<%@LANGUAGE="VBSCRIPT" CODEPAGE="1252"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title></title>
</head>
<body>
<span>Procesing ...</span>

<!-- TODO - Use .Net to Send Mail

 On error Resume Next 

 'Creamos el mensaje
 Set ObjSendMail = CreateObject("CDO.Message") 
 'servidor de correo
 ObjSendMail.Configuration.Fields.Item ("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2 'Send the message using the network (SMTP over the network).
 ObjSendMail.Configuration.Fields.Item ("http://schemas.microsoft.com/cdo/configuration/smtpserver") ="smtpout.europe.secureserver.net"
 ObjSendMail.Configuration.Fields.Item ("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25 
 ObjSendMail.Configuration.Fields.Item ("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = False 'Use SSL for the connection (True or False)
 ObjSendMail.Configuration.Fields.Item ("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout") = 60
 ObjSendMail.Configuration.Fields.Item ("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1 'basic (clear-text) authentication
 ObjSendMail.Configuration.Fields.Item ("http://schemas.microsoft.com/cdo/configuration/sendusername") ="info@inlandandalucia.com"
 ObjSendMail.Configuration.Fields.Item ("http://schemas.microsoft.com/cdo/configuration/sendpassword") ="algmailin"
 ObjSendMail.Configuration.Fields.Update
 'End remote SMTP server configuration section==

 'receptor, normalmente quien se encargue de las ventas...
 ObjSendMail.To = "info@inlandandalucia.com"
 
 'titulo del mensaje
 ObjSendMail.Subject = szType & "Contact form Inland Andalucia"
 'declaramos el mensaje en formato htm (esto ya a tu bola...)
 ObjSendMail.From = "info@inlandandalucia.com"
 'componemos el mensaje en htm en una variable

	 k = "<html><body><table border='1'>"
 k = k &"<tr><td>Title</td><td>" & request.Form("titlename") & "</td></tr>"
 k = k & "<tr><td>First Name</td><td>" & request.Form("firstname") & "</td></tr>"
 k = k & "<tr><td>Last Name</td><td>" & request.Form("lastname") & "</td></tr>"
 k = k & "<tr><td>Address</td><td>" & replace(request.Form("address"),vbCrLf,"<br>") & "</td></tr>"
 k = k & "<tr><td>Telephone</td><td>" & request.Form("tel") & "</td></tr>"
 k = k & "<tr><td>Email</td><td>" & request.Form("email") & "</td></tr>"
 k = k & "<tr><td>Comment</td><td>" & replace(request.Form("comment"),vbCrLf,"<br>") & "</td></tr>"
 k = k & "</table></body></html>"
 ObjSendMail.HTMLBody = k
 'enviamos
 ObjSendMail.Send
 If Err.Number <> 0 Then
 	'caso de que falle algún dato lo redireccionamos a una página de error o incluso como en el caso de ADH lo redireccionas al mismo formulario para que vuelva a escribir los datos, eso ya a tu elección, lo envias a donde te parezca.
 	Response.redirect "../EstadoSubscripcionNewsletter.asp?envio=1"
 else
 	'si hemos llegado hasta aqui, redireccionamos a la tipica página de agradecimiento y que contactaremos con él lo antes posible...
 	Response.Redirect "../EstadoSubscripcionNewsletter.asp?envio=0"
 end if
 %>
-->
</body>
</html>
