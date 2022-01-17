<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="albolote-granada.aspx.vb" Inherits="albolote_granada" %>

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
                        <h1>Albolote Andalucia</h1>
                    </div>
                    <div class="col-md-4"><a href="http://www.inlandandalucia.com/propsearch.aspx?page=1&regionid=2&areaid=18&subareaid=0&typeid=0&minimumbedrooms=0&minimumbathrooms=0&minimumprice=0&maximumprice=0&sort=price_asc">
                        <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>
                </div>
            </div>

        </div>
        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>
                        <asp:Literal ID='Literal1' Text='<%$Resources:Resource, AlboloteDetail %>' runat='server'></asp:Literal>
                    </p>
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
                        Albalote:</h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="map-pin">
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/residents.png">
                        <p>
                            18.083 (2013)<asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>

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
                            Antequera 99km
Malaga 124km
Granada 10km
Sevilla 247km
                        </p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            124km
                            <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>

                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="map-pin-inner">
                        <img src="/images/hospital.png">
                        <p>
                            <asp:Literal ID='Literal6' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>

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
                            45min
                  
                  <p>
                    </div>
                    <div class="map-pin-inner">
                        <img src="/images/pln.png">
                        <p>
                            10km
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
                            247km
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
                    <h3>Albolote
                        <asp:Literal ID='Literal14' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d12707.316987621522!2d-3.6497013!3d37.228028249999994!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd71fdfb37319747%3A0x9a125239dddd5c29!2sAlbolote%2C+Granada%2C+Spain!5e0!3m2!1sen!2suk!4v1411494711552" width="100" height="450" style="border: 0"></iframe>

                </div>
            </div>
        </div>

        <!--Properties for sale in Mollina -->
        <div class="divider">
            <img src="/images/divider.png" alt="test" /></div>

        <!-- Location Information Start -->
        <div class="row">
            <div class="location-info">
                <div class="col-md-6 col-sm-6">
                    <h4>
                        <asp:Literal ID='Literal15' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                    <div class="col-md-4 col-sm-4">

                        <img src="/images/townguide/albolote/albolote-coa.gif" alt="Albolote Coat of Arms"/>
                    </div>
                    <div class="col-md-8 col-sm-8">
                        <h5>Ayuntamiento de Albolote</h5>
                        <p>
                            Telephone: 958465115
Address: Plaza de España, 1
Albolote (Granada)
Postal code:18220
               
                        </p>
                        <p><strong>Email:</strong><a href="mailto:atencionalciudadano@albolote.com">atencionalciudadano@albolote.com</a></p>
                        <p><a href="http://www.albolote.org/" target="_blank">http://www.albolote.org</a></p>

                    </div>


                </div>
                <div class="col-md-6 col-sm-6">
                    <%-- <img class="img-bdr mrg-10t"  src="/images/photos/TownLocationInfo/villa_ayuntamiento.jpg" alt="Villanueva de Algaidas  town hall">--%>
                </div>
            </div>
        </div>

        <!-- Location Information End -->

        <div class="divider">
            <img src="/images/divider.png" alt="divider"/> </div>

        <!-- Detail Two Strat -->
        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12">
                    <h3>
                        <asp:Literal ID='Literal17' Text='<%$Resources:Resource, about %>' runat='server'></asp:Literal>
                        Albolote</h3>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <p>
                            <asp:Literal ID='Literal18' Text='<%$Resources:Resource, AlboloteDetail1 %>' runat='server'></asp:Literal></p>
                    </div>


                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/townguide/albolote/albolote1.jpg" alt="Albolote"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">

                        <p>
                            <asp:Literal ID='Literal19' Text='<%$Resources:Resource, AlboloteDetail2 %>' runat='server'></asp:Literal></p>

                    </div>


                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/townguide/albolote/albolote2.jpg" alt="Albolote"/>
                        <img class="img-bdr" src="/images/townguide/albolote/albolote3.jpg" alt="Albolote"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <p>
                            <asp:Literal ID='Literal22' Text='<%$Resources:Resource, AlboloteDetail3 %>' runat='server'></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID='Literal23' Text='<%$Resources:Resource, AlboloteDetail4 %>' runat='server'></asp:Literal></p>
                    </div>


                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/townguide/albolote/albolote4.jpg" alt="Albolote"/>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="mollina-information-dtl">
                <div class="col-md-8 col-sm-8">
                    <div class="mollina-information-dtl">
                        <p>
                            <asp:Literal ID='Literal20' Text='<%$Resources:Resource, AlboloteDetail5 %>' runat='server'></asp:Literal>
                        </p>
                        <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal21' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                    </div>


                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="mollina-information-dtl">
                        <img class="img-bdr" src="/images/townguide/albolote/albolote5.jpg" alt="Albolote"/>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Detail three Start -->
</asp:Content>

