<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewingPhotos.aspx.vb" Inherits="ViewingPhotos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Viewing Photos</title>
</head>
<body>
    <form id="formViewingPhotos" runat="server">
    <div>        
        <table width="100%">
            <tr> 
                <td colspan="3" align="center">
                    <strong><asp:Label ID="LabelPropertyRef" runat="server"></asp:Label></strong>
                </td>
            </tr>
            <span id="SpanImages" runat="server"></span>
        </table>
    </div>
    </form>
</body>
</html>
