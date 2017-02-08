Module SimVariables
    Public VRTM_SimVariables As New SimulationVariables
    Public Simulation_Results As New SimulationData
    Public FoodPropertiesList As New Collection
    Public CompressorList As New List(Of CompressorFileInfo)
    Public Ammonia As New AmmoniaProps

    <Serializable> Public Class SimulationVariables
        '============================
        '----Variables under tabs----
        '============================

        '----Variables under VRTM Params Tab----
        Public nTrays As Integer
        Public nLevels As Integer
        Public boxesPerTray As Integer

        Public fanFlowRate As Double
        Public fanPower As Double
        Public evapSurfArea As Double
        Public globalHX_Coeff As Double

        Public IdleHourBeginVRTM As Double 'Hour that the VRTM begins the idle time (fraction of day 0-1)
        Public IdleHourEndVRTM As Double 'Hour that the VRTM begins the idle time (fraction of day 0-1)
        Public IdleDaysVRTM() As Boolean 'Days that the VRTM will be idle at those hours

        '----Variables under Machine Room Tab----
        Public CompressorSetup As New List(Of CompressorData)
        Public CompromisedCap As Double '[kW]
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
        Public LevelChoosing As Integer '0=Production, 1=Demand, 2=Random
        Public DelayDemand As Boolean 'Whether it delays the demand algorithm so the TRVM can have enough product
        Public DelayDemandTime As Integer 'Delay time (in days) if DelayDemand is true
        Public StopIfDemandNotMet As Boolean 'Stops the simulation if demand not met (for debug). Otherwise, proceeds simulation and counts how much demand has actually not been met.
        Public EnableIdleReshelving As Boolean 'Enables the reshelving algorithm to kick in
        Public MinimumReshelvingWindow As Double 'Minimum window [h] that is needed for the reshelving algorithm to kick in
        Public EnableImprovedWeekendStrat As Boolean 'Enables a longer strategy that will ensure more product is available
        Public PickingOrders As Integer 'List of indices for the picking orders 0=Random Picking, 1=From File
        Public RandomBias As Boolean 'In random picking orders, enables the random bias towards a given product during a random time
        Public ExternalDemandProfilePath As String 'In "From File" picking orders, stores the file path of the product picking order


        '----Variables under Simulation Params Tab----
        Public TotalSimTime As Double 'Total simulation time in [s]
        Public MinimumSimDt As Double 'Minimum simulation delta-t in [s]

        Public ElevSpeed As Double 'Elevator speed [m/s]
        Public ElevAccel As Double 'Elevator working acceleration [m/s²]
        Public LevelCenterDist As Double 'Center distance between levels [mm]
        Public LoadLevel As Integer
        Public UnloadLevel As Integer
        Public ReturnLevel As Integer
        Public EmptyLevel As Integer
        Public TrayTransferTime As Double '[s]
        Public BoxLoadingTime As Double '[s]
        Public BoxUnloadingTime As Double '[s]
        Public UnloaderRetractionTime As Double '[s]

        Public AssumedDTForPreviews As Double 'This is the assumed Tevap-Tair for the preview window on the food selector

        '===========================================
        '----Data containers for each form opened---
        '===========================================
        Public FixedHeatLoadData As HeatLoadData 'Contains the fixed heat load data
        Public ProductMix() As ProductData 'Contains all the product data in the mix, listed in an array
        Public InletConveyors() As InletConveyor 'Contains the data for all conveyors in this VRTM

        '===================================
        '----Hidden simulation variables----
        '===================================
        'Public SimData As SimulationData

        '========================
        '----Subs and Methods----
        '========================
        Public Sub New()
            'Initializes the data so the system can begin working correctly (this is a blank VRTM)
            Me.nTrays = 8
            Me.nLevels = 28
            Me.boxesPerTray = 60

            Me.fanFlowRate = 600000
            Me.fanPower = 200
            Me.evapSurfArea = 15000
            Me.globalHX_Coeff = 22

            Me.IdleHourBeginVRTM = 18 / 24
            Me.IdleHourEndVRTM = 21 / 24
            Me.IdleDaysVRTM = {True, True, True, True, True, False, False}

            Dim Comp As New CompressorData
            Comp.SelectedCompressorIndex = 0
            Comp.CompressorType = CompressorSystemInterconnectionType.OneStageNoEco
            Comp.IntermediateT = 0
            Comp.VolumeDisplacement_m3rev = 0.002
            Comp.rpm = 3550
            Comp.VolumeDisplacement_m3h = Comp.VolumeDisplacement_m3rev * Comp.rpm * 60
            Comp.VolumeEfficiency = 0.89
            Comp.Qty = 1


            Me.CompressorSetup.Add(Comp)

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

            Me.LevelChoosing = 2
            Me.DelayDemand = True
            Me.DelayDemandTime = 2
            Me.EnableIdleReshelving = True
            Me.MinimumReshelvingWindow = 4
            Me.EnableImprovedWeekendStrat = True
            Me.PickingOrders = 0
            Me.RandomBias = True
            Me.ExternalDemandProfilePath = ""

            Me.TotalSimTime = 3600 * 24 * 7
            Me.MinimumSimDt = 50

            Me.ElevSpeed = 18.3 'Elevator speed [m/s]
            Me.ElevAccel = 0.61 'Elevator working acceleration [m/s²]
            Me.LevelCenterDist = 315
            Me.LoadLevel = 6
            Me.UnloadLevel = 3
            Me.ReturnLevel = 2
            Me.EmptyLevel = 14
            Me.TrayTransferTime = 3.2
            Me.BoxLoadingTime = 3.4
            Me.BoxUnloadingTime = 3.4
            Me.UnloaderRetractionTime = 1.7

            Me.AssumedDTForPreviews = 7



            'Initializes one product in the mix
            ReDim Me.ProductMix(2)
            Me.ProductMix(0) = New ProductData
            Me.ProductMix(0).ProdName = "Chicken"
            Me.ProductMix(0).BoxWeight = 20
            Me.ProductMix(0).AvgFlowRate = 1200
            Me.ProductMix(0).BoxRateStatisticalDistr = "Exponential"
            Me.ProductMix(0).BoxRateStdDev = 0
            Me.ProductMix(0).ConveyorNumber = 0

            Me.ProductMix(0).SimGeometry = "Thin Slab"
            Me.ProductMix(0).SimThickness = 120
            Me.ProductMix(0).SimLength = 600
            Me.ProductMix(0).SimWidth = 400
            Me.ProductMix(0).SimDiameter = 0

            Me.ProductMix(0).InletTemperature = 12
            Me.ProductMix(0).OutletTemperatureDesign = -18
            Me.ProductMix(0).MinimumStayTime = 24
            Me.ProductMix(0).AirSpeed = 4
            Me.ProductMix(0).ConvCoeffMultiplier = 1.0
            Me.ProductMix(0).ConvCoefficientUsed = 10
            Me.ProductMix(0).DeltaHSimulated = 262367 'Simulated already for this product

            Me.ProductMix(0).FoodThermalPropertiesModel = New FoodProperties()


            Me.ProductMix(1) = New ProductData
            Me.ProductMix(1).ProdName = "Pizza"
            Me.ProductMix(1).BoxWeight = 20
            Me.ProductMix(1).AvgFlowRate = 1200
            Me.ProductMix(1).BoxRateStatisticalDistr = "Exponential"
            Me.ProductMix(1).BoxRateStdDev = 0
            Me.ProductMix(1).ConveyorNumber = 1

            Me.ProductMix(1).SimGeometry = "Thin Slab"
            Me.ProductMix(1).SimThickness = 120
            Me.ProductMix(1).SimLength = 600
            Me.ProductMix(1).SimWidth = 400
            Me.ProductMix(1).SimDiameter = 0

            Me.ProductMix(1).InletTemperature = 12
            Me.ProductMix(1).OutletTemperatureDesign = -18
            Me.ProductMix(1).MinimumStayTime = 24
            Me.ProductMix(1).AirSpeed = 4
            Me.ProductMix(1).ConvCoeffMultiplier = 1.0
            Me.ProductMix(1).ConvCoefficientUsed = 10
            Me.ProductMix(1).DeltaHSimulated = 262367 'Simulated already for this product

            Me.ProductMix(1).FoodThermalPropertiesModel = New FoodProperties()


            Me.ProductMix(2) = New ProductData
            Me.ProductMix(2).ProdName = "Butter"
            Me.ProductMix(2).BoxWeight = 20
            Me.ProductMix(2).AvgFlowRate = 1200
            Me.ProductMix(2).BoxRateStatisticalDistr = "Exponential"
            Me.ProductMix(2).BoxRateStdDev = 0
            Me.ProductMix(2).ConveyorNumber = 1

            Me.ProductMix(2).SimGeometry = "Thin Slab"
            Me.ProductMix(2).SimThickness = 120
            Me.ProductMix(2).SimLength = 600
            Me.ProductMix(2).SimWidth = 400
            Me.ProductMix(2).SimDiameter = 0

            Me.ProductMix(2).InletTemperature = 12
            Me.ProductMix(2).OutletTemperatureDesign = -18
            Me.ProductMix(2).MinimumStayTime = 24
            Me.ProductMix(2).AirSpeed = 4
            Me.ProductMix(2).ConvCoeffMultiplier = 1.0
            Me.ProductMix(2).ConvCoefficientUsed = 10
            Me.ProductMix(2).DeltaHSimulated = 262367 'Simulated already for this product

            Me.ProductMix(2).FoodThermalPropertiesModel = New FoodProperties()

            'Initializes the conveyors
            ReDim Me.InletConveyors(1)
            Me.InletConveyors(0) = New InletConveyor
            Me.InletConveyors(0).ConveyorTag = "Chicken Only"
            Me.InletConveyors(0).MinRetTime = 24

            Me.InletConveyors(1) = New InletConveyor
            Me.InletConveyors(1).ConveyorTag = "Pizza and Butter"
            Me.InletConveyors(1).MinRetTime = 36

            'Initializes the heat load data
            Me.FixedHeatLoadData = New HeatLoadData
            Me.FixedHeatLoadData.Height = 15000
            Me.FixedHeatLoadData.Width = 12000
            Me.FixedHeatLoadData.Length = 30000
            Me.FixedHeatLoadData.OutsideT = 35
            Me.FixedHeatLoadData.WallMaterialIdx = 0
            Me.FixedHeatLoadData.WallThickness = 150

            Me.FixedHeatLoadData.MotorPower = 50
            Me.FixedHeatLoadData.MotorHours = 16
            Me.FixedHeatLoadData.IllumPowerArea = 15
            Me.FixedHeatLoadData.IllumHours = 16
            Me.FixedHeatLoadData.DailyVolumeChange = 1

            Me.FixedHeatLoadData.ConductionPower = 0
            Me.FixedHeatLoadData.EquipPower = 0
            Me.FixedHeatLoadData.InfiltrPower = 0

            Me.FixedHeatLoadData.FixedHL = 50

        End Sub
    End Class

    <Serializable> Public Class ProductData
        'This class models one product dataset for mix selection
        Public ProdName As String
        Public BoxWeight As Double 'kg
        Public AvgFlowRate As Double 'In boxes/h
        Public BoxRateStatisticalDistr As String 'Exponential, Gaussian, etc
        Public BoxRateStdDev As Double 'boxes/h
        Public ConveyorNumber As Long 'Number of the conveyor this product will be received at

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

        Public DeltaHSimulated As Double 'J/kg

    End Class

    <Serializable> Public Class FoodPropertiesListItem
        'This models one item of a Food Properties List
        Public ProductName As String
        Public WaterContent As Double '0-1 value
        Public ProteinContent As Double '0-1 value
        Public FatContent As Double '0-1 value
        Public CarbContent As Double '0-1 value
        Public AshContent As Double '0-1 value
        Public FreezingTemp As Double 'ºC
    End Class

    <Serializable> Public Class HeatLoadData
        'Models the Fixed HL Data in the form
        Public Height As Double 'Tunnel room height in mm
        Public Width As Double 'Tunnel room width in mm
        Public Length As Double 'Tunnel room length in mm
        Public OutsideT As Double 'Outside temperature in ºC
        Public WallMaterialIdx As Integer 'Materials available: 0=PUR, 1=EPS
        Public WallThickness As Double 'Wall thickness in mm

        Public MotorPower As Double 'Motor without fans kW
        Public MotorHours As Double 'Motor hours per day
        Public IllumPowerArea As Double 'Illumination  W/m²
        Public IllumHours As Double 'Illumination hours per day
        Public DailyVolumeChange As Double 'Number of changes in the air volume

        Public ConductionPower As Double 'kW
        Public EquipPower As Double 'kW
        Public InfiltrPower As Double 'kW

        Public FixedHL As Double 'kW
    End Class

