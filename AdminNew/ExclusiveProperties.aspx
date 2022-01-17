<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ExclusiveProperties.aspx.vb" Inherits="Admin_ExclusiveProperties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        th a {
            color: black !important;
        }

        .custom_7 .col-md-2 {
            width: calc(100% / 7);
        }
    </style>
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
                        <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" ImageUrl="images/ajaxloading.gif" />
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
                        <a href="ManageProperties.aspx">Manage Properties </a>
                    </li>
                </ul>
            </div>--%>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">Exclusive Properties </div>
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
                                            <asp:TextBox ID="txtreference" runat="server" class="form-control srchvend" placeholder="Reference" aria-controls="sample_1" Style="text-transform: uppercase" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-3">
                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control srchvend" placeholder="Address" aria-controls="sample_1" />
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:Button ID="imgsearch" OnClick="imgsearch_Click1" ToolTip="click here to search by Reference, Address  ..!!" runat="server" class="btn green srchvendsrch" Text="Search"></asp:Button>
                                    </div>
                                    <div class="col-md-3 col-sm-3">
                                        <asp:DropDownList ID="drpAllORPartner" runat="server" CssClass="form-control" Visible="false" OnSelectedIndexChanged="drpAllORPartner_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <p class="text-right" style="font-weight: 800">
                                            <asp:Label ID="lbltotlacount" runat="server"></asp:Label>
                                            Result(s)
                                        </p>
                                    </div>
                                </div>
                                <div class="row custom_7">
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpproperty" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpproperty_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpArea" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpArea_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpTown" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpTown_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpbedrooms" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpbedrooms_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpbathrooms" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpbathrooms_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownListStatus_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpColors" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpColors_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="--Color--" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Orange" Value="Orange"></asp:ListItem>
                                            <asp:ListItem Text="Yellow" Value="Yellow"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView ID="grdAdmin" DataKeyNames="property_id" OnSorting="grdAdmin_Sorting" OnRowDataBound="grdAdmin_RowDataBound1" AllowPaging="true" PageSize="10" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnRowCommand="grdAdmin_RowCommand" OnPageIndexChanging="grdAdmin_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%" AllowSorting="true">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Ref" HeaderStyle-Width="80px" HeaderStyle-Height="20px" SortExpression="Reference">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblisissue" runat="server" Text='<%#Eval("IsIssue") %>' Style="display: none"></asp:Label>
                                                                <%#Eval("Reference") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Partner Ref" HeaderStyle-Width="80px" HeaderStyle-Height="20px" SortExpression="Partner">
                                                            <ItemTemplate>
                                                                <%#Eval("Partner") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Created" HeaderStyle-Width="219px" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <%#Eval("Created")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Modify Date" HeaderStyle-Width="219px" SortExpression="Last_Modified">
                                                            <ItemTemplate>
                                                                <%#Eval("ModifiedDate")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Owner Contact" HeaderStyle-Width="219px" SortExpression="OwnerContactDateSortable">
                                                            <ItemTemplate>
                                                                <%#Eval("OwnerContactDate")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Region" HeaderStyle-Width="160px" SortExpression="Area">
                                                            <ItemTemplate>
                                                                <%#Eval("Area")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Town" HeaderStyle-Width="450px" SortExpression="Town">
                                                            <ItemTemplate>
                                                                <%#Eval("Town")%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bed" SortExpression="Beds">
                                                            <ItemTemplate>
                                                                <%#Eval("Beds")%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bth" SortExpression="Baths">
                                                            <ItemTemplate>
                                                                <%#Eval("Baths")%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="250px" SortExpression="Status">
                                                            <ItemTemplate>
                                                                <%#Eval("Status")%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Price" HeaderStyle-Width="219px" SortExpression="public_price">
                                                            <ItemTemplate>
                                                                <%#Eval("Price")%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Key" SortExpression="door_key">
                                                            <ItemTemplate>
                                                                <%# IIf(Eval("door_key")=1," <img src='/Images/Icons/door_key.png'  style='width:40px'/>" ,"")%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Views" SortExpression="Views">
                                                            <ItemTemplate>
                                                                <%#Eval("Views")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Toured" SortExpression="Toured">
                                                            <ItemTemplate>
                                                               <asp:Label ID="lblIsTour" runat="server" Text='<%#Eval("Toured") %>' Style="display: none"></asp:Label>
                                                                <asp:Label ID="lblIsEightWeeks" runat="server" Text='<%#Eval("IsEightWeeks") %>' Style="display: none"></asp:Label>
                                                                <asp:Label ID="lblIsEightWeeksFeatured" runat="server" Text='<%#Eval("IsEightWeeksFeatured") %>' Style="display: none"></asp:Label>
                                                                <asp:Label ID="lblIsFeatured" runat="server" Text='<%#Eval("IsFeatured") %>' Style="display: none"></asp:Label>
                                                                <asp:Label ID="lblIsExpired" runat="server" Text='<%#Eval("IsExpired") %>' Style="display: none"></asp:Label>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>' Style="display: none"></asp:Label>
                                                                <%#Eval("Toured")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--  <asp:TemplateField HeaderText="Add property" HeaderStyle-Width="219px">
                                                    <ItemTemplate>
                                         <asp:LinkButton ID="lblproperty" runat="server" CommandArgument='<%#Eval("contact_id") %>'  CommandName="Addprop"  Text="Add Property" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                                        <%--     <asp:TemplateField HeaderText="Status" HeaderStyle-Width="219px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBtnStatus" CommandName="changestatus" CommandArgument='<%#Eval("contact_id")%>'
                                                            ToolTip="Click to change status. !!!" ImageUrl='<%#Eval("Status")%>' runat="server"
                                                            OnClientClick="javascript:return confirm('Are you sure you want to make this change !');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="View" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgView" runat="server" CommandArgument='<%#Eval("property_id") %>' ToolTip="Click to edit or view this property " CommandName="editadmin" ImageUrl="~/AdminNew/images/view-img.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="hvrexlude" />
                                                </asp:GridView>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>

                                    </table>

                                    <div align="right">
                                        <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Text="No Record Found!" Visible="false"></asp:Label>
                                        <asp:Button ID="BtnDelete" runat="server" class="btn green" Text="Delete" Style="display: none" Visible="false" OnClick="BtnDelete_Click"
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

