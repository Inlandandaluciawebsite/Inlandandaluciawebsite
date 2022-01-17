<%@ Page Language="VB" AutoEventWireup="false" CodeFile="windowcard.aspx.vb" Inherits="windowcard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Property Information</title>
    <link href="css/print-page.css" rel="stylesheet" />
    <style type="text/css">
        <!--
        body {
            font-family: "Arial", Helvetica, sans-serif;
            font-size: 14px;
            background: #FFF;
            margin: 10px;
            padding: 0;
            text-align: center;
            color: #000000;
        }

        .oneColFixCtr #container {
            width: 190mm;
            max-height: 292mm;
            background: #FFFFFF;
            margin: 0 auto;
            text-align: justify;
            display: block;
            overflow: hidden;
        }

        .oneColFixCtr #mainContent {
            padding: 0;
        }

        .tableDefault {
            width: 190mm;
            margin-bottom: 2mm;
        }

        .bigimg {
            width: 127mm;
            max-height: 94mm;
        }

        .smallimg {
            width: 63mm;
            max-height: 47mm;
        }

        .wrapper {
            -webkit-column-width: 190mm;
            column-width: 190mm;
            height: 100%;
        }

        .footer {
            width: 190mm;
            height: 20mm;
            display: block;
            overflow: hidden;
        }

        .btn-default:hover, .btn-default:focus, .btn-default.focus, .btn-default:active, .btn-default.active, .open > .dropdown-toggle.btn-default {
            color: #333;
            background-color: #E6E6E6;
            border-color: #ADADAD;
        }

        a:active, a:hover {
            outline: 0px none;
        }

        .btn {
            display: inline-block;
            padding: 6px 12px;
            margin-bottom: 0px;
            font-size: 14px;
            font-weight: normal;
            line-height: 1.42857;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            cursor: pointer;
            -moz-user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
        }

        a {
            color: #337AB7;
            text-decoration: none;
        }
    </style>
    <style type="text/css" media="print">
        .NonPrintable {
            display: none;
        }

        @page {
            size: auto; /* auto is the initial value */
            margin: 0px; /* this affects the margin in the printer settings */
        }

        body {
            background-color: #FFFFFF;
            margin: 10px; /* this affects the margin on the content before sending to printer */
            height: 1000px;
        }
    </style>
    <%--      <link href="css/bootstrap.css" rel="stylesheet">--%>
</head>

