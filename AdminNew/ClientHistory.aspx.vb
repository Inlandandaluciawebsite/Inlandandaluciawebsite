Imports Microsoft.VisualBasic
Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_ClientHistory
    Inherits System.Web.UI.Page

    Dim dt As New DataTable()
    Dim CBuyer As ClassBuyer
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
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
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        ' So Postbacks for Image and Document Uploading work First Time
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        ' If we are not in Agent Mode
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        CBuyer = DirectCast(Session("AdminBuyerSelected"), ClassBuyer)
        If Not Page.IsPostBack Then
            ViewState("SortExpressionCP") = "Create_Date DESC"
            'Here i am binding all existing client history by buyer 
            BindHistoryByBuyer()
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
    Public Sub BindHistoryByBuyer()
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Buyer_ID", CBuyer.ID)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_SELECT_BY_BuyerID", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            ' Get the DataView from Person DataTable. 
            Dim dvclientproperties As DataView = dt.DefaultView
            '' Set the sort column and sort order. 
            dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()
            grdBuyerHistory.DataSource = dvclientproperties
            grdBuyerHistory.DataBind()
        End If
    End Sub
    Protected Sub grdBuyerHistory_Sorting(sender As Object, e As GridViewSortEventArgs)
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
        BindHistoryByBuyer()
    End Sub
    Protected Sub grdBuyerHistory_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdBuyerHistory.PageIndex = e.NewPageIndex
        BindHistoryByBuyer()
    End Sub
    'Protected Sub grdBuyerHistory_RowCommand(sender As Object, e As GridViewCommandEventArgs)
    '    If e.CommandName = "moreinfo" Then
    '        Dim History_ID As Integer = Convert.ToInt32(e.CommandArgument)
    '        Dim sql As SqlParameter() = New SqlParameter(1) {}
    '        sql(0) = New SqlParameter("@Buyer_ID", CBuyer.ID)
    '        sql(1) = New SqlParameter("@History_ID", History_ID)
    '        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_SELECT_BY_History_ID", sql).Tables(0)
    '        If dt.Rows.Count > 0 Then


    '            lblActionDate.Text = String.Empty
    '            lblBuyerForename.Text = String.Empty
    '            lblBuyerSurname.Text = String.Empty
    '            lblCreateDate.Text = String.Empty
    '            lblHistoryText.Text = String.Empty
    '            lblType.Text = String.Empty
    '            lblCreatedBy.Text = String.Empty

    '            lblActionDate.Text = dt.Rows(0)("Action_Date").ToString()
    '            lblBuyerForename.Text = dt.Rows(0)("Buyer_Forename").ToString()
    '            lblBuyerSurname.Text = dt.Rows(0)("Buyer_Surname").ToString()
    '            lblCreateDate.Text = dt.Rows(0)("Create_Date").ToString()
    '            lblHistoryText.Text = dt.Rows(0)("History_Text").ToString()
    '            lblType.Text = dt.Rows(0)("Type").ToString()
    '            lblCreatedBy.Text = dt.Rows(0)("CreatedBy").ToString()

    '            Dim sb As New System.Text.StringBuilder()

    '            sb.Append("<script type='text/javascript'>")

    '            sb.Append("$(function () { $('#dialog').dialog({modal: true,autoOpen: false,height: 300,width: 500});$('#dialog').dialog('open'); });")

    '            sb.Append("</script>")

    '            ' ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "EditModalScript", sb.ToString(), False)
    '            ClientScript.RegisterStartupScript(Me.GetType(), "EditModalScript", sb.ToString())
    '        End If

    '    End If
    'End Sub
    Protected Sub grdBuyerHistory_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "moreinfo" Then
            Dim History_ID As Integer = Convert.ToInt32(e.CommandArgument)
            Dim sql As SqlParameter() = New SqlParameter(0) {}
            sql(0) = New SqlParameter("@History_ID", History_ID)
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_SELECT_BY_History_Id", sql).Tables(0)
            If dt.Rows.Count > 0 Then

                lblActionDate.Text = dt.Rows(0)("Action_Date").ToString()
                lblBuyerForename.Text = dt.Rows(0)("Buyer_Forename").ToString()
                lblBuyerSurname.Text = dt.Rows(0)("Buyer_Surname").ToString()
                lblCreateDate.Text = dt.Rows(0)("Create_Date").ToString()
                lblHistoryText.Text = dt.Rows(0)("History_Text").ToString()
                lblType.Text = dt.Rows(0)("Type").ToString()
                lblCreatedBy.Text = dt.Rows(0)("CreatedBy").ToString()

                Dim sb As New System.Text.StringBuilder()

                sb.Append("<script type='text/javascript'>")

                sb.Append("$(function () { $('#dialog').dialog({modal: true,autoOpen: false,height: 300,width: 500});$('#dialog').dialog('open'); });")

                sb.Append("</script>")

                ' ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "EditModalScript", sb.ToString(), False)
                ClientScript.RegisterStartupScript(Me.GetType(), "EditModalScript", sb.ToString())
            End If

        End If
    End Sub
End Class
