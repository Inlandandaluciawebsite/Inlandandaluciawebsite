<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAdmin3PropertyDisplayCardItem.ascx.vb" Inherits="WebUserControlAdmin3PropertyDisplayCardItem" %>
<style type="text/css">
    .Images{height:263px}
    .Town{height:20px; overflow:hidden;}
    .ShortDescription{height:20px; overflow:hidden;}
    .Stats{height:50px; overflow:hidden;}
    .Description{height:173px; overflow:hidden;}
	.row {width: 675px;page-break-inside:avoid}
	.clear { clear:both}
	.floatright { float:right; width:425px;}
	.floatleft {float:left; width:250px;}
	.line {width:675px; height:1px; background-color:#CCCCCC;margin:5px 0px;}
    .page-break {
        width: 675px!important;
        height: auto;
        /*page-break-after: always;*/
        page-break-before: always;
    }	
</style>
<div class="row"><div class="floatleft"><div class="Images">
    <asp:Table ID="TableImages" runat="server">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Image ID="ImageMain" runat="server" Height="169" Width="225" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Image ID="ImageSmall1" runat="server" Height="84" Width="111" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Image ID="ImageSmall2" runat="server" Height="84" Width="111" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</div></div>
<div class="floatright">
<div class="Town">
    <strong><asp:Label ID="LabelReference" runat="server"></asp:Label> / <asp:Label ID="LabelTown" runat="server"></asp:Label></strong>
</div>
<div class="ShortDescription">
    <strong><asp:Label ID="LabelShortDescription" runat="server"></asp:Label></strong>
</div>
<div class="Stats">
    <strong>
        <asp:Table ID="TableStats" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelBedsText" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelBedsValue" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="50px">
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelBathsText" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelBathsValue" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelBuiltText" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelBuiltValue" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelPriceText" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="LabelPriceValue" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </strong>
</div>
<div class="Description">
    <asp:Label ID="LabelDescription" runat="server" Font-Size="Small" ></asp:Label>
</div></div>
</div>
<div class="clear"></div>
<div class="line"></div>



