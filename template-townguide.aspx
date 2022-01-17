<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Translation.aspx.vb" Inherits="ClassTranslation" %>
<%@ Register Src="Controls/WebUserControlHeader.ascx" TagName="Header" TagPrefix="ucHeader" %>
<%@ Register Src="Controls/WebUserControlFooter.ascx" TagName="Footer" TagPrefix="ucFooter" %>
<%@ Register Src="Controls/WebUserControlNavigation.ascx" TagName="Navigation" TagPrefix="ucNavigation" %>
<%@ Register Src="Controls/WebUserControlSearchForm.ascx" TagName="SearchForm" TagPrefix="ucSearchForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Inland Andalucia | Aguadulce Andalucia</title>
<meta name="description" content="Aguadulce Andalucia, a small Andalucian village in Sevilla province, with about 2000 Residents, Aguadulce a typical Spanish village with amenities close by. " />
<meta name="keywords" content="aguadulce, andalucia, sevilla" />
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
<form ID="AguadulceLocationInfo" RunAt="server">
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
		Response.WriteFile("include/googlemap.aspx")
    %>
  </div>
  <div id="mainContent">
  <h1><a href="propsearch.aspx?page=1&regionid=&areaid=&sort=price_asc"><img src="images/buttons/view-properties.gif" alt="View properties" width="262" height="31" border="0" align="right" /></a>Aguadulce Andalucia</h1>
  <p>&nbsp;</p>
   <div class="row"><h2>&nbsp;</h2>
  <hr />
 <div class="townguidequick">
   <p><img src="images/icons/residents.png" alt="Residents" width="40" height="50" align="absmiddle" /> 2.000 </p>
   <p><img src="images/icons/school.png" alt="School" width="40" height="50" align="absmiddle" /></p>
   <p><img src="images/icons/distances.png" alt="Distances" width="40" height="50" align="left" />Antequera 60km<br />
     Malaga 105km<br />
       Granada 145km<br />
         Sevilla 100km</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />105km  Malaga<br />
   </p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/hospital.png" alt="Hospital" width="40" height="50" align="absmiddle" /></p>
   <p><img src="images/icons/pool.png" alt="Swimming pool" width="40" height="50" align="absmiddle" /></p>
   <p><img src="images/icons/beach.png" alt="Beach" width="40" height="50" align="absmiddle" /> 1h15</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />145km Granada</p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/shops.png" alt="Shops" width="40" height="50" align="absmiddle" /></p>
   <p><img src="images/icons/golf.png" alt="Golf" width="40" height="50" align="absmiddle" /></p>
   <p><img src="images/icons/bus.png" alt="Bus" width="40" height="50" align="absmiddle" /></p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />100km  Sevilla</p>
 </div>
 </div>

 <div class="row"> <hr /><h3>&nbsp;</h3>
 <iframe width="620" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.uk/maps?f=q&amp;source=s_q&amp;hl=en-GB&amp;geocode=&amp;q=Aguadulce,+Andaluc%C3%ADa&amp;aq=0&amp;oq=aguadulce+anda&amp;sll=40.396764,-3.713379&amp;sspn=12.291229,33.815918&amp;ie=UTF8&amp;hq=&amp;hnear=Aguadulce,+Sevilla,+Andaluc%C3%ADa&amp;t=m&amp;z=14&amp;ll=37.252467,-4.992743&amp;output=embed"></iframe><br /><small><a href="https://maps.google.co.uk/maps?f=q&amp;source=embed&amp;hl=en-GB&amp;geocode=&amp;q=Aguadulce,+Andaluc%C3%ADa&amp;aq=0&amp;oq=aguadulce+anda&amp;sll=40.396764,-3.713379&amp;sspn=12.291229,33.815918&amp;ie=UTF8&amp;hq=&amp;hnear=Aguadulce,+Sevilla,+Andaluc%C3%ADa&amp;t=m&amp;z=14&amp;ll=37.252467,-4.992743" style="text-align:left">View bigger map</a></small></div>

  <div class="row"> <hr />
  <h4>&nbsp;</h4>
  <p><img src="images/photos/TownLocationInfo/aguadulce_coa.gif"  alt="Aguadulce Coat of Arms" hspace="10" align="left"><img src="images/photos/TownLocationInfo/aguadulce1.jpg" alt="Town Hall, Aguadulce" class="borderimg" border="0" align="right"> </p>
  <p>Ayuntamiento de 
                          Aguadulce<br>
                          Plaza Ram&oacute;n y Caja, 1<br />
41550 Aguadulce, 
                          Sevilla<br>
                          Telephone: 954-816-220<br />
                          <a href="http://www.aguadulce.es/" target="_blank">http://www.aguadulce.es/</a></p>
  </div>
 
  
<div class="row"> <hr />
<h5>&nbsp;</h5>
  <div class="townguidecolumnright"><img src="images/photos/TownLocationInfo/aguadulce2.jpg" alt="Aguadulce Andalucia street" class="borderimg"/>
  <img src="images/photos/TownLocationInfo/aguadulce3.jpg" alt="Aguadulce Andalucia nature" class="borderimg" />
  <img src="images/photos/TownLocationInfo/aguadulce4.jpg" alt="Aguadulce Andalucia nature" class="borderimg" />
  <img src="images/photos/TownLocationInfo/aguadulce5.jpg" alt="Aguadulce Andalucia nature"  class="borderimg"/>
  <img src="images/photos/TownLocationInfo/aguadulce6.jpg" alt="Aguadulce Andalucia pre historic" class="borderimg" /></div>
  <div class="townguidecolumnleft"><p>&nbsp;</p>
  <p>&raquo;&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><%=GetTranslation("More information on towns of Andalucia")%></a> </div>
  </div>
   <div class="clearfloat"></div>
  </div>
	<div id="footer">    <ucFooter:Footer id="Footer1" runat="server" />
  
  <!-- end #footer --></div></div></div>
<!-- end #container --></div>
</form>
</body>
</html>
