Module ProcessSimulationEngine_Organization
    'TERMINOLOGY DEFINITION:
    'Movement: The basic "atom", it's group of elevator movements that consists of a level translation and a tray transfer.
    'Move: Group of movements, representing a "game move". Examples: "Transfer all frozen trays from one level to another" or "Remove all random frozen trays from one level and put them in many different levels"
    'Operation: Group of moves, represents a complete move set that accomplishes an important task. Examples: "Unscramble all possible frozen products" or "Make available all low-flow products"

    Public Class TrayDataSimplified
        'This class contains the data of a tray [Simplified version for the purpose of organization, memory saving]
        Public ConveyorIndex As Long ' Conveyor index
        Public Frozen As Boolean

        Public Function Clone() As TrayDataSimplified
            Return DirectCast(Me.MemberwiseClone(), TrayDataSimplified)
        End Function
    End Class

    Public Class VRTMStateSimplified
        'This class contain a VRTM State (Simplified version)
        Public TrayState(,) As TrayDataSimplified 'Will hold the current VRTM state in memory
        Public ElevatorState As TrayDataSimplified 'Will hold the tray in the elevator
        Public EmptyElevatorB As Boolean 'Will hold whether the elevator B is empty
        Public StateHash As String 'Holds a "probably" unique hash for the state, to compare between states.

        Public Function Clone() As VRTMStateSimplified
            'Clones the state 
            Dim ClonedState As New VRTMStateSimplified
            ClonedState.ElevatorState = Me.ElevatorState.Clone
            ClonedState.EmptyElevatorB = Me.EmptyElevatorB
            ClonedState.StateHash = Me.StateHash

            ReDim ClonedState.TrayState(VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.nLevels - 1)

            For J = 0 To VRTM_SimVariables.nLevels - 1
                For I = 0 To VRTM_SimVariables.nTrays - 1
                    ClonedState.TrayState(I, J) = New TrayDataSimplified
                    ClonedState.TrayState(I, J) = Me.TrayState(I, J).Clone
                Next
            Next

            Return ClonedState
        End Function
    End Class

    Public Function DefineOrganizationMovementsProdDemandTransition(currentSimulationTimeStep As Long, AvailableTime As Double, CurrentTime As Double) As List(Of Long)
        'This is the main function.
        'It's returning a list of levels (Long) where each level corresponds to a back-and-forth movement [It starts at Elev. B, moves to the first level in the list, Performs a transfer B->A, moves to the next level in the list, performs a transfer A->B, etc.]

        Dim WeekendStrategy As Boolean
        WeekendStrategy = (AvailableTime > (24 * 3600)) 'If there is more than one day available, employ the "weekend strategy"
        WeekendStrategy = WeekendStrategy And VRTM_SimVariables.EnableImprovedWeekendStrat 'But only if it's configured to be enabled


        Dim CurrentState As New VRTMStateSimplified
        Dim I, J, K As Long
        Dim StayTime As Double

        'Fills up the current state
        ReDim CurrentState.TrayState(VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.nLevels - 1)

        For J = 0 To VRTM_SimVariables.nLevels - 1
            For I = 0 To VRTM_SimVariables.nTrays - 1
                CurrentState.TrayState(I, J) = New TrayDataSimplified

                CurrentState.TrayState(I, J).ConveyorIndex = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).ConveyorIndex 'Defines the product index
                StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).TrayIndex)

                If CurrentState.TrayState(I, J).ConveyorIndex = -1 Then
                    'No tray here
                    CurrentState.TrayState(I, J).Frozen = False
                Else
                    CurrentState.TrayState(I, J).Frozen = StayTime >= (VRTM_SimVariables.InletConveyors(CurrentState.TrayState(I, J).ConveyorIndex).MinRetTime * 3600) 'Whether the product will be frozen by the end of the organization
                End If

            Next
        Next
        'Elevator part
        CurrentState.ElevatorState = New TrayDataSimplified
        CurrentState.ElevatorState.ConveyorIndex = Simulation_Results.Elevator(currentSimulationTimeStep - 1).ConveyorIndex
        StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.Elevator(currentSimulationTimeStep - 1).TrayIndex)

        If CurrentState.ElevatorState.ConveyorIndex = -1 Then
            CurrentState.ElevatorState.Frozen = False
        Else
            CurrentState.ElevatorState.Frozen = StayTime >= (VRTM_SimVariables.InletConveyors(CurrentState.ElevatorState.ConveyorIndex).MinRetTime * 3600)
        End If


        CurrentState.EmptyElevatorB = Simulation_Results.EmptyElevatorB(currentSimulationTimeStep - 1)


        'Designs the shelving strategy
        Dim Movements As New List(Of Long)
        Dim StateList As New List(Of VRTMStateSimplified)

        StateList.Add(CurrentState)

        Move_TrimToFrontUnavailable(Movements, StateList, 0.8)

        Return Movements

    End Function

    Public Sub Move_TrimToFrontUnavailable(ByRef Movements As List(Of Long), ByRef StateList As List(Of VRTMStateSimplified), AvailabilityThreshold As Double)
        'This function is a MOVE and will result in a "Trimming" of all the levels that are currently unavailable. Will select only the products that are actually unavailable (i.e. don't have any
        'other level that is available. The availability will be determined if the total number of products with a given conveyor index is larger than a threshold (AvailabilityThreshold, 0 to 1, although <0.5 doesn't make sense).
        'The trimming operation, if deemed viable, will happen as follows:
        'Old state: PPPPPPP000000000000 (P=product, 0=Empty tray)
        'New state: XXXXXXXXXXXXPPPPPPP (X=new product)
        'X will be, by order of priority/availability:
        '1. The closest set of a product that has the same index and is a full level
        '2. The closest set of a different product that has enough of it to push the given product forwards 
        '3. A set of empty trays. These will come from a level full of empty trays, and any product can fill this level up (the closest will be selected)


        'NOTE: THIS FUNCTION ---EXPECTS--- A VRTM STATE THAT HAS ONLY LEVELS SIMILAR TO THE "Old State" shown above and WILL NOT WORK on other conditions!!

        'First lists the availability of each level. Defines availability as the ratio between the "available products" (string of products 
        'right at the end of the tunnel) And the total quantity of this given product in the tunnel 
        Dim I, J, K As Long
        Dim currentState As VRTMStateSimplified = StateList(StateList.Count - 1)

        Dim AvailableProducts() As Long
        Dim ProductCount() As Long
        Dim AvailableProductRatio() As Double
        ReDim AvailableProducts(VRTM_SimVariables.InletConveyors.Count - 1) 'Index per conveyor
        ReDim ProductCount(VRTM_SimVariables.InletConveyors.Count - 1)
        ReDim AvailableProductRatio(VRTM_SimVariables.InletConveyors.Count - 1)
        Dim SizeOfStreak As Long
        Dim ProductIndex As Long
        Dim TotalProducts As Long

        For J = 0 To VRTM_SimVariables.nLevels - 1 'This for loop will determine how much of each product index is available (as a ratio in relation to the total product)
            ProductIndex = currentState.TrayState(VRTM_SimVariables.nTrays - 1, J).ConveyorIndex
            SizeOfStreak = StreakSize(currentState, J)

            If ProductIndex <> -1 Then
                AvailableProducts(ProductIndex) += SizeOfStreak
            End If

            For I = 0 To VRTM_SimVariables.InletConveyors.Count - 1
                TotalProducts = CountThisIndexInThisLevel(currentState, J, I)
                ProductCount(I) += TotalProducts
            Next
        Next

        For I = 0 To VRTM_SimVariables.InletConveyors.Count - 1
            If ProductCount(I) = 0 Then
                AvailableProductRatio(I) = 0
            Else
                AvailableProductRatio(I) = AvailableProducts(I) / ProductCount(I)
            End If
        Next

        'Identifies the empty levels that are workable
        Dim EmptyLevelList As New List(Of Long)
        For I = 0 To VRTM_SimVariables.nLevels - 1
            If IsLevelEmpty(currentState, I) Then EmptyLevelList.Add(I)
        Next

        'For each product that has an AvailableProductRatio < AvailabilityThreshold, it performs the movements according to the logic stated in the function description
        Dim ProductLocatedAtLevels() As Dictionary(Of Long, Long) 'Key=Level, Value=Left Streak Count
        Dim LevelsFullOfThisProduct() As List(Of Long)
        Dim UnavProductConveyorIndices() As Long
        Dim UnavailableProdCount As Long = 0

        Dim MinDistance As Long
        Dim MinDistanceAt As Long
        Dim LeftStreakCount As Long
        Dim Dist As Long
        Dim MaxDist As Long
        Dim Success As Boolean
        For K = 0 To VRTM_SimVariables.InletConveyors.Count - 1
            If AvailableProductRatio(K) < AvailabilityThreshold Then 'Product has been deemed unavailable
                ReDim Preserve ProductLocatedAtLevels(UnavailableProdCount) 'Resizes the arrays
                ReDim Preserve LevelsFullOfThisProduct(UnavailableProdCount)
                ReDim Preserve UnavProductConveyorIndices(UnavailableProdCount)

                UnavProductConveyorIndices(UnavailableProdCount) = K
                'Determines where the product is and how much product is needed to push it forwards
                ProductLocatedAtLevels(UnavailableProdCount) = New Dictionary(Of Long, Long) 'Key=Level, Value=Left Streak Count
                LevelsFullOfThisProduct(UnavailableProdCount) = New List(Of Long)
                For J = 0 To VRTM_SimVariables.nLevels - 1
                    LeftStreakCount = 0
                    For I = 0 To VRTM_SimVariables.nTrays - 1
                        If currentState.TrayState(I, J).ConveyorIndex = K Then
                            'Matched the conveyor, proceeds counting
                            LeftStreakCount += 1
                        Else
                            Exit For
                        End If
                    Next

                    If (LeftStreakCount > 0) And (LeftStreakCount < VRTM_SimVariables.nTrays - 1) Then
                        ProductLocatedAtLevels(UnavailableProdCount).Add(J, LeftStreakCount)
                    ElseIf LeftStreakCount = VRTM_SimVariables.nTrays - 1 Then
                        LevelsFullOfThisProduct(UnavailableProdCount).Add(J)
                    End If
                Next

                UnavailableProdCount += 1
            End If
        Next


        Dim Idx, Idx2 As Long


        For Idx = 0 To UnavProductConveyorIndices.Count - 1
            Dim A As Dictionary(Of Long, Long) = ProductLocatedAtLevels(Idx)

            For Each ProdLevelCount As KeyValuePair(Of Long, Long) In ProductLocatedAtLevels(Idx) 'Key=Level, Value=Left Streak Count
                'Now for each level the product is not organized, determines the methodology to push it forwards.

                'First tries to use a level that is already full of the same product.
                If LevelsFullOfThisProduct(Idx).Count > 0 Then
                    'Elevator movements planned will assume ELEVATOR B HAS AN EMPTY TRAY.
                    'Therefore, they begin with the source level

                    MinDistance = Long.MaxValue
                    For Each L As Long In LevelsFullOfThisProduct(Idx)
                        If (L - ProdLevelCount.Key) < MinDistance Then
                            MinDistance = (L - ProdLevelCount.Key)
                            MinDistanceAt = L
                        End If
                    Next

                    For I = 1 To (VRTM_SimVariables.nTrays - ProdLevelCount.Value)
                        Movements.Add(MinDistanceAt)
                        Movements.Add(ProdLevelCount.Key)
                        StateList.Add(PerformMovement(StateList.Last, MinDistanceAt))
                        StateList.Add(PerformMovement(StateList.Last, ProdLevelCount.Key))
                    Next
                    Continue For
                End If
                'Second tries the closest level that has more product than needed to push this product forwards
                Success = False
                MaxDist = (VRTM_SimVariables.nLevels - ProdLevelCount.Key - 2)
                If ProdLevelCount.Key > MaxDist Then MaxDist = ProdLevelCount.Key
                For Dist = 1 To MaxDist
                    'Tries the level up
                    If ProdLevelCount.Key + Dist < VRTM_SimVariables.nLevels - 1 Then
                        For Idx2 = 0 To UnavProductConveyorIndices.Count - 1
                            'Prevents it from using a tray that has already a scheduled product for modification
                            If currentState.TrayState(0, ProdLevelCount.Key + Dist).ConveyorIndex = UnavProductConveyorIndices(Idx2) Then
                                GoTo NextTray
                            End If
                        Next

                        LeftStreakCount = 0
                        For I = 0 To VRTM_SimVariables.nTrays - 1
                            If currentState.TrayState(I, ProdLevelCount.Key + Dist).ConveyorIndex = currentState.TrayState(0, ProdLevelCount.Key + Dist).ConveyorIndex Then
                                'Matched the conveyor, proceeds counting
                                LeftStreakCount += 1
                            Else
                                Exit For
                            End If
                        Next

                        If LeftStreakCount >= (VRTM_SimVariables.nTrays - ProdLevelCount.Value) And LeftStreakCount < VRTM_SimVariables.nTrays Then
                            If LeftStreakCount = ProdLevelCount.Value Then
                                EmptyLevelList.Add(ProdLevelCount.Key + Dist)
                            End If

                            For I = 1 To (VRTM_SimVariables.nTrays - ProdLevelCount.Value)
                                Movements.Add(ProdLevelCount.Key + Dist)
                                Movements.Add(ProdLevelCount.Key)
                                StateList.Add(PerformMovement(StateList.Last, ProdLevelCount.Key + Dist))
                                StateList.Add(PerformMovement(StateList.Last, ProdLevelCount.Key))
                            Next
                            Success = True
                            Exit For
                        End If
                    End If

