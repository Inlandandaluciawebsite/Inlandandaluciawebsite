<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--<link rel="stylesheet" href="owlcarousel/owl.carousel.min.css">
<link rel="stylesheet" href="owlcarousel/owl.theme.default.min.css">--%>
    <link href="dist/assets/owl.carousel.css" rel="stylesheet" />
    <link href="dist/assets/owl.carousel.min.css" rel="stylesheet" />
    <link href="dist/assets/owl.theme.default.min.css" rel="stylesheet" />
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <!-- title -->
    <section class="title">
      <div class="row">
        <div class="large-12 columns">
          <h1>Autoplay</h1>
        </div>
      </div>
    </section>

    <!--  Demos -->
   <div class="owl-carousel">
  <div> Your Content </div>
  <div> Your Content </div>
  <div> Your Content </div>
  <div> Your Content </div>
  <div> Your Content </div>
  <div> Your Content </div>
  <div> Your Content </div>
</div>

    <!-- footer -->
    <footer class="footer">
      <div class="row">
        <div class="large-12 columns">
          <h5>
            <a href="/docs/support-contact.html">Bartosz Wojciechowski</a> 
            <a id="custom-tweet-button" href="https://twitter.com/share?url=http://www.owlcarousel.owlgraphic.com&text=Owl Carousel - This is so awesome! " target="_blank"></a> 
          </h5>
        </div>
      </div>
        </footer>

       <%-- <script src="jquery.min.js"></script>--%>
        <script src="owl.carousel.2.0.0-beta.2.4/jquery.min.js"></script>
<%--<script src="owlcarousel/owl.carousel.min.js"></script>--%>
        <script src="dist/owl.carousel.min.js"></script>
        <script>
            $(document).ready(function () {
                $(".owl-carousel").owlCarousel();
            });
        </script>
    </div>
    </form>
</body>
</html>
