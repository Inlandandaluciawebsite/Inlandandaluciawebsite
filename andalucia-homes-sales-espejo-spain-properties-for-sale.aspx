<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="andalucia-homes-sales-espejo-spain-properties-for-sale.aspx.vb" Inherits="espejo" %>

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
                        <h1>Espejo Andalucia</h1>
                    </div>
                    <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=1&areaid=408&sort=price_asc">
                        <asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>Espejo is a beautiful white washed Spanish Town having a population close to 3,500 inhabitants and boasts a Mediterranean climate.</p>
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
                        <asp:Literal ID='Literal1' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal>
                        Espejo:</h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png">
                        <p>
                            3.563
                            <asp:Literal ID='Literal2' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                            (2012)
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/school.png">
                        <p>
                            <asp:Literal ID='Literal3' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/car.png">
                        <p>
                            Antequera 87km
Malaga 130km
Granada 125km
Sevilla 155km
                  
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            130km  Malaga
                  
                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/hospital.png">
                        <p>
                            <asp:Literal ID='Literal4' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pool.png">
                        <p>
                            <asp:Literal ID='Literal5' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/Beach.png">
                        <p>
                            1h15min
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            125km   Granada
                  
                  <p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/shopping.png">
                        <p>
                            <asp:Literal ID='Literal6' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/golf.png">
                        <p>
                            <asp:Literal ID='Literal7' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/bus.png">
                        <p>
                            <asp:Literal ID='Literal8' Text='<%$Resources:Resource, busstation %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            155km  Sevilla
                  
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
                    <h3>Espejo
                        <asp:Literal ID='Literal9' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                        <asp:Literal ID='Literal10' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                    <div class="col-md-3 col-sm-3">
                        <img src="/images/townguide/espejo/espejo-coa.jpg" alt="Espejo Coat of Arms"></div>
                    <div class="col-md-9 col-sm-9">
                        <h5>Ayuntamiento de Espejo</h5>
                        <p>
                            Plaza de la Constitucion, 5. 14830 Espejo (Cordoba).

Telephone: 957 376 001
                   
                        </p>
                        <p>
                            <strong>E-mail:</strong> <a href="mailto:secretaria.espejo@eprinsa.es ">secretaria.espejo@eprinsa.es </a>
                            <br />
                            <strong>Web:</strong> <a href="http://www.espejo.es" target="_blank">http://www.espejo.es</a>
                        </p>

                    </div>



                </div>
                <div class="col-md-6 col-sm-6">
                    <%--     <img class="img-bdr mrg-10t"  src="/images/townguide/carcabuey/carcabuey1.jpg" alt="Town Hall, Carcabuey">--%>
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
                    <h3>Espejo  
                        <asp:Literal ID='Literal11' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <p>
                            <asp:Literal ID='Literal13' Text='<%$Resources:Resource, espejoDetail1 %>' runat='server'></asp:Literal></p>
                        <p>
                            <asp:Literal ID='Literal14' Text='<%$Resources:Resource, espejoDetail2 %>' runat='server'></asp:Literal></p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/townguide/espejo/espejo-1.jpg" alt="Town Hall, Espejo">
                        <img class="img-bdr" src="/images/townguide/espejo/espejo-2.jpg" alt="Espejo bridge">
                    </div>
                </div>
            </div>
        </div>

        <!-- Detail Two End -->
        <!-- Detail three Start -->
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal15' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/espejo/espejo-3.jpg" alt="View of Espejo"></div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/espejo/espejo-4.jpg" alt="Espejo square"></div>
            </div>
        </div>

        <!-- Detail three Start -->


        <!-- Detail three Start -->

        <!-- Detail three Start -->
    </div>
    <!-- Detail three Start -->
</asp:Content>

