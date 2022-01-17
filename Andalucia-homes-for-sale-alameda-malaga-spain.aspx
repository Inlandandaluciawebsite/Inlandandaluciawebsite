<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Andalucia-homes-for-sale-alameda-malaga-spain.aspx.vb" Inherits="AlamedaLocationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Alameda Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=4&areaid=11&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal16' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p><asp:Literal ID='Literal1' Text='<%$Resources:Resource, AlamedaLocationDetail %>' runat='server'></asp:Literal></p>
              </div></div>
          <!-- Detail one Strat -->
          </div> 
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationAbout %>' runat='server'></asp:Literal> Alameda:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png">
                  <p>     5.500 <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png">
                  <p><asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png">
                  <p>
Antequera 27km
Málaga 65km
Granada 110km
Sevilla 145km
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>65km <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png">
                  <p><asp:Literal ID='Literal6' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png">
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png">
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal> 1h
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>110km <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png">
                  <p><asp:Literal ID='Literal10' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png">
                  <p><asp:Literal ID='Literal11' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png">
                  <p><asp:Literal ID='Literal12' Text='<%$Resources:Resource, busservice %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>145Km <asp:Literal ID='Literal13' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
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
Alameda <asp:Literal ID='Literal14' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                <h4><asp:Literal ID='Literal15' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
              <img src="/images/photos/TownLocationInfo/alameda_coa.gif" alt="Alameda Coat of Arms" >
                <h5>Ayuntamiento de Alameda</h5>
                 <p>
Plaza de España, 5
29530 Alameda, Málaga
Telephone: 952-710-025


                   
   </p>
                  <p><a href="http://www.alameda.es/" title="http://www.alameda.es/" target="_blank">http://www.alameda.es/</a>
    </p>
                
 

              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr mrg-10t"  src="/images/photos/TownLocationInfo/alameda_ayuntamiento.jpg" alt="Town Hall, Alameda"> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
Alameda <asp:Literal ID='Literal17' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal18' Text='<%$Resources:Resource, AlamedaLocationDetail1 %>' runat='server'></asp:Literal></p>  
                
                    <p><asp:Literal ID='Literal19' Text='<%$Resources:Resource, AlamedaLocationDetail2 %>' runat='server'></asp:Literal></p>              
                    <p><asp:Literal ID='Literal20' Text='<%$Resources:Resource, AlamedaLocationDetail3 %>' runat='server'></asp:Literal></p>   
                    <p><asp:Literal ID='Literal21' Text='<%$Resources:Resource, AlamedaLocationDetail4 %>' runat='server'></asp:Literal></p>   
                    <p><asp:Literal ID='Literal22' Text='<%$Resources:Resource, AlamedaLocationDetail5 %>' runat='server'></asp:Literal></p>    
                    <p><asp:Literal ID='Literal23' Text='<%$Resources:Resource, AlamedaLocationDetail6 %>' runat='server'></asp:Literal></p> 
                    <p><asp:Literal ID='Literal24' Text='<%$Resources:Resource, AlamedaLocationDetail7 %>' runat='server'></asp:Literal></p>     
                    <p><asp:Literal ID='Literal25' Text='<%$Resources:Resource, AlamedaLocationDetail8 %>' runat='server'></asp:Literal></p> 
                    <p><asp:Literal ID='Literal26' Text='<%$Resources:Resource, AlamedaLocationDetail9 %>' runat='server'></asp:Literal></p>
                    <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal27' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                   </div>
                     </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/alameda7.jpg" alt="Alameda Andalucia history">

                      <img class="img-bdr" src="/images/photos/TownLocationInfo/alameda2.jpg" alt="Alameda Andalucia donkey">
                     <img class="img-bdr" src="/images/photos/TownLocationInfo/alameda3.jpg" alt="Alameda Andalucia nature">
                    <img class="img-bdr" src="/images/photos/TownLocationInfo/alameda1.jpg" alt="Alameda Andalucia ruin" >
           
                        <img class="img-bdr" src="/images/photos/TownLocationInfo/alameda4.jpg" alt="Alameda Andalucia feasts" >
                      <img class="img-bdr" src= "/images/photos/TownLocationInfo/alameda5.jpg" alt="Alameda Andalucia church">
                         <img class="img-bdr" src= "/images/photos/TownLocationInfo/alameda6.jpg" alt="Alameda Andalucia flowers">
                </div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
    
         
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

