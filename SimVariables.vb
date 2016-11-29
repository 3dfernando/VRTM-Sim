Module SimVariables
    Public VRTM_SimVariables As New SimulationVariables

    Public Class SimulationVariables
        '============================
        '----Variables under tabs----
        '============================

        '----Variables under VRTM Params Tab----
        Public nTrays As Integer
        Public nLevels As Integer
        Public boxesPerTray As Integer
        Public staticCapacity As Long

        Public fanFlowRate As Double
        Public evapSurfArea As Double
        Public globalHX_Coeff As Double

        Public IdleHourBeginVRTM As Double 'Hour that the VRTM begins the idle time (fraction of day 0-1)
        Public IdleHourEndVRTM As Double 'Hour that the VRTM begins the idle time (fraction of day 0-1)
        Public IdleDaysVRTM() As Boolean 'Days that the VRTM will be idle at those hours

        '----Variables under Machine Room Tab----
        Public Tevap_Setpoint As Double
        Public Tcond As Double

        Public IdleHourBeginMRoom As Double 'Hour that the Machine Room begins the idle time (fraction of day 0-1)
        Public IdleHourEndMRoom As Double 'Hour that the Machine Room begins the idle time (fraction of day 0-1)
        Public IdleDaysMRoom() As Boolean 'Days that the Machine Room will be idle at those hours

        '----Variables under Production Tab----
        Public SafetyFactorVRTM As Double 'Multiplies the heat load of the VRTM by this factor

        Public FirstProductionTurnEnabled As Boolean
        Public SecondProductionTurnEnabled As Boolean
        Public FirstTurnBegin As Double '(fraction of day 0-1)
        Public FirstTurnEnd As Double '(fraction of day 0-1)
        Public SecondTurnBegin As Double '(fraction of day 0-1)
        Public SecondTurnEnd As Double '(fraction of day 0-1)
        Public ProductionDays() As Boolean 'Days that the VRTM will be producing

        '----Variables under Demand Tab----

        '----Variables under Simulation Params Tab----
        Public TotalSimTime As Double 'Total simulation time in [s]
        Public MinimumSimDt As Double 'Minimum simulation delta-t in [s]

        '===================================
        '----Hidden simulation variables----
        '===================================

    End Class

    Public Class ProductData
        'This class models one product dataset for mix selection
        Public ProdName As String
        Public BoxWeight As Double
        Public AvgFlowRate As Double 'In boxes/h
        Public BoxRateStatisticalDistr As String 'Exponential, Gaussian, etc

        Public SimGeometry As String
        Public SimThickness As Double 'mm
        Public SimLength As Double 'mm
        Public SimWidth As Double 'mm
        Public SimDiameter As Double 'mm

        Public InletTemperature As Double 'ºC
        Public OutletTemperatureDesign As Double  'ºC
        Public FoodThermalPropertiesModel As FoodProperties 'Food properties model
        Public MinimumStayTime As Double 'h
        Public AirSpeed As Double 'm/s
        Public ConvCoeffMultiplier As Double '[-]
        Public ConvCoefficientUsed As Double 'W/m².K

    End Class
End Module
