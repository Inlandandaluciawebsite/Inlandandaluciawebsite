<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AgentActivitySelection.aspx.vb" Inherits="AgentActivitySelection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Activity Selection</title>
        <link href="css1/style.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <form id="formAgentActivitySelection" runat="server">
            <div id="mainContent">     
                <div class="agentlogin" align="center">     
                    <asp:Table ID="TableAgentActivitySelection" runat="server">
                         <asp:TableRow ID="trPartnerSelection" runat="server" Visible="false">
                            <asp:TableCell>
                                Select Partner
                            </asp:TableCell> 
                            <asp:TableCell>
                                <asp:DropDownList runat="server" ID="drpContactPartner">                                
                                </asp:DropDownList>
                            </asp:TableCell> 
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <%= GetTranslation("Select Activity")%> :
                            </asp:TableCell> 
                            <asp:TableCell>
                                <asp:DropDownList runat="server" ID="DropDownListActivity">                                
                                </asp:DropDownList>
                            </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>
                            </asp:TableCell> 
                            <asp:TableCell>
                                <asp:ImageButton ID="ButtonContinue" runat="server" ImageUrl="~/Images/Buttons/continue.jpg" />
                            </asp:TableCell> 
                        </asp:TableRow>

                    </asp:Table>

                    <asp:ImageButton ID="ImageButtonSignOut" runat="server" CssClass="agentloginbutton" />

                </div>
            </div>
        </form>
    </body>
</html>
