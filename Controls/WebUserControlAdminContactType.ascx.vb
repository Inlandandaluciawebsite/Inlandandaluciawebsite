Imports Obout.Ajax.UI.TreeView

Partial Class WebUserControlAdminContactType
    Inherits System.Web.UI.UserControl

    Public Event ReloadNavigation()
    Public Event Message(ByVal szMessage As String)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        ' Add the Contact Options
        CheckBoxListOptions.Items.Add(New ListItem("Registration Number"))
        CheckBoxListOptions.Items.Add(New ListItem("Address"))
        CheckBoxListOptions.Items.Add(New ListItem("Telephone"))
        CheckBoxListOptions.Items.Add(New ListItem("Mobile"))
        CheckBoxListOptions.Items.Add(New ListItem("Fax"))
        CheckBoxListOptions.Items.Add(New ListItem("Email"))
        CheckBoxListOptions.Items.Add(New ListItem("Notes"))
        CheckBoxListOptions.Items.Add(New ListItem("Login"))
        CheckBoxListOptions.Items.Add(New ListItem("Language"))
        CheckBoxListOptions.Items.Add(New ListItem("Partner"))
        CheckBoxListOptions.Items.Add(New ListItem("Broker"))
        CheckBoxListOptions.Items.Add(New ListItem("Image"))
        CheckBoxListOptions.Items.Add(New ListItem("Commission"))

        ' Check All Options
        For Each li As ListItem In CheckBoxListOptions.Items
            li.Selected = True
        Next

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' If Nodes not Load
        If TreeViewNavigation.Nodes.Count < 1 Then

            ' Load Menu Structure
            Dim CNavigation As New ClassNavigation
            CNavigation.LoadTreeView(TreeViewNavigation)
            CNavigation = Nothing

            ' Add New Parent Node
            Dim tnParent As New Node("New Contact Type")
            tnParent.ClientID = Int32.MaxValue

            ' Add Child Node
            Dim tnChild As New Node("+")
            tnChild.ClientID = Int32.MaxValue - 1

            ' Add to Parent
            tnParent.ChildNodes.Add(tnChild)

            ' Add to Root
            TreeViewNavigation.Nodes(0).ChildNodes.Add(tnParent)

            ' Expand All
            TreeViewNavigation.ExpandAll()

            ' Enable Drag and Drop
            TreeViewNavigation.EnableDragAndDrop = True

        End If

    End Sub

    Private Sub MoveNode(Optional ByVal bUp As Boolean = True)

        ' Local Vars
        Dim tnNode As Node = Nothing

        ' Apply the Name
        FindNode(Int32.MaxValue, TreeViewNavigation.Nodes(0), tnNode)

        ' Did we find the Node
        If Not tnNode Is Nothing Then

            ' Local Vars
            Dim nIndex As Integer
            Dim bNodeSelected = False

            ' Get Parent
            Dim tnParent As Node = tnNode.Parent

            ' If we have a Parent
            If Not tnParent Is Nothing Then

                ' Get the Index
                nIndex = tnParent.ChildNodes.IndexOf(tnNode)

                ' If this is Up
                If bUp Then

                    ' If not the First
                    If nIndex > 0 Then

                        ' Move
                        tnParent.ChildNodes.RemoveAt(nIndex)
                        tnParent.ChildNodes.AddAt(nIndex - 1, tnNode)

                        ' Select the Node
                        tnParent.ChildNodes(nIndex - 1).Selected = True

                        ' Set Flag
                        bNodeSelected = True

                    End If

                Else

                    ' If not the Last
                    If nIndex < tnParent.ChildNodes.Count - 1 Then

                        ' Move
                        tnParent.ChildNodes.RemoveAt(nIndex)
                        tnParent.ChildNodes.AddAt(nIndex + 1, tnNode)

                        ' Select the Node
                        tnParent.ChildNodes(nIndex + 1).Selected = True

                        ' Set Flag
                        bNodeSelected = True

                    End If

                End If

            ElseIf TreeViewNavigation.Nodes.Contains(tnNode) Then

                ' Get the Index
                nIndex = TreeViewNavigation.Nodes.IndexOf(tnNode)

                ' If Up
                If bUp Then

                    ' If this is not the First
                    If nIndex > 0 Then

                        ' Move
                        TreeViewNavigation.Nodes.RemoveAt(nIndex)
                        TreeViewNavigation.Nodes.AddAt(nIndex - 1, tnNode)

                        ' Select the Node
                        TreeViewNavigation.Nodes(nIndex - 1).Selected = True

                        ' Set Flag
                        bNodeSelected = True

                    End If

                Else

                    ' If this is not the Last
                    If nIndex < TreeViewNavigation.Nodes.Count - 1 Then

                        ' Move
                        TreeViewNavigation.Nodes.RemoveAt(nIndex)
                        TreeViewNavigation.Nodes.AddAt(nIndex + 1, tnNode)

                        ' Select the Node
                        TreeViewNavigation.Nodes(nIndex + 1).Selected = True

                        ' Set Flag
                        bNodeSelected = True

                    End If

                End If

            End If

            ' If we haven't Selected a Node
            If Not bNodeSelected Then

                ' Select the New Node
                tnNode.Selected = True

            End If

        End If

    End Sub

    Private Sub FindNode(ByVal szID As String, ByRef tn As Node, ByRef tnRetVal As Node)

        ' If this the Node?
        If tn.ClientID.Trim = szID.Trim Then

            ' Return
            tnRetVal = tn

        Else

            ' For each Child Node
            For Each tnChild As Node In tn.ChildNodes

                ' Find the Node
                FindNode(szID, tnChild, tnRetVal)

            Next

        End If

    End Sub

    Private Function GetNewNode() As Node

        ' Local Vars
        Dim tn As Node = Nothing

        ' Apply the Name
        FindNode(Int32.MaxValue, TreeViewNavigation.Nodes(0), tn)

        ' If Found
        If Not tn Is Nothing Then

            ' Return the Result
            Return tn

        Else

            ' Return NULL
            Return Nothing

        End If

    End Function

    Protected Sub TextBoxName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxName.TextChanged

        ' Local Vars
        Dim tn As Node = GetNewNode()

        ' If Found
        If Not tn Is Nothing Then

            ' If the Text is Empty
            If TextBoxName.Text.Trim = String.Empty Then

                ' Set Default
                tn.Text = "New Menu Item"

            Else

                ' Set the Text
                tn.Text = TextBoxName.Text.Trim

            End If

            ' Select the Node
            tn.Selected = True

        End If

        ' Set Save Visibility
        ButtonSave.Visible = (TextBoxName.Text.Trim <> String.Empty)

    End Sub

    Protected Sub ImageButtonDown_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonDown.Click
        MoveNode(False)
    End Sub

    Protected Sub ImageButtonUp_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonUp.Click
        MoveNode()
    End Sub

    Protected Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click

        ' Check we have a Name for the new Contact Type
        If TextBoxName.Text.Trim <> String.Empty Then

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Add the Contact Type
            Dim nContactTypeID As Integer = CDataAccess.AddContactType(TextBoxName.Text.Trim)

            ' Save the Options
            CDataAccess.SaveContactTypeOptions(nContactTypeID,
                                               CheckBoxListOptions.Items(0).Selected,
                                               CheckBoxListOptions.Items(1).Selected,
                                               CheckBoxListOptions.Items(2).Selected,
                                               CheckBoxListOptions.Items(3).Selected,
                                               CheckBoxListOptions.Items(4).Selected,
                                               CheckBoxListOptions.Items(5).Selected,
                                               CheckBoxListOptions.Items(6).Selected,
                                               CheckBoxListOptions.Items(7).Selected,
                                               CheckBoxListOptions.Items(8).Selected,
                                               CheckBoxListOptions.Items(9).Selected,
                                               CheckBoxListOptions.Items(10).Selected,
                                               CheckBoxListOptions.Items(11).Selected,
                                               CheckBoxListOptions.Items(12).Selected)

            ' Tidy
            CDataAccess = Nothing

            ' Update the New Nodes
            GetNewNode.Value = "LinkButtonContactSearch#" & nContactTypeID.ToString.Trim & "|" & Convert.ToInt32(CheckBoxAdmin.Checked).ToString.Trim & "~0"
            GetNewNode.ChildNodes(0).Value = "LinkButtonContactAdd#" & nContactTypeID.ToString.Trim & "|" & Convert.ToInt32(CheckBoxAdmin.Checked).ToString.Trim & "~0"

            ' Create Navigation Menu from Tree
            Dim CNavigation As New ClassNavigation(TreeViewNavigation.Nodes(0))

            ' Save
            CNavigation.Save()

            ' Tidy
            CNavigation = Nothing

            ' Reload Navigation
            RaiseEvent ReloadNavigation()

            ' Display Message
            RaiseEvent Message("The new contact type has been saved")

        End If

    End Sub

End Class
