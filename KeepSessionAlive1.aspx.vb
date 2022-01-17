
Partial Class KeepSessionAlive
    Inherits System.Web.UI.Page

Protected WindowStatusText As String = ""

    Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not Session("language") = "" Then
                ' Refresh this page 60 seconds before session timeout, effectively resetting the session timeout counter.
                MetaRefresh.Attributes("content") = Convert.ToString((Session.Timeout * 10) - 10) + ";url=KeepSessionAlive.aspx?q=" + Convert.ToString(DateTime.Now.Ticks)

                WindowStatusText = "Last refresh " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
            End If
        Catch ex As Exception

        End Try
       
    End Sub

End Class
