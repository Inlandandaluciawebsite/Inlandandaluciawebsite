<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlNewsletterSubscription.ascx.vb" Inherits="WebUserControlNewsletterSubscription" %>
<h1><%=GetTranslation("Subscribe to our Free Newsletter")%></h1>
<p><%=GetTranslation("Our free monthly Newsletter provides inland news, properties of the month, information about towns and their fiestas and of course, our property promotions")%>. </p>
  
<p><%= GetTranslation("If you would like to register just fill in your name and email address and click on the 'Register' button. It's so simple!")%></p>
<p>&nbsp;</p>
<div class="newsletter">
    <p>&nbsp;</p>
    <table cellpadding="0" cellspacing="0">
        <tr> 
        <td><%=GetTranslation("Name")%>:</td>
            <td>&nbsp;</td>
            <td><asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
            <td><%=GetTranslation("Email")%>:</td>
            <td>&nbsp;</td>
            <td><asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox></td>
            </tr>
        <tr> 
        <td colspan="7" align="left">&nbsp;</td>
            </tr>
        <tr> 
        <td colspan="6" align="left"><asp:CheckBox ID="CheckBoxUnsubscribe" runat="server" class="StrongOrange"/> <%=GetTranslation("Unsubscribe me from this service")%></td>
            <td align="right"><asp:ImageButton ID="Subscribe" runat="server" ImageUrl="<%#GetImagePath%>" /></td>
            </tr>
    </table>
    <p><asp:Label ID="LabelName" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label></p>
    <p><asp:Label ID="LabelEmailAddress" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label></p>
    <input id="TextBoxBotTrap" runat="server" type="text" style="background-color:transparent;border:0px solid white;"/>
</div>

