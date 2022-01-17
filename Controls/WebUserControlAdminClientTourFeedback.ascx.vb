Imports System.Data

Partial Class WebUserControlAdminClientTourFeedback
    Inherits System.Web.UI.UserControl

    Public Event Finished()

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' If the Session has Expired
        If Session("ContactPartnerID") Is Nothing Or Session("FeedbackClientTourID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Clear Current
            UpdatePanelFeedback.ContentTemplateContainer.Controls.Clear()

            ' Load the Properties on this Tour that still require Feedback
            Dim CDataAccess As New ClassDataAccess
            Dim dtDataTable As DataTable = CDataAccess.ClientTourFeedback(Convert.ToInt32(Session("ContactPartnerID")), Convert.ToInt32(Session("FeedbackClientTourID")))
            CDataAccess = Nothing

            ' Init Counter
            Dim nCounter As Integer = 0

            ' For each Row Returned
            For Each dr As DataRow In dtDataTable.Rows

                ' Increment Counter
                nCounter += 1

                ' Add Entry
                CreateFeedbackEntry(nCounter, Convert.ToInt32(dr.Item("tour_id")), Convert.ToInt32(dr.Item("property_id")), dr.Item("partner_reference").ToString.Trim)

            Next

            ' Tidy
            dtDataTable.Dispose()

        End If

    End Sub

    Private Sub CreateFeedbackEntry(ByVal nID As Integer, ByVal nClientTourID As Integer, ByVal nPropertyID As Integer, ByVal szPropertyRef As String)

        ' Create a New Control
        Dim ctrl As ASP.controls_webusercontroladminclienttourfeedbackentry_ascx = CType(LoadControl("~/Controls/WebUserControlAdminClientTourFeedbackEntry.ascx"), ASP.controls_webusercontroladminclienttourfeedbackentry_ascx)

        ' Define an ID
        ctrl.ID = "AdminClientTourFeedbackEntry" & nID.ToString.Trim

        ' Init Control
        ctrl.InitData(ctrl.ID, nClientTourID, nPropertyID, szPropertyRef)

        ' Add to the Form
        UpdatePanelFeedback.ContentTemplateContainer.Controls.Add(ctrl)

        ' Update the Panel
        UpdatePanelFeedback.Update()

    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' If the Session hasn't Expired
        If Session("FeedbackClientTourID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim szClient As String = String.Empty
            Dim szTourBy As String = String.Empty

            ' Load Tour Feedback Header
            CDataAccess.ClientTourVendorTourBy(Convert.ToInt32(Session("FeedbackClientTourID")), szClient, szTourBy)

            ' For each of the Feedback Controls
            For Each ctrl As ASP.controls_webusercontroladminclienttourfeedbackentry_ascx In UpdatePanelFeedback.ContentTemplateContainer.Controls

                ' Save the Feedback
                ctrl.Save(CDataAccess, szClient, szTourBy)

            Next

            ' Tidy
            CDataAccess = Nothing

            ' Raise Event
            RaiseEvent Finished()

        End If

    End Sub

End Class
