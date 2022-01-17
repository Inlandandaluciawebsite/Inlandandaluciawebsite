Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Partial Class Admin_AddTask
    Inherits System.Web.UI.Page

    'Shared id As Int32 = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            Dim id As Int32 = 0
            If Request.QueryString.HasKeys() Then
                id = Convert.ToInt32(Request.QueryString(0))
                hdnvenid.Value = id
                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@TaskId", id)

                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTasks_Select_By_TaskId", sql).Tables(0)
                If dt.Rows.Count > 0 Then

                    'Dim sql1 As SqlParameter() = New SqlParameter(0) {}
                    'sql1(0) = New SqlParameter("@TaskId", id)
                    'Dim dtset As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblActualTime_GetById", sql1).Tables(0)
                    'Dim count As Int16 = dt.Rows.Count - 1
                    'If (String.IsNullOrEmpty(dtset.Rows(count)("EndTime").ToString)) And Not dt.Rows(0)("TaskStatus") = "Completed" Then

                    '    Session("TaskStatus") = "Not edit"
                    '    Response.Redirect("ManageTasks.aspx")

                    'End If

                    btnUpdate.Style.Add(HtmlTextWriterStyle.Display, "block")
                    btnSubmit.Style.Add(HtmlTextWriterStyle.Display, "none")
                    btnCancel.Style.Add(HtmlTextWriterStyle.Display, "none")
                    txtTaskTitle.Text = Convert.ToString(dt.Rows(0)("Title"))
                    txtDescription.Text = Convert.ToString(dt.Rows(0)("Description"))
                    If Not String.IsNullOrEmpty(Convert.ToString(dt.Rows(0)("AssignedTo"))) Then
                        assigntodropdown.SelectedItem.Text = Convert.ToString(dt.Rows(0)("AssignedTo"))
                    End If
                    txtAssignedBy.Text = Convert.ToString(dt.Rows(0)("AssignedBy"))
                    drpStatus.SelectedValue = Convert.ToString(dt.Rows(0)("TaskStatus"))
                    drpType.SelectedValue = Convert.ToString(dt.Rows(0)("TaskType"))
                    drpPriority.SelectedValue = Convert.ToString(dt.Rows(0)("TaskPriority"))
                    txtPageUrl.Text = Convert.ToString(dt.Rows(0)("PageUrl"))
                    txtEstimatedTime.Text = Convert.ToString(dt.Rows(0)("EstimatedTimeNumber"))
                    txtReason.Text = Convert.ToString(dt.Rows(0)("Reason"))



                    If dt.Rows(0)("Image1").ToString() <> "" Or dt.Rows(0)("Image2").ToString() <> "" Then
                        divImageShow.Visible = True
                        imgImage1.ImageUrl = "images/Tasks/pt_img1_" & id & dt.Rows(0)("Image1").ToString()
                        imgImage2.ImageUrl = "images/Tasks/pt_img2_" & id & dt.Rows(0)("Image2").ToString()
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim taskstatusnumber As Integer

        If drpStatus.SelectedItem.Text = "In Progress" Then
            taskstatusnumber = 0


        ElseIf drpStatus.SelectedItem.Text = "Assigned" Then

            taskstatusnumber = 1

        Else drpStatus.SelectedItem.Text = "Completed"

            taskstatusnumber = 2

        End If

        Dim sql As SqlParameter() = New SqlParameter(13) {}
        sql(0) = New SqlParameter("@Title", txtTaskTitle.Text)
        sql(1) = New SqlParameter("@Description", txtDescription.Text)
        sql(2) = New SqlParameter("@AssignedBy", txtAssignedBy.Text)
        sql(3) = New SqlParameter("@AssignedTo", assigntodropdown.SelectedItem.Value)
        sql(4) = New SqlParameter("@PageUrl", txtPageUrl.Text)
        sql(5) = New SqlParameter("@TaskType", drpType.SelectedItem.Text)
        sql(6) = New SqlParameter("@TaskPriority", drpPriority.SelectedItem.Value)
        sql(7) = New SqlParameter("@TaskStatus", drpStatus.SelectedItem.Text)
        sql(8) = New SqlParameter("@Image1", fucImage1.FileName)
        sql(9) = New SqlParameter("@Image2", fucImage2.FileName)
        sql(10) = New SqlParameter("@Reason", txtReason.Text)
        sql(11) = New SqlParameter("@EstimatedTimeNumber", txtEstimatedTime.Text)
        sql(12) = New SqlParameter("@EstimatedTimeText", EstimatedTimeDropdownList.SelectedItem.Text)
        sql(13) = New SqlParameter("@TaskStatusNumber", taskstatusnumber)


        Dim dtTask As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTasks_Insert", sql).Tables(0)
        Dim taskid As Int32 = 0
        If dtTask.Rows.Count > 0 Then
            taskid = dtTask.Rows(0)("TaskId")
        End If

        If fucImage1.HasFile Then
            ' Get the Filename
            Dim szFileName As String = fucImage1.FileName
            ' Upload the Document
            fucImage1.PostedFile.SaveAs(Server.MapPath("~/AdminNew/images/Tasks/pt_img1_" & taskid.ToString.Trim & fucImage1.FileName))
        End If

        If fucImage2.HasFile Then
            ' Get the Filename
            Dim szFileName As String = fucImage2.FileName
            ' Upload the Document
            fucImage2.PostedFile.SaveAs(Server.MapPath("~/AdminNew/images/Tasks/pt_img2_" & taskid.ToString.Trim & fucImage2.FileName))
        End If

        Response.Redirect("ManageTasks.aspx")
    End Sub



    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)

        Dim id As Int32 = Convert.ToInt32(Request.QueryString(0))

        Dim sql1 As SqlParameter() = New SqlParameter(0) {}
        sql1(0) = New SqlParameter("@TaskId", id)
        Dim dtset As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblActualTime_GetById", sql1).Tables(0)
        Dim count As Int16 = dtset.Rows.Count - 1

        Dim dtset1 As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTasks_Select_By_TaskId", sql1).Tables(0)

        If count > -1 Then

            If (String.IsNullOrEmpty(dtset.Rows(count)("EndTime").ToString)) And drpStatus.SelectedItem.Text = "Completed" Then

                Session("TaskStatus") = "true"
                Response.Redirect("AddTask.aspx?TaskId=" + id.ToString)
            End If
        End If

        Dim count1 As Integer = dtset1.Rows.Count - 1
        If count1 > -1 And count > -1 Then

            If (Not String.IsNullOrEmpty(dtset.Rows(count)("EndTime").ToString)) And dtset1.Rows(0)("TaskStatus") = "Completed" Then
                Session("AlreadyCompleted") = "true"
                Response.Redirect("AddTask.aspx?TaskId=" + id.ToString)
            End If

        End If

        Dim taskstatusnumber As Integer

        If drpStatus.SelectedItem.Text = "In Progress" Then
            taskstatusnumber = 0

        ElseIf drpStatus.SelectedItem.Text = "Assigned" Then

            taskstatusnumber = 1

        Else drpStatus.SelectedItem.Text = "Completed"

            taskstatusnumber = 2

        End If

        Dim sql As SqlParameter() = New SqlParameter(14) {}
        sql(0) = New SqlParameter("@TaskId", id)
        sql(1) = New SqlParameter("@Title", txtTaskTitle.Text)
        sql(2) = New SqlParameter("@Description", txtDescription.Text)
        sql(3) = New SqlParameter("@AssignedBy", txtAssignedBy.Text)
        sql(4) = New SqlParameter("@AssignedTo", assigntodropdown.SelectedItem.Value)
        sql(5) = New SqlParameter("@PageUrl", txtPageUrl.Text)
        sql(6) = New SqlParameter("@TaskType", drpType.SelectedItem.Text)
        sql(7) = New SqlParameter("@TaskPriority", drpPriority.SelectedItem.Text)
        sql(8) = New SqlParameter("@TaskStatus", drpStatus.SelectedItem.Text)
        sql(9) = New SqlParameter("@Image1", fucImage1.FileName)
        sql(10) = New SqlParameter("@Image2", fucImage2.FileName)
        sql(11) = New SqlParameter("@Reason", txtReason.Text)
        sql(12) = New SqlParameter("@EstimatedTimeNumber", txtEstimatedTime.Text)
        sql(13) = New SqlParameter("@EstimatedTimeText", EstimatedTimeDropdownList.SelectedItem.Text)
        sql(14) = New SqlParameter("@TaskStatusNumber", taskstatusnumber)

        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTasks_Update", sql).ToString()
        Response.Redirect("ManageTasks.aspx")
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("ManageTasks.aspx")
    End Sub
    Protected Sub imgImage1_Click(sender As Object, e As ImageClickEventArgs)
        Dim imgbutton1 As ImageButton = sender
        Response.Redirect(imgbutton1.ImageUrl)
    End Sub
    Protected Sub imgImage2_Click(sender As Object, e As ImageClickEventArgs)
        Dim imgbutton2 As ImageButton = sender
        Response.Redirect(imgbutton2.ImageUrl)
    End Sub
End Class
