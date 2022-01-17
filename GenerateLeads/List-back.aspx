<%@ Page Title="" Language="C#" MasterPageFile="~/GenerateLeads/Genratedlead.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="GenerateLeads_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/Validation.js"></script>
        <script type="text/javascript" lang="javascript">
            function Validations() {
                var IsError = '';
                var invalid = " "; // Invalid character is a space
                IsError += ValidateDropdown(document.getElementById('<%=drpdate.ClientID%>'), "Please select date!");
           
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
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
    <table id="AdminPropertySearch1_TableFiltersResults" width="42%">
	<tbody><tr id="AdminPropertySearch1_TableRowFilters">
		<td>
            <asp:DropDownList ID="drpdate" runat="server" >
             

            </asp:DropDownList>
           



		</td>
        
        <td><select name="country" >
                                <option value="Spain">Spain</option>
                                                        
                            </select></td>
        
        <td>
                                 <asp:DropDownList ID="drpemail" runat="server" >
             
                                      <asp:ListItem Value="">Select Email Provider</asp:ListItem>
                                     <asp:ListItem Value="Gmail">Gmail</asp:ListItem>
                                     <asp:ListItem Value="Hotmail">Hotmail</asp:ListItem>
                                     <asp:ListItem Value="yahoo">Yahoo</asp:ListItem>
            </asp:DropDownList>
           
          


                                          </td>
        <td>

            <asp:Button ID="btnsearch" runat="server"  Text="Search" OnClick="btnsearch_Click"  class="default-button" OnClientClick="return Validations();"/>
          

        </td>
      
	</tr>
   
</tbody></table>

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
                                                     
                                                        <asp:TemplateField HeaderText="Customer Name" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("CustomerName") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("Email")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MobileNumber" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("MobileNumber")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="city" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("city")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="state" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("state")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                           
                                                                <asp:LinkButton ID="lblgenlead" runat="server" CssClass='<%# Eval("IsLead").ToString() == "Gen" ? "btn yellow" : "btn blue" %>' CommandName='<%# Eval("IsLead").ToString() == "Gen" ? "leadgen" : "genlead" %>' CommandArgument='<%#Eval("DateId") %>'><i class="fa fa-plus"></i> <%# Eval("IsLead").ToString() == "Gen" ? "Lead" : "Genrate Lead" %> </asp:LinkButton>
                                                              
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
             <div id="myModal" class="modal fade mymodel"  tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog">
   
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
               
                    <h4 class="modal-title">Generate Lead</h4>
                </div>
                <div class="modal-body">

        <div class="row">
                <div class="col-sm-6">
                    <div class="form-body sale-summary">
                        <asp:HiddenField ID="hdndataid" runat="server" />
                        <ul class="list-unstyled">
                           
                            <li>
                                <b>Contact Email : </b><br><asp:Literal ID="ltconteactemail" runat="server" ></asp:Literal>
                            </li>
                            <li>
                                <b>Telephone : </b><br><asp:Literal ID="lttele" runat="server" ></asp:Literal>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-body sale-summary">
                        <ul class="list-unstyled">
                            <li>
                                <b>Customer Name : </b><br><asp:Literal ID="ltcosname" runat="server" ></asp:Literal>                       </li>
                            <li>
                                                  </li>
                            <li>
                                <b>City / State : </b><br><asp:Literal ID="ltcity" runat="server" ></asp:Literal> / <asp:Literal ID="ltstate" runat="server" ></asp:Literal>                         </li>
                        </ul>
                    </div>
                </div>
            </div>
<div class="row">
                <div class="col-sm-12">
                    <div class="form-group">
                        <label for="message"><b>Message : </b></label>
                        <input type="hidden" name="generate" value="1">
                        <input type="hidden" name="table" value="domain_info_2016_11_23">
                        <input type="hidden" name="id" value="75254">

                        <asp:TextBox ID="txtmessage" runat="server" placeholder="Enter message here" class="form-control "  TextMode="MultiLine" ></asp:TextBox>
                    
                    </div>
                </div>
            </div>

<div class="modal-footer">
       
   <asp:Button ID="btnsubmit" runat="server" class="btn blue" Text="Generate Lead"   OnClick="btnsubmit_Click" />
      <a class="btn btn-warning close-details pull-right" data-dismiss="modal" aria-label="Close" href="#" role="button"> Close  X </a>
     
    </div>
                </div>
<!--                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>-->
            </div>
        </div>
    </div>
            </ContentTemplate> 

          </asp:UpdatePanel> 
    
            
</asp:Content>

