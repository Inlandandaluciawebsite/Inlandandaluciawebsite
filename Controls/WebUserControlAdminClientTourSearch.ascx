<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminClientTourSearch.ascx.vb" Inherits="WebUserControlAdminClientTourSearch" %>
<h1><asp:Label ID="LabelClientTourSearch" runat="server" Text="Client Tour Search"></asp:Label></h1>
<p>&nbsp;</p>

<asp:Table ID="TableClientTourSearch" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelReference" runat="server" Text="Viewing Reference"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListTourID" runat="server"></asp:DropDownList>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelDateRange" runat="server" Text="Date Range"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListDateFromDay" runat="server" AutoPostBack="true"></asp:DropDownList>
            /
            <asp:DropDownList ID="DropDownListDateFromMonth" runat="server" AutoPostBack="true"></asp:DropDownList>
            /
            <asp:DropDownList ID="DropDownListDateFromYear" runat="server" AutoPostBack="true"></asp:DropDownList>            
            and
            <asp:DropDownList ID="DropDownListDateToDay" runat="server" AutoPostBack="true"></asp:DropDownList>
            /
            <asp:DropDownList ID="DropDownListDateToMonth" runat="server" AutoPostBack="true"></asp:DropDownList>
            /
            <asp:DropDownList ID="DropDownListDateToYear" runat="server" AutoPostBack="true"></asp:DropDownList>            
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelBuyer" runat="server" Text="Buyer"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListBuyer" runat="server"></asp:DropDownList>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelTourWith" runat="server" Text="Tour With"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListTourWith" runat="server"></asp:DropDownList>
        </asp:TableCell> 
    </asp:TableRow> 

    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell> 
        <asp:TableCell>
            <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="default-button"/>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:GridView 
                ID="GridViewResults" 
                runat="server" 
                Width="100%" 
                GridLines="None"                
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"
                AutoGenerateSelectButton="true" 
                AllowSorting="True">
            </asp:GridView>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell> 
        <asp:TableCell>
            <strong><asp:Label ID="LabelNoResults" runat="server" Text="No Results Found" Visible="false"></asp:Label></strong>
        </asp:TableCell> 
    </asp:TableRow> 
</asp:Table>