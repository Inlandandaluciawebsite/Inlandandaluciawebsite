<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="inland-spanish-properties-for-sale-ecija-serville-andalucia.aspx.vb" Inherits="EcijaAndalucia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Ecija Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=322&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p>Avoid visiting Ecija in the middle of summer. It once registered an alarming 52 degrees centigrade on the thermometer and is known as La SartEn de Andalucia (the Frying-Pan of Andalucia) which is no exaggeration.</p>  
                          </div></div>
              </div> 
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal3' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal> Ecija:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png">
                  <p> 38.000 <asp:Literal ID='Literal4' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png">
                  <p><asp:Literal ID='Literal5' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png">
                  <p>
Antequera 84km
Malaga 130km
Granada 180km
Sevilla 100km
             
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>130km <asp:Literal ID='Literal6' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png">
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, healthclinichospital %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png">
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png">
                  <p><asp:Literal ID='Literal9' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal> 1h
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>180km <asp:Literal ID='Literal10' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png">
                  <p><asp:Literal ID='Literal11' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png">
                  <p><asp:Literal ID='Literal13' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png">
                  <p><asp:Literal ID='Literal14' Text='<%$Resources:Resource, BusTrainService %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>100km <asp:Literal ID='Literal15' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
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
                  <h3>Ecija <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                <h4> <asp:Literal ID='Literal17' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                     <div class="col-md-4 col-sm-4">
                          <img src="/images/photos/TownLocationInfo/ecija_coa.gif" alt="Ecija Town Hall" >
                         </div> 
                    <div class="col-md-8 col-sm-8">
                          <h5> Ayuntamiento de Ecija</h5>
                 <p>
                      Plaza de Espana, 
                     1 41400 Ecija
Sevilla 955-900-240


                     <p><a href="http://www.ecija.es" target="_blank" title="Ecija Town Hall">http://www.ecija.es</a></p>
   </p>

                         </div> 
             
              
              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr mrg-10t"  src="/images/photos/TownLocationInfo/ecija_ayuntamiento.jpg" alt="Alacala la Real"> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
Ecija  <asp:Literal ID='Literal18' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p>Located midway between Seville and Cordoba in a valley of low hills, Ecija is home to several magnificent baroque churches, the towers of each glisten with brilliantly colored tiles which can be spied from far in the distance. There are also some splendid houses here which date back to the 18th century when the local nobility bought homes in the town. Many of the mansions are particularly distinctive for their flamboyant architecture displaying interesting shapes and patterns. </p>      
                    <p>Unfortunately, a major earthquake in 1757 did considerable damage to many of the buildings; however the churches were restored - at a considerable cost.</p>
                      </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/ecija5.jpg" alt="Ecija bridge"></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p>Things to see include the Roman mosaic on the ayuntamiento while two of the most spectacular towers are on the Santa Maria church and the Iglesia de San Juan Bautista. The tourist office also just happens to be housed in a former palace with a fabulous portal in contrasting tints of marble, while the Museo Historico Municipal has a fine collection of artifacts in a serene setting of palms and patios. Another highlight is the impressive Palacio de Penaflor on Calle Castellar with a curved facade decorated with frescos and an elaborate baroque portal. Nearby is the San Gil Gothic-MudEjar church which is also worth a camera shot or two.</p>
              </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/ecija6.jpg" alt="View of Ecija"  ></div>
            </div>
          </div>
              <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
              <p>The town of 38,000 has a beautiful municipal pool with bar/restaurant. The amenities are concentrated around the main Plaza. There is a planned 18 hole golf course. From Ecija is a vía verde (greenway) that runs northeast to Valchillon just south of Cordoba and southwest to Marchena. The Via Verde of the Countryside can be used by walkers, cyclists or horse riders. </p>
                         

                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/ecija7.jpg" alt="Ecija square"></div>
            </div>
          </div>
                 <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
            <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal24' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/ecija4.jpg" alt="Ecija castle"></div>
            </div>
          </div>
          <!-- Detail three Start -->
       
         
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

