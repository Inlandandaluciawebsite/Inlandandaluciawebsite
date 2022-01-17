Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.IO.Compression
Imports Ionic.Zip
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Newtonsoft.Json
Imports GoogleMaps.LocationServices

Partial Class Controls_WebUserControlQuickSearch
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Session("language") = "" Then
            If ViewState("SampleText") Is Nothing Then
                ViewState("SampleText") = Session("language")
                If Page.Request.Url.AbsoluteUri.Contains("propsearch.aspx") Then
                    quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "none")
                Else
                    quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "block")
                End If
                bindregions()
                bindareatype()
                bindbudget()
                bindminbed()
            End If
            If Not ViewState("SampleText") = Session("language") Then
                If Page.Request.Url.AbsoluteUri.Contains("propsearch.aspx") Then
                    quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "none")
                Else
                    quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "block")
                End If
                bindregions()
                bindareatype()
                bindbudget()
                bindminbed()
                ViewState("SampleText") = Session("language")
            End If

        End If



        If Not IsPostBack Then

            txtrefnumb.Attributes.Add("onKeyPress", "doClick('" + btnsubmitref.ClientID + "',event)")

            If Page.Request.Url.AbsoluteUri.Contains("propsearch.aspx") Then
                quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "none")
            Else
                quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "block")
            End If
            bindregions()
            bindareatype()
            bindbudget()
            bindminbed()
        End If
    End Sub
    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs)

        Dim maxprice = DropDownListPriceTo.SelectedValue
        Dim region = DropDownListRegion.SelectedValue
        Dim type = DropDownListType.SelectedValue
        Dim bedrooms = DropDownListBedrooms.SelectedValue

        If maxprice = "Any" Or maxprice = "Budget:" Or maxprice = "Presupuesto:" Or maxprice = "Cualquier" Then
            maxprice = 0
        End If
        If region = "Any" Or region = "Area:" Or region = "Área:" Or region = "Région:" Or region = "Gebied:" Or region = "Bereich:" Then
            region = 0
        End If
        If type = "Any" Or type = "Type:" Or type = "Tipo:" Or type = "Catégorie:" Or type = "Typ:" Then
            type = 0
        End If

        If bedrooms = "Any" Or bedrooms = "Min beds:" Or bedrooms = "Min Camas:" Or bedrooms = "Min Lits:" Or bedrooms = "Min Betten:" Or bedrooms = "Min Slaapkamers:" Then
            bedrooms = 0
        End If
        quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "none")
        Response.Redirect("propsearch.aspx?page=1&RegionId=" + region + "&AreaId=0&SubAreaId=0" + "&typeId=" + type + "&minimumbedroom=" + bedrooms + "&minimumbathroom=0&minimumprice=0&maximumprice=" + maxprice + "")

    End Sub

    Protected Sub btnsubmitref_Click(sender As Object, e As EventArgs)
        If Not txtrefnumb.Text = "" Then
            quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "none")
            Response.Redirect("propsearch.aspx?propertyref=" + txtrefnumb.Text)
        Else
            Dim maxprice = DropDownListPriceTo.SelectedValue
            Dim region = DropDownListRegion.SelectedValue
            Dim type = DropDownListType.SelectedValue
            Dim bedrooms = DropDownListBedrooms.SelectedValue

            If maxprice = "Any" Or maxprice = "Budget:" Or maxprice = "Presupuesto:" Or maxprice = "Cualquier" Then
                maxprice = 0
            End If
            If region = "Any" Or region = "Area:" Or region = "Área:" Or region = "Région:" Or region = "Gebied:" Or region = "Bereich:" Then
                region = 0
            End If
            If type = "Any" Or type = "Type:" Or type = "Tipo:" Or type = "Catégorie:" Or type = "Typ:" Then
                type = 0
            End If

            If bedrooms = "Any" Or bedrooms = "Min beds:" Or bedrooms = "Min Camas:" Or bedrooms = "Min Lits:" Or bedrooms = "Min Betten:" Or bedrooms = "Min Slaapkamers:" Then
                bedrooms = 0
            End If
            quicksearchform.Style.Add(HtmlTextWriterStyle.Display, "none")
            Response.Redirect("propsearch.aspx?page=1&RegionId=" + region + "&AreaId=0&SubAreaId=0" + "&typeId=" + type + "&minimumbedroom=" + bedrooms + "&minimumbathroom=0&minimumprice=0&maximumprice=" + maxprice + "")

        End If



    End Sub

    Private Sub bindregions()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Regions").Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListRegion.DataSource = dt
            DropDownListRegion.DataTextField = "text"
            DropDownListRegion.DataValueField = "id"
            DropDownListRegion.DataBind()

            ' Add All Option
            '  DropDownListRegion.Items.Insert(0, ("All"))
            Dim licategory As New ListItem(GetTranslation("All"), 0)

            DropDownListRegion.Items.Insert(0, licategory)
            DropDownListRegion.Items.Insert(0, GetTranslationArea())
        End If

    End Sub
    Public Function GetTranslation(ByVal szText As String) As String
        Dim CDataAccess As New ClassDataAccess
        Return CDataAccess.GetTranslation(szText, Session("Language")).Trim

    End Function
    Public Function GetTranslationBudget() As String
        '  Dim CDataAccess As New ClassDataAccess
        ' Return CDataAccess.GetTranslation(szText, Session("Language")).Trim

        If Not Session("language") = "" Then
            Dim language1 As String = Session("language")
            Select Case language1
                Case "Spanish"
                    Return "Presupuesto:"

                Case "French"
                    Return "Budget:"

                Case "German"
                    Return "Budget:"

                Case "Dutch"
                    Return "Budget:"

                Case Else
                    Return "Budget:"

            End Select
        Else
            Return "Budget:"
        End If
    End Function
    Public Function GetTranslationArea() As String
        '  Dim CDataAccess As New ClassDataAccess
        ' Return CDataAccess.GetTranslation(szText, Session("Language")).Trim

        If Not Session("language") = "" Then
            Dim language1 As String = Session("language")
            Select Case language1
                Case "Spanish"
                    Return "Área:"

                Case "French"
                    Return "Région:"

                Case "German"
                    Return "Gebied:"

                Case "Dutch"
                    Return "Bereich:"

                Case Else
                    Return "Area:"

            End Select
        Else
            Return "Area:"
        End If
    End Function
    Public Function GetTranslationType() As String
        '  Dim CDataAccess As New ClassDataAccess
        ' Return CDataAccess.GetTranslation(szText, Session("Language")).Trim

        If Not Session("language") = "" Then
            Dim language1 As String = Session("language")
            Select Case language1
                Case "Spanish"
                    Return "Tipo:"

                Case "French"
                    Return "Catégorie:"

                Case "German"
                    Return "Type:"

                Case "Dutch"
                    Return "Typ:"

                Case Else
                    Return "Type:"

            End Select
        Else
            Return "Type:"
        End If
    End Function
    Private Sub bindareatype()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Type").Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListType.DataSource = dt
            DropDownListType.DataTextField = "text"
            DropDownListType.DataValueField = "id"
            DropDownListType.DataBind()
            Dim licategory As New ListItem(GetTranslation("All"), 0)

            DropDownListType.Items.Insert(0, licategory)
            DropDownListType.Items.Insert(0, GetTranslationType())

        End If
    End Sub

    Private Sub bindbudget()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_property_priceupto").Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListPriceTo.DataSource = dt
            DropDownListPriceTo.DataTextField = "text"
            DropDownListPriceTo.DataValueField = "id"
            DropDownListPriceTo.DataBind()
            DropDownListPriceTo.Items.Add(GetTranslation("Any"))
            DropDownListPriceTo.Items.Insert(0, GetTranslationBudget())


            ' DropDownListPriceTo.SelectedIndex = DropDownListPriceTo.Items.Count - 1
        End If


    End Sub

    Private Sub bindminbed()

    End Sub

End Class
