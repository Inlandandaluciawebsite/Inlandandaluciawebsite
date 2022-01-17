Imports Microsoft.VisualBasic

Public Class ClassClientTourProperty

    Private m_nPropertyID As Integer
    Public Property PropertyID() As Integer
        Get
            Return m_nPropertyID
        End Get
        Set(ByVal value As Integer)
            m_nPropertyID = value
        End Set
    End Property

    Private m_dtViewingTime As DateTime
    Public Property ViewingTime() As DateTime
        Get
            Return m_dtViewingTime
        End Get
        Set(ByVal value As DateTime)
            m_dtViewingTime = value
        End Set
    End Property

    Private m_szPropertyReference As String
    Public Property PropertyReference() As String
        Get
            Return m_szPropertyReference
        End Get
        Set(ByVal value As String)
            m_szPropertyReference = value
        End Set
    End Property

    Private m_szExternalReference As String
    Public Property ExternalReference() As String
        Get
            Return m_szExternalReference
        End Get
        Set(ByVal value As String)
            m_szExternalReference = value
        End Set
    End Property

End Class
