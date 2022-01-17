<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ManageTownInfo.aspx.vb" Inherits="AdminNew_ManageTownInfo" %>

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
                    //if (confirm("Are you sure you want to delete!") == true) {
                        return true
                    //}
                    //else {
                    //    return false;
                    //}
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
                        <a href="Blogs.aspx">Manage Town Info Pages </a>
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
                                    <div class="col-md-12 col-sm-12">
                                        <asp:DropDownList ID="drpRegions" runat="server" class="form-control" Width="200" AutoPostBack="true" OnSelectedIndexChanged="drpRegions_SelectedIndexChanged">
                                            <asp:ListItem Text="--All Regions--" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Cordoba" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Granada" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Jaen" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Malaga" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Sevilla" Value="5"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CheckBox ID="chkIncludePropertySearchPages" runat="server" Text="Have Town Info ?" Checked="true" CssClass="input-small input-inline srchvendarch" AutoPostBack="true" OnCheckedChanged="chkIncludePropertySearchPages_CheckedChanged" />
                                    </div>
                                </div>
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView ID="grdAdmin" DataKeyNames="PageId" AllowPaging="true" PageSize="15" OnRowCommand="grdAdmin_RowCommand" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnPageIndexChanging="grdAdmin_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                            <HeaderTemplate>
                                                                <input type="checkbox" onclick="SelectAll(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Region" HeaderStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <%#Eval("Region")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Area" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <%#Eval("Area_Name")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Page" HeaderStyle-Width="450px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <a href='/towninformation/<%#Eval("PageName") %>' target="_blank"><%#Eval("PageName") %></a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Created" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <%#Eval("DateCreated")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View" HeaderStyle-Width="25px" HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgView" runat="server" BorderStyle="None" CommandArgument='<%#Eval("PageId")%>' ToolTip="Click to edit or view this town info page " CommandName="editblog" ImageUrl="images/view-img.png" />
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
                                        <asp:Button ID="BtnDelete" runat="server" class="btn green" Text="Delete" Visible="false" OnClientClick="javascript: return confirm('If you will delete this page, it will delete all of its related images & folders, are you sure you want to delete this page ? ');" OnClick="BtnDelete_Click" />
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

