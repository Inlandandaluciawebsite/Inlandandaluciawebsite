<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="contactus.aspx.vb" Inherits="contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="upcontact" runat="server">
        <ContentTemplate>
            <!-- Main Content Area Start -->

            <!-- Left Portion Start -->
            <div class="col-md-8" id="contact" style="display: block" runat="server">
                <!-- Contact Page Start -->
                <div class="row">
                    <div class="col-md-12">
                        <div class="town-guide-hd">
                            <h1>
                                <asp:Literal ID="Literal1" Text="<%$Resources:Resource, ContactUs %>" runat="server"></asp:Literal></h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="contact-bg">
                            <p>
                                <asp:Literal ID="Literal6" Text="<%$Resources:Resource, ContactUswhateveryour%>" runat="server"></asp:Literal>

                            </p>
                            <p>
                                <asp:Literal ID="Literal2" Text="<%$Resources:Resource, ContactUswepride%>" runat="server"></asp:Literal>
                            </p>
                            <p>
                                <asp:Literal ID="Literal3" Text="<%$Resources:Resource, ContactUspleasefillbelow%>" runat="server"></asp:Literal>
                                <strong>
                                    <asp:Literal ID="Literal4" Text="<%$Resources:Resource, ContactUspleasefillat%>" runat="server"></asp:Literal>
                                </strong>
                                <asp:Literal ID="Literal5" Text="<%$Resources:Resource, ContactUsheadoffice%>" runat="server"></asp:Literal><a href="skype:inlandandalucia.com?call">
                                    <img src="/images/skype_button.png"></a><asp:Literal ID="Literal7" Text="<%$Resources:Resource, ContactUscontactsoon%>" runat="server"></asp:Literal>
                            </p>

                            <div class="divider">
                                <img src="/images/divider.png">
                            </div>

                            <div class="form-outer">
                                <div class="form-bg form-horizontal">
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal8" Text="<%$Resources:Resource, ContactUsfname%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">

                                            <asp:TextBox ID="TextBoxFirstName" runat="server" class="form-control widthcontact"></asp:TextBox>
                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="rpfirstname" runat="server" ErrorMessage="<%$Resources:Resource, Validationfirstname%>" ForeColor="Red" ControlToValidate="TextBoxFirstName" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal9" Text="<%$Resources:Resource, ContactUslastname%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TextBoxLastName" runat="server" class="form-control widthcontact"></asp:TextBox>

                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="rplastname" runat="server" ErrorMessage="<%$Resources:Resource, Validationlastname%>" ForeColor="Red" ControlToValidate="TextBoxLastName" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal10" Text="<%$Resources:Resource, ContactUsaddress%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TextBoxAddress" runat="server" class="form-control widthcontact"></asp:TextBox>


                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal11" Text="<%$Resources:Resource, ContactUstelephone%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">

                                            <asp:TextBox ID="TextBoxTelephone" runat="server" class="form-control widthcontact"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal12" Text="<%$Resources:Resource, ContactUsemail%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TextBoxEmail" runat="server" class="form-control widthcontact"></asp:TextBox>
                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$Resources:Resource, Validationemail%>" ForeColor="Red" ControlToValidate="TextBoxEmail" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rpemail" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="<%$Resources:Resource, Validationemailvalid%>" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="Group1"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal13" Text="<%$Resources:Resource, ContactUscomments%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TextBoxComment" runat="server" TextMode="MultiLine" class="form-control widthcontact" Rows="8"></asp:TextBox>
                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="rpcomment" runat="server" ErrorMessage="<%$Resources:Resource, Validationcomment%>" ForeColor="Red" ControlToValidate="TextBoxComment" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="LabelComment" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group" style="font-size:20px;">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal16" Text="Captcha" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:Label ID="lblFirstCaptchaValue" runat="server" Font-Bold="true"></asp:Label>
                                            <b>+</b>
                                        <asp:Label ID="lblSecondCaptchaValue" runat="server" Font-Bold="true"></asp:Label>
                                            <b>=</b>
                                            <asp:TextBox ID="txtCaptchaValue" runat="server"></asp:TextBox> *
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter captcha value" Font-Size="14px" ForeColor="Red" ControlToValidate="txtCaptchaValue" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblCaptchaMessage" runat="server"  Font-Size="14px"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-sm-10 col-sm-offset-2">
                                        <p>
                                            * =
                                            <asp:Literal ID="Literal14" Text="<%$Resources:Resource, ContactUsmandatoryfield%>" runat="server"></asp:Literal>
                                        </p>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            <%--      <button type="submit" class="btn btn-default but-sub">Send The Form</button>--%>
                                            <asp:Button ID="btnSendMessage" runat="server" class="btn btn-default but-sub" Text="<%$Resources:Resource, ContactUsSendtheform%>" OnClick="btnSendMessage_Click" ValidationGroup="Group1" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Form End -->


                            <div class="divider">
                                <img src="/images/divider.png">
                            </div>

                            <!-- iqr code start -->

                <div class="row">
                    <div class="iqr-code-bg">
                        <div class="col-md-12">
                            <p>
                                <asp:Literal ID="Literal15" Text="<%$Resources:Resource, ContactOfficesScanbelow%>" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="col-md-2 col-sm-4">
                            <div class="qr-monilla">
                                <img src="/images/qr_inlandandalucia_mollina.png" />
                                <h3>Mollina Office</h3>
                            </div>
                        </div>
                        <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_jaen.png" />
                                <h3>Alcala La Real Office</h3>
                            </div>
                        </div>
                       <%-- <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_axarquia.png" />
                                <h3>Axarquia Office</h3>
                            </div>
                        </div>--%>
                        <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_martos.png" />
                                <h3>Martos Office</h3>
                            </div>
                        </div>
                        <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_lucena.jpg" />
                                <h3>Lucena Office</h3>
                            </div>
                        </div>
                       <%-- <div class="col-md-2 col-sm-4">
                            <div class="jaén-office">
                                <img src="/images/qr_inlandandalucia_osuna.jpg" />
                                <h3>Osuna Office</h3>
                            </div>
                        </div>--%>
                    </div>
                </div>

                            <!-- iqr code start -->

                        </div>
                    </div>
                </div>

                <!-- Contact Page Start -->
            </div>
            <!-- Left Portion End -->
            <div class="col-md-8" id="thanku" style="display: none" runat="server">
                <div class="row">
                    <h1>
                        <img src="/images/icons/thank-you-icon.jpg" alt="Thank you" height="142" hspace="10" align="left" />Thank you for submitting your comment </h1>
                    <p>A member of our team will be in touch with you shortly!</p>

                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Scripts -->
    <script>
        function rand(captcha_str, fin) {
            captcha_str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+{}:,./;][=-";
            fin = Math.floor(Math.random() * captcha_str.length);
            for (let i = 0; i < 24; i++) {
                fin += captcha_str[Math.floor(Math.random() * 85)];
            }
            //console.log(captcha_str.length);
            return fin;
        }
        var doc = document.getElementById("captcha");
        doc.innerHTML = (rand());
    </script>

    <!-- Main Content Area End -->
</asp:Content>

