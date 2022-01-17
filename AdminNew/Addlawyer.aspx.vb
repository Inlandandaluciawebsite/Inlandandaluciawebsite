﻿Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO

Partial Class Addlawyer
    Inherits System.Web.UI.Page

    '  Shared id As Int32 = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        TableRowImage.Visible = False
        TableRowImageUpload.Visible = TableRowImage.Visible
        LabelStatus.Text = String.Empty
        If Not IsPostBack Then

            bindtype()
            bindlanguage()
            bindpatner()
            ' drppartner_SelectedIndexChanged(Nothing, Nothing)
            Dim id As Int32 = 0
            If Request.QueryString.HasKeys() Then
                '   bindprop()

                id = Convert.ToInt32(Request.QueryString(0))
                hdnvenid.Value = id
                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@Contact_ID", id)

                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "uSP_vendor_Select_By_Contact_Id", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    btnUpdate.Style.Add(HtmlTextWriterStyle.Display, "block")
                    btnSubmit.Style.Add(HtmlTextWriterStyle.Display, "none")
                    btnCancel.Style.Add(HtmlTextWriterStyle.Display, "none")
                    ' vendorimage.Style.Add(HtmlTextWriterStyle.Display, "block")
                    txtName.Text = Convert.ToString(dt.Rows(0)("Contact_Name"))
                    txtAddress.Text = Convert.ToString(dt.Rows(0)("Contact_Address"))
                    txtRegistrationNo.Text = Convert.ToString(dt.Rows(0)("Contact_Registration_Number"))
                    txtNotes.Text = Convert.ToString(dt.Rows(0)("Contact_Notes"))
                    txtTelephone.Text = Convert.ToString(dt.Rows(0)("Contact_Telephone"))
                    txtFax.Text = Convert.ToString(dt.Rows(0)("Contact_Fax"))
                    txtMobile.Text = Convert.ToString(dt.Rows(0)("Contact_Mobile"))
                    txtEmail.Text = Convert.ToString(dt.Rows(0)("Contact_Email"))
                    chkArchived.Checked = Convert.ToBoolean(dt.Rows(0)("Contact_Archived"))
                    LabelContactID.Text = dt.Rows(0)("Contact_ID").ToString()
                    txtCommission.Text = dt.Rows(0)("Contact_Commission").ToString()

                    txtpassword.Attributes.Add("value", dt.Rows(0)("Contact_Password").ToString())
                    txtconfirmpassword.Attributes.Add("value", dt.Rows(0)("Contact_Password").ToString())
                    txtlogin.Text = dt.Rows(0)("Contact_Login").ToString()
                    TableRowImage.Visible = True
                    TableRowImageUpload.Visible = TableRowImage.Visible
                    If (Convert.ToInt32(dt.Rows(0)("Contact_ID").ToString()) <> 0) And File.Exists(Server.MapPath("~/images/logos/p" & dt.Rows(0)("Contact_ID").ToString().Trim & ".jpg")) Then

                        ' Init Image
                        ImageContact.ImageUrl = "~/images/logos/p" & dt.Rows(0)("Contact_ID").ToString().Trim & ".jpg?nocache=" & Rnd.ToString()
                        lblimg.Text = "~/images/logos/p" & dt.Rows(0)("Contact_ID").ToString().Trim & ".jpg"
                    Else

                        ' Set to No Image
                        ImageContact.ImageUrl = "~/images/icons/no-photo.png"

                    End If
                    ' Partner ID stores Broker ID.  Load Partner from Broker.
                    Dim CDataAccess As New ClassDataAccess

                    ' If we have a Partner ID
                    'If CDataAccess.PartnerID(dt.Rows(0)("Contact_Partner_ID").ToString()) > 0 Then

                    '    chklstPartner.SelectedValue = CDataAccess.PartnerID(dt.Rows(0)("Contact_Partner_ID").ToString())

                    'End If

                    ' Tidy
                    CDataAccess = Nothing


                    'Get all partners from contact_partner_id from contact table, even if there is only one partner OR multiple partners

                    Dim sqlBrokerPartner As SqlParameter() = New SqlParameter(1) {}
                    sqlBrokerPartner(0) = New SqlParameter("@Contact_ID", id)
                    sqlBrokerPartner(1) = New SqlParameter("@Contact_Type_Id", 2)

                    Dim dtBrokerPartner As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Partner_By_ContactId_Email_V2", sqlBrokerPartner).Tables(0)

                    If dtBrokerPartner.Rows.Count > 0 Then

                        For nbrokerPartnerIndex = 0 To dtBrokerPartner.Rows.Count - 1

                            chklstPartner.Items.FindByValue(dtBrokerPartner.Rows(nbrokerPartnerIndex)("Contact_Partner_Id").ToString()).Selected = True
                            If dtBrokerPartner.Rows(nbrokerPartnerIndex)("IsMainContact").ToString() = "True" Then
                                drpMainContact.Items.FindByValue(dtBrokerPartner.Rows(nbrokerPartnerIndex)("Contact_Partner_Id").ToString()).Selected = True
                            End If
                        Next

                    End If

                    ' Process to Allow update of Brokers
                    '  drppartner_SelectedIndexChanged(Nothing, Nothing)

                    ' If the Broker Exist






                    ' drppartner.Items(drppartner.Items.IndexOf(drppartner.Items.FindByValue(dt.Rows(0)("Contact_Partner_ID").ToString()))).Selected = True
                    'If Not drpbroker.Items.FindByValue(dt.Rows(0)("Contact_Partner_ID")) Is Nothing Then
                    '    ' Select the Broker
                    '    drpbroker.SelectedValue = dt.Rows(0)("Contact_Partner_ID")

                    'End If

                    drpspoken.Items(drpspoken.Items.IndexOf(drpspoken.Items.FindByValue(dt.Rows(0)("Contact_Language_ID").ToString()))).Selected = True


                    drpType.Items(drpType.Items.IndexOf(drpType.Items.FindByValue(dt.Rows(0)("Contact_Type_ID").ToString()))).Selected = True
                End If
            End If
        End If

    End Sub

    Private Sub bindlanguage()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@ContactId", Convert.ToInt32(Session("ContactLanguageID")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Contact_Languages_ShowbyContactId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            drpspoken.DataSource = dt
            drpspoken.DataTextField = "text"
            drpspoken.DataValueField = "id"
            drpspoken.DataBind()
        End If
    End Sub
    Protected Sub btnuploadimage_Click(sender As Object, e As EventArgs)
        TableRowImage.Visible = True
        TableRowImageUpload.Visible = TableRowImage.Visible
        btnSubmit.BackColor = Drawing.Color.Red
        ' If we have a Filename
        If FileUploadImage.HasFile Then

            ' Get the Filename
            Dim szFileName As String = FileUploadImage.FileName

            ' Upload the Document
            FileUploadImage.PostedFile.SaveAs(Server.MapPath("~/images/logos/p" & Convert.ToInt32(LabelContactID.Text.Trim).ToString.Trim & ".jpg"))

            ' Reflect Changes
            ImageContact.ImageUrl = "~/images/logos/p" & Convert.ToInt32(LabelContactID.Text.Trim).ToString.Trim & ".jpg?nocache=" & Rnd.ToString()
            lblimg.Text = "~/images/logos/p" & Convert.ToInt32(LabelContactID.Text.Trim).ToString.Trim & ".jpg"
            '  upAddAdmin.Update()

        End If

    End Sub
    Private Sub bindpatner()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Pertner_show").Tables(0)
        If dt.Rows.Count > 0 Then
            chklstPartner.DataSource = dt
            chklstPartner.DataTextField = "text"
            chklstPartner.DataValueField = "id"
            chklstPartner.DataBind()

            drpMainContact.DataSource = dt
            drpMainContact.DataTextField = "text"
            drpMainContact.DataValueField = "id"
            drpMainContact.DataBind()
        End If
    End Sub

    Private Sub bindtype()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_CONTACT_TYPE_SHOW").Tables(0)
        If dt.Rows.Count > 0 Then
            drpType.DataSource = dt
            drpType.DataTextField = "Contact_Type"
            drpType.DataValueField = "Contact_Type_ID"
            drpType.SelectedValue = 2
            drpType.DataBind()

        End If
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim isSelected As Boolean = False
        Dim firstContactId As Int16 = 0
        If lblEmailMessage.ForeColor <> System.Drawing.Color.Red Then

            For nPartnerIndex = 0 To chklstPartner.Items.Count - 1
                Dim listitemmaincontact As ListItem
                listitemmaincontact = chklstPartner.Items.FindByText(drpMainContact.SelectedItem.Text)
                If listitemmaincontact.Selected = False Then
                    LabelStatus.Text = "Selected Main Contact is not in Partners Checkbox List so please change Main Contact !"
                    drpMainContact.ForeColor = Drawing.Color.Red
                    LabelStatus.ForeColor = Drawing.Color.Red
                    Return
                End If

                If chklstPartner.Items(nPartnerIndex).Selected Then
                    isSelected = True
                    Dim sql As SqlParameter() = New SqlParameter(16) {}
                    sql(0) = New SqlParameter("@Contact_Type_ID", Convert.ToInt32(drpType.SelectedValue))
                    sql(1) = New SqlParameter("@Contact_Name", txtName.Text)
                    sql(2) = New SqlParameter("@Contact_Registration_Number", txtRegistrationNo.Text)
                    sql(3) = New SqlParameter("@Contact_Address", txtAddress.Text)
                    sql(4) = New SqlParameter("@Contact_Telephone", txtTelephone.Text)
                    sql(5) = New SqlParameter("@Contact_Mobile", txtMobile.Text)
                    sql(6) = New SqlParameter("@Contact_Fax", txtFax.Text)
                    sql(7) = New SqlParameter("@Contact_Email", txtEmail.Text)
                    sql(8) = New SqlParameter("@Contact_Notes", txtNotes.Text)
                    sql(9) = New SqlParameter("@Contact_Language_ID", Convert.ToInt32(drpspoken.SelectedValue))
                    sql(10) = New SqlParameter("@Contact_Partner_ID", Convert.ToInt32(chklstPartner.Items(nPartnerIndex).Value))
                    sql(11) = New SqlParameter("@Contact_Archived", chkArchived.Checked)
                    sql(12) = New SqlParameter("@Contact_Login", txtlogin.Text)
                    sql(13) = New SqlParameter("@Contact_Password", txtpassword.Text)
                    sql(14) = New SqlParameter("@Contact_Commission", txtCommission.Text)

                    If chklstPartner.Items(nPartnerIndex).Text = drpMainContact.SelectedItem.Text Then
                        sql(15) = New SqlParameter("@IsMainContact", True)
                    Else
                        sql(15) = New SqlParameter("@IsMainContact", False)
                    End If


                    Dim ContactId As Integer = Convert.ToInt32(SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Insert_Agent", sql).Tables(0).Rows(0)("ContactId").ToString())
                    If firstContactId = 0 Then
                        firstContactId = ContactId
                    End If
                    '  Response.Redirect("ManageAgents.aspx")
                    LabelStatus.Text = "Contact Saved Successfully"
                    drpMainContact.ForeColor = Drawing.Color.Black
                    LabelStatus.ForeColor = Drawing.Color.Black
                    LabelContactID.Text = ContactId
                    ' Enable the Add Property Button if not Archived and a Vendor
                    '  TablePropertyOptions.Visible = True
                    '  ButtonAddProperty.Visible = (Not CContact.Archived And CContact.TypeID = 5)

                    ' Display Image Upload Options
                    btnUpdate.Style.Add(HtmlTextWriterStyle.Display, "block")
                    btnSubmit.Style.Add(HtmlTextWriterStyle.Display, "none")
                    If ImageContact.ImageUrl = "" Then
                        ImageContact.ImageUrl = "~/images/icons/no-photo.png"
                    End If

                    TableRowImage.Visible = True
                    TableRowImageUpload.Visible = TableRowImage.Visible
                End If
            Next
            If firstContactId <> 0 Then
                Response.Redirect("AddLawyer.aspx?ContactId=" & firstContactId & "&ContactSaved=Yes")
            End If
        End If
        If isSelected = False Then
            LabelStatus.Text = "Please select/link atleast one partner !"
            drpMainContact.ForeColor = Drawing.Color.Red
            LabelStatus.ForeColor = Drawing.Color.Red
        End If
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim id As Int32 = Convert.ToInt32(Request.QueryString(0))
        For nPartnerIndex = 0 To chklstPartner.Items.Count - 1
            Dim listitemmaincontact As ListItem
            listitemmaincontact = chklstPartner.Items.FindByText(drpMainContact.SelectedItem.Text)
            If listitemmaincontact.Selected = False Then
                LabelStatus.Text = "Selected Main Contact is not in Partners Checkbox List so please change Main Contact !"
                drpMainContact.ForeColor = Drawing.Color.Red
                LabelStatus.ForeColor = Drawing.Color.Red
                Return
            End If
            If chklstPartner.Items(nPartnerIndex).Selected Then
                'Check here if partner id against contact id is exists or not, if exists then just update otherwise if any additional partner then insert
                Dim sqlCheckPartnerExists As SqlParameter() = New SqlParameter(2) {}
                sqlCheckPartnerExists(0) = New SqlParameter("@Contact_Email", txtEmail.Text)
                sqlCheckPartnerExists(1) = New SqlParameter("@Contact_Partner_Id", Convert.ToInt32(chklstPartner.Items(nPartnerIndex).Value))
                sqlCheckPartnerExists(2) = New SqlParameter("@Contact_Type_Id", Convert.ToInt32(drpType.SelectedValue))
                Dim dsCheckPartnerExists As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Partner_Exists_By_Email", sqlCheckPartnerExists).Tables(0)
                If dsCheckPartnerExists.Rows.Count > 0 Then
                    id = Convert.ToInt32(dsCheckPartnerExists.Rows(0)("Contact_Id").ToString())
                    Dim sql As SqlParameter() = New SqlParameter(17) {}
                    sql(0) = New SqlParameter("@Contact_Type_ID", Convert.ToInt32(drpType.SelectedValue))
                    sql(1) = New SqlParameter("@Contact_Name", txtName.Text)
                    sql(2) = New SqlParameter("@Contact_Registration_Number", txtRegistrationNo.Text)
                    sql(3) = New SqlParameter("@Contact_Address", txtAddress.Text)
                    sql(4) = New SqlParameter("@Contact_Telephone", txtTelephone.Text)
                    sql(5) = New SqlParameter("@Contact_Mobile", txtMobile.Text)
                    sql(6) = New SqlParameter("@Contact_Fax", txtFax.Text)
                    sql(7) = New SqlParameter("@Contact_Email", txtEmail.Text)
                    sql(8) = New SqlParameter("@Contact_Notes", txtNotes.Text)
                    sql(9) = New SqlParameter("@Contact_Language_ID", Convert.ToInt32(drpspoken.SelectedValue))
                    sql(10) = New SqlParameter("@Contact_Partner_ID", Convert.ToInt32(chklstPartner.Items(nPartnerIndex).Value))
                    sql(11) = New SqlParameter("@Contact_Archived", chkArchived.Checked)
                    sql(12) = New SqlParameter("@Contact_ID", id)
                    sql(13) = New SqlParameter("@Contact_Login", txtlogin.Text)
                    sql(14) = New SqlParameter("@Contact_Password", txtpassword.Text)
                    sql(15) = New SqlParameter("@Contact_Commission", txtCommission.Text)
                    If drpMainContact.SelectedItem.Text = chklstPartner.Items(nPartnerIndex).Text Then
                        sql(16) = New SqlParameter("@IsMainContact", True)
                    Else
                        sql(16) = New SqlParameter("@IsMainContact", False)
                    End If
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Update_Agent", sql).ToString()
                Else
                    Dim sql As SqlParameter() = New SqlParameter(16) {}
                    sql(0) = New SqlParameter("@Contact_Type_ID", Convert.ToInt32(drpType.SelectedValue))
                    sql(1) = New SqlParameter("@Contact_Name", txtName.Text)
                    sql(2) = New SqlParameter("@Contact_Registration_Number", txtRegistrationNo.Text)
                    sql(3) = New SqlParameter("@Contact_Address", txtAddress.Text)
                    sql(4) = New SqlParameter("@Contact_Telephone", txtTelephone.Text)
                    sql(5) = New SqlParameter("@Contact_Mobile", txtMobile.Text)
                    sql(6) = New SqlParameter("@Contact_Fax", txtFax.Text)
                    sql(7) = New SqlParameter("@Contact_Email", txtEmail.Text)
                    sql(8) = New SqlParameter("@Contact_Notes", txtNotes.Text)
                    sql(9) = New SqlParameter("@Contact_Language_ID", Convert.ToInt32(drpspoken.SelectedValue))
                    sql(10) = New SqlParameter("@Contact_Partner_ID", Convert.ToInt32(chklstPartner.Items(nPartnerIndex).Value))
                    sql(11) = New SqlParameter("@Contact_Archived", chkArchived.Checked)
                    sql(12) = New SqlParameter("@Contact_Login", txtlogin.Text)
                    sql(13) = New SqlParameter("@Contact_Password", txtpassword.Text)
                    sql(14) = New SqlParameter("@Contact_Commission", txtCommission.Text)
                    If drpMainContact.SelectedItem.Text = chklstPartner.Items(nPartnerIndex).Text Then
                        sql(15) = New SqlParameter("@IsMainContact", True)
                    Else
                        sql(15) = New SqlParameter("@IsMainContact", False)
                    End If
                    Dim ContactId As Integer = Convert.ToInt32(SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Insert_Agent", sql).Tables(0).Rows(0)("ContactId").ToString())
                End If
                ' Response.Redirect("ManageAgents.aspx")
                LabelStatus.Text = "Contact Saved Successfully"
                drpMainContact.ForeColor = Drawing.Color.Black
                LabelStatus.ForeColor = Drawing.Color.Black
                If ImageContact.ImageUrl = "" Then
                    ImageContact.ImageUrl = "~/images/icons/no-photo.png"
                End If
                TableRowImage.Visible = True
                TableRowImageUpload.Visible = TableRowImage.Visible
                ' End If
            Else
                'if partner not selected and exists then just remove from database
                Dim sqlCheckPartnerExists As SqlParameter() = New SqlParameter(2) {}
                sqlCheckPartnerExists(0) = New SqlParameter("@Contact_Email", txtEmail.Text)
                sqlCheckPartnerExists(1) = New SqlParameter("@Contact_Partner_Id", Convert.ToInt32(chklstPartner.Items(nPartnerIndex).Value))
                sqlCheckPartnerExists(2) = New SqlParameter("@Contact_Type_Id", Convert.ToInt32(drpType.SelectedValue))
                Dim dsCheckPartnerExists As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Partner_Exists_By_Email", sqlCheckPartnerExists).Tables(0)
                If dsCheckPartnerExists.Rows.Count > 0 Then
                    id = Convert.ToInt32(dsCheckPartnerExists.Rows(0)("Contact_Id").ToString())
                    Dim sql As SqlParameter() = New SqlParameter(17) {}
                    sql(0) = New SqlParameter("@Contact_Type_ID", Convert.ToInt32(drpType.SelectedValue))
                    sql(1) = New SqlParameter("@Contact_Name", txtName.Text)
                    sql(2) = New SqlParameter("@Contact_Registration_Number", txtRegistrationNo.Text)
                    sql(3) = New SqlParameter("@Contact_Address", txtAddress.Text)
                    sql(4) = New SqlParameter("@Contact_Telephone", txtTelephone.Text)
                    sql(5) = New SqlParameter("@Contact_Mobile", txtMobile.Text)
                    sql(6) = New SqlParameter("@Contact_Fax", txtFax.Text)
                    sql(7) = New SqlParameter("@Contact_Email", txtEmail.Text)
                    sql(8) = New SqlParameter("@Contact_Notes", txtNotes.Text)
                    sql(9) = New SqlParameter("@Contact_Language_ID", Convert.ToInt32(drpspoken.SelectedValue))
                    sql(10) = New SqlParameter("@Contact_Partner_ID", Convert.ToInt32(chklstPartner.Items(nPartnerIndex).Value))
                    sql(11) = New SqlParameter("@Contact_Archived", True)
                    sql(12) = New SqlParameter("@Contact_ID", id)
                    sql(13) = New SqlParameter("@Contact_Login", txtlogin.Text)
                    sql(14) = New SqlParameter("@Contact_Password", txtpassword.Text)
                    sql(15) = New SqlParameter("@Contact_Commission", txtCommission.Text)
                    If drpMainContact.SelectedItem.Text = chklstPartner.Items(nPartnerIndex).Text Then
                        sql(16) = New SqlParameter("@IsMainContact", True)
                    Else
                        sql(16) = New SqlParameter("@IsMainContact", False)
                    End If
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Update_Agent", sql).ToString()
                End If
            End If
        Next
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("Addlawyer.aspx")
    End Sub

    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================

    Protected Sub btnimageprop_Click(sender As Object, e As EventArgs)

    End Sub
End Class
