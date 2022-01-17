
Partial Class WebUserControlContactUs
    Inherits System.Web.UI.UserControl

    Public Event MessageValidated As System.EventHandler

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If not Postback
        If Not Page.IsPostBack Then

            ' If we have the First Name
            If Not Session("FirstName") Is Nothing Then
                TextBoxFirstName.Text = Session("FirstName")
            End If

            ' If we have the Last Name
            If Not Session("LastName") Is Nothing Then
                TextBoxLastName.Text = Session("LastName")
            End If

            ' If we have the Address
            If Not Session("Address") Is Nothing Then
                TextBoxAddress.Text = Session("Address")
            End If

            ' If we have the Telephone
            If Not Session("Telephone") Is Nothing Then
                TextBoxTelephone.Text = Session("Telephone")
            End If

            ' If we have the Email
            If Not Session("Email") Is Nothing Then
                TextBoxEmail.Text = Session("Email")
            End If

            ' Is there a Property Reference
            If Not Request.QueryString("reference") Is Nothing Then

                ' Update the Comment with the Reference
                TextBoxComment.Text = "Hi" & vbCrLf & vbCrLf & "I am interested in property reference " & Request.QueryString("reference").ToUpper.Trim & ".  Please can you contact me regarding this property using the contact details provided?" & vbCrLf & vbCrLf & "Best Regards" & vbCrLf & vbCrLf

                ' If we have the First Name
                If Not Session("FirstName") Is Nothing Then
                    TextBoxComment.Text &= Session("FirstName")
                End If

                ' Set the Session Value
                Dim CDataAccess As New ClassDataAccess
                Session("ContactUsEmail") = CDataAccess.PartnerEmail(Request.QueryString("reference").ToUpper.Trim)
                Session("ContactUsName") = CDataAccess.PartnerName(Request.QueryString("reference").ToUpper.Trim)
                CDataAccess = Nothing

            Else

                ' No Property Reference.  Reset to avoid Message going to wrong Office.              
                Session("ContactUsEmail") = Nothing
                Session("ContactUsName") = Nothing

            End If

        End If

    End Sub

    Public Function GetImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/Images/Buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "enviar.png"

            Case 3
                ' French
                szRetVal &= "envoyer.png"

            Case 4
                ' German
                szRetVal &= "senden.png"

            Case 5
                ' Dutch
                szRetVal &= "send-the-form-nl.png"

            Case Else
                ' English
                szRetVal &= "send-the-form.png"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Public Function GetFirstNameErrorText() As String
        Return GetTranslation("Please enter your first name")
    End Function

    Public Function GetLastNameErrorText() As String
        Return GetTranslation("Please enter your last name")
    End Function

    Public Function GetEmailMissingErrorText() As String
        Return GetTranslation("Please enter an email address")
    End Function

    Public Function GetCommentErrorText() As String
        Return GetTranslation("Please enter a comment")
    End Function

    Protected Sub ButtonSend_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ButtonSend.Click

        ' Ignore Bots
        If TextBoxBotTrap.Value.Trim = String.Empty Then

            ' Local Vars
            Dim bProceed As Boolean = True

            ' Check we have all the Mandatory Information

            ' First Name
            If TextBoxFirstName.Text.Trim = String.Empty Then

                ' Highlight Field
                TextBoxFirstName.BackColor = Drawing.Color.LightGray

                ' Inform the User
                LabelFirstName.Visible = True

                ' Set Flag
                bProceed = False

            Else

                ' Remove Highlight
                TextBoxFirstName.BackColor = Drawing.Color.White

                ' Inform the User
                LabelFirstName.Visible = False

                ' Save for Future
                Session("FirstName") = StrConv(TextBoxFirstName.Text.Trim, VbStrConv.ProperCase)

            End If

            ' Last Name
            If TextBoxLastName.Text.Trim = String.Empty Then

                ' Highlight Field
                TextBoxLastName.BackColor = Drawing.Color.LightGray

                ' Inform the User
                LabelLastName.Visible = True

                ' Set Flag
                bProceed = False

            Else

                ' Remove Highlight
                TextBoxLastName.BackColor = Drawing.Color.White

                ' Inform the User
                LabelLastName.Visible = False

                ' Save for Future
                Session("LastName") = StrConv(TextBoxLastName.Text.Trim, VbStrConv.ProperCase)

            End If

            ' Store Address and Telephone for Future
            Session("Address") = StrConv(TextBoxAddress.Text.Trim, VbStrConv.ProperCase)
            Session("Telephone") = TextBoxTelephone.Text.Trim

            ' Email
            If TextBoxEmail.Text.Trim = String.Empty Then

                ' Highlight Field
                TextBoxEmail.BackColor = Drawing.Color.LightGray

                ' Inform the User
                LabelEmailAddress.Text = GetTranslation("Please enter your email address")
                LabelEmailAddress.Visible = True

                ' Set Flag
                bProceed = False

            Else

                ' Check that the Email Address is Valid
                If Not Regex.IsMatch(TextBoxEmail.Text.Trim, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") Then

                    ' Invalid Email Address

                    ' Highlight Field
                    TextBoxEmail.BackColor = Drawing.Color.LightGray

                    ' Inform the User
                    LabelEmailAddress.Text = GetTranslation("Please enter a valid email address")
                    LabelEmailAddress.Visible = True

                    ' Set Flag
                    bProceed = False

                Else

                    ' Remove Highlight
                    TextBoxEmail.BackColor = Drawing.Color.White

                    ' Inform the User
                    LabelEmailAddress.Visible = False

                    ' Save for Future
                    Session("Email") = TextBoxEmail.Text.ToLower.Trim

                End If

            End If

            ' Comment
            If TextBoxComment.Text.Trim = String.Empty Then

                ' Highlight Field
                TextBoxComment.BackColor = Drawing.Color.LightGray

                ' Inform the User
                LabelComment.Visible = True

                ' Set Flag
                bProceed = False

            Else

                ' Remove Highlight
                TextBoxComment.BackColor = Drawing.Color.White

                ' Inform the User
                LabelComment.Visible = False

                ' Save the Comment
                Session("Comment") = TextBoxComment.Text.Trim

            End If

            ' If we have All Info
            If bProceed Then

                ' Check that we have not Issued more than 3 Messages Today
                Dim CDataAccess As New ClassDataAccess
                Dim CUtilities As New ClassUtilities

                ' Validate this IP
                If CDataAccess.SendMessageIPCheck(CUtilities.GetIPAddress) Then

                    ' Send
                    RaiseEvent MessageValidated(Me, e)

                Else

                    ' Inform the User
                    LabelComment.Text = "Message service blocked due to multiple requests"
                    LabelComment.Visible = True

                End If

                ' Tidy
                CDataAccess = Nothing
                CUtilities = Nothing

            End If

        End If

    End Sub

End Class
