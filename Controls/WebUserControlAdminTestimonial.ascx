<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminTestimonial.ascx.vb" Inherits="WebUserControlAdminTestimonial" %>
<%@ Register src="~/Controls/WebUserControlAdminDatePicker.ascx" tagname="AdminDatePicker" tagprefix="ucAdminDatePicker" %>
<asp:Table ID="TableTestimonial" runat="server" Width="100%">
    <asp:TableRow>
        <asp:TableCell Width="200px" VerticalAlign="Top">
            <ucAdminDatePicker:AdminDatePicker id="AdminDatePicker" runat="server" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxTestimonial" runat="server" TextMode="MultiLine" Rows="10" Width="100%" AutoPostBack="true"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Table ID="TableSaved" runat="server" Width="100%">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <strong><asp:Label ID="LabelSaved" runat="server" Text="Saved" Visible="false" ForeColor="White" BackColor="Red"></asp:Label></strong> <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="default-button"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Timer ID="TimerSaved" runat="server" Interval="5000" OnTick="HideSaved" Enabled="false">
</asp:Timer>
