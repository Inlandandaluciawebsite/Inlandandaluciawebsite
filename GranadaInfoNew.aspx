<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="GranadaInfoNew.aspx.vb" Inherits="GranadaInfoNew" %>

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
                    <h1>Granada</h1>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, GranadaInfoVisitour %>" runat="server"></asp:Literal>
                        <a href="TownLocationInfo.aspx" title="town guide">
                            <asp:Literal ID="Literal1" Text="<%$Resources:Resource, GranadaInfotownguide %>" runat="server"></asp:Literal>
                        </a>
                        <asp:Literal ID="Literal2" Text="<%$Resources:Resource, GranadaInfodetailed %>" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="listing-list-multi" style="display: block" id="listmenu" runat="server">
                    <div class="top-paggi">
                        <div id="navpropery" runat="server"></div>
                    </div>
                </div>
                <p>&nbsp;</p>
            </div>
        </div>
        <!-- Detail one Strat -->

        <!-- Detail Two Strat -->


        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-6 col-sm-6">
                    <div class="cordoba-img">
                        <img class="img-bdr" alt="granada" src="/images/granada1.jpg" />
                    </div>
                </div>

                <div class="col-md-6 col-sm-6">
                    <div class="cordoba-details-2-inner">
                        <p>
                            <asp:Literal ID="Literal3" Text="<%$Resources:Resource, GranadaInfoprovience %>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal5" Text="<%$Resources:Resource, GranadaInfocityof %>" runat="server"></asp:Literal>
                        </p>



                    </div>
                </div>

            </div>
        </div>


        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12 col-sm-12">
                    <p>
                        <asp:Literal ID="Literal6" Text="<%$Resources:Resource, GranadaInfoprovienceboasts %>" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>







        <div class="row">
            <div class="cordoba-details-2">

                <div class="col-md-8 col-sm-8">
                    <div class="cordoba-details-2-inner">
                        <p>
                            <asp:Literal ID="Literal7" Text="<%$Resources:Resource, GranadaInfothehill %>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal8" Text="<%$Resources:Resource, GranadaInfotheserieaa %>" runat="server"></asp:Literal>
                        </p>

                    </div>
                </div>


                <div class="col-md-4 col-sm-4">
                    <div class="cordoba-img">
                        <img class="img-bdr" src="/images/granada2.jpg" alt="granada2" />
                    </div>
                </div>

            </div>
        </div>


        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-4 col-sm-4">
                    <div class="cordoba-img">
                        <img class="img-bdr" src="/images/granada4.jpg" alt="granada4" />
                    </div>
                </div>

                <div class="col-md-8 col-sm-8">
                    <div class="cordoba-details-2-inner">
                        <h3>MONTEFRIO</h3>
                        <p>
                            <asp:Literal ID="Literal9" Text="<%$Resources:Resource, GranadaInfoheading %>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal10" Text="<%$Resources:Resource, GranadaInfotownitself %>" runat="server"></asp:Literal>
                            .
                        </p>



                    </div>
                </div>

            </div>
        </div>

        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12">
                    <h3>LOJA</h3>
                    <p>
                        <asp:Literal ID="Literal11" Text="<%$Resources:Resource, GranadaInfoanothertown %>" runat="server"></asp:Literal>
                    </p>

                    <p>
                        <asp:Literal ID="Literal12" Text="<%$Resources:Resource, GranadaInfojustshort %>" runat="server"></asp:Literal>
                    </p>

                    <h4><strong>
                        <asp:Literal ID="Literal13" Text="<%$Resources:Resource, GranadaInfowestgranada %>" runat="server"></asp:Literal>
                    </strong></h4>

                </div>
            </div>
        </div>
        <!-- Detail Two End -->

    </div>
    <!-- Left Portion End -->

    <!-- Right Portion Start -->

    <!-- Main Content Area End -->
</asp:Content>