NextTray:
                    'Tries the level down

                    If ProdLevelCount.Key - Dist > 0 Then
                        For Idx2 = 0 To UnavProductConveyorIndices.Count - 1
                            'Prevents it from using a tray that has already a scheduled product for modification
                            If currentState.TrayState(0, ProdLevelCount.Key - Dist).ConveyorIndex = UnavProductConveyorIndices(Idx2) Then
                                GoTo NextTray2
                            End If
                        Next

                        LeftStreakCount = 0
                        For I = 0 To VRTM_SimVariables.nTrays - 1
                            If currentState.TrayState(I, ProdLevelCount.Key - Dist).ConveyorIndex = currentState.TrayState(0, ProdLevelCount.Key - Dist).ConveyorIndex Then
                                'Matched the conveyor, proceeds counting
                                LeftStreakCount += 1
                            Else
                                Exit For
                            End If
                        Next
                        If LeftStreakCount >= (VRTM_SimVariables.nTrays - ProdLevelCount.Value) And LeftStreakCount < VRTM_SimVariables.nTrays Then
                            If LeftStreakCount = ProdLevelCount.Value Then
                                EmptyLevelList.Add(ProdLevelCount.Key - Dist)
                            End If

                            For I = 1 To (VRTM_SimVariables.nTrays - ProdLevelCount.Value)
                                Movements.Add(ProdLevelCount.Key - Dist)
                                Movements.Add(ProdLevelCount.Key)
                                StateList.Add(PerformMovement(StateList.Last, ProdLevelCount.Key - Dist))
                                StateList.Add(PerformMovement(StateList.Last, ProdLevelCount.Key))
                            Next
                            Success = True
                            Exit For
                        End If
                    End If
