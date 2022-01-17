<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlContactUs.ascx.vb" Inherits="WebUserControlContactUs" %>
<h1><%=GetTranslation("Contact Us")%></h1>
<p><%=GetTranslation("Whatever your query, we are happy to help you.")%></p>
<p><%=GetTranslation("We pride ourselves in personalised and good service, trying to give you as much help as possible. As we always want you to have the individual attention you need, please try to reserve an appointment with us before you leave your home, that way we can be ready and available for you personally at a pre-arranged time and date that suits you.")%></p>
<p><%=GetTranslation("Please fill in the form below to contact us at")%> <strong><%=GetTranslation("Head Office in Spain")%> +34 952 741 525</strong> <%=GetTranslation("or by")%><a href="skype:inlandandalucia.com?call"><img src="images/buttons/skype_button.png" alt="Skype Me!" width="70" height="28" align="absmiddle" style="border: none;" /></a><%=GetTranslation("and we will contact you as soon as possible.")%></p>
<div class="contactform">    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td><span class="contactformleft"><%=GetTranslation("First Name")%>:</span></td>
            <td><asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
                *&nbsp;
                <asp:Label ID="LabelFirstName" runat="server" Text="<%#GetFirstNameErrorText%>" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><span class="contactformleft"><%=GetTranslation("Last Name")%>:</span></td>
            <td><asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                *&nbsp;
                <asp:Label ID="LabelLastName" runat="server" Text="<%#GetLastNameErrorText%>" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><span class="contactformleft"><%=GetTranslation("Address")%>:</span></td>
            <td><asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><span class="contactformleft"><%=GetTranslation("Telephone")%>:</span></td>
            <td><asp:TextBox ID="TextBoxTelephone" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><span class="contactformleft"><%=GetTranslation("Email")%>:</span></td>
            <td> 
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            *&nbsp;
            <asp:Label ID="LabelEmailAddress" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top"><span class="contactformleft"><%=GetTranslation("Comment")%>:</span></td>
            <td><asp:TextBox ID="TextBoxComment" runat="server" Height="200px" TextMode="MultiLine" Width="300px"></asp:TextBox> *<br />
                <asp:Label ID="LabelComment" runat="server" Text="<%#GetCommentErrorText%>" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td> * = <%=GetTranslation("Mandatory fields")%>
            <p>
                <asp:ImageButton ID="ButtonSend" runat="server" ImageUrl="<%#GetImagePath%>" />
            </p>
            </td>
        </tr>
    </table>
    <input id="TextBoxBotTrap" runat="server" type="text" style="background-color:transparent;border:0px solid white;"/>
</div>
