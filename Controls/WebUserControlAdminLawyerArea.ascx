<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminLawyerArea.ascx.vb" Inherits="WebUserControlAdminLawyerArea" %>
<%@ Register Src="~/Controls/WebUserControlAdminDocumentManager.ascx" TagName="AdminDocumentManager" TagPrefix="ucAdminDocumentManager" %>
<%@ Register Src="~/Controls/WebUserControlAdminContact.ascx" TagName="AdminContact" TagPrefix="ucAdminContact" %>
<%@ Register Src="~/Controls/WebUserControlAdminBuyer.ascx" TagName="AdminBuyer" TagPrefix="ucAdminBuyer" %>
<h1>Lawyer Area</h1>
<br />
<h3>
    <asp:Label ID="LabelWelcome" runat="server"></asp:Label></h3>
<br />
<asp:Button ID="lnkbtn" runat="server" OnClick="LinkButton2_Click" Text="View List" CssClass="default-button"></asp:Button>

<asp:Table ID="tblgrid" runat="server" Width="100%">
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="grdAdmin" DataKeyNames="id" OnRowCommand="grdAdmin_RowCommand" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" TabIndex="0" runat="server" AutoGenerateColumns="false" GridLines="None"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt">

                <Columns>

                    <asp:TemplateField HeaderText="Property Reference" HeaderStyle-Width="219px" HeaderStyle-Height="20px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval("Reference") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name" HeaderStyle-Width="219px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval("Name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telephone" HeaderStyle-Width="219px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval("Telephone")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" HeaderStyle-Width="219px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval("Email")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Detail" HeaderStyle-Width="219px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblbuyer" runat="server" Text='<%#IIf(Convert.ToString(Eval("IsBuyerVendor")) = "Buyer", "Buyer Detail", "Vendor Detail")%>' CommandName='<%#Eval("IsBuyerVendor") %>'
                                CommandArgument='<%#IIf(Convert.ToString(Eval("IsBuyerVendor")) = "Buyer", Eval("Buyer_Id").ToString(), Eval("Vendor_Id").ToString())%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Document" HeaderStyle-Width="219px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgView" runat="server" CommandArgument='<%#Eval("id") %>' ToolTip="Click to view Document " CommandName="document" ImageUrl="~/AdminNew/images/view-img.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:TableCell>

    </asp:TableRow>
</asp:Table>
<asp:Table ID="TablePropertySelection" runat="server" Visible="false">
    <asp:TableRow>
        <asp:TableCell>
            Property
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListProperty" runat="server" AutoPostBack="true"></asp:DropDownList>
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
    <ucAdminBuyer:AdminBuyer ID="AdminBuyer" runat="server" />
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolderVendor" runat="server" Visible="false">
    <h3>Vendor</h3>
    <ucAdminContact:AdminContact ID="AdminContact" runat="server" />
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolderDocuments" runat="server" Visible="false">
    <h3>Documents</h3>
    <ucAdminDocumentManager:AdminDocumentManager ID="AdminDocumentManager" runat="server" />
</asp:PlaceHolder>
