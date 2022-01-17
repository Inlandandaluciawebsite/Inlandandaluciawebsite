Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO

Partial Class PropertyPostcodeList
    Inherits System.Web.UI.Page
    Dim cda As New ClassDataAccess
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then

            'Bind Region
            drpRegion.DataSource = cda.Regions()
            drpRegion.DataTextField = "text"
            drpRegion.DataValueField = "id"
            drpRegion.DataBind()
            Dim liRegion As New ListItem("--Select Region--", "0")
            drpRegion.Items.Insert(0, liRegion)
            Dim liArea As New ListItem("--Select Area--", "0")
            drpArea.Items.Insert(0, liArea)
            BindPartnersByRegion()
            'Bind Area
            bindadmin()
        End If
    End Sub
    Private Function bindadmin() As DataTable
        Dim sql As SqlParameter() = New SqlParameter(3) {}
        sql(0) = New SqlParameter("@Region_Id", Convert.ToInt32(drpRegion.SelectedValue))
        sql(1) = New SqlParameter("@Area_Id", Convert.ToInt32(drpArea.SelectedValue))
        sql(2) = New SqlParameter("@SearchType", drpListType.SelectedValue)
        sql(3) = New SqlParameter("@Default_Partner_Id", Convert.ToInt32(drpPartner.SelectedValue))

        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Postcode_All_Details", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
        Else
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
        End If
        Return dt
    End Function
    Protected Sub grdAdmin_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editpostcode" Then

            Dim Row As GridViewRow = ((CType(e.CommandSource, Button)).NamingContainer)
            Dim Latitude As String = TryCast(Row.FindControl("txtLatitude"), TextBox).Text
            Dim Longitude As String = TryCast(Row.FindControl("txtLongitude"), TextBox).Text
            Dim Postcode_Id As String = TryCast(Row.FindControl("hdnPostcode_Id"), HiddenField).Value

            'Update Latitude & Longitude by Postcode_Id
            Dim sqlPostcodeupdate As SqlParameter() = New SqlParameter(2) {}
            sqlPostcodeupdate(0) = New SqlParameter("@GPS_Latitude", Convert.ToDecimal(Latitude))
            sqlPostcodeupdate(1) = New SqlParameter("@GPS_Longitude", Convert.ToDecimal(Longitude))
            sqlPostcodeupdate(2) = New SqlParameter("@Postcode_ID", Convert.ToInt32(Postcode_Id))
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Postcode_Update_LatLong_By_PostcodeId", sqlPostcodeupdate)
            bindadmin()
            '  Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        End If

        'If e.CommandName = "checkcoordinates" Then
        '    Dim postcode_id As Int32 = Convert.ToInt32(e.CommandArgument.ToString())
        '    'Get coordinates by postcode_id
        '    Dim dtcoordinates As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "select * from postcode where postcode_id=" & postcode_id).Tables(0)

        '    Response.Redirect("https://developers-dot-devsite-v2-prod.appspot.com/maps/documentation/utils/geocoder#q%3D" & dtcoordinates.Rows(0)("GPS_Latitude_02").ToString() & "%252C" & dtcoordinates.Rows(0)("GPS_Longitude_02").ToString() & "")
        'End If
    End Sub
    Protected Sub grdAdmin_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdAdmin.PageIndex = e.NewPageIndex
        bindadmin()
    End Sub
    Protected Sub imgsearch_Click1(sender As Object, e As EventArgs)
        bindadmin()
    End Sub
    Protected Sub drpRegion_SelectedIndexChanged(sender As Object, e As EventArgs)

        If drpRegion.SelectedValue = "0" Then
            drpArea.DataSource = Nothing
            drpArea.DataBind()
            drpArea.Items.Clear()
            Dim liArea As New ListItem("--Select Area--", "0")
            drpArea.Items.Insert(0, liArea)

            'Bind partners by region
            'drpPartner.DataSource = Nothing
            'drpPartner.DataBind()
            'drpPartner.Items.Clear()
            'Dim liPartner As New ListItem("--Select Partner--", "0")
            'drpPartner.Items.Insert(0, liPartner)
            BindPartnersByRegion()
        Else
            drpArea.DataSource = cda.Areas(drpRegion.SelectedValue, True)
            drpArea.DataTextField = "text"
            drpArea.DataValueField = "id"
            drpArea.DataBind()
            Dim liArea As New ListItem("--Select Area--", "0")
            drpArea.Items.Insert(0, liArea)
            BindPartnersByRegion()
        End If
    End Sub
    Public Sub BindPartnersByRegion()
        'Bind partners by region
        Dim sqlpartners As SqlParameter() = New SqlParameter(2) {}
        sqlpartners(0) = New SqlParameter("@Region_Id", Convert.ToInt32(drpRegion.SelectedValue))
        sqlpartners(1) = New SqlParameter("@Area_Id", Convert.ToInt32(drpArea.SelectedValue))
        Dim dtPartners As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Parnters_By_Area_Region", sqlpartners).Tables(0)
        drpPartner.DataSource = dtPartners
        drpPartner.DataValueField = "contact_id"
        drpPartner.DataTextField = "contact_name"
        drpPartner.DataBind()
        Dim liPartner As New ListItem("--Select Partner--", "0")
        drpPartner.Items.Insert(0, liPartner)
    End Sub
    Protected Sub grdAdmin_Sorting(sender As Object, e As GridViewSortEventArgs)
        Dim sortingDirection As String = String.Empty
        If direction = SortDirection.Ascending Then
            direction = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            direction = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim sortedView As New DataView(bindadmin())
        sortedView.Sort = Convert.ToString(e.SortExpression + " ") & sortingDirection
        Session("objects") = sortedView
        grdAdmin.DataSource = sortedView
        grdAdmin.DataBind()

    End Sub
    Public Property direction() As SortDirection
        Get
            If ViewState("directionState") Is Nothing Then
                ViewState("directionState") = SortDirection.Ascending
            End If
            Return DirectCast(ViewState("directionState"), SortDirection)
        End Get
        Set
            ViewState("directionState") = Value
        End Set
    End Property
End Class
