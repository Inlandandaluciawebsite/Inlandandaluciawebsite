Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports crud_utility

Partial Class Admin_ManageProperties
    Inherits System.Web.UI.Page
    Dim redval As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("AdminPropertySelected") = Nothing
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            ViewState("SortExpressionCP") = "Created DESC"
            bindtype()
            bindregion()
            Dim licategory As New ListItem("--Town--", "0")
            drpTown.Items.Insert(0, licategory)
            bedrooms()
            bathrooms()
            bindstatus()
            ' Is this an Admin User
            If Convert.ToBoolean(Session("AdminUser")) Then
                drpAllORPartner.Visible = True
            Else
                drpAllORPartner.Visible = False
            End If
            bindAllPartner()
            If Not Request.QueryString("PageIndex") Is Nothing Then
                txtreference.Text = Request.QueryString("Ref").ToString()
                txtaddress.Text = Request.QueryString("Address").ToString()
                drpproperty.SelectedValue = Request.QueryString("type").ToString()
                drpArea.SelectedValue = Request.QueryString("Area").ToString()
                drpArea_SelectedIndexChanged(Nothing, Nothing)
                drpTown.SelectedValue = Request.QueryString("Town").ToString()
                drpbedrooms.SelectedIndex = Request.QueryString("Beds").ToString()
                drpbathrooms.SelectedIndex = Request.QueryString("Bath").ToString()
                DropDownListStatus.SelectedValue = Request.QueryString("status").ToString()
            End If
            bindadmin()
        End If
    End Sub
    Private Sub bindadmin()
        Dim nPropertyID As Integer = 0
        Dim CUtilities As New ClassUtilities
        Dim dt As DataTable = populateGridView()

        If dt.Rows.Count > 0 Then
            If Not redval = 1 Then
                If Not Request.QueryString("PageIndex") Is Nothing Then
                    grdAdmin.PageIndex = Convert.ToInt32(Request.QueryString("PageIndex")) - 1
                End If
            End If
            CUtilities = Nothing
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            lblmessage.Visible = False
            BtnDelete.Visible = True
        Else
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            lblmessage.Visible = True
            BtnDelete.Visible = False
        End If
        ApplyStyling()
    End Sub
    Protected Sub grdAdmin_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editadmin" Then
            Dim pg As String
            If grdAdmin.PageIndex = 0 Then
                pg = 1
            Else
                pg = Convert.ToString(grdAdmin.PageIndex) + 1
            End If
            ' Response.Redirect("AddVendor.aspx?ContactId=" + e.CommandArgument.ToString())
            Response.Redirect("Property_General.aspx?PropertyId=" + e.CommandArgument.ToString() + "&PageIndex=" + pg + "&Ref=" + txtreference.Text + "&Address=" + txtaddress.Text + "&type=" + drpproperty.SelectedValue + "&Area=" + drpArea.SelectedValue + "&Town=" + drpTown.SelectedValue + "&Beds=" + drpbedrooms.SelectedIndex.ToString() + "&Bath=" + drpbathrooms.SelectedIndex.ToString() + "&status=" + DropDownListStatus.SelectedValue)
        End If
    End Sub
    Protected Sub grdAdmin_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        '  grdAdmin.PageIndex = e.NewPageIndex
        redval = 1
        grdAdmin.PageIndex = e.NewPageIndex
        If Not Session("objects") Is Nothing Then
            grdAdmin.DataSource = Session("objects")
            grdAdmin.DataBind()
        Else
            grdAdmin.DataSource = populateGridView()
            grdAdmin.DataBind()
        End If
        '   bindadmin()
    End Sub
    Protected Sub BtnDelete_Click(sender As Object, e As EventArgs)
        Dim ID As Int32
        For i As Int32 = 0 To grdAdmin.Rows.Count - 1
            Dim chkClient As CheckBox = DirectCast(grdAdmin.Rows(i).FindControl("chkSelect"), CheckBox)
            If chkClient.Checked <> True Then
            Else
                If Convert.ToInt32(Session("AdminID")) <> Convert.ToInt32(grdAdmin.DataKeys(i)(0)) Then
                    ID = Convert.ToInt32(grdAdmin.DataKeys(i)(0))
                    Dim sql As SqlParameter() = New SqlParameter(0) {}
                    sql(0) = New SqlParameter("@Contact_ID", ID)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Vendor_Delete_ById", sql)
                    Page.RegisterStartupScript("script", "<script language='javascript'>alert('Record has been sucessfully removed !');</script>")
                End If
            End If
        Next
        bindadmin()
    End Sub
    Protected Sub grdAdmin_RowDataBound1(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

            ' determine the value of the UnitsInStock field
            Dim lsDataKeyValue As String = grdAdmin.DataKeys(e.Row.RowIndex).Values(0).ToString()
            ' Dim CategoryID As Integer = Convert.ToInt32(DataBinder.Eval(e.Row., "contact_id"))
            If lsDataKeyValue = Request.QueryString("Id") Then
                ' color the background of the row yellow
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9CF06")
                ' ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "EditModalScript", script.ToString(), False)
            End If
            Dim lblIsIssue As Label = DirectCast(e.Row.FindControl("lblisissue"), Label)
            Dim lblIsTour As Label = DirectCast(e.Row.FindControl("lblIsTour"), Label)
            Dim lblIsEightWeeks As Label = DirectCast(e.Row.FindControl("lblIsEightWeeks"), Label)
            Dim lblIsFeatured As Label = DirectCast(e.Row.FindControl("lblIsFeatured"), Label)
            Dim lblIsEightWeeksFeatured As Label = DirectCast(e.Row.FindControl("lblIsEightWeeksFeatured"), Label)
            Dim lblIsExpired As Label = DirectCast(e.Row.FindControl("lblIsExpired"), Label)
            Dim lblStatus As Label = DirectCast(e.Row.FindControl("lblStatus"), Label)

            If lblIsIssue.Text = "Red" And (drpColors.SelectedItem.Value = "0" Or drpColors.SelectedItem.Value = "Red") Then
                e.Row.BackColor = System.Drawing.Color.Red
            End If
            If lblIsTour.Text = "0" And lblIsEightWeeks.Text = "1" And lblStatus.Text = "For Sale" And lblIsFeatured.Text = "0" And (drpColors.SelectedItem.Value = "0" Or drpColors.SelectedItem.Value = "Blue") Then
                e.Row.BackColor = System.Drawing.Color.LightBlue
            End If
            If lblIsTour.Text = "0" And lblIsEightWeeks.Text = "1" And lblIsFeatured.Text = "1" And lblStatus.Text = "For Sale" And (drpColors.SelectedItem.Value = "0" Or drpColors.SelectedItem.Value = "Orange") Then
                e.Row.BackColor = System.Drawing.Color.Orange
            End If
            If lblIsExpired.Text = "1" And lblStatus.Text = "For Sale" And (drpColors.SelectedItem.Value = "0" Or drpColors.SelectedItem.Value = "Yellow") Then
                e.Row.BackColor = System.Drawing.Color.Yellow
            End If
        End If
    End Sub
    Protected Sub imgsearch_Click1(sender As Object, e As EventArgs)
        bindadmin()
    End Sub
    Protected Sub drpArea_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session.Remove("objects")
        bindtown()
        bindadmin()
    End Sub
    Protected Sub drpTown_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session.Remove("objects")
        bindadmin()
    End Sub
    Private Sub bindtype()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@LanguageId", Convert.ToInt32(Session("ContactLanguageID")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_TypeBYId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            drpproperty.DataSource = dt
            drpproperty.DataTextField = "text"
            drpproperty.DataValueField = "id"
            drpproperty.DataBind()
            Dim licategory As New ListItem("--Type--", "0")
            drpproperty.Items.Insert(0, licategory)
        End If
    End Sub
    Private Sub bindAllPartner()
        Dim crudutil As New crud_utility
        Dim dtPartnerDetails As DataTable
        dtPartnerDetails = crudutil.GetAllPartners_Having_Property()
        drpAllORPartner.DataSource = dtPartnerDetails
        drpAllORPartner.DataTextField = "Contact_Name"
        drpAllORPartner.DataValueField = "Contact_Id"
        drpAllORPartner.DataBind()
        Dim firstItem As New ListItem With {
                .Text = "VIEW ALL",
                .Value = 0
            }
        drpAllORPartner.Items.Insert(0, firstItem)
        'drpAllORPartner.Items.Add(firstItem)
    End Sub
    Private Sub bindregion()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_AdminRegion_ShowAll").Tables(0)
        If dt.Rows.Count > 0 Then
            drpArea.DataSource = dt
            drpArea.DataTextField = "Region_Name"
            drpArea.DataValueField = "Region_ID"
            drpArea.DataBind()
            Dim licategory As New ListItem("--Area--", "0")
            drpArea.Items.Insert(0, licategory)
            '  bindbroker()
        End If
    End Sub
    Private Sub bindtown()
        drpTown.Items.Clear()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_AdminLocation_Byparameters").Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dv As New DataView(DirectCast(dt, DataTable))
            ' Filter Results
            dv.RowFilter = "Region_ID = " + drpArea.SelectedValue
            ' Return Results
            dt = dv.ToTable(True, "Area_ID", "Area_Name")
            drpTown.DataSource = dt
            drpTown.DataTextField = "Area_Name"
            drpTown.DataValueField = "Area_ID"
            drpTown.DataBind()
            Dim licategory As New ListItem("--Town--", "0")
            drpTown.Items.Insert(0, licategory)
            '  bindbroker()
        End If
    End Sub
    Private Sub bedrooms()
        drpbedrooms.Items.Clear()
        For nIndex = 1 To 5
            ' Add Items
            drpbedrooms.Items.Add(nIndex.ToString.Trim & "+")
        Next
        Dim licategory As New ListItem("--Beds--", "0")
        drpbedrooms.Items.Insert(0, licategory)
    End Sub
    Private Sub bathrooms()
        drpbathrooms.Items.Clear()
        For nIndex = 1 To 5
            ' Add Items
            drpbathrooms.Items.Add(nIndex.ToString.Trim & "+")
        Next
        Dim licategory As New ListItem("--Baths--", "0")
        drpbathrooms.Items.Insert(0, licategory)
    End Sub
    Private Sub bindstatus()
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@LanguageId", CUtilities.GetLanguageID(Session("Language")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_Status", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            DropDownListStatus.DataSource = dt
            DropDownListStatus.DataTextField = "text"
            DropDownListStatus.DataValueField = "id"
            DropDownListStatus.DataBind()
            Dim licategory As New ListItem("--Status--", "0")
            DropDownListStatus.Items.Insert(0, licategory)
        End If
    End Sub
    Protected Sub drpproperty_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session.Remove("objects")
        bindadmin()
    End Sub
    Protected Sub drpbedrooms_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session.Remove("objects")
        bindadmin()
    End Sub
    Protected Sub drpbathrooms_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session.Remove("objects")
        bindadmin()
    End Sub
    Protected Sub DropDownListStatus_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session.Remove("objects")
        bindadmin()
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
        Dim sortedView As New DataView(populateGridView())
        sortedView.Sort = Convert.ToString(e.SortExpression + " ") & sortingDirection
        Session("objects") = sortedView
        grdAdmin.DataSource = sortedView
        grdAdmin.DataBind()
        ApplyStyling()
        '=======================================================
        'Service provided by Telerik (www.telerik.com)
        'Conversion powered by NRefactory.
        'Twitter: @telerik
        'Facebook: facebook.com/telerik
        '=======================================================
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
    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================
    Public Function populateGridView() As DataTable
        Dim nPropertyID As Integer = 0
        If txtreference.Text.Trim <> String.Empty And txtaddress.Text.Trim = String.Empty Then
            ' Clear the Address Field to avoid Confusion
            txtaddress.Text = String.Empty
            ' Get the Property ID that pertains to the Property Reference Entered 
            ' Is this an Admin User
            If Convert.ToBoolean(Session("AdminUser")) Then
                ' Use any Ref
                Dim sqlref As SqlParameter() = New SqlParameter(1) {}
                sqlref(0) = New SqlParameter("@PropRef", txtreference.Text.Trim)
                Dim dtrf As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_PropertyId_ByPropRef", sqlref).Tables(0)
                If dtrf.Rows.Count > 0 Then
                    nPropertyID = Convert.ToInt32(dtrf.Rows(0)("Property_ID").ToString())
                End If
            Else
                Dim CDataAccess As New ClassDataAccess
                ' Use Partner Refs
                nPropertyID = CDataAccess.PropertyID(txtreference.Text.Trim, Convert.ToInt32(Session("ContactPartnerID")), True)
            End If
        End If
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(10) {}
        sql(0) = New SqlParameter("@PropertyId", nPropertyID)
        sql(1) = New SqlParameter("@PropertyAddress", txtaddress.Text)
        sql(2) = New SqlParameter("@PartnerId", Convert.ToInt32(Session("ContactPartnerID")))
        sql(3) = New SqlParameter("@Type", drpproperty.SelectedValue)
        sql(4) = New SqlParameter("@Area", drpArea.SelectedValue)
        sql(5) = New SqlParameter("@Town", drpTown.SelectedValue)
        sql(6) = New SqlParameter("@Beds", drpbedrooms.SelectedIndex - 1)
        sql(7) = New SqlParameter("@Baths", drpbathrooms.SelectedIndex - 1)
        sql(8) = New SqlParameter("@Status", DropDownListStatus.SelectedValue)
        sql(9) = New SqlParameter("@IsFeatured", 0)
        Dim dt As DataTable
        If drpAllORPartner.Visible = True Then
            If drpAllORPartner.SelectedItem.Value = 0 Then
                dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_ShowAllNew", sql).Tables(0)
            Else
                sql(2) = New SqlParameter("@PartnerId", Convert.ToInt32(drpAllORPartner.SelectedValue))
                dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_ShowAll_By_Partner_Id", sql).Tables(0)
            End If
        ElseIf Request.QueryString("ViewAll") Is Nothing Then
            sql(2) = New SqlParameter("@PartnerId", Convert.ToInt32(Session("ContactPartnerID")))
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_ShowAll_By_Partner_Id", sql).Tables(0)
        Else
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_ShowAllNew", sql).Tables(0)
        End If
        lbltotlacount.Text = dt.Rows.Count
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                dr("Price") = CUtilities.FormatPrice(Convert.ToInt32(dr("Price")))
            Next
        End If

        'Filter Colors 
        If drpColors.SelectedItem.Value <> "0" Then
            Dim color As String = drpColors.SelectedItem.Text
            'Filter datatable based on color selection

            Dim dataView As New DataView
            dataView = dt.DefaultView

            If drpColors.SelectedItem.Text = "Blue" Then
                dataView.RowFilter = "TouredLastTweleveMonths=0 AND IsEightWeeks=1 AND IsFeatured=0 AND Status='For Sale'"
            End If
            If drpColors.SelectedItem.Text = "Orange" Then
                dataView.RowFilter = "TouredLastTweleveMonths=0 AND IsEightWeeks=1 AND IsFeatured=1 AND Status='For Sale'"
            End If
            If drpColors.SelectedItem.Text = "Red" Then
                dataView.RowFilter = "IsIssue='Red'"
            End If
            If drpColors.SelectedItem.Text = "Yellow" Then
                dataView.RowFilter = "IsExpired=1 AND Status='For Sale'"
            End If
            dt = dataView.ToTable
            lbltotlacount.Text = dt.Rows.Count
        End If

        Return dt
    End Function
    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim quantity As String = Integer.Parse(e.Row.Cells(0).Text)
            For Each cell As TableCell In e.Row.Cells
                If quantity = "IsIssue" Then
                    cell.BackColor = Color.Red
                End If
            Next
        End If
    End Sub
    Private Sub ApplyStyling()
        ' If we have Results
        If Not grdAdmin.HeaderRow Is Nothing Then
            ' Hide the ID and Sorting Columns
            grdAdmin.HeaderRow.Cells(0).Visible = True
            ' For each Row
            For Each gvr As GridViewRow In grdAdmin.Rows
                ' Hide the ID and Sorting Columns
                gvr.Cells(0).Visible = True
            Next
        End If
    End Sub
    Protected Sub drpAllORPartner_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindadmin()
    End Sub
    Protected Sub drpColors_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindadmin()
    End Sub
End Class
