<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="true" CodeFile="ManagePaycredential.aspx.cs" Inherits="Admin_ManagePaycredential" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function validation() {

            var IsError = '';
            var invalid = " "; //
            IsError += ValidateRequiredField(document.getElementById('<%=txtusername.ClientID%>'), "Please enter first name!");

                IsError += ValidateRequiredField(document.getElementById('<%=txtPassword.ClientID%>'), "Please enter password!");

                IsError += ValidateconfirmPassword(document.getElementById('<%=txtPassword.ClientID%>'), document.getElementById('<%=txtconfirmpassword.ClientID%>'));

                if (IsError.length > 0) {
                    alert(IsError);
                    return false
                }

                return true;
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upAddAdmin" runat="server">
        <ContentTemplate>
            <h3 class="page-title">Update Payment Credential
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="ManagePaycredential.aspx">Update Payment Credential</a>
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
                                <div class="portlet-title">
                                    <div class="caption">
                                       Edit Payment Credential
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <%--  <form action="#" class="form-horizontal">--%>
                                    <div class="form-body">
                                        <h3 class="form-section"></h3>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label col-md-2">User Name</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox ID="txtusername" runat="server" Placeholder="Name" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label col-md-2">Password</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox ID="txtPassword" runat="server" placeholder="password" class="form-control" TextMode="Password" OnPreRender="txtPassword_PreRender"></asp:TextBox>
                                                        <asp:HiddenField ID="hdnPassword" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label col-md-2">Confirm Password</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox ID="txtconfirmpassword" runat="server" placeholder="password" class="form-control" TextMode="Password" OnPreRender="txtconfirmpassword_PreRender"></asp:TextBox>
                                                   
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                    </div>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-offset-2 col-md-10">

                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none" OnClientClick="return validation();"></asp:Button>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
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

