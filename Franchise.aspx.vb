Imports System.Data.SqlClient
Imports System.Data
Imports HashSoftwares

Partial Class Franchise
    '   Inherits System.Web.UI.Page
    Inherits BasePage
    Public Event MessageValidated As System.EventHandler
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim CEmail2 As New ClassEmail
        'CEmail2.SendEmail("sourabhodesk@gmail.com", "test subject", "test body content", False)
        Page.Title = "Inland Andalucia | Franchise Request Form"
        ' If not Postback
        If Not Page.IsPostBack Then
            Session("ContactUsArrival") = Now
            ' If we have the First Name
            If Not Session("FirstName") Is Nothing Then
                txtFirstName.Text = Session("FirstName")
            End If

            ' If we have the Last Name
            If Not Session("LastName") Is Nothing Then
                txtLastName.Text = Session("LastName")
            End If

            ' If we have the Address
            If Not Session("Address") Is Nothing Then
                txtAddress.Text = Session("Address")
            End If

            ' If we have the Telephone
            If Not Session("Telephone") Is Nothing Then
                txtTelephone.Text = Session("Telephone")
            End If

            ' If we have the Email
            If Not Session("Email") Is Nothing Then
                txtEmail.Text = Session("Email")
            End If


            ' Is there a Property Reference
            If Not Request.QueryString("reference") Is Nothing Then

                ' Update the Comment with the Reference
                txtComment.Text = "Hi" & vbCrLf & vbCrLf & "I am interested in property reference " & Request.QueryString("reference").ToUpper.Trim & ".  Please can you contact me regarding this property using the contact details provided?" & vbCrLf & vbCrLf & "Best Regards" & vbCrLf & vbCrLf

                ' If we have the First Name
                If Not Session("FirstName") Is Nothing Then
                    txtComment.Text &= Session("FirstName")
                End If

                ' Set the Session Value
                'Dim CDataAccess As New ClassDataAccess

                ' CDataAccess = Nothing
                Dim sql As SqlParameter() = New SqlParameter(1) {}
                sql(0) = New SqlParameter("@property_ref", Request.QueryString("reference"))
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_contact_NameandEmailBy_PropRef", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    Session("ContactUsEmail") = dt.Rows(0)("email")
                    Session("ContactUsName") = dt.Rows(0)("contact_name")

                End If

            Else

                ' No Property Reference.  Reset to avoid Message going to wrong Office.              
                Session("ContactUsEmail") = Nothing
                Session("ContactUsName") = Nothing

            End If

        End If

    End Sub

    Protected Sub btnSendMessage_Click(sender As Object, e As EventArgs)

        Dim CUtilities As New ClassUtilities

        ' Validate this IP
        Session("FirstName") = StrConv(txtFirstName.Text.Trim, VbStrConv.ProperCase)
        Session("LastName") = StrConv(txtLastName.Text.Trim, VbStrConv.ProperCase)
        Session("Address") = StrConv(txtAddress.Text.Trim, VbStrConv.ProperCase)
        Session("Telephone") = txtTelephone.Text.Trim
        Session("Email") = txtEmail.Text.ToLower.Trim
        Session("Comment") = txtComment.Text.Trim
        Dim sql As SqlParameter() = New SqlParameter(6) {}
        sql(0) = New SqlParameter("@Contact_Name", txtFirstName.Text & " " & txtLastName.Text)
        sql(1) = New SqlParameter("@Contact_Address", txtAddress.Text)
        sql(2) = New SqlParameter("@Contact_Telephone", txtTelephone.Text)
        sql(3) = New SqlParameter("@Contact_Email", txtEmail.Text)
        sql(4) = New SqlParameter("@Contact_Notes", txtComment.Text)
        sql(5) = New SqlParameter("@Contact_Id_From", 1001)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Insert_FranchiseRequest", sql)
        'If dt.Rows.Count > 0 Then

        '    'If dt.Rows(0)("Result") = "1" Then
        '    LabelComment.Visible = False
        '    RaiseEvent MessageValidated(Me, e)
        SendMessageToEmail()
        'Else
        '    ' Inform the User
        '    LabelComment.Text = "Message service blocked due to multiple requests"
        '    LabelComment.Visible = True

        'End If

        'End If

    End Sub
    Public Function GetIPAddress() As String

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

        ' Return the Result
        Return szIPAddress.Trim

    End Function

    Private Sub SendMessageToEmail()

        ' Only do this if the User has been on the Page 3 Seconds or more (Bot Avoidance)
        If DateDiff(DateInterval.Second, Convert.ToDateTime(Session("ContactUsArrival")), Now) >= 3 Then

            '' Send the Message on a Separate Execution Thread as can take up to a Minute to Send
            'Dim t As New Threading.Thread(AddressOf ThreadSendMessage)
            't.Start()

            ' Local Vars
            'Dim szEmailTo As String = System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress")
            Dim szEmailTo As String = "franchise@inlandandalucia.com"
            Dim szSubject As String = "Franchise Enquiry"
            Dim CUtilities As New ClassUtilities

            ' Define Content
            Dim szContent As String =
                "First Name:    " & txtFirstName.Text & vbCrLf &
                "Last Name:     " & txtLastName.Text & vbCrLf &
                "Address:       " & txtAddress.Text & vbCrLf &
                "Telephone:     " & txtTelephone.Text & vbCrLf &
                "Email:         " & txtEmail.Text & vbCrLf &
                "Origin:        " & GetLocation() & vbCrLf &
                "Comment:       " & vbCrLf & vbCrLf & txtComment.Text

            ' Tidy
            CUtilities = Nothing

            ' Check if we have a Partner to Send this Email To
            If Not Session("ContactUsEmail") Is Nothing Then

                ' If we have a Value
                If Convert.ToString(Session("ContactUsEmail")).Trim <> String.Empty Then

                    ' Set the Email Address
                    'szEmailTo = Convert.ToString(Session("ContactUsEmail")).ToLower.Trim
                    szEmailTo = "sourabhodesk@gmail.com"
                End If

            End If

            ' Check if we have a Partner Name
            If Not Session("ContactUsName") Is Nothing Then

                ' If we have a Value
                If Convert.ToString(Session("ContactUsName")).Trim <> String.Empty Then

                    ' Add to the Email Subject the Partner Name
                    szSubject &= " for " & Convert.ToString(Session("ContactUsName")).Trim

                End If

            End If

            ' Send the Email
            Dim CEmail As New ClassEmail
            CEmail.SendEmail(szEmailTo, szSubject, szContent, False)
            'CEmail.SendEmail("sourabhodesk@gmail.com", szSubject, szContent, False)

            CEmail = Nothing

        Else
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@ipaddress", GetIPAddress())
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_bot_attacks_insert", sql)
        End If

        contact.Style.Add(HtmlTextWriterStyle.Display, "none")
        thanku.Style.Add(HtmlTextWriterStyle.Display, "block")
        ' Remove Previous Controls

        ' Load Thank You Page
        Dim ctrl As Control = LoadControl("Controls/WebUserControlThankYou.ascx")
        ctrl.ID = "ThankYou1"

        ' Add Control to Update Panel

    End Sub
    Public Function GetLocation() As String

        ' Local Vars
        Dim szLocation As String = String.Empty

        ' Get the IP Numbers
        Dim szIP() As String = GetIPAddress.Split(".")

        ' Calculating IP Number
        Dim nIPNumber As Long = Convert.ToDouble(16777216 * szIP(0)) + 65536 * Convert.ToInt32(szIP(1)) + 256 * Convert.ToInt32(szIP(2)) + Convert.ToInt32(szIP(3))
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@nIPNumber", nIPNumber)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_GetlocationByIPNumber", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            szLocation = dt.Rows(0)("country")
        End If

        Return szLocation

    End Function

End Class
