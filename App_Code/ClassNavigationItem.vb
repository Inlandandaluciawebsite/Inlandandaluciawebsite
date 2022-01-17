Imports Microsoft.VisualBasic

Public Class ClassNavigationItem

    Private m_nID As Integer
    Private m_nParentID As Integer
    Private m_szControlID As String
    Private m_szText As String
    Private m_bAdmin As Boolean
    Private m_bArchived As Boolean
    Private m_liChildren As List(Of ClassNavigationItem)

    Public Property ID() As Integer
        Get
            Return m_nID
        End Get
        Set(ByVal value As Integer)
            m_nID = value
        End Set
    End Property

    Public Property ParentID() As Integer
        Get
            Return m_nParentID
        End Get
        Set(ByVal value As Integer)
            m_nParentID = value
        End Set
    End Property

    Public Property ControlID() As String
        Get
            Return m_szControlID
        End Get
        Set(ByVal value As String)
            m_szControlID = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return m_szText
        End Get
        Set(ByVal value As String)
            m_szText = value
        End Set
    End Property

    Public Property Admin() As Boolean
        Get
            Return m_bAdmin
        End Get
        Set(ByVal value As Boolean)
            m_bAdmin = value
        End Set
    End Property

    Public Property Archived() As Boolean
        Get
            Return m_bArchived
        End Get
        Set(ByVal value As Boolean)
            m_bArchived = value
        End Set
    End Property

    Public Property Children() As List(Of ClassNavigationItem)
        Get
            Return m_liChildren
        End Get
        Set(ByVal value As List(Of ClassNavigationItem))
            m_liChildren = value
        End Set
    End Property

    Public Sub New()

        ' Init Params
        ID = 0
        ParentID = 0
        ControlID = String.Empty
        Text = String.Empty
        Admin = False
        Archived = False

        ' Create Children
        Children = New List(Of ClassNavigationItem)

    End Sub

    Protected Overrides Sub Finalize()

        ' Clear Children
        Children.Clear()
        Children = Nothing

        MyBase.Finalize()

    End Sub

    Public Function Find(ByVal nParentID As Integer) As ClassNavigationItem

        ' Local Vars
        Dim CRetNavigationItem As ClassNavigationItem = Nothing

        ' Am I the Parent?
        If ID = nParentID Then

            ' Return Me
            Return Me

        Else

            ' Recursively Find
            For Each CNavigationItem In Children.ToArray

                ' Find the Result
                CRetNavigationItem = CNavigationItem.Find(nParentID)

                ' If this is not Nothing
                If Not CRetNavigationItem Is Nothing Then

                    ' Return the Child
                    Return CRetNavigationItem

                End If

            Next

        End If

        ' Return the Result
        Return CRetNavigationItem

    End Function

    Public Function GetSQL(ByVal nParentID As Integer, ByRef nID As Integer, ByVal nSortOrder As Integer) As String

        ' Init SQL        
        Dim szSQL As String = String.Empty
        Dim nChildSortOrder As Integer = 0

        ' Increment ID
        nID += 1

        ' Reset IDs
        ID = nID
        ParentID = nParentID

        ' Form SQL for this Child
        szSQL &= "insert into NAVIGATION (id, control_id, text, parent_id, sort_order, admin, archived) values (" & _
            ID.ToString.Trim & ", " & _
            "'" & ControlID.Trim & "', " & _
            "'" & Text.Trim & "', " & _
            ParentID.ToString.Trim & ", " & _
            nSortOrder.ToString.Trim & ", " & _
            Convert.ToInt32(Admin).ToString.Trim & ", " & _
            Convert.ToInt32(Archived).ToString.Trim & ");"

        ' For each Child
        For Each CNavigationItem As ClassNavigationItem In Children

            ' Increment Sort
            nChildSortOrder += 1

            ' For each Child, get that SQL
            szSQL &= CNavigationItem.GetSQL(ID, nID, nChildSortOrder)

        Next

        ' Return the Result
        Return szSQL

    End Function

End Class
