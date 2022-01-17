
Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares

Partial Class AdminNew_FeedLogs
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        If Not IsPostBack Then
            bindfeedlogs()
        End If
    End Sub
    Private Sub bindfeedlogs()

        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Get_Feed_Log").Tables(0)
        If dt.Rows.Count > 0 Then
            grdfeedlogs.DataSource = dt
            grdfeedlogs.DataBind()
            lblmessage.Visible = False
        Else
            grdfeedlogs.DataSource = dt
            grdfeedlogs.DataBind()
            lblmessage.Visible = True
        End If

    End Sub

    Protected Sub grdfeedlogs_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editblog" Then
            Response.Redirect("AddBlog.aspx?BlogId=" + e.CommandArgument.ToString())
        End If
    End Sub
    Protected Sub grdfeedlogs_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdfeedlogs.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub grdfeedlogs_RowDataBound1(sender As Object, e As GridViewRowEventArgs)

    End Sub
    Protected Sub imgsearch_Click1(sender As Object, e As EventArgs)
    End Sub
End Class
