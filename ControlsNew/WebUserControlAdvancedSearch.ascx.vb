
Partial Class WebUserControlAdvancedSearch
    Inherits System.Web.UI.UserControl

    Private m_CDataAccess As ClassDataAccess
    Private Property DataAccess() As ClassDataAccess
        Get
            Return m_CDataAccess
        End Get
        Set(ByVal value As ClassDataAccess)
            m_CDataAccess = value
        End Set
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Set Button Images
        SearchFilter.ImageUrl = GetImagePath()
        SearchReference.ImageUrl = GetImagePath()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Initialise Data Access
        DataAccess = New ClassDataAccess

        '' Bind Data
        'Page.DataBind()

        ' If this is not a Postback
        If Not IsPostBack Then

            ' If we are not in Agent Mode
            If Session("ContactID") Is Nothing Then

                ' Add Header HTML
                Header.InnerHtml = "<h1>" & GetTranslation("Andalucia Property") & "</h1>" & _
                                    "<p>" & GetTranslation("At Inland Andalucia we have country, rural, inland property ranging from fincas, villas, townhouses to apartments. We specialise in the areas of Antequera, Cordoba, Granada, Jaen, Malaga and Sevilla where, with us you will find your ideal inland property. If you do not find what you are looking for please") & " <a href=""contactus.aspx"" title=""contact us"">" & GetTranslation("contact us") & "</a>, " & GetTranslation("as we probably have it") & ".</p>" & _
                                    "<p>&nbsp;</p>"

            Else

                ' Add Header HTML
                Header.InnerHtml = "<h1>" & GetTranslation("Welcome") & " " & Session("ContactName") & "</h1>" & _
                                    "<p>&nbsp;</p>"

            End If

            ' Load Regions
            LoadRegions()

            ' Populate Prices
            PopulatePrices()

            ' Load Property Types
            LoadTypes()

            ' Populate Bedrooms
            PopulateBedsAndBaths()

            ' Enter Key Search
            TextBoxReference.Attributes.Add("onkeypress", "return clickButton(event,'" + SearchReference.ClientID + "')")

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
        DropDownListRegion.Items.Insert(0, GetTranslation("All"))

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

        ' Add All Options
        DropDownListPriceFrom.Items.Insert(0, GetTranslation("Any"))
        DropDownListPriceTo.Items.Add(GetTranslation("Any"))

        ' Init to Any
        DropDownListPriceTo.SelectedIndex = DropDownListPriceTo.Items.Count - 1

    End Sub

    Private Sub LoadTypes()

        Dim CUtilities As New ClassUtilities

        DropDownListType.DataSource = DataAccess.PropertyTypes(CUtilities.GetLanguageID(Session("Language")))
        DropDownListType.DataTextField = "text"
        DropDownListType.DataValueField = "id"
        DropDownListType.DataBind()
        DropDownListType.Items.Insert(0, GetTranslation("All"))

        CUtilities = Nothing

    End Sub

    Private Sub PopulateBedsAndBaths()

        Dim szScratch As String = GetTranslation("or more")

        DropDownListBedrooms.Items.Add(GetTranslation("Any"))
        DropDownListBedrooms.Items.Add("1 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("2 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("3 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("4 " & szScratch.Trim)
        DropDownListBedrooms.Items.Add("5 " & szScratch.Trim)

        DropDownListBathrooms.Items.Add(GetTranslation("Any"))
        DropDownListBathrooms.Items.Add("1 " & szScratch.Trim)
        DropDownListBathrooms.Items.Add("2 " & szScratch.Trim)
        DropDownListBathrooms.Items.Add("3 " & szScratch.Trim)
        DropDownListBathrooms.Items.Add("4 " & szScratch.Trim)
        DropDownListBathrooms.Items.Add("5 " & szScratch.Trim)

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
            DropDownListArea.Items.Insert(0, GetTranslation("All"))

            ' Make Visible
            TableCellTownLabel.Visible = True
            TableCellTown.Visible = True

        Else

            ' User Selected ALL Disable Area and SubArea
            DropDownListArea.Items.Clear()           

            ' Make Invisible
            TableCellTownLabel.Visible = False
            TableCellTown.Visible = False

        End If

        ' Make Villages Invisible
        TableCellVillageLabel.Visible = False
        TableCellVillage.Visible = False

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

            ' If we have more than 1 Result
            If DropDownListSubArea.Items.Count > 1 Then

                ' Add All Option
                DropDownListSubArea.Items.Insert(0, GetTranslation("All"))

                ' Make Visible
                TableCellVillageLabel.Visible = True
                TableCellVillage.Visible = True

            Else

                ' None Available - Hide
                TableCellVillageLabel.Visible = False
                TableCellVillage.Visible = False

            End If

        Else

            ' None Available - Hide
            TableCellVillageLabel.Visible = False
            TableCellVillage.Visible = False

        End If

    End Sub

    Protected Sub DropDownListPriceFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPriceFrom.SelectedIndexChanged

        ' Ensure Ranges are not Negative
        If DropDownListPriceFrom.SelectedIndex > DropDownListPriceTo.SelectedIndex Then
            DropDownListPriceTo.SelectedIndex = DropDownListPriceFrom.SelectedIndex - 1
        End If

    End Sub

    Protected Sub DropDownListPriceTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPriceTo.SelectedIndexChanged

        ' Ensure Ranges are not Negative
        If DropDownListPriceFrom.SelectedIndex > DropDownListPriceTo.SelectedIndex Then
            DropDownListPriceFrom.SelectedIndex = DropDownListPriceTo.SelectedIndex + 1
        End If

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

        Return DataAccess.GetTranslation(szText, Session("Language")).Trim

    End Function

    Protected Sub SearchFilter_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles SearchFilter.Click

        ' Local Vars
        Dim szURL As String = String.Empty

        ' If we are not in Agent Area Mode
        If Session("ContactID") Is Nothing Then
            szURL = "propsearch"
        Else
            szURL = "AgentArea"
        End If

        ' Continue to Init URL
        szURL &= ".aspx?" & _
                        "page=1" & _
                        "&regionid=" & GetID(DropDownListRegion, 0).ToString.Trim & _
                        "&areaid=" & GetID(DropDownListArea, 0).ToString.Trim & _
                        "&subareaid=" & GetID(DropDownListSubArea, 0).ToString.Trim & _
                        "&typeid=" & GetID(DropDownListType, 0).ToString.Trim & _
                        "&minimumbedrooms=" & (DropDownListBedrooms.SelectedIndex).ToString.Trim & _
                        "&minimumbathrooms=" & (DropDownListBathrooms.SelectedIndex).ToString.Trim & _
                        "&minimumprice=" & GetID(DropDownListPriceFrom, 0).ToString.Trim & _
                        "&maximumprice=" & GetID(DropDownListPriceTo, DropDownListPriceTo.Items.Count - 1).ToString.Trim

        ' If a Minimum Price has been Specified or no Maximum Price has been Specified
        If DropDownListPriceFrom.SelectedIndex > 0 Or (DropDownListPriceTo.SelectedIndex = (DropDownListPriceTo.Items.Count - 1)) Then

            ' Minimum Price Specified, Price Ascending
            szURL &= "&sort=price_asc"

        Else

            ' No Minimum Price Specified, Price Descending
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

            ' Are we Logged in as an Agent and have a Partner ID?
            If Session("ContactPartnerID") Is Nothing Then

                ' Saving the Property ID - IA
                nPropertyID = DataAccess.PropertyID(TextBoxReference.Text)

            Else

                ' Saving the Property ID - Partner
                nPropertyID = DataAccess.PropertyID(TextBoxReference.Text, Convert.ToInt32(Session("ContactPartnerID")))

            End If

            

            ' If we are in Agent Mode
            If Not Session("ContactID") Is Nothing Then

                ' Redirect to the Agent Area Page
                Response.Redirect("AgentArea.aspx?propertyid=" & nPropertyID.ToString.Trim)

            Else

                ' Redirect to the Property Search Page
                'Response.Redirect("propsearch.aspx?propertyid=" & nPropertyID.ToString.Trim)
                Response.Redirect("propsearch.aspx?propertyref=" & TextBoxReference.Text)

            End If
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
