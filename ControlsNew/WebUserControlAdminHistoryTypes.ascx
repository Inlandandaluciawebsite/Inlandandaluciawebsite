<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminHistoryTypes.ascx.vb" Inherits="WebUserControlAdminHistoryTypes" %>
<h1>History Types</h1>
<br />
<asp:Table ID="TableHistoryTypes" runat="server" Width="100%">
    <asp:TableRow>
        <asp:TableCell Width="50%">
            <h3>Existing</h3>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2">
            <h3><asp:Label ID="LabelAddEdit" runat="server" Text="Add"></asp:Label><asp:Label ID="LabelID" runat="server" Visible="false"></asp:Label></h3>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow Height="20px" >
        <asp:TableCell RowSpan="3">
            <asp:GridView 
                ID="GridViewTypes" 
                runat="server" 
                Width="90%" 
                GridLines="None"                
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"
                AutoGenerateSelectButton="true" 
                AllowSorting="True" ViewStateMode="Enabled">
            </asp:GridView>
        </asp:TableCell>
        <asp:TableCell Width="60px">
            Type
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxStatus" runat="server"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRowArchive" Height="20px" Visible="false">
        <asp:TableCell VerticalAlign="Top">
            Archived
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="CheckBoxArchived" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow VerticalAlign="Top">
        <asp:TableCell></asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="default-button"/>  <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" Visible="false" CssClass="default-button"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
