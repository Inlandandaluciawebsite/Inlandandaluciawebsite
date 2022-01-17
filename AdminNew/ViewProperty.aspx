<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ViewProperty.aspx.vb" Inherits="Admin_ManageVendors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    

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
                    Height="40" ImageUrl="images/ajaxloading.gif"  />
                                </div>
                   
                </ProgressTemplate>
            </asp:UpdateProgress>
    <h3 class="page-title">Vendor Properties 
    </h3>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="Index.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
               <%-- <a href="ManageVendors.aspx">Manage Vendors </a>--%>

            </li>

        </ul>
  
    </div>

    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN EXAMPLE TABLE PORTLET-->
            <div class="portlet box blue-hoki">
                <div class="portlet-title">
                    <div class="caption"> Properties </div>
                    <div class="tools"></div>
                </div>
                <div class="portlet-body">
                    <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                        <asp:Button ID="btnimageprop" runat="server" Text="Add Property" class="btn green" OnClick="btnimageprop_Click" ></asp:Button>
                    

                        <div class="table-scrollable">
                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                <thead>
                                    <tr role="row" style="border: 1px solid #ddd">
                                        <asp:GridView ID="grdAdmin" DataKeyNames="id" OnRowDataBound="grdAdmin_RowDataBound1" AllowPaging="true" PageSize="10" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnRowCommand="grdAdmin_RowCommand" OnPageIndexChanging="grdAdmin_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">

                                            <Columns>
                                                
                                             <%--   <asp:TemplateField HeaderText="Select" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                    <ItemTemplate>
                                                      <asp:LinkButton ID="lblprop" PostBackUrl="AddProperty.aspx?<%#Eval("id")%>" Text="Select" runat="server"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                              
                                                <asp:TemplateField HeaderText="Reference" HeaderStyle-Width="219px">
                                                    <ItemTemplate>
                                                        <%#Eval("Reference")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                              <asp:TemplateField HeaderText="View" HeaderStyle-Width="219px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgView" runat="server" CommandArgument='<%#Eval("id") %>' ToolTip="Click to edit or view this property " CommandName="editadmin" ImageUrl="~/Admin/images/view-img.png" />
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
