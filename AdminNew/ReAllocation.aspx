<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ReAllocation.aspx.vb" Inherits="Admin_ReAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" lang="javascript">
        function Validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateDropdown(document.getElementById('<%=drpSalesPersonFrom.ClientID%>'), "Please select salesperson from !");
            IsError += ValidateDropdown(document.getElementById('<%=drpSalesPersonTo.ClientID%>'), "Please select salesperon to !");
            IsError += ValidateRequiredField(document.getElementById('<%=txtNumberOfRecords.ClientID%>'), "Number Of Records Field is Required !");
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                Re-Allocation Process
                            </div>
                            <div align="right">
                                <a class="btn green mrgtp" href="ManageTasks.aspx" role="button">
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

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">SalesPerson From</label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="drpSalesPersonFrom" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpSalesPersonFrom_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                Total Clients :
                                                <asp:Label ID="lblSalesPersonFromTotalClient" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/span-->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">SalesPerson To</label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="drpSalesPersonTo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpSalesPersonTo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                Total Clients :
                                                <asp:Label ID="lblSalesPersonToTotalClient" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/span-->
                                </div>
                                <div class="row">
                                    &nbsp;
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Number of clients to Re-Allocate</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtNumberOfRecords" runat="server" Placeholder="Number Of Records to Re-Allocate" class="form-control" onkeypress="CheckNumeric(event);" MaxLength="7"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">From</label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="drpOrderBy" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Newest" Value="desc"></asp:ListItem>
                                                    <asp:ListItem Text="Oldest" Value="asc"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn green" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn default"></asp:Button>
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
        </div>
    </div>
</asp:Content>
