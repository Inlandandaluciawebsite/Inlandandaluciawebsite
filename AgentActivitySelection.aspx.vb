Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Partial Class AgentActivitySelection
    Inherits System.Web.UI.Page

    Public Function GetTranslation(ByVal szText As String) As String
        Dim CDataAccess As New ClassDataAccess
        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim
        CDataAccess = Nothing
        Return szRetVal
    End Function

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Convert.ToInt32(Session("ContactType")) = 9 Then
            Response.Redirect("~/AdminNew/Index.aspx")
        Else
            ' Add Activities to Drop Down
            DropDownListActivity.Items.Add("New Back Office")
            DropDownListActivity.Items.Add("Search Properties")
            DropDownListActivity.Items.Add("Featured Properties")
            'DropDownListActivity.Items.Add("Old Back Office")
            'DropDownListActivity.Items.Add("Generate Leads")
            ' Load the Button Images
        End If
        ImageButtonSignOut.ImageUrl = GetSignOutImagePath()
    End Sub

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

    Protected Sub ButtonContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinue.Click

        If Session("MultipleContact").ToString() = "Yes" Then
            Session("ContactPartnerID") = Convert.ToInt32(drpContactPartner.SelectedValue)
            'Get Contact_Name by Contact Partner Id from Contact Table
            ' Init SQL

            Dim szSQL As String = ""
            If Session("ContactType").ToString() = "6" Then
                szSQL = "select contact_name from contact where contact_mobile="
                szSQL = szSQL & "(select contact_mobile from contact where contact_id=" & Session("ContactID").ToString() & ") and contact_partner_id=" & Session("ContactPartnerID").ToString() & ""
            Else
                szSQL = "select contact_name from contact where contact_email="
                szSQL = szSQL & "(select contact_email from contact where contact_id=" & Session("ContactID").ToString() & ") and contact_partner_id=" & Session("ContactPartnerID").ToString() & ""
            End If

            ' Get the Result
            Dim CDataAccess As New ClassDataAccess

            Dim dtDataTable As DataTable = CDataAccess.GetDataAsDataTable(szSQL)

            If dtDataTable.Rows.Count > 0 Then
                Session("ContactName") = dtDataTable.Rows(0)("Contact_Name").ToString()
            End If

        End If



        ' Depending on the Option Chosen
        If DropDownListActivity.SelectedIndex = 0 Then
            If DropDownListActivity.SelectedIndex = 0 And Convert.ToInt32(Session("AdminUser")) = 0 And Convert.ToInt32(Session("ContactType")) = 4 Then
                'If Convert.ToInt32(Session("ContactID")) = 3426 Or Convert.ToInt32(Session("ContactID")) = 4318 Or Convert.ToInt32(Session("ContactID")) = 5255 Then
                Response.Redirect("~/AdminNew/Dashboard_Action_Agenda.aspx")
            Else
                Response.Redirect("~/AdminNew/Index.aspx")
            End If
        ElseIf DropDownListActivity.SelectedIndex = 1 Then
            Response.Redirect("~/AgentArea.aspx")
        ElseIf DropDownListActivity.SelectedIndex = 2 Then
            Response.Redirect("~/AgentArea.aspx?page=1&regionid=0&areaid=0&subareaid=0&typeid=0&minimumbedrooms=0&minimumbathrooms=0&minimumprice=0&maximumprice=0&features=&sort=price_asc&plotsize=&isfeatured=1")
            'Response.Redirect("~/GenerateLeads/Index.aspx")
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' If we are not in Agent Mode
        If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else
            If Not IsPostBack Then
                If Not String.IsNullOrEmpty(Request.QueryString("ContactType")) Then
                    Session("MultipleContact") = "False"
                End If
                If Session("MultipleContact").ToString() = "Yes" Then
                    trPartnerSelection.Visible = True
                    BindAllPartners()
                End If
            End If

            ' Set Focus
            DropDownListActivity.Focus()

        End If

    End Sub

    Public Sub BindAllPartners()

        Dim contactPartners As SqlParameter() = New SqlParameter(0) {}
        contactPartners(0) = New SqlParameter("@Contact_ID", Convert.ToInt16(Session("ContactID")))

        Dim dtContactPartner As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Partner_By_ContactId_v2", contactPartners).Tables(0)
        drpContactPartner.DataSource = dtContactPartner
        drpContactPartner.DataTextField = "contact_name"
        drpContactPartner.DataValueField = "Contact_Partner_Id"
        drpContactPartner.DataBind()

        ' Set Main Contact In Dropdown by checking ismaincontact for logged in user
        ' Get Default Main Contact of logged in user here
        Dim defaultMainContact As SqlParameter() = New SqlParameter(0) {}
        defaultMainContact(0) = New SqlParameter("@Contact_ID", Convert.ToInt16(Session("ContactID")))

        Dim dtdefaultMainContact As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Contact_Get_MainPartner_By_ContactId", defaultMainContact).Tables(0)
        If dtdefaultMainContact.Rows.Count > 0 Then
            drpContactPartner.SelectedValue = dtdefaultMainContact.Rows(0)(0).ToString()
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

End Class
