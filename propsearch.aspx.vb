Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Web
Imports System.IO.Compression
Imports Ionic.Zip
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Newtonsoft.Json
Imports GoogleMaps.LocationServices

Partial Class propsearch
    Inherits BasePage
    'Inherits System.Web.UI.Page
    Private m_szReference As String
    Public ReadOnly Property Referencem() As String
        Get
            Return m_szReference
        End Get
    End Property
    Private m_CDataAccess As ClassDataAccess
    Private Property DataAccess() As ClassDataAccess
        Get
            Return m_CDataAccess
        End Get
        Set(ByVal value As ClassDataAccess)
            m_CDataAccess = value
        End Set
    End Property
    Public Latitude As String, Longitude As String, Reference As String
    Private PageSize As Integer = 10
    ' Private pageIndex = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Local Vars
        Dim ctrl As Control = Nothing
        Dim meta As HtmlMeta = New HtmlMeta
        meta.Name = "description"
        ' Init Page Title
        Page.Title = "Andalucia Property - Property For Sale Spain"
        Page.MetaDescription = "At Inland Andalucia we have country, rural, inland property ranging from fincas, villas, townhouses to apartments."
        Page.MetaKeywords = "Andalucia Property, Property For Sale Spain"

        ' Init Meta Desc
        meta.Content = "Buy your property for a bargain price in Andalucia Inland, we cover the areas Jaén, Antequera, Malaga inland, Granada and Seville. With Inland Andalucia Ltd you are in safe hands"

        ' Initialise Data Access
        DataAccess = New ClassDataAccess

        ' Have we been Referred?
        If Not Request.QueryString("referrer") Is Nothing Then
            ' Init Entry
            Dim szEntry As String = Request.Path.Substring(1) & " "
            ' If we have a Region
            If Not Request.QueryString("regionid") Is Nothing Then

                ' If the Region ID is Numeric
                If IsNumeric(Request.QueryString("regionid")) Then

                    ' Add the Region requested
                    Select Case Convert.ToInt32(Request.QueryString("regionid"))

                        Case 1
                            szEntry &= "(Cordoba)"

                        Case 2
                            szEntry &= "(Granada)"

                        Case 3
                            szEntry &= "(Jaen)"

                        Case 4
                            szEntry &= "(Malaga)"

                        Case 5
                            szEntry &= "(Sevilla)"

                        Case Else
                            szEntry &= "(" & Request.QueryString("regionid") & ")"

                    End Select

                End If

            End If
            ' Page has been Referred - Add Referral to the Database
            DataAccess.AddReferral(Request.QueryString("referrer"), szEntry.Trim)
        End If
        If Not Session("language") = "" Then
            If ViewState("SampleText") Is Nothing Then
                ViewState("SampleText") = Session("language")

                If Not Request.QueryString("propertyref") Is Nothing Then
                    m_szReference = Request.QueryString("propertyref")
                    binddetail(Request.QueryString("propertyref"))
                    advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                    searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                    detaildiv.Style.Add(HtmlTextWriterStyle.Display, "block")
                    'topmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
                ElseIf Not Request.QueryString("propertyid") Is Nothing Then
                    Dim ppropertyid As Int32
                    ppropertyid = Convert.ToInt32(Request.QueryString("propertyid"))
                    If ppropertyid = 53974 Then
                        ppropertyid = 23974
                    End If
                    Dim CDataAccess As New ClassDataAccess
                    Dim propref = CDataAccess.PropertyRef(ppropertyid)
                    m_szReference = propref
                    binddetail(propref)
                    advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                    searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                    detaildiv.Style.Add(HtmlTextWriterStyle.Display, "block")
                    ' topmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
                ElseIf Not Request.QueryString("page") Is Nothing Then
                    Try
                        advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                        searchresult.Style.Add(HtmlTextWriterStyle.Display, "block")
                        detaildiv.Style.Add(HtmlTextWriterStyle.Display, "none")
                        topmenu.Style.Add(HtmlTextWriterStyle.Display, "none")
                        Showproperybyparam(Convert.ToInt32(Request.QueryString("page")))
                        If Not Request.QueryString("typeId") Is Nothing Then
                            bindpropertynavigation()
                            bindpropertysubnavigation()
                            bindpropertysubareanavigation()
                        End If
                    Catch ex As Exception

                    End Try

                ElseIf Not Request.QueryString("property_ref") Is Nothing Then

                    ' Redirect to Property ID
                    Response.Redirect("propsearch.aspx?propertyid=" & DataAccess.PropertyID(Request.QueryString("property_ref")).ToString.Trim)

                Else
                    bindregion()
                    DropDownListArea.Items.Clear()
                    drptown.Style.Add(HtmlTextWriterStyle.Display, "none")
                    bindtype()
                    bindpricemin()
                    '  PopulateBedsAndBaths()
                    advancesearch.Style.Add(HtmlTextWriterStyle.Display, "block")
                    searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                    detaildiv.Style.Add(HtmlTextWriterStyle.Display, "none")
                End If
            End If
            If Not ViewState("SampleText") = Session("language") Then
                If Not Request.QueryString("propertyref") Is Nothing Then
                    m_szReference = Request.QueryString("propertyref")
                    binddetail(Request.QueryString("propertyref"))
                    advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                    searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                    detaildiv.Style.Add(HtmlTextWriterStyle.Display, "block")
                    '  topmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
                ElseIf Not Request.QueryString("propertyid") Is Nothing Then
                    Dim CDataAccess As New ClassDataAccess
                    Dim propref = CDataAccess.PropertyRef(Convert.ToInt32(Request.QueryString("propertyid")))
                    m_szReference = propref
                    binddetail(propref)
                    advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                    searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                    detaildiv.Style.Add(HtmlTextWriterStyle.Display, "block")
                    '  topmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
                ElseIf Not Request.QueryString("page") Is Nothing Then
                    Try
                        advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                        searchresult.Style.Add(HtmlTextWriterStyle.Display, "block")
                        detaildiv.Style.Add(HtmlTextWriterStyle.Display, "none")
                        topmenu.Style.Add(HtmlTextWriterStyle.Display, "none")
                        Showproperybyparam(Convert.ToInt32(Request.QueryString("page")))
                        If Not Request.QueryString("typeId") Is Nothing Then
                            bindpropertynavigation()
                            bindpropertysubnavigation()
                            bindpropertysubareanavigation()
                        End If
                    Catch ex As Exception

                    End Try
                ElseIf Not Request.QueryString("property_ref") Is Nothing Then

                    ' Redirect to Property ID
                    Response.Redirect("propsearch.aspx?propertyid=" & DataAccess.PropertyID(Request.QueryString("property_ref")).ToString.Trim)

                Else
                    bindregion()
                    DropDownListArea.Items.Clear()
                    drptown.Style.Add(HtmlTextWriterStyle.Display, "none")
                    bindtype()
                    bindpricemin()
                    '  PopulateBedsAndBaths()
                    advancesearch.Style.Add(HtmlTextWriterStyle.Display, "block")
                    searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                    detaildiv.Style.Add(HtmlTextWriterStyle.Display, "none")
                    topmenu.Style.Add(HtmlTextWriterStyle.Display, "none")
                End If
                ViewState("SampleText") = Session("language")
            End If
        End If
        If Not Page.IsPostBack Then
            btnBackDetail.Attributes.Add("onClick", "javascript:history.back(); return false;")
            btnback.Attributes.Add("onClick", "javascript:history.back(); return false;")
            '  txtrefnumb.Attributes.Add("onKeyPress", "doClick('" + btnsubmit.ClientID + "',event)")
            txtrefnumb.Attributes.Add("onkeypress", "return clickButton(event,'" + btnsubmit.ClientID + "')")
            If Not Request.QueryString("propertyref") Is Nothing Then
                m_szReference = Request.QueryString("propertyref")
                binddetail(Request.QueryString("propertyref"))
                advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                detaildiv.Style.Add(HtmlTextWriterStyle.Display, "block")
                '  topmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
            ElseIf Not Request.QueryString("propertyid") Is Nothing Then
                Dim CDataAccess As New ClassDataAccess
                Dim ppropertyid As Int32

                ppropertyid = Convert.ToInt32(Request.QueryString("propertyid"))
                If ppropertyid = 53974 Then
                    ppropertyid = 23974
                End If
                Dim propref = CDataAccess.PropertyRef(ppropertyid)
                m_szReference = propref
                binddetail(propref)
                advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                detaildiv.Style.Add(HtmlTextWriterStyle.Display, "block")
                '  topmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
            ElseIf Not Request.QueryString("page") Is Nothing Then
                Try
                    advancesearch.Style.Add(HtmlTextWriterStyle.Display, "none")
                    searchresult.Style.Add(HtmlTextWriterStyle.Display, "block")
                    detaildiv.Style.Add(HtmlTextWriterStyle.Display, "none")
                    topmenu.Style.Add(HtmlTextWriterStyle.Display, "none")
                    Showproperybyparam(Convert.ToInt32(Request.QueryString("page")))
                    If Not Request.QueryString("typeId") Is Nothing Then
                        bindpropertynavigation()
                        bindpropertysubnavigation()
                        bindpropertysubareanavigation()
                    End If
                Catch ex As Exception
                    Dim strexception = ex.Message.ToString()
                End Try
            ElseIf Not Request.QueryString("property_ref") Is Nothing Then
                ' Redirect to Property ID
                Response.Redirect("propsearch.aspx?propertyid=" & DataAccess.PropertyID(Request.QueryString("property_ref")).ToString.Trim)
            Else
                bindregion()
                DropDownListArea.Items.Clear()
                drptown.Style.Add(HtmlTextWriterStyle.Display, "none")
                bindtype()
                bindpricemin()
                '  PopulateBedsAndBaths()
                advancesearch.Style.Add(HtmlTextWriterStyle.Display, "block")
                searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
                detaildiv.Style.Add(HtmlTextWriterStyle.Display, "none")
                topmenu.Style.Add(HtmlTextWriterStyle.Display, "none")
            End If
        End If

        'Enable / Disable View Town Information Button Based on query string values
        If Not String.IsNullOrEmpty(Request.QueryString("regionid")) Then
            If Request.QueryString("regionid").ToString() <> "0" And Request.QueryString("areaid").ToString() <> "0" Then
                Dim luvinlandURL As String = "https://luvinland.com/town/"
                If Request.QueryString("SubAreaId").ToString() = "0" Then
                    btnViewInformation.Visible = True
                    'Get region name & area name by region id & area id
                    Dim dtArea As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, "select * from PC_Area where Area_Id=" & Convert.ToInt32(Request.QueryString("areaid").ToString())).Tables(0)
                    luvinlandURL = luvinlandURL & dtArea.Rows(0)("Area_Name").ToString().Replace(" ", "-")
                    Dim dtRegion As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, "select * from PC_region where region_Id=" & Convert.ToInt32(Request.QueryString("regionid").ToString())).Tables(0)
                    luvinlandURL = luvinlandURL & "-" & dtRegion.Rows(0)("Region_Name").ToString() & "-andalucia"
                    btnViewInformation.PostBackUrl = luvinlandURL
                Else
                    btnViewInformation.Visible = False
                End If
            Else
                btnViewInformation.Visible = False
            End If
        End If

    End Sub
    Protected Sub DropDownListRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListRegion.SelectedIndexChanged
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@region_id", Convert.ToInt32(DropDownListRegion.SelectedValue))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_AreaByRegionId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            ' Populate the Areas within the Region
            ' Clear Existing
            DropDownListArea.Items.Clear()
            ' Get the Areas in this Region
            DropDownListArea.DataSource = dt
            DropDownListArea.DataTextField = "text"
            DropDownListArea.DataValueField = "id"
            DropDownListArea.DataBind()
            Dim licategory As New ListItem(GetTranslation("All"), 0)
            DropDownListArea.Items.Insert(0, licategory)
            ' Make Visible
            drptown.Style.Add(HtmlTextWriterStyle.Display, "block")
        Else
            ' User Selected ALL Disable Area and SubArea
            DropDownListArea.Items.Clear()
            drptown.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If
    End Sub
    Protected Sub DropDownListArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListArea.SelectedIndexChanged
        ' If the User has Selected an Area
        If DropDownListArea.SelectedIndex > 0 Then
        End If
    End Sub
    Protected Sub DropDownListPriceFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPriceFrom.SelectedIndexChanged
        ' Ensure Ranges are not Negative
        If DropDownListPriceFrom.SelectedIndex > DropDownListPriceTo.SelectedIndex Then
            DropDownListPriceTo.SelectedIndex = DropDownListPriceFrom.SelectedIndex - 1
        End If
    End Sub
    Protected Sub DropDownListPriceTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPriceTo.SelectedIndexChanged
        ' Ensure Ranges are not Negative
        If DropDownListPriceFrom.SelectedIndex > DropDownListPriceTo.SelectedIndex Then
            DropDownListPriceFrom.SelectedIndex = DropDownListPriceTo.SelectedIndex + 1
        End If
    End Sub
    Public Function GetTranslation(ByVal szText As String) As String
        Dim CDataAccess As New ClassDataAccess
        Return CDataAccess.GetTranslation(szText, Session("Language")).Trim
    End Function
    Private Sub bindregion()
        ' Throw New NotImplementedException
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
        End If
    End Sub
    Private Sub bindtype()
        '  Throw New NotImplementedException
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Type").Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListType.DataSource = dt
            DropDownListType.DataTextField = "text"
            DropDownListType.DataValueField = "id"
            DropDownListType.DataBind()
            Dim licategory As New ListItem(GetTranslation("All"), 0)
            DropDownListType.Items.Insert(0, licategory)
        End If
    End Sub
    Private Sub bindpricemin()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Price").Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListPriceFrom.DataSource = dt
            DropDownListPriceFrom.DataTextField = "text"
            DropDownListPriceFrom.DataValueField = "id"
            DropDownListPriceFrom.DataBind()
            ' Remove the Last Options
            DropDownListPriceFrom.Items.RemoveAt(DropDownListPriceFrom.Items.Count - 1)
            DropDownListPriceFrom.Items.RemoveAt(DropDownListPriceFrom.Items.Count - 1)
            DropDownListPriceTo.DataSource = dt
            DropDownListPriceTo.DataTextField = "text"
            DropDownListPriceTo.DataValueField = "id"
            DropDownListPriceTo.DataBind()
            ' Remove the First and Last Options
            DropDownListPriceTo.Items.RemoveAt(0)
            DropDownListPriceTo.Items.RemoveAt(DropDownListPriceTo.Items.Count - 1)
            ' Add All Options
            ' Add All Options
            DropDownListPriceFrom.Items.Insert(0, GetTranslation("Any"))
            DropDownListPriceTo.Items.Add(GetTranslation("Any"))
            ' Init to Any
            DropDownListPriceTo.SelectedIndex = DropDownListPriceTo.Items.Count - 1
        End If
    End Sub
    Private Sub PopulateBedsAndBaths()
        Dim szScratch As String = GetTranslation("or more")
        DropDownListBedrooms.Items.Clear()
        DropDownListBedrooms.Items.Add(GetTranslation("Any"))
        DropDownListBedrooms.Items.Add("1 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("2 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("3 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("4 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("5 " & szScratch.Trim)
        DropDownListBathrooms.Items.Clear()
        DropDownListBathrooms.Items.Add(GetTranslation("Any"))
        DropDownListBathrooms.Items.Add("1 " & szScratch.Trim)
        DropDownListBathrooms.Items.Add("2 " & szScratch.Trim)
        DropDownListBathrooms.Items.Add("3 " & szScratch.Trim)
        DropDownListBathrooms.Items.Add("4 " & szScratch.Trim)
        DropDownListBathrooms.Items.Add("5 " & szScratch.Trim)
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim minprice = DropDownListPriceFrom.SelectedValue
        Dim maxprice = DropDownListPriceTo.SelectedValue
        Dim area = DropDownListArea.SelectedValue
        Dim region = DropDownListRegion.SelectedValue
        Dim listtype = DropDownListType.SelectedValue
        Dim bedrooms = DropDownListBedrooms.SelectedValue
        Dim Bathrooms = DropDownListBathrooms.SelectedValue
        If minprice = "Any" Or minprice = "Cualquier" Or minprice = "Tout" Or minprice = "Jede" Or minprice = "Alle" Then
            minprice = 0
        End If
        If maxprice = "Any" Or maxprice = "Cualquier" Or maxprice = "Tout" Or maxprice = "Jede" Or maxprice = "Alle" Then
            maxprice = 0
        End If
        If area = "" Then
            area = 0
        End If
        If region = "" Then
            region = 0
        End If
        If listtype = "" Then
            listtype = 0
        End If
        If bedrooms = "" Then
            bedrooms = 0
        End If
        If Bathrooms = "" Then
            Bathrooms = 0
        End If
        Response.Redirect("propsearch.aspx?page=1&RegionId=" + region + "&AreaId=" + area + "&SubAreaId=0" + "&typeId=" + listtype + "&minimumbedroom=" + bedrooms + "&minimumbathroom=" + Bathrooms + "&minimumprice=" + minprice + "&maximumprice=" + maxprice + "&PageName=PropSearch")
    End Sub
    Private Sub Showproperybyparam(pageIndex As Integer)
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
        Dim sql As SqlParameter() = New SqlParameter(13) {}
        sql(0) = New SqlParameter("@nRegionID", Convert.ToInt32(Request.QueryString("RegionId")))
        sql(1) = New SqlParameter("@nAreaID", Convert.ToInt32(Request.QueryString("AreaId")))
        sql(2) = New SqlParameter("@nSubAreaID", Convert.ToInt32(Request.QueryString("SubAreaId")))
        sql(3) = New SqlParameter("@nTypeID", Convert.ToInt32(Request.QueryString("typeId")))
        sql(4) = New SqlParameter("@nMinimumBedrooms", Convert.ToInt32(Request.QueryString("minimumbedroom")))
        sql(5) = New SqlParameter("@nMinimumBathrooms", Convert.ToInt32(Request.QueryString("minimumbathroom")))
        sql(6) = New SqlParameter("@nMinimumPrice", Convert.ToInt32(Request.QueryString("minimumprice")))
        sql(7) = New SqlParameter("@nMaximumPrice", Convert.ToInt32(Request.QueryString("maximumprice")))
        sql(8) = New SqlParameter("@PageIndex", pageIndex)
        sql(9) = New SqlParameter("@PageSize", PageSize)
        sql(10) = New SqlParameter("@RecordCount", SqlDbType.Int, 4)
        sql(11) = New SqlParameter("@language", language)
        sql(10).Direction = ParameterDirection.Output
        If Not String.IsNullOrEmpty(Request.QueryString("postcode")) Then
            sql(12) = New SqlParameter("@postcode", Convert.ToInt32(Request.QueryString("postcode")))
            listmenu.Visible = False
            anchNewSearch.HRef = "property-search-andalucia.aspx"
        Else
            sql(12) = New SqlParameter("@postcode", 0)
        End If
        Dim storeprocedure As String = "Usp_Property_SearchBy_Param_Version_03"
        If Convert.ToInt32(Request.QueryString("minimumprice")) = 0 And Convert.ToInt32(Request.QueryString("maximumprice")) > 0 Then
            storeprocedure = "Usp_Property_SearchBy_MaximumPrice_UpTo"
        End If
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, storeprocedure, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            rpFeaturedProperty.DataSource = dt
            rpFeaturedProperty.DataBind()
            Dim recordCount As Integer = Convert.ToInt16(sql(10).Value.ToString())
            Me.PopulatePager(recordCount, pageIndex)
            lblpropertycount.Text = recordCount
            lblpropertycount1.Text = recordCount
            notfound.Style.Add(HtmlTextWriterStyle.Display, "none")
            listmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
            propcount.Style.Add(HtmlTextWriterStyle.Display, "block")
            searchresult.Style.Add(HtmlTextWriterStyle.Display, "block")
        Else
            ' notfound.Attributes.Add()
            notfound.Style.Add(HtmlTextWriterStyle.Display, "block")
            listmenu.Style.Add(HtmlTextWriterStyle.Display, "none")
            propcount.Style.Add(HtmlTextWriterStyle.Display, "none")
            searchresult.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If
    End Sub
    Public Function PhotoURL(reference As String) As String

        ' Local Vars
        Dim szPath As String = "~/images/photos/properties/" & reference.Trim & "/" & reference.Trim & "_1.jpg"

        ' Check we have the Image
        If Not File.Exists(Server.MapPath(szPath)) Then

            ' Set to No Image Photo
            szPath = "~/images/icons/no-photo.png"

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
    Public Function ApplyStatusWatermark(ByVal szImageURL As String, ByVal nStatusID As Integer, ByVal IsFeatured As Integer, ByVal BannerType As String) As String

        Try
            ' Don't add the Watermark to no-photo
            If Not szImageURL.Contains("no-photo") Then
                If IsFeatured = 1 And BannerType = "" Then
                    nStatusID = 20
                End If
                If BannerType <> "" And nStatusID <> 7 Then

                    If BannerType = "DIY Bargain" Then
                        nStatusID = 1001
                    End If

                    If BannerType = "Now Negotiable" Then
                        nStatusID = 1002
                    End If

                    If BannerType = "Reformed" Then
                        nStatusID = 1003
                    End If

                    If BannerType = "Big Reduction" Then
                        nStatusID = 1004
                    End If

                    If BannerType = "Rent To Buy Option" Then
                        nStatusID = 1005
                    End If

                    If BannerType = "Reserved" Then
                        nStatusID = 1006
                    End If

                End If
                ' Does this Image Require a Watermark?
                If nStatusID = 5 Or nStatusID = 7 Or nStatusID = 20 Or nStatusID = 1001 Or nStatusID = 1002 Or nStatusID = 1003 Or nStatusID = 1004 Or nStatusID = 1005 Or nStatusID = 1006 Then

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

                        Case 20

                            ' Sold
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/Exclusive_02.png"))

                        Case 7

                            ' Under Offer
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/UnderOffer4.png"))

                        Case 1001

                            ' DIY_BARGAIN
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/DIY_BARGAIN.png"))

                        Case 1002

                            ' NOW_NEGOTIABLE
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/NOW_NEGOTIABLE.png"))

                        Case 1003

                            ' REFORMED
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/REFORMED.png"))

                        Case 1004

                            ' BIG_REDUCTION
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/BIG_REDUCTION.png"))

                        Case 1005

                            ' RentToBuy
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/RentToBuy.png"))

                        Case 1006
                            ' Reserved
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/Reserved.png"))

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

        Catch ex As Exception

        End Try

        ' Return the URL
        Return szImageURL

    End Function
    Protected Sub Page_Changed(sender As Object, e As EventArgs)
        Dim pageIndex As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim page = pageIndex.ToString()
        Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
        url = url.Replace("?page=" + Request.QueryString("page"), "?page=" + page)
        Response.Redirect(url)

        'Me.Showproperybyparam(pageIndex)
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
    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs)
        If Not txtrefnumb.Text = "" Then
            Response.Redirect("propsearch.aspx?propertyref=" + txtrefnumb.Text)
        Else
            Dim minprice = DropDownListPriceFrom.SelectedValue
            Dim maxprice = DropDownListPriceTo.SelectedValue
            Dim area = DropDownListArea.SelectedValue
            If minprice = "Any" Or minprice = "Cualquier" Or minprice = "Tout" Or minprice = "Jede" Then
                minprice = 0
            End If
            If maxprice = "Any" Or maxprice = "Cualquier" Or maxprice = "Tout" Or maxprice = "Jede" Then
                maxprice = 0
            End If
            If area = "" Then
                area = 0
            End If
            Response.Redirect("propsearch.aspx?page=1&RegionId=" + DropDownListRegion.SelectedValue + "&AreaId=" + area + "&SubAreaId=0" + "&typeId=" + DropDownListType.SelectedValue + "&minimumbedroom=" + DropDownListBedrooms.SelectedValue + "&minimumbathroom=" + DropDownListBathrooms.SelectedValue + "&minimumprice=" + minprice + "&maximumprice=" + maxprice)

        End If


    End Sub
    Private Sub bindpropertynavigation()
        Dim sql As SqlParameter() = New SqlParameter(5) {}

        sql(0) = New SqlParameter("@nTypeID", Convert.ToInt32(Request.QueryString("typeId")))
        sql(1) = New SqlParameter("@nMinBedsint", Convert.ToInt32(Request.QueryString("minimumbedroom")))
        sql(2) = New SqlParameter("@nMinBaths", Convert.ToInt32(Request.QueryString("minimumbathroom")))
        sql(3) = New SqlParameter("@nMinPrice", Convert.ToInt32(Request.QueryString("minimumprice")))
        sql(4) = New SqlParameter("@nMaxPrice", Convert.ToInt32(Request.QueryString("maximumprice")))

        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Search", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim uri = New Uri(url)
            Dim qs = HttpUtility.ParseQueryString(uri.Query)

            navpropery.InnerHtml = String.Empty
            navpropery.InnerHtml = navpropery.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"
            For Each dr As DataRow In dt.Rows
                qs.[Set]("page", "1")
                qs.[Set]("RegionId", dr("id").ToString())
                Dim uriBuilder = New UriBuilder(uri)
                uriBuilder.Query = qs.ToString()
                Dim newUri = uriBuilder.Uri
                '  url = url.Replace("&RegionId=" + Request.QueryString("RegionId"), "&RegionId=" + dr("id").ToString())
                navpropery.InnerHtml = navpropery.InnerHtml + " <li role='presentation'><a href='" + newUri.ToString() + "'> " + dr("text").ToString() + "<span class='badge'>" + dr("count").ToString() + "</span></a></li>"
            Next
            navpropery.InnerHtml = navpropery.InnerHtml + "</ul>"

        Else
            navpropery.InnerHtml = String.Empty
        End If
    End Sub
    Private Sub bindpropertysubnavigation()

        If Convert.ToInt32(Request.QueryString("RegionId")) > 0 Then
            Dim sql As SqlParameter() = New SqlParameter(6) {}

            sql(0) = New SqlParameter("@nRegionID", Convert.ToInt32(Request.QueryString("RegionId")))
            sql(1) = New SqlParameter("@nTypeID", Convert.ToInt32(Request.QueryString("typeId")))
            sql(2) = New SqlParameter("@nMinBeds", Convert.ToInt32(Request.QueryString("minimumbedroom")))
            sql(3) = New SqlParameter("@nMinBaths", Convert.ToInt32(Request.QueryString("minimumbathroom")))
            sql(4) = New SqlParameter("@nMinPrice", Convert.ToInt32(Request.QueryString("minimumprice")))
            sql(5) = New SqlParameter("@nMaxPrice", Convert.ToInt32(Request.QueryString("maximumprice")))

            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_SearchAreatype", sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
                Dim uri = New Uri(url)
                Dim qs = HttpUtility.ParseQueryString(uri.Query)

                navpropery.InnerHtml = String.Empty
                navpropery.InnerHtml = navpropery.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"
                For Each dr As DataRow In dt.Rows
                    qs.[Set]("page", "1")
                    qs.[Set]("AreaId", dr("id").ToString())
                    Dim uriBuilder = New UriBuilder(uri)
                    uriBuilder.Query = qs.ToString()
                    Dim newUri = uriBuilder.Uri
                    '  url = url.Replace("&RegionId=" + Request.QueryString("RegionId"), "&RegionId=" + dr("id").ToString())
                    navpropery.InnerHtml = navpropery.InnerHtml + " <li role='presentation'><a href='" + newUri.ToString() + "'> " + dr("text").ToString() + "<span class='badge'>" + dr("count").ToString() + "</span></a></li>"
                Next
                navpropery.InnerHtml = navpropery.InnerHtml + "</ul>"

            Else
                navpropery.InnerHtml = String.Empty

            End If
        End If

    End Sub
    Private Sub bindpropertysubareanavigation()
        If Convert.ToInt32(Request.QueryString("AreaId")) > 0 Then
            Dim sql As SqlParameter() = New SqlParameter(6) {}

            sql(0) = New SqlParameter("@nRegionID", Convert.ToInt32(Request.QueryString("RegionId")))
            sql(1) = New SqlParameter("@nAreaID", Convert.ToInt32(Request.QueryString("AreaId")))
            sql(2) = New SqlParameter("@nTypeID", Convert.ToInt32(Request.QueryString("typeId")))
            sql(3) = New SqlParameter("@nMinBeds", Convert.ToInt32(Request.QueryString("minimumbedroom")))
            sql(4) = New SqlParameter("@nMinBaths", Convert.ToInt32(Request.QueryString("minimumbathroom")))
            sql(5) = New SqlParameter("@nMinPrice", Convert.ToInt32(Request.QueryString("minimumprice")))
            sql(6) = New SqlParameter("@nMaxPrice", Convert.ToInt32(Request.QueryString("maximumprice")))

            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_property_searchSubArea", sql).Tables(0)
            If dt.Rows.Count > 0 Then
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
                Dim uri = New Uri(url)
                Dim qs = HttpUtility.ParseQueryString(uri.Query)

                navpropery.InnerHtml = String.Empty
                navpropery.InnerHtml = navpropery.InnerHtml + "<ul class='nav nav-pills' role='tablist'  >"
                For Each dr As DataRow In dt.Rows
                    qs.[Set]("page", "1")
                    qs.[Set]("SubAreaId", dr("id").ToString())
                    Dim uriBuilder = New UriBuilder(uri)
                    uriBuilder.Query = qs.ToString()
                    Dim newUri = uriBuilder.Uri
                    '  url = url.Replace("&RegionId=" + Request.QueryString("RegionId"), "&RegionId=" + dr("id").ToString())
                    navpropery.InnerHtml = navpropery.InnerHtml + " <li role='presentation'><a href='" + newUri.ToString() + "'> " + dr("text").ToString() + "<span class='badge'>" + dr("count").ToString() + "</span></a></li>"
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
    ''''''''''''''''''''''''''''''''''''''''''''''Detail Page'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Public Function GetTranslation(ByVal szText As String, Optional ByVal bHTMLSafe As Boolean = False) As String

    '    Dim CDataAccess As New ClassDataAccess

    '    Dim szRetVal As String = CDataAccess.GetTranslation01(szText, Session("Language"), bHTMLSafe).Trim

    '    CDataAccess = Nothing

    '    Return szRetVal

    'End Function
    Private Sub binddetail(proprefrence As String)
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

        Dim sql As SqlParameter() = New SqlParameter(2) {}

        sql(0) = New SqlParameter("@PropRef", proprefrence)
        sql(1) = New SqlParameter("@language", language)
        '  Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_PropertyDetail_ByPropRef01", sql).Tables(0)

        Dim CDataAccess As New ClassDataAccess

        ' If we have a Partner ID
        Dim dt As DataTable
        Dim nPropertyID As Integer
        If Session("ContactPartnerID") Is Nothing Then

            ' Get the Property Detail - No Partner ID
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_PropertyDetail_ByPropRef01", sql).Tables(0)
            nPropertyID = CDataAccess.PropertyID(proprefrence)
            ' Audit Public Viewing
            CDataAccess.AuditPropertyViewed(nPropertyID)
        Else
            ' Get the Property Detail - Partner ID
            Dim sql1 As SqlParameter() = New SqlParameter(3) {}
            sql1(0) = New SqlParameter("@PropRef", proprefrence)
            sql1(1) = New SqlParameter("@language", language)
            sql1(2) = New SqlParameter("@partnerid", Convert.ToInt32(Session("ContactPartnerID")))
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_PropertyDetail_ByPropRefbypartnerid", sql1).Tables(0)
        End If
        If dt.Rows.Count > 0 Then
            hdnBannerType.Value = dt.Rows(0)("BannerType").ToString()
            Dim CUtilities As New ClassUtilities
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object)
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each col As DataColumn In dt.Columns
                    If col.ColumnName = "FormatPrice" Then
                        dr(col) = CUtilities.FormatPrice(dr("price"))
                    End If
                    If col.ColumnName = "FormatorignalPrice" Then
                        dr(col) = CUtilities.FormatPrice(dr("original_price"))
                    End If

                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next

            rpdetail.DataSource = dt
            rpdetail.DataBind()
            hdnPropertyTitle.Value = dt.Rows(0)("type").ToString() & " (" & dt.Rows(0)("partner_reference").ToString() & ") / " & dt.Rows(0)("region").ToString() & " / " & dt.Rows(0)("area").ToString()

            If Not (dt.Rows(0)("video_url")) = "" Then
                vidio.InnerHtml = ""
                vidio.InnerHtml = "<a href='#' class='youtube-link-dark' youtubeid='" & dt.Rows(0)("video_url") & "'><img src=""" & GetVideoImagePath() & """ alt=""Video"" border=""0"" hspace=""5"" /></a>"
                'vidio.InnerHtml = "<a href='Youtubevideos.aspx?videourl=" & dt.Rows(0)("video_url") & "' target=""_blank""><img src=""" & GetVideoImagePath() & """ alt=""Video"" border=""0"" hspace=""5"" /></a>"
            End If
            Try
                Latitude = dt.Rows(0)("latitude")
                Longitude = dt.Rows(0)("longitude")
            Catch ex As Exception

            End Try


            Reference = dt.Rows(0)("reference")

            notfound1.Style.Add(HtmlTextWriterStyle.Display, "none")
            topmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
            fbshare.Style.Add(HtmlTextWriterStyle.Display, "block")
        Else

            notfound1.Style.Add(HtmlTextWriterStyle.Display, "block")
            topmenu.Style.Add(HtmlTextWriterStyle.Display, "none")
            fbshare.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If

        If Not String.IsNullOrEmpty(Request.QueryString("propertyref")) Then
            Email.InnerHtml = "<a href='mailto:?&subject=Property of Interest &body=Hi%0A%0A I have just been on www.inlandandalucia.com and I saw this property which I thought may be of interest to you:%0A%0Ahttp://www.inlandandalucia.com/propsearch.aspx%3Fpropertyref=" & Request.QueryString("propertyref").ToString() & "%0A%0A Regards%0A%0A'> " & GetEmailImagePath() & "</a>"
        Else
            Email.InnerHtml = "<a href='mailto:?&subject=Property of Interest&body=Hi%0A%0AI have just been on www.inlandandalucia.com and I saw this property which I thought may be of interest to you:%0A%0Ahttp://www.inlandandalucia.com/propsearch.aspx%3Fpropertyid=" & Request.QueryString("propertyid").ToString() & "%0A%0ARegards%0A%0A'><i class='fa fa-envelope-o'> </i> Email</a>"
        End If
        ' Define the Contact Us Button
        ContactUs.InnerHtml = "<a href='contactus.aspx?reference=" & Referencem & "'>" & GetContactUsImagePath() & "</a>"
        ' Define the Reserve For Viewing Button
        'spnReserveForViewing.InnerHtml = "<a onclick='OpenMessageWindow();' style='cursor:pointer;'>" & GetPaypalImagePath() & "</a>"
    End Sub
    Private Function GetEmailImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = ""

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "Enviar"

            Case 3
                ' French
                szRetVal &= "Envoyer"

            Case 4
                ' German
                szRetVal &= "email-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "Senden"

            Case Else
                ' English
                szRetVal &= "E-mail"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function
    Public Function GetContactUsImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = ""

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "Contactenos"

            Case 3
                ' French
                szRetVal &= "Contactez-nous"

            Case 4
                ' German
                szRetVal &= "neem contact op met ons"

            Case 5
                ' Dutch
                szRetVal &= "Kontakt"

            Case Else
                ' English
                szRetVal &= "Contact us"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function
    Public Function GetVideoImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "/images/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "watch-video-ES.gif"

            Case 3
                ' French
                szRetVal &= "watch-video-FR.gif"

            Case 4
                ' German
                szRetVal &= "watch-video-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "watch-video-NL.gif"

            Case Else
                ' English
                szRetVal &= "watch-video.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function
    Public Function GetPaypalImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = ""

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "Reservar para ver"

            Case 3
                ' French
                szRetVal &= "Réserver pour visionner"

            Case 4
                ' German
                szRetVal &= "Reservieren zum Ansehen"

            Case 5
                ' Dutch
                szRetVal &= "Reserveren voor weergave"

            Case Else
                ' English
                szRetVal &= "Reserve For Viewing"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function
    Protected Sub rpdetail_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            Dim number As HiddenField = DirectCast(e.Item.FindControl("propnum"), HiddenField)
            Dim status As HiddenField = DirectCast(e.Item.FindControl("statusid"), HiddenField)
            Dim IsFeatured As HiddenField = DirectCast(e.Item.FindControl("IsFeatured"), HiddenField)
            Dim pnlMap As Panel = DirectCast(e.Item.FindControl("pnlMap"), Panel)
            Dim pnlMapCircle As Panel = DirectCast(e.Item.FindControl("pnlMapCircle"), Panel)

            If IsFeatured.Value = "0" Then
                pnlMap.Visible = False
                pnlMapCircle.Visible = True
            Else
                pnlMap.Visible = False
                pnlMapCircle.Visible = True
                'For featured property / exclusive image
                If status.Value <> "5" And status.Value <> "7" Then
                    status.Value = "20"
                End If
            End If

            'If any banner type been  set for property
            If hdnBannerType.Value <> "" And status.Value <> "7" Then

                If hdnBannerType.Value = "DIY Bargain" Then
                    status.Value = "1001"
                End If

                If hdnBannerType.Value = "Now Negotiable" Then
                    status.Value = "1002"
                End If

                If hdnBannerType.Value = "Reformed" Then
                    status.Value = "1003"
                End If

                If hdnBannerType.Value = "Big Reduction" Then
                    status.Value = "1004"
                End If

                If hdnBannerType.Value = "Rent To Buy Option" Then
                    status.Value = "1005"
                End If
                If hdnBannerType.Value = "Reserved" Then
                    status.Value = "1006"
                End If

            End If

            Dim innerRepeater As Repeater = DirectCast(e.Item.FindControl("rpslider"), Repeater)
            Dim innerRepeater2 As Repeater = DirectCast(e.Item.FindControl("rpslider2"), Repeater)
            Dim photos = Convert.ToInt16(number.Value)
            Dim CUtilities As New ClassUtilities
            Dim szImageURL As String
            ' Dim dt As DataTable = GetStudentMarks(lblRollNo.Text)

            '  innerRepeater.DataSource = 
            Dim dt As New DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            ' dt.Columns(0).AutoIncrement = True
            Dim R As DataRow

            For num = 1 To photos
                R = dt.NewRow

                szImageURL = "/images/photos/properties/" & Referencem.Trim & "/" & Referencem.Trim & "_" & num.ToString.Trim & ".jpg"

                If num < 2 Then
                    R("Name") = CUtilities.ApplyStatusWatermark(szImageURL, status.Value)
                Else
                    R("Name") = szImageURL
                End If
                dt.Rows.Add(R)
                '  R = R + 1
            Next
            innerRepeater.DataSource = dt
            innerRepeater.DataBind()
            innerRepeater2.DataSource = dt
            innerRepeater2.DataBind()
        End If
        'innerRepeater.DataBind()
    End Sub
    Protected Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click

    End Sub
    Public Function ConvertDataTabletoString() As String
        If Not Request.QueryString("propertyref") Is Nothing Then
            m_szReference = Request.QueryString("propertyref")

        ElseIf Not Request.QueryString("propertyid") Is Nothing Then
            Dim CDataAccess As New ClassDataAccess
            Dim propref = CDataAccess.PropertyRef(Convert.ToInt32(Request.QueryString("propertyid")))
            m_szReference = propref

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
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@PropRef", m_szReference)
        sql(1) = New SqlParameter("@language", language)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_PropertyDetail_ByPropRef01map", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object)
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each col As DataColumn In dt.Columns
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows)
        Else
            Return ""
        End If
    End Function
    Protected Sub btnRedirectToStripe_Click(sender As Object, e As EventArgs)
        Dim propertyTitle As String = hdnPropertyTitle.Value
        Response.Redirect("Buyer.aspx?propertyref=" & Request.QueryString("propertyref").ToString() & "&propertytitle=" & propertyTitle)
    End Sub

    Protected Sub btnViewInformation_Click(sender As Object, e As EventArgs)

    End Sub
End Class
