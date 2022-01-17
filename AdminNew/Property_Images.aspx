<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Property_Images.aspx.vb" Inherits="AdminNew_Property_Images" %>

<%@ Register Src="~/ControlsNew/WebUserControlAdminPropertyImagenw.ascx" TagName="AdminPropertyImage" TagPrefix="ucAdminPropertyImage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <asp:UpdatePanel ID="updAddProperty_Images" runat="server" UpdateMode="Conditional">
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
                                        Add/Edit Property Images
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
                                                    <ul class="nav nav-tabs">
                                                        <li runat="server" id="liPropertyGeneral">
                                                            <asp:LinkButton ID="btnPropertyGeneral" runat="server" OnClick="btnPropertyGeneral_Click" Text="General"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyDescription">
                                                            <asp:LinkButton ID="btnPropertyDescription" runat="server" OnClick="btnPropertyDescription_Click" Text="Descriptions"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyImages" class="active">
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
                                                        <div class="tab-pane fade in active" id="tab3default" runat="server">
                                                            <div class="form-body">
                                                                <div class="row" id="TableUploadImages" runat="server">
                                                                    <div class="col-md-8">
                                                                        <div class="form-group" id="TableRowImageOptions" runat="server">
                                                                            <div class=" col-md-4">
                                                                                <asp:FileUpload ID="FileUploadImage" AllowMultiple="true" accept="image/*" runat="server" />
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <asp:DropDownList ID="DropDownListUploadImageOption" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <asp:Button ID="ButtonUploadImage" runat="server" Text="Upload" class="btn green" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:Button ID="ButtonBulkUploadImage" runat="server" Text="Bulk" CssClass="btn green" Style="display: none" />

                                                                        <asp:Label ID="lblimgsize" Style="display: none" runat="server" Text="Please upload image of upto 150kb size only" ForeColor="Red"></asp:Label>

                                                                        <div id="TableRowBulkImageUpload" runat="server" visible="false">
                                                                            <asp:AjaxFileUpload ID="AjaxBulkFileUploadImage" runat="server"
                                                                                AllowedFileTypes="jpg,jpeg,png,gif,bmp"
                                                                                OnClientUploadCompleteAll="uploadComplete" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id="TableImages" runat="server">
                                                                    <div class="row">
                                                                        <div class="col-md-6  col-md-offset-3">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage1" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage2" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage3" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage4" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage5" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage6" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage7" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage8" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage9" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage10" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage11" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage12" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage13" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage14" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage15" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                        <div class="col-md-4 col-sm-4 impropwdth">
                                                                            <ucAdminPropertyImage:AdminPropertyImage ID="AdminPropertyImage16" runat="server" Visible="false" OnImageDelete="ImageDelete" OnImageLeft="ImageLeft" OnImageRight="ImageRight" OnImageUp="ImageUp" OnImageDown="ImageDown" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-actions" id="Div2" runat="server" style="display: block">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <b>
                                                                            <asp:Label ID="lblimage" runat="server"></asp:Label></b>
                                                                        <div class="text-right">
                                                                            <asp:Button ID="btnimageprop" runat="server" Text="Save" class="btn green" OnClick="btnimageprop_Click"></asp:Button>
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div style="display: none">
                <asp:AjaxFileUpload ID="ghostAjaxFileUpload" runat="server" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonUploadImage" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

