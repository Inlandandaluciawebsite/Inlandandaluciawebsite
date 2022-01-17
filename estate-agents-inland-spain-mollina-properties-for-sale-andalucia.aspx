<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="estate-agents-inland-spain-mollina-properties-for-sale-andalucia.aspx.vb" Inherits="MollinaLocationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
       
              <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Mollina Andalucia</h1></div>
           <div class="col-md-4"><a href="propsearch.aspx?page=1&regionid=4&areaid=755&SubAreaId=0&sort=price_asc"><asp:Literal ID='Literal16' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a></div>  
              </div>
            </div>
          </div>

          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
                <p><asp:Literal ID='Literal1' Text='<%$Resources:Resource, MollinaLocationDetail %>' runat='server'></asp:Literal></p>
              </div>
            </div>
          </div>
          <!-- Detail one Strat -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationAbout %>' runat='server'></asp:Literal> Mollina, Málaga:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png" alt="plan"/>
                  <p>4.800 <asp:Literal ID='Literal3' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png" alt="plan"/>
                  <p><asp:Literal ID='Literal4' Text='<%$Resources:Resource, schools %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png" alt="plan"/>
                  <p>Antequera 16km
                    Málaga 65km
                    Granada 110km
                    Sevilla 145km
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>65km <asp:Literal ID='Literal5' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png" alt="plan"/>
                  <p><asp:Literal ID='Literal6' Text='<%$Resources:Resource, healthclinic %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png" alt="plan"/>
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, muncipalpool %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png" alt="plan"/>
                  <p><asp:Literal ID='Literal8' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal> 1h
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>110km <asp:Literal ID='Literal9' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png" alt="plan"/>
                  <p><asp:Literal ID='Literal10' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png" alt="plan"/>
                  <p><asp:Literal ID='Literal11' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png" alt="plan"/>
                  <p><asp:Literal ID='Literal12' Text='<%$Resources:Resource, busservice %>' runat='server'></asp:Literal>
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png" alt="plan"/>
                  <p>145km <asp:Literal ID='Literal13' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal>
                  
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
                  <h3>
<asp:Literal ID='Literal14' Text='<%$Resources:Resource, propertiesforsale %>' runat='server'></asp:Literal> Mollina </h3>
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
                <h4><asp:Literal ID='Literal15' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal></h4>
                <img src="/images/mollina_coa.jpg">
                <h5>Ayuntamiento de Mollina</h5>
                <p>Calle de La Villa, 
                  3 29532 Mollina, Màlaga, Spain 
                  Telephone: 952-740-044 </p>
                 <a href="http://www.mollina.org/" title="Offical Mollina website" target="_blank">http://www.mollina.org/</a></div>
              <div class="col-md-6 col-sm-6"> <img class="img-bdr mrg-10t"  src="/images/mollina1 (1).jpg"/> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png" alt="plan"/></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
                <h3>Mollina <asp:Literal ID='Literal17' Text='<%$Resources:Resource, Information %>' runat='server'></asp:Literal></h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
                  <p><asp:Literal ID='Literal18' Text='<%$Resources:Resource, MollinaLocationDetail1 %>' runat='server'></asp:Literal></p>
                  <p><asp:Literal ID='Literal19' Text='<%$Resources:Resource, MollinaLocationDetail2 %>' runat='server'></asp:Literal></p>
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl"> <img class="img-bdr" src="/images/mollina5.jpg" alt="plan"/></div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                <p><asp:Literal ID='Literal20' Text='<%$Resources:Resource, MollinaLocationDetail3 %>' runat='server'></asp:Literal></p>
                <p><asp:Literal ID='Literal21' Text='<%$Resources:Resource, MollinaLocationDetail4 %>' runat='server'></asp:Literal></p>
              </div>
             <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/mollina6 (1).jpg" alt="plan"/></div>
            </div>
          </div>
          <!-- Detail three Start -->
          
         
          
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl ">
             
              <div class="col-md-8 col-sm-8">
                <p><asp:Literal ID='Literal22' Text='<%$Resources:Resource, MollinaLocationDetail5 %>' runat='server'></asp:Literal></p>
                <p><asp:Literal ID='Literal23' Text='<%$Resources:Resource, MollinaLocationDetail6 %>' runat='server'></asp:Literal></p>
              </div>
              
               <div class="col-md-4 col-sm-4"><img class="img-bdr" src="/images/mollina2.jpg" alt="plan"/></div>
            </div>
          </div>
          
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
            
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                <p><asp:Literal ID='Literal24' Text='<%$Resources:Resource, MollinaLocationDetail7 %>' runat='server'></asp:Literal></p>
                </div>
                  <div class="col-md-4 col-sm-4"> <img class="img-bdr" src="/images/mollina3.jpg" alt="plan"/></div>
                
            </div>
          </div>
          
          
          <div class="row">
            <div class="mollina-information-dtl">
               <div class="col-md-8 col-sm-8">
                <img class="img-bdr" src="/images/mollina4.jpg" alt="plan"/>
                <img class="img-bdr" src="/images/mollina8.jpg" alt="plan"/>
               </div>
        </div>
      </div>
             <div class="row">
            <div class="mollina-information-dtl">
            
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
                <p>      <a href="TownLocationInfo.aspx" title="More information on towns of Andalucia">
  <asp:Literal ID='Literal25' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal></a></p>
                  
                   </div>
                  
            </div>
          </div>

          
          
          
          
          
        </div>
        <!-- Detail three Start --> 
        
</asp:Content>

