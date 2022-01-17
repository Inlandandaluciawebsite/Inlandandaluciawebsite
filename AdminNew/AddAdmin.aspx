<%@ Page Title="Jabberad-Add Admin" Language="C#" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="true" CodeFile="AddAdmin.aspx.cs" Inherits="Admin_AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" lang="javascript">
        function Validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredField(document.getElementById('<%=txtName.ClientID%>'), "Please enter name!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtAddress.ClientID%>'), "Please enter address!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtCity.ClientID%>'), "Please enter city!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtZipCode.ClientID%>'), "Please enter areazip!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtState.ClientID%>'), "Please enter state!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtPhone.ClientID%>'), "Please enter phone!");
            IsError += validateEmail(document.getElementById('<%=txtEmail.ClientID%>'), "Please enter valid email!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtUserName.ClientID%>'), "Please enter username!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtPassword.ClientID%>'), "Please enter password!");
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upAddAdmin" runat="server">
        <ContentTemplate>
            <h3 class="page-title">Add Admin 
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AddAdmin.aspx">Add Admin</a>
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
                                        Add/Edit Admin
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <%--  <form action="#" class="form-horizontal">--%>
                                    <div class="form-body">
                                        <h3 class="form-section"></h3>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Name</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtName" runat="server" Placeholder="Name" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Address </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtAddress" runat="server" Placeholder="Address" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">City</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtCity" runat="server" Placeholder="City" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Zip Code</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtZipCode" runat="server" Placeholder="Zip Code" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">State</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtState" runat="server" Placeholder="State" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Phone No.</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPhone" runat="server" Placeholder="Phone No." class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Email</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtEmail" runat="server" Placeholder="abc@gmail.com" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" class="form-control"></asp:TextBox>
                                                        <asp:Label ID="lblEmailMessage" runat="server" ForeColor="Green" Style="float: right;"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">User Name</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtUserName" runat="server" class="form-control" AutoPostBack="true" Placeholder="abc" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
                                                        <asp:Label ID="lblUsernameMessage" runat="server" ForeColor="Green" Style="float: right;"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Password</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPassword" runat="server" placeholder="password" class="form-control" TextMode="Password" OnPreRender="txtPassword_PreRender"></asp:TextBox>
                                                          <asp:HiddenField ID="hdnPassword" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                    </div>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn green" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none" OnClientClick="return Validations();"></asp:Button>
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn default"></asp:Button>
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

