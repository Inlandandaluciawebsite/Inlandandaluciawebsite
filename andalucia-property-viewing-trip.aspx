<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="andalucia-property-viewing-trip.aspx.vb" Inherits="andalucia_property_viewing_trip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main Content Area Start 
        <!-- Left Portion Start -->
    <div class="col-md-8">
        <!-- View trip listing Start -->
        <div class="row">
            <div class="col-md-12">
                <div class="view-trip-listing">
                    <h1>

                        <asp:Literal ID="lblwelcome" Text="<%$Resources:Resource, Viewingtrip %>" runat="server"></asp:Literal>
                    </h1>


                    <div class="view-trip-listing">
                        <h3>
                            <asp:Literal ID="Literal1" Text="<%$Resources:Resource, ViewingTrippersonalisedservice %>" runat="server"></asp:Literal>
                        </h3>
                        <ul>
                            <li>
                                <asp:Literal ID="Literal2" Text="<%$Resources:Resource, ViewingTripppriordesc %>" runat="server"></asp:Literal>

                            </li>

                            <li>
                                <asp:Literal ID="Literal3" Text="<%$Resources:Resource, ViewingTripflightsdesc %>" runat="server"></asp:Literal>

                            </li>

                            <li>
                                <asp:Literal ID="Literal4" Text="<%$Resources:Resource, ViewingTripcollectsdesc %>" runat="server"></asp:Literal>
                            </li>

                            <li>
                                <asp:Literal ID="Literal5" Text="<%$Resources:Resource, ViewingTripourteamdesc %>" runat="server"></asp:Literal>
                            </li>

                            <li>
                                <asp:Literal ID="Literal6" Text="<%$Resources:Resource, ViewingTripcomprehensivedesc %>" runat="server"></asp:Literal>
                            </li>
                            <li>
                                <asp:Literal ID="Literal7" Text="<%$Resources:Resource, ViewingTripAttheEnddesc %>" runat="server"></asp:Literal>
                            </li>




                        </ul>
                    </div>
                    <!-- View trip listing End -->


                    <!-- View trip  Cont Start -->
                    <div class="view-trip-cont-bg">
                        <div class="row">
                            <div class="col-md-12">
                                <!-- View trip left Cont Start -->
                                <div class="row">

                                    <div class="col-md-6 col-sm-6">
                                        <div class="granda-west">
                                            <%--   <h2>Granada (West), Malaga and Sevilla</h2>--%>
                                            <a href="bed-and-breakfast-mollina.aspx">
                                                <%--<img src="/images/specials/viewing-trip-mollina.jpg" alt="B&amp;B Mollina" /></a>--%>
                                                <img src="/images/specials/1.png" alt="" /></a>

                                            <%--  <h2>(+34) 952 741 525 Skype Me</h2>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <div class="granda-west">
                                            <%--   <h2>Granada (West), Malaga and Sevilla</h2>--%>
                                            <a href="casagrandealcala.aspx">
                                                <%--<img src="/images/specials/Alcala-la-Real.jpg" alt="B&amp;B Mollina" /></a>--%>
                                                <img src="/images/specials/2.png" alt="" /></a>
                                            <%--  <h2>(+34) 952 741 525 Skype Me</h2>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-6">
                                        <div class="granda-north">
                                            <%-- <h2>Cordoba, Granada (North) and Jaen</h2>--%>
                                            <a href="cosa_reguelo.aspx">
                                                <%--<img src="/images/Photos/BandB/viewing-trip-mollina.jpg" alt="Mollina, Fuente de Piedra and Humilladero" /></a>--%>
                                                <img src="/images/specials/5.png" alt="" /></a>
                                            <%--   <h2> (+34) 953 587 040 Skype Me</h2>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <div class="granda-north">
                                            <a href="bed-and-breakfast-ermita-nueva-new.aspx">
                                                <img src="/images/specials/3.png" alt="" /></a>
                                        </div>
                                    </div>
                                </div>
                               <%-- <div class="row">
                                    <div class="col-md-6 col-sm-6">
                                        <div class="granda-north">
                                            
                                            <a href="cosa_reguelo.aspx">
                                                
                                                <img src="/images/specials/5.png" alt="Mollina, Fuente de Piedra and Humilladero" /></a>
                                            
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <div class="granda-north">
                                        </div>
                                    </div>
                                </div>--%>
                                <!-- You Are In Safe Hand Start -->
                                <%-- <div class="row">
                                    <div class="col-md-12">
                                        <div class="you-are-in-safe-hand">
                                            <img src="/images/safe-hands.jpg" alt="You´re in safe hands">
                                        </div>
                                    </div>
                                </div>--%>
                                <!-- You Are In Safe Hand End -->
                                <!-- View trip left Cont Start -->
                            </div>
                        </div>
                    </div>
                    <!-- View trip  Cont End -->
                </div>
            </div>
        </div>
    </div>
    <!-- Left Portion Start -->



</asp:Content>

