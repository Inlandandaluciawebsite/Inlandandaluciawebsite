<%@ Control Language="VB" ClassName="WebUserControlSearchForm" CodeFile="WebUserControlSearchForm.ascx.vb" Inherits="WebUserControlSearchForm"%>
<div class="propsearch">
<%-- <asp:Panel ID="UCPanelSearchForm" runat="server" BorderStyle="None">--%>
<h2><%=GetTranslation("Quick  Search")%></h2>
    <table>
    <tr>
    <td ><%=GetTranslation("Area")%>:</td>
    <td colspan="2"><asp:DropDownList ID="DropDownListRegion" runat="server" CssClass="propsearchselect" > </asp:DropDownList></td>
    </tr>
    <tr>
    <td ><%=GetTranslation("Budget")%>:</td>
    <td colspan="2">
        <asp:DropDownList ID="DropDownListPriceTo" runat="server" 
            CssClass="propsearchselect"> </asp:DropDownList></td>
    </tr>
    
    <tr>
    <td ><%=GetTranslation("Type")%>:</td>
    <td colspan="2"><asp:DropDownList ID="DropDownListType" runat="server" CssClass="propsearchselect"> </asp:DropDownList></td>
    </tr>
                <tr>
    <td ><%=GetTranslation("Min beds")%>:</td>
    <td><asp:DropDownList 
            ID="DropDownListBedrooms" runat="server" CssClass="propsearchselectsmall"> </asp:DropDownList></td>
    <td>
        <asp:ImageButton ID="SearchFilter" runat="server" ImageUrl="<%#GetImagePath%>" alt="search" />
    </td>
    </tr>
                <tr>
                  <td >&nbsp;</td>
                  <td>&nbsp;</td>
                  <td ></td>
                </tr>
    </table><hr />
    <h4><%=GetTranslation("Search by Reference")%></h4>
    <table>
    <tr>
    <td><%=GetTranslation("Reference")%>:</td>
    <td ><asp:TextBox ID="TextBoxReference" runat="server" CssClass="propsearchtext" style="text-transform:uppercase"></asp:TextBox></td>
    <td >&nbsp;<asp:ImageButton ID="SearchReference" runat="server" alt="search" ImageUrl="<%#GetImagePath%>" /></td>
    </tr>
    <tr>
    <td></td>
    <td colspan="2">        </td>
    </tr>
    </table>
<%--</asp:Panel>--%>
</div>