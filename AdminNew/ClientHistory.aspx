<%@ Page Title="" Language="VB" MasterPageFile="~/AdminNew/Admin.master" AutoEventWireup="false" CodeFile="ClientHistory.aspx.vb" Inherits="Admin_ClientHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN EXAMPLE TABLE PORTLET-->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">Client History</div>
                    <div align="right" class="right">
                        <a class="btn green mrgtp" href="javascript:window.history.back();" role="button">

                            <i class="fa fa-arrow-left" aria-hidden="true"></i>
                            <asp:Literal ID="Literal13" Text="Back" runat="server"></asp:Literal></a>
                    </div>

                </div>
                <div class="portlet-body">
                    <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">



                        <div class="table-scrollable">
                            <table class="table table-striped table-bordered table-hover dataTable no-footer" style="border: 1px solid #ddd" id="sample_1" role="grid" aria-describedby="sample_1_info">
                                <thead>
                                    <tr role="row" style="border: 1px solid #ddd">
                                        <asp:GridView ID="grdBuyerHistory" runat="server" AutoGenerateColumns="False" Width="100%"
                                            DataKeyNames="History_ID" AllowPaging="True" AllowSorting="true" PageSize="10" HeaderStyle-BackColor="#2D3091" HeaderStyle-ForeColor="White" RowStyle-Height="50" OnSorting="grdBuyerHistory_Sorting" OnRowCommand="grdBuyerHistory_RowCommand" OnPageIndexChanging="grdBuyerHistory_PageIndexChanging">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Created" SortExpression="Create_Date">
                                                    <ItemTemplate>
                                                        <%#Eval("Create_Date")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ActionDate" SortExpression="Action_Date">
                                                    <ItemTemplate>
                                                        <%#Eval("Action_Date")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Buyer ForeName" ItemStyle-HorizontalAlign="center" SortExpression="Buyer_ForeName">
                                                    <ItemTemplate>
                                                        <%#Eval("Buyer_ForeName")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" VerticalAlign="top" Width="400px" />
                                                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="400px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Buyer Surname" ItemStyle-HorizontalAlign="center" SortExpression="Buyer_Surname">
                                                    <ItemTemplate>
                                                        <%#Eval("Buyer_Surname")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" VerticalAlign="top" Width="400px" />
                                                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="400px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Created By" SortExpression="CreatedBy">
                                                    <ItemTemplate>
                                                        <%#Eval("CreatedBy")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action Type" SortExpression="Type">
                                                    <ItemTemplate>
                                                        <%#Eval("Type")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action Status" SortExpression="Action_Status">
                                                    <ItemTemplate>
                                                        <%#Eval("Action_Status")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="History" ItemStyle-HorizontalAlign="Center" SortExpression="History_Text">
                                                    <ItemTemplate>
                                                        <%#Eval("ShortHistory_Text")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="400px" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" SortExpression="History_Text">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkview" runat="server" Text="View" ToolTip="Click here to read full history text!!" data-target="#dialog" CommandName="moreinfo" CommandArgument='<%#Eval("History_ID")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" Width="400px" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>
                                            <PagerStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="Grid_HeaderStyle" />
                                            <RowStyle CssClass="GridItemStyle" />
                                            <AlternatingRowStyle CssClass="Grid_ItemStyle" />
                                        </asp:GridView>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>

                            </table>

                        </div>

                    </div>
                </div>
                <div id="dialog" style="width: 1000px; display: none">


                    <div class="row">
                        <div class="col-md-12">
                            <h1>Client History</h1>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-12">
                            <div class="col-lg-12">
                                <p>CreateDate:<asp:Label ID="lblCreateDate" runat="server"></asp:Label></p>
                                <p>
                                    Buyer Forename:  
                                                                    <asp:Label ID="lblBuyerForename" runat="server"></asp:Label>
                                </p>
                                <p>Buyer Surname:<asp:Label ID="lblBuyerSurname" runat="server"></asp:Label></p>

                                <p>
                                    ActionDate: 
                                                                    <asp:Label ID="lblActionDate" runat="server"></asp:Label>
                                </p>
                                <p>
                                    Type: 
                                                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                </p>
                                <p>
                                    Created By: 
                                                                    <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
                                </p>
                                <p class="text-left">
                                    History:
                                                                    <asp:Label ID="lblHistoryText" runat="server"></asp:Label>
                                </p>
                            </div>
                        </div>


                    </div>


                </div>
            </div>



        </div>
    </div>

</asp:Content>

