Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO

Partial Class ManagePartner
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If True Then
            If Not IsPostBack Then
                bindmagazine()
            End If
        End If
    End Sub
    Private Sub bindmagazine()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblOnlineMagazine_Select_All_Active").Tables(0)
        If dt.Rows.Count > 0 Then
            grdmagazine.DataSource = dt
            grdmagazine.DataBind()
            lblmessage.Visible = False
            BtnDelete.Visible = True
        Else
            grdmagazine.DataSource = dt
            grdmagazine.DataBind()
            lblmessage.Visible = True
            BtnDelete.Visible = False
        End If
    End Sub

    Protected Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim ID As Int32
        For i As Int32 = 0 To grdmagazine.Rows.Count - 1
            Dim chkClient As CheckBox = DirectCast(grdmagazine.Rows(i).FindControl("chkSelect"), CheckBox)

            If chkClient.Checked <> True Then
            Else
                If Convert.ToInt32(Session("MId")) <> Convert.ToInt32(grdmagazine.DataKeys(i)(0)) Then
                    ID = Convert.ToInt32(grdmagazine.DataKeys(i)(0))
                    Dim sql As SqlParameter() = New SqlParameter(0) {}
                    sql(0) = New SqlParameter("@MId", ID)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_delete_tblOnlineMagazine", sql)
                    Page.RegisterStartupScript("script", "<script language='javascript'>alert('Record has been sucessfully removed !');</script>")
                End If
            End If
        Next

        bindmagazine()
    End Sub


    Protected Sub grdmagazine_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdmagazine.PageIndexChanging
        grdmagazine.PageIndex = e.NewPageIndex


        bindmagazine()
    End Sub

    Protected Sub grdmagazine_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editmagazine" Then
            Response.Redirect("OnlineMagazineAddEdit.aspx?MId=" + e.CommandArgument.ToString())
        End If
        If e.CommandName.ToString() = "changestatus" Then
            Dim grow As GridViewRow = DirectCast(DirectCast(e.CommandSource, ImageButton).NamingContainer, GridViewRow)
            Dim img As ImageButton = TryCast(e.CommandSource, ImageButton)
            Dim gvRow As GridViewRow = TryCast(img.Parent.Parent, GridViewRow)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            Dim imgStatus As ImageButton = DirectCast(grdmagazine.Rows(gvRow.RowIndex).FindControl("imgBtnStatus"), ImageButton)
            Dim sql As SqlParameter() = New SqlParameter(2) {}
            If imgStatus.ImageUrl.Contains("notavailable.png") Then
                sql(0) = New SqlParameter("@MId", id)
                sql(1) = New SqlParameter("@IsActive", True)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblOnlineMagazine_Update_Status", sql)
                bindmagazine()
            Else
                sql(0) = New SqlParameter("@MId", id)
                sql(1) = New SqlParameter("@IsActive", False)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblOnlineMagazine_Update_Status", sql)
                bindmagazine()
            End If
        End If



    End Sub
End Class
