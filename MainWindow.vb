Imports System.ComponentModel

Public Class MainWindow
#Region "Declares and Private Variables"
    Dim PrevMidPanelSize As System.Drawing.Size
    Dim FormShown As Boolean = False

    Dim playbackTimerPeriod As Long = 250 'Playback timer frame refresh rate in ms
    Dim currentPlaybackSpeedIndex As Long 'Playback speed index on lists
    Dim playbackSpeed As Double 'Playback speed in seconds/timer tick
    Public playbackDefaultSpeeds As List(Of Long) 'Contains all the default playback speeds
    Public playbackDefaultSpeedNames As List(Of String) 'Contains all the default playback speed names (ie. "1.0 h/s")
#End Region

#Region "Initialization"
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initializes all the fields according to the new, blank VRTM
        txtNTrays.Text = Trim(Str(VRTM_SimVariables.nTrays))
        txtNLevels.Text = Trim(Str(VRTM_SimVariables.nLevels))
        txtBoxesPerTray.Text = Trim(Str(VRTM_SimVariables.boxesPerTray))
        txtStCap.Text = Trim(Str(VRTM_SimVariables.nTrays * VRTM_SimVariables.nLevels * VRTM_SimVariables.boxesPerTray))

        txtHL.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.FixedHL))
        txtFanFlow.Text = Trim(Str(VRTM_SimVariables.fanFlowRate))
        txtFanPower.Text = Trim(Str(VRTM_SimVariables.fanPower))
        txtEvapSurf.Text = Trim(Str(VRTM_SimVariables.evapSurfArea))
        txtGlobalHX.Text = Trim(Str(VRTM_SimVariables.globalHX_Coeff))

        txtSchVRTMBegin.Text = DayFractionToHourString(VRTM_SimVariables.IdleHourBeginVRTM)
        txtSchVRTMEnd.Text = DayFractionToHourString(VRTM_SimVariables.IdleHourEndVRTM)
        chkMondayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(0)
        chkTuesdayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(1)
        chkWednesdayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(2)
        chkThursdayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(3)
        chkFridayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(4)
        chkSaturdayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(5)
        chkSundayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(6)

        txtTevapSP.Text = Trim(Str(VRTM_SimVariables.Tevap_Setpoint))
        txtTCond.Text = Trim(Str(VRTM_SimVariables.Tcond))
        txtIdleHourBeginMR.Text = DayFractionToHourString(VRTM_SimVariables.IdleHourBeginMRoom)
        txtIdleHourEndsMR.Text = DayFractionToHourString(VRTM_SimVariables.IdleHourEndMRoom)
        chkMondayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(0)
        chkTuesdayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(1)
        chkWednesdayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(2)
        chkThursdayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(3)
        chkFridayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(4)
        chkSaturdayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(5)
        chkSundayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(6)

        UpdateProductMixStats()
        txtSafetyFactorVRTM.Text = Trim(Str(VRTM_SimVariables.SafetyFactorVRTM))

        txtFirstTurnBegins.Text = DayFractionToHourString(VRTM_SimVariables.FirstTurnBegin)
        txtFirstTurnEnds.Text = DayFractionToHourString(VRTM_SimVariables.FirstTurnEnd)
        txtSecondTurnBegins.Text = DayFractionToHourString(VRTM_SimVariables.SecondTurnBegin)
        txtSecondTurnEnds.Text = DayFractionToHourString(VRTM_SimVariables.SecondTurnEnd)

        chkFirstTurn.Checked = VRTM_SimVariables.FirstProductionTurnEnabled
        chkSecondTurn.Checked = VRTM_SimVariables.SecondProductionTurnEnabled
        chkMondayProd.Checked = VRTM_SimVariables.ProductionDays(0)
        chkTuesdayProd.Checked = VRTM_SimVariables.ProductionDays(1)
        chkWednesdayProd.Checked = VRTM_SimVariables.ProductionDays(2)
        chkThursdayProd.Checked = VRTM_SimVariables.ProductionDays(3)
        chkFridayProd.Checked = VRTM_SimVariables.ProductionDays(4)
        chkSaturdayProd.Checked = VRTM_SimVariables.ProductionDays(5)
        chkSundayProd.Checked = VRTM_SimVariables.ProductionDays(6)

        txtLevelChoosing.SelectedIndex = VRTM_SimVariables.LevelChoosing
        chkDelayDemand.Checked = VRTM_SimVariables.DelayDemand
        txtDelayDemandTime.Text = Trim(Str(VRTM_SimVariables.DelayDemandTime))
        chkIdleHoursReshelving.Checked = VRTM_SimVariables.EnableIdleReshelving
        txtMinimumReshelvingWindow.Text = Trim(Str(VRTM_SimVariables.MinimumReshelvingWindow))
        chkImprovedWeekendStrat.Checked = VRTM_SimVariables.EnableImprovedWeekendStrat
        txtPickingOrderProfile.SelectedIndex = VRTM_SimVariables.PickingOrders
        chkRandomPickingBias.Checked = VRTM_SimVariables.RandomBias
        txtExternalDemandProfileFile.Text = VRTM_SimVariables.ExternalDemandProfilePath

        txtTotalSimTime.Text = Trim(Str(VRTM_SimVariables.TotalSimTime / (3600 * 24)))
        txtMinimumSimDT.Text = Trim(Str(VRTM_SimVariables.MinimumSimDt))
        txtElevatorSpeed.Text = Trim(Str(VRTM_SimVariables.ElevSpeed))
        txtElevatorAccel.Text = Trim(Str(VRTM_SimVariables.ElevAccel))
        txtLevelCenterDist.Text = Trim(Str(VRTM_SimVariables.LevelCenterDist))
        txtLoadLevel.Text = Trim(Str(VRTM_SimVariables.LoadLevel))
        txtUnloadLevel.Text = Trim(Str(VRTM_SimVariables.UnloadLevel))
        txtReturnLevel.Text = Trim(Str(VRTM_SimVariables.ReturnLevel))
        txtTrayTransferTime.Text = Trim(Str(VRTM_SimVariables.TrayTransferTime))
        txtBoxLoadingTime.Text = Trim(Str(VRTM_SimVariables.BoxLoadingTime))
        txtBoxUnloadingTime.Text = Trim(Str(VRTM_SimVariables.BoxUnloadingTime))
        txtUnloaderRetractionTime.Text = Trim(Str(VRTM_SimVariables.UnloaderRetractionTime))
        txtAcceptedDt.Text = Trim(Str(VRTM_SimVariables.AssumedDTForPreviews))

        'Puts in public memory the food properties model table (many products available from settings)
        LoadFoodPropertiesCSVIntoMemory()
        Try
            VRTM_SimVariables.ProductMix(0).FoodThermalPropertiesModel.FoodModelUsed = FoodPropertiesList(18)
            VRTM_SimVariables.ProductMix(1).FoodThermalPropertiesModel.FoodModelUsed = FoodPropertiesList(18)
            VRTM_SimVariables.ProductMix(2).FoodThermalPropertiesModel.FoodModelUsed = FoodPropertiesList(18)
        Catch ex As Exception
            VRTM_SimVariables.ProductMix(0).FoodThermalPropertiesModel.FoodModelUsed = FoodPropertiesList(0)
            VRTM_SimVariables.ProductMix(1).FoodThermalPropertiesModel.FoodModelUsed = FoodPropertiesList(0)
            VRTM_SimVariables.ProductMix(2).FoodThermalPropertiesModel.FoodModelUsed = FoodPropertiesList(0)
        End Try


        'Creates tooltips for the imaged tooltip components
        Try
            Dim T As New ImageTip
            T.InitialDelay = 100
            T.SetToolTip(txtNLevels, "Tray_and_Levels")
            T.SetToolTip(txtNTrays, "Tray_and_Levels")

        Catch ex As Exception

        End Try

        'Inits panel size
        PrevMidPanelSize = MidPanel.Size
        Divisor1.SplitterDistance = 250
        lblCurrentPos.Location = New Point(Divisor2.SplitterDistance - 100, lblCurrentPos.Location.Y)
        hsSimPosition.Width = Divisor2.SplitterDistance - 120

        'Inits the timer playback variable
        InitPlaybackSpeedSettings()
        tmrPlayback.Interval = playbackTimerPeriod
        currentPlaybackSpeedIndex = My.Settings.Main_PlaybackSpeed
        playbackSpeed = (playbackTimerPeriod / 1000) * playbackDefaultSpeeds(currentPlaybackSpeedIndex)
        lblTimeWarp.Text = playbackDefaultSpeedNames(currentPlaybackSpeedIndex)
    End Sub

    Private Sub MainWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'After shown
        PrevMidPanelSize = MidPanel.Size
        FormShown = True
        Me.WindowState = FormWindowState.Maximized
        MidPanel.SplitterDistance = 55
    End Sub

    Private Sub MainWindow_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Closed the window
        My.Settings.Main_PlaybackSpeed = currentPlaybackSpeedIndex
        My.Settings.Save()
    End Sub

    Private Sub Init_DGV(RowNumber As Integer, ColNumber As Integer)
        'Initializes VRTM table
        Try
            Dim i As Integer

            FormatTable()
            VRTMTable.Rows.Clear()
            VRTMTable.Columns.Clear()

            For i = 0 To ColNumber + 1 'Adds two more columns for the elevator wells
                If i = 0 Or i = ColNumber + 1 Then
                    VRTMTable.Columns.Add("Elev", "Elev")
                Else
                    VRTMTable.Columns.Add(Str(i), Str(i))
                End If
            Next
            Redim_Width_DGV()

            VRTMTable.Rows.Add(RowNumber)
            For i = 1 To RowNumber
                VRTMTable.Rows(i - 1).HeaderCell.Value = Str(i)
            Next

            DefaultBGColorTable() 'Makes the BG color the default one
            VRTMTable.ClearSelection()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Layout Redimensioning Handling"
    Private Sub Divisor2_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Divisor2.SplitterMoved
        'Handles the datagridview column resizing
        Redim_Width_DGV()

        'Redims the scrollbar and repositions the labels
        Dim DeltaW As Integer
        DeltaW = MidPanel.Width - PrevMidPanelSize.Width
        hsSimPosition.Width = hsSimPosition.Width + DeltaW
        lblCurrentPos.Left = lblCurrentPos.Left + DeltaW
        PrevMidPanelSize = MidPanel.Size
    End Sub

    Private Sub MainWindow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If FormShown Then
            'Handles the datagridview column resizing
            Redim_Width_DGV()

            'Redims the scrollbar and repositions the labels
            Dim DeltaW As Integer
            DeltaW = MidPanel.Width - PrevMidPanelSize.Width
            hsSimPosition.Width = hsSimPosition.Width + DeltaW
            lblCurrentPos.Left = lblCurrentPos.Left + DeltaW
            PrevMidPanelSize = MidPanel.Size
        End If
    End Sub

    Private Sub Redim_Width_DGV()
        'Redims the column width according to the new DGV total width and the bounds set in the constants
        Try
            Const TableMinColumnWidth As Integer = 40
            Const TableMaxColumnWidth As Integer = 150
            Dim ColWidth As Integer
            ColWidth = Int((VRTMTable.Width - VRTMTable.RowHeadersWidth - 25) / VRTMTable.Columns.Count) '25 accounts for a possible vscrollbar

            If ColWidth < TableMinColumnWidth Then ColWidth = TableMinColumnWidth
            If ColWidth > TableMaxColumnWidth Then ColWidth = TableMaxColumnWidth

            For i = 1 To VRTMTable.Columns.Count
                VRTMTable.Columns(i - 1).Width = ColWidth
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Button Press"
    Private Sub cmdPrdMixSetup_Click(sender As Object, e As EventArgs) Handles cmdPrdMixSetup.Click
        Dim F As New ProductMixSetup
        F.ShowDialog()
        UpdateProductMixStats()
    End Sub

    Private Sub RunProcessSimulationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunProcessSimulationToolStripMenuItem.Click
        Init_DGV(VRTM_SimVariables.nLevels, VRTM_SimVariables.nTrays)
        RunProcessSimulation()

        hsSimPosition.Minimum = 0
        hsSimPosition.Maximum = VRTM_SimVariables.TotalSimTime
        hsSimPosition.SmallChange = VRTM_SimVariables.MinimumSimDt
        hsSimPosition.LargeChange = VRTM_SimVariables.MinimumSimDt * 10
        hsSimPosition.Value = 0

        lblDisplayVariable.Text = "Simulation Completed"
    End Sub

    Private Sub cmdHLEdit_Click(sender As Object, e As EventArgs) Handles cmdHLEdit.Click
        'Shows the fixed heat load form
        Dim F As New FixedHLComponents
        F.ShowDialog()

        txtHL.Text = Trim(Str(Round(VRTM_SimVariables.FixedHeatLoadData.FixedHL, 2)))
        UpdateProductMixStats()
    End Sub

    Private Sub cmdCopyMR(sender As Object, e As EventArgs) Handles cmdCopyMachineRoom.Click
        'Copies the checkboxes from the machine room to the VRTM
        VRTM_SimVariables.IdleDaysVRTM = VRTM_SimVariables.IdleDaysMRoom
        FormShown = False
        chkMondayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(0)
        chkTuesdayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(1)
        chkWednesdayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(2)
        chkThursdayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(3)
        chkFridayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(4)
        chkSaturdayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(5)
        chkSundayVRTM.Checked = VRTM_SimVariables.IdleDaysVRTM(6)
        FormShown = True
    End Sub

    Private Sub cmdCopyVRTMClick(sender As Object, e As EventArgs) Handles cmdCopyVRTM.Click
        'Copies the checkboxes from the machine room to the VRTM
        VRTM_SimVariables.IdleDaysMRoom = VRTM_SimVariables.IdleDaysVRTM
        FormShown = False
        chkMondayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(0)
        chkTuesdayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(1)
        chkWednesdayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(2)
        chkThursdayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(3)
        chkFridayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(4)
        chkSaturdayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(5)
        chkSundayMR.Checked = VRTM_SimVariables.IdleDaysMRoom(6)
        FormShown = True
    End Sub

    Private Sub DisplayParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayParametersToolStripMenuItem.Click
        Dim F As New frmDisplaySettings
        F.ShowDialog()
        UpdateDGVPlayback(Nothing, Nothing)
    End Sub
