Imports System.ComponentModel

Public Class MainWindow
#Region "Declares and Private Variables"
    Dim PrevMidPanelSize As System.Drawing.Size
    Dim FormShown As Boolean = False
#End Region

#Region "Initialization"
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initializes all the fields according to the new, blank VRTM
        txtNTrays.Text = Trim(Str(VRTM_SimVariables.nTrays))
        txtNLevels.Text = Trim(Str(VRTM_SimVariables.nLevels))
        txtBoxesPerTray.Text = Trim(Str(VRTM_SimVariables.boxesPerTray))
        txtStCap.Text = Trim(Str(VRTM_SimVariables.nTrays * VRTM_SimVariables.nLevels * VRTM_SimVariables.boxesPerTray))

        txtFanFlow.Text = Trim(Str(VRTM_SimVariables.fanFlowRate))
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

        txtTotalSimTime.Text = Trim(Str(VRTM_SimVariables.TotalSimTime / (3600 * 24)))
        txtMinimumSimDT.Text = Trim(Str(VRTM_SimVariables.MinimumSimDt))
        txtAcceptedDt.Text = Trim(Str(VRTM_SimVariables.AssumedDTForPreviews))

        'Puts in public memory the food properties model table (many products available from settings)
        LoadFoodPropertiesCSVIntoMemory()
        Try
            VRTM_SimVariables.ProductMix(0).FoodThermalPropertiesModel.FoodModelUsed = FoodPropertiesList(18)
        Catch ex As Exception
            VRTM_SimVariables.ProductMix(0).FoodThermalPropertiesModel.FoodModelUsed = FoodPropertiesList(0)
        End Try
    End Sub

    Private Sub MainWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'After shown
        PrevMidPanelSize = MidPanel.Size
        FormShown = True
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Init_DGV(RowNumber As Integer, ColNumber As Integer)
        'Initializes VRTM table
        Try
            Dim i As Integer

            FormatTable()
            VRTMTable.Rows.Clear()
            VRTMTable.Columns.Clear()

            For i = 1 To ColNumber
                VRTMTable.Columns.Add(Str(i), Str(i))
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
    End Sub
#End Region

#Region "Validations ====Tab VRTM Params===="
    Private Sub Validate_Positive(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtNLevels.Validating, txtNTrays.Validating, txtBoxesPerTray.Validating, txtFanFlow.Validating, txtEvapSurf.Validating, txtGlobalHX.Validating
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
    End Sub

    Private Sub Validated_Textbox_Evaporators(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtFanFlow.Validated, txtEvapSurf.Validated, txtGlobalHX.Validated
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

#End Region

#Region "Validations ====Tab Simulation Parameters===="
    Private Sub Validate_SimulationTab(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtTotalSimTime.Validating, txtMinimumSimDT.Validating
        'Validates the safety factor between 1.0 and 5.0
        If Not (IsNumeric(sender.Text) And Val(sender.text) > 0) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "The simulation times must be larger than 0")
        End If
    End Sub

    Private Sub Validated_SimulationTab(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtTotalSimTime.Validated, txtMinimumSimDT.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.TotalSimTime = Val(txtTotalSimTime.Text) * 24 * 3600
        VRTM_SimVariables.MinimumSimDt = Val(txtMinimumSimDT.Text)

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
        Dim TotalBoxFlowIn, TotalMassFlowIn As Double

        TotalBoxFlowIn = 0
        TotalMassFlowIn = 0
        If Not IsNothing(VRTM_SimVariables.ProductMix) Then
            For Each Prod As ProductData In VRTM_SimVariables.ProductMix
                TotalBoxFlowIn = TotalBoxFlowIn + Prod.AvgFlowRate
                TotalMassFlowIn = TotalMassFlowIn + Prod.AvgFlowRate * Prod.BoxWeight
            Next
        End If

        txtAvgBoxflowIn.Text = Trim(Str(TotalBoxFlowIn))
        txtAvgMassFlowIn.Text = Trim(Str(TotalMassFlowIn))
        txtAvgBoxMass.Text = Trim(Str(TotalMassFlowIn / TotalBoxFlowIn))

        '----Insert code to update average heat load here----

    End Sub

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

End Class