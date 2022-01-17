<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdminClientTourPrint.ascx.vb" Inherits="WebUserControlAdminClientTourPrint" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Client tour</title>
    <style type="text/css">
        body {
            font-family: "Arial", Helvetica, sans-serif;
            background: #FFF;
            margin: 10px;
            padding: 0;
            text-align: center;
            color: #000000;
        }

        .oneColFixCtr #container {
            width: 840px;
            max-height: 900px;
            background: #FFFFFF;
            margin: 30px auto 0px auto;
            text-align: justify;
        }

        td {
            padding: 5px;
            border: solid 1px #CCCCCC;
            font-size: small;
        }

        #ImageBritishFlag {
            padding: 5px 5px 5px 0px;
        }

        #ImageSpanishFlag {
            padding: 5px 5px 5px 0px;
        }
    </style>
    <style type="text/css" media="print">
        .NonPrintable {
            display: none;
        }

        @page {
            size: landscape; /* auto is the initial value */
            margin: 0px; /* this affects the margin in the printer settings */
        }

        body {
            background-color: #FFFFFF;
            margin: 10px; /* this affects the margin on the content before sending to printer */
            max-height: 1000px;
        }
    </style>
</head>
<body class="oneColFixCtr">
    <div id="container">
        <asp:UpdatePanel ID="UpdatePanelAdminClientTourPrint" runat="server" UpdateMode="Conditional" Width="100%">
            <ContentTemplate>

                <asp:Table ID="TableTourHeader" runat="server" Width="100%" BorderWidth="0"
                    GridLines="None" Style="font-family: Calibri">

                    <asp:TableRow>

                        <asp:TableCell RowSpan="7" ColumnSpan="2" BorderWidth="0">
                            <asp:Image ID="ImageIALogo" runat="server" Width="177" Height="85" />
                        </asp:TableCell>

                        <asp:TableCell RowSpan="2">
                    <strong>Client Name(s)</strong>
                        </asp:TableCell>

                        <asp:TableCell ColumnSpan="2">
                            <asp:Label ID="LabelBuyer" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                    <strong>Viewing Date</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelViewDateDay" runat="server"></asp:Label>
                            /
                    <asp:Label ID="LabelViewDateMonth" runat="server"></asp:Label>
                            /
                    <asp:Label ID="LabelViewDateYear" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow>

                        <asp:TableCell ColumnSpan="2">
                            <asp:Label ID="LabelClientName" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                    <strong>Meeting Time</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelMeetingTimeHour" runat="server"></asp:Label>
                            :
                    <asp:Label ID="LabelMeetingTimeMinute" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow>

                        <asp:TableCell RowSpan="2">
                    <strong>Sign Here</strong>
                        </asp:TableCell>

                        <asp:TableCell RowSpan="2" ColumnSpan="2">
                        </asp:TableCell>

                        <asp:TableCell>
                    <strong>Viewing Reference</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelViewingReference" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow>

                        <asp:TableCell>
                    <strong>Client Reference</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelClientReference" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow>

                        <asp:TableCell>
                    <strong>Contact Tel / Email</strong>
                        </asp:TableCell>

                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                            <asp:Label ID="LabelContactTelEmail" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                    <strong>No. of Properties</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelNoOfProperties" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow>

                        <asp:TableCell>
                    <strong>Toured With</strong>
                        </asp:TableCell>

                        <asp:TableCell ColumnSpan="2">
                            <asp:Label ID="LabelTouredWith" runat="server" Text="Label"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ColumnSpan="2"></asp:TableCell>

                    </asp:TableRow>

                </asp:Table>
                <br />

                <asp:Table ID="TableTourBody" runat="server" Width="100%" BorderWidth="0"
                    GridLines="Both" Style="font-family: Calibri">

                    <asp:TableRow>

                        <asp:TableCell HorizontalAlign="Center">
                    <strong>Ref.</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                    <strong>Name</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                    <strong>Address</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                    <strong>Town</strong>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                    <strong>Contact No.</strong>
                        </asp:TableCell>

                        <asp:TableCell Width="70px" HorizontalAlign="Center">
                    <strong>Price</strong>
                        </asp:TableCell>

                        <asp:TableCell Width="100px" HorizontalAlign="Center">
                    <strong>Time</strong>
                        </asp:TableCell>
                          <asp:TableCell HorizontalAlign="Center">
                    <strong>GPS</strong>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center">
                    <strong>Key</strong>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty1" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference1" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName1" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress1" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown1" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo1" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice1" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour1" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator1" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute1" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude1" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude1" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey1" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty2" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference2" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName2" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress2" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown2" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo2" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice2" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour2" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator2" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute2" runat="server"></asp:Label>
                        </asp:TableCell>
                         <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude2" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude2" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey2" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty3" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference3" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName3" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress3" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown3" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo3" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice3" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour3" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator3" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute3" runat="server"></asp:Label>
                        </asp:TableCell>
                          <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude3" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude3" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey3" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty4" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference4" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName4" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress4" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown4" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo4" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice4" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour4" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator4" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute4" runat="server"></asp:Label>
                        </asp:TableCell>
                           <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude4" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude4" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey4" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty5" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference5" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName5" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress5" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown5" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo5" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice5" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour5" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator5" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute5" runat="server"></asp:Label>
                        </asp:TableCell>
                         <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude5" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude5" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey5" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty6" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference6" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName6" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress6" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown6" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo6" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice6" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour6" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator6" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute6" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude6" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude6" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey6" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty7" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference7" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName7" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress7" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown7" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo7" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice7" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour7" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator7" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute7" runat="server"></asp:Label>
                        </asp:TableCell>
                         <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude7" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude7" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey7" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty8" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference8" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName8" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress8" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown8" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo8" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice8" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour8" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator8" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute8" runat="server"></asp:Label>
                        </asp:TableCell>
                          <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude8" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude8" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey8" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty9" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference9" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName9" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress9" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown9" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo9" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice9" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour9" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator9" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute9" runat="server"></asp:Label>
                        </asp:TableCell>
                            <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude9" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude9" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey9" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow ID="TableRowProperty10" runat="server" Visible="false">

                        <asp:TableCell>
                            <asp:Label ID="LabelReference10" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelName10" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelAddress10" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelTown10" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell>
                            <asp:Label ID="LabelContactNo10" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="LabelPrice10" runat="server"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Label ID="LabelTimeHour10" runat="server"></asp:Label>
                            <asp:Label ID="LabelTimeSeparator10" runat="server" Text=":" Visible="false"></asp:Label>
                            <asp:Label ID="LabelTimeMinute10" runat="server"></asp:Label>
                        </asp:TableCell>
                          <asp:TableCell>
                            <asp:Label ID="LabelGPS_latitude10" runat="server"></asp:Label><br />
                            <asp:Label ID="LabelGPS_longitude10" runat="server"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelKey10" runat="server"></asp:Label>
                        </asp:TableCell>

                    </asp:TableRow>

                </asp:Table>
                <br />

                <asp:Table runat="server" Width="100%" BorderWidth="0" CellPadding="10">

                    <asp:TableRow>

                        <asp:TableCell Width="20px" BorderWidth="0" VerticalAlign="Top">
                            <asp:Image ID="ImageBritishFlag" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell Font-Names="Calibri" Font-Size="X-Small" BorderWidth="0" VerticalAlign="Top" HorizontalAlign="Justify">
                    The person/s who visits the above mentioned property declare that they have not visited this property before  and that they have not had knowledge of this sale offer through any other estate agencies than Inland Andalucia Ltd and they oblige themselves not to carry out any dealing in order to purchase the property by themselves, through PoA or through third parties or relatives. In the event that they manage to acquire the property for themselves or for their relatives within 2 years, they acknowledge that they shall pay Inland Andalucia Ltd the 5% of the asking price + VAT, with a minimum of 3000 € + plus VAT as commission for the sale as form of compensation.
                        </asp:TableCell>

                        <asp:TableCell Width="25px" BorderWidth="0" VerticalAlign="Top">
                            <asp:Image ID="ImageSpanishFlag" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell Font-Names="Calibri" Font-Size="X-Small" BorderWidth="0" VerticalAlign="Top" HorizontalAlign="Justify">
                         Las personas que visitan el inmueble reseñado arriba declaran no haber visitado con anterioridad este inmueble ni haber tenido conocimiento de su oferta de venta a través de otras agencias inmobiliarias diferentes de Inland Andalucia Ltd  y se comprometen a no realizar ninguna gestión encaminada a comprarlo por sí mismo, por medio de apoderado o por conducto de terceras personas o familiares. En caso de que lo adquirieran para sí o para su familia en el plazo de 2 años,  se obligan a abonar a Inland Andalucia Ltd el porcentaje del 5% del precio + IVA, mínimo de 3.000 € más IVA, en concepto de comisión.
                        </asp:TableCell>

                    </asp:TableRow>

                </asp:Table>

            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
</body>
</html>
