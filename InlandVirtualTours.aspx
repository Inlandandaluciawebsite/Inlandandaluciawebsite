<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Translation.aspx.vb" Inherits="ClassTranslation" %>
<%@ Register Src="Controls/WebUserControlHeader.ascx" TagName="Header" TagPrefix="ucHeader" %>
<%@ Register Src="Controls/WebUserControlFooter.ascx" TagName="Footer" TagPrefix="ucFooter" %>
<%@ Register Src="Controls/WebUserControlNavigation.ascx" TagName="Navigation" TagPrefix="ucNavigation" %>
<%@ Register Src="Controls/WebUserControlSearchForm.ascx" TagName="SearchForm" TagPrefix="ucSearchForm" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Inland Andalucia | Virtual Tours</title>
<meta name="description" content="Search in a  selection of our property virtual tours, youll get an idea of our portfolio such as country, rural, and inland properties ranging from fincas, villas, townhouses to apartments and new developments. These properties are all found in the areas of Antequera, Cadiz, Cordoba, Granada, Malaga, and Sevilla where you will find your ideal inland property. " />
<meta name="keywords" content=" andalucia, andalusia, airports" />
<%  Response.WriteFile("include/googlecode.aspx")%>
<link rel="Shortcut Icon" href="/Images/Icons/favicon.ico" type="image/x-icon"/>
<link href="css/style.css" rel="stylesheet" type="text/css" /><link rel="stylesheet" href="http://weatherandtime.net/new_wid/w_2/style.css" type="text/css" media="screen" />
<script language="javascript" src="/js/CheckFieldsContactForm.js" type="text/javascript"></script>


<!--[if IE 5]>
<style type="text/css"> 
/* place css box model fixes for IE 5* in this conditional comment */
.twoColFixRtHdr #sidebar1 { width: 220px; }
</style>
<![endif]--><!--[if IE]>
<style type="text/css"> 
/* place css fixes for all versions of IE in this conditional comment */
.twoColFixRtHdr #sidebar1 { padding-top: 30px; }
.twoColFixRtHdr #mainContent { zoom: 1; }
/* the above proprietary zoom property gives IE the hasLayout it needs to avoid several bugs */
</style>
<![endif]-->
</head>

<body class="twoColFixRtHdr">
<form ID="InlandVirtualTours" RunAt="server">
<div id="container">
 <div id="header"><ucHeader:Header id="Header1" runat="server" />
  <div class="logo"> <a href="http://www.inlandandalucia.com"><img src="images/main/inlandandalucia.png" alt="Inland Andalucia Bargain Properties" width="354" height="170" border="0" /></a></div>
 </div>
  <div class="clearfloat"></div>
   <div class="topnavwrap"><ucNavigation:Navigation id="Navigation1" runat="server" />
      </div>
<div class="clearfloat"></div>
  <div class="wrap"> <div class="center"><div class="space"></div><div id="sidebar1">
		   
        <asp:ScriptManager id="ScriptManagerSearchForm" runat="server" EnablePartialRendering="true"/>
            <asp:UpdatePanel ID="UpdatePanelSearchForm" runat="server">
                <ContentTemplate>
                    <ucSearchForm:SearchForm id="WebUserControlSearchForm1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
    
<%	
	    Response.WriteFile("include/top30.aspx")
	    Response.WriteFile("include/invest2let.aspx")
	    Response.WriteFile("include/testimon.aspx")
		Response.WriteFile("include/googlemap.aspx")
    %>
  </div>
  <div id="mainContent">
    <h1>
  <!-- METADATA TYPE="typelib" UUID="00000200-0000-0010-8000-00AA006D2EA4" NAME="ADO Type Library"-->
  <%

Response.Buffer = True		'Turn buffering on
Response.Expires = -1		'Page expires immediately

'Constants
Const MIN_PAGESIZE = 3		'Minimum pagesize
Const MAX_PAGESIZE = 9		'Maximum pagesize
Const DEF_PAGESIZE = 6		'Default pagesize

'Variables
Dim objCn					'ADO DB connection object
Dim objRs					'ADO DB recordset object
Dim blnWhere				'True/False for have WHERE in sql already
Dim intRecord				'Current record for paging recordset
Dim intPage					'Requested page
Dim intPageSize				'Requested pagesize
Dim sql						'Dynamic sql query string

'Create objects
Set objCn = Server.CreateObject("ADODB.Connection")
Set objRs = Server.CreateObject("ADODB.Recordset")

'Set/initialize variables
intRecord = 1
blnWhere = False

'-Get/set requested page
intPage = MakeLong(Request("page"))
If intPage < 1 Then intPage = 1

'-Get/set requested pagesize
If IsEmpty(Request("pagesize")) Then	'Set to default
	intPageSize = DEF_PAGESIZE
