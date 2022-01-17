<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Spanish-inland-fincas-properties-for-sale-antequera-malaga-spain.aspx.vb" Inherits="AntequeraLocationInfo" %>

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
                        <h1>Antequera in Andalucia</h1>
                    </div>
                    <div class="col-md-4">
                        <a href="propsearch.aspx?page=1&regionid=4&areaid=74&SubAreaId=0&sort=price_asc">
                            <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a>
                    </div>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>
                        <asp:Literal ID='Literal1' Text='<%$Resources:Resource, Antehistoricals %>' runat='server'></asp:Literal> Andaluc&iacute;an
                    </p>
                </div>
            </div>
            <!-- Detail one Strat -->
        </div>
        <div class="divider">
            <img src="/images/divider.png" />
        </div>

        <!-- Quick information about Mollina  Start-->
        <div class="row">
            <div class="col-md-12">
                <div class="quick-information-about-mollina">
                    <h3>
                        <asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationAbout %>' runat='server'></asp:Literal>
                        Antequera:</h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png" />
                        <p>
                            5.500
                            <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/school.png" />
                        <p>
                            <asp:Literal ID='Literal4' Text='<%$Resources:Resource, schooluniversities %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" />
                        <p>
                            Granada 100km
Sevilla 160km
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" />
                        <p>
                            52km
                            <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/hospital.png" />
                        <p>
                            <asp:Literal ID='Literal6' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pool.png" />
                        <p>
                            <asp:Literal ID='Literal7' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/Beach.png" />
                        <p>
                            <asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal>
                            1h
                  
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" />
                        <p>
                            100km
                            <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/shopping.png" />
                        <p>
                            <asp:Literal ID='Literal10' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/golf.png" />
                        <p>
                            <asp:Literal ID='Literal11' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/bus.png" />
                        <p>
                            <asp:Literal ID='Literal12' Text='<%$Resources:Resource, busservice %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png" />
                        <p>
                            160Km
                            <asp:Literal ID='Literal13' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Quick information about Mollina End --->

        <div class="divider">
            <img src="/images/divider.png" />
        </div>

        <!--Properties for sale in Mollina -->

        <div class="row">
            <div class="col-md-12">
                <div class="monilla-loc">

                    <%-- google map --%>
                    <h3>Antequera
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
            <img src="/images/divider.png" />
        </div>

        <!-- Location Information Start -->
        <div class="row">
            <div class="location-info">
                <div class="col-md-6 col-sm-6">
                    <h4>
                        <asp:Literal ID='Literal15' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                    <img src="/images/photos/TownLocationInfo/antequera_coa.jpg" alt="Antequera Coat of Arms" />
                    <h5>Ayuntamiento de Antequera</h5>
                    <p>
                        C/Infante Don Fernando, 70
