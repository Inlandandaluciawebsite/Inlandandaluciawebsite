<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="AddProperty.aspx.vb" Inherits="Admin_AddProperty" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlsNew/WebUserControlAdminLocationnw.ascx" TagName="AdminLocation" TagPrefix="ucAdminLocation" %>
<%@ Register Src="~/ControlsNew/WebUserControlAdminPropertyImagenw.ascx" TagName="AdminPropertyImage" TagPrefix="ucAdminPropertyImage" %>

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
            IsError += ValidateDropdown(document.getElementById('<%=drpproperty.ClientID%>'), "Please select property type!");
            IsError += ValidateDropdown(document.getElementById('<%=drpVendor.ClientID%>'), "Please select vendor!");
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
        function Validationspartner() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredField(document.getElementById('<%=txtproppartref.ClientID%>'), "Please enter property partner ref!");

            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlReportDetails.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>VENDOR REPORT</title>');
            printWindow.document.write('</head><body>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.getElementById('prntButton').style.display = 'none';
            var gridrows = printWindow.document.getElementById('ContentPlaceHolder1_GridViewList');
            for (var i = 0; i < gridrows.rows.length; i++) {
                gridrows.rows[i].cells[0].style.display = "none";
                gridrows.rows[i].cells[1].style = "padding:5px;border:1px solid black;";
                gridrows.rows[i].cells[2].style = "padding:5px;border:1px solid black;";
                gridrows.rows[i].cells[3].style = "padding:5px;border:1px solid black;";
                gridrows.rows[i].cells[4].style = "padding:5px;border:1px solid black;";
            }
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 100);
            return false;
        }
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $("#ContentPlaceHolder1_ButtonUploadImage").bind("click", function () {
                    if (typeof ($("#ContentPlaceHolder1_FileUploadImage")[0].files) != "undefined") {
                        var size = parseFloat($("#ContentPlaceHolder1_FileUploadImage")[0].files[0].size / 1024).toFixed(2);
                        if (size > 300) {
                            $("#ContentPlaceHolder1_lblimgsize").css("display", "block");

                            return false;
                        }
                        else {
                            $("#ContentPlaceHolder1_lblimgsize").css("display", "none");
                            return true;
                        }
                    } else {
                        return false;

                    }
                });
            });
        });

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
                                    </div>
                                </div>

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <%--  <form action="#" class="form-horizontal">--%>
                                    <div class="form-body" id="addprop" runat="server" style="display: block">
                                        <h3 class="form-section"></h3>
                                        <!--/row-->
                                        <asp:HiddenField ID="hdcont" runat="server" />
                                        <asp:HiddenField ID="hdnprevurl" runat="server" />
                                        <asp:HiddenField ID="hdpageind" runat="server" />
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Vendor</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="drpVendor" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Property Type </label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="drpproperty" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <!--/row-->
                                    </div>
                                    <div class="form-body" id="proppartref" runat="server" style="display: none">
                                        <h3 class="form-section"></h3>
                                        <!--/row-->
                                        <!--/row-->

                                        <!--/row-->

                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Partner Reference</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtproppartref" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <!--/row-->
                                    </div>
                                    <div class="form-actions" id="addpropbtn" runat="server" style="display: block">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn green" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none" OnClientClick="return Validations();"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions" id="proppartrefbtn" runat="server" style="display: none">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:Button ID="btn" runat="server" Text="Submit" class="btn green" OnClick="btn_Click" OnClientClick="return Validationspartner();"></asp:Button>
                                                        <asp:Button ID="btnback" runat="server" Text="Back" class="btn green" OnClick="btnback_Click"></asp:Button>
                                                        <asp:Label ID="lblpartmessage" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                            </div>
                                        </div>
                                    </div>


                                    <%--</form>--%>
                                    <!-- END FORM-->


                                    <%-- start form 2 --%>
                                    <%--  <form action="#" class="form-horizontal">--%>
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
                                    <div class="row" id="propform" runat="server" style="display: none">
                                        <div class="col-md-12">
                                            <div class="panel with-nav-tabs panel-default">
                                                <div class="panel-heading">
                                                    <h3 class="form-section">
                                                        <asp:Label ID="lblpropref" runat="server"></asp:Label>
                                                        <asp:Label ID="lblpartnerref" runat="server"></asp:Label>
                                                        <asp:LinkButton ID="btnedirref" runat="server" Text="Edit Reference" Visible="false" OnClick="btnedirref_Click">Edit Reference &nbsp; <i class="fa fa-hand-o-right" aria-hidden="true"></i></asp:LinkButton>
                                                        <asp:HiddenField ID="hdpropid" runat="server" />
                                                    </h3>
                                                    <ul class="nav nav-tabs">
                                                        <li runat="server" id="ligen">
                                                            <asp:LinkButton ID="lbltest" runat="server" OnClick="lblgeneral_Click" Style="display: block" Text="General"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="lidec">
                                                            <asp:LinkButton ID="Button3" runat="server" OnClick="LinkButton1_Click" Text="Descriptions"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liimage">
                                                            <asp:LinkButton ID="Button4" runat="server" OnClick="lblimages_Click" Text="Images"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="lifeat">
                                                            <asp:LinkButton ID="Button5" runat="server" OnClick="lblFeatures_Click" Text="Features"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="lihist">
                                                            <asp:LinkButton ID="Button6" runat="server" OnClick="lblHistory_Click" Text="History"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="lidocum">
                                                            <asp:LinkButton ID="Button7" runat="server" OnClick="lblDocuments_Click" Text="Documents"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyPayment" visible="false">
                                                            <asp:LinkButton ID="lnkPropertyPayment" runat="server" Visible="false" OnClick="lnkPropertyPayment_Click" Text="Payment"></asp:LinkButton>
                                                        </li>
                                                    </ul>
                                                </div>
                                                <div class="panel-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane fade in active " id="tab1default" runat="server" style="display: none">

                                                            <div class="form-body">

                                                                <!--/row-->
                                                                <!--/row-->

                                                                <!--/row-->



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
                                                                                <asp:DropDownList ID="DropDownListType" runat="server" CssClass="form-control" Enabled="false">
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
                                                                    <div class="col-md-7  inline-coder" id="TableRowFeatureProperty" runat="server">
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
                                                                            <asp:Label ID="lblListedBy" runat="server" Visible="false"></asp:Label>
                                                                            <asp:HiddenField ID="hdnListedById" runat="server" /><br />
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

                                                                <!--/row-->

                                                                <!--/row-->
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
                                                                            <asp:Label ID="lblmessage" runat="server"></asp:Label></b>
                                                                        <div class="text-right">
                                                                            <asp:Button ID="btnsaveproperty" runat="server" Text="save" class="btn green" OnClick="btnsaveproperty_Click"></asp:Button>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="tab-pane fade in active" id="tab2default" runat="server" style="display: none">
                                                            <div class="form-body">
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3">Language</label>
                                                                            <div class="col-md-9">
                                                                                <asp:DropDownList ID="DropDownListLanguage" runat="server" CssClass="form-control" AutoPostBack="true">
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
                                                                                <asp:TextBox ID="TextBoxShortDescription" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                                </asp:TextBox>
                                                                                <asp:Label ID="LabelMessageShort" runat="server" ForeColor="Gray" Font-Bold="True" Visible="False"></asp:Label>
                                                                            </div>
                                                                            <asp:Button ID="ButtonSaveShortDescription" runat="server" Text="Save" class="btn green" Style="display: none" />&nbsp;
                <asp:Button ID="ButtonAutoTranslateShort" runat="server" Text="Auto Translate" class="btn green" />

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <label class="control-label col-md-3 sdwdth">Main </label>
                                                                            <div class="col-md-8">
                                                                                <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="20" AutoPostBack="true">

                                                                                </asp:TextBox>
                                                                                <asp:Label ID="LabelMessage" runat="server" ForeColor="Gray" Font-Bold="True" Visible="False"></asp:Label>
                                                                            </div>


                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <div class="clsmaindesc">
                                                                            <asp:Button ID="ButtonSaveDescription" runat="server" Text="Save" class="btn green" Style="display: none" />&nbsp;
                <asp:Button ID="ButtonAutoTranslate" runat="server" Text="Auto Translate" class="btn green" />

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
                                                        <div class="tab-pane fade in active" id="tab3default" runat="server" style="display: none">
                                                            <div class="form-body">
                                                                <div class="row" id="TableUploadImages" runat="server" visible="false">
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

                                                                        <asp:Label ID="lblimgsize" Style="display: none" runat="server" Text="Please upload image of upto 300kb size only" ForeColor="Red"></asp:Label>

                                                                        <div id="TableRowBulkImageUpload" runat="server" visible="false">
                                                                            <asp:AjaxFileUpload ID="AjaxBulkFileUploadImage" runat="server"
                                                                                AllowedFileTypes="jpg,jpeg,png,gif,bmp"
                                                                                OnClientUploadCompleteAll="uploadComplete" />
                                                                        </div>

                                                                    </div>
                                                                </div>

                                                                <div id="TableImages" runat="server" visible="false">
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
                                                        <div class="tab-pane fade in active" id="tab4default" runat="server" style="display: none">
                                                            <div class="form-body">
                                                                <h3 class="form-section"></h3>
                                                                <div id="TableFeatures" runat="server" visible="false">
                                                                    <div class="row">
                                                                        <div class="col-md-3 col-sm-6 chkspc" id="Column1" runat="server"></div>
                                                                        <div class="col-md-3 col-sm-6 chkspc" id="Column2" runat="server"></div>
                                                                        <div class="col-md-3 col-sm-6 chkspc" id="Column3" runat="server"></div>
                                                                        <div class="col-md-3 col-sm-6 chkspc" id="Column4" runat="server"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-actions">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <b>
                                                                            <asp:Label ID="lblfeatuer" runat="server"></asp:Label></b>
                                                                        <div class="text-right">
                                                                            <asp:Button ID="btnfeater" runat="server" Text="Save" class="btn green" OnClick="btnfeater_Click"></asp:Button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="tab-pane fade in active" id="tab5default" runat="server" style="display: block;">
                                                            <div class="form-body" id="TableHistory" runat="server">
                                                                <asp:Panel ID="pnlReportDetails" runat="server">
                                                                    <fieldset>
                                                                        <legend>Report Details:</legend>
                                                                        <div class="property-details-single">
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Name:</span>
                                                                                            <asp:Literal ID="lblHistoryVendorName" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Email: </span>
                                                                                            <asp:Literal ID="lblHistoryVendorEmail" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Telephone: </span>
                                                                                            <asp:Literal ID="lblHistoryVendorTelephone" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Property Reference:</span>
                                                                                            <asp:Literal ID="lblHistoryPropReference" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Date Created: </span>
                                                                                            <asp:Literal ID="lblHistoryDateCreated" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Date Last Modified: </span>
                                                                                            <asp:Literal ID="lblHistoryDateModified" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Original Price: </span>
                                                                                            <asp:Literal ID="lblHistoryOriginalPrice" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Public Price: </span>
                                                                                            <asp:Literal ID="lblHistoryPublicPrice" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Vendor Price: </span>
                                                                                            <asp:Literal ID="lblHistoryVendorPrice" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Views: </span>
                                                                                            <asp:Literal ID="lblHistoryViews" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                        <p>
                                                                                            <span>Total Enquries:</span>
                                                                                            <asp:Literal ID="lblTotalEnquries" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <p>
                                                                                            <span>Toured: </span>
                                                                                            <asp:Literal ID="lblHistoryToured" runat="server"></asp:Literal>
                                                                                        </p>
                                                                                    </td>
                                                                                    <td>
                                                                                        <p>
                                                                                            <a style="color: white; background-color: blue; padding: 3px; font-weight: bold;" id="prntButton" onclick="return PrintPanel();">
                                                                                                <i class="fa fa-print"></i>Print</a>
                                                                                        </p>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div class="table-scrollable01">
                                                                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                                                                <thead>
                                                                                    <tr role="row" style="border: 1px solid #ddd">
                                                                                        <asp:GridView
                                                                                            ID="GridViewList"
                                                                                            runat="server"
                                                                                            Width="100%"
                                                                                            GridLines="None"
                                                                                            CssClass="mGrid"
                                                                                            PagerStyle-CssClass="pgr"
                                                                                            AlternatingRowStyle-CssClass="alt"
                                                                                            AutoGenerateSelectButton="true">
                                                                                        </asp:GridView>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </fieldset>
                                                                </asp:Panel>
                                                                <div class="row" id="TableRowHistoryElement" runat="server" visible="false">
                                                                    <div class="col-md-12">
                                                                        <asp:TextBox ID="TextBoxHistory" runat="server" TextMode="MultiLine" CssClass="form-control" AutoCompleteType="None"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div id="TableRowHistoryArchive" runat="server" visible="false" class="row">
                                                                    <div class="col-md-12 text-right">
                                                                        <asp:Button ID="ButtonArchiveHistory" runat="server" Text="Archive" CssClass="btn green" />
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div>&nbsp;</div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <asp:DropDownList ID="DropDownListHistoryType" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="row" id="divOwnerCallRow" runat="server" visible="false">
                                                                    <div class="col-md-12">
                                                                        Have you tried to reduce the price of the property ?
                                                                        <br />
                                                                        <br />
                                                                        <asp:RadioButton ID="rbtReduceYes" runat="server" Text="Yes I tried & Owner agreed to reduce the price" GroupName="OwnerCall" AutoPostBack="true" OnCheckedChanged="rbtReduceYes_CheckedChanged" />&nbsp; &nbsp;
                                                                        <br />
                                                                        <asp:RadioButton ID="rbtReduceDontWant" runat="server" Text="Yes I tried ,  But Owner not agreed to reduce the price" GroupName="OwnerCall" AutoPostBack="true" OnCheckedChanged="rbtReduceDontWant_CheckedChanged" /><br />
                                                                        <asp:RadioButton ID="rbtReduceNo" runat="server" Text="No, this record is not related with price change" GroupName="OwnerCall" AutoPostBack="true" OnCheckedChanged="rbtReduceNo_CheckedChanged" />&nbsp; &nbsp; 

                                                                        <br />
                                                                        <br />
                                                                        <div id="divReducePriceFromTo" runat="server" visible="false">
                                                                            Vendor's price reduces from
                                                                            <asp:TextBox ID="txtReduceFrom" runat="server" onkeypress="CheckNumeric(event);" MaxLength="10" AutoCompleteType="None"></asp:TextBox>&nbsp;&nbsp;
                                                                            to &nbsp;&nbsp;<asp:TextBox ID="txtReduceTo" runat="server" onkeypress="CheckNumeric(event);" MaxLength="10" AutoCompleteType="None" AutoPostBack="true" OnTextChanged="txtReduceTo_TextChanged"></asp:TextBox>
                                                                            &nbsp;&nbsp;and press "enter"
                                                                            <br />
                                                                        </div>
                                                                        <br />
                                                                    </div>
                                                                </div>
                                                                <div class="row" id="divSubjectTo" runat="server" visible="false">
                                                                    <div class="col-md-12">
                                                                        <br />
                                                                        Expiry Date :
                                                                        <asp:TextBox ID="txtSubjectExpiryDate" runat="server" Width="206"></asp:TextBox><br />
                                                                        <br />

                                                                        Select Buyer : 
                                                                        <asp:DropDownList ID="drpSubjectToBuyer" runat="server" Width="200" Style="border: 1px solid;"></asp:DropDownList>
                                                                        <br />
                                                                        <br />
                                                                    </div>
                                                                </div>
                                                                <div class="row" id="TableRowSoldTo" runat="server" visible="false">
                                                                    <div class="col-md-12">
                                                                        Buyer:
                                                                        <asp:DropDownList ID="DropDownListBuyer" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <asp:TextBox ID="TextBoxAddHistory" CssClass="form-control" runat="server" MaxLength="1500" TextMode="MultiLine" Width="100%" Height="250px" AutoPostBack="true" AutoCompleteType="None"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-actions" style="display: none" id="lnkhistory" runat="server">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <b>
                                                                            <asp:Label ID="lblhistorymsg" runat="server"></asp:Label></b>
                                                                        <div class="text-right">
                                                                            <asp:LinkButton ID="btnhistory" runat="server" Text="Save" ValidationGroup="PriceChanges" class="btn green" OnClick="btnhistory_Click"></asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="tab-pane fade in active" id="tab6default" runat="server" style="display: none">
                                                            <div class="form-body" id="TableDocuments" runat="server" font-names="Calibri" visible="false">
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
                                                        <div class="tab-pane fade in active" id="tabPropertyPayment" runat="server" style="display: none" visible="false">
                                                            <div class="form-body" id="divPropertyPayment" runat="server" font-names="Calibri" visible="false">
                                                                <div class="row">
                                                                    <div class="col-sm-2">
                                                                        Select Payment Type :
                                                                    </div>
                                                                    <div class="col-sm-10">
                                                                        <asp:DropDownList ID="drpPaymentType" runat="server" CssClass="form-control" Width="350">
                                                                            <asp:ListItem Text="Bank Transfer" Value="Bank Transfer"></asp:ListItem>
                                                                            <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                                            <asp:ListItem Text="Credit Card" Value="Credit Card"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-2">
                                                                        Amount : <span style="color: green; font-weight: bold;">In Euro (€)</span>
                                                                    </div>
                                                                    <div class="col-sm-10">
                                                                        <asp:TextBox ID="txtPaymentAmount" runat="server" CssClass="form-control" Width="350" MaxLength="5" oninput="this.value = this.value.replace(/[^0-9\-]+/g, '').replace(/(\..*)\./g, '$1');"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-2">
                                                                        Select Buyer : 
                                                                    </div>
                                                                    <div class="col-sm-10">
                                                                        <asp:DropDownList ID="drpPaymentBuyer" runat="server" CssClass="form-control" Width="350">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-2">
                                                                        Select Subject Type :
                                                                    </div>
                                                                    <div class="col-sm-10">
                                                                        <asp:DropDownList ID="drpPaymentSubjectType" runat="server" CssClass="form-control" Width="350">
                                                                            <asp:ListItem Text="Subject to : None" Value="19"></asp:ListItem>
                                                                            <asp:ListItem Text="Subject to : Viewing" Value="20"></asp:ListItem>
                                                                            <asp:ListItem Text="Subject to : Mortgage" Value="21"></asp:ListItem>
                                                                            <asp:ListItem Text="Subject to : Loan" Value="22"></asp:ListItem>
                                                                            <asp:ListItem Text="Subject to : Survey" Value="23"></asp:ListItem>
                                                                            <asp:ListItem Text="Subject to : Quotation" Value="24"></asp:ListItem>
                                                                            <asp:ListItem Text="Subject to : Sale Buyer Property" Value="25"></asp:ListItem>
                                                                            <%--<asp:ListItem Text="Subject to : no longer valid" Value="26"></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-2">
                                                                        Expiry Date :
                                                                    </div>
                                                                    <div class="col-sm-10">
                                                                        <asp:TextBox ID="txtPaymentExpiryDate" runat="server"  autocomplete="off" CssClass="form-control" Width="350"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-2">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div class="col-sm-10">
                                                                        <asp:Button ID="btnPaymentSave" runat="server" Text="Save" CssClass="btn green" Width="100" OnClick="btnPaymentSave_Click" />
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        &nbsp;
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-2">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div class="col-sm-10">
                                                                        <asp:Label ID="lblPaymentSaveMessage" runat="server" Font-Bold="true" Visible="false"></asp:Label>
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
            <%--      </div>
    </div>
            --%>
            <!-- END CONTENT -->
            <!-- BEGIN QUICK SIDEBAR -->


            <!-- END QUICK SIDEBAR -->

            <!-- END CONTAINER -->
            <!-- BEGIN FOOTER -->
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonUploadImage" />

            <asp:PostBackTrigger ControlID="ButtonUpload" />
            <asp:PostBackTrigger ControlID="ButtonDownload" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>



