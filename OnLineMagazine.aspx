<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="OnLineMagazine.aspx.vb" Inherits="InlandAndaluciaRealEstateArticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <!-- Left Portion Start -->
        <div class="col-md-8 col-sm-7"> 
          <!-- View trip listing Start -->
          <div class="row">
            <div class="col-md-12">
              <div class="view-trip-listing">
                <h4>Don't worry if you could not get a copy of our <b>INLAND PROPERTY</b>  magazine. We are publishing them here.</h4>
                <div class="article-inland">
                    <asp:Repeater ID="rptCustomers" runat="server" >
      <ItemTemplate>
          <div class="row">
              <div class="col-md-12">
    <%#(Eval("EmbedCode"))%>
              </div>
          </div>
  
    </ItemTemplate>
</asp:Repeater>
               
                     </div>
              </div>
              <!-- glossary end --> 
              
            </div>
          </div>
        </div>
        
        <!-- Left Portion Start --> 
        
       
<!-- Main Content Area End --> 
</asp:Content>

