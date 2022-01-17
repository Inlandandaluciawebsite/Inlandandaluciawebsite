<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlHeaderbak.ascx.vb" Inherits="Controls_WebUserControlHeader" %>
<%@ Register Src="WebUserControlWeather.ascx" TagName="Weather" TagPrefix="ucWeather" %>



<div class="topright">
    <a href="https://www.facebook.com/inlandandaluciahomes" target="_blank" title="facebook">
        <img src="../images/icons/facebook.png" alt="Facebook inlandandalucia" width="25" height="25" /></a> <a href="https://plus.google.com/+Inlandandalucia/" rel="publisher" target="_blank" style="text-decoration: none;" title="Google+">
            <img src="../images/icons/google.png" alt="Google +" width="25" height="25" /></a> <a href="http://inland-andalucia.blogspot.com" target="_blank" title="blog">
                <img src="../images/icons/blogger.png" alt="Read articles in Blogger" width="26" height="26" /></a> <a href="https://twitter.com/inlandandalusia" target="_blank" title="twitter">
                    <img src="../images/icons/twitter.png" alt="Twitter Inland Andalusia" width="26" height="26" /></a><!--<div class="topbluebox" >
    <%= GetTranslation("Over 500 Properties for Viewing")%> </div> -->
    <ucWeather:Weather ID="Weather1" runat="server" />
    <div class="clearfloat"></div>
    <div>
        Inland Andalucia   <%= GetTranslation("Head Office in Spain")%> <strong>+34 952 741 525</strong> <%= GetTranslation("FREE")%>:&nbsp;<a href="skype:inlandandalucia.com?call"><img src="images/buttons/skype_button.png" alt="Skype Me!" width="50" height="23" /></a><br />
        <div class="adress">Calle de la Villa 14, 29532 Mollina <%= GetTranslation("for")%>  M&aacute;laga <%= GetTranslation("and")%> Seville</div>
    </div>
    <br />
    C&oacute;rdoba, Granada <%= GetTranslation("and")%> Ja&eacute;n <%= GetTranslation("Regions")%> <strong>+34 953 587 040</strong> <%= GetTranslation("FREE")%>: <a href="skype:casa-andaluza-real-estate?call">
        <img src="images/buttons/skype_button.png" alt="Skype Me!" width="50" height="23" /></a><br />
    Calle Abad Moya 4 bajo, 23680 Alcal&aacute; la Real, Ja&eacute;n<br />
    <strong><%= GetTranslation("Email")%>:</strong> <a href="mailto:info@inlandandalucia.com"><strong>info@inlandandalucia.com</strong></a><br />

    <div class="lang">
    <asp:ImageButton ID="ImageButtonEnglish" runat="server" ImageUrl="../images/buttons/british_flag.jpg" alt="English" ToolTip="English" />&nbsp;
       <asp:ImageButton ID="ImageButtonSpanish" runat="server" ImageUrl="../images/buttons/spanish_flag.jpg" alt="Español" ToolTip="Español" />&nbsp;
       <asp:ImageButton ID="ImageButtonFrench" runat="server" ImageUrl="../images/buttons/french_flag.jpg" alt="Français" ToolTip="Français" />&nbsp;
       <asp:ImageButton ID="ImageButtonGerman" runat="server" ImageUrl="../images/buttons/german_flag.jpg" alt="Deutsch" ToolTip="Deutsch" />&nbsp;
       <asp:ImageButton ID="ImageButtonDutch" runat="server" ImageUrl="../images/buttons/dutch_flag.jpg" alt="Nederlands" ToolTip="Nederlands" />&nbsp;
    </div>
</div>


