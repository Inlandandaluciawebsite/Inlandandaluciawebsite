<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Location.aspx.vb" Inherits="Location" %>

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
                                      System Parameters: <asp:Label ID="LabelTitle" runat="server"></asp:Label>
                                    </div><div  align="right" class="right">    <a class="btn green mrgtp" href="javascript:window.history.back();" role="button" >

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
 <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                          </div>
                                </div>
                             <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                                  <div class="form-body">
                  <%--   <h3></h3>--%>

<div id="TableUpdateSystemVariables" runat="server">

    <div class="row" id="TableRowResults" runat="server">

        <div class="col-lg-12" >
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
                AutoGenerateSelectButton="true" >
            </asp:GridView>
                                        </tr>
                                    </thead>
                                    </table>
                   </div>

        </div>

    </div>
    <div class="form-actions" id="TableRowAdd" runat="server">
                                        <div class="row">
                                            <div class="col-md-12">
                                              <b><asp:Label ID="Label1" runat="server"></asp:Label></b>  
                                                    <div class="text-right">
                                                       
                                                       <asp:Button ID="ButtonAdd" runat="server" Text="Add" CssClass="btn green"/>
                                                          </div>
                                               
                                            </div>
                                           
                                        </div>
                                    </div>
  

    <div class="row" id="TableRowAddEditEnglish" runat="server" Visible="false">
     <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">English:</label>
                                                    <div class="col-md-8">
                                                       <asp:TextBox ID="TextBoxEnglish" runat="server" CssClass="form-control" ></asp:TextBox></div> <div class="col-md-1"> <asp:Button ID="ButtonAutoTranslate" runat="server" Text="Auto Translate" CssClass="btn green"/>
                                                    </div>
                                                               
                                                </div>
                                            </div>
       
    </div>

    <div class="row" id="TableRowAddEditSpanish" runat="server" Visible="false">
    
        <div class="col-md-6">     
             <div class="form-group">
                                                    <label class="control-label col-md-3">Spanish:</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="TextBoxSpanish" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                               
                                                </div> 
                    
        </div>

       
    </div>

    <div class="row"  id="TableRowAddEditFrench" runat="server" Visible="false">
     <div class="col-md-6">     
             <div class="form-group">
                                                    <label class="control-label col-md-3">French:</label>
                                                    <div class="col-md-9">
                                                     <asp:TextBox ID="TextBoxFrench" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                               
                                                </div> 
                    
        </div>
       
    </div>

    <div class="row" id="TableRowAddEditGerman" runat="server" Visible="false">
        <div class="col-md-6">     
      <div class="form-group">
                                                    <label class="control-label col-md-3">German:</label>
                                                    <div class="col-md-9">
                                                    <asp:TextBox ID="TextBoxGerman" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                               
                                                </div> 
       </div>
    
    </div>

    <div class="row"  id="TableRowAddEditDutch" runat="server" Visible="false">
        <div class="col-md-6">   
     <div class="form-group">
                                                    <label class="control-label col-md-3">Dutch:</label>
                                                    <div class="col-md-9">
                                                     <asp:TextBox ID="TextBoxDutch" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                               
                                    </div>            </div> 
       
    
    </div>

    <div class="row"  id="TableRowCode" runat="server" Visible="false">
    <div class="form-group">
                                                    <label class="control-label col-md-3">Code:</label>
                                                    <div class="col-md-9">
                                                     <asp:TextBox ID="TextBoxCode" runat="server" MaxLength="2" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                               
                                                </div> 
      
    
    </div>

  
    <div class="form-actions" id="TableRowOptions" runat="server" Visible="false">
                                        <div class="row">
                                            <div class="col-md-12">
                                             
                                                    <div class="text-right">
                                                       
                                                        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn green"/>
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="btn green"/>
            <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" CssClass="btn green"/>

                                                          </div>
                                               
                                            </div>
                                           
                                        </div>
                                    </div>

    <div class="row" id="TableRowPropertiesAffectedPrompt" runat="server" Visible="false">
    
        <div class="col-md-6">
            Unable to remove this system variable as it is currently in use by the following properties:    
        </div>

        <div  class="col-md-6"></div>

    </div>

    <div class="row" id="TableRowPropertiesAffected" runat="server" Visible="false">
    
        <div class="col-md-12" >
                    <div class="table-scrollable">
                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="Table1" role="grid" aria-describedby="sample_1_info">
                                <thead>
                                    <tr role="row" style="border: 1px solid #ddd">
            <asp:GridView 
                ID="GridViewPropertiesAffected" 
                runat="server" 
                Width="100%" 
                GridLines="None"                
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt">
            </asp:GridView></tr>
                                    </thead>
                                </table>
                        </div>
    
        </div>

        
    </div>

 
    <div class="form-actions" id="TableRowBack" runat="server" Visible="false">
                                        <div class="row">
                                            <div class="col-md-12">
                                              <b><asp:Label ID="lbldocument" runat="server"></asp:Label></b>  
                                                    <div class="text-right">
                                                       
                                                      <asp:Button ID="ButtonBack" runat="server" Text="Back" CssClass="btn green"/>
                                                          </div>
                                               
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
