
Partial Class Controls_WebUserControlTop30
    Inherits System.Web.UI.UserControl

    Public Function GetImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "TOP50-button-ES.png"

            Case 3
                ' French
                szRetVal &= "TOP50-button-FR.png"

            Case 4
                ' German
                szRetVal &= "TOP50-button-DE.png"

            Case 5
                ' Dutch
                szRetVal &= "TOP50-button-NL.png"

            Case Else
                ' English
                szRetVal &= "TOP50-button.png"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

End Class
