Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Partial Class Changepassword
    Inherits System.Web.UI.Page

    Private m_szPassword As String
    Public Property Password() As String
        Get
            Return m_szPassword
        End Get
        Set(ByVal value As String)
            m_szPassword = value
        End Set
    End Property

    Private Function ValidateCurrent(ByVal szPassword As String) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean

        ' Init Message
        LabelMessage.Text = String.Empty

        ' Does the Password Match
        If TextBoxCurrentPassword.Text.Trim = Password.Trim Then

            ' Set the Image
            ImageCurrent.ImageUrl = "../Images/Icons/tick.jpg"

            ' Reset the Password
            TextBoxCurrentPassword.Attributes.Add("value", szPassword)

            ' Set Return Value
            bRetVal = True

        Else

            ' Set the Image
            ImageCurrent.ImageUrl = "../Images/Icons/cross.jpg"

            ' Update Label
            LabelMessage.Text = "The password entered is invalid"

            ' Set Return Value
            bRetVal = False

        End If

        ' Return the Result
        Return bRetVal

    End Function

    Private Function ValidateNew(ByVal szPassword As String) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean
        Dim bError As Boolean = False
        Dim nCounter As Integer = 0
        Dim szDelim As String = String.Empty

        ' Init Message
        LabelMessage.Text = String.Empty

        ' Check if the Password Entered is Valid - Length
        If szPassword.Trim.Length < 6 Then

            ' Update Error Message
            LabelMessage.Text = "Password must be at least 6 characters"

            ' Update Delimter
            szDelim = "<br> "

            ' Update Flag
            bError = True

        End If

        ' Check that the Password Contains Alphanumeric Characters only
        If Not Regex.IsMatch(szPassword, "^[a-zA-Z0-9]+$") Then

            ' Update Error Message
            LabelMessage.Text &= szDelim & "Password must contain alphanumerics only"

            ' Update Flag
            bError = True

        End If

        ' Check if the Password Entered is Valid - 2 Numbers
        For Each ch As Char In szPassword.Trim

            ' If this is Numeric
            If IsNumeric(ch) Then

                ' Increment Counter
                nCounter += 1

            End If

        Next

        ' Do we have at least 2 Numbers?
        If nCounter < 2 Then

            ' Update Error Message
            LabelMessage.Text &= szDelim & "Password must contain at least 2 numbers"

            ' Update Flag
            bError = True

        End If

        ' If Valid
        If Not bError Then

            ' Set the Image
            ImageNew.ImageUrl = "../Images/Icons/tick.jpg"

            ' Reset the Password
            TextBoxNewPassword.Attributes.Add("value", szPassword)

            ' Set Return Value
            bRetVal = True

        Else

            ' Set the Image
            ImageNew.ImageUrl = "../Images/Icons/cross.jpg"

            ' Clear Password
            TextBoxNewPassword.Attributes.Add("value", String.Empty)

            ' Set Return Value
            bRetVal = False

        End If

        ' Return the Result
        Return bRetVal

    End Function

    Private Function ValidateConfirmation(ByVal szPassword As String) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean

        ' Init Message
        LabelMessage.Text = String.Empty

        ' Do the Passwords Match?
        If TextBoxNewPassword.Text.Trim = TextBoxConfirmPassword.Text.Trim Then

            ' Set the Image
            ImageConfirm.ImageUrl = "../Images/Icons/tick.jpg"

            ' Set the Return Value
            bRetVal = True

        Else

            ' Set the Image
            ImageConfirm.ImageUrl = "../Images/Icons/cross.jpg"

            ' Set the Message
            LabelMessage.Text = "The passwords do not match"

            ' Reset Password
            szPassword = String.Empty

            ' Set Return Value
            bRetVal = False

        End If

        ' Make the Image Visible
        ImageConfirm.Visible = ImageNew.Visible

        ' Reset the Password
        TextBoxConfirmPassword.Attributes.Add("value", szPassword)

        ' Return the Result
        Return bRetVal

    End Function

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Check to see if the User is already logged in
        If Session("ContactID") Is Nothing Then

            ' Redirect to the Agent Area
            Response.Redirect("AgentLogin.aspx")

        Else

            ' Get the Password for this User
            Dim CDataAccess As New ClassDataAccess
            Password = CDataAccess.GetPassword(Convert.ToInt32(Session("ContactID")))
            CDataAccess = Nothing

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        ' If not a Postback
        If Not IsPostBack Then

            ' Set Focus to Existing
            TextBoxConfirmPassword.Focus()

        End If

    End Sub

    Protected Sub TextBoxCurrentPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxCurrentPassword.TextChanged

        ' Validate Input
        If ValidateCurrent(TextBoxCurrentPassword.Text.Trim) Then

            ' Set Focus to New
            TextBoxNewPassword.Focus()

        Else

            ' Re Enter
            TextBoxCurrentPassword.Focus()

        End If

        ' Make the Image Visible
        ImageCurrent.Visible = True

    End Sub

    Protected Sub TextBoxNewPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxNewPassword.TextChanged

        ' Validate Input
        If ValidateNew(TextBoxNewPassword.Text.Trim) Then

            ' Set Focus to Confirm
            TextBoxConfirmPassword.Focus()

        Else

            ' Re Enter
            TextBoxNewPassword.Focus()

        End If

        ' Make the Image Visible
        ImageNew.Visible = True

    End Sub

    Protected Sub TextBoxConfirmPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxConfirmPassword.TextChanged

        ' Validate Input
        If ValidateConfirmation(TextBoxConfirmPassword.Text.Trim) Then

            ' Set Focus to Save
            ButtonSave.Focus()

        Else

            ' Re Enter
            TextBoxConfirmPassword.Focus()

        End If

        ' Make the Image Visible
        ImageConfirm.Visible = True

    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' Check to see if the User is already logged in
        If Session("ContactID") Is Nothing Then

            ' Redirect to the Agent Area
            Response.Redirect("AgentLogin.aspx")

        Else

            ' Ensure all Inputs are Valid
            If ValidateCurrent(TextBoxCurrentPassword.Text.Trim) And ValidateNew(TextBoxNewPassword.Text.Trim) And ValidateConfirmation(TextBoxConfirmPassword.Text.Trim) Then

                ' Write this Change to the Database
                Dim CDataAccess As New ClassDataAccess
                CDataAccess.UpdatePassword(Convert.ToInt32(Session("ContactID")), TextBoxConfirmPassword.Text.Trim)
                CDataAccess = Nothing

                ' Clear all Fields
                TextBoxCurrentPassword.Attributes.Add("value", String.Empty)
                TextBoxNewPassword.Attributes.Add("value", String.Empty)
                TextBoxConfirmPassword.Attributes.Add("value", String.Empty)

                ' Update Password
                Password = TextBoxConfirmPassword.Text.Trim

                ' Hide the Table and Save Button
                TablePassword.Visible = False
                ButtonSave.Visible = False

                ' Update Label
                LabelMessage.Text = "Password successfully updated"

            End If

        End If

    End Sub
End Class
