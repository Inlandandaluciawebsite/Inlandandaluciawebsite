Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Security
Imports System.Security.Cryptography

Partial Class Buyer_Criterias
    '  Inherits System.Web.UI.Page
    Inherits BasePage

    'https://www.codeguru.com/dotnet/encrypting-important-strings-with-triple-des-and-net/

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindCriterias()
            BindBuyerCriterias()
        End If
    End Sub
    Public Sub BindCriterias()
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Criterias_Select_All").Tables(0)
        chklstBuyerCriterias.DataSource = dt
        chklstBuyerCriterias.DataTextField = "Criteria"
        chklstBuyerCriterias.DataValueField = "Criteria_ID"
        chklstBuyerCriterias.DataBind()
    End Sub
    Public Sub BindBuyerCriterias()
        Dim Buyer_Id As Int32 = Convert.ToInt32(Decrypt(Request.QueryString("BuyerID").ToString()))
        Dim sqlbuyerdetails As SqlParameter() = New SqlParameter(0) {}
        sqlbuyerdetails(0) = New SqlParameter("@Buyer_Id", Buyer_Id)
        Dim dtbuyerdetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Criterias_Select_By_BuyerID", sqlbuyerdetails).Tables(0)
        If dtbuyerdetails.Rows.Count > 0 Then
            For buyeritems As Integer = 0 To dtbuyerdetails.Rows.Count - 1
                For chkItem As Integer = 0 To chklstBuyerCriterias.Items.Count - 1
                    If chklstBuyerCriterias.Items(chkItem).Value = dtbuyerdetails.Rows(buyeritems)("Criterias_Id").ToString() Then
                        chklstBuyerCriterias.Items(chkItem).Selected = True
                        If chklstBuyerCriterias.Items(chkItem).Text = "Buy in 12 months" Then
                            chklstBuyerCriterias.Items(chkItem).Text = "Buy in 12 months from " & dtbuyerdetails.Rows(buyeritems)("CreateDate").ToString()
                        End If
                        If chklstBuyerCriterias.Items(chkItem).Text = "Buy in 6 months" Then
                            chklstBuyerCriterias.Items(chkItem).Text = "Buy in 6 months from " & dtbuyerdetails.Rows(buyeritems)("CreateDate").ToString()
                        End If
                    End If
                Next
            Next
        End If
        'Get Buyer Name 
        Dim sqlBuyername As String = "select Buyer_Forename+' ' + Buyer_Surname as [BuyerName] from buyer where Buyer_Id=" & Buyer_Id

        Dim dtbuyerName As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, sqlBuyername).Tables(0)
        If dtbuyerName.Rows.Count > 0 Then
            lblBuyerName.Text = dtbuyerName.Rows(0)("BuyerName").ToString()
        End If

    End Sub
    Protected Sub ButtonSave_Click(sender As Object, e As EventArgs)
        Dim Buyer_Id As Int32 = Convert.ToInt32(Decrypt(Request.QueryString("BuyerID").ToString()))
        For chkItem As Integer = 0 To chklstBuyerCriterias.Items.Count - 1
            If chklstBuyerCriterias.Items(chkItem).Selected Then
                Dim sqlBuyerCriteria As SqlParameter() = New SqlParameter(1) {}
                sqlBuyerCriteria(0) = New SqlParameter("@Buyer_Id", Buyer_Id)
                sqlBuyerCriteria(1) = New SqlParameter("@Criterias_Id", Convert.ToInt32(chklstBuyerCriterias.Items(chkItem).Value))
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Criterias_Insert", sqlBuyerCriteria)
            Else
                Dim sql As SqlParameter() = New SqlParameter(1) {}
                sql(0) = New SqlParameter("@Buyer_Id", Buyer_Id)
                sql(1) = New SqlParameter("@Criterias_Id", Convert.ToInt32(chklstBuyerCriterias.Items(chkItem).Value))
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Criterias_Delete", sql)
            End If
        Next
        BindCriterias()
        BindBuyerCriterias()
        lblMessage.Text = "Buyer Criterias been saved successfully !"

        'Send email to sales person
        Dim sqlBuyerDetails As SqlParameter() = New SqlParameter(1) {}
        sqlBuyerDetails(0) = New SqlParameter("@Buyer_Id", Buyer_Id)
        Dim dtBuyerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Select_By_Buyer_Id", sqlBuyerDetails).Tables(0)

        If dtBuyerDetails.Rows.Count > 0 Then

            Dim BuyerName As String = dtBuyerDetails.Rows(0)("Buyer_Forename").ToString() & " " & dtBuyerDetails.Rows(0)("Buyer_Surname").ToString()
            Dim BuyerEmail As String = dtBuyerDetails.Rows(0)("Buyer_Email").ToString()
            Dim mailTitleToSalesPerson As String
            Dim mailBodyToSalesPerson As String = "Email of your client who just updated their criteria : " & BuyerEmail
            If dtBuyerDetails.Rows(0)("SalesPersonEmail").ToString() <> "" Then
                Try
                    ' Define a New Email
                    Dim CEmailSalesPerson As New ClassEmail
                    Dim isDevORTraining As Int16 = 0
                    If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                        mailTitleToSalesPerson = "Test Only -  Your client " & BuyerName & " has updated their criteria"
                        'CEmailSalesPerson.SendEmail(dtBuyerDetails.Rows(0)("SalesPersonEmail").ToString(), mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        CEmailSalesPerson.SendEmail("sourabhodesk@gmail.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        CEmailSalesPerson.SendEmail("jerome@inlandandalucia.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        CEmailSalesPerson.SendEmail("lee@inlandandalucia.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        isDevORTraining = 1
                    End If
                    If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                        mailTitleToSalesPerson = "Test Only -  Your client " & BuyerName & " has updated their criteria"
                        'CEmailSalesPerson.SendEmail(dtBuyerDetails.Rows(0)("SalesPersonEmail").ToString(), mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        CEmailSalesPerson.SendEmail("sourabhodesk@gmail.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        CEmailSalesPerson.SendEmail("jerome@inlandandalucia.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        CEmailSalesPerson.SendEmail("lee@inlandandalucia.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        isDevORTraining = 1
                    End If
                    If isDevORTraining = 0 Then
                        mailTitleToSalesPerson = "Your client " & BuyerName & " has updated their criteria"
                        CEmailSalesPerson.SendEmail(dtBuyerDetails.Rows(0)("SalesPersonEmail").ToString(), mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        'CEmailSalesPerson.SendEmail("sourabhodesk@gmail.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        CEmailSalesPerson.SendEmail("jerome@inlandandalucia.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                        CEmailSalesPerson.SendEmail("lee@inlandandalucia.com", mailTitleToSalesPerson, mailBodyToSalesPerson, True, Nothing, False)
                    End If

                Catch ex As Exception

                End Try
            End If


        End If

        'Insert buyer history record accordingly

        'Get Modified by as SYSTEM ENTRY WITH IN CLIENT TABLE

        Dim dtSystemContact As DataTable
        Dim strQuerySystemContact As String = "select * from contact where contact_email='tech@inlandandalucia.com' and IsMainContact=1"
        dtSystemContact = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, strQuerySystemContact).Tables(0)

        Dim sqlBuyerHistory As SqlParameter() = New SqlParameter(7) {}
        sqlBuyerHistory(0) = New SqlParameter("@Buyer_Id", Buyer_Id)
        sqlBuyerHistory(1) = New SqlParameter("@Buyer_Status", 2)
        sqlBuyerHistory(2) = New SqlParameter("@History_Text", "Client has updated is criterias online ")
        sqlBuyerHistory(3) = New SqlParameter("@Modified_By", Convert.ToInt32(dtSystemContact.Rows(0)("Contact_Id").ToString()))
        sqlBuyerHistory(4) = New SqlParameter("@Action_Date", System.DateTime.Now)
        sqlBuyerHistory(5) = New SqlParameter("@Archived", 0)
        sqlBuyerHistory(6) = New SqlParameter("@Action_Status", "Open")

        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_INSERT", sqlBuyerHistory)

    End Sub

    Private Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText.Replace(" ", "+"))
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function
End Class
