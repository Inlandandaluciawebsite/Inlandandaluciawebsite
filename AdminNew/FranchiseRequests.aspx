<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="FranchiseRequests.aspx.vb" Inherits="FranchiseRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //function SelectAll(id) {
        //    var k = document.getElementsByClassName("clsinp");
        //    alert(k);
        //    alert(id);
        //    alert(k.length);
        //    for (var i = 0; i < k.length; i++) {
        //        if (k[i].type == "checkbox") {
        //            if (id.checked) {
        //                k[i].checked = true;
        //            }
        //            else {
        //                k[i].checked = false;
        //            }
        //        }
        //    }
        //}
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
    <style type="text/css">
        .form-outer {
            background-color: #303194;
            color: white;
            max-width: 700px;
            min-height: 700px;
            padding: 50px;
            margin: 50px auto;
        }

        .popup_wrapper {
            color: white;
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
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
            <h3 class="page-title"></h3>
            <%-- <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="Index.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="ManageAgents.aspx">Manage Agents </a>
            </li>
        </ul>
    </div>--%>

            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">Franchise Requests </div>
                            <div align="right" class="right">
                                <asp:Button ID="btnAddFranchise" runat="server" Text="Add New Request" CssClass="btn green mrgtp" OnClick="btnAddFranchise_Click" />&nbsp;&nbsp;
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
                                            <asp:TextBox ID="txtContactName" runat="server" class="form-control srchvend" placeholder="Search By Contact Name OR Email.." aria-controls="sample_1" Style="width: 350px;" />
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-4">
                                        <div class="row">
                                            <div class="col-md-6"><asp:DropDownList ID="drpSource" runat="server" CssClass="form-control" Style="width: 150px !important;"></asp:DropDownList></div>
                                            <div class="col-md-6"><asp:DropDownList ID="drpStatus" runat="server" CssClass="form-control" Style="width: 177px !important;"></asp:DropDownList></div>
                                        </div>
                                        
                                        
                                    </div>
                                    <div class="col-md-4 col-sm-4">
                                        <asp:Button ID="imgsearch" OnClick="imgsearch_Click" ToolTip="click here to search by Name ..!!" runat="server" class="btn green srchvendsrch" Text="Search"></asp:Button>
                                    </div>
                                </div>
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView ID="grdAdmin" DataKeyNames="Contact_Id" OnRowDataBound="grdAdmin_RowDataBound1" AllowPaging="true" AllowSorting="true" PageSize="10" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnRowCommand="grdAdmin_RowCommand" OnPageIndexChanging="grdAdmin_PageIndexChanging" OnSorting="grdAdmin_Sorting" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thwdth">
                                                            <HeaderTemplate>
                                                                <input type="checkbox" onclick="SelectAll(this);" class="clsinp" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" class="clsinp" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name" HeaderStyle-Width="150px" HeaderStyle-Height="20px" SortExpression="Contact_Name">
                                                            <ItemTemplate>
                                                                <%#Eval("Contact_Name") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="100px" SortExpression="Contact_Email">
                                                            <ItemTemplate>
                                                                <%#Eval("Contact_Email")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Telephone" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <%#Eval("Contact_Telephone")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address" HeaderStyle-Width="210px">
                                                            <ItemTemplate>
                                                                <%#Eval("Contact_Address")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Created" HeaderStyle-Width="210px" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <%#Eval("Create_Date")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="250px">
                                                            <ItemTemplate>
                                                                <%#Eval("Contact_Notes")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Approve ?" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgIsFranchise" runat="server" ImageUrl='<%#Eval("IsActive") %>' CommandName="IsFranchise" CommandArgument='<%#Eval("Contact_Id") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View" HeaderStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgView" runat="server" CommandArgument='<%#Eval("Contact_Id") %>' ToolTip="Click to edit or view this franchise request " CommandName="editfranchise" ImageUrl="~/Admin/images/view-img.png" />
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
            <div class="popup_wrapper" visible="false" runat="server" id="divAddFranchiseRequest">
                <div class="form-outer">
                    <div class="form-bg form-horizontal">
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-2 control-label">
                                <asp:Literal ID="Literal8" Text="<%$Resources:Resource, ContactUsfname%>" runat="server"></asp:Literal></label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="txtFirstName" runat="server" class="form-control widthcontact"></asp:TextBox>
                                <span class="contactspn">*</span>
                                <asp:RequiredFieldValidator ID="rpfirstname" runat="server" ErrorMessage="<%$Resources:Resource, Validationfirstname%>" ForeColor="Red" ControlToValidate="txtFirstName" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-2 control-label">
                                <asp:Literal ID="Literal9" Text="<%$Resources:Resource, ContactUslastname%>" runat="server"></asp:Literal></label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtLastName" runat="server" class="form-control widthcontact"></asp:TextBox>

                                <span class="contactspn">*</span>
                                <asp:RequiredFieldValidator ID="rplastname" runat="server" ErrorMessage="<%$Resources:Resource, Validationlastname%>" ForeColor="Red" ControlToValidate="txtLastName" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-2 control-label">
                                <asp:Literal ID="Literal10" Text="<%$Resources:Resource, ContactUsaddress%>" runat="server"></asp:Literal></label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtAddress" runat="server" class="form-control widthcontact"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-2 control-label">
                                <asp:Literal ID="Literal11" Text="<%$Resources:Resource, ContactUstelephone%>" runat="server"></asp:Literal></label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="txtTelephone" runat="server" class="form-control widthcontact"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-2 control-label">
                                <asp:Literal ID="Literal12" Text="<%$Resources:Resource, ContactUsemail%>" runat="server"></asp:Literal></label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="txtEmail" runat="server" class="form-control widthcontact"></asp:TextBox>
                                <span class="contactspn">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$Resources:Resource, Validationemail%>" ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rpemail" runat="server" ControlToValidate="txtEmail" ErrorMessage="<%$Resources:Resource, Validationemailvalid%>" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="Group1"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-2 control-label">
                                <asp:Literal ID="Literal1" Text="<%$Resources:Resource, ContactUscomments%>" runat="server"></asp:Literal></label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" class="form-control widthcontact" Rows="8"></asp:TextBox>
                                <span class="contactspn">*</span>
                                <asp:RequiredFieldValidator ID="rpcomment" runat="server" ErrorMessage="<%$Resources:Resource, Validationcomment%>" ForeColor="Red" ControlToValidate="txtComment" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                <asp:Label ID="LabelComment" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-10 col-sm-offset-2">
                            <p>
                                * =
                                            <asp:Literal ID="Literal14" Text="<%$Resources:Resource, ContactUsmandatoryfield%>" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSendMessage" runat="server" class="btn btn-default but-sub" Text="Submit" OnClick="btnSendMessage_Click" ValidationGroup="Group1" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" class="btn btn-default but-sub" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
