Public Class A_Star_DebugWindow
    Public OriginalState As FringeItem
    Public BestGenerations As New List(Of FringeItem)
    Public BestFitnesses As New List(Of Double)


    Private Sub A_Star_DebugWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loads the columns
        Dim NColumns As Integer = UBound(OriginalState.VRTMStateConv, 1) + 1
        Dim C As Integer

        dgvTableView.AllowUserToAddRows = False
        dgvTableView.Columns.Clear()
        For I As Integer = 1 To NColumns + 2
            C = dgvTableView.Columns.Add(Str(I), "")
            dgvTableView.Columns(C).Width = 50
        Next

        If BestGenerations.Count > 0 Then
            FillTable(BestGenerations.Last, True)
        Else
            FillTable(OriginalState, True)
        End If

        GenUpDn.Maximum = BestGenerations.Count
        GenUpDn.Value = BestGenerations.Count



        'Initializes the generation evolution chart
        InitializeGraph()

        If BestGenerations.Count > 1 Then
            Dim G() As Double
            Dim F1() As Double
            Dim F2() As Double
            ReDim G(BestGenerations.Count - 1)
            ReDim F1(BestGenerations.Count - 1)
            ReDim F2(BestGenerations.Count - 1)

            G(0) = 0
            F1(0) = OriginalState.Current_Utility_U * 100
            For I As Long = 1 To BestGenerations.Count - 1
                G(I) = I
                F1(I) = BestGenerations(I - 1).Current_Reward_R * 100
                F2(I) = 0 'BestGenerations(I - 1).Current_Reward_R*100
            Next

            UpdateGraph("A", G, "Generation", F1, F2)
        End If


    End Sub

    Private Sub A_Star_DebugWindow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SplitContainer1.SplitterDistance = 420
    End Sub

    Private Sub dgvTableView_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvTableView.CellPainting
        If e.RowIndex > -1 Then
            If e.ColumnIndex > -1 Then
                Dim V As Double = Val(e.Value)
                If V > 1000 Then V = V - 1000

                If V > 0 Then
                    Try
                        e.CellStyle.BackColor = RandomColorSet(V - 1)
                    Catch ex As Exception

                    End Try
                End If

            End If
        End If
    End Sub

    Private Sub GenUpDn_ValueChanged(sender As Object, e As EventArgs) Handles GenUpDn.ValueChanged
        'Updates the table
        If GenUpDn.Value = 0 Then
            FillTable(OriginalState, True)
            txtMovements.Text = "0"
            txtLevelsTraversed.Text = "0"
            txtTimeTaken.Text = "0"
            txtFitnessValue.Text = "-"
            txtAccessFraction.Text = "-"
        Else
            Dim CurrentGen As FringeItem = BestGenerations(Int(GenUpDn.Value - 1))
            FillTable(CurrentGen, True)
            txtMovements.Text = Str(CurrentGen.PlanOfActions.Count)
            txtLevelsTraversed.Text = Str(CurrentGen.PrevCost_G)
            txtTimeTaken.Text = Str(Round(CurrentGen.PrevCost_G * (VRTM_SimVariables.LevelCenterDist / 1000) / (VRTM_SimVariables.ElevSpeed * 60), 1))
            txtFitnessValue.Text = Str(CurrentGen.Current_Utility_U)
            txtAccessFraction.Text = Str(Round(CurrentGen.Current_Reward_R * 100, 1))
        End If
    End Sub

    Private Sub FillTable(Content As FringeItem, clear As Boolean)

        dgvTableView.SuspendLayout()

        If clear Then dgvTableView.Rows.Clear()
        Dim NRow As Integer

        For I As Integer = 0 To UBound(OriginalState.VRTMStateConv, 2)
            If clear Then NRow = dgvTableView.Rows.Add()
            For J As Integer = 0 To UBound(OriginalState.VRTMStateConv, 1)
                dgvTableView.Rows(NRow).Cells(J + 1).Value = Content.VRTMStateConv(J, I)
            Next
        Next
        dgvTableView.ResumeLayout()
    End Sub





