Imports System.Data
Imports ClassHistory

Partial Class WebUserControlAdminPropertySearch
    Inherits System.Web.UI.UserControl

    Public Event PropertySelected()

    Private Sub PopulateFilter(ByRef ddl As DropDownList, ByVal dtDataTable As DataTable, ByVal nColumnIndex As Integer)

        ' Local Vars
        Dim lstAdded As New SortedList
        Dim nIndex As Integer = 0

        ' For each Row
        For Each dr As DataRow In dtDataTable.Rows

            ' Do not Add NULL Strings
            If dr(nColumnIndex).ToString.Trim <> String.Empty Then

                ' If we haven't already added this Value
                If Not lstAdded.Contains(dr(nColumnIndex).ToString.Trim) Then

                    ' Increment Index
                    nIndex += 1

                    ' Add this to the Added Array
                    lstAdded.Add(dr(nColumnIndex).ToString.Trim, nIndex)

                End If

            End If

        Next

        ' Clear Existing
        ddl.Items.Clear()

        ' Add Any Option
        ddl.Items.Add("-- Any --")

        ' For each Dictionary Entry in the Sorted List
        For Each de As DictionaryEntry In lstAdded

            ' Add this to the Drop Down List
            ddl.Items.Add(de.Key)

        Next

    End Sub

    Private Sub PopulateAreasInCountry()

        ' Clear Existing Entries
        DropDownListArea.Items.Clear()

        ' Get the Results as a DataView
        Dim dv As New DataView(DirectCast(Session("PropertyAdminPropertySearchResults"), DataTable))

        ' Apply the Filter
        dv.RowFilter = "Country = 'Spain'"

        ' Apply Sort
        dv.Sort = "Area"

        ' For each Row Returned
        For Each dr As DataRow In dv.ToTable(True, "Area").Rows

            ' Add this to the Drop Down
            DropDownListArea.Items.Add(dr("Area"))

        Next

        ' Tidy
        dv.Dispose()

        ' Add Any
        DropDownListArea.Items.Insert(0, "-- Any --")

        ' Init Towns
        PopulateTownsInArea()

    End Sub

    Private Sub PopulateTownsInArea()

        ' Clear Existing Entries
        DropDownListTown.Items.Clear()

        ' Get the Results as a DataView
        Dim dv As New DataView(DirectCast(Session("PropertyAdminPropertySearchResults"), DataTable))

        ' Apply the Filter
        dv.RowFilter = "Area = '" & DropDownListArea.SelectedValue.Trim & "'"

        ' Apply Sort
        dv.Sort = "Town"

        ' For each Row Returned
        For Each dr As DataRow In dv.ToTable(True, "Town").Rows

            ' Add this to the Drop Down
            DropDownListTown.Items.Add(dr("Town"))

        Next

        ' Tidy
        dv.Dispose()

        ' Add Any
        DropDownListTown.Items.Insert(0, "-- Any --")

    End Sub

    Private Sub InitFilter(ByRef ddl As DropDownList)

        ' Init DDL
        ddl.Items.Clear()
        ddl.Items.Add("-- Any --")

    End Sub

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

        ' If we don't have a Contact Partner ID
        If Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Agent Login Page
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars            
            Dim CDataAccess As New ClassDataAccess
            Dim nPropertyID As Integer = 0

            ' Clear Previous Results
            Session("PropertyAdminPropertySearchResults") = Nothing

            ' If we have neither a Reference nor an Address
            If TextBoxReference.Text.Trim = String.Empty And TextBoxAddress.Text.Trim = String.Empty Then

                ' Init to All Properties
                nPropertyID = -1

            End If

            ' If we just have a Reference
            If TextBoxReference.Text.Trim <> String.Empty And TextBoxAddress.Text.Trim = String.Empty Then

                ' Clear the Address Field to avoid Confusion
                TextBoxAddress.Text = String.Empty

                ' Get the Property ID that pertains to the Property Reference Entered 

                ' Is this an Admin User
                If Convert.ToBoolean(Session("AdminUser")) Then

                    ' Use any Ref
                    nPropertyID = CDataAccess.PropertyID(TextBoxReference.Text.Trim, -1, True)

                Else

                    ' Use Partner Refs
                    nPropertyID = CDataAccess.PropertyID(TextBoxReference.Text.Trim, Convert.ToInt32(Session("ContactPartnerID")), True)

                End If

            End If

            ' If no Result and we have an Address
            If nPropertyID = 0 And TextBoxAddress.Text.Trim <> String.Empty Then

                ' Clear the Reference Field to avoid Confusion
                TextBoxReference.Text = String.Empty

                ' Local Vars
                Dim CUtilities As New ClassUtilities

                ' Get Search Results
                Dim dtDataTable As DataTable = CDataAccess.PropertySearch(TextBoxAddress.Text.Trim, Convert.ToInt32(Session("ContactPartnerID")))

                ' Loop through each of the Results
                For Each dr As DataRow In dtDataTable.Rows

                    ' Format the Price
                    dr("Price") = CUtilities.FormatPrice(Convert.ToInt32(dr("Price")))

                Next

                ' Tidy
                CUtilities = Nothing

                ' Assign Results to Session Variable
                Session("PropertyAdminPropertySearchResults") = dtDataTable

            Else

                ' If we have a Result
                If nPropertyID <> 0 Then

                    ' Local Vars
                    Dim CUtilities As New ClassUtilities

                    ' Get Search Results
                    Dim dtDataTable As DataTable = CDataAccess.PropertySearch(nPropertyID, Convert.ToInt32(Session("ContactPartnerID")))

                    ' Loop through each of the Results
                    For Each dr As DataRow In dtDataTable.Rows

                        ' Format the Price
                        dr("Price") = CUtilities.FormatPrice(Convert.ToInt32(dr("Price")))

                    Next

                    ' Tidy
                    CUtilities = Nothing

                    ' Assign Results to Session Variable
                    Session("PropertyAdminPropertySearchResults") = dtDataTable

                End If

            End If

            ' Tidy
            CDataAccess = Nothing

            ' Check if we have Results
            If Session("PropertyAdminPropertySearchResults") Is Nothing Then

                ' Hide the GridView
                GridViewResults.Visible = False

                ' Display the Label
                LabelNoResults.Visible = True

            ElseIf DirectCast(Session("PropertyAdminPropertySearchResults"), DataTable).Rows.Count < 1 Then

                ' Hide the GridView
                GridViewResults.Visible = False

                ' Display the Label
                LabelNoResults.Visible = True

            Else

                ' Populate Filters
                PopulateFilters()

                ' Apply Filters
                ApplyFilters()

            End If

            ' Apply Styling
            ApplyStyling()
            DropDownListCountry_SelectedIndexChanged(DropDownListCountry, e)
        End If

    End Sub

    'Private Sub AddHistory()

    '    ' Adding History Point
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("TextBoxReference.Text", TextBoxReference.Text)
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("TextBoxAddress.Text", TextBoxAddress.Text)
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("DropDownListType.SelectedValue", DropDownListType.SelectedValue)
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("DropDownListCountry.SelectedValue", DropDownListCountry.SelectedValue)
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("DropDownListArea.SelectedValue", DropDownListArea.SelectedValue)
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("DropDownListTown.SelectedValue", DropDownListTown.SelectedValue)
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("DropDownListBedrooms.SelectedValue", DropDownListBedrooms.SelectedValue)
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("DropDownListBathrooms.SelectedValue", DropDownListBathrooms.SelectedValue)
    '    ScriptManager.GetCurrent(Parent.Page).AddHistoryPoint("DropDownListStatus.SelectedValue", DropDownListStatus.SelectedValue)

    'End Sub

    Private Sub PopulateFilters()

        If Not Session("PropertyAdminPropertySearchResults") Is Nothing Then

            PopulateFilter(DropDownListCountry, DirectCast(Session("PropertyAdminPropertySearchResults"), DataTable), 7)
            InitFilter(DropDownListArea)
            InitFilter(DropDownListTown)
            PopulateFilter(DropDownListStatus, DirectCast(Session("PropertyAdminPropertySearchResults"), DataTable), 12)
            PopulateFilter(DropDownListType, DirectCast(Session("PropertyAdminPropertySearchResults"), DataTable), 6)

        End If

        ' Display Filters
        TableRowFilters.Visible = Not Session("PropertyAdminPropertySearchResults") Is Nothing

    End Sub

    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged

        '' Save as Previous
        'Session("AdminPreviousControl") = Me        

        ' Local Vars
        Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))

        ' Load this Property's Details
        Dim CDataAccess As New ClassDataAccess
        CProperty.Load(Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim))
        CDataAccess = Nothing

        ' Assign to Session Variable
        Session("AdminPropertySelected") = CProperty

        ' Set Session
        Session("AdminLoadPropertySearchResults") = True

        ' Raise Event
        RaiseEvent PropertySelected()

    End Sub

    Protected Sub GridViewResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridViewResults.Sorting

        ' Check to see if the Sort Field is the Same
        If Session("PropertyAdminPropertySearchSortField") = e.SortExpression Then

            ' Toggle Sort
            If Session("PropertyAdminPropertySearchSortOrder") = "Desc" Then
                Session("PropertyAdminPropertySearchSortOrder") = "Asc"
            Else
                Session("PropertyAdminPropertySearchSortOrder") = "Desc"
            End If

        Else

            ' New Sort Field, Set Field and Init to Ascending
            Session("PropertyAdminPropertySearchSortField") = e.SortExpression
            Session("PropertyAdminPropertySearchSortOrder") = "Asc"

        End If

        ' Apply Filters
        ApplyFilters()

        ' Apply Styling
        ApplyStyling()

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Add Bedroom and Bathroom Filters
        For nIndex = 1 To 5

            ' Add to Filters
            DropDownListBedrooms.Items.Add(nIndex.ToString.Trim & "+")
            DropDownListBathrooms.Items.Add(nIndex.ToString.Trim & "+")

        Next

        ' Add Any Option
        DropDownListBedrooms.Items.Insert(0, "-- Any --")
        DropDownListBathrooms.Items.Insert(0, "-- Any --")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If we had Previous Results
        If Not Session("AdminLoadPropertySearchResults") Is Nothing Then

            Session("AdminLoadPropertySearchResults") = Nothing

            '' Populate Filters
            'PopulateFilters()

            '' Init Results
            'GridViewResults.DataSource = Session("AdminPropertySearchResults")
            'GridViewResults.DataBind()

            '' Apply Styling
            'ApplyStyling()

            '' Hide / Display Filters
            'TableRowFilters.Visible = GridViewResults.Rows.Count > 1

        End If

        If Not Page.IsPostBack Then

            ' Init Sorting Params
            Session("PropertyAdminPropertySearchSortField") = ""
            Session("PropertyAdminPropertySearchSortOrder") = "Desc"

        End If

        ' Set Focus
        'TextBoxReference.Focus()

    End Sub

    Protected Sub DropDownListArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListArea.SelectedIndexChanged
        PopulateTownsInArea()
        ApplyFilters()
        ApplyStyling()
    End Sub

    Protected Sub DropDownListStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListStatus.SelectedIndexChanged
        ApplyFilters()
        ApplyStyling()
    End Sub

    Protected Sub DropDownListTown_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListTown.SelectedIndexChanged
        ApplyFilters()
        ApplyStyling()
    End Sub

    Protected Sub DropDownListBedrooms_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListBedrooms.SelectedIndexChanged
        ApplyFilters()
        ApplyStyling()
    End Sub

    Protected Sub DropDownListBathrooms_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListBathrooms.SelectedIndexChanged
        ApplyFilters()
        ApplyStyling()
    End Sub

    Protected Sub DropDownListType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListType.SelectedIndexChanged
        ApplyFilters()
        ApplyStyling()
    End Sub

    Private Sub ApplyFilters()

        ' Get the Intial Data
        Dim dtDataTable As DataTable = DirectCast(Session("PropertyAdminPropertySearchResults"), DataTable)
        Dim dvDataView As DataView = New DataView(dtDataTable)
        Dim szDelim As String = String.Empty

        ' Init Filter
        dvDataView.RowFilter = String.Empty

        ' Country
        If DropDownListCountry.SelectedIndex > 0 Then

            ' Filter Results
            dvDataView.RowFilter = "Country='Spain'"

            ' Set Delimiter
            szDelim = " and "

        End If

        ' Area
        If DropDownListArea.SelectedIndex > 0 Then

            ' Filter Results
            dvDataView.RowFilter = "Area='" & DropDownListArea.SelectedValue & "'"

            ' Set Delimiter
            szDelim = " and "

        End If

        ' Status
        If DropDownListStatus.SelectedIndex > 0 Then

            ' Filter Results
            dvDataView.RowFilter &= szDelim & "Status='" & DropDownListStatus.SelectedValue & "'"

            ' Set Delimiter
            szDelim = " and "

        End If

        ' Town
        If DropDownListTown.SelectedIndex > 0 Then

            ' Filter Results
            dvDataView.RowFilter &= szDelim & "Town='" & DropDownListTown.SelectedItem.ToString.Trim & "'"

            ' Set Delimiter
            szDelim = " and "

        End If

        ' Bedrooms
        If DropDownListBedrooms.SelectedIndex > 0 Then

            ' Filter Results
            dvDataView.RowFilter &= szDelim & "Beds>" & (DropDownListBedrooms.SelectedIndex - 1).ToString.Trim

            ' Set Delimiter
            szDelim = " and "

        End If

        ' Bathrooms
        If DropDownListBathrooms.SelectedIndex > 0 Then

            ' Filter Results
            dvDataView.RowFilter &= szDelim & "Baths>" & (DropDownListBathrooms.SelectedIndex - 1).ToString.Trim

            ' Set Delimiter
            szDelim = " and "

        End If

        ' Type
        If DropDownListType.SelectedIndex > 0 Then

            ' Filter Results
            dvDataView.RowFilter &= szDelim & "Type='" & DropDownListType.SelectedValue & "'"

        End If

        ' If we have Results
        If dvDataView.Table.Rows.Count > 0 Then

            ' Depending on the Sort Direction, Sort
            If Not Session("PropertyAdminPropertySearchSortField") = String.Empty Then

                ' Local Vars
                Dim szSortBy As String

                ' Depending on Sort
                If Session("PropertyAdminPropertySearchSortField").ToString.Trim = "Created" Then

                    ' Creation Date
                    szSortBy = "Create_Date"

                ElseIf Session("PropertyAdminPropertySearchSortField").ToString.Trim = "Price" Then

                    ' Price
                    szSortBy = "public_price"

                Else

                    ' By the Column Title
                    szSortBy = Session("PropertyAdminPropertySearchSortField").ToString.Trim

                End If

                ' Sort
                dvDataView.Sort = szSortBy.Trim & " " & Session("PropertyAdminPropertySearchSortOrder")

            End If

            ' Apply to the GridView
            GridViewResults.DataSource = dvDataView

            ' Bind
            GridViewResults.DataBind()

        End If

    End Sub

    Protected Sub DropDownListCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListCountry.SelectedIndexChanged
        PopulateAreasInCountry()
        ApplyFilters()
        ApplyStyling()
    End Sub

    Private Sub ApplyStyling()

        ' If we have Results
        If Not GridViewResults.HeaderRow Is Nothing Then

            ' Hide the ID and Sorting Columns
            GridViewResults.HeaderRow.Cells(1).Visible = False
            GridViewResults.HeaderRow.Cells(2).Visible = False
            GridViewResults.HeaderRow.Cells(3).Visible = False
            GridViewResults.HeaderRow.Cells(19).Visible = False
            If Convert.ToInt16(Session("ContactPartnerID")) = 3864 Then
                GridViewResults.HeaderRow.Cells(4).Visible = True
            Else
                GridViewResults.HeaderRow.Cells(4).Visible = False

            End If
            GridViewResults.HeaderRow.Cells(8).Visible = False
            ' For each Row
            For Each gvr As GridViewRow In GridViewResults.Rows

                ' Hide the ID and Sorting Columns
                gvr.Cells(1).Visible = False
                gvr.Cells(2).Visible = False
                gvr.Cells(3).Visible = False
                gvr.Cells(19).Visible = False
                If Convert.ToInt16(Session("ContactPartnerID")) = 3864 Then
                    gvr.Cells(4).Visible = True
                Else
                    gvr.Cells(4).Visible = False

                End If
                gvr.Cells(8).Visible = False

            Next

        End If

        ' Apply Colour Coding
        For Each gvr As GridViewRow In GridViewResults.Rows

            ' Depending on the Status
            Select Case gvr.Cells(12).Text.Trim

                Case "New Property"
                    gvr.BackColor = Drawing.Color.Yellow

                Case "Under Offer"
                    gvr.BackColor = Drawing.Color.Green

                Case "Sold", "Withdrawn"
                    gvr.BackColor = Drawing.Color.Red

            End Select
            If gvr.Cells(19).Text.Trim = "Red" Then
                gvr.BackColor = Drawing.Color.Red
            End If
            ' Depending on the Door Key
            Select Case Convert.ToInt32(gvr.Cells(15).Text.Trim)

                Case 1
                    ' We have a Key, Add Image
                    Dim img As New Image
                    img.ImageUrl = "~/Images/Icons/door_key.png"
                    gvr.Cells(15).Controls.Add(img)

                Case Else
                    ' Clear Contents
                    gvr.Cells(15).Text = String.Empty

            End Select

        Next

        ' Update Row Count
        LabelNoOfResults.Text = GridViewResults.Rows.Count.ToString.Trim & " Result(s)"

        ' Set Control Visibilities

        ' Display the Number of Results
        TableRowNoOfResults.Visible = GridViewResults.Rows.Count > 0

        ' Display the GridView
        GridViewResults.Visible = GridViewResults.Rows.Count > 0

        ' Hide the Label
        LabelNoResults.Visible = (GridViewResults.Rows.Count = 0)

    End Sub

    Public Sub Reload()

        ' Populate Filters
        PopulateFilters()

        ' Load Previous Values
        LoadControlValues(Me)

        ' Apply Styling
        ApplyStyling()

    End Sub

End Class
