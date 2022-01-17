
Partial Class WebUserControlAdminUpdateSystemVariables
    Inherits System.Web.UI.UserControl

    Public Sub InitForm()

        ' Check we have the Table we are Updating
        If Session("AdminSystemTable") Is Nothing Then

            ' Redirect to the Login Page
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Set the Label and Populate the Results depending on the System Table being updated
            Select Case Convert.ToInt32(Session("AdminSystemTable"))

                Case ClassDataAccess.E_SystemVariable.BuyerSource
                    LabelTitle.Text = "Buyer Source"
                    GridViewResults.DataSource = CDataAccess.BuyerSourceAll

                Case ClassDataAccess.E_SystemVariable.BuyerStatus
                    LabelTitle.Text = "Buyer Status"
                    GridViewResults.DataSource = CDataAccess.BuyerStatusAll

                Case ClassDataAccess.E_SystemVariable.Feature
                    LabelTitle.Text = "Features"
                    GridViewResults.DataSource = CDataAccess.PropertyFeatures

                Case ClassDataAccess.E_SystemVariable.Language
                    LabelTitle.Text = "Languages"
                    GridViewResults.DataSource = CDataAccess.Languages

                Case ClassDataAccess.E_SystemVariable.Location
                    LabelTitle.Text = "Locations"
                    GridViewResults.DataSource = CDataAccess.PropertyLocations

                Case ClassDataAccess.E_SystemVariable.PaymentType
                    LabelTitle.Text = "Payment Types"
                    GridViewResults.DataSource = CDataAccess.PaymentTypes

                Case ClassDataAccess.E_SystemVariable.Status
                    LabelTitle.Text = "Status"
                    GridViewResults.DataSource = CDataAccess.PropertyStatus

                Case ClassDataAccess.E_SystemVariable.Type
                    LabelTitle.Text = "Types"
                    GridViewResults.DataSource = CDataAccess.PropertyTypes

                Case ClassDataAccess.E_SystemVariable.View
                    LabelTitle.Text = "Views"
                    GridViewResults.DataSource = CDataAccess.Views

            End Select

            ' Bind
            GridViewResults.DataBind()

            ' Decoding any Translations that Require it

            ' Loop through the Results
            For Each gvr As GridViewRow In GridViewResults.Rows

                ' Decode the Output for Spanish, French, German and Dutch
                gvr.Cells(2).Text = gvr.Cells(2).Text.Replace("''", "'").Trim
                gvr.Cells(3).Text = gvr.Cells(3).Text.Replace("''", "'").Trim
                gvr.Cells(4).Text = gvr.Cells(4).Text.Replace("''", "'").Trim
                gvr.Cells(5).Text = gvr.Cells(5).Text.Replace("''", "'").Trim
                gvr.Cells(6).Text = gvr.Cells(6).Text.Replace("''", "'").Trim

            Next

            ' Tidy
            CDataAccess = Nothing

            ' Hide the ID Column
            If Not GridViewResults.HeaderRow Is Nothing Then
                GridViewResults.HeaderRow.Cells(1).Visible = False
                For Each gvr As GridViewRow In GridViewResults.Rows
                    gvr.Cells(1).Visible = False
                Next
            End If

            ' Display Relevent Table Rows
            DisplayMain()

        End If

    End Sub

    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged

        ' Save the ID being Editted / Deleted
        Session("AdminSystemID") = Convert.ToInt32(GridViewResults.SelectedRow.Cells(1).Text.Trim)

        ' Check Session hasn't Expired
        If Session("AdminSystemTable") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Populate the Editting Controls
            TextBoxEnglish.Text = HttpUtility.HtmlDecode(RemoveAutoTranslate(GridViewResults.SelectedRow.Cells(2).Text.Trim))
            TextBoxSpanish.Text = HttpUtility.HtmlDecode(RemoveAutoTranslate(GridViewResults.SelectedRow.Cells(3).Text.Trim))
            TextBoxFrench.Text = HttpUtility.HtmlDecode(RemoveAutoTranslate(GridViewResults.SelectedRow.Cells(4).Text.Trim))
            TextBoxGerman.Text = HttpUtility.HtmlDecode(RemoveAutoTranslate(GridViewResults.SelectedRow.Cells(5).Text.Trim))
            TextBoxDutch.Text = HttpUtility.HtmlDecode(RemoveAutoTranslate(GridViewResults.SelectedRow.Cells(6).Text.Trim))

            ' If this is Property Type or Country
            If Convert.ToInt32(Session("AdminSystemTable")) = ClassDataAccess.E_SystemVariable.Type Then

                ' Assign the Property Type or Country Code
                TextBoxCode.Text = GridViewResults.SelectedRow.Cells(7).Text.Trim

            End If

            ' Display Relevent Tables
            DisplayEditFields()

        End If

    End Sub

    Private Function RemoveAutoTranslate(ByVal szText As String) As String

        If szText.Trim = "Auto Translate" Then
            Return String.Empty
        Else
            Return szText.Trim
        End If

    End Function

    Protected Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click

        ' Display Relevent Tables
        DisplayMain()

    End Sub

    Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        ' Check Session hasn't Expired
        If Session("AdminSystemTable") Is Nothing Or Session("AdminSystemID") Is Nothing Or Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Check to see if the Item being Deleted is in Use
            GridViewPropertiesAffected.DataSource = CDataAccess.PropertiesUsingSystemVariable(Convert.ToInt32(Session("AdminSystemTable")), Convert.ToInt32(Session("AdminSystemID")), Convert.ToInt32(Session("ContactPartnerID")))

            ' Bind the Data
            GridViewPropertiesAffected.DataBind()

            ' If we got a Result
            If GridViewPropertiesAffected.Rows.Count > 0 Then

                ' Display the Affected Properties Fields
                DisplayPropertiesAffected()

            Else

                ' System Variable is not in Use, Remove
                CDataAccess.RemoveSystemVariable(Convert.ToInt32(Session("AdminSystemTable")), Convert.ToInt32(Session("AdminSystemID")))

            End If

            ' Tidy
            CDataAccess = Nothing

            ' If we Removed the View, Init Form
            If GridViewPropertiesAffected.Rows.Count = 0 Then

                ' Reload the Form
                InitForm()

            End If

        End If

    End Sub

    Protected Sub ButtonAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click

        ' Reset ID
        Session("AdminSystemID") = 0

        ' Initialise the New Fields
        TextBoxEnglish.Text = String.Empty
        TextBoxSpanish.Text = String.Empty
        TextBoxFrench.Text = String.Empty
        TextBoxGerman.Text = String.Empty
        TextBoxDutch.Text = String.Empty
        TextBoxCode.Text = String.Empty

        ' Display Relevent Fields
        DisplayAddFields()

    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' Check Session hasn't Expired
        If Session("AdminSystemTable") Is Nothing Or Session("AdminSystemID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim alEntries As New ArrayList

            ' Load Entries
            alEntries.Add(TextBoxEnglish.Text.Replace("'", "''").Trim)
            alEntries.Add(TextBoxSpanish.Text.Replace("'", "''").Trim)
            alEntries.Add(TextBoxFrench.Text.Replace("'", "''").Trim)
            alEntries.Add(TextBoxGerman.Text.Replace("'", "''").Trim)
            alEntries.Add(TextBoxDutch.Text.Replace("'", "''").Trim)

            ' Save Entity
            CDataAccess.SaveSystemVariable(Convert.ToInt32(Session("AdminSystemTable")), alEntries, Convert.ToInt32(Session("AdminSystemID")), TextBoxCode.Text.Trim.ToUpper)

            ' Tidy
            alEntries.Clear()
            alEntries = Nothing
            CDataAccess = Nothing

            ' Reload the Form
            InitForm()

        End If

    End Sub

    Private Sub DisplayPropertiesAffected()

        ' Display Relevent Table Rows
        TableRowResults.Visible = False
        TableRowAdd.Visible = False
        TableRowAddEditEnglish.Visible = False
        TableRowAddEditSpanish.Visible = False
        TableRowAddEditFrench.Visible = False
        TableRowAddEditGerman.Visible = False
        TableRowAddEditDutch.Visible = False
        TableRowCode.Visible = False
        ButtonDelete.Visible = False
        TableRowOptions.Visible = False
        TableRowPropertiesAffectedPrompt.Visible = True
        TableRowPropertiesAffected.Visible = True
        TableRowBack.Visible = True

    End Sub

    Private Sub DisplayEditFields()

        ' Check Session hasn't Expired
        If Session("AdminSystemTable") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Display Relevent Table Rows
            TableRowResults.Visible = False
            TableRowAdd.Visible = False
            TableRowAddEditEnglish.Visible = True
            TableRowAddEditSpanish.Visible = True
            TableRowAddEditFrench.Visible = True
            TableRowAddEditGerman.Visible = True
            TableRowAddEditDutch.Visible = True
            TableRowCode.Visible = (Convert.ToInt32(Session("AdminSystemTable")) = ClassDataAccess.E_SystemVariable.Type)
            ButtonDelete.Visible = (Convert.ToInt32(Session("AdminSystemTable")) <> ClassDataAccess.E_SystemVariable.Language)
            TableRowOptions.Visible = True
            TableRowPropertiesAffectedPrompt.Visible = False
            TableRowPropertiesAffected.Visible = False
            TableRowBack.Visible = False

        End If

    End Sub

    Private Sub DisplayAddFields()

        ' Display Relevent Table Rows
        TableRowResults.Visible = False
        TableRowAdd.Visible = False
        TableRowAddEditEnglish.Visible = True
        TableRowAddEditSpanish.Visible = True
        TableRowAddEditFrench.Visible = True
        TableRowAddEditGerman.Visible = True
        TableRowAddEditDutch.Visible = True
        TableRowCode.Visible = (Convert.ToInt32(Session("AdminSystemTable")) = ClassDataAccess.E_SystemVariable.Type)
        ButtonDelete.Visible = False
        TableRowOptions.Visible = True
        TableRowPropertiesAffectedPrompt.Visible = False
        TableRowPropertiesAffected.Visible = False
        TableRowBack.Visible = False

    End Sub

    Private Sub DisplayMain()

        ' Display Relevent Table Rows
        TableRowResults.Visible = GridViewResults.Rows.Count > 0
        TableRowAdd.Visible = True
        TableRowAddEditEnglish.Visible = False
        TableRowAddEditSpanish.Visible = False
        TableRowAddEditFrench.Visible = False
        TableRowAddEditGerman.Visible = False
        TableRowAddEditDutch.Visible = False
        TableRowCode.Visible = False
        ButtonDelete.Visible = False
        TableRowOptions.Visible = False
        TableRowPropertiesAffectedPrompt.Visible = False
        TableRowPropertiesAffected.Visible = False
        TableRowBack.Visible = False

    End Sub

    Protected Sub ButtonBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBack.Click

        ' Display Relevent Tables
        DisplayMain()

    End Sub

    Protected Sub ButtonAutoTranslate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAutoTranslate.Click

        ' Ensure we have an English Translation
        If TextBoxEnglish.Text.Trim <> String.Empty Then

            ' Local Vars
            Dim CUtilities As New ClassUtilities
            Dim nLanguageID As Integer
            Dim szTranslation As String

            ' For each Language
            For nLanguageID = 2 To 5

                ' Do Translation
                szTranslation = HttpUtility.HtmlDecode(CUtilities.Translate(TextBoxEnglish.Text.Trim, nLanguageID)).Trim

                ' Depending on the Language - Update the TextBoxes
                Select Case nLanguageID

                    Case 2
                        TextBoxSpanish.Text = szTranslation
                    Case 3
                        TextBoxFrench.Text = szTranslation
                    Case 4
                        TextBoxGerman.Text = szTranslation
                    Case Else
                        TextBoxDutch.Text = szTranslation

                End Select

            Next

            ' Tidy
            CUtilities = Nothing

        End If

    End Sub

End Class
