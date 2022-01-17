Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports inland_api
Imports System.Net
Imports System.Web.Script.Serialization

Partial Class Admin_AddManualEnquirer
    Inherits System.Web.UI.Page

    'Shared id As Int32 = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            Dim CDataAccess As New ClassDataAccess
            Dim CUtilities As New ClassUtilities
            ' Source
            CUtilities.PopulateDropDownList(drpSource, CDataAccess.BuyerSource)
            drpSource.Items.Insert(0, "--- Select ---")
            CUtilities.PopulateDropDownList(drpOffices, CDataAccess.Partners)
            drpOffices.Items.Insert(0, "--- Select ---")
            CUtilities.PopulateDropDownList(DropDownListLanguage, CDataAccess.Languages(Convert.ToInt32(Session("ContactLanguageID"))))
            DropDownListLanguage.Items.Insert(0, "--- Select ---")
        End If
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Try
            'Check if property reference which entered is correct one 
            If chkNoPropertyReference.Checked = False And txtPropertyRef.Text <> "" Then
                'Check property reference if exists
                Dim strQuery As String = "select * From property where property_ref='" & txtPropertyRef.Text & "' And (Status_Id=2 OR Status_Id=7)"
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, strQuery).Tables(0)
                If dt.Rows.Count > 0 Then
                Else
                    lblMessage.Text = "Please input valid property reference !"
                    lblMessage.Visible = True
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    Return
                End If
            End If
            ' Set Validation
            If txtSurname.Text = "" Then
                lblMessage.Text = "Please enter Surname !"
                lblMessage.Visible = True
                lblMessage.ForeColor = System.Drawing.Color.Red
                Return
            End If
            If txtEmail.Text = "" And txtTelephone.Text = "" Then
                lblMessage.Text = "Please enter Telephone Or Email !"
                lblMessage.Visible = True
                lblMessage.ForeColor = System.Drawing.Color.Red
                Return
            End If
            If chkNoPropertyReference.Checked = False And txtPropertyRef.Text = "" Then
                lblMessage.Text = "Please enter Property Ref !"
                lblMessage.Visible = True
                lblMessage.ForeColor = System.Drawing.Color.Red
                Return
            End If
            If chkNoPropertyReference.Checked = True And drpOffices.Visible = True Then
                If drpOffices.SelectedItem.Value = "--- Select ---" Then
                    lblMessage.Text = "Please select office !"
                    lblMessage.Visible = True
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    Return
                End If
            End If
            If drpSource.SelectedItem.Value = "--- Select ---" Then
                lblMessage.Text = "Please select source !"
                lblMessage.Visible = True
                lblMessage.ForeColor = System.Drawing.Color.Red
                Return
            End If
            If DropDownListLanguage.SelectedItem.Value = "--- Select ---" Then
                lblMessage.Text = "Please select language !"
                lblMessage.Visible = True
                lblMessage.ForeColor = System.Drawing.Color.Red
                Return
            End If
            ' Send the Email to info@inlandandalucia regarding this manual enquiry details
            Dim SubjectToAdmin As String = ""
            Dim ContentToAdmin As String

            Dim isDevORTraining As Int16 = 0
            If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                SubjectToAdmin = "Test Only - New Manual Enquiry has been entered from " & Session("ContactName").ToString()
                isDevORTraining = 1
            End If
            If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                SubjectToAdmin = "Test Only - New Manual Enquiry has been entered from " & Session("ContactName").ToString()
                isDevORTraining = 1
            End If
            If isDevORTraining = 0 Then
                SubjectToAdmin = "New Manual Enquiry has been entered from " & Session("ContactName").ToString()
            End If


            ContentToAdmin = "Name :  " & txtForeName.Text & "<br/>"
            ContentToAdmin = ContentToAdmin & "Surname :  " & txtSurname.Text & "<br/>"
            ContentToAdmin = ContentToAdmin & "Tel :  " & txtTelephone.Text & "<br/>"
            ContentToAdmin = ContentToAdmin & "Email :  " & txtEmail.Text & "<br/>"
            ContentToAdmin = ContentToAdmin & "Property Ref :  " & txtPropertyRef.Text & "<br/>"
            If drpSource.SelectedItem.Value = "--- Select ---" Then
                ContentToAdmin = ContentToAdmin & "Source :  <br/>"
            Else
                ContentToAdmin = ContentToAdmin & "Source :  " & drpSource.SelectedItem.Text & "<br/>"
            End If

            If drpOffices.Visible = True Then
                If drpOffices.SelectedItem.Value = "--- Select ---" Then
                    ContentToAdmin = ContentToAdmin & "Office :  <br/>"
                Else
                    ContentToAdmin = ContentToAdmin & "Office :  " & drpOffices.SelectedItem.Text & "<br/>"
                End If
            Else
                ContentToAdmin = ContentToAdmin & "Office :  <br/>"
            End If
            ContentToAdmin = ContentToAdmin & "Language : " & DropDownListLanguage.SelectedItem.Text & "<br/>"
            If chkAllocateThisClientToMe.Checked Then
                ContentToAdmin = ContentToAdmin & "Allocate this client to : " & Session("ContactName").ToString() & " - " & Session("ContactID").ToString() & "<br/>"
            Else
                ContentToAdmin = ContentToAdmin & "Allocate this client to : " & "<br/>"
            End If
            ContentToAdmin = ContentToAdmin & "Comments :  " & txtComments.Text & "<br/><br/>"

            ContentToAdmin = ContentToAdmin & "Regards <br/><br/>Inlandandalucia"
            Dim CEmail As New ClassEmail
            CEmail.SendEmail("info@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmail.SendEmail("Enquiry@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmail.SendEmail("jerome@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmail.SendEmail("sourabhodesk@gmail.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            'CEmail.SendEmail("pierre.edimbourg21@gmail.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmail = Nothing
            lblMessage.Text = "Enquiry been sent successfully !"
            lblMessage.ForeColor = System.Drawing.Color.Green
            txtForeName.Text = ""
            txtSurname.Text = ""
            txtTelephone.Text = ""
            txtEmail.Text = ""
            txtComments.Text = ""
            txtPropertyRef.Text = ""
            chkNoPropertyReference.Checked = False
            drpOffices.SelectedIndex = 0
            drpSource.SelectedIndex = 0
            DropDownListLanguage.SelectedIndex = 0
            drpOffices.Visible = False
            lblOffice.Visible = False
            lblPropertyRef.Visible = True
            txtPropertyRef.Visible = True
            chkAllocateThisClientToMe.Checked = False

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub chkNoPropertyReference_CheckedChanged(sender As Object, e As EventArgs)
        If chkNoPropertyReference.Checked = True Then
            txtPropertyRef.Text = ""
            drpOffices.Visible = True
            lblOffice.Visible = True
            lblPropertyRef.Visible = False
            txtPropertyRef.Visible = False
        Else
            drpOffices.Visible = False
            lblOffice.Visible = False
            lblPropertyRef.Visible = True
            txtPropertyRef.Visible = True
        End If
    End Sub
End Class
