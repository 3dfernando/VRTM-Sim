Module A_Star
    'This module contains the functions needed to solve the "puzzle" of reorganizing the VRTM shelves
    Public GlobalGoal As FringeItem

    Public Function Solve_A_Star_Search(CurrentState As FringeItem, GoalState As FringeItem) As List(Of Integer)
        'This will solve the a star algorithm for the current VRTM state
        Dim Fringe As New List(Of FringeItem) 'Fringe of states still being considered
        Dim Count As Long = 0

        GlobalGoal = GoalState 'Makes them global so other functions can access it


        'First layer
        For I As Long = 0 To UBound(CurrentState.VRTMStateConv, 2)
            If I <> CurrentState.CurrentLevel Then
                Dim tF As New FringeItem
                tF = CurrentState.Clone
                tF.Perform_Operation(I)

                Fringe.Add(tF)
            End If
        Next

        Do While 1
            'Locates the minimum cost fringe
            Dim MinCost As Double = Double.MaxValue
            Dim MinFringe As New FringeItem


            For I As Long = 0 To Fringe.Count - 1
                If MinCost > Fringe(I).TotalCost_F Then
                    MinCost = Fringe(I).TotalCost_F
                    MinFringe = Fringe(I)
                End If
            Next

            'Expands this fringe
            If MinFringe.GoalTest(GoalState) Then
                Dim A As Integer = 1
                Return MinFringe.PlanOfActions
            End If
            For I As Long = 0 To UBound(CurrentState.VRTMStateConv, 2)
                If I <> MinFringe.CurrentLevel Then
                    Dim tF As New FringeItem
                    tF = MinFringe.Clone
                    tF.Perform_Operation(I)

                    Fringe.Add(tF)
                End If
            Next

            'Dequeues it
            Fringe.Remove(MinFringe)
            Count += 1
        Loop

    End Function


    Public Class FringeItem
        Public VRTMStateConv(,) As Integer 'VRTM internal state with conveyor indices (Tray no, Level no)
        Public Elevator1 As Integer 'Content of the elevator 1 (-1 means an empty tray, -2 means no tray on it)
        Public Elevator2 As Integer 'Content of the elevator 2 (-1 means an empty tray, -2 means no tray on it)
        Public CurrentLevel As Integer 'Current level the elevator is at
        Public PlanOfActions As List(Of Integer)

        Public TotalCost_F As Double
        Public PrevCost_G As Double
        Public HeuristicCost_H As Double

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
                Me.PrevCost_G = Me.PrevCost_G + ComputeCost(Operation)
                Me.HeuristicCost_H = HeuristicCostToGoal(GlobalGoal)
                Me.TotalCost_F = Me.PrevCost_G + Me.HeuristicCost_H

                Me.CurrentLevel = Operation
                Me.PlanOfActions.Add(Operation)

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
            Else
                'Invalid
            End If
        End Sub

        Public Function HeuristicCostToGoal(GoalState As FringeItem) As Double
            'Computes the heuristic cost to some definite goal state.
            Dim ConvIndices(,) As Long
            ReDim ConvIndices(UBound(Me.VRTMStateConv, 1), UBound(Me.VRTMStateConv, 2))

            For i As Integer = 0 To UBound(Me.VRTMStateConv, 1)
                For j As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                    ConvIndices(i, j) = Me.VRTMStateConv(i, j)
                Next
            Next

            Dim IMax As Long = UBound(GoalState.VRTMStateConv, 1)
            Dim JMax As Long = UBound(GoalState.VRTMStateConv, 2)

            If (IMax <> UBound(Me.VRTMStateConv, 1)) Or (JMax <> UBound(Me.VRTMStateConv, 2)) Then Return Nothing

            Dim RadiusList As New List(Of PointLong)
            Dim AcumCost As Double = 0
            Dim Delta_Levels As Double
            Dim Delta_Trays As Double

            For I As Long = 0 To IMax
                For J As Long = 0 To JMax
                    'Tries the items in a column-wise fashion (easier to compute, might not be an admissible heuriscs)
                    For I1 As Long = 0 To IMax
                        For J1 As Long = 0 To JMax
                            If ConvIndices(I1, J1) = GoalState.VRTMStateConv(I, J) Then
                                ConvIndices(I1, J1) = -99
                                Delta_Levels = Math.Abs((I1 - I)) + Math.Abs((J1 - J))
                                'Tests the current costs according to the heuristics
                                Delta_Trays = I + I1
                                If Delta_Trays > (2 * IMax - I - I1) Then Delta_Trays = (2 * IMax - I - I1)
                                AcumCost += Delta_Trays * Delta_Levels
                                GoTo ContinueFor
                            End If
                        Next
                    Next
ContinueFor:
                Next
            Next

            HeuristicCostToGoal = AcumCost
        End Function


        Public Function ComputeCost(Operation As Long) As Double
            'Computes the cost of this action (currently in levels, but can be in time in the future)
            Return Math.Abs(Me.CurrentLevel - Operation)
        End Function

        Public Function GoalTest(Goal As FringeItem) As Boolean
            'Tests whether the current fringe item is a goal
            For i As Integer = 0 To UBound(Me.VRTMStateConv, 1)
                For j As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                    If (Goal.VRTMStateConv(i, j) <> Me.VRTMStateConv(i, j)) Then Return False
                Next
            Next
            Return True
        End Function
    End Class




    Public Class PointLong
        Implements IComparable(Of PointLong)
        Public T As Long
        Public L As Long
        Public R As Double

        Public Sub New(I, J, I1, J1)
            Me.T = I1
            Me.L = J1

            Dim dI, dJ As Long
            dI = I1 - I
            dJ = J1 - J

            Me.R = Math.Sqrt(dI * dI + dJ * dJ)
        End Sub

        Public Function CompareTo(comparedPoint As PointLong) As Integer _
            Implements IComparable(Of PointLong).CompareTo
            ' A null value means that this object is greater.
            If comparedPoint Is Nothing Then
                Return 1
            Else
                Return Me.R.CompareTo(comparedPoint.R)
            End If
        End Function
    End Class

End Module
