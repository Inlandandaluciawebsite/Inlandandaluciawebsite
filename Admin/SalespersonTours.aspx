<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SalespersonTours.aspx.vb" Inherits="SalespersonTours" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebUserControlAdminNavigation.ascx" TagName="AdminNavigation" TagPrefix="ucAdminNavigation" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Administration</title>
    <link href="../CSS/admin.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../JS/jquery-ui-1.8.17.custom/development-bundle/themes/base/jquery.ui.all.css">
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.datepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#imgDateFrom").click(function () {
                $("#txtDateFrom").focus();
            })
            $("#imgDateTo").click(function () {
                $("#txtDateTo").focus();
            })
            $("#txtDateFrom").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
                timeFormat: "HH:mm",
            });

            $("#txtDateTo").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
                timeFormat: "HH:mm",
            });
        })
        function changeDateControl() {
            $("#imgDateFrom").click(function () {
                $("#txtDateFrom").focus();
            })
            $("#imgDateTo").click(function () {
                $("#txtDateTo").focus();
            })
            $("#txtDateFrom").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
                timeFormat: "HH:mm",
            });

            $("#txtDateTo").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
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
                                    <h1>Salesperson Tours</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td style="font-weight: bold;">User</td>
                                            <td>
                                                <asp:DropDownList ID="drpUsers" runat="server" Width="250">
                                                </asp:DropDownList></td>
                                            <td>&nbsp;
                                            </td>
                                            <td style="font-weight: bold;">Date Range Selection</td>
                                            <td>
                                                <asp:TextBox ID="txtDateFrom" runat="server" Text="" placeholder="From" Width="220"></asp:TextBox></td>
                                            <td align="center">
                                                <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateFrom" style="cursor: pointer;" onclick="javascript:document.getElementById('txtDateFrom').click();" /></td>
                                            <td>
                                                <asp:TextBox ID="txtDateTo" runat="server" Text="" placeholder="To" Width="220"></asp:TextBox></td>
                                            <td align="center">
                                                <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateTo" style="cursor: pointer;" onclick="javascript:document.getElementById('txtDateTo').Click();" /></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="10">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" align="right">
                                                <asp:Button ID="btnListByClient" runat="server" Text="List By Client" OnClick="btnListByClient_Click" Style="cursor: pointer;" BackColor="#2D3091" ForeColor="White" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnListByProperty" runat="server" Text="List By Property" OnClick="btnListByProperty_Click" Style="cursor: pointer;" BackColor="#2D3091" ForeColor="White" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10">&nbsp;</td>
                                        </tr>
                                        <tr id="trGridtitle" runat="server" visible="false">
                                            <td colspan="10">
                                                <h1>
                                                    <asp:Label ID="lblGridTitle" runat="server" Text="Client List"></asp:Label></h1>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10">
                                                <asp:GridView ID="grdClientList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="tour_id" AllowPaging="True" AllowSorting="true" OnSorting="grdClientList_Sorting" PageSize="15" OnPageIndexChanging="grdClientList_PageIndexChanging" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="tour_datetime">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_datetime") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Forename" SortExpression="Buyerforename">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyerforename")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Surname" SortExpression="Buyersurname">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyersurname")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Telephone" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerTelephone">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerTelephone")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerEmail">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerEmail")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerStatus">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerStatus")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                    <RowStyle CssClass="GridItemStyle" />
                                                    <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                </asp:GridView>
                                                <asp:GridView ID="grdPropertyList" runat="server" Visible="false" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="tour_id" AllowPaging="True" AllowSorting="true" OnSorting="grdPropertyList_Sorting" PageSize="15" OnPageIndexChanging="grdPropertyList_PageIndexChanging" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Property" SortExpression="PropertyRef" >
                                                            <ItemTemplate>
                                                                <%#Eval("PropertyRef")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="tour_datetime">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_datetime") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tour Id" SortExpression="tour_id">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_id")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tour Feedback"  SortExpression="TourFeedback">
                                                            <ItemTemplate>
                                                                <%#Eval("TourFeedback") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="700px" />
                                                            <ItemStyle  VerticalAlign="Middle" Width="700px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                    <RowStyle CssClass="GridItemStyle" />
                                                    <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanelOptions" runat="server" UpdateMode="Conditional">
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
