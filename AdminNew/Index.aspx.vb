
Partial Class Admin_Index
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            Response.Redirect("/AgentLogin.aspx")
        End If

        If Convert.ToInt32(Session("ContactType")) = 2 Then
            WebUserControlAdminLawyerArea.Visible = True
            dshcont1.Style.Add(HtmlTextWriterStyle.Display, "none")
            dshcont.Style.Add(HtmlTextWriterStyle.Display, "none")
        Else
            dshcont1.Style.Add(HtmlTextWriterStyle.Display, "block")
            dshcont.Style.Add(HtmlTextWriterStyle.Display, "block")
            WebUserControlAdminLawyerArea.Visible = False

        End If
    End Sub
End Class
