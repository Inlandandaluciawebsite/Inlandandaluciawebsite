<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OnlineMagazine.aspx.vb" Inherits="Admin1_OnlineMagazine" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebUserControlAdminNavigation.ascx" TagName="AdminNavigation" TagPrefix="ucAdminNavigation" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Administration-Action Agenda</title>
    <link href="../CSS/admin.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
       <script type="text/javascript">
         function SelectAll(id) {
             var k = document.getElementsByTagName('input');
             for (var i = 0; i < k.length; i++) {
                 if (k[i].type == "checkbox") {
                     if (id.checked) {
                         k[i].checked = true;
                     }
                     else {
                         k[i].checked = false;
                     }
                 }
             }
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
         $(function () {
            // alert();
             $(document).off('click', '#BtnDelete').on('click', '#BtnDelete', function () {
                 if ($("#grdmagazine input:checkbox:checked").length > 0) {
                     if (confirm("Are you sure you want to delete!") == true) {
                         return true
                     }
                     else {
                         return false;
                     }
                 }
                 else {
                     alert("Please select atleast one checkbox to Delete Record");
                     return false;
                 }

             });
         });
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
<body  onmousemove="SetProgressPosition(event)" class="twoColFixRtHdr">
        <div id="container">
        <form id="formBackOffice1" runat="server">
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
         
          
                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="UpdatePanelMain1"
                            DisplayAfter="1">
                            <ProgressTemplate>
                                <div class="overlay" id="divProgress">
                                    &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="80"
                    Height="80" ImageUrl="../Images/ajaxloading.gif" Style="margin-top: 7px;" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="UpdatePanelMain1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div id="Div1">
                                    <h1>Online Magazine</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="6">
                                                <asp:HiddenField ID="hdnBuyerId" runat="server" />
                                                <asp:GridView ID="grdmagazine" DataKeyNames="MId" AllowPaging="true" PageSize="10"  OnRowCommand="grdmagazine_RowCommand" Font-Names="Open Sans, sans-serif"  HeaderStyle-Height="20px" BorderColor="#dddddd" OnPageIndexChanging="grdmagazine_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                                            <HeaderTemplate>
                                                                <input type="checkbox" onclick="SelectAll(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField  HeaderText="EmbedCode" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign=Center>
                                                            <ItemTemplate>
                                                                <%#System.Web.HttpUtility.HtmlEncode(Eval("EmbedCode"))%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Archived"  ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"  HeaderStyle-HorizontalAlign=Center>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnStatus" CommandName="changestatus" CommandArgument='<%#Eval("MId")%>' BorderStyle="None"
                                                                    ToolTip="Click to change status. !!!" ImageUrl='<%#Eval("IsActive1")%>' runat="server"
                                                                    OnClientClick="javascript:return confirm('Are you sure you want to make this change !');" AlternateText="image" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="View"  ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle"  HeaderStyle-HorizontalAlign=Center>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgView" runat="server" BorderStyle="None" CommandArgument='<%#Eval("MID")%>' ToolTip="Click to edit or view this admin " CommandName="editmagazine" ImageUrl="images/view-img.png" />                                                            </ItemTemplate>
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
                                            <td colspan="6">
                                                    </td>
                                        </tr>

                                       
                                       
                                       
                                    </table>
                                    <table >
                                        <tr>
                                            <td>  <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Text="No Record Found!" Visible="false"></asp:Label>
                                <asp:Button ID="BtnDelete" runat="server" class="btn green" Text="Delete" Visible="true" OnClick="BtnDelete_Click"  />
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
                                            <asp:ImageButton ID="ImageButtonSignOut" runat="server" CssClass="agentloginbutton" OnClick="ImageButtonSignOut_Click" />
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