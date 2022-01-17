<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlQuickSearch.ascx.vb" Inherits="Controls_WebUserControlQuickSearch" %>

<script type="text/javascript">
    function doClick(buttonName, e) {
        //the purpose of this function is to allow the enter key to 
        //point to the correct button to click.
        var key;

        if (window.event)
            key = window.event.keyCode;     //IE
        else
            key = e.which;     //firefox

        if (key == 13) {
            //Get the button the user wants to have clicked
            var btn = document.getElementById(buttonName);
            if (btn != null) { //If we find the button click it

                btn.click();
                event.keyCode = 0
            }
        }
    }
    $(function () {

        $(".Collaspseblog").click(function () {

            $(this).toggleClass("activeblog");

        })
    })
</script>
<div class="col-md-4" style="display: block" runat="server" id="cuser">
    <div class="row">
        <div class="related-links" id="buyer" runat="server" style="display: none">
            <h3>
                <asp:Literal ID="Literal3" Text="<%$Resources:Resource, BuyerRelatedLink  %>" runat="server"></asp:Literal></h3>
            <ul>
                <li>»&nbsp;<a href="BuyersGuide.aspx" title="Buying a Property"><asp:Literal ID="Literal4" Text="<%$Resources:Resource, BuyerBuyingProperty  %>" runat="server"></asp:Literal></a></li>
                <li>»&nbsp;<a href="BuyingProcess.aspx" title="Buying Process"><asp:Literal ID="Literal5" Text="<%$Resources:Resource, BuyerBuyingProcess  %>" runat="server"></asp:Literal></a></li>
                <li>»&nbsp;<a href="PropertyTaxes.aspx" title="Property Taxes"><asp:Literal ID="Literal6" Text="<%$Resources:Resource, BuyerPropertyTaxes  %>" runat="server"></asp:Literal></a></li>
                <li>»&nbsp;<a href="BuyersGuideFAQS.aspx" title="FAQS "><asp:Literal ID="Literal7" Text="<%$Resources:Resource, BuyerFaq %>" runat="server"></asp:Literal></a></li>
                <li>»&nbsp;<a href="BuyersGuideUnpaidTaxes.aspx" title="Unpaid Taxes "><asp:Literal ID="Literal8" Text="<%$Resources:Resource, BuyerUnpaidTaxes  %>" runat="server"></asp:Literal></a></li>
                <li>»&nbsp;<a href="BuyersGuideMortgage.aspx" title="Mortgage"><asp:Literal ID="Literal9" Text="<%$Resources:Resource, BuyerMortage  %>" runat="server"></asp:Literal></a>     </li>
            </ul>
        </div>
        <!-- Related Links End -->
        <!-- Quick links Start -->
        <div class="quick-links" id="quicksearchform" runat="server">
            <div class="col-md-12">
                <h2>
                    <asp:Literal ID="lblpSpecialist" Text="<%$Resources:Resource, QuickSearch  %>" runat="server"></asp:Literal></h2>
            </div>
            <div class="col-md-12">
                <div>
                    <div class="form-group">
                        <asp:DropDownList ID="DropDownListRegion" runat="server" class="form-control-inland"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="DropDownListPriceTo" runat="server"
                            class="form-control-inland">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="DropDownListType" runat="server" class="form-control-inland"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList
                            ID="DropDownListBedrooms" runat="server" class="form-control-inland">
                            <asp:ListItem Text=" <%$Resources:Resource,   MinBed%>" Value="0"></asp:ListItem>
                            <asp:ListItem Text=" <%$Resources:Resource,   Any%>" Value="0"></asp:ListItem>
                            <asp:ListItem Text=" <%$Resources:Resource,   OneorMore%>" Value="1"></asp:ListItem>
                            <asp:ListItem Text=" <%$Resources:Resource,   TwoorMore%>" Value="2"></asp:ListItem>
                            <asp:ListItem Text=" <%$Resources:Resource,   ThreeorMore%>" Value="3"></asp:ListItem>
                            <asp:ListItem Text=" <%$Resources:Resource,   FourorMore%>" Value="4"></asp:ListItem>
                            <asp:ListItem Text=" <%$Resources:Resource,   FiveorMore%>" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="btn-sun-bg">
                    <%-- <button type="submit" class="btn btn-default but-sub">Submit</button>--%>
                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" class="btn btn-default but-sub" Text=" <%$Resources:Resource,    btnSearch%>" />
                </div>
                <asp:Panel ID="pTne" runat="server" DefaultButton="btnsubmitref">
                    <div class="search-by-reference">
                        <h2>
                            <asp:Literal ID="Label1" Text="<%$Resources:Resource, QuickSearch  %>" runat="server"></asp:Literal></h2>
                        <div class="form-group">
                            <asp:TextBox ID="txtrefnumb" runat="server" placeholder="By Property Reference" CssClass="form-control" Style="text-transform: uppercase"></asp:TextBox>

                        </div>
                        <div class="btn-sun-bg">
                            <%--   <button type="submit" class="btn btn-default but-sub">Submit</button>--%>
                            <asp:Button ID="btnsubmitref" runat="server" OnClick="btnsubmitref_Click" class="btn btn-default but-sub" Text=" <%$Resources:Resource,    btnSearch%>" />

                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <!-- Quick links End -->

        <!-- Top 50 Start -->
        <div class="top-fifty-outer" id="top50" runat="server">
            <a href="Top50Properties.aspx" target="_blank">
                <asp:Literal ID="Literal1" Text="<%$Resources:Resource, Top50Image  %>" runat="server"></asp:Literal>
            </a>
        </div>
        <!-- Top 50 End -->
        <%-- top 30 --%>
        <div class="top-fifty-outer" id="top30" runat="server" style="display: none">
            <a href="Top30Properties.aspx" target="_blank">
                <img src="/images/buttons/TOP30-button.png" alt="Top 30">
            </a>
        </div>

        <%-- top 30 --%>

                <!-- Top 50 Start -->
        <div class="top-fifty-outer" id="sellwithus" runat="server" style="background:#3c2d8c;">
            <a href="/SellWithUs.aspx" target="_blank">
                <asp:Literal ID="Literal10" Text="<%$Resources:Resource, SellWithUs  %>" runat="server"></asp:Literal>
            </a>
        </div>
        <!-- Top 50 End -->
        <!-- Franchise Opportunities -->
        <div class="top-fifty-outer" id="Div1" runat="server" style="background:#fed103;">
            <a href="/Franchise.aspx" target="_blank">
                <%--<asp:Literal ID="Literal11" Text="<%$Resources:Resource, FranchiseOpportunities  %>" runat="server"></asp:Literal>--%>
                <img src="/Images/franchiseopportunities.jpg" />
            </a>
        </div>
        <!-- Top 50 End -->

        <!-- Black Friday Start -->
