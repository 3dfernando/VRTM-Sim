﻿Public Class ProductMixSetup
    Private IndexOfProductBeingEdited As Integer = -1
    Private AirTemperatureApproach As Double = 7 'Models a constant approach as a first approx. for air temperature (Tair-Tevap)

#Region "Product list handling/saving"
    Private Sub ProductMixSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loads the columns in the listview
        lstProductMix.View = View.Details
        lstProductMix.FullRowSelect = True

        lstProductMix.Columns.Clear()
        lstProductMix.Columns.Add("Product Name", 100)
        lstProductMix.Columns.Add("Box Weight [kg]", 90)
        lstProductMix.Columns.Add("Avg Flow [box/h]", 100)
        lstProductMix.Columns.Add("Inlet Temp. [ºC]", 100)
        lstProductMix.Columns.Add("Outlet Temp. [ºC]", 100)
        lstProductMix.Columns.Add("Thermal Model", 100)

        'Loads the columns in the product model properties view
        lstProdModelProperties.View = View.Details
        lstProdModelProperties.FullRowSelect = True

        lstProdModelProperties.Columns.Clear()
        lstProdModelProperties.Columns.Add("Property", 120)
        lstProdModelProperties.Columns.Add("Value", 60)

        'Initializes the simple comboboxes
        txtStatDistr.SelectedIndex = 0
        txtSimGeom.SelectedIndex = 0

        'Initializes the Product model combobox
        txtProductModel.Items.Clear()
        For Each Food As FoodPropertiesListItem In FoodPropertiesList
            txtProductModel.Items.Add(Food.ProductName)
        Next
        txtProductModel.SelectedIndex = 0

        'Loads the products according to the VRTMSimulationVariables into the list
        UpdateProductList()

        'Inits the chart formatting
        InitializeGraph()
        UpdateGraph("Sample Temperature Distribution", {0, 1, 2.1, 3, 4, 5.5}, {12, 0, -2, -2, -18, -18}, {12, 11, 5, 2, -2, -7}) 'Delete me
    End Sub

    Private Sub UpdateProductList()
        'Updates the product list according to the current simulation in memory
        lstProductMix.Items.Clear()
        If Not IsNothing(VRTM_SimVariables.ProductMix) Then
            For Each Prod As ProductData In VRTM_SimVariables.ProductMix
                lstProductMix.Items.Add(Prod.ProdName)
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Trim(Str(Prod.BoxWeight)))
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Trim(Str(Prod.AvgFlowRate)))
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Trim(Str(Prod.InletTemperature)))
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Trim(Str(Prod.OutletTemperatureDesign)))
                lstProductMix.Items(lstProductMix.Items.Count - 1).SubItems.Add(Prod.FoodThermalPropertiesModel.FoodModelUsed.ProductName)
            Next
        End If

        lstProductMix.SelectedItems.Clear()
        IndexOfProductBeingEdited = -1
        clearForm()
    End Sub

    Private Sub lstProductMix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProductMix.SelectedIndexChanged
        Dim I As Integer
        Dim p As ProductData
        If lstProductMix.SelectedItems.Count = 1 Then
            'Updates the form with the selected item
            With lstProductMix.SelectedItems(0)
                For I = 0 To UBound(VRTM_SimVariables.ProductMix)
                    p = VRTM_SimVariables.ProductMix(I)
                    If p.ProdName = .Text Then
                        'Found a correspondence between product name in list and in memory (they supposedly are unique)
                        IndexOfProductBeingEdited = I
                        txtProductName.Text = p.ProdName
                        txtBoxWeight.Text = Trim(Str(p.BoxWeight))
                        txtBoxFlowRate.Text = Trim(Str(p.AvgFlowRate))
                        txtStatDistr.SelectedItem = p.BoxRateStatisticalDistr
                        Select Case p.BoxRateStatisticalDistr
                            Case "Exponential"
                                txtStdDev.Text = ""
                                txtStdDev.Enabled = False
                            Case "Gaussian"
                                txtStdDev.Text = Trim(Str(p.BoxRateStdDev))
                                txtStdDev.Enabled = True
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
                        txtProductModel.SelectedItem = p.FoodThermalPropertiesModel.FoodModelUsed.ProductName
                    End If
                Next
            End With
        Else
            'Nothing has been selected, so clears the form
            clearForm()
            IndexOfProductBeingEdited = -1
        End If

        ErrorProvider1.Clear()
    End Sub

    Private Sub clearForm()
        'Clears the form for a new item
        txtProductName.Text = ""
        txtBoxWeight.Text = ""
        txtBoxFlowRate.Text = ""
        txtStatDistr.SelectedIndex = 0
        'Exponential
        txtStdDev.Text = ""
        txtStdDev.Enabled = False

        txtSimGeom.SelectedIndex = 0
        'Thin Slab
        txtSimThickness.Text = ""
        txtSimLength.Text = ""
        txtSimWidth.Text = ""
        txtSimDiameter.Text = ""
        txtSimThickness.Enabled = True
        txtSimLength.Enabled = True
        txtSimWidth.Enabled = True
        txtSimDiameter.Enabled = False

        txtInletTemp.Text = ""
        txtOutletTemp.Text = ""
        txtMinStayTime.Text = ""
        txtAirSpeed.Text = ""
        txtConvectionMultFactor.Text = ""
        txtConvCoeff.Text = ""

        txtProductModel.SelectedIndex = 0

        ClearGraph()
    End Sub

    Private Sub UpdateFoodPropertiesList()
        'This updates the little list of "Product Model Properties"
        Dim i As ListViewItem
        For Each p As FoodPropertiesListItem In FoodPropertiesList
            If p.ProductName = txtProductModel.SelectedItem Then
                lstProdModelProperties.Items.Clear()
                i = lstProdModelProperties.Items.Add("Water Content")
                i.SubItems.Add(Trim(Str(p.WaterContent * 100)) & "%")
                i = lstProdModelProperties.Items.Add("Protein Content")
                i.SubItems.Add(Trim(Str(p.ProteinContent * 100)) & "%")
                i = lstProdModelProperties.Items.Add("Fat Content")
                i.SubItems.Add(Trim(Str(p.FatContent * 100)) & "%")
                i = lstProdModelProperties.Items.Add("Carb Content")
                i.SubItems.Add(Trim(Str(p.CarbContent * 100)) & "%")
                i = lstProdModelProperties.Items.Add("Ash Content")
                i.SubItems.Add(Trim(Str(p.AshContent * 100)) & "%")
                i = lstProdModelProperties.Items.Add("Freezing Temperature")
                i.SubItems.Add(Trim(Str(p.FreezingTemp)) & " ºC")
                Exit For
            End If
        Next
    End Sub

    Private Sub txtProductModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtProductModel.SelectedIndexChanged
        UpdateFoodPropertiesList()
    End Sub

    Private Sub cmdSaveProduct_Click(sender As Object, e As EventArgs) Handles cmdSaveProduct.Click

        'Updates the current selected item in the list with the data

        'Performs validation in all objects before saving
        Dim evargs As New System.ComponentModel.CancelEventArgs
        Dim objectsToValidatePositive() As Object
        Dim objectsToValidateTemperature() As Object
        Dim ProdNameObj As Object
        Dim errorOccurred As Boolean = False

        objectsToValidatePositive = {txtBoxWeight, txtBoxFlowRate, txtStdDev, txtSimThickness, txtSimLength, txtSimWidth, txtSimDiameter, txtMinStayTime,
             txtAirSpeed, txtConvectionMultFactor}
        objectsToValidateTemperature = {txtInletTemp, txtOutletTemp}
        ProdNameObj = txtProductName

        For Each o As Object In objectsToValidatePositive
            Validate_Positive(o, evargs)
            If ErrorProvider1.GetError(o) <> Nothing Then
                errorOccurred = True
            End If
        Next
        For Each o As Object In objectsToValidateTemperature
            Validate_Temperature(o, evargs)
            If ErrorProvider1.GetError(o) <> Nothing Then
                errorOccurred = True
            End If
        Next
        ValidateProdName(ProdNameObj, evargs)
        If ErrorProvider1.GetError(ProdNameObj) <> Nothing Then
            errorOccurred = True
        End If
        If errorOccurred Then Exit Sub

        'Now does the saving
        Dim I As Integer = -1
        If lstProductMix.SelectedItems.Count = 1 Then
            'Saves over the selected item in the list
            If IndexOfProductBeingEdited = -1 Then Exit Sub
            I = IndexOfProductBeingEdited
        ElseIf lstProductMix.SelectedItems.Count = 0 Then
            'It's going to add a new one
            ReDim Preserve VRTM_SimVariables.ProductMix(UBound(VRTM_SimVariables.ProductMix) + 1)
            VRTM_SimVariables.ProductMix(UBound(VRTM_SimVariables.ProductMix)) = New ProductData
            I = UBound(VRTM_SimVariables.ProductMix)
        Else
            'It seems more than one item is selected
            MsgBox("It seems more than one item is selected in the list, please check!")
        End If

        'Performs the actual memory swap
        VRTM_SimVariables.ProductMix(I).ProdName = txtProductName.Text '---------------Loop through to see whether other items don't have the same name
        VRTM_SimVariables.ProductMix(I).BoxWeight = Val(txtBoxWeight.Text)
        VRTM_SimVariables.ProductMix(I).AvgFlowRate = Val(txtBoxFlowRate.Text)
        VRTM_SimVariables.ProductMix(I).BoxRateStatisticalDistr = txtStatDistr.SelectedItem
        Select Case txtStatDistr.SelectedItem
            Case "Exponential"
                VRTM_SimVariables.ProductMix(I).BoxRateStdDev = 0
            Case "Gaussian"
                VRTM_SimVariables.ProductMix(I).BoxRateStdDev = txtStdDev.Text
                txtStdDev.Enabled = True
        End Select

        VRTM_SimVariables.ProductMix(I).SimGeometry = txtSimGeom.SelectedItem
        VRTM_SimVariables.ProductMix(I).SimThickness = Val(txtSimThickness.Text)
        VRTM_SimVariables.ProductMix(I).SimLength = Val(txtSimLength.Text)
        VRTM_SimVariables.ProductMix(I).SimWidth = Val(txtSimWidth.Text)
        VRTM_SimVariables.ProductMix(I).SimDiameter = Val(txtSimDiameter.Text)

        VRTM_SimVariables.ProductMix(I).InletTemperature = Val(txtInletTemp.Text)
        VRTM_SimVariables.ProductMix(I).OutletTemperatureDesign = Val(txtOutletTemp.Text)
        VRTM_SimVariables.ProductMix(I).MinimumStayTime = Val(txtMinStayTime.Text)
        VRTM_SimVariables.ProductMix(I).AirSpeed = Val(txtAirSpeed.Text)
        VRTM_SimVariables.ProductMix(I).ConvCoeffMultiplier = Val(txtConvectionMultFactor.Text)
        VRTM_SimVariables.ProductMix(I).ConvCoefficientUsed = Val(txtConvCoeff.Text)

        For Each p As FoodPropertiesListItem In FoodPropertiesList
            If p.ProductName = txtProductModel.SelectedItem Then
                VRTM_SimVariables.ProductMix(I).FoodThermalPropertiesModel = New FoodProperties(p, True)
                Exit For
            End If
        Next
        UpdateProductList() 'Updates the list with the saved data

    End Sub

    Private Sub cmdRemoveProduct_Click(sender As Object, e As EventArgs) Handles cmdRemoveProduct.Click
        'Removes the selected product from the list
        Dim I As Integer
        Dim J As Integer
        Dim newProductMix() As ProductData
        If lstProductMix.SelectedItems.Count = 1 Then
            If lstProductMix.Items.Count = 1 Then
                MsgBox("You can't remove the last item!")
                Exit Sub
            End If
            With lstProductMix.SelectedItems(0)
                For I = 0 To UBound(VRTM_SimVariables.ProductMix)
                    If VRTM_SimVariables.ProductMix(I).ProdName = .Text Then
                        'It's a match
                        ReDim newProductMix(UBound(VRTM_SimVariables.ProductMix) - 1)
                        For J = 0 To UBound(VRTM_SimVariables.ProductMix)
                            If J < I Then
                                newProductMix(J) = VRTM_SimVariables.ProductMix(J)
                            ElseIf J > I Then
                                newProductMix(J - 1) = VRTM_SimVariables.ProductMix(J)
                            End If
                        Next
                        VRTM_SimVariables.ProductMix = newProductMix
                        Exit For
                    End If
                Next
                .Remove()
            End With
        End If
    End Sub

    Private Sub cmdAddProduct_Click(sender As Object, e As EventArgs) Handles cmdAddProduct.Click
        'Clears the selection
        lstProductMix.SelectedItems.Clear()
        clearForm()
        IndexOfProductBeingEdited = -1
    End Sub

