Imports System.IO

Partial Class WebUserControlAdminLawyerAreaNew
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("ContactID") Is Nothing Then

            Response.Redirect("/AgentLogin.aspx")
        End If
        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Init Welcome
        LabelWelcome.Text = "Welcome " & Session("ContactName")

        ' Populate the Properties Allocated to this Lawyer
        DropDownListProperty.DataSource = CDataAccess.LawyerProperties(Convert.ToInt32(Session("ContactID")))
        'DropDownListProperty.DataSource = CDataAccess.LawyerProperties_By_Partner_Id(Convert.ToInt32(Session("ContactID")), Session("ContactPartnerID").ToString())
        DropDownListProperty.DataValueField = "id"
        DropDownListProperty.DataTextField = "Reference"
        DropDownListProperty.DataBind()

        ' Add Select
        DropDownListProperty.Items.Insert(0, "--- Select ---")

        ' Tidy
        CDataAccess = Nothing

    End Sub

    Private Sub HideControls()

        ' Hide the Controls
        PlaceHolderBuyer.Visible = False
        PlaceHolderVendor.Visible = False
        PlaceHolderDocuments.Visible = False

    End Sub

    Protected Sub DropDownListProperty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListProperty.SelectedIndexChanged

        ' Hide the Controls
        HideControls()

        ' If a Property has been Selected
        If DropDownListProperty.SelectedIndex > 0 Then

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim bBuyersLawyer As Boolean = CDataAccess.IsBuyersLawyer(Convert.ToInt32(DropDownListProperty.SelectedValue), Convert.ToInt32(Session("ContactID")))
            Dim bVendorsLawyer As Boolean = CDataAccess.IsVendorsLawyer(Convert.ToInt32(DropDownListProperty.SelectedValue), Convert.ToInt32(Session("ContactID")))
            CDataAccess = Nothing

            ' Enable / Disable Buyer / Vendor Links
            LinkButtonBuyer.Visible = bBuyersLawyer
            LinkButtonVendor.Visible = bVendorsLawyer
            LinkButtonDocuments.Visible = bBuyersLawyer Or bVendorsLawyer

        End If

        ' Show / Hide Info
        TableOptions.Visible = (DropDownListProperty.SelectedIndex > 0)

    End Sub

    Protected Sub LinkButtonBuyer_Click(sender As Object, e As EventArgs) Handles LinkButtonBuyer.Click

        ' Hide Controls
        HideControls()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))

        ' Load the Contact
        'Session("AdminBuyerSelected") = DropDownListProperty.SelectedValue
        CBuyer.Load(CDataAccess.PropertyBuyer(Convert.ToInt32(DropDownListProperty.SelectedValue)))

        ' Tidy
        CDataAccess = Nothing

        ' If we got the Details
        If CBuyer.ID > 0 Then

            ' Init Buyer
            AdminBuyer.InitData(CBuyer)

            ' Set to Lawyer Mode
            AdminBuyer.LawyerMode()

        End If

        ' Display
        PlaceHolderBuyer.Visible = CBuyer.ID > 0

        ' Tidy
        CBuyer = Nothing

    End Sub

    Protected Sub LinkButtonVendor_Click(sender As Object, e As EventArgs) Handles LinkButtonVendor.Click

        ' Hide Controls
        HideControls()

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim CContact As New ClassContact

        ' Load the Contact
        CContact.Load(CDataAccess.PropertyVendor(Convert.ToInt32(DropDownListProperty.SelectedValue)))

        ' Tidy            
        CDataAccess = Nothing

        ' If we got the Details
        If CContact.ID > 0 Then

            ' Init Vendor
            CContact.PartnerID = Convert.ToInt32(Session("ContactPartnerID"))
            AdminContact.InitData(CContact)

            ' Set to Lawyer Mode
            AdminContact.LawyerMode()

        End If

        ' Display
        PlaceHolderVendor.Visible = CContact.ID > 0

        ' Tidy
        CContact = Nothing

    End Sub

    Protected Sub LinkButtonDocuments_Click(sender As Object, e As EventArgs) Handles LinkButtonDocuments.Click

        ' Hide Controls
        HideControls()

        ' Init Docs
        AdminDocumentManager.InitData(Convert.ToInt32(DropDownListProperty.SelectedValue))

        ' Display
        PlaceHolderDocuments.Visible = True

    End Sub

End Class
