Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Partial Class Translations
    Inherits System.Web.UI.Page

    Private Sub HideIDColumns()

        ' Hide the ID
        If Not GridViewResults.HeaderRow Is Nothing Then
            GridViewResults.HeaderRow.Cells(2).Visible = False
            GridViewResults.HeaderRow.Cells(3).Visible = False
            For Each gvr As GridViewRow In GridViewResults.Rows
                gvr.Cells(2).Visible = False
                gvr.Cells(3).Visible = False
            Next
        End If

    End Sub

    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged

        ' Store the IDs
        Session("AdminTranslationHashCode") = Convert.ToInt64(GridViewResults.SelectedRow.Cells(2).Text.Trim)
        Session("AdminTranslationLanguageID") = Convert.ToInt32(GridViewResults.SelectedRow.Cells(3).Text.Trim)

        ' Init Selection
        TextBoxOriginal.Text = GridViewResults.SelectedRow.Cells(1).Text.Trim
        LabelLanguage.Text = GridViewResults.SelectedRow.Cells(4).Text.Trim
        TextBoxTranslation.Text = HttpUtility.HtmlDecode(GridViewResults.SelectedRow.Cells(5).Text.Trim)

        ' Hide the Search and Results Rows
        TableRowSearchEnglish.Visible = False
        TableRowSearchForeign.Visible = False
        TableRowSearchResults.Visible = False

        ' Display Rows
        TableRowEnglish.Visible = True
        TableRowOriginal.Visible = True
        TableRowLanguage.Visible = True
        TableRowTranslation.Visible = True
        TableRowUpdate.Visible = True

    End Sub

    Protected Sub GridViewResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridViewResults.Sorting

        ' Local Vars
        Dim dtDataTable As DataTable
        Dim dvDataView As DataView

        ' Check to see if the Sort Field is the Same
        If Session("AdminTranslationSearchSortField") = e.SortExpression Then

            ' Toggle Sort
            If Session("AdminTranslationSearchSortOrder") = "Desc" Then
                Session("AdminTranslationSearchSortOrder") = "Asc"
            Else
                Session("AdminTranslationSearchSortOrder") = "Desc"
            End If

        Else

            ' New Sort Field, Set Field and Init to Ascending
            Session("AdminTranslationSearchSortField") = e.SortExpression
            Session("AdminTranslationSearchSortOrder") = "Asc"

        End If

        ' Get the Intial Data
        dtDataTable = DirectCast(Session("AdminTranslationSearchResults"), DataTable)
        dvDataView = New DataView(dtDataTable)

        ' Depending on the Sort Direction, Sort
        dvDataView.Sort = Session("AdminTranslationSearchSortField") & " " & Session("AdminTranslationSearchSortOrder")

        ' Apply to the GridView
        GridViewResults.DataSource = dvDataView

        ' Bind
        GridViewResults.DataBind()

        ' Hide the IDs
        HideIDColumns()

    End Sub

    Protected Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click

        ' Hide Rows
        TableRowEnglish.Visible = False
        TableRowOriginal.Visible = False
        TableRowLanguage.Visible = False
        TableRowTranslation.Visible = False
        TableRowUpdate.Visible = False

        ' Display the Search and Results Rows
        TableRowSearchEnglish.Visible = True
        TableRowSearchForeign.Visible = True
        TableRowSearchResults.Visible = True

    End Sub

    Protected Sub ButtonUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click

        ' Check we have the necessary Session Variables
        If Session("AdminTranslationHashCode") Is Nothing Or Session("AdminTranslationLanguageID") Is Nothing Then

            ' Redirect to Agent Lo0gin
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Check that we have Text to Save
            If TextBoxTranslation.Text.Trim <> String.Empty Then

                ' Update the Translation
                Dim CDataAccess As New ClassDataAccess
                CDataAccess.UpdateTranslation(Convert.ToInt64(Session("AdminTranslationHashCode")), Convert.ToInt32(Session("AdminTranslationLanguageID")), TextBoxTranslation.Text.Trim)
                CDataAccess = Nothing

                ' Reapply Search Results
                ReapplySearchResults()

            End If

        End If

    End Sub

    Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        ' Check we have the necessary Session Variables
        If Session("AdminTranslationHashCode") Is Nothing Or Session("AdminTranslationLanguageID") Is Nothing Then

            ' Redirect to Agent Lo0gin
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Delete the Translation
            Dim CDataAccess As New ClassDataAccess
            CDataAccess.DeleteTranslation(Convert.ToInt64(Session("AdminTranslationHashCode")), Convert.ToInt32(Session("AdminTranslationLanguageID")))
            CDataAccess = Nothing

            ' Reapply Search Results
            ReapplySearchResults()

        End If

    End Sub

    Private Sub ReapplySearchResults()

        ' Check we have the necessary Session Variables
        If Session("AdminTranslationSearchStringEnglish") Is Nothing And Session("AdminTranslationSearchStringForeign") Is Nothing Then

            ' Redirect to Agent Lo0gin
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Depending on the Search
            If Session("AdminTranslationSearchStringEnglish") Is Nothing Then

                ' Reapply Initial Search String
                TextBoxTranslationSearchForeign.Text = Session("AdminTranslationSearchStringForeign")
                ButtonTranslationSearchForeign_Click(Nothing, Nothing)

            Else

                ' Reapply Initial Search String
                TextBoxTranslationSearchEnglish.Text = Session("AdminTranslationSearchStringEnglish")
                ButtonTranslationSearchEnglish_Click(Nothing, Nothing)

            End If

            ' Return the Search Results
            ButtonCancel_Click(Nothing, Nothing)

        End If

    End Sub

    Protected Sub ButtonTranslationSearchForeign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTranslationSearchForeign.Click

        ' Clear other Search Box
        TextBoxTranslationSearchEnglish.Text = String.Empty

        ' Hide Rows
        TableRowNoResults.Visible = False
        TableRowSearchResults.Visible = False
        TableRowLanguage.Visible = False
        TableRowTranslation.Visible = False

        ' Ensure we have a Search String
        If TextBoxTranslationSearchForeign.Text.Trim <> String.Empty Then

            ' Set the Search String
            Session("AdminTranslationSearchStringForeign") = TextBoxTranslationSearchForeign.Text.Trim
            Session("AdminTranslationSearchStringEnglish") = Nothing

            ' Perform a Search
            Dim CDataAccess As New ClassDataAccess
            Session("AdminTranslationSearchResults") = CDataAccess.SearchTranslationsForeign(TextBoxTranslationSearchForeign.Text.Trim)
            CDataAccess = Nothing

            ' Loop through the Results
            For Each dr As DataRow In DirectCast(Session("AdminTranslationSearchResults"), DataTable).Rows

                ' Decode the Output
                dr("Translation") = HttpUtility.HtmlDecode(dr("Translation"))

            Next

            ' Assign to the GridView
            GridViewResults.DataSource = DirectCast(Session("AdminTranslationSearchResults"), DataTable)
            GridViewResults.DataBind()

            ' Hide ID Columns
            HideIDColumns()

            ' Set Visiblitly of GridView and No Results (if we have Results)
            TableRowNoResults.Visible = (GridViewResults.Rows.Count = 0)
            TableRowSearchResults.Visible = (GridViewResults.Rows.Count > 0)

        End If

        ' Update the Panel
        UpdatePanelAdminTranslations.Update()

    End Sub

    Protected Sub ButtonTranslationSearchEnglish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTranslationSearchEnglish.Click

        ' Clear other Search Box
        TextBoxTranslationSearchForeign.Text = String.Empty

        ' Hide Rows
        TableRowNoResults.Visible = False
        TableRowSearchResults.Visible = False
        TableRowLanguage.Visible = False
        TableRowTranslation.Visible = False

        ' Ensure we have a Search String
        If TextBoxTranslationSearchEnglish.Text.Trim <> String.Empty Then

            ' Set the Search String
            Session("AdminTranslationSearchStringEnglish") = TextBoxTranslationSearchEnglish.Text.Trim
            Session("AdminTranslationSearchStringForeign") = Nothing

            ' Perform a Search
            Dim CDataAccess As New ClassDataAccess
            Session("AdminTranslationSearchResults") = CDataAccess.SearchTranslationsEnglish(TextBoxTranslationSearchEnglish.Text.Trim)
            CDataAccess = Nothing

            ' Loop through the Results
            For Each dr As DataRow In DirectCast(Session("AdminTranslationSearchResults"), DataTable).Rows

                ' Decode the Output
                dr("Translation") = HttpUtility.HtmlDecode(dr("Translation"))

            Next

            ' Assign to the GridView
            GridViewResults.DataSource = DirectCast(Session("AdminTranslationSearchResults"), DataTable)
            GridViewResults.DataBind()

            ' Hide ID Columns
            HideIDColumns()

            ' Set Visiblitly of GridView and No Results (if we have Results)
            TableRowNoResults.Visible = (GridViewResults.Rows.Count = 0)
            TableRowSearchResults.Visible = (GridViewResults.Rows.Count > 0)

        End If

        ' Update the Panel
        UpdatePanelAdminTranslations.Update()

    End Sub


End Class
