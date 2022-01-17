<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Translation.aspx.vb" Inherits="ClassTranslation" %>
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
<title>Inland Andalucia | Thank you</title>
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
<form ID="EstadoSubscripcionNewsletter" RunAt="server">
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
  </div>
  <div id="mainContent">
   <%
       'Estado del envio
       If Request("envio") = 0 Then
           Response.Write("<p>&nbsp;</p>")
           Response.Write("<p>&nbsp;</p>")
           Response.Write("<table align='center' cellpadding='0' cellspacing='0' border='1' style='border:2px ridge #0E42A7; width:450px;' class='BlueText'>")
           Response.Write("<tr>")
           Response.Write("<td align='center' bgcolor='#0E42A7' style='border-bottom:2px ridge #0E42A7;'><font size='+2' color='#FFCC00'>Success</font></td>")
           Response.Write("</tr>")
           Response.Write("<tr>")
           Response.Write("<td align='left'><p>&nbsp;</p>")
           Response.Write("<p style='position:relative;left:10px;font-weight:bold;width:410px;'>" & GetTranslation("We are processing your request") & ". </p>")
           Response.Write("<p style='position:relative;left:10px;font-weight:bold;width:410px;'>" & GetTranslation("Thank you") & "</p>")
           Response.Write("<br>")
           Response.Write("<p style='position:relative;right:10px;font-weight:bold' align='right'><a href='/' target='_self' title='Click here to go Home'>" & GetTranslation("Click here to go Home") & "</a></p>")
           Response.Write("<br><br>")
           Response.Write("</td>")
           Response.Write("</tr>")
           Response.Write("</table>")
       Else
					 		
           Response.Write("<p>&nbsp;</p>")
           Response.Write("<p>&nbsp;</p>")
           Response.Write("<table align='center' cellpadding='0' cellspacing='0' border='1' style='border:2px ridge #0E42A7; width:450px;' class='BlueText'>")
           Response.Write("<tr>")
           Response.Write("<td align='center' bgcolor='#0E42A7' style='border-bottom:2px ridge #0E42A7;'><font color='#FFCC00' size='+2'>Error Ocurred</font></td>")
           Response.Write("</tr>")
           Response.Write("<tr>")
           Response.Write("<td align='left'><p>&nbsp;</p>")
           Response.Write("<p style='position:relative;left:10px;font-weight:bold;width:410px;'>" & GetTranslation("An error ocurred processing your request") & ".</p>")
           Response.Write("<p style='position:relative;left:10px;font-weight:bold;width:410px;'>" & GetTranslation("Try again and if the problem persist please try later" & ".</p>")
           Response.Write("<br>")
           Response.Write("<p style='position:relative;right:10px;font-weight:bold' align='right'><a href='/' target='_self' title='Click here to go Home'>Click here to go Home</a><br>")
           Response.Write("<a href='javascript:history.back();' target='_self' title='Click here to return to Contact Form'>" & GetTranslation("Click here to return to Register Form") & "</a>")
           Response.Write("</p>")
           Response.Write("<br>")
           Response.Write("</td>")
           Response.Write("</tr>")
           Response.Write("</table>")
       End If
						 
					%>
                    <p>&nbsp;</p>
                       <p>&nbsp;</p>
                          <p>&nbsp;</p>
                             <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                   <p>&nbsp;</p>
                                      <p>&nbsp;</p>
                                         <p>&nbsp;</p>
                                            <p>&nbsp;</p>
                                               <p>&nbsp;</p>
                                                  <p>&nbsp;</p>
                                                     <p>&nbsp;</p>
                                                        <p>&nbsp;</p>
                                                           <p>&nbsp;</p>
                                                              <p>&nbsp;</p>
                                                                 <p>&nbsp;</p>
                                                                    <p>&nbsp;</p>
                                                                       <p>&nbsp;</p>
		
    
    <!-- end #mainContent --></div>
	<!-- This clearing element should immediately follow the #mainContent div in order to force the #container div to contain all child floats --><br class="clearfloat" />
  <div id="footer">    <ucFooter:Footer id="Footer1" runat="server" />
  
  <!-- end #footer --></div></div></div>
<!-- end #container --></div>
</form>
</body>
</html>
