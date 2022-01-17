<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminClientTourFeedback.ascx.vb" Inherits="WebUserControlAdminClientTourFeedback" %>
<%@ Reference Control="~/ControlsNew/WebUserControlAdminClientTourFeedbackEntry.ascx" %>

<p>&nbsp;</p>
<asp:UpdatePanel ID="UpdatePanelFeedback" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
    <ContentTemplate>                                        
    </ContentTemplate> 
</asp:UpdatePanel> 
    <br />  
<asp:Button ID="ButtonSave" runat="server" Text="Save" style="float: right;"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="btn green"/>             
