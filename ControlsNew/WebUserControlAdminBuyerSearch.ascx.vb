Imports ClassHistory

Partial Class WebUserControlAdminBuyerSearch
    Inherits System.Web.UI.UserControl

    Public Event BuyerSelected()

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

        ' Perform Search
        Dim CDataAccess As New ClassDataAccess
        GridViewResults.DataSource = CDataAccess.BuyerSearch(TextBoxFirstName.Text.Trim, TextBoxLastName.Text.Trim, CheckBoxIncludeArchived.Checked)
        GridViewResults.DataBind()
        CDataAccess = Nothing

        ' Apply Styling
        ApplyStyling()

    End Sub

    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged

        ' Local Vars
        Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))

        ' Load this Property's Details
        Dim CDataAccess As New ClassDataAccess
        CBuyer.Load(Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim))
        CDataAccess = Nothing

        ' Assign to Session Variable
        Session("AdminBuyerSelected") = CBuyer

        ' Raise Event
        RaiseEvent BuyerSelected()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Focus
        TextBoxFirstName.Focus()

    End Sub

    Private Sub ApplyStyling()

        ' If we have a Header Row
        If Not GridViewResults.HeaderRow Is Nothing Then

            ' Hide the ID & Archived Column Headings
            GridViewResults.HeaderRow.Cells(1).Visible = False
            GridViewResults.HeaderRow.Cells(2).Visible = False

            ' For each Row
            For Each gvr As GridViewRow In GridViewResults.Rows

                ' Hide ID and Archived Cells
                gvr.Cells(1).Visible = False
                gvr.Cells(2).Visible = False

                ' If this Client is Archived
                If DirectCast(gvr.Cells(2).Controls(0), CheckBox).Checked Then

                    ' Apply Styling
                    gvr.BackColor = Drawing.Color.Gray

                End If

            Next

        End If

        ' Set Visibility
        TableRowNoResults.Visible = GridViewResults.Rows.Count < 1
        TableRowResults.Visible = Not TableRowNoResults.Visible

    End Sub

    Public Sub Reload()

        ' Reload Values
        LoadControlValues(Me)

        ' Apply Styling
        ApplyStyling()

    End Sub

End Class
