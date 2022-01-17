<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="fuente-tojar-cordoba.aspx.vb" Inherits="fuente_tojar_cordoba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- View trip listing Start -->
     
             <div class="row">
            <div class="">
              <div class="town-guide-hd">
                    <div class="col-md-8"> <h1>Fuente Tojar Andalucia</h1></div>
           <div class="col-md-4">
               <a href="http://inlandandalucia.hashsoftwares.com/propsearch.aspx?page=1&regionid=1&areaid=444&SubAreaId=0"><asp:Literal ID='Literal12' Text='<%$Resources:Resource, Viewpropertiesinthistown %>' runat='server'></asp:Literal></a>
           </div>  
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="cordoba-details">
<p><asp:Literal ID='Literal1' Text='<%$Resources:Resource, FuentetojarDetail %>' runat='server'></asp:Literal> </p>          <!-- Detail one Strat -->
          </div> 
                </div>
              </div> 
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Quick information about Mollina  Start-->
          <div class="row">
            <div class="col-md-12">
              <div class="quick-information-about-mollina">
                <h3><asp:Literal ID='Literal2' Text='<%$Resources:Resource, QuickInformationAbout %>' runat='server'></asp:Literal>  Fuente Tojar:</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="map-pin">
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/residents.png">
                  <p>  744 (2013)<asp:Literal ID='Literal22' Text='<%$Resources:Resource, residents %>' runat='server'></asp:Literal> 
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/school.png">
                  <p><asp:Literal ID='Literal3' Text='<%$Resources:Resource, schoolnearby %>' runat='server'></asp:Literal> 
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/car.png">
                  <p>
Antequera 98km
Malaga 142km
Granada 75km
Sevilla 199km
                  
                  </p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>142km <asp:Literal ID='Literal4' Text='<%$Resources:Resource, tomalega %>' runat='server'></asp:Literal> 
                  
                  </p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/hospital.png">
                  <p><asp:Literal ID='Literal5' Text='<%$Resources:Resource, doctor %>' runat='server'></asp:Literal> 
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pool.png">
                  <p><asp:Literal ID='Literal6' Text='<%$Resources:Resource, poolnearby %>' runat='server'></asp:Literal> 
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/Beach.png">
                  <p><asp:Literal ID='Literal7' Text='<%$Resources:Resource, beach %>' runat='server'></asp:Literal>  1h30
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>75km  <asp:Literal ID='Literal8' Text='<%$Resources:Resource, togranada %>' runat='server'></asp:Literal> 
                  
                  <p> 
                </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="map-pin-inner"> <img src="/images/shopping.png">
                  <p><asp:Literal ID='Literal9' Text='<%$Resources:Resource, shopsbars %>' runat='server'></asp:Literal> 
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/golf.png">
                  <p><asp:Literal ID='Literal10' Text='<%$Resources:Resource, golfnearby %>' runat='server'></asp:Literal> 
                  
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/bus.png">
                  <p><asp:Literal ID='Literal11' Text='<%$Resources:Resource, busservice %>' runat='server'></asp:Literal> 
                  <p> 
                </div>
                <div class="map-pin-inner"> <img src="/images/pln.png">
                  <p>199km  <asp:Literal ID='Literal13' Text='<%$Resources:Resource, tosevilla %>' runat='server'></asp:Literal> 
                  
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
                  <h3>Fuente Tojar <asp:Literal ID='Literal14' Text='<%$Resources:Resource, Location %>' runat='server'></asp:Literal> </h3>
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3164.9010359615!2d-4.146383200000016!3d37.51025220000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd6d9425d57a24ef%3A0x86e50354a69cdffa!2s14815+Fuente+T%C3%B3jar%2C+C%C3%B3rdoba%2C+Spain!5e0!3m2!1sen!2suk!4v1411496032955" width="620" height="450" frameborder="0" style="border:0"></iframe>

              </div>
            </div>
          </div>
          
          <!--Properties for sale in Mollina -->
      <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Location Information Start -->
          <div class="row">
            <div class="location-info">
              <div class="col-md-6 col-sm-6">
                <h4><asp:Literal ID='Literal15' Text='<%$Resources:Resource, LocalInformation %>' runat='server'></asp:Literal> </h4>
              <img src="/images/townguide/fuentetojar/fuentetojar-coa.gif" alt="Fuente Tojar Coat of Arms" >
                <h5>Fuente Tojar Town Hall</h5>
                 <p><strong>Ayuntamiento de 
                          Fuente Tojar</strong><br>
                          <strong>Address:</strong> c/ Castil de Campos, 4, 14815, <br>
              Fuente Tójar (Córdoba)<br>
              <strong>Telephone:</strong> <span class="skype_c2c_print_container notranslate">957 556 028</span><span id="skype_c2c_container" class="skype_c2c_container notranslate" dir="ltr" tabindex="-1" onmouseover="SkypeClick2Call.MenuInjectionHandler.showMenu(this, event)" onmouseout="SkypeClick2Call.MenuInjectionHandler.hideMenu(this, event)" onclick="SkypeClick2Call.MenuInjectionHandler.makeCall(this, event)" data-numbertocall="+34957556028" data-numbertype="paid" data-isfreecall="false" data-isrtl="false" data-ismobile="false"><span class="skype_c2c_highlighting_inactive_common" dir="ltr" skypeaction="skype_dropdown"><span class="skype_c2c_textarea_span" id="non_free_num_ui"><img class="skype_c2c_logo_img" src="resource://skype_ff_extension-at-jetpack/skype_ff_extension/data/call_skype_logo.png" height="0" width="0"><span class="skype_c2c_text_span">957 556 028</span><span class="skype_c2c_free_text_span"></span></span></span></span>  <br>
              <strong>Fax:</strong> 957 705 060<br>
    <strong>E-mail:</strong> <a href="administraciongeneral@fuente-tojar.es&nbsp;">administraciongeneral@fuente-tojar.es </a><br>
    <a href="http://www.fuente-tojar.es/" target="_blank">http://www.fuente-tojar.es</a>

                   
   </p>

              </div>
              <div class="col-md-6 col-sm-6"> 
        <%--      <img class="img-bdr mrg-10t"  src="/images/townguide/encinas-reales/encinas.jpg" alt="Town Hall, Encinas Reales">--%> </div>
            </div>
          </div>
          
          <!-- Location Information End -->
          
          <div class="divider"><img src="/images/divider.png"></div>
          
          <!-- Detail Two Strat -->
          <div class="row">
            <div class="cordoba-details-2">
              <div class="col-md-12">
           <h3>
