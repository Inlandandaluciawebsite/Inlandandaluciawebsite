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
Imports System.Security
Imports System.Security.Cryptography

Partial Class Admin_Property_General
    Inherits System.Web.UI.Page
    Shared BuyerIdNew As Int32 = 0
    Dim CDataAccess As New ClassDataAccess
    Dim CUtilities As New ClassUtilities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            bindvendor()
            bindtype()
            bindstatus()
            bindlocation()
            bindviews()
            bindyears()
            bindlawyer()
            bedrooms()
            bathrooms()
            bindpatner()
            bindbroker()
            bindusers()
            If Request.QueryString("PropertyId") = "" Then
                AdminLocation1.MustIncludePostcodeID = 0
                AdminLocation1.InitData(0)
                Dim sqlGetPartnerId As SqlParameter() = New SqlParameter(0) {}
                sqlGetPartnerId(0) = New SqlParameter("@PostCode_Id", AdminLocation1.PostcodeID)
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_POSTCODE_Select_By_PostCode_Id", sqlGetPartnerId).Tables(0)

                If dt.Rows.Count > 0 Then
                    drpPartner.SelectedValue = dt.Rows(0)("Default_Partner_Id")
                    drppartner_SelectedIndexChanged(Nothing, Nothing)
                End If
                'Set Listed By & Partner by getting logged in user & its partner
                Dim CContact As New ClassContact
                CContact.Load(Convert.ToInt32(Session("ContactPartnerID").ToString()))

                lblListedBy.Text = "By " & Session("ContactName").ToString() & " - " & CContact.Name
                lblListedBy.Visible = True
            Else
                If Not Request.QueryString("PropertyId") = "" Then
                    hdcont.Value = Request.QueryString("PropertyId")
                    hdpageind.Value = Request.QueryString("PageIndex")
                    Dim url As String = Request.UrlReferrer.ToString()
                    'Dim url As String = "http://localhost:59926/AdminNew/AddProperty.aspx?PropertyId=29696&PageIndex=1&Ref=&Address=&type=0&Area=0&Town=0&Beds=0&Bath=0&status=0"
                    Dim uri = New Uri(url)
                    Dim qs = HttpUtility.ParseQueryString(uri.Query)
                    'qs.[Set]("ID", hdcont.Value)
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
                    LoadProperty()
                End If
            End If
            ' Enable / Disable Partner Drop Down
            'drpPartner.Enabled = DirectCast(Session("AdminUser"), Boolean)
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
                    lblMessageTop.Text = "This property has not yet been toured so no potential buyers exist"
                    ' Inform the User
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
                lblMessageTop.Text = "Please enter a property status value of 'Sold' via the History section to select a buyer and provide details of the sale"
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
            End If
        End If
        ' Set to Display if For Sale or Under Offer
        CheckBoxDisplay.Checked = (DropDownListStatus.SelectedValue = 2 Or DropDownListStatus.SelectedValue = 7)
    End Sub
    Protected Sub btnPropertyGeneral_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_General.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyDescription_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Description.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyImages_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Images.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyFeatures_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Features.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyHistory_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_History.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyDocuments_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Documents.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Private Function HideZeros(ByVal nValue As Integer) As String
        If nValue > 0 Then
            Return nValue.ToString.Trim
        Else
            Return String.Empty
        End If
    End Function
    Private Sub bindtype()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@LanguageId", Convert.ToInt32(Session("ContactLanguageID")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_TypeBYId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListType.DataSource = dt
            DropDownListType.DataTextField = "text"
            DropDownListType.DataValueField = "id"
            DropDownListType.DataBind()
            Dim liPropertyType As New ListItem("-- Select Property Type --", "0")
            DropDownListType.Items.Insert(0, liPropertyType)
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
            btnSavePropertyGeneral.Visible = (dtpropertypartner.Rows(0)("Partner_Id") = Session("ContactPartnerID")) Or Convert.ToBoolean(Session("AdminUser"))
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
            DropDownListVendor.DataSource = dt
            DropDownListVendor.DataTextField = "text"
            DropDownListVendor.DataValueField = "id"
            DropDownListVendor.DataBind()
            Dim licategory As New ListItem("-- Select Vendor --", "0")
            Dim licategory1 As New ListItem("-- Select--", "0")
            DropDownListVendor.Items.Insert(0, licategory1)
        End If

        If Not Request.QueryString("VId") = "" Then
            DropDownListVendor.SelectedValue = Convert.ToInt32(Request.QueryString("VId").ToString())
            DropDownListVendor.Enabled = False
        End If

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
            DropDownListStatus.SelectedValue = 3
        End If
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
            drpListedByUsers.Visible = Convert.ToBoolean(Session("AdminUser"))
        End If
    End Sub
    Protected Sub drppartner_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindbroker()
    End Sub
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
    End Sub
    Protected Sub btnedirref_Click(sender As Object, e As EventArgs)
        propform.Style.Add(HtmlTextWriterStyle.Display, "none")
        propformbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
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
    Protected Sub btnSavePropertyGeneral_Click(sender As Object, e As EventArgs)
        If Request.QueryString("PropertyId") = "" Then
            InsertProperty()
        Else
            UpdateProperty()
        End If
    End Sub
    Public Sub LoadProperty()
        DropDownListType.Enabled = False
        Dim sqlPropertyDetails As SqlParameter() = New SqlParameter(1) {}
        sqlPropertyDetails(0) = New SqlParameter("@Property_ID", Request.QueryString("PropertyId").ToString())
        Dim dtPropertyDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Select_By_PropertyId", sqlPropertyDetails).Tables(0)
        If dtPropertyDetails.Rows.Count > 0 Then
            lblpropref.Text = dtPropertyDetails.Rows(0)("Property_Ref").ToString()
            DropDownListVendor.SelectedValue = dtPropertyDetails.Rows(0)("Vendor_ID").ToString()
            If Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_ID").ToString()) > 0 Then
                ButtonViewVendor.Visible = True
            End If
            txtPropertyPartnerRef.Text = dtPropertyDetails.Rows(0)("PropertyPartnerRef").ToString()
            DropDownListType.SelectedValue = dtPropertyDetails.Rows(0)("Property_Type_ID").ToString()
            DropDownListStatus.SelectedValue = dtPropertyDetails.Rows(0)("Status_ID").ToString()
            hdnPropertyStatusValue.Value = dtPropertyDetails.Rows(0)("Status_ID").ToString()
            hdnPropertyStatus.Value = dtPropertyDetails.Rows(0)("PropertyStatus").ToString()
            'hdnPublicPrice.Value = HideZeros(IIf(Convert.ToInt32(dtPropertyDetails.Rows(0)("Public_Price").ToString()) = 0, "", Convert.ToInt32(dtPropertyDetails.Rows(0)("Public_Price").ToString())))
            AdminLocation1.MustIncludePostcodeID = Convert.ToInt32(dtPropertyDetails.Rows(0)("Postcode_ID").ToString())
            AdminLocation1.InitData(Convert.ToInt32(dtPropertyDetails.Rows(0)("Postcode_ID").ToString()))
            txtTAXABLEval.Text = dtPropertyDetails.Rows(0)("Property_Notes").ToString().Trim
            lblListedBy.Text = dtPropertyDetails.Rows(0)("Listed_By_Contact_Name").ToString()
            'drpListedByUsers.SelectedValue = dtPropertyDetails.Rows(0)("Listed_By_Contact_ID").ToString()
            hdnListedById.Value = dtPropertyDetails.Rows(0)("Listed_By_Contact_ID").ToString()
            txtAddress.Text = dtPropertyDetails.Rows(0)("Property_Address").ToString()
            txtLattitude.Text = IIf(Convert.ToDouble(dtPropertyDetails.Rows(0)("GPS_Latitude").ToString()) = 0, "", Convert.ToDouble(dtPropertyDetails.Rows(0)("GPS_Latitude").ToString()))
            txtLongitude.Text = IIf(Convert.ToDouble(dtPropertyDetails.Rows(0)("GPS_Longitude").ToString()) = 0, "", Convert.ToDouble(dtPropertyDetails.Rows(0)("GPS_Longitude").ToString()))
            drplocation.SelectedValue = dtPropertyDetails.Rows(0)("Location_ID").ToString()
            drpviews.SelectedValue = dtPropertyDetails.Rows(0)("Views_ID").ToString()
            drpbedrooms.SelectedValue = dtPropertyDetails.Rows(0)("Bedrooms").ToString()
            drpbathrooms.SelectedValue = dtPropertyDetails.Rows(0)("Bathrooms").ToString()
            drpyearconstructed.SelectedValue = dtPropertyDetails.Rows(0)("Year_Constructed").ToString()
            txtplot.Text = dtPropertyDetails.Rows(0)("SQM_Plot").ToString()
            txtbuilt.Text = dtPropertyDetails.Rows(0)("SQM_Built").ToString()
            txtterrace.Text = IIf(Convert.ToInt32(dtPropertyDetails.Rows(0)("SQM_Terrace").ToString()) = 0, "", Convert.ToInt32(dtPropertyDetails.Rows(0)("SQM_Terrace").ToString()))
            txtensuite.Text = IIf(Convert.ToInt32(dtPropertyDetails.Rows(0)("SQM_En_Suite").ToString()) = 0, "", Convert.ToInt32(dtPropertyDetails.Rows(0)("SQM_En_Suite").ToString()))
            txtAnnualIBI.Text = IIf(Convert.ToDouble(dtPropertyDetails.Rows(0)("Annual_IBI").ToString()) = 0, "", Convert.ToDouble(dtPropertyDetails.Rows(0)("Annual_IBI").ToString()))
            txtAnnualRubbish.Text = IIf(Convert.ToDouble(dtPropertyDetails.Rows(0)("Annual_Rubbish").ToString()) = 0, "", Convert.ToDouble(dtPropertyDetails.Rows(0)("Annual_Rubbish").ToString()))
            txtCommunityFees.Text = IIf(Convert.ToDouble(dtPropertyDetails.Rows(0)("Community_Fees").ToString()) = 0, "", Convert.ToDouble(dtPropertyDetails.Rows(0)("Community_Fees").ToString()))
            txtVendorPrice.Text = IIf(Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_Price").ToString()) = 0, "", Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_Price").ToString()))
            hdnVendorPrice.Value = IIf(Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_Price").ToString()) = 0, "", Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_Price").ToString()))
            txtOriginalPrice.Text = IIf(Convert.ToInt32(dtPropertyDetails.Rows(0)("Original_Price").ToString()) = 0, "", Convert.ToInt32(dtPropertyDetails.Rows(0)("Original_Price").ToString()))
            txtPublicPrice.Text = IIf(Convert.ToInt32(dtPropertyDetails.Rows(0)("Public_Price").ToString()) = 0, "", Convert.ToInt32(dtPropertyDetails.Rows(0)("Public_Price").ToString()))
            hdnPublicPrice.Value = IIf(Convert.ToInt32(dtPropertyDetails.Rows(0)("Public_Price").ToString()) = 0, "", Convert.ToInt32(dtPropertyDetails.Rows(0)("Public_Price").ToString()))

            If Not DropDownListStatus.SelectedValue = "3" And Not DropDownListStatus.SelectedValue = "4" Then
                If hdnVendorPrice.Value <> txtVendorPrice.Text Then
                    If txtOriginalPrice.Text = "" Then
                        txtOriginalPrice.Text = hdnPublicPrice.Value
                    End If
                End If
            End If

            txtYoutubeVideoId.Text = dtPropertyDetails.Rows(0)("Video_URL").ToString()
            txtDoorKey.Text = dtPropertyDetails.Rows(0)("Door_Key").ToString()
            drpPartner.SelectedValue = dtPropertyDetails.Rows(0)("Partner_ID").ToString()
            drpVendrlaywer.SelectedValue = dtPropertyDetails.Rows(0)("Vendor_Lawyer_ID").ToString()
            CheckBoxDisplay.Checked = Convert.ToBoolean(dtPropertyDetails.Rows(0)("Display").ToString())
            CheckBoxFeature.Checked = Convert.ToBoolean(dtPropertyDetails.Rows(0)("IsFeatured").ToString())
            If CheckBoxFeature.Checked Then
                TableRowFeatureProperty.Visible = True
                'Get expiry date & start date from database by property reference 
                Dim sqlfeatureDetails As SqlParameter() = New SqlParameter(0) {}
                sqlfeatureDetails(0) = New SqlParameter("@Property_Ref", lblpropref.Text)
                Dim dtfeatureDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Feature_Property_Select_By_PropRef", sqlfeatureDetails).Tables(0)
                If dtfeatureDetails.Rows.Count > 0 Then
                    txtStartDate.Text = dtfeatureDetails.Rows(0)("Featured_Prop_Date").ToString()
                    txtExpiryDate.Text = dtfeatureDetails.Rows(0)("Expiry_Date").ToString()
                End If
            Else
                TableRowFeatureProperty.Visible = False
            End If

            ' Set Visibility of Viewing Photos
            If (Convert.ToInt32(dtPropertyDetails.Rows(0)("Num_Photos").ToString()) > 0) Then
                ButtonViewingPhotos.Visible = True
            End If

            'Some more code copied from old version which we were using at the time of page init
            'If we have a broker

            If Convert.ToInt32(dtPropertyDetails.Rows(0)("Broker_ID").ToString()) > 0 Then

                'Get broker name by brokerid
                Dim sqlbrokerdetails As SqlParameter() = New SqlParameter(0) {}
                sqlbrokerdetails(0) = New SqlParameter("@Contact_Id", Convert.ToInt32(dtPropertyDetails.Rows(0)("Broker_ID").ToString()))
                Dim dtBrokerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblContact_Select_By_Contact_Id", sqlbrokerdetails).Tables(0)
                If dtBrokerDetails.Rows.Count > 0 Then
                    lblBroker.Text = dtBrokerDetails.Rows(0)("Contact_Name").ToString()
                End If
                hdnBrokerId.Value = dtPropertyDetails.Rows(0)("Broker_ID").ToString()
                BrokerRow.Visible = True
            Else
                BrokerRow.Visible = False
            End If

            ' If we have a Vendor
            If Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_ID").ToString()) > 0 Then
                ' Select the Vendor
                DropDownListVendor.SelectedValue = Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_ID").ToString())
            Else
                ' Init to None
                DropDownListVendor.SelectedIndex = 0
            End If

            ' Buyer Lawyer only Visible if Under Offer
            CUtilities.PopulateDropDownList(DropDownListBuyerLawyer, CDataAccess.Lawyers)
            ' Add <None> to Lawyers
            DropDownListBuyerLawyer.Items.Insert(0, "--- None ---")
            TableRowBuyerLawyer.Visible = (dtPropertyDetails.Rows(0)("Status_ID").ToString() = "7") Or (dtPropertyDetails.Rows(0)("Status_ID").ToString() = "5")
            ' Buyer Lawyer
            If Not String.IsNullOrEmpty(dtPropertyDetails.Rows(0)("Buyer_Lawyer_ID").ToString()) Then
                If Convert.ToInt32(dtPropertyDetails.Rows(0)("Buyer_Lawyer_ID").ToString()) > 0 Then
                    ' Select the Lawyer
                    DropDownListBuyerLawyer.SelectedValue = Convert.ToInt32(dtPropertyDetails.Rows(0)("Buyer_Lawyer_ID").ToString())
                Else
                    ' Init to None
                    DropDownListBuyerLawyer.SelectedIndex = 0
                End If
            End If

            ' Vendor Lawyer
            If Not String.IsNullOrEmpty(dtPropertyDetails.Rows(0)("Vendor_Lawyer_ID").ToString()) Then
                If Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_Lawyer_ID").ToString()) > 0 Then
                    ' Select the Lawyer
                    drpVendrlaywer.SelectedValue = Convert.ToInt32(dtPropertyDetails.Rows(0)("Vendor_Lawyer_ID").ToString())
                Else
                    ' Init to None
                    drpVendrlaywer.SelectedIndex = 0
                End If
            End If


            ' Init to the Last People who Viewed this Property on a Tour in Date Descending Order
            CUtilities.PopulateDropDownList(DropDownListUnderOfferTo, CDataAccess.PropertyLastTouredBuyers(Convert.ToInt32(Request.QueryString("PropertyId").ToString())))
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
            If Not String.IsNullOrEmpty(dtPropertyDetails.Rows(0)("Buyer_ID").ToString()) Then
                If Convert.ToInt32(dtPropertyDetails.Rows(0)("Buyer_ID").ToString()) > 0 Then
                    ' If it Exists in our DropDown
                    If DropDownListUnderOfferTo.Items.Contains(DropDownListUnderOfferTo.Items.FindByValue(dtPropertyDetails.Rows(0)("Buyer_ID").ToString())) Then
                        ' Select this Item
                        DropDownListUnderOfferTo.SelectedValue = dtPropertyDetails.Rows(0)("Buyer_ID").ToString()
                        BuyerIdNew = dtPropertyDetails.Rows(0)("Buyer_ID").ToString()
                    Else
                        BuyerIdNew = 0
                    End If
                Else
                    BuyerIdNew = 0
                End If
            Else
                BuyerIdNew = 0
            End If

            ' Set Visibility of Property Status Options
            SetStatusOptionsVisibility()
            ' Update URLsf
            ButtonWindowcard.OnClientClick = "javascript:window.open('/windowcard.aspx?PropertyRef=" & lblpropref.Text.Trim & "','_self');return false;"
            ButtonViewingPhotos.OnClientClick = "javascript:window.open('/Admin/ViewingPhotos.aspx?PropertyRef=" & lblpropref.Text.Trim & "');return false;"
            ' Set Visibility of Windowcard (for Sale or Under Offer)
            ButtonWindowcard.Visible = (Convert.ToInt32(hdnPropertyStatusValue.Value) = 2 Or Convert.ToInt32(hdnPropertyStatusValue.Value) = 7)
            '''''
            Dim sqlVendorAgent As SqlParameter() = New SqlParameter(1) {}
            sqlVendorAgent(0) = New SqlParameter("@Vendor_Id", Convert.ToInt32(DropDownListVendor.SelectedValue))
            Dim dtVendorAgent As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Select_Agent_By_VendorId", sqlVendorAgent).Tables(0)
            If dtVendorAgent.Rows.Count > 0 Then
                lblAgent.Text = dtVendorAgent.Rows(0)("contact_name").ToString()
            Else
                lblAgent.Text = "-"
            End If

            hdnListedById.Value = dtPropertyDetails.Rows(0)("Listed_By_Contact_ID").ToString()
            Dim listedByPartner As String = dtPropertyDetails.Rows(0)("Listed_By_Partner").ToString()

            If Convert.ToInt32(dtPropertyDetails.Rows(0)("Listed_By_Contact_ID").ToString()) = "0" Then
                lblListedBy.Text = "By - 0"
            Else
                lblListedBy.Text = "By " & dtPropertyDetails.Rows(0)("Listed_By_Contact_Name").ToString() & " - " & listedByPartner
                drpListedByUsers.Visible = True
                lblListedBy.Visible = True
                bindusers()
                'If CProperty.ListedBy <> "" Then
                '    Try
                '        drpListedByUsers.Items.FindByText(CProperty.ListedBy).Selected = True
                '    Catch ex As Exception

                '    End Try

                'End If
            End If
            drpListedByUsers.Visible = Convert.ToBoolean(Session("AdminUser"))
            'Set banner for banner dropdown
            drpBannerType.SelectedValue = dtPropertyDetails.Rows(0)("BannerType").ToString()

            'if property is already resreved and property status is not under offer then remove under offer option
            If DropDownListStatus.SelectedValue <> 7 Then
                If dtPropertyDetails.Rows(0)("BannerType").ToString() = "Reserved" Then
                    DropDownListStatus.Items.Remove(DropDownListStatus.Items.FindByValue("7"))
                End If
            End If
        End If
    End Sub
    Public Sub InsertProperty()

        If DropDownListVendor.SelectedIndex = 0 Then
            lblmessage.Text = "Please Select Vendor !"
            lblMessageTop.Text = "Please Select Vendor !"
            Return
        End If
        If DropDownListType.SelectedIndex = 0 Then
            lblmessage.Text = "Please Select Property Type !"
            lblMessageTop.Text = "Please Select Property Type !"
            Return
        End If
        If txtPublicPrice.Text <> "" And txtVendorPrice.Text <> "" Then
            If Convert.ToInt32(txtPublicPrice.Text) < Convert.ToInt32(txtVendorPrice.Text) Then
                lblmessage.Text = "The public price cannot be less than the vendor price"
                lblMessageTop.Text = "The public price cannot be less than the vendor price"
                Return
            End If
            If (Convert.ToInt32(txtPublicPrice.Text) - Convert.ToInt32(txtVendorPrice.Text)) < 3000 Then
                lblmessage.Text = "you can't have less than 3000 Euros between Public Price and vendor Price. Please correct before saving."
                lblMessageTop.Text = "you can't have less than 3000 Euros between Public Price and vendor Price. Please correct before saving."
                Return
            End If
        End If
        If txtPublicPrice.Text <> "" And txtOriginalPrice.Text <> "" Then
            If Convert.ToInt32(txtPublicPrice.Text) > 0 Then
                If Convert.ToInt32(txtOriginalPrice.Text) < Convert.ToInt32(txtPublicPrice.Text) Then
                    lblmessage.Text = "The original price cannot be less than OR equal to the public price"
                    lblMessageTop.Text = "The original price cannot be less than OR equal to the public price"
                End If
            End If
        End If

        Dim sql As SqlParameter() = New SqlParameter(42) {}
        sql(0) = New SqlParameter("@Country_ID", 2)
        Dim Property_Ref As String = ""
        Dim sqlPropertyRef As SqlParameter() = New SqlParameter(1) {}
        sqlPropertyRef(0) = New SqlParameter("@ePropertyTypeID", DropDownListType.SelectedValue)
        sqlPropertyRef(1) = New SqlParameter("@ContactPartnerID", 0)
        Dim dtPropertyRef As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_GetNextPropertyRef_ByePropertyTypeID", sqlPropertyRef).Tables(0)
        If dtPropertyRef.Rows.Count > 0 Then
            Property_Ref = dtPropertyRef.Rows(0)("id").ToString()
        End If
        sql(1) = New SqlParameter("@Property_Ref", Property_Ref)
        sql(2) = New SqlParameter("@Create_Date", DateTime.Now)
        sql(3) = New SqlParameter("@Status_ID", GetFormInteger(DropDownListStatus.SelectedValue))
        sql(4) = New SqlParameter("@Postcode_ID", AdminLocation1.PostcodeID)
        sql(5) = New SqlParameter("@Property_Type_ID", GetFormInteger(DropDownListType.SelectedValue))
        If txtLattitude.Text.Trim <> "" Then
            sql(6) = New SqlParameter("@GPS_Latitude", Convert.ToDecimal(txtLattitude.Text.Trim))
        Else
            sql(6) = New SqlParameter("@GPS_Latitude", Convert.ToDecimal("0.000000000000"))
        End If
        If txtLongitude.Text.Trim <> "" Then
            sql(7) = New SqlParameter("@GPS_Longitude", Convert.ToDecimal(txtLongitude.Text.Trim))
        Else
            sql(7) = New SqlParameter("@GPS_Longitude", Convert.ToDecimal("0.000000000000"))
        End If

        sql(8) = New SqlParameter("@Location_ID", GetFormInteger(drplocation.SelectedValue))
        sql(9) = New SqlParameter("@Views_ID", GetFormInteger(drpviews.SelectedValue))
        sql(10) = New SqlParameter("@Public_Price", GetFormInteger(txtPublicPrice.Text.Trim))
        sql(11) = New SqlParameter("@Original_Price", GetFormInteger(txtOriginalPrice.Text.Trim))
        sql(12) = New SqlParameter("@Vendor_Price", GetFormInteger(txtVendorPrice.Text.Trim))
        sql(13) = New SqlParameter("@Vendor_ID", GetFormInteger(DropDownListVendor.SelectedValue))
        If lblBroker.Text <> "" Then
            sql(14) = New SqlParameter("@Broker_ID", Convert.ToInt32(hdnBrokerId.Value))
        Else
            sql(14) = New SqlParameter("@Broker_ID", 0)
        End If
        'Here i am getting default partner id by postcodeid
        Dim sqlPartnerByPostcode As SqlParameter() = New SqlParameter(1) {}
        sqlPartnerByPostcode(0) = New SqlParameter("@PostCode_Id", AdminLocation1.PostcodeID)
        Dim dtPartnerByPostcode As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_POSTCODE_Select_By_PostCode_Id", sqlPartnerByPostcode).Tables(0)
        sql(15) = New SqlParameter("@Partner_ID", GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()))
        sql(16) = New SqlParameter("@Bedrooms", GetFormInteger(drpbedrooms.SelectedItem.ToString))
        sql(17) = New SqlParameter("@Bathrooms", GetFormInteger(drpbathrooms.SelectedItem.ToString))
        sql(18) = New SqlParameter("@SQM_Plot", Math.Round(GetFormDouble(txtplot.Text.Trim)))
        sql(19) = New SqlParameter("@SQM_Built", Math.Round(GetFormDouble(txtbuilt.Text.Trim)))
        sql(20) = New SqlParameter("@Property_Address", txtAddress.Text.Trim)
        sql(21) = New SqlParameter("@Video_URL", txtYoutubeVideoId.Text.Trim)
        sql(22) = New SqlParameter("@Property_Notes", txtTAXABLEval.Text.Trim)
        sql(23) = New SqlParameter("@Annual_IBI", GetFormDouble(txtAnnualIBI.Text.Trim))
        sql(24) = New SqlParameter("@Annual_Rubbish", GetFormDouble(txtAnnualRubbish.Text.Trim))
        sql(25) = New SqlParameter("@Community_Fees", GetFormDouble(txtCommunityFees.Text.Trim))
        sql(26) = New SqlParameter("@Year_Constructed", GetFormInteger(drpyearconstructed.SelectedItem.ToString))
        sql(27) = New SqlParameter("@SQM_Terrace", Math.Round(GetFormDouble(txtterrace.Text.Trim)))
        sql(28) = New SqlParameter("@SQM_En_Suite", Math.Round(GetFormDouble(txtensuite.Text.Trim)))
        sql(29) = New SqlParameter("@Num_Photos", 0)
        Dim Listed_By_Contact_Id As Int32 = 0

        If drpListedByUsers.Visible = True Then
            If Not String.IsNullOrEmpty(drpListedByUsers.SelectedValue) Then
                Listed_By_Contact_Id = Convert.ToInt32(drpListedByUsers.SelectedValue)
            Else
                Listed_By_Contact_Id = Convert.ToInt32(Session("ContactID").ToString())
            End If
        Else
            Listed_By_Contact_Id = Convert.ToInt32(Session("ContactID").ToString())
        End If

        sql(30) = New SqlParameter("@Listed_By_Contact_ID", Listed_By_Contact_Id)
        sql(31) = New SqlParameter("@Last_Modified", DateTime.Now)
        sql(32) = New SqlParameter("@Display", CheckBoxDisplay.Checked)
        sql(33) = New SqlParameter("@Viewed", 0)
        sql(34) = New SqlParameter("@Door_Key", txtDoorKey.Text.Trim)
        sql(35) = New SqlParameter("@Buyer_Lawyer_ID", GetFormInteger(DropDownListBuyerLawyer.SelectedValue.ToString))
        sql(36) = New SqlParameter("@Vendor_Lawyer_ID", GetFormInteger(drpVendrlaywer.SelectedValue.ToString))
        Dim BuyerID As Int32 = 0
        ' If this Property is Under Offer
        If Convert.ToInt32(DropDownListStatus.SelectedValue) = 7 Or Convert.ToInt32(DropDownListStatus.SelectedValue) = 5 Or Convert.ToInt32(DropDownListStatus.SelectedValue) = 6 Then
            ' If we have a Potential Buyer Selected
            If DropDownListUnderOfferTo.SelectedIndex > -1 Then
                ' Save who it is Under Offer to
                BuyerID = Convert.ToInt32(DropDownListUnderOfferTo.SelectedValue)
            End If
        End If

        sql(37) = New SqlParameter("@Buyer_ID", BuyerID)
        sql(38) = New SqlParameter("@IsIssue", False)
        sql(39) = New SqlParameter("@Total_Enquiries", 0)
        Dim bannertype As String = ""
        If drpBannerType.SelectedItem.Value <> "" Then
            bannertype = drpBannerType.SelectedItem.Text
        End If

        'If property status is under offer then banner type should be under off

        If DropDownListStatus.SelectedItem.Text = "Under Offer" Then
            bannertype = "Under Offer"
        End If
        sql(40) = New SqlParameter("@BannerType", bannertype)
        sql(41) = New SqlParameter("@History_Subject_To_Id", DBNull.Value)

        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Insert", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Manage_Property_Partner_Ref(Convert.ToInt32(dt.Rows(0)("Property_Id").ToString()))
            lblmessage.Text = "Property Inserted Successfully !"
            lblMessageTop.Text = "Property Inserted Successfully !"
            lblmessage.ForeColor = System.Drawing.Color.Green
            lblMessageTop.ForeColor = System.Drawing.Color.Green

            If CheckBoxFeature.Checked Then
                If hdnVendorPrice.Value <> txtVendorPrice.Text Then
                    txtStartDate.Text = DateTime.Now.Date()
                    txtExpiryDate.Text = DateTime.Now.Date().AddMonths(5)
                End If
                Dim feature_start_date As String = txtStartDate.Text
                Dim feature_expiry_date As String = txtExpiryDate.Text
                Dim Contact_Id As Int32 = Convert.ToInt32(Session("ContactID"))
                Dim sqlFeaturedProperty As SqlParameter() = New SqlParameter(4) {}
                sqlFeaturedProperty(0) = New SqlParameter("@Property_Ref", Property_Ref)
                sqlFeaturedProperty(1) = New SqlParameter("@Featured_Prop_Date", feature_start_date)
                sqlFeaturedProperty(2) = New SqlParameter("@Expiry_Date", feature_expiry_date)
                sqlFeaturedProperty(3) = New SqlParameter("@Contact_Id", Contact_Id)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Featured_Property_Insert", sqlFeaturedProperty)
            Else
                Dim sqlFeaturedProperty As SqlParameter() = New SqlParameter(1) {}
                sqlFeaturedProperty(0) = New SqlParameter("@Property_Ref", Property_Ref)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Featured_Property_Delete", sqlFeaturedProperty)
            End If

            Dim dtListerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "select contact_email from contact where contact_id in(select Listed_By_Contact_Id from property where Property_Ref='" & Property_Ref.ToString() & "')").Tables(0)
            Dim listerEmail As String = ""
            If dtListerDetails.Rows.Count > 0 Then
                listerEmail = dtListerDetails.Rows(0)("contact_email").ToString()
            End If

            Try
                ' Define a New Email
                Dim CEmailPropertyCreated As New ClassEmail
                Dim mailTitlePropertyCreated As String
                Dim mailBodyPropertyCreated As String
                mailTitlePropertyCreated = "New Property ref " & Property_Ref.ToString() & " has been created"
                mailBodyPropertyCreated = "Property " & Property_Ref.ToString() & " has just been created with status " & DropDownListStatus.SelectedItem.Text & ""
                Dim isDevORTraining As Int16 = 0
                If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                    CEmailPropertyCreated.SendEmail_Notification_Single_Fuction(mailTitlePropertyCreated, mailBodyPropertyCreated, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, "NewPropertyCreated", "Dev", 1)
                    isDevORTraining = 1
                End If
                If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                    'CEmailPropertyCreated.SendEmail_Notification_Single_Fuction(mailTitlePropertyCreated, mailBodyPropertyCreated, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, "NewPropertyCreated", "Training", 1)
                    isDevORTraining = 1
                End If
                If isDevORTraining = 0 Then
                    CEmailPropertyCreated.SendEmail_Notification_Single_Fuction(mailTitlePropertyCreated, mailBodyPropertyCreated, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, "NewPropertyCreated", "Live", 1)
                End If

            Catch ex As Exception

            End Try

            Response.Redirect("Property_General.aspx?PropertyId=" & dt.Rows(0)("Property_Id").ToString())
        Else
            lblmessage.Text = "Error , Property have not been inserted successfully !"
            lblMessageTop.Text = "Error , Property have not been inserted successfully !"
        End If
    End Sub
    Public Sub UpdateProperty()

        If DropDownListVendor.SelectedIndex = 0 Then
            lblmessage.Text = "Please Select Vendor !"
            lblMessageTop.Text = "Please Select Vendor !"
            Return
        End If
        If txtPublicPrice.Text <> "" And txtVendorPrice.Text <> "" Then
            If Convert.ToInt32(txtPublicPrice.Text) < Convert.ToInt32(txtVendorPrice.Text) Then
                lblmessage.Text = "The public price cannot be less than the vendor price"
                lblMessageTop.Text = "The public price cannot be less than the vendor price"
                Return
            End If
            If (Convert.ToInt32(txtPublicPrice.Text) - Convert.ToInt32(txtVendorPrice.Text)) < 3000 Then
                lblmessage.Text = "you can't have less than 3000 Euros between Public Price and vendor Price. Please correct before saving."
                lblMessageTop.Text = "you can't have less than 3000 Euros between Public Price and vendor Price. Please correct before saving."
                Return
            End If
        End If
        If txtPublicPrice.Text <> "" And txtOriginalPrice.Text <> "" Then
            If Convert.ToInt32(txtPublicPrice.Text) > 0 Then
                If Convert.ToInt32(txtPublicPrice.Text) > Convert.ToInt32(hdnPublicPrice.Value) Then
                    If Convert.ToInt32(txtOriginalPrice.Text) <= Convert.ToInt32(txtPublicPrice.Text) Then
                        'lblmessage.Text = "The original price cannot be less than OR equal to the public price"
                        'lblMessageTop.Text = "The original price cannot be less than OR equal to the public price"
                        'Return
                        txtOriginalPrice.Text = ""
                    End If
                End If
            End If
        End If
        If txtPublicPrice.Text <> "" And hdnPublicPrice.Value <> "" Then
            If Convert.ToInt32(txtPublicPrice.Text) < Convert.ToInt32(hdnPublicPrice.Value) Then
                If txtOriginalPrice.Text = "" Then
                    txtOriginalPrice.Text = hdnPublicPrice.Value
                End If
            End If
        End If


        If DropDownListStatus.SelectedValue = "2" Then
            If txtPublicPrice.Text = "" Then
                lblmessage.Text = "Please input public price"
                lblMessageTop.Text = "Please input public price"
                Return
            End If
            Dim sqlImageDescCheck As SqlParameter() = New SqlParameter(1) {}
            sqlImageDescCheck(0) = New SqlParameter("@Property_Id", Convert.ToInt32(Request.QueryString("PropertyId").ToString()))
            Dim dtImageDescCheck As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_DescriptionImage_Check", sqlImageDescCheck).Tables(0)
            If dtImageDescCheck.Rows.Count > 0 Then
                If Convert.ToInt32(dtImageDescCheck.Rows(0)("TotalDescValues").ToString()) < 5 Then
                    'If there are missing description in all language then show validation
                    lblmessage.Text = "Descriptions have not been provided in all languages"
                    lblMessageTop.Text = "Descriptions have not been provided in all languages"
                    Return
                End If
                If Convert.ToInt32(dtImageDescCheck.Rows(0)("Num_Photos").ToString()) = 0 Then
                    'If there is no image been uploaded then show validation
                    lblmessage.Text = "At least one property image is required"
                    lblMessageTop.Text = "At least one property image is required"
                    Return
                End If
            End If
        End If

        Dim sql As SqlParameter() = New SqlParameter(39) {}
        sql(0) = New SqlParameter("@Country_ID", 2)
        sql(1) = New SqlParameter("@Property_Ref", lblpropref.Text)
        sql(2) = New SqlParameter("@Status_ID", GetFormInteger(DropDownListStatus.SelectedValue))
        sql(3) = New SqlParameter("@Postcode_ID", AdminLocation1.PostcodeID)
        sql(4) = New SqlParameter("@Property_Type_ID", GetFormInteger(DropDownListType.SelectedValue))
        If txtLattitude.Text.Trim <> "" Then
            sql(5) = New SqlParameter("@GPS_Latitude", Convert.ToDecimal(txtLattitude.Text.Trim))
        Else
            sql(5) = New SqlParameter("@GPS_Latitude", Convert.ToDecimal("0.000000000000"))
        End If
        If txtLongitude.Text.Trim <> "" Then
            sql(6) = New SqlParameter("@GPS_Longitude", Convert.ToDecimal(txtLongitude.Text.Trim))
        Else
            sql(6) = New SqlParameter("@GPS_Longitude", Convert.ToDecimal("0.000000000000"))
        End If
        sql(7) = New SqlParameter("@Location_ID", GetFormInteger(drplocation.SelectedValue))
        sql(8) = New SqlParameter("@Views_ID", GetFormInteger(drpviews.SelectedValue))
        sql(9) = New SqlParameter("@Public_Price", GetFormInteger(txtPublicPrice.Text.Trim))

        sql(10) = New SqlParameter("@Original_Price", GetFormInteger(txtOriginalPrice.Text.Trim))
        sql(11) = New SqlParameter("@Vendor_Price", GetFormInteger(txtVendorPrice.Text.Trim))
        sql(12) = New SqlParameter("@Vendor_ID", GetFormInteger(DropDownListVendor.SelectedValue))
        If lblBroker.Text <> "" Then
            sql(13) = New SqlParameter("@Broker_ID", Convert.ToInt32(hdnBrokerId.Value))
        Else
            sql(13) = New SqlParameter("@Broker_ID", 0)
        End If
        'Here i am getting default partner id by postcodeid
        Dim sqlPartnerByPostcode As SqlParameter() = New SqlParameter(1) {}
        sqlPartnerByPostcode(0) = New SqlParameter("@PostCode_Id", AdminLocation1.PostcodeID)
        Dim dtPartnerByPostcode As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_POSTCODE_Select_By_PostCode_Id", sqlPartnerByPostcode).Tables(0)
        sql(14) = New SqlParameter("@Partner_ID", GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()))
        sql(15) = New SqlParameter("@Bedrooms", GetFormInteger(drpbedrooms.SelectedItem.ToString))
        sql(16) = New SqlParameter("@Bathrooms", GetFormInteger(drpbathrooms.SelectedItem.ToString))
        sql(17) = New SqlParameter("@SQM_Plot", Math.Round(GetFormDouble(txtplot.Text.Trim)))
        sql(18) = New SqlParameter("@SQM_Built", Math.Round(GetFormDouble(txtbuilt.Text.Trim)))
        sql(19) = New SqlParameter("@Property_Address", txtAddress.Text.Trim)
        sql(20) = New SqlParameter("@Video_URL", txtYoutubeVideoId.Text.Trim)
        sql(21) = New SqlParameter("@Property_Notes", txtTAXABLEval.Text.Trim)
        sql(22) = New SqlParameter("@Annual_IBI", GetFormDouble(txtAnnualIBI.Text.Trim))
        sql(23) = New SqlParameter("@Annual_Rubbish", GetFormDouble(txtAnnualRubbish.Text.Trim))
        sql(24) = New SqlParameter("@Community_Fees", GetFormDouble(txtCommunityFees.Text.Trim))
        sql(25) = New SqlParameter("@Year_Constructed", GetFormInteger(drpyearconstructed.SelectedItem.ToString))
        sql(26) = New SqlParameter("@SQM_Terrace", Math.Round(GetFormDouble(txtterrace.Text.Trim)))
        sql(27) = New SqlParameter("@SQM_En_Suite", Math.Round(GetFormDouble(txtensuite.Text.Trim)))
        Dim Listed_By_Contact_Id As Int32 = 0

        If drpListedByUsers.Visible = True Then
            If Not String.IsNullOrEmpty(drpListedByUsers.SelectedValue) Then
                Listed_By_Contact_Id = Convert.ToInt32(drpListedByUsers.SelectedValue)
            Else
                Listed_By_Contact_Id = Convert.ToInt32(hdnListedById.Value)
            End If
        Else
            Listed_By_Contact_Id = Convert.ToInt32(hdnListedById.Value)
        End If

        sql(28) = New SqlParameter("@Listed_By_Contact_ID", Listed_By_Contact_Id)
        sql(29) = New SqlParameter("@Display", CheckBoxDisplay.Checked)
        sql(30) = New SqlParameter("@Door_Key", txtDoorKey.Text.Trim)
        sql(31) = New SqlParameter("@Buyer_Lawyer_ID", GetFormInteger(DropDownListBuyerLawyer.SelectedValue.ToString))
        sql(32) = New SqlParameter("@Vendor_Lawyer_ID", GetFormInteger(drpVendrlaywer.SelectedValue.ToString))
        Dim BuyerID As Int32 = 0
        ' If this Property is Under Offer
        If Convert.ToInt32(DropDownListStatus.SelectedValue) = 7 Or Convert.ToInt32(DropDownListStatus.SelectedValue) = 5 Or Convert.ToInt32(DropDownListStatus.SelectedValue) = 6 Then
            ' If we have a Potential Buyer Selected
            If DropDownListUnderOfferTo.SelectedIndex > -1 Then
                ' Save who it is Under Offer to
                BuyerID = Convert.ToInt32(DropDownListUnderOfferTo.SelectedValue)
            End If
        End If

        sql(33) = New SqlParameter("@Buyer_ID", BuyerID)
        Dim bannertype As String = ""
        If drpBannerType.SelectedItem.Value <> "" Then
            bannertype = drpBannerType.SelectedItem.Text
        End If

        'If property status is under offer then banner type should be under off

        If DropDownListStatus.SelectedItem.Text = "Under Offer" Then
            bannertype = "Under Offer"
        End If
        sql(34) = New SqlParameter("@BannerType", bannertype)
        sql(35) = New SqlParameter("@History_Subject_To_Id", DBNull.Value)
        sql(36) = New SqlParameter("@Property_ID", Convert.ToInt32(Request.QueryString("PropertyId").ToString()))

        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_By_Property_Id", sql)
        Manage_Property_Partner_Ref(Convert.ToInt32(Request.QueryString("PropertyId").ToString()))
        lblmessage.Text = "Property Updated Successfully !"
        lblMessageTop.Text = "Property Updated Successfully !"
        lblmessage.ForeColor = System.Drawing.Color.Green
        lblMessageTop.ForeColor = System.Drawing.Color.Green

        Dim Property_Ref As String = lblpropref.Text
        If CheckBoxFeature.Checked Then
            If hdnVendorPrice.Value <> txtVendorPrice.Text Then
                txtStartDate.Text = DateTime.Now.Date()
                txtExpiryDate.Text = DateTime.Now.Date().AddMonths(5)
            End If
            Dim feature_start_date As String = txtStartDate.Text
            Dim feature_expiry_date As String = txtExpiryDate.Text
            Dim Contact_Id As Int32 = Convert.ToInt32(Session("ContactID"))
            Dim sqlFeaturedProperty As SqlParameter() = New SqlParameter(4) {}
            sqlFeaturedProperty(0) = New SqlParameter("@Property_Ref", Property_Ref)
            sqlFeaturedProperty(1) = New SqlParameter("@Featured_Prop_Date", feature_start_date)
            sqlFeaturedProperty(2) = New SqlParameter("@Expiry_Date", feature_expiry_date)
            sqlFeaturedProperty(3) = New SqlParameter("@Contact_Id", Contact_Id)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Featured_Property_Insert", sqlFeaturedProperty)
        Else
            Dim sqlFeaturedProperty As SqlParameter() = New SqlParameter(1) {}
            sqlFeaturedProperty(0) = New SqlParameter("@Property_Ref", Property_Ref)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Featured_Property_Delete", sqlFeaturedProperty)
        End If

        Dim dtListerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "select contact_email from contact where contact_id in(select Listed_By_Contact_Id from property where Property_Ref='" & lblpropref.Text & "')").Tables(0)
        Dim listerEmail As String = ""
        If dtListerDetails.Rows.Count > 0 Then
            listerEmail = dtListerDetails.Rows(0)("contact_email").ToString()
        End If

        'Save with in property history & send emails to three person & salesperson accordingly. 
        If hdnPublicPrice.Value <> txtPublicPrice.Text And DropDownListStatus.SelectedItem.Value <> "3" Then
            'Price been changed so send email accordingly & save in property history table
            Dim mailTitlePriceChange As String
            Dim mailBodyPriceChange As String = "Public Price been changed for Property Reference " & lblpropref.Text & " From Old Price " & hdnPublicPrice.Value & " To New Price " & txtPublicPrice.Text
            Dim mailBodyPriceChangeForHistory As String = "Public Price been changed for Property Reference " & lblpropref.Text & " From Old Price " & hdnPublicPrice.Value & " To New Price " & txtPublicPrice.Text
            mailBodyPriceChange = mailBodyPriceChange & "<br/><br/>"

            Try
                ' Define a New Email
                Dim CEmailPriceChange As New ClassEmail
                Dim isDevORTraining1 As Int16 = 0
                mailTitlePriceChange = "Property Reference " & lblpropref.Text & " Public Price Changed"
                If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                    mailBodyPriceChange = mailBodyPriceChange & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                    CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, "PriceChanged", "Dev", 1)
                    'CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), "jerome@inlandandalucia.com", "PriceChanged", "Dev", 1)
                    'CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), "sourabhodesk@gmail.com", "PriceChanged", "Dev", 1)
                    'CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), "lee@inlandandalucia.com", "PriceChanged", "Dev", 1)
                    isDevORTraining1 = 1
                End If
                If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                    mailBodyPriceChange = mailBodyPriceChange & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                    CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, "PriceChanged", "Training", 1)
                    isDevORTraining1 = 1
                End If
                If isDevORTraining1 = 0 Then
                    mailBodyPriceChange = mailBodyPriceChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                    CEmailPriceChange.SendEmail_Notification_Single_Fuction(mailTitlePriceChange, mailBodyPriceChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, "PriceChanged", "Live", 1)
                End If

                'Only if public price been less than old public price
                If Convert.ToInt32(txtPublicPrice.Text) < Convert.ToInt32(hdnPublicPrice.Value) Then
                    'Send email to all customers who been have enquiry for this particular property
                    Dim sqlBuyerenquiryProperty As SqlParameter() = New SqlParameter(0) {}
                    sqlBuyerenquiryProperty(0) = New SqlParameter("@PropertyRef", lblpropref.Text)
                    Dim dtBuyerEnquiredProperty As DataSet = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Enquiry_Details", sqlBuyerenquiryProperty)
                    If dtBuyerEnquiredProperty.Tables(0).Rows.Count > 0 Then

                        'Send Email to all customers who been have enquiry for this particular property but archived is 0 and buyer_status_Id<>7
                        Dim emailTitle As String = ""
                        Dim emailContent As String = ""
                        Dim isDevORTrainingBuyerEnquiry As Int32 = 0
                        Dim CEmailBuyerEnquiry As New ClassEmail
                        Dim SalesPersonNameEnquiry As String = ""
                        Dim SalesPersonEmailEnquiry As String = ""
                        Dim SalesPersonWhatsappEnquiry As String = ""

                        For nIndex = 0 To dtBuyerEnquiredProperty.Tables(0).Rows.Count - 1

                            Dim isClienTour As Int32 = 0

                            Dim sqlIsBuyerTourCheck As SqlParameter() = New SqlParameter(2) {}
                            sqlIsBuyerTourCheck(0) = New SqlParameter("@Buyer_Id", Convert.ToInt32(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()))
                            sqlIsBuyerTourCheck(1) = New SqlParameter("@Property_Ref", lblpropref.Text)
                            Dim dtBuyerTourcheck As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_ISClient_Tour_Check", sqlIsBuyerTourCheck).Tables(0)

                            'Get sales person details

                            Dim sqlSalesPersonEnquiry As SqlParameter() = New SqlParameter(1) {}
                            sqlSalesPersonEnquiry(0) = New SqlParameter("@Contact_Id", Convert.ToInt32(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("Buyer_Salesperson_ID").ToString()))
                            Dim dtSalesPersonEnquiry As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblContact_Select_By_Contact_Id", sqlSalesPersonEnquiry).Tables(0)
                            If dtSalesPersonEnquiry.Rows.Count > 0 Then
                                SalesPersonNameEnquiry = dtSalesPersonEnquiry.Rows(0)("Contact_Name").ToString()
                                SalesPersonEmailEnquiry = dtSalesPersonEnquiry.Rows(0)("Contact_Email").ToString()
                                SalesPersonWhatsappEnquiry = dtSalesPersonEnquiry.Rows(0)("Contact_Mobile").ToString()
                            End If
                            If SalesPersonWhatsappEnquiry <> "" Then
                                SalesPersonWhatsappEnquiry = "(0034)" & SalesPersonWhatsappEnquiry
                            End If

                            If dtBuyerTourcheck.Rows.Count = 0 Then
                                If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                    emailTitle = "Test Only - Great News !! Price reduction on one of the properties you were interested in."
                                    emailContent = emailContent & "Dear  " & dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_forename").ToString() & " " & dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_surname").ToString() & " <br/><br/>"
                                    emailContent = emailContent & "We wanted to inform you that  the property you were interested in has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameEnquiry & " your property specialist, Email is " & SalesPersonEmailEnquiry & " , and whatsapp/Tel is " & SalesPersonWhatsappEnquiry & "<br/><br/>"
                                    emailContent = emailContent & "- Property Ref : " & lblpropref.Text & "<br/>"
                                    emailContent = emailContent & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a><br/><br/>"
                                    emailContent = emailContent & "You know you can reserve this property now, and we will ensure that you have the 1st opportunity to negotiate at your next viewing !! just click the green button 'Reserve' on the property detail page above. We can also organise a Virtual Tour of the property.<br/>"
                                    emailContent = emailContent & "We are listing NEW properties daily so take a look at our website to check out our latest opportunities.<br/><a href='dev.inlandandalucia.com'>dev.inlandandalucia.com</a><br/>"
                                    emailContent = emailContent & "if you are still searching for a bargain property to buy in Spain or If you are not interested anymore in receiving our Email please let us know – <a href='dev.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()) & "' >Update your criterias</a> <br/><br/>"
                                    emailContent = emailContent & "Best Regards<br/>"
                                    emailContent = emailContent & "Inland Andalucia Team<br/>"
                                    emailContent = emailContent & "<a href='dev.inlandandalucia.com'>dev.inlandandalucia.com</a><br/>"
                                    'CEmailBuyerEnquiry.SendEmailBuyer(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_email").ToString(), "", emailTitle, emailContent, True, Nothing, False)
                                    CEmailBuyerEnquiry.SendEmailBuyer("sourabhodesk@gmail.com", "", emailTitle, emailContent, True, Nothing, False)
                                    CEmailBuyerEnquiry.SendEmailBuyer("jerome@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                    CEmailBuyerEnquiry.SendEmailBuyer("lee@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                    isDevORTrainingBuyerEnquiry = 1
                                End If
                                If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                    emailTitle = "Test Only - Great News !! Price reduction on one of the properties you were interested in."
                                    emailContent = emailContent & "Dear  " & dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_forename").ToString() & " " & dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_surname").ToString() & " <br/><br/>"
                                    emailContent = emailContent & "We wanted to inform you that  the property you were interested in has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameEnquiry & " your property specialist, Email is " & SalesPersonEmailEnquiry & " , and whatsapp/Tel is " & SalesPersonWhatsappEnquiry & "<br/><br/>"
                                    emailContent = emailContent & "- Property Ref : " & lblpropref.Text & "<br/>"
                                    emailContent = emailContent & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a><br/><br/>"
                                    emailContent = emailContent & "You know you can reserve this property now, and we will ensure that you have the 1st opportunity to negotiate at your next viewing !! just click the green button 'Reserve' on the property detail page above. We can also organise a Virtual Tour of the property.<br/>"
                                    emailContent = emailContent & "We are listing NEW properties daily so take a look at our website to check out our latest opportunities.<br/><a href='training.inlandandalucia.com'>training.inlandandalucia.com</a><br/>"
                                    emailContent = emailContent & "if you are still searching for a bargain property to buy in Spain or If you are not interested anymore in receiving our Email please let us know – <a href='training.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()) & "' >Update your criterias</a> <br/><br/>"
                                    emailContent = emailContent & "Best Regards<br/>"
                                    emailContent = emailContent & "Inland Andalucia Team<br/>"
                                    emailContent = emailContent & "<a href='training.inlandandalucia.com'>training.inlandandalucia.com</a><br/>"
                                    'CEmailBuyerEnquiry.SendEmailBuyer(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_email").ToString(), "", emailTitle, emailContent, True, Nothing, False)
                                    CEmailBuyerEnquiry.SendEmailBuyer("sourabhodesk@gmail.com", "", emailTitle, emailContent, True, Nothing, False)
                                    CEmailBuyerEnquiry.SendEmailBuyer("jerome@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                    CEmailBuyerEnquiry.SendEmailBuyer("lee@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                    isDevORTrainingBuyerEnquiry = 1
                                End If
                                If isDevORTrainingBuyerEnquiry = 0 Then
                                    emailTitle = "Great News !! Price reduction on one of the properties you were interested in."
                                    emailContent = emailContent & "Dear  " & dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_forename").ToString() & " " & dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_surname").ToString() & " <br/><br/>"
                                    emailContent = emailContent & "We wanted to inform you that  the property you were interested in has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameEnquiry & " your property specialist, Email is " & SalesPersonEmailEnquiry & " , and whatsapp/Tel is " & SalesPersonWhatsappEnquiry & "<br/><br/>"
                                    emailContent = emailContent & "- Property Ref : " & lblpropref.Text & "<br/>"
                                    emailContent = emailContent & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a><br/><br/>"
                                    emailContent = emailContent & "You know you can reserve this property now, and we will ensure that you have the 1st opportunity to negotiate at your next viewing !! just click the green button 'Reserve' on the property detail page above. We can also organise a Virtual Tour of the property.<br/>"
                                    emailContent = emailContent & "We are listing NEW properties daily so take a look at our website to check out our latest opportunities.<br/><a href='www.inlandandalucia.com'>www.inlandandalucia.com</a><br/>"
                                    emailContent = emailContent & "if you are still searching for a bargain property to buy in Spain or If you are not interested anymore in receiving our Email please let us know – <a href='www.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()) & "' >Update your criterias</a> <br/><br/>"
                                    emailContent = emailContent & "Best Regards<br/>"
                                    emailContent = emailContent & "Inland Andalucia Team<br/>"
                                    emailContent = emailContent & "<a href='www.inlandandalucia.com'>www.inlandandalucia.com</a><br/>"
                                    CEmailBuyerEnquiry.SendEmailBuyer(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_email").ToString(), "", emailTitle, emailContent, True, Nothing, False)
                                    'CEmailBuyerEnquiry.SendEmailBuyer("sourabhodesk@gmail.com", "", emailTitle, emailContent, True, Nothing, False)
                                    'CEmailBuyerEnquiry.SendEmailBuyer("jerome@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                    'CEmailBuyerEnquiry.SendEmailBuyer("lee@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                End If
                                emailTitle = ""
                                emailContent = ""

                                'Insert buyer history record accordingly

                                Dim History_Text_Enquiry As String = "Notification of price reduction was sent to this client who enquiried about the property " & lblpropref.Text & " before. "
                                Dim sqlBuyerHistory As SqlParameter() = New SqlParameter(7) {}
                                sqlBuyerHistory(0) = New SqlParameter("@Buyer_Id", Convert.ToInt32(dtBuyerEnquiredProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()))
                                sqlBuyerHistory(1) = New SqlParameter("@Buyer_Status", 3)
                                sqlBuyerHistory(2) = New SqlParameter("@History_Text", History_Text_Enquiry)
                                sqlBuyerHistory(3) = New SqlParameter("@Modified_By", Convert.ToInt32(Session("ContactID")))
                                sqlBuyerHistory(4) = New SqlParameter("@Action_Date", System.DateTime.Now)
                                sqlBuyerHistory(5) = New SqlParameter("@Archived", 0)
                                sqlBuyerHistory(6) = New SqlParameter("@Action_Status", "Information Only")

                                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_INSERT", sqlBuyerHistory)


                            End If
                        Next

                    End If

                    'Send email to all customers who been toured this property but archived is 0 and buyer_status_Id<>7
                    Dim sqlBuyerenquiryTourProperty As SqlParameter() = New SqlParameter(0) {}
                    sqlBuyerenquiryTourProperty(0) = New SqlParameter("@PropertyRef", lblpropref.Text)
                    Dim dtBuyerEnquiredTourProperty As DataSet = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Enquiry_Tour_Details", sqlBuyerenquiryTourProperty)
                    If dtBuyerEnquiredTourProperty.Tables(0).Rows.Count > 0 Then

                        'Send Email to all customers who been have enquiry for this particular property
                        Dim emailTitle As String = ""
                        Dim emailContent As String = ""
                        Dim isDevORTrainingBuyerEnquiry As Int32 = 0
                        Dim CEmailBuyerEnquiry As New ClassEmail
                        Dim DateOfViewingTour As String = ""
                        Dim SalesPersonNameTour As String = ""
                        Dim SalesPersonEmailTour As String = ""
                        Dim SalesPersonWhatsappTour As String = ""

                        For nIndex = 0 To dtBuyerEnquiredTourProperty.Tables(0).Rows.Count - 1

                            'Get sales person details

                            Dim sqlSalesPersonTour As SqlParameter() = New SqlParameter(1) {}
                            sqlSalesPersonTour(0) = New SqlParameter("@Contact_Id", Convert.ToInt32(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("Buyer_Salesperson_ID").ToString()))
                            Dim dtSalesPersonTour As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblContact_Select_By_Contact_Id", sqlSalesPersonTour).Tables(0)
                            If dtSalesPersonTour.Rows.Count > 0 Then
                                SalesPersonNameTour = dtSalesPersonTour.Rows(0)("Contact_Name").ToString()
                                SalesPersonEmailTour = dtSalesPersonTour.Rows(0)("Contact_Email").ToString()
                                SalesPersonWhatsappTour = dtSalesPersonTour.Rows(0)("Contact_Mobile").ToString()
                            End If
                            If SalesPersonWhatsappTour <> "" Then
                                SalesPersonWhatsappTour = "(0034)" & SalesPersonWhatsappTour
                            End If

                            'Get viewing date details 

                            Dim sqlTourViewingDate As SqlParameter() = New SqlParameter(1) {}
                            sqlTourViewingDate(0) = New SqlParameter("@PropertyRef", lblpropref.Text)
                            sqlTourViewingDate(1) = New SqlParameter("@Buyer_Id", Convert.ToInt32(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()))
                            Dim dtTourviewingDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Tour_Details_By_Buyer_Property", sqlTourViewingDate).Tables(0)


                            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                emailTitle = "Test Only - Great news !! Price reduction on one of the properties you have viewed with us"
                                emailContent = emailContent & "Dear  " & dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_forename").ToString() & " " & dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_surname").ToString() & " <br/><br/>"

                                If dtTourviewingDetails.Rows.Count > 0 Then
                                    DateOfViewingTour = dtTourviewingDetails.Rows(0)("tour_datetime").ToString()
                                    emailContent = emailContent & "We wanted to inform you that the property you visited with us on " & DateOfViewingTour.ToString() & "  is still available to purchase, but has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameTour & " your property specialist, Email is " & SalesPersonEmailTour & ", and whatsapp/Tel is " & SalesPersonWhatsappTour & "<br/><br/>"
                                Else
                                    DateOfViewingTour = ""
                                    emailContent = emailContent & "We wanted to inform you that the property you visited with us on --  is still available to purchase, but has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameTour & " your property specialist, Email is " & SalesPersonEmailTour & ", and whatsapp/Tel is " & SalesPersonWhatsappTour & "<br/><br/>"
                                End If

                                emailContent = emailContent & "- Property Ref : " & lblpropref.Text & "<br/>"
                                emailContent = emailContent & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a><br/><br/>"
                                emailContent = emailContent & "You know you can reserve this property now, and we will ensure that you have the 1st opportunity to negotiate at your next viewing !! just click the green button 'Reserve' on the property detail page above. We can also organise a Virtual Tour of the property.<br/>"
                                emailContent = emailContent & "We are listing NEW properties daily so take a look at our website to check out our latest opportunities.<br/><a href='dev.inlandandalucia.com'>dev.inlandandalucia.com</a><br/>"
                                emailContent = emailContent & "if you are still searching for a bargain property to buy in Spain or If you are not interested anymore in receiving our Email please let us know – <a href='dev.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()) & "' >Update your criterias</a> <br/><br/>"
                                emailContent = emailContent & "Best Regards<br/>"
                                emailContent = emailContent & "Inland Andalucia Team<br/>"
                                emailContent = emailContent & "<a href='dev.inlandandalucia.com'>dev.inlandandalucia.com</a><br/>"
                                'CEmailBuyerEnquiry.SendEmailBuyer(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_email").ToString(), "", emailTitle, emailContent, True, Nothing, False)
                                CEmailBuyerEnquiry.SendEmailBuyer("sourabhodesk@gmail.com", "", emailTitle, emailContent, True, Nothing, False)
                                CEmailBuyerEnquiry.SendEmailBuyer("jerome@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                CEmailBuyerEnquiry.SendEmailBuyer("lee@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                isDevORTrainingBuyerEnquiry = 1
                            End If
                            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                emailTitle = "Test Only - Great news !! Price reduction on one of the properties you have viewed with us"
                                emailContent = emailContent & "Dear  " & dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_forename").ToString() & " " & dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_surname").ToString() & " <br/><br/>"

                                If dtTourviewingDetails.Rows.Count > 0 Then
                                    DateOfViewingTour = dtTourviewingDetails.Rows(0)("tour_datetime").ToString()
                                    emailContent = emailContent & "We wanted to inform you that the property you visited with us on " & DateOfViewingTour.ToString() & "  is still available to purchase, but has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameTour & " your property specialist, Email is " & SalesPersonEmailTour & ", and whatsapp/Tel is " & SalesPersonWhatsappTour & "<br/><br/>"
                                Else
                                    DateOfViewingTour = ""
                                    emailContent = emailContent & "We wanted to inform you that the property you visited with us on --  is still available to purchase, but has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameTour & " your property specialist, Email is " & SalesPersonEmailTour & ", and whatsapp/Tel is " & SalesPersonWhatsappTour & "<br/><br/>"
                                End If

                                emailContent = emailContent & "- Property Ref : " & lblpropref.Text & "<br/>"
                                emailContent = emailContent & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a><br/><br/>"
                                emailContent = emailContent & "You know you can reserve this property now, and we will ensure that you have the 1st opportunity to negotiate at your next viewing !! just click the green button 'Reserve' on the property detail page above. We can also organise a Virtual Tour of the property.<br/>"
                                emailContent = emailContent & "We are listing NEW properties daily so take a look at our website to check out our latest opportunities.<br/><a href='training.inlandandalucia.com'>training.inlandandalucia.com</a><br/>"
                                emailContent = emailContent & "if you are still searching for a bargain property to buy in Spain or If you are not interested anymore in receiving our Email please let us know – <a href='dev.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()) & "' >Update your criterias</a> <br/><br/>"
                                emailContent = emailContent & "Best Regards<br/>"
                                emailContent = emailContent & "Inland Andalucia Team<br/>"
                                emailContent = emailContent & "<a href='training.inlandandalucia.com'>training.inlandandalucia.com</a><br/>"
                                'CEmailBuyerEnquiry.SendEmailBuyer(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_email").ToString(), "", emailTitle, emailContent, True, Nothing, False)
                                CEmailBuyerEnquiry.SendEmailBuyer("sourabhodesk@gmail.com", "", emailTitle, emailContent, True, Nothing, False)
                                CEmailBuyerEnquiry.SendEmailBuyer("jerome@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                CEmailBuyerEnquiry.SendEmailBuyer("lee@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                isDevORTrainingBuyerEnquiry = 1
                            End If
                            If isDevORTrainingBuyerEnquiry = 0 Then
                                emailTitle = "Great news !! Price reduction on one of the properties you have viewed with us"
                                emailContent = emailContent & "Dear  " & dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_forename").ToString() & " " & dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_surname").ToString() & " <br/><br/>"

                                If dtTourviewingDetails.Rows.Count > 0 Then
                                    DateOfViewingTour = dtTourviewingDetails.Rows(0)("tour_datetime").ToString()
                                    emailContent = emailContent & "We wanted to inform you that the property you visited with us on " & DateOfViewingTour.ToString() & "  is still available to purchase, but has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameTour & " your property specialist, Email is " & SalesPersonEmailTour & ", and whatsapp/Tel is " & SalesPersonWhatsappTour & "<br/><br/>"
                                Else
                                    DateOfViewingTour = ""
                                    emailContent = emailContent & "We wanted to inform you that the property you visited with us on --  is still available to purchase, but has just been reduced in price today. Have a look at the property detailed below and let us know your latest thoughts? – You can contact " & SalesPersonNameTour & " your property specialist, Email is " & SalesPersonEmailTour & ", and whatsapp/Tel is " & SalesPersonWhatsappTour & "<br/><br/>"
                                End If

                                emailContent = emailContent & "- Property Ref : " & lblpropref.Text & "<br/>"
                                emailContent = emailContent & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a><br/><br/>"
                                emailContent = emailContent & "You know you can reserve this property now, and we will ensure that you have the 1st opportunity to negotiate at your next viewing !! just click the green button 'Reserve' on the property detail page above. We can also organise a Virtual Tour of the property.<br/>"
                                emailContent = emailContent & "We are listing NEW properties daily so take a look at our website to check out our latest opportunities.<br/><a href='www.inlandandalucia.com'>www.inlandandalucia.com</a><br/>"
                                emailContent = emailContent & "if you are still searching for a bargain property to buy in Spain or If you are not interested anymore in receiving our Email please let us know – <a href='www.inlandandalucia.com/buyer_criterias.aspx?BuyerId=" & Encrypt(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()) & "' >Update your criterias</a> <br/><br/>"
                                emailContent = emailContent & "Best Regards<br/>"
                                emailContent = emailContent & "Inland Andalucia Team<br/>"
                                emailContent = emailContent & "<a href='www.inlandandalucia.com'>www.inlandandalucia.com</a><br/>"
                                CEmailBuyerEnquiry.SendEmailBuyer(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_email").ToString(), "", emailTitle, emailContent, True, Nothing, False)
                                'CEmailBuyerEnquiry.SendEmailBuyer("sourabhodesk@gmail.com", "", emailTitle, emailContent, True, Nothing, False)
                                'CEmailBuyerEnquiry.SendEmailBuyer("jerome@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                                'CEmailBuyerEnquiry.SendEmailBuyer("lee@inlandandalucia.com", "", emailTitle, emailContent, True, Nothing, False)
                            End If
                            emailTitle = ""
                            emailContent = ""

                            'Insert with in buyer history table accordingly
                            Dim History_Text_Tour As String = "Notification of price reduction was sent to this client who toured property " & lblpropref.Text & " before."
                            Dim sqlBuyerHistoryTour As SqlParameter() = New SqlParameter(7) {}
                            sqlBuyerHistoryTour(0) = New SqlParameter("@Buyer_Id", Convert.ToInt32(dtBuyerEnquiredTourProperty.Tables(0).Rows(nIndex)("buyer_id").ToString()))
                            sqlBuyerHistoryTour(1) = New SqlParameter("@Buyer_Status", 3)
                            sqlBuyerHistoryTour(2) = New SqlParameter("@History_Text", History_Text_Tour)
                            sqlBuyerHistoryTour(3) = New SqlParameter("@Modified_By", Convert.ToInt32(Session("ContactID")))
                            sqlBuyerHistoryTour(4) = New SqlParameter("@Action_Date", System.DateTime.Now)
                            sqlBuyerHistoryTour(5) = New SqlParameter("@Archived", 0)
                            sqlBuyerHistoryTour(6) = New SqlParameter("@Action_Status", "Information Only")

                            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_INSERT", sqlBuyerHistoryTour)

                        Next

                    End If
                End If


            Catch ex As Exception
                Dim str As String = ex.Message.ToString()
            End Try

            'Insert in property history table accordingly 

            Dim sqlPHPriceChange As SqlParameter() = New SqlParameter(7) {}
            sqlPHPriceChange(0) = New SqlParameter("@Property_Ref", lblpropref.Text)
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
            Dim mailBodyStatusChange As String = "Property Status been changed for Property Reference " & lblpropref.Text & "  From " & hdnPropertyStatus.Value & " To " & DropDownListStatus.SelectedItem.Text
            Dim mailBodyStatusChangeForHistory As String = "Property Status been changed for Property Reference " & lblpropref.Text & "  From " & hdnPropertyStatus.Value & " To " & DropDownListStatus.SelectedItem.Text
            mailBodyStatusChange = mailBodyStatusChange & "<br/><br/>"
            mailTitleStatusChange = "Property Reference " & lblpropref.Text & " Property Status is now " & DropDownListStatus.SelectedItem.Text
            Try
                ' Define a New Email
                Dim CEmailStatusChange As New ClassEmail
                Dim isDevORTraining2 As Int16 = 0
                If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                    mailBodyStatusChange = mailBodyStatusChange & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                    CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, DropDownListStatus.SelectedItem.Text, "Dev", 1)
                    isDevORTraining2 = 1
                End If
                If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                    mailBodyStatusChange = mailBodyStatusChange & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                    'CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, DropDownListStatus.SelectedItem.Text, "Training", 1)
                    isDevORTraining2 = 1
                End If
                If isDevORTraining2 = 0 Then
                    mailBodyStatusChange = mailBodyStatusChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                    CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, GetFormInteger(dtPartnerByPostcode.Rows(0)("Default_Partner_ID").ToString()), listerEmail, DropDownListStatus.SelectedItem.Text, "Live", 1)
                End If

            Catch ex As Exception

            End Try

            'Insert in property history table accordingly 

            Dim sqlPHStatusChange As SqlParameter() = New SqlParameter(7) {}
            sqlPHStatusChange(0) = New SqlParameter("@Property_Ref", lblpropref.Text)
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
                sqlUpdateBuyerId(0) = New SqlParameter("@Property_Ref", lblpropref.Text)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_BuyerId", sqlUpdateBuyerId)
            End If

            'If property selected status is Sold OR Sold By Comp OR Withdraw then remove property from featured_property table
            If DropDownListStatus.SelectedItem.Value = "5" Or DropDownListStatus.SelectedItem.Value = "6" Or DropDownListStatus.SelectedItem.Value = "8" Then
                'Remove from featured_property table by selecting property reference
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "delete from featured_property where property_ref='" & lblpropref.Text & "'")
            End If

        End If
        hdnPropertyStatus.Value = DropDownListStatus.SelectedItem.Text
        hdnPublicPrice.Value = txtPublicPrice.Text
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
