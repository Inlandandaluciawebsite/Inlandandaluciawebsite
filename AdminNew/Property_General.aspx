<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Property_General.aspx.vb" Inherits="Admin_Property_General" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlsNew/WebUserControlAdminLocationnw.ascx" TagName="AdminLocation" TagPrefix="ucAdminLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        div#ContentPlaceHolder1_tab5default textarea {
            min-height: 150px;
        }

        .inline-coder .form-group {
            display: inline-flex;
            align-items: center;
            width: auto;
            margin-right: 15px;
        }

            .inline-coder .form-group label.control-label {
                width: 100%;
            }

                .inline-coder .form-group label.control-label .checker {
                    display: inline-block;
                }

                    .inline-coder .form-group label.control-label .checker input {
                        display: inline-block;
                        transform: translateY(4px);
                    }

        .property-details-single p span {
            font-family: 'Open Sans', sans-serif;
            font-size: 14px;
            color: #3e66d9;
            float: left;
            font-weight: bold;
            padding: 0 10px 0 0;
        }
    </style>
    <script type="text/javascript" lang="javascript">
        function Validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateDropdown(document.getElementById('<%=DropDownListType.ClientID%>'), "Please select property type!");
            IsError += ValidateDropdown(document.getElementById('<%=DropDownListVendor.ClientID%>'), "Please select vendor!");
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
        $(function () {
            $("#imgStartDate").click(function () {
                $("#ContentPlaceHolder1_txtStartDate").focus();
            })
            $("#imgExpiryDate").click(function () {
                $("#ContentPlaceHolder1_txtExpiryDate").focus();
            })
            $("#ContentPlaceHolder1_txtStartDate").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
                timeFormat: "HH:mm",
                minDate: 0,
                onSelect: function (date) {
                    var date2 = $('#ContentPlaceHolder1_txtStartDate').datepicker('getDate');
                    date2.setDate(date2.getDate() + 152);
                    $('#ContentPlaceHolder1_txtExpiryDate').datepicker('setDate', date2);
                    //sets minDate to dt1 date + 1
                    //$('#ContentPlaceHolder1_txtExpiryDate').datepicker('option', 'minDate', date2);
                }
            });

            $("#ContentPlaceHolder1_txtExpiryDate").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
                timeFormat: "HH:mm",
                minDate: 0,
                onClose: function () {
                    var dt1 = $('#ContentPlaceHolder1_txtStartDate').datepicker('getDate');
                    var dt2 = $('#ContentPlaceHolder1_txtExpiryDate').datepicker('getDate');
                    //check to prevent a user from entering a date below date of dt1
                    if (dt2 <= dt1) {
                        var minDate = $('#ContentPlaceHolder1_txtExpiryDate').datepicker('option', 'minDate');
                        $('#ContentPlaceHolder1_txtExpiryDate').datepicker('setDate', minDate);
                    }
                }
            });
        })
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $("#imgStartDate").click(function () {
                    $("#ContentPlaceHolder1_txtStartDate").focus();
                })
                $("#imgExpiryDate").click(function () {
                    $("#ContentPlaceHolder1_txtExpiryDate").focus();
                })
                $("#ContentPlaceHolder1_txtStartDate").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                    minDate: 0,
                    onSelect: function (date) {
                        var date2 = $('#ContentPlaceHolder1_txtStartDate').datepicker('getDate');
                        date2.setDate(date2.getDate() + 152);
                        $('#ContentPlaceHolder1_txtExpiryDate').datepicker('setDate', date2);
                        //sets minDate to dt1 date + 1
                        //$('#ContentPlaceHolder1_txtExpiryDate').datepicker('option', 'minDate', date2);
                    }
                });
                $("#ContentPlaceHolder1_txtExpiryDate").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                    minDate: 0,
                    onClose: function () {
                        var dt1 = $('#ContentPlaceHolder1_txtStartDate').datepicker('getDate');
                        var dt2 = $('#ContentPlaceHolder1_txtExpiryDate').datepicker('getDate');
                        //check to prevent a user from entering a date below date of dt1
                        if (dt2 <= dt1) {
                            var minDate = $('#ContentPlaceHolder1_txtExpiryDate').datepicker('option', 'minDate');
                            $('#ContentPlaceHolder1_txtExpiryDate').datepicker('setDate', minDate);
                        }
                    }
                });
                $("#ContentPlaceHolder1_txtSubjectExpiryDate").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                    minDate: 1,
                    onClose: function () {
                    }
                });
                $("#ContentPlaceHolder1_txtPaymentExpiryDate").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                    minDate: 1,
                    onClose: function () {
                    }
                });
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
    <asp:UpdatePanel ID="updvendor" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="updvendor"
                DisplayAfter="1">
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
                                        Add/Edit Property
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
                                    <div class="row" id="propform" runat="server">
                                        <div class="col-md-12">
                                            <div class="panel with-nav-tabs panel-default">
                                                <div class="panel-heading">
                                                    <h3 class="form-section">
                                                        <asp:Label ID="lblpropref" runat="server"></asp:Label>
                                                        <asp:Label ID="lblpartnerref" runat="server"></asp:Label>
                                                        <asp:LinkButton ID="btnedirref" runat="server" Text="Edit Reference" Visible="false" OnClick="btnedirref_Click">Edit Reference &nbsp; <i class="fa fa-hand-o-right" aria-hidden="true"></i></asp:LinkButton>
                                                        <asp:HiddenField ID="hdpropid" runat="server" />
                                                    </h3>
                                                    <div class="text-right">
                                                        <asp:Label ID="lblMessageTop" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                                                        <input type="button" title="SAVE" value="SAVE" class="btn green" onclick="document.getElementById('<%=btnSavePropertyGeneral.ClientID%>').click()" />
                                                    </div>
                                                    <ul class="nav nav-tabs">
                                                        <li runat="server" id="liPropertyGeneral" class="active">
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
                                                        <li runat="server" id="liPropertyDocuments">
                                                            <asp:LinkButton ID="btnPropertyDocuments" runat="server" OnClick="btnPropertyDocuments_Click" Text="Documents"></asp:LinkButton>
                                                        </li>

                                                    </ul>

                                                </div>
                                                <div class="panel-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane fade in active " id="tab1default" runat="server">
                                                            <div class="form-body">
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Vendor</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="DropDownListVendor" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                                <asp:Button ID="ButtonViewVendor" runat="server" Text="View" Visible="false" CssClass="btn green" OnClick="ButtonViewVendor_Click" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">
                                                                                Property Type
                                                                            </label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="DropDownListType" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList><br />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            &nbsp;
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Property Partner Reference</label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtPropertyPartnerRef" runat="server" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Property Status</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                                </asp:DropDownList>
                                                                                <asp:Label ID="lblSubjectTo" runat="server" Visible="false"></asp:Label>
                                                                                <asp:HiddenField ID="hdnPropertyStatus" runat="server" />
                                                                                <asp:HiddenField ID="hdnPropertyStatusValue" runat="server" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group" id="TableRowUnderOfferTo" runat="server" visible="false">
                                                                            <asp:Label ID="lblunderoofferto" runat="server" CssClass="control-label col-md-3"></asp:Label>
                                                                            <%--<label class="control-label col-md-3">Under Offer To </label>--%>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="DropDownListUnderOfferTo" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                                                <asp:Button ID="ButtonUnderOfferTo" runat="server" Text="View" CssClass="btn green" />
                                                                                <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-control" Style="display: none">
                                                                                    <asp:ListItem Text="Spain" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-5 inline-coder" id="TableRowDisplayProperty" visible="false" runat="server">
                                                                        <div class="form-group">
                                                                            <label class="control-label">
                                                                                Display Property 
                                                                                <asp:CheckBox ID="CheckBoxDisplay" runat="server" />
                                                                            </label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="control-label">
                                                                                Exclusive Listing
                                                                                <asp:CheckBox ID="CheckBoxFeature" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBoxFeature_CheckedChanged" />
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-7  inline-coder" id="TableRowFeatureProperty" visible="false" runat="server">
                                                                        <div class="form-group">
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                                                                                <asp:TextBox ID="txtStartDate" runat="server" autocomplete="off" Style="display: inline-block;"></asp:TextBox>
                                                                                <img src="../Images/Images/calendar.png" width="25" height="25" id="imgStartDate" style="cursor: pointer; display: inline-block;" onclick="javascript:document.getElementById('txtStartDate').click();" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date" autocomplete="off"></asp:Label>
                                                                                <asp:TextBox ID="txtExpiryDate" runat="server" autocomplete="off" Style="display: inline-block;"></asp:TextBox>
                                                                                <img src="../Images/Images/calendar.png" width="25" height="25" id="imgExpiryDate" style="cursor: pointer; display: inline-block;" onclick="javascript:document.getElementById('txtStartDate').click();" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <ucAdminLocation:AdminLocation ID="AdminLocation1" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">
                                                                                Catastro Tax Value<br />
                                                                                Minimum Declared Value
                                                                            </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtTAXABLEval" runat="server" CssClass="form-control" Rows="4" TextMode="MultiLine">
                                                                                </asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group" id="divBannerType" runat="server" visible="false">
                                                                            <label class="control-label col-md-3">Banner Type</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="drpBannerType" runat="server" CssClass="form-control">
                                                                                    <asp:ListItem Text="--None--" Value=""></asp:ListItem>
                                                                                    <asp:ListItem Text="DIY Bargain" Value="DIY Bargain"></asp:ListItem>
                                                                                    <asp:ListItem Text="Now Negotiable" Value="Now Negotiable"></asp:ListItem>
                                                                                    <asp:ListItem Text="Reformed" Value="Reformed"></asp:ListItem>
                                                                                    <asp:ListItem Text="Rent To Buy Option" Value="Rent To Buy Option"></asp:ListItem>
                                                                                    <asp:ListItem Text="Reserved" Value="Reserved"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <label class="control-label col-md-3">Property Listed </label>
                                                                        <div class="col-md-9" style="margin-top: 8px;">
                                                                            <asp:Label ID="lblListedBy" runat="server" Visible="false"></asp:Label><br />
                                                                            <asp:HiddenField ID="hdnListedById" runat="server" />
                                                                            <br />
                                                                            <asp:DropDownList ID="drpListedByUsers" Visible="false" runat="server" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <label class="control-label col-md-3">Agent </label>
                                                                        <div class="col-md-9" style="margin-top: 8px;">
                                                                            <asp:Label ID="lblAgent" runat="server" Text=""></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">

                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Address </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine">
                                                                                </asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3"></label>
                                                                            <div class="col-md-9">
                                                                                <div class="col-md-4">
                                                                                    <asp:Button ID="ButtonWindowcard" runat="server" Text="Windowcard" CssClass="btn green" Visible="false" />
                                                                                </div>
                                                                                <div class="col-md-5">
                                                                                    <asp:Button ID="ButtonViewingPhotos" runat="server" Text="Viewing Photos" CssClass="btn green" Visible="false" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Latitude</label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtLattitude" runat="server" CssClass="form-control" onkeypress="CheckDecimalAllowNegative(this, event);">
                                                                                </asp:TextBox>(e.g. 37.0)                                  
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Longitude </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control" onkeypress="CheckDecimalAllowNegative(this, event);">
                                                                                </asp:TextBox>(e.g. -4.0)                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Location</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="drplocation" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Views </label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="drpviews" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Bedrooms</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="drpbedrooms" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Bathrooms </label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="drpbathrooms" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Year Constructed</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="drpyearconstructed" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Plot </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtplot" runat="server" CssClass="form-control" onkeypress="CheckDecimal(this, event);" MaxLength="6" AutoCompleteType="None">
                                                                                </asp:TextBox>m2                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Built</label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtbuilt" runat="server" CssClass="form-control" onkeypress="CheckDecimal(this, event);" MaxLength="4" AutoCompleteType="None">
                                                                                </asp:TextBox>m2                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Terrace </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtterrace" runat="server" CssClass="form-control" onkeypress="CheckDecimal(this, event);" MaxLength="3" AutoCompleteType="None">
                                                                                </asp:TextBox>m2                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">En Suite</label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtensuite" runat="server" CssClass="form-control" onkeypress="CheckDecimal(this, event);" MaxLength="2" AutoCompleteType="None">
                                                                                </asp:TextBox>m2                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Annual IBI </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtAnnualIBI" runat="server" CssClass="form-control" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None">
                                                                                </asp:TextBox>€ (e.g. ###.## €)                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Annual Rubbish</label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtAnnualRubbish" runat="server" CssClass="form-control" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None">
                                                                                </asp:TextBox>€ (e.g. ###.## €)                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Community Fees </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtCommunityFees" runat="server" CssClass="form-control" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None">
                                                                                </asp:TextBox>€ (e.g. ###.## €)                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Vendor Price<span style="color: red;">(Net)</span></label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtVendorPrice" runat="server" CssClass="form-control" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None">
                                                                                </asp:TextBox>€ (e.g. ###.## €)                                           
                                                                                <asp:HiddenField ID="hdnVendorPrice" runat="server" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Original Price </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtOriginalPrice" runat="server" CssClass="form-control" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None">
                                                                                </asp:TextBox>€ (e.g. ###.## €)                                           
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Public Price</label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtPublicPrice" runat="server" CssClass="form-control" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None">
                                                                                </asp:TextBox>€ (e.g. ###.## €)                                           
                                                                                <asp:HiddenField ID="hdnPublicPrice" runat="server" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Youtube Video ID </label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtYoutubeVideoId" runat="server" CssClass="form-control" MaxLength="100" AutoCompleteType="None">
                                                                                </asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->
                                                                <!--/row-->
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Door Key</label>
                                                                            <div class="col-md-9">
                                                                                <asp:TextBox ID="txtDoorKey" runat="server" CssClass="form-control" MaxLength="10" AutoCompleteType="None">
                                                                                </asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Partner </label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="drpPartner" runat="server" CssClass="form-control" OnSelectedIndexChanged="drppartner_SelectedIndexChanged" Enabled="false" AutoPostBack="true">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!--/row-->

                                                                <!--/row-->
                                                                <div class="row" id="BrokerRow" runat="server" visible="false">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Broker</label>
                                                                            <div class="col-md-9">
                                                                                <%--<asp:DropDownList ID="drpBroker" runat="server" CssClass="form-control" Enabled="false">
                                                                                </asp:DropDownList>--%>
                                                                                <asp:Label ID="lblBroker" runat="server"></asp:Label>
                                                                                <asp:HiddenField ID="hdnBrokerId" runat="server" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">

                                                                    <div class="col-md-6" id="TableRowBuyerLawyer" runat="server" visible="false">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Buyer's Lawyer</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="DropDownListBuyerLawyer" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Vendor's Lawyer </label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="drpVendrlaywer" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">

                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3"></label>
                                                                            <div class="col-md-9">
                                                                                <%--<asp:Label ID="lblAgent" runat="server" Text=""></asp:Label>   --%>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3"></label>
                                                                            <div class="col-md-9">
                                                                                &nbsp;
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!--/row-->
                                                                <%-- End form 2 --%>
                                                            </div>
                                                            <div class="form-actions" id="propformbtn" runat="server" style="display: block">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <b>
                                                                            <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label></b>
                                                                        <div class="text-right">
                                                                            <asp:Button ID="btnSavePropertyGeneral" runat="server" Text="save" class="btn green" OnClick="btnSavePropertyGeneral_Click"></asp:Button>
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



