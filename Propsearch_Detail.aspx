<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Propsearch_Detail.aspx.vb" Inherits="Propsearch_Detail" %>
 <asp:Content ID="Contenttp" runat="server" ContentPlaceHolderID="ContentPlaceHolder3" >
              <link href="owl-carousel/owl.carousel.css" rel="stylesheet" />
    <link href="owl-carousel/owl.theme.css" rel="stylesheet" />
     <link href="owl-carousel/owl.transitions.css" rel="stylesheet" />
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      
        <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4&sensor=false">
    </script>
    <script type="text/javascript">
      
        function initialize() {
            var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
            var mapOptions = {
                center: new google.maps.LatLng(markers[0].latitude, markers[0].longitude),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            
            var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
            var image = 'images/icons/map-pointer.png';
            var data = markers[0]

            //"<p><strong>" & szType.Trim & " (" & szReference.Trim & ")</strong></p>" & _
            //"<p><a href=""propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim & """><img src=""" & szImageURL.Trim & """ alt=""Prop img"" width=""150"" height=""100""/></a></p>"

            var myLatlng = new google.maps.LatLng(data.latitude, data.longitude);
        
            var marker = new google.maps.Marker
            (
                {
                    position: myLatlng,
                    map: map,
                    title: data.Reference,
                    icon: image
                }
            );
            }

            google.maps.event.addDomListener(window, 'load', initialize);    

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- Main Content Area Start --Detail page>

        <!-- Left Portion Start -->
        <div class="col-md-8" id="detaildiv" runat="server" > 
          <!-- Listing Head Start -->
          <div class="row">
            <div class="col-md-12"> 
              <!-- Detail Page Start -->
              <div class="detail-property-start"> 
                
                <!-- Listing Start -->
                <div class="row">
                  <div class="col-md-12">
                           <a class="a2a_dd" href="https://www.addtoany.com/share_save" style="display:none" id="fbshare" runat="server" >
            <img src="//static.addtoany.com/buttons/share_save_171_16.png" width="171" height="16" border="0" alt="Share" /></a>
            
                    <div class="details-listing" id="topmenu" runat="server" style="display:block ">
                   
        <script type="text/javascript" src="//static.addtoany.com/menu/page.js"></script>
                      <ul>
                        <li><%--<a href="#"></a>--%>
                            <asp:LinkButton ID="btnback"  runat="server"  OnClick="btnback_Click" >   <asp:Literal runat="server" ID="Literal14" Text=" <%$Resources:Resource,     Back%>"></asp:Literal></asp:LinkButton>
<%--                                                <asp:Button ID="btnback" runat="server" class="btn btn-default listing-bk fa fa-arrow-left"  Text="Back" OnClick="btnback_Click" />--%>
                        </li>
                        <li>

                            <a href="windowcard.aspx?propertyref=<%=Referencem %>"  >   <asp:Literal runat="server" ID="Literal9" Text=" <%$Resources:Resource,     PrintPreview%>"></asp:Literal></a></li>
                        <li><span id="Email" runat="server"></span></li>
                        <li> <span id="ContactUs" runat="server"></span></li>
                          
              
                      </ul>
                           <div class="watch-video"> <div id="vidio" runat="server" ></div>   </div>
                    </div>

                         <div id="notfound" runat="server" style="display:none">
            <div>
	
<p> <img src="images/icons/sorry-icon.png" alt="Sorry!" hspace="10" align="left">Sorry, the selected search did not yield any results<br>
Please <span id="NoResults1_TryAgain"><a href="propsearch.aspx" title="New search">try again</a></span> with different search criteria.</p>


</div>
        </div>
                
               
                  </div>
                </div>
                <!-- Listing End --> 
          
                
                <!-- property Details Start -->
                  <asp:Label ID="lblMapInformation" runat="server"  style="display:none"></asp:Label>
                  <asp:Repeater ID="rpdetail" runat="server" OnItemDataBound="rpdetail_ItemDataBound">
                      <ItemTemplate>
                               <asp:HiddenField ID="propnum" runat="server" Value='<%#Eval("Photos")%>' />
                             <asp:HiddenField ID="statusid" runat="server" Value='<%#Eval("status_id")%>' />
                <!-- Gallery Head Start -->
                <div class="row">
                  <div class="col-md-12">
                    <div class="gallery-head">
                      <div class="row">
                        <div class="col-md-8 col-sm-8">
                          <h3><%#Eval("type") %>  (<%#Eval("partner_reference") %>) /<span> <%#Eval("region") %></span> / <%#Eval("area")%> <%#IIf(Convert.ToString(Eval("subarea")) = "Not Specified", "","/" +Eval("subarea").ToString())%> </h3>
                            <h4><%--<%#Eval("subArea")%>--%>
                                

                             
                            </h4>
                         
                        </div>
                        <div class="col-md-4 col-sm-4">
                          <div class="rate-list">
                            <h3><del class="delete"> <%#IIf(Convert.ToString(Eval("FormatorignalPrice")) = "0 €", "", Eval("FormatorignalPrice").ToString())%> </del> &nbsp;<%#Eval("FormatPrice") %> </h3>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <!-- Gallery Head End --> 
                
                <!-- Slider Start -->
                <div class="row">
                  <div class="col-md-12">
                    <div class="gallery-slider-bg">
                      <div id="demo1">
                           <div id="sync1" class="owl-carousel">
                          <asp:Repeater ID="rpslider" runat="server">
                              <ItemTemplate>
                                 
                          <div class="item"><img src='<%#Eval("Name") %>' style="width:100%;"></div>
                        
                       
                              </ItemTemplate>
                          </asp:Repeater>
                                </div>
                            <div id="sync2" class="owl-carousel thumbss">
                            <asp:Repeater ID="rpslider2" runat="server">
                              <ItemTemplate>
                               
                      
                          <div class="item"><img src='<%#Eval("Name") %>' style=""></div>
                        
                              </ItemTemplate>
                          </asp:Repeater>
                                 </div>
            
                      </div>
                    </div>
                  </div>
                </div>
                <!-- Slider End --> 
                            <div class="property-details-single">
                  <div class="row">
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <p> <span>  <asp:Literal runat="server" ID="Literal14" Text=" <%$Resources:Resource,     Beds%>"></asp:Literal>:</span> <%#Eval("bedrooms") %></p>
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <p><span>  <asp:Literal runat="server" ID="Literal1" Text=" <%$Resources:Resource,     Baths%>"></asp:Literal>: </span> <%#Eval("bathrooms") %></p>
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <p><span>  <asp:Literal runat="server" ID="Literal2" Text=" <%$Resources:Resource,     Views%>"></asp:Literal>: </span> <%#Eval("views") %> </p>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <p><span>  <asp:Literal runat="server" ID="Literal3" Text=" <%$Resources:Resource,     Built%>"></asp:Literal>: </span> <%#Eval("sqm_built")%></p>
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <p><span>   <asp:Literal runat="server" ID="Literal4" Text=" <%$Resources:Resource,     Plot%>"></asp:Literal>: </span> <%#Eval("sqm_plot") %> </p>
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <p><span>  <asp:Literal runat="server" ID="Literal5" Text=" <%$Resources:Resource,     Location%>"></asp:Literal>: </span>  <%#Eval("location") %> </span>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                    <div class="divider"><img src="images/divider.png"></div>
                      <p><span>  <asp:Literal runat="server" ID="Literal6" Text=" <%$Resources:Resource,     Features%>"></asp:Literal>: </span>  <%#Eval("features") %></p>
                       <div class="divider"><img src="images/divider.png"></div>
                      <p><span>  <asp:Literal runat="server" ID="Literal7" Text=" <%$Resources:Resource,     Description%>"></asp:Literal>: </span>  <%#Eval("description") %></p>
                    </div>
                  </div>
                </div>
                                  <!-- property Details End --> 
                
                
                 <!-- Map Page Start -->
                 <div class="map-outer">
                 <div class="row">
                    <div class="col-md-12">
                    <h6>  <asp:Literal runat="server" ID="Literal8" Text=" <%$Resources:Resource,     LocationGoogeMap%>"></asp:Literal>:</h6>
                    <!-- Map Start -->
                    <div class="map-inner">
                      <div id="map_canvas" class="map-inr" style="width:100%;min-height:450px;"></div>
                    </div><!-- Map Start -->
                    
                    </div>
                 </div>
                 </div>
                 <!-- Map Page End -->
                
                  <!-- Gallery Head Start -->
                <div class="row">
                  <div class="col-md-12">
                    <div class="gallery-head">
                      <div class="row">
                        <div class="col-md-8 col-sm-8">
                          <h3><%#Eval("type") %>  (<%#Eval("partner_reference") %>) / <span> <%#Eval("region") %> </span> /  <%#Eval("area")%><%#IIf(Convert.ToString(Eval("subarea")) = "Not Specified", "","/" +Eval("subarea").ToString())%>  </h3>
<%--                            <h4><%#Eval("subArea")%></h4>--%>
                         
                        </div>
                        <div class="col-md-4 col-sm-4">
                          <div class="rate-list">
                            <h3><del class="delete">  <%#IIf(Convert.ToString(Eval("FormatorignalPrice")) = "0 €", "", Eval("FormatorignalPrice").ToString())%> </del> &nbsp;<%#Eval("FormatPrice") %> </h3>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <!-- Gallery Head End --> 
                      </ItemTemplate>
                  </asp:Repeater>
              
      
              </div>
              <!-- Detail Page End --> 
            </div>
          </div>
          <!-- Listing Head End --> 
        </div>
        <!-- Left Portion Start --End Detail Page> 
        
      
<!-- Main Content Area End --> 
    
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) --> 
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script> 
<!-- Include all compiled plugins (below), or include individual files as needed --> 
<script src="js/bootstrap.min.js"></script> 
<script src="assets/js/jquery-1.9.1.min.js"></script> 
<script src="owl-carousel/owl.carousel.js"></script>
<%--     <script src="owl-carousel-back/owl.carousel.js"></script>--%>
<script>
    $(document).ready(function () {

        var sync1 = $("#sync1");
        var sync2 = $("#sync2");

        sync1.owlCarousel({
            singleItem: true,
            navigation: true,
            pagination: false,
            autoPlay: 3000,
            afterAction: syncPosition,
            responsiveRefreshRate: 200,
            transitionStyle : "fade",
            autoHeight : true,
            autoWidth:true

        });

        sync2.owlCarousel({
            items: 6,
            transitionStyle : "fade",
            itemsDesktop: [1199, 6],
            itemsDesktopSmall: [979, 6],
            itemsTablet: [768, 6],
            itemsMobile: [479, 4],
            pagination: false,
            responsiveRefreshRate: 100,
            autoHeight : true,
            autoWidth:true,
            afterInit: function (el) {
                el.find(".owl-item").eq(0).addClass("synced");
            }
        });

        function syncPosition(el) {
            var current = this.currentItem;
            $("#sync2")
              .find(".owl-item")
              .removeClass("synced")
              .eq(current)
              .addClass("synced")
            if ($("#sync2").data("owlCarousel") !== undefined) {
                center(current)
            }
        }

        $("#sync2").on("click", ".owl-item", function (e) {
            e.preventDefault();
            var number = $(this).data("owlItem");
            sync1.trigger("owl.goTo", number);
        });

        function center(number) {
            var sync2visible = sync2.data("owlCarousel").owl.visibleItems;
            var num = number;
            var found = false;
            for (var i in sync2visible) {
                if (num === sync2visible[i]) {
                    var found = true;
                }
            }

            if (found === false) {
                if (num > sync2visible[sync2visible.length - 1]) {
                    sync2.trigger("owl.goTo", num - sync2visible.length + 2)
                   
                } 
                else {
                    if (num - 1 === -1) {
                        num = 0;
                       

                    }
                    sync2.trigger("owl.jumpTo", num);
               
                }
            } else if (num === sync2visible[sync2visible.length - 1]) {
                sync2.trigger("owl.goTo", sync2visible[1])
               // alert("2");
            } else if (num === sync2visible[0]) {
                sync2.trigger("owl.goTo", num - 1)
               // alert("3");
            }

        }

    });
</script> 
</asp:Content>

