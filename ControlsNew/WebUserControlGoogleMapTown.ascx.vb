Imports System.Data

Partial Public Class WebUserControlGoogleMapTown
    Inherits System.Web.UI.UserControl

    Private m_nRegionID As Integer
    Private ReadOnly Property RegionID As Integer
        Get
            Return m_nRegionID
        End Get
    End Property

    Private m_nAreaID As Integer
    Private ReadOnly Property AreaID As Integer
        Get
            Return m_nAreaID
        End Get
    End Property

    Private m_nNumberOfResults As Integer
    Public ReadOnly Property NumberOfResults As Integer
        Get
            Return m_nNumberOfResults
        End Get
    End Property

    Private m_szLatitudes As String
    Public ReadOnly Property Latitudes As String
        Get
            Return m_szLatitudes
        End Get
    End Property

    Private m_szLongitudes As String
    Public ReadOnly Property Longitudes As String
        Get
            Return m_szLongitudes
        End Get
    End Property

    Private m_szInfoWindowHTML As String
    Public ReadOnly Property InfoWindowHTML As String
        Get
            Return m_szInfoWindowHTML
        End Get
    End Property

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        Dim szDelim = String.Empty

        ' Load Property Locations
        Dim dtDataTable As DataTable = CDataAccess.PropertyLocations(CUtilities.GetLanguageID(Session("Language")), Session("RegionID"), Session("AreaID"))

        ' Tidy
        CUtilities = Nothing

        ' Set the Number of Results
        m_nNumberOfResults = dtDataTable.Rows.Count

        ' For each Row in the DataTable
        For Each dr As DataRow In dtDataTable.Rows

            ' Append this to our Strings
            m_szLatitudes &= szDelim & dr.Item("latitude").ToString.Trim
            m_szLongitudes &= szDelim & dr.Item("longitude").ToString.Trim
            m_szInfoWindowHTML &= szDelim & GoogleInfoWindowHTML(Convert.ToInt32(dr.Item("property_id")), _
                                                                 dr.Item("location").ToString.Trim, _
                                                                 dr.Item("type").ToString.Trim, _
                                                                 dr.Item("property_ref").ToString.Trim, _
                                                                 "/images/photos/properties/" & dr.Item("property_ref").ToString.Trim & "/" & dr.Item("property_ref").ToString.Trim & "_1.jpg", _
                                                                 Convert.ToInt32(dr.Item("price")))

            ' Set Delimiter
            szDelim = Chr(126)

        Next

        ' Tidy
        dtDataTable.Dispose()

        ' Depending on the Area ID
        Select Case Session("AreaID")

            Case 7

                ' Aguadulce - set the Coordinates
                m_dLatitude = 37.252467
                m_dLongitude = -4.992743
                m_nZoom = 15

            Case 11

                ' Alameda - set the Coordinates
                m_dLatitude = 37.20644
                m_dLongitude = -4.658289
                m_nZoom = 15

            Case 25

                ' Alcala la Real - set the Coordinates
                m_dLatitude = 37.460416
                m_dLongitude = -3.923492
                m_nZoom = 14

            Case 28

                ' Alcaudete - set the Coordinates
                m_dLatitude = 37.592331
                m_dLongitude = -4.081254
                m_nZoom = 15

            Case 59

                ' Almedinilla - set the Coordinates
                m_dLatitude = 37.43953
                m_dLongitude = -4.091908
                m_nZoom = 15

            Case 74

                ' Antequera - set the Coordinates
                m_dLatitude = 37.020001
                m_dLongitude = -4.559368
                m_nZoom = 14

            Case 76

                ' Arahal - set the Coordinates
                m_dLatitude = 37.26099
                m_dLongitude = -5.548603
                m_nZoom = 14

            Case 79

                ' Archidona - set the Coordinates
                m_dLatitude = 37.095153
                m_dLongitude = -4.387995
                m_nZoom = 15

            Case 142

                ' Benamaji - set the Coordinates
                m_dLatitude = 37.268879
                m_dLongitude = -4.541645
                m_nZoom = 15

            Case 182

                ' Campillos - set the Coordinates
                m_dLatitude = 37.048704
                m_dLongitude = -4.863338
                m_nZoom = 15

            Case 211

                ' Carcabuey - set the Coordinates
                m_dLatitude = 37.442781
                m_dLongitude = -4.273401
                m_nZoom = 15

            Case 216

                ' Carmona - set the Coordinates
                m_dLatitude = 37.471588
                m_dLongitude = -5.647144
                m_nZoom = 14

            Case 233

                ' Castil de Campos - set the Coordinates
                m_dLatitude = 37.491018
                m_dLongitude = -4.14306
                m_nZoom = 16

            Case 242

                ' Castillo de Locubin - set the Coordinates
                m_dLatitude = 37.527184
                m_dLongitude = -3.941304
                m_nZoom = 15

            Case 322

                ' Ecija - set the Coordinates
                m_dLatitude = 37.541466
                m_dLongitude = -5.082674
                m_nZoom = 14

            Case 385

                ' Saucejo - set the Coordinates
                m_dLatitude = 37.071251
                m_dLongitude = -5.094754
                m_nZoom = 15

            Case 402

                ' Encinas Reales - set the Coordinates
                m_dLatitude = 37.274505
                m_dLongitude = -4.488346
                m_nZoom = 15

            Case 408

                ' Espejo - set the Coordinates
                m_dLatitude = 37.679982
                m_dLongitude = -4.554005
                m_nZoom = 15

            Case 415

                ' Estepa - set the Coordinates
                m_dLatitude = 37.29273
                m_dLongitude = -4.87793
                m_nZoom = 15

            Case 437

                ' Fuente de Piedra - set the Coordinates
                m_dLatitude = 37.134161
                m_dLongitude = -4.730986
                m_nZoom = 15

            Case 493

                ' Herrera - set the Coordinates
                m_dLatitude = 37.36279
                m_dLongitude = -4.848275
                m_nZoom = 14

            Case 514

                ' Humilladero - set the Coordinates
                m_dLatitude = 37.113842
                m_dLongitude = -4.703829
                m_nZoom = 15

            Case 524

                ' Iznajar - set the Coordinates
                m_dLatitude = 37.257192
                m_dLongitude = -4.307079
                m_nZoom = 12

            Case 535

                ' Jauja - set the Coordinates
                m_dLatitude = 37.303083
                m_dLongitude = -4.655691
                m_nZoom = 16

            Case 585

                ' La Luisiana - set the Coordinates
                m_dLatitude = 37.528364
                m_dLongitude = -5.250671
                m_nZoom = 15

            Case 599

                ' La Puebla de Cazalla - set the Coordinates
                m_dLatitude = 37.221451
                m_dLongitude = -5.308644
                m_nZoom = 15

            Case 606

                ' La Roda - set the Coordinates
                m_dLatitude = 37.199247
                m_dLongitude = -4.774247
                m_nZoom = 15

            Case 708

                ' Lucena - set the Coordinates
                m_dLatitude = 37.410733
                m_dLongitude = -4.485426
                m_nZoom = 14

            Case 726

                ' Marchena - set the Coordinates
                m_dLatitude = 37.32737
                m_dLongitude = -5.414668
                m_nZoom = 15

            Case 729

                ' Marinaleda - set the Coordinates
                m_dLatitude = 37.37177
                m_dLongitude = -4.959117
                m_nZoom = 15

            Case 734

                ' Martos - set the Coordinates
                m_dLatitude = 37.718522
                m_dLongitude = -3.971901
                m_nZoom = 14

            Case 755

                ' Mollina - set the Coordinates
                m_dLatitude = 37.124836
                m_dLongitude = -4.657597
                m_nZoom = 14

            Case 780

                ' Moron - set the Coordinates
                m_dLatitude = 37.124534
                m_dLongitude = -5.454369
                m_nZoom = 14

            Case 816

                ' Osuna - set the Coordinates
                m_dLatitude = 37.240125
                m_dLongitude = -5.104437
                m_nZoom = 14

            Case 820

                ' Palenciana - set the Coordinates
                m_dLatitude = 37.248778
                m_dLongitude = -4.582586
                m_nZoom = 15

            Case 880

                ' Priego of Cordoba - set the Coordinates
                m_dLatitude = 37.438685
                m_dLongitude = -4.194618
                m_nZoom = 15

            Case 887

                ' Puente Genil - set the Coordinates
                m_dLatitude = 37.390243
                m_dLongitude = -4.765835
                m_nZoom = 14

            Case 920

                ' Rute - set the Coordinates
                m_dLatitude = 37.326318
                m_dLongitude = -4.367881
                m_nZoom = 14

            Case 964

                ' Sevilla - set the Coordinates
                m_dLatitude = 37.388096
                m_dLongitude = -5.98233
                m_nZoom = 12

            Case 966

                ' Sierra de Yeguas - set the Coordinates
                m_dLatitude = 37.124619
                m_dLongitude = -4.867244
                m_nZoom = 15

            Case 1070

                ' Villanueva de Algaidas - set the Coordinates
                m_dLatitude = 37.183799
                m_dLongitude = -4.449727
                m_nZoom = 15

        End Select

        ' Tidy
        dtDataTable.Dispose()

    End Sub

    Public Function GoogleInfoWindowHTML(ByVal nPropertyID As Integer, _
                                         ByVal szLocation As String, _
                                         ByVal szType As String, _
                                         ByVal szReference As String, _
                                         ByVal szPhotoURL As String, _
                                         ByVal nPrice As Integer) As String

        Dim CUtilities As New ClassUtilities

        Dim szRetVal As String = _
            "<h2>" & GetTranslation("Location") & ": " & szLocation.Trim & "</h2>" & _
            "<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
            "<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """><img src=""" & szPhotoURL.Trim & """ alt=""Prop img"" width=""150"" height=""100""/></a></p>"

        If nPrice = 0 Then
            szRetVal &= "<p><strong>" & GetTranslation("Price") & ":</strong> P.O.A.</p>"
        Else
            szRetVal &= "<p><strong>" & GetTranslation("Price") & ":</strong> " & CUtilities.FormatPrice(nPrice) & "</p>"
        End If

        ' Continue to Construct HTML
        szRetVal &= _
            "<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """ title=""" & GetTranslation("More information") & """>+ info</a></p>" & _
            "<p><a href=""http://www.inlandandalucia.com"" title=""InlandAndalucia.com"">InlandAndalucia.com</a></p>"

        CUtilities = Nothing

        ' Return the Result
        Return szRetVal

    End Function

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

End Class