<%--        <div class="click-here-outer">
            <a href="Videos/BLACKFRIDAY.mp4" target="_blank">
                <img src="images/BlackFriday.JPG" width="385" alt="Black Friday"></a>
        </div>--%>
        <!-- Black Friday End -->

        <!-- Click Here Start -->
        <div class="click-here-outer">
            <a href="andalucia-property-viewing-trip.aspx">
                <asp:Literal ID="Literal2" Text="<%$Resources:Resource, ViewingImage  %>" runat="server"></asp:Literal></a>
        </div>
        <!-- Click Here End -->

        <!-- Click Here Start -->
        <div class="safe-hand-outer">
            <h3>You’ re in Safe Hands</h3>
            <a href="propertytestimonials.aspx">»<asp:Literal ID="Label2" Text="<%$Resources:Resource, ReadwhatourVendorsandClientssay  %>" runat="server"></asp:Literal></a>
        </div>
        <!-- Click Here End -->
        
        <!-- Click Here Start -->
        <div class="safe-hand-outer" style="background-color:white;">
            <%--<asp:ImageButton ID="imgbtnDownloadCalander" runat="server" PostBackUrl="https://dev.inlandandalucia.com/PDF/My_IA_Calendar.PDF" Width="386" ImageUrl="~/Images/downloadcalander.jpg" />--%>
            <a href="https://dev.inlandandalucia.com/PDF/My_IA_Calendar.PDF" target="_blank"><img src="https://dev.inlandandalucia.com/Images/downloadcalander.jpg" style="width:386px;" /></a>
        </div>
        <!-- Click Here End -->

        <!-- Complaint Start -->
        <div class="complaint-start " id="comlait" runat="server" style="display: none">
            <div class="col-md-8 col-sm-8 col-xs-7">
                <a href="pdf/Comply218.pdf" target="_blank">
                    <img src="/images/decreto-218.jpg" alt=""></a>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-5">
                <img src="/images/aplaceinthesun.jpg" alt="">
            </div>
        </div>
        <!-- Complaint End -->
        <div class="find-us-map" id="fbinfo" runat="server" style="display: block">
            <div class="col-sm-12">
                <h3>
                    <asp:Literal ID="Label4" Text="<%$Resources:Resource, Findallourpropertiesusing   %>" runat="server"></asp:Literal><br />
                    <strong>
                        <asp:Literal ID="Label5" Text="<%$Resources:Resource, GoogleMaps   %>" runat="server"></asp:Literal></strong></h3>
                <div class="map-find">
                    <a href="property-search-andalucia.aspx" target="_blank">
                        <img src="/images/map.jpg" alt="map"></a>
                </div>
            </div>
        </div>

        <!--Find Us Using Google Map End -->

        <!-- facebook Wideget Start -->
        <div class="fb-outer" id="fbiframe" runat="server" style="display: block">
            <div class="fb-like-box fb_iframe_widget" data-href="https://www.facebook.com/inlandandaluciahomes" data-height="490" data-colorscheme="light" data-show-faces="false" data-header="true" data-stream="true" data-show-border="true">
                <span style="vertical-align: bottom; height: 490px;">
                    <iframe name="f28c7a3d8" width="98%" height="490px" title="fb:like_box Facebook Social Plugin" src="https://www.facebook.com/v2.0/plugins/like_box.php?app_id=&amp;channel=http%3A%2F%2Fstatic.ak.facebook.com%2Fconnect%2Fxd_arbiter%2FNM7BtzAR8RM.js%3Fversion%3D41%23cb%3Df19f6433d%26domain%3Dwww.inlandandalucia.com%26origin%3Dhttp%253A%252F%252Fwww.inlandandalucia.com%252Ff71cec64%26relation%3Dparent.parent&amp;color_scheme=light&amp;container_width=300&amp;header=true&amp;height=520&amp;href=https%3A%2F%2Fwww.facebook.com%2Finlandandaluciahomes&amp;locale=en_US&amp;sdk=joey&amp;show_border=true&amp;show_faces=false&amp;stream=true&amp;width=295" style="border: none; visibility: visible; height: 490px;" class=""></iframe>
                </span>
            </div>
        </div>
        <!-- Face Book Widdget End -->





    </div>