#End Region

#Region "Validations ====Tab VRTM Params===="
    Private Sub Validate_Positive(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtNLevels.Validating, txtNTrays.Validating, txtBoxesPerTray.Validating, txtFanFlow.Validating, txtEvapSurf.Validating, txtGlobalHX.Validating, txtFanPower.Validating
        'Validates several textboxes that have a numeric input
        If Not (IsNumeric(sender.Text) And Val(sender.text) > 0) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A numeric value must be provided.")
        End If
    End Sub

    Private Sub Validate_Hour_VRTM(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtSchVRTMBegin.Validating, txtSchVRTMEnd.Validating
        'Validates these textboxes that have a time input, and whether the times are consistent
        Dim HourFormat As New System.Text.RegularExpressions.Regex("([0-1][0-9]|2[0-3]):([0-5][0-9])")
        If (Not (HourFormat.IsMatch(sender.Text))) Or CompareHours(txtSchVRTMBegin.Text, txtSchVRTMEnd.Text, "LargerThan") Or CompareHours(txtSchVRTMBegin.Text, txtSchVRTMEnd.Text, "EqualTo") Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A valid begin/end hour combination must be provided.")
        End If
    End Sub

    Private Sub Validated_Textbox_VRTM(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtNLevels.Validated, txtNTrays.Validated, txtBoxesPerTray.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.nLevels = Int(txtNLevels.Text)
        VRTM_SimVariables.nTrays = Int(txtNTrays.Text)
        VRTM_SimVariables.boxesPerTray = Int(txtBoxesPerTray.Text)
        txtStCap.Text = Trim(Str(VRTM_SimVariables.nLevels * VRTM_SimVariables.nTrays * VRTM_SimVariables.boxesPerTray))
    End Sub

    Private Sub Validated_Textbox_Evaporators(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtFanFlow.Validated, txtEvapSurf.Validated, txtGlobalHX.Validated, txtFanPower.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.fanFlowRate = Val(txtFanFlow.Text)
        VRTM_SimVariables.evapSurfArea = Val(txtEvapSurf.Text)
        VRTM_SimVariables.globalHX_Coeff = Val(txtGlobalHX.Text)
    End Sub

    Private Sub Validated_Textbox_Time_VRTM(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtSchVRTMBegin.Validated, txtSchVRTMEnd.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.IdleHourBeginVRTM = HourStringToDayFraction(txtSchVRTMBegin.Text)
        VRTM_SimVariables.IdleHourEndVRTM = HourStringToDayFraction(txtSchVRTMEnd.Text)
    End Sub

    Private Sub chkDaysVRTM(sender As Object, e As EventArgs) Handles chkMondayVRTM.CheckedChanged, chkTuesdayVRTM.CheckedChanged, chkWednesdayVRTM.CheckedChanged,
            chkThursdayVRTM.CheckedChanged, chkFridayVRTM.CheckedChanged, chkSaturdayVRTM.CheckedChanged, chkSundayVRTM.CheckedChanged
        'This will update the array of idle days in the VRTM
        If FormShown Then
            VRTM_SimVariables.IdleDaysVRTM = {chkMondayVRTM.Checked, chkTuesdayVRTM.Checked, chkWednesdayVRTM.Checked,
                        chkThursdayVRTM.Checked, chkFridayVRTM.Checked, chkSaturdayVRTM.Checked, chkSundayVRTM.Checked}
        End If
    End Sub
#End Region

#Region "Validations ====Tab Machine Room===="
    Private Sub Validate_Temperature(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtTCond.Validating, txtTevapSP.Validating
        'Validates several textboxes that have a numeric input
        If Not ((IsNumeric(sender.Text)) And Val(sender.text) >= -70 And Val(sender.text) <= 100 And (Val(txtTCond.Text) > Val(txtTevapSP.Text))) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A temperature between -70ºC and +100ºC must be provided and Tcond>Tevap.")
        End If
    End Sub

    Private Sub Validate_Hour_MR(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtIdleHourBeginMR.Validating, txtIdleHourEndsMR.Validating
        'Validates these textboxes that have a time input, and whether the times are consistent
        Dim HourFormat As New System.Text.RegularExpressions.Regex("([0-1][0-9]|2[0-3]):([0-5][0-9])")
        If (Not (HourFormat.IsMatch(sender.Text))) Or CompareHours(txtIdleHourBeginMR.Text, txtIdleHourEndsMR.Text, "LargerThan") Or CompareHours(txtIdleHourBeginMR.Text, txtIdleHourEndsMR.Text, "EqualTo") Then

            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A valid begin/end hour combination must be provided.")
        End If
    End Sub

    Private Sub Validated_Textbox_Temperatures(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtTCond.Validated, txtTevapSP.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.Tcond = Int(txtTCond.Text)
        VRTM_SimVariables.Tevap_Setpoint = Int(txtTevapSP.Text)
    End Sub

    Private Sub Validated_Textbox_Time_MR(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtIdleHourBeginMR.Validated, txtIdleHourEndsMR.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.IdleHourBeginMRoom = HourStringToDayFraction(txtIdleHourBeginMR.Text)
        VRTM_SimVariables.IdleHourEndMRoom = HourStringToDayFraction(txtIdleHourEndsMR.Text)
    End Sub

    Private Sub chkDaysMR(sender As Object, e As EventArgs) Handles chkMondayMR.CheckedChanged, chkTuesdayMR.CheckedChanged, chkWednesdayMR.CheckedChanged,
            chkThursdayMR.CheckedChanged, chkFridayMR.CheckedChanged, chkSaturdayMR.CheckedChanged, chkSundayMR.CheckedChanged
        'This will update the array of idle days in the MR
        If FormShown Then
            VRTM_SimVariables.IdleDaysMRoom = {chkMondayMR.Checked, chkTuesdayMR.Checked, chkWednesdayMR.Checked,
                chkThursdayMR.Checked, chkFridayMR.Checked, chkSaturdayMR.Checked, chkSundayMR.Checked}
        End If
    End Sub
#End Region

#Region "Validations ====Tab Production===="
    Private Sub Validate_SafetyFactor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtSafetyFactorVRTM.Validating
        'Validates the safety factor between 1.0 and 5.0
        If Not (IsNumeric(sender.Text) And Val(sender.text) >= 1 And Val(sender.text) <= 5) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "The safety factor must be between 1.0 and 5.0")
        End If
    End Sub

    Private Sub Validated_SafetyFactor(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtSafetyFactorVRTM.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.SafetyFactorVRTM = Val(txtSafetyFactorVRTM.Text)
        UpdateProductMixStats()
    End Sub

    Private Sub Checkboxes_Production() Handles _
            chkFirstTurn.CheckedChanged, chkSecondTurn.CheckedChanged
        If FormShown Then
            VRTM_SimVariables.FirstProductionTurnEnabled = chkFirstTurn.Checked
            VRTM_SimVariables.SecondProductionTurnEnabled = chkSecondTurn.Checked
        End If
    End Sub

    Private Sub Validate_Hour_Prod(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtFirstTurnBegins.Validating, txtFirstTurnEnds.Validating, txtSecondTurnBegins.Validating, txtSecondTurnEnds.Validating
        'Validates these textboxes that have a time input, and whether the times are consistent
        Dim HourFormat As New System.Text.RegularExpressions.Regex("([0-1][0-9]|2[0-3]):([0-5][0-9])")
        If (Not (HourFormat.IsMatch(sender.Text))) Or CompareHours(txtFirstTurnBegins.Text, txtFirstTurnEnds.Text, "LargerThan") Or
            CompareHours(txtFirstTurnBegins.Text, txtFirstTurnEnds.Text, "EqualTo") Or CompareHours(txtFirstTurnEnds.Text, txtSecondTurnBegins.Text, "LargerThan") _
            Or CompareHours(txtSecondTurnBegins.Text, txtSecondTurnEnds.Text, "LargerThan") Or CompareHours(txtSecondTurnBegins.Text, txtSecondTurnEnds.Text, "EqualTo") Then

            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A valid begin/end hour combination must be provided for both turns.")
        End If
    End Sub

    Private Sub Validated_Textbox_Time_Prod(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtFirstTurnBegins.Validated, txtFirstTurnEnds.Validated, txtSecondTurnBegins.Validated, txtSecondTurnEnds.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.FirstTurnBegin = HourStringToDayFraction(txtFirstTurnBegins.Text)
        VRTM_SimVariables.FirstTurnEnd = HourStringToDayFraction(txtFirstTurnEnds.Text)
        VRTM_SimVariables.SecondTurnBegin = HourStringToDayFraction(txtSecondTurnBegins.Text)
        VRTM_SimVariables.SecondTurnEnd = HourStringToDayFraction(txtSecondTurnEnds.Text)
    End Sub

    Private Sub chkDaysProd(sender As Object, e As EventArgs) Handles chkMondayProd.CheckedChanged, chkTuesdayProd.CheckedChanged, chkWednesdayProd.CheckedChanged,
            chkThursdayProd.CheckedChanged, chkFridayProd.CheckedChanged, chkSaturdayProd.CheckedChanged, chkSundayProd.CheckedChanged
        'This will update the array of idle days in the Prod
        If FormShown Then
            VRTM_SimVariables.ProductionDays = {chkMondayProd.Checked, chkTuesdayProd.Checked, chkWednesdayProd.Checked,
            chkThursdayProd.Checked, chkFridayProd.Checked, chkSaturdayProd.Checked, chkSundayProd.Checked}
        End If
    End Sub

#End Region

#Region "Validations ====Tab Demand===="
    Private Sub txtLevelChoosing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtLevelChoosing.SelectedIndexChanged
        VRTM_SimVariables.LevelChoosing = txtLevelChoosing.SelectedIndex
        Select Case txtLevelChoosing.SelectedIndex
            Case 0 'Production
                grpDemandProf.Enabled = False
                grpTunnelOrg.Enabled = True
                chkDelayDemand.Enabled = False
                txtDelayDemandTime.Enabled = False
            Case 1 'Demand
                grpDemandProf.Enabled = True
                grpTunnelOrg.Enabled = True
                chkDelayDemand.Enabled = True
                txtDelayDemandTime.Enabled = chkDelayDemand.Checked
            Case 2 'Rnd
                grpDemandProf.Enabled = False
                grpTunnelOrg.Enabled = True
                chkDelayDemand.Enabled = False
                txtDelayDemandTime.Enabled = False
        End Select

    End Sub

    Private Sub txtPickingOrderProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtPickingOrderProfile.SelectedIndexChanged
        VRTM_SimVariables.PickingOrders = txtPickingOrderProfile.SelectedIndex
        Select Case txtPickingOrderProfile.SelectedIndex
            Case 0 'Random bias
                chkRandomPickingBias.Enabled = True
                txtExternalDemandProfileFile.Enabled = False
            Case 1 'External File
                chkRandomPickingBias.Enabled = False
                txtExternalDemandProfileFile.Enabled = True

                Dim F As String
                OpenFileDialog1.Filter = "CSV Files (*.CSV)|*.csv"
                OpenFileDialog1.Title = "Select an external picking demand profile"
                OpenFileDialog1.FileName = ""
                OpenFileDialog1.CheckFileExists = True

                Try
                    OpenFileDialog1.ShowDialog()

                    F = OpenFileDialog1.FileName

                    If System.IO.File.Exists(F) Then
                        txtExternalDemandProfileFile.Text = F
                    End If
                Catch ex As Exception
                End Try

        End Select
    End Sub

    Private Sub txtExternalDemandProfileFile_MouseClick(sender As Object, e As MouseEventArgs) Handles txtExternalDemandProfileFile.MouseClick
        'Tries to open a new file
        Dim F As String
        OpenFileDialog1.Filter = "CSV Files (*.CSV)|*.csv"
        OpenFileDialog1.Title = "Select an external picking demand profile"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.CheckFileExists = True

        Try
            OpenFileDialog1.ShowDialog()

            F = OpenFileDialog1.FileName

            If System.IO.File.Exists(F) Then
                txtExternalDemandProfileFile.Text = F
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkDelayDemand_CheckedChanged(sender As Object, e As EventArgs) Handles chkDelayDemand.CheckedChanged
        VRTM_SimVariables.DelayDemand = chkDelayDemand.Checked
        txtDelayDemandTime.Enabled = chkDelayDemand.Checked
    End Sub

    Private Sub chkIdleHoursReshelving_CheckedChanged(sender As Object, e As EventArgs) Handles chkIdleHoursReshelving.CheckedChanged
        VRTM_SimVariables.EnableIdleReshelving = chkIdleHoursReshelving.Checked
        txtMinimumReshelvingWindow.Enabled = chkIdleHoursReshelving.Checked
    End Sub

    Private Sub chkImprovedWeekendStrat_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprovedWeekendStrat.CheckedChanged
        VRTM_SimVariables.EnableImprovedWeekendStrat = chkImprovedWeekendStrat.Checked
    End Sub

    Private Sub chkRandomPickingBias_CheckedChanged(sender As Object, e As EventArgs) Handles chkRandomPickingBias.CheckedChanged
        VRTM_SimVariables.RandomBias = chkRandomPickingBias.Checked
    End Sub

    Private Sub Validate_DemandTab(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtDelayDemandTime.Validating, txtMinimumReshelvingWindow.Validating
        If (Not (IsNumeric(sender.Text) And Val(sender.text) > 0)) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)
            ErrorProvider1.SetError(sender, "The value must be greater than zero.")
        End If
    End Sub

    Private Sub Validated_DemandTab(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtDelayDemandTime.Validated, txtMinimumReshelvingWindow.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.DelayDemandTime = Val(txtDelayDemandTime.Text)
        VRTM_SimVariables.MinimumReshelvingWindow = Val(txtMinimumReshelvingWindow.Text)
    End Sub

#End Region

#Region "Validations ====Tab Simulation Parameters===="
    Private Sub Validate_SimulationTab(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtTotalSimTime.Validating, txtMinimumSimDT.Validating, txtReturnLevel.Validating, txtLoadLevel.Validating, txtUnloadLevel.Validating,
        txtElevatorAccel.Validating, txtElevatorSpeed.Validating, txtTrayTransferTime.Validating, txtBoxUnloadingTime.Validating, txtBoxLoadingTime.Validating,
        txtUnloaderRetractionTime.Validating
        If (Not (IsNumeric(sender.Text) And Val(sender.text) > 0)) Or
            ((sender.Name = txtReturnLevel.Name Or sender.Name = txtLoadLevel.Name Or sender.Name = txtUnloadLevel.Name) AndAlso (Int(Val(sender.text)) > VRTM_SimVariables.nLevels Or Int(Val(sender.text)) < 0)) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            If (sender.Name = txtReturnLevel.Name Or sender.Name = txtLoadLevel.Name Or sender.Name = txtUnloadLevel.Name) Then
                ErrorProvider1.SetError(sender, "The load/unload/return level must be between 1 and the last level number")
            Else
                ErrorProvider1.SetError(sender, "The simulation times must be larger than 0")
            End If
        End If
    End Sub

    Private Sub Validated_SimulationTab(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtTotalSimTime.Validated, txtMinimumSimDT.Validated, txtReturnLevel.Validated, txtLoadLevel.Validated, txtUnloadLevel.Validated,
        txtElevatorAccel.Validated, txtElevatorSpeed.Validated, txtTrayTransferTime.Validated, txtBoxUnloadingTime.Validated, txtBoxLoadingTime.Validated,
        txtUnloaderRetractionTime.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.TotalSimTime = Val(txtTotalSimTime.Text) * 24 * 3600
        VRTM_SimVariables.MinimumSimDt = Val(txtMinimumSimDT.Text)
        VRTM_SimVariables.ElevSpeed = Val(txtElevatorSpeed.Text)
        VRTM_SimVariables.ElevAccel = Val(txtElevatorAccel.Text)
        VRTM_SimVariables.LevelCenterDist = Val(txtLevelCenterDist.Text)
        VRTM_SimVariables.LoadLevel = Int(Val(txtLoadLevel.Text))
        VRTM_SimVariables.UnloadLevel = Int(Val(txtUnloadLevel.Text))
        VRTM_SimVariables.ReturnLevel = Int(Val(txtReturnLevel.Text))
        VRTM_SimVariables.TrayTransferTime = Val(txtTrayTransferTime.Text)
        VRTM_SimVariables.BoxLoadingTime = Val(txtBoxLoadingTime.Text)
        VRTM_SimVariables.BoxUnloadingTime = Val(txtBoxUnloadingTime.Text)
        VRTM_SimVariables.UnloaderRetractionTime = Val(txtUnloaderRetractionTime.Text)

        VRTM_SimVariables.AssumedDTForPreviews = Val(txtAcceptedDt.Text)
    End Sub
#End Region

#Region "Other Functions"
    Private Function HourStringToDayFraction(Hour As String) As Double
        'This function converts an hour string in the format 24:00 to a day fraction (0 to 1).
        'i.e.: 18:00 becomes 0.75

        Dim H As Integer
        Dim M As Integer

        H = Int(Val(Mid(Hour, 1, 2)))
        M = Int(Val(Mid(Hour, 4, 2)))

        HourStringToDayFraction = (H / 24) + (M / (60 * 24))

        If HourStringToDayFraction < 0 Then HourStringToDayFraction = 0 'Makes negative hours become zero
        If HourStringToDayFraction >= 1 Then HourStringToDayFraction = 0 'Makes 24:00 become 0:00 (loops around)
    End Function

    Private Function DayFractionToHourString(DayFraction As Double) As String
        'This function converts a day fraction (0 to 1) to an hour string in the format 24:00 .
        'i.e.: 0.75 becomes 18:00

        Dim H As String
        Dim M As String

        H = Trim(Str(Int(DayFraction * 24)))
        If H.Length < 2 Then H = "0" & H
        If H.Length > 2 Then H = "00"

        M = Trim(Str((DayFraction * 24 * 60) Mod 60))
        If M.Length < 2 Then M = "0" & M
        If M.Length > 2 Then M = "00"

        DayFractionToHourString = H & ":" & M
    End Function

    Private Function CompareHours(H1 As String, H2 As String, Comparator As String) As Boolean
        'Compares H1 and H2 and returns

        Dim DayFraction1, DayFraction2 As Double
        DayFraction1 = HourStringToDayFraction(H1)
        DayFraction2 = HourStringToDayFraction(H2)

        Select Case Comparator
            Case "LargerThan"
                CompareHours = (DayFraction1 > DayFraction2)
                If DayFraction2 = 0 And DayFraction1 <> 0 Then CompareHours = False 'Handles the case of midnight meaning Dayfraction=1
            Case "LessThan"
                CompareHours = (DayFraction1 < DayFraction2)
            Case "EqualTo"
                CompareHours = (DayFraction1 = DayFraction2)
            Case Else
                CompareHours = False
        End Select

    End Function

    Private Sub UpdateProductMixStats()
        'Updates the fields that correspond to the overall statistics of the product mix
        Dim TotalBoxFlowIn, TotalMassFlowIn, TotalInstHeatLoad As Double

        TotalBoxFlowIn = 0
        TotalMassFlowIn = 0
        TotalInstHeatLoad = 0
        If Not IsNothing(VRTM_SimVariables.ProductMix) Then
            For Each Prod As ProductData In VRTM_SimVariables.ProductMix
                TotalBoxFlowIn = TotalBoxFlowIn + Prod.AvgFlowRate
                TotalMassFlowIn = TotalMassFlowIn + Prod.AvgFlowRate * Prod.BoxWeight
                TotalInstHeatLoad = TotalInstHeatLoad + Prod.DeltaHSimulated * (TotalMassFlowIn / 3600)
            Next
        End If

        Dim ProductiveDays As Integer = 0
        Dim MRDays As Integer = 0
        Dim VRTMDays As Integer = 0
        For i As Integer = 0 To 6
            ProductiveDays -= VRTM_SimVariables.ProductionDays(i)
            MRDays -= VRTM_SimVariables.IdleDaysMRoom(i)
            VRTMDays -= VRTM_SimVariables.IdleDaysVRTM(i)
        Next

        Dim ProductiveHours As Double = 24 * (Delta_Day(VRTM_SimVariables.SecondTurnEnd, VRTM_SimVariables.SecondTurnBegin) +
                                        Delta_Day(VRTM_SimVariables.FirstTurnEnd, VRTM_SimVariables.FirstTurnBegin))
        Dim MRHours As Double = 24 * (1 - Delta_Day(VRTM_SimVariables.IdleHourEndMRoom, VRTM_SimVariables.IdleHourBeginMRoom))
        Dim VRTMHours As Double = 24 * (1 - Delta_Day(VRTM_SimVariables.IdleHourEndVRTM, VRTM_SimVariables.IdleHourBeginVRTM))

        Dim DailyAvgHL As Double
        Dim WeeklyAvgHL As Double


        DailyAvgHL = ((ProductiveHours / MRHours) * TotalInstHeatLoad) / 1000 'Averages the instant HL throughout the day
        DailyAvgHL += (VRTMHours / MRHours) * Val(txtFanPower.Text) 'Adds the fan power averaged through the day in the same fashion
        DailyAvgHL += VRTM_SimVariables.FixedHeatLoadData.FixedHL 'Adds the fixed HL component
        DailyAvgHL *= VRTM_SimVariables.SafetyFactorVRTM 'Adds the safety factor


        WeeklyAvgHL = (ProductiveHours * ProductiveDays) / (168 - (24 - MRHours) * MRDays) ' Gets the ratio between inlet HL and MR HL
        WeeklyAvgHL *= TotalInstHeatLoad / 1000 'Multiplies that by the heat load of the product
        WeeklyAvgHL += ((168 - (24 - VRTMHours) * VRTMDays) / (168 - (24 - MRHours) * MRDays)) * Val(txtFanPower.Text) 'Adds the fan HL
        WeeklyAvgHL += VRTM_SimVariables.FixedHeatLoadData.FixedHL 'Adds the fixed HL component
        WeeklyAvgHL *= VRTM_SimVariables.SafetyFactorVRTM 'Adds the safety factor



        txtAvgBoxflowIn.Text = Trim(Str(TotalBoxFlowIn))
        txtAvgMassFlowIn.Text = Trim(Str(TotalMassFlowIn))
        txtAvgBoxMass.Text = Trim(Str(Round(TotalMassFlowIn / TotalBoxFlowIn, 2)))
        txtAvgHeatLoad.Text = Trim(Str(Round(DailyAvgHL, 2)))
        txtWeeklyHeatLoad.Text = Trim(Str(Round(WeeklyAvgHL, 2)))

    End Sub

    Private Sub UpdateDisplayVariableLabel()
        'Updates the display variable to ensure it's showing the right info
        Dim StringDisplayVariable As String = "Displaying Value: "
        Select Case My.Settings.DisplayParameter
            Case 0 'Tray Index
                StringDisplayVariable = StringDisplayVariable & "Tray Index, "
            Case 1 'Conveyor Index
                StringDisplayVariable = StringDisplayVariable & "Conveyor Index, "
            Case 2 'Retention Time
                StringDisplayVariable = StringDisplayVariable & "Retention Time [h], "
            Case 3 'Center T
                StringDisplayVariable = StringDisplayVariable & "Center Temperature [ºC], "
            Case 4 'Surf T
                StringDisplayVariable = StringDisplayVariable & "Surface Temperature [ºC], "
            Case 5 'Power
                StringDisplayVariable = StringDisplayVariable & "Instantaneous Power [W], "
        End Select

        StringDisplayVariable = StringDisplayVariable & "Background Color: "
        Select Case My.Settings.DisplayParameterForeColor
            Case 0 'Tray Index
                StringDisplayVariable = StringDisplayVariable & "Tray Index, "
            Case 1 'Conveyor Index
                StringDisplayVariable = StringDisplayVariable & "Conveyor Index, "
            Case 2 'Retention Time
                StringDisplayVariable = StringDisplayVariable & "Retention Time, "
            Case 3 'Center T
                StringDisplayVariable = StringDisplayVariable & "Center Temperature, "
            Case 4 'Surf T
                StringDisplayVariable = StringDisplayVariable & "Surface Temperature, "
            Case 5 'Power
                StringDisplayVariable = StringDisplayVariable & "Instantaneous Power, "
            Case 6 'Bool Frozen
                StringDisplayVariable = StringDisplayVariable & "Frozen/Not Frozen, "
            Case 7 'Always use minimum
                StringDisplayVariable = StringDisplayVariable & "Fixed Color, "
        End Select

        StringDisplayVariable = StringDisplayVariable & "Text Color: "
        Select Case My.Settings.DisplayParameterBackColor
            Case 0 'Tray Index
                StringDisplayVariable = StringDisplayVariable & "Tray Index"
            Case 1 'Conveyor Index
                StringDisplayVariable = StringDisplayVariable & "Conveyor Index"
            Case 2 'Retention Time
                StringDisplayVariable = StringDisplayVariable & "Retention Time"
            Case 3 'Center T
                StringDisplayVariable = StringDisplayVariable & "Center Temperature"
            Case 4 'Surf T
                StringDisplayVariable = StringDisplayVariable & "Surface Temperature"
            Case 5 'Power
                StringDisplayVariable = StringDisplayVariable & "Instantaneous Power"
            Case 6 'Bool Frozen
                StringDisplayVariable = StringDisplayVariable & "Frozen/Not Frozen"
            Case 7 'Always use minimum
                StringDisplayVariable = StringDisplayVariable & "Fixed Color"
        End Select
        lblDisplayVariable.Text = StringDisplayVariable
    End Sub

    Private Function Delta_Day(ByVal Day1 As Double, ByVal Day2 As Double) As Double
        'Calculates the difference in days between one time and the other (Day1 and Day2 are expected 0-1)
        If Day1 = 0 Then Day1 = 1
        If Day2 = 0 Then Day2 = 1
        Delta_Day = Day1 - Day2
    End Function

    Private Sub RefreshTable(Data(,))
        If (VRTMTable.Rows.Count <> (UBound(Data, 2) + 1)) Or (VRTMTable.Columns.Count <> (UBound(Data, 1) + 1)) Then
            Exit Sub
        End If

        For i = 0 To UBound(Data, 1)
            For j = 0 To UBound(Data, 2)
                VRTMTable.Item(i, j).Value = Data(i, j)
            Next
        Next
    End Sub
#End Region

#Region "Simulation playback"
    Private Sub UpdateDGVPlayback(sender As Object, e As ScrollEventArgs) Handles hsSimPosition.Scroll
        If Simulation_Results.SimulationComplete Then
            'This triggers the update of the DGV. ALL UPDATE CALLS must change this hs position.
            lblCurrentPos.Text = GetCurrentTimeString(hsSimPosition.Value)

            'Gets the current time index
            Dim thisT_index As Long
            thisT_index = Array.BinarySearch(Of Double)(Simulation_Results.VRTMTimePositions, hsSimPosition.Value)
            If thisT_index < 0 Then
                thisT_index = (Not thisT_index) - 1
            End If

            'Highlights the row header of the current level
            If My.Settings.Display_boolHighlight Then
                For J As Integer = 0 To VRTM_SimVariables.nLevels - 1
                    VRTMTable.Rows(J).HeaderCell.Style.BackColor = My.Settings.Display_TableHeaderBColor
                Next
                VRTMTable.Rows(Simulation_Results.TrayEntryLevels(thisT_index)).HeaderCell.Style.BackColor = My.Settings.Display_HighlightColor
            End If

            'Highlights all the other cells according to the rules
            For I As Integer = 0 To VRTM_SimVariables.nTrays - 1
                For J As Integer = 0 To VRTM_SimVariables.nLevels - 1
                    UpdateDGVInnerCell(thisT_index, I, J)
                Next
            Next

            'Updates the Elevator Wells.
            For J As Integer = 0 To VRTM_SimVariables.nLevels - 1
                'Clears the elevator well
                VRTMTable.Item(0, J).ToolTipText = ""
                VRTMTable.Item(0, J).Value = ""
                VRTMTable.Item(VRTM_SimVariables.nTrays + 1, J).ToolTipText = ""
                VRTMTable.Item(VRTM_SimVariables.nTrays + 1, J).Value = ""
            Next
            'Updates the cells that have content
            UpdateElevatorWellCells(thisT_index)
            UpdateDisplayVariableLabel()
        Else
            lblDisplayVariable.Text = "Simulation Not Ready"
        End If


    End Sub

    Private Sub UpdateDGVInnerCell(T As Long, Tray As Integer, Level As Integer)
        'This routine updates a given cell in the table and all its properties

        'Computes the values of the variables for this cell
        Dim TrayInfo As TrayData
        Dim Row, Column As Integer

        TrayInfo = Simulation_Results.VRTMTrayData(T, Tray, Level)
        Column = Tray + 1
        Row = Level

        UpdateDGVCell(T, Column, Row, TrayInfo)

    End Sub

    Private Sub UpdateElevatorWellCells(T As Long)
        'Updates the elevator well cells
        Dim Column, Row As Integer

        If Simulation_Results.EmptyElevatorB(T) Then
            'Fills up elevator A
            Column = 0
        Else
            'Fills up elevator B
            Column = VRTM_SimVariables.nTrays + 1
        End If

        Row = Simulation_Results.TrayEntryLevels(T)


        Dim Tray As TrayData
        Dim T_Temp As Long

        T_Temp = T
        If T = 0 Then T_Temp = 1

        Tray = Simulation_Results.Elevator(T_Temp)

        UpdateDGVCell(T, Column, Row, Tray)
    End Sub

    Private Sub UpdateDGVCell(T As Long, Column As Integer, Row As Integer, TrayInfo As TrayData)
        'This routine updates a given cell in the table and all its properties

        With VRTMTable.Item(Column, Row)
            If TrayInfo.TrayIndex = 0 Or T <= 0 Or TrayInfo.ConveyorIndex = -1 Then
                'Doesn't apply colors if there is an empty tray here
                .Value = " "
                .Style.BackColor = My.Settings.Display_TableBackColor
                .ToolTipText = ""
            Else
                'There is indeed a tray here, computes the colors
                Dim RetTime As Double
                Dim CenterTemp As Double
                Dim SurfTemp As Double
                Dim Power As Double
                Dim Frozen As Boolean
                RetTime = (hsSimPosition.Value - Simulation_Results.TrayEntryTimes(TrayInfo.TrayIndex)) / 3600
                Frozen = RetTime >= VRTM_SimVariables.InletConveyors(TrayInfo.ConveyorIndex).MinRetTime

                Select Case My.Settings.DisplayParameter
                    Case 0 'Tray Index
                        .Value = TrayInfo.TrayIndex
                    Case 1 'Conveyor Index
                        .Value = TrayInfo.ConveyorIndex
                    Case 2 'Retention Time
                        .Value = Int(RetTime * 10) / 10
                    Case 3 'Center T
                    Case 4 'Surf T
                    Case 5 'Power
                End Select

                Dim ColorPos As Double
                Select Case My.Settings.DisplayParameterForeColor
                    Case 0 'Tray Index
                        ColorPos = TrayInfo.TrayIndex / UBound(Simulation_Results.TrayEntryTimes)
                        .Style.ForeColor = Interpolate_Color(ColorPos, My.Settings.Display_MinColor_ForeColor, My.Settings.Display_MaxColor_ForeColor)
                    Case 1 'Conveyor Index
                        ColorPos = TrayInfo.ConveyorIndex / UBound(VRTM_SimVariables.InletConveyors)
                        .Style.ForeColor = Interpolate_Color(ColorPos, My.Settings.Display_MinColor_ForeColor, My.Settings.Display_MaxColor_ForeColor)
                    Case 2 'Retention Time
                        ColorPos = RetTime / VRTM_SimVariables.InletConveyors(TrayInfo.ConveyorIndex).MinRetTime
                        .Style.ForeColor = Interpolate_Color(ColorPos, My.Settings.Display_MinColor_ForeColor, My.Settings.Display_MaxColor_ForeColor)
                    Case 3 'Center T
                    Case 4 'Surf T
                    Case 5 'Power
                    Case 6 'Bool Frozen
                        If Frozen Then
                            .Style.ForeColor = My.Settings.Display_MinColor_ForeColor
                        Else
                            .Style.ForeColor = My.Settings.Display_MaxColor_ForeColor
                        End If
                    Case 7 'Always use minimum
                        .Style.ForeColor = My.Settings.Display_MinColor_ForeColor
                End Select

                Select Case My.Settings.DisplayParameterBackColor
                    Case 0 'Tray Index
                        ColorPos = TrayInfo.TrayIndex / UBound(Simulation_Results.TrayEntryTimes)
                        .Style.BackColor = Interpolate_Color(ColorPos, My.Settings.Display_MinColor_BackColor, My.Settings.Display_MaxColor_BackColor)
                    Case 1 'Conveyor Index
                        ColorPos = TrayInfo.ConveyorIndex / UBound(VRTM_SimVariables.InletConveyors)
                        .Style.BackColor = Interpolate_Color(ColorPos, My.Settings.Display_MinColor_BackColor, My.Settings.Display_MaxColor_BackColor)
                    Case 2 'Retention Time
                        ColorPos = RetTime / VRTM_SimVariables.InletConveyors(TrayInfo.ConveyorIndex).MinRetTime
                        .Style.BackColor = Interpolate_Color(ColorPos, My.Settings.Display_MinColor_BackColor, My.Settings.Display_MaxColor_BackColor)
                    Case 3 'Center T
                    Case 4 'Surf T
                    Case 5 'Power
                    Case 6 'Bool Frozen
                        If Frozen Then
                            .Style.BackColor = My.Settings.Display_MinColor_BackColor
                        Else
                            .Style.BackColor = My.Settings.Display_MaxColor_BackColor
                        End If
                    Case 7 'Always use minimum
                        .Style.BackColor = My.Settings.Display_MinColor_BackColor
                End Select

                'Sets a tooltip
                .ToolTipText = "Tray Index: " & Trim(Str(TrayInfo.TrayIndex)) & vbCrLf &
                    "Conveyor: " & VRTM_SimVariables.InletConveyors(TrayInfo.ConveyorIndex).ConveyorTag & "(Idx " & Trim(Str(TrayInfo.ConveyorIndex)) & ")" & vbCrLf &
                    "Current Ret. Time: " & Trim(Str(Int(RetTime * 10) / 10)) & " h/" & Trim(Str(VRTM_SimVariables.InletConveyors(TrayInfo.ConveyorIndex).MinRetTime)) & " h" & vbCrLf &
                    "Center Temperature: " & Trim(Str(0)) & " ºC" & vbCrLf &
                    "Surface Temperature: " & Trim(Str(0)) & " ºC" & vbCrLf &
                    "Instantaneous Power Exchanged: " & Trim(Str(0)) & " W" & vbCrLf & vbCrLf & "Boxes in This Tray:"

                'Adds the box/product list [index of product, quantity]
                For Each i As KeyValuePair(Of Long, Long) In TrayInfo.ProductIndices
                    .ToolTipText = .ToolTipText & vbCrLf & Trim(Str(i.Value)) & "x " & VRTM_SimVariables.ProductMix(i.Key).ProdName
                Next
            End If


        End With

    End Sub


    Private Sub VRTMTable_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles VRTMTable.CellPainting
        'Handles the elevator well cell painting and border removal
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 0 Then
                If Not IsNothing(e.Value) AndAlso e.Value.ToString = "" Then
                    e.CellStyle.BackColor = My.Settings.Display_ElevatorWellColor
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                Else
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single
                End If
            ElseIf e.ColumnIndex = VRTM_SimVariables.nTrays + 1 Then
                If Not IsNothing(e.Value) AndAlso e.Value.ToString = "" Then
                    e.CellStyle.BackColor = My.Settings.Display_ElevatorWellColor
                    e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                Else
                    e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single
                End If
            End If
            If e.RowIndex = VRTM_SimVariables.nLevels - 1 Then
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single
            End If
        End If

    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click, PlayToolStripMenuItem.Click
        tmrPlayback.Enabled = True
    End Sub

    Private Sub btnStop_CheckedChanged(sender As Object, e As EventArgs) Handles btnStop.Click, StopToolStripMenuItem.Click
        tmrPlayback.Enabled = False
    End Sub

    Private Sub btnIncreaseSpeed_Click(sender As Object, e As EventArgs) Handles btnIncreaseSpeed.Click, IncreaseSpeedToolStripMenuItem.Click
        'Increases the counter
        If currentPlaybackSpeedIndex < (playbackDefaultSpeeds.Count - 1) Then
            currentPlaybackSpeedIndex += 1
            playbackSpeed = (playbackTimerPeriod / 1000) * playbackDefaultSpeeds(currentPlaybackSpeedIndex)
            lblTimeWarp.Text = playbackDefaultSpeedNames(currentPlaybackSpeedIndex)
        End If
    End Sub

    Private Sub btnReduceSpeed_Click(sender As Object, e As EventArgs) Handles btnReduceSpeed.Click, ReduceSpeedToolStripMenuItem.Click
        'Decreases the counter
        If currentPlaybackSpeedIndex > 0 Then
            currentPlaybackSpeedIndex -= 1
            playbackSpeed = (playbackTimerPeriod / 1000) * playbackDefaultSpeeds(currentPlaybackSpeedIndex)
            lblTimeWarp.Text = playbackDefaultSpeedNames(currentPlaybackSpeedIndex)
        End If
    End Sub

    Private Sub tmrPlayback_Tick(sender As Object, e As EventArgs) Handles tmrPlayback.Tick
        'The playback timer will just increase the scrollbar and its change event will deal with the rest
        If Simulation_Results.SimulationComplete Then
            'Tries to set the new value to the scrollbar.
            Dim newValue As Integer = hsSimPosition.Value + Int(playbackSpeed)
            If newValue < hsSimPosition.Maximum And newValue > hsSimPosition.Minimum Then
                hsSimPosition.Value = newValue
                UpdateDGVPlayback(Nothing, Nothing)
            End If
        End If
    End Sub

#End Region

#Region "File Menu"
    Private Sub SaveSimulationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSimulationToolStripMenuItem.Click
        Dim F As String
        SaveFileDialog1.Filter = "VRTM Config Files (*.vcfg)|*.vcfg"
        SaveFileDialog1.Title = "Save the Simulation Setup"
        SaveFileDialog1.ShowDialog()

        F = SaveFileDialog1.FileName

        Try
            SaveTRVMVariables(VRTM_SimVariables, F)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub OpenSimulationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSimulationToolStripMenuItem.Click

        Dim F As String
        OpenFileDialog1.Filter = "VRTM Config Files (*.vcfg)|*.vcfg"
        OpenFileDialog1.Title = "Open a Simulation Setup"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.ShowDialog()

        F = OpenFileDialog1.FileName

        If System.IO.File.Exists(F) Then
            Try
                OpenTRVMVariables(F)
            Catch ex As Exception

            End Try

            'Zeroes the system and clears the results
            MainWindow_Load(Nothing, Nothing)
            VRTMTable.Columns.Clear()
            Simulation_Results = New SimulationData
        End If


    End Sub



#End Region


End Class