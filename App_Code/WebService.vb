Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Net
Imports System.Web.Script.Serialization

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <WebMethod()>
    Public Function TranslateGoogle(text As String, fromCulture As String, toCulture As String) As String
        fromCulture = fromCulture.ToLower()
        toCulture = toCulture.ToLower()

        ' normalize the culture in case something like en-us was passed 
        ' retrieve only en since Google doesn't support sub-locales
        Dim tokens As String() = fromCulture.Split("-"c)
        If tokens.Length > 1 Then
            fromCulture = tokens(0)
        End If

        ' normalize ToCulture
        tokens = toCulture.Split("-"c)
        If tokens.Length > 1 Then
            toCulture = tokens(0)
        End If

        Dim url As String = String.Format("http://translate.google.com/translate_a/t?client=j&text={0}&hl=en&sl={1}&tl={2}", HttpUtility.UrlEncode(text), fromCulture, toCulture)

        ' Retrieve Translation with HTTP GET call
        Dim html As String = Nothing
        Try
            Dim web As New WebClient()

            ' MUST add a known browser user agent or else response encoding doen't return UTF-8 (WTF Google?)
            web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0")
            web.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8")

            ' Make sure we have response encoding to UTF-8
            web.Encoding = Encoding.UTF8
            html = web.DownloadString(url)
        Catch ex As Exception
        End Try

        ' Extract out trans":"...[Extracted]...","from the JSON string
        Dim result As String = Regex.Match(html, "trans"":("".*?""),""", RegexOptions.IgnoreCase).Groups(1).Value

        If String.IsNullOrEmpty(result) Then

        End If

        'return WebUtils.DecodeJsString(result);

        ' Result is a JavaScript string so we need to deserialize it properly
        Dim ser As New JavaScriptSerializer()
        Return TryCast(ser.Deserialize(result, GetType(String)), String)
    End Function

    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================

End Class