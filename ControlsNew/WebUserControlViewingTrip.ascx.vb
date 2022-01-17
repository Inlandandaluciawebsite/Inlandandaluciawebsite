
Partial Class Controls_WebUserControlViewingTrip
    Inherits System.Web.UI.UserControl

       Public Function GetImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/specials/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "viewing-trip-ES.jpg"

            Case 3
                ' French
                szRetVal &= "viewing-trip-FR.jpg"

            Case 4
                ' German
                szRetVal &= "viewing-trip-DE.jpg"

            Case 5
                ' Dutch
                szRetVal &= "viewing-trip-NL.jpg"

            Case Else
                ' English
                szRetVal &= "viewing-trip.jpg"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

End Class
