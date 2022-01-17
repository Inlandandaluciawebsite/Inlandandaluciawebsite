<%@ Control Language="VB" ClassName="WebUserControlSearchResults" CodeFile="WebUserControlSearchResults.ascx.vb" Inherits="WebUserControlSearchResults"%>
<head>
    <script>
        function printpage() {
            window.print()
        }
    </script>
</head>
<body>
    <span id="Header" runat="server"></span>

    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" ID="Table1">
<tr>
							<td width="100%" height="50" align="right">
                                <a href="javascript:history.go(-1)"><img src="<%=GetBackImagePath%>" alt="Back to list" border="0" /></a><span id="NewSearch" runat="server"></span></td>
	  </tr>
		            </table>
<span id="Filtering" runat="server"></span>
                    <br />
					<br>
					<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" ID="Table2">
						<tr>
							<td width="37%"align="left">
							  <div align="left"><b><% =NumberOfResults%>&nbsp;<%=GetTranslation("properties found")%></b></div>
							</td>
						  <td width="20%"align="right"><b><%=GetTranslation("Page")%> <%= Session("PageNumber").ToString.Trim%>&nbsp;<%=GetTranslation("of")%>&nbsp;<%= NumberOfPages%></b>
							</td>
					  <td width="30%"align="center">
								<div align="center"><b>
                                <!-- TODO
								% numeracion = (Session("bloquepag") * 10) + 1
								    numeracion_final = numeracion + 9
								   if numeracion_final > Rs.PageCount then
										numeracion_final = Rs.PageCount
								   end if
								   for n = numeracion to numeracion_final %>
								  &nbsp;<a href='lista.asp?pagina=%=n%>'>%=n%></a>
								% next %>								
                                -->
							
								</b></div>
							</td>
							<td width="13%"align="left"><b>
										<!--%
								if cint(Rs.PageCount) > cint(Session("pagina")) then
								ps = Session("pagina") + 1
								response.write "<a href='lista.asp?pagina=" & ps & "'>&lt;Next&gt;</a>"
								'else
								'response.Write "&gt;" 
								end if 
								%>-->
									<span id="NavigationTop" runat="server"></span>
									</b>							</td>
					  </tr>
					</table>

<!--%
DO WHILE Numero_Registro < Session("CPP") AND NOT Rs.Eof 
%>-->
					
					
					<!--%
  Numero_Registro = Numero_Registro + 1
  Rs.MoveNext
LOOP 	

%>-->
                    <asp:UpdatePanel ID="UpdatePanelDetails" runat="server">
                    </asp:UpdatePanel>
					<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" ID="Table2">
						<tr>
							<td width="37%"align="left">
							  <div align="left"><b><% = NumberOfResults%>&nbsp;<%=GetTranslation("properties found")%></b></div>
							</td>
						  <td width="20%"align="right"><b><%=GetTranslation("Page")%> <%= Session("PageNumber").ToString.Trim%>&nbsp;<%=GetTranslation("of")%>&nbsp;<%= NumberOfPages%></b>
							</td>
					  <td width="30%"align="center">
								<div align="center"><b>

								<!--% numeracion = (session("bloquepag") * 10) + 1
								   numeracion_final = numeracion + 9
								   if numeracion_final > Rs.PageCount then
										numeracion_final = Rs.PageCount
								   end if
								   for n = numeracion to numeracion_final %
								  &nbsp;<a href='lista.asp?pagina=%=n%'>%=n%</a>
								% next %>								-->

							
								</b></div>
							</td>
							<td width="13%"align="left"><b>
										<!--%
								if cint(Rs.PageCount) > cint(Session("pagina")) then
								ps = Session("pagina") + 1
								response.write "<a href='lista.asp?pagina=" & ps & "'>&lt;Next&gt;</a>"
								'else
								'response.Write "&gt;" 
								end if 
								%>-->
								<span id="NavigationBottom" runat="server"></span></b></td>
					  </tr>
					</table>
					<br>
                    <p>&nbsp;
                        </p>
                        <span id="Footer" runat="server"></span>
</body>
    
                    