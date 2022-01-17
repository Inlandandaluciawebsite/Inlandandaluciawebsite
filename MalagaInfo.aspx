<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="MalagaInfo.aspx.vb" Inherits="MalagaInfo" %>

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
                    <h1>Malaga</h1>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="malaga-info">
                    <%-- <p>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, MalegaInfoVisitour %>" runat="server"></asp:Literal>
                        <a href="TownLocationInfo.aspx" title="town guide">
                            <asp:Literal ID="Literal1" Text="<%$Resources:Resource, MalegaInfotownguide %>" runat="server"></asp:Literal>
                        </a>
                        <asp:Literal ID="Literal2" Text="<%$Resources:Resource, MalegaInfodetailed %>" runat="server"></asp:Literal>
                    </p>--%>
                    <p>
                        Inland Andalucia is collaborating with <a href="https://www.LuvInland.com" target="_blank">LuvInland.com</a> to give  you the best level of Information about Andalucia and its LIFESTYLE. For Each town we have 
                        properties for sale, click on the town name to get all the information you need. Luvinland will return you to us to view the properties for sale in the town selected.
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
            <div class="malaga-info">
                <div class="col-md-6 col-sm-6">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/malaga1.jpg" alt="plan" />
                    </div>
                </div>

                <div class="col-md-6 col-sm-6">
                    <div class="malaga-info">
                        <p>
                            <asp:Literal ID="Literal3" Text="<%$Resources:Resource, MalegaInfomalegais %>" runat="server"></asp:Literal>
                        </p>

                    </div>
                </div>

            </div>
        </div>


        <div class="row">
            <div class="malaga-info">
                <div class="col-md-12">

                    <p>
                        <asp:Literal ID="Literal5" Text="<%$Resources:Resource, MalegaInfoifyouclicmb %>" runat="server"></asp:Literal>
                    </p>

                </div>
            </div>
        </div>


        <div class="row">
            <div class="malaga-info">
                <div class="col-md-4 col-sm-4">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/malaga2.jpg" alt="plan" />
                    </div>
                </div>
                <div class="col-md-8 col-sm-8">
                    <div class="malaga-info">
                        <p>
                            <asp:Literal ID="Literal6" Text="<%$Resources:Resource, MalegaInfobirthplace %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>
        </div>



        <div class="row">
            <div class="malaga-info">

                <div class="col-md-8 col-sm-8">
                    <div class="malaga-info">
                        <p>
                            <asp:Literal ID="Literal7" Text="<%$Resources:Resource, MalegaInfomountains %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>

                <div class="col-md-4 col-sm-4">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/malaga5.jpg" alt="plan" />
                    </div>
                </div>
            </div>
        </div>





        <div class="row">
            <div class="malaga-info">

                <div class="col-md-4 col-sm-4">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/malaga3.jpg" alt="plan" />
                    </div>
                </div>


                <div class="col-md-8 col-sm-8">
                    <div class="malaga-info">
                        <p>
                            <asp:Literal ID="Literal8" Text="<%$Resources:Resource, MalegaInfointheheart %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>


            </div>
        </div>


        <div class="row">
            <div class="malaga-info">
                <div class="col-md-7 col-sm-7">
                    <div class="malaga-info">
                        <p>
                            <asp:Literal ID="Literal9" Text="<%$Resources:Resource, MalegaInfocarryingon %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>

                <div class="col-md-5 col-sm-5">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/malaga4.jpg" alt="plan" />
                    </div>
                </div>


            </div>
        </div>



        <!-- Detail Two End -->

    </div>
    <!-- Left Portion End -->


    <!-- Main Content Area End -->
</asp:Content>

