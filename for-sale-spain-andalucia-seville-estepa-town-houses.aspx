<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="for-sale-spain-andalucia-seville-estepa-town-houses.aspx.vb" Inherits="EstepaLocationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
          <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Estepa Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=415&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
  <p> <asp:Literal ID='Literal1' Text='<%$Resources:Resource, EstepaDetail %>' runat='server'></asp:Literal></p>
             </div>
            </div>
          </div>
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationAbout %>' runat='server'></asp:Literal> Estepa:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png">
                  <p>14.000 <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png">
                  <p><asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png">
                  <p>Antequera 40km
     M&aacute;laga 95km
     Granada 
                          140km
                          Sevilla 110km
             
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>95km <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
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
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal> 1h15
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>140km <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
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
                  <p><asp:Literal ID='Literal13' Text='<%$Resources:Resource, busservice %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>110km <asp:Literal ID='Literal14' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
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
                  <h3>Estepa <asp:Literal ID='Literal15' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                <h4><asp:Literal ID='Literal16' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
              <img src="/images/photos/TownLocationInfo/estepa_coa.jpg"  alt="Estepa Coat of Arms" >
                <h5>Ayuntamiento de Estepa</h5>
                 <p>  	 Avenida Bad&iacute;a Polesine, 28,
    41560 Estepa, Sevilla 
  
    <%=("Telephone")%>: 955-912-717</p>
    <a href="http://www.estepa.com/" title="Estepa Town Hall" target="_blank">http://www.estepa.com/</a>
              </div>
              <div class="col-md-6 col-sm-6"> 
                  <img class="img-bdr mrg-10t"  src="/images/photos/TownLocationInfo/estepa7.jpg" alt="Estepa Andalucia El Torcal"> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
         <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
                <h3>Estepa <asp:Literal ID='Literal17' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal18' Text='<%$Resources:Resource, EstepaDetail1 %>' runat='server'></asp:Literal></p>
<p><asp:Literal ID='Literal19' Text='<%$Resources:Resource, EstepaDetail2 %>' runat='server'></asp:Literal></p>                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa12.jpg" alt="Estepa Andalucia Roman coin"></div>
              </div>
            </div>
          </div>          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p><asp:Literal ID='Literal20' Text='<%$Resources:Resource, EstepaDetail3 %>' runat='server'></asp:Literal> </p>                   </div>
            
                 <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/estepa13.jpg" alt="Estepa Andalucia Romans"></div>
            </div>
          </div>
          <!-- Detail three Start -->
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl ">
             
              <div class="col-md-8 col-sm-8">
            <p> <asp:Literal ID='Literal21' Text='<%$Resources:Resource, EstepaDetail4 %>' runat='server'></asp:Literal></p>
                    </div>
              
               <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/estepa14.jpg" alt="Estepa Andalucia city wall"></div>
            </div>
          </div>

          <!-- Detail three Start --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
            
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p><asp:Literal ID='Literal22' Text='<%$Resources:Resource, EstepaDetail5 %>' runat='server'></asp:Literal></p>   
                  <p><asp:Literal ID='Literal23' Text='<%$Resources:Resource, EstepaDetail6 %>' runat='server'></asp:Literal></p>
              </div>
                  <div class="col-md-4 col-sm-4"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa15.jpg" alt="Estepa Andalucia history"></div>
                
            </div>
          </div>
                <!-- Detail Two Strat -->
   
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
                <p><asp:Literal ID='Literal24' Text='<%$Resources:Resource, EstepaDetail7 %>' runat='server'></asp:Literal></p>  </div>
            <p><asp:Literal ID='Literal25' Text='<%$Resources:Resource, EstepaDetail8 %>' runat='server'></asp:Literal></p>
                    </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa16.jpg" alt="Estepa Andalucia history"></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p> <asp:Literal ID='Literal26' Text='<%$Resources:Resource, EstepaDetail9 %>' runat='server'></asp:Literal> </p>               
<p><asp:Literal ID='Literal27' Text='<%$Resources:Resource, EstepaDetail10 %>' runat='server'></asp:Literal></p>
              </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/estepa17.jpg" alt="Estepa Andalucia bandoleros"></div>
            </div>
          </div>
          <!-- Detail three Start -->
          
         
          
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl ">
             
              <div class="col-md-8 col-sm-8">
               <p><asp:Literal ID='Literal28' Text='<%$Resources:Resource, EstepaDetail11 %>' runat='server'></asp:Literal></p>
             <p><asp:Literal ID='Literal29' Text='<%$Resources:Resource, EstepaDetail12 %>' runat='server'></asp:Literal></p>                 

                     </div>
              
               <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/estepa21.jpg" alt="Estepa Andalucia Museum"></div>
            </div>
          </div>
          
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
            
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
              <p><asp:Literal ID='Literal30' Text='<%$Resources:Resource, EstepaDetail13 %>' runat='server'></asp:Literal></p>
                    </div>
                    <div class="col-md-4 col-sm-4"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa20.jpg" alt="Estepa Andalucia Street"></div>
                
            </div>
          </div>
              <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal31' Text='<%$Resources:Resource, EstepaDetail14 %>' runat='server'></asp:Literal></p>             
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa19.jpg" alt="Estepa Andalucia plaza"></div>
              </div>
            </div>
          </div>
        
                <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal32' Text='<%$Resources:Resource, EstepaDetail15 %>' runat='server'></asp:Literal></p>            
             <p><asp:Literal ID='Literal33' Text='<%$Resources:Resource, EstepaDetail16 %>' runat='server'></asp:Literal></p>
                       </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa11.jpg" alt="Estepa Andalucia Town"></div>
              </div>
            </div>
          </div>
        
                <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
                 <p><asp:Literal ID='Literal34' Text='<%$Resources:Resource, EstepaDetail17 %>' runat='server'></asp:Literal></p>
               <p><asp:Literal ID='Literal35' Text='<%$Resources:Resource, EstepaDetail18 %>' runat='server'></asp:Literal></p>
                     </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa8.jpg" alt="Estepa Andalucia church"></div>
              </div>
            </div>
          </div>
        
                <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
              <p><asp:Literal ID='Literal36' Text='<%$Resources:Resource, EstepaDetail19 %>' runat='server'></asp:Literal></p>
                    <p><asp:Literal ID='Literal37' Text='<%$Resources:Resource, EstepaDetail20 %>' runat='server'></asp:Literal></p>
                      </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa22.jpg" alt="Estepa Andalucia dulces"></div>
              </div>
            </div>
          </div>
        
                <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
                 <p><asp:Literal ID='Literal38' Text='<%$Resources:Resource, EstepaDetail21 %>' runat='server'></asp:Literal></p>
                       <p><asp:Literal ID='Literal40' Text='<%$Resources:Resource, EstepaDetail22 %>' runat='server'></asp:Literal></p>
                    
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa3.jpg" alt="Estepa Andalucia feria" ></div>
              </div>
            </div>
          </div>
            <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
                 
<p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"> <asp:Literal ID="Literal39" Text="<%$Resources:Resource, aguaduceLocationInfomoreinfo %>" runat="server"></asp:Literal></a> 
  </p>             </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/estepa9.jpg" alt="Estepa Andalucia street"></div>
              </div>
            </div>
          </div>
        
        </div>
        <!-- Detail three Start --> 
</asp:Content>

