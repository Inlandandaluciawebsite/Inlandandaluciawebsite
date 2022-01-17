<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="AndaluciaAirports.aspx.vb" Inherits="AndaluciaAirports" %>

<%@ Register Src="~/Controls/WebUserControlTownGuid.ascx" TagPrefix="uc1" TagName="WebUserControlTownGuid" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main Content Area Start -->

    <!-- Left Portion Start -->
    <div class="col-md-8">
        <!-- View trip listing Start -->
        <div class="row">
            <div class="col-md-12">
                <div class="town-guide-hd">
                    <h1>
                        <asp:Literal ID="Literal2" Text="<%$Resources:Resource, theairportinandalucia %>" runat="server"></asp:Literal>
                    </h1>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="weather">
                </div>
            </div>
        </div>
        <!-- Detail one Strat -->

        <!-- Detail Two Strat -->

        <div class="row">
            <div class="airports-bg">
                <div class="col-md-3 col-sm-4"><a href="https://www.aena-aeropuertos.es/csee/Satellite/Aeropuerto-Malaga/en/Home.html" target="_blank">
                    <img class="img-bdr" src="/images/photos/malagaairportguide.jpg" alt="M&aacute;laga Airport Guide" title="M&aacute;laga Airport Guide"></a> </div>
                <div class="col-md-6 col-sm-8">
                    <h2><a href="https://www.aena-aeropuertos.es/csee/Satellite/Aeropuerto-Malaga/en/Home.html" target="_blank">M&aacute;laga <%=("Airport Guide")%></a></h2>
                    <p>
                        <asp:Literal ID="Literal1" Text="<%$Resources:Resource, AndaluciaAirportsinformation %>" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="airports-bg">
                <div class="col-md-3 col-sm-4"><a href="https://www.aena-aeropuertos.es/csee/Satellite/Aeropuerto-Federico-Garcia-Lorca-Granada-Jaen/en/Page/1056529998926/" target="_blank">
                    <img class="img-bdr" src="/images/photos/granadaairport.jpg" alt="Granada Airport Guide" title="Granada Airport Guide"></a> </div>
                <div class="col-md-6 col-sm-8">
                    <h2><a href="https://www.aena-aeropuertos.es/csee/Satellite/Aeropuerto-Federico-Garcia-Lorca-Granada-Jaen/en/Page/1056529998926/" target="_blank">Granada <%=("Airport Guide")%></a></h2>
                    <p>
                        <asp:Literal ID="Literal3" Text="<%$Resources:Resource, AndaluciaAirportsinformation %>" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="airports-bg">
                <div class="col-md-3 col-sm-4"><a href="https://www.aena-aeropuertos.es/csee/Satellite/Aeropuerto-Sevilla/en/Home.html" target="_blank">
                    <img class="img-bdr" src="/images/photos/sevillaairport.jpg" alt="Sevilla Airport Guide" title="Sevilla Airport Guide"></a> </div>
                <div class="col-md-6 col-sm-8">
                    <h2><a href="https://www.aena-aeropuertos.es/csee/Satellite/Aeropuerto-Sevilla/en/Home.html" target="_blank">Sevilla <%=("Airport Guide")%></a></h2>
                    <p>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, AndaluciaAirportsinformation %>" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="divider">
                    <img src="/images/divider.png"></div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="airports-bg-map ">
                    <img class="img-bdr" src="/images/AndaluciaMap.gif">
                    <h4>
                        <asp:Literal ID="Literal5" Text="<%$Resources:Resource, AndaluciaAirportsdetailed %>" runat="server"></asp:Literal></h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="divider">
                    <img src="/images/divider.png"></div>
            </div>
        </div>

        <!-- Airlines Start -->
        <div class="row">
            <div class="airlines-bg">
                <div class="col-md-12">
                    <h2>AIRLINES</h2>
                </div>
                <div class="col-md-6 col-sm-6">
                    <div class="row bdr-mob">
                        <div class="col-md-5 col-sm-5 col-xs-6"><a href="https://iberia.com" target="_blank">
                            <img class="img-bdr" src="/images/photos/airiberia.jpg" alt="iberia" title="iberia"></a></div>
                        <div class="col-md-7 col-sm-7 col-xs-6">
                            <h4>Iberia</h4>
                            <a href="https://iberia.com" target="_blank">iberia.com</a>
                        </div>
                    </div>
                    <div class="row bdr-mob">
                        <div class="col-md-5 col-sm-5 col-xs-6"><a href="https://easyjet.co.uk" target="_blank">
                            <img class="img-bdr" src="/images/photos/easyjet.jpg" alt="easyjet" title="easyjet"></a></div>
                        <div class="col-md-7 col-sm-7 col-xs-6">
                            <h4>Easyjet</h4>
                            <a href="https://easyjet.co.uk" target="_blank">easyjet.co.uk</a>

                        </div>
                    </div>
                    <div class="row bdr-mob">
                        <div class="col-md-5 col-sm-5 col-xs-6"><a href="https://thomsonfly.com" target="_blank">
                            <img class="img-bdr" src="/images/photos/thomsonfly.jpg" alt="thomsonfly" title="thomsonfly"></a></div>
                        <div class="col-md-7 col-sm-7 col-xs-6">
                            <h4>Thomsonfly</h4>
                            <a href="https://thomsonfly.com" target="_blank">thomsonfly.com</a>

                        </div>
                    </div>
                    <div class="row bdr-mob">
                        <div class="col-md-5 col-sm-5 col-xs-6"><a href="https://flybe.com" target="_blank">
                            <img class="img-bdr" src="/images/photos/flybe.jpg" alt="flybe" title="flybe"></a></div>
                        <div class="col-md-7 col-sm-7 col-xs-6">
                            <h4>Flybe</h4>
                            <a href="https://flybe.com" target="_blank">flybe.com</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-6">
                    <div class="row bdr-mob">
                        <div class="col-md-5 col-sm-5 col-xs-6"><a href="https://ba.com" target="_blank">
                            <img class="img-bdr" src="/images/photos/ba.jpg" alt="British Airways" title="British Airways"></a></div>
                        <div class="col-md-7 col-sm-7 col-xs-6">
                            <h4>British Airways</h4>
                            <a href="https://ba.com" target="_blank">ba.com</a>
                        </div>
                    </div>
                    <div class="row bdr-mob">
                        <div class="col-md-5 col-sm-5 col-xs-6">
                            <a href="https://ryanair.com" target="_blank">
                                <img class="img-bdr" src="/images/photos/ryan.jpg" alt="ryanair" title="ryanair"></a>
                        </div>
                        <div class="col-md-7 col-sm-7 col-xs-6">
                            <h4>Ryanair</h4>
                            <a href="https://ryanair.com" target="_blank">ryanair.com</a>
                        </div>
                    </div>
                    <div class="row bdr-mob">
                        <div class="col-md-5 col-sm-5 col-xs-6">
                            <a href="https://flymonarch.com" target="_blank">
                                <img class="img-bdr" src="/images/photos/monarch2.jpg" alt="monarch" title="monarch"></a>
                        </div>
                        <div class="col-md-7 col-sm-7 col-xs-6">
                            <h4>Monarch</h4>
                            <a href="https://flymonarch.com" target="_blank">flymonarch.com</a>

                        </div>
                    </div>
                    <div class="row bdr-mob">
                        <div class="col-md-5 col-sm-5 col-xs-6"><a href="https://clickair.com" target="_blank">
                            <img class="img-bdr" src="/images/photos/clickair.jpg" alt="clickair" title="clickair"></a></div>
                        <div class="col-md-7 col-sm-7 col-xs-6">
                            <h4>Clickair</h4>
                            <a href="https://clickair.com" target="_blank">clickair.com</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Airlines End -->

        <div class="row">
            <div class="col-md-12 ">
                <div class="divider">
                    <img src="/images/divider.png"></div>
            </div>
        </div>

        <!-- Check if Your Flight Start -->
        <div class="row">
            <div class="col-md-6 ">


                <iframe src="https://www.flightstats.com/go/FlightStatus/getFlightStatusWidget.do?guid=c228b59beca1b817:5a43e438:114a252da0d:-6a0"
                    width="280" height="240"></iframe>

            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <span><a href="https://www.flightstats.com/go/FlightStatus/flightStatusByRoute.do">
                    <asp:Literal ID="Literal7" Text="<%$Resources:Resource, AndaluciaAirportstrack%>" runat="server"></asp:Literal></a>
                    <asp:Literal ID="Literal8" Text="<%$Resources:Resource, AndaluciaAirportsmoreat%>" runat="server"></asp:Literal>
                </span>
                <span><a href="https://www.flightstats.com">www.flightstats.com</a></span>
            </div>
        </div>

        <!-- Check if Your Flight End -->

        <div class="row">
            <div class="col-md-12">
                <div class="divider">
                    <img src="/images/divider.png" alt="divider" /></div>
            </div>
        </div>

        <!-- Sorted By Provinance Start -->
        <div class="row">
            <div class="col-md-12">
                <div class="weather">
                    <p><strong>
                        <asp:Literal ID="Literal6" Text="<%$Resources:Resource, AndaluciaAirportslistbelow %>" runat="server"></asp:Literal>
                    </strong></p>
                </div>
            </div>
        </div>
        <uc1:WebUserControlTownGuid runat="server" ID="WebUserControlTownGuid" />
        <!-- Sorted by Provinance End -->

        <!-- Detail Two End -->

    </div>
    <!-- Left Portion End -->


    <!-- Main Content Area End -->
</asp:Content>

