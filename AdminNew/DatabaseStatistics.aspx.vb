Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Partial Class BuyerSource
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        ' Load the Stats
        Dim CDataAccess As New ClassDataAccess
        GridViewStatistics.DataSource = CDataAccess.DatabaseStats()
        CDataAccess = Nothing
        GridViewStatistics.DataBind()

    End Sub
End Class
