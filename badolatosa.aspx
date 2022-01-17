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
<title>Inland Andalucia | Badolatosa Andalucia</title>
<meta name="description" content="Badolatosa , a small village in the province of Seville, a typical Spanish village to enjoy the Spanish way of living. Buying your property in Baldolatosa guarantees living in true Spain " />
<meta name="keywords" content="badolatosa, andalucia, sevilla" />
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
<form ID="BadolatosaLocationInfo" RunAt="server">
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
  <h1><a href="propsearch.aspx?page=1&regionid=5&areaid=7&sort=price_asc"><span id="ViewProperties" runat="server" /></a>Badolatosa Andalucia</h1>
  <p>Badolatosa<%=GetTranslation("is a Spanish municipality in the province of Seville, Andalusia. In 2008 it had 3,228 inhabitants, including the hamlet of Corcoya..")%></p>
   <div class="row"><h2>  <%=GetTranslation("Quick information about Badolatosa")%>:</h2>
  <hr />
 <div class="townguidequick">
   <p><img src="images/icons/residents.png" alt="Residents" width="40" height="50" align="absmiddle" /> 3.200 <%=GetTranslation("residents")%></p>
   <p><img src="images/icons/school.png" alt="School" width="40" height="50" align="absmiddle" /> <%=GetTranslation("Schools")%></p>
   <p><img src="images/icons/distances.png" alt="Distances" width="40" height="50" align="left" />Antequera 43km<br />
     Malaga 86km<br />
       Granada 129km<br />
         Sevilla 131km</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />86km <%=GetTranslation("to")%> Malaga<br />
   </p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/hospital.png" alt="Hospital" width="40" height="50" align="absmiddle" /><%=GetTranslation("Health clinic")%></p>
   <p><img src="images/icons/pool.png" alt="Swimming pool" width="40" height="50" align="absmiddle" /><%=GetTranslation("Municipal pool")%></p>
   <p><img src="images/icons/beach.png" alt="Beach" width="40" height="50" align="absmiddle" /><%=GetTranslation("Beach")%> 1h</p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />129km <%=GetTranslation("to")%> Granada</p>
 </div>
 <div class="townguidequick">
   <p><img src="images/icons/shops.png" alt="Shops" width="40" height="50" align="absmiddle" /><%=GetTranslation("Shops, Bars, Restaurants")%></p>
   <p><img src="images/icons/golf.png" alt="Golf" width="40" height="50" align="absmiddle" /><%=GetTranslation("Golf nearby")%></p>
   <p><img src="images/icons/bus.png" alt="Bus" width="40" height="50" align="absmiddle" /><%=GetTranslation("Bus service")%></p>
   <p><img src="images/icons/airport.png" alt="Airport" width="40" height="50" align="absmiddle" />131km <%=GetTranslation("to")%> Sevilla</p>
 </div>
 </div>

 <div class="row"> <hr /><h3><%=GetTranslation("Badolatosa location")%></h3>
        <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel> 
  </div>
 <div class="row"> <hr />
  <h4><%=GetTranslation("Local Information")%></h4>
  <p><img src="images/townguide/badolatosa/badolatosa_coa.jpg"  alt="Badolatosa Coat of Arms"  hspace="10" align="left"><img src="images/townguide/badolatosa/badolatosa_1.jpg" alt="Town Hall, Badolatosa" width="160" height="120" border="0" align="right" class="borderimg"> </p>
  <p>Ayuntamiento de 
                          Badolatosa<br>
                          Avda. de Cuba, 32<br />
C.P. 41570 Badolatosa, 
                          Sevilla<br>
                          Telephone:  954 01 70 64 <br />
                          <a href="http://www.badolatosa.es/" target="_blank">http://www.badolatosa.es/</a></p>
  </div>
 
  
<div class="row"> <hr />
<h5><%=GetTranslation("Badolatosa information")%></h5>
  <div class="townguidecolumnright"><img src="images/townguide/badolatosa/badolatosa_2.jpg" alt="Badolatosa Andalucia street" class="borderimg"/>
  <img src="images/townguide/badolatosa/badolatosa_3.jpg" alt="Badolatosa Andalucia nature" class="borderimg" />
  <img src="images/townguide/badolatosa/badolatosa_4.jpg" alt="Badolatosa Andalucia nature" class="borderimg" /></div>
  <div class="townguidecolumnleft"><p><%=GetTranslation("The foundation of this town and their name seem to come from the Roman civilization. After the battle of Munda fought Julius Caesar against Pompey and his sons, in the year 45 BC, the Roman Emperor decided to punish the rebellious cities, as Urso (Osuna). It is thought that crossed the river "Sergelio" (Genil) passing by the "Vadus Latus" (Vado Ancho), ie the place where the people that think it was during this time the name of the town "Vadus latus ". The town began as group housing with Vado name of Booths.")%> </p>
  <p><%=GetTranslation("On the other hand, and much closer in history, it seems that the current BADOLATOSA name could come from the word "Badolatonsa" (Espaldar Wet), from the time of the Arab domination in the peninsula. At this time the town was an orchard, whose products are used to maintain the closest towns.")%></p>
  <p><%=GetTranslation("In 1549 the present location of the village was the same, calling themselves Baldelatosa and with a population of 11 residents and 6 more in Corcoya.")%></p>
  <p> 	
<%=GetTranslation("Towards the end of 1500 the core of the town began to develop around the Church. The lineage prospered from sixteenth century when it was given by the Marquis of Estepa, granted by King Philip II in 1562 to General Mar Marco Centurion. The sixth holder of this title received the Greatness of Spain at the time that this area was formed as Estepa neighborhood. It was then a place with a river with relatively shallow level and could be crossed on foot without difficulty and, hence, the name of the whole. For phonetic contraction is called the Shack Vado, then joined in a single word as Vadolatoza. In the late eighteenth started writing with a "b" home, while retaining the "z", Badolatoza. The current name first appears in the 1855 municipal seal.")%></p>
<p> 	
<%=GetTranslation("Around first half of the nineteenth century the town had a population of 2,107 inhabitants who lived in a total of 375 homes plus a 60 in the village of Corcoya. The streets are paved at this time, but one that was only on the sides, being the center of poplars planted earthen and this street was called Broad.")%></p>
<p> 	
<%=GetTranslation("In the early years of the eighteenth century was in this town like Andalusia largely a phenomenon quite common in those days, the Bandit. Resident of the town was one of the most famous outlaws of that time, was called José Ruiz Permana, nicknamed "germain". Together with José Maria Hinojosa "El Tempranillo", Juan Caballero and Jose Ruiz Permana, bandits were highlights of the day. On July 23, 1832, and through the mediation of his majesty Ferdinand I was awarded a royal pardon to the three aforementioned bandits and their headings, in the Chapel of Our Lady of Fuensanta of Corcoya.")%></p>


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
