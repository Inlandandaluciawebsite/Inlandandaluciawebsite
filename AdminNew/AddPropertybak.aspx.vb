Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO


Partial Class Admin_AddProperty
    Inherits System.Web.UI.Page

    Shared id As Int32 = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblmessage.Text = String.Empty

        If Not IsPostBack Then


            bindvendor()
            bindtype()


            If Request.QueryString.HasKeys() Then
                id = Convert.ToInt32(Request.QueryString(0))
                Dim sql As SqlParameter() = New SqlParameter(2) {}
                sql(0) = New SqlParameter("@property_id", id)
                sql(1) = New SqlParameter("@PartnerId", Convert.ToInt32(Session("ContactPartnerID")))
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_SelectByPropertyId", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    lblpropref.Text = dt.Rows(0)("Property_Ref").ToString()
                    addprop.Style.Add(HtmlTextWriterStyle.Display, "none")
                    addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
                    propform.Style.Add(HtmlTextWriterStyle.Display, "block")
                    propformbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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




                    bindstatus()
                    bindlocation()
                    bindviews()
                    bindyears()
                    bindlawyer()
                    bedrooms()
                    bathrooms()
                    bindpatner()

                    bindregion()
                    If Not dt.Rows(0)("Region_ID").ToString() = "" Then
                        drpArea.SelectedValue = dt.Rows(0)("Region_ID")
                    End If

                    drpArea_SelectedIndexChanged(Nothing, Nothing)
                    If Not dt.Rows(0)("Area_ID").ToString() = "" Then
                        drpTown.SelectedValue = dt.Rows(0)("Area_ID")
                    End If
                    drpTown_SelectedIndexChanged(Nothing, Nothing)
                    If Not dt.Rows(0)("SubArea_ID").ToString() = "" Then
                        drpvillage.SelectedValue = dt.Rows(0)("SubArea_ID")
                    End If
                    ' drpvillage_SelectedIndexChanged(Nothing, Nothing)
                    If Not dt.Rows(0)("Postcode").ToString() = "" Then
                        drppostcode.SelectedValue = dt.Rows(0)("Postcode")
                        ' drppostcode_SelectedIndexChanged(Nothing, Nothing)
                    End If


                    If drpVendor.SelectedValue > 0 Then
                        DropDownListVendor.SelectedValue = Convert.ToInt32(drpVendor.SelectedValue)

                    End If
                    If drpproperty.SelectedValue > 0 Then
                        DropDownListType.SelectedValue = Convert.ToInt32(drpproperty.SelectedValue)
                    End If

                    DropDownListStatus.SelectedValue = 3
                    drplocation.SelectedValue = 0
                    drpviews.SelectedValue = 0
                    drppartner_SelectedIndexChanged(Nothing, Nothing)


                    '''''''''''''''''''''''''''''''''''''''''''''

                    DropDownListVendor.SelectedValue = dt.Rows(0)("Vendor_ID")
                    drpproperty.SelectedValue = dt.Rows(0)("Property_Type_ID")
                    DropDownListType.SelectedValue = dt.Rows(0)("Property_Type_ID")
                    DropDownListStatus.SelectedValue = dt.Rows(0)("Status_ID")
                  
                   
                    drplocation.SelectedValue = dt.Rows(0)("Location_ID")
                    drpviews.SelectedValue = dt.Rows(0)("Views_ID")
                    drpbedrooms.SelectedValue = dt.Rows(0)("Bedrooms")
                    drpbathrooms.SelectedValue = dt.Rows(0)("Bathrooms")
                    drpyearconstructed.SelectedValue = dt.Rows(0)("Year_Constructed")
                    drpPartner.SelectedValue = dt.Rows(0)("Partner_ID")
                    drppartner_SelectedIndexChanged(Nothing, Nothing)
                    drpBroker.SelectedValue = dt.Rows(0)("Broker_ID")
                    If Not String.IsNullOrEmpty(Convert.ToString(dt.Rows(0)("Vendor_Lawyer_ID"))) Then
                        drpVendrlaywer.SelectedValue = dt.Rows(0)("Vendor_Lawyer_ID")

                    End If
                   
                    txtLattitude.Text = dt.Rows(0)("GPS_Latitude")
                    txtLongitude.Text = dt.Rows(0)("GPS_Longitude")
                   
                    txtPublicPrice.Text = dt.Rows(0)("Public_Price")
                    txtOriginalPrice.Text = dt.Rows(0)("Original_Price")
                    txtVendorPrice.Text = dt.Rows(0)("Vendor_Price")
                 
                    txtplot.Text = dt.Rows(0)("SQM_Plot")
                    txtbuilt.Text = dt.Rows(0)("SQM_Built")
                    txtAddress.Text = dt.Rows(0)("Property_Address").ToString()
                    txtYoutubeVideoId.Text = dt.Rows(0)("Video_URL").ToString()

                    txtAnnualIBI.Text = dt.Rows(0)("Annual_IBI").ToString()
                    txtAnnualRubbish.Text = dt.Rows(0)("Annual_Rubbish").ToString()
                    txtCommunityFees.Text = dt.Rows(0)("Community_Fees").ToString()

                    txtterrace.Text = dt.Rows(0)("SQM_Terrace").ToString()
                    txtensuite.Text = dt.Rows(0)("SQM_En_Suite").ToString()
                 
                    txtDoorKey.Text = dt.Rows(0)("Door_Key").ToString()
                
                Else
                    addprop.Style.Add(HtmlTextWriterStyle.Display, "block")
                    addpropbtn.Style.Add(HtmlTextWriterStyle.Display, "block")
                    propform.Style.Add(HtmlTextWriterStyle.Display, "none")
                    propformbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
                End If
            
            End If
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
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Vendor").Tables(0)
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
        sql(1) = New SqlParameter("@ContactPartnerID", Convert.ToInt32(Session("ContactPartnerID")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_GetNextPropertyRef_ByePropertyTypeID", sql).Tables(0)

        If dt.Rows.Count > 0 Then

            lblpropref.Text = dt.Rows(0)("id").ToString()
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
            lblgeneral_Click(Nothing, Nothing)
        End If

    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)


        'SqlParameter[] sql = new SqlParameter[13];
        'sql[0] = new SqlParameter("@Contact_Type_ID", Convert.ToInt32(drpType.SelectedValue ));
        'sql[1] = new SqlParameter("@Contact_Name",txtName.Text);
        'sql[2] = new SqlParameter("@Contact_Registration_Number", txtRegistrationNo.Text);
        'sql[3] = new SqlParameter("@Contact_Address",txtAddress.Text);
        'sql[4] = new SqlParameter("@Contact_Telephone",txtTelephone.Text);
        'sql[5] = new SqlParameter("@Contact_Mobile", txtMobile.Text);
        'sql[6] = new SqlParameter("@Contact_Fax",txtFax.Text);
        'sql[7] = new SqlParameter("@Contact_Email",txtEmail.Text);
        'sql[8] = new SqlParameter("@Contact_Notes", txtNotes.Text);
        'sql[9] = new SqlParameter("@Contact_Language_ID", Convert.ToInt32(drpspoken.SelectedValue));
        'sql[10] = new SqlParameter("@Contact_Partner_ID", Convert.ToInt32(drppartner.SelectedValue ));
        'sql[11] = new SqlParameter("@Contact_Archived", chkArchived.Checked);
        'sql[12] = new SqlParameter("@Contact_ID", id);
        'SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "Usp_CONTACT_Update_Vender", sql).ToString();
        'Response.Redirect("ManageVendor.aspx");


    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("AddVendor.aspx")
    End Sub


    'protected void drppartner_SelectedIndexChanged(object sender, EventArgs e)
    '{
    '    bindbroker();
    '}

    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================

    Private Sub bindernalsection()


    End Sub

    Protected Sub lblgeneral_Click(sender As Object, e As EventArgs)
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


      

        bindstatus()
        bindlocation()
        bindcountry()
        bindarea()

        bindviews()
        bindyears()
        bindlawyer()
        bedrooms()
        bathrooms()
        bindpatner()
        bindregion()
        drpArea_SelectedIndexChanged(Nothing, Nothing)

        If drpVendor.SelectedValue > 0 Then
            DropDownListVendor.SelectedValue = Convert.ToInt32(drpVendor.SelectedValue)

        End If
        If drpproperty.SelectedValue > 0 Then
            DropDownListType.SelectedValue = Convert.ToInt32(drpproperty.SelectedValue)
        End If

        DropDownListStatus.SelectedValue = 3
        drplocation.SelectedValue = 0
        drpviews.SelectedValue = 0
        drppartner_SelectedIndexChanged(Nothing, Nothing)
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
        liimage.Attributes.Remove("class")
        lifeat.Attributes.Remove("class")
        lihist.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
    End Sub

    Protected Sub lblimages_Click(sender As Object, e As EventArgs)
        liimage.Attributes.Add("class", "active")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
        ligen.Attributes.Remove("class")
        lidec.Attributes.Remove("class")
        lifeat.Attributes.Remove("class")
        lihist.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
    End Sub

    Protected Sub lblFeatures_Click(sender As Object, e As EventArgs)
        lifeat.Attributes.Add("class", "active")
        ligen.Attributes.Remove("class")
        lidec.Attributes.Remove("class")
        liimage.Attributes.Remove("class")
        lihist.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
    End Sub

    Protected Sub lblHistory_Click(sender As Object, e As EventArgs)
        lihist.Attributes.Add("class", "active")
        ligen.Attributes.Remove("class")
        lidec.Attributes.Remove("class")
        liimage.Attributes.Remove("class")
        lifeat.Attributes.Remove("class")
        lidocum.Attributes.Remove("class")
        tab5default.Style.Add(HtmlTextWriterStyle.Display, "block")
        tab2default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab3default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab4default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab1default.Style.Add(HtmlTextWriterStyle.Display, "none")
        tab6default.Style.Add(HtmlTextWriterStyle.Display, "none")
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

    End Sub

    Private Sub bindstatus()
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@LanguageId", CUtilities.GetLanguageID(Session("Language")))
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

    Private Sub bindarea()

    End Sub

    Private Sub bindtown()
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@region_id", Convert.ToInt32(drpArea.SelectedValue))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_AreaByRegionId", sql).Tables(0)

        If dt.Rows.Count > 0 Then
           
            drpTown.DataSource = dt
            drpTown.DataTextField = "text"
            drpTown.DataValueField = "id"
            drpTown.DataBind()

            '  bindbroker()

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
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Lawyer").Tables(0)
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
            drppartner.DataSource = dt
            drppartner.DataTextField = "text"
            drppartner.DataValueField = "id"
            drppartner.DataBind()

            '  bindbroker()

        End If
    End Sub
    Protected Sub drppartner_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindbroker()
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

            drpBroker.Items.Insert(0, licategory)


        End If
    End Sub

   
    Protected Sub btnsaveproperty_Click(sender As Object, e As EventArgs)
        Dim sql As SqlParameter() = New SqlParameter(37) {}
        sql(0) = New SqlParameter("@Country_ID", drpCountry.SelectedValue)
        sql(1) = New SqlParameter("@Property_Ref", lblpropref.Text)
        sql(2) = New SqlParameter("@Status_ID", DropDownListStatus.SelectedValue)
        sql(3) = New SqlParameter("@Postcode_ID", drppostcode.SelectedValue)
        sql(4) = New SqlParameter("@Property_Type_ID", drpproperty.SelectedValue)
        sql(5) = New SqlParameter("@GPS_Latitude", IIf(txtLattitude.Text = String.Empty, 0, txtLattitude.Text))
        sql(6) = New SqlParameter("@GPS_Longitude", IIf(txtLongitude.Text = String.Empty, 0, txtLongitude.Text))
        sql(7) = New SqlParameter("@Location_ID", drplocation.SelectedValue)
        sql(8) = New SqlParameter("@Views_ID", drpviews.SelectedValue)
        sql(9) = New SqlParameter("@Public_Price", IIf(txtPublicPrice.Text = String.Empty, 0, txtPublicPrice.Text))
        sql(10) = New SqlParameter("@Original_Price", IIf(txtOriginalPrice.Text = String.Empty, 0, txtOriginalPrice.Text))
        sql(11) = New SqlParameter("@Vendor_Price", IIf(txtVendorPrice.Text = String.Empty, 0, txtVendorPrice.Text))
        sql(12) = New SqlParameter("@Vendor_ID", drpVendor.SelectedValue)
        sql(13) = New SqlParameter("@Broker_ID", drpBroker.SelectedValue)
        sql(14) = New SqlParameter("@Partner_ID", drpPartner.SelectedValue)
        sql(15) = New SqlParameter("@Bedrooms", drpbedrooms.SelectedValue)
        sql(16) = New SqlParameter("@Bathrooms", drpbathrooms.SelectedValue)
        sql(17) = New SqlParameter("@SQM_Plot", IIf(txtplot.Text = String.Empty, 0, txtplot.Text))
        sql(18) = New SqlParameter("@SQM_Built", IIf(txtbuilt.Text = String.Empty, 0, txtbuilt.Text))
        sql(19) = New SqlParameter("@Property_Address", txtAddress.Text)
        sql(20) = New SqlParameter("@Video_URL", txtYoutubeVideoId.Text)
        sql(21) = New SqlParameter("@Property_Notes", "")
        sql(22) = New SqlParameter("@Annual_IBI", IIf(txtAnnualIBI.Text = String.Empty, 0, txtAnnualIBI.Text))
        sql(23) = New SqlParameter("@Annual_Rubbish", IIf(txtAnnualRubbish.Text = String.Empty, 0, txtAnnualRubbish.Text))
        sql(24) = New SqlParameter("@Community_Fees", IIf(txtCommunityFees.Text = String.Empty, 0, txtCommunityFees.Text))
        sql(25) = New SqlParameter("@Year_Constructed", drpyearconstructed.SelectedValue)
        sql(26) = New SqlParameter("@SQM_Terrace", IIf(txtterrace.Text = String.Empty, 0, txtterrace.Text))
        sql(27) = New SqlParameter("@SQM_En_Suite", IIf(txtensuite.Text = String.Empty, 0, txtensuite.Text))
        sql(28) = New SqlParameter("@Num_Photos", 0)
        sql(29) = New SqlParameter("@Listed_By_Contact_ID", Convert.ToInt32(Session("ContactID")))
        sql(30) = New SqlParameter("@Last_Modified", System.DateTime.Now)
        sql(31) = New SqlParameter("@Display", False)
        sql(32) = New SqlParameter("@Viewed", drpviews.SelectedValue)
        sql(33) = New SqlParameter("@Door_Key", txtDoorKey.Text)
        sql(34) = New SqlParameter("@Buyer_Lawyer_ID", 0)
        sql(35) = New SqlParameter("@Vendor_Lawyer_ID", drpVendrlaywer.SelectedValue)
        sql(36) = New SqlParameter("@Buyer_ID", 0)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_property_UpdateGeneral", sql)
        lblmessage.Text = " Property Saved Successfully!"
    End Sub

    Protected Sub drpArea_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindtown()
        bindvillage()
        bindpostcode()

    End Sub

    Protected Sub drpTown_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindvillage()
        drpvillage_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub bindregion()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_AdminRegion_ShowAll").Tables(0)
        If dt.Rows.Count > 0 Then
            
            drpArea.DataSource = dt
            drpArea.DataTextField = "Region_Name"
            drpArea.DataValueField = "Region_ID"
            drpArea.DataBind()
            
            '  bindbroker()


        End If
    End Sub

  

    Private Sub bindvillage()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_AdminLocation_Byparameters").Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dv As New DataView(DirectCast(dt, DataTable))

            ' Filter Results
            dv.RowFilter = "Area_ID = " + drpTown.SelectedValue

            ' Return Results
            dt = dv.ToTable(True, "SubArea_ID", "SubArea_Name")
            If dt.Rows.Count > 1 Then
                subareasection.Style.Add(HtmlTextWriterStyle.Display, "block")
            Else
                subareasection.Style.Add(HtmlTextWriterStyle.Display, "none")
            End If
            drpvillage.DataSource = dt
            drpvillage.DataTextField = "SubArea_Name"
            drpvillage.DataValueField = "SubArea_ID"
            drpvillage.DataBind()

            '  bindbroker()

        End If
    End Sub

    Protected Sub drpvillage_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_AdminLocation_Byparameters").Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dv As New DataView(DirectCast(dt, DataTable))

            ' Filter Region
            dv.RowFilter = "Region_ID = " & drpArea.SelectedValue

            ' Filter Area

            dv.RowFilter &= " and Area_ID = " & drpTown.SelectedValue

            ' Filter Sub Area

            dv.RowFilter &= " and SubArea_ID = " & drpvillage.SelectedValue


            dt = dv.ToTable(True, "Postcode_ID", "Postcode")
            Dim postcodeid As Integer = Convert.ToInt32(dv.ToTable(True, "Postcode_ID").Rows(0).Item("Postcode_ID"))

            drppostcode.SelectedValue = postcodeid
            '  bindbroker()

        End If

    End Sub

    Private Sub bindpostcode()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_AdminLocation_Byparameters").Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dv As New DataView(DirectCast(dt, DataTable))

            ' Filter Results
            dv.RowFilter = "Region_ID = " + drpArea.SelectedValue
            dv.Sort = "Postcode ASC"
            ' Return Results
            dt = dv.ToTable(True, "Postcode_ID", "Postcode")

            drppostcode.DataSource = dt
            drppostcode.DataTextField = "Postcode"
            drppostcode.DataValueField = "Postcode_ID"
            drppostcode.DataBind()

            '  bindbroker()

        End If
    End Sub

    Protected Sub drppostcode_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Local Vars
        Dim nCountryID As Integer = 0
        Dim nRegionID As Integer = 0
        Dim nAreaID As Integer = 0
        Dim nSubAreaID As Integer = 0

        ' If we have Selected Enable All and the Select Option has been Chosen, Reload
       

            ' Get IDs based upon Postcode Selected
        GetFromPostcode(Convert.ToInt32(drppostcode.SelectedValue), nCountryID, nRegionID, nAreaID, nSubAreaID)

            ' Set Flag


            ' Selecting Values
        drpArea.SelectedValue = nRegionID
        drpArea_SelectedIndexChanged(Nothing, Nothing)
        drpTown .SelectedValue = nAreaID
        drpvillage_SelectedIndexChanged(Nothing, Nothing)
        drpvillage.SelectedValue = nSubAreaID

            ' Reset Flag




    End Sub
    Private Sub GetFromPostcode(ByVal nPostcodeID As Integer, ByRef nCountryID As Integer, ByRef nRegionID As Integer, ByRef nAreaID As Integer, ByRef nSubAreaID As Integer)

        ' Load Postcode Table
        '  LoadPostcodeTable()

        ' Define a Data View
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_AdminLocation_Byparameters").Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dv As New DataView(DirectCast(dt, DataTable))
            
            ' Apply Filter
            dv.RowFilter = "Postcode_ID = " & nPostcodeID.ToString.Trim

            ' Assign Results
            nCountryID = Convert.ToInt32(dv.ToTable.Rows(0).Item("Country_ID"))
            nRegionID = Convert.ToInt32(dv.ToTable.Rows(0).Item("Region_ID"))
            nAreaID = Convert.ToInt32(dv.ToTable.Rows(0).Item("Area_ID"))
            nSubAreaID = Convert.ToInt32(dv.ToTable.Rows(0).Item("SubArea_ID"))
        End If
    End Sub

End Class
