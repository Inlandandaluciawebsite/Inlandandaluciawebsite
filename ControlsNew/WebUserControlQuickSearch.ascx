<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlQuickSearch.ascx.vb" Inherits="Controls_WebUserControlQuickSearch" %>
   
<SCRIPT type=text/javascript>
    function doClick(buttonName, e) {
        //the purpose of this function is to allow the enter key to 
        //point to the correct button to click.
        var key;

        if (window.event)
            key = window.event.keyCode;     //IE
        else
            key = e.which;     //firefox

        if (key == 13) {
            //Get the button the user wants to have clicked
            var btn = document.getElementById(buttonName);
            if (btn != null) { //If we find the button click it
               
                btn.click();
                event.keyCode = 0
            }
        }
    }
</SCRIPT>
 <div  class="col-md-4" style="display:block" runat="server" id="cuser">
          <div class="row"> 
                    <div class="related-links" id="buyer" runat="server" style="display:none" > 
            <h3> <asp:Literal ID="Literal3" Text="<%$Resources:Resource, BuyerRelatedLink  %>" runat="server"  ></asp:Literal></h3>
            <ul>
    <li>»&nbsp;<a href="BuyersGuide.aspx" title="Buying a Property"><asp:Literal ID="Literal4" Text="<%$Resources:Resource, BuyerBuyingProperty  %>" runat="server"  ></asp:Literal></a></li>
    <li>»&nbsp;<a href="BuyingProcess.aspx" title="Buying Process"><asp:Literal ID="Literal5" Text="<%$Resources:Resource, BuyerBuyingProcess  %>" runat="server"  ></asp:Literal></a></li>
    <li>»&nbsp;<a href="PropertyTaxes.aspx" title="Property Taxes"><asp:Literal ID="Literal6" Text="<%$Resources:Resource, BuyerPropertyTaxes  %>" runat="server"  ></asp:Literal></a></li>
    <li>»&nbsp;<a href="BuyersGuideFAQS.aspx" title="FAQS "><asp:Literal ID="Literal7" Text="<%$Resources:Resource, BuyerFaq %>" runat="server"  ></asp:Literal></a></li>
    <li>»&nbsp;<a href="BuyersGuideUnpaidTaxes.aspx" title="Unpaid Taxes "><asp:Literal ID="Literal8" Text="<%$Resources:Resource, BuyerUnpaidTaxes  %>" runat="server"  ></asp:Literal></a></li>
    <li>»&nbsp;<a href="BuyersGuideMortgage.aspx" title="Mortgage"><asp:Literal ID="Literal9" Text="<%$Resources:Resource, BuyerMortage  %>" runat="server"  ></asp:Literal></a>     </li>
  </ul>
            </div>
            <!-- Related Links End -->
            <!-- Quick links Start -->
            <div class="quick-links" id="quicksearchform" runat ="server"  >
              <div class="col-md-12">
                <h2> <asp:Literal ID="lblpSpecialist" Text="<%$Resources:Resource, QuickSearch  %>" runat="server"  ></asp:Literal></h2>
              </div>
              <div class="col-md-12">
                <div>
                  <div class="form-group">
                      <asp:DropDownList ID="DropDownListRegion" runat="server"  class="form-control-inland" > </asp:DropDownList>
               
                  </div>
                  <div class="form-group">
                     
        <asp:DropDownList ID="DropDownListPriceTo" runat="server" 
            class="form-control-inland"> </asp:DropDownList>
                  </div>
                  <div class="form-group">
                    <asp:DropDownList ID="DropDownListType" runat="server"  class="form-control-inland"> </asp:DropDownList>
                  </div>
                  <div class="form-group">
                   <asp:DropDownList 
            ID="DropDownListBedrooms" runat="server" class="form-control-inland">
                   
                        <asp:ListItem Text=" <%$Resources:Resource,   MinBed%>" Value="0"></asp:ListItem>
                       <asp:ListItem Text=" <%$Resources:Resource,   Any%>" Value="0"></asp:ListItem>
                                                      <asp:ListItem Text=" <%$Resources:Resource,   OneorMore%>" Value="1"></asp:ListItem>
                                                      <asp:ListItem Text=" <%$Resources:Resource,   TwoorMore%>" Value="2"></asp:ListItem>
                                                      <asp:ListItem Text=" <%$Resources:Resource,   ThreeorMore%>" Value="3"></asp:ListItem>
                                                      <asp:ListItem Text=" <%$Resources:Resource,   FourorMore%>" Value="4"></asp:ListItem>
                                                     <asp:ListItem Text=" <%$Resources:Resource,   FiveorMore%>" Value="5"></asp:ListItem>
                   </asp:DropDownList>
                  </div>
                </div>
                <div class="btn-sun-bg">
                 <%-- <button type="submit" class="btn btn-default but-sub">Submit</button>--%>
                    <asp:Button ID="btnsubmit" runat="server"  OnClick="btnsubmit_Click"  class="btn btn-default but-sub" Text=" <%$Resources:Resource,    btnSearch%>" />
                </div>
                        <asp:Panel ID="pTne" runat="server" DefaultButton="btnsubmitref">
                <div class="search-by-reference">
                  <h2><asp:Literal ID="Label1" Text="<%$Resources:Resource, QuickSearch  %>" runat="server"  ></asp:Literal></h2>
                  <div class="form-group">
            <asp:TextBox ID="txtrefnumb" runat="server" CssClass="form-control" style="text-transform:uppercase"></asp:TextBox>

                  </div>
                  <div class="btn-sun-bg">
                 <%--   <button type="submit" class="btn btn-default but-sub">Submit</button>--%>
                                          <asp:Button ID="btnsubmitref" runat="server" OnClick="btnsubmitref_Click"   class="btn btn-default but-sub" Text=" <%$Resources:Resource,    btnSearch%>"/>

                  </div>
                </div>
                            </asp:Panel>
              </div>
            </div>
            <!-- Quick links End --> 
            
            <!-- Top 50 Start -->
            <div class="top-fifty-outer" id="top50" runat="server" > <a href="Top50Properties.aspx" target="_blank"><asp:Literal ID="Literal1" Text="<%$Resources:Resource, Top50Image  %>" runat="server"  ></asp:Literal> </a> </div>
            <!-- Top 50 End --> 
            <%-- top 30 --%>
                <div class="top-fifty-outer" id="top30" runat="server"  style="display:none"> <a href="Top30Properties.aspx" target="_blank"><img src="/images/buttons/TOP30-button.png" alt="Top 30"></a> </div>
          
              <%-- top 30 --%>
            <!-- Click Here Start -->
            <div class="click-here-outer"> <a href="andalucia-property-viewing-trip.aspx"><asp:Literal ID="Literal2" Text="<%$Resources:Resource, ViewingImage  %>" runat="server"  ></asp:Literal></a> </div>
            <!-- Click Here End --> 
            
            <!-- Click Here Start -->
            <div class="safe-hand-outer">
              <h3>You 're in Safe Hands</h3>
              <a href="propertytestimonials.aspx">»<asp:Literal ID="Label2" Text="<%$Resources:Resource, ReadwhatourVendorsandClientssay  %>" runat="server"  ></asp:Literal></a> </div>
            <!-- Click Here End --> 
            
            <!-- Complaint Start -->
            <div class="complaint-start " id="comlait" runat="server"  style="display:none">
              <div class="col-md-8 col-sm-8 col-xs-7"><a href="pdf/Comply218.pdf" target="_blank" ><img  src="/images/decreto-218.jpg" alt=""></a>  </div>
              <div class="col-md-4 col-sm-4 col-xs-5"> <img  src="/images/aplaceinthesun.jpg" alt=""> </div>
            </div>
            <!-- Complaint End --> 
               <div class="find-us-map" id="fbinfo" runat="server"  style="display:block">
              <div class="col-sm-12">
                <h3> <asp:Literal ID="Label4" Text="<%$Resources:Resource, Findallourpropertiesusing   %>" runat="server"  ></asp:Literal><br/>
                  <strong> <asp:Literal ID="Label5" Text="<%$Resources:Resource, GoogleMaps   %>" runat="server"  ></asp:Literal></strong></h3>
                <div class="map-find"><a href="property-search-andalucia.aspx" target="_blank" ><img src="/images/map.jpg" alt="img-map"></a></div>
              </div>
            </div>
            
            <!--Find Us Using Google Map End --> 
            
            <!-- facebook Wideget Start -->
            <div class="fb-outer" id="fbiframe" runat="server"  style="display:block">
              <div class="fb-like-box fb_iframe_widget" data-href="https://www.facebook.com/inlandandaluciahomes"  data-height="490" data-colorscheme="light" data-show-faces="false" data-header="true" data-stream="true" data-show-border="true" ><span style="vertical-align: bottom;  height: 490px;">
                <iframe name="f28c7a3d8" width="98"  height="490"  title="fb:like_box Facebook Social Plugin" src="http://www.facebook.com/v2.0/plugins/like_box.php?app_id=&amp;channel=http%3A%2F%2Fstatic.ak.facebook.com%2Fconnect%2Fxd_arbiter%2FNM7BtzAR8RM.js%3Fversion%3D41%23cb%3Df19f6433d%26domain%3Dwww.inlandandalucia.com%26origin%3Dhttp%253A%252F%252Fwww.inlandandalucia.com%252Ff71cec64%26relation%3Dparent.parent&amp;color_scheme=light&amp;container_width=300&amp;header=true&amp;height=520&amp;href=https%3A%2F%2Fwww.facebook.com%2Finlandandaluciahomes&amp;locale=en_US&amp;sdk=joey&amp;show_border=true&amp;show_faces=false&amp;stream=true&amp;width=295" style="border: none; visibility: visible; height: 490px;" class=""></iframe>
                </span></div>
            </div>
            <!-- Face Book Widdget End --> 
            
          </div>
        </div>
        