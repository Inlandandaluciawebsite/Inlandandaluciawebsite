<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminProperty.ascx.vb" Inherits="WebUserControlAdminProperty" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="WebUserControlAdminLocation.ascx" TagName="AdminLocation" TagPrefix="ucAdminLocation" %>
<%@ Register Src="WebUserControlAdminPropertyImage.ascx" TagName="AdminPropertyImage" TagPrefix="ucAdminPropertyImage" %>

<div id="menu" style="width:120px;float:left;">
    <h4><asp:Label ID="LabelPropertyReference" runat="server" Text=""></asp:Label></h4>
    <br />
    <asp:ListBox ID="ListBoxCategory" runat="server" AutoPostBack="true" Height="200" Visible="false"></asp:ListBox><br />    
</div>
<div id="content" style="width:940px; float:left;">
    
    <asp:Table ID="TableGeneral" runat="server" Width="80%">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <h4>General</h4>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRowVendor">
            <asp:TableCell Width="120px">
                <asp:Label ID="LabelVendor" runat="server" Text="Vendor" ></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListVendor" runat="server"></asp:DropDownList>        
                <asp:Button ID="ButtonViewVendor" runat="server" Text="View" Visible="false" CssClass="default-button"/>       
            </asp:TableCell>  
            <asp:TableCell HorizontalAlign="Right">
                <asp:Button ID="ButtonWindowcard" runat="server" Text="Windowcard" CssClass="default-button" Width="120px" Visible="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRowPropertyType">
            <asp:TableCell>
                <asp:Label ID="LabelPropertyType" runat="server" Text="Property Type" ></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListType" runat="server">
                </asp:DropDownList>
            </asp:TableCell>  
            <asp:TableCell HorizontalAlign="Right">
                <asp:Button ID="ButtonViewingPhotos" runat="server" Text="Viewing Photos" CssClass="default-button" Width="120px" Visible="false" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelPropertyStatus" runat="server" Text="Property Status"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="true"></asp:DropDownList>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow ID="TableRowUnderOfferTo" runat="server" Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelUnderOfferTo" runat="server" Text="Under Offer To"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListUnderOfferTo" runat="server" AutoPostBack="true"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRowDisplayProperty" Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelDisplay" runat="server" Text="Display Property"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:CheckBox ID="CheckBoxDisplay" runat="server"/>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow ID="TableRowFeatureProperty" Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelFeature" runat="server" Text="Feature Property"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:CheckBox ID="CheckBoxFeature" runat="server" AutoPostBack="true"/>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow ID="TableRowPropertyLocation" Visible="false">    
            <asp:TableCell VerticalAlign="Top">
                Location
            </asp:TableCell>        
            <asp:TableCell>
                <ucAdminLocation:AdminLocation id="AdminLocation1" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell VerticalAlign="Top">
                <asp:Label ID="LabelAddress" runat="server" Text="Address"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxPropertyAddress" runat="server" MaxLength="250" TextMode="MultiLine" Width="300px" Rows="4" AutoCompleteType="None"></asp:TextBox>
                <asp:Label ID="LabelPropertyAddress" runat="server" Visible="false"></asp:Label>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelLatitude" runat="server" Text="Latitude"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxLatitude" runat="server" onkeypress="CheckDecimalAllowNegative(this, event);" MaxLength="15" AutoCompleteType="None"></asp:TextBox> <i>(e.g. 37.0)</i>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelLongitude" runat="server" Text="Longitude"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxLongitude" runat="server" onkeypress="CheckDecimalAllowNegative(this, event);" MaxLength="15" AutoCompleteType="None"></asp:TextBox> <i>(e.g. -4.0)</i>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelLocation" runat="server" Text="Location"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListLocation" runat="server">
                </asp:DropDownList>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelViews" runat="server" Text="Views"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListViews" runat="server">
                </asp:DropDownList>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelBedrooms" runat="server" Text="Bedrooms"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListBedrooms" runat="server">
                </asp:DropDownList>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelBathrooms" runat="server" Text="Bathrooms"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListBathrooms" runat="server">
                </asp:DropDownList>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelYearConstructed" runat="server" Text="Year Constructed"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListYearConstructed" runat="server">
                </asp:DropDownList>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelPlot" runat="server" Text="Plot"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxPlotSQM" runat="server" onkeypress="CheckDecimal(this, event);" MaxLength="6" AutoCompleteType="None"></asp:TextBox> m<sup>2</sup>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelBuilt" runat="server" Text="Built"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxBuiltSQM" runat="server" onkeypress="CheckDecimal(this, event);" MaxLength="4" AutoCompleteType="None"></asp:TextBox> m<sup>2</sup>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelTerrace" runat="server" Text="Terrace"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxTerraceSQM" runat="server" onkeypress="CheckDecimal(this, event);" MaxLength="3" AutoCompleteType="None"></asp:TextBox> m<sup>2</sup>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelEnSuite" runat="server" Text="En Suite"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxEnSuiteSQM" runat="server" onkeypress="CheckDecimal(this, event);" MaxLength="2" AutoCompleteType="None"></asp:TextBox> m<sup>2</sup>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelAnnualIBI" runat="server" Text="Annual IBI"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxAnnualIBI" runat="server" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None"></asp:TextBox> € <i>(e.g. ###.## €)</i>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelAnnualRubbish" runat="server" Text="Annual Rubbish"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxAnnualRubbish" runat="server" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None"></asp:TextBox> € <i>(e.g. ###.## €)</i>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelCommunityFees" runat="server" Text="Community Fees"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxCommunityFees" runat="server" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None"></asp:TextBox> € <i>(e.g. ###.## €)</i>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelVendorPrice" runat="server" Text="Vendor Price"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxVendorPrice" runat="server" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None"></asp:TextBox> € <i>(e.g. ###### €)</i>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelOriginalPrice" runat="server" Text="Original Price"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxOriginalPrice" runat="server" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None"></asp:TextBox> € <i>(e.g. ###### €)</i>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelPublicPrice" runat="server" Text="Public Price"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxPublicPrice" runat="server" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None"></asp:TextBox> € <i>(e.g. ###### €)</i>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelVideoURL" runat="server" Text="YouTube Video ID"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxVideoURL" runat="server" MaxLength="100" AutoCompleteType="None"></asp:TextBox>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false">
            <asp:TableCell>
                <asp:Label ID="LabelDoorKey" runat="server" Text="Door Key"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxDoorKey" runat="server" MaxLength="10" AutoCompleteType="None" style="text-transform:uppercase"></asp:TextBox>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow Visible="false" Enabled="false">
            <asp:TableCell>
                Partner
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListPartner" runat="server" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                <%--<asp:TextBox ID="txtPartner" runat="server" Text="" Enabled="false" ReadOnly="true"></asp:TextBox>--%>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible="false" Enabled="false">
            <asp:TableCell>
                Broker
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListBroker" runat="server"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRowBuyerLawyer" runat="server" Visible="false" >
            <asp:TableCell>
                Buyer's Lawyer
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListBuyerLawyer" runat="server" AutoPostBack="true"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Vendor's Lawyer
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListVendorLawyer" runat="server" AutoPostBack="true"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table> 
    
    <asp:Table ID="TableDescription" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <h4>Descriptions</h4>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelLanguage" runat="server" Text="Language"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListLanguage" runat="server" AutoPostBack="true"></asp:DropDownList>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" >
                <br />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">
                <asp:Label ID="LabelShortDescription" runat="server" Text="Short"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell VerticalAlign="Top">
                <asp:TextBox ID="TextBoxShortDescription" runat="server" MaxLength="85" Width="680px" Height="20px" AutoPostBack="true" AutoCompleteType="None" style="overflow:auto;"></asp:TextBox>
            </asp:TableCell>        
            <asp:TableCell VerticalAlign="Bottom">
                <asp:Button ID="ButtonSaveShortDescription" runat="server" Text="Save" CssClass="default-button"/>&nbsp;
                <asp:Button ID="ButtonAutoTranslateShort" runat="server" Text="Auto Translate" CssClass="default-button"/>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelMessageShort" runat="server" ForeColor="Gray" Font-Bold="True" Visible="False"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">
                <asp:Label ID="LabelMainDescription" runat="server" Text="Main"></asp:Label>
            </asp:TableCell>        
            <asp:TableCell>
                <asp:TextBox ID="TextBoxDescription" runat="server" MaxLength="3000" TextMode="MultiLine" Width="680px" Height="500px" AutoPostBack="true" AutoCompleteType="None" style="overflow:auto;"></asp:TextBox>
            </asp:TableCell>        
            <asp:TableCell VerticalAlign="Bottom">
                <asp:Button ID="ButtonSaveDescription" runat="server" Text="Save" CssClass="default-button"/>&nbsp;
                <asp:Button ID="ButtonAutoTranslate" runat="server" Text="Auto Translate" CssClass="default-button"/>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelMessage" runat="server" ForeColor="Gray" Font-Bold="True" Visible="False"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="TableUploadImages" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <h4>Images</h4>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRowImageOptions" runat="server">
            <asp:TableCell>
                <asp:FileUpload ID="FileUploadImage" AllowMultiple="true" accept="image/*" runat="server"  />        
            </asp:TableCell>        
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListUploadImageOption" runat="server" AutoPostBack="true"></asp:DropDownList>
            </asp:TableCell>    
            <asp:TableCell>
                <asp:Button ID="ButtonUploadImage" runat="server"  Text="Upload" CssClass="default-button"/>
            </asp:TableCell>    
            <asp:TableCell>
                <asp:Button ID="ButtonBulkUploadImage" runat="server" Text="Bulk" CssClass="default-button"/>
            </asp:TableCell>    
        </asp:TableRow>
        <asp:TableRow ID="TableRowBulkImageUpload" runat="server" Visible="false">
            <asp:TableCell ColumnSpan="4">
                    <asp:AjaxFileUpload ID="AjaxBulkFileUploadImage" runat="server"
                        AllowedFileTypes="jpg,jpeg,png,gif,bmp"        
                        OnClientUploadCompleteAll="uploadComplete"
                    />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="TableImages" runat="server" Visible="false">
        <asp:TableFooterRow>
        <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
            <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage1" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
        </asp:TableCell>
        </asp:TableFooterRow>
        <asp:TableFooterRow>
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage2" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage3" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage4" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
        </asp:TableFooterRow> 
        <asp:TableFooterRow>
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage5" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage6" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage7" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
        </asp:TableFooterRow> 
        <asp:TableFooterRow>
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage8" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage9" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage10" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
        </asp:TableFooterRow> 
        <asp:TableFooterRow>
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage11" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage12" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage13" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
        </asp:TableFooterRow> 
        <asp:TableFooterRow>
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage14" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage15" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
            <asp:TableCell>
                <ucAdminPropertyImage:AdminPropertyImage id="AdminPropertyImage16" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown"/>
            </asp:TableCell> 
        </asp:TableFooterRow> 
    </asp:Table>

    <asp:Table ID="TableFeatures" runat="server" Visible="false" Width="100%">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4">
                <h4>Features</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ID="Column1" runat="server" VerticalAlign="Top" Width="25%"></asp:TableCell> 
            <asp:TableCell ID="Column2" runat="server" VerticalAlign="Top" Width="25%"></asp:TableCell> 
            <asp:TableCell ID="Column3" runat="server" VerticalAlign="Top" Width="25%"></asp:TableCell> 
            <asp:TableCell ID="Column4" runat="server" VerticalAlign="Top" Width="25%"></asp:TableCell> 
        </asp:TableRow> 
    </asp:Table>

    <asp:Table ID="TableHistory" runat="server" Width="100%" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <h4>History</h4>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView 
                    ID="GridViewList" 
                    runat="server" 
                    Width="100%" 
                    GridLines="None"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"  
                    AlternatingRowStyle-CssClass="alt"
                    AutoGenerateSelectButton="true">
                </asp:GridView>
            </asp:TableCell>                
        </asp:TableRow>
        <asp:TableRow ID="TableRowHistoryElement" runat="server" Visible="false">
            <asp:TableCell>
                <asp:TextBox ID="TextBoxHistory" runat="server" TextMode="MultiLine" Width="100%" Height="250px" AutoCompleteType="None"></asp:TextBox>            
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow ID="TableRowHistoryArchive" runat="server" Visible="false">
            <asp:TableCell HorizontalAlign="Right">
                <asp:Button ID="ButtonArchiveHistory" runat="server" Text="Archive" CssClass="default-button"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListHistoryType" runat="server" AutoPostBack="true" ></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRowSoldTo" runat="server" Visible="false">
            <asp:TableCell>
                Buyer: <asp:DropDownList ID="DropDownListBuyer" runat="server" AutoPostBack="true" ></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxAddHistory" runat="server" MaxLength="1500" TextMode="MultiLine" Width="100%" Height="250px" AutoPostBack="true" AutoCompleteType="None"></asp:TextBox>            
            </asp:TableCell>        
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="TableDocuments" runat="server" Font-Names="Calibri" Visible="false">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="7">
                <h4>Documents</h4>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRowFolderOptions" runat="server">
            <asp:TableCell>
               <asp:Button ID="ButtonNewFolder" runat="server" Text="New Folder" Enabled="false" CssClass="default-button"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" Enabled="false" CssClass="default-button"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="ButtonRename" runat="server" Text="Rename" Enabled="false" CssClass="default-button"/>
            </asp:TableCell>
            <asp:TableCell >
                <asp:FileUpload ID="FileUploadFile" runat="server" AllowMultiple="true"  Enabled="false" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="ButtonUpload" runat="server" Text="Upload" Enabled="false" CssClass="default-button"/>

            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="ButtonDownload" runat="server" Text="Download" Enabled="false" CssClass="default-button"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="ButtonEmail" runat="server" Text="Email" Enabled="false" CssClass="default-button"/>
            </asp:TableCell>
        </asp:TableRow> 
        <asp:TableRow ID="TableRowUpdate" runat="server" Visible="false">
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                <asp:Label ID="LabelUpdate" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ColumnSpan="3">
                <asp:TextBox ID="TextBoxName" runat="server" Width="98%" AutoCompleteType="None"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelFileExtension" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="default-button"/>
            </asp:TableCell>
        </asp:TableRow> 
        <asp:TableRow ID="TableRowDelete" runat="server" Visible="false">
            <asp:TableCell ColumnSpan="5" HorizontalAlign="Right">
                <asp:Label ID="LabelDelete" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="ButtonDeleteYes" runat="server" Text="Yes" CssClass="default-button"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="ButtonDeleteNo" runat="server" Text="No" CssClass="default-button"/>
            </asp:TableCell>
        </asp:TableRow> 
        <asp:TableRow>
            <asp:TableCell ColumnSpan="7">
                <asp:TreeView ID="TreeViewBrowser" runat="server" Font-Names="Calibri" Font-Size="11" ForeColor="Black" SelectedNodeStyle-BackColor="Silver" BorderColor="Silver" BorderStyle="None">
                </asp:TreeView>
            </asp:TableCell>
        </asp:TableRow> 
        <asp:TableRow ID="TableRowEmailSent" runat="server" Visible="false">
            <asp:TableCell ColumnSpan="7" HorizontalAlign="Center">
                The email has been sent successfully
            </asp:TableCell>
        </asp:TableRow> 
        <asp:TableRow ID="TableRowFileLimitExceeded" runat="server" Visible="false">
            <asp:TableCell ColumnSpan="7" HorizontalAlign="Center" Font-Bold="true" ForeColor="Red">
                The file selected exceeds the maximum file size limit of 3MB
            </asp:TableCell>
        </asp:TableRow> 
    </asp:Table>

    <asp:Table ID="TableEmailDocument" runat="server" Visible="false" Width="500px">
        <asp:TableRow>
            <asp:TableCell>
                To: <asp:TextBox ID="TextBoxEmailAddress" runat="server" Width="100%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ID="TableRowProvideEmailAddress" runat="server" Visible="false" HorizontalAlign="Center">
                <strong>Please provide an email address</strong>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Subject: <asp:TextBox ID="TextBoxEmailSubject" runat="server" Width="100%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxEmailMessage" runat="server" TextMode="MultiLine" Rows="10" Width="100%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <strong>Attachment: <asp:Label ID="LabelAttachment" runat="server"></asp:Label></strong>
                <asp:Label ID="LabelAttachmentFullPath" runat="server" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Button ID="ButtonSend" runat="server" Text="Send" CssClass="default-button"/> 
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="default-button"/> 
            </asp:TableCell>            
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ID="TableCellEmailFailed" runat="server" Visible="false" HorizontalAlign="Center">
                <strong>Email sending failed. Please check the email address is valid.</strong>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table> 

    <asp:Table ID="TableMessage" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <strong><asp:Label ID="LabelMessageTitle" runat="server"></asp:Label></strong>
            </asp:TableCell>            
        </asp:TableRow>    
        <asp:TableRow></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelMessageBody" runat="server"></asp:Label>
            </asp:TableCell>            
        </asp:TableRow>    
        <asp:TableRow></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Button ID="ButtonOK" runat="server" Text="OK" CssClass="default-button"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="TableSave" runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell Width="500px">  
                <b><asp:Label ID="LabelStatus" runat="server"></asp:Label></b>              
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Button ID="ButtonSave" runat="server" Text="Save" Visible="false" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="default-button" />
            </asp:TableCell>
        </asp:TableRow>    
    </asp:Table>

</div>
<div style="display:none"><asp:AjaxFileUpload ID="ghostAjaxFileUpload" runat="server" /></div>