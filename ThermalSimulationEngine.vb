Module ThermalSimulationEngine
    Public Sub RunThermalSimulation()
        'This sub will review the current process simulation data and will run a thermal simulation.
        Dim I, J, TimeStep As Long
        Dim CurrentIndex As Long
        Dim Delta_Time As Double
        Dim TotalPower As Double

        'Inits a thermal data array
        Dim TrayThermalInformation() As TrayThermalData
        ReDim TrayThermalInformation(Simulation_Results.VRTMTimePositions.Count - 1)

        'Inits the total power array
        ReDim Simulation_Results.TotalPower(Simulation_Results.VRTMTimePositions.Count - 1)

        'Begins the main sim loop
        Dim Watch As New Stopwatch
        Watch.Start()

        For TimeStep = 0 To Simulation_Results.VRTMTimePositions.Count - 1

            If TimeStep Mod 100 Then
                'Updates the progress
                MainWindow.MainForm.Text = "VRTM Simulator V1.0 - Thermal Simulation Progress: " &
                    Trim(Str(Round(TimeStep * 100 / (Simulation_Results.VRTMTimePositions.Count - 1), 1))) & " %..."
            End If

            TotalPower = 0 'Inits the power for this t_step
            For I = 0 To VRTM_SimVariables.nTrays - 1
                For J = 0 To VRTM_SimVariables.nLevels - 1


                    CurrentIndex = Simulation_Results.VRTMTrayData(TimeStep, I, J).TrayIndex 'Gets the current tray index
                    If TimeStep > 0 Then Delta_Time = Simulation_Results.VRTMTimePositions(TimeStep) - Simulation_Results.VRTMTimePositions(TimeStep - 1)

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
                                                TrayThermalInformation(CurrentIndex).PastTProfs_AllProds, Delta_Time, -35)
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

                        Dim dm As Double
                        Dim dQ As Double
                        Dim Q As Double
                        Dim T1 As Double
                        Dim T2 As Double
                        Dim CurrDT As Double

                        Dim Power As Double

                        If Not (IsNothing(TrayThermalInformation(CurrentIndex).PastTProfs_AllProds) _
                            Or IsNothing(TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds)) Then 'There must be data to work with

                            Q = 0
                            For Each Product As KeyValuePair(Of Long, TProfile) In TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds 'Key=prod index, value=Tprof
                                ProdMassEach = VRTM_SimVariables.ProductMix(Product.Key).BoxWeight
                                ProdQty = Simulation_Results.VRTMTrayData(TimeStep, I, J).ProductIndices(Product.Key)

                                dm = (ProdQty * ProdMassEach) / ProductMixSetup.nx 'mass element [kg]

                                For N As Long = 0 To ProductMixSetup.nx - 1
                                    T1 = TrayThermalInformation(CurrentIndex).PastTProfs_AllProds(Product.Key).TemperatureProfile(N)
                                    T2 = TrayThermalInformation(CurrentIndex).CurrentTProfs_AllProds(Product.Key).TemperatureProfile(N)
                                    CurrDT = T1 - T2

                                    ProdCp = VRTM_SimVariables.ProductMix(Product.Key).FoodThermalPropertiesModel.get_cp((T1 + T2) / 2)

                                    dQ = dm * ProdCp * CurrDT 'Heat exchanged in the timestep for the current mass element [J]
                                    Q += dQ 'Total heat exchanged [integral], across all products
                                Next
                            Next

                            'The power is Q/dt
                            Power = Q / Delta_Time
                        Else
                            Power = 0
                        End If

                        Simulation_Results.VRTMTrayData(TimeStep, I, J).TrayPower = Power
                        TotalPower += Power
                    End If

                Next
            Next

            Simulation_Results.TotalPower(TimeStep) = (TotalPower + 1000 * (VRTM_SimVariables.FixedHeatLoadData.FixedHL + VRTM_SimVariables.fanPower)) *
                                            VRTM_SimVariables.SafetyFactorVRTM 'Updates total power in [W]
        Next
        Watch.Stop()

        MainWindow.MainForm.Text = "VRTM Simulator V1.0"
        MainWindow.MainForm.LoadTotalHeatLoadGraph()


        MsgBox("Thermal Simulation Completed Successully.")


    End Sub

    Public Function GenerateNextTemperatureProfile(Tray As TrayData, CurrentTProfiles As Dictionary(Of Long, TProfile),
                                                   Delta_time As Double, AirTemperature As Double) As Dictionary(Of Long, TProfile)
        'This function will perform a timestep in the simulation and will generate a new set of temperature profiles as output for each product.

        GenerateNextTemperatureProfile = New Dictionary(Of Long, TProfile)
        Dim Tprof() As Double
        Dim NewTprof() As Double

        For Each Product As KeyValuePair(Of Long, TProfile) In CurrentTProfiles 'Key=Product index in the array of ProductMix() . Value=T profile
            Tprof = Product.Value.TemperatureProfile

            NewTprof = Next_Timestep(Tprof, VRTM_SimVariables.ProductMix(Product.Key).SimThickness / (2000 * ProductMixSetup.nx),
                                     Delta_time, Crank_Nicolson.Boundary.Neumann, 0, 0, 0, Crank_Nicolson.Boundary.Robin, AirTemperature,
                                     VRTM_SimVariables.ProductMix(Product.Key).ConvCoefficientUsed, 0,
                                     Geometry_Exponent(VRTM_SimVariables.ProductMix(Product.Key).SimGeometry),
                                     VRTM_SimVariables.ProductMix(Product.Key).FoodThermalPropertiesModel)


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
End Module
