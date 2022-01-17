
Partial Class WebUserControlIntelliSelect
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If (Not IsPostBack) Then
            MultiHandleSliderExtender1.Minimum = 0
            MultiHandleSliderExtender1.Maximum = 1000
            txtLeftHandle.Text = 0
            txtRightHandle.Text = 100
        End If

    End Sub

End Class
