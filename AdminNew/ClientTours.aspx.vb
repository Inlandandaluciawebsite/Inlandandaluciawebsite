Imports ClassHistory
Imports System.Data

Partial Class ClientTours
    Inherits System.Web.UI.Page
    Private Function GetDDLValue(ByVal ddl As DropDownList) As Integer
        ' If we have a Value Selected
        If ddl.SelectedIndex > 0 Then
            ' Return the Result
            Return Convert.ToInt32(ddl.SelectedValue)
        Else
            ' Return NULL
            Return 0
        End If
    End Function
    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        bindgrid()
    End Sub
    Public Sub LoadSearchOptions()
        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        ' Populate Tour IDs
        DropDownListTourID.DataSource = CDataAccess.ClientTourIDs
        DropDownListTourID.DataTextField = "text"
        DropDownListTourID.DataValueField = "id"
        DropDownListTourID.DataBind()
        DropDownListTourID.Items.Insert(0, "-- Any --")
        ' Populate Buyers
        DropDownListBuyer.DataSource = CDataAccess.Buyers
        DropDownListBuyer.DataTextField = "text"
        DropDownListBuyer.DataValueField = "id"
        DropDownListBuyer.DataBind()
        DropDownListBuyer.Items.Insert(0, "-- Any --")
        ' Populate Tour With
        DropDownListTourWith.DataSource = CDataAccess.Users
        DropDownListTourWith.DataTextField = "text"
        DropDownListTourWith.DataValueField = "id"
        DropDownListTourWith.DataBind()
        DropDownListTourWith.Items.Insert(0, "-- Any --")
        'If logged in user is not admin user
        If Session("AdminUser").ToString() = "False" Then
            DropDownListTourWith.Enabled = False
            DropDownListTourWith.Items.FindByValue(Convert.ToInt32(Session("ContactID"))).Selected = True
        End If
        'txtDateFrom.Text = Session("AdminUser").ToString()
        ' Tidy
        CDataAccess = Nothing
    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        ' Load Search Options
        If Not IsPostBack Then
            LoadSearchOptions()
            btnback.Attributes.Add("onClick", "javascript:history.back(); return false;")
        End If
    End Sub
    Protected Sub GridViewResults_Sorting(sender As Object, e As GridViewSortEventArgs)
        Dim strSortExpression As String() = ViewState("SortExpressionCP").ToString().Split(" ")
        ' If the sorting column is the same as the previous one,  
        ' then change the sort order. 
        If strSortExpression(0) = e.SortExpression Then
            If strSortExpression(1) = "ASC" Then
                ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "DESC"
            Else
                ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "ASC"
            End If
        Else
            ' If sorting column is another column,   
            ' then specify the sort order to "Ascending". 
            ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "ASC"
        End If
        ' Rebind the GridView control to show sorted data. 
        bindgrid()
    End Sub
    Private Sub bindgrid()
        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim dt As DataTable
        Dim dateFrom As DateTime = #1/1/1990#
        Dim dateTo As DateTime = #1/1/2090#
        If txtDateFrom.Text <> "" Then
            dateFrom = Convert.ToDateTime(txtDateFrom.Text)
        End If
        If txtDateTo.Text <> "" Then
            dateTo = Convert.ToDateTime(txtDateTo.Text)
        End If
        dt = CDataAccess.ClientTourSearchNew(GetDDLValue(DropDownListTourID), dateFrom, dateTo, GetDDLValue(DropDownListBuyer), GetDDLValue(DropDownListTourWith))
        Dim dvclientproperties As DataView = dt.DefaultView
        ' set the sort column and sort order. 
        If ViewState("SortExpressionCP") Is Nothing Then
            ViewState("SortExpressionCP") = "Tour Asc"
        End If
        dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()
        GridViewResults.DataSource = dvclientproperties
        GridViewResults.DataBind()
        ' Tidy
        CDataAccess = Nothing
        ' Apply Styling
        ' Set Visibility
        GridViewResults.Visible = GridViewResults.Rows.Count > 0
        LabelNoResults.Visible = Not GridViewResults.Visible
    End Sub
    Protected Sub GridViewResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewResults.SelectedIndexChanged
        Dim id As Integer = Convert.ToInt32(DirectCast(GridViewResults.SelectedRow.FindControl("hdnReference"), HiddenField).Value)
        Dim buyerid As Integer = Convert.ToInt32(DirectCast(GridViewResults.SelectedRow.FindControl("hdnBuyerId"), HiddenField).Value)
        Session("ClientTourID") = id
        Session("AdminCreateTourBuyerID") = buyerid
        ' RaiseEvent TourSelected()
        Response.Redirect("Reports.aspx")
    End Sub
    Protected Sub GridViewResults_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        'e.Row.Cells(4).Visible = False
    End Sub
End Class
