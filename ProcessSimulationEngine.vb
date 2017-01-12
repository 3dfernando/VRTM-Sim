Module ProcessSimulationEngine
    'This module will contain all subs needed to perform the process simulation.
    Private ConveyorPosition_To_Index As New Dictionary(Of Long, Long)
    Private ConveyorIndexDemanded As Long 'This variable has been made public to facilitate debugging by the user (it's going to be shown in the message box)
    Public TimeWhereSimulationStopped As Double 'This will store the simulation stop time so the scroll bar positions itself automatically in the case of an error.
    Public UniformConveyorRandomNumberLimits() As Double 'Get a random number and compare to this list to find which product should be selected according to the production rates.

    Public Sub RunProcessSimulation()
        'This will run the process simulation.
        'Inits variables
        Simulation_Results = New SimulationData
        TimeWhereSimulationStopped = 0
        GenerateUniformDistributionWeightList()

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
            ReDim Simulation_Results.TrayExitTimes(2 * Int(ArrivalTimes.Count / BoxLimit))
            ReDim Simulation_Results.TrayStayTime(2 * Int(ArrivalTimes.Count / BoxLimit))
            ReDim Simulation_Results.TrayEntryPositions(2 * Int(ArrivalTimes.Count / BoxLimit))

            ReDim Simulation_Results.VRTMTrayData(Int(VRTM_SimVariables.TotalSimTime / VRTM_SimVariables.MinimumSimDt), .nTrays - 1, .nLevels - 1)
            ReDim Simulation_Results.VRTMTimePositions(Int(VRTM_SimVariables.TotalSimTime / VRTM_SimVariables.MinimumSimDt))
            ReDim Simulation_Results.EmptyElevatorB(Int(VRTM_SimVariables.TotalSimTime / VRTM_SimVariables.MinimumSimDt))
            ReDim Simulation_Results.Elevator(Int(VRTM_SimVariables.TotalSimTime / VRTM_SimVariables.MinimumSimDt))
            ReDim Simulation_Results.TrayEntryLevels(Int(VRTM_SimVariables.TotalSimTime / VRTM_SimVariables.MinimumSimDt))


            'Defines the empty elevator as the second (Right-hand, B)
            Simulation_Results.EmptyElevatorB(0) = True 'true=Elev 2
            Simulation_Results.Elevator(0) = New TrayData
            Simulation_Results.Elevator(0).TrayIndex = 0
            Simulation_Results.Elevator(0).ConveyorIndex = -1

            'Inits the trays inside the tunnel
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


            '####### As more boxes are created, advances into the day and defines the loading/organizing actions#######
            Dim prevBoxTime As Long = 0
            Dim elevatorMovementTime As Double
            Dim prevLevel As Long = 1
            Dim ElevatorWaitUntil As Double = 0 'Absolute time where the elevator will be ready
            Dim lostBoxes As Long = 0 'Counts the boxes that have been lost due to elevator wait

            For Each k In ArrivalTimes
                'Adds the next box to the conveyor
                'k.Key is the time of arrival (seconds from start)
                'k.Value is the index of the product in the ProductMix

                'First counts the boxes in the conveyor to ensure it doesnt exceed the number of boxes
                Dim boxCountInConveyor As Long = 0
                For Each boxCount In Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor
                    boxCountInConveyor += boxCount.Value
                Next


                If boxCountInConveyor >= BoxLimit Then
                    boxCountInConveyor = BoxLimit 'Will delete a box that exceeded the accumulator size
                    lostBoxes += 1
                Else
                    'Adds the box
                    If Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.ContainsKey(k.Value) Then
                        Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor(k.Value) += 1
                    Else
                        Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Add(k.Value, 1)
                    End If
                End If

                If boxCountInConveyor >= BoxLimit Then 'Gets the seeded products and forms trays as the box quantity needed to fill up a tray is achieved
                    If k.Key > ElevatorWaitUntil Then 'Will only perform a loading if the elevator is ready
                        'Loads the tray
                        If Not LoadNewTray(k, currentTrayIndex, currentLevel, currentSimulationTimeStep, Conveyors) Then

                            MsgBox("This VRTM Size doesn't seem to be large enough to fit the selected loading criteria" & vbCrLf &
                                       "Simulation stopped at " & GetCurrentTimeString(k.Key) & vbCrLf &
                                       "Product that was being loaded had a conveyor index of " & Trim(Str(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)) &
                                       " and the demand was a product of conveyor index of " & Trim(Str(ConveyorIndexDemanded)))
                            TimeWhereSimulationStopped = k.Key
                            GoTo PostProcessing
                        End If
                        elevatorMovementTime = Compute_Entire_Cycle_Time(prevLevel, currentLevel) 'computes the time for the elevator to complete a loading/unloading cycle
                        prevLevel = currentLevel
                        ElevatorWaitUntil = k.Key + elevatorMovementTime

                        'Updates the loop variables
                        currentTrayIndex += 1
                        currentSimulationTimeStep += 1
                    End If


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

                            'Loads the tray
                            If Not LoadNewTray(fakeKey, currentTrayIndex, currentLevel, currentSimulationTimeStep, Conveyors) Then
                                MsgBox("This VRTM Size doesn't seem to be large enough to fit the selected loading criteria" & vbCrLf &
                                       "Simulation stopped at " & GetCurrentTimeString(k.Key) & vbCrLf &
                                       "Product that was being loaded had a conveyor index of " & Trim(Str(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)) &
                                       " and the demand was a product of conveyor index of " & Trim(Str(ConveyorIndexDemanded)))
                                TimeWhereSimulationStopped = prevBoxTime + TimeDelay
                                GoTo PostProcessing
                            End If
                            elevatorMovementTime = Compute_Entire_Cycle_Time(prevLevel, currentLevel)
                            prevLevel = currentLevel


                            'Updates the loop variables
                            TimeDelay += elevatorMovementTime
                            currentTrayIndex += 1
                            currentSimulationTimeStep += 1
                        End If
                    Next

                    '============RESHELVING===========
                    If VRTM_SimVariables.EnableIdleReshelving Then
                        'Now employs the organization strategy to reorganize the tunnel

                        'Defines if the window is sufficient according to the configs
                        If (k.Key - prevBoxTime) > VRTM_SimVariables.MinimumReshelvingWindow * 3600 Then
                            Dim AvailableTime As Double
                            AvailableTime = (k.Key - prevBoxTime) 'Gets how much time is available to reshelve

                            'Reshelving won't make sense unless the configuration is demand-based, so checks that.
                            If VRTM_SimVariables.LevelChoosing = 1 Then

                                'Checks whether we reached the delay configured. If so, are we in the first reshelving operation after the production-based level choosing?
                                Dim CurrentDay As Long
                                Dim Recipe As New List(Of Long)

                                CurrentDay = Int(k.Key / (24 * 3600))
                                If CurrentDay = VRTM_SimVariables.DelayDemandTime - 1 Then
                                    'Performs a preparation reorganization
                                    Recipe = DefineOrganizationMovementsProdDemandTransition(currentSimulationTimeStep, AvailableTime, k.Key) 'Calls the primer organization routine and gets the recipe for organization
                                ElseIf CurrentDay > VRTM_SimVariables.DelayDemandTime - 1 Then
                                    Recipe = DefineOrganizationMovements(currentSimulationTimeStep, AvailableTime, k.Key) 'Calls the regular organization routine and gets the recipe for organization
                                End If

                                If CurrentDay >= VRTM_SimVariables.DelayDemandTime - 1 Then
                                    'Actually performs the reshelving operation according to the recipe
                                    For Each currentLevel In Recipe 'These are the new current levels

                                        elevatorMovementTime = Compute_Reshelving_Cycle_Time(prevLevel, currentLevel)
                                        TimeDelay += elevatorMovementTime

                                        PerformReshelvingMovement(currentLevel, currentSimulationTimeStep, prevBoxTime + TimeDelay)

                                        'Updates the loop variables
                                        prevLevel = currentLevel
                                        currentSimulationTimeStep += 1
                                    Next
                                End If

                            End If

                        End If
                    End If
                End If

                'Updates the previous box time
                prevBoxTime = k.Key
            Next

