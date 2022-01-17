<%@ Page Title="Jabberad-Manage Admins" Language="C#" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="true" CodeFile="ManageAdmins.aspx.cs" Inherits="Admin_ManageAdmins" %>

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
                    Height="40" ImageUrl="~/Admin/images/ajaxloading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <h3 class="page-title">Manage Admins 
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="ManageAdmins.aspx">Manage Admins </a>
                    </li>
                </ul>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box blue-hoki">
                        <div class="portlet-title">
                            <div class="caption">Manage Admins </div>
                            <div class="tools"></div>
                        </div>
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
                                                <asp:GridView ID="grdAdmin" DataKeyNames="AdminId" AllowPaging="true" PageSize="10" OnRowCommand="grdAdmin_RowCommand" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnPageIndexChanging="grdAdmin_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
                                                            <HeaderTemplate>
                                                                <input type="checkbox" onclick="SelectAll(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("Name") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="City" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("City")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="State" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("State")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("Email")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Phone" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("Phone")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Zip Code" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("AreaZipCode")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnStatus" CommandName="changestatus" CommandArgument='<%#Eval("AdminId")%>'
                                                                    ToolTip="Click to change status. !!!" ImageUrl='<%#Eval("Status")%>' runat="server"
                                                                    OnClientClick="javascript:return confirm('Are you sure you want to make this change !');" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgView" runat="server" CommandArgument='<%#Eval("AdminID") %>' ToolTip="Click to edit or view this admin " CommandName="editadmin" ImageUrl="~/Admin/images/view-img.png" />
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
                                        <asp:Button ID="BtnDelete" runat="server" class="btn green" Text="Delete" Visible="false" OnClick="BtnDelete_Click" />
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

