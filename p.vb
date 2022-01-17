
Partial Class PropertySearch
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

        If Not Page.IsPostBack Then

            ' Load Regions
            LoadRegions()

            ' Populate Prices
            PopulatePrices()

            ' Load Property Types
            LoadTypes()

            ' Populate Bedrooms
            PopulateBedsAndBaths()

            ' Disable Area and Sub Area Options
            DropDownListArea.Enabled = False
            DropDownListSubArea.Enabled = False

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        ' Tidy
        DataAccess = Nothing

    End Sub

    Private Sub LoadRegions()

        DropDownListRegion.DataSource = DataAccess.Regions
        DropDownListRegion.DataTextField = "text"
        DropDownListRegion.DataValueField = "id"
        DropDownListRegion.DataBind()

        ' Add All Option
        DropDownListRegion.Items.Insert(0, "All")

        ' Disable Area and SubArea
        DropDownListArea.Enabled = False
        DropDownListSubArea.Enabled = False

    End Sub

    Private Sub PopulatePrices()

        DropDownListPriceFrom.DataSource = DataAccess.PriceToValuesOnly
        DropDownListPriceFrom.DataTextField = "text"
        DropDownListPriceFrom.DataValueField = "id"
        DropDownListPriceFrom.DataBind()

        ' Remove the Last Options
        DropDownListPriceFrom.Items.RemoveAt(DropDownListPriceFrom.Items.Count - 1)
        DropDownListPriceFrom.Items.RemoveAt(DropDownListPriceFrom.Items.Count - 1)

        DropDownListPriceTo.DataSource = DataAccess.PriceToValuesOnly
        DropDownListPriceTo.DataTextField = "text"
        DropDownListPriceTo.DataValueField = "id"
        DropDownListPriceTo.DataBind()

        ' Remove the First and Last Options
        DropDownListPriceTo.Items.RemoveAt(0)
        DropDownListPriceTo.Items.RemoveAt(DropDownListPriceTo.Items.Count - 1)

        ' Add All Option
        DropDownListPriceTo.Items.Add("Unlimited")

        ' Init to Unlimited
        DropDownListPriceTo.SelectedIndex = DropDownListPriceTo.Items.Count - 1

    End Sub

    Private Sub LoadTypes()

        DropDownListType.DataSource = DataAccess.PropertyTypes
        DropDownListType.DataTextField = "text"
        DropDownListType.DataValueField = "id"
        DropDownListType.DataBind()
        DropDownListType.Items.Insert(0, "All")

    End Sub

    Private Sub PopulateBedsAndBaths()

        DropDownListBedrooms.Items.Add("1 or more")
        DropDownListBedrooms.Items.Add("2 or more")
        DropDownListBedrooms.Items.Add("3 or more")
        DropDownListBedrooms.Items.Add("4 or more")
        DropDownListBedrooms.Items.Add("5 or more")

        DropDownListBathrooms.Items.Add("1 or more")
        DropDownListBathrooms.Items.Add("2 or more")
        DropDownListBathrooms.Items.Add("3 or more")
        DropDownListBathrooms.Items.Add("4 or more")
        DropDownListBathrooms.Items.Add("5 or more")

    End Sub

    Protected Sub DropDownListRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListRegion.SelectedIndexChanged

        ' If the User has Selected a Region
        If DropDownListRegion.SelectedIndex > 0 Then

            ' Populate the Areas within the Region

            ' Clear Existing
            DropDownListArea.Items.Clear()

            ' Get the Areas in this Region
            DropDownListArea.DataSource = DataAccess.Areas(DropDownListRegion.SelectedValue)
            DropDownListArea.DataTextField = "text"
            DropDownListArea.DataValueField = "id"
            DropDownListArea.DataBind()

            ' Add All Option
            DropDownListArea.Items.Insert(0, "All")

            ' Enable Area
            DropDownListArea.Enabled = True

            ' Disable Sub Area
            DropDownListSubArea.Enabled = False

        Else

            ' User Selected ALL Disable Area and SubArea
            DropDownListArea.Enabled = False
            DropDownListSubArea.Enabled = False

        End If

    End Sub

    Protected Sub DropDownListArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListArea.SelectedIndexChanged

        ' If the User has Selected an Area
        If DropDownListArea.SelectedIndex > 0 Then

            ' Populate the Sub Areas within the Area

            ' Clear Existing
            DropDownListSubArea.Items.Clear()

            ' Get the Areas in this Region
            DropDownListSubArea.DataSource = DataAccess.SubAreas(DropDownListArea.SelectedValue)
            DropDownListSubArea.DataTextField = "text"
            DropDownListSubArea.DataValueField = "id"
            DropDownListSubArea.DataBind()

            ' If we have Results
            If DropDownListSubArea.Items.Count > 0 Then

                ' Add All Option
                DropDownListSubArea.Items.Insert(0, "All")

                ' Enable Area
                DropDownListSubArea.Enabled = True

            Else

                ' None Available - Disable
                DropDownListSubArea.Enabled = False

            End If

        Else

            ' User Selected ALL Disable SubArea            
            DropDownListSubArea.Enabled = False

        End If

    End Sub

    Protected Sub DropDownListPriceFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPriceFrom.SelectedIndexChanged

        ' Ensure Ranges are not Negative
        If DropDownListPriceFrom.SelectedIndex > DropDownListPriceTo.SelectedIndex Then
            DropDownListPriceTo.SelectedIndex = DropDownListPriceFrom.SelectedIndex
        End If

    End Sub

    Protected Sub DropDownListPriceTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPriceTo.SelectedIndexChanged

        ' Ensure Ranges are not Negative
        If DropDownListPriceFrom.SelectedIndex > DropDownListPriceTo.SelectedIndex Then
            DropDownListPriceFrom.SelectedIndex = DropDownListPriceTo.SelectedIndex
        End If

    End Sub
End Class
