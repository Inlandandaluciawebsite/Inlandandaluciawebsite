<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="propertytestimonials.aspx.vb" Inherits="propertytestimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Left Portion Start -->
        <div class="col-md-8 col-sm-7"> 
          <!-- View trip listing Start -->
          
          <div class="row">
          <!-- Single Testimonial Start -->
         <div id="UpdatePanelTestimonials">
	
             <asp:Repeater ID="rptest" runat="server">
                 <ItemTemplate>
                     <div class="testimonialpage">
                         <div class="testimonalpagequotetop"></div>
                         <div class="testimonalpagequotebottom"></div> 
<div class="testimonialtext">    
    <p><%#Replace(Eval("testimonial_text"), vbCrLf, "<br>") %></p>
</div>
<div class="testimonialdate"><%#Convert.ToDateTime(Eval("testimonial_date")).ToString("MMMM, yyyy").Trim%> </div>
<p>&nbsp;</p></div>
                 </ItemTemplate>
             </asp:Repeater>








</div>
           <!-- Single Testimonial Start -->  
            
          </div>
        </div>
        
        <!-- Left Portion Start --> 
        
</asp:Content>

