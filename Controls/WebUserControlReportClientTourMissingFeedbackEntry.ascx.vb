Imports System.IO

Partial Class WebUserControlReportClientTourMissingFeedbackEntry
    Inherits System.Web.UI.UserControl

    Public Event TourSelected()
    Public Event SortByTour()
    Public Event SortByDate()
    Public Event SortByTourer()
    Public Event SortByBuyer()

    Public Sub InitData(ByVal CClientTour As ClassClientTour)

        ' Local Vars
        Dim cl As TableCell
        Dim rw As TableRow
        Dim nRowCounter As Integer = 0

        ' Add Header Info
        LabelTourID.Text = CClientTour.TourID.ToString.Trim
        LabelTourDate.Text = CClientTour.ViewingDate.ToShortDateString.Trim
        LabelTourBy.Text = CClientTour.TourWith
        LabelBuyer.Text = CClientTour.Buyer

        ' Add the Pic of the Tourer - Init Image
        Dim imgTourer As New Image()

        ' Check to see if the Image Exists
        If File.Exists(Server.MapPath("~/images/logos/p" & CClientTour.TourWithID.ToString.Trim & ".jpg")) Then

            ' Assign Image
            imgTourer.ImageUrl = "~/images/logos/p" & CClientTour.TourWithID.ToString.Trim & ".jpg"

        Else

            ' Assign Lack of Image Icon
            imgTourer.ImageUrl = "~/images/icons/no-photo.png"

        End If

        ' Add Border
        imgTourer.BorderStyle = BorderStyle.Ridge

        ' Set the Width
        imgTourer.Width = 50

        ' Define a Table Cell
        cl = New TableCell

        ' Set Attributes
        cl.RowSpan = CClientTour.TourProperty.Count
        cl.HorizontalAlign = HorizontalAlign.Center

        ' Add the Image
        cl.Controls.Add(imgTourer)

        ' Add to a Row
        rw = New TableRow
        rw.Cells.Add(cl)

        ' For each Property
        For Each CClientTourProperty As ClassClientTourProperty In CClientTour.TourProperty

            ' Increment Row Counter
            nRowCounter += 1

            ' Define a Table Cell
            cl = New TableCell

            ' Add IA Ref
            cl.Text = CClientTourProperty.PropertyReference.Trim

            ' Add to a Row (if not First Row)
            If nRowCounter > 1 Then
                rw = New TableRow
            End If

            ' Add Cell
            rw.Cells.Add(cl)

            ' Define a Table Cell
            cl = New TableCell

            ' Add External Ref
            cl.Text = "Partner Reference: " & CClientTourProperty.ExternalReference.Trim

            ' Add to Row
            rw.Cells.Add(cl)

            ' Add a New Row to the Table
            TableEntry.Rows.Add(rw)

        Next

        ' Update Button Text
        ButtonOpenTour.Text = "Open Tour ID: " & LabelTourID.Text.Trim

    End Sub

    Protected Sub LinkButtonSortTour_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonSortTour.Click
        RaiseEvent SortByTour()
    End Sub

    Protected Sub LinkButtonSortDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonSortDate.Click
        RaiseEvent SortByDate()
    End Sub

    Protected Sub LinkButtonSortBy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonSortBy.Click
        RaiseEvent SortByTourer()
    End Sub

    Protected Sub LinkButtonSortBuyer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonSortBuyer.Click
        RaiseEvent SortByBuyer()
    End Sub

    Protected Sub ButtonOpenTour_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOpenTour.Click

        Session("ClientTourID") = Convert.ToInt32(LabelTourID.Text.Trim)

        RaiseEvent TourSelected()

    End Sub

End Class
