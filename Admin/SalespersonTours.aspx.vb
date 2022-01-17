Imports Microsoft.VisualBasic
Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Public Class SalespersonTours
    Inherits System.Web.UI.Page

    Dim dt As New DataTable()
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Session Variables
        If Session("AdminDisplayingMessage") Is Nothing Then
            Session("AdminDisplayingMessage") = False
        End If
        If Session("AdminPropertyEdit") Is Nothing Then
            Session("AdminPropertyEdit") = False
        End If

        ' Load Header Image
        ImageHeader.ImageUrl = "http://www.inlandandalucia.com/Images/Admin/header.jpg"

        ' Load the Button Images
        ImageButtonBack.ImageUrl = GetBackImagePath()
        ImageButtonForward.ImageUrl = GetForwardImagePath()
        ImageButtonSignOut.ImageUrl = GetSignOutImagePath()

        '' Add Postback Trigger for Images
        'Dim sm As ScriptManager = ScriptManager.GetCurrent(Page)
        'sm.RegisterPostBackControl(AdminNavigation)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' So Postbacks for Image and Document Uploading work First Time
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        ' If we are not in Agent Mode
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If

        If Not Page.IsPostBack Then

            BindUsers()
            ' If Session Value for Admin Menu Items is NULL
            If Session("AdminLoggedIn") = Nothing Then

                ' Assign Value
                Session("AdminLoggedIn") = False

            End If

            ' Initialize the sorting expression. 
            ViewState("SortExpressionCP") = "tour_datetime ASC"
            ViewState("SortExpressionLP") = "tour_datetime ASC"

        End If

    End Sub
    Public Function GetBackImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "back-ES.gif"

            Case 3
                ' French
                szRetVal &= "back-FR.gif"

            Case 4
                ' German
                szRetVal &= "back-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "back-NL.gif"

            Case Else
                ' English
                szRetVal &= "back.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function
    Public Function GetForwardImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "forward-ES.png"

            Case 3
                ' French
                szRetVal &= "forward-FR.png"

            Case 4
                ' German
                szRetVal &= "forward-DE.png"

            Case 5
                ' Dutch
                szRetVal &= "forward-NL.png"

            Case Else
                ' English
                szRetVal &= "forward.png"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function
    Private Function GetSignOutImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities
        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "sign-out-ES.gif"

            Case 3
                ' French
                szRetVal &= "sign-out-FR.gif"

            Case 4
                ' German
                szRetVal &= "sign-out-DE.gif"

            Case Else
                ' English
                szRetVal &= "sign-out.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function
    Public Sub BindUsers()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Select").Tables(0)
        If dt.Rows.Count > 0 Then
            drpUsers.DataSource = dt
            drpUsers.DataTextField = "Contact_Name"
            drpUsers.DataValueField = "Contact_Id"
            drpUsers.DataBind()
            drpUsers.Items.Insert(0, New ListItem("All", ""))
        End If
    End Sub
    Protected Sub btnListByClient_Click(sender As Object, e As EventArgs)
        trGridtitle.Visible = True
        lblGridTitle.Text = "Client List"
        grdClientList.Visible = True
        grdPropertyList.Visible = False
        BindList_ByClients()
    End Sub
    Public Sub BindList_ByClients()
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        If Not String.IsNullOrEmpty(drpUsers.SelectedValue) Then
            sql(0) = New SqlParameter("@tour_with_id", Convert.ToInt32(drpUsers.SelectedValue))
        Else
            sql(0) = New SqlParameter("@tour_with_id", 0)
        End If

        If txtDateFrom.Text = "" Then
            sql(1) = New SqlParameter("@DateFrom", Convert.ToDateTime("01-01-1900"))
        Else
            sql(1) = New SqlParameter("@DateFrom", txtDateFrom.Text)
        End If

        If txtDateTo.Text = "" Then
            sql(2) = New SqlParameter("@DateTo", "01-01-3015")
        Else
            sql(2) = New SqlParameter("@DateTo", txtDateTo.Text)
        End If

        dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_ClientTour_Select_By_ContactId", sql).Tables(0)

        If dt.Rows.Count > 0 Then
            ' Get the DataView from Person DataTable. 
            Dim dvclientproperties As DataView = dt.DefaultView


            ' Set the sort column and sort order. 
            dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()

            grdClientList.DataSource = dvclientproperties
            grdClientList.DataBind()
        End If
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "changeDateControl();", True)
    End Sub
    Public Sub BindList_ByProperties()
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        If Not String.IsNullOrEmpty(drpUsers.SelectedValue) Then
            sql(0) = New SqlParameter("@tour_with_id", Convert.ToInt32(drpUsers.SelectedValue))
        Else
            sql(0) = New SqlParameter("@tour_with_id", 0)
        End If

        If txtDateFrom.Text = "" Then
            sql(1) = New SqlParameter("@DateFrom", Convert.ToDateTime("01-01-1900"))
        Else
            sql(1) = New SqlParameter("@DateFrom", txtDateFrom.Text)
        End If

        If txtDateTo.Text = "" Then
            sql(2) = New SqlParameter("@DateTo", "01-01-3015")
        Else
            sql(2) = New SqlParameter("@DateTo", txtDateTo.Text)
        End If

        dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_ClientTour_Select_By_PropertyId_02", sql).Tables(0)

        If dt.Rows.Count > 0 Then

            ' Get the DataView from Person DataTable. 
            Dim dvlistproperties As DataView = dt.DefaultView


            ' Set the sort column and sort order. 
            dvlistproperties.Sort = ViewState("SortExpressionLP").ToString()

            grdPropertyList.DataSource = dvlistproperties

            grdPropertyList.DataBind()
        End If
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "changeDateControl();", True)
    End Sub
    Protected Sub grdClientList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdClientList.PageIndex = e.NewPageIndex
        BindList_ByClients()
    End Sub
    Protected Sub grdPropertyList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdPropertyList.PageIndex = e.NewPageIndex
        BindList_ByProperties()
    End Sub
    Protected Sub btnListByProperty_Click(sender As Object, e As EventArgs)
        trGridtitle.Visible = True
        lblGridTitle.Text = "Property List"
        grdClientList.Visible = False
        grdPropertyList.Visible = True
        BindList_ByProperties()
    End Sub
    Protected Sub ImageButtonSignOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSignOut.Click

        ' Clear Session Variables
        Session.Clear()

        ' Return to Hoempage
        Response.Redirect("/")

    End Sub
    Protected Sub grdClientList_Sorting(sender As Object, e As GridViewSortEventArgs)

        Dim strSortExpression As String() = ViewState("SortExpressionCP").ToString().Split(" "c)


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
        BindList_ByClients()

    End Sub
    Protected Sub grdPropertyList_Sorting(sender As Object, e As GridViewSortEventArgs)
        
        Dim strSortExpression As String() = ViewState("SortExpressionLP").ToString().Split(" "c)


        ' If the sorting column is the same as the previous one,  
        ' then change the sort order. 
        If strSortExpression(0) = e.SortExpression Then
            If strSortExpression(1) = "ASC" Then
                ViewState("SortExpressionLP") = Convert.ToString(e.SortExpression) & " " & "DESC"
            Else
                ViewState("SortExpressionLP") = Convert.ToString(e.SortExpression) & " " & "ASC"
            End If
        Else
            ' If sorting column is another column,   
            ' then specify the sort order to "Ascending". 
            ViewState("SortExpressionLP") = Convert.ToString(e.SortExpression) & " " & "ASC"
        End If


        ' Rebind the GridView control to show sorted data. 
        BindList_ByProperties()

    End Sub
End Class
