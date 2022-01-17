Imports System.IO
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebUserControlPropertyOverview
    Inherits System.Web.UI.UserControl

    Private m_nPropertyID As Integer
    Public ReadOnly Property PropertyID() As Integer
        Get
            Return m_nPropertyID
        End Get
    End Property

    Public Function PhotoURL() As String

        ' Local Vars
        Dim szPath As String = "~/images/photos/properties/" & Reference.Trim & "/" & Reference.Trim & "_1.jpg"

        ' Check we have the Image
        If Not File.Exists(Server.MapPath(szPath)) Then

            ' Set to No Image Photo
            szPath = "~/images/icons/no-photo.png"

        End If

        ' Return the Result
        Return szPath

    End Function

    Private m_nStatusID As String
    Public ReadOnly Property StatusID() As String
        Get
            Return m_nStatusID
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

            ' Remove a Sub Area of 'Not Specified'
            If m_szSubArea.ToLower.Trim = "not specified" Then
                Return String.Empty
            Else
                Return " / " & m_szSubArea.Trim
            End If

        End Get
    End Property

    Private m_szDescription As String
    Public ReadOnly Property Description() As String
        Get
            ' Depending on the Length of the Description
            If m_szDescription.Trim.Length > 520 Then
                Return m_szDescription.Substring(0, Math.Min(m_szDescription.Trim.Length, 520)).Trim & "..."
            Else
                Return m_szDescription.Trim
            End If
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

    'Public Sub InitPropertyDetails(ByVal nPropertyID As Integer, _
    '                                ByVal szType As String, _
    '                                ByVal szReference As String, _
    '                                ByVal szRegion As String, _
    '                                ByVal szArea As String, _
    '                                ByVal szSubArea As String, _
    '                                ByVal szDescription As String, _
    '                                ByVal nBedrooms As Integer, _
    '                                ByVal nBathrooms As Integer, _
    '                                ByVal nBuiltSize As Integer, _
    '                                ByVal nPlotSize As Integer, _
    '                                ByVal dPrice As Double)

    '    ' Set Property Variables
    '    m_nPropertyID = nPropertyID
    '    m_szType = szType
    '    m_szReference = szReference
    '    m_szRegion = szRegion
    '    m_szArea = szArea
    '    m_szSubArea = szSubArea
    '    m_szDescription = szDescription
    '    m_nBedrooms = nBedrooms
    '    m_nBathrooms = nBathrooms
    '    m_nBuiltSize = nBuiltSize
    '    m_nPlotSize = nPlotSize
    '    m_dPrice = dPrice

    'End Sub

    Public Function GetImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

        If Session("Language") Is Nothing Then

            ' Add English Path
            szRetVal &= "more-info.gif"

        Else

            ' Depending on the Language
            Dim CUtilities As New ClassUtilities

            Select Case CUtilities.GetLanguageID(Session("Language"))

                Case 2
                    ' Spanish
                    szRetVal &= "more-info-ES.gif"

                Case 3
                    ' French
                    szRetVal &= "more-info-FR.gif"

                Case 4
                    ' German
                    szRetVal &= "more-info-DE.gif"

                Case Else
                    ' English
                    szRetVal &= "more-info.gif"

            End Select

            ' Tidy
            CUtilities = Nothing

        End If

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        ' Assign Variables
        m_nPropertyID = Session("OverviewPropertyID")
        m_nStatusID = Session("OverviewStatusID")
        m_szType = Session("OverviewType")
        m_szReference = Session("OverviewReference")
        m_szPartnerReference = Session("OverviewPartnerReference")
        m_szRegion = Session("OverviewRegion")
        m_szArea = Session("OverviewArea")
        m_szSubArea = Session("OverviewSubArea")
        m_szShortDescription = Session("OverviewShortDescription")
        m_szDescription = Session("OverviewDescription")
        m_nBedrooms = Session("OverviewBedrooms")
        m_nBathrooms = Session("OverviewBathrooms")
        m_nBuiltSize = Session("OverviewSQMBuilt")
        m_nPlotSize = Session("OverviewSQMPlot")
        m_dPrice = Session("OverviewPrice")
        m_dOriginalPrice = Session("OverviewOriginalPrice")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Local Vars
        Dim CUtilities As New ClassUtilities

        ' See if a Watermark is Required
        Dim szImageURL As String = CUtilities.ApplyStatusWatermark(PhotoURL, StatusID)

        ' Tidy
        CUtilities = Nothing

        ' Assign to Image
        ImageProperty.ImageUrl = szImageURL
        ImageProperty.AlternateText = "No Image Available"
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@Property_ID", PropertyID)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Select_By_PropertyId", sql).Tables(0)

        ' If this is in Agent Area
        If Session("ContactID") Is Nothing Then

            ' Normal Mode
            'MoreInfoButton.InnerHtml = "<a href='propsearch.aspx?propertyid=" & PropertyID.ToString.Trim & "' title=""more information""><img src=""" & GetImagePath() & """ alt=""More info"" name=""More information"" width=""116"" height=""31"" border=""0"" id=""More information"" /></a>"
            MoreInfoButton.InnerHtml = "<a href='propsearch.aspx?propertyref=" & dt.Rows(0)("Property_Ref").ToString() & "' title=""more information""><img src=""" & GetImagePath() & """ alt=""More info"" name=""More information"" width=""116"" height=""31"" border=""0"" id=""More information"" /></a>"

        Else

            ' Agent Area Mode
            'MoreInfoButton.InnerHtml = "<a href='AgentArea.aspx?propertyid=" & PropertyID.ToString.Trim & "' title=""more information""><img src=""" & GetImagePath() & """ alt=""More info"" name=""More information"" width=""116"" height=""31"" border=""0"" id=""More information"" /></a>"
            MoreInfoButton.InnerHtml = "<a href='AgentArea.aspx?PropertyID=" & dt.Rows(0)("Property_ID").ToString() & "' title=""more information""><img src=""" & GetImagePath() & """ alt=""More info"" name=""More information"" width=""116"" height=""31"" border=""0"" id=""More information"" /></a>"

        End If


    End Sub

    Protected Sub ImageProperty_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageProperty.Click

        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@Property_ID", PropertyID)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Select_By_PropertyId", sql).Tables(0)

        ' If this is in Agent Area
        If Session("ContactID") Is Nothing Then

            ' Normal
            'Response.Redirect("propsearch.aspx?propertyid=" & PropertyID.ToString.Trim)
            Response.Redirect("propsearch.aspx?propertyref=" & dt.Rows(0)("Property_Ref").ToString())

        Else

            ' Agent Area
            'Response.Redirect("AgentArea.aspx?propertyid=" & PropertyID.ToString.Trim)
            Response.Redirect("AgentArea.aspx?propertyid=" & dt.Rows(0)("Property_ID").ToString())

        End If

    End Sub

End Class
