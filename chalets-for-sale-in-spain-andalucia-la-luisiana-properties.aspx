<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="chalets-for-sale-in-spain-andalucia-la-luisiana-properties.aspx.vb" Inherits="benameji" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>La Luisiana Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=5&areaid=585&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p>This town was a colony that was founded during the late 18th century by Charles III in an attempt to populate the uninhabited areas near to the Sierra Morena.</p>  
                         </div></div>
              </div> 
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal3' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal> La Luisiana, Sevilla:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png" alt="plan"/>
                  <p> 4.300 <asp:Literal ID='Literal4' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png" alt="plan"/>
                  <p><asp:Literal ID='Literal5' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png" alt="plan"/>
                  <p>
Antequera 99km
Malaga 150km
Granada 195km
Sevilla 75km
             
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>150km <asp:Literal ID='Literal6' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png" alt="plan"/>
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png" alt="plan"/>
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png" alt="plan"/>
                  <p><asp:Literal ID='Literal9' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal> 1h45
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>68km <asp:Literal ID='Literal10' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
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
                  <p>75km <asp:Literal ID='Literal15' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
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
                  <h3>La Luisiana <asp:Literal ID='Literal16' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                          <img src="/images/photos/TownLocationInfo/laluisiana_coa.gif" alt="Alcala de Real Coat of Arms"/>
                         </div> 
                    <div class="col-md-8 col-sm-8">
                          <h5>  Ayuntamiento de La Luisiana</h5>
                 <p>
                     

Plaza Pablo Olavide, 12
41430 La Luisiana, Sevilla
Telephone: 955-907-202
                     <p><a href="http://www.aytolaluisiana.com/" target="_blank">http://www.aytolaluisiana.com/</a></p>
   </p>

                         </div> 
             
              
              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr mrg-10t"  src="/images/photos/TownLocationInfo/laluisiana_ayuntamiento.jpg" alt="La Luisiana Ayuntamiento"/> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"/></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
La Luisiana <asp:Literal ID='Literal18' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p>A number of colonies were set up at this time and Charles' minister, Olavide, decided that rather than populating these new towns with Spaniards and risk depopulating other areas of Spain. </p>      
                    <%--<p>They would bring people in from other parts of Europe, mostly from</p>--%>
                      </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/photos/TownLocationInfo/laluisiana3.jpg" alt="La Luisiana Andalucia fruit"/></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
<%--          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p><asp:Literal ID='Literal21' Text='<%$Resources:Resource, BenamejiDetail4 %>' runat='server'></asp:Literal></p>
              </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/laluisiana2.jpg" alt="La Luisiana flamenco"/></div>
            </div>
          </div>--%>
              <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
              <p>La Luisiana is built on a regular grid pattern as dictated by town planners of the time. The small and attractive town square is adjacent to the town hall and as is the neoclassical pink parish church. La Luisiana has a population of 4300.</p>
                          <p>It is situated 15km to the west of Écija, next to the NIV motorway, 75km east of Seville</p>

                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/laluisiana1.jpg" alt="La Luisiana Andalucia feria"/></div>
            </div>
          </div>
                 <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
            <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal24' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/photos/TownLocationInfo/laluisiana4.jpg" alt="BLa Luisiana Andalucia centre"/></div>
            </div>
          </div>
          <!-- Detail three Start -->
       
         
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

