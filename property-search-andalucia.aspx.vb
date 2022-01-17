Imports System.Data
Imports HashSoftwares
Imports System.IO
Imports System.Data.SqlClient

Partial Class property_search_andalucia
    ' Inherits System.Web.UI.Page
    Inherits BasePage
    Public Function ConvertDataTabletoString() As String
        Dim CUtilities As New ClassUtilities
        Dim language As Integer
        If Not Session("language") = "" Then
            Dim language1 As String = Session("language")
            Select Case language1

                Case "Spanish"
                    language = 2

                Case "French"
                    language = 3

                Case "German"
                    language = 5

                Case "Dutch"
                    language = 4

                Case Else
                    language = 1

            End Select
        Else
            language = 1
        End If

        'Dim sql As SqlParameter() = New SqlParameter(1) {}
        'sql(0) = New SqlParameter("@LanguageId", language)
        'Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_property_mapAllLocation", sql).Tables(0)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_property_mapAllLocation_By_Areas").Tables(0)
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
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Set Session Variables
        Page.Title = "Inland Andalucia | Property Search by Google Map"
    End Sub
End Class
