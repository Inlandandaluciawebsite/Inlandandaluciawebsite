Imports System.Data

Partial Class WebUserControlAdminPostcodeReassignment
    Inherits System.Web.UI.UserControl

    Public Event Completed()

    Public Enum E_Level As Integer
        TopLevel = 0
        Country = 1
        Region = 2
        Area = 3
        SubArea = 4
    End Enum

    Private m_bUpdatingByPostcode As Boolean
    Public Property UpdatingByPostcode() As Boolean
        Get
            Return m_bUpdatingByPostcode
        End Get
        Set(ByVal value As Boolean)
            m_bUpdatingByPostcode = value
        End Set
    End Property

    Public Sub LoadReassignment()

        ' Check we have Session Variables
        If Session("AdminPostcodeReassignments") Is Nothing Or Session("AdminPostcodeReassignmentLevel") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Check we have Reassignments
            If DirectCast(Session("AdminPostcodeReassignments"), DataTable).Rows.Count > 0 Then

                ' Local Vars
                Dim szPostcode As String = String.Empty
                Dim nCountryID As Integer = 0
                Dim szCountry As String = String.Empty
                Dim nRegionID As Integer = 0
                Dim szRegion As String = String.Empty
                Dim nAreaID As Integer = 0
                Dim szArea As String = String.Empty
                Dim nSubAreaID As Integer = 0
                Dim szSubArea As String = String.Empty
                Dim CDataAccess As New ClassDataAccess

                ' Update Label
                LabelReassignmentsRemaining.Text = DirectCast(Session("AdminPostcodeReassignments"), DataTable).Rows.Count.ToString.Trim

                ' Set the Postcode ID to Replace
                Dim nPostcodeIDToReplace As Integer = Convert.ToInt32(DirectCast(Session("AdminPostcodeReassignments"), DataTable).Rows(0).Item("postcode_id"))

                ' Get the Existing
                If CDataAccess.RegionAreaSubArea(nPostcodeIDToReplace, szPostcode, nCountryID, szCountry, nRegionID, szRegion, nAreaID, szArea, nSubAreaID, szSubArea) Then

                    ' Assign to Form
                    LabelPostcode.Text = szPostcode.Trim
                    LabelCountry.Text = szCountry.Trim
                    LabelArea.Text = szRegion.Trim
                    LabelTown.Text = szArea.Trim
                    LabelVillage.Text = szSubArea.Trim

                End If

                ' Tidy
                CDataAccess = Nothing

                ' Init Country
                AdminLocation1.InitCountry(nCountryID)

            Else

                ' Raise Event
                RaiseEvent Completed()

            End If

        End If

    End Sub

    Public Sub InitForm(ByVal alPostcodeIDExclusions As ArrayList)

        ' Check we have Session Variables
        If Session("AdminPostcodeReassignments") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Reset Postcode Table
            Session("AdminLocationPostcodeTable") = Nothing

            ' Initialise Location Control
            AdminLocation1.ContainingPropertiesOnly = False
            AdminLocation1.AddAllOption = False
            AdminLocation1.LoadCountries(alPostcodeIDExclusions)

        End If

    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click

        ' Check we have Session Variables
        If Session("AdminPostcodeReassignments") Is Nothing Then

            ' Redirect to Login Screen
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Move affected Properties to new Postcode
            CDataAccess.ReassignPostcode(Convert.ToInt32(DirectCast(Session("AdminPostcodeReassignments"), DataTable).Rows(0).Item("postcode_id")), AdminLocation1.PostcodeID)

            ' Tidy
            CDataAccess = Nothing

            ' Remove this Entry from the List
            DirectCast(Session("AdminPostcodeReassignments"), DataTable).Rows(0).Delete()
            DirectCast(Session("AdminPostcodeReassignments"), DataTable).Rows(0).AcceptChanges()

            ' Load the Next
            LoadReassignment()

        End If

    End Sub

End Class
