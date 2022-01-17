<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="NoHistory.aspx.vb" Inherits="Admin_NoHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function SelectAll(id) {
            var k = document.getElementsByClassName("clsinp");

            for (var i = 0; i < k.length; i++) {
                if (k[i].type == "checkbox") {
                    if (id.checked) {
                        k[i].checked = true;
                    }
                    else {
                        k[i].checked = false;
                    }
                }
            }
        }
        $(function () {
            $(document).off('click', '#ContentPlaceHolder1_BtnDelete').on('click', '#ContentPlaceHolder1_BtnDelete', function () {
                if ($("#ContentPlaceHolder1_grdAdmin input:checkbox:checked").length > 0) {
                    if (confirm("Are you sure you want to delete!") == true) {
                        return true
                    }
                    else {
                        return false;
                    }
                }
                else {
                    alert("Please select atleast one checkbox to Delete Record");
                    return false;
                }

            });

            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {


                $("#ContentPlaceHolder1_txtdatecreated").datepicker({
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
    <asp:UpdatePanel ID="manageAdmins" runat="server" UpdateMode="Conditional">
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
                        <a href="ManageUsers.aspx">ClientSearch </a>
                    </li>
                </ul>
            </div>--%>

            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">Client Search </div>

                            <div align="right" class="right">

                                <asp:CheckBox ID="CheckBoxIncludeArchived" runat="server" Text="Include Archived" class="input-small input-inline" />

                                <asp:Button ID="ButtonSearch" ToolTip="click here to search by First Name,Last Name and Archived ..!!" runat="server" class="btn green srchvendsrch mrgtp " Text="Search"></asp:Button>
                                <a class="btn green mrgtp left " href="javascript:window.history.back();" role="button">

                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">

                                <div class="row">
                                    <div class="col-md-12">
                                        <ul class="clnt-search">
                                            <li>
                                                <div id="sample_1_filter" class="inp">
                                                    <%--                            <asp:TextBox ID="txtname" runat="server"  class="form-control srchvend" placeholder="Name" aria-controls="sample_1" />--%>
                                                    <asp:TextBox ID="TextBoxFirstName" runat="server" class="form-control srchvend" placeholder="FirstName"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li>

                                                <asp:TextBox ID="txtlastname" runat="server" class="form-control srchvend" placeholder="LastName"></asp:TextBox>

                                            </li>

                                            <li>
                                                <asp:TextBox ID="txtBuyeremail" runat="server" class="form-control srchvend" placeholder="Email"></asp:TextBox>


                                            </li>
                                            <li>


                                                <asp:TextBox ID="txtdatecreated" runat="server" class="form-control srchvend" placeholder="DateCreated"></asp:TextBox>

                                            </li>
                                            <li>
                                                <asp:DropDownList ID="drpUser" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </li>
                                            <li>
                                                <asp:DropDownList ID="DropDownListSource" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </li>
                                            <li>
                                                <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </li>
                                        </ul>




                                    </div>





                                </div>
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">

                                                <asp:GridView
                                                    ID="GridViewResultsClient"
                                                    OnRowDataBound="GridViewResultsClient_RowDataBound"
                                                    DataKeyNames="ID"
                                                    runat="server"
                                                    Width="100%"
                                                    GridLines="None"
                                                    CssClass="mGrid"
                                                    PagerStyle-CssClass="pgr hvrexlude"
                                                    AlternatingRowStyle-CssClass="alt"
                                                    TabIndex="0"
                                                    AllowSorting="true" AllowPaging="true" PageSize="10" OnRowCommand="GridViewResultsClient_RowCommand" OnPageIndexChanging="GridViewResultsClient_PageIndexChanging"
                                                    AutoGenerateColumns="false" OnSorting="GridViewResultsClient_Sorting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="10px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="imgView" runat="server" Text="Select" CommandArgument='<%#Eval("ID") %>' ToolTip="Click to edit or view this Client " CommandName="editadmin" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="White" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                                                            <ItemTemplate>
                                                                <%#Eval("Name")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" SortExpression="Buyer_Email">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyer_Email")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Date Created" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" SortExpression="Buyer_Date_Created">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyer_Date_Created")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" SortExpression="Status">
                                                            <ItemTemplate>
                                                                <%#Eval("Status")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Source" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" SortExpression="Source">
                                                            <ItemTemplate>
                                                                <%#Eval("Source")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Salesperson" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" SortExpression="SalespersonName">
                                                            <ItemTemplate>
                                                                <%#Eval("SalespersonName")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>
                                            </tr>
                                        </thead>

                                    </table>


                                    <div align="right" id="TableRowNoResults" runat="server" visible="false">


                                        <strong>
                                            <asp:Label ID="LabelNoResults" runat="server" Text="No Results Found"></asp:Label></strong>

                                    </div>

                                </div>
                            </div>
                        </div>



                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

