<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ClientTour.aspx.vb" Inherits="ClientTour" %>
<%@ Register Src="~/ControlsNew/WebUserControlAdminClientTourPrint.ascx" TagName="AdminClientTourPrint" TagPrefix="ucAdminClientTourPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="HeadClientTourPrint" runat="server">
        <title>Client Tour</title>
    </head>
    <body>
        <form id="formClientTourPrint" runat="server">
            <asp:ScriptManager id="ScriptManagerClientTourPrint" EnablePartialRendering="true" runat="server" >
            </asp:ScriptManager>
            <div>
                <ucAdminClientTourPrint:AdminClientTourPrint ID="AdminClientTourPrint" runat="server"/>
            </div>
        </form>
    </body>
</html>
