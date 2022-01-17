<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="PropertyPostcode.aspx.vb" Inherits="PropertyPostcode" %>

<%@ Register Src="~/ControlsNew/WebUserControlAdminPostcodeReassignment.ascx" TagName="AdminPostcodeReassignment" TagPrefix="ucAdminPostcodeReassignment" %>

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
    <script>
        $(function () {

            $('#ContentPlaceHolder1_txtconfirmpassword').change(function () {
                if ($('#ContentPlaceHolder1_txtpassword').val() != $('#ContentPlaceHolder1_txtconfirmpassword').val())
                    $('#msgerror').text('The passwords entered do not match');
                else
                    $('#msgerror').text('');
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upAddAdmin" runat="server" UpdateMode="Conditional">
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
                                        <asp:Label ID="LabelPostcodes" runat="server" Text="Postcodes"></asp:Label>
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
                                        <%--      <h1>
        </h1>--%>

                                        <div id="TablePostcodes" runat="server" width="100%">

                                            <div class="row" id="TableRowEditName" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Edit <%= GetParentEntity()%>:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxEditName" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>



                                            </div>

                                            <div class="row" id="TableRowEditCountryHeader" runat="server" visible="false">

                                                <div class="col-md-12" columnspan="2">
                                                    <strong>Edit Country</strong>
                                                </div>

                                            </div>

                                            <div class="row" id="TableRowEditCountryEN" runat="server" visible="false">

                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">English:</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxEditCountryEN" runat="server"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>



                                            </div>

                                            <div class="row" id="TableRowEditCountryES" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Spanish:</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxEditCountryES" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="row" id="TableRowEditCountryFR" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">French:</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxEditCountryFR" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>



                                            </div>

                                            <div class="row" id="TableRowEditCountryDE" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">German:</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxEditCountryDE" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="row" id="TableRowEditCountryNL" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Dutch:</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxEditCountryNL" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="row" id="TableRowEditCountryCode" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Country Code:</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxEditCountryCode" runat="server" MaxLength="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row" id="TableRowEditPostcode" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Edit Postcode:</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxEditPostcode" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="row" id="TableRowEditDefaultPartner" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Default Partner:</label>
                                                        <div class="col-md-9">
                                                            <asp:DropDownList ID="DropDownListEditDefaultPartner" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="form-actions" id="TableRowEditOptions" runat="server" visible="false">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <div class="col-md-offset-3 col-md-9">
                                                                <asp:Button ID="ButtonSaveEdit" runat="server" Text="Save" CssClass="btn green" />
                                                                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="btn green" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="TableRowParent" runat="server">
                                                <div class="col-md-12">
                                                    <strong>
                                                        <asp:Label ID="LabelType" runat="server"></asp:Label>
                                                        <asp:LinkButton ID="LinkButtonParentCountry" runat="server" Visible="false"></asp:LinkButton>
                                                        <asp:Label ID="LabelSeparator1" runat="server" Text=" / " Visible="false"></asp:Label>
                                                        <asp:LinkButton ID="LinkButtonParentRegion" runat="server" Visible="false"></asp:LinkButton>
                                                        <asp:Label ID="LabelSeparator2" runat="server" Text=" / " Visible="false"></asp:Label>
                                                        <asp:LinkButton ID="LinkButtonParentArea" runat="server" Visible="false"></asp:LinkButton>
                                                        <asp:Label ID="LabelSeparator3" runat="server" Text=" / " Visible="false"></asp:Label>
                                                        <asp:LinkButton ID="LinkButtonParentSubArea" runat="server" Visible="false"></asp:LinkButton>
                                                    </strong>
                                                </div>
                                            </div>
                                            <div class="row" id="TableRowResults" runat="server">
                                                <div class="col-lg-12">
                                                    <div class="table-scrollable">
                                                        <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                                            <thead>
                                                                <tr role="row" style="border: 1px solid #ddd">

                                                                    <asp:GridView
                                                                        ID="GridViewResults"
                                                                        runat="server"
                                                                        Width="100%"
                                                                        GridLines="None"
                                                                        CssClass="mGrid"
                                                                        PagerStyle-CssClass="pgr"
                                                                        AlternatingRowStyle-CssClass="alt"
                                                                        AutoGenerateSelectButton="true"
                                                                        AllowSorting="True">
                                                                    </asp:GridView>
                                                                </tr>
                                                            </thead>
                                                        </table>
                                                    </div>

                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">&nbsp;</div>
                                            </div>
                                            <div class="row" id="TableRowAddName" runat="server" visible="false">

                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Add <%= GetThisEntity()%>:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:HiddenField ID="hdnSubAreaId" runat="server" />
                                                            <asp:HiddenField ID="hdnPostCodeId" runat="server" />
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddName" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>



                                            </div>

                                            <div class="row" id="TableRowAddCountryHeader" runat="server" visible="false">

                                                <div class="col-md-6">
                                                    <strong>Add Country</strong>
                                                </div>

                                            </div>

                                            <div class="row" id="TableRowAddCountryEN" runat="server" visible="false">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">English:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddCountryEN" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>



                                            </div>

                                            <div class="row" id="TableRowAddCountryES" runat="server" visible="false">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Spanish:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddCountryES" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                            <div class="row" id="TableRowAddCountryFR" runat="server" visible="false">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">French:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddCountryFR" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row" id="TableRowAddCountryDE" runat="server" visible="false">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">German:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddCountryDE" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                            <div class="row" id="TableRowAddCountryNL" runat="server" visible="false">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Dutch:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddCountryNL" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                            <div class="row" id="TableRowAddCountryCode" runat="server" visible="false">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Country Code:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddCountryCode" runat="server" MaxLength="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row" id="TableRowAddPostcode" runat="server" visible="false">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Add Postcode:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddPostcode" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row" id="TableRowAddDefaultPartner" runat="server" visible="false">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Default Partner:</label>
                                                        <div class="col-md-9 ">
                                                            <asp:DropDownList ID="DropDownListAddDefaultPartner" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>


                                            <div class="form-actions" id="TableRowAddOptions" runat="server" visible="false">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <div class="col-md-offset-3 col-md-9">
                                                                <asp:Button ID="ButtonSaveAdd" runat="server" Text="Save" CssClass="btn green" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                    </div>
                                                </div>
                                            </div>


                                        </div>

                                        <div class="row" id="TableConfirmDeletion" runat="server" visible="false">

                                            <div>

                                                <div class="col-lg-12">
                                                    <asp:Label ID="LabelDeletionPrompt" runat="server"></asp:Label>
                                                </div>

                                            </div>

                                            <div class="row" id="TableRowDeletionResults" runat="server" visible="false">

                                                <div class="col-lg-12">
                                                    <asp:GridView
                                                        ID="GridViewDeletionResults"
                                                        runat="server"
                                                        Width="100%"
                                                        GridLines="None"
                                                        CssClass="mGrid"
                                                        PagerStyle-CssClass="pgr"
                                                        AlternatingRowStyle-CssClass="alt"
                                                        AllowSorting="True">
                                                    </asp:GridView>

                                                </div>

                                            </div>

                                            <div class="row">

                                                <div class="col-lg-12">
                                                    <div class="form-group">
                                                        <div class="col-md-6">
                                                            Are you sure you want to continue?
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:Button ID="ButtonConfirmDeletion" runat="server" Text="Yes" CssClass="btn green" />
                                                            <asp:Button ID="ButtonCancelDeletion" runat="server" Text="No" CssClass="btn green" />
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
