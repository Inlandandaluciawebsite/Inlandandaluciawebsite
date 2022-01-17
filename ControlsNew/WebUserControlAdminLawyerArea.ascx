<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminLawyerArea.ascx.vb" Inherits="WebUserControlAdminLawyerArea" %>
<%@ Register src="~/ControlsNew/WebUserControlAdminDocumentManager.ascx" tagname="AdminDocumentManager" tagprefix="ucAdminDocumentManager" %>
<%--<%@ Register src="~/ControlsNew/WebUserControlAdminContact.ascx" tagname="AdminContact" tagprefix="ucAdminContact" %>
<%@ Register src="~/ControlsNew/WebUserControlAdminBuyer.ascx" tagname="AdminBuyer" tagprefix="ucAdminBuyer" %>--%>
<h1>Lawyer Area</h1>
<br />
<h3><asp:Label ID="LabelWelcome" runat="server"></asp:Label></h3>
<br />
<asp:Table ID="TablePropertySelection" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            Property
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListProperty" runat="server" AutoPostBack="true" ></asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<asp:Table ID="TableOptions" runat="server" Width="100%" Visible="false">
    <asp:TableRow>
        <asp:TableCell Width="33%">
            <asp:LinkButton ID="LinkButtonBuyer" runat="server">Buyer's Details</asp:LinkButton>
        </asp:TableCell>
        <asp:TableCell Width="34%">
            <asp:LinkButton ID="LinkButtonVendor" runat="server">Vendor's Details</asp:LinkButton>
        </asp:TableCell>
        <asp:TableCell Width="33%">
            <asp:LinkButton ID="LinkButtonDocuments" runat="server">Property Documents</asp:LinkButton>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<asp:PlaceHolder ID="PlaceHolderBuyer" runat="server" Visible="false">
    <h3>Buyer</h3>
    <ucAdminBuyer:AdminBuyer ID="AdminBuyer" runat="server"/> 
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolderVendor" runat="server" Visible="false">
    <h3>Vendor</h3>
    <ucAdminContact:AdminContact ID="AdminContact" runat="server"/> 
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolderDocuments" runat="server" Visible="false">
    <h3>Documents</h3>
    <ucAdminDocumentManager:AdminDocumentManager ID="AdminDocumentManager" runat="server"/> 
</asp:PlaceHolder>