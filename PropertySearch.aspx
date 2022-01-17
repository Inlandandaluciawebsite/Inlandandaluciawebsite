<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PropertySearch.aspx.vb" Inherits="PropertySearch" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Andalucia property | Inland Andalucia</title>
<meta name="description" content="Andalucia property, find your property in Inland Andalucia, we have a great amount of inland properties in Andalucia at bargain prices. Buy your property, villa, town house, finca, through a reliable Andalucia Real Estate" />
<meta name="keywords" content="spain property, properties Spain, Andalucia property" />
<%  Response.WriteFile("include/googlecode.aspx")%>
<link rel="Shortcut Icon" href="/Images/Icons/favicon.ico" type="image/x-icon"/>
<link href="css/style.css" rel="stylesheet" type="text/css" /><link rel="stylesheet" href="http://weatherandtime.net/new_wid/w_2/style.css" type="text/css" media="screen" />


<!--[if IE 5]>
<style type="text/css"> 
/* place css box model fixes for IE 5* in this conditional comment */
.twoColFixRtHdr #sidebar1 { width: 220px; }
</style>
<![endif]--><!--[if IE]>
<style type="text/css"> 
/* place css fixes for all versions of IE in this conditional comment */
.twoColFixRtHdr #sidebar1 { padding-top: 30px; }
.twoColFixRtHdr #mainContent { zoom: 1; }
/* the above proprietary zoom property gives IE the hasLayout it needs to avoid several bugs */
</style>
<![endif]-->
</head>

<body class="twoColFixRtHdr">
<form ID="PropertySearch" RunAt="server">
<div id="container">
 <div id="header"><ucHeader:Header id="Header1" runat="server" />
  <div class="logo"> <a href="http://www.inlandandalucia.com"><img src="images/main/inlandandalucia.png" alt="Inland Andalucia Bargain Properties" width="354" height="170" border="0" /></a></div>
 </div>
  <div class="clearfloat"></div>
   <div class="topnavwrap"><ucNavigation:Navigation id="Navigation1" runat="server" />
      </div>
<div class="clearfloat"></div>
  <div class="wrap"> <div class="center"><div class="space"></div><div id="sidebar1">
		<%		   
	    Response.WriteFile("include/top30.aspx")
	    Response.WriteFile("include/invest2let.aspx")
	    Response.WriteFile("include/googlemap.aspx")
    %>
  </div>
  <div id="mainContent">
    <form ID="PropertySearchForm" RunAt="server">
    <asp:ScriptManager id="ScriptManagerPropertySearch" EnablePartialRendering="true" runat="server" />            
    <h1>Andalucia Property </h1>
    <p>At Inland Andalucia we have country, rural, inland property ranging from fincas , villas, townhouses to apartments. We specialise in the areas of Antequera, Cordoba, Granada, Jaen, Malaga and Sevilla where, with us you will find your ideal inland property. If you do not find what you are looking for please <a href="contactus.aspx" title="contact us">contact us</a>, as we probably have it. </p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <div class="propertysearch">
      <h2>Property search (advanced)</h2>
      <div class="propertysearchbox">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="18%">Area:</td>
            <td width="29%">
                <asp:DropDownList ID="DropDownListRegion" runat="server" 
                    CssClass="propertysearchselect" OnSelectedIndexChanged="DropDownListRegion_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td width="16%">Town:</td>
            <td width="37%">
                <asp:UpdatePanel ID="UpdatePanelArea" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DropDownListArea" runat="server" CssClass="propertysearchselect" OnSelectedIndexChanged="DropDownListArea_SelectedIndexChanged" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownListRegion" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
          </tr>
          <tr>
            <td>Property type:</td>
            <td>
                <asp:DropDownList ID="DropDownListType" runat="server" 
                    CssClass="propertysearchselect">
                </asp:DropDownList>
            </td>
            <td>Village:</td>
            <td>
                <asp:DropDownList ID="DropDownListSubArea" runat="server" 
                    CssClass="propertysearchselect">
                </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td>Min. Beds:</td>
            <td>
                <asp:DropDownList ID="DropDownListBedrooms" runat="server" 
                    CssClass="propertysearchselectsmall">
                </asp:DropDownList>
            </td>
            <td>Min. Baths:</td>
            <td>
                <asp:DropDownList ID="DropDownListBathrooms" runat="server" 
                    CssClass="propertysearchselectsmall">
                </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td>Price from:</td>
            <td>
                <asp:DropDownList ID="DropDownListPriceFrom" runat="server" 
                    CssClass="propertysearchselect" OnSelectedIndexChanged="DropDownListPriceFrom_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>to:</td>
            <td>
                <asp:DropDownList ID="DropDownListPriceTo" runat="server" 
                    CssClass="propertysearchselect" OnSelectedIndexChanged="DropDownListPriceTo_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td>
                <label>
                    <asp:Button ID="SearchFilter" runat="server" Text="SEARCH" CssClass="propertysearchsubmit" />
                </label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
        </table>
      </div>
      <h3> Property search by reference</h3>
      <div class="propertysearchbox">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="20%">Reference number:</td>
          <td width="27%">
            <label>
              <asp:TextBox ID="TextBoxReference" runat="server" CssClass="propsearchtext"></asp:TextBox>
            </label></td>
          <td width="53%"><asp:Button ID="SearchReference" runat="server" Text="SEARCH" CssClass="propertysearchsubmit" /></td>
        </tr>
      </table>
      <p>&nbsp;</p>
    </div>
    </form>
  </div>
 <p>&nbsp;</p>
 <p>&nbsp;</p> <p>&nbsp;</p>
 <p>&nbsp;</p> <p>&nbsp;</p>
 <p>&nbsp;</p> <p>&nbsp;</p>
 <p>&nbsp;</p> <p>&nbsp;</p>
 <p>&nbsp;</p>
    <!-- end #mainContent --></div>
	<!-- This clearing element should immediately follow the #mainContent div in order to force the #container div to contain all child floats --><br class="clearfloat" />
  <div id="footer">    <ucFooter:Footer id="Footer1" runat="server" />
  
  <!-- end #footer --></div></div></div>
<!-- end #container --></div>
</form>
</body>
</html>
