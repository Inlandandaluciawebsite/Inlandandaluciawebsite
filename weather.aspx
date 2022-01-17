<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="weather.aspx.vb" Inherits="weather" %>

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
                <h1><asp:Literal ID="Literal1" Text="<%$Resources:Resource, theweatherinandalucai %>" runat="server"></asp:Literal>:</h1>
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
                <div class="weather wthertest loc-img" style="width: 525px;
margin: 0px auto;
float: none;">  
                    <%--<img class="img-bdr" src="/images/weather.jpg">--%>
              
<map id="imgmap2016121151238" name="imgmap2016121151238" >
<area shape="poly" alt="cordoba" title="" coords="181,80,181,58,182,53,185,48,186,45,190,41,198,34,203,33,206,32,208,32,209,32,212,25,217,19,219,17,223,16,226,16,230,19,234,22,237,27,239,29,241,33,243,35,248,37,254,41,258,45,262,49,268,52,282,59,286,60,290,61,292,63,293,65,294,68,295,72,297,75,300,78,301,80,300,83,298,85,296,86,294,90,294,93,292,96,293,100,294,104,294,108,292,112,292,112,290,113,293,116,294,116,295,117,296,119,297,125,299,125,299,128,299,131,298,134,299,139,303,142,304,146,307,149,310,153,311,156,310,158,308,159,305,159,303,160,302,163,301,165,298,165,297,166,294,169,292,173,289,175,287,176,285,175,283,173,279,170,276,169,273,170,271,170,268,171,266,174,264,174,262,172,259,171,257,171,257,169,250,163,246,159,243,155,236,146,231,139,232,139,232,135,232,131,231,128,230,125,228,125,226,124,224,126,221,127,220,126,219,125,217,125,215,125,208,129,204,131,203,132,202,129,202,121,199,115,195,108,193,106,193,102,193,99,190,97,188,95,188,95,186,89,183,83,179,75,177,68,177,61,182,54,182,54" 
href="http://www.weather.com/weather/today/l/SPXX0024:1:SP" target="_blank" />

