<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="country-houses-for-sale-lucena-andalucia-spain-properties.aspx.vb" Inherits="benameji" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Lucena Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=1&areaid=708&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p>The second, most populated city in the province of Cordoba. It offers to the visitor numerous incentives, from its history and heritage, to its impressive surroundings. In Lucenawe find the Gothic-Renaissance church of San Mateo, from the 15th-16th centuries, with one of the most beautiful Baroque sacrariums in Andalusia. Civil buildings include the castle and old palace of Medinaceli, the house of the Count of Santa Ana, and the house of Rico de Rueda. Also, within town limits we find areas of great interest, such as the Amarga Lagoon Nature Reserve, Jarales Lagoon Nature Reserve, and Malpasillo Reservoir Nature Park.</p>  
                      </div></div>
              </div> 
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal3' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal> Lucena:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png" alt="plan"/>
                  <p> 42.529  <asp:Literal ID='Literal4' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>(2012)
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png" alt="plan"/>
                  <p><asp:Literal ID='Literal5' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>,univerities
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png" alt="plan"/>
                  <p>
Antequera 48km
Malaga 93km
Granada 134km
Sevilla 161km
             
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>93km <asp:Literal ID='Literal6' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png" alt="plan"/>
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, healthclinichospital %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png" alt="plan"/>
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png" alt="plan"/>
                  <p><asp:Literal ID='Literal9' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal> 1h
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>134km <asp:Literal ID='Literal10' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png" alt="plan"/>
                  <p><asp:Literal ID='Literal11' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png" alt="plan"/>
                  <p><asp:Literal ID='Literal13' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png" alt="plan"/>
                  <p><asp:Literal ID='Literal14' Text='<%$Resources:Resource, BusTrainService %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>161km <asp:Literal ID='Literal15' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
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
                  <h3>Lucena <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                <h4> <asp:Literal ID='Literal17' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                     <div class="col-md-4 col-sm-4">
                          <img src="/images/townguide/lucena/lucena-coa.jpg" alt="LucenaCoat of Arms"/>
                         </div> 
                    <div class="col-md-8 col-sm-8">
                          <h5> Ayuntamiento de Lucena</h5>
                 <p>
                    
Plaza Nueva, 1 14900
Lucena, Córdoba, Spain

Telephone:+34 957 51 05 97 

                     <p><a href="https://www.aytolucena.es" target="_blank">https://www.aytolucena.es/</a></p>
   </p>

                         </div> 
             
              
              </div>
              <div class="col-md-6 col-sm-6"> 
             <%-- <img class="img-bdr mrg-10t"  src="/images/townguide/almedinilla/almedinilla1.jpg" alt="Alacala la Real">--%> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
Lucena <asp:Literal ID='Literal18' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p>Although Lucena appears to be entirely comprised of furniture factories and outlets, the old town hosts many exquisite churches reflecting its importance in the Subbetica of Baroque times. </p>      
                  
                      </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/townguide/lucena/lucena-1.jpg" alt="Lucena village"/></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p>The present day courthouse, the Palacio de los Condes was an eighteenth century palace, and has a striking marble entrance, two interior courtyards and impressive plasterwork. Lucena's main church is that of San Mateo, a Gothic-Renaissance work from the fourteenth and sixteenth centuries. The Renaissance altarpiece is by Jeronimo Hernandez and Juan Bautista Vazquez the Elder. But it's the Capilla del Sagrario which is the most important part of the church, ranking with the Sagrario de la Asuncion in Priego as one of the high points of Andalusian baroque. It was built between 1740 and 1772 and boasts a stunning entrance of encrusted marble. Laid out in an octagon, it has a central shrine and exquisitely painted plasterwork.</p>
              </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/townguide/lucena/lucena-2.jpg" alt="Lucena village"/></div>
            </div>
          </div>
              <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
              <p>Other landmarks are the Palacio de los Condes de Hust in the old Jewish Quarter, and the Iglesia y Hospital de San Juan de Dios boasting a splendid marble entrance and typically Baroque altarpiece and plasterwork. Worth a visit too is the Santuario de Nuestra Señora de Araceli, a hermitage whose chapel is considered to be one of the finest examples of Baroque art in the province. Also the Castillo del Moral, or former prison of Boabdil - the tourism office is there now - and the sixteenth century Parroquia de Santiago built on the site of the former synagogue.

 </p>
                          

                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/townguide/lucena/lucena-3.jpg" alt="Lucena village"/></div>
            </div>
          </div>
                 <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
            <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal24' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/townguide/lucena/lucena-4.jpg" alt="Lucena street"/></div>
            </div>
          </div>

            <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
            
                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/townguide/lucena/lucena-5.jpg" alt="Lucena street"/></div>
            </div>
          </div>
          <!-- Detail three Start -->
       
         
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

