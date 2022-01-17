<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Buyer_Criterias.aspx.vb" Inherits="Buyer_Criterias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="AdminNew/css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="AdminNew/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="AdminNew/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="AdminNew/css/custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tabbable-custom table td {
            vertical-align: middle;
        }

            .tabbable-custom table td .checker {
                display: inline-block;
                margin-right: 7px !important;
            }

        .logo {
            width: 287px !important;
            height: 138px !important;
        }

            .logo img {
                width: 287px !important;
            }
    </style>
    <script type="text/javascript">
        var submit = 0;
        function CheckDouble() {
            if (++submit > 1) {
                alert('Saving your criterias , will take few seconds - Thanks');
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upAddAdmin" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="upAddAdmin"
                DisplayAfter="1">
            </asp:UpdateProgress>
            <h3 class="page-title"></h3>

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
                                        <asp:Label ID="lblBuyerName" runat="server">Buyer</asp:Label>
                                        Criterias
                                    </div>
                                    <div align="right" class="right">
                                        <%--                                        <a class="btn green mrgtp" href="#" role="button">
                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                            <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>--%>
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
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" OnClientClick="return CheckDouble();" CssClass="btn green" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

