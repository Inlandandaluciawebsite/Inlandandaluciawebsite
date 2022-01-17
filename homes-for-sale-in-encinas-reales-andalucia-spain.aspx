<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="homes-for-sale-in-encinas-reales-andalucia-spain.aspx.vb" Inherits="encinas_reales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Encinas Reales Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=1&areaid=402&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p><asp:Literal ID='Literal1' Text='<%$Resources:Resource, EncinasRealesDetail %>' runat='server'></asp:Literal></p>          </div></div>
          <!-- Detail one Strat -->
          </div> 
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationOf %>' runat='server'></asp:Literal> Encinas Reales:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png">
                  <p>  2.391 <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal> (2012)
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png">
                  <p><asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png">
                  <p>
Antequera 37km
Malaga 77km
Granada 119km
Sevilla 184km
             
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>77km  Malaga
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png">
                  <p><asp:Literal ID='Literal5' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png">
                  <p><asp:Literal ID='Literal6' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png">
                  <p> 45min
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>119km   Granada
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png">
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png">
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png">
                  <p><asp:Literal ID='Literal9' Text='<%$Resources:Resource, busstation %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>184km  Sevilla
                  
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
                  <h3>Encinas Reales <asp:Literal ID='Literal10' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal></h3>
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
                <h4><asp:Literal ID='Literal11' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
              <img src="/images/townguide/encinas-reales/encinas-coa.jpg" alt="Encinas Reales Coat of Arms" >
                <h5>Ayuntamiento de Encinas Reales</h5>
                 <p>Plaza De La Democracia s/n, 14913
Encinas Reales(Córdoba)

Telephone: 957 - 59 71 28 / 957 - 59 71 34

                     <p><a href="http://www.encinasreales.es" target="_blank">http://www.encinasreales.es</a></p>
   </p>

              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr mrg-10t"  src="/images/townguide/encinas-reales/encinas.jpg" alt="Town Hall, Encinas Reales"> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
Encinas Reales <asp:Literal ID='Literal13' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal14' Text='<%$Resources:Resource, EncinasRealesDetail1 %>' runat='server'></asp:Literal></p>     
                    <p><asp:Literal ID='Literal15' Text='<%$Resources:Resource, EncinasRealesDetail2 %>' runat='server'></asp:Literal></p>             
                     </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/townguide/encinas-reales/encinas-1.jpg" alt="Castle Encinas Reales"></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p><asp:Literal ID='Literal16' Text='<%$Resources:Resource, EncinasRealesDetail3 %>' runat='server'></asp:Literal></p>
                            <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal17' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>

              </div>
             <div class="col-md-4 col-sm-4">
                 <img class="img-bdr" src="/images/townguide/encinas-reales/encinas-2.jpg" alt="Encinas Reales views"  >
                         <img class="img-bdr" src="/images/townguide/encinas-reales/encinas-3.jpg" alt="Street Encinas Reales" >
                               <img class="img-bdr" src="/images/townguide/encinas-reales/encinas-4.jpg" alt="Encinas Reales church">
             </div>
            </div>
          </div>
             
       
         
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

