
Partial Class guide_priego_of_cordoba
    '  Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables
        Session("RegionID") = 1
        Session("AreaID") = 880
        ' Get the View Properties Button
        ' ViewProperties.InnerHtml = "<img src='images/buttons/view-properties.gif' alt=""View properties""  height=""31"" border=""0"" align=""right"" />"
        Page.Title = "Inland Andalucia | Priego de Cordoba"
        ' Init Class
        Dim CTownMap As Control = LoadControl("Controls/WebUserControlLocationMap.ascx")

        ' Add this to the Update Panel
        UpdatePanelTownMap.ContentTemplateContainer.Controls.Add(CTownMap)

    End Sub
End Class
