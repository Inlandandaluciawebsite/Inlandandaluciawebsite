Imports System.Data.SqlClient
Imports System.Data
Imports HashSoftwares
Partial Class InlandAndaluciaRealEstateArticles
    '  Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables


        Page.Title = "Inland Andalucia | On-Line Magazine"

        If True Then
            If Not IsPostBack Then
                bindmagazine()
            End If
        End If
    End Sub


    Private Sub bindmagazine()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblOnlineMagazine_Select_All_Active1").Tables(0)
        If dt.Rows.Count > 0 Then
            rptCustomers.DataSource = dt
            rptCustomers.DataBind()

        Else
            rptCustomers.DataSource = dt
            rptCustomers.DataBind()

        End If
    End Sub
End Class
