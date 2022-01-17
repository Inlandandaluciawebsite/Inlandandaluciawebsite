Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Threading
Imports HashSoftwares

Public Class ClassProperty

#Region "General Properties"

    Private m_szAddress As String
    Public Property Address() As String
        Get
            Return m_szAddress
        End Get
        Set(ByVal value As String)
            m_szAddress = value
        End Set
    End Property
    Private m_szTaxablevalue As String
    Public Property Taxablevalue() As String
        Get
            Return m_szTaxablevalue
        End Get
        Set(ByVal value As String)
            m_szTaxablevalue = value
        End Set
    End Property
    Private m_dAnnualIBI As Double
    Public Property AnnualIBI() As Double
        Get
            Return m_dAnnualIBI
        End Get
        Set(ByVal value As Double)
            m_dAnnualIBI = value
        End Set
    End Property
    Private m_dAnnualRubbish As Double
    Public Property AnnualRubbish() As Double
        Get
            Return m_dAnnualRubbish
        End Get
        Set(ByVal value As Double)
            m_dAnnualRubbish = value
        End Set
    End Property
    Private m_nAreaID As Integer
    Public Property AreaID() As Integer
        Get
            Return m_nAreaID
        End Get
        Set(ByVal value As Integer)
            m_nAreaID = value
        End Set
    End Property

    Private m_szAreaName As String
    Public Property AreaName() As String
        Get
            Return m_szAreaName
        End Get
        Set(ByVal value As String)
            m_szAreaName = value
        End Set
    End Property

    Private m_nBathrooms As Integer
    Public Property Bathrooms() As Integer
        Get
            Return m_nBathrooms
        End Get
        Set(ByVal value As Integer)
            m_nBathrooms = value
        End Set
    End Property

    Private m_nBedrooms As Integer
    Public Property Bedrooms() As Integer
        Get
            Return m_nBedrooms
        End Get
        Set(ByVal value As Integer)
            m_nBedrooms = value
        End Set
    End Property

    Private m_nBrokerID As Integer
    Public Property BrokerID() As Integer
        Get
            Return m_nBrokerID
        End Get
        Set(ByVal value As Integer)
            m_nBrokerID = value
        End Set
    End Property

    Private m_nBuilt As Integer
    Public Property Built() As Integer
        Get
            Return m_nBuilt
        End Get
        Set(ByVal value As Integer)
            m_nBuilt = value
        End Set
    End Property

    Private m_nBuyerID As Integer
    Public Property BuyerID() As Integer
        Get
            Return m_nBuyerID
        End Get
        Set(ByVal value As Integer)
            m_nBuyerID = value
        End Set
    End Property

    Private m_nBuyerLawyerID As Integer
    Public Property BuyerLawyerID() As Integer
        Get
            Return m_nBuyerLawyerID
        End Get
        Set(ByVal value As Integer)
            m_nBuyerLawyerID = value
        End Set
    End Property

    Private m_szCAReference As String
    Public Property CAReference() As String
        Get
            Return m_szCAReference
        End Get
        Set(ByVal value As String)
            m_szCAReference = value
        End Set
    End Property

    Private m_dCommunityFees As Double
    Public Property CommunityFees() As Double
        Get
            Return m_dCommunityFees
        End Get
        Set(ByVal value As Double)
            m_dCommunityFees = value
        End Set
    End Property

    Private m_nCountryID As Integer
    Public Property CountryID() As Integer
        Get
            Return m_nCountryID
        End Get
        Set(ByVal value As Integer)
            m_nCountryID = value
        End Set
    End Property

    Private m_bDisplay As Boolean
    Public Property Display() As Boolean
        Get
            Return m_bDisplay
        End Get
        Set(ByVal value As Boolean)
            m_bDisplay = value
        End Set
    End Property

    Private m_szDoorKey As String
    Public Property DoorKey() As String
        Get
            Return m_szDoorKey.Trim.ToUpper
        End Get
        Set(ByVal value As String)
            m_szDoorKey = value
        End Set
    End Property

    Private m_nEnSuite As Integer
    Public Property EnSuite() As Integer
        Get
            Return m_nEnSuite
        End Get
        Set(ByVal value As Integer)
            m_nEnSuite = value
        End Set
    End Property

    Private m_bFeatured As Boolean
    Public Property Featured() As Boolean
        Get
            Return m_bFeatured
        End Get
        Set(ByVal value As Boolean)
            m_bFeatured = value
        End Set
    End Property

    Private m_lstFeatureIDs As List(Of Int32)
    Public Property FeatureIDs() As List(Of Int32)
        Get
            Return m_lstFeatureIDs
        End Get
        Set(ByVal value As List(Of Int32))
            m_lstFeatureIDs = value
        End Set
    End Property

    Private m_nHistoryTypeID As Integer
    Public Property HistoryTypeID() As Integer
        Get
            Return m_nHistoryTypeID
        End Get
        Set(ByVal value As Integer)
            m_nHistoryTypeID = value
        End Set
    End Property

    Private m_CImages As ClassImages
    Public Property Images() As ClassImages
        Get
            Return m_CImages
        End Get
        Set(ByVal value As ClassImages)
            m_CImages = value
        End Set
    End Property

    Private m_dLatitude As Double
    Public Property Latitude() As Double
        Get
            Return m_dLatitude
        End Get
        Set(ByVal value As Double)
            m_dLatitude = value
        End Set
    End Property

    Private m_nLocationID As Integer
    Public Property LocationID() As Integer
        Get
            Return m_nLocationID
        End Get
        Set(ByVal value As Integer)
            m_nLocationID = value
        End Set
    End Property

    Private m_dLongitude As Double
    Public Property Longitude() As Double
        Get
            Return m_dLongitude
        End Get
        Set(ByVal value As Double)
            m_dLongitude = value
        End Set
    End Property

    Private m_szHistory As String
    Public Property History() As String
        Get
            Return m_szHistory
        End Get
        Set(ByVal value As String)
            m_szHistory = value
        End Set
    End Property

    Private m_nID As Integer
    Public Property ID() As Integer
        Get
            Return m_nID
        End Get
        Set(ByVal value As Integer)
            m_nID = value
        End Set
    End Property

    Private m_nNumberOfImages As Integer
    Public Property NumberOfImages() As Integer
        Get
            Return m_nNumberOfImages
        End Get
        Set(ByVal value As Integer)
            m_nNumberOfImages = value
        End Set
    End Property

    Private m_nOriginalPrice As Integer
    Public Property OriginalPrice() As Integer
        Get
            Return m_nOriginalPrice
        End Get
        Set(ByVal value As Integer)
            m_nOriginalPrice = value
        End Set
    End Property

    Private m_nPartnerID As Integer
    Public Property PartnerID() As Integer
        Get
            Return m_nPartnerID
        End Get
        Set(ByVal value As Integer)
            m_nPartnerID = value
        End Set
    End Property

    Private m_nPlot As Integer
    Public Property Plot() As Integer
        Get
            Return m_nPlot
        End Get
        Set(ByVal value As Integer)
            m_nPlot = value
        End Set
    End Property

    Private m_nPostcodeID As Integer
    Public Property PostcodeID() As Integer
        Get
            Return m_nPostcodeID
        End Get
        Set(ByVal value As Integer)
            m_nPostcodeID = value
        End Set
    End Property

    Private m_nPublicPrice As Integer
    Public Property PublicPrice() As Integer
        Get
            Return m_nPublicPrice
        End Get
        Set(ByVal value As Integer)
            m_nPublicPrice = value
        End Set
    End Property

    Private m_szReference As String
    Public Property Reference() As String
        Get
            Return m_szReference
        End Get
        Set(ByVal value As String)
            m_szReference = value
        End Set
    End Property

    Private m_nRegionID As Integer
    Public Property RegionID() As Integer
        Get
            Return m_nRegionID
        End Get
        Set(ByVal value As Integer)
            m_nRegionID = value
        End Set
    End Property

    Private m_nStatusID As Integer
    Public Property StatusID() As Integer
        Get
            Return m_nStatusID
        End Get
        Set(ByVal value As Integer)
            m_nStatusID = value
        End Set
    End Property

    Private m_nSubAreaID As Integer
    Public Property SubAreaID() As Integer
        Get
            Return m_nSubAreaID
        End Get
        Set(ByVal value As Integer)
            m_nSubAreaID = value
        End Set
    End Property

    Private m_nTerrace As Integer
    Public Property Terrace() As Integer
        Get
            Return m_nTerrace
        End Get
        Set(ByVal value As Integer)
            m_nTerrace = value
        End Set
    End Property

    Private m_nTypeID As Integer
    Public Property TypeID() As Integer
        Get
            Return m_nTypeID
        End Get
        Set(ByVal value As Integer)
            m_nTypeID = value
        End Set
    End Property

    Private m_nVendorID As Integer
    Public Property VendorID() As Integer
        Get
            Return m_nVendorID
        End Get
        Set(ByVal value As Integer)
            m_nVendorID = value
        End Set
    End Property

    Private m_nVendorLawyerID As Integer
    Public Property VendorLawyerID() As Integer
        Get
            Return m_nVendorLawyerID
        End Get
        Set(ByVal value As Integer)
            m_nVendorLawyerID = value
        End Set
    End Property

    Private m_dVendorPrice As Double
    Public Property VendorPrice() As Double
        Get
            Return m_dVendorPrice
        End Get
        Set(ByVal value As Double)
            m_dVendorPrice = value
        End Set
    End Property

    Private m_nViewsID As Integer
    Public Property ViewsID() As Integer
        Get
            Return m_nViewsID
        End Get
        Set(ByVal value As Integer)
            m_nViewsID = value
        End Set
    End Property

    Private m_nYearConstructed As Integer
    Public Property YearConstructed() As Integer
        Get
            Return m_nYearConstructed
        End Get
        Set(ByVal value As Integer)
            m_nYearConstructed = value
        End Set
    End Property

    Private m_szYouTubeVideoID As String
    Public Property YouTubeVideoID() As String
        Get
            Return m_szYouTubeVideoID
        End Get
        Set(ByVal value As String)
            m_szYouTubeVideoID = value
        End Set
    End Property
    Private m_IsIssue As Boolean
    Public Property IsIssue() As Boolean
        Get
            Return m_IsIssue
        End Get
        Set(ByVal value As Boolean)
            m_IsIssue = value
        End Set
    End Property
    Private m_BannerType As String
    Public Property BannerType() As String
        Get
            Return m_BannerType
        End Get
        Set(ByVal value As String)
            m_BannerType = value
        End Set
    End Property
    Private m_ListedBy As String
    Public Property ListedBy() As String
        Get
            Return m_ListedBy
        End Get
        Set(ByVal value As String)
            m_ListedBy = value
        End Set
    End Property
    Private m_ListedByPartner As String
    Public Property ListedByPartner() As String
        Get
            Return m_ListedByPartner
        End Get
        Set(ByVal value As String)
            m_ListedByPartner = value
        End Set
    End Property
    'Private m_History_Subject_To_Id As Integer
    'Public Property History_Subject_To_Id() As Integer
    '    Get
    '        Return m_History_Subject_To_Id
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_History_Subject_To_Id = value
    '    End Set
    'End Property
    'Private m_HistorySubjectType As String
    'Public Property HistorySubjectType() As String
    '    Get
    '        Return m_HistorySubjectType
    '    End Get
    '    Set(ByVal value As String)
    '        m_HistorySubjectType = value
    '    End Set
    'End Property
    'Private m_HistoryExpiryDate As String
    'Public Property HistoryExpiryDate() As String
    '    Get
    '        Return m_HistoryExpiryDate
    '    End Get
    '    Set(ByVal value As String)
    '        m_HistoryExpiryDate = value
    '    End Set
    'End Property
    'Private m_BuyerForename As String
    'Public Property BuyerForename() As String
    '    Get
    '        Return m_BuyerForename
    '    End Get
    '    Set(ByVal value As String)
    '        m_BuyerForename = value
    '    End Set
    'End Property
    'Private m_BuyerSurname As String
    'Public Property BuyerSurname() As String
    '    Get
    '        Return m_BuyerSurname
    '    End Get
    '    Set(ByVal value As String)
    '        m_BuyerSurname = value
    '    End Set
    'End Property
    Private m_Listed_By_Contact_ID As Integer
    Public Property Listed_By_Contact_ID() As Integer
        Get
            Return m_Listed_By_Contact_ID
        End Get
        Set(ByVal value As Integer)
            m_Listed_By_Contact_ID = value
        End Set
    End Property
    Private m_LContactId As Integer
    Public Property LContactId() As Integer
        Get
            Return m_LContactId
        End Get
        Set(ByVal value As Integer)
            m_LContactId = value
        End Set
    End Property
