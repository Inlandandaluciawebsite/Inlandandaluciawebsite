Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports inland_api
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Security
Imports System.Security.Cryptography


Partial Class Client
    Inherits System.Web.UI.Page
    Public Event CreateTour()
    Public Event BuyerSelected()
    Dim CBuyer As ClassBuyer
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        ' Languages
        CUtilities.PopulateDropDownList(DropDownListLanguage, CDataAccess.Languages(Convert.ToInt32(Session("ContactLanguageID"))))
        ' Source
        CUtilities.PopulateDropDownList(DropDownListSource, CDataAccess.BuyerSource)
        DropDownListSource.Items.Insert(0, "--- Select ---")
        ' Status
        CUtilities.PopulateDropDownList(DropDownListStatus, CDataAccess.BuyerStatus)
        DropDownListStatus.Items.Insert(0, "--- Select ---")
        ' Tidy
        CDataAccess = Nothing
        CUtilities = Nothing
    End Sub
    Public Sub BindHistoryByBuyer()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Buyer_ID", CBuyer.ID)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_SELECT_BY_BuyerID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            btnClintHistory.Visible = True
        Else
            btnClintHistory.Visible = True
            btnClintHistory.PostBackUrl = "~/AdminNew/BuyerActionAgenda.aspx"
        End If
    End Sub
    Protected Sub DropDownListPartner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPartner.SelectedIndexChanged
        ' If we have a Partner
        If DropDownListPartner.SelectedValue <> String.Empty Then
            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            ' Get the Agents associated with this Partner
            CUtilities.PopulateDropDownList(DropDownListAgent, CDataAccess.Agents(Convert.ToInt32(DropDownListPartner.SelectedValue)))
            ' Tidy
            CDataAccess = Nothing
            CUtilities = Nothing
        End If
        ' Add <None> to Agent
        DropDownListAgent.Items.Insert(0, "--- None ---")
        ' Make Form Dirty
        'MakeDirty()
    End Sub
    Private Sub EnableMakeDirty(ByVal bEnable As Boolean)
        ' Add / Remove Event Handlers
        'TextBoxForename.AutoPostBack = bEnable
        'TextBoxSurname.AutoPostBack = bEnable
        'TextBoxPassportNo.AutoPostBack = bEnable
        'TextBoxAddress.AutoPostBack = bEnable
        'TextBoxContactName.AutoPostBack = bEnable
        'TextBoxTelephone.AutoPostBack = bEnable
        'TextBoxEmail.AutoPostBack = bEnable
        'TextBoxNotes.AutoPostBack = bEnable
        'DropDownListAgent.AutoPostBack = bEnable
        'DropDownListLanguage.AutoPostBack = bEnable
        'TextBoxBudget.AutoPostBack = bEnable
        'DropDownListSource.AutoPostBack = bEnable
        'DropDownListStatus.AutoPostBack = bEnable
        'CheckBoxArchived12.AutoPostBack = bEnable
    End Sub
    Private Sub MakeDirty()
        ' Make Form Changes
        TableRowSaved.Visible = False
        ButtonSave.BackColor = Drawing.Color.Red
        ButtonSave.ForeColor = Drawing.Color.White
        ButtonSave.Font.Bold = True
        ' Disable Make Dirty
        EnableMakeDirty(False)
    End Sub
    Private Sub MakeClean()
        ' Make Form Changes
        ButtonSave.BackColor = Nothing
        ButtonSave.ForeColor = Nothing
        ButtonSave.Font.Bold = False
        ' Enable Make Dirty
        EnableMakeDirty(True)
    End Sub
    'Protected Sub TextBoxForename_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForename.TextChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub DropDownListBroker_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListAgent.SelectedIndexChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub DropDownListLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListLanguage.SelectedIndexChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub TextBoxAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAddress.TextChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub TextBoxBudget_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxBudget.TextChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub TextBoxContactName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxContactName.TextChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub TextBoxEmail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxEmail.TextChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub TextBoxNotes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxNotes.TextChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub TextBoxPassportNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPassportNo.TextChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub TextBoxSurname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxSurname.TextChanged
    '    MakeDirty()
    'End Sub
    'Protected Sub TextBoxTelephone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxTelephone.TextChanged
    '    MakeDirty()
    'End Sub
    Private Function GetFormInteger(ByVal ddl As DropDownList) As Integer
        If ddl.SelectedValue.Trim = "--- None ---" Or ddl.SelectedValue.Trim = "--- Select ---" Then
            Return 0
        Else
            Return Convert.ToInt32(ddl.SelectedValue.Trim)
        End If
    End Function
    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        ' Check Session Expiration
        If Session("AdminBuyerSelected") Is Nothing Then
            Response.Redirect("~/AgentLogin.aspx")
        Else
            ' Local Vars
            Dim bProceed As Boolean = False
            Dim CBuyer As ClassBuyer = DirectCast(Session("AdminBuyerSelected"), ClassBuyer)
            ' If this is a New Buyer
            If CBuyer.ID < 1 Then
                ' If we have not yet Prompted for Duplicates
                If TableRowPossibleDuplicates.Visible Then
                    ' Been Prompted, Continue
                    bProceed = True
                Else
                    ' If no Possible Duplicates Exist
                    If Not CheckForDuplicates() Then
                        ' Proceed
                        bProceed = True
                    End If
                End If
            Else
                ' Updating
                bProceed = True
            End If
            ' If we are Saving
            If bProceed Then
                ' Assign Variables
                CBuyer.Forename = TextBoxForename.Text.Trim
                CBuyer.Surname = TextBoxSurname.Text.Trim
                CBuyer.PassportNumber = TextBoxPassportNo.Text.Trim
                CBuyer.Address = TextBoxAddress.Text.Trim
                CBuyer.ContactName = TextBoxContactName.Text.Trim
                CBuyer.Telephone = TextBoxTelephone.Text.Trim
                CBuyer.Email = TextBoxEmail.Text.Trim
                CBuyer.Notes = TextBoxNotes.Text.Trim.Replace("'", "''")
                CBuyer.AgentID = GetFormInteger(DropDownListAgent)
                CBuyer.LanguageID = GetFormInteger(DropDownListLanguage)
                If TextBoxBudget.Text = "" Then
                    TextBoxBudget.Text = "0"
                End If
                CBuyer.Budget = Convert.ToInt32(TextBoxBudget.Text)
                CBuyer.SourceID = GetFormInteger(DropDownListSource)
                CBuyer.StatusID = GetFormInteger(DropDownListStatus)
                CBuyer.Archived = CheckBoxArchived12.Checked
                CBuyer.PartnerID = Convert.ToInt32(DropDownListPartner.SelectedValue)
                CBuyer.Buyer_Salesperson_ID = Convert.ToInt32(drpUser.SelectedValue)
                ' Save & Assign to the Session Variable
                CBuyer.Save()

                'Insert with in buyer_history table if allocated user been changed/modified'

                If hdnUser.Value <> drpUser.SelectedItem.Text Then
                    Dim HistoryText As String
                    If hdnUser.Value = "-- Select --" Then
                        HistoryText = "New Sales Person " & drpUser.SelectedItem.Text & " has been allocated for this buyer"

                        CBuyer.BuyerAllocationChange(CBuyer.ID, HistoryText, Convert.ToInt32(Session("ContactID")))
                    Else
                        HistoryText = "Allocated Salesperson has been changed from " & hdnUser.Value & "  to " & drpUser.SelectedItem.Text & ""
                        CBuyer.BuyerAllocationChange(CBuyer.ID, HistoryText, Convert.ToInt32(Session("ContactID")))
                    End If
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'Here call procedure to update propertyref column of buyer table and also insert in the property history table together

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Session("AdminBuyerSelected") = CBuyer
                ' Display / Hide Create Tour Button
                ButtonCreateTour.Visible = CBuyer.ID > 0
                ' Clean the Form
                MakeClean()
                ' Enable Functionality
                EnableForm((CBuyer.PartnerID = Convert.ToInt32(Session("ContactPartnerID"))) And (Not CBuyer.Archived))

                ' Display the Message to the User
                TableRowSaved.Visible = True
                btnAction.Visible = True
                If Not Request.QueryString("ID") Is Nothing Then
                    'Call Inland API function after Update Existing Buyer
                    Try
                        'Dim createPropertyReturnJason As String
                        'Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/buyer/update/" & CBuyer.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                        'httpRequest.ContentType = "application/json"
                        'httpRequest.Method = "GET"
                        'Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                        '    Using stream As Stream = httpResponse.GetResponseStream()
                        '        Dim json As String = (New StreamReader(stream)).ReadToEnd()
                        '        createPropertyReturnJason = json
                        '    End Using
                        'End Using
                        'Dim sqlAPI As SqlParameter() = New SqlParameter(5) {}
                        'sqlAPI(0) = New SqlParameter("@Title", "Buyer")
                        'sqlAPI(1) = New SqlParameter("@ActionType", "Update")
                        'sqlAPI(2) = New SqlParameter("@JasonString", createPropertyReturnJason)
                        'sqlAPI(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                        'sqlAPI(4) = New SqlParameter("@Property_Id", CBuyer.ID)
                        'SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sqlAPI)
                    Catch ex As Exception
                        'Dim sqlAPI As SqlParameter() = New SqlParameter(5) {}
                        'sqlAPI(0) = New SqlParameter("@Title", "Buyer")
                        'sqlAPI(1) = New SqlParameter("@ActionType", "Update")
                        'sqlAPI(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                        'sqlAPI(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                        'sqlAPI(4) = New SqlParameter("@Property_Id", CBuyer.ID)
                        'SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sqlAPI)
                    End Try

                    'Adding new enquiry form request with in property history as per property references

                    Dim propertyreferences As String = ""
                    Dim propertyreference As String = ""
                    Dim BuyerNotes = TextBoxNotes.Text.ToLower()
                    Dim propertytypes As String = "AP,BA,CH,CM,CJ,DP,FI,PJ,PL,TH,VL"
                    For i = 0 To propertytypes.Split(",").Length - 1
                        BuyerNotes = TextBoxNotes.Text.ToLower()
                        For j = 0 To 9
                            Dim prefix As String = propertytypes.ToLower().Split(",")(i) & j.ToString().ToLower()
                            Dim index As Int16 = BuyerNotes.IndexOf(prefix)
                            Dim count1 As String = BuyerNotes.Replace(prefix, "")
                            Dim countHowMany As Int16 = (BuyerNotes.Length - count1.Length) / prefix.Length
                            For startPrefix = 1 To countHowMany
                                If Convert.ToInt16(BuyerNotes.IndexOf(prefix)) > -1 Then
                                    Try
                                        propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 6)
                                    Catch ex As Exception
                                        Try
                                            propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 5)
                                        Catch exjj As Exception
                                            Try
                                                propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 4)
                                            Catch ex1 As Exception
                                                Try
                                                    propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 3)
                                                Catch ex2 As Exception
                                                    Try
                                                        propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 2)
                                                    Catch ex3 As Exception

                                                    End Try
                                                End Try
                                            End Try
                                        End Try
                                    End Try
                                    propertyreferences = propertyreferences & propertyreference & " "
                                End If
                                BuyerNotes = BuyerNotes.Replace(propertyreference.Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", ""), "")
                            Next
                        Next
                    Next
                    Dim sql As SqlParameter() = New SqlParameter(2) {}
                    sql(0) = New SqlParameter("@Buyer_Id", CBuyer.ID)
                    sql(1) = New SqlParameter("@PropertyRef", propertyreferences.ToUpper().Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", ""))
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Update_PropertyRefs", sql)

                    Dim totalreferences() As String = propertyreferences.ToUpper().Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", "").Split(" ")
                    For i = 0 To totalreferences.Count - 1
                        If totalreferences(i) <> "" Then
                            Dim sqlpropertyhistory As SqlParameter() = New SqlParameter(5) {}
                            sqlpropertyhistory(0) = New SqlParameter("@Property_Ref", totalreferences(i).ToString())
                            sqlpropertyhistory(1) = New SqlParameter("@Type_Id", 14)
                            Dim Buyer_Surname As String = CBuyer.Surname
                            Dim Buyer_Forename As String = CBuyer.Forename
                            Dim datereceived As String = DateTime.Now.ToString()
                            Dim historytext = "Enquiry received for the property ref  " & totalreferences(i).ToString() & " from client " & Buyer_Surname & " " & Buyer_Forename & " – on the " & datereceived & ""
                            sqlpropertyhistory(2) = New SqlParameter("@History_Text", historytext)
                            sqlpropertyhistory(3) = New SqlParameter("@Modified_By", 0)
                            sqlpropertyhistory(4) = New SqlParameter("@Buyer_Id", CBuyer.ID)
                            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert", sqlpropertyhistory)
                        End If
                    Next

                Else
                    'Send email after creating new buyer only if buyer source is APITS Manchaster

                    'If DropDownListSource.SelectedItem.Text = "APITS Manchester" Then

                    '    Try
                    '        Dim SubjectToBuyer As String
                    '        Dim ContentToBuyer As String
                    '        SubjectToBuyer = "We met earlier today in Inland Andalucia Stand at APITS Manchester"
                    '        ContentToBuyer = "<p>Dear <b>" & TextBoxForename.Text & " " & TextBoxSurname.Text & "</b></p>"
                    '        ContentToBuyer = ContentToBuyer & "<p>It was a real pleasure to meet you at the A Place in the Sun show today in Manchester. I hope that you enjoyed your day.               </p>               <p>Please let me confirm that following our conversation we have full details of your search criteria and property search requirements.</p>               <p>In the next day or two you will receive a further email from our property specialist who knows and understands the area that you are considering. We will do our very best to help you find the property of your dreams. </p>               <p>                   Meanwhile please when you have time take a look at our website…               </p>               <p>                   <a href='https://www.inlandandalucia.com/'>www.inlandandalucia.com</a>               </p>               <p>                   Please remember that we have videos of our properties and also Google Maps showing the location.               </p>               <p>                   Kind Regards,               </p>               <p>                   Inland Andalucia Team               </p>               <p>                   <a href='https://www.inlandandalucia.com/'>www.inlandandalucia.com</a>               </p>"
                    '        Dim ccto As String = ""

                    '        'get ccto from database by passing contact id

                    '        Dim sqlContact As SqlParameter() = New SqlParameter(1) {}
                    '        sqlContact(0) = New SqlParameter("@Contact_Id", drpUser.SelectedItem.Value)
                    '        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblContact_Select_By_Contact_Id", sqlContact).Tables(0)
                    '        If dt.Rows.Count > 0 Then
                    '            ccto = dt.Rows(0)("Contact_Email").ToString()
                    '        End If
                    '        '''''''''''''''''''''''''''''''''''''''''''''

                    '        Dim CEmailBuyer As New ClassEmail
                    '        CEmailBuyer.SendEmailBuyer(TextBoxEmail.Text, ccto, SubjectToBuyer, ContentToBuyer, True, Nothing, True)

                    '        CEmailBuyer = Nothing
                    '    Catch ex As Exception
                    '        Dim st As String = ex.InnerException.ToString()
                    '    End Try

                    'End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Call Inland API function after create new Buyer
                    Try
                        'Dim createPropertyReturnJason As String
                        'Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/buyer/create/" & CBuyer.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                        'httpRequest.ContentType = "application/json"
                        'httpRequest.Method = "GET"
                        'Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                        '    Using stream As Stream = httpResponse.GetResponseStream()
                        '        Dim json As String = (New StreamReader(stream)).ReadToEnd()
                        '        createPropertyReturnJason = json
                        '    End Using
                        'End Using
                        'Dim sqlAPI As SqlParameter() = New SqlParameter(5) {}
                        'sqlAPI(0) = New SqlParameter("@Title", "Buyer")
                        'sqlAPI(1) = New SqlParameter("@ActionType", "Create")
                        'sqlAPI(2) = New SqlParameter("@JasonString", createPropertyReturnJason)
                        'sqlAPI(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                        'sqlAPI(4) = New SqlParameter("@Property_Id", CBuyer.ID)
                        'SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sqlAPI)
                    Catch ex As Exception
                        'Dim sqlAPI As SqlParameter() = New SqlParameter(5) {}
                        'sqlAPI(0) = New SqlParameter("@Title", "Buyer")
                        'sqlAPI(1) = New SqlParameter("@ActionType", "Create")
                        'sqlAPI(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                        'sqlAPI(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                        'sqlAPI(4) = New SqlParameter("@Property_Id", CBuyer.ID)
                        'SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sqlAPI)
                    End Try

                    'Updating new enquiry form request with in property history as per property references

                    Dim propertyreferences As String = ""
                    Dim propertyreference As String = ""
                    Dim BuyerNotes = TextBoxNotes.Text.ToLower()
                    Dim propertytypes As String = "AP,BA,CH,CM,CJ,DP,FI,PJ,PL,TH,VL"
                    For i = 0 To propertytypes.Split(",").Length - 1
                        BuyerNotes = TextBoxNotes.Text.ToLower()
                        For j = 0 To 9
                            Dim prefix As String = propertytypes.ToLower().Split(",")(i) & j.ToString().ToLower()
                            Dim index As Int16 = BuyerNotes.IndexOf(prefix)
                            Dim count1 As String = BuyerNotes.Replace(prefix, "")
                            Dim countHowMany As Int16 = (BuyerNotes.Length - count1.Length) / prefix.Length
                            For startPrefix = 1 To countHowMany
                                If Convert.ToInt16(BuyerNotes.IndexOf(prefix)) > -1 Then
                                    Try
                                        propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 6)
                                    Catch ex As Exception
                                        Try
                                            propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 5)
                                        Catch exjj As Exception
                                            Try
                                                propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 4)
                                            Catch ex1 As Exception
                                                Try
                                                    propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 3)
                                                Catch ex2 As Exception
                                                    Try
                                                        propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 2)
                                                    Catch ex3 As Exception

                                                    End Try
                                                End Try
                                            End Try
                                        End Try
                                    End Try
                                    propertyreferences = propertyreferences & propertyreference & " "
                                End If
                                BuyerNotes = BuyerNotes.Replace(propertyreference.Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", ""), "")
                            Next
                        Next
                    Next
                    Dim sql As SqlParameter() = New SqlParameter(2) {}
                    sql(0) = New SqlParameter("@Buyer_Id", CBuyer.ID)
                    sql(1) = New SqlParameter("@PropertyRef", propertyreferences.ToUpper().Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", ""))
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Update_PropertyRefs", sql)

                    Dim totalreferences() As String = propertyreferences.ToUpper().Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", "").Split(" ")
                    For i = 0 To totalreferences.Count - 1
                        If totalreferences(i) <> "" Then
                            Dim sqlpropertyhistory As SqlParameter() = New SqlParameter(5) {}
                            sqlpropertyhistory(0) = New SqlParameter("@Property_Ref", totalreferences(i).ToString())
                            sqlpropertyhistory(1) = New SqlParameter("@Type_Id", 14)
                            Dim Buyer_Surname As String = CBuyer.Surname
                            Dim Buyer_Forename As String = CBuyer.Forename
                            Dim datereceived As String = DateTime.Now.ToString()
                            Dim historytext = "Enquiry received for the property ref  " & totalreferences(i).ToString() & " from client " & Buyer_Surname & " " & Buyer_Forename & " – on the " & datereceived & ""
                            sqlpropertyhistory(2) = New SqlParameter("@History_Text", historytext)
                            sqlpropertyhistory(3) = New SqlParameter("@Modified_By", Convert.ToInt32(Session("ContactID")))
                            sqlpropertyhistory(4) = New SqlParameter("@Buyer_Id", CBuyer.ID)
                            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert", sqlpropertyhistory)
                        End If
                    Next
                End If
                ' Tidy
                CBuyer = Nothing
            End If
        End If
    End Sub
    Public Sub InitData(ByVal CBuyer As ClassBuyer)
        ' Assign to the Form
        TextBoxForename.Text = CBuyer.Forename
        TextBoxSurname.Text = CBuyer.Surname
        TextBoxPassportNo.Text = CBuyer.PassportNumber
        TextBoxAddress.Text = CBuyer.Address
        TextBoxContactName.Text = CBuyer.ContactName
        TextBoxTelephone.Text = CBuyer.Telephone
        TextBoxEmail.Text = CBuyer.Email
        TextBoxNotes.Text = CBuyer.Notes
        lnkBuyerCriteriaURL.NavigateUrl = "../buyer_criterias.aspx?BuyerId=" & Encrypt(CBuyer.ID.ToString())
        Dim isDevORTraining As Int32 = 0
        If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
            lnkBuyerCriteriaURL.Text = "dev.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(CBuyer.ID.ToString())
            isDevORTraining = 1
        End If
        If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
            lnkBuyerCriteriaURL.Text = "training.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(CBuyer.ID.ToString())
            isDevORTraining = 1
        End If
        If isDevORTraining = 0 Then
            lnkBuyerCriteriaURL.Text = "www.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(CBuyer.ID.ToString())
        End If

        ' If the Partner ID is Null
        If CBuyer.PartnerID < 1 Then
            ' Set to this Partner ID
            DropDownListPartner.SelectedValue = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            ' Assign Partner ID
            DropDownListPartner.SelectedValue = CBuyer.PartnerID
        End If
        ' Initiate Update of Agents
        DropDownListPartner_SelectedIndexChanged(Nothing, Nothing)
        ' If we have an Agent ID
        If CBuyer.AgentID > 0 Then
            ' If the Agent Exists in the List   
            If Not DropDownListAgent.Items.FindByValue(CBuyer.AgentID) Is Nothing Then
                ' Load Agent
                DropDownListAgent.SelectedValue = CBuyer.AgentID
            Else
                ' Set to None
                DropDownListAgent.SelectedIndex = 0
            End If
        Else
            ' Init to None
            DropDownListAgent.SelectedIndex = 0
        End If
        ' Continue to Init Vars        
        DropDownListLanguage.SelectedValue = CBuyer.LanguageID
        TextBoxBudget.Text = CBuyer.Budget.ToString.Trim
        ' Init Buyer Status
        If CBuyer.StatusID > 0 Then
            DropDownListStatus.SelectedValue = CBuyer.StatusID
        End If
        If CBuyer.Buyer_Salesperson_ID > 0 Then
            drpUser.SelectedValue = CBuyer.Buyer_Salesperson_ID
            drpUser_SelectedIndexChanged(Nothing, Nothing)
            hdnUser.Value = drpUser.SelectedItem.Text
        Else
            hdnUser.Value = "-- Select --"
        End If
        ' Init Buyer Source
        If CBuyer.SourceID > 0 Then
            DropDownListSource.SelectedValue = CBuyer.SourceID
        End If
        ' Init Archived
        CheckBoxArchived12.Checked = CBuyer.Archived
        If Request.QueryString.Count > 0 Then
            ' Enable / Disable the Form
            EnableForm(((CBuyer.PartnerID = Convert.ToInt32(Session("ContactPartnerID"))) And (Not CBuyer.Archived)) Or Convert.ToBoolean(Session("AdminUser")))
        End If
        ' Display / Hide Save Button
        'ButtonSave.Visible = (CBuyer.PartnerID = Convert.ToInt32(Session("ContactPartnerID")))
        ' Display / Hide Create Tour Button
        ButtonCreateTour.Visible = CBuyer.ID > 0
        Dim CDataAccess As New ClassDataAccess
        If CBuyer.ID > 0 Then

            Dim dt As DataTable = CDataAccess.ClientTourSearch(0, "1/1/1900", "1/1/1900", CBuyer.ID, 0)
            If (dt.Rows.Count > 0) Then
                btntours.Visible = True
                lbltourid.Text = dt.Rows(0)("Reference").ToString()
            Else

            End If
        Else
            btntours.Visible = False
        End If
        btnAction.Visible = CBuyer.ID > 0
        ' Save this
        Session("AdminBuyerSelected") = CBuyer
        ' Clean the Form
        MakeClean()
        ' Tidy
        CBuyer = Nothing
    End Sub
    'Protected Sub DropDownListSource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListSource.SelectedIndexChanged
    '    MakeDirty() 
    'End Sub
    'Protected Sub DropDownListStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListStatus.SelectedIndexChanged
    '    MakeDirty()
    'End Sub
    Protected Sub ButtonCreateTour_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCreateTour.Click

        ' Check to see Session hasn't Expired
        If Not Session("AdminBuyerSelected") Is Nothing Then

            ' Set the Client ID
            Session("AdminCreateTourBuyerID") = DirectCast(Session("AdminBuyerSelected"), ClassBuyer).ID

            ' Raise Event
            '     RaiseEvent CreateTour()
            Response.Redirect("CreateClientTour.aspx")
        End If

    End Sub
    Protected Sub btntours_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntours.Click

        If Not Session("AdminBuyerSelected") Is Nothing Then

            ' Set the Client ID
            Session("AdminCreateTourBuyerID") = DirectCast(Session("AdminBuyerSelected"), ClassBuyer).ID

        End If

        ' Check to see Session hasn't Expired
        Session("ClientTourID") = Convert.ToInt32(lbltourid.Text)

        ' RaiseEvent TourSelected()
        Response.Redirect("Reports.aspx")

    End Sub
    Private Sub EnableForm(ByVal bEnabled As Boolean)

        TextBoxForename.Enabled = bEnabled
        TextBoxSurname.Enabled = bEnabled
        ButtonCreateTour.Enabled = bEnabled
        TextBoxPassportNo.Enabled = bEnabled
        TextBoxAddress.Enabled = bEnabled
        TextBoxContactName.Enabled = bEnabled
        TextBoxTelephone.Enabled = bEnabled
        TextBoxEmail.Enabled = bEnabled
        TextBoxNotes.Enabled = bEnabled
        DropDownListPartner.Enabled = bEnabled
        DropDownListAgent.Enabled = bEnabled
        DropDownListLanguage.Enabled = bEnabled
        TextBoxBudget.Enabled = bEnabled
        DropDownListSource.Enabled = bEnabled
        DropDownListStatus.Enabled = bEnabled

    End Sub
    'Protected Sub CheckBoxArchived12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxArchived12.CheckedChanged
    '    MakeDirty()
    'End Sub
    Private Function CheckForDuplicates() As Boolean

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Update Search Results
        AdminPossibleDuplicates.UpdateMatches(CDataAccess.DuplicateBuyers(TextBoxForename.Text, TextBoxSurname.Text, TextBoxTelephone.Text, TextBoxEmail.Text))

        ' Tidy
        CDataAccess = Nothing

        ' Set Visibility of Results
        TableRowPossibleDuplicates.Visible = AdminPossibleDuplicates.HasSuggestions

        ' If Suggestions
        If AdminPossibleDuplicates.HasSuggestions Then

            ' Change Save Button Text
            ButtonSave.Text = "No, Save"

        End If

        ' Return Result
        Return AdminPossibleDuplicates.HasSuggestions

    End Function
    Protected Sub AdminPossibleDuplicates_DuplicateSelected() Handles AdminPossibleDuplicates.DuplicateSelected

        ' Local Vars
        Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))

        ' Load this Property's Details
        Dim CDataAccess As New ClassDataAccess
        CBuyer.Load(Convert.ToInt32(Session("DuplicateIDSelected")))
        CDataAccess = Nothing

        ' Assign to Session Variable
        Session("AdminBuyerSelected") = CBuyer

        ' Tidy
        Session("DuplicateIDSelected") = Nothing

        ' Raise Event
        'RaiseEvent BuyerSelected()
        'If Not IsPostBack And Not Session("AdminBuyerSelected") Is Nothing Then
        If Not Session("AdminBuyerSelected") Is Nothing Then

            ' Load Previous Buyer
            InitData(DirectCast(Session("AdminBuyerSelected"), ClassBuyer))
        Else
            '   Dim CBuyer1 As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
            '   CBuyer = Nothing
            Dim CBuyer1 As ClassBuyer = New ClassBuyer(Nothing)
            InitData(CBuyer1)

        End If

    End Sub
    Public Sub LawyerMode()

        ' Hide Controls
        LabelBuyer.Visible = False
        ButtonCreateTour.Visible = False
        TableRowSave.Visible = False

        ' Read Only
        ' TableBuyer.Enabled = False

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            btntours.Visible = False
            btnBuyerCriterias.Visible = False
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            bindusers()
            ' Partners
            CUtilities.PopulateDropDownList(DropDownListPartner, CDataAccess.Partners)
            drpUser_SelectedIndexChanged(Nothing, Nothing)
            ' Dim CBuyer As ClassBuyer = New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
            ' Dim CBuyer As ClassBuyer = New ClassBuyer(Nothing)
            CBuyer = DirectCast(Session("AdminBuyerSelected"), ClassBuyer)
            If Not CBuyer Is Nothing Then
                BindHistoryByBuyer()
            End If
            ' Initialising if Necessary
            If Not CBuyer Is Nothing Then
                ' If not a Postback and we have a Buyer
                'If Not IsPostBack And Not Session("AdminBuyerSelected") Is Nothing Then
                If Not Session("AdminBuyerSelected") Is Nothing Then
                    If Request.QueryString.HasKeys() Then
                        ID = Convert.ToInt32(Request.QueryString(0))
                        hdcont.Value = ID
                        hdpageind.Value = Request.QueryString("PageIndex")
                    End If
                    If Not Request.UrlReferrer Is Nothing Then
                        btnBuyerCriterias.Visible = True
                        Dim url As String = Request.UrlReferrer.ToString()
                        Dim uri = New Uri(url)
                        Dim qs = HttpUtility.ParseQueryString(uri.Query)
                        If url.Contains("ClientSearch.aspx") Then
                            qs.[Set]("ID", ID)
                            qs.[Set]("PageIndex", hdpageind.Value)
                            qs.[Set]("Firstname", Request.QueryString("Firstname"))
                            qs.[Set]("lastname", Request.QueryString("lastname"))
                            qs.[Set]("Included", Request.QueryString("Included"))
                            qs.[Set]("Email", Request.QueryString("Email"))
                            qs.[Set]("date", Request.QueryString("date"))
                            qs.[Set]("salesperson", Request.QueryString("salesperson"))
                            qs.[Set]("source", Request.QueryString("source"))
                            qs.[Set]("status", Request.QueryString("status"))
                        End If
                        Dim uriBuilder = New UriBuilder(uri)
                        uriBuilder.Query = qs.ToString()
                        Dim newUri = uriBuilder.Uri
                        hdnprevurl.Value = newUri.ToString()
                    End If
                    ' Load Previous Buyer
                    InitData(DirectCast(Session("AdminBuyerSelected"), ClassBuyer))
                Else
                    '   Dim CBuyer1 As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
                    '   CBuyer = Nothing
                    Dim CBuyer1 As ClassBuyer = New ClassBuyer(Nothing)
                    InitData(CBuyer1)
                End If
            Else
                '  Dim CBuyer1 As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
                Dim CBuyer2 As ClassBuyer = New ClassBuyer(Nothing)
                InitData(CBuyer2)
            End If
        End If
    End Sub
    Private Sub bindusers()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Show_Users_Without_Archived").Tables(0)
        If dt.Rows.Count > 0 Then
            drpUser.DataSource = dt
            drpUser.DataTextField = "Contact_Name"
            drpUser.DataValueField = "Contact_Id"
            drpUser.DataBind()
            Dim licategory1 As New ListItem("-- Select --", "0")
            drpUser.Items.Insert(0, licategory1)
        End If
    End Sub
    Protected Sub drpUser_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Contact_Id", drpUser.SelectedValue)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Contact_getPartnerbyId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListPartner.SelectedValue = dt.Rows(0)("Contact_Partner_Id").ToString()
        End If
    End Sub
    Protected Sub TextBoxEmail_TextChanged(sender As Object, e As EventArgs)
        'Get buyer's details from database if buyer is already exists
        If TextBoxEmail.Text <> "" Then
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@Email", TextBoxEmail.Text)
            Dim dtBuyerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Select_By_Email", sql).Tables(0)
            If dtBuyerDetails.Rows.Count > 0 Then
                lblClient.Text = dtBuyerDetails.Rows(0)("Buyer_Forename") & " " & dtBuyerDetails.Rows(0)("Buyer_Surname")
                lblEmail.Text = dtBuyerDetails.Rows(0)("Buyer_Email")
                lblTelephone.Text = dtBuyerDetails.Rows(0)("Buyer_Telephone")
                lblPartner.Text = dtBuyerDetails.Rows(0)("Partner")
                lblSalesPerson.Text = dtBuyerDetails.Rows(0)("SalesPerson")
                pnlBuyerDetails.Visible = True
            Else
                pnlBuyerDetails.Visible = False
            End If
        Else

        End If
    End Sub
    Protected Sub btnClose_Click(sender As Object, e As EventArgs)
        pnlBuyerDetails.Visible = False
        TextBoxEmail.Text = ""
    End Sub
    Protected Sub btnBuyerCriterias_Click(sender As Object, e As EventArgs)
        Response.Redirect("BuyerCriterias.aspx?BuyerID=" & Request.QueryString("ID").ToString())
    End Sub
    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
End Class
