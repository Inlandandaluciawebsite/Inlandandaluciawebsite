
Partial Class WebUserControlAdminHistoryTypes
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        ' Load the Types
        LoadTypes()

    End Sub

    Private Sub LoadTypes()

        ' Get Data Sources
        Dim CDataAccess As New ClassDataAccess
        GridViewTypes.DataSource = CDataAccess.PropertyHistoryTypes(True)
        GridViewTypes.DataBind()
        CDataAccess = Nothing

        ' Format Display Results
        FormatDisplayResults()

    End Sub

    Private Sub FormatDisplayResults()

        ' Hide the ID
        If Not GridViewTypes.HeaderRow Is Nothing Then
            GridViewTypes.HeaderRow.Cells(1).Visible = False
            GridViewTypes.HeaderRow.Cells(2).Text = "Type"
            GridViewTypes.HeaderRow.Cells(3).Visible = False
            For Each gvr As GridViewRow In GridViewTypes.Rows

                ' Hide the ID
                gvr.Cells(1).Visible = False

                ' Hide Archived Flag
                gvr.Cells(3).Visible = False

                ' If this is Archived, Highlight
                If DirectCast(gvr.Cells(3).Controls(0), CheckBox).Checked Then
                    gvr.BackColor = Drawing.Color.LightGray
                End If

            Next
        End If

        ' Display the GridView
        GridViewTypes.Visible = GridViewTypes.Rows.Count > 0

    End Sub

    Protected Sub GridViewTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewTypes.SelectedIndexChanged

        ' Update Label
        LabelAddEdit.Text = "Edit"

        ' Set the Selected ID
        LabelID.Text = GridViewTypes.SelectedRow.Cells(1).Text.Trim

        ' Update the Text
        TextBoxStatus.Text = GridViewTypes.SelectedRow.Cells(2).Text.Trim

        ' Set the Archived Flag
        CheckBoxArchived.Checked = DirectCast(GridViewTypes.SelectedRow.Cells(3).Controls(0), CheckBox).Checked

        ' Display the Archive Option
        TableRowArchive.Visible = True

        ' Display the Cancel Button
        ButtonCancel.Visible = True

    End Sub

    Protected Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ' Update Label
        LabelAddEdit.Text = "Add"

        ' Set the Selected ID
        LabelID.Text = String.Empty

        ' Update the Text
        TextBoxStatus.Text = String.Empty

        ' Reset the Archived Flag
        CheckBoxArchived.Checked = False

        ' Hide the Archive Option
        TableRowArchive.Visible = False

        ' Hide the Cancel Button
        ButtonCancel.Visible = False

    End Sub

    Protected Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click

        ' Check we have Text
        If TextBoxStatus.Text.Trim <> String.Empty Then

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Are we Adding or Editting...
            If LabelAddEdit.Text.Trim = "Add" Then

                ' Adding
                CDataAccess.AddHistoryType(TextBoxStatus.Text.Trim)

            Else

                ' Editing
                CDataAccess.UpdateHistoryType(Convert.ToInt32(LabelID.Text.Trim), TextBoxStatus.Text.Trim, CheckBoxArchived.Checked)

            End If

            ' Tidy
            CDataAccess = Nothing

            ' Reload the Types
            LoadTypes()

        End If

        ' Tidy
        TextBoxStatus.Text = String.Empty
        CheckBoxArchived.Checked = False

        ' If we were Editting, revert to Adding
        If LabelAddEdit.Text.Trim <> "Add" Then

            ' Hit the Cancel Button
            ButtonCancel_Click(Nothing, Nothing)

        End If

    End Sub

End Class
