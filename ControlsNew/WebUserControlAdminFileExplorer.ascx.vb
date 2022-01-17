Imports System.IO

Partial Class WebUserControlAdminFileExplorer
    Inherits System.Web.UI.UserControl

    Private Sub LoadDirectory(ByRef tnParent As TreeNode)

        ' Local Vars
        Dim tn As TreeNode

        ' Clear all Child Nodes
        tnParent.ChildNodes.Clear()

        ' Get the Path of the Parent Directory
        Dim szParentDirectory As String = tnParent.Value

        ' Get all the Sub Directories in the Parent Directory
        Dim szDirectories() As String = Directory.GetDirectories(szParentDirectory)

        ' For each Directory
        For Each szDirectory As String In szDirectories

            ' Creating a new Node
            tn = New TreeNode(GetDirectoryName(szDirectory))
            tn.Value = szDirectory
            tn.ImageUrl = "~/Images/Icons/folder.png"

            ' Adding to Parent
            tnParent.ChildNodes.Add(tn)

        Next

        ' Get all the Files in the Parent Directory
        Dim szFiles() As String = Directory.GetFiles(szParentDirectory)

        ' For each File
        For Each szFile As String In szFiles

            ' Creating a new Node
            tn = New TreeNode(Path.GetFileName(szFile))
            tn.Value = szFile

            ' Does this File have an Extention
            If Path.HasExtension(szFile) Then

                ' Do we have an Icon for this File
                If File.Exists(Server.MapPath("~/Images/Icons/" & Path.GetExtension(szFile).Substring(1) & "-32_32.png")) Then

                    ' Set to Icon
                    tn.ImageUrl = "~/Images/Icons/" & Path.GetExtension(szFile).Substring(1) & "-32_32.png"

                Else

                    ' Set to Unknown Icon
                    tn.ImageUrl = "~/Images/Icons/file.png"

                End If

            Else

                ' Set to Unknown Icon
                tn.ImageUrl = "~/Images/Icons/file.png"

            End If

            ' Adding to Parent
            tnParent.ChildNodes.Add(tn)

        Next

        ' Expand Results
        tnParent.Expand()

    End Sub

    Private Function GetDirectoryName(ByVal szFullPath As String) As String

        ' Local Vars
        Dim szRetVal As String

        ' If we have a Trailing Slash
        If szFullPath.EndsWith("\") Then

            ' Remove Trailing Slash
            szRetVal = szFullPath.Substring(0, szFullPath.Length - 1)

        Else

            ' Get Full String
            szRetVal = szFullPath

        End If

        ' Get the Directory Name Only
        szRetVal = szRetVal.Substring(szRetVal.LastIndexOf("\") + 1)

        ' Return the Result
        Return szRetVal

    End Function

    Protected Sub TreeViewBrowser_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeViewBrowser.SelectedNodeChanged

        ' If this Value has a File Extention
        If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

            ' A Directory
            LoadDirectory(TreeViewBrowser.SelectedNode)

        End If

        ' Update Buttons
        Updating(False)

        ' Store the Sected Value
        Session("AdminFileExplorerSelectedNode") = TreeViewBrowser.SelectedNode

    End Sub

    Public Sub LoadData()

        ' If we have a Property
        If Session("AdminPropertySelected") Is Nothing Then

            ' Redirect to Login Page
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Clear any Existing
            TreeViewBrowser.Nodes.Clear()

            ' Local Vars
            Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)

            '' If we haven't already Loaded this
            'If Not CProperty.DocumentsLoaded Then

            ' Init Parent Node
            Dim CDataAccess As New ClassDataAccess
            Dim szParentDirectory As String = AppDomain.CurrentDomain.GetData("DataDirectory") & "\Documents\Properties\" & CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), CProperty.Reference)
            CDataAccess = Nothing

            ' Check if the Directory Exists
            If Not Directory.Exists(szParentDirectory) Then

                ' Create it
                Directory.CreateDirectory(szParentDirectory)

            End If

            ' Add the Parent Node
            Dim tn As New TreeNode(CProperty.Reference)
            tn.Value = szParentDirectory
            tn.ImageUrl = "~/Images/Icons/house.jpg"
            TreeViewBrowser.Nodes.Add(tn)

            ' Select the Root Node
            TreeViewBrowser.Nodes(0).Selected = True
            TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)

            '' Set Flag
            'CProperty.DocumentsLoaded = True

            ' Set back to Global
            Session("AdminPropertySelected") = CProperty

            'End If

        End If

    End Sub

    Protected Sub ButtonDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDownload.Click

        ' If we have a Node Selected
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' Has this Value got a File Extention
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then

                ' A File
                Response.AppendHeader("Content-Disposition", "attachment; filename=" & Path.GetFileName(TreeViewBrowser.SelectedNode.Value))
                Response.TransmitFile(TreeViewBrowser.SelectedNode.Value)
                Response.End()

            End If

        End If

    End Sub

    Protected Sub ButtonRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRename.Click

        ' If we have a Selected Node
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' If this is not the Parent Node
            If Not TreeViewBrowser.SelectedNode.Parent Is Nothing Then

                ' Has this Value got a File Extention
                If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then

                    ' File - Init Fields
                    LabelUpdate.Text = "New Filename:"
                    TextBoxName.Text = TreeViewBrowser.SelectedNode.Text.Substring(0, TreeViewBrowser.SelectedNode.Text.IndexOf("."))
                    LabelFileExtension.Text = TreeViewBrowser.SelectedNode.Text.Substring(TreeViewBrowser.SelectedNode.Text.IndexOf("."))

                Else

                    ' Directory - Init Fields
                    LabelUpdate.Text = "New Directory Name:"
                    TextBoxName.Text = TreeViewBrowser.SelectedNode.Text
                    LabelFileExtension.Text = String.Empty

                End If

                ' Set to Updating
                Updating(True)

                ' Make the Update Row Visible
                TableRowUpdate.Visible = True

                ' Set Mode
                Session("AdminFileExplorerUpdateMode") = "Rename"

            End If

        End If

    End Sub

    Protected Sub ButtonUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpdate.Click

        ' Do we have a Node Selected
        If Not Session("AdminFileExplorerSelectedNode") Is Nothing Then

            ' Has Text Been Added?
            If TextBoxName.Text.Trim <> String.Empty Then

                ' Depending on the Update
                Select Case Session("AdminFileExplorerUpdateMode")

                    Case "Rename"

                        ' Init Updated Flag
                        Dim bUpdated As Boolean = False

                        ' Assign to Local Vars
                        Dim tn As TreeNode = DirectCast(Session("AdminFileExplorerSelectedNode"), TreeNode)

                        ' Is this a File or Directory?
                        If Path.GetExtension(tn.Value) <> String.Empty Then

                            ' Only do the following if Source and Destination differ
                            If tn.Value <> Path.GetDirectoryName(tn.Value) & "\" & TextBoxName.Text.Trim & LabelFileExtension.Text.Trim Then

                                ' File
                                File.Move(tn.Value, Path.GetDirectoryName(tn.Value) & "\" & TextBoxName.Text.Trim & LabelFileExtension.Text.Trim)

                                ' Set Flag
                                bUpdated = True

                            End If

                        Else

                            ' Only do the following if Source and Destination differ
                            If tn.Value <> Directory.GetParent(tn.Value).FullName & "\" & TextBoxName.Text.Trim Then

                                ' Directory
                                Directory.Move(tn.Value, Directory.GetParent(tn.Value).FullName & "\" & TextBoxName.Text.Trim)

                                ' Set Flag
                                bUpdated = True

                            End If

                        End If

                        ' If Updates were made
                        If bUpdated Then

                            ' Update
                            Update(True)

                        End If

                    Case "New"

                        ' Assign to Local Vars
                        Dim tn As TreeNode = DirectCast(Session("AdminFileExplorerSelectedNode"), TreeNode)

                        ' Create the Directory
                        Directory.CreateDirectory(tn.Value & "\" & TextBoxName.Text.Trim)

                        ' Update
                        Update(False)

                End Select

            End If

        End If

        ' Hide Update Row
        TableRowUpdate.Visible = False

        ' Set to Not Updating
        Updating(False)

    End Sub

    Private Function FindNode(ByVal tn As TreeNode, ByVal szValue As String, Optional ByRef tnResult As TreeNode = Nothing) As Boolean

        ' If this Matches, Return the Node
        If tn.Value = szValue Then
            Return True
        End If

        ' Loop through each Node
        For Each tnSub As TreeNode In tn.ChildNodes

            ' Find the Value
            If FindNode(tnSub, szValue, tnResult) Then
                tnResult = tnSub
            End If

        Next

        Return False

    End Function

    Private Sub Update(ByVal bParent As Boolean)

        ' Find Selected
        Dim tn As TreeNode = Nothing
        FindNode(TreeViewBrowser.Nodes(0), DirectCast(Session("AdminFileExplorerSelectedNode"), TreeNode).Value, tn)

        ' If Found, set to Root
        If Not tn Is Nothing Then

            ' If we are Updating the Parent
            If bParent Then

                ' Select Parent
                tn.Parent.Select()

            Else

                ' Select this Node
                tn.Select()

            End If

        Else

            ' Select Root
            TreeViewBrowser.Nodes(0).Select()

        End If

        ' Update
        TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)

    End Sub

    Protected Sub ButtonNewFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNewFolder.Click

        ' If we have a Node Selected
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' If this is a Directory
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                ' Init Fields
                LabelUpdate.Text = "Directory Name:"
                TextBoxName.Text = String.Empty

                ' Set to Updating
                Updating(True)

                ' Display Row
                TableRowUpdate.Visible = True

                ' Set Mode
                Session("AdminFileExplorerUpdateMode") = "New"

            End If

        End If

    End Sub

    Private Sub Updating(ByVal bUpdating As Boolean)

        ' Local Vars
        Dim bRoot As Boolean = False
        Dim bDirectory As Boolean = False
        Dim bFile As Boolean = False

        ' If we are NOT Updating
        If Not bUpdating Then

            ' If the Root Node has been Selected
            If TreeViewBrowser.Nodes(0).Selected Then

                ' Set Flag
                bRoot = True

            End If

            ' If this Value has a File Extention
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                ' Set Flag only if not Root
                If Not bRoot Then
                    bDirectory = True
                End If

            Else

                ' A File - Set Flag
                bFile = True

            End If

            ' If we are in Read Only Mode
            If Convert.ToBoolean(Session("PropertyAdminReadOnly")) Then

                ' Enable / Disable Functionality based on Selection
                ButtonDownload.Enabled = bFile

            Else

                ' Enable / Disable Functionality based on Selection
                ButtonDelete.Enabled = bDirectory Or bFile
                ButtonDownload.Enabled = bFile
                ButtonNewFolder.Enabled = bRoot Or bDirectory
                ButtonRename.Enabled = bDirectory Or bFile
                ButtonUpload.Enabled = bRoot Or bDirectory
                FileUploadFile.Enabled = bRoot Or bDirectory
                HyperLinkEmail.Enabled = bFile

                ' Update HyperLink
                HyperLinkEmail.NavigateUrl = "mailto=''"

            End If

        Else

            ' Updating so Disable ALL
            ButtonDelete.Enabled = False
            ButtonDownload.Enabled = False
            ButtonNewFolder.Enabled = False
            ButtonRename.Enabled = False
            ButtonUpload.Enabled = False
            FileUploadFile.Enabled = False
            HyperLinkEmail.Enabled = False

        End If

    End Sub

    Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click

        ' If a Node has been Selected
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' If this is not the Parent Node
            If Not TreeViewBrowser.SelectedNode.Parent Is Nothing Then

                ' Save the Selected Node
                Session("AdminFileExplorerSelectedNode") = TreeViewBrowser.SelectedNode

                ' Updating
                Updating(True)

                ' Directory / File
                If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                    ' Directory
                    LabelDelete.Text = "Are you sure you want to delete the Directory named " & TreeViewBrowser.SelectedNode.Text & "?"

                Else

                    ' File
                    LabelDelete.Text = "Are you sure you want to delete the File named " & TreeViewBrowser.SelectedNode.Text & "?"

                End If

                ' Display the Row
                TableRowDelete.Visible = True

            End If

        End If

    End Sub

    Protected Sub ButtonDeleteNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDeleteNo.Click

        ' Hide the Delete Row
        TableRowDelete.Visible = False

        ' Not Updating
        Updating(False)

    End Sub

    Protected Sub ButtonDeleteYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDeleteYes.Click

        ' If we have a Selected Node
        If Not Session("AdminFileExplorerSelectedNode") Is Nothing Then

            ' Assign to Local
            Dim tn As TreeNode = DirectCast(Session("AdminFileExplorerSelectedNode"), TreeNode)

            ' Directory / File
            If Path.GetExtension(tn.Value) = String.Empty Then

                ' Directory
                Directory.Delete(tn.Value, True)

            Else

                ' File
                File.Delete(tn.Value)

            End If

            ' Hide the Delete Row
            TableRowDelete.Visible = False

            ' Update
            Update(True)

            ' No Longer Updating
            Updating(False)

        End If

    End Sub

    Protected Sub ButtonUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpload.Click

        ' Is a Node Selected?
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' Is this a Directory?
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                ' Do we have a File to Upload?
                If FileUploadFile.HasFile Then

                    ' Upload Document
                    FileUploadFile.PostedFile.SaveAs(TreeViewBrowser.SelectedNode.Value & "\" & FileUploadFile.FileName)

                    ' Update
                    LoadDirectory(TreeViewBrowser.SelectedNode)

                End If

            End If

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadData()

    End Sub

End Class
