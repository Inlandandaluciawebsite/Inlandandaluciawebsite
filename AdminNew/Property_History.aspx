<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Property_History.aspx.vb" Inherits="AdminNew_Property_History" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
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
                $(".mrgtp").click(function () {
                    var stateObj = $("#ContentPlaceHolder1_hdcont").val()
                    var pageindex = $("#ContentPlaceHolder1_hdpageind").val()
                    var prevurl = $("#ContentPlaceHolder1_hdnprevurl").val()
                    window.location.href = prevurl
                })
            });
        });
        function Encode() {
            var value = (document.getElementById('ContentPlaceHolder1_TextBoxAddHistory').value);
            value = value.replace('<', "< ");
            value = value.replace('>', " >");
            document.getElementById('ContentPlaceHolder1_TextBoxAddHistory').value = value;
        }
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
                                        Add/Edit Property History
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
                                                        <li runat="server" id="liPropertyHistory" class="active">
                                                            <asp:LinkButton ID="btnPropertyHistory" runat="server" OnClick="btnPropertyHistory_Click" Text="History"></asp:LinkButton>
                                                        </li>
                                                        <li runat="server" id="liPropertyDocuments">
                                                            <asp:LinkButton ID="btnPropertyDocuments" runat="server" OnClick="btnPropertyDocuments_Click" Text="Documents"></asp:LinkButton>
                                                        </li>

                                                    </ul>
                                                </div>
                                                <div class="panel-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane fade in active" id="tab5default" runat="server">
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
                                                                                            <span>Total Enquiries:</span>
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
                                                                                            <asp:HiddenField ID="hdnPropertyStatus" runat="server" />
                                                                                            <asp:HiddenField ID="hdnPropertyStatusText" runat="server" />
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
                                                                        <asp:DropDownList ID="DropDownListBuyer" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListBuyer_SelectedIndexChanged"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <asp:TextBox ID="TextBoxAddHistory" CssClass="form-control" runat="server" MaxLength="1500" TextMode="MultiLine" Width="100%" Height="250px" AutoPostBack="true" AutoCompleteType="None"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-actions" id="lnkhistory" runat="server">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <b>
                                                                            <asp:Label ID="lblhistorymsg" runat="server"></asp:Label></b>
                                                                        <div class="text-right">
                                                                            <asp:LinkButton ID="btnhistory" runat="server" Text="Save" ValidationGroup="PriceChanges" class="btn green" OnClick="btnhistory_Click" OnClientClick="Encode()"></asp:LinkButton>
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
    </asp:UpdatePanel>
</asp:Content>

