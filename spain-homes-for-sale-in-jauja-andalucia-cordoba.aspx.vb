
Partial Class jauja
    Inherits BasePage
    '  Inherits System.Web.UI.Page
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    ' Set Session Variables
    '    Session("RegionID") = 1
    '    Session("AreaID") = 535
    '    ' Get the View Properties Button
    '    Page.Title = "Inland Andalucia | Jauja Andalucia"

    '    ' Init Class
    '    Dim CTownMap As Control = LoadControl("Controls/WebUserControlLocationMap.ascx")

    '    ' Add this to the Update Panel
    '    UpdatePanelTownMap.ContentTemplateContainer.Controls.Add(CTownMap)

    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables
        Session("RegionID") = 1
        Session("AreaID") = 535
        ' Get the View Properties Button
        Page.Title = "Inland Andalucia | Jauja Andalucia"

        ' Init Class
        Dim CTownMap As Control = LoadControl("Controls/WebUserControlLocationMap.ascx")

        ' Add this to the Update Panel
        UpdatePanelTownMap.ContentTemplateContainer.Controls.Add(CTownMap)

    End Sub
End Class
