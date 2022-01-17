Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.tool.xml

Partial Class WebUserControlAdminClientTourPrint
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Assing Header Image
        ImageIALogo.ImageUrl = "http://www.inlandandalucia.com/Images/Main/inlandandalucia.png"

        ' Assign Flags
        ImageBritishFlag.ImageUrl = "http://www.inlandandalucia.com/Images/Buttons/british_flag.jpg"
        ImageSpanishFlag.ImageUrl = "http://www.inlandandalucia.com/Images/Buttons/spanish_flag.jpg"

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If not a Postback
        If Not Page.IsPostBack Then

            ' Check we have a Tour ID to Open
            If Session("ClientTourID") Is Nothing Then

                ' Redirect to Login
                Response.Redirect("~/AgentLogin.aspx")

            Else

                ' Load the Tour
                LoadTour()

                ' Init Response
                Response.Clear()
                Response.Buffer = True
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "inline")
                Response.Cache.SetCacheability(HttpCacheability.NoCache)

                ' Output as PDF
                Dim sw As StringWriter = New StringWriter()
                Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
                Me.Page.RenderControl(hw)
                Dim sr As StringReader = New StringReader(sw.ToString())
                Dim document As New Document(New Rectangle(288.0F, 144.0F), 10, 10, 10, 10)
                document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate)
                Dim writer As PdfWriter = PdfWriter.GetInstance(document, Response.OutputStream)
                document.Open()
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr)
                document.Close()

                ' Tidy
                sw.Dispose()
                hw.Dispose()
                sr.Dispose()

                ' Return the Result
                Response.Write(document)
                Response.End()

            End If

        End If

    End Sub

    Private Sub UpdatePropertyDetails(ByVal nPropertyID As Integer, ByRef lblpatner As Label, ByRef lblName As Label, ByRef lblAddress As Label, ByRef lblTown As Label, ByRef lblContactNo As Label, ByRef lblPrice As Label, ByRef lblHour As Label, ByRef lblSeparator As Label, ByRef lblMinute As Label, ByRef lblKey As Label)

        ' Get the Property Details
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable = CDataAccess.ClientTourPropertyDetail(nPropertyID)
        CDataAccess = Nothing

        ' If we Loaded the Property
        If dtDataTable.Rows.Count > 0 Then

            ' Populate Form
            lblName.Text = Convert.ToString(dtDataTable.Rows(0).Item("Name"))
            lblAddress.Text = Convert.ToString(dtDataTable.Rows(0).Item("Address"))
            lblTown.Text = Convert.ToString(dtDataTable.Rows(0).Item("Town"))
            lblContactNo.Text = Convert.ToString(dtDataTable.Rows(0).Item("Telephone")) & " / " & Convert.ToString(dtDataTable.Rows(0).Item("Mobile"))
            lblpatner.Text = Convert.ToString(dtDataTable.Rows(0).Item("Reference"))
            ' Add the Price
            Dim CUtilities As New ClassUtilities
            lblPrice.Text = CUtilities.FormatPrice(Convert.ToInt32(dtDataTable.Rows(0).Item("Price")))
            CUtilities = Nothing

            ' Set Appointment
            lblHour.Visible = True
            lblSeparator.Visible = True
            lblMinute.Visible = True

            ' Assign Key
            lblKey.Text = dtDataTable.Rows(0).Item("Key")

        End If

        ' Tidy
        dtDataTable = Nothing

    End Sub

    Private Sub LoadPropertyViewing(ByVal CClientTourProperty As ClassClientTourProperty, ByRef lblRef As Label, ByRef lblHour As Label, ByRef lblMinute As Label)

        ' Selected Saved Variables
        lblRef.Text = CClientTourProperty.PropertyReference
        lblHour.Text = Format(CClientTourProperty.ViewingTime.Hour, "00")
        lblMinute.Text = Format(CClientTourProperty.ViewingTime.Minute, "00")

    End Sub

    Public Sub LoadTour()

        ' Local Vars
        Dim nPropertyCounter As Integer = 0

        ' Load the Tour
        Dim CDataAccess As New ClassDataAccess
        Dim CClientTour As ClassClientTour = CDataAccess.LoadClientTour(Convert.ToInt32(Session("ClientTourID")), Convert.ToInt32(Session("ContactPartnerID")))
        CDataAccess = Nothing

        ' Assign to the Form
        LabelViewingReference.Text = CClientTour.TourID.ToString.Trim
        LabelBuyer.Text = CClientTour.Buyer.Trim
        LabelContactTelEmail.Text = CClientTour.BuyerTelEmail.Trim
        LabelTouredWith.Text = CClientTour.TourWith.Trim
        LabelClientReference.Text = CClientTour.BuyerID.ToString.Trim
        LabelNoOfProperties.Text = CClientTour.TourProperty.Count.ToString.Trim
        LabelViewDateYear.Text = CClientTour.ViewingDate.Year.ToString.Trim
        LabelViewDateMonth.Text = CClientTour.ViewingDate.Month.ToString.Trim
        LabelViewDateDay.Text = CClientTour.ViewingDate.Day.ToString.Trim
        LabelMeetingTimeHour.Text = Format(CClientTour.ViewingDate.Hour, "00")
        LabelMeetingTimeMinute.Text = Format(CClientTour.ViewingDate.Minute, "00")

        ' For each Property being Viewed
        For Each CClientTourProperty As ClassClientTourProperty In CClientTour.TourProperty

            ' Increment Property Counter
            nPropertyCounter += 1

            ' Depending on the Count - update the relevent row
            Select Case nPropertyCounter

                Case 1
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpartner1, LabelName1, LabelAddress1, LabelTown1, LabelContactNo1, LabelPrice1, LabelTimeHour1, LabelTimeSeparator1, LabelTimeMinute1, LabelKey1)
                    LoadPropertyViewing(CClientTourProperty, LabelReference1, LabelTimeHour1, LabelTimeMinute1)
                    TableRowProperty1.Visible = True

                Case 2
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpartner2, LabelName2, LabelAddress2, LabelTown2, LabelContactNo2, LabelPrice2, LabelTimeHour2, LabelTimeSeparator2, LabelTimeMinute2, LabelKey2)
                    LoadPropertyViewing(CClientTourProperty, LabelReference2, LabelTimeHour2, LabelTimeMinute2)
                    TableRowProperty2.Visible = True

                Case 3
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpartner3, LabelName3, LabelAddress3, LabelTown3, LabelContactNo3, LabelPrice3, LabelTimeHour3, LabelTimeSeparator3, LabelTimeMinute3, LabelKey3)
                    LoadPropertyViewing(CClientTourProperty, LabelReference3, LabelTimeHour3, LabelTimeMinute3)
                    TableRowProperty3.Visible = True

                Case 4
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpatner4, LabelName4, LabelAddress4, LabelTown4, LabelContactNo4, LabelPrice4, LabelTimeHour4, LabelTimeSeparator4, LabelTimeMinute4, LabelKey4)
                    LoadPropertyViewing(CClientTourProperty, LabelReference4, LabelTimeHour4, LabelTimeMinute4)
                    TableRowProperty4.Visible = True

                Case 5
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpatner5, LabelName5, LabelAddress5, LabelTown5, LabelContactNo5, LabelPrice5, LabelTimeHour5, LabelTimeSeparator5, LabelTimeMinute5, LabelKey5)
                    LoadPropertyViewing(CClientTourProperty, LabelReference5, LabelTimeHour5, LabelTimeMinute5)
                    TableRowProperty5.Visible = True

                Case 6
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpatner6, LabelName6, LabelAddress6, LabelTown6, LabelContactNo6, LabelPrice6, LabelTimeHour6, LabelTimeSeparator6, LabelTimeMinute6, LabelKey6)
                    LoadPropertyViewing(CClientTourProperty, LabelReference6, LabelTimeHour6, LabelTimeMinute6)
                    TableRowProperty6.Visible = True

                Case 7
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpatner7, LabelName7, LabelAddress7, LabelTown7, LabelContactNo7, LabelPrice7, LabelTimeHour7, LabelTimeSeparator7, LabelTimeMinute7, LabelKey7)
                    LoadPropertyViewing(CClientTourProperty, LabelReference7, LabelTimeHour7, LabelTimeMinute7)
                    TableRowProperty7.Visible = True

                Case 8
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpatner8, LabelName8, LabelAddress8, LabelTown8, LabelContactNo8, LabelPrice8, LabelTimeHour8, LabelTimeSeparator8, LabelTimeMinute8, LabelKey8)
                    LoadPropertyViewing(CClientTourProperty, LabelReference8, LabelTimeHour8, LabelTimeMinute8)
                    TableRowProperty8.Visible = True

                Case 9
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpatner9, LabelName9, LabelAddress9, LabelTown9, LabelContactNo9, LabelPrice9, LabelTimeHour9, LabelTimeSeparator9, LabelTimeMinute9, LabelKey9)
                    LoadPropertyViewing(CClientTourProperty, LabelReference9, LabelTimeHour9, LabelTimeMinute9)
                    TableRowProperty9.Visible = True

                Case Else
                    UpdatePropertyDetails(CClientTourProperty.PropertyID, Labelpatner10, LabelName10, LabelAddress10, LabelTown10, LabelContactNo10, LabelPrice10, LabelTimeHour10, LabelTimeSeparator10, LabelTimeMinute10, LabelKey10)
                    LoadPropertyViewing(CClientTourProperty, LabelReference10, LabelTimeHour10, LabelTimeMinute10)
                    TableRowProperty10.Visible = True

            End Select

        Next

        ' Tidy
        CClientTour = Nothing

    End Sub

End Class
