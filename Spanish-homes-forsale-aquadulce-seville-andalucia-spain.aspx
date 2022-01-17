<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Spanish-homes-forsale-aquadulce-seville-andalucia-spain.aspx.vb" Inherits="aguadulceLocationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Left Portion Start -->
    <div class="col-md-8">
        <!-- View trip listing Start -->
        <div class="row">
            <div class="">
                <div class="town-guide-hd">
                    <div class="col-md-8">
                        <h1>
                            <asp:Literal ID="Literal3" Text="<%$Resources:Resource, aguaduceLocationInfoheading %>" runat="server"></asp:Literal></h1>
                    </div>
                    <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=7&SubAreaId=0&sort=price_asc">
                        <asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>
                </div>
            </div>
        </div>


        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>
                        <asp:Literal ID="Literal2" Text="<%$Resources:Resource, aguaduceLocationInfoquickdetail %>" runat="server"></asp:Literal>
                    </p>

                </div>
            </div>
        </div>
        <!-- Detail one Strat -->

        <div class="divider">
            <img src="/images/divider.png"></div>

        <!-- Quick information about Mollina  Start-->
        <div class="row">
            <div class="col-md-12">
                <div class="quick-information-about-mollina">
                    <h3>
                        <asp:Literal ID="Literal1" Text="<%$Resources:Resource, aguaduceLocationInfoquickinfoabout %>" runat="server"></asp:Literal></h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png">
                        <p>
                            2.000
                            <asp:Literal ID="Literal13" Text="<%$Resources:Resource, residents %>" runat="server"></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/school.png">
                        <p>
                            <asp:Literal ID="Literal14" Text="<%$Resources:Resource, schools %>" runat="server"></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/car.png">
                        <p>
                            Antequera 60km
Malaga 105km
Granada 145km
Sevilla 100km
                  
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            105km
                            <asp:Literal ID="Literal15" Text="<%$Resources:Resource, tomalega %>" runat="server"></asp:Literal>

                            <p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/hospital.png">
                        <p>
                            <asp:Literal ID="Literal16" Text="<%$Resources:Resource, healthclinic %>" runat="server"></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pool.png">
                        <p>
                            <asp:Literal ID="Literal17" Text="<%$Resources:Resource, muncipalpool %>" runat="server"></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/Beach.png">
                        <p>
                            <asp:Literal ID="Literal18" Text="<%$Resources:Resource, beach %>" runat="server"></asp:Literal>
                            1h15
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            145km
                            <asp:Literal ID="Literal19" Text="<%$Resources:Resource, togranada %>" runat="server"></asp:Literal>

                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/shopping.png">
                        <p>
                            <asp:Literal ID="Literal20" Text="<%$Resources:Resource, shopsbars %>" runat="server"></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/golf.png">
                        <p>
                            <asp:Literal ID="Literal21" Text="<%$Resources:Resource, golfnearby %>" runat="server"></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/bus.png">
                        <p>
                            <asp:Literal ID="Literal23" Text="<%$Resources:Resource, busservice %>" runat="server"></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            100km
                            <asp:Literal ID="Literal24" Text="<%$Resources:Resource, tosevilla %>" runat="server"></asp:Literal>

                            <p>
                    </div>
                </div>


            </div>
        </div>

        <!-- Quick information about Mollina End --->

        <div class="divider">
            <img src="/images/divider.png"></div>

        <!--Properties for sale in Mollina -->

        <div class="row">
            <div class="col-md-12">
                <div class="monilla-loc">
                    <%-- google map --%>
                    <h3>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, aguaduceLocationInfolocation %>" runat="server"></asp:Literal></h3>
                    <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <!--Properties for sale in Mollina -->

        <div class="divider">
            <img src="/images/divider.png"></div>

        <!-- Location Information Start -->
        <div class="row">
            <div class="location-info">
                <div class="col-md-6 col-sm-6">
                    <h4>
                        <asp:Literal ID="Literal5" Text="<%$Resources:Resource, aguaduceLocationInfolocalinfo%>" runat="server"></asp:Literal></h4>
                    <img src="/images/photos/TownLocationInfo/aguadulce_coa.gif" alt="Aguadulce Coat of Arms" />

                    <h5>Ayuntamiento de 
                          Aguadulce</h5>
                    <p>
                        Plaza Ram&oacute;n y Caja, 1, 
                 41550 Aguadulce, 
                          Sevilla
                   Telephone: 954-816-220
                    </p>
                    <a href="http://www.aguadulce.es/" target="_blank">http://www.aguadulce.es/</a>
                </div>
                <div class="col-md-6 col-sm-6">
                    <img src="/images/photos/TownLocationInfo/aguadulce1.jpg" alt="Town Hall, Aguadulce" class="img-bdr mrg-10t">
                </div>
            </div>
        </div>

        <!-- Location Information End -->

        <div class="divider">
            <img src="/images/divider.png"></div>

        <!-- Detail Two Strat -->
        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12">
                    <h3>
                        <asp:Literal ID="Literal6" Text="<%$Resources:Resource, aguaduceLocationInfanguinformation %>" runat="server"></asp:Literal></h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <p>
                            <asp:Literal ID="Literal7" Text="<%$Resources:Resource, aguaduceLocationInfoquickinfodetail1 %>" runat="server"></asp:Literal></p>
                        <p>
                            <asp:Literal ID="Literal8" Text="<%$Resources:Resource, aguaduceLocationInfodetail2 %>" runat="server"></asp:Literal></p>

                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/aguadulce2.jpg" alt="Aguadulce Andalucia street"></div>
                </div>
            </div>
        </div>

        <!-- Detail Two End -->
        <!-- Detail three Start -->
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>
                        <asp:Literal ID="Literal9" Text="<%$Resources:Resource, aguaduceLocationInfodetail3 %>" runat="server"></asp:Literal></p>
                    <p>
                        <asp:Literal ID="Literal10" Text="<%$Resources:Resource, aguaduceLocationInfodetail4 %>" runat="server"></asp:Literal></p>

                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/aguadulce3.jpg" alt="Aguadulce Andalucia nature"></div>
            </div>
        </div>
        <!-- Detail three Start -->



        <!-- Detail three Start -->
        <div class="row">
            <div class="mollina-information-dtl ">

                <div class="col-md-8 col-sm-8">
                    <p>
                        »&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia">
                            <asp:Literal ID="Literal11" Text="<%$Resources:Resource, aguaduceLocationInfomoreinfo %>" runat="server"></asp:Literal></a>
                    </p>

                </div>

                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/aguadulce4.jpg" alt="Aguadulce Andalucia nature"></div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl ">

                <div class="col-md-8 col-sm-8">
                </div>

                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/aguadulce6.jpg" alt="Aguadulce Andalucia pre historic"></div>
            </div>
        </div>

        <!-- Detail three Start -->

        <!-- Detail three Start -->
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/aguadulce5.jpg" alt="Aguadulce Andalucia nature"></div>

            </div>
        </div>


        <%--          <div class="row">
            <div class="mollina-information-dtl">
               <div class="col-md-8 col-sm-8">
                <img class="img-bdr" src="/images/mollina4.jpg">
                <img class="img-bdr" src="/images/mollina8.jpg">
               </div>
        </div>
      </div>
             <div class="row">
            <div class="mollina-information-dtl">
            
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                <p>      <a href="TownLocationInfo.aspx" title="More information on towns of Andalucia">
          <%=("More information on towns of Andalucia")%></a></p>
                  
                   </div>
                  
            </div>
          </div>

          
        --%>
    </div>
    <!-- Detail three Start -->
</asp:Content>

