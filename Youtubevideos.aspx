<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Youtubevideos.aspx.vb" Inherits="Youtubevideos" %>
<%@ Register assembly="AjaxControlToolkit" 
namespace="AjaxControlToolkit" 
tagprefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
    <script>
        $(function () {
 })
    </script>
<%--    <script> (function () { var v = document.getElementsByClassName("youtube-player"); for (var n = 0; n < v.length; n++) { v[n].onclick = function () { var iframe = document.createElement("iframe"); iframe.setAttribute("src", "//www.youtube.com/embed/" + this.dataset.id + "?autoplay=1&autohide=2&border=0&wmode=opaque&enablejsapi=1&rel=" + this.dataset.related + "&controls=" + this.dataset.control + "&showinfo=" + this.dataset.info); iframe.setAttribute("frameborder", "0"); iframe.setAttribute("id", "youtube-iframe"); iframe.setAttribute("style", "width: 100%; height: 100%; position: absolute; top: 0; left: 0;"); if (this.dataset.fullscreen == 1) { iframe.setAttribute("allowfullscreen", ""); } while (this.firstChild) { this.removeChild(this.firstChild); } this.appendChild(iframe); }; } })(); </script>
--%>
</head>
<body>
 <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" updatemode="Conditional" >
            <ContentTemplate> 
                <div>
                    <!-- ALL CONTENT IS SHOWN FOR DEMO PURPOSE ONLY-->
                 
                  
                     <iframe   width="100%" height="500"  ></iframe>
                  <%--  <asp:Literal ID="Literal1" runat="server" ></asp:Literal>--%>
              
                    <asp:Label ID="urlembed" runat="server" style="display:none" ></asp:Label>
                </div>

             
            </ContentTemplate>
          </asp:UpdatePanel>
    
         
        </form>
</body>
 <script>
     $(function () {


         var url = $("#urlembed").text();
        // alert(url);
         $("iframe").attr("src", "http://www.youtube.com/embed/" + url);



     })
    </script>
</html>
