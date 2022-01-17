Partial Public Class WebUserControlSearchForm
    Inherits System.Web.UI.UserControl

    Public Custom Event SearchFilterClick As Web.UI.ImageClickEventHandler
        AddHandler(ByVal value As Web.UI.ImageClickEventHandler)
            AddHandler SearchFilter.Click, value
        End AddHandler

        RemoveHandler(ByVal value As Web.UI.ImageClickEventHandler)
            RemoveHandler SearchFilter.Click, value
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        End RaiseEvent
    End Event

    Public Custom Event SearchReferenceClick As Web.UI.ImageClickEventHandler
        AddHandler(ByVal value As Web.UI.ImageClickEventHandler)
            AddHandler SearchReference.Click, value
        End AddHandler

        RemoveHandler(ByVal value As Web.UI.ImageClickEventHandler)
            RemoveHandler SearchReference.Click, value
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        End RaiseEvent
    End Event

    Private m_CDataAccess As ClassDataAccess
    Private Property DataAccess() As ClassDataAccess
        Get
            Return m_CDataAccess
        End Get
        Set(ByVal value As ClassDataAccess)
            m_CDataAccess = value
        End Set
    End Property

    Private Sub LoadRegions()

        DropDownListRegion.DataSource = DataAccess.Regions
        DropDownListRegion.DataTextField = "text"
        DropDownListRegion.DataValueField = "id"
        DropDownListRegion.DataBind()
        DropDownListRegion.Items.Insert(0, GetTranslation("All"))

    End Sub

    Private Sub PopulatePrices()

        ' Local Vars
        Dim CUtilities As New ClassUtilities

        DropDownListPriceTo.DataSource = DataAccess.PriceTo(CUtilities.GetLanguageID(Session("Language")))
        DropDownListPriceTo.DataTextField = "text"
        DropDownListPriceTo.DataValueField = "id"
        DropDownListPriceTo.DataBind()
        DropDownListPriceTo.Items.Add(GetTranslation("Any"))

        DropDownListPriceTo.SelectedIndex = DropDownListPriceTo.Items.Count - 1

        ' Tidy
        CUtilities = Nothing

    End Sub

    Private Sub LoadTypes()

        ' Local Vars
        Dim CUtilities As New ClassUtilities

        DropDownListType.DataSource = DataAccess.PropertyTypes(CUtilities.GetLanguageID(Session("Language")))
        DropDownListType.DataTextField = "text"
        DropDownListType.DataValueField = "id"
        DropDownListType.DataBind()
        DropDownListType.Items.Insert(0, GetTranslation("All"))

        ' Tidy
        CUtilities = Nothing

    End Sub

    Private Sub PopulateBedrooms()

        Dim szScratch As String = GetTranslation("or more")

        DropDownListBedrooms.Items.Add(GetTranslation("Any"))
        DropDownListBedrooms.Items.Add("1 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("2 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("3 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("4 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("5 " & szScratch.Trim)

    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Initialise Data Access
        DataAccess = New ClassDataAccess

        ' Bind Data
        Page.DataBind()

        If Not Page.IsPostBack Then

            ' Load Regions
            LoadRegions()

            ' Populate Prices
            PopulatePrices()

            ' Load Property Types
            LoadTypes()

            ' Populate Bedrooms
            PopulateBedrooms()

            ' Enter Key Search
            TextBoxReference.Attributes.Add("onkeypress", "return clickButton(event,'" + SearchReference.ClientID + "')")

        End If

    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        ' Tidy
        DataAccess = Nothing

    End Sub

    Private Function GetID(ByVal ddl As DropDownList, Optional ByVal nAllIndex As Integer = -1) As Integer

        ' Check that the DropDownList Contains at Least 1 Item
        If ddl.Items.Count > 0 Then

            ' If All Option (or None)
            If ddl.SelectedIndex = nAllIndex Then

                ' Set to Any
                GetID = 0

            Else

                ' Set to Selected
                GetID = ddl.SelectedValue

            End If

        Else

            ' Set to Any
            GetID = 0

        End If

    End Function

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub SearchFilter_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles SearchFilter.Click

        ' Local Vars
        Dim szURL As String = "propsearch.aspx?page=1&regionid=" & GetID(DropDownListRegion, 0).ToString.Trim & "&typeid=" & GetID(DropDownListType, 0).ToString.Trim & "&minimumbedrooms=" & (DropDownListBedrooms.SelectedIndex).ToString.Trim & "&maximumprice=" & GetID(DropDownListPriceTo, DropDownListPriceTo.Items.Count - 1).ToString.Trim

        ' If no Maximum Price has been Specified
        If DropDownListPriceTo.SelectedIndex = (DropDownListPriceTo.Items.Count - 1) Then

            ' No Maximum Price has been Specified so Order Results in Price Ascending Order
            szURL &= "&sort=price_asc"

        Else

            ' Maximum Price has been Specified so Order Results in Price Descending Order
            szURL &= "&sort=price_desc"

        End If

        ' Redirect to the Property Search Page
        Response.Redirect(szURL)

    End Sub

    Protected Sub SearchReference_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles SearchReference.Click

        ' Local Vars
        Dim nPropertyID As Integer

        ' Check that the User has Entered a Reference
        If TextBoxReference.Text.Trim = String.Empty Then

            ' They Probably meant to hit the Search by Criteria
            SearchFilter_Click(Nothing, Nothing)

        Else

            ' Saving the Property ID
            nPropertyID = DataAccess.PropertyID(TextBoxReference.Text)

           

            ' Redirect to the Property Search Page
            'Response.Redirect("propsearch.aspx?propertyref=" & nPropertyID.ToString.Trim)
            Response.Redirect("propsearch.aspx?propertyref=" & TextBoxReference.Text.Trim)

            ' Clear Search Box
            TextBoxReference.Text = String.Empty

        End If

    End Sub

    Public Function GetImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/Images/Buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "buscar.png"

            Case 3
                ' French
                szRetVal &= "recherche.png"

            Case 4
                ' German
                szRetVal &= "suche.png"

            Case 5
                ' Dutch
                szRetVal &= "search-nl.png"

            Case Else
                ' English
                szRetVal &= "search.png"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

End Class