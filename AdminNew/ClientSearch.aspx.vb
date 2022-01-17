Imports System.Data
Imports System.Data.SqlClient
Imports System.String
Imports ClassHistory
Imports HashSoftwares
Imports Saplin
Imports System.IO
Imports System.Net.Mail

Partial Class ClientSearch
    Inherits System.Web.UI.Page

    Public Event BuyerSelected()
    Dim redval As Integer = 0
    Dim pg As String = String.Empty
    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        lblExportMailingMessage.Visible = False
        ' Perform Search
        bindgrid()
    End Sub
    Private Sub bindusers()
        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)
        Dim dt As DataTable
        If Convert.ToInt32(Session("AdminUser")) = 0 Then
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Show_Users_By_ContactPartnerId_With_IsMainContact", sql).Tables(0)
        Else
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Show_Users_Without_Archived").Tables(0)
        End If

        If dt.Rows.Count > 0 Then
            drpUser.DataSource = dt
            drpUser.DataTextField = "Contact_Name"
            drpUser.DataValueField = "Contact_Id"

            drpUser.DataBind()
            Dim licategory1 As New ListItem("--Salesperson--", "")
            drpUser.Items.Insert(0, licategory1)
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session.Remove("ClientTourID")
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        ' Set Focus
        TextBoxFirstName.Focus()
        If Not IsPostBack Then
            binduserstatus()
            bindusers()
            If Not Request.QueryString("PageIndex") Is Nothing Then
                TextBoxFirstName.Text = Request.QueryString("Firstname").ToString()
                txtlastname.Text = Request.QueryString("lastname").ToString()
                CheckBoxIncludeArchived.Checked = Request.QueryString("Included").ToString()
                txtBuyeremail.Text = Request.QueryString("Email").ToString()
                txtdatecreated.Text = Request.QueryString("date").ToString()
                drpUser.SelectedValue = Request.QueryString("salesperson").ToString()
                DropDownListSource.SelectedValue = Request.QueryString("source").ToString()
                DropDownListStatus.SelectedValue = Request.QueryString("status").ToString()
            End If
            bindgrid()
        End If

    End Sub

    Private Sub binduserstatus()
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities

        ' Source
        CUtilities.PopulateDropDownList(DropDownListSource, CDataAccess.BuyerSource)
        '     DropDownListSource.Items.Insert(0, "--- Source ---")
        Dim licategory1 As New ListItem("--Source--", "")
        DropDownListSource.Items.Insert(0, licategory1)
        ' Status
        CUtilities.PopulateDropDownList(DropDownListStatus, CDataAccess.BuyerStatus)
        ' DropDownListStatus.Items.Insert(0, "--- Status ---")
        Dim licategory2 As New ListItem("--Status--", "")
        DropDownListStatus.Items.Insert(0, licategory2)
        'Criterias
        'CUtilities.PopulateDropDownList(DropDownListCriterias, CDataAccess.BuyerCriterias)
        DropDownListCriterias.DataSource = CDataAccess.OnlyBuyerCriterias
        DropDownListCriterias.DataTextField = "text"
        DropDownListCriterias.DataValueField = "Criteria_Id"
        DropDownListCriterias.DataBind()
        ' DropDownListStatus.Items.Insert(0, "--- Status ---")
        'Dim liCriterias As New ListItem("--Criteria--", "")
        'DropDownListCriterias.Items.Insert(0, liCriterias)

    End Sub

    Private Sub ApplyStyling()

        ' If we have a Header Row
        'If Not GridViewResultsClient.HeaderRow Is Nothing Then

        '    ' Hide the ID & Archived Column Headings
        '    GridViewResultsClient.HeaderRow.Cells(1).Visible = False
        '    GridViewResultsClient.HeaderRow.Cells(2).Visible = False

        '    ' For each Row
        '    For Each gvr As GridViewRow In GridViewResultsClient.Rows

        '        ' Hide ID and Archived Cells
        '        gvr.Cells(1).Visible = False
        '        gvr.Cells(2).Visible = False

        '        ' If this Client is Archived
        '        If DirectCast(gvr.Cells(2).Controls(0), CheckBox).Checked Then

        '            ' Apply Styling
        '            gvr.BackColor = Drawing.Color.Gray

        '        End If

        '    Next

        'End If

        ' Set Visibility
        TableRowNoResults.Visible = GridViewResultsClient.Rows.Count < 1
        ' TableRowResults.Visible = Not TableRowNoResults.Visible

    End Sub
    Public Sub Reload()

        ' Reload Values
        LoadControlValues(Me)

        ' Apply Styling
        ApplyStyling()

    End Sub
    Private Sub bindgrid()
        Dim CDataAccess As New ClassDataAccess
        If Not redval = 1 Then
            If Not Request.QueryString("PageIndex") Is Nothing Then
                GridViewResultsClient.PageIndex = Convert.ToInt32(Request.QueryString("PageIndex")) - 1
            End If
        End If
        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If

        Dim sql As SqlParameter() = New SqlParameter(9) {}
        sql(0) = New SqlParameter("@szFirstName", TextBoxFirstName.Text.Trim)
        sql(1) = New SqlParameter("@szLastName", txtlastname.Text.Trim)
        sql(2) = New SqlParameter("@Email", txtBuyeremail.Text.Trim)
        sql(3) = New SqlParameter("@bIncludeArchived", Convert.ToBoolean(CheckBoxIncludeArchived.Checked))
        sql(4) = New SqlParameter("@DateCeated", txtdatecreated.Text)
        sql(5) = New SqlParameter("@Salesperson", drpUser.SelectedValue)
        sql(6) = New SqlParameter("@Source", DropDownListSource.SelectedValue)
        sql(7) = New SqlParameter("@Status", DropDownListStatus.SelectedValue)
        sql(8) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)

        Dim Criteria_Id As String = ""

        If drpListType.SelectedValue = "OR" Then
            Criteria_Id = "select Buyer_Id from Buyer_Criterias where Criterias_ID in(0"
        Else
            Criteria_Id = ""
        End If

        Dim howmanyselected As Int32 = 0
        For a = 0 To DropDownListCriterias.Items.Count - 1
            If DropDownListCriterias.Items(a).Selected = True Then
                howmanyselected = howmanyselected + 1
            End If
        Next
        Dim howmanyselected02 As Int32 = 0
        For a = 0 To DropDownListCriterias.Items.Count - 1
            If DropDownListCriterias.Items(a).Selected = True Then
                howmanyselected02 = howmanyselected02 + 1
                If drpListType.SelectedValue = "OR" Then
                    Criteria_Id = Criteria_Id & "," & DropDownListCriterias.Items(a).Value
                Else
                    Criteria_Id = Criteria_Id & " select Buyer_Id from Buyer_Criterias where Criterias_ID=" & DropDownListCriterias.Items(a).Value
                    If howmanyselected02 <> howmanyselected Then
                        Criteria_Id = Criteria_Id & " intersect"
                    End If

                End If
            End If
        Next

        If drpListType.SelectedValue = "OR" Then
            Criteria_Id = Criteria_Id & ")"
        Else
            If Criteria_Id = "" Then
                Criteria_Id = "0"
            End If
        End If
        lblcriteriatest.Text = Criteria_Id
        If howmanyselected = 0 Then
            Criteria_Id = "0"
        End If

        'lblcriteriatest.Text = Criteria_Id
        sql(9) = New SqlParameter("@Criteria_Id", Criteria_Id)

        Dim dt As DataTable
        If Convert.ToInt32(Session("AdminUser")) = 0 Then
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Client_Search_By_Partner_Id", sql).Tables(0)
        Else
            dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Client_Search_Without_Partner_Id", sql).Tables(0)
        End If

        Dim dvclientproperties As DataView = dt.DefaultView

        ' set the sort column and sort order. 
        If ViewState("SortExpressionCP") Is Nothing Then
            ViewState("SortExpressionCP") = "Buyer_Date_Created Desc"
        End If
        dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()
        GridViewResultsClient.DataSource = dvclientproperties
        GridViewResultsClient.DataBind()
        If dt.Rows.Count > 0 Then
            TableRowNoResults.Visible = False
        Else
            TableRowNoResults.Visible = True
        End If
        CDataAccess = Nothing
        ' Apply Styling
        ApplyStyling()
        lbltotlacount.Text = dt.Rows.Count.ToString()
    End Sub
    Protected Sub GridViewResultsClient_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridViewResultsClient.PageIndex = e.NewPageIndex
        redval = 1
        bindgrid()
    End Sub
    Protected Sub GridViewResultsClient_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' determine the value of the UnitsInStock field
            Dim lsDataKeyValue As String = GridViewResultsClient.DataKeys(e.Row.RowIndex).Values(0).ToString()
            ' Dim CategoryID As Integer = Convert.ToInt32(DataBinder.Eval(e.Row., "contact_id"))
            If lsDataKeyValue = Request.QueryString("Id") Then
                ' color the background of the row yellow
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9CF06")
                ' ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "EditModalScript", script.ToString(), False)
            End If
        End If
    End Sub
    Protected Sub GridViewResultsClient_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editadmin" Then
            pg = Convert.ToString(GridViewResultsClient.PageIndex) + 1
            Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))
            ' Load this Property's Details
            Dim CDataAccess As New ClassDataAccess
            CBuyer.Load(Convert.ToInt32(e.CommandArgument))
            CDataAccess = Nothing
            ' Assign to Session Variable
            Session("AdminBuyerSelected") = CBuyer
            ' Raise Event
            '  RaiseEvent BuyerSelected()
            Response.Redirect("Client.aspx?ID=" + e.CommandArgument + "&PageIndex=" + pg + "&Firstname=" + TextBoxFirstName.Text + "&lastname=" + txtlastname.Text + "&Included=" + CheckBoxIncludeArchived.Checked.ToString() + "&Email=" + txtBuyeremail.Text.ToString() + "&date=" + txtdatecreated.Text.ToString() + "&salesperson=" + drpUser.SelectedValue.ToString() + "&source=" + DropDownListSource.SelectedValue.ToString() + "&status=" + DropDownListStatus.SelectedValue.ToString())
        End If
    End Sub
    Protected Sub GridViewResultsClient_Sorting(sender As Object, e As GridViewSortEventArgs)
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
    Protected Sub drpUser_SelectedIndexChanged(sender As Object, e As EventArgs)
        lblExportMailingMessage.Visible = False
        If drpUser.SelectedIndex <> 0 Then
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            DropDownListCriterias.DataSource = CDataAccess.OnlyBuyerCriterias_BySalesPerson(Convert.ToInt32(drpUser.SelectedValue))
            DropDownListCriterias.DataTextField = "text"
            DropDownListCriterias.DataValueField = "Criteria_Id"
            DropDownListCriterias.DataBind()
        Else
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            DropDownListCriterias.DataSource = CDataAccess.OnlyBuyerCriterias
            DropDownListCriterias.DataTextField = "text"
            DropDownListCriterias.DataValueField = "Criteria_Id"
            DropDownListCriterias.DataBind()
        End If
    End Sub
    Protected Sub btnExportCsv_Click(sender As Object, e As EventArgs)
        Dim filename As String = "mailingfile-"
        filename = filename & DateTime.Now.Day.ToString() & "-" & DateTime.Now.Month.ToString() & "-" & DateTime.Now.Year.ToString() & "-" & Session("ContactName").ToString() & ".csv"

        Dim CDataAccess As New ClassDataAccess
        If Not redval = 1 Then
            If Not Request.QueryString("PageIndex") Is Nothing Then
                GridViewResultsClient.PageIndex = Convert.ToInt32(Request.QueryString("PageIndex")) - 1
            End If
        End If
        Dim Contact_Partner_Id As Int16
        If Convert.ToInt32(Session("ContactPartnerID")) <> 0 Then
            Contact_Partner_Id = Convert.ToInt32(Session("ContactPartnerID"))
        Else
            Contact_Partner_Id = Convert.ToInt32(Session("ContactID"))
        End If

        Dim sql As SqlParameter() = New SqlParameter(9) {}
        sql(0) = New SqlParameter("@szFirstName", TextBoxFirstName.Text.Trim)
        sql(1) = New SqlParameter("@szLastName", txtlastname.Text.Trim)
        sql(2) = New SqlParameter("@Email", txtBuyeremail.Text.Trim)
        sql(3) = New SqlParameter("@bIncludeArchived", Convert.ToBoolean(CheckBoxIncludeArchived.Checked))
        sql(4) = New SqlParameter("@DateCeated", txtdatecreated.Text)
        If drpUser.SelectedItem.Text = "--Salesperson--" Then
            If Convert.ToInt32(Session("AdminUser")) = 0 Then
                sql(5) = New SqlParameter("@Salesperson", Convert.ToInt32(Session("ContactID")))
            Else
                sql(5) = New SqlParameter("@Salesperson", drpUser.SelectedValue)
            End If
        Else
            sql(5) = New SqlParameter("@Salesperson", drpUser.SelectedValue)
        End If

        sql(6) = New SqlParameter("@Source", DropDownListSource.SelectedValue)
        sql(7) = New SqlParameter("@Status", DropDownListStatus.SelectedValue)
        sql(8) = New SqlParameter("@Contact_Partner_Id", Contact_Partner_Id)

        Dim Criteria_Id As String = ""

        If drpListType.SelectedValue = "OR" Then
            Criteria_Id = "select Buyer_Id from Buyer_Criterias where Criterias_ID in(0"
        Else
            Criteria_Id = ""
        End If

        Dim howmanyselected As Int32 = 0
        For a = 0 To DropDownListCriterias.Items.Count - 1
            If DropDownListCriterias.Items(a).Selected = True Then
                howmanyselected = howmanyselected + 1
            End If
        Next
        Dim howmanyselected02 As Int32 = 0
        For a = 0 To DropDownListCriterias.Items.Count - 1
            If DropDownListCriterias.Items(a).Selected = True Then
                howmanyselected02 = howmanyselected02 + 1
                If drpListType.SelectedValue = "OR" Then
                    Criteria_Id = Criteria_Id & "," & DropDownListCriterias.Items(a).Value
                Else
                    Criteria_Id = Criteria_Id & " select Buyer_Id from Buyer_Criterias where Criterias_ID=" & DropDownListCriterias.Items(a).Value
                    If howmanyselected02 <> howmanyselected Then
                        Criteria_Id = Criteria_Id & " intersect"
                    End If

                End If
            End If
        Next

        If drpListType.SelectedValue = "OR" Then
            Criteria_Id = Criteria_Id & ")"
        Else
            If Criteria_Id = "" Then
                Criteria_Id = "0"
            End If
        End If
        lblcriteriatest.Text = Criteria_Id
        If howmanyselected = 0 Then
            Criteria_Id = "0"
        End If

        'lblcriteriatest.Text = Criteria_Id
        sql(9) = New SqlParameter("@Criteria_Id", Criteria_Id)

        Dim dtExportToCsv As DataTable
        If Convert.ToInt32(Session("AdminUser")) = 0 Then
            dtExportToCsv = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Client_Search_By_Partner_Id", sql).Tables(0)
        Else
            dtExportToCsv = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Client_Search_Without_Partner_Id", sql).Tables(0)
        End If
        Dim dvclientproperties As DataView = dtExportToCsv.DefaultView

        ' set the sort column and sort order. 
        If ViewState("SortExpressionCP") Is Nothing Then
            ViewState("SortExpressionCP") = "Buyer_Date_Created Asc"
        End If
        dvclientproperties.Sort = ViewState("SortExpressionCP").ToString()
        GridViewResultsClient.DataSource = dvclientproperties
        GridViewResultsClient.DataBind()
        If dtExportToCsv.Rows.Count > 0 Then
            TableRowNoResults.Visible = False
        Else
            TableRowNoResults.Visible = True
        End If
        CDataAccess = Nothing
        ' Apply Styling
        ApplyStyling()
        dtExportToCsv.Columns.Remove("ID")
        dtExportToCsv.Columns.Remove("Name")
        dtExportToCsv.Columns.Remove("Archived")
        dtExportToCsv.Columns.Remove("Buyer_Date_Created")
        dtExportToCsv.Columns.Remove("Buyer_Salesperson_ID")

        'Build the CSV file data as a Comma separated string.
        Dim csv As String = String.Empty

        For Each column As DataColumn In dtExportToCsv.Columns
            'Add the Header row for CSV file.
            csv += column.ColumnName + ","c
        Next

        'Add new line.
        csv += vbCr & vbLf
        Try
            For Each row As DataRow In dtExportToCsv.Rows
                For Each column As DataColumn In dtExportToCsv.Columns
                    'Add the Data rows.
                    csv += row(column.ColumnName).ToString().Replace(",", ";") + ","c
                Next

                'Add new line.
                csv += vbCr & vbLf
            Next
        Catch ex As Exception

        End Try
        Dim filepath As String = Server.MapPath("../App_Data/ExportMailingList/" & filename)
        If Not System.IO.File.Exists(filepath) Then
            System.IO.File.Create(filepath).Dispose()
        End If
        'Dim filepath As String=Server.MapPath("AdminNew\ExportMailingList")
        File.WriteAllText(filepath, csv.ToString)

        'Download the CSV file.
        'Response.Clear()
        'Response.Buffer = True
        'Response.AddHeader("content-disposition", "attachment;filename=" & filename)
        'Response.Charset = ""
        'Response.ContentType = "application/text"
        'Response.Output.Write(csv)
        'Response.Flush()
        'Response.End()

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")

        mMailMessage.To.Add(New MailAddress("info@inlandandalucia.com"))
        mMailMessage.To.Add(New MailAddress("jerome@inlandandalucia.com"))
        'mMailMessage.To.Add(New MailAddress("cecilio@inlandandalucia.com"))
        'mMailMessage.To.Add(New MailAddress("sourabhodesk@gmail.com"))

        ' Set the subject of the mail message
        mMailMessage.Subject = "Requested Mailing List from IA BackOffice"

        ' Set the body of the mail message
        mMailMessage.Body = "Attached is the the csv file with client contacts user " & Session("ContactName").ToString() & "  have just requested." & "<br/>"
        mMailMessage.Body = mMailMessage.Body & "Here are search filters been selected : <br/> "
        If TextBoxFirstName.Text <> "" Then
            mMailMessage.Body = mMailMessage.Body & "First Name : " & TextBoxFirstName.Text & "<br/>"
        End If
        If txtlastname.Text <> "" Then
            mMailMessage.Body = mMailMessage.Body & "Last Name : " & txtlastname.Text & "<br/>"
        End If
        If txtBuyeremail.Text <> "" Then
            mMailMessage.Body = mMailMessage.Body & "Email : " & txtBuyeremail.Text & "<br/>"
        End If
        If txtdatecreated.Text <> "" Then
            mMailMessage.Body = mMailMessage.Body & "Date Created : " & txtdatecreated.Text & "<br/>"
        End If
        If drpUser.SelectedItem.Text <> "--Salesperson--" Then
            mMailMessage.Body = mMailMessage.Body & "SalesPerson : " & drpUser.SelectedItem.Text & "<br/>"
        End If
        If DropDownListSource.SelectedItem.Text <> "--Source--" Then
            mMailMessage.Body = mMailMessage.Body & "Source : " & DropDownListSource.SelectedItem.Text & "<br/>"
        End If
        If DropDownListStatus.SelectedItem.Text <> "--Status--" Then
            mMailMessage.Body = mMailMessage.Body & "Status : " & DropDownListStatus.SelectedItem.Text & "<br/>"
        End If

        mMailMessage.Body = mMailMessage.Body & "Only Archived : " & CheckBoxIncludeArchived.Checked.ToString() & "<br/>"

        mMailMessage.Body = mMailMessage.Body & "Criterias Selection : " & "" & "<br/>"

        For a = 0 To DropDownListCriterias.Items.Count - 1
            If DropDownListCriterias.Items(a).Selected = True Then
                mMailMessage.Body = mMailMessage.Body & DropDownListCriterias.Items(a).Text & " " & drpListType.SelectedItem.Text & "<br/> "
            End If
        Next


        ' Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = True

        ' Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal



        Dim att As New Attachment(filepath, "text/csv")
        att.Name = filename
        mMailMessage.Attachments.Add(att)

        ' Instantiate a new instance of SmtpClient
        Dim mSmtpClient As New SmtpClient()

        ' Send the Mail Message
        mSmtpClient.Send(mMailMessage)

        ' Tidy
        mSmtpClient.Dispose()
        ' Tidy
        mMailMessage.Dispose()

        'Sending another email only to user who logged in and requesting this mailing list

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage02 As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage02.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("InlandAndaluciaEmailAddress"), "Inland Andalucia")
        Dim strcontactemail As String = "select contact_email from contact where contact_id =" & Convert.ToInt32(Session("ContactID")) & ""
        Dim dtUserEmail As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, strcontactemail).Tables(0)
        Dim userEmail As String = ""
        If dtUserEmail.Rows.Count > 0 Then
            userEmail = dtUserEmail.Rows(0)("contact_email").ToString()
        End If

        mMailMessage02.To.Add(New MailAddress(userEmail))
        'mMailMessage02.To.Add(New MailAddress("sourabhodesk@gmail.com"))
        'mMailMessage02.To.Add(New MailAddress("jerome@inlandandalucia.com"))

        ' Set the subject of the mail message
        mMailMessage02.Subject = "Requested Mailing List from IA BackOffice"

        ' Set the body of the mail message
        mMailMessage02.Body = "You have requested a mailing list to do a mailing to some of your clients, please send to IT (Jerome and jOLYNE) a template to be sent to your clients so we can process the mailing.<br/>"
        mMailMessage02.Body = mMailMessage02.Body & "Here are search filters been selected : <br/> "
        If TextBoxFirstName.Text <> "" Then
            mMailMessage02.Body = mMailMessage02.Body & "First Name : " & TextBoxFirstName.Text & "<br/>"
        End If
        If txtlastname.Text <> "" Then
            mMailMessage02.Body = mMailMessage02.Body & "Last Name : " & txtlastname.Text & "<br/>"
        End If
        If txtBuyeremail.Text <> "" Then
            mMailMessage02.Body = mMailMessage02.Body & "Email : " & txtBuyeremail.Text & "<br/>"
        End If
        If txtdatecreated.Text <> "" Then
            mMailMessage02.Body = mMailMessage02.Body & "Date Created : " & txtdatecreated.Text & "<br/>"
        End If
        If drpUser.SelectedItem.Text <> "--Salesperson--" Then
            mMailMessage02.Body = mMailMessage02.Body & "SalesPerson : " & drpUser.SelectedItem.Text & "<br/>"
        End If
        If DropDownListSource.SelectedItem.Text <> "--Source--" Then
            mMailMessage02.Body = mMailMessage02.Body & "Source : " & DropDownListSource.SelectedItem.Text & "<br/>"
        End If
        If DropDownListStatus.SelectedItem.Text <> "--Status--" Then
            mMailMessage02.Body = mMailMessage02.Body & "Status : " & DropDownListStatus.SelectedItem.Text & "<br/>"
        End If

        mMailMessage02.Body = mMailMessage02.Body & "Only Archived : " & CheckBoxIncludeArchived.Checked.ToString() & "<br/>"

        mMailMessage02.Body = mMailMessage02.Body & "Criterias Selection : " & "" & "<br/>"

        For a = 0 To DropDownListCriterias.Items.Count - 1
            If DropDownListCriterias.Items(a).Selected = True Then
                mMailMessage02.Body = mMailMessage02.Body & DropDownListCriterias.Items(a).Text & " " & drpListType.SelectedItem.Text & "<br/> "
            End If
        Next

        ' Set the format of the mail message body as HTML
        mMailMessage02.IsBodyHtml = True

        ' Set the priority of the mail message to normal
        mMailMessage02.Priority = MailPriority.Normal

        ' Instantiate a new instance of SmtpClient
        Dim mSmtpClient02 As New SmtpClient()

        ' Send the Mail Message
        mSmtpClient02.Send(mMailMessage02)

        ' Tidy
        mSmtpClient02.Dispose()
        ' Tidy
        mSmtpClient02.Dispose()


        lblExportMailingMessage.Visible = True
        lblExportMailingMessage.Text = "Contact list csv file has been created & been sent successfully to you by Email"
    End Sub
    'Public Shared Function WriteCSV(ByVal input As String) As String
    '    Try
    '        If (input Is Nothing) Then
    '            Return String.Empty
    '        End If
    '        Dim containsQuote As Boolean = False
    '        Dim containsComma As Boolean = False
    '        Dim len As Integer = input.Length
    '        Dim i As Integer = 0
    '        Do While ((i < len) _
    '        AndAlso ((containsComma = False) _
    '        OrElse (containsQuote = False)))
    '            Dim ch As Char = input(i)
    '            If (ch = Microsoft.VisualBasic.ChrW(34)) Then
    '                containsQuote = True
    '            ElseIf (ch = Microsoft.VisualBasic.ChrW(44)) Then
    '                containsComma = True
    '            End If

    '            i = (i + 1)
    '        Loop
    '        If (containsQuote AndAlso containsComma) Then
    '            input = input.Replace("""", """""")
    '        End If
    '        If (containsComma) Then
    '            Return """" & input & """"
    '        Else
    '            Return input
    '        End If
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function
End Class
