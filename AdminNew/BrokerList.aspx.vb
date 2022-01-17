Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO

Partial Class BrokerList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        If Not IsPostBack Then

            bindadmin()
        End If
    End Sub
    Private Sub bindadmin()

        'Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Vendor_ShowAll").Tables(0)
        'If dt.Rows.Count > 0 Then
        '    grdAdmin.DataSource = dt
        '    grdAdmin.DataBind()
        '    BtnDelete.Visible = True

        '    lblmessage.Visible = False
        'Else
        '    grdAdmin.DataSource = dtbindadmin
        '    grdAdmin.DataBind()
        '    BtnDelete.Visible = False
        '    lblmessage.Visible = True
        'End If
        Dim sqlSearch As SqlParameter() = New SqlParameter(5) {}
        sqlSearch(0) = New SqlParameter("@Name", txtname.Text)
        sqlSearch(1) = New SqlParameter("@propRef", (txtprop.Text).ToUpper)
        sqlSearch(2) = New SqlParameter("@Included", chkarchived.Checked)
        sqlSearch(3) = New SqlParameter("@TypeId", 6)
        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If
        sqlSearch(4) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)

        Dim CDataAccess As New ClassDataAccess
        Dim procedure As String = "USP_Select_VendorORBroker_By_AdminUser"
        If Convert.ToInt32(Session("AdminUser")) = 0 Then
            procedure = "USP_ContactVendor_Select_By_ParamNew01"
        End If
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, procedure, sqlSearch).Tables(0)
        If dt.Rows.Count > 0 Then
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            lblmessage.Visible = False
            ''  BtnDelete.Visible = True
        Else
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            lblmessage.Visible = True
            ''    BtnDelete.Visible = False
        End If

    End Sub

    Protected Sub grdAdmin_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editadmin" Then
            Response.Redirect("AddBroker.aspx?ContactId=" + e.CommandArgument.ToString())
        End If

        If e.CommandName = "viewproperty" Then
            Response.Redirect("viewproperty.aspx?ContactId=" + e.CommandArgument.ToString())
        End If


    End Sub
    Protected Sub grdAdmin_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdAdmin.PageIndex = e.NewPageIndex


        bindadmin()
    End Sub



    Protected Sub grdAdmin_RowDataBound1(sender As Object, e As GridViewRowEventArgs)
        'if (e.Row.RowType == DataControlRowType.Header)
        '{
        '    ((CheckBox)e.Row.FindControl("cbSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" +
        '        ((CheckBox)e.Row.FindControl("cbSelectAll")).ClientID + "')");
        '}
    End Sub




    Protected Sub imgsearch_Click1(sender As Object, e As EventArgs)
        bindadmin()

    End Sub
End Class
