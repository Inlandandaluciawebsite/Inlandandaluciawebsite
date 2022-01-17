<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminFileExplorer.ascx.vb" Inherits="WebUserControlAdminFileExplorer" %>

<asp:UpdatePanel ID="UpdatePanelFileExplorer" runat="server" UpdateMode="Conditional">

    <ContentTemplate>

        <asp:Table ID="TableFileExplorer" runat="server" Font-Names="Calibri">

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="ButtonNewFolder" runat="server" Text="New Folder" Enabled="false" CssClass="default-button" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" Enabled="false" CssClass="default-button" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonRename" runat="server" Text="Rename" Enabled="false" CssClass="default-button" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="FileUploadFile" runat="server" Enabled="false" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonUpload" runat="server" Text="Upload" Enabled="false" CssClass="default-button" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonDownload" runat="server" Text="Download" Enabled="false" CssClass="default-button" />
                </asp:TableCell>
                <asp:TableCell>
                  ss  <asp:HyperLink ID="HyperLinkEmail" runat="server">Email</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell>
                   ss <asp:Button ID="btnBulkLoad" runat="server" Text="Bulk Load" CssClass="default-button" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowUpdate" runat="server" Visible="false">
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                    <asp:Label ID="LabelUpdate" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                    <asp:TextBox ID="TextBoxName" runat="server" Width="100%"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelFileExtension" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="default-button" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowDelete" runat="server" Visible="false">
                <asp:TableCell ColumnSpan="5" HorizontalAlign="Right">
                    <asp:Label ID="LabelDelete" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonDeleteYes" runat="server" Text="Yes" CssClass="default-button" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonDeleteNo" runat="server" Text="No" CssClass="default-button" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="7">
                    <asp:TreeView ID="TreeViewBrowser" runat="server" Font-Names="Calibri" Font-Size="11" ForeColor="Black" SelectedNodeStyle-BackColor="Silver" BorderColor="Silver" BorderStyle="None">
                    </asp:TreeView>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>

    </ContentTemplate>

    <Triggers>
        <asp:PostBackTrigger ControlID="ButtonUpload" />
        <asp:PostBackTrigger ControlID="ButtonDownload" />
    </Triggers>

</asp:UpdatePanel>
