<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlReportClientTourMissingFeedbackEntry1.ascx.vb" Inherits="WebUserControlReportClientTourMissingFeedbackEntry" %>
<asp:Table ID="TableEntry" runat="server" Width="100%">
    <asp:TableRow BackColor="#2D3091" ForeColor="White">
        <asp:TableCell Width="25%">
            <strong>
                <asp:LinkButton ID="LinkButtonSortTour" runat="server" ForeColor="White">Tour ID</asp:LinkButton>: 
                <asp:Label ID="LabelTourID" runat="server" ForeColor="White"></asp:Label>
            </strong>
        </asp:TableCell>
        <asp:TableCell Width="25%">
            <strong>
                <asp:LinkButton ID="LinkButtonSortDate" runat="server" ForeColor="White">Tour Date</asp:LinkButton>: 
                <asp:Label ID="LabelTourDate" runat="server"></asp:Label>
            </strong>
        </asp:TableCell>
        <asp:TableCell Width="25%">
            <strong>
                <asp:LinkButton ID="LinkButtonSortBy" runat="server" ForeColor="White">Tour By</asp:LinkButton>: 
                <asp:Label ID="LabelTourBy" runat="server"></asp:Label>
            </strong>
        </asp:TableCell>
        <asp:TableCell Width="25%">
            <strong>
                <asp:LinkButton ID="LinkButtonSortBuyer" runat="server" ForeColor="White">Buyer</asp:LinkButton>:  
                <asp:Label ID="LabelBuyer" runat="server"></asp:Label>
            </strong>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<div style="float:right">
    <asp:Button ID="ButtonOpenTour" runat="server" Text="Open Tour" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button"/>
</div>
