<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="overseas-properties-for-sale-in-spain-andalucia-seville.aspx.vb" Inherits="benameji" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Sevilla Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=965&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p>According to legend, Sevilla was founded by Hercules and its origins are linked with the Tartessian civilisation. It was called Hispalis under the Romans and Isbiliya with the Moors. Its high point in its history was following the discovery of America. Sevilla lies on the banks of the Guadalquivir and is one of the largest historical centres in Europe, it has the minaret of La Giralda, the cathedral (one of the largest in Christendom), and the Alcázar Palace. Part of its treasure include Casa de Pilatos, Torre del Oro, the Town Hall, Archive of the Indies (where the historical records of the American continent are kept), the Fine Arts Museum (the second largest picture gallery in Spain), plus convents, parish churches and palaces.</p>  
                          </div></div>
              </div> 
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal3' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal> Sevilla:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png">
                  <p> 700.000 <asp:Literal ID='Literal4' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png">
                  <p><asp:Literal ID='Literal5' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png">
                  <p>
Antequera 170km
Malaga 215km
Granada 260km

             
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>215km <asp:Literal ID='Literal6' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
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
                  <p>260km <asp:Literal ID='Literal10' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png">
                  <p>Large supermarkets, Commercial centers,
Shops, Bars, Restaurants
                  
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
                  <p>5km <asp:Literal ID='Literal15' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
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
                  <h3>Sevilla <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                          <img src="/images/photos/TownLocationInfo/sevilla_coa.gif" alt="Alcala de Real Coat of Arms" >
                         </div> 
                    <div class="col-md-8 col-sm-8">
                          <h5>  Ayuntamiento de Sevilla</h5>
                 <p>
                   

Calle Inca Gracilazo,
Edificio Expo 41092 Sevilla, Sevilla
Telephone: 954-467-830
                     <p><a href="http://www.sevilla.org/" target="_blank">http://www.sevilla.org/</a></p>
   </p>

                         </div> 
             
              
              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr mrg-10t"  src="/images/photos/TownLocationInfo/sevilla_ayuntamiento.jpg" alt="Alacala la Real"> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
Sevilla  <asp:Literal ID='Literal18' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p>It has hosted two international exhibitions (1929 and 1992) and is the administrative capital of Andalucia. The quarter of Triana on the other side of the river, La Macarena, Santa Cruz and San Bartolomé, the street of Las Sierpes, plus La Maestranza bullring, María Luisa park and the riverside walks are all representative images of Sevilla. For all its important monuments and fascinating history, Sevilla is universally famous for being a joyous town. While the Sevillanos are known for their wit and sparkle, the city itself is striking for its vitality. It is the largest town in Southern Spain, the city of Carmen, Don Juan and Figaro. </p>      
                    <p>Seville is the 2000 year old artistic, cultural and financial capital of Andalucia and is situated on the plain of the River Guadalquivir. The University of Seville has a present student body of 65,000 and is considered one of the top-ranked universities in Spain.</p>
                      </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/sevilla6.jpg" alt="Sevilla Andalucia plaza de España"></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p>Seville boasts 3 UNESCO World Heritage Sites; The Cathedral of Saint Mary of the Sea is a Roman Catholic cathedral and is the largest Gothic cathedral, as well as being the fourth-largest church in the world; The Alcazar of Seville is a royal palace, originally a Moorish fort it is the oldest royal palace still in use in Europe. The Almohades were the first to build a palace, which was called Al-Muwarak on the site of the modern day Alcazar and is one of the best remaining examples of Mudejar architecture; The Archivo General de Indias (“ General Archive of the Indies”), housed in the Casa Lonja de Mercaderes, the ancient merchants exchange of Seville, is the home of extremely valuable archival documents illustrating the History of the Spanish Empire in the Americas and the Philippines.</p>
            <p>Immediately before that is Holy Week, Semana Santa, a religious festival where hooded penitents march in long processions followed by huge baroque floats on which sit Images of the Virgin or Christ, surrounded by cheerful crowds. Both spring events are well worth experiencing.</p>
                      </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/sevilla_002.jpg" alt="Sevilla Andalucia centre"  ></div>
            </div>
          </div>
              <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
            
                          <p>Don't miss out on the Tapas! The city of 700,000 is credited with their invention and has more than a thousand bars where the choice of food is virtually unlimited; from seafood to ham and sausage, from vegetable to cheese. The Sevillanos actually make a meal of them, moving from bar to bar and trying one dish at a time!</p>

                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/sevilla5.jpg" alt="Sevilla Andalucia cathedral"></div>
            </div>
          </div>
                  <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
            
                          <p>In Sevilla, you will want to visit the old city, with the Cathedral and the Giralda tower at its heart. (You can climb the steps inside the tower for a magnificent view of the City). Very close by are the royal Mudéjar palace known as the Alcazar with marvellous gardens and the Santa Cruz quarter, with cramped streets, flowered balconies, richly decorated facades, hidden patios... Other sights not to be missed are, in the old city, the Casa de Pilatos, a large sixteenth-century mansion where Mudejar, Gothic and Renaissance styles blend harmoniously amidst exuberant patios and gardens and, crossing the Triana bridge over the large Guadalquívir River, the lively popular quarter of Triana with charming narrow streets around the church of Santa Ana and traditional ceramic factories.</p>

                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/sevilla3.jpg" alt="Sevilla Andalucia bridge"></div>
            </div>
          </div>
                 <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
            <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal24' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/sevilla10.jpg" alt="Sevilla Andalucia tapas"></div>
            </div>
          </div>
             <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/sevilla2.jpg" alt="Sevilla Andalucia  sunset"></div>
            </div>
          </div>
             <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/sevilla4.jpg" alt="Sevilla Andalucia cathedral"></div>
            </div>
          </div>
          <!-- Detail three Start -->
       
         
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

