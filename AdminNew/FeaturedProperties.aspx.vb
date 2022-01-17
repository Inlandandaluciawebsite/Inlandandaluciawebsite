Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO

Partial Class Admin_FeaturedProperties
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Populate the Drop Down List 

        ' Non Featured
        'ListBoxAvailableProperties.DataSource = CDataAccess.AdminNonFeaturedProperties(Convert.ToInt32(Session("ContactPartnerID")))
        ListBoxAvailableProperties.DataSource = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_NonFeatured_Property_Select").Tables(0)
        ListBoxAvailableProperties.DataTextField = "text"
        ListBoxAvailableProperties.DataValueField = "ref"
        ListBoxAvailableProperties.DataBind()

        ' Featured
        Dim dtFeaturedProperties As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Featured_Property_Select").Tables(0)
        'ListBoxSelectedProperties.DataSource = CDataAccess.AdminFeaturedProperties(Convert.ToInt32(Session("ContactPartnerID")))
        ListBoxSelectedProperties.DataSource = dtFeaturedProperties
        ListBoxSelectedProperties.DataTextField = "text"
        ListBoxSelectedProperties.DataValueField = "ref"
        ListBoxSelectedProperties.DataBind()

        ' Tidy
        CDataAccess = Nothing

        ' Update Form
        UpdateForm()

    End Sub

    Protected Sub ButtonAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click

        ' Check we have a Property Selected
        If ListBoxAvailableProperties.SelectedValue <> String.Empty Then

            ' Remove Selected Focus
            ListBoxSelectedProperties.SelectedIndex = -1

            ' Move this to those Selected
            ListBoxSelectedProperties.Items.Add(ListBoxAvailableProperties.SelectedItem)

            ' Remove from Available
            ListBoxAvailableProperties.Items.Remove(ListBoxAvailableProperties.SelectedItem)

            ' Make Dirty
            MakeDirty()

            ' Update the Form
            UpdateForm()

        End If

    End Sub

    Protected Sub ButtonRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRemove.Click

        ' Check we have a Property Selected
        If ListBoxSelectedProperties.SelectedValue <> String.Empty Then

            ' Remove Available Focus
            ListBoxAvailableProperties.SelectedIndex = -1

            ' Move this to those Available
            ListBoxAvailableProperties.Items.Add(ListBoxSelectedProperties.SelectedItem)

            ' Sort
            SortList(ListBoxAvailableProperties)

            ' Remove from Selected
            ListBoxSelectedProperties.Items.Remove(ListBoxSelectedProperties.SelectedItem)

            ' Update the Form
            UpdateForm()

            ' Make Dirty
            MakeDirty()

        End If

    End Sub

    Private Sub SortList(ByRef lstBox As ListBox)

        ' Local Vars
        Dim lstSorted As New SortedList

        ' Loop through Items
        For Each lstItem As ListItem In lstBox.Items

            ' If the Item doesn't already Exist
            If Not lstSorted.Contains(lstItem.Text) Then

                ' Add to Sorted List
                lstSorted.Add(lstItem.Text, lstItem.Value)

            End If

        Next

        ' Clear Existing
        lstBox.Items.Clear()

        ' Add Sorted
        For Each szKey As String In lstSorted.Keys
            lstBox.Items.Add(New ListItem(szKey, lstSorted(szKey).ToString()))
        Next

    End Sub

    Private Sub UpdateForm()

        ' Hide Saved Message
        TableRowSaved.Visible = False

        ' Enable / Disable Add/Remove Buttons
        ButtonAdd.Enabled = (ListBoxSelectedProperties.Items.Count < 5000) And (Not ListBoxAvailableProperties.SelectedItem Is Nothing)
        ButtonRemove.Enabled = (Not ListBoxSelectedProperties.SelectedItem Is Nothing)

        ' Set Number
        LabelNoSelected.Text = ListBoxSelectedProperties.Items.Count.ToString.Trim & " Properties Featured"

        ' Set Warnings
        If ListBoxSelectedProperties.Items.Count < 5000 Then
            LabelNoSelected.ForeColor = Drawing.Color.Red
        Else
            LabelNoSelected.ForeColor = Drawing.Color.Black
        End If

        ' Update Position
        UpdatePosition()

    End Sub

    Private Sub UpdatePosition()

        ' If an Item has been Selected
        If ListBoxSelectedProperties.SelectedIndex > -1 Then

            ' Update Selection 
            LabelPosition.Text = "Position " & ListBoxSelectedProperties.SelectedIndex + 1

        End If

        ' Make Visible
        LabelPosition.Visible = (ListBoxSelectedProperties.SelectedIndex > -1)

    End Sub

    Private Sub MakeDirty()

        ' Make Form Changes
        ButtonSave.BackColor = Drawing.Color.Red
        ButtonSave.ForeColor = Drawing.Color.White
        ButtonSave.Font.Bold = True

    End Sub

    Private Sub MakeClean()

        ' Make Form Changes
        ButtonSave.BackColor = Nothing
        ButtonSave.ForeColor = Nothing
        ButtonSave.Font.Bold = False

    End Sub

    Protected Sub ListBoxAvailableProperties_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxAvailableProperties.SelectedIndexChanged
        UpdateForm()
    End Sub

    Protected Sub ListBoxSelectedProperties_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxSelectedProperties.SelectedIndexChanged
        UpdateForm()
    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' Add Featured Property IDs to ArrayList
        Dim alFeaturedPropertyIDs As New ArrayList

        ' For each Item Selected
        For Each lstBoxItem As ListItem In ListBoxSelectedProperties.Items

            ' Add this ID to the Array
            alFeaturedPropertyIDs.Add(lstBoxItem.Value)

        Next

        ' Save this to the Database
        Dim CDataAccess As New ClassDataAccess
        CDataAccess.SaveFeaturedProperties(alFeaturedPropertyIDs)
        CDataAccess = Nothing

        ' Clean the Form
        MakeClean()

        ' Inform the User
        TableRowSaved.Visible = True

    End Sub

    Protected Sub ImageButtonUp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonUp.Click

        ' Check we have a Property Selected
        If ListBoxSelectedProperties.SelectedValue <> String.Empty Then

            ' If this is not in the Topmost Position
            If ListBoxSelectedProperties.SelectedIndex > 0 Then

                ' Get Index
                Dim nIndex As Integer = ListBoxSelectedProperties.SelectedIndex

                ' Store Elements
                Dim lbItem1 As ListItem
                Dim lbItem2 As ListItem
                lbItem1 = ListBoxSelectedProperties.Items(nIndex - 1)
                lbItem2 = ListBoxSelectedProperties.Items(nIndex)

                ' Delete Elements
                ListBoxSelectedProperties.Items.Remove(lbItem1)
                ListBoxSelectedProperties.Items.Remove(lbItem2)

                ' Insert Items
                ListBoxSelectedProperties.Items.Insert(nIndex - 1, lbItem2)
                ListBoxSelectedProperties.Items.Insert(nIndex, lbItem1)

            End If

            ' Update Position
            UpdatePosition()

            ' Make Dirty
            MakeDirty()

        End If

    End Sub

    Protected Sub ImageButtonDown_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonDown.Click

        ' Check we have a Property Selected
        If ListBoxSelectedProperties.SelectedValue <> String.Empty Then

            ' If this is not in the Bottom most Position
            If ListBoxSelectedProperties.SelectedIndex < ListBoxSelectedProperties.Items.Count - 1 Then

                ' Get Index
                Dim nIndex As Integer = ListBoxSelectedProperties.SelectedIndex

                ' Store Elements
                Dim lbItem1 As ListItem
                Dim lbItem2 As ListItem
                lbItem1 = ListBoxSelectedProperties.Items(nIndex + 1)
                lbItem2 = ListBoxSelectedProperties.Items(nIndex)

                ' Delete Elements
                ListBoxSelectedProperties.Items.Remove(lbItem1)
                ListBoxSelectedProperties.Items.Remove(lbItem2)

                ' Insert Items
                ListBoxSelectedProperties.Items.Insert(nIndex, lbItem2)
                ListBoxSelectedProperties.Items.Insert(nIndex, lbItem1)

            End If

            ' Update Position
            UpdatePosition()

            ' Make Dirty
            MakeDirty()

        End If

    End Sub

    Protected Sub ImageButtonDown10_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonDown10.Click

        ' Check we have a Property Selected
        If ListBoxSelectedProperties.SelectedValue <> String.Empty Then

            ' Loop 10 Times
            For nIndex = 1 To 10

                ' Move Down
                ImageButtonDown_Click(Nothing, Nothing)

            Next

        End If

    End Sub

    Protected Sub ImageButtonUp10_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonUp10.Click

        ' Check we have a Property Selected
        If ListBoxSelectedProperties.SelectedValue <> String.Empty Then

            ' Loop 10 Times
            For nIndex = 1 To 10

                ' Move Up
                ImageButtonUp_Click(Nothing, Nothing)

            Next

        End If

    End Sub

    Protected Sub ImageButtonBottom_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonBottom.Click

        ' Check we have a Property Selected
        If ListBoxSelectedProperties.SelectedValue <> String.Empty Then

            ' Loop to End
            For nIndex = ListBoxSelectedProperties.SelectedIndex To ListBoxSelectedProperties.Items.Count

                ' Move Down
                ImageButtonDown_Click(Nothing, Nothing)

            Next

        End If

    End Sub

    Protected Sub ImageButtonTop_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonTop.Click

        ' Check we have a Property Selected
        If ListBoxSelectedProperties.SelectedValue <> String.Empty Then

            ' Loop to End
            For nIndex = ListBoxSelectedProperties.SelectedIndex To 1 Step -1

                ' Move Down
                ImageButtonUp_Click(Nothing, Nothing)

            Next

        End If

    End Sub

End Class
