<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlHomePage.ascx.vb" Inherits="WebUserControlHomePage" %>
<!-- <head>-->
<style type="text/css">
    .gm-style-iw {
        top: 9px;
        position: absolute;
        left: 15px;
        width: 173px;
        text-align: center;
    }
</style>
<script type="text/javascript">

    function initialize() {
        var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
       
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].latitude, markers[0].longitude),
            zoom: 8,
            mapTypeId: google.maps.MapTypeId.ROADMAP
            //  marker:true
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]

            //"<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
            //"<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Prop img"" width=""150"" height=""100""/></a></p>"

            var myLatlng = new google.maps.LatLng(data.latitude, data.longitude);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title,
                icon: 'images/icons/map-pointer.png'
            });
            (function (marker, i) {
                // Attaching a click event to the current marker
                google.maps.event.addListener(marker, "click", function (e) {

                    var price = markers[i].price;
                    var desc = '<h2>' + markers[i].location.trim() + '</h2>' + '<p><strong>' + markers[i].type.trim() + '(' + markers[i].property_ref.trim() + ')' + '</strong></p>' +
                          '<p><a href="Propsearch_Detail.aspx?propertyref=' + markers[i].property_ref.trim() + '"><img src="' + markers[i].url + '" alt="Prop img" width="150" height="100"/></a></p>';
                    if (price == 0) {
                        desc = desc + "<p><strong>Price:</strong>P.O.A.</p>"
                    }
                    else {

                        desc = desc + "<p><strong>Price:</strong>" + markers[i].formatprice + "</p>"
                    }

                    desc = desc + '<p><a href="Propsearch_Detail.aspx?propertyref=' + markers[i].property_ref.trim() + '" title="More information">+info</a></p>'
                    //'<p><a href="http://www.inlandandalucia.com" title="InlandAndalucia.com">InlandAndalucia.com</a></p>'

                    infoWindow.setContent(desc);
                    infoWindow.open(map, marker);
                });
            })(marker, i);
        }
    }
    function loadScript() {
        //alert('loadscript');
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.src = 'https://maps.googleapis.com/maps/api/js?v=3.exp&callback=initialize&key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4&sensor=false';
        document.body.appendChild(script);
    }
    window.onload = loadScript;


</script>

<!--  </head>
  <body>-->
<%--    <h1><%= GetTranslation("The inland Andalucia Property Specialist")%> </h1>
    <p><%= GetTranslation("Our Company is the true Inland Andalucia Real estate specialist, and we have the largest bargain rural country selection available here for you in Andalucia, Southern Spain. Our")%> <a href="PropSearch.aspx" title="inland property portfolio"><%= GetTranslation("inland property portfolio")%></a> <%= GetTranslation("includes both large and small fincas, cortijos, village houses, cottages, farmhouses, villas and house plots, cheap old Spanish ruins where you can create your Spanish dream home.")%></p>  --%>
<h1>
    <asp:Literal ID="ltrlInnerTitle" runat="server"></asp:Literal></h1>
<p>
    <asp:Literal ID="ltrlInnerTopText" runat="server"></asp:Literal>
</p>
<p>&nbsp;</p>
<div id="map-canvas" class="propertydetailmap"></div>
<%--<div>
    <img src="../Images/Images/map-new.jpg" onmousemove="SetProgressPosition(event);"  />
    <div id="divRefresh" style="width: 180px; background-color: #7F80B9; border: 2px solid gray; cursor: pointer; color: white; padding: 3px; position: absolute; display: none;">Click 2 Refresh</div>
</div>--%>
<p>&nbsp;</p>
<p><%= GetTranslation("Our service area is truly comprehensive and covers a large section of inland Andalucia. If you have a desire to purchase a rural, inland property in a true Spanish area and are interested in any of the villages in and around")%> Alcala la Real, Alora, Antequera, Archidona, Mollina, Fuente de Piedra, Campillos, Iznajar, Villanueva de Algaidas, Lucena, Loja, Osuna, Salinas, Alameda <%= GetTranslation("and all places in between, as well as the")%> Subbetica National Park <%= GetTranslation("covering the regions of")%> Antequera, C&aacute;diz, Cordoba, Granada, Jaen, M&aacute;laga <%= GetTranslation("and")%> Sevilla <%= GetTranslation("then")%> <a href="ContactOffices.aspx" title="come and see us"><%= GetTranslation("come and see us")%></a>!</p>
<p><%= GetTranslation("Please also remember, we are adding inland properties on a daily basis to our web site, there is nearly always something new!")%></p>
<!--</body>-->