#End Region

#Region "Chart update"
    Private Sub InitializeGraph()
        'Initializes the graph formatting (because the default formatting is awful!!)
        Dim LightGrayColor, DarkGrayColor As Color
        LightGrayColor = Color.FromArgb(230, 230, 230)
        DarkGrayColor = Color.FromArgb(100, 100, 100)

        With ProductFreezingChart
            .ChartAreas(0).AxisX.Title = "Time [h]"
            .ChartAreas(0).AxisY.Title = "Temperature [ºC]"

            .ChartAreas(0).AxisX.LineColor = DarkGrayColor
            .ChartAreas(0).AxisX.MajorGrid.LineColor = LightGrayColor
            .ChartAreas(0).AxisX.MinorGrid.LineColor = LightGrayColor
            .ChartAreas(0).AxisX.MajorTickMark.LineColor = DarkGrayColor
            .ChartAreas(0).AxisX.MinorTickMark.LineColor = DarkGrayColor
            .ChartAreas(0).AxisY.LineColor = DarkGrayColor
            .ChartAreas(0).AxisY.MajorGrid.LineColor = LightGrayColor
            .ChartAreas(0).AxisY.MinorGrid.LineColor = LightGrayColor
            .ChartAreas(0).AxisY.MajorTickMark.LineColor = DarkGrayColor
            .ChartAreas(0).AxisY.MinorTickMark.LineColor = DarkGrayColor

            .ChartAreas(0).AxisX.LabelStyle.Font = New Font(.ChartAreas(0).AxisX.LabelStyle.Font.FontFamily, 8)
            .ChartAreas(0).AxisY.LabelStyle.Font = New Font(.ChartAreas(0).AxisY.LabelStyle.Font.FontFamily, 8)
            .ChartAreas(0).AxisX.LabelStyle.ForeColor = DarkGrayColor
            .ChartAreas(0).AxisY.LabelStyle.ForeColor = DarkGrayColor

        End With
    End Sub

    Private Sub UpdateGraph(Title As String, TimeArray() As Double, TemperatureArraySurf() As Double, TemperatureArrayCenter() As Double)
        'Updates the graph with the three results from the simulation
        Dim I As Integer

        If UBound(TimeArray) <> UBound(TemperatureArraySurf) Then Exit Sub
        If UBound(TimeArray) <> UBound(TemperatureArrayCenter) Then Exit Sub

        'Titles
        ProductFreezingChart.Titles.Clear()
        ProductFreezingChart.Titles.Add(Title)

        'Surface series
        ProductFreezingChart.Series.Clear()
        Dim Surf As New DataVisualization.Charting.Series
        Surf.Name = "Surface"
        Surf.ChartType = DataVisualization.Charting.SeriesChartType.Line
        For I = 0 To UBound(TemperatureArraySurf)
            Surf.Points.AddXY(TimeArray(I), TemperatureArraySurf(I))
        Next
        Surf.Color = Color.Red
        Surf.BorderWidth = 1
        ProductFreezingChart.Series.Add(Surf)

        'Center series
        Dim Center As New DataVisualization.Charting.Series
        Center.Name = "Center"
        Center.ChartType = DataVisualization.Charting.SeriesChartType.Line
        For I = 0 To UBound(TemperatureArrayCenter)
            Center.Points.AddXY(TimeArray(I), TemperatureArrayCenter(I))
        Next
        Center.Color = Color.Blue
        Center.BorderWidth = 1
        ProductFreezingChart.Series.Add(Center)

        'Chart resizing
        ProductFreezingChart.ChartAreas(0).AxisX.Minimum = 0
        ProductFreezingChart.ChartAreas(0).AxisX.Maximum = TimeArray(UBound(TimeArray))

        Dim TInterval, TMin, TMax, padding As Double
        TMin = TemperatureArraySurf(UBound(TemperatureArraySurf))
        TMax = TemperatureArrayCenter(0)
        TInterval = TMax - TMin
        padding = 0.1
        ProductFreezingChart.ChartAreas(0).AxisY.Minimum = TMin - padding * TInterval
        ProductFreezingChart.ChartAreas(0).AxisY.Maximum = TMax + padding * TInterval


        'Legends
        ProductFreezingChart.Legends.Add("Surface")
        ProductFreezingChart.Legends.Add("Center")
        ProductFreezingChart.Legends(0).Position.Auto = False
        ProductFreezingChart.Legends(0).Position = New DataVisualization.Charting.ElementPosition(80, 10, 15, 20)

    End Sub

    Private Sub ClearGraph()
        'Clears the data in the chart
        ProductFreezingChart.Titles.Clear()
        ProductFreezingChart.Series.Clear()
    End Sub

