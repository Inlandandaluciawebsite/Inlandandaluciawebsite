Imports System.Data

Partial Class WebUserControlAdminPossibleDuplicates
    Inherits System.Web.UI.UserControl

    Public Event DuplicateSelected()

    Public Sub UpdateMatches(ByVal dtDataTable As DataTable)

        ' Assign to GridView
        GridViewResults.DataSource = dtDataTable
        GridViewResults.DataBind()

        ' Hide ID if we have Results
        If Not GridViewResults.HeaderRow Is Nothing Then

            ' Hide the ID
            GridViewResults.HeaderRow.Cells(1).Visible = False

            ' For each Row
            For Each gvr As GridViewRow In GridViewResults.Rows

                ' Hide the ID Column
                gvr.Cells(1).Visible = False

            Next

        End If

    End Sub

    Public Function HasSuggestions() As Boolean
        Return GridViewResults.Rows.Count > 0
    End Function

    Protected Sub GridViewResults_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewResults.SelectedIndexChanged

        ' Set the ID
        Session("DuplicateIDSelected") = Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim)

        ' Raise Event
        RaiseEvent DuplicateSelected()

    End Sub

End Class
