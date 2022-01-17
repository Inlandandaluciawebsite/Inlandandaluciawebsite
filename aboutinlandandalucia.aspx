<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="aboutinlandandalucia.aspx.vb" Inherits="aboutinlandandalucia" %>

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
                        <asp:Literal ID="Literal3" Text="<%$Resources:Resource, aboutinlandandalkuciawelcome %>" runat="server"></asp:Literal></h1>
                </div>
            </div>
        </div>


        <!-- Detail Two Strat -->


        <div class="row">
            <div class="about-andalucia">
                <div class="col-md-6 col-sm-6">
                    <div class="about-andalucia"><a href="ContactOffices.aspx">
                        <img class="img-bdr" src="/images/inland-redesign-2.jpg" title="Click here to view Our offices" alt="Andalucia" /></a></div>
                </div>
                <div class="col-md-6 col-sm-6">
                    <div class="about-andalucia">
                        <h1>
                            <asp:Literal ID="Literal1" Text="<%$Resources:Resource, aboutinlandandaluciaDetai1 %>" runat="server"></asp:Literal></h1>

                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="about-andalucia">
                <div class="col-md-12 col-sm-12">
                    <h3>
                        <asp:Literal ID="Literal2" Text="<%$Resources:Resource, aboutinlandandaluciaDetai2 %>" runat="server"></asp:Literal></h3>
                    <p>
                        <asp:Literal ID="Literal4" Text="<%$Resources:Resource, aboutinlandandaluciaDetai3 %>" runat="server"></asp:Literal></p>
                    <p>
                        <asp:Literal ID="Literal5" Text="<%$Resources:Resource, aboutinlandandaluciaDetai4 %>" runat="server"></asp:Literal></p>
                    <p>
                        <asp:Literal ID="Literal6" Text="<%$Resources:Resource, aboutinlandandaluciaDetai5 %>" runat="server"></asp:Literal></p>
                    <p>
                        <asp:Literal ID="Literal7" Text="<%$Resources:Resource, aboutinlandandaluciaDetai6 %>" runat="server"></asp:Literal></p>
                </div>
            </div>
        </div>


        <!-- Detail Two End -->


        <div class="row">
            <div class="col-md-12">
                <div class="divider">
                    <img src="/images/divider.png" alt="divider" /></div>
            </div>
        </div>


        <!-- Sorted By Provinance Start -->
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="list-town-g">
                    <h4>
                        <asp:Literal ID="Literal8" Text="<%$Resources:Resource, aboutinlandandaluciaDetai7 %>" runat="server"></asp:Literal></h4>

                </div>
            </div>

        </div>
        <uc1:WebUserControlTownGuid runat="server" ID="WebUserControlTownGuid" />
        <!-- Sorted by Provinance End -->



    </div>
    <!-- Left Portion End -->


    <!-- Main Content Area End -->
</asp:Content>

