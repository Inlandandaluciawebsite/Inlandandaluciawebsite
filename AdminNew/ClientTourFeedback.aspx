<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ClientTourFeedback.aspx.vb" Inherits="Admin_ClientTourFeedback" %>

<%@ Register Src="~/ControlsNew/WebUserControlAdminClientTourFeedback.ascx" TagPrefix="uc1" TagName="WebUserControlAdminClientTourFeedback" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel id="upAddAdmin" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
              <asp:UpdateProgress runat="server" id="PageUpdateProgress" AssociatedUpdatePanelid="upAddAdmin"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="overlay" id="divProgress">
                                    &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" id="Image1" runat="server" Width="50"
                    Height="40" ImageUrl="images/ajaxloading.gif"  />
                                </div>
                   
                </ProgressTemplate>
            </asp:UpdateProgress>

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
                                      <h2>Client Tour Feedback</h2>
                                    </div>
                                       <div  align="right" class="right">    <a class="btn green mrgtp" href="javascript:window.history.back();" role="button" >

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
 <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                          </div>
                                </div>
                             <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                            <div class="form-body">
                                <h3 class="form-section"></h3>
                                <!--/row-->
                                <!--/row-->
                           
        <div id="TableBuyer" runat="server" >

            <div class="row">
                 <div class="col-md-12">
                <uc1:WebUserControlAdminClientTourFeedback runat="server" ID="WebUserControlAdminClientTourFeedback" />
                 
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








            </ContentTemplate>
        </asp:UpdatePanel>

  
</asp:Content>

