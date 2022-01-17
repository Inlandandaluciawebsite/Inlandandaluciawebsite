<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="ContactOffices.aspx.vb" Inherits="ContactOffices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" href="http://weatherandtime.net/new_wid/w_2/style.css" type="text/css" media="screen" />--%>
    <%--    <script src="https://apis.google.com/js/platform.js" async defer>
  {lang: 'en-GB'}
    </script>--%>
    <style>
        .monilla-off img {
            max-width: 100%;
            min-height: 126px;
            object-fit: cover;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="fb-root"></div>
    <script>(function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.0";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));</script>
    <!-- Left Portion Start -->
    <div class="col-md-8">
        <!-- Contact Page Start -->
        <div class="row">
            <div class="col-md-12">
                <div class="town-guide-hd">
                    <h1>
                        <asp:Literal ID="Literal13" Text="<%$Resources:Resource, ContactOfficesOur%>" runat="server"></asp:Literal></h1>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="contact-bg">
                    <p>
                        <asp:Literal ID="Literal1" Text="<%$Resources:Resource, ContactOfficesfeelfree%>" runat="server"></asp:Literal>
                        <a href="contactus.aspx">
                            <asp:Literal ID="Literal2" Text="<%$Resources:Resource, ContactOfficesClickhere%>" runat="server"></asp:Literal>
                        </a>
                    </p>
                    <div class="divider">
                        <img src="/images/divider.png" />
                    </div>
                    <!-- Our Head Offices Start -->
                    <!-- Mollina Offices Start -->
                    <div class="row">
                        <div class="our-head-offices">
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/mollina.jpg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <h2>
                                        <asp:Literal ID="Literal3" Text="<%$Resources:Resource, ContactOfficesmollinaoffice%>" runat="server"></asp:Literal></h2>
                                    <p>
                                        Calle de la Villa, 14 
                          29532 Mollina (Málaga)
                                    </p>
                                    <p>Tel: (0034) 952 741 525</p>
                                    <p>Fax: (0034) 952 74 02 19 </p>
                                    <a href="mailto:info@inlandandalucia.com ">info@inlandandalucia.com</a>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/mollina-office1.jpg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/mollina1.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Mollina Offices End -->
                    <!-- Alcala  Offices Start -->
                    <div class="row">
                        <div class="our-head-offices">
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/alcala-office.jpg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <h2>
                                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, ContactOfficesAlcalaoffice%>" runat="server"></asp:Literal></h2>
                                    <p>
                                        Calle Abad Moya 4 bajo, 
23680 Alcalá la Real (Jaén)
                                    </p>
                                    <p>Tel: (0034) 953 587 040</p>
                                    <%--           <p>Fax: (0034) 952 74 02 19 </p>--%>
                                    <a href="mailto:info@inlandandalucia.com">info@inlandandalucia.com</a>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/Alcala1.JPG" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/alcala-office-1.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Alcala  Offices End -->

                    <!-- Axarquia  Offices Start -->
<%--                    <div class="row">
                        <div class="our-head-offices">
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/Images/Axarquia.jpg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <h2>
                                        <asp:Literal ID="Literal6" Text="Axarquia Office" runat="server"></asp:Literal></h2>
                                    <p>
                                        Cruce Puente Don Manuel 4, Edificio Al Zabel, Alcaucin, 29713, Málaga
                                    </p>
                                    <p>Tel: (0034) 952 519 718</p>
                                    <a href="mailto:info@inlandandalucia.com ">info@inlandandalucia.com</a>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/Axarquia_1.JPG" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/Axarquia_2.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <!-- Axarquia  Offices End -->
                    <!-- Martos  Offices Start -->
                    <div class="row">
                        <div class="our-head-offices">
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/Images/Martos.png" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <h2>
                                        <asp:Literal ID="Literal7" Text="Martos Office" runat="server"></asp:Literal></h2>
                                    <p>
                                        Calle Lope de Vega, 6, 23600 Martos (Jaén)
                                    </p>
                                    <p>Tel: (0034) 953 704 319</p>
                                    <%--           <p>Fax: (0034) 952 74 02 19 </p>--%>
                                    <a href="mailto:info@inlandandalucia.com ">info@inlandandalucia.com</a>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/Martos_1.jpeg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/images/Martos_2.jpeg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Martos  Offices End -->
                    <!-- Lucena  Offices Start -->
                    <div class="row">
                        <div class="our-head-offices">
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/Images/Lucenamain.jpg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <h2>
                                        <asp:Literal ID="Literal8" Text="Lucena Office" runat="server"></asp:Literal></h2>
                                    <p>
                                        Calle Juan Garcia de Palma 2, 14900 Lucena (Cordoba)
                                    </p>
                                    <p>Tel: 0034 681 683 477</p>
                                    <a href="mailto:info@inlandandalucia.com ">info@inlandandalucia.com</a>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/Images/Lucena2.jpg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/Images/Lucena3.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Lucena  Offices End -->
                    <!-- Osuna  Offices Start -->
<%--                    <div class="row">
                        <div class="our-head-offices">
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/Images/Osunamain.jpg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <h2>
                                        <asp:Literal ID="Literal9" Text="Osuna Office" runat="server"></asp:Literal></h2>
                                    <p>
                                        C.C. Conyper, Local 14, 41640 Osuna (Sevilla)
                                    </p>
                                    <p>Tel : 0034 675 787 627</p>
                                    <a href="mailto:info@inlandandalucia.com ">info@inlandandalucia.com</a>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/Images/Osuna2.jpg" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="monilla-off">
                                    <img class="img-bdr" src="/Images/Osuna3.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <!-- Osuna  Offices End -->
                    <!-- Our Head Offices End -->
                </div>
                <div class="divider">
                    <img src="/images/divider.png" />
                </div>
                <!-- iqr code start -->
                <div class="row">
                    <div class="iqr-code-bg">
                        <div class="col-md-12">
                            <p>
                                <asp:Literal ID="Literal5" Text="<%$Resources:Resource, ContactOfficesScanbelow%>" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="col-md-2 col-sm-4">
                            <div class="qr-monilla">
                                <img src="/images/qr_inlandandalucia_mollina.png" />
                                <h3>Mollina Office</h3>
                            </div>
                        </div>
                        <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_jaen.png" />
                                <h3>Alcala La Real Office</h3>
                            </div>
                        </div>
                       <%-- <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_axarquia.png" />
                                <h3>Axarquia Office</h3>
                            </div>
                        </div>--%>
                        <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_martos.png" />
                                <h3>Martos Office</h3>
                            </div>
                        </div>
                        <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_lucena.jpg" />
                                <h3>Lucena Office</h3>
                            </div>
                        </div>
                       <%-- <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_osuna.jpg" />
                                <h3>Osuna Office</h3>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <!-- iqr code start -->
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <div class="g-page" data-href="//plus.google.com/u/0/111046084239890082041" data-rel="publisher"></div>
                        <div class="fb-like-box" data-href="https://www.facebook.com/inlandandaluciahomes" data-width="300" data-height="326" data-colorscheme="light" data-show-faces="true" data-header="true" data-stream="false" data-show-border="true"></div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Contact Page Start -->
    </div>
    <!-- Left Portion End -->
</asp:Content>

