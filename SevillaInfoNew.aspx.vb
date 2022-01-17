Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Partial Class SevillaInfoNew
    'Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Local Vars
        Page.Title = "Property For Sale In Seville - Properties For Sale In Seville Spain"
        Page.MetaDescription = "Inland Andalucia provide the Property for Sale in Seville. The popular capital of Andalucia, Seville and Sevilla."
        Page.MetaKeywords = "Property For Sale In Seville, Properties For Sale In Seville Spain"
        TownInfoPages()
    End Sub

    Public Sub TownInfoPages()
        navpropery.InnerHtml = navpropery.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Region_Id", 5)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Select_By_Region_ID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("PageName").ToString() = "No" Then
                    navpropery.InnerHtml = navpropery.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=5&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                Else
                    navpropery.InnerHtml = navpropery.InnerHtml + " <li role='presentation'><a href='Town/" + dt.Rows(i)("PageName").ToString() + "'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                End If
            Next
        End If
    End Sub
End Class
