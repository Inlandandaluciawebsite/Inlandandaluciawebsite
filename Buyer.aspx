<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Buyer.aspx.vb" Inherits="Buyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href='<%= ResolveUrl("~/css/PayPal.css") %>' rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src='<%= ResolveUrl("~/js/Validation.js") %>'></script>
    <script type="text/javascript" lang="javascript">
        function validations() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += validateEmailWithMsg(document.getElementById('<%=txtEmail.ClientID%>'), "Please enter email address");
            IsError += ValidateRequiredField(document.getElementById('<%=txtForename.ClientID%>'), "Please enter first name");
            if (IsError.length > 0) {
                alert(IsError);
                return false;
            }
            return true;
        }
    </script>
    <style>
        input#ContentPlaceHolder1_btnStripe {
            outline: none;
            padding: 10px 0px;
            outline: none;
            max-width: 100%;
            border: 2px solid #0008ff !important;
            border-radius: 7px;
        }

        a.form-cancel {
            background: #ffffff;
            border: 2px solid #0008ff;
            color: red;
            text-transform: uppercase;
            float: right;
            padding: 14px 33px;
            border-radius: 7px;
            text-decoration: none;
            font-weight: bold;
        }

        a#ContentPlaceHolder1_lnkReserve {
            padding: 3px 20px;
        }

        a.form-cancel img {
            max-width: 73px;
            display: block;
        }

        @media (max-width:991px) {
            .contact-bg .form-actions {
                text-align: center;
            }

                .contact-bg .form-actions .col-md-2 {
                    display: inline-block;
                }
        }

        #ContentPlaceHolder1_lnkReserve {
            padding: 3px 20px;
        }

            #ContentPlaceHolder1_lnkReserve::after {
                display: block;
                height: 21px;
                width: 73px;
                content: "";
                background-image: url("https://inlandandalucia.com/images/stripeimg.gif");
                background-size: contain;
                background-repeat: no-repeat;
            }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="manageAdmins" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="manageAdmins"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="overlay" id="divProgress">
                        &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" ImageUrl="/AdminNew/images/ajaxloading.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="col-md-8 buyer-paypal contact-bg">
                <div class="row">
                    <div class="col-md-12">
                        <div class="town-guide-hd">
                            <h1>
                                <asp:Literal ID="ltrlBuyerTitle" runat="server" Text="<%$Resources:Resource,     ReserveForViewing%>"></asp:Literal>
                            </h1>
                            <hr style="margin-top: 10px; margin-bottom: 10px;" />
                            <p>
                                <asp:Literal ID="ltrlOnReceiptTitle" runat="server" Text="<%$Resources:Resource,     ReserveForViewingOnReceiptTitle%>"></asp:Literal>
                            </p>
                            <br />
                            <div runat="server" id="divSueccess">
                                <asp:Label runat="server" ID="lblProperty"></asp:Label>
                                <asp:Label runat="server" ID="lblBookedMsg"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label col-md-3">Email: <span style="color: red;">*</span></label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" AutoPostBack="true" autocomplete="autocomplete_off_hack_xfr4!k" CssClass="form-control" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label col-md-3">Forename: <span style="color: red;">*</span> </label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtForename" runat="server" MaxLength="30" autocomplete="autocomplete_off_hack_xfr4!k" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label col-md-3">Surname: </label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtSurname" runat="server" MaxLength="30" autocomplete="autocomplete_off_hack_xfr4!k" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label col-md-3">Address: </label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="250" autocomplete="autocomplete_off_hack_xfr4!k" CssClass="form-control" Rows="3" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label col-md-3">Telephone:</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtTelephone" runat="server" MaxLength="15" autocomplete="autocomplete_off_hack_xfr4!k" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label col-md-3"></label>
                            <div class="col-md-6">
					<asp:TextBox ID="txtNotes" runat="server" MaxLength="2000" Rows="1" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-2">
                            <%--<a href="Default.aspx" class="form-cancel">'<%$Resources:Resource,  BuyerReserveForViewingCancel%>'</a>--%>
                            <asp:HyperLink ID="hlnkCancel" runat="server" CssClass="form-cancel" Text='<%$Resources:Resource,  BuyerReserveForViewingCancel%>' NavigateUrl="Default.aspx"></asp:HyperLink>
                        </div>
                        &nbsp;
                        <div class="col-md-2">
                            <div class="text-center">
                                <asp:LinkButton ID="lnkReserve" Style="background: #ffffff; border: 2px solid #0008ff; color: green; text-transform: uppercase; float: right; border-radius: 7px; text-decoration: none; font-weight: bold;" runat="server" Text='<%$Resources:Resource,  BuyerReserveForViewingReserve%>' CssClass="form-cancel" OnClientClick="return validations();" ToolTip="Proceed with Stripe">
                                   
                                </asp:LinkButton>
                                <%--<img src='<%= ResolveUrl("~/images/stripeimg.gif") %>' />--%>
                                <%--<asp:ImageButton runat="server" ID="btnStripe" ImageUrl="images/stripeimg.gif" BorderColor="#206df0" OnClientClick="return validations();" ToolTip="Proceed with Stripe" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