Else
	intPageSize = MakeLong(Request("pagesize"))
	'Make sure it fits our min/max requirements	
	If intPageSize < MIN_PAGESIZE Then
		intPageSize = MIN_PAGESIZE
	ElseIf intPageSize > MAX_PAGESIZE Then
		intPageSize = MAX_PAGESIZE
	End If
End If

'-Build dynamic sql
sql = "SELECT reference, areaname, subareaname, prize FROM Property, Area, Subarea WHERE Property.show AND Property.area=Area.id AND Property.subarea=Subarea.id ORDER BY prize ASC;"
'--Dynamic sql finished

'Create and open connection object
With objCn
	.CursorLocation = adUseClient
	.ConnectionTimeout = 15
	.CommandTimeout = 30
	.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
						"Data Source=" & Server.MapPath("./VrTourDB/VRTours.mdb") & ";"
	.Open
End With

'Create and open recordset object
With objRs
	.ActiveConnection = objCn
	.CursorLocation = adUseClient
	.CursorType = adOpenForwardOnly
	.LockType = adLockReadOnly
	.Source = sql
	.PageSize = intPageSize
	.Open
	Set .ActiveConnection = Nothing	'Disconnect the recordset
End With

'Creates a long value from a variant, invalid always set to zero
Function MakeLong(ByVal varValue)
	If IsNumeric(varValue) Then
		MakeLong = CLng(varValue)
	Else
		MakeLong = 0
	End If
End Function

'Euro-Pounds Rate
Dim rateEurosPounds 
rateEurosPounds = 1.45

'Converts Euros to Pounds
Function convertEurosToPounds(euros)
	convertEurosToPounds = euros / rateEurosPounds
End Function

