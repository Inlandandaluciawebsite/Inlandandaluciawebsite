<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminLocation.ascx.vb" Inherits="WebUserControlAdminLocation" %>
<asp:Table ID="TableLocation" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelCountry" runat="server" Text="Country"></asp:Label>
        </asp:TableCell>        
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListCountry" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </asp:TableCell>        
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelArea" runat="server" Text="Area"></asp:Label>
        </asp:TableCell>        
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListRegion" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </asp:TableCell>        
    </asp:TableRow>
    <asp:TableRow ID="TableRowArea" runat="server">
        <asp:TableCell>
            <asp:Label ID="LabelTown" runat="server" Text="Town"></asp:Label>
        </asp:TableCell>        
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListArea" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </asp:TableCell>        
    </asp:TableRow>
    <asp:TableRow ID="TableRowSubArea" runat="server">
        <asp:TableCell>
            <asp:Label ID="LabelVillage" runat="server" Text="Village"></asp:Label>
        </asp:TableCell>        
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListSubArea" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </asp:TableCell>        
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelPostcode" runat="server" Text="Postcode"></asp:Label>
        </asp:TableCell>        
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListPostcode" runat="server" AutoPostBack="true"></asp:DropDownList>
        </asp:TableCell>        
    </asp:TableRow>
</asp:Table>