#Region "CSV Load"
    Public Sub LoadFoodPropertiesCSVIntoMemory()
        Try
            Dim ThisFolderPath As String = System.IO.Path.Combine(Environment.CurrentDirectory, "Food Properties.csv")
            If System.IO.File.Exists(ThisFolderPath) Then
                My.Settings.FoodProductCSVPath = ThisFolderPath
                My.Settings.Save()
            End If
            If Not System.IO.File.Exists(My.Settings.FoodProductCSVPath) Then
TryAgain:
                Dim fDiag As New System.Windows.Forms.OpenFileDialog
                fDiag.Title = "Select a CSV file for the food properties table"
                fDiag.Filter = "CSV Files|*.csv"
                fDiag.ShowDialog()
                If Not System.IO.File.Exists(fDiag.FileName) Then
                    MsgBox("Invalid file. Shutting down.")
                Else
                    My.Settings.FoodProductCSVPath = fDiag.FileName
                End If
            End If

            FoodPropertiesList.Clear()
            Try
                Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(My.Settings.FoodProductCSVPath, System.Text.Encoding.GetEncoding("Windows-1252"))
                    Reader.TextFieldType = FileIO.FieldType.Delimited
                    Reader.SetDelimiters({";"})

                    Dim currentRow As String()
                    Dim firstLine As Boolean = True
                    'Reads data from file
                    While Not Reader.EndOfData
                        currentRow = Reader.ReadFields()
                        If Not firstLine Then
                            If UBound(currentRow) = 6 Then
                                Dim TempFood As New FoodPropertiesListItem
                                With TempFood
                                    .ProductName = currentRow(0)
                                    .WaterContent = Double.Parse(currentRow(1).Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                                    .ProteinContent = Double.Parse(currentRow(2).Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                                    .FatContent = Double.Parse(currentRow(3).Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                                    .CarbContent = Double.Parse(currentRow(4).Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                                    .AshContent = Double.Parse(currentRow(5).Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                                    .FreezingTemp = Double.Parse(currentRow(6).Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)

                                    If ((TempFood.WaterContent + TempFood.ProteinContent + TempFood.FatContent + TempFood.CarbContent + TempFood.AshContent) - 1) < 0.00001 Then 'Allow for double imprecision
                                        FoodPropertiesList.Add(TempFood)
                                    End If
                                End With
                            Else
                                Throw New Exception("CSV File Format incorrect for food properties (should be exactly 7 columns)")
                            End If
                        Else
                            firstLine = False
                        End If
                    End While
                End Using
            Catch ex As Exception
                If MsgBox("Problem trying to read this file. Do you want to open another file?", vbYesNo + vbCritical, "Error") = vbYes Then
                    GoTo TryAgain
                End If
            End Try


        Catch ex As Exception
            MsgBox("Error whilst trying to find a food product properties model. Shutting down.")
            Application.Exit()
        End Try
    End Sub

    Public Sub LoadCompressorCSV()
        Try
            Dim ThisFolderPath As String = System.IO.Path.Combine(Environment.CurrentDirectory, "Compressors.csv")
            If System.IO.File.Exists(ThisFolderPath) Then
                My.Settings.CompressorCSV = ThisFolderPath
                My.Settings.Save()
            End If
            If Not System.IO.File.Exists(My.Settings.CompressorCSV) Then
TryAgain:
                Dim fDiag As New System.Windows.Forms.OpenFileDialog
                fDiag.Title = "Select a CSV file for the compressor data table"
                fDiag.Filter = "CSV Files|*.csv"
                fDiag.ShowDialog()
                If Not System.IO.File.Exists(fDiag.FileName) Then
                    MsgBox("Invalid file. Shutting down.")
                Else
                    My.Settings.CompressorCSV = fDiag.FileName
                End If
            End If

            CompressorList.Clear()
            Try
                Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(My.Settings.CompressorCSV, System.Text.Encoding.GetEncoding("Windows-1252"))
                    Reader.TextFieldType = FileIO.FieldType.Delimited
                    Reader.SetDelimiters({";"})

                    Dim currentRow As String()
                    Dim firstLine As Boolean = True
                    'Reads data from file
                    While Not Reader.EndOfData
                        currentRow = Reader.ReadFields()
                        If Not firstLine Then
                            If UBound(currentRow) = 1 Then
                                Dim TempCompressor As New CompressorFileInfo
                                With TempCompressor
                                    .CompressorName = currentRow(0)
                                    .VolumeDisplacement = Double.Parse(currentRow(1).Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)

                                    If .VolumeDisplacement > 0 Then 'Incorrect volume displacement
                                        CompressorList.Add(TempCompressor)
                                    End If
                                End With
                            Else
                                Throw New Exception("CSV File Format incorrect for a compressor table (should be exactly 2 columns)")
                            End If
                        Else
                            firstLine = False
                        End If
                    End While
                End Using
            Catch ex As Exception
                If MsgBox("Problem trying to read this file. Do you want to open another file?", vbYesNo + vbCritical, "Error") = vbYes Then
                    GoTo TryAgain
                End If
            End Try


        Catch ex As Exception
            MsgBox("Error whilst trying to find a compressor properties list. Shutting down.")
            Application.Exit()
        End Try
    End Sub

#End Region


    <Serializable> Public Class SimulationData
        'This class will contain all the variables in the process simulation data (variables of the process simulation)
        Public VRTMTrayData(,,) As TrayData   'ARRAY OF TRAY DATA IN THE FORMAT of timestep, Tray no, Level no
        Public VRTMTimePositions() As Double 'This array links the TrayEntryPositions with VRTMTrayData through the time array. VRTMTimePositions(TimeStep)=Time
        Public TrayEntryPositions() As Long 'This array contains the "timesteps" where the given tray indices entered the TRVM.
        Public TrayEntryTimes() As Double 'Array of simulation entry time indices for each tray index mentioned in TRVMTrayIndices
        Public TrayExitTimes() As Double 'Array of simulation exit time indices for each tray index mentioned in TRVMTrayIndices
        Public TrayStayTime() As Double 'Array of stay times for each tray
        'Public TrayAirTemperatures() As Double 'Air temperatures on the trays
        Public TrayEntryLevels() As Integer 'Array of levels where each tray was entering onto for the tray index mentioned in TRVMTrayIndices
        Public Elevator() As TrayData 'Representation of the tray in the elevator, array in timesteps
        Public EmptyElevatorB() As Boolean 'Number of the elevator that is empty (FALSE = left [A], TRUE = right [B])
        Public AirTemperatures(,) As Double 'Stores the air temperatures inside the tunnel. AirTemperatures(TimeStep, Tray position)=Air Temperature
        Public EvaporatorTemperatures() As Double 'Stores the evaporator temperatures each time step

        Public TotalPower() As Double 'Total Power integralized in [W] for each time step

        Public SimulationComplete As Boolean = False
    End Class

    <Serializable> Public Class TrayData
        'This class contains the data of a tray after simulation has been processed
        Public TrayIndex As Long ' Sequential tray index (Starts at 1)
        Public ConveyorIndex As Long ' Conveyor index
        Public ProductIndices As Dictionary(Of Long, Long) 'Key=Product index in the array of ProductMix() [In other words, the SKU]. Value=Quantity of boxes
        Public SurfTemperature As Double 'Surface temperature of the product after thermal sim [ºC]
        Public CenterTemperature As Double 'Center temperature of the product after thermal sim [ºC]
        Public TrayPower As Double 'Heat power released in the current timestep after thermal sim [W]

        Public Function Clone() As TrayData
            Return DirectCast(Me.MemberwiseClone(), TrayData)
        End Function

    End Class

    <Serializable> Public Class InletConveyor
        'Defines the properties of a conveyor that are important
        Public ConveyorTag As String
        Public MinRetTime As Double 'hours
    End Class

    <Serializable> Public Class CompressorData
        'Implements the compressor data for a single compressor
        Public SelectedCompressorIndex As Long
        Public Qty As Long
        Public VolumeDisplacement_m3rev As Double 'm³/rev
        Public rpm As Double 'rpm
        Public VolumeDisplacement_m3h As Double 'm³/h

        Public VolumeEfficiency As Double
        Public CompressorType As CompressorSystemInterconnectionType
        Public IntermediateT As Double
    End Class

    <Serializable> Public Class CompressorFileInfo
        'Implements the compressor data for a single compressor in a file
        Public CompressorName As String
        Public VolumeDisplacement As Double 'm³/rev
    End Class

    <Serializable> Public Enum CompressorSystemInterconnectionType
        OneStageNoEco = 0
        OneStageEco = 1
        TwoStage = 2
    End Enum

End Module

