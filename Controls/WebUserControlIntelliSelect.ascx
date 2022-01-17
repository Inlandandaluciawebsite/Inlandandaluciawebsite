<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlIntelliSelect.ascx.vb" Inherits="WebUserControlIntelliSelect" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:TextBox ID="txtSlider" runat="server"></asp:TextBox>
<asp:MultiHandleSliderExtender ID="MultiHandleSliderExtender1"
           runat="server"
           TargetControlID ="txtSlider"
           Length="257"
           ShowInnerRail="true"
           ShowHandleHoverStyle="true"
            Minimum="1"
            Maximum="100"
           >

          <asp:MultiHandleSliderTargets>
                   <asp:MultiHandleSliderTarget ControlID="txtLeftHandle" />
                   <asp:MultiHandleSliderTarget ControlID="txtRightHandle"/>
          </asp:MultiHandleSliderTargets>

       </asp:MultiHandleSliderExtender>

       <br />

       <table>
           <tr>
               <td align="left">MININUM VALUE: <asp:TextBox ID="txtLeftHandle" runat="server" Width="30"></asp:TextBox></td>
               <td align="right">MAXIMUM VALUE: <asp:TextBox ID="txtRightHandle" runat="server" Width="30"></asp:TextBox></td>
           </tr>
       </table>
