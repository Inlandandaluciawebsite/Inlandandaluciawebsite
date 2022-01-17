<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminDatabaseStatistics.ascx.vb" Inherits="WebUserControlAdminDatabaseStatistics" %>
<h1>Database Status</h1>
<asp:GridView 
    ID="GridViewStatistics" 
    runat="server" 
    Width="100%" 
    GridLines="None"                
    CssClass="mGrid"
    PagerStyle-CssClass="pgr"  
    AlternatingRowStyle-CssClass="alt"
    AllowSorting="True">
</asp:GridView>