<area shape="poly" alt="Jaen" title="" coords="439,60,440,71,439,77,438,80,436,84,436,86,433,86,431,88,431,91,431,93,428,95,425,97,421,100,416,103,414,105,411,109,407,116,404,121,401,126,399,130,396,134,393,134,392,134,389,132,385,131,382,130,379,129,375,131,371,134,368,137,366,140,363,136,361,135,357,134,351,135,349,137,342,141,337,142,333,144,331,147,328,150,328,154,326,157,321,156,317,156,314,155,312,153,309,148,305,144,303,139,301,135,301,131,302,130,301,125,299,122,298,117,296,115,294,114,295,110,297,106,296,100,295,96,296,92,297,89,300,87,302,84,303,81,303,78,300,76,299,72,297,68,295,62,295,61,300,58,303,57,310,56,313,57,321,57,327,56,332,58,336,60,341,57,345,55,349,52,354,52,357,54,362,54,364,50,367,48,368,45,370,44,373,46,378,48,380,48,384,48,387,49,390,52,394,53,397,53,398,50,402,48,408,46,412,44,418,42,422,41,428,44,433,48,436,51,439,55,439,56,440,62"
 href="http://www.weather.com/weather/today/l/SPXX0045:1:SP" target="_blank" />
 
 <area shape="poly" alt="" title="" coords="332,229,333,224,334,222,333,219,332,217,329,215,325,213,321,212,318,210,316,209,312,209,311,209,309,207,306,205,301,202,298,201,295,197,293,193,291,187,289,180,287,177,289,177,292,175,295,171,297,169,299,167,300,166,304,165,305,162,309,160,311,160,312,158,313,156,316,157,319,158,324,158,327,158,329,156,329,153,330,150,333,146,338,144,344,142,348,140,350,138,353,136,356,136,359,136,362,139,365,140,366,142,369,138,375,134,379,132,382,132,386,133,390,135,393,135,396,136,399,134,402,127,409,117,412,111,416,105,420,102,424,100,428,97,430,95,432,93,433,89,436,91,439,92,443,92,446,93,451,93,453,94,455,97,458,99,460,102,463,102,464,103,462,105,459,110,458,113,460,117,460,119,459,122,456,126,456,130,457,132,453,134,450,137,452,140,453,145,452,147,449,148,444,150,437,153,436,153,434,155,434,157,430,159,429,165,429,173,428,176,424,177,421,176,420,174,417,171,415,171,411,172,409,175,407,179,403,186,401,191,398,191,400,195,400,199,400,202,398,205,393,207,394,209,392,211,394,213,395,215,395,218,393,219,390,220,388,224,385,228,383,228,372,228,365,231,359,232,353,232,336,230,331,228" 
 href="http://www.weather.com/weather/today/l/SPXX0040:1:SP" target="_blank" />
 
 <area shape="poly" alt="almeria" title="" coords="513,163,511,164,509,167,506,172,502,176,499,181,498,185,496,189,495,194,493,200,493,202,491,205,486,208,483,214,480,218,475,224,471,227,467,228,460,226,456,223,452,219,448,217,443,216,440,218,436,221,433,225,432,229,429,232,420,233,414,232,407,229,400,227,387,228,388,225,390,222,394,220,395,218,396,214,396,212,394,210,396,208,399,206,401,203,402,200,402,196,400,192,403,190,407,183,408,179,410,176,411,174,415,173,417,173,418,175,421,178,426,178,428,177,430,175,430,172,431,167,431,163,432,160,434,158,436,157,436,154,439,153,442,152,445,151,449,149,452,148,454,146,454,143,454,140,452,138,453,136,455,134,457,133,458,132,458,129,458,126,459,124,460,121,461,120,462,117,461,115,460,112,460,110,462,108,462,106,464,104,464,104,467,103,470,104,474,105,477,107,479,109,481,113,482,116,481,120,480,123,480,127,482,134,484,139,487,143,492,148,496,149,501,153,506,157,510,160,512,162"
  href="http://www.weather.com/weather/today/l/SPXX0009:1:SP" target="_blank" />
  
  <area shape="poly" alt="cadiz" title="" coords="103,219,105,218,105,216,104,214,105,212,107,210,109,208,112,207,117,206,122,206,125,207,127,208,130,210,133,212,134,213,143,213,146,213,147,210,148,208,152,206,156,206,159,205,161,206,163,206,165,203,167,201,169,201,173,203,176,205,179,204,182,203,185,204,186,205,190,202,193,200,194,200,196,198,197,196,199,195,202,197,204,198,205,201,206,204,207,201,211,199,213,198,217,200,217,204,217,209,216,212,216,214,215,216,214,217,211,218,207,216,205,215,203,213,200,214,197,214,196,216,197,219,199,221,200,226,198,228,197,234,194,236,192,239,190,241,189,246,190,251,190,253,193,256,194,258,195,262,196,265,198,267,200,269,200,271,198,274,195,280,192,287,189,291,185,296,178,301,174,302,170,302,169,300,167,298,164,295,161,295,155,294,151,292,148,288,145,285,141,284,134,281,130,277,126,275,123,270,121,266,119,262,118,258,119,254,120,248,119,246,116,242,112,239,108,235,105,231,103,228,102,223,102,220,102,220"
   href="http://www.weather.com/weather/today/l/SPXX0017:1:SP" target="_blank" />
   
   <area shape="poly" alt="malaga" title="" coords="252,254,245,255,242,254,239,253,235,252,231,253,228,255,223,256,218,257,213,258,207,261,203,264,202,268,200,267,198,264,197,261,196,258,195,256,193,253,191,250,191,244,193,240,194,238,197,235,199,231,200,227,201,225,201,222,199,219,198,217,199,214,202,214,203,215,205,216,208,218,211,218,213,218,216,217,217,215,218,212,219,208,220,205,219,201,218,199,216,198,216,197,217,195,219,194,221,193,224,194,226,192,228,190,231,187,233,187,233,185,233,184,234,182,234,180,236,181,239,180,240,178,244,178,245,179,247,181,250,179,251,177,250,175,252,174,255,173,259,173,262,175,264,176,267,176,269,174,271,172,275,171,278,171,285,178,287,180,288,185,290,191,291,195,295,202,299,204,302,206,305,207,309,210,310,211,313,211,315,211,318,212,321,214,325,215,328,216,329,216,331,218,332,220,332,222,331,224,330,229,329,230,325,230,320,231,311,231,304,231,299,231,290,231,284,232,279,233,277,233,274,235,273,237,271,240,269,242,265,245,259,249,255,252,252,254" 
   href="http://www.weather.com/weather/today/l/SPXX0052:1:SP" target="_blank" />
   
   <area shape="poly" alt="sevilla" title="" coords="123,99,127,97,132,94,136,95,141,94,145,94,148,89,151,83,155,79,159,79,167,80,171,82,178,80,180,80,183,86,186,93,189,98,192,100,192,107,194,110,197,114,200,120,200,127,201,132,203,133,208,131,211,129,215,126,217,126,220,128,222,129,224,127,226,126,229,126,231,131,231,137,230,141,239,152,243,158,249,165,254,168,255,171,251,172,249,174,249,177,248,178,247,179,246,177,243,176,241,176,238,178,236,180,234,178,233,180,232,183,231,185,230,186,226,190,224,193,221,191,217,194,215,195,215,198,213,197,209,199,206,202,206,199,204,196,202,196,199,193,196,195,195,198,192,200,188,202,186,203,183,201,178,202,176,204,173,201,169,200,165,201,163,204,161,204,157,204,151,205,148,207,146,209,145,212,140,211,135,212,134,212,130,209,128,207,125,205,120,205,112,205,109,207,107,205,106,200,105,195,104,191,105,184,106,177,106,171,106,169,107,161,108,152,107,149,105,144,104,141,101,138,98,136,95,132,93,127,93,125,94,121,95,118,100,114,110,110,114,106,121,101" 
   href="http://www.weather.com/weather/today/l/SPAN0049:1:SP" target="_blank" />
   
   <area shape="poly" alt="huelva" title="" coords="58,81,60,79,61,77,64,75,66,74,69,74,72,76,76,80,81,80,87,81,90,81,93,85,99,89,106,89,111,88,115,91,118,95,120,98,121,99,117,102,112,106,109,109,103,111,98,114,95,117,93,119,92,126,92,131,96,136,102,141,104,144,106,150,105,161,105,169,104,179,103,185,103,190,104,197,106,203,107,207,106,209,104,212,103,213,102,212,100,209,98,206,96,201,90,197,83,193,76,188,68,184,61,180,57,178,50,176,48,176,38,176,23,176,19,174,18,170,19,165,18,160,16,158,17,153,18,149,15,146,13,139,14,132,17,127,27,116,34,110,37,103,38,96,41,93,48,93,57,93,59,88,57,85" href="http://www.weather.com/weather/today/l/SPXX0225:1:SP" target="blank" /><!-- Created by Online Image Map Editor (http://www.maschek.hu/imagemap/index) --></map>
<img class="map" src="/images/mapw.jpg" usemap="#imgmap2016121151238"  />
<%--  <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" style="width: 70%;height:317px;margin-top: 5px;" >
    <param name="movie" value="Flash/andalusiaweathermap.swf">
    <param name="quality" value="high">
    <embed src="Flash/andalusiaweathermap.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" style="width: 70%;height:317px;margin-top: 5px;" class="img-bdr"></embed>
  </object>--%>

                </div>
                <p><asp:Literal ID="Literal5" Text="<%$Resources:Resource, Weatherchecktown %>" runat="server"></asp:Literal></p>
              </div>
            </div>
          </div>
          
          
          <div class="row">
            <div class="weather">
              <div class="col-md-6 col-sm-6">
            
             <ul>
               <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/weather/today/l/SPXX0052:1:SP" title="Click here to check Weather Forecast in Malaga Province, Andalusia, Spain"  target="_blank">MALAGA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/weather/today/l/SPXX0089:1:SP" title="Click here to check Weather Forecast in Antequera, Andalusia, Spain"  target="_blank">Antequera</a></li>
                            <li><i class="fa fa-plus"></i><a href="http://www.weather.com/weather/today/l/SPXX0121:1:SP" title="Click here to check Weather Forecast in Ronda, Andalusia, Spain" target="_blank">Ronda</a></li>
                             <li><i class="fa fa-plus"></i><a href="http://www.weather.com/weather/today/l/SPXX0054:1:SP" title="Click here to check Weather Forecast in Marbella, Andalusia, Spain"  target="_blank">Marbella</a></li>
                          </ul>
               </li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/weather/today/l/SPXX0220:1:SP" title="Click here to check Weather Forecast in Cordoba Province, Andalusia, Spain"  target="_blank">CORDOBA</a></li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/weather/today/l/SPXX0040:1:SP" title="Click here to check Weather Forecast in Granada Province, Andalusia, Spain"  target="_blank">GRANADA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/weather/today/l/SPXX0042:1:SP" title="Click here to check Weather Forecast in Guadix, Andalusia, Spain"  target="_blank">Guadix</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/weather/today/l/SPXX0058:1:SP" title="Click here to check Weather Forecast in Motril, Andalusia, Spain"  target="_blank">Motril</a></li>
                            
                          </ul>
               </li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/weather/today/l/SPXX0017:1:SP" title="Click here to check Weather Forecast in Cadiz Province, Andalusia, Spain"  target="_blank">CADIZ</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/weather/today/l/SPXX0046:1:SP" title="Click here to check Weather Forecast in Jerez de la Frontera, Andalusia, Spain"  target="_blank">Jerez de la Frontera</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/weather/today/l/SPXX0088:1:SP" title="Click here to check Weather Forecast in Algeciras, Andalusia, Spain"  target="_blank">Algeciras</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/weather/today/l/SPGR0471:1:SP" title="Click here to check Weather Forecast in Tarifa, Andalusia, Spain"  target="_blank">Tarifa</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/weather/today/l/GIXX0001:1:GI" title="Click here to check Weather Forecast in Gibraltar, Andalusia, Spain"  target="_blank">Gibraltar</a>
</li>
                            
                          </ul>
               </li>
              
             </ul>
                  
              </div>
              
              <div class="col-md-6 col-sm-6">
            
             <ul>
               <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/weather/today/l/SPXX0009:1:SP" title="Click here to check Weather Forecast in Almeria Province, Andalusia, Spain"  target="_blank">ALMERIA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/weather/today/l/SPXX0032:1:SP" title="Click here to check Weather Forecast in El Ejido, Andalusia, Spain"  target="_blank">El Ejido</a></li>
                           
                          </ul>
               </li>
               
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/weather/today/l//SPXX0074:1:SP" title="Click here to check Weather Forecast in Sevilla Province, Andalusia, Spain"  target="_blank">SEVILLA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/weather/today/l/SPXX0028:1:SP" title="Click here to check Weather Forecast in Ecija, Andalusia, Spain"  target="_blank">Ecija</a></li>
                            <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/weather/today/l/SPXX0081:1:SP" title="Click here to check Weather Forecast in Utrera, Andalusia, Spain" target="_blank">Utrera</a></li>
                            
                          </ul>
               </li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/weather/today/l/SPXX0225:1:SP" title="Click here to check Weather Forecast in Huelva Province, Andalusia, Spain"  target="_blank">HUELVA</a>
                           <ul>
                           <li><i class="fa fa-plus"></i><a href="http://www.weather.com/weather/today/l/SPXX0092:1:SP" title="Click here to check Weather Forecast in Ayamonte, Andalusia, Spain"  target="_blank">Ayamonte</a></li>
                            <li><i class="fa fa-plus"></i> <a href="http://www.weather.com/weather/today/l/SPXX0090:1:SP" title="Click here to check Weather Forecast in Aracena, Andalusia, Spain"  target="_blank">Aracena</a></li>
                            
                            
                          </ul>
               </li>
                <li><i class="fa fa-arrow-right"></i><a href="http://www.weather.com/weather/today/l/SPXX0045:1:SP" title="Click here to check Weather Forecast in Jaen Province, Andalusia, Spain"  target="_blank">JAEN</a>
                           <ul>
                           <li><i class="fa fa-plus"></i>  <a href="http://www.weather.com/weather/today/l/SPXX0098:1:SP" title="Click here to check Weather Forecast in Cazorla, Andalusia, Spain" target="_blank">Cazorla</a></li>
                          
                            
                            
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
             <div class="divider"><img src="/images/divider.png"></div>
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

