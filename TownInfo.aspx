<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="TownInfo.aspx.vb" Inherits="TownInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Left Portion Start -->
    <div class="col-md-8">
        <!-- View trip listing Start -->
        <div class="row">
            <div class="col-md-8">
                &nbsp;
            </div>
            <div class="col-md-4">
                <asp:HyperLink ID="hplnkViewPropertiesInTown" runat="server">
                    <asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a>
                </asp:HyperLink>
            </div>
        </div>
        <div class="row">
            <div class="">
                <div class="town-guide-hd">
                    <div class="col-md-12">
                        <h1>
                            <asp:Label ID="lblPageHeading" runat="server"></asp:Label></h1>
                    </div>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>
                        <asp:Literal ID="ltrlTopDescription" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>
        <!-- Detail one Strat -->

        <div class="divider">
            <img src="/images/divider.png" alt="plan" />
        </div>

        <!-- Quick information about Mollina  Start-->
        <div class="row">
            <div class="col-md-12">
                <div class="quick-information-about-mollina">
                    <h2>
                        <asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal>
                        <asp:Label ID="lblQuickHeading" runat="server"></asp:Label>:</h2>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png" alt="plan" />
                        <p>
                            <asp:Label ID="lblResidents" runat="server"></asp:Label>
                            <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                    <div class="map-pin-inner" id="divSchools" runat="server">
                        <img src="/images/school.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/car.png" alt="plan" />
                        <p>
                            <asp:Label ID="lblDistanceNearBy" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            <asp:Label ID="lblMalagaDistance" runat="server"></asp:Label>km
                            <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner" id="divHealthClinic" runat="server">
                        <img src="/images/hospital.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal6' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                    <div class="map-pin-inner" id="divMunicipalPool" runat="server">
                        <img src="/images/pool.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal7' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/Beach.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal>
                            <asp:Label ID="lblBeachDistance" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            <asp:Label ID="lblGranadaDistance" runat="server"></asp:Label>km
                            <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner" id="divShopBars" runat="server">
                        <img src="/images/shopping.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal10' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                    <div class="map-pin-inner" id="divGolfNearBy" runat="server">
                        <img src="/images/golf.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal11' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                    <div class="map-pin-inner" id="divBusTrainService" runat="server">
                        <img src="/images/bus.png" alt="plan" />
                        <p>
                            <asp:Literal ID='Literal13' Text='<%$Resources:Resource, BusTrainService %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan" />
                        <p>
                            <asp:Label ID="lblSevillaDistance" runat="server"></asp:Label>km
                            <asp:Literal ID='Literal14' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Quick information about Mollina End --->

        <div class="divider">
            <img src="/images/divider.png" alt="plan" />
        </div>

        <!--Properties for sale in Mollina -->

        <div class="row">
            <div class="col-md-12">
                <div class="monilla-loc">

                    <%-- google map --%>
                    <h2>
                        <asp:Literal ID="ltrMapHeading" runat="server"></asp:Literal>
                        <asp:Literal ID='Literal15' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h2>
                    <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <!--Properties for sale in Mollina -->
        <div class="divider">
            <img src="/images/divider.png" alt="plan" />
        </div>

        <!-- Location Information Start -->
        <%--<div class="row">
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
        </div>--%>
        <asp:Literal ID="ltrlLocationInformation" runat="server"></asp:Literal>
        <!-- Location Information End -->

        <div class="divider">
            <img src="/images/divider.png" alt="plan" />
        </div>
        <asp:Literal ID="ltrlMainInformation" runat="server"></asp:Literal>
        <!-- Detail Two Strat -->
        <%--        <div class="row">
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
                            <asp:Literal ID='Literal18' Text='<%$Resources:Resource, AlmedinillaDetail1 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal19' Text='<%$Resources:Resource, AlmedinillaDetail2 %>' runat='server'></asp:Literal>
                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/townguide/almedinilla/almedinilla2.jpg" alt="View of Almedinilla" />
                    </div>
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
                    <img class="img-bdr" src="/images/townguide/almedinilla/almedinilla3.jpg" alt="View of Almedinilla" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/almedinilla/almedinilla4.jpg" alt="Castle Almedinilla" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/almedinilla/almedinilla5.jpg" alt="astle View of Almedinilla" />
                </div>
            </div>
        </div>--%>
        <!-- Detail three Start -->


        <!-- Detail three Start -->

        <!-- Detail three Start -->
    </div>
    <!-- Detail three Start -->
</asp:Content>

