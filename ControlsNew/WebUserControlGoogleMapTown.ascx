<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlGoogleMapTown.ascx.vb" Inherits="WebUserControlGoogleMapTown" %>
  <head>
    <link rel="stylesheet" href="../../css/lightbox.css" type="text/css" media="screen" />
    <script type="text/javascript"
      src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4&sensor=false">
    </script>
    <script type="text/javascript">

        function initialize() {
            var mapOptions = {
                center: new google.maps.LatLng(<%=Latitude%>, <%=Longitude%>),
                zoom: <%=Zoom%>,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
            
            var latitudes = '<%=Latitudes%>'.split('~');
            var longitudes = '<%=Longitudes%>'.split('~');
            var infoHTML = '<%=InfoWindowHTML%>'.split('~');
            
            var infowindow = new google.maps.InfoWindow();

            var marker, i;
            var image = 'images/icons/map-pointer.png';

            for (i = 0; i < <%=NumberOfResults%>; i++) 
            {  
                marker = new google.maps.Marker
                (
                    {
                        position: new google.maps.LatLng(latitudes[i], longitudes[i]),
                        map: map,
                        icon: image
                    }
                );

                google.maps.event.addListener(marker, 'click', (function(marker, i) {
                    return function() {
                        infowindow.setContent(infoHTML[i]);
                        infowindow.open(map, marker);
                    }
                })(marker, i));

            }
        }

        google.maps.event.addDomListener(window, 'load', initialize);    

    </script>
  </head>
  <body>
    <div id="map-canvas" class="propertydetailmap"></div>
  </body>