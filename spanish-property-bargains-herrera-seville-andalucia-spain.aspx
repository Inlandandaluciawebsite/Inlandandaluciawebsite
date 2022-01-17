<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="spanish-property-bargains-herrera-seville-andalucia-spain.aspx.vb" Inherits="benameji" %>

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
                        <h1>Herrera Andalucia</h1>
                    </div>
                    <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=493&SubAreaId=0&sort=price_asc">
                        <asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>At the eastern edge of La Campiña, Herrera is a farming village surrounded by rolling hills of wheat fields and olive groves. It used to be an important iron mining area.</p>
                </div>
            </div>
        </div>
        <!-- Detail one Strat -->

        <div class="divider">
            <img src="/images/divider.png" alt="plan" /></div>

        <!-- Quick information about Mollina  Start-->
        <div class="row">
            <div class="col-md-12">
                <div class="quick-information-about-mollina">
                    <h3>
                        <asp:Literal ID='Literal3' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal>
                        Herrera:</h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png" alt="plan" />
                        <p>
                            6.700
                            <asp:Literal ID='Literal4' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/school.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal5' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/car.png" alt="plan" />
                        <p>
                            Antequera 54km
Malaga 100km
Granada 145km
Sevilla 120km
             
                  
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            100km
                            <asp:Literal ID='Literal6' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/hospital.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal7' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pool.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal8' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/Beach.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal9' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal>
                            1h
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            145km
                            <asp:Literal ID='Literal10' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/shopping.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal11' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/golf.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal13' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/bus.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal14' Text='<%$Resources:Resource, BusTrainService %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            120km
                            <asp:Literal ID='Literal15' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Quick information about Mollina End --->

        <div class="divider">
            <img src="/images/divider.png" alt="plan" /></div>

        <!--Properties for sale in Mollina -->

        <div class="row">
            <div class="col-md-12">
                <div class="monilla-loc">

                    <%-- google map --%>
                    <h3>Herrera
                        <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
                    <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <!--Properties for sale in Mollina -->
        <div class="divider">
            <img src="/images/divider.png" alt="plan" /></div>

        <!-- Location Information Start -->
        <div class="row">
            <div class="location-info">
                <div class="col-md-6 col-sm-6">
                    <h4>
                        <asp:Literal ID='Literal17' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                    <div class="col-md-4 col-sm-4">
                        <img src="/images/photos/TownLocationInfo/herrera_coa.gif" alt="Alcala de Real Coat of Arms" />
                    </div>
                    <div class="col-md-8 col-sm-8">
                        <h5>Ayuntamiento de Herrera</h5>
                        <p>
                            Avenida Constitución,
1 41567 Herrera, Sevilla.
Telephone: 954-013-012 
E-mail: ayuntamiento@benameji.es

                     <p><a href="http://aytoherrera.com/" target="_blank">http://aytoherrera.com/</a></p>
                        </p>

                    </div>


                </div>
                <div class="col-md-6 col-sm-6">
                    <%--   <img class="img-bdr mrg-10t"  src="/images/townguide/almedinilla/almedinilla1.jpg" alt="Alacala la Real">--%>
                </div>
            </div>
        </div>

        <!-- Location Information End -->

        <div class="divider">
            <img src="/images/divider.png" alt="plan" /></div>

        <!-- Detail Two Strat -->
        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12">
                    <h3>Herrera
                        <asp:Literal ID='Literal18' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <p>The 17th century church of Santiago el Mayor forms the central focus of the village. Festivals in Herrera include the main local fair which takes place from the 5th to the 8th of August, the festival of San Marcos on April 25th and a pilgrimage of the Virgen de Fátima on the 10th of May.</p>
                        <p>The town of 6,700 is full of amenities and has a beautiful municipal pool with bar/restaurant. There is also a train station for the new high speed train (AVE) that is nearing completion. The town is flat and everything is a short, easy walk. </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/herrera5.jpg" alt="Herrera donkeys" /></div>
                </div>
            </div>
        </div>

        <!-- Detail Two End -->
        <!-- Detail three Start -->
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>Herrera is situated on the N340, 8km north of the A92 motorway. The nearest sizeable town is that of Puente Genil, 9km away in Córdoba province. </p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/herrera1.jpg" alt="Herrera Andalucia sheep" /></div>
            </div>
        </div>
<%--        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>
                        <asp:Literal ID='Literal22' Text='<%$Resources:Resource, BenamejiDetail5 %>' runat='server'></asp:Literal></p>


                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/herrera4.jpg" alt="Herrera Andalucia motorway" /></div>
            </div>
        </div>--%>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal24' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/herrera6.jpg" alt="Herrera Andalucia church" /></div>
            </div>
        </div>
        <!-- Detail three Start -->


        <!-- Detail three Start -->

        <!-- Detail three Start -->
    </div>
    <!-- Detail three Start -->
</asp:Content>

