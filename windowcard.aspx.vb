Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.tool.xml
Imports System.Data.SqlClient
Imports System.Configuration
Imports HashSoftwares

Public Class windowcard
    Inherits System.Web.UI.Page
    Private m_nPropertyID As Integer
    Public ReadOnly Property PropertyID() As Integer
        Get
            Return m_nPropertyID
        End Get
    End Property
    Private m_szType As String
    Public ReadOnly Property Type() As String
        Get
            Return m_szType
        End Get
    End Property
    Private m_szReference As String
    Private ReadOnly Property Reference() As String
        Get
            Return m_szReference
        End Get
    End Property
    Private m_szPartnerReference As String
    Public ReadOnly Property PartnerReference() As String
        Get
            Return m_szPartnerReference
        End Get
    End Property

    Private m_szRegion As String
    Public ReadOnly Property Region() As String
        Get
            Return m_szRegion
        End Get
    End Property
    Private m_szArea As String
    Public ReadOnly Property Area() As String
        Get
            Return m_szArea
        End Get
    End Property
    Private m_szSubArea As String
    Public ReadOnly Property SubArea() As String
        Get
            Dim szRetVal As String = String.Empty
            ' If the Sub Area is NULL
            If m_szSubArea.ToLower.Trim <> "not specified" Then
                szRetVal = " - " & m_szSubArea.Trim
            Else
                szRetVal = ""
            End If
            Return szRetVal
        End Get
    End Property
    Private m_szDescription As String
    Public ReadOnly Property Description() As String
        Get
            Return m_szDescription
        End Get
    End Property
    Private m_szDescriptionES As String
    Public ReadOnly Property DescriptionES() As String
        Get
            Return m_szDescriptionES
        End Get
    End Property
    Private m_szShortDescription As String
    Public ReadOnly Property ShortDescription() As String
        Get
            Return m_szShortDescription
        End Get
    End Property
    Private m_nBedrooms As Integer
    Public ReadOnly Property Bedrooms() As Integer
        Get
            Return m_nBedrooms
        End Get
    End Property

    Private m_nBathrooms As Integer
    Public ReadOnly Property Bathrooms() As Integer
        Get
            Return m_nBathrooms
        End Get
    End Property

    Private m_nBuiltSize As Integer
    Public ReadOnly Property BuiltSize() As String
        Get
            Return String.Format("{0:#,##0}", m_nBuiltSize)
        End Get
    End Property

    Private m_nPlotSize As Integer
    Public ReadOnly Property PlotSize() As String
        Get
            Return String.Format("{0:#,##0}", m_nPlotSize)
        End Get
    End Property

    Private m_dOriginalPrice As Double
    Private ReadOnly Property OriginalPrice() As String
        Get
            Dim szRetVal As String = String.Empty
            Dim CUtilities As New ClassUtilities
            If m_dOriginalPrice > 0 Then
                szRetVal = CUtilities.FormatPrice(m_dOriginalPrice)
            End If
            CUtilities = Nothing
            Return szRetVal
        End Get
    End Property
    Private m_dPrice As Double
    Private ReadOnly Property Price() As String
        Get
            Dim szRetVal As String = String.Empty
            Dim CUtilities As New ClassUtilities
            If m_dPrice = 0 Then
                szRetVal = "P.O.A."
            Else
                szRetVal = CUtilities.FormatPrice(m_dPrice)
            End If
            CUtilities = Nothing
            Return szRetVal
        End Get
    End Property
    Private m_szViews As String
    Public ReadOnly Property Views() As String
        Get
            Return m_szViews
        End Get
    End Property
    Private m_szLocation As String
    Public ReadOnly Property Location() As String
        Get
            Return m_szLocation
        End Get
    End Property
    Private m_szFeatures() As String
    Public ReadOnly Property Feature(ByVal nIndex As Integer) As String
        Get
            Return m_szFeatures(nIndex)
        End Get
    End Property
    Public ReadOnly Property Features As String
        Get

            ' Local Vars
            Dim szRetVal As String = String.Empty
            Dim szDelim As String = String.Empty

            ' For each Feature
            For Each szFeature As String In m_szFeatures

                ' If this is not Empty
                If szFeature.Trim <> String.Empty Then

                    ' Add this Feature
                    szRetVal &= szDelim & GetTranslation(szFeature)

                    ' Update Delimiter
                    szDelim = " - "

                End If

            Next

            ' Return the Result
            Return szRetVal

        End Get

    End Property
    'Private m_szPhotoIDs() As String
    'Private ReadOnly Property PhotoIDs() As String()
    '    Get
    '        Return m_szPhotoIDs
    '    End Get
    'End Property
    'Private m_szPhotoDescriptions() As String
    'Private ReadOnly Property PhotoDescriptions() As String()
    '    Get
    '        Return m_szPhotoDescriptions
    '    End Get
    'End Property
    Private m_dLatitude As Double
    Public ReadOnly Property Latitude() As Double
        Get
            Return m_dLatitude
        End Get
    End Property
    Private m_dLongitude As Double
    Public ReadOnly Property Longitude() As Double
        Get
            Return m_dLongitude
        End Get
    End Property
    Private m_nStatusID As Integer
    Public ReadOnly Property StatusID() As Integer
        Get
            Return m_nStatusID
        End Get
    End Property
    Public Function GoogleInfoWindowHTML() As String
        Return "<h2>Location: " & Location.Trim & "</h2>" &
            "<p><strong>" & Type.Trim & " (" & Reference.Trim & ")</strong></p>" &
            "<p><img src=""" & GetPhotoURL(1).Trim & """ alt=""Prop img"" width=""150"" height=""100""/></p>" &
            "<p><strong>Price:</strong> " & Price.Trim & "</p>" &
            "<p><a href=""https://www.inlandandalucia.com"" title=""InlandAndalucia.com"">InlandAndalucia.com</a></p>"
    End Function
    Public Function GetPhotoURL(ByVal nIndex As Integer) As String
        Dim szImageURL As String
        ' Set the File Pat
        If Not Reference = "" Then
            szImageURL = "/images/photos/properties/" & Reference & "/" & Reference & "_" & nIndex & ".jpg"
            ' If this is the Main Image

            'get isfeatured by reference
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@Property_ref", Reference)
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_IsFeatured_By_Reference", sql).Tables(0)


            If nIndex < 2 Then
                ' Apply Status Watermark
                Dim CUtilities As New ClassUtilities
                ' See if a Watermark is Required
                If dt.Rows.Count > 0 And StatusID <> 7 Then
                    szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, 20)
                Else
                    szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, StatusID)
                End If
                'get bannertype by reference
                Dim sqlbannertype As SqlParameter() = New SqlParameter(1) {}
                sqlbannertype(0) = New SqlParameter("@Property_ref", Reference)
                Dim dtbannertype As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Get_BannerType_By_PropertyRef", sqlbannertype).Tables(0)
                If dtbannertype.Rows.Count > 0 Then

                    If dtbannertype.Rows(0)("BannerType") <> "" And StatusID <> 7 Then
                        szImageURL = "/images/photos/properties/" & Reference & "/" & Reference & "_" & nIndex & ".jpg"
                        If dtbannertype.Rows(0)("BannerType") = "DIY Bargain" Then
                            szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, 1001)
                        End If

                        If dtbannertype.Rows(0)("BannerType") = "Now Negotiable" Then
                            szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, 1002)
                        End If

                        If dtbannertype.Rows(0)("BannerType") = "Reformed" Then
                            szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, 1003)
                        End If

                        If dtbannertype.Rows(0)("BannerType") = "Big Reduction" Then
                            szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, 1004)
                        End If
                        If dtbannertype.Rows(0)("BannerType") = "Rent To Buy Option" Then
                            szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, 1005)
                        End If
                        If dtbannertype.Rows(0)("BannerType") = "Reserved" Then
                            szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, 1006)
                        End If
                    End If
                End If

                ' Tidy
                CUtilities = Nothing
            End If
        End If
        ' Return the Result
        Return szImageURL
    End Function
    Public Function GetTranslation(ByVal szText As String, Optional ByVal nTargetLanguageID As Integer = 0) As String
        Dim CDataAccess As New ClassDataAccess
        Dim szRetVal As String
        ' If no Target Language has been Specified
        If nTargetLanguageID = 0 Then
            ' Default to selected Language
            szRetVal = CDataAccess.GetTranslation(szText, Session("Language")).Trim
        Else
            ' Use Target Language Specified
            szRetVal = CDataAccess.GetTranslation(szText, nTargetLanguageID).Trim
        End If
        CDataAccess = Nothing
        Return szRetVal
    End Function
    Public Function GetFlag() As String
        ' Local Vars
        Dim CUtilities As New ClassUtilities
        Dim szPath As String = String.Empty
        ' Depending on the Language
        Select Case CUtilities.GetLanguageID(Session("Language"))
            Case 1
                ' English
                szPath = "https://www.inlandandalucia.com//images/buttons/british_flag.jpg"
            Case 2
                ' Spanish
                szPath = "https://www.inlandandalucia.com//images/buttons/spanish_flag.jpg"
            Case 3
                ' French
                szPath = "https://www.inlandandalucia.com//images/buttons/french_flag.jpg"
            Case 4
                ' German
                szPath = "https://www.inlandandalucia.com//images/buttons/german_flag.jpg"
            Case 5
                ' Dutch
                szPath = "https://www.inlandandalucia.com//images/buttons/dutch_flag.jpg"
        End Select
        ' Return the Path
        Return szPath
    End Function
    Public Function GetSpanishFlag() As String
        Return "https://www.inlandandalucia.com//images/windowcard/spanish_flag.jpg"
    End Function
    Private Function GetHeaderImageURL() As String
        ' Local Var
        Dim szRetVal As String
        ' If we are not in Agent Area Mode
        If Session("ContactID") Is Nothing Then
            ' IA
            ' Depending on the Location
            Select Case Region
                Case "Antequera Area", "Malaga", "Sevilla"
                    ' Mollina Office
                    szRetVal = "https://www.inlandandalucia.com/images/windowcard/header-windowcard-mollina.jpg"
                Case Else
                    ' Alcala Office
                    szRetVal = "https://www.inlandandalucia.com/images/windowcard/header-windowcard-alcala.jpg"
            End Select
        Else
            ' Does this User have a Partner
            If Not Session("ContactPartnerID") Is Nothing Then
                ' If set to a Value
                If Convert.ToInt32(Session("ContactPartnerID")) > 0 Then
                    ' Not a Partner but using their Partner's Logo
                    szRetVal = "https://www.inlandandalucia.com/images/logos/p" & Session("ContactPartnerID").ToString.Trim & ".jpg"
                Else
                    szRetVal = "https://www.inlandandalucia.com/images/logos/p" & Session("ContactID").ToString.Trim & ".jpg"
                End If
            Else
                ' Init to his being a Partner, Return their URL
                szRetVal = "https://www.inlandandalucia.com/images/logos/p" & Session("ContactID").ToString.Trim & ".jpg"
            End If
        End If
        ' Return the Result
        Return szRetVal
    End Function
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim nPropertyID As Integer
        Dim CDataAccess As New ClassDataAccess
        'Code to get all same kind of data which we are getting by propertyid, instead of that get all data by property_ref from url
        If Not Request.QueryString("propertyref") Is Nothing Then
            ' User is Looking at Details of a Property
            ' Set the Property ID
            nPropertyID = CDataAccess.PropertyID(Request.QueryString("propertyref")).ToString.Trim
        Else
            nPropertyID = Convert.ToInt32(Request.QueryString("propertyid"))
        End If
        ' Depending on what is being Viewed
        'If Not Request.QueryString("propertyid") Is Nothing Then
        ' Local Vars
        Dim dtDataTable As DataTable
        Dim CUtilities As New ClassUtilities
        ' User is Looking at Details of a Property
        ' Get the IDs
        Dim nLanguageID As Integer = CUtilities.GetLanguageID(Session("Language"))
        ' Only if this Property Exists
        If CDataAccess.PropertyExists(nPropertyID) Then
            ' If we have a Partner ID
            If Session("ContactPartnerID") Is Nothing Then
                ' Get the Property Detail - No Partner ID
                dtDataTable = CDataAccess.PropertyDetail(CDataAccess.PropertyRef(nPropertyID), nLanguageID)
            Else
                ' Get the Property Detail - Partner ID
                dtDataTable = CDataAccess.PropertyDetail(CDataAccess.PropertyRef(nPropertyID), nLanguageID, Convert.ToInt32(Session("ContactPartnerID")))
            End If
            ' If we got some Results
            If dtDataTable.Rows.Count > 0 Then
                ' Assign to Vars
                m_nPropertyID = Convert.ToInt32(dtDataTable.Rows(0).Item("property_id"))
                m_szType = dtDataTable.Rows(0).Item("type").ToString.Trim
                m_szReference = dtDataTable.Rows(0).Item("reference").ToString.Trim
                m_szPartnerReference = dtDataTable.Rows(0).Item("partner_reference").ToString.Trim
                m_szRegion = dtDataTable.Rows(0).Item("region").ToString.Trim
                m_szArea = dtDataTable.Rows(0).Item("area").ToString.Trim
                m_szSubArea = dtDataTable.Rows(0).Item("subarea").ToString.Trim
                m_szDescription = dtDataTable.Rows(0).Item("description").ToString.Trim
                m_szDescriptionES = dtDataTable.Rows(0).Item("description_es").ToString.Trim
                m_szShortDescription = dtDataTable.Rows(0).Item("short_description").ToString.Trim
                m_nBedrooms = Convert.ToInt32(dtDataTable.Rows(0).Item("bedrooms"))
                m_nBathrooms = Convert.ToInt32(dtDataTable.Rows(0).Item("bathrooms"))
                m_nBuiltSize = Convert.ToInt32(dtDataTable.Rows(0).Item("sqm_built"))
                m_nPlotSize = Convert.ToInt32(dtDataTable.Rows(0).Item("sqm_plot"))
                m_dPrice = Convert.ToInt32(dtDataTable.Rows(0).Item("price"))
                m_dOriginalPrice = Convert.ToInt32(dtDataTable.Rows(0).Item("original_price"))
                m_szViews = GetTranslation(dtDataTable.Rows(0).Item("views").ToString)
                m_szLocation = dtDataTable.Rows(0).Item("location").ToString.Trim
                m_szFeatures = dtDataTable.Rows(0).Item("features").ToString.Trim.Split(",")
                'm_szPhotoIDs = dtDataTable.Rows(0).Item("photo_ids").ToString.Trim.Split(",")
                'm_szPhotoDescriptions = dtDataTable.Rows(0).Item("photo_descs").ToString.Trim.Split("~")
                m_dLatitude = Convert.ToDouble(dtDataTable.Rows(0).Item("latitude"))
                m_dLongitude = Convert.ToDouble(dtDataTable.Rows(0).Item("longitude"))
                m_nStatusID = Convert.ToInt32(dtDataTable.Rows(0).Item("status_id"))
                ' If Spanish
                If CUtilities.GetLanguageID(Session("Language")) = 2 Then
                    ' Spanish
                    WC_Area.InnerHtml = "Localidad"
                    WC_Baths.InnerHtml = GetTranslation("Baths")
                    WC_Beds.InnerHtml = GetTranslation("Beds")
                    WC_Built.InnerHtml = GetTranslation("Built")
                    WC_Features.InnerHtml = GetTranslation("Features")
                    WC_Location.InnerHtml = GetTranslation("Location")
                    WC_Plot.InnerHtml = GetTranslation("Plot")
                    WC_Price.InnerHtml = GetTranslation("Price")
                    'WC_Type.InnerHtml = GetTranslation("Type")
                    WC_Views.InnerHtml = GetTranslation("Views")
                    ' If we have an Original Price
                    If m_dOriginalPrice > 0 Then
                        WC_OriginalPrice.InnerHtml = GetTranslation("Before") & ": "
                    End If
                Else
                    ' Any other Language
                    'WC_Area.InnerHtml = GetTranslation("Area") & " / " & GetTranslation("Area", 2)
                    If CUtilities.GetLanguageID(Session("Language")) = 1 Then
                        WC_Area.InnerHtml = "Location / Localidad"
                    End If
                    If CUtilities.GetLanguageID(Session("Language")) = 3 Then
                        WC_Area.InnerHtml = "Localité / Localidad"
                    End If
                    If CUtilities.GetLanguageID(Session("Language")) = 4 Then
                        WC_Area.InnerHtml = "Plaats / Localidad"
                    End If
                    If CUtilities.GetLanguageID(Session("Language")) = 5 Then
                        WC_Area.InnerHtml = "Platz / Localidad"
                    End If
                    WC_Baths.InnerHtml = GetTranslation("Baths") & " / " & GetTranslation("Baths", 2)
                    WC_Beds.InnerHtml = GetTranslation("Beds") & " / " & GetTranslation("Beds", 2)
                    WC_Built.InnerHtml = GetTranslation("Built") & " / " & GetTranslation("Built", 2)
                    WC_Features.InnerHtml = GetTranslation("Features") & " / " & GetTranslation("Features", 2)
                    WC_Location.InnerHtml = GetTranslation("Location") & " / " & GetTranslation("Location", 2)
                    WC_Plot.InnerHtml = GetTranslation("Plot") & " / " & GetTranslation("Plot", 2)
                    WC_Price.InnerHtml = GetTranslation("Price") & " / " & GetTranslation("Price", 2)
                    'WC_Type.InnerHtml = GetTranslation("Type") & " / " & GetTranslation("Type", 2)
                    WC_Views.InnerHtml = GetTranslation("Views") & " / " & GetTranslation("Views", 2)
                    ' If we have an Original Price
                    If m_dOriginalPrice > 0 Then
                        WC_OriginalPrice.InnerHtml = GetTranslation("Before") & " / " & GetTranslation("Before", 2) & ": "
                    End If
                    '' If Required, Load Spanish Description SPAN
                    'If CUtilities.GetLanguageID(Session("Language")) <> 2 Then
                    '    ' Define HTML
                    '    'SpanishDescription = DescriptionES
                    'End If
                End If
                '' If this is a Partner
                'If Session("ContactType") Is Nothing Or Convert.ToInt32(Session("ContactType")) = 3 Or Convert.ToInt32(Session("ContactType")) = 4 Then
                ' Load QR Code
                ImageQRCode.ImageUrl = "https://chart.apis.google.com/chart?cht=qr&chs=100x100&chld=L|0&chl=https://www.inlandandalucia.com/propsearch.aspx?propertyid=" & PropertyID.ToString.Trim
                'End If
                ' Set Images
                ImageHeader.ImageUrl = GetHeaderImageURL()
                If Session("ContactId") Is Nothing And Session("ContactPartnerId") Is Nothing Then
                    ImageHeader.ImageUrl = "https://www.inlandandalucia.com/images/logos/p" & dtDataTable.Rows(0).Item("Partner_Id").ToString & ".jpg"
                End If

                ' Set Vars
                LabelReference.Text = Reference
                LabelPrice.Text = Price
                LabelOriginalPrice.Text = OriginalPrice
            End If
            ' Tidy
            dtDataTable.Dispose()
            CDataAccess = Nothing
            CUtilities = Nothing
        Else
            ' Tidy
            CDataAccess = Nothing
            CUtilities = Nothing
            ' Redirect to 404
            Response.Redirect("404.aspx")
        End If
        'End If
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    ' PDF
    '    ' Init Response
    '    Response.Clear()
    '    Response.Buffer = True
    '    Response.ContentType = "application/pdf"
    '    Response.AddHeader("content-disposition", "inline")
    '    'Response.AddHeader("content-disposition", "attachment; filename=" & Reference.Trim.ToUpper & ".pdf")
    '    Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '    ' Output as PDF
    '    Dim sw As StringWriter = New StringWriter()
    '    Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
    '    Me.Page.RenderControl(hw)
    '    Dim sr As StringReader = New StringReader(sw.ToString())
    '    Dim document As New Document(PageSize.A4, 25.0F, 25.0F, 25.0F, 25.0F)
    '    document.SetPageSize(iTextSharp.text.PageSize.A4)
    '    Dim writer As PdfWriter = PdfWriter.GetInstance(document, Response.OutputStream)
    '    document.Open()
    '    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr)
    '    document.Close()
    '    ' Tidy
    '    sw.Dispose()
    '    hw.Dispose()
    '    sr.Dispose()
    '    ' Return the Result
    '    Response.Write(document)
    '    Response.End()
    'End Sub
End Class
