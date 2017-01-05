<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConveyorSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConveyorSetup))
        Me.lstConveyors = New System.Windows.Forms.ListView()
        Me.lstProducts = New System.Windows.Forms.ListView()
        Me.cmdRemoveConveyor = New System.Windows.Forms.Button()
        Me.cmdAddConveyor = New System.Windows.Forms.Button()
        Me.cmdSaveConveyor = New System.Windows.Forms.Button()
        Me.txtConveyorTag = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMinTime = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstConveyors
        '
        Me.lstConveyors.Location = New System.Drawing.Point(144, 12)
        Me.lstConveyors.Name = "lstConveyors"
        Me.lstConveyors.Size = New System.Drawing.Size(322, 125)
        Me.lstConveyors.TabIndex = 17
        Me.lstConveyors.UseCompatibleStateImageBehavior = False
        Me.lstConveyors.View = System.Windows.Forms.View.Details
        '
        'lstProducts
        '
        Me.lstProducts.Location = New System.Drawing.Point(259, 19)
        Me.lstProducts.Name = "lstProducts"
        Me.lstProducts.Size = New System.Drawing.Size(181, 171)
        Me.lstProducts.TabIndex = 18
        Me.lstProducts.UseCompatibleStateImageBehavior = False
        '
        'cmdRemoveConveyor
        '
        Me.cmdRemoveConveyor.Image = Global.VRTM_Simulator.My.Resources.Resources.list_remove_4
        Me.cmdRemoveConveyor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRemoveConveyor.Location = New System.Drawing.Point(12, 44)
        Me.cmdRemoveConveyor.Name = "cmdRemoveConveyor"
        Me.cmdRemoveConveyor.Size = New System.Drawing.Size(126, 26)
        Me.cmdRemoveConveyor.TabIndex = 16
        Me.cmdRemoveConveyor.Text = "Remove Conveyor"
        Me.cmdRemoveConveyor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRemoveConveyor.UseVisualStyleBackColor = True
        '
        'cmdAddConveyor
        '
        Me.cmdAddConveyor.Image = Global.VRTM_Simulator.My.Resources.Resources.edit_add_2
        Me.cmdAddConveyor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddConveyor.Location = New System.Drawing.Point(12, 12)
        Me.cmdAddConveyor.Name = "cmdAddConveyor"
        Me.cmdAddConveyor.Size = New System.Drawing.Size(126, 26)
        Me.cmdAddConveyor.TabIndex = 15
        Me.cmdAddConveyor.Text = "Add Conveyor"
        Me.cmdAddConveyor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddConveyor.UseVisualStyleBackColor = True
        '
        'cmdSaveConveyor
        '
        Me.cmdSaveConveyor.Image = Global.VRTM_Simulator.My.Resources.Resources.document_save_5
        Me.cmdSaveConveyor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSaveConveyor.Location = New System.Drawing.Point(314, 199)
        Me.cmdSaveConveyor.Name = "cmdSaveConveyor"
        Me.cmdSaveConveyor.Size = New System.Drawing.Size(126, 33)
        Me.cmdSaveConveyor.TabIndex = 22
        Me.cmdSaveConveyor.Text = "Save Conveyor"
        Me.cmdSaveConveyor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSaveConveyor.UseVisualStyleBackColor = True
        '
        'txtConveyorTag
        '
        Me.txtConveyorTag.Location = New System.Drawing.Point(143, 19)
        Me.txtConveyorTag.Name = "txtConveyorTag"
        Me.txtConveyorTag.Size = New System.Drawing.Size(97, 20)
        Me.txtConveyorTag.TabIndex = 24
        Me.txtConveyorTag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Conveyor Tag:"
        '
        'txtMinTime
        '
        Me.txtMinTime.Location = New System.Drawing.Point(143, 44)
        Me.txtMinTime.Name = "txtMinTime"
        Me.txtMinTime.Size = New System.Drawing.Size(78, 20)
        Me.txtMinTime.TabIndex = 26
        Me.txtMinTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Minimum Retention Time:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lstProducts)
        Me.GroupBox1.Controls.Add(Me.cmdSaveConveyor)
        Me.GroupBox1.Controls.Add(Me.txtConveyorTag)
        Me.GroupBox1.Controls.Add(Me.txtMinTime)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 143)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 245)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(227, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "h"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmConveyorSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 395)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdRemoveConveyor)
        Me.Controls.Add(Me.cmdAddConveyor)
        Me.Controls.Add(Me.lstConveyors)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConveyorSetup"
        Me.Text = "Conveyor Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdRemoveConveyor As Button
    Friend WithEvents cmdAddConveyor As Button
    Friend WithEvents lstConveyors As ListView
    Friend WithEvents lstProducts As ListView
    Friend WithEvents cmdSaveConveyor As Button
    Friend WithEvents txtConveyorTag As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMinTime As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
