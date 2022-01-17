<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="BuyerCriterias.aspx.vb" Inherits="BuyerCriterias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" lang="javascript">
        function Validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space

            <%--IsError += ValidateRequiredField(document.getElementById('<%=drpUser.ClientID%>'), "Please select !");--%>
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
    </script>
    <script>
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $(".mrgtp").click(function () {
                    var stateObj = $("#ContentPlaceHolder1_hdcont").val()
                    var pageindex = $("#ContentPlaceHolder1_hdpageind").val()
                    var prevurl = $("#ContentPlaceHolder1_hdnprevurl").val()
                    window.location.href = prevurl
                })
            });
        });
    </script>
    <style type="text/css">
        .tabbable-custom table td {
            vertical-align: middle;
        }

            .tabbable-custom table td .checker {
                display: inline-block;
                margin-right: 7px !important;
            }
            .page-content
            {
                height:1300px !important;
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
            <div class="col-md-8">
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
                                            Buyer Criterias
                                        </div>
                                        <div align="right" class="right">
                                            <a class="btn green mrgtp" href="#" role="button">
                                                <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                                <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:HiddenField ID="hdcont" runat="server" />
                                    <asp:HiddenField ID="hdnprevurl" runat="server" />
                                    <asp:HiddenField ID="hdpageind" runat="server" />
                                    <asp:CheckBoxList ID="chklstBuyerCriterias" Width="100%" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-actions" id="TableRowSave" runat="server">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="text-right" style="margin-right: 17px;">
                                    <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" OnClientClick="return Validations();" UseSubmitBehavior="true" CssClass="btn green" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
