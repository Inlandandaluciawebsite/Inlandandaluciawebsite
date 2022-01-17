Imports Microsoft.VisualBasic
Imports System.Data

Public Class ClassContact

    Private m_nID As Integer
    Public Property ID As Integer
        Get
            Return m_nID
        End Get
        Set(ByVal value As Integer)
            m_nID = value
        End Set
    End Property

    Private m_szUsername As String
    Public Property Username As String
        Get
            Return m_szUsername
        End Get
        Set(ByVal value As String)
            m_szUsername = value
        End Set
    End Property

    Private m_szPassword As String
    Public Property Password As String
        Get
            Return m_szPassword
        End Get
        Set(ByVal value As String)
            m_szPassword = value
        End Set
    End Property

    Private m_nTypeID As Integer
    Public Property TypeID As Integer
        Get
            Return m_nTypeID
        End Get
        Set(ByVal value As Integer)
            m_nTypeID = value
        End Set
    End Property

    Private m_szName As String
    Public Property Name As String
        Get
            Return m_szName
        End Get
        Set(ByVal value As String)
            m_szName = value
        End Set
    End Property

    Private m_szRegistrationNumber As String
    Public Property RegistrationNumber As String
        Get
            Return m_szRegistrationNumber
        End Get
        Set(ByVal value As String)
            m_szRegistrationNumber = value
        End Set
    End Property

    Private m_szAddress As String
    Public Property Address As String
        Get
            Return m_szAddress
        End Get
        Set(ByVal value As String)
            m_szAddress = value
        End Set
    End Property

    Private m_szTelephone As String
    Public Property Telephone As String
        Get
            Return m_szTelephone
        End Get
        Set(ByVal value As String)
            m_szTelephone = value
        End Set
    End Property

    Private m_szMobile As String
    Public Property Mobile As String
        Get
            Return m_szMobile
        End Get
        Set(ByVal value As String)
            m_szMobile = value
        End Set
    End Property

    Private m_szFax As String
    Public Property Fax As String
        Get
            Return m_szFax
        End Get
        Set(ByVal value As String)
            m_szFax = value
        End Set
    End Property

    Private m_szEmail As String
    Public Property Email As String
        Get
            Return m_szEmail
        End Get
        Set(ByVal value As String)
            m_szEmail = value
        End Set
    End Property

    Private m_szNotes As String
    Public Property Notes As String
        Get
            Return m_szNotes
        End Get
        Set(ByVal value As String)
            m_szNotes = value
        End Set
    End Property

    Private m_nLanguageID As Integer
    Public Property LanguageID As Integer
        Get
            Return m_nLanguageID
        End Get
        Set(ByVal value As Integer)
            m_nLanguageID = value
        End Set
    End Property

    Private m_nPartnerID As Integer
    Public Property PartnerID As Integer
        Get
            Return m_nPartnerID
        End Get
        Set(ByVal value As Integer)
            m_nPartnerID = value
        End Set
    End Property

    Private m_nCommission As Integer
    Public Property Commission As Integer
        Get
            Return m_nCommission
        End Get
        Set(ByVal value As Integer)
            m_nCommission = value
        End Set
    End Property

    Private m_bAdministrator As Boolean
    Public Property Administrator As Boolean
        Get
            Return m_bAdministrator
        End Get
        Set(ByVal value As Boolean)
            m_bAdministrator = value
        End Set
    End Property

    Private m_bArchived As Boolean
    Public Property Archived As Boolean
        Get
            Return m_bArchived
        End Get
        Set(ByVal value As Boolean)
            m_bArchived = value
        End Set
    End Property

    Private m_bAuthenticated As Boolean
    Public ReadOnly Property Authenticated As Boolean
        Get
            Return m_bAuthenticated
        End Get
    End Property

    Private m_multipleContact As Boolean
    Public Property MultipleContact As Boolean
        Get
            Return m_multipleContact
        End Get
        Set(ByVal value As Boolean)
            m_multipleContact = value
        End Set
    End Property


    Public Sub New(ByVal szUsername As String, ByVal szPassword As String)

        ' Assign to Class
        m_szUsername = szUsername.Trim.ToLower
        m_szPassword = szPassword.Trim.ToLower

    End Sub

    Public Sub New(Optional ByVal nID As Integer = 0, Optional ByVal nTypeID As Integer = 0)

        ' Assign to Class
        ID = nID
        TypeID = nTypeID

        ' Init Remaining Parameters        
        Name = String.Empty
        RegistrationNumber = String.Empty
        Address = String.Empty
        Telephone = String.Empty
        Mobile = String.Empty
        Fax = String.Empty
        Email = String.Empty
        Notes = String.Empty
        Username = String.Empty
        Password = String.Empty
        LanguageID = 1
        PartnerID = 3873
        Commission = 0
        Administrator = False
        Archived = False

    End Sub

    Public Sub Load(ByVal nContactID As Integer)

        ' If there is a Contact being Loaded
        If nContactID > 0 Then

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Load Contact
            Dim dtDatatable As DataTable = CDataAccess.LoadContact(nContactID)

            ' If we have a Row
            If dtDatatable.Rows.Count > 0 Then

                ' Populate Data
                ID = nContactID
                TypeID = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_type_id"), 0)
                Name = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_name"), String.Empty)
                RegistrationNumber = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_registration_number"), String.Empty)
                Address = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_address"), String.Empty)
                Telephone = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_telephone"), String.Empty)
                Mobile = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_mobile"), String.Empty)
                Fax = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_fax"), String.Empty)
                Email = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_email"), String.Empty)
                Notes = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_notes"), String.Empty)
                Username = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_login"), String.Empty)
                Password = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_password"), String.Empty)
                LanguageID = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_language_id"), 0)
                PartnerID = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_partner_id"), 0)
                Commission = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_commission"), 0)
                Administrator = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_admin"), False)
                Archived = CDataAccess.DBSafe(dtDatatable.Rows(0).Item("contact_archived"), False)

                ' Legacy Code - Convert Old Partner IDs to New
                If PartnerID = 10100 Then
                    PartnerID = 3873
                End If

            End If

            ' Tidy
            CDataAccess = Nothing

        End If

    End Sub

    Public Function Type(ByVal nContactTypeID As Integer) As String

        ' Local Vars
        Dim szRetVal As String = String.Empty
        Dim CDataAccess As New ClassDataAccess

        ' Get the Type
        szRetVal = CDataAccess.ContactType(nContactTypeID).Trim

        ' Tidy
        CDataAccess = Nothing

        ' Return the Result
        Return szRetVal

    End Function

    Public Function Save() As Boolean

        ' Init SQL
        Dim szSQL As String = _
            "merge contact as target using " & _
            "(" & _
                "select " & _
                    ID.ToString.Trim & ", " & _
                    "'" & Address.Trim & "', "

        ' Adding Administrator Flag
        If Administrator Then
            szSQL &= "1, "
        Else
            szSQL &= "0, "
        End If

        ' Adding Archived Flag
        If Archived Then
            szSQL &= "1, "
        Else
            szSQL &= "0, "
        End If

        szSQL &= _
                    Commission.ToString.Trim & ", " & _
                    "'" & Email.Trim & "', " & _
                    "'" & Fax.Trim & "', " & _
                    LanguageID.ToString.Trim & ", " & _
                    "'" & Mobile.Trim & "', " & _
                    "'" & Name.Replace("'", "''").Trim & "', " & _
                    "'" & Notes.Trim & "', " & _
                    PartnerID.ToString.Trim & ", " & _
                    "'" & Password.Trim & "', " & _
                    "'" & RegistrationNumber.Trim & "', " & _
                    "'" & Telephone.Trim & "', " & _
                    TypeID.ToString.Trim & ", " & _
                    "'" & Username.Trim & "'" & _
            ") " & _
            "as source " & _
            "(" & _
                "contact_id, " & _
                "contact_address, " & _
                "contact_admin, " & _
                "contact_archived, " & _
                "contact_commission, " & _
                "contact_email, " & _
                "contact_fax, " & _
                "contact_language_id, " & _
                "contact_mobile, " & _
                "contact_name, " & _
                "contact_notes, " & _
                "contact_partner_id, " & _
                "contact_password, " & _
                "contact_registration_number, " & _
                "contact_telephone, " & _
                "contact_type_id, " & _
                "contact_login" & _
             ") " & _
            "on target.contact_id = source.contact_id " & _
            "when matched then " & _
                "update set " & _
                     "contact_address = source.contact_address, " & _
                     "contact_archived = source.contact_archived, " & _
                     "contact_admin = source.contact_admin, " & _
                     "contact_commission = source.contact_commission, " & _
                     "contact_email = source.contact_email, " & _
                     "contact_fax = source.contact_fax, " & _
                     "contact_language_id = source.contact_language_id, " & _
                     "contact_mobile = source.contact_mobile, " & _
                     "contact_name = source.contact_name, " & _
                     "contact_notes = source.contact_notes, " & _
                     "contact_partner_id = source.contact_partner_id, " & _
                     "contact_password = source.contact_password, " & _
                     "contact_registration_number = source.contact_registration_number, " & _
                     "contact_telephone = source.contact_telephone, " & _
                     "contact_type_id = source.contact_type_id, " & _
                     "contact_login = source.contact_login " & _
            "when not matched then " & _
                "insert " & _
                "(" & _
                    "contact_address, " & _
                    "contact_archived, " & _
                    "contact_admin, " & _
                    "contact_commission, " & _
                    "contact_email, " & _
                    "contact_fax, " & _
                    "contact_language_id, " & _
                    "contact_mobile, " & _
                    "contact_name, " & _
                    "contact_notes, " & _
                    "contact_partner_id, " & _
                    "contact_password, " & _
                    "contact_registration_number, " & _
                    "contact_telephone, " & _
                    "contact_type_id, " & _
                    "contact_login" & _
                ") " & _
                "values " & _
                "(" & _
                    "source.contact_address, " & _
                    "source.contact_archived, " & _
                    "source.contact_admin, " & _
                    "source.contact_commission, " & _
                    "source.contact_email, " & _
                    "source.contact_fax, " & _
                    "source.contact_language_id, " & _
                    "source.contact_mobile, " & _
                    "source.contact_name, " & _
                    "source.contact_notes, " & _
                    "source.contact_partner_id, " & _
                    "source.contact_password, " & _
                    "source.contact_registration_number, " & _
                    "source.contact_telephone, " & _
                    "source.contact_type_id, " & _
                    "source.contact_login" & _
                ");"

        ' Run the Update
        Dim CDataAccess As New ClassDataAccess
        Dim bRetVal As Boolean = CDataAccess.Execute(szSQL)

        ' If the ID was Zero (new Contact)
        If ID < 1 Then

            ' Init SQL
            szSQL = "select top 1 contact_id from CONTACT order by Contact_ID desc"

            ' Set the new ID
            ID = CDataAccess.GetDataAsInteger(szSQL)

        End If

        ' Tidy
        CDataAccess = Nothing

        ' Return Result
        Return bRetVal

    End Function

End Class
