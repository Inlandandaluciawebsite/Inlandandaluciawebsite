Imports System.Data
Imports System.IO

Partial Public Class WebUserControlGoogleMapPage
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

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        Dim szDelim = String.Empty

        ' Load Property Locations
        Dim dtDataTable As DataTable = CDataAccess.PropertyLocations(CUtilities.GetLanguageID(Session("Language")))

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
                                                                 PhotoURL(dr.Item("property_ref").ToString.Trim), _
                                                                 Convert.ToInt32(dr.Item("price")),
                                                                 Convert.ToInt32(dr.Item("status_id")))

            ' Set Delimiter
            szDelim = Chr(126)

        Next

        ' Tidy
        dtDataTable.Dispose()

        ' Get the Map Center Point
        dtDataTable = CDataAccess.MapCenterPoint

        ' If we had a Row Returned
        If dtDataTable.Rows.Count > 0 Then

            ' Set the Coordinates
            m_dLatitude = Convert.ToDouble(dtDataTable.Rows(0).Item("latitude"))
            m_dLongitude = Convert.ToDouble(dtDataTable.Rows(0).Item("longitude"))

        End If

        ' Tidy
        dtDataTable.Dispose()

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

    Public Function GoogleInfoWindowHTML(ByVal nPropertyID As Integer, _
                                         ByVal szLocation As String, _
                                         ByVal szType As String, _
                                         ByVal szReference As String, _
                                         ByVal szImageURL As String, _
                                         ByVal nPrice As Integer,
                                         ByVal nStatusID As Integer) As String

        ' Local Vars
        Dim CUtilities As New ClassUtilities

        ' Prep Image            

        ' See if a Watermark is Required
        szImageURL = CUtilities.ApplyStatusWatermark(szImageURL, nStatusID)

        ' Init HTML
        'Dim szRetVal As String = _
        '"<h2>" & GetTranslation("Location") & ": " & szLocation.Trim & "</h2>" & _
        '"<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
        '"<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Property Image"" width=""150"" height=""100""/></a></p>"
        '    Dim szRetVal As String = _
        '        "<h2>" & GetTranslation("Location") & ": " & szLocation.Trim & "</h2>" & _
        '        "<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
        '        "<p><a href=""propsearch.aspx?propertyref=" & szReference.ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Property Image"" width=""150"" height=""100""/></a></p>"

        '    If nPrice = 0 Then
        '        szRetVal &= "<p><strong>" & GetTranslation("Price") & ":</strong> P.O.A.</p>"
        '    Else
        '        szRetVal &= "<p><strong>" & GetTranslation("Price") & ":</strong> " & CUtilities.FormatPrice(nPrice) & "</p>"
        '    End If

        '    ' Continue to Construct HTML
        '    'szRetVal &= _
        '    '    "<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """ title=""" & GetTranslation("More information") & """>+ info</a></p>" & _
        '    '    "<p><a href=""http://www.inlandandalucia.com"" title=""InlandAndalucia.com"">InlandAndalucia.com</a></p>"
        '    szRetVal &= _
        '"<p><a href=""propsearch.aspx?propertyref=" & szReference.ToString.Trim & """ title=""" & GetTranslation("More information") & """>+ info</a></p>" & _
        '"<p><a href=""http://www.inlandandalucia.com"" title=""InlandAndalucia.com"">InlandAndalucia.com</a></p>"

        '    CUtilities = Nothing

        'Removed & GetTranslation("Location") & ": " 
        Dim szRetVal As String = _
            "<h5>" & szLocation.Trim & "</h5>" & _
            "<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
            "<p><a href=""propsearch.aspx?propertyref=" & szReference.ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Prop img"" width=""150"" height=""100""/></a></p>"

        If nPrice = 0 Then
            szRetVal &= "<p><strong>" & GetTranslation("Price") & ":</strong> P.O.A.</p>"
        Else
            szRetVal &= "<p><strong>" & GetTranslation("Price") & ":</strong> " & CUtilities.FormatPrice(nPrice) & "</p>"
        End If

        ' Continue to Construct HTML
        'szRetVal &= _
        '"<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """ title=""" & GetTranslation("More information") & """>+ info</a></p>"
        szRetVal &= _
        "<p><a href=""propsearch.aspx?propertyref=" & szReference.ToString.Trim & """ title=""" & GetTranslation("More information") & """>+ info</a></p>"

        ' Tidy
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
