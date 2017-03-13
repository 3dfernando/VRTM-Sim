Imports VRTM_Simulator

Public Module A_Star
    'This module contains the functions needed to solve the "puzzle" of reorganizing the VRTM shelves
    Public Const H_Weight As Double = 1 'Weight Attributed to the heuristics (G weight is always 1)
    Public Const N_Plies As Integer = 2 'Number of plies used in each fringe group iteration
    Public RandomColorSet As New List(Of Color) 'This is for debugging of the VRTM. The random color set needs to be fixed and thus cannot be defined under the A_Star_Debug_Window form

    Public Function Solve_A_Star_Search(CurrentState As FringeItem, TimeBudget_s As Double) As List(Of Integer)
        'This will solve the A star algorithm for the current VRTM state
        'The goal is to organize the shelves in a fashion that the products with index >1000 go to the side of Elevator2 and the indices <1000 go to the side of Elevator 1
        Dim Fringe As New List(Of FringeItem) 'Fringe of states still being considered
        Dim Count As Long = 0

        '-----------Evolutionary selection config----------
        Dim Gen As Long = 0 'Generation number
        Dim GenLoops As Long = 100 'Tree branchings to next generation
        Dim Decimation As Long = 100 'Total Number of fringes left after a decimation event
        Dim DeceaseProbability As Double = 0.2 'How many deceased (not within the best choices for decimation) fringes will be chosen randomly
        Dim GenBestFitness As New List(Of Double) 'List of peak fitness (utility) function results for each generation
        Dim GenBests As New List(Of FringeItem) 'List of peak fitness (utility) function results for each generation

        Dim T1 As Stopwatch = New Stopwatch
        T1.Start()

        CurrentState.Current_Reward_R = CurrentState.ComputeReward(CurrentState.RewardComputation) 'Ensures the current state has already a reward function

        'Before everything, flush the current state
        Dim FlushedCurrentState As FringeItem = CurrentState.Clone
        FlushedCurrentState.Flush(5)

        'First layer
        For I As Long = 0 To UBound(FlushedCurrentState.VRTMStateConv, 2)
            If I <> FlushedCurrentState.CurrentLevel Then
                Dim tF As New FringeItem
                tF = FlushedCurrentState.Clone
                tF.Perform_Operation(I)

                Fringe.Add(tF)
            End If
        Next

        'Next layers
        Dim MaxUtility As Double = Double.MinValue
        Dim BestFringe As New FringeItem
        Do While 1
            'Cleanup after N iterations
            If Count > 0 And (Count Mod GenLoops = 0) Then
                'Tests if the time budget has been exceeded
                If T1.ElapsedMilliseconds / 1000 > TimeBudget_s Then
                    'Debug line - Enable to visualize the current results
                    DebugThisState(CurrentState, GenBests, GenBestFitness)

                    Return BestFringe.PlanOfActions
                End If

                '--------------------New Generation----------------------
                Gen += 1

                Fringe.Sort() 'Makes it possible to select the best fitness functions

                Dim ChosenFringes As New List(Of FringeItem)
                'Chooses the best fit fringes
                If Fringe.Count > Decimation Then
                    'Selects within the best ones the non-deceased
                    For I = 1 To Decimation
                        If Rnd() > DeceaseProbability Then
                            'Chooses the unit
                            ChosenFringes.Add(Fringe(I))
                        Else
                            'The unit has deceased and will not be chosen
                        End If
                    Next

                    Dim FringesLeftToChoose As Integer = Decimation - ChosenFringes.Count
                    If FringesLeftToChoose > 0 Then
                        'Select Bad fringes
                        Dim DeceaseProbabilityOfBadOnes As Double = 1 - (FringesLeftToChoose / (Fringe.Count - Decimation))
                        For I = Decimation + 1 To Fringe.Count - 1
                            If Rnd() > DeceaseProbabilityOfBadOnes Then
                                'Chooses the unit
                                Fringe(I).Flush(5)
                                'DebugThisState(Fringe(I), GenBests, GenBestFitness)
                                ChosenFringes.Add(Fringe(I))
                            Else
                                'The unit has deceased and will not be chosen
                            End If
                        Next
                    End If


                    Fringe.Clear()
                    Fringe.AddRange(ChosenFringes)
                Else
                    'All fringes will be selected, it makes no sense to perform evolution. 
                End If

                Fringe.Sort()
                BestFringe = Fringe(0)

                GenBestFitness.Add(BestFringe.Current_Reward_R)
                GenBests.Add(BestFringe)

                'Debug line - Enable to visualize the current results <<<<<<<<<<<<<<<================================================================
                DebugThisState(CurrentState, GenBests, GenBestFitness)
            End If


            'Locates the maximum utility fringe
            MaxUtility = Double.MinValue

            For I As Long = 0 To Fringe.Count - 1
                If MaxUtility < Fringe(I).Current_Utility_U Then
                    MaxUtility = Fringe(I).Current_Utility_U
                    BestFringe = Fringe(I)
                End If
            Next

            'Expands this fringe
            If BestFringe.GoalTest() Then
                T1.Stop()
                DebugThisState(CurrentState, GenBests, GenBestFitness)
                Return BestFringe.PlanOfActions
            End If

            Dim LocalTreeNode As New List(Of FringeItem)
            LocalTreeNode.Add(BestFringe)

            For K As Long = 1 To N_Plies
                Dim listOfNodes As New List(Of FringeItem)
                For Each fr As FringeItem In LocalTreeNode
                    For I As Long = 0 To UBound(CurrentState.VRTMStateConv, 2)
                        If I <> fr.CurrentLevel And Not fr.IsLevelClosed(I) Then
                            Dim tF As New FringeItem
                            tF = fr.Clone
                            tF.Perform_Operation(I)

                            If tF.PrevCost_G <= tF.CostBudget Then
                                listOfNodes.Add(tF)
                            Else
                                Dim X As Long = 0
                            End If
                        End If
                    Next
                Next

                LocalTreeNode = listOfNodes

            Next

            'Dequeues it
            If LocalTreeNode.Count >= 1 Then
                Fringe.Remove(BestFringe)
                Fringe.AddRange(LocalTreeNode)

            End If

            Count += 1

            'Debug line - Enable to visualize the current results
            'DebugThisState(CurrentState, GenBests, GenBestFitness)

        Loop

        Return Nothing
    End Function


    Public Class FringeItem
        Implements IComparable(Of FringeItem)

        Public VRTMStateConv(,) As Integer 'VRTM internal state with conveyor indices (Tray no, Level no) ***A conveyor index that is larger than 1000 is the same as (index-1000), but ready to ship and needs to be on the side of elevator 2 in the goal.
        Public Elevator1 As Integer 'Content of the elevator 1 (-1 means an empty tray, -2 means no tray on it)
        Public Elevator2 As Integer 'Content of the elevator 2 (-1 means an empty tray, -2 means no tray on it)
        Public CurrentLevel As Integer 'Current level the elevator is at
        Public PlanOfActions As List(Of Integer)
        Public SKUCount As Integer 'Number of unique SKUs to treat here

        Public AcceptableReward As Double = 1
        Public Current_Utility_U As Double = 0
        Public PrevCost_G As Double = 0
        Public Current_Reward_R As Double = 0
        Public RewardComputation As String = "Global"
        Public CostBudget As Double = 100000

        Public Function Compare(compareFringe As FringeItem) As Integer _
            Implements IComparable(Of FringeItem).CompareTo
            ' A null value means that this object is greater.
            If compareFringe Is Nothing Then
                Return 1
            Else
                Return Current_Utility_U.CompareTo(compareFringe.Current_Utility_U)
            End If
        End Function

        Public Function Clone() As FringeItem
            Dim ClonedItem As New FringeItem
            ReDim ClonedItem.VRTMStateConv(UBound(Me.VRTMStateConv, 1), UBound(Me.VRTMStateConv, 2))

            For i As Integer = 0 To UBound(Me.VRTMStateConv, 1)
                For j As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                    ClonedItem.VRTMStateConv(i, j) = Me.VRTMStateConv(i, j)
                Next
            Next

            ClonedItem.PlanOfActions = New List(Of Integer)
            For i As Integer = 0 To Me.PlanOfActions.Count - 1
                ClonedItem.PlanOfActions.Add(Me.PlanOfActions(i))
            Next

            ClonedItem.Elevator1 = Me.Elevator1
            ClonedItem.Elevator2 = Me.Elevator2
            ClonedItem.CurrentLevel = Me.CurrentLevel

            ClonedItem.Current_Utility_U = Me.Current_Utility_U
            ClonedItem.PrevCost_G = Me.PrevCost_G
            ClonedItem.Current_Reward_R = Me.Current_Reward_R
            ClonedItem.CostBudget = Me.CostBudget
            ClonedItem.AcceptableReward = Me.AcceptableReward
            ClonedItem.RewardComputation = Me.RewardComputation
            ClonedItem.SKUCount = Me.SKUCount

            Return ClonedItem
        End Function

        Public Sub Perform_Operation(Operation As Long)
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

                'Computes costs 
                Me.PrevCost_G = Me.PrevCost_G + ComputeCost(Operation)
                Me.Current_Reward_R = ComputeReward(RewardComputation)
                Me.Current_Utility_U = Me.Current_Reward_R - Me.PrevCost_G / Me.CostBudget

                Me.CurrentLevel = Operation
                Me.PlanOfActions.Add(Operation)
            Else
                'Invalid
            End If
        End Sub

        Public Function ComputeReward(Type As String) As Double
            'Implements the current utility for the current VRTM state
            'Reward Type as String

            Select Case Type
                Case "Global"
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
                Case "Minimum"
                    'Computes the fraction available/frozen for each SKU and returns the minimum value
                    Dim AvailableProducts() As Integer
                    Dim TotalFrozen() As Integer
                    ReDim AvailableProducts(SKUCount)
                    ReDim TotalFrozen(SKUCount)

                    For I As Integer = 1 To SKUCount
                        AvailableProducts(I) = 0
                        TotalFrozen(I) = 0
                        For J As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                            'Looks at each level
                            AvailableProducts(I) += AvailableProductCount(J, I)
                            TotalFrozen(I) += FrozenProductCount(J, I)
                        Next J
                    Next I

                    'Now searches for the minimum ratio available/frozen
                    Dim MinAvFrozenRatio As Double = Double.MaxValue
                    Dim CurrAvFrozenRatio As Double
                    Dim AvFrozenRatios() As Double
                    ReDim AvFrozenRatios(SKUCount)


                    For I As Integer = 1 To Me.SKUCount
                        If TotalFrozen(I) <> 0 Then
                            CurrAvFrozenRatio = AvailableProducts(I) / TotalFrozen(I)
                            AvFrozenRatios(I) = CurrAvFrozenRatio
                            If MinAvFrozenRatio > CurrAvFrozenRatio Then MinAvFrozenRatio = CurrAvFrozenRatio
                        End If
                    Next

                    If MinAvFrozenRatio < 0 Then MinAvFrozenRatio = 0

                    Return MinAvFrozenRatio
                Case Else
                    Return Nothing
            End Select

        End Function

        Public Function ComputeCost(Operation As Long) As Double
            'Computes the cost of this action (currently in levels, but can be in time in the future)
            Return Math.Abs(Me.CurrentLevel - Operation)
        End Function

        Public Function GoalTest() As Boolean
            'Tests whether the current fringe item is a goal
            Return ComputeReward(RewardComputation) > AcceptableReward
        End Function

        Public Function CurrentStatusPoints() As Integer
            'Calculates the total number of points the current status deserves based on how long are the string 
            Dim StringReady As Boolean
            Dim PointsEarned As Integer = 0
            Dim S As Integer

            For J As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                'Just sums the points
                LargestValidString(J, StringReady, 0, S)
                PointsEarned += S
            Next

            Return PointsEarned
        End Function

        Public Sub LargestValidString(Level As Integer, ByRef IsStringReady As Boolean, ByRef LargestStringPosition As Integer, ByRef LargestStringSize As Integer)
            'This function will look inside the given Level what is the largest valid string of products and return the size of it.
            LargestStringSize = 0
            LargestStringPosition = -1
            Dim CurrentStringSize As Integer = 1
            Dim CurrentStringPosition As Integer = 0

            For I As Integer = 1 To UBound(Me.VRTMStateConv, 1)
                If (Me.VRTMStateConv(I - 1, Level) = Me.VRTMStateConv(I, Level)) _
                    Or (Me.VRTMStateConv(I - 1, Level) < 1000 And Me.VRTMStateConv(I, Level) > 1000) Then
                    CurrentStringSize += 1
                Else
                    If CurrentStringSize > LargestStringSize Then
                        LargestStringPosition = CurrentStringPosition
                        LargestStringSize = CurrentStringSize
                    End If
                    CurrentStringPosition = I
                    CurrentStringSize = 1
                End If
            Next
            If CurrentStringSize > LargestStringSize Then
                LargestStringPosition = CurrentStringPosition
                LargestStringSize = CurrentStringSize
            End If

            IsStringReady = Me.VRTMStateConv(UBound(Me.VRTMStateConv, 1), Level) >= 1000 'If the last item is ready returns that the string is ready
        End Sub

        Public Function ClearLevelButTheLargestString(Level As Integer, ByRef UnFrozenProduct As Integer, ByRef FrozenProduct As Integer,
                                                      ByRef Beginning As Integer, ByRef Ending As Integer) As Integer()
            'This function will look inside the given Level what is the largest valid string of products, 
            'and then return the same level as an array with the elements that do not belong to this largest string as "-1" (empty tray)

            Dim LargestStringBegins, StringSize As Integer
            LargestValidString(Level, False, LargestStringBegins, StringSize)

            'Fills up a new level with the longest string and nothing else
            Dim ModifiedLevel() As Integer
            ReDim ModifiedLevel(UBound(Me.VRTMStateConv, 1))

            For I As Integer = 0 To UBound(Me.VRTMStateConv, 1)
                If I >= LargestStringBegins And I <= LargestStringBegins + StringSize - 1 Then
                    ModifiedLevel(I) = Me.VRTMStateConv(I, Level)
                Else
                    ModifiedLevel(I) = -1
                End If
            Next

            ClearLevelButTheLargestString = ModifiedLevel
            Beginning = LargestStringBegins
            Ending = LargestStringBegins + StringSize - 1
            UnFrozenProduct = Me.VRTMStateConv(LargestStringBegins, Level)
            FrozenProduct = Me.VRTMStateConv(Ending, Level)
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

        Public Function IsLevelClosed(Level As Integer) As Boolean
            'Returns whether the level contains the same frozen product
            Dim LastProduct As Integer = VRTMStateConv(UBound(Me.VRTMStateConv, 1), Level)

            For I As Integer = UBound(Me.VRTMStateConv, 1) To 0 Step -1
                If VRTMStateConv(I, Level) < 1000 Then
                    Return False
                Else
                    If VRTMStateConv(I, Level) <> LastProduct Then
                        Return False
                    End If
                End If
            Next

            Return True
        End Function

        Public Sub Flush(NFlushes As Integer)
            'Will take any set of incomplete levels (with any streak of frozen product) with the same SKU and merge them together [by performing movements].
            Dim AvailableProductCountList As New Dictionary(Of Integer, Integer) 'key=Level, value=Count
            Dim AvProd As Integer

            For N = 1 To NFlushes 'Performs multiple flushes as advancing product can happen to be flushable again
                For S As Integer = 1 To SKUCount
                    AvailableProductCountList.Clear()
                    For L As Integer = 0 To UBound(VRTMStateConv, 2)
                        AvProd = AvailableProductCount(L, S)
                        If AvProd > 0 Then
                            AvailableProductCountList.Add(L, AvProd)
                        End If
                    Next

                    Dim FirstLevel As Integer, SecondLevel As Integer
                    Dim NMovements As Integer
                    Dim LevelToRemove As Integer
                    Do While AvailableProductCountList.Count > 1
                        'Only performs movements if there is at least one pair of levels.
                        FirstLevel = AvailableProductCountList.Keys(0)
                        SecondLevel = AvailableProductCountList.Keys(1)

                        'Dumps the content of SecondLevel onto FirstLevel 
                        NMovements = (UBound(VRTMStateConv, 1) + 1) - AvailableProductCountList(FirstLevel) 'The largest number of movements possible is to fill up the first level
                        If NMovements > AvailableProductCountList(SecondLevel) Then
                            NMovements = AvailableProductCountList(SecondLevel) 'But if there isn't enough product in the second level then it will just empty the second level.
                            LevelToRemove = 2
                        Else
                            LevelToRemove = 1
                        End If


                        If Elevator1 = -2 Then
                            'Elevator 1 is empty - This means the movements will not work - Needs to undo the last movement
                            Me.Perform_Operation(Me.PlanOfActions.Last)

                            Me.PlanOfActions.RemoveAt(Me.PlanOfActions.Count - 1) 'Removes both the advance and retract actions from the record
                            Me.PlanOfActions.RemoveAt(Me.PlanOfActions.Count - 1)
                        End If

                        For I As Integer = 1 To NMovements
                            'This will actually perform the dump
                            Me.Perform_Operation(SecondLevel)
                            Me.Perform_Operation(FirstLevel)
                        Next

                        'now removes either the first or second level, depending on the choice made previously
                        If LevelToRemove = 1 Then
                            AvailableProductCountList.Remove(FirstLevel)
                        Else
                            AvailableProductCountList.Remove(SecondLevel)
                        End If
                    Loop
                Next
            Next
        End Sub
    End Class

    Public Function GenerateRandomState(NLevels As Integer, NTrays As Integer, NSKUs As Integer, PercentFrozen As Double) As Integer(,)
        'This function will generate a random state to test the algorithm
        Dim ResultState(,) As Integer
        ReDim ResultState(NTrays - 1, NLevels - 1)

        For I As Integer = 0 To NTrays - 1
            For J As Integer = 0 To NLevels - 1
                ResultState(I, J) = Int(Rnd() * NSKUs) + 1
                If Rnd() <= PercentFrozen Then
                    ResultState(I, J) += 1000
                End If
            Next
        Next

        GenerateRandomState = ResultState
    End Function

    Public Function ConvertStateForA_Star(currentSimulationTimeStep As Long, CurrentTime As Double, Availability As Double) As FringeItem
        'Gets a current simulation state and converts it into a FrigeItem object.
        Dim CurrentState As New FringeItem
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

        CurrentState.PlanOfActions = New List(Of Integer)
        CurrentState.CurrentLevel = Simulation_Results.TrayEntryLevels(currentSimulationTimeStep - 1)
        If Simulation_Results.EmptyElevatorB(currentSimulationTimeStep - 1) Then
            'Elevator B is empty
            CurrentState.Elevator1 = IndexOnElevator
            CurrentState.Elevator2 = -2
        Else
            'Elevator A is empty
            CurrentState.Elevator1 = -2
            CurrentState.Elevator2 = IndexOnElevator
            CurrentState.PlanOfActions.Add(CurrentState.CurrentLevel)
        End If


        'Remaining required variables for the current state
        CurrentState.VRTMStateConv = TunnelConfig
        CurrentState.PrevCost_G = 0
        CurrentState.AcceptableReward = Availability
        CurrentState.SKUCount = VRTM_SimVariables.InletConveyors.Count
        CurrentState.RewardComputation = "Global" 'Global or Minimum

        Return CurrentState
    End Function

    Public Sub DebugThisState(OriginalState As FringeItem, BestGenerations As List(Of FringeItem), BestFitnesses As List(Of Double))
        'This sub will show and hide the current form to perform debug in the array
        If RandomColorSet.Count = 0 Then
            For I = 1 To OriginalState.SKUCount
                RandomColorSet.Add(Color.FromArgb(Rnd() * 255, Rnd() * 255, Rnd() * 255))
            Next
        End If

        Dim DebugForm As New A_Star_DebugWindow

        DebugForm.OriginalState = OriginalState
        DebugForm.BestGenerations = BestGenerations
        DebugForm.BestFitnesses = BestFitnesses
        DebugForm.ShowDialog()
    End Sub

End Module
