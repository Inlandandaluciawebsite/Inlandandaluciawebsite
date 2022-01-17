Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares
Imports System.IO
Partial Class Buyer
    Inherits BasePage
    Dim hashClass As New zHashClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblProperty.Text = "<h3><span>" & Request.QueryString("propertytitle").ToString() & "</span></h3>"
            txtNotes.Text = "I would like to reserve " & Request.QueryString("propertyref").ToString() & " for next two weeks..."
            If Not Session("language") = "" Then
                If Session("language") = "English" Then
                    txtNotes.Text = "I would like to reserve " & Request.QueryString("propertyref").ToString() & " for next two weeks..."
                End If
                If Session("language") = "Spanish" Then
                    txtNotes.Text = "Me gustaría reservar " & Request.QueryString("propertyref").ToString() & " durante las próximas dos semanas."
                End If
                If Session("language") = "French" Then
                    txtNotes.Text = "J'aimerais réserver " & Request.QueryString("propertyref").ToString() & " pour les deux prochaines semaines."
                End If
                If Session("language") = "German" Then
                    txtNotes.Text = "Ik zou graag " & Request.QueryString("propertyref").ToString() & " willen reserveren gedurende twee weken."
                End If
                If Session("language") = "Dutch" Then
                    txtNotes.Text = "I would like to reserve " & Request.QueryString("propertyref").ToString() & " for next two weeks..."
                End If
            End If
        End If
            If Not Session("language") = "" Then
            If ViewState("SampleText") Is Nothing Then
                ViewState("SampleText") = Session("language")
            End If
            If Not ViewState("SampleText") = Session("language") Then
                ViewState("SampleText") = Session("language")
            End If
        End If
    End Sub
    Protected Sub btnStripe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkReserve.Click
        Dim strAddress As String = txtAddress.Text
        Dim strNotes As String = txtNotes.Text
        strAddress = strAddress.Replace(vbLf, " ")
        strNotes = strNotes.Replace(vbLf, " ")
        Response.Redirect("StripePayment.aspx?Forename=" & txtForename.Text & "&Surname=" & txtSurname.Text & "&Address=" & strAddress & "&Telephone=" & txtTelephone.Text & "&Email=" & txtEmail.Text & "&Notes=" & strNotes & "&propertyref=" & Request.QueryString("propertyref").ToString() & "&propertytitle=" & Request.QueryString("propertytitle").ToString())
    End Sub
    Protected Sub txtEmail_TextChanged(sender As Object, e As EventArgs)
        'Get Buyer's details from database if buyer is already exists
        If txtEmail.Text <> "" Then
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@Email", txtEmail.Text)
            Dim dtBuyerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Select_By_Email", sql).Tables(0)
            If dtBuyerDetails.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(dtBuyerDetails.Rows(0)("Buyer_Forename")) Then
                    txtForename.Text = dtBuyerDetails.Rows(0)("Buyer_Forename")
                End If
                If Not String.IsNullOrEmpty(dtBuyerDetails.Rows(0)("Buyer_Surname")) Then
                    txtSurname.Text = dtBuyerDetails.Rows(0)("Buyer_Surname")
                End If
                If Not String.IsNullOrEmpty(dtBuyerDetails.Rows(0)("Buyer_Address")) Then
                    txtAddress.Text = dtBuyerDetails.Rows(0)("Buyer_Address")
                End If
                If Not String.IsNullOrEmpty(dtBuyerDetails.Rows(0)("Buyer_Telephone")) Then
                    txtTelephone.Text = dtBuyerDetails.Rows(0)("Buyer_Telephone")
                End If

                'txtForename.Text = dtBuyerDetails.Rows(0)("Buyer_Forename")
                'txtSurname.Text = dtBuyerDetails.Rows(0)("Buyer_Surname")
                'txtAddress.Text = dtBuyerDetails.Rows(0)("Buyer_Address")
                'txtTelephone.Text = dtBuyerDetails.Rows(0)("Buyer_Telephone")
            Else
                txtForename.Text = ""
                txtSurname.Text = ""
                txtAddress.Text = ""
                txtTelephone.Text = ""
            End If
        Else
            txtForename.Text = ""
            txtSurname.Text = ""
            txtAddress.Text = ""
            txtTelephone.Text = ""
        End If
    End Sub
End Class
