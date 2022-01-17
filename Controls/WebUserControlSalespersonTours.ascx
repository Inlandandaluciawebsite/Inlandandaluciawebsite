<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlSalespersonTours.ascx.vb" Inherits="Controls_WebUserControlSalespersonTours" %>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>


   <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div id="Div1">
                                    <h1>Salesperson Tours</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td style="font-weight: bold;">User</td>
                                            <td>
                                                <asp:DropDownList ID="drpUsers" runat="server" Width="250">
                                                </asp:DropDownList></td>
                                            <td>&nbsp;
                                            </td>
                                            <td style="font-weight: bold;">Date Range Selection</td>
                                            <td>
                                                <asp:TextBox ID="txtDateFrom" runat="server" Text="" placeholder="From" Width="220" CssClass="testjh"></asp:TextBox></td>
                                            <td align="center">
                                                <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateFrom" style="cursor: pointer;" onclick="javascript:document.getElementById('AdminSalesperontour_txtDateFrom').click();" /></td>
                                            <td>
                                                <asp:TextBox ID="txtDateTo" runat="server" Text="" placeholder="To" Width="220"></asp:TextBox></td>
                                            <td align="center">
                                                <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateTo" style="cursor: pointer;" onclick="javascript:document.getElementById('AdminSalesperontour_txtDateTo').Click();" /></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="10">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" align="right">
                                                <asp:Button ID="btnListByClient" runat="server" Text="List By Client" OnClick="btnListByClient_Click" Style="cursor: pointer;" BackColor="#2D3091" ForeColor="White" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnListByProperty" runat="server" Text="List By Property" OnClick="btnListByProperty_Click" Style="cursor: pointer;" BackColor="#2D3091" ForeColor="White" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10">&nbsp;</td>
                                        </tr>
                                        <tr id="trGridtitle" runat="server" visible="false">
                                            <td colspan="10">
                                                <h1>
                                                    <asp:Label ID="lblGridTitle" runat="server" Text="Client List"></asp:Label></h1>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10">
                                             <asp:Label ID="lblnorecord" runat="server"  Text="No Record Found!" Visible="false" ></asp:Label>
                                                <asp:GridView ID="grdClientList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="tour_id" AllowPaging="True" AllowSorting="true" OnSorting="grdClientList_Sorting" PageSize="15" OnPageIndexChanging="grdClientList_PageIndexChanging" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="tour_datetime">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_datetime") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Forename" SortExpression="Buyerforename">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyerforename")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Surname" SortExpression="Buyersurname">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyersurname")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Telephone" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerTelephone">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerTelephone")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerEmail">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerEmail")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerStatus">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerStatus")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                    <RowStyle CssClass="GridItemStyle" />
                                                    <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                </asp:GridView>
                                                <asp:GridView ID="grdPropertyList" runat="server" Visible="false" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="tour_id" AllowPaging="True" AllowSorting="true" OnSorting="grdPropertyList_Sorting" PageSize="15" OnPageIndexChanging="grdPropertyList_PageIndexChanging" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Property" SortExpression="PropertyRef" >
                                                            <ItemTemplate>
                                                                <%#Eval("PropertyRef")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="tour_datetime">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_datetime") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tour Id" SortExpression="tour_id">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_id")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tour Feedback"  SortExpression="TourFeedback">
                                                            <ItemTemplate>
                                                                <%#Eval("TourFeedback") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="700px" />
                                                            <ItemStyle  VerticalAlign="Middle" Width="700px" />
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

                 