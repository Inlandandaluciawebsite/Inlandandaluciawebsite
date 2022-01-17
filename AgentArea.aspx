<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AgentArea.aspx.vb" Inherits="AgentArea" %>
<%@ Register Src="Controls/WebUserControlAdvancedSearch.ascx" TagName="AdvancedSearch" TagPrefix="ucAdvancedSearch" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Andalucia property | Inland Andalucia</title>
<meta name="description" content="Andalucia property, find your property in Inland Andalucia, we have a great amount of inland properties in Andalucia at bargain prices. Buy your property, villa, town house, finca, through a reliable Andalucia Real Estate" />
<meta name="keywords" content="spain property, properties Spain, Andalucia property" />
<link rel="Shortcut Icon" href="/Images/Icons/favicon.ico" type="image/x-icon"/>
<link href="css1/style.css" rel="stylesheet" type="text/css" /><link rel="stylesheet" href="http://weatherandtime.net/new_wid/w_2/style.css" type="text/css" media="screen" />

<!--[if IE 5]>
<style type="text/css"> 
/* place css box model fixes for IE 5* in this conditional comment */
.twoColFixRtHdr #sidebar1 { width: 220px; }
</style>
<![endif]--><!--[if IE]>
<style type="text/css"> 
/* place css fixes for all versions of IE in this conditional comment */
.twoColFixRtHdr #sidebar1 { padding-top: 30px; }
.twoColFixRtHdr #mainContent { zoom: 1; }
/* the above proprietary zoom property gives IE the hasLayout it needs to avoid several bugs */
</style>
<![endif]-->
</head>
<body class="twoColFixRtHdr">
<form ID="AgentAreaForm" RunAt="server">
<div id="container">
    <div class="agentarea" align="center">   
        <asp:ScriptManager id="ScriptManagerAgentArea" EnablePartialRendering="true" runat="server" >
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelAgentArea" runat="server" UpdateMode="Conditional">
        <ContentTemplate>            
             <ucAdvancedSearch:AdvancedSearch id="AdvancedSearch1" runat="server" />
        </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton ID="ImageButtonBack" runat="server" CssClass="agentloginbutton" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ID="ImageButtonSignOut" runat="server" CssClass="agentloginbutton" />
                </asp:TableCell>
            </asp:TableRow> 
        </asp:Table>                            
    </div>
  </div>
  <!-- end #footer -->
<!-- end #container -->

</form>
</body>
</html>