<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminLawyerAreaNew.ascx.vb" Inherits="WebUserControlAdminLawyerAreaNew" %>
<%@ Register src="~/ControlsNew/WebUserControlAdminDocumentManagerNew.ascx" tagname="AdminDocumentManager" tagprefix="ucAdminDocumentManager" %>
<%@ Register src="~/ControlsNew/WebUserControlAdminContact.ascx" tagname="AdminContact" tagprefix="ucAdminContact" %>
<%@ Register src="~/ControlsNew/WebUserControlAdminBuyerNew.ascx" tagname="AdminBuyer" tagprefix="ucAdminBuyer" %>
<h1>Lawyer Area</h1>
<br />
<h3><asp:Label ID="LabelWelcome" runat="server"></asp:Label></h3>
<br />
<div class="row" ID="TablePropertySelection" runat="server">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Property</label>
                                                    <div class="col-md-9">
                                                     <asp:DropDownList ID="DropDownListProperty" runat="server" AutoPostBack="true"  CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                          
                                        </div>
         

<br />
<div class="row" ID="TableOptions" runat="server" Visible="false">
    <div class="col-md-4"> <asp:LinkButton ID="LinkButtonBuyer" runat="server">Buyer's Details</asp:LinkButton></div>
    <div class="col-md-4"> <asp:LinkButton ID="LinkButtonDocuments" runat="server">Property Documents</asp:LinkButton></div>
        <div class="col-md-4">   <asp:LinkButton ID="LinkButtonVendor" runat="server">Vendor's Details</asp:LinkButton></div>
        
</div>

<br />
<asp:PlaceHolder ID="PlaceHolderBuyer" runat="server" Visible="false">
    <h3>Buyer</h3>
    <ucAdminBuyer:AdminBuyer ID="AdminBuyer" runat="server"/> 
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolderVendor" runat="server" Visible="false">
    <h3>Vendor</h3>
    <ucAdminContact:AdminContact ID="AdminContact" runat="server"/> 
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolderDocuments" runat="server" Visible="false">
    <h3>Documents</h3>
    <ucAdminDocumentManager:AdminDocumentManager ID="AdminDocumentManager" runat="server"/> 
</asp:PlaceHolder>