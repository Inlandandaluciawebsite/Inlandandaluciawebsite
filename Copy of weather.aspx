<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Copy of weather.aspx.vb" Inherits="weather" %>

<%@ Register Src="~/Controls/WebUserControlTownGuid.ascx" TagPrefix="uc1" TagName="WebUserControlTownGuid" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- Main Content Area Start -->
 
        <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
          <div class="row">
            <div class="col-md-12">
              <div class="town-guide-hd">
                <h1>The weather in Andalucia:</h1>
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="weather">
               <p><asp:Literal ID="Literal3" Text="<%$Resources:Resource, Weathercheckforecast %>" runat="server"></asp:Literal></p>
                 </div>
            </div>
          </div>
          <!-- Detail one Strat --> 
          
          <!-- Detail Two Strat -->
          
          
          <div class="row">
            <div class="weather">
            <div class="col-md-12 col-sm-12">
                <div class="weather loc-img">
                    <%--<img class="img-bdr" src="images/weather.jpg">--%>
                  
  <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" style="width: 70%;height:317px;margin-top: 5px;" >
    <param name="movie" value="Flash/andalusiaweathermap.swf">
    <param name="quality" value="high">
    <embed src="Flash/andalusiaweathermap.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" style="width: 70%;height:317px;margin-top: 5px;" class="img-bdr"></embed>
  </object>

                </div>
                <p><asp:Literal ID="Literal1" Text="<%$Resources:Resource, Weatherchecktown %>" runat="server"></asp:Literal></p>
              </div>
            </div>
          </div>
          
          
          <div class="row">
            <div class="weather">
              <div class="col-md-6 col-sm-6">
            
             <ul>
               <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0052" title="Click here to check Weather Forecast in Malaga Province, Andalusia, Spain"  target="_blank">MALAGA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0089" title="Click here to check Weather Forecast in Antequera, Andalusia, Spain"  target="_blank">Antequera</a></li>
                            <li><i class="fa fa-plus"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0121" title="Click here to check Weather Forecast in Ronda, Andalusia, Spain" target="_blank">Ronda</a></li>
                             <li><i class="fa fa-plus"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0054" title="Click here to check Weather Forecast in Marbella, Andalusia, Spain"  target="_blank">Marbella</a></li>
                          </ul>
               </li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0220" title="Click here to check Weather Forecast in Cordoba Province, Andalusia, Spain"  target="_blank">CORDOBA</a></li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0040" title="Click here to check Weather Forecast in Granada Province, Andalusia, Spain"  target="_blank">GRANADA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0042" title="Click here to check Weather Forecast in Guadix, Andalusia, Spain"  target="_blank">Guadix</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0058" title="Click here to check Weather Forecast in Motril, Andalusia, Spain"  target="_blank">Motril</a></li>
                            
                          </ul>
               </li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0017" title="Click here to check Weather Forecast in Cadiz Province, Andalusia, Spain"  target="_blank">CADIZ</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0046" title="Click here to check Weather Forecast in Jerez de la Frontera, Andalusia, Spain"  target="_blank">Jerez de la Frontera</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0088" title="Click here to check Weather Forecast in Algeciras, Andalusia, Spain"  target="_blank">Algeciras</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0237?from=search" title="Click here to check Weather Forecast in Tarifa, Andalusia, Spain"  target="_blank">Tarifa</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/GIXX0001?from=search" title="Click here to check Weather Forecast in Gibraltar, Andalusia, Spain"  target="_blank">Gibraltar</a>
</li>
                            
                          </ul>
               </li>
              
             </ul>
                  
              </div>
              
              <div class="col-md-6 col-sm-6">
            
             <ul>
               <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0009" title="Click here to check Weather Forecast in Almeria Province, Andalusia, Spain"  target="_blank">ALMERIA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0032" title="Click here to check Weather Forecast in El Ejido, Andalusia, Spain"  target="_blank">El Ejido</a></li>
                           
                          </ul>
               </li>
               
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0074" title="Click here to check Weather Forecast in Sevilla Province, Andalusia, Spain"  target="_blank">SEVILLA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0028" title="Click here to check Weather Forecast in Ecija, Andalusia, Spain"  target="_blank">Ecija</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0081" title="Click here to check Weather Forecast in Utrera, Andalusia, Spain" target="_blank">Utrera</a></li>
                            
                          </ul>
               </li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0225" title="Click here to check Weather Forecast in Huelva Province, Andalusia, Spain"  target="_blank">HUELVA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0092?from=search" title="Click here to check Weather Forecast in Ayamonte, Andalusia, Spain"  target="_blank">Ayamonte</a></li>
                            <li><i class="fa fa-plus"></i> <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0090" title="Click here to check Weather Forecast in Aracena, Andalusia, Spain"  target="_blank">Aracena</a></li>
                            
                            
                          </ul>
               </li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0045" title="Click here to check Weather Forecast in Jaen Province, Andalusia, Spain"  target="_blank">JAEN</a>
                           <ul>
                           <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/outlook/travel/businesstraveler/local/SPXX0098" title="Click here to check Weather Forecast in Cazorla, Andalusia, Spain" target="_blank">Cazorla</a></li>
                          
                            
                            
                          </ul>
               </li>
              
             </ul>
                  
              </div>
              
            </div>
          </div>
          
          
          
          
          
          
          
          
          
          
          
          
          <div class="row">
               <div class="col-md-12 col-sm-12">
              <div class="weather-map-lk">
                 <a href="LocationMapInlandTowns.aspx" title="Click here to see a Location Map" ><asp:Literal ID="Literal2" Text="<%$Resources:Resource, Weatherclickhere %>" runat="server"></asp:Literal> </a>
               </div>
           </div>
          </div>
          
          
            
          <div class="row">
             <div class="col-md-12">
             <div class="divider"><img src="images/divider.png"></div>
             </div>
          </div>
          
          
          <!-- Sorted By Provinance Start -->
          <div class="row">
            <div class="col-md-12">
          <div class="weather">  <p><strong><asp:Literal ID="Literal4" Text="<%$Resources:Resource, Weatherbelowlist %>" runat="server"></asp:Literal></p></strong></div>
            </div> 
                     </div>
            
            <uc1:WebUserControlTownGuid runat="server" ID="WebUserControlTownGuid" />
          <!-- Sorted by Provinance End -->
          
          
          
          <!-- Detail Two End --> 
          
        </div>
        <!-- Left Portion End --> 
        
        <!-- Right Portion Start -->
      
</asp:Content>

