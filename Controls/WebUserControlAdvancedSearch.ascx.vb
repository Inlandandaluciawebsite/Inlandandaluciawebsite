
Imports System.Data

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
    Protected Sub LinkButtonFeatures_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonFeatures.Click

        ' Toggle Features Visibility
        TableRowFeatures.Visible = Not TableRowFeatures.Visible
        bindfeatures()

    End Sub
    Private Sub bindfeatures()
        ' FEATURES
        Dim CDataAccess As New ClassDataAccess
        Dim nCount As Integer = 0
        Dim nColumnCount As Integer
        Dim nScratch As Integer
        ' Get the Features Available
        Dim dtDataTable As DataTable = CDataAccess.Features

        ' Get the Column Count
        nColumnCount = Math.Ceiling(dtDataTable.Rows.Count / 5)
        chkfeatures.DataSource = dtDataTable
        chkfeatures.DataTextField = "Text"

        chkfeatures.DataValueField = "ID"
        chkfeatures.DataBind()
        '' For each Row Returned
        'For Each dr As DataRow In dtDataTable.Rows

        '    ' Increment Counter
        '    nCount += 1

        '    ' Add a CheckBox
        '    Dim chkFeature As New CheckBox

        '    ' Add Feature
        '    chkFeature.ID = dr("id").ToString
        '    chkFeature.Text = dr("text").ToString.Trim

        '    ' Depending on the Column
        '    If nCount > 0 And nCount <= nColumnCount Then
        '        ColumnFeatures1.Controls.Add(chkFeature)
        '        ColumnFeatures1.Controls.Add(New LiteralControl("<br/>"))
        '    ElseIf nCount > nColumnCount And nCount <= (nColumnCount * 2) Then
        '        ColumnFeatures2.Controls.Add(chkFeature)
        '        ColumnFeatures2.Controls.Add(New LiteralControl("<br/>"))
        '    ElseIf nCount > (nColumnCount * 2) And nCount <= (nColumnCount * 3) Then
        '        ColumnFeatures3.Controls.Add(chkFeature)
        '        ColumnFeatures3.Controls.Add(New LiteralControl("<br/>"))
        '    ElseIf nCount > (nColumnCount * 3) And nCount <= (nColumnCount * 4) Then
        '        ColumnFeatures4.Controls.Add(chkFeature)
        '        ColumnFeatures4.Controls.Add(New LiteralControl("<br/>"))
        '    Else
        '        ColumnFeatures5.Controls.Add(chkFeature)
        '        ColumnFeatures5.Controls.Add(New LiteralControl("<br/>"))
        '    End If

        'Next

        ' Tidy
        CDataAccess = Nothing

        ' Add Minimum Bedrooms and Bathrooms
        For nScratch = 0 To 5
            'DropDownListMinBathrooms.Items.Add(nScratch)
            'DropDownListMinBedrooms.Items.Add(nScratch)
        Next

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Initialise Data Access
        DataAccess = New ClassDataAccess

        '' Bind Data
        'Page.DataBind()

        ' If this is not a Postback
        If Not IsPostBack Then
            bindfeatures()
            ' If we are not in Agent Mode
            If Session("ContactID") Is Nothing Then

                ' Add Header HTML
                Header.InnerHtml = "<h1>" & GetTranslation("Andalucia Property") & "</h1>" &
                                    "<p>" & GetTranslation("At Inland Andalucia we have country, rural, inland property ranging from fincas, villas, townhouses to apartments. We specialise in the areas of Antequera, Cordoba, Granada, Jaen, Malaga and Sevilla where, with us you will find your ideal inland property. If you do not find what you are looking for please") & " <a href=""contactus.aspx"" title=""contact us"">" & GetTranslation("contact us") & "</a>, " & GetTranslation("as we probably have it") & ".</p>" &
                                    "<p>&nbsp;</p>"

            Else

                ' Add Header HTML
                Header.InnerHtml = "<h1>" & GetTranslation("Welcome") & " " & Session("ContactName") & "</h1>" &
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
            DropDownListSubArea.DataSource = DataAccess.Areas(Convert.ToInt32(DropDownListRegion.SelectedValue))
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
        szURL &= ".aspx?" &
                        "page=1" &
                        "&regionid=" & GetID(DropDownListRegion, 0).ToString.Trim &
                        "&areaid=" & GetID(DropDownListArea, 0).ToString.Trim &
                        "&subareaid=" & GetID(DropDownListSubArea, 0).ToString.Trim &
                        "&typeid=" & GetID(DropDownListType, 0).ToString.Trim &
                        "&minimumbedrooms=" & (DropDownListBedrooms.SelectedIndex).ToString.Trim &
                        "&minimumbathrooms=" & (DropDownListBathrooms.SelectedIndex).ToString.Trim &
                        "&minimumprice=" & GetID(DropDownListPriceFrom, 0).ToString.Trim &
                        "&maximumprice=" & GetID(DropDownListPriceTo, DropDownListPriceTo.Items.Count - 1).ToString.Trim
        'If TableRowFeatures.Visible Then
        '    Dim myControl1 As Control = FindControl("ColumnFeatures1")
        '    ' Get Feature Selection from each Column
        '    szURL &= GetFeatureSelection("&Features1", myControl1)
        '    szURL &= GetFeatureSelection("&Feature2", ColumnFeatures2)
        '    szURL &= GetFeatureSelection("&Features3", ColumnFeatures3)
        '    szURL &= GetFeatureSelection("&Features4", ColumnFeatures4)

        'End If
        Dim sCheckedValue As String = ""
        Dim iscomma As String = ""
        Dim count As Integer = 0
        For Each oItem As ListItem In chkfeatures.Items
            If oItem.Selected Then

                If count = 0 Then
                    iscomma = ""
                Else
                    iscomma = ","
                End If

                sCheckedValue += iscomma + "" + oItem.Value + ""
                count =count+1
            End If
        Next

        szURL &= "&features=" + sCheckedValue
        ' If a Minimum Price has been Specified or no Maximum Price has been Specified
        If DropDownListPriceFrom.SelectedIndex > 0 Or (DropDownListPriceTo.SelectedIndex = (DropDownListPriceTo.Items.Count - 1)) Then

            ' Minimum Price Specified, Price Ascending
            szURL &= "&sort=price_asc"

        Else

            ' No Minimum Price Specified, Price Descending
            szURL &= "&sort=price_desc"

        End If


        szURL &= "&plotsize=" + txtminplotsize.Text
        ' Redirect to the Property Search Page
        Response.Redirect(szURL)

    End Sub
    Private Function GetFeatureSelection(ByVal szDelim As String, ByVal ctrlParent As Control) As String

        ' Local Vars
        Dim szRetVal As String = String.Empty
        Dim controles As New List(Of Control)()
        ' For each CheckBox in the Control
        For Each ctrl As Control In ctrlParent.Controls

            ' If this is a Checkbox
            If TypeOf (ctrl) Is CheckBox Then

                ' If this is Checked
                If DirectCast(ctrl, CheckBox).Checked Then

                    ' Apply Filter
                    szRetVal &= szDelim & "" & ctrl.ID.ToString.Trim & ""

                End If

            End If

        Next

        ' Return the Result
        Return szRetVal

    End Function
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

    Protected Sub btnFeaturedProperties_Click(sender As Object, e As EventArgs)
        Response.Redirect("AgentArea.aspx?page=1&regionid=0&areaid=0&subareaid=0&typeid=0&minimumbedrooms=0&minimumbathrooms=0&minimumprice=0&maximumprice=0&features=&sort=price_asc&plotsize=&IsFeatured=1")
    End Sub
End Class
