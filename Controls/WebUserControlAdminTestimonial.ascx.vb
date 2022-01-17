
Partial Class WebUserControlAdminTestimonial
    Inherits System.Web.UI.UserControl

    Public Event TestimonialAdded()

    Private m_nTestimonialID As Integer
    Private Property TestimonialID As Integer
        Get
            Return m_nTestimonialID
        End Get
        Set(ByVal value As Integer)
            m_nTestimonialID = value
        End Set
    End Property

    Private m_szTestimonial As String
    Public Property Testimonial() As String
        Get
            Return m_szTestimonial
        End Get
        Set(ByVal value As String)
            m_szTestimonial = value
        End Set
    End Property

    Public Sub InitData(Optional ByVal nID As Integer = 0, Optional ByVal dtDate As Date = #1/1/2000#, Optional ByVal szTestimonial As String = vbNullString)

        ' If Date is Default, set to Today
        If dtDate = #1/1/2000# Then
            dtDate = Today
        End If

        ' Init Vars
        TestimonialID = nID
        AdminDatePicker.SetDate(dtDate)

        ' If we have a Testimonial
        If Not szTestimonial Is Nothing Then
            Testimonial = szTestimonial.Trim
        End If

        ' Add Testimonial
        TextBoxTestimonial.Text = Testimonial

        ' Clean
        MakeClean()

    End Sub

    Protected Sub TextBoxTestimonial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxTestimonial.TextChanged

        ' Define Regex
        Dim rgx As Regex = New Regex("[^a-zA-Z0-9 -.]")

        ' If the Text has Changed
        If rgx.Replace(TextBoxTestimonial.Text, "") = rgx.Replace(Testimonial, "") Then
            MakeClean()
        Else
            MakeDirty()
        End If

    End Sub

    Private Sub MakeDirty()

        ' Highlight
        ButtonSave.BackColor = Drawing.Color.Red
        ButtonSave.ForeColor = Drawing.Color.White
        ButtonSave.Font.Bold = True

        ' Hide the Saved Message
        LabelSaved.Visible = False

    End Sub

    Private Sub MakeClean()

        ' Remove Highlight
        ButtonSave.BackColor = Nothing
        ButtonSave.ForeColor = Nothing
        ButtonSave.Font.Bold = False

    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim bNewEntry As Boolean = (TestimonialID = 0)

        ' Update Testimonial
        TestimonialID = CDataAccess.UpdateTestimonial(TestimonialID, AdminDatePicker.SelectedDate, TextBoxTestimonial.Text.Trim)

        ' Tidy
        CDataAccess = Nothing

        ' Reassign ID
        ID = "AdminTestimonial" & TestimonialID.ToString.Trim

        ' Assign to Local
        Testimonial = TextBoxTestimonial.Text.Trim

        ' Make Clean
        MakeClean()

        ' Display Message
        LabelSaved.Visible = True

        ' Start Timer
        TimerSaved.Enabled = True

        ' If this was a New Entry
        If bNewEntry Then

            ' Raise the Event
            RaiseEvent TestimonialAdded()

        End If

    End Sub

    Public Sub New()

        ' Init Vars
        Testimonial = String.Empty

    End Sub

    Public Sub HideSaved()

        ' Stop Timer
        TimerSaved.Enabled = False

        ' Hide the Saved Label
        LabelSaved.Visible = False

    End Sub

    Protected Sub AdminDatePicker_DateChanged() Handles AdminDatePicker.DateChanged
        MakeDirty()
    End Sub

End Class
