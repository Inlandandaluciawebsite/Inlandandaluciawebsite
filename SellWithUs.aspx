<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="SellWithUs.aspx.vb" Inherits="SellWithUs" %>

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
                                <asp:Literal ID="Literal1" Text="Let us Sell your property" runat="server"></asp:Literal></h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="contact-bg">
                            <p>
                                <asp:Literal ID="Literal6" Text="We are Andalucia’s largest most trusted Estate Agent, established for more than 20 years, we have sold 1,000’s of properties across all of Inland Andalucia. " runat="server"></asp:Literal>

                            </p>
                            <p>
                                <asp:Literal ID="Literal2" Text="We advertise across more than 30 online portals across all of Europe and publish on all the main Social Media platforms including Facebook reaching over 100,000 people a month, Telegram Instagram and YouTube getting over 70,000 views each month. We also send weekly newsletters to over 14,500 subscribers watching new listings and price drops. This marketing provides us with more than 550 new buyer enquiries each month." runat="server"></asp:Literal>
                            </p>
                            <p>
                                <asp:Literal ID="Literal3" Text="Our professional multilingual listing staff use the very latest in digital technology to take high quality photographs and videos of your property." runat="server"></asp:Literal>
                                <a href="/propertytestimonials.aspx" target="_blank"> See what our Vendors and Clients say.</a>

                            </p>
                            <p>
                                We have an extensive database of clients ready to purchase property in Andalucia and our property experts are constantly informing buyers of the latest deals to be had.
                            </p>
                            <p>
                                Selling your property through us you’re in Safe Hands.
                                <br />
                                Please fill in the form below and we will contact you as soon as possible or call <b>+34 952 741 525</b>

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
                                            <asp:Literal ID="Literal4" Text="Property Location:" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtPropertyLocation" runat="server" class="form-control widthcontact"></asp:TextBox>
                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter property location !" ForeColor="Red" ControlToValidate="txtPropertyLocation" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal13" Text="Property Details" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtPropertyDetails" runat="server" TextMode="MultiLine" class="form-control widthcontact" Rows="8"></asp:TextBox>
                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="rpcomment" runat="server" ErrorMessage="Please enter property details !" ForeColor="Red" ControlToValidate="txtPropertyDetails" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="LabelComment" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group" style="font-size: 20px;">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal16" Text="Captcha" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:Label ID="lblFirstCaptchaValue" runat="server" Font-Bold="true"></asp:Label>
                                            <b>+</b>
                                            <asp:Label ID="lblSecondCaptchaValue" runat="server" Font-Bold="true"></asp:Label>
                                            <b>=</b>
                                            <asp:TextBox ID="txtCaptchaValue" runat="server"></asp:TextBox>
                                            *
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter captcha value" Font-Size="14px" ForeColor="Red" ControlToValidate="txtCaptchaValue" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblCaptchaMessage" runat="server" Font-Size="14px"></asp:Label>
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

         

                        </div>
                    </div>
                </div>

                <!-- Contact Page Start -->
            </div>
            <!-- Left Portion End -->
            <div class="col-md-8" id="thanku" style="display: none" runat="server">
                <div class="row">
                    <h1>
                        <img src="/images/icons/thank-you-icon.jpg" alt="Thank you" height="142" hspace="10" align="left" />Thank you for submitting your request. </h1>
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

