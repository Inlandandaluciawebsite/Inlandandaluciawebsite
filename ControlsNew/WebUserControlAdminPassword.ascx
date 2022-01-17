<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminPassword.ascx.vb" Inherits="WebUserControlAdminPassword" %>
<H1>Change Password</H1>
    <br />
<asp:Table ID="TablePassword" runat="server" Width="370px">
    <asp:TableRow>
        <asp:TableCell Width="150px">
            <asp:Label ID="LabelCurrent" runat="server" Text="Current Password"></asp:Label>:
        </asp:TableCell>
        <asp:TableCell Width="200px">
            <asp:TextBox ID="TextBoxCurrentPassword" runat="server" TextMode="Password" Width="90%" AutoPostBack="true"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell Width="20px" HorizontalAlign="Right">
            <asp:Image ID="ImageCurrent" runat="server" Visible="false" Width="20px" Height="20px"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelNew" runat="server" Text="New Password"></asp:Label>:
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxNewPassword" runat="server" TextMode="Password" Width="90%" AutoPostBack="true"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Image ID="ImageNew" runat="server" Visible="false" Width="20px" Height="20px"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelConfirm" runat="server" Text="Confirm Password"></asp:Label>:
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password" Width="90%" AutoPostBack="true"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Image ID="ImageConfirm" runat="server" Visible="false" Width="20px" Height="20px"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
    <br />
<asp:Table ID="TableSave" runat="server" Width="370px">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left" Width="320px"> 
            <strong><asp:Label ID="LabelMessage" runat="server"></asp:Label></strong>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right" Width="50px">
            <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>