<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="villas-cortijos-for-sale-iznajar-lakes-inland-andalucia-spain.aspx.vb" Inherits="guide_iznajar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Iznajar</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=1&areaid=524&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
         </div></div>
          <!-- Detail one Strat -->
          </div> 
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal> Iznajar:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png" alt="plan"/>
                  <p>   5,960 <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png" alt="plan"/>
                  <p><asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png" alt="plan"/>
                  <p>
Antequera 57km
Malaga 85km
Granada 94km
Sevilla 188km
             
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>85km   Malaga
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png" alt="plan"/>
                  <p><asp:Literal ID='Literal5' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png" alt="plan"/>
                  <p><asp:Literal ID='Literal6' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png" alt="plan"/>
                  <p> 1h
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>94km    Granada
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png" alt="plan"/>
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png" alt="plan"/>
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png" alt="plan"/>
                  <p><asp:Literal ID='Literal9' Text='<%$Resources:Resource, busstation %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>188km Sevilla
                  
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
                  <h3>Iznajar location</h3>
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
                <h4><asp:Literal ID='Literal10' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
              <img src="/images/townguide/iznajar/coa_iznajar.jpg" alt="Iznajar Coat of Arms" style="width:30%"/>
                <h5>Ayuntamiento de Encinas Reales</h5>
                 <p>Ayuntamiento de Iznajar
Julio Burell, 17, 14970
Iznajar, Córdoba
Telephone: 957 53 40 02
                     <p><a href="http://www.iznajar.es/" target="_blank">http://www.iznajar.es/</a></p>
   </p>

              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr mrg-10t"  src="/images/townguide/iznajar/iznajar1.jpg" alt="Town Hall, Iznajar"/> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>Iznajar <asp:Literal ID='Literal11' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal13' Text='<%$Resources:Resource, inzajarDetail1 %>' runat='server'></asp:Literal></p>             

                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/townguide/iznajar/iznajar2.jpg" alt="Iznajar Cordoba lake"/></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p><asp:Literal ID='Literal14' Text='<%$Resources:Resource, inzajarDetail2 %>' runat='server'></asp:Literal></p>                          
         

              </div>
             <div class="col-md-4 col-sm-4">
                 <img class="img-bdr" src="/images/townguide/iznajar/iznajar3.jpg" alt="Iznajar Cordoba lake"/>
                    
             </div>
            </div>
          </div>
             
            <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p><asp:Literal ID='Literal15' Text='<%$Resources:Resource, inzajarDetail3 %>' runat='server'></asp:Literal></p>
              </div>
             <div class="col-md-4 col-sm-4">
                 <img class="img-bdr" src="/images/townguide/iznajar/iznajar4.jpg" alt="Iznajar Cordoba"/>
                    
             </div>
            </div>
          </div>
             
            <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                             <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal16' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
              </div>
             <div class="col-md-4 col-sm-4">
                 <img class="img-bdr" src="/images/townguide/iznajar/iznajar5.jpg" alt="Iznajar Cordoba"/>
                    
             </div>
            </div>
          </div>
             
     
       
         
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

