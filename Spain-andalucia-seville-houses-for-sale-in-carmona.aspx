<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Spain-andalucia-seville-houses-for-sale-in-carmona.aspx.vb" Inherits="CampillosLocationInfo" %>

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
                        <h1>Carmona Andalucia</h1>
                    </div>
                    <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=216&SubAreaId=0&sort=price_asc">
                        <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>
                        <asp:Literal ID='Literal22' Text='<%$Resources:Resource, Located  %>' runat='server'></asp:Literal></p>
                    <!-- Detail one Strat -->
                </div>
            </div>
        </div>
        <div class="divider">
            <img src="/images/divider.png"></div>

        <!-- Quick information about Mollina  Start-->
        <div class="row">
            <div class="col-md-12">
                <div class="quick-information-about-mollina">
                    <h3>
                        <asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationAbout %>' runat='server'></asp:Literal>
                        Carmona:</h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png">
                        <p>
                            29.000<asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/school.png">
                        <p>
                            <asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/car.png">
                        <p>
                            Antequera 123km
Málaga 180km
Granada 230km
Sevilla 45km
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            180km
                            <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/hospital.png">
                        <p>
                            <asp:Literal ID='Literal6' Text='<%$Resources:Resource, healthclinichospital %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pool.png">
                        <p>
                            <asp:Literal ID='Literal7' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/Beach.png">
                        <p>
                            <asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal>
                            1.30h
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            230km
                            <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/shopping.png">
                        <p>
                            <asp:Literal ID='Literal10' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/golf.png">
                        <p>
                            <asp:Literal ID='Literal11' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/bus.png">
                        <p>
                            <asp:Literal ID='Literal12' Text='<%$Resources:Resource, busservice %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            45km
                            <asp:Literal ID='Literal13' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>

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
                    <h3>Carmonal
                        <asp:Literal ID='Literal14' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                        <asp:Literal ID='Literal15' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                    <img src="/images/photos/TownLocationInfo/carmona_coa.gif" alt="Carmona Coat of Arms">

                    <a href="http://www.carmona.org" title="Caroma Town Hall" target="_blank">www.carmona.org</a>
                    <h5>Ayuntamiento de Carmona</h5>
                    <p>
                        Plaza del Salvador, s/n 41410
 Carmona, Sevilla
   Telephone: 954-140-011
                    </p>
                    <p><a href="http://www.campillos.es/" title="Ayuntamiento de Campillos" target="_blank">http://www.campillos.es/</a></p>

                </div>
                <div class="col-md-6 col-sm-6">
                    <img class="img-bdr mrg-10t" src="/images/photos/TownLocationInfo/carmona_ayuntamiento.jpg" alt="Carmona Coat of Arms">
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
                    <h3>Carmona 
                        <asp:Literal ID='Literal17' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>
                        <asp:Literal ID='Literal31' Text='<%$Resources:Resource, enterance %>' runat='server'></asp:Literal></p>
                    <p>Up still further is the Plaza San Fernando which is comparatively small but dominated by splendid Moorish style buildings, behind here is a bustling fruit and vegetable market which, like all markets in Andalucia, appropriately reflects what is in season at any given time.</p>

                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/carmona5.jpg" alt="Carmona Town Hall"></div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">

                    <p>
                        <asp:Literal ID='Literal1' Text='<%$Resources:Resource, carmonaclose %>' runat='server'></asp:Literal></p>
                    <p>
                        <asp:Literal ID='Literal18' Text='<%$Resources:Resource, carmonatotheleft %>' runat='server'></asp:Literal></p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/carmona6.jpg" alt="Benameji square"></div>
            </div>
        </div>


        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>
                        <asp:Literal ID='Literal19' Text='<%$Resources:Resource, carmonatotheroman %>' runat='server'></asp:Literal></p>
                    <p>
                        <asp:Literal ID='Literal20' Text='<%$Resources:Resource, carmonaEnclosed  %>' runat='server'></asp:Literal></p>


                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/carmona7.jpg" alt="Benameji square"></div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>
                        <asp:Literal ID='Literal21' Text='<%$Resources:Resource, carmonaCarmona  %>' runat='server'></asp:Literal></p>
                    <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal24' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/carmona4.jpg" alt="Benameji castle"></div>
            </div>
        </div>

        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p></p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/carmona8.jpg" alt="Benameji castle"></div>
            </div>
        </div>

        <!-- Detail Two End -->
        <!-- Detail three Start -->


        <!-- Detail three Start -->

        <!-- Detail three Start -->
    </div>
    <!-- Detail three Start -->
</asp:Content>

