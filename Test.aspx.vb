
Partial Class Test
    Inherits System.Web.UI.Page

    Public Function GetIPAddress() As String

        ' Get the User's IP
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim szIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(szIPAddress) Then
            szIPAddress = context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = szIPAddress.Split(
                New [Char]() {","c})
            szIPAddress = ipArray(0)
        End If

        ' Return the Result
        Return szIPAddress.Trim

    End Function

End Class
