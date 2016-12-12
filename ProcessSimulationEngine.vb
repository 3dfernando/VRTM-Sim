Module ProcessSimulationEngine
    'This module will contain all subs needed to perform the process simulation.
    Private ConveyorPosition_To_Index As New Dictionary(Of Long, Long)

    Public Sub RunProcessSimulation()
        'This will run the process simulation.

        '################Preruns the box times########################
        With VRTM_SimVariables
            'Seeds the multiple products according to their statistical distributions
            Dim T As Double
            Dim tCurrent As Double = 0
            Dim ArrivalTimes As New SortedDictionary(Of Double, Long)
            Dim idx As Long

            For idx = 0 To .ProductMix.Count - 1
                T = 0
                Do While T < .TotalSimTime
                    If IsProductionTime(T) Then
                        'It's producing, so creates another box
                        If .ProductMix(idx).BoxRateStatisticalDistr.ToLower = "exponential" Then
                            tCurrent = GetExponentialT(3600 / .ProductMix(idx).AvgFlowRate)
                        ElseIf .ProductMix(idx).BoxRateStatisticalDistr.ToLower = "gaussian" Then
                            tCurrent = GetGaussianT(.ProductMix(idx).AvgFlowRate / 3600, .ProductMix(idx).BoxRateStdDev / 3600)
                        End If
                        T = T + tCurrent
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
                CList.add(.ProductMix(I).ConveyorNumber)
            Next

            Dim UniqueList As List(Of Long)
            UniqueList = CList.Distinct().ToList

            Dim Conveyors() As Conveyor
            ReDim Conveyors(UniqueList.Count - 1)

            For I As Long = 0 To UniqueList.Count - 1
                Conveyors(I) = New Conveyor
                Conveyors(I).ConveyorIndex = UniqueList(I)
                ConveyorPosition_To_Index.Add(UniqueList(I), I) 'Fills up the dictionary to lookup the keys in the next step
            Next


            Dim BoxLimit As Long = .boxesPerTray
            Dim currentTrayIndex As Long = 1
            Dim currentLevel As Long

            'Oversizes the tray data array
            ReDim .SimData.TrayEntryTimes(Int(ArrivalTimes.Count / BoxLimit))
            ReDim .SimData.TrayEntryLevels(Int(ArrivalTimes.Count / BoxLimit))
            ReDim .SimData.VRTMTrayData(Int(ArrivalTimes.Count / BoxLimit), .nTrays - 1, .nLevels - 1)
            For I As Long = 0 To UBound(.SimData.VRTMTrayData, 1)
                For J As Long = 0 To UBound(.SimData.VRTMTrayData, 2)
                    For K As Long = 0 To UBound(.SimData.VRTMTrayData, 3)
                        .SimData.VRTMTrayData(I, J, K) = New TrayData
                    Next
                Next
            Next

            'Initializes the first time step with no trays
            For I As Long = 0 To UBound(.SimData.VRTMTrayData, 2)
                For J As Long = 0 To UBound(.SimData.VRTMTrayData, 3)
                    .SimData.VRTMTrayData(0, I, J).TrayIndex = 0
                Next
            Next


            '#######Gets the seeded products and forms trays as the box quantity needed to fill up a tray is achieved#######
            For Each k In ArrivalTimes
                Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Add(k.Value)
                If Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Count >= BoxLimit Then
                    'Unload the conveyor and create a tray
                    currentLevel = Int(Rnd() * (.nLevels))

                    If currentTrayIndex <> 0 Then
                        For I As Long = 0 To .nTrays - 1
                            For J As Long = 0 To .nLevels - 1
                                'Copies the last timestep onto the current timestep
                                .SimData.VRTMTrayData(currentTrayIndex, I, J) = .SimData.VRTMTrayData(currentTrayIndex - 1, I, J).Clone
                            Next
                        Next
                    End If

                    'Advances all the other trays in this level
                    For I As Long = .nTrays - 1 To 1 Step -1
                        .SimData.VRTMTrayData(currentTrayIndex, I, currentLevel) = .SimData.VRTMTrayData(currentTrayIndex, I - 1, currentLevel).Clone
                    Next

                    'Puts the current tray here
                    VRTM_SimVariables.SimData.VRTMTrayData(currentTrayIndex, 0, currentLevel).TrayIndex = currentTrayIndex
                    VRTM_SimVariables.SimData.VRTMTrayData(currentTrayIndex, 0, currentLevel).ConveyorIndex = VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber

                    'Clears the conveyor
                    Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Clear()

                    'Updates the arrival and exit times
                    .SimData.TrayEntryTimes(currentTrayIndex) = k.Key
                    .SimData.TrayEntryLevels(currentTrayIndex) = currentLevel

                    currentTrayIndex += 1
                End If
            Next

            'Resizes the tray data array back 
            ReDim Preserve .SimData.TrayEntryTimes(currentTrayIndex - 1)
            ReDim Preserve .SimData.TrayEntryLevels(currentTrayIndex - 1)
            'ReDim Preserve .SimData.VRTMTrayData(currentTrayIndex - 1, .nTrays - 1, .nLevels - 1)' Unfortunately this is impossible


            .SimData.SimulationComplete = True
        End With
    End Sub

    Public Class Conveyor
        'Models the array of products inside a conveyor belt (will store only the indices)
        Public BoxesInConveyor As New List(Of Double)
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

End Module
