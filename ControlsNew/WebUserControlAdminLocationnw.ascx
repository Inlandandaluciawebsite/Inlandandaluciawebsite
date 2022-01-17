<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminLocationnw.ascx.vb" Inherits="WebUserControlAdminLocationnw" %>
 <div class="form-group">
                               <label class="control-label col-md-2 sdwdth">Locations </label> 
 
         <div class="col-md-2">
      <label class="control-label ">Country </label>
        <asp:DropDownList ID="DropDownListCountry" runat="server" AutoPostBack="true" CssClass="form-control">
            </asp:DropDownList>
    </div>
    <div class="col-md-2">
         <label class="control-label ">Area </label>
         <asp:DropDownList ID="DropDownListRegion" runat="server" AutoPostBack="true" CssClass="form-control">
            </asp:DropDownList>
    </div>
    <div class="col-md-2" id="TableRowArea" runat="server" >
         <label class="control-label ">Town </label>
         <asp:DropDownList ID="DropDownListArea" runat="server" AutoPostBack="true" CssClass="form-control">
            </asp:DropDownList>
    </div>
     <div class="col-md-2" id="TableRowSubArea" runat="server">
          <label class="control-label ">Village </label>
           <asp:DropDownList ID="DropDownListSubArea" runat="server" AutoPostBack="true" CssClass="form-control">
            </asp:DropDownList>
    </div>
     <div class="col-md-2">
          <label class="control-label ">Postcode </label>
              <asp:DropDownList ID="DropDownListPostcode" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
    </div>
         </div>
