<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlActionAgenda.ascx.vb" Inherits="Controls_WebUserControlActionAgenda" %>
   


                                <div id="Div1">
                                    <h1>Action Agenda</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="6">
                                                <asp:HiddenField ID="hdnBuyerId" runat="server" />
                                                <asp:GridView ID="grdActionAgenda" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="History_ID" AllowPaging="True" AllowSorting="true" PageSize="15" OnPageIndexChanging="grdActionAgenda_PageIndexChanging" OnSorting="grdActionAgenda_Sorting" OnRowCommand="grdActionAgenda_RowCommand" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>">
                                                                    <asp:LinkButton ID="lnkSelectBuyerHistory" runat="server" ToolTip="Click to edit or view this Buyer. !!!" CommandArgument='<%#Eval("History_ID") %>' CommandName="EditBuyer" Text="Select"></asp:LinkButton></span>

                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Create_Date")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action Date" SortExpression="Action_Date">

                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Action_Date")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" Buyer ForeName" SortExpression="Buyer_Forename">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Buyer_Forename")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Buyer Surname" SortExpression="Buyer_Surname">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Buyer_Surname")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Buyer Status" SortExpression="Status">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Status")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="User" ItemStyle-HorizontalAlign="Center" SortExpression="User">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("User")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="400px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px"></ItemStyle>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                    <RowStyle CssClass="GridItemStyle" />
                                                    <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td style="font-weight: bold;">User</td>
                                            <td>
                                                <asp:DropDownList ID="drpAgents" runat="server" Width="180"></asp:DropDownList>
                                            </td>
                                            <td style="font-weight: bold;">Status</td>
                                            <td colspan="2" style="vertical-align: middle;">
                                                <asp:DropDownList ID="drpBuyerStatus" runat="server" Width="180">
                                                </asp:DropDownList>
                                                &nbsp;&nbsp;&nbsp;
                                                <b>Action Date</b>
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txtActionDate" runat="server" Text="" Width="200" CssClass="ActionDate01"></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;
                                                <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateFrom1" alt="calender" style="cursor: pointer;" onclick="javascript:document.getElementById('AdminActionAgenda_txtActionDate').click();" />
                                                &nbsp;&nbsp; &nbsp;
                                               <%--<span>
                                                   <asp:CheckBox ID="chkIsArchived" runat="server" /><b>IsArchived</b></span>--%>
                                                <asp:Button ID="btnClientHistorySave" runat="server" Text="Save" Style="cursor: pointer;" BackColor="#2D3091" ForeColor="White" OnClick="btnClientHistorySave_Click" />

                                            </td>
                                            <td>
                                                <asp:Button ID="btnClientHistoryUpdate" runat="server" Text="Save" Style="cursor: pointer; margin-right: 170px; display: none;" BackColor="#2D3091" ForeColor="White" OnClick="btnClientHistoryUpdate_Click" />
                                            </td>

                                        </tr>

                                        <tr>
                                            <td colspan="6">&nbsp;

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="txtDescription" runat="server" CssClass="Description01" Text="" TextMode="MultiLine" Width="800" Height="230" MaxLength="1500" name="txtDescription" onKeyDown="limitText();"
                                                    onKeyUp="limitText();"></asp:TextBox>
                                                &nbsp;&nbsp;<font size="2">(Maximum characters: 1500)<br>
                                                    You have
                                                    <input readonly type="text" id="countdown" name="countdown" size="3" value="1500">
                                                    characters left.</font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">&nbsp;</td>
                                        </tr>
                                        <tr id="trGridtitle" runat="server" visible="false">
                                            <td colspan="6">
                                                <h1>
                                                    <asp:Label ID="lblGridTitle" runat="server" Text="Client List"></asp:Label></h1>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                          