﻿<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Index.aspx.vb" Inherits="Admin_Index" %>

<%@ Register Src="~/ControlsNew/WebUserControlAdminLawyerAreaNew.ascx" TagPrefix="uc1" TagName="WebUserControlAdminLawyerArea" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="upIndex" runat="server">
        <ContentTemplate>
            <h3 class="page-title"  style="display:block" runat="server" id="dshcont1"> 
            </h3>
            <div class="page-bar" style="display:block" runat="server" id="dshcont">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="Index.aspx">Dashboard</a>
                    </li>
                </ul>
            </div>
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
                            </div>
                        </div>
                    </div>
                    <%--</form>--%>
                    <!-- END FORM-->
                </div>
            </div>
            <div class="form-body">
                <h3 class="form-section"></h3>

                <uc1:WebUserControlAdminLawyerArea runat="server" ID="WebUserControlAdminLawyerArea" />
                <!--/row-->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

