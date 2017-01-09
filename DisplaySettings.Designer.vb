<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisplaySettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisplaySettings))
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pcbHighlight = New System.Windows.Forms.PictureBox()
        Me.chkHighlight = New System.Windows.Forms.CheckBox()
        Me.txtDisplayParam = New System.Windows.Forms.ComboBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pcbMaxBG = New System.Windows.Forms.PictureBox()
        Me.pcbMaxText = New System.Windows.Forms.PictureBox()
        Me.pcbGradBG = New System.Windows.Forms.PictureBox()
        Me.pcbGradText = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pcbMinBG = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pcbMinText = New System.Windows.Forms.PictureBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.txtTextColor = New System.Windows.Forms.ComboBox()
        Me.txtBGColor = New System.Windows.Forms.ComboBox()
        CType(Me.pcbHighlight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbMaxBG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbMaxText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbGradBG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbGradText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbMinBG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbMinText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox10
        '
        Me.GroupBox10.Location = New System.Drawing.Point(58, 457)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(302, 84)
        Me.GroupBox10.TabIndex = 6
        Me.GroupBox10.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Highlight Color:"
        '
        'pcbHighlight
        '
        Me.pcbHighlight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbHighlight.Location = New System.Drawing.Point(16, 178)
        Me.pcbHighlight.Name = "pcbHighlight"
        Me.pcbHighlight.Size = New System.Drawing.Size(74, 32)
        Me.pcbHighlight.TabIndex = 63
        Me.pcbHighlight.TabStop = False
        '
        'chkHighlight
        '
        Me.chkHighlight.AutoSize = True
        Me.chkHighlight.Location = New System.Drawing.Point(11, 138)
        Me.chkHighlight.Name = "chkHighlight"
        Me.chkHighlight.Size = New System.Drawing.Size(160, 17)
        Me.chkHighlight.TabIndex = 62
        Me.chkHighlight.Text = "Highlight Current Load Level"
        Me.chkHighlight.UseVisualStyleBackColor = True
        '
        'txtDisplayParam
        '
        Me.txtDisplayParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtDisplayParam.FormattingEnabled = True
        Me.txtDisplayParam.Items.AddRange(New Object() {"Tray Index", "Conveyor Index", "Retention Time", "Center Temp.", "Surface Temp.", "Power Released"})
        Me.txtDisplayParam.Location = New System.Drawing.Point(139, 12)
        Me.txtDisplayParam.Name = "txtDisplayParam"
        Me.txtDisplayParam.Size = New System.Drawing.Size(175, 21)
        Me.txtDisplayParam.TabIndex = 63
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(12, 15)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(95, 13)
        Me.Label55.TabIndex = 2
        Me.Label55.Text = "Display Parameter:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.pcbHighlight)
        Me.GroupBox1.Controls.Add(Me.txtBGColor)
        Me.GroupBox1.Controls.Add(Me.txtTextColor)
        Me.GroupBox1.Controls.Add(Me.chkHighlight)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.pcbMaxBG)
        Me.GroupBox1.Controls.Add(Me.pcbMaxText)
        Me.GroupBox1.Controls.Add(Me.pcbGradBG)
        Me.GroupBox1.Controls.Add(Me.pcbGradText)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.pcbMinBG)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.pcbMinText)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(465, 231)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Table Dynamic Color Settings"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "BG Colorscale:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Text Colorscale:"
        '
        'pcbMaxBG
        '
        Me.pcbMaxBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbMaxBG.Location = New System.Drawing.Point(259, 67)
        Me.pcbMaxBG.Name = "pcbMaxBG"
        Me.pcbMaxBG.Size = New System.Drawing.Size(30, 20)
        Me.pcbMaxBG.TabIndex = 64
        Me.pcbMaxBG.TabStop = False
        '
        'pcbMaxText
        '
        Me.pcbMaxText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbMaxText.Location = New System.Drawing.Point(259, 41)
        Me.pcbMaxText.Name = "pcbMaxText"
        Me.pcbMaxText.Size = New System.Drawing.Size(30, 20)
        Me.pcbMaxText.TabIndex = 64
        Me.pcbMaxText.TabStop = False
        '
        'pcbGradBG
        '
        Me.pcbGradBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbGradBG.Location = New System.Drawing.Point(131, 67)
        Me.pcbGradBG.Name = "pcbGradBG"
        Me.pcbGradBG.Size = New System.Drawing.Size(129, 20)
        Me.pcbGradBG.TabIndex = 65
        Me.pcbGradBG.TabStop = False
        '
        'pcbGradText
        '
        Me.pcbGradText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbGradText.Location = New System.Drawing.Point(131, 41)
        Me.pcbGradText.Name = "pcbGradText"
        Me.pcbGradText.Size = New System.Drawing.Size(129, 20)
        Me.pcbGradText.TabIndex = 65
        Me.pcbGradText.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Maximum:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pcbMinBG
        '
        Me.pcbMinBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbMinBG.Location = New System.Drawing.Point(102, 67)
        Me.pcbMinBG.Name = "pcbMinBG"
        Me.pcbMinBG.Size = New System.Drawing.Size(30, 20)
        Me.pcbMinBG.TabIndex = 63
        Me.pcbMinBG.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(99, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Minimum:"
        '
        'pcbMinText
        '
        Me.pcbMinText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcbMinText.Location = New System.Drawing.Point(102, 41)
        Me.pcbMinText.Name = "pcbMinText"
        Me.pcbMinText.Size = New System.Drawing.Size(30, 20)
        Me.pcbMinText.TabIndex = 63
        Me.pcbMinText.TabStop = False
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 2
        '
        'txtTextColor
        '
        Me.txtTextColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtTextColor.FormattingEnabled = True
        Me.txtTextColor.Items.AddRange(New Object() {"Tray Index", "Conveyor Index", "Retention Time", "Center Temp.", "Surface Temp.", "Power Released", "Frozen/Not Frozen", "Fixed Color (Minimum)"})
        Me.txtTextColor.Location = New System.Drawing.Point(297, 40)
        Me.txtTextColor.Name = "txtTextColor"
        Me.txtTextColor.Size = New System.Drawing.Size(150, 21)
        Me.txtTextColor.TabIndex = 67
        '
        'txtBGColor
        '
        Me.txtBGColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtBGColor.FormattingEnabled = True
        Me.txtBGColor.Items.AddRange(New Object() {"Tray Index", "Conveyor Index", "Retention Time", "Center Temp.", "Surface Temp.", "Power Released", "Frozen/Not Frozen", "Fixed Color (Minimum)"})
        Me.txtBGColor.Location = New System.Drawing.Point(297, 66)
        Me.txtBGColor.Name = "txtBGColor"
        Me.txtBGColor.Size = New System.Drawing.Size(150, 21)
        Me.txtBGColor.TabIndex = 67
        '
        'frmDisplaySettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 282)
        Me.Controls.Add(Me.txtDisplayParam)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.Label55)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDisplaySettings"
        Me.Text = "Display Settings"
        CType(Me.pcbHighlight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbMaxBG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbMaxText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbGradBG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbGradText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbMinBG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbMinText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents txtDisplayParam As ComboBox
    Friend WithEvents chkHighlight As CheckBox
    Friend WithEvents Label55 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pcbHighlight As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pcbMaxText As PictureBox
    Friend WithEvents pcbGradText As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pcbMinText As PictureBox
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Timer As Timer
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pcbMaxBG As PictureBox
    Friend WithEvents pcbGradBG As PictureBox
    Friend WithEvents pcbMinBG As PictureBox
    Friend WithEvents txtBGColor As ComboBox
    Friend WithEvents txtTextColor As ComboBox
End Class
