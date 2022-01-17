Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares
Imports System.IO
Imports Stripe

Partial Class StripePayment
    Inherits System.Web.UI.Page
    Dim hashClass As New zHashClass
    Public Const Stripe = "Stripe"
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            If (Not IsPostBack) Then
                buyerForname.InnerText = Request.QueryString("Forename").ToString()
                buyerSurname.InnerText = Request.QueryString("Surname").ToString()
                buyerAddress.InnerText = Request.QueryString("Address").ToString()
                buyerTelePhone.InnerText = Request.QueryString("Telephone").ToString()
                buyerEmail.InnerText = Request.QueryString("Email").ToString()
                buyerRefrence.InnerText = Request.QueryString("propertytitle").ToString()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs)

        'First check if same customer already been paid for same property reservation, don't want them to pay duplicate ammount
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@Property_Ref", Request.QueryString("propertyref").ToString())
        sql(1) = New SqlParameter("@Buyer_Email", Request.QueryString("Email").ToString())
        Dim dtTransactionDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Check_Buyer_AlreadyReserved", sql).Tables(0)
        If dtTransactionDetails.Rows.Count > 0 Then
            Page.RegisterStartupScript("script", "<script language='javascript'>alert('You have already been reserved this property, please check your email. Thanks !');</script>")
        Else
            If txtAmount.Text <> "" Then
                'StripeConfiguration.ApiKey = "sk_test_r04LuCbZ4hze5EcdCzqvxyUC"
                StripeConfiguration.ApiKey = "sk_live_IIsyEX1afAdNR3c5e5gEsOPl"
                Dim service = New PaymentIntentService()
                Dim options = New PaymentIntentCreateOptions With {
                            .Amount = Convert.ToInt32(txtAmount.Text) * 100,
                            .Currency = "eur",
                            .Description = buyerRefrence.InnerText
                        }
                Dim v = service.Create(options)
                hfClientSecret.Value = v.ClientSecret.ToString()
                hfPaymentIntentId.Value = v.Id.ToString()
                divCardDetails.Visible = True
                dvAmount.Visible = False
                hdnPaidAmount.Value = txtAmount.Text
            End If
        End If
        lblSecurityCode.Visible = True
        lblPostCode.Visible = True
    End Sub

    'Creating Email function to admin & to customer after successful payment
    Public Sub SendEmails(ByVal paidAmount As Integer)
        Try
            Dim CBuyer As New ClassBuyer(0)
            CBuyer.Load(Convert.ToInt32(hdnBuyerId.Value))
            Dim CContact As New ClassContact(0)
            CContact.Load(CBuyer.Buyer_Salesperson_ID)
            Dim SalesPersonEmail As String = CContact.Email

            ' Send the Email to Customer (just doing testing)
            Dim SubjectToCustomer As String
            Dim ContentToCustomer As String

            'Check if buyer already have tour for this property Yes Or Not then send email body content and title accordingly
            Dim strBuyerTourCheck As String = "select count(*) 'TotalTours' from client_tour_properties where tour_id in(select tour_id from client_tour where tour_buyer_id=" & Convert.ToInt32(hdnBuyerId.Value) & ")"
            Dim dtBuyerTours As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, strBuyerTourCheck).Tables(0)
            Dim TotalTours As Int32
            If dtBuyerTours.Rows.Count > 0 Then
                TotalTours = Convert.ToInt32(dtBuyerTours.Rows(0)("TotalTours").ToString())
            End If
            If TotalTours = 0 Then
                SubjectToCustomer = "" + Request.QueryString("propertyref").ToString() + " been successfully reserved for next 2 weeks"
                ContentToCustomer = "Dear " & Request.QueryString("ForeName").ToString() & ",<br/> " & Request.QueryString("propertyref").ToString() & " has been successfully reserved for the next 2 weeks with " & paidAmount & " €<br/> Our representative will contact you shortly to arrange the final details of your viewing trip.<br/><br/>  Kind Regards Inland Andalucia Ltd"
            Else
                SubjectToCustomer = "Property Ref " + Request.QueryString("propertyref").ToString() + " is now reserved for you."
                ContentToCustomer = "Dear " & Request.QueryString("ForeName").ToString() & ",<br/> Congratulations on your reservation. Our admin department will be in contact with your Property specialist to prepare your receipt and the property is now reserved to your order. Thank you for choosing Inland Andalucia for your property purchase.<br/><br/>  Kind Regards Inland Andalucia Ltd"
            End If
            Dim CEmail As New ClassEmail
            CEmail.SendEmail(Request.QueryString("Email").ToString(), SubjectToCustomer, ContentToCustomer, True, Nothing, False)
            CEmail = Nothing
            ' Send the Email to Admin (just doing testing)
            Dim SubjectToAdmin As String
            Dim ContentToAdmin As String
            SubjectToAdmin = Request.QueryString("propertyref").ToString() + " been successfully reserved for next 2 weeks"
            ContentToAdmin = "Dear Admin,<br/> " & Request.QueryString("propertyref").ToString() & " has been successfully reserved for the next 2 weeks.<br/> Please ask representative to contact customer shortly to arrange the final details of viewing trip.<br/><br/> Here are customer details : <br/><br/> Customer Name : " & Request.QueryString("ForeName").ToString() & "<br/> Customer Email : " & Request.QueryString("Email").ToString() & "<br/> Reserved Amount : € " & paidAmount & "<br/><br/> Kind Regards Inland Andalucia Ltd"
            Dim CEmailAdmin As New ClassEmail
            CEmailAdmin.SendEmail("info@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("rochelle@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("graham@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("sourabhodesk@gmail.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            If Not String.IsNullOrEmpty(SalesPersonEmail) Then
                Dim ContentToSalesPerson As String
                ContentToSalesPerson = "Hi,<br/> " & Request.QueryString("propertyref").ToString() & " has been successfully reserved for the next 2 weeks.<br/> Please ask representative to contact customer shortly to arrange the final details of viewing trip.<br/><br/> Here are customer details : <br/><br/> Customer Name : " & Request.QueryString("ForeName").ToString() & "<br/> Customer Email : " & Request.QueryString("Email").ToString() & "<br/> Reserved Amount : € " & paidAmount & "<br/><br/> Kind Regards Inland Andalucia Ltd"
                CEmailAdmin.SendEmail(SalesPersonEmail, SubjectToAdmin, ContentToSalesPerson, True, Nothing, False)
                If CBuyer.PartnerID = 3864 Or CBuyer.PartnerID = 10391 Then
                    CEmailAdmin.SendEmail("alejandrocanterolawyer@gmail.com", SubjectToAdmin, ContentToSalesPerson, True, Nothing, False)
                End If
                'CEmailAdmin.SendEmail("sourabhodesk@gmail.com", SubjectToAdmin, ContentToSalesPerson, True, Nothing, False)
            End If

            CEmailAdmin.SendEmail("sourabhodesk@gmail.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("jerome@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin = Nothing
        Catch ex As Exception
            'lblError.Text = ex.InnerException.ToString()
        End Try
    End Sub

    Public Sub LogPayment(ByVal transactionId As String, ByVal amount As Decimal)
        Try
            Dim sql As SqlParameter() = New SqlParameter(11) {}
            sql(0) = New SqlParameter("@Buyer_Forename", Request.QueryString("Forename").ToString().Trim)
            sql(1) = New SqlParameter("@Buyer_Surname", Request.QueryString("Surname").ToString().Trim)
            sql(2) = New SqlParameter("@Buyer_Passport", "")
            sql(3) = New SqlParameter("@Buyer_Address", Request.QueryString("Address").ToString().Trim)
            sql(4) = New SqlParameter("@Buyer_Contact_Name", "")
            sql(5) = New SqlParameter("@Buyer_Telephone", Request.QueryString("Telephone").ToString().Trim)
            sql(6) = New SqlParameter("@Buyer_Email", Request.QueryString("Email").ToString().Trim)
            sql(7) = New SqlParameter("@Buyer_Notes", Request.QueryString("Notes").ToString().Trim)
            sql(8) = New SqlParameter("@Property_Ref", Request.QueryString("propertyref").ToString())
            sql(9) = New SqlParameter("@Buyer_Status_Id", 15)
            sql(10) = New SqlParameter("@History_Text", GetEmail_HistoryText())
            Dim buyerID As Integer = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Insert", sql).Tables(0).Rows(0)("Buyer_ID")
            hdnBuyerId.Value = buyerID.ToString()
            'Getting values back from paypal
            'Insert The Records to the Transaction Table
            hashClass.InsertInTransactionTable(buyerID, transactionId, amount, "EUR", Request.QueryString("propertyref").ToString(), Stripe)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Sub

    Public Function GetEmail_HistoryText() As String
        Dim strEmailContent As String = ""
        strEmailContent = Request.QueryString("propertyref").ToString().Trim + " has been reserved , "
        strEmailContent = strEmailContent & "An Email has been sent To Customer " & Request.QueryString("ForeName").ToString().Trim & " " & Request.QueryString("Surname").ToString() & " : "
        strEmailContent = strEmailContent & "Congratulations on your reservation. Our admin department will be in contact with your Property specialist to prepare your receipt and the property is now reserved to your order. Thank you for choosing Inland Andalucia for your property purchase."
        Return strEmailContent
    End Function

    Protected Sub btnLogPayment_Click(sender As Object, e As EventArgs)
        Dim TransactionId = hfPaymentIntentId.Value
        Dim Amount = hdnPaidAmount.Value
        LogPayment(TransactionId, Convert.ToInt32(Amount))
        SendEmails(Convert.ToInt32(Amount))

        'Status been changed so send email accordingly & save in property history table
        Dim Property_Ref As String = Request.QueryString("propertyref").ToString()
        'Dim mailTitleStatusChange As String = "Property Reference " & Property_Ref & " Property Status is now Under Offer "
        'Dim mailBodyStatusChange As String = "Property Status been changed for Property Reference " & Property_Ref & "  From Sale To Under Offer"
        'Dim mailBodyStatusChangeForHistory As String = "Property Status been changed for Property Reference " & Property_Ref & "  From Sale To Under offer"
        'mailBodyStatusChange = mailBodyStatusChange & "<br/><br/>"
        'mailBodyStatusChange = mailBodyStatusChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
        'Dim dtListerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "select contact_email from contact where contact_id in(select Listed_By_Contact_Id from property where Property_Ref='" & Property_Ref & "')").Tables(0)
        'Dim listerEmail As String = ""
        'If dtListerDetails.Rows.Count > 0 Then
        '    listerEmail = dtListerDetails.Rows(0)("contact_email").ToString()
        'End If

        'Try
        '    ' Define a New Email
        '    Dim CEmailStatusChange As New ClassEmail
        '    Dim CProperty As New ClassProperty(0)
        '    CProperty.Load(Property_Ref)
        '    Dim isDevORTraining As Int16 = 0
        '    If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
        '        mailBodyStatusChange = mailBodyStatusChange & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
        '        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, "Under Offer", "Dev", 1)
        '        isDevORTraining = 1
        '    End If
        '    If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
        '        mailBodyStatusChange = mailBodyStatusChange & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
        '        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, "Under Offer", "Training", 1)
        '        isDevORTraining = 1
        '    End If
        '    If isDevORTraining = 0 Then
        '        mailBodyStatusChange = mailBodyStatusChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
        '        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, "Under Offer", "Live", 1)
        '    End If

        'Catch ex As Exception

        'End Try

        'Insert in property history table accordingly 

        Dim sqlPHStatusChange As SqlParameter() = New SqlParameter(9) {}
        sqlPHStatusChange(0) = New SqlParameter("@Property_Ref", Property_Ref.ToString())
        sqlPHStatusChange(1) = New SqlParameter("@Type_Id", 27)
        Dim stripeHistoryText As String = "Stripe Payment - " & Amount.ToString() & " Paid"
        sqlPHStatusChange(2) = New SqlParameter("@History_Text", stripeHistoryText)

        'Check if this buyer already have salesperson'

        Dim CBuyer As New ClassBuyer(0)
        CBuyer.Load(Convert.ToInt32(hdnBuyerId.Value))
        sqlPHStatusChange(3) = New SqlParameter("@Modified_By", CBuyer.Buyer_Salesperson_ID)

        ''''''''''''''''''''''''''''''''''''''''''''''

        sqlPHStatusChange(4) = New SqlParameter("@PriceChanged", DBNull.Value)
        sqlPHStatusChange(5) = New SqlParameter("@NewPrice", DBNull.Value)
        sqlPHStatusChange(6) = New SqlParameter("@OldPrice", DBNull.Value)
        sqlPHStatusChange(7) = New SqlParameter("@Buyer_Id", Convert.ToInt32(hdnBuyerId.Value))
        sqlPHStatusChange(8) = New SqlParameter("@Expiry_Date", DBNull.Value)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert_After_StripePayment", sqlPHStatusChange)

        divPayment.Attributes.Add("class", "hidden")
        divMsg.Attributes.Add("class", "visible")
        msgAmount.InnerHtml = "Amount " & Amount & " Euro has been received."
        pmsg.InnerHtml = Request.QueryString("propertyref") & " has been successfully reserved for next 2 weeks."
    End Sub

End Class
