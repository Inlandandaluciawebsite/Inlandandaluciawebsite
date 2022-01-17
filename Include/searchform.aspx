<%@ Page Language="vb" AutoEventWireup="false" CodeFile="SearchForm.aspx.vb" Inherits="SearchForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">

         <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td>   <h4> Quick Search</h4></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>Region:</td>
            <td>
                <asp:DropDownList ID="DropDownListRegion" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="DropDownListRegions_SelectedIndexChanged" >                </asp:DropDownList>              </td>
          </tr>
          <tr>
            <td>Area:</td>
            <td><asp:DropDownList ID="DropDownListArea" runat="server"></asp:DropDownList></td>
          </tr>
          <tr>
            <td>Price:</td>
            <td>
                <asp:DropDownList ID="DropDownListPriceFrom" runat="server" AutoPostBack="True">                </asp:DropDownList>
&nbsp;to
                <asp:DropDownList ID="DropDownListPriceTo" runat="server" AutoPostBack="True">                </asp:DropDownList>              </td>
          </tr>
          <tr>
            <td>Type:</td>
            <td>
                <asp:DropDownList ID="DropDownListType" runat="server">                </asp:DropDownList>              </td>
          </tr>
                      <tr>
            <td>Bedrooms:</td>
            <td>
                <asp:DropDownList 
                    ID="DropDownListBedrooms" runat="server">                </asp:DropDownList>
           <br />           </td>
          </tr>
                      <tr>
            <td></td>
            <td>
                <asp:Button ID="SearchFilter" runat="server" Text="Search" />           </td>
          </tr>
       </table>
  <hr />
          <h4>Search by Reference</h4>
         <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td>Reference:</td>
            <td><asp:TextBox ID="TextBoxReference" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td></td>
            <td>
                <asp:Button ID="SearchReference" runat="server" Text="Search" />
              </td>
          </tr>
        </table>
    </form>
</body>
</html>
