<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminClientTourFeedbackEntry.ascx.vb" Inherits="WebUserControlAdminClientTourFeedbackEntry" %>
<asp:Table ID="TableFeedbackEntry" runat="server" Width="100%">

    <asp:TableRow>
    
        <asp:TableCell VerticalAlign="Top" Width="100px">
        
            <strong><asp:Label ID="LabelPropertyRef" runat="server"></asp:Label></strong>
        
        </asp:TableCell>

        <asp:TableCell>
        
            <asp:TextBox ID="TextBoxFeedback" runat="server" TextMode="MultiLine" Rows="5" Width="95%" MaxLength="1000"></asp:TextBox>
        
        </asp:TableCell>

    </asp:TableRow>

</asp:Table>
