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


    End Sub

    Private Sub A_Star_DebugWindow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SplitContainer1.SplitterDistance = 210
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