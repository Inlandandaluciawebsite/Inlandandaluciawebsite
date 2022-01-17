Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Public Class zHashClass
    Public MyCon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Public Sub ModifyStatusAfterPayPalPayment(SQLquery As String)
        SqlHelper.ExecuteNonQuery(MyCon, CommandType.Text, SQLquery)
    End Sub
    Public Function InsertInBuyerTable(SQLquery As String) As DataTable
        Return SqlHelper.ExecuteDataset(MyCon, CommandType.Text, SQLquery).Tables(0)
    End Function
    Public Sub InsertInTransactionTable(Buyer_Id As Integer, TransactionNumber As String, ReservedAmount As Decimal, Currency As String, PropertyRef As String, PaymentMethod As String)
        Dim sqldata As SqlParameter() = New SqlParameter(6) {}
        sqldata(0) = New SqlParameter("@Buyer_Id", Buyer_Id)
        sqldata(1) = New SqlParameter("@TransactionNumber", TransactionNumber)
        sqldata(2) = New SqlParameter("@ReservedAmount", ReservedAmount)
        sqldata(3) = New SqlParameter("@Currency", Currency)
        sqldata(4) = New SqlParameter("@PropertyRef", PropertyRef)
        sqldata(5) = New SqlParameter("@PaymentMethod", PaymentMethod)

        SqlHelper.ExecuteNonQuery(MyCon, CommandType.StoredProcedure, "USP_PaypalTransactions_Insert", sqldata)
    End Sub
    Public Function GetTransactionTable() As DataTable

        Return SqlHelper.ExecuteDataset(MyCon, CommandType.StoredProcedure, "USP_PaypalTransactions_Select").Tables(0)

    End Function
End Class
