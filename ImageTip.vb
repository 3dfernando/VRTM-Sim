Public Class ImageTip
    'From http://stackoverflow.com/questions/21281411/how-to-add-image-to-tooltip-using-vb-net
    Inherits ToolTip

    Public Sub New()
        MyBase.New()
        Me.OwnerDraw = True 'Must be set otherwise will not draw the image properly
        Me.IsBalloon = False
    End Sub

    Private Sub ImageTip_Draw(ByVal sender As Object, ByVal e As DrawToolTipEventArgs) _
                Handles Me.Draw
        'Draws the image in the tooltip popup by reading the tooltip
        'text on the control that you want to have a popup for
        e.Graphics.DrawImage(My.Resources.ResourceManager.GetObject(e.ToolTipText), 0, 0)
    End Sub

    Private Sub ImageTip_Popup(ByVal sender As Object, ByVal e As PopupEventArgs) _
                Handles Me.Popup
        'Creates the popup and sets its dimensions from the resource name
        Dim Image As Image
        Dim ToolText As String

        ToolText = Me.GetToolTip(e.AssociatedControl)
        If ToolText <> "" Then
            Image = My.Resources.ResourceManager.GetObject(ToolText)
            If Image IsNot Nothing Then
                e.ToolTipSize = New Size(Image.Width, Image.Height)
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class