<asp:Literal ID='Literal16' Text='<%$Resources:Resource, About %>' runat='server'></asp:Literal>  Fuente Tojar</h3>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="mollina-information-dtl">
              <div class="col-md-8 col-sm-8">
                <div class="mollina-information-dtl">
<p><asp:Literal ID='Literal17' Text='<%$Resources:Resource, FuentetojarDetail1 %>' runat='server'></asp:Literal> </p>       
<p><asp:Literal ID='Literal18' Text='<%$Resources:Resource, FuentetojarDetail2 %>' runat='server'></asp:Literal> .</p>                    
                   <p><asp:Literal ID='Literal19' Text='<%$Resources:Resource, FuentetojarDetail3 %>' runat='server'></asp:Literal> </p>
                      </div>
              </div>
              <div class="col-md-4 col-sm-4">
                <div class="mollina-information-dtl">
                     <img class="img-bdr" src="/images/townguide/fuentetojar/fuentetojar1.jpg" alt="Fuente Tojar">
                     <img class="img-bdr" src="/images/townguide/fuentetojar/fuentetojar2.jpg" alt="Fuente Tojar">

                </div>
              </div>
            </div>
          </div>
          
          <!-- Detail Two End --> 
          <!-- Detail three Start -->
          <div class="row">
            <div class="mollina-information-dtl">
              
              <div class="col-md-8 col-sm-8 mollina-information-dtl-2">
<p><asp:Literal ID='Literal20' Text='<%$Resources:Resource, FuentetojarDetail4 %>' runat='server'></asp:Literal>  </p>   <p>»&nbsp;<a href="TownLocationInfo.aspx" title="More information on towns of Andalucia"><asp:Literal ID='Literal21' Text='<%$Resources:Resource, aguaduceLocationInfomoreinfo %>' runat='server'></asp:Literal> </a> </p>

              </div>
             <div class="col-md-4 col-sm-4">
                    </div>
            </div>
          </div>
             
       
         
          <!-- Detail three Start --> 
          
          <!-- Detail three Start -->
        </div>
        <!-- Detail three Start --> 
</asp:Content>

