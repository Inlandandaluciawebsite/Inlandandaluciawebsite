<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminNavigation.ascx.vb" Inherits="WebUserControlAdminNavigation" %>
<div style="display:none">
     <asp:GridView ID="grdMarkettingLeads" DataKeyNames="property_id"  Font-Names="Open Sans, sans-serif" CssClass="table-bordered table-striped table-condensed cf" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record found!">
                                                <Columns>
                                                  
                                                    <asp:BoundField DataField="property_ref"
                                                        HeaderText="REF" />
                                                    <asp:BoundField DataField="type"
                                                        HeaderText="TYPE" />
                                                    <asp:BoundField DataField="location"
                                                        HeaderText="LOCATION" />
                                                    <asp:BoundField DataField="latitude"
                                                        HeaderText="LATITUDE" />
                                                    <asp:BoundField DataField="longitude"
                                                        HeaderText="LONGITUDE" />
                                                    <asp:BoundField DataField='Description'
                                                        HeaderText="DESCRIPTION" />
                                                         <asp:BoundField DataField='url'
                                                        HeaderText="url" />
                                                        
                                                    <asp:BoundField DataField="price"
                                                        HeaderText="SALES PRICE" />
                                                  
                                                   
                                                </Columns>
                                            </asp:GridView>
</div>

