<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BuyerActionAgenda1.aspx.vb" Inherits="BuyerActionAgenda" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlsNew/WebUserControlAdminNavigation.ascx" TagName="AdminNavigation" TagPrefix="ucAdminNavigation" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Administration-Action Agenda</title>
    <link href="../CSS/admin.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <%--   <link rel="stylesheet" href="../JS/jquery-ui-1.8.17.custom/development-bundle/themes/base/jquery.ui.all.css" />
 <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.8.17.custom/development-bundle/ui/jquery.ui.datepicker.js"></script>--%>
    <script type="text/javascript">
        $(function () {
            $("#imgDateFrom").click(function () {
                $("#txtActionDate").focus();
            })
            $("#txtActionDate").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
                timeFormat: "HH:mm",
            });
        })
        function changeDateControl() {
            $("#imgDateFrom").click(function () {
                $("#txtActionDate").focus();
            })
            $("#txtActionDate").datepicker({
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
        function limitText() {
            var limitField = document.getElementById('txtDescription').value;
            var limitCount = document.getElementById('countdown').value;
            if (limitField.length > 1500) {
                document.getElementById('txtDescription').value = limitField.substring(0, 1500);
            } else {
                document.getElementById('countdown').value = 1500 - limitField.length;
            }
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
                                    <h1>Action Agenda</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="grdActionAgenda" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="History_ID" AllowPaging="True" AllowSorting="true" PageSize="15" OnPageIndexChanging="grdActionAgenda_PageIndexChanging" OnSorting="grdActionAgenda_Sorting" OnRowCommand="grdActionAgenda_RowCommand" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>">
                                                                    <asp:LinkButton ID="lnkSelectBuyerHistory" runat="server" ToolTip="Click to edit or view this Buyer. !!!" CommandArgument='<%#Eval("History_ID") %>' CommandName="EditBuyer" Text="Select"></asp:LinkButton></span>

                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Create_Date")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action Date" SortExpression="Action_Date">

                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Action_Date")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" Buyer ForeName" SortExpression="Buyer_Forename">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Buyer_Forename")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Buyer Surname" SortExpression="Buyer_Surname">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Buyer_Surname")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Buyer Status" SortExpression="Status">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Status")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="User" ItemStyle-HorizontalAlign="Center" SortExpression="User">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("User")%></span>
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
                                            <td colspan="6">&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td style="font-weight: bold;">User</td>
                                            <td>
                                                <asp:DropDownList ID="drpAgents" runat="server" Width="180"></asp:DropDownList>
                                            </td>
                                            <td style="font-weight: bold;">Status</td>
                                            <td colspan="2" style="vertical-align: middle;">
                                                <asp:DropDownList ID="drpBuyerStatus" runat="server" Width="180">
                                                </asp:DropDownList>
                                                &nbsp;&nbsp;&nbsp;
                                                <b>Action Date</b>
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txtActionDate" runat="server" Text="" Width="200"></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;
                                                <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateFrom" alt="calender" style="cursor: pointer;" onclick="javascript:document.getElementById('txtActionDate').click();" />
                                                &nbsp;&nbsp; &nbsp;
                                               <%--<span>
                                                   <asp:CheckBox ID="chkIsArchived" runat="server" /><b>IsArchived</b></span>--%>
                                                <asp:Button ID="btnClientHistorySave" runat="server" Text="Save" Style="cursor: pointer;" BackColor="#2D3091" ForeColor="White" OnClick="btnClientHistorySave_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnClientHistoryUpdate" runat="server" Text="Save" Style="cursor: pointer; margin-right: 170px; display: none;" BackColor="#2D3091" ForeColor="White" OnClick="btnClientHistoryUpdate_Click" />
                                            </td>

                                        </tr>

                                        <tr>
                                            <td colspan="6">&nbsp;

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="txtDescription" runat="server" Text="" TextMode="MultiLine" Width="800" Height="230" MaxLength="1500" name="txtDescription" onKeyDown="limitText();"
                                                    onKeyUp="limitText();"></asp:TextBox>
                                                &nbsp;&nbsp;<font size="2">(Maximum characters: 1500)<br>
                                                    You have
                                                    <input readonly type="text" id="countdown" name="countdown" size="3" value="1500">
                                                    characters left.</font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">&nbsp;</td>
                                        </tr>
                                        <tr id="trGridtitle" runat="server" visible="false">
                                            <td colspan="6">
                                                <h1>
                                                    <asp:Label ID="lblGridTitle" runat="server" Text="Client List"></asp:Label></h1>
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
