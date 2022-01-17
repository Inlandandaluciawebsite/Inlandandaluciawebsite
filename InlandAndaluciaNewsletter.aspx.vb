Imports System.Data.SqlClient
Imports HashSoftwares
Imports System.Data

Partial Class InlandAndaluciaNewsletter
    '  Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If we know the Name and Email Address of the User, Pre Populate
        ' If not Postback
        Page.Title = "Inland Andalucia | Subscribe to Newsletter"
        If Not Page.IsPostBack Then
            Session("NewsletterArrival") = Now

            ' If we have the First Name
            If Not Session("FirstName") Is Nothing Then
                TextBoxName.Text = Convert.ToString(Session("FirstName")).Trim
            End If

            ' If we have the Last Name
            If Not Session("LastName") Is Nothing Then
                TextBoxName.Text &= " " & Convert.ToString(Session("LastName")).Trim
            End If

            ' If we have the Email
            If Not Session("Email") Is Nothing Then
                TextBoxEmail.Text = Session("Email")
            End If

        End If

    End Sub
    Protected Sub btnsubscribe_Click(sender As Object, e As EventArgs)

        ' Only do this if the User has been on the Page 3 Seconds or more (Bot Avoidance)
        If DateDiff(DateInterval.Second, Convert.ToDateTime(Session("NewsletterArrival")), Now) >= 3 Then

            ' If the Session Variables have been Defined
            If Not TextBoxName.Text Is Nothing And Not TextBoxEmail.Text Is Nothing Then

                ' Send the Message on a Separate Execution Thread as can take up to a Minute to Send
                Dim t As New Threading.Thread(AddressOf ThreadSendMessage)
                t.Start()

            End If

        Else

            ' Record Bot Attack
            '   Dim CDataAccess As New ClassDataAccess

            ' Get the User's IP
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
            Dim szIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If String.IsNullOrEmpty(szIPAddress) Then
                szIPAddress = context.Request.ServerVariables("REMOTE_ADDR")
            Else
                Dim ipArray As String() = szIPAddress.Split(
                    New [Char]() {","c})
                szIPAddress = ipArray(0)
            End If

            ' Init SQL
            '     CDataAccess.RecordBotAttack(szIPAddress.Trim)
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@ipaddress", szIPAddress.Trim)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_bot_attacks_insert", sql)


            ' Tidy
            'CDataAccess = Nothing

        End If

        ' Remove Previous Controls
        ' UpdatePanelNewsletterSubscription.ContentTemplateContainer.Controls.Clear()

        ' Load Thank You Page
        'Dim ctrl As Control = LoadControl("Controls/WebUserControlThankYouSubscription.ascx")
        'ctrl.ID = "ThankYouSubscription1"

        ' Add Control to Update Panel
        'UpdatePanelNewsletterSubscription.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update Panel
        'UpdatePanelNewsletterSubscription.Update()
       
            ' If they have Unsubscribed
        If CheckBoxUnsubscribe.Checked = True Then

            ' Unsubscribed
            SubscriptionText.InnerHtml = "Your request to unsubscribe from our newsletter has been received"

        Else

            ' Subscribed
            SubscriptionText.InnerHtml = "Thank you for subscribing to our newsletter"

        End If


        newsletter.Style.Add(HtmlTextWriterStyle.Display, "none")
        thanku.Style.Add(HtmlTextWriterStyle.Display, "block")

    End Sub

    Private Sub ThreadSendMessage()

        ' Define Content
        Dim szContent As String
        Dim szSubject As String

        ' Remove unwanted Characters
        If Convert.ToString(Session("SubscriberName")).StartsWith("~~~") And Convert.ToString(Session("SubscriberName")).EndsWith("~~~") Then

            ' Local Vars
            Dim szScratch As String = Convert.ToString(Session("SubscriberName")).Replace("~", String.Empty)
            '  Dim CDataAccess As New ClassDataAccess
            Execute(szScratch)
        Else

            ' If they have Subscribed
            If CheckBoxUnsubscribe.Checked = True Then

                ' Unsubscribed
                szSubject = "Unsubscription from the Newsletter"
                szContent =
                    "The following person has unsubscibed from the Newsletter:" & vbCrLf & vbCrLf &
                    "Name: " & Convert.ToString((TextBoxName.Text)).Trim & vbCrLf &
                    "Email: " & Convert.ToString((TextBoxEmail.Text)).Trim

            Else

                ' Subscribed
                szSubject = "Subscription to the Newsletter"
                szContent =
                    "The following person has subscibed to the Newsletter:" & vbCrLf & vbCrLf &
                    "Name: " & Convert.ToString(TextBoxName.Text).Trim & vbCrLf &
                    "Email: " & Convert.ToString(TextBoxEmail.Text).Trim

            End If

            ' Send the Email
            Dim CEmail As New ClassEmail

            If CheckBoxUnsubscribe.Checked Then
                Try
                    CEmail.SendEmailNewsletter("newsletter@inlandandalucia.com", szSubject, szContent, False)
                    CEmail = Nothing
                Catch ex As Exception

                End Try

            Else
                Try
                    Dim CEmail03 As New ClassEmail
                    CEmail03.SendEmail(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), szSubject, szContent, False)
                    'CEmail03.SendEmailNewsletter("sourabhodesk+1@gmail.com", szSubject, szContent, False)
                    CEmail03 = Nothing
                Catch ex As Exception

                End Try
                Try
                    Dim CEmail02 As New ClassEmail
                    CEmail02.SendEmailNewsletter("newsletter@inlandandalucia.com", szSubject, szContent, False)
                    CEmail02 = Nothing
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub
    Public Function Execute(ByVal szSQL As String) As Boolean

        ' Init to no Error
        Dim bRetVal As Boolean = False

        Using sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("IA").ToString)

            Try

                Dim sqlCommand As New SqlCommand(szSQL, sqlConnection)

                sqlConnection.Open()

                sqlCommand.ExecuteNonQuery()

                sqlCommand.Dispose()

            Catch ex As Exception
                ' Error - set Flag
                bRetVal = True
            End Try

            sqlConnection.Close()

        End Using

        ' Return the Result
        Return bRetVal

    End Function

End Class

