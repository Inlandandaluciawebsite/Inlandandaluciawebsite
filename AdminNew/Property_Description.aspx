<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Property_Description.aspx.vb" Inherits="AdminNew_Property_Description" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .checker {
            display: inline-block;
        }
    </style>
    <script type="text/javascript" lang="ja">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updAddProperty_Descriptions" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                <ProgressTemplate>
                    <div class="overlay" id="divProgress">
                        &nbsp;
                    <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="50"
                        Height="40" ImageUrl="images/ajaxloading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <!-- BEGIN PAGE CONTENT-->
            <div class="row">
                <div class="col-md-12">
                    <div class="tabbable tabbable-custom boxless tabbable-reversed">

                        <div class="tab-pane" id="tab_2">
                            <div class="portlet box green">
                                <div class="portlet-title">
                                    <div class="caption">
                                        Add/Edit Property Description
                                    </div>
                                    <div align="right" class="right">
                                        <a class="btn green mrgtp" href="#" role="button">
                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                            <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                        <asp:HiddenField ID="hdcont" runat="server" />
                                        <asp:HiddenField ID="hdnprevurl" runat="server" />
                                        <asp:HiddenField ID="hdpageind" runat="server" />
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <div class="form-body" id="TableMessage" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <strong>
                                                    <asp:Label ID="LabelMessageTitle" runat="server"></asp:Label></strong>
                                                <asp:Label ID="LabelMessageBody" runat="server"></asp:Label>
                                                <asp:Button ID="ButtonOK" runat="server" Text="OK" CssClass="btn green" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="propform" runat="server">
                                        <div class="col-md-12">
                                            <div class="panel with-nav-tabs panel-default">
                                                <div class="panel-heading">
                                                    <h3 class="form-section">
                                                        <asp:Label ID="lblpropref" runat="server"></asp:Label>
                                                        <asp:Label ID="lblpartnerref" runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hdpropid" runat="server" />
                                                    </h3>
                                                    <div class="text-right">
                                                        <asp:Label ID="lblMessageTop" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                                                        <input type="button" title="SAVE" value="SAVE" class="btn green" onclick="document.getElementById('<%=btndescription.ClientID%>').click()" />
                                                    </div>
                                                    <ul class="nav nav-tabs">
                                                        <li runat="server" id="liPropertyGeneral">
                                                            <asp:LinkButton ID="btnPropertyGeneral" runat="server" OnClick="btnPropertyGeneral_Click" Text="General"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyDescription" class="active">
                                                            <asp:LinkButton ID="btnPropertyDescription" runat="server" OnClick="btnPropertyDescription_Click" Text="Descriptions"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyImages">
                                                            <asp:LinkButton ID="btnPropertyImages" runat="server" OnClick="btnPropertyImages_Click" Text="Images"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyFeatures">
                                                            <asp:LinkButton ID="btnPropertyFeatures" runat="server" OnClick="btnPropertyFeatures_Click" Text="Features"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyHistory">
                                                            <asp:LinkButton ID="btnPropertyHistory" runat="server" OnClick="btnPropertyHistory_Click" Text="History"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyDocuments">
                                                            <asp:LinkButton ID="btnPropertyDocuments" runat="server" OnClick="btnPropertyDocuments_Click" Text="Documents"></asp:LinkButton>
                                                        </li>

                                                    </ul>


                                                </div>
                                                <div class="panel-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane fade in active" id="tab2default" runat="server">
                                                            <div class="form-body">
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Language</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="DropDownListLanguage" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListLanguage_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3 sdwdth">Short </label>
                                                                            <div class="col-md-8">
                                                                                <asp:TextBox ID="TextBoxShortDescription" runat="server" CssClass="form-control">
                                                                                </asp:TextBox>
                                                                                <asp:Label ID="LabelMessageShort" runat="server" ForeColor="Gray" Font-Bold="True" Visible="False"></asp:Label>
                                                                            </div>
                                                                            <asp:Button ID="ButtonSaveShortDescription" runat="server" Text="Save" class="btn green" Style="display: none" />
                                                                            <%--<asp:Button ID="ButtonAutoTranslateShort" runat="server" Text="Auto Translate" class="btn green" OnClick="ButtonAutoTranslateShort_Click" />--%>
                                                                            <asp:CheckBox ID="chkAutoTranslateShort" runat="server" Checked="true" Text="Auto Translate" />

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3 sdwdth">Main </label>
                                                                            <div class="col-md-8">
                                                                                <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="20">

                                                                                </asp:TextBox>
                                                                                <asp:Label ID="LabelMessage" runat="server" ForeColor="Gray" Font-Bold="True" Visible="False"></asp:Label>
                                                                            </div>
                                                                            <asp:CheckBox ID="chkAutoTranslateMain" runat="server" Checked="true" Text="Auto Translate" />

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <div class="clsmaindesc">
                                                                            <asp:Button ID="ButtonSaveDescription" runat="server" Text="Save" class="btn green" Style="display: none" />&nbsp;
                <%--<asp:Button ID="ButtonAutoTranslate" runat="server" Text="Auto Translate" class="btn green" OnClick="ButtonAutoTranslate_Click" />--%>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="form-actions" id="Div1" runat="server" style="display: block">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <b>
                                                                            <asp:Label ID="lbldescmessage" runat="server"></asp:Label></b>
                                                                        <div class="text-right">
                                                                            <asp:Button ID="btndescription" runat="server" Text="Save" class="btn green" OnClick="btndescription_Click"></asp:Button>

                                                                        </div>

                                                                    </div>
                                                                    <div class="col-md-6">
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--</form>--%>
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <div style="display: none">
                <asp:AjaxFileUpload ID="ghostAjaxFileUpload" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

