
Partial Class Controls_WebUserControlHeader
    Inherits System.Web.UI.UserControl

    Protected Sub ImageButtonEnglish_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonEnglish.Click

        Session("Language") = "English"

        Response.Redirect(Request.RawUrl)

    End Sub

    Protected Sub ImageButtonSpanish_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSpanish.Click

        Session("Language") = "Spanish"

        Response.Redirect(Request.RawUrl)

    End Sub

    Protected Sub ImageButtonFrench_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonFrench.Click

        Session("Language") = "French"

        Response.Redirect(Request.RawUrl)

    End Sub

    Protected Sub ImageButtonGerman_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonGerman.Click

        Session("Language") = "German"

        Response.Redirect(Request.RawUrl)

    End Sub

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub ImageButtonDutch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonDutch.Click

        Session("Language") = "Dutch"

        Response.Redirect(Request.RawUrl)

    End Sub
End Class
