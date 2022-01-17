<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ManageTasks.aspx.vb" Inherits="Admin_ManageTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function SelectAll(id) {
            var k = document.getElementsByTagName('input');
            for (var i = 0; i < k.length; i++) {
                if (k[i].type == "checkbox") {
                    if (id.checked) {
                        k[i].checked = true;
                    }
                    else {
                        k[i].checked = false;
                    }
                }
            }
        }
        $(function () {
            $(document).off('click', '#ContentPlaceHolder1_BtnDelete').on('click', '#ContentPlaceHolder1_BtnDelete', function () {
                if ($("#ContentPlaceHolder1_grdTasks input:checkbox:checked").length > 0) {
                    if (confirm("Are you sure you want to delete!") == true) {
                        return true
                    }
                    else {
                        return false;
                    }
                }
                else {
                    alert("Please select atleast one checkbox to Delete Record");
                    return false;
                }

            });
        });


        //burrons enable and disable code 

        //$(document).ready(function () {

        //    console.log("document ready called");
        //    $(".btn-resume").hide();
        //    console.log("resume btn hide");
        //    $(".btn-start").attr("disabled", false);
        //    $(".btn-pause").attr("disabled", true);
        //    $(".btn-end").attr("disabled", true);

                    

        //    $(".btn-pause").on('click', function () {
        //         console.log("pause button clicked");
        //        $(this).hide();
        //        $(".btn-resume").show();
               
        //    });

        //    $(".btn-pause").on('click', function () {
        //         console.log("resume button clicked");
        //        $(this).hide();
        //        $(".btn-resume").show();
               
        //    });

        //    $(".btn-end").on('click', function () {
        //        $(".btn-start").hide();
        //        $(".btn-resume").hide();
        //        $(".btn-pause").hide();
        //        $(".btn-end").hide();
        //        console.log("start button disabled");
        //    });

        //});


        //$(document).ready(function () {

          
        //   $(".btn-resume").hide();
        //   console.log("resume btn hide");
        //   $(".btn-start").attr("disabled", false);
        //   $(".btn-pause").attr("disabled", true);
        //   $(".btn-end").attr("disabled", true);
        //});


        //function Start_btn_clicked() {
            
        //    $(this).attr("disabled", true);
        //    $(".btn-pause").attr("disabled", false);
        //    $(".btn-end").attr("disabled", false);
           
        //}

        function postclick(args) {


            $(".clspager").find("td").find("table").find("tbody").find("tr").find("td").each(function () {

                var vl = $(this).find("a").html();

                if (vl == args) {


                    __doPostBack('ctl00$ContentPlaceHolder1$grdTasks', 'Page$' + args)

                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="manageAdmins" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="manageAdmins"
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
                        <a href="ManageUsers.aspx">ClientSearch </a>
                    </li>
                </ul>
            </div>--%>

            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">Task Search </div>

                            <div align="right" class="right">

                                <%--<asp:Button ID="ButtonSearch" ToolTip="click here to search by First Name,Last Name and Archived ..!!" runat="server" class="btn green srchvendsrch mrgtp " Text="Search"></asp:Button>--%>
                                <a class="btn green mrgtp left " href="javascript:window.history.back();" role="button">

                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">

                                <%-- <div class="row">
                                    <div class="col-md-12">
                                        <ul class="clnt-search">

                                            <li>
                                                <asp:DropDownList ID="drpUser" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </li>
                                            <li>
                                                <asp:DropDownList ID="DropDownListSource" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </li>
                                            <li>
                                                <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </li>
                                        </ul>
                                    </div>
                                </div>--%>
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                       
                                            <tr role="row" style="border: 1px solid #ddd">

                                                <asp:GridView ID="grdTasks" DataKeyNames="TaskId" OnRowDataBound="grdTasks_RowDataBound" AllowPaging="true" PageSize="10" Font-Names="Open Sans, sans-serif" class="sorting  table-hover " HeaderStyle-Height="20px" BorderColor="#dddddd" OnRowCommand="grdTasks_RowCommand" OnPageIndexChanging="grdTasks_PageIndexChanging" TabIndex="0" runat="server" AutoGenerateColumns="false" Width="100%">

                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thwdth">
                                                            <HeaderTemplate>
                                                                <input type="checkbox" onclick="SelectAll(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Title" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("Title") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Estimated Time" HeaderStyle-Width="219px" HeaderStyle-Height="20px">
                                                            <ItemTemplate>                                                                                                                                                  
                                                                      <%# Eval("EstimatedTimeNumber")%> <%#Eval("EstimatedTimeText") %>    
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Assigned To" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("AssignedTo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Assigned By" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("AssignedBy")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Type" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("TaskType")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Priority" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("TaskPriority")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="219px">
                                                            <ItemTemplate>
                                                                <%#Eval("TaskStatus")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Actions" HeaderStyle-Width="300px">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="TaskHidden" runat="server" Value='<%#Eval("TaskId") %>' />
                                                                <asp:Button ID="startbtn" Text="Start" runat="server" CommandArgument='<%#Eval("TaskId") %>' ToolTip="Click to start the task"  OnClick="StartButton_Click" CommandName="startTask" class="btn btn-primary btn-sm btn-start"/>
                                                                <asp:Button ID="pausebtn" Text="Pause" runat="server" CommandArgument='<%#Eval("TaskId") %>' ToolTip="Click to pause the task" OnClick="StartButton_Click" CommandName="pauseTask" class= "btn btn-Secondary btn-sm btn-pause" />
                                                                <asp:Button ID="resumebtn" Text="Resume" runat="server" CommandArgument='<%#Eval("TaskId") %>' ToolTip="Click to resume the task" OnClick="StartButton_Click" CommandName="resumeTask" class="btn btn-info btn-sm btn-resume"/>                                                               
                                                                <asp:Button ID="endbtn" Text="Finish" runat="server" CommandArgument='<%#Eval("TaskId") %>' ToolTip="Click to start the task" OnClick="StartButton_Click" CommandName="endTask" class="btn btn-success btn-sm btn-end"/>
                                                                  <asp:label ID="finishlabel"  runat="server"></asp:label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                           <asp:TemplateField HeaderText="Dev. Time" HeaderStyle-Width="200px">
                                                            <ItemTemplate>
                                                                 <asp:label ID="textlabel"  runat="server"></asp:label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Pause" HeaderStyle-Width="46px">
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="End" HeaderStyle-Width="46px">
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="View" HeaderStyle-Width="46px">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgView" runat="server" CommandArgument='<%#Eval("TaskId") %>' ToolTip="Click to edit or view this task " CommandName="editadmin" ImageUrl="~/Admin/images/view-img.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="clspager hvrexlude" />
                                                </asp:GridView>
                                            </tr>
                                        </thead>

                                    </table>


                                    <div align="right">


                                        <strong>
                                            <asp:Label ID="LabelNoResults" runat="server" Text="No Results Found" Visible="false"></asp:Label></strong>
                                        <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Text="No Record Found!" Visible="false"></asp:Label>
                                        <asp:Button ID="BtnDelete" runat="server" class="btn green" Text="Delete" Visible="false" OnClick="BtnDelete_Click"
                                            OnClientClick="javascript: return validateCheckBoxes()" />
                                    </div>

                                </div>
                            </div>
                        </div>



                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

