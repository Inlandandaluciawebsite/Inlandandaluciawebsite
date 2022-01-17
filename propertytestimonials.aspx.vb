Imports System.Data

Partial Class propertytestimonials
    'Inherits System.Web.UI.Page
    Inherits BasePage

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Load the Testimonials
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable = CDataAccess.Testimonials
        ' Dim CPropertyTestimonial As Control
        rptest.DataSource = dtDataTable
        rptest.DataBind()

        ' For each Testimonial
        For Each dr As DataRow In dtDataTable.Rows

            ' Set the Session Values
            Session("TestimonialDate") = Convert.ToDateTime(dr("testimonial_date")).ToString("MMMM, yyyy").Trim
            Session("TestimonialText") = Replace(dr("testimonial_text"), vbCrLf, "<br>")
            ' Session("TestimonialText") = dr("testimonial_text").ToString()
            ' Init Class
            '   CPropertyTestimonial = LoadControl("Controls/WebUserControlPropertyTestimonial.ascx")

            ' Add this to the Update Panel
            '   UpdatePanelTestimonials.ContentTemplateContainer.Controls.Add(CPropertyTestimonial)

        Next

        ' Tidy
        dtDataTable.Dispose()
        CDataAccess = Nothing

    End Sub
End Class
