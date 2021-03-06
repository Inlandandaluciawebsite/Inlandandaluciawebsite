<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ActionAgenda.aspx.vb" Inherits="Admin_ActionAgenda" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#imgDateFrom").click(function () {
                $("#ContentPlaceHolder1_txtActionDate").focus();
            })
            $("#ContentPlaceHolder1_txtActionDate").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
                timeFormat: "HH:mm",
            });
            if (document.getElementById('ContentPlaceHolder1_txtDescription') != null) {
                limitText()
            }
        })
        function changeDateControl() {
            $("#ContentPlaceHolder1_imgDateFrom").click(function () {
                $("#txtActionDate").focus();
            })
            $("#ContentPlaceHolder1_txtActionDate").datepicker({
                altField: "#alternate",
                altFormat: "MM/dd/yyyy",
                dateFormat: "mm-dd-yy",
                timeFormat: "HH:mm",
            });
        }
        function SetProgressPosition(e) {
            var posx = 0;
            var posy = 0;
            if (!e) var e = window.event;
            if (e.pageX || e.pageY) {
                posx = e.pageX;
                posy = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                posx = e.clientX + document.documentElement.scrollLeft;
                posy = e.clientY + document.documentElement.scrollTop;
            }
            document.getElementById('divProgress').style.left = posx - 8 + "px";
            document.getElementById('divProgress').style.top = posy - 8 + "px";
        }
        function limitText() {
            var limitField = document.getElementById('ContentPlaceHolder1_txtDescription').value;
            var limitCount = document.getElementById('countdown').value;
            if (limitField.length > 1500) {
                document.getElementById('ContentPlaceHolder1_txtDescription').value = limitField.substring(0, 1500);
            }
            else {
                document.getElementById('countdown').value = 1500 - limitField.length;
            }
        }
        //function scrollToBottom() {
        //    $('html,body').animate({ scrollTop: 9999 }, 'slow');
        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upAddAdmin" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="upAddAdmin"
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
            <asp:Label ID="LabelContactID" runat="server" Visible="false"></asp:Label>
            <%-- <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AddAgent.aspx">Add Agent</a>
                    </li>
                </ul>
            </div>--%>
            <!-- /.modal -->
            <!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->
            <!-- BEGIN STYLE CUSTOMIZER -->

            <!-- END STYLE CUSTOMIZER -->
            <!-- BEGIN PAGE HEADER-->

            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row">
                <div class="col-md-12">
                    <div class="tabbable tabbable-custom boxless tabbable-reversed">
                        <ul class="nav nav-tabs">
                            <li class="active"></li>
                            <li></li>
                            <li></li>
                            <li></li>
                            <li></li>
                            <li></li>
                            <li></li>
                            <li></li>
                        </ul>
                        <div class="tab-pane" id="tab_2">
                            <div class="portlet box green">
                                <div class="portlet-title">
                                    <div class="caption">
                                        Action Agenda
                                    </div>
                                    <div align="right">
                                        <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">
                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                            <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal>
                                        </a>
                                    </div>
                                </div>

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <%--  <form action="#" class="form-horizontal">--%>
                                    <div class="form-body">
                                        <h3 class="form-section"></h3>
                                        <!--/row-->
                                        <!--/row-->
                                        <div class="table-scrollable" style="border: 0px !important;">
                                            <asp:DropDownList ID="drpActionAgendaType" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="drpActionAgendaType_SelectedIndexChanged">
                                                <asp:ListItem Text="Standard Client" Value="Buyer"></asp:ListItem>
                                                <asp:ListItem Text="Franchise Client" Value="Franchise"></asp:ListItem>
                                                <asp:ListItem Text="Partner" Value="Partner"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <!--/row-->
                                        <div class="table-scrollable">
                                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                                <thead>
                                                    <tr role="row" style="border: 1px solid #ddd">
                                                        <asp:HiddenField ID="hdnBuyerId" runat="server" />
                                                        <asp:GridView ID="grdBuyerActionAgenda" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            DataKeyNames="History_ID" AllowPaging="True" AllowSorting="true" PageSize="15" OnPageIndexChanging="grdBuyerActionAgenda_PageIndexChanging" OnSorting="grdBuyerActionAgenda_Sorting" OnRowCommand="grdBuyerActionAgenda_RowCommand" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>">
                                                                            <asp:LinkButton ID="lnkSelectBuyerHistory" runat="server" ToolTip="Click to edit or view this Buyer. !!!" CommandArgument='<%#Eval("History_ID") %>' CommandName="EditBuyer" Text="Select"></asp:LinkButton></span>

                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date" SortExpression="Create_Date">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Create_Date")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action Date" SortExpression="Action_Date">

                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Action_Date")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText=" Buyer ForeName" SortExpression="Buyer_Forename">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Buyer_Forename")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Buyer Surname" SortExpression="Buyer_Surname">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Buyer_Surname")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Buyer Status" SortExpression="Status">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Status")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="User" ItemStyle-HorizontalAlign="Center" SortExpression="User">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("User")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="400px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px"></ItemStyle>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Action Status" ItemStyle-HorizontalAlign="Center" SortExpression="Action_Status">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Action_Status")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="400px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle HorizontalAlign="Center" />
                                                            <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                            <RowStyle CssClass="GridItemStyle" />
                                                            <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                        </asp:GridView>
                                                        <asp:HiddenField ID="hdnFranchiseId" runat="server" />
                                                        <asp:GridView ID="grdFranchiseActionAgenda" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            DataKeyNames="History_ID" AllowPaging="True" AllowSorting="true" PageSize="15" OnPageIndexChanging="grdFranchiseActionAgenda_PageIndexChanging" OnSorting="grdFranchiseActionAgenda_Sorting" OnRowCommand="grdFranchiseActionAgenda_RowCommand" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>">
                                                                            <asp:LinkButton ID="lnkSelectBuyerHistory" runat="server" ToolTip="Click to edit or view this Buyer. !!!" CommandArgument='<%#Eval("History_ID") %>' CommandName="EditFranchise" Text="Select"></asp:LinkButton></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date" SortExpression="Create_Date">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Create_Date")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action Date" SortExpression="Action_Date">

                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Action_Date")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Franchise" SortExpression="Franchise_Name">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Franchise_Name")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Buyer Status" SortExpression="Status">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("Status")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="User" ItemStyle-HorizontalAlign="Center" SortExpression="User">
                                                                    <ItemTemplate>
                                                                        <span style="color: <%#Eval("color")%>"><%#Eval("User")%></span>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="400px" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px"></ItemStyle>
                                                                </asp:TemplateField>
                                                               
                                                            </Columns>
                                                            <PagerStyle HorizontalAlign="Center" />
                                                            <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                            <RowStyle CssClass="GridItemStyle" />
                                                            <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                        </asp:GridView>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                </tbody>
                                            </table>
                                            <div id="actionDetails" runat="server" visible="false">
                                                <div class="form-inline">
                                                    <div class="form-group">
                                                        <label for="exampleInputName2">User</label>
                                                        <asp:DropDownList ID="drpAgents" runat="server" CssClass="form-control" Width="135"></asp:DropDownList>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail2">Client Status</label>
                                                        <asp:DropDownList ID="drpStatus" runat="server" Width="131" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail2">Action Date</label>
                                                        <asp:TextBox ID="txtActionDate" runat="server" Text="" Width="150" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                                        <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateFrom" alt="calender" style="cursor: pointer;" onclick="javascript:document.getElementById('txtActionDate').click();" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail2">Action Status</label>
                                                        <asp:DropDownList ID="drpActionStatus" runat="server" Width="137" CssClass="form-control">
                                                            <asp:ListItem Text="Open" Value="Open"></asp:ListItem>
                                                            <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                                                            <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                                            <asp:ListItem Text="Information Only" Value="Information Only"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Button ID="btnClientHistoryUpdate" runat="server" Text="Save" Style="display: none; margin-bottom: 10px !important;" CssClass="btn green" OnClick="btnClientHistoryUpdate_Click" />
                                                        <asp:Button ID="btnClientHistorySave" runat="server" Text="Save" Style="margin-bottom: 10px !important;" OnClick="btnClientHistorySave_Click" CssClass="btn green" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="col-md-12">
                                                                <asp:TextBox ID="txtDescription" runat="server" Text="" TextMode="MultiLine" CssClass="form-control" MaxLength="1500" name="txtDescription" onKeyDown="limitText();"
                                                                    onKeyUp="limitText();" Rows="10"></asp:TextBox>
                                                                <font size="2">(Maximum characters: 1500)<br>
                                                    You have
                                                    <input readonly type="text" id="countdown" name="countdown" size="3" value="1500">
                                                    characters left.</font>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="trGridtitle" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <h1>
                                                                <asp:Label ID="lblGridTitle" runat="server" Text="Client List"></asp:Label></h1>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <%-- propery --%>
                                        </div>

                                        <%--</form>--%>
                                        <!-- END FORM-->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END CONTENT -->
                    <!-- BEGIN QUICK SIDEBAR -->
                    <!-- END QUICK SIDEBAR -->
                    <!-- END CONTAINER -->
                    <!-- BEGIN FOOTER -->
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>

