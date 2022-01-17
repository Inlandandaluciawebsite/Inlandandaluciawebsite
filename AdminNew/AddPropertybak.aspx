<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="AddProperty.aspx.vb" Inherits="Admin_AddProperty" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" lang="javascript">
        function Validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateDropdown(document.getElementById('<%=drpproperty.ClientID%>'), "Please select property type!");
            IsError += ValidateDropdown(document.getElementById('<%=drpVendor.ClientID%>'), "Please select vendor!");


            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
    </script>

    <%--<script>

        function pageLoad() {
            $(document).ready(function () {

                $('.clstabs').click(function () {
                    var id = $(this).attr('rel');
                    document.getElementById('ContentPlaceHolder1_' + id).click();

                });
            });
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="page-content-wrapper">
        <div class="page-content">--%>
    <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->

    <asp:UpdatePanel ID="updvendor" runat="server">
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

    <h3 class="page-title">Add Property 
    </h3>
   <%-- <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="Index.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="AddProperty.aspx">Add Property</a>

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
                                Add/Edit Property
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
                                            <label class="control-label col-md-3">Vendor</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="drpVendor" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Property Type </label>
                                                  <div class="col-md-9">
<asp:DropDownList ID="drpproperty" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
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
                          
                                 <div class="row" id="propform" runat="server" style="display:none">
    <div class="col-md-12">
      <div class="panel with-nav-tabs panel-default">
        <div class="panel-heading">
              <h3 class="form-section"><asp:Label ID="lblpropref" runat="server"></asp:Label>
                 
                  <asp:HiddenField ID="hdpropid" runat="server" />
              </h3>
          <ul class="nav nav-tabs">
            <li  runat="server" id="ligen" >
                <asp:linkButton ID="lbltest" runat="server"  OnClick="lblgeneral_Click"   style="display:block" Text="General"></asp:linkButton>
            </li>
            <li runat="server" id="lidec">
                  <asp:linkButton  ID="Button3" runat="server"  OnClick="LinkButton1_Click"  Text="Descriptions" ></asp:linkButton> 
            </li>
            <li runat="server" id="liimage">
                 <asp:linkButton  ID="Button4" runat="server"  OnClick="lblimages_Click"   Text="Images"></asp:linkButton>
            </li>
            <li runat="server" id="lifeat">
                      <asp:linkButton  ID="Button5" runat="server"  OnClick="lblFeatures_Click"  Text="Features"></asp:linkButton>
            </li>
               <li runat="server" id="lihist">
                    <asp:linkButton ID="Button6" runat="server"  OnClick="lblHistory_Click"  Text="History" ></asp:linkButton> 
               </li>
               <li runat="server" id="lidocum">
                   <asp:linkButton ID="Button7" runat="server"  OnClick="lblDocuments_Click"   Text="Documents"></asp:linkButton> 
               </li>
          </ul>
        </div>
        <div class="panel-body">
          <div class="tab-content">
            <div class="tab-pane fade in active " id="tab1default" runat="server" style="display:none">

                 <div class="form-body" >
                              
                                <!--/row-->
                                <!--/row-->

                                <!--/row-->
                           


                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Vendor</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="DropDownListVendor" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Property Type </label>
                                                  <div class="col-md-9">
<asp:DropDownList ID="DropDownListType" runat="server"  CssClass="form-control" Enabled="false" >
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                                  <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Property Status</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="DropDownListStatus" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Country </label>
                                                  <div class="col-md-9">
<asp:DropDownList ID="drpCountry" runat="server"  CssClass="form-control" >
    <asp:ListItem Text="Spain" Value="2"></asp:ListItem>
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                                  <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Area</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="drpArea" runat="server"  CssClass="form-control" OnSelectedIndexChanged="drpArea_SelectedIndexChanged"  AutoPostBack="true" >
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Town </label>
                                                  <div class="col-md-9">
<asp:DropDownList ID="drpTown" runat="server"  CssClass="form-control" OnSelectedIndexChanged="drpTown_SelectedIndexChanged"  AutoPostBack="true" >
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                                  <!--/row-->
                                <div class="row">
                                      <div class="col-md-6" style="display:none" runat="server" id="subareasection">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Village </label>
                                                  <div class="col-md-9">
        <asp:DropDownList ID="drpvillage" runat="server"  CssClass="form-control"  OnSelectedIndexChanged="drpvillage_SelectedIndexChanged"  AutoPostBack="true" >
</asp:DropDownList>  
                                         </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Postcode</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="drppostcode" runat="server"  CssClass="form-control" OnSelectedIndexChanged="drppostcode_SelectedIndexChanged"  AutoPostBack="true" >
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                  
                                </div>
                                <div class="row">
                                  
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Address </label>
                                                  <div class="col-md-9">
<asp:TextBox ID="txtAddress" runat="server"  CssClass="form-control" TextMode="MultiLine" >
</asp:TextBox>                                              </div>
                                        </div>
                                    </div>
                                </div>
                                <!--/row-->
                                  <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Latitude</label>
                                            <div class="col-md-9">
<asp:TextBox ID="txtLattitude" runat="server"  CssClass="form-control" onkeypress="CheckDecimalAllowNegative(this, event);">
</asp:TextBox>(e.g. 37.0)                                   </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Longitude </label>
                                                  <div class="col-md-9">
<asp:TextBox ID="txtLongitude" runat="server"  CssClass="form-control" onkeypress="CheckDecimalAllowNegative(this, event);">
</asp:TextBox>(e.g. -4.0)                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->

                                 <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Location</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="drplocation" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Views </label>
                                                  <div class="col-md-9">
<asp:DropDownList ID="drpviews" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Bedrooms</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="drpbedrooms" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Bathrooms </label>
                                                  <div class="col-md-9">
<asp:DropDownList ID="drpbathrooms" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Year Constructed</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="drpyearconstructed" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Plot </label>
                                                  <div class="col-md-9">
<asp:TextBox ID="txtplot" runat="server"  CssClass="form-control" onkeypress="CheckDecimal(this, event);" MaxLength="6" AutoCompleteType="None">
</asp:TextBox>m2                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Built</label>
                                            <div class="col-md-9">
<asp:TextBox ID="txtbuilt" runat="server"  CssClass="form-control" onkeypress="CheckDecimal(this, event);" MaxLength="4" AutoCompleteType="None">
</asp:TextBox>m2                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Terrace </label>
                                                  <div class="col-md-9">
<asp:TextBox ID="txtterrace" runat="server"  CssClass="form-control" onkeypress="CheckDecimal(this, event);" MaxLength="3" AutoCompleteType="None">
</asp:TextBox>m2                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">En Suite</label>
                                            <div class="col-md-9">
<asp:TextBox ID="txtensuite" runat="server"  CssClass="form-control" onkeypress="CheckDecimal(this, event);" MaxLength="2" AutoCompleteType="None">
</asp:TextBox>m2                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Annual IBI </label>
                                                  <div class="col-md-9">
<asp:TextBox ID="txtAnnualIBI" runat="server"  CssClass="form-control" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None">
</asp:TextBox>€ (e.g. ###.## €)                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Annual Rubbish</label>
                                            <div class="col-md-9">
<asp:TextBox ID="txtAnnualRubbish" runat="server"  CssClass="form-control" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None">
</asp:TextBox>€ (e.g. ###.## €)                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Community Fees </label>
                                                  <div class="col-md-9">
<asp:TextBox ID="txtCommunityFees" runat="server"  CssClass="form-control" onkeypress="CheckCurrency(this, event);" MaxLength="7" AutoCompleteType="None">
</asp:TextBox>€ (e.g. ###.## €)                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Vendor Price</label>
                                            <div class="col-md-9">
<asp:TextBox ID="txtVendorPrice" runat="server"  CssClass="form-control" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None">
</asp:TextBox>€ (e.g. ###.## €)                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Original Price </label>
                                                  <div class="col-md-9">
<asp:TextBox ID="txtOriginalPrice" runat="server"  CssClass="form-control" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None">
</asp:TextBox>€ (e.g. ###.## €)                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Public Price</label>
                                            <div class="col-md-9">
<asp:TextBox ID="txtPublicPrice" runat="server"  CssClass="form-control" onkeypress="CheckNumeric(event);" MaxLength="7" AutoCompleteType="None" >
</asp:TextBox>€ (e.g. ###.## €)                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Youtube Video ID </label>
                                                  <div class="col-md-9">
<asp:TextBox ID="txtYoutubeVideoId" runat="server"  CssClass="form-control"  MaxLength="100" AutoCompleteType="None">
</asp:TextBox>                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Door Key</label>
                                            <div class="col-md-9">
<asp:TextBox ID="txtDoorKey" runat="server"  CssClass="form-control" MaxLength="10" AutoCompleteType="None">
</asp:TextBox>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Partner </label>
                                                  <div class="col-md-9">
<asp:DropDownList ID="drpPartner" runat="server"  CssClass="form-control" OnSelectedIndexChanged="drppartner_SelectedIndexChanged"  AutoPostBack="true" >
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                      <!--/row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Broker</label>
                                            <div class="col-md-9">
<asp:DropDownList ID="drpBroker" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Vendor's Lawyer </label>
                                                  <div class="col-md-9">
<asp:DropDownList ID="drpVendrlaywer" runat="server"  CssClass="form-control">
</asp:DropDownList>                                            </div>
                                        </div>
                                    </div>
                                </div>
                             
                                <!--/row-->
                        <%-- End form 2 --%>
                            </div>
                             <div class="form-actions" id="propformbtn" runat="server" style="display:block">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-offset-3 col-md-9">
                                                <asp:Button ID="btnsaveproperty" runat="server" Text="Submit" class="btn green" OnClick="btnsaveproperty_Click"  ></asp:Button>
                                                <b><asp:Label ID="lblmessage" runat="server"></asp:Label></b> 
                                                <asp:Button ID="Button2" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none"  ></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                            </div>

            </div>
            <div class="tab-pane fade in active" id="tab2default" runat="server"  style="display:none">Default 2</div>
            <div class="tab-pane fade in active" id="tab3default" runat="server" style="display:none" >Default 3</div>
            <div class="tab-pane fade in active" id="tab4default" runat="server" style="display:none" >Default 4</div>
            <div class="tab-pane fade in active" id="tab5default" runat="server" style="display:none" >Default 5</div>
              <div class="tab-pane fade in active" id="tab6default" runat="server"  style="display:none">Default 6</div>
          
          </div>
        </div>
      </div>
    </div>
  </div>
                           
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



