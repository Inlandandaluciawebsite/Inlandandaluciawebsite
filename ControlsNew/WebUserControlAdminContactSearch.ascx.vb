Imports System.Data
Imports ClassHistory

Partial Class WebUserControlAdminContactSearch
    Inherits System.Web.UI.UserControl

    Public Event ContactSelected()

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Assign Results to Session Variable
        Session("PropertyAdminContactSearchResults") = CDataAccess.ContactSearch(Convert.ToInt32(Session("AdminContactSearchTypeID")), TextBoxName.Text.Trim, Convert.ToInt32(Session("ContactPartnerID")), TextBoxPropertyReference.Text.Trim, CheckBoxIncludeArchived.Checked)

        ' Tidy
        CDataAccess = Nothing

        ' Load up Previous Notes
        GridViewResults.DataSource = DirectCast(Session("PropertyAdminContactSearchResults"), DataTable)
        GridViewResults.DataBind()

        ' Format and Display GridView
        FormatDisplayResults()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ' Init Sorting Params
            Session("PropertyAdminContactSearchSortField") = ""
            Session("PropertyAdminContactSearchSortOrder") = "Desc"

        End If

        ' Set Focus
        TextBoxName.Focus()

    End Sub

    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged

        ' Local Vars
        Dim CContact As New ClassContact()

        ' Load this Contact's Details
        Dim CDataAccess As New ClassDataAccess
        CContact.Load(Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim))
        CDataAccess = Nothing

        ' Assign to Session Variable
        Session("AdminContactSelected") = CContact

        ' Raise Event
        RaiseEvent ContactSelected()

    End Sub

    Protected Sub GridViewResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridViewResults.Sorting

        ' Local Vars
        Dim dtDataTable As DataTable
        Dim dvDataView As DataView

        ' Check to see if the Sort Field is the Same
        If Session("PropertyAdminContactSearchSortField") = e.SortExpression Then

            ' Toggle Sort
            If Session("PropertyAdminContactSearchSortOrder") = "Desc" Then
                Session("PropertyAdminContactSearchSortOrder") = "Asc"
            Else
                Session("PropertyAdminContactSearchSortOrder") = "Desc"
            End If

        Else

            ' New Sort Field, Set Field and Init to Ascending
            Session("PropertyAdminContactSearchSortField") = e.SortExpression
            Session("PropertyAdminContactSearchSortOrder") = "Asc"

        End If

        ' Get the Intial Data
        dtDataTable = DirectCast(Session("PropertyAdminContactSearchResults"), DataTable)
        dvDataView = New DataView(dtDataTable)

        ' Depending on the Sort Direction, Sort
        dvDataView.Sort = Session("PropertyAdminContactSearchSortField") & " " & Session("PropertyAdminContactSearchSortOrder")

        ' Apply to the GridView
        GridViewResults.DataSource = dvDataView

        ' Bind
        GridViewResults.DataBind()

    End Sub

    Public Sub InitForm()

        '' Load Previous Values
        'LoadControlValues(Me)

        '' Format Results
        'FormatDisplayResults()

        ' If we know the Contact Type ID
        If Not Session("AdminContactSearchTypeID") Is Nothing Then

            ' Define Contact Class
            Dim CContact As New ClassContact

            ' Set the Contact Type
            LabelContact.Text = CContact.Type(Convert.ToInt32(Session("AdminContactSearchTypeID"))) & " Search"

            ' If this is a Vendor, display the Property Reference Search
            If Convert.ToInt32(Session("AdminContactSearchTypeID")) = 5 Then

                ' Display the Search Criteria
                TableRowPropertyReference.Visible = True

            End If

            ' Tidy
            CContact = Nothing

        End If

    End Sub

    Public Sub Reload()

        ' Load Previous Values
        LoadControlValues(Me)

        ' Format Results
        FormatDisplayResults()

    End Sub

    Private Sub FormatDisplayResults()

        ' Hide the ID
        If Not GridViewResults.HeaderRow Is Nothing Then
            GridViewResults.HeaderRow.Cells(1).Visible = False
            GridViewResults.HeaderRow.Cells(3).Visible = False
            For Each gvr As GridViewRow In GridViewResults.Rows

                ' Hide the ID
                gvr.Cells(1).Visible = False

                ' Hide Archived Flag
                gvr.Cells(3).Visible = False

                ' If this is Archived, Make Yellow
                If gvr.Cells(3).Text = "Archived" Then
                    gvr.BackColor = Drawing.Color.LightGray
                End If

            Next
        End If

        ' Display the GridView
        GridViewResults.Visible = GridViewResults.Rows.Count > 0

    End Sub

End Class
