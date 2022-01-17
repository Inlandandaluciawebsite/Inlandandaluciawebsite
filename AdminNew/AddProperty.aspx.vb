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
Imports System.Net.Mail

Partial Class Admin_AddProperty
    Inherits System.Web.UI.Page
    'Shared id As Int32 = 0
    Shared BuyerIdNew As Int32 = 0
    Shared postcodeId As Integer = 0
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Session("ContactPartnerID") = 3873
        'Session("ContactID") = 1001
        'Session("AdminUser") = 1
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        AdminLocation1.ContainingPropertiesOnly = False
        AdminLocation1.AddAllOption = False
        '' Init and Set Partner and Broker Vars
        'CUtilities.PopulateDropDownList(drpPartner, CDataAccess.Partners)
        'CUtilities.PopulateDropDownList(drpBroker, CDataAccess.Brokers(Convert.ToInt32(drpPartner.SelectedValue)))
        '' Add <None> to Broker
        'drpBroker.Items.Insert(0, "--- None ---")        ' Add Broker
        'drpPartner.Items.Insert(0, "--- None ---")        ' Add Partner
        CUtilities.PopulateDropDownList(DropDownListBuyerLawyer, CDataAccess.Lawyers)
        ' Add <None> to Lawyers
        DropDownListBuyerLawyer.Items.Insert(0, "--- None ---")
        CUtilities.PopulateDropDownList(DropDownListLanguage, CDataAccess.Languages(Convert.ToInt32(Session("ContactLanguageID"))))
        ' Add Image Inserting Options
        DropDownListUploadImageOption.Items.Add("Append")
        DropDownListUploadImageOption.Items.Add("Prepend")
        DropDownListUploadImageOption.Items.Add("Replace Main")
        ' Local Vars
        Dim nCount As Integer = 0
        Dim nColumnCount As Integer
        ' Get the Features Available
        Dim dtDataTable As DataTable = CDataAccess.Features
        ' Get the Column Count
        nColumnCount = Math.Ceiling(dtDataTable.Rows.Count / 4)
        ' For each Row Returned
        For Each dr As DataRow In dtDataTable.Rows
            ' Increment Counter
            nCount += 1
            ' Add a CheckBox
            Dim chkFeature As New CheckBox
            ' Add Feature
            chkFeature.ID = dr("id").ToString
            chkFeature.Text = dr("text").ToString.Trim
            chkFeature.AutoPostBack = True
            ' Add an Event Handler for this
            ' AddHandler chkFeature.CheckedChanged, AddressOf MakeDirty
            ' Depending on the Column
            If nCount > nColumnCount * 3 Then
                Column4.Controls.Add(chkFeature)
                Column4.Controls.Add(New LiteralControl("<br/>"))
            ElseIf nCount > nColumnCount * 2 Then
                Column3.Controls.Add(chkFeature)
                Column3.Controls.Add(New LiteralControl("<br/>"))
            ElseIf nCount > nColumnCount Then
                Column2.Controls.Add(chkFeature)
                Column2.Controls.Add(New LiteralControl("<br/>"))
            Else
                Column1.Controls.Add(chkFeature)
                Column1.Controls.Add(New LiteralControl("<br/>"))
            End If
        Next
        ' Tidy
        dtDataTable.Dispose()
        ' Populate History Types
        CUtilities.PopulateDropDownList(DropDownListHistoryType, CDataAccess.PropertyHistoryTypes)
        ' Add None
        DropDownListHistoryType.Items.Insert(0, "--- Select ---")
        ' If we are Looking at an Existing Property
        If Not Session("AdminPropertySelected") Is Nothing Then
            ' Load the Last People who Viewed this Property on a Tour in Date Descending Order
            CUtilities.PopulateDropDownList(DropDownListBuyer, CDataAccess.PropertyLastTouredBuyers(DirectCast(Session("AdminPropertySelected"), ClassProperty).ID))
            ' If this List COntains the Buyer
            If DropDownListBuyer.Items.Contains(DropDownListBuyer.Items.FindByValue(DirectCast(Session("AdminPropertySelected"), ClassProperty).BuyerID)) Then
                ' Select this Item
                DropDownListBuyer.SelectedValue = DirectCast(Session("AdminPropertySelected"), ClassProperty).BuyerID
            End If
        End If
        ' Tidy
        CDataAccess = Nothing
        CUtilities = Nothing
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        ' Add Postback Trigger for Images
        'Dim sm As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        'sm.RegisterPostBackControl(ButtonUploadImage)
        'sm.RegisterPostBackControl(ButtonUpload)
        'sm.RegisterPostBackControl(ButtonDownload)
    End Sub
    Protected Sub AdminLocation1_Dirty() Handles AdminLocation1.Dirty
        MakeDirty()
    End Sub
    Protected Sub DropDownListLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListLanguage.SelectedIndexChanged
        ' Hide Messages
        ' HideDescriptionMessages()
        ' For Each lstItem As ListItem In DropDownListLanguage.Items

        '    ' If this is the Selected Language
        '    If lstItem.Selected Then

        '        ' Simply Save Text
        '        DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = TextBoxShortDescription.Text.Trim

        '    Else

        '        ' Translate and Add to the Array
        '        Dim CUtilities As New ClassUtilities
        '        DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = CUtilities.Translate(TextBoxShortDescription.Text.Trim, lstItem.Value, DropDownListLanguage.SelectedValue)
        '        CUtilities = Nothing

        '    End If

        'Next
        'For Each lstItem As ListItem In DropDownListLanguage.Items

        '    ' If this is the Selected Language
        '    If lstItem.Selected Then

        '        ' Simply Save Text
        '        DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = TextBoxDescription.Text.Trim

        '    Else

        '        ' Translate and Add to the Array
        '        Dim CUtilities As New ClassUtilities
        '        DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = CUtilities.Translate(TextBoxDescription.Text.Trim, lstItem.Value, DropDownListLanguage.SelectedValue)
        '        CUtilities = Nothing

        '    End If
        'Next
        ' Check we have a Value
        If DropDownListLanguage.SelectedValue <> String.Empty Then
            ' Populate Drop Down Lists with Descriptions
            TextBoxShortDescription.Text = HttpUtility.HtmlDecode(DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)))
            TextBoxDescription.Text = HttpUtility.HtmlDecode(DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)))
            ' Clean the Form
            '   MakeDescriptionClean()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        TableMessage.Visible = False
        lblmessage.Text = String.Empty
        lblpartmessage.Text = String.Empty
        LabelMessageShort.Visible = False
        LabelMessage.Visible = False
        lbldescmessage.Text = String.Empty
        lblfeatuer.Text = String.Empty
        lblimage.Text = String.Empty
        lblhistorymsg.Text = String.Empty
        lbldocument.Text = String.Empty
        If Not IsPostBack Then
            bindvendor()
            bindtype()
            If Not Request.QueryString("PropertyId") = "" Then
                hdcont.Value = Request.QueryString("PropertyId")
                hdpageind.Value = Request.QueryString("PageIndex")
                Dim url As String = Request.UrlReferrer.ToString()
                'Dim url As String = "http://localhost:59926/AdminNew/AddProperty.aspx?PropertyId=29696&PageIndex=1&Ref=&Address=&type=0&Area=0&Town=0&Beds=0&Bath=0&status=0"
                Dim uri = New Uri(url)
                Dim qs = HttpUtility.ParseQueryString(uri.Query)
                qs.[Set]("ID", hdcont.Value)
                If url.Contains("ManageProperties.aspx") Then
                    qs.[Set]("PageIndex", hdpageind.Value)
                    qs.[Set]("Ref", Request.QueryString("Ref"))
                    qs.[Set]("Address", Request.QueryString("Address"))
                    qs.[Set]("type", Request.QueryString("type"))
                    qs.[Set]("Area", Request.QueryString("Area"))
                    qs.[Set]("Town", Request.QueryString("Town"))
                    qs.[Set]("Beds", Request.QueryString("Beds"))
                    qs.[Set]("Bath", Request.QueryString("Bath"))
                    qs.[Set]("status", Request.QueryString("status"))
                End If
                If url.Contains("LatestProperties.aspx") Then
                    qs.[Set]("Duration", Request.QueryString("Duration"))
                    qs.[Set]("Created", Request.QueryString("Created"))
                    qs.[Set]("Modified", Request.QueryString("Modified"))
                End If
                If url.Contains("Novideos.aspx") Then
                    qs.[Set]("PageIndex", hdpageind.Value)
                End If
                Dim uriBuilder = New UriBuilder(uri)
                uriBuilder.Query = qs.ToString()
                Dim newUri = uriBuilder.Uri
                hdnprevurl.Value = newUri.ToString()
                id = Convert.ToInt32(Request.QueryString(0))
                Dim sql As SqlParameter() = New SqlParameter(2) {}
                sql(0) = New SqlParameter("@property_id", id)
                sql(1) = New SqlParameter("@PartnerId", Convert.ToInt32(Session("ContactPartnerID")))
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_SelectByPropertyId", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    lblpropref.Text = dt.Rows(0)("Property_Ref").ToString()
                    'Binding History Header Values
                    lblHistoryPropReference.Text = dt.Rows(0)("Property_Ref").ToString()
                    lblHistoryDateCreated.Text = dt.Rows(0)("Create_Date").ToString()
                    lblHistoryDateModified.Text = dt.Rows(0)("Last_Modified").ToString()
                    lblHistoryPublicPrice.Text = dt.Rows(0)("public_price").ToString()
                    lblHistoryOriginalPrice.Text = dt.Rows(0)("original_price").ToString()
                    lblHistoryVendorPrice.Text = dt.Rows(0)("vendor_price").ToString()
                    lblHistoryVendorName.Text = dt.Rows(0)("VendorName").ToString()
                    lblHistoryVendorEmail.Text = dt.Rows(0)("VendorEmail").ToString()
                    lblHistoryVendorTelephone.Text = dt.Rows(0)("VendorPhone").ToString()
                    lblHistoryViews.Text = dt.Rows(0)("Viewed").ToString()
                    lblHistoryToured.Text = dt.Rows(0)("Toured").ToString()
                    If Convert.ToInt32(lblHistoryToured.Text) = 0 Then
                        DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("19"))
                        DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("20"))
                        DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("21"))
                        DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("22"))
                        DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("23"))
                        DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("24"))
                        DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("25"))
                        DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("26"))
                    End If
                    lblTotalEnquries.Text = dt.Rows(0)("Total_Enquriries").ToString()
                    ''''''''''''''''''''''''''''''
                    addprop.Style.Add(HtmlTextWriterStyle.Display, "none")
                    addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
                    proppartrefbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
                    proppartref.Style.Add(HtmlTextWriterStyle.Display, "none")
                    propform.Style.Add(HtmlTextWriterStyle.Display, "block")
                    propformbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
                    hdpropid.Value = dt.Rows(0)("Property_Ref").ToString()
                    '''''''''''
                    ligen.Attributes.Add("class", "active")
                    tab1default.Style.Add(HtmlTextWriterStyle.Display, "block")
                    tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
                    tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
                    tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
                    tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
                    tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
                    lidec.Attributes.Remove("class")
                    liimage.Attributes.Remove("class")
                    lifeat.Attributes.Remove("class")
                    lihist.Attributes.Remove("class")
                    lidocum.Attributes.Remove("class")
                    ' If we are not Bulk Loading Images
                    bindstatus()
                    bindlocation()
                    bindviews()
                    bindyears()
                    bindlawyer()
                    bedrooms()
                    bathrooms()
                    bindpatner()
                    bindbroker()
                    Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))
                    ' Load this Property's Details
                    Dim CDataAccess As New ClassDataAccess
                    CProperty.Load(lblpropref.Text)
                    CDataAccess = Nothing
                    Session("AdminPropertySelected") = CProperty
                    CProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
                    '' InitData(CProperty)
                    InitData(DirectCast(Session("AdminPropertySelected"), ClassProperty))
                    lblgeneral_Click(Nothing, Nothing)
                    '''''''''''''''''''''''''''''''''''''''''''''
                End If

            ElseIf Not Request.QueryString("VId") = "" Then
                drpVendor.SelectedValue = Convert.ToInt32(Request.QueryString("VId").ToString())
                drpVendor.Enabled = False
                addprop.Style.Add(HtmlTextWriterStyle.Display, "block")
                addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
                propform.Style.Add(HtmlTextWriterStyle.Display, "none")
                propformbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
            Else
                addprop.Style.Add(HtmlTextWriterStyle.Display, "block")
                addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
                propform.Style.Add(HtmlTextWriterStyle.Display, "none")
                propformbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
            End If
            'AdminLocation1.MustIncludePostcodeID = postcodeId
            'AdminLocation1.InitData(postcodeId)
            Dim CDataAccess1 As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            ' If we are Looking at an Existing Property
            If Not Session("AdminPropertySelected") Is Nothing Then
                ' Load the Last People who Viewed this Property on a Tour in Date Descending Order
                CUtilities.PopulateDropDownList(DropDownListBuyer, CDataAccess1.PropertyLastTouredBuyers(DirectCast(Session("AdminPropertySelected"), ClassProperty).ID))
                ' If this List COntains the Buyer
                If DropDownListBuyer.Items.Contains(DropDownListBuyer.Items.FindByValue(DirectCast(Session("AdminPropertySelected"), ClassProperty).BuyerID)) Then
                    ' Select this Item
                    DropDownListBuyer.SelectedValue = DirectCast(Session("AdminPropertySelected"), ClassProperty).BuyerID
                End If
            End If
        End If
        ' If this is a Postback
        If IsPostBack And Not Session("AdminPropertyBulkImageUpload") Is Nothing Then
            ' Completed Bulk Image Upload
            ' Display Images
            DisplayImages()
            ' Display / Hide Image Upload Options
            DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)
            ' Make Dirty
            MakeDirty()
            ' Reset Flag
            Session("AdminPropertyBulkImageUpload") = Nothing
        End If
        Dim sqlVendorAgent As SqlParameter() = New SqlParameter(1) {}
        sqlVendorAgent(0) = New SqlParameter("@Vendor_Id", Convert.ToInt32(DropDownListVendor.SelectedValue))
        Dim dtVendorAgent As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Select_Agent_By_VendorId", sqlVendorAgent).Tables(0)
        If dtVendorAgent.Rows.Count > 0 Then
            lblAgent.Text = dtVendorAgent.Rows(0)("contact_name").ToString()
        Else
            lblAgent.Text = "-"
        End If

        If DropDownListUnderOfferTo.Items.Count = 0 Then
            liPropertyPayment.Visible = False
        End If
    End Sub
    Private Sub bindtype()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@LanguageId", Convert.ToInt32(Session("ContactLanguageID")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_TypeBYId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            drpproperty.DataSource = dt
            drpproperty.DataTextField = "text"
            drpproperty.DataValueField = "id"
            drpproperty.DataBind()
            DropDownListType.DataSource = dt
            DropDownListType.DataTextField = "text"
            DropDownListType.DataValueField = "id"
            DropDownListType.DataBind()
            Dim licategory As New ListItem("-- Select Property --", "0")
            drpproperty.Items.Insert(0, licategory)
        End If
    End Sub
    Private Sub bindvendor()
        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If
        'get property partner id
        Dim sqlpropertypartner As SqlParameter() = New SqlParameter(0) {}
        sqlpropertypartner(0) = New SqlParameter("@Property_Id", Convert.ToInt32(Request.QueryString("PropertyId")))
        Dim dtpropertypartner As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_GetPartner_By_PropertyId", sqlpropertypartner).Tables(0)
        If dtpropertypartner.Rows.Count > 0 Then
            btnsaveproperty.Visible = (dtpropertypartner.Rows(0)("Partner_Id") = Session("ContactPartnerID")) Or Convert.ToBoolean(Session("AdminUser"))
        End If
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)
        Dim dt As DataTable
        'If Convert.ToInt32(Session("AdminUser")) = 0 And btnsaveproperty.Visible = True Then
        '    dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Vendor_By_ContactPartnerId", Sql).Tables(0)
        'Else
        '    DropDownListVendor.Enabled = False
        dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Vendor").Tables(0)
        'End If
        If dt.Rows.Count > 0 Then
            drpVendor.DataSource = dt
            drpVendor.DataTextField = "text"
            drpVendor.DataValueField = "id"
            drpVendor.DataBind()
            DropDownListVendor.DataSource = dt
            DropDownListVendor.DataTextField = "text"
            DropDownListVendor.DataValueField = "id"
            DropDownListVendor.DataBind()
            Dim licategory As New ListItem("-- Select Vendor --", "0")
            Dim licategory1 As New ListItem("-- Select--", "0")
            DropDownListVendor.Items.Insert(0, licategory1)
            drpVendor.Items.Insert(0, licategory)
        End If
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@ePropertyTypeID", drpproperty.SelectedValue)
        sql(1) = New SqlParameter("@ContactPartnerID", 0)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_GetNextPropertyRef_ByePropertyTypeID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            lblpropref.Text = dt.Rows(0)("id").ToString()
            hdpropid.Value = dt.Rows(0)("id").ToString()
            'addprop.Style.Add(HtmlTextWriterStyle.Display, "none")
            'addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
            'propform.Style.Add(HtmlTextWriterStyle.Display, "block")
            'propformbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
            addprop.Style.Add(HtmlTextWriterStyle.Display, "none")
            addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
            propform.Style.Add(HtmlTextWriterStyle.Display, "block")
            propformbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
            Dim sql1 As SqlParameter() = New SqlParameter(5) {}
            sql1(0) = New SqlParameter("@property_ref", dt.Rows(0)("id").ToString())
            sql1(1) = New SqlParameter("@ContactId", Convert.ToInt32(Session("ContactID")))
            sql1(2) = New SqlParameter("@ContactPartnerId", Convert.ToInt32(Session("ContactPartnerID")))
            sql1(3) = New SqlParameter("@VendorId", drpVendor.SelectedValue)
            sql1(4) = New SqlParameter("@PropertyType", drpproperty.SelectedValue)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_SavePropertyRefrence_ByRef", sql1)
            Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))
            bindstatus()
            bindlocation()
            bindviews()
            bindyears()
            bindlawyer()
            bedrooms()
            bathrooms()
            bindpatner()
            bindbroker()
            ' Load this Property's Details
            Dim CDataAccess As New ClassDataAccess
            CProperty.Load(lblpropref.Text)
            CDataAccess = Nothing
            Session("AdminPropertySelected") = CProperty
            CProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
            InitData(CProperty)
            'If Convert.ToInt32(Session("ContactPartnerID")) <> 3864 And Convert.ToInt32(Session("ContactPartnerID")) <> 9103 And Convert.ToInt32(Session("ContactPartnerID")) <> 3873 And Convert.ToInt32(Session("ContactPartnerID")) <> 9495 And Convert.ToInt32(Session("ContactPartnerID")) <> 7666 And Convert.ToInt32(Session("ContactPartnerID")) <> 10109 And Convert.ToInt32(Session("ContactPartnerID")) <> 10274 And Convert.ToInt32(Session("ContactPartnerID")) <> 10309 And Convert.ToInt32(Session("ContactPartnerID")) <> 10391 And Convert.ToInt32(Session("ContactPartnerID")) <> 14429 And Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID Then
            If Convert.ToInt32(Session("ContactPartnerID")) = -1 And Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID Then
                proppartrefbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
                proppartref.Style.Add(HtmlTextWriterStyle.Display, "block")
                propform.Style.Add(HtmlTextWriterStyle.Display, "none")
                propformbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
            Else
                lblgeneral_Click(Nothing, Nothing)
            End If
        End If
    End Sub
    Private Sub SetStatusOptionsVisibility()
        Try
            ' If this Property is Under Offer, display the Drop Down of Potential Buyers
            TableRowUnderOfferTo.Visible = (DropDownListStatus.SelectedValue = 7) And (DropDownListUnderOfferTo.Items.Count > 0)
            If TableRowUnderOfferTo.Visible = True Then
                lblunderoofferto.Text = "Under Offer To"
            End If
            If (BuyerIdNew > 0) Then
                If DropDownListStatus.SelectedValue = 5 Or DropDownListStatus.SelectedValue = 6 Then
                    TableRowUnderOfferTo.Visible = (DropDownListStatus.SelectedValue = 5 Or DropDownListStatus.SelectedValue = 6) And (DropDownListUnderOfferTo.Items.Count > 0)
                    lblunderoofferto.Text = "Sold To"
                End If
            End If '' If this Property is For Sale / Under Offer, Display the Display property Checkbox
            ' GG Requested Change on 15/01/2015 - Never Display
            TableRowDisplayProperty.Visible = (DropDownListStatus.SelectedValue = 2 Or DropDownListStatus.SelectedValue = 7)
            divBannerType.Visible = (DropDownListStatus.SelectedValue = 2)
            ' If this Property is for Sale, display the Featured Property CheckBox
            'TableRowFeatureProperty.Visible = (DropDownListStatus.SelectedValue = 2)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub DropDownListStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListStatus.SelectedIndexChanged
        ' Init to not Display
        CheckBoxDisplay.Checked = False
        ' If not NULL
        If DropDownListStatus.SelectedValue <> String.Empty Then
            ' Local Vars
            Dim bDirty As Boolean = True
            Dim alMessage As ArrayList
            ' If this is set to Under Offer
            If DropDownListStatus.SelectedValue = 7 Then
                ' If we don't have any Viewers
                If DropDownListUnderOfferTo.Items.Count < 1 Then
                    ' Inform the User of the Problem
                    ' Create Message Array
                    alMessage = New ArrayList
                    ' Create the Message
                    alMessage.Add("This property has not yet been toured so no potential buyers exist")
                    lblmessage.Text = "This property has not yet been toured so no potential buyers exist"
                    ' Inform the User
                    'Message("Status of 'Under Offer'", alMessage, False)
                    ' Tidy
                    alMessage.Clear()
                    alMessage = Nothing
                    ' Reset
                    DropDownListStatus.SelectedValue = "2"
                Else
                    ' Set Flag
                    bDirty = False
                End If
            ElseIf DropDownListStatus.SelectedValue = 5 Then
                ' Create Message Array
                alMessage = New ArrayList
                ' Create the Message
                alMessage.Add("Please enter a property status value of 'Sold' via the History section to select a buyer and provide details of the sale")
                lblmessage.Text = "Please enter a property status value of 'Sold' via the History section to select a buyer and provide details of the sale"
                ' Inform the User
                Message("Status of 'Sold'", alMessage, False)
                ' Tidy
                alMessage.Clear()
                alMessage = Nothing
                ' Reset
                DropDownListStatus.SelectedValue = "2"
                ' Set Flag
                bDirty = False
            Else
                ' If this Property is not for Sale, it cannot be Featured
                If DropDownListStatus.SelectedValue <> 2 Then
                    CheckBoxFeature.Checked = False
                End If
            End If
            ' Set Status Options Visibility
            SetStatusOptionsVisibility()
            ' If Dirty
            If bDirty Then
                ' Make Dirty
                MakeDirty()
            End If
        End If
        ' Set to Display if For Sale or Under Offer
        CheckBoxDisplay.Checked = (DropDownListStatus.SelectedValue = 2 Or DropDownListStatus.SelectedValue = 7)
    End Sub
    Protected Sub ButtonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        ' Hide Message
        addprop.Style.Add(HtmlTextWriterStyle.Display, "none")
        addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
        propform.Style.Add(HtmlTextWriterStyle.Display, "block")
        propformbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
        lblgeneral_Click(Nothing, Nothing)
        TableMessage.Visible = False
    End Sub
    Private Sub Message(ByVal szTitle As String, ByVal alMessage As ArrayList, Optional ByVal bBulletPoints As Boolean = False)
        ' Hide Header
        addprop.Style.Add(HtmlTextWriterStyle.Display, "none")
        addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
        propform.Style.Add(HtmlTextWriterStyle.Display, "none")
        propformbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
        TableUploadImages.Visible = False
        TableImages.Visible = False
        TableFeatures.Visible = False
        TableHistory.Visible = False
        TableDocuments.Visible = False
        ' Set Title
        LabelMessageTitle.Text = szTitle.Trim
        ' If Bullet Points
        If bBulletPoints Then
            LabelMessageBody.Text = "<ul>"
        Else
            LabelMessageBody.Text = String.Empty
        End If
        ' Add each Line of the Message
        For Each szLine As String In alMessage
            ' If Bullet Points
            If bBulletPoints Then
                LabelMessageBody.Text &= "<li>" & szLine.Trim & "</li>"
            Else
                LabelMessageBody.Text &= szLine.Trim & "<br />"
            End If
        Next
        ' If Bullet Points
        If bBulletPoints Then
            LabelMessageBody.Text &= "</ul>"
        End If
        ' Display the Message
        TableMessage.Visible = True
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("AddVendor.aspx")
    End Sub
    Protected Sub lblgeneral_Click(sender As Object, e As EventArgs)
        ligen.Attributes.Add("class", "active")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
        lnkhistory.Style.Add(HtmlTextWriterStyle.Display, "none")
        tabPropertyPayment.Style.Add(HtmlTextWriterStyle.Display, "none")
        lidec.Attributes.Remove("class")
        liimage.Attributes.Remove("class")
        lifeat.Attributes.Remove("class")
        lihist.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
        liPropertyPayment.Attributes.Remove("class")
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        lidec.Attributes.Add("class", "active")
        ligen.Attributes.Remove("class")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
        lnkhistory.Style.Add(HtmlTextWriterStyle.Display, "none")
        tabPropertyPayment.Style.Add(HtmlTextWriterStyle.Display, "none")
        liimage.Attributes.Remove("class")
        lifeat.Attributes.Remove("class")
        lihist.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
        liPropertyPayment.Attributes.Remove("class")
    End Sub
    Private Function HideZeros(ByVal nValue As Integer) As String
        If nValue > 0 Then
            Return nValue.ToString.Trim
        Else
            Return String.Empty
        End If
    End Function
    Public Sub InitData(ByVal CProperty As ClassProperty)
        If Session("AdminPropertyBulkImageUpload") Is Nothing Then
            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            ''''general
            ButtonViewVendor.Visible = CProperty.VendorID > 0
            btnsaveproperty.Visible = (CProperty.PartnerID = Session("ContactPartnerID")) Or Convert.ToBoolean(Session("AdminUser"))
            ButtonAutoTranslateShort.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))
            ButtonSaveShortDescription.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))
            ButtonAutoTranslate.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))
            ButtonSaveDescription.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))
            btndescription.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))
            btnimageprop.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))
            btnfeater.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))
            ''  btnhistory.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))
            btndocument.Visible = btnsaveproperty.Visible Or Convert.ToBoolean(Session("AdminUser"))

            'drpBroker.Enabled = Convert.ToBoolean(Session("AdminUser"))
            txtPropertyPartnerRef.Text = CProperty.CAReference
            'Try
            'If CProperty.HistorySubjectType.ToString() <> "" Then
            'lblSubjectTo.Text = "Reserved With " & CProperty.HistorySubjectType.ToString()
            'Get Buyer From procedure based on reserved and No Longer Valid check
            'Dim BuyerReserved As String = ""
            'Dim sqlBuyerReserved As SqlParameter() = New SqlParameter(0) {}
            'sqlBuyerReserved(0) = New SqlParameter("@PropertyRef", CProperty.Reference)
            'Dim dtBuyerReserved As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Get_Reserved_Buyer_With_NoLongerValid_Check", sqlBuyerReserved).Tables(0)
            'If dtBuyerReserved.Rows.Count > 0 Then
            '    BuyerReserved = dtBuyerReserved.Rows(0)("BuyerReserved").ToString()
            'End If
            'lblSubjectTo.Text = "Reserved - " & CProperty.HistorySubjectType.ToString() & " - Expired Date : " & CProperty.HistoryExpiryDate & "  -  Client : " & BuyerReserved & "  - Salesperson : " & CProperty.ListedBy & ""
            'Dim sqlSubjectToInfo As SqlParameter() = New SqlParameter(0) {}
            '        sqlSubjectToInfo(0) = New SqlParameter("@Property_Ref", CProperty.Reference)
            '        Dim dtSubjectToInfo As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_SubjectTo_Get", sqlSubjectToInfo).Tables(0)
            '        If dtSubjectToInfo.Rows.Count > 0 Then
            '            lblSubjectTo.Text = dtSubjectToInfo.Rows(0)("SubjectToInfo").ToString()
            '        End If

            'End If

            'If lblSubjectTo.Text <> "" Then
            '        lblSubjectTo.Visible = True
            '    Else
            '        lblSubjectTo.Visible = False
            '    End If
            'Catch ex As Exception

            'End Try

            '''' GENERAL ''''
            'If Convert.ToInt32(Session("ContactPartnerID")) <> 3864 And Convert.ToInt32(Session("ContactPartnerID")) <> 9103 And Convert.ToInt32(Session("ContactPartnerID")) <> 3873 And Convert.ToInt32(Session("ContactPartnerID")) <> 9495 And Convert.ToInt32(Session("ContactPartnerID")) <> 7666 And Convert.ToInt32(Session("ContactPartnerID")) <> 10109 And Convert.ToInt32(Session("ContactPartnerID")) <> 10274 And Convert.ToInt32(Session("ContactPartnerID")) <> 10309 And Convert.ToInt32(Session("ContactPartnerID")) <> 10391 And Convert.ToInt32(Session("ContactPartnerID")) <> 14429 And Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID Then
            If Convert.ToInt32(Session("ContactPartnerID")) = -1 And Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID Then
                txtproppartref.Text = CProperty.CAReference
                If CProperty.CAReference = "" Then
                    btnedirref.Text = "Add Partner Ref"
                End If
                lblpartnerref.Text = CProperty.CAReference
                btnedirref.Visible = True
            Else
                btnedirref.Visible = False
            End If
            ' Assign Form Variables from the Property Class
            txtAddress.Text = CProperty.Address.Trim
            'LabelPropertyAddress.Text = TextBoxPropertyAddress.Text
            txtTAXABLEval.Text = CProperty.Taxablevalue.ToString.Trim
            drpBannerType.SelectedValue = CProperty.BannerType
            lblListedBy.Visible = True
            hdnListedById.Value = CProperty.LContactId.ToString()
            Dim listedByPartner As String = CProperty.ListedByPartner

            If CProperty.ListedBy = "0" Then
                lblListedBy.Text = "By - 0"
            Else
                lblListedBy.Text = "By " & CProperty.ListedBy & " - " & listedByPartner
                drpListedByUsers.Visible = True
                bindusers()
                'If CProperty.ListedBy <> "" Then
                '    Try
                '        drpListedByUsers.Items.FindByText(CProperty.ListedBy).Selected = True
                '    Catch ex As Exception

                '    End Try

                'End If
            End If
            drpListedByUsers.Visible = Convert.ToBoolean(Session("AdminUser"))
            txtAnnualIBI.Text = IIf(CProperty.AnnualIBI = 0, "", CProperty.AnnualIBI)
            txtAnnualRubbish.Text = IIf(CProperty.AnnualRubbish = 0, "", CProperty.AnnualRubbish)
            drpbathrooms.SelectedValue = CProperty.Bathrooms.ToString.Trim
            drpbedrooms.SelectedValue = CProperty.Bedrooms.ToString.Trim
            txtbuilt.Text = IIf(CProperty.Built = 0, "", CProperty.Built)
            txtCommunityFees.Text = IIf(CProperty.CommunityFees = 0, "", CProperty.CommunityFees)
            CheckBoxDisplay.Checked = CProperty.Display
            txtensuite.Text = IIf(CProperty.EnSuite = 0, "", CProperty.EnSuite)
            CheckBoxFeature.Checked = CProperty.Featured
            If CheckBoxFeature.Checked Then
                TableRowFeatureProperty.Visible = True
                'Get expiry date & start date from database by property reference 
                Dim sqlfeatureDetails As SqlParameter() = New SqlParameter(0) {}
                sqlfeatureDetails(0) = New SqlParameter("@Property_Ref", CProperty.Reference)
                Dim dtfeatureDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Feature_Property_Select_By_PropRef", sqlfeatureDetails).Tables(0)
                If dtfeatureDetails.Rows.Count > 0 Then
                    txtStartDate.Text = dtfeatureDetails.Rows(0)("Featured_Prop_Date").ToString()
                    txtExpiryDate.Text = dtfeatureDetails.Rows(0)("Expiry_Date").ToString()
                End If
            Else
                TableRowFeatureProperty.Visible = False
            End If
            txtLattitude.Text = IIf(CProperty.Latitude = 0, "", CProperty.Latitude)
            drplocation.SelectedValue = CProperty.LocationID
            txtLongitude.Text = IIf(CProperty.Longitude = 0, "", CProperty.Longitude)
            txtOriginalPrice.Text = IIf(CProperty.OriginalPrice = 0, "", CProperty.OriginalPrice)
            txtplot.Text = HideZeros(CProperty.Plot)
            AdminLocation1.MustIncludePostcodeID = CProperty.PostcodeID
            AdminLocation1.InitData(CProperty.PostcodeID)
            txtPublicPrice.Text = IIf(CProperty.PublicPrice = 0, "", CProperty.PublicPrice)
            DropDownListStatus.SelectedValue = CProperty.StatusID
            hdnPropertyStatus.Value = DropDownListStatus.SelectedItem.Text
            txtterrace.Text = IIf(CProperty.Terrace = 0, "", CProperty.Terrace)
            chkIsIssues.Checked = CProperty.IsIssue
            ' If we don't have a Property Type ID
            If CProperty.TypeID = 0 Then
                DropDownListType.SelectedIndex = -1
            Else
                DropDownListType.SelectedValue = CProperty.TypeID
            End If

            ' Continue to Init Vars
            txtVendorPrice.Text = HideZeros(CProperty.VendorPrice)
            hdnVendorPrice.Value = HideZeros(CProperty.VendorPrice)
            hdnPublicPrice.Value = HideZeros(CProperty.PublicPrice)
            drpviews.SelectedValue = CProperty.ViewsID
            ' If we have a Construction Year
            If CProperty.YearConstructed > 0 Then
                drpyearconstructed.SelectedValue = CProperty.YearConstructed
            End If
            ' Continue to Init Vars
            txtYoutubeVideoId.Text = CProperty.YouTubeVideoID
            txtDoorKey.Text = CProperty.DoorKey

            ' Select Partner
            If CProperty.PartnerID > 0 Then
                drpPartner.SelectedValue = CProperty.PartnerID
                ' Update Brokers
                drppartner_SelectedIndexChanged(Nothing, Nothing)
            End If

            ' Get PartnerId from postcode table by passing postcode id

            Dim sqlGetPartnerId As SqlParameter() = New SqlParameter(0) {}
            sqlGetPartnerId(0) = New SqlParameter("@PostCode_Id", CProperty.PostcodeID)
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_POSTCODE_Select_By_PostCode_Id", sqlGetPartnerId).Tables(0)

            If dt.Rows.Count > 0 Then
                drpPartner.SelectedValue = dt.Rows(0)("Default_Partner_Id")
                drppartner_SelectedIndexChanged(Nothing, Nothing)
            End If

            ' If we have a Broker
            'If CProperty.BrokerID > 0 Then

            '    ' Select the Broker
            '    drpBroker.SelectedValue = CProperty.BrokerID
            'Else
            ' Get the Broker ID
            'Dim nBrokerID As Integer = CDataAccess.PartnerID(CProperty.VendorID)
            'Dim nBrokerID As Integer = CProperty.BrokerID
            ' Response.Write(nBrokerID)
            ' Does the Broker Exist in the List?
            'If drpBroker.Items.FindByValue(nBrokerID.ToString.Trim) Is Nothing Then
            '    ' Init to None
            '    drpBroker.SelectedIndex = 0
            'Else
            '    ' Select Value
            '    'drpBroker.SelectedValue = CDataAccess.PartnerID(CProperty.BrokerID)
            '    drpBroker.SelectedValue = nBrokerID
            '    '  drpBroker.Items(drpBroker.Items.IndexOf(drpBroker.Items.FindByValue(CDataAccess.PartnerID(CProperty.VendorID)))).Selected = True
            'End If
            '  End If

            'If we have a broker

            If CProperty.BrokerID > 0 Then

                'Get broker name by brokerid
                Dim sqlbrokerdetails As SqlParameter() = New SqlParameter(0) {}
                sqlbrokerdetails(0) = New SqlParameter("@Contact_Id", CProperty.BrokerID)
                Dim dtBrokerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblContact_Select_By_Contact_Id", sqlbrokerdetails).Tables(0)
                If dtBrokerDetails.Rows.Count > 0 Then
                    lblBroker.Text = dtBrokerDetails.Rows(0)("Contact_Name").ToString()
                End If
                hdnBrokerId.Value = CProperty.BrokerID.ToString()
                BrokerRow.Visible = True
            Else
                BrokerRow.Visible = False
            End If

            ' If we have a Vendor
            If CProperty.VendorID > 0 Then
                ' Select the Vendor
                DropDownListVendor.SelectedValue = CProperty.VendorID
            Else
                ' Init to None
                DropDownListVendor.SelectedIndex = 0
            End If
            ' Buyer Lawyer
            If CProperty.BuyerLawyerID > 0 Then
                ' Select the Lawyer
                DropDownListBuyerLawyer.SelectedValue = CProperty.BuyerLawyerID
            Else
                ' Init to None
                DropDownListBuyerLawyer.SelectedIndex = 0
            End If
            ' Buyer Lawyer only Visible if Under Offer
            TableRowBuyerLawyer.Visible = (CProperty.StatusID = 7) Or (CProperty.StatusID = 5)
            ' Vendor Lawyer
            If CProperty.VendorLawyerID > 0 Then
                ' Select the Lawyer
                drpVendrlaywer.SelectedValue = CProperty.VendorLawyerID
            Else
                ' Init to None
                drpVendrlaywer.SelectedIndex = 0
            End If
            ' Init to the Last People who Viewed this Property on a Tour in Date Descending Order
            CUtilities.PopulateDropDownList(DropDownListUnderOfferTo, CDataAccess.PropertyLastTouredBuyers(CProperty.ID))
            'Here i am getting buyer from tblPaypalTransactions if anyone recently been reserved this property through paypal OR stirpe
            'And adding with in binded buyers dropdown

            Dim dtBuyerDetails As DataTable
            Dim query As String = "select ltrim(rtrim(Buyer_Forename)) + ' ' + ltrim(rtrim(Buyer_Surname)) 'Buyer',Buyer_Id From buyer where Buyer_Id in(select top 1 Buyer_Id from  tblPaypalTransactions where PropertyRef='" & lblpropref.Text & "' order by PaypalTransactionId Desc)"
            dtBuyerDetails = CDataAccess.GetDataAsDataTable(query)
            If dtBuyerDetails.Rows.Count > 0 Then
                Dim liBuyer As ListItem
                liBuyer = New ListItem(dtBuyerDetails.Rows(0)("Buyer").ToString(), dtBuyerDetails.Rows(0)("Buyer_Id").ToString())
                DropDownListUnderOfferTo.Items.Add(liBuyer)
                DropDownListUnderOfferTo.SelectedValue = liBuyer.Value
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' If we have a Buyer ID
            If CProperty.BuyerID > 0 Then
                ' If it Exists in our DropDown
                If DropDownListUnderOfferTo.Items.Contains(DropDownListUnderOfferTo.Items.FindByValue(CProperty.BuyerID.ToString)) Then
                    ' Select this Item
                    DropDownListUnderOfferTo.SelectedValue = CProperty.BuyerID.ToString
                    BuyerIdNew = CProperty.BuyerID.ToString
                Else
                    BuyerIdNew = 0
                End If
            Else
                BuyerIdNew = 0
            End If
            ' Set Visibility of Property Status Options
            SetStatusOptionsVisibility()
            ' Update URLsf
            ButtonWindowcard.OnClientClick = "javascript:window.open('/windowcard.aspx?PropertyRef=" & CProperty.Reference.Trim & "','_self');return false;"
            ButtonViewingPhotos.OnClientClick = "javascript:window.open('/Admin/ViewingPhotos.aspx?PropertyRef=" & CProperty.Reference.Trim & "');return false;"
            ' Set Visibility of Windowcard (for Sale or Under Offer)
            ButtonWindowcard.Visible = (CProperty.StatusID = 2 Or CProperty.StatusID = 7)
            '''''
            ' Local Vars
            Dim de As DictionaryEntry
            ' Create the Arrays
            CreateDescriptionArrays()
            ' For each Short Description
            For Each de In CProperty.ShortDescription
                ' Populate the Array Item
                DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(de.Key)) = de.Value
            Next
            ' For each Description
            For Each de In CProperty.Description
                ' Populate the Array Item
                DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(de.Key)) = de.Value
            Next
            ' Load any Existing Descriptions
            DropDownListLanguage_SelectedIndexChanged(Nothing, Nothing)
            ''''''''''''''''''''''''''''
            'TableImages.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            Dim CImage As ClassImage
            ' Init ArrayList
            Session("PropertyAdminImages") = New ClassImages
            ' Get the IA Ref for this Property
            Dim szIARef As String = CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), CProperty.Reference).Trim.ToUpper
            ' Only do the Following if we have a Reference
            If CProperty.Reference.Trim <> String.Empty Then

                ' For each of the Images
                For nImage As Integer = 1 To CProperty.NumberOfImages
                    ' Define a New Image (Restricted to Partner)
                    CImage = New ClassImage(szIARef, szIARef.Trim & "_" & nImage.ToString.Trim & ".jpg", (Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID) Or DirectCast(Session("AdminUser"), Boolean))
                    ' If this Image Exists
                    If File.Exists(Server.MapPath(CImage.CleanURL)) Then
                        ' Add this to the Array
                        DirectCast(Session("PropertyAdminImages"), ClassImages).Append(CImage)
                    Else
                        ' File does not Exist, Ignore
                        CImage = Nothing
                    End If
                Next
                ' Display the Images
                DisplayImages()
            End If

            ' Set Visibility of Viewing Photos
            If (CProperty.NumberOfImages > 0) Then
                ButtonViewingPhotos.Visible = True
            End If
            ' Enable / Disable Upload Button
            DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)

            '''' FEATURES ''''
            '''' FEATURES ''''

            ' Init Checkboxes
            InitCheckBoxes(Column1)
            InitCheckBoxes(Column2)
            InitCheckBoxes(Column3)
            InitCheckBoxes(Column4)
            Dim mpContentPlaceHolder As ContentPlaceHolder
            mpContentPlaceHolder =
        CType(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)

            ' For each Feature this Property has
            For Each nID In CProperty.FeatureIDs

                ' If we have Found this Control
                If Not mpContentPlaceHolder.FindControl(nID.ToString.Trim) Is Nothing Then

                    ' Get this Control
                    DirectCast(mpContentPlaceHolder.FindControl(nID.ToString.Trim), CheckBox).Checked = True

                End If

            Next

            '''''''''''''''''
            LoadHistory(CProperty)
            ''''''''''''''''''''''''''''''''
            TreeViewBrowser.Nodes.Clear()

            ' Init Parent Node
            Dim szParentDirectory As String = AppDomain.CurrentDomain.GetData("DataDirectory") & "\Documents\Properties\" & CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), CProperty.Reference)

            ' Check if the Directory Exists
            If Not Directory.Exists(szParentDirectory) Then

                ' Create it
                Directory.CreateDirectory(szParentDirectory)

            End If

            ' Add the Parent Node
            Dim tn As New TreeNode(CProperty.Reference)
            tn.Value = szParentDirectory
            tn.ImageUrl = "~/Images/Icons/house.jpg"
            TreeViewBrowser.Nodes.Add(tn)

            ' Select the Root Node
            TreeViewBrowser.Nodes(0).Selected = True
            TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)

            ' Tidy
            CDataAccess = Nothing
            CUtilities = Nothing

            'End If

            ' Enable / Disable Partner Drop Down
            drpPartner.Enabled = DirectCast(Session("AdminUser"), Boolean)
        End If
    End Sub
    Public Sub InitDataImage(ByVal CProperty As ClassProperty)

        '''' IMAGES ''''
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        ' Local Vars
        'TableImages.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
        Dim CImage As ClassImage

        ' Init ArrayList
        Session("PropertyAdminImages") = New ClassImages

        ' Get the IA Ref for this Property
        Dim szIARef As String = CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), CProperty.Reference).Trim.ToUpper

        ' Only do the Following if we have a Reference
        If CProperty.Reference.Trim <> String.Empty Then

            ' For each of the Images
            For nImage As Integer = 1 To CProperty.NumberOfImages

                ' Define a New Image (Restricted to Partner)
                CImage = New ClassImage(szIARef, szIARef.Trim & "_" & nImage.ToString.Trim & ".jpg", (Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID) Or DirectCast(Session("AdminUser"), Boolean))

                ' If this Image Exists
                If File.Exists(Server.MapPath(CImage.CleanURL)) Then

                    ' Add this to the Array
                    DirectCast(Session("PropertyAdminImages"), ClassImages).Append(CImage)

                Else

                    ' File does not Exist, Ignore
                    CImage = Nothing

                End If

            Next

            ' Display the Images
            DisplayImages()

        End If

        ' Set Visibility of Viewing Photos
        ButtonViewingPhotos.Visible = (CProperty.NumberOfImages > 0)

        ' Enable / Disable Upload Button
        DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)

        '''' FEATURES ''''


    End Sub
    Public Sub InitDatafeatures(ByVal CProperty As ClassProperty)
        'TableFeatures.Enabled = True
        '''' IMAGES ''''
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        ' Local Vars
        'TableImages.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
        ' Local Vars
        '''' FEATURES ''''

        ' Init Checkboxes
        InitCheckBoxes(Column1)
        InitCheckBoxes(Column2)
        InitCheckBoxes(Column3)
        InitCheckBoxes(Column4)
        Dim mpContentPlaceHolder As ContentPlaceHolder
        mpContentPlaceHolder =
