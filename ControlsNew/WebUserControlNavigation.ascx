<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlNavigation.ascx.vb" Inherits="Controls_WebUserControlNavigation" %>

<div class="topnav">
    <div class="nav">
        <ul>
            <li><a href="/" title="Inland Andalucia Bargain Properties"><%= GetTranslation("Home")%></a>
            </li>
            <li><a href="propsearch.aspx" title="Property search Andalucia"><%= GetTranslation("Property Search")%></a>
                <ul>
                    <li><a href="propsearch.aspx" title="Advanced Search"><%= GetTranslation("Advanced Search")%></a></li>
                    <li><a href="property-search-andalucia.aspx" title="Google Map"><%= GetTranslation("Search by Google Map")%></a>                  </li>
                    <li><a href="Top50Properties.aspx" title="Top 50"><%= GetTranslation("Top 50")%></a></li>
                    <li><a href="andalucia-property-viewing-trip.aspx" title="Viewing Trip"><%= GetTranslation("Viewing Trip")%></a></li>

                </ul>
            </li>
            <li><a href="TownLocationInfo.aspx" title="Town Guide"><%= GetTranslation("Town Guide")%></a>
                <ul>
                    <li><a href="CordobaInfo.aspx" title="Cordoba"><%= GetTranslation("Cordoba province")%></a></li>
                    <li><a href="GranadaInfo.aspx" title="Granada"><%= GetTranslation("Granada province")%></a></li>
                    <li><a href="JaenInfo.aspx" title="Jaen"><%= GetTranslation("Jaen province")%></a></li>
                    <li><a href="MalagaInfo.aspx" title="Malaga"><%= GetTranslation("Malaga province")%></a></li>
                    <li><a href="SevillaInfo.aspx" title="Seville"><%= GetTranslation("Seville province")%></a></li>
                </ul>
            </li>
            <li><a href="buyersguide.aspx" title="Buyers Guide"><%= GetTranslation("Buyer's Guide")%></a>
                <ul>
                    <li><a href="BuyersGuide.aspx" title="Buying a Property"><%= GetTranslation("Buying a Property")%></a></li>
                    <li><a href="BuyingProcess.aspx" title="Buying Process"><%= GetTranslation("Buying Process")%></a></li>
                    <li><a href="PropertyTaxes.aspx" title="Property Taxes"><%= GetTranslation("Property Taxes")%></a></li>
                    <li><a href="BuyersGuideFAQS.aspx" title="FAQS"><%= GetTranslation("FAQs")%></a></li>
                    <li><a href="BuyersGuideUnpaidTaxes.aspx" title="Unpaid Taxes"><%= GetTranslation("Unpaid Taxes")%></a></li>
                    <li><a href="BuyersGuideMortgage.aspx" title="Mortgage"><%= GetTranslation("Mortgage")%></a></li>
                </ul>
            </li>
            <li><a href="inland-andalucia.aspx" title="About Andalucia"><%= GetTranslation("About Andalucia")%></a>
                <ul>
                    <li><a href="LocationMapInlandTowns.aspx" title="Location"><%= GetTranslation("Location")%></a> </li>
                    <li><a href="weather.aspx" title="Weather"><%= GetTranslation("Weather")%></a> </li>
                    <li><a href="AndaluciaAirports.aspx" title="Airports"><%= GetTranslation("Airports")%></a> </li>
                </ul>
            </li>
            <li><a href="contactus.aspx" title="Contact us"><%= GetTranslation("Contact us")%></a>
                <ul>
                    <li><a href="ContactOffices.aspx" title="Our Offices"><%= GetTranslation("Our Offices")%></a></li>
                    <li><a href="InlandAndaluciaGlossaryTerms.aspx" title="Glossary"><%= GetTranslation("Glossary")%></a></li>
                    <li><a href="InlandAndaluciaRealEstateArticles.aspx" title=" Articles "><%= GetTranslation("Articles")%> </a></li>
                    <li><a href="InlandAndaluciaNewsletter.aspx" title="Newsletter"><%= GetTranslation("Newsletter")%></a></li>
                    <li><a href="UsefulLinks.aspx" title="Useful Links"><%= GetTranslation("Useful Links")%></a></li>
                    <li><a href="AgentLogin.aspx" title="Agents Private Area"><%= GetTranslation("Agents Private Area")%></a></li>
                </ul>
            </li>
        </ul>
    </div>
</div>
