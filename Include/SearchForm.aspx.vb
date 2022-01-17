Imports Microsoft.VisualBasic

Public Class SearchForm

    Inherits System.Web.UI.Page

    Private m_CDataAccess As ClassDataAccess
    Private Property DataAccess() As ClassDataAccess
        Get
            Return m_CDataAccess
        End Get
        Set(ByVal value As ClassDataAccess)
            m_CDataAccess = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Initialise Data Access
        DataAccess = New ClassDataAccess

        ' Check we are not in a Post Back Situation
        If Not Page.IsPostBack Then

            ' Load Regions
            LoadRegions()

            ' Load Areas
            Call DropDownListRegions_SelectedIndexChanged(Nothing, Nothing)

            ' Populate Prices
            PopulatePrices()

            ' Load Property Types
            LoadTypes()

            ' Populate Bedrooms
            PopulateBedrooms()

        End If

    End Sub

    Private Sub LoadRegions()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        DropDownListRegion.DataSource = CDataAccess.Regions
        DropDownListRegion.DataTextField = "text"
        DropDownListRegion.DataValueField = "id"
        DropDownListRegion.DataBind()

        ' Tidy
        CDataAccess = Nothing

    End Sub

    Private Sub PopulatePrices()

        DropDownListPriceFrom.Items.Add("75000 €")
        DropDownListPriceFrom.Items.Add("100000 €")
        DropDownListPriceFrom.Items.Add("125000 €")
        DropDownListPriceFrom.Items.Add("150000 €")
        DropDownListPriceFrom.Items.Add("200000 €")
        DropDownListPriceFrom.Items.Add("300000 €")
        DropDownListPriceFrom.Items.Add("500000 €")
        DropDownListPriceFrom.Items.Add("1000000 €")
        DropDownListPriceTo.Items.Add("100000 €")
        DropDownListPriceTo.Items.Add("125000 €")
        DropDownListPriceTo.Items.Add("150000 €")
        DropDownListPriceTo.Items.Add("200000 €")
        DropDownListPriceTo.Items.Add("300000 €")
        DropDownListPriceTo.Items.Add("500000 €")
        DropDownListPriceTo.Items.Add("1000000 €")
        DropDownListPriceTo.Items.Add("2000000 €")

    End Sub

    Private Sub LoadTypes()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        DropDownListType.DataSource = CDataAccess.PropertyTypes
        DropDownListType.DataTextField = "text"
        DropDownListType.DataValueField = "id"
        DropDownListType.DataBind()

        ' Tidy
        CDataAccess = Nothing

    End Sub

    Private Sub PopulateBedrooms()

        DropDownListBedrooms.Items.Add("1")
        DropDownListBedrooms.Items.Add("2")
        DropDownListBedrooms.Items.Add("3")
        DropDownListBedrooms.Items.Add("4")
        DropDownListBedrooms.Items.Add("5")
        DropDownListBedrooms.Items.Add("more than 5")

    End Sub

    Private Sub searchform_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        ' Tidy
        DataAccess = Nothing

    End Sub

    Protected Sub DropDownListRegions_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListRegion.SelectedIndexChanged

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        DropDownListArea.DataSource = CDataAccess.Areas(Convert.ToInt32(DropDownListRegion.SelectedItem.Value))
        DropDownListArea.DataTextField = "text"
        DropDownListArea.DataValueField = "id"
        DropDownListArea.DataBind()

        ' Tidy
        CDataAccess = Nothing

    End Sub

    Protected Sub DropDownListPriceFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListPriceFrom.SelectedIndexChanged

        ' Check to see the Prices are in the Correct Order
        If DropDownListPriceFrom.SelectedIndex > DropDownListPriceTo.SelectedIndex Then
            DropDownListPriceTo.SelectedIndex = DropDownListPriceFrom.SelectedIndex
        End If

    End Sub

    Protected Sub DropDownListPriceTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownListPriceTo.SelectedIndexChanged

        ' Check to see the Prices are in the Correct Order
        If DropDownListPriceFrom.SelectedIndex > DropDownListPriceTo.SelectedIndex Then
            DropDownListPriceFrom.SelectedIndex = DropDownListPriceTo.SelectedIndex
        End If

    End Sub

    Protected Sub SearchFilter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SearchFilter.Click

    End Sub

End Class
