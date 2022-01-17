
Partial Class WebUserControlAdminDatePicker
    Inherits System.Web.UI.UserControl

    Public Event DateChanged()

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        ' Local Vars
        Dim nScratch As Integer

        ' For each Month
        For nScratch = 1 To 12

            ' Add the Month to the List
            DropDownListMonth.Items.Add(nScratch)

        Next

        ' Add Last 5 Years
        For nScratch = Today.Year - 5 To Today.Year
            DropDownListYear.Items.Add(nScratch)
        Next

        ' Init Date
        SetDate(Today)

    End Sub

    Public Sub SetDate(ByVal dtDate As Date)

        ' Select the Month and Year
        DropDownListMonth.SelectedValue = dtDate.Month
        DropDownListYear.SelectedValue = dtDate.Year

        ' Populate the Number of Days in this Month
        PopulateDaysOfMonth(DropDownListDay, DropDownListMonth, DropDownListYear)

        ' Select Day
        DropDownListDay.SelectedValue = dtDate.Day

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

    Public Function SelectedDate() As Date

        ' Return the Selection
        Return New Date(Convert.ToInt32(DropDownListYear.SelectedValue), Convert.ToInt32(DropDownListMonth.SelectedValue), Convert.ToInt32(DropDownListDay.SelectedValue))

    End Function

    Protected Sub DropDownListMonthYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged, DropDownListYear.SelectedIndexChanged

        ' Populate Drop Down with Days of the Month
        PopulateDaysOfMonth(DropDownListDay, DropDownListMonth, DropDownListYear)

        ' Raise Changed Eveent
        RaiseEvent DateChanged()

    End Sub

    Protected Sub DropDownListDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDay.SelectedIndexChanged

        ' Raise Changed Eveent
        RaiseEvent DateChanged()

    End Sub

End Class
