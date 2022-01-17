<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminMenuEditor.ascx.vb" Inherits="WebUserControlAdminMenuEditor" %>
<%@ Register assembly="Obout.Ajax.UI" namespace="Obout.Ajax.UI.TreeView" tagprefix="obout" %>

<style type='text/css'>
    .column-left{ 
        width: 33% ;
    }
    .button-save {
        background-color: #003399;
        color: #FFFFFF;
        border: 1px solid #FFCC00;
        font-size: 14px;
        margin: 5px 0px;
        float: right; 
    }
    .navbuttons{ border:none; background-color:transparent; width: 30px; height: 30px; } 
</style>

<h1>Menu Editor</h1>

<div class="column-left">    

    <obout:Tree ID="TreeViewNavigation" runat="server" ClientIDMode="AutoID" CssClass="vista"></obout:Tree>
    <br />
    <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="button-save" />
    <br />

</div>
<div class="menu-navigation-center">
    <asp:Table ID="TableNavigation" runat="server" HorizontalAlign="Center">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:ImageButton ID="ImageButtonUp" runat="server" ImageUrl="~/Images/Buttons/up-arrow.jpg" CssClass="navbuttons" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:ImageButton ID="ImageButtonDown" runat="server" ImageUrl="~/Images/Buttons/down-arrow.jpg" CssClass="navbuttons" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
<div class="menu-navigation-edit-right">    
    <asp:Table ID="TableNode" runat="server" Visible="false" Width="300px">
        <asp:TableRow>
            <asp:TableCell>
                Text
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxText" runat="server" AutoPostBack="true" Width="100%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Admin Only
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="CheckBoxAdmin" runat="server" AutoPostBack="true" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Archived
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="CheckBoxArchived" runat="server" AutoPostBack="true" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
