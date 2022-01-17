<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="Franchise.aspx.vb" Inherits="Franchise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="CSS/grt-youtube-popup.css">
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
                                <asp:Literal ID="Literal1" Text="FRANCHISE PROFILE" runat="server"></asp:Literal></h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="contact-bg">
                            <p>
                                <asp:Literal ID="Literal6" Text="If you are inspired by real estate business." runat="server"></asp:Literal>
                            </p>
                            <p>
                                <asp:Literal ID="Literal2" Text="You like the south of Spain (Andalucia) and living in a calm town as part of a community and you are dreaming for a life changing experience, then we have the perfect chance for you. 
"
                                    runat="server"></asp:Literal>
                            </p>
                            <p>
                                <b>INLAND ANDALUCIA FRANCHISE</b>
                                <asp:Literal ID="Literal3" Text=" offers you the opportunity to start a new life in Andalucía plenty of sun and stress free lifestyle, surrounded by nature and a very good income, with no ceiling on your earnings. 
"
                                    runat="server"></asp:Literal>
                            </p>
                            <p>
                                <b>INLAND ANDALUCIA</b><asp:Literal ID="Literal4" Text=" is a self-employment business ideal for an individual or family with the following requirements:" runat="server"></asp:Literal>
                            </p>
                            <p>
                                * English native speaking.
                                <br />
                                * Commercial attitude.
                                <br />
                                * Basic Computer skills.
                                <br />
                                * Economic solvency.
                                <br />
                                * Country lover.
                                <br />
                                * Willing to be a part of a network.
                                <br />
                                <br />
                                It would be advantageous to have real estate experience and being Spanish speaking<br />
                            </p>
                            <p>
                            </p>
                            <p>

                                <div class="watch-video">
                                    <div id="ContentPlaceHolder1_vidio">
                                        <b>Want to know more ?</b>    <a href="#" class="youtube-link-dark" youtubeid="NOK9--3_YYQ">
                                            <img src="/images/watch-video.gif" alt="Video" border="0" hspace="5"></a>
                                        <b>OR
                                You can complete the form below and we will make contact to arrange a meeting : </b>
                                    </div>
                                </div>
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

                                            <asp:TextBox ID="txtFirstName" runat="server" class="form-control widthcontact"></asp:TextBox>
                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="rpfirstname" runat="server" ErrorMessage="<%$Resources:Resource, Validationfirstname%>" ForeColor="Red" ControlToValidate="txtFirstName" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal9" Text="<%$Resources:Resource, ContactUslastname%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtLastName" runat="server" class="form-control widthcontact"></asp:TextBox>

                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="rplastname" runat="server" ErrorMessage="<%$Resources:Resource, Validationlastname%>" ForeColor="Red" ControlToValidate="txtLastName" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal10" Text="<%$Resources:Resource, ContactUsaddress%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtAddress" runat="server" class="form-control widthcontact"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal11" Text="<%$Resources:Resource, ContactUstelephone%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">

                                            <asp:TextBox ID="txtTelephone" runat="server" class="form-control widthcontact"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal12" Text="<%$Resources:Resource, ContactUsemail%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">

                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control widthcontact"></asp:TextBox>
                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$Resources:Resource, Validationemail%>" ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="rpemail" runat="server" ControlToValidate="txtEmail" ErrorMessage="<%$Resources:Resource, Validationemailvalid%>" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="Group1"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            <asp:Literal ID="Literal13" Text="<%$Resources:Resource, ContactUscomments%>" runat="server"></asp:Literal></label>
                                        <div class="col-sm-10">


                                            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" class="form-control widthcontact" Rows="8"></asp:TextBox>
                                            <span class="contactspn">*</span>
                                            <asp:RequiredFieldValidator ID="rpcomment" runat="server" ErrorMessage="<%$Resources:Resource, Validationcomment%>" ForeColor="Red" ControlToValidate="txtComment" Display="Dynamic" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="LabelComment" runat="server" ForeColor="Red" Visible="False"></asp:Label>
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
                                            <asp:Literal ID="Literal15" Text="<%$Resources:Resource, ContactUsscan%>" runat="server"></asp:Literal>
                                        </p>
                                    </div>
                                    <div class="col-md-2 col-sm-4">
                                        <div class="qr-monilla">
                                            <img src="/images/qr_inlandandalucia_mollina.png">
                                            <h3>Mollina Office</h3>
                                        </div>
                                    </div>
                                    <div class="col-md-2 col-sm-4">
                                        <div class="jaén-office">
                                            <img src="/images/qr_inlandandalucia_jaen.png">
                                            <h3>Jaén Office</h3>
                                        </div>
                                    </div>
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
                        <img src="/images/icons/thank-you-icon.jpg" alt="Thank you" height="142" hspace="10" align="left" />Thank you for submitting your new Franchise Request </h1>
                    <p>A member of our team will be in touch with you shortly!</p>

                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


    <!-- Github button for demo page -->
    <script async defer src="https://buttons.github.io/buttons.js"></script>

    <!-- GRT Youtube Popup -->
    <script src="JS/grt-youtube-popup.js"></script>

    <!-- Initialize GRT Youtube Popup plugin -->
    <script>
        // Demo video 1
        $(".youtube-link").grtyoutube({
            autoPlay: true,
            theme: "light"
        });

        // Demo video 2
        $(".youtube-link-dark").grtyoutube({
            autoPlay: false,
            theme: "dark"
        });
    </script>

    <!-- Main Content Area End -->
</asp:Content>

