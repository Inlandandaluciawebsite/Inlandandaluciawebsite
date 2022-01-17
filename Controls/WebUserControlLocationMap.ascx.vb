Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares

Partial Class Controls_WebUserControlLocationMap
    Inherits System.Web.UI.UserControl
    Private m_dLatitude As Double
    Public ReadOnly Property Latitude As Double
        Get
            Return m_dLatitude
        End Get
    End Property
    Private m_dLongitude As Double
    Public ReadOnly Property Longitude As Double
        Get
            Return m_dLongitude
        End Get
    End Property
    Private m_nZoom As Integer
    Public ReadOnly Property Zoom As Integer
        Get
            Return m_nZoom
        End Get
    End Property
    Private m_price As String
    Public ReadOnly Property price As String
        Get
            Return m_price
        End Get
    End Property
    Private m_postcodeid As Integer
    Public ReadOnly Property postcode_Id As String
        Get
            Return m_postcodeid
        End Get
    End Property
    'Private m_location As String
    'Public ReadOnly Property location As String
    '    Get
    '        Return m_location
    '    End Get
    'End Property
    'Private m_type As String
    'Public ReadOnly Property type As String
    '    Get
    '        Return m_type
    '    End Get
    'End Property
    'Private m_property_ref As String
    'Public ReadOnly Property property_ref As String
    '    Get
    '        Return m_property_ref
    '    End Get
    'End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Select Case Session("AreaID")

        '    Case 7

        '        ' Aguadulce - set the Coordinates
        '        m_dLatitude = 37.252467
        '        m_dLongitude = -4.992743
        '        m_nZoom = 15

        '    Case 11

        '        ' Alameda - set the Coordinates
        '        m_dLatitude = 37.20644
        '        m_dLongitude = -4.658289
        '        m_nZoom = 15

        '    Case 25

        '        ' Alcala la Real - set the Coordinates
        '        m_dLatitude = 37.460416
        '        m_dLongitude = -3.923492
        '        m_nZoom = 14

        '    Case 28

        '        ' Alcaudete - set the Coordinates
        '        m_dLatitude = 37.592331
        '        m_dLongitude = -4.081254
        '        m_nZoom = 15

        '    Case 50
        '        ' Alhaurin el Grande - set the Coordinates
        '        m_dLatitude = 36.64186
        '        m_dLongitude = -4.69145
        '        m_nZoom = 15

        '    Case 59

        '        ' Almedinilla - set the Coordinates
        '        m_dLatitude = 37.43953
        '        m_dLongitude = -4.091908
        '        m_nZoom = 15

        '    Case 74

        '        ' Antequera - set the Coordinates
        '        m_dLatitude = 37.020001
        '        m_dLongitude = -4.559368
        '        m_nZoom = 14

        '    Case 76

        '        ' Arahal - set the Coordinates
        '        m_dLatitude = 37.26099
        '        m_dLongitude = -5.548603
        '        m_nZoom = 14

        '    Case 79

        '        ' Archidona - set the Coordinates
        '        m_dLatitude = 37.095153
        '        m_dLongitude = -4.387995
        '        m_nZoom = 15

        '    Case 109
        '        ' Badolatosa - set the Coordinates
        '        m_dLatitude = 37.30871
        '        m_dLongitude = -4.67286
        '        m_nZoom = 15

        '    Case 110
        '        ' Baena - set the Coordinates
        '        m_dLatitude = 37.61441
        '        m_dLongitude = -4.32609
        '        m_nZoom = 15

        '    Case 142

        '        ' Benamaji - set the Coordinates
        '        m_dLatitude = 37.268879
        '        m_dLongitude = -4.541645
        '        m_nZoom = 15

        '    Case 182

        '        ' Campillos - set the Coordinates
        '        m_dLatitude = 37.048704
        '        m_dLongitude = -4.863338
        '        m_nZoom = 15


        '    Case 187

        '        ' Campillos - set the Coordinates
        '        m_dLatitude = 37.5432848
        '        m_dLongitude = -4.1625172
        '        m_nZoom = 12

        '    Case 211

        '        ' Carcabuey - set the Coordinates
        '        m_dLatitude = 37.442781
        '        m_dLongitude = -4.273401
        '        m_nZoom = 15

        '    Case 216

        '        ' Carmona - set the Coordinates
        '        m_dLatitude = 37.4712052
        '        m_dLongitude = -5.6563188
        '        m_nZoom = 14

        '    Case 225

        '        ' Casabermeja - set the Coordinates
        '        m_dLatitude = 36.89407
        '        m_dLongitude = -4.42891
        '        m_nZoom = 15

        '    Case 233

        '        ' Castil de Campos - set the Coordinates
        '        m_dLatitude = 37.491018
        '        m_dLongitude = -4.14306
        '        m_nZoom = 16

        '    Case 242

        '        ' Castillo de Locubin - set the Coordinates
        '        m_dLatitude = 37.527184
        '        m_dLongitude = -3.941304
        '        m_nZoom = 15

        '    Case 276

        '        ' Coin - set the Coordinates
        '        m_dLatitude = 36.65871
        '        m_dLongitude = -4.76034
        '        m_nZoom = 15

        '    Case 322

        '        ' Ecija - set the Coordinates
        '        m_dLatitude = 37.5403514
        '        m_dLongitude = -5.0845655
        '        m_nZoom = 14

        '    Case 385

        '        ' Saucejo - set the Coordinates
        '        m_dLatitude = 37.071251
        '        m_dLongitude = -5.094754
        '        m_nZoom = 15

        '    Case 402

        '        ' Encinas Reales - set the Coordinates
        '        m_dLatitude = 37.274505
        '        m_dLongitude = -4.488346
        '        m_nZoom = 15

        '    Case 408

        '        ' Espejo - set the Coordinates
        '        m_dLatitude = 37.6681739
        '        m_dLongitude = -4.6276182
        '        m_nZoom = 15

        '    Case 415

        '        ' Estepa - set the Coordinates
        '        m_dLatitude = 37.29273
        '        m_dLongitude = -4.87793
        '        m_nZoom = 15

        '    Case 437

        '        ' Fuente de Piedra - set the Coordinates
        '        m_dLatitude = 37.134161
        '        m_dLongitude = -4.730986
        '        m_nZoom = 15

        '    Case 484

        '        ' Guaro - set the Coordinates
        '        m_dLatitude = 36.656487
        '        m_dLongitude = -4.834565
        '        m_nZoom = 14

        '    Case 493

        '        ' Herrera - set the Coordinates
        '        m_dLatitude = 37.36279
        '        m_dLongitude = -4.848275
        '        m_nZoom = 14

        '    Case 514

        '        ' Humilladero - set the Coordinates
        '        m_dLatitude = 37.113842
        '        m_dLongitude = -4.703829
        '        m_nZoom = 15

        '    Case 520

        '        ' Isla Redonda  - set the Coordinates
        '        m_dLatitude = 37.44907
        '        m_dLongitude = -4.88265
        '        m_nZoom = 12

        '    Case 524

        '        ' Iznajar - set the Coordinates
        '        m_dLatitude = 37.257192
        '        m_dLongitude = -4.307079
        '        m_nZoom = 12

        '    Case 525

        '        ' Iznalloz - set the Coordinates
        '        m_dLatitude = 37.3927
        '        m_dLongitude = -3.52755
        '        m_nZoom = 12

        '    Case 535

        '        ' Jauja - set the Coordinates
        '        m_dLatitude = 37.303083
        '        m_dLongitude = -4.655691
        '        m_nZoom = 16

        '    Case 585

        '        ' La Luisiana - set the Coordinates
        '        m_dLatitude = 37.528364
        '        m_dLongitude = -5.250671
        '        m_nZoom = 15

        '    Case 599

        '        ' La Puebla de Cazalla - set the Coordinates
        '        m_dLatitude = 37.221451
        '        m_dLongitude = -5.308644
        '        m_nZoom = 15

        '    Case 603

        '        ' La Rabita - set the Coordinates
        '        m_dLatitude = 36.7486033
        '        m_dLongitude = -3.171063
        '        m_nZoom = 12

        '    Case 606

        '        ' La Roda - set the Coordinates
        '        m_dLatitude = 37.199247
        '        m_dLongitude = -4.774247
        '        m_nZoom = 15

        '    Case 665
        '        ' Lora de Estepa - set the Coordinates
        '        m_dLatitude = 37.26869
        '        m_dLongitude = -4.82782
        '        m_nZoom = 15

        '    Case 708

        '        ' Lucena - set the Coordinates
        '        m_dLatitude = 37.410733
        '        m_dLongitude = -4.485426
        '        m_nZoom = 12

        '    Case 712

        '        ' Luque - set the Coordinates
        '        m_dLatitude = -25.26566
        '        m_dLongitude = -57.49379
        '        m_nZoom = 15

        '    Case 726

        '        ' Marchena - set the Coordinates
        '        m_dLatitude = 37.32737
        '        m_dLongitude = -5.414668
        '        m_nZoom = 15

        '    Case 729

        '        ' Marinaleda - set the Coordinates
        '        m_dLatitude = 37.37177
        '        m_dLongitude = -4.959117
        '        m_nZoom = 15

        '    Case 734

        '        ' Martos - set the Coordinates
        '        m_dLatitude = 37.718522
        '        m_dLongitude = -3.971901
        '        m_nZoom = 14

        '    Case 755

        '        ' Mollina - set the Coordinates
        '        m_dLatitude = 37.124836
        '        m_dLongitude = -4.657597
        '        m_nZoom = 14

        '    Case 758
        '        ' Monda - set the Coordinates
        '        m_dLatitude = 36.63018
        '        m_dLongitude = -4.83112
        '        m_nZoom = 15

        '    Case 780

        '        ' Moron - set the Coordinates
        '        m_dLatitude = 37.124534
        '        m_dLongitude = -5.454369
        '        m_nZoom = 14

        '    Case 816

        '        ' Osuna - set the Coordinates
        '        m_dLatitude = 37.240125
        '        m_dLongitude = -5.104437
        '        m_nZoom = 14

        '    Case 820

        '        ' Palenciana - set the Coordinates
        '        m_dLatitude = 37.248778
        '        m_dLongitude = -4.582586
        '        m_nZoom = 15

        '    Case 880

        '        ' Priego of Cordoba - set the Coordinates
        '        m_dLatitude = 37.438685
        '        m_dLongitude = -4.194618
        '        m_nZoom = 15

        '    Case 887

        '        ' Puente Genil - set the Coordinates
        '        m_dLatitude = 37.390243
        '        m_dLongitude = -4.765835
        '        m_nZoom = 14

        '    Case 920

        '        ' Rute - set the Coordinates
        '        m_dLatitude = 37.326318
        '        m_dLongitude = -4.367881
        '        m_nZoom = 12

        '    Case 964

        '        ' Sevilla - set the Coordinates
        '        m_dLatitude = 37.3754864
        '        m_dLongitude = -6.0252699
        '        m_nZoom = 12

        '    Case 966

        '        ' Sierra de Yeguas - set the Coordinates
        '        m_dLatitude = 37.124619
        '        m_dLongitude = -4.867244
        '        m_nZoom = 15

        '    Case 981
        '        ' Teba - set the Coordinates
        '        m_dLatitude = 36.98348
        '        m_dLongitude = -4.92027
        '        m_nZoom = 15

        '    Case 1070

        '        ' Villanueva de Algaidas - set the Coordinates
        '        m_dLatitude = 37.183799
        '        m_dLongitude = -4.449727
        '        m_nZoom = 15

        '    Case 1107
        '        ' Zuheros - set the Coordinates
        '        m_dLatitude = 37.54314
        '        m_dLongitude = -4.31641
        '        m_nZoom = 15
        'End Select

        'As we have now latitude & longitude with in postcode so no need to hard code values like above 
        'Code by sourabh sachdeva 11-02-2020
        Dim AreaId As Int16 = Convert.ToInt16(Session("AreaID"))
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@Area_Id", AreaId)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Get_LatLong_By_AreaId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            m_dLatitude = dt.Rows(0)("GPS_Latitude_02").ToString()
            m_dLongitude = dt.Rows(0)("GPS_Latitude_02").ToString()
            m_nZoom = 12
        End If
    End Sub
    Public Function ConvertDataTabletoString() As String

        Dim language As Integer
        If Not Session("language") = "" Then
            Dim language1 As String = Session("language")
            Select Case language1

                Case "Spanish"
                    language = 2

                Case "French"
                    language = 3

                Case "German"
                    language = 4

                Case "Dutch"
                    language = 5

                Case Else
                    language = 1

            End Select
        Else
            language = 1
        End If
        Dim dt As New DataTable, daW As New ClassUtilities
        'dt = daW.GetLocations(Session("RegionID"), Session("AreaID"), language)
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@Area_Id", Convert.ToInt32(Session("AreaID")))
        dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_property_mapAllLocation_By_AreaId", sql).Tables(0)
        Dim CUtilities As New ClassUtilities
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                'If col.ColumnName = "formatprice" Then
                '    dr(col) = CUtilities.FormatPrice(dr("price"))
                'End If
                'If col.ColumnName = "url" Then
                '    dr(col) = CUtilities.ApplyStatusWatermark(PhotoURL(dr("property_ref")), dr("status_id"))
                'End If
                'If col.ColumnName = "priceHead" Then
                '    dr(col) = GetTranslation("Price")
                'End If
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
    End Function
    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function
    Private Function PhotoURL(ByVal szPropertyRef As String) As String

        ' Local Vars
        Dim bThumbnail As Boolean = True

        ' Set the Path to the Thumbnail
        Dim szPath As String = "/images/photos/properties/" & szPropertyRef.Trim & "/" & szPropertyRef.Trim & "_TN.jpg"

        ' If the Thumbnail does not Exist
        If Not File.Exists(Server.MapPath(szPath)) Then

            ' Create the Thumbnail
            Dim CUtilities As New ClassUtilities
            bThumbnail = CUtilities.CreateThumbnail(szPropertyRef)
            CUtilities = Nothing

        End If

        ' If we were unable to Create a Thumbnail
        If Not bThumbnail Then

            ' Set to No Image Photo
            szPath = "/images/icons/no-photo.png"

        End If
        ' Return the Result
        Return szPath
    End Function
End Class
