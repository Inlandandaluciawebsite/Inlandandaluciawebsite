
Imports System.Data

Partial Class WebUserControlAdminLocationnw
    Inherits System.Web.UI.UserControl

    Public Event Dirty()

    Private m_bUpdatingByPostcode As Boolean
    Public Property UpdatingByPostcode() As Boolean
        Get
            Return m_bUpdatingByPostcode
        End Get
        Set(ByVal value As Boolean)
            m_bUpdatingByPostcode = value
        End Set
    End Property

    Private m_bAddAllOption As Boolean
    Public Property AddAllOption() As Boolean
        Get
            Return m_bAddAllOption
        End Get
        Set(ByVal value As Boolean)
            m_bAddAllOption = value
        End Set
    End Property

    Private m_bContainingPropertiesOnly As Boolean
    Public Property ContainingPropertiesOnly() As Boolean
        Get
            Return m_bContainingPropertiesOnly
        End Get
        Set(ByVal value As Boolean)
            m_bContainingPropertiesOnly = value
        End Set
    End Property

    Private m_alPostcodeIDExclusions As ArrayList
    Public Property PostcodeIDExclusions() As ArrayList
        Get
            Return m_alPostcodeIDExclusions
        End Get
        Set(ByVal value As ArrayList)
            m_alPostcodeIDExclusions = value
        End Set
    End Property

    Private m_nMustIncludePostcodeID As Integer
    Public Property MustIncludePostcodeID() As Integer
        Get
            Return m_nMustIncludePostcodeID
        End Get
        Set(ByVal value As Integer)
            m_nMustIncludePostcodeID = value
        End Set
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Init Flags
        ContainingPropertiesOnly = False
        UpdatingByPostcode = False
        MustIncludePostcodeID = 0

    End Sub

    Public Sub LoadCountries(Optional ByVal alPostcodeIDExclusions As ArrayList = Nothing)

        ' Re Init Postcode Table
        Session("AdminLocationPostcodeTable") = Nothing

        ' Assign Exclusions
        PostcodeIDExclusions = alPostcodeIDExclusions

        ' Populate Countries
        DropDownListCountry.DataSource = GetCountries()
        AssignFields(DropDownListCountry)
        DropDownListCountry.DataBind()

    End Sub

    Private Sub LoadPostcodeTable()

        If Session("AdminLocationPostcodeTable") Is Nothing Then

            ' Define Classe
            Dim CDataAccess = New ClassDataAccess

            ' If this is an Admin User
            If Convert.ToBoolean(Session("AdminUser")) Then

                ' Load Postcode Table (Hardcoded Language for now), no Restrictions
                Session("AdminLocationPostcodeTable") = CDataAccess.LoadPostcodeTable(1, ContainingPropertiesOnly, PostcodeIDExclusions)

            Else

                ' Load Postcode Table (Hardcoded Language for now) with Partner ID
                Session("AdminLocationPostcodeTable") = CDataAccess.LoadPostcodeTable(1, ContainingPropertiesOnly, PostcodeIDExclusions, Convert.ToInt32(Session("ContactPartnerID")), MustIncludePostcodeID)

            End If

            ' Tidy
            CDataAccess = Nothing

        End If

    End Sub

    Private Sub AssignFields(ByRef ddl As DropDownList)

        ' Assign ID and Text Fields
        ddl.DataValueField = "id"
        ddl.DataTextField = "text"

    End Sub

    Private Function RenameColumns(ByVal dtDataTable As DataTable) As DataTable

        ' Rename Columns
        dtDataTable.Columns(0).ColumnName = "id"
        dtDataTable.Columns(1).ColumnName = "text"

        ' Return the Result
        Return dtDataTable

    End Function

    Private Function GetPostcodes(ByVal nRegionID As Integer) As DataTable

        ' Load Postcode Table
        LoadPostcodeTable()

        ' Define a Data View
        Dim dv As New DataView(DirectCast(Session("AdminLocationPostcodeTable"), DataTable))

        ' Filter Results
        dv.RowFilter = "Region_ID = " & nRegionID.ToString.Trim

        ' Sort Results
        dv.Sort = "Postcode ASC"

        ' Return Results
        Return RenameColumns(dv.ToTable(True, "Postcode_ID", "Postcode"))

    End Function

    Private Function GetCountries() As DataTable

        ' Load Postcode Table
        LoadPostcodeTable()

        ' Return Result
        Return RenameColumns(DirectCast(Session("AdminLocationPostcodeTable"), DataTable).DefaultView.ToTable(True, "Country_ID", "Country_Name"))

    End Function

    Private Function GetRegions(ByVal nCountryID As Integer) As DataTable

        ' Load Postcode Table
        LoadPostcodeTable()

        ' Define a Data View
        Dim dv As New DataView(DirectCast(Session("AdminLocationPostcodeTable"), DataTable))

        ' Filter Results
        dv.RowFilter = "Country_ID = " & nCountryID.ToString.Trim

        ' Return Results
        Return RenameColumns(dv.ToTable(True, "Region_ID", "Region_Name"))

    End Function

    Private Function GetAreas(ByVal nRegionID As Integer) As DataTable

        ' Load Postcode Table
        LoadPostcodeTable()

        ' Define a Data View
        Dim dv As New DataView(DirectCast(Session("AdminLocationPostcodeTable"), DataTable))

        ' Filter Results
        dv.RowFilter = "Region_ID = " & nRegionID.ToString.Trim

        ' Return Results
        Return RenameColumns(dv.ToTable(True, "Area_ID", "Area_Name"))

    End Function

    Private Function GetSubAreas(ByVal nAreaID As Integer) As DataTable

        ' Load Postcode Table
        LoadPostcodeTable()

        ' Define a Data View
        Dim dv As New DataView(DirectCast(Session("AdminLocationPostcodeTable"), DataTable))

        ' Filter Results
        dv.RowFilter = "Area_ID = " & nAreaID.ToString.Trim

        ' Sort Results
        dv.Sort = "SubArea_ID ASC"

        ' Return Results
        Return RenameColumns(dv.ToTable(True, "SubArea_ID", "SubArea_Name"))

    End Function

    Private Function GetPostcode(ByVal nRegionID As Integer, ByVal nAreaID As Integer, ByVal nSubAreaID As Integer) As Integer

        ' Load Postcode Table
        LoadPostcodeTable()

        ' Define a Data View
        Dim dv As New DataView(DirectCast(Session("AdminLocationPostcodeTable"), DataTable))

        ' Filter Region
        dv.RowFilter = "Region_ID = " & nRegionID.ToString.Trim

        ' Filter Area
        dv.RowFilter &= " and Area_ID = " & nAreaID.ToString.Trim

        ' Filter Sub Area
        dv.RowFilter &= " and SubArea_ID = " & nSubAreaID.ToString.Trim

        ' Return Results
        Return Convert.ToInt32(dv.ToTable(True, "Postcode_ID").Rows(0).Item("Postcode_ID"))

    End Function

    Private Sub GetFromPostcode(ByVal nPostcodeID As Integer, ByRef nCountryID As Integer, ByRef nRegionID As Integer, ByRef nAreaID As Integer, ByRef nSubAreaID As Integer)

        ' Load Postcode Table
        LoadPostcodeTable()

        ' Define a Data View
        Dim dv As New DataView(DirectCast(Session("AdminLocationPostcodeTable"), DataTable))

        ' Apply Filter
        dv.RowFilter = "Postcode_ID = " & nPostcodeID.ToString.Trim

        ' Assign Results
        nCountryID = Convert.ToInt32(dv.ToTable.Rows(0).Item("Country_ID"))
        nRegionID = Convert.ToInt32(dv.ToTable.Rows(0).Item("Region_ID"))
        nAreaID = Convert.ToInt32(dv.ToTable.Rows(0).Item("Area_ID"))
        nSubAreaID = Convert.ToInt32(dv.ToTable.Rows(0).Item("SubArea_ID"))

    End Sub

    Private Sub FlushDDL(ByRef ddl As DropDownList)

        ddl.Items.Clear()
        ddl.SelectedValue = Nothing

    End Sub

    Protected Sub DropDownListCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListCountry.SelectedIndexChanged

        ' Assign to Region Drop Down
        FlushDDL(DropDownListRegion)
        DropDownListRegion.DataSource = GetRegions(Convert.ToInt32(DropDownListCountry.SelectedValue))
        AssignFields(DropDownListRegion)
        DropDownListRegion.DataBind()

        ' If we are Adding All
        If AddAllOption Then

            ' Insert Select Option
            DropDownListPostcode.Items.Insert(0, "-- Select --")

            ' Insert All Option
            DropDownListRegion.Items.Insert(0, "-- All --")

        End If

        ' Init Region Selection
        DropDownListRegion_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Protected Sub DropDownListRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListRegion.SelectedIndexChanged

        ' If we are not Updating by Postcode
        If Not UpdatingByPostcode And Not (AddAllOption And DropDownListRegion.SelectedIndex = 0) Then

            ' Populate Postcodes
            FlushDDL(DropDownListPostcode)
            DropDownListPostcode.DataSource = GetPostcodes(Convert.ToInt32(DropDownListRegion.SelectedValue))
            AssignFields(DropDownListPostcode)
            DropDownListPostcode.DataBind()

        End If

        ' If we are Inserting All and All is Selected
        If AddAllOption And DropDownListRegion.SelectedIndex = 0 Then

            ' Hide Area & SubArea Selection
            TableRowArea.Visible = False
            TableRowSubArea.Visible = False

            '' Reset to Select
            'DropDownListArea.SelectedIndex = 0

            '' If we have Items
            'If DropDownListSubArea.Items.Count > 0 Then
            '    DropDownListSubArea.SelectedIndex = 0
            'End If

            ' Reset Postcode
            DropDownListPostcode.SelectedIndex = 0

        Else

            ' Show Area Selection
            TableRowArea.Visible = True

            ' Assign to Area Drop Down
            FlushDDL(DropDownListArea)
            DropDownListArea.DataSource = GetAreas(Convert.ToInt32(DropDownListRegion.SelectedValue))
            AssignFields(DropDownListArea)
            DropDownListArea.DataBind()

            ' If we are Adding All
            If AddAllOption Then

                ' Insert All Option
                DropDownListArea.Items.Insert(0, "-- All --")

            End If

            ' Init Area Selection
            DropDownListArea.SelectedIndex = 0
            DropDownListArea_SelectedIndexChanged(Nothing, Nothing)

        End If

        ' Dirty Parent
        RaiseEvent Dirty()

    End Sub

    Protected Sub DropDownListArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListArea.SelectedIndexChanged

        ' If we are Inserting All and All is Selected
        If AddAllOption And DropDownListArea.SelectedIndex = 0 Then

            ' Hide SubArea Selection
            TableRowSubArea.Visible = False

            ' Reset to Select
            DropDownListSubArea.SelectedIndex = -1

            ' If not Updating by Postcode
            If Not UpdatingByPostcode Then

                ' Reset Postcode
                DropDownListPostcode.SelectedIndex = 0

            End If

        Else

            ' Assign to Area Drop Down
            FlushDDL(DropDownListSubArea)
            DropDownListSubArea.DataSource = GetSubAreas(Convert.ToInt32(DropDownListArea.SelectedValue))
            AssignFields(DropDownListSubArea)
            DropDownListSubArea.DataBind()

            ' Init SubArea Selection
            DropDownListSubArea_SelectedIndexChanged(Nothing, Nothing)

            ' Show / Hide SubArea Selection
            TableRowSubArea.Visible = DropDownListSubArea.Items.Count > 1

        End If

        ' Dirty Parent
        RaiseEvent Dirty()

    End Sub

    Protected Sub DropDownListSubArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListSubArea.SelectedIndexChanged

        ' If we are not Updting by Postcode
        If Not UpdatingByPostcode Then

            ' Select Postcode
            DropDownListPostcode.SelectedValue = GetPostcode(Convert.ToInt32(DropDownListRegion.SelectedValue), Convert.ToInt32(DropDownListArea.SelectedValue), Convert.ToInt32(DropDownListSubArea.SelectedValue)).ToString.Trim

        End If

        ' Dirty Parent
        RaiseEvent Dirty()

    End Sub

    Protected Sub DropDownListPostcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPostcode.SelectedIndexChanged

        ' Local Vars
        Dim nCountryID As Integer
        Dim nRegionID As Integer
        Dim nAreaID As Integer
        Dim nSubAreaID As Integer

        ' If we have Selected Enable All and the Select Option has been Chosen, Reload
        If AddAllOption And DropDownListPostcode.SelectedIndex = 0 Then

            ' Init Country Selection
            DropDownListCountry_SelectedIndexChanged(Nothing, Nothing)

        Else

            ' Get IDs based upon Postcode Selected
            GetFromPostcode(Convert.ToInt32(DropDownListPostcode.SelectedValue), nCountryID, nRegionID, nAreaID, nSubAreaID)

            ' Set Flag
            UpdatingByPostcode = True

            ' Selecting Values
            DropDownListRegion.SelectedValue = nRegionID
            DropDownListRegion_SelectedIndexChanged(Nothing, Nothing)
            DropDownListArea.SelectedValue = nAreaID
            DropDownListArea_SelectedIndexChanged(Nothing, Nothing)
            DropDownListSubArea.SelectedValue = nSubAreaID

            ' Reset Flag
            UpdatingByPostcode = False

        End If

        ' Dirty Parent
        RaiseEvent Dirty()

    End Sub

    Private Function GetDDLValue(ByVal ddl As DropDownList) As Integer

        ' If we have a Value Selected
        If ddl.SelectedIndex = -1 Or (AddAllOption And ddl.SelectedIndex = 0) Then

            ' Return NULL
            Return 0

        Else

            ' Return Value
            Return Convert.ToInt32(ddl.SelectedValue)

        End If

    End Function

    Private Function GetDDLText(ByVal ddl As DropDownList) As String

        ' If we have a Value Selected
        If ddl.SelectedIndex = -1 Or (AddAllOption And ddl.SelectedIndex = 0) Then

            ' Return NULL
            Return String.Empty

        Else

            ' Return Value
            Return ddl.SelectedItem.ToString.Trim

        End If

    End Function

    Public Function CountryID() As Integer
        Return Convert.ToInt32(DropDownListCountry.SelectedValue)
    End Function

    Public Function CountryName() As String
        Return DropDownListCountry.SelectedItem.ToString.Trim
    End Function

    Public Function PostcodeID() As Integer
        Return GetDDLValue(DropDownListPostcode)
    End Function

    Public Function RegionID() As Integer
        Return GetDDLValue(DropDownListRegion)
    End Function

    Public Function RegionName() As String
        Return GetDDLText(DropDownListRegion)
    End Function

    Public Function AreaID() As Integer
        Return GetDDLValue(DropDownListArea)
    End Function

    Public Function AreaName() As String
        Return GetDDLText(DropDownListArea)
    End Function

    Public Function SubAreaID() As Integer
        Return GetDDLValue(DropDownListSubArea)
    End Function

    Public Function SubAreaName() As String
        Return GetDDLText(DropDownListSubArea)
    End Function

    Public Sub InitData(Optional ByVal nPostcodeID As Integer = 0)

        ' Re Init Postcode Table
        Session("AdminLocationPostcodeTable") = Nothing

        ' Load Countries
        LoadCountries()

        ' If we Received a Valid ID
        If nPostcodeID > 0 Then

            ' Local Vars
            Dim nCountryID As Integer
            Dim nRegionID As Integer
            Dim nAreaID As Integer
            Dim nSubAreaID As Integer

            ' Get the IDs
            GetFromPostcode(nPostcodeID, nCountryID, nRegionID, nAreaID, nSubAreaID)

            ' Initialise
            DropDownListCountry.SelectedValue = nCountryID
            DropDownListCountry_SelectedIndexChanged(Nothing, Nothing)
            DropDownListRegion.SelectedValue = nRegionID
            DropDownListRegion_SelectedIndexChanged(Nothing, Nothing)
            DropDownListPostcode.SelectedValue = nPostcodeID
            DropDownListPostcode_SelectedIndexChanged(Nothing, Nothing)

        Else

            ' Select to First in the List
            'If DropDownListCountry.Items.Count > 0 Then
            DropDownListCountry.SelectedIndex = 0
            DropDownListCountry_SelectedIndexChanged(Nothing, Nothing)
                DropDownListPostcode.SelectedIndex = 0
                DropDownListPostcode_SelectedIndexChanged(Nothing, Nothing)
            'End If


        End If

    End Sub

    Public Sub InitCountry(ByVal nCountryID As Integer)

        ' Check this Country Exists
        If Not DropDownListCountry.Items.FindByValue(nCountryID.ToString.Trim) Is Nothing Then

            ' Select this Country
            DropDownListCountry.SelectedValue = nCountryID

        Else

            ' Select the First in the List
            DropDownListCountry.SelectedIndex = 0

        End If

        ' Ring in the Changes
        DropDownListCountry_SelectedIndexChanged(Nothing, Nothing)

    End Sub

End Class
