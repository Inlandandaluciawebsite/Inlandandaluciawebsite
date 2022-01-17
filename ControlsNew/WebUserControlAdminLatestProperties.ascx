<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminLatestProperties.ascx.vb" Inherits="WebUserControlAdminLatestProperties" %>

<h1><asp:Label ID="LabelLatestProperties" runat="server" Text="Latest Properties"></asp:Label></h1>

<p>
    &nbsp;</p>

<asp:Table ID="TableLatestProperties" runat="server">
    
    <asp:TableRow>
        <asp:TableCell Width="70px">
            Duration:
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2" Width="300px">
            <asp:DropDownList ID="DropDownListDuration" runat="server"></asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell>
            Include:
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="CheckBoxCreated" runat="server" Text="Created Properties" Checked="true"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="CheckBoxModified" runat="server" Text="Modified Properties" Checked="true" />
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2">
            <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="default-button" />
        </asp:TableCell> 
    </asp:TableRow>

    <asp:TableRow ID="TableRowNoResults" runat="server" Visible="false">
        <asp:TableCell>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2">
            <strong><asp:Label ID="LabelNoResults" runat="server" Text="No Results Found"></asp:Label></strong>
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow ID="TableRowNoOfResults" runat="server" Visible="false" HorizontalAlign="Right">
        <asp:TableCell ColumnSpan="3">
            <strong><asp:Label ID="LabelNoOfResults" runat="server"></asp:Label></strong>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

<asp:Table ID="TableResults" runat="server" Visible="false">
    
    <asp:TableRow ID="TableRowResults" runat="server">
        <asp:TableCell ColumnSpan="3">
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

</asp:Table>
