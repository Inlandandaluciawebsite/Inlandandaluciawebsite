<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" EnableViewState="false"  AutoEventWireup="false" CodeFile="Changepassword.aspx.vb" Inherits="Changepassword" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upAddAdmin" runat="server" UpdateMode="Conditional" >
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
            <h3 class="page-title">
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
                              Change Password
                                    </div>
                                </div>
                             <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                                  <div class="form-body">
               

<div  id="TablePassword" runat="server" >
    <div class="row">
          <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4"> <asp:Label ID="LabelCurrent" runat="server" Text="Current Password"></asp:Label>:</label>
                                            <div class="col-md-6">
                                                  <asp:TextBox ID="TextBoxCurrentPassword" runat="server" TextMode="Password" class="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2"> <asp:Image ID="ImageCurrent" runat="server" Visible="false" Width="20px" Height="20px"/></div>
                                        </div>
                                    </div>

    </div>
    <div class="row">
            <div class="col-md-6">
                  <div class="form-group">
               <label class="control-label col-md-4">    <asp:Label ID="LabelNew" runat="server" Text="New Password"></asp:Label>:</label>
                <div class="col-md-6">
                    <asp:TextBox ID="TextBoxNewPassword" runat="server" TextMode="Password" class="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">    <asp:Image ID="ImageNew" runat="server" Visible="false" Width="20px" Height="20px"/></div>
                                        </div>
                                    </div>
        
    </div>
    <div class="row">
         <div class="col-md-6">
                  <div class="form-group">
               <label class="control-label col-md-4">   <asp:Label ID="LabelConfirm" runat="server" Text="Confirm Password"></asp:Label>:</label>
                <div class="col-md-6">
                 <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password" class="form-control" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">   <asp:Image ID="ImageConfirm" runat="server" Visible="false" Width="20px" Height="20px"/></div>
                                        </div>
                                    </div>
    
    </div>
</div>
</br>


                                       
                            <div class="form-actions" id="TableSave" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                            <strong><asp:Label ID="LabelMessage" runat="server"></asp:Label></strong>
                                         <div class="text-right">      
                                         <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="btn green"/>  
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
