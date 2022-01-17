<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ClientTours.aspx.vb" Inherits="ClientTours" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $("#ContentPlaceHolder1_txtDateFrom").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                });
                $("#ContentPlaceHolder1_txtDateTo").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                });
            });
        });
    </script>
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
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label ID="LabelClientTourSearch" runat="server" Text="Client Tour Search"></asp:Label>
                            </div>
                            <div align="right" class="right">
                                <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">
                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">

                                <%-- <h1></h1>--%>
                                <p>&nbsp;</p>

                                <div id="TableClientTourSearch" runat="server">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">
                                                    <asp:Label ID="LabelReference" runat="server" Text="Viewing Reference"></asp:Label>:</label>
                                                <asp:DropDownList ID="DropDownListTourID" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="daterng">
                                                <div class="form-group">
                                                    <label for="exampleInputEmail1">
                                                        <asp:Label ID="LabelDateRange" runat="server" Text="Date Range"></asp:Label>:</label> <span style="color:red;">(Remove any existing Date Range if viewing reference is selected)</span>
                                                    <div class="yfhgf">
                                                        <div class="col-md-2">
                                                            <%--<asp:DropDownList ID="DropDownListDateFromDay" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>--%>
                                                            <asp:TextBox ID="txtDateFrom" runat="server" class="form-control srchvend" placeholder="Date From" Width="250" autocomplete="off"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <%--<asp:DropDownList ID="DropDownListDateFromMonth" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>--%>
                                                            <asp:TextBox ID="txtDateTo" runat="server" class="form-control srchvend" placeholder="Date To" Width="250" autocomplete="off"></asp:TextBox>
                                                        </div>
                                                        <%--                                                        <div class="col-md-2">
                                                            <asp:DropDownList ID="DropDownListDateFromYear" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <p style="line-height: 30px; text-align: center">and</p>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:DropDownList ID="DropDownListDateToDay" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:DropDownList ID="DropDownListDateToMonth" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:DropDownList ID="DropDownListDateToYear" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                        </div>--%>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">
                                                    <asp:Label ID="LabelBuyer" runat="server" Text="Buyer"></asp:Label>:</label>
                                                <asp:DropDownList ID="DropDownListBuyer" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">
                                                    <asp:Label ID="LabelTourWith" runat="server" Text="Tour With"></asp:Label>:</label>
                                                <asp:DropDownList ID="DropDownListTourWith" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-12">

                                                <div class="text-right">
                                                    <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="btn green" />
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            &nbsp;
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-scrollable">
                                                <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr role="row" style="border: 1px solid #ddd">
                                                            <asp:GridView
                                                                ID="GridViewResults"
                                                                runat="server"
                                                                Width="100%"
                                                                GridLines="None"
                                                                CssClass="mGrid"
                                                                PagerStyle-CssClass="pgr"
                                                                AlternatingRowStyle-CssClass="alt"
                                                                AutoGenerateColumns="false"
                                                                AutoGenerateSelectButton="true"
                                                                AllowSorting="True" OnRowDataBound="GridViewResults_RowDataBound" OnSorting="GridViewResults_Sorting">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Reference" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" SortExpression="Reference">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Reference")%>
                                                                            <asp:HiddenField ID="hdnReference" runat="server" Value='<%#Eval("Reference")%>' />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Date and Time" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" SortExpression="DateTime">
                                                                        <ItemTemplate>
                                                                            <%#Eval("DateTime")%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Buyer" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" SortExpression="Buyer">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Buyer")%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Tour By" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" SortExpression="Tour">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Tour")%>
                                                                            <asp:HiddenField ID="hdnBuyerId" runat="server" Value='<%#Eval("BuyerId")%>' />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Tour Type" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" SortExpression="VirtualTour">
                                                                        <ItemTemplate>
                                                                            <%#Eval("VirtualTour")%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>
                                                                </Columns>

                                                            </asp:GridView>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">

                                            <div class="text-right">
                                                <strong>
                                                    <asp:Label ID="LabelNoResults" runat="server" Text="No Results Found" Visible="false"></asp:Label></strong>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-12">

                                                <div class="text-right">
                                                    <asp:ImageButton ID="btnback" runat="server" CssClass="agentloginbutton" Visible="false" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
