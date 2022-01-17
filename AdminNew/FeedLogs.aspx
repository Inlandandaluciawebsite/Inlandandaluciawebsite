<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="FeedLogs.aspx.vb" Inherits="AdminNew_FeedLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function SelectAll(id) {
            var k = document.getElementsByTagName('input');
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
                if ($("#ContentPlaceHolder1_grdfeedlogs input:checkbox:checked").length > 0) {
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
            <%-- <h3 class="page-title">Manage Admins 
            </h3>--%>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="FeedLogs.aspx">All Feed Logs (Latest Updated Feeds) </a>
                    </li>
                </ul>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box blue-hoki">
                        <%-- <div class="portlet-title">
                            <div class="caption">Manage Admins </div>
                            <div class="tools"></div>
                        </div>--%>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                                <div class="row">
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-12">
                                        <div class="dataTables_length" id="sample_1_length">
                                            <div class="select2-drop select2-display-none select2-with-searchbox">
                                                <div class="select2-search">
                                                    <label for="s2id_autogen2_search" class="select2-offscreen"></label>
                                                    <asp:TextBox ID="txtSearch" runat="server" autocomplete="off" autocorrect="off" autocapitalize="off" spellcheck="false" class="select2-input" role="combobox" aria-expanded="true" aria-autocomplete="list" aria-owns="select2-results-2" placeholder=""></asp:TextBox>
                                                </div>
                                                <ul class="select2-results" role="listbox" id="select2-results-2">
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        <div id="sample_1_filter" class="dataTables_filter">
                                        </div>
                                    </div>
                                </div>

                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView ID="grdfeedlogs" AllowPaging="true" PageSize="50" OnRowCommand="grdfeedlogs_RowCommand" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnPageIndexChanging="grdfeedlogs_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Title" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("Title") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Modified" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("LastModified")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Live URL" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                               <a href='<%#Eval("LiveUrl")%>' target="_blank" style="color:blue;"><%#Eval("LiveUrl")%></a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Feed Execution Time" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("FeedExecutionTime")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                    <div align="right">
                                        <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Text="No Record Found!" Visible="false"></asp:Label>
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

