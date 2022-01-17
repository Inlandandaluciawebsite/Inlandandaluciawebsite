Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports HashSoftwares
Partial Class WebUserControlAdminLawyerArea
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        lnkbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
        ' Init Welcome
        LabelWelcome.Text = "Welcome " & Session("ContactName")

        ' Populate the Properties Allocated to this Lawyer
        DropDownListProperty.DataSource = CDataAccess.LawyerProperties(Convert.ToInt32(Session("ContactID")))
        DropDownListProperty.DataValueField = "id"
        DropDownListProperty.DataTextField = "Reference"
        DropDownListProperty.DataBind()

        ' Add Select
        DropDownListProperty.Items.Insert(0, "--- Select ---")

        Dim sqlSearch As SqlParameter() = New SqlParameter(1) {}
        sqlSearch(0) = New SqlParameter("@nLawyerID", Convert.ToInt32(Session("ContactID")))

        '   Dim CDataAccess As New ClassDataAccess

        ' Assign Results to Session Variable
        ' Dim dt As DataTable = CDataAccess.ContactSearch(Convert.ToInt32(Session("AdminContactSearchTypeID")), txtname.Text.Trim, Convert.ToInt32(Session("ContactPartnerID")), txtprop.Text.Trim, chkarchived.Checked)

        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_buyerdetail_showbylawyerId", sqlSearch).Tables(0)
        If dt.Rows.Count > 0 Then
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            'lblmessage.Visible = False
            'BtnDelete.Visible = True
        Else
            grdAdmin.DataSource = dt
            grdAdmin.DataBind()
            'lblmessage.Visible = True
            'BtnDelete.Visible = False
        End If
        ' Tidy
        CDataAccess = Nothing

    End Sub

    Private Sub HideControls()

        ' Hide the Controls
        PlaceHolderBuyer.Visible = False
        PlaceHolderVendor.Visible = False
        PlaceHolderDocuments.Visible = False
        tblgrid.Visible = False

        lnkbtn.Style.Add(HtmlTextWriterStyle.Display, "Inline")

    End Sub
    Private Sub SHOWControls()

        ' Hide the Controls
        PlaceHolderBuyer.Visible = False
        PlaceHolderVendor.Visible = False
        PlaceHolderDocuments.Visible = False
        tblgrid.Visible = True
        TableOptions.Visible = False
        lnkbtn.Style.Add(HtmlTextWriterStyle.Display, "none")
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
    Protected Sub grdAdmin_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "Buyer" Then
            ' Hide Controls
            HideControls()

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim CBuyer As New ClassBuyer(Convert.ToInt32(Session("ContactPartnerID")))

            ' Load the Contact
            CBuyer.Load(CDataAccess.PropertyBuyer(Convert.ToInt32(e.CommandArgument)))

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

        End If
        If e.CommandName = "Vendor" Then
            ' Hide Controls
            HideControls()

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess
            Dim CContact As New ClassContact

            ' Load the Contact
            CContact.Load(9608)

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


        End If

        If e.CommandName = "document" Then
            ' Hide Controls
            ' Hide Controls
            HideControls()

            ' Init Docs
            AdminDocumentManager.InitData(Convert.ToInt32(e.CommandArgument))

            ' Display
            PlaceHolderDocuments.Visible = True


        End If
    End Sub
    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs)
        SHOWControls()
    End Sub
End Class
