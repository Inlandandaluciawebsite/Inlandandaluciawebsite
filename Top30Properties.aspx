<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Top30Properties.aspx.vb" Inherits="Top30Properties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
          <style>
     
          
        .page_enabled, .page_disabled
        {
            display: inline-block;
         
        }
        .page_enabled
        {
        position: relative;
float: left;
padding: 6px 12px;
margin-left: -1px;
line-height: 1.42857;
color: #337AB7!important;
text-decoration: none;
background-color: #FFF!important;
border: 1px solid #DDD;
        }
        .page_disabled
        {
         

      color: #23527C;
background-color: #eee!important;
border-color: #DDD!important;
outline: 0px none;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <!-- Main Content Area Start -->

        <!-- Left Portion Start -->
        <div class="col-md-8"> 
          <!-- Listing Head Start -->
          <div class="row">
            <div class="col-md-12">
              <div class="listing-head">
                <h1>Latest <span> Top 30 </span> Properties in Andalucia</h1>
                <p>An overview of our 30 best bargain properties for sale in Cordoba, Granada, Jaen, Malaga and Sevilla</p>
                <div class="listing-btns">
                <asp:Button ID="btnback" runat="server" class="btn btn-default listing-bk"  Text="Back" OnClick="btnback_Click" />
                    <a id="A1" href ="propsearch.aspx" runat="server" class="btn btn-default listing-search" ><span class="newsrch"><i class="fa fa-star"></i></span> New Search</a>
                </div>
                <div class="listing-list-multi">
                  <div class="top-paggi">
                        <div id="navpropery" runat="server"></div>
               <%--     <ul class="nav nav-pills" role="tablist">
                      <li role="presentation" class="active"><a href="#">Cordoba <span class="badge">44</span></a></li>
                      <li role="presentation"><a href="#">Granada <span class="badge">45</span></a></li>
                      <li role="presentation"><a href="#">Jaen <span class="badge">220</span></a></li>
                      <li role="presentation"><a href="#">Malaga <span class="badge">180</span></a></li>
                      <li role="presentation"><a href="#">Sevilla <span class="badge">89</span></a></li>
                    </ul>--%>
                  </div>
                </div>
                
                <!-- main pagging start -->
                <div class="row">
                  <div class="col-md-12">
                    <div class="paggination-top">
                      <div class="col-md-6 col-sm-6">
                        <h4><asp:Label ID="lblpropertycount" runat="server" ></asp:Label> properties found </h4>
                      </div>
                      <div class="col-md-6 col-sm-6">
                        <ul class="pagination">
                         <asp:Repeater ID="rptPager" runat="server">
    <ItemTemplate>
       <li> <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
            CssClass='<%# If(Convert.ToBoolean(Eval("Enabled")), "page_enabled", "page_disabled")%>'
            OnClick="Page_Changed" OnClientClick='<%# If(Not Convert.ToBoolean(Eval("Enabled")), "return false;", "") %>'></asp:LinkButton></li>
    </ItemTemplate>
</asp:Repeater>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>

                  


                <!-- Main Pagging End --> 
                


                    <asp:Repeater ID="rpFeaturedProperty" runat="server">
                    <ItemTemplate>
                          <!-- Mini single item Start -->
                <div class="row">
                  <div class="col-md-12">
                    <div class="mini-item-start">
                      <div class="col-md-8 col-sm-8">
                        <h4><b> <%#Eval("type") %>  (<%#Eval("reference") %> )</b> / <%#Eval("region") %><b>/<%#IIf(Convert.ToString(Request.QueryString("SubAreaId")) = "", Eval("area").ToString(), Eval("subarea").ToString())%>  

                                                                                                         </b></h4>
                        <h3><%#Eval("short_description") %> </h3>
                      </div>
                      <div class="col-md-4 col-sm-4">
                       <h2><del class="delete"> <%#IIf(Convert.ToString(Eval("original_price")) = "0", "", FormatPrice(Eval("original_price")).ToString())%> </del> &nbsp; <%#FormatPrice(Eval("price")) %> </h2>
                      </div>
                    </div>
                    <div class="mini-item-detail">
                      <div class="thumbnail-imgg col-md-4 col-sm-4"> <a href="propsearch.aspx?propertyref=<%#Eval("reference") %>"><asp:Image ID="imgproperty" runat="server"  ImageUrl='<%# ApplyStatusWatermark(PhotoURL(Eval("reference").ToString().Trim()), Convert.ToInt32(Eval("status_id"))) %>' /></a> </div>
                      <div class="paragraph-st col-md-8 col-sm-8">
                        <p><strong><asp:Literal runat="server" ID="Literal8" Text=" <%$Resources:Resource,     Beds%>"></asp:Literal>:</strong> <%#Eval("bedrooms") %>  / <strong><asp:Literal runat="server" ID="Literal1" Text=" <%$Resources:Resource,     Baths%>"></asp:Literal>:</strong> <%#Eval(" bathrooms") %>  / <strong><asp:Literal runat="server" ID="Literal2" Text=" <%$Resources:Resource,     Built%>"></asp:Literal>:</strong> <%#Eval("sqm_built") %> m² /<strong> <asp:Literal runat="server" ID="Literal3" Text=" <%$Resources:Resource,     Plot%>"></asp:Literal>:</strong> <%#Eval("sqm_plot")%> m²</p>
                        <p><%#Eval("description") %> </p>
                          <a href="propsearch.aspx?propertyref=<%#Eval("reference") %>" class="btn btn-default read-more"> <asp:Literal runat="server" ID="Literal4" Text=" <%$Resources:Resource,     MoreInfo%>"></asp:Literal> >></a>
   
                      </div>
                    </div>
                    <!--mini-item-detail-end--> 
                    
                  </div>
                </div>
                <!--Mini single item End --> 
                    </ItemTemplate>
                </asp:Repeater>
              
                
                
             
                
                   <div class="row">
                  <div class="col-md-12">
                    <div class="paggination-top">
                      <div class="col-md-6 col-sm-6">
                     <%--   <h4><asp:Label ID="Label1" runat="server" ></asp:Label> properties found </h4>--%>
                      </div>
                      <div class="col-md-6 col-sm-6">
                        <ul class="pagination">
                         <asp:Repeater ID="rptpage2" runat="server">
    <ItemTemplate>
       <li> <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
            CssClass='<%# If(Convert.ToBoolean(Eval("Enabled")), "page_enabled", "page_disabled")%>'
            OnClick="Page_Changed" OnClientClick='<%# If(Not Convert.ToBoolean(Eval("Enabled")), "return false;", "") %>'></asp:LinkButton></li>
    </ItemTemplate>
</asp:Repeater>
                        </ul>
                      </div>
                    </div>
                  </div>
                </div>

                  
                
              </div>
            </div>
          </div>
          <!-- Listing Head End --> 
        </div>
        <!-- Left Portion Start --> 
        
     
<!-- Main Content Area End --> 
</asp:Content>

