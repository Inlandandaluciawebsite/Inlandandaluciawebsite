Imports System.Data
Imports System.IO

Partial Class Controls_WebUserControlFeaturedProperties
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        Dim szHTML As String = String.Empty
        Dim nPropertyCounter As Integer = 0
        Dim nFrameCounter As Integer = 0
        Dim nFeaturedPropertyCounter As Integer = 0
        Dim szImageURL As String

        ' Load the Featured Properties
        Dim dtDataTable As DataTable = CDataAccess.FeaturedProperties(CUtilities.GetLanguageID(Session("Language")), True)

        ' Init Frame HTML
        szHTML = "<div id=""featured1b-click-prev"">&laquo;Prev</div>"

        ' For each Row Returned - Frames
        For Each dr As DataRow In dtDataTable.Rows

            ' If the Property Counter is the First
            If nPropertyCounter Mod 3 = 0 Then

                ' Add Frame
                szHTML &= "<div id=""featured1b-item-" & nFrameCounter.ToString.Trim & """>" & (nFrameCounter + 1).ToString.Trim & "</div>"

                ' Increment Frame Counter
                nFrameCounter += 1

            End If

            ' Increment Property Counter
            nPropertyCounter += 1

        Next

        ' Terminate Frame HTML
        szHTML &= "<div id=""featured1b-click-next"">Next&raquo;</div>"

        ' Add to Span
        FeaturedFrames.InnerHtml = szHTML.Trim

        ' Init HTML
        szHTML = String.Empty

        ' Reset Counters
        nPropertyCounter = 0
        nFrameCounter = 0

        ' For each Row Returned - Properties
        For Each dr As DataRow In dtDataTable.Rows

            ' Increment the Featured Property Counter
            nFeaturedPropertyCounter += 1

            ' If we are Starting a new Frame
            If nPropertyCounter = 0 Then

                ' Init HTML
                szHTML &= "<div id=""featured1a-item-" & nFrameCounter.ToString.Trim & """>"

                ' Add Header
                szHTML &= "<h1>" & CDataAccess.GetTranslation("Featured Properties", CUtilities.GetLanguageID(Session("Language"))).Trim & "</h1>"

            End If

            ' Add the Opening DIV
            szHTML &= "<div class=""featuredproperty"">"

            ' Prep Image            

            ' Get the Image URL
            szImageURL = CUtilities.ApplyStatusWatermark(PhotoURL(dr("property_ref").ToString.Trim), Convert.ToInt32(dr("status_id")))

            ' Add the Image
            'szHTML &= "<a href=""/propsearch.aspx?propertyid=" & dr("property_id").ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Featured " & nFeaturedPropertyCounter.ToString.Trim & """ /></a>"
            szHTML &= "<a href=""/propsearch.aspx?propertyref=" & dr("property_ref").ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Featured " & nFeaturedPropertyCounter.ToString.Trim & """ /></a>"

            ' Continue to Init HTML
            szHTML &= "<p>"
            szHTML &= "<br />"
            szHTML &= "<strong>" & dr("type").ToString.Trim & "</strong>"
            szHTML &= "<br />"
            szHTML &= dr("region").ToString.Trim & "<br />"
            szHTML &= dr("area").ToString.Trim & "<br />"
            szHTML &= "<strong>" & CUtilities.FormatPrice(Convert.ToInt32(dr("price"))) & "</strong><br />"

            ' Do we have an Original rice to Display?
            If Convert.ToInt32(dr("original_price")) > 0 Then
                szHTML &= "<span class=""red"">" & CUtilities.FormatPrice(Convert.ToInt32(dr("original_price"))) & "</span><br />"
            End If

            szHTML &= "<br />"
            'szHTML &= "<a href=""/propsearch.aspx?propertyid=" & dr("property_id").ToString.Trim & """ title=""More information"">+info</a>"
            szHTML &= "<a href=""/propsearch.aspx?propertyref=" & dr("property_ref").ToString.Trim & """ title=""More information"">+info</a>"
            szHTML &= "</p>"
            szHTML &= "</div>"

            ' Increment Property Counter
            nPropertyCounter += 1

            ' If the Propert Counter is 3, Completed a Frame
            If nPropertyCounter > 2 Then

                ' Add Closing DIV
                szHTML &= "</div>"

                ' Reset Property Counter
                nPropertyCounter = 0

                ' Increment Frame Counter
                nFrameCounter += 1

            End If

        Next

        ' If the Property Counter <> 0, we have an Unclosed Frame so Close
        If nPropertyCounter <> 0 Then

            ' Add Closing DIV
            szHTML &= "</div>"

        End If

        ' Tidy
        CUtilities = Nothing
        CDataAccess = Nothing

        ' Add to Span
        FeaturedProperties.InnerHtml = szHTML.Trim

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

End Class