NextTray2:
                Next
                If Success Then Continue For

                'Thirdly, uses an empty tray if none of the other tries worked
                If EmptyLevelList.Count > 0 Then
                    MinDistance = Long.MaxValue
                    For Each L As Long In EmptyLevelList
                        If (L - ProdLevelCount.Key) < MinDistance Then
                            MinDistance = (L - ProdLevelCount.Key)
                            MinDistanceAt = L
                        End If
                    Next

                    For I = 1 To (VRTM_SimVariables.nTrays - ProdLevelCount.Value)
                        Movements.Add(MinDistanceAt)
                        Movements.Add(ProdLevelCount.Key)
                        StateList.Add(PerformMovement(StateList.Last, MinDistanceAt))
                        StateList.Add(PerformMovement(StateList.Last, ProdLevelCount.Key))
                    Next
                    Continue For
                End If

                'If nothing worked, then this level will be left untouched.
            Next
        Next


    End Sub


    Public Function PerformMovement(State As VRTMStateSimplified, Level As Long) As VRTMStateSimplified
        'This function is a MOVEMENT and performs a movement->transfer in the elevator at the given level and returns a new, cloned state
        'Old state: _ AABBCC X      (A,B,C are products, _ is an empty elevator and X is a product in the elevator)
        'New state: A ABBCCX _
        'This will happen at the level informed in the parameters.

        PerformMovement = State.Clone

        If State.EmptyElevatorB Then
            'Performs movement A->>B
            PerformMovement.ElevatorState = State.TrayState(VRTM_SimVariables.nTrays - 1, Level).Clone

            For I = VRTM_SimVariables.nTrays - 2 To 0 Step -1
                PerformMovement.TrayState(I + 1, Level) = State.TrayState(I, Level).Clone
            Next
            PerformMovement.TrayState(0, Level) = State.ElevatorState.Clone

            PerformMovement.EmptyElevatorB = False
        Else
            'Performs movement B->>A
            PerformMovement.ElevatorState = State.TrayState(0, Level).Clone

            For I = 1 To VRTM_SimVariables.nTrays - 1
                PerformMovement.TrayState(I - 1, Level) = State.TrayState(I, Level).Clone
            Next
            PerformMovement.TrayState(VRTM_SimVariables.nTrays - 1, Level) = State.ElevatorState.Clone


            PerformMovement.EmptyElevatorB = True
        End If
    End Function

    Public Function StreakSize(State As VRTMStateSimplified, Level As Long) As Long
        'Returns the size of a "Streak" of products in the given level. 
        'Examples:
        'XXXXXXXAAAAAAA returns 7
        'XXXXXXXAAAABAA returns 2

        StreakSize = 1
        Dim LastProductIndex As Long

        LastProductIndex = State.TrayState(VRTM_SimVariables.nTrays - 1, Level).ConveyorIndex
        For I As Long = VRTM_SimVariables.nTrays - 2 To 0 Step -1
            If LastProductIndex = State.TrayState(I, Level).ConveyorIndex Then
                StreakSize += 1
            Else
                Exit For
            End If
        Next

    End Function

    Public Function CountThisIndexInThisLevel(State As VRTMStateSimplified, Level As Long, index As Long) As Long
        'Returns how many products of this index are in this level.
        'Examples:
        'XXXXXXXAAAAAAA returns 7
        'XXXXXXXAAAABAA returns 6

        CountThisIndexInThisLevel = 0
        For I As Long = 0 To VRTM_SimVariables.nTrays - 1
            If index = State.TrayState(I, Level).ConveyorIndex Then
                CountThisIndexInThisLevel += 1
            End If
        Next
    End Function

    Public Function IsLevelEmpty(State As VRTMStateSimplified, Level As Long) As Boolean
        'Returns whether the level empty
        IsLevelEmpty = True
        For I As Long = 0 To VRTM_SimVariables.nTrays - 1
            IsLevelEmpty = IsLevelEmpty And (State.TrayState(I, Level).ConveyorIndex = -1)
        Next
    End Function



End Module
