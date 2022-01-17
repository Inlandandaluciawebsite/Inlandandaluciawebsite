<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="JaenInfoNew.aspx.vb" Inherits="JaenInfoNew" %>

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
                    <h1>Jaen</h1>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="jaen-info">
                    <p>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, JaenInfoVisitour %>" runat="server"></asp:Literal>
                        <a href="TownLocationInfo.aspx" title="town guide">
                            <asp:Literal ID="Literal1" Text="<%$Resources:Resource, JaenInfotownguide %>" runat="server"></asp:Literal>
                        </a>
                        <asp:Literal ID="Literal2" Text="<%$Resources:Resource, JaenInfodetailed %>" runat="server"></asp:Literal>
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
            <div class="jaen-info">
                <div class="col-md-5 col-sm-5">
                    <div class="jaen-info">
                        <img class="img-bdr" src="/images/jaen1.jpg" alt="plan" /></div>
                </div>

                <div class="col-md-7 col-sm-7">
                    <div class="jaen-info">
                        <p>
                            <asp:Literal ID="Literal3" Text="<%$Resources:Resource, JaenInfoprovience %>" runat="server"></asp:Literal>
                        </p>

                        <p>
                            <asp:Literal ID="Literal5" Text="<%$Resources:Resource, JaenInfocityof %>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal6" Text="<%$Resources:Resource, JaenInfocenterof %>" runat="server"></asp:Literal>
                        </p>

                    </div>
                </div>

            </div>
        </div>


        <div class="row">
            <div class="jaen-info">
                <div class="col-md-12">
                    <h3>
                        <asp:Literal ID="Literal7" Text="<%$Resources:Resource, JaenInfothecatherdal %>" runat="server"></asp:Literal>
                    </h3>
                    <p>
                        <asp:Literal ID="Literal8" Text="<%$Resources:Resource, JaenInfojaencatherdal %>" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="jaen-info">
                <div class="col-md-7 col-md-7">
                    <div class="jaen-info">
                        <h3>
                            <asp:Literal ID="Literal9" Text="<%$Resources:Resource, JaenInfosaintcastle %>" runat="server"></asp:Literal>
                        </h3>
                        <p>
                            <asp:Literal ID="Literal10" Text="<%$Resources:Resource, JaenInfosaintcastledesc %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>

                <div class="col-md-5 col-sm-5">
                    <div class="jaen-info">
                        <img class="img-bdr" src="/images/jaen2.jpg" alt="plan" /></div>
                </div>



            </div>
        </div>


        <!-- Detail Two End -->

    </div>
    <!-- Left Portion End -->

    <!-- Right Portion Start -->

    <!-- Main Content Area End -->
</asp:Content>

