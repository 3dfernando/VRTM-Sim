﻿Public Module MonteCarlo
    'This module contains an implementation of the MonteCarlo Tree search algorithm.
    'It uses the concept of budgetting to define the Monte Carlo Simulation Step end (after a defined amount of hours, in this case, stop the simulation and return whatever result)

    Public Const NumberOfStartupSimulations As Long = 2 'This will set the simulations performed each expansion
    Public TimeBudgetSimulation_s As Double
    Dim TunnelState As MonteCarloState
    'Dim RootNode As MonteCarloNode


    Public Function SolveGeneticSearch(CurrentState As MonteCarloState, TimeBudgetForTunnel_s As Double, TimeBudgetMonteCarlo_s As Double) As List(Of Integer)
        'Applies a genetic algorithm to solve the current state

        Dim CurrentTimer As New Stopwatch

        CurrentTimer.Start() 'This will allow the MonteCarlo to keep track of its own execution time and exit accordingly

        TimeBudgetSimulation_s = TimeBudgetForTunnel_s 'Makes it public
        TunnelState = CurrentState
        'Don't erase over here

        'Parameterize the genetic search
        Dim nActions As Integer = 1000
        Dim nGenerations As Integer = 1000
        Dim maxMutations As Integer = 100 'Max number of genes to be mutated each reproduction step
        Dim nReproductions As Integer = 5 'Number of Offspring each generation
        Dim nSelections As Integer = 100 'Number of selected creatures each generation

        Dim PopulationSize As Integer = (nReproductions + 1) * nSelections 'Number of creatures in the population is fixed: (parent + children)*(number of parents)


        'Genetic search variables
        Dim CurrentPopulation As New List(Of List(Of Integer))
        Dim ListOfActions As New List(Of Integer)
        Dim BestOfGeneration As New List(Of Double)


        'Initializes random genes
        Dim r As New System.Random
        For I As Integer = 1 To PopulationSize
            ListOfActions = New List(Of Integer)
            For A As Integer = 0 To nActions - 1
                'Begins with a random list of movements
                ListOfActions.Add(r.Next(0, VRTM_SimVariables.nLevels - 1))
            Next
            CurrentPopulation.Add(New List(Of Integer)(ListOfActions))
        Next


        'Adds the generation 0 to the best score list
        BestOfGeneration.Add(TunnelState.AccessibleFraction)

        'Performs the evolution (Selection -> Mutation)
        For Gen As Integer = 1 To nGenerations
            '==============================SELECTION STEP==============================

            Dim D As New List(Of KeyValuePair(Of Integer, Double)) 'Implements a dictionary of AvailableFractions. Key=Index in the population list, Value=Available Fraction
            For I As Integer = 0 To CurrentPopulation.Count - 1
                Dim State As MonteCarloState = TunnelState.Clone
                State.PerformBatchOperation(CurrentPopulation(I))
                D.Add(New KeyValuePair(Of Integer, Double)(I, State.AvailableFraction))
            Next

            D.Sort(Function(x, y) y.Value.CompareTo(x.Value))
            BestOfGeneration.Add(D.First.Value)

            Dim SelectedPopulation As New List(Of List(Of Integer))

            'If that's the last generation, doesn't perform the next step
            If Gen = nGenerations Then
                ListOfActions = CurrentPopulation(D(0).Key)

                'After all has already been done, trims the list
                ListOfActions = TrimListOfOperations(ListOfActions)
                ListOfActions = TrimListOfOperations(ListOfActions)
                Exit For
            End If

            For I As Integer = 0 To nSelections - 1
                'Selects the ones to keep
                SelectedPopulation.Add(CurrentPopulation(D(I).Key))
            Next
            CurrentPopulation = New List(Of List(Of Integer))(SelectedPopulation)


            '==============================REPRODUCTION/MUTATION STEP==============================
            For I As Integer = 0 To nSelections - 1
                'Gets each parent and reproduces it with at most nMutations random mutations

                For J As Integer = 1 To nReproductions
                    Dim ChildCreature As New List(Of Integer)(CurrentPopulation(I))
                    'Mutates this creature
                    Dim rn As New System.Random()
                    Dim N As Integer = rn.Next(1, maxMutations)
                    Dim G As Integer
                    For M As Integer = 1 To N
                        G = rn.Next(0, nActions - 1) 'Selects a new gen to change
                        ChildCreature(G) = rn.Next(0, VRTM_SimVariables.nLevels - 1)
                    Next

                    CurrentPopulation.Add(ChildCreature) 'Now this creature is part of the new generation's population
                Next
            Next

        Next


        CurrentTimer.Stop()

        Dim TestState As MonteCarloState = CurrentState.Clone
        TestState.PerformBatchOperation(ListOfActions)
        If TestState.AccessibleFraction > BestOfGeneration.First Then
            'It's a better solution
            Dim OperationTime As Double = ComputeTimeForOperations(ListOfActions)
            Return ListOfActions
        Else
            'It's not a better solution than doing nothing
            Return New List(Of Integer)
        End If

        Return CurrentPopulation(0)



    End Function


    Public Function SolveMonteCarloSearch(CurrentState As MonteCarloState, TimeBudgetForTunnel_s As Double, TimeBudgetMonteCarlo_s As Double) As List(Of Integer)

        Dim CurrentTimer As New Stopwatch
        Dim r As New System.Random
        Dim CompleteListOfMovements As New List(Of Integer)

        CurrentTimer.Start() 'This will allow the MonteCarlo to keep track of its own execution time and exit accordingly

        TimeBudgetSimulation_s = TimeBudgetForTunnel_s 'Makes it public
        TunnelState = CurrentState.Clone
        Dim TunnelArrayCSV As String = ArrayToCSVString(TunnelState.VRTMStateConv)

        If CurrentState.Elevator1 = -2 Then
            'Transfer it back just to make sure. Also, this product is probably unfrozen, which increases the freedom of the solver
            CurrentState.Perform_Operation(CurrentState.CurrentLevel)
            CompleteListOfMovements.Add(CurrentState.CurrentLevel)
        End If

        Dim LastLevelPair As PossibleLevelPair 'To prevent looping back and forth between the same level pair
        For Iterations As Integer = 1 To 1000
            'Iterates through random level pairs and performs the merging operations as it goes.

            'First updates the list of available levels
            CurrentState.ComputeSimplifiedState()
            Dim UnlockedLevels As New List(Of Integer)(CurrentState.ListOfUnlockedLevels)


            'Evaluates all the possible level pair combinations from here
            Dim PossibleCombinations As New List(Of PossibleLevelPair)

            For F As Integer = 0 To UnlockedLevels.Count - 1
                Dim FirstLevel As Integer = UnlockedLevels(F)
                For L As Integer = 0 To UnlockedLevels.Count - 1
                    Dim LastLevel As Integer = UnlockedLevels(L)

                    If Not FirstLevel = LastLevel Then
                        If Not ((CurrentState.SimplifiedState(FirstLevel).Count = 1 AndAlso CurrentState.SimplifiedState(FirstLevel).First.ItemCode = 0) AndAlso
                                (CurrentState.SimplifiedState(LastLevel).Count = 1 AndAlso CurrentState.SimplifiedState(LastLevel).First.ItemCode = 0)) Then 'Checks for empty level pair (won't select an empty level pair)
                            If CurrentState.IsLevelPairMergeable(FirstLevel, LastLevel) Then
                                'This level pair is actually mergeable, so proceeds
                                Dim AvailableFractionResult As Double
                                If CurrentState.DoesItMakeSenseToPerformThisOperation(FirstLevel, LastLevel, AvailableFractionResult) Then
                                    'It's an operation that will actually change the state of the tunnel

                                    Dim PLP As New PossibleLevelPair
                                    PLP.Level1 = FirstLevel
                                    PLP.Level2 = LastLevel
                                    PLP.AvailableFraction = AvailableFractionResult
                                    PLP.TimeCost = Compute_Elevator_Time(FirstLevel, LastLevel)
                                    PLP.MovementPairs = CurrentState.ComputeNumberOfMovementPairs(FirstLevel, LastLevel)

                                    PossibleCombinations.Add(PLP)
                                End If
                            End If
                        End If
                    End If
                Next
            Next

            'Picks the best availablefraction from the possible combinations and performs it
            If PossibleCombinations.Count <> 0 Then
                PossibleCombinations.Sort()
                PossibleCombinations.Reverse() 'Just for debug - can be suppressed and changed for .last in the code below

                If (Not IsNothing(LastLevelPair)) AndAlso LastLevelPair.Level1 = PossibleCombinations.First.Level2 AndAlso LastLevelPair.Level2 = PossibleCombinations.First.Level1 Then
                    'It's going to loop through the same pair of levels, abort and use the next best one
                    PossibleCombinations.RemoveAt(0)
                End If

                Dim MovList As New List(Of Integer)

                For I As Integer = 1 To PossibleCombinations.First.MovementPairs
                    MovList.Add(PossibleCombinations.First.Level1)
                    MovList.Add(PossibleCombinations.First.Level2)
                Next
                CurrentState.PerformBatchOperation(MovList)

                CompleteListOfMovements.AddRange(MovList)
                LastLevelPair = PossibleCombinations.First
            Else
                Exit For
            End If

            Dim T As Double = ComputeTimeForOperations(CompleteListOfMovements)
            If T > TimeBudgetForTunnel_s Then
                Exit For
            End If
        Next

        CurrentTimer.Stop()
        Dim OperationTime As Double = ComputeTimeForOperations(CompleteListOfMovements) / 3600


        Return CompleteListOfMovements


    End Function


    Public Class MonteCarloState
        Implements IComparable(Of MonteCarloState)
        Public VRTMStateConv(,) As Integer 'VRTM internal state with conveyor indices (Tray no, Level no) ***A conveyor index that is larger than 1000 is the same as (index-1000), but ready to ship and needs to be on the side of elevator 2 in the goal.
        Public Elevator1 As Integer 'Content of the elevator 1 (-1 means an empty tray, -2 means no tray on it)
        Public Elevator2 As Integer 'Content of the elevator 2 (-1 means an empty tray, -2 means no tray on it)
        Public CurrentLevel As Integer 'Current level the elevator is at
        Public SKUCount As Integer 'Number of unique SKUs to treat here
        Public AvailableFraction As Double 'Number of available frozen products/total frozen products 
        Public SimplifiedState As List(Of List(Of SimplifiedLevelInfo))

        Public Function Compare(compareState As MonteCarloState) As Integer _
            Implements IComparable(Of MonteCarloState).CompareTo
            ' A null value means that this object is greater.
            If compareState Is Nothing Then
                Return 1
            Else
                Return AvailableFraction.CompareTo(compareState.AvailableFraction)
            End If
        End Function

        Public Function Clone() As MonteCarloState
            'Clones myself
            Dim NewMe As New MonteCarloState
            NewMe.VRTMStateConv = Me.VRTMStateConv.Clone
            NewMe.Elevator1 = Me.Elevator1
            NewMe.Elevator2 = Me.Elevator2
            NewMe.CurrentLevel = Me.CurrentLevel
            NewMe.SKUCount = Me.SKUCount
            NewMe.SimplifiedState = New List(Of List(Of SimplifiedLevelInfo))(Me.SimplifiedState)

            Return NewMe
        End Function

        Public Sub Perform_Operation(Operation As Integer)
            'Performs an operation of moving and swapping according to the operation. 
            'The operation is the number of the level that the elevator will move to and perform the swap
            If Me.Elevator1 = -2 Xor Me.Elevator2 = -2 Then
                'Only one elevator can be empty


                'Performs the operation here
                If Me.Elevator1 = -2 Then
                    Me.Elevator1 = Me.VRTMStateConv(0, Operation)
                    For I As Long = 0 To UBound(Me.VRTMStateConv, 1) - 1
                        Me.VRTMStateConv(I, Operation) = Me.VRTMStateConv(I + 1, Operation)
                    Next
                    Me.VRTMStateConv(UBound(Me.VRTMStateConv, 1), Operation) = Me.Elevator2
                    Me.Elevator2 = -2
                ElseIf Me.Elevator2 = -2 Then
                    Me.Elevator2 = Me.VRTMStateConv(UBound(Me.VRTMStateConv, 1), Operation)
                    For I As Long = UBound(Me.VRTMStateConv, 1) - 1 To 0 Step -1
                        Me.VRTMStateConv(I + 1, Operation) = Me.VRTMStateConv(I, Operation)
                    Next
                    Me.VRTMStateConv(0, Operation) = Me.Elevator1
                    Me.Elevator1 = -2
                End If

                Me.CurrentLevel = Operation
            Else
                'Invalid
            End If
        End Sub

        Public Function AccessibleFraction() As Double
            'Returns the global fraction available/frozen
            Dim AvailableProducts As Integer = 0
            Dim TotalFrozen As Integer = 0

            For J As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                'Looks at each level
                AvailableProducts += AvailableProductCount(J, -1)
                TotalFrozen += FrozenProductCount(J, -1)
            Next

            If TotalFrozen = 0 Then Return 1
            Return (AvailableProducts / TotalFrozen)
        End Function

        Public Function AvailableProductCount(Level As Integer, SKU As Integer) As Integer
            'Returns for the current level the number of available frozen product
            Dim AvailableProduct As Integer = 0
            Dim LastProduct As Integer = VRTMStateConv(UBound(Me.VRTMStateConv, 1), Level)


            If LastProduct > 1000 Then
                'There is at least one frozen product at the end of the line
                If (VRTMStateConv(UBound(Me.VRTMStateConv, 1), Level) = SKU + 1000) Or SKU = -1 Then
                    AvailableProduct = 1
                End If

                For I As Integer = UBound(Me.VRTMStateConv, 1) - 1 To 0 Step -1
                    If VRTMStateConv(I, Level) = LastProduct Then
                        If (VRTMStateConv(I, Level) = SKU + 1000) Or SKU = -1 Then
                            'There is a streak of products of this SKU
                            AvailableProduct += 1
                        End If
                    Else
                        Exit For
                    End If
                Next
            Else
                'No available frozen product.
                Return 0
            End If

            Return AvailableProduct
        End Function

        Public Function FrozenProductCount(Level As Integer, SKU As Integer) As Integer
            'Returns for the current level the number of frozen product
            Dim FrozenProduct As Integer = 0

            For I As Integer = UBound(Me.VRTMStateConv, 1) To 0 Step -1
                If VRTMStateConv(I, Level) > 1000 Then
                    If (VRTMStateConv(I, Level) = SKU + 1000) Or SKU = -1 Then
                        'Another frozen product
                        FrozenProduct += 1
                    End If
                End If
            Next

            Return FrozenProduct
        End Function

        Public Sub PerformBatchOperation(OperationList As List(Of Integer))
            'This will recur operations for multiple operations
            'Will update the VRTMStateConv array and the elevator states.
            'This operation takes roughly 115us/1000 random operations in a 42x10 TRVM.

            If Not (Me.Elevator1 = -2 Xor Me.Elevator2 = -2) Then
                'Only one elevator can be empty
                Exit Sub
            End If

            Dim ElevatorEndPosition As Integer
            Dim IsElevatorOnSide1 As Boolean
            Dim FloatingProduct As Integer
            If OperationList.Count Mod 2 = 0 Then
                'Even number of operations, elevator position stays as is
                If Elevator1 = -2 Then
                    ElevatorEndPosition = 2
                    IsElevatorOnSide1 = False
                    FloatingProduct = Me.Elevator2
                Else
                    ElevatorEndPosition = 1
                    IsElevatorOnSide1 = True
                    FloatingProduct = Me.Elevator1
                End If
            Else
                'Odd number of operations, elevator position changes
                If Elevator1 = -2 Then
                    ElevatorEndPosition = 1
                    IsElevatorOnSide1 = False
                    FloatingProduct = Me.Elevator2
                Else
                    ElevatorEndPosition = 2
                    IsElevatorOnSide1 = True
                    FloatingProduct = Me.Elevator1
                End If
            End If

            'Performs the transfer operations
            Dim TempFloatingProduct As Integer
            For Each I As Integer In OperationList
                If IsElevatorOnSide1 Then
                    TempFloatingProduct = VRTMStateConv(VRTM_SimVariables.nTrays - 1, I)
                    For J As Integer = VRTM_SimVariables.nTrays - 1 To 1 Step -1
                        VRTMStateConv(J, I) = VRTMStateConv(J - 1, I)
                    Next
                    VRTMStateConv(0, I) = FloatingProduct
                    FloatingProduct = TempFloatingProduct
                Else
                    TempFloatingProduct = VRTMStateConv(0, I)
                    For J As Integer = 0 To VRTM_SimVariables.nTrays - 2
                        VRTMStateConv(J, I) = VRTMStateConv(J + 1, I)
                    Next
                    VRTMStateConv(VRTM_SimVariables.nTrays - 1, I) = FloatingProduct
                    FloatingProduct = TempFloatingProduct
                End If
                IsElevatorOnSide1 = Not IsElevatorOnSide1
            Next

            'Fills the elevator position again
            If ElevatorEndPosition = 1 Then
                Me.Elevator1 = FloatingProduct
                Me.Elevator2 = -2
            Else
                Me.Elevator1 = -2
                Me.Elevator2 = FloatingProduct
            End If

            Me.AvailableFraction = Me.AccessibleFraction 'Updates the available fraction
        End Sub

        Public Sub ComputeSimplifiedState()
            'Transforms the current VRTMStateConf into a list of lists.
            'Parent list represents the levels of the tunnel
            'Internal list represents the level simplified view (just a collection of items chunks)
            Me.SimplifiedState = New List(Of List(Of SimplifiedLevelInfo))
            For L = 0 To VRTM_SimVariables.nLevels - 1
                Me.SimplifiedState.Add(SimplifyLevel(L))
            Next
        End Sub

        Public Function SimplifyLevel(Level As Integer) As List(Of SimplifiedLevelInfo)
            'Transforms the current VRTMStateConf into a list of lists.
            'First list represents the levels of the tunnel
            'Second list represents the level simplified view (just a collection of items chunks)
            'ItemCode=0 represents an unfrozen product (regardless of code)
            Dim NewLevel As New List(Of SimplifiedLevelInfo)
            Dim LastProduct As Integer

            LastProduct = VRTMStateConv(0, Level)
            Dim nProducts As Integer = 1

            For I = 1 To VRTM_SimVariables.nTrays - 1

                If LastProduct = VRTMStateConv(I, Level) Then
                    nProducts += 1
                ElseIf (LastProduct < 1000 AndAlso LastProduct > -1) AndAlso (VRTMStateConv(I, Level) < 1000 AndAlso VRTMStateConv(I, Level) > -1) Then
                    nProducts += 1
                Else
                    'Streak ended
                    Dim Info As New SimplifiedLevelInfo
                    If (LastProduct < 1000 AndAlso LastProduct > -1) Then
                        Info.ItemCode = 0
                    Else
                        Info.ItemCode = LastProduct
                    End If
                    Info.NumberOfItems = nProducts
                    NewLevel.Add(Info)
                    nProducts = 1
                    LastProduct = VRTMStateConv(I, Level)
                End If
            Next

            Dim Info2 As New SimplifiedLevelInfo
            If (LastProduct < 1000 AndAlso LastProduct > -1) Then
                Info2.ItemCode = 0
            Else
                Info2.ItemCode = LastProduct
            End If
            Info2.NumberOfItems = nProducts
            NewLevel.Add(Info2)

            SimplifyLevel = NewLevel

        End Function

        Public Function IsLevelPairMergeable(Level1 As Integer, Level2 As Integer) As Boolean
            'Validates whether this pair of levels (Level 1 and 2) is mergeable using the rules below.
            Dim F1 As Integer = Me.SimplifiedState(Level1).First.ItemCode
            Dim F2 As Integer = Me.SimplifiedState(Level2).First.ItemCode
            Dim L1 As Integer = Me.SimplifiedState(Level1).Last.ItemCode
            Dim L2 As Integer = Me.SimplifiedState(Level2).Last.ItemCode

            Dim Merge_Elevator_Side As Boolean
            Dim Merge_Elevator_Opp_Side As Boolean

            Dim E1 As Integer
            Dim E2 As Integer
            SimplifyElevator(E1, E2)

            If E1 = -2 Then
                'Empty elevator 1. Elevator with product on the right side. 
                Merge_Elevator_Opp_Side = (F1 = F2) 'Only merges the opposite side if either are unfrozen or either are the same product (doesn't allow for mixing in the left side)
                If L2 = 0 And Me.SimplifiedState(Level1).Count = 1 And Me.SimplifiedState(Level1).First.ItemCode = 0 Then
                    'One exception is if there is this combination (XYZ=frozen, U=unfrozen):
                    'Level2=XYZUUUUUUUU
                    'Level1=UUUUUUUUUUU
                    'or Level2=UUUUXYZUU
                    Merge_Elevator_Opp_Side = True
                End If

                If L1 = 0 Then
                    'Receiving level from elevator is unfrozen, so it can receive anything given the elevator contains the same product as the giving level
                    Merge_Elevator_Side = (E2 = L2)
                Else
                    'Receiving level from elevator is frozen
                    Merge_Elevator_Side = (E2 = L2) And (E2 = L1) 'If it is frozen will only merge when all products are the same.
                End If
            ElseIf E2 = -2 Then
                'Empty elevator 2. Elevator with product on the left side. 

                'Merge_Elevator_Side = (F1 = F2) And (E1 = F1) 'Left hand side cannot be mixed, so will only perform an operation if all levels contain either unfrozen product or the same frozen product
                'If L1 = 0 And Me.SimplifiedState(Level2).Count = 1 And Me.SimplifiedState(Level2).First.ItemCode = 0 Then
                '    'One exception is if there is this combination (XYZ=frozen, U=unfrozen):
                '    'Level1=XYZUUUUUUUU
                '    'Level2=UUUUUUUUUUU
                '    'or Level1=UUUUXYZUU
                '    Merge_Elevator_Side = True
                'End If

                Merge_Elevator_Side = True 'remove me (or maybe not, because this actually works!)

                If L2 = 0 Then
                    'Receiving level from the opposite side is unfrozen, so it can receive anything given the elevator contains the same product as the giving level
                    Merge_Elevator_Opp_Side = True
                Else
                    'Receiving level from elevator is frozen
                    Merge_Elevator_Opp_Side = (L1 = L2) 'If it is frozen will only merge when both products are the same.
                End If
            End If



            IsLevelPairMergeable = Merge_Elevator_Side And Merge_Elevator_Opp_Side

            If IsLevelPairMergeable = False Then 'For debug
                Dim A As Boolean = False
            End If
        End Function

        Public Function DoesItMakeSenseToPerformThisOperation(Level1 As Integer, Level2 As Integer, ByRef AvailableFractionResult As Double) As Boolean
            'Checks whether this operations is something inocuous that accomplishes nothing

            'First pretends to perform this operation as a mock:

            Dim E1 As Integer
            Dim E2 As Integer
            SimplifyElevator(E1, E2)

            Dim MovPairs As Integer = ComputeNumberOfMovementPairs(Level1, Level2)
            Dim MockTunnel As MonteCarloState = Me.Clone
            Dim MovList As New List(Of Integer)

            For I As Integer = 1 To MovPairs
                MovList.Add(Level1)
                MovList.Add(Level2)
            Next
            MockTunnel.PerformBatchOperation(MovList)
            MockTunnel.ComputeSimplifiedState()

            Dim ME1 As Integer
            Dim ME2 As Integer
            SimplifyElevator(ME1, ME2)

            'Compares the mocktunnel state with the current tunnel state
            Dim DoesItMakeSense As Boolean
            If MockTunnel.SimplifiedState(Level1).Count = Me.SimplifiedState(Level2).Count Then
                If MockTunnel.SimplifiedState(Level2).Count = Me.SimplifiedState(Level1).Count Then 'Compares the tunnels simplified states at the current levels
                    For I = 0 To MockTunnel.SimplifiedState(Level1).Count - 1
                        If Not MockTunnel.SimplifiedState(Level1)(I) = Me.SimplifiedState(Level2)(I) Then
                            DoesItMakeSense = True 'Maybe something has changed!
                        End If
                    Next
                    For I = 0 To MockTunnel.SimplifiedState(Level2).Count - 1
                        If Not MockTunnel.SimplifiedState(Level2)(I) = Me.SimplifiedState(Level1)(I) Then
                            DoesItMakeSense = True 'Maybe something has changed!
                        End If
                    Next
                    If E1 = ME1 AndAlso E2 = ME2 Then
                        DoesItMakeSense = False 'PASSES ALL TESTS - RETURN FALSE MEANS THE OPERATION JUST SWAPPED THE LEVELS
                    Else
                        DoesItMakeSense = True
                    End If
                Else
                    DoesItMakeSense = True 'If they're not equal, then something has changed (enough proof to say it might be worth it)
                End If
            Else
                DoesItMakeSense = True 'If they're not equal, then something has changed (enough proof to say it might be worth it)
            End If

            If DoesItMakeSense Then
                AvailableFractionResult = MockTunnel.AccessibleFraction
                Return True
            End If


        End Function

        Public Function ComputeNumberOfMovementPairs(Level1 As Integer, Level2 As Integer) As Integer
            'Outputs the number of movement pairs needed to perform a cleanup on the last streak in the level
            Dim MinMovements As Integer
            If Elevator1 = -2 Then
                'right-to-left
                MinMovements = Me.SimplifiedState(Level1).First.NumberOfItems
                If MinMovements > Me.SimplifiedState(Level2).Last.NumberOfItems Then MinMovements = Me.SimplifiedState(Level2).Last.NumberOfItems
            ElseIf Elevator2 = -2 Then
                'left-to-right
                MinMovements = Me.SimplifiedState(Level1).Last.NumberOfItems
                If MinMovements > Me.SimplifiedState(Level2).First.NumberOfItems Then MinMovements = Me.SimplifiedState(Level2).First.NumberOfItems
            End If
            ComputeNumberOfMovementPairs = MinMovements 'Movement pairs - needs to multiply by 2 to compute the number of movements
        End Function

        Private Sub SimplifyElevator(ByRef E1 As Integer, ByRef E2 As Integer)
            'Returns in E1 and E2 the simplified elevator values (between 0 and 1000, returns 0)

            E1 = Me.Elevator1
            E2 = Me.Elevator2
            If Not (E1 = -2) Then
                If E1 < 1000 AndAlso E1 > -1 Then
                    E1 = 0
                End If
            End If
            If Not (E2 = -2) Then
                If E2 < 1000 AndAlso E2 > -1 Then
                    E2 = 0
                End If
            End If
        End Sub

        Public Function ListOfUnlockedLevels() As List(Of Integer)
            'returns, based on the current SIMPLIFIEDSTATE, the list of levels that aren't full of the same frozen product or of empty trays.
            Dim UnlockedLevelList As New List(Of Integer)

            For I = 0 To VRTM_SimVariables.nLevels - 1
                If SimplifiedState(I).Count = 1 Then
                    If Not (SimplifiedState(I).First.ItemCode >= 1000 Or SimplifiedState(I).First.ItemCode = -1) Then
                        UnlockedLevelList.Add(I) 'This level is full of unfrozen product!
                    End If
                Else
                    UnlockedLevelList.Add(I) 'This level is not full!
                End If
            Next

            Return UnlockedLevelList

        End Function


    End Class

    Public Class SimplifiedLevelInfo
        'Simplifies the level into a pair of two info:
        Public ItemCode As Integer
        Public NumberOfItems As Integer

        Public Shared Operator =(A As SimplifiedLevelInfo, B As SimplifiedLevelInfo) As Boolean
            If A.ItemCode = B.ItemCode AndAlso A.NumberOfItems = B.NumberOfItems Then
                Return True
            Else
                Return False
            End If
        End Operator

        Public Shared Operator <>(A As SimplifiedLevelInfo, B As SimplifiedLevelInfo) As Boolean
            If A.ItemCode = B.ItemCode AndAlso A.NumberOfItems = B.NumberOfItems Then
                Return False
            Else
                Return True
            End If
        End Operator

    End Class

    Public Class PossibleLevelPair
        Implements IComparable(Of PossibleLevelPair)
        'Implements a level pair that is a possible combination.
        'Carries the results and the data of the levels
        Public Level1 As Integer
        Public Level2 As Integer
        Public AvailableFraction As Double
        Public TimeCost As Double
        Public MovementPairs As Integer

        Public Function Compare(compareState As PossibleLevelPair) As Integer _
            Implements IComparable(Of PossibleLevelPair).CompareTo
            ' A null value means that this object is greater.
            If compareState Is Nothing Then
                Return 1
            Else
                Dim C As Integer
                C = AvailableFraction.CompareTo(compareState.AvailableFraction)

                If C = 0 Then C = -TimeCost.CompareTo(compareState.TimeCost)

                Return C

            End If
        End Function
    End Class

    Public Function ConvertStateForMonteCarlo(currentSimulationTimeStep As Long, CurrentTime As Double) As MonteCarloState
        'Gets a current simulation state and converts it into a FrigeItem object.
        Dim CurrentState As New MonteCarloState
        Dim TunnelConfig(,) As Integer
        ReDim TunnelConfig(VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.nLevels - 1)
        Dim StayTime As Double

        'Fills up the current state
        For J = 0 To VRTM_SimVariables.nLevels - 1
            For I = 0 To VRTM_SimVariables.nTrays - 1
                TunnelConfig(I, J) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).ConveyorIndex 'Defines the product index

                StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).TrayIndex)

                If TunnelConfig(I, J) <> -1 Then
                    'Evaluates whether the tray is frozen
                    If StayTime >= (VRTM_SimVariables.InletConveyors(TunnelConfig(I, J)).MinRetTime * 3600) Then
                        TunnelConfig(I, J) = TunnelConfig(I, J) + 1000 '100X indicates a frozen tray
                    End If
                End If

                TunnelConfig(I, J) = TunnelConfig(I, J) + 1 'Adds one to the 0-based SKU index. Empty trays will show as 0.
            Next
        Next

        'Elevators
        Dim IndexOnElevator As Integer = Simulation_Results.Elevator(currentSimulationTimeStep - 1).ConveyorIndex
        StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.Elevator(currentSimulationTimeStep - 1).TrayIndex)

        If IndexOnElevator <> -1 Then
            If StayTime >= (VRTM_SimVariables.InletConveyors(IndexOnElevator).MinRetTime * 3600) Then
                'The tray in the elevator is frozen
                IndexOnElevator = IndexOnElevator + 1000
            End If
        End If
        IndexOnElevator = IndexOnElevator + 1 'Adds one to the 0-based SKU index. Empty trays will show as 0.

        CurrentState.CurrentLevel = Simulation_Results.TrayEntryLevels(currentSimulationTimeStep - 1)
        If Simulation_Results.EmptyElevatorB(currentSimulationTimeStep - 1) Then
            'Elevator B is empty
            CurrentState.Elevator1 = IndexOnElevator
            CurrentState.Elevator2 = -2
        Else
            'Elevator A is empty
            CurrentState.Elevator1 = -2
            CurrentState.Elevator2 = IndexOnElevator
        End If


        'Remaining required variables for the current state
        CurrentState.VRTMStateConv = TunnelConfig
        CurrentState.SKUCount = VRTM_SimVariables.InletConveyors.Count

        CurrentState.ComputeSimplifiedState()

        Return CurrentState
    End Function

    Public Function ComputeTimeForOperations(OperationList As List(Of Integer)) As Double
        'This will compute how much time does it cost for this operation list to be performed
        Dim T As Double = 0

        If OperationList.Count > 1 Then
            For I As Integer = 1 To OperationList.Count - 1
                If I = 0 Then
                    T = T + Compute_Elevator_Time(TunnelState.CurrentLevel, OperationList(I))
                End If

                T = T + Compute_Elevator_Time(OperationList(I - 1), OperationList(I))
                T = T + 2 * VRTM_SimVariables.TrayTransferTime
            Next
        End If

        ComputeTimeForOperations = T
    End Function

    Public Function TrimListOfOperations(OpList As List(Of Integer)) As List(Of Integer)
        'Trims repetitive actions on the given list.
        Dim NewListOfActions As New List(Of Integer)
        Dim LastStreakSize As Integer = 0

        'Commented out so one can test if the lists of actions are actually equivalent
        'Dim TestState1 As MonteCarloState = TunnelState.Clone
        'TestState1.PerformBatchOperation(OpList)
        'Dim AF1 As Double = TestState1.AccessibleFraction

        For I As Integer = 0 To OpList.Count - 2
            If OpList(I) = OpList(I + 1) Then
                LastStreakSize += 1
            Else
                If LastStreakSize Mod 2 = 0 Then
                    'Even number of streaks, means either there is no streak (LastStreakSize=0) or the number of streaks is 2,4,6...
                    'The latter case shows the operation has been performed an ODD number of times (3,5,7...), which is equal to perform the operation only once.
                    NewListOfActions.Add(OpList(I))
                End If
                LastStreakSize = 0
            End If
        Next
        NewListOfActions.Add(OpList.Last)

        'Dim TestState2 As MonteCarloState = TunnelState.Clone
        'TestState2.PerformBatchOperation(NewListOfActions)
        'Dim AF2 As Double = TestState2.AccessibleFraction

        Return NewListOfActions
    End Function

    Public Sub ComplementListWithZeros(OpList As List(Of Integer), TotalSize As Integer)
        'Creates new zero items in the list so the size of the list becomes TotalSize
        'Works on the reference object (doesn't clone to save time)
        If OpList.Count >= TotalSize Then Exit Sub

        For I = 1 To TotalSize - OpList.Count
            OpList.Add(0)
        Next
    End Sub



    Public Function ArrayToCSVString(SomeArray(,) As Integer) As String
        'Returns a CSV-able string from this array
        Dim S As String = ""

        For I As Integer = 0 To UBound(SomeArray, 2)
            For J As Integer = 0 To UBound(SomeArray, 1) - 1
                S = S & SomeArray(J, I) & ","
            Next
            S = S & SomeArray(UBound(SomeArray, 1), I) & vbNewLine
        Next

        Return S
    End Function




End Module
