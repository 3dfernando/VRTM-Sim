Module ProcessSimulationEngine_Organization
    'TERMINOLOGY DEFINITION:
    'Movement: The basic "atom", it's group of elevator movements that consists of a level translation and a tray transfer.
    'Move: Group of movements, representing a "game move". Examples: "Transfer all frozen trays from one level to another" or "Remove all random frozen trays from one level and put them in many different levels"
    'Operation: Group of moves, represents a complete move set that accomplishes an important task. Examples: "Unscramble all possible frozen products" or "Make available all low-flow products"

#Region "SIMPLIFIED VERSIONS OF CLASSES"
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

#End Region

#Region "MAIN FUNCTION BLOCKS"
    Public Function DefineOrganizationMovements(currentSimulationTimeStep As Integer, AvailableTime As Double, CurrentTime As Double) As List(Of Integer)
        'This is the main function.
        'It's returning a list of levels (Long) where each level corresponds to a back-and-forth movement [It starts at Elev. B, moves to the first level in the list, Performs a transfer B->A, 
        'moves to the next level in the list, performs a transfer A->B, etc.]

        Dim WeekendStrategy As Boolean
        WeekendStrategy = (AvailableTime > (24 * 3600)) 'If there is more than 24 hours available, employ the "weekend strategy"
        WeekendStrategy = WeekendStrategy And VRTM_SimVariables.EnableImprovedWeekendStrat 'But only if it's configured to be enabled

        '-------------NOW THAT THERE ARE MULTIPLE CODES TO SOLVE THIS ISSUE:--------------

        If False Then
            'Previous startegy-driven solution
            Dim currentState As VRTMStateSimplified = GenerateSimplifiedState(currentSimulationTimeStep, CurrentTime)

            'Designs the shelving strategy
            Dim Movements As New List(Of Integer)
            Dim StateList As New List(Of VRTMStateSimplified)

            StateList.Add(currentState)

            Move_GroupAllFrozen(Movements, StateList, 0.1)
            Move_GroupAllFrozen(Movements, StateList, 0.1)
            Return Movements
        End If

        If False Then
            'A* search algorithm
            Dim currentState As FringeItem = ConvertStateForA_Star(currentSimulationTimeStep, CurrentTime, 0.9)

            Return Solve_A_Star_Search(currentState, 300)
        End If

        If True Then
            'Monte Carlo search algorithm
            Dim currentState As MonteCarloState = ConvertStateForMonteCarlo(currentSimulationTimeStep, CurrentTime)

            Return SolveMonteCarloSearch(currentState, 14400, 300)
        End If


    End Function

    Public Function DefineOrganizationMovementsProdDemandTransition(currentSimulationTimeStep As Long, AvailableTime As Double, CurrentTime As Double) As List(Of Integer)
        'This is a secondary function that accomplishes the purpose of enabling product to be available when the transition from the period ruled by "production" (startup) passes and the period ruled by "demand != production" begins.
        'It's returning a list of levels (Long) where each level corresponds to a back-and-forth movement [It starts at Elev. B, moves to the first level in the list, Performs a transfer B->A, moves to the next level in the list, 
        'performs a transfer A->B, etc.]

        Dim currentState As VRTMStateSimplified = GenerateSimplifiedState(currentSimulationTimeStep, CurrentTime)

        'Designs the shelving strategy
        Dim Movements As New List(Of Integer)
        Dim StateList As New List(Of VRTMStateSimplified)

        StateList.Add(currentState)

        Move_TrimToFrontUnavailable(Movements, StateList, 0.5, 0.05)
        Return Movements

    End Function
#End Region



#Region "MOVES"
    Public Sub Move_TrimToFrontUnavailable(ByRef Movements As List(Of Integer), ByRef StateList As List(Of VRTMStateSimplified), AvailabilityThreshold As Double, ProductionRatioThreshold As Double)
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
        Dim currentState As VRTMStateSimplified = StateList.Last

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
        Dim ConveyorIndex As Long


        For Idx = 0 To UnavProductConveyorIndices.Count - 1
            Dim A As Dictionary(Of Long, Long) = ProductLocatedAtLevels(Idx)

            For Each ProdLevelCount As KeyValuePair(Of Long, Long) In ProductLocatedAtLevels(Idx) 'Key=Level, Value=Left Streak Count
                'Now for each level the product is not organized, determines the methodology to push it forwards.

                'Secondly, uses an empty tray if the previous try didnt work
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


                'First tries the closest level that has more product than needed to push this product forwards
                Success = False
                MaxDist = (VRTM_SimVariables.nLevels - ProdLevelCount.Key - 2)
                If ProdLevelCount.Key > MaxDist Then MaxDist = ProdLevelCount.Key
                For Dist = 1 To MaxDist
                    'Tries the level up
                    If (ProdLevelCount.Key + Dist < VRTM_SimVariables.nLevels - 1) Then 'Prevents it from trying a level out of bounds 
                        ConveyorIndex = currentState.TrayState(0, ProdLevelCount.Key + Dist).ConveyorIndex
                        If ConveyorIndex > -1 AndAlso (ConveyorProductionRatios(ConveyorIndex) > ProductionRatioThreshold) Then 'Prevents it to move a conveyor that has an index that is not produced much
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
                    End If

NextTray:
                    'Tries the level down
                    If ProdLevelCount.Key - Dist > 0 Then 'Prevents it from trying a level out of bounds 
                        ConveyorIndex = currentState.TrayState(0, ProdLevelCount.Key - Dist).ConveyorIndex
                        If ConveyorIndex > -1 AndAlso (ConveyorProductionRatios(ConveyorIndex) > ProductionRatioThreshold) Then 'Prevents it to move a conveyor that has an index that is not produced much

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
                    End If
NextTray2:
                Next
                If Success Then Continue For

                'If nothing worked, then this level will be left untouched.
            Next
        Next


    End Sub

    Public Sub Move_GroupAllFrozen(ByRef Movements As List(Of Integer), ByRef StateList As List(Of VRTMStateSimplified), ByVal CostToBenefitThreshold As Double)
        'This MOVE will group all products that WILL BE frozen by the time the new day dawns again. 

        Dim currentState As VRTMStateSimplified = StateList.Last
        Dim I, J, K As Long

        'Counts the open levels
        Dim OpenLevelCount As Long
        Dim OpenLevels() As Long
        ReDim OpenLevels(0)
        Dim OpenLevelAssignments() As Long
        ReDim OpenLevelAssignments(0)
        OpenLevelCount = 0
        For I = 0 To VRTM_SimVariables.nLevels - 1
            If I <> VRTM_SimVariables.EmptyLevel - 1 Then
                If Not IsLevelFullOfTheSameProduct(currentState, I) AndAlso (Not I = VRTM_SimVariables.ReturnLevel - 1) Then
                    ReDim Preserve OpenLevels(OpenLevelCount)
                    ReDim Preserve OpenLevelAssignments(OpenLevelCount)
                    OpenLevels(OpenLevelCount) = I
                    OpenLevelAssignments(OpenLevelCount) = -2 'Empty variable
                    OpenLevelCount = OpenLevelCount + 1
                End If
            End If
        Next I
        OpenLevelCount -= 1 'Corrects to the right number of levels

        If OpenLevelCount < VRTM_SimVariables.InletConveyors.Count + 1 Then 'We need at least as many levels as there are conveyor indices PLUS one level for the movements.
            Exit Sub 'Insufficient open levels
        End If


        'Now assigns levels according to the streak size (prefers the longest streak)
        Dim LongestStreak As Long
        Dim LongestStreakPosition As Long
        Dim SCount As Long
        Dim OrphanProducts() As Long 'An orphan product is one that has only one at the end of the streak (it's available but there is only one, like in this example: XXXXXXXXXXP)
        ReDim OrphanProducts(0)
        Dim OrphanProdCount As Long

        OrphanProdCount = 0
        For K = 0 To VRTM_SimVariables.InletConveyors.Count - 1
            LongestStreak = 0
            For I = 0 To OpenLevelCount - 1
                If currentState.TrayState(VRTM_SimVariables.nTrays - 1, OpenLevels(I)).Frozen And currentState.TrayState(VRTM_SimVariables.nTrays - 1, OpenLevels(I)).ConveyorIndex = K Then
                    SCount = StreakSize(currentState, OpenLevels(I))
                    If LongestStreak < SCount Then
                        LongestStreak = SCount
                        LongestStreakPosition = I
                    End If
                End If
            Next I

            If LongestStreak <= 1 Then
                ReDim Preserve OrphanProducts(OrphanProdCount)
                OrphanProducts(OrphanProdCount) = K
                OrphanProdCount = OrphanProdCount + 1
            Else
                OpenLevelAssignments(LongestStreakPosition) = K
            End If
        Next K

        'Includes also an empty tray level assignment
        ReDim Preserve OpenLevels(OpenLevelCount)
        ReDim Preserve OpenLevelAssignments(OpenLevelCount)
        OpenLevels(OpenLevelCount) = VRTM_SimVariables.EmptyLevel - 1
        OpenLevelAssignments(OpenLevelCount) = -1 'Empty tray
        OpenLevelCount = OpenLevelCount + 1

        'The orphan products (They don't appear in the last tray in the current config) need to be assigned, and that will happen in the order of remaining open levels.
        For J = 0 To OrphanProdCount - 1
            For I = 0 To OpenLevelCount - 1
                If OpenLevelAssignments(I) = -2 Then
                    OpenLevelAssignments(I) = OrphanProducts(J)
                    Exit For
                End If
            Next I
        Next J


        'Now all the assignments have been made, loops through all the Temporary Levels until it needs to shut it down
        Dim TemporaryLevels() As Long
        Dim TemporaryLevelCostToBenefit() As Double
        ReDim TemporaryLevels(0)
        ReDim TemporaryLevelCostToBenefit(0)
        Dim TemporaryLevelCount As Long
        Dim Frozen As Long
        TemporaryLevelCount = -1

        For I = 0 To OpenLevelCount - 1 'Selects which levels will be deemed as temporary
            If OpenLevelAssignments(I) = -2 Then
                TemporaryLevelCount = TemporaryLevelCount + 1
                ReDim Preserve TemporaryLevels(TemporaryLevelCount)
                ReDim Preserve TemporaryLevelCostToBenefit(TemporaryLevelCount)
                TemporaryLevels(TemporaryLevelCount) = OpenLevels(I)

                For J = 0 To VRTM_SimVariables.nTrays - 1
                    If currentState.TrayState(J, OpenLevels(I)).Frozen Then
                        Exit For
                    End If
                Next J
                TemporaryLevelCostToBenefit(TemporaryLevelCount) = (VRTM_SimVariables.nTrays - J + 1)

                Frozen = 0
                For J = 0 To VRTM_SimVariables.nTrays - 1
                    If currentState.TrayState(J, OpenLevels(I)).Frozen Then
                        Frozen += 1
                    End If
                Next J
                If Not TemporaryLevelCostToBenefit(TemporaryLevelCount) = 0 Then TemporaryLevelCostToBenefit(TemporaryLevelCount) = Frozen / TemporaryLevelCostToBenefit(TemporaryLevelCount)
            End If
        Next I
        TemporaryLevelCount += 1 'Corrects to the current count

        'Orders the temporary levels according to cost to benefit
        Dim OrderedCost() As Double
        ReDim OrderedCost(TemporaryLevelCount)
        For J = 0 To TemporaryLevelCount - 1
            OrderedCost(J) = TemporaryLevelCostToBenefit(J)
        Next J

        'Bubble sort
        Dim Tmp As Double
        For J = 0 To TemporaryLevelCount - 2
            For I = 0 To TemporaryLevelCount - 2
                If TemporaryLevelCostToBenefit(I + 1) > TemporaryLevelCostToBenefit(I) Then 'Descending order
                    Tmp = TemporaryLevels(I + 1)
                    TemporaryLevels(I + 1) = TemporaryLevels(I)
                    TemporaryLevels(I) = Tmp

                    Tmp = OrderedCost(I + 1)
                    OrderedCost(I + 1) = OrderedCost(I)
                    OrderedCost(I) = Tmp
                End If
            Next I
            For I = 0 To TemporaryLevelCount - 1
                TemporaryLevelCostToBenefit(I) = OrderedCost(I)
            Next I
        Next J

        'Do the actual shelving

        Dim CurrentProduct As TrayDataSimplified
        Dim LevelFullOfUnfrozenProd As Boolean
        Dim LoopCount As Long

        'Before anything makes sure that the elevator B is empty
        If StateList.Last.EmptyElevatorB = False Then
            Movements.Add(VRTM_SimVariables.ReturnLevel - 1)
            StateList.Add(PerformMovement(StateList.Last, VRTM_SimVariables.ReturnLevel - 1))
        End If

        For K = 0 To TemporaryLevelCount - 1
            If OrderedCost(K) > CostToBenefitThreshold Then
                LoopCount = 0
                Do While 1
                    'Empties this level as much as it is possible while organizing the other levels
                    'This loop will have to stop when some of the levels fills up, then we'll have to commit the current "temporary level" with the new product.

                    'Select the next level
                    CurrentProduct = StateList.Last.TrayState(VRTM_SimVariables.nTrays - 1, TemporaryLevels(K))

                    If CurrentProduct.ConveyorIndex = -1 Then
                        Dim ostragildo As String = ""

                    End If
                    For I = 0 To OpenLevelCount - 1
                        If Not CurrentProduct.Frozen Then
                            If CurrentProduct.ConveyorIndex = -1 And OpenLevelAssignments(I) = -1 Then
                                'Performs the transfer
                                Movements.Add(TemporaryLevels(K))
                                Movements.Add(OpenLevels(I))
                                StateList.Add(PerformMovement(StateList.Last, TemporaryLevels(K)))
                                StateList.Add(PerformMovement(StateList.Last, OpenLevels(I)))
                                Exit For
                            ElseIf OpenLevelAssignments(I) = -2 Then
                                'Performs the transfer
                                Movements.Add(TemporaryLevels(K))
                                Movements.Add(OpenLevels(I))
                                StateList.Add(PerformMovement(StateList.Last, TemporaryLevels(K)))
                                StateList.Add(PerformMovement(StateList.Last, OpenLevels(I)))
                                Exit For
                            End If
                        Else
                            If OpenLevelAssignments(I) = CurrentProduct.ConveyorIndex Then
                                'Performs the transfer
                                Movements.Add(TemporaryLevels(K))
                                Movements.Add(OpenLevels(I))
                                StateList.Add(PerformMovement(StateList.Last, TemporaryLevels(K)))
                                StateList.Add(PerformMovement(StateList.Last, OpenLevels(I)))
                                Exit For
                            End If
                        End If
                    Next I
                    'If the target level fills up, it's time to go to the next temporary level...
                    If CurrentProduct.Frozen = False Then
                        'For unfrozen products the isLevelFull function won't work, so customizes it here:
                        LevelFullOfUnfrozenProd = True
                        For J = 0 To VRTM_SimVariables.nTrays - 1
                            If StateList.Last.TrayState(J, OpenLevels(I)).Frozen Then
                                LevelFullOfUnfrozenProd = False
                                Exit For
                            End If
                        Next J

                        If LevelFullOfUnfrozenProd Then
                            OpenLevels(I) = TemporaryLevels(K)
                            Exit Do
                        End If
                    Else
                        If IsLevelFullOfTheSameProduct(StateList.Last, OpenLevels(I)) Then
                            OpenLevels(I) = TemporaryLevels(K)
                            Exit Do
                        End If
                    End If

                    If LoopCount > 100 Then
                        Exit Do
                    End If
                    LoopCount += 1
                Loop
            End If
        Next K



    End Sub

#End Region

#Region "MOVEMENTS"
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
#End Region





#Region "AUXILIARY FUNCTIONS"
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

    Public Function IsLevelFullOfTheSameProduct(State As VRTMStateSimplified, Level As Long) As Boolean
        'Returns whether the level is full of the same product
        For I As Long = 0 To VRTM_SimVariables.nTrays - 1
            If State.TrayState(I, Level).ConveyorIndex <> State.TrayState(0, Level).ConveyorIndex Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function GenerateSimplifiedState(currentSimulationTimeStep As Long, CurrentTime As Double) As VRTMStateSimplified
        'This will return a simplified version of the current time step
        Dim CurrentState As New VRTMStateSimplified
        Dim I, J As Long
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

        Return CurrentState
    End Function
#End Region



End Module
