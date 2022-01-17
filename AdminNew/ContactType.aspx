<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ContactType.aspx.vb" Inherits="ContactType" %>

<%@ Register Assembly="Obout.Ajax.UI" Namespace="Obout.Ajax.UI.TreeView" TagPrefix="obout" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style type='text/css'>
    .column-left{ float: left; width: 33%; }
    .column-center{ display: inline-block; width: 34%; }
    .column-right{ float: right; width: 33%; }   
    .navbuttons{ border:none; background-color:transparent; width: 30px; height: 30px; } 
    .button-search {
        background-color: #003399;
        color: #FFFFFF;
        border: 1px solid #FFCC00;
        font-size: 14px;
        margin: 5px 0px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upAddAdmin" runat="server">
        <ContentTemplate>
              <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="upAddAdmin"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="overlay" id="divProgress">
                                    &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="50"
                    Height="40" ImageUrl="images/ajaxloading.gif"  />
                                </div>
                   
                </ProgressTemplate>
            </asp:UpdateProgress>
            <h3 class="page-title">Buyer Source
            </h3> <asp:Label ID="LabelContactID" runat="server" Visible="false"></asp:Label>
           <%-- <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AddAgent.aspx">Add Agent</a>
                    </li>
                </ul>
            </div>--%>
            <!-- /.modal -->
            <!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->
            <!-- BEGIN STYLE CUSTOMIZER -->

            <!-- END STYLE CUSTOMIZER -->
            <!-- BEGIN PAGE HEADER-->

            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row">
                <div class="col-md-12">
                    <div class="tabbable tabbable-custom boxless tabbable-reversed">
                        <ul class="nav nav-tabs">
                            <li class="active"></li>
                            <li></li>
                            <li></li>
                            <li></li>
                            <li></li>
                            <li></li>
                            <li></li>
                            <li></li>
                        </ul>
                        <div class="tab-pane" id="tab_2">
                            <div class="portlet box green">
                                <div class="portlet-title">
                                    <div class="caption">
                                       Buyer Source
                                    </div>
                                </div>
                             <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                                  <div class="form-body">
                  <div class="column-left">
        <h3>New Contact Type</h3>
        <br />
        <asp:Table ID="TableName" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    Name
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxName" runat="server" Width="200px" AutoPostBack="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Admin Only
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="CheckBoxAdmin" runat="server" Checked="false" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" Visible="false" CssClass="button-search"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div class="column-center">
        <h3>Options</h3>
        <br />
        <asp:CheckBoxList ID="CheckBoxListOptions" 
            AutoPostBack="True"
            CellPadding="5"
            CellSpacing="5"
            RepeatDirection="Vertical"
            RepeatLayout="Flow"
            TextAlign="Right"
            runat="server">
                        
        </asp:CheckBoxList>

    </div>    
    <div class="column-right">
        <h3>Menu Location</h3>
        <br />
        <obout:Tree ID="TreeViewNavigation" runat="server" ClientIDMode="AutoID" CssClass="vista"></obout:Tree> 
        <div class="menu-navigation-right">
            <asp:Table ID="TableNavigation" runat="server" HorizontalAlign="Center">
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButtonUp" runat="server" ImageUrl="~/Images/Buttons/up-arrow.jpg" CssClass="navbuttons" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButtonDown" runat="server" ImageURL="~/Images/Buttons/down-arrow.jpg" CssClass="navbuttons" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
                                 </div>
                                <%--</form>--%>
                                <!-- END FORM-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END CONTENT -->
            <!-- BEGIN QUICK SIDEBAR -->
            <!-- END QUICK SIDEBAR -->
            <!-- END CONTAINER -->
            <!-- BEGIN FOOTER -->
        </ContentTemplate>
            
    </asp:UpdatePanel>
</asp:Content>
