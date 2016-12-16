Module A_Star
    'This module contains the functions needed to solve the "puzzle" of reorganizing the VRTM shelves

    Public Function Solve_A_Star_Search(CurrentState As VRTMState, GoalState As VRTMState) As Long()
        'This will solve the a star algorithm for the current VRTM state
        Dim Fringe As List(Of VRTMState)
        Dim GoalTest As Boolean = False

        Dim S As New VRTMState(20, 20, 1, -2, 12)
        S = S.Perform_Operation(2)

        Do Until GoalTest

        Loop

    End Function


    Public Class VRTMState
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
                Dim NewState As VRTMState = Me
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
                        NewState.ConveyorIndexArray(I, Operation) = NewState.ConveyorIndexArray(I + 1, Operation)
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
            Dim ConvIndices(,) As Long = Me.ConveyorIndexArray

            Dim IMax As Long = UBound(GoalState.ConveyorIndexArray, 1)
            Dim JMax As Long = UBound(GoalState.ConveyorIndexArray, 2)

            If (IMax <> UBound(Me.ConveyorIndexArray, 1)) Or (JMax <> UBound(Me.ConveyorIndexArray, 2)) Then Return Nothing

            Dim RadiusList As New SortedDictionary(Of Double, PointLong)
            Dim dI, dJ As Long

            For I As Long = 0 To IMax
                For J As Long = 0 To JMax
                    'Enumerates all the radii and then tries radially outwards
                    RadiusList.Clear()
                    For I1 As Long = 0 To IMax
                        For J1 As Long = 0 To JMax
                            dI = I1 - I
                            dJ = J1 - J
                            RadiusList.Add(Math.Sqrt(dI * dI + dJ * dJ), New PointLong(I1, J1)) 'MUST SOLVE THE DUPLICATE PROBLEM NOT ALLOWED IN DICTIONARIES
                        Next
                    Next

                    For Each R As Double In RadiusList.Keys

                    Next
                Next
            Next

        End Function

    End Class

    Public Class PointLong
        Public T As Long
        Public L As Long

        Public Sub New(I, J)
            T = I
            L = J
        End Sub
    End Class

End Module
