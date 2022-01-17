<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="chalet-spanish-bargain-homes-for-sale-marchena-sevilla-spain.aspx.vb" Inherits="MarchenaLocationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Marchena Sevilla</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=726&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p><asp:Literal ID='Literal1' Text='<%$Resources:Resource, MarchenaLocationInfoDetail %>' runat='server'></asp:Literal></p>           

              </div>
          </div></div>
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationAbout %>' runat='server'></asp:Literal> Marchena, Sevilla:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png" alt="plan"/>
                  <p>21.000 <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png" alt="plan"/>
                  <p><asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png" alt="plan"/>
                  <p>
  Antequera 111km
Málaga 160km
Granada 200km
Sevilla 60km

             
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>160km <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png" alt="plan"/>
                  <p><asp:Literal ID='Literal6' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png" alt="plan"/>
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png" alt="plan"/>
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal> 1h15
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>200km <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png" alt="plan"/>
                  <p><asp:Literal ID='Literal10' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png" alt="plan"/>
                  <p><asp:Literal ID='Literal11' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png" alt="plan"/>
                  <p><asp:Literal ID='Literal13' Text='<%$Resources:Resource, busservice %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>60km <asp:Literal ID='Literal14' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
              </div>
            </div>
          </div>
          
          <!-- Quick information about Mollina End --->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!--Properties for sale in Mollina -->
          
          <div class="row">
            <div class="col-md-12">
              <div class="monilla-loc">
               
               <%-- google map --%>
                  <h3>
Marchena <asp:Literal ID='Literal15' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
                     <asp:UpdatePanel ID="UpdatePanelTownMap" runat="server" UpdateMode="Conditional">
           <ContentTemplate>
           </ContentTemplate>
       </asp:UpdatePanel> 
              </div>
            </div>
          </div>
          
          <!--Properties for sale in Mollina -->
      <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Location Information Start -->
          <div class="row">
            <div class="location-info">
              <div class="col-md-6 col-sm-6">
                <h4><asp:Literal ID='Literal16' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
              <img src="/images/photos/TownLocationInfo/marchena_coa.gif" alt="Marchena Coat of Arms" >
                <h5> Ayuntamiento de Marchena </h5>
                 <p> Plaza del Ayuntamiento, 1
                     41620 Marchena, Sevilla 
Telephone: 955-846-457
   </p>
   <p> <a href="http://www.ayto-marchena.com" title="www.ayto-marchena.com" target="_blank">www.ayto-marchena.com</a></p>
              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr mrg-10t"  src="/images/photos/TownLocationInfo/marchena_ayuntamiento.jpg" alt="Marchena Andalucia wine"/> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
Marchena <asp:Literal ID='Literal17' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal18' Text='<%$Resources:Resource, MarchenaLocationInfoDetail1 %>' runat='server'></asp:Literal></p> 

<p><asp:Literal ID='Literal19' Text='<%$Resources:Resource, MarchenaLocationInfoDetail2 %>' runat='server'></asp:Literal>.</p>
                      </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/marchena5.jpg" alt="Marchena Andalucia centre"/></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                  <p><asp:Literal ID='Literal20' Text='<%$Resources:Resource, MarchenaLocationInfoDetail3 %>' runat='server'></asp:Literal></p>
                  <p><asp:Literal ID='Literal21' Text='<%$Resources:Resource, MarchenaLocationInfoDetail4 %>' runat='server'></asp:Literal></p>
              </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/marchena4.jpg" alt="Marchena nature"/></div>
            </div>
          </div>
          <!-- Detail three Start -->
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl ">
             
              <div class="col-md-8 col-sm-8">
               <p><asp:Literal ID='Literal22' Text='<%$Resources:Resource, MarchenaLocationInfoDetail5 %>' runat='server'></asp:Literal></p>
                 <p><asp:Literal ID='Literal23' Text='<%$Resources:Resource, MarchenaLocationInfoDetail6 %>' runat='server'></asp:Literal></p>
                    </div>
              
               <div class="col-md-4 col-sm-4"><img class="img-bdr" src= "/images/photos/TownLocationInfo/marchena3.jpg" alt="Marchena Andalucia building"/></div>
            </div>
          </div>
          
          <!-- Detail three Start --> 
              <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl ">
             
              <div class="col-md-8 col-sm-8">
               <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal24' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>

                   </div>
              
               <div class="col-md-4 col-sm-4"><img class="img-bdr" src= "/images/photos/TownLocationInfo/marchena2.jpg" alt="Marchena Andalucia birds"/></div>
            </div>
          </div>
          
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
        
</asp:Content>

