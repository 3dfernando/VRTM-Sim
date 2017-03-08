Module A_Star
    'This module contains the functions needed to solve the "puzzle" of reorganizing the VRTM shelves
    Public Const H_Weight As Double = 1 'Weight Attributed to the heuristics (G weight is always 1)
    Public Const N_Plies As Integer = 1 'Number of plies used in each fringe group iteration

    Public Function Solve_A_Star_Search(CurrentState As FringeItem) As List(Of Integer)
        'This will solve the A star algorithm for the current VRTM state
        'The goal is to organize the shelves in a fashion that the products with index >1000 go to the side of Elevator2 and the indices <1000 go to the side of Elevator 1
        Dim Fringe As New List(Of FringeItem) 'Fringe of states still being considered
        Dim Count As Long = 0

        Dim T1 As Stopwatch = New Stopwatch
        T1.Start()


        'First layer
        For I As Long = 0 To UBound(CurrentState.VRTMStateConv, 2)
            If I <> CurrentState.CurrentLevel Then
                Dim tF As New FringeItem
                tF = CurrentState.Clone
                tF.Perform_Operation(I)

                Fringe.Add(tF)
            End If
        Next

        'Next layers
        Dim MaxUtility As Double = Double.MinValue
        Dim BestFringe As New FringeItem
        Do While 1
            'Cleanup after N iterations
            If Count > 0 And (Count Mod 500 = 0) Then
                Fringe.Clear()
                Fringe.Add(BestFringe)
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

                            listOfNodes.Add(tF)
                        End If
                    Next
                Next

                LocalTreeNode = listOfNodes

            Next

            'Dequeues it
            Fringe.Remove(BestFringe)
            For Each fr As FringeItem In LocalTreeNode
                Fringe.Add(fr)
            Next

            Count += 1

        Loop


    End Function


    Public Class FringeItem
        Public VRTMStateConv(,) As Integer 'VRTM internal state with conveyor indices (Tray no, Level no) ***A conveyor index that is larger than 1000 is the same as (index-1000), but ready to ship and needs to be on the side of elevator 2 in the goal.
        Public Elevator1 As Integer 'Content of the elevator 1 (-1 means an empty tray, -2 means no tray on it)
        Public Elevator2 As Integer 'Content of the elevator 2 (-1 means an empty tray, -2 means no tray on it)
        Public CurrentLevel As Integer 'Current level the elevator is at
        Public PlanOfActions As List(Of Integer)

        Public AcceptableReward As Double = 1
        Public Current_Utility_U As Double = 0
        Public PrevCost_G As Double = 0
        Public Current_Reward_R As Double = 0
        Public CostBudget As Double = 100000

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
                Me.Current_Reward_R = CurrentReward()
                Me.Current_Utility_U = Me.Current_Reward_R - Me.PrevCost_G / Me.CostBudget

                Me.CurrentLevel = Operation
                Me.PlanOfActions.Add(Operation)
            Else
                'Invalid
            End If
        End Sub

        Public Function CurrentReward() As Double
            'Implements the current utility for the current VRTM state
            Dim AvailableProducts As Integer = 0
            Dim TotalFrozen As Integer = 0

            For J As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                'Looks at each level
                AvailableProducts += AvailableProductCount(J)
                TotalFrozen += FrozenProductCount(J)
            Next

            Return (AvailableProducts / TotalFrozen)
        End Function

        Public Function ComputeCost(Operation As Long) As Double
            'Computes the cost of this action (currently in levels, but can be in time in the future)
            Return Math.Abs(Me.CurrentLevel - Operation)
        End Function

        Public Function GoalTest() As Boolean
            'Tests whether the current fringe item is a goal
            Return CurrentReward() > AcceptableReward
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

        Public Function AvailableProductCount(Level As Integer) As Integer
            'Returns for the current level the number of available frozen product
            Dim AvailableProduct As Integer = 0
            Dim LastProduct As Integer = VRTMStateConv(UBound(Me.VRTMStateConv, 1), Level)


            If LastProduct > 1000 Then
                'There is at least one frozen product at the end of the line
                AvailableProduct = 1
                For I As Integer = UBound(Me.VRTMStateConv, 1) - 1 To 0 Step -1
                    If VRTMStateConv(I, Level) = LastProduct Then
                        'There is a streak of products
                        AvailableProduct += 1
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

        Public Function FrozenProductCount(Level As Integer) As Integer
            'Returns for the current level the number of frozen product
            Dim FrozenProduct As Integer = 0

            For I As Integer = UBound(Me.VRTMStateConv, 1) To 0 Step -1
                If VRTMStateConv(I, Level) > 1000 Then
                    'Another frozen product
                    FrozenProduct += 1
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



End Module
