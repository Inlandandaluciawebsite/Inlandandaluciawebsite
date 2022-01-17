Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebUserControlAdminBuyerNew
    Inherits System.Web.UI.UserControl
    Public Event CreateTour()
    Public Event BuyerSelected()
    Dim CBuyer As ClassBuyer
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities

        ' Languages
        CUtilities.PopulateDropDownList(DropDownListLanguage, CDataAccess.Languages(Convert.ToInt32(Session("ContactLanguageID"))))

        ' Partners
        CUtilities.PopulateDropDownList(DropDownListPartner, CDataAccess.Partners)

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
            btnClintHistory.Visible = False
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
        'CheckBoxArchived.AutoPostBack = bEnable

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
                CBuyer.Budget = Convert.ToInt32(TextBoxBudget.Text)
                CBuyer.SourceID = GetFormInteger(DropDownListSource)
                CBuyer.StatusID = GetFormInteger(DropDownListStatus)
                CBuyer.Archived = CheckBoxArchived.Checked
                CBuyer.PartnerID = Convert.ToInt32(DropDownListPartner.SelectedValue)

                ' Save & Assign to the Session Variable
                CBuyer.Save()
                Session("AdminBuyerSelected") = CBuyer

                ' Display / Hide Create Tour Button
                ButtonCreateTour.Visible = CBuyer.ID > 0

                ' Clean the Form
                MakeClean()

                ' Enable Functionality
                EnableForm((CBuyer.PartnerID = Convert.ToInt32(Session("ContactPartnerID"))) And (Not CBuyer.Archived))

                ' Tidy
                CBuyer = Nothing

                ' Display the Message to the User
                TableRowSaved.Visible = True
                btnAction.Visible = True
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

        ' Init Buyer Source
        If CBuyer.SourceID > 0 Then
            DropDownListSource.SelectedValue = CBuyer.SourceID
        End If

        ' Init Archived
        CheckBoxArchived.Checked = CBuyer.Archived

        ' Enable / Disable the Form
        EnableForm(((CBuyer.PartnerID = Convert.ToInt32(Session("ContactPartnerID"))) And (Not CBuyer.Archived)) Or Convert.ToBoolean(Session("AdminUser")))

        ' Display / Hide Save Button
        'ButtonSave.Visible = (CBuyer.PartnerID = Convert.ToInt32(Session("ContactPartnerID")))

        ' Display / Hide Create Tour Button
        ButtonCreateTour.Visible = CBuyer.ID > 0
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
            RaiseEvent CreateTour()

        End If

    End Sub

    Private Sub EnableForm(ByVal bEnabled As Boolean)

        TextBoxForename.Enabled = bEnabled
        TextBoxSurname.Enabled = bEnabled
        '  ButtonCreateTour.Enabled = bEnabled
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

    'Protected Sub CheckBoxArchived_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxArchived.CheckedChanged
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
        RaiseEvent BuyerSelected()

    End Sub

    Public Sub LawyerMode()
        ' Hide Controls
        LabelBuyer.Visible = False
        ButtonCreateTour.Visible = False
        TableRowSave.Visible = False

        ' Read Only
        '  TableBuyer.Enabled = False

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        CBuyer = DirectCast(Session("AdminBuyerSelected"), ClassBuyer)
        If Not CBuyer Is Nothing Then
            BindHistoryByBuyer()
        End If

    End Sub
End Class
