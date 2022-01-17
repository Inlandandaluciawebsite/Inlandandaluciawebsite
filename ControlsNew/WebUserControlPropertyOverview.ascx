<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlPropertyOverview.ascx.vb" Inherits="WebUserControlPropertyOverview" %>

<div class="propertylist">   <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="2" align="left" valign="top" bgcolor="#7F80B9">
        <div class="propertylisthead">
            <span class="propertylistheadtype"><%= Type%>&nbsp;&nbsp;(<% = PartnerReference%>)</span>/<span class="propertylistheadtown"><% =Region %>&nbsp;/&nbsp;<strong><% =Area %></strong><% =SubArea%></span> 
            <span class="propertylistheadprice"><strike><font color="red"><% = OriginalPrice.Trim%></font></strike>&nbsp;&nbsp;&nbsp;<strong><% = Price.Trim%></strong></span>    <br />
            <strong><% = ShortDescription.Trim%></strong>
        </div>
        <div class="clearfloat"></div>
    </td>
    </tr>
  <tr>
    <td width="25%" align="left" valign="middle" bgcolor="#FBFBFB">
        <asp:ImageButton ID="ImageProperty" runat="server" class="propertylistimg" />
      <%-- 
										Foto=Split(Sacar_Fotos(Rs.Fields("idgeneral"),"_"),";")   
															   
										If Ubound(Foto)>0 then
											If Foto(1) > "" then
												Response.Write "<a href='index.aspx?property_id=<%=PropertyID.ToString.Trim %>'><IMG class="propertylistimg" alt='Click here for more details and pictures' align='middle' SRC='http://www.inlandandalucia.com/fotos/" & Foto(1) & "' border='0' width='150'></a>"
											Else
												Response.Write "<a href='index.aspx?property_id=<%=PropertyID.ToString.Trim %>'><IMG class="propertylistimg" alt='Click here for more details and pictures' align='middle' SRC='http://www.inlandandalucia.com/fotos/nofoto.gif' border='0' width='150'></a>"
											End If
										Else
											Response.Write "<a href='index.aspx?property_id=<%=PropertyID.ToString.Trim %>'><IMG class="propertylistimg" alt='Click here for more details and pictures' align='middle' SRC='http://www.inlandandalucia.com/fotos/nofoto.gif' border='0' width='150'></a>"
										End If
										--%></td>
    <td width="75%" align="left" valign="top" bgcolor="#FBFBFB"><div class="propertylistdetails">
      <p><% = "<strong>" & GetTranslation("Beds") & ":</strong> " & Bedrooms.ToString.Trim & " /<strong> " & GetTranslation("Baths") & ":</strong> " & Bathrooms.ToString.Trim & " / <strong>" & GetTranslation("Built") & ": </strong>" & BuiltSize.ToString.Trim & "m² / <strong>" & GetTranslation("Plot") & ":</strong> " & PlotSize.ToString.Trim & "m²"%></p>

      <% = Description.Trim%>
    </div>
      </td>
  </tr>
  <tr>
    <td align="left" valign="top" bgcolor="#DDDDDD">&nbsp;</td>
    <td align="left" valign="top" bgcolor="#DDDDDD"><div class="propertylistbuttons"><span id="MoreInfoButton" runat="server"></span>&nbsp;&nbsp;&nbsp;</div></td>
  </tr>
</table>
    </div>
    
   