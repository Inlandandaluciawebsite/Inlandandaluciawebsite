<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="SalespersonTours.aspx.vb" Inherits="Admin_SalespersonTours" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script type="text/javascript">
            $(function () {
                $("#imgDateFrom").click(function () {
                    $("#ContentPlaceHolder1_txtDateFrom").focus();
                })
                $("#imgDateTo").click(function () {
                    $("#ContentPlaceHolder1_txtDateTo").focus();
                })
                $("#ContentPlaceHolder1_txtDateFrom").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                });

                $("#ContentPlaceHolder1_txtDateTo").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                });
            })
            function changeDateControl() {
                $("#imgDateFrom").click(function () {
                    $("#ContentPlaceHolder1_txtDateFrom").focus();
                })
                $("#imgDateTo").click(function () {
                    $("#ContentPlaceHolder1_txtDateTo").focus();
                })
                $("#ContentPlaceHolder1_txtDateFrom").datepicker({
                    altField: "#alternate",
                    altFormat: "MM/dd/yyyy",
                    dateFormat: "mm-dd-yy",
                    timeFormat: "HH:mm",
                });

                $("#ContentPlaceHolder1_txtDateTo").datepicker({
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <asp:UpdatePanel ID="manageAdmins" runat="server">
        <ContentTemplate>
               <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="manageAdmins"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="overlay" id="divProgress">
                                    &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="50"
                    Height="40" ImageUrl="images/ajaxloading.gif"  />
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
                    <div class="caption">  Salesperson Tours </div>
                     <div  align="right" >    <a class="btn green mrgtp" href="javascript:window.history.back();" role="button" >

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
 <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                          </div>
                </div>
                <div class="portlet-body">
                    <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                      
                <div class="form-inline">
  <div class="form-group">
    <label for="exampleInputName2">User</label>
    <asp:DropDownList ID="drpUsers" runat="server"  CssClass="form-control" >
                                                </asp:DropDownList>
  </div>
  <div class="form-group">
    <label for="exampleInputEmail2">Date Range Selection</label>
   <asp:TextBox ID="txtDateFrom" runat="server" Text="" placeholder="From" CssClass="form-control"></asp:TextBox>
       <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateFrom" style="cursor: pointer;" onclick="javascript:document.getElementById('txtDateFrom').click();" />
  </div>
                      <div class="form-group">
    
     <asp:TextBox ID="txtDateTo" runat="server" Text="" placeholder="To" CssClass="form-control"></asp:TextBox>
 <img src="../Images/Images/calendar.png" width="25" height="25" id="imgDateTo" style="cursor: pointer;" onclick="javascript:document.getElementById('txtDateTo').Click();" />
  </div>
</div>
                        <div class="form-inline">
  <div class="form-group">
    <label for="exampleInputName2"></label>
    <asp:Button ID="btnListByClient" runat="server" CssClass="btn green"  Text="List By Client" OnClick="btnListByClient_Click"  />

  </div>
  <div class="form-group">
 <asp:Button ID="btnListByProperty" runat="server" CssClass="btn green" Text="List By Property" OnClick="btnListByProperty_Click"  />
  </div>
                      </div>

                        <div class="table-scrollable">
                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                <thead>
                                     <tr id="trGridtitle" runat="server" visible="false">
                                            <td colspan="10">
                                                <h1>
                                                    <asp:Label ID="lblGridTitle" runat="server" Text="Client List"></asp:Label></h1>
                                            </td>
                                        </tr>
                                    <tr role="row" style="border: 1px solid #ddd">
                                         <asp:GridView ID="grdClientList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="tour_id" AllowPaging="True" AllowSorting="true" OnSorting="grdClientList_Sorting" PageSize="15" OnPageIndexChanging="grdClientList_PageIndexChanging" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="tour_datetime">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_datetime") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Forename" SortExpression="Buyerforename">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyerforename")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Surname" SortExpression="Buyersurname">
                                                            <ItemTemplate>
                                                                <%#Eval("Buyersurname")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Telephone" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerTelephone">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerTelephone")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerEmail">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerEmail")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="BuyerStatus">
                                                            <ItemTemplate>
                                                                <%#Eval("BuyerStatus")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="50px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="Grid_HeaderStyle" />
                                                    <RowStyle CssClass="GridItemStyle" />
                                                    <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                                </asp:GridView>
                                         
                                        

                                        
                                            
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblnorecord" runat="server"  Text="No Record Found!" Visible="false" ></asp:Label>
                                        </td>
                                    </tr>
                                     <tr role="row" style="border: 1px solid #ddd">
                                         <asp:GridView ID="grdPropertyList" runat="server" Visible="false" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="tour_id" AllowPaging="True" AllowSorting="true" OnSorting="grdPropertyList_Sorting" PageSize="15" OnPageIndexChanging="grdPropertyList_PageIndexChanging" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Property" SortExpression="PropertyRef" >
                                                            <ItemTemplate>
                                                                <%#Eval("PropertyRef")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="tour_datetime">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_datetime") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tour Id" SortExpression="tour_id">
                                                            <ItemTemplate>
                                                                <%#Eval("tour_id")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tour Feedback"  SortExpression="TourFeedback">
                                                            <ItemTemplate>
                                                                <%#Eval("TourFeedback") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="700px" />
                                                            <ItemStyle  VerticalAlign="Middle" Width="700px" />
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
                    
                    </div>
                </div>
            </div>



        </div>
    </div>
           </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

