
Partial Class WebUserControlAdminDatabaseStatistics
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Load the Stats
        Dim CDataAccess As New ClassDataAccess
        GridViewStatistics.DataSource = CDataAccess.DatabaseStats()
        CDataAccess = Nothing
        GridViewStatistics.DataBind()

    End Sub

End Class
