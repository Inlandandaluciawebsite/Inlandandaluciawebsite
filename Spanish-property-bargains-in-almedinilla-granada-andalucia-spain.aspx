<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Spanish-property-bargains-in-almedinilla-granada-andalucia-spain.aspx.vb" Inherits="guide_almedinilla" %>

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
                        <h1>Almedinilla Granada</h1>
                    </div>
                    <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=1&areaid=59&SubAreaId=0&sort=price_asc">
                        <asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>
                        <asp:Literal ID='Literal1' Text='<%$Resources:Resource, AlmedinillaDetail %>' runat='server'></asp:Literal></p>
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
                        <asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal>
                        Almedinilla:</h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png" alt="plan" />
                        <p>
                            2.536
                            <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/school.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/car.png" alt="plan" />
                        <p>
                            Antequera 100km
Malaga 143km
Granada 68km
Sevilla 206km
             
                  
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            143km
                            <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/hospital.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal6' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pool.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal7' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/Beach.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal>
                            1h45
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            68km
                            <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/shopping.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal10' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/golf.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal11' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/bus.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal13' Text='<%$Resources:Resource, BusTrainService %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            206km
                            <asp:Literal ID='Literal14' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>

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
                    <h3>Almedinilla
                        <asp:Literal ID='Literal15' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                        <img src="/images/townguide/almedinilla/coa-almedinilla.jpg" alt="Alcala de Real Coat of Arms" />
                    </div>
                    <div class="col-md-8 col-sm-8">
                        <h5>Ayuntamiento de Marinaleda</h5>
                        <p>
                            Ayuntamiento de Almedinilla
Plaza de la Constitucion, 1
Almedinilla, Granada
Telephone: 957 703 085
                     <p><a href="http://www.almedinilla.es/" target="_blank">http://www.almedinilla.es/</a></p>
                        </p>

                    </div>
                    <div>
                    </div>

                </div>
                <div class="col-md-6 col-sm-6">
                    <img class="img-bdr mrg-10t" src="/images/townguide/almedinilla/almedinilla1.jpg" alt="Alacala la Real" />
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
                    <h3>Almedinilla
                        <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <p>
                            <asp:Literal ID='Literal18' Text='<%$Resources:Resource, AlmedinillaDetail1 %>' runat='server'></asp:Literal></p>
                        <p>
                            <asp:Literal ID='Literal19' Text='<%$Resources:Resource, AlmedinillaDetail2 %>' runat='server'></asp:Literal></p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/townguide/almedinilla/almedinilla2.jpg" alt="View of Almedinilla" /></div>
                </div>
            </div>
        </div>

        <!-- Detail Two End -->
        <!-- Detail three Start -->
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal20' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>

                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/almedinilla/almedinilla3.jpg" alt="View of Almedinilla" /></div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/almedinilla/almedinilla4.jpg" alt="Castle Almedinilla" /></div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/almedinilla/almedinilla5.jpg" alt="astle View of Almedinilla" /></div>
            </div>
        </div>
        <!-- Detail three Start -->


        <!-- Detail three Start -->

        <!-- Detail three Start -->
    </div>
    <!-- Detail three Start -->
</asp:Content>

