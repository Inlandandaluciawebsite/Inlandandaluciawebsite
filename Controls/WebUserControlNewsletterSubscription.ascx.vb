
Partial Class WebUserControlNewsletterSubscription
    Inherits System.Web.UI.UserControl

    Public Event MessageValidated As System.EventHandler

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Public Function GetImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/Images/Buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "subscribe-es.png"

            Case 3
                ' French
                szRetVal &= "subscribe-fr.png"

            Case 4
                ' German
                szRetVal &= "subscribe-de.png"

            Case Else
                ' English
                szRetVal &= "subscribe-en.png"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Protected Sub Subscribe_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Subscribe.Click

        ' Ignore Bots
        If TextBoxBotTrap.Value.Trim = String.Empty Then

            ' Local Vars
            Dim bProceed As Boolean = True

            ' Check we have all the Mandatory Information

            ' Name
            If TextBoxName.Text.Trim = String.Empty Then

                ' Highlight Field
                TextBoxName.BackColor = Drawing.Color.LightGray

                ' Inform the User
                LabelName.Text = GetTranslation("Please enter your name")
                LabelName.Visible = True

                ' Set Flag
                bProceed = False

            Else

                ' Remove Highlight
                TextBoxName.BackColor = Drawing.Color.White

                ' Inform the User
                LabelName.Visible = False

                ' Save for Future
                Session("SubscriberName") = StrConv(TextBoxName.Text.Trim, VbStrConv.ProperCase)

            End If

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
                    Session("SubscriberEmail") = TextBoxEmail.Text.ToLower.Trim

                End If

            End If

            ' If we have All Info
            If bProceed Then

                ' Set Unsubscribe Value
                Session("Unsubscribe") = CheckBoxUnsubscribe.Checked

                ' Send
                RaiseEvent MessageValidated(Me, e)

            End If

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If we know the Name and Email Address of the User, Pre Populate
        ' If not Postback
        If Not Page.IsPostBack Then

            ' If we have the First Name
            If Not Session("FirstName") Is Nothing Then
                TextBoxName.Text = Convert.ToString(Session("FirstName")).Trim
            End If

            ' If we have the Last Name
            If Not Session("LastName") Is Nothing Then
                TextBoxName.Text &= " " & Convert.ToString(Session("LastName")).Trim
            End If

            ' If we have the Email
            If Not Session("Email") Is Nothing Then
                TextBoxEmail.Text = Session("Email")
            End If

        End If

    End Sub
End Class
