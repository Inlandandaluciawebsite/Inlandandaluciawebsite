<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Contenttp" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <%--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4&sensor=false"></script>--%>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA5h3ZfC3rhIC2ow1VlVC_J6sprxC1Rbns"></script>
    <link href='<%= ResolveUrl("~/owl-carousel12/owl.carousel.css") %>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/owl-carousel12/owl.theme.css") %>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/owl-carousel12/owl.transitions.css") %>' rel="stylesheet" />
    <%--<link href="owl-carousel12/owl.theme.css" rel="stylesheet" />
    <link href="owl-carousel12/owl.transitions.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            var map = new google.maps.Map(document.getElementById("ContentPlaceHolder1_googleMap"), mapOptions);
            for (i = 0; i < markers.length; i++) {
                var data = markers[i]

                //"<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
                //"<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Prop img"" width=""150"" height=""100""/></a></p>"

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
                        if (markers[i].TotalFeaturedProperties_By_Area == "0") {
                            desc = desc + "<br/>"
                        }
                        else {
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
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Slider Start-->
    <!-- Slider End -->
    <!-- Left Portion Start -->
    <div class="col-md-8">
        <div class="row">
            <div class="map-back">
                <div class="col-md-12">
                    <h2>
                        <asp:Literal ID="lblpSpecialist" Text="<%$Resources:Resource, Specialist %>" runat="server"></asp:Literal>
                    </h2>
                    <p>
                        <asp:Literal ID="lblwelcome" Text="<%$Resources:Resource, welcome %>" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="col-md-12">
                    <div class="map-wrapper">
                        <asp:ImageButton ID="imgmap" runat="server" ImageUrl="~//images/map1.jpg" OnClick="imgmap_Click" Style="display: block" AlternateText="Images" />
                        <div id="googleMap" class="map-inr" style="width: 100%; min-height: 450px; display: none" runat="server"></div>
                        <p>&nbsp;</p>
                        <p>
                            <%--<asp:Literal ID="lblourservice" runat="server" Text="<%$Resources:Resource, OurService %>"></asp:Literal>--%>
                            Inland Andalucia since opened in 2001 has grown into the leading and most trusted Inland property agent.
                        </p>
                        <p>
                            <%--<asp:Literal ID="lblpleasealso" runat="server" Text="<%$Resources:Resource, pleasealso %>"></asp:Literal>--%>
                            Always remember, we will sell you the Inland LIFESTYLE whilst supporting you all the way to secure <a href="https://inlandandalucia.com/propsearch.aspx" target="_blank">your dream home</a>.
                        </p>
                        <p>
                            Our service is truly comprehensive and we have built a network of Inland Andalucia franchise partners  who operate <a href="https://www.inlandandalucia.com/ContactOffices.aspx" target="_blank">local offices</a> under the Inland Andalucia system of brand excellence. This allows you to have vast local knowledge of properties, facilities, events and provide an aftersales network that is second-to-none. All our properties are vetted to ensure legality and correct ownership before we promote that property.  The company strap line of “You´re in Safe Hands” has real meaning and forms the central part of our philosophy and the service we provide to our clients and partners.
                        </p>
                        <p>
                            With over 1,100 properties available on our website, you will also enjoy property video links to <a href="https://www.youtube.com/channel/UCeku6fMjkT8mmRmB0kAaALw" target="_blank">Youtube</a>, GPS coordinates by Google maps and our property Specialist chat room to also assist you.
                        </p>
                        <p>
                            Your are welcome to subscribe here to our <a href="https://www.inlandandalucia.com/InlandAndaluciaNewsletter.aspx" target="_blank">weekly newsletter</a> to keep up to date with latest bargains. When you <a href="https://www.youtube.com/channel/UCeku6fMjkT8mmRmB0kAaALw" target="_blank">subscribe</a> to our youtube channel  you will receive notice of each new property listing..
                        </p>
                        <p>
                            For more information we invite you to <a href="https://www.inlandandalucia.com/contactus.aspx" target="_blank">contact one of our property Specialist</a>. You can also follow us on social media, We have very active <a href="https://www.facebook.com/inlandandaluciahomes/" target="_blank">Facebook</a> and <a href="https://www.instagram.com/inland_andalucia/" target="_blank">Instagram</a> pages with many inspiring information.
                        </p>
                        <p>
                            Want to live and work in Andalucia. <a href="https://www.inlandandaluciafranchise.com/" target="_blank">Contact our Franchise</a> department for more details.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Left Portion Start -->


    <!-- Main Content Area End -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="featured-properties-outer">
        <div class="container">
            <div class="row">
                <div class="featured-properties">
                    <div class="row">
                        <div class="col-md-9">
                            <h1>
                                <asp:Literal ID="Label1" Text="<%$Resources:Resource, FeaturedProperties %>" runat="server"></asp:Literal>

                            </h1>
                        </div>
                        <div class="col-md-3" style="margin-top:15px;">
                            <asp:ImageButton ID="btnSubscribe" runat="server" ImageUrl="~/Images/Subscribe.png" PostBackUrl="https://www.inlandandalucia.com/InlandAndaluciaNewsletter.aspx" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="property-slider">
                            <div id="owl-demo">
                                <asp:Repeater ID="rpFeaturedProperty" runat="server">
                                    <ItemTemplate>
                                        <div class="item ">
                                            <div class="property-sing">
                                                <div class="col-md-7">
                                                    <div class="home-details img_border">

                                                        <a href="propsearch.aspx?propertyref=<%#Eval("property_ref") %>">
                                                            <asp:Image ID="imgproperty" runat="server" ImageUrl='<%#Eval("ImageUrl") %>' AlternateText="images" /></a>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="home-details">
                                                        <h2><%#Eval("type") %></h2>
                                                        <h3><%#Eval("region") %> </h3>
                                                        <h3><%#Eval("area") %></h3>
                                                        <span><span class="prwidth"><b><%#Eval("FormatPrice") %></b>  </span><strike>
                                     <%#IIf(Convert.ToString(Eval("FormatorignalPrice")) = "0 €", "", Eval("FormatorignalPrice").ToString())%>
                   </strike></span>
                                                        <div class="btn-info-out">
                                                            <a href="propsearch.aspx?propertyref=<%#Eval("property_ref") %>" class="btn btn-default more-info">Info</a>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <!-- Item End-->
                            </div>
                        </div>
                    </div>
                    <!-- Row End-->

                </div>
            </div>
        </div>
    </div>
    <script src='<%= ResolveUrl("~/assets/js/jquery-1.9.1.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/owl-carousel12/owl.carousel.js") %>'></script>
    <%--    <script src="assets/js/jquery-1.9.1.min.js"></script>
    <script src="owl-carousel12/owl.carousel.js"></script>--%>
    <style>
        #owl-demo .item {
            display: block;
            padding: 10px 0px 0;
            margin: 5px;
            color: #FFF;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            text-align: center;
        }

        .owl-theme .owl-controls .owl-buttons div {
            padding: 5px 9px;
        }

        .owl-theme .owl-buttons i {
            margin-top: 2px;
        }

        /*To move navigation buttons outside use these settings:*/

        .owl-theme .owl-controls .owl-buttons div {
            position: absolute;
        }

        .owl-theme .owl-controls .owl-buttons .owl-prev {
            top: -13px;
            background: url(/images/arrow-lft.png) no-repeat center 10%;
            height: 30px;
            width: 20px;
            font-size: 0px;
            right: 52px;
        }

        .owl-theme .owl-controls .owl-buttons .owl-next {
            right: 23px;
            top: -13px;
            background: url(/images/arrow-rt.png) no-repeat center 10%;
            height: 30px;
            width: 20px;
            font-size: 0px;
        }
    </style>
    <script>
        $(document).ready(function () {
            var owl = $('#owl-demo');
            //$("#owl-demo").owlCarousel({
            //   // autoPlay: 3000,
            //    //navigation: true,
            //    //items: 3,
            //    //transitionStyle: "fade"
            //    items: 3,
            //    loop: true,
            //    margin: 10,
            //    autoplay: true,
            //    autoplayTimeout: 1000,
            //    autoplayHoverPause: true
            //});
            owl.owlCarousel({

                navigation: true,
                autoPlay: 3000,
                items: 3,
                transitionStyle: "fade",
                autoPlay: 3000,
                loop: true,

                autoplay: true,
                autoplayTimeout: 5000,
                autoplayHoverPause: true,
                responsive: {
                    0: {
                        items: 1

                    },
                    600: {
                        items: 2

                    },
                    800: {
                        items: 3

                    },
                    1000: {
                        items: 3

                    }
                }
            });
            $('.play').on('click', function () {
                owl.trigger('autoplay.play.owl', [1000])
            })
            $('.stop').on('click', function () {
                owl.trigger('autoplay.stop.owl')
            })
        });
    </script>
</asp:Content>

