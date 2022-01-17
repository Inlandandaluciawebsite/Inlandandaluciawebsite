<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Translation.aspx.vb" Inherits="ClassTranslation" %>
<%@ Register Src="Controls/WebUserControlHeader.ascx" TagName="Header" TagPrefix="ucHeader" %>
<%@ Register Src="Controls/WebUserControlFooter.ascx" TagName="Footer" TagPrefix="ucFooter" %>
<%@ Register Src="Controls/WebUserControlNavigation.ascx" TagName="Navigation" TagPrefix="ucNavigation" %>
<%@ Register Src="Controls/WebUserControlSearchForm.ascx" TagName="SearchForm" TagPrefix="ucSearchForm" %>
<%@ Register src="Controls/WebUserControlTop30.ascx" tagname="Top30" tagprefix="ucTop30" %>
<%@ Register src="Controls/WebUserControlViewingTrip.ascx" tagname="ViewingTrip" tagprefix="ucViewingTrip" %>
<%@ Register src="Controls/WebUserControlTestimonial.ascx" tagname="Testimonial" tagprefix="ucTestimonial" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Inland Andalucia | Town Guide</title>
<meta name="description" content="Town guide for Andalucia, more useful information of different towns in Andalucia such as Aguadulce, Antequera, Arahal, Archidona, Campillos, Carmona, Écija, El Saucejo, Alameda, Fuente de Piedra ,Herrera, Humilladero, La Luisiana, La Puebla de Cazalla, La Roda de Andalucia, Marchena, Marinaleda, Mollina, Morón de la Frontera, Osuna, Sevilla, Sierra de Yeguas, Villanueva de Algaidas " />
<meta name="keywords" content="town, guide, andalucia, Aguadulce, Antequera, Alameda, Arahal, Archidona, Campillos, Carmona, Écija, El Saucejo, Alameda, Fuente de Piedra ,Herrera, Humilladero, La Luisiana, La Puebla de Cazalla, La Roda de Andalucia, Marchena, Marinaleda, Mollina, Morón de la Frontera, Osuna, Sevilla, Sierra de Yeguas, Villanueva de Algaidas" />
<%  Response.WriteFile("include/googlecode.aspx")%>
<link rel="Shortcut Icon" href="/Images/Icons/favicon.ico" type="image/x-icon"/>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="/js/CheckFieldsContactForm.js" type="text/javascript"></script>


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
<form ID="TownLocationInfo" RunAt="server">
<div id="container">
 <div id="header"><ucHeader:Header id="Header1" runat="server" />
  <div class="logo"> <a href="http://www.inlandandalucia.com"><img src="images/main/inlandandalucia.png" alt="Inland Andalucia Bargain Properties" width="354" height="170" border="0" /></a></div>
 </div>
  <div class="clearfloat"></div>
   <div class="topnavwrap"><ucNavigation:Navigation id="Navigation1" runat="server" />
      </div>
