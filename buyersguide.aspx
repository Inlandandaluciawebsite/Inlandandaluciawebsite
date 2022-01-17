<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="BuyersGuide.aspx.vb" Inherits="BuyersGuide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
        <!-- Left Portion Start -->
        <div class="col-md-8"> 
         
          
          
          <!-- Buyers Guide Start -->
          <div class="row">
          <div class="col-md-12">
          <div class="buyers-guide">
          <h3><asp:Literal ID="Literal10" Text="<%$Resources:Resource, BuyersGuideBuyingproperty %>" runat="server"></asp:Literal>
             </h3>
          <p>
              <asp:Literal ID="Literal1" Text="<%$Resources:Resource, BuyersGuideintend %>" runat="server"></asp:Literal>
           </p>
          
          <p><asp:Literal ID="Literal2" Text="<%$Resources:Resource, BuyersGuideimpossible %>" runat="server"></asp:Literal>
             </p>
          
          <p><asp:Literal ID="Literal3" Text="<%$Resources:Resource, BuyersGuidespanish %>" runat="server"></asp:Literal>
             </p>
          
          
          <h3><asp:Literal ID="Literal4" Text="<%$Resources:Resource, BuyersGuidewhattoexpect %>" runat="server"></asp:Literal></h3>
          
          <p><asp:Literal ID="Literal5" Text="<%$Resources:Resource, BuyersGuideaswewll %>" runat="server"></asp:Literal>
             </p>
          
          <p><asp:Literal ID="Literal6" Text="<%$Resources:Resource, BuyersGuidehavealook %>" runat="server"></asp:Literal></p>
          
          </div>
          </div>
          </div>
          
          <!-- Buyers Guide End -->
          
          
          <!-- Contact Page Start --> 
        </div>
        <!-- Left Portion End --> 
        
      
<!-- Main Content Area End --> 
</asp:Content>

