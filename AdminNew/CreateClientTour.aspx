<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="CreateClientTour.aspx.vb" Inherits="CreateClientTour" %>

<%@ Register Src="~/ControlsNew/WebUserControlAdminLocationclient.ascx" TagName="AdminLocation" TagPrefix="ucAdminLocation" %>
<%@ Reference Control="~/ControlsNew/WebUserControlAdminPropertySearchResultsHeader.ascx" %>
<%@ Reference Control="~/ControlsNew/WebUserControlAdminPropertySearchResult.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            <h3 class="page-title"></h3>
            <%-- <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="Index.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="ManageUsers.aspx">Manage Users </a>

            </li>

        </ul>
  
    </div>--%>

            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label ID="LabelHeader" runat="server"></asp:Label>
                            </div>
                            <div align="right" class="right">
                                <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">

                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="form-body">
                                <%--  <h1></h1>--%>
                                <p>&nbsp;</p>
                                <div id="TableSearchFilters" runat="server" width="100%">

                                    <div class="row">

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Reference: </label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="TextBoxReference" runat="server" Style="text-transform: uppercase" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Type: </label>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="DropDownListType" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <ucAdminLocation:AdminLocation ID="AdminLocation1" runat="server" />
                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">

                                            <div class="form-group">
                                                <label class="control-label col-md-3">Min Bedrooms:</label>
                                                <div class="col-md-4">
                                                    <asp:DropDownList ID="DropDownListMinBedrooms" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>


                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Min Bathrooms:</label>
                                                <div class="col-md-4">
                                                    <asp:DropDownList ID="DropDownListMinBathrooms" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">

                                                <div class="col-md-9">
                                                    <asp:LinkButton ID="LinkButtonFeatures" runat="server" CssClass="">Features:</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>



                                    </div>

                                    <div class="row" id="TableRowFeatures" runat="server" visible="false">

                                        <div>

                                            <div id="TableFeatures" runat="server" width="100%">

                                                <div class="row">

                                                    <div class="col-md-2"></div>
                                                    <div class="col-md-2" id="ColumnFeatures1" runat="server"></div>
                                                    <div class="col-md-2" id="ColumnFeatures2" runat="server"></div>
                                                    <div class="col-md-2" id="ColumnFeatures3" runat="server"></div>
                                                    <div class="col-md-2" id="ColumnFeatures4" runat="server"></div>
                                                    <div class="col-md-2" id="ColumnFeatures5" runat="server"></div>

                                                </div>

                                            </div>

                                        </div>

                                    </div>



                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Price: </label>
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="TextBoxPriceFrom" runat="server" onkeypress="CheckNumeric(event);" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1">
                                                    and
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="TextBoxPriceTo" runat="server" CssClass="form-control" onkeypress="CheckNumeric(event);"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Minimum Plot Size: </label>
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="txtminplotsize" runat="server"  CssClass="form-control" onkeypress="CheckNumeric(event);"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1">
                                                </div>
                                                <div class="col-md-4">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">

                                                        <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="btn green" />
                                                    </div>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                            </div>
                                        </div>
                                    </div>



                                </div>

                                <div id="TableNoResults" runat="server" visible="false">
                                    <div class="row">
                                        <div class="col-md-6"></div>
                                        <div class="col-md-6">
                                            <strong>
                                                <asp:Label ID="LabelNoResults" runat="server" Text="No Results"></asp:Label></strong>
                                        </div>
                                    </div>
                                </div>

                                <asp:UpdatePanel ID="UpdatePanelAdminClientTourPropertySearchResults" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanelPaging" runat="server">
                                    <ContentTemplate>

                                        <div id="TableFooter" runat="server">

                                            <div class="row">

                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="DropDownListPage" runat="server" Visible="false" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                </div>

                                                <div class="col-md-4">
                                                    <asp:LinkButton ID="LinkButtonPropertiesSelected" runat="server"></asp:LinkButton>
                                                </div>

                                                <div class="col-md-3">
                                                    <asp:HyperLink ID="HyperLink3Card" runat="server" NavigateUrl="~/Admin/3PropertyDisplayCard.aspx" Target="_blank">3 Property Card Print</asp:HyperLink>
                                                </div>

                                                <div class="col-md-3">
                                                    <asp:Button ID="ButtonFinish" runat="server" Text="Finish" Visible="false" CssClass="btn green" />
                                                </div>

                                            </div>

                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    </div>



                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
