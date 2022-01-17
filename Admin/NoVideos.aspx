<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NoVideos.aspx.vb" Inherits="NoVideos" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebUserControlAdminNavigation.ascx" TagName="AdminNavigation" TagPrefix="ucAdminNavigation" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Administration-NO Videos Properties</title>
    <link href="../CSS/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
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
                                    <h1>Properties With No Videos</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="6">
                                                <asp:HiddenField ID="hdnBuyerId" runat="server" />
                                                <asp:GridView ID="grdNoVideosProperties" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="Property_Ref" AllowPaging="True" AllowSorting="true" PageSize="15" OnPageIndexChanging="grdNoVideosProperties_PageIndexChanging" OnSorting="grdNoVideosProperties_Sorting" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%--<asp:LinkButton ID="lnkSelectBuyerHistory" runat="server" ToolTip="Click to edit or view this property. !!!" CommandArgument='<%#Eval("Property_Ref") %>' CommandName="EditBuyer" Text="Select"></asp:LinkButton>--%>
                                                                <a href='BackOffice.aspx?Property_Ref=<%#Eval("Property_Ref")%>&Type=PropertyDetails'>Select</a>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Property Ref" SortExpression="Property_Ref">
                                                            <ItemTemplate>
                                                                <%#Eval("Property_Ref")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Create Date" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <%#Eval("Create_Date_02") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Modified" SortExpression="Last_Modified">
                                                            <ItemTemplate>
                                                                <%#Eval("Last_Modified_02")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Door Key" SortExpression="Door_Key">
                                                            <ItemTemplate>
                                                                <%#Eval("Door_Key")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Region/Town" SortExpression="regiontext">
                                                            <ItemTemplate>
                                                                <%#Eval("regiontext")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Property Address" SortExpression="Property_Address">
                                                            <ItemTemplate>
                                                                <%#Eval("Property_Address")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Vendor" SortExpression="Vendor">
                                                            <ItemTemplate>
                                                                <%#Eval("Vendor")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Photos" ItemStyle-HorizontalAlign="Center" SortExpression="Num_Photos">
                                                            <ItemTemplate>
                                                                <%#Eval("Num_Photos")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"></ItemStyle>
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
