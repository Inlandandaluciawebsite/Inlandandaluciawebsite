<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" ValidateRequest="false" AutoEventWireup="false" CodeFile="AddBlog.aspx.vb" Inherits="AdminNew_AddBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .tag {
            display: inline-block;
            font-size: 12px;
            height: 30px;
            line-height: 30px;
            border-radius: 4px;
            min-width: 10px;
            padding: 0 5px;
            margin-right: 5px;
            margin-bottom: 10px;
            border: 0;
            vertical-align: top;
            cursor: default;
            color: #F9CF06;
            background: #303194;
        }

            .tag .tag-name {
                padding: 0px 8px;
                display: inline-block;
            }

        .drp-style {
            margin-bottom: 10px;
            margin-left: 12px;
        }

        .tag .tag-delete, .tag .tag-add {
            display: inline-block;
            width: 30px;
            height: 30px;
            line-height: 30px;
            vertical-align: top;
            text-align: center;
            border-left: 1px solid #fff;
            border-bottom-right-radius: 4px;
            border-top-right-radius: 4px;
            margin-right: -6px;
            font-size: 20px;
            font-weight: 900;
            cursor: pointer;
        }

            .tag .tag-delete:hover, .tag .tag-add:hover {
                background-color: #fff;
            }

        .tag:hover {
            color: #303194;
            background: #f1f9fc;
        }
    </style>

    <link href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js" type="text/javascript"></script>
    <style type="text/css">
        .progressbar {
            width: 300px;
            height: 30px;
        }

        .progressbarlabel {
            width: 300px;
            height: 21px;
            position: absolute;
            text-align: center;
            font-size: small;
            margin: 5px 5px 5px 5px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtPostdate").datepicker();
            $("#ContentPlaceHolder1_fileimg").on("change", function (evt) {

                var data = new Array();
                var values = "";
                var newval = [];
                var files = $("#ContentPlaceHolder1_fileimg").get(0).files;
                values = $("#ContentPlaceHolder1_lblimg").val().split(",");
                alert(values);
                for (i = 0; i < values.length; i++) {
                    newval.push(values[i]);
                }
              //  alert(newval);
                for (var i = 0; i < files.length; i++) {
                    data.push(files[i].name);
                    newval.push(files[i].name);
                }
              //  alert(newval);
                $("#ContentPlaceHolder1_lblimg").val(newval);
                // var ObjUl = $('<ul></ul>');
                for (i = 0; i < data.length; i++) {

                    $(".mylist").append('<li><span>' + data[i] + '</span> <a href="#!" class="remove">Remove</a> <br/>(http://www.inlandandalucia.com/BlogImages/' + data[i] + ')</li>');
                }
                //  $('.DivSai').append(ObjUl);
            });


       
        });
        $(document).on("click", ".remove", function (e) {
            e.preventDefault();
            var fileName = $(this).parent().find("span").html();

            // loop through the files array and check if the name of that file matches FileName
            // and get the index of the match
            var filesToUpload = $("#ContentPlaceHolder1_fileimg").get(0).files;

            //for (i = 0; i < filesToUpload.length; i++) {

            //    if (filesToUpload[i].name == fileName) {
            //        //console.log("match at: " + i);
            //        // remove the one element at the index where we get a match
            //          filesToUpload.splice(i, 1);                   
            //    }    
            //}
            var values = "";
            var newval = [];
            values = $("#ContentPlaceHolder1_lblimg").val().split(",");
            //    alert(values);
            for (i = 0; i < values.length; i++) {
                if (values[i] != fileName) {
                    newval.push(values[i]);
                }
            }
            $("#ContentPlaceHolder1_lblimg").val(newval);
            alert($("#ContentPlaceHolder1_lblimg").val());

            //console.log(filesToUpload);
            // remove the <li> element of the removed file from the page DOM
            $(this).parent().remove();
        });
    </script>
    <script type="text/javascript" src="/tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
    <%--   <script src="js/taggle.min.js"></script>
   <script src="js/scripts.js"></script>--%>
    <script src="js/Validation.js"></script>
    <script type="text/javascript" lang="javascript">
  
    </script>

    <script>
        $(function () {
            //bind Cities
            $(document).off('click', '.lbbl').on('click', '.lbbl', function () {
                var a = "";
                var b = "";
                $(this).parent('.tag').remove();
                $('#<%=divlabel.ClientID%>').find('.tagcity').each(function () {
                    a = a + $(this).find('.city-name').text() + ',';
                });
                $('#<%=hdnlabel.ClientID%>').val(a);
                // alert( $('#<%=hdnlabel.ClientID%>').val(a));
            });
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {


                $('#<%=txtlabel.ClientID%>').keydown(function (event) {
                    if (event.keyCode == 13) {
                        event.preventDefault();
                        return false;
                    }
                });
                //city dropdown
                $('#<%=txtlabel.ClientID%>').change(function () {
                    var a = "";
                    var val = "";
                    var value = "";

                    var cityselect = $("#<%=txtlabel.ClientID%>").val();
                    if ($('#<%=divlabel.ClientID%>').find('.tagcity').length > 0) {
                        $('#<%=divlabel.ClientID%>').find('.tagcity').each(function () {
                            var selectedval = $("#<%=txtlabel.ClientID%>").val();

                            var existingval = $(this).find('.city-name').val();
                            if (selectedval.trim() == existingval.trim()) {
                                val = "exists";
                            }
                        });
                        if (val == "exists") {
                        }
                        else {
                            if (cityselect == "0") {
                            }
                            else {
                                $('#<%=divlabel.ClientID%>').append("<div class='tag tagcity'><span class='tag-name city-name'>" + $("#<%=txtlabel.ClientID%>").val() + "</span><span class='tag-delete lbbl'><i class='fa fa-times'></i></span></div>");

                                $("#ContentPlaceHolder1_txtlabel").val('');

                            }
                        }
                    }
                    else {
                        if (cityselect == "0") {
                        }
                        else {
                            $('#<%=divlabel.ClientID%>').append("<div class='tag tagcity'><span class='tag-name city-name'>" + $("#<%=txtlabel.ClientID%>").val() + "</span><span class='tag-delete lbbl'><i class='fa fa-times'></i></span></div>");
                            $("#ContentPlaceHolder1_txtlabel").val('');


                        }
                    }
                    $('#<%=divlabel.ClientID%>').find('.tagcity').each(function () {
                        a = a + $(this).find('.city-name').text() + ',';
                    });
                    $('#<%=hdnlabel.ClientID%>').val(a);
                });

            });
        });

        function IsRequired(ValueFirst, Errormesage) {
            var IsError = "";
            if ($(ValueFirst).find('.tagcity').length > 0) {
            }
            else {
                IsError = Errormesage + ".\n"
            }
            return IsError;
        }
    </script>


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
            <h3 class="page-title">Add Blog 
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AddBlog.aspx">Add Blog</a>
                    </li>
                </ul>
            </div>
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
                                <%-- <div class="portlet-title">
                                    <div class="caption">
                                        Add/Edit Blog
                                    </div>
                                </div>--%>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <%--  <form action="#" class="form-horizontal">--%>
                                    <div class="form-body">
                                        <h3 class="form-section"></h3>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Title</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txttitle" runat="server" Placeholder="Title" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Sub Title </label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtsubtitle" runat="server" Placeholder="Sub Title" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Image</label>
                                                    <div class="col-md-9">
                                                        <asp:HiddenField ID="lblimg" runat="server"></asp:HiddenField>
                                                        <asp:Image ID="imgblog" runat="server" AlternateText="images" Style="display: none; width: 100px; height: 100px" />
                                                        <asp:FileUpload ID="fileimg" runat="server" AllowMultiple="true" />
                                                        <ul class="mylist" runat="server" id="myllist"></ul>

                                                        <div id="progressbar" class="progressbar">
                                                            <div id="progresslabel" class="progressbarlabel">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Label</label>
                                                    <div class="col-md-9 example1">
                                                        <asp:HiddenField runat="server" ID="hdnlabel" />
                                                        <asp:TextBox ID="txtlabel" runat="server" Placeholder="Label" Style="height: auto" class="form-control lbl"></asp:TextBox>
                                                        <div id="divlabel" runat="server" class="drp-style">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <!--/span-->
                                        </div>

                                        <div class="row">

                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">PostDate</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPostdate" runat="server" Placeholder="Date" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Is Popular</label>
                                                    <div class="col-md-9">
                                                        <asp:CheckBox ID="chkIsPopular" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <!--/span-->
                                        </div>


                                        <div class="row">

                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Blog Url Title</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtblogurl" runat="server" placeholder="Blog Url Title" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                                    <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Language</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="drpLangugae" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="en" Value="en"></asp:ListItem>
                                                            <asp:ListItem Text="es" Value="es"></asp:ListItem>
                                                            <asp:ListItem Text="nl" Value="nl"></asp:ListItem>
                                                            <asp:ListItem Text="de" Value="de"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">

                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label col-md-3">Description</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Placeholder="Description" class="form-control tinymcereq"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                    
                                            <!--/span-->
                                        </div>

                                        <!--/row-->

                                        <!--/row-->
                                    </div>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn green" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none" OnClientClick="return Validations();"></asp:Button>
                                                   
                                                        <input type="button" id="svtranslation" value="Save Translation" class="btn green" />
                                                        
                                                             <%--     <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn default"></asp:Button>--%>
                                                    
                                                    <span id="trssave"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
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
        <Triggers>

            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
        </Triggers>
    </asp:UpdatePanel>
    <script>
        $(function () {
               $("#ContentPlaceHolder1_drpLangugae").on("change", function () {
            
                var langtype = $("#ContentPlaceHolder1_drpLangugae").val();
              //  alert(langtype);
                $.ajax({
                    type: "POST",
                    url: "AddBlog.aspx/GetLangChange",
                    data: '{langtype: "' + $("#<%=drpLangugae.ClientID%>")[0].value + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        data = data || {};
                        //console.log(data);
                      //  tinyMCE.triggerSave();
                    //    tinymce.get(tinymce_editor_id).setContent('');
                        $('#ContentPlaceHolder1_txtdescription').html();
                        $('#ContentPlaceHolder1_txtdescription').html(data.d);
                        tinyMCE.triggerSave();
                        tinyMCE.activeEditor.setContent((data.d));
                    }
                });
            })

            $("#svtranslation").click(function () {
                $("#trssave").html("");
                tinyMCE.triggerSave();
            var IsError = '';
            var invalid = " "; 
            IsError += ValidateRequiredField(document.getElementById('<%=txttitle.ClientID%>'), "Please enter title!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtdescription.ClientID%>'), "Please enter description!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtblogurl.ClientID%>'), "Please enter blog url title!");
            //  alert(content)
                    if (IsError.length > 0) {
                        alert(IsError);
                        return false;
                    }
                    else {
                        var langtype = $("#ContentPlaceHolder1_drpLangugae").val();
                     
                        var Title = $("#ContentPlaceHolder1_txttitle").val();
                        var SubTitle = $("#ContentPlaceHolder1_txtsubtitle").val();
                  //      var Description = $("#ContentPlaceHolder1_txtlabel").val();
                        var label = $("#ContentPlaceHolder1_drplanguage").val();
                     //   var PostedBy = $("#ContentPlaceHolder1_txtPostdate").val();
                        var PostedOn = $("#ContentPlaceHolder1_txtPostdate").val();
                     //   var IsActive = $("#ContentPlaceHolder1_txtpopuptitle").val();
                        var IsPopular = $("#ContentPlaceHolder1_chkIsPopular").val();
                        var BlogTitle = $("#ContentPlaceHolder1_txtblogurl").val();
                        //  var content = $("#ContentPlaceHolder1_txtpopuptinymce").val();

                        //var body = tinymce.get("tinymce").getBody();
                        //var content = tinymce.trim(body.innerText || body.textContent);

                        var Description = $('#ContentPlaceHolder1_txtdescription').val();
                        //     console.log(    $('textarea.tinymce').html('Some contents...'));
                       // alert(IsPopular);
                        $.ajax({
                            type: "POST",
                            url: "AddBlog.aspx/savelanguages",
                            data: JSON.stringify({ langtype, Title, SubTitle, Description, PostedOn }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",


                            success: function (data) {
                                data = data || {};
                                console.log(data);
                                $("#trssave").html("Translation Saved!");
                         
                            }

                        });
                    }
                })

        });

        function Validations() {
            tinyMCE.triggerSave();
            var istranslationsaved = $("#trssave").html();
               var IsError = '';
            var invalid = " "; 
            IsError += ValidateRequiredField(document.getElementById('<%=txttitle.ClientID%>'), "Please enter title!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtdescription.ClientID%>'), "Please enter description!");
            IsError += ValidateRequiredField(document.getElementById('<%=txtblogurl.ClientID%>'), "Please enter blog url title!");
            //  alert(content)
                    if (IsError.length > 0) {
                        alert(IsError);
                        return false;
                    }
            if (istranslationsaved.length > 0) {
                return true;
            }
            else {
                alert("please save translation first");
                return false;
            }

        }


    </script>
</asp:Content>
 