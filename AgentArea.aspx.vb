
Partial Class AgentArea
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Load the Button Images
        ImageButtonBack.ImageUrl = GetBackImagePath()
        ImageButtonSignOut.ImageUrl = GetSignOutImagePath()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        ' Local Vars
        Dim ctrl As Control = Nothing

        ' If we are not in Agent Mode
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("AgentLogin.aspx")

        Else

            ' Reassert Session to Maintain
            Session("ContactID") = Session("ContactID")

        End If

        ' Set the Mode
        Session("SearchMode") = "AgentArea"

        ' Depending on the Postback
        If Not Request.QueryString("page") Is Nothing Then

            ' User Viewing Results

            ' Set Page Number
            Session("PageNumber") = Request.QueryString("page")

            ' If a Region has been Provided
            If Not Request.QueryString("regionid") Is Nothing Then
                Session("RegionID") = Request.QueryString("regionid")
            Else
                Session("RegionID") = 0
            End If

            ' If an Area has been Provided
            If Not Request.QueryString("areaid") Is Nothing Then
                Session("AreaID") = Request.QueryString("areaid")
            Else
                Session("AreaID") = 0
            End If

            ' If a SubArea has been Provided
            If Not Request.QueryString("subareaid") Is Nothing Then
                Session("SubAreaID") = Request.QueryString("subareaid")
            Else
                Session("SubAreaID") = 0
            End If

            ' If a Type has been Provided
            If Not Request.QueryString("typeid") Is Nothing Then
                Session("TypeID") = Request.QueryString("typeid")
            Else
                Session("TypeID") = 0
            End If

            ' If Minimum Bedrooms has been Provided
            If Not Request.QueryString("minimumbedrooms") Is Nothing Then
                Session("MinimumBedrooms") = Request.QueryString("minimumbedrooms")
            Else
                Session("MinimumBedrooms") = 0
            End If

            ' If Minimum Bathrooms has been Provided
            If Not Request.QueryString("minimumbathrooms") Is Nothing Then
                Session("MinimumBathrooms") = Request.QueryString("minimumbathrooms")
            Else
                Session("MinimumBathrooms") = 0
            End If

            ' If Minimum Price has been Provided
            If Not Request.QueryString("minimumprice") Is Nothing Then
                Session("MinimumPrice") = Request.QueryString("minimumprice")
            Else
                Session("MinimumPrice") = 0
            End If

            ' If Maximum Price has been Provided
            If Not Request.QueryString("maximumprice") Is Nothing Then
                Session("MaximumPrice") = Request.QueryString("maximumprice")
            Else
                Session("MaximumPrice") = 0
            End If
            If Not Request.QueryString("features") Is Nothing Then
                Session("features") = Request.QueryString("features")
            Else
                Session("features") = ""
            End If
            If Not Request.QueryString("plotsize") Is "" Then
                Session("plotsize") = Request.QueryString("plotsize")
            Else
                Session("plotsize") = 0
            End If

            ' Use Detailed Search
            Session("DetailedSearch") = 1

            ' Set to Price Ascending
            Session("SortOrder") = ClassDataAccess.E_Sort_Order.PriceAscending

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' If the Query Contains Results
            If CDataAccess.SearchHasResultsNew(Convert.ToInt32(Session("RegionID")),
                                           Convert.ToInt32(Session("AreaID")),
                                           Convert.ToInt32(Session("SubAreaID")),
                                           Convert.ToInt32(Session("TypeID")),
                                           Convert.ToInt32(Session("MinimumBedrooms")),
                                           Convert.ToInt32(Session("MinimumBathrooms")),
                                           Convert.ToInt32(Session("MinimumPrice")),
                                           Convert.ToInt32(Session("MaximimPrice")),
                                              Convert.ToString(Session("features")),
                                                  Convert.ToString(Session("plotsize"))
                                           ) Then



                ' Set Session Mode
                Session("SearchMode") = "AgentArea"

                ' Define the Control
                ctrl = LoadControl("Controls/WebUserControlSearchResults.ascx")
                ctrl.ID = "SearchResults1"

            Else

                ' Define the Control
                ctrl = LoadControl("Controls/WebUserControlNoResults.ascx")
                ctrl.ID = "NoResults1"

            End If

            ' Tidy
            CDataAccess = Nothing

        ElseIf Not Request.QueryString("propertyid") Is Nothing Then

            ' User is Looking at Details of a Property

            ' Set the Property ID
            Session("ViewPropertyID") = Request.QueryString("propertyid")

            ' If no Entry was made
            If Session("ViewPropertyID") = 0 Then

                ' Define the Control
                ctrl = LoadControl("Controls/WebUserControlNoResults.ascx")
                ctrl.ID = "NoResults1"

            Else

                ' Define the Control
                ctrl = LoadControl("Controls/WebUserControlPropertyDetail.ascx")
                ctrl.ID = "PropertyDetail1"

            End If

        End If

        ' If we have a Control
        If Not ctrl Is Nothing Then

            ' Set the Mode
            Session("SearchMode") = "AgentArea"

            ' Clear Previous Controls
            UpdatePanelAgentArea.ContentTemplateContainer.Controls.Clear()

            ' Add Control to Update Panel
            UpdatePanelAgentArea.ContentTemplateContainer.Controls.Add(ctrl)

            ' Update Panel
            UpdatePanelAgentArea.Update()

        End If

    End Sub

    Protected Sub ImageButtonSignOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSignOut.Click

        ' Set to NULL
        Session("ContactID") = Nothing
        Session("ContactName") = Nothing
        Session("ContactType") = Nothing
        Session("ContactPartnerID") = Nothing

        ' Return to Hoempage
        Response.Redirect("/")

    End Sub

    Public Function GetBackImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "back-ES.gif"

            Case 3
                ' French
                szRetVal &= "back-FR.gif"

            Case 4
                ' German
                szRetVal &= "back-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "back-NL.gif"

            Case Else
                ' English
                szRetVal &= "back.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Private Function GetSignOutImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "~/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities
        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "sign-out-ES.gif"

            Case 3
                ' French
                szRetVal &= "sign-out-FR.gif"

            Case 4
                ' German
                szRetVal &= "sign-out-DE.gif"

            Case Else
                ' English
                szRetVal &= "sign-out.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

    Protected Sub ImageButtonBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonBack.Click

        ' Go back to Activity Selection
        Response.Redirect("~/AgentActivitySelection.aspx")

    End Sub

End Class
