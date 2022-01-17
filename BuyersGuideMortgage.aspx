<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="BuyersGuideMortgage.aspx.vb" Inherits="BuyersGuideMortgage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Main Content Area Start -->

        <!-- Left Portion Start -->
        <div class="col-md-8"> 
         
          
          
          <!-- Buyers Guide  Start -->
          <div class="row">
          <div class="col-md-12">
          <div class="buyers-guide">
          <h3><asp:Literal ID="Literal10" Text="<%$Resources:Resource, BuyersGuideMortageInSpain %>" runat="server"></asp:Literal></h3>
          <p><asp:Literal ID="Literal1" Text="<%$Resources:Resource, BuyersGuideMortageManyguide %>" runat="server"></asp:Literal></p>
          
          <p><asp:Literal ID="Literal2" Text="<%$Resources:Resource, BuyersGuideMortageIntrsestRate %>" runat="server"></asp:Literal></p>
          
          <p><asp:Literal ID="Literal3" Text="<%$Resources:Resource, BuyersGuideMortageYouWill %>" runat="server"></asp:Literal><strong><asp:Literal ID="Literal4" Text="<%$Resources:Resource, BuyersGuideMortagedocument %>" runat="server"></asp:Literal></strong></p>
          
          </div>
          </div>
          </div>
          
          <!-- Buyers Guide End -->
          
            <!-- Buyers Guide Bottom Start -->
            <div class="row">
            <div class="buyers-guide">
            <div class="col-md-6 col-sm-6">
            <div class="buyer-left">
            <p><b> <asp:Literal ID="Literal5" Text="<%$Resources:Resource, BuyersGuideMortageNonResident %>" runat="server"></asp:Literal></b></p>
           
            <ul>
                <asp:Literal ID="Literal6" Text="<%$Resources:Resource, BuyersGuideMortagecopy %>" runat="server"></asp:Literal>
              
               
            </ul>
            
            
            </div>
            
            </div><!-- Buyer left end-->
            
            <!-- Buyer Right Start -->
            <div class="col-md-6 col-sm-6">
            <div class="buyer-rt">
            <p><b><asp:Literal ID="Literal7" Text="<%$Resources:Resource, BuyersGuideMortagebuyers %>" runat="server"></asp:Literal></b></p>
            <ul>
             <asp:Literal ID="Literal8" Text="<%$Resources:Resource, BuyersGuideMortagecopy2 %>" runat="server"></asp:Literal>
            </ul>
            
            </div>
            </div>
             <!-- Buyer Right End -->
            
            
            </div>
            
            </div>
            
            <!-- Buyers Guide Bottom End -->
            
            
            
            <!-- Buyers Bottom Start -->
            <div class="row">
             <div class="col-md-12">
               <div class="buyers-guide">
               <p><asp:Literal ID="Literal9" Text="<%$Resources:Resource, BuyersGuideMortageiflegelresident %>" runat="server"></asp:Literal>
      </p>
               
               <p><asp:Literal ID="Literal11" Text="<%$Resources:Resource, BuyersGuideMortagemostspanish %>" runat="server"></asp:Literal>
             </p>
               
               
               <p><asp:Literal ID="Literal12" Text="<%$Resources:Resource, BuyersGuideMortageliabilities %>" runat="server"></asp:Literal></p>
               
               
                <div class="buyer-left">
                <ul>
                <asp:Literal ID="Literal13" Text="<%$Resources:Resource, BuyersGuideMortagecopy3 %>" runat="server"></asp:Literal>
                  
                </ul>
                
                </div>
               
               
               
               </div>
             
             </div>
             
            </div>
            
            <!-- Buyers Bottom End -->
            
            
          
          
          
          
          
          <!-- Contact Page Start --> 
        </div>
        <!-- Left Portion End --> 
        
       
<!-- Main Content Area End --> 
</asp:Content>

