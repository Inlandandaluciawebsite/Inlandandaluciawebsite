
Partial Class PayPalPayment
    Inherits System.Web.UI.Page
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        divMsg.Attributes.Add("class", "hidden")
        If Request.QueryString("st") = "Completed" Then
            divPayment.Attributes.Add("class", "hidden")
            divMsg.Attributes.Add("class", "display")
            SendEmails()
        End If
        buyerName.InnerText = Session("BuyerDetail")(0)
        buyerPassport.InnerText = Session("BuyerDetail")(1)
        buyerAddress.InnerText = Session("BuyerDetail")(2)
        buyerTelePhone.InnerText = Session("BuyerDetail")(3)
        buyerEmail.InnerText = Session("BuyerDetail")(4)
    End Sub

    'Creating Email function to admin & to customer after successful payment
    Public Sub SendEmails()

        Try
            ' Send the Email to Customer (just doing testing)
            Dim SubjectToCustomer As String
            Dim ContentToCustomer As String
            SubjectToCustomer = "" + Session("PropReference").ToString() + " been successfully reserved for next 2 weeks"
            ContentToCustomer = "Dear " & Session("BuyerDetail")(0).ToString() & ",<br/> " & Session("PropReference").ToString() & " has been successfully reserved for the next 2 weeks.<br/> Our representative will contact you shortly to arrange the final details of your viewing trip.<br/><br/>  Kind Regards Inland Andalucia Ltd"
            Dim CEmail As New ClassEmail
            CEmail.SendEmail(Session("BuyerDetail")(4).ToString(), SubjectToCustomer, ContentToCustomer, True, Nothing, False)
            CEmail = Nothing

            ' Send the Email to Admin (just doing testing)
            Dim SubjectToAdmin As String
            Dim ContentToAdmin As String
            SubjectToAdmin = "" + Session("PropReference") + " been successfully reserved for next 2 weeks"
            ContentToAdmin = "Dear Admin,<br/> " & Session("PropReference") & " has been successfully reserved for the next 2 weeks.<br/> Please ask representative to contact customer shortly to arrange the final details of viewing trip.<br/><br/> Here are customer details : <br/><br/> Customer Name : " & Session("BuyerDetail")(0).ToString() & "<br/> Customer Email : " & Session("BuyerDetail")(4).ToString() & "<br/> Reserved Amount : " & Request.QueryString("amt") & "<br/><br/>  Kind Regards Inland Andalucia Ltd"
            Dim CEmailAdmin As New ClassEmail
            CEmailAdmin.SendEmail("info@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("rochelle@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("sourabhodesk@gmail.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin = Nothing
        Catch ex As Exception
            'lblError.Text = ex.InnerException.ToString()
        End Try
    End Sub

    Private Sub PayPalPayment_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Session.RemoveAll()
    End Sub
End Class
