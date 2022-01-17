Imports System.Data

Partial Class WebUserControlAdminClientTour
    Inherits System.Web.UI.UserControl

    Public Event Feedback()

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Check we have Session Open to Commence
        If Session("ContactID") Is Nothing Or Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim nScratch As Integer
            Dim CDataAccess As New ClassDataAccess

            ' For each Month
            For nScratch = 1 To 12

                ' Add the Month to the List
                DropDownListViewDateMonth.Items.Add(MonthName(nScratch))

            Next

            ' Add Years, lat Year, this Year and Next
            DropDownListViewDateYear.Items.Add(DateAdd(DateInterval.Year, -1, Now).Year)
            DropDownListViewDateYear.Items.Add(Now.Year)
            DropDownListViewDateYear.Items.Add(DateAdd(DateInterval.Year, 1, Now).Year)

            ' Set the Meeting Date to Tomorrow
            Dim dateTomorrow As Date = DateAdd(DateInterval.Day, 1, Today)

            ' Set the Form Fields
            DropDownListViewDateYear.SelectedValue = dateTomorrow.Year
            DropDownListViewDateMonth.SelectedIndex = dateTomorrow.Month - 1

            ' Populate the Number of Days in this Month
            PopulateDaysOfMonth()

            ' Set the Day
            DropDownListViewDateDay.SelectedValue = dateTomorrow.Day

            ' For each Hour
            For nScratch = 0 To 23

                ' Add the Hours to the Drop Downs
                DropDownListMeetingTimeHour.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour1.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour2.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour3.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour4.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour5.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour6.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour7.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour8.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour9.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeHour10.Items.Add(nScratch.ToString("00").Trim)

            Next

            ' In Five Minute Increments
            For nScratch = 0 To 55 Step 5

                ' Add the Minutes to the Drop Downs
                DropDownListMeetingTimeMinute.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute1.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute2.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute3.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute4.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute5.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute6.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute7.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute8.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute9.Items.Add(nScratch.ToString("00").Trim)
                DropDownListTimeMinute10.Items.Add(nScratch.ToString("00").Trim)

            Next

            ' Set All Times for Mid Day
            DropDownListMeetingTimeHour.SelectedValue = "12"
            DropDownListMeetingTimeMinute.SelectedValue = "00"
            DropDownListTimeHour1.SelectedValue = "12"
            DropDownListTimeMinute1.SelectedValue = "00"
            DropDownListTimeHour2.SelectedValue = "12"
            DropDownListTimeMinute2.SelectedValue = "00"
            DropDownListTimeHour3.SelectedValue = "12"
            DropDownListTimeMinute3.SelectedValue = "00"
            DropDownListTimeHour4.SelectedValue = "12"
            DropDownListTimeMinute4.SelectedValue = "00"
            DropDownListTimeHour5.SelectedValue = "12"
            DropDownListTimeMinute5.SelectedValue = "00"
            DropDownListTimeHour6.SelectedValue = "12"
            DropDownListTimeMinute6.SelectedValue = "00"
            DropDownListTimeHour7.SelectedValue = "12"
            DropDownListTimeMinute7.SelectedValue = "00"
            DropDownListTimeHour8.SelectedValue = "12"
            DropDownListTimeMinute8.SelectedValue = "00"
            DropDownListTimeHour9.SelectedValue = "12"
            DropDownListTimeMinute9.SelectedValue = "00"
            DropDownListTimeHour10.SelectedValue = "12"
            DropDownListTimeMinute10.SelectedValue = "00"

            ' Add Buyer Options
            DropDownListBuyer.DataSource = CDataAccess.Buyers
            DropDownListBuyer.DataTextField = "text"
            DropDownListBuyer.DataValueField = "id"
            DropDownListBuyer.DataBind()

            ' Init Contact's Telephone Number
            DropDownListBuyer_SelectedIndexChanged(Nothing, Nothing)

            ' Add List of Client Tour By Options        
            DropDownListTouredWith.DataSource = CDataAccess.Users
            DropDownListTouredWith.DataTextField = "text"
            DropDownListTouredWith.DataValueField = "id"
            DropDownListTouredWith.DataBind()

            ' If a Contact is Logged in
            If Not Session("ContactID") Is Nothing Then

                ' Attempt to Select the Contact
                DropDownListTouredWith.SelectedValue = Session("ContactID")

            End If

            ' Populate the Property References
            Dim dtDataTable As DataTable = CDataAccess.ClientTourPropertieswithoutcase(Session("ContactPartnerID"))
            Dim dtDataTable1 As DataTable = CDataAccess.ClientTourProperties(Session("ContactPartnerID"))

            ' Poplate Property Reference Drop Downs
            PopulatePropertyReference(DropDownListReference1, dtDataTable)
            PopulatePropertyReference(DropDownListReference2, dtDataTable)
            PopulatePropertyReference(DropDownListReference3, dtDataTable)
            PopulatePropertyReference(DropDownListReference4, dtDataTable)
            PopulatePropertyReference(DropDownListReference5, dtDataTable)
            PopulatePropertyReference(DropDownListReference6, dtDataTable)
            PopulatePropertyReference(DropDownListReference7, dtDataTable)
            PopulatePropertyReference(DropDownListReference8, dtDataTable)
            PopulatePropertyReference(DropDownListReference9, dtDataTable)
            PopulatePropertyReference(DropDownListReference10, dtDataTable)

            ' Tidy
            dtDataTable.Dispose()

            ' Tidy
            CDataAccess = Nothing

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If not a Postback
        If Not Page.IsPostBack Then

            ' Init Session Tour ID
            Session("ClientTourID") = Nothing

            ' If we have Properties to Initialise the Form with
            If Not Session("AdminClientTourPropertiesSelected") Is Nothing Then

                ' Init Counter
                Dim nCounter As Integer = 0

                ' For each Element in the Array
                For Each nID As Integer In DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList)

                    ' Increment Counter
                    nCounter += 1

                    ' Depending on the Counter
                    Select Case nCounter

                        ' Assigning Property ID
                        Case 1
                            DropDownListReference1.SelectedValue = nID
                            DropDownListReference1_SelectedIndexChanged(Nothing, Nothing)
                        Case 2
                            DropDownListReference2.SelectedValue = nID
                            DropDownListReference2_SelectedIndexChanged(Nothing, Nothing)
                        Case 3
                            DropDownListReference3.SelectedValue = nID
                            DropDownListReference3_SelectedIndexChanged(Nothing, Nothing)
                        Case 4
                            DropDownListReference4.SelectedValue = nID
                            DropDownListReference4_SelectedIndexChanged(Nothing, Nothing)
                        Case 5
                            DropDownListReference5.SelectedValue = nID
                            DropDownListReference5_SelectedIndexChanged(Nothing, Nothing)
                        Case 6
                            DropDownListReference6.SelectedValue = nID
                            DropDownListReference6_SelectedIndexChanged(Nothing, Nothing)
                        Case 7
                            DropDownListReference7.SelectedValue = nID
                            DropDownListReference7_SelectedIndexChanged(Nothing, Nothing)
                        Case 8
                            DropDownListReference8.SelectedValue = nID
                            DropDownListReference8_SelectedIndexChanged(Nothing, Nothing)
                        Case 9
                            DropDownListReference9.SelectedValue = nID
                            DropDownListReference9_SelectedIndexChanged(Nothing, Nothing)
                        Case Else
                            DropDownListReference10.SelectedValue = nID
                            DropDownListReference10_SelectedIndexChanged(Nothing, Nothing)

                    End Select

                Next

            End If

            ' Clean the Form
            MakeClean()

        End If

    End Sub

    Private Sub PopulatePropertyReference(ByRef ddl As DropDownList, ByVal dtDataTable As DataTable)

        ' Populate the Property References
        ddl.DataSource = dtDataTable
        ddl.DataTextField = "text"
        ddl.DataValueField = "id"
        ddl.DataBind()

        ' Add 'Add' Option
        ddl.Items.Insert(0, "-- Add --")

    End Sub

    Private Sub PopulateDaysOfMonth()

        ' Local Vars
        Dim nCurrentIndex As Integer = -1

        ' If we have a Current Selection
        If DropDownListViewDateDay.SelectedValue <> String.Empty Then

            ' Store the Current Selection
            nCurrentIndex = DropDownListViewDateDay.SelectedIndex

        End If

        ' Clear the Current List
        DropDownListViewDateDay.Items.Clear()

        ' For each Day in this Month
        For nDay As Integer = 1 To DateTime.DaysInMonth(Convert.ToInt32(DropDownListViewDateYear.SelectedValue), DropDownListViewDateMonth.SelectedIndex + 1)

            ' Add Value
            DropDownListViewDateDay.Items.Add(nDay.ToString.Trim)

        Next

        ' If we Stored a Previous Value
        If nCurrentIndex > -1 Then

            ' Try and Restore the Value - if the Value Exists
            If DropDownListViewDateDay.Items.Count > nCurrentIndex Then

                ' Restore Value
                DropDownListViewDateDay.SelectedIndex = nCurrentIndex

            Else

                ' Set to Month Max
                DropDownListViewDateDay.SelectedIndex = DropDownListViewDateDay.Items.Count - 1

            End If

        End If

    End Sub

    Protected Sub DropDownListViewDateMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListViewDateMonth.SelectedIndexChanged

        MakeDirty()

        ' Populate the Number of Days in this Month
        PopulateDaysOfMonth()

    End Sub

    Protected Sub DropDownListViewDateYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListViewDateYear.SelectedIndexChanged

        MakeDirty()

        ' Populate the Number of Days in this Month
        PopulateDaysOfMonth()

    End Sub

    Private Sub UpdatePropertyDetails(ByVal ddl As DropDownList, ByVal nPropertyID As Integer, ByRef lblpatner As Label, ByRef lblName As Label, ByRef lblAddress As Label, ByRef lblTown As Label, ByRef lblContactNo As Label, ByRef lblPrice As Label, ByRef ddlHour As DropDownList, ByRef lblSeparator As Label, ByRef ddlMinute As DropDownList, ByRef lblKey As Label)

        ' Get the Property Details
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable = CDataAccess.ClientTourPropertyDetail(nPropertyID)
        CDataAccess = Nothing

        ' If we Loaded the Property
        If dtDataTable.Rows.Count > 0 Then

            ' Populate Form
            If dtDataTable.Rows(0).Item("Video_URL").ToString() = "" Then
                lblpatner.Style.Add("color", "red")
                ddl.Style.Add("color", "red")
            End If

            lblpatner.Text = Convert.ToString(dtDataTable.Rows(0).Item("Reference"))
            lblName.Text = Convert.ToString(dtDataTable.Rows(0).Item("Name"))
            lblAddress.Text = Convert.ToString(dtDataTable.Rows(0).Item("Address"))
            lblTown.Text = Convert.ToString(dtDataTable.Rows(0).Item("Town"))
            lblContactNo.Text = Convert.ToString(dtDataTable.Rows(0).Item("Telephone")) & " / " & Convert.ToString(dtDataTable.Rows(0).Item("Mobile"))

            ' Add the Price
            Dim CUtilities As New ClassUtilities
            lblPrice.Text = CUtilities.FormatPrice(Convert.ToInt32(dtDataTable.Rows(0).Item("Price")))
            CUtilities = Nothing

            ' Make Appointment Visible
            ddlHour.Visible = True
            lblSeparator.Visible = True
            ddlMinute.Visible = True

            ' Add Door Key
            lblKey.Text = dtDataTable.Rows(0).Item("Key")

            ' Update Property Count
            UpdatePropertyCount()

        Else

            ' No Data - Clear
            ClearRow(lblpatner, lblName, lblAddress, lblTown, lblContactNo, lblPrice, ddlHour, lblSeparator, ddlMinute, lblKey)

        End If

        ' Tidy
        dtDataTable = Nothing

    End Sub

    Private Sub ClearRow(ByRef lblpatner As Label, ByRef lblName As Label, ByRef lblAddress As Label, ByRef lblTown As Label, ByRef lblContactNo As Label, ByRef lblPrice As Label, ByRef ddlHour As DropDownList, ByRef lblSeparator As Label, ByRef ddlMinute As DropDownList, ByRef lblKey As Label)

        ' Clear the Row
        lblpatner.Text = String.Empty
        lblName.Text = String.Empty
        lblAddress.Text = String.Empty
        lblTown.Text = String.Empty
        lblContactNo.Text = String.Empty
        lblPrice.Text = String.Empty
        ddlHour.Visible = False
        lblSeparator.Visible = False
        ddlMinute.Visible = False
        lblKey.Text = String.Empty

        ' Update Property Count
        UpdatePropertyCount()

    End Sub

    Private Sub UpdatePropertyCount()

        ' Local Vars
        Dim nCount As Integer = 0

        ' For each of the Drop Downs
        If DropDownListReference1.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference2.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference3.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference4.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference5.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference6.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference7.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference8.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference9.SelectedIndex > 0 Then
            nCount += 1
        End If
        If DropDownListReference10.SelectedIndex > 0 Then
            nCount += 1
        End If

        ' Update Counter
        LabelNoOfProperties.Text = nCount.ToString.Trim

    End Sub

    Private Function PropertyPreviouslySelected(ByVal ddl As DropDownList) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean = False

        ' If this is not set to NULL
        If ddl.SelectedIndex > 0 Then

            ' For each Row in the Tour Body Table
            For Each tr As TableRow In TableTourBody.Rows

                ' For each Cell
                For Each tc As TableCell In tr.Cells

                    ' For each Control in the Cell
                    For Each ctrl As Control In tc.Controls

                        ' If this is a Drop Down List
                        If TypeOf (ctrl) Is DropDownList Then

                            ' If this is a Property Reference Drop Down and not the one Changed
                            If DirectCast(ctrl, DropDownList).ID.StartsWith("DropDownListReference") And Not DirectCast(ctrl, DropDownList).ID = ddl.ID Then

                                ' If the Index Matches
                                If DirectCast(ctrl, DropDownList).SelectedIndex = ddl.SelectedIndex Then

                                    ' Set the Flag
                                    bRetVal = True

                                End If

                            End If

                        End If

                    Next

                Next

            Next

        End If

        ' Return the Result
        Return bRetVal

    End Function

    Private Sub ProcessPropertySelection(ByRef ddl As DropDownList,
                                         ByRef lblpatner As Label,
                                         ByRef lblName As Label,
                                         ByRef lblAddress As Label,
                                         ByRef lblTown As Label,
                                         ByRef lblContactNo As Label,
                                         ByRef lblPrice As Label,
                                         ByRef ddlTimeHour As DropDownList,
                                         ByRef lblTimeSeparator As Label,
                                         ByRef ddlTimeMinute As DropDownList,
                                         ByRef lblKey As Label)

        ' Make the Form Dirty
        MakeDirty()

        ' Check if Previously Selected
        If PropertyPreviouslySelected(ddl) Then

            ' Set to NULL
            ddl.SelectedIndex = 0

            ' Clear the Row
            ClearRow(lblpatner, lblName, lblAddress, lblTown, lblContactNo, lblPrice, ddlTimeHour, lblTimeSeparator, ddlTimeMinute, lblKey)

        Else

            ' If we have a Reference Selected
            If ddl.SelectedIndex > 0 Then

                ' Update Property Details
                UpdatePropertyDetails(ddl, Convert.ToInt32(ddl.SelectedValue), lblpatner, lblName, lblAddress, lblTown, lblContactNo, lblPrice, ddlTimeHour, lblTimeSeparator, ddlTimeMinute, lblKey)

            Else

                ' Clear the Row
                ClearRow(lblpatner, lblName, lblAddress, lblTown, lblContactNo, lblPrice, ddlTimeHour, lblTimeSeparator, ddlTimeMinute, lblKey)

            End If

        End If

    End Sub

    Protected Sub DropDownListReference1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference1.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference1, Labelpatner1, LabelName1, LabelAddress1, LabelTown1, LabelContactNo1, LabelPrice1, DropDownListTimeHour1, LabelTimeSeparator1, DropDownListTimeMinute1, LabelKey1)
    End Sub

    Protected Sub DropDownListReference2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference2.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference2, Labelpatner2, LabelName2, LabelAddress2, LabelTown2, LabelContactNo2, LabelPrice2, DropDownListTimeHour2, LabelTimeSeparator2, DropDownListTimeMinute2, LabelKey2)
    End Sub

    Protected Sub DropDownListReference3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference3.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference3, Labelpatner3, LabelName3, LabelAddress3, LabelTown3, LabelContactNo3, LabelPrice3, DropDownListTimeHour3, LabelTimeSeparator3, DropDownListTimeMinute3, LabelKey3)
    End Sub

    Protected Sub DropDownListReference4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference4.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference4, Labelpatner4, LabelName4, LabelAddress4, LabelTown4, LabelContactNo4, LabelPrice4, DropDownListTimeHour4, LabelTimeSeparator4, DropDownListTimeMinute4, LabelKey4)
    End Sub

    Protected Sub DropDownListReference5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference5.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference5, Labelpatner5, LabelName5, LabelAddress5, LabelTown5, LabelContactNo5, LabelPrice5, DropDownListTimeHour5, LabelTimeSeparator5, DropDownListTimeMinute5, LabelKey5)
    End Sub

    Protected Sub DropDownListReference6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference6.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference6, Labelpatner6, LabelName6, LabelAddress6, LabelTown6, LabelContactNo6, LabelPrice6, DropDownListTimeHour6, LabelTimeSeparator6, DropDownListTimeMinute6, LabelKey6)
    End Sub

    Protected Sub DropDownListReference7_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference7.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference7, Labelpatner7, LabelName7, LabelAddress7, LabelTown7, LabelContactNo7, LabelPrice7, DropDownListTimeHour7, LabelTimeSeparator7, DropDownListTimeMinute7, LabelKey7)
    End Sub

    Protected Sub DropDownListReference8_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference8.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference8, Labelpatner8, LabelName8, LabelAddress8, LabelTown8, LabelContactNo8, LabelPrice8, DropDownListTimeHour8, LabelTimeSeparator8, DropDownListTimeMinute8, LabelKey8)
    End Sub

    Protected Sub DropDownListReference9_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference9.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference9, Labelpatner9, LabelName9, LabelAddress9, LabelTown9, LabelContactNo9, LabelPrice9, DropDownListTimeHour9, LabelTimeSeparator9, DropDownListTimeMinute9, LabelKey9)
    End Sub

    Protected Sub DropDownListReference10_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListReference10.SelectedIndexChanged
        ProcessPropertySelection(DropDownListReference10, Labelpatner10, LabelName10, LabelAddress10, LabelTown10, LabelContactNo10, LabelPrice10, DropDownListTimeHour10, LabelTimeSeparator10, DropDownListTimeMinute10, LabelKey10)
    End Sub

    Private Sub AddPropertyToTour(ByRef CClientTour As ClassClientTour, ByVal ddlRef As DropDownList, ByVal ddlHour As DropDownList, ByVal ddlMinute As DropDownList)

        ' Assign Properties Viewed
        If ddlRef.SelectedIndex > 0 Then

            ' Assign Property Vars
            Dim CClientTourProperty As New ClassClientTourProperty
            CClientTourProperty.PropertyID = Convert.ToInt32(ddlRef.SelectedValue)
            CClientTourProperty.ViewingTime = New DateTime(Convert.ToInt32(DropDownListViewDateYear.SelectedValue), DropDownListViewDateMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListViewDateDay.SelectedValue), Convert.ToInt32(ddlHour.SelectedValue), Convert.ToInt32(ddlMinute.SelectedValue), 0)

            ' Add to Tour
            CClientTour.TourProperty.Add(CClientTourProperty)

        End If

    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' Assign the Client Tour to Class
        Dim CClientTour As New ClassClientTour

        ' Are we Updating an Existing Tour?
        If LabelViewingReference.Text <> String.Empty Then

            ' Assign ID
            CClientTour.TourID = Convert.ToInt32(LabelViewingReference.Text)

        End If
        ' Assign Parameters
        CClientTour.BuyerID = Convert.ToInt32(DropDownListBuyer.SelectedValue)
        CClientTour.TourWithID = Convert.ToInt32(DropDownListTouredWith.SelectedValue)
        CClientTour.ViewingDate = New DateTime(Convert.ToInt32(DropDownListViewDateYear.SelectedValue), DropDownListViewDateMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListViewDateDay.SelectedValue), Convert.ToInt32(DropDownListMeetingTimeHour.SelectedValue), Convert.ToInt32(DropDownListMeetingTimeMinute.SelectedValue), 0)

        ' Adding Properties being Visited
        AddPropertyToTour(CClientTour, DropDownListReference1, DropDownListTimeHour1, DropDownListTimeMinute1)
        AddPropertyToTour(CClientTour, DropDownListReference2, DropDownListTimeHour2, DropDownListTimeMinute2)
        AddPropertyToTour(CClientTour, DropDownListReference3, DropDownListTimeHour3, DropDownListTimeMinute3)
        AddPropertyToTour(CClientTour, DropDownListReference4, DropDownListTimeHour4, DropDownListTimeMinute4)
        AddPropertyToTour(CClientTour, DropDownListReference5, DropDownListTimeHour5, DropDownListTimeMinute5)
        AddPropertyToTour(CClientTour, DropDownListReference6, DropDownListTimeHour6, DropDownListTimeMinute6)
        AddPropertyToTour(CClientTour, DropDownListReference7, DropDownListTimeHour7, DropDownListTimeMinute7)
        AddPropertyToTour(CClientTour, DropDownListReference8, DropDownListTimeHour8, DropDownListTimeMinute8)
        AddPropertyToTour(CClientTour, DropDownListReference9, DropDownListTimeHour9, DropDownListTimeMinute9)
        AddPropertyToTour(CClientTour, DropDownListReference10, DropDownListTimeHour10, DropDownListTimeMinute10)

        ' Saving the Client Tour
        Dim CDataAccess As New ClassDataAccess
        LabelViewingReference.Text = CDataAccess.SaveClientTour(CClientTour).ToString.Trim
        CDataAccess = Nothing

        ' Display the Saved Message
        TableRowSaved.Visible = True
        UpdatePanelAdminClientTour.Update()

        ' Assign Tour ID
        Session("ClientTourID") = Convert.ToInt32(LabelViewingReference.Text)

        ' Reload the Tour
        LoadTour()

    End Sub

    Protected Sub DropDownListBuyer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListBuyer.SelectedIndexChanged

        ' If we have a Selected Buyer
        If DropDownListBuyer.SelectedValue.Trim <> String.Empty Then

            MakeDirty()

            ' Set this Contact's Telephone Number
            Dim CDataAccess As New ClassDataAccess
            LabelContactTelEmail.Text = CDataAccess.BuyerTelEmail(Convert.ToInt32(DropDownListBuyer.SelectedValue))
            CDataAccess = Nothing

            ' Update Client Ref
            LabelClientReference.Text = DropDownListBuyer.SelectedValue

        End If

    End Sub

    Private Sub LoadPropertyViewing(ByVal CClientTourProperty As ClassClientTourProperty, ByRef ddlRef As DropDownList, ByRef ddlHour As DropDownList, ByRef ddlMinute As DropDownList)

        MakeDirty()

        ' Selected Saved Variables
        ddlRef.SelectedValue = CClientTourProperty.PropertyID
        ddlHour.SelectedValue = Format(CClientTourProperty.ViewingTime.Hour, "00")
        ddlMinute.SelectedValue = Format(CClientTourProperty.ViewingTime.Minute, "00")

    End Sub

    Private Sub ClearPropertySelections()

        ' Clearing Selections
        DropDownListReference1.SelectedIndex = 0
        DropDownListReference1_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference2.SelectedIndex = 0
        DropDownListReference2_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference3.SelectedIndex = 0
        DropDownListReference3_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference4.SelectedIndex = 0
        DropDownListReference4_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference5.SelectedIndex = 0
        DropDownListReference5_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference6.SelectedIndex = 0
        DropDownListReference6_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference7.SelectedIndex = 0
        DropDownListReference7_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference8.SelectedIndex = 0
        DropDownListReference8_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference9.SelectedIndex = 0
        DropDownListReference9_SelectedIndexChanged(Nothing, Nothing)
        DropDownListReference10.SelectedIndex = 0
        DropDownListReference10_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Public Sub LoadTour()

        ' Local Vars
        Dim nPropertyCounter As Integer = 0

        ' Load the Tour
        Dim CDataAccess As New ClassDataAccess

        ' Add Buyer Options
        DropDownListBuyer.Items.Clear()
        DropDownListBuyer.DataSource = CDataAccess.Buyers(True)
        DropDownListBuyer.DataTextField = "text"
        DropDownListBuyer.DataValueField = "id"
        DropDownListBuyer.DataBind()


        ' Load Client Tour
        Dim CClientTour As ClassClientTour = CDataAccess.LoadClientTour(Convert.ToInt32(Session("ClientTourID")), Convert.ToInt32(Session("ContactPartnerID")))        

        ' Assign to the Form
        LabelViewingReference.Text = CClientTour.TourID.ToString.Trim
        DropDownListBuyer.SelectedValue = CClientTour.BuyerID
        DropDownListBuyer_SelectedIndexChanged(Nothing, Nothing)
        DropDownListTouredWith.SelectedValue = CClientTour.TourWithID
        DropDownListViewDateYear.SelectedValue = CClientTour.ViewingDate.Year
        DropDownListViewDateMonth.SelectedIndex = CClientTour.ViewingDate.Month - 1
        PopulateDaysOfMonth()
        DropDownListViewDateDay.SelectedValue = CClientTour.ViewingDate.Day
        DropDownListMeetingTimeHour.SelectedValue = Format(CClientTour.ViewingDate.Hour, "00")
        DropDownListMeetingTimeMinute.SelectedValue = Format(CClientTour.ViewingDate.Minute, "00")

        ' Clear Previous Selections
        ClearPropertySelections()

        ' For each Property being Viewed
        For Each CClientTourProperty As ClassClientTourProperty In CClientTour.TourProperty

            ' Increment Property Counter
            nPropertyCounter += 1

            ' Depending on the Count - update the relevent row
            Select Case nPropertyCounter

                Case 1
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference1, DropDownListTimeHour1, DropDownListTimeMinute1)
                    DropDownListReference1_SelectedIndexChanged(Nothing, Nothing)

                Case 2
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference2, DropDownListTimeHour2, DropDownListTimeMinute2)
                    DropDownListReference2_SelectedIndexChanged(Nothing, Nothing)

                Case 3
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference3, DropDownListTimeHour3, DropDownListTimeMinute3)
                    DropDownListReference3_SelectedIndexChanged(Nothing, Nothing)

                Case 4
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference4, DropDownListTimeHour4, DropDownListTimeMinute4)
                    DropDownListReference4_SelectedIndexChanged(Nothing, Nothing)

                Case 5
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference5, DropDownListTimeHour5, DropDownListTimeMinute5)
                    DropDownListReference5_SelectedIndexChanged(Nothing, Nothing)

                Case 6
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference6, DropDownListTimeHour6, DropDownListTimeMinute6)
                    DropDownListReference6_SelectedIndexChanged(Nothing, Nothing)

                Case 7
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference7, DropDownListTimeHour7, DropDownListTimeMinute7)
                    DropDownListReference7_SelectedIndexChanged(Nothing, Nothing)

                Case 8
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference8, DropDownListTimeHour8, DropDownListTimeMinute8)
                    DropDownListReference8_SelectedIndexChanged(Nothing, Nothing)

                Case 9
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference9, DropDownListTimeHour9, DropDownListTimeMinute9)
                    DropDownListReference9_SelectedIndexChanged(Nothing, Nothing)

                Case Else
                    LoadPropertyViewing(CClientTourProperty, DropDownListReference10, DropDownListTimeHour10, DropDownListTimeMinute10)
                    DropDownListReference10_SelectedIndexChanged(Nothing, Nothing)

            End Select

        Next

        ' Clean the Form
        MakeClean()

        ' If this is a Historic Tour, make Read Only
        If CClientTour.ViewingDate < Today Then

            ' Disable All
            TableTourHeader.Enabled = False
            TableTourBody.Enabled = False
            ButtonSave.Visible = False

            ' Enable Feedback
            ButtonFeedback.Visible = CDataAccess.ClientTourFeedbackRemaining(CClientTour.TourID)

        End If

        ' Tidy
        CDataAccess = Nothing
        CClientTour = Nothing

    End Sub

    Public Sub InitBuyer(ByVal nBuyerID As Integer)

        ' Select this Client from the Drop Down List
        DropDownListBuyer.SelectedValue = nBuyerID

        ' Disable the Drop Down
        DropDownListBuyer.Enabled = False

    End Sub

    Public Sub InitSelectedProperties(ByVal alSelectedProperties As ArrayList)

        ' Local Vars
        Dim nPropertyCounter As Integer = 0

        ' For each Property ID
        For Each nID As Integer In alSelectedProperties

            ' Increment Property Counter
            nPropertyCounter += 1

            ' Depending on the Count - update the relevent row
            Select Case nPropertyCounter

                Case 1
                    DropDownListReference1.SelectedValue = nID
                    DropDownListReference1_SelectedIndexChanged(Nothing, Nothing)

                Case 2
                    DropDownListReference2.SelectedValue = nID
                    DropDownListReference2_SelectedIndexChanged(Nothing, Nothing)

                Case 3
                    DropDownListReference3.SelectedValue = nID
                    DropDownListReference3_SelectedIndexChanged(Nothing, Nothing)

                Case 4
                    DropDownListReference4.SelectedValue = nID
                    DropDownListReference4_SelectedIndexChanged(Nothing, Nothing)

                Case 5
                    DropDownListReference5.SelectedValue = nID
                    DropDownListReference5_SelectedIndexChanged(Nothing, Nothing)

                Case 6
                    DropDownListReference6.SelectedValue = nID
                    DropDownListReference6_SelectedIndexChanged(Nothing, Nothing)

                Case 7
                    DropDownListReference7.SelectedValue = nID
                    DropDownListReference7_SelectedIndexChanged(Nothing, Nothing)

                Case 8
                    DropDownListReference8.SelectedValue = nID
                    DropDownListReference8_SelectedIndexChanged(Nothing, Nothing)

                Case 9
                    DropDownListReference9.SelectedValue = nID
                    DropDownListReference9_SelectedIndexChanged(Nothing, Nothing)

                Case Else
                    DropDownListReference10.SelectedValue = nID
                    DropDownListReference10_SelectedIndexChanged(Nothing, Nothing)

            End Select

        Next

    End Sub

    Private Sub EnableMakeDirty(ByVal bEnable As Boolean)

        ' Add / Remove Event Handlers
        DropDownListMeetingTimeHour.AutoPostBack = bEnable
        DropDownListMeetingTimeMinute.AutoPostBack = bEnable
        DropDownListTouredWith.AutoPostBack = bEnable
        DropDownListTimeHour1.AutoPostBack = bEnable
        DropDownListTimeMinute1.AutoPostBack = bEnable
        DropDownListTimeHour2.AutoPostBack = bEnable
        DropDownListTimeMinute2.AutoPostBack = bEnable
        DropDownListTimeHour3.AutoPostBack = bEnable
        DropDownListTimeMinute3.AutoPostBack = bEnable
        DropDownListTimeHour4.AutoPostBack = bEnable
        DropDownListTimeMinute4.AutoPostBack = bEnable
        DropDownListTimeHour5.AutoPostBack = bEnable
        DropDownListTimeMinute5.AutoPostBack = bEnable
        DropDownListTimeHour6.AutoPostBack = bEnable
        DropDownListTimeMinute6.AutoPostBack = bEnable
        DropDownListTimeHour7.AutoPostBack = bEnable
        DropDownListTimeMinute7.AutoPostBack = bEnable
        DropDownListTimeHour8.AutoPostBack = bEnable
        DropDownListTimeMinute8.AutoPostBack = bEnable
        DropDownListTimeHour9.AutoPostBack = bEnable
        DropDownListTimeMinute9.AutoPostBack = bEnable
        DropDownListTimeHour10.AutoPostBack = bEnable
        DropDownListTimeMinute10.AutoPostBack = bEnable

    End Sub

    Public Sub MakeDirty()

        ' Make the Form Dirty
        TableRowSaved.Visible = False
        ButtonSave.BackColor = Drawing.Color.Red
        ButtonSave.ForeColor = Drawing.Color.White
        ButtonSave.Font.Bold = True

        ' Hide the Print Button
        ButtonPrint.Visible = False

        ' Disable Make Dirty
        EnableMakeDirty(False)

    End Sub

    Private Sub MakeClean()

        ' Clean the Form
        ButtonSave.BackColor = Nothing
        ButtonSave.ForeColor = Nothing
        ButtonSave.Font.Bold = False

        ' Display / Hide Print Option
        ButtonPrint.Visible = (LabelViewingReference.Text.Trim <> String.Empty)

        ' Enable Make Dirty
        EnableMakeDirty(True)

    End Sub

    Protected Sub DropDownListTouredWith_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTouredWith.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub DropDownListViewDateDay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListViewDateDay.SelectedIndexChanged
        MakeDirty()
    End Sub

    Protected Sub ButtonFeedback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFeedback.Click

        ' Save the Tour ID
        Session("FeedbackClientTourID") = Convert.ToInt32(LabelViewingReference.Text.Trim)

        ' Raise Event
        RaiseEvent Feedback()

    End Sub

End Class
