﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
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
        Me.OpenSimulationVariablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveSimulationResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.cmbFluidRefrigerant = New System.Windows.Forms.ComboBox()
        Me.Label75 = New System.Windows.Forms.Label()
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
        Me.grpTunnelOrg = New System.Windows.Forms.GroupBox()
        Me.chkImprovedWeekendStrat = New System.Windows.Forms.CheckBox()
        Me.chkIdleHoursReshelving = New System.Windows.Forms.CheckBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.txtMinimumReshelvingWindow = New System.Windows.Forms.TextBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.grpDemandProf = New System.Windows.Forms.GroupBox()
        Me.chkRandomPickingBias = New System.Windows.Forms.CheckBox()
        Me.txtPickingOrderProfile = New System.Windows.Forms.ComboBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.txtExternalDemandProfileFile = New System.Windows.Forms.TextBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.chkStopOnDemand = New System.Windows.Forms.CheckBox()
        Me.chkDelayDemand = New System.Windows.Forms.CheckBox()
        Me.txtLevelChoosing = New System.Windows.Forms.ComboBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.txtDelayDemandTime = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.SimParams = New System.Windows.Forms.TabPage()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtLevelCenterDist = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.txtUnloaderRetractionTime = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtBoxUnloadingTime = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.txtBoxLoadingTime = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txtEmptyLevel = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtReturnLevel = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txtTrayTransferTime = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txtUnloadLevel = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtLoadLevel = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtElevatorSpeed = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtElevatorAccel = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
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
        Me.RightPanel = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.SimStats = New System.Windows.Forms.TabControl()
        Me.tabCurrentFrame = New System.Windows.Forms.TabPage()
        Me.lstCurrentFrameStats = New System.Windows.Forms.ListView()
        Me.tabSimTotals = New System.Windows.Forms.TabPage()
        Me.lstSimTotalsStats = New System.Windows.Forms.ListView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.GraphicalSummaryTab = New System.Windows.Forms.TabControl()
        Me.tabTunnelTemperature = New System.Windows.Forms.TabPage()
        Me.TProfileGraph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabHeatLoad = New System.Windows.Forms.TabPage()
        Me.HLProfileGraph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabRetTime = New System.Windows.Forms.TabPage()
        Me.RetentionTimeGraph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabExitTemp = New System.Windows.Forms.TabPage()
        Me.ExitTempGraph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tmrPlayback = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.ProdStats.SuspendLayout()
        Me.grpTunnelOrg.SuspendLayout()
        Me.grpDemandProf.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.SimParams.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.Divisor2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Divisor2.Panel1.SuspendLayout()
        Me.Divisor2.Panel2.SuspendLayout()
        Me.Divisor2.SuspendLayout()
        CType(Me.MidPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MidPanel.Panel1.SuspendLayout()
        Me.MidPanel.Panel2.SuspendLayout()
        Me.MidPanel.SuspendLayout()
        CType(Me.VRTMTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RightPanel.Panel1.SuspendLayout()
        Me.RightPanel.Panel2.SuspendLayout()
        Me.RightPanel.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SimStats.SuspendLayout()
        Me.tabCurrentFrame.SuspendLayout()
        Me.tabSimTotals.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GraphicalSummaryTab.SuspendLayout()
        Me.tabTunnelTemperature.SuspendLayout()
        CType(Me.TProfileGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabHeatLoad.SuspendLayout()
        CType(Me.HLProfileGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRetTime.SuspendLayout()
        CType(Me.RetentionTimeGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabExitTemp.SuspendLayout()
        CType(Me.ExitTempGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Divisor1
        '
        Me.Divisor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Divisor1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.Divisor1.Location = New System.Drawing.Point(0, 0)
        Me.Divisor1.Name = "Divisor1"
        '
        'Divisor1.Panel1
        '
        Me.Divisor1.Panel1.Controls.Add(Me.LeftPanel)
        '
        'Divisor1.Panel2
        '
        Me.Divisor1.Panel2.Controls.Add(Me.Divisor2)
        Me.Divisor1.Size = New System.Drawing.Size(1332, 792)
        Me.Divisor1.SplitterDistance = 324
        Me.Divisor1.TabIndex = 1
        '
        'LeftPanel
        '
        Me.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeftPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.LeftPanel.Location = New System.Drawing.Point(0, 0)
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
        Me.LeftPanel.Size = New System.Drawing.Size(324, 792)
        Me.LeftPanel.SplitterDistance = 52
        Me.LeftPanel.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnReduceSpeed, Me.btnStop, Me.btnPlay, Me.btnIncreaseSpeed, Me.ToolStripSeparator2, Me.lblTimeWarp, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
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
        Me.lblTimeWarp.Size = New System.Drawing.Size(42, 24)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(324, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenSimulationToolStripMenuItem, Me.SaveSimulationToolStripMenuItem, Me.OpenSimulationVariablesToolStripMenuItem, Me.SaveSimulationResultsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenSimulationToolStripMenuItem
        '
        Me.OpenSimulationToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.document_open_5
        Me.OpenSimulationToolStripMenuItem.Name = "OpenSimulationToolStripMenuItem"
        Me.OpenSimulationToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.OpenSimulationToolStripMenuItem.Text = "&Open Simulation Setup"
        '
        'SaveSimulationToolStripMenuItem
        '
        Me.SaveSimulationToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.document_save_5
        Me.SaveSimulationToolStripMenuItem.Name = "SaveSimulationToolStripMenuItem"
        Me.SaveSimulationToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SaveSimulationToolStripMenuItem.Text = "&Save Simulation Setup"
        '
        'OpenSimulationVariablesToolStripMenuItem
        '
        Me.OpenSimulationVariablesToolStripMenuItem.Name = "OpenSimulationVariablesToolStripMenuItem"
        Me.OpenSimulationVariablesToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.OpenSimulationVariablesToolStripMenuItem.Text = "Open Simulation &Results"
        '
        'SaveSimulationResultsToolStripMenuItem
        '
        Me.SaveSimulationResultsToolStripMenuItem.Name = "SaveSimulationResultsToolStripMenuItem"
        Me.SaveSimulationResultsToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SaveSimulationResultsToolStripMenuItem.Text = "Save Simulation R&esults"
        '
        'SimulationToolStripMenuItem
        '
        Me.SimulationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunProcessSimulationToolStripMenuItem, Me.RunThermalSimulationToolStripMenuItem})
        Me.SimulationToolStripMenuItem.Name = "SimulationToolStripMenuItem"
        Me.SimulationToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.SimulationToolStripMenuItem.Text = "Si&mulation"
        '
        'RunProcessSimulationToolStripMenuItem
        '
        Me.RunProcessSimulationToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.script_gear
        Me.RunProcessSimulationToolStripMenuItem.Name = "RunProcessSimulationToolStripMenuItem"
        Me.RunProcessSimulationToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.RunProcessSimulationToolStripMenuItem.Text = "Run Process Simulation"
        '
        'RunThermalSimulationToolStripMenuItem
        '
        Me.RunThermalSimulationToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.pictograms_hazard_signs_xtremely_flammable
        Me.RunThermalSimulationToolStripMenuItem.Name = "RunThermalSimulationToolStripMenuItem"
        Me.RunThermalSimulationToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.RunThermalSimulationToolStripMenuItem.Text = "Run Thermal Simulation"
        '
        'PlaybackToolStripMenuItem
        '
        Me.PlaybackToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReduceSpeedToolStripMenuItem, Me.StopToolStripMenuItem, Me.PlayToolStripMenuItem, Me.IncreaseSpeedToolStripMenuItem, Me.ToolStripSeparator1, Me.DisplayParametersToolStripMenuItem})
        Me.PlaybackToolStripMenuItem.Name = "PlaybackToolStripMenuItem"
        Me.PlaybackToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.PlaybackToolStripMenuItem.Text = "&Playback"
        '
        'ReduceSpeedToolStripMenuItem
        '
        Me.ReduceSpeedToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.media_seek_backward_3
        Me.ReduceSpeedToolStripMenuItem.Name = "ReduceSpeedToolStripMenuItem"
        Me.ReduceSpeedToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ReduceSpeedToolStripMenuItem.Text = "Reduce Speed"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.media_playback_stop_3
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'PlayToolStripMenuItem
        '
        Me.PlayToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.media_playback_start_3
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        Me.PlayToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.PlayToolStripMenuItem.Text = "Play"
        '
        'IncreaseSpeedToolStripMenuItem
        '
        Me.IncreaseSpeedToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.media_seek_forward_3
        Me.IncreaseSpeedToolStripMenuItem.Name = "IncreaseSpeedToolStripMenuItem"
        Me.IncreaseSpeedToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.IncreaseSpeedToolStripMenuItem.Text = "Increase Speed"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(171, 6)
        '
        'DisplayParametersToolStripMenuItem
        '
        Me.DisplayParametersToolStripMenuItem.Image = Global.VRTM_Simulator.My.Resources.Resources.page_white_paintbrush
        Me.DisplayParametersToolStripMenuItem.Name = "DisplayParametersToolStripMenuItem"
        Me.DisplayParametersToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
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
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(324, 736)
        Me.TabControl1.TabIndex = 20
        '
        'VRTMParams
        '
        Me.VRTMParams.Controls.Add(Me.Label32)
        Me.VRTMParams.Controls.Add(Me.GroupBox7)
        Me.VRTMParams.Controls.Add(Me.GroupBox1)
        Me.VRTMParams.Controls.Add(Me.GroupBox2)
        Me.VRTMParams.Location = New System.Drawing.Point(4, 40)
        Me.VRTMParams.Name = "VRTMParams"
        Me.VRTMParams.Padding = New System.Windows.Forms.Padding(3)
        Me.VRTMParams.Size = New System.Drawing.Size(316, 692)
        Me.VRTMParams.TabIndex = 0
        Me.VRTMParams.Text = "VRT Params"
        Me.VRTMParams.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(189, 29)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(34, 13)
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
        Me.GroupBox7.Location = New System.Drawing.Point(15, 285)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(211, 287)
        Me.GroupBox7.TabIndex = 17
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Schedule"
        '
        'cmdCopyMachineRoom
        '
        Me.cmdCopyMachineRoom.Location = New System.Drawing.Point(83, 254)
        Me.cmdCopyMachineRoom.Name = "cmdCopyMachineRoom"
        Me.cmdCopyMachineRoom.Size = New System.Drawing.Size(120, 26)
        Me.cmdCopyMachineRoom.TabIndex = 19
        Me.cmdCopyMachineRoom.Text = "Copy Machine Room"
        Me.cmdCopyMachineRoom.UseVisualStyleBackColor = True
        '
        'txtSchVRTMEnd
        '
        Me.txtSchVRTMEnd.Location = New System.Drawing.Point(78, 68)
        Me.txtSchVRTMEnd.Mask = "00:00"
        Me.txtSchVRTMEnd.Name = "txtSchVRTMEnd"
        Me.txtSchVRTMEnd.Size = New System.Drawing.Size(57, 20)
        Me.txtSchVRTMEnd.TabIndex = 11
        Me.txtSchVRTMEnd.ValidatingType = GetType(Date)
        '
        'txtSchVRTMBegin
        '
        Me.txtSchVRTMBegin.Location = New System.Drawing.Point(78, 44)
        Me.txtSchVRTMBegin.Mask = "00:00"
        Me.txtSchVRTMBegin.Name = "txtSchVRTMBegin"
        Me.txtSchVRTMBegin.Size = New System.Drawing.Size(57, 20)
        Me.txtSchVRTMBegin.TabIndex = 10
        '
        'chkSundayVRTM
        '
        Me.chkSundayVRTM.AutoSize = True
        Me.chkSundayVRTM.Location = New System.Drawing.Point(33, 232)
        Me.chkSundayVRTM.Name = "chkSundayVRTM"
        Me.chkSundayVRTM.Size = New System.Drawing.Size(62, 17)
        Me.chkSundayVRTM.TabIndex = 18
        Me.chkSundayVRTM.Text = "Sunday"
        Me.chkSundayVRTM.UseVisualStyleBackColor = True
        '
        'chkSaturdayVRTM
        '
        Me.chkSaturdayVRTM.AutoSize = True
        Me.chkSaturdayVRTM.Location = New System.Drawing.Point(33, 209)
        Me.chkSaturdayVRTM.Name = "chkSaturdayVRTM"
        Me.chkSaturdayVRTM.Size = New System.Drawing.Size(68, 17)
        Me.chkSaturdayVRTM.TabIndex = 17
        Me.chkSaturdayVRTM.Text = "Saturday"
        Me.chkSaturdayVRTM.UseVisualStyleBackColor = True
        '
        'chkFridayVRTM
        '
        Me.chkFridayVRTM.AutoSize = True
        Me.chkFridayVRTM.Location = New System.Drawing.Point(33, 186)
        Me.chkFridayVRTM.Name = "chkFridayVRTM"
        Me.chkFridayVRTM.Size = New System.Drawing.Size(54, 17)
        Me.chkFridayVRTM.TabIndex = 16
        Me.chkFridayVRTM.Text = "Friday"
        Me.chkFridayVRTM.UseVisualStyleBackColor = True
        '
        'chkThursdayVRTM
        '
        Me.chkThursdayVRTM.AutoSize = True
        Me.chkThursdayVRTM.Location = New System.Drawing.Point(33, 163)
        Me.chkThursdayVRTM.Name = "chkThursdayVRTM"
        Me.chkThursdayVRTM.Size = New System.Drawing.Size(70, 17)
        Me.chkThursdayVRTM.TabIndex = 15
        Me.chkThursdayVRTM.Text = "Thursday"
        Me.chkThursdayVRTM.UseVisualStyleBackColor = True
        '
        'chkWednesdayVRTM
        '
        Me.chkWednesdayVRTM.AutoSize = True
        Me.chkWednesdayVRTM.Location = New System.Drawing.Point(33, 140)
        Me.chkWednesdayVRTM.Name = "chkWednesdayVRTM"
        Me.chkWednesdayVRTM.Size = New System.Drawing.Size(83, 17)
        Me.chkWednesdayVRTM.TabIndex = 14
        Me.chkWednesdayVRTM.Text = "Wednesday"
        Me.chkWednesdayVRTM.UseVisualStyleBackColor = True
        '
        'chkTuesdayVRTM
        '
        Me.chkTuesdayVRTM.AutoSize = True
        Me.chkTuesdayVRTM.Location = New System.Drawing.Point(33, 117)
        Me.chkTuesdayVRTM.Name = "chkTuesdayVRTM"
        Me.chkTuesdayVRTM.Size = New System.Drawing.Size(67, 17)
        Me.chkTuesdayVRTM.TabIndex = 13
        Me.chkTuesdayVRTM.Text = "Tuesday"
        Me.chkTuesdayVRTM.UseVisualStyleBackColor = True
        '
        'chkMondayVRTM
        '
        Me.chkMondayVRTM.AutoSize = True
        Me.chkMondayVRTM.Location = New System.Drawing.Point(33, 94)
        Me.chkMondayVRTM.Name = "chkMondayVRTM"
        Me.chkMondayVRTM.Size = New System.Drawing.Size(64, 17)
        Me.chkMondayVRTM.TabIndex = 12
        Me.chkMondayVRTM.Text = "Monday"
        Me.chkMondayVRTM.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(30, 47)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 13)
        Me.Label25.TabIndex = 11
        Me.Label25.Text = "Begins:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(30, 71)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Ends:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(7, 23)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(186, 13)
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
        Me.GroupBox1.Location = New System.Drawing.Point(15, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(211, 127)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "VRT Parameters"
        '
        'txtStCap
        '
        Me.txtStCap.Enabled = False
        Me.txtStCap.Location = New System.Drawing.Point(94, 89)
        Me.txtStCap.Name = "txtStCap"
        Me.txtStCap.Size = New System.Drawing.Size(74, 20)
        Me.txtStCap.TabIndex = 4
        Me.txtStCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxesPerTray
        '
        Me.txtBoxesPerTray.Location = New System.Drawing.Point(124, 66)
        Me.txtBoxesPerTray.Name = "txtBoxesPerTray"
        Me.txtBoxesPerTray.Size = New System.Drawing.Size(44, 20)
        Me.txtBoxesPerTray.TabIndex = 3
        Me.txtBoxesPerTray.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNTrays
        '
        Me.txtNTrays.Location = New System.Drawing.Point(124, 43)
        Me.txtNTrays.Name = "txtNTrays"
        Me.txtNTrays.Size = New System.Drawing.Size(44, 20)
        Me.txtNTrays.TabIndex = 2
        Me.txtNTrays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNLevels
        '
        Me.txtNLevels.Location = New System.Drawing.Point(124, 20)
        Me.txtNLevels.Name = "txtNLevels"
        Me.txtNLevels.Size = New System.Drawing.Size(44, 20)
        Me.txtNLevels.TabIndex = 1
        Me.txtNLevels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(174, 92)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(35, 13)
        Me.Label38.TabIndex = 7
        Me.Label38.Text = "boxes"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(174, 69)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(35, 13)
        Me.Label37.TabIndex = 6
        Me.Label37.Text = "boxes"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(174, 46)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(29, 13)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = "trays"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Boxes per Tray Group:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Static Capacity:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Number of Trays:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
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
        Me.GroupBox2.Location = New System.Drawing.Point(15, 139)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(211, 140)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Evaporators"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(161, 116)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(44, 13)
        Me.Label41.TabIndex = 9
        Me.Label41.Text = "W/m².K"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(177, 93)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(18, 13)
        Me.Label40.TabIndex = 8
        Me.Label40.Text = "m²"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(177, 69)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(24, 13)
        Me.Label52.TabIndex = 7
        Me.Label52.Text = "kW"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(177, 46)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(29, 13)
        Me.Label39.TabIndex = 7
        Me.Label39.Text = "m³/h"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(147, 24)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(24, 13)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "kW"
        '
        'txtGlobalHX
        '
        Me.txtGlobalHX.Location = New System.Drawing.Point(97, 113)
        Me.txtGlobalHX.Name = "txtGlobalHX"
        Me.txtGlobalHX.Size = New System.Drawing.Size(59, 20)
        Me.txtGlobalHX.TabIndex = 9
        Me.txtGlobalHX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Global HX Coeff.:"
        '
        'txtEvapSurf
        '
        Me.txtEvapSurf.Location = New System.Drawing.Point(116, 90)
        Me.txtEvapSurf.Name = "txtEvapSurf"
        Me.txtEvapSurf.Size = New System.Drawing.Size(55, 20)
        Me.txtEvapSurf.TabIndex = 8
        Me.txtEvapSurf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdHLEdit
        '
        Me.cmdHLEdit.Location = New System.Drawing.Point(173, 20)
        Me.cmdHLEdit.Name = "cmdHLEdit"
        Me.cmdHLEdit.Size = New System.Drawing.Size(25, 20)
        Me.cmdHLEdit.TabIndex = 6
        Me.cmdHLEdit.Text = "..."
        Me.cmdHLEdit.UseVisualStyleBackColor = True
        '
        'txtFanPower
        '
        Me.txtFanPower.Location = New System.Drawing.Point(97, 66)
        Me.txtFanPower.Name = "txtFanPower"
        Me.txtFanPower.Size = New System.Drawing.Size(74, 20)
        Me.txtFanPower.TabIndex = 7
        Me.txtFanPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFanFlow
        '
        Me.txtFanFlow.Location = New System.Drawing.Point(97, 43)
        Me.txtFanFlow.Name = "txtFanFlow"
        Me.txtFanFlow.Size = New System.Drawing.Size(74, 20)
        Me.txtFanFlow.TabIndex = 7
        Me.txtFanFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(7, 69)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 13)
        Me.Label51.TabIndex = 2
        Me.Label51.Text = "Total Fan Power:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Evap. Surface Area:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fan Flow Rate:"
        '
        'txtHL
        '
        Me.txtHL.Enabled = False
        Me.txtHL.Location = New System.Drawing.Point(97, 20)
        Me.txtHL.Name = "txtHL"
        Me.txtHL.Size = New System.Drawing.Size(46, 20)
        Me.txtHL.TabIndex = 5
        Me.txtHL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Fixed Heat Load:"
        '
        'MachRoom
        '
        Me.MachRoom.Controls.Add(Me.GroupBox6)
        Me.MachRoom.Controls.Add(Me.GroupBox3)
        Me.MachRoom.Location = New System.Drawing.Point(4, 40)
        Me.MachRoom.Name = "MachRoom"
        Me.MachRoom.Padding = New System.Windows.Forms.Padding(3)
        Me.MachRoom.Size = New System.Drawing.Size(316, 692)
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
        Me.GroupBox6.Location = New System.Drawing.Point(15, 177)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(211, 272)
        Me.GroupBox6.TabIndex = 16
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Schedule"
        '
        'cmdCopyVRTM
        '
        Me.cmdCopyVRTM.Location = New System.Drawing.Point(116, 239)
        Me.cmdCopyVRTM.Name = "cmdCopyVRTM"
        Me.cmdCopyVRTM.Size = New System.Drawing.Size(88, 26)
        Me.cmdCopyVRTM.TabIndex = 39
        Me.cmdCopyVRTM.Text = "Copy VRTM"
        Me.cmdCopyVRTM.UseVisualStyleBackColor = True
        '
        'txtIdleHourEndsMR
        '
        Me.txtIdleHourEndsMR.Location = New System.Drawing.Point(78, 68)
        Me.txtIdleHourEndsMR.Mask = "00:00"
        Me.txtIdleHourEndsMR.Name = "txtIdleHourEndsMR"
        Me.txtIdleHourEndsMR.Size = New System.Drawing.Size(57, 20)
        Me.txtIdleHourEndsMR.TabIndex = 31
        Me.txtIdleHourEndsMR.ValidatingType = GetType(Date)
        '
        'txtIdleHourBeginMR
        '
        Me.txtIdleHourBeginMR.Location = New System.Drawing.Point(78, 44)
        Me.txtIdleHourBeginMR.Mask = "00:00"
        Me.txtIdleHourBeginMR.Name = "txtIdleHourBeginMR"
        Me.txtIdleHourBeginMR.Size = New System.Drawing.Size(57, 20)
        Me.txtIdleHourBeginMR.TabIndex = 30
        Me.txtIdleHourBeginMR.ValidatingType = GetType(Date)
        '
        'chkSundayMR
        '
        Me.chkSundayMR.AutoSize = True
        Me.chkSundayMR.Location = New System.Drawing.Point(33, 232)
        Me.chkSundayMR.Name = "chkSundayMR"
        Me.chkSundayMR.Size = New System.Drawing.Size(62, 17)
        Me.chkSundayMR.TabIndex = 38
        Me.chkSundayMR.Text = "Sunday"
        Me.chkSundayMR.UseVisualStyleBackColor = True
        '
        'chkSaturdayMR
        '
        Me.chkSaturdayMR.AutoSize = True
        Me.chkSaturdayMR.Location = New System.Drawing.Point(33, 209)
        Me.chkSaturdayMR.Name = "chkSaturdayMR"
        Me.chkSaturdayMR.Size = New System.Drawing.Size(68, 17)
        Me.chkSaturdayMR.TabIndex = 37
        Me.chkSaturdayMR.Text = "Saturday"
        Me.chkSaturdayMR.UseVisualStyleBackColor = True
        '
        'chkFridayMR
        '
        Me.chkFridayMR.AutoSize = True
        Me.chkFridayMR.Location = New System.Drawing.Point(33, 186)
        Me.chkFridayMR.Name = "chkFridayMR"
        Me.chkFridayMR.Size = New System.Drawing.Size(54, 17)
        Me.chkFridayMR.TabIndex = 36
        Me.chkFridayMR.Text = "Friday"
        Me.chkFridayMR.UseVisualStyleBackColor = True
        '
        'chkThursdayMR
        '
        Me.chkThursdayMR.AutoSize = True
        Me.chkThursdayMR.Location = New System.Drawing.Point(33, 163)
        Me.chkThursdayMR.Name = "chkThursdayMR"
        Me.chkThursdayMR.Size = New System.Drawing.Size(70, 17)
        Me.chkThursdayMR.TabIndex = 35
        Me.chkThursdayMR.Text = "Thursday"
        Me.chkThursdayMR.UseVisualStyleBackColor = True
        '
        'chkWednesdayMR
        '
        Me.chkWednesdayMR.AutoSize = True
        Me.chkWednesdayMR.Location = New System.Drawing.Point(33, 140)
        Me.chkWednesdayMR.Name = "chkWednesdayMR"
        Me.chkWednesdayMR.Size = New System.Drawing.Size(83, 17)
        Me.chkWednesdayMR.TabIndex = 34
        Me.chkWednesdayMR.Text = "Wednesday"
        Me.chkWednesdayMR.UseVisualStyleBackColor = True
        '
        'chkTuesdayMR
        '
        Me.chkTuesdayMR.AutoSize = True
        Me.chkTuesdayMR.Location = New System.Drawing.Point(33, 117)
        Me.chkTuesdayMR.Name = "chkTuesdayMR"
        Me.chkTuesdayMR.Size = New System.Drawing.Size(67, 17)
        Me.chkTuesdayMR.TabIndex = 33
        Me.chkTuesdayMR.Text = "Tuesday"
        Me.chkTuesdayMR.UseVisualStyleBackColor = True
        '
        'chkMondayMR
        '
        Me.chkMondayMR.AutoSize = True
        Me.chkMondayMR.Location = New System.Drawing.Point(33, 94)
        Me.chkMondayMR.Name = "chkMondayMR"
        Me.chkMondayMR.Size = New System.Drawing.Size(64, 17)
        Me.chkMondayMR.TabIndex = 32
        Me.chkMondayMR.Text = "Monday"
        Me.chkMondayMR.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(30, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 13)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Begins:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(30, 71)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 13)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Ends:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 23)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(128, 13)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "Mandatory Turnoff Times:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbFluidRefrigerant)
        Me.GroupBox3.Controls.Add(Me.Label75)
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
        Me.GroupBox3.Location = New System.Drawing.Point(15, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 165)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Machines"
        '
        'cmbFluidRefrigerant
        '
        Me.cmbFluidRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFluidRefrigerant.FormattingEnabled = True
        Me.cmbFluidRefrigerant.Items.AddRange(New Object() {"Ammonia"})
        Me.cmbFluidRefrigerant.Location = New System.Drawing.Point(112, 55)
        Me.cmbFluidRefrigerant.Name = "cmbFluidRefrigerant"
        Me.cmbFluidRefrigerant.Size = New System.Drawing.Size(88, 21)
        Me.cmbFluidRefrigerant.TabIndex = 30
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(6, 59)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(87, 13)
        Me.Label75.TabIndex = 29
        Me.Label75.Text = "Fluid Refrigerant:"
        '
        'cmdMRSetup
        '
        Me.cmdMRSetup.Location = New System.Drawing.Point(33, 21)
        Me.cmdMRSetup.Name = "cmdMRSetup"
        Me.cmdMRSetup.Size = New System.Drawing.Size(134, 26)
        Me.cmdMRSetup.TabIndex = 27
        Me.cmdMRSetup.Text = "Setup Machine Room..."
        Me.cmdMRSetup.UseVisualStyleBackColor = True
        '
        'txtReferenceCapacity
        '
        Me.txtReferenceCapacity.Enabled = False
        Me.txtReferenceCapacity.Location = New System.Drawing.Point(116, 130)
        Me.txtReferenceCapacity.Name = "txtReferenceCapacity"
        Me.txtReferenceCapacity.Size = New System.Drawing.Size(60, 20)
        Me.txtReferenceCapacity.TabIndex = 26
        Me.txtReferenceCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(182, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "kW"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(182, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "ºC"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(182, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "ºC"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Condensing Temp.:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Ref. Capacity:"
        '
        'txtTevapSP
        '
        Me.txtTevapSP.Location = New System.Drawing.Point(115, 106)
        Me.txtTevapSP.Name = "txtTevapSP"
        Me.txtTevapSP.Size = New System.Drawing.Size(61, 20)
        Me.txtTevapSP.TabIndex = 27
        Me.txtTevapSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTCond
        '
        Me.txtTCond.Location = New System.Drawing.Point(115, 82)
        Me.txtTCond.Name = "txtTCond"
        Me.txtTCond.Size = New System.Drawing.Size(61, 20)
        Me.txtTCond.TabIndex = 28
        Me.txtTCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 109)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Setpoint Tevap:"
        '
        'Production
        '
        Me.Production.Controls.Add(Me.GroupBox8)
        Me.Production.Controls.Add(Me.GroupBox5)
        Me.Production.Location = New System.Drawing.Point(4, 40)
        Me.Production.Name = "Production"
        Me.Production.Size = New System.Drawing.Size(316, 692)
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
        Me.GroupBox8.Location = New System.Drawing.Point(16, 230)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(211, 362)
        Me.GroupBox8.TabIndex = 17
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Schedule"
        '
        'chkSecondTurn
        '
        Me.chkSecondTurn.AutoSize = True
        Me.chkSecondTurn.Location = New System.Drawing.Point(10, 94)
        Me.chkSecondTurn.Name = "chkSecondTurn"
        Me.chkSecondTurn.Size = New System.Drawing.Size(145, 17)
        Me.chkSecondTurn.TabIndex = 48
        Me.chkSecondTurn.Text = "Second Production Turn:"
        Me.chkSecondTurn.UseVisualStyleBackColor = True
        '
        'txtSecondTurnEnds
        '
        Me.txtSecondTurnEnds.Location = New System.Drawing.Point(77, 141)
        Me.txtSecondTurnEnds.Mask = "00:00"
        Me.txtSecondTurnEnds.Name = "txtSecondTurnEnds"
        Me.txtSecondTurnEnds.Size = New System.Drawing.Size(57, 20)
        Me.txtSecondTurnEnds.TabIndex = 50
        Me.txtSecondTurnEnds.ValidatingType = GetType(Date)
        '
        'txtSecondTurnBegins
        '
        Me.txtSecondTurnBegins.Location = New System.Drawing.Point(77, 117)
        Me.txtSecondTurnBegins.Mask = "00:00"
        Me.txtSecondTurnBegins.Name = "txtSecondTurnBegins"
        Me.txtSecondTurnBegins.Size = New System.Drawing.Size(57, 20)
        Me.txtSecondTurnBegins.TabIndex = 49
        Me.txtSecondTurnBegins.ValidatingType = GetType(Date)
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(29, 120)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(42, 13)
        Me.Label30.TabIndex = 23
        Me.Label30.Text = "Begins:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(29, 144)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(34, 13)
        Me.Label31.TabIndex = 24
        Me.Label31.Text = "Ends:"
        '
        'chkFirstTurn
        '
        Me.chkFirstTurn.AutoSize = True
        Me.chkFirstTurn.Location = New System.Drawing.Point(11, 21)
        Me.chkFirstTurn.Name = "chkFirstTurn"
        Me.chkFirstTurn.Size = New System.Drawing.Size(127, 17)
        Me.chkFirstTurn.TabIndex = 45
        Me.chkFirstTurn.Text = "First Production Turn:"
        Me.chkFirstTurn.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 172)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 13)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "Operation Days:"
        '
        'txtFirstTurnEnds
        '
        Me.txtFirstTurnEnds.Location = New System.Drawing.Point(78, 68)
        Me.txtFirstTurnEnds.Mask = "00:00"
        Me.txtFirstTurnEnds.Name = "txtFirstTurnEnds"
        Me.txtFirstTurnEnds.Size = New System.Drawing.Size(57, 20)
        Me.txtFirstTurnEnds.TabIndex = 47
        Me.txtFirstTurnEnds.ValidatingType = GetType(Date)
        '
        'txtFirstTurnBegins
        '
        Me.txtFirstTurnBegins.Location = New System.Drawing.Point(78, 44)
        Me.txtFirstTurnBegins.Mask = "00:00"
        Me.txtFirstTurnBegins.Name = "txtFirstTurnBegins"
        Me.txtFirstTurnBegins.Size = New System.Drawing.Size(57, 20)
        Me.txtFirstTurnBegins.TabIndex = 46
        Me.txtFirstTurnBegins.ValidatingType = GetType(Date)
        '
        'chkSundayProd
        '
        Me.chkSundayProd.AutoSize = True
        Me.chkSundayProd.Location = New System.Drawing.Point(33, 333)
        Me.chkSundayProd.Name = "chkSundayProd"
        Me.chkSundayProd.Size = New System.Drawing.Size(62, 17)
        Me.chkSundayProd.TabIndex = 57
        Me.chkSundayProd.Text = "Sunday"
        Me.chkSundayProd.UseVisualStyleBackColor = True
        '
        'chkSaturdayProd
        '
        Me.chkSaturdayProd.AutoSize = True
        Me.chkSaturdayProd.Location = New System.Drawing.Point(33, 310)
        Me.chkSaturdayProd.Name = "chkSaturdayProd"
        Me.chkSaturdayProd.Size = New System.Drawing.Size(68, 17)
        Me.chkSaturdayProd.TabIndex = 56
        Me.chkSaturdayProd.Text = "Saturday"
        Me.chkSaturdayProd.UseVisualStyleBackColor = True
        '
        'chkFridayProd
        '
        Me.chkFridayProd.AutoSize = True
        Me.chkFridayProd.Location = New System.Drawing.Point(33, 287)
        Me.chkFridayProd.Name = "chkFridayProd"
        Me.chkFridayProd.Size = New System.Drawing.Size(54, 17)
        Me.chkFridayProd.TabIndex = 55
        Me.chkFridayProd.Text = "Friday"
        Me.chkFridayProd.UseVisualStyleBackColor = True
        '
        'chkThursdayProd
        '
        Me.chkThursdayProd.AutoSize = True
        Me.chkThursdayProd.Location = New System.Drawing.Point(33, 264)
        Me.chkThursdayProd.Name = "chkThursdayProd"
        Me.chkThursdayProd.Size = New System.Drawing.Size(70, 17)
        Me.chkThursdayProd.TabIndex = 54
        Me.chkThursdayProd.Text = "Thursday"
        Me.chkThursdayProd.UseVisualStyleBackColor = True
        '
        'chkWednesdayProd
        '
        Me.chkWednesdayProd.AutoSize = True
        Me.chkWednesdayProd.Location = New System.Drawing.Point(33, 241)
        Me.chkWednesdayProd.Name = "chkWednesdayProd"
        Me.chkWednesdayProd.Size = New System.Drawing.Size(83, 17)
        Me.chkWednesdayProd.TabIndex = 53
        Me.chkWednesdayProd.Text = "Wednesday"
        Me.chkWednesdayProd.UseVisualStyleBackColor = True
        '
        'chkTuesdayProd
        '
        Me.chkTuesdayProd.AutoSize = True
        Me.chkTuesdayProd.Location = New System.Drawing.Point(33, 218)
        Me.chkTuesdayProd.Name = "chkTuesdayProd"
        Me.chkTuesdayProd.Size = New System.Drawing.Size(67, 17)
        Me.chkTuesdayProd.TabIndex = 52
        Me.chkTuesdayProd.Text = "Tuesday"
        Me.chkTuesdayProd.UseVisualStyleBackColor = True
        '
        'chkMondayProd
        '
        Me.chkMondayProd.AutoSize = True
        Me.chkMondayProd.Location = New System.Drawing.Point(33, 195)
        Me.chkMondayProd.Name = "chkMondayProd"
        Me.chkMondayProd.Size = New System.Drawing.Size(64, 17)
        Me.chkMondayProd.TabIndex = 51
        Me.chkMondayProd.Text = "Monday"
        Me.chkMondayProd.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(30, 47)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(42, 13)
        Me.Label28.TabIndex = 11
        Me.Label28.Text = "Begins:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(30, 71)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(34, 13)
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
        Me.GroupBox5.Location = New System.Drawing.Point(16, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(211, 217)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Products"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(177, 152)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(24, 13)
        Me.Label47.TabIndex = 53
        Me.Label47.Text = "kW"
        '
        'txtWeeklyHeatLoad
        '
        Me.txtWeeklyHeatLoad.Enabled = False
        Me.txtWeeklyHeatLoad.Location = New System.Drawing.Point(106, 149)
        Me.txtWeeklyHeatLoad.Name = "txtWeeklyHeatLoad"
        Me.txtWeeklyHeatLoad.Size = New System.Drawing.Size(65, 20)
        Me.txtWeeklyHeatLoad.TabIndex = 52
        Me.txtWeeklyHeatLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(7, 152)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(99, 13)
        Me.Label50.TabIndex = 51
        Me.Label50.Text = "Weekly Heat Load:"
        '
        'txtSafetyFactorVRTM
        '
        Me.txtSafetyFactorVRTM.Location = New System.Drawing.Point(106, 173)
        Me.txtSafetyFactorVRTM.Name = "txtSafetyFactorVRTM"
        Me.txtSafetyFactorVRTM.Size = New System.Drawing.Size(65, 20)
        Me.txtSafetyFactorVRTM.TabIndex = 50
        Me.txtSafetyFactorVRTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 176)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Safety Factor:"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(177, 128)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(24, 13)
        Me.Label44.TabIndex = 48
        Me.Label44.Text = "kW"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(177, 104)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(30, 13)
        Me.Label43.TabIndex = 47
        Me.Label43.Text = "kg/h"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(177, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "un/h"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(177, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 13)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "kg"
        '
        'txtAvgHeatLoad
        '
        Me.txtAvgHeatLoad.Enabled = False
        Me.txtAvgHeatLoad.Location = New System.Drawing.Point(106, 125)
        Me.txtAvgHeatLoad.Name = "txtAvgHeatLoad"
        Me.txtAvgHeatLoad.Size = New System.Drawing.Size(65, 20)
        Me.txtAvgHeatLoad.TabIndex = 44
        Me.txtAvgHeatLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(7, 128)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(86, 13)
        Me.Label42.TabIndex = 7
        Me.Label42.Text = "Daily Heat Load:"
        '
        'txtAvgMassFlowIn
        '
        Me.txtAvgMassFlowIn.Enabled = False
        Me.txtAvgMassFlowIn.Location = New System.Drawing.Point(106, 101)
        Me.txtAvgMassFlowIn.Name = "txtAvgMassFlowIn"
        Me.txtAvgMassFlowIn.Size = New System.Drawing.Size(65, 20)
        Me.txtAvgMassFlowIn.TabIndex = 43
        Me.txtAvgMassFlowIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Avg Mass Flow In:"
        '
        'cmdPrdMixSetup
        '
        Me.cmdPrdMixSetup.Location = New System.Drawing.Point(34, 19)
        Me.cmdPrdMixSetup.Name = "cmdPrdMixSetup"
        Me.cmdPrdMixSetup.Size = New System.Drawing.Size(135, 26)
        Me.cmdPrdMixSetup.TabIndex = 40
        Me.cmdPrdMixSetup.Text = "Setup Product Mix..."
        Me.cmdPrdMixSetup.UseVisualStyleBackColor = True
        '
        'txtAvgBoxMass
        '
        Me.txtAvgBoxMass.Enabled = False
        Me.txtAvgBoxMass.Location = New System.Drawing.Point(106, 53)
        Me.txtAvgBoxMass.Name = "txtAvgBoxMass"
        Me.txtAvgBoxMass.Size = New System.Drawing.Size(65, 20)
        Me.txtAvgBoxMass.TabIndex = 41
        Me.txtAvgBoxMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Avg Box Mass:"
        '
        'txtAvgBoxflowIn
        '
        Me.txtAvgBoxflowIn.Enabled = False
        Me.txtAvgBoxflowIn.Location = New System.Drawing.Point(106, 77)
        Me.txtAvgBoxflowIn.Name = "txtAvgBoxflowIn"
        Me.txtAvgBoxflowIn.Size = New System.Drawing.Size(65, 20)
        Me.txtAvgBoxflowIn.TabIndex = 42
        Me.txtAvgBoxflowIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 80)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(87, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Avg Box Flow In:"
        '
        'ProdStats
        '
        Me.ProdStats.Controls.Add(Me.grpTunnelOrg)
        Me.ProdStats.Controls.Add(Me.grpDemandProf)
        Me.ProdStats.Controls.Add(Me.GroupBox11)
        Me.ProdStats.Location = New System.Drawing.Point(4, 40)
        Me.ProdStats.Name = "ProdStats"
        Me.ProdStats.Size = New System.Drawing.Size(316, 692)
        Me.ProdStats.TabIndex = 4
        Me.ProdStats.Text = "Demand"
        Me.ProdStats.UseVisualStyleBackColor = True
        '
        'grpTunnelOrg
        '
        Me.grpTunnelOrg.Controls.Add(Me.chkImprovedWeekendStrat)
        Me.grpTunnelOrg.Controls.Add(Me.chkIdleHoursReshelving)
        Me.grpTunnelOrg.Controls.Add(Me.Label86)
        Me.grpTunnelOrg.Controls.Add(Me.txtMinimumReshelvingWindow)
        Me.grpTunnelOrg.Controls.Add(Me.Label87)
        Me.grpTunnelOrg.Location = New System.Drawing.Point(16, 152)
        Me.grpTunnelOrg.Name = "grpTunnelOrg"
        Me.grpTunnelOrg.Size = New System.Drawing.Size(211, 125)
        Me.grpTunnelOrg.TabIndex = 55
        Me.grpTunnelOrg.TabStop = False
        Me.grpTunnelOrg.Text = "Tunnel Organization"
        '
        'chkImprovedWeekendStrat
        '
        Me.chkImprovedWeekendStrat.AutoSize = True
        Me.chkImprovedWeekendStrat.Location = New System.Drawing.Point(10, 88)
        Me.chkImprovedWeekendStrat.Name = "chkImprovedWeekendStrat"
        Me.chkImprovedWeekendStrat.Size = New System.Drawing.Size(198, 17)
        Me.chkImprovedWeekendStrat.TabIndex = 57
        Me.chkImprovedWeekendStrat.Text = "Enable Improved Weekend Strategy"
        Me.chkImprovedWeekendStrat.UseVisualStyleBackColor = True
        '
        'chkIdleHoursReshelving
        '
        Me.chkIdleHoursReshelving.AutoSize = True
        Me.chkIdleHoursReshelving.Location = New System.Drawing.Point(10, 24)
        Me.chkIdleHoursReshelving.Name = "chkIdleHoursReshelving"
        Me.chkIdleHoursReshelving.Size = New System.Drawing.Size(166, 17)
        Me.chkIdleHoursReshelving.TabIndex = 56
        Me.chkIdleHoursReshelving.Text = "Enable Idle-Hours Reshelving"
        Me.chkIdleHoursReshelving.UseVisualStyleBackColor = True
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Location = New System.Drawing.Point(177, 53)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(13, 13)
        Me.Label86.TabIndex = 45
        Me.Label86.Text = "h"
        '
        'txtMinimumReshelvingWindow
        '
        Me.txtMinimumReshelvingWindow.Enabled = False
        Me.txtMinimumReshelvingWindow.Location = New System.Drawing.Point(106, 50)
        Me.txtMinimumReshelvingWindow.Name = "txtMinimumReshelvingWindow"
        Me.txtMinimumReshelvingWindow.Size = New System.Drawing.Size(65, 20)
        Me.txtMinimumReshelvingWindow.TabIndex = 41
        Me.txtMinimumReshelvingWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(7, 53)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(93, 13)
        Me.Label87.TabIndex = 2
        Me.Label87.Text = "Minimum Window:"
        '
        'grpDemandProf
        '
        Me.grpDemandProf.Controls.Add(Me.chkRandomPickingBias)
        Me.grpDemandProf.Controls.Add(Me.txtPickingOrderProfile)
        Me.grpDemandProf.Controls.Add(Me.Label82)
        Me.grpDemandProf.Controls.Add(Me.txtExternalDemandProfileFile)
        Me.grpDemandProf.Controls.Add(Me.Label84)
        Me.grpDemandProf.Location = New System.Drawing.Point(16, 283)
        Me.grpDemandProf.Name = "grpDemandProf"
        Me.grpDemandProf.Size = New System.Drawing.Size(211, 119)
        Me.grpDemandProf.TabIndex = 54
        Me.grpDemandProf.TabStop = False
        Me.grpDemandProf.Text = "Demand Profile"
        '
        'chkRandomPickingBias
        '
        Me.chkRandomPickingBias.AutoSize = True
        Me.chkRandomPickingBias.Location = New System.Drawing.Point(6, 55)
        Me.chkRandomPickingBias.Name = "chkRandomPickingBias"
        Me.chkRandomPickingBias.Size = New System.Drawing.Size(185, 17)
        Me.chkRandomPickingBias.TabIndex = 57
        Me.chkRandomPickingBias.Text = "Randomly Bias Towards Products"
        Me.chkRandomPickingBias.UseVisualStyleBackColor = True
        '
        'txtPickingOrderProfile
        '
        Me.txtPickingOrderProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtPickingOrderProfile.FormattingEnabled = True
        Me.txtPickingOrderProfile.Items.AddRange(New Object() {"Random", "From File..."})
        Me.txtPickingOrderProfile.Location = New System.Drawing.Point(106, 25)
        Me.txtPickingOrderProfile.Name = "txtPickingOrderProfile"
        Me.txtPickingOrderProfile.Size = New System.Drawing.Size(95, 21)
        Me.txtPickingOrderProfile.TabIndex = 55
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(7, 28)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(79, 13)
        Me.Label82.TabIndex = 54
        Me.Label82.Text = "Picking Orders:"
        '
        'txtExternalDemandProfileFile
        '
        Me.txtExternalDemandProfileFile.Enabled = False
        Me.txtExternalDemandProfileFile.Location = New System.Drawing.Point(106, 81)
        Me.txtExternalDemandProfileFile.Name = "txtExternalDemandProfileFile"
        Me.txtExternalDemandProfileFile.ReadOnly = True
        Me.txtExternalDemandProfileFile.Size = New System.Drawing.Size(95, 20)
        Me.txtExternalDemandProfileFile.TabIndex = 41
        Me.txtExternalDemandProfileFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(7, 84)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(67, 13)
        Me.Label84.TabIndex = 2
        Me.Label84.Text = "External File:"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.chkStopOnDemand)
        Me.GroupBox11.Controls.Add(Me.chkDelayDemand)
        Me.GroupBox11.Controls.Add(Me.txtLevelChoosing)
        Me.GroupBox11.Controls.Add(Me.Label81)
        Me.GroupBox11.Controls.Add(Me.Label76)
        Me.GroupBox11.Controls.Add(Me.txtDelayDemandTime)
        Me.GroupBox11.Controls.Add(Me.Label79)
        Me.GroupBox11.Location = New System.Drawing.Point(16, 6)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(211, 140)
        Me.GroupBox11.TabIndex = 4
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Shelving Strategy"
        '
        'chkStopOnDemand
        '
        Me.chkStopOnDemand.AutoSize = True
        Me.chkStopOnDemand.Location = New System.Drawing.Point(10, 108)
        Me.chkStopOnDemand.Name = "chkStopOnDemand"
        Me.chkStopOnDemand.Size = New System.Drawing.Size(192, 17)
        Me.chkStopOnDemand.TabIndex = 63
        Me.chkStopOnDemand.Text = "Stop Simulation If Demand Not Met"
        Me.chkStopOnDemand.UseVisualStyleBackColor = True
        '
        'chkDelayDemand
        '
        Me.chkDelayDemand.AutoSize = True
        Me.chkDelayDemand.Location = New System.Drawing.Point(10, 55)
        Me.chkDelayDemand.Name = "chkDelayDemand"
        Me.chkDelayDemand.Size = New System.Drawing.Size(167, 17)
        Me.chkDelayDemand.TabIndex = 56
        Me.chkDelayDemand.Text = "Delay Demand During Startup"
        Me.chkDelayDemand.UseVisualStyleBackColor = True
        '
        'txtLevelChoosing
        '
        Me.txtLevelChoosing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtLevelChoosing.FormattingEnabled = True
        Me.txtLevelChoosing.Items.AddRange(New Object() {"Production", "Demand", "Random"})
        Me.txtLevelChoosing.Location = New System.Drawing.Point(106, 25)
        Me.txtLevelChoosing.Name = "txtLevelChoosing"
        Me.txtLevelChoosing.Size = New System.Drawing.Size(95, 21)
        Me.txtLevelChoosing.TabIndex = 55
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(7, 28)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(83, 13)
        Me.Label81.TabIndex = 54
        Me.Label81.Text = "Level Choosing:"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(177, 80)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(29, 13)
        Me.Label76.TabIndex = 45
        Me.Label76.Text = "days"
        '
        'txtDelayDemandTime
        '
        Me.txtDelayDemandTime.Enabled = False
        Me.txtDelayDemandTime.Location = New System.Drawing.Point(106, 77)
        Me.txtDelayDemandTime.Name = "txtDelayDemandTime"
        Me.txtDelayDemandTime.Size = New System.Drawing.Size(65, 20)
        Me.txtDelayDemandTime.TabIndex = 41
        Me.txtDelayDemandTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(7, 80)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(63, 13)
        Me.Label79.TabIndex = 2
        Me.Label79.Text = "Delay Time:"
        '
        'SimParams
        '
        Me.SimParams.Controls.Add(Me.GroupBox10)
        Me.SimParams.Controls.Add(Me.GroupBox4)
        Me.SimParams.Controls.Add(Me.GroupBox9)
        Me.SimParams.Location = New System.Drawing.Point(4, 40)
        Me.SimParams.Name = "SimParams"
        Me.SimParams.Size = New System.Drawing.Size(316, 692)
        Me.SimParams.TabIndex = 3
        Me.SimParams.Text = "Simulation Params"
        Me.SimParams.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label68)
        Me.GroupBox10.Controls.Add(Me.txtLevelCenterDist)
        Me.GroupBox10.Controls.Add(Me.Label69)
        Me.GroupBox10.Controls.Add(Me.Label66)
        Me.GroupBox10.Controls.Add(Me.txtUnloaderRetractionTime)
        Me.GroupBox10.Controls.Add(Me.Label67)
        Me.GroupBox10.Controls.Add(Me.Label64)
        Me.GroupBox10.Controls.Add(Me.txtBoxUnloadingTime)
        Me.GroupBox10.Controls.Add(Me.Label65)
        Me.GroupBox10.Controls.Add(Me.Label58)
        Me.GroupBox10.Controls.Add(Me.txtBoxLoadingTime)
        Me.GroupBox10.Controls.Add(Me.Label60)
        Me.GroupBox10.Controls.Add(Me.Label62)
        Me.GroupBox10.Controls.Add(Me.txtEmptyLevel)
        Me.GroupBox10.Controls.Add(Me.Label71)
        Me.GroupBox10.Controls.Add(Me.txtReturnLevel)
        Me.GroupBox10.Controls.Add(Me.Label54)
        Me.GroupBox10.Controls.Add(Me.txtTrayTransferTime)
        Me.GroupBox10.Controls.Add(Me.Label63)
        Me.GroupBox10.Controls.Add(Me.txtUnloadLevel)
        Me.GroupBox10.Controls.Add(Me.Label61)
        Me.GroupBox10.Controls.Add(Me.txtLoadLevel)
        Me.GroupBox10.Controls.Add(Me.Label59)
        Me.GroupBox10.Controls.Add(Me.Label53)
        Me.GroupBox10.Controls.Add(Me.txtElevatorSpeed)
        Me.GroupBox10.Controls.Add(Me.Label55)
        Me.GroupBox10.Controls.Add(Me.Label56)
        Me.GroupBox10.Controls.Add(Me.txtElevatorAccel)
        Me.GroupBox10.Controls.Add(Me.Label57)
        Me.GroupBox10.Location = New System.Drawing.Point(16, 90)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(211, 301)
        Me.GroupBox10.TabIndex = 64
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Elevator Configuration"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(173, 70)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(23, 13)
        Me.Label68.TabIndex = 82
        Me.Label68.Text = "mm"
        '
        'txtLevelCenterDist
        '
        Me.txtLevelCenterDist.Location = New System.Drawing.Point(124, 67)
        Me.txtLevelCenterDist.Name = "txtLevelCenterDist"
        Me.txtLevelCenterDist.Size = New System.Drawing.Size(43, 20)
        Me.txtLevelCenterDist.TabIndex = 81
        Me.txtLevelCenterDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(7, 70)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(115, 13)
        Me.Label69.TabIndex = 80
        Me.Label69.Text = "Level Center Distance:"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(191, 275)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(12, 13)
        Me.Label66.TabIndex = 79
        Me.Label66.Text = "s"
        '
        'txtUnloaderRetractionTime
        '
        Me.txtUnloaderRetractionTime.Location = New System.Drawing.Point(142, 272)
        Me.txtUnloaderRetractionTime.Name = "txtUnloaderRetractionTime"
        Me.txtUnloaderRetractionTime.Size = New System.Drawing.Size(43, 20)
        Me.txtUnloaderRetractionTime.TabIndex = 78
        Me.txtUnloaderRetractionTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(7, 275)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(131, 13)
        Me.Label67.TabIndex = 77
        Me.Label67.Text = "Unloader Retraction Time:"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(173, 251)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(12, 13)
        Me.Label64.TabIndex = 76
        Me.Label64.Text = "s"
        '
        'txtBoxUnloadingTime
        '
        Me.txtBoxUnloadingTime.Location = New System.Drawing.Point(124, 248)
        Me.txtBoxUnloadingTime.Name = "txtBoxUnloadingTime"
        Me.txtBoxUnloadingTime.Size = New System.Drawing.Size(43, 20)
        Me.txtBoxUnloadingTime.TabIndex = 75
        Me.txtBoxUnloadingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(7, 251)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(105, 13)
        Me.Label65.TabIndex = 74
        Me.Label65.Text = "Box Unloading Time:"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(173, 227)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(12, 13)
        Me.Label58.TabIndex = 73
        Me.Label58.Text = "s"
        '
        'txtBoxLoadingTime
        '
        Me.txtBoxLoadingTime.Location = New System.Drawing.Point(124, 224)
        Me.txtBoxLoadingTime.Name = "txtBoxLoadingTime"
        Me.txtBoxLoadingTime.Size = New System.Drawing.Size(43, 20)
        Me.txtBoxLoadingTime.TabIndex = 72
        Me.txtBoxLoadingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(7, 227)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(95, 13)
        Me.Label60.TabIndex = 71
        Me.Label60.Text = "Box Loading Time:"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(173, 203)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(12, 13)
        Me.Label62.TabIndex = 70
        Me.Label62.Text = "s"
        '
        'txtEmptyLevel
        '
        Me.txtEmptyLevel.Location = New System.Drawing.Point(124, 170)
        Me.txtEmptyLevel.Name = "txtEmptyLevel"
        Me.txtEmptyLevel.Size = New System.Drawing.Size(43, 20)
        Me.txtEmptyLevel.TabIndex = 63
        Me.txtEmptyLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(7, 172)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(68, 13)
        Me.Label71.TabIndex = 62
        Me.Label71.Text = "Empty Level:"
        '
        'txtReturnLevel
        '
        Me.txtReturnLevel.Location = New System.Drawing.Point(124, 146)
        Me.txtReturnLevel.Name = "txtReturnLevel"
        Me.txtReturnLevel.Size = New System.Drawing.Size(43, 20)
        Me.txtReturnLevel.TabIndex = 63
        Me.txtReturnLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(7, 148)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(71, 13)
        Me.Label54.TabIndex = 62
        Me.Label54.Text = "Return Level:"
        '
        'txtTrayTransferTime
        '
        Me.txtTrayTransferTime.Location = New System.Drawing.Point(124, 200)
        Me.txtTrayTransferTime.Name = "txtTrayTransferTime"
        Me.txtTrayTransferTime.Size = New System.Drawing.Size(43, 20)
        Me.txtTrayTransferTime.TabIndex = 69
        Me.txtTrayTransferTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(7, 203)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(99, 13)
        Me.Label63.TabIndex = 68
        Me.Label63.Text = "Tray Transfer Time:"
        '
        'txtUnloadLevel
        '
        Me.txtUnloadLevel.Location = New System.Drawing.Point(124, 122)
        Me.txtUnloadLevel.Name = "txtUnloadLevel"
        Me.txtUnloadLevel.Size = New System.Drawing.Size(43, 20)
        Me.txtUnloadLevel.TabIndex = 66
        Me.txtUnloadLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(7, 125)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(73, 13)
        Me.Label61.TabIndex = 65
        Me.Label61.Text = "Unload Level:"
        '
        'txtLoadLevel
        '
        Me.txtLoadLevel.Location = New System.Drawing.Point(124, 98)
        Me.txtLoadLevel.Name = "txtLoadLevel"
        Me.txtLoadLevel.Size = New System.Drawing.Size(43, 20)
        Me.txtLoadLevel.TabIndex = 63
        Me.txtLoadLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(7, 101)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(63, 13)
        Me.Label59.TabIndex = 62
        Me.Label59.Text = "Load Level:"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(173, 46)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(28, 13)
        Me.Label53.TabIndex = 61
        Me.Label53.Text = "m/s²"
        '
        'txtElevatorSpeed
        '
        Me.txtElevatorSpeed.Location = New System.Drawing.Point(124, 20)
        Me.txtElevatorSpeed.Name = "txtElevatorSpeed"
        Me.txtElevatorSpeed.Size = New System.Drawing.Size(43, 20)
        Me.txtElevatorSpeed.TabIndex = 58
        Me.txtElevatorSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(173, 23)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(36, 13)
        Me.Label55.TabIndex = 2
        Me.Label55.Text = "m/min"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(7, 23)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(83, 13)
        Me.Label56.TabIndex = 2
        Me.Label56.Text = "Elevator Speed:"
        '
        'txtElevatorAccel
        '
        Me.txtElevatorAccel.Location = New System.Drawing.Point(124, 43)
        Me.txtElevatorAccel.Name = "txtElevatorAccel"
        Me.txtElevatorAccel.Size = New System.Drawing.Size(43, 20)
        Me.txtElevatorAccel.TabIndex = 60
        Me.txtElevatorAccel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(7, 46)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(111, 13)
        Me.Label57.TabIndex = 0
        Me.Label57.Text = "Elevator Acceleration:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtAcceptedDt)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 397)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(211, 60)
        Me.GroupBox4.TabIndex = 62
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Food Selector Mini-Simulator"
        '
        'txtAcceptedDt
        '
        Me.txtAcceptedDt.Location = New System.Drawing.Point(124, 20)
        Me.txtAcceptedDt.Name = "txtAcceptedDt"
        Me.txtAcceptedDt.Size = New System.Drawing.Size(43, 20)
        Me.txtAcceptedDt.TabIndex = 58
        Me.txtAcceptedDt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(173, 23)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(18, 13)
        Me.Label48.TabIndex = 2
        Me.Label48.Text = "ºC"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(7, 23)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(114, 13)
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
        Me.GroupBox9.Location = New System.Drawing.Point(16, 9)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(211, 73)
        Me.GroupBox9.TabIndex = 4
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Main Simulator General Configs"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(173, 46)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(12, 13)
        Me.Label46.TabIndex = 61
        Me.Label46.Text = "s"
        '
        'txtTotalSimTime
        '
        Me.txtTotalSimTime.Location = New System.Drawing.Point(124, 20)
        Me.txtTotalSimTime.Name = "txtTotalSimTime"
        Me.txtTotalSimTime.Size = New System.Drawing.Size(43, 20)
        Me.txtTotalSimTime.TabIndex = 58
        Me.txtTotalSimTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(173, 23)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(29, 13)
        Me.Label45.TabIndex = 2
        Me.Label45.Text = "days"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(7, 23)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(111, 13)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "Total Simulation Time:"
        '
        'txtMinimumSimDT
        '
        Me.txtMinimumSimDT.Location = New System.Drawing.Point(124, 43)
        Me.txtMinimumSimDT.Name = "txtMinimumSimDT"
        Me.txtMinimumSimDT.Size = New System.Drawing.Size(43, 20)
        Me.txtMinimumSimDT.TabIndex = 60
        Me.txtMinimumSimDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(7, 46)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(84, 13)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "Minimum Sim Δt:"
        '
        'Divisor2
        '
        Me.Divisor2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Divisor2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.Divisor2.Location = New System.Drawing.Point(0, 0)
        Me.Divisor2.Name = "Divisor2"
        '
        'Divisor2.Panel1
        '
        Me.Divisor2.Panel1.Controls.Add(Me.MidPanel)
        '
        'Divisor2.Panel2
        '
        Me.Divisor2.Panel2.Controls.Add(Me.RightPanel)
        Me.Divisor2.Size = New System.Drawing.Size(1004, 792)
        Me.Divisor2.SplitterDistance = 601
        Me.Divisor2.TabIndex = 0
        '
        'MidPanel
        '
        Me.MidPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MidPanel.IsSplitterFixed = True
        Me.MidPanel.Location = New System.Drawing.Point(0, 0)
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
        Me.MidPanel.Size = New System.Drawing.Size(601, 792)
        Me.MidPanel.SplitterDistance = 54
        Me.MidPanel.TabIndex = 2
        '
        'lblDisplayVariable
        '
        Me.lblDisplayVariable.AutoSize = True
        Me.lblDisplayVariable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayVariable.Location = New System.Drawing.Point(8, 34)
        Me.lblDisplayVariable.Name = "lblDisplayVariable"
        Me.lblDisplayVariable.Size = New System.Drawing.Size(129, 13)
        Me.lblDisplayVariable.TabIndex = 3
        Me.lblDisplayVariable.Text = "Simulation Not Ready"
        '
        'lblCurrentPos
        '
        Me.lblCurrentPos.AutoSize = True
        Me.lblCurrentPos.Location = New System.Drawing.Point(419, 9)
        Me.lblCurrentPos.Name = "lblCurrentPos"
        Me.lblCurrentPos.Size = New System.Drawing.Size(75, 13)
        Me.lblCurrentPos.TabIndex = 2
        Me.lblCurrentPos.Text = "Mo D00 00:00"
        '
        'hsSimPosition
        '
        Me.hsSimPosition.LargeChange = 2
        Me.hsSimPosition.Location = New System.Drawing.Point(10, 7)
        Me.hsSimPosition.Maximum = 1
        Me.hsSimPosition.Name = "hsSimPosition"
        Me.hsSimPosition.Size = New System.Drawing.Size(406, 17)
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
        Me.VRTMTable.Name = "VRTMTable"
        Me.VRTMTable.ReadOnly = True
        Me.VRTMTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.VRTMTable.ShowEditingIcon = False
        Me.VRTMTable.Size = New System.Drawing.Size(601, 734)
        Me.VRTMTable.TabIndex = 0
        '
        'RightPanel
        '
        Me.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightPanel.Name = "RightPanel"
        Me.RightPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'RightPanel.Panel1
        '
        Me.RightPanel.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'RightPanel.Panel2
        '
        Me.RightPanel.Panel2.Controls.Add(Me.SplitContainer2)
        Me.RightPanel.Size = New System.Drawing.Size(399, 792)
        Me.RightPanel.SplitterDistance = 310
        Me.RightPanel.TabIndex = 6
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label70)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SimStats)
        Me.SplitContainer1.Size = New System.Drawing.Size(399, 310)
        Me.SplitContainer1.SplitterDistance = 28
        Me.SplitContainer1.TabIndex = 4
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(7, 7)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(181, 13)
        Me.Label70.TabIndex = 1
        Me.Label70.Text = "Statistics of Current Simulation"
        '
        'SimStats
        '
        Me.SimStats.Controls.Add(Me.tabCurrentFrame)
        Me.SimStats.Controls.Add(Me.tabSimTotals)
        Me.SimStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimStats.Location = New System.Drawing.Point(0, 0)
        Me.SimStats.Name = "SimStats"
        Me.SimStats.SelectedIndex = 0
        Me.SimStats.Size = New System.Drawing.Size(399, 278)
        Me.SimStats.TabIndex = 0
        '
        'tabCurrentFrame
        '
        Me.tabCurrentFrame.Controls.Add(Me.lstCurrentFrameStats)
        Me.tabCurrentFrame.Location = New System.Drawing.Point(4, 22)
        Me.tabCurrentFrame.Name = "tabCurrentFrame"
        Me.tabCurrentFrame.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCurrentFrame.Size = New System.Drawing.Size(391, 252)
        Me.tabCurrentFrame.TabIndex = 0
        Me.tabCurrentFrame.Text = "Current Frame"
        Me.tabCurrentFrame.UseVisualStyleBackColor = True
        '
        'lstCurrentFrameStats
        '
        Me.lstCurrentFrameStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstCurrentFrameStats.Location = New System.Drawing.Point(3, 3)
        Me.lstCurrentFrameStats.Name = "lstCurrentFrameStats"
        Me.lstCurrentFrameStats.Size = New System.Drawing.Size(385, 246)
        Me.lstCurrentFrameStats.TabIndex = 1
        Me.lstCurrentFrameStats.UseCompatibleStateImageBehavior = False
        '
        'tabSimTotals
        '
        Me.tabSimTotals.Controls.Add(Me.lstSimTotalsStats)
        Me.tabSimTotals.Location = New System.Drawing.Point(4, 22)
        Me.tabSimTotals.Name = "tabSimTotals"
        Me.tabSimTotals.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSimTotals.Size = New System.Drawing.Size(391, 252)
        Me.tabSimTotals.TabIndex = 1
        Me.tabSimTotals.Text = "Simulation Totals"
        Me.tabSimTotals.UseVisualStyleBackColor = True
        '
        'lstSimTotalsStats
        '
        Me.lstSimTotalsStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSimTotalsStats.Location = New System.Drawing.Point(3, 3)
        Me.lstSimTotalsStats.Name = "lstSimTotalsStats"
        Me.lstSimTotalsStats.Size = New System.Drawing.Size(385, 246)
        Me.lstSimTotalsStats.TabIndex = 0
        Me.lstSimTotalsStats.UseCompatibleStateImageBehavior = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label72)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GraphicalSummaryTab)
        Me.SplitContainer2.Size = New System.Drawing.Size(399, 478)
        Me.SplitContainer2.SplitterDistance = 27
        Me.SplitContainer2.TabIndex = 5
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(7, 8)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(115, 13)
        Me.Label72.TabIndex = 3
        Me.Label72.Text = "Graphical Summary"
        '
        'GraphicalSummaryTab
        '
        Me.GraphicalSummaryTab.Controls.Add(Me.tabTunnelTemperature)
        Me.GraphicalSummaryTab.Controls.Add(Me.tabHeatLoad)
        Me.GraphicalSummaryTab.Controls.Add(Me.tabRetTime)
        Me.GraphicalSummaryTab.Controls.Add(Me.tabExitTemp)
        Me.GraphicalSummaryTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GraphicalSummaryTab.Location = New System.Drawing.Point(0, 0)
        Me.GraphicalSummaryTab.Name = "GraphicalSummaryTab"
        Me.GraphicalSummaryTab.SelectedIndex = 0
        Me.GraphicalSummaryTab.Size = New System.Drawing.Size(399, 447)
        Me.GraphicalSummaryTab.TabIndex = 2
        '
        'tabTunnelTemperature
        '
        Me.tabTunnelTemperature.Controls.Add(Me.TProfileGraph)
        Me.tabTunnelTemperature.Location = New System.Drawing.Point(4, 22)
        Me.tabTunnelTemperature.Name = "tabTunnelTemperature"
        Me.tabTunnelTemperature.Size = New System.Drawing.Size(391, 421)
        Me.tabTunnelTemperature.TabIndex = 3
        Me.tabTunnelTemperature.Text = "Tunnel Temperatures"
        Me.tabTunnelTemperature.UseVisualStyleBackColor = True
        '
        'TProfileGraph
        '
        Me.TProfileGraph.BorderlineColor = System.Drawing.Color.Gray
        Me.TProfileGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.Name = "ChartArea1"
        Me.TProfileGraph.ChartAreas.Add(ChartArea1)
        Me.TProfileGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TProfileGraph.Location = New System.Drawing.Point(0, 0)
        Me.TProfileGraph.Name = "TProfileGraph"
        Me.TProfileGraph.Size = New System.Drawing.Size(391, 421)
        Me.TProfileGraph.TabIndex = 6
        Me.TProfileGraph.Text = "Chart1"
        '
        'tabHeatLoad
        '
        Me.tabHeatLoad.Controls.Add(Me.HLProfileGraph)
        Me.tabHeatLoad.Location = New System.Drawing.Point(4, 22)
        Me.tabHeatLoad.Name = "tabHeatLoad"
        Me.tabHeatLoad.Padding = New System.Windows.Forms.Padding(3)
        Me.tabHeatLoad.Size = New System.Drawing.Size(391, 421)
        Me.tabHeatLoad.TabIndex = 0
        Me.tabHeatLoad.Text = "Heat Load Profile"
        Me.tabHeatLoad.UseVisualStyleBackColor = True
        '
        'HLProfileGraph
        '
        Me.HLProfileGraph.BorderlineColor = System.Drawing.Color.Gray
        Me.HLProfileGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea2.Name = "ChartArea1"
        Me.HLProfileGraph.ChartAreas.Add(ChartArea2)
        Me.HLProfileGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HLProfileGraph.Location = New System.Drawing.Point(3, 3)
        Me.HLProfileGraph.Name = "HLProfileGraph"
        Me.HLProfileGraph.Size = New System.Drawing.Size(385, 415)
        Me.HLProfileGraph.TabIndex = 5
        Me.HLProfileGraph.Text = "Chart1"
        '
        'tabRetTime
        '
        Me.tabRetTime.Controls.Add(Me.RetentionTimeGraph)
        Me.tabRetTime.Location = New System.Drawing.Point(4, 22)
        Me.tabRetTime.Name = "tabRetTime"
        Me.tabRetTime.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRetTime.Size = New System.Drawing.Size(391, 421)
        Me.tabRetTime.TabIndex = 1
        Me.tabRetTime.Text = "Retention Time"
        Me.tabRetTime.UseVisualStyleBackColor = True
        '
        'RetentionTimeGraph
        '
        Me.RetentionTimeGraph.BorderlineColor = System.Drawing.Color.Gray
        Me.RetentionTimeGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea3.Name = "ChartArea1"
        Me.RetentionTimeGraph.ChartAreas.Add(ChartArea3)
        Me.RetentionTimeGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RetentionTimeGraph.Location = New System.Drawing.Point(3, 3)
        Me.RetentionTimeGraph.Name = "RetentionTimeGraph"
        Me.RetentionTimeGraph.Size = New System.Drawing.Size(385, 415)
        Me.RetentionTimeGraph.TabIndex = 6
        Me.RetentionTimeGraph.Text = "Chart1"
        '
        'tabExitTemp
        '
        Me.tabExitTemp.Controls.Add(Me.ExitTempGraph)
        Me.tabExitTemp.Location = New System.Drawing.Point(4, 22)
        Me.tabExitTemp.Name = "tabExitTemp"
        Me.tabExitTemp.Size = New System.Drawing.Size(391, 421)
        Me.tabExitTemp.TabIndex = 2
        Me.tabExitTemp.Text = "Exit Temperature"
        Me.tabExitTemp.UseVisualStyleBackColor = True
        '
        'ExitTempGraph
        '
        Me.ExitTempGraph.BorderlineColor = System.Drawing.Color.Gray
        Me.ExitTempGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea4.Name = "ChartArea1"
        Me.ExitTempGraph.ChartAreas.Add(ChartArea4)
        Me.ExitTempGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExitTempGraph.Location = New System.Drawing.Point(0, 0)
        Me.ExitTempGraph.Name = "ExitTempGraph"
        Me.ExitTempGraph.Size = New System.Drawing.Size(391, 421)
        Me.ExitTempGraph.TabIndex = 6
        Me.ExitTempGraph.Text = "Chart1"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'tmrPlayback
        '
        Me.tmrPlayback.Interval = 500
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1332, 792)
        Me.Controls.Add(Me.Divisor1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainWindow"
        Me.Text = "VRT Simulator V1.0"
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
        Me.ProdStats.ResumeLayout(False)
        Me.grpTunnelOrg.ResumeLayout(False)
        Me.grpTunnelOrg.PerformLayout()
        Me.grpDemandProf.ResumeLayout(False)
        Me.grpDemandProf.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.SimParams.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.Divisor2.Panel1.ResumeLayout(False)
        Me.Divisor2.Panel2.ResumeLayout(False)
        CType(Me.Divisor2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Divisor2.ResumeLayout(False)
        Me.MidPanel.Panel1.ResumeLayout(False)
        Me.MidPanel.Panel1.PerformLayout()
        Me.MidPanel.Panel2.ResumeLayout(False)
        CType(Me.MidPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MidPanel.ResumeLayout(False)
        CType(Me.VRTMTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RightPanel.Panel1.ResumeLayout(False)
        Me.RightPanel.Panel2.ResumeLayout(False)
        CType(Me.RightPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RightPanel.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SimStats.ResumeLayout(False)
        Me.tabCurrentFrame.ResumeLayout(False)
        Me.tabSimTotals.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GraphicalSummaryTab.ResumeLayout(False)
        Me.tabTunnelTemperature.ResumeLayout(False)
        CType(Me.TProfileGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabHeatLoad.ResumeLayout(False)
        CType(Me.HLProfileGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRetTime.ResumeLayout(False)
        CType(Me.RetentionTimeGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabExitTemp.ResumeLayout(False)
        CType(Me.ExitTempGraph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tmrPlayback As Timer
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenSimulationVariablesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveSimulationResultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents txtReturnLevel As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents Label53 As Label
    Friend WithEvents txtElevatorSpeed As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents txtElevatorAccel As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents txtTrayTransferTime As TextBox
    Friend WithEvents Label63 As Label
    Friend WithEvents txtUnloadLevel As TextBox
    Friend WithEvents Label61 As Label
    Friend WithEvents txtLoadLevel As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents txtUnloaderRetractionTime As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents txtBoxUnloadingTime As TextBox
    Friend WithEvents Label65 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents txtBoxLoadingTime As TextBox
    Friend WithEvents Label60 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents txtLevelCenterDist As TextBox
    Friend WithEvents Label69 As Label
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents txtLevelChoosing As ComboBox
    Friend WithEvents Label81 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents txtDelayDemandTime As TextBox
    Friend WithEvents Label79 As Label
    Friend WithEvents chkDelayDemand As CheckBox
    Friend WithEvents grpDemandProf As GroupBox
    Friend WithEvents txtPickingOrderProfile As ComboBox
    Friend WithEvents Label82 As Label
    Friend WithEvents txtExternalDemandProfileFile As TextBox
    Friend WithEvents Label84 As Label
    Friend WithEvents grpTunnelOrg As GroupBox
    Friend WithEvents chkIdleHoursReshelving As CheckBox
    Friend WithEvents Label86 As Label
    Friend WithEvents txtMinimumReshelvingWindow As TextBox
    Friend WithEvents Label87 As Label
    Friend WithEvents chkImprovedWeekendStrat As CheckBox
    Friend WithEvents chkRandomPickingBias As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label70 As Label
    Friend WithEvents SimStats As TabControl
    Friend WithEvents tabCurrentFrame As TabPage
    Friend WithEvents tabSimTotals As TabPage
    Friend WithEvents chkStopOnDemand As CheckBox
    Friend WithEvents lstCurrentFrameStats As ListView
    Friend WithEvents lstSimTotalsStats As ListView
    Friend WithEvents txtEmptyLevel As TextBox
    Friend WithEvents Label71 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents GraphicalSummaryTab As TabControl
    Friend WithEvents tabHeatLoad As TabPage
    Friend WithEvents tabRetTime As TabPage
    Friend WithEvents tabExitTemp As TabPage
    Friend WithEvents HLProfileGraph As DataVisualization.Charting.Chart
    Friend WithEvents RightPanel As SplitContainer
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents tabTunnelTemperature As TabPage
    Friend WithEvents TProfileGraph As DataVisualization.Charting.Chart
    Friend WithEvents RetentionTimeGraph As DataVisualization.Charting.Chart
    Friend WithEvents ExitTempGraph As DataVisualization.Charting.Chart
    Friend WithEvents cmbFluidRefrigerant As ComboBox
    Friend WithEvents Label75 As Label
End Class
