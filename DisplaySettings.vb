Public Class frmDisplaySettings

    Private Sub frmDisplaySettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Initializes
        txtDisplayParam.SelectedIndex = My.Settings.DisplayParameter
        txtTextColor.SelectedIndex = My.Settings.DisplayParameterForeColor
        txtBGColor.SelectedIndex = My.Settings.DisplayParameterBackColor

        chkHighlight.Checked = My.Settings.Display_boolHighlight

        pcbHighlight.BackColor = My.Settings.Display_HighlightColor

        pcbMinText.BackColor = My.Settings.Display_MinColor_ForeColor
        pcbMaxText.BackColor = My.Settings.Display_MaxColor_ForeColor

        pcbMinBG.BackColor = My.Settings.Display_MinColor_BackColor
        pcbMaxBG.BackColor = My.Settings.Display_MaxColor_BackColor
    End Sub

    Private Sub frmDisplaySettings_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Closes
        My.Settings.DisplayParameter = txtDisplayParam.SelectedIndex
        My.Settings.DisplayParameterForeColor = txtTextColor.SelectedIndex
        My.Settings.DisplayParameterBackColor = txtBGColor.SelectedIndex

        My.Settings.Display_boolHighlight = chkHighlight.Checked

        My.Settings.Display_HighlightColor = pcbHighlight.BackColor

        My.Settings.Display_MinColor_ForeColor = pcbMinText.BackColor
        My.Settings.Display_MaxColor_ForeColor = pcbMaxText.BackColor

        My.Settings.Display_MinColor_BackColor = pcbMinBG.BackColor
        My.Settings.Display_MaxColor_BackColor = pcbMaxBG.BackColor

        My.Settings.Save()
    End Sub

    Private Sub ColorChange(sender As Object, e As EventArgs) Handles pcbHighlight.Click, pcbMinText.Click, pcbMaxText.Click, pcbMaxBG.Click, pcbMinBG.Click
        If Not ColorDialog1.ShowDialog() = DialogResult.Cancel Then
            sender.BackColor = ColorDialog1.Color
            UpdateGradients()
        End If
    End Sub

    Public Sub UpdateGradients()
        UpdateGradient(pcbMinText.BackColor, pcbMaxText.BackColor, pcbGradText)
        UpdateGradient(pcbMinBG.BackColor, pcbMaxBG.BackColor, pcbGradBG)
    End Sub

    Public Sub UpdateGradient(MinColor As Color, MaxColor As Color, recipient As PictureBox)
        'Updates the gradient
        Dim vLinearGradient As Drawing.Drawing2D.LinearGradientBrush =
        New Drawing.Drawing2D.LinearGradientBrush(New Drawing.Point(0, 0),
                                                    New Drawing.Point(recipient.Width, 0),
                                                    MinColor,
                                                    MaxColor)
        Dim vGraphic As Drawing.Graphics = recipient.CreateGraphics
        ' To tile the image background - Using the same image background of the image
        'Dim vTexture As New Drawing.TextureBrush(pcbGradient.BackgroundImage)

        vGraphic.FillRectangle(vLinearGradient, recipient.DisplayRectangle)
        'vGraphic.FillRectangle(vTexture, pcbGradient.DisplayRectangle)

        vGraphic.Dispose() : vGraphic = Nothing  'vTexture.Dispose() : vTexture = Nothing
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        'This is a workaround as the routine UpdateGradient doesn't work in the Form_Shown event
        UpdateGradients()
        Timer.Enabled = False
    End Sub

End Class