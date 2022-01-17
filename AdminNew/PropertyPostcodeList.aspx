<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="PropertyPostcodeList.aspx.vb" Inherits="PropertyPostcodeList" %>

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
            <h3 class="page-title"></h3>
            <%-- <div class="page-bar">
<ul class="page-breadcrumb">
<li>
<i class="fa fa-home"></i>
<a href="Index.aspx">Home</a>
<i class="fa fa-angle-right"></i>
</li>
<li>
<a href="ManageBrokers.aspx">Manage Brokers </a>
</li>
</ul> 
</div>--%>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">Manage Postcode Coordinates </div>
                            <div align="right" class="right">
                                <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">

                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">

                                <div class="row">
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpRegion" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpRegion_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpArea" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpPartner" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:DropDownList ID="drpListType" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="---All---" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Duplicate Coordinates" Value="1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:Button ID="imgsearch" OnClick="imgsearch_Click1" ToolTip="click here to search by Name and Archived ..!!" runat="server" class="btn green srchvendsrch" Text="Search"></asp:Button>
                                    </div>
                                </div>

                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView ID="grdAdmin" DataKeyNames="Postcode_Id" AllowPaging="true" PageSize="20" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnRowCommand="grdAdmin_RowCommand" OnPageIndexChanging="grdAdmin_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%" AllowSorting="true" OnSorting="grdAdmin_Sorting">
                                                    <Columns>
                                                        <%--<asp:TemplateField HeaderText="" HeaderStyle-CssClass="thwdth">
                                                            <HeaderTemplate>
                                                                <input type="checkbox" onclick="SelectAll(this);" class="clsinp" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" class="clsinp" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Postcode Id" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("Postcode_Id") %>
                                                                <asp:HiddenField ID="hdnPostcode_Id" runat="server" Value='<%#Eval("Postcode_Id") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Postcode" HeaderStyle-Width="219px" HeaderStyle-Height="20px" SortExpression="Postcode">
                                                            <ItemTemplate>
                                                                <%#Eval("Postcode") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Region" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("Region") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Area" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("Area") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sub Area" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("Sub-Area") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Partner" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("Partner") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Entry Type" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("EntryType") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Latitude" HeaderStyle-Width="219px" HeaderStyle-Height="20px" SortExpression="GPS_Latitude_02">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtLatitude" Width="100" runat="server" Text='<%#Eval("GPS_Latitude_02") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Longitude" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtLongitude" Width="100" runat="server" Text='<%#Eval("GPS_Longitude_02") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Update" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnUpdate" ForeColor="White" BackColor="#303194" Text="Update" runat="server" ToolTip="Click to edit or update this postcode " CommandName="editpostcode" OnClientClick="return confirm('Are you sure you want to update this record ?')" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Check Coordinates" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%--<asp:Button ID="btnCheckCoordinates" ForeColor="White" BackColor="#303194" Text="Check on Map" runat="server" ToolTip="Click to check coordinates on map. " CommandName="checkcoordinates" CommandArgument='<%#Eval("Postcode_Id") %>' />--%>
                                                                <a href='https://developers-dot-devsite-v2-prod.appspot.com/maps/documentation/utils/geocoder#q%3D<%#Eval("GPS_Latitude_02") %>%252C<%#Eval("GPS_Longitude_02") %>' target="_blank" style="background-color:#303194; color:white;">Check on Map</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Check Query" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%--<asp:Button ID="btnCheckCoordinates" ForeColor="White" BackColor="#303194" Text="Check on Map" runat="server" ToolTip="Click to check coordinates on map. " CommandName="checkcoordinates" CommandArgument='<%#Eval("Postcode_Id") %>' />--%>
                                                                <a href='https://maps.googleapis.com/maps/api/geocode/xml?address=<%#Eval("Address") %>&components=country:ES&key=AIzaSyCwJpxFElMKO5iffzrYp1EH9ohb5lvyogU' target="_blank" style="background-color:#303194; color:white;">Check Query</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
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
