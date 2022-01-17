<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminBuyer.ascx.vb" Inherits="WebUserControlAdminBuyer" %>
<%@ Register Src="~/Controls/WebUserControlAdminPossibleDuplicates.ascx" TagName="AdminPossibleDuplicates" TagPrefix="ucAdminPossibleDuplicates" %>
<asp:UpdatePanel ID="UpdatePanelAdminBuyer" runat="server" UpdateMode="Conditional">

    <ContentTemplate>

        <h1>
            <asp:Label ID="LabelBuyer" runat="server" Text="Client"></asp:Label><asp:Button ID="btnAction" runat="server" Text="ACTION" Style="margin-left: 49px;" Visible="false" CssClass="default-button" PostBackUrl="~/AdminNew/BuyerActionAgenda.aspx" />
            <asp:Button ID="btnClintHistory" runat="server" Text="CLIENT HISTORY" Style="margin-left: 49px;" CssClass="default-button" PostBackUrl="~/AdminNew/ClientHistory.aspx" Visible="false" />
        </h1>

        <asp:Table ID="TableBuyer" runat="server" Width="600px">

            <asp:TableRow>
                <asp:TableCell Width="120px">
                    Forename:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxForename" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonCreateTour" runat="server" Text="Create Tour" Visible="false" CssClass="default-button" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Surname:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSurname" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Passport No.:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxPassportNo" runat="server" MaxLength="10" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top">
                    Address:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAddress" runat="server" MaxLength="250" Width="300px" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Contact Name:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxContactName" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Telephone:
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="TextBoxTelephone" runat="server" onkeypress="CheckNumeric(event);" MaxLength="15" Width="300px"></asp:TextBox>--%>
                    <asp:TextBox ID="TextBoxTelephone" runat="server" MaxLength="15" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Email:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top">
                    Notes:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxNotes" runat="server" MaxLength="2000" TextMode="MultiLine" Rows="10" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Partner:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListPartner" runat="server" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Agent:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListAgent" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Language:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListLanguage" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Budget:
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:TextBox ID="TextBoxBudget" runat="server" onkeypress="CheckNumeric(event);" MaxLength="7"></asp:TextBox>--%>
                    <asp:TextBox ID="TextBoxBudget" runat="server"  MaxLength="7"></asp:TextBox>
                    €
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Source:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListSource" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Status:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Archived:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="CheckBoxArchived" runat="server" AutoPostBack="true" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowPossibleDuplicates" runat="server" Visible="false">
                <asp:TableCell ColumnSpan="2">
                    <br />
                    <h2>Did you perhaps mean...</h2>
                    <ucAdminPossibleDuplicates:AdminPossibleDuplicates ID="AdminPossibleDuplicates" runat="server" />
                    <br />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowSave" runat="server">
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowSaved" runat="server" Visible="false">
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell>
                    <strong>
                        <asp:Label ID="LabelSaved" runat="server" Text="Buyer Successfully Saved"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>

    </ContentTemplate>

</asp:UpdatePanel>
