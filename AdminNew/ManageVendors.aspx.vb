Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Reflection

Partial Class Admin_ManageVendors
    Inherits System.Web.UI.Page
    Dim redval As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        If Not IsPostBack Then
            If Not Request.QueryString("PageIndex") Is Nothing Then
                'Dim script As String = "window.onload = function() { postclick('" & Request.QueryString("PageIndex") & "'); };"
                'ClientScript.RegisterStartupScript(Me.GetType(), "UpdateTime", script, True)
                txtname.Text = Request.QueryString("name").ToString()
                txtprop.Text = Request.QueryString("propref").ToString()
                chkarchived.Checked = Request.QueryString("Included").ToString()
            End If

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
        '    grdAdmin.DataSource = dt
        '    grdAdmin.DataBind()
        '    BtnDelete.Visible = False
        '    lblmessage.Visible = True
        'End If


        Dim sqlSearch As SqlParameter() = New SqlParameter(5) {}
        sqlSearch(0) = New SqlParameter("@Name", txtname.Text)
        sqlSearch(1) = New SqlParameter("@propRef", (txtprop.Text).ToUpper)
        sqlSearch(2) = New SqlParameter("@Included", chkarchived.Checked)
        sqlSearch(3) = New SqlParameter("@TypeId", 5)
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
            If Not redval = 1 Then
                If Not Request.QueryString("PageIndex") Is Nothing Then

                    grdAdmin.PageIndex = Convert.ToInt32(Request.QueryString("PageIndex")) - 1
                End If
            End If
           
            grdAdmin.DataSource = dt
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
        If e.CommandName = "editadmin" Then
            Dim pg As String
            If grdAdmin.PageIndex = 0 Then
                pg = 1
            Else
                pg = Convert.ToString(grdAdmin.PageIndex) + 1
            End If
            Response.Redirect("AddVendor.aspx?ContactId=" + e.CommandArgument.ToString() + "&PageIndex=" + pg + "&Name=" + txtname.Text + "&propref=" + txtprop.Text + "&Included=" + chkarchived.Checked.ToString())
        End If

        If e.CommandName = "viewproperty" Then
            Response.Redirect("viewproperty.aspx?ContactId=" + e.CommandArgument.ToString())
        End If


    End Sub
    Protected Sub grdAdmin_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

        If Request.QueryString.HasKeys() Then

            Dim isreadonly As PropertyInfo = GetType(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance Or BindingFlags.NonPublic)
            ' make collection editable
            isreadonly.SetValue(Me.Request.QueryString, False, Nothing)
            ' remove
            Me.Request.QueryString.Remove("Id")
        End If
        grdAdmin.PageIndex = e.NewPageIndex

        redval = 1
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
                    sql(0) = New SqlParameter("@Contact_ID", ID)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Vendor_Delete_ById", sql)
                    Page.RegisterStartupScript("script", "<script language='javascript'>alert('Record has been sucessfully removed !');</script>")
                End If
            End If
        Next

        bindadmin()
    End Sub




    Protected Sub grdAdmin_RowDataBound1(sender As Object, e As GridViewRowEventArgs)
        'if (e.Row.RowType == DataControlRowType.Header)
        '{
        '    ((CheckBox)e.Row.FindControl("cbSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" +
        '        ((CheckBox)e.Row.FindControl("cbSelectAll")).ClientID + "')");
        '} Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' determine the value of the UnitsInStock field
            Dim lsDataKeyValue As String = grdAdmin.DataKeys(e.Row.RowIndex).Values(0).ToString()
            ' Dim CategoryID As Integer = Convert.ToInt32(DataBinder.Eval(e.Row., "contact_id"))
            If lsDataKeyValue = Request.QueryString("Id") Then
                ' color the background of the row yellow
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9CF06")


                ' ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "EditModalScript", script.ToString(), False)
            End If
        End If
    End Sub




    Protected Sub imgsearch_Click1(sender As Object, e As EventArgs)
        bindadmin()

    End Sub
End Class
