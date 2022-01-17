
Partial Class WebUserControlAdminClientTourFeedbackEntry
    Inherits System.Web.UI.UserControl

    Private m_szControlID As String
    Private Property ControlID() As String
        Get
            Return m_szControlID
        End Get
        Set(ByVal value As String)
            m_szControlID = value
        End Set
    End Property

    Private m_nClientTourID As Integer
    Private Property ClientTourID() As Integer
        Get
            Return m_nClientTourID
        End Get
        Set(ByVal value As Integer)
            m_nClientTourID = value
        End Set
    End Property

    Private m_nPropertyID As Integer
    Private Property PropertyID() As Integer
        Get
            Return m_nPropertyID
        End Get
        Set(ByVal value As Integer)
            m_nPropertyID = value
        End Set
    End Property

    Public Sub InitData(ByVal szControlID As String, ByVal nClientTourID As Integer, ByVal nPropertyID As Integer, ByVal szPropertyRef As String)

        ' Save IDs
        ControlID = szControlID
        ClientTourID = nClientTourID
        PropertyID = nPropertyID

        ' Assign Reference
        LabelPropertyRef.Text = szPropertyRef.Trim

    End Sub

    Public Sub Save(ByVal CDataAccess As ClassDataAccess, ByVal szClient As String, ByVal szTourBy As String)

        ' Check Session hasn't Expired
        If Session("ContactID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim szFeedback As String = TextBoxFeedback.Text.Trim

            ' Check Feedback Exists
            If szFeedback.Trim = String.Empty Then

                ' Record No Feedback
                szFeedback = "No Feedback Provided"

            End If

            ' Prefix
            szFeedback = "Feedback received from " & szClient.Trim & " on Client Tour ID [" & ClientTourID.ToString.Trim & "] by " & szTourBy.Trim & " - " & szFeedback

            ' Save Feedback
            CDataAccess.SaveClientTourFeedback(ClientTourID, PropertyID, szFeedback, Convert.ToInt32(Session("ContactID")))

        End If

    End Sub

End Class
