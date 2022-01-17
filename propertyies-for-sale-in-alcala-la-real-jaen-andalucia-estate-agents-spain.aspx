<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="propertyies-for-sale-in-alcala-la-real-jaen-andalucia-estate-agents-spain.aspx.vb" Inherits="guide_alcala_la_real" %>

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
                        <h1>Alcala la Real Jaen</h1>
                    </div>
                    <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=3&areaid=25&SubAreaId=0&sort=price_asc">
                        <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <%--<p>Almedinilla is a locality in the province of Cordoba, Andalusia, Spain. In the year 2005 there were 2.534 inhabitants. It is at an altitude of 622 meters and 114 kilometres to Cordoba capital.</p> --%>
                </div>
            </div>
        </div>
        <!-- Detail one Strat -->

        <div class="divider">
            <img src="/images/divider.png" alt="divider" /></div>

        <!-- Quick information about Mollina  Start-->
        <div class="row">
            <div class="col-md-12">
                <div class="quick-information-about-mollina">
                    <h3>
                        <asp:Literal ID='Literal1' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal>
                        Alcala La Real:</h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png" alt="resdident"/>
                        <p>
                            22.870 Residents
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/school.png" alt="school"/>
                        <p>
                            <asp:Literal ID='Literal2' Text='<%$Resources:Resource, schooluniversities %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/car.png" alt="car"/>
                        <p>
                            Antequera 112km
Malaga 158km
Granada 53km
Sevilla 219km
                  
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="pln"/>
                        <p>
                            158km  Malaga
                  
                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/hospital.png" alt="hospital"/>
                        <p>
                            <asp:Literal ID='Literal3' Text='<%$Resources:Resource, healthclinichospital %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pool.png" alt="pool"/>
                        <p>
                            <asp:Literal ID='Literal4' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/Beach.png" alt="beach"/>
                        <p>
                            1h45
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan"/>
                        <p>
                            53km  Granada
                  
                  <p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/shopping.png" alt="plan"/>
                        <p>
                            <asp:Literal ID='Literal5' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/golf.png" alt="plan"/>
                        <p>
                            <asp:Literal ID='Literal6' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/bus.png" alt="plan"/>
                        <p>
                            <asp:Literal ID='Literal7' Text='<%$Resources:Resource, busstation %>' runat='server'></asp:Literal>

                            <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" alt="plan"/>
                        <p>
                            219km Sevilla
                  
                  <p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Quick information about Mollina End --->

        <div class="divider">
            <img src="/images/divider.png" alt="plan"/></div>

        <!--Properties for sale in Mollina -->

        <div class="row">
            <div class="col-md-12">
                <div class="monilla-loc">

                    <%-- google map --%>
                    <h3>Almedinilla
                        <asp:Literal ID='Literal8' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
                    <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <!--Properties for sale in Mollina -->
        <div class="divider">
            <img src="/images/divider.png" alt="plan"/></div>

        <!-- Location Information Start -->
        <div class="row">
            <div class="location-info">
                <div class="col-md-6 col-sm-6">
                    <h4>
                        <asp:Literal ID='Literal9' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                    <img src="/images/townguide/alcala-la-real/coa-alcala.jpg" alt="Alcala de Real Coat of Arms"/>
                    <h5>Ayuntamiento de Alcala la Real</h5>
                    <p>
                        Plaza Arcipreste de Hita s/n
23680 Alcala la Real, Jaen
Telephone: 953 58 00 00
                     <p><a href="http://www.alcalalareal.es/" target="_blank">http://www.alcalalareal.es/</a></p>
                    </p>

                </div>
                <div class="col-md-6 col-sm-6">
                    <img class="img-bdr mrg-10t" src="/images/townguide/alcala-la-real/alcala1.jpg" alt="Alcala la Real"/>
                </div>
            </div>
        </div>

        <!-- Location Information End -->

        <div class="divider">
            <img src="/images/divider.png"/></div>

        <!-- Detail Two Strat -->
        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12">
                    <h3>Alcala la Real
                        <asp:Literal ID='Literal10' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <p>
                            <asp:Literal ID='Literal11' Text='<%$Resources:Resource, guidealcalaDetail1 %>' runat='server'></asp:Literal></p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/townguide/alcala-la-real/alcala2.jpg" alt="View of Alcala la Real"/></div>
                </div>
            </div>
        </div>

        <!-- Detail Two End -->
        <!-- Detail three Start -->
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <b>La Mota Castle</b>
                    <p>
                        <asp:Literal ID='Literal12' Text='<%$Resources:Resource, guidealcalaDetail1 %>' runat='server'></asp:Literal></p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/alcala-la-real/alcala3.jpg" alt="View of Alcala la Real"/></div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <b>
                        <asp:Literal ID='Literal13' Text='<%$Resources:Resource, localfesivals %>' runat='server'></asp:Literal></b>
                    <p>
                        <asp:Literal ID='Literal14' Text='<%$Resources:Resource, guidealcalaDetail2 %>' runat='server'></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID='Literal15' Text='<%$Resources:Resource, guidealcalaDetail3 %>' runat='server'></asp:Literal></p>
                    <p>
                        <asp:Literal ID='Literal17' Text='<%$Resources:Resource, guidealcalaDetail4 %>' runat='server'></asp:Literal></p>
                    <p>
                        <asp:Literal ID='Literal18' Text='<%$Resources:Resource, guidealcalaDetail5 %>' runat='server'></asp:Literal></p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/alcala-la-real/alcala4.jpg" alt="Castle Alcala la Real"/></div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">

                <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal19' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <img class="img-bdr" src="/images/townguide/alcala-la-real/alcala5.jpg" alt="astle View of Alcala la Real"/></div>
            </div>
        </div>
        <!-- Detail three Start -->


        <!-- Detail three Start -->

        <!-- Detail three Start -->
    </div>
    <!-- Detail three Start -->
</asp:Content>

