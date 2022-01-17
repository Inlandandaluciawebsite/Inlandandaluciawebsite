
Partial Class Controls_WebUserControlNoResults
    Inherits System.Web.UI.UserControl

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Depending on whether or not we are in Agent Mode, set up the Try Again redirect accordingly
        If Session("AgentID") Is Nothing Then
            TryAgain.InnerHtml = "<a href=""propsearch.aspx"" title=""New search"">" & GetTranslation("try again") & "</a>"
        Else
            TryAgain.InnerHtml = "<a href=""AgentArea.aspx"" title=""New search"">" & GetTranslation("try again") & "</a>"
        End If

    End Sub

End Class
