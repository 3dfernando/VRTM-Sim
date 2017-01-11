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
            Return DirectCast(Me.MemberwiseClone(), VRTMStateSimplified)
        End Function
    End Class

    Public Function DefineOrganizationMovements(currentSimulationTimeStep As Long, AvailableTime As Double, CurrentTime As Double) As List(Of Long)
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

                CurrentState.TrayState(I, J).ConveyorIndex = Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I, J).ConveyorIndex 'Defines the product index
                StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.VRTMTrayData(currentSimulationTimeStep, I, J).TrayIndex)

                CurrentState.TrayState(I, J).Frozen = StayTime >= (VRTM_SimVariables.InletConveyors(CurrentState.TrayState(I, J).ConveyorIndex).MinRetTime * 3600) 'Whether the product will be frozen by the end of the organization
            Next
        Next


        Dim Movements As New List(Of Long)

        For I = 1 To 100
            Movements.Add(Int(Rnd(VRTM_SimVariables.nLevels)))
        Next

        Return Movements

    End Function

    Public Function PerformMovement(State As VRTMStateSimplified, Level As Long) As VRTMStateSimplified
        'Performs a given movement in the elevator at the given level and returns a new, cloned state
        PerformMovement = New VRTMStateSimplified
        ReDim PerformMovement.TrayState(VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.nLevels - 1)

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
            For I = 1 To VRTM_SimVariables.nTrays - 1
                PerformMovement.TrayState(I - 1, Level) = State.TrayState(I, Level).Clone
            Next
            PerformMovement.TrayState(VRTM_SimVariables.nTrays - 1, Level) = State.ElevatorState.Clone

            PerformMovement.ElevatorState = State.TrayState(0, Level).Clone

            PerformMovement.EmptyElevatorB = True
        End If
    End Function



End Module
