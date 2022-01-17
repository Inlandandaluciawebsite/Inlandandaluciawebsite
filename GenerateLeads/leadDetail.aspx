<%@ Page Title="" Language="C#" MasterPageFile="~/GenerateLeads/Genratedlead.master" AutoEventWireup="true" CodeFile="leadDetail.aspx.cs" Inherits="GenerateLeads_leadDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/Validation.js"></script>
        <script type="text/javascript" lang="javascript">
            function Validations() {
                var IsError = '';
                var invalid = " "; // Invalid character is a space
                IsError += ValidateRequiredField(document.getElementById('<%=txtmessage.ClientID%>'), "Please enter message!");

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
    <div class="page-container">
    <!-- BEGIN SIDEBAR -->
  
    <!-- END SIDEBAR -->
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <!-- BEGIN CONTENT BODY -->
        <div class="page-content" style="min-height:275px"><div class="row">
    <div class="col-sm-12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet light bordered">
            <div class="portlet-title">
                <div class="caption font-red-sunglo">
                    <i class="fa fa-envelope font-red-sunglo"></i>
                    <span class="caption-subject bold uppercase"> Lead Messages</span>
                </div>
                <div class="actions">
                    <a href="javascript:history.back();" class="btn blue pull-right"><i class="fa fa-arrow-left"></i> Back to leads</a>
                </div>
            </div>
            <div class="portlet-body form">
            
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-body sale-summary">
                                <asp:HiddenField ID="hdndataid" runat="server" />
                        <ul class="list-unstyled">
                           
                            <li>
                                <b>Contact Email : </b><br/><asp:Literal ID="ltconteactemail" runat="server" ></asp:Literal>
                            </li>
                            <li>
                                <b>Telephone : </b><br/><asp:Literal ID="lttele" runat="server" ></asp:Literal>
                            </li>
                        </ul>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-body sale-summary">
                               <ul class="list-unstyled">
                            <li>
                                <b>Customer Name : </b><br/><asp:Literal ID="ltcosname" runat="server" ></asp:Literal>                       </li>
                            <li>
                                                  </li>
                            <li>
                                <b>City / State : </b><br/><asp:Literal ID="ltcity" runat="server" ></asp:Literal> / <asp:Literal ID="ltstate" runat="server" ></asp:Literal>                         </li>
                        </ul>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label for="message"><b>Message : </b></label>
                                <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine"  placeholder="Enter message here" class="form-control"></asp:TextBox>
                              
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnsubmit" runat="server" class="btn blue" Text="Add Message"  OnClick="btnsubmit_Click" OnClientClick="return Validations();"/>
                                
                            </div>
                        </div>
                    </div>
                                        <hr>
                <asp:Repeater ID="rpmessge" runat="server">

                    <ItemTemplate>
                               <div class="row">
                        <div class="col-sm-8">
                                                        <div class="message">
                                <p><b>Posted at : </b><%#Eval("Date") %></p>
                                <p><%#Eval("Message") %></p>
                            </div>
                            <hr>
                                                    </div>
                    </div>
                    </ItemTemplate>
                </asp:Repeater>
             
                                  
            </div>
        </div>
    </div>
</div></div>
<!-- END CONTENT BODY -->
</div>
<!-- END CONTENT -->       
</div>
 </ContentTemplate> 

          </asp:UpdatePanel> 
</asp:Content>

