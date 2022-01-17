<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ReportClientTourMissingFeedback.aspx.vb" Inherits="Admin_ReportClientTourMissingFeedback" %>

<%@ Register Src="~/ControlsNew/WebUserControlReportClientTourMissingFeedback.ascx" TagPrefix="uc1" TagName="WebUserControlReportClientTourMissingFeedback" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    <link href="css/table-css.css" rel="stylesheet" />
    <script>
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                $(".tab-res").each(function () {

                    var btn = $(this).next(".btncl").find(".open-t");

                    var btnapp = $(this).find("table").find("tbody").find("tr:last").find("td:last");

                    $(btn).append().appendTo(btnapp);
                });
            });

        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%-- <asp:Panel ID="testpn" runat ="server"><uc1:WebUserControlReportClientTourMissingFeedback runat="server" id="WebUserControlReportClientTourMissingFeedback" />
    </asp:Panel>--%>
    <asp:UpdatePanel ID="uptes" runat="server">
        <ContentTemplate>

    
    <div class="row">
        <div class="col-md-12">
   <div class="table-outer">
  <div class="container clscontrep">
    <div class="row">
      <div class="table-inner">
        <div class="col-md-12">
            <div class="col-md-6"> <h2>Client Tours Requiring Feedback</h2></div>
             <div class="col-md-6">
         
             <div  align="right" >    <a class="btn green mrgtp" href="javascript:window.history.back();" role="button" >

                                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
 <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                                          </div></div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="table-inner">
        <div class="col-md-12">
             <uc1:WebUserControlReportClientTourMissingFeedback runat="server" ID="WebUserControlReportClientTourMissingFeedback" />
    <asp:PlaceHolder ID="testpn" runat="server" ></asp:PlaceHolder>
                 
        </div>
      </div>
    </div>
        </div>
     

 </div>
        </div></div>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


