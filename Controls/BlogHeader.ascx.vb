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
Imports System.Drawing.Bitmap
Partial Class Controls_BlogHeader
    Inherits System.Web.UI.UserControl
    'Inherits BasePage
    Public language As Integer
    Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ''   Response.Write(result(5))


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
        Page.Title = "Inland Andalucia - The inland Andalucia Property Specialist"
        Page.MetaDescription = "Welcome to Inland Andalucia Ltd. We are the real property specialist for inland Andalucia. Our service area is truly comprehensive and covers a large section of inland Andalucia. "
        Page.MetaKeywords = "Inland Andalucia, property in cordoba, property in jaen, property in Granada, property in Malaga, properties for sale in Seville Spain"
        If Not Session("language") = "" Then
            If ViewState("SampleText") Is Nothing Then
                ViewState("SampleText") = Session("language")
                bindFeaturedProperty()
            End If
            If Not ViewState("SampleText") = Session("language") Then
                bindFeaturedProperty()
                ViewState("SampleText") = Session("language")
            End If

        End If
        If Not Page.IsPostBack Then
            bindFeaturedProperty()
        End If
    End Sub

    Private Sub bindFeaturedProperty()


        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@language", language)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Featured", sql).Tables(0)
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
                    If col.ColumnName = "ImageUrl" Then
                        dr(col) = CUtilities.ApplyStatusWatermark(PhotoURL(dr("property_ref")), dr("status_id"))
                    End If
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            rpFeaturedProperty.DataSource = dt
            rpFeaturedProperty.DataBind()
        End If
    End Sub

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


    'Protected Sub imgmap_Click(sender As Object, e As ImageClickEventArgs)
    '    imgmap.Style.Add(HtmlTextWriterStyle.Display, "none")
    '    googleMap.Style.Add(HtmlTextWriterStyle.Display, "block")
    'End Sub
End Class