29200 Antequera, M&aacute;laga
Telephone: 952-708-100


                   
                    </p>
                    <p>
                        <a href="http://www.antequera.es/" title="http://www.antequera.es/" target="_blank">http://www.antequera.es/</a>
                    </p>



                </div>
                <div class="col-md-6 col-sm-6">
                    <img class="img-bdr mrg-10t" src="/images/photos/TownLocationInfo/antequera_ayuntamiento.jpg" alt="Town Hall, Antequera" />
                </div>
            </div>
        </div>

        <!-- Location Information End -->

        <div class="divider">
            <img src="/images/divider.png" />
        </div>

        <!-- Detail Two Strat -->
        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12">
                    <h3>Antequera
                        <asp:Literal ID='Literal17' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <%--  <p>
                            <asp:Literal ID='Literal18' Text='<%$Resources:Resource, Antequerainformation %>' runat='server'></asp:Literal>
                        </p>--%>

                        <p>
                            <asp:Literal ID='Literal19' Text='<%$Resources:Resource, Antequerainformation1 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal20' Text='<%$Resources:Resource, Antequerainformation2 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal21' Text='<%$Resources:Resource, Antequerainformation3 %>' runat='server'></asp:Literal>La Pe&ntilde;a de los Enamorados,<asp:Literal ID='Literal28' Text='<%$Resources:Resource, Antequerainformation10 %>' runat='server'></asp:Literal>&quot;<asp:Literal ID='Literal29' Text='<%$Resources:Resource, Antequerainformation11 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal22' Text='<%$Resources:Resource, Antequerainformation4 %>' runat='server'></asp:Literal>Cueva de la Menga.<asp:Literal ID='Literal30' Text='<%$Resources:Resource, Antequerainformation12 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal23' Text='<%$Resources:Resource, Antequerainformation5 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal24' Text='<%$Resources:Resource, Antequerainformation6 %>' runat='server'></asp:Literal>
                            Andaluc&iacute;a, 
                            <asp:Literal ID='Literal18' Text='<%$Resources:Resource, Antequerainformation34 %>' runat='server'></asp:Literal>Cueva de la Menga. 
                                            <asp:Literal ID='Literal27' Text='<%$Resources:Resource, Antequerainformation35 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal25' Text='<%$Resources:Resource, Antequerainformation7 %>' runat='server'></asp:Literal>
                            Santa Mar&iacute;a la Mayor Church, 
                                                   <asp:Literal ID='Literal51' Text='<%$Resources:Resource, Antequerainformation36 %>' runat='server'></asp:Literal>
                            Nuestra Se&ntilde;ora del Carmen, 
                                                                <asp:Literal ID='Literal52' Text='<%$Resources:Resource, Antequerainformation37 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal26' Text='<%$Resources:Resource, Antequerainformation8 %>' runat='server'></asp:Literal>Convento de las Descalzas,<asp:Literal ID='Literal31' Text='<%$Resources:Resource, Antequerainformation13 %>' runat='server'></asp:Literal>
                            &quot;S&iacute;&quot;,<asp:Literal ID='Literal32' Text='<%$Resources:Resource, Antequerainformation14 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            El Torcal
                            <asp:Literal ID='Literal33' Text='<%$Resources:Resource, Antequerainformation16 %>' runat='server'></asp:Literal>. El Torcal
                        <asp:Literal ID='Literal41' Text='<%$Resources:Resource, Antequerainformation17 %>' runat='server'></asp:Literal>
                            M&aacute;laga
                                                    <asp:Literal ID='Literal42' Text='<%$Resources:Resource, Antequerainformation18 %>' runat='server'></asp:Literal>Villanueva de la Concepci&oacute;n. 
                      
                                                    <asp:Literal ID='Literal43' Text='<%$Resources:Resource, Antequerainformation19 %>' runat='server'></asp:Literal>
                            El Torcal 
                             <asp:Literal ID='Literal44' Text='<%$Resources:Resource, Antequerainformation20 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal34' Text='<%$Resources:Resource, Antequerainformation21 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal35' Text='<%$Resources:Resource, Antequerainformation22 %>' runat='server'></asp:Literal>Villanueva de la Concepci&oacute;n 
                              <asp:Literal ID='Literal45' Text='<%$Resources:Resource, Antequerainformation23 %>' runat='server'></asp:Literal>El Torcal
                                       <asp:Literal ID='Literal46' Text='<%$Resources:Resource, Antequerainformation24 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal36' Text='<%$Resources:Resource, Antequerainformation25 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal37' Text='<%$Resources:Resource, Antequerainformation26 %>' runat='server'></asp:Literal>&quot;Las Ventanillas&quot; 
                                                     <asp:Literal ID='Literal47' Text='<%$Resources:Resource, Antequerainformation27 %>' runat='server'></asp:Literal>
                            M&aacute;laga
                              <asp:Literal ID='Literal48' Text='<%$Resources:Resource, Antequerainformation28 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal38' Text='<%$Resources:Resource, Antequerainformation29 %>' runat='server'></asp:Literal>
                            El Torcal
                                                   <asp:Literal ID='Literal49' Text='<%$Resources:Resource, Antequerainformation30 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal39' Text='<%$Resources:Resource, Antequerainformation31 %>' runat='server'></asp:Literal>. El Torcal de Antequera - 
                                                        <asp:Literal ID='Literal50' Text='<%$Resources:Resource, Antequerainformation32 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            &raquo;&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia">
                                <asp:Literal ID='Literal40' Text='<%$Resources:Resource, Antequerainformation33 %>' runat='server'></asp:Literal></a>
                        </p>
                        <%--<p>»&nbsp;<asp:Literal ID='Literal27' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal>
                        </p>--%>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera2.jpg" alt="Antequera Andalucia town" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera7.jpg" alt="Antequera Andalucia El Torcal" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/sunflower1.jpg" alt="Antequera Andalucia sunflowers" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera3.jpg" alt="Antequera Andalucia caves" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera1.jpg" alt="Antequera Andalucia town" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera4.jpg" alt="Antequera Andalucia church" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera5.jpg" alt="Antequera Andalucia El Torcal" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera6.jpg" alt="Antequera Andalucia El Torcal" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera7.jpg" alt="Antequera Andalucia El Torcal" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera8.jpg" alt="Antequera Andalucia El Torcal" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera9.jpg" alt="Antequera Andalucia caves" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera10.jpg" alt="Antequera Andalucia ruin" />
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/antequera11.jpg" alt="Antequera Andalucia Mountain" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Detail Two End -->
        <!-- Detail three Start -->


        <!-- Detail three Start -->

        <!-- Detail three Start -->
    </div>
    <!-- Detail three Start -->
</asp:Content>

