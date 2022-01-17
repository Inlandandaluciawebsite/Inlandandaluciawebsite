<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminContactSearch.ascx.vb" Inherits="WebUserControlAdminContactSearch" %>
<h1><asp:Label ID="LabelContact" runat="server"></asp:Label></h1>
<p>&nbsp;</p>
<asp:Table ID="TableContactSearch" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow ID="TableRowPropertyReference" runat="server" Visible="false">
        <asp:TableCell>
            <asp:Label ID="LabelPropertyRef" runat="server" Text="Property Reference"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:TextBox ID="TextBoxPropertyReference" runat="server" style="text-transform:uppercase"></asp:TextBox>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelArchived" runat="server" Text="Include Archived"></asp:Label>:
        </asp:TableCell> 
        <asp:TableCell>
            <asp:CheckBox ID="CheckBoxIncludeArchived" runat="server" Checked="false"/>
        </asp:TableCell> 
    </asp:TableRow> 
    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell> 
        <asp:TableCell>
            <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="default-button" />
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
                AllowSorting="True"
                Visible="false"
            >
            </asp:GridView>
        </asp:TableCell> 
    </asp:TableRow> 
</asp:Table>