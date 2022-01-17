<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="AddBroker.aspx.vb" Inherits="AddBroker" %>

<script runat="server">
    Protected Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" lang="javascript">
        function Validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            var cnfr = $("#msgerror").text();
            IsError += ValidateRequiredField(document.getElementById('<%=txtName.ClientID%>'), "Please enter name!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtMobile.ClientID%>'), "Please enter mobile!");
<%--            IsError += ValidateRequiredField(document.getElementById('<%=txtpassword.ClientID%>'), "Please enter password!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtconfirmpassword.ClientID%>'), "Please confirm password!");--%>
            if (cnfr != "") {
                return false;
            }
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
    </script>
    <%--    <script>
        $(function () {

            $('#ContentPlaceHolder1_txtconfirmpassword').change(function () {
                if ($('#ContentPlaceHolder1_txtpassword').val() != $('#ContentPlaceHolder1_txtconfirmpassword').val())
                    $('#msgerror').text('The passwords entered do not match');
                else
                    $('#msgerror').text('');
            })
        })
    </script>--%>
    <style type="text/css">
        .checker input, .radio input {
            outline: none !important;
            text-align: center !important;
            float: left !important;
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
                    Height="40" ImageUrl="images/ajaxloading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <h3 class="page-title"></h3>
            <asp:Label ID="LabelContactID" runat="server" Visible="false"></asp:Label>
            <%-- <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AddBroker.aspx">Add Broker</a>
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
                                        Add/Edit Broker
                                    </div>
                                    <div align="right" class="right">
                                        <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                            <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <%--  <form action="#" class="form-horizontal">--%>
                                    <div class="form-body">
                                        <h3 class="form-section"></h3>
                                        <!--/row-->
                                        <!--/row-->

                                        <!--/row-->
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Type</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="drpType" runat="server" CssClass="form-control" Enabled="false">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Name </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtName" runat="server" AutoPostBack="true" OnTextChanged="txtUserName_TextChanged" Placeholder="Name" class="form-control"></asp:TextBox>
                                                        <asp:Label ID="lblUsernameMessage" runat="server" ForeColor="Green" Style="float: right;"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Registration No</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtRegistrationNo" runat="server" Placeholder="Registration No" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Address</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtAddress" runat="server" Placeholder="Address" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Telephone</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtTelephone" runat="server" Placeholder="Telephone" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Mobile </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtMobile" runat="server" Placeholder="Mobile" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Fax</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtFax" runat="server" Placeholder="Fax" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Email </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" MaxLength="50" class="form-control" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                                                        <asp:Label ID="lblEmailMessage" runat="server" ForeColor="Green" Style="float: right;"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Notes </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtNotes" runat="server" Placeholder="Notes" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Login </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtlogin" runat="server" Placeholder="Login" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>--%>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Spoken Language</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="drpspoken" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-3" style="width: 150px; text-align: left;">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Partners </label>
                                                    </div>
                                                </div>
                                                <div class="col-md-9">
                                                    <div class="form-group">
                                                        <asp:CheckBoxList ID="chklstPartner" RepeatColumns="3" runat="server" RepeatDirection="Horizontal" Width="1042" Height="161"></asp:CheckBoxList>
                                                        
                                                    </div>
                                                </div>
                                            </div>

                                            <!--/span-->
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Main Contact (Partner) </label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="drpMainContact" runat="server"  CssClass="form-control"></asp:DropDownList>                                                      
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Commission </label>
                                                    <div class="col-md-9">
                                                           <asp:TextBox ID="txtCommission" runat="server" CssClass="form-control" MaxLength="10">
                                                        </asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/row-->
                                        <div class="row">
                                            <!--/span-->
                                            <div class="col-md-6" id="TableRowImage" runat="server">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Image</label>
                                                    <div class="col-md-9">
                                                        <asp:Image ID="ImageContact" runat="server" Style="width: 100px; height: auto;" />
                                                        <asp:Label ID="lblimg" runat="server" Style="display: none"></asp:Label>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6" id="TableRowImageUpload" runat="server">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3"></label>
                                                    <div class="col-md-5 ">
                                                        <asp:FileUpload ID="FileUploadImage" runat="server" />
                                                    </div>
                                                    <div class="col-md-4 ">
                                                        <asp:Button ID="btnuploadimage" runat="server" Text="Upload Image" CssClass="btn green" OnClick="btnuploadimage_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12">&nbsp</div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3"></label>
                                                    <div class="col-md-9 ">
                                                        <asp:CheckBox ID="chkArchived" runat="server" Visible="false" Text="Archived" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/row-->
                                        <!--/row-->
                                        <div class="row" id="prop" runat="server" style="display: none">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Properties</label>
                                                    <div class="col-md-9">
                                                        <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">

                                                            <div class="table-scrollable">
                                                                <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                                                    <thead>
                                                                        <tr role="row" style="border: 1px solid #ddd">
                                                                            <asp:GridView ID="grdAdmin" DataKeyNames="id" AllowPaging="true" PageSize="5" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnRowCommand="grdAdmin_RowCommand" OnPageIndexChanging="grdAdmin_PageIndexChanging" OnRowDataBound="grdAdmin_RowDataBound" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Reference" HeaderStyle-Width="219px">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblisissue" runat="server" Text='<%#Eval("IsIssue") %>' Style="display: none"></asp:Label>
                                                                                            <%#Eval("Reference")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Partner" HeaderStyle-Width="219px">
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Partner")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="219px">
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Status")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="View" HeaderStyle-Width="219px">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgView" runat="server" CommandArgument='<%#Eval("id") %>' ToolTip="Click to edit or view this property " CommandName="editadmin" ImageUrl="~/Admin/images/view-img.png" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                            <asp:Button ID="btnimageprop" runat="server" Text="Add Property" class="btn green" OnClick="btnimageprop_Click"></asp:Button>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="form-actions">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="row">
                                                        <div class="col-md-offset-3 col-md-9">

                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn green" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none" OnClientClick="return Validations();"></asp:Button>
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn default"></asp:Button>
                                                            <asp:Label ID="LabelStatus" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                </div>
                                            </div>
                                        </div>




                                        <asp:HiddenField ID="hdnvenid" runat="server" />
                                        <%-- propery --%>
                                    </div>

                                    <%--</form>--%>
                                    <!-- END FORM-->
                                </div>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnuploadimage" />


        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
