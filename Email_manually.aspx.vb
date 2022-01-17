


Imports Stripe

Partial Class Email_manually
    Inherits System.Web.UI.Page
    Dim hashClass As New zHashClass
    Public Const Stripe = "Stripe"

    'Creating Email function to admin & to customer after successful payment
    Public Sub SendEmails(ByVal paidAmount As Integer)

        Try
            'Send the Email to Customer (just doing testing)
            Dim SubjectToCustomer As String
            Dim ContentToCustomer As String
            SubjectToCustomer = "TH3271 been successfully reserved for next 2 weeks"
            ContentToCustomer = "Dear Daniele,<br/> TH3271 has been successfully reserved for the next 2 weeks with 1000.00 €<br/> Our representative will contact you shortly to arrange the final details of your viewing trip.<br/><br/>  Kind Regards Inland Andalucia Ltd"
            Dim CEmail As New ClassEmail
            CEmail.SendEmail("danielenastasi@outlook.com", SubjectToCustomer, ContentToCustomer, True)
            CEmail = Nothing

            ' Send the Email to Admin (just doing testing)
            Dim SubjectToAdmin As String
            Dim ContentToAdmin As String
            SubjectToAdmin = "TH3271 been successfully reserved for next 2 weeks"
            ContentToAdmin = "Dear Admin,<br/> TH3271 has been successfully reserved for the next 2 weeks.<br/> Please ask representative to contact customer shortly to arrange the final details of viewing trip.<br/><br/> Here are customer details : <br/><br/> Customer Name :  Daniele <br/> Customer Email : danielenastasi@outlook.com<br/> Reserved Amount : € 1000<br/><br/> Kind Regards Inland Andalucia Ltd"
            Dim CEmailAdmin As New ClassEmail
            CEmailAdmin.SendEmail("info@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True)
            CEmailAdmin.SendEmail("sourabhodesk@gmail.com", SubjectToAdmin, ContentToAdmin, True)
            CEmailAdmin = Nothing
        Catch ex As Exception
            'lblError.Text = ex.InnerException.ToString()
        End Try
    End Sub

    Private Sub Email_manually_Load(sender As Object, e As EventArgs) Handles Me.Load
        SendEmails(1000)
    End Sub
End Class
