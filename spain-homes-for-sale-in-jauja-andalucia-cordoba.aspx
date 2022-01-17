<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="spain-homes-for-sale-in-jauja-andalucia-cordoba.aspx.vb" Inherits="jauja" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
       <div class="row">
            <div class="">
              <div class="town-guide-hd">
          <div class="col-md-8"> <h1> <asp:Literal ID="Literal3" Text="<%$Resources:Resource, JaujaLocationheading %>" runat="server"></asp:Literal></h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=1&areaid=535&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
 <p> 	
     <asp:Literal ID="Literal1" Text="<%$Resources:Resource, JaujaLocationDetail1 %>" runat="server"></asp:Literal></p>
              </div>
            </div>
          </div>
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID="Literal2" Text="<%$Resources:Resource, QuickInformationOf %>" runat="server"></asp:Literal> jauja:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png" alt="plan"/>
                  <p>1.080 <asp:Literal ID="Literal4" Text="<%$Resources:Resource, residents %>" runat="server"></asp:Literal>(2012)
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png" alt="plan"/>
                  <p><asp:Literal ID="Literal5" Text="<%$Resources:Resource, schools %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png" alt="plan"/>
                  <p>Antequera 45km
Malaga 88km
Granada 131km
Sevilla 133km

                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>88km <asp:Literal ID="Literal6" Text="<%$Resources:Resource, tomalega %>" runat="server"></asp:Literal>
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png" alt="plan"/>
                  <p><asp:Literal ID="Literal7" Text="<%$Resources:Resource, healthclinic %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png" alt="plan"/>
                  <p><asp:Literal ID="Literal8" Text="<%$Resources:Resource, muncipalpool %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png" alt="plan"/>
                  <p><asp:Literal ID="Literal9" Text="<%$Resources:Resource, beach %>" runat="server"></asp:Literal> 1h15
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>131km <asp:Literal ID="Literal10" Text="<%$Resources:Resource, togranada %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png" alt="plan"/>
                  <p><asp:Literal ID="Literal11" Text="<%$Resources:Resource, shopsbars %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png" alt="plan"/>
                  <p><asp:Literal ID="Literal13" Text="<%$Resources:Resource, golfnearby %>" runat="server"></asp:Literal>
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png" alt="plan"/>
                  <p><asp:Literal ID="Literal14" Text="<%$Resources:Resource, BusStation %>" runat="server"></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>133km <asp:Literal ID="Literal15" Text="<%$Resources:Resource, tosevilla %>" runat="server"></asp:Literal>
                  
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
                  <h3>Jauja
<asp:Literal ID="Literal16" Text="<%$Resources:Resource, Location %>" runat="server"></asp:Literal></h3>
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
                <h4><asp:Literal ID='Literal27' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                   <div class="col-md-3 col-sm-3"><img src="/images/townguide/jauja/jauja-coa.jpg" alt="Jauja Coat of Arms"/></div>
                        <div class="col-md-9 col-sm-9">           <h5>Ayuntamiento de Jauja</h5>
                 <p> Ronda s/n 14911 Jauja (Córdoba)  ,<br />
  957 51 90 51 Fax: 957 51 91 52
 
<%--                  <a href="http://www.arahal.es/" title="http://www.arahal.es/" target="_blank">http://www.arahal.es/</a>--%>
</p>
                    <p><strong>E-mail:</strong> <a href="mailto:jauja@aytolucena.es">jauja@aytolucena.es  </a><br />
                        <strong>Web:</strong> <a href="https://www.aytolucena.es/" target="_blank">https://www.aytolucena.es/</a>
 </p>
            
        </div>
              
               

              </div>
              <div class="col-md-6 col-sm-6"> 
              <img class="img-bdr" src="/images/townguide/jauja/jauja.jpg" alt="Town Hall, Jauja"/> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"/></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>Jauja <asp:Literal ID="Literal18" Text="<%$Resources:Resource,   Information %>" runat="server"></asp:Literal></h3>
              </div>
            </div>
          </div>
              <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID="Literal19" Text="<%$Resources:Resource, JaujaLocationDetail2 %>" runat="server"></asp:Literal> </p>      
                     <p><asp:Literal ID="Literal20" Text="<%$Resources:Resource, JaujaLocationDetail3 %>" runat="server"></asp:Literal></p>
                      </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr"  src="/images/townguide/jauja/jauja-2.jpg" alt=" Jauja village"/></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
             <p><asp:Literal ID="Literal21" Text="<%$Resources:Resource, JaujaLocationDetail4 %>" runat="server"></asp:Literal></p>
        <p><asp:Literal ID="Literal22" Text="<%$Resources:Resource, JaujaLocationDetail5 %>" runat="server"></asp:Literal></p>
           
              </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/townguide/jauja/jauja-3.jpg" alt=" Jauja village"/></div>
            </div>
          </div>
              <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
            <p><asp:Literal ID="Literal23" Text="<%$Resources:Resource, JaujaLocationDetail6 %>" runat="server"></asp:Literal></p>
           <p><asp:Literal ID="Literal24" Text="<%$Resources:Resource, JaujaLocationDetail7 %>" runat="server"></asp:Literal></p>
       

                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/townguide/jauja/jauja-4.jpg" alt="Jauja street"/></div>
            </div>
          </div>
             
             <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                         <p><asp:Literal ID="Literal26" Text="<%$Resources:Resource, JaujaLocationDetail8 %>" runat="server"></asp:Literal></p>
       

            <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal25' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a> </p>
                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/townguide/jauja/jauja-1.jpg" alt=" Jauja village"/></div>
            </div>
          </div>
               <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                        

                    </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/townguide/jauja/jauja-5.jpg" alt="Jauja street"/></div>
            </div>
          </div>
          <!-- Detail three Start -->
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

