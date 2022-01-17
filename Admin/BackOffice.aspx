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
<%@ Reference Control="~/Controls/WebUserControlSalespersonTours.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlNoVideos.ascx" %>
<%@ Reference Control="~/Controls/WebUserControlActionAgenda.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <title>Administration</title>
        <link href="../CSS/admin.css" rel="stylesheet" type="text/css" />
     <link href="../CSS/admin.css" rel="stylesheet" type="text/css" />
           <link type="text/css" rel="stylesheet" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <%--<link rel="stylesheet" href="../js/jquery-ui-1.8.17.custom/development-bundle/themes/base/jquery.ui.all.css">
    <script type="text/javascript" src="../js/jquery-ui-1.8.17.custom/development-bundle/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.datepicker.js"></script>
   --%>   
    <script type="text/javascript">
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $("#imgDateFrom").click(function () {

                    $("#AdminSalesperontour_txtDateFrom").focus();
                })
                $("#imgDateTo").click(function () {
                    $("#AdminSalesperontour_txtDateTo").focus();
                })
                $("#AdminSalesperontour_txtDateFrom").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                });

                $("#AdminSalesperontour_txtDateTo").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                });
            });
        });


         
       

    </script>


     <script type="text/javascript">
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $("#imgDateFrom1").click(function () {
                    $(".ActionDate01").focus();
                })
                $(".ActionDate01").datepicker({
                    altField: "#alternate",
                    altFormat: "dd/MM/yyyy",
                    dateFormat: "dd-mm-yy",
                    timeFormat: "HH:mm",
                });
            })
            function changeDateControl() {
                $("#imgDateFrom1").click(function () {
                    $(".ActionDate01").focus();
                })
                $(".ActionDate01").datepicker({
                    altField: "#alternate",
                    altFormat: "dd/MM/yyyy",
                    dateFormat: "dd-mm-yy",
                    timeFormat: "HH:mm",
                });
            }
        });
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(limitText);

            function limitText() {
                var limitField = $('.Description01').val();
                var limitCount = document.getElementById('countdown').value;
                if (limitField.length > 1500) {
                    $('.Description01').val(limitField.substring(0, 1500));
                } else {
                 
                    document.getElementById('countdown').value = 1500 - limitField.length;
                }
            }
       
    </script>
      <script type="text/javascript">
          $(function () {
              Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                  $("#AdminProperty1_ButtonUploadImage").bind("click", function () {
                      if (typeof ($("#AdminProperty1_FileUploadImage")[0].files) != "undefined") {
                          var size = parseFloat($("#AdminProperty1_FileUploadImage")[0].files[0].size / 1024).toFixed(2);
                          if (size > 150) {
                              $("#AdminProperty1_lblimgsize").css("display", "block");

                              return false;
                          }
                          else {
                              $("#AdminProperty1_lblimgsize").css("display", "none");
                              return true;
                          }
                      } else {
                          return false;

                      }
                  }); 
                  $("#AdminProperty1_TextBoxShortDescription").keypress(function (e) {
                      if (String.fromCharCode(e.which).match(/[^A-Za-z0-9_.,$@*()-+=~`%#<>?\/\\\;":'^{}! ]/)) {
                          e.preventDefault();
                          alert("& character is not allowed.");
                      }
                  });
                  $("#AdminProperty1_TextBoxDescription").keypress(function (e) {
                      if (String.fromCharCode(e.which).match(/[^A-Za-z0-9_.,$@*()-+=~`%#<>?\/\\\;":'^{}! ]/)) {
                          e.preventDefault();
                          alert("& character is not allowed.");
                      }
                  });
              });
          });
</script>


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
            function SetProgressPosition(e) {
                var posx = 0;
                var posy = 0;
                if (!e) var e = window.event;
                if (e.pageX || e.pageY) {
                    posx = e.pageX;
                    posy = e.pageY;
                }
                else if (e.clientX || e.clientY) {
                    posx = e.clientX + document.documentElement.scrollLeft;
                    posy = e.clientY + document.documentElement.scrollTop;
                }
                document.getElementById('divProgress').style.left = posx - 8 + "px";
                document.getElementById('divProgress').style.top = posy - 8 + "px";
            }

        </script>
            
        <style type="text/css">
        .overlay {
            border: black 1px solid;
            padding: 5px;
            z-index: 100;
            width: 80px;
            position: absolute;
            background-color: #fff;
            -moz-opacity: 0.75;
            opacity: 0.75;
            filter: alpha(opacity=75);
            font-family: Tahoma;
            font-size: 11px;
            font-weight: bold;
            text-align: center;
        }
    </style>
    </head>
    <body class="twoColFixRtHdr" onmousemove="SetProgressPosition(event)">
              

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
                           <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="UpdatePanelMain"
                            DisplayAfter="1">
                            <ProgressTemplate>
                                <div class="overlay" id="divProgress">
                                    &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="80"
                    Height="80" ImageUrl="../Images/ajaxloading.gif" Style="margin-top: 7px;" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                            <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanelOptions" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Table ID="TableOptions" runat="server">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                              <div id="result"></div>
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
