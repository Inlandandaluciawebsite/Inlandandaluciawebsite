
Partial Class Sierra_de_YeguasLocationInfo
    '  Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables
        Session("RegionID") = 4
        Session("AreaID") = 966
        ' Get the View Properties Button
        Page.Title = "Inland Andalucia |Sierra de Yeguas Andalucia"
        '  ViewProperties.InnerHtml = "<img src='images/buttons/view-properties.gif' alt=""View properties""  height=""31"" border=""0"" align=""right"" />"

        ' Init Class
        Dim CTownMap As Control = LoadControl("Controls/WebUserControlLocationMap.ascx")

        ' Add this to the Update Panel
        UpdatePanelTownMap.ContentTemplateContainer.Controls.Add(CTownMap)

    End Sub
End Class
