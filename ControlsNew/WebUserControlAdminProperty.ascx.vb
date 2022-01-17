Imports System.Data
Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data.SqlClient

Partial Class WebUserControlAdminProperty
    Inherits System.Web.UI.UserControl

    Public Event ViewVendor()

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        Dim nIndex As Integer

        ' Add Items to Categories
        ListBoxCategory.Items.Add("General")
        ListBoxCategory.Items.Add("Descriptions")
        ListBoxCategory.Items.Add("Images")
        ListBoxCategory.Items.Add("Features")
        ListBoxCategory.Items.Add("History")
        ListBoxCategory.Items.Add("Documents")

        ' Type
        CUtilities.PopulateDropDownList(DropDownListType, CDataAccess.PropertyTypes(CUtilities.GetLanguageID(Session("Language"))))
        DropDownListType.Items.Insert(0, "--- Select ---")

        ' Vendors
        LoadVendors()

        ' Status
        CUtilities.PopulateDropDownList(DropDownListStatus, CDataAccess.PropertyStatus(CUtilities.GetLanguageID(Session("Language"))))

        ' Init to For Sale
        DropDownListStatus.SelectedValue = 3

        ' Locations
        CUtilities.PopulateDropDownList(DropDownListLocation, CDataAccess.Locations(CUtilities.GetLanguageID(Session("Language"))))

        ' Select Not Specified
        DropDownListLocation.SelectedValue = 0

        ' Views
        CUtilities.PopulateDropDownList(DropDownListViews, CDataAccess.Views(CUtilities.GetLanguageID(Session("Language"))))

        ' Select Not Specified
        DropDownListViews.SelectedValue = 0

        ' Insert Number of Bedrooms & Bathrooms
        For nIndex = 0 To 15

            ' Add Items
            DropDownListBathrooms.Items.Add(nIndex.ToString.Trim)
            DropDownListBedrooms.Items.Add(nIndex.ToString.Trim)

        Next

        ' Insert Year Constructed
        For nIndex = Today.Year To 1850 Step -1

            ' Add Items
            DropDownListYearConstructed.Items.Add(nIndex.ToString.Trim)

        Next
        DropDownListYearConstructed.Items.Insert(0, "--- Select ---")

        ' Init to Select
        DropDownListYearConstructed.SelectedIndex = 0

        ' Init and Set Partner and Broker Vars
        CUtilities.PopulateDropDownList(DropDownListPartner, CDataAccess.Partners)
        CUtilities.PopulateDropDownList(DropDownListBroker, CDataAccess.Brokers(Convert.ToInt32(DropDownListPartner.SelectedValue)))

        ' Add <None> to Broker
        DropDownListBroker.Items.Insert(0, "--- None ---")

        ' Add Lawyers
        CUtilities.PopulateDropDownList(DropDownListBuyerLawyer, CDataAccess.Lawyers)
        CUtilities.PopulateDropDownList(DropDownListVendorLawyer, CDataAccess.Lawyers)

        ' Add <None> to Lawyers
        DropDownListBuyerLawyer.Items.Insert(0, "--- None ---")
        DropDownListVendorLawyer.Items.Insert(0, "--- None ---")

        ' Load All Areas
        AdminLocation1.ContainingPropertiesOnly = False
        AdminLocation1.AddAllOption = False
        'AdminLocation1.InitData()

        ' Hide Messages
        LabelMessageShort.Visible = False
        LabelMessage.Visible = False

        ' Populate Languages
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
            AddHandler chkFeature.CheckedChanged, AddressOf MakeDirty

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

        ' Add Postback Trigger for Images
        Dim sm As ScriptManager = ScriptManager.GetCurrent(Parent.Page)
        sm.RegisterPostBackControl(ButtonUploadImage)
        sm.RegisterPostBackControl(ButtonUpload)
        sm.RegisterPostBackControl(ButtonDownload)

        ' Make Clean
        MakeClean()

    End Sub

    Private Sub LoadVendors()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities

        ' Vendor
        CUtilities.PopulateDropDownList(DropDownListVendor, CDataAccess.Vendors)
        DropDownListVendor.Items.Insert(0, "--- Select ---")

        ' Tidy
        CDataAccess = Nothing
        CUtilities = Nothing

        '' Init No Vendor
        'InitNoVendor()

    End Sub

    Private Sub EnableMakeDirty(ByVal bEnable As Boolean)

        ' Add / Remove Event Handlers
        DropDownListVendor.AutoPostBack = bEnable
        CheckBoxDisplay.AutoPostBack = bEnable
        DropDownListBathrooms.AutoPostBack = bEnable
        DropDownListBedrooms.AutoPostBack = bEnable
        DropDownListBroker.AutoPostBack = bEnable
        DropDownListBuyer.AutoPostBack = bEnable
        DropDownListBuyerLawyer.AutoPostBack = bEnable
        DropDownListLocation.AutoPostBack = bEnable
        DropDownListUnderOfferTo.AutoPostBack = bEnable
        DropDownListVendorLawyer.AutoPostBack = bEnable
        DropDownListViews.AutoPostBack = bEnable
        DropDownListYearConstructed.AutoPostBack = bEnable
        TextBoxAnnualIBI.AutoPostBack = bEnable
        TextBoxAnnualRubbish.AutoPostBack = bEnable
        TextBoxBuiltSQM.AutoPostBack = bEnable
        TextBoxCommunityFees.AutoPostBack = bEnable
        TextBoxEnSuiteSQM.AutoPostBack = bEnable
        TextBoxLatitude.AutoPostBack = bEnable
        TextBoxLongitude.AutoPostBack = bEnable
        TextBoxOriginalPrice.AutoPostBack = bEnable
        TextBoxPlotSQM.AutoPostBack = bEnable
        TextBoxPropertyAddress.AutoPostBack = bEnable
        TextBoxPublicPrice.AutoPostBack = bEnable
        TextBoxTerraceSQM.AutoPostBack = bEnable
        TextBoxVendorPrice.AutoPostBack = bEnable
        TextBoxVideoURL.AutoPostBack = bEnable
        TextBoxDoorKey.AutoPostBack = bEnable
        TextBoxAddHistory.AutoPostBack = bEnable

    End Sub

    Private Sub MakeDirty()

        ' Check the Session is still Active
        If Session("AdminPropertySelected") Is Nothing Or Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Agent Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Disable Make Dirty
            EnableMakeDirty(False)

            ' If this is the Paryner ID
            If DirectCast(Session("AdminPropertySelected"), ClassProperty).PartnerID = Convert.ToInt32(Session("ContactPartnerID")) Or Convert.ToBoolean(Session("AdminUser")) Then
                ButtonSave.BackColor = Drawing.Color.Red
                ButtonSave.ForeColor = Drawing.Color.White
                ButtonSave.Font.Bold = True
            End If

        End If

    End Sub

    Private Sub MakeClean()

        ' Enable Make Dirty
        EnableMakeDirty(True)

        ' Remove Highlight
        ButtonSave.BackColor = Nothing
        ButtonSave.ForeColor = Nothing
        ButtonSave.Font.Bold = False

    End Sub

    Private Function HideZeros(ByVal nValue As Integer) As String

        If nValue > 0 Then
            Return nValue.ToString.Trim
        Else
            Return String.Empty
        End If

    End Function

    Private Function HideZeros(ByVal dValue As Double) As String

        If dValue <> 0 Then
            Return dValue.ToString.Trim
        Else
            Return String.Empty
        End If

    End Function

    Private Sub DisplayImages(Optional ByVal alAffectedIndexes As ArrayList = Nothing, Optional ByVal bDeletion As Boolean = False)

        ' Local Vars
        Dim nIndex As Integer

        ' If we have Loaded Images
        If Not Session("PropertyAdminImages") Is Nothing Then

            ' If we aren't Dealing with Affected Indexes
            If alAffectedIndexes Is Nothing Then

                ' For each Image
                For nIndex = 1 To 16

                    ' If we have a URL as this Location
                    If nIndex <= DirectCast(Session("PropertyAdminImages"), ClassImages).Count Then

                        ' Assign the URL to this Control
                        DirectCast(FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImage).LoadImage(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage))

                        ' Set Header Image
                        DirectCast(FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImage).MakeHeaderImage(nIndex = 1)

                        ' Enable / Disable
                        DirectCast(FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImage).Enable(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage).Enabled)

                        ' Make Visible
                        FindControl("AdminPropertyImage" & nIndex.ToString.Trim).Visible = True

                    Else

                        ' Make Invisible
                        FindControl("AdminPropertyImage" & nIndex.ToString.Trim).Visible = False

                    End If

                Next

            Else

                ' Specific Indexes being Updated
                For Each nIndex In alAffectedIndexes

                    ' Assign the URL to this Control
                    DirectCast(FindControl("AdminPropertyImage" & (nIndex).ToString.Trim), WebUserControlAdminPropertyImage).LoadImage(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage))

                    ' Set Header Image
                    DirectCast(FindControl("AdminPropertyImage" & (nIndex).ToString.Trim), WebUserControlAdminPropertyImage).MakeHeaderImage(nIndex = 1)

                    ' Make Visible
                    FindControl("AdminPropertyImage" & (nIndex).ToString.Trim).Visible = True

                Next

            End If

        End If

    End Sub

    Private Sub InitCheckBoxes(ByRef ctrlParent As Control)

        ' For each CheckBox in the Control
        For Each ctrl As Control In ctrlParent.Controls

            ' If this is a Checkbox
            If TypeOf (ctrl) Is CheckBox Then

                ' Uncheck
                DirectCast(ctrl, CheckBox).Checked = False

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Clear any Previous Status Messages
        LabelStatus.Text = String.Empty
        LabelMessage.Visible = False
        LabelMessageShort.Visible = False

        ' Hide Rows
        TableRowHistoryElement.Visible = False
        TableRowHistoryArchive.Visible = False
        TableRowEmailSent.Visible = False
        TableRowFileLimitExceeded.Visible = False

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

    End Sub

    Public Sub InitData(ByVal CProperty As ClassProperty)

        ' If we are not Bulk Loading Images
        If Session("AdminPropertyBulkImageUpload") Is Nothing Then

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities

            ' Seeting Visibility of Client Details Button
            ButtonViewVendor.Visible = CProperty.VendorID > 0

            '''' OVERVIEW ''''

            ' Set Save Buttons Visibility
            ButtonSave.Visible = (CProperty.PartnerID = Session("ContactPartnerID")) Or Convert.ToBoolean(Session("AdminUser"))
            ButtonAutoTranslateShort.Visible = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            ButtonSaveShortDescription.Visible = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            ButtonAutoTranslate.Visible = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            ButtonSaveDescription.Visible = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            'FileUploadImage.Enabled = ButtonSave.Visible
            'ButtonUploadImage.Enabled = ButtonSave.Visible
            'TableRowFolderOptions.Enabled = ButtonSave.Visible

            ' Enable / Disable Tables
            TableGeneral.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            TableDescription.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            TableUploadImages.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            TableImages.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            TableFeatures.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            TableHistory.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))
            TableDocuments.Enabled = ButtonSave.Visible Or Convert.ToBoolean(Session("AdminUser"))

            ' If this is not a New Property
            If Not CProperty.ID = 0 Then

                ' Set the Reference
                LabelPropertyReference.Text = CProperty.Reference

            End If

            '''' GENERAL ''''

            ' Assign Form Variables from the Property Class
            TextBoxPropertyAddress.Text = CProperty.Address.Trim
            LabelPropertyAddress.Text = TextBoxPropertyAddress.Text
            TextBoxAnnualIBI.Text = HideZeros(CProperty.AnnualIBI)
            TextBoxAnnualRubbish.Text = HideZeros(CProperty.AnnualRubbish)
            DropDownListBathrooms.SelectedValue = CProperty.Bathrooms.ToString.Trim
            DropDownListBedrooms.SelectedValue = CProperty.Bedrooms.ToString.Trim
            TextBoxBuiltSQM.Text = HideZeros(CProperty.Built)
            TextBoxCommunityFees.Text = HideZeros(CProperty.CommunityFees)
            CheckBoxDisplay.Checked = CProperty.Display
            TextBoxEnSuiteSQM.Text = HideZeros(CProperty.EnSuite)
            CheckBoxFeature.Checked = CProperty.Featured
            TextBoxLatitude.Text = HideZeros(CProperty.Latitude)
            DropDownListLocation.SelectedValue = CProperty.LocationID
            TextBoxLongitude.Text = HideZeros(CProperty.Longitude)
            TextBoxOriginalPrice.Text = HideZeros(CProperty.OriginalPrice)
            TextBoxPlotSQM.Text = HideZeros(CProperty.Plot)
            AdminLocation1.MustIncludePostcodeID = CProperty.PostcodeID
            AdminLocation1.InitData(CProperty.PostcodeID)
            TextBoxPublicPrice.Text = HideZeros(CProperty.PublicPrice)
            DropDownListStatus.SelectedValue = CProperty.StatusID
            TextBoxTerraceSQM.Text = HideZeros(CProperty.Terrace)

            ' If we don't have a Property Type ID
            If CProperty.TypeID = 0 Then
                DropDownListType.SelectedIndex = -1
            Else
                DropDownListType.SelectedValue = CProperty.TypeID
            End If

            ' Continue to Init Vars
            TextBoxVendorPrice.Text = HideZeros(CProperty.VendorPrice)
            DropDownListViews.SelectedValue = CProperty.ViewsID

            ' If we have a Construction Year
            If CProperty.YearConstructed > 0 Then
                DropDownListYearConstructed.SelectedValue = CProperty.YearConstructed
            End If

            ' Continue to Init Vars
            TextBoxVideoURL.Text = CProperty.YouTubeVideoID
            TextBoxDoorKey.Text = CProperty.DoorKey

            ' Select Partner
            DropDownListPartner.SelectedValue = CProperty.PartnerID

            ' Update Brokers
            DropDownListPartner_SelectedIndexChanged(Nothing, Nothing)

            ' If we have a Broker
            If CProperty.BrokerID > 0 Then

                ' Select the Broker
                DropDownListBroker.SelectedValue = CProperty.BrokerID

            Else

                ' Get the Broker ID
                Dim nBrokerID As Integer = CDataAccess.PartnerID(CProperty.VendorID)

                ' Does the Broker Exist in the List?
                If DropDownListBroker.Items.FindByValue(nBrokerID.ToString.Trim) Is Nothing Then

                    ' Init to None
                    DropDownListBroker.SelectedIndex = 0

                Else

                    ' Select Value
                    DropDownListBroker.SelectedValue = CDataAccess.PartnerID(CProperty.VendorID)

                End If

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
            TableRowBuyerLawyer.Visible = (CProperty.StatusID = 7)

            ' Vendor Lawyer
            If CProperty.VendorLawyerID > 0 Then

                ' Select the Lawyer
                DropDownListVendorLawyer.SelectedValue = CProperty.VendorLawyerID

            Else

                ' Init to None
                DropDownListVendorLawyer.SelectedIndex = 0

            End If

            ' Init to the Last People who Viewed this Property on a Tour in Date Descending Order
            CUtilities.PopulateDropDownList(DropDownListUnderOfferTo, CDataAccess.PropertyLastTouredBuyers(CProperty.ID))

            ' If we have a Buyer ID
            If CProperty.BuyerID > 0 Then

                ' If it Exists in our DropDown
                If DropDownListUnderOfferTo.Items.Contains(DropDownListUnderOfferTo.Items.FindByValue(CProperty.BuyerID.ToString)) Then

                    ' Select this Item
                    DropDownListUnderOfferTo.SelectedValue = CProperty.BuyerID.ToString

                End If

            End If

            ' Set Visibility of Property Status Options
            SetStatusOptionsVisibility()

            ' Update URLs
            ButtonWindowcard.OnClientClick = "javascript:window.open('/windowcard.aspx?propertyid=" & CProperty.ID.ToString.Trim & "');return false;"
            ButtonViewingPhotos.OnClientClick = "javascript:window.open('/Admin/ViewingPhotos.aspx?PropertyRef=" & CProperty.Reference.Trim & "');return false;"

            ' Set Visibility of Windowcard (for Sale or Under Offer)
            ButtonWindowcard.Visible = (CProperty.StatusID = 2 Or CProperty.StatusID = 7)

            '''' DESCRIPTIONS ''''

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

            '''' IMAGES ''''

            ' Local Vars
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

            ' Init Checkboxes
            InitCheckBoxes(Column1)
            InitCheckBoxes(Column2)
            InitCheckBoxes(Column3)
            InitCheckBoxes(Column4)

            ' For each Feature this Property has
            For Each nID In CProperty.FeatureIDs

                ' If we have Found this Control
                If Not FindControl(nID.ToString.Trim) Is Nothing Then

                    ' Get this Control
                    DirectCast(FindControl(nID.ToString.Trim), CheckBox).Checked = True

                End If

            Next

            '''' HISTORY ''''
            LoadHistory(CProperty)

            '''' DOCUMENTS ''''

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
            DropDownListPartner.Enabled = DirectCast(Session("AdminUser"), Boolean)

            ' Set General Visibility
            SetGeneralVisibility(CProperty.VendorID > 0 And CProperty.TypeID > 0)

            ' Set Visibility
            SetVisibility()

            ' Clean
            MakeClean()

        End If

    End Sub

    Private Sub SetGeneralVisibility(ByVal bVendorTypeSpecified As Boolean)

        ' Set Vendor Enabled
        DropDownListVendor.Enabled = True ' Not bVendorTypeSpecified
        DropDownListType.Enabled = Not bVendorTypeSpecified

        ' Set Visiblity
        For Each tr As TableRow In TableGeneral.Rows

            ' If not the Vendor
            If tr.ID <> "TableRowVendor" _
                And tr.ID <> "TableRowPropertyType" _
                And tr.ID <> "TableRowBuyerLawyer" _
                And tr.ID <> "TableRowUnderOfferTo" _
                And tr.ID <> "TableRowDisplayProperty" _
                And tr.ID <> "TableRowFeatureProperty" Then

                ' Set Visibility
                tr.Visible = bVendorTypeSpecified

            End If

        Next

    End Sub

    Private Sub SetVisibility()

        ' Local Vars
        Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)

        ' Init Reference
        LabelPropertyReference.Text = String.Empty

        '' Set the Reference
        'If Convert.ToInt32(Session("ContactPartnerID")) = 3864 Then

        ' Set IA Reference
        LabelPropertyReference.Text = CProperty.Reference

        ' If we have a CA Ref
        If CProperty.CAReference.Trim <> String.Empty Then

            ' Add the CA Ref
            LabelPropertyReference.Text &= "<br/>" & CProperty.CAReference

        End If

        'End If

        ' If Reference not Set
        If LabelPropertyReference.Text.Trim = String.Empty Then

            ' IA Ref
            LabelPropertyReference.Text = CProperty.Reference

        End If

        ' Set Control Visibility
        LabelPropertyReference.Visible = LabelPropertyReference.Text.Trim <> String.Empty
        ListBoxCategory.Visible = LabelPropertyReference.Visible

        ' If the Categories are Visible
        If ListBoxCategory.Visible Then

            ' If nothing is Selected
            If ListBoxCategory.SelectedIndex < 0 Then

                ' Select General
                ListBoxCategory.SelectedIndex = 0
                ListBoxCategory_SelectedIndexChanged(Nothing, Nothing)

            End If

        End If

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

                    ' Inform the User
                    Message("Status of 'Under Offer'", alMessage, False)

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

    Private Sub SetStatusOptionsVisibility()

        ' If this Property is Under Offer, display the Drop Down of Potential Buyers
        TableRowUnderOfferTo.Visible = (DropDownListStatus.SelectedValue = 7) And (DropDownListUnderOfferTo.Items.Count > 0)

        '' If this Property is For Sale / Under Offer, Display the Display property Checkbox
        ' GG Requested Change on 15/01/2015 - Never Display
        'TableRowDisplayProperty.Visible = (DropDownListStatus.SelectedValue = 2 Or DropDownListStatus.SelectedValue = 7)

        ' If this Property is for Sale, display the Featured Property CheckBox
        TableRowFeatureProperty.Visible = (DropDownListStatus.SelectedValue = 2)

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

    Protected Sub TreeViewBrowser_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeViewBrowser.SelectedNodeChanged

        ' If this Value has a File Extention
        If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

            ' A Directory
            LoadDirectory(TreeViewBrowser.SelectedNode)

        End If

        ' If the Form is Enabled
        If ButtonSave.Visible Then

            ' Update Buttons
            Updating(False)

        End If

        ' Store the Selected Value
        Session("AdminFileExplorerSelectedNode") = TreeViewBrowser.SelectedNode

    End Sub

    Public Sub ImageDelete(ByVal nPosition As Integer)

        ' Remove this from the Array of those Selected
        DirectCast(Session("PropertyAdminImages"), ClassImages).Remove(nPosition)

        ' Display the Images
        DisplayImages(, True)

        ' Enable / Disable Image Upload Button
        DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)

        ' Make Dirty
        MakeDirty()

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
        MakeDirty()

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
        MakeDirty()

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
        MakeDirty()

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
        MakeDirty()

    End Sub

    'Public Sub InitNoVendor()

    '    ' Init Vendor Drop Down
    '    DropDownListVendor.SelectedIndex = 0

    '    ' Clean
    '    MakeClean()

    'End Sub

    'Public Sub InitVendor()

    '    ' Init Vendor Drop Down
    '    DropDownListVendor.SelectedValue = Convert.ToInt32(Session("ContactAdminContactID"))

    '    ' Clean
    '    MakeClean()

    'End Sub

    Private Function VendorTypeSelected() As Boolean
        Return DropDownListVendor.SelectedIndex > 0 And DropDownListType.SelectedIndex > 0
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
        CProperty.Address = TextBoxPropertyAddress.Text.Trim
        CProperty.AnnualIBI = GetFormDouble(TextBoxAnnualIBI.Text.Trim)
        CProperty.AnnualRubbish = GetFormDouble(TextBoxAnnualRubbish.Text.Trim)
        CProperty.AreaID = AdminLocation1.AreaID
        CProperty.Bathrooms = GetFormInteger(DropDownListBathrooms.SelectedItem.ToString)
        CProperty.Bedrooms = GetFormInteger(DropDownListBedrooms.SelectedItem.ToString)

        ' Check if we have a Broker
        If DropDownListBroker.SelectedIndex > 0 Then
            CProperty.BrokerID = GetFormInteger(DropDownListBroker.SelectedValue.ToString)
        Else
            CProperty.BrokerID = 0
        End If

        ' Continue to Populate Vars
        CProperty.Built = Math.Round(GetFormDouble(TextBoxBuiltSQM.Text.Trim))

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
        CProperty.CommunityFees = GetFormDouble(TextBoxCommunityFees.Text.Trim)
        CProperty.Display = CheckBoxDisplay.Checked
        CProperty.DoorKey = TextBoxDoorKey.Text.Trim
        CProperty.EnSuite = Math.Round(GetFormDouble(TextBoxEnSuiteSQM.Text.Trim))
        CProperty.Featured = CheckBoxFeature.Checked
        CProperty.Latitude = GetFormDouble(TextBoxLatitude.Text.Trim)
        CProperty.LocationID = GetFormInteger(DropDownListLocation.SelectedValue)
        CProperty.Longitude = GetFormDouble(TextBoxLongitude.Text.Trim)
        CProperty.OriginalPrice = GetFormInteger(TextBoxOriginalPrice.Text.Trim)
        'CProperty.PartnerID = GetFormInteger(DropDownListPartner.SelectedValue.ToString)
        CProperty.Plot = Math.Round(GetFormDouble(TextBoxPlotSQM.Text.Trim))
        CProperty.PostcodeID = AdminLocation1.PostcodeID

        'Here i am getting default partner id by postcodeid

        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@PostCode_Id", CProperty.PostcodeID)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_POSTCODE_Select_By_PostCode_Id", sql).Tables(0)
        CProperty.PartnerID = GetFormInteger(dt.Rows(0)("Default_Partner_ID").ToString())

        CProperty.PublicPrice = GetFormInteger(TextBoxPublicPrice.Text.Trim)
        CProperty.RegionID = AdminLocation1.RegionID
        CProperty.StatusID = GetFormInteger(DropDownListStatus.SelectedValue)
        CProperty.SubAreaID = AdminLocation1.SubAreaID
        CProperty.Terrace = Math.Round(GetFormDouble(TextBoxTerraceSQM.Text.Trim))
        CProperty.TypeID = GetFormInteger(DropDownListType.SelectedValue)
        CProperty.VendorID = GetFormInteger(DropDownListVendor.SelectedValue)
        CProperty.VendorLawyerID = GetFormInteger(DropDownListVendorLawyer.SelectedValue.ToString)
        CProperty.VendorPrice = GetFormInteger(TextBoxVendorPrice.Text.Trim)
        CProperty.ViewsID = GetFormInteger(DropDownListViews.SelectedValue)
        CProperty.YearConstructed = GetFormInteger(DropDownListYearConstructed.SelectedItem.ToString)
        CProperty.YouTubeVideoID = TextBoxVideoURL.Text.Trim

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

        ' If we have an Original Price
        If CProperty.OriginalPrice > 0 Then

            ' Check Original Price > Public Price
            If CProperty.OriginalPrice < CProperty.PublicPrice Then

                ' Init Message
                alMessage.Add("The original price cannot be less than the public price")

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

    Private Function PopulateSaveDataDescription(ByRef CProperty As ClassProperty) As Boolean

        ' Populate the Class with the Descriptions we have

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

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' Check we have all the Login Info
        If Session("ContactID") Is Nothing Or Session("ContactPartnerID") Is Nothing Or Session("AdminPropertySelected") Is Nothing Then

            ' Session Expired - Redirect to the Login Page
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
            Dim bError As Boolean
            Dim szSaveMessage As String = String.Empty
            Dim alMessage As ArrayList

            ' Are we saving the Property Type to get a Reference?
            If CProperty.Reference = String.Empty Then

                ' Save the Vendor and Type
                CProperty.VendorID = GetFormInteger(DropDownListVendor.SelectedValue)
                CProperty.TypeID = GetFormInteger(DropDownListType.SelectedValue)

                ' If these are Valid
                If CProperty.VendorID > 0 And CProperty.TypeID > 0 Then

                    ' Get the Reference(s)
                    Dim CDataAccess As New ClassDataAccess

                    ' Save the Property Reference
                    CProperty.Reference = CDataAccess.GetNextPropertyRef(CProperty.TypeID)

                    ' If this User ID is a CA User
                    If Convert.ToInt32(Session("ContactPartnerID")) = 3864 Then
                        CProperty.CAReference = CDataAccess.GetNextPropertyCARef.ToString.Trim
                    End If

                    ' Tidy
                    CDataAccess = Nothing

                    ' Set the Save Message
                    szSaveMessage = "Reference Saved"

                Else

                    ' Create Message Array
                    alMessage = New ArrayList

                    ' Create the Message
                    alMessage.Add("Please select a vendor and property type before saving")

                    ' Inform the User
                    Message("Missing Data", alMessage, False)

                    ' Tidy
                    alMessage.Clear()
                    alMessage = Nothing

                    ' Set Error Flag
                    bError = True

                End If

            Else

                ' Saving Pre Existing Property

                ' If no Errors
                If Not bError Then

                    ' If we have Images
                    If Not Session("PropertyAdminImages") Is Nothing Then
                        CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
                    End If

                    ' Assign to the Class               
                    bError = PopulateSaveDataDescription(CProperty)
                    bError = bError Or PopulateSaveDataHistory(CProperty)
                    bError = bError Or PopulateSaveDataGeneral(CProperty)
                    bError = bError Or PopulateSaveDataFeatures(CProperty)                    

                    ' Set the Save Message
                    If bError Then
                        szSaveMessage = "An error occurred whilst populating the save data for this Property"
                    Else
                        szSaveMessage = "Property Details Saved"
                    End If

                End If

            End If

            ' If no Errors
            If Not bError Then

                ' Save this Property to the Database
                bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))

                ' If we had an Error
                If bError Then
                    szSaveMessage = "An error occurred whilst saving this property to the database"
                End If

            End If

            ' Display Message
            LabelStatus.Text = szSaveMessage

            ' If we did not have an Error
            If Not bError Then

                ' Reload Data
                If CProperty.ID < 1 Then
                    CProperty.Load(CProperty.Reference)
                Else
                    CProperty.Load(CProperty.ID)
                End If

                ' Reinitialise the Form
                InitData(CProperty)

            End If

        End If

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

    Protected Sub ListBoxCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxCategory.SelectedIndexChanged

        ' Hide / Display Header
        LabelPropertyReference.Visible = (LabelPropertyReference.Text.Trim <> String.Empty)
        ListBoxCategory.Visible = LabelPropertyReference.Visible

        ' Hide All Tables
        TableGeneral.Visible = False
        TableDescription.Visible = False
        TableUploadImages.Visible = False
        TableImages.Visible = False
        TableFeatures.Visible = False
        TableHistory.Visible = False
        TableDocuments.Visible = False

        ' Depending on Option Selected
        Select Case ListBoxCategory.SelectedIndex

            Case 1
                ' Description
                TableDescription.Visible = True

            Case 2
                ' Images
                TableUploadImages.Visible = True
                TableImages.Visible = True

                ' Set Visibility of Upload Image Button
                DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)

            Case 3
                ' Features
                TableFeatures.Visible = True

            Case 4
                ' History
                TableHistory.Visible = True

            Case 5
                ' Documents
                TableDocuments.Visible = True

            Case Else
                ' General
                TableGeneral.Visible = True

        End Select

    End Sub

    Private Sub HideDescriptionMessages()

        ' Hide Messages
        LabelMessage.Visible = False
        LabelMessageShort.Visible = False

    End Sub

    Private Sub MakeDescriptionClean()

        ' Clean 
        ButtonSaveShortDescription.BackColor = Nothing
        ButtonSaveShortDescription.ForeColor = Nothing
        ButtonSaveShortDescription.Font.Bold = False
        ButtonSaveDescription.BackColor = Nothing
        ButtonSaveDescription.ForeColor = Nothing
        ButtonSaveDescription.Font.Bold = False

    End Sub

    Protected Sub DropDownListLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListLanguage.SelectedIndexChanged

        ' Hide Messages
        HideDescriptionMessages()

        ' Check we have a Value
        If DropDownListLanguage.SelectedValue <> String.Empty Then

            ' Populate Drop Down Lists with Descriptions
            TextBoxShortDescription.Text = HttpUtility.HtmlDecode(DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)))
            TextBoxDescription.Text = HttpUtility.HtmlDecode(DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(DropDownListLanguage.SelectedValue)))

            ' Clean the Form
            MakeDescriptionClean()

        End If

    End Sub

    Protected Sub CheckBoxDisplay_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxDisplay.CheckedChanged
        MakeDirty()
    End Sub

    Protected Sub CheckBoxFeature_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxFeature.CheckedChanged
        MakeDirty()
    End Sub

    Protected Sub AdminLocation1_Dirty() Handles AdminLocation1.Dirty
        MakeDirty()
    End Sub

    Protected Sub TextBoxPropertyAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPropertyAddress.TextChanged

        ' Define Regex
        Dim rgx As Regex = New Regex("[^a-zA-Z0-9 -]")

        ' If the Address has Changed
        If rgx.Replace(TextBoxPropertyAddress.Text.Trim, "") <> rgx.Replace(LabelPropertyAddress.Text.Trim, "") Then
            MakeDirty()
        End If

    End Sub

    Protected Sub TextBoxLatitude_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxLatitude.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxLongitude_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxLongitude.TextChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListViews_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListViews.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListBedrooms_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListBedrooms.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListBathrooms_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListBathrooms.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListYearConstructed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListYearConstructed.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxPlotSQM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPlotSQM.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxBuiltSQM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxBuiltSQM.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxTerraceSQM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxTerraceSQM.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxEnSuiteSQM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxEnSuiteSQM.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxAnnualIBI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAnnualIBI.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxAnnualRubbish_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAnnualRubbish.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxCommunityFees_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxCommunityFees.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxVendorPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxVendorPrice.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxOriginalPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxOriginalPrice.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxPublicPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPublicPrice.TextChanged
        MakeDirty()
    End Sub

    Protected Sub TextBoxVideoURL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxVideoURL.TextChanged
        MakeDirty()
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

        MakeDirty()

    End Sub

    Protected Sub DropDownListBroker_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListBroker.SelectedIndexChanged
        MakeDirty()
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
                DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = CUtilities.Translate(TextBoxDescription.Text.Trim, lstItem.Value, DropDownListLanguage.SelectedValue)
                CUtilities = Nothing

            End If

        Next

        ' Make the Save Button Clean
        ButtonSaveDescription.BackColor = Nothing
        ButtonSaveDescription.ForeColor = Nothing
        ButtonSaveDescription.Font.Bold = False

        ' Dirty
        MakeDirty()

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
                DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = CUtilities.Translate(TextBoxShortDescription.Text.Trim, lstItem.Value, DropDownListLanguage.SelectedValue)
                CUtilities = Nothing

            End If

        Next

        ' Make the Save Button Clean
        ButtonSaveShortDescription.BackColor = Nothing
        ButtonSaveShortDescription.ForeColor = Nothing
        ButtonSaveShortDescription.Font.Bold = False

        ' Dirty
        MakeDirty()

        ' Display Message
        LabelMessageShort.Text = "Translations have been Completed"
        LabelMessageShort.Visible = True

    End Sub

    Protected Sub ButtonSaveDescription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSaveDescription.Click

        ' Mark the Property as Dirty
        MakeDirty()

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
        MakeDirty()

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

                    End If
                Next

            End If

        End If

    End Sub

    Protected Sub TextBoxAddHistory_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxAddHistory.TextChanged
        MakeDirty()
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

    Private Sub Message(ByVal szTitle As String, ByVal alMessage As ArrayList, Optional ByVal bBulletPoints As Boolean = False)

        ' Hide Header
        LabelPropertyReference.Visible = False
        ListBoxCategory.Visible = False

        ' Hide All Tables
        TableGeneral.Visible = False
        TableDescription.Visible = False
        TableUploadImages.Visible = False
        TableImages.Visible = False
        TableFeatures.Visible = False
        TableHistory.Visible = False
        TableDocuments.Visible = False
        TableSave.Visible = False

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

    Protected Sub ButtonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOK.Click

        ' Hide Message
        TableMessage.Visible = False

        ' Redisplay Option
        ListBoxCategory_SelectedIndexChanged(Nothing, Nothing)

        ' Redisplay Save
        TableSave.Visible = True

    End Sub

    Protected Sub ButtonEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmail.Click

        ' Set to Updating
        Updating(True)

        ' Hide the Document Table
        TableDocuments.Visible = False

        ' Hide the Property Ref Label
        LabelPropertyReference.Visible = False

        ' Hide Category Selection
        ListBoxCategory.Visible = False

        ' Hide Save Button
        ButtonSave.Visible = False

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
        LabelPropertyReference.Visible = True

        ' Display Category Selection
        ListBoxCategory.Visible = True

        ' Show Save Button
        ButtonSave.Visible = True

        ' Display the Documents Table
        TableDocuments.Visible = True

        ' Reselect Parent
        TreeViewBrowser.Nodes(0).Selected = True
        TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)

        ' No longer Updating
        Updating(False)

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

    Protected Sub ButtonViewVendor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonViewVendor.Click

        ' Local Vars
        Dim CContact As New ClassContact()

        ' Load this Contact's Details
        Dim CDataAccess As New ClassDataAccess
        CContact.Load(Convert.ToInt32(DropDownListVendor.SelectedValue))
        CDataAccess = Nothing

        ' Assign to Session Variable
        Session("AdminContactSelected") = CContact

        ' Raise Event
        RaiseEvent ViewVendor()

    End Sub

    Protected Sub DropDownListVendor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListVendor.SelectedIndexChanged

        ' Only Make Dirty if the Vendor and Type have been Defined
        If ListBoxCategory.Visible Then
            MakeDirty()
        End If

    End Sub

    Protected Sub TextBoxDoorKey_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxDoorKey.TextChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListUploadImageOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListUploadImageOption.SelectedIndexChanged

        ' Make the Upload Image Visible / Invisible
        TableRowImageOptions.Visible = (Not AdminPropertyImage16.Visible) Or (AdminPropertyImage16.Visible And DropDownListUploadImageOption.SelectedIndex = 2)
        AjaxBulkFileUploadImage.Visible = TableRowImageOptions.Visible

    End Sub

    Protected Sub DropDownListBuyerLawyer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListBuyerLawyer.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListVendorLawyer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListVendorLawyer.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListHistoryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListHistoryType.SelectedIndexChanged

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

        ' If Dirty
        If bDirty Then

            ' Make Dirty 
            MakeDirty()

        End If

    End Sub

    Protected Sub DropDownListUnderOfferTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListUnderOfferTo.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListBuyer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListBuyer.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub ButtonBulkUploadImage_Click(sender As Object, e As EventArgs) Handles ButtonBulkUploadImage.Click

        ' Display / Hide Control
        TableRowBulkImageUpload.Visible = Not TableRowBulkImageUpload.Visible

        ' Enable / Disable Associated Controls
        FileUploadImage.Enabled = Not TableRowBulkImageUpload.Visible
        DropDownListUploadImageOption.Enabled = Not TableRowBulkImageUpload.Visible
        ButtonUploadImage.Enabled = Not TableRowBulkImageUpload.Visible

        ' If Visible
        If TableRowBulkImageUpload.Visible Then

            ' Highlight
            ButtonBulkUploadImage.BackColor = Drawing.Color.Red
            ButtonBulkUploadImage.ForeColor = Drawing.Color.White
            ButtonBulkUploadImage.Font.Bold = True

        Else

            ' Remove Highlight
            ButtonBulkUploadImage.BackColor = Nothing
            ButtonBulkUploadImage.ForeColor = Nothing
            ButtonBulkUploadImage.Font.Bold = False

        End If

    End Sub

    Private Sub UploadImage(ByVal szFilename As String, ByVal strFile As IO.Stream, Optional ByVal bBulk As Boolean = False)

        ' Only do the Following if we don't already have the Maximum Number of Properties
        If DirectCast(Session("PropertyAdminImages"), ClassImages).Count < 16 Then

            ' Mark Property as Dirty
            MakeDirty()

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
                CUtilities.ApplyIAWatermark(imgImage)
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

    Protected Sub ghostAjaxFileUpload_UploadComplete(sender As Object, e As AjaxControlToolkit.AjaxFileUploadEventArgs) Handles ghostAjaxFileUpload.UploadComplete

        ' Upload Image
        UploadImage(e.FileName, e.GetStreamContents, True)

    End Sub

    Protected Sub ghostAjaxFileUpload_UploadStart(sender As Object, e As AjaxControlToolkit.AjaxFileUploadStartEventArgs) Handles ghostAjaxFileUpload.UploadStart

        ' Set Flag
        Session("AdminPropertyBulkImageUpload") = True

    End Sub

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

    End Sub

End Class
