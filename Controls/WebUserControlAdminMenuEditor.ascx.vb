Imports Obout.Ajax.UI.TreeView

Partial Class WebUserControlAdminMenuEditor
    Inherits System.Web.UI.UserControl

    Public Event ReloadNavigation()
    Public Event Message(ByVal szMessage As String)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' If Nodes not Load
        If TreeViewNavigation.Nodes.Count < 1 Then

            ' Load TreeView
            Dim tvNavigation As New Tree
            Dim CNavigation As New ClassNavigation
            CNavigation.LoadTreeView(TreeViewNavigation, True)
            CNavigation = Nothing

            ' Expand All
            TreeViewNavigation.ExpandAll()

            ' Enable Drag and Drop
            TreeViewNavigation.EnableDragAndDrop = True

        End If

    End Sub

    Private Sub MoveNode(Optional ByVal bUp As Boolean = True)

        ' If a Node has been Selected
        If Not TreeViewNavigation.SelectedNode Is Nothing Then

            ' Local Vars
            Dim tnNode As Node = TreeViewNavigation.SelectedNode
            Dim nIndex As Integer
            Dim bNodeSelected As Boolean = False

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

    Protected Sub ImageButtonDown_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonDown.Click
        MoveNode(False)
    End Sub

    Protected Sub ImageButtonUp_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonUp.Click
        MoveNode()
    End Sub

    Protected Sub TreeViewNavigation_SelectedTreeNodeChanged(sender As Object, e As NodeEventArgs) Handles TreeViewNavigation.SelectedTreeNodeChanged

        ' Local Vars
        Dim bVisible As Boolean = False

        ' Do we have a Selected Node?
        If Not TreeViewNavigation.SelectedNode Is Nothing Then

            ' If this is not the Root Node nor the Menu Editor
            If Convert.ToInt32(TreeViewNavigation.SelectedNode.ClientID) > 0 And Not TreeViewNavigation.SelectedNode.Value.StartsWith("LinkButtonMenuEditor") Then

                ' Get the Node
                Dim tnNode As Node = TreeViewNavigation.SelectedNode

                ' Display the Information
                TextBoxText.Text = tnNode.Text.Trim
                CheckBoxAdmin.Checked = Convert.ToBoolean(Convert.ToInt32(tnNode.Value.Substring(tnNode.Value.IndexOf("|") + 1, 1)))
                CheckBoxArchived.Checked = Convert.ToBoolean(Convert.ToInt32(tnNode.Value.Substring(tnNode.Value.IndexOf("~") + 1, 1)))

                ' Make Visible
                bVisible = True

                ' Reselect the Node
                tnNode.Selected = True

            End If

        End If

        ' Set the Display
        TableNode.Visible = bVisible

    End Sub

    Protected Sub TextBoxText_TextChanged(sender As Object, e As EventArgs) Handles TextBoxText.TextChanged

        ' Do we have a Selected Node?
        If Not TreeViewNavigation.SelectedNode Is Nothing Then

            ' Update the Node Text
            TreeViewNavigation.SelectedNode.Text = TextBoxText.Text.Trim

        End If

    End Sub

    Protected Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click

        ' Save this Structure
        Dim CNavigation As New ClassNavigation(TreeViewNavigation.Nodes(0))
        CNavigation.Save()
        CNavigation = Nothing

        ' Reload Navigation
        RaiseEvent ReloadNavigation()

        ' Display Message
        RaiseEvent Message("The navigation menu configuration has been saved")

    End Sub

    Protected Sub CheckBoxAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAdmin.CheckedChanged

        ' Do we have a Selected Node?
        If Not TreeViewNavigation.SelectedNode Is Nothing Then

            ' Update the Node Admin
            TreeViewNavigation.SelectedNode.Value = TreeViewNavigation.SelectedNode.Value.Substring(0, TreeViewNavigation.SelectedNode.Value.IndexOf("|") + 1) & Convert.ToInt32(CheckBoxAdmin.Checked).ToString.Trim & TreeViewNavigation.SelectedNode.Value.Substring(TreeViewNavigation.SelectedNode.Value.IndexOf("~"))

        End If

    End Sub

    Protected Sub CheckBoxArchived_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxArchived.CheckedChanged

        ' Do we have a Selected Node?
        If Not TreeViewNavigation.SelectedNode Is Nothing Then

            ' Update the Node Archive
            TreeViewNavigation.SelectedNode.Value = TreeViewNavigation.SelectedNode.Value.Substring(0, TreeViewNavigation.SelectedNode.Value.IndexOf("~") + 1) & Convert.ToInt32(CheckBoxArchived.Checked).ToString.Trim

            ' Update Archiving in Display
            If CheckBoxArchived.Checked Then
                TreeViewNavigation.SelectedNode.CssClass = "navigation-archived"
            Else
                TreeViewNavigation.SelectedNode.CssClass = String.Empty
            End If

        End If

    End Sub

End Class
