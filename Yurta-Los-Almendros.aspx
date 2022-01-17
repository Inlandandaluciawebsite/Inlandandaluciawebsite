<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Yurta-Los-Almendros.aspx.vb" Inherits="bed_and_breakfast_ermita_nueva" %>

<asp:Content ID="Contenttp" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <link href='<%= ResolveUrl("~/owl-carousel/owl.carousel.css")%>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/owl-carousel/owl.theme.css")%>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/owl-carousel/owl.transitions.css")%>' rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main Content Area Start -->

    <!-- Left Portion Start -->
    <div class="col-md-8">
        <div class="row">
            <div class="col-md-12">
                <%--<img src="/images/photos/BandB/FULL INDIVIDUAL YURTA LOS ALMENDROS_Mesa de trabajo 1.png" alt="Featured 1" />--%>
                <img src="/images/photos/BandB/FULL INDIVIDUAL5.png" width="750" height="1500" alt="Featured 1" />
            </div>
        </div>
        <!-- View trip listing Start -->
        <%--          <div class="row">
            <div class="col-md-12">
              <div class="town-guide-hd">
                <h1>Yurta Los Almendros</h1>
                  <p>Finca Los Amendros, Calle Herradura, Humilladero, 29531 </p>
                  <p>Our Yurt offers spacious and very comfortable sleeping accommodation. </p>
                  <p>It is furnished with a double bed and two single beds (a third bed can be available if required). All bedding, duvets, pillows and towels are provided including Beach Towels for use by the Pool. </p>
                  <p>We have tried to make the yurt comfortable and welcoming and well equipped so that you can enjoy the tranquility and magic that sleeping in a round room can bring.   </p>
                  <p>We have provided wardrobe space, chest of drawers, bedside cabinets and a privacy screen. Elecricity is connected providing an overhead light, bedside lamps and a fan or two for those warm summer nights.  </p>
                  <p>The Yurt is fully insulated and waterproofed. There is central roof window (Corona) for ventilation (covered with insect screen!) which allows you to view the night sky from your bed. It is a truly magical space, particularly on a full moon!  </p>
                  <p>The site of the Yurt is surrounded by screening and planted with various flowers and herbs. </p>
                  <p>There is a gateway through to the Pool area where there is a Swimming Pool, Children's Paddling Pool (if required) and Pool Shelter for getting out of the hot Summer sun. </p>
              </div>
            </div>
          </div>--%>


        <!-- Detail Two Strat -->


        <%--        <div class="row">
            <div class="col-md-12">
                <div class="gallery-slider-bg">
                    <div id="demo1">
                        <div id="sync1" class="owl-carousel">


                            <div class="item">
                                <div class="slidertext">
                                    <h3></h3>
                                </div>
                                <img src="/images/photos/BandB/IMG_5641.JPG" alt="Featured 2" /></div>
                            <div class="item">
                                <div class="slidertext">
                                    <h3></h3>
                                </div>
                                <img src="/images/photos/BandB/IMG_5642.JPG" alt="Featured 3" /></div>
                            <div class="item">
                                <div class="slidertext">
                                    <h3></h3>
                                </div>
                                <img src="/images/photos/BandB/IMG_5643.JPG" alt="Featured 4" /></div>
                            <div class="item">
                                <div class="slidertext">
                                    <h3></h3>
                                </div>
                                <img src="/images/photos/BandB/IMG_5644.JPG" alt="Featured 5" /></div>

                        </div>

                    </div>
                </div>
            </div>
        </div>--%>





        <!-- Detail Two End -->

    </div>
    <!-- Left Portion End -->
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <%--     <link href='<%= ResolveUrl("~/js/bootstrap.min.js")%>' rel="stylesheet" />
      <link href='<%= ResolveUrl("~/assets/js/jquery-1.9.1.min.js")%>' rel="stylesheet" />
      <link href='<%= ResolveUrl("~/owl-carousel/owl.carousel.js")%>' rel="stylesheet" />--%>
    <script src='<%= ResolveUrl("~/js/bootstrap.min.js")%>'></script>
    <script src='<%= ResolveUrl("~/assets/js/jquery-1.9.1.min.js")%>'></script>
    <script src='<%= ResolveUrl("~/owl-carousel/owl.carousel.js")%>'></script>
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
                transitionStyle: "fade",
                autoHeight: true,
                autoWidth: true
            });

            sync2.owlCarousel({
                items: 6,
                itemsDesktop: [1199, 6],
                itemsDesktopSmall: [979, 6],
                itemsTablet: [768, 6],
                itemsMobile: [479, 4],
                pagination: false,
                responsiveRefreshRate: 100,
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
                    } else {
                        if (num - 1 === -1) {
                            num = 0;
                        }
                        sync2.trigger("owl.goTo", num);
                    }
                } else if (num === sync2visible[sync2visible.length - 1]) {
                    sync2.trigger("owl.goTo", sync2visible[1])
                } else if (num === sync2visible[0]) {
                    sync2.trigger("owl.goTo", num - 1)
                }

            }

        });
    </script>
    <script type="text/javascript">
        WebFontConfig = {
            google: { families: ['Dancing+Script::latin'] }
        };
        (function () {
            var wf = document.createElement('script');
            wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
                '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
            wf.type = 'text/javascript';
            wf.async = 'true';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(wf, s);
        })(); </script>

</asp:Content>

