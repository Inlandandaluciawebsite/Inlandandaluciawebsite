<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="BuyingProcess.aspx.vb" Inherits="BuyingProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Main Content Area Start -->

        <!-- Left Portion Start -->
        <div class="col-md-8"> 
         
          
          
          <!-- Buyers Guide Start -->
          <div class="row">
          <div class="col-md-12">
          <div class="buyers-guide">
          <h3><asp:Literal ID="Literal10" Text="<%$Resources:Resource, BuyersprocessBuyingpropertyprocess %>" runat="server"></asp:Literal></h3>
          <h4><asp:Literal ID="Literal1" Text="<%$Resources:Resource, BuyersprocessBuyingpropertyprocessinspain %>" runat="server"></asp:Literal>
             </h4>
          
          <div class="listing-buyer">
            <ul>
               <li><a href="#section1" title="Reservation Deposit"><b>1.</b> <asp:Literal ID="Literal2" Text="<%$Resources:Resource, Buyersprocessreservationdeposit %>" runat="server"></asp:Literal></a></li>
<%--                <li><a href="#"><b>2.1.</b> Exchange of the Private Purchase Contract - Off Plan</a></li>--%>
                 <li><a href="#section2.2" title="xchange of the Private Purchase Contract - Re-Sal"><b>2.2.</b><asp:Literal ID="Literal3" Text="<%$Resources:Resource, Buyersprocessexchange %>" runat="server"></asp:Literal></a></li>
                  <li><a  href="#section3" title="Completion"><b>3.</b><asp:Literal ID="Literal4" Text="<%$Resources:Resource, Buyersprocesscompletion %>" runat="server"></asp:Literal> </a></li>
                   <li><a href="#section4" title="Costs Incurred"><b>4. </b><asp:Literal ID="Literal16" Text="<%$Resources:Resource, Buyersprocesscostoccured%>" runat="server"></asp:Literal></a></li>
            </ul>
          </div>
          
          <h3 ><a name="section1">1.<asp:Literal ID="Literal5" Text="<%$Resources:Resource, Buyersprocessreservationdeposit %>" runat="server"></asp:Literal></a> </h3>
        <p><asp:Literal ID="Literal6" Text="<%$Resources:Resource, Buyersprocessreservationdepositdesc %>" runat="server"></asp:Literal>  </p>
        <h5><a href="#top" title="Back to Top."><asp:Literal ID="Literal7" Text="<%$Resources:Resource, BackToTop %>" runat="server"></asp:Literal></a></h5>
        <div class="divider mrg-20"><img src="/images/divider.png"></div>  
        
          
          <%--<h3>2.1. Exchange of the Private Purchase Contract - Off Plan</h3>
        <p> This takes place 30 days after the reservation fee has been paid, during this time your assigned Lawyer will prepare all the necessary legal documentation. On exchange of the private purchase contract 30% of the property value is paid, the property is bank guaranteed through a developer’s insurance policy or directly underwritten by the lending bank. These checks are made by the Lawyer prior to the private purchase contract being signed. This will insure the safety of your funds at all times. This is based on the 30%-70% payment plan, which is the most common but again in certain cases, payment plans may vary. </p>
       --%>
          <h3 ><a name="section2.2">2.<asp:Literal ID="Literal8" Text="<%$Resources:Resource, Buyersprocessexchange %>" runat="server"></asp:Literal> </a> </h3>
        <p> <asp:Literal ID="Literal9" Text="<%$Resources:Resource, Buyersprocessexchangedesc %>" runat="server"></asp:Literal> </p>
        <h5><a href="#top" title="Back to Top." ><asp:Literal ID="Literal11" Text="<%$Resources:Resource, BackToTop %>" runat="server"></asp:Literal></a><span>|</span><a href="#section2.2" title="Previous Step" ><asp:Literal ID="Literal21" Text="<%$Resources:Resource, PeriviousStep %>" runat="server"></asp:Literal></a></h5>
        <div class="divider mrg-20"><img src="/images/divider.png"></div> 
        
        
         <h3 > <a name="section3">3. <asp:Literal ID="Literal12" Text="<%$Resources:Resource, Buyersprocesscompletion %>" runat="server"></asp:Literal></a> </h3>
        <p> <asp:Literal ID="Literal13" Text="<%$Resources:Resource, Buyersprocesscompletiondesc%>" runat="server"></asp:Literal></p>
        <h5><a href="#top" title="Back to Top." ><asp:Literal ID="Literal14" Text="<%$Resources:Resource, BackToTop %>" runat="server"></asp:Literal></a><span>|</span> <a href="#section2" title="Previous Step"><asp:Literal ID="Literal20" Text="<%$Resources:Resource, PeriviousStep %>" runat="server"></asp:Literal></a></h5>
        <div class="divider mrg-20"><img src="/images/divider.png"></div> 
          
          
           <h3 ><a name="section4">4. <asp:Literal ID="Literal15" Text="<%$Resources:Resource, Buyersprocesscostoccured %>" runat="server"></asp:Literal></a></h3>
        <p> <asp:Literal ID="Literal17" Text="<%$Resources:Resource, Buyersprocesscostoccureddesc%>" runat="server"></asp:Literal> </p>
        <h5><a href="#top" title="Back to Top."><asp:Literal ID="Literal18" Text="<%$Resources:Resource, BackToTop %>" runat="server"></asp:Literal></a><span>|</span><a href="#section3" title="Previous Step" ><asp:Literal ID="Literal19" Text="<%$Resources:Resource, PeriviousStep %>" runat="server"></asp:Literal></a></h5>
        <div class="divider mrg-20"><img src="/images/divider.png"></div> 
          
          </div>
          </div>
          </div>
          
          <!-- Buyers Guide End -->
          
          
          <!-- Contact Page Start --> 
        </div>
        <!-- Left Portion End --> 
        
     
<!-- Main Content Area End --> 
</asp:Content>

