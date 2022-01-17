
Partial Class WebUserControlThankYou
    Inherits System.Web.UI.UserControl

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Session("Unsubscribe") Is Nothing Then

            ' If they have Unsubscribed
            If Convert.ToBoolean(Session("Unsubscribe")) Then

                ' Unsubscribed
                SubscriptionText.InnerHtml = GetTranslation("Your request to unsubscribe from our newsletter has been received")

            Else

                ' Subscribed
                SubscriptionText.InnerHtml = GetTranslation("Thank you for subscribing to our newsletter")

            End If

        End If

    End Sub

End Class
