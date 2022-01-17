<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="OnlineMagazineAddEdit.aspx.vb" Inherits="Admin_AddMagazine" ValidateRequest="false"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script type="text/javascript" lang="javascript">
          function Validations() {
              var IsError = '';
              var invalid = " "; // Invalid character is a space
              IsError += ValidateRequiredField(document.getElementById('<%=txtEmbedCode.ClientID%>'), "Please enter Embed code!");
              if (IsError.length > 0) {
                  alert(IsError);
                  return false;
              }
              return true;
          }

    </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="page-content-wrapper">
        <div class="page-content">--%>
    <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->

    <asp:UpdatePanel ID="updvendor" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

          <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="updvendor"
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
                <a href="AddMagazine.aspx">Add Magazine</a>

            </li>

        </ul>
  
    </div>--%>
    <!-- /.modal -->

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
                               Add/Edit Online Magazine
                            </div>
                        </div>

                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                            <div class="form-body" id="addprop" runat="server" style="display:block">
                                <h3 class="form-section"></h3>
                                <!--/row-->
                                <!--/row-->

                                <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">   Embed Code</label>
                                            <div class="col-md-9">
 <asp:TextBox ID="txtEmbedCode" runat="server" TextMode="MultiLine" Rows="6" Columns="53" Placeholder="Embed Code" class="form-control" CssClass="form-control"></asp:TextBox>                                          </div>
                                        </div>
                                    </div>
                                
                                </div>
                             
                                <!--/row-->
                            </div>
                            <div class="form-actions" id="addpropbtn" runat="server" style="display:block">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-offset-3 col-md-9">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn green" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none"  OnClientClick="return Validations();"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                            </div>
                      

                        <%--</form>--%>
                        <!-- END FORM-->


                        <%-- start form 2 --%>
                           <%--  <form action="#" class="form-horizontal">--%>
                          
                            
                           
                        </div>
                        </div>

                        <%--</form>--%>
                     
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--      </div>
    </div>
    --%>
    <!-- END CONTENT -->
    <!-- BEGIN QUICK SIDEBAR -->


    <!-- END QUICK SIDEBAR -->

    <!-- END CONTAINER -->
    <!-- BEGIN FOOTER -->
              </ContentTemplate>
     
    </asp:UpdatePanel>
</asp:Content>



