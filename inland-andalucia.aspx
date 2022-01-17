<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="inland-andalucia.aspx.vb" Inherits="inland_andalucia" %>

<%@ Register Src="~/Controls/WebUserControlTownGuid.ascx" TagPrefix="uc1" TagName="WebUserControlTownGuid" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Main Content Area Start -->

        <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
          <div class="row">
            <div class="col-md-12">
              <div class="town-guide-hd">
                <h1><asp:Literal ID="Literal9" Text="<%$Resources:Resource, InlandAndaluciaandalucia %>" runat="server"></asp:Literal></h1>
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="about-andalucia">
                <p><asp:Literal ID="Literal1" Text="<%$Resources:Resource, InlandAndaluciaregion%>" runat="server"></asp:Literal></p>
              </div>
            </div>
          </div>
          <!-- Detail one Strat --> 
          
          <!-- Detail Two Strat -->
          
          <div class="row">
            <div class="about-andalucia">
              <div class="col-md-4 col-sm-4">
                <div class="about-andalucia">
                  <ul>
                    <li><i class="fa fa-arrow-right"></i><a href="#">Almería</a></li>
                    <li><i class="fa fa-arrow-right"></i><a href="#">Cádiz</a></li>
                    <li><i class="fa fa-arrow-right"></i><a href="CordobaInfo.aspx" title=" C&oacute;rdoba"> C&oacute;rdoba</a></li>
                    <li><i class="fa fa-arrow-right"></i><a href="GranadaInfo.aspx" title=" Granada"> Granada</a></li>
                    <li><i class="fa fa-arrow-right"></i><a href="#">Huelva</a></li>
                    <li><i class="fa fa-arrow-right"></i><a href="JaenInfo.aspx" title=" Ja&eacute;n"> Ja&eacute;n</a></li>
                    <li><i class="fa fa-arrow-right"></i><a href="MalagaInfo.aspx" title="M&aacute;laga">M&aacute;laga</a></li>
                    <li><i class="fa fa-arrow-right"></i><a href="SevillaInfo.aspx" title="Sevilla">Sevilla</a></li>
                  </ul>
                </div>
              </div>
              <div class="col-md-8 col-sm-8">
                <div class="about-andalucia flt-rt"><img class="img-bdr" src="/images/AndaluciaOutlineMap.gif" alt="plan"/></div>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="about-andalucia">
              <div class="col-md-4 col-sm-4">
                <div class="about-andalucia"><img class="img-bdr" src="/images/inland_Andalucia1.jpg" alt="plan"/></div>
              </div>
              <div class="col-md-8 col-sm-8">
                <div class="about-andalucia">
                  <p><asp:Literal ID="Literal2" Text="<%$Resources:Resource, InlandAndaluciawithclimate %>" runat="server"></asp:Literal> </p>
                </div>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="about-andalucia">
              <div class="col-md-12 col-sm-12">
                <p><asp:Literal ID="Literal3" Text="<%$Resources:Resource, InlandAndalucialasubbetica %>" runat="server"></asp:Literal></p>
                <p><asp:Literal ID="Literal4" Text="<%$Resources:Resource, InlandAndalucialandrugged%>" runat="server"></asp:Literal></p>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="about-andalucia">
              <div class="col-md-8 col-sm-8">
                <div class="about-andalucia">
                  <p><asp:Literal ID="Literal5" Text="<%$Resources:Resource, InlandAndaluciaheartland%>" runat="server"></asp:Literal></p>
                  <p><asp:Literal ID="Literal6" Text="<%$Resources:Resource, InlandAndaluciabutitsnot %>" runat="server"></asp:Literal></p>
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="about-andalucia"><img class="img-bdr" src="/images/inland_Andalucia3.jpg" alt="plan"/></div>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="about-andalucia">
              <div class="col-md-12 col-sm-12">
                <p><asp:Literal ID="Literal7" Text="<%$Resources:Resource, InlandAndaluciathesesierras %>" runat="server"></asp:Literal></p>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="about-andalucia">
              <div class="col-md-4 col-sm-4">
                <div class="about-andalucia"><img class="img-bdr" src="/images/inland_Andalucia2.jpg" alt="plan"/></div>
              </div>
              <div class="col-md-8 col-sm-8">
                <div class="about-andalucia">
                  <p><asp:Literal ID="Literal8" Text="<%$Resources:Resource, InlandAndaluciacompletelist %>" runat="server"></asp:Literal> </p>
                </div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          
          
          <div class="row">
             <div class="col-md-12">
             <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
             </div>
          </div>
          
          
          <!-- Sorted By Provinance Start -->
            <uc1:WebUserControlTownGuid runat="server" ID="WebUserControlTownGuid" />
         </div>
        <!-- Left Portion End --> 
        
        <!-- Right Portion Start -->
     
<!-- Main Content Area End --> 
</asp:Content>

