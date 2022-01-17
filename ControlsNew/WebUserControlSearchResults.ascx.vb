Imports System.Data

Partial Class WebUserControlSearchResults
    Inherits System.Web.UI.UserControl

    Private m_nNumberOfPages As Integer
    Public Property NumberOfPages() As Integer
        Get
            Return m_nNumberOfPages
        End Get
        Set(ByVal value As Integer)
            m_nNumberOfPages = value
        End Set
    End Property

    Private m_htPageResults As Hashtable
    Public Property PageResults() As Hashtable
        Get
            Return m_htPageResults
        End Get
        Set(ByVal value As Hashtable)
            m_htPageResults = value
        End Set
    End Property

    Private m_nRegionID As Integer
    Public Property RegionID() As Integer
        Get
            Return m_nRegionID
        End Get
        Set(ByVal value As Integer)
            m_nRegionID = value
        End Set
    End Property

    Private m_nAreaID As Integer
    Public Property AreaID() As Integer
        Get
            Return m_nAreaID
        End Get
        Set(ByVal value As Integer)
            m_nAreaID = value
        End Set
    End Property

    Private m_nSubAreaID As Integer
    Public Property SubAreaID() As Integer
        Get
            Return m_nSubAreaID
        End Get
        Set(ByVal value As Integer)
            m_nSubAreaID = value
        End Set
    End Property

    Private m_nMinimumPrice As Integer
    Public Property MinimumPrice() As Integer
        Get
            Return m_nMinimumPrice
        End Get
        Set(ByVal value As Integer)
            m_nMinimumPrice = value
        End Set
    End Property

    Private m_nMaximumPrice As Integer
    Public Property MaximumPrice() As Integer
        Get
            Return m_nMaximumPrice
        End Get
        Set(ByVal value As Integer)
            m_nMaximumPrice = value
        End Set
    End Property

    Private m_nTypeID As Integer
    Public Property TypeID() As Integer
        Get
            Return m_nTypeID
        End Get
        Set(ByVal value As Integer)
            m_nTypeID = value
        End Set
    End Property

    Private m_nMinimumBedrooms As Integer
    Public Property MinimumBedrooms() As Integer
        Get
            Return m_nMinimumBedrooms
        End Get
        Set(ByVal value As Integer)
            m_nMinimumBedrooms = value
        End Set
    End Property

    Private m_nMinimumBathrooms As Integer
    Public Property MinimumBathrooms() As Integer
        Get
            Return m_nMinimumBathrooms
        End Get
        Set(ByVal value As Integer)
            m_nMinimumBathrooms = value
        End Set
    End Property

    Private m_eSortOrder As ClassDataAccess.E_Sort_Order
    Public Property SortOrder() As ClassDataAccess.E_Sort_Order
        Get
            Return m_eSortOrder
        End Get
        Set(ByVal value As ClassDataAccess.E_Sort_Order)
            m_eSortOrder = value
        End Set
    End Property

    Private m_nNumberOfResults As Integer
    Public Property NumberOfResults() As Integer
        Get
            Return m_nNumberOfResults
        End Get
        Set(ByVal value As Integer)
            m_nNumberOfResults = value
        End Set
    End Property

    Private m_szReference As String
    Private Property Reference As String
        Get
            Return m_szReference
        End Get
        Set(ByVal value As String)
            m_szReference = value
        End Set
    End Property

    Private Sub LoadResults()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CUtilities As New ClassUtilities
        Dim nRowCounter As Integer = 0
        Dim dtResults As DataTable
        Dim dtTable As DataTable

        ' Init Number of Results & Pages
        NumberOfResults = 0
        NumberOfPages = 0

        ' If we have a Partner ID
        If Session("ContactPartnerID") Is Nothing Then

            ' Not Logged in as a Partner
            dtResults = CDataAccess.SearchResults(CUtilities.GetLanguageID(Session("Language")),
                                                                   RegionID,
                                                                   AreaID,
                                                                   SubAreaID,
                                                                   Session("SearchMode") = "Top30",
                                                                   TypeID,
                                                                   MinimumBedrooms,
                                                                   MinimumBathrooms,
                                                                   MinimumPrice,
                                                                   MaximumPrice,
                                                                   SortOrder)

        Else

            ' Logged in as a Partner
            dtResults = CDataAccess.SearchResults(CUtilities.GetLanguageID(Session("Language")),
                                                                   RegionID,
                                                                   AreaID,
                                                                   SubAreaID,
                                                                   Session("SearchMode") = "Top30",
                                                                   TypeID,
                                                                   MinimumBedrooms,
                                                                   MinimumBathrooms,
                                                                   MinimumPrice,
                                                                   MaximumPrice,
                                                                   SortOrder,
                                                                   Convert.ToInt32(Session("ContactPartnerID")))

        End If

        ' Tidy
        CUtilities = Nothing

        ' Store the Number of Results
        NumberOfResults = dtResults.Rows.Count

        ' Set to Session Variable
        Session("NumberOfResults") = NumberOfResults

        ' If we have no Results
        If NumberOfResults > 0 Then

            ' Clone the Table
            dtTable = dtResults.Clone

            ' For each Row in the Table
            For Each dr As DataRow In dtResults.Rows

                ' Increment Row Counter
                nRowCounter += 1

                ' Add this Row to the Table
                dtTable.ImportRow(dr)

                ' If we have Added 10 to the Table
                If nRowCounter > 9 Then

                    ' Increment Number of Pages
                    NumberOfPages += 1

                    ' Add this Table to the Array
                    PageResults.Add(NumberOfPages, dtTable)

                    ' Reset Row Counter
                    nRowCounter = 0

                    ' Create a New Table
                    dtTable = dtResults.Clone

                End If

            Next

            ' If the Final Table Contained Results
            If dtTable.Rows.Count > 0 Then

                ' Increment Number of Pages
                NumberOfPages += 1

                ' Add this Table to the Array
                PageResults.Add(NumberOfPages, dtTable)

            End If

        End If

        ' Tidy
        dtResults.Dispose()
        CDataAccess = Nothing

    End Sub

    Private Sub LoadNavigation()

        ' Init
        NavigationTop.InnerHtml = String.Empty

        ' If we have at least 1 Result
        If NumberOfResults > 0 Then

            ' If we have more than 1 Page and we are on Page 2 or more
            If NumberOfPages > 1 And Session("PageNumber") > 1 Then

                ' Depending on the Mode
                Select Case Session("SearchMode")

                    Case "Top30"

                        ' Add the Back Option
                        NavigationTop.InnerHtml &= "<a href='Top30Properties.aspx?" & _
                                                    "page=" & (Convert.ToInt32(Session("PageNumber")) - 1).ToString.Trim & _
                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                    "&amp;areaid=" & AreaID.ToString.Trim & _
                                                    "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                    " '>&lt;Prev&gt;</a>&nbsp"

                    Case "AgentArea"

                        ' Add the Back Option
                        NavigationTop.InnerHtml &= "<a href='AgentArea.aspx?" & _
                                                    "page=" & (Convert.ToInt32(Session("PageNumber")) - 1).ToString.Trim & _
                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                    "&amp;areaid=" & AreaID.ToString.Trim & _
                                                    "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                    "&amp;typeid=" & TypeID.ToString.Trim & _
                                                    "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                    "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                    "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                    "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                    " '>&lt;Prev&gt;</a>&nbsp"

                    Case Else

                        ' Add the Back Option
                        NavigationTop.InnerHtml &= "<a href='propsearch.aspx?" & _
                                                    "page=" & (Convert.ToInt32(Session("PageNumber")) - 1).ToString.Trim & _
                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                    "&amp;areaid=" & AreaID.ToString.Trim & _
                                                    "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                    "&amp;typeid=" & TypeID.ToString.Trim & _
                                                    "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                    "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                    "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                    "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                    " '>&lt;Prev&gt;</a>&nbsp"

                End Select

            End If

            ' For each of the Pages
            For nPage As Integer = Math.Max(1, Session("PageNumber") - 5) To Math.Min(NumberOfPages, Math.Max(10, Session("PageNumber") + 5))

                ' If this is the Page Number we are on
                If nPage = Session("PageNumber") Then

                    ' Simply Add the Number
                    NavigationTop.InnerHtml &= nPage.ToString.Trim & "&nbsp"

                Else

                    ' Depending on the Mode
                    Select Case Session("SearchMode")

                        Case "Top30"

                            ' Add this Page as a Link
                            NavigationTop.InnerHtml &= "<a href='Top30Properties.aspx?" & _
                                                        "page=" & nPage.ToString.Trim & _
                                                        "&amp;regionid=" & RegionID.ToString.Trim & _
                                                        "&amp;areaid=" & AreaID.ToString.Trim & _
                                                        "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                        "'>" & nPage.ToString.Trim & "</a>&nbsp"

                        Case "AgentArea"

                            ' Add this Page as a Link
                            NavigationTop.InnerHtml &= "<a href='AgentArea.aspx?" & _
                                                        "page=" & nPage.ToString.Trim & _
                                                        "&amp;regionid=" & RegionID.ToString.Trim & _
                                                        "&amp;areaid=" & AreaID.ToString.Trim & _
                                                        "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                        "&amp;typeid=" & TypeID.ToString.Trim & _
                                                        "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                        "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                        "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                        "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                        "'>" & nPage.ToString.Trim & "</a>&nbsp"

                        Case Else

                            ' Add this Page as a Link
                            NavigationTop.InnerHtml &= "<a href='propsearch.aspx?" & _
                                                        "page=" & nPage.ToString.Trim & _
                                                        "&amp;regionid=" & RegionID.ToString.Trim & _
                                                        "&amp;areaid=" & AreaID.ToString.Trim & _
                                                        "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                        "&amp;typeid=" & TypeID.ToString.Trim & _
                                                        "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                        "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                        "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                        "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                        "'>" & nPage.ToString.Trim & "</a>&nbsp"

                    End Select

                End If

            Next

            ' If we have more than 1 Page and we are not on the last Page
            If NumberOfPages > 1 And Session("PageNumber") < NumberOfPages Then

                ' Depending on the Mode
                Select Case Session("SearchMode")

                    Case "Top30"

                        ' Add the Next Option
                        NavigationTop.InnerHtml &= "<a href='Top30Properties.aspx?" & _
                                                    "page=" & (Convert.ToInt32(Session("PageNumber")) + 1).ToString.Trim & _
                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                    "&amp;areaid=" & AreaID.ToString.Trim & _
                                                    "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                    "'>&lt;Next&gt;</a>&nbsp"

                    Case "AgentArea"

                        ' Add the Next Option
                        NavigationTop.InnerHtml &= "<a href='AgentArea.aspx?" & _
                                                    "page=" & (Convert.ToInt32(Session("PageNumber")) + 1).ToString.Trim & _
                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                    "&amp;areaid=" & AreaID.ToString.Trim & _
                                                    "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                    "&amp;typeid=" & TypeID.ToString.Trim & _
                                                    "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                    "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                    "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                    "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                    "'>&lt;Next&gt;</a>&nbsp"

                    Case Else

                        ' Add the Next Option
                        NavigationTop.InnerHtml &= "<a href='propsearch.aspx?" & _
                                                    "page=" & (Convert.ToInt32(Session("PageNumber")) + 1).ToString.Trim & _
                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                    "&amp;areaid=" & AreaID.ToString.Trim & _
                                                    "&amp;subareaid=" & SubAreaID.ToString.Trim & _
                                                    "&amp;typeid=" & TypeID.ToString.Trim & _
                                                    "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                    "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                    "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                    "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                    "'>&lt;Next&gt;</a>&nbsp"

                End Select

            End If

            ' Repeat for Lower Navigation
            NavigationBottom.InnerHtml = NavigationTop.InnerHtml

        End If

    End Sub

    Private Sub LoadFiltering()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable
        Dim szDelimter As String = String.Empty

        ' Init
        Filtering.InnerHtml = String.Empty

        ' If the User has Selected All Regions
        If RegionID = 0 Then

            ' Add Regions

            ' If Top 30 Mode
            If Session("SearchMode") = "Top30" Then

                ' Getting the List of Regions
                dtDataTable = CDataAccess.RegionsIncFeaturedPropertyCounts()

            Else

                ' Getting the List of Regions
                dtDataTable = CDataAccess.RegionsIncPropertyCounts(TypeID, MinimumBedrooms, MinimumBathrooms, MinimumPrice, MaximumPrice)

            End If

            ' For each Item in the Table
            For Each dr As DataRow In dtDataTable.Rows

                ' If this Region Contains Properties
                If Convert.ToInt32(dr("count")) > 0 Then

                    ' Depending on the Mode
                    Select Case Session("SearchMode")

                        Case "Top30"

                            ' Constructing the HTML
                            Filtering.InnerHtml &= szDelimter & "<a href='Top30Properties.aspx?page=1" & _
                                                                "&amp;regionid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                        Case "AgentArea"

                            ' Constructing the HTML
                            Filtering.InnerHtml &= szDelimter & "<a href='AgentArea.aspx?page=1" & _
                                                                "&amp;regionid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                "&amp;areaid=0" & _
                                                                "&amp;subareaid=0" & _
                                                                "&amp;typeid=" & TypeID.ToString.Trim & _
                                                                "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                                "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                                "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                                "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                                "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                        Case Else

                            ' Constructing the HTML
                            Filtering.InnerHtml &= szDelimter & "<a href='propsearch.aspx?page=1" & _
                                                                "&amp;regionid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                "&amp;areaid=0" & _
                                                                "&amp;subareaid=0" & _
                                                                "&amp;typeid=" & TypeID.ToString.Trim & _
                                                                "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                                "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                                "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                                "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                                "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                    End Select

                    ' Update Delimiter
                    szDelimter = " / "

                End If

            Next dr

        Else

            ' If the User has Selected All Areas
            If AreaID = 0 Then

                ' Add Areas

                ' If in Top 30 Mode
                If Session("SearchMode") = "Top30" Then

                    ' Getting the List of Areas
                    dtDataTable = CDataAccess.AreasIncFeaturedPropertyCounts(RegionID)

                Else

                    ' Getting the List of Areas
                    dtDataTable = CDataAccess.AreasIncPropertyCounts(RegionID, TypeID, MinimumBedrooms, MinimumBathrooms, MinimumPrice, MaximumPrice)

                End If

                ' For each Item in the Table
                For Each dr As DataRow In dtDataTable.Rows

                    ' If this Region Contains Properties
                    If Convert.ToInt32(dr("count")) > 0 Then

                        ' Depending on the Mode
                        Select Case Session("SearchMode")

                            Case "Top30"

                                ' Constructing the HTML
                                Filtering.InnerHtml &= szDelimter & "<a href='Top30Properties.aspx?page=1" & _
                                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                                    "&amp;areaid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                    "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                            Case "AgentArea"

                                ' Constructing the HTML
                                Filtering.InnerHtml &= szDelimter & "<a href='AgentArea.aspx?page=1" & _
                                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                                    "&amp;areaid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                    "&amp;subareaid=0" & _
                                                                    "&amp;typeid=" & TypeID.ToString.Trim & _
                                                                    "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                                    "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                                    "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                                    "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                                    "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                            Case Else

                                ' Constructing the HTML
                                Filtering.InnerHtml &= szDelimter & "<a href='propsearch.aspx?page=1" & _
                                                                    "&amp;regionid=" & RegionID.ToString.Trim & _
                                                                    "&amp;areaid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                    "&amp;subareaid=0" & _
                                                                    "&amp;typeid=" & TypeID.ToString.Trim & _
                                                                    "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                                    "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                                    "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                                    "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                                    "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                        End Select

                        ' Update Delimiter
                        szDelimter = " / "


                    End If

                Next dr

            ElseIf SubAreaID = 0 Then

                ' Add Sub Areas

                ' If in Top 30 Mode
                If Session("SearchMode") = "Top30" Then

                    ' Getting the List of Areas
                    dtDataTable = CDataAccess.SubAreasIncFeaturedPropertyCounts(RegionID, AreaID)

                Else

                    ' Getting the List of Areas
                    dtDataTable = CDataAccess.SubAreasIncPropertyCounts(RegionID, AreaID, TypeID, MinimumBedrooms, MinimumBathrooms, MinimumPrice, MaximumPrice)

                End If

                ' For each Item in the Table
                For Each dr As DataRow In dtDataTable.Rows

                    ' Depending on the Mode
                    Select Case Session("SearchMode")

                        Case "Top30"

                            ' Constructing the HTML
                            Filtering.InnerHtml &= szDelimter & "<a href='Top30Properties.aspx?page=1" & _
                                                                "&amp;regionid=" & RegionID.ToString.Trim & _
                                                                "&amp;areaid=" & AreaID.ToString.Trim & _
                                                                "&amp;subareaid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                        Case "AgentArea"

                            ' Constructing the HTML
                            Filtering.InnerHtml &= szDelimter & "<a href='AgentArea.aspx?page=1" & _
                                                                "&amp;regionid=" & RegionID.ToString.Trim & _
                                                                "&amp;areaid=" & AreaID.ToString.Trim & _
                                                                "&amp;subareaid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                "&amp;typeid=" & TypeID.ToString.Trim & _
                                                                "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                                "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                                "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                                "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                                "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                        Case Else

                            ' Constructing the HTML
                            Filtering.InnerHtml &= szDelimter & "<a href='propsearch.aspx?page=1" & _
                                                                "&amp;regionid=" & RegionID.ToString.Trim & _
                                                                "&amp;areaid=" & AreaID.ToString.Trim & _
                                                                "&amp;subareaid=" & (Convert.ToInt32(dr("id"))).ToString.Trim & _
                                                                "&amp;typeid=" & TypeID.ToString.Trim & _
                                                                "&amp;minimumbedrooms=" & MinimumBedrooms.ToString.Trim & _
                                                                "&amp;minimumbathrooms=" & MinimumBathrooms.ToString.Trim & _
                                                                "&amp;minimumprice=" & MinimumPrice.ToString.Trim & _
                                                                "&amp;maximumprice=" & MaximumPrice.ToString.Trim & _
                                                                "'>" & dr("text").ToString.Trim & " (" & Convert.ToInt32(dr("count")).ToString.Trim & ")</a>"

                    End Select

                    ' Update Delimiter
                    szDelimter = " / "

                Next dr

            End If

        End If

        ' Tidy
        CDataAccess = Nothing

    End Sub


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Init Region / Area / Sub Area for Filtering
        RegionID = 0
        AreaID = 0
        SubAreaID = 0

    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If we are in Normal Top 30 Mode
        If Session("SearchMode") = "None" Then

            ' Add the Header
            Header.InnerHtml = "<h1>Inland " & GetTranslation("Property List") & "</h1>"

        End If

        ' If we are not in Agent Area Mode
        If Session("SearchMode") <> "AgentArea" Then

            ' Add the Footer
            Footer.InnerHtml = "<p>" & GetTranslation("At") & " Inland Andalucia " & GetTranslation("we have country, rural, inland property ranging from fincas, villas, townhouses to apartments. We specialise in the areas of Antequera, Cordoba, Granada, Jaen, Malaga and Sevilla where, with us you will find your ideal inland property. If you do not find what you are looking for please") & " <a href=""contactus.aspx"">" & GetTranslation("contact us") & "</a>, " & GetTranslation("as we probably have it.") & "</p>"

            ' Add the New Search
            NewSearch.InnerHtml = "<a href=""propsearch.aspx""><img alt=""Click here to make a new search"" hspace=""5"" src=""" & GetNewSearchImagePath() & """ border=""0""/></a>"

        Else

            ' Add the New Search
            NewSearch.InnerHtml = "<a href=""AgentArea.aspx""><img alt=""Click here to make a new search"" hspace=""5"" src=""" & GetNewSearchImagePath() & """ border=""0""/></a>"

        End If

        ' Set IDs
        RegionID = Convert.ToInt32(Session("RegionID"))
        MaximumPrice = Convert.ToInt32(Session("MaximumPrice"))
        TypeID = Convert.ToInt32(Session("TypeID"))
        MinimumBedrooms = Convert.ToInt32(Session("MinimumBedrooms"))

        ' If this is a Detailed Search
        If Session("DetailedSearch") = 1 Then

            ' Set Remaining Variables
            AreaID = Convert.ToInt32(Session("AreaID"))
            SubAreaID = Convert.ToInt32(Session("SubAreaID"))
            MinimumBathrooms = Convert.ToInt32(Session("MinimumBathrooms"))
            MinimumPrice = Convert.ToInt32(Session("MinimumPrice"))

        End If

        ' If no Sort Order was Specified
        If Session("SortOrder") Is Nothing Then

            ' Default
            SortOrder = ClassDataAccess.E_Sort_Order.PriceDescending

        Else

            ' Use Sort Order Specified
            SortOrder = Convert.ToInt32(Session("SortOrder"))

        End If

        ' Init Array
        PageResults = New Hashtable

        ' Load Results
        LoadResults()

        ' If we have at Least 1 Result
        If NumberOfResults > 0 Then

            ' Define Navigation
            LoadNavigation()

            ' Define Region / Area / SubArea Filtering
            LoadFiltering()

            ' Populate Results
            GetProperties()

        End If

    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        ' If the Page Results were Defined
        If Not PageResults Is Nothing Then

            ' Tidy
            PageResults.Clear()
            PageResults = Nothing

        End If

    End Sub

    Public Function GetBackImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "images/buttons/"

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

    Public Sub GetProperties()

        ' If we have Results
        If NumberOfResults > 0 Then

            ' Local Vars
            Dim CPropertyOverview As Control

            ' For each Property
            For Each drRow In DirectCast(PageResults(Convert.ToInt32(Session("PageNumber"))), DataTable).Rows

                ' Init Vars
                'DirectCast(CPropertyOverview, WebUserControlPropertyOverview).InitPropertyDetails(drRow("property_id"), drRow("type"), drRow("reference"), drRow("region"), drRow("area"), drRow("subarea"), drRow("description"), drRow("bedrooms"), drRow("bathrooms"), drRow("sqm_built"), drRow("sqm_plot"), drRow("price"))

                ' Assign Session Variables
                Session("OverviewPropertyID") = drRow("property_id")
                Session("OverviewStatusID") = drRow("status_id")
                Session("OverviewType") = drRow("type")
                Session("OverviewReference") = drRow("reference")
                Session("OverviewPartnerReference") = drRow("partner_reference")
                Session("OverviewRegion") = drRow("region")
                Session("OverviewArea") = drRow("area")
                Session("OverviewSubArea") = drRow("subarea")
                Session("OverviewShortDescription") = drRow("short_description")
                Session("OverviewDescription") = drRow("description")
                Session("OverviewBedrooms") = drRow("bedrooms")
                Session("OverviewBathrooms") = drRow("bathrooms")
                Session("OverviewSQMBuilt") = drRow("sqm_built")
                Session("OverviewSQMPlot") = drRow("sqm_plot")
                Session("OverviewPrice") = drRow("price")
                Session("OverviewOriginalPrice") = drRow("original_price")

                ' Init Class
                CPropertyOverview = LoadControl("WebUserControlPropertyOverview.ascx")

                ' Add this to the Update Panel
                UpdatePanelDetails.ContentTemplateContainer.Controls.Add(CPropertyOverview)

            Next

        End If

    End Sub

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Public Function GetNewSearchImagePath() As String

        ' Init Return Var
        Dim szRetVal As String = "/images/buttons/"

        ' Depending on the Language
        Dim CUtilities As New ClassUtilities

        Select Case CUtilities.GetLanguageID(Session("Language"))

            Case 2
                ' Spanish
                szRetVal &= "new-search-ES.gif"

            Case 3
                ' French
                szRetVal &= "new-search-FR.gif"

            Case 4
                ' German
                szRetVal &= "new-search-DE.gif"

            Case 5
                ' Dutch
                szRetVal &= "new-search-NL.gif"

            Case Else
                ' English
                szRetVal &= "new-search.gif"

        End Select

        ' Tidy
        CUtilities = Nothing

        ' Return the Path
        Return szRetVal.Trim

    End Function

End Class