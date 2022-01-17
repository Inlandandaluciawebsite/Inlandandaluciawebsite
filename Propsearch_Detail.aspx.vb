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
Imports Newtonsoft.Json
Imports GoogleMaps.LocationServices
Partial Class Propsearch_Detail
    '  Inherits System.Web.UI.Page
    Inherits BasePage
    Private m_szReference As String
    Public ReadOnly Property Referencem() As String
        Get
            Return m_szReference
        End Get
    End Property
  
    Public Latitude As Double, Longitude As Double, Reference As String, nPropertyID As Integer
    Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Page.Title = "Andalucia property | Inland Andalucia"
        ' If Not Page.IsPostBack Then
        btnback.Attributes.Add("onClick", "javascript:history.back(); return false;")

        If Not Request.QueryString("propertyref") Is Nothing Then
            m_szReference = Request.QueryString("propertyref")
            binddetail(Request.QueryString("propertyref"))
        ElseIf Not Request.QueryString("propertyid") Is Nothing Then
            Dim CDataAccess As New ClassDataAccess
            Dim propref = CDataAccess.PropertyRef(Convert.ToInt32(Request.QueryString("propertyid")))
            m_szReference = propref
            nPropertyID = Convert.ToInt32(Request.QueryString("propertyid"))
            binddetail(propref)
        End If

        ' End If
    End Sub
    Public Function GetTranslation(ByVal szText As String, Optional ByVal bHTMLSafe As Boolean = False) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation01(szText, Session("Language"), bHTMLSafe).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Private Sub binddetail(proprefrence As String)
        Dim language As Integer
        If Not Session("language") = "" Then
            Dim language1 As String = Session("language")
            Select Case language1

                Case "de-de"
                    language = 2

                Case "fr"
                    language = 3

                Case "nl"
                    language = 4

                Case "da"
                    language = 5

                Case Else
                    language = 1

            End Select
        Else
            language = 1
        End If

        Dim sql As SqlParameter() = New SqlParameter(2) {}

        sql(0) = New SqlParameter("@PropRef", proprefrence)
        sql(1) = New SqlParameter("@language", language)
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
            dt = CDataAccess.PropertyDetail(proprefrence, language, Convert.ToInt32(Session("ContactPartnerID")))

        End If

        If dt.Rows.Count > 0 Then

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
                    If col.ColumnName = "description" Then
                        dr(col) = GetTranslation(dr("description"))
                    End If
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next

            rpdetail.DataSource = dt
            rpdetail.DataBind()

            If Not (dt.Rows(0)("video_url")) = "" Then
                vidio.InnerHtml = ""
                vidio.InnerHtml = "<a href='https://youtube.googleapis.com/v/" & dt.Rows(0)("video_url") & "%26autoplay=1' target=""_blank""><img src=""" & GetVideoImagePath() & """ alt=""Video"" border=""0"" hspace=""5"" /></a>"
            End If

            Latitude = dt.Rows(0)("latitude")
            Longitude = dt.Rows(0)("longitude")
            Reference = dt.Rows(0)("reference")

            notfound.Style.Add(HtmlTextWriterStyle.Display, "none")
            topmenu.Style.Add(HtmlTextWriterStyle.Display, "block")
            fbshare.Style.Add(HtmlTextWriterStyle.Display, "block")
        Else

            notfound.Style.Add(HtmlTextWriterStyle.Display, "block")
            topmenu.Style.Add(HtmlTextWriterStyle.Display, "none")
            fbshare.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If

        If Not String.IsNullOrEmpty(Request.QueryString("propertyref")) Then
            Email.InnerHtml = "<a href='mailto:&subject=Property of Interest &body=Hi%0A%0A I have just been on www.inlandandalucia.com and I saw this property which I thought may be of interest to you:%0A%0Ahttp://inlandandalucia.hashsoftwares.com/Propsearch_Detail.aspx%3Fpropertyref=" & Request.QueryString("propertyref").ToString() & "%0A%0A Regards%0A%0A'> " & GetEmailImagePath() & "</a>"
        Else
            ' Email.InnerHtml = "<a href='mailto:&subject=Property of Interest&body=Hi%0A%0AI have just been on www.inlandandalucia.com and I saw this property which I thought may be of interest to you:%0A%0Ahttp://www.inlandandalucia.com/Propsearch_Detail.aspx%3Fpropertyid=" & PropertyID.ToString.Trim & "%0A%0ARegards%0A%0A'><i class='fa fa-envelope-o'> </i> Email</a>"
        End If



        ' Define the Contact Us Button
        ContactUs.InnerHtml = "<a href='contactus.aspx?reference=" & Referencem & "'>" & GetContactUsImagePath() & "</a>"


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

                    Case "de-de"
                        language = 2

                    Case "fr"
                        language = 3

                    Case "nl"
                        language = 4

                    Case "da"
                        language = 5

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
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_PropertyDetail_ByPropRef01", sql).Tables(0)
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
        Dim szRetVal As String = "images/"

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

    Protected Sub rpdetail_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)



        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then

            Dim number As HiddenField = DirectCast(e.Item.FindControl("propnum"), HiddenField)

            Dim status As HiddenField = DirectCast(e.Item.FindControl("statusid"), HiddenField)
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


                szImageURL = "images/photos/properties/" & Referencem.Trim & "/" & Referencem.Trim & "_" & num.ToString.Trim & ".jpg"
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
  
   
  
   
End Class
