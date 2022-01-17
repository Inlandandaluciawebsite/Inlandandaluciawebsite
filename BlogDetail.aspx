<%@ Page Title="" Language="VB" MasterPageFile="~/InlandandAlucia.master" AutoEventWireup="false" CodeFile="BlogDetail.aspx.vb" Inherits="BlogDetail" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="css/Blog.css" rel="stylesheet" />
    <link href="css/popup.css" rel="stylesheet" />

    <%--<script>
        (function () {
            var po = document.createElement('script');
            po.type = 'text/javascript'; po.async = true;
            po.src = 'https://plus.google.com/js/client:plusone.js';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(po, s);
        })();
    </script>--%>
<%--     <script type="text/javascript">
        /**
        * Calls the helper method that handles the authentication flow.
        *
        * @param {Object} authResult An Object which contains the access token and
        *   other authentication information.
        */
        function onSignInCallback(authResult) {
            if (authResult['access_token']) {
                // The user is signed in
                var loc = '/GoogleLogin.aspx?accessToken=' + authResult['access_token'];
                window.location.href = loc;
            } else if (authResult['error']) {
                // There was an error, which means the user is not signed in.
                // As an example, you can troubleshoot by writing to the console:
                alert('There was an error: ' + authResult['error']);
            }
            //console.log('authResult', authResult);
        }
    </script>--%>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Left Portion Start -->
    <div class="col-md-8">
        <asp:HiddenField ID="hdblogid" runat="server" />
        <asp:FormView ID="frmview" runat="server">
            <ItemTemplate>
                <!-- Blog Repeater S-->
                <div class="gray-bg-inner">
                    <div class="outer-border">
                        <p class="time"><%#Eval("dateposted").ToString() %></p>
                        <h3 class="blog-title"><a href="BlogDetail.aspx?Title=<%#Eval("Title").ToString() %>"><%#Eval("Title").ToString() %></a></h3>
                        <p class="blog-main-txt">
                            <%#(Eval("SubTitle").ToString()) %>
                        </p>
                        <p class="blog-main-txt">
                            <%#Server.HtmlDecode(Eval("Description").ToString()) %>aseem
                        </p>
                        <p class="blog-main-txt">Posted by: <%#Eval("PostedByUser").ToString() %> at <%#Eval("Time").ToString() %> <a class="comment-link" href="#!" onclick="">1 comment: </a></p>
                        <p class="blog-main-txt">
                            Labels: <%#Server.HtmlDecode(Eval("hashlables").ToString()) %>
                        </p>
                    </div>
                </div>
                <!-- Blog Repeater E-->

            </ItemTemplate>
        </asp:FormView>
        <div class="gray-bg-inner">
            <div class="outer-border">
                <div>
                    <div class="form-group col-md-12">
                        <h3 class="blog-sub-hd m0">
                            <asp:Label ID="lblcountcomment" runat="server"></asp:Label>
                            comment:</h3>
                        <asp:Repeater ID="rpblogcomment" runat="server" OnItemCommand="rpblogcomment_ItemCommand" OnItemDataBound="rpblogcomment_ItemDataBound">
                            <ItemTemplate>
                                <asp:HiddenField ID="blogcid" runat="server" Value='<%#Eval("BcId")%>' />
                                <div class="row">
                                    <div class="col-md-12">
                                        <label for="exampleInputEmail1"><%#Eval("UserName") %> <%#Eval("Months") %> <%#Eval("year") %> at <%#Eval("Time") %></label>
                                        <p class="blog-main-txt"><%#Eval("Comment") %></p>
                                        <%-- <a class="btn btn-default" href="#" role="button"></a>  --%>
                                        <asp:LinkButton ID="lblreply" class="btn btn-default" runat="server" Text="Reply" CommandName="reply" CommandArgument='<%#Eval("BcId") %>'></asp:LinkButton>
                                        <a href="#<%#Eval("BcId") %>" class="btn btn-default" data-toggle="collapse">Replies

                                          (<asp:Literal ID="lblcount" runat="server"></asp:Literal>)

                                        </a>


                                        <div id="<%#Eval("BcId") %>" class="collapse">
                                            <asp:Repeater ID="rpslider2" runat="server">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="gray-bg-inner">
                                                                <div class="outer-border">
                                                                    <div>
                                                                        <div class="form-group col-md-12">

                                                                            <label for="exampleInputEmail1"><%#Eval("UserName") %> <%#Eval("Months") %> <%#Eval("year") %> at <%#Eval("Time") %></label>
                                                                            <p class="blog-main-txt"><%#Eval("Comment") %></p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>


                                    </div>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>


                    </div>
                    <div class="form-group col-md-12">
                        <asp:TextBox ID="txtcomment" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <%--   <textarea class="form-control" rows="3" placeholder="Enter your comment..."></textarea>--%>
                    </div>
                    <%-- <div class="form-group col-md-5">
                      <label for="inputEmail3" class=" control-label"> Comment as:</label>
                      <select class="form-control " id="identityMenu" name="identityMenu" dir="ltr" onchange="BLOG_CMT_onSelectorChange()" style="display: inline;">
                        <option value="NONE" disabled="">Select profile...</option>
                        <option value="CURRENT">Unknown (Google)</option>
                        <option value="NONE">LiveJournal</option>
                        <option value="NONE">WordPress</option>
                        <option value="NONE">TypePad</option>
                        <option value="NONE">AIM</option>
                        <option value="OPENID">OpenID</option>
                        <option value="NAMEURL">Name/URL</option>
                        <option value="ANON">Anonymous</option>
                      </select>
                    </div>
                    <div class="form-group col-md-12">
                      <button type="submit" class="btn btn-default btn-yellow ">Submit</button>
                    </div>--%>
                    <div class="form-group">
                        <div class="gray-bg-2">
                            <div class="col-sm-6">
                                <a id="modal_trigger" href="#modal" class="btn" style="display: none;"></a>
                                <a id="modal_trigger1" href="#modal1" class="btn" style="display: none;"></a>
                                <asp:Button ID="btnpostcomment" class="btn btn-default publish-btn" OnClientClick="return Validationscomment();" runat="server" Text="Post Comment" OnClick="btnpostcomment_Click" />
                                <%--     <button class="btn btn-default publish-btn" type="submit">Post Comment</button>--%>
                                <%-- <button class="btn btn-default publish-btn" type="submit">Preview</button>--%>
                            </div>
                        </div>
                    </div>
                    <%--    <div class="form-group">
                      <nav aria-label="...">
                        <ul class="pager">
                          <li class="previous disabled"><a href="#"><span aria-hidden="true">←</span> Older</a></li>
                          <li class="next"><a href="#">Newer <span aria-hidden="true">→</span></a></li>
                        </ul>
                      </nav>
                    </div>--%>
                </div>
            </div>
        </div>
        <!-- Buyers Guide End -->


        <!-- Contact Page Start -->
    </div>



    <div id="modal" class="popupContainer" style="display: none;">
        <header class="popupHeader">
            <span class="header_title">Login</span>
            <span class="modal_close"><i class="fa fa-times">x</i></span>
        </header>

        <section class="popupBody">
            <!-- Social Login -->
            <div class="social_login">
                <div class="">

                 <%--   <asp:ImageButton ID="ass"  runat="server"  >

                    </asp:imagebutton>--%>

                    <asp:ImageButton ID="lblloginwithfb" runat="server" AlternateText="image" ImageUrl="~/images/facebooklogin.png"  class="social_box fb" OnClick="lblloginwithfb_Click" >
                          <%-- <span class="icon"><i class="fa fa-facebook" aria-hidden="true"></i></span>
                        <span class="icon_title">Login with Facebook</span>--%>

                    </asp:ImageButton>
                

                  <%--  <a href="#" class="social_box google">
                        <span class="icon"><i class="fa fa-google-plus"></i></span>
                        <span class="icon_title">Connect with Google</span>
                    </a>--%>
                <%--     <asp:LinkButton ID="lblloginwithgoogle" runat="server"  class="social_box google" OnClick="lblloginwithgoogle_Click" >
                           <span class="icon"><i class="fa fa-facebook" aria-hidden="true"></i></span>
                        <span class="icon_title">Login with Google</span>

                    </asp:LinkButton>
                     <button class="g-signin social_box google"
            data-scope="https://www.googleapis.com/auth/plus.login  https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile"
         
            data-clientid="1074390800872-66rgan23ia0bg2mruf0ehlq36sglk0ff.apps.googleusercontent.com"
            data-accesstype="offline"
            data-callback="onSignInCallback"
            data-theme="dark"
            data-cookiepolicy="single_host_origin">
        </button>--%>
                    
                </div>

                <div class="centeredText">
                    <span>Or use your Email address</span>
                </div>

                <div class="action_btns">
                    <div class="one_half">
                        
                        
                        <a href="#" id="login_form" class="btn">Login</a></div>
                    <div class="one_half last"><a href="#" id="register_form" class="btn">Sign up</a></div>
                </div>
            </div>

            <!-- Username & Password Login form -->
            <div class="user_login">
                <div>
                    <label>Email / Username</label>
                    <asp:TextBox ID="txtEmaillogin" runat="server"></asp:TextBox>
                    <br />

                    <label>Password</label>
                    <asp:TextBox ID="txtpasswordlogin" TextMode="Password" runat="server"></asp:TextBox>
                    <br />



                    <div class="action_btns">
                        <div class="one_half"><a href="#" class="btn back_btn"><i class="fa fa-angle-double-left"></i>Back</a></div>
                        <div class="one_half last">
                            <%--<a href="#" class="btn btn_red">Login</a>--%>
                            <asp:Button ID="btnlogin" runat="server" class="btn btn_red" Text="Login" OnClientClick="return Validationslogin();" OnClick="btnlogin_Click" />
                        </div>
                    </div>
                </div>

                <%--	<a href="#" class="forgot_password">Forgot password?</a>--%>
            </div>

            <!-- Register Form -->
            <div class="user_register">
                <div>
                    <label>Full Name</label>
                    <asp:TextBox ID="txtfullnameregister" runat="server"></asp:TextBox>
                    <br />

                    <label>Email Address</label>
                    <asp:TextBox ID="txtemailregister" runat="server"></asp:TextBox>
                    <br />

                    <label>Password</label>
                    <asp:TextBox ID="txtpasswordregister" runat="server" TextMode="Password"></asp:TextBox>
                    <br />



                    <div class="action_btns">
                        <div class="one_half"><a href="#" class="btn back_btn"><i class="fa fa-angle-double-left"></i>Back</a></div>
                        <div class="one_half last">
                            <%--  <a href="#" class="btn btn_red">Register</a>--%>
                            <asp:Button ID="btnregister" runat="server" Text="Register" OnClick="btnregister_Click" OnClientClick="return ValidationsRegister();" class="btn btn_red" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>


    <div id="modal1" class="popupContainer" style="display: none;">
        <header class="popupHeader">
            <span class="header_title">Comment</span>
            <span class="modal_close"><i class="fa fa-times">x</i></span>
        </header>

        <section class="popupBody">
            <!-- Social Login -->


            <!-- Username & Password Login form -->
            <div class="user_login1">
                <div>
                    <asp:HiddenField ID="hdnreply" runat="server" />

                    <asp:TextBox ID="txtreplycomment" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    <br />

                    <div class="action_btns">

                        <div class="one_half last">
                            <%--<a href="#" class="btn btn_red">Login</a>--%>
                            <asp:Button ID="Button1" runat="server" class="btn btn_red" Text="Reply" OnClientClick="return Validationsreply();" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>

                <%--	<a href="#" class="forgot_password">Forgot password?</a>--%>
            </div>

        </section>
    </div>
    <asp:Label ID="lblchkuser" runat="server" Style="display: none;">></asp:Label>
    <!-- Left Portion End -->


    <script src="js/bootbox.min.js"></script>


    <script src="js/Validation.js"></script>
    <script type="text/javascript" lang="javascript">
        function Validationsreply() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredFieldBlog(document.getElementById('<%=txtreplycomment.ClientID%>'), "Please enter comment to reply!<br>");

            if (IsError.length > 0) {
                bootbox.alert({
                    size: "small",
                    //  title: "Your Title",
                    message: IsError,
                    callback: function () { /* your callback code */ }
                })
                //  alert(IsError);
                return false;
            }
            return true;
        }
        function Validationslogin() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredFieldBlog(document.getElementById('<%=txtEmaillogin.ClientID%>'), "Please enter email!<br>");
            IsError += ValidateRequiredFieldBlog(document.getElementById('<%=txtpasswordlogin.ClientID%>'), "Please enter password!");

            if (IsError.length > 0) {
                bootbox.alert({
                    size: "small",
                    //  title: "Your Title",
                    message: IsError,
                    callback: function () { /* your callback code */ }
                })
                //  alert(IsError);
                return false;
            }
            return true;
        }
        function Validationscomment() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredField(document.getElementById('<%=txtcomment.ClientID%>'), "Please enter comment!");

            if (IsError.length > 0) {
                bootbox.alert({
                    size: "small",
                    //  title: "Your Title",
                    message: IsError,
                    callback: function () { /* your callback code */ }
                })
                return false;
            }
            return true;
        }

        function ValidationsRegister() {
            var IsError = '';
            var invalid = " "; // Invalid character is a space
            IsError += ValidateRequiredFieldBlog(document.getElementById('<%=txtfullnameregister.ClientID%>'), "Please enter full name!<br>");
            IsError += validateEmailblog(document.getElementById('<%=txtemailregister.ClientID%>'), "Please enter email!<br>");
             IsError += ValidateRequiredFieldBlog(document.getElementById('<%=txtpasswordregister.ClientID%>'), "Please enter password!<br>");
             if (IsError.length > 0) {
                 bootbox.alert({
                     size: "small",
                     //  title: "Your Title",
                     message: IsError,
                     callback: function () { /* your callback code */ }
                 })
                 return false;
             }
             return true;
         }
    </script>

</asp:Content>

