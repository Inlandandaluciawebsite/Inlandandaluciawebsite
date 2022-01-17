<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ClientHistory.aspx.vb" Inherits="ClientHistory" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebUserControlAdminNavigation.ascx" TagName="AdminNavigation" TagPrefix="ucAdminNavigation" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Administration-Client History</title>
    <link href="../CSS/admin.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="Stylesheet" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="../JS/jquery-ui-1.8.17.custom/development-bundle/themes/base/jquery.ui.all.css" />
    <%-- <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.datepicker.js"></script>--%>
     <link type="text/css" rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
    <%--<script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js"></script>--%>
    <script type="text/javascript" src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#imgDateFrom").click(function () {
                $("#txtActionDate").focus();
            })
            $("#txtActionDate").datepicker({
                altField: "#alternate",
                altFormat: "dd/MM/yyyy",
                dateFormat: "dd-mm-yy",
                timeFormat: "HH:mm",
            });
        })
        function changeDateControl() {
            $("#imgDateFrom").click(function () {
                $("#txtActionDate").focus();
            })
            $("#txtActionDate").datepicker({
                altField: "#alternate",
                altFormat: "dd/MM/yyyy",
                dateFormat: "dd-mm-yy",
                timeFormat: "HH:mm",
            });
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
        function limitText() {
            var limitField = document.getElementById('txtDescription').value;
            var limitCount = document.getElementById('countdown').value;
            if (limitField.length > 1500) {
                document.getElementById('txtDescription').value = limitField.substring(0, 1500);
            } else {
                document.getElementById('countdown').value = 1500 - limitField.length;
            }
        }

            function ShowSuccessMsg() {
            $(function () {
                $("#dialog").dialog({
                    title: "Success",
                    width: '500',
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
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

    /*.ui-dialog {
        border-radius: 50px!important;
    }

        .ui-dialog .ui-dialog-titlebar-close {
            margin: -11px 22px 0!important;
        }

    .ui-widget input, .ui-widget select, .ui-widget textarea, .ui-widget button, td {
        font-family: "MS Sans Serif"!important;
        font-size: 14px !important;
    }*/
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
                        <asp:UpdatePanel ID="UpdatePanelNavigation" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <ucAdminNavigation:AdminNavigation ID="AdminNavigation" runat="server" UpdateMode="Conditional" />
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
                                <div id="Div1">
                                    <h1>Client History</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdBuyerHistory" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="History_ID" AllowPaging="True" AllowSorting="true" PageSize="10" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50" OnSorting="grdBuyerHistory_Sorting" OnRowCommand="grdBuyerHistory_RowCommand" OnPageIndexChanging="grdBuyerHistory_PageIndexChanging">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Created" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <%#Eval("Create_Date")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ActionDate" SortExpression="Action_Date">
                                                            <ItemTemplate>
                                                                <%#Eval("Action_Date")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Buyer ForeName" ItemStyle-HorizontalAlign="center" SortExpression="Buyer_ForeName">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyer_ForeName")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="center" VerticalAlign="top" Width="400px" />
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="400px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Buyer Surname" ItemStyle-HorizontalAlign="center" SortExpression="Buyer_Surname">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyer_Surname")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="center" VerticalAlign="top" Width="400px" />
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="400px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Created By" SortExpression="CreatedBy">
                                                            <ItemTemplate>
                                                                <%#Eval("CreatedBy")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                                            <ItemTemplate>
                                                                <%#Eval("Type")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="History" ItemStyle-HorizontalAlign="Center" SortExpression="History_Text">
                                                            <ItemTemplate>
                                                                <%#Eval("ShortHistory_Text")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="400px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" SortExpression="History_Text">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkview" runat="server" Text="View" ToolTip="Click here to read full history text!!" data-target="#dialog" CommandName="moreinfo" CommandArgument='<%#Eval("History_Id")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="400px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px"></ItemStyle>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                    <RowStyle CssClass="GridItemStyle" />
                                                    <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>



                                    </table>
                                </div>
                                <div>
                                        <div id="dialog" style="width: 1000px; display:none">
                                             
                                              

                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                            <h1>Client History</h1>
                                                        </div>
                                                        <div class="col-lg-7">
                                                            <div class="col-lg-7">
                                                                <p>CreateDate:<asp:Label ID="lblCreateDate" runat="server"></asp:Label></p>
                                                                <p>Buyer Forename:  
                                                                    <asp:Label ID="lblBuyerForename" runat="server"></asp:Label></p>
                                                                <p>Buyer Surname:<asp:Label ID="lblBuyerSurname" runat="server"></asp:Label></p>

                                                                <p>ActionDate: 
                                                                    <asp:Label ID="lblActionDate" runat="server"></asp:Label></p>
                                                                 <p>Type: 
                                                                    <asp:Label ID="lblType" runat="server"></asp:Label></p>
                                                                 <p>Created By: 
                                                                    <asp:Label ID="lblCreatedBy" runat="server"></asp:Label></p>
                                                                <p class="text-left">History:
                                                                    <asp:Label ID="lblHistoryText" runat="server"></asp:Label>
                                                                </p>
                                                            </div>
                                                        </div>


                                                    </div>

                                               
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanelOptions" runat="server">
                            <ContentTemplate>
                                <asp:Table ID="TableOptions" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:ImageButton ID="ImageButtonBack" runat="server" PostBackUrl="~/Admin/BackOffice.aspx" CssClass="agentloginbutton" Visible="true" />
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
