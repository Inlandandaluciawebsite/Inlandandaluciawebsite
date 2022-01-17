<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminContactType.ascx.vb" Inherits="WebUserControlAdminContactType" %>
<%@ Register Assembly="Obout.Ajax.UI" Namespace="Obout.Ajax.UI.TreeView" TagPrefix="obout" %>
<style type='text/css'>
    .column-left{ float: left; width: 33%; }
    .column-center{ display: inline-block; width: 34%; }
    .column-right{ float: right; width: 33%; }   
    .navbuttons{ border:none; background-color:transparent; width: 30px; height: 30px; } 
    .button-search {
        background-color: #003399;
        color: #FFFFFF;
        border: 1px solid #FFCC00;
        font-size: 14px;
        margin: 5px 0px;
    }
</style>
<div class="container">
    <div class="column-left">
        <h3>New Contact Type</h3>
        <br />
        <asp:Table ID="TableName" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    Name
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxName" runat="server" Width="200px" AutoPostBack="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Admin Only
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="CheckBoxAdmin" runat="server" Checked="false" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" Visible="false" CssClass="button-search"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div class="column-center">
        <h3>Options</h3>
        <br />
        <asp:CheckBoxList ID="CheckBoxListOptions" 
            AutoPostBack="True"
            CellPadding="5"
            CellSpacing="5"
            RepeatDirection="Vertical"
            RepeatLayout="Flow"
            TextAlign="Right"
            runat="server">
                        
        </asp:CheckBoxList>

    </div>    
    <div class="column-right">
        <h3>Menu Location</h3>
        <br />
        <obout:Tree ID="TreeViewNavigation" runat="server" ClientIDMode="AutoID" CssClass="vista"></obout:Tree> 
        <div class="menu-navigation-right">
            <asp:Table ID="TableNavigation" runat="server" HorizontalAlign="Center">
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButtonUp" runat="server" ImageUrl="~/Images/Buttons/up-arrow.jpg" CssClass="navbuttons" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButtonDown" runat="server" ImageURL="~/Images/Buttons/down-arrow.jpg" CssClass="navbuttons" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
</div>