<body class="oneColFixCtr">
    <form id="WindowCard" runat="server">
        <div id="container">
            <div id="mainContent">
                <div class="NonPrintable">
                    <a class="btn btn-default print-btn prnttop NonPrintable" href="javascript:window.print()" role="button">
                        <i class="fa fa-print"></i>
                        <asp:Literal ID="lblwelcome" Text="<%$Resources:Resource, Print %>" runat="server"></asp:Literal></a>
                    <a class="btn btn-default print-btn prnttop NonPrintable" href="javascript:history.back()" role="button">
                        <i class="fa fa-print"></i>
                        <asp:Literal ID="Literal13" Text="<%$Resources:Resource, Back %>" runat="server"></asp:Literal></a>
                </div>
                <asp:Table ID="TableHeader" runat="server" CssClass="tableDefault" CellPadding="0" CellSpacing="0">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Image ID="ImageHeader" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Table ID="TableHeaderInfo" runat="server" Width="100%">
                    <asp:TableRow Height="5mm">
                        <asp:TableCell Width="33%">
                            Ref: <strong>
                                <asp:Label ID="LabelReference" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label></strong>
                        </asp:TableCell>
                        <asp:TableCell Width="34%" HorizontalAlign="Center">
                            <strong><%= Type%></strong>
                        </asp:TableCell>
                        <asp:TableCell Width="33%" HorizontalAlign="Right">
                            <span id="WC_Price" runat="server"></span>: <strong>
                                <asp:Label ID="LabelPrice" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label></strong>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="5mm">
                        <asp:TableCell ColumnSpan="2">
                            <span id="WC_Area" runat="server"></span>: <strong><%= Region%> - <%= Area%><%= SubArea%></strong>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right">
                            <span id="WC_OriginalPrice" runat="server"></span>
                            <asp:Label ID="LabelOriginalPrice" runat="server" ForeColor="Red"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>                  
                    <asp:TableRow Height="6mm">
                        <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                            <strong style="font-size:13px;"><%= ShortDescription%></strong>         
                        </asp:TableCell>
                    </asp:TableRow>     
                </asp:Table>

                <asp:Table ID="TableImages" runat="server" CssClass="tableDefault" CellPadding="0" CellSpacing="0">

                    <asp:TableRow>

                        <asp:TableCell RowSpan="2" CssClass="bigimg">
            
                <img src="<%= GetPhotoURL(1)%>" alt="Main Photo" align="left" class="bigimg"  />
            
                        </asp:TableCell>

                        <asp:TableCell CssClass="smallimg">
            
                <img src="<%= GetPhotoURL(2)%>" alt="Photo 2" class="smallimg" />
            
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow>

                        <asp:TableCell CssClass="smallimg">
            
                <img src="<%= GetPhotoURL(3)%>" alt="Photo 3" class="smallimg" />
            
                        </asp:TableCell>

                    </asp:TableRow>

                </asp:Table>

                <asp:Table ID="TableFooterInfo" runat="server" CssClass="tableDefault">

                    <asp:TableRow Height="5mm">

                        <asp:TableCell Width="30%">

                            <span id="WC_Beds" runat="server"></span>: <strong><%= Bedrooms%></strong>

                        </asp:TableCell>

                        <asp:TableCell Width="30%" HorizontalAlign="Center">

                            <span id="WC_Built" runat="server"></span>: <strong><%= BuiltSize%> m<sup>2</sup></strong>

                        </asp:TableCell>

                        <asp:TableCell Width="40%" HorizontalAlign="Right">

                            <span id="WC_Views" runat="server"></span>: <strong><%= Views%></strong>

                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow Height="5mm">

                        <asp:TableCell>

                            <span id="WC_Baths" runat="server"></span>: <strong><%= Bathrooms%></strong>

                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">

                            <span id="WC_Plot" runat="server"></span>: <strong><%= PlotSize%> m<sup>2</sup></strong>

                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">

                            <span id="WC_Location" runat="server"></span>: <strong><%= Location%></strong>

                        </asp:TableCell>

                    </asp:TableRow>

                </asp:Table>

                <div style="width: 100%; height: 37mm; display: block; overflow: hidden;">

                    <div class="wrapper">

                        <asp:Table ID="TableEnglishDescription" runat="server" Width="100%" Height="100%">

                            <asp:TableRow Height="37mm" Font-Size="13px">
                                <asp:TableCell>
                        <img src="<%= GetFlag%>" alt="Flag" width="30" height="17" hspace="0" vspace="0" align="left" style="padding: 0px 10px 0px 0px; float:left;"  />
                         <%= Description%>
                                </asp:TableCell>
                            </asp:TableRow>


                        </asp:Table>

                    </div>

                </div>

                <div style="width: 100%; height: 37mm; display: block; overflow: hidden;">

                    <div class="wrapper">

                        <asp:Table ID="TableSpanishDescription" runat="server" Width="100%">

                            <asp:TableRow Height="3mm" Font-Size="13px">
                                <asp:TableCell>
                        <img src="<%= GetSpanishFlag%>" alt="Flag" width="30" height="17" hspace="0" vspace="0" align="left" style="padding: 0px 10px 0px 0px; float: left;" />
                        <%= DescriptionES%>
                                </asp:TableCell>
                            </asp:TableRow>

                        </asp:Table>

                    </div>
                </div>


                <div id="footer">

                    <asp:Table ID="TableFooter" runat="server" Width="100%" Font-Size="14px">

                        <asp:TableRow>

                            <asp:TableCell VerticalAlign="Top" Width="100px">

                                <span id="WC_Features" runat="server"></span>:
            
                            </asp:TableCell>

                            <asp:TableCell Width="10px"></asp:TableCell>

                            <asp:TableCell VerticalAlign="Top">
            
                    <strong><%= Features%></strong>
            
                            </asp:TableCell>

                            <asp:TableCell Width="10px"></asp:TableCell>

                            <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right" Width="100px">

                                <asp:Image ID="ImageQRCode" runat="server" />

                            </asp:TableCell>

                        </asp:TableRow>

                    </asp:Table>

                </div>
                <div class="NonPrintable">
                    <a class="btn btn-default print-btn  NonPrintable" href="javascript:window.print();" role="button">
                        <i class="fa fa-print"></i>
                        <asp:Literal ID="Literal1" Text="<%$Resources:Resource, Print %>" runat="server"></asp:Literal></a>

                    <a class="btn btn-default print-btn NonPrintable" href="javascript:history.back()" role="button">
                        <i class="fa fa-print"></i>
                        <asp:Literal ID="Literal2" Text="<%$Resources:Resource, Back %>" runat="server"></asp:Literal></a>
                </div>
                <!-- end #mainContent -->
            </div>
            <!-- end #container -->
        </div>
    </form>
</body>
</html>
