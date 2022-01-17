<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlRelatedLinks.ascx.vb" Inherits="Controls_WebUserControlRelatedLinks" %>
 <div class="buyersguide"><h4> <%= GetTranslation("Related links")%></h4>
 	
  <ul>
    <li>&raquo;&nbsp;<a href="BuyersGuide.aspx" title="Buying a Property"><%= GetTranslation("Buying a Property")%></a></li>
    <li>&raquo;&nbsp;<a href="BuyingProcess.aspx" title="Buying Process"><%= GetTranslation("Buying Process")%></a></li>
    <li>&raquo;&nbsp;<a href="PropertyTaxes.aspx" title="Property Taxes"><%= GetTranslation("Property Taxes")%></a></li>
    <li>&raquo;&nbsp;<a href="BuyersGuideFAQS.aspx" title="FAQS "><%= GetTranslation("FAQs")%></a></li>
    <li>&raquo;&nbsp;<a href="BuyersGuideUnpaidTaxes.aspx" title="Unpaid Taxes "><%= GetTranslation("Unpaid Taxes")%></a></li>
    <li>&raquo;&nbsp;<a href="BuyersGuideMortgage.aspx" title="Mortgage"><%= GetTranslation("Mortgage")%></a>     </li>
  </ul>
  </div>