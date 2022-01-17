<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_Example_Int_.aspx.cs" Inherits="_Example_Int_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="OrderForm" action="https://mdepayments.epdq.co.uk/ncol/test/orderstandard.asp" method="post" runat="server">
    <div>
        <asp:HiddenField ID="AMOUNT" runat="server" />
        <asp:HiddenField ID="CN" runat="server" />
        <asp:HiddenField ID="COM" runat="server" />
        <asp:HiddenField ID="CURRENCY" runat="server" />
        <asp:HiddenField ID="EMAIL" runat="server" />
        <asp:HiddenField ID="FONTTYPE" runat="server" />
        <asp:HiddenField ID="LANGUAGE" runat="server" />
        <asp:HiddenField ID="LOGO" runat="server" />
        <asp:HiddenField ID="ORDERID" runat="server" />
        <asp:HiddenField ID="OWNERADDRESS" runat="server" />
        <asp:HiddenField ID="OWNERCTY" runat="server" />
        <asp:HiddenField ID="OWNERTELNO" runat="server" />
        <asp:HiddenField ID="OWNERTOWN" runat="server" />
        <asp:HiddenField ID="OWNERZIP" runat="server" />
        <asp:HiddenField ID="PMLISTTYPE" runat="server" />
        <asp:HiddenField ID="PSPID" runat="server" />
        <asp:HiddenField ID="BGCOLOR" runat="server" />
        <asp:HiddenField ID="BUTTONBGCOLOR" runat="server" />
        <asp:HiddenField ID="BUTTONTXTCOLOR" runat="server" />
        <asp:HiddenField ID="TBLBGCOLOR" runat="server" />
        <asp:HiddenField ID="TBLTXTCOLOR" runat="server" />
        <asp:HiddenField ID="TITLE" runat="server" />
        <asp:HiddenField ID="TXTCOLOR" runat="server" />
        
        <asp:HiddenField ID="SHASign" runat="server" />



        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

        <input id="Submit1" type="submit" value="Go To Payment Page" />
    </div>

    </form>
</body>
</html>
