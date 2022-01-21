Imports HashSoftwares
Imports System.Data
Imports System.Data.SqlClient

Public Class crud_utility
    Public MyCon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Public Function GetContactDetails_By_ContactId(Contact_Id As Integer) As DataTable
        Dim sqldata As SqlParameter() = New SqlParameter(1) {}
        sqldata(0) = New SqlParameter("@Contact_Id", Contact_Id)
        Return SqlHelper.ExecuteDataset(MyCon, CommandType.StoredProcedure, "USP_tblContact_Select_By_Contact_Id", sqldata).Tables(0)
    End Function
    Public Function GetAllPartners_Having_Property() As DataTable
        Return SqlHelper.ExecuteDataset(MyCon, CommandType.StoredProcedure, "USP_tblContact_Get_Partner_Having_Property").Tables(0)
    End Function
End Class
