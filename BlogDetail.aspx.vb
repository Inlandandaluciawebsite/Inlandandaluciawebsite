
Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares

Partial Class BlogDetail
    'Inherits System.Web.UI.Page
    'Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables


        Page.Title = "Inland Andalucia - Blog"
        bindFeaturedProperty()
        'Page.MetaDescription = "If you intend buying a property in Spain, whether this be an apartment or house on the coast, a flat in town, a plot of land or country estate."
        'Page.MetaKeywords = "Buying Property Spain"


    End Sub

    Private Sub bindFeaturedProperty()
        Dim title As String = ""
        If Not Request.QueryString("Title") = "" Then
            title = Request.QueryString("Title").ToString()
        End If
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@Title", title)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblBlogs_Showallbysearch", sql).Tables(0)
        If dt.Rows.Count > 0 Then

            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object)
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each col As DataColumn In dt.Columns
                    If col.ColumnName = "hashlables" Then
                        dr(col) = ""
                        Dim labels As String() = dr("Label").ToString().Split(",")
                        Dim comma = ""
                        For j As Integer = 0 To labels.Count() - 1
                            If j > 0 Then
                                comma = " , "
                            End If
                            dr(col) = dr(col) + comma + "<a href='BlogDetail.aspx?Title=" + (labels(j).ToString()) + "'>" + (labels(j)) + "</a> "
                        Next
                    End If
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            frmview.DataSource = dt
            frmview.DataBind()
        End If

    End Sub
End Class
