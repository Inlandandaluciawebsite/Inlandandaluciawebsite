<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="LatestProperties.aspx.vb" Inherits="Admin_LatestProperties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        th {
            padding: 7px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="manageAdmins" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="manageAdmins"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="overlay" id="divProgress">
                        &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="50"
                    Height="40" ImageUrl="images/ajaxloading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label ID="LabelLatestProperties" runat="server" Text="Latest Properties"></asp:Label>
                            </div>
                            <div align="right" class="right">
                                <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">
                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">

                                <div class="row">
                                </div>

                                <div class="form-body">
                                    <h3 class="form-section"></h3>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Duration:</label>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="DropDownListDuration" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Include: </label>
                                                <div class="col-md-5">
                                                    <asp:CheckBox ID="CheckBoxCreated" runat="server" Text="Created Properties" Checked="true" />
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:CheckBox ID="CheckBoxModified" runat="server" Text="Modified Properties" Checked="true" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!--/row-->
                                </div>
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-offset-3 col-md-9">
                                                    <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="btn green" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 text-right" id="TableRowNoResults" runat="server" visible="false">
                                        <asp:Label ID="LabelNoResults" runat="server" Text="No Results Found"></asp:Label>
                                    </div>
                                    <div class="col-md-12 text-right" id="TableRowNoOfResults" runat="server" visible="false">
                                        <asp:Label ID="LabelNoOfResults" runat="server"></asp:Label>
                                    </div>
                                </div>


                                <div class="table-scrollable" id="TableResults" runat="server" visible="false">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView
                                                    ID="GridViewResultslatest"
                                                    runat="server"
                                                    Width="100%"
                                                    GridLines="None"
                                                    CssClass="mGrid table-hover"
                                                    PagerStyle-CssClass="pgr"
                                                    AlternatingRowStyle-CssClass="alt"
                                                    AutoGenerateSelectButton="true"
                                                    AllowSorting="True"
                                                    Font-Names="Open Sans, sans-serif"
                                                    class="sorting"
                                                    HeaderStyle-Height="20px"
                                                    BorderColor="#dddddd"
                                                    OnRowDataBound="GridViewResultslatest_RowDataBound"
                                                    DataKeyNames="id">
                                                </asp:GridView>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>

                                    </table>

                                </div>

                            </div>
                        </div>
                    </div>



                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

