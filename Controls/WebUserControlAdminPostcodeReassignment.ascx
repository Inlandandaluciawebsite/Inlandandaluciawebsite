<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminPostcodeReassignment.ascx.vb" Inherits="WebUserControlAdminPostcodeReassignment" %>
<%@ Register Src="WebUserControlAdminLocation.ascx" TagName="AdminLocation" TagPrefix="ucAdminLocation" %>
<p>&nbsp;</p>
<p><strong>Postcode Reassignments</strong></p>

<p>Properties are currently allocated to the region, area and sub areas you are removing.  These require reassignment before deletion.</p>

<p><asp:Label ID="LabelReassignmentsRemaining" runat="server"></asp:Label> reassignment(s) remaining...</p>
<p>&nbsp;</p>

<asp:Table ID="TablePostcodeReassignment" runat="server">

    <asp:TableRow>

        <asp:TableCell ColumnSpan="2">
            <strong>Existing Address</strong>
        </asp:TableCell>

        <asp:TableCell Width="100px"></asp:TableCell>

        <asp:TableCell ColumnSpan="2">
            <strong>Replacement Address</strong>
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell>
            Country
        </asp:TableCell>

        <asp:TableCell>
            <strong><asp:Label ID="LabelCountry" runat="server"></asp:Label></strong>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>

        <asp:TableCell RowSpan="5" ColumnSpan="2">
            <ucAdminLocation:AdminLocation id="AdminLocation1" runat="server" />
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell>
            Area
        </asp:TableCell>

        <asp:TableCell>
            <strong><asp:Label ID="LabelArea" runat="server"></asp:Label></strong>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell>
            Town
        </asp:TableCell>

        <asp:TableCell>
            <strong><asp:Label ID="LabelTown" runat="server"></asp:Label></strong>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell>
            Village
        </asp:TableCell>

        <asp:TableCell>
            <strong><asp:Label ID="LabelVillage" runat="server"></asp:Label></strong>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell>
            Postcode
        </asp:TableCell>

        <asp:TableCell>
            <strong><asp:Label ID="LabelPostcode" runat="server"></asp:Label></strong>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>
    
        <asp:TableCell ColumnSpan="4"></asp:TableCell>

        <asp:TableCell>
            <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button"/>
        </asp:TableCell>
    
    </asp:TableRow>

</asp:Table>