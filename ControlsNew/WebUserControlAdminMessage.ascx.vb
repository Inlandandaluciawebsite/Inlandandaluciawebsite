
Partial Class WebUserControlAdminMessage
    Inherits System.Web.UI.UserControl

    Public Event Acknowledged()

    Public Sub InitMessage(ByVal szTitle As String, ByVal alMessage As ArrayList, Optional ByVal bBulletPoints As Boolean = False)

        ' Set Title
        LabelTitle.Text = szTitle.Trim

        ' If Bullet Points
        If bBulletPoints Then
            LabelMessage.Text = "<ul>"
        Else
            LabelMessage.Text = String.Empty
        End If

        ' Add each Line of the Message
        For Each szLine As String In alMessage

            ' If Bullet Points
            If bBulletPoints Then
                LabelMessage.Text &= "<li>" & szLine.Trim & "</li>"
            Else
                LabelMessage.Text &= szLine.Trim & "<br />"
            End If

        Next

        ' If Bullet Points
        If bBulletPoints Then
            LabelMessage.Text &= "</ul>"
        End If

    End Sub

    Protected Sub ButtonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOK.Click

        RaiseEvent Acknowledged()

    End Sub

End Class
