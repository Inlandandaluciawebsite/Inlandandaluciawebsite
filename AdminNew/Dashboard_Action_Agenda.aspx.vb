Imports Microsoft.VisualBasic
Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Public Class Dashboard_Action_Agenda
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
        ' So Postbacks for Image and Document Uploading work First Time
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        ' If we are not in Agent Mode
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not Page.IsPostBack Then
            ViewState("SortExpressionCP") = "Action_Date DESC"
            'Here i am binding all existing client history by buyer
            BindAgents()

            If Not String.IsNullOrEmpty(Request.QueryString("Type")) Then
                If Request.QueryString("Type").ToString() = "Buyer" Then
                    drpActionAgendaType.Items.FindByValue("Buyer").Selected = True
                Else
                    drpActionAgendaType.Items.FindByValue("Franchise").Selected = True
                End If
            End If

            BindStatus(drpActionAgendaType.SelectedValue)
            BindAction(drpActionAgendaType.SelectedValue)
            If Not String.IsNullOrEmpty(Request.QueryString("History_ID")) Then
                If Request.QueryString.HasKeys() Then
                    ID = Convert.ToInt32(Request.QueryString(0))
                    Dim sql As SqlParameter() = New SqlParameter(0) {}
                    sql(0) = New SqlParameter("@History_ID", ID)
                    If Request.QueryString("Type").ToString() = "Buyer" Then
                        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_SELECT_BY_HistoryID", sql).Tables(0)
                        If dt.Rows.Count > 0 Then
                            btnClientHistoryUpdate.Style.Add("display", "Inline")
                            btnClientHistorySave.Style.Add("display", "none")
                            BindStatus("Buyer")
                            If Not Convert.ToString(dt.Rows(0)("Action_Type")) = "1" Then
                                drpStatus.Items(drpStatus.Items.IndexOf(drpStatus.Items.FindByValue(dt.Rows(0)("Action_Type").ToString()))).Selected = True
                            End If
                            drpActionStatus.Items(drpActionStatus.Items.IndexOf(drpActionStatus.Items.FindByValue(dt.Rows(0)("Action_Status").ToString()))).Selected = True
                            If drpActionStatus.SelectedItem.Text = "In Progress" Then
                                txtDescription.Enabled = True
                            Else
                                txtDescription.Enabled = False
                            End If
                            drpAgents.SelectedValue = dt.Rows(0)("Modified_By").ToString()
                            txtActionDate.Text = dt.Rows(0)("Action_Date").ToString()
                            txtDescription.Text = dt.Rows(0)("History_Text").ToString()
                            hdnBuyerId.Value = dt.Rows(0)("Buyer_Id").ToString()
                        End If
                    Else
                        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_SELECT_BY_HistoryID", sql).Tables(0)
                        If dt.Rows.Count > 0 Then
                            btnClientHistoryUpdate.Style.Add("display", "Inline")
                            btnClientHistorySave.Style.Add("display", "none")
                            BindStatus("Franchise")
                            If Not Convert.ToString(dt.Rows(0)("Franchise_Status")) = "1" Then
                                drpStatus.Items(drpStatus.Items.IndexOf(drpStatus.Items.FindByValue(dt.Rows(0)("Franchise_Status").ToString()))).Selected = True
                            End If
                            drpAgents.SelectedValue = dt.Rows(0)("Modified_By").ToString()
                            txtActionDate.Text = dt.Rows(0)("Action_Date").ToString()
                            txtDescription.Text = dt.Rows(0)("History_Text").ToString()
                            hdnFranchiseId.Value = dt.Rows(0)("Franchise_Id").ToString()
                        End If
                    End If
                    Page.RegisterStartupScript("script", "<script language='javascript'>document.getElementById('ContentPlaceHolder1_txtDescription').focus();</script>")
                    actionDetails.Visible = True
                End If
                ' If Session Value for Admin Menu Items is NULL
                If Session("AdminLoggedIn") = Nothing Then
                    ' Assign Value
                    Session("AdminLoggedIn") = False
                End If
            End If

            ' Initialize the sorting expression. 
        End If
    End Sub
    Public Sub BindAgents()
        'Dim Contact_Partner_Id As Int16
        'If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
        '    Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        'Else
        '    Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        'End If
        'Dim sql As SqlParameter() = New SqlParameter(0) {}
        'sql(0) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)
        'Dim dt As DataTable
        'If Convert.ToInt32(Session("AdminUser")) = 0 Then
        '    dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_SelectAll_By_PartnerId", sql).Tables(0)
        'Else
        '    drpActionAgendaType.Visible = True
        '    dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_SelectAll").Tables(0)
        'End If
        Dim partnerid As Int16 = Convert.ToInt32(Session("ContactPartnerID"))
        Dim dt As DataTable
        If Convert.ToBoolean(Session("AdminUser")) Then
            drpActionAgendaType.Visible = True
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Contact_SelectAll").Tables(0)
        Else
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@Partner_Id", partnerid)
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Contact_SelectAll_By_PartnerId", sql).Tables(0)
        End If

        If dt.Rows.Count > 0 Then
            drpAgents.DataSource = dt
            drpAgents.DataTextField = "Contact_Name"
            drpAgents.DataValueField = "Contact_ID"
            drpAgents.DataBind()
            Dim licategory As New ListItem("-- Select User--", "0")
            drpAgents.Items.Insert(0, licategory)
            If Not Request.QueryString.HasKeys() Then
                drpAgents.SelectedValue = Session("ContactID")
            End If
        End If
    End Sub
    Public Sub BindStatus(type As String)
        Dim strProcedure As String = "USP_BUYER_STATUS_SELECT_From_ActionTypes"
        Dim strValueField As String = "Action_Type_Id"
        If type = "Franchise" Then
            strProcedure = "USP_Franchise_STATUS_SELECT"
            strValueField = "Franchise_Status_Id"
        End If
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, strProcedure).Tables(0)
        If dt.Rows.Count > 0 Then
            drpStatus.DataSource = dt
            drpStatus.DataTextField = "Name"
            drpStatus.DataValueField = strValueField
            drpStatus.DataBind()
        End If
    End Sub
    Public Sub BindAction(type As String)
        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If
        If type = "Buyer" Then
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)
            sql(1) = New SqlParameter("@User_Id", Convert.ToInt32(Session("ContactID")))
            Dim dt As DataTable
            If Convert.ToInt32(Session("AdminUser")) = 0 Then
                dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_FUTURE_SELECT_All_By_User_Id", sql).Tables(0)
            Else
                dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_FUTURE_SELECT_All").Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                ' get the dataview from person datatable. 
                Dim dvBuyerActionAgenda As DataView = dt.DefaultView
                ' set the sort column and sort order. 
                dvBuyerActionAgenda.Sort = ViewState("SortExpressionCP").ToString()
                grdBuyerActionAgenda.DataSource = dvBuyerActionAgenda
                grdBuyerActionAgenda.DataBind()

                Dim dtTodayActions As DataTable
                dtTodayActions = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_FUTURE_SELECT_All_By_User_Id_TodayActions", sql).Tables(0)

                'Bind today's actions by selecting only today's date
                grdTodayActions.DataSource = dtTodayActions
                grdTodayActions.DataBind()
                grdFranchiseActionAgenda.Visible = False
                grdBuyerActionAgenda.Visible = True
            End If
        Else
            Dim sql As SqlParameter() = New SqlParameter(0) {}
            sql(0) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)
            Dim dt As DataTable
            If Convert.ToInt32(Session("AdminUser")) = 0 Then
                dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_FUTURE_SELECT_All_By_Partner_Id", sql).Tables(0)
            Else
                dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_FUTURE_SELECT_ALL").Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                ' get the dataview from person datatable. 
                Dim dvFranchiseActionAgenda As DataView = dt.DefaultView
                ' set the sort column and sort order. 
                dvFranchiseActionAgenda.Sort = ViewState("SortExpressionCP").ToString()
                grdFranchiseActionAgenda.DataSource = dvFranchiseActionAgenda
                grdFranchiseActionAgenda.DataBind()
                grdBuyerActionAgenda.Visible = False
                grdFranchiseActionAgenda.Visible = True
            End If
        End If
    End Sub
    Protected Sub grdBuyerActionAgenda_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdBuyerActionAgenda.PageIndex = e.NewPageIndex
        BindAction(drpActionAgendaType.SelectedValue)
    End Sub
    Protected Sub grdBuyerActionAgenda_Sorting(sender As Object, e As GridViewSortEventArgs)
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
        BindAction(drpActionAgendaType.SelectedValue)
    End Sub
    Protected Sub grdBuyerActionAgenda_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "EditBuyer" Then
            Response.Redirect("Dashboard_Action_Agenda.aspx?History_ID=" + e.CommandArgument.ToString() + "&Type=Buyer")
        End If
    End Sub
    Protected Sub btnClientHistoryUpdate_Click(sender As Object, e As EventArgs)
        popupActionYesNo.Visible = True
    End Sub
    Protected Sub btnClientHistorySave_Click(sender As Object, e As EventArgs)
        If drpActionAgendaType.SelectedValue = "Buyer" Then
            Dim sql As SqlParameter() = New SqlParameter(7) {}
            sql(0) = New SqlParameter("@Buyer_Status", Convert.ToInt32(drpStatus.SelectedValue))
            sql(1) = New SqlParameter("@Buyer_ID", Convert.ToInt32(hdnBuyerId.Value))
            If txtActionDate.Text = "" Then
                sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
            Else
                sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
            End If
            sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
            sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)

            Dim strSelectedDate As DateTime = Convert.ToDateTime(txtActionDate.Text)
            Dim strTodayDate As DateTime = Convert.ToDateTime(DateTime.Now.ToString())

            If strSelectedDate.Day = strTodayDate.Day And strSelectedDate.Month = strTodayDate.Month And strSelectedDate.Year = strTodayDate.Year Then
                sql(5) = New SqlParameter("@Archived", 0)
            Else
                If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
                    sql(5) = New SqlParameter("@Archived", 1)
                Else
                    sql(5) = New SqlParameter("@Archived", 0)
                End If
            End If
            sql(6) = New SqlParameter("@Action_Status", drpActionStatus.SelectedItem.Text)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_INSERT", sql).ToString()
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "changeDateControl(); alert('Record has been Saved successfully !');", True)
            BindAction(drpActionAgendaType.SelectedValue)
            txtActionDate.Text = ""
            txtDescription.Text = ""
            drpStatus.SelectedIndex = 0
            'chkIsArchived.Checked = False
            'Response.Redirect("ActionAgenda.aspx")
        Else
            Dim sql As SqlParameter() = New SqlParameter(6) {}
            sql(0) = New SqlParameter("@Franchise_Status", Convert.ToInt32(drpStatus.SelectedValue))
            sql(1) = New SqlParameter("@Franchise_ID", Convert.ToInt32(hdnFranchiseId.Value))
            If txtActionDate.Text = "" Then
                sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
            Else
                sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
            End If
            sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
            sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
            Dim strSelectedDate As DateTime = Convert.ToDateTime(txtActionDate.Text)
            Dim strTodayDate As DateTime = Convert.ToDateTime(DateTime.Now.ToString())

            If strSelectedDate.Day = strTodayDate.Day And strSelectedDate.Month = strTodayDate.Month And strSelectedDate.Year = strTodayDate.Year Then
                sql(5) = New SqlParameter("@Archived", 0)
            Else
                If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
                    sql(5) = New SqlParameter("@Archived", 1)
                Else
                    sql(5) = New SqlParameter("@Archived", 0)
                End If
            End If
            sql(6) = New SqlParameter("@Action_Status", drpActionStatus.SelectedItem.Text)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_INSERT", sql).ToString()
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "changeDateControl(); alert('Record has been Saved successfully !');", True)
            BindAction(drpActionAgendaType.SelectedValue)
            txtActionDate.Text = ""
            txtDescription.Text = ""
            drpStatus.SelectedIndex = 0
            'chkIsArchived.Checked = False
            'Response.Redirect("ActionAgenda.aspx")
        End If
    End Sub
    Protected Sub drpActionAgendaType_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindStatus(drpActionAgendaType.SelectedValue)
        BindAction(drpActionAgendaType.SelectedValue)
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "ScriptChangeDateAfterTypeSelection", "changeDateControl();", True)
    End Sub
    Protected Sub grdFranchiseActionAgenda_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdFranchiseActionAgenda.PageIndex = e.NewPageIndex
        BindAction(drpActionAgendaType.SelectedValue)
    End Sub
    Protected Sub grdFranchiseActionAgenda_Sorting(sender As Object, e As GridViewSortEventArgs)
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
        BindAction(drpActionAgendaType.SelectedValue)
    End Sub
    Protected Sub grdFranchiseActionAgenda_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "EditFranchise" Then
            Response.Redirect("Dashboard_Action_Agenda.aspx?History_ID=" + e.CommandArgument.ToString() + "&Type=Franchise")
        End If
    End Sub
    Protected Sub btnNewAction_Click(sender As Object, e As EventArgs)
        Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
        CBuyer.Load(Convert.ToInt32(hdnBuyerId.Value))
        Session("AdminBuyerSelected") = CBuyer
        Response.Redirect("BuyerActionAgenda.aspx")
    End Sub
    Protected Sub btnClientHistory_Click(sender As Object, e As EventArgs)
        Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
        CBuyer.Load(Convert.ToInt32(hdnBuyerId.Value))
        Session("AdminBuyerSelected") = CBuyer
        Response.Redirect("ClientHistory.aspx")
    End Sub
    Protected Sub drpActionStatus_SelectedIndexChanged(sender As Object, e As EventArgs)
        If drpActionStatus.SelectedItem.Text = "In Progress" Then
            txtDescription.Enabled = True
        Else
            txtDescription.Enabled = False
        End If
    End Sub
    Protected Sub btnSaveYes_Click(sender As Object, e As EventArgs)
        ID = Convert.ToInt32(Request.QueryString(0))

        If drpActionAgendaType.SelectedValue = "Buyer" Then
            Dim sql As SqlParameter() = New SqlParameter(8) {}
            sql(0) = New SqlParameter("@Buyer_Status", Convert.ToInt32(drpStatus.SelectedValue))
            sql(1) = New SqlParameter("@Buyer_ID", Convert.ToInt32(hdnBuyerId.Value))
            If txtActionDate.Text = "" Then
                sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
            Else
                sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
            End If
            sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
            sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
            Dim strSelectedDate As DateTime = Convert.ToDateTime(txtActionDate.Text)
            Dim strTodayDate As DateTime = Convert.ToDateTime(DateTime.Now.ToString())

            If strSelectedDate.Day = strTodayDate.Day And strSelectedDate.Month = strTodayDate.Month And strSelectedDate.Year = strTodayDate.Year Then
                sql(5) = New SqlParameter("@Archived", 0)
            Else
                If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
                    sql(5) = New SqlParameter("@Archived", 0)
                Else
                    sql(5) = New SqlParameter("@Archived", 0)
                End If
            End If

            sql(6) = New SqlParameter("@History_ID", ID)
            sql(7) = New SqlParameter("@Action_Status", drpActionStatus.SelectedItem.Text)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_UPDATE", sql).ToString()
        End If
        If drpActionAgendaType.SelectedValue = "Franchise" Then
            Dim sql As SqlParameter() = New SqlParameter(7) {}
            sql(0) = New SqlParameter("@Franchise_Status", Convert.ToInt32(drpStatus.SelectedValue))
            sql(1) = New SqlParameter("@Franchise_ID", Convert.ToInt32(hdnFranchiseId.Value))
            If txtActionDate.Text = "" Then
                sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
            Else
                sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
            End If
            sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
            sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
            Dim strSelectedDate As DateTime = Convert.ToDateTime(txtActionDate.Text)
            Dim strTodayDate As DateTime = Convert.ToDateTime(DateTime.Now.ToString())

            If strSelectedDate.Day = strTodayDate.Day And strSelectedDate.Month = strTodayDate.Month And strSelectedDate.Year = strTodayDate.Year Then
                sql(5) = New SqlParameter("@Archived", 0)
            Else
                If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
                    sql(5) = New SqlParameter("@Archived", 1)
                Else
                    sql(5) = New SqlParameter("@Archived", 0)
                End If
            End If

            sql(6) = New SqlParameter("@History_ID", ID)
            sql(7) = New SqlParameter("@Action_Status", drpActionStatus.SelectedItem.Text)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_UPDATE", sql).ToString()

        End If

        If drpActionAgendaType.SelectedValue = "Partner" Then
            Dim sql As SqlParameter() = New SqlParameter(7) {}
            sql(0) = New SqlParameter("@Partner_Status", Convert.ToInt32(drpStatus.SelectedValue))
            sql(1) = New SqlParameter("@Partner_ID", Convert.ToInt32(hdnFranchiseId.Value))
            If txtActionDate.Text = "" Then
                sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
            Else
                sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
            End If
            sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
            sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
            Dim strSelectedDate As DateTime = Convert.ToDateTime(txtActionDate.Text)
            Dim strTodayDate As DateTime = Convert.ToDateTime(DateTime.Now.ToString())

            If strSelectedDate.Day = strTodayDate.Day And strSelectedDate.Month = strTodayDate.Month And strSelectedDate.Year = strTodayDate.Year Then
                sql(5) = New SqlParameter("@Archived", 0)
            Else
                If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
                    sql(5) = New SqlParameter("@Archived", 1)
                Else
                    sql(5) = New SqlParameter("@Archived", 0)
                End If
            End If

            sql(6) = New SqlParameter("@History_ID", ID)
            sql(7) = New SqlParameter("@Action_Status", drpActionStatus.SelectedItem.Text)

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Partner_HISTORY_UPDATE", sql).ToString()

        End If

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "changeDateControl(); alert('Record has been updated successfully !');", True)
        BindAction(drpActionAgendaType.SelectedValue)

        'Response.Redirect("Dashboard_Action_Agenda.aspx?Type=" + drpActionAgendaType.SelectedValue)

        Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
        CBuyer.Load(Convert.ToInt32(hdnBuyerId.Value))
        Session("AdminBuyerSelected") = CBuyer
        Response.Redirect("BuyerActionAgenda.aspx")

    End Sub
    Protected Sub btnSaveNo_Click(sender As Object, e As EventArgs)
        ID = Convert.ToInt32(Request.QueryString(0))

        If drpActionAgendaType.SelectedValue = "Buyer" Then
            Dim sql As SqlParameter() = New SqlParameter(8) {}
            sql(0) = New SqlParameter("@Buyer_Status", Convert.ToInt32(drpStatus.SelectedValue))
            sql(1) = New SqlParameter("@Buyer_ID", Convert.ToInt32(hdnBuyerId.Value))
            If txtActionDate.Text = "" Then
                sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
            Else
                sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
            End If
            sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
            sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
            Dim strSelectedDate As DateTime = Convert.ToDateTime(txtActionDate.Text)
            Dim strTodayDate As DateTime = Convert.ToDateTime(DateTime.Now.ToString())

            If strSelectedDate.Day = strTodayDate.Day And strSelectedDate.Month = strTodayDate.Month And strSelectedDate.Year = strTodayDate.Year Then
                sql(5) = New SqlParameter("@Archived", 0)
            Else
                If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
                    sql(5) = New SqlParameter("@Archived", 0)
                Else
                    sql(5) = New SqlParameter("@Archived", 0)
                End If
            End If

            sql(6) = New SqlParameter("@History_ID", ID)
            sql(7) = New SqlParameter("@Action_Status", drpActionStatus.SelectedItem.Text)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_UPDATE", sql).ToString()
        End If
        If drpActionAgendaType.SelectedValue = "Franchise" Then
            Dim sql As SqlParameter() = New SqlParameter(7) {}
            sql(0) = New SqlParameter("@Franchise_Status", Convert.ToInt32(drpStatus.SelectedValue))
            sql(1) = New SqlParameter("@Franchise_ID", Convert.ToInt32(hdnFranchiseId.Value))
            If txtActionDate.Text = "" Then
                sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
            Else
                sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
            End If
            sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
            sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
            Dim strSelectedDate As DateTime = Convert.ToDateTime(txtActionDate.Text)
            Dim strTodayDate As DateTime = Convert.ToDateTime(DateTime.Now.ToString())

            If strSelectedDate.Day = strTodayDate.Day And strSelectedDate.Month = strTodayDate.Month And strSelectedDate.Year = strTodayDate.Year Then
                sql(5) = New SqlParameter("@Archived", 0)
            Else
                If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
                    sql(5) = New SqlParameter("@Archived", 1)
                Else
                    sql(5) = New SqlParameter("@Archived", 0)
                End If
            End If

            sql(6) = New SqlParameter("@History_ID", ID)
            sql(7) = New SqlParameter("@Action_Status", drpActionStatus.SelectedItem.Text)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_HISTORY_UPDATE", sql).ToString()

        End If

        If drpActionAgendaType.SelectedValue = "Partner" Then
            Dim sql As SqlParameter() = New SqlParameter(7) {}
            sql(0) = New SqlParameter("@Partner_Status", Convert.ToInt32(drpStatus.SelectedValue))
            sql(1) = New SqlParameter("@Partner_ID", Convert.ToInt32(hdnFranchiseId.Value))
            If txtActionDate.Text = "" Then
                sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
            Else
                sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
            End If
            sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
            sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
            Dim strSelectedDate As DateTime = Convert.ToDateTime(txtActionDate.Text)
            Dim strTodayDate As DateTime = Convert.ToDateTime(DateTime.Now.ToString())

            If strSelectedDate.Day = strTodayDate.Day And strSelectedDate.Month = strTodayDate.Month And strSelectedDate.Year = strTodayDate.Year Then
                sql(5) = New SqlParameter("@Archived", 0)
            Else
                If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
                    sql(5) = New SqlParameter("@Archived", 1)
                Else
                    sql(5) = New SqlParameter("@Archived", 0)
                End If
            End If

            sql(6) = New SqlParameter("@History_ID", ID)
            sql(7) = New SqlParameter("@Action_Status", drpActionStatus.SelectedItem.Text)

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Partner_HISTORY_UPDATE", sql).ToString()

        End If

        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "changeDateControl(); alert('Record has been updated successfully !');", True)
        BindAction(drpActionAgendaType.SelectedValue)

        Response.Redirect("Dashboard_Action_Agenda.aspx?Type=" + drpActionAgendaType.SelectedValue)
    End Sub
End Class
