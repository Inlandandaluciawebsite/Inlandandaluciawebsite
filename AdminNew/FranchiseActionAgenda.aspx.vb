Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_FranchiseActionAgenda
    Inherits System.Web.UI.Page

    Dim dt As New DataTable()
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

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
            ViewState("SortExpressionCP") = "Action_Date ASC"
            'Here i am binding all existing client history by Franchise 
            BindAgents()
            BindFranchiseStatus()
            BindFranchiseAction()
            If Request.QueryString.HasKeys() Then
                ID = Convert.ToInt32(Request.QueryString(0))
                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@History_ID", ID)
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_SELECT_BY_HistoryID", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    btnClientHistoryUpdate.Style.Add("display", "inline")
                    btnClientHistorySave.Style.Add("display", "none")
                    drpFranchiseStatus.Items(drpFranchiseStatus.Items.IndexOf(drpFranchiseStatus.Items.FindByValue(dt.Rows(0)("Franchise_Status").ToString()))).Selected = True
                    drpAgents.Items(drpAgents.Items.IndexOf(drpAgents.Items.FindByValue(dt.Rows(0)("Modified_By").ToString()))).Selected = True
                    txtActionDate.Text = dt.Rows(0)("Action_Date").ToString()
                    txtDescription.Text = dt.Rows(0)("History_Text").ToString()
                    'If (dt.Rows(0)("Archived").ToString() = True) Then
                    '    'chkIsArchived.Checked = True
                    'Else
                    '    'chkIsArchived.Checked = False
                    'End If
                End If
                Page.RegisterStartupScript("script", "<script language='javascript'>document.getElementById('ContentPlaceHolder1_txtDescription').focus();</script>")
            End If
            ' If Session Value for Admin Menu Items is NULL
            If Session("AdminLoggedIn") = Nothing Then
                ' Assign Value
                Session("AdminLoggedIn") = False
            End If
            ' Initialize the sorting expression. 
        End If
    End Sub
    Public Sub BindFranchiseAction()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Franchise_ID", Request.QueryString("FranchiseId").ToString())
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_FUTURE_SELECT", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            ' get the dataview from person datatable. 
            Dim dvclientproperties As DataView = dt.DefaultView

            ' set the sort column and sort order. 
            dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()
            grdActionAgenda.DataSource = dvclientproperties
            grdActionAgenda.DataBind()
        End If
    End Sub
    Protected Sub grdActionAgenda_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdActionAgenda.PageIndex = e.NewPageIndex
        BindFranchiseAction()
    End Sub
    Protected Sub grdActionAgenda_Sorting(sender As Object, e As GridViewSortEventArgs)
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
        BindFranchiseAction()
    End Sub
    Public Sub BindAgents()
        Dim partnerid As Int16 = Convert.ToInt32(Session("ContactPartnerID"))
        Dim dt As DataTable
        If Convert.ToBoolean(Session("AdminUser")) Then
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Contact_SelectAll").Tables(0)
        Else
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@Partner_Id", partnerid)
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Contact_SelectAll_By_PartnerId").Tables(0)
        End If
        If dt.Rows.Count > 0 Then
            drpAgents.DataSource = dt
            drpAgents.DataTextField = "Contact_Name"
            drpAgents.DataValueField = "Contact_ID"
            drpAgents.DataBind()
            If Request.QueryString("History_ID") Is Nothing Then
                drpAgents.SelectedValue = Session("ContactID")
            End If
        End If
    End Sub
    Public Sub BindFranchiseStatus()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_STATUS_SELECT").Tables(0)
        If dt.Rows.Count > 0 Then
            drpFranchiseStatus.DataSource = dt
            drpFranchiseStatus.DataTextField = "Name"
            drpFranchiseStatus.DataValueField = "Franchise_Status_Id"
            drpFranchiseStatus.DataBind()
        End If
    End Sub
    Protected Sub grdActionAgenda_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "EditFranchise" Then
            Response.Redirect("FranchiseActionAgenda.aspx?History_ID=" & e.CommandArgument.ToString() & "&FranchiseId=" + Request.QueryString("FranchiseId").ToString())
        End If
    End Sub
    Protected Sub btnClientHistoryUpdate_Click(sender As Object, e As EventArgs)

        ID = Convert.ToInt32(Request.QueryString(0))
        Dim sql As SqlParameter() = New SqlParameter(7) {}
        sql(0) = New SqlParameter("@Franchise_Status", Convert.ToInt32(drpFranchiseStatus.SelectedValue))
        sql(1) = New SqlParameter("@Franchise_ID", Request.QueryString("FranchiseId").ToString())
        If txtActionDate.Text = "" Then
            sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
        Else
            sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
        End If
        sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
        sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
        If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
            sql(5) = New SqlParameter("@Archived", 1)
        Else
            sql(5) = New SqlParameter("@Archived", 0)
        End If

        sql(6) = New SqlParameter("@History_ID", ID)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_UPDATE", sql).ToString()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "updatescript", "changeDateControl(); alert('Record has been updated successfully !');", True)
        'Response.Redirect("FranchiseActionAgenda.aspx?FranchiseId=" & Request.QueryString("FranchiseId").ToString())
        BindFranchiseAction()
        txtActionDate.Text = ""
        txtDescription.Text = ""
        drpFranchiseStatus.SelectedIndex = 0
    End Sub
    Protected Sub btnClientHistorySave_Click(sender As Object, e As EventArgs)

        Dim sql As SqlParameter() = New SqlParameter(6) {}
        sql(0) = New SqlParameter("@Franchise_Status", Convert.ToInt32(drpFranchiseStatus.SelectedValue))
        sql(1) = New SqlParameter("@Franchise_ID", Request.QueryString("FranchiseId").ToString())
        If txtActionDate.Text = "" Then
            sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
        Else
            sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
        End If
        sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
        sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
        If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
            sql(5) = New SqlParameter("@Archived", 1)
        Else
            sql(5) = New SqlParameter("@Archived", 0)
        End If
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_INSERT", sql).ToString()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "addScript", "changeDateControl(); alert('Record has been saved successfully !');", True)
        BindFranchiseAction()
        txtActionDate.Text = ""
        txtDescription.Text = ""
        drpFranchiseStatus.SelectedIndex = 0
        'chkIsArchived.Checked = False
        '  Response.Redirect("FranchiseActionAgenda.aspx")

    End Sub
End Class
