<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Managelawyer.aspx.vb" Inherits="ManageLawyer" %>

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
            <%--    <h3 class="page-title">Manage Lawyer 
    </h3>--%>
            <%-- <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="Index.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="ManageLawyer.aspx">Manage Lawyer </a>

            </li>

        </ul>
  
    </div>--%>

            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">Manage Lawyer </div>
                            <div align="right" class="right">
                                <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">

                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">

                                <div class="row">

                                    <div class="col-md-4 col-sm-4">

                                        <div id="sample_1_filter" class="inp">
                                            <asp:TextBox ID="txtname" runat="server" class="form-control srchvend" placeholder="Name" aria-controls="sample_1" />



                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3" style="display: none">
                                        <asp:TextBox ID="txtprop" runat="server" class="form-control srchvend" placeholder="Property Refrence" aria-controls="sample_1" />


                                    </div>
                                    <div class="col-md-5 col-sm-5">
                                        <asp:CheckBox ID="chkarchived" runat="server" Text="Include Archived" Visible="false" class="input-small input-inline srchvendarch" />

                                        <asp:Button ID="imgsearch" OnClick="imgsearch_Click1" ToolTip="click here to search by Name and Archived ..!!" runat="server" class="btn green srchvendsrch" Text="Search"></asp:Button>

                                    </div>
                                </div>

                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView ID="grdAdmin" DataKeyNames="contact_id" OnRowDataBound="grdAdmin_RowDataBound1" AllowPaging="true" PageSize="10" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnRowCommand="grdAdmin_RowCommand" OnPageIndexChanging="grdAdmin_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">

                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thwdth">
                                                            <HeaderTemplate>
                                                                <input type="checkbox" onclick="SelectAll(this);" class="clsinp" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" class="clsinp" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Lawyer Name" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("contact_name") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Lawyer Mobile" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("Contact_Mobile")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Lawyer Email" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("Contact_Email")%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Partners" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%# AllPartners_By_Email(Eval("Contact_Email"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgView" runat="server" CommandArgument='<%#Eval("contact_id") %>' ToolTip="Click to edit or view this Lawyer " CommandName="editadmin" ImageUrl="~/Admin/images/view-img.png" />
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
                                        <asp:Button ID="BtnDelete" runat="server" class="btn green" Text="Delete" Visible="false" OnClick="BtnDelete_Click"
                                            OnClientClick="javascript: return validateCheckBoxes()" />

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
