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

        '===========================================
        '----Data containers for each form opened---
        '===========================================
        Public ProductMix() As ProductData 'Contains all the product data in the mix, listed in an array


        '===================================
        '----Hidden simulation variables----
        '===================================


        '========================
        '----Subs and Methods----
        '========================
        Public Sub New()
            'Initializes the data so the system can begin working correctly (this is a blank VRTM)
            Me.nTrays = 8
            Me.nLevels = 28
            Me.boxesPerTray = 60

            Me.fanFlowRate = 600000
            Me.evapSurfArea = 15000
            Me.globalHX_Coeff = 22

            Me.IdleHourBeginVRTM = 18 / 24
            Me.IdleHourEndVRTM = 21 / 24
            Me.IdleDaysVRTM = {True, True, True, True, True, False, False}

            Me.Tevap_Setpoint = -35
            Me.Tcond = 35

            Me.IdleHourBeginMRoom = 18 / 24
            Me.IdleHourEndMRoom = 21 / 24
            Me.IdleDaysMRoom = {True, True, True, True, True, False, False}

            Me.SafetyFactorVRTM = 1.15

            Me.FirstProductionTurnEnabled = True
            Me.SecondProductionTurnEnabled = True
            Me.FirstTurnBegin = 6 / 24
            Me.FirstTurnEnd = 14 / 24
            Me.SecondTurnBegin = 16 / 24
            Me.SecondTurnEnd = 0
            Me.ProductionDays = {True, True, True, True, True, False, False}

            Me.TotalSimTime = 3600 * 24 * 7
            Me.MinimumSimDt = 300

            'Initializes one product in the mix
            ReDim Me.ProductMix(0)
            Me.ProductMix(0) = New ProductData
            Me.ProductMix(0).ProdName = "Chicken"
            Me.ProductMix(0).BoxWeight = 20
            Me.ProductMix(0).AvgFlowRate = 1200
            Me.ProductMix(0).BoxRateStatisticalDistr = "Exponential"
            Me.ProductMix(0).BoxRateStdDev = 0

            Me.ProductMix(0).SimGeometry = "Thin Slab"
            Me.ProductMix(0).SimThickness = 120
            Me.ProductMix(0).SimLength = 600
            Me.ProductMix(0).SimWidth = 400
            Me.ProductMix(0).SimDiameter = 0

            Me.ProductMix(0).InletTemperature = 12
            Me.ProductMix(0).OutletTemperatureDesign = -18
            Me.ProductMix(0).FoodThermalPropertiesModel = New FoodProperties()
            Me.ProductMix(0).MinimumStayTime = 24
            Me.ProductMix(0).AirSpeed = 4
            Me.ProductMix(0).ConvCoeffMultiplier = 1.1
            Me.ProductMix(0).ConvCoefficientUsed = 10
        End Sub


    End Class

    Public Class ProductData
        'This class models one product dataset for mix selection
        Public ProdName As String
        Public BoxWeight As Double 'kg
        Public AvgFlowRate As Double 'In boxes/h
        Public BoxRateStatisticalDistr As String 'Exponential, Gaussian, etc
        Public BoxRateStdDev As Double 'boxes/h

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
