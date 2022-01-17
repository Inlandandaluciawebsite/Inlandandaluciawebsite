
Partial Class WebUserControlAdminPropertyImage
    Inherits System.Web.UI.UserControl

    Public Event ImageLeft(ByVal nPosition As Integer)
    Public Event ImageRight(ByVal nPosition As Integer)
    Public Event ImageUp(ByVal nPosition As Integer)
    Public Event ImageDown(ByVal nPosition As Integer)
    Public Event ImageDelete(ByVal nPosition As Integer)    

    Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        RaiseEvent ImageDelete(Convert.ToInt32(ID.Substring(18)))
    End Sub

    Public Sub LoadImage(ByVal CImage As ClassImage)

        ' Assign to Image
        ImageProperty.ImageUrl = CImage.URL

        ' Update Image
        UpdatePanelPropertyImage.Update()

    End Sub

    Public Function GetImageURL() As String

        ' Get the Image URL
        Return ImageProperty.ImageUrl

    End Function

    Public Sub MakeHeaderImage(ByVal bHeader As Boolean)

        ' If this is the Header
        If bHeader Then

            ' Enlarge Image
            ImageProperty.Width = "400"
            ImageProperty.Height = "300"

        Else

            ' Normal Image
            ImageProperty.Width = "200"
            ImageProperty.Height = "150"

        End If

    End Sub

    Public Sub Enable(ByVal bEnabled As Boolean)

        ' Enable / Disable
        ButtonDelete.Visible = bEnabled
        ImageButtonLeft.Visible = bEnabled
        ImageButtonRight.Visible = bEnabled
        ImageButtonUp.Visible = bEnabled
        ImageButtonDown.Visible = bEnabled

    End Sub

    Protected Sub ImageButtonLeft_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonLeft.Click
        RaiseEvent ImageLeft(Convert.ToInt32(ID.Substring(18)))
    End Sub

    Protected Sub ImageButtonRight_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonRight.Click
        RaiseEvent ImageRight(Convert.ToInt32(ID.Substring(18)))
    End Sub

    Protected Sub ImageButtonUp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonUp.Click
        RaiseEvent ImageUp(Convert.ToInt32(ID.Substring(18)))
    End Sub

    Protected Sub ImageButtonDown_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonDown.Click
        RaiseEvent ImageDown(Convert.ToInt32(ID.Substring(18)))
    End Sub
End Class
