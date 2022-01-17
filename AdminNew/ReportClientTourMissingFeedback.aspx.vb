
Partial Class Admin_ReportClientTourMissingFeedback
    Inherits System.Web.UI.Page





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
      
    End Sub

 
End Class
