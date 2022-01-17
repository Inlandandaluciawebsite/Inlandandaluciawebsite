<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Translation.aspx.vb" Inherits="ClassTranslation" %>
<%@ Register Src="Controls/WebUserControlHeader.ascx" TagName="Header" TagPrefix="ucHeader" %>
<%@ Register Src="Controls/WebUserControlFooter.ascx" TagName="Footer" TagPrefix="ucFooter" %>
<%@ Register Src="Controls/WebUserControlNavigation.ascx" TagName="Navigation" TagPrefix="ucNavigation" %>
<%@ Register Src="Controls/WebUserControlSearchForm.ascx" TagName="SearchForm" TagPrefix="ucSearchForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Spain property | Inland Andalucia</title>
<meta name="description" content="Spain property, buy your property in the south of Spain, list of properties, villas, town houses, country homes in Andalucia Spain" />
<meta name="keywords" content="spain property, properties Spain, Andalucia property" />
<%  Response.WriteFile("include/googlecode.aspx")%>
<link rel="Shortcut Icon" href="/Images/Icons/favicon.ico" type="image/x-icon"/>
<link href="css/style.css" rel="stylesheet" type="text/css" />


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
<form ID="Lista" RunAt="server">
<div id="container">
 <div id="header"><ucHeader:Header id="Header1" runat="server" />
  <div class="logo"> <a href="http://www.inlandandalucia.com"><img src="images/main/inlandandalucia.png" alt="Inland Andalucia Bargain Properties" width="354" height="170" border="0" /></a></div>
 </div>
  <div class="clearfloat"></div>
   <div class="topnavwrap"><ucNavigation:Navigation id="Navigation1" runat="server" />
      </div>
<div class="clearfloat"></div>
  <div class="wrap"> <div class="center"><div class="space"></div><div id="sidebar1">
		   
        <asp:ScriptManager id="ScriptManagerSearchForm" runat="server" EnablePartialRendering="true"/>
            <asp:UpdatePanel ID="UpdatePanelSearchForm" runat="server">
                <ContentTemplate>
                    <ucSearchForm:SearchForm id="WebUserControlSearchForm1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
    
<%	
	    Response.WriteFile("include/top30.aspx")
	    Response.WriteFile("include/invest2let.aspx")
	    Response.WriteFile("include/testimon.aspx")
    %>
  </div>
  <div id="mainContent">
    <h1>Spain Property list </h1>
    <p>At Inland Andalucia we have country, rural, inland property ranging from fincas , villas, townhouses to apartments. We specialise in the areas of Antequera, Cordoba, Granada, Jaen, Malaga and Sevilla where, with us you will find your ideal inland property. If you do not find what you are looking for please contact us, as we probably have it. </p>
    <p>&nbsp;</p>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td align="left" valign="top">
          <label>
          Order list by:
            <select name="Order price" class="propertylistselect" id="Order price">
              <option value="Choose" selected="selected">Choose</option>
              <option value="Price ascending">Price ascending</option>
              <option value="Prices descending">Prices descending</option>
              </select>
         
          </label>        </td>
        <td align="right" valign="top"><a href="#"><img src="images/buttons/new-search.gif" alt="New Search" width="125" height="31" hspace="10" /></a><a href="#"><img src="images/buttons/print.gif" alt="Print list" width="81" height="30" /></a></td>
      </tr>
    </table>
    <div class="propertylistpages">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td align="left" valign="top"><strong>X Properties found using your criteria</strong></td>
              <td align="right" valign="top"><a href="#">&laquo;</a> Page <a href="#">x</a> of <a href="#">x</a> <a href="#">&raquo;</a></td>
            </tr>
          </table>
      </div>
       <div class="propertylist">   <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="2" align="left" valign="top" bgcolor="#DDDDDD"><div class="propertylisthead">
      <span class="propertylistheadtype"> Property Type</span>/ <span class="propertylistheadtown"> Town </span> / <span class="propertylistheadref"> Reference number </span>
   <span class="propertylistheadprice"> <strong>Price:</strong> 0.00 &euro;</span></div>
   <div class="clearfloat"></div></td>
    </tr>
  <tr>
    <td width="25%" align="left" valign="middle" bgcolor="#FBFBFB"><a href="#"><img src="images/prop/featured-1.jpg" alt="Property image" width="200" height="150" class="propertylistimg" /></a></td>
    <td width="75%" align="left" valign="top" bgcolor="#FBFBFB"><div class="propertylistdetails">
      <p><strong>Beds: </strong>(if any)<strong> Baths: </strong> (if any) <strong>Built:</strong> (if any) <strong>Plot size: </strong>(if any)</p>
      <p><strong>Description:</strong></p>
    </div>
      <br />
      <br /></td>
  </tr>
  <tr>
    <td align="left" valign="top" bgcolor="#DDDDDD">&nbsp;</td>
    <td align="left" valign="top" bgcolor="#DDDDDD"><div class="propertylistbuttons"><a href="#"><img src="images/buttons/more-info.gif" alt="More info" width="116" height="31" /></a></div></td>
  </tr>
