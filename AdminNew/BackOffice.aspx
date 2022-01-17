<%@ Page Language="VB" AutoEventWireup="false"  CodeFile="BackOffice.aspx.vb" Inherits="BackOffice" EnableEventValidation="false" ValidateRequest="false"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controls/WebUserControlAdminNavigation.ascx" tagname="AdminNavigation" tagprefix="ucAdminNavigation" %>
<%@ Reference Control="~/Controls/WebUserControlAdminMessage.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminProperty.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminPropertySearch.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminContact.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminContactSearch.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminTranslations.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminClientTour.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminClientTourFeedback.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminClientTourSearch.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminBuyer.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminBuyerSearch.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminFeaturedProperties.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminPostcodes.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminLatestProperties.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminUpdateSystemVariables.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminClientTourPropertySelection.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminTestimonials.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminPassword.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminDatabaseStatistics.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlReportClientTourMissingFeedback.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminLawyerArea.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminHistoryTypes.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminContactType.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlAdminMenuEditor.ascx" %>

<%@ Reference Control="~/Controls/WebUserControlIntelliSelect.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <title>Administration</title>
        <link href="../CSS/admin.css" rel="stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript">

            function uploadComplete(sender, args) {
                __doPostBack('upTop', '');
            }

            function Cancel(e) {

                if (window.event) { // IE
                    event.returnValue = false;
                }
                else { // FireFox
                    e.preventDefault();
                }

                return false;
            }
    
            function CheckNumeric(evt) {

                var e = window.event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;
                var bCancel = false;

                if ((charCode < 48 || charCode > 57) & charCode != 8) 
                {
                    bCancel = true;
                }

                if (bCancel) {
                    return Cancel(e)
                }
            }

            function CheckDecimal(field, evt) {

                var e = window.event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;
                var bCancel = false;

                if ((charCode == 46) & ((field.value.indexOf(".") != -1) || (field.value.length < 1))) {
                    bCancel = true;
                }
                else if ((charCode < 48 || charCode > 57) & charCode != 8 & charCode != 46) {
                    bCancel = true;
                }

                if (bCancel) {
                    return Cancel(e)
                }
            }

            function CheckDecimalAllowNegative(field, evt) {

                var e = window.event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;
                var bCancel = false;

                if (((charCode == 46) && (field.value == "-")) || (((charCode == 46) && ((field.value.indexOf(".") != -1) || (field.value.length < 1))) || ((charCode == 45) && ((field.value.indexOf("-") != -1) || (field.value.length > 0))))) {
                    bCancel = true;
                }
                else if ((charCode < 48 || charCode > 57) & charCode != 8 & charCode != 46 & charCode != 45) {
                    bCancel = true;
                }

                if (bCancel) {
                    return Cancel(e)
                }
            }

            function CheckCurrency(field, evt) {

                var e = window.event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;
                var bCancel = false;

                if ((charCode == 46) && ((field.value.indexOf(".") != -1) || (field.value.length < 1))) {
                    bCancel = true;
                }
                else if ((field.value.indexOf(".") != -1) && (field.value.length > (field.value.indexOf(".") + 2))) {
                    bCancel = true;
                }
                else if ((charCode < 48 || charCode > 57) & charCode != 8 & charCode != 46) {
                    bCancel = true;
                }

                if (bCancel) {
                    return Cancel(e)
                }
            }

            redirectToPage = function (url) {
                void (window.open(url, "child_window"));
                return false;
            }

        </script>

    </head>
    <body class="twoColFixRtHdr">
        <div id="container">    
            <form id="formBackOffice" runat="server">
                <asp:ToolkitScriptManager ID="ScriptManagerMain" EnablePartialRendering="true" runat="server">
                </asp:ToolkitScriptManager>
       
                <div id="header">
                    <asp:Image ID="ImageHeader" runat="server" alt="Header" />
                </div>
                <div class="topnavwrap">
                    <div class="topnav">
                        <div class="nav">
                            <asp:UpdatePanel ID="UpdatePanelNavigation" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
                                <ContentTemplate>
                                    <ucAdminNavigation:AdminNavigation ID="AdminNavigation" runat="server" UpdateMode="Conditional"/>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="wrap">
                    <div class="center">
                        <div id="mainContent">
                            <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanelOptions" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Table ID="TableOptions" runat="server">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:ImageButton ID="ImageButtonBack" runat="server" CssClass="agentloginbutton" Visible="false" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:ImageButton ID="ImageButtonForward" runat="server" CssClass="agentloginbutton" Visible="false" />
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:ImageButton ID="ImageButtonSignOut" runat="server" CssClass="agentloginbutton" />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="clearfloat"></div>
                        </div>
                        <div id="footer">All rights reserved Inland Andalucia Ltd</div>
                    </div>
                </div>
            </form>
        </div>
    </body>
</html>
