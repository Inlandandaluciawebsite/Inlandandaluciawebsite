<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="SevillaInfoNew.aspx.vb" Inherits="SevillaInfoNew" %>

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
                    <h1>Seville</h1>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="malaga-info">
                    <p>
                        <asp:Literal ID="Literal8" Text="<%$Resources:Resource, SevillaInfoVisitour %>" runat="server"></asp:Literal><a href="TownLocationInfo.aspx" title="town guide">
                            <asp:Literal ID="Literal1" Text="<%$Resources:Resource, SevillaInfotownguide %>" runat="server"></asp:Literal>
                        </a>
                        <asp:Literal ID="Literal2" Text="<%$Resources:Resource, SevillaInfodetailed %>" runat="server"></asp:Literal>
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
                <div class="col-md-4 col-sm-4">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/sevilla1.jpg">
                    </div>
                </div>

                <div class="col-md-8 col-sm-8">
                    <div class="malaga-info">
                        <p>
                            <asp:Literal ID="Literal3" Text="<%$Resources:Resource, SevillaInfothepopular %>" runat="server"></asp:Literal>
                        </p>

                    </div>
                </div>

            </div>
        </div>


        <div class="row">
            <div class="malaga-info">
                <div class="col-md-12">

                    <p>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, SevillaInfothearcitechure %>" runat="server"></asp:Literal>
                    </p>

                </div>
            </div>
        </div>


        <div class="row">
            <div class="malaga-info">
                <div class="col-md-4 col-sm-4">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/sevilla2.jpg">
                    </div>
                </div>
                <div class="col-md-8 col-sm-8">
                    <div class="malaga-info">
                        <p>
                            <asp:Literal ID="Literal5" Text="<%$Resources:Resource, SevillaInfotheplaza %>" runat="server"></asp:Literal>
                        </p>

                        <p>
                            <asp:Literal ID="Literal6" Text="<%$Resources:Resource, SevillaInfolacalle %>" runat="server"></asp:Literal>
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
                            <asp:Literal ID="Literal7" Text="<%$Resources:Resource, SevillaInfothecomerca %>" runat="server"></asp:Literal>
                        </p>

                        <p>
                            <asp:Literal ID="Literal9" Text="<%$Resources:Resource, SevillaInfoinapril %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>

                <div class="col-md-4 col-sm-4">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/sevilla3.jpg">
                    </div>
                </div>
            </div>
        </div>





        <div class="row">
            <div class="malaga-info">

                <div class="col-md-4 col-sm-4">
                    <div class="malaga-info">
                        <img class="img-bdr" src="/images/sevilla4.jpg">
                    </div>
                </div>


                <div class="col-md-8 col-sm-8">
                    <div class="malaga-info">
                        <p>
                            <asp:Literal ID="Literal10" Text="<%$Resources:Resource, SevillaInfoheadingeast %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>


            </div>
        </div>






        <!-- Detail Two End -->

    </div>
    <!-- Left Portion End -->



</asp:Content>

