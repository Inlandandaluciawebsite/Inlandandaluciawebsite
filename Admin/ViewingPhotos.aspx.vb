
Partial Class ViewingPhotos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Depending on the Postback
        If Not Request.QueryString("PropertyRef") Is Nothing Then

            ' Get the Property Reference
            Dim szPropertyRef As String = Request.QueryString("PropertyRef").ToString.Trim.ToUpper

            ' Load the Number of Images
            Dim CDataAccess As New ClassDataAccess
            Dim nNumberOfImages As Integer = CDataAccess.NumberOfPropertyImages(szPropertyRef)
            CDataAccess = Nothing

            ' Init HTML
            Dim szHTML As String = "<tr>"

            ' If we have at least 1 Image
            If nNumberOfImages > 0 Then

                ' Set the Property Ref
                LabelPropertyRef.Text = szPropertyRef

                ' For each Image
                For nImage As Integer = 1 To nNumberOfImages

                    ' Assign this Image
                    szHTML &= "<td width=""33%""><img src=""/images/photos/properties/" & szPropertyRef & "/" & szPropertyRef & "_" & nImage.ToString.Trim & ".jpg"" width=""225px"" height=""169px""></td>"

                    ' If we have Completed a Row
                    If nImage Mod 3 = 0 Then

                        ' Complete Row
                        szHTML &= "</tr>"

                        ' If there are More Images
                        If nImage < nNumberOfImages Then

                            ' Start New Row
                            szHTML &= "<tr>"

                        End If

                    End If

                Next

                ' Check to see if we need to Close the Row
                If Not szHTML.EndsWith("</tr>") Then

                    ' Complete Row
                    szHTML &= "</tr>"

                End If

                ' Close Table
                szHTML &= "</table>"

            End If

            ' Assign to Span
            SpanImages.InnerHtml = szHTML

        End If

    End Sub

End Class
