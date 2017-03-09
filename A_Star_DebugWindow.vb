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
            FillTable(BestGenerations.Last)
        Else
            FillTable(OriginalState)
        End If

        GenUpDn.Maximum = BestGenerations.Count
        GenUpDn.Value = BestGenerations.Count
    End Sub

    Private Sub A_Star_DebugWindow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SplitContainer1.SplitterDistance = 210
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
            FillTable(OriginalState)
            txtMovements.Text = "0"
            txtLevelsTraversed.Text = "0"
            txtTimeTaken.Text = "0"
            txtFitnessValue.Text = "-"
            txtAccessFraction.Text = "-"
        Else
            Dim CurrentGen As FringeItem = BestGenerations(Int(GenUpDn.Value - 1))
            FillTable(CurrentGen)
            txtMovements.Text = Str(CurrentGen.PlanOfActions.Count)
            txtLevelsTraversed.Text = Str(CurrentGen.PrevCost_G)
            txtTimeTaken.Text = Str(Round(CurrentGen.PrevCost_G * (VRTM_SimVariables.LevelCenterDist / 1000) / (VRTM_SimVariables.ElevSpeed * 60), 1))
            txtFitnessValue.Text = Str(CurrentGen.Current_Utility_U)
            txtAccessFraction.Text = Str(Round(CurrentGen.Current_Reward_R * 100, 1))
        End If
    End Sub

    Private Sub FillTable(Content As FringeItem)
        dgvTableView.Rows.Clear()
        Dim NRow As Integer

        For I As Integer = 0 To UBound(OriginalState.VRTMStateConv, 2)
            NRow = dgvTableView.Rows.Add()
            For J As Integer = 0 To UBound(OriginalState.VRTMStateConv, 1)
                dgvTableView.Rows(NRow).Cells(J + 1).Value = Content.VRTMStateConv(J, I)
            Next
        Next
    End Sub

End Class