'Returns a neatly made paging string, automatically configuring for request
'variables, regardless of in querystring or from form, adjust output to your needs.
Function Paging(ByVal intPage, ByVal intPageCount, ByVal intRecordCount)
	Dim strQueryString
	Dim strScript
	Dim intStart
	Dim intEnd
	Dim strRet
	Dim i

	If intPage > intPageCount Then
		intPage = intPageCount
	ElseIf intPage < 1 Then 
		intPage = 1
	End If
	
	If intRecordCount = 0 Then
		strRet = "No Records Found"
	ElseIf intPageCount = 1 Then
		strRet = "End Of Hits"
	Else
		For i = 1 To Request.QueryString.Count
			If LCase(Request.QueryString.Key(i)) <> "page" Then
				strQueryString = strQueryString & "&" 
				strQueryString = strQueryString & Server.URLEncode(Request.QueryString.Key(i)) & "=" 
				strQueryString = strQueryString & Server.URLEncode(Request.QueryString.Item(i))
			End If
		Next

		For i = 1 To Request.Form.Count
			If LCase(Request.Form.Key(i)) <> "page" Then
				strQueryString = strQueryString & "&" 
				strQueryString = strQueryString & Server.URLEncode(Request.Form.Key(i)) & "=" 
				strQueryString = strQueryString & Server.URLEncode(Request.Form.Item(i))
			End If
		Next

		If Len(strQueryString) <> 0 Then
			strQueryString = "?" & Mid(strQueryString, 2) & "&"
		Else
			strQueryString = "?"
		End If

		strScript = Request.ServerVariables("SCRIPT_NAME") & strQueryString
	
		If intPage <= 10 Then
			intStart = 1
		Else
			If (intPage Mod 10) = 0 Then
				intStart = intPage - 9
			Else
				intStart = intPage - (intPage Mod 10) + 1
			End If
		End If

		intEnd = intStart + 9
		If intEnd > intPageCount Then intEnd = intPageCount
	
		strRet = "Page " & intPage & " of " & intPageCount & ": "
	
		If intPage <> 1 Then 
			strRet = strRet & "<a href=""" & strScript
			strRet = strRet & "page=" & intPage - 1 
			strRet = strRet & """>&lt;&lt;Prev</a> "
		End If
	
		For i = intStart To intEnd
			If i = intPage Then
				strRet = strRet & "<span class='StrongOrange'><b>" & i & "</b></span> "
			Else
				strRet = strRet & "<a href=""" & strScript
				strRet = strRet & "page=" & i 
				strRet = strRet & """>" & i & "</a>"
				If i <> intEnd Then strRet = strRet & " "
			End If
		Next
	
		If intPage <> intPageCount Then
			strRet = strRet & " <a href=""" & strScript
			strRet = strRet & "page=" & intPage + 1 
			strRet = strRet & """>Next&gt;&gt;</a> "
		End If
	End If
	
	Paging = strRet
End Function
%>
  <BR>
      Virtual Tours<BR>
      <%If objRs.EOF Then%>
    </h1>
    <p>&nbsp;</p>
	<table width="769" border="1" align="center" cellpadding="0" cellspacing="0" class="texto" >
	<tr>
	<td width="754" align="center" >No Matches with your criteria</td>
	</tr>
	<tr>
	
	<td ><p>&nbsp;</p>
	  <p>Sorry we don't have any properties matching your search criteria on the web site at the moment.
	</p>
	<br>
	<p>
	<p>&nbsp;</p>
	</td>
	
	  
	</tr>
	</table>

	<%Else%>
	<!--Records Found-->
	<table cellpadding="0" cellspacing="0" align="center" width="100%" height="400px"> <!-- Tabla Total -->
	<tr>
		<td align="left" colspan="3">Below is a selection of our property virtual tours, you'll get an idea of our portfolio such as country, rural, and inland properties ranging from fincas, villas, townhouses to apartments and new developments.  These properties are all found in the areas of Antequera, Cadiz, Cordoba, Granada, Malaga, and Sevilla where you will find your ideal inland property.<br>
		  <br>
		</td>
	</tr>
	<tr>
		<!-- Barra Navegación -->
		<td align="right" colspan="3"><%=Paging(intPage, objRs.PageCount, objRs.RecordCount)%></td>
	</tr>
	<tr><td>&nbsp;</td><td></td><td></td></tr>
	<tr><!-- Fila 1-->
	
	<%
	If objRs.PageCount < intPage Then intPage = objRs.PageCount
				objRs.AbsolutePage = intPage
    
	Do While Not objRs.EOF And intRecord <= intPageSize				
	%>
				
			<!--Propiedad -->
		<td>
				<table cellpadding="0" cellspacing="0" border="1" align="center" style="border:2px outset #0E42A7;" height="180">
				<tr>
					<td height="100"><img src="./Pictures/PropsWithVRTours/<%=objRs("reference").Value%>.jpg" alt="Main picture of Inland Property <%=objRs("reference").Value%>" width="152" height="114"></td>
				</tr>
				<tr bgcolor="#0E42A7">
					<td height="80">
						 <table cellpadding="0" cellspacing="0" align="center" width="150">
						 <tr>
							  <td colspan="2" align="center"><span class="YellowText"><strong>Prop. <%=objRs("reference").Value%></strong><br><%=objRs("areaname").Value%> -<BR> <%=objRs("subareaname").Value%><br><strong><%=FormatNumber(objRs("prize").Value, 0) & "€ "%>/&nbsp;&pound;<%=FormatNumber(convertEurosToPounds(objRs("prize").Value),0)%></strong></span><br></td>
						 </tr>
						 <tr>
							 <td align="center" width="75"><a href="PropSearch.asp?referencia=<%=objRs("reference").Value%>" title="Click here to see details of this property." style="color:#FFCC00;"><img src="./Pictures/sobrecito.GIF" width="32" height="32" border="0"><br>Info</a></td>
							 <td align="center"><a href="showVRTour.asp?ref=<%=objRs("reference").Value%>" title="Click here to see the Virtual Reality Tour." style="color:#FFCC00;"><img src="./Pictures/pelicula.gif" width="32" height="32" border="0"><br>VR Tour</a></td>
						 </tr>
						 </table>
					</td>
			</tr>
			</table>
		</td>
		
		<%
				If (intRecord Mod 3) = 0 Then 
			
					'Cambio de Fila
					Response.Write("</tr><tr><td>&nbsp;</td><td></td><td></td></tr><tr>")
			
				End If
		
				intRecord = intRecord + 1
				objRs.MoveNext
			Loop
			
			Do While intRecord <= intPageSize
			
				Response.Write("<td>&nbsp;</td>")
				If (intRecord Mod 3) = 0 Then 
			
					'Cambio de Fila
					Response.Write("</tr><tr><td>&nbsp;</td><td></td><td></td></tr><tr>")
			
				End If
				intRecord=intRecord +1
			Loop
			
		%>
					
		<!-- Barra Navegación -->
		<td align="right" colspan="3"><span class="BlueText"><%=Paging(intPage, objRs.PageCount, objRs.RecordCount)%></span> </td>
		
		<!-- Fin de Página -->
		</tr>
		</table>
		
		<p>&nbsp;</p>
		<!--#includes file="contac-foot.htm"-->
		<p>&nbsp;</p>
		

	<%End If%>

<%
'Object cleanup
If IsObject(objRs) Then
	If Not objRs Is Nothing Then
		If objRs.State = adStateOpen Then objRs.Close
		Set objRs = Nothing
	End If
End If

If IsObject(objCn) Then
	If Not objCn Is Nothing Then
		If objCn.State = adStateOpen Then objCn.Close
		Set objCn = Nothing
	End If
End If
%>

<div class="clearfloat"></div>
  </div>
	<div id="footer">    <ucFooter:Footer id="Footer1" runat="server" />
  
  <!-- end #footer --></div></div></div>
<!-- end #container --></div>
</form>
</body>
</html>
