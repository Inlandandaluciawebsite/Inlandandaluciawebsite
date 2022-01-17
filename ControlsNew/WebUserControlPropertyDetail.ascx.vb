Imports System.Data
Imports System.IO

Partial Class Controls_WebUserControlPropertyDetail
    Inherits System.Web.UI.UserControl

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
    Public ReadOnly Property Reference() As String
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

    Private m_nNumPhotos As Integer
    Private ReadOnly Property NumPhotos As Integer
        Get
            Return m_nNumPhotos
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

            If m_szSubArea Is Nothing Then
                Return String.Empty
            Else
                ' Remove a Sub Area of 'Not Specified'
                If m_szSubArea.ToLower.Trim = "not specified" Then
                    Return String.Empty
                Else
                    Return " / " & m_szSubArea.Trim
                End If
            End If

        End Get
    End Property

    Private m_szDescription As String
    Public ReadOnly Property Description() As String
        Get
            Return m_szDescription
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
    Public ReadOnly Property BuiltSize() As Integer
        Get
            Return m_nBuiltSize
        End Get
    End Property

    Private m_nPlotSize As Integer
    Public ReadOnly Property PlotSize() As Integer
        Get
            Return m_nPlotSize
        End Get
    End Property

    Private m_dOriginalPrice As Double
    Public ReadOnly Property OriginalPrice() As String
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
    Public ReadOnly Property Price() As String
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

            ' If we have Features
            If Not m_szFeatures Is Nothing Then

                ' For each Feature
                For Each szFeature As String In m_szFeatures

                    ' If this is not Empty
                    If szFeature.Trim <> String.Empty Then

                        ' Add this Feature
                        szRetVal &= szDelim & szFeature.Replace("''", "'").Trim

                        ' Update Delimiter
                        szDelim = ", "

                    End If

                Next

            End If

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

    Private m_szVideoURL As String
    Public ReadOnly Property VideoURL() As String
        Get
            Return m_szVideoURL
        End Get
    End Property

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

        ' Local Vars
        Dim CUtilities As New ClassUtilities

        ' See if a Watermark is Required
        Dim szImageURL As String = CUtilities.ApplyStatusWatermark(GetMainPhotoURL, StatusID)

        ' Tidy
        CUtilities = Nothing

        ' Init HTML
        Return "<h2>Location: " & Location.Trim & "</h2>" & _
            "<p><strong>" & Type.Trim & " (" & Reference.Trim & ")</strong></p>" & _
            "<p><img src=""" & szImageURL.Trim & """ alt=""Property Image"" width=""150"" height=""100""/></p>" & _
            "<p><strong>Price:</strong> " & Price.Trim & "</p>" & _
            "<p><a href=""http://www.inlandandalucia.com"" title=""InlandAndalucia.com"">InlandAndalucia.com</a></p>"

    End Function

    Private Function GetMainPhotoURL() As String

        ' Set the File Path
        Return "/images/photos/properties/" & Reference.Trim & "/" & Reference.Trim & "_1.jpg"

    End Function

    Private Sub LoadPhotos()

        ' Local Vars
        Dim szPhotoDescription As String
        Dim nCounter As Integer
        Dim CUtilities As New ClassUtilities
        Dim szImageURL As String

        ' Init HTML
        Photos.InnerHtml = "<ul id=""slideshow"">"

        ' For each Picture
        For nCounter = 1 To NumPhotos

            ' If the File Exists
            If File.Exists(Server.MapPath("~/images/photos/properties/" & Reference.Trim & "/" & Reference.Trim & "_" & nCounter.ToString.Trim & ".jpg")) Then

                ' Just Add the Picture Number
                szPhotoDescription = "Picture " & nCounter.ToString.Trim

                ' Prep Image            

                ' Init URL
                szImageURL = "/images/photos/properties/" & Reference.Trim & "/" & Reference.Trim & "_" & nCounter.ToString.Trim & ".jpg"

                ' If this is the Main Image
                If nCounter < 2 Then

                    ' See if a Watermark is Required
                    szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, StatusID)

                End If

                ' Add Image Title
                Photos.InnerHtml &= "<li><h3>" & szPhotoDescription.Trim & "</h3>"
                Photos.InnerHtml &= "<span>" & szImageURL.Trim & "</span><p>&copy; InlandAndalucia</p>"
                Photos.InnerHtml &= "<a href=""" & szImageURL.Trim & """><img src=""" & szImageURL.Trim & """ id=""sliderthumb""/></a>"
                'Photos.InnerHtml &= "<span>/images/photos/properties/" & Reference.Trim & "/" & Reference.Trim & "_" & nCounter.ToString.Trim & ".jpg</span><p>&copy; InlandAndalucia</p>"
                'Photos.InnerHtml &= "<a href=""/images/photos/properties/" & Reference.Trim & "/" & Reference.Trim & "_" & nCounter.ToString.Trim & ".jpg""><img src=""/images/photos/properties/" & Reference.Trim & "/" & Reference.Trim & "_" & nCounter.ToString.Trim & ".jpg"" id=""sliderthumb""/></a>"
                Photos.InnerHtml &= "</li>"

            End If

        Next

        ' Tidy
        CUtilities = Nothing

        ' Close HTML
        Photos.InnerHtml &= "</ul>"
        Photos.InnerHtml &= "<div id=""wrapper"">"
        Photos.InnerHtml &= "<div id=""fullsize"">"
        Photos.InnerHtml &= "<div id=""imgprev"" class=""imgnav"" title=""" & GetTranslation("Previous Image") & """></div>"
        Photos.InnerHtml &= "<div id=""imglink""></div>"
        Photos.InnerHtml &= "<div id=""imgnext"" class=""imgnav"" title=""" & GetTranslation("Next Image") & """></div>"
        Photos.InnerHtml &= "<div id=""image""></div>"
        Photos.InnerHtml &= "<div id=""information"">"
        Photos.InnerHtml &= "<h3></h3>"
        Photos.InnerHtml &= "<p></p>"
        Photos.InnerHtml &= "</div>"
        Photos.InnerHtml &= "</div>"
        Photos.InnerHtml &= "<div id=""thumbnails"">"
        Photos.InnerHtml &= "<div id=""slideleft"" title=""Slide Left""></div>"
        Photos.InnerHtml &= "<div id=""slidearea"">"
        Photos.InnerHtml &= "<div id=""slider""></div>"
        Photos.InnerHtml &= "</div>"
        Photos.InnerHtml &= "<div id=""slideright"" title=""Slide Right""></div>"
        Photos.InnerHtml &= "</div>"
        Photos.InnerHtml &= "</div>"

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If not Postback
        If Not Page.IsPostBack Then

            ' If we are looking at a Property
            If Not Session("ViewPropertyID") Is Nothing Then

                ' Local Vars
                Dim CUtilities As New ClassUtilities
                Dim dtDataTable As DataTable

                ' Get the IDs
                Dim nPropertyID As Integer = Convert.ToInt32(Session("ViewPropertyID"))
                Dim nLanguageID As Integer = CUtilities.GetLanguageID(Session("Language"))

                ' Tidy
                CUtilities = Nothing

                ' Define Data Access
                Dim CDataAccess As New ClassDataAccess

                ' If we have a Partner ID
                If Session("ContactPartnerID") Is Nothing Then

                    ' Get the Property Detail - No Partner ID
                    dtDataTable = CDataAccess.PropertyDetail(CDataAccess.PropertyRef(nPropertyID), nLanguageID)

                    ' Audit Public Viewing
                    CDataAccess.AuditPropertyViewed(nPropertyID)

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
                    m_nNumPhotos = Convert.ToInt32(dtDataTable.Rows(0).Item("photos"))
                    m_szPartnerReference = dtDataTable.Rows(0).Item("partner_reference").ToString.Trim
                    m_szRegion = dtDataTable.Rows(0).Item("region").ToString.Trim
                    m_szArea = dtDataTable.Rows(0).Item("area").ToString.Trim
                    m_szSubArea = dtDataTable.Rows(0).Item("subarea").ToString.Trim
                    m_szDescription = dtDataTable.Rows(0).Item("description").ToString.Trim
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
                    m_szVideoURL = dtDataTable.Rows(0).Item("video_url").ToString.Trim
                    m_dLatitude = Convert.ToDouble(dtDataTable.Rows(0).Item("latitude"))
                    m_dLongitude = Convert.ToDouble(dtDataTable.Rows(0).Item("longitude"))
                    m_nStatusID = dtDataTable.Rows(0).Item("status_id").ToString.Trim

                    ' Load Photos of Property
                    LoadPhotos()

                End If

                ' Tidy
                dtDataTable.Dispose()
                CDataAccess = Nothing

                ' Check Video URL is not NULL
                If Not VideoURL Is Nothing Then

                    ' If there is a Video to Watch
                    If VideoURL.Trim <> String.Empty Then

                        ' Add the Video Button
                        Video.InnerHtml = "<a href='https://youtube.googleapis.com/v/" & VideoURL.Trim & "%26autoplay=1' target=""_blank""><img src=""" & GetVideoImagePath() & """ alt=""Video"" border=""0"" hspace=""5"" /></a>"

                    End If

                End If

                ' If we are not in Agent Area Mode
                If Session("ContactID") Is Nothing Then

                    ' Init Email Tag
                    If Not String.IsNullOrEmpty(Request.QueryString("propertyref")) Then
                        Email.InnerHtml = "<a href='mailto:&subject=" & GetTranslation("Property of Interest", True) & "&body=" & GetTranslation("Hi", True) & "%0A%0A" & GetTranslation("I have just been on www.inlandandalucia.com and I saw this property which I thought may be of interest to you", True) & ":%0A%0Ahttp://www.inlandandalucia.com/propsearch.aspx%3Fpropertyref=" & Request.QueryString("propertyref").ToString() & "%0A%0A" & GetTranslation("Regards", True) & "%0A%0A'><img src=""" & GetEmailImagePath() & """ alt=""Email"" border=""0"" hspace=""5"" /></a>"
                    Else
                        Email.InnerHtml = "<a href='mailto:&subject=" & GetTranslation("Property of Interest", True) & "&body=" & GetTranslation("Hi", True) & "%0A%0A" & GetTranslation("I have just been on www.inlandandalucia.com and I saw this property which I thought may be of interest to you", True) & ":%0A%0Ahttp://www.inlandandalucia.com/propsearch.aspx%3Fpropertyid=" & PropertyID.ToString.Trim & "%0A%0A" & GetTranslation("Regards", True) & "%0A%0A'><img src=""" & GetEmailImagePath() & """ alt=""Email"" border=""0"" hspace=""5"" /></a>"
                    End If



                    ' Define the Contact Us Button
                    ContactUs.InnerHtml = "<a href='contactus.aspx?reference=" & Reference & "'><img src=""" & GetContactUsImagePath() & """ alt=""Contact us"" hspace=""5"" /></a>"

                End If

            End If

        End If

    End Sub

    Public Function GetVideoImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

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

    Public Function GetBackImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "back-ES.gif"

            Case 3
                ' French
                szRetVal &= "back-FR.gif"

            Case 4
                ' German
                szRetVal &= "back-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "back-NL.gif"

            Case Else
                ' English
                szRetVal &= "back.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Public Function GetPrintImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "print-preview-ES.gif"

            Case 3
                ' French
                szRetVal &= "print-preview-FR.gif"

            Case 4
                ' German
                szRetVal &= "print-preview-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "print-preview-NL.gif"

            Case Else
                ' English
                szRetVal &= "print-preview.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Private Function GetEmailImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "email-ES.gif"

            Case 3
                ' French
                szRetVal &= "email-FR.gif"

            Case 4
                ' German
                szRetVal &= "email-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "email-NL.gif"

            Case Else
                ' English
                szRetVal &= "email.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Public Function GetContactUsImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "contact-us-ES.gif"

            Case 3
                ' French
                szRetVal &= "contact-us-FR.gif"

            Case 4
                ' German
                szRetVal &= "contact-us-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "contact-us-NL.gif"

            Case Else
                ' English
                szRetVal &= "contact-us.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Public Function GetTranslation(ByVal szText As String, Optional ByVal bHTMLSafe As Boolean = False) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language"), bHTMLSafe).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

End Class

