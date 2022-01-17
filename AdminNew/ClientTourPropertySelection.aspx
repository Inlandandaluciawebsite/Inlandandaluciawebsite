<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ClientTourPropertySelection.aspx.vb" Inherits="Admin_WebUserControlAdminClientTourPropertySelection" %>

<%@ Register Src="~/ControlsNew/WebUserControlAdminClientTourPropertySelection.ascx" TagPrefix="uc1" TagName="WebUserControlAdminClientTourPropertySelection" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



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
                <uc1:WebUserControlAdminClientTourPropertySelection runat="server" ID="WebUserControlAdminClientTourPropertySelection1" />
                 
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










  
</asp:Content>

