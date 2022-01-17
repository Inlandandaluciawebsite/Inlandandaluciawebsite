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
<title>Inland Andalucia | El Rubio Andalucia</title>
<meta name="description" content="El Rubio is a small village in the province of Sevilla, the river Blanco runs from north to south giving rise to rich vegetation in this town " />
<meta name="keywords" content="el rubio, andalucia, sevilla" />
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
<form ID="El RubioLocationInfo" RunAt="server">
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
  <h1><a href="propsearch.aspx?page=1&regionid=5&areaid=7&sort=price_asc"><span id="ViewProperties" runat="server" /></a>El Rubio Andalucia</h1>
  <p><%=GetTranslation("The River Blanco is worth noting. It crosses the town from north to south, giving rise to rich vegetation on its way, such as eucalyptus trees. Nearby we can find the old spring of drinkable water, "La Fuente de la Teja", and a small dam. Back to this leisure area, called "El Cruce", we can enjoy picnic spots, camping areas, and facilities for doing sports such as tennis courts and other activities in contact with nature. In addition, in summer you can find a large swimming lake with big lawn areas.")%>:</h2>
  <hr />
 <div class="townguidequick">
   <p><img src="images/icons/residents.png" alt="Residents" width="40" height="50" align="absmiddle" /> 3573 <%=GetTranslation("residents")%></p>
   <p><img src="images/icons/school.png" alt="School" width="40" height="50" align="absmiddle" /> <%=GetTranslation("Schools")%></p>
   <p><img src="images/icons/distances.png" alt="Distances" width="40" height="50" align="left" />Antequera 64km<br />
     Malaga 111km<br />
       Granada 153km<br />
         Sevilla 108km</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />111km <%=GetTranslation("to")%> Malaga<br />
   </p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/hospital.png" alt="Hospital" width="40" height="50" align="absmiddle" /><%=GetTranslation("Health clinic")%></p>
   <p><img src="images/icons/pool.png" alt="Swimming pool" width="40" height="50" align="absmiddle" /><%=GetTranslation("Municipal pool")%></p>
   <p><img src="images/icons/beach.png" alt="Beach" width="40" height="50" align="absmiddle" /><%=GetTranslation("Beach")%> 1h15</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />153km <%=GetTranslation("to")%> Granada</p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/shops.png" alt="Shops" width="40" height="50" align="absmiddle" /><%=GetTranslation("Shops, Bars, Restaurants")%></p>
   <p><img src="images/icons/golf.png" alt="Golf" width="40" height="50" align="absmiddle" /><%=GetTranslation("Golf nearby")%></p>
   <p><img src="images/icons/bus.png" alt="Bus" width="40" height="50" align="absmiddle" /><%=GetTranslation("Bus service")%></p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />108km <%=GetTranslation("to")%> Sevilla</p>
 </div>
 </div>

 <div class="row"> <hr /><h3><%=GetTranslation("El Rubio location")%></h3>
        <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel> 
  </div>
 <div class="row"> <hr />
  <h4><%=GetTranslation("Local Information")%></h4>
  <p><img src="images/townguide/el-rubio/el-rubio_coa.jpg"  alt="El Rubio Coat of Arms"  hspace="10" align="left"><img src="images/townguide/el-rubio/el-rubio_2.jpg" alt="Town Hall, El Rubio" width="160" height="120" border="0" align="right" class="borderimg"> </p>
  <p>Ayuntamiento de 
                          El Rubio<br>
                          Beata, 11<br />
41568 – El Rubio (Sevilla)<br>
                          Telephone:  955 82 81 27 <br />
            <a href="http://www.elrubio.es/" target="_blank">http://www.elrubio.es/</a></p>
  </div>
 
  
<div class="row"> <hr />
<h5><%=GetTranslation("El Rubio information")%></h5>
  <div class="townguidecolumnright">
    <p><img src="images/townguide/el-rubio/el-rubio_1.jpg" alt="El Rubio Andalucia" class="borderimg"/></p>
    <p><img src="images/townguide/el-rubio/el-rubio_3.jpg" alt="El Rubio Andalucia" class="borderimg"/></p>
    <p><img src="images/townguide/el-rubio/el-rubio_4.jpg" alt="El Rubio Andalucia " class="borderimg"/></p>
  </div>
  <div class="townguidecolumnleft"><p><%=GetTranslation("In 1248, the town was conquered by the Spanish troops of Ferdinand III, being granted to the Order of Santiago in 1267.")%> </p>
  <p><%=GetTranslation("In Ecija Repartimiento village granted the gentleman Monclova Rubio Pascual Jimenez, according to other experts might have given the town its name (Puebla del Rubio). Around the farmhouse new homes also are built to accommodate the growing population, especially since the seventeenth century. The cortijada passes hands later duchy of Osuna, who belongs to the abolition of the domains in the nineteenth century.")%></p>
  <p><%=GetTranslation("The original nucleus is almond shaped sector located in the center of town, around the church and the city. Subsequent urban developments have relied on different paths or roads connecting the villages El Rubio and surrounding fields. The largest increases have occurred to the south-southwest (towards Osuna) and to the north, and to a lesser extent, to the east-northeast, toward Marinaleda. In the latter area, the village is very close to the river or stream White (tributary of the Genil), which coincides with the boundary of the municipality. The combination of both elements acts as a barrier to urban growth in this direction")%></p>
  <p><a href="images/townguide/el-rubio/el-rubio_5.jpg" target="_blank"><img src="images/townguide/el-rubio/el-rubio_5.jpg" alt="Town location map" width="400" height="497" border="0" /></a></p>

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
