<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlReportClientTourMissingFeedbackEntry.ascx.vb" EnableViewState="true" Inherits="WebUserControlReportClientTourMissingFeedbackEntry" %>

<div class="table-bordered table-striped tab-res">

    <asp:Table ID="TableEntry" runat="server">
        <asp:TableRow>
            <asp:TableHeaderCell>
                <asp:LinkButton ID="LinkButtonSortTour" runat="server" ForeColor="White">Tour ID</asp:LinkButton>: 
                <asp:Label ID="LabelTourID" runat="server" ForeColor="White"></asp:Label></asp:TableHeaderCell>

            <asp:TableHeaderCell>
                <asp:LinkButton ID="LinkButtonSortDate" runat="server" ForeColor="White">Tour Date</asp:LinkButton>: 
                <asp:Label ID="LabelTourDate" runat="server"></asp:Label></asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:LinkButton ID="LinkButtonSortBy" runat="server" ForeColor="White">Tour By</asp:LinkButton>: 
                <asp:Label ID="LabelTourBy" runat="server"></asp:Label></asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:LinkButton ID="LinkButtonSortBuyer" runat="server" ForeColor="White">Buyer</asp:LinkButton>:  
                <asp:Label ID="LabelBuyer" runat="server"></asp:Label></asp:TableHeaderCell>

        </asp:TableRow>
    </asp:Table>



</div>
<div class="btncl">
    <asp:HiddenField ID="hdnBuyerId" runat="server" />
    <asp:Button ID="ButtonOpenTour" runat="server" Text="Open Tour" OnClick="ButtonOpenTour_Click" UseSubmitBehavior="false" CssClass="btn open-t" Style="" />
</div>
