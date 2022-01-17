
Partial Class benameji
    ' Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables

        Session("RegionID") = 5
        Session("AreaID") = 585
        Page.Title = "Inland Andalucia | La Luisiana Andalucia"
        ' Get the View Properties Button
        ' ViewProperties.InnerHtml = "<img src='images/buttons/view-properties.gif' alt=""View properties""  height=""31"" border=""0"" align=""right"" />"

        ' Init Class
        Dim CTownMap As Control = LoadControl("Controls/WebUserControlLocationMap.ascx")

        ' Add this to the Update Panel
        UpdatePanelTownMap.ContentTemplateContainer.Controls.Add(CTownMap)

    End Sub
End Class
