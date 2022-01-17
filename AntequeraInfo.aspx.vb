
Partial Class AntequeraInfo
    ' Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables

        Session("RegionID") = 4
        Session("AreaID") = 11
        ' Get the View Properties Button
        Page.Title = "Inland Andalucia |Antequera are Andalucia"
        
    End Sub
End Class
