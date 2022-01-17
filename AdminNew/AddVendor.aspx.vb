Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports inland_api
Imports System.Net
Imports System.Web.Script.Serialization

Partial Class Admin_AddVendor
    Inherits System.Web.UI.Page

    'Shared id As Int32 = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            bindtype()
            bindlanguage()
            bindpatner()
            If Convert.ToBoolean(Session("AdminUser")) = False Then
                drppartner.Enabled = False
            End If
            If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
                drppartner.SelectedValue = Convert.ToInt32(Session("ContactPartnerID"))
            Else
                drppartner.SelectedValue = Convert.ToInt32(Session("ContactID"))
            End If
            Dim id As Int32 = 0
            If Request.QueryString.HasKeys() Then
                id = Convert.ToInt32(Request.QueryString(0))
                hdnvenid.Value = id
                hdpageind.Value = Request.QueryString("PageIndex")
                Dim url As String = ""
                If Not String.IsNullOrEmpty(Convert.ToString(Request.UrlReferrer)) Then
                    url = Request.UrlReferrer.ToString()
                    Dim uri = New Uri(url)
                    Dim qs = HttpUtility.ParseQueryString(uri.Query)
                    qs.[Set]("ID", id)
                    If url.Contains("ManageVendors.aspx") Then
                        qs.[Set]("PageIndex", hdpageind.Value)
                        qs.[Set]("Name", Request.QueryString("Name"))
                        qs.[Set]("propref", Request.QueryString("propref"))
                        qs.[Set]("Included", Request.QueryString("Included"))
                    End If
                    Dim uriBuilder = New UriBuilder(uri)
                    uriBuilder.Query = qs.ToString()
                    Dim newUri = uriBuilder.Uri
                    hdnprevurl.Value = newUri.ToString()
                End If
                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@Contact_ID", id)
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "uSP_vendor_Select_By_Contact_Id", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    btnUpdate.Style.Add(HtmlTextWriterStyle.Display, "block")
                    btnSubmit.Style.Add(HtmlTextWriterStyle.Display, "none")
                    btnCancel.Style.Add(HtmlTextWriterStyle.Display, "none")
                    vendorimage.Style.Add(HtmlTextWriterStyle.Display, "block")
                    prop.Style.Add(HtmlTextWriterStyle.Display, "block")
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
                    If Not Convert.ToString(dt.Rows(0)("Contact_Partner_IDNew")) = "" Then
                        'If CDataAccess.PartnerID(dt.Rows(0)("Contact_Partner_IDNew")) > 0 Then
                        If dt.Rows(0)("Contact_Partner_IDNew") > 0 Then
                            'drppartner.SelectedValue = CDataAccess.PartnerID(dt.Rows(0)("Contact_Partner_IDNew").ToString())
                            drppartner.SelectedValue = dt.Rows(0)("Contact_Partner_IDNew").ToString()
                        End If
                    End If
                    ' Tidy
                    CDataAccess = Nothing
                    '' Process to Allow update of Brokers
                    drppartner_SelectedIndexChanged(Nothing, Nothing)
                    ' If the Broker Exist
                    If Not drpbroker.Items.FindByValue(dt.Rows(0)("Contact_Partner_ID").ToString()) Is Nothing Then
                        ' Select the Broker
                        drpbroker.SelectedValue = dt.Rows(0)("Contact_Partner_ID").ToString()
                    End If
                    'drppartner.Items(drppartner.Items.IndexOf(drppartner.Items.FindByValue(dt.Rows(0)("Contact_Partner_ID").ToString()))).Selected = True
                    If Not drpbroker.Items.FindByValue(dt.Rows(0)("Contact_Partner_ID")) Is Nothing Then
                        ' Select the Broker
                        drpbroker.SelectedValue = dt.Rows(0)("Contact_Partner_ID")
                    End If
                    drpspoken.Items(drpspoken.Items.IndexOf(drpspoken.Items.FindByValue(dt.Rows(0)("Contact_Language_ID").ToString()))).Selected = True
                    drpType.Items(drpType.Items.IndexOf(drpType.Items.FindByValue(dt.Rows(0)("Contact_Type_ID").ToString()))).Selected = True
                    'Bind agents by partner id 
                    BindPartnerAgents(Convert.ToInt32(drppartner.SelectedValue))
                    Try
                        drpPartnerAgent.Items(drpPartnerAgent.Items.IndexOf(drpPartnerAgent.Items.FindByValue(dt.Rows(0)("Contact_Agent_Id").ToString()))).Selected = True
                    Catch ex As Exception
                        Dim liPartnerAgent As New ListItem("--None--", "0")
                        drpPartnerAgent.Items.Insert(0, liPartnerAgent)
                    End Try

                    bindprop()
                End If
            Else
                lblBrokerMessage.Visible = True
                lblbroker.Visible = True
                'Bind agents by partner id 
                BindPartnerAgents(Convert.ToInt32(drppartner.SelectedValue))
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
    Private Sub bindpatner()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Pertner_show").Tables(0)
        If dt.Rows.Count > 0 Then
            drppartner.DataSource = dt
            drppartner.DataTextField = "text"
            drppartner.DataValueField = "id"
            drppartner.DataBind()
            'bindbroker()
        End If
    End Sub
    Private Sub bindtype()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_CONTACT_TYPE_SHOW").Tables(0)
        If dt.Rows.Count > 0 Then
            drpType.DataSource = dt
            drpType.DataTextField = "Contact_Type"
            drpType.DataValueField = "Contact_Type_ID"
            drpType.SelectedValue = 5
            drpType.DataBind()
        End If
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim sql As SqlParameter() = New SqlParameter(12) {}
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
        If drppartner.SelectedValue <> "" Then
            sql(10) = New SqlParameter("@Contact_Partner_ID", Convert.ToInt32(drppartner.SelectedValue))
        Else
            sql(10) = New SqlParameter("@Contact_Partner_ID", 0)
        End If
        sql(11) = New SqlParameter("@Contact_Archived", chkArchived.Checked)
        sql(12) = New SqlParameter("@Contact_Agent_Id", Convert.ToInt32(drpPartnerAgent.SelectedValue))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Insert_Vender", sql).Tables(0)
        ''Call Inland API function after create new agent/vendor
        'Try
        '    Dim createPropertyReturnJason As String
        '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/agentvendor/create/" & dt.Rows(0)(0).ToString() & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
        '    httpRequest.ContentType = "application/json"
        '    httpRequest.Method = "GET"
        '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
        '        Using stream As Stream = httpResponse.GetResponseStream()
        '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
        '            createPropertyReturnJason = json
        '        End Using
        '    End Using
        '    Dim sqlAPI As SqlParameter() = New SqlParameter(5) {}
        '    sqlAPI(0) = New SqlParameter("@Title", "Vendor")
        '    sqlAPI(1) = New SqlParameter("@ActionType", "Create")
        '    sqlAPI(2) = New SqlParameter("@JasonString", createPropertyReturnJason)
        '    sqlAPI(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
        '    sqlAPI(4) = New SqlParameter("@Property_Id", Convert.ToInt32(dt.Rows(0)(0).ToString()))
        '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sqlAPI)
        'Catch ex As Exception
        '    Dim sqlAPI As SqlParameter() = New SqlParameter(5) {}
        '    sqlAPI(0) = New SqlParameter("@Title", "Vendor")
        '    sqlAPI(1) = New SqlParameter("@ActionType", "Create")
        '    sqlAPI(2) = New SqlParameter("@JasonString", ex.Message.ToString())
        '    sqlAPI(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
        '    sqlAPI(4) = New SqlParameter("@Property_Id", Convert.ToInt32(dt.Rows(0)(0).ToString()))
        '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sqlAPI)
        'End Try
        Response.Redirect("Property_General.aspx?VId=" & dt.Rows(0)(0).ToString())
        'lblMessage.Text = "Vendor added successfully !"
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim id As Int32 = Convert.ToInt32(Request.QueryString(0))
        Dim sql As SqlParameter() = New SqlParameter(13) {}
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
        If drppartner.SelectedValue <> "" Then
            sql(10) = New SqlParameter("@Contact_Partner_ID", Convert.ToInt32(drppartner.SelectedValue))
        Else
            sql(10) = New SqlParameter("@Contact_Partner_ID", 0)
        End If
        sql(11) = New SqlParameter("@Contact_Archived", chkArchived.Checked)
        sql(12) = New SqlParameter("@Contact_ID", id)
        sql(13) = New SqlParameter("@Contact_Agent_Id", Convert.ToInt32(drpPartnerAgent.SelectedValue))
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Update_Vender", sql).ToString()

        'Update property's broker by selecting current selected broker from broker dropdown list
        If drpbroker.Items.Count > 0 Then
            If drpbroker.SelectedValue <> 0 Then
                For i = 0 To grdAdmin.Rows.Count - 1
                    Try
                        Dim lblPropertyRef As Label = DirectCast(grdAdmin.Rows(i).FindControl("lblPropertyReference"), Label)
                        Dim sqlBroker As SqlParameter() = New SqlParameter(2) {}
                        sqlBroker(0) = New SqlParameter("@PropertyRef", lblPropertyRef.Text)
                        sqlBroker(1) = New SqlParameter("@BrokerId", Convert.ToInt32(drpbroker.SelectedValue))
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Update_Broker_By_PropertyRef", sqlBroker)
                    Catch ex As Exception

                    End Try
                Next
            Else
                For i = 0 To grdAdmin.Rows.Count - 1
                    Try
                        Dim lblPropertyRef As Label = DirectCast(grdAdmin.Rows(i).FindControl("lblPropertyReference"), Label)
                        Dim sqlBroker As SqlParameter() = New SqlParameter(2) {}
                        sqlBroker(0) = New SqlParameter("@PropertyRef", lblPropertyRef.Text)
                        sqlBroker(1) = New SqlParameter("@BrokerId", 0)
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Update_Broker_By_PropertyRef", sqlBroker)
                    Catch ex As Exception

                    End Try
                Next
                lblBrokerName.Text = ""
                lblbroker.Visible = False
            End If
        End If

        'Call Inland API function after update new agent/vendor
        'Try
        '    Dim updatePropertyReturnJason As String
        '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/agentvendor/update/" & id & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
        '    httpRequest.ContentType = "application/json"
        '    httpRequest.Method = "GET"
        '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
        '        Using stream As Stream = httpResponse.GetResponseStream()
        '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
        '            updatePropertyReturnJason = json
        '        End Using
        '    End Using
        '    Dim sqlAPI As SqlParameter() = New SqlParameter(5) {}
        '    sqlAPI(0) = New SqlParameter("@Title", "Vendor")
        '    sqlAPI(1) = New SqlParameter("@ActionType", "Update")
        '    sqlAPI(2) = New SqlParameter("@JasonString", updatePropertyReturnJason)
        '    sqlAPI(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
        '    sqlAPI(4) = New SqlParameter("@Property_Id", id)
        '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sqlAPI)
        'Catch ex As Exception
        '    Dim sqlAPI As SqlParameter() = New SqlParameter(5) {}
        '    sqlAPI(0) = New SqlParameter("@Title", "Vendor")
        '    sqlAPI(1) = New SqlParameter("@ActionType", "Update")
        '    sqlAPI(2) = New SqlParameter("@JasonString", ex.Message.ToString())
        '    sqlAPI(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
        '    sqlAPI(4) = New SqlParameter("@Property_Id", id)
        '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
        'End Try
        'Response.Redirect("ManageVendors.aspx")
        lblMessage.Text = "Vendor updated successfully !"
        bindprop()
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("AddVendor.aspx")
    End Sub
    Protected Sub drppartner_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If drpbroker.Visible = True Then
        bindbroker()
        BindPartnerAgents(Convert.ToInt32(drppartner.SelectedValue))
        'End If
    End Sub
    Private Sub bindbroker()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@PartnerId", Convert.ToInt32(drppartner.SelectedValue))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Contact_Broker_By_PartnerId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            drpbroker.DataSource = dt
            drpbroker.DataTextField = "text"
            drpbroker.DataValueField = "id"
            drpbroker.DataBind()
            Dim licategory As New ListItem("-- None--", "0")
            drpbroker.Items.Insert(0, licategory)
        Else
            drpbroker.Items.Clear()
        End If
    End Sub
    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================
    Protected Sub btnuploadimage_Click(sender As Object, e As EventArgs)
        ' If we have a Filename
        If FileUploadImage.HasFile Then

            ' Get the Filename
            Dim szFileName As String = FileUploadImage.FileName

            ' Upload the Document
            'Dim fi As FileInfo = New FileInfo(Server.MapPath(lblimg.Text))
            'If fi.Exists Then
            '    fi.Delete()
            'End If
            FileUploadImage.PostedFile.SaveAs(Server.MapPath("~/images/logos/p" & Convert.ToInt32(LabelContactID.Text.Trim).ToString.Trim & ".jpg"))

            ' Reflect Changes

            ImageContact.ImageUrl = "~/images/logos/p" & Convert.ToInt32(LabelContactID.Text.Trim).ToString.Trim & ".jpg?nocache=" & Rnd.ToString()
            lblimg.Text = "~/images/logos/p" & Convert.ToInt32(LabelContactID.Text.Trim).ToString.Trim & ".jpg"
        End If
    End Sub
    Private Sub bindprop()
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@VendorId", Request.QueryString("ContactId").ToString())
        sql(1) = New SqlParameter("@nPartnerID", Convert.ToInt32(Session("ContactPartnerID")))

        Dim CDataAccess As New ClassDataAccess
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Vendor_Properties", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            lblbroker.Visible = True
            drpbroker.Visible = True
            lblPleaseChooseMessage.Visible = True
            'Here i am setting broker dropdown value as per latest discussion
            'getting first available broker & showing in dropdown

            Dim brokerSet As Boolean = False
            For i = 0 To grdAdmin.Rows.Count - 1
                Try
                    If dt.Rows(i)("Broker_ID").ToString() <> "" And brokerSet = False And dt.Rows(i)("Broker_ID") <> "0" Then
                        brokerSet = True
                        drpbroker.SelectedValue = dt.Rows(i)("Broker_ID").ToString()
                        lblBrokerName.Visible = True
                        lblBrokerName.Text = "Current Broker : " & dt.Rows(i)("Broker").ToString()
                    End If
                Catch ex As Exception

                End Try
            Next
        Else
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            lblBrokerMessage.Visible = True
            'lblmessage.Visible = True
        End If
    End Sub
    Protected Sub grdAdmin_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdAdmin.PageIndex = e.NewPageIndex
        bindprop()
    End Sub
    Protected Sub grdAdmin_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editadmin" Then
            Response.Redirect("Property_General.aspx?PropertyId=" + e.CommandArgument.ToString())
        End If
    End Sub
    Protected Sub btnimageprop_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_General.aspx?VId=" + hdnvenid.Value)
    End Sub
    Protected Sub grdAdmin_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblIsIssue As Label = DirectCast(e.Row.FindControl("lblisissue"), Label)
            If lblIsIssue.Text = "Red" Then
                e.Row.BackColor = System.Drawing.Color.Red
            End If
        End If
    End Sub
    Public Sub BindPartnerAgents(ByVal Partner_Id As Int32)
        Dim sqlPartnerAgent As SqlParameter() = New SqlParameter(1) {}
        sqlPartnerAgent(0) = New SqlParameter("@Contact_Partner_Id", Partner_Id)
        drpPartnerAgent.Items.Clear()
        Dim dtPartnerAgent As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Select_Agent_By_Partner_Id", sqlPartnerAgent).Tables(0)
        If dtPartnerAgent.Rows.Count > 0 Then
            drpPartnerAgent.DataSource = dtPartnerAgent
            drpPartnerAgent.DataTextField = "Contact_Name"
            drpPartnerAgent.DataValueField = "Contact_ID"
            drpPartnerAgent.DataBind()
            Dim liPartnerAgent As New ListItem("--None--", "0")
            drpPartnerAgent.Items.Insert(0, liPartnerAgent)
        Else
            Dim liPartnerAgent As New ListItem("--None--", "0")
            drpPartnerAgent.Items.Insert(0, liPartnerAgent)
        End If
    End Sub
End Class
