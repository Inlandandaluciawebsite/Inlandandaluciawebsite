Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Partial Class twitterex
    Inherits System.Web.UI.Page
    Public username As String = "Sonika Sharma"
    Public password As String = "12@sonika"


    Public FriendTimeline As String = "http://twitter.com/statuses/friends_timeline/{0}.xml"
    Public Publictimeline As String = "http://twitter.com/statuses/public_timeline.xml"
    Public Archive As String = "http://twitter.com/statuses/user_timeline/{0}.xml"
    Public Replies As String = "http://twitter.com/statuses/replies.xml"
    Public Direct As String = "http://twitter.com/direct_messages.xml"
    Public AuthUser As String = "http://twitter.com/account/verify_credentials.xml"
    Public Update As String = "http://@twitter.com/statuses/update.xml"
    Public Followers As String = "http://twitter.com/statuses/followers.xml"

    Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
       
    End Sub
    Public Function Push(ByVal username As String, _
                         ByVal password As String, _
                         ByVal action As String, _
                         Optional ByVal mode As Integer = 0) As String
        Dim req As WebRequest
        If mode = 0 Then
            req = HttpWebRequest.Create(String.Format(action, username))
        Else
            req = HttpWebRequest.Create(String.Format(action))
        End If

        req.Credentials = New NetworkCredential(username, password)
        Try
            'returns raw xml 
            Dim res As WebResponse = req.GetResponse()
            Dim ret As StreamReader = New StreamReader(res.GetResponseStream())
            Dim retData As String = ret.ReadToEnd()
            ret.Close()
            Return retData.ToString
        Catch ex As Exception
            Return "There was an error please try again..."
        End Try
    End Function

    Public Function PostStatus(ByVal status As String) As String
        Dim ret As String
        Dim req As WebRequest = HttpWebRequest.Create(Update)
        System.Net.ServicePointManager.Expect100Continue = False
        req.Credentials = New NetworkCredential(username, password)

        req.ContentType = "application/x-www-form-urlencoded"
        req.Method = "POST"
        Dim encoding As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()
        Dim bt() As Byte = encoding.GetBytes(String.Format("status={0}", status))

        Dim s As Stream
        Try
            req.ContentLength = bt.Length
            s = req.GetRequestStream()
            s.Write(bt, 0, bt.Length)
        Catch ex As Exception
            Throw ex
        End Try

        Try
            'returns raw xml 
            Dim res As WebResponse = req.GetResponse()
            If res Is Nothing Then
                Return Nothing
            End If

            Dim sr As StreamReader = New StreamReader(res.GetResponseStream())
            ret = sr.ReadToEnd().Trim()
            sr.Close()
        Catch ex As Exception
            Throw ex
        End Try

        Return ret
    End Function
End Class
