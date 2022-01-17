<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="OnlineMagazine.aspx.vb" Inherits="ManagePartner" %>

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
                 if ($("#ContentPlaceHolder1_grdmagazine input:checkbox:checked").length > 0) {
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
                    Height="40" ImageUrl="images/ajaxloading.gif"  />
                                </div>
                   
                </ProgressTemplate>
            </asp:UpdateProgress>
    <h3 class="page-title">
    </h3>
   <%-- <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="Index.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="ManagePartner.aspx">Manage Partner </a>

            </li>

        </ul>
  
    </div>--%>

    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN EXAMPLE TABLE PORTLET-->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">Manage Online Magazine </div>
                 <%-- <div  align="right" class="right">    <a class="btn green mrgtp" href="javascript:window.history.back();" role="button" >

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
 <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                          </div>--%>
                </div>
                <div class="portlet-body">
                    <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                      
               

                        <div class="table-scrollable">
                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                <thead>
                                    <tr role="row" style="border: 1px solid #ddd">
                                         <asp:GridView ID="grdmagazine" DataKeyNames="MId" AllowPaging="true" PageSize="10"  OnRowCommand="grdmagazine_RowCommand" Font-Names="Open Sans, sans-serif"  HeaderStyle-Height="20px" BorderColor="#dddddd" OnPageIndexChanging="grdmagazine_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thwdth" >
                                                            <HeaderTemplate>
                                                                <input type="checkbox" onclick="SelectAll(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField  HeaderText="EmbedCode" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                                                            <ItemTemplate>
                                                                <%#System.Web.HttpUtility.HtmlEncode(Eval("EmbedCode"))%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                        </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Archived" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center"  >
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnStatus" CommandName="changestatus" CommandArgument='<%#Eval("MId")%>' BorderStyle="None"
                                                                    ToolTip="Click to change status. !!!" ImageUrl='<%#Eval("IsActive1")%>' runat="server"
                                                                    OnClientClick="javascript:return confirm('Are you sure you want to make this change !');" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="View" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White"   HeaderStyle-HorizontalAlign="Center"  >
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgView" runat="server" BorderStyle="None" CommandArgument='<%#Eval("MID")%>' ToolTip="Click to edit or view this admin " CommandName="editmagazine" ImageUrl="images/view-img.png" />                                                            </ItemTemplate>
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
