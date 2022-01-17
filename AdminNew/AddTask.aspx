<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="AddTask.aspx.vb" Inherits="Admin_AddTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" lang="javascript">
        function Validations() {
            
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredField(document.getElementById('<%=txtTaskTitle.ClientID%>'), "Title Field is Required");
            IsError += ValidateRequiredField(document.getElementById('<%=txtEstimatedTime.ClientID%>'), "Estimated Time Field is Required");

            var assignedToField = $("#ContentPlaceHolder1_assigntodropdown option:selected").text();
            if (assignedToField == "Please Select") {
                alert("Please select Assigned To");
                return false;
            }

            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }

    

        $(document).ready(function () {

        <% If Session("TaskStatus") = "true" Then%>


            alert("Can not change status because Dev Time is in progress")
             <% Session("TaskStatus") = ""%>

            window.location.href = "ManageTasks.aspx";

        <%End If%>

         <% If Session("AlreadyCompleted") = "true" Then%>

        alert("Can not change status because It is already completed")
        <% Session("AlreadyCompleted") = ""%>
            window.location.href = "ManageTasks.aspx";

        <%End If%>

        });
      
        

    </script>
    <style type="text/css">
        .textarea_control {
            display: flex;
            align-items: flex-start;
            justify-content: space-between;
            flex-wrap: wrap;
        }

            .textarea_control label.control-label {
                padding: 0px 15px;
                max-width: 117px;
                width: 100%;
            }

        .textarea_container {
            flex: 1 1 0;
            padding: 0px 15px;
        }

            .textarea_container textarea {
                max-height: 138px;
                min-height: 136px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <asp:UpdatePanel ID="upAddAdmin" runat="server">
        <ContentTemplate>--%>
    <%--            <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="upAddAdmin"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="overlay" id="divProgress">
                        &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="50"
                    Height="40" ImageUrl="images/ajaxloading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>


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
                                Add/Edit Task
                            </div>
                            <div align="right">
                                <a class="btn green mrgtp" href="ManageTasks.aspx" role="button">
                                    <i class="fa fa-arrow-left" aria-hidden="true"></i>
                                    <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                            </div>
                            <asp:HiddenField ID="hdcont" runat="server" />
                            <asp:HiddenField ID="hdnprevurl" runat="server" />
                            <asp:HiddenField ID="hdpageind" runat="server" />
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <%--  <form action="#" class="form-horizontal">--%>
                            <div class="form-body">
                                <h3 class="form-section"></h3>
                                <!--/row-->
                                <!--/row-->

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Type</label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="drpType" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="New Task" Value="New Task"></asp:ListItem>
                                                    <asp:ListItem Text="New Issue" Value="New Issue"></asp:ListItem>
                                                    <asp:ListItem Text="Existing Issue" Value="Existing Issue"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/span-->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Priority</label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="drpPriority" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                                                    <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                                    <asp:ListItem Text="High" Value="High"></asp:ListItem>
                                                    <asp:ListItem Text="Critical" Value="Critical"></asp:ListItem>
                                                   <%-- <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                  
                                    <!--/span-->
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Assigned By</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtAssignedBy" runat="server" Placeholder="Assigned By" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Assigned To </label>
                                            <div class="col-md-9">
                                                <%--<asp:TextBox ID="txtAssignedTo" runat="server" Placeholder="Assigned To" class="form-control"></asp:TextBox>--%>
                                                 <asp:DropDownList ID="assigntodropdown" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Sourabh" Value="Sourabh"></asp:ListItem>
                                                    <asp:ListItem Text="Jerome" Value="Jerome"></asp:ListItem>
                                                    <asp:ListItem Text="User" Value="User"></asp:ListItem>
                                                    <asp:ListItem Text="New Developer" Value="New Developer"></asp:ListItem>                              
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Title</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtTaskTitle" runat="server" Placeholder="Task Title" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Url / Link </label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtPageUrl" runat="server" Placeholder="Page URL / Link" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                              <div class="row">
                                    <div class="col-md-6">

                                         <div class="form-group">
                                            <label class="control-label col-md-3">Estimated Time</label>
                                            <div class="col-md-5">
                                                <asp:TextBox ID="txtEstimatedTime" runat="server" Placeholder="Task Estimated Time" class="form-control"></asp:TextBox>
                                           </div>
                                             <div class="col-sm-4">
                                                 <asp:DropDownList ID="EstimatedTimeDropdownList" runat="server" CssClass="form-control" >
                                                    <asp:ListItem Text="Hours" Value="Hours"></asp:ListItem>
                                                    <asp:ListItem Text="Minutes" Value="Minutes"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                               

                                    </div>
                                    <div class="col-md-4"></div>
                                 </div>


                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group textarea_control">
                                            <label class="control-label">Description </label>
                                            <div class="textarea_container">
                                                <asp:TextBox ID="txtDescription" runat="server" Placeholder="Task Description" Height="30" TextMode="MultiLine" MaxLength="50" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group textarea_control">
                                            <label class="control-label">Solution</label>
                                            <div class="textarea_container">
                                                <asp:TextBox ID="txtReason" runat="server" Placeholder="Task Solution" Height="30" TextMode="MultiLine" MaxLength="50" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row" id="divImageShow" runat="server" visible="false">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"></label>
                                            <div class="col-md-9">
                                                <asp:ImageButton ID="imgImage1" runat="server" Width="100" Height="100" OnClick="imgImage1_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3"></label>
                                            <div class="col-md-9">
                                                <asp:ImageButton ID="imgImage2" runat="server" Width="100" Height="100" OnClick="imgImage2_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Image 1</label>
                                            <div class="col-md-9">
                                                <asp:FileUpload ID="fucImage1" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Image 2 </label>
                                            <div class="col-md-9">
                                                <asp:FileUpload ID="fucImage2" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Status</label>
                                            <div class="col-md-9">
                                                <asp:DropDownList ID="drpStatus" runat="server" CssClass="form-control">
                                                       <asp:ListItem Text="Assigned" Value="Assigned"></asp:ListItem>
                                                    <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                                                 
                                                    <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-offset-3 col-md-9">

                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn green" OnClick="btnSubmit_Click" OnClientClick="return Validations();"></asp:Button>
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn green" OnClick="btnUpdate_Click" Style="display: none" OnClientClick="return Validations();"></asp:Button>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn default"></asp:Button>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                    </div>
                                </div>

                                <asp:HiddenField ID="hdnvenid" runat="server" />
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
        <!-- BEGIN QUICK SIDEBAR -->
        <!-- END QUICK SIDEBAR -->
        <!-- END CONTAINER -->
        <!-- BEGIN FOOTER -->
        <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
