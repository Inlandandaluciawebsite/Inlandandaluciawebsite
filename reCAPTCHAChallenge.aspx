<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reCAPTCHAChallenge.aspx.vb" Inherits="reCAPTCHAChallenge" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>   
    <form id="form1" runat="server">
        <div id="MainContent">
            <recaptcha:RecaptchaControl
                ID="recaptcha"
                runat="server"
                Theme="white"
                PublicKey="6Le4ueQSAAAAAJjqYST-ph8F2NACHVLIVogo2-5-"
                PrivateKey="6Le4ueQSAAAAAOsXlwAizifddaFq1UJjl3xgLV5I"
            />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            <asp:Label ID="LabelResult" runat="server" Text=""></asp:Label>
        </div>    
    </form>
</body>
</html>
