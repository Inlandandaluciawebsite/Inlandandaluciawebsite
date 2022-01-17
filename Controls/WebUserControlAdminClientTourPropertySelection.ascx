<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminClientTourPropertySelection.ascx.vb" Inherits="WebUserControlAdminClientTourPropertySelection" %>
<%@ Register Src="WebUserControlAdminLocation.ascx" TagName="AdminLocation" TagPrefix="ucAdminLocation" %>
<%@ Reference Control="WebUserControlAdminPropertySearchResultsHeader.ascx" %>
<%@ Reference Control="WebUserControlAdminPropertySearchResult.ascx" %>
<h1><asp:Label ID="LabelHeader" runat="server"></asp:Label></h1>
<p>&nbsp;</p>
<asp:Table ID="TableSearchFilters" runat="server" Width="100%">

    <asp:TableRow>

        <asp:TableCell Width="100px">
            Reference:
        </asp:TableCell>

        <asp:TableCell>
            <asp:TextBox ID="TextBoxReference" runat="server" style="text-transform:uppercase"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>
    
        <asp:TableCell>
            Type:
        </asp:TableCell>
    
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListType" runat="server">
            </asp:DropDownList>
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>
    
        <asp:TableCell VerticalAlign="Top">
            Location:
        </asp:TableCell>
        
        <asp:TableCell>
            <ucAdminLocation:AdminLocation id="AdminLocation1" runat="server" />
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>
    
        <asp:TableCell>
            Min Bedrooms:
        </asp:TableCell>
        
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListMinBedrooms" runat="server"></asp:DropDownList>
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>
    
        <asp:TableCell>
            Min Bathrooms:
        </asp:TableCell>
        
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListMinBathrooms" runat="server"></asp:DropDownList>
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>
    
        <asp:TableCell ColumnSpan="2">
            <asp:LinkButton ID="LinkButtonFeatures" runat="server">Features:</asp:LinkButton>
        </asp:TableCell>
    
    </asp:TableRow>

    <asp:TableRow ID="TableRowFeatures" runat="server" Visible="false">
    
        <asp:TableCell ColumnSpan="2">

            <asp:Table ID="TableFeatures" runat="server" Width="100%">

                <asp:TableRow>

                    <asp:TableCell Width="100px"></asp:TableCell>
                    <asp:TableCell ID="ColumnFeatures1" runat="server" VerticalAlign="Top" Width="20%"></asp:TableCell> 
                    <asp:TableCell ID="ColumnFeatures2" runat="server" VerticalAlign="Top" Width="20%"></asp:TableCell> 
                    <asp:TableCell ID="ColumnFeatures3" runat="server" VerticalAlign="Top" Width="20%"></asp:TableCell> 
                    <asp:TableCell ID="ColumnFeatures4" runat="server" VerticalAlign="Top" Width="20%"></asp:TableCell> 
                    <asp:TableCell ID="ColumnFeatures5" runat="server" VerticalAlign="Top" Width="20%"></asp:TableCell> 
                
                </asp:TableRow>
            
            </asp:Table>

        </asp:TableCell>
    
    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell>
            Price:
        </asp:TableCell>
        
        <asp:TableCell>
            <asp:TextBox ID="TextBoxPriceFrom" runat="server" onkeypress="CheckNumeric(event);"></asp:TextBox> and <asp:TextBox ID="TextBoxPriceTo" runat="server" onkeypress="CheckNumeric(event);"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>

    <asp:TableRow>

        <asp:TableCell>
         </asp:TableCell>
        
        <asp:TableCell>
            <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="default-button"/>
        </asp:TableCell>

    </asp:TableRow>

</asp:Table>

<asp:Table ID="TableNoResults" runat="server" Visible="false">
    <asp:TableRow>
        <asp:TableCell Width="100px"></asp:TableCell>
        <asp:TableCell><strong><asp:Label ID="LabelNoResults" runat="server" Text="No Results"></asp:Label></strong></asp:TableCell>
    </asp:TableRow>
</asp:Table>

<asp:UpdatePanel ID="UpdatePanelAdminClientTourPropertySearchResults" runat="server" UpdateMode="Conditional">
    <ContentTemplate>     
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanelPaging" runat="server">
    <ContentTemplate>    
        
        <asp:Table ID="TableFooter" runat="server" Width="1037px">
            
            <asp:TableRow>
            
                <asp:TableCell Width="282px">
                    <asp:DropDownList ID="DropDownListPage" runat="server" Visible="false" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>

                <asp:TableCell HorizontalAlign="Center" Width="284px">
                    <asp:LinkButton ID="LinkButtonPropertiesSelected" runat="server"></asp:LinkButton>
                </asp:TableCell>

                <asp:TableCell HorizontalAlign="Center" Width="285px">
                    <asp:HyperLink ID="HyperLink3Card" runat="server" NavigateUrl="~/Admin/3PropertyDisplayCard.aspx" Target="_blank">3 Property Card Print</asp:HyperLink>
                </asp:TableCell>
            
                <asp:TableCell HorizontalAlign="Right" Width="282px">
                    <asp:Button ID="ButtonFinish" runat="server" Text="Finish" Visible="false" CssClass="default-button"/>
                </asp:TableCell>

            </asp:TableRow>

        </asp:Table>        

    </ContentTemplate>
</asp:UpdatePanel>
