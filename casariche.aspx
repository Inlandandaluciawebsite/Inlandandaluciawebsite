<%@ Page Language="VB" AutoEventWireup="false" CodeFile="aguadulceLocationInfo.aspx.vb" Inherits="aguadulceLocationInfo" %>
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
<title>Inland Andalucia | Casariche Andalucia</title>
<meta name="description" content="Casariche, located in the province Sevilla with over 5.600 inhabitants. A village rich in history, located at the River Mares. " />
<meta name="keywords" content="casariche, andalucia, sevilla" />
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
<form ID="CasaricheLocationInfo" RunAt="server">
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
  <h1><a href="propsearch.aspx?page=1&regionid=5&areaid=7&sort=price_asc"><span id="ViewProperties" runat="server" /></a>Casariche Andalucia</h1>
  <p>Casariche<%=GetTranslation("is a Spanish municipality in the province of Seville, Andalusia. In the year 2011 it had 5,611 inhabitants. The urban structure of the town is determined by two elements that have given their growth and development to date, these are the river and railway Mares. The original town center lies on the left bank of the river, forming an urban rather orthogonal. Subsequent expansions have occurred in an anarchic way in all directions, and especially between the channel and the railroad and west of it.")%>:</h2>
  <hr />
 <div class="townguidequick">
   <p><img src="images/icons/residents.png" alt="Residents" width="40" height="50" align="absmiddle" /> 5652 <%=GetTranslation("residents")%></p>
   <p><img src="images/icons/school.png" alt="School" width="40" height="50" align="absmiddle" /> <%=GetTranslation("Schools")%></p>
   <p><img src="images/icons/distances.png" alt="Distances" width="40" height="50" align="left" />Antequera 48km<br />
     Malaga 94km<br />
       Granada 137km<br />
         Sevilla 123km</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />94km <%=GetTranslation("to")%> Malaga<br />
   </p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/hospital.png" alt="Hospital" width="40" height="50" align="absmiddle" /><%=GetTranslation("Health clinic")%></p>
   <p><img src="images/icons/pool.png" alt="Swimming pool" width="40" height="50" align="absmiddle" /><%=GetTranslation("Municipal pool")%></p>
   <p><img src="images/icons/beach.png" alt="Beach" width="40" height="50" align="absmiddle" /><%=GetTranslation("Beach")%> 1h</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />137km <%=GetTranslation("to")%> Granada</p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/shops.png" alt="Shops" width="40" height="50" align="absmiddle" /><%=GetTranslation("Shops, Bars, Restaurants")%></p>
   <p><img src="images/icons/golf.png" alt="Golf" width="40" height="50" align="absmiddle" /><%=GetTranslation("Golf nearby")%></p>
   <p><img src="images/icons/bus.png" alt="Bus" width="40" height="50" align="absmiddle" /><%=GetTranslation("Bus service")%></p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />123km <%=GetTranslation("to")%> Sevilla</p>
 </div>
 </div>

 <div class="row"> <hr /><h3><%=GetTranslation("Casariche location")%></h3>
        <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel> 
  </div>
 <div class="row"> <hr />
  <h4><%=GetTranslation("Local Information")%></h4>
  <p><img src="images/townguide/casariche/casariche_coa.jpg"  alt="Casariche Coat of Arms"  hspace="10" align="left"><img src="images/townguide/casariche/casariche_1.jpg" alt="Town Hall, Casariche" width="160" height="120" border="0" align="right" class="borderimg"> </p>
  <p>Ayuntamiento de 
                          Casariche<br>
                          Pl. Alcalde José Ramón Parrado Cano, 1<br />
41580 – Casariche (Sevilla)<br>
                          Telephone:  954 019 911 <br />
                          <a href="http://www.casariche.es/" target="_blank">http://www.casariche.es/</a></p>
  </div>
 
  
<div class="row"> <hr />
<h5><%=GetTranslation("Casariche information")%></h5>
  <div class="townguidecolumnright"><img src="images/townguide/casariche/casariche_2.jpg" alt="Casariche Andalucia street" class="borderimg"/></div>
  <div class="townguidecolumnleft"><p><%=GetTranslation("The popular town history is inconceivable without reference to the river Mares, primarily responsible for the birth and progress of the people over the centuries and key element in the expansion and growth of the same. Born in Sierra Mares, in a place called Sierra de los Caballos, and reaches Casariche from La Roda de Andalucía. After talking through the town reaches Puente Genil, where it empties into the river Genil. The river runs up to 1 km from the town, and nearly 10 km through the town.")%> </p>
  <p><%=GetTranslation("Although currently its flow is quite poor (some even dry summers), was not always so. The age of the bridge and mill decenar that worked in the nineteenth century thanks to that, revealed that once presented a considerable flow. In the story are tragic floods of 1969 and 1973, when he came to overflow a bridge 14 meters high and causing damage to hundreds of homes. The most recent was in 2001, but without serious incidents.")%></p>
  <p><%=GetTranslation("In 2011, the population was distributed as follows. Of its 5,611 inhabitants, 5,109 live in the urban core, while the remaining 502 are spread by urbanized areas around the village, as the Riguelo, Ribera Baja, Cortijo Alameda and Vina Diego. Casariche is also a growing town, and a clear sign of this is the relative population increase of 6.94% recorded in the last year.")%></p>
  

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