</table>
    </div>
    


   
       <div class="propertylist">
         <table width="100%" border="0" cellspacing="0" cellpadding="0">
           <tr>
             <td colspan="2" align="left" valign="top" bgcolor="#DDDDDD"><div class="propertylisthead"> <span class="propertylistheadtype"> Property Type</span>/ <span class="propertylistheadtown"> Town </span> / <span class="propertylistheadref"> Reference number </span> <span class="propertylistheadprice"> <strong>Price:</strong> 0.00 &euro;</span></div>
                 <div class="clearfloat"></div></td>
           </tr>
           <tr>
             <td width="25%" align="left" valign="middle" bgcolor="#FBFBFB"><img src="images/prop/featured-1.jpg" alt="Property image" width="200" height="150" class="propertylistimg" /></td>
             <td width="75%" align="left" valign="top" bgcolor="#FBFBFB"><div class="propertylistdetails">
                 <p><strong>Beds: </strong>(if any)<strong> Baths: </strong> (if any) <strong>Built:</strong> (if any) <strong>Plot size: </strong>(if any)</p>
               <p><strong>Description:</strong></p>
             </div>
                 <br />
                 <br /></td>
           </tr>
           <tr>
             <td align="left" valign="top" bgcolor="#DDDDDD">&nbsp;</td>
             <td align="left" valign="top" bgcolor="#DDDDDD"><div class="propertylistbuttons"><a href="#"><img src="images/buttons/more-info.gif" alt="More info" width="116" height="31" /></a></div></td>
           </tr>
         </table>
       </div>
       <div class="propertylist">
         <table width="100%" border="0" cellspacing="0" cellpadding="0">
           <tr>
             <td colspan="2" align="left" valign="top" bgcolor="#FACF00"><div class="propertylisthead"> <span class="propertylistheadtype"> FEATURED Property Type</span>/ <span class="propertylistheadtown"> Town </span> / <span class="propertylistheadref"> Reference number </span> <span class="propertylistheadprice"> <strong>Price:</strong> 0.00 &euro;</span></div>
                 <div class="clearfloat"></div></td>
           </tr>
           <tr>
             <td width="25%" align="left" valign="middle" bgcolor="#FBFBFB"><img src="images/prop/featured-1.jpg" alt="Property image" width="200" height="150" class="propertylistimg" /></td>
             <td width="75%" align="left" valign="top" bgcolor="#FBFBFB"><div class="propertylistdetails">
                 <p><strong>Beds: </strong>(if any)<strong> Baths: </strong> (if any) <strong>Built:</strong> (if any) <strong>Plot size: </strong>(if any)</p>
               <p><strong>Description:</strong></p>
             </div>
                 <br />
                 <br /></td>
           </tr>
           <tr>
             <td align="left" valign="top" bgcolor="#DDDDDD">&nbsp;</td>
             <td align="left" valign="top" bgcolor="#DDDDDD"><div class="propertylistbuttons"><a href="#"><img src="images/buttons/more-info.gif" alt="More info" width="116" height="31" /></a></div></td>
           </tr>
         </table>
       </div>
       <div class="propertylistpages">
         <table width="100%" border="0" cellspacing="0" cellpadding="0">
           <tr>
             <td align="left" valign="top"><strong>X Properties found using your criteria</strong></td>
             <td align="right" valign="top"><a href="#">&laquo;</a> Page <a href="#">x</a> of <a href="#">x</a> <a href="#">&raquo;</a></td>
           </tr>
         </table>
       </div>
       <p>&nbsp;</p>
      <!-- end #mainContent --></div>
	<!-- This clearing element should immediately follow the #mainContent div in order to force the #container div to contain all child floats --><br class="clearfloat" />
  <div id="footer">    <ucFooter:Footer id="Footer1" runat="server" />
  
  <!-- end #footer --></div></div></div>
<!-- end #container --></div>
</form>
</body>
</html>
