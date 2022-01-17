Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Partial Class Admin_ReAllocation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            'Bind SalesPerson From & SalesPerson To Dropdowns
            bindusers()
        End If
    End Sub

    Private Sub bindusers()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Show_Users_Without_Archived_All").Tables(0)
        If dt.Rows.Count > 0 Then
            drpSalesPersonFrom.DataSource = dt
            drpSalesPersonFrom.DataTextField = "Contact_Name"
            drpSalesPersonFrom.DataValueField = "Contact_Id"
            drpSalesPersonFrom.DataBind()
            Dim lisalespersonFrom As New ListItem("-- Select --", "0")
            drpSalesPersonFrom.Items.Insert(0, lisalespersonFrom)

            drpSalesPersonTo.DataSource = dt
            drpSalesPersonTo.DataTextField = "Contact_Name"
            drpSalesPersonTo.DataValueField = "Contact_Id"
            drpSalesPersonTo.DataBind()
            Dim lisalespersonTo As New ListItem("-- Select --", "0")
            drpSalesPersonTo.Items.Insert(0, lisalespersonTo)
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        If drpSalesPersonFrom.SelectedValue = drpSalesPersonTo.SelectedValue Then
            Page.RegisterStartupScript("script", "<script language='javascript'>alert('SalesPerson From & SalesPerson To can not be same, please select different values !');</script>")
        Else
            Dim sql As SqlParameter() = New SqlParameter(4) {}
            sql(0) = New SqlParameter("@SalesPersonFrom", Convert.ToInt32(drpSalesPersonFrom.SelectedItem.Value))
            sql(1) = New SqlParameter("@SalesPersonTo", Convert.ToInt32(drpSalesPersonTo.SelectedItem.Value))
            sql(2) = New SqlParameter("@NoOfRecords", Convert.ToInt32(txtNumberOfRecords.Text))
            sql(3) = New SqlParameter("@OrderBy", drpOrderBy.SelectedItem.Value)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Do_ReAllocation", sql)
            Page.RegisterStartupScript("script", "<script language='javascript'>alert('Re Allocation Been Successfully Done ! ');</script>")
            drpSalesPersonFrom.SelectedValue = 0
            drpSalesPersonTo.SelectedValue = 0
            txtNumberOfRecords.Text = ""
            drpOrderBy.SelectedValue = "desc"
            lblSalesPersonFromTotalClient.Text = ""
            lblSalesPersonToTotalClient.Text = ""
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("ReAllocation.aspx")
    End Sub

    Protected Sub drpSalesPersonFrom_SelectedIndexChanged(sender As Object, e As EventArgs)
        If drpSalesPersonFrom.SelectedValue = "0" Then
            lblSalesPersonFromTotalClient.Text = "0"
        Else
            Dim dtTotalClients As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, "select count(*) 'TotalClients' from buyer where Buyer_Salesperson_Id=" + drpSalesPersonFrom.SelectedItem.Value + "").Tables(0)
            If dtTotalClients.Rows.Count > 0 Then
                lblSalesPersonFromTotalClient.Text = dtTotalClients.Rows(0)("TotalClients").ToString()
            Else
                lblSalesPersonFromTotalClient.Text = "0"
            End If
        End If

    End Sub

    Protected Sub drpSalesPersonTo_SelectedIndexChanged(sender As Object, e As EventArgs)
        If drpSalesPersonTo.SelectedValue = "0" Then
            lblSalesPersonToTotalClient.Text = "0"
        Else
            Dim dtTotalClients As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, "select count(*) 'TotalClients' from buyer where Buyer_Salesperson_Id=" + drpSalesPersonTo.SelectedItem.Value + "").Tables(0)
            If dtTotalClients.Rows.Count > 0 Then
                lblSalesPersonToTotalClient.Text = dtTotalClients.Rows(0)("TotalClients").ToString()
            Else
                lblSalesPersonToTotalClient.Text = "0"
            End If
        End If
    End Sub
End Class
