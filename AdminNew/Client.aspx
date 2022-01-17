<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Client.aspx.vb" Inherits="Client" %>

<%@ Register Src="~/ControlsNew/WebUserControlAdminPossibleDuplicates.ascx" TagName="AdminPossibleDuplicates" TagPrefix="ucAdminPossibleDuplicates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" lang="javascript">
        function Validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredField(document.getElementById('<%=TextBoxForename.ClientID%>'), "Please enter forename!");
            IsError += ValidateRequiredField(document.getElementById('<%=TextBoxSurname.ClientID%>'), "Please enter surname!");
            IsError += ValidateRequiredField(document.getElementById('<%=TextBoxEmail.ClientID%>'), "Please enter email!");

            var allocatedToField = $("#ContentPlaceHolder1_drpUser option:selected").text();
            if (allocatedToField == "-- Select --") {
                IsError +="Please select allocated to user !\r\n"
            }
            var sourceField = $("#ContentPlaceHolder1_DropDownListSource option:selected").text();
            if (sourceField == "--- Select ---") {
               IsError +="Please select source !"
            }
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 & unicode != 9) { //if the key isn't the backspace key (which we should allow)
                if (unicode < 48 || unicode > 57 || unicode == 9) //if not a number
                {
                    alert('Please Input Numbers Only');
                    return false //disable key press
                }
            }
        }
    </script>
    <script>
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $(".mrgtp").click(function () {
                    var stateObj = $("#ContentPlaceHolder1_hdcont").val()
                    var pageindex = $("#ContentPlaceHolder1_hdpageind").val()
                    var prevurl = $("#ContentPlaceHolder1_hdnprevurl").val()

                    window.location.href = prevurl


                })
            });
        });
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
                    Height="40" ImageUrl="images/ajaxloading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <h3 class="page-title"></h3>
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
                                        Client
                                    </div>
                                    <div align="right" class="right">
                                        <a class="btn green mrgtp" href="#" role="button">

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                            <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <asp:HiddenField ID="hdcont" runat="server" />
                                    <asp:HiddenField ID="hdnprevurl" runat="server" />
                                    <asp:HiddenField ID="hdpageind" runat="server" />
                                    <!-- BEGIN FORM-->
                                    <%--  <form action="#" class="form-horizontal">--%>
                                    <div class="form-body">
                                        <h3 class="form-section"></h3>
                                        <!--/row-->
                                        <!--/row-->
                                        <h1>
                                            <asp:Label ID="LabelBuyer" runat="server" Text="Client" Style="display: none"></asp:Label>
                                            <asp:Button ID="btnAction" runat="server" Text="ACTION" Visible="false" CssClass="btn green" PostBackUrl="~/AdminNew/BuyerActionAgenda.aspx" />
                                            <asp:Button ID="btnClintHistory" runat="server" Text="CLIENT HISTORY" CssClass="btn green" PostBackUrl="~/AdminNew/ClientHistory.aspx" Visible="false" />
                                            <asp:Button ID="btnBuyerCriterias" runat="server" Text="CRITERIAS" CssClass="btn green" OnClick="btnBuyerCriterias_Click" />
                                        </h1>

                                        <div id="TableBuyer" runat="server">
                                             <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Email:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="50" CssClass="form-control" OnTextChanged="TextBoxEmail_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                            <asp:Panel ID="pnlBuyerDetails" runat="server" Visible="false" Width="367px">
                                                                <table style="width:367px;">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <b>This client already exists, you can't create it, here are details : </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Client : </td>
                                                                        <td>
                                                                            <asp:Label ID="lblClient" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Telephone : </td>
                                                                        <td>
                                                                            <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Email : </td>
                                                                        <td>
                                                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Partner : </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPartner" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td>SalesPerson : </td>
                                                                        <td>
                                                                            <asp:Label ID="lblSalesPerson" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>
                                                                            <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn green" OnClick="btnClose_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                            </asp:Panel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Forename: </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TextBoxForename" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="col-md-6">
                                                    <div class="form-group">

                                                        <div class="col-md-12">

                                                            <asp:Button ID="ButtonCreateTour" runat="server" Text="Create Tour" Visible="false" CssClass="btn green" />


                                                            <asp:Button ID="btntours" runat="server" Text="Tours" Visible="false" CssClass="btn green" />
                                                            <asp:Label ID="lbltourid" runat="server" Style="display: none"></asp:Label>

                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Surname: </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TextBoxSurname" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Passport No.: </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TextBoxPassportNo" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Address: </label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TextBoxAddress" runat="server" MaxLength="250" CssClass="form-control" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>


                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Contact Name:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TextBoxContactName" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Telephone:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TextBoxTelephone" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                           
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Notes:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TextBoxNotes" runat="server" MaxLength="2000" TextMode="MultiLine" Rows="10" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Buyer Criteria URL :</label>
                                                        <div class="col-md-8">
                                                            <asp:HyperLink ID="lnkBuyerCriteriaURL" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Allocated to:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="drpUser" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpUser_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                                            <asp:HiddenField ID="hdnUser" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Partner:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="DropDownListPartner" runat="server" AutoPostBack="true" Enabled="false" CssClass="form-control"></asp:DropDownList>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>


                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Agent:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="DropDownListAgent" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>



                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Language:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="DropDownListLanguage" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Budget:</label>
                                                        <div class="col-md-7">
                                                            <asp:TextBox ID="TextBoxBudget" onkeypress="return numbersonly(event)" runat="server" MaxLength="7" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-1">
                                                            €                  
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Source:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="DropDownListSource" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>


                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Status:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3"></label>
                                                        <div class="col-md-8">

                                                            <asp:CheckBox ID="CheckBoxArchived12" runat="server" Text="Archived" />

                                                        </div>

                                                    </div>
                                                </div>




                                            </div>


                                            <div class="row" id="TableRowPossibleDuplicates" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3">Did you perhaps mean..</label>
                                                        <div class="col-md-6">
                                                            <ucAdminPossibleDuplicates:AdminPossibleDuplicates ID="AdminPossibleDuplicates" runat="server" />
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>
                                            <div class="form-actions" id="TableRowSave" runat="server">
                                                <div class="row">
                                                    <div class="col-md-12">

                                                        <div class="text-right">
                                                            <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="return Validations();" UseSubmitBehavior="true" CssClass="btn green" />
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>



                                            <div class="row" id="TableRowSaved" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3"></label>
                                                        <div class="col-md-8">
                                                            <strong>
                                                                <asp:Label ID="LabelSaved" runat="server" Text="Buyer Successfully Saved"></asp:Label></strong>
                                                        </div>

                                                    </div>
                                                </div>




                                            </div>



                                        </div>

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
                <!-- BEGIN QUICK SidEBAR -->
                <!-- END QUICK SidEBAR -->
                <!-- END CONTAINER -->
                <!-- BEGIN FOOTER -->
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
