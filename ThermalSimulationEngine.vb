Module ThermalSimulationEngine
    Public VentilationMultiplier As Double = 1
    Public Const Low_Pass_T_Constant_Compressor As Double = 1800 'Time constant of the low pass filter (to prevent the machine room from oscillating)
    Public Const Low_Pass_T_Constant_Evaporator As Double = 1800 'Time constant of the low pass filter (to prevent the evaporator from oscillating)

    Public Sub RunThermalSimulation()
        'This sub will review the current process simulation data and will run a thermal simulation.
        Dim I, J, TimeStep As Long
        Dim CurrentIndex As Long
        Dim Delta_Time As Double
        Dim PowerColumn As Double 'Stores the power of the current time step in the current tray column position
        Dim TotalPower As Double
        Dim PowerFansFixed As Double 'Power in W of fans and others
        Dim Air_T_Evaporator, T_inlet_evap, NTU, epsilon, epsilon_low, C_min As Double
        Dim VentilationOn As Boolean
        Dim Target_TE As Double 'Target evaporator temperature C
        Dim Target_TAir As Double 'Target air temperature C

        'Begins counting sim time
        Dim Watch As New Stopwatch
        Watch.Start()

        Const ThermalSimulationMethod As Long = 0 '[0=DT Heat balance method], [1=Surface convection method]

        'Inits a thermal data array
        Dim TrayThermalInformation() As TrayThermalData
        ReDim TrayThermalInformation(Simulation_Results.VRTMTimePositions.Count - 1)

        ReDim Simulation_Results.TotalPower(Simulation_Results.VRTMTimePositions.Count - 1) 'Inits the total power array
        ReDim Simulation_Results.AirTemperatures(Simulation_Results.VRTMTimePositions.Count - 1,
                                                 VRTM_SimVariables.nTrays - 1) 'Inits the air temperature array
        ReDim Simulation_Results.EvaporatorTemperatures(Simulation_Results.VRTMTimePositions.Count - 1) 'Inits the evaporator temperatures array

        'Makes sure the thermal property models are initialized
        For Each P As ProductData In VRTM_SimVariables.ProductMix
            P.FoodThermalPropertiesModel.Initialize()
        Next

        'Inits the air temperatures with the evaporator T
        For I = 0 To VRTM_SimVariables.nTrays - 1
            Simulation_Results.AirTemperatures(0, I) = VRTM_SimVariables.Tevap_Setpoint
        Next

        'Inits the evaporator
        C_min = ((VRTM_SimVariables.fanFlowRate / 3600) * 1.44 * 1005) 'Air flow heat capacity, [W/K]
        NTU = (VRTM_SimVariables.globalHX_Coeff * VRTM_SimVariables.evapSurfArea) / C_min
        epsilon = 1 - Math.Exp(-NTU)

        PowerFansFixed = 1000 * ((VRTM_SimVariables.FixedHeatLoadData.FixedHL + VRTM_SimVariables.fanPower)) * VRTM_SimVariables.SafetyFactorVRTM

        'Begins the main sim loop
        For TimeStep = 0 To Simulation_Results.VRTMTimePositions.Count - 1

            If TimeStep Mod 100 Then
                'Updates the progress
                MainWindow.MainForm.Text = "VRTM Simulator V1.0 - Thermal Simulation Progress: " &
                    Trim(Str(Round(TimeStep * 100 / (Simulation_Results.VRTMTimePositions.Count - 1), 1))) & " %..."
            End If

            TotalPower = 0 'Inits the power for this t_step
            If TimeStep > 0 Then Delta_Time = Simulation_Results.VRTMTimePositions(TimeStep) - Simulation_Results.VRTMTimePositions(TimeStep - 1)

            VentilationOn = IsVentilationTurnedOn(Simulation_Results.VRTMTimePositions(TimeStep)) 'Indicates whether the fans are turned on
            If VentilationOn Then
                VentilationMultiplier = 1
            Else
                VentilationMultiplier = 0.01
            End If


            If TimeStep > 0 Then
                'Calculates the machine room
                Target_TE = MachineRoom.Get_Evaporating_Temperature(Simulation_Results.TotalPower(TimeStep - 1) / 1000) 'power in kW
                If Target_TE < VRTM_SimVariables.Tevap_Setpoint Then Target_TE = VRTM_SimVariables.Tevap_Setpoint

                Simulation_Results.EvaporatorTemperatures(TimeStep) = (Delta_Time / Low_Pass_T_Constant_Compressor) *
                                                    (Target_TE - Simulation_Results.EvaporatorTemperatures(TimeStep - 1)) +
                                                    Simulation_Results.EvaporatorTemperatures(TimeStep - 1)


                'Calculates the evaporator (e-NTU method)
                If VentilationOn Then
                    T_inlet_evap = Simulation_Results.AirTemperatures(TimeStep, VRTM_SimVariables.nTrays - 1) + PowerFansFixed / C_min 'ºC
                    Target_TAir = T_inlet_evap - epsilon *
                    (T_inlet_evap - Simulation_Results.EvaporatorTemperatures(TimeStep)) 'ºC
                Else
                    Target_TAir = VRTM_SimVariables.Tevap_Setpoint 'ºC
                End If
                If Target_TAir < Simulation_Results.EvaporatorTemperatures(TimeStep) Then _
                    Target_TAir = Simulation_Results.EvaporatorTemperatures(TimeStep) 'Prevent the outlet temperature from dropping too much

                Air_T_Evaporator = (Math.Min(Delta_Time / Low_Pass_T_Constant_Evaporator, 1)) *
                                                    (Target_TAir - Air_T_Evaporator) + Air_T_Evaporator


            Else
                Air_T_Evaporator = VRTM_SimVariables.Tevap_Setpoint
                Simulation_Results.EvaporatorTemperatures(0) = VRTM_SimVariables.Tevap_Setpoint 'Inits the machine room
            End If


            For I = 0 To VRTM_SimVariables.nTrays - 1

                PowerColumn = 0 'Inits the power in the current tray position
                'Runs the thermal sim on all the levels in the tunnel
                For J = 0 To VRTM_SimVariables.nLevels - 1
                    CurrentIndex = Simulation_Results.VRTMTrayData(TimeStep, I, J).TrayIndex 'Gets the current tray index


                    If CurrentIndex > 0 Then
                        If IsNothing(TrayThermalInformation(CurrentIndex)) Then
                            'We know there is a tray over here, but it's not been looked into until now. Inits it, then.
                            TrayThermalInformation(CurrentIndex) = New TrayThermalData
                            TrayThermalInformation(CurrentIndex).CurrentTimestep = TimeStep
                            TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds = GenerateProductTemperatureProfile(Simulation_Results.VRTMTrayData(TimeStep, I, J))
                            TrayThermalInformation(CurrentIndex).PastTProfs_AllProds = Nothing

                        Else
                            'The tray has already been initialized, so it needs to update it for the current time step.
                            TrayThermalInformation(CurrentIndex).CurrentTimestep = TimeStep
                            TrayThermalInformation(CurrentIndex).PastTProfs_AllProds = New Dictionary(Of Long, TProfile)(TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds)

                            TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds =
                                                GenerateNextTemperatureProfile(Simulation_Results.VRTMTrayData(TimeStep, I, J),
                                                TrayThermalInformation(CurrentIndex).PastTProfs_AllProds, Delta_Time,
                                                Simulation_Results.AirTemperatures(TimeStep, I), VentilationOn)
                        End If


                        'Updates the temperatures on the sim data array
                        Dim MaxTSurf As Double = Double.MinValue
                        Dim MaxTCenter As Double = Double.MinValue
                        For Each P As KeyValuePair(Of Long, TProfile) In TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds
                            If MaxTCenter < P.Value.TemperatureProfile(0) Then MaxTCenter = P.Value.TemperatureProfile(0)
                            If MaxTSurf < P.Value.TemperatureProfile(ProductMixSetup.nx - 1) Then MaxTSurf = P.Value.TemperatureProfile(ProductMixSetup.nx - 1)
                        Next


                        Simulation_Results.VRTMTrayData(TimeStep, I, J).CenterTemperature = MaxTCenter
                        Simulation_Results.VRTMTrayData(TimeStep, I, J).SurfTemperature = MaxTSurf

                        'Updates the power dissipated in the data array.
                        Dim ProdMassEach As Double
                        Dim ProdQty As Double
                        Dim ProdCp As Double

                        Dim dm, dH, dQ, Q As Double
                        Dim T1, T2, CurrDT As Double
                        Dim A, h, rhoL As Double

                        Dim Power As Double

                        If Not (IsNothing(TrayThermalInformation(CurrentIndex).PastTProfs_AllProds) _
                            Or IsNothing(TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds)) Then 'There must be data to work with

                            Q = 0
                            For Each Product As KeyValuePair(Of Long, TProfile) In TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds 'Key=prod index, value=Tprof
                                ProdMassEach = VRTM_SimVariables.ProductMix(Product.Key).BoxWeight
                                ProdQty = Simulation_Results.VRTMTrayData(TimeStep, I, J).ProductIndices(Product.Key)

                                If ThermalSimulationMethod = 0 Then
                                    '{{{{{{{{ DELTA-ENTHALPY METHOD }}}}}}}
                                    dm = (ProdQty * ProdMassEach) / ProductMixSetup.nx 'mass element [kg]

                                    For N As Long = 0 To ProductMixSetup.nx - 1

                                        T1 = TrayThermalInformation(CurrentIndex).PastTProfs_AllProds(Product.Key).TemperatureProfile(N)
                                        T2 = TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds(Product.Key).TemperatureProfile(N)
                                        'CurrDT = T1 - T2

                                        'ProdCp = VRTM_SimVariables.ProductMix(Product.Key).FoodThermalPropertiesModel.get_cp((T1 + T2) / 2)

                                        dH = VRTM_SimVariables.ProductMix(Product.Key).FoodThermalPropertiesModel.get_H(T1) -
                                            VRTM_SimVariables.ProductMix(Product.Key).FoodThermalPropertiesModel.get_H(T2)

                                        dQ = dm * dH 'Heat exchanged in the timestep for the current mass element [J]

                                        If dQ < 0 Then
                                            'That's not quite probable...
                                            dQ = 0
                                        End If

                                        Q += dQ 'Total heat exchanged [integral], across all products
                                    Next

                                ElseIf ThermalSimulationMethod = 1 Then
                                    '{{{{{{{{ SURFACE CONVECTION METHOD }}}}}}}
                                    h = VRTM_SimVariables.ProductMix(Product.Key).ConvCoefficientUsed '[W/m².K]
                                    rhoL = VRTM_SimVariables.ProductMix(Product.Key).FoodThermalPropertiesModel.get_rho(VRTM_SimVariables.ProductMix(Product.Key).InletTemperature) *
                                        VRTM_SimVariables.ProductMix(Product.Key).SimThickness / 1000 '[kg/m²]
                                    A = 2 * ProdMassEach * ProdQty / rhoL '[m²], both faces
                                    T1 = TrayThermalInformation(CurrentIndex).PastTProfs_AllProds(Product.Key).TemperatureProfile(ProductMixSetup.nx - 1) 'Surf T, [C]
                                    T2 = -35 'Fluid T, [C]
                                    CurrDT = T1 - T2
                                    'If CurrDT < 0 Then
                                    '    'That's not quite probable...
                                    '    Dim aseuhasueasue As Long = 0
                                    'End If

                                    dQ = h * A * CurrDT

                                    Q += dQ 'Total heat exchanged [integral], across all products
                                End If
                            Next

                            If ThermalSimulationMethod = 0 Then 'Safety factor included here
                                Power = VRTM_SimVariables.SafetyFactorVRTM * (Q / Delta_Time) 'Power for the DT method is Q/dt
                                If Power > 100000 Then
                                    Dim hehe As String = "hehe"
                                End If
                            ElseIf ThermalSimulationMethod = 1 Then
                                Power = VRTM_SimVariables.SafetyFactorVRTM * (Q) 'Power for the Surf Convection method is Q already
                            End If
                            If Not VentilationOn Then Power = 0

                        Else
                            Power = 0
                        End If

                        Simulation_Results.VRTMTrayData(TimeStep, I, J).TrayPower = Power
                        TotalPower += Power
                        PowerColumn += Power
                    End If

                Next

                'Updates the next air temperature profile
                If TimeStep < Simulation_Results.VRTMTimePositions.Count - 1 Then
                    If I = 0 Then
                        'First tray
                        Simulation_Results.AirTemperatures(TimeStep + 1, I) = Air_T_Evaporator + (PowerColumn / C_min) 'ºC
                    Else
                        Simulation_Results.AirTemperatures(TimeStep + 1, I) = Simulation_Results.AirTemperatures(TimeStep + 1, I - 1) + (PowerColumn / C_min) 'ºC
                    End If
                End If
            Next

            If VentilationOn Then
                Simulation_Results.TotalPower(TimeStep) = TotalPower + PowerFansFixed 'Updates total power in [W]
            Else
                Simulation_Results.TotalPower(TimeStep) = TotalPower 'Updates total power in [W]
            End If
        Next
        Watch.Stop()

        MainWindow.MainForm.Text = "VRTM Simulator V1.0"
        MainWindow.MainForm.LoadTotalHeatLoadGraph()
        MainWindow.MainForm.LoadTemperatureProfileGraph()
        MainWindow.MainForm.LoadTemperaturePercentileGraph()
        MainWindow.MainForm.GraphicalSummaryTab.SelectedTab = MainWindow.MainForm.tabHeatLoad
        MainWindow.MainForm.UpdateSimTotalsList()
        MainWindow.MainForm.SimStats.SelectedTab = MainWindow.MainForm.tabSimTotals

        MsgBox("Thermal Simulation Completed Successully.")

    End Sub

    Public Function GenerateNextTemperatureProfile(Tray As TrayData, CurrentTProfiles As Dictionary(Of Long, TProfile),
                                                   Delta_time As Double, AirTemperature As Double, VentilationOn As Boolean) As Dictionary(Of Long, TProfile)
        'This function will perform a timestep in the simulation and will generate a new set of temperature profiles as output for each product.

        GenerateNextTemperatureProfile = New Dictionary(Of Long, TProfile)
        Dim Tprof() As Double
        Dim NewTprof() As Double

        For Each Product As KeyValuePair(Of Long, TProfile) In CurrentTProfiles 'Key=Product index in the array of ProductMix() . Value=T profile
            Tprof = Product.Value.TemperatureProfile


            NewTprof = Next_Timestep(Tprof, VRTM_SimVariables.ProductMix(Product.Key).SimThickness / (2000 * ProductMixSetup.nx),
                                     Delta_time, Crank_Nicolson.Boundary.Neumann, 0, 0, 0, Crank_Nicolson.Boundary.Robin, AirTemperature,
                                     VRTM_SimVariables.ProductMix(Product.Key).ConvCoefficientUsed * VentilationMultiplier, 0,
                                     Geometry_Exponent(VRTM_SimVariables.ProductMix(Product.Key).SimGeometry),
                                     VRTM_SimVariables.ProductMix(Product.Key).FoodThermalPropertiesModel)

            'Energy balance
            'Dim E As Double = Energy_Balance(Tprof, NewTprof, VRTM_SimVariables.ProductMix(Product.Key).SimThickness / (2000 * ProductMixSetup.nx),
            'Delta_time, Crank_Nicolson.Boundary.Neumann, 0, 0, 0, Crank_Nicolson.Boundary.Robin, AirTemperature,
            'VRTM_SimVariables.ProductMix(Product.Key).ConvCoefficientUsed * VentilationMultiplier, 0,
            'Geometry_Exponent(VRTM_SimVariables.ProductMix(Product.Key).SimGeometry),
            'VRTM_SimVariables.ProductMix(Product.Key).FoodThermalPropertiesModel)

            GenerateNextTemperatureProfile.Add(Product.Key, New TProfile(NewTprof))
        Next

    End Function

    Public Function GenerateProductTemperatureProfile(Tray As TrayData) As Dictionary(Of Long, TProfile)
        'This function will generate an empty T profile for the given tray, based on the initial conditions set in the simulation configurations.

        GenerateProductTemperatureProfile = New Dictionary(Of Long, TProfile)
        Dim Tprof As TProfile

        For Each Product As KeyValuePair(Of Long, Long) In Tray.ProductIndices 'Key=Product index in the array of ProductMix() . Value=Quantity of boxes
            Tprof = New TProfile(Nothing)
            ReDim Tprof.TemperatureProfile(ProductMixSetup.nx - 1)

            For I As Long = 0 To (ProductMixSetup.nx - 1)
                Tprof.TemperatureProfile(I) = VRTM_SimVariables.ProductMix(Product.Key).InletTemperature
            Next

            GenerateProductTemperatureProfile.Add(Product.Key, Tprof)
        Next

    End Function

    Public Class TrayThermalData
        'Will store a tray worth of thermal profiles
        Public CurrentTimestep As Long
        Public CurrentTProfs_AllProds As Dictionary(Of Long, TProfile) 'Key=product index in the array ProductMix(), Value=array of temperature profiles versus X
        Public PastTProfs_AllProds As Dictionary(Of Long, TProfile) 'Key=product index in the array ProductMix(), Value=array of temperature profiles versus X

        Public Function Clone() As TrayThermalData
            Return DirectCast(Me.MemberwiseClone(), TrayThermalData)
        End Function

    End Class

    Public Class TProfile
        'Will store the thermal profile for any given time step and product combination.
        Public TemperatureProfile As Double()

        Public Sub New(NewTProf As Double())
            If Not IsNothing(NewTProf) Then
                Me.TemperatureProfile = NewTProf
            End If
        End Sub

        Public Function Clone() As TProfile
            Return DirectCast(Me.MemberwiseClone(), TProfile)
        End Function
    End Class

    Public Function IsVentilationTurnedOn(t As Double) As Boolean
        'Defines whether this time t (in s from zero) is inside the ventilation hours.
        Dim DayOfWeek As Integer
        DayOfWeek = Math.Floor((t / 86400)) Mod 7

        If VRTM_SimVariables.IdleDaysVRTM(DayOfWeek) Then 'It might be idle today
            Dim Hours_Intraday As Double
            Hours_Intraday = (t Mod 86400) / 86400
            If (VRTM_SimVariables.IdleHourBeginVRTM <= Hours_Intraday And VRTM_SimVariables.IdleHourEndVRTM >= Hours_Intraday) Then
                'It's actually idle.
                Return False
            End If
        End If

        Return True
    End Function

    Public Function IsMachineRoomTurnedOn(t As Double) As Boolean
        'Defines whether this time t (in s from zero) is inside the ventilation hours.
        Dim DayOfWeek As Integer
        DayOfWeek = Math.Floor((t / 86400)) Mod 7

        If VRTM_SimVariables.IdleDaysMRoom(DayOfWeek) Then 'It might be idle today
            Dim Hours_Intraday As Double
            Hours_Intraday = (t Mod 86400) / 86400
            If (VRTM_SimVariables.IdleHourBeginMRoom <= Hours_Intraday And VRTM_SimVariables.IdleHourEndMRoom >= Hours_Intraday) Then
                'It's actually idle.
                Return False
            End If
        End If
        Return True
    End Function
End Module
