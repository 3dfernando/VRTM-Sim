Module Debug
    'Contains debug functions
    Public Function ExtractLevel(State As VRTMStateSimplified, Level As Long) As Long()
        'Extracts a level for debug visualization
        Dim R As Long()
        ReDim R(VRTM_SimVariables.nTrays - 1)
        For I = 0 To VRTM_SimVariables.nTrays - 1
            R(I) = State.TrayState(I, Level).ConveyorIndex
        Next
        Return R
    End Function
End Module
