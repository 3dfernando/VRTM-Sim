<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductMixSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductMixSetup))
        Me.lstProductMix = New System.Windows.Forms.ListView()
        Me.cmdRemoveProduct = New System.Windows.Forms.Button()
        Me.cmdAddProduct = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStatDistr = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStdDev = New System.Windows.Forms.TextBox()
        Me.txtBoxFlowRate = New System.Windows.Forms.TextBox()
        Me.txtBoxWeight = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProductFreezingChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSimGeom = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSimDiameter = New System.Windows.Forms.TextBox()
        Me.txtSimWidth = New System.Windows.Forms.TextBox()
        Me.txtSimLength = New System.Windows.Forms.TextBox()
        Me.txtSimThickness = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lstProdModelProperties = New System.Windows.Forms.ListView()
        Me.txtProductModel = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtConvCoeff = New System.Windows.Forms.TextBox()
        Me.txtConvectionMultFactor = New System.Windows.Forms.TextBox()
        Me.txtAirSpeed = New System.Windows.Forms.TextBox()
        Me.txtMinStayTime = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtOutletTemp = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtInletTemp = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmdSaveProduct = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.ProductFreezingChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstProductMix
        '
        Me.lstProductMix.Location = New System.Drawing.Point(142, 12)
        Me.lstProductMix.Name = "lstProductMix"
        Me.lstProductMix.Size = New System.Drawing.Size(650, 125)
        Me.lstProductMix.TabIndex = 2
        Me.lstProductMix.UseCompatibleStateImageBehavior = False
        Me.lstProductMix.View = System.Windows.Forms.View.Details
        '
        'cmdRemoveProduct
        '
        Me.cmdRemoveProduct.Image = Global.VRTM_Simulator.My.Resources.Resources.list_remove_4
        Me.cmdRemoveProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRemoveProduct.Location = New System.Drawing.Point(10, 44)
        Me.cmdRemoveProduct.Name = "cmdRemoveProduct"
        Me.cmdRemoveProduct.Size = New System.Drawing.Size(126, 26)
        Me.cmdRemoveProduct.TabIndex = 1
        Me.cmdRemoveProduct.Text = "Remove Product"
        Me.cmdRemoveProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRemoveProduct.UseVisualStyleBackColor = True
        '
        'cmdAddProduct
        '
        Me.cmdAddProduct.Image = Global.VRTM_Simulator.My.Resources.Resources.edit_add_2
        Me.cmdAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddProduct.Location = New System.Drawing.Point(10, 12)
        Me.cmdAddProduct.Name = "cmdAddProduct"
        Me.cmdAddProduct.Size = New System.Drawing.Size(126, 26)
        Me.cmdAddProduct.TabIndex = 0
        Me.cmdAddProduct.Text = "Add Product"
        Me.cmdAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddProduct.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStatDistr)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtStdDev)
        Me.GroupBox1.Controls.Add(Me.txtBoxFlowRate)
        Me.GroupBox1.Controls.Add(Me.txtBoxWeight)
        Me.GroupBox1.Controls.Add(Me.txtProductName)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 143)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 161)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General Product Data"
        '
        'txtStatDistr
        '
        Me.txtStatDistr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtStatDistr.FormattingEnabled = True
        Me.txtStatDistr.Items.AddRange(New Object() {"Exponential", "Gaussian"})
        Me.txtStatDistr.Location = New System.Drawing.Point(117, 92)
        Me.txtStatDistr.Name = "txtStatDistr"
        Me.txtStatDistr.Size = New System.Drawing.Size(125, 21)
        Me.txtStatDistr.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(196, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "boxes/h"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(196, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "boxes/h"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(196, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "kg"
        '
        'txtStdDev
        '
        Me.txtStdDev.Location = New System.Drawing.Point(117, 117)
        Me.txtStdDev.Name = "txtStdDev"
        Me.txtStdDev.Size = New System.Drawing.Size(73, 20)
        Me.txtStdDev.TabIndex = 7
        Me.txtStdDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxFlowRate
        '
        Me.txtBoxFlowRate.Location = New System.Drawing.Point(117, 69)
        Me.txtBoxFlowRate.Name = "txtBoxFlowRate"
        Me.txtBoxFlowRate.Size = New System.Drawing.Size(73, 20)
        Me.txtBoxFlowRate.TabIndex = 5
        Me.txtBoxFlowRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxWeight
        '
        Me.txtBoxWeight.Location = New System.Drawing.Point(117, 45)
        Me.txtBoxWeight.Name = "txtBoxWeight"
        Me.txtBoxWeight.Size = New System.Drawing.Size(73, 20)
        Me.txtBoxWeight.TabIndex = 4
        Me.txtBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProductName
        '
        Me.txtProductName.Location = New System.Drawing.Point(117, 20)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(125, 20)
        Me.txtProductName.TabIndex = 3
        Me.txtProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Standard Deviation:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Statistical Distribution:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Avg. Box Flow Rate:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Box Weight:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Name/SKU:"
        '
        'ProductFreezingChart
        '
        Me.ProductFreezingChart.BorderlineColor = System.Drawing.Color.Gray
        Me.ProductFreezingChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.Name = "ChartArea1"
        Me.ProductFreezingChart.ChartAreas.Add(ChartArea1)
        Me.ProductFreezingChart.Location = New System.Drawing.Point(10, 310)
        Me.ProductFreezingChart.Name = "ProductFreezingChart"
        Me.ProductFreezingChart.Size = New System.Drawing.Size(517, 286)
        Me.ProductFreezingChart.TabIndex = 4
        Me.ProductFreezingChart.Text = "Chart1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSimGeom)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtSimDiameter)
        Me.GroupBox2.Controls.Add(Me.txtSimWidth)
        Me.GroupBox2.Controls.Add(Me.txtSimLength)
        Me.GroupBox2.Controls.Add(Me.txtSimThickness)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Location = New System.Drawing.Point(273, 143)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(254, 161)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Geometric Data"
        '
        'txtSimGeom
        '
        Me.txtSimGeom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSimGeom.FormattingEnabled = True
        Me.txtSimGeom.Items.AddRange(New Object() {"Thin Slab", "Long Cylinder", "Sphere"})
        Me.txtSimGeom.Location = New System.Drawing.Point(117, 22)
        Me.txtSimGeom.Name = "txtSimGeom"
        Me.txtSimGeom.Size = New System.Drawing.Size(125, 21)
        Me.txtSimGeom.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(196, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "mm"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(196, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "mm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(196, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "mm"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(196, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "mm"
        '
        'txtSimDiameter
        '
        Me.txtSimDiameter.Location = New System.Drawing.Point(117, 118)
        Me.txtSimDiameter.Name = "txtSimDiameter"
        Me.txtSimDiameter.Size = New System.Drawing.Size(73, 20)
        Me.txtSimDiameter.TabIndex = 12
        Me.txtSimDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSimWidth
        '
        Me.txtSimWidth.Location = New System.Drawing.Point(117, 94)
        Me.txtSimWidth.Name = "txtSimWidth"
        Me.txtSimWidth.Size = New System.Drawing.Size(73, 20)
        Me.txtSimWidth.TabIndex = 11
        Me.txtSimWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSimLength
        '
        Me.txtSimLength.Location = New System.Drawing.Point(117, 71)
        Me.txtSimLength.Name = "txtSimLength"
        Me.txtSimLength.Size = New System.Drawing.Size(73, 20)
        Me.txtSimLength.TabIndex = 10
        Me.txtSimLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSimThickness
        '
        Me.txtSimThickness.Location = New System.Drawing.Point(117, 47)
        Me.txtSimThickness.Name = "txtSimThickness"
        Me.txtSimThickness.Size = New System.Drawing.Size(73, 20)
        Me.txtSimThickness.TabIndex = 9
        Me.txtSimThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Simulation Diameter:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Simulation Width:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Simulation Length:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Simulation Thickness:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Simulation Geometry:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.lstProdModelProperties)
        Me.GroupBox3.Controls.Add(Me.txtProductModel)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.txtConvCoeff)
        Me.GroupBox3.Controls.Add(Me.txtConvectionMultFactor)
        Me.GroupBox3.Controls.Add(Me.txtAirSpeed)
        Me.GroupBox3.Controls.Add(Me.txtMinStayTime)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.txtOutletTemp)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.txtInletTemp)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Location = New System.Drawing.Point(533, 143)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(259, 397)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Thermal Simulation Data"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 52)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(129, 13)
        Me.Label30.TabIndex = 6
        Me.Label30.Text = "Product Model Properties:"
        '
        'lstProdModelProperties
        '
        Me.lstProdModelProperties.Location = New System.Drawing.Point(22, 72)
        Me.lstProdModelProperties.Name = "lstProdModelProperties"
        Me.lstProdModelProperties.Size = New System.Drawing.Size(218, 149)
        Me.lstProdModelProperties.TabIndex = 14
        Me.lstProdModelProperties.UseCompatibleStateImageBehavior = False
        '
        'txtProductModel
        '
        Me.txtProductModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtProductModel.FormattingEnabled = True
        Me.txtProductModel.Location = New System.Drawing.Point(117, 22)
        Me.txtProductModel.Name = "txtProductModel"
        Me.txtProductModel.Size = New System.Drawing.Size(125, 21)
        Me.txtProductModel.TabIndex = 13
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(196, 362)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(44, 13)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "W/m².K"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(196, 316)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "m/s"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(196, 292)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(13, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "h"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(196, 269)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(18, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "ºC"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(196, 245)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(18, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "ºC"
        '
        'txtConvCoeff
        '
        Me.txtConvCoeff.Enabled = False
        Me.txtConvCoeff.Location = New System.Drawing.Point(117, 359)
        Me.txtConvCoeff.Name = "txtConvCoeff"
        Me.txtConvCoeff.Size = New System.Drawing.Size(73, 20)
        Me.txtConvCoeff.TabIndex = 20
        Me.txtConvCoeff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConvectionMultFactor
        '
        Me.txtConvectionMultFactor.Location = New System.Drawing.Point(117, 336)
        Me.txtConvectionMultFactor.Name = "txtConvectionMultFactor"
        Me.txtConvectionMultFactor.Size = New System.Drawing.Size(73, 20)
        Me.txtConvectionMultFactor.TabIndex = 19
        Me.txtConvectionMultFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAirSpeed
        '
        Me.txtAirSpeed.Location = New System.Drawing.Point(117, 313)
        Me.txtAirSpeed.Name = "txtAirSpeed"
        Me.txtAirSpeed.Size = New System.Drawing.Size(73, 20)
        Me.txtAirSpeed.TabIndex = 18
        Me.txtAirSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinStayTime
        '
        Me.txtMinStayTime.Location = New System.Drawing.Point(117, 289)
        Me.txtMinStayTime.Name = "txtMinStayTime"
        Me.txtMinStayTime.Size = New System.Drawing.Size(73, 20)
        Me.txtMinStayTime.TabIndex = 17
        Me.txtMinStayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 362)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(91, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Conv. Coefficient:"
        '
        'txtOutletTemp
        '
        Me.txtOutletTemp.Location = New System.Drawing.Point(117, 266)
        Me.txtOutletTemp.Name = "txtOutletTemp"
        Me.txtOutletTemp.Size = New System.Drawing.Size(73, 20)
        Me.txtOutletTemp.TabIndex = 16
        Me.txtOutletTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 339)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(97, 13)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Conv. Mult. Factor:"
        '
        'txtInletTemp
        '
        Me.txtInletTemp.Location = New System.Drawing.Point(117, 242)
        Me.txtInletTemp.Name = "txtInletTemp"
        Me.txtInletTemp.Size = New System.Drawing.Size(73, 20)
        Me.txtInletTemp.TabIndex = 15
        Me.txtInletTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 316)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(110, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Air Speed Over Prod.:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 292)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(101, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Minimum Stay Time:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 269)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(107, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Design Outlet Temp.:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 245)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(93, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Inlet Temperature:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(79, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Product Model:"
        '
        'cmdSaveProduct
        '
        Me.cmdSaveProduct.Image = Global.VRTM_Simulator.My.Resources.Resources.document_save_5
        Me.cmdSaveProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSaveProduct.Location = New System.Drawing.Point(666, 546)
        Me.cmdSaveProduct.Name = "cmdSaveProduct"
        Me.cmdSaveProduct.Size = New System.Drawing.Size(126, 33)
        Me.cmdSaveProduct.TabIndex = 21
        Me.cmdSaveProduct.Text = "Save Product"
        Me.cmdSaveProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSaveProduct.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ProductMixSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 608)
        Me.Controls.Add(Me.cmdSaveProduct)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ProductFreezingChart)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdRemoveProduct)
        Me.Controls.Add(Me.cmdAddProduct)
        Me.Controls.Add(Me.lstProductMix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProductMixSetup"
        Me.Text = "Product Mix Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ProductFreezingChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstProductMix As ListView
    Friend WithEvents cmdAddProduct As Button
    Friend WithEvents cmdRemoveProduct As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtStatDistr As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtStdDev As TextBox
    Friend WithEvents txtBoxFlowRate As TextBox
    Friend WithEvents txtBoxWeight As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ProductFreezingChart As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtSimGeom As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSimDiameter As TextBox
    Friend WithEvents txtSimWidth As TextBox
    Friend WithEvents txtSimLength As TextBox
    Friend WithEvents txtSimThickness As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label30 As Label
    Friend WithEvents lstProdModelProperties As ListView
    Friend WithEvents txtProductModel As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtConvCoeff As TextBox
    Friend WithEvents txtConvectionMultFactor As TextBox
    Friend WithEvents txtAirSpeed As TextBox
    Friend WithEvents txtMinStayTime As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtOutletTemp As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtInletTemp As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents cmdSaveProduct As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
