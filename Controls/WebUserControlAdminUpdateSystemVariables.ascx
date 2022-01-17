<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminUpdateSystemVariables.ascx.vb" Inherits="WebUserControlAdminUpdateSystemVariables" %>

<h3>System Parameters: <asp:Label ID="LabelTitle" runat="server"></asp:Label></h3>

<asp:Table ID="TableUpdateSystemVariables" runat="server">

    <asp:TableRow ID="TableRowResults" runat="server">

        <asp:TableCell ColumnSpan="2">

            <asp:GridView 
                ID="GridViewResults" 
                runat="server" 
                Width="100%" 
                GridLines="None"                
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"
                AutoGenerateSelectButton="true" >
            </asp:GridView>

        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow ID="TableRowAdd" runat="server">
    
        <asp:TableCell HorizontalAlign="Right" ColumnSpan="2">
    
            <asp:Button ID="ButtonAdd" runat="server" Text="Add" CssClass="default-button"/>

        </asp:TableCell>
    
    </asp:TableRow>

    <asp:TableRow ID="TableRowAddEditEnglish" runat="server" Visible="false">
    
        <asp:TableCell>      
            English:        
        </asp:TableCell>

        <asp:TableCell>      
            <asp:TextBox ID="TextBoxEnglish" runat="server"></asp:TextBox>
        </asp:TableCell>

        <asp:TableCell>
            <asp:Button ID="ButtonAutoTranslate" runat="server" Text="Auto Translate" CssClass="default-button"/>
        </asp:TableCell>
    
    </asp:TableRow>

    <asp:TableRow ID="TableRowAddEditSpanish" runat="server" Visible="false">
    
        <asp:TableCell>      
            Spanish:        
        </asp:TableCell>

        <asp:TableCell>      
            <asp:TextBox ID="TextBoxSpanish" runat="server"></asp:TextBox>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>
    
    </asp:TableRow>

    <asp:TableRow ID="TableRowAddEditFrench" runat="server" Visible="false">
    
        <asp:TableCell>      
            French:        
        </asp:TableCell>

        <asp:TableCell>      
            <asp:TextBox ID="TextBoxFrench" runat="server"></asp:TextBox>
        </asp:TableCell>
    
        <asp:TableCell></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow ID="TableRowAddEditGerman" runat="server" Visible="false">
    
        <asp:TableCell>      
            German:        
        </asp:TableCell>

        <asp:TableCell>      
            <asp:TextBox ID="TextBoxGerman" runat="server"></asp:TextBox>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>
    
    </asp:TableRow>

    <asp:TableRow ID="TableRowAddEditDutch" runat="server" Visible="false">
    
        <asp:TableCell>      
            Dutch:        
        </asp:TableCell>

        <asp:TableCell>      
            <asp:TextBox ID="TextBoxDutch" runat="server"></asp:TextBox>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>
    
    </asp:TableRow>

    <asp:TableRow ID="TableRowCode" runat="server" Visible="false">
    
        <asp:TableCell>      
            Code:        
        </asp:TableCell>

        <asp:TableCell>      
            <asp:TextBox ID="TextBoxCode" runat="server" MaxLength="2"></asp:TextBox>
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>
    
    </asp:TableRow>

    <asp:TableRow ID="TableRowOptions" runat="server" Visible="false">
    
        <asp:TableCell HorizontalAlign="Right" ColumnSpan="2">
    
            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="default-button"/>
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button"/>
            <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button"/>

        </asp:TableCell>

        <asp:TableCell></asp:TableCell>
   
    </asp:TableRow>

    <asp:TableRow ID="TableRowPropertiesAffectedPrompt" runat="server" Visible="false">
    
        <asp:TableCell ColumnSpan="2">
            Unable to remove this system variable as it is currently in use by the following properties:    
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow ID="TableRowPropertiesAffected" runat="server" Visible="false">
    
        <asp:TableCell ColumnSpan="2">

            <asp:GridView 
                ID="GridViewPropertiesAffected" 
                runat="server" 
                Width="100%" 
                GridLines="None"                
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt">
            </asp:GridView>
    
        </asp:TableCell>

        <asp:TableCell></asp:TableCell>

    </asp:TableRow>

    <asp:TableRow ID="TableRowBack" runat="server" Visible="false">
    
        <asp:TableCell HorizontalAlign="Right" ColumnSpan="2">
    
            <asp:Button ID="ButtonBack" runat="server" Text="Back" CssClass="default-button"/>

        </asp:TableCell>

        <asp:TableCell></asp:TableCell>
    
    </asp:TableRow>

</asp:Table>
