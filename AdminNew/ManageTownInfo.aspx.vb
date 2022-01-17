
Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares

Partial Class AdminNew_ManageTownInfo
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
        Dim dt As DataTable
        If drpRegions.SelectedValue = 0 Then
            Dim sql As SqlParameter() = New SqlParameter(0) {}
            sql(0) = New SqlParameter("@IncludePropertySearchPages", chkIncludePropertySearchPages.Checked)
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_SelectAll", sql).Tables(0)
        Else
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@Region_Id", drpRegions.SelectedValue)
            sql(1) = New SqlParameter("@IncludePropertySearchPages", chkIncludePropertySearchPages.Checked)
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Select_By_Region_ID_ForAdmin", sql).Tables(0)
        End If
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
            Response.Redirect("AddTownInfo.aspx?PageId=" + e.CommandArgument.ToString())
        End If
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
                    sql(0) = New SqlParameter("@PageId", ID)
                    Dim areaName As String = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Delete_By_PageId", sql).Tables(0).Rows(0)("Area_Name").ToString()
                    Page.RegisterStartupScript("script", "<script language='javascript'>alert('Record has been sucessfully removed !');</script>")
                    'Now delete complete folder from townguide images folder
                    Dim folderPath As String = "/images/townguide/" & areaName.ToLower().Replace(" ", "-")
                    System.IO.Directory.Delete(Server.MapPath(folderPath))
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
    Protected Sub drpRegions_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindadmin()
    End Sub
    Protected Sub chkIncludePropertySearchPages_CheckedChanged(sender As Object, e As EventArgs)
        bindadmin()
    End Sub
End Class
