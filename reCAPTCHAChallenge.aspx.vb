
Partial Class reCAPTCHAChallenge
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        ' Check if reCAPTCHA Succeeded
        If Page.IsValid Then

            ' Define Content
            Dim szContent As String = _
                "First Name: " & Session("ContactFirstName") & vbCrLf & _
                "Last Name: " & Session("ContactLastName") & vbCrLf & _
                "Address: " & Session("ContactAddress") & vbCrLf & _
                "Telephone: " & Session("ContactTelephone") & vbCrLf & _
                "Email: " & Session("ContactEmail") & vbCrLf & _
                "Comment: " & vbCrLf & vbCrLf & Session("ContactComment") & vbCrLf & vbCrLf

            ' Send the Email
            Dim CUtilities As New ClassUtilities
            CUtilities.SendEmail("jason@techgenie.es", "Website Submission", szContent, False)

            ' Tidy
            CUtilities = Nothing

            ' Update Result
            LabelResult.text = "Email Sent"

            '' Remove Previous Controls
            'UpdatePanelContactUs.ContentTemplateContainer.Controls.Clear()

            '' Load Thank You Page
            'Dim ctrl As Control = LoadControl("Controls/WebUserControlThankYou.ascx")
            'ctrl.ID = "SearchResults1"

            '' Add Control to Update Panel
            'UpdatePanelContactUs.ContentTemplateContainer.Controls.Add(ctrl)

            'UpdatePanelContactUs.Update()

        Else

            ' Update Result
            LabelResult.text = "Failed.  Please Retry..."

        End If

    End Sub
End Class