#Region "Chart update"
    Private Sub InitializeGraph()
        'Initializes the graph formatting (because the default formatting is awful!!)
        Dim LightGrayColor, DarkGrayColor As Color
        LightGrayColor = Color.FromArgb(230, 230, 230)
        DarkGrayColor = Color.FromArgb(100, 100, 100)

        With AccessFractionChart
            .ChartAreas(0).AxisY.Title = "Access Fraction [%]"

            .ChartAreas(0).AxisX.LineColor = DarkGrayColor
            .ChartAreas(0).AxisX.MajorGrid.LineColor = LightGrayColor
            .ChartAreas(0).AxisX.MinorGrid.LineColor = LightGrayColor
            .ChartAreas(0).AxisX.MajorTickMark.LineColor = DarkGrayColor
            .ChartAreas(0).AxisX.MinorTickMark.LineColor = DarkGrayColor
            .ChartAreas(0).AxisY.LineColor = DarkGrayColor
            .ChartAreas(0).AxisY.MajorGrid.LineColor = LightGrayColor
            .ChartAreas(0).AxisY.MinorGrid.LineColor = LightGrayColor
            .ChartAreas(0).AxisY.MajorTickMark.LineColor = DarkGrayColor
            .ChartAreas(0).AxisY.MinorTickMark.LineColor = DarkGrayColor

            .ChartAreas(0).AxisX.LabelStyle.Font = New Font(.ChartAreas(0).AxisX.LabelStyle.Font.FontFamily, 8)
            .ChartAreas(0).AxisY.LabelStyle.Font = New Font(.ChartAreas(0).AxisY.LabelStyle.Font.FontFamily, 8)
            .ChartAreas(0).AxisX.LabelStyle.ForeColor = DarkGrayColor
            .ChartAreas(0).AxisY.LabelStyle.ForeColor = DarkGrayColor

        End With
    End Sub

    Private Sub UpdateGraph(Title As String, GenArray() As Double, Time_AxisLabel As String, GenMax() As Double, TemperatureArrayCenter() As Double)
        'Updates the graph with the three results from the simulation
        Dim I As Integer

        If UBound(GenArray) <> UBound(GenMax) Then Exit Sub
        If UBound(GenArray) <> UBound(TemperatureArrayCenter) Then Exit Sub

        'Axis title
        AccessFractionChart.ChartAreas(0).AxisX.Title = Time_AxisLabel

        'Titles
        AccessFractionChart.Titles.Clear()
        AccessFractionChart.Titles.Add(Title)

        'Surface series
        AccessFractionChart.Series.Clear()
        Dim Surf As New DataVisualization.Charting.Series
        Surf.Name = "Ac Frac."
        Surf.ChartType = DataVisualization.Charting.SeriesChartType.Line
        For I = 0 To UBound(GenMax)
            Surf.Points.AddXY(GenArray(I), GenMax(I))
        Next
        Surf.Color = Color.Red
        Surf.BorderWidth = 1
        AccessFractionChart.Series.Add(Surf)

        'Center series
        Dim Center As New DataVisualization.Charting.Series
        Center.Name = "Center"
        Center.ChartType = DataVisualization.Charting.SeriesChartType.Line
        For I = 0 To UBound(TemperatureArrayCenter)
            Center.Points.AddXY(GenArray(I), TemperatureArrayCenter(I))
        Next
        Center.Color = Color.Blue
        Center.BorderWidth = 1
        AccessFractionChart.Series.Add(Center)

        'Chart resizing
        AccessFractionChart.ChartAreas(0).AxisX.Minimum = GenArray(0)
        AccessFractionChart.ChartAreas(0).AxisX.Maximum = GenArray(UBound(GenArray))

        Dim TInterval, TMin1, TMax1, TMin2, TMax2, padding As Double
        MinMax(GenMax, TMin1, TMax1)
        MinMax(TemperatureArrayCenter, TMin2, TMax2)

        Dim TMin As Double = Math.Min(TMin1, TMin2)
        Dim TMax As Double = Math.Max(TMax1, TMax2)
        TInterval = TMax - TMin
        padding = 0.1
        AccessFractionChart.ChartAreas(0).AxisY.Minimum = TMin - padding * TInterval
        AccessFractionChart.ChartAreas(0).AxisY.Maximum = TMax + padding * TInterval

        'Implements smart axis tick marks
        With AccessFractionChart.ChartAreas(0)
            .AxisX.Interval = GetTickInterval(.AxisX.Minimum, .AxisX.Maximum, 5)
            .AxisX.MajorTickMark.Interval = .AxisX.Interval
            .AxisX.Minimum = Int(.AxisX.Minimum / .AxisX.Interval) * .AxisX.Interval
            .AxisX.Maximum = Int(.AxisX.Maximum / .AxisX.Interval) * .AxisX.Interval

            .AxisY.Interval = GetTickInterval(.AxisY.Minimum, .AxisY.Maximum, 5)
            .AxisY.MajorTickMark.Interval = .AxisY.Interval
            .AxisY.Minimum = (Int(.AxisY.Minimum / .AxisY.Interval) - 1) * .AxisY.Interval
            .AxisY.Maximum = (Int(.AxisY.Maximum / .AxisY.Interval) + 1) * .AxisY.Interval
        End With

        'Binds axes tooltips
        Surf.ToolTip = "t=#VALX s" & vbCrLf & "T=#VALY ºC"
        Center.ToolTip = "t=#VALX s" & vbCrLf & "T=#VALY ºC"

        'Legends
        AccessFractionChart.Legends.Clear()
        'AccessFractionChart.Legends.Add("Surface")
        'AccessFractionChart.Legends.Add("Center")
        'AccessFractionChart.Legends(0).Position.Auto = False
        'AccessFractionChart.Legends(0).Position = New DataVisualization.Charting.ElementPosition(80, 10, 15, 20)

    End Sub


    Private Sub ClearGraph()
        'Clears the data in the chart
        AccessFractionChart.Titles.Clear()
        AccessFractionChart.Series.Clear()
    End Sub


#End Region

End Class