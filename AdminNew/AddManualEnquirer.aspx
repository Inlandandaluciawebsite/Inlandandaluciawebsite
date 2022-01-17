<%@ Page Title="Add Manual Enquirer" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="AddManualEnquirer.aspx.vb" Inherits="Admin_AddManualEnquirer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript" lang="javascript">
    function Encode()
    {
            var value = (document.getElementById('ContentPlaceHolder1_txtComments').value);
            value = value.replace('<', "< ");
            value = value.replace('>', " >");
            document.getElementById('ContentPlaceHolder1_txtComments').value = value;
        }
</script>
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
                                        Add New Manual Enquiry 
                                    </div>
                                    <div align="right">
                                        <a class="btn green mrgtp" href="#" role="button">
                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                            <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                    </div>
                                    <asp:HiddenField ID="hdcont" runat="server" />
                                    <asp:HiddenField ID="hdnprevurl" runat="server" />
                                    <asp:HiddenField ID="hdpageind" runat="server" />
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
                                                    <label class="control-label col-md-3">Name</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtForeName" runat="server" Placeholder="Name" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Surname </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtSurname" runat="server" Placeholder="Surname" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
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
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Email</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label" style="display: flex;">
                                                        <asp:CheckBox ID="chkNoPropertyReference" Text="No Property Reference" runat="server" AutoPostBack="true" OnCheckedChanged="chkNoPropertyReference_CheckedChanged" />
                                                    </label>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3" runat="server" id="lblPropertyRef" visible="true">Property Ref</label>
                                                    <label class="control-label col-md-3" runat="server" id="lblOffice" visible="false">Office</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPropertyRef" runat="server" Placeholder="Property Ref" class="form-control"></asp:TextBox>
                                                        <asp:DropDownList ID="drpOffices" runat="server" Visible="false" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Source</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="drpSource" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Comments </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtComments" runat="server" Placeholder="Comments" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Language</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="DropDownListLanguage" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3"></label>
                                                    <div class="col-md-9">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3"></label>
                                                    <div class="col-md-9">
                                                        <asp:CheckBox ID="chkAllocateThisClientToMe" runat="server" Text="Allocate this client to me" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-actions">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="row">
                                                        <div class="col-md-offset-3 col-md-9">
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Send Enquiry" class="btn green" OnClick="btnSubmit_Click" OnClientClick="Encode();"></asp:Button>
                                                            &nbsp;&nbsp;
                                                            <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
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
                <!-- END CONTENT -->
                <!-- BEGIN QUICK SIDEBAR -->
                <!-- END QUICK SIDEBAR -->
                <!-- END CONTAINER -->
                <!-- BEGIN FOOTER -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
