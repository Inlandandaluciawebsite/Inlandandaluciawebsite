Imports Microsoft.VisualBasic
Imports System.IO
Imports ClassHistory

Public Class BackOffice
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Session Variables
        If Session("AdminDisplayingMessage") Is Nothing Then
            Session("AdminDisplayingMessage") = False
        End If
        If Session("AdminPropertyEdit") Is Nothing Then
            Session("AdminPropertyEdit") = False
        End If

        ' Create Previous Control
        CreateControl()

        ' Load Header Image
        ImageHeader.ImageUrl = "http://www.inlandandalucia.com/Images/Admin/header.jpg"

        ' Load the Button Images
        ImageButtonBack.ImageUrl = GetBackImagePath()
        ImageButtonForward.ImageUrl = GetForwardImagePath()
        ImageButtonSignOut.ImageUrl = GetSignOutImagePath()

        '' Add Postback Trigger for Images
        'Dim sm As ScriptManager = ScriptManager.GetCurrent(Page)
        'sm.RegisterPostBackControl(AdminNavigation)

    End Sub

    Private Sub CreateControl(Optional ByVal bSaveState As Boolean = True, Optional ByVal objParam1 As Object = Nothing)

        ' If this is a Lawyer
        If Convert.ToInt32(Session("ContactType")) = 2 Then

            ' Only 1 Control
            CreateLawyerArea()

        Else

            ' If we have an Active Control
            If Not Session("AdminActiveControl") Is Nothing Then

                ' If Saving
                If bSaveState Then

                    ' Save Current Control
                    SaveControlValues()

                End If

                ' ReAdd
                Select Case Session("AdminActiveControl").GetType

                    Case GetType(ASP.controls_webusercontroladminbuyer_ascx)
                        CreateBuyer()

                    Case GetType(ASP.controls_webusercontroladminbuyersearch_ascx)
                        CreateBuyerSearch()

                    Case GetType(ASP.controls_webusercontroladminclienttour_ascx)
                        If objParam1 Is Nothing Then
                            CreateClientTour()
                        Else
                            CreateClientTour(, DirectCast(objParam1, Boolean))
                        End If

                    Case GetType(ASP.controls_webusercontroladminclienttourfeedback_ascx)
                        CreateClientTourFeedback()

                    Case GetType(ASP.controls_webusercontroladminclienttourpropertyselection_ascx)
                        CreateClientTourPropertySelection()

                    Case GetType(ASP.controls_webusercontroladminclienttoursearch_ascx)
                        CreateClientTourSearch()

                    Case GetType(ASP.controls_webusercontroladmincontact_ascx)
                        CreateContact()

                    Case GetType(ASP.controls_webusercontroladmincontactsearch_ascx)
                        CreateContactSearch()

                    Case GetType(ASP.controls_webusercontroladmincontacttype_ascx)
                        CreateContactType()

                    Case GetType(ASP.controls_webusercontroladmindatabasestatistics_ascx)
                        CreateDatabaseStatistics()

                    Case GetType(ASP.controls_webusercontroladminmessage_ascx)
                        CreateMessage()

                    Case GetType(ASP.controls_webusercontroladminfeaturedproperties_ascx)
                        CreateFeaturedProperties()

                    Case GetType(ASP.controls_webusercontroladminhistorytypes_ascx)
                        CreateHistoryTypes()

                    Case GetType(ASP.controls_webusercontrolintelliselect_ascx)
                        CreateIntelliSelect()

                    Case GetType(ASP.controls_webusercontroladminlatestproperties_ascx)
                        CreateLatestProperties()

                    Case GetType(ASP.controls_webusercontroladminmenueditor_ascx)
                        CreateMenuEditor()

                    Case GetType(ASP.controls_webusercontroladminpassword_ascx)
                        CreatePassword()

                    Case GetType(ASP.controls_webusercontroladminpostcodes_ascx)
                        CreatePostcodes()

                    Case GetType(ASP.controls_webusercontroladminproperty_ascx)
                        CreateProperty()

                    Case GetType(ASP.controls_webusercontroladminpropertysearch_ascx)
                        CreatePropertySearch()

                    Case GetType(ASP.controls_webusercontroladmintestimonials_ascx)
                        CreateTestimonials()

                    Case GetType(ASP.controls_webusercontroladmintranslations_ascx)
                        CreateTranslations()

                    Case GetType(ASP.controls_webusercontroladminupdatesystemvariables_ascx)
                        CreateUpdateSystemVariable()

                    Case GetType(ASP.controls_webusercontrolreportclienttourmissingfeedback_ascx)
                        CreateReportClientTourMissingFeedback()

                End Select

            End If

            ' Clear Reload Flag
            Session("ReloadControl") = Nothing

        End If

    End Sub

    Private Sub CreateBuyer(Optional ByVal CBuyer As ClassBuyer = Nothing)

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminbuyer_ascx = CType(LoadControl("~/Controls/WebUserControlAdminBuyer.ascx"), ASP.controls_webusercontroladminbuyer_ascx)

        ' Define an ID
        ctrl.ID = "AdminBuyer1"

        ' Add Handlers
        AddHandler ctrl.CreateTour, AddressOf TourAddWithBuyerID
        AddHandler ctrl.BuyerSelected, AddressOf AdminBuyerSearch_BuyerSelected

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Initialising if Necessary
        If CBuyer Is Nothing Then

            ' If not a Postback and we have a Buyer
            'If Not IsPostBack And Not Session("AdminBuyerSelected") Is Nothing Then
            If Not Session("AdminBuyerSelected") Is Nothing Then

                ' Load Previous Buyer
                ctrl.InitData(DirectCast(Session("AdminBuyerSelected"), ClassBuyer))

            End If

        Else

            ' Init the Control
            ctrl.InitData(CBuyer)

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateBuyerSearch()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminbuyersearch_ascx = CType(LoadControl("~/Controls/WebUserControlAdminBuyerSearch.ascx"), ASP.controls_webusercontroladminbuyersearch_ascx)

        ' Define an ID
        ctrl.ID = "AdminBuyerSearch1"

        ' Add Handler
        AddHandler ctrl.BuyerSelected, AddressOf AdminBuyerSearch_BuyerSelected

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' If Reloading
        If Not Session("ReloadControl") Is Nothing Then

            ' Reload the Control
            ctrl.Reload()

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateClientTour(Optional ByVal alSelectedProperties As ArrayList = Nothing, Optional ByVal bLoadTour As Boolean = False)

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminclienttour_ascx = CType(LoadControl("~/Controls/WebUserControlAdminClientTour.ascx"), ASP.controls_webusercontroladminclienttour_ascx)

        ' Define an ID
        ctrl.ID = "AdminClientTour1"

        ' Add Handler
        AddHandler ctrl.Feedback, AddressOf SavePreviousCreateClientTourFeedback

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' If we are Creating a new Tour for a Buyer
        If Not Session("AdminCreateTourBuyerID") Is Nothing Then

            ' Init Control
            ctrl.InitBuyer(Convert.ToInt32(Session("AdminCreateTourBuyerID")))

        End If

        ' If we have Properties to Init
        If Not alSelectedProperties Is Nothing Then

            ' Init Control
            ctrl.InitSelectedProperties(alSelectedProperties)

        Else

            ' If Loading the Tour
            If bLoadTour Then

                ' Load the Tour
                ctrl.LoadTour()

            End If

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateClientTourFeedback()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminclienttourfeedback_ascx = CType(LoadControl("~/Controls/WebUserControlAdminClientTourFeedback.ascx"), ASP.controls_webusercontroladminclienttourfeedback_ascx)

        ' Define an ID
        ctrl.ID = "AdminClientTourFeedback1"

        ' Add Handler
        AddHandler ctrl.Finished, AddressOf ReloadClientTour

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateClientTourPropertySelection()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminclienttourpropertyselection_ascx = CType(LoadControl("~/Controls/WebUserControlAdminClientTourPropertySelection.ascx"), ASP.controls_webusercontroladminclienttourpropertyselection_ascx)

        ' Define an ID
        ctrl.ID = "AdminClientTourPropertySelection1"

        ' If we are Creating a new Tour for a Buyer
        If Not Session("AdminCreateTourBuyerID") Is Nothing Then

            ' Init Control
            ctrl.InitBuyer(Convert.ToInt32(Session("AdminCreateTourBuyerID")))

        End If

        ' Add Handler
        AddHandler ctrl.Finished, AddressOf AdminClientTourPropertySelection_Finished

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' If Reloading
        If Not Session("ReloadControl") Is Nothing Then

            ' Reload the Control
            ctrl.Reload()

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateClientTourSearch()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminclienttoursearch_ascx = CType(LoadControl("~/Controls/WebUserControlAdminClientTourSearch.ascx"), ASP.controls_webusercontroladminclienttoursearch_ascx)

        ' Define an ID
        ctrl.ID = "AdminClientTourSearch1"

        ' Add Handler
        AddHandler ctrl.TourSelected, AddressOf AdminClientTourSearch_TourSelected

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' If Reloading
        If Not Session("ReloadControl") Is Nothing Then

            ' Reload the Control
            ctrl.Reload()

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateContact(Optional ByVal CContact As ClassContact = Nothing)

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladmincontact_ascx = CType(LoadControl("~/Controls/WebUserControlAdminContact.ascx"), ASP.controls_webusercontroladmincontact_ascx)

        ' Define an ID
        ctrl.ID = "AdminContact1"

        ' Add Handler
        AddHandler ctrl.PropertySelected, AddressOf AdminContact_PropertySelected
        AddHandler ctrl.NewProperty, AddressOf AdminContact_NewProperty
        AddHandler ctrl.Message, AddressOf Message

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Initialising if Necessary
        If CContact Is Nothing Then

            ' If not a Postback and we have a Contact
            'If Not IsPostBack And Not Session("AdminContactSelected") Is Nothing Then
            If Not Session("AdminContactSelected") Is Nothing Then

                ' Load Previous Contact
                ctrl.InitData(DirectCast(Session("AdminContactSelected"), ClassContact))

            Else

                ' Create New Contact
                CContact = New ClassContact
                CContact.PartnerID = Convert.ToInt32(Session("ContactPartnerID"))
                ctrl.InitData(CContact)

            End If

        Else

            ' Init the Control
            ctrl.InitData(CContact)

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateContactSearch()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladmincontactsearch_ascx = CType(LoadControl("~/Controls/WebUserControlAdminContactSearch.ascx"), ASP.controls_webusercontroladmincontactsearch_ascx)

        ' Define an ID
        ctrl.ID = "AdminContactSearch1"

        ' Add Handler
        AddHandler ctrl.ContactSelected, AddressOf AdminContactSearch_ContactSelected

        ' Init the Control
        ctrl.InitForm()

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' If Reloading
        If Not Session("ReloadControl") Is Nothing Then

            ' Reload the Control
            ctrl.Reload()

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateContactType()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladmincontacttype_ascx = CType(LoadControl("~/Controls/WebUserControlAdminContactType.ascx"), ASP.controls_webusercontroladmincontacttype_ascx)

        ' Define an ID
        ctrl.ID = "AdminContactType1"

        ' Add Handler
        AddHandler ctrl.ReloadNavigation, AddressOf ReloadNavigation
        AddHandler ctrl.Message, AddressOf CustomMessage

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateDatabaseStatistics()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladmindatabasestatistics_ascx = CType(LoadControl("~/Controls/WebUserControlAdminDatabaseStatistics.ascx"), ASP.controls_webusercontroladmindatabasestatistics_ascx)

        ' Define an ID
        ctrl.ID = "AdminDatabaseStatistics1"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateFeaturedProperties()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminfeaturedproperties_ascx = CType(LoadControl("~/Controls/WebUserControlAdminFeaturedProperties.ascx"), ASP.controls_webusercontroladminfeaturedproperties_ascx)

        ' Define an ID
        ctrl.ID = "AdminFeaturedProperties1"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateHistoryTypes()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminhistorytypes_ascx = CType(LoadControl("~/Controls/WebUserControlAdminHistoryTypes.ascx"), ASP.controls_webusercontroladminhistorytypes_ascx)

        ' Define an ID
        ctrl.ID = "AdminHistoryTypes1"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateIntelliSelect()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontrolintelliselect_ascx = CType(LoadControl("~/Controls/WebUserControlIntelliSelect.ascx"), ASP.controls_webusercontrolintelliselect_ascx)

        ' Define an ID
        ctrl.ID = "AdminIntelliSelect"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateLatestProperties()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminlatestproperties_ascx = CType(LoadControl("~/Controls/WebUserControlAdminLatestProperties.ascx"), ASP.controls_webusercontroladminlatestproperties_ascx)

        ' Define an ID
        ctrl.ID = "AdminLatestProperties1"

        ' Add Handler
        AddHandler ctrl.PropertySelected, AddressOf AdminLatestProperties_PropertySelected

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' If Reloading
        If Not Session("ReloadControl") Is Nothing Then

            ' Reload the Control
            ctrl.Reload()

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateLawyerArea()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminlawyerarea_ascx = CType(LoadControl("~/Controls/WebUserControlAdminLawyerArea.ascx"), ASP.controls_webusercontroladminlawyerarea_ascx)

        ' Define an ID
        ctrl.ID = "AdminLawyerArea1"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

    End Sub

    Private Sub CreateMessage()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminmessage_ascx = CType(LoadControl("~/Controls/WebUserControlAdminMessage.ascx"), ASP.controls_webusercontroladminmessage_ascx)

        ' Define an ID
        ctrl.ID = "AdminMessage1"

        ' Add Handler
        AddHandler ctrl.Acknowledged, AddressOf AdminMessage_Acknowledged

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Init Message
        ctrl.InitMessage(Session("MessageTitle"), DirectCast(Session("MessageText"), ArrayList), Convert.ToBoolean(Session("MessageBulletPoints")))

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Store Parent
        If Session("AdminActiveControl").GetType <> GetType(ASP.controls_webusercontroladminmessage_ascx) Then
            Session("AdminMessageParentControl") = Session("AdminActiveControl")
        End If

        ' Set Flag
        Session("AdminDisplayingMessage") = True

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateMenuEditor()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminmenueditor_ascx = CType(LoadControl("~/Controls/WebUserControlAdminMenuEditor.ascx"), ASP.controls_webusercontroladminmenueditor_ascx)

        ' Define an ID
        ctrl.ID = "AdminMenuEditor1"

        ' Add Handler
        AddHandler ctrl.ReloadNavigation, AddressOf ReloadNavigation
        AddHandler ctrl.Message, AddressOf CustomMessage

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreatePassword()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminpassword_ascx = CType(LoadControl("~/Controls/WebUserControlAdminPassword.ascx"), ASP.controls_webusercontroladminpassword_ascx)

        ' Define an ID
        ctrl.ID = "AdminPassword1"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreatePostcodes(Optional ByVal bInitialise As Boolean = False)

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Local Vars
        Dim ctrl As ASP.controls_webusercontroladminpostcodes_ascx = CType(LoadControl("~/Controls/WebUserControlAdminPostcodes.ascx"), ASP.controls_webusercontroladminpostcodes_ascx)

        ' Define an ID
        ctrl.ID = "AdminPostcodes1"

        ' Add Handler
        AddHandler ctrl.Message, AddressOf Message

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' If not a Postback or Initialising
        If Not IsPostBack Or bInitialise Then
            ctrl.InitData()
        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateProperty() 'Optional ByVal bInitVendor As Boolean = False)

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminproperty_ascx = CType(LoadControl("~/Controls/WebUserControlAdminProperty.ascx"), ASP.controls_webusercontroladminproperty_ascx)

        ' Define an ID
        ctrl.ID = "AdminProperty1"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Add Handler
        AddHandler ctrl.ViewVendor, AddressOf AdminContactSearch_ContactSelected

        ' If this is:
        '  - Not a Postback
        '  - We were Displaying a Message
        '  - A Property is being Editted
        '  - If we have a Property
        If (Not IsPostBack Or Convert.ToBoolean(Session("AdminPropertyEdit")) Or Not Session("ReloadControl") Is Nothing) And Not Session("AdminPropertySelected") Is Nothing Then

            ' Init Data with Property
            ctrl.InitData(DirectCast(Session("AdminPropertySelected"), ClassProperty))

        End If

        ' Reset Flag
        Session("AdminPropertyEdit") = False

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreatePropertySearch()

        ' Local Vars
        Dim ctrl As ASP.controls_webusercontroladminpropertysearch_ascx

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create New
        ctrl = CType(LoadControl("~/Controls/WebUserControlAdminPropertySearch.ascx"), ASP.controls_webusercontroladminpropertysearch_ascx)

        ' Define an ID
        ctrl.ID = "AdminPropertySearch1"

        ' Add Handler
        AddHandler ctrl.PropertySelected, AddressOf PropertyEdit

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' If Reloading
        If Not Session("ReloadControl") Is Nothing Then

            ' Reload the Control
            ctrl.Reload()

        End If

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateReportClientTourMissingFeedback()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontrolreportclienttourmissingfeedback_ascx = CType(LoadControl("~/Controls/WebUserControlReportClientTourMissingFeedback.ascx"), ASP.controls_webusercontrolreportclienttourmissingfeedback_ascx)

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Define an ID
        ctrl.ID = "ReportClientTourMissingFeedback1"

        ' Add Handler
        AddHandler ctrl.TourSelected, AddressOf AdminClientTourSearch_TourSelected

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Initialise the Form
        ctrl.InitForm()

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateTestimonials()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladmintestimonials_ascx = CType(LoadControl("~/Controls/WebUserControlAdminTestimonials.ascx"), ASP.controls_webusercontroladmintestimonials_ascx)

        ' Define an ID
        ctrl.ID = "AdminTestimonials1"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateTranslations()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladmintranslations_ascx = CType(LoadControl("~/Controls/WebUserControlAdminTranslations.ascx"), ASP.controls_webusercontroladmintranslations_ascx)

        ' Define an ID
        ctrl.ID = "AdminTranslations1"

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Private Sub CreateUpdateSystemVariable()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminupdatesystemvariables_ascx = CType(LoadControl("~/Controls/WebUserControlAdminUpdateSystemVariables.ascx"), ASP.controls_webusercontroladminupdatesystemvariables_ascx)

        ' Define an ID
        ctrl.ID = "AdminUpdateSystemVariables1"

        ' Initialise the Form
        ctrl.InitForm()

        ' Add to the Form
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelMain.Update()

        ' Update Active Control
        Session("AdminActiveControl") = ctrl

        ' Update Options
        UpdateOptions()

    End Sub

    Public Sub PropertyNew(Optional ByVal nVendorID As Integer = 0)

        ' Init Property Reference
        Session("AdminPropertySelected") = New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))

        ' Assign the Vendor ID
        DirectCast(Session("AdminPropertySelected"), ClassProperty).VendorID = nVendorID

        ' Set Flag
        Session("AdminPropertyEdit") = True

        ' Create Property
        CreateProperty() 'nVendorID > 0)

    End Sub

    Public Sub PropertyEdit()

        ' Check Session Expiration
        If Session("AdminPropertySelected") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Set Flag
            Session("AdminPropertyEdit") = True

            ' Save the Previous Control
            SaveActiveControl()

            ' Create Property
            CreateProperty()

        End If

    End Sub

    Public Sub PropertySearch()

        ' Create Property Search
        CreatePropertySearch()

    End Sub

    Public Function GetBackImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "back-ES.gif"

            Case 3
                ' French
                szRetVal &= "back-FR.gif"

            Case 4
                ' German
                szRetVal &= "back-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "back-NL.gif"

            Case Else
                ' English
                szRetVal &= "back.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Public Function GetForwardImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "forward-ES.png"

            Case 3
                ' French
                szRetVal &= "forward-FR.png"

            Case 4
                ' German
                szRetVal &= "forward-DE.png"

            Case 5
                ' Dutch
                szRetVal &= "forward-NL.png"

            Case Else
                ' English
                szRetVal &= "forward.png"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Private Function GetSignOutImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities
        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "sign-out-ES.gif"

            Case 3
                ' French
                szRetVal &= "sign-out-FR.gif"

            Case 4
                ' German
                szRetVal &= "sign-out-DE.gif"

            Case Else
                ' English
                szRetVal &= "sign-out.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Private Sub HideControls()

        ' Clear Update Panel
        For Each ctrl As Control In UpdatePanelMain.ContentTemplateContainer.Controls

            ' If this is not the Message Control
            If ctrl.ID <> "AdminMessage1" Then

                ' Make Invisible
                ctrl.Visible = False

            End If

        Next

    End Sub

    Private Sub ShowControls()

        ' Clear Update Panel
        For Each ctrl As Control In UpdatePanelMain.ContentTemplateContainer.Controls

            ' If this is not the Message Control
            If ctrl.ID <> "AdminMessage1" Then

                ' Make Invisible
                ctrl.Visible = True

            End If

        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' So Postbacks for Image and Document Uploading work First Time
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        ' If we are not in Agent Mode
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If

        If Not Page.IsPostBack Then

            ' If Session Value for Admin Menu Items is NULL
            If Session("AdminLoggedIn") = Nothing Then

                ' Assign Value
                Session("AdminLoggedIn") = False

            End If

            ' Update Menu Items
            AdminNavigationOptions()

        End If

    End Sub

    Private Sub ReloadNavigation()

        ' Get Control to Reload
        AdminNavigation.Reload()

        ' Update
        UpdatePanelNavigation.Update()

    End Sub

    Private Sub ContactAdd(ByVal nTypeID As Integer)

        ' Create a New Contact
        Dim CContact As New ClassContact(, nTypeID)

        ' New Contact - Init Partner ID
        CContact.PartnerID = Convert.ToInt32(Session("ContactPartnerID"))

        ' Set to not Read Only
        Session("ContactAdminReadOnly") = False

        ' Initialise the Object
        Session("AdminContactSelected") = CContact

        ' Create the Contact
        CreateContact(CContact)

        ' Tidy
        CContact = Nothing

    End Sub

    Private Sub ContactSearch(ByVal nTypeID As Integer)

        ' Set the Contact Search Type
        Session("AdminContactSearchTypeID") = nTypeID

        ' Create Contact Search
        CreateContactSearch()

    End Sub

    Public Sub BrokerAdd()
        ContactAdd(6)
    End Sub

    Public Sub BrokerSearch()
        ContactSearch(6)
    End Sub

    'Public Sub BuyerAdd()

    'End Sub

    'Public Sub BuyerSearch()

    'End Sub

    Public Sub PartnerAdd()
        ContactAdd(3)
    End Sub

    Public Sub PartnerSearch()
        ContactSearch(3)
    End Sub

    Public Sub VendorAdd()
        ContactAdd(5)
    End Sub

    Public Sub VendorSearch()
        ContactSearch(5)
    End Sub

    Private Sub AdminContactSearch_ContactSelected()

        SaveActiveControl()

        ' Create Contact
        CreateContact(DirectCast(Session("AdminContactSelected"), ClassContact))

    End Sub

    Private Sub AdminBuyerSearch_BuyerSelected()

        SaveActiveControl()

        ' Create Buyer
        CreateBuyer(DirectCast(Session("AdminBuyerSelected"), ClassBuyer))

    End Sub

    Public Sub AdminMessage_Acknowledged()

        ' Reload Previous Control
        Session("AdminActiveControl") = Session("AdminMessageParentControl")

        ' Recreate Control
        CreateControl()

        ' Reset the Flag
        Session("AdminDisplayingMessage") = False

    End Sub

    Private Sub UpdateParent()
        UpdatePanelMain.Update()
    End Sub

    Private Sub Message()

        ' Check we have Session Variables
        If Session("MessageTitle") Is Nothing Or Session("MessageText") Is Nothing Or Session("MessageBulletPoints") Is Nothing Or Session("AdminActiveControl") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Display the Message
            CreateMessage()

        End If

    End Sub

    Private Sub AdminNavigationOptions()

        ' If this is a Lawyer
        If Convert.ToInt32(Session("ContactType")) = 2 Then

            ' Lawyer Area - Disable Navigation
            AdminNavigation.Visible = False

        End If

        ' Update the Menu
        UpdatePanelNavigation.Update()

    End Sub

    Private Sub AdminContact_PropertySelected()

        ' Go into Edit Mode
        PropertyEdit()

    End Sub

    Private Sub AdminContact_NewProperty()

        ' New Property for this Vendor
        PropertyNew(DirectCast(Session("AdminContactSelected"), ClassContact).ID)

    End Sub

    Protected Sub ImageButtonSignOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSignOut.Click

        ' Clear Session Variables
        Session.Clear()

        ' Return to Hoempage
        Response.Redirect("/")

    End Sub

    Protected Sub ImageButtonBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonBack.Click

        ' Set Flag
        Session("ReloadControl") = True

        ' Load Previous Control
        LoadPreviousControl()

        ' Recreate
        CreateControl(False, True)

    End Sub

    Protected Sub ImageButtonForward_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonForward.Click

        ' Set Flag
        Session("ReloadControl") = True

        ' Load Next Control
        LoadNextControl()

        ' Recreate
        CreateControl(False, True)

    End Sub

    Protected Sub AdminNavigation_BrokerAdd() Handles AdminNavigation.BrokerAdd

        SaveActiveControl()

        BrokerAdd()

    End Sub

    Protected Sub AdminNavigation_BuyerAdd() Handles AdminNavigation.BuyerAdd

        SaveActiveControl()

        ' Chech Session Expiration
        If Session("ContactPartnerID") Is Nothing Then
            Response.Redirect("~/AgentLogin.aspx")
        Else

            ' Reset Buyer ID
            Dim CBuyer As ClassBuyer = New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))

            ' Create Buyer
            CreateBuyer(CBuyer)

        End If

    End Sub

    Protected Sub AdminNavigation_TourAdd() Handles AdminNavigation.TourAdd

        SaveActiveControl()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Reset Buyer
        Session("AdminCreateTourBuyerID") = Nothing

        ' Create Client Tour Property Selection
        CreateClientTourPropertySelection()

    End Sub

    Private Sub TourAddWithBuyerID()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create Client Tour Property Selection
        CreateClientTourPropertySelection()

    End Sub

    Private Sub AdminClientTourPropertySelection_Finished()

        ' Create Client Tour
        CreateClientTour(DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList))

        ' Tidy
        Session("AdminClientTourPropertiesSelected") = Nothing

    End Sub

    Protected Sub AdminNavigation_Tours() Handles AdminNavigation.Tours

        SaveActiveControl()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create Client Tour Search
        CreateClientTourSearch()

    End Sub

    Protected Sub AdminNavigation_Translations() Handles AdminNavigation.Translations

        SaveActiveControl()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create Translations
        CreateTranslations()

    End Sub

    Private Sub AdminClientTourSearch_TourSelected()

        SaveActiveControl()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create Client Tour
        CreateClientTour(, True)

    End Sub

    Protected Sub AdminNavigation_Agents() Handles AdminNavigation.Agents

        SaveActiveControl()

        ContactSearch(1)

    End Sub

    Protected Sub AdminNavigation_AgentAdd() Handles AdminNavigation.AgentAdd

        SaveActiveControl()

        ContactAdd(1)

    End Sub

    Protected Sub AdminNavigation_Buyers() Handles AdminNavigation.Buyers

        SaveActiveControl()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create Buyer Search
        CreateBuyerSearch()

    End Sub

    'Protected Sub AdminNavigation_Export() Handles AdminNavigation.Export

    '    SaveActiveControl()

    '    ' Local Vars
    '    Dim CUtilities As New ClassUtilities

    '    ' Export Data
    '    CUtilities.Export()

    '    ' Tidy
    '    CUtilities = Nothing

    '    ' A File
    '    Response.AppendHeader("Content-Disposition", "attachment; filename=Export.zip")
    '    Response.TransmitFile(AppDomain.CurrentDomain.GetData("DataDirectory") & "\Export\Export.zip")
    '    Response.End()

    'End Sub

    Protected Sub AdminNavigation_FeaturedProperties() Handles AdminNavigation.FeaturedProperties

        SaveActiveControl()

        ' Create Featured Properties
        CreateFeaturedProperties()

    End Sub

    Protected Sub AdminNavigation_LatestProperties() Handles AdminNavigation.LatestProperties

        SaveActiveControl()

        ' Create Latest Properties
        CreateLatestProperties()

    End Sub

    Private Sub AdminLatestProperties_PropertySelected()

        SaveActiveControl()

        ' Go into Edit Mode
        PropertyEdit()

    End Sub

    Protected Sub AdminNavigation_Postcodes() Handles AdminNavigation.Postcodes

        SaveActiveControl()

        ' Create (and Initialise) Postcodes
        CreatePostcodes(True)

    End Sub

    'Private Sub UpdateSystemVariable()

    '    ' Create Update System Variables
    '    CreateUpdateSystemVariable()

    'End Sub

    Protected Sub AdminNavigation_Views() Handles AdminNavigation.Views

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.View

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_PropertyType() Handles AdminNavigation.PropertyType

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.Type

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_PropertyStatus() Handles AdminNavigation.PropertyStatus

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.Status

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_PropertyFeatures() Handles AdminNavigation.PropertyFeatures

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.Feature

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_PropertyLocations() Handles AdminNavigation.PropertyLocations

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.Location

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_BuyerSource() Handles AdminNavigation.BuyerSource

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.BuyerSource

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_BuyerStatus() Handles AdminNavigation.BuyerStatus

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.BuyerStatus

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_Users() Handles AdminNavigation.Users

        SaveActiveControl()

        ContactSearch(4)

    End Sub

    Protected Sub AdminNavigation_UserAdd() Handles AdminNavigation.UserAdd

        SaveActiveControl()

        ContactAdd(4)

    End Sub

    Protected Sub AdminNavigation_Testimonials() Handles AdminNavigation.Testimonials

        SaveActiveControl()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create Testimonials
        CreateTestimonials()

    End Sub

    Protected Sub AdminNavigation_Password() Handles AdminNavigation.Password

        SaveActiveControl()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create Password
        CreatePassword()

    End Sub

    Protected Sub AdminNavigation_DatabaseStatistics() Handles AdminNavigation.DatabaseStatistics

        SaveActiveControl()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Create Database Statistics
        CreateDatabaseStatistics()

    End Sub

    Private Sub ClearControls()

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

    End Sub

    Private Sub ReloadClientTour()

        CreateClientTour(, True)

    End Sub

    Protected Sub AdminNavigation_Brokers() Handles AdminNavigation.Brokers

        SaveActiveControl()

        BrokerSearch()

    End Sub

    Protected Sub AdminNavigation_PartnerAdd() Handles AdminNavigation.PartnerAdd

        SaveActiveControl()

        PartnerAdd()

    End Sub

    Protected Sub AdminNavigation_Partners() Handles AdminNavigation.Partners

        SaveActiveControl()

        PartnerSearch()

    End Sub

    Protected Sub AdminNavigation_PropertyAdd() Handles AdminNavigation.PropertyAdd

        SaveActiveControl()

        PropertyNew()

    End Sub

    Protected Sub AdminNavigation_Properties() Handles AdminNavigation.Properties

        SaveActiveControl()

        PropertySearch()

    End Sub

    Protected Sub AdminNavigation_VendorAdd() Handles AdminNavigation.VendorAdd

        SaveActiveControl()

        VendorAdd()

    End Sub

    Protected Sub AdminNavigation_Vendors() Handles AdminNavigation.Vendors

        SaveActiveControl()

        VendorSearch()

    End Sub

    Private Sub SavePreviousCreateClientTourFeedback()

        SaveActiveControl()

        CreateClientTourFeedback()

    End Sub

    Private Sub UpdateOptions()

        ' If we don't yet have a Control List
        If Session("AdminControlListPointer") Is Nothing Then

            ' Set Back / Forward Vis
            ImageButtonBack.Visible = False
            ImageButtonForward.Visible = False

        Else

            ' Set Back / Forward Vis
            ImageButtonBack.Visible = DirectCast(Session("AdminControlListPointer"), Int32) > 0
            ImageButtonForward.Visible = DirectCast(Session("AdminControlListPointer"), Int32) < DirectCast(Session("AdminControlList"), ArrayList).Count - 1

        End If

        ' Update Options
        UpdatePanelOptions.Update()

    End Sub

    Protected Sub AdminNavigation_ReportClientTourMissingFeedback() Handles AdminNavigation.ReportClientTourMissingFeedback

        SaveActiveControl()

        CreateReportClientTourMissingFeedback()

    End Sub

    Protected Sub AdminNavigation_Lawyers() Handles AdminNavigation.Lawyers

        SaveActiveControl()

        ContactSearch(2)

    End Sub

    Protected Sub AdminNavigation_LawyerAdd() Handles AdminNavigation.LawyerAdd

        SaveActiveControl()

        ContactAdd(2)

    End Sub

    Protected Sub AdminNavigation_ContactType() Handles AdminNavigation.ContactType

        SaveActiveControl()

        CreateContactType()

    End Sub

    Protected Sub AdminNavigation_HistoryTypes() Handles AdminNavigation.HistoryTypes

        SaveActiveControl()

        CreateHistoryTypes()

    End Sub

    Protected Sub AdminNavigation_CustomContact(ByVal nContactTypeID As Integer) Handles AdminNavigation.CustomContact

        SaveActiveControl()

        ContactSearch(nContactTypeID)

    End Sub

    Protected Sub AdminNavigation_CustomContactAdd(ByVal nContactTypeID As Integer) Handles AdminNavigation.CustomContactAdd

        SaveActiveControl()

        ContactAdd(nContactTypeID)

    End Sub

    Protected Sub AdminNavigation_MenuEditor() Handles AdminNavigation.MenuEditor

        SaveActiveControl()

        CreateMenuEditor()

    End Sub

    Private Sub CustomMessage(ByVal szMessage As String)

        ' Clear Controls
        UpdatePanelMain.ContentTemplateContainer.Controls.Clear()

        ' Add Label
        Dim lbl As New Label

        ' Set Message
        lbl.Text = szMessage.Trim

        ' Make Bold
        lbl.Font.Bold = True

        ' Add this to the Panel
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(New LiteralControl("<br />"))
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(lbl)
        UpdatePanelMain.ContentTemplateContainer.Controls.Add(New LiteralControl("<br />"))

    End Sub

    Protected Sub AdminNavigation_Languages() Handles AdminNavigation.Languages

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.Language

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_PaymentTypes() Handles AdminNavigation.PaymentTypes

        SaveActiveControl()

        ' Init Parameter to Update
        Session("AdminSystemTable") = ClassDataAccess.E_SystemVariable.PaymentType

        ' Update System Variable
        CreateUpdateSystemVariable()

    End Sub

    Protected Sub AdminNavigation_Testing() Handles AdminNavigation.Testing

        SaveActiveControl()

        CreateIntelliSelect()

    End Sub

End Class
