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
Imports System.Drawing.Bitmap
Imports System.Reflection

Partial Class Top50Properties
    ' Inherits System.Web.UI.Page
    Inherits BasePage
    Private PageSize As Integer = 10
    Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Page.Title = "Inland Andalucia | Top 50 properties Andalucia"
        ' If Not Page.IsPostBack Then
        btnback.Attributes.Add("onClick", "javascript:history.back(); return false;")

        If Not Request.QueryString("page") = "" Then
            bindFeaturedProperty(Convert.ToInt32(Request.QueryString("page")))
            bindregionnavigation()
            bindareanavigation()
            bindsubareanavigation()
        Else
            bindFeaturedProperty(1)
            bindregionnavigation()
            bindareanavigation()
            bindsubareanavigation()
        End If

        ' End If
    End Sub

    Protected Sub Page_Changed(sender As Object, e As EventArgs)
        Dim pageIndex As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim page = pageIndex.ToString()
        Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim uri = New Uri(url)

        Dim newQueryString = HttpUtility.ParseQueryString(uri.Query)

        ' this removes the key if exists

        newQueryString.[Set]("page", page)
        Dim uriBuilder = New UriBuilder(uri)
        uriBuilder.Query = newQueryString.ToString()
        url = uriBuilder.Uri.ToString()

       

        '  url = url.Replace("?page=" + Request.QueryString("page"), "?page=" + page)
        Response.Redirect(url)
        '  Me.bindFeaturedProperty(pageIndex)
    End Sub

    Public Function FormatPrice(ByVal nPrice As Integer) As String

        ' Local Vars
        Dim szScratch As String
        Dim szRetVal As String = String.Empty
        Dim szDelim As String = String.Empty

        ' Init Scratch Value
        szScratch = nPrice.ToString.Trim

        ' While the Length of szScratch is greater than 3
        While szScratch.Length > 3

            ' Add the Last 3 Chars of szScratch to the Return Value and add Delimiter
            szRetVal = szScratch.Substring(szScratch.Length - 3, 3) & szDelim & szRetVal

            ' Reduce szScratch
            szScratch = szScratch.Substring(0, szScratch.Length - 3)

            ' Set the Delimiter
            szDelim = "."

        End While

        ' Add Remaining Values
        szRetVal = szScratch & szDelim & szRetVal

        ' Return the Result
        Return szRetVal & " €"

    End Function

    Private Sub bindFeaturedProperty(pageIndex As Integer)
        Dim Regionid As Integer = 0
        Dim areaid As Integer = 0
        Dim subarea As Integer = 0
        If Not Request.QueryString("regionid") = "" Then
            Regionid = Request.QueryString("Regionid")
        End If
        If Not Request.QueryString("areaid") = "" Then
            areaid = Request.QueryString("areaid")
        End If
        If Not Request.QueryString("SubAreaId") = "" Then
            subarea = Request.QueryString("SubAreaId")
        End If
        Dim language As Integer
        If Not Session("language") = "" Then
            Dim language1 As String = Session("language")
            Select Case language1

                Case "Spanish"
                    language = 2

                Case "French"
                    language = 3

                Case "German"
                    language = 5

                Case "Dutch"
                    language = 4

                Case Else
                    language = 1

            End Select
        Else
            language = 1
        End If
        Dim sql As SqlParameter() = New SqlParameter(7) {}
        sql(0) = New SqlParameter("@nRegionID", Regionid)
        sql(1) = New SqlParameter("@nAreaID", areaid)
        sql(2) = New SqlParameter("@nSubAreaID", subarea)
        sql(3) = New SqlParameter("@PageIndex", pageIndex)
        sql(4) = New SqlParameter("@PageSize", PageSize)
        sql(5) = New SqlParameter("@RecordCount", SqlDbType.Int, 4)
        sql(5).Direction = ParameterDirection.Output
        sql(6) = New SqlParameter("@language", language)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_ListbyPaging", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            rpFeaturedProperty.DataSource = dt
            rpFeaturedProperty.DataBind()
            Dim recordCount As Integer = Convert.ToInt16(sql(5).Value.ToString())
            lblpropertycount.Text = recordCount
            lblpropertycount1.Text = recordCount
            Me.PopulatePager(recordCount, pageIndex)
        End If
    End Sub



    Private Sub PopulatePager(recordCount As Integer, currentPage As Integer)
        Dim pages As New List(Of ListItem)()
        Dim startIndex As Integer, endIndex As Integer
        Dim pagerSpan As Integer = 5

        'Calculate the Start and End Index of pages to be displayed.
        Dim dblPageCount As Double = CDbl(CDec(recordCount) / Convert.ToDecimal(PageSize))
        Dim pageCount As Integer = CInt(Math.Ceiling(dblPageCount))
        startIndex = If(currentPage > 1 AndAlso currentPage + pagerSpan - 1 < pagerSpan, currentPage, 1)
        endIndex = If(pageCount > pagerSpan, pagerSpan, pageCount)
        If currentPage > pagerSpan Mod 2 Then
            If currentPage = 2 Then
                endIndex = 5
            Else
                endIndex = currentPage + 2
            End If
        Else
            endIndex = (pagerSpan - currentPage) + 1
        End If

        If endIndex - (pagerSpan - 1) > startIndex Then
            startIndex = endIndex - (pagerSpan - 1)
        End If

        If endIndex > pageCount Then
            endIndex = pageCount
            startIndex = If(((endIndex - pagerSpan) + 1) > 0, (endIndex - pagerSpan) + 1, 1)
        End If

        'Add the First Page Button.
        'If currentPage > 1 Then
        '    pages.Add(New ListItem("First", "1"))
        'End If

        'Add the Previous Button.
        lblcounttotalpage.Text = pageCount
        lblcounttotalpage1.Text = pageCount


        If currentPage > 1 Then
            pages.Add(New ListItem("<<", (currentPage - 1).ToString()))
        End If

        For i As Integer = startIndex To endIndex
            pages.Add(New ListItem(i.ToString(), i.ToString(), i <> currentPage))
        Next

        'Add the Next Button.
        If currentPage < pageCount Then
            pages.Add(New ListItem(">>", (currentPage + 1).ToString()))
        End If

        'Add the Last Button.
        'If currentPage <> pageCount Then
        '    pages.Add(New ListItem("Last", pageCount.ToString()))
        'End If
        rptPager.DataSource = pages
        rptPager.DataBind()
        rptpage2.DataSource = pages
        rptpage2.DataBind()
        Dim page As String = "1"
        If Not Request.QueryString("page") = "" Then
            page = Request.QueryString("page")

        End If

        lblcountpagenumber.Text = page
        lblcountpagenumber1.Text = page

    End Sub



    Public Function PhotoURL(reference As String) As String

        ' Local Vars
        Dim szPath As String = "~/images/photos/properties/" & reference.Trim & "/" & reference.Trim & "_1.jpg"

        ' Check we have the Image
        If Not File.Exists(Server.MapPath(szPath)) Then

            ' Set to No Image Photo
            szPath = "/images/icons/no-photo.png"

        End If

        ' Return the Result
        Return szPath

    End Function


    Public Sub ApplyIAWatermark(ByRef imgImage As Image)

        ' Load the IA Watermark
        Dim imgWatermark As Image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/IA.png"))

        ' Apply
        AddWatermark(imgImage, imgWatermark)

        ' Tidy
        imgWatermark.Dispose()

    End Sub

    Public Function ApplyStatusWatermark(ByVal szImageURL As String, ByVal nStatusID As Integer) As String

        ' Don't add the Watermark to no-photo
        If Not szImageURL.Contains("no-photo") Then

            ' Does this Image Require a Watermark?
            If nStatusID = 5 Or nStatusID = 7 Then

                ' Local Vars
                Dim msImage As New MemoryStream
                Dim imgWatermark As Image

                ' Load the Image
                Dim imgImage As Image = Image.FromFile(HttpContext.Current.Server.MapPath(szImageURL))

                ' Load Watermark Based on Status
                Select Case nStatusID

                    Case 5

                        ' Sold
                        imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/Sold.png"))

                    Case Else ' 7

                        ' Under Offer
                        imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/UnderOffer.png"))

                End Select

                ' Apply
                AddWatermark(imgImage, imgWatermark, False)

                ' Tidy
                imgWatermark.Dispose()

                ' Load the Image into a Memory Stream
                imgImage.Save(msImage, Imaging.ImageFormat.Jpeg)

                ' Update Image URL
                szImageURL = "data:image/png;base64," + Convert.ToBase64String(msImage.ToArray(), 0, msImage.ToArray().Length)

                ' Tidy
                msImage.Close()
                msImage.Dispose()
                imgImage.Dispose()

            End If

        End If

        ' Return the URL
        Return szImageURL

    End Function

    Private Sub AddWatermark(ByRef imgMain As Image, ByVal imgWatermark As Image, Optional ByVal bTopRight As Boolean = True)

        ' Load into Graphics Object
        Using g As Graphics = Graphics.FromImage(imgMain)

            If bTopRight Then

                g.DrawImage(imgWatermark, New Point(imgMain.Width - imgWatermark.Width - 14, 5))

            Else

                g.DrawImage(imgWatermark, New Point(0, 0))

            End If

        End Using

    End Sub

    Public Function CreateThumbnail(ByVal szPropertyRef As String) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean = False
        Dim szImagePath As String = HttpContext.Current.Server.MapPath("~/images/photos/properties/" & szPropertyRef.Trim & "/")
        Dim szImageFilename As String = szPropertyRef.Trim & "_1.jpg"
        Dim szImageThumbnail As String = szPropertyRef.Trim & "_TN.jpg"
        Dim fl As System.IO.FileInfo = New System.IO.FileInfo(szImagePath & szImageFilename)


        ' If a Header Image Exists
        If fl.Exists Then

            ' Load the Image
            Dim img As Image = Image.FromFile(szImagePath & szImageFilename)

            ' Generate Thumbnail

            Dim bmp As Image = img.GetThumbnailImage(168, 124, Nothing, IntPtr.Zero)

            bmp.Save(szImagePath & szImageThumbnail, ImageFormat.Jpeg)
            'testnbjbn
            bmp.Dispose()

            img.Dispose()

            ' Return True
            bRetVal = True


        End If


        ' Return the Result
        Return bRetVal

    End Function

    Private Sub bindareanavigation()
        If Convert.ToInt32(Request.QueryString("RegionId")) > 0 Then
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@nRegionID", Convert.ToInt32(Request.QueryString("RegionId")))
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_property_AreaTo50ByRegionId", sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
                Dim uri = New Uri(url)
                Dim qs = HttpUtility.ParseQueryString(uri.Query)
                navpropery.InnerHtml = String.Empty
                navpropery.InnerHtml = navpropery.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"
                For Each dr As DataRow In dt.Rows
                    Dim newQueryString = HttpUtility.ParseQueryString(uri.Query)
                    newQueryString.[Set]("page", "1")
                    ' this removes the key if exists
                    If newQueryString.ToString() = "AreaId" Then

                        newQueryString.Remove("AreaId")
                        Dim pagePathWithoutQueryString As String = uri.GetLeftPart(UriPartial.Path)
                        url = pagePathWithoutQueryString + "&AreaId=" + dr("id").ToString()

                    Else
                       
                        Dim uriBuilder = New UriBuilder(uri)
                        uriBuilder.Query = newQueryString.ToString()
                        url = uriBuilder.Uri.ToString() + "&AreaId=" + dr("id").ToString()
                        '   url = uri.ToString() + "&AreaId=" + dr("id").ToString()

                    End If

                    navpropery.InnerHtml = navpropery.InnerHtml + " <li role='presentation'><a href='" + url + "'> " + dr("text").ToString() + "<span class='badge'>" + dr("count").ToString() + "</span></a></li>"

                Next
                navpropery.InnerHtml = navpropery.InnerHtml + "</ul>"

            Else
                navpropery.InnerHtml = String.Empty
            End If
        End If
       
    End Sub

    Private Sub bindsubareanavigation()
        If Convert.ToInt32(Request.QueryString("AreaId")) > 0 Then
            Dim sql As SqlParameter() = New SqlParameter(2) {}
            sql(0) = New SqlParameter("@nRegionID", Convert.ToInt32(Request.QueryString("RegionId")))
            sql(1) = New SqlParameter("@nAreaID", Convert.ToInt32(Request.QueryString("AreaId")))
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_property_sAubAreatop50ByRegionAreaId", sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
                Dim uri = New Uri(url)
                Dim qs = HttpUtility.ParseQueryString(uri.Query)
                navpropery.InnerHtml = String.Empty
                navpropery.InnerHtml = navpropery.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"
                For Each dr As DataRow In dt.Rows
                    Dim newQueryString = HttpUtility.ParseQueryString(uri.Query)


                    newQueryString.[Set]("page", "1")
                    ' this removes the key if exists
                    If newQueryString.ToString() = "SubAreaId" Then

                        newQueryString.Remove("SubAreaId")
                        Dim pagePathWithoutQueryString As String = uri.GetLeftPart(UriPartial.Path)
                        url = pagePathWithoutQueryString + "&SubAreaId=" + dr("id").ToString()

                    Else

                        Dim uriBuilder = New UriBuilder(uri)
                        uriBuilder.Query = newQueryString.ToString()
                        url = uriBuilder.Uri.ToString() + "&SubAreaId=" + dr("id").ToString()
                        '   url = uri.ToString() + "&AreaId=" + dr("id").ToString()

                    End If

                    navpropery.InnerHtml = navpropery.InnerHtml + " <li role='presentation'><a href='" + url + "'> " + dr("text").ToString() + "<span class='badge'>" + dr("count").ToString() + "</span></a></li>"

                Next
                navpropery.InnerHtml = navpropery.InnerHtml + "</ul>"

            Else
                navpropery.InnerHtml = String.Empty
            End If
        End If
        If Convert.ToInt32(Request.QueryString("SubAreaId")) > 0 Then
            navpropery.InnerHtml = String.Empty
        End If

    End Sub

    Private Sub bindregionnavigation()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_property_RegionTop50").Tables(0)
        If dt.Rows.Count > 0 Then
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim uri = New Uri(url)

            navpropery.InnerHtml = String.Empty
            navpropery.InnerHtml = navpropery.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"
            For Each dr As DataRow In dt.Rows

               
                Dim newQueryString = HttpUtility.ParseQueryString(uri.Query)

                ' this removes the key if exists
                newQueryString.Remove("RegionId")
                Dim pagePathWithoutQueryString As String = uri.GetLeftPart(UriPartial.Path)

                url = pagePathWithoutQueryString + "?page=1&RegionId=" + dr("id").ToString()



                navpropery.InnerHtml = navpropery.InnerHtml + " <li role='presentation'><a href='" + url + "'> " + dr("text").ToString() + "<span class='badge'>" + dr("count").ToString() + "</span></a></li>"
            Next
            navpropery.InnerHtml = navpropery.InnerHtml + "</ul>"

        Else
            navpropery.InnerHtml = String.Empty
        End If
    End Sub
    Protected Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click

    End Sub

End Class
