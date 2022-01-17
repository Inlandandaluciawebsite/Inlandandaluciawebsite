<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminFeaturedProperties.ascx.vb" Inherits="WebUserControlAdminFeaturedProperties" %>

<style type='text/css'>
    .navbuttons{ border:none; background-color:transparent; } 
</style>

<asp:UpdatePanel ID="UpdatePanelFeaturedProperties" runat="server" updatemode="Conditional" >

    <ContentTemplate>     

        <h1><asp:Label ID="LabelFeaturedProperties" runat="server" Text="Featured Properties"></asp:Label></h1>

        <p></p>

        <asp:Table ID="TableFeaturedProperties" runat="server" Width="100%">
    
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <strong>Available Properties</strong>
                </asp:TableCell>
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <strong>Featured Properties</strong>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell RowSpan="10">
                    <asp:ListBox ID="ListBoxAvailableProperties" runat="server" Width="100%" Rows="30" AutoPostBack="true"></asp:ListBox>
                </asp:TableCell>
                <asp:TableCell RowSpan="10">
                </asp:TableCell>
                <asp:TableCell RowSpan="10">
                    <asp:ListBox ID="ListBoxSelectedProperties" runat="server" Width="100%" Rows="30" AutoPostBack="true"></asp:ListBox>
                </asp:TableCell>
                <asp:TableCell>                    
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:ImageButton ID="ImageButtonTop" runat="server" ImageUrl="~/Images/Buttons/up-arrow.jpg" Width="40px" Height="40px" CssClass="navbuttons"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:ImageButton ID="ImageButtonUp10" runat="server" ImageUrl="~/Images/Buttons/up-arrow.jpg" Width="30px" Height="30px" CssClass="navbuttons"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:ImageButton ID="ImageButtonUp" runat="server" ImageUrl="~/Images/Buttons/up-arrow.jpg" Width="20px" Height="20px" CssClass="navbuttons"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:ImageButton ID="ImageButtonDown" runat="server" ImageUrl="~/Images/Buttons/down-arrow.jpg" Width="20px" Height="20px" CssClass="navbuttons"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:ImageButton ID="ImageButtonDown10" runat="server" ImageUrl="~/Images/Buttons/down-arrow.jpg" Width="30px" Height="30px" CssClass="navbuttons"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:ImageButton ID="ImageButtonBottom" runat="server" ImageUrl="~/Images/Buttons/down-arrow.jpg" Width="40px" Height="40px" CssClass="navbuttons"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <strong><asp:Label ID="LabelPosition" runat="server"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <strong><asp:Label ID="LabelNoSelected" runat="server"></asp:Label></strong>
                </asp:TableCell>
                <asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="ButtonAdd" runat="server" Text="Add" Width="80px" Enabled="false" CssClass="default-button"/>
                </asp:TableCell>
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="ButtonRemove" runat="server" Text="Remove"  Width="80px" Enabled="false" CssClass="default-button"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="3">
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="default-button"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowSaved" runat="server" Visible="false">
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="3">
                    <strong><asp:Label ID="LabelSaved" runat="server" Text="The featured properties selected have been saved successfully"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>

    </ContentTemplate>

</asp:UpdatePanel>


