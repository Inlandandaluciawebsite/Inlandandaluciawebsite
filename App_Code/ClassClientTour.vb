Imports Microsoft.VisualBasic

Public Class ClassClientTour

    Private m_nTourID As Integer
    Public Property TourID() As Integer
        Get
            Return m_nTourID
        End Get
        Set(ByVal value As Integer)
            m_nTourID = value
        End Set
    End Property

    Private m_nBuyerID As Integer
    Public Property BuyerID() As Integer
        Get
            Return m_nBuyerID
        End Get
        Set(ByVal value As Integer)
            m_nBuyerID = value
        End Set
    End Property

    Private m_nTourWithID As Integer
    Public Property TourWithID() As Integer
        Get
            Return m_nTourWithID
        End Get
        Set(ByVal value As Integer)
            m_nTourWithID = value
        End Set
    End Property

    Private m_dtViewingDateTime As DateTime
    Public Property ViewingDate() As DateTime
        Get
            Return m_dtViewingDateTime
        End Get
        Set(ByVal value As DateTime)
            m_dtViewingDateTime = value
        End Set
    End Property

    Private m_szBuyer As String
    Public Property Buyer() As String
        Get
            Return m_szBuyer
        End Get
        Set(ByVal value As String)
            m_szBuyer = value
        End Set
    End Property

    Private m_szBuyerTelEmail As String
    Public Property BuyerTelEmail() As String
        Get
            Return m_szBuyerTelEmail
        End Get
        Set(ByVal value As String)
            m_szBuyerTelEmail = value
        End Set
    End Property

    Private m_szTourWith As String
    Public Property TourWith() As String
        Get
            Return m_szTourWith
        End Get
        Set(ByVal value As String)
            m_szTourWith = value
        End Set
    End Property
    Private m_VirtualTour As Boolean
    Public Property VirtualTour() As Boolean
        Get
            Return m_VirtualTour
        End Get
        Set(ByVal value As Boolean)
            m_VirtualTour = value
        End Set
    End Property

    Private m_alTourProperty As ArrayList
    Public ReadOnly Property TourProperty As ArrayList
        Get
            Return m_alTourProperty
        End Get
    End Property

    Public Sub New()

        ' Init Tour ID
        TourID = 0

        ' Initialise Array
        m_alTourProperty = New ArrayList

    End Sub

    Protected Overrides Sub Finalize()

        ' Tidy
        TourProperty.Clear()
        m_alTourProperty = Nothing

        MyBase.Finalize()

    End Sub
End Class
