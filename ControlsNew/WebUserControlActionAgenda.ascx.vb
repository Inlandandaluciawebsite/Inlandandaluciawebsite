Imports Microsoft.VisualBasic
Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Partial Class Controls_WebUserControlActionAgenda
    Inherits System.Web.UI.UserControl
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
        'ImageHeader.ImageUrl = "http://www.inlandandalucia.com/Images/Admin/header.jpg"

        '' Load the Button Images
        'ImageButtonBack.ImageUrl = GetBackImagePath()
        'ImageButtonForward.ImageUrl = GetForwardImagePath()
        'ImageButtonSignOut.ImageUrl = GetSignOutImagePath()

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
        If Not Session("ContactID") Is Nothing Then
            If ViewState("SampleText") Is Nothing Then
                ViewState("SampleText") = Session("ContactID")

                ViewState("SortExpressionCP") = "Action_Date ASC"
                'Here i am binding all existing client history by buyer
                BindAgents()
                BindBuyerStatus()
                BindbuyerAction()
                If Request.QueryString.HasKeys() Then
                    ID = Convert.ToInt32(Request.QueryString(0))
                    Dim sql As SqlParameter() = New SqlParameter(0) {}
                    sql(0) = New SqlParameter("@History_ID", ID)
                    Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_SELECT_BY_HistoryID", sql).Tables(0)
                    If dt.Rows.Count > 0 Then

                        btnClientHistoryUpdate.Style.Add("display", "block")
                        btnClientHistorySave.Style.Add("display", "none")


                        drpBuyerStatus.Items(drpBuyerStatus.Items.IndexOf(drpBuyerStatus.Items.FindByValue(dt.Rows(0)("Buyer_Status").ToString()))).Selected = True
                        drpAgents.Items(drpAgents.Items.IndexOf(drpAgents.Items.FindByValue(dt.Rows(0)("Modified_By").ToString()))).Selected = True
                        txtActionDate.Text = dt.Rows(0)("Action_Date").ToString()
                        txtDescription.Text = dt.Rows(0)("History_Text").ToString()
                        hdnBuyerId.Value = dt.Rows(0)("Buyer_Id").ToString()
                        'If (dt.Rows(0)("Archived").ToString() = True) Then
                        '    'chkIsArchived.Checked = True
                        'Else
                        '    'chkIsArchived.Checked = False

                        'End If
                    End If
                    Page.RegisterStartupScript("script", "<script language='javascript'>document.getElementById('txtDescription').focus();</script>")
                End If

                ' If Session Value for Admin Menu Items is NULL
                If Session("AdminLoggedIn") = Nothing Then

                    ' Assign Value
                    Session("AdminLoggedIn") = False

                End If
            End If
            If Not ViewState("SampleText") = Session("ContactID") Then

                ViewState("SortExpressionCP") = "Action_Date ASC"
                'Here i am binding all existing client history by buyer
                BindAgents()
                BindBuyerStatus()
                BindbuyerAction()
                If Request.QueryString.HasKeys() Then
                    ID = Convert.ToInt32(Request.QueryString(0))
                    Dim sql As SqlParameter() = New SqlParameter(0) {}
                    sql(0) = New SqlParameter("@History_ID", ID)
                    Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_SELECT_BY_HistoryID", sql).Tables(0)
                    If dt.Rows.Count > 0 Then

                        btnClientHistoryUpdate.Style.Add("display", "block")
                        btnClientHistorySave.Style.Add("display", "none")


                        drpBuyerStatus.Items(drpBuyerStatus.Items.IndexOf(drpBuyerStatus.Items.FindByValue(dt.Rows(0)("Buyer_Status").ToString()))).Selected = True
                        drpAgents.Items(drpAgents.Items.IndexOf(drpAgents.Items.FindByValue(dt.Rows(0)("Modified_By").ToString()))).Selected = True
                        txtActionDate.Text = dt.Rows(0)("Action_Date").ToString()
                        txtDescription.Text = dt.Rows(0)("History_Text").ToString()
                        hdnBuyerId.Value = dt.Rows(0)("Buyer_Id").ToString()
                        'If (dt.Rows(0)("Archived").ToString() = True) Then
                        '    'chkIsArchived.Checked = True
                        'Else
                        '    'chkIsArchived.Checked = False

                        'End If
                    End If
                    Page.RegisterStartupScript("script", "<script language='javascript'>document.getElementById('txtDescription').focus();</script>")
                End If

                ' If Session Value for Admin Menu Items is NULL
                If Session("AdminLoggedIn") = Nothing Then

                    ' Assign Value
                    Session("AdminLoggedIn") = False

                End If
                ViewState("SampleText") = Session("ContactID")

            End If

        End If
        If Not Page.IsPostBack Then


            ViewState("SortExpressionCP") = "Action_Date ASC"
            'Here i am binding all existing client history by buyer
            BindAgents()
            BindBuyerStatus()
            BindbuyerAction()
            If Request.QueryString.HasKeys() Then
                ID = Convert.ToInt32(Request.QueryString(0))
                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@History_ID", ID)
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_SELECT_BY_HistoryID", sql).Tables(0)
                If dt.Rows.Count > 0 Then

                    btnClientHistoryUpdate.Style.Add("display", "block")
                    btnClientHistorySave.Style.Add("display", "none")


                    drpBuyerStatus.Items(drpBuyerStatus.Items.IndexOf(drpBuyerStatus.Items.FindByValue(dt.Rows(0)("Buyer_Status").ToString()))).Selected = True
                    drpAgents.Items(drpAgents.Items.IndexOf(drpAgents.Items.FindByValue(dt.Rows(0)("Modified_By").ToString()))).Selected = True
                    txtActionDate.Text = dt.Rows(0)("Action_Date").ToString()
                    txtDescription.Text = dt.Rows(0)("History_Text").ToString()
                    hdnBuyerId.Value = dt.Rows(0)("Buyer_Id").ToString()
                    'If (dt.Rows(0)("Archived").ToString() = True) Then
                    '    'chkIsArchived.Checked = True
                    'Else
                    '    'chkIsArchived.Checked = False

                    'End If
                End If
                Page.RegisterStartupScript("script", "<script language='javascript'>document.getElementById('txtDescription').focus();</script>")
            End If

            ' If Session Value for Admin Menu Items is NULL
            If Session("AdminLoggedIn") = Nothing Then

                ' Assign Value
                Session("AdminLoggedIn") = False

            End If

            ' Initialize the sorting expression. 

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
    Public Sub BindAgents()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Contact_SelectAll").Tables(0)
        If dt.Rows.Count > 0 Then
            drpAgents.DataSource = dt
            drpAgents.DataTextField = "Contact_Name"
            drpAgents.DataValueField = "Contact_ID"
            drpAgents.DataBind()
            If Not Request.QueryString.HasKeys() Then
                drpAgents.SelectedValue = Session("ContactID")
            End If
        End If
    End Sub
    Public Sub BindbuyerAction()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_FUTURE_SELECT_All").Tables(0)
        If dt.Rows.Count > 0 Then
            ' get the dataview from person datatable. 
            Dim dvclientproperties As DataView = dt.DefaultView

            ' set the sort column and sort order. 
            dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()
            grdActionAgenda.DataSource = dvclientproperties
            grdActionAgenda.DataBind()
        End If
    End Sub
    Protected Sub grdActionAgenda_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdActionAgenda.PageIndex = e.NewPageIndex
        BindbuyerAction()
    End Sub
    Protected Sub grdActionAgenda_Sorting(sender As Object, e As GridViewSortEventArgs)
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
        BindbuyerAction()
    End Sub
    Public Sub BindBuyerStatus()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_STATUS_SELECT").Tables(0)
        If dt.Rows.Count > 0 Then
            drpBuyerStatus.DataSource = dt
            drpBuyerStatus.DataTextField = "Name"
            drpBuyerStatus.DataValueField = "Buyer_Status_Id"
            drpBuyerStatus.DataBind()
        End If
    End Sub
    Protected Sub grdActionAgenda_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "EditBuyer" Then
            Response.Redirect("BackOffice.aspx?History_ID=" + e.CommandArgument.ToString())
        End If
    End Sub
    Protected Sub btnClientHistoryUpdate_Click(sender As Object, e As EventArgs)
        ID = Convert.ToInt32(Request.QueryString(0))
        Dim sql As SqlParameter() = New SqlParameter(7) {}
        sql(0) = New SqlParameter("@Buyer_Status", Convert.ToInt32(drpBuyerStatus.SelectedValue))
        sql(1) = New SqlParameter("@Buyer_ID", Convert.ToInt32(hdnBuyerId.Value))
        If txtActionDate.Text = "" Then
            sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
        Else
            sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
        End If
        sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
        sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
        If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
            sql(5) = New SqlParameter("@Archived", 1)
        Else
            sql(5) = New SqlParameter("@Archived", 0)
        End If

        sql(6) = New SqlParameter("@History_ID", ID)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_UPDATE", sql).ToString()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "changeDateControl(); alert('Record has been updated successfully !');", True)
        BindbuyerAction()
        Response.Redirect("ActionAgenda.aspx")
    End Sub
    Protected Sub btnClientHistorySave_Click(sender As Object, e As EventArgs)

        Dim sql As SqlParameter() = New SqlParameter(6) {}
        sql(0) = New SqlParameter("@Buyer_Status", Convert.ToInt32(drpBuyerStatus.SelectedValue))
        sql(1) = New SqlParameter("@Buyer_ID", Convert.ToInt32(hdnBuyerId.Value))
        If txtActionDate.Text = "" Then
            sql(2) = New SqlParameter("@Action_Date", DateTime.Now.ToString())
        Else
            sql(2) = New SqlParameter("@Action_Date", Convert.ToDateTime(txtActionDate.Text))
        End If
        sql(3) = New SqlParameter("@History_Text", txtDescription.Text)
        sql(4) = New SqlParameter("@Modified_By", drpAgents.SelectedValue)
        If Convert.ToDateTime(txtActionDate.Text) < Convert.ToDateTime(DateTime.Now.ToString()) Then
            sql(5) = New SqlParameter("@Archived", 1)
        Else
            sql(5) = New SqlParameter("@Archived", 0)
        End If
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_INSERT", sql).ToString()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "changeDateControl(); alert('Record has been Saved successfully !');", True)
        BindbuyerAction()
        txtActionDate.Text = ""
        txtDescription.Text = ""
        drpBuyerStatus.SelectedIndex = 0
        'chkIsArchived.Checked = False
        Response.Redirect("ActionAgenda.aspx")

    End Sub
End Class
