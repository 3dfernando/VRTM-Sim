Module A_Star
    'This module contains the functions needed to solve the "puzzle" of reorganizing the VRTM shelves
    Public Const H_Weight As Double = 1 'Weight Attributed to the heuristics (G weight is always 1)
    Public Const N_Plies As Integer = 3 'Number of plies used in each fringe group iteration

    Public Function Solve_A_Star_Search(CurrentState As FringeItem) As List(Of Integer)
        'This will solve the A star algorithm for the current VRTM state
        'The goal is to organize the shelves in a fashion that the products with index >1000 go to the side of Elevator2 and the indices <1000 go to the side of Elevator 1
        Dim Fringe As New List(Of FringeItem) 'Fringe of states still being considered
        Dim Count As Long = 0


        'First layer
        For I As Long = 0 To UBound(CurrentState.VRTMStateConv, 2)
            If I <> CurrentState.CurrentLevel Then
                Dim tF As New FringeItem
                tF = CurrentState.Clone
                tF.Perform_Operation(I)

                Fringe.Add(tF)
            End If
        Next

        Dim CostWeight As Double = 0
        Dim RewardWeight As Double = 1

        Do While 1
            'Locates the minimum cost fringe
            Dim MinCost As Double = Double.MaxValue
            Dim MinFringe As New FringeItem

            For I As Long = 0 To Fringe.Count - 1
                If MinCost > Fringe(I).TotalCost_F Then
                    MinCost = Fringe(I).TotalCost_F * CostWeight - Fringe(I).PointsEarned * RewardWeight
                    MinFringe = Fringe(I)
                End If
            Next


            'Expands this fringe
            If MinFringe.GoalTest() Then
                Dim A As Integer = 1
                Return MinFringe.PlanOfActions
            End If

            Dim LocalTreeNode As New List(Of FringeItem)
            LocalTreeNode.Add(MinFringe)

            For K As Long = 1 To N_Plies
                Dim listOfNodes As New List(Of FringeItem)
                For Each fr As FringeItem In LocalTreeNode
                    For I As Long = 0 To UBound(CurrentState.VRTMStateConv, 2)
                        If I <> fr.CurrentLevel Then
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
            Fringe.Remove(MinFringe)
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

        Public TotalCost_F As Double
        Public PrevCost_G As Double
        Public HeuristicCost_H As Double
        Public PointsEarned As Integer

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

            ClonedItem.TotalCost_F = Me.TotalCost_F
            ClonedItem.PrevCost_G = Me.PrevCost_G
            ClonedItem.HeuristicCost_H = Me.HeuristicCost_H

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

                'Computes costs and points
                Me.PrevCost_G = Me.PrevCost_G + ComputeCost(Operation)
                Me.HeuristicCost_H = HeuristicCostToGoal()
                Me.TotalCost_F = Me.PrevCost_G + Me.HeuristicCost_H
                Me.PointsEarned = Me.CurrentStatusPoints
                Me.CurrentLevel = Operation
                Me.PlanOfActions.Add(Operation)
            Else
                'Invalid
            End If
        End Sub

        Public Function HeuristicCostToGoal() As Double
            'Computes the heuristic cost to some definite goal state.
            'Copies the indices to a temporary variable
            Dim ConvIndices(,) As Integer
            ReDim ConvIndices(UBound(Me.VRTMStateConv, 1), UBound(Me.VRTMStateConv, 2))

            For i As Integer = 0 To UBound(Me.VRTMStateConv, 1)
                For j As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                    ConvIndices(i, j) = Me.VRTMStateConv(i, j)
                Next
            Next

            Dim IMax As Long = UBound(Me.VRTMStateConv, 1)
            Dim JMax As Long = UBound(Me.VRTMStateConv, 2)


            Dim NewLevel() As Integer
            Dim UnfrozenProd As Integer
            Dim FrozenProd As Integer
            Dim Beginning As Integer
            Dim Ending As Integer

            Dim Delta_Levels As Integer
            Dim Delta_Trays As Integer
            Dim AcumCost As Integer = 0

            For J As Integer = 0 To JMax
                'Runs through each level and clears out the largest strings from the conveyor indices
                NewLevel = ClearLevelButTheLargestString(J, UnfrozenProd, FrozenProd, Beginning, Ending)

                For I As Integer = Beginning To Ending
                    'These trays are not available
                    ConvIndices(I, J) = -99
                Next
            Next

            For J As Integer = 0 To JMax

                NewLevel = ClearLevelButTheLargestString(J, UnfrozenProd, FrozenProd, Beginning, Ending)
                'Now runs through each level and tries to move the trays that haven't yet been positioned according to the heuristics
                For I As Integer = 0 To Beginning - 1
                    For I1 As Integer = 0 To IMax
                        For J1 As Integer = 0 To JMax
                            If ConvIndices(I1, J1) = UnfrozenProd Then
                                ConvIndices(I1, J1) = -99
                                Delta_Levels = Math.Abs((I1 - I)) + Math.Abs((J1 - J))
                                'Tests the current costs according to the heuristics
                                Delta_Trays = I + I1 + 2
                                If Delta_Trays > (2 * IMax - I - I1) Then Delta_Trays = (2 * IMax - I - I1)
                                AcumCost += Delta_Trays * Delta_Levels
                                GoTo ContinueFor1
                            End If
                        Next
                    Next
ContinueFor1:
                Next

                For I As Integer = Ending + 1 To IMax
                    For I1 As Integer = 0 To IMax
                        For J1 As Integer = 0 To JMax
                            If ConvIndices(I1, J1) = UnfrozenProd Then
                                ConvIndices(I1, J1) = -99
                                Delta_Levels = Math.Abs((I1 - I)) + Math.Abs((J1 - J))
                                'Tests the current costs according to the heuristics
                                Delta_Trays = I + I1
                                If Delta_Trays > (2 * IMax - I - I1) Then Delta_Trays = (2 * IMax - I - I1)
                                AcumCost += Delta_Trays * Delta_Levels
                                GoTo ContinueFor2
                            End If
                        Next
                    Next
ContinueFor2:
                Next

            Next

            HeuristicCostToGoal = AcumCost * H_Weight
        End Function


        Public Function ComputeCost(Operation As Long) As Double
            'Computes the cost of this action (currently in levels, but can be in time in the future)
            Return Math.Abs(Me.CurrentLevel - Operation)
        End Function

        Public Function GoalTest() As Boolean
            'Tests whether the current fringe item is a goal
            Dim LargestStringSize As Integer
            Dim StringReady As Boolean
            Dim ValidLevels As Integer = 0

            For J As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                'Looks for the largest valid string 
                LargestValidString(J, StringReady, 0, LargestStringSize)
                If (LargestStringSize = (UBound(Me.VRTMStateConv, 1) + 1) And StringReady) Then ValidLevels += 1
            Next
            If ValidLevels = UBound(Me.VRTMStateConv, 2) + 1 Then Return True
            Return False
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

    End Class

End Module
