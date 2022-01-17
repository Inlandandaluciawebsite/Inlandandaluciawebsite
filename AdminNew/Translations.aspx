<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Translations.aspx.vb" Inherits="Translations" %>

<script runat="server">

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script type="text/javascript" lang="javascript">
       function Validations() {
           var IsError = '';
           var invalid = " "; // Invalid character is a space
           var cnfr = $("#msgerror").text();
          
           if (cnfr != "") {
               return false;
           }


            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
    </script>
    <script>
        $(function () {

            $('#ContentPlaceHolder1_txtconfirmpassword').change(function () {
                if ($('#ContentPlaceHolder1_txtpassword').val() != $('#ContentPlaceHolder1_txtconfirmpassword').val())
                    $('#msgerror').text('The passwords entered do not match');
                else
                    $('#msgerror').text('');
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanelAdminTranslations" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
              <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="UpdatePanelAdminTranslations"
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
            </h3> <asp:Label ID="LabelContactID" runat="server" Visible="false"></asp:Label>
           <%-- <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AddAgent.aspx">Add Agent</a>
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
                                      Translations
                                    </div><div  align="right" class="right">    <a class="btn green mrgtp" href="javascript:window.history.back();" role="button" >

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
 <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                          </div>
                                </div>
                             <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                                  <div class="form-body">
                                    
                      <div id="TableTranslations" runat="server">

            <div class="row" id="TableRowSearchEnglish" runat="server">
                <div class="col-md-3" >
                    Search English text for:
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="TextBoxTranslationSearchEnglish" runat="server"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="ButtonTranslationSearchEnglish" runat="server" Text="Search" CssClass="btn green"/>
                </div>                
            </div>
            
            <div class="row" id="TableRowSearchForeign" runat="server">
                <div class="col-md-3" >
                    Search Translations for:
                </div>
                 <div class="col-md-6" >
                    <asp:TextBox ID="TextBoxTranslationSearchForeign" runat="server"  CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="col-md-3" >
                    <asp:Button ID="ButtonTranslationSearchForeign" runat="server" Text="Search" CssClass="btn green"/>
                </div>                
            </div>

            <div class="row" id="TableRowNoResults" runat="server"  Visible="false">
                <div class="col-md-3" >
                    </div>
                <div class="col-md-3">
                    <strong>No results found</strong>
                </div>            
               <div class="col-md-3" >
                    </div>
            </div>

            <div class="row" id="TableRowSearchResults" runat="server" Visible="false">
                <div class="col-md-12">
                      <div class="table-scrollable">
                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                <thead>
                                    <tr role="row" style="border: 1px solid #ddd">
           
                    <asp:GridView 
                        ID="GridViewResults" 
                        runat="server" 
                        Width="100%" 
                        GridLines="None"                
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"  
                        AlternatingRowStyle-CssClass="alt"
                        AutoGenerateSelectButton="true" 
                        AllowSorting="True">
                    </asp:GridView>
                                     </tr></thead>   </table></div>
                </div>
            </div>

            <div class="row" ID="TableRowEnglish" runat="server" Visible="false">
                <div class="col-md-3"  >
                    <strong>English</strong>
                </div>            
            </div>

            <div class="row" ID="TableRowOriginal" runat="server" Visible="false">
                <div class="col-md-12">
                    <asp:TextBox ID="TextBoxOriginal" runat="server" CssClass="form-control" MaxLength="2000" TextMode="MultiLine" Rows="4" width="100%" AutoPostBack="true" Font-Names="Lucida Sans Unicode" Enabled="false"></asp:TextBox>
                </div>            
            </div>

            <div class="row" ID="TableRowLanguage" runat="server" Visible="false">
                <div class="col-md-12" >
                    <strong><asp:Label ID="LabelLanguage" runat="server" ></asp:Label></strong>
                </div>            
            </div>

            <div class="row" ID="TableRowTranslation" runat="server" Visible="false">
                <div class="col-md-12">
                    <asp:TextBox ID="TextBoxTranslation" runat="server" CssClass="form-control"  MaxLength="2000" TextMode="MultiLine" Rows="4" width="100%" AutoPostBack="true" Font-Names="Lucida Sans Unicode"></asp:TextBox>
                </div>            
            </div>

            
                            <div class="form-actions"  ID="TableRowUpdate" runat="server" Visible="false">
                                <div class="row">
                                    <div class="col-md-12">
                                         <b><asp:Label ID="lblmessage" runat="server"></asp:Label></b> 
                                            <div class="text-right">
                                                            <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="btn green"/> <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="btn green"/> <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn green"/>       </div>
                                       
                                    </div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                            </div>

        </div>




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
            
    </asp:UpdatePanel>
</asp:Content>
