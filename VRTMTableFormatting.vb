Module VRTMTableFormatting

    Public Sub FormatTable()
        Dim DefFont As New Font("Calibri", 8, FontStyle.Regular)
        Dim pad As New Padding(1)

        With MainWindow.VRTMTable
            .BackgroundColor = Color.LightGray
            .EnableHeadersVisualStyles = False

            .DefaultCellStyle.Font = DefFont
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellBorderStyle = DataGridViewCellBorderStyle.Single

            .RowHeadersDefaultCellStyle.Font = DefFont
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            .RowHeadersDefaultCellStyle.Padding = pad
            .RowHeadersWidth = 60
            .RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 150)
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 150)
            .ColumnHeadersDefaultCellStyle.Font = DefFont
            .ColumnHeadersHeight = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Padding = pad
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            .ClearSelection()
        End With

    End Sub

    Public Sub DefaultBGColorTable()
        'Formats the background of the table with the "Default" background color
        Dim i As Integer
        Try
            With MainWindow.VRTMTable
                For i = 0 To .Rows.Count
                    For Each c As DataGridViewCell In .Rows(i).Cells
                        c.Style.BackColor = Color.FromArgb(255, 255, 204)
                    Next
                Next
                .ClearSelection()
            End With
        Catch ex As Exception

        End Try
    End Sub


End Module
