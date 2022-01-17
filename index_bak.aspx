<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>
<%@ Register Src="Controls/WebUserControlHeader.ascx" TagName="Header" TagPrefix="ucHeader" %>
<%@ Register Src="Controls/WebUserControlFooter.ascx" TagName="Footer" TagPrefix="ucFooter" %>
<%@ Register Src="Controls/WebUserControlNavigation.ascx" TagName="Navigation" TagPrefix="ucNavigation" %>
<%@ Register Src="Controls/WebUserControlFeaturedProperties.ascx" TagName="FeaturedProperties" TagPrefix="ucFeaturedProperties" %>
<%@ Register src="Controls/WebUserControlSearchForm.ascx" tagname="SearchForm" tagprefix="ucSearchForm" %>
<%@ Register src="Controls/WebUserControlTop30.ascx" tagname="Top30" tagprefix="ucTop30" %>
<%@ Register src="Controls/WebUserControlViewingTrip.ascx" tagname="ViewingTrip" tagprefix="ucViewingTrip" %>
<%@ Register src="Controls/WebUserControlTestimonial.ascx" tagname="Testimonial" tagprefix="ucTestimonial" %>
<%@ Register src="Controls/WebUserControlHomepage.ascx" tagname="Homepage" tagprefix="ucHomepage" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Inland Andalucia | Properties for sale in the Inlands of Andalucia</title>
    <meta name="description" content="Inland Andalucia Ltd offers a wide range of properties, apartments, villas, town houses, commercial properties and cortijos located in the Inlands of Andalucia. Undescovered places to live or for holidays. Bargain properties for sale in Antequera, Granada, Jaen and Seville" />

    <meta name="keywords" content="Inland andalucia, bargain, properties, villas, town houses, cortijos, andalusia, inland" />
    <%  Response.WriteFile("include/googlecode.aspx")%>
    <link rel="Shortcut Icon" href="/Images/Icons/favicon.ico" type="image/x-icon"/>
<link href="css/style.css" rel="stylesheet" type="text/css" />
  <link rel="stylesheet" href="../css/lightbox.css" type="text/css" media="screen" />
  <link rel="stylesheet" href="http://weatherandtime.net/new_wid/w_2/style.css" type="text/css" media="screen" />
    <script type="text/javascript">
        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>

</head>
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

<body class="twoColFixRtHdr">
<form ID="Index" RunAt="server" action="#">
<asp:ScriptManager id="ScriptManagerMain" EnablePartialRendering="true" runat="server">
</asp:ScriptManager>
<div id="container">
 <div id="header"><ucHeader:Header id="Header1" runat="server" />
  <div class="logo"> <a href="http://www.inlandandalucia.com"><img src="images/main/inlandandalucia.png" alt="Inland Andalucia Bargain Properties" width="354" height="170" /></a></div>
 </div>
  <div class="clearfloat"></div>
   <div class="topnavwrap"><ucNavigation:Navigation id="Navigation1" runat="server" />
      </div>
<div class="clearfloat"></div>
  <div class="wrap"> <div class="center"><div class="space"></div><ucFeaturedProperties:FeaturedProperties id="FeaturedProperties1" runat="server" /><div id="sidebar1">
    <asp:UpdatePanel ID="UpdatePanelSearchForm" runat="server" UpdateMode="Conditional">
        <ContentTemplate>            
            <ucSearchForm:SearchForm id="WebUserControlSearchForm1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
	<ucTop30:Top30 id="Top301" runat="server" />
    <ucViewingTrip:ViewingTrip id="ViewingTrip1" runat="server" />
    <ucTestimonial:Testimonial id="Testimonial1" runat="server" />
    <%	  
		Response.WriteFile("include/advert.aspx")
    %>    
  </div>
  <div id="mainContent">
    <asp:UpdatePanel ID="UpdatePanelMainForm" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <ucHomepage:Homepage id="Homepage1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel> 
    
    <!-- end #mainContent --></div>
	<!-- This clearing element should immediately follow the #mainContent div in order to force the #container div to contain all child floats --><br class="clearfloat" />
   <div id="footer">    <ucFooter:Footer id="Footer1" runat="server" />
 
  <!-- end #footer --></div></div></div>
<!-- end #container --></div>
</form>
</body>
</html>