</div>
<div class="col-md-4" style="display: none" runat="server" id="blogright">

    <div class="gray-bg-inner">

        <!-- Address inner S-->
        <div class="outer-border our-address-nw mrd-bot10">
            <h3 class="blog-sub-hd m0">Properties in inland Andalucia </h3>
            <p>Inland Andalucia Ltd</p>
            <p>T: (+34) 952.741.525</p>
            <p>E: <a href="#">info@inlandandalucia.com</a></p>
            <p class="mtop20">Visit our offices in:</p>
            <p>Mollina (Malaga) and Alcala la Real (Jaén)</p>
            <p>www.inlandandalucia.com</p>
        </div>
        <!-- Address border inner S-->

        <!-- Address inner S-->
        <div class="outer-border mrd-bot10">

            <!-- Blog Repeater S -->
            <div class="top-10-posts">
                <h3 class="blog-sub-hd m0">Top 10 Most Popular </h3>

                <asp:Repeater ID="rpFeaturedProperty" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 p0">
                            <div class="popular-post-img">
                                <img src="<%#Eval("BlogImage").ToString() %>">
                            </div>
                        </div>
                        <div class="col-md-8 p0">
                            <h4><a href="/Blog/<%#(Eval("TitleNew").ToString()) %>"><%#Eval("Title").ToString() %></a></h4>
                            <%#(Server.HtmlDecode(Eval("Blogdesc").ToString())) %>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>


        </div>
        <!-- Address border inner S-->

        <!-- Follow by Email Start -->
        <div class="outer-border mrd-bot10">
            <h3 class="blog-sub-hd m0">Follow by Email</h3>
            <div class="input-group">
                <input type="text" class="form-control" placeholder="Email Address">
                <span class="input-group-btn">
                    <button class="btn btn-default btn-yellow " type="button">Submit</button>
                </span>
            </div>
        </div>
        <!-- Follow by Email End -->

        <!-- Blog Archive Start -->
        <div class="outer-border mrd-bot10">
            <h3 class="blog-sub-hd m0">Blog Archive</h3>

            <div id="blogarchive" runat="server">
            </div>


            <%--     <ul class="blog-archive-list">
                    <li><a href="#demo" data-toggle="collapse">2014</a>
                      <div id="demo" class="collapse"> 
                        	
                         <a href="#demo1a" data-toggle="collapse">December</a>
                        <div id="demo1a" class="collapse our-cust-callps">The inexplicable beauty of inland Andalusia</div>
                        
                        <a href="#demo1b" data-toggle="collapse">November</a>
                        <div id="demo1b" class="collapse our-cust-callps"> The inexplicable beauty of inland Andalusia </div>
                        
                        <a href="#demo1c" data-toggle="collapse">October</a>
                        <div id="demo1c" class="collapse our-cust-callps"> The inexplicable beauty of inland Andalusia </div>
                        
                        <a href="#demo1d" data-toggle="collapse">September</a>
                        <div id="demo1d" class="collapse our-cust-callps"> The inexplicable beauty of inland Andalusia </div>
                        
                      </div>
                    </li>
                    <li><a href="#demo1" data-toggle="collapse">2015</a>
                      <div id="demo1" class="collapse"> Lorem ipsum dolor text.... </div>
                    </li>
                  </ul>--%>
        </div>
        <!-- Blog Archive End -->

        <!-- Blog Archive Start -->
        <div class="outer-border mrd-bot10">
            <div class="widget PlusBadge" data-version="1" id="PlusBadge1">
                <script type="text/javascript">
                    window.___gcfg = {
                        lang: 'en_GB'
                    };
                </script>
                <h2 class="title">Google+ Badge</h2>
                <div style="text-indent: 0px; margin: 0px; padding: 0px; background: transparent; border-style: none; float: none; line-height: normal; font-size: 1px; vertical-align: baseline; display: inline-block; width: 306px; height: 356px;" id="___page_0">
                    <iframe style="position: static; top: 0px; width: 306px; margin: 0px; border-style: none; left: 0px; visibility: visible; height: 356px;" tabindex="0" width="100" id="I6_1497524666773" name="I6_1497524666773" src="https://apis.google.com/_/widget/render/page?usegapi=1&amp;href=https%3A%2F%2Fplus.google.com%2F111046084239890082041&amp;layout=portrait&amp;rel=author&amp;showcoverphoto=true&amp;showtagline=true&amp;theme=light&amp;width=306&amp;hl=en_GB&amp;origin=http%3A%2F%2Finland-andalucia.blogspot.in&amp;gsrc=3p&amp;ic=1&amp;jsh=m%3B%2F_%2Fscs%2Fapps-static%2F_%2Fjs%2Fk%3Doz.gapi.en_US.jilAkG49OP4.O%2Fm%3D__features__%2Fam%3DAQ%2Frt%3Dj%2Fd%3D1%2Frs%3DAGLTcCOdVhrjiqdOGCPL43uHelKks7zUCA#_methods=onPlusOne%2C_ready%2C_close%2C_open%2C_resizeMe%2C_renderstart%2Concircled%2Cdrefresh%2Cerefresh%2Conload&amp;id=I6_1497524666773&amp;parent=http%3A%2F%2Finland-andalucia.blogspot.in&amp;pfname=&amp;rpctoken=30981414" data-gapiattached="true" title="+Badge"></iframe>
                </div>
            </div>
        </div>

    </div>
</div>
