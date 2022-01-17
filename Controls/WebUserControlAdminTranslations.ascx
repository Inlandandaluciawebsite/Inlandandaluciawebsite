<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminTranslations.ascx.vb" Inherits="WebUserControlAdminTranslations" %>

<h1>Translations</h1>

<asp:UpdatePanel ID="UpdatePanelAdminTranslations" runat="server" updatemode="Conditional" >

    <ContentTemplate>     

        <asp:Table ID="TableTranslations" runat="server" Width="100%">

            <asp:TableRow ID="TableRowSearchEnglish" runat="server">
                <asp:TableCell HorizontalAlign="Right">
                    Search English text for:
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxTranslationSearchEnglish" runat="server" Width="100%"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:Button ID="ButtonTranslationSearchEnglish" runat="server" Text="Search" CssClass="default-button"/>
                </asp:TableCell>                
            </asp:TableRow>
            
            <asp:TableRow ID="TableRowSearchForeign" runat="server">
                <asp:TableCell HorizontalAlign="Right">
                    Search Translations for:
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxTranslationSearchForeign" runat="server" Width="100%"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:Button ID="ButtonTranslationSearchForeign" runat="server" Text="Search" CssClass="default-button"/>
                </asp:TableCell>                
            </asp:TableRow>

            <asp:TableRow ID="TableRowNoResults" Visible="false">
                <asp:TableCell></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <strong>No results found</strong>
                </asp:TableCell>            
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowSearchResults" runat="server" Visible="false">
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
                        AllowSorting="True"
                    >
                    </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowEnglish" runat="server" Visible="false">
                <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                    <strong>English</strong>
                </asp:TableCell>            
            </asp:TableRow>

            <asp:TableRow ID="TableRowOriginal" runat="server" Visible="false">
                <asp:TableCell ColumnSpan="3">
                    <asp:TextBox ID="TextBoxOriginal" runat="server" MaxLength="2000" TextMode="MultiLine" Rows="4" width="100%" AutoPostBack="true" Font-Names="Lucida Sans Unicode" Enabled="false"></asp:TextBox>
                </asp:TableCell>            
            </asp:TableRow>

            <asp:TableRow ID="TableRowLanguage" runat="server" Visible="false">
                <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                    <strong><asp:Label ID="LabelLanguage" runat="server" ></asp:Label></strong>
                </asp:TableCell>            
            </asp:TableRow>

            <asp:TableRow ID="TableRowTranslation" runat="server" Visible="false">
                <asp:TableCell ColumnSpan="3">
                    <asp:TextBox ID="TextBoxTranslation" runat="server" MaxLength="2000" TextMode="MultiLine" Rows="4" width="100%" AutoPostBack="true" Font-Names="Lucida Sans Unicode"></asp:TextBox>
                </asp:TableCell>            
            </asp:TableRow>

            <asp:TableRow ID="TableRowUpdate" runat="server" Visible="false">
                <asp:TableCell>                    
                </asp:TableCell>            
                <asp:TableCell>                    
                </asp:TableCell>            
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="default-button"/> <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="default-button"/> <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="default-button"/>
                </asp:TableCell>            
            </asp:TableRow>

        </asp:Table>

    </ContentTemplate>

</asp:UpdatePanel>