CType(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)

        ' For each Feature this Property has
        For Each nID In CProperty.FeatureIDs

            ' If we have Found this Control
            If Not mpContentPlaceHolder.FindControl(nID.ToString.Trim) Is Nothing Then

                ' Get this Control
                DirectCast(mpContentPlaceHolder.FindControl(nID.ToString.Trim), CheckBox).Checked = True

            End If

        Next



    End Sub
    Protected Sub ghostAjaxFileUpload_UploadComplete(sender As Object, e As AjaxControlToolkit.AjaxFileUploadEventArgs) Handles ghostAjaxFileUpload.UploadComplete
        ' Upload Image
        UploadImage(e.FileName, e.GetStreamContents, True)
    End Sub
    Protected Sub ghostAjaxFileUpload_UploadStart(sender As Object, e As AjaxControlToolkit.AjaxFileUploadStartEventArgs) Handles ghostAjaxFileUpload.UploadStart
        ' Set Flag
        Session("AdminPropertyBulkImageUpload") = True
    End Sub
    Private Function PopulateSaveDataFeatures(ByRef CProperty As ClassProperty) As Boolean
        Try
            ' Clear Existing
            CProperty.FeatureIDs.Clear()
            ' Populate the Class with the Features Selected
            GetSelections(CProperty, Column1)
            GetSelections(CProperty, Column2)
            GetSelections(CProperty, Column3)
            GetSelections(CProperty, Column4)
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function
    Private Sub GetSelections(ByRef CProperty As ClassProperty, ByRef ctrlParent As Control)
        ' For each CheckBox in the Control
        For Each ctrl As Control In ctrlParent.Controls
            ' If this is a Checkbox
            If TypeOf (ctrl) Is CheckBox Then
                ' If this is Checked
                If DirectCast(ctrl, CheckBox).Checked Then
                    ' Add this to the Features Array
                    CProperty.FeatureIDs.Add(Convert.ToInt32(ctrl.ID))
                End If
            End If
        Next
    End Sub
    Private Function PopulateSaveDataDescription(ByRef CProperty As ClassProperty) As Boolean
        ' Populate the Class with the Descriptions we have
        DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)) = TextBoxDescription.Text.Trim
        DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)) = TextBoxShortDescription.Text.Trim
        Try
            ' For each Language
            For Each lstItem As ListItem In DropDownListLanguage.Items
                ' Save the Descriptions
                CProperty.ShortDescription(Convert.ToInt32(lstItem.Value)) = DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(lstItem.Value))
                CProperty.Description(Convert.ToInt32(lstItem.Value)) = DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(lstItem.Value))
            Next
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function
    Private Sub InitCheckBoxes(ByRef ctrlParent As Control)
        ' For each CheckBox in the Control
        For Each ctrl As Control In ctrlParent.Controls
            ' If this is a Checkbox
            If TypeOf (ctrl) Is CheckBox Then
                ' Uncheck
                DirectCast(ctrl, CheckBox).Checked = False
                DirectCast(ctrl, CheckBox).AutoPostBack = False
            End If
        Next
    End Sub
    Private Sub CreateDescriptionArrays()
        ' Define Description Arrays
        Session("PropertyAdminShortDescription") = New Hashtable
        Session("PropertyAdminDescription") = New Hashtable
        ' For each of the Languages
        For Each lstItem In DropDownListLanguage.Items
            ' Create this Language in the Array
            DirectCast(Session("PropertyAdminShortDescription"), Hashtable).Add(Convert.ToInt32(lstItem.value), String.Empty)
            DirectCast(Session("PropertyAdminDescription"), Hashtable).Add(Convert.ToInt32(lstItem.value), String.Empty)
        Next
    End Sub
    Protected Sub lblimages_Click(sender As Object, e As EventArgs)
        liimage.Attributes.Add("class", "active")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tabPropertyPayment.Style.Add(HtmlTextWriterStyle.Display, "none")
        lnkhistory.Style.Add(HtmlTextWriterStyle.Display, "none")
        ligen.Attributes.Remove("class")
        lidec.Attributes.Remove("class")
        lifeat.Attributes.Remove("class")
        lihist.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
        liPropertyPayment.Attributes.Remove("class")
        ' Images
        TableUploadImages.Visible = True
        TableImages.Visible = True
        ' Set Visibility of Upload Image Button
        DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    Protected Sub lblFeatures_Click(sender As Object, e As EventArgs)
        lifeat.Attributes.Add("class", "active")
        ligen.Attributes.Remove("class")
        lidec.Attributes.Remove("class")
        liimage.Attributes.Remove("class")
        lihist.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
        liPropertyPayment.Attributes.Remove("class")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tabPropertyPayment.Style.Add(HtmlTextWriterStyle.Display, "none")
        lnkhistory.Style.Add(HtmlTextWriterStyle.Display, "none")
        TableFeatures.Visible = True
    End Sub
    Protected Sub lblHistory_Click(sender As Object, e As EventArgs)
        lihist.Attributes.Add("class", "active")
        ligen.Attributes.Remove("class")
        lidec.Attributes.Remove("class")
        liimage.Attributes.Remove("class")
        lifeat.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
        liPropertyPayment.Attributes.Remove("class")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tabPropertyPayment.Style.Add(HtmlTextWriterStyle.Display, "none")
        lnkhistory.Style.Add(HtmlTextWriterStyle.Display, "block")
        TableHistory.Visible = True
    End Sub
    Private Sub LoadHistory(ByVal CProperty As ClassProperty)

        ' If Session not Expired
        If Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Login Page
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Load up Previous History
            GridViewList.DataSource = CDataAccess.PropertyHistoryAbbrev(CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), CProperty.Reference), 75, Convert.ToBoolean(Session("AdminUser")))
            GridViewList.DataBind()

            ' Tidy
            CDataAccess = Nothing

            ' Hide the ID & Archive Flags
            If Not GridViewList.HeaderRow Is Nothing Then
                GridViewList.HeaderRow.Cells(1).Visible = False
                GridViewList.HeaderRow.Cells(6).Visible = False
                'GridViewList.HeaderRow.Cells(7).Visible = False
                For Each gvr As GridViewRow In GridViewList.Rows
                    gvr.Cells(1).Visible = False
                    gvr.Cells(6).Visible = False

                    ' If this is Archived, Make Gray
                    If gvr.Cells(6).Text = "Yes" Then
                        gvr.BackColor = Drawing.Color.LightGray
                    End If

                Next
            End If

            ' Reset History Type
            DropDownListHistoryType.SelectedIndex = 0

            ' Hide Buyer
            TableRowSoldTo.Visible = False

            ' Clear Add Notes
            TextBoxAddHistory.Text = String.Empty

        End If

    End Sub
    Private Sub LoadDocument(ByVal CProperty As ClassProperty)

        '''' DOCUMENTS ''''
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        ' Clear any Existing
        TreeViewBrowser.Nodes.Clear()

        ' Init Parent Node
        Dim szParentDirectory As String = AppDomain.CurrentDomain.GetData("DataDirectory") & "\Documents\Properties\" & CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), CProperty.Reference)

        ' Check if the Directory Exists
        If Not Directory.Exists(szParentDirectory) Then

            ' Create it
            Directory.CreateDirectory(szParentDirectory)

        End If

        ' Add the Parent Node
        Dim tn As New TreeNode(CProperty.Reference)
        tn.Value = szParentDirectory
        tn.ImageUrl = "~/Images/Icons/house.jpg"
        TreeViewBrowser.Nodes.Add(tn)

        ' Select the Root Node
        TreeViewBrowser.Nodes(0).Selected = True
        TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)

        ' Tidy
        CDataAccess = Nothing
        CUtilities = Nothing

        'End If

        ' Enable / Disable Partner Drop Down
        drpPartner.Enabled = DirectCast(Session("AdminUser"), Boolean)

        ' Set General Visibility
        SetGeneralVisibility(CProperty.VendorID > 0 And CProperty.TypeID > 0)

        ' Set Visibility
        ' SetVisibility()

        ' Clean
        ' MakeClean()

    End Sub
    Private Sub SetGeneralVisibility(ByVal bVendorTypeSpecified As Boolean)

        ' Set Vendor Enabled
        DropDownListVendor.Enabled = True ' Not bVendorTypeSpecified
        DropDownListType.Enabled = Not bVendorTypeSpecified

        ' Set Visiblity
        'For Each tr As TableRow In TableGeneral.Rows

        '    ' If not the Vendor
        '    If tr.ID <> "TableRowVendor" _
        '        And tr.ID <> "TableRowPropertyType" _
        '        And tr.ID <> "TableRowBuyerLawyer" _
        '        And tr.ID <> "TableRowUnderOfferTo" _
        '        And tr.ID <> "TableRowDisplayProperty" _
        '        And tr.ID <> "TableRowFeatureProperty" Then

        '        ' Set Visibility
        '        tr.Visible = bVendorTypeSpecified

        '    End If

        'Next

    End Sub
    Protected Sub GridViewList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewList.SelectedIndexChanged

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim dvRow As GridViewRow = GridViewList.SelectedRow

        ' Load the History
        TextBoxHistory.Text = CDataAccess.PropertyHistory(Convert.ToInt32(dvRow.Cells(1).Text))

        ' Make the Note Visible
        TableRowHistoryElement.Visible = True

        ' Make the Archive Visible only if Admin
        TableRowHistoryArchive.Visible = Convert.ToBoolean(Session("AdminUser"))

        ' Set the Button Text
        If dvRow.Cells(6).Text.Trim = "No" Then

            ' Currently Active
            ButtonArchiveHistory.Text = "Archive"

        Else

            ' Currently Archived
            ButtonArchiveHistory.Text = "Restore"

        End If

        ' Tidy
        CDataAccess = Nothing

    End Sub
    Protected Sub DropDownListHistoryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListHistoryType.SelectedIndexChanged
        divOwnerCallRow.Visible = False
        ' Local Vars
        Dim bDirty As Boolean = True

        ' Set Sold To Invisible
        TableRowSoldTo.Visible = False

        ' If this is set to Sold
        If DropDownListHistoryType.SelectedValue = 4 Then
            ' If we don't have any Viewers
            If DropDownListBuyer.Items.Count < 1 Then

                ' Inform the User of the Problem

                ' Create Message Array
                Dim alMessage As New ArrayList

                ' Create the Message
                alMessage.Add("This property has not yet been toured so no potential buyers exist")

                ' Inform the User
                Message("Status of 'Sold'", alMessage, False)

                ' Tidy
                alMessage.Clear()
                alMessage = Nothing

                ' Reset
                DropDownListHistoryType.SelectedIndex = 0

                ' Mark as not Dirty
                bDirty = False

            Else

                ' Set Sold To Visible
                TableRowSoldTo.Visible = True

            End If
        End If

        If DropDownListHistoryType.SelectedValue = 19 Or DropDownListHistoryType.SelectedValue = 20 Or DropDownListHistoryType.SelectedValue = 21 Or DropDownListHistoryType.SelectedValue = 22 Or DropDownListHistoryType.SelectedValue = 23 Or DropDownListHistoryType.SelectedValue = 24 Or DropDownListHistoryType.SelectedValue = 25 Or DropDownListHistoryType.SelectedValue = 26 Then
            divSubjectTo.Visible = True
            Dim CUtilities As New ClassUtilities
            Dim CDataAccess As New ClassDataAccess
            Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
            CUtilities.PopulateDropDownList(drpSubjectToBuyer, CDataAccess.PropertyLastTouredBuyers(CProperty.ID))
        Else
            divSubjectTo.Visible = False
        End If

        'If this is set to Owner Call
        Try
            If DropDownListHistoryType.SelectedValue = 2 Or DropDownListHistoryType.SelectedValue = 17 Or DropDownListHistoryType.SelectedValue = 18 Then
                rbtReduceYes.Checked = False
                rbtReduceNo.Checked = False
                rbtReduceDontWant.Checked = False
                divOwnerCallRow.Visible = True
                TextBoxAddHistory.Visible = False
            Else
                TextBoxAddHistory.Visible = True
            End If
        Catch ex As Exception

        End Try

        ' If Dirty
        If bDirty Then

            ' Make Dirty 
            MakeDirty()

        End If

    End Sub
    Protected Sub ButtonUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpload.Click
        ' Is a Node Selected?
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' Is this a Directory?
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                For Each postedFile As HttpPostedFile In FileUploadFile.PostedFiles

                    ' Do we have a File to Upload?
                    If FileUploadFile.HasFile Then

                        ' File Size
                        If postedFile.ContentLength < 3145728 Then

                            ' Upload Document
                            postedFile.SaveAs(TreeViewBrowser.SelectedNode.Value & "\" & postedFile.FileName)

                            ' Update
                            LoadDirectory(TreeViewBrowser.SelectedNode)

                        Else

                            ' Display the Error Message
                            TableRowFileLimitExceeded.Visible = True

                        End If

                    End If
                Next


            End If

        End If

    End Sub
    Protected Sub ButtonDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDownload.Click

        ' If we have a Node Selected
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' Has this Value got a File Extention
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then

                ' A File
                Response.AppendHeader("Content-Disposition", "attachment; filename=" & Chr(34) & Path.GetFileName(TreeViewBrowser.SelectedNode.Value) & Chr(34))
                Response.TransmitFile(TreeViewBrowser.SelectedNode.Value)
                Response.End()

            End If

        End If

    End Sub
    Protected Sub ButtonRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRename.Click

        ' If we have a Selected Node
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' If this is not the Parent Node
            If Not TreeViewBrowser.SelectedNode.Parent Is Nothing Then

                ' Has this Value got a File Extention
                If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then

                    ' File - Init Fields
                    LabelUpdate.Text = "New Filename:"
                    TextBoxName.Text = TreeViewBrowser.SelectedNode.Text.Substring(0, TreeViewBrowser.SelectedNode.Text.IndexOf("."))
                    LabelFileExtension.Text = Path.GetFileName(TreeViewBrowser.SelectedNode.Value).Substring(Path.GetFileName(TreeViewBrowser.SelectedNode.Value).IndexOf("."))

                Else

                    ' Directory - Init Fields
                    LabelUpdate.Text = "New Directory Name:"
                    TextBoxName.Text = TreeViewBrowser.SelectedNode.Text
                    LabelFileExtension.Text = String.Empty

                End If

                ' Set to Updating
                Updating(True)

                ' Make the Update Row Visible
                TableRowUpdate.Visible = True

                ' Set Mode
                Session("AdminFileExplorerUpdateMode") = "Rename"

            End If

        End If

    End Sub
    Protected Sub ButtonMoveYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonMoveYes.Click

        ' If we have a Selected Node
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            If Convert.ToInt32(hdsource.Value) > 0 Then

                Dim bUpdated As Boolean = False
                LabelUpdate.Text = "New Directory Name:"
                TextBoxName.Text = Path.GetFullPath(TreeViewBrowser.SelectedNode.Value)
                If Not Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then
                    If Not Path.GetExtension(lblsourcefile.Text) <> String.Empty Then


                        Dim drjj = Path.GetFileName(lblsourcefile.Text)
                        Dim dest As String = Path.Combine(TextBoxName.Text, drjj)
                        Directory.Move(lblsourcefile.Text, dest)
                        'Next
                        hdsource.Value = 0
                        TableRowMove.Visible = False
                        bUpdated = True
                    Else

                        Dim drjj = Path.GetFileName(lblsourcefile.Text)
                        Dim dest As String = Path.Combine(TextBoxName.Text, drjj)
                        File.Move(lblsourcefile.Text, dest)
                        hdsource.Value = 0
                        TableRowMove.Visible = False
                        bUpdated = True

                    End If
                Else
                    TableRowMove.Visible = True
                    lblMove.Text = "Please select destination directory"
                    ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
                    ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")
                End If


                If (bUpdated) Then
                    Update(True)
                End If
            End If
        Else
            lblMove.Text = "Please select directory/File to move"
            ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
            ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If

    End Sub
    Protected Sub BtnMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMove.Click
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            If Convert.ToInt32(hdsource.Value) = 0 Then
                hdsource.Value = 1
                TableRowMove.Visible = True
                lblMove.Text = "please select destination directory"
                ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
                ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")
                ' Has this Value got a File Extention
                If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then

                    ' File - Init Fields
                    LabelUpdate.Text = "New Filename:"
                    TextBoxName.Text = Path.GetFullPath(TreeViewBrowser.SelectedNode.Value)
                    LabelFileExtension.Text = Path.GetFileName(TreeViewBrowser.SelectedNode.Value).Substring(Path.GetFileName(TreeViewBrowser.SelectedNode.Value).IndexOf("."))
                    lblsourcefile.Text = TextBoxName.Text
                Else

                    ' Directory - Init Fields
                    LabelUpdate.Text = "New Directory Name:"
                    TextBoxName.Text = Path.GetFullPath(TreeViewBrowser.SelectedNode.Value)
                    LabelFileExtension.Text = String.Empty
                    lblsourcefile.Text = TextBoxName.Text
                End If

            Else
                If Not TreeViewBrowser.SelectedNode Is Nothing Then

                    If (Path.GetFileName(lblsourcefile.Text) = Path.GetFileName(TreeViewBrowser.SelectedNode.Value)) Then
                        TableRowMove.Visible = True
                        lblMove.Text = "please select different destination directory"
                        ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
                        ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")
                    Else
                        If Path.GetExtension(lblsourcefile.Text) <> String.Empty Then

                            lblMove.Text = "Are you sure you want to move " & Path.GetFileName(lblsourcefile.Text) & " file"


                        Else
                            lblMove.Text = "Are you sure you want to move " & Path.GetFileName(lblsourcefile.Text) & " directory"

                        End If
                        TableRowMove.Visible = True
                        ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "block")
                        ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "block")
                    End If
                    ' Set to Updating
                    ' Updating(True)

                    ' Make the Update Row Visible


                    ' Set Mode
                    'Session("AdminFileExplorerUpdateMode") = "Rename"
                End If

            End If

        Else

            lblMove.Text = "Please select directory/File to move"
            ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
            ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")

        End If


    End Sub
    Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        ' If a Node has been Selected
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' If this is not the Parent Node
            If Not TreeViewBrowser.SelectedNode.Parent Is Nothing Then

                ' Save the Selected Node
                Session("AdminFileExplorerSelectedNode") = TreeViewBrowser.SelectedNode

                ' Updating
                Updating(True)

                ' Directory / File
                If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                    ' Directory
                    LabelDelete.Text = "Are you sure you want to delete the Directory named " & TreeViewBrowser.SelectedNode.Text & "?"

                Else

                    ' File
                    LabelDelete.Text = "Are you sure you want to delete the File named " & Path.GetFileName(TreeViewBrowser.SelectedNode.Value) & "?"

                End If

                ' Display the Row
                TableRowDelete.Visible = True

            End If

        End If

    End Sub
    Protected Sub ButtonNewFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNewFolder.Click

        ' If we have a Node Selected
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' If this is a Directory
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                ' Init Fields
                LabelUpdate.Text = "Directory Name:"
                TextBoxName.Text = String.Empty

                ' Set to Updating
                Updating(True)

                ' Display Row
                TableRowUpdate.Visible = True

                ' Set Mode
                Session("AdminFileExplorerUpdateMode") = "New"

            End If

        End If

    End Sub
    Protected Sub ButtonMoveNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonMoveNo.Click

        ' Hide the Delete Row
        TableRowMove.Visible = False
        hdsource.Value = 0
        ' Not Updating
        Updating(False)

    End Sub
    Protected Sub ButtonDeleteNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDeleteNo.Click

        ' Hide the Delete Row
        TableRowDelete.Visible = False

        ' Not Updating
        Updating(False)

    End Sub
    Private Function FindNode(ByVal tn As TreeNode, ByVal szValue As String, Optional ByRef tnResult As TreeNode = Nothing) As Boolean

        ' If this Matches, Return the Node
        If tn.Value = szValue Then
            Return True
        End If

        ' Loop through each Node
        For Each tnSub As TreeNode In tn.ChildNodes

            ' Find the Value
            If FindNode(tnSub, szValue, tnResult) Then
                tnResult = tnSub
            End If

        Next

        Return False

    End Function
    Private Sub Update(ByVal bParent As Boolean)

        ' Find Selected
        Dim tn As TreeNode = Nothing
        FindNode(TreeViewBrowser.Nodes(0), DirectCast(Session("AdminFileExplorerSelectedNode"), TreeNode).Value, tn)

        ' If Found, set to Root
        If Not tn Is Nothing Then

            ' If we are Updating the Parent
            If bParent Then

                ' Select Parent
                tn.Parent.Select()

            Else

                ' Select this Node
                tn.Select()

            End If

        Else

            ' Select Root
            TreeViewBrowser.Nodes(0).Select()

        End If

        ' Update
        TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)

    End Sub
    Protected Sub ButtonDeleteYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDeleteYes.Click

        ' If we have a Selected Node
        If Not Session("AdminFileExplorerSelectedNode") Is Nothing Then

            ' Assign to Local
            Dim tn As TreeNode = DirectCast(Session("AdminFileExplorerSelectedNode"), TreeNode)

            ' Directory / File
            If Path.GetExtension(tn.Value) = String.Empty Then

                ' Directory
                Directory.Delete(tn.Value, True)

            Else

                ' File
                File.Delete(tn.Value)

            End If

            ' Hide the Delete Row
            TableRowDelete.Visible = False

            ' Update
            Update(True)

            ' No Longer Updating
            Updating(False)

        End If

    End Sub
    Protected Sub ButtonUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click

        ' Do we have a Node Selected
        If Not Session("AdminFileExplorerSelectedNode") Is Nothing Then

            ' Has Text Been Added?
            If TextBoxName.Text.Trim <> String.Empty Then

                ' Depending on the Update
                Select Case Session("AdminFileExplorerUpdateMode")

                    Case "Rename"

                        ' Init Updated Flag
                        Dim bUpdated As Boolean = False

                        ' Assign to Local Vars
                        Dim tn As TreeNode = DirectCast(Session("AdminFileExplorerSelectedNode"), TreeNode)

                        ' Is this a File or Directory?
                        If Path.GetExtension(tn.Value) <> String.Empty Then

                            ' Only do the following if Source and Destination differ
                            If tn.Value <> Path.GetDirectoryName(tn.Value) & "\" & TextBoxName.Text.Trim & LabelFileExtension.Text.Trim Then

                                ' File
                                File.Move(tn.Value, Path.GetDirectoryName(tn.Value) & "\" & TextBoxName.Text.Trim & LabelFileExtension.Text.Trim)

                                ' Set Flag
                                bUpdated = True

                            End If

                        Else

                            ' Only do the following if Source and Destination differ
                            If tn.Value <> Directory.GetParent(tn.Value).FullName & "\" & TextBoxName.Text.Trim Then

                                ' Directory
                                Directory.Move(tn.Value, Directory.GetParent(tn.Value).FullName & "\" & TextBoxName.Text.Trim)

                                ' Set Flag
                                bUpdated = True

                            End If

                        End If

                        ' If Updates were made
                        If bUpdated Then

                            ' Update
                            Update(True)

                        End If

                    Case "New"

                        ' Assign to Local Vars
                        Dim tn As TreeNode = DirectCast(Session("AdminFileExplorerSelectedNode"), TreeNode)

                        ' Create the Directory
                        Directory.CreateDirectory(tn.Value & "\" & TextBoxName.Text.Trim)

                        ' Update
                        Update(False)

                End Select

            End If

        End If

        ' Hide Update Row
        TableRowUpdate.Visible = False

        ' Set to Not Updating
        Updating(False)

    End Sub
    Protected Sub lblDocuments_Click(sender As Object, e As EventArgs)
        lidocum.Attributes.Add("class", "active")
        ligen.Attributes.Remove("class")
        lidec.Attributes.Remove("class")
        liimage.Attributes.Remove("class")
        lihist.Attributes.Remove("class")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tabPropertyPayment.Style.Add(HtmlTextWriterStyle.Display, "none")
        lnkhistory.Style.Add(HtmlTextWriterStyle.Display, "none")
        'TableDocuments.Enabled = True
        TableDocuments.Visible = True
        TableEmailDocument.Visible = False

    End Sub
    Private Sub bindstatus()
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        'sql(0) = New SqlParameter("@LanguageId", CUtilities.GetLanguageID(Session("Language")))
        'Passing only for english parameter is 1 
        sql(0) = New SqlParameter("@LanguageId", 1)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Status", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListStatus.DataSource = dt
            DropDownListStatus.DataTextField = "text"
            DropDownListStatus.DataValueField = "id"
            DropDownListStatus.DataBind()
        End If
    End Sub
    Private Sub bindcountry()

    End Sub
    Private Sub bindlocation()
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@LanguageId", CUtilities.GetLanguageID(Session("Language")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_LocationByLangId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            drplocation.DataSource = dt
            drplocation.DataTextField = "text"
            drplocation.DataValueField = "id"
            drplocation.DataBind()
        End If
    End Sub
    Private Sub bindviews()
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@LanguageId", CUtilities.GetLanguageID(Session("Language")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_ViewsByLangId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            drpviews.DataSource = dt
            drpviews.DataTextField = "text"
            drpviews.DataValueField = "id"
            drpviews.DataBind()
        End If
    End Sub
    Private Sub bindyears()
        drpyearconstructed.Items.Clear()

        For nIndex = Today.Year To 1850 Step -1

            ' Add Items
            drpyearconstructed.Items.Add(nIndex.ToString.Trim)

        Next
        Dim licategory As New ListItem("--- Select ---", "0")

        drpyearconstructed.Items.Insert(0, licategory)
        ' drpyearconstructed.Items.Insert(0, "--- Select ---")

    End Sub
    Private Sub bindlawyer()
        Dim CUtilities As New ClassUtilities
        Dim dt As DataTable
        If Convert.ToBoolean(Session("AdminUser")) Then
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Lawyer").Tables(0)
        Else
            Dim sql As SqlParameter() = New SqlParameter(0) {}
            sql(0) = New SqlParameter("@Contact_Partner_Id", Convert.ToInt32(Session("ContactPartnerID")))

            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Lawyer_By_Partner_Id", sql).Tables(0)
        End If

        If dt.Rows.Count > 0 Then
            drpVendrlaywer.DataSource = dt
            drpVendrlaywer.DataTextField = "text"
            drpVendrlaywer.DataValueField = "id"
            drpVendrlaywer.DataBind()
            Dim licategory As New ListItem("-- None --", "0")
            drpVendrlaywer.Items.Insert(0, licategory)
        End If
    End Sub
    Private Sub bedrooms()
        drpbedrooms.Items.Clear()
        For nIndex = 0 To 15
            ' Add Items
            drpbedrooms.Items.Add(nIndex.ToString.Trim)
        Next
    End Sub
    Private Sub bathrooms()
        drpbathrooms.Items.Clear()
        For nIndex = 0 To 15
            ' Add Items
            drpbathrooms.Items.Add(nIndex.ToString.Trim)
        Next
    End Sub
    Private Sub bindpatner()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Pertner_show").Tables(0)
        If dt.Rows.Count > 0 Then
            drpPartner.DataSource = dt
            drpPartner.DataTextField = "text"
            drpPartner.DataValueField = "id"
            drpPartner.DataBind()
        End If
        'If Not Session("ContactPartnerID") Is Nothing Then
        '    drpPartner.SelectedValue = Convert.ToInt16(Session("ContactPartnerId"))
        'End If
    End Sub
    Protected Sub drppartner_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindbroker()
    End Sub
    Private Sub bindbroker()
        'Dim sql As SqlParameter() = New SqlParameter(0) {}
        'sql(0) = New SqlParameter("@PartnerId", Convert.ToInt32(drpPartner.SelectedValue))
        'Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Contact_Broker_By_PartnerId", sql).Tables(0)
        'If dt.Rows.Count > 0 Then
        'drpBroker.DataSource = dt
        'drpBroker.DataTextField = "text"
        'drpBroker.DataValueField = "id"
        'drpBroker.DataBind()
        'Dim licategory As New ListItem("-- None--", "0")
        'drpBroker.Items.Insert(0, licategory)
        'Else

        'End If
    End Sub
    Protected Sub btnsaveproperty_Click(sender As Object, e As EventArgs)
        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        If Not Session("PropertyAdminImages") Is Nothing Then
            CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
        End If
        Dim bError As Boolean
        bError = PopulateSaveDataGeneral(CProperty)
        If Not bError Then
            If hdnListedById.Value = "0" And String.IsNullOrEmpty(drpListedByUsers.SelectedValue) Then
                lblmessage.Text = "Listed By could not be 0 value... Please update Listed By...."
                Return
            End If
            ' Save this Property to the Database
            '  bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            CProperty.CAReference = txtproppartref.Text
            'If Convert.ToInt32(Session("ContactPartnerID")) <> 3864 And Convert.ToInt32(Session("ContactPartnerID")) <> 9103 And Convert.ToInt32(Session("ContactPartnerID")) <> 3873 And Convert.ToInt32(Session("ContactPartnerID")) <> 9495 And Convert.ToInt32(Session("ContactPartnerID")) <> 7666 And Convert.ToInt32(Session("ContactPartnerID")) <> 10109 And Convert.ToInt32(Session("ContactPartnerID")) <> 10274 And Convert.ToInt32(Session("ContactPartnerID")) <> 10309 And Convert.ToInt32(Session("ContactPartnerID")) <> 10391 And Convert.ToInt32(Session("ContactPartnerID")) <> 14429 And Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID Then
            If Convert.ToInt32(Session("ContactPartnerID")) = -1 And Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID Then
                bError = CProperty.SaveNew(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            Else
                bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            End If
            Dim Property_Ref As String = lblpropref.Text
            If CheckBoxFeature.Checked Then
                If hdnVendorPrice.Value <> txtVendorPrice.Text Then
                    txtStartDate.Text = DateTime.Now.Date()
                    txtExpiryDate.Text = DateTime.Now.Date().AddMonths(5)
                End If
                Dim feature_start_date As String = txtStartDate.Text
                Dim feature_expiry_date As String = txtExpiryDate.Text
                Dim Contact_Id As Int32 = Convert.ToInt32(Session("ContactID"))
                Dim sql As SqlParameter() = New SqlParameter(4) {}
                sql(0) = New SqlParameter("@Property_Ref", Property_Ref)
                sql(1) = New SqlParameter("@Featured_Prop_Date", feature_start_date)
                sql(2) = New SqlParameter("@Expiry_Date", feature_expiry_date)
                sql(3) = New SqlParameter("@Contact_Id", Contact_Id)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Featured_Property_Insert", sql)
            Else
                Dim sql As SqlParameter() = New SqlParameter(1) {}
                sql(0) = New SqlParameter("@Property_Ref", Property_Ref)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Featured_Property_Delete", sql)
            End If

            lblmessage.Text = "Property Details Saved"
            lblpartmessage.Text = "Property Details Saved"
            ButtonWindowcard.Visible = (CProperty.StatusID = 2 Or CProperty.StatusID = 7)
            TableRowBuyerLawyer.Visible = CProperty.StatusID = 5 Or CProperty.StatusID = 7
            If (CProperty.NumberOfImages > 0) Then
                ButtonViewingPhotos.Visible = True
            End If
            ' If we had an Error
            If bError Then
                lblpartmessage.Text = "An error occurred whilst saving this property to the database"
                lblmessage.Text = "An error occurred whilst saving this property to the database"
            Else

                'Call Manage Property_Partner_Ref function 
                Manage_Property_Partner_Ref(CProperty.ID)
                Dim dtListerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "select contact_email from contact where contact_id in(select Listed_By_Contact_Id from property where Property_Ref='" & Property_Ref.ToString() & "')").Tables(0)
                Dim listerEmail As String = ""
                If dtListerDetails.Rows.Count > 0 Then
                    listerEmail = dtListerDetails.Rows(0)("contact_email").ToString()
                End If
                'Call Inland API function after create new property
                If Request.QueryString("PropertyId") = "" Then

                    'Try
                    '    Dim createPropertyReturnJason As String
                    '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/property/create/" & CProperty.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                    '    httpRequest.ContentType = "application/json"
                    '    httpRequest.Method = "GET"
                    '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                    '        Using stream As Stream = httpResponse.GetResponseStream()
                    '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
                    '            createPropertyReturnJason = json
                    '        End Using
                    '    End Using
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property")
                    '    sql(1) = New SqlParameter("@ActionType", "Create")
                    '    sql(2) = New SqlParameter("@JasonString", createPropertyReturnJason)
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'Catch ex As Exception
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property")
                    '    sql(1) = New SqlParameter("@ActionType", "Create")
                    '    sql(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'End Try

                    'When saving the first time a new added property, Send notification Email to related office + lister : 

                    Try
                        ' Define a New Email
                        Dim CEmailPropertyCreated As New ClassEmail
                        Dim mailTitlePropertyCreated As String
                        Dim mailBodyPropertyCreated As String
                        mailTitlePropertyCreated = "New Property ref " & Property_Ref.ToString() & " has been created"
                        mailBodyPropertyCreated = "Property " & Property_Ref.ToString() & " has just been created with status " & DropDownListStatus.SelectedItem.Text & ""
                        Dim isDevORTraining As Int16 = 0
                        If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                            CEmailPropertyCreated.SendEmail_Notification_Single_Fuction(mailTitlePropertyCreated, mailBodyPropertyCreated, CProperty.PartnerID, listerEmail, "NewPropertyCreated", "Dev", 1)
                            isDevORTraining = 1
                        End If
                        If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                            CEmailPropertyCreated.SendEmail_Notification_Single_Fuction(mailTitlePropertyCreated, mailBodyPropertyCreated, CProperty.PartnerID, listerEmail, "NewPropertyCreated", "Training", 1)
                            isDevORTraining = 1
                        End If
                        If isDevORTraining = 0 Then
                            CEmailPropertyCreated.SendEmail_Notification_Single_Fuction(mailTitlePropertyCreated, mailBodyPropertyCreated, CProperty.PartnerID, listerEmail, "NewPropertyCreated", "Live", 1)
                        End If

                    Catch ex As Exception

                    End Try
                    Response.Redirect("AddProperty.aspx?PropertyId=" & CProperty.ID.ToString() & "&PageIndex=1&Ref=&Address=&type=0&Area=0&Town=0&Beds=0&Bath=0&status=0")
                Else

                    'Save with in property history & send emails to three person & salesperson accordingly. 
                    If hdnPublicPrice.Value <> txtPublicPrice.Text And DropDownListStatus.SelectedItem.Value <> "3" Then
                        'Price been changed so send email accordingly & save in property history table
                        Dim mailTitlePriceChange As String
                        Dim mailBodyPriceChange As String = "Public Price been changed for Property Reference " & Property_Ref.ToString() & " From Old Price " & hdnPublicPrice.Value & " To New Price " & txtPublicPrice.Text
                        Dim mailBodyPriceChangeForHistory As String = "Public Price been changed for Property Reference " & Property_Ref.ToString() & " From Old Price " & hdnPublicPrice.Value & " To New Price " & txtPublicPrice.Text
                        mailBodyPriceChange = mailBodyPriceChange & "<br/><br/>"

                        Try
                            ' Define a New Email
                            Dim CEmailPriceChange As New ClassEmail
                            Dim isDevORTraining1 As Int16 = 0
                            mailTitlePriceChange = "Property Reference " & Property_Ref.ToString() & " Public Price Changed"
                            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                mailBodyPriceChange = mailBodyPriceChange & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
                                CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, CProperty.PartnerID, listerEmail, "PriceChanged", "Dev", 1)
                                isDevORTraining1 = 1
                            End If
                            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                mailBodyPriceChange = mailBodyPriceChange & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
                                CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, CProperty.PartnerID, listerEmail, "PriceChanged", "Training", 1)
                                isDevORTraining1 = 1
                            End If
                            If isDevORTraining1 = 0 Then
                                mailBodyPriceChange = mailBodyPriceChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
                                CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, CProperty.PartnerID, listerEmail, "PriceChanged", "Live", 1)
                            End If

                        Catch ex As Exception

                        End Try

                        'Insert in property history table accordingly 

                        Dim sqlPHPriceChange As SqlParameter() = New SqlParameter(7) {}
                        sqlPHPriceChange(0) = New SqlParameter("@Property_Ref", Property_Ref.ToString())
                        sqlPHPriceChange(1) = New SqlParameter("@Type_Id", 2)
                        sqlPHPriceChange(2) = New SqlParameter("@History_Text", mailBodyPriceChangeForHistory)
                        sqlPHPriceChange(3) = New SqlParameter("@Modified_By", Convert.ToInt32(Session("ContactID")))
                        sqlPHPriceChange(4) = New SqlParameter("@PriceChanged", 1)
                        sqlPHPriceChange(5) = New SqlParameter("@NewPrice", Convert.ToInt32(txtPublicPrice.Text))
                        sqlPHPriceChange(6) = New SqlParameter("@OldPrice", Convert.ToInt32(hdnPublicPrice.Value))
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert_PriceStatusChange", sqlPHPriceChange)

                    End If
                    If hdnPropertyStatus.Value <> DropDownListStatus.SelectedItem.Text Then
                        'Status been changed so send email accordingly & save in property history table
                        Dim mailTitleStatusChange As String
                        Dim mailBodyStatusChange As String = "Property Status been changed for Property Reference " & Property_Ref.ToString() & "  From " & hdnPropertyStatus.Value & " To " & DropDownListStatus.SelectedItem.Text
                        Dim mailBodyStatusChangeForHistory As String = "Property Status been changed for Property Reference " & Property_Ref.ToString() & "  From " & hdnPropertyStatus.Value & " To " & DropDownListStatus.SelectedItem.Text
                        mailBodyStatusChange = mailBodyStatusChange & "<br/><br/>"
                        mailTitleStatusChange = "Property Reference " & Property_Ref.ToString() & " Property Status is now " & DropDownListStatus.SelectedItem.Text
                        Try
                            ' Define a New Email
                            Dim CEmailStatusChange As New ClassEmail
                            Dim isDevORTraining2 As Int16 = 0
                            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                mailBodyStatusChange = mailBodyStatusChange & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
                                CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListStatus.SelectedItem.Text, "Dev", 1)
                                isDevORTraining2 = 1
                            End If
                            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                mailBodyStatusChange = mailBodyStatusChange & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
                                CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListStatus.SelectedItem.Text, "Training", 1)
                                isDevORTraining2 = 1
                            End If
                            If isDevORTraining2 = 0 Then
                                mailBodyStatusChange = mailBodyStatusChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & Property_Ref.ToString() & "</a>"
                                CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListStatus.SelectedItem.Text, "Live", 1)
                            End If

                        Catch ex As Exception

                        End Try

                        'Insert in property history table accordingly 

                        Dim sqlPHStatusChange As SqlParameter() = New SqlParameter(7) {}
                        sqlPHStatusChange(0) = New SqlParameter("@Property_Ref", Property_Ref.ToString())
                        sqlPHStatusChange(1) = New SqlParameter("@Type_Id", 7)
                        sqlPHStatusChange(2) = New SqlParameter("@History_Text", mailBodyStatusChangeForHistory)
                        sqlPHStatusChange(3) = New SqlParameter("@Modified_By", Convert.ToInt32(Session("ContactID")))
                        sqlPHStatusChange(4) = New SqlParameter("@PriceChanged", DBNull.Value)
                        sqlPHStatusChange(5) = New SqlParameter("@NewPrice", DBNull.Value)
                        sqlPHStatusChange(6) = New SqlParameter("@OldPrice", DBNull.Value)
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert_PriceStatusChange", sqlPHStatusChange)

                        'As status been changed check if status been changed from Under Offer To Sales OR Withdraw Then update Buyer_Id to 0 in property table
                        If DropDownListStatus.SelectedItem.Value = "2" Or DropDownListStatus.SelectedItem.Value = "8" Then
                            'Update buyer_id to 0 for this particular property
                            Dim sqlUpdateBuyerId As SqlParameter() = New SqlParameter(0) {}
                            sqlUpdateBuyerId(0) = New SqlParameter("@Property_Ref", Property_Ref.ToString())
                            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_BuyerId", sqlUpdateBuyerId)
                        End If

                        'If property selected status is Sold OR Sold By Comp OR Withdraw then remove property from featured_property table
                        If DropDownListStatus.SelectedItem.Value = "5" Or DropDownListStatus.SelectedItem.Value = "6" Or DropDownListStatus.SelectedItem.Value = "8" Then
                            'Remove from featured_property table by selecting property reference
                            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "delete from featured_property where property_ref='" & Property_Ref.ToString() & "'")
                        End If

                    End If
                    hdnPropertyStatus.Value = DropDownListStatus.SelectedItem.Text
                    hdnPublicPrice.Value = txtPublicPrice.Text

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Try
                    '    Dim updatePropertyReturnJason As String
                    '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/property/update/" & CProperty.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                    '    httpRequest.ContentType = "application/json"
                    '    httpRequest.Method = "GET"
                    '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                    '        Using stream As Stream = httpResponse.GetResponseStream()
                    '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
                    '            updatePropertyReturnJason = json
                    '        End Using
                    '    End Using
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", updatePropertyReturnJason)
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'Catch ex As Exception
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'End Try
                End If
            End If
            If drpListedByUsers.Visible = True Then
                If Not String.IsNullOrEmpty(drpListedByUsers.SelectedValue) Then
                    lblListedBy.Text = "By " & drpListedByUsers.SelectedItem.Text & " - " & CProperty.ListedByPartner
                End If
            End If
            'Load property details again 
            Dim CDataAccess As New ClassDataAccess
            CProperty.Load(lblpropref.Text)
            CDataAccess = Nothing
            Session("AdminPropertySelected") = CProperty
            CProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
            lblHistoryVendorPrice.Text = txtVendorPrice.Text
            lblHistoryPublicPrice.Text = txtPublicPrice.Text
            lblHistoryOriginalPrice.Text = txtOriginalPrice.Text
            LoadHistory(CProperty)
        End If
    End Sub

    Public Sub Manage_Property_Partner_Ref(PropertyId As Int32)
        If txtPropertyPartnerRef.Text <> "" Then
            Dim sql As SqlParameter() = New SqlParameter(2) {}
            sql(0) = New SqlParameter("@Property_Id", PropertyId)
            sql(1) = New SqlParameter("@Partner_Id", Convert.ToInt32(drpPartner.SelectedValue))
            sql(2) = New SqlParameter("@Reference", txtPropertyPartnerRef.Text)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Partner_Ref_Insert_Update", sql)
        End If
    End Sub

    Protected Sub ButtonUploadImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUploadImage.Click

        ' If the Session has Expired
        If Session("ContactPartnerID") Is Nothing Then
            Response.Redirect("~/AgentLogin.aspx")
        Else

            ' Check the Session hasn't Expired
            If Not Session("PropertyAdminImages") Is Nothing Then
                For Each postedFile As HttpPostedFile In FileUploadImage.PostedFiles
                    ' If we have a Filename
                    If FileUploadImage.HasFile Then

                        ' Upload the Image
                        UploadImage(postedFile.FileName, postedFile.InputStream)
                        btnimageprop.BackColor = Drawing.Color.Red
                        btnimageprop.ForeColor = Drawing.Color.White
                        btnimageprop.Font.Bold = True

                    End If
                Next

            End If

        End If

    End Sub
    Private Sub UploadImage(ByVal szFilename As String, ByVal strFile As IO.Stream, Optional ByVal bBulk As Boolean = False)

        ' Only do the Following if we don't already have the Maximum Number of Properties
        If DirectCast(Session("PropertyAdminImages"), ClassImages).Count < 16 Then

            ' Mark Property as Dirty
            'MakeDirty()

            ' If we haven't already Uploaded this File
            If Not DirectCast(Session("PropertyAdminImages"), ClassImages).Contains(szFilename) Then

                ' Get the IA Reference for this Property
                Dim CDataAccess As New ClassDataAccess

                ' Load the Property
                Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)

                ' Define a New Image
                Dim CImage As New ClassImage(CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), CProperty.Reference), szFilename, True)

                ' Tidy
                CDataAccess = Nothing

                ' If the Directory does not Exist
                If Not Directory.Exists(CImage.ImageDirectory) Then

                    ' Create the Directory
                    Directory.CreateDirectory(CImage.ImageDirectory)

                End If

                ' Resize and Apply IA Watermark
                Dim CUtilities As New ClassUtilities
                Dim imgImage As Drawing.Image = Drawing.Image.FromStream(strFile)
                CUtilities.ProcessPropertyImage(imgImage)
                'CUtilities.ApplyIAWatermark(im gImage)
                CUtilities.ApplyIAWatermarkCenter(imgImage)
                CUtilities = Nothing

                ' Save the Image
                imgImage.Save(Server.MapPath(CImage.CleanPath & CImage.Filename))

                ' Tidy
                imgImage.Dispose()

                ' If this is Bulk
                If bBulk Then

                    ' Bulk - Append
                    DirectCast(Session("PropertyAdminImages"), ClassImages).Append(CImage)

                Else

                    ' Single

                    ' Assign Affected Index
                    Dim alAffectedIndexes As New ArrayList

                    ' Depending on the Option Selected
                    Select Case DropDownListUploadImageOption.SelectedIndex

                        Case 0
                            ' Append
                            DirectCast(Session("PropertyAdminImages"), ClassImages).Append(CImage)
                            alAffectedIndexes.Add(DirectCast(Session("PropertyAdminImages"), ClassImages).Count)

                        Case 1
                            ' Prepend
                            DirectCast(Session("PropertyAdminImages"), ClassImages).Prepend(CImage)

                            ' Redraw Everything
                            alAffectedIndexes = Nothing

                        Case Else
                            ' Replace Main
                            DirectCast(Session("PropertyAdminImages"), ClassImages).ReplaceMain(CImage)
                            alAffectedIndexes.Add(1)

                    End Select

                    ' Display Images
                    DisplayImages(alAffectedIndexes)

                    ' Tidy
                    If Not alAffectedIndexes Is Nothing Then
                        alAffectedIndexes.Clear()
                    End If
                    alAffectedIndexes = Nothing

                    ' Enable / Disable Image Upload Button
                    DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)

                End If

            End If

        End If

    End Sub
    Private Sub DisplayImages(Optional ByVal alAffectedIndexes As ArrayList = Nothing, Optional ByVal bDeletion As Boolean = False)

        ' Local Vars
        Dim nIndex As Integer
        Dim mpContentPlaceHolder As ContentPlaceHolder
        mpContentPlaceHolder = CType(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        ' If we have Loaded Images
        If Not Session("PropertyAdminImages") Is Nothing Then

            ' If we aren't Dealing with Affected Indexes
            If alAffectedIndexes Is Nothing Then

                ' For each Image

                For nIndex = 1 To 16

                    ' If we have a URL as this Location
                    If nIndex <= DirectCast(Session("PropertyAdminImages"), ClassImages).Count Then

                        ' Assign the URL to this Control

                        DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImagenw).LoadImage(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage))

                        ' Set Header Image
                        DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImagenw).MakeHeaderImage(nIndex = 1)

                        ' Enable / Disable
                        DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImagenw).Enable(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage).Enabled)

                        ' Make Visible
                        mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim).Visible = True

                    Else

                        ' Make Invisible

                        ' AdminPropertyImage1.Visible = True


                        mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim).Visible = False
                    End If

                Next

            Else

                ' Specific Indexes being Updated
                For Each nIndex In alAffectedIndexes

                    ' Assign the URL to this Control
                    DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & (nIndex).ToString.Trim), WebUserControlAdminPropertyImagenw).LoadImage(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage))

                    ' Set Header Image
                    DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & (nIndex).ToString.Trim), WebUserControlAdminPropertyImagenw).MakeHeaderImage(nIndex = 1)

                    ' Make Visible
                    mpContentPlaceHolder.FindControl("AdminPropertyImage" & (nIndex).ToString.Trim).Visible = True

                Next

            End If

        End If

    End Sub
    Protected Sub DropDownListUploadImageOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListUploadImageOption.SelectedIndexChanged
        ' Make the Upload Image Visible / Invisible
        TableRowImageOptions.Visible = (Not AdminPropertyImage16.Visible) Or (AdminPropertyImage16.Visible And DropDownListUploadImageOption.SelectedIndex = 2)
        AjaxBulkFileUploadImage.Visible = TableRowImageOptions.Visible
    End Sub
    Protected Sub btndescription_Click(sender As Object, e As EventArgs)
        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        Dim bError As Boolean
        bError = PopulateSaveDataDescription(CProperty)
        ' If we have Images
        If Not Session("PropertyAdminImages") Is Nothing Then
            CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
        End If
        If Not bError Then

            ' Save this Property to the Database
            bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            lbldescmessage.Text = "Property Details Saved"
            ' If we had an Error
            If bError Then
                ' szSaveMessage = "An error occurred whilst saving this property to the database"
            Else
                If Not Request.QueryString("PropertyId") = "" Then
                    'Try
                    '    Dim updatePropertyReturnJason As String
                    '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/property/update/" & CProperty.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                    '    httpRequest.ContentType = "application/json"
                    '    httpRequest.Method = "GET"
                    '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                    '        Using stream As Stream = httpResponse.GetResponseStream()
                    '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
                    '            updatePropertyReturnJason = json
                    '        End Using
                    '    End Using
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property-Description")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", updatePropertyReturnJason)
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'Catch ex As Exception
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property-Description")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'End Try
                End If
            End If
        End If
    End Sub
    Protected Sub TextBoxShortDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxShortDescription.TextChanged
        ' Define Regex
        Dim rgx As Regex = New Regex("[^a-zA-Z0-9 -]")
        ' If the Address has Changed
        If rgx.Replace(DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)), "") <> rgx.Replace(TextBoxShortDescription.Text.Trim, "") Then
            ' Highlight Save
            ButtonSaveShortDescription.BackColor = Drawing.Color.Red
            ButtonSaveShortDescription.ForeColor = Drawing.Color.White
            ButtonSaveShortDescription.Font.Bold = True
        Else
            ' Remove Highlight
            ButtonSaveShortDescription.BackColor = Nothing
            ButtonSaveShortDescription.ForeColor = Nothing
            ButtonSaveShortDescription.Font.Bold = False
        End If
    End Sub
    Protected Sub TextBoxDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxDescription.TextChanged
        ' Define Regex
        Dim rgx As Regex = New Regex("[^a-zA-Z0-9 -]")
        ' If the Address has Changed
        If rgx.Replace(DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)), "") <> rgx.Replace(TextBoxDescription.Text.Trim, "") Then
            ' Highlight Save
            ButtonSaveDescription.BackColor = Drawing.Color.Red
            ButtonSaveDescription.ForeColor = Drawing.Color.White
            ButtonSaveDescription.Font.Bold = True
        Else
            ' Remove Highlight
            ButtonSaveDescription.BackColor = Nothing
            ButtonSaveDescription.ForeColor = Nothing
            ButtonSaveDescription.Font.Bold = False
        End If
    End Sub
    Protected Sub ButtonAutoTranslate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAutoTranslate.Click

        ' Translating to the Remaining Languages - DESCRIPTIONS

        ' For each Language
        For Each lstItem As ListItem In DropDownListLanguage.Items

            ' If this is the Selected Language
            If lstItem.Selected Then

                ' Simply Save Text
                DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = TextBoxDescription.Text.Trim

            Else

                ' Translate and Add to the Array
                Dim CUtilities As New ClassUtilities
                DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = CUtilities.TranslateNew(TextBoxDescription.Text.Trim, lstItem.Value, DropDownListLanguage.SelectedValue)
                CUtilities = Nothing

            End If

        Next

        ' Make the Save Button Clean
        ButtonSaveDescription.BackColor = Nothing
        ButtonSaveDescription.ForeColor = Nothing
        ButtonSaveDescription.Font.Bold = False

        ' Dirty
        ' MakeDirty()

        ' Display Message
        LabelMessage.Text = "Translations have been Completed"
        LabelMessage.Visible = True

    End Sub
    Protected Sub ButtonAutoTranslateShort_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAutoTranslateShort.Click

        ' Translating to the Remaining Languages - SHORT DESCRIPTIONS

        ' For each Language
        For Each lstItem As ListItem In DropDownListLanguage.Items
            ' If this is the Selected Language
            If lstItem.Selected Then
                ' Simply Save Text
                DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = TextBoxShortDescription.Text.Trim
            Else
                ' Translate and Add to the Array
                Dim CUtilities As New ClassUtilities
                DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = CUtilities.TranslateNew(TextBoxShortDescription.Text.Trim, lstItem.Value, DropDownListLanguage.SelectedValue)
                CUtilities = Nothing
            End If
        Next

        ' Make the Save Button Clean
        ButtonSaveShortDescription.BackColor = Nothing
        ButtonSaveShortDescription.ForeColor = Nothing
        ButtonSaveShortDescription.Font.Bold = False

        ' Dirty
        'MakeDirty()

        ' Display Message
        LabelMessageShort.Text = "Translations have been Completed"
        LabelMessageShort.Visible = True

    End Sub
    Protected Sub ButtonSaveDescription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSaveDescription.Click

        ' Mark the Property as Dirty
        ' MakeDirty()

        ' Simply Save Text
        DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)) = TextBoxDescription.Text.Trim

        ' Display Message
        LabelMessage.Text = "Description has been Saved"
        LabelMessage.Visible = True

        ' Re Enable Postback
        TextBoxDescription.AutoPostBack = True

        ' Clean 
        ButtonSaveDescription.BackColor = Nothing
        ButtonSaveDescription.ForeColor = Nothing
        ButtonSaveDescription.Font.Bold = False

    End Sub
    Protected Sub ButtonSaveShortDescription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSaveShortDescription.Click

        ' Mark the Property as Dirty
        '  MakeDirty()

        ' Simply Save Text
        DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)) = TextBoxShortDescription.Text.Trim

        ' Display Message
        LabelMessageShort.Text = "Short Description has been Saved"
        LabelMessageShort.Visible = True

        ' Re Enable Postback
        TextBoxShortDescription.AutoPostBack = True

        ' Clean 
        ButtonSaveShortDescription.BackColor = Nothing
        ButtonSaveShortDescription.ForeColor = Nothing
        ButtonSaveShortDescription.Font.Bold = False

    End Sub
    Public Sub ImageLeft(ByVal nPosition As Integer)

        ' Local Vars
        Dim alAffectedIndexes As ArrayList

        ' Move Images Left
        alAffectedIndexes = DirectCast(Session("PropertyAdminImages"), ClassImages).ImageLeft(nPosition)

        ' If we have Affected Indexes
        If alAffectedIndexes.Count > 0 Then

            ' Display the Images
            DisplayImages(alAffectedIndexes)

        End If

        ' Tidy
        alAffectedIndexes.Clear()
        alAffectedIndexes = Nothing

        ' Make Dirty
        '  MakeDirty()

    End Sub
    Public Sub ImageRight(ByVal nPosition As Integer)

        ' Local Vars
        Dim alAffectedIndexes As ArrayList

        ' Move Images Right
        alAffectedIndexes = DirectCast(Session("PropertyAdminImages"), ClassImages).ImageRight(nPosition)

        ' If we have Affected Indexes
        If alAffectedIndexes.Count > 0 Then

            ' Display the Images
            DisplayImages(alAffectedIndexes)

        End If

        ' Tidy
        alAffectedIndexes.Clear()
        alAffectedIndexes = Nothing

        ' Make Dirty
        '  MakeDirty()

    End Sub
    Public Sub ImageUp(ByVal nPosition As Integer)

        ' Local Vars
        Dim alAffectedIndexes As ArrayList

        ' Move Images Right
        alAffectedIndexes = DirectCast(Session("PropertyAdminImages"), ClassImages).ImageUp(nPosition)

        ' If we have Affected Indexes
        If alAffectedIndexes.Count > 0 Then

            ' Display the Images
            DisplayImages(alAffectedIndexes)

        End If

        ' Tidy
        alAffectedIndexes.Clear()
        alAffectedIndexes = Nothing

        ' Make Dirty
        '  MakeDirty()

    End Sub
    Public Sub ImageDown(ByVal nPosition As Integer)

        ' Local Vars
        Dim alAffectedIndexes As ArrayList

        ' Move Images Right
        alAffectedIndexes = DirectCast(Session("PropertyAdminImages"), ClassImages).ImageDown(nPosition)

        ' If we have Affected Indexes
        If alAffectedIndexes.Count > 0 Then

            ' Display the Images
            DisplayImages(alAffectedIndexes)

        End If

        ' Tidy
        alAffectedIndexes.Clear()
        alAffectedIndexes = Nothing

        ' Make Dirty
        ' MakeDirty()

    End Sub
    Public Sub ImageDelete(ByVal nPosition As Integer)

        ' Remove this from the Array of those Selected
        DirectCast(Session("PropertyAdminImages"), ClassImages).Remove(nPosition)

        ' Display the Images
        DisplayImages(, True)

        ' Enable / Disable Image Upload Button
        DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)

        ' Make Dirty
        '  MakeDirty()
        btnimageprop.BackColor = Drawing.Color.Red
        btnimageprop.ForeColor = Drawing.Color.White
        btnimageprop.Font.Bold = True
        updvendor.Update()

    End Sub
    Protected Sub btnimageprop_Click(sender As Object, e As EventArgs)
        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        Dim bError As Boolean

        ' If we have Images
        If Not Session("PropertyAdminImages") Is Nothing Then
            CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
        End If

        ' Save this Property to the Database
        bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
        lblimage.Text = "Property Details Saved"
        ButtonViewingPhotos.Visible = True
        ' If we had an Error

        If bError Then
            ' szSaveMessage = "An error occurred whilst saving this property to the database"
        Else
            If Not Request.QueryString("PropertyId") = "" Then
                'Try
                '    Dim updatePropertyReturnJason As String
                '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/property/update/" & CProperty.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                '    httpRequest.ContentType = "application/json"
                '    httpRequest.Method = "GET"
                '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                '        Using stream As Stream = httpResponse.GetResponseStream()
                '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
                '            updatePropertyReturnJason = json
                '        End Using
                '    End Using
                '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                '    sql(0) = New SqlParameter("@Title", "Property-Image")
                '    sql(1) = New SqlParameter("@ActionType", "Update")
                '    sql(2) = New SqlParameter("@JasonString", updatePropertyReturnJason)
                '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                'Catch ex As Exception
                '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                '    sql(0) = New SqlParameter("@Title", "Property-Image")
                '    sql(1) = New SqlParameter("@ActionType", "Update")
                '    sql(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                'End Try
            End If
        End If

        DisplayImages(, True)
        updvendor.Update()
        btnimageprop.BackColor = System.Drawing.ColorTranslator.FromHtml("#303194")
    End Sub
    Private Sub MakeDirty()

        ' Check the Session is still Active
        If Session("AdminPropertySelected") Is Nothing Or Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Agent Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Disable Make Dirty
            ' EnableMakeDirty(False)

            ' If this is the Paryner ID
            If DirectCast(Session("AdminPropertySelected"), ClassProperty).PartnerID = Convert.ToInt32(Session("ContactPartnerID")) Or Convert.ToBoolean(Session("AdminUser")) Then

            End If

        End If

    End Sub
    Protected Sub btnfeater_Click(sender As Object, e As EventArgs)
        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        Dim bError As Boolean
        bError = PopulateSaveDataFeatures(CProperty)
        ' If we have Images
        If Not Session("PropertyAdminImages") Is Nothing Then
            CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
        End If
        If Not bError Then

            ' Save this Property to the Database
            bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            lblfeatuer.Text = "Property Details Saved"
            ' If we had an Error
            If bError Then
                ' szSaveMessage = "An error occurred whilst saving this property to the database"
            Else
                If Not Request.QueryString("PropertyId") = "" Then
                    'Try
                    '    Dim updatePropertyReturnJason As String
                    '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/property/update/" & CProperty.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                    '    httpRequest.ContentType = "application/json"
                    '    httpRequest.Method = "GET"
                    '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                    '        Using stream As Stream = httpResponse.GetResponseStream()
                    '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
                    '            updatePropertyReturnJason = json
                    '        End Using
                    '    End Using
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property-Feature")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", updatePropertyReturnJason)
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'Catch ex As Exception
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property-Feature")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'End Try
                End If
            End If

        End If
    End Sub
    Protected Sub btnhistory_Click(sender As Object, e As EventArgs)

        Dim HistoryTypeId As Int32 = Convert.ToInt32(DropDownListHistoryType.SelectedValue)
        If HistoryTypeId = 2 Then
            If rbtReduceYes.Checked Then
                If txtReduceFrom.Text = "" Then
                    'Page.RegisterStartupScript("script", "<script language='javascript'>alert('Please input Reduce From Price !');</script>")
                    'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('Please input Reduce From Price !');</script>", True)
                    lblhistorymsg.Text = "Please input Reduce From Price !"
                    lblhistorymsg.ForeColor = System.Drawing.Color.Red
                    Return
                End If
                If txtReduceTo.Text = "" Then
                    'Page.RegisterStartupScript("script", "<script language='javascript'>alert('Please input Reduce To Price !');</script>")
                    'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('Please input Reduce To Price !');</script>", True)
                    lblhistorymsg.Text = "Please input Reduce To Price !"
                    lblhistorymsg.ForeColor = System.Drawing.Color.Red
                    Return
                End If
                If txtReduceTo.Text <> "" And txtReduceFrom.Text <> "" Then
                    If Convert.ToInt32(txtReduceTo.Text) >= Convert.ToInt32(txtReduceFrom.Text) Then
                        'Page.RegisterStartupScript("script", "<script language='javascript'>alert('To Price should be less than From Price !');</script>")
                        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('To Price should be less than From Price !');</script>", True)
                        lblhistorymsg.Text = "To Price should be less than From Price !"
                        lblhistorymsg.ForeColor = System.Drawing.Color.Red
                        Return
                    End If
                End If
                'Check property to price is same as property price we have in property table
                If txtVendorPrice.Text <> "" Then
                    Dim existingVendorPrice As Int32 = Convert.ToInt32(txtVendorPrice.Text)
                    Dim newVendorPrice As Int32 = Convert.ToInt32(txtReduceTo.Text)
                    If existingVendorPrice <> newVendorPrice Then
                        'Page.RegisterStartupScript("script", "<script language='javascript'>alert('Reduce To Price is not same as per property vendor price !');</script>")
                        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('Reduce To Price is not same as per property vendor price, it should be same as vendor price !');</script>", True)
                        lblhistorymsg.Text = "Reduce To Price is not same as per property vendor price, it should be same as vendor price !"
                        lblhistorymsg.ForeColor = System.Drawing.Color.Red
                        Return
                    End If
                Else
                    'Page.RegisterStartupScript("script", "<script language='javascript'>alert('Please first set vendor price for this property, vendor price is blank !');</script>")
                    'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('Please first set vendor price for this property, vendor price is blank !');</script>", True)
                    lblhistorymsg.Text = "Please first set vendor price for this property, vendor price is blank !"
                    lblhistorymsg.ForeColor = System.Drawing.Color.Red
                    Return
                End If
            End If
        End If

        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        Dim bError As Boolean
        bError = PopulateSaveDataHistory(CProperty)
        If Not bError Then
            If Not Session("PropertyAdminImages") Is Nothing Then
                CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
            End If
            CProperty.StatusID = GetFormInteger(DropDownListStatus.SelectedValue)
            ' Save this Property to the Database
            'bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            lblhistorymsg.Text = "Property Details Saved"
            lblhistorymsg.ForeColor = System.Drawing.Color.Black

            If hdnPropertyStatus.Value <> DropDownListStatus.SelectedItem.Text Then

                'Status been changed so send email accordingly & save in property history table
                Dim mailTitleStatusChange As String
                Dim mailBodyStatusChange As String = "Property Status been changed for Property Reference " & CProperty.Reference.ToString() & "  From " & hdnPropertyStatus.Value & " To " & DropDownListStatus.SelectedItem.Text
                Dim mailBodyStatusChangeForHistory As String = "Property Status been changed for Property Reference " & CProperty.Reference.ToString() & "  From " & hdnPropertyStatus.Value & " To " & DropDownListStatus.SelectedItem.Text
                mailBodyStatusChange = mailBodyStatusChange & "<br/><br/>"
                mailTitleStatusChange = "Property Reference " & CProperty.Reference.ToString() & " Property Status is now " & DropDownListStatus.SelectedItem.Text
                Dim dtListerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "select contact_email from contact where contact_id in(select Listed_By_Contact_Id from property where Property_Ref='" & CProperty.Reference.ToString() & "')").Tables(0)
                Dim listerEmail As String = ""
                If dtListerDetails.Rows.Count > 0 Then
                    listerEmail = dtListerDetails.Rows(0)("contact_email").ToString()
                End If
                Try
                    Dim CEmailStatusChange02 As New ClassEmail
                    Dim isDevORTraining3 As Int16 = 0
                    If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                        mailBodyStatusChange = mailBodyStatusChange & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & CProperty.Reference.ToString() & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & CProperty.Reference.ToString() & "</a>"
                        CEmailStatusChange02.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListStatus.SelectedItem.Text, "Dev", 1)
                        isDevORTraining3 = 1
                    End If
                    If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                        mailBodyStatusChange = mailBodyStatusChange & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & CProperty.Reference.ToString() & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & CProperty.Reference.ToString() & "</a>"
                        CEmailStatusChange02.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListStatus.SelectedItem.Text, "Training", 1)
                        isDevORTraining3 = 1
                    End If
                    If isDevORTraining3 = 0 Then
                        mailBodyStatusChange = mailBodyStatusChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & CProperty.Reference.ToString() & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & CProperty.Reference.ToString() & "</a>"
                        CEmailStatusChange02.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListStatus.SelectedItem.Text, "Live", 1)
                    End If

                Catch ex As Exception

                End Try

            End If

            ' If we had an Error
            If bError Then
                lblhistorymsg.Text = "There is something wrong, please try again !"
            Else
                'Update old price, new price, price changed fields of property history

                If HistoryTypeId = 2 Then

                    Dim sql As SqlParameter() = New SqlParameter(4) {}

                    Dim PriceChanged As Int32 = 0

                    If rbtReduceYes.Checked Then
                        sql(0) = New SqlParameter("@OldPrice", Convert.ToInt32(txtReduceFrom.Text))
                        sql(1) = New SqlParameter("@NewPrice", Convert.ToInt32(txtReduceTo.Text))
                        PriceChanged = 1
                    End If

                    If rbtReduceNo.Checked Then
                        sql(0) = New SqlParameter("@OldPrice", Convert.ToInt32(0))
                        sql(1) = New SqlParameter("@NewPrice", Convert.ToInt32(0))
                        PriceChanged = 0
                    End If

                    If rbtReduceDontWant.Checked Then
                        sql(0) = New SqlParameter("@OldPrice", Convert.ToInt32(0))
                        sql(1) = New SqlParameter("@NewPrice", Convert.ToInt32(0))
                        PriceChanged = 2
                    End If

                    sql(2) = New SqlParameter("@PriceChanged", PriceChanged)
                    sql(3) = New SqlParameter("@Property_Ref", CProperty.Reference)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Price_Update", sql)
                End If

                'Update expiry date of property history
                'If HistoryTypeId = 19 Or HistoryTypeId = 20 Or HistoryTypeId = 21 Or HistoryTypeId = 22 Or HistoryTypeId = 23 Or HistoryTypeId = 24 Or HistoryTypeId = 25 Or HistoryTypeId = 26 Then
                '    Dim sqlExpiryChange As SqlParameter() = New SqlParameter(3) {}
                '    sqlExpiryChange(0) = New SqlParameter("@expiry_date", Convert.ToDateTime(txtSubjectExpiryDate.Text))
                '    sqlExpiryChange(1) = New SqlParameter("@Property_Id", CProperty.ID)
                '    sqlExpiryChange(2) = New SqlParameter("@History_Subject_To_Id", Convert.ToInt32(DropDownListHistoryType.SelectedValue))
                '    If drpSubjectToBuyer.Items.Count > 0 Then
                '        sqlExpiryChange(3) = New SqlParameter("@Buyer_Id", Convert.ToInt32(drpSubjectToBuyer.SelectedValue))
                '    Else
                '        sqlExpiryChange(3) = New SqlParameter("@Buyer_Id", DBNull.Value)
                '    End If

                '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_ExpiryDate_Update", sqlExpiryChange)
                '    txtSubjectExpiryDate.Text = ""
                '    divSubjectTo.Visible = False
                '    If HistoryTypeId = 26 Then
                '        'Send email to sales person & admin
                '        'Send email functionality to admin & sales person
                '        Dim PropertyRef As String = ""
                '        Dim CustomerName As String = ""
                '        Dim SalesPersonEmail As String = ""
                '        Dim SubjectToType As String = ""
                '        Dim SubjectToAdmin As String
                '        Dim ContentToAdmin As String
                '        Dim sqlManualExpiring As SqlParameter() = New SqlParameter(1) {}
                '        sqlManualExpiring(0) = New SqlParameter("@Property_Ref", CProperty.Reference)
                '        Dim dtPropertyHistoryExpiring As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Manual_Expiring", sqlManualExpiring).Tables(0)
                '        If dtPropertyHistoryExpiring.Rows.Count > 0 Then
                '            For Each row As DataRow In dtPropertyHistoryExpiring.Rows
                '                PropertyRef = row("Property_Ref")
                '                CustomerName = row("Buyer")
                '                SalesPersonEmail = row("SalesPersonEmail")
                '                SubjectToType = row("SubjectType")
                '                SubjectToAdmin = "Test Only - Subject to reservation has been manually cancelled for this client "
                '                ContentToAdmin = "Test Only - The reservation " & SubjectToType & " for the client " & CustomerName & " on property " & PropertyRef & " has been manually canceled."
                '                If PropertyRef = CProperty.Reference Then
                '                    SendExpiryEmails(SubjectToAdmin, ContentToAdmin)
                '                End If
                '            Next row
                '        End If
                '    End If
                'End If

                divOwnerCallRow.Visible = False
                txtReduceFrom.Text = ""
                txtReduceTo.Text = ""
                LoadHistory(CProperty)
                ' Load this Property's Details
                'CProperty.Load(lblpropref.Text)
                'Session("AdminPropertySelected") = CProperty
                'CProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
                'InitData(CProperty)
                If Not Request.QueryString("PropertyId") = "" Then
                    'Try
                    '    Dim updatePropertyReturnJason As String
                    '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/property/update/" & CProperty.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                    '    httpRequest.ContentType = "application/json"
                    '    httpRequest.Method = "GET"
                    '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                    '        Using stream As Stream = httpResponse.GetResponseStream()
                    '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
                    '            updatePropertyReturnJason = json
                    '        End Using
                    '    End Using
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property-History")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", updatePropertyReturnJason)
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'Catch ex As Exception
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property-History")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'End Try
                End If
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
    Private Function PopulateSaveDataHistory(ByRef CProperty As ClassProperty) As Boolean

        Try

            ' If we have History Notes, Add
            CProperty.History = TextBoxAddHistory.Text.Trim

            ' If the History Type Record was set
            If DropDownListHistoryType.SelectedIndex > 0 Then

                ' Save this
                CProperty.HistoryTypeID = DropDownListHistoryType.SelectedValue

                ' If this is Sold
                If DropDownListHistoryType.Items.FindByValue("4").Selected Then

                    ' Set the Property Status to Sold
                    DropDownListStatus.SelectedValue = 5

                    ' Don't Display or Feature this Property
                    CheckBoxDisplay.Checked = False
                    CheckBoxFeature.Checked = False

                    ' Save the Buyer
                    CProperty.BuyerID = DropDownListBuyer.SelectedValue

                    ' If we don't have a Description
                    If CProperty.History.Trim = String.Empty Then

                        ' Add Default
                        CProperty.History = "Sold to " & DropDownListBuyer.SelectedItem.Text.Trim

                    End If

                End If

            Else

                ' No History Type Selected
                CProperty.HistoryTypeID = 0

            End If

            Return False

        Catch ex As Exception
            Return True
        End Try

    End Function
    Private Function GetFormDouble(ByVal szEntry As String) As Double

        If szEntry.Trim = String.Empty Then
            Return 0
        Else
            Return Convert.ToDouble(szEntry.Trim)
        End If

    End Function
    Private Function GetFormInteger(ByVal szEntry As String) As Integer

        If szEntry.Trim = String.Empty Or szEntry = "--- Select ---" Or szEntry = "--- None ---" Then
            Return 0
        Else
            Return Convert.ToInt32(szEntry.Trim)
        End If

    End Function
    Private Function PopulateSaveDataGeneral(ByRef CProperty As ClassProperty) As Boolean
        ' Local Vars
        Dim alMessage As New ArrayList
        Dim bRetVal As Boolean = False
        ' Assign Variables to the Property Class
        CProperty.Address = txtAddress.Text.Trim
        CProperty.Taxablevalue = txtTAXABLEval.Text.Trim
        CProperty.AnnualIBI = GetFormDouble(txtAnnualIBI.Text.Trim)
        CProperty.AnnualRubbish = GetFormDouble(txtAnnualRubbish.Text.Trim)
        CProperty.AreaID = AdminLocation1.AreaID
        CProperty.Bathrooms = GetFormInteger(drpbathrooms.SelectedItem.ToString)
        CProperty.Bedrooms = GetFormInteger(drpbedrooms.SelectedItem.ToString)
        ' Check if we have a Broker
        'If drpBroker.SelectedIndex > 0 Then
        '    CProperty.BrokerID = GetFormInteger(drpBroker.SelectedValue.ToString)
        'Else
        '    CProperty.BrokerID = 0
        'End If
        If lblBroker.Text <> "" Then
            CProperty.BrokerID = Convert.ToInt32(hdnBrokerId.Value)
        Else
            CProperty.BrokerID = 0
        End If
        ' Continue to Populate Vars
        CProperty.Built = Math.Round(GetFormDouble(txtbuilt.Text.Trim))
        ' If this Property is Under Offer
        If Convert.ToInt32(DropDownListStatus.SelectedValue) = 7 Then
            ' If we have a Potential Buyer Selected
            If DropDownListUnderOfferTo.SelectedIndex > -1 Then
                ' Save who it is Under Offer to
                CProperty.BuyerID = Convert.ToInt32(DropDownListUnderOfferTo.SelectedValue)
            End If
        End If
        ' Continue to Set Parameters
        CProperty.BuyerLawyerID = GetFormInteger(DropDownListBuyerLawyer.SelectedValue.ToString)
        CProperty.CommunityFees = GetFormDouble(txtCommunityFees.Text.Trim)
        CProperty.Display = CheckBoxDisplay.Checked
        CProperty.DoorKey = txtDoorKey.Text.Trim
        CProperty.EnSuite = Math.Round(GetFormDouble(txtensuite.Text.Trim))
        CProperty.Featured = CheckBoxFeature.Checked
        CProperty.Latitude = GetFormDouble(txtLattitude.Text.Trim)
        CProperty.LocationID = GetFormInteger(drplocation.SelectedValue)
        CProperty.Longitude = GetFormDouble(txtLongitude.Text.Trim)

        If Not DropDownListStatus.SelectedValue = "3" And Not DropDownListStatus.SelectedValue = "4" Then
            If hdnVendorPrice.Value <> txtVendorPrice.Text Then
                If txtOriginalPrice.Text = "" Then
                    txtOriginalPrice.Text = hdnPublicPrice.Value
                End If
            End If
        End If

        CProperty.OriginalPrice = GetFormInteger(txtOriginalPrice.Text.Trim)
        'CProperty.PartnerID = GetFormInteger(DropDownListPartner.SelectedValue.ToString)
        CProperty.Plot = Math.Round(GetFormDouble(txtplot.Text.Trim))
        CProperty.PostcodeID = AdminLocation1.PostcodeID
        'Here i am getting default partner id by postcodeid
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@PostCode_Id", CProperty.PostcodeID)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_POSTCODE_Select_By_PostCode_Id", sql).Tables(0)
        CProperty.PartnerID = GetFormInteger(dt.Rows(0)("Default_Partner_ID").ToString())
        CProperty.PublicPrice = GetFormInteger(txtPublicPrice.Text.Trim)
        CProperty.RegionID = AdminLocation1.RegionID
        CProperty.StatusID = GetFormInteger(DropDownListStatus.SelectedValue)
        CProperty.SubAreaID = AdminLocation1.SubAreaID
        CProperty.Terrace = Math.Round(GetFormDouble(txtterrace.Text.Trim))
        CProperty.TypeID = GetFormInteger(DropDownListType.SelectedValue)
        CProperty.VendorID = GetFormInteger(DropDownListVendor.SelectedValue)
        CProperty.VendorLawyerID = GetFormInteger(drpVendrlaywer.SelectedValue.ToString)
        CProperty.VendorPrice = GetFormInteger(txtVendorPrice.Text.Trim)
        CProperty.ViewsID = GetFormInteger(drpviews.SelectedValue)
        CProperty.YearConstructed = GetFormInteger(drpyearconstructed.SelectedItem.ToString)
        CProperty.YouTubeVideoID = txtYoutubeVideoId.Text.Trim

        If drpListedByUsers.Visible = True Then
            If Not String.IsNullOrEmpty(drpListedByUsers.SelectedValue) Then
                CProperty.Listed_By_Contact_ID = Convert.ToInt32(drpListedByUsers.SelectedValue)
            Else
                CProperty.Listed_By_Contact_ID = Convert.ToInt32(hdnListedById.Value)
            End If
        Else
            CProperty.Listed_By_Contact_ID = Convert.ToInt32(hdnListedById.Value)
        End If

        Dim bannertype As String = ""
        If drpBannerType.SelectedItem.Value <> "" Then
            bannertype = drpBannerType.SelectedItem.Text
        End If

        'If property status is under offer then banner type should be under off

        If DropDownListStatus.SelectedItem.Text = "Under Offer" Then
            bannertype = "Under Offer"
        End If

        CProperty.BannerType = bannertype
        ' Perform Validation Checks
        ' Region
        If AdminLocation1.RegionID < 1 Then
            ' Init Message
            alMessage.Add("Please select an area before saving this property")
            ' Set Flag
            bRetVal = True
        End If
        ' Area
        If AdminLocation1.AreaID < 1 Then
            ' Init Message
            alMessage.Add("Please select a town before saving this property")
            ' Set Flag
            bRetVal = True
        End If

        '' Year Constructed
        'If DropDownListYearConstructed.SelectedIndex < 1 Then

        '    ' Init Message
        '    alMessage.Add("Please select the age of the property")

        '    ' Set Flag
        '    bRetVal = True

        'End If

        ' Check Public Price > Vendor Price
        If CProperty.PublicPrice < CProperty.VendorPrice Then

            ' Init Message
            alMessage.Add("The public price cannot be less than the vendor price")

            ' Set Flag
            bRetVal = True

        End If

        ' If public price and vendor price is less than 3000
        If CProperty.PublicPrice - CProperty.VendorPrice < 3000 Then

            ' Init Message
            alMessage.Add("you can't have less than 3000 Euros between Public Price and vendor Price. Please correct before saving.")

            ' Set Flag
            bRetVal = True

        End If

        ' If we have an Original Price
        If CProperty.OriginalPrice > 0 Then

            ' Check Original Price > Public Price
            If CProperty.OriginalPrice <= CProperty.PublicPrice Then

                ' Init Message
                alMessage.Add("The original price cannot be less than OR equal to the public price")

                ' Set Flag
                bRetVal = True

            End If

        End If

        ' If this Property has a Status of For Sale, check essential Items
        If CProperty.StatusID = 2 Then

            ' Local Var
            Dim bMissingDescription As Boolean = False

            ' If we have no Descriptions
            If CProperty.Description.Count < 1 Then

                ' Init Flag
                bMissingDescription = True

            Else

                ' Loop through Descriptions
                For Each deDesc As DictionaryEntry In CProperty.Description
                    ' Check to see if this is Empty
                    If deDesc.Value.ToString.Trim = String.Empty Then
                        ' Set Flag
                        bMissingDescription = True
                    End If
                Next
            End If

            ' If we are missing a Description
            If bMissingDescription Then
                ' Init Message
                alMessage.Add("Descriptions have not been provided in all languages")
                ' Set Flag
                bRetVal = True
            End If

            ' Check we have at least 1 Image
            'commented by sourbh for testing
            If CProperty.Images.Count < 1 Then
                ' Init Message
                alMessage.Add("At least one property image is required")
                ' Set Flag
                If DropDownListHistoryType.SelectedIndex > 0 Then
                    bRetVal = False
                Else
                    bRetVal = True
                End If
            End If
        End If
        ' If we have had Errors
        If bRetVal Then
            ' Display Message
            Message("Unable to Save this Property", alMessage, True)
        End If
        ' Return the Result
        Return bRetVal
    End Function
    Protected Sub ButtonArchiveHistory_Click(sender As Object, e As EventArgs) Handles ButtonArchiveHistory.Click

        ' Only do this if we have a History Item Selected
        If GridViewList.SelectedIndex > -1 Then

            ' Archive / Restore Record
            Dim CDataAccess As New ClassDataAccess
            CDataAccess.PropertyHistoryArchiveRecord(Convert.ToInt32(GridViewList.SelectedRow.Cells(1).Text.Trim), GridViewList.SelectedRow.Cells(6).Text.Trim = "No")
            CDataAccess = Nothing

            ' Update Interface
            If GridViewList.SelectedRow.Cells(6).Text = "Yes" Then

                ' Update Flag
                GridViewList.SelectedRow.Cells(6).Text = "No"

                ' Update Colour
                GridViewList.SelectedRow.BackColor = Nothing

            Else

                ' Update Flag
                GridViewList.SelectedRow.Cells(6).Text = "Yes"

                ' Update Colour
                GridViewList.SelectedRow.BackColor = Drawing.Color.LightGray

            End If

        End If
        TableRowHistoryElement.Visible = False
        TableRowHistoryArchive.Visible = False
    End Sub
    Protected Sub ButtonEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmail.Click

        ' Set to Updating
        Updating(True)

        ' Hide the Document Table
        TableDocuments.Visible = False

        ' Hide the Property Ref Label
        '  LabelPropertyReference.Visible = False

        ' Hide Category Selection
        ' ListBoxCategory.Visible = False

        ' Hide Save Button
        '  ButtonSave.Visible = False

        ' Init Fields
        TextBoxEmailAddress.Text = String.Empty
        TextBoxEmailSubject.Text = String.Empty
        TextBoxEmailMessage.Text = String.Empty

        ' Update Attachment
        LabelAttachment.Text = TreeViewBrowser.SelectedNode.Text.Trim
        LabelAttachmentFullPath.Text = TreeViewBrowser.SelectedNode.Value.Trim

        ' Display the Email Table
        TableEmailDocument.Visible = True

    End Sub
    Protected Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click

        ' Hide the Table
        TableEmailDocument.Visible = False

        ' Display the Property Ref Label
        'LabelPropertyReference.Visible = True

        '' Display Category Selection
        'ListBoxCategory.Visible = True

        '' Show Save Button
        'ButtonSave.Visible = True

        ' Display the Documents Table
        TableDocuments.Visible = True

        ' Reselect Parent
        TreeViewBrowser.Nodes(0).Selected = True
        TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)

        ' No longer Updating
        Updating(False)

    End Sub
    Protected Sub TreeViewBrowser_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeViewBrowser.SelectedNodeChanged

        ' If this Value has a File Extention
        If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

            ' A Directory
            LoadDirectory(TreeViewBrowser.SelectedNode)

        End If

        ' If the Form is Enabled
        '  If ButtonSave.Visible Then

        ' Update Buttons
        Updating(False)

        ' End If

        ' Store the Selected Value
        Session("AdminFileExplorerSelectedNode") = TreeViewBrowser.SelectedNode

    End Sub
    Private Sub LoadDirectory(ByRef tnParent As TreeNode)

        ' Local Vars
        Dim tn As TreeNode
        Dim fi As FileInfo
        Dim szFileSize As String

        ' Clear all Child Nodes
        tnParent.ChildNodes.Clear()

        ' Get the Path of the Parent Directory
        Dim szParentDirectory As String = tnParent.Value

        ' Get all the Sub Directories in the Parent Directory
        Dim szDirectories() As String = Directory.GetDirectories(szParentDirectory)

        ' For each Directory
        For Each szDirectory As String In szDirectories

            ' Creating a new Node
            tn = New TreeNode(GetDirectoryName(szDirectory))
            tn.Value = szDirectory
            tn.ImageUrl = "~/Images/Icons/folder.png"

            ' Adding to Parent
            tnParent.ChildNodes.Add(tn)

        Next

        ' Get all the Files in the Parent Directory
        Dim szFiles() As String = Directory.GetFiles(szParentDirectory)

        ' For each File
        For Each szFile As String In szFiles

            ' Get the File Info
            fi = New FileInfo(szFile)

            ' Set File Size
            If fi.Length < 1000 Then
                szFileSize = fi.Length & " B"
            ElseIf fi.Length >= 1000 And fi.Length < 1000000 Then
                szFileSize = Math.Round(fi.Length / 1000) & " KB"
            Else
                szFileSize = Math.Round(fi.Length / 1000000, 2) & " MB"
            End If

            ' Creating a new Node
            tn = New TreeNode(fi.Name & " (" & szFileSize.Trim & ")")
            tn.Value = szFile

            ' Does this File have an Extention
            If Path.HasExtension(szFile) Then

                ' Do we have an Icon for this File
                If File.Exists(Server.MapPath("~/Images/Icons/" & Path.GetExtension(szFile).Substring(1) & "-32_32.png")) Then

                    ' Set to Icon
                    tn.ImageUrl = "~/Images/Icons/" & Path.GetExtension(szFile).Substring(1) & "-32_32.png"

                Else

                    ' Set to Unknown Icon
                    tn.ImageUrl = "~/Images/Icons/file.png"

                End If

            Else

                ' Set to Unknown Icon
                tn.ImageUrl = "~/Images/Icons/file.png"

            End If

            ' Adding to Parent
            tnParent.ChildNodes.Add(tn)

        Next

        ' Expand Results
        tnParent.Expand()

    End Sub
    Private Function GetDirectoryName(ByVal szFullPath As String) As String

        ' Local Vars
        Dim szRetVal As String

        ' If we have a Trailing Slash
        If szFullPath.EndsWith("\") Then

            ' Remove Trailing Slash
            szRetVal = szFullPath.Substring(0, szFullPath.Length - 1)

        Else

            ' Get Full String
            szRetVal = szFullPath

        End If

        ' Get the Directory Name Only
        szRetVal = szRetVal.Substring(szRetVal.LastIndexOf("\") + 1)

        ' Return the Result
        Return szRetVal

    End Function
    Private Sub Updating(ByVal bUpdating As Boolean)

        ' Local Vars
        Dim bRoot As Boolean = False
        Dim bDirectory As Boolean = False
        Dim bFile As Boolean = False

        ' If we are NOT Updating
        If Not bUpdating Then

            ' If the Root Node has been Selected
            If TreeViewBrowser.Nodes(0).Selected Then

                ' Set Flag
                bRoot = True

            End If

            ' If we have a Selected Node
            If Not TreeViewBrowser.SelectedNode Is Nothing Then

                ' If this Value has a File Extention
                If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                    ' Set Flag only if not Root
                    If Not bRoot Then
                        bDirectory = True
                    End If

                Else

                    ' A File - Set Flag
                    bFile = True

                End If

                ' If we are not in Read Only Mode
                If Not Convert.ToBoolean(Session("PropertyAdminReadOnly")) Then

                    '    ' Enable / Disable Functionality based on Selection
                    '    ButtonDownload.Enabled = bFile

                    'Else

                    ' Enable / Disable Functionality based on Selection
                    ButtonDelete.Enabled = bDirectory Or bFile
                    ButtonDownload.Enabled = bFile
                    ButtonNewFolder.Enabled = bRoot Or bDirectory
                    ButtonRename.Enabled = bDirectory Or bFile
                    btnMove.Enabled = bRoot Or bDirectory Or bFile
                    ButtonUpload.Enabled = bRoot Or bDirectory
                    FileUploadFile.Enabled = bRoot Or bDirectory
                    ButtonEmail.Enabled = bFile

                End If

            End If

            ' Enable Tree View
            TreeViewBrowser.Enabled = True

        Else

            ' Updating so Disable ALL
            ButtonDelete.Enabled = False
            ButtonDownload.Enabled = False
            ButtonNewFolder.Enabled = False
            ButtonRename.Enabled = False

            ButtonUpload.Enabled = False
            FileUploadFile.Enabled = False
            ButtonEmail.Enabled = False

            ' Disable Tree View
            TreeViewBrowser.Enabled = False

        End If

    End Sub
    Protected Sub btndocument_Click(sender As Object, e As EventArgs)
        'Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        'Dim bError As Boolean

        '' If we have Images

        'If Not bError Then

        '    ' Save this Property to the Database
        '    bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
        '    lbldocument.Text = "Property Details Saved"
        '    ' If we had an Error
        '    If bError Then
        '        ' szSaveMessage = "An error occurred whilst saving this property to the database"
        '    End If

        'End If

        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        Dim bError As Boolean

        ' If we have Images
        If Not Session("PropertyAdminImages") Is Nothing Then
            CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
        End If
        If Not bError Then

            If chkIsIssues.Checked = True Then
                CProperty.IsIssue = True
            Else
                CProperty.IsIssue = False
            End If

            ' Save this Property to the Database
            bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            lbldocument.Text = "Property Details Saved"
            ' If we had an Error
            If bError Then
                ' szSaveMessage = "An error occurred whilst saving this property to the database"
            Else
                If Not Request.QueryString("PropertyId") = "" Then
                    'Try
                    '    Dim updatePropertyReturnJason As String
                    '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/property/update/" & CProperty.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                    '    httpRequest.ContentType = "application/json"
                    '    httpRequest.Method = "GET"
                    '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                    '        Using stream As Stream = httpResponse.GetResponseStream()
                    '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
                    '            updatePropertyReturnJason = json
                    '        End Using
                    '    End Using
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property-Document")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", updatePropertyReturnJason)
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'Catch ex As Exception
                    '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    '    sql(0) = New SqlParameter("@Title", "Property-Document")
                    '    sql(1) = New SqlParameter("@ActionType", "Update")
                    '    sql(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                    '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                    '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                    '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                    'End Try
                End If
            End If
        End If
    End Sub
    Protected Sub ButtonSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSend.Click

        ' Ensure we have an Email Address
        If TextBoxEmailAddress.Text.Trim = String.Empty Then

            ' Display Error
            TableRowProvideEmailAddress.Visible = True

        Else

            ' Define a New Email
            Dim CEmail As New ClassEmail

            ' Send the Email
            If CEmail.SendEmail(TextBoxEmailAddress.Text.Trim, TextBoxEmailSubject.Text.Trim, TextBoxEmailMessage.Text.Trim, False, LabelAttachmentFullPath.Text.Trim, False) Then

                ' Display Success Message
                TableRowEmailSent.Visible = True

                ' Close Email Table
                ButtonCancel_Click(Nothing, Nothing)

            Else

                ' Display Failure Message
                TableCellEmailFailed.Visible = True

            End If

            ' Tidy
            CEmail = Nothing

        End If

    End Sub
    Protected Sub ButtonViewVendor_Click(sender As Object, e As EventArgs)
        Response.Redirect("AddVendor.aspx?ContactId=" + DropDownListVendor.SelectedValue)
    End Sub
    Protected Sub ButtonUnderOfferTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUnderOfferTo.Click

        ' Local Vars
        Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))

        ' Load this Contact's Details
        Dim CDataAccess As New ClassDataAccess
        CBuyer.Load(Convert.ToInt32(DropDownListUnderOfferTo.SelectedValue))
        CDataAccess = Nothing

        ' Assign to Session Variable
        Session("AdminBuyerSelected") = CBuyer
        Response.Redirect("Client.aspx")
        ' Raise Event
        '   RaiseEvent BuyerSelected()

    End Sub
    Protected Sub chkIsIssues_CheckedChanged(sender As Object, e As EventArgs)
        btndocument.BackColor = Drawing.Color.Red
        btndocument.ForeColor = Drawing.Color.White
        btndocument.Font.Bold = True
    End Sub
    Protected Sub btnback_Click(sender As Object, e As EventArgs)
        addprop.Style.Add(HtmlTextWriterStyle.Display, "none")
        addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
        proppartrefbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
        proppartref.Style.Add(HtmlTextWriterStyle.Display, "none")
        propform.Style.Add(HtmlTextWriterStyle.Display, "block")
        propformbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
        ' Load this Property's Details
        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        lblpartnerref.Text = CProperty.CAReference
        lblgeneral_Click(Nothing, Nothing)
        '' InitData
    End Sub
    Protected Sub btnedirref_Click(sender As Object, e As EventArgs)
        addprop.Style.Add(HtmlTextWriterStyle.Display, "none")
        addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
        proppartrefbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
        proppartref.Style.Add(HtmlTextWriterStyle.Display, "block")
        propform.Style.Add(HtmlTextWriterStyle.Display, "none")
        propformbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
    End Sub
    Protected Sub btn_Click(sender As Object, e As EventArgs)
        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        If Not Session("PropertyAdminImages") Is Nothing Then
            CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
        End If
        Dim bError As Boolean
        bError = PopulateSaveDataGeneral(CProperty)

        If Not bError Then
            CProperty.CAReference = txtproppartref.Text
            If Convert.ToInt32(Session("ContactPartnerID")) = -1 And Convert.ToInt32(Session("ContactPartnerID")) = CProperty.PartnerID Then
                bError = CProperty.SaveNew(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            Else
                bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))
            End If
            Response.Redirect("AddProperty.aspx?PropertyId=" & CProperty.ID & "&PageIndex=1&Ref=&Address=&type=0&Area=0&Town=0&Beds=0&Bath=0&status=0")
        End If
    End Sub
    Protected Sub CheckBoxFeature_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBoxFeature.Checked Then
            TableRowFeatureProperty.Visible = True
            If Request.QueryString("PropertyId") = "" Then
                txtStartDate.Text = DateTime.Now.Date()
                txtExpiryDate.Text = DateTime.Now.Date().AddMonths(5)
            Else
                If txtStartDate.Text = "" Then
                    txtStartDate.Text = DateTime.Now.Date()
                End If
                If txtExpiryDate.Text = "" Then
                    txtExpiryDate.Text = DateTime.Now.Date().AddMonths(5)
                End If
            End If
        Else
            TableRowFeatureProperty.Visible = False
        End If
    End Sub
    Protected Sub rbtReduceYes_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxAddHistory.Text = ""
        txtReduceFrom.Text = ""
        txtReduceTo.Text = ""
        divReducePriceFromTo.Visible = True
        TextBoxAddHistory.Visible = True
    End Sub
    Protected Sub rbtReduceNo_CheckedChanged(sender As Object, e As EventArgs)
        divReducePriceFromTo.Visible = False
        TextBoxAddHistory.Text = ""
        TextBoxAddHistory.Visible = True
    End Sub
    Protected Sub rbtReduceDontWant_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxAddHistory.Text = "Vendor didn't want to reduce the price"
        divReducePriceFromTo.Visible = False
        TextBoxAddHistory.Visible = True
    End Sub
    Protected Sub txtReduceTo_TextChanged(sender As Object, e As EventArgs)
        TextBoxAddHistory.Text = "Vendor's price reduced from " & txtReduceFrom.Text & " to " & txtReduceTo.Text
    End Sub
    Protected Sub lnkPropertyPayment_Click(sender As Object, e As EventArgs)
        'lblPaymentSaveMessage.Visible = False
        'liPropertyPayment.Attributes.Add("class", "active")
        'ligen.Attributes.Remove("class")
        'lidec.Attributes.Remove("class")
        'liimage.Attributes.Remove("class")
        'lihist.Attributes.Remove("class")
        'lidocum.Attributes.Remove("class")
        'tabPropertyPayment.Style.Add(HtmlTextWriterStyle.Display, "block")
        'tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
        'tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        'tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
        'tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
        'tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
        'tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        'lnkhistory.Style.Add(HtmlTextWriterStyle.Display, "none")
        'divPropertyPayment.Visible = True
        ''Bind Buyer dropdown from under offer to 
        'Dim CUtilities As New ClassUtilities
        'Dim CDataAccess As New ClassDataAccess
        'CUtilities.PopulateDropDownList(drpPaymentBuyer, CDataAccess.PropertyLastTouredBuyers(Convert.ToInt32(Request.QueryString("PropertyId"))))
        'drpPaymentBuyer.DataTextField = "text"
        'drpPaymentBuyer.DataValueField = "id"
        'drpPaymentBuyer.DataBind()

    End Sub
    Protected Sub btnPaymentSave_Click(sender As Object, e As EventArgs)
        'Try
        '    Dim Property_Ref As String = lblpropref.Text
        '    Dim sqlPHStatusChange As SqlParameter() = New SqlParameter(9) {}
        '    sqlPHStatusChange(0) = New SqlParameter("@Property_Ref", Property_Ref.ToString())
        '    sqlPHStatusChange(1) = New SqlParameter("@Type_Id", drpPaymentSubjectType.SelectedValue)
        '    Dim stripeHistoryText As String = drpPaymentType.SelectedItem.Value & " - €" & txtPaymentAmount.Text & " - " & drpPaymentBuyer.SelectedItem.Text
        '    sqlPHStatusChange(2) = New SqlParameter("@History_Text", stripeHistoryText)

        '    'Check if this buyer already have salesperson'

        '    Dim CBuyer As New ClassBuyer(0)
        '    CBuyer.Load(Convert.ToInt32(drpPaymentBuyer.SelectedValue))
        '    sqlPHStatusChange(3) = New SqlParameter("@Modified_By", Convert.ToInt32(Session("ContactID")))

        '    ''''''''''''''''''''''''''''''''''''''''''''''

        '    sqlPHStatusChange(4) = New SqlParameter("@PriceChanged", DBNull.Value)
        '    sqlPHStatusChange(5) = New SqlParameter("@NewPrice", DBNull.Value)
        '    sqlPHStatusChange(6) = New SqlParameter("@OldPrice", DBNull.Value)
        '    sqlPHStatusChange(7) = New SqlParameter("@Buyer_Id", Convert.ToInt32(drpPaymentBuyer.SelectedValue))
        '    sqlPHStatusChange(8) = New SqlParameter("@Expiry_Date", Convert.ToDateTime(txtPaymentExpiryDate.Text))
        '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert_After_StripePayment_BackOffice", sqlPHStatusChange)

        '    Dim BuyerEmail As String = CBuyer.Email
        '    Dim BuyerName As String = drpPaymentBuyer.SelectedItem.Text
        '    Dim CContact As New ClassContact(0)
        '    CContact.Load(CBuyer.Buyer_Salesperson_ID)
        '    Dim SalesPersonEmail As String = CContact.Email

        '    SendPaymentEmails(Convert.ToInt32(txtPaymentAmount.Text), Property_Ref.ToString(), BuyerEmail, BuyerName, SalesPersonEmail)
        '    txtPaymentAmount.Text = ""
        '    txtPaymentExpiryDate.Text = ""
        '    drpPaymentBuyer.SelectedIndex = 0
        '    drpPaymentSubjectType.SelectedIndex = 0
        '    drpPaymentType.SelectedIndex = 0
        '    lblPaymentSaveMessage.Text = "Payment Record been saved successfully !"
        '    lblPaymentSaveMessage.ForeColor = System.Drawing.Color.Green
        '    lblPaymentSaveMessage.Visible = True
        '    ' Load this Property's Details
        '    Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        '    CProperty.Load(lblpropref.Text)
        '    Session("AdminPropertySelected") = CProperty
        '    CProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
        '    InitData(CProperty)
        'Catch ex As Exception
        '    lblPaymentSaveMessage.Text = ex.Message.ToString()
        '    lblPaymentSaveMessage.ForeColor = System.Drawing.Color.Red
        '    lblPaymentSaveMessage.Visible = True
        'End Try
    End Sub
    'Creating Email function to admin & to customer after successful payment
    'Public Sub SendPaymentEmails(ByVal paidAmount As Integer, ByVal PropertyRef As String, ByVal CustomerEmail As String, ByVal CustomerName As String, ByVal SalesPersonEmail As String)
    '    Try
    '        ' Send the Email to Customer (just doing testing)
    '        Dim SubjectToCustomer As String
    '        Dim ContentToCustomer As String
    '        SubjectToCustomer = "Test Only - Manual Payment has been done on property " & PropertyRef
    '        ContentToCustomer = "Payment amount :  " & paidAmount & " Euros<br/>"
    '        ContentToCustomer = ContentToCustomer & "Payment Made by Client name :  " & CustomerName & "  -  Client Email : " & CustomerEmail & " <br/>"
    '        ContentToCustomer = ContentToCustomer & "The property has been reserved " & drpPaymentSubjectType.SelectedItem.Text & "  with Expired Date " & txtPaymentExpiryDate.Text & ""
    '        Dim CEmail As New ClassEmail
    '        CEmail.SendEmail("jerome@inlandandalucia.com", SubjectToCustomer, ContentToCustomer, True, Nothing, False)
    '        CEmail.SendEmail("sourabhodesk@gmail.com", SubjectToCustomer, ContentToCustomer, True, Nothing, False)
    '        CEmail = Nothing
    '        ' Send the Email to Admin (just doing testing)
    '        Dim SubjectToAdmin As String
    '        Dim ContentToAdmin As String
    '        SubjectToAdmin = "Test Only - Manual Payment has been done on property " & PropertyRef
    '        ContentToAdmin = "Payment amount :  " & paidAmount & " Euros<br/>"
    '        ContentToAdmin = ContentToAdmin & "Payment Made by Client name :  " & CustomerName & "  -  Client Email : " & CustomerEmail & " <br/>"
    '        ContentToAdmin = ContentToAdmin & "The property has been reserved " & drpPaymentSubjectType.SelectedItem.Text & "  with Expired Date " & txtPaymentExpiryDate.Text & ""
    '        Dim CEmailAdmin As New ClassEmail
    '        'CEmailAdmin.SendEmail("info@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
    '        CEmailAdmin.SendEmail("jerome@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
    '        'CEmailAdmin.SendEmail("lee@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
    '        'CEmailAdmin.SendEmail(SalesPersonEmail, SubjectToAdmin, ContentToAdmin, True, Nothing, False)
    '        CEmailAdmin.SendEmail("sourabhodesk@gmail.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
    '        CEmailAdmin = Nothing
    '    Catch ex As Exception
    '        'lblError.Text = ex.InnerException.ToString()
    '    End Try
    'End Sub

    Private Sub bindusers()
        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)
        Dim dt As DataTable
        If Convert.ToInt32(Session("AdminUser")) = 0 Then
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Show_Users_By_ContactPartnerId_With_IsMainContact", sql).Tables(0)
        Else
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Show_Users_Without_Archived").Tables(0)
        End If

        If dt.Rows.Count > 0 Then
            drpListedByUsers.DataSource = dt
            drpListedByUsers.DataTextField = "Contact_Name"
            drpListedByUsers.DataValueField = "Contact_Id"

            drpListedByUsers.DataBind()
            Dim licategory1 As New ListItem("--Listed By--", "")
            drpListedByUsers.Items.Insert(0, licategory1)
        End If
    End Sub
End Class
