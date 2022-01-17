<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Blog.aspx.vb" Inherits="BuyersGuide1" %>

<%@ Register Src="~/Controls/BlogHeader.ascx" TagPrefix="uc1" TagName="BlogHeader" %>

      <asp:Content ID="Contenttp" runat="server" ContentPlaceHolderID="ContentPlaceHolder3" >
             
              <link href='<%= ResolveUrl("~/owl-carousel12/owl.carousel.css") %>' rel="stylesheet" />
              <link href='<%= ResolveUrl("~/owl-carousel12/owl.theme.css") %>' rel="stylesheet" />
              <link href='<%= ResolveUrl("~/owl-carousel12/owl.transitions.css") %>' rel="stylesheet" />
<%--    <link href="owl-carousel12/owl.theme.css" rel="stylesheet" />
     <link href="owl-carousel12/owl.transitions.css" rel="stylesheet" />--%>
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link href='<%= ResolveUrl("~/css/Blog.css") %>' rel="stylesheet" />
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <uc1:BlogHeader runat="server" id="BlogHeader" />
        </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <!-- Left Portion Start -->
    <div class="col-md-8">

        <asp:Repeater ID="rpFeaturedProperty" runat="server">
            <ItemTemplate>

                  <!-- Blog Repeater S-->
              <div class="gray-bg-inner">
                <div class="outer-border">
                  <p class="time"><%#Eval("dateposted").ToString() %></p>
                  <h3 class="blog-title"><a href="/Blog/<%#(Eval("TitleNew").ToString()) %>"><%#Eval("Title").ToString() %></a></h3>
                   <p class="blog-main-txt">
                 <%#(Eval("SubTitle").ToString()) %>
                  </p>
                     <p class="blog-main-txt">
                 <%#Server.HtmlDecode(Eval("Description").ToString()) %>sourabh
                         <%#Eval("Description").ToString() %>
                  </p>
                 <p class="blog-main-txt">Posted by: <%#Eval("PostedByUser").ToString() %> at <%#Eval("Time").ToString() %> </p>
               <p class="blog-main-txt">Labels: <%#Server.HtmlDecode(Eval("hashlables").ToString()) %>
                        </p>
                     </div>
              </div>
              <!-- Blog Repeater E--> 

             
            </ItemTemplate>
        </asp:Repeater>


     

        <!-- Buyers Guide End -->


        <!-- Contact Page Start -->
    </div>
    <!-- Left Portion End -->


    <!-- Main Content Area End -->
</asp:Content>

