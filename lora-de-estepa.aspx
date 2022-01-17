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
<title>Inland Andalucia | Lora de Estepa Andalucia</title>
<meta name="description" content="Lora de Estepa is a very small but nice village in the province of Sevilla, with only 871 habitants and a annual temperature of 15 ºC " />
<meta name="keywords" content="Lora de Estepa, andalucia, sevilla" />
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
<form ID="Lora de EstepaLocationInfo" RunAt="server">
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
  <h1><a href="propsearch.aspx?page=1&regionid=5&areaid=7&sort=price_asc"><span id="ViewProperties" runat="server" /></a>Lora de Estepa Andalucia</h1>
  <p><%=GetTranslation("The Municipality of Lora de Estepa is located in the south-east of the province of Seville, has a flat surface for the most part, and is dominated by Sierra calf belonging to the points named Piedra del Aguila, Cerro de Guichón and Hacho in the northern end, which occupy a quarter of the municipality, with a total area of 1,876 hectares. Its average height above sea level is 447 meters. It borders the municipality with Estepa mostly, except for the northwest, which borders Casariche and far from the capital 112 km towards Málaga by the A-92. It has a population of 788 inhabitants of law, according to the Municipal Register of 2.003, which practically living in the population, there is also an unsettled foreign population and occupying other houses as second homes in the summer, which can be estimated in 400 people.")%>:</h2>
  <hr />
 <div class="townguidequick">
   <p><img src="images/icons/residents.png" alt="Residents" width="40" height="50" align="absmiddle" /> 871 <%=GetTranslation("residents")%></p>
   <p><img src="images/icons/school.png" alt="School" width="40" height="50" align="absmiddle" /> <%=GetTranslation("Schools")%></p>
   <p><img src="images/icons/distances.png" alt="Distances" width="40" height="50" align="left" />Antequera 44km<br />
     Malaga 90km<br />
       Granada 133km<br />
         Sevilla 117km</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />90km <%=GetTranslation("to")%> Malaga<br />
   </p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/hospital.png" alt="Hospital" width="40" height="50" align="absmiddle" /><%=GetTranslation("Health clinic")%></p>
   <p><img src="images/icons/pool.png" alt="Swimming pool" width="40" height="50" align="absmiddle" /><%=GetTranslation("Municipal pool")%></p>
   <p><img src="images/icons/beach.png" alt="Beach" width="40" height="50" align="absmiddle" /><%=GetTranslation("Beach")%> 1h</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />133km <%=GetTranslation("to")%> Granada</p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/shops.png" alt="Shops" width="40" height="50" align="absmiddle" /><%=GetTranslation("Shops, Bars, Restaurants")%></p>
   <p><img src="images/icons/golf.png" alt="Golf" width="40" height="50" align="absmiddle" /><%=GetTranslation("Golf nearby")%></p>
   <p><img src="images/icons/bus.png" alt="Bus" width="40" height="50" align="absmiddle" /><%=GetTranslation("Bus service")%></p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />117km <%=GetTranslation("to")%> Sevilla</p>
 </div>
 </div>

 <div class="row"> <hr /><h3><%=GetTranslation("Lora de Estepa location")%></h3>
        <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel> 
  </div>
 <div class="row"> <hr />
  <h4><%=GetTranslation("Local Information")%></h4>
  <p><img src="images/townguide/lora-de-estepa/lora-de-estepa_coa.jpg"  alt="Lora de Estepa Coat of Arms"  hspace="10" align="left"><img src="images/townguide/lora-de-estepa/lora-de-estepa_2.jpg" alt="Town Hall, Lora de Estepa" width="160" height="120" border="0" align="right" class="borderimg"> </p>
  <p>Ayuntamiento de 
                          Lora de Estepa<br>
                          Plaza de Andalucia, nº15<br />
41564 – Lora de Estepa (Sevilla)<br>
                          Telephone:  954 82 90 11<br />
            <a href="http://www.loradeestepa.es/" target="_blank">http://www.loradeestepa.es/</a></p>
  </div>
 
  
<div class="row"> <hr />
<h5><%=GetTranslation("Lora de Estepa information")%></h5>
  <div class="townguidecolumnright">
    <p><img src="images/townguide/lora-de-estepa/lora-de-estepa_1.jpg" alt="Lora de Estepa Andalucia" class="borderimg"/></p>
    <p><img src="images/townguide/lora-de-estepa/lora-de-estepa_3.jpg" alt="Lora de Estepa Andalucia" class="borderimg"/></p>
    <p><img src="images/townguide/lora-de-estepa/lora-de-estepa_4.jpg" alt="Lora de Estepa Andalucia " class="borderimg"/></p>
  </div>
  <div class="townguidecolumnleft"><p><%=GetTranslation("Its origins date back to Roman times, although the study of Palaeolithic remains abundant confirms the existence of settlements since the dawn of humanity. An example of this are the Chalcolithic caves with more than 4,000 years old that housed a wide variety of parts such as axes, pottery and funerary icons unpublished. Also left their mark Tartessian and Iberian cultures as demonstrated by architectural structures appeared in "The Hachillo".")%> </p>
  <p><%=GetTranslation("Already in Roman times establishing a greater population center called Olaura recreation building villas with rich mosaics. Only today has reached the votive pit, the popular town road bridge, inscriptions, tombstones and mosaics of a villa. Later, Muslims used a complex system of irrigation, by ditches, to enhance the wealth of garden products, considered as a real orchard Lora, and introducing, in turn, growing species like thyme and rosemary.")%></p>
  

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
