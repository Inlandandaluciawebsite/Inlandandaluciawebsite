<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminPossibleDuplicates.ascx.vb" Inherits="WebUserControlAdminPossibleDuplicates" %>
<asp:Table ID="TableMatches" runat="server">
    <asp:TableRow>
        <asp:TableCell Width="500px">
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
</asp:Table>