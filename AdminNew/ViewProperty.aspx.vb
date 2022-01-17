Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO

Partial Class Admin_ManageVendors
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        If Not IsPostBack Then
            If Request.QueryString.HasKeys() Then
                bindadmin()
            End If

        End If
    End Sub
    Private Sub bindadmin()
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@VendorId", Request.QueryString("ContactId").ToString())
        sql(1) = New SqlParameter("@nPartnerID", Convert.ToInt32(Session("ContactPartnerID")))

        Dim CDataAccess As New ClassDataAccess
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Vendor_Properties", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()


            lblmessage.Visible = False
        Else
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()

            lblmessage.Visible = True
        End If
    End Sub

    Protected Sub grdAdmin_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editadmin" Then
            Response.Redirect("AddProperty.aspx?PropertyId=" + e.CommandArgument.ToString())
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

    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================

    Protected Sub btnimageprop_Click(sender As Object, e As EventArgs)
        Response.Redirect("AddProperty.aspx")
    End Sub
End Class
