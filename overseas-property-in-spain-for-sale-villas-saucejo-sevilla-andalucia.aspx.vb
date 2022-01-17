
Partial Class SaucejoLocationInfo
    'Inherits System.Web.UI.Page
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables
       Session("RegionID") = 5
        Session("AreaID") = 385
        ' Get the View Properties Button
        Page.Title = "Inland Andalucia | El Saucejo Andalucia"
       
        ' Init Class
        Dim CTownMap As Control = LoadControl("Controls/WebUserControlLocationMap.ascx")

        ' Add this to the Update Panel
        UpdatePanelTownMap.ContentTemplateContainer.Controls.Add(CTownMap)

    End Sub
End Class
