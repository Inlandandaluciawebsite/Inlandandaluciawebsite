<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Novideos.aspx.vb" Inherits="Admin_Novideos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
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
   <%-- <h3 class="page-title">Properties With No Videos
    </h3>--%>
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
                    <div class="caption">Properties With No Videos </div>
                    <div  align="right" >    <a class="btn green mrgtp" href="javascript:window.history.back();" role="button" >

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
 <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                          </div>
                </div>
                <div class="portlet-body">
                    <div id="Div1" class="dataTables_wrapper no-footer">
                      
                       
                        <div class="table-scrollable">
                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="Table1" role="grid" aria-describedby="sample_1_info">
                                <thead>
                                    <tr role="row" style="border: 1px solid #ddd">
                                        <asp:HiddenField ID="hdnBuyerId" runat="server" />
                                                <asp:GridView ID="grdNoVideosProperties" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="Property_ID" AllowPaging="True" AllowSorting="true" PageSize="15" OnRowCommand="grdNoVideosProperties_RowCommand"  OnPageIndexChanging="grdNoVideosProperties_PageIndexChanging" OnSorting="grdNoVideosProperties_Sorting" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50" OnRowDataBound="grdNoVideosProperties_RowDataBound" >
                                                    <Columns>
                                                           <asp:TemplateField HeaderText="View" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblisissue" runat="server"  Text='<%#Eval("IsIssue") %>' style="display:none"></asp:Label>
                                                      
                                                        <asp:linkButton ID="imgView" runat="server" Text="Select" CommandArgument='<%#Eval("Property_ID") %>' ToolTip="Click to edit or view this property " CommandName="editadmin"  />
                                                    </ItemTemplate>
                                                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px"  ForeColor="White"/>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Property Ref" SortExpression="Property_Ref">
                                                            <ItemTemplate>
                                                                <%#Eval("Property_Ref")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Create Date" SortExpression="Create_Date">
                                                            <ItemTemplate>
                                                                <%#Eval("Create_Date") %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Modified" SortExpression="Last_Modified">
                                                            <ItemTemplate>
                                                                <%#Eval("Last_Modified")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Door Key" SortExpression="Door_Key">
                                                            <ItemTemplate>
                                                                <%#Eval("Door_Key")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Region/Town" SortExpression="regiontext">
                                                            <ItemTemplate>
                                                                <%#Eval("regiontext")%></span>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Property Address" SortExpression="Property_Address">
                                                            <ItemTemplate>
                                                                <%#Eval("Property_Address")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Vendor" SortExpression="Vendor">
                                                            <ItemTemplate>
                                                                <%#Eval("Vendor")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="300px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Photos" ItemStyle-HorizontalAlign="Center" SortExpression="Num_Photos">
                                                            <ItemTemplate>
                                                                <%#Eval("Num_Photos")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle HorizontalAlign="Center"  CssClass="hvrexlude"/>
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

