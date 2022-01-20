Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports System.Net.Mail
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.IO.Compression
Imports Ionic.Zip
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Bitmap

Partial Class _Default
    Inherits BasePage
    ' Inherits System.Web.UI.Page
    Public language As Integer
    Function result(ByVal value As Long) As Long
        If value <= 1 Then
            Return (1)
        Else
            Return value * result(value - 1)
        End If
    End Function 'Factorial
    Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Response.Redirect("https://dev.inlandandalucia.com/Under_Construction/index.html")
        If Not Session("language") = "" Then
            Dim language1 As String = Session("language")
            Select Case language1

                Case "Spanish"
                    language = 2

                Case "French"
                    language = 3

                Case "German"
                    language = 5

                Case "Dutch"
                    language = 4

                Case Else
                    language = 1

            End Select
        Else
            language = 1
        End If
        Page.Title = "Inland Andalucia - The inland Andalucia Property Specialist"
        Page.MetaDescription = "Welcome to Inland Andalucia Ltd. We are the real property specialist for inland Andalucia. Our service area is truly comprehensive and covers a large section of inland Andalucia. "
        Page.MetaKeywords = "Inland Andalucia, property in cordoba, property in jaen, property in Granada, property in Malaga, properties for sale in Seville Spain"
        If Not Session("language") = "" Then
            If ViewState("SampleText") Is Nothing Then
                ViewState("SampleText") = Session("language")
                bindFeaturedProperty()
            End If
            If Not ViewState("SampleText") = Session("language") Then
                bindFeaturedProperty()
                ViewState("SampleText") = Session("language")
            End If
        End If
        If Not Page.IsPostBack Then
            bindFeaturedProperty()
            Dim isDevORTraining As Int16 = 0
            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                isDevORTraining = 1
                NotifyFeaturedProperty()
                NotifyOrangeBlue()
                NotifyOrangeBlue_To_Partners()
                ResetProertyHistorySubjectToNoValid()
                ResetProertyHistorySubjectToNoValid_Warning_BeforeFiveDays()
                'NotifyFeedLog()
            End If
            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                'NotifyOrangeBlue()
                'NotifyOrangeBlue_To_Partners()
                'NotifyFeedLog()
                isDevORTraining = 1
            End If
            If isDevORTraining = 0 Then
                NotifyFeaturedProperty()
                NotifyOrangeBlue()
                NotifyOrangeBlue_To_Partners()
                NotifyFeedLog()
            End If
        End If
    End Sub
    Private Sub bindFeaturedProperty()
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@language", language)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Featured", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Dim CUtilities As New ClassUtilities
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object)
            For Each dr As DataRow In dt.Rows
                Dim BannerType As String = ""
                BannerType = dr("BannerType")
                row = New Dictionary(Of String, Object)()
                For Each col As DataColumn In dt.Columns
                    If col.ColumnName = "FormatPrice" Then
                        dr(col) = CUtilities.FormatPrice(dr("price"))
                    End If
                    If col.ColumnName = "FormatorignalPrice" Then
                        dr(col) = CUtilities.FormatPrice(dr("original_price"))
                    End If
                    If col.ColumnName = "ImageUrl" Then
                        Dim szImageURL As String
                        szImageURL = "/images/photos/properties/" & dr("property_ref").Trim & "/" & dr("property_ref").Trim & "_" & 1.ToString.Trim & ".jpg"
                        Dim nStatusID As Int16 = 0
                        If BannerType <> "" Then
                            If BannerType = "DIY Bargain" Then
                                nStatusID = 1001
                            End If
                            If BannerType = "Now Negotiable" Then
                                nStatusID = 1002
                            End If
                            If BannerType = "Reformed" Then
                                nStatusID = 1003
                            End If
                            If BannerType = "Big Reduction" Then
                                nStatusID = 1004
                            End If
                            If BannerType = "Rent To Buy Option" Then
                                nStatusID = 1005
                            End If
                            If BannerType = "Reserved" Then
                                nStatusID = 1006
                            End If
                            If BannerType = "Under Offer" Then
                                nStatusID = 7
                            End If
                        Else
                            If dr("status_id") = "7" Then
                                nStatusID = 7
                            End If
                        End If
                            dr(col) = CUtilities.ApplyStatusWatermark(szImageURL, nStatusID)
                    End If
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            rpFeaturedProperty.DataSource = dt
            rpFeaturedProperty.DataBind()
        End If
    End Sub
    Public Sub NotifyFeaturedProperty()
        Try
            Dim dtNotifyExpired As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_FeaturedProperty_GoingTo_Expired").Tables(0)
            If dtNotifyExpired.Rows.Count > 0 Then
                Dim mailTitleExpire As String = ""
                Dim mailBodyExpire As String = ""
                'Dim Partner_Id As Int32 = dr("PartnerId")
                For Each dr As DataRow In dtNotifyExpired.Rows
                    If dr("DaysToExpire") = "7" Then
                        mailTitleExpire = "Email " & dr("Property_Ref") & " exclusive contract will expire in one week"
                        If dr("IsBeforeNovember") = "1" Then
                            mailBodyExpire = "Please contact vendor to extand exclusive contract on this property using new contract with starting date after the 1st of November."
                        Else
                            mailBodyExpire = "Please contact vendor to communicate  property report and possible price reduction before exclusive contract get automaticly extended  in one week."
                        End If
                        Try
                            ' Define a New Email
                            Dim CEmailExclusiveNotification As New ClassEmail
                            Dim isDevORTraining As Int16 = 0
                            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                CEmailExclusiveNotification.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Dev", 1)
                                isDevORTraining = 1
                            End If
                            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                CEmailExclusiveNotification.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Training", 1)
                                isDevORTraining = 1
                            End If
                            If isDevORTraining = 0 Then
                                CEmailExclusiveNotification.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Live", 1)
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                    If dr("DaysToExpire") = "-7" And dr("IsBeforeNovember") = "1" Then
                        mailTitleExpire = "Email - Property " & dr("Property_Ref") & " is no longer exclusive "
                        mailBodyExpire = "Exclusive contract for this property has expired and it has been removed from Featured property listing."
                        Try
                            ' Define a New Email
                            Dim CEmailExclusiveNotification02 As New ClassEmail
                            Dim isDevORTraining As Int16 = 0
                            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                mailBodyExpire = mailBodyExpire & "<br/><a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "</a>"
                                CEmailExclusiveNotification02.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Dev", 1)
                                isDevORTraining = 1
                            End If
                            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                mailBodyExpire = mailBodyExpire & "<br/><a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "</a>"
                                CEmailExclusiveNotification02.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Training", 1)
                                isDevORTraining = 1
                            End If
                            If isDevORTraining = 0 Then
                                mailBodyExpire = mailBodyExpire & "<br/><a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "</a>"
                                CEmailExclusiveNotification02.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Live", 1)
                            End If

                        Catch ex As Exception

                        End Try
                        Dim sql As SqlParameter() = New SqlParameter(0) {}
                        sql(0) = New SqlParameter("@Property_Ref", dr("Property_Ref").ToString())
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Featured_Property_Delete", sql)
                    End If
                    If dr("DaysToExpire") = "0" And dr("IsBeforeNovember") = "0" Then
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, "update featured_property set Expiry_Date=dateadd(week,6,Expiry_Date) where Property_Ref='" & dr("Property_Ref").ToString() & "'")
                    End If
                    If dr("DaysToExpire") = "2" Then
                        Dim sqlproperyhistoryNoActionRecorded As SqlParameter() = New SqlParameter(1) {}
                        sqlproperyhistoryNoActionRecorded(0) = New SqlParameter("@Property_Ref", dr("Property_Ref").ToString())
                        Dim dtEmailRequired As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert_NoActionRecorded", sqlproperyhistoryNoActionRecorded).Tables(0)
                        If dtEmailRequired.Rows(0)("IsInserted").ToString() = "1" Then
                            'As per new requirements mentioned by jerome today by 3-11-2020 i am doing work for following : 
                            'If no owner call history in the 5 days, in addition to insert a need attention record in property history , an Email should be sent to same persons like in 2- With Message : Property ref : xxxx Vendor as not been contacted since Email sent 5 days ago. 
                            mailTitleExpire = "Email Property ref : " & dr("Property_Ref").ToString() & " Need Attentions, vendor has not been Contacted "
                            mailBodyExpire = "Property ref : " & dr("Property_Ref").ToString() & " Vendor has not been contacted since Email sent 5 days ago."

                            Try
                                ' Define a New Email
                                Dim CEmailAfter5Days As New ClassEmail
                                Dim isDevORTraining As Int16 = 0
                                If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                    mailBodyExpire = mailBodyExpire & "<br/><a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "</a>"
                                    CEmailAfter5Days.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Dev", 1)
                                    isDevORTraining = 1
                                End If
                                If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                    mailBodyExpire = mailBodyExpire & "<br/><a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "</a>"
                                    CEmailAfter5Days.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Training", 1)
                                    isDevORTraining = 1
                                End If
                                If isDevORTraining = 0 Then
                                    mailBodyExpire = mailBodyExpire & "<br/><a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("Property_Ref") & "</a>"
                                    CEmailAfter5Days.SendEmail_Notification_Single_Fuction(mailTitleExpire, mailBodyExpire, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyFeaturedProperty", "Live", 1)
                                End If
                            Catch ex As Exception

                            End Try
                        Else
                            'Else nothing.... No email.....
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub NotifyOrangeBlue()
        Try
            Dim dtNotifyBlue As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Notify_Blue").Tables(0)
            If dtNotifyBlue.Rows.Count > 0 Then
                Dim mailBlueTitle As String = ""
                Dim mailBlueBody As String = ""
                For Each dr As DataRow In dtNotifyBlue.Rows
                    If dr("daysdifference") = "56" Then
                        mailBlueTitle = "Color code on  Property " & dr("Property_Ref") & " just turn Blue"
                        mailBlueBody = "Owner of property " & dr("Property_Ref") & " needs to be contacted to discuss possible price adjustment."
                        Try
                            ' Define a New Email
                            Dim CEmailBlueNotification As New ClassEmail
                            Dim isDevORTraining As Int16 = 0
                            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                CEmailBlueNotification.SendEmail_Notification_Single_Fuction(mailBlueTitle, mailBlueBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyBlue", "Dev", 1)
                                isDevORTraining = 1
                            End If
                            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                CEmailBlueNotification.SendEmail_Notification_Single_Fuction(mailBlueTitle, mailBlueBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyBlue", "Training", 1)
                                isDevORTraining = 1
                            End If
                            If isDevORTraining = 0 Then

                                CEmailBlueNotification.SendEmail_Notification_Single_Fuction(mailBlueTitle, mailBlueBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyBlue", "Live", 1)
                            End If

                        Catch ex As Exception

                        End Try
                    End If
                    If dr("daysdifference") = "61" Then
                        Dim sqlproperyhistoryNoActionRecorded As SqlParameter() = New SqlParameter(1) {}
                        sqlproperyhistoryNoActionRecorded(0) = New SqlParameter("@Property_Ref", dr("Property_Ref").ToString())
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert_NoActionRecorded", sqlproperyhistoryNoActionRecorded)
                    End If
                Next
            End If

            Dim dtNotifyOrange As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Notify_Orange").Tables(0)
            If dtNotifyOrange.Rows.Count > 0 Then
                Dim mailOrangeTitle As String = ""
                Dim mailOrangeBody As String = ""
                For Each dr As DataRow In dtNotifyOrange.Rows
                    If dr("daysdifference") = "56" Then
                        mailOrangeTitle = "Color code on  Property " & dr("Property_Ref") & " just turn Orange"
                        mailOrangeBody = "Owner of property " & dr("Property_Ref") & " needs to be contacted to discuss possible price adjustment."
                        Try
                            ' Define a New Email
                            Dim CEmailOrangeNotification As New ClassEmail
                            Dim isDevORTraining As Int16 = 0
                            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                CEmailOrangeNotification.SendEmail_Notification_Single_Fuction(mailOrangeTitle, mailOrangeBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyOrange", "Dev", 1)
                                isDevORTraining = 1
                            End If
                            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                CEmailOrangeNotification.SendEmail_Notification_Single_Fuction(mailOrangeTitle, mailOrangeBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyOrange", "Training", 1)
                                isDevORTraining = 1
                            End If
                            If isDevORTraining = 0 Then
                                CEmailOrangeNotification.SendEmail_Notification_Single_Fuction(mailOrangeTitle, mailOrangeBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyOrange", "Live", 1)
                            End If

                        Catch ex As Exception

                        End Try
                    End If
                    If dr("daysdifference") = "61" Then
                        Dim sqlproperyhistoryNoActionRecorded As SqlParameter() = New SqlParameter(1) {}
                        sqlproperyhistoryNoActionRecorded(0) = New SqlParameter("@Property_Ref", dr("Property_Ref").ToString())
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert_NoActionRecorded", sqlproperyhistoryNoActionRecorded)
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub NotifyOrangeBlue_To_Partners()
        'Notify Blue To Partners If More than 10 properties in Blue then send email to all contacts under partner
        Try
            Dim dtNotifyBluePartners As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Blue_Check_By_Partners").Tables(0)

            If dtNotifyBluePartners.Rows.Count > 0 Then
                Dim mailBluePartnerTitle As String
                Dim mailBluePartnerBody As String = "There are more than 10 Properties of Blue Colors, please contact vendors."
                mailBluePartnerTitle = "There are more than 10 Blue color properties"

                For Each dr As DataRow In dtNotifyBluePartners.Rows
                    Try
                        ' Define a New Email
                        Dim CEmailBluePartnerNotification As New ClassEmail
                        Dim isDevORTraining As Int16 = 0
                        If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                            CEmailBluePartnerNotification.SendEmail_Notification_Single_Fuction(mailBluePartnerTitle, mailBluePartnerBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyBlueToPartnesOnly", "Dev", 1)
                            isDevORTraining = 1
                        End If
                        If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                            CEmailBluePartnerNotification.SendEmail_Notification_Single_Fuction(mailBluePartnerTitle, mailBluePartnerBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyBlueToPartnesOnly", "Training", 1)
                            isDevORTraining = 1
                        End If
                        If isDevORTraining = 0 Then
                            CEmailBluePartnerNotification.SendEmail_Notification_Single_Fuction(mailBluePartnerTitle, mailBluePartnerBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyBlueToPartnesOnly", "Live", 1)
                        End If

                    Catch ex As Exception

                    End Try
                Next
            End If

        Catch ex As Exception

        End Try
        Try
            Dim dtNotifyOrangePartners As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Orange_Check_By_Partners").Tables(0)

            If dtNotifyOrangePartners.Rows.Count > 0 Then
                Dim mailOrangePartnerTitle As String
                mailOrangePartnerTitle = "There are more than 3 orange color properties"
                Dim mailOrangePartnerBody As String = "There are more than 3 Properties of Orange Colors, please contact vendors."
                For Each dr As DataRow In dtNotifyOrangePartners.Rows
                    Try
                        ' Define a New Email
                        Dim CEmailOrangePartnerNotification As New ClassEmail
                        Dim isDevORTraining As Int16 = 0
                        If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                            CEmailOrangePartnerNotification.SendEmail_Notification_Single_Fuction(mailOrangePartnerTitle, mailOrangePartnerBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyOrangeToPartnesOnly", "Dev", 1)
                            isDevORTraining = 1
                        End If
                        If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                            CEmailOrangePartnerNotification.SendEmail_Notification_Single_Fuction(mailOrangePartnerTitle, mailOrangePartnerBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyOrangeToPartnesOnly", "Training", 1)
                            isDevORTraining = 1
                        End If
                        If isDevORTraining = 0 Then
                            CEmailOrangePartnerNotification.SendEmail_Notification_Single_Fuction(mailOrangePartnerTitle, mailOrangePartnerBody, Convert.ToInt32(dr("PartnerId")), dr("ListerEmail").ToString(), "NotifyOrangeToPartnesOnly", "Live", 1)
                        End If

                    Catch ex As Exception

                    End Try
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub NotifyFeedLog()
        Dim dtCheckFeedLogs As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Check_Latest_FeedLog").Tables(0)
        If dtCheckFeedLogs.Rows.Count > 0 Then
            If dtCheckFeedLogs.Rows(0)("CheckDate").ToString() = "2" And dtCheckFeedLogs.Rows(0)("TodayDate").ToString() = "0" Then
                Dim mailTitleFeedLog As String = ""
                Dim mailBodyFeedLog As String = ""
                mailTitleFeedLog = "Feed Generation Failure Email Notification"
                mailBodyFeedLog = "Hey, This is to inform you that last day feeds have not been genereated successfully for Inalandandalucia Portal ! Please check as soon as possible !"
                ' Define a New Email
                Dim CEmailFeedLogNotification As New ClassEmail
                CEmailFeedLogNotification.SendFeedLogs_Email_Notification(mailTitleFeedLog, mailBodyFeedLog)
                'Insert into feed check logs
                Dim sqlFeedLogs As SqlParameter() = New SqlParameter(1) {}
                sqlFeedLogs(0) = New SqlParameter("@LogStatus", "False")
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_FeedCheckLog_Insert", sqlFeedLogs)
            End If
        End If
    End Sub
    Public Sub ResetProertyHistorySubjectToNoValid()
        'Check if there is already log been created means URL been hit at the same day already
        Dim sqlReservationExpiringToday As SqlParameter() = New SqlParameter(1) {}
        sqlReservationExpiringToday(0) = New SqlParameter("@NotifyLogType", "Reservation_Expiring_Today")
        Dim dtReservationExpiringToday As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_NotifyLog_Check", sqlReservationExpiringToday).Tables(0)
        If dtReservationExpiringToday.Rows(0)("TotalRecords").ToString() = "0" Then
            'Send email functionality to admin & sales person
            Dim PropertyRef As String = ""
            Dim CustomerName As String = ""
            Dim SalesPersonEmail As String = ""
            Dim SubjectToType As String = ""
            Dim SubjectToAdmin As String
            Dim ContentToAdmin As String
            Dim dtPropertyHistoryExpiring As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Get_Today_Expiring").Tables(0)
            If dtPropertyHistoryExpiring.Rows.Count > 0 Then
                For Each row As DataRow In dtPropertyHistoryExpiring.Rows
                    PropertyRef = row("Property_Ref")
                    CustomerName = row("Buyer")
                    SalesPersonEmail = row("SalesPersonEmail")
                    SubjectToType = row("SubjectType")
                    SubjectToAdmin = "Test Only - Subject to reservation has expired for property " & PropertyRef
                    ContentToAdmin = "Test Only - The reservation " & SubjectToType & " for the client " & CustomerName & " on property " & PropertyRef & " has now expired. This client doesn't have this property reserved anymore. "
                    SendExpiryEmails(SubjectToAdmin, ContentToAdmin)
                Next row
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Make_No_Valid")
            End If
        End If
    End Sub
    Public Sub ResetProertyHistorySubjectToNoValid_Warning_BeforeFiveDays()
        'Check if there is already log been created means URL been hit at the same day already
        Dim sqlReservationExpiringToday As SqlParameter() = New SqlParameter(1) {}
        sqlReservationExpiringToday(0) = New SqlParameter("@NotifyLogType", "Reservation_Expiring_After_Five_Days")
        Dim dtReservationExpiringToday As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_NotifyLog_Check", sqlReservationExpiringToday).Tables(0)
        If dtReservationExpiringToday.Rows(0)("TotalRecords").ToString() = "0" Then
            'Send email functionality to admin & sales person before 5 days as warning email
            Dim PropertyRef As String = ""
            Dim CustomerName As String = ""
            Dim SalesPersonEmail As String = ""
            Dim SubjectToType As String = ""
            Dim SubjectToAdmin As String
            Dim ContentToAdmin As String
            Dim dtPropertyHistoryExpiring As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Get_Expiring_Five_Days_Left").Tables(0)
            If dtPropertyHistoryExpiring.Rows.Count > 0 Then
                For Each row As DataRow In dtPropertyHistoryExpiring.Rows
                    PropertyRef = row("Property_Ref")
                    CustomerName = row("Buyer")
                    SalesPersonEmail = row("SalesPersonEmail")
                    SubjectToType = row("SubjectType")
                    SubjectToAdmin = "Test Only - The resevation for property " & PropertyRef & " will expire in 5 days"
                    ContentToAdmin = "Test Only : If no action is taken, the reservation " & SubjectToType & " for the client  " & CustomerName & " on property " & PropertyRef & " will end in 5 days."
                    SendExpiryEmails(SubjectToAdmin, ContentToAdmin)
                Next row
            End If
        End If

    End Sub
    Public Sub SendExpiryEmails(ByVal EmailTitle As String, ByVal EmailBody As String)
        Try
            Dim CEmailAdmin As New ClassEmail
            'CEmailAdmin.SendEmail("info@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("jerome@inlandandalucia.com", EmailTitle, EmailBody, True, Nothing, False)
            'CEmailAdmin.SendEmail("lee@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            'CEmailAdmin.SendEmail(SalesPersonEmail, SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("sourabhodesk@gmail.com", EmailTitle, EmailBody, True, Nothing, False)
            CEmailAdmin = Nothing
        Catch ex As Exception
            'lblError.Text = ex.InnerException.ToString()
        End Try
    End Sub
    Public Function ConvertDataTabletoString() As String
        If Not IsPostBack Then
            Return ""
        Else
            Dim CUtilities As New ClassUtilities
            'Dim sql As SqlParameter() = New SqlParameter(1) {}
            'sql(0) = New SqlParameter("@LanguageId", language)
            'Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_property_mapAllLocation", sql).Tables(0)
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_property_mapAllLocation_By_Areas").Tables(0)
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object)
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each col As DataColumn In dt.Columns
                    'If col.ColumnName = "formatprice" Then
                    '    dr(col) = CUtilities.FormatPrice(dr("price"))
                    'End If
                    'If col.ColumnName = "url" Then
                    '    'If dr("status_id") <> "7" And dr("status_id") <> "5" Then
                    '    '    dr("status_Id") = "20"
                    '    'End If
                    '    dr(col) = CUtilities.ApplyStatusWatermark(PhotoURL(dr("property_ref")), dr("status_id"))
                    'End If
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows)
        End If
    End Function
    Private Function PhotoURL(ByVal szPropertyRef As String) As String
        ' Local Vars
        Dim bThumbnail As Boolean = True
        ' Set the Path to the Thumbnail
        Dim szPath As String = "/images/photos/properties/" & szPropertyRef.Trim & "/" & szPropertyRef.Trim & "_TN.jpg"
        ' If the Thumbnail does not Exist
        If Not File.Exists(Server.MapPath(szPath)) Then
            ' Create the Thumbnail
            Dim CUtilities As New ClassUtilities
            bThumbnail = CUtilities.CreateThumbnail(szPropertyRef)
            CUtilities = Nothing
        End If

        ' If we were unable to Create a Thumbnail
        If Not bThumbnail Then

            ' Set to No Image Photo
            szPath = "/images/icons/no-photo.png"

        End If

        ' Return the Result
        Return szPath

    End Function
    Protected Sub imgmap_Click(sender As Object, e As ImageClickEventArgs)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "myKey", "google.maps.event.addDomListener(window, 'load', initialize);", True)
        imgmap.Style.Add(HtmlTextWriterStyle.Display, "none")
        googleMap.Style.Add(HtmlTextWriterStyle.Display, "block")
    End Sub
End Class