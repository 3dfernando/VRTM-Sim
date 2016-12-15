<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.Divisor1 = New System.Windows.Forms.SplitContainer()
        Me.LeftPanel = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnReduceSpeed = New System.Windows.Forms.ToolStripButton()
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.btnPlay = New System.Windows.Forms.ToolStripButton()
        Me.btnIncreaseSpeed = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblTimeWarp = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSimulationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveSimulationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SimulationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunProcessSimulationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunThermalSimulationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaybackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReduceSpeedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncreaseSpeedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DisplayParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.VRTMParams = New System.Windows.Forms.TabPage()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cmdCopyMachineRoom = New System.Windows.Forms.Button()
        Me.txtSchVRTMEnd = New System.Windows.Forms.MaskedTextBox()
        Me.txtSchVRTMBegin = New System.Windows.Forms.MaskedTextBox()
        Me.chkSundayVRTM = New System.Windows.Forms.CheckBox()
        Me.chkSaturdayVRTM = New System.Windows.Forms.CheckBox()
        Me.chkFridayVRTM = New System.Windows.Forms.CheckBox()
        Me.chkThursdayVRTM = New System.Windows.Forms.CheckBox()
        Me.chkWednesdayVRTM = New System.Windows.Forms.CheckBox()
        Me.chkTuesdayVRTM = New System.Windows.Forms.CheckBox()
        Me.chkMondayVRTM = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStCap = New System.Windows.Forms.TextBox()
        Me.txtBoxesPerTray = New System.Windows.Forms.TextBox()
        Me.txtNTrays = New System.Windows.Forms.TextBox()
        Me.txtNLevels = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtGlobalHX = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEvapSurf = New System.Windows.Forms.TextBox()
        Me.cmdHLEdit = New System.Windows.Forms.Button()
        Me.txtFanPower = New System.Windows.Forms.TextBox()
        Me.txtFanFlow = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHL = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MachRoom = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmdCopyVRTM = New System.Windows.Forms.Button()
        Me.txtIdleHourEndsMR = New System.Windows.Forms.MaskedTextBox()
        Me.txtIdleHourBeginMR = New System.Windows.Forms.MaskedTextBox()
        Me.chkSundayMR = New System.Windows.Forms.CheckBox()
        Me.chkSaturdayMR = New System.Windows.Forms.CheckBox()
        Me.chkFridayMR = New System.Windows.Forms.CheckBox()
        Me.chkThursdayMR = New System.Windows.Forms.CheckBox()
        Me.chkWednesdayMR = New System.Windows.Forms.CheckBox()
        Me.chkTuesdayMR = New System.Windows.Forms.CheckBox()
        Me.chkMondayMR = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdMRSetup = New System.Windows.Forms.Button()
        Me.txtReferenceCapacity = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTevapSP = New System.Windows.Forms.TextBox()
        Me.txtTCond = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Production = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.chkSecondTurn = New System.Windows.Forms.CheckBox()
        Me.txtSecondTurnEnds = New System.Windows.Forms.MaskedTextBox()
        Me.txtSecondTurnBegins = New System.Windows.Forms.MaskedTextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.chkFirstTurn = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtFirstTurnEnds = New System.Windows.Forms.MaskedTextBox()
        Me.txtFirstTurnBegins = New System.Windows.Forms.MaskedTextBox()
        Me.chkSundayProd = New System.Windows.Forms.CheckBox()
        Me.chkSaturdayProd = New System.Windows.Forms.CheckBox()
        Me.chkFridayProd = New System.Windows.Forms.CheckBox()
        Me.chkThursdayProd = New System.Windows.Forms.CheckBox()
        Me.chkWednesdayProd = New System.Windows.Forms.CheckBox()
        Me.chkTuesdayProd = New System.Windows.Forms.CheckBox()
        Me.chkMondayProd = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtWeeklyHeatLoad = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtSafetyFactorVRTM = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAvgHeatLoad = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtAvgMassFlowIn = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmdPrdMixSetup = New System.Windows.Forms.Button()
        Me.txtAvgBoxMass = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAvgBoxflowIn = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ProdStats = New System.Windows.Forms.TabPage()
        Me.SimParams = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtAcceptedDt = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtTotalSimTime = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtMinimumSimDT = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Divisor2 = New System.Windows.Forms.SplitContainer()
        Me.MidPanel = New System.Windows.Forms.SplitContainer()
        Me.lblDisplayVariable = New System.Windows.Forms.Label()
        Me.lblCurrentPos = New System.Windows.Forms.Label()
        Me.hsSimPosition = New System.Windows.Forms.HScrollBar()
        Me.VRTMTable = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProvider2 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tmrPlayback = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Divisor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Divisor1.Panel1.SuspendLayout()
        Me.Divisor1.Panel2.SuspendLayout()
        Me.Divisor1.SuspendLayout()
        CType(Me.LeftPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LeftPanel.Panel1.SuspendLayout()
        Me.LeftPanel.Panel2.SuspendLayout()
        Me.LeftPanel.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.VRTMParams.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MachRoom.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Production.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SimParams.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.Divisor2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Divisor2.Panel1.SuspendLayout()
        Me.Divisor2.SuspendLayout()
        CType(Me.MidPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MidPanel.Panel1.SuspendLayout()
        Me.MidPanel.Panel2.SuspendLayout()
        Me.MidPanel.SuspendLayout()
        CType(Me.VRTMTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Divisor1
        '
        Me.Divisor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Divisor1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.Divisor1.Location = New System.Drawing.Point(0, 0)
        Me.Divisor1.Margin = New System.Windows.Forms.Padding(4)
        Me.Divisor1.Name = "Divisor1"
        '
        'Divisor1.Panel1
        '
        Me.Divisor1.Panel1.Controls.Add(Me.LeftPanel)
        '
        'Divisor1.Panel2
        '
        Me.Divisor1.Panel2.Controls.Add(Me.Divisor2)
        Me.Divisor1.Size = New System.Drawing.Size(1552, 975)
        Me.Divisor1.SplitterDistance = 324
        Me.Divisor1.SplitterWidth = 5
        Me.Divisor1.TabIndex = 1
        '
        'LeftPanel
        '
        Me.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeftPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.LeftPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.LeftPanel.Name = "LeftPanel"
        Me.LeftPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'LeftPanel.Panel1
        '
        Me.LeftPanel.Panel1.Controls.Add(Me.ToolStrip1)
        Me.LeftPanel.Panel1.Controls.Add(Me.MenuStrip1)
        '
        'LeftPanel.Panel2
        '
        Me.LeftPanel.Panel2.Controls.Add(Me.TabControl1)
        Me.LeftPanel.Size = New System.Drawing.Size(324, 975)
        Me.LeftPanel.SplitterDistance = 52
        Me.LeftPanel.SplitterWidth = 5
        Me.LeftPanel.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnReduceSpeed, Me.btnStop, Me.btnPlay, Me.btnIncreaseSpeed, Me.ToolStripSeparator2, Me.lblTimeWarp, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(324, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnReduceSpeed
        '
        Me.btnReduceSpeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReduceSpeed.Image = Global.VRTM_Simulator.My.Resources.Resources.media_seek_backward_3
        Me.btnReduceSpeed.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReduceSpeed.Name = "btnReduceSpeed"
        Me.btnReduceSpeed.Size = New System.Drawing.Size(24, 24)
        Me.btnReduceSpeed.Text = "Decrease Speed"
        '
        'btnStop
        '
        Me.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStop.Image = Global.VRTM_Simulator.My.Resources.Resources.media_playback_stop_3
        Me.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(24, 24)
        Me.btnStop.Text = "Stop Simulation"
        '
        'btnPlay
        '
        Me.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPlay.Image = Global.VRTM_Simulator.My.Resources.Resources.media_playback_start_3
        Me.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(24, 24)
        Me.btnPlay.Text = "ToolStripButton5"
        Me.btnPlay.ToolTipText = "Play Simulation"
        '
        'btnIncreaseSpeed
        '
        Me.btnIncreaseSpeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnIncreaseSpeed.Image = Global.VRTM_Simulator.My.Resources.Resources.media_seek_forward_3
        Me.btnIncreaseSpeed.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnIncreaseSpeed.Name = "btnIncreaseSpeed"
        Me.btnIncreaseSpeed.Size = New System.Drawing.Size(24, 24)
        Me.btnIncreaseSpeed.Text = "Increase Speed"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'lblTimeWarp
        '
        Me.lblTimeWarp.Name = "lblTimeWarp"
        Me.lblTimeWarp.Size = New System.Drawing.Size(52, 24)
        Me.lblTimeWarp.Text = "1,0 h/s"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SimulationToolStripMenuItem, Me.PlaybackToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(324, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenSimulationToolStripMenuItem, Me.SaveSimulationToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenSimulationToolStripMenuItem
        '
        Me.OpenSimulationToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.document_open_5
        Me.OpenSimulationToolStripMenuItem.Name = "OpenSimulationToolStripMenuItem"
        Me.OpenSimulationToolStripMenuItem.Size = New System.Drawing.Size(195, 26)
        Me.OpenSimulationToolStripMenuItem.Text = "&Open Simulation"
        '
        'SaveSimulationToolStripMenuItem
        '
        Me.SaveSimulationToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.document_save_5
        Me.SaveSimulationToolStripMenuItem.Name = "SaveSimulationToolStripMenuItem"
        Me.SaveSimulationToolStripMenuItem.Size = New System.Drawing.Size(195, 26)
        Me.SaveSimulationToolStripMenuItem.Text = "&Save Simulation"
        '
        'SimulationToolStripMenuItem
        '
        Me.SimulationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunProcessSimulationToolStripMenuItem, Me.RunThermalSimulationToolStripMenuItem})
        Me.SimulationToolStripMenuItem.Name = "SimulationToolStripMenuItem"
        Me.SimulationToolStripMenuItem.Size = New System.Drawing.Size(92, 24)
        Me.SimulationToolStripMenuItem.Text = "Si&mulation"
        '
        'RunProcessSimulationToolStripMenuItem
        '
        Me.RunProcessSimulationToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.script_gear
        Me.RunProcessSimulationToolStripMenuItem.Name = "RunProcessSimulationToolStripMenuItem"
        Me.RunProcessSimulationToolStripMenuItem.Size = New System.Drawing.Size(242, 26)
        Me.RunProcessSimulationToolStripMenuItem.Text = "Run Process Simulation"
        '
        'RunThermalSimulationToolStripMenuItem
        '
        Me.RunThermalSimulationToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.pictograms_hazard_signs_xtremely_flammable
        Me.RunThermalSimulationToolStripMenuItem.Name = "RunThermalSimulationToolStripMenuItem"
        Me.RunThermalSimulationToolStripMenuItem.Size = New System.Drawing.Size(242, 26)
        Me.RunThermalSimulationToolStripMenuItem.Text = "Run Thermal Simulation"
        '
        'PlaybackToolStripMenuItem
        '
        Me.PlaybackToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReduceSpeedToolStripMenuItem, Me.StopToolStripMenuItem, Me.PlayToolStripMenuItem, Me.IncreaseSpeedToolStripMenuItem, Me.ToolStripSeparator1, Me.DisplayParametersToolStripMenuItem})
        Me.PlaybackToolStripMenuItem.Name = "PlaybackToolStripMenuItem"
        Me.PlaybackToolStripMenuItem.Size = New System.Drawing.Size(79, 24)
        Me.PlaybackToolStripMenuItem.Text = "&Playback"
        '
        'ReduceSpeedToolStripMenuItem
        '
        Me.ReduceSpeedToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.media_seek_backward_3
        Me.ReduceSpeedToolStripMenuItem.Name = "ReduceSpeedToolStripMenuItem"
        Me.ReduceSpeedToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.ReduceSpeedToolStripMenuItem.Text = "Reduce Speed"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.media_playback_stop_3
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'PlayToolStripMenuItem
        '
        Me.PlayToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.media_playback_start_3
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        Me.PlayToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.PlayToolStripMenuItem.Text = "Play"
        '
        'IncreaseSpeedToolStripMenuItem
        '
        Me.IncreaseSpeedToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.media_seek_forward_3
        Me.IncreaseSpeedToolStripMenuItem.Name = "IncreaseSpeedToolStripMenuItem"
        Me.IncreaseSpeedToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.IncreaseSpeedToolStripMenuItem.Text = "Increase Speed"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(207, 6)
        '
        'DisplayParametersToolStripMenuItem
        '
        Me.DisplayParametersToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.page_white_paintbrush
        Me.DisplayParametersToolStripMenuItem.Name = "DisplayParametersToolStripMenuItem"
        Me.DisplayParametersToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
        Me.DisplayParametersToolStripMenuItem.Text = "Displa&y Parameters"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.VRTMParams)
        Me.TabControl1.Controls.Add(Me.MachRoom)
        Me.TabControl1.Controls.Add(Me.Production)
        Me.TabControl1.Controls.Add(Me.ProdStats)
        Me.TabControl1.Controls.Add(Me.SimParams)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(324, 918)
        Me.TabControl1.TabIndex = 20
        '
        'VRTMParams
        '
        Me.VRTMParams.Controls.Add(Me.Label32)
        Me.VRTMParams.Controls.Add(Me.GroupBox7)
        Me.VRTMParams.Controls.Add(Me.GroupBox1)
        Me.VRTMParams.Controls.Add(Me.GroupBox2)
        Me.VRTMParams.Location = New System.Drawing.Point(4, 46)
        Me.VRTMParams.Margin = New System.Windows.Forms.Padding(4)
        Me.VRTMParams.Name = "VRTMParams"
        Me.VRTMParams.Padding = New System.Windows.Forms.Padding(4)
        Me.VRTMParams.Size = New System.Drawing.Size(316, 868)
        Me.VRTMParams.TabIndex = 0
        Me.VRTMParams.Text = "VRTM Params"
        Me.VRTMParams.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(252, 36)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(44, 17)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "levels"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cmdCopyMachineRoom)
        Me.GroupBox7.Controls.Add(Me.txtSchVRTMEnd)
        Me.GroupBox7.Controls.Add(Me.txtSchVRTMBegin)
        Me.GroupBox7.Controls.Add(Me.chkSundayVRTM)
        Me.GroupBox7.Controls.Add(Me.chkSaturdayVRTM)
        Me.GroupBox7.Controls.Add(Me.chkFridayVRTM)
        Me.GroupBox7.Controls.Add(Me.chkThursdayVRTM)
        Me.GroupBox7.Controls.Add(Me.chkWednesdayVRTM)
        Me.GroupBox7.Controls.Add(Me.chkTuesdayVRTM)
        Me.GroupBox7.Controls.Add(Me.chkMondayVRTM)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Controls.Add(Me.Label27)
        Me.GroupBox7.Location = New System.Drawing.Point(20, 351)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Size = New System.Drawing.Size(281, 353)
        Me.GroupBox7.TabIndex = 17
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Schedule"
        '
        'cmdCopyMachineRoom
        '
        Me.cmdCopyMachineRoom.Location = New System.Drawing.Point(111, 313)
        Me.cmdCopyMachineRoom.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCopyMachineRoom.Name = "cmdCopyMachineRoom"
        Me.cmdCopyMachineRoom.Size = New System.Drawing.Size(160, 32)
        Me.cmdCopyMachineRoom.TabIndex = 19
        Me.cmdCopyMachineRoom.Text = "Copy Machine Room"
        Me.cmdCopyMachineRoom.UseVisualStyleBackColor = True
        '
        'txtSchVRTMEnd
        '
        Me.txtSchVRTMEnd.Location = New System.Drawing.Point(104, 84)
        Me.txtSchVRTMEnd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSchVRTMEnd.Mask = "00:00"
        Me.txtSchVRTMEnd.Name = "txtSchVRTMEnd"
        Me.txtSchVRTMEnd.Size = New System.Drawing.Size(75, 22)
        Me.txtSchVRTMEnd.TabIndex = 11
        Me.txtSchVRTMEnd.ValidatingType = GetType(Date)
        '
        'txtSchVRTMBegin
        '
        Me.txtSchVRTMBegin.Location = New System.Drawing.Point(104, 54)
        Me.txtSchVRTMBegin.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSchVRTMBegin.Mask = "00:00"
        Me.txtSchVRTMBegin.Name = "txtSchVRTMBegin"
        Me.txtSchVRTMBegin.Size = New System.Drawing.Size(75, 22)
        Me.txtSchVRTMBegin.TabIndex = 10
        '
        'chkSundayVRTM
        '
        Me.chkSundayVRTM.AutoSize = True
        Me.chkSundayVRTM.Location = New System.Drawing.Point(44, 286)
        Me.chkSundayVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSundayVRTM.Name = "chkSundayVRTM"
        Me.chkSundayVRTM.Size = New System.Drawing.Size(78, 21)
        Me.chkSundayVRTM.TabIndex = 18
        Me.chkSundayVRTM.Text = "Sunday"
        Me.chkSundayVRTM.UseVisualStyleBackColor = True
        '
        'chkSaturdayVRTM
        '
        Me.chkSaturdayVRTM.AutoSize = True
        Me.chkSaturdayVRTM.Location = New System.Drawing.Point(44, 257)
        Me.chkSaturdayVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSaturdayVRTM.Name = "chkSaturdayVRTM"
        Me.chkSaturdayVRTM.Size = New System.Drawing.Size(87, 21)
        Me.chkSaturdayVRTM.TabIndex = 17
        Me.chkSaturdayVRTM.Text = "Saturday"
        Me.chkSaturdayVRTM.UseVisualStyleBackColor = True
        '
        'chkFridayVRTM
        '
        Me.chkFridayVRTM.AutoSize = True
        Me.chkFridayVRTM.Location = New System.Drawing.Point(44, 229)
        Me.chkFridayVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFridayVRTM.Name = "chkFridayVRTM"
        Me.chkFridayVRTM.Size = New System.Drawing.Size(69, 21)
        Me.chkFridayVRTM.TabIndex = 16
        Me.chkFridayVRTM.Text = "Friday"
        Me.chkFridayVRTM.UseVisualStyleBackColor = True
        '
        'chkThursdayVRTM
        '
        Me.chkThursdayVRTM.AutoSize = True
        Me.chkThursdayVRTM.Location = New System.Drawing.Point(44, 201)
        Me.chkThursdayVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.chkThursdayVRTM.Name = "chkThursdayVRTM"
        Me.chkThursdayVRTM.Size = New System.Drawing.Size(90, 21)
        Me.chkThursdayVRTM.TabIndex = 15
        Me.chkThursdayVRTM.Text = "Thursday"
        Me.chkThursdayVRTM.UseVisualStyleBackColor = True
        '
        'chkWednesdayVRTM
        '
        Me.chkWednesdayVRTM.AutoSize = True
        Me.chkWednesdayVRTM.Location = New System.Drawing.Point(44, 172)
        Me.chkWednesdayVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.chkWednesdayVRTM.Name = "chkWednesdayVRTM"
        Me.chkWednesdayVRTM.Size = New System.Drawing.Size(105, 21)
        Me.chkWednesdayVRTM.TabIndex = 14
        Me.chkWednesdayVRTM.Text = "Wednesday"
        Me.chkWednesdayVRTM.UseVisualStyleBackColor = True
        '
        'chkTuesdayVRTM
        '
        Me.chkTuesdayVRTM.AutoSize = True
        Me.chkTuesdayVRTM.Location = New System.Drawing.Point(44, 144)
        Me.chkTuesdayVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTuesdayVRTM.Name = "chkTuesdayVRTM"
        Me.chkTuesdayVRTM.Size = New System.Drawing.Size(85, 21)
        Me.chkTuesdayVRTM.TabIndex = 13
        Me.chkTuesdayVRTM.Text = "Tuesday"
        Me.chkTuesdayVRTM.UseVisualStyleBackColor = True
        '
        'chkMondayVRTM
        '
        Me.chkMondayVRTM.AutoSize = True
        Me.chkMondayVRTM.Location = New System.Drawing.Point(44, 116)
        Me.chkMondayVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.chkMondayVRTM.Name = "chkMondayVRTM"
        Me.chkMondayVRTM.Size = New System.Drawing.Size(80, 21)
        Me.chkMondayVRTM.TabIndex = 12
        Me.chkMondayVRTM.Text = "Monday"
        Me.chkMondayVRTM.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(40, 58)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(55, 17)
        Me.Label25.TabIndex = 11
        Me.Label25.Text = "Begins:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(40, 87)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 17)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Ends:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 28)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(251, 17)
        Me.Label27.TabIndex = 9
        Me.Label27.Text = "Mandatory Turnoff Times (Ventilation):"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStCap)
        Me.GroupBox1.Controls.Add(Me.txtBoxesPerTray)
        Me.GroupBox1.Controls.Add(Me.txtNTrays)
        Me.GroupBox1.Controls.Add(Me.txtNLevels)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 7)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(281, 156)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "VRTM Parameters"
        '
        'txtStCap
        '
        Me.txtStCap.Enabled = False
        Me.txtStCap.Location = New System.Drawing.Point(125, 110)
        Me.txtStCap.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStCap.Name = "txtStCap"
        Me.txtStCap.Size = New System.Drawing.Size(97, 22)
        Me.txtStCap.TabIndex = 4
        Me.txtStCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxesPerTray
        '
        Me.txtBoxesPerTray.Location = New System.Drawing.Point(165, 81)
        Me.txtBoxesPerTray.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBoxesPerTray.Name = "txtBoxesPerTray"
        Me.txtBoxesPerTray.Size = New System.Drawing.Size(57, 22)
        Me.txtBoxesPerTray.TabIndex = 3
        Me.txtBoxesPerTray.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNTrays
        '
        Me.txtNTrays.Location = New System.Drawing.Point(165, 53)
        Me.txtNTrays.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNTrays.Name = "txtNTrays"
        Me.txtNTrays.Size = New System.Drawing.Size(57, 22)
        Me.txtNTrays.TabIndex = 2
        Me.txtNTrays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNLevels
        '
        Me.txtNLevels.Location = New System.Drawing.Point(165, 25)
        Me.txtNLevels.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNLevels.Name = "txtNLevels"
        Me.txtNLevels.Size = New System.Drawing.Size(57, 22)
        Me.txtNLevels.TabIndex = 1
        Me.txtNLevels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(232, 113)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(45, 17)
        Me.Label38.TabIndex = 7
        Me.Label38.Text = "boxes"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(232, 85)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(45, 17)
        Me.Label37.TabIndex = 6
        Me.Label37.Text = "boxes"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(232, 57)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(39, 17)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = "trays"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Boxes per Tray Group:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 112)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Static Capacity:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Number of Trays:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Number of Levels:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.Label52)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.txtGlobalHX)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtEvapSurf)
        Me.GroupBox2.Controls.Add(Me.cmdHLEdit)
        Me.GroupBox2.Controls.Add(Me.txtFanPower)
        Me.GroupBox2.Controls.Add(Me.txtFanFlow)
        Me.GroupBox2.Controls.Add(Me.Label51)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtHL)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 171)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(281, 172)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Evaporators"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(215, 143)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(54, 17)
        Me.Label41.TabIndex = 9
        Me.Label41.Text = "W/m².K"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(236, 114)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(24, 17)
        Me.Label40.TabIndex = 8
        Me.Label40.Text = "m²"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(236, 85)
        Me.Label52.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(28, 17)
        Me.Label52.TabIndex = 7
        Me.Label52.Text = "kW"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(236, 57)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(36, 17)
        Me.Label39.TabIndex = 7
        Me.Label39.Text = "m³/h"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(196, 30)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(28, 17)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "kW"
        '
        'txtGlobalHX
        '
        Me.txtGlobalHX.Location = New System.Drawing.Point(129, 139)
        Me.txtGlobalHX.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGlobalHX.Name = "txtGlobalHX"
        Me.txtGlobalHX.Size = New System.Drawing.Size(77, 22)
        Me.txtGlobalHX.TabIndex = 9
        Me.txtGlobalHX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 143)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 17)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Global HX Coeff.:"
        '
        'txtEvapSurf
        '
        Me.txtEvapSurf.Location = New System.Drawing.Point(155, 111)
        Me.txtEvapSurf.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEvapSurf.Name = "txtEvapSurf"
        Me.txtEvapSurf.Size = New System.Drawing.Size(72, 22)
        Me.txtEvapSurf.TabIndex = 8
        Me.txtEvapSurf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdHLEdit
        '
        Me.cmdHLEdit.Location = New System.Drawing.Point(231, 25)
        Me.cmdHLEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdHLEdit.Name = "cmdHLEdit"
        Me.cmdHLEdit.Size = New System.Drawing.Size(33, 25)
        Me.cmdHLEdit.TabIndex = 6
        Me.cmdHLEdit.Text = "..."
        Me.cmdHLEdit.UseVisualStyleBackColor = True
        '
        'txtFanPower
        '
        Me.txtFanPower.Location = New System.Drawing.Point(129, 81)
        Me.txtFanPower.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFanPower.Name = "txtFanPower"
        Me.txtFanPower.Size = New System.Drawing.Size(97, 22)
        Me.txtFanPower.TabIndex = 7
        Me.txtFanPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFanFlow
        '
        Me.txtFanFlow.Location = New System.Drawing.Point(129, 53)
        Me.txtFanFlow.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFanFlow.Name = "txtFanFlow"
        Me.txtFanFlow.Size = New System.Drawing.Size(97, 22)
        Me.txtFanFlow.TabIndex = 7
        Me.txtFanFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(9, 85)
        Me.Label51.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(115, 17)
        Me.Label51.TabIndex = 2
        Me.Label51.Text = "Total Fan Power:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 114)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Evap. Surface Area:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 57)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fan Flow Rate:"
        '
        'txtHL
        '
        Me.txtHL.Enabled = False
        Me.txtHL.Location = New System.Drawing.Point(129, 25)
        Me.txtHL.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHL.Name = "txtHL"
        Me.txtHL.Size = New System.Drawing.Size(60, 22)
        Me.txtHL.TabIndex = 5
        Me.txtHL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 28)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Fixed Heat Load:"
        '
        'MachRoom
        '
        Me.MachRoom.Controls.Add(Me.GroupBox6)
        Me.MachRoom.Controls.Add(Me.GroupBox3)
        Me.MachRoom.Location = New System.Drawing.Point(4, 67)
        Me.MachRoom.Margin = New System.Windows.Forms.Padding(4)
        Me.MachRoom.Name = "MachRoom"
        Me.MachRoom.Padding = New System.Windows.Forms.Padding(4)
        Me.MachRoom.Size = New System.Drawing.Size(242, 847)
        Me.MachRoom.TabIndex = 1
        Me.MachRoom.Text = "Machine Room"
        Me.MachRoom.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmdCopyVRTM)
        Me.GroupBox6.Controls.Add(Me.txtIdleHourEndsMR)
        Me.GroupBox6.Controls.Add(Me.txtIdleHourBeginMR)
        Me.GroupBox6.Controls.Add(Me.chkSundayMR)
        Me.GroupBox6.Controls.Add(Me.chkSaturdayMR)
        Me.GroupBox6.Controls.Add(Me.chkFridayMR)
        Me.GroupBox6.Controls.Add(Me.chkThursdayMR)
        Me.GroupBox6.Controls.Add(Me.chkWednesdayMR)
        Me.GroupBox6.Controls.Add(Me.chkTuesdayMR)
        Me.GroupBox6.Controls.Add(Me.chkMondayMR)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Location = New System.Drawing.Point(20, 203)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Size = New System.Drawing.Size(281, 335)
        Me.GroupBox6.TabIndex = 16
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Schedule"
        '
        'cmdCopyVRTM
        '
        Me.cmdCopyVRTM.Location = New System.Drawing.Point(155, 294)
        Me.cmdCopyVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCopyVRTM.Name = "cmdCopyVRTM"
        Me.cmdCopyVRTM.Size = New System.Drawing.Size(117, 32)
        Me.cmdCopyVRTM.TabIndex = 39
        Me.cmdCopyVRTM.Text = "Copy VRTM"
        Me.cmdCopyVRTM.UseVisualStyleBackColor = True
        '
        'txtIdleHourEndsMR
        '
        Me.txtIdleHourEndsMR.Location = New System.Drawing.Point(104, 84)
        Me.txtIdleHourEndsMR.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdleHourEndsMR.Mask = "00:00"
        Me.txtIdleHourEndsMR.Name = "txtIdleHourEndsMR"
        Me.txtIdleHourEndsMR.Size = New System.Drawing.Size(75, 22)
        Me.txtIdleHourEndsMR.TabIndex = 31
        Me.txtIdleHourEndsMR.ValidatingType = GetType(Date)
        '
        'txtIdleHourBeginMR
        '
        Me.txtIdleHourBeginMR.Location = New System.Drawing.Point(104, 54)
        Me.txtIdleHourBeginMR.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdleHourBeginMR.Mask = "00:00"
        Me.txtIdleHourBeginMR.Name = "txtIdleHourBeginMR"
        Me.txtIdleHourBeginMR.Size = New System.Drawing.Size(75, 22)
        Me.txtIdleHourBeginMR.TabIndex = 30
        Me.txtIdleHourBeginMR.ValidatingType = GetType(Date)
        '
        'chkSundayMR
        '
        Me.chkSundayMR.AutoSize = True
        Me.chkSundayMR.Location = New System.Drawing.Point(44, 286)
        Me.chkSundayMR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSundayMR.Name = "chkSundayMR"
        Me.chkSundayMR.Size = New System.Drawing.Size(78, 21)
        Me.chkSundayMR.TabIndex = 38
        Me.chkSundayMR.Text = "Sunday"
        Me.chkSundayMR.UseVisualStyleBackColor = True
        '
        'chkSaturdayMR
        '
        Me.chkSaturdayMR.AutoSize = True
        Me.chkSaturdayMR.Location = New System.Drawing.Point(44, 257)
        Me.chkSaturdayMR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSaturdayMR.Name = "chkSaturdayMR"
        Me.chkSaturdayMR.Size = New System.Drawing.Size(87, 21)
        Me.chkSaturdayMR.TabIndex = 37
        Me.chkSaturdayMR.Text = "Saturday"
        Me.chkSaturdayMR.UseVisualStyleBackColor = True
        '
        'chkFridayMR
        '
        Me.chkFridayMR.AutoSize = True
        Me.chkFridayMR.Location = New System.Drawing.Point(44, 229)
        Me.chkFridayMR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFridayMR.Name = "chkFridayMR"
        Me.chkFridayMR.Size = New System.Drawing.Size(69, 21)
        Me.chkFridayMR.TabIndex = 36
        Me.chkFridayMR.Text = "Friday"
        Me.chkFridayMR.UseVisualStyleBackColor = True
        '
        'chkThursdayMR
        '
        Me.chkThursdayMR.AutoSize = True
        Me.chkThursdayMR.Location = New System.Drawing.Point(44, 201)
        Me.chkThursdayMR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkThursdayMR.Name = "chkThursdayMR"
        Me.chkThursdayMR.Size = New System.Drawing.Size(90, 21)
        Me.chkThursdayMR.TabIndex = 35
        Me.chkThursdayMR.Text = "Thursday"
        Me.chkThursdayMR.UseVisualStyleBackColor = True
        '
        'chkWednesdayMR
        '
        Me.chkWednesdayMR.AutoSize = True
        Me.chkWednesdayMR.Location = New System.Drawing.Point(44, 172)
        Me.chkWednesdayMR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkWednesdayMR.Name = "chkWednesdayMR"
        Me.chkWednesdayMR.Size = New System.Drawing.Size(105, 21)
        Me.chkWednesdayMR.TabIndex = 34
        Me.chkWednesdayMR.Text = "Wednesday"
        Me.chkWednesdayMR.UseVisualStyleBackColor = True
        '
        'chkTuesdayMR
        '
        Me.chkTuesdayMR.AutoSize = True
        Me.chkTuesdayMR.Location = New System.Drawing.Point(44, 144)
        Me.chkTuesdayMR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTuesdayMR.Name = "chkTuesdayMR"
        Me.chkTuesdayMR.Size = New System.Drawing.Size(85, 21)
        Me.chkTuesdayMR.TabIndex = 33
        Me.chkTuesdayMR.Text = "Tuesday"
        Me.chkTuesdayMR.UseVisualStyleBackColor = True
        '
        'chkMondayMR
        '
        Me.chkMondayMR.AutoSize = True
        Me.chkMondayMR.Location = New System.Drawing.Point(44, 116)
        Me.chkMondayMR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkMondayMR.Name = "chkMondayMR"
        Me.chkMondayMR.Size = New System.Drawing.Size(80, 21)
        Me.chkMondayMR.TabIndex = 32
        Me.chkMondayMR.Text = "Monday"
        Me.chkMondayMR.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(40, 58)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(55, 17)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Begins:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(40, 87)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(44, 17)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Ends:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(9, 28)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(171, 17)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "Mandatory Turnoff Times:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdMRSetup)
        Me.GroupBox3.Controls.Add(Me.txtReferenceCapacity)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.txtTevapSP)
        Me.GroupBox3.Controls.Add(Me.txtTCond)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Location = New System.Drawing.Point(20, 7)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(281, 182)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Machines"
        '
        'cmdMRSetup
        '
        Me.cmdMRSetup.Location = New System.Drawing.Point(44, 28)
        Me.cmdMRSetup.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdMRSetup.Name = "cmdMRSetup"
        Me.cmdMRSetup.Size = New System.Drawing.Size(179, 32)
        Me.cmdMRSetup.TabIndex = 27
        Me.cmdMRSetup.Text = "Setup Machine Room..."
        Me.cmdMRSetup.UseVisualStyleBackColor = True
        '
        'txtReferenceCapacity
        '
        Me.txtReferenceCapacity.Enabled = False
        Me.txtReferenceCapacity.Location = New System.Drawing.Point(116, 137)
        Me.txtReferenceCapacity.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReferenceCapacity.Name = "txtReferenceCapacity"
        Me.txtReferenceCapacity.Size = New System.Drawing.Size(117, 22)
        Me.txtReferenceCapacity.TabIndex = 26
        Me.txtReferenceCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(243, 140)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 17)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "kW"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(243, 111)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 17)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "ºC"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(243, 81)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 17)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "ºC"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 81)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(131, 17)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Condensing Temp.:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 140)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 17)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Ref. Capacity:"
        '
        'txtTevapSP
        '
        Me.txtTevapSP.Location = New System.Drawing.Point(153, 107)
        Me.txtTevapSP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTevapSP.Name = "txtTevapSP"
        Me.txtTevapSP.Size = New System.Drawing.Size(80, 22)
        Me.txtTevapSP.TabIndex = 27
        Me.txtTevapSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTCond
        '
        Me.txtTCond.Location = New System.Drawing.Point(153, 78)
        Me.txtTCond.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTCond.Name = "txtTCond"
        Me.txtTCond.Size = New System.Drawing.Size(80, 22)
        Me.txtTCond.TabIndex = 28
        Me.txtTCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 111)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 17)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Setpoint Tevap:"
        '
        'Production
        '
        Me.Production.Controls.Add(Me.GroupBox8)
        Me.Production.Controls.Add(Me.GroupBox5)
        Me.Production.Location = New System.Drawing.Point(4, 67)
        Me.Production.Margin = New System.Windows.Forms.Padding(4)
        Me.Production.Name = "Production"
        Me.Production.Size = New System.Drawing.Size(242, 847)
        Me.Production.TabIndex = 2
        Me.Production.Text = "Production"
        Me.Production.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkSecondTurn)
        Me.GroupBox8.Controls.Add(Me.txtSecondTurnEnds)
        Me.GroupBox8.Controls.Add(Me.txtSecondTurnBegins)
        Me.GroupBox8.Controls.Add(Me.Label30)
        Me.GroupBox8.Controls.Add(Me.Label31)
        Me.GroupBox8.Controls.Add(Me.chkFirstTurn)
        Me.GroupBox8.Controls.Add(Me.Label20)
        Me.GroupBox8.Controls.Add(Me.txtFirstTurnEnds)
        Me.GroupBox8.Controls.Add(Me.txtFirstTurnBegins)
        Me.GroupBox8.Controls.Add(Me.chkSundayProd)
        Me.GroupBox8.Controls.Add(Me.chkSaturdayProd)
        Me.GroupBox8.Controls.Add(Me.chkFridayProd)
        Me.GroupBox8.Controls.Add(Me.chkThursdayProd)
        Me.GroupBox8.Controls.Add(Me.chkWednesdayProd)
        Me.GroupBox8.Controls.Add(Me.chkTuesdayProd)
        Me.GroupBox8.Controls.Add(Me.chkMondayProd)
        Me.GroupBox8.Controls.Add(Me.Label28)
        Me.GroupBox8.Controls.Add(Me.Label29)
        Me.GroupBox8.Location = New System.Drawing.Point(21, 283)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox8.Size = New System.Drawing.Size(281, 446)
        Me.GroupBox8.TabIndex = 17
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Schedule"
        '
        'chkSecondTurn
        '
        Me.chkSecondTurn.AutoSize = True
        Me.chkSecondTurn.Location = New System.Drawing.Point(13, 116)
        Me.chkSecondTurn.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSecondTurn.Name = "chkSecondTurn"
        Me.chkSecondTurn.Size = New System.Drawing.Size(188, 21)
        Me.chkSecondTurn.TabIndex = 48
        Me.chkSecondTurn.Text = "Second Production Turn:"
        Me.chkSecondTurn.UseVisualStyleBackColor = True
        '
        'txtSecondTurnEnds
        '
        Me.txtSecondTurnEnds.Location = New System.Drawing.Point(103, 174)
        Me.txtSecondTurnEnds.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSecondTurnEnds.Mask = "00:00"
        Me.txtSecondTurnEnds.Name = "txtSecondTurnEnds"
        Me.txtSecondTurnEnds.Size = New System.Drawing.Size(75, 22)
        Me.txtSecondTurnEnds.TabIndex = 50
        Me.txtSecondTurnEnds.ValidatingType = GetType(Date)
        '
        'txtSecondTurnBegins
        '
        Me.txtSecondTurnBegins.Location = New System.Drawing.Point(103, 144)
        Me.txtSecondTurnBegins.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSecondTurnBegins.Mask = "00:00"
        Me.txtSecondTurnBegins.Name = "txtSecondTurnBegins"
        Me.txtSecondTurnBegins.Size = New System.Drawing.Size(75, 22)
        Me.txtSecondTurnBegins.TabIndex = 49
        Me.txtSecondTurnBegins.ValidatingType = GetType(Date)
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(39, 148)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 17)
        Me.Label30.TabIndex = 23
        Me.Label30.Text = "Begins:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(39, 177)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(44, 17)
        Me.Label31.TabIndex = 24
        Me.Label31.Text = "Ends:"
        '
        'chkFirstTurn
        '
        Me.chkFirstTurn.AutoSize = True
        Me.chkFirstTurn.Location = New System.Drawing.Point(15, 26)
        Me.chkFirstTurn.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFirstTurn.Name = "chkFirstTurn"
        Me.chkFirstTurn.Size = New System.Drawing.Size(167, 21)
        Me.chkFirstTurn.TabIndex = 45
        Me.chkFirstTurn.Text = "First Production Turn:"
        Me.chkFirstTurn.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 212)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(111, 17)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "Operation Days:"
        '
        'txtFirstTurnEnds
        '
        Me.txtFirstTurnEnds.Location = New System.Drawing.Point(104, 84)
        Me.txtFirstTurnEnds.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirstTurnEnds.Mask = "00:00"
        Me.txtFirstTurnEnds.Name = "txtFirstTurnEnds"
        Me.txtFirstTurnEnds.Size = New System.Drawing.Size(75, 22)
        Me.txtFirstTurnEnds.TabIndex = 47
        Me.txtFirstTurnEnds.ValidatingType = GetType(Date)
        '
        'txtFirstTurnBegins
        '
        Me.txtFirstTurnBegins.Location = New System.Drawing.Point(104, 54)
        Me.txtFirstTurnBegins.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirstTurnBegins.Mask = "00:00"
        Me.txtFirstTurnBegins.Name = "txtFirstTurnBegins"
        Me.txtFirstTurnBegins.Size = New System.Drawing.Size(75, 22)
        Me.txtFirstTurnBegins.TabIndex = 46
        Me.txtFirstTurnBegins.ValidatingType = GetType(Date)
        '
        'chkSundayProd
        '
        Me.chkSundayProd.AutoSize = True
        Me.chkSundayProd.Location = New System.Drawing.Point(44, 410)
        Me.chkSundayProd.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSundayProd.Name = "chkSundayProd"
        Me.chkSundayProd.Size = New System.Drawing.Size(78, 21)
        Me.chkSundayProd.TabIndex = 57
        Me.chkSundayProd.Text = "Sunday"
        Me.chkSundayProd.UseVisualStyleBackColor = True
        '
        'chkSaturdayProd
        '
        Me.chkSaturdayProd.AutoSize = True
        Me.chkSaturdayProd.Location = New System.Drawing.Point(44, 382)
        Me.chkSaturdayProd.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSaturdayProd.Name = "chkSaturdayProd"
        Me.chkSaturdayProd.Size = New System.Drawing.Size(87, 21)
        Me.chkSaturdayProd.TabIndex = 56
        Me.chkSaturdayProd.Text = "Saturday"
        Me.chkSaturdayProd.UseVisualStyleBackColor = True
        '
        'chkFridayProd
        '
        Me.chkFridayProd.AutoSize = True
        Me.chkFridayProd.Location = New System.Drawing.Point(44, 353)
        Me.chkFridayProd.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFridayProd.Name = "chkFridayProd"
        Me.chkFridayProd.Size = New System.Drawing.Size(69, 21)
        Me.chkFridayProd.TabIndex = 55
        Me.chkFridayProd.Text = "Friday"
        Me.chkFridayProd.UseVisualStyleBackColor = True
        '
        'chkThursdayProd
        '
        Me.chkThursdayProd.AutoSize = True
        Me.chkThursdayProd.Location = New System.Drawing.Point(44, 325)
        Me.chkThursdayProd.Margin = New System.Windows.Forms.Padding(4)
        Me.chkThursdayProd.Name = "chkThursdayProd"
        Me.chkThursdayProd.Size = New System.Drawing.Size(90, 21)
        Me.chkThursdayProd.TabIndex = 54
        Me.chkThursdayProd.Text = "Thursday"
        Me.chkThursdayProd.UseVisualStyleBackColor = True
        '
        'chkWednesdayProd
        '
        Me.chkWednesdayProd.AutoSize = True
        Me.chkWednesdayProd.Location = New System.Drawing.Point(44, 297)
        Me.chkWednesdayProd.Margin = New System.Windows.Forms.Padding(4)
        Me.chkWednesdayProd.Name = "chkWednesdayProd"
        Me.chkWednesdayProd.Size = New System.Drawing.Size(105, 21)
        Me.chkWednesdayProd.TabIndex = 53
        Me.chkWednesdayProd.Text = "Wednesday"
        Me.chkWednesdayProd.UseVisualStyleBackColor = True
        '
        'chkTuesdayProd
        '
        Me.chkTuesdayProd.AutoSize = True
        Me.chkTuesdayProd.Location = New System.Drawing.Point(44, 268)
        Me.chkTuesdayProd.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTuesdayProd.Name = "chkTuesdayProd"
        Me.chkTuesdayProd.Size = New System.Drawing.Size(85, 21)
        Me.chkTuesdayProd.TabIndex = 52
        Me.chkTuesdayProd.Text = "Tuesday"
        Me.chkTuesdayProd.UseVisualStyleBackColor = True
        '
        'chkMondayProd
        '
        Me.chkMondayProd.AutoSize = True
        Me.chkMondayProd.Location = New System.Drawing.Point(44, 240)
        Me.chkMondayProd.Margin = New System.Windows.Forms.Padding(4)
        Me.chkMondayProd.Name = "chkMondayProd"
        Me.chkMondayProd.Size = New System.Drawing.Size(80, 21)
        Me.chkMondayProd.TabIndex = 51
        Me.chkMondayProd.Text = "Monday"
        Me.chkMondayProd.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(40, 58)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(55, 17)
        Me.Label28.TabIndex = 11
        Me.Label28.Text = "Begins:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(40, 87)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(44, 17)
        Me.Label29.TabIndex = 15
        Me.Label29.Text = "Ends:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label47)
        Me.GroupBox5.Controls.Add(Me.txtWeeklyHeatLoad)
        Me.GroupBox5.Controls.Add(Me.Label50)
        Me.GroupBox5.Controls.Add(Me.txtSafetyFactorVRTM)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label44)
        Me.GroupBox5.Controls.Add(Me.Label43)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.txtAvgHeatLoad)
        Me.GroupBox5.Controls.Add(Me.Label42)
        Me.GroupBox5.Controls.Add(Me.txtAvgMassFlowIn)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.cmdPrdMixSetup)
        Me.GroupBox5.Controls.Add(Me.txtAvgBoxMass)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txtAvgBoxflowIn)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Location = New System.Drawing.Point(21, 7)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(281, 267)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Products"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(236, 187)
        Me.Label47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(28, 17)
        Me.Label47.TabIndex = 53
        Me.Label47.Text = "kW"
        '
        'txtWeeklyHeatLoad
        '
        Me.txtWeeklyHeatLoad.Enabled = False
        Me.txtWeeklyHeatLoad.Location = New System.Drawing.Point(141, 183)
        Me.txtWeeklyHeatLoad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWeeklyHeatLoad.Name = "txtWeeklyHeatLoad"
        Me.txtWeeklyHeatLoad.Size = New System.Drawing.Size(85, 22)
        Me.txtWeeklyHeatLoad.TabIndex = 52
        Me.txtWeeklyHeatLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(9, 187)
        Me.Label50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(128, 17)
        Me.Label50.TabIndex = 51
        Me.Label50.Text = "Weekly Heat Load:"
        '
        'txtSafetyFactorVRTM
        '
        Me.txtSafetyFactorVRTM.Location = New System.Drawing.Point(141, 213)
        Me.txtSafetyFactorVRTM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSafetyFactorVRTM.Name = "txtSafetyFactorVRTM"
        Me.txtSafetyFactorVRTM.Size = New System.Drawing.Size(85, 22)
        Me.txtSafetyFactorVRTM.TabIndex = 50
        Me.txtSafetyFactorVRTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 217)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 17)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Safety Factor:"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(236, 158)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(28, 17)
        Me.Label44.TabIndex = 48
        Me.Label44.Text = "kW"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(236, 128)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(35, 17)
        Me.Label43.TabIndex = 47
        Me.Label43.Text = "kg/h"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(236, 98)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 17)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "un/h"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(236, 69)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 17)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "kg"
        '
        'txtAvgHeatLoad
        '
        Me.txtAvgHeatLoad.Enabled = False
        Me.txtAvgHeatLoad.Location = New System.Drawing.Point(141, 154)
        Me.txtAvgHeatLoad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAvgHeatLoad.Name = "txtAvgHeatLoad"
        Me.txtAvgHeatLoad.Size = New System.Drawing.Size(85, 22)
        Me.txtAvgHeatLoad.TabIndex = 44
        Me.txtAvgHeatLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(9, 158)
        Me.Label42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(113, 17)
        Me.Label42.TabIndex = 7
        Me.Label42.Text = "Daily Heat Load:"
        '
        'txtAvgMassFlowIn
        '
        Me.txtAvgMassFlowIn.Enabled = False
        Me.txtAvgMassFlowIn.Location = New System.Drawing.Point(141, 124)
        Me.txtAvgMassFlowIn.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAvgMassFlowIn.Name = "txtAvgMassFlowIn"
        Me.txtAvgMassFlowIn.Size = New System.Drawing.Size(85, 22)
        Me.txtAvgMassFlowIn.TabIndex = 43
        Me.txtAvgMassFlowIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 128)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 17)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Avg Mass Flow In:"
        '
        'cmdPrdMixSetup
        '
        Me.cmdPrdMixSetup.Location = New System.Drawing.Point(45, 23)
        Me.cmdPrdMixSetup.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPrdMixSetup.Name = "cmdPrdMixSetup"
        Me.cmdPrdMixSetup.Size = New System.Drawing.Size(180, 32)
        Me.cmdPrdMixSetup.TabIndex = 40
        Me.cmdPrdMixSetup.Text = "Setup Product Mix..."
        Me.cmdPrdMixSetup.UseVisualStyleBackColor = True
        '
        'txtAvgBoxMass
        '
        Me.txtAvgBoxMass.Enabled = False
        Me.txtAvgBoxMass.Location = New System.Drawing.Point(141, 65)
        Me.txtAvgBoxMass.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAvgBoxMass.Name = "txtAvgBoxMass"
        Me.txtAvgBoxMass.Size = New System.Drawing.Size(85, 22)
        Me.txtAvgBoxMass.TabIndex = 41
        Me.txtAvgBoxMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 69)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 17)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Avg Box Mass:"
        '
        'txtAvgBoxflowIn
        '
        Me.txtAvgBoxflowIn.Enabled = False
        Me.txtAvgBoxflowIn.Location = New System.Drawing.Point(141, 95)
        Me.txtAvgBoxflowIn.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAvgBoxflowIn.Name = "txtAvgBoxflowIn"
        Me.txtAvgBoxflowIn.Size = New System.Drawing.Size(85, 22)
        Me.txtAvgBoxflowIn.TabIndex = 42
        Me.txtAvgBoxflowIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 98)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(110, 17)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Avg Box Flow In:"
        '
        'ProdStats
        '
        Me.ProdStats.Location = New System.Drawing.Point(4, 67)
        Me.ProdStats.Margin = New System.Windows.Forms.Padding(4)
        Me.ProdStats.Name = "ProdStats"
        Me.ProdStats.Size = New System.Drawing.Size(242, 847)
        Me.ProdStats.TabIndex = 4
        Me.ProdStats.Text = "Demand"
        Me.ProdStats.UseVisualStyleBackColor = True
        '
        'SimParams
        '
        Me.SimParams.Controls.Add(Me.GroupBox4)
        Me.SimParams.Controls.Add(Me.GroupBox9)
        Me.SimParams.Location = New System.Drawing.Point(4, 67)
        Me.SimParams.Margin = New System.Windows.Forms.Padding(4)
        Me.SimParams.Name = "SimParams"
        Me.SimParams.Size = New System.Drawing.Size(242, 847)
        Me.SimParams.TabIndex = 3
        Me.SimParams.Text = "Simulation Params"
        Me.SimParams.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtAcceptedDt)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Location = New System.Drawing.Point(21, 130)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(281, 74)
        Me.GroupBox4.TabIndex = 62
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Food Selector Mini-Simulator"
        '
        'txtAcceptedDt
        '
        Me.txtAcceptedDt.Location = New System.Drawing.Point(165, 25)
        Me.txtAcceptedDt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAcceptedDt.Name = "txtAcceptedDt"
        Me.txtAcceptedDt.Size = New System.Drawing.Size(56, 22)
        Me.txtAcceptedDt.TabIndex = 58
        Me.txtAcceptedDt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(231, 28)
        Me.Label48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(22, 17)
        Me.Label48.TabIndex = 2
        Me.Label48.Text = "ºC"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(9, 28)
        Me.Label49.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(151, 17)
        Me.Label49.TabIndex = 2
        Me.Label49.Text = "ΔT from Tevap to Tair:"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label46)
        Me.GroupBox9.Controls.Add(Me.txtTotalSimTime)
        Me.GroupBox9.Controls.Add(Me.Label45)
        Me.GroupBox9.Controls.Add(Me.Label33)
        Me.GroupBox9.Controls.Add(Me.txtMinimumSimDT)
        Me.GroupBox9.Controls.Add(Me.Label34)
        Me.GroupBox9.Location = New System.Drawing.Point(21, 11)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Size = New System.Drawing.Size(281, 101)
        Me.GroupBox9.TabIndex = 4
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Main Simulator"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(231, 57)
        Me.Label46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(15, 17)
        Me.Label46.TabIndex = 61
        Me.Label46.Text = "s"
        '
        'txtTotalSimTime
        '
        Me.txtTotalSimTime.Location = New System.Drawing.Point(165, 25)
        Me.txtTotalSimTime.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalSimTime.Name = "txtTotalSimTime"
        Me.txtTotalSimTime.Size = New System.Drawing.Size(56, 22)
        Me.txtTotalSimTime.TabIndex = 58
        Me.txtTotalSimTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(231, 28)
        Me.Label45.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(38, 17)
        Me.Label45.TabIndex = 2
        Me.Label45.Text = "days"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(9, 28)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(148, 17)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "Total Simulation Time:"
        '
        'txtMinimumSimDT
        '
        Me.txtMinimumSimDT.Location = New System.Drawing.Point(165, 53)
        Me.txtMinimumSimDT.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMinimumSimDT.Name = "txtMinimumSimDT"
        Me.txtMinimumSimDT.Size = New System.Drawing.Size(56, 22)
        Me.txtMinimumSimDT.TabIndex = 60
        Me.txtMinimumSimDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(9, 57)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(111, 17)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "Minimum Sim Δt:"
        '
        'Divisor2
        '
        Me.Divisor2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Divisor2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.Divisor2.Location = New System.Drawing.Point(0, 0)
        Me.Divisor2.Margin = New System.Windows.Forms.Padding(4)
        Me.Divisor2.Name = "Divisor2"
        '
        'Divisor2.Panel1
        '
        Me.Divisor2.Panel1.Controls.Add(Me.MidPanel)
        Me.Divisor2.Size = New System.Drawing.Size(1223, 975)
        Me.Divisor2.SplitterDistance = 820
        Me.Divisor2.SplitterWidth = 5
        Me.Divisor2.TabIndex = 0
        '
        'MidPanel
        '
        Me.MidPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MidPanel.IsSplitterFixed = True
        Me.MidPanel.Location = New System.Drawing.Point(0, 0)
        Me.MidPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.MidPanel.Name = "MidPanel"
        Me.MidPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'MidPanel.Panel1
        '
        Me.MidPanel.Panel1.Controls.Add(Me.lblDisplayVariable)
        Me.MidPanel.Panel1.Controls.Add(Me.lblCurrentPos)
        Me.MidPanel.Panel1.Controls.Add(Me.hsSimPosition)
        '
        'MidPanel.Panel2
        '
        Me.MidPanel.Panel2.Controls.Add(Me.VRTMTable)
        Me.MidPanel.Size = New System.Drawing.Size(820, 975)
        Me.MidPanel.SplitterDistance = 67
        Me.MidPanel.SplitterWidth = 5
        Me.MidPanel.TabIndex = 2
        '
        'lblDisplayVariable
        '
        Me.lblDisplayVariable.AutoSize = True
        Me.lblDisplayVariable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayVariable.Location = New System.Drawing.Point(11, 42)
        Me.lblDisplayVariable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayVariable.Name = "lblDisplayVariable"
        Me.lblDisplayVariable.Size = New System.Drawing.Size(164, 17)
        Me.lblDisplayVariable.TabIndex = 3
        Me.lblDisplayVariable.Text = "Simulation Not Ready"
        '
        'lblCurrentPos
        '
        Me.lblCurrentPos.AutoSize = True
        Me.lblCurrentPos.Location = New System.Drawing.Point(559, 11)
        Me.lblCurrentPos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentPos.Name = "lblCurrentPos"
        Me.lblCurrentPos.Size = New System.Drawing.Size(97, 17)
        Me.lblCurrentPos.TabIndex = 2
        Me.lblCurrentPos.Text = "Mo D00 00:00"
        '
        'hsSimPosition
        '
        Me.hsSimPosition.LargeChange = 2
        Me.hsSimPosition.Location = New System.Drawing.Point(13, 9)
        Me.hsSimPosition.Maximum = 1
        Me.hsSimPosition.Name = "hsSimPosition"
        Me.hsSimPosition.Size = New System.Drawing.Size(541, 17)
        Me.hsSimPosition.TabIndex = 1
        '
        'VRTMTable
        '
        Me.VRTMTable.AllowUserToAddRows = False
        Me.VRTMTable.AllowUserToDeleteRows = False
        Me.VRTMTable.AllowUserToResizeColumns = False
        Me.VRTMTable.AllowUserToResizeRows = False
        Me.VRTMTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.VRTMTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VRTMTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.VRTMTable.Location = New System.Drawing.Point(0, 0)
        Me.VRTMTable.Margin = New System.Windows.Forms.Padding(4)
        Me.VRTMTable.Name = "VRTMTable"
        Me.VRTMTable.ReadOnly = True
        Me.VRTMTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.VRTMTable.ShowEditingIcon = False
        Me.VRTMTable.Size = New System.Drawing.Size(820, 903)
        Me.VRTMTable.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ErrorProvider2
        '
        Me.ErrorProvider2.ContainerControl = Me
        '
        'tmrPlayback
        '
        Me.tmrPlayback.Interval = 500
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1552, 975)
        Me.Controls.Add(Me.Divisor1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainWindow"
        Me.Text = "VRTM Simulator V1.0"
        Me.Divisor1.Panel1.ResumeLayout(False)
        Me.Divisor1.Panel2.ResumeLayout(False)
        CType(Me.Divisor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Divisor1.ResumeLayout(False)
        Me.LeftPanel.Panel1.ResumeLayout(False)
        Me.LeftPanel.Panel1.PerformLayout()
        Me.LeftPanel.Panel2.ResumeLayout(False)
        CType(Me.LeftPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LeftPanel.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.VRTMParams.ResumeLayout(False)
        Me.VRTMParams.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MachRoom.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Production.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.SimParams.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.Divisor2.Panel1.ResumeLayout(False)
        CType(Me.Divisor2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Divisor2.ResumeLayout(False)
        Me.MidPanel.Panel1.ResumeLayout(False)
        Me.MidPanel.Panel1.PerformLayout()
        Me.MidPanel.Panel2.ResumeLayout(False)
        CType(Me.MidPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MidPanel.ResumeLayout(False)
        CType(Me.VRTMTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Divisor1 As SplitContainer
    Friend WithEvents Divisor2 As SplitContainer
    Friend WithEvents VRTMTable As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtBoxesPerTray As TextBox
    Friend WithEvents txtNTrays As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNLevels As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdHLEdit As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtEvapSurf As TextBox
    Friend WithEvents txtFanFlow As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtHL As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtStCap As TextBox
    Friend WithEvents txtGlobalHX As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtReferenceCapacity As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTCond As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtTevapSP As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents VRTMParams As TabPage
    Friend WithEvents MachRoom As TabPage
    Friend WithEvents Production As TabPage
    Friend WithEvents SimParams As TabPage
    Friend WithEvents ProdStats As TabPage
    Friend WithEvents LeftPanel As SplitContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnReduceSpeed As ToolStripButton
    Friend WithEvents btnStop As ToolStripButton
    Friend WithEvents btnPlay As ToolStripButton
    Friend WithEvents btnIncreaseSpeed As ToolStripButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtAvgBoxMass As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtAvgBoxflowIn As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents chkSundayMR As CheckBox
    Friend WithEvents chkSaturdayMR As CheckBox
    Friend WithEvents chkFridayMR As CheckBox
    Friend WithEvents chkThursdayMR As CheckBox
    Friend WithEvents chkWednesdayMR As CheckBox
    Friend WithEvents chkTuesdayMR As CheckBox
    Friend WithEvents chkMondayMR As CheckBox
    Friend WithEvents txtIdleHourEndsMR As MaskedTextBox
    Friend WithEvents txtIdleHourBeginMR As MaskedTextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents txtSchVRTMEnd As MaskedTextBox
    Friend WithEvents txtSchVRTMBegin As MaskedTextBox
    Friend WithEvents chkSundayVRTM As CheckBox
    Friend WithEvents chkSaturdayVRTM As CheckBox
    Friend WithEvents chkFridayVRTM As CheckBox
    Friend WithEvents chkThursdayVRTM As CheckBox
    Friend WithEvents chkWednesdayVRTM As CheckBox
    Friend WithEvents chkTuesdayVRTM As CheckBox
    Friend WithEvents chkMondayVRTM As CheckBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents txtFirstTurnEnds As MaskedTextBox
    Friend WithEvents txtFirstTurnBegins As MaskedTextBox
    Friend WithEvents chkSundayProd As CheckBox
    Friend WithEvents chkSaturdayProd As CheckBox
    Friend WithEvents chkFridayProd As CheckBox
    Friend WithEvents chkThursdayProd As CheckBox
    Friend WithEvents chkWednesdayProd As CheckBox
    Friend WithEvents chkTuesdayProd As CheckBox
    Friend WithEvents chkMondayProd As CheckBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents cmdPrdMixSetup As Button
    Friend WithEvents chkSecondTurn As CheckBox
    Friend WithEvents txtSecondTurnEnds As MaskedTextBox
    Friend WithEvents txtSecondTurnBegins As MaskedTextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents chkFirstTurn As CheckBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtAvgMassFlowIn As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cmdCopyMachineRoom As Button
    Friend WithEvents cmdCopyVRTM As Button
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents txtTotalSimTime As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtMinimumSimDT As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SimulationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunProcessSimulationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunThermalSimulationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlaybackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenSimulationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveSimulationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents lblTimeWarp As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ReduceSpeedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IncreaseSpeedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MidPanel As SplitContainer
    Friend WithEvents hsSimPosition As HScrollBar
    Friend WithEvents lblCurrentPos As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents txtAvgHeatLoad As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents cmdMRSetup As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSafetyFactorVRTM As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents lblDisplayVariable As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtAcceptedDt As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents txtWeeklyHeatLoad As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents txtFanPower As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents DisplayParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ErrorProvider2 As ErrorProvider
    Friend WithEvents tmrPlayback As Timer
End Class
