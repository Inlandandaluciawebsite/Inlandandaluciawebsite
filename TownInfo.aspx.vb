Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Partial Class TownInfo
    Inherits System.Web.UI.Page
    'Inherits BasePage
    Dim objUtil As New ClassUtilities()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Set Session Variables
        ' Get the View Properties Button
        'Page.Title = "Inland Andalucia | Almedinilla"
        ' ViewProperties.InnerHtml = "<img src='images/buttons/view-properties.gif' alt=""View properties""  height=""31"" border=""0"" align=""right"" />"
        Dim PageName As String = TryCast(Page.RouteData.Values("Page"), String)
        If Not IsPostBack Then
            If PageName <> "" Then
                Dim targetLanguageId As Int16 = 2

                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@PageName", PageName)
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoPages_Select_By_PageName", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    lblPageHeading.Text = Convert.ToString(dt.Rows(0)("Area_Name")) + " is located in " + Convert.ToString(dt.Rows(0)("Region_Name")) + " Region , Andalucia "
                    ltrlTopDescription.Text = Convert.ToString(dt.Rows(0)("TopDescription"))
                    Page.Title = Convert.ToString(dt.Rows(0)("MetaTitle"))
                    Page.MetaKeywords = Convert.ToString(dt.Rows(0)("MetaKeyword"))
                    Page.MetaDescription = Convert.ToString(dt.Rows(0)("MetaDescription"))
                    lblQuickHeading.Text = dt.Rows(0)("Heading").ToString()
                    'lblQuickHeading.Text = Convert.ToString(dt.Rows(0)("Area_Name")) + " , " + Convert.ToString(dt.Rows(0)("Region_Name")) + " Region "
                    ltrMapHeading.Text = dt.Rows(0)("Heading").ToString()
                    'chkBusAndTrainService.Checked = Convert.ToBoolean(dt.Rows(0)("BusAndTrainService"))
                    'chkGolfnearby.Checked = Convert.ToBoolean(dt.Rows(0)("GolfNearBy"))
                    'chkHealthClinic.Checked = Convert.ToBoolean(dt.Rows(0)("HealthClinic"))
                    'chkMunicipalpool.Checked = Convert.ToBoolean(dt.Rows(0)("Municipalpool"))
                    'chkSchools.Checked = Convert.ToBoolean(dt.Rows(0)("Schools"))
                    'chkShopsBarsRestaurant.Checked = Convert.ToBoolean(dt.Rows(0)("ShopsBarsRestaurants"))
                    If Convert.ToBoolean(dt.Rows(0)("GolfNearBy")) = False Then
                        divGolfNearBy.Attributes.Add("style", "pointer-events: none;opacity: 0.3;background: #CCC;")
                    End If
                    If Convert.ToBoolean(dt.Rows(0)("BusAndTrainService")) = False Then
                        divBusTrainService.Attributes.Add("style", "pointer-events: none;opacity: 0.3;background: #CCC;")
                    End If
                    If Convert.ToBoolean(dt.Rows(0)("HealthClinic")) = False Then
                        divHealthClinic.Attributes.Add("style", "pointer-events: none;opacity: 0.3;background: #CCC;")
                    End If
                    If Convert.ToBoolean(dt.Rows(0)("Municipalpool")) = False Then
                        divMunicipalPool.Attributes.Add("style", "pointer-events: none;opacity: 0.3;background: #CCC;")
                    End If
                    If Convert.ToBoolean(dt.Rows(0)("Schools")) = False Then
                        divSchools.Attributes.Add("style", "pointer-events: none;opacity: 0.3;background: #CCC;")
                    End If
                    If Convert.ToBoolean(dt.Rows(0)("ShopsBarsRestaurants")) = False Then
                        divShopBars.Attributes.Add("style", "pointer-events: none;opacity: 0.3;background: #CCC;")
                    End If
                    lblDistanceNearBy.Text = Convert.ToString(dt.Rows(0)("DistanceNearBy"))
                    lblResidents.Text = Convert.ToString(dt.Rows(0)("Residents"))
                    lblBeachDistance.Text = Convert.ToString(dt.Rows(0)("BeachDistance"))
                    lblGranadaDistance.Text = dt.Rows(0)("GranadaDistance").ToString()
                    lblMalagaDistance.Text = dt.Rows(0)("MalagaDistance").ToString()
                    lblSevillaDistance.Text = dt.Rows(0)("SevillaDistance").ToString()
                    ltrlMainInformation.Text = dt.Rows(0)("MainInformation").ToString()
                    ltrlLocationInformation.Text = dt.Rows(0)("LocalInformation").ToString()
                    Session("AreaID") = dt.Rows(0)("Area_Id").ToString()
                    Session("RegionID") = dt.Rows(0)("Region_ID").ToString()
                    hplnkViewPropertiesInTown.NavigateUrl = "propsearch.aspx?page=1&regionid=" + dt.Rows(0)("Region_ID").ToString() + "&areaid=" + dt.Rows(0)("Area_Id").ToString() + "&SubAreaId=0&sort=price_asc"
                    'ltrlLocationInformation.Text = Session("AreaID").ToString() + Session("RegionID").ToString()
                End If
            End If
        End If
        ' Init Class
        Dim CTownMap As Control = LoadControl("Controls/WebUserControlLocationMap.ascx")

        ' Add this to the Update Panel
        UpdatePanelTownMap.ContentTemplateContainer.Controls.Add(CTownMap)
    End Sub
End Class
