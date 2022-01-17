﻿<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Copy of AddVendor.aspx.vb" Inherits="Admin_AddVendor" %>

<script runat="server">

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script type="text/javascript" lang="javascript">
       function Validations() {
           var IsError = '';
           var invalid = " "; // Invalid character is a space
           IsError += ValidateRequiredField(document.getElementById('<%=txtName.ClientID%>'), "Please enter name!");
          


            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
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
                    Height="40" ImageUrl="images/ajaxloading.gif"  />
                                </div>
                   
                </ProgressTemplate>
            </asp:UpdateProgress>
            <h3 class="page-title">Add Vendor
            </h3>
           <%-- <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AddVendor.aspx">Add Vendor</a>
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
                                        Add/Edit Vendor
                                    </div>
                                </div>
                             <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                            <div class="form-body">
                                <h3 class="form-section"></h3>
                                <!--/row-->
                                <!--/row-->

                                <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Type</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="drpType" runat="server"  CssClass="form-control" Enabled="false" >
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Name </label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtName" runat="server" Placeholder="Name" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Registration No</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtRegistrationNo" runat="server" Placeholder="Registration No" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/span-->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Address</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtAddress" runat="server" Placeholder="Address" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/span-->
                                </div>
                                       <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Telephone</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtTelephone" runat="server" Placeholder="Telephone" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Mobile </label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtMobile" runat="server" Placeholder="Mobile" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                       <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Fax</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtFax" runat="server" Placeholder="Fax" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Email </label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" class="form-control" ></asp:TextBox>
                                             <asp:Label ID="lblEmailMessage" runat="server" ForeColor="Green" Style="float: right;"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                           <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Notes </label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtNotes" runat="server" Placeholder="Notes" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Spoken Language</label>
                                            <div class="col-md-9">
                                            <asp:DropDownList ID="drpspoken" runat="server"  CssClass="form-control">
</asp:DropDownList>      
                                            </div>
                                        </div>
                                    </div>
                                    <!--/span-->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Partner</label>
                                            <div class="col-md-9">
                                            <asp:DropDownList ID="drppartner" runat="server"  CssClass="form-control" OnSelectedIndexChanged="drppartner_SelectedIndexChanged"  AutoPostBack="true" ></asp:DropDownList>          
                                            </div>
                                        </div>
                                    </div>
                                    <!--/span-->
                                </div>

                                <div class="row">
                                   

                                    <!--/span-->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Broker</label>
                                            <div class="col-md-9">
                                               <asp:DropDownList ID="drpbroker" runat="server"  CssClass="form-control">
</asp:DropDownList>          
                               

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"></label>
                                            <div class="col-md-9 ">
                                                <asp:CheckBox ID="chkArchived" runat="server"  Text="Archived"/>
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row" id="vendorimage" runat="server" style="display:none">
                                   
                                     <asp:Label ID="LabelContactID" runat="server" Visible="false"></asp:Label>
                                    <!--/span-->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Image</label>
                                            <div class="col-md-5">
                                           
                                                <asp:FileUpload ID="FileUploadImage" runat="server"/>   
                                                  
                                            </div>
                                             <div class="col-md-4">
                                           
                                               <asp:Button ID="btnuploadimage" runat="server" Text="Upload Image" class="btn green" OnClick="btnuploadimage_Click" ></asp:Button>   
                                                  
                                            </div>
                                        </div>
                                    </div>
                                      <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">  <asp:Label ID="LabelImageTitle" runat="server"></asp:Label></label>

                                            <div class="col-md-9">
                                             <asp:Image ID="ImageContact" runat="server"  style="width:200px;height:200px"/>
                                             <asp:Label ID="lblimg" runat="server" style="display:none"></asp:Label>    
                                            </div>
                                        </div>
                                    </div>
                                
                                </div>
                              
                                <!--/row-->
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Properties</label>
                                            <div class="col-md-9">
  <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                        
                        <div class="table-scrollable">
                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                <thead>
                                    <tr role="row" style="border: 1px solid #ddd">
                                        <asp:GridView ID="grdAdmin" DataKeyNames="id"  AllowPaging="true" PageSize="5" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnRowCommand="grdAdmin_RowCommand" OnPageIndexChanging="grdAdmin_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">

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
                            
                        </div>
                    <asp:Button ID="btnimageprop" runat="server" Text="Add Property" class="btn green" OnClick="btnimageprop_Click" ></asp:Button>
                    

                    </div>                                         </div>
                                        </div>
                                    </div>
                                   
                                </div>
                           
                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-offset-3 col-md-9">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn green" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none"  OnClientClick="return Validations();"></asp:Button>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn default"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                            </div>




                                <asp:HiddenField ID="hdnvenid" runat="server" />
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
           <Triggers>
            <asp:PostBackTrigger ControlID="btnuploadimage" />


        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
