<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="overseas-property-in-spain-for-sale-villas-saucejo-sevilla-andalucia.aspx.vb" Inherits="SaucejoLocationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
       <div class="row">
            <div class="">
              <div class="town-guide-hd">
          <div class="col-md-8"> <h1> <asp:Literal ID="Literal3" Text="<%$Resources:Resource, SaucejoLocationInfoHeading %>" runat="server"></asp:Literal></h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=385&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
 <p> 	
     <asp:Literal ID="Literal1" Text="<%$Resources:Resource, SaucejoLocationInfoDetail %>" runat="server"></asp:Literal></p>
              </div>
            </div>
          </div>
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID="Literal2" Text="<%$Resources:Resource, SaucejoLocationInfoQuickinfo %>" runat="server"></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png">
                  <p>4.300 <asp:Literal ID="Literal4" Text="<%$Resources:Resource, residents %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png">
                  <p><asp:Literal ID="Literal5" Text="<%$Resources:Resource, schools %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png">
                  <p>Antequera 58km
                      M&aacute;laga 
                          120km
Granada 150km
Sevilla 115km
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>120km <asp:Literal ID="Literal6" Text="<%$Resources:Resource, tomalega %>" runat="server"></asp:Literal>
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png">
                  <p><asp:Literal ID="Literal7" Text="<%$Resources:Resource, healthclinic %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png">
                  <p><asp:Literal ID="Literal8" Text="<%$Resources:Resource, muncipalpool %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png">
                  <p><asp:Literal ID="Literal9" Text="<%$Resources:Resource, beach %>" runat="server"></asp:Literal> 1h15
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>150km <asp:Literal ID="Literal10" Text="<%$Resources:Resource, togranada %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png">
                  <p><asp:Literal ID="Literal11" Text="<%$Resources:Resource, shopsbars %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png">
                  <p><asp:Literal ID="Literal13" Text="<%$Resources:Resource, golfnearby %>" runat="server"></asp:Literal>
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png">
                  <p><asp:Literal ID="Literal14" Text="<%$Resources:Resource, busservice %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>115km <asp:Literal ID="Literal15" Text="<%$Resources:Resource, tosevilla %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
              </div>
            </div>
          </div>
          
          <!-- Quick information about Mollina End --->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!--Properties for sale in Mollina -->
          
          <div class="row">
            <div class="col-md-12">
              <div class="monilla-loc">
               <%-- google map --%>
                  <h3>
<asp:Literal ID="Literal16" Text="<%$Resources:Resource, SaucejoLocationInfolocation %>" runat="server"></asp:Literal></h3>
                     <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
           <ContentTemplate>
           </ContentTemplate>
       </asp:UpdatePanel> 
              </div>
            </div>
          </div>
          
          <!--Properties for sale in Mollina -->
      <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Location Information Start -->
          <div class="row">
            <div class="location-info">
              <div class="col-md-6 col-sm-6">
                <h4><asp:Literal ID="Literal17" Text="<%$Resources:Resource, SaucejoLocationInfolocinfo %>" runat="server"></asp:Literal></h4>
              <img src="/images/photos/TownLocationInfo/elsaucejo_coa.gif"  alt="Saucejo Coat of Arms">
                <h5>Ayuntamiento de Arahal</h5>
                 <p>  	 Ayuntamiento de El Saucejo ,
    Plaza de la Constitución, 
    12 41650 El Saucejo, Sevilla
    <%=("Telephone")%>: 955-824-702</p>
<%--                  <a href="http://www.arahal.es/" title="http://www.arahal.es/" target="_blank">http://www.arahal.es/</a>--%>

              </div>
              <div class="col-md-6 col-sm-6"> 
                  <%--<img class="img-bdr mrg-10t"  src="/images/mollina1 (1).jpg">--%> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3><asp:Literal ID="Literal18" Text="<%$Resources:Resource, SaucejoLocationInfoinformation %>" runat="server"></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
             <p>  	<asp:Literal ID="Literal19" Text="<%$Resources:Resource, SaucejoLocationInfodetail1 %>" runat="server"></asp:Literal> </p>
  <p> 	 <asp:Literal ID="Literal20" Text="<%$Resources:Resource, SaucejoLocationInfodetail2%>" runat="server"></asp:Literal></p>
           <p> <asp:Literal ID="Literal21" Text="<%$Resources:Resource, SaucejoLocationInfodetail3 %>" runat="server"></asp:Literal> </p>
 <p>      <a href="TownLocationInfo.aspx" title="More information on towns of Andalucia">
          <asp:Literal ID="Literal22" Text="<%$Resources:Resource, aguaduceLocationInfolocation %>" runat="server"></asp:Literal></a></p>
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/elsaucejo5.jpg" alt="Saucejo street"></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
              
               
              </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/elsaucejo1.jpg" alt="Saucejo Andalucia spring"></div>
            </div>
          </div>
          <!-- Detail three Start -->
          
         
          
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl ">
             
              <div class="col-md-8 col-sm-8">
               
                   </div>
              
               <div class="col-md-4 col-sm-4"><img class="img-bdr" src= "/images/photos/TownLocationInfo/elsaucejo3.jpg" alt="Saucejo Andalucia wine"></div>
            </div>
          </div>
             <div class="row">
            <div class="mollina-information-dtl ">
             
              <div class="col-md-8 col-sm-8">
               
                   </div>
              
               <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/elsaucejo4.jpg" alt="Saucejo Andalucia town centre"></div>
            </div>
          </div>
          
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

