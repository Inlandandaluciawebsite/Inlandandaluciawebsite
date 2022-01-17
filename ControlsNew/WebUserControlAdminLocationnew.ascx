<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminLocationnew.ascx.vb" Inherits="WebUserControlAdminLocationnew" %>

             <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"><asp:Label ID="LabelCountry" runat="server" Text="Country"></asp:Label></label>
                                            <div class="col-md-9">
  <asp:DropDownList ID="DropDownListCountry" runat="server" AutoPostBack="true"  CssClass="form-control">
            </asp:DropDownList>                                         </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Country </label>
                                                  <div class="col-md-9">
  <asp:DropDownList ID="DropDownListRegion" runat="server" AutoPostBack="true"  CssClass="form-control">
            </asp:DropDownList>                                          </div>
                                        </div>
                                    </div>
                       <div class="col-md-3" ID="TableRowArea" runat="server">
                                        <div class="form-group" >
                                            <label class="control-label col-md-3">Country </label>
                                                  <div class="col-md-9" >
 <asp:DropDownList ID="DropDownListArea" runat="server" AutoPostBack="true"  CssClass="form-control">
            </asp:DropDownList>                                        </div>
                                        </div>
                                    </div>
                       <div class="col-md-3" ID="TableRowSubArea" runat="server">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Country </label>
                                                  <div class="col-md-9">
   <asp:DropDownList ID="DropDownListSubArea" runat="server" AutoPostBack="true" CssClass="form-control">
            </asp:DropDownList>                                         </div>
                                        </div>
                                    </div>
                    <div class="col-md-3" ID="Div1" runat="server">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Country </label>
                                                  <div class="col-md-9">
 <asp:DropDownList ID="DropDownListPostcode" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>                                        </div>
                                        </div>
                                    </div>
                                </div>



  

 