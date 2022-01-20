<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StripePayment.aspx.vb" Inherits="StripePayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stripe Payment Page</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/Validation.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="https://use.fontawesome.com/aa2cfa76bb.js"></script>
    <script>
        function CheckAmountValidation() {
            if (document.getElementById('txtAmount').value == '') {
                alert("Please enter booking amount to reserve this property !");
                return false;
            }
            if (parseInt(document.getElementById('txtAmount').value) < 600) {
                alert("Please Select the amount above 600.");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <style>
        .block {
            pointer-events: none;
        }

        h3 {
            margin: 0 0 10px;
            display: block;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            font-size: 14px;
            line-height: 1.42857143;
        }

        .visible {
            display: block !important;
        }

        form#paymentform label {
            display: block;
        }

        form#paymentform .input-control {
            margin-bottom: 8px;
        }

        .cstm-dtl {
            float: left;
            width: 100%;
            background: #f9f9f9;
            padding: 8px;
            border: 1px solid #e0f0da;
            height:312px;
        }

        .cstm-dtl h2 {
            font-size: 24px;
            background: #e0f0d9;
            padding: 6px;
            margin-top: 0;
            margin-bottom: 20px;
        }

        .pymt-dtl.cstm-dtl {
            min-height: 312px;
        }

        input#txtAmount {
            border-radius: 3px;
            border: 1px solid #bdbdbd;
            padding: 5px;
        }

        input#btnNext {
            background: #ffc439;
            border: 1px solid #ffc439;
            font-weight: 600;
            border-radius: 10px;
        }

        input#cardholdername {
            padding: 7px !important;
            border-radius: 3px;
            border: 1px solid #bdbdbd;
            width: 96%;
            margin: 10px 10px 0;
        }

        div#card-element {
            padding: 7px !important;
            border-radius: 3px;
            border: 1px solid #bdbdbd;
            width: 96%;
            margin: 10px 10px 0;
        }

        input#cardholdername::-webkit-input-placeholder {
            color: #b0bcc8;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form runat="server" method="post" id="paymentform">
        <div class="container" id="divPayment" runat="server">
            <div class="row">
                <div class="col-md-12 text-center">
                    <a href="Default.aspx">
                        <img src="images/Logos/Payment Header.jpg" alt="Inland Andalucia Ltd." /></a>
                </div>
            </div>
            <div class="row" style="margin-top: 50px">
                <div class="col-md-12">
                    <h3 class="text-center bg-success table-bordered">Inland Andalucia Ltd.</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="cstm-dtl">
                        <h2>Customer Details</h2>
                        <div class="row">
                            <div class="col-sm-6">
                                <label>Forname:</label>
                                <p runat="server" id="buyerForname"></p>
                            </div>
                            <div class="col-sm-6">
                                <label>Surname:</label><p runat="server" id="buyerSurname"></p>
                            </div>
                            <div class="col-sm-6">
                                <label>Address:</label><p runat="server" id="buyerAddress"></p>
                            </div>
                            <div class="col-sm-6">
                                <label>
                                    Email:
                                </label>
                                <p runat="server" id="buyerEmail"></p>
                            </div>
                            <div class="col-sm-6">
                                <label>Telephone:</label>
                                <p runat="server" id="buyerTelePhone"></p>
                            </div>
                            <div class="col-sm-6">
                                <label>Property Reference</label><p class="propertyRef" runat="server" id="buyerRefrence"></p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="pymt-dtl cstm-dtl" style="height:312px;">
                        <h2>Payment Details</h2>
                        <div class="form-row" id="divCardDetails" runat="server" visible="false" style="background-color: white;">
                            <label for="card-element">
                            </label>
                            <input id="cardholdername" type="text" placeholder="Cardholder Name" class="InputElement is-empty Input Input--empty" />
                            <label style="padding: 10px; color: gray; font-size: 16px; font-weight: normal; padding-bottom: 0px;">
                                Please enter Card Number, Expiry Date, CVC*, CP** below :
                            </label>
                            <div id="card-element">
                                <!-- A Stripe Element will be inserted here. -->
                            </div>
                            <asp:Label ID="lblSecurityCode" runat="server" Visible="false" style="padding:8px; color:gray; display:block; margin-top:6px;">*Security code at the back of your card : last 3 digit only</asp:Label>
                            <asp:Label ID="lblPostCode" runat="server" Visible="false" style="padding:8px; color:gray; display:block; margin-top:-12px;">**Enter Postode only if Required</asp:Label>
                            <!-- Used to display form errors. -->
                            <div id="card-errors" role="alert"></div>
                            <img src="images/reserve_now.gif" alt="Buy Now" id="card-button" style="cursor: pointer; padding: 10px;" />
                        </div>
                        <div id="dvAmount" runat="server" visible="true">
                            <asp:TextBox ID="txtAmount" type="text" runat="server" placeholder="Booking Amount in Euro"  MaxLength="5" oninput="this.value = this.value.replace(/[^0-9\-]+/g, '').replace(/(\..*)\./g, '$1');"></asp:TextBox>
                            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" OnClientClick="javascript:return CheckAmountValidation();" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                     <%--<hr class="table-bordered" />--%>
                </div>

                <div class="col-md-6" style="margin-top: 10px">
                    
                    <%--<hr class="table-bordered" />--%>
                    <input type="hidden" id="hfClientSecret" runat="server" />
                    <input type="hidden" id="hfPaymentIntentId" runat="server" />
                    <input type="hidden" id="hdnPaidAmount" runat="server" />
                    <input type="hidden" id="hdnBuyerId" runat="server" />
                </div>
            </div>
        </div>
        <div class="thanks-sec" style="display: none;" id="divMsg" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="thank-check"><i class="fa fa-check-circle" aria-hidden="true"></i></div>
                        <h2>Thank You For Payment</h2>
                        <p id="msgAmount" runat="server">Amount 1000.00 Euro has been received. </p>
                        <p runat="server" id="pmsg" class="alert-success"></p>
                        <a href="Default.aspx">Click Here Go back to Home Page.</a>
                        <asp:Button ID="btnLogPayment" runat="server" Text="LogPayment" Style="display: none;" OnClick="btnLogPayment_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://js.stripe.com/v3/"></script>
    <script type="text/javascript" lang="javascript">
        var stripe = Stripe('pk_test_dKUXdwSFhfmvFsRXjqk1Ksw8');
        //var stripe = Stripe('pk_live_D0Fo1miKIFgSzk14xavTlVrb');
        
        var elements = stripe.elements();
        // Custom styling can be passed to options when creating an Element.
        // (Note that this demo uses a wider set of styles than the guide below.)
        var style = {
            base: {
                color: '#32325d',
                fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
                fontSmoothing: 'antialiased',
                fontSize: '16px',
                '::placeholder': {
                    color: '#aab7c4'
                }
            },
            invalid: {
                color: '#fa755a',
                iconColor: '#fa755a'
            }
        };

        var cardElement = elements.create('card', { style: style });
        cardElement.mount('#card-element');
        var cardholderName = document.getElementById('cardholdername');
        var cardButton = document.getElementById('card-button');
        //var clientSecret = cardButton.dataset.secret;
        var clientSecret = document.getElementById('hfClientSecret').value;
        console.log(clientSecret);
        cardButton.addEventListener('click', function (ev) {
            stripe.handleCardPayment(
                clientSecret, cardElement, {
                    payment_method_data: {
                        billing_details: { name: cardholderName.value }
                    }
                }
            ).then(function (result) {
                if (result.error) {
                    // Display error.message in your UI.
                    var str = result.error.message;
                    if (str.includes("You passed an empty string for 'payment_method_data[billing_details][name]")) {
                        alert("Please enter card holder name !");
                    }
                    else {
                        alert(result.error.message);
                    }
                }
                else {
                    // The payment has succeeded. Display a success message.
                    //alert("Property been reserved successfully !");
                    document.getElementById('btnLogPayment').click();
                }
            });
        });
    </script>
</body>
</html>
