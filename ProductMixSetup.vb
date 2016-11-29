Public Class ProductMixSetup
    Private Sub ProductMixSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loads the columns in the listview
        lstProductMix.View = View.Details
        lstProductMix.FullRowSelect = True

        lstProductMix.Columns.Add("Product Name", 100)
        lstProductMix.Columns.Add("Box Weight [kg]", 90)
        lstProductMix.Columns.Add("Avg Flow [box/h]", 100)
        lstProductMix.Columns.Add("Inlet Temp. [ºC]", 100)
        lstProductMix.Columns.Add("Outlet Temp. [ºC]", 100)
        lstProductMix.Columns.Add("Thermal Model", 100)

        'Loads the products according to the VRTMSimulationVariables into the list
        UpdateProductList()

        'Initializes the simple comboboxes
        txtStatDistr.SelectedIndex = 0
        txtSimGeom.SelectedIndex = 0

    End Sub

    Private Sub UpdateProductList()
        'Updates the product list according to the current simulation in memory
        If Not IsNothing(VRTM_SimVariables.ProductMix) Then
            For Each Prod As ProductData In VRTM_SimVariables.ProductMix
                lstProductMix.Items.Add(Prod.ProdName)
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Trim(Str(Prod.BoxWeight)))
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Trim(Str(Prod.AvgFlowRate)))
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Trim(Str(Prod.InletTemperature)))
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Trim(Str(Prod.OutletTemperatureDesign)))
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Prod.ProdName)
            Next
        End If

        lstProductMix.SelectedItems.Clear()
    End Sub

    Private Sub lstProductMix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProductMix.SelectedIndexChanged
        If lstProductMix.SelectedItems.Count = 1 Then
            'Updates the form with the selected item
            With lstProductMix.SelectedItems(0)
                For Each p As ProductData In VRTM_SimVariables.ProductMix
                    If p.ProdName = .Text Then
                        'Found a correspondence between product name in list and in memory (they supposedly are unique)
                        txtProductName.Text = p.ProdName
                        txtBoxWeight.Text = Trim(Str(p.BoxWeight))
                        txtBoxFlowRate.Text = Trim(Str(p.AvgFlowRate))
                        txtStatDistr.SelectedItem = p.BoxRateStatisticalDistr
                        Select Case p.BoxRateStatisticalDistr
                            Case "Exponential"
                                txtStdDev.Text = ""
                            Case "Gaussian"
                                txtStdDev.Text = Trim(Str(p.BoxRateStdDev))
                        End Select

                        txtSimGeom.SelectedItem = p.SimGeometry
                        Select Case p.SimGeometry
                            Case "Thin Slab"
                                txtSimThickness.Text = Trim(Str(p.SimThickness))
                                txtSimLength.Text = Trim(Str(p.SimLength))
                                txtSimWidth.Text = Trim(Str(p.SimWidth))
                                txtSimDiameter.Text = ""

                                txtSimThickness.Enabled = True
                                txtSimLength.Enabled = True
                                txtSimWidth.Enabled = True
                                txtSimDiameter.Enabled = False
                            Case "Long Cylinder"
                                txtSimThickness.Text = ""
                                txtSimLength.Text = Trim(Str(p.SimLength))
                                txtSimWidth.Text = ""
                                txtSimDiameter.Text = Trim(Str(p.SimDiameter))

                                txtSimThickness.Enabled = False
                                txtSimLength.Enabled = True
                                txtSimWidth.Enabled = False
                                txtSimDiameter.Enabled = True
                            Case "Sphere"
                                txtSimThickness.Text = ""
                                txtSimLength.Text = ""
                                txtSimWidth.Text = ""
                                txtSimDiameter.Text = Trim(Str(p.SimDiameter))

                                txtSimThickness.Enabled = False
                                txtSimLength.Enabled = False
                                txtSimWidth.Enabled = False
                                txtSimDiameter.Enabled = True
                        End Select

                        txtInletTemp.Text = Trim(Str(p.InletTemperature))
                        txtOutletTemp.Text = Trim(Str(p.OutletTemperatureDesign))
                        txtMinStayTime.Text = Trim(Str(p.MinimumStayTime))
                        txtAirSpeed.Text = Trim(Str(p.AirSpeed))
                        txtConvectionMultFactor.Text = Trim(Str(p.ConvCoeffMultiplier))
                        txtConvCoeff.Text = Trim(Str(p.ConvCoefficientUsed))

                        txtProductModel.Text = ""

                        'Include the food thermal properties model here
                        '=p.FoodThermalPropertiesModel
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub cmdSaveProduct_Click(sender As Object, e As EventArgs) Handles cmdSaveProduct.Click
        'Dummy code
        MsgBox(lstProductMix.SelectedItems(0).Text)
    End Sub
End Class