<div class="clearfloat"></div>
  <div class="wrap"> <div class="center"><img src="images/photos/townguide.jpg" alt="Town guide" /><div class="space"></div><div id="sidebar1">
		   
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
  <h1>Our complete guide for Andaluc&iacute;a</h1
  ><div class="row">
  <div class="townguidecolumn"><p><strong><a href="SevillaInfo.aspx" target="_self" title="Click here to see properties in Sevilla" style="text-decoration:underline;">Sevilla</a></strong></p>
    <p><a  href="aguadulceLocationInfo.aspx" title="Useful information of Aguadulce, Sevilla">Aguadulce</a><br />
      <a  href="arahalLocationInfo.aspx" title="Useful information of Arahal, Sevilla">Arahal</a><br />
      Badolatosa<br />
      <a  href="CarmonaLocationInfo.aspx" title="Useful information of Carmona, Sevilla">Carmona</a><br />
      Casariche<br />
      <a  href="EcijaLocationInfo.aspx" title="Useful information of Écija, Sevilla">&Eacute;cija</a><br />
      El Rig&uuml;elo<br />
      El Rubio<br />
      <a  href="SaucejoLocationInfo.aspx" title="Useful information of El Saucejo, Sevilla">El Saucejo</a><br />
      <a  href="EstepaLocationInfo.aspx" title="Useful information of Alameda, Sevilla">Estepa </a><br />
      <a  href="herreraLocationInfo.aspx" title="Useful information of Herrera, Sevilla">Herrera</a><br />
      Isla Redonda<br />
      <a  href="laluisianaLocationInfo.aspx" title="Useful information of La Luisiana, Sevilla">La Luisiana</a><br />
      <a  href="lapuebladecazallaLocationInfo.aspx" title="Useful information of La Puebla de Cazalla, Sevilla">La Puebla de Cazalla</a><br />
      <a  href="LaRodaLocationInfo.aspx" title="Useful information of La Roda de Andalucia, Sevilla">La Roda de Andalucia</a><br />
      Lora de Estepa<br />
      Los P&eacute;rez<br />
      <a  href="MarchenaLocationInfo.aspx" title="Useful information of Marchena, Sevilla">Marchena</a><br />
      <a  href="MarinaledaLocationInfo.aspx" title="Useful information of Marinaleda, Sevilla">Marinaleda</a><br />
      Matarredonda<br />
      <a  href="MoronLocationInfo.aspx" title="Useful information of Morón de la Frontera, Sevilla">Mor&oacute;n de la Frontera</a><br />
      <a  href="OsunaLocationInfo.aspx" title="Useful information of Osuna, Sevilla">Osuna</a><br />
      Pruna<br />
      <a  href="sevillaLocationInfo.aspx" title="Useful information of Sevilla, Sevilla">Sevilla</a><br>

      </p>
    <br>
  </div>
  <div class="townguidecolumn">
    <p><strong><a href="CordobaInfo.aspx" target="_self" title="Click here to see properties in Cordoba" style="text-decoration:underline;">Cordoba</a></strong></p>
    <p><a href="guide-almedinilla.aspx" title="Almedinilla">Almedinilla</a><br />
      Benamej&iacute;<br />
      <a href="guide-carcabuey.aspx" title="Carcabuey">Carcabuey</a><br />
      Castil de Campos<br />
      Encinas Reales<br />
      <a href="guide-iznajar.aspx" title="Iznajar">Iznajar</a><br />
      Jauja<br />
      Lucena<br />
      Palenciana<br />
      <a href="guide-priego-of-cordoba.aspx" title="Priego de Cordoba">Priego de Cordoba</a><br />
      Puente Genil<br />
      Rute</p>
      <p><strong><a href="http://www.ics-login.com/MalagaInfo.aspx" target="_self" title="Click here to see properties in Málaga" style="text-decoration:underline;">M&aacute;laga</a></strong></p>
    <p><a  href="AlamedaLocationInfo.aspx" title="Useful information of Alameda, Málaga">Alameda<br />
      </a><a  href="AntequeraLocationInfo.aspx" title="Useful information of Antequera, Málaga">Antequera </a><a  href="AlamedaLocationInfo.aspx" title="Useful information of Alameda, Málaga"><br />
      </a><a  href="ArchidonaLocationInfo.aspx" title="Useful information of Archidona, Málaga">Archidona</a><br />
      Bobadilla Estaci&oacute;n<br />
      Ca&ntilde;ada de Pareja<br />
      <a  href="CampillosLocationInfo.aspx" title="Useful information of Campillos, Málaga">Campillos</a><br />
      Casabermeja<br />
      Cuevas Bajas<br />
      Cuevas de San Marcos<br />
      <a  href="Fuente_de_PiedraLocationInfo.aspx" title="Useful information of Fuente de Piedra, Málaga">Fuente de Piedra</a><br />
      <a  href="HumilladeroLocationInfo.aspx" title="Useful information of Humilladero, Málaga">Humilladero</a><br />
      <a  href="MollinaLocationInfo.aspx" title="Useful information of Mollina, Málaga">Mollina<br />
      </a><a  href="Sierra_de_YeguasLocationInfo.aspx" title="Useful information of Sierra de Yeguas, Málaga">Sierra de Yeguas</a><br />
      <a  href="Villanueva_de_AlgaidasLocationInfo.aspx" title="Useful information of Villanueva de Algaidas, Málaga">Villanueva de Algaidas</a><br />
      Villanueva de Trabuco <br />
    </p>
  </div>
 <div class="townguidecolumn">
    <p><strong><a href="GranadaInfo.aspx" target="_self" title="Click here to see properties in " style="text-decoration:underline;">Granada</a></strong></p>
    <p>Algarinejo<br />
      Alomartes<br />
      Baza<br />
      Fornes<br />
      Huetor-Tajar<br />
      Loja<br />
      Montefr&iacute;o<br />
      Montesol<br />
      Montillana<br />
      Salar<br />
      Salinas<br />
      Zagra</p>
  </div>
  <div class="townguidecolumn">
    <p><strong><a href="JaenInfo.aspx" target="_self" title="Click here to see properties in Cádiz" style="text-decoration:underline;">Ja&eacute;n</a></strong></p>
    <p><a href="guide-alcala-la-real.aspx" title="Alcalá la Real">Alcal&aacute; la Real</a><br />
      <a href="guide-alcaudete.aspx" title="Alcaudete">Alcaudete</a><br />
      Castillo de Locubin<br />
      Charilla<br />
      Ermita Nueva<br />
      Frailes<br />
      Fuente-Alamo<br />
      La Carrasca<br />
      La Laguna<br />
      La Pedriza<br />
      La Rabita<br />
      Las Casillas de Martos<br />
      <a href="guide-martos.aspx" title="Martos">Martos</a><br />
      Ribera Alta<br />
      San Jose de la Rabita<br />
      Santiago de Calatrava<br />
      Venta de los Agramaderos<br />
      Ventas de Carrizal<br />
      Villalobos<br />
      Villar Bajo</p>
    <br />
  </div>
  
  </div>
  <div class="row">
  <div class="townguidecolumnright"><img src="images/photos/VillageLocationInfo1.jpg" class="borderimg" title="Nature Andalucia" ><br />
    <img src="images/photos/VillageLocationInfo2.jpg" class="borderimg" title="Mountain Andalucia"><br />
    <img src="images/photos/VillageLocationInfo4.jpg" class="borderimg" title="Alameda Andalucia"><br />
    <img src="images/photos/VillageLocationInfo3.jpg" class="borderimg" title="Street in Andalucia"><br />
  </div>
  <div class="townguidecolumnleft">
    <h2>Andalucia is unique</h2>
    <p>With so many hundreds of white washed villages in Andalucia it's difficult to know which the right one for you is. We always suggest that before you start looking for a home, you should spend some time looking for an area. Here in Spain you will spend considerably more time outdoors so it's essential that your environment and surroundings are comfortable. Buy the area first and then you're home!</p>
    <p>There are countless beautiful areas in which to buy your Spanish property, we focus on key areas around Alcala de Real, Antequera, Estepa and Marchena. The unrivalled natural beauty of the area, the friendliness of the local people, the facilities, amenities, the transportation infrastructure and the amazing value for money you get here makes it the perfect area to find your <a href="PropSearch.aspx" title="Are you looking for the Spanish Dream Home? We have it. Click here.">Spanish Dream Home</a>.</p>
    <p>The areas around the Montes of Malaga, Granada, Sierras of Cordoba, Subbetica and Cadiz offer wonderful mountains and incredible views but may not be practical for a retired couple or a young family. The corridor from Antequera to Sevilla is a vast plain and most of the villages in the area are flat making village life very comfortable with easy access to everything!</p>
    <p>The small villages in the Antequera, Estepa and Marchena area have all the amenities you'll need but you may need to ask around in the beginning as most shops are run from the ground floor of the proprietor's house and seldom have a sign! A larger town is always nearby for high street shopping and other services.</p>
  </div>
   </div>
   
  </div>  <div class="clearfloat"></div>
	<div id="footer">    <ucFooter:Footer id="Footer1" runat="server" />
  
  <!-- end #footer --></div></div></div>
<!-- end #container --></div>
</form>
</body>
</html>
