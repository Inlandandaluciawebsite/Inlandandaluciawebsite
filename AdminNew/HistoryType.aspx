<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="HistoryType.aspx.vb" Inherits="BuyerHistory" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  
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
            <h3 class="page-title"><%--Buyer Source--%>
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
                                   History Types
                                    </div><div  align="right" class="right">    <a class="btn green mrgtp" href="javascript:window.history.back();" role="button" >

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
 <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                          </div>
                                </div>
                             <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                                  <div class="form-body">
       <%--          <h1>History Types</h1>--%>

<div id="TableHistoryTypes" runat="server" Width="100%">
    <div class="row">
        <div class="col-lg-6" >
            <h3>Existing</h3>
        </div>
        <div class="col-lg-6"  >
            <h3><asp:Label ID="LabelAddEdit" runat="server" Text="Add"></asp:Label><asp:Label ID="LabelID" runat="server" Visible="false"></asp:Label></h3>
        </div>
    </div>
    <div class="row" >
        <div class="col-md-6">
            <asp:GridView 
                ID="GridViewTypes" 
                runat="server" 
                Width="90%" 
                GridLines="None"                
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"
                AutoGenerateSelectButton="true" 
                AllowSorting="True" ViewStateMode="Enabled">
            </asp:GridView>
        </div>
        <div class="col-md-6">
            <div class="row">
                 <div class="col-md-3">
            Type
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="TextBoxStatus" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
            </div>
           
              <div class="row" id="TableRowArchive" runat="server"  Visible="false">
        <div class="col-md-3" >
            Archived
        </div>
        <div class="col-md-9">
            <asp:CheckBox ID="CheckBoxArchived" runat="server" />
        </div>
    </div>
    <div class="row" >
        <div class="col-md-3"></div>
        <div class="col-md-9">
            <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="btn green"/>  <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" Visible="false" CssClass="btn green"/>
        </div>
    </div>
        </div>
      
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
