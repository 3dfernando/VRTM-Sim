Public Class frmDisplaySettings

    Private Sub frmDisplaySettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Initializes
        txtDisplayParam.SelectedIndex = My.Settings.DisplayParameter
        chkHighlight.Checked = My.Settings.Display_boolHighlight
        chkConditionalForm.Checked = My.Settings.Display_boolConditionalFormatting

        pcbHighlight.BackColor = My.Settings.Display_HighlightColor
        pcbMinTray.BackColor = My.Settings.Display_MinimumColor
        pcbMaxTray.BackColor = My.Settings.Display_MaximumColor
    End Sub

    Private Sub frmDisplaySettings_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Closes
        My.Settings.DisplayParameter = txtDisplayParam.SelectedIndex
        My.Settings.Display_boolHighlight = chkHighlight.Checked
        My.Settings.Display_boolConditionalFormatting = chkConditionalForm.Checked

        My.Settings.Display_HighlightColor = pcbHighlight.BackColor
        My.Settings.Display_MinimumColor = pcbMinTray.BackColor
        My.Settings.Display_MaximumColor = pcbMaxTray.BackColor

        My.Settings.Save()
    End Sub

    Private Sub ColorChange(sender As Object, e As EventArgs) Handles pcbHighlight.Click, pcbMinTray.Click, pcbMaxTray.Click, pcbMaxCenter.Click, pcbMinCenter.Click, pcbMaxRet.Click, pcbMinRet.Click, pcbMaxConv.Click, pcbMaxPow.Click, pcbMinPow.Click, pcbMaxSurf.Click, pcbMinSurf.Click, pcbMinConv.Click
        If Not ColorDialog1.ShowDialog() = DialogResult.Cancel Then
            sender.BackColor = ColorDialog1.Color
            UpdateGradients()
        End If
    End Sub

    Public Sub UpdateGradients()
        UpdateGradient(pcbMinTray.BackColor, pcbMaxTray.BackColor, pcbGradTray)
        UpdateGradient(pcbMinConv.BackColor, pcbMaxConv.BackColor, pcbGradConv)
        UpdateGradient(pcbMinRet.BackColor, pcbMaxRet.BackColor, pcbGradRet)
        UpdateGradient(pcbMinCenter.BackColor, pcbMaxCenter.BackColor, pcbGradCenter)
        UpdateGradient(pcbMinSurf.BackColor, pcbMaxSurf.BackColor, pcbGradSurf)
        UpdateGradient(pcbMinPow.BackColor, pcbMaxPow.BackColor, pcbGradPow)
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