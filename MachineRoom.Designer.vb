<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MachineRoom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MachineRoom))
        Me.lstCompressor = New System.Windows.Forms.ListView()
        Me.cmdRemoveComp = New System.Windows.Forms.Button()
        Me.cmdAddComp = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtVolDispm3h = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtRPM = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmdSaveComp = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIntermTemp = New System.Windows.Forms.TextBox()
        Me.opTwoStage = New System.Windows.Forms.RadioButton()
        Me.opOneStageNoEco = New System.Windows.Forms.RadioButton()
        Me.opOneStageWithEco = New System.Windows.Forms.RadioButton()
        Me.txtEstimatedCap = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbSelCompressor = New System.Windows.Forms.ComboBox()
        Me.txtVolEff = New System.Windows.Forms.TextBox()
        Me.txtVolDisp = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstCompressor
        '
        Me.lstCompressor.Location = New System.Drawing.Point(12, 60)
        Me.lstCompressor.Name = "lstCompressor"
        Me.lstCompressor.Size = New System.Drawing.Size(290, 224)
        Me.lstCompressor.TabIndex = 15
        Me.lstCompressor.UseCompatibleStateImageBehavior = False
        '
        'cmdRemoveComp
        '
        Me.cmdRemoveComp.Image = Global.VRTM_Simulator.My.Resources.Resources.list_remove_4
        Me.cmdRemoveComp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRemoveComp.Location = New System.Drawing.Point(163, 12)
        Me.cmdRemoveComp.Name = "cmdRemoveComp"
        Me.cmdRemoveComp.Size = New System.Drawing.Size(145, 26)
        Me.cmdRemoveComp.TabIndex = 14
        Me.cmdRemoveComp.Text = "Remove Compressor"
        Me.cmdRemoveComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRemoveComp.UseVisualStyleBackColor = True
        '
        'cmdAddComp
        '
        Me.cmdAddComp.Image = Global.VRTM_Simulator.My.Resources.Resources.edit_add_2
        Me.cmdAddComp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddComp.Location = New System.Drawing.Point(12, 12)
        Me.cmdAddComp.Name = "cmdAddComp"
        Me.cmdAddComp.Size = New System.Drawing.Size(145, 26)
        Me.cmdAddComp.TabIndex = 13
        Me.cmdAddComp.Text = "Add Compressor"
        Me.cmdAddComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddComp.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtVolDispm3h)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtRPM)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtQty)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmdSaveComp)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtIntermTemp)
        Me.GroupBox1.Controls.Add(Me.opTwoStage)
        Me.GroupBox1.Controls.Add(Me.opOneStageNoEco)
        Me.GroupBox1.Controls.Add(Me.opOneStageWithEco)
        Me.GroupBox1.Controls.Add(Me.txtEstimatedCap)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbSelCompressor)
        Me.GroupBox1.Controls.Add(Me.txtVolEff)
        Me.GroupBox1.Controls.Add(Me.txtVolDisp)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 290)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 355)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Compressor Setup"
        '
        'txtVolDispm3h
        '
        Me.txtVolDispm3h.Enabled = False
        Me.txtVolDispm3h.Location = New System.Drawing.Point(168, 124)
        Me.txtVolDispm3h.Name = "txtVolDispm3h"
        Me.txtVolDispm3h.Size = New System.Drawing.Size(58, 20)
        Me.txtVolDispm3h.TabIndex = 4
        Me.txtVolDispm3h.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(232, 127)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "m³/h"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(126, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Volumetric Displacement:"
        '
        'txtRPM
        '
        Me.txtRPM.Location = New System.Drawing.Point(168, 100)
        Me.txtRPM.Name = "txtRPM"
        Me.txtRPM.Size = New System.Drawing.Size(58, 20)
        Me.txtRPM.TabIndex = 3
        Me.txtRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(232, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "rpm"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Rotation:"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(168, 52)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(58, 20)
        Me.txtQty.TabIndex = 1
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(232, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 13)
        Me.Label12.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Quantity:"
        '
        'cmdSaveComp
        '
        Me.cmdSaveComp.Image = Global.VRTM_Simulator.My.Resources.Resources.document_save_5
        Me.cmdSaveComp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSaveComp.Location = New System.Drawing.Point(158, 314)
        Me.cmdSaveComp.Name = "cmdSaveComp"
        Me.cmdSaveComp.Size = New System.Drawing.Size(126, 33)
        Me.cmdSaveComp.TabIndex = 11
        Me.cmdSaveComp.Text = "Save Compressor"
        Me.cmdSaveComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSaveComp.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 284)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Intermediate Temperature:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(232, 284)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "ºC"
        '
        'txtIntermTemp
        '
        Me.txtIntermTemp.Enabled = False
        Me.txtIntermTemp.Location = New System.Drawing.Point(168, 281)
        Me.txtIntermTemp.Name = "txtIntermTemp"
        Me.txtIntermTemp.Size = New System.Drawing.Size(58, 20)
        Me.txtIntermTemp.TabIndex = 10
        Me.txtIntermTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'opTwoStage
        '
        Me.opTwoStage.AutoSize = True
        Me.opTwoStage.Location = New System.Drawing.Point(10, 255)
        Me.opTwoStage.Name = "opTwoStage"
        Me.opTwoStage.Size = New System.Drawing.Size(116, 17)
        Me.opTwoStage.TabIndex = 9
        Me.opTwoStage.Text = "Two-Stage Booster"
        Me.opTwoStage.UseVisualStyleBackColor = True
        '
        'opOneStageNoEco
        '
        Me.opOneStageNoEco.AutoSize = True
        Me.opOneStageNoEco.Checked = True
        Me.opOneStageNoEco.Location = New System.Drawing.Point(10, 209)
        Me.opOneStageNoEco.Name = "opOneStageNoEco"
        Me.opOneStageNoEco.Size = New System.Drawing.Size(171, 17)
        Me.opOneStageNoEco.TabIndex = 7
        Me.opOneStageNoEco.TabStop = True
        Me.opOneStageNoEco.Text = "One-Stage without Economizer"
        Me.opOneStageNoEco.UseVisualStyleBackColor = True
        '
        'opOneStageWithEco
        '
        Me.opOneStageWithEco.AutoSize = True
        Me.opOneStageWithEco.Enabled = False
        Me.opOneStageWithEco.Location = New System.Drawing.Point(10, 232)
        Me.opOneStageWithEco.Name = "opOneStageWithEco"
        Me.opOneStageWithEco.Size = New System.Drawing.Size(156, 17)
        Me.opOneStageWithEco.TabIndex = 8
        Me.opOneStageWithEco.Text = "One-Stage with Economizer"
        Me.opOneStageWithEco.UseVisualStyleBackColor = True
        '
        'txtEstimatedCap
        '
        Me.txtEstimatedCap.Enabled = False
        Me.txtEstimatedCap.Location = New System.Drawing.Point(168, 172)
        Me.txtEstimatedCap.Name = "txtEstimatedCap"
        Me.txtEstimatedCap.Size = New System.Drawing.Size(58, 20)
        Me.txtEstimatedCap.TabIndex = 6
        Me.txtEstimatedCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(232, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "kW"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Estimated Capacity@SP (Each):"
        '
        'cmbSelCompressor
        '
        Me.cmbSelCompressor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelCompressor.FormattingEnabled = True
        Me.cmbSelCompressor.Location = New System.Drawing.Point(123, 20)
        Me.cmbSelCompressor.Name = "cmbSelCompressor"
        Me.cmbSelCompressor.Size = New System.Drawing.Size(132, 21)
        Me.cmbSelCompressor.TabIndex = 0
        '
        'txtVolEff
        '
        Me.txtVolEff.Location = New System.Drawing.Point(168, 148)
        Me.txtVolEff.Name = "txtVolEff"
        Me.txtVolEff.Size = New System.Drawing.Size(58, 20)
        Me.txtVolEff.TabIndex = 5
        Me.txtVolEff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVolDisp
        '
        Me.txtVolDisp.Location = New System.Drawing.Point(168, 76)
        Me.txtVolDisp.Name = "txtVolDisp"
        Me.txtVolDisp.Size = New System.Drawing.Size(58, 20)
        Me.txtVolDisp.TabIndex = 2
        Me.txtVolDisp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(232, 151)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(15, 13)
        Me.Label37.TabIndex = 6
        Me.Label37.Text = "%"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(232, 79)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(38, 13)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = "m³/rev"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Volumetric Efficiency:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Volumetric Displacement:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selected Compressor:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(256, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Compressor List (Only compressors used in the VRT):"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 648)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(275, 52)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Important Observation: This machine room simulation " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is approximate. It won't re" &
    "place the need for an accurate," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "more complete compressor selection with the sup" &
    "plier's" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "software."
        '
        'MachineRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 708)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdRemoveComp)
        Me.Controls.Add(Me.cmdAddComp)
        Me.Controls.Add(Me.lstCompressor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MachineRoom"
        Me.Text = "Machine Room Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstCompressor As ListView
    Friend WithEvents cmdRemoveComp As Button
    Friend WithEvents cmdAddComp As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtVolEff As TextBox
    Friend WithEvents txtVolDisp As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSelCompressor As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtIntermTemp As TextBox
    Friend WithEvents opTwoStage As RadioButton
    Friend WithEvents opOneStageNoEco As RadioButton
    Friend WithEvents opOneStageWithEco As RadioButton
    Friend WithEvents txtEstimatedCap As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdSaveComp As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRPM As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtVolDispm3h As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
End Class
