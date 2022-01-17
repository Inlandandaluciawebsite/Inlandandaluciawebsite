
Partial Class httpdocs_Controls_WebUserControlPropertyTestimonial
    Inherits System.Web.UI.UserControl

    Private m_szTestimonialText As String
    Public ReadOnly Property TestimonialText() As String
        Get
            Return m_szTestimonialText
        End Get
    End Property

    Private m_szTestimonialDate As String
    Public ReadOnly Property TestimonialDate() As String
        Get
            Return m_szTestimonialDate
        End Get
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Set Variables
        m_szTestimonialText = Session("TestimonialText")
        m_szTestimonialDate = Session("TestimonialDate")

    End Sub

End Class
