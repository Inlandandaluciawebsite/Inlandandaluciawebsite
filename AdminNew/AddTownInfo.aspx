<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" ValidateRequest="false" AutoEventWireup="false" CodeFile="AddTownInfo.aspx.vb" Inherits="AddTownInfo" %>

<%@ Register Src="~/ControlsNew/WebUserControlAdminPossibleDuplicates.ascx" TagName="AdminPossibleDuplicates" TagPrefix="ucAdminPossibleDuplicates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" lang="javascript">
        function Validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredField(document.getElementById('<%=txtTopHeading.ClientID%>'), "Please enter top heading!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtTopDescription.ClientID%>'), "Please enter top description!");
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript" src="/tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            // General options 
            //  mode: "textareas",
            mode: "specific_textareas",
            editor_selector: "tinymcereq",
            theme: "advanced",
            plugins: "image",
            toolbar: "image",
            image_caption: true,
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,  inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,  directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,  wordcount,advlist,autosave",
            setup: function (ed) {
                ed.onKeyPress.add(
                function (ed, evt) {
                }
                );
            },
            // Theme options 
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,       justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,       fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,       bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,       image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,       charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,       styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,       template,pagebreak,restoredraft",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,
            // Example content CSS (should be your site CSS) 
            content_css: "css/content.css",
            // Drop lists for link/image/media/template dialogs 
            template_external_list_url: "lists/template_list.js",
            external_link_list_url: "lists/link_list.js",
            external_image_list_url: "lists/image_list.js",
            media_external_list_url: "lists/media_list.js",
            // Style formats 
            style_formats: [
            { title: 'Bold text', inline: 'b' },
            { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
            { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
            { title: 'Example 1', inline: 'span', classes: 'example1' },
            { title: 'Example 2', inline: 'span', classes: 'example2' },
            { title: 'Table styles' },
            { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
            ],
            // Replace values for the template plugin 
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
    </script>
    <style type="text/css">
        .map-pin-inner {
            display: flex;
            align-items: center;
            margin-bottom: 15px;
        }

        #uniform-ContentPlaceHolder1_chkSchools {
            display: inline-block;
        }

        #uniform-ContentPlaceHolder1_chkHealthClinic {
            display: inline-block;
        }

        #uniform-ContentPlaceHolder1_chkShopsBarsRestaurant {
            display: inline-block;
        }

        #uniform-ContentPlaceHolder1_chkMunicipalpool {
            display: inline-block;
        }

        #uniform-ContentPlaceHolder1_chkGolfnearby {
            display: inline-block;
        }

        #uniform-ContentPlaceHolder1_chkBusAndTrainService {
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <asp:UpdatePanel ID="upAddAdmin" runat="server">
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
            </asp:UpdateProgress>--%>
    <h3 class="page-title"></h3>
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
                                Add Town Info Page
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

                                <div id="TableBuyer" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Select Region:</label>
                                                <div class="col-md-10">
                                                    <asp:DropDownList ID="drpRegion" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="drpRegion_TextChanged">
                                                        <asp:ListItem Text="Select Region" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Cordoba" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Granada" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Jaen" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Malaga" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Sevilla" Value="5"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Select Area:</label>
                                                <div class="col-md-10">
                                                    <asp:DropDownList ID="drpArea" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="drpArea_TextChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Page Name: </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtPageName" runat="server" MaxLength="200" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                      <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Meta Keywords:</label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtMetaKeywords" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Top Heading: </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtTopHeading" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Top Description: </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtTopDescription" runat="server" class="form-control" Placeholder="Top Description" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="divider">
                                        &nbsp;
                                    </div>
                                    <div class="row">
                                        <label class="control-label col-md-2">Quick information of Town: </label>
                                        <div class="col-md-10">
                                            <div class="map-pin">
                                                <div class="col-md-4 col-sm-4">
                                                    <div class="map-pin-inner">
                                                        <img src="/images/residents.png">
                                                        <p>
                                                            <asp:TextBox ID="txtResidents" Width="40" Text="0" runat="server"></asp:TextBox>
                                                            residents
                                                        </p>
                                                        <p>
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/school.png">
                                                        <p>
                                                            <asp:CheckBox ID="chkSchools" runat="server" Text="Schools" Checked="true" />
                                                        </p>
                                                        <p>
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/car.png">
                                                        <p>
                                                            <asp:TextBox ID="txtDistanceNearBy" TextMode="MultiLine" Rows="3" Columns="28" Text="" runat="server"></asp:TextBox>
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/pln.png">
                                                        <p>
                                                            <asp:TextBox ID="txtMalagaDistance" Text="0" Width="40" runat="server"></asp:TextBox>km to Malaga
                                                        </p>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-4">
                                                    <div class="map-pin-inner">
                                                        <img src="/images/hospital.png">
                                                        <p>
                                                            <asp:CheckBox ID="chkHealthClinic" runat="server" Text="Health clinic" Checked="true" />
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/pool.png">
                                                        <p>
                                                            <asp:CheckBox ID="chkMunicipalpool" runat="server" Text="Municipal pool" Checked="true" />
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/Beach.png">
                                                        <p>
                                                            Beach<asp:TextBox ID="txtBeachDistance" Width="40" runat="server"></asp:TextBox>
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/pln.png">
                                                        <p>
                                                            <asp:TextBox ID="txtGranadaDistance" Text="0" Width="40" runat="server"></asp:TextBox>km to Granada
                                                        </p>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-4">
                                                    <div class="map-pin-inner">
                                                        <img src="/images/shopping.png">
                                                        <p>
                                                            <asp:CheckBox ID="chkShopsBarsRestaurant" runat="server" Text="Shops, Bars, Restaurants" Checked="true" />
                                                        </p>
                                                        <p>
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/golf.png">
                                                        <p>
                                                            <asp:CheckBox ID="chkGolfnearby" runat="server" Text="Golf nearby" Checked="true" />
                                                        </p>
                                                        <p>
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/bus.png">
                                                        <p>
                                                            <asp:CheckBox ID="chkBusAndTrainService" runat="server" Text="Bus and train service" Checked="true" />
                                                        </p>
                                                        <p>
                                                        </p>
                                                    </div>
                                                    <div class="map-pin-inner">
                                                        <img src="/images/pln.png">
                                                        <p>
                                                            <asp:TextBox ID="txtSevillaDistance" Text="0" Width="40" runat="server"></asp:TextBox>km to Sevilla
                                                        </p>
                                                        <p>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="divider">
                                        &nbsp;
                                    </div>
                                    <div class="row" id="divPageImages" runat="server" visible="false">
                                        <label class="control-label col-md-2">Manage Page Images: </label>
                                        <div class="col-md-10">
                                            <div class="table-scrollable">
                                                <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr role="row">
                                                            <td>
                                                                <asp:FileUpload ID="fucPageImage" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnSaveImage" runat="server" Text="Save" CssClass="btn green" OnClick="btnSaveImage_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr role="row" style="border: 1px solid #ddd">
                                                            <td colspan="2">
                                                                <asp:GridView ID="grdPageImages" DataKeyNames="ImageId" AllowPaging="true" OnRowCommand="grdPageImages_RowCommand" PageSize="10" Font-Names="Open Sans, sans-serif" class="sorting" HeaderStyle-Height="20px" BorderColor="#dddddd" OnPageIndexChanging="grdPageImages_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">
                                                                    <Columns>
                                                                       <%-- <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                                                            <HeaderTemplate>
                                                                                <input type="checkbox" onclick="SelectAll(this);" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Image" HeaderStyle-Width="70px">
                                                                            <ItemTemplate>
                                                                                <img src='<%#Eval("ImageUrl")%>' width="100" height="100" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Absolute Url" HeaderStyle-Width="100px">
                                                                            <ItemTemplate>
                                                                                <a href='<%#Eval("ImageUrl")%>' target="_blank">www.inlandandalucia.com<%#Eval("ImageUrl")%></a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Relative Url" HeaderStyle-Width="100px">
                                                                            <ItemTemplate>
                                                                                <%#Eval("ImageUrl")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--   <asp:TemplateField HeaderText="Date Created" HeaderStyle-Width="100px">
                                                                            <ItemTemplate>
                                                                                <%#Eval("DateCreated")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="25px" HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnDeltePageImage" runat="server" CommandName="DeleteImage" OnClientClick="javascript: return confirm('Are you sure you want to delete this image ? ');"  CommandArgument='<%#Eval("ImageId")%>' class="btn green" Text="Delete" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row"  id="divLocalInformation" runat="server" visible="false">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Local Information: </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtLocalInformation" runat="server" class="form-control tinymcereq" Placeholder="Local Information" TextMode="MultiLine" Rows="25"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="divider">
                                        &nbsp;
                                    </div>
                                    <div class="row"  id="divMainDescription" runat="server" visible="false">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Main Description:</label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtMainDescription" runat="server" class="form-control  tinymcereq" Placeholder="Main Description" TextMode="MultiLine" Rows="45"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="divider">
                                        &nbsp;
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Meta Title:</label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtMetaTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                  
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Meta Description:</label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtMetaDescription" runat="server" TextMode="MultiLine" Rows="10" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions" id="TableRowSave" runat="server">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="text-right">
                                                    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" OnClientClick="return Validations();" UseSubmitBehavior="true" CssClass="btn green" />
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
    </div>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
