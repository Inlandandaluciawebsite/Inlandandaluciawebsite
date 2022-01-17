<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Property_Documents.aspx.vb" Inherits="AdminNew_Property_Documents" %>

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
                                        Add/Edit Property Documents
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
                                                        <li runat="server" id="liPropertyImages">
                                                            <asp:LinkButton ID="btnPropertyImages" runat="server" OnClick="btnPropertyImages_Click" Text="Images"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyFeatures">
                                                            <asp:LinkButton ID="btnPropertyFeatures" runat="server" OnClick="btnPropertyFeatures_Click" Text="Features"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyHistory">
                                                            <asp:LinkButton ID="btnPropertyHistory" runat="server" OnClick="btnPropertyHistory_Click" Text="History"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyDocuments" class="active">
                                                            <asp:LinkButton ID="btnPropertyDocuments" runat="server" OnClick="btnPropertyDocuments_Click" Text="Documents"></asp:LinkButton>
                                                        </li>

                                                    </ul>
                                                </div>
                                                <div class="panel-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane fade in active" id="tabPropertyDocuments" runat="server">
                                                            <div class="form-body" id="TableDocuments" runat="server" font-names="Calibri">
                                                                <div class="row" id="TableRowFolderOptions" runat="server">
                                                                    <div class="col-md-12">
                                                                        <div class="d">
                                                                            <div class="f">
                                                                                <asp:Button ID="ButtonNewFolder" runat="server" Text="New Folder" Enabled="false" CssClass="btn green" />
                                                                            </div>
                                                                            <div class="f">
                                                                                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" Enabled="false" CssClass="btn green" />
                                                                            </div>
                                                                            <div class="f">
                                                                                <asp:Button ID="ButtonRename" runat="server" Text="Rename" Enabled="false" CssClass="btn green" />
                                                                            </div>
                                                                            <div class="f">
                                                                                <asp:Button ID="btnMove" runat="server" Text="Move" Enabled="false" CssClass="btn green" />
                                                                            </div>
                                                                            <div class="f sd">
                                                                                <asp:FileUpload ID="FileUploadFile" runat="server" AllowMultiple="true" Enabled="false" />
                                                                            </div>
                                                                            <div class="f">
                                                                                <asp:Button ID="ButtonUpload" runat="server" Text="Upload" Enabled="false" CssClass="btn green" />
                                                                            </div>
                                                                            <div class="f">
                                                                                <asp:Button ID="ButtonDownload" runat="server" Text="Download" Enabled="false" CssClass="btn green" />
                                                                            </div>
                                                                            <div class="f">
                                                                                <asp:Button ID="ButtonEmail" runat="server" Text="Email" Enabled="false" CssClass="btn green" />
                                                                            </div>
                                                                            <div class="f  chkissue">
                                                                                <asp:CheckBox ID="chkIsIssues" runat="server" Text="Issues" AutoPostBack="true" OnCheckedChanged="chkIsIssues_CheckedChanged" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div>&nbsp</div>
                                                                </div>
                                                                <div class="row" id="TableRowUpdate" runat="server" visible="false">
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="LabelUpdate" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server" AutoCompleteType="None"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="LabelFileExtension" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="btn green" />
                                                                    </div>
                                                                </div>
                                                                <div class="row" id="TableRowMove" runat="server" visible="false">
                                                                    <div class="col-md-6">
                                                                        <asp:HiddenField ID="hdsource" runat="server" Value="0" />
                                                                        <asp:Label ID="lblsourcefile" runat="server" Style="display: none"></asp:Label>
                                                                        <asp:Label ID="lblMove" runat="server" Text=""></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Button ID="ButtonMoveYes" runat="server" Text="Yes" CssClass="btn green" />
                                                                        <asp:Button ID="ButtonMoveNo" runat="server" Text="No" CssClass="btn green" />
                                                                    </div>

                                                                </div>

                                                                <div class="row" id="TableRowDelete" runat="server" visible="false">
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="LabelDelete" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Button ID="ButtonDeleteYes" runat="server" Text="Yes" CssClass="btn green" />
                                                                        <asp:Button ID="ButtonDeleteNo" runat="server" Text="No" CssClass="btn green" />
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div>&nbsp</div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <asp:TreeView ID="TreeViewBrowser" runat="server" Font-Names="Calibri" Font-Size="11" ForeColor="Black" SelectedNodeStyle-BackColor="Silver" BorderColor="Silver" BorderStyle="None">
                                                                        </asp:TreeView>
                                                                    </div>
                                                                </div>
                                                                <div class="row" id="TableRowEmailSent" runat="server" visible="false">
                                                                    <div class="col-md-12">
                                                                        The email has been sent successfully 
                                                                    </div>
                                                                </div>
                                                                <div class="row" id="TableRowFileLimitExceeded" runat="server" visible="false">
                                                                    <div class="col-md-12">
                                                                        The file selected exceeds the maximum file size limit of 3MB
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="TableEmailDocument" runat="server" visible="false">
                                                                <div class="form-body">
                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <label class="control-label col-md-3">To:</label>
                                                                                <div class="col-md-9">
                                                                                    <asp:TextBox ID="TextBoxEmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" id="TableRowProvideEmailAddress" runat="server">
                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <label class="control-label col-md-3"></label>
                                                                                <div class="col-md-9">
                                                                                    <strong>Please provide an email address</strong>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <!--/span-->

                                                                        <!--/span-->
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <label class="control-label col-md-3">Subject: </label>
                                                                                <div class="col-md-9">
                                                                                    <asp:TextBox ID="TextBoxEmailSubject" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <label class="control-label col-md-3"></label>
                                                                                <div class="col-md-9">
                                                                                    <asp:TextBox ID="TextBoxEmailMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10" Width="100%"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                            <div class="form-group">
                                                                                <label class="control-label col-md-3">Attachment</label><asp:Label ID="LabelAttachment" runat="server"></asp:Label>
                                                                                <div class="col-md-9">
                                                                                    <asp:Label ID="LabelAttachmentFullPath" runat="server" Visible="false"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <!--/row-->
                                                                    <div class="row" id="TableCellEmailFailed" runat="server" visible="false">
                                                                        <div class="col-md-12">
                                                                            <strong>Email sending failed. Please check the email address is valid.</strong>
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
                                                                                    <asp:Button ID="ButtonSend" runat="server" Text="Send" CssClass="btn green" />
                                                                                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn green" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="form-actions">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <b>
                                                                            <asp:Label ID="lbldocument" runat="server"></asp:Label></b>
                                                                        <div class="text-right">

                                                                            <asp:Button ID="btndocument" runat="server" Text="Save" class="btn green" OnClick="btndocument_Click"></asp:Button>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonUpload" />
            <asp:PostBackTrigger ControlID="ButtonDownload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

