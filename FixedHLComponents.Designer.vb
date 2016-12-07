<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FixedHLComponents
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FixedHLComponents))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtWallMaterial = New System.Windows.Forms.ComboBox()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.txtOuterT = New System.Windows.Forms.TextBox()
        Me.txtWallThickness = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInnerT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtHoursIllum = New System.Windows.Forms.TextBox()
        Me.txtHoursMotor = New System.Windows.Forms.TextBox()
        Me.txtIllumination = New System.Windows.Forms.TextBox()
        Me.txtTotalMotorPower = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtVolChanges = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtFixedHeatLoad = New System.Windows.Forms.TextBox()
        Me.txtInfiltrationPower = New System.Windows.Forms.TextBox()
        Me.txtEquipmentPower = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtConductionPower = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtWallMaterial)
        Me.GroupBox1.Controls.Add(Me.txtLength)
        Me.GroupBox1.Controls.Add(Me.txtWidth)
        Me.GroupBox1.Controls.Add(Me.txtOuterT)
        Me.GroupBox1.Controls.Add(Me.txtWallThickness)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtInnerT)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtHeight)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(402, 303)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "1. Conduction Through Walls"
        '
        'txtWallMaterial
        '
        Me.txtWallMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtWallMaterial.FormattingEnabled = True
        Me.txtWallMaterial.Items.AddRange(New Object() {"PUR", "EPS"})
        Me.txtWallMaterial.Location = New System.Drawing.Point(108, 250)
        Me.txtWallMaterial.Name = "txtWallMaterial"
        Me.txtWallMaterial.Size = New System.Drawing.Size(100, 21)
        Me.txtWallMaterial.TabIndex = 5
        '
        'txtLength
        '
        Me.txtLength.Location = New System.Drawing.Point(215, 209)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(60, 20)
        Me.txtLength.TabIndex = 4
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(73, 218)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(60, 20)
        Me.txtWidth.TabIndex = 4
        '
        'txtOuterT
        '
        Me.txtOuterT.Location = New System.Drawing.Point(315, 101)
        Me.txtOuterT.Name = "txtOuterT"
        Me.txtOuterT.Size = New System.Drawing.Size(60, 20)
        Me.txtOuterT.TabIndex = 4
        '
        'txtWallThickness
        '
        Me.txtWallThickness.Location = New System.Drawing.Point(108, 275)
        Me.txtWallThickness.Name = "txtWallThickness"
        Me.txtWallThickness.Size = New System.Drawing.Size(71, 20)
        Me.txtWallThickness.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(300, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Outside Temp. [ºC]"
        '
        'txtInnerT
        '
        Me.txtInnerT.Enabled = False
        Me.txtInnerT.Location = New System.Drawing.Point(166, 106)
        Me.txtInnerT.Name = "txtInnerT"
        Me.txtInnerT.Size = New System.Drawing.Size(60, 20)
        Me.txtInnerT.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(152, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Inside Temp. [ºC]"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(185, 277)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(23, 13)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "mm"
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(11, 101)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(60, 20)
        Me.txtHeight.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Height [mm]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Length [mm]"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 279)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(83, 13)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Wall Thickness:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Width [mm]"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(9, 254)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 13)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Wall Material:"
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = Global.VRTM_Simulator.My.Resources.Resources.Tunnel_Size2
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(50, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(277, 226)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtHoursIllum)
        Me.GroupBox2.Controls.Add(Me.txtHoursMotor)
        Me.GroupBox2.Controls.Add(Me.txtIllumination)
        Me.GroupBox2.Controls.Add(Me.txtTotalMotorPower)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 322)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 148)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "2. Electrical Equipment"
        '
        'txtHoursIllum
        '
        Me.txtHoursIllum.Location = New System.Drawing.Point(204, 106)
        Me.txtHoursIllum.Name = "txtHoursIllum"
        Me.txtHoursIllum.Size = New System.Drawing.Size(71, 20)
        Me.txtHoursIllum.TabIndex = 4
        '
        'txtHoursMotor
        '
        Me.txtHoursMotor.Location = New System.Drawing.Point(204, 48)
        Me.txtHoursMotor.Name = "txtHoursMotor"
        Me.txtHoursMotor.Size = New System.Drawing.Size(71, 20)
        Me.txtHoursMotor.TabIndex = 4
        '
        'txtIllumination
        '
        Me.txtIllumination.Location = New System.Drawing.Point(204, 83)
        Me.txtIllumination.Name = "txtIllumination"
        Me.txtIllumination.Size = New System.Drawing.Size(71, 20)
        Me.txtIllumination.TabIndex = 4
        '
        'txtTotalMotorPower
        '
        Me.txtTotalMotorPower.Location = New System.Drawing.Point(204, 25)
        Me.txtTotalMotorPower.Name = "txtTotalMotorPower"
        Me.txtTotalMotorPower.Size = New System.Drawing.Size(71, 20)
        Me.txtTotalMotorPower.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(179, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Number of Operative Hours per Day:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(281, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "h"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Number of Operative Hours per Day:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(281, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "W/m²"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(281, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "h"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(138, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Illumination Power per Area:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(281, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "kW"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(186, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Total Motor Power Installed (no Fans):"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtVolChanges)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 476)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(402, 62)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "3. Air Infiltration"
        '
        'txtVolChanges
        '
        Me.txtVolChanges.Enabled = False
        Me.txtVolChanges.Location = New System.Drawing.Point(204, 25)
        Me.txtVolChanges.Name = "txtVolChanges"
        Me.txtVolChanges.Size = New System.Drawing.Size(71, 20)
        Me.txtVolChanges.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(281, 29)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "full volumes/day"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 29)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(116, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Daily Volume Changes:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtFixedHeatLoad)
        Me.GroupBox4.Controls.Add(Me.txtInfiltrationPower)
        Me.GroupBox4.Controls.Add(Me.txtEquipmentPower)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.txtConductionPower)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Location = New System.Drawing.Point(424, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(313, 525)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Results"
        '
        'txtFixedHeatLoad
        '
        Me.txtFixedHeatLoad.Enabled = False
        Me.txtFixedHeatLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFixedHeatLoad.Location = New System.Drawing.Point(200, 107)
        Me.txtFixedHeatLoad.Name = "txtFixedHeatLoad"
        Me.txtFixedHeatLoad.Size = New System.Drawing.Size(56, 20)
        Me.txtFixedHeatLoad.TabIndex = 4
        Me.txtFixedHeatLoad.Text = "10"
        '
        'txtInfiltrationPower
        '
        Me.txtInfiltrationPower.Enabled = False
        Me.txtInfiltrationPower.Location = New System.Drawing.Point(200, 71)
        Me.txtInfiltrationPower.Name = "txtInfiltrationPower"
        Me.txtInfiltrationPower.Size = New System.Drawing.Size(56, 20)
        Me.txtInfiltrationPower.TabIndex = 4
        '
        'txtEquipmentPower
        '
        Me.txtEquipmentPower.Enabled = False
        Me.txtEquipmentPower.Location = New System.Drawing.Point(200, 48)
        Me.txtEquipmentPower.Name = "txtEquipmentPower"
        Me.txtEquipmentPower.Size = New System.Drawing.Size(56, 20)
        Me.txtEquipmentPower.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 111)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(171, 13)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Total Fixed Heat Load Considered:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 75)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(176, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "3. Average Power due to Infiltration:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(266, 110)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(26, 13)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "kW"
        '
        'txtConductionPower
        '
        Me.txtConductionPower.Enabled = False
        Me.txtConductionPower.Location = New System.Drawing.Point(200, 25)
        Me.txtConductionPower.Name = "txtConductionPower"
        Me.txtConductionPower.Size = New System.Drawing.Size(56, 20)
        Me.txtConductionPower.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(266, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "kW"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(181, 13)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "2. Average Power due to Equipment:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(266, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "kW"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(185, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "1. Average Power due to Conduction:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(266, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "kW"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FixedHLComponents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 550)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FixedHLComponents"
        Me.Text = "Fixed Heat Load Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtLength As TextBox
    Friend WithEvents txtWidth As TextBox
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents txtOuterT As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtHoursMotor As TextBox
    Friend WithEvents txtTotalMotorPower As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtHoursIllum As TextBox
    Friend WithEvents txtIllumination As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtVolChanges As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtFixedHeatLoad As TextBox
    Friend WithEvents txtInfiltrationPower As TextBox
    Friend WithEvents txtEquipmentPower As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtConductionPower As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtInnerT As TextBox
    Friend WithEvents txtWallMaterial As ComboBox
    Friend WithEvents txtWallThickness As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
