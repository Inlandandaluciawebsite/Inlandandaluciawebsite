<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminContact.ascx.vb" Inherits="WebUserControlAdminContact" %>

<asp:UpdatePanel ID="UpdatePanelAdminContact" runat="server" updatemode="Conditional" >

    <ContentTemplate>     

        <h1><asp:Label ID="LabelContact" runat="server"></asp:Label></h1>
        
        <asp:Label ID="LabelContactID" runat="server" Visible="false"></asp:Label>

        <asp:Table ID="TableContact" runat="server" Width="100%">

            <asp:TableRow ID="TableRowContactType" runat="server" >
                <asp:TableCell>
                    Type:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListType" runat="server" Enabled="false" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="120px">
                    Name:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxName" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowRegistrationNo" runat="server">
                <asp:TableCell>
                    Registration No.:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxRegistrationNo" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowAddress" runat="server">
                <asp:TableCell VerticalAlign="Top">
                    Address:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAddress" runat="server" MaxLength="250" Width="300px" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell>        
            </asp:TableRow>

            <asp:TableRow ID="TableRowTelephone" runat="server">
                <asp:TableCell>
                    Telephone:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxTelephone" runat="server" onkeypress="CheckNumeric(event);" MaxLength="15" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowMobile" runat="server">
                <asp:TableCell>
                    Mobile:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxMobile" runat="server" onkeypress="CheckNumeric(event);" MaxLength="15" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowFax" runat="server">
                <asp:TableCell>
                    Fax:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxFax" runat="server" onkeypress="CheckNumeric(event);" MaxLength="15" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowEmail" runat="server">
                <asp:TableCell>
                    Email:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="40" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowNotes" runat="server">
                <asp:TableCell VerticalAlign="Top">
                    Notes:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxNotes" runat="server" MaxLength="200" Width="300px" Rows="10" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell>        
            </asp:TableRow>

            <asp:TableRow ID="TableRowLogin" runat="server">
                <asp:TableCell>
                    Login:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxLogin" runat="server" MaxLength="10"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowPassword1" runat="server">
                <asp:TableCell>
                    Password:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxPassword" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowPassword2" runat="server">
                <asp:TableCell>
                    Confirm Password:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxConfirmPassword" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowLanguage" runat="server">
                <asp:TableCell>
                    Spoken Language:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListLanguage" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowPartner">
                <asp:TableCell>
                    Partner:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListPartner" runat="server" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowBroker">
                <asp:TableCell>
                    Broker:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListBroker" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowImage" Visible="false" AccessKey="1">
                <asp:TableCell VerticalAlign="Top">
                    <asp:Label ID="LabelImageTitle" runat="server"></asp:Label>:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Image ID="ImageContact" runat="server" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowImageUpload" Visible="false">
                <asp:TableCell>                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="FileUploadImage" runat="server"/>        
                    <asp:Button ID="ButtonUploadImage" runat="server" Text="Upload Image" CssClass="default-button"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowCommission" runat="server">
                <asp:TableCell>
                    Commission:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxCommission" runat="server" MaxLength="10"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowAdmin" runat="server" Visible="false">
                <asp:TableCell>
                    Admin:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="CheckBoxAdmin" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowArchived" runat="server">
                <asp:TableCell>
                    Archived:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="CheckBoxArchived" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="TableRowSave" runat="server">
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                </asp:TableCell>
                <asp:TableCell>
                    <b><asp:Label ID="LabelStatus" runat="server"></asp:Label></b>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>

        <asp:Table ID="TablePropertyOptions" runat="server" Width="100%" Visible="false" >

            <asp:TableRow ID="TableRowProperties" Visible="false" runat="server">
                <asp:TableCell Width="120px" VerticalAlign="Top">
                    Properties:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:GridView 
                        ID="GridViewProperties" 
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

            <asp:TableRow>
                <asp:TableCell Width="120px">
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonAddProperty" runat="server" Text="Add Property" Visible="false" CssClass="default-button"/>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    
    </ContentTemplate> 

    <Triggers>
        <asp:PostBackTrigger ControlID="ButtonUploadImage" />
    </Triggers>

</asp:UpdatePanel> 