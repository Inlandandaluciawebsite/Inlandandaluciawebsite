<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="InlandAndaluciaRealEstateArticles.aspx.vb" Inherits="InlandAndaluciaRealEstateArticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <!-- Left Portion Start -->
        <div class="col-md-8 col-sm-7"> 
          <!-- View trip listing Start -->
          <div class="row">
            <div class="col-md-12">
              <div class="view-trip-listing">
                <h1> <asp:Literal ID="Literal2" Text="<%$Resources:Resource, InlandAndaluciaRealEstateArticlesselection%>" runat="server"></asp:Literal></h1>
                <div class="article-inland">
                 <asp:Literal ID="Literal1" Text="<%$Resources:Resource, InlandAndaluciaRealEstateArticlesdesc%>" runat="server"></asp:Literal>
                </div>
              </div>
              <!-- glossary end --> 
              
            </div>
          </div>
        </div>
        
        <!-- Left Portion Start --> 
        
       
<!-- Main Content Area End --> 
</asp:Content>

