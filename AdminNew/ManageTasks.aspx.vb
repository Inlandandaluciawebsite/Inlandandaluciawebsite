Imports Microsoft.VisualBasic
Imports System.IO
Imports ClassHistory
Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient
Imports Inl

Public Class Admin_ManageTasks
    Inherits System.Web.UI.Page

    Public Event BuyerSelected()
    Dim redval As Integer = 0
    Dim pg As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            bindgrid()
        End If

    End Sub



    Private Sub bindgrid()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTasks_Select_All").Tables(0)
        grdTasks.DataSource = dt
        grdTasks.DataBind()
        If dt.Rows.Count > 0 Then
            BtnDelete.Visible = True
        Else
            LabelNoResults.Visible = True
            BtnDelete.Visible = False
        End If
    End Sub
    Protected Sub grdTasks_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdTasks.PageIndex = e.NewPageIndex
        redval = 1
        bindgrid()
    End Sub



    Protected Sub grdTasks_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        Dim taskId As Integer = 0
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' determine the value of the UnitsInStock field
            Dim lsDataKeyValue As String = grdTasks.DataKeys(e.Row.RowIndex).Values(0).ToString()

            Dim theHiddenField As HiddenField = TryCast(e.Row.FindControl("TaskHidden"), HiddenField)

            Dim strtbtn As Button = e.Row.FindControl("startbtn")
            Dim pausebtn As Button = e.Row.FindControl("pausebtn")
            Dim endbtn As Button = e.Row.FindControl("endbtn")
            Dim resumebtn As Button = e.Row.FindControl("resumebtn")

            strtbtn.Visible = False
            pausebtn.Visible = False
            endbtn.Visible = False
            resumebtn.Visible = False


            Dim StartTime As String = String.Empty
            Dim PauseTime As String = String.Empty
            Dim ResumeTime As String = String.Empty
            Dim EndTime As String = String.Empty

            If theHiddenField IsNot Nothing Then


                taskId = Convert.ToInt32(theHiddenField.Value)

                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@TaskId", taskId)

                Dim dataset As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblActualTime_GetAllData", sql).Tables(0)
                Dim Count As Integer = dataset.Rows.Count - 1

                If Count > -1 Then


                    If Not IsDBNull(dataset.Rows(Count)("StartTime")) Then
                        StartTime = dataset.Rows(Count)("StartTime")
                    End If

                    If Not IsDBNull(dataset.Rows(Count)("PauseTime")) Then
                        PauseTime = dataset.Rows(Count)("PauseTime")
                    End If

                    If Not IsDBNull(dataset.Rows(Count)("ResumeTime")) Then
                        ResumeTime = dataset.Rows(Count)("ResumeTime")
                    End If

                    If Not IsDBNull(dataset.Rows(Count)("EndTime")) Then
                        EndTime = dataset.Rows(Count)("EndTime")
                    End If

                    If Not StartTime = "" Then

                        pausebtn.Visible = True
                        endbtn.Visible = True
                        resumebtn.Visible = False

                        Dim totaltime As String = Calculate_ActualTime(taskId)
                        Dim label As Label = e.Row.FindControl("textlabel")
                        label.Text = totaltime



                    ElseIf Not EndTime = "" Then

                        strtbtn.Visible = False
                        pausebtn.Visible = False
                        endbtn.Visible = False
                        resumebtn.Visible = False
                        Dim totaltime As String = Calculate_ActualTime(taskId)
                        Dim label As Label = e.Row.FindControl("textlabel")
                        Dim finish As Label = e.Row.FindControl("finishlabel")

                        finish.Text = "Finished"
                        label.Text = totaltime

                        'ElseIf Not PauseTime = "" And ResumeTime = "" Then

                        '    resumebtn.Visible = True




                    ElseIf Not ResumeTime = "" And Not PauseTime = "" Then

                        strtbtn.Visible = False
                        pausebtn.Visible = True
                        endbtn.Visible = True

                        Dim totaltime As String = Calculate_ActualTime(taskId)
                        Dim label As Label = e.Row.FindControl("textlabel")
                        label.Text = totaltime

                    ElseIf Not PauseTime = "" And ResumeTime = "" Then

                        resumebtn.Visible = True

                        Dim totaltime As String = Calculate_ActualTime(taskId)
                        Dim label As Label = e.Row.FindControl("textlabel")
                        label.Text = totaltime



                    ElseIf PauseTime = "" And ResumeTime = "" Then

                        pausebtn.Visible = True
                        endbtn.Visible = True


                        'Else

                        '    strtbtn.Visible = False
                        '    pausebtn.Visible = True
                        '    endbtn.Visible = True


                    End If


                    'ElseIf Count = -1 And e.Row.DataItem(9) = "Completed" Then

                    '    strtbtn.Visible = False
                    '    pausebtn.Visible = False
                    '    endbtn.Visible = False
                    '    resumebtn.Visible = False
                    '    Dim finish As Label = e.Row.FindControl("finishlabel")
                    '    finish.Text = "Finished"

                ElseIf Count = -1 Then

                    strtbtn.Visible = True
                    pausebtn.Visible = False
                    endbtn.Visible = False
                    resumebtn.Visible = False


                End If

            End If
            ' Dim CategoryID As Integer = Convert.ToInt32(DataBinder.Eval(e.Row., "contact_id"))
            If lsDataKeyValue = Request.QueryString("Id") Then
                ' color the background of the row yellow
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9CF06")
                ' ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "EditModalScript", script.ToString(), False)
            End If
        End If
    End Sub
    Protected Sub grdTasks_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "editadmin" Then
            Response.Redirect("AddTask.aspx?TaskId=" & e.CommandArgument.ToString())
        End If
    End Sub


    'Protected Sub grdTasks_Sorting(sender As Object, e As GridViewSortEventArgs)
    '    Dim strSortExpression As String() = ViewState("SortExpressionCP").ToString().Split(" ")

    '    ' If the sorting column is the same as the previous one,  
    '    ' then change the sort order. 
    '    If strSortExpression(0) = e.SortExpression Then
    '        If strSortExpression(1) = "ASC" Then
    '            ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "DESC"
    '        Else
    '            ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "ASC"
    '        End If
    '    Else
    '        ' If sorting column is another column,   
    '        ' then specify the sort order to "Ascending". 
    '        ViewState("SortExpressionCP") = Convert.ToString(e.SortExpression) & " " & "ASC"
    '    End If

    '    ' Rebind the GridView control to show sorted data. 
    '    bindgrid()
    'End Sub

    Protected Sub BtnDelete_Click(sender As Object, e As EventArgs)
        Dim ID As Int32
        For i As Int32 = 0 To grdTasks.Rows.Count - 1
            Dim chkClient As CheckBox = DirectCast(grdTasks.Rows(i).FindControl("chkSelect"), CheckBox)

            If chkClient.Checked <> True Then
            Else
                ID = Convert.ToInt32(grdTasks.DataKeys(i)(0))
                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@TaskId", ID)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblTasks_Delete_By_TaskId", sql)
                Page.RegisterStartupScript("script", "<script language='javascript'>alert('Record has been sucessfully removed !');</script>")
            End If
        Next

        bindgrid()
    End Sub

    Protected Sub StartButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As Button = sender

        If lnk.CommandName = "startTask" Then

            Dim ID As Int32 = lnk.CommandArgument
            Dim StartTime As Nullable(Of DateTime) = Date.Now
            Dim PauseTime As Nullable(Of DateTime) = Nothing
            Dim ResumeTime As Nullable(Of DateTime) = Nothing
            Dim EndTime As Nullable(Of DateTime) = Nothing


            Dim sql As SqlParameter() = New SqlParameter(4) {}
            sql(0) = New SqlParameter("@StartTime", StartTime)
            sql(1) = New SqlParameter("@PauseTime", PauseTime)
            sql(2) = New SqlParameter("@ResumeTime", ResumeTime)
            sql(3) = New SqlParameter("@EndTime", EndTime)
            sql(4) = New SqlParameter("@TaskId", ID)

            Dim dtTask As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblActualTime_Insert", sql).Tables(0)

            Response.Redirect("ManageTasks.aspx")

        End If

        If lnk.CommandName = "pauseTask" Then

            Dim ID As Int32 = lnk.CommandArgument
            Dim StartTime As Nullable(Of DateTime) = Nothing
            Dim PauseTime As Nullable(Of DateTime) = Date.Now
            Dim ResumeTime As Nullable(Of DateTime) = Nothing
            Dim EndTime As Nullable(Of DateTime) = Nothing


            Dim sql As SqlParameter() = New SqlParameter(4) {}
            sql(0) = New SqlParameter("@StartTime", StartTime)
            sql(1) = New SqlParameter("@PauseTime", PauseTime)
            sql(2) = New SqlParameter("@ResumeTime", ResumeTime)
            sql(3) = New SqlParameter("@EndTime", EndTime)
            sql(4) = New SqlParameter("@TaskId", ID)

            Dim dtTask As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblActualTime_Insert", sql).Tables(0)

            Response.Redirect("ManageTasks.aspx")


        End If

        If lnk.CommandName = "endTask" Then

            Dim ID As Int32 = lnk.CommandArgument
            Dim StartTime As Nullable(Of DateTime) = Nothing
            Dim PauseTime As Nullable(Of DateTime) = Nothing
            Dim ResumeTime As Nullable(Of DateTime) = Nothing
            Dim EndTime As Nullable(Of DateTime) = Date.Now

            Dim sql As SqlParameter() = New SqlParameter(4) {}
            sql(0) = New SqlParameter("@StartTime", StartTime)
            sql(1) = New SqlParameter("@PauseTime", PauseTime)
            sql(2) = New SqlParameter("@ResumeTime", ResumeTime)
            sql(3) = New SqlParameter("@EndTime", EndTime)
            sql(4) = New SqlParameter("@TaskId", ID)

            Try
                Dim dtTask As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblActualTime_Insert", sql).Tables(0)

            Catch ex As Exception
                Throw ex

            End Try


            Dim value As String = Calculate_ActualTime(ID)
            Response.Redirect("ManageTasks.aspx")

        End If


        If lnk.CommandName = "resumeTask" Then

            Dim ID As Int32 = lnk.CommandArgument
            Dim ResumeTime As Nullable(Of DateTime) = Date.Now

            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@ResumeTime", ResumeTime)
            sql(1) = New SqlParameter("@TaskId", ID)
            Try
                Dim dtTask As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblActualTime_Resume_Update", sql).Tables(0)

            Catch ex As Exception
                Throw ex

            End Try

            Response.Redirect("ManageTasks.aspx")

        End If



    End Sub




    Function Calculate_ActualTime(ByVal id As Int32) As String

        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@TaskId", id)

        Dim dataset As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblActualTime_GetAllData", sql).Tables(0)

        Dim totalTime As String

        If dataset.Rows.Count > 0 Then
            'Dim arr As IEnumerable = dtTask
            Dim endIndex As Integer = dataset.Rows.Count
            Dim tblName As String = dataset.TableName
            'Dim actualtimelst As List(Of String)
            Dim List As New List(Of ActualTimeViewModel)
            'Dim obj As New ActualTimeViewModel

            Dim statusId As Integer = 0

            For i As Integer = 0 To endIndex - 1 Step 1

                Dim ActualTimeId As Integer
                Dim StartTime As String = String.Empty
                Dim PauseTime As String = String.Empty
                Dim ResumeTime As String = String.Empty
                Dim EndTime As String = String.Empty
                Dim TaskId As Integer
                statusId = 0

                ActualTimeId = dataset.Rows(i)("ActualTimeId")

                If Not IsDBNull(dataset.Rows(i)("StartTime")) Then
                    StartTime = dataset.Rows(i)("StartTime")
                End If

                If Not IsDBNull(dataset.Rows(i)("PauseTime")) Then
                    PauseTime = dataset.Rows(i)("PauseTime")
                End If

                If Not IsDBNull(dataset.Rows(i)("ResumeTime")) Then
                    ResumeTime = dataset.Rows(i)("ResumeTime")
                End If

                If Not IsDBNull(dataset.Rows(i)("EndTime")) Then
                    EndTime = dataset.Rows(i)("EndTime")
                End If


                'If Not IsDBNull(dataset.Rows(i)("TaskStatusNumber")) Then
                '    statusId = dataset.Rows(i)("TaskStatusNumber")
                'End If

                TaskId = dataset.Rows(i)("TaskId")

                Dim obj As ActualTimeViewModel = New ActualTimeViewModel()

                obj.ActualTimeId = ActualTimeId
                obj.StartTime = StartTime
                obj.PauseTime = PauseTime
                obj.ResumeTime = ResumeTime
                obj.EndTime = EndTime
                obj.TaskId = TaskId

                List.Add(obj)


            Next

            Dim breaktime As String = String.Empty

            Dim startdatetime As String = String.Empty
            Dim enddatetime As String = String.Empty


            startdatetime = (From sDate In List
                             Where Not String.IsNullOrEmpty(sDate.StartTime)
                             Order By sDate.ActualTimeId Ascending
                             Select sDate.StartTime).FirstOrDefault()

            Dim endDateCount = (From eDate In List
                                Where Not String.IsNullOrEmpty(eDate.EndTime)
                                Order By eDate.ActualTimeId Descending
                                Select eDate.EndTime.FirstOrDefault).Count


            If String.IsNullOrEmpty(enddatetime) Or String.IsNullOrWhiteSpace(enddatetime) Or IsNothing(enddatetime) Then
                enddatetime = DateTime.Now
            End If

            If endDateCount > 0 Then

                enddatetime = (From eDate In List
                               Where Not String.IsNullOrEmpty(eDate.EndTime)
                               Order By eDate.ActualTimeId Descending
                               Select eDate.EndTime).FirstOrDefault
            Else

                enddatetime = DateTime.Now
            End If

            Dim totalTaskTime As TimeSpan = DateTime.Parse(enddatetime) - DateTime.Parse(startdatetime)


            Dim breakTimesList = From breakTimes In List
                                 Where Not String.IsNullOrEmpty(breakTimes.PauseTime) Or Not String.IsNullOrWhiteSpace(breakTimes.ResumeTime)
                                 Select breakTimes


            Dim breakPauseTime As String = String.Empty
            Dim breakResumeTime As String = String.Empty


            Dim brbTime As TimeSpan

            If breakTimesList.Count > 0 Then
                For Each item As ActualTimeViewModel In breakTimesList

                    breakPauseTime = item.PauseTime

                    breakResumeTime = item.ResumeTime

                    If String.IsNullOrEmpty(breakResumeTime) Then
                        breakResumeTime = DateTime.Now
                    End If

                    brbTime = DateTime.Parse(breakResumeTime) - DateTime.Parse(breakPauseTime)


                    totalTaskTime = totalTaskTime - brbTime
                Next


            End If


            Dim hours As Int16 = Convert.ToInt32(totalTaskTime.TotalMinutes / 60)
            Dim minutes As Int16 = totalTaskTime.Minutes
            Dim seconds As Int16 = totalTaskTime.Seconds

            totalTime = String.Empty

            If hours > 0 And minutes > 0 Then


                totalTime = hours.ToString + " hrs " + " " + minutes.ToString + " min"

            ElseIf minutes > 0 Then

                totalTime = minutes.ToString + " min"

            ElseIf hours > 0 Then

                totalTime = hours.ToString + " hrs"

            Else

                totalTime = minutes.ToString + " " + "min"


            End If


        End If

        Return totalTime

    End Function




End Class
