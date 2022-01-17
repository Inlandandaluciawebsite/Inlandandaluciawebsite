Imports ClassHistory

Partial Class WebUserControlAdminClientTourSearch
    Inherits System.Web.UI.UserControl

    Public Event TourSelected()

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


    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Load the Results
        GridViewResults.DataSource = CDataAccess.ClientTourSearch(GetDDLValue(DropDownListTourID),
                                                                  New DateTime(Convert.ToInt32(DropDownListDateFromYear.SelectedValue), DropDownListDateFromMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListDateFromDay.SelectedValue)),
                                                                  New DateTime(Convert.ToInt32(DropDownListDateToYear.SelectedValue), DropDownListDateToMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListDateToDay.SelectedValue)),
                                                                  GetDDLValue(DropDownListBuyer),
                                                                  GetDDLValue(DropDownListTourWith))
        ' Bind Results
        GridViewResults.DataBind()

        ' Tidy
        CDataAccess = Nothing

        ' Apply Styling
        ApplyStyling()

    End Sub

    Public Sub LoadSearchOptions()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim nScratch As Integer

        ' Populate Tour IDs
        DropDownListTourID.DataSource = CDataAccess.ClientTourIDs
        DropDownListTourID.DataTextField = "text"
        DropDownListTourID.DataValueField = "id"
        DropDownListTourID.DataBind()
        DropDownListTourID.Items.Insert(0, "-- Any --")

        ' For each Month
        For nScratch = 1 To 12

            ' Add the Month to the List
            DropDownListDateFromMonth.Items.Add(MonthName(nScratch))
            DropDownListDateToMonth.Items.Add(MonthName(nScratch))

        Next

        ' Add Years, last Year, this Year and Next
        DropDownListDateFromYear.Items.Add(DateAdd(DateInterval.Year, -1, Now).Year)
        DropDownListDateToYear.Items.Add(DateAdd(DateInterval.Year, -1, Now).Year)
        DropDownListDateFromYear.Items.Add(Now.Year)
        DropDownListDateToYear.Items.Add(Now.Year)
        DropDownListDateFromYear.Items.Add(DateAdd(DateInterval.Year, 1, Now).Year)
        DropDownListDateToYear.Items.Add(DateAdd(DateInterval.Year, 1, Now).Year)

        ' Populate Buyers
        DropDownListBuyer.DataSource = CDataAccess.Buyers
        DropDownListBuyer.DataTextField = "text"
        DropDownListBuyer.DataValueField = "id"
        DropDownListBuyer.DataBind()
        DropDownListBuyer.Items.Insert(0, "-- Any --")

        ' Populate Tour With
        DropDownListTourWith.DataSource = CDataAccess.Users
        DropDownListTourWith.DataTextField = "text"
        DropDownListTourWith.DataValueField = "id"
        DropDownListTourWith.DataBind()
        DropDownListTourWith.Items.Insert(0, "-- Any --")

        ' Tidy
        CDataAccess = Nothing

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Load Search Options
        LoadSearchOptions()

        ' Set the Date Range as a Month either side of Today
        Dim dateFrom As Date = DateAdd(DateInterval.Month, -1, Today)
        Dim dateTo As Date = DateAdd(DateInterval.Month, 1, Today)

        ' Set the Form Fields
        DropDownListDateFromYear.SelectedValue = dateFrom.Year
        DropDownListDateFromMonth.SelectedIndex = dateFrom.Month - 1
        DropDownListDateToYear.SelectedValue = dateTo.Year
        DropDownListDateToMonth.SelectedIndex = dateTo.Month - 1

        ' Populate the Number of Days in this Month
        PopulateDaysOfMonth(DropDownListDateFromDay, DropDownListDateFromMonth, DropDownListDateFromYear)
        PopulateDaysOfMonth(DropDownListDateToDay, DropDownListDateToMonth, DropDownListDateToYear)

        ' Set the Day
        DropDownListDateFromDay.SelectedValue = dateFrom.Day
        DropDownListDateToDay.SelectedValue = dateTo.Day

    End Sub

    Private Sub PopulateDaysOfMonth(ByRef ddlDay As DropDownList, ByVal ddlMonth As DropDownList, ByVal ddlYear As DropDownList)

        ' Local Vars
        Dim nCurrentIndex As Integer = -1

        ' If we have a Current Selection
        If ddlDay.SelectedValue <> String.Empty Then

            ' Store the Current Selection
            nCurrentIndex = ddlDay.SelectedIndex

        End If

        ' Clear the Current List
        ddlDay.Items.Clear()

        ' For each Day in this Month
        For nDay As Integer = 1 To DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), ddlMonth.SelectedIndex + 1)

            ' Add Value
            ddlDay.Items.Add(nDay.ToString.Trim)

        Next

        ' If we Stored a Previous Value
        If nCurrentIndex > -1 Then

            ' Try and Restore the Value - if the Value Exists
            If ddlDay.Items.Count > nCurrentIndex Then

                ' Restore Value
                ddlDay.SelectedIndex = nCurrentIndex

            Else

                ' Set to Month Max
                ddlDay.SelectedIndex = ddlDay.Items.Count - 1

            End If

        End If

    End Sub

    Private Function CheckDateRangeError() As Boolean

        ' Get Dates
        Dim dtDateFrom As Date = New DateTime(Convert.ToInt32(DropDownListDateFromYear.SelectedValue), DropDownListDateFromMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListDateFromDay.SelectedValue))
        Dim dtDateTo As Date = New DateTime(Convert.ToInt32(DropDownListDateToYear.SelectedValue), DropDownListDateToMonth.SelectedIndex + 1, Convert.ToInt32(DropDownListDateToDay.SelectedValue))

        ' Return Date Error
        Return dtDateFrom > dtDateTo

    End Function

    Private Sub AdjustDate(ByVal bFromDate As Boolean)

        ' If we are Adjusting the From Date
        If bFromDate Then

            ' From Date
            DropDownListDateFromYear.SelectedIndex = DropDownListDateToYear.SelectedIndex
            DropDownListDateFromMonth.SelectedIndex = DropDownListDateToMonth.SelectedIndex
            DropDownListDateFromDay.SelectedIndex = DropDownListDateToDay.SelectedIndex

        Else

            ' To Date
            DropDownListDateToYear.SelectedIndex = DropDownListDateFromYear.SelectedIndex
            DropDownListDateToMonth.SelectedIndex = DropDownListDateFromMonth.SelectedIndex
            DropDownListDateToDay.SelectedIndex = DropDownListDateFromDay.SelectedIndex

        End If

    End Sub

    Protected Sub DropDownListDateFromMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateFromMonth.SelectedIndexChanged

        ' Populate Drop Down with Days of the Month
        PopulateDaysOfMonth(DropDownListDateFromDay, DropDownListDateFromMonth, DropDownListDateFromYear)

        ' Check if we have a Date Error, if so, Adjust
        If CheckDateRangeError() Then
            AdjustDate(False)
        End If

    End Sub

    Protected Sub DropDownListDateFromYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateFromYear.SelectedIndexChanged

        ' Populate Drop Down with Days of the Month
        PopulateDaysOfMonth(DropDownListDateFromDay, DropDownListDateFromMonth, DropDownListDateFromYear)

        ' Check if we have a Date Error, if so, Adjust
        If CheckDateRangeError() Then
            AdjustDate(False)
        End If

    End Sub

    Protected Sub DropDownListDateToMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateToMonth.SelectedIndexChanged

        ' Populate Drop Down with Days of the Month
        PopulateDaysOfMonth(DropDownListDateToDay, DropDownListDateToMonth, DropDownListDateToYear)

        ' Check if we have a Date Error, if so, Adjust
        If CheckDateRangeError() Then
            AdjustDate(True)
        End If

    End Sub

    Protected Sub DropDownListDateToYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateToYear.SelectedIndexChanged

        ' Populate Drop Down with Days of the Month
        PopulateDaysOfMonth(DropDownListDateToDay, DropDownListDateToMonth, DropDownListDateToYear)

        ' Check if we have a Date Error, if so, Adjust
        If CheckDateRangeError() Then
            AdjustDate(True)
        End If

    End Sub

    Protected Sub DropDownListDateFromDay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateFromDay.SelectedIndexChanged

        ' Check if we have a Date Error, if so, Adjust
        If CheckDateRangeError() Then
            AdjustDate(False)
        End If

    End Sub

    Protected Sub DropDownListDateToDay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDateToDay.SelectedIndexChanged

        ' Check if we have a Date Error, if so, Adjust
        If CheckDateRangeError() Then
            AdjustDate(True)
        End If

    End Sub

    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged

        Session("ClientTourID") = Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim)

        RaiseEvent TourSelected()

    End Sub

    Private Sub ApplyStyling()

        ' Set Visibility
        GridViewResults.Visible = GridViewResults.Rows.Count > 0
        LabelNoResults.Visible = Not GridViewResults.Visible

    End Sub

    Public Sub Reload()

        ' Load Previous Values
        LoadControlValues(Me)

        ' Re Apply Styling
        ApplyStyling()

    End Sub

End Class
