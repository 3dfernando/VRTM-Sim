Module ProcessSimulationEngine
    'This module will contain all subs needed to perform the process simulation.
    Private ConveyorPosition_To_Index As New Dictionary(Of Long, Long)

    Public Sub RunProcessSimulation()
        'This will run the process simulation.

        '################Preruns the box times########################
        With VRTM_SimVariables
            Simulation_Results = New SimulationData

            'Seeds the multiple products according to their statistical distributions
            Dim T As Double
            Dim tCurrent As Double = 0
            Dim ArrivalTimes As New SortedDictionary(Of Double, Long)
            Dim idx As Long

            For idx = 0 To .ProductMix.Count - 1
                T = 0
                Do While T < .TotalSimTime
                    If .ProductMix(idx).BoxRateStatisticalDistr.ToLower = "exponential" Then
                        tCurrent = GetExponentialT(3600 / .ProductMix(idx).AvgFlowRate)
                    ElseIf .ProductMix(idx).BoxRateStatisticalDistr.ToLower = "gaussian" Then
                        tCurrent = GetGaussianT(.ProductMix(idx).AvgFlowRate / 3600, .ProductMix(idx).BoxRateStdDev / 3600)
                    End If

                    T = T + tCurrent

                    If IsProductionTime(T) Then
                        'It's producing, so creates another box
                        ArrivalTimes.Add(T, idx) 'Adds the current box in the list (this dictionary automatically sorts them)
                    Else
                        'It's stopped production, so fast-forwards to next turn begin
                        T = Fast_Forward_Next_Turn(T)
                    End If
                Loop
            Next

            'Determines how many conveyors are there
            Dim CList As New List(Of Long)
            For I As Long = 0 To .ProductMix.Count - 1
                CList.Add(.ProductMix(I).ConveyorNumber)
            Next

            Dim UniqueList As List(Of Long)
            UniqueList = CList.Distinct().ToList

            Dim Conveyors() As Conveyor
            ReDim Conveyors(UniqueList.Count - 1)

            ConveyorPosition_To_Index.Clear()
            For I As Long = 0 To UniqueList.Count - 1
                Conveyors(I) = New Conveyor
                Conveyors(I).ConveyorIndex = UniqueList(I)
                ConveyorPosition_To_Index.Add(UniqueList(I), I) 'Fills up the dictionary to lookup the keys in the next step
            Next


            Dim BoxLimit As Long = .boxesPerTray
            Dim currentTrayIndex As Long = 1
            Dim currentLevel As Long
            Dim currentSimulationTimeStep As Long = 1

            'Oversizes the tray data array
            ReDim Simulation_Results.TrayEntryTimes(2 * Int(ArrivalTimes.Count / BoxLimit))
            ReDim Simulation_Results.TrayEntryLevels(2 * Int(ArrivalTimes.Count / BoxLimit))
            ReDim Simulation_Results.TrayExitTimes(2 * Int(ArrivalTimes.Count / BoxLimit))
            ReDim Simulation_Results.TrayStayTime(2 * Int(ArrivalTimes.Count / BoxLimit))
            ReDim Simulation_Results.TrayEntryPositions(2 * Int(ArrivalTimes.Count / BoxLimit))

            ReDim Simulation_Results.VRTMTrayData(Int(VRTM_SimVariables.TotalSimTime / VRTM_SimVariables.MinimumSimDt), .nTrays - 1, .nLevels - 1)
            ReDim Simulation_Results.VRTMTimePositions(Int(VRTM_SimVariables.TotalSimTime / VRTM_SimVariables.MinimumSimDt))

            For I As Long = 0 To UBound(Simulation_Results.VRTMTrayData, 1)
                For J As Long = 0 To UBound(Simulation_Results.VRTMTrayData, 2)
                    For K As Long = 0 To UBound(Simulation_Results.VRTMTrayData, 3)
                        Simulation_Results.VRTMTrayData(I, J, K) = New TrayData
                    Next
                Next
            Next

            'Initializes the first time step with no trays
            For I As Long = 0 To UBound(Simulation_Results.VRTMTrayData, 2)
                For J As Long = 0 To UBound(Simulation_Results.VRTMTrayData, 3)
                    Simulation_Results.VRTMTrayData(0, I, J).TrayIndex = 0
                    Simulation_Results.VRTMTrayData(0, I, J).ConveyorIndex = -1
                Next
            Next


            '####### As more boxes are created, passes the day and defines the loading/organizing actions#######
            Dim prevBoxTime As Long = 0

            For Each k In ArrivalTimes
                'Adds the next box to the conveyor
                'k.Value is the index of the product
                If Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.ContainsKey(k.Value) Then
                    Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor(k.Value) += 1
                Else
                    Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Add(k.Value, 1)
                End If

                Dim boxCountInConveyor As Long = 0
                For Each boxCount In Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor
                    boxCountInConveyor += boxCount.Value
                Next

                If boxCountInConveyor >= BoxLimit Then 'Gets the seeded products and forms trays as the box quantity needed to fill up a tray is achieved
                    If Not LoadNewTray(k, currentTrayIndex, currentLevel, currentSimulationTimeStep, Conveyors) Then
                        MsgBox("This VRTM Size doesn't seem to be enough to fit the selected criteria")
                        Exit Sub
                    End If

                    currentTrayIndex += 1
                    currentSimulationTimeStep += 1

                ElseIf ((k.Key - prevBoxTime) > (3 * 3600)) AndAlso (prevBoxTime > 0) Then
                    '### This will happen when the day turns over. Remaining boxes in all conveyors must be emptied 
                    'for the night, so creates more loading steps for each box ###

                    'Goes through all conveyors and the ones that are not empty will generate a loading 
                    Dim boxCount As Long = 0
                    Dim TimeDelay As Double = 0
                    For Each C As Conveyor In Conveyors
                        boxCount = 0
                        For Each boxType In C.BoxesInConveyor
                            boxCount += boxType.Value
                        Next

                        If boxCount > 0 Then 'There's at least one box in the conveyor
                            Dim fakeKey As New KeyValuePair(Of Double, Long)(prevBoxTime + TimeDelay, C.BoxesInConveyor.Keys(0)) 'This generates a time delay between this and the next key

                            If Not LoadNewTray(fakeKey, currentTrayIndex, currentLevel, currentSimulationTimeStep, Conveyors) Then
                                MsgBox("This VRTM Size doesn't seem to be large enough to fit the selected loading criteria")
                                Exit Sub
                            End If

                            'Updates the loop variables
                            TimeDelay += 300
                            currentTrayIndex += 1
                            currentSimulationTimeStep += 1
                        End If
                    Next

                End If

                'Updates the previous box time
                prevBoxTime = k.Key
            Next

            For I = 0 To UBound(Simulation_Results.TrayEntryTimes)
                Simulation_Results.TrayStayTime(I) = Simulation_Results.TrayExitTimes(I) - Simulation_Results.TrayEntryTimes(I)
                If Simulation_Results.TrayStayTime(I) <= 0 Then
                    Simulation_Results.TrayStayTime(I) = -1
                End If
            Next

            'Resizes the tray data array back (yes, it's painful as coded...)
            ReDim Preserve Simulation_Results.TrayEntryTimes(currentTrayIndex - 1)
            ReDim Preserve Simulation_Results.TrayEntryLevels(currentTrayIndex - 1)
            ReDim Preserve Simulation_Results.VRTMTimePositions(currentSimulationTimeStep - 1)

            Dim TempArray(,,) As TrayData
            ReDim TempArray(currentSimulationTimeStep - 1, .nTrays - 1, .nLevels - 1)

            For I As Long = 0 To currentSimulationTimeStep - 1 'All of this is because Redim Preserve doesn't work in the first dimension
                For J As Long = 0 To .nTrays - 1
                    For K As Long = 0 To .nLevels - 1
                        TempArray(I, J, K) = Simulation_Results.VRTMTrayData(I, J, K)
                    Next
                Next
            Next
            Erase Simulation_Results.VRTMTrayData
            Simulation_Results.VRTMTrayData = TempArray
            Erase TempArray


            Simulation_Results.SimulationComplete = True
        End With
    End Sub

    Public Function LoadNewTray(ByVal k As KeyValuePair(Of Double, Long), ByVal currentTrayIndex As Long, ByVal currentLevel As Long,
                         ByVal currentSimulationTimeStep As Long, ByRef Conveyors() As Conveyor) As Boolean
        'Selects the level according to logic
        Simulation_Results.TrayEntryTimes(currentTrayIndex) = k.Key
        currentLevel = SelectLevel(currentTrayIndex, k.Value)

        If currentLevel = -1 Then
            MsgBox("The given VRTM size is not enough to accomodate all the products" &
                   vbCrLf & "and still meet the minimum retention time requirement." &
                   vbCrLf & "Please consider increasing the VRTM size.", vbOKOnly + vbCritical, "Simulation error")
            Return True
        End If

        'Unload the conveyor and create a tray
        If currentSimulationTimeStep <> 0 Then
            For I As Long = 0 To VRTM_SimVariables.nTrays - 1
                For J As Long = 0 To VRTM_SimVariables.nLevels - 1
                    'Copies the last timestep onto the current timestep
                    Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I, J) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).Clone
                Next
            Next
        End If

        'Advances all the other trays in this level
        For I As Long = VRTM_SimVariables.nTrays - 1 To 1 Step -1
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I, currentLevel) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I - 1, currentLevel).Clone
        Next

        'Puts the current tray here
        Simulation_Results.VRTMTrayData(currentSimulationTimeStep, 0, currentLevel).TrayIndex = currentTrayIndex
        Simulation_Results.VRTMTrayData(currentSimulationTimeStep, 0, currentLevel).ConveyorIndex = VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber
        Simulation_Results.VRTMTrayData(currentSimulationTimeStep, 0, currentLevel).ProductIndices = Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor
        Simulation_Results.TrayEntryPositions(currentTrayIndex) = currentSimulationTimeStep
        Simulation_Results.VRTMTimePositions(currentSimulationTimeStep) = k.Key

        'Clears the conveyor
        Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Clear()

        'Updates the level and exit times
        Simulation_Results.TrayEntryLevels(currentTrayIndex) = currentLevel
        Dim ExitingTrayIndex As Long
        ExitingTrayIndex = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, VRTM_SimVariables.nTrays - 1, currentLevel).TrayIndex
        If Not ExitingTrayIndex <= 0 Then Simulation_Results.TrayExitTimes(ExitingTrayIndex) = k.Key


        Return True
    End Function




    Public Class Conveyor
        'Models the array of products inside a conveyor belt (will store only the indices)
        Public BoxesInConveyor As New Dictionary(Of Long, Long)
        Public ConveyorIndex As Long
    End Class


    Public Function GetExponentialT(MeanArrivalTime As Double) As Double
        'Outputs an exponentially distributed arrival time given an average rate
        GetExponentialT = (-1) * MeanArrivalTime * Math.Log(1 - Rnd())
    End Function

    Public Function GetGaussianT(MeanRate As Double, StdRateDev As Double) As Double
        'Outputs a Gaussian distributed arrival time given an average rate
        Dim U1, U2 As Double
        U1 = Rnd()
        U2 = Rnd()

        Dim Z0 As Double
        Z0 = Math.Sqrt(-2 * Math.Log(U1))
        Z0 *= Math.Cos(2 * Math.PI * U2)

        GetGaussianT = 1 / (MeanRate + Z0 * StdRateDev)
    End Function

    Public Function IsProductionTime(t As Double) As Boolean
        'Defines whether this time t (in s from zero) is inside the production hours.
        Dim DayOfWeek As Integer
        DayOfWeek = Math.Floor((t / 86400)) Mod 7

        If VRTM_SimVariables.ProductionDays(DayOfWeek) Then 'It's producing today
            Dim Hours_Intraday As Double
            Hours_Intraday = (t Mod 86400) / 86400
            If (VRTM_SimVariables.FirstTurnBegin <= Hours_Intraday And VRTM_SimVariables.FirstTurnEnd >= Hours_Intraday) _
                Or (VRTM_SimVariables.SecondTurnBegin <= Hours_Intraday And Return_1_if_0(VRTM_SimVariables.SecondTurnEnd) >= Hours_Intraday) Then
                'It's producing now, too.
                Return True
            End If
        End If

        Return False
    End Function

    Public Function Fast_Forward_Next_Turn(t As Double) As Double
        'Returns the next value of t that is inside a valid turn time
        Dim Hours_Intraday As Double
        Dim Hours_FF As Double
        Dim Days_FF As Double
        Dim DayOfWeek As Integer
        Dim I As Integer

        Hours_Intraday = (t Mod 86400) / 86400
        DayOfWeek = Math.Floor((t / 86400)) Mod 7

        'If now is before the turn began today, we don't know whether today is a working day
        If Hours_Intraday < VRTM_SimVariables.FirstTurnBegin Then
            If VRTM_SimVariables.ProductionDays(DayOfWeek) Then 'It's producing today
                Hours_FF = VRTM_SimVariables.FirstTurnBegin
                Days_FF = 0
            Else 'Roll to next days of production
                For I = DayOfWeek + 1 To 6
                    If VRTM_SimVariables.ProductionDays(I) Then 'It's producing this day
                        Days_FF = I - DayOfWeek
                    End If
                Next
                For I = 0 To DayOfWeek
                    If VRTM_SimVariables.ProductionDays(I) Then 'It's producing this day
                        Days_FF = 7 + (I - DayOfWeek)
                        Exit For
                    End If
                Next
                Hours_FF = VRTM_SimVariables.FirstTurnBegin
            End If

        ElseIf Hours_Intraday < VRTM_SimVariables.SecondTurnBegin Then 'It is supposed here that the FirstTurnEnds has already been tested
            Hours_FF = VRTM_SimVariables.SecondTurnBegin
            Days_FF = 0
        ElseIf Hours_Intraday > Return_1_if_0(VRTM_SimVariables.SecondTurnEnd) Then 'This means it's gonna roll around the next day
            If VRTM_SimVariables.ProductionDays(DayOfWeek + 1) Then 'It's producing today
                Hours_FF = VRTM_SimVariables.FirstTurnBegin
                Days_FF = 1
            Else 'Roll to next days of production
                For I = DayOfWeek + 2 To 6
                    If VRTM_SimVariables.ProductionDays(I) Then 'It's producing this day
                        Days_FF = I - DayOfWeek
                    End If
                Next
                For I = 0 To DayOfWeek + 1
                    If VRTM_SimVariables.ProductionDays(I) Then 'It's producing this day
                        Days_FF = I - DayOfWeek
                    End If
                Next
                Hours_FF = VRTM_SimVariables.FirstTurnBegin
            End If
        End If

        'Composes the next production time from zero to return
        Dim CurrentDay As Long
        CurrentDay = Int(t / 86400)

        Fast_Forward_Next_Turn = ((CurrentDay + Days_FF) * 86400) + Hours_FF * 86400

    End Function

    Public Function SelectLevel(t As Long, prodIndex As Long) As Long
        'This implements the logic of selecting a level in the tunnel
        With VRTM_SimVariables
            Dim availableLevels As New List(Of Long)
            Dim stayTime, exitEntryTime As Double

            For I As Long = 0 To .nLevels - 1
                exitEntryTime = Simulation_Results.TrayEntryTimes(Simulation_Results.VRTMTrayData(t - 1, .nTrays - 1, I).TrayIndex)
                stayTime = Simulation_Results.TrayEntryTimes(t) - exitEntryTime
                If (stayTime > (.ProductMix(prodIndex).MinimumStayTime * 3600)) Or
                    (exitEntryTime = 0) Then
                    availableLevels.Add(I)
                Else
                    Dim A As Long = 0
                End If
            Next

            If availableLevels.Count > 0 Then
                SelectLevel = availableLevels(Int(Rnd() * (availableLevels.Count)))
            Else
                SelectLevel = -1
            End If
        End With
    End Function
End Module
