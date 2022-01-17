Imports Microsoft.VisualBasic
Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Public Class Admin_NoHistory
    Inherits System.Web.UI.Page

    Public Event BuyerSelected()
    Dim redval As Integer = 0
    Dim pg As String = String.Empty
    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        ' Perform Search
        bindgrid()
    End Sub
    Private Sub bindusers()
        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)
        Dim dt As DataTable
        If Convert.ToInt32(Session("AdminUser")) = 0 Then
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Show_Users_By_ContactPartnerId", sql).Tables(0)
        Else
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Show_Users").Tables(0)
        End If
        If dt.Rows.Count > 0 Then
            drpUser.DataSource = dt
            drpUser.DataTextField = "Contact_Name"
            drpUser.DataValueField = "Contact_Id"
            drpUser.DataBind()
            Dim licategory1 As New ListItem("--Salesperson--", "")
            drpUser.Items.Insert(0, licategory1)
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        ' Set Focus
        TextBoxFirstName.Focus()
        If Not IsPostBack Then
            binduserstatus()
            bindusers()
            If Not Request.QueryString("PageIndex") Is Nothing Then
                TextBoxFirstName.Text = Request.QueryString("Firstname").ToString()
                txtlastname.Text = Request.QueryString("lastname").ToString()
                CheckBoxIncludeArchived.Checked = Request.QueryString("Included").ToString()
                txtBuyeremail.Text = Request.QueryString("Email").ToString()
                txtdatecreated.Text = Request.QueryString("date").ToString()
                drpUser.SelectedValue = Request.QueryString("salesperson").ToString()
                DropDownListSource.SelectedValue = Request.QueryString("source").ToString()
                DropDownListStatus.SelectedValue = Request.QueryString("status").ToString()
            End If
            bindgrid()
        End If
    End Sub

    Private Sub binduserstatus()
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        ' Source
        CUtilities.PopulateDropDownList(DropDownListSource, CDataAccess.BuyerSource)
        '     DropDownListSource.Items.Insert(0, "--- Source ---")
        Dim licategory1 As New ListItem("--Source--", "")
        DropDownListSource.Items.Insert(0, licategory1)
        ' Status
        CUtilities.PopulateDropDownList(DropDownListStatus, CDataAccess.BuyerStatus)
        ' DropDownListStatus.Items.Insert(0, "--- Status ---")
        Dim licategory2 As New ListItem("--Status--", "")
        DropDownListStatus.Items.Insert(0, licategory2)
    End Sub

    Private Sub ApplyStyling()
        ' If we have a Header Row
        'If Not GridViewResultsClient.HeaderRow Is Nothing Then

        '    ' Hide the ID & Archived Column Headings
        '    GridViewResultsClient.HeaderRow.Cells(1).Visible = False
        '    GridViewResultsClient.HeaderRow.Cells(2).Visible = False

        '    ' For each Row
        '    For Each gvr As GridViewRow In GridViewResultsClient.Rows

        '        ' Hide ID and Archived Cells
        '        gvr.Cells(1).Visible = False
        '        gvr.Cells(2).Visible = False

        '        ' If this Client is Archived
        '        If DirectCast(gvr.Cells(2).Controls(0), CheckBox).Checked Then

        '            ' Apply Styling
        '            gvr.BackColor = Drawing.Color.Gray

        '        End If

        '    Next

        'End If

        ' Set Visibility
        TableRowNoResults.Visible = GridViewResultsClient.Rows.Count < 1
        ' TableRowResults.Visible = Not TableRowNoResults.Visible

    End Sub
    Public Sub Reload()
        ' Reload Values
        LoadControlValues(Me)
        ' Apply Styling
        ApplyStyling()
    End Sub
    Private Sub bindgrid()
        Dim CDataAccess As New ClassDataAccess
        If Not redval = 1 Then
            If Not Request.QueryString("PageIndex") Is Nothing Then
                GridViewResultsClient.PageIndex = Convert.ToInt32(Request.QueryString("PageIndex")) - 1
            End If
        End If

        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If

        Dim sql As SqlParameter() = New SqlParameter(9) {}
        sql(0) = New SqlParameter("@szFirstName", TextBoxFirstName.Text.Trim)
        sql(1) = New SqlParameter("@szLastName", txtlastname.Text.Trim)
        sql(2) = New SqlParameter("@Email", txtBuyeremail.Text.Trim)
        sql(3) = New SqlParameter("@bIncludeArchived", Convert.ToBoolean(CheckBoxIncludeArchived.Checked))
        sql(4) = New SqlParameter("@DateCeated", txtdatecreated.Text)
        sql(5) = New SqlParameter("@Salesperson", drpUser.SelectedValue)
        sql(6) = New SqlParameter("@Source", DropDownListSource.SelectedValue)
        sql(7) = New SqlParameter("@Status", DropDownListStatus.SelectedValue)
        sql(8) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)

        Dim dt As DataTable
        If Convert.ToInt32(Session("AdminUser")) = 0 Then
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Client_With_NoHistory_By_Partner_Id", sql).Tables(0)
        Else
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Client_With_NoHistory_Without_Partner_Id", sql).Tables(0)
        End If

        Dim dvclientproperties As DataView = dt.DefaultView

        ' set the sort column and sort order. 
        If ViewState("SortExpressionCP") Is Nothing Then
            ViewState("SortExpressionCP") = "Name Asc"
        End If
        dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()
        GridViewResultsClient.DataSource = dvclientproperties
        GridViewResultsClient.DataBind()
        If dt.Rows.Count > 0 Then
            TableRowNoResults.Visible = False
        Else
            TableRowNoResults.Visible = True
        End If
        CDataAccess = Nothing
        ' Apply Styling
        ApplyStyling()
    End Sub
    Protected Sub GridViewResultsClient_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridViewResultsClient.PageIndex = e.NewPageIndex
        redval = 1
        bindgrid()
    End Sub
    Protected Sub GridViewResultsClient_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' determine the value of the UnitsInStock field
            Dim lsDataKeyValue As String = GridViewResultsClient.DataKeys(e.Row.RowIndex).Values(0).ToString()
            ' Dim CategoryID As Integer = Convert.ToInt32(DataBinder.Eval(e.Row., "contact_id"))
            If lsDataKeyValue = Request.QueryString("Id") Then
                ' color the background of the row yellow
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9CF06")
                ' ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "EditModalScript", script.ToString(), False)
            End If
        End If
    End Sub
    Protected Sub GridViewResultsClient_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editadmin" Then
            pg = Convert.ToString(GridViewResultsClient.PageIndex) + 1
            Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
            ' Load this Property's Details
            Dim CDataAccess As New ClassDataAccess
            CBuyer.Load(Convert.ToInt32(e.CommandArgument))
            CDataAccess = Nothing
            ' Assign to Session Variable
            Session("AdminBuyerSelected") = CBuyer
            ' Raise Event
            '  RaiseEvent BuyerSelected()
            Response.Redirect("Client.aspx?ID=" + e.CommandArgument + "&PageIndex=" + pg + "&Firstname=" + TextBoxFirstName.Text + "&lastname=" + txtlastname.Text + "&Included=" + CheckBoxIncludeArchived.Checked.ToString() + "&Email=" + txtBuyeremail.Text.ToString() + "&date=" + txtdatecreated.Text.ToString() + "&salesperson=" + drpUser.SelectedValue.ToString() + "&source=" + DropDownListSource.SelectedValue.ToString() + "&status=" + DropDownListStatus.SelectedValue.ToString())
        End If
    End Sub
    Protected Sub GridViewResultsClient_Sorting(sender As Object, e As GridViewSortEventArgs)
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
        bindgrid()
    End Sub
End Class
