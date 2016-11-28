Module SimVariables
    Public VRTM_SimVariables As New SimulationVariables

    Public Class SimulationVariables
        Public nTrays As Integer
        Public nLevels As Integer
        Public boxesPerTray As Integer
        Public staticCapacity As Long

        Public fanFlowRate As Double
        Public evapSurfArea As Double
        Public globalHX_Coeff As Double

    End Class
End Module
