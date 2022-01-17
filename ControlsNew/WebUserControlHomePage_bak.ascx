<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlHomePage.ascx.vb" Inherits="WebUserControlHomePage" %>
 <!-- <head>-->
  
    <script type="text/javascript">

        function initialize() {
            var mapOptions = {
                center: new google.maps.LatLng(<%=Latitude%>, <%=Longitude%>),
                zoom: 8,
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

        function loadScript() {
          var script = document.createElement('script');
          script.type = 'text/javascript';
          script.src = 'https://maps.googleapis.com/maps/api/js?v=3.exp&callback=initialize&key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4&sensor=false';
          document.body.appendChild(script);
        }

        window.onload = loadScript;

    </script>

  <!--  </head>
  <body>-->
    <h1>Inland Andalucia <%= GetTranslation("Property Specialist")%> </h1>
    <p><%= GetTranslation("Our Company is the true Inland Andalucia Real estate specialist, and we have the largest bargain rural country selection available here for you in Andalucia, Southern Spain. Our")%> <a href="PropSearch.aspx" title="inland property portfolio"><%= GetTranslation("inland property portfolio")%></a> <%= GetTranslation("includes both large and small fincas, cortijos, village houses, cottages, farmhouses, villas and house plots, cheap old Spanish ruins where you can create your Spanish dream home.")%></p>  
    <p>&nbsp;</p>  
    <div id="map-canvas" class="propertydetailmap"></div>
       <p>&nbsp;</p>  
    <p><%= GetTranslation("Our service area is truly comprehensive and covers a large section of inland Andalucia. If you have a desire to purchase a rural, inland property in a true Spanish area and are interested in any of the villages in and around")%> Alcala la Real, Alora, Antequera, Archidona, Mollina, Fuente de Piedra, Campillos, Iznajar, Villanueva de Algaidas, Lucena, Loja, Osuna, Salinas, Alameda <%= GetTranslation("and all places in between, as well as the")%> Subbetica National Park <%= GetTranslation("covering the regions of")%> Antequera, C&aacute;diz, Cordoba, Granada, Jaen, M&aacute;laga <%= GetTranslation("and")%> Sevilla <%= GetTranslation("then")%> <a href="ContactOffices.aspx" title="come and see us"><%= GetTranslation("come and see us")%></a>!</p>
    <p><%= GetTranslation("Please also remember, we are adding inland properties on a daily basis to our web site, there is nearly always something new!")%></p>
  <!--</body>-->