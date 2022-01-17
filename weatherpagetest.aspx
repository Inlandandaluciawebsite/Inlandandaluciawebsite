<%@ Page Language="VB" AutoEventWireup="false" CodeFile="weatherpagetest.aspx.vb" Inherits="weatherpagetest" %>

<%@ Register Src="Controls/WebUserControlHeader.ascx" TagName="Header" TagPrefix="ucHeader" %>
<%@ Register Src="Controls/WebUserControlFooter.ascx" TagName="Footer" TagPrefix="ucFooter" %>
<%@ Register Src="Controls/WebUserControlNavigation.ascx" TagName="Navigation" TagPrefix="ucNavigation" %>
<%@ Register Src="Controls/WebUserControlSearchForm.ascx" TagName="SearchForm" TagPrefix="ucSearchForm" %>
<%@ Register src="Controls/WebUserControlTop30.ascx" tagname="Top30" tagprefix="ucTop30" %>
<%@ Register src="Controls/WebUserControlViewingTrip.ascx" tagname="ViewingTrip" tagprefix="ucViewingTrip" %>
<%@ Register src="Controls/WebUserControlTestimonial.ascx" tagname="Testimonial" tagprefix="ucTestimonial" %>
<%@ Register src="Controls/WebUserControlTownGuide.ascx" tagname="TownGuide" tagprefix="ucTownGuide" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Inland Andalucia | The weather in  Andalucia</title>
<meta name="description" content="Everything about the weather in Andalucia. What is the weather right now? What to expect in which region or province? Weather map and predictions for every province. " />
<meta name="keywords" content=" andalucia, andalusia, weather" />
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
<form ID="Weather" RunAt="server">
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
  <h1><%=("The weather in Andalucia")%>:</h1>
  <p><%=("Check the Weather Forecast in any region of Andalucia by clicking the Map")%></p>
  <div id="weatherlayer" style="position:relative;top:10px;" align="center">
  <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="550" height="317">
    <param name="movie" value="Flash/andalusiaweathermap.swf">
    <param name="quality" value="high">
    <embed src="Flash/andalusiaweathermap.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="550" height="317"></embed>
  </object>
</div>
<p>&nbsp;</p>
<p><%=("Or check it on differents towns of each region in Andalucia")%>

</p>
<br>
<table cellpadding="0" cellspacing="0" border="0" class="BlueText" width="400"  align="center" style="text-align:left;">
<tr>
<td colspan="2"><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0052" title="Click here to check Weather Forecast in Malaga Province, Andalusia, Spain" style="text-decoration:underline" target="_blank">MALAGA</a></td>
<td colspan="2"><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0009" title="Click here to check Weather Forecast in Almeria Province, Andalusia, Spain" style="text-decoration:underline" target="_blank">ALMERIA</a></td>
</tr>
<tr>
<td width="30px"></td>
<td valign="top">
<a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0089" title="Click here to check Weather Forecast in Antequera, Andalusia, Spain" style="text-decoration:underline" target="_blank">Antequera</a>
<br>
<a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0121" title="Click here to check Weather Forecast in Ronda, Andalusia, Spain" style="text-decoration:underline" target="_blank">Ronda</a>
<br>
<a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0054" title="Click here to check Weather Forecast in Marbella, Andalusia, Spain" style="text-decoration:underline" target="_blank">Marbella</a>
<br>
</td>
<td width="30px"></td>
<td valign="top">
<a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0032" title="Click here to check Weather Forecast in El Ejido, Andalusia, Spain" style="text-decoration:underline" target="_blank">El Ejido</a>
</td>
</tr>
<tr>
<td colspan="2"><br><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0220" title="Click here to check Weather Forecast in Cordoba Province, Andalusia, Spain" style="text-decoration:underline" target="_blank">CORDOBA</a></td>
<td colspan="2"><br><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0074" title="Click here to check Weather Forecast in Sevilla Province, Andalusia, Spain" style="text-decoration:underline" target="_blank">SEVILLA</a></td>
</tr>
<tr>
<td></td>
<td valign="top">&nbsp;</td>
<td></td>
<td valign="top"><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0028" title="Click here to check Weather Forecast in Ecija, Andalusia, Spain" style="text-decoration:underline" target="_blank">Ecija</a> <br>
  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0081" title="Click here to check Weather Forecast in Utrera, Andalusia, Spain" style="text-decoration:underline" target="_blank">Utrera</a> <br>
  </td>
</tr>
<tr>
<td colspan="2"><br><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0040" title="Click here to check Weather Forecast in Granada Province, Andalusia, Spain" style="text-decoration:underline" target="_blank">GRANADA</a></td>
<td colspan="2"><br><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0225" title="Click here to check Weather Forecast in Huelva Province, Andalusia, Spain" style="text-decoration:underline" target="_blank">HUELVA</a></td>
</tr>
<tr>
<td></td>
<td valign="top">
<a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0042" title="Click here to check Weather Forecast in Guadix, Andalusia, Spain" style="text-decoration:underline" target="_blank">Guadix</a> <br>
  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0058" title="Click here to check Weather Forecast in Motril, Andalusia, Spain" style="text-decoration:underline" target="_blank">Motril</a>
</td>
<td></td>
<td valign="top"> <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0092?from=search" title="Click here to check Weather Forecast in Ayamonte, Andalusia, Spain" style="text-decoration:underline" target="_blank">Ayamonte</a>
<br>
 <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0090" title="Click here to check Weather Forecast in Aracena, Andalusia, Spain" style="text-decoration:underline" target="_blank">Aracena</a></td>
</tr>
<tr>
<td colspan="2"><br><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0017" title="Click here to check Weather Forecast in Cadiz Province, Andalusia, Spain" style="text-decoration:underline" target="_blank">CADIZ</a></td>
<td colspan="2"><br><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0045" title="Click here to check Weather Forecast in Jaen Province, Andalusia, Spain" style="text-decoration:underline" target="_blank">JAEN</a></td>
</tr>
<tr>
<td></td>
<td valign="top">
<a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0046" title="Click here to check Weather Forecast in Jerez de la Frontera, Andalusia, Spain" style="text-decoration:underline" target="_blank">Jerez de la Frontera</a> <br>
  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0088" title="Click here to check Weather Forecast in Algeciras, Andalusia, Spain" style="text-decoration:underline" target="_blank">Algeciras</a>
  <br>
  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0237?from=search" title="Click here to check Weather Forecast in Tarifa, Andalusia, Spain" style="text-decoration:underline" target="_blank">Tarifa</a> <br>
  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/GIXX0001?from=search" title="Click here to check Weather Forecast in Gibraltar, Andalusia, Spain" style="text-decoration:underline" target="_blank">Gibraltar</a>
</td>
<td></td>
<td valign="top">
  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0098" title="Click here to check Weather Forecast in Cazorla, Andalusia, Spain" style="text-decoration:underline" target="_blank">Cazorla</a>
</td>
</tr>
<tr>
<td colspan="4" align="center">
<br>
<span class="BlueText">
    <a href="LocationMapInlandTowns.aspx" title="Click here to see a Location Map" style="text-decoration:underline"> Click here to see a Location Map</a></span>
</td>
</tr>
</table>
  <hr />
  <p><strong><%=("Below is a list of our inland properties in Andalucia sorted by province and in alphabetical order")%>:</strong></p>
  <ucTownGuide:TownGuide id="TownGuide1" runat="server" />
  <div class="clearfloat"></div>
</div>
<div id="footer">    <ucFooter:Footer id="Footer1" runat="server" />
  
  <!-- end #footer --></div></div></div>
<!-- end #container --></div>
</form>
</body>
</html>