PostProcessing:
            For I = 0 To UBound(Simulation_Results.TrayEntryTimes)
                Simulation_Results.TrayStayTime(I) = Simulation_Results.TrayExitTimes(I) - Simulation_Results.TrayEntryTimes(I)
                If Simulation_Results.TrayStayTime(I) <= 0 Then
                    Simulation_Results.TrayStayTime(I) = -1
                End If
            Next

            'Resizes the tray data array back (yes, it's painful as coded...)
            ReDim Preserve Simulation_Results.TrayEntryTimes(currentTrayIndex - 1)
            ReDim Preserve Simulation_Results.TrayEntryPositions(currentTrayIndex - 1)
            ReDim Preserve Simulation_Results.TrayEntryLevels(currentSimulationTimeStep - 1)
            ReDim Preserve Simulation_Results.VRTMTimePositions(currentSimulationTimeStep - 1)
            ReDim Preserve Simulation_Results.EmptyElevatorB(currentSimulationTimeStep - 1)
            ReDim Preserve Simulation_Results.Elevator(currentSimulationTimeStep - 1)

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

            'Warns the user if the tunnel hasn't been fast enough to feed all the boxes
            If lostBoxes > 0 Then
                Dim PercentBoxes As Double = Int((lostBoxes / ArrivalTimes.Count) * 100 * 10) / 10
                MsgBox("Warning: The TRVM wasn't fast enough to feed all the boxes that arrived." & vbCrLf _
                       & Trim(Str(lostBoxes)) & " boxes (" & Trim(Str(PercentBoxes)) & "%) were removed from the simulation as ""Production delay"".")
            End If

            Simulation_Results.SimulationComplete = True
        End With
    End Sub

    Public Function PerformReshelvingMovement(ByRef currentLevel As Long, ByVal currentSimulationTimeStep As Long, ByVal CurrentTime As Double) As Boolean
        'This performs one reshelving operation.

        If currentLevel = -1 Then Return False

        If currentSimulationTimeStep <> 0 Then
            For I As Long = 0 To VRTM_SimVariables.nTrays - 1
                For J As Long = 0 To VRTM_SimVariables.nLevels - 1
                    'Copies the last timestep onto the current timestep
                    Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I, J) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).Clone
                Next
            Next
        End If

        'Detects the elevator side
        If Simulation_Results.EmptyElevatorB(currentSimulationTimeStep - 1) Then
            'Performs movement A->>B
            Simulation_Results.Elevator(currentSimulationTimeStep) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, VRTM_SimVariables.nTrays - 1, currentLevel).Clone

            For I = VRTM_SimVariables.nTrays - 2 To 0 Step -1
                Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I + 1, currentLevel) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, currentLevel).Clone
            Next
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, 0, currentLevel) = Simulation_Results.Elevator(currentSimulationTimeStep - 1).Clone

            Simulation_Results.EmptyElevatorB(currentSimulationTimeStep) = False
        Else
            'Performs movement B->>A
            Simulation_Results.Elevator(currentSimulationTimeStep) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, 0, currentLevel).Clone

            For I = 1 To VRTM_SimVariables.nTrays - 1
                Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I - 1, currentLevel) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, currentLevel).Clone
            Next
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, VRTM_SimVariables.nTrays - 1, currentLevel) = Simulation_Results.Elevator(currentSimulationTimeStep - 1).Clone

            Simulation_Results.EmptyElevatorB(currentSimulationTimeStep) = True
        End If

        'Updates the VRTM Variables
        Simulation_Results.VRTMTimePositions(currentSimulationTimeStep) = CurrentTime
        Simulation_Results.TrayEntryLevels(currentSimulationTimeStep) = currentLevel

        Return True

    End Function

    Public Function LoadNewTray(ByVal k As KeyValuePair(Of Double, Long), ByVal currentTrayIndex As Long, ByRef currentLevel As Long,
                         ByVal currentSimulationTimeStep As Long, ByRef Conveyors() As Conveyor) As Boolean
        'Selects the level according to logic
        Simulation_Results.TrayEntryTimes(currentTrayIndex) = k.Key
        currentLevel = SelectLevel(currentTrayIndex, currentSimulationTimeStep, k.Value)

        If currentLevel = -1 Then Return False

        Dim Prods As New Dictionary(Of Long, Long)
        If currentSimulationTimeStep <> 0 Then
            For I As Long = 0 To VRTM_SimVariables.nTrays - 1
                For J As Long = 0 To VRTM_SimVariables.nLevels - 1
                    'Copies the last timestep onto the current timestep
                    Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I, J) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).Clone
                Next
            Next
        End If

        'Stores the index of the exiting tray
        Dim ExitingTrayIndex As Long
        ExitingTrayIndex = Simulation_Results.VRTMTrayData(currentSimulationTimeStep, 0, VRTM_SimVariables.ReturnLevel - 1).TrayIndex

        'First, advances (backwards) the trays in the return level
        For I As Long = 0 To VRTM_SimVariables.nTrays - 2
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I, VRTM_SimVariables.ReturnLevel - 1) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I + 1, VRTM_SimVariables.ReturnLevel - 1).Clone
        Next

        'Then places the contents of elevator 2 in the last tray of the return level
        If Not IsNothing(Simulation_Results.Elevator(currentSimulationTimeStep - 1)) Then
            If Simulation_Results.Elevator(currentSimulationTimeStep - 1).ConveyorIndex <> -1 Then
                Dim asld As String = ""
            End If
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.ReturnLevel - 1) = Simulation_Results.Elevator(currentSimulationTimeStep - 1).Clone
        Else
            'There was nothing in the elevator 2 (first loop), so fills up the return level with an empty tray
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.ReturnLevel - 1) = New TrayData
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.ReturnLevel - 1).TrayIndex = 0
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.ReturnLevel - 1).ConveyorIndex = -1
        End If


        'Before loading the current level fills up the elevator 2 contents (In normal loading the elevator 2 is the only shown)
        Simulation_Results.EmptyElevatorB(currentSimulationTimeStep) = False
        Simulation_Results.Elevator(currentSimulationTimeStep) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep, VRTM_SimVariables.nTrays - 1, currentLevel).Clone

        'Advances all the other trays in this level
        For I As Long = VRTM_SimVariables.nTrays - 1 To 1 Step -1
            Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I, currentLevel) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I - 1, currentLevel).Clone
        Next

        'Puts the current tray here
        Simulation_Results.VRTMTrayData(currentSimulationTimeStep, 0, currentLevel).TrayIndex = currentTrayIndex
        Simulation_Results.VRTMTrayData(currentSimulationTimeStep, 0, currentLevel).ConveyorIndex = VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber
        Simulation_Results.VRTMTrayData(currentSimulationTimeStep, 0, currentLevel).ProductIndices = New Dictionary(Of Long, Long)(Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor)
        Simulation_Results.TrayEntryPositions(currentTrayIndex) = currentSimulationTimeStep
        Simulation_Results.VRTMTimePositions(currentSimulationTimeStep) = k.Key

        'Clears the conveyor
        Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Clear()

        'Updates the level and exit times
        Simulation_Results.TrayEntryLevels(currentSimulationTimeStep) = currentLevel
        If Not ExitingTrayIndex <= 0 Then Simulation_Results.TrayExitTimes(ExitingTrayIndex) = k.Key


        Return True
    End Function


    Public Class Conveyor
        'Models the array of products inside a conveyor belt (will store only the indices)
        Public BoxesInConveyor As New Dictionary(Of Long, Long)
        Public ConveyorIndex As Long
    End Class

    Public Function Compute_Reshelving_Cycle_Time(StartLevel As Integer, EndLevel As Integer) As Double
        'Time in seconds for elevator cycle when reshelving 

        With VRTM_SimVariables
            '1. Moves to target level
            Compute_Reshelving_Cycle_Time = Compute_Elevator_Time(StartLevel, EndLevel)
            '2. Transfers trays
            Compute_Reshelving_Cycle_Time = Compute_Reshelving_Cycle_Time + .TrayTransferTime
        End With

    End Function

    Public Function Compute_Entire_Cycle_Time(StartLevel As Integer, EndLevel As Integer) As Double
        'Time in seconds for elevator cycle

        With VRTM_SimVariables
            '1. Transfers the trays from elevator A to elevator B
            Compute_Entire_Cycle_Time = .TrayTransferTime
            '2. Descends to return level
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + Compute_Elevator_Time(StartLevel, .ReturnLevel - 1)
            '3. Transfers trays from B to A
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + .TrayTransferTime
            '4. Moves elevator to unload level
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + Compute_Elevator_Time(.ReturnLevel - 1, .UnloadLevel - 1)
            '5. Moves discharge device forwards
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + .UnloaderRetractionTime
            '6. Aligns with the discharge level
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + Compute_Elevator_Time(.UnloadLevel - 1, .UnloadLevel)
            '7. Retracts discharge device
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + .UnloaderRetractionTime
            '8. Moves the elevator to loading level
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + Compute_Elevator_Time(.UnloadLevel - 1, .LoadLevel - 1)
            '9. Loads boxes in tray
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + .BoxLoadingTime
            '10. Moves loaded elevator to work level
            Compute_Entire_Cycle_Time = Compute_Entire_Cycle_Time + Compute_Elevator_Time(.LoadLevel - 1, EndLevel - 1)

        End With

    End Function

    Public Function Compute_Elevator_Time(StartLevel As Integer, EndLevel As Integer) As Double
        'Time in seconds for the elevator displacement

        With VRTM_SimVariables
            Dim AccelDist As Double = (.ElevSpeed * .ElevSpeed) / (2 * .ElevAccel) 'Minimum distance to accelerate the elevator to full speed 
            Dim TravelDist As Double = Math.Abs(EndLevel - StartLevel) * (.LevelCenterDist / 1000)

            If TravelDist > 2 * AccelDist Then
                'The elevator reaches full speed. Calculates in two parts, the accel/deccel time and the full speed time
                Compute_Elevator_Time = 2 * (.ElevSpeed / .ElevAccel) + (TravelDist - 2 * AccelDist) / .ElevSpeed
            Else
                'The elevator never reaches full speed, there is only acceleration and decceleration
                Dim MaxSpeed As Double = Math.Sqrt(2 * .ElevAccel * TravelDist)
                Compute_Elevator_Time = 2 * (MaxSpeed / .ElevAccel)
            End If
        End With

    End Function

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

    Public Function SelectLevel(t As Long, ByVal currentSimulationTimeStep As Long, prodIndex As Long) As Long
        'This implements the logic of selecting a level in the tunnel
        With VRTM_SimVariables
            Dim availableLevels As New List(Of Long)
            Dim stayTime, exitEntryTime As Double

            For I As Long = 0 To .nLevels - 1
                exitEntryTime = Simulation_Results.TrayEntryTimes(Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, .nTrays - 1, I).TrayIndex)
                stayTime = Simulation_Results.TrayEntryTimes(t) - exitEntryTime
                If (stayTime > (.ProductMix(prodIndex).MinimumStayTime * 3600)) Or
                    (exitEntryTime = 0) Then
                    If I <> VRTM_SimVariables.ReturnLevel - 1 Then availableLevels.Add(I) 'Don't use the return level to do this
                Else
                    Dim A As Long = 0
                End If
            Next

            If availableLevels.Count > 0 Then
                'There are available levels.
                If VRTM_SimVariables.LevelChoosing = 0 Then 'Production
                    'Selects levels according to the production demand
                    SelectLevel = SelectLevelAccordingToProduction(availableLevels, t, currentSimulationTimeStep, prodIndex)
                ElseIf VRTM_SimVariables.LevelChoosing = 1 Then 'Demand
                    If .DelayDemand And (Simulation_Results.TrayEntryTimes(t) < (.DelayDemandTime - 1) * 3600 * 24) Then
                        'Selects levels to keep stuff organized
                        SelectLevel = SelectLevelAccordingToProduction(availableLevels, t, currentSimulationTimeStep, prodIndex)
                    Else
                        'Selects levels according to a demand profile
                        If .PickingOrders = 0 Then
                            'Random demands a conveyor index type and requests it
                            ConveyorIndexDemanded = DemandUniformRandomProduct()
                            Dim NarrowedAvailableLevels As New List(Of Long)

                            For Each L As Long In availableLevels
                                If Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, .nTrays - 1, L).ConveyorIndex = ConveyorIndexDemanded Then
                                    'Whether it's frozen AND has the selected product index
                                    NarrowedAvailableLevels.Add(L)
                                End If
                            Next

                            'The simulation failed as there is no available frozen product of the given index
                            If NarrowedAvailableLevels.Count = 0 Then
                                SelectLevel = -1
                            Else
                                'Select the maximum stay time available (as a FIFO-like system)
                                Dim stayTimeMaxAt As Long = 0
                                stayTime = Double.MinValue
                                For Each N As Long In NarrowedAvailableLevels
                                    exitEntryTime = Simulation_Results.TrayEntryTimes(Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, .nTrays - 1, N).TrayIndex)
                                    If (exitEntryTime - Simulation_Results.TrayEntryTimes(t)) > stayTime Then
                                        stayTime = exitEntryTime - Simulation_Results.TrayEntryTimes(t)
                                        stayTimeMaxAt = N
                                    End If
                                Next

                                SelectLevel = stayTimeMaxAt

                            End If

                        Else
                            'Demand is according to file
                            SelectLevel = -1
                        End If
                    End If
                ElseIf VRTM_SimVariables.LevelChoosing = 2 Then 'Random
                    SelectLevel = availableLevels(Int(Rnd() * (availableLevels.Count)))
                Else
                    SelectLevel = -1
                End If
            Else
                SelectLevel = -1
            End If
        End With
    End Function

    Public Function SelectLevelAccordingToProduction(availableLevels As List(Of Long), t As Long, currentSimulationTimeStep As Long, prodIndex As Long) As Long
        With VRTM_SimVariables
            'Will feed to the closest to loading level and never put a product on a level where there is another product already.
            Dim ConvIndex As Long = .ProductMix(prodIndex).ConveyorNumber

            'Selects the levels that have the current conveyor index
            Dim MatchedLevels As New List(Of Long)
            For Each l As Long In availableLevels
                If Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, 0, l).ConveyorIndex = ConvIndex Then
                    MatchedLevels.Add(l)
                End If
            Next

            If MatchedLevels.Count = 0 Then
                'No matches, tries to find an empty level then
                For Each l As Long In availableLevels
                    If Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, 0, l).ConveyorIndex = -1 Then
                        MatchedLevels.Add(l)
                    End If
                Next

                If MatchedLevels.Count = 0 Then
                    'Now we're locked, as there is nothing to do
                    SelectLevelAccordingToProduction = -1
                    Exit Function
                End If
            End If

            'If we didn't exit function then we can proceed to find the closest level to the loading level (minimize travel time)
            Dim MinDist As Long = Long.MaxValue
            Dim MinDistAt As Long = 0

            For Each Level As Long In MatchedLevels
                If Math.Abs(Level - VRTM_SimVariables.LoadLevel) < MinDist Then
                    MinDist = Math.Abs(Level - VRTM_SimVariables.LoadLevel)
                    MinDistAt = Level
                End If
            Next

            SelectLevelAccordingToProduction = MinDistAt
        End With
    End Function

    Public Function DemandUniformRandomProduct() As Long
        'This function selects a random product and outputs a conveyor index according to the inflow rate
        Dim R As Double = Rnd()
        For I As Long = 0 To VRTM_SimVariables.InletConveyors.Count - 1
            If R < UniformConveyorRandomNumberLimits(I) Then
                'Selects it
                Return I
            End If
        Next
        Return Nothing 'Just to throw an error because this shouldn't make sense (R>1?)
    End Function

    Public Sub GenerateUniformDistributionWeightList()
        'This function helps to generate a random demand based on a weighted uniform distribution
        'Numbers between 0-1 

        'First totalizes the production rates for each conveyor
        Dim ProductionRates() As Double
        Dim TotalProductionRate As Double = 0
        ReDim ProductionRates(VRTM_SimVariables.InletConveyors.Count - 1)
        ReDim UniformConveyorRandomNumberLimits(VRTM_SimVariables.InletConveyors.Count - 1)


        For Each P As ProductData In VRTM_SimVariables.ProductMix
            ProductionRates(P.ConveyorNumber) += P.AvgFlowRate
            TotalProductionRate += P.AvgFlowRate
        Next

        'Computes the partial coefficients for each random number
        Dim AccumProductionRate As Double = 0
        For I As Long = 0 To VRTM_SimVariables.InletConveyors.Count - 1
            AccumProductionRate += ProductionRates(I)
            UniformConveyorRandomNumberLimits(I) = AccumProductionRate / TotalProductionRate
        Next

    End Sub


End Module
