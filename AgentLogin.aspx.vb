Imports System.Data.SqlClient
Imports System.Data
Imports HashSoftwares

Partial Class AgentLogin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Redirect("https://inlandandalucia.com/Under_Construction/index.html")
        ' Check to see if the User is already logged in
        If Not Session("ContactID") Is Nothing Then

            ' Redirect to the Agent Area
            Response.Redirect("AgentActivitySelection.aspx")

        Else

            ' Load the Sign In Button Image
            ' ImageButtonSignIn.ImageUrl = GetSignInImagePath()

            ' Set Focus
            TextBoxUsername.Focus()

        End If

    End Sub

    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs)
           ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CContact As New ClassContact(TextBoxUsername.Text, TextBoxPassword.Text)

        ' Authenticate Login
        If CDataAccess.AuthenticateLogin(CContact) Then
            ' Set the Session Values
            Session("ContactID") = CContact.ID
            Session("ContactName") = CContact.Name
            Session("ContactType") = CContact.TypeID
            Session("ContactPartnerID") = CContact.PartnerID
            Session("ContactLanguageID") = CContact.LanguageID
            Session("AdminUser") = CContact.Administrator
            If CContact.MultipleContact = True Then
                Session("MultipleContact") = "Yes"
            Else
                Session("MultipleContact") = "False"
            End If
            ' If this is a Lawyer
            If CContact.TypeID = 2 Then
                ' Redirect to Activity Selection
                'Response.Redirect("Admin/BackOffice.aspx")
                Response.Redirect("AgentActivitySelection.aspx?ContactType=Lawyer")
            Else
                ' Redirect Direct to Back Office
                Response.Redirect("AgentActivitySelection.aspx")
            End If
        Else
            ' Set to NULL
            Session.Clear()
            ' Inform the user of the Error
            LabelMessage.Text = GetTranslation("The username and password entered have not been recognised")
        End If

        ' Tidy        
        CContact = Nothing
        CDataAccess = Nothing

    End Sub
    Public Function GetBackImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

        If Session("Language") Is Nothing Then

            ' Add English Path
            szRetVal &= "back.gif"

        Else

            ' Depending on the Language
            Dim CUtilities As New ClassUtilities

            Select Case CUtilities.GetLanguageID(Session("Language"))

                Case 2
                    ' Spanish
                    szRetVal &= "back-ES.gif"

                Case 3
                    ' French
                    szRetVal &= "back-FR.gif"

                Case 4
                    ' German
                    szRetVal &= "back-DE.gif"

                Case 5
                    ' Dutch
                    szRetVal &= "back-NL.gif"

                Case Else
                    ' English
                    szRetVal &= "back.gif"

            End Select

            ' Tidy
            CUtilities = Nothing

        End If

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Private Function GetSignInImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities
        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "sign-in-ES.gif"

            Case 3
                ' French
                szRetVal &= "sign-in-FR.gif"

            Case 4
                ' German
                szRetVal &= "sign-in-DE.gif"

            Case Else
                ' English
                szRetVal &= "sign-in.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function
End Class
