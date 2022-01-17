<%@ Page Title="" Language="C#" MasterPageFile="~/GenerateLeads/Genratedlead.master" AutoEventWireup="true" CodeFile="Lead.aspx.cs" Inherits="GenerateLeads_Lead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">

        function confirmDelete() {
            if (confirm("Are you sure? All lead data will be permanently deleted including messages!") == true)
                return true;
            else
                return false;
        }
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="manageAdmins"
                DisplayAfter="1">
                <ProgressTemplate>
                     <div class="overlay" id="divProgress">
                                    &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="80"
                    Height="80" ImageUrl="../Images/ajaxloading.gif"  />
                                </div>
                   
                </ProgressTemplate>
            </asp:UpdateProgress>
      <asp:UpdatePanel ID="manageAdmins" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
          
    <table>
        <tr>
            <td>&nbsp</td>
        </tr>
         <tr>
            <td>&nbsp</td>
        </tr>
       
    </table>
   
     <table>
        <tr>
            <td>&nbsp</td>
        </tr>
         <tr>
            <td>&nbsp</td>
        </tr>
       <tr>
           <td>
  <table class="table table-striped table-bordered table-hover dataTable no-footer"  style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <asp:GridView ID="grdAdmin"  AllowPaging="true" OnRowCommand="grdAdmin_RowCommand"  PageSize="50" Font-Names="Open Sans, sans-serif" class="mGrid" HeaderStyle-Height="20px" BorderColor="#dddddd" OnPageIndexChanging="grdAdmin_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">
                                                    <Columns>
                                                     
                                                        <asp:TemplateField HeaderText="Customer Name"  HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("CustomerName") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Email" >
                                                            <ItemTemplate>
                                                                <%#Eval("Email")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MobileNumber" >
                                                            <ItemTemplate>
                                                                <%#Eval("MobileNumber")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="City" >
                                                            <ItemTemplate>
                                                                <%#Eval("city")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="State" >
                                                            <ItemTemplate>
                                                                <%#Eval("state")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText=" Lead Date " >
                                                            <ItemTemplate>
                                                                <%#Eval("Date")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText=" Last Message " >
                                                            <ItemTemplate>
                                                                <%#Eval("lastmessage")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="">
                                                            <ItemTemplate>
                                                                <a class="btn blue" href='leadDetail.aspx?Id=<%#Eval("Date_Id") %>'> <i class="fa fa-envelope"></i> Messages</a>
                                                                <asp:LinkButton ID="lbldel" OnClientClick="return confirmDelete()" class="btn red" runat="server"  CommandArgument='<%#Eval("Date_Id") %>' CommandName="remove" ><i class="fa fa-trash"></i></asp:LinkButton>
                                                          </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>

           </td>
       </tr>

         <tr>
             <td>  <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Text="No Record Found!" Visible="false"></asp:Label></td>
         </tr>
    </table>
        
            </ContentTemplate> 

          </asp:UpdatePanel> 
    
            
</asp:Content>

