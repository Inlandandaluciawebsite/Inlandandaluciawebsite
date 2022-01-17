Imports Microsoft.VisualBasic
Imports System.Data
Imports Obout.Ajax.UI.TreeView

Public Class ClassNavigation

    Private m_CNavigationItem As ClassNavigationItem
    Public Property NavigationItem() As ClassNavigationItem
        Get
            Return m_CNavigationItem
        End Get
        Set(ByVal value As ClassNavigationItem)
            m_CNavigationItem = value
        End Set
    End Property

    Public Sub LoadFromDB()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CParentNavigationItem As ClassNavigationItem
        Dim CChildNavigationItem As ClassNavigationItem

        ' Init Array
        NavigationItem = New ClassNavigationItem

        ' Load Navigation from DB
        Dim dtNavigation As DataTable = CDataAccess.Navigation

        ' Tidy
        CDataAccess = Nothing

        ' Set Root Item
        NavigationItem.ParentID = 0

        ' For each Record
        For Each dr As DataRow In dtNavigation.Rows

            ' Get the Parent Item
            CParentNavigationItem = NavigationItem.Find(Convert.ToInt32(dr("parent_id")))

            ' If this does Exists
            If Not CParentNavigationItem Is Nothing Then

                ' Create Child
                CChildNavigationItem = New ClassNavigationItem
                CChildNavigationItem.ID = Convert.ToInt32(dr("id"))
                CChildNavigationItem.ParentID = CParentNavigationItem.ID
                CChildNavigationItem.ControlID = dr("control_id")
                CChildNavigationItem.Text = dr("text")
                CChildNavigationItem.Admin = Convert.ToBoolean(dr("admin"))
                CChildNavigationItem.Archived = Convert.ToBoolean(dr("archived"))

                ' Add to Children
                CParentNavigationItem.Children.Add(CChildNavigationItem)

            End If

        Next

        ' Tidy
        dtNavigation.Clear()
        dtNavigation.Dispose()

    End Sub

    Private Sub LoadFromTreeView(ByVal tnRootNode As Node)

        ' Local Vars
        Dim CParentNavigationItem As ClassNavigationItem
        Dim CChildNavigationItem As ClassNavigationItem

        ' For each Node
        For Each tnNode As Node In tnRootNode.ChildNodes

            ' Get the Parent Item
            CParentNavigationItem = NavigationItem.Find(Convert.ToInt32(tnNode.Parent.ClientID))

            ' If this does Exists
            If Not CParentNavigationItem Is Nothing Then

                ' Create Child
                CChildNavigationItem = New ClassNavigationItem
                CChildNavigationItem.ID = Convert.ToInt32(tnNode.ClientID)
                CChildNavigationItem.ParentID = Convert.ToInt32(tnNode.Parent.ClientID)
                CChildNavigationItem.ControlID = tnNode.Value.Substring(0, tnNode.Value.IndexOf("|"))
                CChildNavigationItem.Text = tnNode.Text
                CChildNavigationItem.Admin = Convert.ToBoolean(Convert.ToInt32(tnNode.Value.Substring(tnNode.Value.IndexOf("|") + 1, 1)))
                CChildNavigationItem.Archived = Convert.ToBoolean(Convert.ToInt32(tnNode.Value.Substring(tnNode.Value.IndexOf("~") + 1, 1)))

                ' Add to Children
                CParentNavigationItem.Children.Add(CChildNavigationItem)

            End If

            ' Add Children Nodes
            LoadFromTreeView(tnNode)

        Next

    End Sub

    Private Sub AddChildren(ByVal CNavigationItem As ClassNavigationItem, ByRef tnNode As Node, Optional ByVal bAllowDragDrop As Boolean = False)

        ' For each Child
        For Each CChildNavigationItem As ClassNavigationItem In CNavigationItem.Children

            ' Create a New Node
            Dim tnChild As New Node(CChildNavigationItem.Text)

            ' Add the ID
            tnChild.ClientID = CChildNavigationItem.ID

            ' Set the Control ID
            tnChild.Value = CChildNavigationItem.ControlID & "|" & Convert.ToInt32(CChildNavigationItem.Admin).ToString.Trim & "~" & Convert.ToInt32(CChildNavigationItem.Archived).ToString.Trim

            ' Allow Drag / Drop
            tnChild.AllowDrag = bAllowDragDrop

            ' If Archived
            If CChildNavigationItem.Archived Then

                ' Make this Invisible
                tnChild.CssClass = "navigation-archived"

            End If

            ' Add to Parent
            tnNode.ChildNodes.Add(tnChild)

            ' Add Children
            AddChildren(CChildNavigationItem, tnChild, bAllowDragDrop)

        Next

    End Sub

    Public Function GetRootNode(Optional ByVal bAllowDragDrop As Boolean = False) As Node

        ' Reload to Reflect any Changes
        LoadFromDB()

        ' Add Root
        Dim tnNode As New Node("Root")

        ' Set ID of 0
        tnNode.ClientID = 0

        ' Enable Drag and Drop
        tnNode.AllowDrag = bAllowDragDrop

        ' Add Children
        AddChildren(NavigationItem, tnNode, bAllowDragDrop)

        ' Return Node
        Return tnNode

    End Function

    Public Sub LoadTreeView(ByRef tvNavigation As Tree, Optional ByVal bAllowDragDrop As Boolean = False)

        ' Add to Tree
        tvNavigation.Nodes.Add(GetRootNode(bAllowDragDrop))

    End Sub

    Public Sub New(Optional ByVal tnRootNode As Node = Nothing)

        ' If we are Loading from Existing Tree View
        If Not tnRootNode Is Nothing Then

            ' Init Array
            NavigationItem = New ClassNavigationItem

            ' Set Root Item
            NavigationItem.ParentID = 0

            ' Load from TreeView
            LoadFromTreeView(tnRootNode)

        End If

    End Sub

    Public Sub Save()

        ' Local Vars
        Dim nID As Integer = 0
        Dim nSortOrder As Integer = 0
        Dim szSQL As String = String.Empty

        ' Form SQL
        For Each CNavigationItem In NavigationItem.Children

            ' Increment Sort Order
            nSortOrder += 1

            ' Get the SQL
            szSQL &= CNavigationItem.GetSQL(0, nID, nSortOrder)

        Next

        ' Do we have SQL?
        If szSQL.Trim <> String.Empty Then

            ' Prefix Deletion
            szSQL = "delete from navigation;" & szSQL.Trim

            ' Run the Update
            Dim CDataAccess As New ClassDataAccess
            CDataAccess.Execute(szSQL)
            CDataAccess = Nothing

        End If

    End Sub

End Class
