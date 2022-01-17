Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO

Partial Class FranchiseRequests
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            'Bind Source
            ' Source
            CUtilities.PopulateDropDownList(drpSource, CDataAccess.BuyerSource)
            Dim liSource As New ListItem
            liSource.Value = "0"
            liSource.Text = "--- Source ---"
            drpSource.Items.Insert(0, liSource)
            BindFranchiseStatus()
            bindadmin()
        End If
    End Sub
    Public Sub BindFranchiseStatus()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Franchise_STATUS_SELECT").Tables(0)
        If dt.Rows.Count > 0 Then
            drpStatus.DataSource = dt
            drpStatus.DataTextField = "Name"
            drpStatus.DataValueField = "Franchise_Status_Id"
            drpStatus.DataBind()
            Dim liStatus As New ListItem
            liStatus.Value = "0"
            liStatus.Text = "--- Current Status ---"
            drpStatus.Items.Insert(0, liStatus)
        End If
    End Sub
    Private Sub bindadmin()
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@Contact_Name", txtContactName.Text)
        sql(1) = New SqlParameter("@Status", Convert.ToInt32(drpStatus.SelectedValue))
        sql(2) = New SqlParameter("@Source", Convert.ToInt32(drpSource.SelectedValue))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblFranchiseRequests_Select", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dvFranchiseRequests As DataView = dt.DefaultView
            ' set the sort column and sort order. 
            If ViewState("SortExpressionCP") Is Nothing Then
                ViewState("SortExpressionCP") = "Contact_Name Asc"
            End If
            dvFranchiseRequests.Sort = ViewState("SortExpressionCP").ToString()
            grdAdmin.DataSource = dvFranchiseRequests
            'grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            lblmessage.Visible = False
            BtnDelete.Visible = True
        Else
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            lblmessage.Visible = True
            BtnDelete.Visible = False
        End If
    End Sub
    Protected Sub grdAdmin_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editfranchise" Then
            Response.Redirect("AddPartner.aspx?ContactId=" + e.CommandArgument.ToString())
        End If
        If e.CommandName = "IsFranchise" Then
            Dim sqlUpdateStatus As SqlParameter() = New SqlParameter(2) {}
            sqlUpdateStatus(0) = New SqlParameter("@Contact_Id", Convert.ToInt32(e.CommandArgument.ToString()))
            Dim imgCurrentButton As ImageButton = e.CommandSource
            If imgCurrentButton.ImageUrl.Contains("tick-mark.png") Then
                sqlUpdateStatus(1) = New SqlParameter("@IsActive", Convert.ToChar("0"))
            Else
                sqlUpdateStatus(1) = New SqlParameter("@IsActive", Convert.ToChar("1"))
            End If
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Update_Status", sqlUpdateStatus)
        End If
        bindadmin()
    End Sub
    Protected Sub grdAdmin_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdAdmin.PageIndex = e.NewPageIndex
        bindadmin()
    End Sub
    Protected Sub BtnDelete_Click(sender As Object, e As EventArgs)
        Dim ID As Int32
        For i As Int32 = 0 To grdAdmin.Rows.Count - 1
            Dim chkClient As CheckBox = DirectCast(grdAdmin.Rows(i).FindControl("chkSelect"), CheckBox)
            If chkClient.Checked <> True Then
            Else
                If Convert.ToInt32(Session("AdminID")) <> Convert.ToInt32(grdAdmin.DataKeys(i)(0)) Then
                    ID = Convert.ToInt32(grdAdmin.DataKeys(i)(0))
                    Dim sql As SqlParameter() = New SqlParameter(0) {}
                    sql(0) = New SqlParameter("@Contact_Id", ID)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Delete", sql)
                    Page.RegisterStartupScript("script", "<script language='javascript'>alert('Record has been sucessfully removed !');</script>")
                End If
            End If
        Next
        bindadmin()
    End Sub
    Protected Sub grdAdmin_RowDataBound1(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
        End If
        'If (e.Row.RowType == DataControlRowType.Header) Then
        '            {
        '    ((CheckBox)e.Row.FindControl("cbSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" +
        '        ((CheckBox)e.Row.FindControl("cbSelectAll")).ClientID + "')");
        '}
    End Sub
    Protected Sub btnSendMessage_Click(sender As Object, e As EventArgs)
        Dim sql As SqlParameter() = New SqlParameter(6) {}
        sql(0) = New SqlParameter("@Contact_Name", txtFirstName.Text & " " & txtLastName.Text)
        sql(1) = New SqlParameter("@Contact_Address", txtAddress.Text)
        sql(2) = New SqlParameter("@Contact_Telephone", txtTelephone.Text)
        sql(3) = New SqlParameter("@Contact_Email", txtEmail.Text)
        sql(4) = New SqlParameter("@Contact_Notes", txtComment.Text)
        sql(5) = New SqlParameter("@Contact_Id_From", Convert.ToInt32(Session("ContactID")))
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Insert_FranchiseRequest", sql)
        bindadmin()
        divAddFranchiseRequest.Visible = False
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtAddress.Text = ""
        txtTelephone.Text = ""
        txtEmail.Text = ""
        txtComment.Text = ""
    End Sub
    Protected Sub btnAddFranchise_Click(sender As Object, e As EventArgs)
        'Page.RegisterStartupScript("script", "<script language='javascript'>document.getElementById('divAddFranchiseRequest').style.display='block';</script>")
        divAddFranchiseRequest.Visible = True
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        divAddFranchiseRequest.Visible = False
    End Sub
    Protected Sub imgsearch_Click(sender As Object, e As EventArgs)
        bindadmin()
    End Sub
    Protected Sub grdAdmin_Sorting(sender As Object, e As GridViewSortEventArgs)
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
        bindadmin()
    End Sub
End Class
