<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdvancedSearch.ascx.vb" Inherits="WebUserControlAdvancedSearch" %>
        <span id="Header" runat="server"></span>
        <div class="propertysearch">
          <h2><%=GetTranslation("Property search (advanced)")%></h2>
          <div class="propertysearchbox">
             <asp:Table ID="TableAdvancedSearch" runat="server" Width="100%" BorderWidth="0" CellSpacing="0" CellPadding="0">
              <asp:TableRow>
                <asp:TableCell width="18%"><%=GetTranslation("Area")%>:</asp:TableCell>
                <asp:TableCell width="29%">
                    <asp:DropDownList ID="DropDownListRegion" runat="server" 
                        CssClass="propertysearchselect" AutoPostBack="true" />
                </asp:TableCell>
                <asp:TableCell ID="TableCellTownLabel" Width="16%" Visible="false"><%=GetTranslation("Town")%>:</asp:TableCell>
                <asp:TableCell ID="TableCellTown" Visible="false" Width="37%">
                    <asp:DropDownList ID="DropDownListArea" runat="server" CssClass="propertysearchselect" AutoPostBack="true" />
                </asp:TableCell>
              </asp:TableRow>              
              <asp:TableRow>
                <asp:TableCell><%=GetTranslation("Property type")%>:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListType" runat="server" 
                        CssClass="propertysearchselect">
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell ID="TableCellVillageLabel" Visible="false"><%=GetTranslation("Village")%>:</asp:TableCell>
                <asp:TableCell ID="TableCellVillage" Visible="false">
                    <asp:DropDownList ID="DropDownListSubArea" runat="server" 
                        CssClass="propertysearchselect">
                    </asp:DropDownList>
                </asp:TableCell>
              </asp:TableRow>
              <asp:TableRow>
                <asp:TableCell><%=GetTranslation("Min. Beds")%>:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListBedrooms" runat="server" 
                        CssClass="propertysearchselectsmall">
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell><%=GetTranslation("Min. Baths")%>:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListBathrooms" runat="server" 
                        CssClass="propertysearchselectsmall">
                    </asp:DropDownList>
                </asp:TableCell>
              </asp:TableRow>
              <asp:TableRow>
                <asp:TableCell><%=GetTranslation("Price from")%>:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListPriceFrom" runat="server" 
                        CssClass="propertysearchselect" OnSelectedIndexChanged="DropDownListPriceFrom_SelectedIndexChanged" AutoPostBack="true" >
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell><%=GetTranslation("to")%>:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListPriceTo" runat="server" 
                        CssClass="propertysearchselect" OnSelectedIndexChanged="DropDownListPriceTo_SelectedIndexChanged" AutoPostBack="true" >
                    </asp:DropDownList>
                </asp:TableCell>
              </asp:TableRow>
              <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
              </asp:TableRow>
              <asp:TableRow>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <label>
                        <asp:ImageButton ID="SearchFilter" runat="server" ImageUrl="<%=GetImagePath%>" />
                    </label>
                </asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
              </asp:TableRow>
            </asp:Table>
          </div>
          <h3><%=GetTranslation("Property search by reference")%></h3>
          <div class="propertysearchbox">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="20%"><%=GetTranslation("Reference number")%>:</td>
              <td width="27%">
                <label>
                  <asp:TextBox ID="TextBoxReference" runat="server" CssClass="propsearchtext" style="text-transform:uppercase"></asp:TextBox>
                </label></td>
              <td width="53%">
                <asp:ImageButton ID="SearchReference" runat="server" ImageUrl="<%=GetImagePath%>" />
              </td>
            </tr>
          </table>
          <p>&nbsp;</p>       
        </div>
     </div>