Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Partial Class BuyerCriterias
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            If Not Session("AdminBuyerSelected") Is Nothing Then
                If Request.QueryString.HasKeys() Then
                    ID = Convert.ToInt32(Request.QueryString(0))
                    hdcont.Value = ID
                    hdpageind.Value = Request.QueryString("PageIndex")
                End If
                If Not Request.UrlReferrer Is Nothing Then
                    Dim url As String = Request.UrlReferrer.ToString()
                    Dim uri = New Uri(url)
                    Dim qs = HttpUtility.ParseQueryString(uri.Query)
                    If url.Contains("ClientSearch.aspx") Then
                        qs.[Set]("ID", ID)
                        qs.[Set]("PageIndex", hdpageind.Value)
                        qs.[Set]("Firstname", Request.QueryString("Firstname"))
                        qs.[Set]("lastname", Request.QueryString("lastname"))
                        qs.[Set]("Included", Request.QueryString("Included"))
                        qs.[Set]("Email", Request.QueryString("Email"))
                        qs.[Set]("date", Request.QueryString("date"))
                        qs.[Set]("salesperson", Request.QueryString("salesperson"))
                        qs.[Set]("source", Request.QueryString("source"))
                        qs.[Set]("status", Request.QueryString("status"))
                    End If
                    Dim uriBuilder = New UriBuilder(uri)
                    uriBuilder.Query = qs.ToString()
                    Dim newUri = uriBuilder.Uri
                    hdnprevurl.Value = newUri.ToString()
                End If
            End If
            BindCriterias()
            BindBuyerCriterias()
        End If
    End Sub
    Public Sub BindCriterias()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Criterias_Select_All").Tables(0)
        chklstBuyerCriterias.DataSource = dt
        chklstBuyerCriterias.DataTextField = "Criteria"
        chklstBuyerCriterias.DataValueField = "Criteria_ID"
        chklstBuyerCriterias.DataBind()
    End Sub
    Public Sub BindBuyerCriterias()
        Dim sqlbuyerdetails As SqlParameter() = New SqlParameter(0) {}
        sqlbuyerdetails(0) = New SqlParameter("@Buyer_Id", Convert.ToInt32(Request.QueryString("BuyerID")))
        Dim dtbuyerdetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Criterias_Select_By_BuyerID", sqlbuyerdetails).Tables(0)
        If dtbuyerdetails.Rows.Count > 0 Then
            For buyeritems As Integer = 0 To dtbuyerdetails.Rows.Count - 1
                For chkItem As Integer = 0 To chklstBuyerCriterias.Items.Count - 1
                    If chklstBuyerCriterias.Items(chkItem).Value = dtbuyerdetails.Rows(buyeritems)("Criterias_Id").ToString() Then
                        chklstBuyerCriterias.Items(chkItem).Selected = True
                        If chklstBuyerCriterias.Items(chkItem).Text = "Buy in 12 months" Then
                            chklstBuyerCriterias.Items(chkItem).Text = "Buy in 12 months from " & dtbuyerdetails.Rows(buyeritems)("CreateDate").ToString()
                        End If
                        If chklstBuyerCriterias.Items(chkItem).Text = "Buy in 6 months" Then
                            chklstBuyerCriterias.Items(chkItem).Text = "Buy in 6 months from " & dtbuyerdetails.Rows(buyeritems)("CreateDate").ToString()
                        End If
                    End If
                Next
            Next
        End If
    End Sub
    Protected Sub ButtonSave_Click(sender As Object, e As EventArgs)

        For chkItem As Integer = 0 To chklstBuyerCriterias.Items.Count - 1
            If chklstBuyerCriterias.Items(chkItem).Selected Then
                Dim sqlBuyerCriteria As SqlParameter() = New SqlParameter(1) {}
                sqlBuyerCriteria(0) = New SqlParameter("@Buyer_Id", Convert.ToInt32(Request.QueryString("BuyerID")))
                sqlBuyerCriteria(1) = New SqlParameter("@Criterias_Id", Convert.ToInt32(chklstBuyerCriterias.Items(chkItem).Value))
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Criterias_Insert", sqlBuyerCriteria)
            Else
                Dim sql As SqlParameter() = New SqlParameter(1) {}
                sql(0) = New SqlParameter("@Buyer_Id", Convert.ToInt32(Request.QueryString("BuyerID")))
                sql(1) = New SqlParameter("@Criterias_Id", Convert.ToInt32(chklstBuyerCriterias.Items(chkItem).Value))
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Criterias_Delete", sql)
            End If
        Next
        BindCriterias()
        BindBuyerCriterias()
    End Sub

End Class
