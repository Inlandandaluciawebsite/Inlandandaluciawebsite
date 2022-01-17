Imports System.IO

Partial Class WebUserControlAdminContact
    Inherits System.Web.UI.UserControl

    Public Event PropertySelected()
    Public Event NewProperty()

    Public Event Message(ByVal szTitle As String, ByVal alMessage As ArrayList, ByVal bBulletPoints As Boolean)

    Public Sub InitData(ByVal CContact As ClassContact)

        ' Save the Contact ID
        LabelContactID.Text = CContact.ID

        ' Hide Rows not relevent to this Contact Type
        Select Case CContact.TypeID

            Case 1

                ' No Broker
                TableRowBroker.Visible = False

                ' Disable Partner Selection
                DropDownListPartner.Enabled = False

            Case 3
                ' Partner
                TableRowBroker.Visible = False
                TableRowPartner.Visible = False

            Case 4
                ' User
                TableRowAdmin.Visible = Convert.ToBoolean(Session("AdminUser"))

            Case 5
                ' Vendor

                ' If we are Loading Details
                If CContact.ID > 0 Then

                    ' Declare Adata Access
                    Dim CDataAccess As New ClassDataAccess

                    ' Load the Properties Owned
                    GridViewProperties.DataSource = CDataAccess.VendorProperties(Convert.ToInt32(Session("ContactPartnerID")), CContact.ID)
                    GridViewProperties.DataBind()

                    ' Hide the ID
                    If Not GridViewProperties.HeaderRow Is Nothing Then
                        GridViewProperties.HeaderRow.Cells(1).Visible = False
                        If Convert.ToInt16(Session("ContactPartnerID")) = 3864 Then
                            GridViewProperties.HeaderRow.Cells(3).Visible = True
                        Else
                            GridViewProperties.HeaderRow.Cells(3).Visible = False

                        End If
                        For Each gvr As GridViewRow In GridViewProperties.Rows
                            gvr.Cells(1).Visible = False
                            If Convert.ToInt16(Session("ContactPartnerID")) = 3864 Then
                                gvr.Cells(3).Visible = True
                            Else
                                gvr.Cells(3).Visible = False

                            End If
                        Next
                    End If

                    ' Tidy
                    CDataAccess = Nothing

                Else

                    ' New - Clear Grid View of Properties Owned
                    GridViewProperties.DataSource = Nothing
                    GridViewProperties.DataBind()

                End If

                ' Hide Login Details and Commission
                TableRowLogin.Visible = False
                TableRowPassword1.Visible = False
                TableRowPassword2.Visible = False
                TableRowCommission.Visible = False

                ' Display Properties Row
                TablePropertyOptions.Visible = (CContact.ID > 0)
                TableRowProperties.Visible = (GridViewProperties.Rows.Count > 0)

                ' Disable Partner Selection
                DropDownListPartner.Enabled = False

            Case 2, 6
                ' Broker, Lawyer
                TableRowBroker.Visible = False

            Case Else
                ' Custom

                ' Load Options
                Dim bImage As Boolean
                Dim CDataAccess As New ClassDataAccess
                CDataAccess.LoadContactTypeOptions(CContact.TypeID,
                                                 TableRowRegistrationNo.Visible,
                                                 TableRowAddress.Visible,
                                                 TableRowTelephone.Visible,
                                                 TableRowMobile.Visible,
                                                 TableRowFax.Visible,
                                                 TableRowEmail.Visible,
                                                 TableRowNotes.Visible,
                                                 TableRowLogin.Visible,
                                                 TableRowLanguage.Visible,
                                                 TableRowPartner.Visible,
                                                 TableRowBroker.Visible,
                                                 bImage,
                                                 TableRowCommission.Visible)
                ' Tidy
                CDataAccess = Nothing

                ' Apply to other Controls
                TableRowPassword1.Visible = TableRowLogin.Visible
                TableRowPassword2.Visible = TableRowLogin.Visible
                TableRowImage.AccessKey = Convert.ToInt32(bImage).ToString.Trim

        End Select

        ' Set the WindowCard Image Label (Agent or Partner)
        If CContact.TypeID = 1 Or CContact.TypeID = 3 Then
            LabelImageTitle.Text = "Window Card Image"
        Else
            LabelImageTitle.Text = "Image"
        End If

        ' Init Image - if it Exists
        If (CContact.ID <> 0) And File.Exists(Server.MapPath("~/images/logos/p" & CContact.ID.ToString.Trim & ".jpg")) Then

            ' Init Image
            ImageContact.ImageUrl = "~/images/logos/p" & CContact.ID.ToString.Trim & ".jpg?nocache=" & Rnd.ToString()

        Else

            ' Set to No Image
            ImageContact.ImageUrl = "~/images/icons/no-photo.png"

        End If

        ' Set Visibility
        TableRowImage.Visible = CContact.ID > 0 And Convert.ToBoolean(Convert.ToInt32(TableRowImage.AccessKey))
        TableRowImageUpload.Visible = TableRowImage.Visible

        ' Assign Form Variables
        DropDownListType.SelectedValue = CContact.TypeID
        TextBoxName.Text = CContact.Name.Trim
        TextBoxRegistrationNo.Text = CContact.RegistrationNumber.Trim
        TextBoxAddress.Text = CContact.Address.Trim
        TextBoxTelephone.Text = CContact.Telephone.Trim
        TextBoxMobile.Text = CContact.Mobile.Trim
        TextBoxFax.Text = CContact.Fax.Trim
        TextBoxEmail.Text = CContact.Email.Trim
        TextBoxNotes.Text = CContact.Notes.Trim
        TextBoxLogin.Text = CContact.Username.Trim
        TextBoxPassword.Attributes.Add("value", CContact.Password.Trim)
        TextBoxConfirmPassword.Attributes.Add("value", CContact.Password.Trim)
        DropDownListLanguage.SelectedValue = CContact.LanguageID

        ' Enable / Disable Add Property / Save Buttons
        ' ButtonSave.Visible = CContact.PartnerID = 0 Or (CContact.PartnerID = Convert.ToInt32(Session("ContactPartnerID"))) Or Convert.ToBoolean(Session("AdminUser"))



        ButtonSave.Visible = True
        ButtonAddProperty.Visible = ButtonSave.Visible And CContact.TypeID = 5 And Not CContact.Archived

        ' Set Table Enabled
        TableContact.Enabled = ButtonSave.Visible

        ' If there is a Partner ID
        If CContact.PartnerID > 0 Then

            ' If this is a Vendor
            If CContact.TypeID = 5 Then

                ' Partner ID stores Broker ID.  Load Partner from Broker.
                Dim CDataAccess As New ClassDataAccess

                ' If we have a Partner ID
                If CDataAccess.PartnerID(CContact.PartnerID) > 0 Then

                    DropDownListPartner.SelectedValue = CDataAccess.PartnerID(CContact.PartnerID)

                End If

                ' Tidy
                CDataAccess = Nothing

                ' Process to Allow update of Brokers
                DropDownListPartner_SelectedIndexChanged(Nothing, Nothing)

                ' If the Broker Exist
                If Not DropDownListBroker.Items.FindByValue(CContact.PartnerID) Is Nothing Then

                    ' Select the Broker
                    DropDownListBroker.SelectedValue = CContact.PartnerID

                End If


            Else

                ' Load Partner
                DropDownListPartner.SelectedValue = CContact.PartnerID

                ' Process to Allow update of Brokers
                DropDownListPartner_SelectedIndexChanged(Nothing, Nothing)

            End If

        Else

            ' No Partner ID - Init to this Partner
            DropDownListPartner.SelectedValue = Convert.ToInt32(Session("ContactPartnerID"))

            ' Update Brokers
            DropDownListPartner_SelectedIndexChanged(Nothing, Nothing)

            ' Enable
            DropDownListPartner.Enabled = True

        End If

        ' Admin can alter Partner
        If Convert.ToBoolean(Session("AdminUser")) Then
            DropDownListPartner.Enabled = True
        End If

        ' Continue to Init Variables
        TextBoxCommission.Text = CContact.Commission.ToString.Trim
        CheckBoxAdmin.Checked = CContact.Administrator
        CheckBoxArchived.Checked = CContact.Archived

        ' Init Label
        LabelContact.Text = String.Empty

        ' If this is a new Contact
        If CContact.ID = 0 Then
            LabelContact.Text = "New "
        Else
            LabelContact.Text = "Edit "
        End If

        ' Set the Contact Type
        LabelContact.Text &= CContact.Type(CContact.TypeID)

        ' Clean the Form
        MakeClean()

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities

        ' Type
        CUtilities.PopulateDropDownList(DropDownListType, CDataAccess.ContactTypes)

        ' Languages
        CUtilities.PopulateDropDownList(DropDownListLanguage, CDataAccess.Languages(Convert.ToInt32(Session("ContactLanguageID"))))

        ' Partners
        CUtilities.PopulateDropDownList(DropDownListPartner, CDataAccess.Partners)

        ' Tidy
        CDataAccess = Nothing
        CUtilities = Nothing

    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' Check we are Still Logged in
        If Session("ContactID") Is Nothing Then

            ' Session Expired
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim alMessage As New ArrayList
            Dim bError As Boolean = False

            ' Pre Validation Checks

            ' Check the Passwords Match
            If TextBoxPassword.Text.Trim <> TextBoxConfirmPassword.Text.Trim Then
                alMessage.Add("The passwords entered do not match")
                bError = True
            End If

            ' If we Encountered Errors
            If bError Then

                ' Raise a Message
                RaiseEvent Message("Unable to Save this Contact", alMessage, True)

            End If

            ' Tidy
            alMessage.Clear()
            alMessage = Nothing

            ' If we didn't Fail Pre Validation Checks
            If Not bError Then

                ' Assign the Form Variables to Current Class Contact
                Dim CContact As ClassContact = DirectCast(Session("AdminContactSelected"), ClassContact)
                CContact.Address = TextBoxAddress.Text.Trim
                CContact.Administrator = CheckBoxAdmin.Checked
                CContact.Archived = CheckBoxArchived.Checked
                CContact.Commission = TextBoxCommission.Text.Trim
                CContact.Email = TextBoxEmail.Text.Trim
                CContact.Fax = TextBoxFax.Text.Trim
                CContact.LanguageID = DropDownListLanguage.SelectedValue
                CContact.Mobile = TextBoxMobile.Text.Trim
                CContact.Name = TextBoxName.Text.Trim
                CContact.Notes = TextBoxNotes.Text.Trim
                CContact.Password = TextBoxPassword.Text.Trim
                CContact.RegistrationNumber = TextBoxRegistrationNo.Text.Trim
                CContact.Telephone = TextBoxTelephone.Text.Trim
                CContact.Username = TextBoxLogin.Text.Trim

                ' If this is a Vendor
                If CContact.TypeID = 5 Then

                    ' Do we have a Broker ID selected?
                    If DropDownListBroker.SelectedIndex > 0 Then

                        ' Save the Broker ID
                        CContact.PartnerID = DropDownListBroker.SelectedValue

                    Else

                        ' Set to Null
                        CContact.PartnerID = 0

                    End If

                Else

                    ' Save the Partner ID
                    CContact.PartnerID = DropDownListPartner.SelectedValue

                End If

                ' Save this Contact to the Database
                bError = CContact.Save()

                ' Reapply Changes
                Session("AdminContactSelected") = CContact

                ' If we had an Error
                If bError Then

                    ' Display an Error Message
                    LabelStatus.Text = "An error occurred whilst saving this Contact"

                Else

                    ' Save the ID
                    LabelContactID.Text = CContact.ID.ToString.Trim

                    ' Display Message
                    LabelStatus.Text = "Contact Saved Successfully"

                    ' Enable the Add Property Button if not Archived and a Vendor
                    TablePropertyOptions.Visible = True
                    ButtonAddProperty.Visible = (Not CContact.Archived And CContact.TypeID = 5)

                    ' Display Image Upload Options
                    TableRowImage.Visible = Convert.ToBoolean(Convert.ToInt32(TableRowImage.AccessKey))
                    TableRowImageUpload.Visible = TableRowImage.Visible

                    ' Clean the Form
                    MakeClean()

                End If

                ' Make the Status Label Visible
                LabelStatus.Visible = True

                ' Tidy
                CContact = Nothing

            End If

        End If

    End Sub

    Protected Sub DropDownListPartner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPartner.SelectedIndexChanged

        ' If we have a Value
        If DropDownListPartner.SelectedValue <> String.Empty Then

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities

            ' Get the Brokers associated with this Partner
            CUtilities.PopulateDropDownList(DropDownListBroker, CDataAccess.Brokers(Convert.ToInt32(DropDownListPartner.SelectedValue)))

            ' Tidy
            CDataAccess = Nothing
            CUtilities = Nothing

            ' Add <None> to Broker
            DropDownListBroker.Items.Insert(0, "--- None ---")

        End If

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub GridViewProperties_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewProperties.SelectedIndexChanged

        ' Local Vars
        Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))

        ' Load this Property's Details
        Dim CDataAccess As New ClassDataAccess
        CProperty.Load(Convert.ToInt32(GridViewProperties.SelectedRow.Cells(1).Text.Trim))
        CDataAccess = Nothing

        ' Assign to Session Variable
        Session("AdminPropertySelected") = CProperty

        ' Raise Event
        RaiseEvent PropertySelected()

    End Sub

    Protected Sub ButtonAddProperty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAddProperty.Click
        RaiseEvent NewProperty()
    End Sub

    Protected Sub ButtonUploadImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUploadImage.Click

        ' If we have a Filename
        If FileUploadImage.HasFile Then

            ' Get the Filename
            Dim szFileName As String = FileUploadImage.FileName

            ' Upload the Document
            FileUploadImage.PostedFile.SaveAs(Server.MapPath("~/images/logos/p" & Convert.ToInt32(LabelContactID.Text.Trim).ToString.Trim & ".jpg"))

            ' Reflect Changes
            ImageContact.ImageUrl = "~/images/logos/p" & Convert.ToInt32(LabelContactID.Text.Trim).ToString.Trim & ".jpg?nocache=" & Rnd.ToString()
            UpdatePanelAdminContact.Update()

        End If

    End Sub

    Private Sub EnableMakeDirty(ByVal bEnable As Boolean)

        ' Add / Remove Event Handlers
        TextBoxName.AutoPostBack = bEnable
        TextBoxRegistrationNo.AutoPostBack = bEnable
        TextBoxAddress.AutoPostBack = bEnable
        TextBoxTelephone.AutoPostBack = bEnable
        TextBoxMobile.AutoPostBack = bEnable
        TextBoxFax.AutoPostBack = bEnable
        TextBoxEmail.AutoPostBack = bEnable
        TextBoxNotes.AutoPostBack = bEnable
        TextBoxLogin.AutoPostBack = bEnable
        TextBoxPassword.AutoPostBack = bEnable
        TextBoxConfirmPassword.AutoPostBack = bEnable
        DropDownListLanguage.AutoPostBack = bEnable
        DropDownListBroker.AutoPostBack = bEnable
        TextBoxCommission.AutoPostBack = bEnable
        CheckBoxAdmin.AutoPostBack = bEnable
        CheckBoxArchived.AutoPostBack = bEnable

    End Sub

    Private Sub MakeDirty()

        ' Local Vars
        Dim bReadOnly As Boolean = False

        ' Hide the Status
        LabelStatus.Visible = False

        ' If Read Only Session Variable Defined
        If Not Session("ContactAdminReadOnly") Is Nothing Then

            ' Set Read Only Flag
            bReadOnly = Convert.ToBoolean(Session("ContactAdminReadOnly"))

        End If

        ' If not Read Only
        If Not bReadOnly Then

            ' Make Form Changes
            ButtonSave.BackColor = Drawing.Color.Red
            ButtonSave.ForeColor = Drawing.Color.White
            ButtonSave.Font.Bold = True

        End If

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

    Protected Sub CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxArchived.CheckedChanged, CheckBoxAdmin.CheckedChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub DropDownListBroker_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListBroker.SelectedIndexChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub DropDownListLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListLanguage.SelectedIndexChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAddress.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxCommission_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxCommission.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxConfirmPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxConfirmPassword.TextChanged

        ' Get the Password
        Dim szPassword As String = TextBoxConfirmPassword.Text

        ' Make Form Dirty
        MakeDirty()

        ' Reset the Password
        TextBoxConfirmPassword.Attributes.Add("value", szPassword)

    End Sub

    Protected Sub TextBoxEmail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxEmail.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxFax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxFax.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxLogin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxLogin.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxMobile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxMobile.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxName.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxNotes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxNotes.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPassword.TextChanged

        ' Get the Password
        Dim szPassword As String = TextBoxPassword.Text

        ' Make Form Dirty
        MakeDirty()

        ' Reset the Password
        TextBoxPassword.Attributes.Add("value", szPassword)

    End Sub

    Protected Sub TextBoxRegistrationNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxRegistrationNo.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Protected Sub TextBoxTelephone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxTelephone.TextChanged

        ' Make Form Dirty
        MakeDirty()

    End Sub

    Public Sub LawyerMode()

        ' Hide Controls
        LabelContact.Visible = False
        TableRowContactType.Visible = False
        TablePropertyOptions.Visible = False
        TableRowImageUpload.Visible = False
        TableRowSave.Visible = False

        ' Read Only
        TableContact.Enabled = False

    End Sub

End Class
