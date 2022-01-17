Imports System.Data

Partial Class WebUserControlAdminTestimonials
    Inherits System.Web.UI.UserControl

    Private Sub AddTestimonial(Optional ByVal nTestimonialID As Integer = 0,
                               Optional ByVal dtTestimonialDate As Date = #1/1/2000#,
                               Optional ByVal szTestimonialText As String = vbNullString)

        Dim ctrl As ASP.controlsNew_webusercontroladmintestimonial_ascx

        ' Create a New Control
        ctrl = CType(LoadControl("~/controlsNew/WebUserControlAdminTestimonial.ascx"), ASP.controlsNew_webusercontroladmintestimonial_ascx)

        ' Define an ID
        ctrl.ID = "AdminTestimonial" & nTestimonialID.ToString.Trim

        ' Add Handler
        AddHandler ctrl.TestimonialAdded, AddressOf TestimonialAdded

        ' If this is a New Testimonial
        If nTestimonialID < 1 Then

            ' Insert Topmost
            Me.Controls.AddAt(2, ctrl)

            ' Init New Testimonial
            ctrl.InitData()

        Else

            ' Add to the Form at the End
            Me.Controls.Add(ctrl)

            ' Init Existing Testimonial
            ctrl.InitData(nTestimonialID, dtTestimonialDate, szTestimonialText)

        End If

    End Sub

    Private Sub TestimonialAdded()

        ' Create a New Testimonial Control
        AddTestimonial()

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Get the Testimonials
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable = CDataAccess.Testimonials
        CDataAccess = Nothing

        ' Add new Testimonial
        AddTestimonial()

        ' For each Record
        For Each dr As DataRow In dtDataTable.Rows

            ' Add Existing Testimonial
            AddTestimonial(Convert.ToInt32(dr("testimonial_id")), Convert.ToDateTime(dr("testimonial_date")), Convert.ToString(dr("testimonial_text")))

        Next

    End Sub

End Class
