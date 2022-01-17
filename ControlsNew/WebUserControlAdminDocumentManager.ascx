<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminDocumentManager.ascx.vb" Inherits="WebUserControlAdminDocumentManager" %>
<asp:Table ID="TableDocuments" runat="server" Font-Names="Calibri">
    <asp:TableRow ID="TableRowFolderOptions" runat="server">
        <asp:TableCell>
            <asp:Button ID="ButtonNewFolder" runat="server" Text="New Folder" Enabled="false" CssClass="default-button"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" Enabled="false" CssClass="default-button"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="ButtonRename" runat="server" Text="Rename" Enabled="false" CssClass="default-button"/>
        </asp:TableCell>
        <asp:TableCell >
            <asp:FileUpload ID="FileUploadFile" runat="server" Enabled="false"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="ButtonUpload" runat="server" Text="Upload" Enabled="false" CssClass="default-button"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="ButtonDownload" runat="server" Text="Download" Enabled="false" CssClass="default-button"/>
        </asp:TableCell>
        <asp:TableCell>
          ss  <asp:Button ID="ButtonEmail" runat="server" Text="Email" Enabled="false" CssClass="default-button"/>
        </asp:TableCell>
    </asp:TableRow> 
    <asp:TableRow ID="TableRowUpdate" runat="server" Visible="false">
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
            <asp:Label ID="LabelUpdate" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <asp:TextBox ID="TextBoxName" runat="server" Width="98%" AutoCompleteType="None"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="LabelFileExtension" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="default-button"/>
        </asp:TableCell>
    </asp:TableRow> 
    <asp:TableRow ID="TableRowDelete" runat="server" Visible="false">
        <asp:TableCell ColumnSpan="5" HorizontalAlign="Right">
            <asp:Label ID="LabelDelete" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="ButtonDeleteYes" runat="server" Text="Yes" CssClass="default-button"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="ButtonDeleteNo" runat="server" Text="No" CssClass="default-button"/>
        </asp:TableCell>
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell ColumnSpan="7">
            <asp:TreeView ID="TreeViewBrowser" runat="server" Font-Names="Calibri" Font-Size="11" ForeColor="Black" SelectedNodeStyle-BackColor="Silver" BorderColor="Silver" BorderStyle="None">
            </asp:TreeView>
        </asp:TableCell>
    </asp:TableRow> 
    <asp:TableRow ID="TableRowEmailSent" runat="server" Visible="false">
        <asp:TableCell ColumnSpan="7" HorizontalAlign="Center">
            The email has been sent successfully
        </asp:TableCell>
    </asp:TableRow> 
    <asp:TableRow ID="TableRowFileLimitExceeded" runat="server" Visible="false">
        <asp:TableCell ColumnSpan="7" HorizontalAlign="Center" Font-Bold="true" ForeColor="Red">
            The file selected exceeds the maximum file size limit of 3MB
        </asp:TableCell>
    </asp:TableRow> 
</asp:Table>

<asp:Table ID="TableEmailDocument" runat="server" Visible="false" Width="500px">
    <asp:TableRow>
        <asp:TableCell>
            To: <asp:TextBox ID="TextBoxEmailAddress" runat="server" Width="100%"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ID="TableRowProvideEmailAddress" runat="server" Visible="false" HorizontalAlign="Center">
            <strong>Please provide an email address</strong>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Subject: <asp:TextBox ID="TextBoxEmailSubject" runat="server" Width="100%"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxEmailMessage" runat="server" TextMode="MultiLine" Rows="10" Width="100%"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <strong>Attachment: <asp:Label ID="LabelAttachment" runat="server"></asp:Label></strong>
            <asp:Label ID="LabelAttachmentFullPath" runat="server" Visible="false"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Button ID="ButtonSend" runat="server" Text="Send" CssClass="default-button"/> 
            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="default-button"/> 
        </asp:TableCell>            
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ID="TableCellEmailFailed" runat="server" Visible="false" HorizontalAlign="Center">
            <strong>Email sending failed. Please check the email address is valid.</strong>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table> 
