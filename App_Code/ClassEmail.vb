Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net
Imports HashSoftwares
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class ClassEmail

    Public Function SendEmail(ByVal szTo As String, ByVal szSubject As String, ByVal szBody As String, ByVal bHTML As Boolean, Optional ByVal szAttachmentPath As String = vbNullString, Optional ByVal bCCInfo As Boolean = True) As Boolean

        ' Init Return Value
        Dim bRetVal As Boolean = True

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")

        Try

            ' Set the recepient address of the mail message
            mMailMessage.To.Add(New MailAddress(szTo.ToLower.Trim))

        Catch ex As System.FormatException

            ' Set Flag
            bRetVal = False

        End Try

        ' If still all Okay
        If bRetVal Then

            ' If we are CC'ing Info@
            If bCCInfo Then

                ' If this is not to InlandAndalucia.com
                If szTo.ToLower.Trim <> System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress") Then

                    ' CC Message to InlandAndalucia.com
                    mMailMessage.To.Add(New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress")))

                End If

            End If

            ' Set the subject of the mail message
            mMailMessage.Subject = szSubject.Trim

            ' Set the body of the mail message
            mMailMessage.Body = szBody

            ' Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = bHTML

            ' If we have an Attachment
            If Not szAttachmentPath Is Nothing Then

                ' If we have a String
                If szAttachmentPath.Trim <> String.Empty Then

                    ' Define the Attachment
                    Dim ma As New Mail.Attachment(szAttachmentPath.Trim)

                    ' Add the Attachment
                    mMailMessage.Attachments.Add(ma)

                End If

            End If

            ' Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal

            ' Instantiate a new instance of SmtpClient
            Dim mSmtpClient As New SmtpClient()

            ' Send the Mail Message
            mSmtpClient.Send(mMailMessage)

            ' Tidy
            mSmtpClient.Dispose()

        End If

        ' Tidy
        mMailMessage.Dispose()

        ' Return the Result
        Return bRetVal

    End Function
    Public Function SendEmailContactEnquiry(ByVal szTo As String, ByVal szSubject As String, ByVal szBody As String, ByVal bHTML As Boolean, Optional ByVal szAttachmentPath As String = vbNullString, Optional ByVal bCCInfo As Boolean = True) As Boolean

        ' Init Return Value
        Dim bRetVal As Boolean = True

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")

        Try

            ' Set the recepient address of the mail message
            mMailMessage.To.Add(New MailAddress(szTo.ToLower.Trim))
            ' Is there a Property Reference
            If Not HttpContext.Current.Request.QueryString("reference") Is Nothing Then
                mMailMessage.CC.Add(New MailAddress("enquiry@inlandandalucia.com"))
                'mMailMessage.CC.Add(New MailAddress("sourabhodesk@gmail.com"))
            End If

            'mMailMessage.CC.Add(New MailAddress("sourabhodesk@gmail.com"))
        Catch ex As System.FormatException

            ' Set Flag
            bRetVal = False

        End Try

        ' If still all Okay
        If bRetVal Then

            ' If we are CC'ing Info@
            If bCCInfo Then

                ' If this is not to InlandAndalucia.com
                If szTo.ToLower.Trim <> System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress") Then

                    ' CC Message to InlandAndalucia.com
                    mMailMessage.To.Add(New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress")))

                End If

            End If

            ' Set the subject of the mail message
            mMailMessage.Subject = szSubject.Trim

            ' Set the body of the mail message
            mMailMessage.Body = szBody

            ' Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = bHTML

            ' If we have an Attachment
            If Not szAttachmentPath Is Nothing Then

                ' If we have a String
                If szAttachmentPath.Trim <> String.Empty Then

                    ' Define the Attachment
                    Dim ma As New Mail.Attachment(szAttachmentPath.Trim)

                    ' Add the Attachment
                    mMailMessage.Attachments.Add(ma)

                End If

            End If

            ' Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal

            ' Instantiate a new instance of SmtpClient
            Dim mSmtpClient As New SmtpClient()

            ' Send the Mail Message
            mSmtpClient.Send(mMailMessage)

            ' Tidy
            mSmtpClient.Dispose()

        End If

        ' Tidy
        mMailMessage.Dispose()

        ' Return the Result
        Return bRetVal

    End Function
    Public Function SendEmailNewsletter(ByVal szTo As String, ByVal szSubject As String, ByVal szBody As String, ByVal bHTML As Boolean, Optional ByVal szAttachmentPath As String = vbNullString, Optional ByVal bCCInfo As Boolean = False) As Boolean

        ' Init Return Value
        Dim bRetVal As Boolean = True

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")

        Try

            ' Set the recepient address of the mail message
            mMailMessage.To.Add(New MailAddress(szTo.ToLower.Trim))

        Catch ex As System.FormatException

            ' Set Flag
            bRetVal = False

        End Try

        ' If still all Okay
        If bRetVal Then

            ' If we are CC'ing Info@
            If bCCInfo Then

                ' If this is not to InlandAndalucia.com
                If szTo.ToLower.Trim <> System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress") Then

                    ' CC Message to InlandAndalucia.com
                    mMailMessage.To.Add(New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress")))

                End If

            End If

            ' Set the subject of the mail message
            mMailMessage.Subject = szSubject.Trim

            ' Set the body of the mail message
            mMailMessage.Body = szBody

            ' Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = bHTML

            ' If we have an Attachment
            If Not szAttachmentPath Is Nothing Then

                ' If we have a String
                If szAttachmentPath.Trim <> String.Empty Then

                    ' Define the Attachment
                    Dim ma As New Mail.Attachment(szAttachmentPath.Trim)

                    ' Add the Attachment
                    mMailMessage.Attachments.Add(ma)

                End If

            End If

            ' Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal

            ' Instantiate a new instance of SmtpClient
            Dim mSmtpClient As New SmtpClient()

            ' Send the Mail Message
            mSmtpClient.Send(mMailMessage)

            ' Tidy
            mSmtpClient.Dispose()

        End If

        ' Tidy
        mMailMessage.Dispose()

        ' Return the Result
        Return bRetVal

    End Function
    Public Function SendEmailBuyer(ByVal szTo As String, ByVal szCCTo As String, ByVal szSubject As String, ByVal szBody As String, ByVal bHTML As Boolean, Optional ByVal szAttachmentPath As String = vbNullString, Optional ByVal bCCInfo As Boolean = True) As Boolean

        ' Init Return Value
        Dim bRetVal As Boolean = True

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")

        Try

            ' Set the recepient address of the mail message
            mMailMessage.To.Add(New MailAddress(szTo.ToLower.Trim))

        Catch ex As System.FormatException

            ' Set Flag
            bRetVal = False

        End Try

        ' If still all Okay
        If bRetVal Then


            If szCCTo <> "" Then
                mMailMessage.Bcc.Add(New MailAddress(szCCTo))
            End If

            ' Set the subject of the mail message
            mMailMessage.Subject = szSubject.Trim

            ' Set the body of the mail message
            mMailMessage.Body = szBody

            ' Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = bHTML

            ' If we have an Attachment
            If Not szAttachmentPath Is Nothing Then

                ' If we have a String
                If szAttachmentPath.Trim <> String.Empty Then

                    ' Define the Attachment
                    Dim ma As New Mail.Attachment(szAttachmentPath.Trim)

                    ' Add the Attachment
                    mMailMessage.Attachments.Add(ma)

                End If

            End If

            ' Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal

            ' Instantiate a new instance of SmtpClient
            Dim mSmtpClient As New SmtpClient()

            ' Send the Mail Message
            mSmtpClient.Send(mMailMessage)

            ' Tidy
            mSmtpClient.Dispose()

        End If

        ' Tidy
        mMailMessage.Dispose()

        ' Return the Result
        Return bRetVal

    End Function
    Public Sub SendEmailToLister(ByVal mTitle As String, ByVal mBody As String, ByVal mTo As String)
        Dim mMailMessage As New MailMessage()
        mMailMessage.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")
        mMailMessage.To.Add(New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress")))
        mMailMessage.To.Add(New MailAddress(mTo))
        mMailMessage.CC.Add(New MailAddress("jerome@inlandandalucia.com"))
        'mMailMessage.CC.Add(New MailAddress("stuart@inlandandalucia.com"))
        'mMailMessage.CC.Add(New MailAddress("sourabhodesk@gmail.com"))
        mMailMessage.Subject = mTitle
        mMailMessage.Body = mBody
        mMailMessage.IsBodyHtml = True
        ' Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal
        ' Instantiate a new instance of SmtpClient
        Dim mSmtpClient As New SmtpClient()
        ' Send the Mail Message
        mSmtpClient.Send(mMailMessage)
        ' Tidy
        mSmtpClient.Dispose()
        mMailMessage.Dispose()
    End Sub
    Public Sub SendFeedLogs_Email_Notification(ByVal mTitle As String, ByVal mBody As String)

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")

        ' CC Message to InlandAndalucia.com
        mMailMessage.To.Add(New MailAddress("sourabhodesk@gmail.com"))
        mMailMessage.CC.Add(New MailAddress("jerome@inlandandalucia.com"))
        'mMailMessage.CC.Add(New MailAddress("stuart@inlandandalucia.com"))

        mMailMessage.Subject = mTitle
        mMailMessage.Body = mBody
        mMailMessage.IsBodyHtml = True
        ' Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal
        ' Instantiate a new instance of SmtpClient
        Dim mSmtpClient As New SmtpClient()
        ' Send the Mail Message
        mSmtpClient.Send(mMailMessage)
        ' Tidy
        mSmtpClient.Dispose()
        mMailMessage.Dispose()
    End Sub
    Dim isListerEmailAlreadyExists As Int32 = 0
    Public Sub CheckListerEmailAlreadyExists(ByVal ListerEmail As String, ByVal PartnerUserEmail As String)
        If ListerEmail = PartnerUserEmail Then
            isListerEmailAlreadyExists = 1
        End If
    End Sub
    Public Sub SendEmail_Notification_Single_Fuction(ByVal mTitle As String, ByVal mBody As String, ByVal Partner_Id As Int32, ByVal ListerEmail As String, ByVal ActionType As String, ByVal EnvoirementType As String, ByVal IsLister As Int32)

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")

        ' CC Message to InlandAndalucia.com
        If EnvoirementType = "Live" Then
            mMailMessage.To.Add(New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress")))
            mMailMessage.CC.Add(New MailAddress("jerome@inlandandalucia.com"))
            'mMailMessage.CC.Add(New MailAddress("stuart@inlandandalucia.com"))
            'mMailMessage.CC.Add(New MailAddress("sourabhodesk@gmail.com"))
            'Condition set for Chelo & Geoffrey
            If ActionType = "PriceChanged" Or ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold" Or ActionType = "Sold by Comp" Then
                mMailMessage.CC.Add(New MailAddress("chelo@inlandandalucia.com"))
                mMailMessage.CC.Add(New MailAddress("geoffrey@inlandandalucia.com"))
                If ListerEmail <> "" Then
                    CheckListerEmailAlreadyExists(ListerEmail, "geoffrey@inlandandalucia.com")
                    CheckListerEmailAlreadyExists(ListerEmail, "chelo@inlandandalucia.com")
                End If
            End If
            'mTitle = "TEST EMAIL PLEASE IGNORE - " & mTitle
        End If

        ' Set the recepient address of the mail message
        If EnvoirementType = "Dev" Or EnvoirementType = "Training" Then
            mMailMessage.To.Add(New MailAddress("sourabhodesk@gmail.com"))
            mMailMessage.CC.Add(New MailAddress("jerome@inlandandalucia.com"))
            'mMailMessage.CC.Add(New MailAddress("stuart@inlandandalucia.com"))
            mMailMessage.CC.Add(New MailAddress("lee@inlandandalucia.com"))
            mTitle = "Test - " & mTitle
        End If
        If EnvoirementType = "Live" And ListerEmail <> "" Then
            CheckListerEmailAlreadyExists(ListerEmail, "jerome@inlandandalucia.com")
            'CheckListerEmailAlreadyExists(ListerEmail, "stuart@inlandandalucia.com")
        End If

        If EnvoirementType = "Live" Then
            Select Case Partner_Id
                Case 3864
                    mMailMessage.CC.Add(New MailAddress("Antonia@inlandandalucia.com"))
                    mMailMessage.CC.Add(New MailAddress("alejandrocanterolawyer@gmail.com"))
                    'Condition set for Raquel
                    If ActionType = "PriceChanged" Or ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold" Or ActionType = "Sold by Comp" Then
                        mMailMessage.CC.Add(New MailAddress("raquel@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "raquel@inlandandalucia.com")
                        End If
                    End If
                    'Condition set for Hayley
                    If ActionType = "PriceChanged" Or ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold by Comp" Then
                        mMailMessage.CC.Add(New MailAddress("Hayley@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "Hayley@inlandandalucia.com")
                        End If
                    End If
                    If ListerEmail <> "" Then
                        CheckListerEmailAlreadyExists(ListerEmail, "Antonia@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "alejandrocanterolawyer@gmail.com")
                    End If
                Case 3873

                    If ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "New Property" Then
                        mMailMessage.CC.Add(New MailAddress("helena@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "helena@inlandandalucia.com")
                        End If
                    End If

                    'Condition set for paul barnett
                    If ActionType = "For Sale" Then
                        mMailMessage.CC.Add(New MailAddress("paul.barnett@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "paul.barnett@inlandandalucia.com")
                        End If
                    End If

                    mMailMessage.CC.Add(New MailAddress("pam@inlandandalucia.com"))
                    mMailMessage.CC.Add(New MailAddress("david@inlandandalucia.com"))
                    mMailMessage.CC.Add(New MailAddress("juan@inlandandalucia.com"))
                    If ListerEmail <> "" Then
                        CheckListerEmailAlreadyExists(ListerEmail, "pam@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "david@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "juan@inlandandalucia.com")
                    End If

                Case 10274
                    'mMailMessage.CC.Add(New MailAddress("philippe@inlandandalucia.com"))
                    mMailMessage.CC.Add(New MailAddress("joaquin@inlandandalucia.com"))
                    If ListerEmail <> "" Then
                        'CheckListerEmailAlreadyExists(ListerEmail, "philippe@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "joaquin@inlandandalucia.com")
                    End If
                Case 9103
                    'Condition set for Rachel
                    If ActionType = "NotifyBlue" Or ActionType = "NotifyOrange" Or ActionType = "NotifyBlueToPartnesOnly" Or ActionType = "NotifyOrangeToPartnesOnly" Or ActionType = "For Sale" Or ActionType = "Under Offer" Then
                        mMailMessage.CC.Add(New MailAddress("rachel@inlandandalucia.com"))
                    End If
                    If ListerEmail <> "rachel@inlandandalucia.com" Then
                        mMailMessage.CC.Add(New MailAddress("rachel@inlandandalucia.com"))
                    End If
                    If ListerEmail <> "" Then
                        CheckListerEmailAlreadyExists(ListerEmail, "rachel@inlandandalucia.com")
                    End If
                Case 9495
                    If ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "New Property" Then
                        mMailMessage.CC.Add(New MailAddress("helena@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "helena@inlandandalucia.com")
                        End If
                    End If
                    mMailMessage.CC.Add(New MailAddress("juan@inlandandalucia.com"))
                    mMailMessage.CC.Add(New MailAddress("jolyne@inlandandalucia.com"))
                    'Condition set for paul barnett
                    If ActionType = "For Sale" Then
                        mMailMessage.CC.Add(New MailAddress("paul.barnett@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "paul.barnett@inlandandalucia.com")
                        End If
                    End If
                    mMailMessage.CC.Add(New MailAddress("david@inlandandalucia.com"))
                    'mMailMessage.CC.Add(New MailAddress("philippe@inlandandalucia.com"))
                    'Condition set for natalja
                    If ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold" Or ActionType = "Sold by Comp" Or ActionType = "New Property" Or ActionType = "Pending Doc" Or ActionType = "Review before DELETE" Then
                        mMailMessage.CC.Add(New MailAddress("natalja@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "natalja@inlandandalucia.com")
                        End If
                    End If
                    If ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold" Or ActionType = "Sold by Comp" Then
                        mMailMessage.CC.Add(New MailAddress("hans@inlandadalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "hans@inlandadalucia.com")
                        End If
                    End If
                    If ListerEmail <> "" Then
                        CheckListerEmailAlreadyExists(ListerEmail, "david@inlandandalucia.com")
                        'CheckListerEmailAlreadyExists(ListerEmail, "philippe@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "juan@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "jolyne@inlandandalucia.com")
                    End If
                Case 10109
                    If ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "New Property" Then
                        mMailMessage.CC.Add(New MailAddress("helena@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "helena@inlandandalucia.com")
                        End If
                    End If

                    mMailMessage.CC.Add(New MailAddress("joaquin@inlandandalucia.com"))
                    'Condition set for paul barnett
                    If ActionType = "For Sale" Then
                        mMailMessage.CC.Add(New MailAddress("paul.barnett@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "paul.barnett@inlandandalucia.com")
                        End If
                    End If
                    mMailMessage.CC.Add(New MailAddress("pam@inlandandalucia.com"))
                    mMailMessage.CC.Add(New MailAddress("david@inlandandalucia.com"))
                    'Condition set for natalja
                    If ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold" Or ActionType = "Sold by Comp" Or ActionType = "New Property" Or ActionType = "Pending Doc" Or ActionType = "Review before DELETE" Then
                        mMailMessage.CC.Add(New MailAddress("natalja@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "natalja@inlandandalucia.com")
                        End If
                    End If
                    If ListerEmail <> "" Then
                        CheckListerEmailAlreadyExists(ListerEmail, "pam@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "david@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "joaquin@inlandandalucia.com")
                    End If
                Case 7666
                    If ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "New Property" Then
                        mMailMessage.CC.Add(New MailAddress("helena@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "helena@inlandandalucia.com")
                        End If
                    End If

                    'mMailMessage.CC.Add(New MailAddress("philippe@inlandandalucia.com"))
                    mMailMessage.CC.Add(New MailAddress("pam@inlandandalucia.com"))
                    'Condition set for natalja
                    If ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold" Or ActionType = "Sold by Comp" Or ActionType = "New Property" Or ActionType = "Pending Doc" Or ActionType = "Review before DELETE" Then
                        mMailMessage.CC.Add(New MailAddress("natalja@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "natalja@inlandandalucia.com")
                        End If
                    End If
                    mMailMessage.CC.Add(New MailAddress("david@inlandandalucia.com"))
                    If ListerEmail <> "" Then
                        'CheckListerEmailAlreadyExists(ListerEmail, "philippe@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "david@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "pam@inlandandalucia.com")
                    End If
                Case 10391
                    mMailMessage.CC.Add(New MailAddress("Alejandro@inlandandalucia.com"))
                    mMailMessage.CC.Add(New MailAddress("Antonia@inlandandalucia.com"))
                    If ActionType = "PriceChanged" Or ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold" Or ActionType = "Sold by Comp" Then
                        mMailMessage.CC.Add(New MailAddress("raquel@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "raquel@inlandandalucia.com")
                        End If
                    End If
                    'Condition set for Hayley
                    If ActionType = "PriceChanged" Or ActionType = "For Sale" Or ActionType = "Under Offer" Or ActionType = "Withdrawn" Or ActionType = "Sold by Comp" Then
                        mMailMessage.CC.Add(New MailAddress("Hayley@inlandandalucia.com"))
                        If ListerEmail <> "" Then
                            CheckListerEmailAlreadyExists(ListerEmail, "Hayley@inlandandalucia.com")
                        End If
                    End If
                    If ListerEmail <> "" Then
                        CheckListerEmailAlreadyExists(ListerEmail, "Antonia@inlandandalucia.com")
                        CheckListerEmailAlreadyExists(ListerEmail, "alejandrocanterolawyer@gmail.com")
                    End If
            End Select
            'Dim ListerEmailContactArchived As Int32
            'Dim dt As DataTable
            'Dim sql As SqlParameter() = New SqlParameter(1) {}
            'sql(0) = New SqlParameter("@contact_email", ListerEmail)
            'dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Check_ListerEmail_IsArchived", sql).Tables(0)
            'If dt.Rows.Count > 0 Then
            '    ListerEmailContactArchived = Convert.ToInt32(dt.Rows(0)("Contact_Archived").ToString())
            'Else
            '    ListerEmailContactArchived = 0
            'End If
            If ListerEmail <> "" And isListerEmailAlreadyExists = 0 And ListerEmail <> "graham@inlandandalucia.com" And ListerEmail <> "george@inlandandalucia.com" And ListerEmail <> "julian@inlandandalucia.com" And ListerEmail <> "ana@inlandandalucia.com" And ListerEmail <> "richard@inlandandalucia.com" Then
                mMailMessage.CC.Add(New MailAddress(ListerEmail))
            End If
            If ActionType = "Under Offer" Then
                mMailMessage.CC.Add(New MailAddress("rochelle@inlandandalucia.com"))
            End If
        End If

        mMailMessage.Subject = mTitle
        mMailMessage.Body = mBody
        mMailMessage.IsBodyHtml = True
        ' Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal
        ' Instantiate a new instance of SmtpClient
        Dim mSmtpClient As New SmtpClient()
        ' Send the Mail Message
        mSmtpClient.Send(mMailMessage)
        ' Tidy
        mSmtpClient.Dispose()
        mMailMessage.Dispose()
    End Sub

    Public Function EmailIsArchived(ByVal contact_email As String) As Int32
        'Check if email is archived or not
        Dim szSQL As String = "select * from contact where Contact_Type_ID=4 and Contact_Archived=0 and contact_email=" & contact_email
        Dim dtResult As DataTable = GetDataAsDataTable(szSQL)
        If dtResult.Rows.Count > 0 Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Public Function GetDataAsDataTable(ByVal szSQL As String) As DataTable

        ' Local Vars
        Dim dtDataTable As New DataTable

        ' Open Database
        Using sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("IA").ToString)

            Try

                Dim sqlDataAdapter As New SqlDataAdapter(szSQL, sqlConnection)

                sqlDataAdapter.Fill(dtDataTable)

                sqlDataAdapter.Dispose()

            Catch ex As Exception
                ' TODO
            End Try

            sqlConnection.Close()

        End Using

        Return dtDataTable

    End Function


End Class

