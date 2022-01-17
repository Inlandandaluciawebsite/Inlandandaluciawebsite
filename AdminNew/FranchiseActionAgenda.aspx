<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="FranchiseActionAgenda.aspx.vb" Inherits="Admin_FranchiseActionAgenda" %>

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
        })
        function changeDateControl() {
            $("#imgDateFrom").click(function () {
                $("#ContentPlaceHolder1_txtActionDate").focus();
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
            } else {
                document.getElementById('countdown').value = 1500 - limitField.length;
            }
        }
        //        function scrollToBottom() {
        //    $('html,body').animate({ scrollTop: 9999 }, 'slow');
        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="manageAdmins" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="manageAdmins"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="overlay" id="divProgress">
                        &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="50"
                    Height="40" ImageUrl="images/ajaxloading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
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
                            <div class="caption">Action Agenda </div>
                            <div align="right">
                                <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">

                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>

                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView ID="grdActionAgenda" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="History_ID" AllowPaging="True" AllowSorting="true" PageSize="15" OnPageIndexChanging="grdActionAgenda_PageIndexChanging" OnSorting="grdActionAgenda_Sorting" OnRowCommand="grdActionAgenda_RowCommand" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>">
                                                                    <asp:LinkButton ID="lnkSelectFranchiseHistory" runat="server" ToolTip="Click to edit or view this Franchise. !!!" CommandArgument='<%#Eval("History_ID") %>' CommandName="EditFranchise" Text="Select"></asp:LinkButton></span>

                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Create_Date")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action Date" SortExpression="Action_Date">

                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Action_Date")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Franchise" SortExpression="Franchise_Name">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Franchise_Name")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                        </asp:TemplateField>
<%--                                                        <asp:TemplateField HeaderText="Franchise Surname" SortExpression="Franchise_Surname">
                                                            <ItemTemplate>
                                                                <span style="color: <%#Eval("color")%>"><%#Eval("Franchise_Surname")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Franchise Status" SortExpression="Status">
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
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"></ItemStyle>
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


                                </div>


                                <div class="form-inline">
                                    <div class="form-group">
                                        <label for="exampleInputName2">User</label>
                                        <asp:DropDownList ID="drpAgents" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail2">Status</label>
                                        <asp:DropDownList ID="drpFranchiseStatus" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail2">Action Date</label>
                                        <asp:TextBox ID="txtActionDate" runat="server" Text="" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                        <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateFrom" alt="calender" style="cursor: pointer;" onclick="javascript:document.getElementById('txtActionDate').click();" />
                                    </div>
                                    <asp:Button ID="btnClientHistorySave" runat="server" Text="Save" OnClick="btnClientHistorySave_Click" CssClass="btn green" />
                                    <asp:Button ID="btnClientHistoryUpdate" runat="server" Text="Save" CssClass="btn green" OnClick="btnClientHistoryUpdate_Click" Style="display: none;" />
                                </div>


                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtDescription" runat="server" Text="" TextMode="MultiLine" CssClass="form-control" Rows="10" MaxLength="1500" name="txtDescription" onKeyDown="limitText();"
                                            onKeyUp="limitText();"></asp:TextBox><font size="2">(Maximum characters: 1500)<br>
                                                    You have
                                                    <input readonly type="text" id="countdown" name="countdown" size="3"    value="1500">
                                                    characters left.</font>
                                    </div>
                                </div>
                                <div class="row" id="trGridtitle" runat="server" visible="false">
                                    <div class="col-md-12">
                                        <h1>
                                            <asp:Label ID="lblGridTitle" runat="server" Text="Client List"></asp:Label></h1>
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

