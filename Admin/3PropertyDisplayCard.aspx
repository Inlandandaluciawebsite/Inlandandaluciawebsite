<%@ Page Language="VB" AutoEventWireup="false" CodeFile="3PropertyDisplayCard.aspx.vb" Inherits="Admin_3PropertyDisplayCard" %>
<%@ Register Src="~/Controls/WebUserControlAdmin3PropertyDisplayCard.ascx" TagName="Admin3PropertyDisplayCard" TagPrefix="ucAdmin3PropertyDisplayCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Three Property Display Card</title>
    <style type="text/css">
<!--
body {
	font-family: "Arial", Helvetica, sans-serif;
	font-size: 14px;
	background: #FFF;
	margin: 10px; 
	padding: 0;
	text-align: center; 
	color: #000000;
}
.oneColFixCtr #container {
	width: 675px; 
	max-height: 900px;
	background: #FFFFFF;
	margin: 0 auto; 
	text-align: justify; 
	}
.oneColFixCtr #mainContent {
	padding: 0 
}
</style>
<style type="text/css" media="print">
    .NonPrintable
    {
        display: none;
    }
    @page 
    {
        size: auto;   /* auto is the initial value */
        margin: 0px;  /* this affects the margin in the printer settings */
        
    }

    body 
    {
        background-color:#FFFFFF; 
        margin: 10px;  /* this affects the margin on the content before sending to printer */
		height: 1000px;
   }

    @media print {
	.page-break	{ display: block;page-break-before: always; }
}
</style>

<script type="text/javascript" >
    function printpage() {
        window.print();
    }        
</script>
</head>
<body class="oneColFixCtr">
<div>
    <a href="Javascript: window.print();" class="NonPrintable">Print this page</a>
</div>
    <form id="form3PropertyDisplayCard" runat="server">
    <div id="container">    
  <div id="mainContent">
        <asp:ScriptManager id="ScriptManager3PropertyDisplayCard" EnablePartialRendering="true" runat="server" >
        </asp:ScriptManager>
        <div>
            <ucAdmin3PropertyDisplayCard:Admin3PropertyDisplayCard ID="Admin3PropertyDisplayCard" runat="server"/>
        </div>
    </div></div>
    </form>
</body>
</html>
