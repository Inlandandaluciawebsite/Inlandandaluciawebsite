Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports inland_api
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Net.Mail


Partial Class AdminNew_Property_Documents
    Inherits System.Web.UI.Page
    Dim CDataAccess As New ClassDataAccess
    Dim CUtilities As New ClassUtilities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            lblpropref.Text = Request.QueryString("PropertyRef").ToString()
            LoadTree()
            'Bind LBLIssue value
            Dim sqlPropertyDetails As SqlParameter() = New SqlParameter(1) {}
            sqlPropertyDetails(0) = New SqlParameter("@Property_ID", Request.QueryString("PropertyId").ToString())
            Dim dtPropertyDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Select_By_PropertyId", sqlPropertyDetails).Tables(0)
            If dtPropertyDetails.Rows.Count > 0 Then
                chkIsIssues.Checked = Convert.ToBoolean(dtPropertyDetails.Rows(0)("IsIssue").ToString())
            End If
            If Not Request.QueryString("PropertyId") = "" Then
                hdcont.Value = Request.QueryString("PropertyId")
                hdpageind.Value = Request.QueryString("PageIndex")
                Dim url As String = Request.UrlReferrer.ToString()
                'Dim url As String = "http://localhost:59926/AdminNew/AddProperty.aspx?PropertyId=29696&PageIndex=1&Ref=&Address=&type=0&Area=0&Town=0&Beds=0&Bath=0&status=0"
                Dim uri = New Uri(url)
                Dim qs = HttpUtility.ParseQueryString(uri.Query)
                'qs.[Set]("ID", hdcont.Value)
                If url.Contains("ManageProperties.aspx") Then
                    qs.[Set]("PageIndex", hdpageind.Value)
                    qs.[Set]("Ref", Request.QueryString("Ref"))
                    qs.[Set]("Address", Request.QueryString("Address"))
                    qs.[Set]("type", Request.QueryString("type"))
                    qs.[Set]("Area", Request.QueryString("Area"))
                    qs.[Set]("Town", Request.QueryString("Town"))
                    qs.[Set]("Beds", Request.QueryString("Beds"))
                    qs.[Set]("Bath", Request.QueryString("Bath"))
                    qs.[Set]("status", Request.QueryString("status"))
                End If
                If url.Contains("LatestProperties.aspx") Then
                    qs.[Set]("Duration", Request.QueryString("Duration"))
                    qs.[Set]("Created", Request.QueryString("Created"))
                    qs.[Set]("Modified", Request.QueryString("Modified"))
                End If
                If url.Contains("Novideos.aspx") Then
                    qs.[Set]("PageIndex", hdpageind.Value)
                End If
                Dim uriBuilder = New UriBuilder(uri)
                uriBuilder.Query = qs.ToString()
                Dim newUri = uriBuilder.Uri
                hdnprevurl.Value = newUri.ToString()

            End If
        End If
    End Sub
    Public Sub LoadTree()
        ''''''''''''''''''''''''''''''''
        TreeViewBrowser.Nodes.Clear()
        ' Init Parent Node
        Dim szParentDirectory As String = AppDomain.CurrentDomain.GetData("DataDirectory") & "\Documents\Properties\" & CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), Request.QueryString("PropertyRef").ToString())
        ' Check if the Directory Exists
        If Not Directory.Exists(szParentDirectory) Then
            ' Create it
            Directory.CreateDirectory(szParentDirectory)
        End If
        ' Add the Parent Node
        Dim tn As New TreeNode(Request.QueryString("PropertyRef").ToString())
        tn.Value = szParentDirectory
        tn.ImageUrl = "~/Images/Icons/house.jpg"
        TreeViewBrowser.Nodes.Add(tn)
        ' Select the Root Node
        TreeViewBrowser.Nodes(0).Selected = True
        TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)
    End Sub
    Protected Sub btnPropertyGeneral_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_General.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyDescription_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Description.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyImages_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Images.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyFeatures_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Features.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyHistory_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_History.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyDocuments_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Documents.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub ButtonUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpload.Click
        ' Is a Node Selected?
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' Is this a Directory?
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

                For Each postedFile As HttpPostedFile In FileUploadFile.PostedFiles

                    ' Do we have a File to Upload?
                    If FileUploadFile.HasFile Then

                        ' File Size
                        If postedFile.ContentLength < 3145728 Then

                            ' Upload Document
                            postedFile.SaveAs(TreeViewBrowser.SelectedNode.Value & "\" & postedFile.FileName)

                            ' Update
                            LoadDirectory(TreeViewBrowser.SelectedNode)

                        Else

                            ' Display the Error Message
                            TableRowFileLimitExceeded.Visible = True

                        End If

                    End If
                Next


            End If

        End If

    End Sub
    Protected Sub ButtonDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDownload.Click

        ' If we have a Node Selected
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            ' Has this Value got a File Extention
            If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then

                ' A File
                Response.AppendHeader("Content-Disposition", "attachment; filename=" & Chr(34) & Path.GetFileName(TreeViewBrowser.SelectedNode.Value) & Chr(34))
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
                    LabelFileExtension.Text = Path.GetFileName(TreeViewBrowser.SelectedNode.Value).Substring(Path.GetFileName(TreeViewBrowser.SelectedNode.Value).IndexOf("."))

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
    Protected Sub ButtonMoveYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonMoveYes.Click

        ' If we have a Selected Node
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            If Convert.ToInt32(hdsource.Value) > 0 Then

                Dim bUpdated As Boolean = False
                LabelUpdate.Text = "New Directory Name:"
                TextBoxName.Text = Path.GetFullPath(TreeViewBrowser.SelectedNode.Value)
                If Not Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then
                    If Not Path.GetExtension(lblsourcefile.Text) <> String.Empty Then


                        Dim drjj = Path.GetFileName(lblsourcefile.Text)
                        Dim dest As String = Path.Combine(TextBoxName.Text, drjj)
                        Directory.Move(lblsourcefile.Text, dest)
                        'Next
                        hdsource.Value = 0
                        TableRowMove.Visible = False
                        bUpdated = True
                    Else

                        Dim drjj = Path.GetFileName(lblsourcefile.Text)
                        Dim dest As String = Path.Combine(TextBoxName.Text, drjj)
                        File.Move(lblsourcefile.Text, dest)
                        hdsource.Value = 0
                        TableRowMove.Visible = False
                        bUpdated = True

                    End If
                Else
                    TableRowMove.Visible = True
                    lblMove.Text = "Please select destination directory"
                    ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
                    ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")
                End If


                If (bUpdated) Then
                    Update(True)
                End If
            End If
        Else
            lblMove.Text = "Please select directory/File to move"
            ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
            ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If

    End Sub
    Protected Sub BtnMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMove.Click
        If Not TreeViewBrowser.SelectedNode Is Nothing Then

            If Convert.ToInt32(hdsource.Value) = 0 Then
                hdsource.Value = 1
                TableRowMove.Visible = True
                lblMove.Text = "please select destination directory"
                ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
                ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")
                ' Has this Value got a File Extention
                If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) <> String.Empty Then

                    ' File - Init Fields
                    LabelUpdate.Text = "New Filename:"
                    TextBoxName.Text = Path.GetFullPath(TreeViewBrowser.SelectedNode.Value)
                    LabelFileExtension.Text = Path.GetFileName(TreeViewBrowser.SelectedNode.Value).Substring(Path.GetFileName(TreeViewBrowser.SelectedNode.Value).IndexOf("."))
                    lblsourcefile.Text = TextBoxName.Text
                Else

                    ' Directory - Init Fields
                    LabelUpdate.Text = "New Directory Name:"
                    TextBoxName.Text = Path.GetFullPath(TreeViewBrowser.SelectedNode.Value)
                    LabelFileExtension.Text = String.Empty
                    lblsourcefile.Text = TextBoxName.Text
                End If

            Else
                If Not TreeViewBrowser.SelectedNode Is Nothing Then

                    If (Path.GetFileName(lblsourcefile.Text) = Path.GetFileName(TreeViewBrowser.SelectedNode.Value)) Then
                        TableRowMove.Visible = True
                        lblMove.Text = "please select different destination directory"
                        ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
                        ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")
                    Else
                        If Path.GetExtension(lblsourcefile.Text) <> String.Empty Then

                            lblMove.Text = "Are you sure you want to move " & Path.GetFileName(lblsourcefile.Text) & " file"


                        Else
                            lblMove.Text = "Are you sure you want to move " & Path.GetFileName(lblsourcefile.Text) & " directory"

                        End If
                        TableRowMove.Visible = True
                        ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "block")
                        ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "block")
                    End If
                    ' Set to Updating
                    ' Updating(True)

                    ' Make the Update Row Visible


                    ' Set Mode
                    'Session("AdminFileExplorerUpdateMode") = "Rename"
                End If

            End If

        Else

            lblMove.Text = "Please select directory/File to move"
            ButtonMoveYes.Style.Add(HtmlTextWriterStyle.Display, "none")
            ButtonMoveNo.Style.Add(HtmlTextWriterStyle.Display, "none")

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
                    LabelDelete.Text = "Are you sure you want to delete the File named " & Path.GetFileName(TreeViewBrowser.SelectedNode.Value) & "?"

                End If

                ' Display the Row
                TableRowDelete.Visible = True

            End If

        End If

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
    Protected Sub ButtonMoveNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonMoveNo.Click

        ' Hide the Delete Row
        TableRowMove.Visible = False
        hdsource.Value = 0
        ' Not Updating
        Updating(False)

    End Sub
    Protected Sub ButtonDeleteNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDeleteNo.Click

        ' Hide the Delete Row
        TableRowDelete.Visible = False

        ' Not Updating
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
    Protected Sub ButtonEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmail.Click

        ' Set to Updating
        Updating(True)

        ' Hide the Document Table
        TableDocuments.Visible = False

        ' Hide the Property Ref Label
        '  LabelPropertyReference.Visible = False

        ' Hide Category Selection
        ' ListBoxCategory.Visible = False

        ' Hide Save Button
        '  ButtonSave.Visible = False

        ' Init Fields
        TextBoxEmailAddress.Text = String.Empty
        TextBoxEmailSubject.Text = String.Empty
        TextBoxEmailMessage.Text = String.Empty

        ' Update Attachment
        LabelAttachment.Text = TreeViewBrowser.SelectedNode.Text.Trim
        LabelAttachmentFullPath.Text = TreeViewBrowser.SelectedNode.Value.Trim

        ' Display the Email Table
        TableEmailDocument.Visible = True

    End Sub
    Protected Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click

        ' Hide the Table
        TableEmailDocument.Visible = False

        ' Display the Property Ref Label
        'LabelPropertyReference.Visible = True

        '' Display Category Selection
        'ListBoxCategory.Visible = True

        '' Show Save Button
        'ButtonSave.Visible = True

        ' Display the Documents Table
        TableDocuments.Visible = True

        ' Reselect Parent
        TreeViewBrowser.Nodes(0).Selected = True
        TreeViewBrowser_SelectedNodeChanged(Nothing, Nothing)

        ' No longer Updating
        Updating(False)

    End Sub
    Protected Sub TreeViewBrowser_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeViewBrowser.SelectedNodeChanged

        ' If this Value has a File Extention
        If Path.GetExtension(TreeViewBrowser.SelectedNode.Value) = String.Empty Then

            ' A Directory
            LoadDirectory(TreeViewBrowser.SelectedNode)

        End If

        ' If the Form is Enabled
        '  If ButtonSave.Visible Then

        ' Update Buttons
        Updating(False)

        ' End If

        ' Store the Selected Value
        Session("AdminFileExplorerSelectedNode") = TreeViewBrowser.SelectedNode

    End Sub
    Private Sub LoadDirectory(ByRef tnParent As TreeNode)

        ' Local Vars
        Dim tn As TreeNode
        Dim fi As FileInfo
        Dim szFileSize As String

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

            ' Get the File Info
            fi = New FileInfo(szFile)

            ' Set File Size
            If fi.Length < 1000 Then
                szFileSize = fi.Length & " B"
            ElseIf fi.Length >= 1000 And fi.Length < 1000000 Then
                szFileSize = Math.Round(fi.Length / 1000) & " KB"
            Else
                szFileSize = Math.Round(fi.Length / 1000000, 2) & " MB"
            End If

            ' Creating a new Node
            tn = New TreeNode(fi.Name & " (" & szFileSize.Trim & ")")
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

            ' If we have a Selected Node
            If Not TreeViewBrowser.SelectedNode Is Nothing Then

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

                ' If we are not in Read Only Mode
                If Not Convert.ToBoolean(Session("PropertyAdminReadOnly")) Then

                    '    ' Enable / Disable Functionality based on Selection
                    '    ButtonDownload.Enabled = bFile

                    'Else

                    ' Enable / Disable Functionality based on Selection
                    ButtonDelete.Enabled = bDirectory Or bFile
                    ButtonDownload.Enabled = bFile
                    ButtonNewFolder.Enabled = bRoot Or bDirectory
                    ButtonRename.Enabled = bDirectory Or bFile
                    btnMove.Enabled = bRoot Or bDirectory Or bFile
                    ButtonUpload.Enabled = bRoot Or bDirectory
                    FileUploadFile.Enabled = bRoot Or bDirectory
                    ButtonEmail.Enabled = bFile

                End If

            End If

            ' Enable Tree View
            TreeViewBrowser.Enabled = True

        Else

            ' Updating so Disable ALL
            ButtonDelete.Enabled = False
            ButtonDownload.Enabled = False
            ButtonNewFolder.Enabled = False
            ButtonRename.Enabled = False

            ButtonUpload.Enabled = False
            FileUploadFile.Enabled = False
            ButtonEmail.Enabled = False

            ' Disable Tree View
            TreeViewBrowser.Enabled = False

        End If

    End Sub
    Protected Sub btndocument_Click(sender As Object, e As EventArgs)
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@Property_Id", Convert.ToInt32(Request.QueryString("PropertyId").ToString()))
        sql(1) = New SqlParameter("@IsIssue", chkIsIssues.Checked)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_IsIssue", sql)

        lbldocument.Text = "Property Documents Saved !"
    End Sub
    Protected Sub chkIsIssues_CheckedChanged(sender As Object, e As EventArgs)
        btndocument.BackColor = Drawing.Color.Red
        btndocument.ForeColor = Drawing.Color.White
        btndocument.Font.Bold = True
    End Sub
    Protected Sub ButtonSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSend.Click

        ' Ensure we have an Email Address
        If TextBoxEmailAddress.Text.Trim = String.Empty Then

            ' Display Error
            TableRowProvideEmailAddress.Visible = True

        Else

            ' Define a New Email
            Dim CEmail As New ClassEmail

            ' Send the Email
            If CEmail.SendEmail(TextBoxEmailAddress.Text.Trim, TextBoxEmailSubject.Text.Trim, TextBoxEmailMessage.Text.Trim, False, LabelAttachmentFullPath.Text.Trim, False) Then

                ' Display Success Message
                TableRowEmailSent.Visible = True

                ' Close Email Table
                ButtonCancel_Click(Nothing, Nothing)

            Else

                ' Display Failure Message
                TableCellEmailFailed.Visible = True

            End If

            ' Tidy
            CEmail = Nothing

        End If

    End Sub
End Class
