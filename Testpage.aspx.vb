
Partial Class Testpage
    Inherits System.Web.UI.Page
    Dim objXMLHTTP, xml As New Object
    'Create & initialize the XMLHTTP object

             Set xml = CreateObject("MSXML2.ServerXMLHTTP")
             xml.Open "POST", "https://secure.ppsgateway.com/api/transact.php", False
             xml.setRequestHeader "Content-Type", "application/x-www-form-urlencoded"

             strLogin = "stsadvanced"
             strPassword = "lozinka2o0o"
              strMerchantID = 3
              strProcessorID = "stsadvanced"
    ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    ' THIS IS THE NEW PAYMENT GATEWAY CODE
    ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
             strCCNumber = rsItems.fields("creditCardNumber")
             strCCNumber = trim(rsItems.fields("creditCardNumber"))    
             xml.Send "username=" & strLogin _
                  & "&password=" & strPassword _
                  & "&ccnumber=" & strCCNumber _
                  & "&ccexp=" & rsItems.fields("creditCardValidThruM") & rsItems.fields("creditCardValidThruY") _
                  & "&amount=" & BillTotal _
                  & "&firstname=" &  rsItems.fields("nameOnTheCard")  _
                  & "&address1=" &  rsItems.fields("BillingAddress") _
                  & "&zip=" & rsItems.fields("BillingZip") _
                  & "&processor_id=" & strProcessorID _
                  & "&type=" & "sale"
             ResponseString = xml.responseText
             Results = Split(ResponseString, "&")

             GatewaySale = False
             For Each i In Results
                 Result = Split(i, "=")
                 If UBound(Result) > 0 Then
                     If LCase(Result(0)) = "response" Then
                         If Result(1) = "1" Then
                             GatewaySale = True
                         End If
                     End If
                 End If
             Next
    ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    ' it the payment was successful, we update the database and send the customer an email
    ' notifying them of the payment. If this was a first payment for new members, we send
    ' a welcome email.
             If (GatewaySale = True) Then
    ' SAVE THE DATA TO THE DB TO CREATE THE ACCOUNT
             else            
    ' DISPLAY THE DECLINE MESSAGE FROM THE PROCESSOR ON THE FORM BUT MAKE SURE ALL ITEMS ARE STILL POPULATED SO THAT WE DONT NEED    TO RE-ENTER EVERYTHING AGAIN TO RE-ATTEMPT.
             end if
End Class
