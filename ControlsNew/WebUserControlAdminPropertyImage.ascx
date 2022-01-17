<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminPropertyImage.ascx.vb" Inherits="WebUserControlAdminPropertyImage" %>
<asp:UpdatePanel ID="UpdatePanelPropertyImage" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Table ID="TableImage" runat="server" BorderStyle="Ridge">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="5">
                    <asp:Image ID="ImageProperty" runat="server" Height="150px" Width="200px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:ImageButton ID="ImageButtonLeft" runat="server" ImageUrl="~/Images/Admin/left.jpg" Height="15px" Width="15px"/>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:ImageButton ID="ImageButtonRight" runat="server" ImageUrl="~/Images/Admin/right.jpg" Height="15px" Width="15px"/>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:ImageButton ID="ImageButtonUp" runat="server" ImageUrl="~/Images/Admin/up.jpg" Height="15px" Width="15px"/>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:ImageButton ID="ImageButtonDown" runat="server" ImageUrl="~/Images/Admin/down.jpg" Height="15px" Width="15px"/>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="default-button"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </ContentTemplate>
</asp:UpdatePanel>


