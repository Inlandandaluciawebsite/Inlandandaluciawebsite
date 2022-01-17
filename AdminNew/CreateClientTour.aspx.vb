Imports System.Data
Imports ClassHistory

Partial Class CreateClientTour
    Inherits System.Web.UI.Page
    Public Event TourSelected()

    Public Event Finished()

    Private m_nBuyerID As Integer
    Private Property BuyerID() As Integer
        Get
            Return m_nBuyerID
        End Get
        Set(ByVal value As Integer)
            m_nBuyerID = value
        End Set
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        ' Local Vars
        Dim nCount As Integer = 0
        Dim nColumnCount As Integer
        Dim nScratch As Integer
        Dim CDataAccess As New ClassDataAccess

        ' Init Header
        If BuyerID > 0 Then

            ' Update Header
            LabelHeader.Text = "Create Client Tour for " & CDataAccess.BuyerName(BuyerID)

        Else

            ' Default Header
            LabelHeader.Text = "Create Client Tour"

        End If

        '' Populate Status - Hardcoded Language for now
        'DropDownListStatus.DataSource = CDataAccess.PropertyStatus(1)
        'DropDownListStatus.DataValueField = "id"
        'DropDownListStatus.DataTextField = "text"        
        'DropDownListStatus.DataBind()
        'DropDownListStatus.Items.Insert(0, "-- Any --")

        ' Populate Type - Hardcoded Language for now
        DropDownListType.DataSource = CDataAccess.PropertyTypes(1)
        DropDownListType.DataValueField = "id"
        DropDownListType.DataTextField = "text"
        DropDownListType.DataBind()
        DropDownListType.Items.Insert(0, "-- Any --")

        ' FEATURES

        ' Get the Features Available
        Dim dtDataTable As DataTable = CDataAccess.Features

        ' Get the Column Count
        nColumnCount = Math.Ceiling(dtDataTable.Rows.Count / 5)

        ' For each Row Returned
        For Each dr As DataRow In dtDataTable.Rows

            ' Increment Counter
            nCount += 1

            ' Add a CheckBox
            Dim chkFeature As New CheckBox

            ' Add Feature
            chkFeature.ID = dr("id").ToString
            chkFeature.Text = dr("text").ToString.Trim

            ' Depending on the Column
            If nCount > 0 And nCount <= nColumnCount Then
                ColumnFeatures1.Controls.Add(chkFeature)
                ColumnFeatures1.Controls.Add(New LiteralControl("<br/>"))
            ElseIf nCount > nColumnCount And nCount <= (nColumnCount * 2) Then
                ColumnFeatures2.Controls.Add(chkFeature)
                ColumnFeatures2.Controls.Add(New LiteralControl("<br/>"))
            ElseIf nCount > (nColumnCount * 2) And nCount <= (nColumnCount * 3) Then
                ColumnFeatures3.Controls.Add(chkFeature)
                ColumnFeatures3.Controls.Add(New LiteralControl("<br/>"))
            ElseIf nCount > (nColumnCount * 3) And nCount <= (nColumnCount * 4) Then
                ColumnFeatures4.Controls.Add(chkFeature)
                ColumnFeatures4.Controls.Add(New LiteralControl("<br/>"))
            Else
                ColumnFeatures5.Controls.Add(chkFeature)
                ColumnFeatures5.Controls.Add(New LiteralControl("<br/>"))
            End If

        Next

        ' Tidy
        CDataAccess = Nothing

        ' Add Minimum Bedrooms and Bathrooms
        For nScratch = 0 To 5
            DropDownListMinBathrooms.Items.Add(nScratch)
            DropDownListMinBedrooms.Items.Add(nScratch)
        Next

        '' For each Month
        'For nScratch = 1 To 12

        '    ' Add the Month to the List
        '    DropDownListDateFromMonth.Items.Add(MonthName(nScratch))
        '    DropDownListDateToMonth.Items.Add(MonthName(nScratch))

        'Next

        '' Add Years, last Year, this Year and Next
        'DropDownListDateFromYear.Items.Add(DateAdd(DateInterval.Year, -1, Now).Year)
        'DropDownListDateToYear.Items.Add(DateAdd(DateInterval.Year, -1, Now).Year)
        'DropDownListDateFromYear.Items.Add(Now.Year)
        'DropDownListDateToYear.Items.Add(Now.Year)
        'DropDownListDateFromYear.Items.Add(DateAdd(DateInterval.Year, 1, Now).Year)
        'DropDownListDateToYear.Items.Add(DateAdd(DateInterval.Year, 1, Now).Year)

        '' Set the Date Range as a Month either side of Today
        'Dim dateFrom As Date = DateAdd(DateInterval.Year, -1, Today)
        'Dim dateTo As Date = Today

        '' Set the Form Fields
        'DropDownListDateFromYear.SelectedValue = dateFrom.Year
        'DropDownListDateFromMonth.SelectedIndex = dateFrom.Month - 1
        'DropDownListDateToYear.SelectedValue = dateTo.Year
        'DropDownListDateToMonth.SelectedIndex = dateTo.Month - 1

        '' Populate the Number of Days in this Month
        'PopulateDaysOfMonth(DropDownListDateFromDay, DropDownListDateFromMonth, DropDownListDateFromYear)
        'PopulateDaysOfMonth(DropDownListDateToDay, DropDownListDateToMonth, DropDownListDateToYear)

        '' Set the Day
        'DropDownListDateFromDay.SelectedValue = dateFrom.Day
        'DropDownListDateToDay.SelectedValue = dateTo.Day

        ' Load Areas Containing Properties Only and adding ALL Option
        AdminLocation1.ContainingPropertiesOnly = True
        AdminLocation1.AddAllOption = True
        AdminLocation1.InitData()

    End Sub

    Public Sub InitBuyer(ByVal nBuyerID As Integer)

        ' Assign to Property
        BuyerID = nBuyerID

    End Sub

    'Private Sub PopulateDaysOfMonth(ByRef ddlDay As DropDownList, ByVal ddlMonth As DropDownList, ByVal ddlYear As DropDownList)

    '    ' Local Vars
    '    Dim nCurrentIndex As Integer = -1

    '    ' If we have a Current Selection
    '    If ddlDay.SelectedValue <> String.Empty Then

    '        ' Store the Current Selection
    '        nCurrentIndex = ddlDay.SelectedIndex

    '    End If

    '    ' Clear the Current List
    '    ddlDay.Items.Clear()

    '    ' For each Day in this Month
    '    For nDay As Integer = 1 To DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), ddlMonth.SelectedIndex + 1)

    '        ' Add Value
    '        ddlDay.Items.Add(nDay.ToString.Trim)

    '    Next

    '    ' If we Stored a Previous Value
    '    If nCurrentIndex > -1 Then

    '        ' Try and Restore the Value - if the Value Exists
    '        If ddlDay.Items.Count > nCurrentIndex Then

    '            ' Restore Value
    '            ddlDay.SelectedIndex = nCurrentIndex

    '        Else

    '            ' Set to Month Max
    '            ddlDay.SelectedIndex = ddlDay.Items.Count - 1

    '        End If

    '    End If

    'End Sub

    'Private Function CheckDateRangeError() As Boolean

    '    ' Get Dates
    '    Dim dtDateFrom As Date = New DateTime(Convert.ToInt32(DropDownListDateFromYear.SelectedValue), DropDownListDateFromMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListDateFromDay.SelectedValue))
    '    Dim dtDateTo As Date = New DateTime(Convert.ToInt32(DropDownListDateToYear.SelectedValue), DropDownListDateToMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListDateToDay.SelectedValue))

    '    ' Return Date Error
    '    Return dtDateFrom > dtDateTo

    'End Function

    'Private Sub AdjustDate(ByVal bFromDate As Boolean)

    '    ' If we are Adjusting the From Date
    '    If bFromDate Then

    '        ' From Date
    '        DropDownListDateFromYear.SelectedIndex = DropDownListDateToYear.SelectedIndex
    '        DropDownListDateFromMonth.SelectedIndex = DropDownListDateToMonth.SelectedIndex
    '        DropDownListDateFromDay.SelectedIndex = DropDownListDateToDay.SelectedIndex

    '    Else

    '        ' To Date
    '        DropDownListDateToYear.SelectedIndex = DropDownListDateFromYear.SelectedIndex
    '        DropDownListDateToMonth.SelectedIndex = DropDownListDateFromMonth.SelectedIndex
    '        DropDownListDateToDay.SelectedIndex = DropDownListDateFromDay.SelectedIndex

    '    End If

    'End Sub

    'Protected Sub DropDownListDateFromMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateFromMonth.SelectedIndexChanged

    '    ' Populate Drop Down with Days of the Month
    '    PopulateDaysOfMonth(DropDownListDateFromDay, DropDownListDateFromMonth, DropDownListDateFromYear)

    '    ' Check if we have a Date Error, if so, Adjust
    '    If CheckDateRangeError() Then
    '        AdjustDate(False)
    '    End If

    'End Sub

    'Protected Sub DropDownListDateFromYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateFromYear.SelectedIndexChanged

    '    ' Populate Drop Down with Days of the Month
    '    PopulateDaysOfMonth(DropDownListDateFromDay, DropDownListDateFromMonth, DropDownListDateFromYear)

    '    ' Check if we have a Date Error, if so, Adjust
    '    If CheckDateRangeError() Then
    '        AdjustDate(False)
    '    End If

    'End Sub

    'Protected Sub DropDownListDateToMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateToMonth.SelectedIndexChanged

    '    ' Populate Drop Down with Days of the Month
    '    PopulateDaysOfMonth(DropDownListDateToDay, DropDownListDateToMonth, DropDownListDateToYear)

    '    ' Check if we have a Date Error, if so, Adjust
    '    If CheckDateRangeError() Then
    '        AdjustDate(True)
    '    End If

    'End Sub

    'Protected Sub DropDownListDateToYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateToYear.SelectedIndexChanged

    '    ' Populate Drop Down with Days of the Month
    '    PopulateDaysOfMonth(DropDownListDateToDay, DropDownListDateToMonth, DropDownListDateToYear)

    '    ' Check if we have a Date Error, if so, Adjust
    '    If CheckDateRangeError() Then
    '        AdjustDate(True)
    '    End If

    'End Sub

    'Protected Sub DropDownListDateFromDay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateFromDay.SelectedIndexChanged

    '    ' Check if we have a Date Error, if so, Adjust
    '    If CheckDateRangeError() Then
    '        AdjustDate(False)
    '    End If

    'End Sub

    'Protected Sub DropDownListDateToDay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateToDay.SelectedIndexChanged

    '    ' Check if we have a Date Error, if so, Adjust
    '    If CheckDateRangeError() Then
    '        AdjustDate(True)
    '    End If

    'End Sub

    Private Function GetDDLValue(ByVal ddl As DropDownList) As Integer

        ' If we have a Value Selected
        If ddl.SelectedIndex > 0 Then

            ' Return the Result
            Return Convert.ToInt32(ddl.SelectedValue)

        Else

            ' Return NULL
            Return 0

        End If

    End Function

    Private Function GetTBValue(ByVal tb As TextBox) As Integer

        ' If we have a Value
        If tb.Text.Trim = String.Empty Then

            ' Return NULL
            Return 0

        Else

            ' Return Value
            Return Convert.ToInt32(tb.Text.Trim)

        End If

    End Function

    Private Sub LoadPageNumbers()

        ' If we have more than 25 Results
        If DirectCast(Session("AdminClientTourPropertySearchFilteredResults"), DataTable).Rows.Count > 25 Then

            ' Clear Existing
            DropDownListPage.Items.Clear()

            ' Populate Page Numbering
            For nPage As Integer = 1 To Math.Ceiling(Convert.ToDouble(DirectCast(Session("AdminClientTourPropertySearchFilteredResults"), DataTable).Rows.Count / 25))

                ' Add Page
                DropDownListPage.Items.Add("Page " & nPage.ToString.Trim)

            Next

        End If

    End Sub

    Private Function GetFeatureSelection(ByVal szDelim As String, ByRef ctrlParent As Control) As String

        ' Local Vars
        Dim szRetVal As String = String.Empty

        ' For each CheckBox in the Control
        For Each ctrl As Control In ctrlParent.Controls

            ' If this is a Checkbox
            If TypeOf (ctrl) Is CheckBox Then

                ' If this is Checked
                If DirectCast(ctrl, CheckBox).Checked Then

                    ' Apply Filter
                    szRetVal &= szDelim & "(Features LIKE '*" & ctrl.ID.ToString.Trim & "*')"

                End If

            End If

        Next

        ' Return the Result
        Return szRetVal

    End Function

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

        ' Check we have Required Variable Loaded
        If Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Hide the Finish Button
            ButtonFinish.Visible = False

            ' If we have Results
            If DirectCast(Session("AdminClientTourPropertySearchAllResults"), DataTable).Rows.Count > 0 Then

                ' Local Vars
                Dim szDelim As String = String.Empty

                ' Get the Results as a DataView
                Dim dv As New DataView(DirectCast(Session("AdminClientTourPropertySearchAllResults"), DataTable))

                '' Local Vars
                'Dim CDataAccess As New ClassDataAccess

                '' CREATED
                'dv.RowFilter = "(Created >= " & CDataAccess.SQLDateTime(New DateTime(Convert.ToInt32(DropDownListDateFromYear.SelectedValue), DropDownListDateFromMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListDateFromDay.SelectedValue))) & ")"
                'dv.RowFilter &= szDelim & "(Created <= " & CDataAccess.SQLDateTime(New DateTime(Convert.ToInt32(DropDownListDateToYear.SelectedValue), DropDownListDateToMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListDateToDay.SelectedValue))) & ")"

                '' Tidy
                'CDataAccess = Nothing

                ' REFERENCE
                If TextBoxReference.Text.Trim <> String.Empty Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Reference = '" & TextBoxReference.Text.Trim & "') or (ExtReference = '" & TextBoxReference.Text.Trim & "')"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                '' STATUS
                'If DropDownListStatus.SelectedIndex > 0 Then

                '    ' Apply Filter
                '    dv.RowFilter &= szDelim & "(Status = '" & DropDownListStatus.SelectedItem.Text.Trim & "')"

                'End If

                ' TYPE
                If DropDownListType.SelectedIndex > 0 Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Type = '" & DropDownListType.SelectedItem.Text.Trim & "')"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                ' COUNTRY
                If AdminLocation1.CountryID > 0 Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Country = '" & AdminLocation1.CountryName.Trim & "')"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                ' AREA
                If AdminLocation1.RegionID > 0 Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Area = '" & AdminLocation1.RegionName.Trim & "')"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                ' TOWN
                If AdminLocation1.AreaID > 0 Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Town = '" & AdminLocation1.AreaName.Trim & "')"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                ' VILLAGE
                If AdminLocation1.SubAreaID > 0 Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Village = '" & AdminLocation1.SubAreaName.Trim & "')"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                ' MIN BEDROOMS
                If DropDownListMinBedrooms.SelectedIndex > 0 Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Bedrooms >= " & DropDownListMinBedrooms.SelectedIndex.ToString.Trim & ")"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                ' MIN BATHROOMS
                If DropDownListMinBathrooms.SelectedIndex > 0 Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Bathrooms >= " & DropDownListMinBathrooms.SelectedIndex.ToString.Trim & ")"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                ' FEATURES
                If TableRowFeatures.Visible Then

                    ' Get Feature Selection from each Column
                    dv.RowFilter &= GetFeatureSelection(szDelim, ColumnFeatures1)
                    dv.RowFilter &= GetFeatureSelection(szDelim, ColumnFeatures2)
                    dv.RowFilter &= GetFeatureSelection(szDelim, ColumnFeatures3)
                    dv.RowFilter &= GetFeatureSelection(szDelim, ColumnFeatures4)
                    dv.RowFilter &= GetFeatureSelection(szDelim, ColumnFeatures5)

                End If

                ' MIN PRICE
                If TextBoxPriceFrom.Text.Trim <> String.Empty Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Price >= " & Convert.ToInt32(TextBoxPriceFrom.Text.Trim) & ")"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                ' MAX PRICE
                If TextBoxPriceTo.Text.Trim <> String.Empty Then

                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(Price <= " & Convert.ToInt32(TextBoxPriceTo.Text.Trim) & ")"

                    ' Update Delimiter
                    szDelim = " and "

                End If

                If txtminplotsize.Text.Trim <> String.Empty Then
                    ' Apply Filter
                    dv.RowFilter &= szDelim & "(SQM_Plot >= " & Convert.ToInt32(txtminplotsize.Text.Trim) & ")"

                    ' Update Delimiter
                    szDelim = " and "
                End If

                ' Apply Results
                Session("AdminClientTourPropertySearchFilteredResults") = dv.ToTable

                ' Load Page Numbers
                LoadPageNumbers()

                ' Populate the Results
                SortPrice()

            End If

        End If

    End Sub

    Private Sub Sort(ByVal szField As String)

        ' Check Session hasn't expired
        If Session("AdminClientTourPropertySearchFilteredResults") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Get the Results as a DataView
            Dim dv As New DataView(DirectCast(Session("AdminClientTourPropertySearchFilteredResults"), DataTable))

            ' Sort the Results
            dv.Sort = szField & " ASC"

            ' Write back to Memory
            Session("AdminClientTourPropertySearchFilteredResults") = dv.ToTable

            ' Populate Results
            Update()

        End If

    End Sub

    Private Sub PopulateResults()

        ' Display only if we have Filtered Results
        If Not Session("AdminClientTourPropertySearchFilteredResults") Is Nothing Then

            ' Local Vars
            Dim nCounter As Integer = 0
            Dim bDisplay As Boolean
            Dim CUtilities As New ClassUtilities
            Dim dtResults As DataTable = DirectCast(Session("AdminClientTourPropertySearchFilteredResults"), DataTable)
            Dim bPaging As Boolean = dtResults.Rows.Count > 25

            ' If Page Numbering not Loaded, Load
            If DropDownListPage.Items.Count < 1 Then
                LoadPageNumbers()
            End If

            ' Removing Previous Results
            UpdatePanelAdminClientTourPropertySearchResults.ContentTemplateContainer.Controls.Clear()

            ' If we have Results
            If dtResults.Rows.Count > 0 Then

                ' Create a New Control
                Dim ctrlResultsHeader As ASP.controlsnew_webusercontroladminpropertysearchresultsheader_ascx = CType(LoadControl("~/ControlsNew/WebUserControlAdminPropertySearchResultsHeader.ascx"), ASP.controlsnew_webusercontroladminpropertysearchresultsheader_ascx)

                ' Define an ID
                ctrlResultsHeader.ID = "AdminPropertySearchResultsHeader1"

                ' Add Handler
                AddHandler ctrlResultsHeader.SortArea, AddressOf SortArea
                AddHandler ctrlResultsHeader.SortBathrooms, AddressOf SortBathrooms
                AddHandler ctrlResultsHeader.SortBedrooms, AddressOf SortBedrooms
                AddHandler ctrlResultsHeader.SortCreated, AddressOf SortCreated
                AddHandler ctrlResultsHeader.SortPrice, AddressOf SortPrice
                AddHandler ctrlResultsHeader.SortReference, AddressOf SortReference
                AddHandler ctrlResultsHeader.SortRegion, AddressOf SortRegion
                'AddHandler ctrlResultsHeader.SortStatus, AddressOf SortStatus
                AddHandler ctrlResultsHeader.SortSubArea, AddressOf SortSubArea
                AddHandler ctrlResultsHeader.SortType, AddressOf SortType

                ' Add to the Form
                UpdatePanelAdminClientTourPropertySearchResults.ContentTemplateContainer.Controls.Add(ctrlResultsHeader)

                ' For each Result
                For Each dr As DataRow In dtResults.Rows

                    ' Increment the Counter
                    nCounter += 1

                    ' If Paging
                    If bPaging Then

                        ' If it is this Page we are looking at
                        bDisplay = nCounter > ((DropDownListPage.SelectedIndex) * 25) And nCounter <= ((DropDownListPage.SelectedIndex + 1) * 25)

                    Else

                        ' Not Paging so Display
                        bDisplay = True

                    End If

                    ' If Displaying
                    If bDisplay Then

                        ' Create a New Control
                        Dim ctrlResult As ASP.controlsnew_webusercontroladminpropertysearchresult_ascx = CType(LoadControl("~/ControlsNew/WebUserControlAdminPropertySearchResult.ascx"), ASP.controlsnew_webusercontroladminpropertysearchresult_ascx)

                        ' Define an ID
                        ctrlResult.ID = "AdminPropertySearchResult" & nCounter.ToString.Trim

                        ' Set Status
                        ctrlResult.SetStatus(DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList).Contains(Convert.ToInt32(dr(0).ToString.Trim)), DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList).Count > 9)

                        ' Add Handler
                        AddHandler ctrlResult.AddRemove, AddressOf Update

                        ' Init Data
                        ctrlResult.InitData(CUtilities, dr)

                        ' Add to the Form
                        UpdatePanelAdminClientTourPropertySearchResults.ContentTemplateContainer.Controls.Add(ctrlResult)

                    End If

                Next

                ' Tidy
                CUtilities = Nothing

            Else

                ' Inform the User
                TableNoResults.Visible = True

            End If

            ' Display / Hide ControlsNew
            DropDownListPage.Visible = bPaging

        End If

    End Sub

    Private Sub Update()

        ' Check Session still Active
        If Session("AdminClientTourPropertiesSelected") Is Nothing Then

            ' Create Array
            Session("AdminClientTourPropertiesSelected") = New ArrayList

        End If

        ' Depending on the Count
        Select Case DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList).Count

            Case 0
                ' Hide the Links
                LinkButtonPropertiesSelected.Visible = False
                HyperLink3Card.Visible = False

            Case 1
                ' Set Text
                LinkButtonPropertiesSelected.Text = "1 Property Selected"

                ' Show the Links
                LinkButtonPropertiesSelected.Visible = True
                HyperLink3Card.Visible = True

            Case Else
                ' Set Text
                LinkButtonPropertiesSelected.Text = DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList).Count.ToString.Trim & " Properties Selected"

                ' Show the Links
                LinkButtonPropertiesSelected.Visible = True
                HyperLink3Card.Visible = True

        End Select

        ' Populate Results
        PopulateResults()

    End Sub

    Private Sub SortArea()
        Sort("Town")
    End Sub

    Private Sub SortBathrooms()
        Sort("Bathrooms")
    End Sub

    Private Sub SortBedrooms()
        Sort("Bedrooms")
    End Sub

    Private Sub SortCreated()
        Sort("Created")
    End Sub

    Private Sub SortPrice()
        Sort("Price")
    End Sub

    Private Sub SortReference()
        Sort("Reference")
    End Sub

    Private Sub SortRegion()
        Sort("Area")
    End Sub

    'Private Sub SortStatus()
    '    Sort("Status")
    'End Sub

    Private Sub SortSubArea()
        Sort("Village")
    End Sub

    Private Sub SortType()
        Sort("Type")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Remove("ClientTourID")
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        ' If we have no Search Results
        If Session("AdminClientTourPropertySearchAllResults") Is Nothing Then

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Get the Results of the Search
            Session("AdminClientTourPropertySearchAllResults") = CDataAccess.PropertyAdvancedSearch(Convert.ToInt32(Session("ContactPartnerID")), , , , 2)

            ' Tidy
            CDataAccess = Nothing

        End If

        ' Populate Previous
        Update()

        ' Hide No Results Message
        TableNoResults.Visible = False

    End Sub

    Protected Sub DropDownListPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPage.SelectedIndexChanged

        ' Populate Previous
        Update()

    End Sub

    Protected Sub LinkButtonPropertiesSelected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonPropertiesSelected.Click

        ' Check Session hasn't expired
        If Session("AdminClientTourPropertySearchAllResults") Is Nothing Or Session("AdminClientTourPropertiesSelected") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' If we have Selected Properties
            If DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList).Count > 0 Then

                ' Local Vars
                Dim szDelim As String = String.Empty

                ' Get the Results as a DataView
                Dim dv As New DataView(DirectCast(Session("AdminClientTourPropertySearchAllResults"), DataTable))

                ' For each Property Selected
                For Each nID In DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList)

                    ' Add to Filter
                    dv.RowFilter &= szDelim & "id = " & nID.ToString.Trim

                    ' Define Delimiter
                    szDelim = " or "

                Next

                ' Write back to Memory
                Session("AdminClientTourPropertySearchFilteredResults") = dv.ToTable

                ' Populate Results
                Update()

                ' Display the Finish Button
                ButtonFinish.Visible = True

            End If

        End If

    End Sub

    Protected Sub ButtonFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFinish.Click

        ' Clear Search Results
        Session("AdminClientTourPropertySearchAllResults") = Nothing
        Session("AdminClientTourPropertySearchFilteredResults") = Nothing

        ' If this is being Initialised to a Buyer
        If BuyerID > 0 Then

            ' Set Session Variable
            Session("AdminCreateTourBuyerID") = BuyerID
        End If

        ' Raise Event
        Response.Redirect("Reports.aspx")
        ' RaiseEvent Finished()

    End Sub

    Protected Sub LinkButtonFeatures_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonFeatures.Click

        ' Toggle Features Visibility
        TableRowFeatures.Visible = Not TableRowFeatures.Visible

    End Sub

    Public Sub Reload()

        LoadControlValues(Me)

    End Sub

End Class
