Module A_Star
    'This module contains the functions needed to solve the "puzzle" of reorganizing the VRTM shelves
    Public GlobalGoal As VRTMState

    Public Function Solve_A_Star_Search(CurrentState As VRTMState, GoalState As VRTMState) As Long()
        'This will solve the a star algorithm for the current VRTM state
        Dim Fringe As New List(Of FringeItem) 'VRTMState, Operation
        Dim FringesToAdd As New List(Of FringeItem) 'VRTMState, Operation
        Dim FringesToRemove As New List(Of FringeItem) 'VRTMState, Operation

        Dim GoalTest As Boolean = False

        GlobalGoal = GoalState 'Makes them global so other functions can access it

        'First layer
        For I As Long = 0 To UBound(CurrentState.ConveyorIndexArray, 2)
            If I <> CurrentState.CurrentLevel Then
                Dim tF As New FringeItem
                tF.CurrState = CurrentState.Clone
                tF.PlannedOperation = I
                Fringe.Add(tF)
            End If
        Next

        Dim Goal As VRTMState = Nothing


        Do Until GoalTest
            Fringe.Sort() 'Sorts the fringe by cost

            For Each f As FringeItem In Fringe
                For I As Long = 0 To UBound(f.CurrState.ConveyorIndexArray, 2)
                    If I <> f.CurrState.CurrentLevel Then
                        Dim tF As New FringeItem
                        tF.CurrState = f.CurrState.Perform_Operation(f.PlannedOperation)
                        tF.PlannedOperation = I
                        FringesToAdd.Add(tF)
                    End If
                Next
                FringesToRemove.Add(f)
            Next

            'Now performs the add remove operations
            For Each f As FringeItem In FringesToRemove
                Fringe.Remove(f)
            Next
            For Each f As FringeItem In FringesToAdd
                Fringe.Add(f)
            Next

        Loop

    End Function


    Public Class FringeItem
        Implements IComparable(Of FringeItem)
        Public CurrState As VRTMState
        Public PlannedOperation As Long

        Public Function CompareTo(comparedItem As FringeItem) As Integer _
            Implements IComparable(Of FringeItem).CompareTo
            ' A null value means that this object is greater.
            If comparedItem Is Nothing Then
                Return 1
            Else
                Dim CostMe As Double = Me.CurrState.PrevCost + Me.CurrState.ComputeCost(Me.PlannedOperation) + Me.CurrState.HeuristicCostToGoal(GlobalGoal)
                Dim CostOther As Double = comparedItem.CurrState.PrevCost + comparedItem.CurrState.ComputeCost(comparedItem.PlannedOperation) + comparedItem.CurrState.HeuristicCostToGoal(GlobalGoal)
                Return CostMe.CompareTo(CostOther)
            End If
        End Function
    End Class


    Public Class VRTMState
        Implements System.ICloneable

        Public ConveyorIndexArray(,) As Long 'VRTM internal state with conveyor indices (Tray no, Level no)
        Public Elevator1 As Long 'Content of the elevator 1 (-1 means an empty tray, -2 means no tray on it)
        Public Elevator2 As Long 'Content of the elevator 2 (-1 means an empty tray, -2 means no tray on it)
        Public CurrentLevel As Long 'Current level the elevator is at
        Public PlanOfActions As List(Of Long)
        Public PrevCost As Double

        Public Sub New(nTrays As Long, nLevels As Long, Elev1 As Long, Elev2 As Long, CurrLevel As Long)
            ReDim ConveyorIndexArray(nTrays, nLevels)
            Elevator1 = Elev1
            Elevator2 = Elev2
            CurrentLevel = CurrLevel
            PlanOfActions = New List(Of Long)
            PrevCost = 0
        End Sub

        Public Function Perform_Operation(Operation As Long) As VRTMState
            'Performs an operation of moving and swapping according to the operation. 
            'The operation is the number of the level that the elevator will move to and perform the swap
            If Me.Elevator1 = -2 Xor Me.Elevator2 Then
                'Only one elevator can be empty
                Dim NewState As VRTMState = Nothing
                NewState = Me.Clone
                NewState.PrevCost = NewState.PrevCost + ComputeCost(Operation)
                NewState.CurrentLevel = Operation
                NewState.PlanOfActions.Add(Operation)

                If Me.Elevator1 = -2 Then
                    NewState.Elevator1 = NewState.ConveyorIndexArray(0, Operation)
                    For I As Long = 0 To UBound(NewState.ConveyorIndexArray, 1) - 1
                        NewState.ConveyorIndexArray(I, Operation) = NewState.ConveyorIndexArray(I + 1, Operation)
                    Next
                    NewState.ConveyorIndexArray(UBound(NewState.ConveyorIndexArray, 1), Operation) = Me.Elevator2
                    NewState.Elevator2 = -2
                ElseIf Me.Elevator2 = -2 Then
                    NewState.Elevator2 = NewState.ConveyorIndexArray(UBound(NewState.ConveyorIndexArray, 1), Operation)
                    For I As Long = UBound(NewState.ConveyorIndexArray, 1) - 1 To 0 Step -1
                        NewState.ConveyorIndexArray(I + 1, Operation) = NewState.ConveyorIndexArray(I, Operation)
                    Next
                    NewState.ConveyorIndexArray(0, Operation) = Me.Elevator1
                    NewState.Elevator1 = -2
                End If
                Return NewState
            Else
                'Invalid
                Return Nothing
            End If
        End Function

        Public Function ComputeCost(Operation As Long) As Double
            'Computes the cost of this action (currently in levels, but can be in time in the future)
            Return Math.Abs(Me.CurrentLevel - Operation)
        End Function

        Public Function HeuristicCostToGoal(GoalState As VRTMState) As Double
            'Computes the heuristic cost to some definite goal state.
            Dim ConvIndices(,) As Long = Me.ConveyorIndexArray.Clone

            Dim IMax As Long = UBound(GoalState.ConveyorIndexArray, 1)
            Dim JMax As Long = UBound(GoalState.ConveyorIndexArray, 2)

            If (IMax <> UBound(Me.ConveyorIndexArray, 1)) Or (JMax <> UBound(Me.ConveyorIndexArray, 2)) Then Return Nothing

            Dim RadiusList As New List(Of PointLong)
            Dim AcumCost As Double = 0

            For I As Long = 0 To IMax
                For J As Long = 0 To JMax
                    'Enumerates all the radii and then tries radially outwards
                    RadiusList.Clear()

                    For I1 As Long = 0 To IMax
                        For J1 As Long = 0 To JMax
                            RadiusList.Add(New PointLong(I, J, I1, J1)) 'MUST SOLVE THE DUPLICATE PROBLEM NOT ALLOWED IN DICTIONARIES
                        Next
                    Next
                    RadiusList.Sort()

                    For K = 0 To RadiusList.Count - 1
                        If ConvIndices(RadiusList(K).T, RadiusList(K).L) = GoalState.ConveyorIndexArray(I, J) Then
                            ConvIndices(RadiusList(K).T, RadiusList(K).L) = -99
                            AcumCost += Math.Abs((RadiusList(K).T - I) + (RadiusList(K).L - J))
                        End If
                    Next
                Next
            Next

            HeuristicCostToGoal = AcumCost
        End Function

        Public Function Clone() As Object Implements ICloneable.Clone
            Dim ClonedItem As New VRTMState(0, 0, Me.Elevator1, Me.Elevator2, Me.CurrentLevel)
            ReDim ClonedItem.ConveyorIndexArray(UBound(Me.ConveyorIndexArray, 1), UBound(Me.ConveyorIndexArray, 2))

            For I As Long = 0 To UBound(Me.ConveyorIndexArray, 1)
                For J As Long = 0 To UBound(Me.ConveyorIndexArray, 2)
                    ClonedItem.ConveyorIndexArray(I, J) = Me.ConveyorIndexArray(I, J)
                Next
            Next

            For I As Long = 0 To Me.PlanOfActions.Count() - 1
                ClonedItem.PlanOfActions.Add(Me.PlanOfActions(I))
            Next
            ClonedItem.PrevCost = Me.PrevCost

            Return ClonedItem
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
