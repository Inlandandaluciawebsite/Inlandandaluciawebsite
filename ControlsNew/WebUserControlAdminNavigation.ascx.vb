Imports System.Data

Partial Class WebUserControlAdminNavigation
    Inherits System.Web.UI.UserControl

    Public Event AgentAdd()
    Public Event Agents()
    Public Event BrokerAdd()
    Public Event Brokers()
    Public Event BuyerAdd()
    Public Event Buyers()
    Public Event BuyerSource()
    Public Event BuyerStatus()
    Public Event ContactType()
    Public Event Controller()
    Public Event CustomContact(ByVal nContactTypeID As Integer)
    Public Event CustomContactAdd(ByVal nContactTypeID As Integer)
    Public Event DatabaseStatistics()
    Public Event FeaturedProperties()
    Public Event HistoryTypes()
    Public Event Languages()
    Public Event LatestProperties()
    Public Event Lawyers()
    Public Event LawyerAdd()
    Public Event MenuEditor()
    Public Event Partners()
    Public Event PartnerAdd()
    Public Event Password()
    Public Event PaymentTypes()
    Public Event Postcodes()
    Public Event Properties()
    Public Event PropertyAdd()
    Public Event PropertyFeatures()
    Public Event PropertyLocations()
    Public Event PropertyStatus()
    Public Event PropertyType()
    Public Event ReportClientTourMissingFeedback()
    Public Event Testimonials()
    Public Event TourAdd()
    Public Event Tours()
    Public Event Translations()
    Public Event UserAdd()
    Public Event Users()
    Public Event VendorAdd()
    Public Event Vendors()
    Public Event Views()

    Public Event Testing()

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        ' If the Navigation has not already been Loaded
        If Session("AdminNavigation") Is Nothing Then

            ' Load Navigation
            Dim CNavigation As New ClassNavigation
            CNavigation.LoadFromDB()

            ' Assign to Variable
            Session("AdminNavigation") = CNavigation

        End If

        ' Clear Current Control
        Controls.Clear()

        ' Append Start
        Dim ul As New HtmlGenericControl("ul")

        ' For each Item in the Array
        For Each CNavigationItem As ClassNavigationItem In DirectCast(Session("AdminNavigation"), ClassNavigation).NavigationItem.Children

            ' Build this Menu
            BuildMenu(ul, CNavigationItem)

        Next

        ' Add Menu
        Controls.Add(ul)

        ' If we have the Export Menu Item
        'If Not FindControl("LinkButtonExport") Is Nothing Then

        '    ' Add Postback Trigger for Export
        '    Dim sm As ScriptManager = ScriptManager.GetCurrent(Parent.Page)
        '    sm.RegisterPostBackControl(Me.FindControl("LinkButtonExport"))

        'End If

    End Sub

    Private Sub BuildMenu(ByRef ulParent As Control, ByVal CNavigationItem As ClassNavigationItem)

        ' If this is Not Archived, Non Admin or Admin and we are Admin
        If Not CNavigationItem.Archived And (Not CNavigationItem.Admin Or (CNavigationItem.Admin And Convert.ToBoolean(Session("AdminUser")))) Then

            ' Local Vars
            Dim li As New HtmlGenericControl("li")

            ' If this is Defined
            If Not CNavigationItem.Text Is Nothing Then

                ' Append Start
                Dim lb As New LinkButton
                lb.ID = CNavigationItem.ControlID.Trim
                lb.Text = CNavigationItem.Text.Trim

                ' Add Handler
                AddHandler lb.Click, AddressOf MenuClick

                ' Add thi
                ' If Not Session("ContactType") = "4" And Not (lb.Text = "LinkButtonMagazine") Then
                Dim count = 0
                If lb.Text = "LinkButtonMagazine" Then
                    If Not Session("ContactType") = "4" Then
                        count = 1
                    End If
                End If
                If Not count > 0 Then
                    li.Controls.Add(lb)
                End If
                count = 0
                ' End If


            End If

            ' If we have Children
            If CNavigationItem.Children.Count > 0 Then

                ' Append Start
                Dim ul As New HtmlGenericControl("ul")

                ' For each Child
                For Each CChildNavigationItem As ClassNavigationItem In CNavigationItem.Children.ToArray

                    ' Build Controls

                    BuildMenu(ul, CChildNavigationItem)

                Next

                ' If this is Defined
                If CNavigationItem.Text Is Nothing Then

                    ' Add to the Parent Control
                    ulParent.Controls.Add(ul)

                Else

                    ' Add to Controls
                    li.Controls.Add(ul)

                End If

            End If

            ' If this is Defined
            If Not CNavigationItem.Text Is Nothing Then

                ' Add this
                ulParent.Controls.Add(li)

            End If

        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' If the Session has Expired
        If Session("ContactID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If

    End Sub

    Public Sub Reload()

        ' Clear Cache
        Session("AdminNavigation") = Nothing

        ' Reload
        Call Page_Init(Nothing, Nothing)

    End Sub

    Private Sub MenuClick(sender As Object, e As EventArgs)

        ' Get the Client ID
        Dim szClientID As String = DirectCast(sender, Control).ClientID.Trim

        ' Depending on the Sender
        Select Case szClientID

            Case "AdminNavigation_LinkButtonVendors"
                RaiseEvent Vendors()

            Case "AdminNavigation_LinkButtonVendorAdd"
                RaiseEvent VendorAdd()

            Case "AdminNavigation_LinkButtonProperties"
                RaiseEvent Properties()

            Case "AdminNavigation_LinkButtonLatest"
                RaiseEvent LatestProperties()

            Case "AdminNavigation_LinkButtonFeatured"
                RaiseEvent FeaturedProperties()

            Case "AdminNavigation_LinkButtonPropertyAdd"
                RaiseEvent PropertyAdd()

            Case "AdminNavigation_LinkButtonBuyers"
                RaiseEvent Buyers()

            Case "AdminNavigation_LinkButtonTours"
                RaiseEvent Tours()

            Case "AdminNavigation_LinkButtonTourAdd"
                RaiseEvent TourAdd()

            Case "AdminNavigation_LinkButtonBuyerAdd"
                RaiseEvent BuyerAdd()

            Case "AdminNavigation_LinkButtonReportClientTourMissingFeedback"
                RaiseEvent ReportClientTourMissingFeedback()

            Case "AdminNavigation_LinkButtonPassword"
                RaiseEvent Password()

            Case "AdminNavigation_LinkButtonPTStatus"
                RaiseEvent PropertyStatus()

            Case "AdminNavigation_LinkButtonPTFeatures"
                RaiseEvent PropertyFeatures()

            Case "AdminNavigation_LinkButtonPTLocation"
                RaiseEvent PropertyLocations()

            Case "AdminNavigation_LinkButtonPTPostcode"
                RaiseEvent Postcodes()

            Case "AdminNavigation_LinkButtonPTType"
                RaiseEvent PropertyType()

            Case "AdminNavigation_LinkButtonPTViews"
                RaiseEvent Views()

            Case "AdminNavigation_LinkButtonSTAgents"
                RaiseEvent Agents()

            Case "AdminNavigation_LinkButtonSTAgentAdd"
                RaiseEvent AgentAdd()

            Case "AdminNavigation_LinkButtonSTBanks"
                ' TO DO 

            Case "AdminNavigation_LinkButtonSTBrokers"
                RaiseEvent Brokers()

            Case "AdminNavigation_LinkButtonSTBrokerAdd"
                RaiseEvent BrokerAdd()

            Case "AdminNavigation_LinkButtonSTBuyerSource"
                RaiseEvent BuyerSource()

            Case "AdminNavigation_LinkButtonSTBuyerStatus"
                RaiseEvent BuyerStatus()

            Case "AdminNavigation_LinkButtonSTLanguage"
                RaiseEvent Languages()

            Case "AdminNavigation_LinkButtonSTPartners"
                RaiseEvent Partners()

            Case "AdminNavigation_LinkButtonSTPartnerAdd"
                RaiseEvent PartnerAdd()

            Case "AdminNavigation_LinkButtonSTPaymentTypes"
                RaiseEvent PaymentTypes()

            Case "AdminNavigation_LinkButtonSTUsers"
                RaiseEvent Users()

            Case "AdminNavigation_LinkButtonSTUserAdd"
                RaiseEvent UserAdd()

            Case "AdminNavigation_LinkButtonSTContactType"
                RaiseEvent ContactType()

            Case "AdminNavigation_LinkButtonSTLanguage"
                ' TO DO

            Case "AdminNavigation_LinkButtonSTLawyers"
                RaiseEvent Lawyers()

            Case "AdminNavigation_LinkButtonSTLawyerAdd"
                RaiseEvent LawyerAdd()

            Case "AdminNavigation_LinkButtonSTPaymentTypes"
                ' TO DO 

            Case "AdminNavigation_LinkButtonSTFileStatus"
                RaiseEvent DatabaseStatistics()

            Case "AdminNavigation_LinkButtonSTHistoryTypes"
                RaiseEvent HistoryTypes()

            Case "AdminNavigation_LinkButtonSTTestimonials"
                RaiseEvent Testimonials()

            Case "AdminNavigation_LinkButtonSTTranslations"
                RaiseEvent Translations()

            Case "AdminNavigation_LinkButtonExport"
                Export()

            Case "AdminNavigation_LinkButtonMenuEditor"
                RaiseEvent MenuEditor()

            Case "AdminNavigation_LinkButtonDev"
                RaiseEvent Testing()
            Case "AdminNavigation_LinkButtonSalespersonTours"
                Response.Redirect("SalespersonTours.aspx")
            Case "AdminNavigation_LinkButtonActionAgenda"
                Response.Redirect("ActionAgenda.aspx")
            Case "AdminNavigation_LinkButtonNoVideos"
                Response.Redirect("NoVideos.aspx")

            Case "AdminNavigation_LinkButtonMagazine"
                Response.Redirect("OnlineMagazine.aspx")
            Case "AdminNavigation_LinkButtonMagazineAdd"
                Response.Redirect("OnlineMagazineAddEdit.aspx")
            Case Else
                ' Possible Custom Contact
                If szClientID.StartsWith("AdminNavigation_LinkButtonContactSearch") Then

                    ' Raise Search Event with the Contact ID
                    RaiseEvent CustomContact(Convert.ToInt32(szClientID.Substring(szClientID.IndexOf("#") + 1)))

                ElseIf szClientID.StartsWith("AdminNavigation_LinkButtonContactAdd") Then

                    ' Raise Search Event with the Contact ID
                    RaiseEvent CustomContactAdd(Convert.ToInt32(szClientID.Substring(szClientID.IndexOf("#") + 1)))

                End If

        End Select

    End Sub

    Private Sub Export()

        ' Local Vars
        Dim CUtilities As New ClassUtilities

        ' Export Data
        CUtilities.Export()

        ' Tidy
        CUtilities = Nothing

        ' A File
        Response.AppendHeader("Content-Disposition", "attachment; filename=Export.zip")
        Response.TransmitFile(AppDomain.CurrentDomain.GetData("DataDirectory") & "\Export\Export.zip")
        Response.End()

    End Sub

End Class
