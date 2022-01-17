
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares
Imports ClassUtilities
Imports System.IO
Imports System.Globalization






Partial Public Class InlandandAlucia
    Inherits System.Web.UI.MasterPage
    ' Inherits BasePage

    Protected Sub Page_Load(sender As Object, e As EventArgs)
        If Not IsPostBack Then

            ActiveMenu()
        End If
    End Sub
    Public Sub ActiveMenu()
        Dim fb As HtmlGenericControl = DirectCast(WebUserControlQuickSearch.FindControl("fbiframe"), HtmlGenericControl)
        Dim fbinfo As HtmlGenericControl = DirectCast(WebUserControlQuickSearch.FindControl("fbinfo"), HtmlGenericControl)
        Dim comlait As HtmlGenericControl = DirectCast(WebUserControlQuickSearch.FindControl("comlait"), HtmlGenericControl)
        Dim top50 As HtmlGenericControl = DirectCast(WebUserControlQuickSearch.FindControl("top50"), HtmlGenericControl)
        Dim top30 As HtmlGenericControl = DirectCast(WebUserControlQuickSearch.FindControl("top30"), HtmlGenericControl)

        Dim buyer As HtmlGenericControl = DirectCast(WebUserControlQuickSearch.FindControl("buyer"), HtmlGenericControl)


        If Page.Request.Url.AbsoluteUri.Contains("default.aspx") Then
            Home.Attributes.Add("class", "dropdown active")
            fb.Style.Add(HtmlTextWriterStyle.Display, "block")
            fbinfo.Style.Add(HtmlTextWriterStyle.Display, "none")
            comlait.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If
        If Page.Request.Url.AbsoluteUri.Contains("Default.aspx") Then
            Home.Attributes.Add("class", "dropdown active")
            fb.Style.Add(HtmlTextWriterStyle.Display, "block")
            fbinfo.Style.Add(HtmlTextWriterStyle.Display, "none")
            comlait.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If

        If Page.Request.Url.AbsoluteUri.Contains("bed-and-breakfast-ermita-nueva.aspx") Then
            prop.Attributes.Add("class", "dropdown active")
            top30.Style.Add(HtmlTextWriterStyle.Display, "block")
            top50.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("bed-and-breakfast-mollina.aspx") Then
            prop.Attributes.Add("class", "dropdown active")
            top30.Style.Add(HtmlTextWriterStyle.Display, "block")
            top50.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If

        If Page.Request.Url.AbsoluteUri.Contains("Top50Properties.aspx") Then
            prop.Attributes.Add("class", "dropdown active")
            top50.Style.Add(HtmlTextWriterStyle.Display, "none")
            comlait.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("propsearch.aspx") Then
            prop.Attributes.Add("class", "dropdown active")
            comlait.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If
        If Page.Request.Url.AbsoluteUri.Contains("andalucia-property-viewing-trip.aspx") Then
            prop.Attributes.Add("class", "dropdown active")

            fb.Style.Add(HtmlTextWriterStyle.Display, "none")
            fbinfo.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("property-search-andalucia.aspx") Then
            prop.Attributes.Add("class", "dropdown active")
            fb.Style.Add(HtmlTextWriterStyle.Display, "none")
            fbinfo.Style.Add(HtmlTextWriterStyle.Display, "none")
            comlait.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If


        If Page.Request.Url.AbsoluteUri.Contains("TownLocationInfo.aspx") Then
            TownLocationInfo.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("CordobaInfo.aspx") Then
            TownLocationInfo.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("GranadaInfo.aspx") Then
            TownLocationInfo.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("JaenInfo.aspx") Then
            TownLocationInfo.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("MalagaInfo.aspx") Then
            TownLocationInfo.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("SevillaInfo.aspx") Then
            TownLocationInfo.Attributes.Add("class", "dropdown active")

        End If



        If Page.Request.Url.AbsoluteUri.Contains("buyersguide.aspx") Then
            buyersguide.Attributes.Add("class", "dropdown active")
            buyer.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If
        If Page.Request.Url.AbsoluteUri.Contains("BuyersGuide.aspx") Then
            buyersguide.Attributes.Add("class", "dropdown active")
            buyer.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If
        If Page.Request.Url.AbsoluteUri.Contains("BuyingProcess.aspx") Then
            buyersguide.Attributes.Add("class", "dropdown active")
            buyer.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If
        If Page.Request.Url.AbsoluteUri.Contains("PropertyTaxes.aspx") Then
            buyersguide.Attributes.Add("class", "dropdown active")
            buyer.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If
        If Page.Request.Url.AbsoluteUri.Contains("BuyersGuideFAQS.aspx") Then
            buyersguide.Attributes.Add("class", "dropdown active")
            buyer.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If
        If Page.Request.Url.AbsoluteUri.Contains("BuyersGuideUnpaidTaxes.aspx") Then
            buyersguide.Attributes.Add("class", "dropdown active")
            buyer.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If
        If Page.Request.Url.AbsoluteUri.Contains("BuyersGuideMortgage.aspx") Then
            buyersguide.Attributes.Add("class", "dropdown active")
            buyer.Style.Add(HtmlTextWriterStyle.Display, "block")
        End If




        If Page.Request.Url.AbsoluteUri.Contains("inland-andalucia.aspx") Then
            inlandandaluciaa.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("LocationMapInlandTowns.aspx") Then
            inlandandaluciaa.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("weather.aspx") Then
            inlandandaluciaa.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("AndaluciaAirports.aspx") Then
            inlandandaluciaa.Attributes.Add("class", "dropdown active")

        End If


        If Page.Request.Url.AbsoluteUri.Contains("contactus.aspx") Then
            contactus.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("ContactOffices.aspx") Then
            contactus.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("InlandAndaluciaGlossaryTerms.aspx") Then
            contactus.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("InlandAndaluciaRealEstateArticles.aspx") Then
            contactus.Attributes.Add("class", "dropdown active")
            fb.Style.Add(HtmlTextWriterStyle.Display, "none")
            fbinfo.Style.Add(HtmlTextWriterStyle.Display, "none")
            comlait.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("UsefulLinks.aspx") Then
            contactus.Attributes.Add("class", "dropdown active")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("AgentLogin.aspx") Then
            contactus.Attributes.Add("class", "dropdown active")
        End If


        If Page.Request.Url.AbsoluteUri.Contains("AgentLogin.aspx") Then
            contactus.Attributes.Add("class", "dropdown active")
        End If



        Dim usercn As HtmlGenericControl = DirectCast(WebUserControlQuickSearch.FindControl("cuser"), HtmlGenericControl)




        If Page.Request.Url.AbsoluteUri.Contains("ArticleKnockemdown.aspx") Then
            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If

        If Page.Request.Url.AbsoluteUri.Contains("ArticleSchoolingForExPatChildrenInSpain.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("ArticleBringingYourPetsToSpain.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("ArticleRealEstatemarketinSpain.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("ArticleRealEstatemarketinSpain.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")
        Else

        End If
        If Page.Request.Url.AbsoluteUri.Contains("ArticleBuyTheRightProperty.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")
        Else

        End If
        If Page.Request.Url.AbsoluteUri.Contains("ArticleQuickTourofSpain.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")
        Else

        End If
        If Page.Request.Url.AbsoluteUri.Contains("ArticleQuickTourofSpain.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If
        If Page.Request.Url.AbsoluteUri.Contains("ArticleMovingToSpain.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")
        Else

        End If
        If Page.Request.Url.AbsoluteUri.Contains("aquickguideofseville.aspx") Then

            usercn.Style.Add(HtmlTextWriterStyle.Display, "none")
        Else

        End If

        If Page.Request.Url.AbsoluteUri.Contains("OnLineMagazine.aspx") Then
            lionlinemagazine.Attributes.Add("class", "dropdown active")
        End If

    End Sub

    'Public Function ConvertDataTabletoString() As String
    '    Dim CUtilities As New ClassUtilities
    '    Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_property_mapAllLocation").Tables(0)
    '    Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
    '    Dim rows As New List(Of Dictionary(Of String, Object))()
    '    Dim row As Dictionary(Of String, Object)
    '    For Each dr As DataRow In dt.Rows
    '        row = New Dictionary(Of String, Object)()
    '        For Each col As DataColumn In dt.Columns
    '            Dim status As Integer
    '            status = dr("status_id")
    '            Dim ref As String
    '            ref = dr("property_ref")
    '            Dim price As Integer
    '            price = dr("price")

    '            If col.ColumnName = "formatprice" Then
    '                dr(col) = CUtilities.FormatPrice(price)
    '            End If

    '            If col.ColumnName = "url" Then
    '                Dim url As String
    '                url = ref
    '                dr(col) = CUtilities.ApplyStatusWatermark(PhotoURL(url), status)
    '            End If
    '            row.Add(col.ColumnName, dr(col))
    '        Next
    '        rows.Add(row)
    '    Next
    '    Return serializer.Serialize(rows)
    'End Function


    'Public Function FormatPrice1(ByVal nPrice As Integer) As String

    '    ' Local Vars
    '    Dim szScratch As String
    '    Dim szRetVal As String = String.Empty
    '    Dim szDelim As String = String.Empty

    '    ' Init Scratch Value
    '    szScratch = nPrice.ToString.Trim

    '    ' While the Length of szScratch is greater than 3
    '    While szScratch.Length > 3

    '        ' Add the Last 3 Chars of szScratch to the Return Value and add Delimiter
    '        szRetVal = szScratch.Substring(szScratch.Length - 3, 3) & szDelim & szRetVal

    '        ' Reduce szScratch
    '        szScratch = szScratch.Substring(0, szScratch.Length - 3)

    '        ' Set the Delimiter
    '        szDelim = "."

    '    End While

    '    ' Add Remaining Values
    '    szRetVal = szScratch & szDelim & szRetVal

    '    ' Return the Result
    '    Return szRetVal & " €"

    'End Function


    'Private Function PhotoURL(ByVal szPropertyRef As String) As String

    '    ' Local Vars
    '    Dim szPath As String = "images/photos/properties/" & szPropertyRef.Trim & "/" & szPropertyRef.Trim & "_1.jpg"

    '    ' Check we have the Image
    '    If Not File.Exists(Server.MapPath(szPath)) Then

    '        ' Set to No Image Photo
    '        szPath = "images/icons/no-photo.png"

    '    End If

    '    ' Return the Result
    '    Return szPath

    'End Function



  
    Protected Sub ImageButtonEnglish_Click(sender As Object, e As EventArgs)
      
        Dim pageName2 As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim currentpage As String = pageName2.Substring(pageName2.LastIndexOf("/") + 1)
        Response.Redirect("~\en\" + currentpage)
    End Sub

    Protected Sub ImageButtonSpanish_Click(sender As Object, e As EventArgs)
      
        Dim pageName2 As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim currentpage As String = pageName2.Substring(pageName2.LastIndexOf("/") + 1)
        Response.Redirect("~\es\" + currentpage)
    End Sub

    Protected Sub ImageButtonFrench_Click(sender As Object, e As EventArgs)
       
        Dim pageName2 As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim currentpage As String = pageName2.Substring(pageName2.LastIndexOf("/") + 1)
        Response.Redirect("~\fr\" + currentpage)
    End Sub

    Protected Sub ImageButtonDutch_Click(sender As Object, e As EventArgs)
     
        Dim pageName2 As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim currentpage As String = pageName2.Substring(pageName2.LastIndexOf("/") + 1)
        Response.Redirect("~\de\" + currentpage)
    End Sub

    Protected Sub ImageButtonGerman_Click(sender As Object, e As EventArgs)
      
        Dim pageName2 As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim currentpage As String = pageName2.Substring(pageName2.LastIndexOf("/") + 1)
        Response.Redirect("~\nl\" + currentpage)
    End Sub
End Class

