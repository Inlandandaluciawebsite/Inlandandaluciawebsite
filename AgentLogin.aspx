<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AgentLogin.aspx.vb" Inherits="AgentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
<title>Agent Login</title>
<link rel="Shortcut Icon" href="/Images/Icons/favicon.ico" type="image/x-icon"/>

<!-- Owl Carousel Assets -->
<link href="owl-carousel/owl.carousel.css" rel="stylesheet">
<link href="owl-carousel/owl.theme.css"rel="stylesheet">
<link rel="Shortcut Icon" href="Images/favicon.ico" type="image/x-icon" />
<link href="assets/js/google-code-prettify/prettify.css" rel="stylesheet">
<link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'>

<!-- Bootstrap -->
<link href='http://fonts.googleapis.com/css?family=PT+Sans' rel='stylesheet' type='text/css'>
<link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/font-awesome.css" rel="stylesheet">
<link href="css/style.css" rel="stylesheet">

<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">    
        <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
            <div class="panel panel-info bdr-col" >
                    <div class="panel-heading login-hd">
                        <div class="panel-title">
     <div class="row">      <div class="col-md-6 login-logo"><img src="/images/logo.png"> </div>
      <div class="col-md-6"><h4 class="logi-hding">Agent Area</h4></div>    
                        </div>
                   
                    </div>  </div>   

                    <div style="padding-top:30px" class="panel-body" >

                        <div style="display:none" id="login-alert" class="alert alert-danger col-sm-12"></div>
                            
                        <div id="loginform" class="form-horizontal" role="form">
                                    
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                  <asp:TextBox ID="TextBoxUsername" runat="server"  class="form-control"> 
        </asp:TextBox>
                                                                             
                                    </div>
                                
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                                                <asp:TextBox ID="TextBoxPassword" runat="server"  class="form-control"  TextMode="Password"> 
        </asp:TextBox>
                                    </div>
                                    

                                
                  


                                <div style="margin-top:10px" class="form-group">
                                    <!-- Button -->

                                    <div class="col-sm-12 controls">
                                      <a id="btn-login" href="javascript:history.go(-1)" class="btn btn-success"><i class="fa fa-arrow-left"></i> Back  </a>
                                 
                                                   
                                        <asp:Button ID="btnsubmit" runat="server"  Text="Sign In" class="btn btn-primary" OnClick="btnsubmit_Click" />

                                    </div>
                                  
                                     
                                </div>


                             <div class="form-group">
                                    <div class="col-md-12 control">
                                        <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                </div> 
                            </div>     



                        </div>                     
                    </div>  
        </div>
      
    </div>
    
    </form>
</body>
</html>
