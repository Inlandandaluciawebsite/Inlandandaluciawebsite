Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class AddTownInfo
    Inherits System.Web.UI.Page

    Public Event CreateTour()
    Public Event BuyerSelected()
    Dim CBuyer As ClassBuyer
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
    End Sub

    Protected Sub ButtonSave_Click(sender As Object, e As EventArgs)
        Dim proc As String = "USP_tblTownInfoPages_Insert"
        Dim id As Int16 = 0
        If Request.QueryString.HasKeys() Then
            proc = "USP_tblTownInfoPages_Update"
            id = Convert.ToInt32(Request.QueryString(0))
        End If
        Dim sql As SqlParameter() = New SqlParameter(23) {}
        sql(0) = New SqlParameter("@MetaTitle", txtMetaTitle.Text)
        sql(1) = New SqlParameter("@MetaKeyword", txtMetaKeywords.Text)
        sql(2) = New SqlParameter("@MetaDescription ", txtMetaDescription.Text)
        sql(3) = New SqlParameter("@Heading", txtTopHeading.Text)
        sql(4) = New SqlParameter("@PageName", txtPageName.Text)
        sql(5) = New SqlParameter("@Residents", Convert.ToInt32(txtResidents.Text))
        sql(6) = New SqlParameter("@HealthClinic", chkHealthClinic.Checked)
        sql(7) = New SqlParameter("@ShopsBarsRestaurants", chkShopsBarsRestaurant.Checked)
        sql(8) = New SqlParameter("@Schools", chkSchools.Checked)
        sql(9) = New SqlParameter("@Municipalpool", chkMunicipalpool.Checked)
        sql(10) = New SqlParameter("@GolfNearBy", chkGolfnearby.Checked)
        sql(11) = New SqlParameter("@DistanceNearBy", txtDistanceNearBy.Text)
        sql(12) = New SqlParameter("@BeachDistance", txtBeachDistance.Text)
        sql(13) = New SqlParameter("@BusAndTrainService", chkBusAndTrainService.Checked)
        sql(14) = New SqlParameter("@MalagaDistance", Convert.ToInt32(txtMalagaDistance.Text))
        sql(15) = New SqlParameter("@GranadaDistance", Convert.ToInt32(txtGranadaDistance.Text))
        sql(16) = New SqlParameter("@SevillaDistance", Convert.ToInt32(txtSevillaDistance.Text))
        sql(17) = New SqlParameter("@LocalInformation", txtLocalInformation.Text)
        sql(18) = New SqlParameter("@MainInformation", txtMainDescription.Text)
        sql(19) = New SqlParameter("@Region_ID", drpRegion.SelectedValue)
        sql(20) = New SqlParameter("@TopDescription", txtTopDescription.Text)
        sql(21) = New SqlParameter("@PageId", id)
        sql(22) = New SqlParameter("@Area_Id", drpArea.SelectedValue)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, proc, sql)

        'Create OR  Update Folders in townguide for page's images
        If (Not System.IO.Directory.Exists(Server.MapPath("/Images/townguide/" & drpArea.SelectedItem.Text.ToLower().Replace(" ", "-")))) Then
            System.IO.Directory.CreateDirectory(Server.MapPath("/Images/townguide/" & drpArea.SelectedItem.Text.ToLower().Replace(" ", "-")))
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''

        Response.Redirect("ManageTownInfo.aspx")
    End Sub
    Private Sub AddTownInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Bind all Areas from database
            If Request.QueryString.HasKeys() Then
                ID = Convert.ToInt32(Request.QueryString(0))
                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@PageId", ID)
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_tbltowninfopages_select_by_pageid", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    txtTopHeading.Text = Convert.ToString(dt.Rows(0)("Heading"))
                    txtTopDescription.Text = Convert.ToString(dt.Rows(0)("TopDescription"))
                    txtMetaTitle.Text = Convert.ToString(dt.Rows(0)("MetaTitle"))
                    txtMetaKeywords.Text = Convert.ToString(dt.Rows(0)("MetaKeyword"))
                    txtMetaDescription.Text = Convert.ToString(dt.Rows(0)("MetaDescription"))
                    txtPageName.Text = Convert.ToString(dt.Rows(0)("PageName"))
                    chkBusAndTrainService.Checked = Convert.ToBoolean(dt.Rows(0)("BusAndTrainService"))
                    chkGolfnearby.Checked = Convert.ToBoolean(dt.Rows(0)("GolfNearBy"))
                    chkHealthClinic.Checked = Convert.ToBoolean(dt.Rows(0)("HealthClinic"))
                    chkMunicipalpool.Checked = Convert.ToBoolean(dt.Rows(0)("Municipalpool"))
                    chkSchools.Checked = Convert.ToBoolean(dt.Rows(0)("Schools"))
                    chkShopsBarsRestaurant.Checked = Convert.ToBoolean(dt.Rows(0)("ShopsBarsRestaurants"))
                    txtDistanceNearBy.Text = Convert.ToString(dt.Rows(0)("DistanceNearBy"))
                    txtResidents.Text = Convert.ToString(dt.Rows(0)("Residents"))
                    txtBeachDistance.Text = Convert.ToString(dt.Rows(0)("BeachDistance"))
                    txtGranadaDistance.Text = dt.Rows(0)("GranadaDistance").ToString()
                    txtMalagaDistance.Text = dt.Rows(0)("MalagaDistance").ToString()
                    txtSevillaDistance.Text = dt.Rows(0)("SevillaDistance").ToString()
                    txtMainDescription.Text = dt.Rows(0)("MainInformation").ToString()
                    txtLocalInformation.Text = dt.Rows(0)("LocalInformation").ToString()
                    drpRegion.SelectedValue = dt.Rows(0)("Region_Id").ToString()
                    bindAreas()
                    drpArea.SelectedValue = dt.Rows(0)("Area_Id").ToString()
                    divPageImages.Visible = True
                    divLocalInformation.Visible = True
                    divMainDescription.Visible = True
                    BindPageImages()
                End If
            Else
                txtLocalInformation.Text = GetContent("LocalInformation")
                txtMainDescription.Text = GetContent("MainInformation")
            End If
        End If
    End Sub
    Protected Sub drpRegion_TextChanged(sender As Object, e As EventArgs)
        bindAreas()
    End Sub
    Public Sub bindAreas()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@region_id", drpRegion.SelectedValue)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_AreaByRegionId_v2", sql).Tables(0)
        drpArea.DataSource = dt
        drpArea.DataValueField = "id"
        drpArea.DataTextField = "text"
        drpArea.DataBind()

        If Not Request.QueryString.HasKeys() Then
            'Set Page Name & Meta Keywords accordingly as per region & area selection
            txtPageName.Text = drpArea.SelectedItem.Text.ToLower().Replace(" ", "") + "-" + drpRegion.SelectedItem.Text.ToLower().Replace(" ", "") + "-" + "bargain-inlandpropertyforsale-andalucia"
            txtMetaKeywords.Text = drpArea.SelectedItem.Text.ToLower().Replace(" ", "") + "," + drpRegion.SelectedItem.Text.ToLower().Replace(" ", "") + "," + "bargain,inlandpropertyforsale,andalucia"
        End If

    End Sub
    Public Function GetContent(Title As String) As String
        Dim content As String = ""
        If Title = "LocalInformation" Then
            content = "<div class='row'>" & vbCrLf &
        "<div class='location-info'>" & vbCrLf &
        "<div class='col-md-6 col-sm-6'>" & vbCrLf &
        "<h4>Local Information</h4>" & vbCrLf &
        "<div class='col-md-4 col-sm-4'><img src='../images/townguide/almedinilla/coa-almedinilla.jpg' alt='Alcala de Real Coat of Arms' /></div>" & vbCrLf &
        "<div class='col-md-8 col-sm-8'>" & vbCrLf &
        "<h5>Ayuntamiento de Marinaleda</h5>" & vbCrLf &
        "<p>de Benameji Plaza de la Constitucion, 1 14910, Benameji (Cordoba) Telephone: 954-816-220  E-mail: ayuntamiento@benameji.es Web: http://www.benameji.es</p>" & vbCrLf &
        "<p><a href='http://www.almedinilla.es/' target='_blank'>http://www.almedinilla.es/</a></p>" & vbCrLf &
        "<p>&nbsp;</p>" & vbCrLf &
        "</div>" & vbCrLf &
        "</div>" & vbCrLf &
        "<div class='col-md-6 col-sm-6'><img class='img-bdr mrg-10t' src='../images/townguide/almedinilla/almedinilla1.jpg' alt='Alacala la Real' /></div>" & vbCrLf &
        "</div>" & vbCrLf &
        "</div>"
        Else
            content = "<div Class='row'>" & vbCrLf &
                "<div Class='cordoba-details-2'>" & vbCrLf &
                "<div Class='col-md-12'>" & vbCrLf &
                "<h3> Benjameji information</h3>" & vbCrLf &
                "</div>" & vbCrLf &
                "</div>" & vbCrLf &
                "</div>" & vbCrLf &
                "<div Class='row'>" & vbCrLf &
                "<div Class='mollina-information-dtl'>" & vbCrLf &
                "<div Class='col-md-8 col-sm-8'>" & vbCrLf &
                "<div Class='mollina-information-dtl'>" & vbCrLf &
                "<p> Walking through the village, the most important monument Is the parish church which Is dedicated To the Immaculate Conception. Its facade Of yellow blocks, which faces the square And the Single arch opens onto a niche Of a stony image Of the Immaculate Conception. In the epistle side Of the tower stands the eighteenth century square brick, except For the belfry, which Is octagonal.</p>" & vbCrLf &
                "<p> The Constitution Square Is a reflection Of everyday life. Encouraged, where women go To buy, contemplate about dynamic trade, etc.</p>" & vbCrLf &
                "</div>" & vbCrLf &
                "</div>" & vbCrLf &
                "<div Class='col-md-4 col-sm-4'>" & vbCrLf &
                "<div Class='mollina-information-dtl'><img class='img-bdr' src='/images/townguide/benameji/benameji2.jpg' alt='Benameji bridge' /></div>" & vbCrLf &
                "</div>" & vbCrLf &
                "</div>" & vbCrLf &
                "</div>" & vbCrLf &
                "<div Class='row'>" & vbCrLf &
                "<div Class='mollina-information-dtl'>" & vbCrLf &
                "<div Class='col-md-8 col-sm-8 mollina-information-dtl-2'>" & vbCrLf &
                "<p> Benameji currently known For its urban design, which comes from the mid sixteenth century, parallel And perpendicular streets, characteristic Of both Renaissance urban populations As New creation. This monument stands the Main Plaza, a large square space that once was chaired by the palace Of the Marquis Of Benameji. Where after simple facade hid a grandiose Renaissance courtyard With arches Or columns Of jasper discount On colorado, several rooms With coffered ceilings And a staircase In which there was a coffered dome style Hern&aacute;n Ruiz. The site Of the palace Is occupied by the Town Hall To retain shields In front Of the palace.</p>" & vbCrLf &
                "</div>" & vbCrLf &
                "<div Class='col-md-4 col-sm-4'><img class='img-bdr' src='/images/townguide/benameji/benameji3.jpg' alt='View of Benameji' /></div>" & vbCrLf &
                "</div>" & vbCrLf &
                "</div>" & vbCrLf &
                "<div Class='row'>" & vbCrLf &
                "<div Class='mollina-information-dtl'>" & vbCrLf &
                "<div class='col-md-8 col-sm-8 mollina-information-dtl-2'>" & vbCrLf &
                "<p>The architect was also responsible for the magnificent stonework bridge over the river Genil, whose channel anchuroso saves a bow and two smaller ponds separated by semi-cylindrical.</p>" & vbCrLf &
                "<p>At the end of Benameji Castle is located Gomez Arias, of Muslim origin, now only some remains, mainly the walls of a tower.</p>" & vbCrLf &
                "</div>" & vbCrLf &
                "<div class='col-md-4 col-sm-4'><img class='img-bdr' src='/images/townguide/benameji/benameji4.jpg' alt='Benameji square' /></div>" & vbCrLf &
                "</div>" & vbCrLf &
                "</div>" & vbCrLf &
                "<div class='row'>" & vbCrLf &
                "<div class='mollina-information-dtl'>" & vbCrLf &
                "<div class='col-md-8 col-sm-8 mollina-information-dtl-2'>" & vbCrLf &
                "<p>&raquo;&nbsp;<a title='More information on towns of Andalucia' href='/TownLocationInfo.aspx'>More information on towns of Andalucia</a></p>" & vbCrLf &
                "</div>" & vbCrLf &
                "<div class='col-md-4 col-sm-4'><img class='img-bdr' src='/images/townguide/benameji/benameji5.jpg' alt='Benameji castle' /></div>" & vbCrLf &
                "</div>" & vbCrLf &
                "</div>"
        End If
        Return content
    End Function
    Protected Sub grdPageImages_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
    End Sub
    Protected Sub btnSaveImage_Click(sender As Object, e As EventArgs)
        If Request.QueryString.HasKeys() Then
            If fucPageImage.HasFile Then
                'First save image in related folder & then save image infromation in database

                Dim areaName As String = drpArea.SelectedItem.Text
                Dim imagePath As String = "/images/townguide/" & areaName.ToLower().Replace(" ", "-")
                fucPageImage.SaveAs(Server.MapPath(imagePath) & "/" & fucPageImage.FileName)
                ID = Convert.ToInt32(Request.QueryString(0))
                Dim sql As SqlParameter() = New SqlParameter(2) {}
                sql(0) = New SqlParameter("@ImageName", fucPageImage.FileName)
                sql(1) = New SqlParameter("@Page_Id", ID)
                sql(2) = New SqlParameter("@Area_Id", drpArea.SelectedValue)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoImages_Insert", sql)
                BindPageImages()
            Else
                Page.RegisterStartupScript("script", "<script language='javascript'>alert('please select image first !')</script>")
            End If
        End If
    End Sub
    Public Sub BindPageImages()
        If Request.QueryString.HasKeys() Then
            ID = Convert.ToInt32(Request.QueryString(0))
            Dim sql As SqlParameter() = New SqlParameter(0) {}
            sql(0) = New SqlParameter("@Page_Id", ID)
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoImages_SelectAll_By_PageId", sql).Tables(0)
            If dt.Rows.Count > 0 Then
                grdPageImages.DataSource = dt
                grdPageImages.DataBind()
            Else
                grdPageImages.DataSource = dt
                grdPageImages.DataBind()
            End If
        End If
    End Sub
    Protected Sub grdPageImages_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "DeleteImage" Then

            'First delete image from database & then from its related folder
            Dim ImageId = Convert.ToInt16(e.CommandArgument.ToString())
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@ImageId", ImageId)
            Dim imageName As String = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTownInfoImages_Delete", sql).Tables(0).Rows(0)("imageName").ToString()

            Dim areaName As String = drpArea.SelectedItem.Text
            Dim imagePath As String = "/images/townguide/" & areaName.ToLower().Replace(" ", "-") & "/" & imageName
            System.IO.File.Delete(Server.MapPath(imagePath))

        End If
        BindPageImages()
    End Sub
    Protected Sub drpArea_TextChanged(sender As Object, e As EventArgs)
        'Set Page Name & Meta Keywords accordingly as per region & area selection
        txtPageName.Text = drpArea.SelectedItem.Text.ToLower().Replace(" ", "") + "-" + drpRegion.SelectedItem.Text.ToLower().Replace(" ", "") + "-" + "bargain-inlandpropertyforsale-andalucia"
        txtMetaKeywords.Text = drpArea.SelectedItem.Text.ToLower().Replace(" ", "") + "," + drpRegion.SelectedItem.Text.ToLower().Replace(" ", "") + "," + "bargain,inlandpropertyforsale,andalucia"
    End Sub
End Class
