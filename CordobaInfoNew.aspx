<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="CordobaInfoNew.aspx.vb" Inherits="CordobaInfo" %>

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
                    <h1>Cordoba</h1>
                </div>
            </div>
        </div>

        <!-- Detail one Strat -->
        <div class="row">
            <div class="col-md-12">
                <div class="cordoba-details">
                    <p>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, CordobaInfoVisitour %>" runat="server"></asp:Literal>
                        <a href="TownLocationInfo.aspx" title="town guide">
                            <asp:Literal ID="Literal1" Text="<%$Resources:Resource, CordobaInfotownguide  %>" runat="server"></asp:Literal>
                        </a>
                        <asp:Literal ID="Literal3" Text="<%$Resources:Resource, CordobaInfodetailedInfo  %>" runat="server"></asp:Literal>
                    </p>
                    <div class="listing-list-multi" style="display: block" id="listmenu" runat="server">
                        <div class="top-paggi">
                            <div id="navpropery" runat="server"></div>
                        </div>
                    </div>
                    <p>&nbsp;</p>
                    <img class="img-bdr" src="/images/cordoba1.jpg">
                </div>
            </div>
        </div>
        <!-- Detail one Strat -->

        <!-- Detail Two Strat -->

        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12">
                    <p>
                        <asp:Literal ID="Literal5" Text="<%$Resources:Resource, CordobaInfoJewishQuarter %>" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-8 col-sm-8">
                    <div class="cordoba-details-2-inner">
                        <p>
                            <asp:Literal ID="Literal6" Text="<%$Resources:Resource, CordobaInfoAcross %>" runat="server"></asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="Literal7" Text="<%$Resources:Resource, CordobaInfoCity %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="cordoba-img">
                        <img class="img-bdr" src="/images/cordoba2.jpg">
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-6 col-sm-6">
                    <div class="cordoba-img">
                        <img class="img-bdr" src="/images/cordoba3.jpg">
                    </div>
                </div>
                <div class="col-md-6 col-md-6">
                    <div class="cordoba-details-2-inner">
                        <p>
                            <asp:Literal ID="Literal8" Text="<%$Resources:Resource, CordobaInfoCordobaenjoys %>" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="cordoba-details-2">
                <div class="col-md-12">
                    <p>
                        <asp:Literal ID="Literal9" Text="<%$Resources:Resource, CordobaInfoAsyoumind %>" runat="server"></asp:Literal>
                        .
                    </p>
                </div>
            </div>
        </div>
        <!-- Detail Two End -->

    </div>
    <!-- Left Portion End -->


    <!-- Main Content Area End -->
</asp:Content>


