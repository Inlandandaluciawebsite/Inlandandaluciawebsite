<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlLocationMap.ascx.vb" Inherits="Controls_WebUserControlLocationMap" %>
  
 <script type="text/javascript">
        function initialize() {
            debugger;
            var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
            var mapOptions = {
                center: new google.maps.LatLng(markers[0].latitude, markers[0].longitude),
                zoom: <%=Zoom%>,
                mapTypeId: google.maps.MapTypeId.ROADMAP
                //  marker:true
            };
            var infoWindow = new google.maps.InfoWindow();
            var map = new google.maps.Map(document.getElementById("googleMap"), mapOptions);
            for (i = 0; i < markers.length; i++) {
                var data = markers[i]

                //"<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
                //"<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Prop img"" width=""150"" height=""100""/></a></p>"

                var myLatlng = new google.maps.LatLng(data.latitude, data.longitude);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title,
                    icon: '/images/icons/map-pointer.png'
                });
                (function (marker, i) {
                    // Attaching a click event to the current marker
                    google.maps.event.addListener(marker, "click", function (e) {


                        var price = markers[i].price;

                        var desc = '<h2>' + markers[i].location.trim() + '</h2>' + '<p><strong>' + markers[i].type.trim() + '(' + markers[i].property_ref.trim() + ')' + '</strong></p>' +
                              '<p><a href="propsearch.aspx?propertyref=' + markers[i].property_ref.trim() + '"><img src="' + markers[i].url + '" alt="Prop img" width="150" height="100"/></a></p>';
                        if (price == 0) {
                            desc = desc + "<p><strong>"+markers[i].priceHead.trim()+":</strong>P.O.A.</p>"
                        }
                        else {

                            desc = desc + "<p><strong>"+ markers[i].priceHead.trim()+":</strong>" + markers[i].formatprice.trim() + "</p>"
                        }

                        desc = desc + '<p><a href="propsearch.aspx?propertyref=' + markers[i].property_ref.trim() + '" title="More information">+info</a></p>' +
                        '<p><a href="http://www.inlandandalucia.com" title="InlandAndalucia.com">InlandAndalucia.com</a></p>'

                        infoWindow.setContent(desc);
                        infoWindow.open(map, marker);
                    });
                })(marker, i);
            }
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>

 <div id="googleMap" class="map-inr" style="width:100%;min-height:450px;"> </div>