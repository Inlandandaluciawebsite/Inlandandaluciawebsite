<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="Utility.aspx.vb" Inherits="AdminNew_Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="manageAdmins" runat="server">
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
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="Index.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="FeedLogs.aspx">Utility Programs</a>
                    </li>
                </ul>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box blue-hoki">
                        <div class="portlet-title">
                            <div class="caption" style="color: black; font-weight: bold;">Utility - Swap Properties</div>
                            <div class="tools"></div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                                <div class="row">
                                </div>
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <td width="20%">Property Refernce From </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtPropertyReferenceFrom" runat="server"></asp:TextBox></td>
                                                <td width="20%">Property Refernce To </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtPropertyReferenceTo" runat="server"></asp:TextBox></td>
                                                <td width="20%">
                                                    <asp:Button ID="btnSwap" runat="server" Text="Swap" OnClick="btnSwap_Click" />
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="portlet box blue-hoki">
                        <div class="portlet-title">
                            <div class="caption" style="color: black; font-weight: bold;">Utility - Rename Child Files / Folders</div>
                            <div class="tools"></div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                                <div class="row">
                                </div>
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <td width="20%">Property Refernce </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtPropertyReferenceToRename" runat="server"></asp:TextBox></td>
                                                <td width="20%">
                                                    <asp:Button ID="btnDoRename" runat="server" Text="Rename" OnClick="btnDoRename_Click" />
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="portlet box blue-hoki">
                        <div class="portlet-title">
                            <div class="caption" style="color: black; font-weight: bold;">Utility - Remove Property & Child Records</div>
                            <div class="tools"></div>
                        </div>
                        <div class="portlet-body">
                            <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">
                                <div class="row">
                                </div>
                                <div class="table-scrollable">
                                    <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                        <thead>
                                            <tr role="row" style="border: 1px solid #ddd">
                                                <td width="20%">Property Refernce </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtPropReference" runat="server"></asp:TextBox></td>
                                                <td width="20%">
                                                    <asp:Button ID="btnRemoveProperty" runat="server" Text="Rename" OnClick="btnRemoveProperty_Click" />
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="portlet box blue-hoki">
                        <div class="portlet-title">
                            <div class="caption" style="color: black; font-weight: bold;">Generate Property References - From Buyer Notes Column Of Buyer Table <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" /></div>
                            <div class="tools"></div>
                        </div>
                        
                    </div>
                     <div class="portlet box blue-hoki">
                        <div class="portlet-title">
                            <div class="caption" style="color: black; font-weight: bold;">Insert into property history by getting property refs from buyer table<asp:Button ID="bnInsertPropertyHistory" runat="server" Text="Generate" OnClick="bnInsertPropertyHistory_Click" /></div>
                            <div class="tools"></div>
                        </div>
                        
                    </div>
                     <div class="portlet box blue-hoki">
                        <div class="portlet-title">
                            <div class="caption" style="color: black; font-weight: bold;">Generate Latitude Longitude For Postcode File<asp:Button ID="btnGenerateLatLong" runat="server" Text="Generate" OnClick="btnGenerateLatLong_Click" />
                                <asp:Label ID="lblAddressComponent" runat="server"></asp:Label>

                            </div>
                            <div class="tools"></div>
                        </div>
                        
                    </div>
                     <div class="portlet box blue-hoki">
                        <div class="portlet-title">
                            <div class="caption" style="color: black; font-weight: bold;">Convert Image Watermark Position<asp:Button ID="btnWatermarkPosition" runat="server" Text="Generate" OnClick="btnWatermarkPosition_Click" /></div>
                            <div class="tools"></div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