#End Region

#Region "Validation of fields"
    Private Sub GeneralValidated(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtProductName.Validated, txtBoxWeight.Validated, txtBoxFlowRate.Validated, txtStdDev.Validated, txtSimThickness.Validated, txtSimLength.Validated,
        txtSimWidth.Validated, txtSimDiameter.Validated, txtMinStayTime.Validated, txtAirSpeed.Validated, txtConvectionMultFactor.Validated,
        txtInletTemp.Validated, txtOutletTemp.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        'Updates convection coefficient if enough data is available.
        Dim OkToCalc As Boolean = True
        OkToCalc = OkToCalc And (txtSimGeom.SelectedItem <> "")
        OkToCalc = OkToCalc And (Val(txtAirSpeed.Text) > 0)
        OkToCalc = OkToCalc And (txtConvectionMultFactor.Text > 0)

        txtConvCoeff.Text = Trim(Str(Int(Get_H(txtSimGeom.SelectedItem, Val(txtSimThickness.Text), Val(txtSimWidth.Text), Val(txtSimLength.Text),
                       VRTM_SimVariables.Tevap_Setpoint + AirTemperatureApproach, "Air", Val(txtAirSpeed.Text), Val(txtConvectionMultFactor.Text)) * 100) / 100))

    End Sub
    Private Sub ValidateProdName(sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtProductName.Validating
        'It cannot be the same as any product
        Dim Once As Boolean
        Once = False
        For Each p As ProductData In VRTM_SimVariables.ProductMix
            If p.ProdName = txtProductName.Text Then
                If Once Then
                    ' Cancel the event and select the text to be corrected by the user.
                    e.Cancel = True
                    sender.Select(0, sender.Text.Length)

                    ' Set the ErrorProvider error with the text to display. 
                    ErrorProvider1.SetError(sender, "The product name cannot repeat any of the other product's names.")
                Else
                    Once = True
                End If
                Exit Sub
            End If
        Next
    End Sub
    Private Sub Validate_Positive(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtBoxWeight.Validating, txtBoxFlowRate.Validating, txtStdDev.Validating, txtSimThickness.Validating, txtSimLength.Validating, txtSimWidth.Validating,
        txtSimDiameter.Validating, txtMinStayTime.Validating, txtAirSpeed.Validating, txtConvectionMultFactor.Validating
        'Validates several textboxes that have a numeric input
        If sender.Enabled = False Then Exit Sub
        If Not (IsNumeric(sender.Text) And Val(sender.text) > 0) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A numeric value must be provided.")
        End If
    End Sub
    Private Sub Validate_Temperature(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtInletTemp.Validating, txtOutletTemp.Validating
        'Validates several textboxes that have a numeric input
        If sender.Enabled = False Then Exit Sub
        If Not (IsNumeric(sender.Text) And Val(sender.text) > -50 And Val(sender.text) < 70 And (Val(txtInletTemp.Text) > Val(txtOutletTemp.Text))) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A numeric value between -50ºC and +70ºC must be provided and T_in>T_out.")
        End If
    End Sub
    Private Sub txtStatDistr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtStatDistr.SelectedIndexChanged
        Select Case txtStatDistr.SelectedIndex
            Case 0
                'Exponential
                txtStdDev.Text = ""
                txtStdDev.Enabled = False
            Case 1
                'Gaussian
                txtStdDev.Text = "0"
                txtStdDev.Enabled = True
        End Select
    End Sub
    Private Sub txtSimGeom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSimGeom.SelectedIndexChanged
        Select Case txtSimGeom.SelectedIndex
            Case 0
                'Thin slab
                txtSimThickness.Text = ""
                txtSimLength.Text = ""
                txtSimWidth.Text = ""
                txtSimDiameter.Text = ""

                txtSimThickness.Enabled = True
                txtSimLength.Enabled = True
                txtSimWidth.Enabled = True
                txtSimDiameter.Enabled = False
            Case 1
                'Long cyl
                txtSimThickness.Text = ""
                txtSimLength.Text = ""
                txtSimWidth.Text = ""
                txtSimDiameter.Text = ""

                txtSimThickness.Enabled = False
                txtSimLength.Enabled = True
                txtSimWidth.Enabled = False
                txtSimDiameter.Enabled = True
            Case 2
                'Sphere
                txtSimThickness.Text = ""
                txtSimLength.Text = ""
                txtSimWidth.Text = ""
                txtSimDiameter.Text = ""

                txtSimThickness.Enabled = False
                txtSimLength.Enabled = False
                txtSimWidth.Enabled = False
                txtSimDiameter.Enabled = True
        End Select
    End Sub



#End Region


End Class