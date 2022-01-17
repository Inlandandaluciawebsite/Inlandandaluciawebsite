<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="property-for-sale-in-archidona-spain-inland-malaga.aspx.vb" Inherits="ArchidonaLocationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Archidona Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=4&areaid=79&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal16' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p><asp:Literal ID='Literal1' Text='<%$Resources:Resource, ArchidonaLocationDetail1 %>' runat='server'></asp:Literal> </p>              </div></div>
          <!-- Detail one Strat -->
          </div> 
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationAbout %>' runat='server'></asp:Literal>  Archidona:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png">
                  <p>   10.200 <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png">
                  <p><asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png">
                  <p>
Antequera 24km
Málaga 63
Granada 80km
Sevilla 170km
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>63km  <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
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
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal> 45min
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>80km <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
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
                  <p><asp:Literal ID='Literal12' Text='<%$Resources:Resource, BusTrainService %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>170km <asp:Literal ID='Literal13' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
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
                  <h3>Archidona location</h3>
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
                <h4> <asp:Literal ID='Literal14' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
              <img src="/images/townguide/rute/rute-coa.jpg" alt="Rute Coat of Arms">
                <h5>Ayuntamiento de Archidona</h5>
                 <p>
Plaza de la Victoria,
S/N 29300 Archidona, Málaga
Telephone: 952-714-061 </p>
                <p><a href="http://www.portalmalaga.com/ ayuntamiento_archidona.htm" title="Archidona" target="_blank">http://www.portalmalaga.com/ ayuntamiento_archidona.htm</a></p>

              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr mrg-10t"  src="/images/townguide/rute/rute.jpg" alt="Town Hall, Rute"> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
Archidona   <asp:Literal ID='Literal15' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal17' Text='<%$Resources:Resource, ArchidonaLocationDetail2 %>' runat='server'></asp:Literal></p>
<p><asp:Literal ID='Literal18' Text='<%$Resources:Resource, ArchidonaLocationDetail3 %>' runat='server'></asp:Literal></p>     
                    <p><asp:Literal ID='Literal19' Text='<%$Resources:Resource, ArchidonaLocationDetail4 %>' runat='server'></asp:Literal></p>
                    <p><asp:Literal ID='Literal20' Text='<%$Resources:Resource, ArchidonaLocationDetail5 %>' runat='server'></asp:Literal></p>  
                    <p><asp:Literal ID='Literal21' Text='<%$Resources:Resource, ArchidonaLocationDetail6 %>' runat='server'></asp:Literal></p>      
                    <p><asp:Literal ID='Literal22' Text='<%$Resources:Resource, ArchidonaLocationDetail7 %>' runat='server'></asp:Literal></p> 
                    <p><asp:Literal ID='Literal23' Text='<%$Resources:Resource, ArchidonaLocationDetail8 %>' runat='server'></asp:Literal> </p>
                    <p><asp:Literal ID='Literal24' Text='<%$Resources:Resource, ArchidonaLocationDetail9 %>' runat='server'></asp:Literal> </p>
                     <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal25' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>

                </div>
                                 
       
                   </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/Archidona1.jpg" alt="Archidona Andalucia view ">

                      <img class="img-bdr" src="/images/photos/TownLocationInfo/Archidona6.jpg" alt="Archidona Andalucia main square">
                     <img class="img-bdr" src="/images/photos/TownLocationInfo/Archidona4.jpg" alt="Archidona Andalucia history">
                               <img class="img-bdr" src="/images/photos/TownLocationInfo/Archidona5.jpg" alt="Archidona Andalucia wind mill">
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

