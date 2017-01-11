Module Debug
    'Contains debug functions
    Public Function ExtractLevel(TimeStep As Long, Level As Long) As Long()
        'Extracts a level for debug visualization
        Dim R As Long()
        ReDim R(VRTM_SimVariables.nTrays - 1)
        For I = 0 To VRTM_SimVariables.nTrays - 1
            R(I) = Simulation_Results.VRTMTrayData(TimeStep, I, Level).TrayIndex
        Next
        Return R
    End Function
End Module
