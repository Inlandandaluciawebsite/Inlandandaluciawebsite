<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="InlandAndaluciaNewsletter.aspx.vb" Inherits="InlandAndaluciaNewsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- Main Content Area Start -->

        <!-- Left Portion Start -->
        <div class="col-md-8" id="newsletter" runat="server" style="display:block"> 
          <!-- Contact Page Start -->
          <div class="row">
            <div class="col-md-12">
              <div class="town-guide-hd">
                <h1><asp:Literal ID="Literal2" Text="<%$Resources:Resource, InlandAndaluciaRealNewslettersubscribe%>" runat="server"></asp:Literal></h1>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <div class="contact-bg">
                <p> <asp:Literal ID="Literal1" Text="<%$Resources:Resource, InlandAndaluciaRealNewsletterfreemonthly%>" runat="server"></asp:Literal></p>
               <p><asp:Literal ID="Literal3" Text="<%$Resources:Resource, InlandAndaluciaRealNewsletterwouldlike%>" runat="server"></asp:Literal></p>
               
                
              
                
               <!-- News Letter Start -->
               <div class="row">
                  <div class="col-md-12">
                     <div class="newsletter-start">
                     <h2><asp:Literal ID="Literal4" Text="<%$Resources:Resource, InlandAndaluciaRealNewslettersubscribe%>" runat="server"></asp:Literal></h2>
                     
                    <div class="form-inline form-bg">
  <div class="form-group col-md-6">
    <label class="col-md-3 labl" for="exampleInputName2"><asp:Literal ID="Literal5" Text="<%$Resources:Resource, InlandAndaluciaRealNewslettername%>" runat="server"></asp:Literal></label>
 
      <asp:TextBox ID="TextBoxName" runat="server"  class="form-control" ></asp:TextBox>
   <asp:RequiredFieldValidator ID="rpname" runat="server" ErrorMessage="<%$Resources:Resource, InlandAndaluciaRealNewslettername%>" ForeColor="Red" ControlToValidate="TextBoxName" Display="Dynamic" ValidationGroup="Group2" ></asp:RequiredFieldValidator>

  </div>
  <div class="form-group col-md-6">
    <label class="col-md-3 labl" for="exampleInputEmail2"><asp:Literal ID="Literal6" Text="<%$Resources:Resource, InlandAndaluciaRealNewsletteremail%>" runat="server"></asp:Literal></label>
<asp:TextBox ID="TextBoxEmail" runat="server" class="form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rpemail" runat="server" ErrorMessage="<%$Resources:Resource, Validationemail%>" ForeColor="Red" ControlToValidate="TextBoxEmail" Display="Dynamic" ValidationGroup="Group2"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="rpvalidemail" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="<%$Resources:Resource, Validationemailvalid%>" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="Group2"></asp:RegularExpressionValidator>

  </div>
  <!-------000000000000000---->
   <div class="form-group col-md-12 mrg-20">
    <div class=" col-sm-10">
      <div class="checkbox">
        <label>
            <asp:CheckBox ID="CheckBoxUnsubscribe" runat="server" class="StrongOrange"/> <span><asp:Literal ID="Literal7" Text="<%$Resources:Resource, InlandAndaluciaRealNewsletterunsubscribe%>" runat="server"></asp:Literal></span>

        </label>
      </div>
    </div>
  </div>
  <div class="form-group col-md-12 mrg-20">
    <div class=" col-sm-10">
<%--      <button type="submit" class="btn btn-default Subscribe-btn">Subscribe</button>--%>
        <asp:Button ID="btnsubscribe" runat="server"  Text="<%$Resources:Resource, Subscribe%>" OnClick="btnsubscribe_Click" class="btn btn-default Subscribe-btn" ValidationGroup="Group2"/>
    </div></div>
</div>
                     </div>
                  </div>
               </div>
               
               
               <!-- News Letter Start -->
               
               
                
                
                  
                
               
                
              </div>
            </div>
          </div>
          
          <!-- Contact Page Start --> 
        </div>
        <!-- Left Portion End --> 
        <div>
               <div class="col-md-8" id="thanku" runat="server" style="display:none"> 
          <!-- Contact Page Start -->
          <div class="row">
            <div class="col-md-12">
            <h1><img src="/images/icons/thank-you-icon.jpg" alt="Thank you"  height="142" hspace="10" align="left" /><span id="SubscriptionText" runat="server"></span></h1>
 <div>
          <p>Maybe our <a href="http://inland-andalucia.blogspot.in/" target="_blank">Blog</a> is also something for you.</p>
          <p>Or connecting with us on <a href="https://www.facebook.com/inlandandaluciahomes" target="_blank">Facebook.</a></p>
          <p>And of course,always welcome to one of <a href="http://www.inlandandalucia.com/ContactOffices.aspx" target="_blank">our offices</a>.</p>
      </div>
        </div>
    </div>
        </div> </div>
       
<!-- Main Content Area End --> 
</asp:Content>

