Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Partial Class Controls_WebUserControlTownGuid
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindCordobaPages()
            BindGranadaPages()
            BindJaenPages()
            BindMalagaPages()
            BindSevillePages()
        End If
    End Sub
    Public Sub BindCordobaPages()
        navproperyCordoba.InnerHtml = navproperyCordoba.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"

        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Region_Id", 1)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Select_By_Region_ID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("TotalProperties").ToString() <> "0" Then
                    If dt.Rows(i)("PageName").ToString() = "No" Then
                        'navproperyCordoba.InnerHtml = navproperyCordoba.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=1&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperyCordoba.InnerHtml = navproperyCordoba.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-cordoba-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperyCordoba.InnerHtml = navproperyCordoba.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=1&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    Else
                        'navproperyCordoba.InnerHtml = navproperyCordoba.InnerHtml + " <li role='presentation'><a href='towninformation/" + dt.Rows(i)("PageName").ToString() + "'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperyCordoba.InnerHtml = navproperyCordoba.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-cordoba-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperyCordoba.InnerHtml = navproperyCordoba.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=1&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub BindGranadaPages()
        navproperyGranada.InnerHtml = navproperyGranada.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"

        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Region_Id", 2)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Select_By_Region_ID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("TotalProperties").ToString() <> "0" Then
                    If dt.Rows(i)("PageName").ToString() = "No" Then
                        'navproperyGranada.InnerHtml = navproperyGranada.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=2&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperyGranada.InnerHtml = navproperyGranada.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-granada-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperyGranada.InnerHtml = navproperyGranada.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=2&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    Else
                        'navproperyGranada.InnerHtml = navproperyGranada.InnerHtml + " <li role='presentation'><a href='towninformation/" + dt.Rows(i)("PageName").ToString() + "'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperyGranada.InnerHtml = navproperyGranada.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-granada-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperyGranada.InnerHtml = navproperyGranada.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=2&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub BindJaenPages()
        navproperyJaen.InnerHtml = navproperyJaen.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"

        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Region_Id", 3)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Select_By_Region_ID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("TotalProperties").ToString() <> "0" Then
                    If dt.Rows(i)("PageName").ToString() = "No" Then
                        'navproperyJaen.InnerHtml = navproperyJaen.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=3&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperyJaen.InnerHtml = navproperyJaen.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-jaen-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperyJaen.InnerHtml = navproperyJaen.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=3&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    Else
                        'navproperyJaen.InnerHtml = navproperyJaen.InnerHtml + " <li role='presentation'><a href='towninformation/" + dt.Rows(i)("PageName").ToString() + "'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperyJaen.InnerHtml = navproperyJaen.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-jaen-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperyJaen.InnerHtml = navproperyJaen.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=3&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    End If
                End If

            Next
        End If
    End Sub
    Public Sub BindMalagaPages()
        navproperyMalaga.InnerHtml = navproperyMalaga.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"

        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Region_Id", 4)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Select_By_Region_ID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("TotalProperties").ToString() <> "0" Then
                    If dt.Rows(i)("PageName").ToString() = "No" Then
                        'navproperyMalaga.InnerHtml = navproperyMalaga.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=4&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperyMalaga.InnerHtml = navproperyMalaga.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-malaga-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperyMalaga.InnerHtml = navproperyMalaga.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=4&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    Else
                        'navproperyMalaga.InnerHtml = navproperyMalaga.InnerHtml + " <li role='presentation'><a href='towninformation/" + dt.Rows(i)("PageName").ToString() + "'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperyMalaga.InnerHtml = navproperyMalaga.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-malaga-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperyMalaga.InnerHtml = navproperyMalaga.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=4&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    End If
                End If

            Next
        End If
    End Sub
    Public Sub BindSevillePages()
        navproperySeville.InnerHtml = navproperySeville.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Region_Id", 5)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Select_By_Region_ID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("TotalProperties").ToString() <> "0" Then
                    If dt.Rows(i)("PageName").ToString() = "No" Then
                        'navproperySeville.InnerHtml = navproperySeville.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=5&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperySeville.InnerHtml = navproperySeville.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-seville-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperySeville.InnerHtml = navproperySeville.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=5&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    Else
                        'navproperySeville.InnerHtml = navproperySeville.InnerHtml + " <li role='presentation'><a href='towninformation/" + dt.Rows(i)("PageName").ToString() + "'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        'navproperySeville.InnerHtml = navproperySeville.InnerHtml + " <li role='presentation'><a href='https://luvinland.com/town/" + dt.Rows(i)("Area_Name").ToString().Replace(" ", "-") + "-seville-andalucia/' target='_blank'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                        navproperySeville.InnerHtml = navproperySeville.InnerHtml + " <li role='presentation'><a href='propsearch.aspx?page=1&regionid=5&areaid=" + dt.Rows(i)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc'> " + dt.Rows(i)("Area_Name").ToString() + "<span class='badge'>" + dt.Rows(i)("TotalProperties").ToString() + "</span></a></li>"
                    End If
                End If
            Next
        End If
    End Sub
End Class
