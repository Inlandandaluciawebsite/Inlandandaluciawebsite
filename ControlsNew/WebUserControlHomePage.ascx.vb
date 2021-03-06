
Imports System.IO
Imports System.Data
Imports HashSoftwares
Imports System.Data.SqlClient

Partial Public Class WebUserControlHomePage
    Inherits System.Web.UI.UserControl

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Doing some translation code for time being with in page load, because in future we are going to do same work with resource file in future : 
        'Code by sourabh sachdeva
        'Date : 9 March 2015

        If Session("Language") Is Nothing Then
            ltrlInnerTitle.Text = "The inland Andalucia Property Specialist"
            ltrlInnerTopText.Text = "Welcome to Inland Andalucia Ltd. We are the real property specialist for inland Andalucia. All locations and all property types: if it’s inland Andalucia, it’s us. Discover our very extensive and all-encompassing <a href='PropSearch.aspx'>inland property portfolio</a>"
        Else
            If Session("Language") = "English" Then
                ltrlInnerTitle.Text = "The inland Andalucia Property Specialist"
                ltrlInnerTopText.Text = "Welcome to Inland Andalucia Ltd. We are the real property specialist for inland Andalucia. All locations and all property types: if it’s inland Andalucia, it’s us. Discover our very extensive and all-encompassing <a href='PropSearch.aspx'>inland property portfolio</a>"
            End If
            If Session("Language") = "Spanish" Then
                ltrlInnerTitle.Text = "Su Inmobiliaria en el interior de Andalucía"
                ltrlInnerTopText.Text = "Bienvenido a Inland Andalucia Ltd, su Inmobiliaria situado en Mollina, Málaga y Alcalá la Real en Jaén. Estamos especializados en propriedades en el interior de Andalucía. Si usted busca una propiedad, sea un Cortijo, una hacienda, una finca o una casa de pueblo, un chalet o parcelas, llamanos o descubre la <a href='PropSearch.aspx'>cartera de propiedades</a>"
            End If
            If Session("Language") = "French" Then
                ltrlInnerTitle.Text = "Spécialiste de l’immobilier à l’interieur de l’Andalousie"
                ltrlInnerTopText.Text = "Bienvenue au véritable spécialiste de l'immobilier en Andalousie. Nous vous offrons la plus grande sélection des appartements, maisons, villas, chalets, terrains, ruines, fincas disponible en Andalousie.  Découvrez notre <a href='PropSearch.aspx'>portefeuille immobilier</a> et nous vous aidons à realiser votre rêve Espagnol."
            End If
            If Session("Language") = "German" Then
                ltrlInnerTitle.Text = "Immobilien Spezialist Andalusien"
                ltrlInnerTopText.Text = "Willkommen bei ihr Immobilienmakler für das echte Andalusien. Inland Andalucia Ltd ist ein wahre Andalusien Immobilien Spezialist. Besuchen Sie uns in Mollina oder Alcalá la Real, oder entdecken Sie unsere <a href='PropSearch.aspx'>Immobilienportfolio</a> mit sowohl große und kleine Villen cortijos, Hauser, Bauernhäuser, Villen, billige alte spanische Ruinen, wo Sie Ihr Spanisch Traumhaus erstellen können."
            End If
            If Session("Language") = "Dutch" Then
                ltrlInnerTitle.Text = "Uw makelaar voor het binnenland van Andalusië"
                ltrlInnerTopText.Text = "Welkom bij Inland Andalucia Ltd. Volledig gespecialiseerd in het binnenland van Andalusië, bieden we u de grootste selectie van landelijke eigendommen aan. Onze <a href='PropSearch.aspx'>portfolio met woningen in het binnenland</a> bevat elk type van eigendom, van grote en kleine fincas en cortijos, tot huisjes in dorpen, boerderijen, villas, percelen en zelfs goedkope Spaanse ruïnes. Begin uw Spaanse droom hier!"
            End If
        End If


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Local Vars
        'Dim CDataAccess As New ClassDataAccess
        'Dim CUtilities As New ClassUtilities
        'Dim szDelim = String.Empty

        '' Load Property Locations
        'Dim dtDataTable As DataTable = CDataAccess.PropertyLocations(CUtilities.GetLanguageID(Session("Language")))

        '' Tidy
        'CUtilities = Nothing

        '' Set the Number of Results
        'm_nNumberOfResults = dtDataTable.Rows.Count

        '' For each Row in the DataTable
        'For Each dr As DataRow In dtDataTable.Rows

        '    ' Append this to our Strings
        '    m_szLatitudes &= szDelim & dr.Item("latitude").ToString.Trim
        '    m_szLongitudes &= szDelim & dr.Item("longitude").ToString.Trim
        '    m_szInfoWindowHTML &= szDelim & GoogleInfoWindowHTML(Convert.ToInt32(dr.Item("property_id")), _
        '                                                         dr.Item("location").ToString.Trim, _
        '                                                         dr.Item("type").ToString.Trim, _
        '                                                         dr.Item("property_ref").ToString.Trim, _
        '                                                         PhotoURL(dr.Item("property_ref").ToString.Trim), _
        '                                                         Convert.ToInt32(dr.Item("price")),
        '                                                         Convert.ToInt32(dr.Item("status_id")))

        '    ' Set Delimiter
        '    szDelim = Chr(126)

        'Next

        '' Tidy
        'dtDataTable.Dispose()

        '' Get the Map Center Point
        'dtDataTable = CDataAccess.MapCenterPoint

        '' If we had a Row Returned
        'If dtDataTable.Rows.Count > 0 Then

        '    ' Set the Coordinates
        '    m_dLatitude = Convert.ToDouble(dtDataTable.Rows(0).Item("latitude"))
        '    m_dLongitude = Convert.ToDouble(dtDataTable.Rows(0).Item("longitude"))

        'End If

        '' Tidy
        'dtDataTable.Dispose()
        'CDataAccess = Nothing

    End Sub

    Private Function PhotoURL(ByVal szPropertyRef As String) As String

        ' Local Vars
        Dim szPath As String = "/images/photos/properties/" & szPropertyRef.Trim & "/" & szPropertyRef.Trim & "_1.jpg"

        ' Check we have the Image
        If Not File.Exists(Server.MapPath(szPath)) Then

            ' Set to No Image Photo
            szPath = "/images/icons/no-photo.png"

        End If

        ' Return the Result
        Return szPath

    End Function

    'Public Function GoogleInfoWindowHTML(ByVal nPropertyID As Integer, _
    '                                     ByVal szLocation As String, _
    '                                     ByVal szType As String, _
    '                                     ByVal szReference As String, _
    '                                     ByVal szImageURL As String, _
    '                                     ByVal nPrice As Integer,
    '                                     ByVal nStatusID As Integer) As String

    '    ' Local Vars
    '    Dim CUtilities As New ClassUtilities

    '    ' See if a Watermark is Required
    '    szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, nStatusID)

    '    ' Init HTML
    '    'Removed & GetTranslation("Location") & ": " 
    '    Dim szRetVal As String = _
    '        "<h5>" & szLocation.Trim & "</h5>" & _
    '        "<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
    '        "<p><a href=""propsearch.aspx?propertyref=" & szReference.ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Prop img"" width=""150"" height=""100""/></a></p>"

    '    If nPrice = 0 Then
    '        szRetVal &= "<p><strong>" & GetTranslation("Price") & ":</strong> P.O.A.</p>"
    '    Else
    '        szRetVal &= "<p><strong>" & GetTranslation("Price") & ":</strong> " & CUtilities.FormatPrice(nPrice) & "</p>"
    '    End If

    '    ' Continue to Construct HTML
    '    'szRetVal &= _
    '    '"<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """ title=""" & GetTranslation("More information") & """>+ info</a></p>"
    '    szRetVal &= _
    '    "<p><a href=""propsearch.aspx?propertyref=" & szReference.ToString.Trim & """ title=""" & GetTranslation("More information") & """>+ info</a></p>"

    '    ' Tidy
    '    CUtilities = Nothing

    '    ' Return the Result
    '    Return szRetVal

    'End Function

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    'Public Function ConvertDataTabletoString() As String
    '    Dim CDataAccess As New ClassDataAccess
    '    Dim CUtilities As New ClassUtilities
    '    Dim szDelim = String.Empty

    '    ' Load Property Locations
    '    Dim dt As DataTable = CDataAccess.PropertyLocationsTest(CUtilities.GetLanguageID(Session("Language")))

    '    ' Tidy
    '    CUtilities = Nothing
    '    Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
    '    Dim rows As New List(Of Dictionary(Of String, Object))()
    '    Dim row As Dictionary(Of String, Object)
    '    For Each dr As DataRow In dt.Rows
    '        row = New Dictionary(Of String, Object)()
    '        For Each col As DataColumn In dt.Columns
    '            If col.ColumnName = "formatprice" Then
    '                dr(col) = CUtilities.FormatPrice(dr("price"))
    '            End If
    '            If col.ColumnName = "url" Then
    '                dr(col) = CUtilities.ApplyStatusWatermark(PhotoURL(dr("property_ref")), dr("price"))
    '            End If
    '            row.Add(col.ColumnName, dr(col))
    '        Next
    '        rows.Add(row)
    '    Next
    '    Return serializer.Serialize(rows)
    'End Function


    Public Function ConvertDataTabletoString() As String
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@LanguageId", CUtilities.GetLanguageID(Session("Language")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_property_mapAllLocation", Sql).Tables(0)
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                If col.ColumnName = "formatprice" Then
                    dr(col) = CUtilities.FormatPrice(dr("price"))
                End If
                If col.ColumnName = "url" Then
                    dr(col) = CUtilities.ApplyStatusWatermark(PhotoURL(dr("property_ref").ToString.Trim), dr("status_id"))
                End If
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
    End Function
End Class
