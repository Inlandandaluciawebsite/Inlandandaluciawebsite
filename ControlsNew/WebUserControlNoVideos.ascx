<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlNoVideos.ascx.vb" Inherits="Controls_WebUserControlNoVideos" %>
     <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div id="Div1">
                                    <h1>Properties With No Videos</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="6">
                                                <asp:HiddenField ID="hdnBuyerId" runat="server" />
                                                <asp:GridView ID="grdNoVideosProperties" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="Property_Ref" AllowPaging="True" AllowSorting="true" PageSize="15" OnPageIndexChanging="grdNoVideosProperties_PageIndexChanging" OnSorting="grdNoVideosProperties_Sorting" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%--<asp:LinkButton ID="lnkSelectBuyerHistory" runat="server" ToolTip="Click to edit or view this property. !!!" CommandArgument='<%#Eval("Property_Ref") %>' CommandName="EditBuyer" Text="Select"></asp:LinkButton>--%>
                                                                <a href='BackOffice.aspx?Property_Ref=<%#Eval("Property_Ref")%>&Type=PropertyDetails'>Select</a>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Property Ref" SortExpression="Property_Ref">
                                                            <ItemTemplate>
                                                                <%#Eval("Property_Ref")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Create Date" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <%#Eval("Create_Date_02") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Modified" SortExpression="Last_Modified">
                                                            <ItemTemplate>
                                                                <%#Eval("Last_Modified_02")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Door Key" SortExpression="Door_Key">
                                                            <ItemTemplate>
                                                                <%#Eval("Door_Key")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Region/Town" SortExpression="regiontext">
                                                            <ItemTemplate>
                                                                <%#Eval("regiontext")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Property Address" SortExpression="Property_Address">
                                                            <ItemTemplate>
                                                                <%#Eval("Property_Address")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Vendor" SortExpression="Vendor">
                                                            <ItemTemplate>
                                                                <%#Eval("Vendor")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Photos" ItemStyle-HorizontalAlign="Center" SortExpression="Num_Photos">
                                                            <ItemTemplate>
                                                                <%#Eval("Num_Photos")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                    <RowStyle CssClass="GridItemStyle" />
                                                    <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>