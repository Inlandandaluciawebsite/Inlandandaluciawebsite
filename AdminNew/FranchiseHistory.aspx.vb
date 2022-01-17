Imports Microsoft.VisualBasic
Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_FranchiseHistory
    Inherits System.Web.UI.Page
    Dim dt As New DataTable()
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        ' Session Variables
        If Session("AdminDisplayingMessage") Is Nothing Then
            Session("AdminDisplayingMessage") = False
        End If
        If Session("AdminPropertyEdit") Is Nothing Then
            Session("AdminPropertyEdit") = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        ' So Postbacks for Image and Document Uploading work First Time
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        ' If we are not in Agent Mode
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not Page.IsPostBack Then
            ViewState("SortExpressionCP") = "Create_Date DESC"
            'Here i am binding all existing client history by Franchise 
            BindHistoryByFranchise()
            ' If Session Value for Admin Menu Items is NULL
            If Session("AdminLoggedIn") = Nothing Then
                ' Assign Value
                Session("AdminLoggedIn") = False
            End If
            ' Initialize the sorting expression. 
        End If
    End Sub
    Public Sub BindHistoryByFranchise()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Franchise_ID", Request.QueryString("FranchiseId").ToString())
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_SELECT_BY_FranchiseID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            ' Get the DataView from Person DataTable. 
            Dim dvclientproperties As DataView = dt.DefaultView

            '' Set the sort column and sort order. 
            dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()
            grdFranchiseHistory.DataSource = dvclientproperties
            grdFranchiseHistory.DataBind()
        End If
    End Sub
    Protected Sub grdFranchiseHistory_Sorting(sender As Object, e As GridViewSortEventArgs)
        Dim strSortExpression As String() = ViewState("SortExpressionCP").ToString().Split(" ")
        ' If the sorting column is the same as the previous one,  
        ' then change the sort order. 
        If strSortExpression(0) = e.SortExpression Then
            If strSortExpression(1) = "ASC" Then
                ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "DESC"
            Else
                ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "ASC"
            End If
        Else
            ' If sorting column is another column,   
            ' then specify the sort order to "Ascending". 
            ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "ASC"
        End If
        ' Rebind the GridView control to show sorted data. 
        BindHistoryByFranchise()
    End Sub
    Protected Sub grdFranchiseHistory_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdFranchiseHistory.PageIndex = e.NewPageIndex
        BindHistoryByFranchise()
    End Sub
    Protected Sub grdFranchiseHistory_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "moreinfo" Then
            Dim History_ID As Integer = Convert.ToInt32(e.CommandArgument)
            Dim sql As SqlParameter() = New SqlParameter(0) {}
            sql(0) = New SqlParameter("@History_ID", History_ID)
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_SELECT_BY_History_Id", sql).Tables(0)
            If dt.Rows.Count > 0 Then
                lblActionDate.Text = dt.Rows(0)("Action_Date").ToString()
                lblFranchiseForename.Text = dt.Rows(0)("Franchise").ToString()
                'lblFranchiseSurname.Text = dt.Rows(0)("Franchise_Surname").ToString()
                lblCreateDate.Text = dt.Rows(0)("Create_Date").ToString()
                lblHistoryText.Text = dt.Rows(0)("History_Text").ToString()
                lblType.Text = dt.Rows(0)("Type").ToString()
                lblCreatedBy.Text = dt.Rows(0)("CreatedBy").ToString()
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type='text/javascript'>")
                sb.Append("$(function () { $('#dialog').dialog({modal: true,autoOpen: false,height: 300,width: 500});$('#dialog').dialog('open'); });")
                sb.Append("</script>")
                ' ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "EditModalScript", sb.ToString(), False)
                ClientScript.RegisterStartupScript(Me.GetType(), "EditModalScript", sb.ToString())
            End If
        End If
    End Sub
End Class
