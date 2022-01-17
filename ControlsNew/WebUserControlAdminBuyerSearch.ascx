<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminBuyerSearch.ascx.vb" Inherits="WebUserControlAdminBuyerSearch" %>
<h1><asp:Label ID="LabelBuyer" runat="server" Text="Client Search"></asp:Label></h1>
<p>&nbsp;</p>
<asp:Table ID="TableBuyerSearch" runat="server">

    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelFirstName" runat="server" Text="First Name"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        </asp:TableCell> 
    </asp:TableRow> 

    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelLastName" runat="server" Text="Last Name"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        </asp:TableCell> 
    </asp:TableRow> 

    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelIncludeArchived" runat="server" Text="Include Archived"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:CheckBox ID="CheckBoxIncludeArchived" runat="server" />
        </asp:TableCell> 
    </asp:TableRow> 

    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell> 
        <asp:TableCell>
            <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="default-button" />
        </asp:TableCell> 
    </asp:TableRow> 

    <asp:TableRow ID="TableRowNoResults" runat="server" Visible="false">
        <asp:TableCell>
        </asp:TableCell> 
        <asp:TableCell>
            <strong><asp:Label ID="LabelNoResults" runat="server" Text="No Results Found"></asp:Label></strong>
        </asp:TableCell> 
    </asp:TableRow> 

    <asp:TableRow ID="TableRowResults" runat="server" Visible="false">

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
                AllowSorting="False"
            >
            </asp:GridView>
        </asp:TableCell> 
    </asp:TableRow> 
</asp:Table>