<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BlogHeader.ascx.vb" Inherits="Controls_BlogHeader" %>

    <div class="featured-properties-outer">
  <div class="container">
    <div class="row">
      <div class="featured-properties">
        <div class="row">
          <div class="col-md-12">
     <h1>       <asp:Literal ID="Label1" Text="<%$Resources:Resource, FeaturedProperties %>" runat="server"></asp:Literal></h1>

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
                       
                  <a href="propsearch.aspx?propertyref=<%#Eval("property_ref") %>"><asp:Image ID="imgproperty" runat="server"  ImageUrl='<%#Eval("ImageUrl") %>' /></a>  </div>
                  </div>
                  <div class="col-md-5">
                    <div class="home-details">
                      <h2><%#Eval("type") %></h2>
                      <h3><%#Eval("region") %> </h3>
                      <h3><%#Eval("area") %></h3>
                      <span> <span class="prwidth"> <b><%#Eval("FormatPrice") %></b>  </span>    <strike>
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
               
                navigation : true,
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
