Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares

Public Class ClassBuyer

    Private m_nID As Integer
    Public Property ID() As Integer
        Get
            Return m_nID
        End Get
        Set(ByVal value As Integer)
            m_nID = value
        End Set
    End Property

    Private m_szForename As String
    Public Property Forename() As String
        Get
            Return m_szForename
        End Get
        Set(ByVal value As String)
            m_szForename = value
        End Set
    End Property

    Private m_szSurname As String
    Public Property Surname() As String
        Get
            Return m_szSurname
        End Get
        Set(ByVal value As String)
            m_szSurname = value
        End Set
    End Property

    Private m_szPassportNumber As String
    Public Property PassportNumber() As String
        Get
            Return m_szPassportNumber
        End Get
        Set(ByVal value As String)
            m_szPassportNumber = value
        End Set
    End Property

    Private m_szAddress As String
    Public Property Address() As String
        Get
            Return m_szAddress
        End Get
        Set(ByVal value As String)
            m_szAddress = value
        End Set
    End Property

    Private m_szContactName As String
    Public Property ContactName() As String
        Get
            Return m_szContactName
        End Get
        Set(ByVal value As String)
            m_szContactName = value
        End Set
    End Property

    Private m_szTelephone As String
    Public Property Telephone() As String
        Get
            Return m_szTelephone
        End Get
        Set(ByVal value As String)
            m_szTelephone = value
        End Set
    End Property

    Private m_szEmail As String
    Public Property Email() As String
        Get
            Return m_szEmail
        End Get
        Set(ByVal value As String)
            m_szEmail = value
        End Set
    End Property

    Private m_szNotes As String
    Public Property Notes() As String
        Get
            Return m_szNotes
        End Get
        Set(ByVal value As String)
            m_szNotes = value
        End Set
    End Property

    Private m_nPartnerID As Integer
    Public Property PartnerID() As Integer
        Get
            Return m_nPartnerID
        End Get
        Set(ByVal value As Integer)
            m_nPartnerID = value
        End Set
    End Property

    Private m_nAgentID As Integer
    Public Property AgentID() As Integer
        Get
            Return m_nAgentID
        End Get
        Set(ByVal value As Integer)
            m_nAgentID = value
        End Set
    End Property

    Private m_nLanguageID As Integer
    Public Property LanguageID() As Integer
        Get
            Return m_nLanguageID
        End Get
        Set(ByVal value As Integer)
            m_nLanguageID = value
        End Set
    End Property

    Private m_nBudget As Integer
    Public Property Budget() As Integer
        Get
            Return m_nBudget
        End Get
        Set(ByVal value As Integer)
            m_nBudget = value
        End Set
    End Property

    Private m_nSourceID As Integer
    Public Property SourceID() As Integer
        Get
            Return m_nSourceID
        End Get
        Set(ByVal value As Integer)
            m_nSourceID = value
        End Set
    End Property

    Private m_nStatusID As Integer
    Public Property StatusID() As Integer
        Get
            Return m_nStatusID
        End Get
        Set(ByVal value As Integer)
            m_nStatusID = value
        End Set
    End Property

    Private m_bArchived As Integer
    Public Property Archived() As Integer
        Get
            Return m_bArchived
        End Get
        Set(ByVal value As Integer)
            m_bArchived = value
        End Set
    End Property

    Private m_nBuyer_Salesperson_ID As Integer
    Public Property Buyer_Salesperson_ID() As Integer
        Get
            Return m_nBuyer_Salesperson_ID
        End Get
        Set(ByVal value As Integer)
            m_nBuyer_Salesperson_ID = value
        End Set
    End Property

    Public Function Save() As Integer

        ' Local Vars
        Dim szSQL As String
        Dim bNew As Boolean = False

        ' Set Flag
        bNew = (ID < 1)

        ' Are we Creating a New or Updating an Existing Record?
        If bNew Then

            ' Creating a New Record
            szSQL = "insert into BUYER " &
                    "(" &
                        "Buyer_Forename, " &
                        "Buyer_Surname, " &
                        "Buyer_Passport, " &
                        "Buyer_Address, " &
                        "Buyer_Contact_Name, " &
                        "Buyer_Telephone, " &
                        "Buyer_Email, " &
                        "Buyer_Notes, " &
                        "Buyer_Partner_ID, " &
                        "Buyer_Agent_ID, " &
                        "Language_ID, " &
                        "Buyer_Budget, " &
                        "Buyer_Source_ID, " &
                        "Buyer_Status_ID, " &
                        "Archived, " &
                        "Buyer_Salesperson_ID " &
                    ") " &
                    "values " &
                    "(" &
                        "'" & Forename.Replace("'", "''").Trim & "', " &
                        "'" & Surname.Replace("'", "''").Trim & "', " &
                        "'" & PassportNumber.Trim & "', " &
                        "'" & Address.Trim & "', " &
                        "'" & ContactName.Trim & "', " &
                        "'" & Telephone.Trim & "', " &
                        "'" & Email.Trim & "', " &
                        "'" & Notes.Trim & "', " &
                        PartnerID.ToString.Trim & ", " &
                        AgentID.ToString.Trim & ", " &
                        LanguageID.ToString.Trim & ", " &
                        Budget.ToString.Trim & ", " &
                        SourceID.ToString.Trim & ", " &
                        StatusID.ToString.Trim & ", " &
                        Convert.ToInt32(Archived) & ", " &
                          Buyer_Salesperson_ID.ToString() &
                    ")"

        Else

            ' Updating an Existing Record
            szSQL = "update BUYER " &
                    "set " &
                        "Buyer_Forename = '" & Forename.Replace("'", "''").Trim & "', " &
                        "Buyer_Surname = '" & Surname.Replace("'", "''").Trim & "', " &
                        "Buyer_Passport = '" & PassportNumber.Trim & "', " &
                        "Buyer_Address = '" & Address.Trim & "', " &
                        "Buyer_Contact_Name = '" & ContactName.Trim & "', " &
                        "Buyer_Telephone = '" & Telephone.Trim & "', " &
                        "Buyer_Email = '" & Email.Trim & "', " &
                        "Buyer_Notes = '" & Notes.Trim & "', " &
                        "Buyer_Partner_ID = " & PartnerID.ToString.Trim & ", " &
                        "Buyer_Agent_ID = " & AgentID.ToString.Trim & ", " &
                        "Language_ID = " & LanguageID.ToString.Trim & ", " &
                        "Buyer_Budget = " & Budget.ToString.Trim & ", " &
                        "Buyer_Source_ID = " & SourceID.ToString.Trim & ", " &
                        "Buyer_Status_ID = " & StatusID.ToString.Trim & ", " &
                        "Archived = " & Convert.ToInt32(Archived) & ",  " &
                        "Buyer_Salesperson_ID = " & Buyer_Salesperson_ID.ToString() & " " &
                    "where Buyer_ID = " & ID.ToString.Trim

        End If

        ' Saving this Record
        Dim CDataAccess As New ClassDataAccess
        Dim bRetVal As Boolean = CDataAccess.Execute(szSQL)

        ' If this is New
        If bNew Then

            ' Get the ID
            ID = CDataAccess.GetDataAsInteger("select max(Buyer_ID) from BUYER")

        End If

        ' Tidy
        CDataAccess = Nothing

        ' Return the ID
        Return ID

    End Function

    Public Sub Load(ByVal nBuyerID As Integer)

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess

        ' Set the ID
        ID = nBuyerID

        ' Init SQL
        Dim szSQL As String =
            "select " &
                "Buyer_Forename, " &
                "Buyer_Surname, " &
                "Buyer_Passport, " &
                "Buyer_Address, " &
                "Buyer_Contact_Name, " &
                "Buyer_Telephone, " &
                "Buyer_Email, " &
                "Buyer_Notes, " &
                "Buyer_Partner_ID, " &
                "Buyer_Agent_ID, " &
                "Language_ID, " &
                "Buyer_Budget, " &
                "isnull(Buyer_Source_ID, 0) Buyer_Source_ID, " &
                "isnull(Buyer_Status_ID, 0) Buyer_Status_ID, " &
                "Archived , " &
                 "Buyer_Salesperson_ID " &
            "from BUYER " &
            "where Buyer_ID = " & ID.ToString.Trim

        ' Load into Data Table
        Dim dtDataTable As DataTable = CDataAccess.GetDataAsDataTable(szSQL)

        ' If we got a Result
        If dtDataTable.Rows.Count > 0 Then

            ' Assign to Locals
            Forename = dtDataTable.Rows(0).Item("Buyer_Forename").ToString.Trim
            Surname = dtDataTable.Rows(0).Item("Buyer_Surname").ToString.Trim
            PassportNumber = dtDataTable.Rows(0).Item("Buyer_Passport").ToString.Trim
            Address = dtDataTable.Rows(0).Item("Buyer_Address").ToString.Trim
            ContactName = dtDataTable.Rows(0).Item("Buyer_Contact_Name").ToString.Trim
            Telephone = dtDataTable.Rows(0).Item("Buyer_Telephone").ToString.Trim
            Email = dtDataTable.Rows(0).Item("Buyer_Email").ToString.Trim
            Notes = dtDataTable.Rows(0).Item("Buyer_Notes").ToString.Trim
            PartnerID = Convert.ToInt32(dtDataTable.Rows(0).Item("Buyer_Partner_ID"))
            AgentID = Convert.ToInt32(dtDataTable.Rows(0).Item("Buyer_Agent_ID"))
            LanguageID = Convert.ToInt32(dtDataTable.Rows(0).Item("Language_ID"))
            Budget = Convert.ToInt32(dtDataTable.Rows(0).Item("Buyer_Budget"))
            SourceID = Convert.ToInt32(dtDataTable.Rows(0).Item("Buyer_Source_ID"))
            StatusID = Convert.ToInt32(dtDataTable.Rows(0).Item("Buyer_Status_ID"))
            Archived = Convert.ToBoolean(dtDataTable.Rows(0).Item("Archived"))
            Buyer_Salesperson_ID = (dtDataTable.Rows(0).Item("Buyer_Salesperson_ID"))
        End If

        ' Tidy
        dtDataTable.Dispose()
        CDataAccess = Nothing

    End Sub

    Public Sub New(ByVal nPartnerID As Integer)

        ' Init
        PartnerID = nPartnerID
        LanguageID = 1

    End Sub

    'Public Sub New(ByVal nPartnerID As Integer)

    '    ' Init Vars
    '    Address = String.Empty
    '    AgentID = 0
    '    Budget = 0
    '    ContactName = String.Empty
    '    Email = String.Empty
    '    Forename = String.Empty
    '    ID = 0
    '    LanguageID = 1
    '    Notes = String.Empty
    '    PartnerID = nPartnerID
    '    PassportNumber = String.Empty
    '    Surname = String.Empty
    '    Telephone = String.Empty

    'End Sub

    'Public Overloads Function IsEqual(ByVal CBuyer As ClassBuyer) As Boolean

    '    ' Compare Variables
    '    Return _
    '        CBuyer.Address = Address And _
    '        CBuyer.AgentID = AgentID And _
    '        CBuyer.Budget = Budget And _
    '        CBuyer.ContactName = ContactName And _
    '        CBuyer.Email = Email And _
    '        CBuyer.Forename = Forename And _
    '        CBuyer.ID = ID And _
    '        CBuyer.LanguageID = LanguageID And _
    '        CBuyer.Notes = Notes And _
    '        CBuyer.PartnerID = PartnerID And _
    '        CBuyer.PassportNumber = PassportNumber And _
    '        CBuyer.Surname = Surname And _
    '        CBuyer.Telephone = Telephone

    'End Function

    Public Sub BuyerAllocationChange(ByVal Buyer_Id As Int32, ByVal History_Text As String, ByVal Modified_By As Int32)

        Dim sql As SqlParameter() = New SqlParameter(6) {}
        sql(0) = New SqlParameter("@Buyer_ID", Buyer_Id)
        sql(1) = New SqlParameter("@Buyer_Status", 1)
        sql(2) = New SqlParameter("@History_Text", History_Text)
        sql(3) = New SqlParameter("@Modified_By", Modified_By)
        sql(4) = New SqlParameter("@Action_Date", System.DateTime.Now)
        sql(5) = New SqlParameter("@Archived", 0)
        sql(6) = New SqlParameter("@Action_Status", "Open")

        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_BUYER_HISTORY_INSERT", sql)


    End Sub

End Class
