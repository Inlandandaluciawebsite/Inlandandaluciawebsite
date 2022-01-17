<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PayPalPayment.aspx.vb" Inherits="PayPalPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PayPal Payment Page</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/PayPal.css" rel="stylesheet" />
    <script src="js/Validation.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://use.fontawesome.com/aa2cfa76bb.js"></script>
    <style>
        .block {
            pointer-events: none; 
        }
    </style>
    <script>
        $(function () {
            document.getElementById("buyerRefrence").innerHTML = sessionStorage.getItem("dataBuyer");
            document.getElementById("msgAmount").innerHTML = "Amount " + sessionStorage.getItem("paidAmount") + ".00 Euro has been received.";
            $("input[name=item_name_1]").val($("#buyerRefrence").text().replace(/\s+/g, ' ').trim());
            var msg = $("#buyerRefrence").text().replace(/\s+/g, ' ').trim() + " has been successfully booked for next 2 weeks.";
            $("#pmsg").text(msg);
            $("#hdnPaidAmount").val(sessionStorage.getItem("paidAmount"));
        });
        $(document).on("change","input",function () {
            $("input[name=amount_1]").val($("#txtBookingAmount").val());
            sessionStorage.setItem("paidAmount", $("input[name=amount_1]").val());
            if ($("#txtBookingAmount").val() < 1) {
                $("#lblError").text("Please Select the amount above 1000.")
                $("input[name=submit]").addClass("block")
            }
            else {
                $("input[name=submit]").removeClass("block")
                $("#lblError").text("")
            }
        });

        $(document).on("keyup","input",function () {
            this.value = this.value.replace(/[^0-9\+]/g, '');
        });
    </script>
    <style>
        h3 {
            margin: 0 0 10px;
            display: block;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            font-size: 14px;
            line-height: 1.42857143;
        }

        .propertyRef {
        }
    </style>
</head>
<body>

    <!-- For DEV TESTING -->
    <%--<form runat="server" action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post">--%>
    <!-- FOR LIVE ENVIORMENT -->
    <form runat="server" action="https://www.paypal.com/cgi-bin/webscr" method="post">
        <asp:HiddenField runat="server" ID="hdnPaidAmount" Value="hdnAmountPaid" />
        <div class="container" id="divPayment" runat="server">
            <div class="row">
                <div class="col-md-12 text-center">
                   <a href="Default.aspx"><img src="images/Logos/Payment Header.jpg" alt="Inland Andalucia Ltd." /></a>
                </div>
            </div>
            <div class="row" style="margin-top: 50px">
                <h3 class="text-center bg-success table-bordered">Inland Andalucia Ltd.</h3>

            </div>
            <div class="row">
                <div class="col-md-3">
                    <label>Forname:</label>
                    <p runat="server" id="buyerName"></p>
                </div>
                <div class="col-md-3">
                    <label>Surname:</label><p runat="server" id="buyerPassport"></p>

                </div>
                <div class="col-md-3">
                    <label>Address:</label><p runat="server" id="buyerAddress"></p>

                </div>
                <div class="col-md-3">
                    <label>
                        Email:
                    </label>
                    <p runat="server" id="buyerEmail"></p>
                </div>
                <div class="col-md-3">
                    <label>Telephone:</label>
                    <p runat="server" id="buyerTelePhone"></p>
                </div>
                <div class="col-md-3">
                    <label>Property Reference</label><p class="propertyRef" runat="server" id="buyerRefrence"></p>
                </div>
                <div class="col-md-3">
                    <label>Booking Amount:</label>
                    <asp:TextBox ID="txtBookingAmount" Width="60px" runat="server" Text="1000"></asp:TextBox>
                    <span class="alert-success">€</span><br /><asp:Label ID="lblError" runat="server" ForeColor="red"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    
                    <!-- DEV VARIABLES -->
                    <%--<input type="hidden" name="cmd" value="_cart" />
                    <input type="hidden" name="at" value="Gog8nkK21JqeA0nE6auuk2Oz2XVFQt6gmIEScrjt4gXn6jgNHula05V68pq" />
                    <input type="hidden" name="upload" value="1" />
                    <input type="hidden" name="business" value="inlandstore@hashsoftwares.com" />
                    <input type="hidden" name="image_url" value="http://inlandandalucia.hashsoftwares.com/images/logo.png" />--%>
                    <!-- LIVE VARIABLES-->
                    <input type="hidden" name="cmd" value="_cart" />
                    <input type="hidden" name="at" value="skDEFR_Iv4fVNZtfT_9RgFNIMTP2JYuVH7WSZ-1hay91t8mKmhsAeO_vSIO" />
                    <input type="hidden" name="upload" value="1" />
                    <input type="hidden" name="business" value="info@inlandandalucia.com" />
                    <input type="hidden" name="image_url" value="http://www.inlandandalucia.com/images/logo.png" />
		    <input type="hidden" name="return" value="http://inlandandalucia.com/Buyer.aspx" />

                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <input type="hidden" name="item_name_1" value="Property" />
                    <input type="hidden" name="amount_1" value="1000" />
                    <input type="hidden" name="quantity_1" value="1" />
                    <input type="hidden" name="currency_code" value="EUR" />
                </div>
                <div class="col-md-12 text-center" style="margin-top: 10px">
                    <hr class="table-bordered" />
                    <input type="image" name="submit" border="0" src="images/reserve_now.gif" alt="Buy Now"/>
                </div>
            </div>
        </div>
        <div class="thanks-sec">
            <div class="container" id="divMsg" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <div class="thank-check"><i class="fa fa-check-circle" aria-hidden="true"></i></div>
                        <h2>Thank You For Payment</h2>
                        <p id="msgAmount">Amount 1000.00 Euro has been received. </p>
                        <p runat="server" id="pmsg" class="alert-success"></p>
                        <a href="Default.aspx">Click Here Go back to Home Page.</a>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
