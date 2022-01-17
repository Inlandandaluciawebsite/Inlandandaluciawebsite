<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlPropertyDetail.ascx.vb" Inherits="Controls_WebUserControlPropertyDetail" %>
<head>
    <title>Property Details</title>
    <link rel="stylesheet" href="css/gallery.css" />
    <script type="text/javascript" src="js/compressed.js"></script>
    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCwJpxFElMKO5iffzrYp1EH9ohb5lvyogU&sensor=false">
    </script>
    <script type="text/javascript">

        function initialize() {
            var mapOptions = {
                center: new google.maps.LatLng(<%=Latitude%>, <%=Longitude%>),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            
            var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
            var image = 'images/icons/map-pointer.png';

            var marker = new google.maps.Marker
            (
                {
                    position: new google.maps.LatLng(<%=Latitude%>, <%=Longitude%>),
                    map: map,
                    title: '<%=Reference%>',
                    icon: image
                }
            );
            }

            google.maps.event.addDomListener(window, 'load', initialize);    

    </script>
</head>
<body>
    <div class="propertydetail">
        <!-- AddToAny BEGIN -->
        &nbsp; <a class="a2a_dd" href="https://www.addtoany.com/share_save">
            <img src="//static.addtoany.com/buttons/share_save_171_16.png" width="171" height="16" border="0" alt="Share" /></a>
        <script type="text/javascript" src="//static.addtoany.com/menu/page.js"></script>
        <!-- AddToAny END -->
        <div class="propertydetailbuttons">
            <a href="javascript:history.go(-1)">
                <img src="<%=GetBackImagePath%>" alt="Back to list" border="0" hspace="5" /></a>
            <span id="Video" runat="server"></span>
            <% If (Not String.IsNullOrEmpty(Request.QueryString("propertyref"))) Then%>
            <a href="/windowcard.aspx?propertyref=<%=Request.QueryString("propertyref").ToString()%>" target="_blank">
                <img src="<%=GetPrintImagePath%>" alt="Print" hspace="5" /></a>
            <%Else%>
            <a href="/windowcard.aspx?propertyid=<%=PropertyID%>" target="_blank">
                <img src="<%=GetPrintImagePath%>" alt="Print" hspace="5" /></a>
            <% End If%>

            <span id="Email" runat="server"></span>
            <span id="ContactUs" runat="server"></span>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="3" align="left" valign="top" bgcolor="#7F80B9">
                    <div class="propertydetailhead">
                        <span class="propertylistheadtype"><%= Type%>&nbsp;&nbsp;(<% = PartnerReference%>)</span>/<span class="propertylistheadtown"><% =Region %>&nbsp;/&nbsp;<strong><% =Area %></strong><% =SubArea%></span>
                        <span class="propertylistheadprice"><strike><font color="red"><% = OriginalPrice.Trim%></font></strike>&nbsp;&nbsp;&nbsp;<strong><% = Price.Trim%></strong></span>
                    </div>
                    <div class="clearfloat"></div>
                </td>
            </tr>

            <tr>
                <td colspan="3" align="left" valign="top" bgcolor="#FBFBFB" height="650">
                    <div class="main_gallery"><span id="Photos" runat="server"></span></div>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left" valign="top" bgcolor="#EBEBEB">
                    <div class="propertydetaildescription">
                        <% = ShortDescription%>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#DCDCDC">
                    <div class="propertydetailfeatures">
                        <strong><%=GetTranslation("Beds")%>:</strong> <%= Bedrooms%>
                    </div>
                    <div class="propertydetailfeatures"><strong><%=GetTranslation("Built")%>:</strong> <%= BuiltSize%> m<sup>2</sup></div>
                </td>
                <td align="left" valign="top" bgcolor="#DCDCDC">
                    <div class="propertydetailfeatures">
                        <strong><%=GetTranslation("Baths")%>: </strong><%= Bathrooms%>
                    </div>
                    <div class="propertydetailfeatures"><strong><%=GetTranslation("Plot")%>:</strong> <%= PlotSize%> m<sup>2</sup></div>
                </td>
                <td align="left" valign="top" bgcolor="#DCDCDC">
                    <div class="propertydetailfeatures">
                        <strong><%=GetTranslation("Views")%>:</strong> <%= Views%><br>
                    </div>
                    <div class="propertydetailfeatures"><strong><%=GetTranslation("Location")%>: </strong><%= Location%></div>
                </td>
            </tr>


            <tr>
                <td colspan="3" align="left" valign="top" bgcolor="#DCDCDC">
                    <div class="propertydetailfeatureswide"><strong><%=GetTranslation("Features")%>:</strong> <%=Features %> </div>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left" valign="top" bgcolor="#C9C9C9">
                    <div class="propertydetaildescription"><strong><%=GetTranslation("Description")%>:</strong> <%= Description%> </div>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left" valign="top" bgcolor="#BBBBBB">
                    <div class="propertydetailmap"><strong><%=GetTranslation("Location")%> Google Map:</strong><br />
                    </div>
                    <div id="map-canvas"></div>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left" valign="top" bgcolor="#7F80B9">
                    <div class="propertydetailhead">
                        <span class="propertylistheadtype"><%= Type%>&nbsp;&nbsp;(<% = PartnerReference%>)</span>/<span class="propertylistheadtown"><% =Region %>&nbsp;/&nbsp;<strong><% =Area %></strong><% =SubArea%></span>
                        <span class="propertylistheadprice"><strike><font color="red"><% = OriginalPrice.Trim%></font></strike>&nbsp;&nbsp;&nbsp;<strong><% = Price.Trim%></strong></span>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        $('slideshow').style.display = 'none';
        $('wrapper').style.display = 'block';
        var slideshow = new TINY.slideshow("slideshow");
        window.onload = function () {
            slideshow.auto = true;
            slideshow.speed = 5;
            slideshow.link = "linkhover";
            slideshow.info = "information";
            slideshow.thumbs = "slider";
            slideshow.left = "slideleft";
            slideshow.right = "slideright";
            slideshow.scrollSpeed = 4;
            slideshow.spacing = 5;
            slideshow.active = "#fff";
            slideshow.init("slideshow", "image", "imgprev", "imgnext", "imglink");
        }
    </script>
</body>

