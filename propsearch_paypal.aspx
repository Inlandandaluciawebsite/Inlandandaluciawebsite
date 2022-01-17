<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="propsearch.aspx.vb" Inherits="propsearch" %>

<asp:Content ID="Contenttp" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <link href='<%= ResolveUrl("~/owl-carousel/owl.carousel.css") %>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/owl-carousel/owl.theme.css") %>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/owl-carousel/owl.transitions.css") %>' rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">

        function initialize() {
            var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
            var mapOptions = {
                center: new google.maps.LatLng(markers[0].latitude, markers[0].longitude),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
            var image = '/images/icons/map-pointer.png';
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

        function RedirectToBuyerPage() {

            var valueOfh3;
            valueOfh3 = $(".gallery-head .row .col-md-8").html();
            sessionStorage.setItem("dataBuyer", valueOfh3);
            sessionStorage.setItem("paidAmount", 1000);
            window.location = "Buyer.aspx";

        }
        function OpenMessageWindow() {
            document.getElementById('msgWindow').style.display = "block";
        }
    </script>


    <style>
        .page_enabled, .page_disabled {
            display: inline-block;
        }

        .page_enabled {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin-left: -1px;
            line-height: 1.42857;
            color: #337AB7 !important;
            text-decoration: none;
            background-color: #FFF !important;
            border: 1px solid #DDD;
        }

        .page_disabled {
            color: #23527C;
            background-color: #eee !important;
            border-color: #DDD !important;
            outline: 0px none;
        }
    </style>
    <script type="text/javascript">
         function clickButton(e, buttonid) {
             var evt = e ? e : window.event;
             var bt = document.getElementById(buttonid);
             if (bt) {
                 if (evt.keyCode == 13) {
                     bt.click();
                     return false;
                 }
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <asp:UpdatePanel ID="upsearch" runat="server">
        <ContentTemplate>




            <!-- Main Content Area Start --Detail page>

        <!-- Left Portion Start -->
            <div class="col-md-8" id="detaildiv" runat="server">
                <!-- Listing Head Start -->
                <div class="row">
                    <div class="col-md-12">
                        <!-- Detail Page Start -->
                        <div class="detail-property-start">

                            <!-- Listing Start -->
                            <div class="row">
                                <div class="col-md-12">
                                    <a class="a2a_dd" href="https://www.addtoany.com/share_save" style="display: none" id="fbshare" runat="server">
                                        <img src="//static.addtoany.com/buttons/share_save_171_16.png" width="171" height="16" border="0" alt="Share" /></a>

                                    <div class="details-listing" id="topmenu" runat="server" style="display: block; width: 744px;">

                                        <script type="text/javascript" src="//static.addtoany.com/menu/page.js"></script>
                                        <ul>
                                            <li><%--<a href="#"></a>--%>
                                                <asp:LinkButton ID="btnBackDetail" runat="server" OnClick="btnback_Click">
                                                    <asp:Literal runat="server" ID="Literal25" Text=" <%$Resources:Resource,     Back%>"></asp:Literal>
                                                </asp:LinkButton>
                                                <%--                                                <asp:Button ID="btnback" runat="server" class="btn btn-default listing-bk fa fa-arrow-left"  Text="Back" OnClick="btnback_Click" />--%>
                                            </li>
                                            <li>

                                                <a href="windowcard.aspx?propertyref=<%=Referencem %>">
                                                    <asp:Literal runat="server" ID="Literal26" Text=" <%$Resources:Resource,     PrintPreview%>"></asp:Literal></a></li>
                                            <li><span id="Email" runat="server"></span></li>
                                            <li><span id="ContactUs" runat="server"></span></li>
                                            <li>
                                                <div class="watch-video">
                                                    <div id="vidio" runat="server"></div>
                                                </div>
                                            </li>
                                            <li><span id="spnReserveForViewing" runat="server"></span>
                                            </li>

                                        </ul>

                                    </div>

                                    <div id="notfound1" runat="server" style="display: none">
                                        <div>

                                            <p>
                                                <img src="/images/icons/sorry-icon.png" alt="Sorry!" hspace="10" align="left">Sorry, the selected search did not yield any results<br>
                                                Please <span id="Span1"><a href="propsearch.aspx" title="New search">try again</a></span> with different search criteria.
                                            </p>


                                        </div>
                                    </div>


                                </div>
                            </div>
                            <!-- Listing End -->


                            <!-- property Details Start -->
                            <asp:Label ID="lblMapInformation" runat="server" Style="display: none"></asp:Label>
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
                                                            <h3><del class="delete"><%#IIf(Convert.ToString(Eval("FormatorignalPrice")) = "0 €", "", Eval("FormatorignalPrice").ToString())%> </del>&nbsp;<%#Eval("FormatPrice") %> </h3>
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

                                                                <div class="item">
                                                                    <a href='<%#Eval("Name") %>'>
                                                                        <img src='<%#Eval("Name") %>' style="width: 100%;"></a>
                                                                </div>


                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                    <div id="sync2" class="owl-carousel thumbss">
                                                        <asp:Repeater ID="rpslider2" runat="server">
                                                            <ItemTemplate>


                                                                <div class="item">
                                                                    <img src='<%#Eval("Name") %>' style="">
                                                                </div>

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
                                                <p>
                                                    <span>
                                                        <asp:Literal runat="server" ID="Literal14" Text=" <%$Resources:Resource,     Beds%>"></asp:Literal>:</span> <%#Eval("bedrooms") %>
                                                </p>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <p>
                                                    <span>
                                                        <asp:Literal runat="server" ID="Literal1" Text=" <%$Resources:Resource,     Baths%>"></asp:Literal>: </span><%#Eval("bathrooms") %>
                                                </p>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <p>
                                                    <span>
                                                        <asp:Literal runat="server" ID="Literal2" Text=" <%$Resources:Resource,     Views%>"></asp:Literal>: </span><%#Eval("views") %>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <p>
                                                    <span>
                                                        <asp:Literal runat="server" ID="Literal3" Text=" <%$Resources:Resource,     Built%>"></asp:Literal>: </span><%#Eval("sqm_built")%> m²
                                                </p>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <p>
                                                    <span>
                                                        <asp:Literal runat="server" ID="Literal4" Text=" <%$Resources:Resource,     Plot%>"></asp:Literal>: </span><%#Eval("sqm_plot") %> m²
                                                </p>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <p>
                                                    <span>
                                                        <asp:Literal runat="server" ID="Literal5" Text=" <%$Resources:Resource,     Location%>"></asp:Literal>: </span><%#Eval("location") %>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="divider">
                                                    <img src="/images/divider.png">
                                                </div>
                                                <p>
                                                    <span>
                                                        <asp:Literal runat="server" ID="Literal6" Text=" <%$Resources:Resource,     Features%>"></asp:Literal>: </span><%#Eval("features") %>
                                                </p>
                                                <div class="divider">
                                                    <img src="/images/divider.png">
                                                </div>
                                                <p>
                                                    <span>
                                                        <asp:Literal runat="server" ID="Literal7" Text=" <%$Resources:Resource,     Description%>"></asp:Literal>: </span><%#Eval("description") %>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- property Details End -->


                                    <!-- Map Page Start -->
                                    <div class="map-outer">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h6>
                                                    <asp:Literal runat="server" ID="Literal8" Text=" <%$Resources:Resource,     LocationGoogeMap%>"></asp:Literal>:</h6>
                                                <!-- Map Start -->
                                                <div class="map-inner">
                                                    <div id="map_canvas" class="map-inr" style="width: 100%; min-height: 450px;"></div>
                                                </div>
                                                <!-- Map Start -->

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
                                                        <h3><%#Eval("type") %>  (<%#Eval("partner_reference") %>) / <span><%#Eval("region") %> </span>/  <%#Eval("area")%><%#IIf(Convert.ToString(Eval("subarea")) = "Not Specified", "","/" +Eval("subarea").ToString())%>  </h3>
                                                        <%--                            <h4><%#Eval("subArea")%></h4>--%>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4">
                                                        <div class="rate-list">
                                                            <h3><del class="delete"><%#IIf(Convert.ToString(Eval("FormatorignalPrice")) = "0 €", "", Eval("FormatorignalPrice").ToString())%> </del>&nbsp;<%#Eval("FormatPrice") %> </h3>
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

            <!-- Main Content Area Start -->

            <!-- Left Portion Start -->
            <div class="col-md-8" id="advancesearch" runat="server" style="display: block">
                <!-- Property Search Head Start -->
                <div class="row">
                    <div class="col-md-12">
                        <div class="listing-head">
                            <h1 runat="server">
                                <asp:Literal runat="server" ID="tst" Text=" <%$Resources:Resource, AndaluciaProperty %>"></asp:Literal>


                            </h1>
                            <p>
                                <asp:Literal runat="server" ID="Literal1" Text=" <%$Resources:Resource, AndaluciaPropertydesc %>"></asp:Literal>


                            </p>
                        </div>
                    </div>
                </div>
                <!-- Property Search Head End -->

                <!-- Property Search Main Search Area Start -->
                <div class="row">
                    <div class="col-md-12">
                        <div class="property-search-advanced">
                            <h2>
                                <asp:Literal runat="server" ID="Literal2" Text=" <%$Resources:Resource, Propertysearchadvanced %>"></asp:Literal>
                            </h2>
                            <div class="form-horizontal prop-search-adv col-md-8">

                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        <asp:Literal runat="server" ID="Literal3" Text=" <%$Resources:Resource, Area%>"></asp:Literal>
                                    </label>
                                    <div class="col-sm-8">

                                        <asp:DropDownList ID="DropDownListRegion" runat="server"
                                            class="form-control" AutoPostBack="true" />
                                    </div>
                                </div>

                                <div class="form-group" id="drptown" runat="server" style="display: none">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        <asp:Literal runat="server" ID="Literal4" Text=" <%$Resources:Resource, Town%>"></asp:Literal>
                                    </label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="DropDownListArea" runat="server" class="form-control" AutoPostBack="true" />


                                    </div>
                                </div>


                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        <asp:Literal runat="server" ID="Literal5" Text=" <%$Resources:Resource, PropertyType%>"></asp:Literal>
                                    </label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="DropDownListType" runat="server"
                                            class="form-control">
                                        </asp:DropDownList>

                                    </div>
                                </div>


                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        <asp:Literal runat="server" ID="Literal6" Text=" <%$Resources:Resource, MinBeds%>"></asp:Literal>
                                    </label>

                                    <div class="col-sm-8">

                                        <asp:DropDownList ID="DropDownListBedrooms" runat="server"
                                            CssClass="form-control">
                                            <asp:ListItem Text=" <%$Resources:Resource,   Any%>" Value="0"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   OneorMore%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   TwoorMore%>" Value="2"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   ThreeorMore%>" Value="3"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   FourorMore%>" Value="4"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   FiveorMore%>" Value="5"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        <asp:Literal runat="server" ID="Literal7" Text=" <%$Resources:Resource,   MinBaths%>"></asp:Literal>

                                    </label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="DropDownListBathrooms" runat="server"
                                            CssClass="form-control">
                                            <asp:ListItem Text=" <%$Resources:Resource,   Any%>" Value="0"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   OneorMore%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   TwoorMore%>" Value="2"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   ThreeorMore%>" Value="3"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   FourorMore%>" Value="4"></asp:ListItem>
                                            <asp:ListItem Text=" <%$Resources:Resource,   FiveorMore%>" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                        <%--   <select class="form-control">
                                                    <option value="Any">Any</option>
                                                    <option value="1 or more">1 or more</option>
                                                    <option value="2 or more">2 or more</option>
                                                    <option value="3 or more">3 or more</option>
                                                    <option value="4 or more">4 or more</option>
                                                    <option value="5 or more">5 or more</option>

                                                </select>--%>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        <asp:Literal runat="server" ID="Literal8" Text=" <%$Resources:Resource,    Pricefrom%>"></asp:Literal>
                                    </label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="DropDownListPriceFrom" runat="server"
                                            CssClass="form-control" OnSelectedIndexChanged="DropDownListPriceFrom_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>


                                    </div>
                                </div>


                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        <asp:Literal runat="server" ID="Literal9" Text=" <%$Resources:Resource,    to%>"></asp:Literal>
                                    </label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="DropDownListPriceTo" runat="server"
                                            CssClass="form-control" OnSelectedIndexChanged="DropDownListPriceTo_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>

                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:Button ID="btnSearch" runat="server" Text=" <%$Resources:Resource,    btnSearch%>" class="btn btn-default listing-bk serach-btn " OnClick="btnSearch_Click" />

                                    </div>

                                </div>


                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="property-search-advanced">
                            <h2>
                                <asp:Literal runat="server" ID="Literal11" Text=" <%$Resources:Resource,     Propertysearchbyreference%>"></asp:Literal>

                            </h2>
                            <div class="form-horizontal prop-search-adv col-md-8">

                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        <asp:Literal runat="server" ID="Literal10" Text=" <%$Resources:Resource,     Referencenumber%>"></asp:Literal>
                                    </label>
                                    <div class="col-sm-8">
                                        <%--   <input type="email" class="form-control" id="exampleInputEmail1" placeholder="">--%>
                                        <asp:TextBox ID="txtrefnumb" runat="server" CssClass="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <%--                                                <button type="submit" class="btn btn-default listing-bk serach-btn ">Search</button>--%>
                                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-default listing-bk serach-btn" OnClick="btnsubmit_Click" Text=" <%$Resources:Resource,    btnSearch%>" />
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>


                <!-- Property Search Main Search Area End -->


            </div>
            <div id="notfound" class="col-md-8" runat="server" style="display: none">
                <div class="row">
                    <div class="col-md-12">
                        <p>
                            <img src="/images/icons/sorry-icon.png" alt="Sorry!" hspace="10" align="left">Sorry, the selected search did not yield any results<br>
                            Please <span id="NoResults1_TryAgain"><a href="propsearch.aspx" title="New search">try again</a></span> with different search criteria.
                        </p>
                    </div>

                </div>
            </div>
            <div class="col-md-8" id="searchresult" runat="server" style="display: none">
                <!-- Listing Head Start -->
                <div class="row">
                    <div class="col-md-12">
                        <div class="listing-head">
                            <h1>
                                <asp:Literal runat="server" ID="Literal19" Text=" <%$Resources:Resource,     InlandPropertyList%>"></asp:Literal>
                            </h1>
                            <div class="listing-btns">
                                <%-- <button class="btn btn-default listing-bk" type="submit"><span><i class="fa fa-arrow-left"></i></span> Back</button>--%>
                                <asp:Button ID="btnback" runat="server" class="btn btn-default listing-bk" Text=" <%$Resources:Resource,     Back%>" OnClick="btnback_Click" />
                                <a href="propsearch.aspx" runat="server" class="btn btn-default listing-search"><span class="newsrch"><i class="fa fa-star"></i></span>
                                    <asp:Literal runat="server" ID="Literal20" Text=" <%$Resources:Resource,     NewSearch%>"></asp:Literal></a>
                                <%--<button class="btn btn-default listing-search" type="submit"></button>--%>
                            </div>
                            <div class="listing-list-multi" style="display: block" id="listmenu" runat="server">
                                <div class="top-paggi">
                                    <div id="navpropery" runat="server"></div>
                                    <%-- <ul class="nav nav-pills" role="tablist">
                      <li role="presentation" class="active"><a href="#">Cordoba <span class="badge">44</span></a></li>
                      <li role="presentation"><a href="#">Granada <span class="badge">45</span></a></li>
                      <li role="presentation"><a href="#">Jaen <span class="badge">220</span></a></li>
                      <li role="presentation"><a href="#">Malaga <span class="badge">180</span></a></li>
                      <li role="presentation"><a href="#">Sevilla <span class="badge">89</span></a></li>
                    </ul>--%>
                                </div>
                            </div>



                            <!-- main pagging start -->
                            <div class="row">
                                <div class="col-md-12">

                                    <div class="paggination-top" style="display: block" runat="server" id="propcount">

                                        <div class="col-md-6 col-sm-6">
                                            <h4>
                                                <asp:Label ID="lblpropertycount" runat="server"></asp:Label>
                                                <asp:Literal runat="server" ID="Literal18" Text=" <%$Resources:Resource,     propertiesfound%>"></asp:Literal>
                                            </h4>

                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <div class="pagecount1">
                                                <asp:Literal runat="server" ID="Literal17" Text=" <%$Resources:Resource,     Page%>"></asp:Literal>
                                                <asp:Label ID="lblcountpagenumber" runat="server"></asp:Label>
                                                <asp:Literal runat="server" ID="Literal16" Text=" <%$Resources:Resource,     of%>"></asp:Literal>
                                                <asp:Label ID="lblcounttotalpage" runat="server"></asp:Label>

                                            </div>

                                        </div>

                                        <div class="col-md-4 col-sm-4">
                                            <ul class="pagination">
                                                <asp:Repeater ID="rptPager" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                                CssClass='<%# If(Convert.ToBoolean(Eval("Enabled")), "page_enabled", "page_disabled")%>'
                                                                OnClick="Page_Changed" OnClientClick='<%# If(Not Convert.ToBoolean(Eval("Enabled")), "return false;", "") %>'></asp:LinkButton></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                            </div>






                            <!-- Main Pagging End -->



                            <asp:Repeater ID="rpFeaturedProperty" runat="server">
                                <ItemTemplate>
                                    <!-- Mini single item Start -->
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="mini-item-start">
                                                <div class="col-md-8 col-sm-8">
                                                    <h4><b><%#Eval("type") %>  (<%#Eval("reference") %> )</b> / <%#Eval("region") %>  <b>/<%#IIf(Convert.ToString(Request.QueryString("SubAreaId")) = "0", Eval("area").ToString(), Eval("subarea").ToString())%>   </b></h4>
                                                    <h3><%#Eval("short_description") %> </h3>
                                                </div>
                                                <div class="col-md-4 col-sm-4">
                                                    <h2><del class="delete"><%#IIf(Convert.ToString(Eval("original_price")) = "0", "", FormatPrice(Eval("original_price")).ToString())%> </del>&nbsp; <%#FormatPrice(Eval("price")) %></h2>
                                                </div>
                                            </div>
                                            <div class="mini-item-detail">
                                                <div class="thumbnail-imgg col-md-4 col-sm-4">
                                                    <a href="propsearch.aspx?propertyref=<%#Eval("reference") %>">
                                                        <asp:Image ID="imgproperty" runat="server" ImageUrl='<%# ApplyStatusWatermark(PhotoURL(Eval("reference").ToString().Trim()), Convert.ToInt32(Eval("status_id"))) %>' /></a>
                                                </div>
                                                <div class="paragraph-st col-md-8 col-sm-8">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal runat="server" ID="Literal14" Text=" <%$Resources:Resource,     Beds%>"></asp:Literal>:</strong> <%#Eval("bedrooms") %>  / <strong>
                                                                <asp:Literal runat="server" ID="Literal21" Text=" <%$Resources:Resource,     Baths%>"></asp:Literal>:</strong> <%#Eval(" bathrooms") %>  / <strong>
                                                                    <asp:Literal runat="server" ID="Literal22" Text=" <%$Resources:Resource,     Built%>"></asp:Literal>:</strong> <%#Eval("sqm_built") %> m² /<strong>
                                                                        <asp:Literal runat="server" ID="Literal23" Text=" <%$Resources:Resource,     Plot%>"></asp:Literal>:</strong> <%#Eval("sqm_plot")%> m²
                                                    </p>
                                                    <p><%#Eval("description") %> </p>
                                                    <a href="propsearch.aspx?propertyref=<%#Eval("reference") %>" class="btn btn-default read-more">
                                                        <asp:Literal runat="server" ID="Literal24" Text=" <%$Resources:Resource,     MoreInfo%>"></asp:Literal>
                                                        >></a>

                                                </div>
                                            </div>
                                            <!--mini-item-detail-end-->

                                        </div>
                                    </div>
                                    <!--Mini single item End -->
                                </ItemTemplate>
                            </asp:Repeater>


                            <!-- main pagging start -->
                            <div class="row">
                                <div class="col-md-12">

                                    <div class="paggination-top" style="display: block" runat="server" id="Div2">

                                        <div class="col-md-6 col-sm-6">
                                            <h4>
                                                <asp:Label ID="lblpropertycount1" runat="server"></asp:Label>
                                                <asp:Literal runat="server" ID="Literal13" Text=" <%$Resources:Resource,     propertiesfound%>"></asp:Literal>
                                            </h4>

                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <div class="pagecount1">
                                                <asp:Literal runat="server" ID="Literal14" Text=" <%$Resources:Resource,     Page%>"></asp:Literal>
                                                <asp:Label ID="lblcountpagenumber1" runat="server"></asp:Label>
                                                <asp:Literal runat="server" ID="Literal15" Text=" <%$Resources:Resource,     of%>"></asp:Literal>
                                                <asp:Label ID="lblcounttotalpage1" runat="server"></asp:Label>

                                            </div>

                                        </div>
                                        <div class="col-md-4 col-sm-4">
                                            <ul class="pagination">
                                                <asp:Repeater ID="rptpage2" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                                CssClass='<%# If(Convert.ToBoolean(Eval("Enabled")), "page_enabled", "page_disabled")%>'
                                                                OnClick="Page_Changed" OnClientClick='<%# If(Not Convert.ToBoolean(Eval("Enabled")), "return false;", "") %>'></asp:LinkButton></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <p>
                                        <asp:Literal runat="server" ID="Literal12" Text=" <%$Resources:Resource,     To050descbelow%>"></asp:Literal>
                                    </p>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- Listing Head End -->
            </div>
            <!-- Left Portion Start -->


            <!-- Main Content Area End -->

            <!-- Created Message Window -->
            <div id="msgWindow" style="background-color: #2d3091; color: white; width: 310px; height: 100px; padding: 8px; border: 2px; border-radius: 10px; display: none; position: absolute; top: 230px; left: 600px;">
                On receipt, we will reserve this property for you to view within 2 weeks. Any price negotiation will be determined after.
                <br />
                <input type="button" value="OK" title="OK" style="color: #2d3091; width: 80px;" onclick="javascript: RedirectToBuyerPage();" />&nbsp;&nbsp;
                <input type="button" value="Cancel" style="color: #2d3091; width: 80px;" title="Cancel" onclick="javascript: document.getElementById('msgWindow').style.display = 'none';" />
            </div>
            <!-- Endo of Message Window Markup -->
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Main Content Area End -->

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->

    <script src='<%= ResolveUrl("~/assets/js/jquery-1.9.1.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/owl-carousel/owl.carousel.js") %>'></script>

    <%--<script src="owl-carousel/owl.carousel.js"></script>--%>
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
                transitionStyle: "fade",
                stopOnHover: true,
                autoHeight: true,
                autoWidth: true

            });

            sync2.owlCarousel({
                items: 6,
                transitionStyle: "fade",
                itemsDesktop: [1199, 6],
                itemsDesktopSmall: [979, 6],
                itemsTablet: [768, 6],
                itemsMobile: [479, 4],
                pagination: false,
                responsiveRefreshRate: 100,
                autoHeight: true,
                autoWidth: true,
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

