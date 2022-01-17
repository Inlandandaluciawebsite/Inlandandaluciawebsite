Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Partial Class PropertyPostcode
    Inherits System.Web.UI.Page

    Public Event Message(ByVal szTitle As String, ByVal alMessage As ArrayList, ByVal bBulletPoints As Boolean)
    Dim dt As New DataTable()
    Private Enum E_LEVEL As Integer
        TopLevel = 0
        Country = 1
        Region = 2
        Area = 3
        SubArea = 4
    End Enum

    Private WithEvents m_ctrlPostcodeReassignment As WebUserControlAdminPostcodeReassignment
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        If Not IsPostBack Then
            If Not Session("AdminPostcodeRegionID") Is Nothing Then
                InitData()
                InitCountry()
                InitRegion()
            Else
                InitData()
            End If
        End If
    End Sub
    Public Property PostcodeReassignment As WebUserControlAdminPostcodeReassignment
        Get
            Return m_ctrlPostcodeReassignment
        End Get
        Set(ByVal value As WebUserControlAdminPostcodeReassignment)
            m_ctrlPostcodeReassignment = value
        End Set
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Check we have the Session Variables Required
        If Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Populate Default Partner Combos
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            CUtilities.PopulateDropDownList(DropDownListAddDefaultPartner, CDataAccess.Partners, True)
            CUtilities.PopulateDropDownList(DropDownListEditDefaultPartner, CDataAccess.Partners, True)
            CUtilities = Nothing
            CDataAccess = Nothing

            ' Init Combos to Current Partner
            DropDownListAddDefaultPartner.SelectedValue = Convert.ToInt32(Session("ContactPartnerID"))
            DropDownListEditDefaultPartner.SelectedValue = Convert.ToInt32(Session("ContactPartnerID"))

            ' Declare Postcode Reassignment
            PostcodeReassignment = New ASP.controlsnew_webusercontroladminpostcodereassignment_ascx
            PostcodeReassignment.ID = "AdminPropertyPostcodeReassignment1"
            upAddAdmin.ContentTemplateContainer.Controls.Add(PostcodeReassignment)
            PostcodeReassignment.Visible = False

        End If

    End Sub

    Public Sub InitData()

        ' Set Level to Top Level
        Session("AdminPostcodeLevel") = E_LEVEL.TopLevel

        ' Load the Countries
        Dim CDataAccess As New ClassDataAccess
        GridViewResults.DataSource = CDataAccess.Countries
        GridViewResults.DataBind()
        CDataAccess = Nothing

        ' If we have Results
        If GridViewResults.Rows.Count > 0 Then

            ' If we have a Header
            If Not GridViewResults.HeaderRow Is Nothing Then

                ' Hide the ID Column
                GridViewResults.HeaderRow.Cells(1).Visible = False

                ' For each Row
                For Each gvr As GridViewRow In GridViewResults.Rows

                    ' Hide the ID
                    gvr.Cells(1).Visible = False

                Next

            End If

            ' Make the Grid View Visible
            GridViewResults.Visible = True

        End If

        ' Clear Fields
        TextBoxAddCountryEN.Text = String.Empty
        TextBoxAddCountryES.Text = String.Empty
        TextBoxAddCountryFR.Text = String.Empty
        TextBoxAddCountryDE.Text = String.Empty
        TextBoxAddCountryNL.Text = String.Empty
        TextBoxAddCountryCode.Text = String.Empty

        ' Hide Deletion Confirmation Table
        TableConfirmDeletion.Visible = False

        ' Hide Edit Options
        ShowEditOptions(False)

        ' Show Add Options
        ShowAddOptions()

        ' Hide Breadcrumb
        ShowBreadcrumb(False, False, False, False)

        ' Set the Type
        LabelType.Text = "Country"

    End Sub

    Private Sub InitSubArea()

        ' Check we have the Session Variables Required
        If Session("AdminPostcodeSubAreaID") Is Nothing _
            Or Session("AdminPostcodeSubAreaName") Is Nothing _
            Or Session("AdminPostcodePostcode") Is Nothing _
            Or Session("AdminPostcodeDefaultPartnerID") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Set to SubArea Level
            Session("AdminPostcodeLevel") = E_LEVEL.SubArea

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Set Type
            LabelType.Text = String.Empty

            ' Set Parent
            LinkButtonParentSubArea.Text = Session("AdminPostcodeSubAreaName")

            ' Show Breadcrumb
            ShowBreadcrumb(True, True, True, True)

            ' Set Current Name
            TextBoxEditName.Text = Session("AdminPostcodeSubAreaName")

            ' Set Current Postcode
            TextBoxEditPostcode.Text = Session("AdminPostcodePostcode")

            ' Set Default Partner
            DropDownListEditDefaultPartner.SelectedValue = Session("AdminPostcodeDefaultPartnerID")

            ' Display Edit Options
            ShowEditOptions()

            ' Hide Add Option
            ShowAddOptions(False)
            'ShowAddOptions()
            ' Hide Results
            GridViewResults.Visible = False
            'GridViewResults.Visible = True

            ' Tidy
            CDataAccess = Nothing

        End If

    End Sub

    Private Sub InitArea()

        ' Check we have the Session Variables Required
        If Session("AdminPostcodeAreaID") Is Nothing _
            Or Session("AdminPostcodeAreaName") Is Nothing _
            Or Session("AdminPostcodePostcode") Is Nothing _
            Or Session("AdminPostcodeDefaultPartnerID") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else


            ' Set to SubArea Level
            Session("AdminPostcodeLevel") = E_LEVEL.Area

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Set Type
            LabelType.Text = "SubAreas in "

            ' Set Parent
            LinkButtonParentArea.Text = Session("AdminPostcodeAreaName")

            ' Show Breadcrumb
            ShowBreadcrumb(True, True, True, False)

            ' Set Current Name
            TextBoxEditName.Text = Session("AdminPostcodeAreaName")

            ' Set Current Postcode
            TextBoxEditPostcode.Text = Session("AdminPostcodePostcode")

            ' Set Default Partner
            DropDownListEditDefaultPartner.SelectedValue = Session("AdminPostcodeDefaultPartnerID")

            ' Display Edit Options
            ShowEditOptions()

            ' Display Add Option
            ShowAddOptions()

            ' Load SubAreas
            GridViewResults.DataSource = CDataAccess.SubAreas(Convert.ToInt32(Session("AdminPostcodeAreaID")), True, "SubArea", True)
            GridViewResults.DataBind()

            ' Hide ID
            HideIDColumn(True)

            ' Set Visibility
            GridViewResults.Visible = GridViewResults.Rows.Count > 0

            ' Tidy
            CDataAccess = Nothing

            'To bind sub area information by area id (if Exists in database)
            'Dim sql As SqlParameter() = New SqlParameter(1) {}
            'sql(1) = New SqlParameter("@Area_Id", Session("AdminPostcodeAreaID"))
            'dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblSubArea_Select_By_AreaId", sql).Tables(0)
            DropDownListAddDefaultPartner.SelectedValue = Session("AdminPostcodeDefaultPartnerID")
            DropDownListAddDefaultPartner.Enabled = False
            'If dt.Rows.Count > 0 Then
            '    TextBoxAddName.Text = dt.Rows(0)("SubArea_Name").ToString()
            '    TextBoxAddPostcode.Text = dt.Rows(0)("PostCode").ToString()
            '    DropDownListAddDefaultPartner.SelectedValue = dt.Rows(0)("Default_Partner_Id").ToString()
            '    hdnSubAreaId.Value = dt.Rows(0)("SubArea_Id").ToString()
            '    hdnPostCodeId.Value = dt.Rows(0)("PostCode_Id").ToString()
            'End If
        End If
    End Sub

    Private Sub InitRegion()

        ' Check we have the Session Variables Required
        If Session("AdminPostcodeRegionID") Is Nothing Or Session("AdminPostcodeRegionName") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Set to Area Level
            Session("AdminPostcodeLevel") = E_LEVEL.Region

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Set Type
            LabelType.Text = "Areas in "

            ' Set Parent
            LinkButtonParentRegion.Text = Session("AdminPostcodeRegionName")

            ' Show Breadcrumb
            ShowBreadcrumb(True, True, False, False)

            ' Set Current Name
            TextBoxEditName.Text = Session("AdminPostcodeRegionName")

            ' Display Edit Options
            ShowEditOptions()

            ' Display Add Option
            ShowAddOptions()

            ' Load Areas
            GridViewResults.DataSource = CDataAccess.Areas(Convert.ToInt32(Session("AdminPostcodeRegionID")), True, "Area", True)
            GridViewResults.DataBind()

            ' Hide ID
            HideIDColumn(True)

            ' Set Visibility
            GridViewResults.Visible = GridViewResults.Rows.Count > 0

            ' Tidy
            CDataAccess = Nothing

        End If

    End Sub

    Private Sub InitCountry()

        ' Check we have the Session Variables Required
        If Session("AdminPostcodeCountryID") Is Nothing _
            Or Session("AdminPostcodeCountryNameEN") Is Nothing _
            Or Session("AdminPostcodeCountryNameES") Is Nothing _
            Or Session("AdminPostcodeCountryNameFR") Is Nothing _
            Or Session("AdminPostcodeCountryNameDE") Is Nothing _
            Or Session("AdminPostcodeCountryNameNL") Is Nothing _
            Or Session("AdminPostcodeCountryCode") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Set to Area Level
            Session("AdminPostcodeLevel") = E_LEVEL.Country

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Set Type
            LabelType.Text = "Regions in "

            ' Set Parent
            LinkButtonParentCountry.Text = Session("AdminPostcodeCountryNameEN")

            ' Show Breadcrumb
            ShowBreadcrumb(True, False, False, False)

            ' Set Current Name
            TextBoxEditCountryEN.Text = Session("AdminPostcodeCountryNameEN")
            TextBoxEditCountryES.Text = Session("AdminPostcodeCountryNameES")
            TextBoxEditCountryFR.Text = Session("AdminPostcodeCountryNameFR")
            TextBoxEditCountryDE.Text = Session("AdminPostcodeCountryNameDE")
            TextBoxEditCountryNL.Text = Session("AdminPostcodeCountryNameNL")
            TextBoxEditCountryCode.Text = Session("AdminPostcodeCountryCode")

            ' Display Edit Options
            ShowEditOptions()

            ' Display Add Option
            ShowAddOptions()

            ' Load Regions
            GridViewResults.DataSource = CDataAccess.Regions(Convert.ToInt32(Session("AdminPostcodeCountryID")), "Region")
            GridViewResults.DataBind()

            ' Hide ID
            HideIDColumn()

            ' Set Visibility
            GridViewResults.Visible = GridViewResults.Rows.Count > 0

            ' Tidy
            CDataAccess = Nothing

        End If

    End Sub

    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged

        ' If Session still Active
        If Session("AdminPostcodeLevel") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Depending on what Level we are at
            Select Case Convert.ToInt32(Session("AdminPostcodeLevel"))

                Case E_LEVEL.TopLevel
                    ' Country Selected

                    ' Assign to Session Variables
                    Session("AdminPostcodeCountryID") = Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim)
                    Session("AdminPostcodeCountryNameEN") = HttpUtility.HtmlDecode(GridViewResults.SelectedRow.Cells(2).Text).Trim
                    Session("AdminPostcodeCountryNameES") = HttpUtility.HtmlDecode(GridViewResults.SelectedRow.Cells(3).Text).Trim
                    Session("AdminPostcodeCountryNameFR") = HttpUtility.HtmlDecode(GridViewResults.SelectedRow.Cells(4).Text).Trim
                    Session("AdminPostcodeCountryNameDE") = HttpUtility.HtmlDecode(GridViewResults.SelectedRow.Cells(5).Text).Trim
                    Session("AdminPostcodeCountryNameNL") = HttpUtility.HtmlDecode(GridViewResults.SelectedRow.Cells(6).Text).Trim
                    Session("AdminPostcodeCountryCode") = HttpUtility.HtmlDecode(GridViewResults.SelectedRow.Cells(7).Text).Trim

                    ' Init Country
                    InitCountry()

                Case E_LEVEL.Country
                    ' Region Selected

                    ' Assign to Session Variables
                    Session("AdminPostcodeRegionID") = Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim)
                    Session("AdminPostcodeRegionName") = GridViewResults.SelectedRow.Cells(2).Text.Trim

                    ' Init Region
                    InitRegion()

                Case E_LEVEL.Region
                    ' Area Selected

                    ' Assign to Session Variables
                    Session("AdminPostcodeAreaID") = Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim)
                    Session("AdminPostcodeAreaName") = GridViewResults.SelectedRow.Cells(2).Text.Trim
                    Session("AdminPostcodePostcode") = GridViewResults.SelectedRow.Cells(3).Text.Trim
                    Session("AdminPostcodeDefaultPartnerID") = GridViewResults.SelectedRow.Cells(4).Text.Trim

                    ' Init Area
                    InitArea()

                Case E_LEVEL.Area
                    ' SubArea Selected

                    ' Assign to Session Variables
                    Session("AdminPostcodeSubAreaID") = Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim)
                    Session("AdminPostcodeSubAreaName") = GridViewResults.SelectedRow.Cells(2).Text.Trim
                    Session("AdminPostcodePostcode") = GridViewResults.SelectedRow.Cells(3).Text.Trim
                    Session("AdminPostcodeDefaultPartnerID") = GridViewResults.SelectedRow.Cells(4).Text.Trim

                    ' Init SubArea
                    InitSubArea()

                Case Else

                    ' Init Form
                    InitData()

            End Select

        End If

    End Sub

    Private Sub ShowEditOptions(Optional ByVal bShow As Boolean = True)

        TableRowEditName.Visible = bShow And Not (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.Country)
        TableRowEditCountryHeader.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.Country)
        TableRowEditCountryEN.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.Country)
        TableRowEditCountryES.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.Country)
        TableRowEditCountryFR.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.Country)
        TableRowEditCountryDE.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.Country)
        TableRowEditCountryNL.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.Country)
        TableRowEditCountryCode.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.Country)
        TableRowEditPostcode.Visible = bShow And ((Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.TopLevel) And (Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.Country) And (Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.Region))
        TableRowEditDefaultPartner.Visible = bShow And ((Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.TopLevel) And (Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.Country) And (Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.Region))
        TableRowEditOptions.Visible = bShow

    End Sub

    Private Sub ShowAddOptions(Optional ByVal bShow As Boolean = True)
        TableRowAddName.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.TopLevel)
        TableRowAddCountryHeader.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.TopLevel)
        TableRowAddCountryEN.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.TopLevel)
        TableRowAddCountryES.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.TopLevel)
        TableRowAddCountryFR.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.TopLevel)
        TableRowAddCountryDE.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.TopLevel)
        TableRowAddCountryNL.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.TopLevel)
        TableRowAddCountryCode.Visible = bShow And (Convert.ToInt32(Session("AdminPostcodeLevel")) = E_LEVEL.TopLevel)
        TableRowAddPostcode.Visible = bShow And ((Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.TopLevel) And (Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.Country))
        TableRowAddDefaultPartner.Visible = bShow And ((Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.TopLevel) And (Convert.ToInt32(Session("AdminPostcodeLevel")) <> E_LEVEL.Country))
        TableRowAddOptions.Visible = bShow
    End Sub

    Private Sub ShowBreadcrumb(ByVal bShowCountry As Boolean, ByVal bShowRegion As Boolean, ByVal bShowArea As Boolean, ByVal bShowSubArea As Boolean)

        LinkButtonParentCountry.Visible = bShowCountry
        LabelSeparator1.Visible = bShowRegion
        LinkButtonParentRegion.Visible = bShowRegion
        LabelSeparator2.Visible = bShowArea
        LinkButtonParentArea.Visible = bShowArea
        LabelSeparator3.Visible = bShowSubArea
        LinkButtonParentSubArea.Visible = bShowSubArea

    End Sub

    Private Sub HideIDColumn(Optional ByVal bContainsDefaultPartnerID As Boolean = False)
        ' If we have Results
        If GridViewResults.Rows.Count > 0 Then
            ' If we have a Header
            If Not GridViewResults.HeaderRow Is Nothing Then
                ' Hide the ID Column(s)
                GridViewResults.HeaderRow.Cells(1).Visible = False
                ' If we are Hiding the Default Partner ID too
                If bContainsDefaultPartnerID Then
                    GridViewResults.HeaderRow.Cells(4).Visible = False
                End If
                ' For each Row
                For Each gvr As GridViewRow In GridViewResults.Rows
                    ' Hide the ID(s)
                    gvr.Cells(1).Visible = False
                    ' If we are Hiding the Default Partner ID too
                    If bContainsDefaultPartnerID Then
                        gvr.Cells(4).Visible = False
                    End If
                Next
            End If
        End If
    End Sub

    Protected Sub LinkButtonParentRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonParentRegion.Click
        ' Initialise the Country
        'InitCountry()
        ' Initialise Region
        InitRegion()
    End Sub

    Protected Sub LinkButtonParentArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonParentArea.Click
        ' Initialise Area
        InitArea()
    End Sub

    Protected Sub LinkButtonParentSubArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonParentSubArea.Click
        ' Initialise Sub Area
        InitSubArea()
    End Sub



    Public Function GetParentEntity() As String
        ' Depending on Level
        Select Case Convert.ToInt32(Session("AdminPostcodeLevel"))

            Case E_LEVEL.Country
                Return "Country"

            Case E_LEVEL.Region
                Return "Region"

            Case E_LEVEL.Area
                Return "Area"

            Case E_LEVEL.SubArea
                Return "SubArea"

            Case Else
                Return "TopLevel"
        End Select

    End Function

    Public Function GetThisEntity() As String

        ' Depending on Level
        Select Case Convert.ToInt32(Session("AdminPostcodeLevel"))

            Case E_LEVEL.TopLevel
                Return "Country"

            Case E_LEVEL.Country
                Return "Region"

            Case E_LEVEL.Region
                Return "Area"

            Case E_LEVEL.Area
                Return "SubArea"

            Case Else
                Return ""

        End Select

    End Function


    Public Sub ClearAddCountryTextboxes()

        TextBoxAddCountryEN.Text = String.Empty
        TextBoxAddCountryES.Text = String.Empty
        TextBoxAddCountryFR.Text = String.Empty
        TextBoxAddCountryDE.Text = String.Empty
        TextBoxAddCountryNL.Text = String.Empty
        TextBoxAddCountryCode.Text = String.Empty

    End Sub

    Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        ' If Session still Active
        If Session("AdminPostcodeCountryID") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Hide Main Table
            TablePostcodes.Visible = False

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Depending on the Entity
            Select Case GetParentEntity()

                Case "Country"
                    GridViewDeletionResults.DataSource = CDataAccess.RegionsAreasSubAreas(Convert.ToInt32(Session("AdminPostcodeCountryID")))

                Case "Region"
                    GridViewDeletionResults.DataSource = CDataAccess.RegionsAreasSubAreas(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")))

                Case "Area"
                    GridViewDeletionResults.DataSource = CDataAccess.RegionsAreasSubAreas(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")), Convert.ToInt32(Session("AdminPostcodeAreaID")))

            End Select

            ' Bind Results
            GridViewDeletionResults.DataBind()

            ' Hide the ID Column
            If Not GridViewDeletionResults.HeaderRow Is Nothing Then
                GridViewDeletionResults.HeaderRow.Cells(0).Visible = False
                For Each gvr As GridViewRow In GridViewDeletionResults.Rows
                    gvr.Cells(0).Visible = False
                Next
            End If

            ' Tidy
            CDataAccess = Nothing

            ' Define Prompt
            LabelDeletionPrompt.Text = "You are about to delete the " & GetParentEntity() & " "

            ' Depending on the Entity
            Select Case GetParentEntity()

                Case "Country"
                    LabelDeletionPrompt.Text &= Session("AdminPostcodeCountryNameEN")

                Case "Region"
                    LabelDeletionPrompt.Text &= Session("AdminPostcodeRegionName")

                Case "Area"
                    LabelDeletionPrompt.Text &= Session("AdminPostcodeAreaName")

                Case Else
                    LabelDeletionPrompt.Text &= Session("AdminPostcodeSubAreaName")

            End Select

            ' If there are Child Records and this is not a Sub Area
            If GridViewDeletionResults.Rows.Count > 0 And GetParentEntity() <> "SubArea" Then

                ' Continue to Form Prompt
                LabelDeletionPrompt.Text &= " which contains the following " & GridViewDeletionResults.Rows.Count.ToString.Trim & " child records:"

                ' Display the Table
                TableRowDeletionResults.Visible = True

            Else

                ' No Child Record
                TableRowDeletionResults.Visible = False

            End If

            ' Display this Table
            TableConfirmDeletion.Visible = True

        End If

    End Sub

    Protected Sub ButtonCancelDeletion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancelDeletion.Click

        ' Hide the Deletion Confirmation Form and Display the Main
        TableConfirmDeletion.Visible = False
        TablePostcodes.Visible = True

    End Sub

    Protected Sub ButtonConfirmDeletion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonConfirmDeletion.Click

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim dtPostcodeIDsWithProperties As DataTable
        Dim dtPostcodeIDs As DataTable
        Dim nLevel As Integer

        ' Depending on the Entity - Get a List of Postcode IDs that Require Replacing
        Select Case GetParentEntity()

            Case "Country"
                dtPostcodeIDsWithProperties = CDataAccess.PostcodeIDsWithPropertiesIn(Convert.ToInt32(Session("AdminPostcodeCountryID")))
                dtPostcodeIDs = CDataAccess.PostcodeIDsIn(Convert.ToInt32(Session("AdminPostcodeCountryID")))
                nLevel = 1

            Case "Region"
                dtPostcodeIDsWithProperties = CDataAccess.PostcodeIDsWithPropertiesIn(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")))
                dtPostcodeIDs = CDataAccess.PostcodeIDsIn(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")))
                nLevel = 2

            Case "Area"
                dtPostcodeIDsWithProperties = CDataAccess.PostcodeIDsWithPropertiesIn(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")), Convert.ToInt32(Session("AdminPostcodeAreaID")))
                dtPostcodeIDs = CDataAccess.PostcodeIDsIn(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")), Convert.ToInt32(Session("AdminPostcodeAreaID")))
                nLevel = 3

            Case Else
                dtPostcodeIDsWithProperties = CDataAccess.PostcodeIDsWithPropertiesIn(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")), Convert.ToInt32(Session("AdminPostcodeAreaID")), Convert.ToInt32(Session("AdminPostcodeSubAreaID")))
                dtPostcodeIDs = CDataAccess.PostcodeIDsIn(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")), Convert.ToInt32(Session("AdminPostcodeAreaID")), Convert.ToInt32(Session("AdminPostcodeSubAreaID")))
                nLevel = 4

        End Select

        ' If we have Reassignments to make
        If dtPostcodeIDsWithProperties.Rows.Count > 0 Then

            ' Hide the Tables
            TablePostcodes.Visible = False
            TableConfirmDeletion.Visible = False

            ' Assign to Session Variables
            Session("AdminPostcodeReassignments") = dtPostcodeIDsWithProperties
            Session("AdminPostcodeReassignmentLevel") = nLevel

            ' Initialise Exclusion Array
            Dim alPostcodeIDExclusions As New ArrayList

            ' For each Postcode ID being Deleted
            For Each dr As DataRow In dtPostcodeIDs.Rows

                ' Add this ID to the List of those being Deleted
                alPostcodeIDExclusions.Add(Convert.ToInt32(dr.Item("postcode_id").ToString.Trim))

            Next
            ' Init Postcode Reassignment Form
            PostcodeReassignment.InitForm(alPostcodeIDExclusions)
            PostcodeReassignment.LoadReassignment()
            PostcodeReassignment.Visible = True

        Else

            ' No Reassignments Necessary, Remove Entity
            DeleteEntity()
            'Show section accordingly, done by sourabh

            If nLevel = 2 Then
                InitCountry()
            End If
            If nLevel = 3 Then
                InitRegion()
            End If
            If nLevel = 4 Then
                InitArea()
            End If
        End If

        ' Tidy
        dtPostcodeIDsWithProperties.Dispose()



    End Sub

    Protected Sub m_ctrlPostcodeReassignment_Completed() Handles m_ctrlPostcodeReassignment.Completed

        ' Properties Reassigned, Delete Entity
        DeleteEntity()

    End Sub

    Private Sub DeleteEntity()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Depending on the Entity
        Select Case GetParentEntity()

            Case "Country"
                CDataAccess.DeleteCountry(Convert.ToInt32(Session("AdminPostcodeCountryID")))

            Case "Region"
                CDataAccess.DeleteRegion(Convert.ToInt32(Session("AdminPostcodeRegionID")))

            Case "Area"
                CDataAccess.DeleteArea(Convert.ToInt32(Session("AdminPostcodeAreaID")))

            Case Else
                CDataAccess.DeleteSubArea(Convert.ToInt32(Session("AdminPostcodeSubAreaID")))

        End Select

        ' Tidy
        CDataAccess = Nothing

        ' Reload the Form
        InitData()

        ' Hide the Postcode Reassignment Form
        PostcodeReassignment.Visible = False

        ' Display Postcodes
        TablePostcodes.Visible = True

    End Sub

    Protected Sub LinkButtonParentCountry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonParentCountry.Click

        ' Initialise the Form
        'InitData()
        InitCountry()

    End Sub

    Protected Sub ButtonSaveAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSaveAdd.Click

        ' Local Vars
        Dim alMessage As New ArrayList

        ' Check we have a Name Specified
        If TableRowAddName.Visible And TextBoxAddName.Text.Trim = String.Empty Then

            ' Add Message
            alMessage.Add("You must provide a name before saving this " & GetThisEntity())

        End If

        ' Check we have the Country in English
        If TableRowAddCountryEN.Visible And TextBoxAddCountryEN.Text.Trim = String.Empty Then

            ' Add Message
            alMessage.Add("You must provide the name of the country in English")

        End If

        ' Check we have the Country in Spanish
        If TableRowAddCountryES.Visible And TextBoxAddCountryES.Text.Trim = String.Empty Then

            ' Add Message
            alMessage.Add("You must provide the name of the country in Spanish")

        End If

        ' Check we have the Country in French
        If TableRowAddCountryFR.Visible And TextBoxAddCountryFR.Text.Trim = String.Empty Then

            ' Add Message
            alMessage.Add("You must provide the name of the country in French")

        End If

        ' Check we have the Country in German
        If TableRowAddCountryDE.Visible And TextBoxAddCountryDE.Text.Trim = String.Empty Then

            ' Add Message
            alMessage.Add("You must provide the name of the country in German")

        End If

        ' Check we have the Country in Dutch
        If TableRowAddCountryNL.Visible And TextBoxAddCountryNL.Text.Trim = String.Empty Then

            ' Add Message
            alMessage.Add("You must provide the name of the country in Dutch")

        End If

        ' Check we have the Country Code
        If TableRowAddCountryCode.Visible And TextBoxAddCountryCode.Text.Trim = String.Empty Then
            ' Add Message
            alMessage.Add("You must provide a country code")
        End If

        ' If a Postcode is required and not been Supplied
        If TableRowAddPostcode.Visible And TextBoxAddPostcode.Text.Trim = String.Empty Then
            ' Add Message
            alMessage.Add("You must provide a postcode before saving this " & GetThisEntity())
        End If

        ' If we have had no Errors
        If alMessage.Count = 0 Then

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Depending on Level
            Select Case GetThisEntity()

                Case "Country"
                    ' Add Country
                    CDataAccess.AddCountry(
                        TextBoxAddCountryEN.Text.Trim,
                        TextBoxAddCountryES.Text.Trim,
                        TextBoxAddCountryFR.Text.Trim,
                        TextBoxAddCountryDE.Text.Trim,
                        TextBoxAddCountryNL.Text.Trim,
                        TextBoxAddCountryCode.Text.Trim.ToUpper
                        )
                    Session("AdminPostcodeCountryName") = TextBoxAddCountryEN.Text.Trim
                    ClearAddCountryTextboxes()
                Case "Region"
                    ' Add Region
                    CDataAccess.AddPostcode(Convert.ToInt32(Session("AdminPostcodeCountryID")), TextBoxAddName.Text.Trim)
                    Session("AdminPostcodeRegionName") = TextBoxAddName.Text.Trim
                Case "Area"
                    ' Adding Area
                    CDataAccess.AddPostcode(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")), TextBoxAddName.Text.Trim, TextBoxAddPostcode.Text.Trim, Convert.ToInt32(DropDownListAddDefaultPartner.SelectedValue))
                    Session("AdminPostcodeAreaName") = TextBoxAddName.Text.Trim
                Case Else
                    If hdnSubAreaId.Value = "" Then
                        ' Adding SubArea
                        CDataAccess.AddPostcode(Convert.ToInt32(Session("AdminPostcodeCountryID")), Convert.ToInt32(Session("AdminPostcodeRegionID")), Convert.ToInt32(Session("AdminPostcodeAreaID")), TextBoxAddName.Text.Trim, TextBoxAddPostcode.Text.Trim, Convert.ToInt32(DropDownListAddDefaultPartner.SelectedValue))

                        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "alert('Record added successfully !');", True)
                    Else
                        'just to add a new postcode record based on region , area OR sub area
                        Dim sql As SqlParameter() = New SqlParameter(4) {}
                        sql(1) = New SqlParameter("@SubArea_Id", hdnSubAreaId.Value)
                        sql(2) = New SqlParameter("@PostCode_Id", hdnPostCodeId.Value)
                        sql(3) = New SqlParameter("@SubArea_Name", TextBoxAddName.Text)
                        sql(4) = New SqlParameter("@PostCode", TextBoxAddPostcode.Text)
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_SubAreaPostCode_Update", sql)
                        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "alert('Record updated successfully !');", True)
                    End If
                    Session("AdminPostcodeSubAreaName") = TextBoxAddName.Text.Trim
                    TextBoxAddPostcode.Text = String.Empty
                    hdnSubAreaId.Value = ""
                    hdnPostCodeId.Value = ""

            End Select
            Update_LatLong_For_New_Postcodes()
            TextBoxAddName.Text = String.Empty


            ' Tidy
            CDataAccess = Nothing

            ' Depending on Level
            Select Case GetParentEntity()

                Case "TopLevel"
                    InitData()

                Case "Country"
                    InitCountry()

                Case "Region"
                    InitRegion()

                Case "Area"
                    InitArea()

                Case Else
                    InitSubArea()

            End Select

            ' Clear the Text Boxes for Adding
            'TextBoxAddName.Text = String.Empty
            'TextBoxAddPostcode.Text = String.Empty

        Else

            ' Inform the User
            RaiseEvent Message("Missing Data", alMessage, True)

        End If

        ' Tidy
        alMessage.Clear()
        alMessage = Nothing

        'If hdnSubAreaId.Value = "" Then
        '    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "alert('Record added successfully !');", True)
        'Else
        '    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "alert('Record updated successfully !');", True)
        'End If
    End Sub

    Protected Sub ButtonSaveEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSaveEdit.Click
        ' If Session still Active
        If Session("AdminPostcodeLevel") Is Nothing Then
            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")
        Else
            ' Local Vars
            Dim alMessage As New ArrayList
            ' Check we have a Name Specified
            If TableRowEditName.Visible And TextBoxEditName.Text.Trim = String.Empty Then
                ' Add Message
                alMessage.Add("You must provide a name before saving this " & GetThisEntity())
            End If
            ' Check we have the Country in English
            If TableRowEditCountryEN.Visible And TextBoxEditCountryEN.Text.Trim = String.Empty Then
                ' Add Message
                alMessage.Add("You must provide the name of the country in English")
            End If
            ' Check we have the Country in Spanish
            If TableRowEditCountryES.Visible And TextBoxEditCountryES.Text.Trim = String.Empty Then
                ' Add Message
                alMessage.Add("You must provide the name of the country in Spanish")
            End If
            ' Check we have the Country in French
            If TableRowEditCountryFR.Visible And TextBoxEditCountryFR.Text.Trim = String.Empty Then
                ' Add Message
                alMessage.Add("You must provide the name of the country in French")
            End If
            ' Check we have the Country in German
            If TableRowEditCountryDE.Visible And TextBoxEditCountryDE.Text.Trim = String.Empty Then
                ' Add Message
                alMessage.Add("You must provide the name of the country in German")
            End If
            ' Check we have the Country in Dutch
            If TableRowEditCountryNL.Visible And TextBoxEditCountryNL.Text.Trim = String.Empty Then
                ' Add Message
                alMessage.Add("You must provide the name of the country in Dutch")
            End If
            ' Check we have the Country Code
            If TableRowEditCountryCode.Visible And TextBoxEditCountryCode.Text.Trim = String.Empty Then
                ' Add Message
                alMessage.Add("You must provide a country code")
            End If
            ' If a Postcode is required and not been Supplied
            If TableRowEditPostcode.Visible And TextBoxEditPostcode.Text.Trim = String.Empty Then
                ' Add Message
                alMessage.Add("You must provide a postcode before saving this " & GetParentEntity())
            End If
            ' If we have had no Errors
            If alMessage.Count = 0 Then
                ' Local Vars
                Dim CDataAccess As New ClassDataAccess
                ' Depending on Level
                Select Case GetParentEntity()
                    Case "Country"
                        ' Updating Country
                        CDataAccess.UpdateCountry(Convert.ToInt32(Session("AdminPostcodeCountryID")), TextBoxEditCountryEN.Text.Trim, TextBoxEditCountryES.Text.Trim, TextBoxEditCountryFR.Text.Trim, TextBoxEditCountryDE.Text.Trim, TextBoxEditCountryNL.Text.Trim, TextBoxEditCountryCode.Text.Trim)
                        Session("AdminPostcodeCountryName") = TextBoxEditName.Text.Trim
                    Case "Region"
                        ' Updating Region
                        CDataAccess.UpdatePostcode(Convert.ToInt32(Session("AdminPostcodeRegionID")), TextBoxEditName.Text.Trim)
                        Session("AdminPostcodeRegionName") = TextBoxEditName.Text.Trim

                    Case "Area"
                        ' Updating Area

                        CDataAccess.UpdatePostcode(Convert.ToInt32(Session("AdminPostcodeRegionID")), Convert.ToInt32(Session("AdminPostcodeAreaID")), TextBoxEditName.Text.Trim, TextBoxEditPostcode.Text.Trim, Convert.ToInt32(DropDownListEditDefaultPartner.SelectedValue))

                        'Get Latitude & Longitude by api by passing required information and update gps_latitude and gps_longitude columns

                        Dim sqlpcdetailsforarea As SqlParameter() = New SqlParameter(2) {}
                        sqlpcdetailsforarea(1) = New SqlParameter("@Area_Id", Convert.ToInt32(Session("AdminPostcodeAreaID")))
                        sqlpcdetailsforarea(2) = New SqlParameter("@Region_Id", Convert.ToInt32(Session("AdminPostcodeRegionID")))
                        Dim dtPostCodeDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_GetPostCodeAddress_For_Area", sqlpcdetailsforarea).Tables(0)
                        If dtPostCodeDetails.Rows.Count > 0 Then
                            Update_LatLong_For_OnePostcode(dtPostCodeDetails.Rows(0)("Address").ToString(), dtPostCodeDetails.Rows(0)("Postcode_Id").ToString())
                        End If

                        Session("AdminPostcodeAreaName") = TextBoxEditName.Text.Trim

                        'Update partner_id with in property table for all these post codes

                        Dim sql As SqlParameter() = New SqlParameter(2) {}
                        sql(1) = New SqlParameter("@PostCode_Id", Convert.ToInt32(TextBoxEditPostcode.Text.Trim))
                        sql(2) = New SqlParameter("@Partner_Id", Convert.ToInt32(DropDownListEditDefaultPartner.SelectedValue))
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_Partner_Id", sql)

                    Case Else
                        ' Updating SubArea
                        CDataAccess.UpdatePostcode(Convert.ToInt32(Session("AdminPostcodeRegionID")), Convert.ToInt32(Session("AdminPostcodeAreaID")), Convert.ToInt32(Session("AdminPostcodeSubAreaID")), TextBoxEditName.Text.Trim, TextBoxEditPostcode.Text.Trim, Convert.ToInt32(DropDownListEditDefaultPartner.SelectedValue))

                        'Get Latitude & Longitude by api by passing required information and update gps_latitude and gps_longitude columns

                        Dim sqlpcdetailsforsubarea As SqlParameter() = New SqlParameter(3) {}
                        sqlpcdetailsforsubarea(1) = New SqlParameter("@Area_Id", Convert.ToInt32(Session("AdminPostcodeAreaID")))
                        sqlpcdetailsforsubarea(2) = New SqlParameter("@Region_Id", Convert.ToInt32(Session("AdminPostcodeRegionID")))
                        sqlpcdetailsforsubarea(3) = New SqlParameter("@SubArea_Id", Convert.ToInt32(Session("AdminPostcodeSubAreaID")))
                        Dim dtPostCodeDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_GetPostCodeAddress_For_SubArea", sqlpcdetailsforsubarea).Tables(0)
                        If dtPostCodeDetails.Rows.Count > 0 Then
                            Update_LatLong_For_OnePostcode(dtPostCodeDetails.Rows(0)("Address").ToString(), dtPostCodeDetails.Rows(0)("Postcode_Id").ToString())
                        End If
                        Session("AdminPostcodeSubAreaName") = TextBoxEditName.Text.Trim

                        'Update partner_id with in property table for all these post codes

                        Dim sql As SqlParameter() = New SqlParameter(2) {}
                        sql(1) = New SqlParameter("@PostCode_Id", Convert.ToInt32(TextBoxEditPostcode.Text.Trim))
                        sql(2) = New SqlParameter("@Partner_Id", Convert.ToInt32(DropDownListEditDefaultPartner.SelectedValue))
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_Partner_Id", sql)

                End Select
                'Update_LatLong_For_New_Postcodes()
                ' Tidy
                CDataAccess = Nothing
                ' Depending on Level
                Select Case GetParentEntity()
                    'Case "Country"
                    '    InitData()
                    Case "Region"
                        InitData()
                    Case "Area"
                        InitRegion()
                    Case Else
                        InitArea()

                End Select

            Else

                ' Inform the User
                RaiseEvent Message("Missing Data", alMessage, True)

            End If

            ' Tidy
            alMessage.Clear()
            alMessage = Nothing

        End If
    End Sub

    Public Sub Update_LatLong_For_New_Postcodes()
        Dim dtPostcodes As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_GetPostCodeAddress_ToGenerate_LatLong").Tables(0)
        For Each dr As DataRow In dtPostcodes.Rows
            Dim address As String = dr("Address")
            'Dim postCode As String = dr("Postcode")
            Dim postCode As String = dr("Postcode_id")
            'Dim googleAPIUrl As String = "https://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4"
            Dim googleAPIUrl As String = "https://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&key=AIzaSyA5h3ZfC3rhIC2ow1VlVC_J6sprxC1Rbns"
            Dim request As WebRequest = WebRequest.Create(googleAPIUrl)
            Dim response As WebResponse = request.GetResponse()
            Dim dataStream As Stream = response.GetResponseStream
            Dim reader As StreamReader = New StreamReader(dataStream)
            Dim dsResult As New DataSet
            dsResult.ReadXml(reader)
            Try
                For Each drInner As DataRow In dsResult.Tables("result").Rows
                    Dim geometry_id As String = dsResult.Tables("geometry").Select("result_id = " & drInner("result_id").ToString())(0)("geometry_id").ToString()
                    Dim location As DataRow = dsResult.Tables("location").Select("geometry_id = " + geometry_id)(0)
                    Update_LatLong_By_Postcode(postCode, Convert.ToDecimal(location("lat")), Convert.ToDecimal(location("lng")))
                Next
                'End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Public Sub Update_LatLong_By_Postcode(ByVal postcode As String, ByVal GPS_Latitude As Decimal, ByVal GPS_Longitude As Decimal)
        Dim sql As SqlParameter() = New SqlParameter(3) {}
        sql(0) = New SqlParameter("@Postcode_Id", postcode)
        sql(1) = New SqlParameter("@GPS_Latitude", GPS_Latitude)
        sql(2) = New SqlParameter("@GPS_Longitude", GPS_Longitude)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_PostCode_Update_LatLong_By_PostCodeId", sql)
    End Sub

    Public Sub Update_LatLong_For_OnePostcode(ByVal address As String, ByVal postCode As String)
        'Dim googleAPIUrl As String = "https://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4"
        Dim googleAPIUrl As String = "https://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&key=AIzaSyA5h3ZfC3rhIC2ow1VlVC_J6sprxC1Rbns"
        Dim request As WebRequest = WebRequest.Create(googleAPIUrl)
        Dim response As WebResponse = request.GetResponse()
        Dim dataStream As Stream = response.GetResponseStream
        Dim reader As StreamReader = New StreamReader(dataStream)
        Dim dsResult As New DataSet
        dsResult.ReadXml(reader)
        Try
            For Each drInner As DataRow In dsResult.Tables("result").Rows
                Dim geometry_id As String = dsResult.Tables("geometry").Select("result_id = " & drInner("result_id").ToString())(0)("geometry_id").ToString()
                Dim location As DataRow = dsResult.Tables("location").Select("geometry_id = " + geometry_id)(0)
                Update_LatLong_By_Postcode(postCode, Convert.ToDecimal(location("lat")), Convert.ToDecimal(location("lng")))
            Next
            'End If
        Catch ex As Exception

        End Try
    End Sub

End Class