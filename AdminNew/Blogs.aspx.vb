﻿
Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares

Partial Class AdminNew_Blogs
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
        'Dim sqlSearch As SqlParameter() = New SqlParameter(4) {}
        'sqlSearch(0) = New SqlParameter("@Name", txtname.Text)
        'sqlSearch(1) = New SqlParameter("@propRef", (txtprop.Text).ToUpper)
        'sqlSearch(2) = New SqlParameter("@Included", chkarchived.Checked)
        'sqlSearch(3) = New SqlParameter("@TypeId", 4)
        'Dim CDataAccess As New ClassDataAccess

        ' Assign Results to Session Variable
        ' Dim dt As DataTable = CDataAccess.ContactSearch(Convert.ToInt32(Session("AdminContactSearchTypeID")), txtname.Text.Trim, Convert.ToInt32(Session("ContactPartnerID")), txtprop.Text.Trim, chkarchived.Checked)

        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblBlogs_Showall").Tables(0)
        If dt.Rows.Count > 0 Then
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
        If e.CommandName = "editblog" Then
            Response.Redirect("AddBlog.aspx?BlogId=" + e.CommandArgument.ToString())
        End If

        'If e.CommandName = "viewproperty" Then
        '    Response.Redirect("viewproperty.aspx?ContactId=" + e.CommandArgument.ToString())
        'End If


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
                    sql(0) = New SqlParameter("@BlogId", ID)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblBlogs_Delete", sql)
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
        '}
    End Sub




    Protected Sub imgsearch_Click1(sender As Object, e As EventArgs)
        bindadmin()

    End Sub
End Class
