<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EcijaLocationInfoback.aspx.vb" Inherits="EcijaLocationInfo" %>
<%@ Register Src="Controls/WebUserControlHeader.ascx" TagName="Header" TagPrefix="ucHeader" %>
<%@ Register Src="Controls/WebUserControlFooter.ascx" TagName="Footer" TagPrefix="ucFooter" %>
<%@ Register Src="Controls/WebUserControlNavigation.ascx" TagName="Navigation" TagPrefix="ucNavigation" %>
<%@ Register Src="Controls/WebUserControlSearchForm.ascx" TagName="SearchForm" TagPrefix="ucSearchForm" %>
<%@ Register src="Controls/WebUserControlTop30.ascx" tagname="Top30" tagprefix="ucTop30" %>
<%@ Register src="Controls/WebUserControlViewingTrip.ascx" tagname="ViewingTrip" tagprefix="ucViewingTrip" %>
<%@ Register src="Controls/WebUserControlTestimonial.ascx" tagname="Testimonial" tagprefix="ucTestimonial" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Inland Andalucia | Ecija Andalucia</title>
<meta name="description" content="Ecija Andalucia located in Sevilla province, a beautiful historical town with a lot to visit, located in between Sevilla and Cordoba, several magnificent baroque churches " />
<meta name="keywords" content="ecija, andalucia, sevilla" />
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
<form ID="EcijaLocationInfo" RunAt="server">
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
	    <ucTop30:Top30 id="Top301" runat="server" />
	    <ucViewingTrip:ViewingTrip id="ViewingTrip1" runat="server" />
	    <ucTestimonial:Testimonial id="Testimonial1" runat="server" />
	    <%
		Response.WriteFile("include/googlemap.aspx")
    %>
  </div>
  <div id="mainContent">
  <h1><a href="propsearch.aspx?page=1&regionid=5&areaid=322&sort=price_asc"><span id="ViewProperties" runat="server" /></a>Ecija Andalucia</h1>
 <p> 	

<%=GetTranslation("Avoid visiting")%> Ecija <%=GetTranslation("in the middle of summer. It once registered an alarming 52 degrees centigrade on the thermometer and is known as")%> La SartEn de Andalucia <%=GetTranslation("(the Frying-Pan of Andalucia) which is no exaggeration")%>.</p>

  <div class="row"> <hr /> <h2>  <%=GetTranslation("Quick information about")%> Ecija:</h2>
 <div class="townguidequick">
   <p><img src="images/icons/residents.png" alt="Residents" width="40" height="50" align="absmiddle" />38.000 <%=GetTranslation("residents")%></p>
   <p><img src="images/icons/school.png" alt="School" width="40" height="50" align="absmiddle" /> <%=GetTranslation("Schools")%></p>
   <p><img src="images/icons/distances.png" alt="Distances" width="40" height="50" align="left" />Antequera 84km<br />
Malaga 
                          130km<br />
Granada 180km<br />
Sevilla 100km<br />
   <br />
   </p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />130km <%=GetTranslation("to")%> Malaga<br />
   </p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/hospital.png" alt="Hospital" width="40" height="50" align="absmiddle" /><%=GetTranslation("Hospital, Health clinic")%></p>
   <p><img src="images/icons/pool.png" alt="Swimming pool" width="40" height="50" align="absmiddle" /><%=GetTranslation("Municipal pool")%></p>
   <p><img src="images/icons/beach.png" alt="Beach" width="40" height="50" align="absmiddle" /><%=GetTranslation("Beach")%> 1h</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />180km <%=GetTranslation("to")%> Granada</p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/shops.png" alt="Shops" width="40" height="50" align="absmiddle" /><%=GetTranslation("Shops, Bars, Restaurants")%></p>
   <p><img src="images/icons/golf.png" alt="Golf" width="40" height="50" align="absmiddle" /><%=GetTranslation("Golf nearby")%></p>
   <p><img src="images/icons/bus.png" alt="Bus" width="40" height="50" align="absmiddle" /><%=GetTranslation("Bus service")%></p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />100km <%=GetTranslation("to")%> Sevilla</p>
 </div>
 </div>
 <hr />
 <div class="row">
   <hr />
   <h3>Ecija location</h3>
    <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel> 
  </div>
  <div class="row"><hr />
  <h4><%=GetTranslation("Local Information")%></h4>
  <p align="left"><img src="images/photos/TownLocationInfo/ecija_coa.gif"  alt="Ecija Coat of Arms" hspace="10" align="left"><img src="images/photos/TownLocationInfo/ecija_ayuntamiento.jpg" alt="Ecija Town Hall" align="right" class="borderimg" /></p>
  <p>  	 Ayuntamiento de Ecija<br />
    Plaza de Espana, <br />
    1 41400 Ecija,<br /> 
    Sevilla 955-900-240<br />
    <a href="http://www.ecija.es" title="Ecija Town Hall" target="_blank">www.ecija.es</a></p>
  </div>

  
<div class="row">  <hr />
<h5>Ecija <%=GetTranslation("information")%></h5>
  <div class="townguidecolumnright"><img src="images/photos/TownLocationInfo/ecija5.jpg" alt="Ecija town" class="borderimg"/>
<img src="images/photos/TownLocationInfo/ecija6.jpg" alt="Ecija Andalucia centre" class="borderimg"/> 
 <img src="images/photos/TownLocationInfo/ecija7.jpg" alt="Ecija Andalucia building" class="borderimg"/><img src="images/photos/TownLocationInfo/ecija4.jpg" alt="Ecija Andalucia town centre" class="borderimg"/></div>
  <div class="townguidecolumnleft">
  <p> <%=GetTranslation("Located midway between Seville and")%> Cordoba <%=GetTranslation("in a valley of low hills")%>, Ecija <%=GetTranslation("is home to several magnificent baroque churches, the towers of each glisten with brilliantly colored tiles which can be spied from far in the distance. There are also some splendid houses here which date back to the 18th century when the local nobility bought homes in the town. Many of the mansions are particularly distinctive for their flamboyant architecture displaying interesting shapes and patterns")%>. </p>
  <p> <%=GetTranslation("Unfortunately, a major earthquake in 1757 did considerable damage to many of the buildings; however the churches were restored - at a considerable cost")%>.</p>
  <p> <%=GetTranslation("Things to see include the Roman mosaic on the ayuntamiento while two of the most spectacular towers are on the Santa Maria church and the Iglesia de San Juan Bautista. The tourist office also just happens to be housed in a former palace with a fabulous portal in contrasting tints of marble, while the")%> Museo Historico Municipal <%=GetTranslation("has a fine collection of artifacts in a serene setting of palms and patios. Another highlight is the impressive")%> Palacio de Penaflor <%=GetTranslation("on")%> Calle Castellar <%=GetTranslation("with a curved facade decorated with frescos and an elaborate baroque portal. Nearby is the")%> San Gil Gothic-MudEjar <%=GetTranslation("church which is also worth a camera shot or two")%>.</p>
  <p> <%=GetTranslation("The town of 38,000 has a beautiful municipal pool with bar/restaurant. The amenities are concentrated around the main Plaza. There is a planned 18 hole golf course. From")%> Ecija <%=GetTranslation("is a vía verde (greenway) that runs northeast to")%> Valchillon <%=GetTranslation("just south of Cordoba and southwest to Marchena. The")%> Via Verde <%=GetTranslation("of the Countryside can be used by walkers, cyclists or horse riders")%>. </p>
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
