<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="property-search-andalucia.aspx.vb" Inherits="property_search_andalucia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4&sensor=false"></script>--%>
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA5h3ZfC3rhIC2ow1VlVC_J6sprxC1Rbns"></script>
    <script type="text/javascript">
        function initialize() {
            var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
            var mapOptions =
            {
                center: new google.maps.LatLng(markers[0].latitude, markers[0].longitude),
                zoom: 8,
                mapTypeId: google.maps.MapTypeId.ROADMAP
                //  marker:true
            };
            var infoWindow = new google.maps.InfoWindow();
            var map = new google.maps.Map(document.getElementById("googleMap"), mapOptions);
            for (i = 0; i < markers.length; i++) {
                var data = markers[i]
                var myLatlng = new google.maps.LatLng(data.latitude, data.longitude);
                var mapIconImage = ""
                if (data.IsFeatured == "1") {
                    mapIconImage = "/images/icons/map-pointer.png"
                }
                else {
                    mapIconImage = "/images/icons/map-pointer.png"
                }
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title,
                    icon: mapIconImage
                });
                (function (marker, i) {
                    // Attaching a click event to the current marker
                    google.maps.event.addListener(marker, "click", function (e) {

                        var price = markers[i].price;
                        var desc = "";
                        //if (markers[i].IsFeatured == "0" && markers[i].TotalProperties_By_Postcode!="1") {
                        desc = "<p><strong>Total of " + markers[i].TotalProperties_By_Area + " properties in this area";
                        if (markers[i].TotalFeaturedProperties_By_Area == "0")
                        {
                            desc = desc + "<br/>"
                        }
                        else
                        {
                            desc = desc + " including " + markers[i].TotalFeaturedProperties_By_Area + " Exclusives<br/>"
                        }
                        //desc = desc + ' Click below for property details</strong></p><br/><p><a href="propsearch.aspx?page=1&RegionId=0&AreaId=0&SubAreaId=0&typeId=0&minimumbedroom=0&minimumbathroom=0&minimumprice=0&maximumprice=0&PageName=PropSearch&postcode=' + markers[i].postcode_id + '" title="More information">Click Here</a></p>';
                        desc = desc + ' Click below for property details</strong></p><br/><p><a href="propsearch.aspx?page=1&RegionId=' + markers[i].Region_Id + '&AreaId=' + markers[i].Area_Id + '&SubAreaId=0&typeId=0&minimumbedroom=0&minimumbathroom=0&minimumprice=0&maximumprice=0&PageName=PropSearch" title="More information">Click Here</a></p>';
                        //}
                        //else {
                        //    desc = '<h2>' + markers[i].location.trim() + '</h2>' + '<p><strong>' + markers[i].type.trim() + '(' + markers[i].property_ref.trim() + ')' + '</strong></p>' +
                        //        '<p><a href="propsearch.aspx?propertyref=' + markers[i].property_ref.trim() + '"><img src="' + markers[i].url + '" alt="Prop img" width="150" height="100"/></a></p>';
                        //    if (price == 0) {
                        //        desc = desc + "<p><strong>" + markers[i].PriceHead.trim() + ":</strong>P.O.A.</p>"
                        //    }
                        //    else {

                        //        desc = desc + "<p><strong>" + markers[i].PriceHead.trim() + ":</strong>" + markers[i].formatprice.trim() + "</p>"
                        //    }
                        //    desc = desc + '<p><a href="propsearch.aspx?propertyref=' + markers[i].property_ref.trim() + '" title="More information">+info</a></p>'
                        //}
                        infoWindow.setContent(desc);
                        infoWindow.open(map, marker);
                    });
                })(marker, i);
            }
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-8">
        <div class="row">
            <div class="map-back">
                <div class="col-md-12">
                    <div class="town-guide-hd">
                        <h1>
                            <asp:Literal runat="server" ID="Literal11" Text=" <%$Resources:Resource,     SearchpropertiesinAndaluciabyGoogleMap%>"></asp:Literal>
                        </h1>
                    </div>
                </div>
                <%-- <div class="col-md-12">
                    <img src="Images/Icons/map-pointer.png" /> &nbsp; &nbsp; <b> Non Featured / Non Exclusive Properties</b>
                    <br />
                    <img src="Images/Icons/map-pointer-star.png" /> &nbsp; &nbsp;<b> Featured / Exclusive Properties</b>
                </div>--%>
                <div class="col-md-12">
                    <div class="map-wrapper">
                        <div id="googleMap" class="map-inr" style="width: 100%; min-height: 700px;"></div>
                    </div>
                </div>
                <%-- <div class="col-md-12">
                    <img src="Images/Icons/map-pointer.png" /> &nbsp; &nbsp; <b> Non Featured / Non Exclusive Properties</b>
                    <br />
                    <img src="Images/Icons/map-pointer-star.png" /> &nbsp; &nbsp;<b> Featured / Exclusive Properties</b>
                </div>--%>
            </div>
        </div>
    </div>
</asp:Content>


