<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_Star_DebugWindow
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmdLast = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GenUpDn = New System.Windows.Forms.NumericUpDown()
        Me.dgvTableView = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMovements = New System.Windows.Forms.TextBox()
        Me.txtLevelsTraversed = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTimeTaken = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFitnessValue = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAccessFraction = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GenUpDn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTableView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAccessFraction)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFitnessValue)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTimeTaken)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLevelsTraversed)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMovements)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdLast)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GenUpDn)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvTableView)
        Me.SplitContainer1.Size = New System.Drawing.Size(627, 509)
        Me.SplitContainer1.SplitterDistance = 209
        Me.SplitContainer1.TabIndex = 0
        '
        'cmdLast
        '
        Me.cmdLast.Location = New System.Drawing.Point(154, 20)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(51, 20)
        Me.cmdLast.TabIndex = 2
        Me.cmdLast.Text = "Last"
        Me.cmdLast.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Generation"
        '
        'GenUpDn
        '
        Me.GenUpDn.Location = New System.Drawing.Point(92, 20)
        Me.GenUpDn.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.GenUpDn.Name = "GenUpDn"
        Me.GenUpDn.Size = New System.Drawing.Size(56, 20)
        Me.GenUpDn.TabIndex = 0
        '
        'dgvTableView
        '
        Me.dgvTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTableView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTableView.Location = New System.Drawing.Point(0, 0)
        Me.dgvTableView.Name = "dgvTableView"
        Me.dgvTableView.Size = New System.Drawing.Size(414, 509)
        Me.dgvTableView.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Movements:"
        '
        'txtMovements
        '
        Me.txtMovements.Enabled = False
        Me.txtMovements.Location = New System.Drawing.Point(102, 46)
        Me.txtMovements.Name = "txtMovements"
        Me.txtMovements.Size = New System.Drawing.Size(65, 20)
        Me.txtMovements.TabIndex = 1
        '
        'txtLevelsTraversed
        '
        Me.txtLevelsTraversed.Enabled = False
        Me.txtLevelsTraversed.Location = New System.Drawing.Point(110, 72)
        Me.txtLevelsTraversed.Name = "txtLevelsTraversed"
        Me.txtLevelsTraversed.Size = New System.Drawing.Size(57, 20)
        Me.txtLevelsTraversed.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Levels Traversed:"
        '
        'txtTimeTaken
        '
        Me.txtTimeTaken.Enabled = False
        Me.txtTimeTaken.Location = New System.Drawing.Point(102, 98)
        Me.txtTimeTaken.Name = "txtTimeTaken"
        Me.txtTimeTaken.Size = New System.Drawing.Size(65, 20)
        Me.txtTimeTaken.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Time Taken:"
        '
        'txtFitnessValue
        '
        Me.txtFitnessValue.Enabled = False
        Me.txtFitnessValue.Location = New System.Drawing.Point(102, 124)
        Me.txtFitnessValue.Name = "txtFitnessValue"
        Me.txtFitnessValue.Size = New System.Drawing.Size(65, 20)
        Me.txtFitnessValue.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fitness Value:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(173, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "h"
        '
        'txtAccessFraction
        '
        Me.txtAccessFraction.Enabled = False
        Me.txtAccessFraction.Location = New System.Drawing.Point(102, 150)
        Me.txtAccessFraction.Name = "txtAccessFraction"
        Me.txtAccessFraction.Size = New System.Drawing.Size(65, 20)
        Me.txtAccessFraction.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Access Fraction:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(173, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "%"
        '
        'A_Star_DebugWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 509)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "A_Star_DebugWindow"
        Me.Text = "A_Star_DebugWindow"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GenUpDn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTableView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents cmdLast As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GenUpDn As NumericUpDown
    Friend WithEvents dgvTableView As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFitnessValue As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTimeTaken As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLevelsTraversed As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMovements As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAccessFraction As TextBox
    Friend WithEvents Label7 As Label
End Class
