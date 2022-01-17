
Partial Class WebUserControlReportClientTourMissingFeedback
    Inherits System.Web.UI.UserControl

    Public Event TourSelected()

    Private Sub DisplayReport()

        ' Clear Controls
        Me.Controls.Clear()

        ' Add Header
        'Me.Controls.Add(New LiteralControl("<h1>Client Tours Requiring Feedback</h1>"))

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Get the Properties still requiring Feedback
        Dim alClientTour As ArrayList = CDataAccess.ClientTourRequiringFeedback(Convert.ToString(Session("ReportClientToursMissingFeedbackSortBy")), Convert.ToBoolean(Session("ReportClientToursMissingFeedbackSortAsc")))

        ' Tidy
        CDataAccess = Nothing

        ' For each Client Tour
        For Each CClientTour As ClassClientTour In alClientTour

            ' Create a New Entry
            Dim CReportClientTourMissingFeedbackEntry As New ASP.controlsnew_webusercontrolreportclienttourmissingfeedbackentry_ascx

            ' Add Handlers
            AddHandler CReportClientTourMissingFeedbackEntry.TourSelected, AddressOf ClientTourSelected
            AddHandler CReportClientTourMissingFeedbackEntry.SortByTour, AddressOf SortByTour
            AddHandler CReportClientTourMissingFeedbackEntry.SortByDate, AddressOf SortByDate
            AddHandler CReportClientTourMissingFeedbackEntry.SortByTourer, AddressOf SortByTourer
            AddHandler CReportClientTourMissingFeedbackEntry.SortByBuyer, AddressOf SortByBuyer

            ' Add New Line
            ' Me.Controls.Add(New LiteralControl("<br />"))

            ' Add this to the Form
            Me.Controls.Add(CReportClientTourMissingFeedbackEntry)

            ' Init
            CReportClientTourMissingFeedbackEntry.InitData(CClientTour)

        Next

        ' Tidy
        alClientTour.Clear()
        alClientTour = Nothing

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' If Sorting not been Defined
        If Session("ReportClientToursMissingFeedbackSortBy") Is Nothing Then

            ' Set Sort Item
            Session("ReportClientToursMissingFeedbackSortBy") = "Tour"

        End If

        If Session("ReportClientToursMissingFeedbackSortAsc") Is Nothing Then

            ' Set Sort Direction
            Session("ReportClientToursMissingFeedbackSortAsc") = True

        End If

    End Sub

    Private Sub ClientTourSelected()
        RaiseEvent TourSelected()
    End Sub

    Private Sub SortByTour()

        ' If we were already Sorting by this
        If Session("ReportClientToursMissingFeedbackSortBy") = "Tour" Then

            ' Change the Sort Order 
            Session("ReportClientToursMissingFeedbackSortAsc") = Not Convert.ToBoolean(Session("ReportClientToursMissingFeedbackSortAsc"))

        Else

            ' Set this as the Sort
            Session("ReportClientToursMissingFeedbackSortBy") = "Tour"

            ' Init Ascending
            Session("ReportClientToursMissingFeedbackSortAsc") = True

        End If

        ' Display Report
        DisplayReport()

    End Sub

    Private Sub SortByDate()

        ' If we were already Sorting by this
        If Session("ReportClientToursMissingFeedbackSortBy") = "Date" Then

            ' Change the Sort Order 
            Session("ReportClientToursMissingFeedbackSortAsc") = Not Convert.ToBoolean(Session("ReportClientToursMissingFeedbackSortAsc"))

        Else

            ' Set this as the Sort
            Session("ReportClientToursMissingFeedbackSortBy") = "Date"

            ' Init Ascending
            Session("ReportClientToursMissingFeedbackSortAsc") = True

        End If

        ' Display Report
        DisplayReport()

    End Sub

    Private Sub SortByTourer()

        ' If we were already Sorting by this
        If Session("ReportClientToursMissingFeedbackSortBy") = "Tourer" Then

            ' Change the Sort Order 
            Session("ReportClientToursMissingFeedbackSortAsc") = Not Convert.ToBoolean(Session("ReportClientToursMissingFeedbackSortAsc"))

        Else

            ' Set this as the Sort
            Session("ReportClientToursMissingFeedbackSortBy") = "Tourer"

            ' Init Ascending
            Session("ReportClientToursMissingFeedbackSortAsc") = True

        End If

        ' Display Report
        DisplayReport()

    End Sub

    Private Sub SortByBuyer()

        ' If we were already Sorting by this
        If Session("ReportClientToursMissingFeedbackSortBy") = "Buyer" Then

            ' Change the Sort Order 
            Session("ReportClientToursMissingFeedbackSortAsc") = Not Convert.ToBoolean(Session("ReportClientToursMissingFeedbackSortAsc"))

        Else

            ' Set this as the Sort
            Session("ReportClientToursMissingFeedbackSortBy") = "Buyer"

            ' Init Ascending
            Session("ReportClientToursMissingFeedbackSortAsc") = True

        End If

        ' Display Report
        DisplayReport()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitForm()

    End Sub

    Public Sub InitForm()

        ' Display
        DisplayReport()

    End Sub

End Class
