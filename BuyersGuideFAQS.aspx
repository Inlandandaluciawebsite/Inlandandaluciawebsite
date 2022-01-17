<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="BuyersGuideFAQS.aspx.vb" Inherits="BuyersGuideFAQS" %>

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
          <h3><asp:Literal ID="Literal10" Text="<%$Resources:Resource, BuyerGuideFAQSfreqaskedqn %>" runat="server"></asp:Literal></h3>
         
          
          <div class="listing-buyer">
            <ul>
               <li><a href="#q1" title="What is a N.I.E.?"><b>1.</b><asp:Literal ID="Literal1" Text="<%$Resources:Resource, BuyerGuideFAQSwhatis %>" runat="server"></asp:Literal></a></li>
                <li><a href="#q2" title=" How do I get a NIE?"><b>2</b><asp:Literal ID="Literal2" Text="<%$Resources:Resource, BuyerGuideFAQShowdogetnie %>" runat="server"></asp:Literal> </a></li>
                 <li><a href="#q3" title="How do Unpaid Bills and Taxes on a Property affect the New Owner?"><b>3</b><asp:Literal ID="Literal3" Text="<%$Resources:Resource, BuyerGuideFAQSunpaidbills%>" runat="server"></asp:Literal></a></li>
                  <li><a href="#q4" title="What is the Plusval&iacute;a Tax in Spain?"><b>4</b><asp:Literal ID="Literal4" Text="<%$Resources:Resource, BuyerGuideFAQSplusvalia %>" runat="server"></asp:Literal> </a></li></ul>
                  
 <div class="divider mrg-10"><img src="/images/divider.png"></div>                   
           <h4><a name="q1"></a>1.<asp:Literal ID="Literal5" Text="<%$Resources:Resource, BuyerGuideFAQSwhatis %>" runat="server"></asp:Literal></h4> 
           <p><asp:Literal ID="Literal6" Text="<%$Resources:Resource, BuyerGuideFAQSrecentspanish %>" runat="server"></asp:Literal></p> 
           
           <p><asp:Literal ID="Literal7" Text="<%$Resources:Resource, BuyerGuideFAQSuntilrecently %>" runat="server"></asp:Literal></p>
           
         <h5><a href="#top" title="Back to top"><asp:Literal ID="Literal18" Text="<%$Resources:Resource, BackToTop %>" runat="server"></asp:Literal></a></h5>
           
<div class="divider mrg-10"><img src="/images/divider.png"></div>             
           <h4><a name="q2"></a>2.<asp:Literal ID="Literal8" Text="<%$Resources:Resource, BuyerGuideFAQShowdogetnie %>" runat="server"></asp:Literal>  </h4>
           <p><asp:Literal ID="Literal9" Text="<%$Resources:Resource, BuyerGuideFAQSintherory %>" runat="server"></asp:Literal> </p>
           
           <h5><a href="#top" title="top"><asp:Literal ID="Literal19" Text="<%$Resources:Resource, BackToTop %>" runat="server"></asp:Literal></a><span>|</span><a href="#q1" title="Previous Question"><asp:Literal ID="Literal20" Text="<%$Resources:Resource, Previousquestion %>" runat="server"></asp:Literal></a></h5>
<div class="divider mrg-10 "><img src="/images/divider.png"></div>             
           <h4><a name="q3"></a>3. <asp:Literal ID="Literal11" Text="<%$Resources:Resource, BuyerGuideFAQSunpaidbills%>" runat="server"></asp:Literal></h4>
           
           <p><asp:Literal ID="Literal12" Text="<%$Resources:Resource, BuyerGuideFAQSunpaidbillsdesc%>" runat="server"></asp:Literal></p>
           
            <h5><a href="#top" title="top"><asp:Literal ID="Literal13" Text="<%$Resources:Resource, BackToTop%>" runat="server"></asp:Literal></a><span>|</span><a href="#q2" title="Previous Question"><asp:Literal ID="Literal14" Text="<%$Resources:Resource, Previousquestion%>" runat="server"></asp:Literal></a></h5>
            
 <div class="divider mrg-10"><img src="/images/divider.png"></div> 
              <h4><a name="q4"></a> 4. <asp:Literal ID="Literal15" Text="<%$Resources:Resource, BuyerGuideFAQSplusvalia %>" runat="server"></asp:Literal> </h4>
            <p><asp:Literal ID="Literal16" Text="<%$Resources:Resource, BuyerGuideFAQSplusvaliadesc %>" runat="server"></asp:Literal>  </p>
            <h5><a href="#top" title="top"><%=("Back to Top")%></a><span>|</span><a href="#q3" title="Previous Question"><asp:Literal ID="Literal17" Text="<%$Resources:Resource, Previousquestion%>" runat="server"></asp:Literal></a></h5>
                
       <div class="divider mrg-10"><img src="/images/divider.png"></div>           
                  
          </div>
          
        
          
          </div>
          </div>
          </div>
          
          <!-- Buyers Guide End -->
          
          
          <!-- Contact Page Start --> 
        </div>
        <!-- Left Portion End --> 
        
       
<!-- Main Content Area End --> 
</asp:Content>

