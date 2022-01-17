<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="TownLocationInfo.aspx.vb" Inherits="TownLocationInfo" %>

<%@ Register Src="~/Controls/WebUserControlTownGuid.ascx" TagPrefix="uc1" TagName="WebUserControlTownGuid" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Banner Town Guide Start -->
    <div class="banner-town-guide">
        <div class="container">
            <div class="row white-bg">
                <div class="col-md-12">
                    <div class="banner-town-guide-inr">
                        <img src="/images/townguide.jpg">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Main Content Area Start -->

    <!-- Left Portion Start -->
    <div class="col-md-8">
        <!-- View trip listing Start -->
        <div class="row">
            <div class="col-md-12">
                <div class="town-guide-hd">
                    <h1>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, TownLocationInfocompleteGuide %>" runat="server"></asp:Literal></h1>
                     <p>
                        Inland Andalucia is collaborating with <a href="https://www.LuvInland.com" target="_blank">LuvInland.com</a> to give  you the best level of Information about Andalucia and its LIFESTYLE. For Each town we have 
                        properties for sale, click on the town name to get all the information you need. Luvinland will return you to us to view the properties for sale in the town selected.
                    </p>
                </div>
            </div>
        </div>


        <uc1:WebUserControlTownGuid runat="server" ID="WebUserControlTownGuid" />
        <!--Andalucia is unique -->

        <div class="row">
            <div class="col-md-8 col-sm-7">
                <h3>
                    <asp:Literal ID="Literal1" Text="<%$Resources:Resource, TownLocationInfoAndaluciaunique%>" runat="server"></asp:Literal>
                </h3>
                <p>
                    <asp:Literal ID="Literal2" Text="<%$Resources:Resource, TownLocationInfohunderedof%>" runat="server"></asp:Literal>
                </p>

                <p>
                    <asp:Literal ID="Literal3" Text="<%$Resources:Resource, TownLocationInfoCountless%>" runat="server"></asp:Literal>
                </p>

                <p>
                    <asp:Literal ID="Literal5" Text="<%$Resources:Resource, TownLocationInfoAreaaround%>" runat="server"></asp:Literal>
                </p>
                <p>
                    <asp:Literal ID="Literal6" Text="<%$Resources:Resource, TownLocationInfosmallvillage%>" runat="server"></asp:Literal>
                </p>
            </div>

            <div class="col-md-4 col-sm-5">
                <div class="andalucia-vill">
                    <div class="img-twn">
                        <img class="img-bdr" src="/images/VillageLocationInfo1.jpg">
                    </div>
                    <div class="img-twn">
                        <img class="img-bdr" src="/images/VillageLocationInfo2.jpg">
                    </div>
                    <div class="img-twn">
                        <img class="img-bdr" src="/images/VillageLocationInfo4.jpg">
                    </div>
                    <div class="img-twn">
                        <img class="img-bdr" src="/images/VillageLocationInfo3.jpg">
                    </div>
                </div>
            </div>
        </div>

        <!--Andalucia is unique -->


    </div>
    <!-- Left Portion End -->


</asp:Content>

