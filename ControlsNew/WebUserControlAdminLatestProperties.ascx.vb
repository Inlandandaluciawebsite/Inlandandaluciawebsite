Imports System.Data
Imports ClassHistory

Partial Class WebUserControlAdminLatestProperties
    Inherits System.Web.UI.UserControl

    Public Event PropertySelected()

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Add the Durations
        DropDownListDuration.Items.Add("Past Week")
        DropDownListDuration.Items.Add("Past Month")
        DropDownListDuration.Items.Add("Past 2 Months")
        DropDownListDuration.Items.Add("Past 3 Months")
        DropDownListDuration.Items.Add("Past 6 Months")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ' Init Sorting Params
            Session("PropertyAdminPropertyLatestSortField") = ""
            Session("PropertyAdminPropertyLatestSortOrder") = "Desc"

        End If

    End Sub

    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged

        ' Local Vars
        Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))

        ' Load this Property's Details
        Dim CDataAccess As New ClassDataAccess
        CProperty.Load(Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim))
        CDataAccess = Nothing

        ' Assign to Session Variable
        Session("AdminPropertySelected") = CProperty

        ' Raise Event
        RaiseEvent PropertySelected()

    End Sub

    Protected Sub GridViewResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridViewResults.Sorting

        ' Local Vars
        Dim dtDataTable As New DataTable
        Dim dvDataView As DataView

        ' Check to see if the Sort Field is the Same
        If Session("PropertyAdminPropertyLatestSortField") = e.SortExpression Then

            ' Toggle Sort
            If Session("PropertyAdminPropertyLatestSortOrder") = "Desc" Then
                Session("PropertyAdminPropertyLatestSortOrder") = "Asc"
            Else
                Session("PropertyAdminPropertyLatestSortOrder") = "Desc"
            End If

        Else

            ' New Sort Field, Set Field and Init to Ascending
            Session("PropertyAdminPropertyLatestSortField") = e.SortExpression
            Session("PropertyAdminPropertyLatestSortOrder") = "Asc"

        End If

        ' Apply Sorting
        ApplySorting()

        ' Apply the Styling
        ApplyStyling()

    End Sub

    Private Sub ApplySorting()

        ' Get the Intial Data
        Dim dtDataTable As DataTable = DirectCast(Session("PropertyAdminPropertyLatestResults"), DataTable)
        Dim dvDataView As New DataView(dtDataTable)

        ' If we are Sorting
        If Not Session("PropertyAdminPropertyLatestSortField") = String.Empty Then

            ' Local Vars
            Dim szSortBy As String

            If Session("PropertyAdminPropertyLatestSortField").ToString.Trim = "Price" Then

                ' Price
                szSortBy = "public_price"

            Else

                ' By the Column Title
                szSortBy = Session("PropertyAdminPropertyLatestSortField").ToString.Trim

            End If

            ' Sort
            dvDataView.Sort = szSortBy.Trim & " " & Session("PropertyAdminPropertyLatestSortOrder")

        End If

        ' Apply to the GridView
        GridViewResults.DataSource = dvDataView

        ' Bind
        GridViewResults.DataBind()

        ' Tidy
        dtDataTable.Dispose()

    End Sub

    Private Sub ApplyStyling()

        ' Hide the ID & Price
        If Not GridViewResults.HeaderRow Is Nothing Then
            GridViewResults.HeaderRow.Cells(1).Visible = False
            GridViewResults.HeaderRow.Cells(2).Visible = False
            For Each gvr As GridViewRow In GridViewResults.Rows
                gvr.Cells(1).Visible = False
                gvr.Cells(2).Visible = False
            Next
        End If

        ' Apply Colour Coding
        For Each gvr As GridViewRow In GridViewResults.Rows

            ' Depending on the Status
            Select Case gvr.Cells(10).Text.Trim

                Case "New Property"
                    gvr.BackColor = Drawing.Color.Yellow

                Case "Under Offer"
                    gvr.BackColor = Drawing.Color.Green

                Case "Sold", "Withdrawn"
                    gvr.BackColor = Drawing.Color.Red

            End Select

        Next

        ' Update Row Count
        LabelNoOfResults.Text = GridViewResults.Rows.Count.ToString.Trim & " Result(s)"

        ' Set Visibility
        TableRowNoResults.Visible = GridViewResults.Rows.Count < 1
        TableRowNoOfResults.Visible = Not TableRowNoResults.Visible
        TableResults.Visible = TableRowNoOfResults.Visible

    End Sub

    Public Sub Reload()

        ' Load Previous Values
        LoadControlValues(Me)

        ' Apply Styling
        ApplyStyling()

        ' Hide / Display GridView
        GridViewResults.Visible = GridViewResults.Rows.Count > 0

    End Sub

    Protected Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click

        ' If we don't have a Contact Partner ID
        If Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Agent Login Page
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Check we are Searching for Something
            If CheckBoxCreated.Checked Or CheckBoxModified.Checked Then

                ' Local Vars
                Dim CDataAccess As New ClassDataAccess
                Dim CUtilities As New ClassUtilities
                Dim dteFrom As Date

                ' Set the From Date
                Select Case DropDownListDuration.SelectedIndex

                    Case 1
                        ' Past Month
                        dteFrom = DateAdd(DateInterval.Month, -1, Today)

                    Case 2
                        ' Past 2 Months
                        dteFrom = DateAdd(DateInterval.Month, -2, Today)

                    Case 3
                        ' Past 3 Months
                        dteFrom = DateAdd(DateInterval.Month, -3, Today)

                    Case 4
                        ' Past 6 Months
                        dteFrom = DateAdd(DateInterval.Month, -6, Today)

                    Case Else
                        ' Past Week
                        dteFrom = DateAdd(DateInterval.Day, -7, Today)

                End Select

                ' Get Search Results
                Dim dtDataTable As DataTable

                ' Depending on Options
                If CheckBoxCreated.Checked And Not CheckBoxModified.Checked Then

                    ' Created Only
                    dtDataTable = CDataAccess.LatestProperties(dteFrom)

                ElseIf Not CheckBoxCreated.Checked And CheckBoxModified.Checked Then

                    ' Modified Only
                    dtDataTable = CDataAccess.LatestProperties(, dteFrom)

                Else

                    ' Created and Modified
                    dtDataTable = CDataAccess.LatestProperties(dteFrom, dteFrom)

                End If

                ' If we have Results
                If dtDataTable.Rows.Count > 0 Then

                    ' Loop through each of the Results
                    For Each dr As DataRow In dtDataTable.Rows

                        ' Format the Price
                        dr("Price") = CUtilities.FormatPrice(Convert.ToInt32(dr("Price")))

                    Next

                    ' Assign Results to Session
                    Session("PropertyAdminPropertyLatestResults") = dtDataTable

                    ' Apply Sorting
                    ApplySorting()

                    ' Apply Styling
                    ApplyStyling()

                Else

                    ' Set Visibility
                    TableRowNoResults.Visible = True

                End If

                ' Tidy
                dtDataTable.Dispose()
                CDataAccess = Nothing
                CUtilities = Nothing

            Else

                ' Show no Results
                TableRowNoResults.Visible = True

            End If

        End If

    End Sub

End Class
