<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  

  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
     <script lang="ja" type="text/ecmascript">
         function SetProgressPosition(e) {
             //  alert();
             var posx = 0;
             var posy = 0;
             if (!e) var e = window.event;
             if (e.pageX || e.pageY) {
                 posx = e.pageX;
                 posy = e.pageY;
             }
             else if (e.clientX || e.clientY) {
                 posx = e.clientX + document.documentElement.scrollLeft;
                 posy = e.clientY + document.documentElement.scrollTop;
             }
             document.getElementById('divProgress').style.left = posx - 8 + "px";
             document.getElementById('divProgress').style.top = posy - 8 + "px";
         }

         $(function () {

             $("#ContentPlaceHolder1_txtDateTo").datepicker();

         })
    </script>

     <style type="text/css">
        .overlay {
            border: black 1px solid;
            padding: 5px;
            z-index: 100;
            width: 80px;
            position: absolute;
            background-color: #fff;
            -moz-opacity: 0.75;
            opacity: 0.75;
            filter: alpha(opacity=75);
            font-family: Tahoma;
            font-size: 11px;
            font-weight: bold;
            text-align: center;
        }
    </style>
</head>
<body onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
    <div>
       <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="manageAdmins"
                DisplayAfter="1">
                <ProgressTemplate>
                     <div class="overlay" id="divProgress">
                                    &nbsp;
                <asp:Image GenerateEmptyAlternateText="true" ID="Image1" runat="server" Width="80"
                    Height="80" ImageUrl="../Images/ajaxloading.gif"  />
                                </div>
                   
                </ProgressTemplate>
            </asp:UpdateProgress>
      <asp:UpdatePanel ID="manageAdmins" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
          
               <!-- Main Content Area Start -->

        <!-- Left Portion Start -->
        <div class="col-md-8" > 
          <!-- Listing Head Start -->
          <div class="row">
            <div class="col-md-12">
              <div class="listing-head">
                <h1>Import Excel</h1>
              
           
              
                
                <!-- main pagging start -->
                <div class="row">
                  <div class="col-md-12">
                    <div class="paggination-top">
                   
                      <div class="col-md-6 col-sm-6">
                       <asp:FileUpload ID="FlUploadcsv" runat="server" />
       
                      </div> 
                         <div class="col-md-6 col-sm-6">
                     <asp:TextBox ID="txtDateTo" runat="server"  CssClass="form-control"></asp:TextBox>
                      </div>
                    </div>
                  </div>
                </div>

                  <div class="row">
                        <div class="col-md-12"> <asp:Button ID="btnsubmit" runat="server" class="btn btn-default" Text="Upload" OnClick="btnsubmit_Click"  /></div> 
                      </div> 


                <!-- Main Pagging End --> 
                


                  
              
                
                
             
            
                </div>

                  
                
              </div>
            </div>
          </div>
          <!-- Listing Head End --> 
       
        <!-- Left Portion Start --> 
        
     
<!-- Main Content Area End --> 
            </ContentTemplate>
          <Triggers >

                      <asp:PostBackTrigger ControlID="btnsubmit" />
          </Triggers> 
  
          </asp:UpdatePanel> 
    </div>
    </form>
</body>
</html>
