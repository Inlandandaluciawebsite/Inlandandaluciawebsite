<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminPropertySearch.ascx.vb" Inherits="WebUserControlAdminPropertySearch" %>

<h1><asp:Label ID="LabelPropertySearch" runat="server" Text="Property Search"></asp:Label></h1>
<p>&nbsp;</p>

<asp:Table ID="TablePropertySearch" runat="server" Width="50%">
    <asp:TableRow>
        <asp:TableCell Width="80px">
            <asp:Label ID="LabelReference" runat="server" Text="Reference"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell ColumnSpan="6">
            <asp:TextBox ID="TextBoxReference" runat="server" style="text-transform:uppercase"></asp:TextBox>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelAddress" runat="server" Text="Address"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell ColumnSpan="6">
            <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell> 
        <asp:TableCell ColumnSpan="6">
            <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="default-button" />
        </asp:TableCell> 
    </asp:TableRow> 
</asp:Table>
<asp:Table ID="TableFiltersResults" runat="server">
    <asp:TableRow ID="TableRowFilters" runat="server" Visible="false">
        <asp:TableCell>
            Type: <asp:DropDownList ID="DropDownListType" runat="server" AutoPostBack="true"></asp:DropDownList>
        </asp:TableCell>        
        <asp:TableCell>
 <asp:DropDownList ID="DropDownListCountry" runat="server" AutoPostBack="true" style="display:none"></asp:DropDownList>
        </asp:TableCell>        
        <asp:TableCell>
            Area: <asp:DropDownList ID="DropDownListArea" runat="server" AutoPostBack="true"></asp:DropDownList>
        </asp:TableCell>        
        <asp:TableCell>
            Town: <asp:DropDownList ID="DropDownListTown" runat="server" AutoPostBack="true"></asp:DropDownList>
        </asp:TableCell>                
        <asp:TableCell>
            Beds: <asp:DropDownList ID="DropDownListBedrooms" runat="server" AutoPostBack="true"></asp:DropDownList>
        </asp:TableCell>                
        <asp:TableCell>
            Baths: <asp:DropDownList ID="DropDownListBathrooms" runat="server" AutoPostBack="true"></asp:DropDownList>
        </asp:TableCell>                
        <asp:TableCell>
            Status: <asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="true"></asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRowNoOfResults" runat="server" Visible="false" HorizontalAlign="Right">
        <asp:TableCell ColumnSpan="7">
            <strong><asp:Label ID="LabelNoOfResults" runat="server"></asp:Label></strong>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="7">
            <asp:GridView 
                ID="GridViewResults" 
                runat="server" 
                Width="100%" 
                GridLines="None"                
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"
                AutoGenerateSelectButton="true" 
                AllowSorting="True" ViewStateMode="Enabled">
            </asp:GridView>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell> 
        <asp:TableCell ColumnSpan="6">
            <strong><asp:Label ID="LabelNoResults" runat="server" Text="No Results Found" Visible="false"></asp:Label></strong>
        </asp:TableCell> 
    </asp:TableRow> 
</asp:Table>