#End Region

#Region "Description Properties"

    Private m_htShortDescription As Hashtable
    Public ReadOnly Property ShortDescription() As Hashtable
        Get
            Return m_htShortDescription
        End Get
    End Property

    Private m_htDescription As Hashtable
    Public ReadOnly Property Description() As Hashtable
        Get
            Return m_htDescription
        End Get
    End Property

#End Region

    '#Region "Loading Flags"

    '    Private m_bOverviewLoaded As Boolean
    '    Public Property OverviewLoaded() As Boolean
    '        Get
    '            Return m_bOverviewLoaded
    '        End Get
    '        Set(ByVal value As Boolean)
    '            m_bOverviewLoaded = value
    '        End Set
    '    End Property

    '    Private m_bGeneralLoaded As Boolean
    '    Public Property GeneralLoaded() As Boolean
    '        Get
    '            Return m_bGeneralLoaded
    '        End Get
    '        Set(ByVal value As Boolean)
    '            m_bGeneralLoaded = value
    '        End Set
    '    End Property

    '    Private m_bDescriptionLoaded As Boolean
    '    Public Property DescriptionLoaded() As Boolean
    '        Get
    '            Return m_bDescriptionLoaded
    '        End Get
    '        Set(ByVal value As Boolean)
    '            m_bDescriptionLoaded = value
    '        End Set
    '    End Property

    '    Private m_bImagesLoaded As Boolean
    '    Public Property ImagesLoaded() As Boolean
    '        Get
    '            Return m_bImagesLoaded
    '        End Get
    '        Set(ByVal value As Boolean)
    '            m_bImagesLoaded = value
    '        End Set
    '    End Property

    '    Private m_bFeaturesLoaded As Boolean
    '    Public Property FeaturesLoaded() As Boolean
    '        Get
    '            Return m_bFeaturesLoaded
    '        End Get
    '        Set(ByVal value As Boolean)
    '            m_bFeaturesLoaded = value
    '        End Set
    '    End Property

    '    Private m_bHistoryLoaded As Boolean
    '    Public Property HistoryLoaded() As Boolean
    '        Get
    '            Return m_bHistoryLoaded
    '        End Get
    '        Set(ByVal value As Boolean)
    '            m_bHistoryLoaded = value
    '        End Set
    '    End Property

    '    Private m_bDocumentsLoaded As Boolean
    '    Public Property DocumentsLoaded() As Boolean
    '        Get
    '            Return m_bDocumentsLoaded
    '        End Get
    '        Set(ByVal value As Boolean)
    '            m_bDocumentsLoaded = value
    '        End Set
    '    End Property

    '#End Region
    Public Function SaveNew(ByVal nUserID As Integer, ByVal nPartnerID As Integer) As Boolean

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim de As DictionaryEntry
        Dim nImage As Integer = 0
        Dim szFiles() As String
        Dim szFile As String
        Dim bError As Boolean

        ' If this is not IA
        'If nPartnerID <> 3873 And nPartnerID <> 3864 Then

        '    ' Get our Reference for this Property
        '    Reference = CDataAccess.PropertyIARef(nPartnerID, Reference)

        'End If

        ' GENERAL, IMAGES & FEATURED

        ' Init SQL
        Dim szSQL As String =
            "merge property as target using " &
            "(" &
                "select " &
                    "'" & Address.Trim & "', " &
                    AnnualIBI.ToString.Trim & ", " &
                    AnnualRubbish.ToString.Trim & ", " &
                    Bathrooms.ToString.Trim & ", " &
                    Bedrooms.ToString.Trim & ", " &
                    BrokerID.ToString.Trim & ", " &
                    Built.ToString.Trim & ", " &
                    BuyerID.ToString.Trim & ", " &
                    BuyerLawyerID.ToString.Trim & ", " &
                    CommunityFees.ToString.Trim & ", " &
                    CountryID.ToString.Trim & ", " &
                    CDataAccess.SQLBoolean(Display).Trim & ", " &
                    "'" & DoorKey.Trim & "', " &
                    EnSuite.ToString.Trim & ", " &
                    Latitude.ToString.Trim & ", " &
                    LocationID.ToString.Trim & ", " &
                    Longitude.ToString.Trim & ", " &
                    Images.Count.ToString.Trim & ", " &
                    OriginalPrice.ToString.Trim & ", " &
                    PartnerID.ToString.Trim & ", " &
                    Plot.ToString.Trim & ", " &
                    PostcodeID.ToString.Trim & ", " &
                    "'" & Reference.Trim.ToUpper & "', " &
                    PublicPrice.ToString.Trim & ", " &
                    StatusID.ToString.Trim & ", " &
                    Terrace.ToString.Trim & ", " &
                    TypeID.ToString.Trim & ", " &
                    VendorID.ToString.Trim & ", " &
                    VendorLawyerID.ToString.Trim & ", " &
                    VendorPrice.ToString.Trim & ", " &
                    ViewsID.ToString.Trim & ", " &
                    YearConstructed.ToString.Trim & ", " &
                    "'" & YouTubeVideoID.ToString.Trim & "'," &
                    CDataAccess.SQLDateTime(Now) & ", " &
                    "'" & Taxablevalue.Trim & "' , " &
                     CDataAccess.SQLBoolean(IsIssue).Trim & ", " &
                     "'" & BannerType & ", " &
                     Listed_By_Contact_ID.ToString() & "' " &
                 ") " &
            "as source " &
            "(" &
                "property_address, " &
                "annual_ibi, " &
                "annual_rubbish, " &
                "bathrooms, " &
                "bedrooms, " &
                "broker_id, " &
                "sqm_built, " &
                "buyer_id, " &
                "buyer_lawyer_id, " &
                "community_fees, " &
                "country_id, " &
                "display, " &
                "door_key, " &
                "sqm_en_suite, " &
                "gps_latitude, " &
                "location_id, " &
                "gps_longitude, " &
                "num_photos, " &
                "original_price, " &
                "partner_id, " &
                "sqm_plot, " &
                "postcode_id, " &
                "property_ref, " &
                "public_price, " &
                "status_id, " &
                "sqm_terrace, " &
                "property_type_id, " &
                "vendor_id, " &
                "vendor_lawyer_id, " &
                "vendor_price, " &
                "views_id, " &
                "year_constructed, " &
                "video_url, " &
                "last_modified, " &
                "Property_Notes ," &
                  "IsIssue," &
                  "BannerType," &
                  "Listed_By_Contact_ID" &
             ") " &
            "on target.property_ref = source.property_ref " &
            "when matched then " &
                "update set " &
                    "property_address = source.property_address, " &
                    "annual_ibi = source.annual_ibi, " &
                    "annual_rubbish = source.annual_rubbish, " &
                    "bathrooms = source.bathrooms, " &
                    "bedrooms = source.bedrooms, " &
                    "broker_id = source.broker_id, " &
                    "sqm_built = source.sqm_built, " &
                    "buyer_id = source.buyer_id, " &
                    "buyer_lawyer_id = source.buyer_lawyer_id, " &
                    "community_fees = source.community_fees, " &
                    "country_id = source.country_id, " &
                    "display = source.display, " &
                    "door_key = source.door_key, " &
                    "sqm_en_suite = source.sqm_en_suite, " &
                    "gps_latitude = source.gps_latitude, " &
                    "location_id = source.location_id, " &
                    "gps_longitude = source.gps_longitude, " &
                    "num_photos = source.num_photos, " &
                    "original_price = source.original_price, " &
                    "partner_id = source.partner_id, " &
                    "sqm_plot = source.sqm_plot, " &
                    "postcode_id = source.postcode_id, " &
                    "public_price = source.public_price, " &
                    "status_id = source.status_id, " &
                    "sqm_terrace = source.sqm_terrace, " &
                    "property_type_id = source.property_type_id, " &
                    "vendor_id = source.vendor_id, " &
                    "vendor_lawyer_id = source.vendor_lawyer_id, " &
                    "vendor_price = source.vendor_price, " &
                    "views_id = source.views_id, " &
                    "year_constructed = source.year_constructed, " &
                    "video_url = source.video_url, " &
                    "last_modified = source.last_modified, " &
                       "Property_Notes = source.Property_Notes ," &
                         "IsIssue = source.IsIssue ," &
                         "BannerType = source.BannerType ," &
                         "Listed_By_Contact_ID = source.Listed_By_Contact_ID " &
            "when not matched then " &
                "insert " &
                "(" &
                    "property_address, " &
                    "annual_ibi, " &
                    "annual_rubbish, " &
                    "bathrooms, " &
                    "bedrooms, " &
                    "broker_id, " &
                    "sqm_built, " &
                    "buyer_id, " &
                    "buyer_lawyer_id, " &
                    "community_fees, " &
                    "country_id, " &
                    "display, " &
                    "door_key, " &
                    "sqm_en_suite, " &
                    "gps_latitude, " &
                    "location_id, " &
                    "gps_longitude, " &
                    "num_photos, " &
                    "original_price, " &
                    "partner_id, " &
                    "sqm_plot, " &
                    "postcode_id, " &
                    "property_ref, " &
                    "public_price, " &
                    "status_id, " &
                    "sqm_terrace, " &
                    "property_type_id, " &
                    "vendor_id, " &
                    "vendor_lawyer_id, " &
                    "vendor_price, " &
                    "views_id, " &
                    "year_constructed, " &
                    "video_url, " &
                    "create_date, " &
                    "last_modified, " &
                    "Property_Notes ," &
                    "IsIssue," &
                    "BannerType," &
                    "Listed_By_Contact_ID" &
                ") " &
                "values " &
                "(" &
                    "source.property_address, " &
                    "source.annual_ibi, " &
                    "source.annual_rubbish, " &
                    "source.bathrooms, " &
                    "source.bedrooms, " &
                    "source.broker_id, " &
                    "source.sqm_built, " &
                    "source.buyer_id, " &
                    "source.buyer_lawyer_id, " &
                    "source.community_fees, " &
                    "source.country_id, " &
                    "source.display, " &
                    "source.door_key, " &
                    "source.sqm_en_suite, " &
                    "source.gps_latitude, " &
                    "source.location_id, " &
                    "source.gps_longitude, " &
                    "source.num_photos, " &
                    "source.original_price, " &
                    "source.partner_id, " &
                    "source.sqm_plot, " &
                    "source.postcode_id, " &
                    "source.property_ref, " &
                    "source.public_price, " &
                    "source.status_id, " &
                    "source.sqm_terrace, " &
                    "source.property_type_id, " &
                    "source.vendor_id, " &
                    "source.vendor_lawyer_id, " &
                    "source.vendor_price, " &
                    "source.views_id, " &
                    "source.year_constructed, " &
                    "source.video_url, " &
                    "source.last_modified, " &
                    "source.last_modified, " &
                    "source.Property_Notes ," &
                     "source.IsIssue, " &
                     "source.BannerType, " &
                     "source.Listed_By_Contact_ID " &
                ");"

        ' Featured Property Status - if Featured and For Sale
        'If Featured And StatusID = 2 Then

        '    szSQL &= "if not exists (select property_ref from FEATURED_PROPERTY where LTRIM(RTRIM(upper(property_ref))) = '" & Reference.Trim.ToUpper & "') " &
        '                "insert into FEATURED_PROPERTY (Property_Ref, Sort_Order) values ('" & Reference.Trim.ToUpper & "', (select MAX(sort_order) + 1 from FEATURED_PROPERTY))"

        'Else

        '    ' Delete any Entries
        '    szSQL &= "delete from featured_property where ltrim(rtrim(upper(property_ref))) = '" & Reference.Trim.ToUpper & "';"

        'End If

        ' Run the Update
        bError = CDataAccess.Execute(szSQL)
        If CAReference = "" Then
            CAReference = CDataAccess.GetDataAsString("select Reference From property_partner_ref where Property_Id in(select property_Id from property where LTRIM(RTRIM(upper(property_ref))) = '" & Reference.Trim.ToUpper & "') ")
        End If


        '' If we have no Error
        'If Not bError Then

        '    ' Init SQL to Insert CA Property Partner Ref
        '    szSQL =
        '        "merge PROPERTY_PARTNER_REF as target using " &
        '        "( " &
        '            "Select " &
        '            "( " &
        '                "Select Property_ID " &
        '                "from PROPERTY " &
        '                "where Property_Ref = '" & Reference.Trim.ToUpper & "' " &
        '            "), " &
        '            "7666 " &
        '        ") " &
        '        "as source " &
        '        "( " &
        '            "Property_ID, " &
        '            "Partner_ID " &
        '        ") " &
        '        "on target.Property_ID = source.Property_ID and target.Partner_ID = source.Partner_ID " &
        '        " when matched then " &
        '        "update set " &
        '        "Reference =  '" & CAReference & "'" &
        '        " when not matched then " &
        '        "insert " &
        '        "( " &
        '            "Property_ID, " &
        '            "Partner_ID, " &
        '            "Reference " &
        '        ") " &
        '        "values " &
        '        "( " &
        '            "source.Property_ID, " &
        '            "source.Partner_ID, " &
        '            "( '" & CAReference & "'" &
        '            ")	 " &
        '        ");"

        '    ' Run the Update
        '    bError = CDataAccess.Execute(szSQL)

        'End If

        ' If we have no Error
        If Not bError Then

            ' DESCRIPTIONS

            ' Clear Pre Existing
            szSQL = "delete from property_short_desc where upper(ltrim(rtrim(property_ref))) = '" & Reference.Trim.ToUpper & "';" & vbCrLf &
                    "delete from property_desc where upper(ltrim(rtrim(property_ref))) = '" & Reference.Trim.ToUpper & "';"

            ' Short Descriptions
            For Each de In ShortDescription

                ' If we have a Short Description
                If Convert.ToString(de.Value).Length > 0 Then

                    ' Add to SQL
                    szSQL &= "insert into property_short_desc " &
                             "(" &
                                "property_ref, " &
                                "language_id, " &
                                "text" &
                             ") " &
                             "values " &
                             "(" &
                                "'" & Reference.Trim.ToUpper & "', " &
                                Convert.ToInt32(de.Key) & ", " &
                                "'" & Replace(HttpUtility.HtmlDecode(Convert.ToString(de.Value)), "'", "''").Trim & "'" &
                             ");"

                End If

            Next

            ' Descriptions
            For Each de In Description

                ' If we have a Description
                If Convert.ToString(de.Value).Length > 0 Then

                    ' Add to SQL
                    szSQL &= "insert into property_desc " &
                             "(" &
                                "property_ref, " &
                                "language_id, " &
                                "text" &
                             ") " &
                             "values " &
                             "(" &
                                "'" & Reference.Trim.ToUpper & "', " &
                                Convert.ToInt32(de.Key) & ", " &
                                "'" & Replace(HttpUtility.HtmlDecode(Convert.ToString(de.Value)), "'", "''").Trim & "'" &
                             ");"

                End If

            Next

            ' Run the Update
            bError = CDataAccess.Execute(szSQL)

        End If

        ' If we have no Error
        If Not bError Then

            ' FEATURES

            ' Remove any Previous Entries
            szSQL = "delete from property_features where LTRIM(rtrim(upper(property_ref))) = '" & Reference.Trim.ToUpper & "';"

            ' For each Feature
            For Each nFeatureID As Integer In FeatureIDs

                ' Add Inserting SQL
                szSQL &= "insert into property_features (property_ref, features_id) values ('" & Reference.Trim.ToUpper & "', " & nFeatureID.ToString.Trim & ");"

            Next

            ' Run the Update
            bError = CDataAccess.Execute(szSQL)

        End If

        ' If we have no Error
        If Not bError Then

            ' IMAGES

            ' Get the Directories
            Dim szTargetDirectory As String = HttpContext.Current.Server.MapPath("~/Images/Photos/Properties/" & Reference.Trim.ToUpper)

            ' If the Target Directory does not Exists
            If Not Directory.Exists(szTargetDirectory) Then

                ' Create the Directory
                Directory.CreateDirectory(szTargetDirectory)

            End If

            ' Get All Files
            szFiles = Directory.GetFiles(szTargetDirectory)

            ' For each File
            For Each szFile In szFiles

                ' If this is not one of the Files in the Collection, Delete
                If Not Images.Contains(Path.GetFileName(szFile)) Then

                    Try

                        ' Attempt Deletion
                        File.Delete(szFile)

                    Catch ex As Exception
                        System.Console.Write("Source: " & ex.Source & " / " & ex.Message)
                    End Try

                End If

            Next

            ' For each Image
            For Each CImage As ClassImage In Images.Image

                ' Create Temporary Filename to avoid Duplicate Filenames
                File.Move(szTargetDirectory & "\" & CImage.Filename, szTargetDirectory & "\" & CImage.TemporaryFilename)
                CImage.Filename = CImage.TemporaryFilename

            Next

            ' For each Image
            For Each CImage As ClassImage In Images.Image

                ' Increment Image Counter
                nImage += 1

                ' Give Image Correct Filename
                File.Move(szTargetDirectory & "\" & CImage.Filename, szTargetDirectory & "\" & Reference.Trim & "_" & nImage.ToString.Trim & ".jpg")
                CImage.Filename = Reference.Trim & "_" & nImage.ToString.Trim & ".jpg"

            Next

            ' If we have at least 1 Image
            If Images.Count > 0 Then

                ' Create a Thumbnail
                Dim CUtilities As New ClassUtilities
                CUtilities.CreateThumbnail(Reference)
                CUtilities = Nothing

            End If

        End If

        ' If we have no Error
        If Not bError Then

            ' HISTORY

            ' If we have History
            If History.Trim <> String.Empty Then

                'check if the same record already exists in the table
                Dim dt_property_history_latest_Record As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Check_Latest_Property_History_Record").Tables(0)
                If dt_property_history_latest_Record.Rows.Count > 0 Then
                    Dim lr_property_ref As String = dt_property_history_latest_Record.Rows(0)("Property_Ref").ToString()
                    Dim lr_Type_Id As String = dt_property_history_latest_Record.Rows(0)("Type_Id").ToString()
                    Dim lr_Modified_By As String = dt_property_history_latest_Record.Rows(0)("Modified_By").ToString()
                    Dim lr_History_Text As String = dt_property_history_latest_Record.Rows(0)("History_Text").ToString()
                    If lr_property_ref.Trim.ToUpper = Reference.Trim.ToUpper And lr_Type_Id = HistoryTypeID.ToString.Trim And lr_Modified_By = nUserID.ToString.Trim And lr_History_Text = History.Replace("'", "''").Trim Then
                    Else
                        ' Insert the Notes
                        szSQL = "insert into property_history " &
                            "(" &
                                "property_ref, " &
                                "type_id, " &
                                "history_text, " &
                                "modified_by" &
                            ") " &
                            "values " &
                            "(" &
                                "'" & Reference.Trim.ToUpper & "', " &
                                HistoryTypeID.ToString.Trim & ", " &
                                "'" & History.Replace("'", "''").Trim & "', " &
                                nUserID.ToString.Trim &
                            ")"

                        ' Run the Update
                        bError = CDataAccess.Execute(szSQL)
                    End If
                End If
            End If
        End If

        ' Tidy
        CDataAccess = Nothing

        ' Return the Error Flag
        Return bError

    End Function
    Public Function Save(ByVal nUserID As Integer, ByVal nPartnerID As Integer) As Boolean

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim de As DictionaryEntry
        Dim nImage As Integer = 0
        Dim szFiles() As String
        Dim szFile As String
        Dim bError As Boolean

        ' If this is not IA
        If nPartnerID <> 3873 Then

            ' Get our Reference for this Property
            Reference = CDataAccess.PropertyIARef(nPartnerID, Reference)

        End If

        ' GENERAL, IMAGES & FEATURED

        ' Init SQL
        Dim szSQL As String =
            "merge property as target using " &
            "(" &
                "select " &
                    "'" & Address.Trim & "', " &
                    AnnualIBI.ToString.Trim & ", " &
                    AnnualRubbish.ToString.Trim & ", " &
                    Bathrooms.ToString.Trim & ", " &
                    Bedrooms.ToString.Trim & ", " &
                    BrokerID.ToString.Trim & ", " &
                    Built.ToString.Trim & ", " &
                    BuyerID.ToString.Trim & ", " &
                    BuyerLawyerID.ToString.Trim & ", " &
                    CommunityFees.ToString.Trim & ", " &
                    CountryID.ToString.Trim & ", " &
                    CDataAccess.SQLBoolean(Display).Trim & ", " &
                    "'" & DoorKey.Trim & "', " &
                    EnSuite.ToString.Trim & ", " &
                    Latitude.ToString.Trim & ", " &
                    LocationID.ToString.Trim & ", " &
                    Longitude.ToString.Trim & ", " &
                    Images.Count.ToString.Trim & ", " &
                    OriginalPrice.ToString.Trim & ", " &
                    PartnerID.ToString.Trim & ", " &
                    Plot.ToString.Trim & ", " &
                    PostcodeID.ToString.Trim & ", " &
                    "'" & Reference.Trim.ToUpper & "', " &
                    PublicPrice.ToString.Trim & ", " &
                    StatusID.ToString.Trim & ", " &
                    Terrace.ToString.Trim & ", " &
                    TypeID.ToString.Trim & ", " &
                    VendorID.ToString.Trim & ", " &
                    VendorLawyerID.ToString.Trim & ", " &
                    VendorPrice.ToString.Trim & ", " &
                    ViewsID.ToString.Trim & ", " &
                    YearConstructed.ToString.Trim & ", " &
                    "'" & YouTubeVideoID.ToString.Trim & "'," &
                    CDataAccess.SQLDateTime(Now) & ", " &
                    "'" & Taxablevalue.Trim & "' , " &
                    CDataAccess.SQLBoolean(IsIssue).Trim & ", " &
                     "'" & BannerType & "', " &
                     Listed_By_Contact_ID.ToString.Trim & "" &
                 ") " &
            "as source " &
            "(" &
                "property_address, " &
                "annual_ibi, " &
                "annual_rubbish, " &
                "bathrooms, " &
                "bedrooms, " &
                "broker_id, " &
                "sqm_built, " &
                "buyer_id, " &
                "buyer_lawyer_id, " &
                "community_fees, " &
                "country_id, " &
                "display, " &
                "door_key, " &
                "sqm_en_suite, " &
                "gps_latitude, " &
                "location_id, " &
                "gps_longitude, " &
                "num_photos, " &
                "original_price, " &
                "partner_id, " &
                "sqm_plot, " &
                "postcode_id, " &
                "property_ref, " &
                "public_price, " &
                "status_id, " &
                "sqm_terrace, " &
                "property_type_id, " &
                "vendor_id, " &
                "vendor_lawyer_id, " &
                "vendor_price, " &
                "views_id, " &
                "year_constructed, " &
                "video_url, " &
                "last_modified, " &
                "Property_Notes ," &
                  "IsIssue," &
                  "BannerType," &
                  "Listed_By_Contact_ID" &
             ") " &
            "on target.property_ref = source.property_ref " &
            "when matched then " &
                "update set " &
                    "property_address = source.property_address, " &
                    "annual_ibi = source.annual_ibi, " &
                    "annual_rubbish = source.annual_rubbish, " &
                    "bathrooms = source.bathrooms, " &
                    "bedrooms = source.bedrooms, " &
                    "broker_id = source.broker_id, " &
                    "sqm_built = source.sqm_built, " &
                    "buyer_id = source.buyer_id, " &
                    "buyer_lawyer_id = source.buyer_lawyer_id, " &
                    "community_fees = source.community_fees, " &
                    "country_id = source.country_id, " &
                    "display = source.display, " &
                    "door_key = source.door_key, " &
                    "sqm_en_suite = source.sqm_en_suite, " &
                    "gps_latitude = source.gps_latitude, " &
                    "location_id = source.location_id, " &
                    "gps_longitude = source.gps_longitude, " &
                    "num_photos = source.num_photos, " &
                    "original_price = source.original_price, " &
                    "partner_id = source.partner_id, " &
                    "sqm_plot = source.sqm_plot, " &
                    "postcode_id = source.postcode_id, " &
                    "public_price = source.public_price, " &
                    "status_id = source.status_id, " &
                    "sqm_terrace = source.sqm_terrace, " &
                    "property_type_id = source.property_type_id, " &
                    "vendor_id = source.vendor_id, " &
                    "vendor_lawyer_id = source.vendor_lawyer_id, " &
                    "vendor_price = source.vendor_price, " &
                    "views_id = source.views_id, " &
                    "year_constructed = source.year_constructed, " &
                    "video_url = source.video_url, " &
                    "last_modified = source.last_modified, " &
                       "Property_Notes = source.Property_Notes ," &
                         "IsIssue = source.IsIssue, " &
                         "BannerType = source.BannerType, " &
                         "Listed_By_Contact_ID = source.Listed_By_Contact_ID " &
            "when not matched then " &
                "insert " &
                "(" &
                    "property_address, " &
                    "annual_ibi, " &
                    "annual_rubbish, " &
                    "bathrooms, " &
                    "bedrooms, " &
                    "broker_id, " &
                    "sqm_built, " &
                    "buyer_id, " &
                    "buyer_lawyer_id, " &
                    "community_fees, " &
                    "country_id, " &
                    "display, " &
                    "door_key, " &
                    "sqm_en_suite, " &
                    "gps_latitude, " &
                    "location_id, " &
                    "gps_longitude, " &
                    "num_photos, " &
                    "original_price, " &
                    "partner_id, " &
                    "sqm_plot, " &
                    "postcode_id, " &
                    "property_ref, " &
                    "public_price, " &
                    "status_id, " &
                    "sqm_terrace, " &
                    "property_type_id, " &
                    "vendor_id, " &
                    "vendor_lawyer_id, " &
                    "vendor_price, " &
                    "views_id, " &
                    "year_constructed, " &
                    "video_url, " &
                    "create_date, " &
                    "last_modified, " &
                    "Property_Notes ," &
                    "IsIssue," &
                    "BannerType," &
                    "Listed_By_Contact_ID" &
                ") " &
                "values " &
                "(" &
                    "source.property_address, " &
                    "source.annual_ibi, " &
                    "source.annual_rubbish, " &
                    "source.bathrooms, " &
                    "source.bedrooms, " &
                    "source.broker_id, " &
                    "source.sqm_built, " &
                    "source.buyer_id, " &
                    "source.buyer_lawyer_id, " &
                    "source.community_fees, " &
                    "source.country_id, " &
                    "source.display, " &
                    "source.door_key, " &
                    "source.sqm_en_suite, " &
                    "source.gps_latitude, " &
                    "source.location_id, " &
                    "source.gps_longitude, " &
                    "source.num_photos, " &
                    "source.original_price, " &
                    "source.partner_id, " &
                    "source.sqm_plot, " &
                    "source.postcode_id, " &
                    "source.property_ref, " &
                    "source.public_price, " &
                    "source.status_id, " &
                    "source.sqm_terrace, " &
                    "source.property_type_id, " &
                    "source.vendor_id, " &
                    "source.vendor_lawyer_id, " &
                    "source.vendor_price, " &
                    "source.views_id, " &
                    "source.year_constructed, " &
                    "source.video_url, " &
                    "source.last_modified, " &
                    "source.last_modified, " &
                    "source.Property_Notes ," &
                     "source.IsIssue, " &
                     "source.BannerType, " &
                     "source.Listed_By_Contact_ID " &
                ");"

        ' Featured Property Status - if Featured and For Sale
        'If Featured And StatusID = 2 Then

        '    szSQL &= "if not exists (select property_ref from FEATURED_PROPERTY where LTRIM(RTRIM(upper(property_ref))) = '" & Reference.Trim.ToUpper & "') " &
        '                "insert into FEATURED_PROPERTY (Property_Ref, Sort_Order) values ('" & Reference.Trim.ToUpper & "', (select MAX(sort_order) + 1 from FEATURED_PROPERTY))"

        'Else

        '    ' Delete any Entries
        '    szSQL &= "delete from featured_property where ltrim(rtrim(upper(property_ref))) = '" & Reference.Trim.ToUpper & "';"

        'End If

        ' Run the Update
        bError = CDataAccess.Execute(szSQL)

        ' If we have no Error
        'If Not bError Then

        '    ' Init SQL to Insert CA Property Partner Ref
        '    szSQL =
        '        "merge PROPERTY_PARTNER_REF as target using " &
        '        "( " &
        '            "Select " &
        '            "( " &
        '                "Select Property_ID " &
        '                "from PROPERTY " &
        '                "where Property_Ref = '" & Reference.Trim.ToUpper & "' " &
        '            "), " &
        '            "3864 " &
        '        ") " &
        '        "as source " &
        '        "( " &
        '            "Property_ID, " &
        '            "Partner_ID " &
        '        ") " &
        '        "on target.Property_ID = source.Property_ID and target.Partner_ID = source.Partner_ID " &
        '        "when not matched then " &
        '        "insert " &
        '        "( " &
        '            "Property_ID, " &
        '            "Partner_ID, " &
        '            "Reference " &
        '        ") " &
        '        "values " &
        '        "( " &
        '            "source.Property_ID, " &
        '            "source.Partner_ID, " &
        '            "( " &
        '                "select top 1 cast(reference as integer) + 1 ref  " &
        '                "from property_partner_ref  " &
        '                "where Partner_ID = source.Partner_ID " &
        '                "order by Reference desc " &
        '            ")	 " &
        '        ");"

        '    ' Run the Update
        '    bError = CDataAccess.Execute(szSQL)

        'End If

        ' If we have no Error
        If Not bError Then

            ' DESCRIPTIONS

            ' Clear Pre Existing
            szSQL = "delete from property_short_desc where upper(ltrim(rtrim(property_ref))) = '" & Reference.Trim.ToUpper & "';" & vbCrLf &
                    "delete from property_desc where upper(ltrim(rtrim(property_ref))) = '" & Reference.Trim.ToUpper & "';"

            ' Short Descriptions
            For Each de In ShortDescription

                ' If we have a Short Description
                If Convert.ToString(de.Value).Length > 0 Then

                    ' Add to SQL
                    szSQL &= "insert into property_short_desc " &
                             "(" &
                                "property_ref, " &
                                "language_id, " &
                                "text" &
                             ") " &
                             "values " &
                             "(" &
                                "'" & Reference.Trim.ToUpper & "', " &
                                Convert.ToInt32(de.Key) & ", " &
                                "'" & Replace(HttpUtility.HtmlDecode(Convert.ToString(de.Value)), "'", "''").Trim & "'" &
                             ");"

                End If

            Next

            ' Descriptions
            For Each de In Description

                ' If we have a Description
                If Convert.ToString(de.Value).Length > 0 Then

                    ' Add to SQL
                    szSQL &= "insert into property_desc " &
                             "(" &
                                "property_ref, " &
                                "language_id, " &
                                "text" &
                             ") " &
                             "values " &
                             "(" &
                                "'" & Reference.Trim.ToUpper & "', " &
                                Convert.ToInt32(de.Key) & ", " &
                                "'" & Replace(HttpUtility.HtmlDecode(Convert.ToString(de.Value)), "'", "''").Trim & "'" &
                             ");"

                End If

            Next

            ' Run the Update
            bError = CDataAccess.Execute(szSQL)

        End If

        ' If we have no Error
        If Not bError Then

            ' FEATURES

            ' Remove any Previous Entries
            szSQL = "delete from property_features where LTRIM(rtrim(upper(property_ref))) = '" & Reference.Trim.ToUpper & "';"

            ' For each Feature
            For Each nFeatureID As Integer In FeatureIDs

                ' Add Inserting SQL
                szSQL &= "insert into property_features (property_ref, features_id) values ('" & Reference.Trim.ToUpper & "', " & nFeatureID.ToString.Trim & ");"

            Next

            ' Run the Update
            bError = CDataAccess.Execute(szSQL)

        End If

        ' If we have no Error
        If Not bError Then

            ' IMAGES

            ' Get the Directories
            Dim szTargetDirectory As String = HttpContext.Current.Server.MapPath("~/Images/Photos/Properties/" & Reference.Trim.ToUpper)

            ' If the Target Directory does not Exists
            If Not Directory.Exists(szTargetDirectory) Then

                ' Create the Directory
                Directory.CreateDirectory(szTargetDirectory)

            End If

            ' Get All Files
            szFiles = Directory.GetFiles(szTargetDirectory)

            ' For each File
            For Each szFile In szFiles

                ' If this is not one of the Files in the Collection, Delete
                If Not Images.Contains(Path.GetFileName(szFile)) Then

                    Try

                        ' Attempt Deletion
                        File.Delete(szFile)

                    Catch ex As Exception
                        System.Console.Write("Source: " & ex.Source & " / " & ex.Message)
                    End Try

                End If

            Next

            ' For each Image
            For Each CImage As ClassImage In Images.Image

                ' Create Temporary Filename to avoid Duplicate Filenames
                File.Move(szTargetDirectory & "\" & CImage.Filename, szTargetDirectory & "\" & CImage.TemporaryFilename)
                CImage.Filename = CImage.TemporaryFilename

            Next

            ' For each Image
            For Each CImage As ClassImage In Images.Image

                ' Increment Image Counter
                nImage += 1

                ' Give Image Correct Filename
                File.Move(szTargetDirectory & "\" & CImage.Filename, szTargetDirectory & "\" & Reference.Trim & "_" & nImage.ToString.Trim & ".jpg")
                CImage.Filename = Reference.Trim & "_" & nImage.ToString.Trim & ".jpg"

            Next

            ' If we have at least 1 Image
            If Images.Count > 0 Then

                ' Create a Thumbnail
                Dim CUtilities As New ClassUtilities
                CUtilities.CreateThumbnail(Reference)
                CUtilities = Nothing

            End If

        End If

        ' If we have no Error
        If Not bError Then

            ' HISTORY

            ' If we have History
            If History.Trim <> String.Empty Then

                'check if the same record already exists in the table
                Dim dt_property_history_latest_Record As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Check_Latest_Property_History_Record").Tables(0)
                If dt_property_history_latest_Record.Rows.Count > 0 Then
                    Dim lr_property_ref As String = dt_property_history_latest_Record.Rows(0)("Property_Ref").ToString()
                    Dim lr_Type_Id As String = dt_property_history_latest_Record.Rows(0)("Type_Id").ToString()
                    Dim lr_Modified_By As String = dt_property_history_latest_Record.Rows(0)("Modified_By").ToString()
                    Dim lr_History_Text As String = dt_property_history_latest_Record.Rows(0)("History_Text").ToString()
                    If lr_property_ref.Trim.ToUpper = Reference.Trim.ToUpper And lr_Type_Id = HistoryTypeID.ToString.Trim And lr_Modified_By = nUserID.ToString.Trim And lr_History_Text = History.Replace("'", "''").Trim Then
                    Else
                        ' Insert the Notes
                        szSQL = "insert into property_history " &
                            "(" &
                                "property_ref, " &
                                "type_id, " &
                                "history_text, " &
                                "modified_by" &
                            ") " &
                            "values " &
                            "(" &
                                "'" & Reference.Trim.ToUpper & "', " &
                                HistoryTypeID.ToString.Trim & ", " &
                                "'" & History.Replace("'", "''").Trim & "', " &
                                nUserID.ToString.Trim &
                            ")"

                        ' Run the Update
                        bError = CDataAccess.Execute(szSQL)
                    End If
                End If
            End If

        End If

        ' Tidy
        CDataAccess = Nothing

        ' Return the Error Flag
        Return bError

    End Function
    Public Sub New(ByVal nPartnerID As Integer)

        ' Local Vars
        Dim nLanguageID As Integer

        ' Initialise Variables
        Address = String.Empty
        AreaName = String.Empty
        Taxablevalue = String.Empty
        BrokerID = 0
        BuyerID = 0
        BuyerLawyerID = 0
        CAReference = String.Empty
        CountryID = 2   ' Spain
        Display = False
        DoorKey = String.Empty
        Featured = False
        FeatureIDs = New List(Of Int32)
        History = String.Empty
        HistoryTypeID = 0
        ID = 0
        Images = New ClassImages
        PartnerID = nPartnerID
        PostcodeID = 0 '14430
        Reference = String.Empty
        StatusID = 3    ' New Property  
        VendorID = 0
        VendorLawyerID = 0
        YouTubeVideoID = String.Empty

        ' Initialise Arrays
        m_htShortDescription = New Hashtable
        m_htDescription = New Hashtable

        ' Get Languages
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable = CDataAccess.Languages(1)
        CDataAccess = Nothing

        ' For each Row Returned
        For Each dr As DataRow In dtDataTable.Rows

            ' Get the Language ID
            nLanguageID = Convert.ToInt32(dr("id"))

            ' Add this Language to the Description Arrays
            ShortDescription.Add(nLanguageID, String.Empty)
            Description.Add(nLanguageID, String.Empty)

        Next

        ' Tidy
        dtDataTable.Dispose()

        '' Set Flags
        'OverviewLoaded = False
        'GeneralLoaded = False
        'DescriptionLoaded = False
        'ImagesLoaded = False
        'FeaturesLoaded = False
        'HistoryLoaded = False
        'DocumentsLoaded = False

    End Sub
    Protected Overrides Sub Finalize()

        ' Tidy
        ShortDescription.Clear()
        Description.Clear()
        FeatureIDs.Clear()
        Images.Clear()
        m_htShortDescription = Nothing
        m_htDescription = Nothing
        FeatureIDs = Nothing
        Images = Nothing

        MyBase.Finalize()

    End Sub
    Public Sub Load(ByVal szPropertyRef As String)

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Get this ID
        Dim nPropertyID As Integer = CDataAccess.PropertyID(szPropertyRef, -1)

        ' Tidy
        CDataAccess = Nothing

        ' Load Property
        Load(nPropertyID)

    End Sub
    Public Sub Load(ByVal nPropertyID As Integer)

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim dr As DataRow

        ' GENERAL & IMAGES

        ' Load Property Details
        Dim dtDataTable As DataTable = CDataAccess.LoadProperty(nPropertyID, PartnerID)

        ' Check we have a Record
        If dtDataTable.Rows.Count > 0 Then

            ' Load Details
            Address = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("property_address"), String.Empty)
            Taxablevalue = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("Property_Notes"), String.Empty)
            AnnualIBI = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("annual_ibi"), 0.0)
            AnnualRubbish = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("annual_rubbish"), 0.0)
            AreaName = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("area_name"), String.Empty)
            Bathrooms = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("bathrooms"), 0)
            Bedrooms = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("bedrooms"), 0)
            BrokerID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("broker_id"), 0)
            Built = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("sqm_built"), 0)
            BuyerID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("buyer_id"), 0)
            BuyerLawyerID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("buyer_lawyer_id"), 0)
            CAReference = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("ca_ref"), String.Empty)
            CommunityFees = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("community_fees"), 0.0)
            CountryID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("country_id"), 0)
            Display = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("display"), False)
            DoorKey = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("door_key"), String.Empty)
            EnSuite = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("sqm_en_suite"), 0)
            Featured = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("featured"), False)
            Dim szFeaturesIDs() As String = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("features_id"), "").Split(","c)
            ID = nPropertyID
            Latitude = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("gps_latitude"), 0.0)
            LocationID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("location_id"), 0)
            Longitude = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("gps_longitude"), 0.0)
            NumberOfImages = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("num_photos"), 0)
            OriginalPrice = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("original_price"), 0)
            PartnerID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("partner_id"), 3873)
            Plot = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("sqm_plot"), 0)
            PostcodeID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("postcode_id"), 0)
            Reference = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("property_ref"), String.Empty)
            PublicPrice = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("public_price"), 0)
            StatusID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("status_id"), 0)
            Terrace = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("sqm_terrace"), 0)
            TypeID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("property_type_id"), 0)
            VendorID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("vendor_id"), 0)
            VendorLawyerID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("vendor_lawyer_id"), 0)
            VendorPrice = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("vendor_price"), 0)
            ViewsID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("views_id"), 0)
            YearConstructed = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("year_constructed"), 0)
            YouTubeVideoID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("video_url"), String.Empty)
            IsIssue = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("IsIssue"), False)
            BannerType = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("BannerType"), String.Empty)
            ListedBy = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("listed_by_contact_id"), String.Empty)
            ListedByPartner = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("Listed_By_Partner"), String.Empty)
            LContactId = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("LContactId"), String.Empty)
            Listed_By_Contact_ID = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("LContactId"), String.Empty)
            'If Not IsDBNull(dtDataTable.Rows(0).Item("History_Subject_To_Id")) Then
            '    History_Subject_To_Id = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("History_Subject_To_Id"), String.Empty)
            'End If
            'HistorySubjectType = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("HistorySubjectType"), String.Empty)
            'HistoryExpiryDate = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("HistoryExpiryDate"), String.Empty)
            'BuyerSurname = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("BuyerForename"), String.Empty)
            'BuyerForename = CDataAccess.DBSafe(dtDataTable.Rows(0).Item("BuyerSurname"), String.Empty)
            ' Clear Feature IDs
            FeatureIDs.Clear()

            ' Extract Features
            For Each szID In szFeaturesIDs

                ' Check this is a Valid Value
                If IsNumeric(szID.Trim) Then

                    ' Add this ID
                    FeatureIDs.Add(Convert.ToInt32(szID.Trim))

                End If

            Next

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' SHORT DESCRIPTIONS

        ' Clearing any Previous Entries
        ShortDescription.Clear()

        ' Load Short Descriptions
        dtDataTable = CDataAccess.LoadPropertyShortDesc(nPropertyID)

        ' For each Row Returned
        For Each dr In dtDataTable.Rows

            ' Add this to the Array
            ShortDescription.Add(CDataAccess.DBSafe(dr("language_id"), 0), CDataAccess.DBSafe(dr("text"), String.Empty))

        Next

        ' Tidy
        dtDataTable.Dispose()

        ' DESCRIPTIONS

        ' Clearing any Previous Entries
        Description.Clear()

        ' Load Short Descriptions
        dtDataTable = CDataAccess.LoadPropertyDesc(nPropertyID)

        ' For each Row Returned
        For Each dr In dtDataTable.Rows

            ' Add this to the Array
            Description.Add(CDataAccess.DBSafe(dr("language_id"), 0), CDataAccess.DBSafe(dr("text"), String.Empty))

        Next

        ' Tidy
        dtDataTable.Dispose()

        ' Tidy
        CDataAccess = Nothing

    End Sub

End Class
