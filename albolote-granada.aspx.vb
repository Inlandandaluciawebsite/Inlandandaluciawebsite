
Partial Class albolote_granada
    ' Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables
        Session("RegionID") = 4
        Session("AreaID") = 966
        ' Get the View Properties Button
        Page.Title = "Inland Andalucia |About Albolote Granada"
        '   ViewProperties.InnerHtml = "<img src='images/buttons/view-properties.gif' alt=""View properties""  height=""31"" border=""0"" align=""right"" />"

       
    End Sub
End Class
