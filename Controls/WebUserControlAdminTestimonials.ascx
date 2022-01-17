<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminTestimonials.ascx.vb" Inherits="WebUserControlAdminTestimonials" %>
<%@ Reference Control="~/Controls/WebUserControlAdminTestimonial.ascx" %>
<h1>Testimonials</h1>
<p></p>
<asp:Table ID="TableTestimonial" runat="server" Width="100%">
    <asp:TableRow>
        <asp:TableCell Width="200px">
            <strong><asp:Label ID="LabelDate" runat="server" Text="Date (dd/mm/yyyy)"></asp:Label></strong>
        </asp:TableCell>
        <asp:TableCell>
            <strong><asp:Label ID="LabelTestimonial" runat="server" Text="Testimonial"></asp:Label></strong>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<p></p>