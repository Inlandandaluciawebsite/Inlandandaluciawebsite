<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminPostcodes.ascx.vb" Inherits="WebUserControlAdminPostcodes" %>
<%@ Register Src="~/ControlsNew/WebUserControlAdminPostcodeReassignment.ascx" TagName="AdminPostcodeReassignment" TagPrefix="ucAdminPostcodeReassignment" %>

<asp:UpdatePanel ID="UpdatePanelPostcodes" runat="server" UpdateMode="Conditional">

    <ContentTemplate>

        <h1>
            <asp:Label ID="LabelPostcodes" runat="server" Text="Postcodes"></asp:Label></h1>

        <asp:Table ID="TablePostcodes" runat="server" Width="100%">

            <asp:TableRow ID="TableRowEditName" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    Edit <%= GetParentEntity()%>:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxEditName" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditCountryHeader" runat="server" Visible="false">

                <asp:TableCell ColumnSpan="2">
                    <strong>Edit Country</strong>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditCountryEN" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    English:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxEditCountryEN" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditCountryES" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    Spanish:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxEditCountryES" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditCountryFR" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    French:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxEditCountryFR" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditCountryDE" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    German:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxEditCountryDE" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditCountryNL" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    Dutch:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxEditCountryNL" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditCountryCode" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    Country Code:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxEditCountryCode" runat="server" MaxLength="2"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditPostcode" runat="server" Visible="false">

                <asp:TableCell>
                    Edit Postcode:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxEditPostcode" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditDefaultPartner" runat="server" Visible="false">

                <asp:TableCell>
                    Default Partner:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList ID="DropDownListEditDefaultPartner" runat="server"></asp:DropDownList>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowEditOptions" runat="server" Visible="false">

                <asp:TableCell>                                        
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                    <asp:Button ID="ButtonSaveEdit" runat="server" Text="Save" CssClass="default-button" />
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="default-button" />
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowParent" runat="server">

                <asp:TableCell ColumnSpan="3">
                    <strong>
                        <asp:Label ID="LabelType" runat="server"></asp:Label>
                        <asp:LinkButton ID="LinkButtonParentCountry" runat="server" Visible="false"></asp:LinkButton>
                        <asp:Label ID="LabelSeparator1" runat="server" Text=" / " Visible="false"></asp:Label>
                        <asp:LinkButton ID="LinkButtonParentRegion" runat="server" Visible="false"></asp:LinkButton>
                        <asp:Label ID="LabelSeparator2" runat="server" Text=" / " Visible="false"></asp:Label>
                        <asp:LinkButton ID="LinkButtonParentArea" runat="server" Visible="false"></asp:LinkButton>
                        <asp:Label ID="LabelSeparator3" runat="server" Text=" / " Visible="false"></asp:Label>
                        <asp:LinkButton ID="LinkButtonParentSubArea" runat="server" Visible="false"></asp:LinkButton>
                    </strong>
                </asp:TableCell>

            </asp:TableRow>

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

            <asp:TableRow ID="TableRowAddName" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    Add <%= GetThisEntity()%>:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:HiddenField ID="hdnSubAreaId" runat="server" />
                    <asp:HiddenField ID="hdnPostCodeId" runat="server" />
                    <asp:TextBox ID="TextBoxAddName" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddCountryHeader" runat="server" Visible="false">

                <asp:TableCell ColumnSpan="2">
                    <strong>Add Country</strong> 
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddCountryEN" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    English:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxAddCountryEN" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddCountryES" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    Spanish:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxAddCountryES" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddCountryFR" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    French:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxAddCountryFR" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddCountryDE" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    German:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxAddCountryDE" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddCountryNL" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    Dutch:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxAddCountryNL" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddCountryCode" runat="server" Visible="false">

                <asp:TableCell Width="100px">
                    Country Code:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxAddCountryCode" runat="server" MaxLength="2"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddPostcode" runat="server" Visible="false">

                <asp:TableCell>
                    Add Postcode:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="TextBoxAddPostcode" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddDefaultPartner" runat="server" Visible="false">

                <asp:TableCell>
                    Default Partner:
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList ID="DropDownListAddDefaultPartner" runat="server"></asp:DropDownList>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowAddOptions" runat="server" Visible="false">

                <asp:TableCell>                                        
                </asp:TableCell>

                <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                    <asp:Button ID="ButtonSaveAdd" runat="server" Text="Save" CssClass="default-button" />
                </asp:TableCell>

            </asp:TableRow>

        </asp:Table>

        <asp:Table ID="TableConfirmDeletion" runat="server" Visible="false">

            <asp:TableRow>

                <asp:TableCell ColumnSpan="3">
                    <asp:Label ID="LabelDeletionPrompt" runat="server"></asp:Label>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRowDeletionResults" runat="server" Visible="false">

                <asp:TableCell ColumnSpan="3">
                    <asp:GridView
                        ID="GridViewDeletionResults"
                        runat="server"
                        Width="100%"
                        GridLines="None"
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        AllowSorting="True">
                    </asp:GridView>

                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow>

                <asp:TableCell>
                    Are you sure you want to continue?
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Button ID="ButtonConfirmDeletion" runat="server" Text="Yes" CssClass="default-button" />
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Button ID="ButtonCancelDeletion" runat="server" Text="No" CssClass="default-button" />
                </asp:TableCell>

            </asp:TableRow>

        </asp:Table>

    </ContentTemplate>

</asp:UpdatePanel>
