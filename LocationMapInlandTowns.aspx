<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="LocationMapInlandTowns.aspx.vb" Inherits="LocationMapInlandTowns" %>

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
                <h1><asp:Literal ID="Literal4" Text="<%$Resources:Resource, thelocationmapofadalucia %>" runat="server"></asp:Literal>The location of Andalucia</h1>
              </div>
            </div>
          </div>
          
          <!-- Detail one Strat -->
          <div class="row">
            <div class="col-md-12">
              <div class="about-andalucia">
        <p><asp:Literal ID="Literal9" Text="<%$Resources:Resource, LocationMapInlandautonomous %>" runat="server"></asp:Literal></p>
        
        <p><asp:Literal ID="Literal1" Text="<%$Resources:Resource, LocationMapInlandborders %>" runat="server"></asp:Literal></p>
        
        
        <p><asp:Literal ID="Literal2" Text="<%$Resources:Resource, LocationMapInlandmostnotable %>" runat="server"></asp:Literal></p>
        
        
      
              </div>
            </div>
          </div>
          <!-- Detail one Strat --> 
          
          <!-- Detail Two Strat -->
          
          <div class="row">
            <div class="malaga-info">
             
              <div class="col-md-12 col-sm-12">
                <div class="about-andalucia loc-img"> <img class="img-bdr" src="/images/AndaluciaMap.gif"> </div>
              </div>
            </div>
          </div>
        
          
          <!-- Detail Two End --> 
          
          
           <!-- Detail Two Strat -->
          
          <div class="row">
            <div class="malaga-info">
             
              <div class="col-md-12 col-sm-12">
                <div class="about-andalucia "> 
                <p><asp:Literal ID="Literal3" Text="<%$Resources:Resource, LocationMapInlandvaststrech %>" runat="server"></asp:Literal></p>
                 </div>
              </div>
            </div>
          </div>
        
          
          <!-- Detail Two End --> 
          
          
          
        </div>
        <!-- Left Portion End --> 
        
      
<!-- Main Content Area End --> 
</asp:Content>

