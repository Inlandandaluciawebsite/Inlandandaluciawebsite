Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Partial Class UpdatePropertyHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("BuyerId") Is Nothing Then
                InsertErrorLog(0, "URL is missing Buyer Id ! Please check URL !")
                Response.Write("URL is missing Buyer Id ! Please check URL !")
                Return
            End If
            Try
                Dim Buyer_idCheck As Int16 = Convert.ToInt32(Request.QueryString("BuyerId"))
            Catch ex As Exception
                InsertErrorLog(0, "BuyerId is not in correct format , please check buyer id again !")
                Response.Write("Operation haven't performed property ! Error Message : " & ex.Message.ToString())
                Return
            End Try

            Try
                'Check salesperson id of coming buyer if not ismainadmin then update with ismainadmin record by checking same email
                Dim sqlUpdateSalesPerson As SqlParameter() = New SqlParameter(1) {}
                sqlUpdateSalesPerson(0) = New SqlParameter("@Buyer_Id", Convert.ToInt32(Request.QueryString("BuyerId")))
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_SalesPerson_Check", sqlUpdateSalesPerson)

                UpdatePropertyHistory()
                InsertErrorLog(Convert.ToInt32(Request.QueryString("BuyerId")), "Operation Performed Successfully !")
                Response.Write("Operation Performed Successfully !")
            Catch ex As Exception
                Dim errormessage As String = ex.Message
                InsertErrorLog(Convert.ToInt32(Request.QueryString("BuyerId")), errormessage)
                Response.Write("Operation haven't performed property ! Error Message : " & ex.Message.ToString())
            End Try
        End If
    End Sub
    Public Sub UpdatePropertyHistory()

        If Not Request.QueryString("BuyerId") Is Nothing Then

            'Get Buyer Notes From database by buyer id

            Dim BuyerId As Int16 = Convert.ToInt32(Request.QueryString("BuyerId"))
            Dim dtBuyerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, "select * from buyer where buyer_id=" & BuyerId & "").Tables(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Updating new enquiry form request with in property history as per property references

            Dim propertyreferences As String = ""
            Dim propertyreference As String = ""
            Dim BuyerNotes = dtBuyerDetails.Rows(0)("Buyer_Notes").ToString().ToLower()
            Dim propertytypes As String = "AP,BA,CH,CM,CJ,DP,FI,PJ,PL,TH,VL"
            For i = 0 To propertytypes.Split(",").Length - 1
                BuyerNotes = dtBuyerDetails.Rows(0)("Buyer_Notes").ToString().ToLower()
                For j = 0 To 9
                    Dim prefix As String = propertytypes.ToLower().Split(",")(i) & j.ToString().ToLower()
                    Dim index As Int16 = BuyerNotes.IndexOf(prefix)
                    Dim count1 As String = BuyerNotes.Replace(prefix, "")
                    Dim countHowMany As Int16 = (BuyerNotes.Length - count1.Length) / prefix.Length
                    For startPrefix = 1 To countHowMany
                        If Convert.ToInt16(BuyerNotes.IndexOf(prefix)) > -1 Then
                            Try
                                propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 6)
                            Catch ex As Exception
                                Try
                                    propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 5)
                                Catch exjj As Exception
                                    Try
                                        propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 4)
                                    Catch ex1 As Exception
                                        Try
                                            propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 3)
                                        Catch ex2 As Exception
                                            Try
                                                propertyreference = BuyerNotes.Substring(BuyerNotes.IndexOf(prefix).ToString(), 2)
                                            Catch ex3 As Exception

                                            End Try
                                        End Try
                                    End Try
                                End Try
                            End Try
                            propertyreferences = propertyreferences & propertyreference & " "
                        End If
                        BuyerNotes = BuyerNotes.Replace(propertyreference.Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", ""), "")
                    Next
                Next
            Next
            Dim sql As SqlParameter() = New SqlParameter(2) {}
            sql(0) = New SqlParameter("@Buyer_Id", BuyerId)
            sql(1) = New SqlParameter("@PropertyRef", propertyreferences.ToUpper().Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", ""))
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Update_PropertyRefs", sql)

            Dim totalreferences() As String = propertyreferences.ToUpper().Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", "").Split(" ")
            For i = 0 To totalreferences.Count - 1
                If totalreferences(i) <> "" Then
                    Dim sqlpropertyhistory As SqlParameter() = New SqlParameter(5) {}
                    sqlpropertyhistory(0) = New SqlParameter("@Property_Ref", totalreferences(i).ToString())
                    sqlpropertyhistory(1) = New SqlParameter("@Type_Id", 14)
                    Dim Buyer_Surname As String = dtBuyerDetails.Rows(0)("Buyer_Surname").ToString()
                    Dim Buyer_Forename As String = dtBuyerDetails.Rows(0)("Buyer_Forename").ToString()
                    Dim datereceived As String = DateTime.Now.ToString()
                    Dim historytext = "Enquiry received for the property ref  " & totalreferences(i).ToString() & " from client " & Buyer_Surname & " " & Buyer_Forename & " – on the " & datereceived & ""
                    sqlpropertyhistory(2) = New SqlParameter("@History_Text", historytext)
                    sqlpropertyhistory(3) = New SqlParameter("@Modified_By", 0)
                    sqlpropertyhistory(4) = New SqlParameter("@Buyer_Id", BuyerId)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert", sqlpropertyhistory)
                End If
            Next
        End If
    End Sub
    Public Sub InsertErrorLog(BuyerId As Int32, Message As String)
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@Message", Message)
        sql(1) = New SqlParameter("@Buyer_Id", BuyerId)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblErrorLogs_Insert", sql)
    End Sub
End Class
