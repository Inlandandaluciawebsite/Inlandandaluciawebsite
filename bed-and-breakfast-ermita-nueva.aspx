<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="bed-and-breakfast-ermita-nueva.aspx.vb" Inherits="bed_and_breakfast_ermita_nueva" %>
 <asp:Content ID="Contenttp" runat="server" ContentPlaceHolderID="ContentPlaceHolder3" >
             
       <link href='<%= ResolveUrl("~/owl-carousel/owl.carousel.css")%>' rel="stylesheet" />
     <link href='<%= ResolveUrl("~/owl-carousel/owl.theme.css")%>' rel="stylesheet" />
     <link href='<%= ResolveUrl("~/owl-carousel/owl.transitions.css")%>' rel="stylesheet" />

    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Main Content Area Start -->

        <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
          <div class="row">
            <div class="col-md-12">
              <div class="town-guide-hd">
                <h1>Casa Rosa, Guest House</h1>
                  <p>28 Los Rios, 14812 Almedinilla, Cordoba </p>
                  <h3>Description Casa Rosa</h3>
                  <p>A real taste of Spain in our rural Guesthouse with two en-suite bedrooms fitted in typical Andalucian style.</p>
                  <p>Attention to detail and cleanliness is foremost in our endevours to enhance our guests stay with us, Nothing is to much trouble for us and 50% of this years guests are return customers which speaks for itself, 5 minutes from Priego de Cordoba with its castle, bars,restaurants and a Flamenco show.</p>
                  <p>And 15 mins from Alcala La Real which has a fantastic castle La Mota and many museums, We are in in quiet hamlet with local bars and friendly Spanish neighbours. Lunch, dinner and picnics available, as well as local information and guides. </p>
                  <p>We will taxi you to Almedinilla which has a Roman villa and museum or Sileras (no charge) but for Priego and Alcala we do have a small charge. All food where possible is from local farms, we grow some vegetable's and have what must be the happiest chickens in Spain to provide your eggs. </p>
                  <p>Also check out our great review's on<a href="http://www.tripadvisor.co.uk/Hotel_Review-g1726220-d1925886-Reviews-Casa_Rosa_B_B_Spain-Almedinilla_Province_of_Cordoba_Andalucia.html" title="Casa Rosa Tripadvisor" target="_blank"> Trip advisor</a>,they are great. </p>
                  <h1>Bed and Breakfast Casa Rosa</h1>
              </div>
            </div>
          </div>
          
        
          <!-- Detail Two Strat -->
          
          
            <div class="row">
                  <div class="col-md-12">
                    <div class="gallery-slider-bg">
                      <div id="demo1">
                        <div id="sync1" class="owl-carousel">
                          <div class="item">
                             <div class="slidertext"><h3><%= ("Casa Rosa")%></h3></div>
                              <img src="/images/photos/BandB/casa-rosa.jpg" alt="Featured 1"  /></div>
                          <div class="item"> <div class="slidertext"><h3><%= ("Living Room")%></h3></div><img src="/images/photos/BandB/casa-rosa1.jpg" alt="Featured 2"  /></div>
                          <div class="item"> <div class="slidertext"><h3><%= ("Pool")%></h3></div><img src="/images/photos/BandB/casa-rosa2.jpg" alt="Featured 3"  /></div>
                          <div class="item"> <div class="slidertext"><h3><%= ("Sun Terrace")%></h3></div><img src="/images/photos/BandB/casa-rosa3.jpg" alt="Featured 4"  /></div>
                          <div class="item"> <div class="slidertext"><h3><%= ("Breakfast Room")%></h3></div><img src="/images/photos/BandB/casa-rosa4.jpg" alt="Featured 5"  /></div>
                          <div class="item"> <div class="slidertext"><h3><%= ("Double and twin rooms")%></h3></div><img src="/images/photos/BandB/casa-rosa5.jpg" alt="Featured 6"  /></div>
                          
                        </div>
                   
                      </div>
                    </div>
                  </div>
                </div>
          
         
          
          
          
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

