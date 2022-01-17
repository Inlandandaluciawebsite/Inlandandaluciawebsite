<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OnlineMagazineAddEdit.aspx.vb" Inherits="Admin1_OnlineMagazine" ValidateRequest="false"  %>

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
    <script src="../JS/Validation.js" type="text/javascript"></script>
   <link href="bootstrap-switch.min.css" rel="stylesheet" />
      <script type="text/javascript" lang="javascript">
          function Validations() {
              var IsError = '';
              var invalid = " "; // Invalid character is a space
              IsError += ValidateRequiredField(document.getElementById('<%=txtEmbedCode.ClientID%>'), "Please enter Embed code!");
              if (IsError.length > 0) {
                  alert(IsError);
                  return false;
              }
              return true;
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
<body  onmousemove="SetProgressPosition(event)"  class="twoColFixRtHdr">
        <div id="container">
        <form id="formBackOffice1" runat="server">
            
            <asp:ScriptManager ID="ScriptManagerMain" EnablePartialRendering="true" runat="server">
            </asp:ScriptManager>
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
                                    <h1>Add/Edit Online Magazine</h1>
                                    <br>
                                    <table width="100%">
                                        <tr>
                                            <td >
                                              Embed Code
                                            </td>
                                            <td >
                                            
                                                <asp:TextBox ID="txtEmbedCode" runat="server" TextMode="MultiLine" Rows="6" Columns="53" Placeholder="Embed Code" class="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan=""></td> 
                                            <td colspan="">
                                             <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="default-button" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="default-button" OnClick="btnUpdate_Click" Style="display: none" OnClientClick="return Validations();"></asp:Button>
                                                
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