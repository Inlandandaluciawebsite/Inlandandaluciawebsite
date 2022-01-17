'Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Imports HashSoftwares

Public Class ClassDataAccess

    Public Enum E_PropertyType As Integer

        Apartment = 1
        Bar = 2
        Chalet = 3
        CoastProperty = 4
        Commercial = 5
        Cortijo = 6
        Duplex = 7
        Finca = 8
        NewBuild = 9
        Plot = 10
        TownHouse = 11
        Villa = 12

    End Enum

    Public Enum E_Region As Integer
        Cordoba = 1
        Granada = 2
        Jaen = 3
        Malaga = 4
        Sevilla = 5
    End Enum

    Public Enum E_Sort_Order As Integer
        PriceAscending = 1
        PriceDescending = 2
    End Enum

    Public Enum E_SystemVariable As Integer
        BuyerSource = 1
        BuyerStatus = 2
        Feature = 3
        Language = 4
        Location = 5
        PaymentType = 6
        Status = 7
        Type = 8
        View = 9
        Criterias = 10
        ActionTypes = 11
    End Enum

    Public Function AuthenticateLogin(ByRef CContact As ClassContact) As Boolean

        ' Init to Invalid
        Dim bRetVal As Boolean = False

        ' Check we have Credentials
        If CContact.Username <> String.Empty And CContact.Password <> String.Empty Then

            ' Init SQL
            Dim szSQL As String = "select contact_id, contact_name, contact_type_id, contact_partner_id, contact_language_id, contact_admin " &
                                  "from contact " &
                                  "where Contact_Archived=0 and Contact_Type_Id<>3 and lower(ltrim(rtrim(contact_login))) = '" & CContact.Username & "' and lower(ltrim(rtrim(contact_password))) = '" & CContact.Password & "' order by ismaincontact desc"

            ' Get the Result
            Dim dtDataTable As DataTable = GetDataAsDataTable(szSQL)

            ' If we got a Record
            If dtDataTable.Rows.Count > 0 Then

                ' Valid - Assign to Class
                CContact.ID = Convert.ToInt32(dtDataTable.Rows(0).Item("contact_id"))
                CContact.Name = dtDataTable.Rows(0).Item("contact_name").ToString
                CContact.TypeID = Convert.ToInt32(dtDataTable.Rows(0).Item("contact_type_id"))
                CContact.PartnerID = Convert.ToInt32(dtDataTable.Rows(0).Item("contact_partner_id"))
                CContact.LanguageID = Convert.ToInt32(dtDataTable.Rows(0).Item("contact_language_id"))
                CContact.Administrator = Convert.ToBoolean(dtDataTable.Rows(0).Item("contact_admin"))

                'Set if same username/password have other contacts
                If dtDataTable.Rows.Count > 1 Then
                    CContact.MultipleContact = True
                Else
                    CContact.MultipleContact = False
                End If

                ' Set the Flag
                bRetVal = True

            End If

            ' Tidy
            dtDataTable.Dispose()

        End If

        ' Return the Result
        Return bRetVal

    End Function

    Public Function Execute(ByVal szSQL As String) As Boolean

        ' Init to no Error
        Dim bRetVal As Boolean = False

        Using sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("IA").ToString)

            Try

                Dim sqlCommand As New SqlCommand(szSQL, sqlConnection)

                sqlConnection.Open()

                sqlCommand.ExecuteNonQuery()

                sqlCommand.Dispose()

            Catch ex As Exception
                ' Error - set Flag
                bRetVal = True
            End Try

            sqlConnection.Close()

        End Using

        ' Return the Result
        Return bRetVal

    End Function

    Public Function GetDataAsDataTable(ByVal szSQL As String) As DataTable

        ' Local Vars
        Dim dtDataTable As New DataTable

        ' Open Database
        Using sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("IA").ToString)

            Try

                Dim sqlDataAdapter As New SqlDataAdapter(szSQL, sqlConnection)

                sqlDataAdapter.Fill(dtDataTable)

                sqlDataAdapter.Dispose()

            Catch ex As Exception
                ' TODO
            End Try

            sqlConnection.Close()

        End Using

        Return dtDataTable

    End Function

    Public Function GetDataAsString(ByVal szSQL As String) As String

        ' Local Vars
        Dim dtTable As New DataTable
        Dim szRetVal As String = ""

        Try

            ' Get the Data Table
            dtTable = GetDataAsDataTable(szSQL)

            ' Check we got a Record
            If dtTable.Rows.Count > 0 Then

                ' Check that Field is Null
                If Not IsDBNull(dtTable.Rows(0).Item(0)) Then
                    szRetVal = dtTable.Rows(0).Item(0).ToString.Trim
                End If

            End If

            ' Tidy
            dtTable.Dispose()

        Catch ex As Exception
            ' TODO
        End Try

        ' Return the Result
        Return szRetVal

    End Function

    Public Function GetDataAsInteger(ByVal szSQL As String) As Integer

        ' Local Vars
        Dim dtTable As New DataTable
        Dim nRetVal As String = 0

        Try

            ' Get the Data Table
            dtTable = GetDataAsDataTable(szSQL)

            ' Check we got a Record
            If dtTable.Rows.Count > 0 Then

                ' Check that Field is Null
                If Not IsDBNull(dtTable.Rows(0).Item(0)) Then
                    nRetVal = Convert.ToInt32(dtTable.Rows(0).Item(0))
                End If

            End If

        Catch ex As Exception
            ' TODO
        End Try

        ' Tidy
        dtTable.Dispose()

        ' Return the Result
        Return nRetVal

    End Function

    Public Function Countries() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select c.Country_ID id, english.Text English, spanish.Text Spanish, french.Text French, german.Text German, dutch.Text Dutch, c.Country_Code Code " &
            "from COUNTRY c " &
                "inner join dictionary english on c.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "inner join dictionary spanish on c.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "inner join dictionary french on c.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "inner join dictionary german on c.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "inner join dictionary dutch on c.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function Countries(ByVal nLanguageID As Integer, Optional ByVal szColumnHeader As String = vbNullString) As DataTable

        ' Local Vars
        Dim szSQL As String =
            "select c.Country_ID id, d.text "

        ' If a Column Name has not been Provided
        If szColumnHeader Is Nothing Then

            ' Use Default
            szSQL &= "text"

        Else

            ' Use Provided
            szSQL &= szColumnHeader.Trim

        End If

        ' Continue to Init SQL
        szSQL &=
            ", c.country_code Code " &
            "from country c " &
                "inner join DICTIONARY d on c.dictionary_id = d.dictionary_id " &
            "where d.Language_ID = " & nLanguageID.ToString.Trim & " " &
            "order by d.text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function Regions(Optional ByVal nCountryID As Integer = 0, Optional ByVal szColumnHeader As String = vbNullString, Optional ByVal nExcludingPostcodeID As Integer = 0) As DataTable

        ' Local Vars
        Dim szSQL As String =
            "select r.region_id id, r.region_name "

        ' If a Column Name has not been Provided
        If szColumnHeader Is Nothing Then

            ' Use Default
            szSQL &= "text"

        Else

            ' Use Provided
            szSQL &= szColumnHeader.Trim

        End If

        ' Continue to Init SQL
        szSQL &= " " &
            "from pc_region r " &
                "inner join postcode p on r.region_id = p.region_id "

        ' If a Country ID has been Provided
        If nCountryID > 0 Then

            ' Apply Country Criteria
            szSQL &= "and p.country_id = " & nCountryID.ToString.Trim & " "

        End If

        ' If we are Excluding a Postcode
        If nExcludingPostcodeID > 0 Then

            ' Add Clause
            szSQL &=
                "where r.region_id not in " &
                "(" &
                    "select region_id " &
                    "from postcode " &
                    "where postcode_id = " & nExcludingPostcodeID.ToString.Trim &
                ") "

        End If

        ' Continue to Init SQL
        szSQL &=
            "group by r.Region_ID, r.Region_Name " &
            "order by r.region_name"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function RegionsIncPropertyCounts(Optional ByVal nTypeID As Integer = 0,
                                             Optional ByVal nMinBeds As Integer = 0,
                                             Optional ByVal nMinBaths As Integer = 0,
                                             Optional ByVal nMinPrice As Integer = 0,
                                             Optional ByVal nMaxPrice As Integer = 0) As DataTable
        Dim szSQL As String =
            "select r.region_id id, " &
                "r.region_name text, " &
                "count(p.property_id) count " &
            "from pc_region r " &
                "inner join postcode pc on pc.region_id = r.region_id " &
                "inner join property p on pc.postcode_id = p.postcode_id " &
            "where p.display = 1 "

        If nTypeID > 0 Then
            szSQL &= "and p.property_type_id = " & nTypeID.ToString.Trim & " "
        End If

        If nMinBeds > 0 Then
            szSQL &= "and p.bedrooms >= " & nMinBeds.ToString.Trim & " "
        End If

        If nMinBaths > 0 Then
            szSQL &= "and p.bathrooms >= " & nMinBaths.ToString.Trim & " "
        End If

        If nMinPrice > 0 Then
            szSQL &= "and p.public_price >= " & nMinPrice.ToString.Trim & " "
        End If

        If nMaxPrice > 0 Then
            szSQL &= "and p.public_price <= " & nMaxPrice.ToString.Trim & " "
        End If

        szSQL &=
            "group by r.region_id, r.region_name " &
            "order by r.region_name"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function RegionsIncPropertyCountsNew(Optional ByVal nTypeID As Integer = 0,
                                             Optional ByVal nMinBeds As Integer = 0,
                                             Optional ByVal nMinBaths As Integer = 0,
                                             Optional ByVal nMinPrice As Integer = 0,
                                             Optional ByVal nMaxPrice As Integer = 0,
                                                   Optional ByVal nFeatures As String = "",
                                                 Optional ByVal nMinPlotsize As Integer = 0
                                                ) As DataTable
        Dim szSQL As String =
            "select r.region_id id, " &
                "r.region_name text, " &
                "count(p.property_id) count " &
            "from pc_region r " &
                "inner join postcode pc on pc.region_id = r.region_id " &
                "inner join property p on pc.postcode_id = p.postcode_id " &
        "inner join PROPERTY_FEATURES pf on pf.property_ref = p.property_ref " &
             "where p.display = 1 and p.Status_Id=2  "

        If nTypeID > 0 Then
            szSQL &= "and p.property_type_id = " & nTypeID.ToString.Trim & " "
        End If

        If nMinBeds > 0 Then
            szSQL &= "and p.bedrooms >= " & nMinBeds.ToString.Trim & " "
        End If

        If nMinBaths > 0 Then
            szSQL &= "and p.bathrooms >= " & nMinBaths.ToString.Trim & " "
        End If

        If nMinPrice > 0 Then
            szSQL &= "and p.public_price >= " & nMinPrice.ToString.Trim & " "
        End If

        If nMaxPrice > 0 Then
            szSQL &= "and p.public_price <= " & nMaxPrice.ToString.Trim & " "
        End If
        If nMinPlotsize > 0 Then
            szSQL &= "and p.SQM_Plot >= " & nMinPlotsize.ToString.Trim & " "
        End If

        If Not nFeatures = "" Then
            szSQL &= "and pf.Features_ID In ( "
            Dim featurelist = nFeatures.Split(",")
            Dim getallfetureId As Integer = 0
            Dim count As Integer = 0
            Dim szDelim1 = " and"
            For Each c In featurelist
                If count = 0 Then
                    szDelim1 = " "
                Else
                    szDelim1 = " , "

                End If
                szSQL &= szDelim1 & c & ""
                count = count + 1
            Next
            szSQL &= " )"

        End If
        szSQL &=
            "group by r.region_id, r.region_name "
        If Not nFeatures = "" Then
            '   szSQL &= " having count(pf.property_ref) =" & nFeatures.Split(",").Length
        End If
        szSQL &= " order by r.region_name"

        Return GetDataAsDataTable(szSQL)

    End Function



    Public Function RegionsIncFeaturedPropertyCounts() As DataTable

        Dim szSQL As String =
            "select r.region_id id, " &
                "r.region_name text, " &
                "count(p.property_id) count " &
            "from pc_region r " &
                "inner join postcode pc on pc.region_id = r.region_id " &
                "inner join property p on pc.postcode_id = p.postcode_id " &
            "where p.property_ref in " &
                "( " &
                    "select top 50 property_ref " &
                    "from featured_property " &
                    "order by featured_prop_date desc " &
                ") " &
            "group by r.region_id, r.region_name " &
            "order by r.region_name"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function Areas(ByVal nRegionID As Integer, Optional ByVal bIncludeAll As Boolean = False, Optional ByVal szColumnHeader As String = vbNullString, Optional ByVal bIncludePostcodePartner As Boolean = False, Optional ByVal nExcludingPostcodeID As Integer = 0) As DataTable

        ' Local Vars
        Dim szSQL As String
        Dim szDelim As String = "where"

        ' Init SQL
        szSQL =
            "select a.area_id id, a.area_name "

        ' If a Column Name has not been Provided
        If szColumnHeader Is Nothing Then

            ' Use Default
            szSQL &= "text"

        Else

            ' Use Provided
            szSQL &= szColumnHeader.Trim

        End If

        ' If we are Including Postcode and Default Partner
        If bIncludePostcodePartner Then

            ' Add to Selection
            szSQL &= ", pc.postcode Postcode, pc.Default_Partner_ID partner_id, c.contact_name 'Default Partner'"

        End If

        ' If we are Including All
        If bIncludeAll Then

            ' Including All

            ' Continue to Init SQL
            szSQL &= " from postcode pc " &
                    "inner join pc_area a on pc.area_id = a.area_id "

            ' If we are Including Postcode and Default Partner
            If bIncludePostcodePartner Then

                ' Add to SQL
                szSQL &=
                        "inner join contact c on pc.default_partner_id = c.contact_id "

            End If

            ' If we have a Region ID
            If nRegionID > 0 Then

                ' Add Region Clause
                szSQL &= szDelim & " pc.region_id = " & nRegionID.ToString.Trim & " "

                ' Update Delimiter
                szDelim = "and"

            End If

            ' If we are Excluding a Postcode
            If nExcludingPostcodeID > 0 Then

                ' Add Clause
                szSQL &=
                    szDelim & " pc.area_id not in " &
                    "(" &
                        "select area_id " &
                        "from postcode " &
                        "where postcode_id = " & nExcludingPostcodeID.ToString.Trim &
                    ") "

            End If

            ' Continue to Init SQL
            szSQL &=
                szDelim & " pc.subarea_id = 0 " &
                "group by a.area_id, a.area_name"

            ' If we are Including Postcode and Default Partner
            If bIncludePostcodePartner Then

                ' Add to SQL
                szSQL &=
                        ", pc.Postcode, pc.Default_Partner_ID, c.Contact_Name"

            End If

            ' Continue to Init SQL
            szSQL &=
                " order by a.area_name"

        Else

            ' Including only those with Properties for Sale
            szSQL &=
                " from pc_area a "

            ' If we are Including Postcode and Default Partner
            If bIncludePostcodePartner Then

                ' Add to SQL
                szSQL &=
                        "inner join postcode pc on pc.area_id = a.area_id " &
                        "inner join contact c on pc.default_partner_id = c.contact_id "

            End If

            ' Continue to Init SQL
            szSQL &=
                "where a.area_id in " &
                "( " &
                    "select a.area_id " &
                    "from pc_area a " &
                        "inner join postcode pc on a.area_id = pc.area_id " &
                        "inner join property p on p.postcode_id = pc.postcode_id " &
                    "where p.display = 1 "

            ' If we have a Region ID
            If nRegionID > 0 Then

                ' Add Region Clause
                szSQL &= "and pc.region_id = " & nRegionID.ToString.Trim & " "

            End If

            ' If we are Excluding a Postcode
            If nExcludingPostcodeID > 0 Then

                ' Add Clause
                szSQL &=
                    "and pc.area_id not in " &
                    "(" &
                        "select area_id " &
                        "from postcode " &
                        "where postcode_id = " & nExcludingPostcodeID.ToString.Trim &
                    ") "

            End If

            ' Continue to Init SQL
            szSQL &=
                ") " &
                "order by area_name"

        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function AreasIncPropertyCounts(ByVal nRegionID As Integer,
                                             Optional ByVal nTypeID As Integer = 0,
                                             Optional ByVal nMinBeds As Integer = 0,
                                             Optional ByVal nMinBaths As Integer = 0,
                                             Optional ByVal nMinPrice As Integer = 0,
                                             Optional ByVal nMaxPrice As Integer = 0) As DataTable

        Dim szSQL As String =
            "select a.area_id id, " &
                "a.area_name text, " &
                "count(p.property_id) count " &
            "from postcode pc " &
                "inner join pc_area a on pc.area_id = a.area_id " &
                "inner join property p on pc.postcode_id = p.postcode_id " &
            "where p.display = 1 " &
            "and pc.region_id = " & nRegionID.ToString.Trim & " "

        If nTypeID > 0 Then
            szSQL &= "and p.property_type_id = " & nTypeID.ToString.Trim & " "
        End If

        If nMinBeds > 0 Then
            szSQL &= "and p.bedrooms >= " & nMinBeds.ToString.Trim & " "
        End If

        If nMinBaths > 0 Then
            szSQL &= "and p.bathrooms >= " & nMinBaths.ToString.Trim & " "
        End If

        If nMinPrice > 0 Then
            szSQL &= "and p.public_price >= " & nMinPrice.ToString.Trim & " "
        End If

        If nMaxPrice > 0 Then
            szSQL &= "and p.public_price <= " & nMaxPrice.ToString.Trim & " "
        End If

        szSQL &=
            "group by a.area_id, a.area_name " &
            "order by a.area_name"

        Return GetDataAsDataTable(szSQL)

    End Function



    Public Function AreasIncPropertyCountsNew(ByVal nRegionID As Integer,
                                             Optional ByVal nTypeID As Integer = 0,
                                             Optional ByVal nMinBeds As Integer = 0,
                                             Optional ByVal nMinBaths As Integer = 0,
                                             Optional ByVal nMinPrice As Integer = 0,
                                             Optional ByVal nMaxPrice As Integer = 0,
                                               Optional ByVal nFeatures As String = "",
                                               Optional ByVal nMinPlot As Integer = 0
                                              ) As DataTable

        Dim szSQL As String =
            "select a.area_id id, " &
                "a.area_name text, " &
                "count(p.property_id) count " &
            "from postcode pc " &
                "inner join pc_area a on pc.area_id = a.area_id " &
                "inner join property p on pc.postcode_id = p.postcode_id " &
                  "inner join PROPERTY_FEATURES pf on pf.property_ref = p.property_ref " &
            "where p.display = 1 and p.Status_Id=2 " &
            "and pc.region_id = " & nRegionID.ToString.Trim & " "

        If nTypeID > 0 Then
            szSQL &= "and p.property_type_id = " & nTypeID.ToString.Trim & " "
        End If

        If nMinBeds > 0 Then
            szSQL &= "and p.bedrooms >= " & nMinBeds.ToString.Trim & " "
        End If

        If nMinBaths > 0 Then
            szSQL &= "and p.bathrooms >= " & nMinBaths.ToString.Trim & " "
        End If

        If nMinPrice > 0 Then
            szSQL &= "and p.public_price >= " & nMinPrice.ToString.Trim & " "
        End If

        If nMaxPrice > 0 Then
            szSQL &= "and p.public_price <= " & nMaxPrice.ToString.Trim & " "
        End If
        If nMaxPrice > 0 Then
            szSQL &= "and p.SQM_Plot >= " & nMinPlot.ToString.Trim & " "
        End If

        If Not nFeatures = "" Then
            szSQL &= "and pf.Features_ID In ( "
            Dim featurelist = nFeatures.Split(",")
            Dim getallfetureId As Integer = 0
            Dim count As Integer = 0
            Dim szDelim1 = " and"
            For Each c In featurelist
                If count = 0 Then
                    szDelim1 = " "
                Else
                    szDelim1 = " , "

                End If
                szSQL &= szDelim1 & c & ""
                count = count + 1
            Next
            szSQL &= " )"

        End If
        szSQL &= "group by a.area_id, a.area_name "
        If Not nFeatures = "" Then
            szSQL &= " having count(pf.property_ref) =" & nFeatures.Split(",").Length
        End If
        szSQL &= "order by a.area_name"

        Return GetDataAsDataTable(szSQL)

    End Function


    Public Function AreasIncFeaturedPropertyCounts(ByVal nRegionID As Integer) As DataTable

        Dim szSQL As String =
            "select a.area_id id, " &
                "a.area_name text, " &
                "count(p.property_id) count " &
            "from postcode pc " &
                "inner join pc_area a on pc.area_id = a.area_id " &
                "inner join property p on pc.postcode_id = p.postcode_id " &
            "where pc.region_id = " & nRegionID.ToString.Trim & " " &
                "and p.property_ref in " &
                "( " &
                    "select top 50 property_ref " &
                    "from featured_property " &
                    "order by featured_prop_date desc " &
                ") " &
            "group by a.area_id, a.area_name " &
            "order by a.area_name"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function SubAreas(ByVal nAreaID As Integer, Optional ByVal bIncludeAll As Boolean = False, Optional ByVal szColumnHeader As String = vbNullString, Optional ByVal bIncludePostcodePartner As Boolean = False, Optional ByVal nExcludingPostcodeID As Integer = 0) As DataTable

        ' Local Vars
        Dim szSQL As String

        ' Init SQL
        szSQL =
            "select s.subarea_id id, subarea_name "

        ' If a Column Name has not been Provided
        If szColumnHeader Is Nothing Then

            ' Use Default
            szSQL &= "text"

        Else

            ' Use Provided
            szSQL &= szColumnHeader.Trim

        End If

        ' If we are Including Postcode and Default Partner
        If bIncludePostcodePartner Then

            ' Add to Selection
            szSQL &= ", pc.postcode Postcode, pc.Default_Partner_ID partner_id, c.contact_name 'Default Partner'"

        End If

        ' If we are Including All
        If bIncludeAll Then

            ' Including All
            szSQL &=
                " from postcode pc " &
                    "inner join pc_subarea s on pc.subarea_id = s.subarea_id "

            ' If we are Including Postcode and Default Partner
            If bIncludePostcodePartner Then

                ' Add to SQL
                szSQL &=
                        "inner join contact c on pc.default_partner_id = c.contact_id "

            End If

            ' Continue to Init SQL
            szSQL &=
                "where s.subarea_id > 0 "

            ' If we have an Area ID
            If nAreaID > 0 Then

                ' Add the Area Clause
                szSQL &= "and pc.area_id = " & nAreaID.ToString.Trim & " "

            End If

            ' If we are Excluding a Postcode
            If nExcludingPostcodeID > 0 Then

                ' Add Clause
                szSQL &=
                    "and pc.subarea_id not in " &
                    "(" &
                        "select subarea_id " &
                        "from postcode " &
                        "where postcode_id = " & nExcludingPostcodeID.ToString.Trim &
                    ") "

            End If

            ' Continue to Init SQL
            szSQL &=
                "group by s.subarea_id, s.subarea_name"


            ' If we are Including Postcode and Default Partner
            If bIncludePostcodePartner Then

                ' Add to SQL
                szSQL &=
                        ", pc.Postcode, pc.Default_Partner_ID, c.Contact_Name"

            End If

            ' Continue to Init SQL
            szSQL &=
                " order by s.subarea_name"

        Else

            ' Including only those with Properties for Sale
            szSQL &=
                " from pc_subarea "

            ' If we are Including Postcode and Default Partner
            If bIncludePostcodePartner Then

                ' Add to SQL
                szSQL &=
                        "inner join postcode pc on pc.subarea_id = pc_subarea.subarea_id " &
                        "inner join contact c on pc.default_partner_id = c.contact_id "

            End If

            ' Continue to Init SQL
            szSQL &=
                "where subarea_id in " &
                "( " &
                    "select s.subarea_id " &
                    "from pc_subarea s " &
                        "inner join postcode pc on s.subarea_id = pc.subarea_id " &
                        "inner join property p on p.postcode_id = pc.postcode_id " &
                    "where s.subarea_id > 0 "

            ' If we have an Area ID
            If nAreaID > 0 Then

                ' Add Area Clause
                szSQL &= "and pc.area_id = " & nAreaID.ToString.Trim & " "

            End If

            ' If we are Excluding a Postcode
            If nExcludingPostcodeID > 0 Then

                ' Add Clause
                szSQL &=
                    "and pc.subarea_id not in " &
                    "(" &
                        "select subarea_id " &
                        "from postcode " &
                        "where postcode_id = " & nExcludingPostcodeID.ToString.Trim &
                    ") "

            End If

            ' Continue to Init SQL
            szSQL &=
                ") " &
                "order by subarea_name"

        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function SubAreasIncPropertyCounts(ByVal nRegionID As Integer,
                                              ByVal nAreaID As Integer,
                                              Optional ByVal nTypeID As Integer = 0,
                                              Optional ByVal nMinBeds As Integer = 0,
                                              Optional ByVal nMinBaths As Integer = 0,
                                              Optional ByVal nMinPrice As Integer = 0,
                                              Optional ByVal nMaxPrice As Integer = 0) As DataTable
        Dim szSQL As String =
            "select s.subarea_id id, " &
                "s.subarea_name text, " &
                "count(p.property_id) count " &
            "from postcode pc " &
                "inner join pc_subarea s on pc.subarea_id = s.subarea_id " &
                "inner join property p on p.postcode_id = pc.postcode_id " &
            "where p.display = 1 " &
                "and s.subarea_id > 0 " &
                "and pc.region_id = " & nRegionID.ToString.Trim & " " &
                "and pc.area_id = " & nAreaID.ToString.Trim & " "

        If nTypeID > 0 Then
            szSQL &= "and p.property_type_id = " & nTypeID.ToString.Trim & " "
        End If

        If nMinBeds > 0 Then
            szSQL &= "and p.bedrooms >= " & nMinBeds.ToString.Trim & " "
        End If

        If nMinBaths > 0 Then
            szSQL &= "and p.bathrooms >= " & nMinBaths.ToString.Trim & " "
        End If

        If nMinPrice > 0 Then
            szSQL &= "and p.public_price >= " & nMinPrice.ToString.Trim & " "
        End If

        If nMaxPrice > 0 Then
            szSQL &= "and p.public_price <= " & nMaxPrice.ToString.Trim & " "
        End If

        szSQL &=
            "group by s.subarea_id, s.subarea_name " &
            "order by s.subarea_name"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function SubAreasIncFeaturedPropertyCounts(ByVal nRegionID As Integer,
                                              ByVal nAreaID As Integer) As DataTable

        Dim szSQL As String =
            "select s.subarea_id id, " &
                "s.subarea_name text, " &
                "count(p.property_id) count " &
            "from postcode pc " &
                "inner join pc_subarea s on pc.subarea_id = s.subarea_id " &
                "inner join property p on p.postcode_id = pc.postcode_id " &
            "where s.subarea_id > 0 " &
                "and pc.region_id = " & nRegionID.ToString.Trim & " " &
                "and pc.area_id = " & nAreaID.ToString.Trim & " " &
                "and p.property_ref in " &
                "( " &
                    "select top 50 property_ref " &
                    "from featured_property " &
                    "order by featured_prop_date desc " &
                ") " &
            "group by s.subarea_id, s.subarea_name " &
            "order by s.subarea_name"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyExists(ByVal nPropertyID As Integer) As Boolean

        ' Local Var
        Dim bRetVal As Boolean

        ' Run Query
        Dim dtDataTable As DataTable = GetDataAsDataTable("select property_id from property where display = 1 and property_id = " & nPropertyID.ToString.Trim)

        ' Set Return Value
        bRetVal = dtDataTable.Rows.Count > 0

        ' Tidy
        dtDataTable.Dispose()

        ' Return the Result
        Return bRetVal

    End Function

    Public Function PropertyDetail(ByVal szPropertyRef As String, ByVal nLanguageID As Integer, Optional ByVal nPartnerID As Integer = 3873) As DataTable

        ' Init SQL Query
        Dim szSQL As String =
            "select pr.property_id, " &
                "d_type.text type, " &
                "pr.property_ref reference, " &
                "pr.num_photos photos, " &
                "isnull(cast(ppr.reference as varchar(10)), pr.property_ref) partner_reference, " &
                "r.region_name region, " &
                "a.area_name area, " &
                "S.subarea_name subarea, " &
                "isnull(d.text, '') description, " &
                "isnull(d_es.text, '') description_es, " &
                "case when len(ds.text)>105 then isnull(left(ds.text,105)+'...','') else isnull(ds.text,'') end as 'short_description', " &
                "pr.bedrooms, " &
                "pr.bathrooms, " &
                "pr.sqm_built, " &
                "pr.sqm_plot, " &
                "pr.public_price price, " &
                "isnull(pr.original_price, 0) original_price, " &
                "d_views.text views, " &
                "d_location.text location, " &
                "(" &
                    "select ltrim(rtrim(d.text)) + ',' " &
                    "from property_features p " &
                        "inner join features f on p.features_id = f.features_id " &
                        "inner join dictionary d on f.dictionary_id = d.dictionary_id and d.language_id = " & nLanguageID.ToString.Trim &
                    "where ltrim(rtrim(upper(property_ref))) = pr.property_ref " &
                    "order by d.text " &
                    "for xml path('') " &
                ") features, " &
                "isnull(pr.video_url, '') video_url, " &
                "pr.gps_latitude latitude, " &
                "pr.gps_longitude longitude, " &
                "pr.status_id status_id, " &
                "pr.Partner_Id Partner_Id " &
            "from property pr " &
                "inner join property_type t on pr.property_type_id = t.property_type_id " &
                "left join dictionary d_type on t.dictionary_id = d_type.dictionary_id and (d_type.language_id = 0 or d_type.language_id = " & nLanguageID.ToString.Trim & ") " &
                "inner join postcode pc on pc.postcode_id = pr.postcode_id " &
                "inner join pc_region r on pc.region_id = r.region_id " &
                "inner join pc_area a on pc.area_id = a.area_id " &
                "inner join pc_subarea s on pc.subarea_id = s.subarea_id " &
                "left join property_partner_ref ppr on pr.property_id = ppr.property_id and ppr.partner_id = " & nPartnerID.ToString.Trim & " " &
                "inner join views v on pr.views_id = v.views_id " &
                "left join dictionary d_views on v.dictionary_id = d_views.dictionary_id and (d_views.language_id = 0 or d_views.language_id = " & nLanguageID.ToString.Trim & ") " &
                "inner join location l on pr.location_id = l.location_id " &
                "left join dictionary d_location on l.dictionary_id = d_location.dictionary_id and (d_location.language_id = 0 or d_location.language_id = " & nLanguageID.ToString.Trim & ") " &
                "left join property_desc d on pr.property_ref = d.property_ref and d.language_id = " & nLanguageID.ToString.Trim & " " &
                "left join property_desc d_es on pr.property_ref = d_es.property_ref and d_es.language_id = 2 " &
                "left join property_short_desc ds on pr.property_ref = ds.property_ref and ds.language_id = " & nLanguageID.ToString.Trim & " " &
            "where ltrim(rtrim(upper(pr.property_ref))) = '" & szPropertyRef.ToUpper.Trim & "'"

        '        "(" & _
        '    "select ltrim(rtrim(cast(photo_position as varchar))) + ',' " & _
        '    "from photo_image " & _
        '    "where ltrim(rtrim(upper(property_ref))) = '" & szPropertyRef.ToUpper.ToString.Trim & "' " & _
        '    "order by photo_position " & _
        '    "for xml path('') " & _
        '") photo_ids, " & _


        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function SearchResults(ByVal nLanguageID As Integer,
                                    Optional ByVal nRegionID As Integer = 0,
                                    Optional ByVal nAreaID As Integer = 0,
                                    Optional ByVal nSubAreaID As Integer = 0,
                                    Optional ByVal bTop30Mode As Boolean = False,
                                    Optional ByVal nTypeID As Integer = 0,
                                    Optional ByVal nMinimumBedrooms As Integer = 0,
                                    Optional ByVal nMinimumBathrooms As Integer = 0,
                                    Optional ByVal nMinimumPrice As Integer = 0,
                                    Optional ByVal nMaximumPrice As Integer = 0,
                                    Optional ByVal eSortOrder As E_Sort_Order = E_Sort_Order.PriceDescending,
                                    Optional ByVal nPartnerID As Integer = 3873,
                                    Optional ByVal nFeatures As String = "",
                                    Optional ByVal nplotsize As Integer = 0
                                ) As DataTable

        Dim szSQL As String =
            "select pr.property_id, " &
                "isnull(d_type.text, '') type, " &
                "pr.status_id status_id, " &
                "pr.property_ref reference, " &
                "isnull(cast(ppr.reference as varchar(10)), pr.property_ref) partner_reference, " &
                "isnull(r.region_name, '') region, " &
                "isnull(a.area_name, '') area, " &
                "isnull(s.subarea_name, '') subarea, " &
                "isnull(ds.text, '') short_description, " &
                "isnull(d.text, '') description, " &
                "pr.bedrooms, " &
                "pr.bathrooms, " &
                "pr.sqm_built, " &
                "pr.sqm_plot, " &
                "pr.public_price price, " &
                "isnull(pr.original_price, 0) original_price " &
            "from property pr " &
                "inner join postcode pc on pr.postcode_id = pc.postcode_id " &
                "inner join pc_region r on pc.region_id = r.region_id " &
                "inner join pc_area a on pc.area_id = a.area_id " &
                "inner join pc_subarea s on pc.subarea_id = s.subarea_id " &
                "left join property_partner_ref ppr on pr.property_id = ppr.property_id and ppr.partner_id = " & nPartnerID.ToString.Trim & " " &
                "inner join property_type t on pr.property_type_id = t.property_type_id " &
                 "inner join PROPERTY_FEATURES pf on pf.property_ref = pr.property_ref " &
                "left join dictionary d_type on t.dictionary_id = d_type.dictionary_id and (d_type.language_id = 0 or d_type.language_id = " & nLanguageID.ToString.Trim & ") " &
                "left join property_short_desc ds on pr.property_ref = ds.property_ref and ds.language_id = " & nLanguageID.ToString.Trim & " " &
                "left join property_desc d on pr.property_ref = d.property_ref and d.language_id = " & nLanguageID.ToString.Trim & " " &
            "where pr.property_id > 0 " &
                "and pr.display = 1 "

        ' If a Region was Specified
        If nRegionID > 0 Then
            szSQL &= "and pc.region_id = " & nRegionID.ToString.Trim & " "
        End If

        ' If an Area was Specified
        If nAreaID > 0 Then
            szSQL &= "and pc.area_id = " & nAreaID.ToString.Trim & " "
        End If

        ' If a SubArea was Specified
        If nSubAreaID > 0 Then
            szSQL &= "and pc.subarea_id = " & nSubAreaID.ToString.Trim & " "
        End If
        If nplotsize > 0 Then
            szSQL &= " and pc.SQM_Plot = " & nplotsize.ToString.Trim & " "
        End If
        ' If we are in Top 30 Mode
        If bTop30Mode Then

            ' Add SQL
            szSQL &=
                "and pr.property_ref in " &
                "( " &
                    "select top 50 property_ref " &
                    "from featured_property " &
                    "order by featured_prop_date desc " &
                ") "

        Else

            ' If a Property Type was Specified
            If nTypeID > 0 Then
                szSQL &= "and pr.property_type_id = " & nTypeID.ToString.Trim & " "
            End If

            ' If Minimum Bedrooms was Specified
            If nMinimumBedrooms > 0 Then
                szSQL &= "and pr.bedrooms >= " & nMinimumBedrooms.ToString.Trim & " "
            End If

            ' If Minimum Bathrooms was Specified
            If nMinimumBathrooms > 0 Then
                szSQL &= "and pr.bathrooms >= " & nMinimumBathrooms.ToString.Trim & " "
            End If

            ' If a Minimum Pricing Option was Specified
            If nMinimumPrice > 0 Then
                szSQL &= "and pr.public_price >= " & nMinimumPrice.ToString.Trim & " "
            End If

            ' If a Maximum Pricing Option was Specified
            If nMaximumPrice > 0 Then
                szSQL &= "and pr.public_price <= " & nMaximumPrice.ToString.Trim & " "
            End If

        End If
        If Not nFeatures = "" Then
            szSQL &= "and ("
            Dim featurelist = nFeatures.Split(",")
            Dim getallfetureId As Integer = 0
            Dim count As Integer = 0
            Dim szDelim1 = " and"
            For Each c In featurelist
                If count = 0 Then
                    szDelim1 = " "
                Else
                    szDelim1 = " or "

                End If
                szSQL &= szDelim1 & "pf.Features_ID = " & c & ""
                count = count + 1
            Next
            szSQL &= ")"



        End If

        ' Init Sort Order
        szSQL &= "order by pr.public_price"

        ' Order Results depending on the Sort Order
        If eSortOrder = E_Sort_Order.PriceDescending Then
            szSQL &= " desc"
        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function


    Public Function SearchResultsNew(ByVal nLanguageID As Integer,
                                    Optional ByVal nRegionID As Integer = 0,
                                    Optional ByVal nAreaID As Integer = 0,
                                    Optional ByVal nSubAreaID As Integer = 0,
                                    Optional ByVal bTop30Mode As Boolean = False,
                                    Optional ByVal nTypeID As Integer = 0,
                                    Optional ByVal nMinimumBedrooms As Integer = 0,
                                    Optional ByVal nMinimumBathrooms As Integer = 0,
                                    Optional ByVal nMinimumPrice As Integer = 0,
                                    Optional ByVal nMaximumPrice As Integer = 0,
                                    Optional ByVal eSortOrder As E_Sort_Order = E_Sort_Order.PriceDescending,
                                    Optional ByVal nPartnerID As Integer = 3873,
                                     Optional ByVal nFeatures As String = "",
                                      Optional ByVal nplotsize As Integer = 0
                                ) As DataTable

        Dim szSQL As String =
            "select pr.property_id, " &
                "isnull(d_type.text, '') type, " &
                "pr.status_id status_id, " &
                "pr.property_ref reference, " &
                "isnull(cast(ppr.reference as varchar(10)), pr.property_ref) partner_reference, " &
                "isnull(r.region_name, '') region, " &
                "isnull(a.area_name, '') area, " &
                "isnull(s.subarea_name, '') subarea, " &
                "isnull(ds.text, '') short_description, " &
                "isnull(d.text, '') description, " &
                "pr.bedrooms, " &
                "pr.bathrooms, " &
                "pr.sqm_built, " &
                "pr.sqm_plot, " &
                "pr.public_price price, " &
                "isnull(pr.original_price, 0) original_price " &
            "from property pr " &
                "inner join postcode pc on pr.postcode_id = pc.postcode_id " &
                "inner join pc_region r on pc.region_id = r.region_id " &
                "inner join pc_area a on pc.area_id = a.area_id " &
                "inner join pc_subarea s on pc.subarea_id = s.subarea_id " &
                "left join property_partner_ref ppr on pr.property_id = ppr.property_id and ppr.partner_id = " & nPartnerID.ToString.Trim & " " &
                "inner join property_type t on pr.property_type_id = t.property_type_id " &
                  "inner join PROPERTY_FEATURES pf on pf.property_ref = pr.property_ref " &
                "left join dictionary d_type on t.dictionary_id = d_type.dictionary_id and (d_type.language_id = 0 or d_type.language_id = " & nLanguageID.ToString.Trim & ") " &
                "left join property_short_desc ds on pr.property_ref = ds.property_ref and ds.language_id = " & nLanguageID.ToString.Trim & " " &
                "left join property_desc d on pr.property_ref = d.property_ref and d.language_id = " & nLanguageID.ToString.Trim & " " &
            "where pr.property_id > 0 " &
                " and pr.status_id=2 and pr.display = 1 "

        ' If a Region was Specified
        If nRegionID > 0 Then
            szSQL &= "and pc.region_id = " & nRegionID.ToString.Trim & " "
        End If

        ' If an Area was Specified
        If nAreaID > 0 Then
            szSQL &= "and pc.area_id = " & nAreaID.ToString.Trim & " "
        End If

        ' If a SubArea was Specified
        If nSubAreaID > 0 Then
            szSQL &= "and pc.subarea_id = " & nSubAreaID.ToString.Trim & " "
        End If
        If Not nFeatures = "" Then
            szSQL &= "and pf.Features_ID In ( "
            Dim featurelist = nFeatures.Split(",")
            Dim getallfetureId As Integer = 0
            Dim count As Integer = 0
            Dim szDelim1 = " and"
            For Each c In featurelist
                If count = 0 Then
                    szDelim1 = " "
                Else
                    szDelim1 = " , "

                End If
                szSQL &= szDelim1 & c & ""
                count = count + 1
            Next
            szSQL &= " )"

        End If
        If nplotsize > 0 Then
            szSQL &= " and pr.SQM_Plot >=" & nplotsize.ToString.Trim & "  "
        End If
        ' If we are in Top 30 Mode
        If bTop30Mode Then

            ' Add SQL
            szSQL &=
                "and pr.property_ref in " &
                "( " &
                    "select top 50 property_ref " &
                    "from featured_property " &
                    "order by featured_prop_date desc " &
                ") "

        Else

            ' If a Property Type was Specified
            If nTypeID > 0 Then
                szSQL &= "and pr.property_type_id = " & nTypeID.ToString.Trim & " "
            End If

            ' If Minimum Bedrooms was Specified
            If nMinimumBedrooms > 0 Then
                szSQL &= "and pr.bedrooms >= " & nMinimumBedrooms.ToString.Trim & " "
            End If

            ' If Minimum Bathrooms was Specified
            If nMinimumBathrooms > 0 Then
                szSQL &= "and pr.bathrooms >= " & nMinimumBathrooms.ToString.Trim & " "
            End If

            ' If a Minimum Pricing Option was Specified
            If nMinimumPrice > 0 Then
                szSQL &= "and pr.public_price >= " & nMinimumPrice.ToString.Trim & " "
            End If

            ' If a Maximum Pricing Option was Specified
            If nMaximumPrice > 0 Then
                szSQL &= "and pr.public_price <= " & nMaximumPrice.ToString.Trim & " "
            End If

        End If

        ' Init Sort Order
        szSQL &= "Group by pr.property_id,d_type.text,pr.status_id,pr.property_ref , ppr.reference,r.region_name,a.area_name,s.subarea_name,ds.text,d.text,pr.bedrooms, pr.bathrooms,pr.sqm_built,pr.sqm_plot,pr.public_price, pr.original_price"
        If Not nFeatures = "" Then
            szSQL &= " having count(pf.Property_Ref) =" & nFeatures.Split(",").Length
        End If
        szSQL &= " order by pr.public_price"
        ' Order Results depending on the Sort Order
        If eSortOrder = E_Sort_Order.PriceDescending Then
            szSQL &= " desc"
        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function
    Public Function SearchResultsOnlyFeatured(ByVal nLanguageID As Integer, Optional ByVal nPartnerID As Integer = 3873) As DataTable
        Dim szSQL As String =
            "select pr.property_id, " &
                "isnull(d_type.text, '') type, " &
                "pr.status_id status_id, " &
                "pr.property_ref reference, " &
                "isnull(cast(ppr.reference as varchar(10)), pr.property_ref) partner_reference, " &
                "isnull(r.region_name, '') region, " &
                "isnull(a.area_name, '') area, " &
                "isnull(s.subarea_name, '') subarea, " &
                "isnull(ds.text, '') short_description, " &
                "isnull(d.text, '') description, " &
                "pr.bedrooms, " &
                "pr.bathrooms, " &
                "pr.sqm_built, " &
                "pr.sqm_plot, " &
                "pr.public_price price, " &
                "isnull(pr.original_price, 0) original_price " &
                 "from property pr " &
                "inner join postcode pc on pr.postcode_id = pc.postcode_id " &
                "inner join pc_region r on pc.region_id = r.region_id " &
                "inner join pc_area a on pc.area_id = a.area_id " &
                "inner join pc_subarea s on pc.subarea_id = s.subarea_id " &
                "left join property_partner_ref ppr on pr.property_id = ppr.property_id and ppr.partner_id = " & nPartnerID.ToString.Trim & " " &
                "inner join property_type t on pr.property_type_id = t.property_type_id " &
                  "inner join PROPERTY_FEATURES pf on pf.property_ref = pr.property_ref " &
                "left join dictionary d_type on t.dictionary_id = d_type.dictionary_id and (d_type.language_id = 0 or d_type.language_id = " & nLanguageID.ToString.Trim & ") " &
                "left join property_short_desc ds on pr.property_ref = ds.property_ref and ds.language_id = " & nLanguageID.ToString.Trim & " " &
                "left join property_desc d on pr.property_ref = d.property_ref and d.language_id = " & nLanguageID.ToString.Trim & " " &
                "where pr.property_id > 0 " &
                " and pr.display = 1 and pr.property_ref in(select property_ref from FEATURED_PROPERTY) "
        ' Init Sort Order
        szSQL &= "Group by pr.property_id,d_type.text,pr.status_id,pr.property_ref , ppr.reference,r.region_name,a.area_name,s.subarea_name,ds.text,d.text,pr.bedrooms, pr.bathrooms,pr.sqm_built,pr.sqm_plot,pr.public_price, pr.original_price"
        szSQL &= " order by pr.public_price"
        ' Return the Result
        Return GetDataAsDataTable(szSQL)
    End Function


    Public Function PaymentTypes() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select p.Payment_Type_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch " &
            "from PAYMENT_TYPE p " &
                "left join DICTIONARY english on p.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on p.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on p.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on p.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on p.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyStatus() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select ps.Status_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch " &
            "from PROPERTY_STATUS ps " &
                "left join DICTIONARY english on ps.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on ps.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on ps.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on ps.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on ps.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyStatus(ByVal nLanguageID As Integer) As DataTable
        Return GetDataAsDataTable("select p.status_id id, d.text text from property_status p inner join dictionary d on p.dictionary_id = d.dictionary_id where d.language_id = " & nLanguageID.ToString.Trim & " order by d.text")
    End Function

    Public Function PropertyFeatures() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select pf.Features_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch " &
            "from FEATURES pf " &
                "left join DICTIONARY english on pf.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on pf.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on pf.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on pf.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on pf.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function BuyerCriterias() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select bc.Criteria_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch,isnull(english.Text, 'Auto Translate') text " &
            "from Criterias bc " &
                "left join DICTIONARY english on bc.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on bc.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on bc.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on bc.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on bc.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by bc.sort_by asc"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function OnlyBuyerCriterias() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select * from (" &
            "select Criteria_Id,Dictionary_ID," &
            "(select text from dictionary where dictionary_id=Criterias.Dictionary_ID and language_Id=1) 'text'" &
        "From Criterias where Criteria_Id in(select distinct Criterias_Id from Buyer_Criterias)) Buyer_Criterias order by text asc"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function OnlyBuyerCriterias_BySalesPerson(ByVal SalesPersonId As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select Criteria_Id,Dictionary_ID," &
            "(select text from dictionary where dictionary_id=Criterias.Dictionary_ID and language_Id=1) 'text'" &
        "From Criterias where Criteria_Id in(select distinct Criterias_Id from Buyer_Criterias " &
        " where buyer_Id in(select buyer_id from buyer where Buyer_Salesperson_ID=" & SalesPersonId & ")) "

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyTypes() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select pt.Property_Type_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch, pt.Property_Code Code " &
            "from PROPERTY_TYPE pt " &
                "left join DICTIONARY english on pt.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on pt.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on pt.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on pt.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on pt.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyTypes(ByVal nLanguageID As Integer) As DataTable
        Return GetDataAsDataTable("select p.property_type_id id, d.text text from property_type p inner join dictionary d on p.dictionary_id = d.dictionary_id where d.language_id = " & nLanguageID.ToString.Trim & " order by d.text")
    End Function

    Public Function PriceTo(ByVal nLanguageID As Integer) As DataTable
        Return GetDataAsDataTable("select p.price_to_value id, (replace(d.text, '''''', '''') + ' ' + ltrim(rtrim(substring(ltrim(rtrim(cast(p.price_to_value as varchar(10)))), 0, len(ltrim(rtrim(cast(p.price_to_value as varchar(10))))) - 2) + '.' + substring(ltrim(rtrim(cast(p.price_to_value as varchar(10)))), len(ltrim(rtrim(cast(p.price_to_value as varchar(10))))) - 2, len(ltrim(rtrim(cast(p.price_to_value as varchar(10)))))))) + ' Euros') text " &
                                    "from dictionary d inner join price_to p on p.dictionary_id = d.dictionary_id " &
                                    "where d.language_id = " & nLanguageID.ToString.Trim & " " &
                                    "order by p.price_to_value")
    End Function

    Public Function PriceToValuesOnly() As DataTable
        Return GetDataAsDataTable("select p.price_to_value id, (ltrim(rtrim(substring(ltrim(rtrim(cast(p.price_to_value as varchar(10)))), 0, len(ltrim(rtrim(cast(p.price_to_value as varchar(10))))) - 2) + '.' + substring(ltrim(rtrim(cast(p.price_to_value as varchar(10)))), len(ltrim(rtrim(cast(p.price_to_value as varchar(10))))) - 2, len(ltrim(rtrim(cast(p.price_to_value as varchar(10)))))))) + ' Euros') text " &
                                    "from price_to p " &
                                    "order by p.price_to_value")
    End Function

    Public Function SearchHasResults(Optional ByVal nRegionID As Integer = 0,
                                     Optional ByVal nAreaID As Integer = 0,
                                     Optional ByVal nSubAreaID As Integer = 0,
                                     Optional ByVal nTypeID As Integer = 0,
                                     Optional ByVal nMinBeds As Integer = 0,
                                     Optional ByVal nMinBaths As Integer = 0,
                                     Optional ByVal nMinPrice As Integer = 0,
                                     Optional ByVal nMaxPrice As Integer = 0
                                     ) As Boolean

        ' Local Vars
        Dim szSQL As String
        Dim szDelim As String = " and "
        Dim bRetVal As Boolean

        ' Init SQL
        szSQL = "select count(*) " &
            "from property p " &
                "inner join postcode pc on p.postcode_id = pc.postcode_id " &
            "where p.display = 1"

        ' If a Region has been Provided
        If nRegionID > 0 Then

            ' Add to Query
            szSQL &= szDelim & "pc.region_id = " & nRegionID.ToString.Trim

        End If

        ' If an Area has been Provided
        If nAreaID > 0 Then

            ' Add to Query
            szSQL &= szDelim & "pc.area_id = " & nAreaID.ToString.Trim

        End If

        ' If a SubArea has been Provided
        If nSubAreaID > 0 Then

            ' Add to Query
            szSQL &= szDelim & "pc.subarea_id = " & nSubAreaID.ToString.Trim

        End If

        ' If a Type has been Provided
        If nTypeID > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.property_type_id = " & nTypeID.ToString.Trim

        End If

        ' If Minimum Bedrooms has been Provided
        If nMinBeds > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.bedrooms >= " & nMinBeds.ToString.Trim

        End If

        ' If Minimum Bathrooms has been Provided
        If nMinBaths > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.bathrooms >= " & nMinBaths.ToString.Trim

        End If

        ' If a Minimum Price has been Provided
        If nMinPrice > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.public_price >= " & nMinPrice.ToString.Trim

        End If

        ' If a Maximum Price has been Provided
        If nMaxPrice > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.public_price <= " & nMaxPrice.ToString.Trim

        End If

        ' Check if we have Results
        If GetDataAsInteger(szSQL) > 0 Then
            bRetVal = True
        Else
            bRetVal = False
        End If

        ' Return the Result
        Return bRetVal

    End Function





    Public Function SearchHasResultsNew(Optional ByVal nRegionID As Integer = 0,
                                     Optional ByVal nAreaID As Integer = 0,
                                     Optional ByVal nSubAreaID As Integer = 0,
                                     Optional ByVal nTypeID As Integer = 0,
                                     Optional ByVal nMinBeds As Integer = 0,
                                     Optional ByVal nMinBaths As Integer = 0,
                                     Optional ByVal nMinPrice As Integer = 0,
                                     Optional ByVal nMaxPrice As Integer = 0,
                                         Optional ByVal nFeature As String = "",
                                          Optional ByVal nplotsize As Integer = 0
                                     ) As Boolean

        ' Local Vars
        Dim szSQL As String
        Dim szDelim As String = " and "
        Dim bRetVal As Boolean

        ' Init SQL
        szSQL = "select count(*) " &
            "from property p " &
                "inner join postcode pc on p.postcode_id = pc.postcode_id " &
                  "inner join PROPERTY_FEATURES pf on pf.Property_Ref= p.Property_Ref " &
            "where p.display = 1"

        ' If a Region has been Provided
        If nRegionID > 0 Then

            ' Add to Query
            szSQL &= szDelim & "pc.region_id = " & nRegionID.ToString.Trim

        End If

        ' If an Area has been Provided
        If nAreaID > 0 Then

            ' Add to Query
            szSQL &= szDelim & "pc.area_id = " & nAreaID.ToString.Trim

        End If

        ' If a SubArea has been Provided
        If nSubAreaID > 0 Then

            ' Add to Query
            szSQL &= szDelim & "pc.subarea_id = " & nSubAreaID.ToString.Trim

        End If

        ' If a Type has been Provided
        If nTypeID > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.property_type_id = " & nTypeID.ToString.Trim

        End If

        ' If Minimum Bedrooms has been Provided
        If nMinBeds > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.bedrooms >= " & nMinBeds.ToString.Trim

        End If

        ' If Minimum Bathrooms has been Provided
        If nMinBaths > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.bathrooms >= " & nMinBaths.ToString.Trim

        End If

        ' If a Minimum Price has been Provided
        If nMinPrice > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.public_price >= " & nMinPrice.ToString.Trim

        End If

        ' If a Maximum Price has been Provided
        If nMaxPrice > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.public_price <= " & nMaxPrice.ToString.Trim

        End If
        If Not nFeature = "" Then
            szSQL &= "and pf.Features_ID In ( "
            Dim featurelist = nFeature.Split(",")
            Dim getallfetureId As Integer = 0
            Dim count As Integer = 0
            Dim szDelim1 = " and"
            For Each c In featurelist
                If count = 0 Then
                    szDelim1 = " "
                Else
                    szDelim1 = " , "

                End If
                szSQL &= szDelim1 & c & ""
                count = count + 1
            Next
            szSQL &= " )"

        End If
        ' Add to Query
        If nplotsize > 0 Then

            ' Add to Query
            szSQL &= szDelim & "p.SQM_Plot >= " & nplotsize.ToString.Trim

        End If
        szSQL &= szDelim & " p.status_id = 2 "
        If Not nFeature = "" Then
            szSQL &= " group by pf.Property_Ref having count(pf.Property_Ref)= " & nFeature.Split(",").Length
        End If
        ' Check if we have Results
        If GetDataAsInteger(szSQL) > 0 Then
            bRetVal = True
        Else
            bRetVal = False
        End If

        ' Return the Result
        Return bRetVal

    End Function


    Public Function SearchHasResults(ByVal szPropertyRef As String) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean

        ' Check if we have Results
        If GetDataAsInteger("select count(*) from property where display = 1 and upper(property_ref) = '" & szPropertyRef.ToUpper.Trim & "'") > 0 Then
            bRetVal = True
        Else
            bRetVal = False
        End If

        ' Return the Result
        Return bRetVal

    End Function

    Public Function PropertyLocations() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select l.Location_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch " &
            "from LOCATION l " &
                "left join DICTIONARY english on l.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on l.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on l.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on l.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on l.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "where Location_ID > 0 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyLocations(ByVal nLanguageID As Integer,
                                        Optional ByVal nRegionID As Integer = 0,
                                        Optional ByVal nAreaID As Integer = 0) As DataTable

        ' Local Vars
        Dim szSQL As String = "select p.property_id, " &
                                "p.property_ref, " &
                                "dict_location.text location, " &
                                "dict_type.text type, " &
                                "p.public_price price, " &
                                "isnull(p.gps_latitude, 0) latitude, " &
                                "isnull(p.gps_longitude, 0) longitude, " &
                                "p.status_id status_id " &
                                "from property p " &
                                    "inner join location l on p.location_id = l.location_id " &
                                    "inner join dictionary dict_location on dict_location.dictionary_id = l.dictionary_id " &
                                    "inner join property_type t on p.property_type_id = t.property_type_id " &
                                    "inner join dictionary dict_type on dict_type.dictionary_id = t.dictionary_id " &
                                "where p.gps_latitude <> 0 " &
                                    "and p.display = 1 " &
                                    "and (dict_location.language_id = " & nLanguageID.ToString.Trim & ") " &
                                    "and (dict_type.language_id = " & nLanguageID.ToString.Trim & ")"

        ' If we have had a Region & Area Supplied
        If nRegionID <> 0 And nAreaID <> 0 Then

            ' Add this to the Query
            szSQL &= " " &
                    "and p.postcode_id in " &
                    "(" &
                        "select postcode_id " &
                        "from postcode " &
                        "where region_id = " & nRegionID.ToString.Trim & " " &
                            "and area_id = " & nAreaID.ToString.Trim &
                    ")"

        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function
    Public Function PropertyLocationsTest(ByVal nLanguageID As Integer,
                                        Optional ByVal nRegionID As Integer = 0,
                                        Optional ByVal nAreaID As Integer = 0) As DataTable

        ' Local Vars
        Dim szSQL As String = "select isnull(p.gps_latitude, 0) latitude,  " &
             "isnull(p.gps_longitude, 0) longitude, " &
             " p.property_id," &
                                "p.property_ref, " &
                                "dict_location.text location, " &
                                "dict_type.text type, " &
                                "p.public_price price, " &
                                "p.status_id status_id " &
                                  "('')url" &
                                   "('')formatprice" &
                                "from property p " &
                                    "inner join location l on p.location_id = l.location_id " &
                                    "inner join dictionary dict_location on dict_location.dictionary_id = l.dictionary_id " &
                                    "inner join property_type t on p.property_type_id = t.property_type_id " &
                                    "inner join dictionary dict_type on dict_type.dictionary_id = t.dictionary_id " &
                                "where p.gps_latitude <> 0 " &
                                    "and p.display = 1 " &
                                    "and (dict_location.language_id = " & nLanguageID.ToString.Trim & ") " &
                                    "and (dict_type.language_id = " & nLanguageID.ToString.Trim & ")"

        ' If we have had a Region & Area Supplied
        If nRegionID <> 0 And nAreaID <> 0 Then

            ' Add this to the Query
            szSQL &= " " &
                    "and p.postcode_id in " &
                    "(" &
                        "select postcode_id " &
                        "from postcode " &
                        "where region_id = " & nRegionID.ToString.Trim & " " &
                            "and area_id = " & nAreaID.ToString.Trim &
                    ")"

        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function FeaturedProperties(ByVal nLanguageID As Integer, Optional ByVal b51Properties As Boolean = False) As DataTable

        Dim szSQL As String =
            "select pr.property_id, " &
                "pr.property_ref, " &
                "d_type.text type, " &
                "r.region_name region, " &
                "a.area_name area, " &
                "pr.public_price price, " &
                "isnull(pr.original_price, 0) original_price, " &
                "pr.status_id status_id " &
            "from property pr " &
                "inner join postcode pc on pc.postcode_id = pr.postcode_id " &
                "inner join pc_region r on r.region_id = pc.region_id " &
                "inner join pc_area a on a.area_id = pc.area_id " &
                "inner join property_type t on pr.property_type_id = t.property_type_id " &
                "left join dictionary d_type on t.dictionary_id = d_type.dictionary_id and (d_type.language_id = 0 or d_type.language_id = " & nLanguageID.ToString.Trim & ") " &
                "inner join " &
                "(" &
                    "select top "

        ' If 51 Properties
        If b51Properties Then
            szSQL &= "51"
        Else
            szSQL &= "50"
        End If

        ' Continue to Init SQL
        szSQL &=
                        " property_ref, sort_order " &
                    "from featured_property " &
                    "order by featured_prop_date desc " &
                ") t1 on pr.Property_Ref = t1.Property_Ref " &
            "order by t1.sort_order"

        ' Retrun the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyCountsInAreas(ByVal eRegion As E_Region, ByVal alAreaIDs As ArrayList) As DataTable

        ' Local Vars
        Dim szDelim As String = String.Empty

        ' Init SQL
        Dim szSQL As String =
            "select a.area_name, count(p.property_id) num " &
            "from " &
            "(" &
                "select area_id " &
                "from " &
                "(" &
                    "VALUES "

        ' For each Area ID
        For Each nAreaID As Integer In alAreaIDs

            ' Add this Area ID to the Query
            szSQL &= szDelim & "(" & nAreaID.ToString.Trim & ")"

            ' Set Delimiter
            szDelim = ", "

        Next

        ' Continue to Init SQL
        szSQL &=
                ") " &
                "V(area_id) " &
            ") t1 " &
                "left join postcode pc on t1.area_id = pc.Area_ID and pc.Region_ID = " & Convert.ToInt32(eRegion).ToString.Trim & " " &
                "inner join PC_AREA a on pc.Area_ID = a.Area_ID " &
                "left join PROPERTY p on pc.Postcode_ID = p.Postcode_ID and p.Display = 1 " &
            "group by t1.area_id, a.area_name " &
            "order by a.Area_Name"

        ' Get the Result
        Dim dtDataTable As DataTable = GetDataAsDataTable(szSQL)

        ' Return the Result
        Return dtDataTable

    End Function

    Public Function Testimonials() As DataTable
        Return GetDataAsDataTable("select testimonial_id, testimonial_date, replace(testimonial_text, '''''', '''') testimonial_text from testimonials order by testimonial_date desc")
    End Function

    Public Function MapCenterPoint() As DataTable
        Return GetDataAsDataTable("select avg(gps_latitude) latitude, avg(gps_longitude) longitude from property where display = 1 and gps_latitude <> 0")
    End Function

    Public Function PropertyID(ByVal szPropertyRef As String, Optional ByVal nPartnerID As Integer = 0, Optional ByVal bIgnoreDisplay As Boolean = False) As Integer

        ' Local Vars
        Dim szSQL As String

        ' If Power User
        If nPartnerID = -1 Then

            ' Init SQL
            szSQL =
                "select p.Property_ID " &
                "from PROPERTY p " &
                    "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID " &
                "where p.Property_Ref = '" & szPropertyRef.Trim.ToUpper & "' or cast(pr.Reference as varchar) = '" & szPropertyRef.Trim.ToUpper & "'"

            ' Are we Filtering by Display
            If Not bIgnoreDisplay Then
                szSQL &= " and p.display = 1"
            End If

        ElseIf nPartnerID > 0 Then

            ' We have a Partner ID

            ' Partner
            szSQL =
                "if exists (select 1 from property_partner_ref where partner_id = " & nPartnerID.ToString.Trim & " and ltrim(rtrim(upper(cast(reference as varchar(10))))) = '" & szPropertyRef.Trim.ToUpper & "') " &
                "begin " &
                    "select p.property_id " &
                    "from property_partner_ref ref " &
                        "inner join property p on ref.property_id = p.property_id " &
                    "where "

            ' Are we Filtering by Display
            If Not bIgnoreDisplay Then
                szSQL &= "p.display = 1 and "
            End If

            ' Continue to Init SQL
            szSQL &=
                "ref.partner_id = " & nPartnerID.ToString.Trim & " and ltrim(rtrim(upper(cast(ref.reference as varchar(10))))) = '" & szPropertyRef.Trim.ToUpper & "' " &
                "end " &
                "else " &
                "begin " &
                    "select property_id " &
                    "from property " &
                    "where "

            ' Are we Filtering by Display
            If Not bIgnoreDisplay Then
                szSQL &= "display = 1 and "
            End If

            ' Continue to Init SQL
            szSQL &=
                    "ltrim(rtrim(upper(property_ref))) = '" & szPropertyRef.Trim.ToUpper & "' " &
                "end"

        Else

            ' IA
            szSQL = "select property_id from property where "

            ' Are we Filtering by Display
            If Not bIgnoreDisplay Then
                szSQL &= "display = 1 and "
            End If

            ' Continue to Init SQL
            szSQL &=
                "ltrim(rtrim(upper(property_ref))) = '" & szPropertyRef.Trim.ToUpper & "'"

        End If

        ' Return the Result
        Return GetDataAsInteger(szSQL)

    End Function

    Public Function PropertyRef(ByVal nPropertyID As Integer) As String
        Return GetDataAsString("select ltrim(rtrim(upper(property_ref))) from property where property_id = " & nPropertyID.ToString.Trim)
    End Function

    Public Function PropertyIARef(ByVal nPartnerID As Integer, ByVal szExternalRef As String) As String

        ' Local Vars
        Dim szSQL As String =
            "select p.property_ref " &
            "from PROPERTY p " &
                "left join PROPERTY_PARTNER_REF pr on p.property_id = pr.property_id and pr.partner_id = " & nPartnerID.ToString.Trim & " " &
            "where ltrim(rtrim(upper(pr.reference))) = '" & szExternalRef.Trim.ToUpper & "'"

        ' Get the Result
        Dim szRetVal As String = GetDataAsString(szSQL)

        ' If Null
        If szRetVal.Trim = String.Empty Then
            Return szExternalRef
        Else
            Return szRetVal
        End If

    End Function

    Public Function PartnerEmail(ByVal szPropertyRef As String) As String
        Return GetDataAsString("select ltrim(rtrim(lower(contact_email))) email from contact c inner join property p on p.partner_id = c.contact_id where p.property_ref = '" & szPropertyRef.ToUpper.Trim & "'")
    End Function

    Public Function PartnerName(ByVal szPropertyRef As String) As String
        Return GetDataAsString("select contact_name from contact c inner join property p on p.partner_id = c.contact_id where p.property_ref = '" & szPropertyRef.ToUpper.Trim & "'")
    End Function

    Public Function PartnerID(ByVal nContactID As Integer) As Integer
        Return GetDataAsInteger("select contact_partner_id from CONTACT where Contact_ID = " & nContactID.ToString.Trim)
    End Function


    Public Function GetRegionForProperty(ByVal nPropertyID As Integer) As Integer

        ' Init SQL
        Dim szSQL As String =
            "select r.region_id " &
            "from pc_region r " &
                "inner join postcode pc on r.region_id = pc.region_id " &
                "inner join property p on pc.postcode_id = p.postcode_id " &
            "where p.property_id = " & nPropertyID.ToString.Trim

        Return GetDataAsInteger(szSQL)

    End Function

#Region "Translation Access"

    Public Function GetTranslation(ByVal szText As String, ByVal obj As Object, Optional ByVal bHTMLSafe As Boolean = False) As String

        Dim szRetVal As String

        ' Check if NULL
        If obj Is Nothing Then

            ' Return Original Text (Default English)
            szRetVal = szText.TrimEnd

        Else

            ' Dependent on Type, Return the Translation
            If TypeOf (obj) Is String Then
                szRetVal = GetTranslation(szText, Convert.ToString(obj))
            Else
                szRetVal = GetTranslation(szText, Convert.ToInt32(obj))
            End If

        End If

        ' If this is to be HTML Safe
        If bHTMLSafe Then

            ' Replace all UniCode Characters
            szRetVal = MakeHTMLSafe(szRetVal)

        End If

        ' Return the Result
        Return szRetVal

    End Function
    Public Sub AddReferral(ByVal szReferrer As String, ByVal szURL As String)

        ' If we have all the Info Required
        If Not szReferrer Is Nothing And Not szURL Is Nothing Then

            ' Init SQL
            Dim szSQL As String = "insert into referral (referrer_id, referral_url) " &
                                    "select referrer_id, '" & szURL.ToLower.Trim & "' from referrer where lower(ltrim(rtrim(referrer_name))) = '" & szReferrer.ToLower.Trim & "'"

            ' Insert Referral
            Execute(szSQL)

        End If

    End Sub
    Private Function GetTranslation(ByVal szText As String, ByVal szLanguage As String, Optional ByVal bHTMLSafe As Boolean = False) As String

        ' Depending on the Language
        Select Case szLanguage.Trim.ToLower

            Case "spanish"
                Return GetTranslation(szText, 2, bHTMLSafe)

            Case "french"
                Return GetTranslation(szText, 3, bHTMLSafe)

            Case "german"
                Return GetTranslation(szText, 4, bHTMLSafe)

            Case "dutch"
                Return GetTranslation(szText, 5, bHTMLSafe)

            Case Else
                Return szText.Trim

        End Select

    End Function

    Public Function GetTranslation(ByVal szText As String, ByVal nLanguageID As Integer, Optional ByVal bHTMLSafe As Boolean = False) As String

        ' Local Vars
        Dim szSQL As String
        Dim szTranslation As String = String.Empty

        ' If we have Text to Translate
        If szText.Trim <> String.Empty Then

            ' Get the Hash Code for this Text
            Dim nHashCode As Integer = szText.Trim.GetHashCode

            ' See if we have the Translation - Init SQL
            szSQL =
                "merge translation as target using " &
                "( " &
                    "select " &
                    nHashCode.ToString.Trim & ", " &
                    nLanguageID.ToString.Trim & ", " &
                    "'" & szText.Replace("'", "''").Trim & "', " &
                    SQLDateTime(Now) & " " &
                ") " &
                "as source " &
                "( " &
                    "Hash_Code, " &
                    "Language_ID, " &
                    "Text, " &
                    "Added " &
                ") " &
                "on target.Hash_Code = source.Hash_Code and target.Language_ID = source.Language_ID " &
                "when not matched then " &
                "insert " &
                "( " &
                    "Hash_Code, " &
                    "Language_ID, " &
                    "Text, " &
                    "Added " &
                ") " &
                "values " &
                "( " &
                    "source.Hash_Code, " &
                    "source.Language_ID, " &
                    "source.Text, " &
                    "source.Added " &
                "); " &
                "select text from translation where hash_code = " & nHashCode.ToString.Trim & " and language_id = " & nLanguageID.ToString.Trim & ";"

            ' Get the Result
            szTranslation = GetDataAsString(szSQL).Replace("''", "'").Trim

            ' If we have no Result
            If szTranslation.Trim = String.Empty Then

                ' Translation not found, we need to Add
                Dim CUtilities As New ClassUtilities

                ' Translate the Text
                szTranslation = CUtilities.Translate(szText, nLanguageID)

                ' Add this to the Database
                AddTranslation(nHashCode, nLanguageID, szTranslation.Trim)

            Else

                ' We have the Translation - are we recording Stats?
                If System.Configuration.ConfigurationManager.AppSettings("TranslationStats") = "true" Then

                    ' Add a Time Stamp for Accessed
                    Execute("update translation set accessed = getdate() where hash_code = " & nHashCode.ToString.Trim & " and language_id = " & nLanguageID.ToString.Trim)

                End If

            End If

            ' If this is to be HTML Safe
            If bHTMLSafe Then

                ' Replace all UniCode Characters
                szTranslation = MakeHTMLSafe(szTranslation)

            End If

            ' Remove Possible \u200b \u003cbr /\u003e
            szTranslation = szTranslation.Replace("\u200b", String.Empty)
            szTranslation = szTranslation.Replace("\u003cbr", String.Empty)
            szTranslation = szTranslation.Replace("/\u003e", String.Empty)

        End If

        ' Return the Result
        Return szTranslation.Trim

    End Function

    Private Function GetDictionaryID(ByVal nLanguageID As Integer, ByVal szText As String) As Integer

        ' Init SQL
        Dim szSQL As String =
            "if exists " &
            "( " &
                "select Dictionary_ID " &
                "from DICTIONARY " &
                "where Language_ID = " & nLanguageID.ToString.Trim & " and TEXT = '" & szText.Trim & "' " &
            ") " &
            "BEGIN " &
                "select Dictionary_ID " &
                "from DICTIONARY " &
                "where Language_ID = " & nLanguageID.ToString.Trim & " and TEXT = '" & szText.Trim & "' " &
            "END " &
            "ELSE " &
            "BEGIN " &
                "set identity_insert dictionary on; " &
                "insert into DICTIONARY (Dictionary_ID, Language_ID, Text) values ((select MAX(Dictionary_ID) + 1 from DICTIONARY), " & nLanguageID.ToString.Trim & ", '" & szText.Trim & "'); " &
                "select MAX(Dictionary_ID) from DICTIONARY; " &
                "set identity_insert dictionary off; " &
            "END;"

        ' Return the ID
        Return GetDataAsInteger(szSQL)

    End Function

    Private Function MakeHTMLSafe(ByVal szString As String) As String

        Return szString _
            .Replace("%", "%25") _
            .Replace(" ", "%20") _
            .Replace("!", "%21") _
            .Replace(Chr(34), "%22") _
            .Replace("$", "%24") _
            .Replace("'", "%27") _
            .Replace("(", "%28") _
            .Replace(")", "%29") _
            .Replace("*", "%2A") _
            .Replace("+", "%2B") _
            .Replace(",", "%2C") _
            .Replace("-", "%2D") _
            .Replace(".", "%2E") _
            .Replace("/", "%2F") _
            .Replace(":", "%3A") _
            .Replace("<", "%3C") _
            .Replace("=", "%3D") _
            .Replace(">", "%3E") _
            .Replace("?", "%3F") _
            .Replace("@", "%40") _
            .Replace("[", "%5B") _
            .Replace("\", "%5C") _
            .Replace("]", "%5D") _
            .Replace("^", "%5E") _
            .Replace("_", "%5F") _
            .Replace("`", "%60") _
            .Replace("{", "%7B") _
            .Replace("|", "%7C") _
            .Replace("}", "%7D") _
            .Replace("~", "%7E") _
            .Replace("`", "%80") _
            .Replace("¡", "%A1") _
            .Replace("¢", "%A2") _
            .Replace("£", "%A3") _
            .Replace("¤", "%A4") _
            .Replace("¥", "%A5") _
            .Replace("¦", "%A6") _
            .Replace("§", "%A7") _
            .Replace("¨", "%A8") _
            .Replace("©", "%A9") _
            .Replace("ª", "%AA") _
            .Replace("«", "%AB") _
            .Replace("¬", "%AC") _
            .Replace("®", "%AE") _
            .Replace("¯", "%AF") _
            .Replace("°", "%B0") _
            .Replace("±", "%B1") _
            .Replace("²", "%B2") _
            .Replace("³", "%B3") _
            .Replace("´", "%B4") _
            .Replace("µ", "%B5") _
            .Replace("¶", "%B6") _
            .Replace("·", "%B7") _
            .Replace("¸", "%B8") _
            .Replace("¹", "%B9") _
            .Replace("º", "%BA") _
            .Replace("»", "%BB") _
            .Replace("¼", "%BC") _
            .Replace("½", "%BD") _
            .Replace("¾", "%BE") _
            .Replace("¿", "%BF") _
            .Replace("À", "%C0") _
            .Replace("Á", "%C1") _
            .Replace("Â", "%C2") _
            .Replace("Ã", "%C3") _
            .Replace("Ä", "%C4") _
            .Replace("Å", "%C5") _
            .Replace("Æ", "%C6") _
            .Replace("Ç", "%C7") _
            .Replace("È", "%C8") _
            .Replace("É", "%C9") _
            .Replace("Ê", "%CA") _
            .Replace("Ë", "%CB") _
            .Replace("Ì", "%CC") _
            .Replace("Í", "%CD") _
            .Replace("Î", "%CE") _
            .Replace("Ï", "%CF") _
            .Replace("Ð", "%D0") _
            .Replace("Ñ", "%D1") _
            .Replace("Ò", "%D2") _
            .Replace("Ó", "%D3") _
            .Replace("Ô", "%D4") _
            .Replace("Õ", "%D5") _
            .Replace("Ö", "%D6") _
            .Replace("×", "%D7") _
            .Replace("Ø", "%D8") _
            .Replace("Ù", "%D9") _
            .Replace("Ú", "%DA") _
            .Replace("Û", "%DB") _
            .Replace("Ü", "%DC") _
            .Replace("Ý", "%DD") _
            .Replace("Þ", "%DE") _
            .Replace("ß", "%DF") _
            .Replace("à", "%E0") _
            .Replace("á", "%E1") _
            .Replace("â", "%E2") _
            .Replace("ã", "%E3") _
            .Replace("ä", "%E4") _
            .Replace("å", "%E5") _
            .Replace("æ", "%E6") _
            .Replace("ç", "%E7") _
            .Replace("è", "%E8") _
            .Replace("é", "%E9") _
            .Replace("ê", "%EA") _
            .Replace("ë", "%EB") _
            .Replace("ì", "%EC") _
            .Replace("í", "%ED") _
            .Replace("î", "%EE") _
            .Replace("ï", "%EF") _
            .Replace("ð", "%F0") _
            .Replace("ñ", "%F1") _
            .Replace("ò", "%F2") _
            .Replace("ó", "%F3") _
            .Replace("ô", "%F4") _
            .Replace("õ", "%F5") _
            .Replace("ö", "%F6") _
            .Replace("÷", "%F7") _
            .Replace("ø", "%F8") _
            .Replace("ù", "%F9") _
            .Replace("ú", "%FA") _
            .Replace("û", "%FB") _
            .Replace("ü", "%FC") _
            .Replace("ý", "%FD") _
            .Replace("þ", "%FE") _
            .Replace("ÿ", "%FF")

    End Function

    Private Sub AddTranslation(ByVal nHashCode As Integer, ByVal nLanguageID As Integer, ByVal szText As String)

        ' If we have Text to Translate
        If szText.Trim <> String.Empty Then

            ' Init SQL
            Dim szSQL As String = "insert into translation (hash_code, language_id, text, added) values (" & nHashCode.ToString.Trim & ", " & nLanguageID.ToString.Trim & ", '" & szText.Replace("'", "''").Trim & "', " & SQLDateTime(Now) & ")"

            Using sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("IA").ToString)

                'Try

                ' Init Command
                Dim sqlCommand As New SqlCommand(szSQL, sqlConnection)

                ' Open the Database
                sqlConnection.Open()

                ' Insert the Translation
                sqlCommand.ExecuteNonQuery()

                ' Tidy
                sqlCommand.Dispose()

                'Catch ex As Exception
                ' TODO
                'End Try

                ' Tidy
                sqlConnection.Close()

            End Using

        End If

    End Sub

#End Region

#Region "Utilities"

    Public Sub RecordBotAttack(ByVal szIPAddress As String)

        ' Init SQL
        Dim szSQL As String = "insert into bot_attacks (source_ip) values ('" & szIPAddress.Trim & "')"

        Using sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("IA").ToString)

            'Try

            ' Init Command
            Dim sqlCommand As New SqlCommand(szSQL, sqlConnection)

            ' Open the Database
            sqlConnection.Open()

            ' Insert the Translation
            sqlCommand.ExecuteNonQuery()

            ' Tidy
            sqlCommand.Dispose()

            'Catch ex As Exception
            ' TODO
            'End Try

            ' Tidy
            sqlConnection.Close()

        End Using

    End Sub

    Public Function DBSafe(ByVal objItem As Object, ByVal nDefault As Integer) As Integer

        Dim nRetVar As Integer = nDefault

        If Not IsDBNull(objItem) Then

            If objItem.ToString.Trim <> String.Empty Then

                nRetVar = Convert.ToInt32(objItem)

            End If

        End If

        Return nRetVar

    End Function

    Public Function DBSafe(ByVal objItem As Object, ByVal nDefault As Long) As Long

        Dim nRetVar As Long = nDefault

        If Not IsDBNull(objItem) Then

            If objItem.ToString.Trim <> String.Empty Then

                nRetVar = Convert.ToInt64(objItem)

            End If

        End If

        Return nRetVar

    End Function

    Public Function DBSafe(ByVal objItem As Object, ByVal dDefault As Double) As Double

        Dim dRetVar As Double = dDefault

        If Not IsDBNull(objItem) Then

            If TypeOf (objItem) Is Decimal Then

                dRetVar = Convert.ToDouble(objItem)

            End If

        End If

        Return dRetVar

    End Function

    Public Function DBSafe(ByVal objItem As Object, Optional ByVal szDefault As String = vbNullString) As String

        Dim szRetVar As String = szDefault

        If Not IsDBNull(objItem) Then
            szRetVar = Convert.ToString(objItem).Trim
        End If

        Return szRetVar

    End Function

    Public Function DBSafe(ByVal objItem As Object, ByVal dtDefault As Date) As Date

        Dim dtRetVar As Date = dtDefault

        If Not IsDBNull(objItem) Then

            dtRetVar = Convert.ToDateTime(objItem)

        End If

        Return dtRetVar

    End Function

    Public Function DBSafe(ByVal objItem As Object, ByVal bDefault As Boolean) As Boolean

        Dim bRetVar As Boolean = bDefault

        If Not IsDBNull(objItem) Then

            bRetVar = Convert.ToBoolean(objItem)

        End If

        Return bRetVar

    End Function

    Public Function SQLBoolean(ByVal bValue As Boolean) As String

        If bValue Then
            Return "1"
        Else
            Return "0"
        End If

    End Function

    Public Function SQLDateTime(ByVal dtDateTime As DateTime) As String

        ' Form String
        Return "'" & dtDateTime.Year & "-" & dtDateTime.Month & "-" & dtDateTime.Day & " " & dtDateTime.Hour & ":" & dtDateTime.Minute & ":" & dtDateTime.Second & "'"

    End Function

    Public Function SendMessageIPCheck(ByVal szIPAddress As String) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean = False

        ' Housekeeping
        Dim szSQL As String =
            "delete from MESSAGE_IP_LOG where where message_sent < DATEADD(DAY, -1, GETDATE());"
        Execute(szSQL)

        ' Get the Message Count in the last 24 Hours
        szSQL =
            "select count(*) from MESSAGE_IP_LOG where ip_address = '" & szIPAddress.Trim & "';"
        Dim nCount As Integer = GetDataAsInteger(szSQL)

        ' If Valid
        If nCount < 3 Then

            ' Log this Message
            szSQL = "insert into MESSAGE_IP_LOG (ip_address) values ('" & szIPAddress.Trim & "');"
            Execute(szSQL)

            ' Set the Return Variable
            bRetVal = True

        End If

        ' Return the Result
        Return bRetVal

    End Function

#End Region

#Region "Back Office"

    Public Function GetNextPropertyRef(ByVal ePropertyTypeID As E_PropertyType) As String

        ' Local Vars
        Dim szRetVal As String = String.Empty
        Dim szSQL As String

        ' Init SQL
        szSQL =
            "select top 1 cast(substring(property_ref, 3, 10) as integer) + 1 id " &
            "from property " &
            "where Property_Ref like '"

        ' Depending on the Property Type
        Select Case ePropertyTypeID

            Case E_PropertyType.Apartment
                ' Apartment
                szSQL &= "AP"
                szRetVal = "AP"

            Case E_PropertyType.Bar
                ' Bar
                szSQL &= "BA"
                szRetVal = "BA"

            Case E_PropertyType.Chalet
                ' Chalet
                szSQL &= "CH"
                szRetVal = "CH"

            Case E_PropertyType.CoastProperty
                ' Coast Property
                szSQL &= "CP"
                szRetVal = "CP"

            Case E_PropertyType.Commercial
                ' Commercial
                szSQL &= "CM"
                szRetVal = "CM"

            Case E_PropertyType.Cortijo
                ' Cortijo
                szSQL &= "CJ"
                szRetVal = "CJ"

            Case E_PropertyType.Duplex
                ' Duplex
                szSQL &= "DP"
                szRetVal = "DP"

            Case E_PropertyType.Finca
                ' Finca
                szSQL &= "FI"
                szRetVal = "FI"

            Case E_PropertyType.NewBuild
                ' New Build
                szSQL &= "PJ"
                szRetVal = "PJ"

            Case E_PropertyType.Plot
                ' Plot
                szSQL &= "PL"
                szRetVal = "PL"

            Case E_PropertyType.TownHouse
                ' Town House
                szSQL &= "TH"
                szRetVal = "TH"

            Case Else
                ' Villa
                szSQL &= "VL"
                szRetVal = "VL"

        End Select

        ' Continue to Prep SQL
        szSQL &=
            "%' " &
            "order by ID desc"

        ' Run the Query
        Dim dtDataTable As DataTable = GetDataAsDataTable(szSQL)

        ' If we got a Record
        If dtDataTable.Rows.Count > 0 Then

            ' Get the next Property Reference
            szRetVal &= dtDataTable.Rows(0).Item("id").ToString

        Else

            ' Must be the First
            szRetVal &= "1"

        End If

        ' Tidy
        dtDataTable.Dispose()
        dtDataTable = Nothing

        ' Return the Result
        Return szRetVal.Trim.ToUpper

    End Function

    Public Function GetNextPropertyCARef() As Integer

        ' Init SQL
        Dim szSQL As String =
            "select top 1 cast(reference as integer) + 1 ref " &
            "from property_partner_ref " &
            "where Partner_ID = 3864 " &
            "order by Reference desc"

        Return GetDataAsInteger(szSQL)

    End Function

    Public Function Locations(ByVal nLanguageID As Integer) As DataTable
        Return GetDataAsDataTable("select l.location_id id, d.text text from location l inner join dictionary d on l.dictionary_id = d.dictionary_id where d.language_id = " & nLanguageID.ToString.Trim & " or d.language_id = 0 order by d.text")
    End Function

    Public Function Views() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select v.Views_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch " &
            "from views v " &
                "left join DICTIONARY english on v.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on v.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on v.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on v.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on v.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "where v.Views_ID > 0 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function Views(ByVal nLanguageID As Integer) As DataTable
        Return GetDataAsDataTable("select v.views_id id, d.text text from views v inner join dictionary d on v.dictionary_id = d.dictionary_id where d.language_id = " & nLanguageID.ToString.Trim & " or d.language_id = 0 order by d.text")
    End Function

    Public Function PropertyImages(ByVal nPropertyID As Integer) As DataTable

        ' Local Vars
        Dim dtDataTable As New DataTable

        ' Get the Images Associated with this Property
        dtDataTable = GetDataAsDataTable("select 'M0001' + ltrim(rtrim(cast(property_id as varchar(10)))) + '_' + ltrim(rtrim(cast(photo_id as varchar))) + '.jpg' filename from photo_image where property_id = " & nPropertyID.ToString.Trim & " order by photo_position")

        ' Return the Result
        Return dtDataTable

    End Function

    Public Function Postcode(ByVal nRegionID As Integer, Optional ByVal nAreaID As Integer = -1, Optional ByVal nSubAreaID As Integer = -1) As Integer

        ' Local Vars
        Dim szSQL As String

        ' Init SQL
        szSQL = "select postcode from postcode where region_id = " & nRegionID.ToString.Trim

        ' If an Area has been Specified
        If nAreaID > -1 Then
            szSQL &= " and area_id = " & nAreaID.ToString.Trim
        End If

        ' If a SubArea has been Specified
        If nSubAreaID > -1 Then
            szSQL &= " and subarea_id = " & nSubAreaID.ToString.Trim
        End If

        ' Add Clauses
        szSQL &= " group by postcode order by postcode"

        ' Return the Result
        Return GetDataAsInteger(szSQL)

    End Function

    Public Function PostcodesRegionsAreasSubAreas(ByVal nCountryID As Integer) As DataTable

        ' Local Vars
        Dim szSQL As String =
            "select postcode_id, country_id, region_id, area_id, subarea_id, postcode from postcode where country_id = " & nCountryID.ToString.Trim

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function Postcodes(Optional ByVal nExcludePostcodeID As Integer = 0) As DataTable

        ' If we are Exlcuding a Postcode
        If nExcludePostcodeID > 0 Then
            Return GetDataAsDataTable("select postcode id, postcode text from postcode where postcode_id <> " & nExcludePostcodeID.ToString.Trim & " group by postcode order by postcode")
        Else
            Return GetDataAsDataTable("select postcode id, postcode text from postcode group by postcode order by postcode")
        End If

    End Function

    Public Function RegionInPostcode(ByVal szPostcode As String) As Integer

        ' Local Vars
        Dim szSQL =
            "select pc.region_id id " &
            "from postcode pc " &
                "inner join pc_region r on pc.region_id = r.region_id " &
            "where pc.postcode = '" & szPostcode.Trim & "' " &
            "group by pc.region_id, r.region_name " &
            "order by r.region_name"

        Return GetDataAsInteger(szSQL)

    End Function

    Public Function AreaInPostcode(ByVal szPostcode As String) As Integer

        ' Local Vars
        Dim szSQL =
            "select pc.area_id id " &
            "from postcode pc " &
                "inner join pc_area a on pc.area_id = a.area_id " &
            "where pc.postcode = '" & szPostcode.Trim & "' " &
            "group by pc.area_id, a.area_name " &
            "order by a.area_name"

        Return GetDataAsInteger(szSQL)

    End Function

    Public Function SubAreaInPostcode(ByVal szPostcode As String) As Integer

        ' Local Vars
        Dim szSQL =
            "select pc.subarea_id id " &
            "from postcode pc " &
                "inner join pc_subarea s on pc.subarea_id = s.subarea_id " &
            "where pc.postcode = " & szPostcode.Trim & " and pc.subarea_id > 0 " &
            "group by pc.subarea_id, s.subarea_name " &
            "order by s.subarea_name"

        Return GetDataAsInteger(szSQL)

    End Function
    Public Function Languages(Optional ByVal nLanguageID As Integer = 0) As DataTable

        ' Local Vars
        Dim szSQL As String

        ' If we have a Language ID
        If nLanguageID > 0 Then

            ' Init SQL
            szSQL =
                "select l.language_id id, d.text text , l.Language_Short_Code  " &
                "from language l " &
                    "inner join dictionary d on l.dictionary_id = d.dictionary_id " &
                "where d.language_id = " & nLanguageID.ToString.Trim & " " &
                "order by l.language_id"

        Else

            ' Init SQL for all Languages
            szSQL =
                "select l.Language_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch , l.Language_Short_Code " &
                "from LANGUAGE l " &
                    "left join DICTIONARY english on l.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                    "left join DICTIONARY spanish on l.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                    "left join DICTIONARY french on l.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                    "left join DICTIONARY german on l.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                    "left join DICTIONARY dutch on l.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
                "order by english.Text"

        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function BuyerStatus() As DataTable

        ' Local Vars
        Dim szSQL As String =
            "select b.buyer_status_id id, d.text text " &
            "from buyer_status b " &
                "inner join dictionary d on b.dictionary_id = d.dictionary_id " &
            "where d.language_id = 1 " &
            "order by d.text"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function BuyerSource() As DataTable

        ' Local Vars
        Dim szSQL As String =
            "select b.buyer_source_id id, d.text text " &
            "from buyer_source b " &
                "inner join dictionary d on b.dictionary_id = d.dictionary_id " &
            "where d.language_id = 1 " &
            "order by d.text"

        Return GetDataAsDataTable(szSQL)

    End Function

    'Public Function LoadProperty_With_History_Subject(ByVal nPropertyID As Integer, ByVal nPartnerID As Integer) As DataTable

    '    ' Init SQL
    '    Dim szSQL As String =
    '        "select " &
    '            "p.property_address, " &
    '            "p.annual_ibi, " &
    '            "p.annual_rubbish, " &
    '            "p.bathrooms, " &
    '            "p.bedrooms, " &
    '            "p.broker_id, " &
    '            "p.sqm_built, " &
    '            "p.buyer_id, " &
    '            "p.buyer_lawyer_id, " &
    '            "pr.reference ca_ref, " &
    '            "p.community_fees, " &
    '            "p.country_id, " &
    '            "p.display, " &
    '            "p.door_key, " &
    '            "p.sqm_en_suite, " &
    '            "p.partner_id, " &
    '            "case when isnull(f.property_ref, '') = '' then 'False' " &
    '            "else 'True' " &
    '            "end as Featured, " &
    '            "(SELECT STUFF((SELECT ',' + rtrim(convert(char(10),features_id)) " &
    '            "FROM property_features " &
    '            "WHERE ltrim(rtrim(upper(property_ref))) = (select ltrim(rtrim(upper(property_ref))) from property where property_id = " & nPropertyID.ToString.Trim & ") " &
    '            "FOR XML PATH('')),1,1,'')) Features_ID, " &
    '            "p.gps_latitude, " &
    '            "p.location_id, " &
    '            "p.gps_longitude, " &
    '            "p.num_photos, " &
    '            "p.original_price, " &
    '            "p.sqm_plot, " &
    '            "p.postcode_id, " &
    '            "p.property_ref, " &
    '            "p.public_price, " &
    '            "p.status_id, " &
    '            "p.sqm_terrace, " &
    '            "p.property_type_id, " &
    '            "p.vendor_id, " &
    '            "p.vendor_lawyer_id, " &
    '            "p.vendor_price, " &
    '            "p.views_id, " &
    '            "p.year_constructed, " &
    '            "p.video_url, " &
    '            "a.area_name, " &
    '            "p.Property_Notes , " &
    '             " p.IsIssue, " &
    '             " p.BannerType, " &
    '             " p.History_Subject_To_Id, " &
    '             "(select text from dictionary where dictionary_id in(select Dictionary_ID From PROPERTY_HISTORY_TYPE where history_type_id=p.History_Subject_To_Id)) as HistorySubjectType, " &
    '             "(select Contact_name from Contact where Contact_Id=p.Listed_By_Contact_ID) as Listed_By_Contact_Id, " &
    '             "(select Contact_name from Contact where Contact_Id in(select contact_partner_id from contact where Contact_id=p.Listed_By_Contact_ID)) as Listed_By_Partner, " &
    '             "(select top 1 convert(varchar, expiry_date, 103) from property_history where property_ref=p.property_ref and expiry_date is not null) as HistoryExpiryDate, " &
    '             "(select Buyer_Forename from buyer where buyer_id=p.Buyer_ID) as BuyerForename, " &
    '             "(select Buyer_Surname from buyer where buyer_id=p.Buyer_ID) as BuyerSurname " &
    '            "from property p " &
    '            "left join featured_property f on p.Property_Ref = f.Property_Ref " &
    '            "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID " &
    '            "left join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
    '            "left join PC_AREA a on pc.Area_ID = a.Area_ID " &
    '            "where p.property_id = " & nPropertyID.ToString.Trim

    '    Return GetDataAsDataTable(szSQL)
    '    'And pr.Partner_ID = " & nPartnerID.ToString.Trim & "
    'End Function

    Public Function LoadProperty(ByVal nPropertyID As Integer, ByVal nPartnerID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select " &
                "p.property_address, " &
                "p.annual_ibi, " &
                "p.annual_rubbish, " &
                "p.bathrooms, " &
                "p.bedrooms, " &
                "p.broker_id, " &
                "p.sqm_built, " &
                "p.buyer_id, " &
                "p.buyer_lawyer_id, " &
                "pr.reference ca_ref, " &
                "p.community_fees, " &
                "p.country_id, " &
                "p.display, " &
                "p.door_key, " &
                "p.sqm_en_suite, " &
                "p.partner_id, " &
                "case when isnull(f.property_ref, '') = '' then 'False' " &
                "else 'True' " &
                "end as Featured, " &
                "(SELECT STUFF((SELECT ',' + rtrim(convert(char(10),features_id)) " &
                "FROM property_features " &
                "WHERE ltrim(rtrim(upper(property_ref))) = (select ltrim(rtrim(upper(property_ref))) from property where property_id = " & nPropertyID.ToString.Trim & ") " &
                "FOR XML PATH('')),1,1,'')) Features_ID, " &
                "p.gps_latitude, " &
                "p.location_id, " &
                "p.gps_longitude, " &
                "p.num_photos, " &
                "p.original_price, " &
                "p.sqm_plot, " &
                "p.postcode_id, " &
                "p.property_ref, " &
                "p.public_price, " &
                "p.status_id, " &
                "p.sqm_terrace, " &
                "p.property_type_id, " &
                "p.vendor_id, " &
                "p.vendor_lawyer_id, " &
                "p.vendor_price, " &
                "p.views_id, " &
                "p.year_constructed, " &
                "p.video_url, " &
                "a.area_name, " &
                "p.Property_Notes , " &
                 " p.IsIssue, " &
                 " p.BannerType, " &
                 " p.Listed_By_Contact_Id as LContactId, " &
                 "(select Contact_name from Contact where Contact_Id=p.Listed_By_Contact_ID) as Listed_By_Contact_Id, " &
                 "(select Contact_name from Contact where Contact_Id in(select contact_partner_id from contact where Contact_id=p.Listed_By_Contact_ID)) as Listed_By_Partner " &
                "from property p " &
                "left join featured_property f on p.Property_Ref = f.Property_Ref " &
                "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID " &
                "left join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
                "left join PC_AREA a on pc.Area_ID = a.Area_ID " &
                "where p.property_id = " & nPropertyID.ToString.Trim

        Return GetDataAsDataTable(szSQL)
        'And pr.Partner_ID = " & nPartnerID.ToString.Trim & "
    End Function

    Public Function LoadPropertyShortDesc(ByVal nPropertyID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select Language_ID, Text " &
            "from property_short_desc " &
            "where ltrim(rtrim(upper(Property_Ref))) = (select ltrim(rtrim(upper(Property_Ref))) from property where property_id = " & nPropertyID.ToString.Trim & ")"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function LoadPropertyDesc(ByVal nPropertyID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select Language_ID, Text " &
            "from property_desc " &
            "where ltrim(rtrim(upper(Property_Ref))) = (select ltrim(rtrim(upper(Property_Ref))) from property where property_id = " & nPropertyID.ToString.Trim & ")"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyHistoryAbbrev(ByVal szPropertyRef As String, ByVal nLength As Integer, Optional ByVal bAdmin As Boolean = False) As DataTable
        '"case when (len(h.history_text) > " & nLength.ToString.Trim & ") then substring(h.history_text, 1, " & nLength.ToString.Trim & ") + '...' else h.history_text end History, " &
        ' Local Vars

        'Here i am deleting duplicate history records
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Delete_Duplicate_Property_History_Records")

        'Here i am inserting history record in property_history table
        'Dim szSQL As String =
        '    "select h.history_id, " &
        '        "convert(varchar, h.create_date, 103) as Created, " &
        '        "c.contact_name 'Created By', " &
        '        "ISNULL(d.text, '') Type, " &
        '        "h.history_text History," &
        '        "case when h.Archived = 1 then 'Yes' else 'No' end Archived " &
        '    "from property_history h " &
        '        "inner join contact c on h.modified_by = c.contact_id " &
        '        "left join PROPERTY_HISTORY_TYPE ht on h.Type_ID = ht.history_type_id " &
        '        "left join DICTIONARY d on ht.Dictionary_ID = d.Dictionary_ID and d.Language_ID = 1 " &
        '    "where ltrim(rtrim(upper(h.property_ref))) = '" & szPropertyRef.Trim.ToUpper & "' "

        'Dim szSQL As String =
        '    "			select history_id,convert(varchar, create_date, 103) as Created," &
        '    "isnull((select top 1 contact_name from contact where contact_id=property_history.Modified_By),'-') [Created By]," &
        '    "(select top 1  text from DICTIONARY where Dictionary_ID in(select Dictionary_Id from PROPERTY_HISTORY_TYPE where History_Type_ID=TYPE_ID)) [Type]," &
        '    "case CHARINDEX('– on the', History_Text) when 0 then History_Text else left(history_text,CHARINDEX('– on the', History_Text)-len(29)) end 'History'," &
        '    "case when Archived = 1 then 'Yes' else 'No' end Archived " &
        '     "from PROPERTY_HISTORY " &
        '    "where  ltrim(rtrim(upper(property_ref))) = '" & szPropertyRef.Trim.ToUpper & "' "

        Dim szSQL As String =
            "			select history_id,Created,[Created By],Type,case when History like 'Enquiry received for the property ref%'" &
            " then History+' Email : '+Buyer_Email " &
            " else History end as 'History',Archived from (select history_id,convert(varchar, create_date, 103) as Created, " &
            " (select Buyer_Email from buyer where buyer.Buyer_ID=PROPERTY_HISTORY.Buyer_Id) [Buyer_Email]," &
            " isnull((select top 1 contact_name from contact where contact_id=property_history.Modified_By),'-') [Created By], " &
            " (select top 1  text from DICTIONARY where Dictionary_ID in(select Dictionary_Id from PROPERTY_HISTORY_TYPE where History_Type_ID=TYPE_ID)) [Type], " &
            " case CHARINDEX('– on the', History_Text) when 0 then History_Text else left(history_text,CHARINDEX('– on the', History_Text)-len(29)) end 'History', " &
            " case when Archived = 1 then 'Yes' else 'No' end Archived,create_date " &
            " from PROPERTY_HISTORY  " &
            " where  ltrim(rtrim(upper(property_ref))) = '" & szPropertyRef.Trim.ToUpper & "') PropertyHistoryRecords where 1=1 "


        ' If this is not Admin
        If Not bAdmin Then

            ' Filter Archived Records
            szSQL &=
                "and Archived = 'No' "

        End If

        ' Add Order By Clause
        szSQL &=
            "order by create_date desc"

        ' Return Results
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyHistory(ByVal nHistoryID As Integer) As String

        ' Local Vars
        Dim szSQL As String =
            "select history_text History " &
            "from property_history " &
            "where history_id = " & nHistoryID.ToString.Trim

        Return GetDataAsString(szSQL)

    End Function

    Public Function PropertyHistoryTypes(Optional ByVal bIncludeArchived As Boolean = False) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select ht.History_Type_ID id, d.Text text"

        ' If we are Including Archived
        If bIncludeArchived Then

            ' Add to Selection
            szSQL &= ", ht.Archived"

        End If

        ' Continue to Init SQL
        szSQL &= " " &
            "from DICTIONARY d " &
                "inner join property_history_type ht on d.Dictionary_ID = ht.dictionary_id and d.language_id = 1 "

        ' If we are Excluding Archived
        If Not bIncludeArchived Then

            ' Add Clause
            szSQL &= "where ht.archived = 0 "

        End If

        ' Add Order by Clause
        szSQL &= "order by d.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Sub PropertyHistoryArchiveRecord(ByVal nHistoryID As Integer, Optional ByVal bArchive As Boolean = True)

        ' Init SQL
        Dim szSQL As String =
            "update property_history set Archived = " & Convert.ToInt32(bArchive) & " where history_id = " & nHistoryID.ToString.Trim

        ' Run Update
        Execute(szSQL)

    End Sub

    Public Function PropertySearch(ByVal nPropertyID As Integer,
                                   Optional ByVal nPartnerID As Integer = 0,
                                   Optional ByVal dteCreatedSince As Date = #1/1/1900#,
                                   Optional ByVal dteModifiedSince As Date = #1/1/1900#) As DataTable

        ' Local Vars
        Dim szDelim As String = "where"
        Dim szSQL As String =
            "select " &
                "p.property_id id, " &
                "p.Create_Date, " &
                "p.public_price, " &
                      "case " &
             "when " & nPartnerID & " = 3864  then p.Property_Ref " &
                 "end Property_Ref  , " &
                "case " &
                    "when pr.Reference IS null then p.Property_Ref " &
                    "else cast(pr.Reference as varchar(10)) " &
                "end Reference, " &
                "Convert(varchar(10), p.Create_Date, 103) Created, " &
                "d_type.Text Type, " &
                "d_country.Text Country, " &
                "r.region_name Area, " &
                "a.area_name Town, " &
                "p.bedrooms Beds, " &
                "p.bathrooms Baths, " &
                "d_status.text Status, " &
                "cast(p.public_price as varchar) Price, " &
                "case isnull(p.door_key, '') when '' then 0 else 1 end 'Key', " &
                "p.viewed Views , " &
                 "count(hs.history_id) Toured , " &
                   "p.SQM_Plot ,   " &
                   "case " &
                    "when p.IsIssue = 1 then 'Red' " &
                    "else 'white' " &
                "end IsIssue " &
                   "from property p " &
                "inner join PROPERTY_STATUS s on p.Status_ID = s.Status_ID " &
                "inner join DICTIONARY d_status on s.Dictionary_ID = d_status.Dictionary_ID and d_status.Language_ID = 1 " &
                "inner join PROPERTY_TYPE t on p.Property_Type_ID = t.Property_Type_ID " &
                "inner join DICTIONARY d_type on t.Dictionary_ID = d_type.Dictionary_ID and d_type.Language_ID = 1 " &
                "left join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
                "left join country c on pc.country_id = c.country_id " &
                "left join dictionary d_country on c.dictionary_id = d_country.dictionary_id and d_country.language_id = 1 " &
                "left join PC_REGION r on pc.Region_ID = r.Region_ID " &
                "left join PC_AREA a on pc.Area_ID = a.Area_ID " &
                "left join PROPERTY_history hs on p.property_ref = hs.property_ref  and hs.Type_Id=5 " &
                "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID and pr.Partner_ID = " & nPartnerID.ToString.Trim & " "

        ' If we are getting a Property
        If nPropertyID > -1 Then

            ' Update SQL
            szSQL &= szDelim & " p.property_id = " & nPropertyID.ToString.Trim & " "

            ' Update Delimiter
            szDelim = "and"

        End If

        ' If we have set a Date for Properties Created Since
        If dteCreatedSince > #1/1/1900# Then

            ' Update SQL
            szSQL &= szDelim

            ' If we have also Specified a Modified Date
            If dteModifiedSince > #1/1/1900# Then

                ' Add Parenthesis
                szSQL &= "("

                ' Update Delimter
                szDelim = "or"

            Else

                ' Update Delimiter
                szDelim = "and"

            End If

            ' Continue to Update SQL
            szSQL &= " p.create_date >= " & SQLDateTime(dteCreatedSince) & " "

        End If

        ' If we have set a Date for Properties Modified Since
        If dteModifiedSince > #1/1/1900# Then

            ' Update SQL
            szSQL &= szDelim & " p.last_modified >= " & SQLDateTime(dteModifiedSince) & " "

            ' If we have also Specified a Created Date
            If dteCreatedSince > #1/1/1900# Then

                ' Add Parenthesis
                szSQL &= ") "

            End If

        End If
        szSQL &= "	group by p.property_id ,p.IsIssue,  p.Create_Date,  p.public_price, pr.Reference ,p.Create_Date ,  d_type.Text , r.region_name , a.area_name ,  p.bedrooms , p.bathrooms ,  d_status.text ,  p.public_price ,  p.door_key, p.viewed , p.Property_Ref ,d_country.Text,p.SQM_Plot  "

        ' Add Order by Clause
        szSQL &= "order by p.Create_Date desc"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertySearch(ByVal szAddress As String, Optional ByVal nPartnerID As Integer = 0) As DataTable

        ' Local Vars
        Dim szSQL As String =
            "select " &
                "p.property_id id, " &
                "p.Create_Date, " &
                "p.public_price, " &
                  "case " &
             "when " & nPartnerID & " = 3864  then p.Property_Ref " &
                 "end Property_Ref  , " &
                 "case " &
                    "when pr.Reference IS null then p.Property_Ref " &
                    "else cast(pr.Reference as varchar(10)) " &
                "end Reference, " &
                "p.Create_Date Created, " &
                "d_type.Text Type, " &
                "d_country.Text Country, " &
                "r.region_name Area, " &
                "a.area_name Town, " &
                "p.bedrooms Bedrooms, " &
                "p.bathrooms Bathrooms, " &
                "d_status.text Status, " &
                "cast(p.public_price as varchar) Price, " &
                "case isnull(p.door_key, '') when '' then 0 else 1 end 'Key', " &
                "p.viewed Views , " &
                "count(hs.history_id) Toured , " &
               "p.SQM_Plot , " &
                 "case " &
                    "when p.IsIssue = 1 then 'Red' " &
                    "else 'white' " &
                "end IsIssue " &
                 "from property p " &
                "inner join PROPERTY_STATUS s on p.Status_ID = s.Status_ID " &
                "inner join DICTIONARY d_status on s.Dictionary_ID = d_status.Dictionary_ID and d_status.Language_ID = 1 " &
                "inner join PROPERTY_TYPE t on p.Property_Type_ID = t.Property_Type_ID " &
                "inner join DICTIONARY d_type on t.Dictionary_ID = d_type.Dictionary_ID and d_type.Language_ID = 1 " &
                "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
                "inner join country c on pc.country_id = c.country_id " &
                "inner join dictionary d_country on c.dictionary_id = d_country.dictionary_id and d_country.language_id = 1 " &
                "inner join PC_REGION r on pc.Region_ID = r.Region_ID " &
                "inner join PC_AREA a on pc.Area_ID = a.Area_ID " &
                 "left join PROPERTY_history hs on p.property_ref = hs.property_ref  and hs.Type_Id=5 " &
                "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID and pr.Partner_ID = " & nPartnerID.ToString.Trim & " "

        ' If we have an Address
        If szAddress.Trim <> String.Empty Then

            ' Update SQL
            szSQL &= "where p.Property_Address like '%" & szAddress.Trim & "%' "

        End If

        ' Add Order by Clause
        szSQL &= " group by p.property_id ,p.IsIssue,   p.Create_Date,  p.public_price,  pr.Reference , p.Property_Ref  , p.Create_Date , d_type.Text ,    d_country.Text ,    r.region_name ,    a.area_name ,   p.bedrooms ,   p.bathrooms ,   d_status.text ,     p.public_price ,    p.door_key,     p.viewed ,p.SQM_Plot  "
        szSQL &= "order by p.Create_Date desc"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PropertyAdvancedSearch(ByVal nPartnerID As Integer,
                                           Optional ByVal szReference As String = vbNullString,
                                           Optional ByVal dteCreatedFrom As Date = #1/1/2000#,
                                           Optional ByVal dteCreatedTo As Date = #1/1/2100#,
                                           Optional ByVal nStatusID As Integer = 0,
                                           Optional ByVal nTypeID As Integer = 0,
                                           Optional ByVal nCountryID As Integer = 0,
                                           Optional ByVal nRegionID As Integer = 0,
                                           Optional ByVal nAreaID As Integer = 0,
                                           Optional ByVal nSubAreaID As Integer = 0,
                                           Optional ByVal nMinBedrooms As Integer = 0,
                                           Optional ByVal nMinBathrooms As Integer = 0,
                                           Optional ByVal nPriceFrom As Integer = 0,
                                           Optional ByVal nPriceTo As Integer = 0) As DataTable

        ' Local Vars
        Dim szDelim As String = "where"

        ' Init SQL
        Dim szSQL As String =
            "select t1.id, t1.Reference, t1.ExtReference, t1.Created, t1.Type, t1.Country, t1.Area, t1.Town, t1.Village, t1.Bedrooms, t1.Bathrooms, t1.SQM_Plot, t1.Status, isnull(t1.Features, '') Features, t1.Price " &
            "from " &
            "(" &
                "select " &
                    "p.property_id id, " &
                    "p.Property_Ref Reference, " &
                    "cast(pr.Reference as varchar) ExtReference, " &
                    "p.Create_Date Created, " &
                    "d_type.Text Type, " &
                    "d_country.Text Country, " &
                    "r.region_name Area, " &
                    "a.area_name Town, " &
                    "sa.subarea_name Village, " &
                    "p.bedrooms Bedrooms, " &
                    "p.bathrooms Bathrooms, " &
                    "p.SQM_Plot SQM_Plot," &
                    "d_status.text Status, " &
                    "(" &
                        "select '*', cast(Features_ID as varchar)+ '*' " &
                        "from property_features " &
                        "where Property_Ref = p.Property_Ref " &
                        "for xml path('') " &
                    ") Features, " &
                    "p.public_price Price " &
                "from property p " &
                    "inner join PROPERTY_STATUS s on p.Status_ID = s.Status_ID "

        ' If we have a Status ID
        If nStatusID > 0 Then

            ' Add Clause
            szSQL &= "and s.Status_ID = " & nStatusID.ToString.Trim & " "

        End If

        ' Continue to Init SQL
        szSQL &=
                    "inner join DICTIONARY d_status on s.Dictionary_ID = d_status.Dictionary_ID and d_status.Language_ID = 1 " &
                    "inner join PROPERTY_TYPE t on p.Property_Type_ID = t.Property_Type_ID "

        ' If we have a Type ID
        If nTypeID > 0 Then

            ' Add Clause
            szSQL &= "and t.Property_Type_ID = " & nTypeID.ToString.Trim & " "

        End If

        ' Continue to Init SQL
        szSQL &=
                    "inner join DICTIONARY d_type on t.Dictionary_ID = d_type.Dictionary_ID and d_type.Language_ID = 1 " &
                    "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
                    "inner join COUNTRY c on pc.Country_ID = c.Country_ID "

        ' If we have a Country ID
        If nCountryID > 0 Then

            ' Add Clause
            szSQL &= "and c.Country_ID = " & nCountryID.ToString.Trim & " "

        End If

        ' Continue to Init SQL
        szSQL &=
                    "inner join dictionary d_country on c.dictionary_id = d_country.dictionary_id and d_country.language_id = 1 " &
                    "inner join PC_REGION r on pc.Region_ID = r.Region_ID "

        ' If we have a Region ID
        If nRegionID > 0 Then

            ' Add Clause
            szSQL &= "and r.Region_ID = " & nRegionID.ToString.Trim & " "

        End If

        ' Continue to Init SQL
        szSQL &= "inner join PC_AREA a on pc.Area_ID = a.Area_ID "

        ' If we have an Area ID
        If nAreaID > 0 Then

            ' Add Clause
            szSQL &= "and a.Area_ID = " & nAreaID.ToString.Trim & " "

        End If

        ' Continue to Init SQL
        szSQL &= "inner join PC_SUBAREA sa on pc.SubArea_ID = sa.SubArea_ID "

        ' If we have a SubArea ID
        If nSubAreaID > 0 Then

            ' Add Clause
            szSQL &= "and sa.SubArea_ID = " & nSubAreaID.ToString.Trim & " "

        End If

        ' Continue to Init SQL
        szSQL &=
            "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID and pr.Partner_ID = " & nPartnerID.ToString.Trim &
            ") t1 "

        ' If we have a Reference
        If Not szReference Is Nothing Then

            ' Add to Clause
            szSQL &= szDelim & " t1.Reference = '" & szReference.Trim & "' "

            ' Update Delimiter
            szDelim = "and"

        End If

        ' If we have a Created From
        If dteCreatedFrom <> #1/1/2000# Then

            ' Add to Clause
            szSQL &= szDelim & " t1.Created >= " & SQLDateTime(dteCreatedFrom) & " "

            ' Update Delimiter
            szDelim = "and"

        End If

        ' If we have a Created To
        If dteCreatedTo <> #1/1/2100# Then

            ' Add to Clause
            szSQL &= szDelim & " t1.Created <= " & SQLDateTime(dteCreatedTo) & " "

            ' Update Delimiter
            szDelim = "and"

        End If

        ' If we have Minimum Bedrooms Specified
        If nMinBedrooms > 0 Then

            ' Add to Clause
            szSQL &= szDelim & " t1.Bedrooms >= " & nMinBedrooms.ToString.Trim & " "

            ' Update Delimiter
            szDelim = "and"

        End If

        ' If we have Minimum Bathrooms Specified
        If nMinBathrooms > 0 Then

            ' Add to Clause
            szSQL &= szDelim & " t1.Bathrooms >= " & nMinBathrooms.ToString.Trim & " "

            ' Update Delimiter
            szDelim = "and"

        End If

        ' If we have a Minimum Price
        If nPriceFrom > 0 Then

            ' Add to Clause
            szSQL &= szDelim & " t1.Price >= " & nPriceFrom.ToString.Trim & " "

            ' Update Delimiter
            szDelim = "and"

        End If

        ' If we have a Maximum Price
        If nPriceTo > 0 Then

            ' Add to Clause
            szSQL &= szDelim & " t1.Price <= " & nPriceTo.ToString.Trim & " "

            ' Update Delimiter
            szDelim = "and"

        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function Features() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select f.Features_ID ID, d.text Text " &
            "from FEATURES f " &
                "inner join DICTIONARY d on f.Dictionary_ID = d.Dictionary_ID and d.Language_id = 1 " &
            "order by d.Text"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function LoadContact(ByVal nContactID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select Contact_Type_ID, " &
            "Contact_Name, " &
            "Contact_Registration_Number, " &
            "Contact_Address, " &
            "Contact_Telephone, " &
            "Contact_Mobile, " &
            "Contact_Fax, " &
            "Contact_Email, " &
            "Contact_Notes, " &
            "Contact_Login, " &
            "Contact_Password, " &
            "Contact_Language_ID, " &
            "case Contact_Partner_ID " &
            "when 0 then " &
            "(" &
                "select top 1 pc.default_partner_id " &
                "from postcode pc " &
                    "inner join PROPERTY p on pc.Postcode_ID = p.Postcode_ID " &
                "where p.Vendor_ID = " & nContactID.ToString.Trim & " " &
            ") " &
            "else Contact_Partner_ID " &
            "end Contact_Partner_ID, " &
            "Contact_Commission, " &
            "Contact_Admin, " &
            "Contact_Archived " &
            "from contact " &
            "where Contact_ID = " & nContactID.ToString.Trim

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function ContactType(ByVal nContactTypeID As Integer) As String
        Return GetDataAsString("select contact_type text from contact_type where contact_type_id = " & nContactTypeID.ToString.Trim)
    End Function

    Public Function ContactTypes() As DataTable
        Return GetDataAsDataTable("select contact_type_id id, contact_type text from contact_type order by contact_type")
    End Function

    Public Function Partners() As DataTable
        Return GetDataAsDataTable("select Contact_ID id, Contact_Name text from CONTACT where Contact_Type_ID = 3 order by Contact_Name")
    End Function

    Public Function Brokers() As DataTable
        Return GetDataAsDataTable("select Contact_ID id, Contact_Name text from CONTACT where Contact_Type_ID = 6 order by Contact_Name")
    End Function

    Public Function Lawyers() As DataTable
        Return GetDataAsDataTable("select Contact_ID id, Contact_Name text from CONTACT where Contact_Type_ID = 2 order by Contact_Name")
    End Function

    Public Function Brokers(ByVal nPartnerID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select Contact_Id id,Contact_Name text from contact where Contact_Partner_ID=" & nPartnerID.ToString() & " and Contact_Type_Id=6 order by Contact_Name asc"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function Vendors() As DataTable
        Return GetDataAsDataTable("select Contact_ID ID, Contact_Name text from CONTACT where Contact_Type_ID = 5 and Contact_Archived = 0 order by Contact_Name")
    End Function

    Public Function VendorProperties(ByVal nPartnerID As Integer, ByVal nVendorID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select p.property_id id, " &
            "case " &
                "when pr.Reference IS null then p.Property_Ref " &
                "else cast(pr.Reference as varchar(10)) " &
            "end Reference ," &
              "case " &
             "when " & nPartnerID & " = 3864  then p.Property_Ref " &
                 "end Property_Ref , " &
                   "case " &
             " when p.IsIssue = 1 then 'Red' " &
                 "end IsIssue  " &
            "from PROPERTY p " &
                "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID and pr.Partner_ID = " & nPartnerID.ToString.Trim & " " &
            "where Vendor_ID = " & nVendorID.ToString & " " &
            "order by property_ref"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function IsBuyersLawyer(ByVal nPropertyID As Integer, nLawyerID As Integer) As Boolean

        ' Init SQL
        Dim szSQL As String =
            "select 1 " &
            "from PROPERTY " &
            "where Property_ID = " & nPropertyID.ToString.Trim & " and Buyer_Lawyer_ID in (select contact_id from contact where contact_email=(select contact_email from contact where contact_id= " & nLawyerID.ToString.Trim & "))"

        ' Return the Result
        Return GetDataAsDataTable(szSQL).Rows.Count > 0

    End Function

    Public Function IsVendorsLawyer(ByVal nPropertyID As Integer, nLawyerID As Integer) As Boolean

        ' Init SQL
        Dim szSQL As String =
            "select 1 " &
            "from PROPERTY " &
            "where Property_ID = " & nPropertyID.ToString.Trim & " and Vendor_Lawyer_ID  in (select contact_id from contact where contact_email=(select contact_email from contact where contact_id= " & nLawyerID.ToString.Trim & "))"

        ' Return the Result
        Return GetDataAsDataTable(szSQL).Rows.Count > 0

    End Function

    Public Function PropertyBuyer(ByVal nPropertyID As Integer) As Integer

        ' Init SQL
        Dim szSQL As String =
            "select Buyer_ID from property where property_id = " & nPropertyID.ToString.Trim

        ' Return the Result
        Return GetDataAsInteger(szSQL)

    End Function

    Public Function PropertyVendor(ByVal nPropertyID As Integer) As Integer

        ' Init SQL
        Dim szSQL As String =
            "select Vendor_ID from property where property_id = " & nPropertyID.ToString.Trim

        ' Return the Result
        Return GetDataAsInteger(szSQL)

    End Function

    Public Function LawyerProperties(ByVal nLawyerID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
                       "select p.property_id id, " &
                "p.property_ref Reference " &
            "from PROPERTY p " &
            "where p.Status_ID in(2,3,4,5,7) and (p.Buyer_Lawyer_ID in(select contact_id from contact where contact_email=(select contact_email from contact where contact_id= " & nLawyerID.ToString & ")) or p.Vendor_Lawyer_ID in(select contact_id from contact where contact_email=(select contact_email from contact where contact_id=" & nLawyerID.ToString.Trim & "))) " &
            "order by property_ref"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function LawyerProperties_By_Partner_Id(ByVal nLawyerID As Integer, ByVal nPartnerID As String) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select p.property_id id, " &
                "p.property_ref Reference " &
            "from PROPERTY p " &
            "where p.Status_ID in(2,3,4,5,7) and Partner_Id=" & nPartnerID & " and (p.Buyer_Lawyer_ID = " & nLawyerID.ToString & " or p.Vendor_Lawyer_ID = " & nLawyerID.ToString.Trim & ") " &
            "order by property_ref"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function ContactSearch(ByVal nTypeID As Integer,
                                    ByVal szName As String,
                                    Optional ByVal nPartnerID As Integer = 0,
                                    Optional ByVal szPropertyRef As String = vbNullString,
                                    Optional ByVal bIncludeArchived As Boolean = False
                                 ) As DataTable

        ' Local Vars
        Dim szSQL As String

        ' Init SQL
        szSQL =
                "select C.Contact_ID ID, " &
                    "C.Contact_Name Name, " &
                    "case " &
                        "when (C.Contact_Archived) = 1 then 'Archived' " &
                        "else '' " &
                    "end Archived " &
                "from CONTACT C "

        ' If we have a Partner ID and a Property Reference
        If nPartnerID > 0 And szPropertyRef.Trim <> String.Empty Then

            ' Init SQL searching for a Contact associated with this Property Reference
            szSQL &=
                    "inner join PROPERTY P on C.Contact_ID = P.Vendor_ID  and p.Property_Ref = '" & PropertyIARef(nPartnerID, szPropertyRef.Trim).ToUpper & "' " &
                "where C.Contact_Type_ID = " & nTypeID.ToString.Trim & " "

        Else

            ' Init SQL
            szSQL &=
                "where C.Contact_Type_ID = " & nTypeID.ToString.Trim & " and C.Contact_Name like '%" & szName.Trim & "%' "

        End If

        ' If we are not Including Archived
        If Not bIncludeArchived Then

            ' Add Clause
            szSQL &= "and Contact_Archived = " & SQLBoolean(bIncludeArchived) & " "

        End If

        ' Add Order By Clause
        szSQL &= "order by C.Contact_Name"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Sub AddDocument(ByVal nPropertyID As Integer, ByVal szFilename As String, ByVal nUserID As Integer)
        Execute("insert into property_documents (property_id, filename, uploaded_by) values (" & nPropertyID.ToString.Trim & ", '" & szFilename.Trim & "', " & nUserID.ToString.Trim & ")")
    End Sub

    Public Function LoadDocument(ByVal nDocumentID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select d.filename, p.property_ref reference " &
            "from property_documents d " &
                "inner join property p on d.property_id = p.property_id " &
            "where document_id = " & nDocumentID.ToString.Trim

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function LoadDocuments(ByVal nPropertyID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select d.document_id, d.filename Filename, c.contact_name ""Uploaded By"", d.uploaded_on ""Uploaded On"" " &
            "from property_documents d " &
             "inner join contact c on d.uploaded_by = c.Contact_ID " &
            "where property_id = " & nPropertyID.ToString.Trim & " " &
            "order by d.uploaded_on desc"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Sub DeleteDocument(ByVal nDocumentID As Integer)

        Execute("delete from property_documents where document_id = " & nDocumentID.ToString.Trim)

    End Sub

    Public Function SearchTranslationsEnglish(ByVal szSearchString As String) As DataTable

        ' Prepare SQL
        Dim szSQL As String =
            "select o.text English, t.Hash_Code, t.Language_ID, d.Text Language, t.text Translation " &
            "from TRANSLATION t " &
                "inner join TRANSLATION o on t.Hash_Code = o.Hash_Code and o.Language_ID = 1 " &
                "inner join LANGUAGE l on t.Language_ID = l.Language_ID " &
                "inner join DICTIONARY d on l.Dictionary_ID = d.Dictionary_ID and d.Language_ID = 1 " &
            "where t.language_id <> 1 and (o.text like '%" & szSearchString.Trim & "%' or o.text like '%" & HttpUtility.HtmlEncode(szSearchString.Trim) & "%') " &
            "order by o.text, t.text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function SearchTranslationsForeign(ByVal szSearchString As String) As DataTable

        ' Prepare SQL
        Dim szSQL As String =
            "select o.text English, t.Hash_Code, t.Language_ID, d.Text Language, t.text Translation " &
            "from TRANSLATION t " &
                "left join TRANSLATION o on t.Hash_Code = o.Hash_Code and o.Language_ID = 1 " &
                "inner join LANGUAGE l on t.Language_ID = l.Language_ID " &
                "inner join DICTIONARY d on l.Dictionary_ID = d.Dictionary_ID and d.Language_ID = 1 " &
            "where t.language_id <> 1 and (t.text like '%" & szSearchString.Trim & "%' or t.text like '%" & HttpUtility.HtmlEncode(szSearchString.Trim) & "%') " &
            "order by o.text, t.text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Sub UpdateTranslation(ByVal nHashCode As Long, ByVal nLanguageID As Integer, ByVal szTranslation As String)

        ' Prepare SQL
        Dim szSQL As String =
            "update TRANSLATION set text = '" & HttpUtility.HtmlEncode(szTranslation.Replace("'", "''")) & "' where Hash_Code = " & nHashCode.ToString.Trim & " and Language_ID = " & nLanguageID.ToString.Trim

        ' Run the Update
        Execute(szSQL)

    End Sub

    Public Sub DeleteTranslation(ByVal nHashCode As Long, ByVal nLanguageID As Integer)

        ' Prepare SQL
        Dim szSQL As String =
            "delete from TRANSLATION where Hash_Code = " & nHashCode.ToString.Trim & " and Language_ID = " & nLanguageID.ToString.Trim

        ' Run the Update
        Execute(szSQL)

    End Sub

    Public Function ClientTourIDs() As DataTable
        Return GetDataAsDataTable("select tour_id id, tour_id text from client_tour order by tour_id desc")
    End Function

    Public Function Users() As DataTable
        Return GetDataAsDataTable("select Contact_ID id, Contact_Name text from contact where Contact_Type_ID = 4 and Contact_Archived=0 order by Contact_Name")
    End Function

    Public Function ClientTourProperties(ByVal nPartnerID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select p.Property_ID id, " &
            "case " &
                "when pr.Reference is null then p.Property_Ref " &
                "else cast (pr.Reference as varchar(10)) " &
            "end text " &
            "from property p " &
                "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID and pr.Partner_ID = " & nPartnerID.ToString.Trim & " " &
            "order by text"
        '"where p.Status_ID = 2 " & _

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function
    Public Function ClientTourPropertieswithoutcase(ByVal nPartnerID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
           "select p.Property_ID id, " &
            "cast (p.Property_Ref as varchar(10)) as text " &
            "from property p " &
                "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID and pr.Partner_ID = " & nPartnerID.ToString.Trim & " " &
            "order by text"
        '"where p.Status_ID = 2 " & _

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function ClientTourPropertyDetail(ByVal nPropertyID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select c.Contact_Name Name,prr.Reference, p.Property_Address Address, a.Area_Name Town, c.Contact_Telephone Telephone, c.Contact_Mobile Mobile, p.Public_Price Price, isnull(p.door_key, '') 'Key' ,p.Video_URL, p.GPS_Latitude ,p.GPS_Longitude  " &
            "from PROPERTY p " &
                "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
                "inner join PC_AREA a on pc.Area_ID = a.Area_ID " &
                "inner join CONTACT c on p.Vendor_ID = c.Contact_ID " &
                 "left join PROPERTY_PARTNER_REF prr on p.Property_ID = prr.Property_ID " &
            "where p.Property_ID = " & nPropertyID.ToString.Trim

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function ClientTourSearch(Optional ByVal nTourID As Integer = 0,
                                     Optional ByVal dtDateFrom As Date = #1/1/1900#,
                                     Optional ByVal dtDateTo As Date = #1/1/1900#,
                                     Optional ByVal nBuyerID As Integer = 0,
                                     Optional ByVal nTourByID As Integer = 0) As DataTable

        ' Local Vars
        Dim szDelim As String = " where "

        ' Init SQL
        Dim szSQL As String =
            "select t.tour_id Reference, t.tour_datetime ""Date and Time"", LTRIM(rtrim(b.buyer_forename)) + ' ' +  LTRIM(rtrim(b.buyer_surname)) Buyer, b.Buyer_Id 'BuyerId', c.Contact_Name ""Tour By"" " &
            "from client_tour t " &
                "inner join BUYER b on t.tour_buyer_id = b.Buyer_ID " &
                "inner join CONTACT c on t.tour_with_id = c.Contact_ID"

        ' If we have a Tour ID
        If nTourID > 0 Then

            ' Add Clause
            szSQL &= szDelim & "t.tour_id = " & nTourID.ToString.Trim

            ' Update Delimiter
            szDelim = " and "

        End If

        ' If we have a Date
        If dtDateFrom > #1/1/1900# And dtDateTo > #1/1/1900# Then

            ' Add Clause
            szSQL &= szDelim & "cast(t.tour_datetime as DATE) between cast(" & SQLDateTime(dtDateFrom) & " as DATE) and cast(" & SQLDateTime(dtDateTo) & " as DATE) "

            ' Update Delimiter
            szDelim = " and "

        End If

        ' If we have a Buyer ID
        If nBuyerID > 0 Then

            ' Add Clause
            szSQL &= szDelim & "b.Buyer_ID = " & nBuyerID.ToString.Trim

            ' Update Delimiter
            szDelim = " and "

        End If

        ' If we have a Tour By ID
        If nTourByID > 0 Then

            ' Add Clause
            szSQL &= szDelim & "c.Contact_ID = " & nTourByID.ToString.Trim

        End If

        ' Add Order By Clause
        szSQL &= " order by t.tour_datetime desc"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function ClientTourSearchNew(Optional ByVal nTourID As Integer = 0,
                                     Optional ByVal dtDateFrom As Date = #1/1/1900#,
                                     Optional ByVal dtDateTo As Date = #1/1/1900#,
                                     Optional ByVal nBuyerID As Integer = 0,
                                     Optional ByVal nTourByID As Integer = 0) As DataTable

        ' Local Vars
        Dim szDelim As String = " where "

        ' Init SQL
        Dim szSQL As String =
            "select t.tour_id Reference, t.tour_datetime ""DateTime"", LTRIM(rtrim(b.buyer_forename)) + ' ' +  LTRIM(rtrim(b.buyer_surname)) Buyer, b.Buyer_Id 'BuyerId', c.Contact_Name ""Tour"" " &
            ",case VirtualTour when 0 then 'Normal' else 'Virtual' end as 'VirtualTour' from client_tour t " &
                "inner join BUYER b on t.tour_buyer_id = b.Buyer_ID " &
                "inner join CONTACT c on t.tour_with_id = c.Contact_ID"

        ' If we have a Tour ID
        If nTourID > 0 Then

            ' Add Clause
            szSQL &= szDelim & "t.tour_id = " & nTourID.ToString.Trim

            ' Update Delimiter
            szDelim = " and "

        End If

        ' If we have a Date
        If dtDateFrom > #1/1/1900# And dtDateTo > #1/1/1900# Then

            ' Add Clause
            szSQL &= szDelim & "cast(t.tour_datetime as DATE) between cast(" & SQLDateTime(dtDateFrom) & " as DATE) and cast(" & SQLDateTime(dtDateTo) & " as DATE) "

            ' Update Delimiter
            szDelim = " and "

        End If

        ' If we have a Buyer ID
        If nBuyerID > 0 Then

            ' Add Clause
            szSQL &= szDelim & "b.Buyer_ID = " & nBuyerID.ToString.Trim

            ' Update Delimiter
            szDelim = " and "

        End If

        ' If we have a Tour By ID
        If nTourByID > 0 Then

            ' Add Clause
            szSQL &= szDelim & "c.Contact_ID = " & nTourByID.ToString.Trim

        End If

        ' Add Order By Clause
        szSQL &= " order by t.tour_datetime desc"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function


    Public Function SaveClientTour(ByVal CClientTour As ClassClientTour) As Integer

        ' Local Vars
        Dim szSQL As String
        Dim bNew As Boolean = False

        ' Are we Updating an Existing?
        If CClientTour.TourID > 0 Then

            ' Updating - Init SQL
            szSQL =
                "update CLIENT_TOUR set " &
                    "Tour_DateTime = " & SQLDateTime(CClientTour.ViewingDate) & ", " &
                    "Tour_Buyer_ID = " & CClientTour.BuyerID.ToString.Trim & ", " &
                    "Tour_With_ID = " & CClientTour.TourWithID.ToString.Trim & ", " &
                    "VirtualTour = " & Convert.ToInt32(CClientTour.VirtualTour) & " " &
                "where Tour_ID = " & CClientTour.TourID.ToString.Trim

        Else

            ' New = Set Flag
            bNew = True

            ' New - Init SQL
            szSQL =
                "insert into CLIENT_TOUR (Tour_DateTime, Tour_Buyer_ID, Tour_With_ID,VirtualTour) values " &
                "(" &
                    SQLDateTime(CClientTour.ViewingDate) & ", " &
                    CClientTour.BuyerID.ToString.Trim & ", " &
                    CClientTour.TourWithID.ToString.Trim & ", " &
                    Convert.ToInt32(CClientTour.VirtualTour) &
                ")"

        End If

        ' Run the Update
        Execute(szSQL)

        ' If this is New
        If bNew Then

            ' Get the Tour ID
            CClientTour.TourID = GetDataAsInteger("select max(Tour_ID) from CLIENT_TOUR")

        End If

        ' Delete any Previous Entries for this Tour - Init SQL
        szSQL = "delete from CLIENT_TOUR_PROPERTIES where Tour_ID = " & CClientTour.TourID
        Execute(szSQL)

        ' Init SQL
        szSQL = String.Empty

        ' Saving the Properties being Visited
        For Each CClientTourProperty As ClassClientTourProperty In CClientTour.TourProperty

            ' Init SQL
            szSQL &=
                "insert into CLIENT_TOUR_PROPERTIES (Tour_ID, Tour_Property_ID, Tour_DateTime) values " &
                "(" &
                    CClientTour.TourID.ToString.Trim & ", " &
                    CClientTourProperty.PropertyID.ToString.Trim & ", " &
                    SQLDateTime(CClientTourProperty.ViewingTime) &
                ");"

        Next

        ' Run the Update
        Execute(szSQL)

        ' Return the Tour ID
        Return CClientTour.TourID

    End Function

    Public Function LoadClientTour(ByVal nClientTourID As Integer, ByVal nPartnerID As Integer) As ClassClientTour

        ' Local Vars
        Dim CClientTour As New ClassClientTour

        ' Init SQL to get Header Info
        Dim szSQL As String =
            "select t.*, ltrim(rtrim(b.buyer_forename)) + ' ' + ltrim(rtrim(b.buyer_surname)) Buyer, case b.Buyer_Telephone when '' then 'Unknown' else b.Buyer_Telephone end + ' / ' + case b.Buyer_Email when '' then 'Unknown' else b.Buyer_Email end TelEmail, c.contact_name ""Tour With"" " &
            "from client_tour t " &
                "inner join BUYER b on t.tour_buyer_id = b.buyer_id " &
                "inner join CONTACT c on t.tour_with_id = c.contact_id " &
            "where t.tour_id = " & nClientTourID.ToString.Trim
        Dim dtDataTable As DataTable = GetDataAsDataTable(szSQL)

        ' If we got a Row
        If dtDataTable.Rows.Count > 0 Then

            ' Assign Header Info            
            CClientTour.TourID = Convert.ToInt32(dtDataTable.Rows(0).Item("tour_id"))
            CClientTour.ViewingDate = Convert.ToDateTime(dtDataTable.Rows(0).Item("tour_datetime"))
            CClientTour.BuyerID = Convert.ToInt32(dtDataTable.Rows(0).Item("tour_buyer_id"))
            CClientTour.TourWithID = Convert.ToInt32(dtDataTable.Rows(0).Item("tour_with_id"))
            CClientTour.Buyer = dtDataTable.Rows(0).Item("Buyer").ToString.Trim
            CClientTour.BuyerTelEmail = dtDataTable.Rows(0).Item("TelEmail").ToString.Trim
            CClientTour.TourWith = dtDataTable.Rows(0).Item("Tour With").ToString.Trim
            CClientTour.VirtualTour = Convert.ToBoolean(dtDataTable.Rows(0).Item("VirtualTour"))
            ' Tidy
            dtDataTable.Dispose()

            ' Get the Property Info
            szSQL =
                "select tp.*, " &
                " p.Property_Ref [Reference] " &
                "from client_tour_properties tp " &
                    "inner join PROPERTY p on tp.tour_property_id = p.Property_ID " &
                    "left join PROPERTY_PARTNER_REF ppr on tp.tour_property_id = ppr.Property_ID and ppr.Partner_ID = " & nPartnerID.ToString.Trim & " " &
                "where tp.tour_id = " & nClientTourID.ToString.Trim & " " &
                "order by tp.tour_datetime"
            dtDataTable = GetDataAsDataTable(szSQL)

            ' For each Row Returned
            For Each dr As DataRow In dtDataTable.Rows

                ' Define a new Client Tour Proeprty
                Dim CClientTourProperty As New ClassClientTourProperty

                ' Assign Vars
                CClientTourProperty.PropertyID = Convert.ToInt32(dr.Item("tour_property_id"))
                CClientTourProperty.ViewingTime = Convert.ToDateTime(dr.Item("tour_datetime"))
                CClientTourProperty.PropertyReference = dr.Item("Reference").ToString.Trim

                ' Add this to the Array
                CClientTour.TourProperty.Add(CClientTourProperty)

            Next

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' Return the Result
        Return CClientTour

    End Function

    Public Function Buyers(Optional ByVal bIncludeArchived As Boolean = False) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select Buyer_ID id, ltrim(rtrim(Buyer_Forename)) + ' ' + ltrim(rtrim(Buyer_Surname)) text from buyer "

        ' If we are not Including Archived
        If Not bIncludeArchived Then

            ' Add Clause
            szSQL &= "where Archived = 0"

        End If

        ' Add Order by Clause
        szSQL &= "order by Buyer_Surname, Buyer_Forename"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function BuyerName(ByVal nBuyerID As Integer) As String

        ' Init SQL
        Dim szSQL As String =
            "select LTRIM(RTRIM(LTRIM(RTRIM(Buyer_Forename)) + ' ' + LTRIM(RTRIM(Buyer_Surname)))) from Buyer where Buyer_ID = " & nBuyerID.ToString.Trim

        ' Return the Result
        Return GetDataAsString(szSQL)

    End Function

    Public Function BuyerTelEmail(ByVal nBuyerID As Integer) As String

        ' Init SQL
        Dim szSQL As String =
            "select case Buyer_Telephone when '' then 'Unknown' else Buyer_Telephone end + ' / ' + case Buyer_Email when '' then 'Unknown' else Buyer_Email end as Contacts from BUYER where Buyer_ID = " & nBuyerID.ToString.Trim

        ' Return the Result
        Return GetDataAsString(szSQL)

    End Function

    Public Function PropertyLastTouredBuyers(ByVal nPropertyID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select ct.tour_buyer_id id, ltrim(rtrim(b.Buyer_Forename)) + ' ' + ltrim(rtrim(b.Buyer_Surname)) text " &
            "from CLIENT_TOUR ct " &
                "inner join CLIENT_TOUR_PROPERTIES ctp on ct.tour_id = ctp.tour_id " &
                "inner join BUYER b on ct.tour_buyer_id = b.Buyer_ID " &
            "where ctp.tour_property_id = " & nPropertyID.ToString.Trim & " and ct.tour_datetime <= GETDATE() " &
            "order by ct.tour_datetime desc"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function Agents(ByVal nPartnerID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select agent.Contact_ID id, agent.Contact_Name text " &
            "from CONTACT agent " &
                "inner join CONTACT partner on agent.Contact_Partner_ID = partner.Contact_ID " &
            "where agent.Contact_Type_ID = 1 And agent.Contact_Partner_ID = " & nPartnerID.ToString.Trim & " " &
            "order by agent.Contact_Name"

        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function BuyerSearch(ByVal szFirstName As String, ByVal szLastName As String, Optional ByVal bIncludeArchived As Boolean = False) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select Buyer_ID ID, Archived, LTRIM(rtrim(buyer_forename)) + ' ' + LTRIM(rtrim(buyer_surname)) Name " &
            "from buyer " &
            "where Buyer_Forename like '%" & szFirstName.Trim & "%' " &
                "or Buyer_Surname like '%" & szLastName.Trim & "%' "

        ' If we are not Including Archived
        If Not bIncludeArchived Then

            ' Add Clause
            szSQL &= "and Archived = 0 "

        End If

        ' Add Order by Clause
        szSQL &= "order by Buyer_Surname, Buyer_Forename"

        Return GetDataAsDataTable(szSQL)

    End Function
    Public Function BuyerSearchEmail(ByVal szFirstName As String, ByVal szLastName As String, ByVal Email As String, Optional ByVal bIncludeArchived As Boolean = False) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select Buyer_ID ID, Archived, LTRIM(rtrim(buyer_forename)) + ' ' + LTRIM(rtrim(buyer_surname)) Name " &
            "from buyer " &
            "where Buyer_Forename like '%" & szFirstName.Trim & "%' " &
                "and Buyer_Email like '%" & Email.Trim & "%' "

        ' If we are not Including Archived
        If Not bIncludeArchived Then

            ' Add Clause
            szSQL &= "and Archived = 0 "

        End If

        ' Add Order by Clause
        szSQL &= "order by Buyer_Surname, Buyer_Forename"

        Return GetDataAsDataTable(szSQL)

    End Function


    'Public Function AdminFeaturedProperties(ByVal nPartnerID As Integer) As DataTable

    '    ' Init SQL
    '    Dim szSQL As String = _
    '        "select t1.ref, t1.text " & _
    '        "from " & _
    '        "(" & _
    '            "select p.Property_Ref ref, " & _
    '            " case " & nPartnerID & " when 3864 then " & _
    '            "p.property_ref+' '+   isnull(cast(ppr.reference as varchar(10)), '') + ' (' + r.Region_Name + ')'+' '+ cast(Public_Price as varchar(100)) +' €' " & _
    '            " else " & _
    '                "isnull(cast(ppr.reference as varchar(10)), p.property_ref) + ' (' + r.Region_Name + ')' end text, " & _
    '                "fp.sort_order " & _
    '            "from FEATURED_PROPERTY fp " & _
    '                "inner join PROPERTY p on fp.Property_Ref = p.Property_Ref " & _
    '                "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " & _
    '                "inner join PC_REGION r on pc.Region_ID = r.Region_ID " & _
    '                "left join PROPERTY_PARTNER_REF ppr on p.Property_ID = ppr.Property_ID and ppr.partner_id = " & nPartnerID.ToString.Trim & " " & _
    '        ") t1 " & _
    '        "order by t1.sort_order, t1.ref"

    '    ' Return the Result
    '    Return GetDataAsDataTable(szSQL)

    'End Function


    'Public Function AdminNonFeaturedProperties(ByVal nPartnerID As Integer) As DataTable

    '    ' Init SQL
    '    Dim szSQL As String = _
    '        "select * " & _
    '        "from " & _
    '        "(" & _
    '            "select p.Property_Ref ref, " & _
    '            " case " & nPartnerID & " when 3864 then " & _
    '            "p.property_ref+' '+   isnull(cast(ppr.reference as varchar(10)), '') + ' (' + r.Region_Name + ')'+' '+ cast(Public_Price as varchar(100)) +' €' " & _
    '            " else " & _
    '                "isnull(cast(ppr.reference as varchar(10)), p.property_ref) + ' (' + r.Region_Name + ')' end text " & _
    '            "from PROPERTY p " & _
    '                "left join PROPERTY_PARTNER_REF ppr on p.Property_ID = ppr.Property_ID and ppr.partner_id = " & nPartnerID.ToString.Trim & " " & _
    '                "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " & _
    '                "inner join PC_REGION r on pc.Region_ID = r.Region_ID " & _
    '            "where p.Property_Ref not in " & _
    '                "(" & _
    '                    "select Property_Ref " & _
    '                    "from FEATURED_PROPERTY" & _
    '                ") " & _
    '                "and p.Display = 1 " & _
    '                "and p.Status_ID = 2" & _
    '            ") t1 " & _
    '        "group by t1.ref, t1.text " & _
    '        "order by t1.text"

    '    ' Return the Result
    '    Return GetDataAsDataTable(szSQL)

    'End Function

    'Public Function AdminNonFeaturedProperties(ByVal nPartnerID As Integer) As DataTable

    '    ' Init SQL
    '    Dim szSQL As String = _
    '        "select * " & _
    '        "from " & _
    '        "(" & _
    '            "select p.Property_Ref ref, " & _
    '                "isnull(cast(ppr.reference as varchar(10)), p.property_ref) + ' (' + r.Region_Name + ')' text " & _
    '            "from PROPERTY p " & _
    '                "left join PROPERTY_PARTNER_REF ppr on p.Property_ID = ppr.Property_ID and ppr.partner_id = " & nPartnerID.ToString.Trim & " " & _
    '                "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " & _
    '                "inner join PC_REGION r on pc.Region_ID = r.Region_ID " & _
    '            "where p.Property_Ref not in " & _
    '                "(" & _
    '                    "select Property_Ref " & _
    '                    "from FEATURED_PROPERTY" & _
    '                ") " & _
    '                "and p.Display = 1 " & _
    '                "and p.Status_ID = 2" & _
    '            ") t1 " & _
    '        "group by t1.ref, t1.text " & _
    '        "order by t1.text"

    '    ' Return the Result
    '    Return GetDataAsDataTable(szSQL)

    'End Function

    Public Function AdminFeaturedProperties(ByVal nPartnerID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select t1.ref, t1.text " &
            "from " &
            "(" &
                "select p.Property_Ref ref, " &
                 " case " & nPartnerID & " when 3864 then " &
                "p.property_ref+' '+   isnull(cast(ppr.reference as varchar(10)), '') + ' (' + r.Region_Name + ') ('+cast (case when p.partner_id=3864 then 'Casa-Andaluza.net' else 'Inland Andalucia Ltd' end as varchar(20))+')'+' '+ cast(Public_Price as varchar(100)) +' €' " &
                    " else " &
                    "isnull(cast(ppr.reference as varchar(10)), p.property_ref) + ' (' + r.Region_Name + ') ('+cast (case when p.partner_id=3864 then 'Casa-Andaluza.net' else 'Inland Andalucia Ltd' end as varchar(20))+')' end text, " &
                    "fp.sort_order " &
                "from FEATURED_PROPERTY fp " &
                    "inner join PROPERTY p on fp.Property_Ref = p.Property_Ref " &
                    "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
                    "inner join PC_REGION r on pc.Region_ID = r.Region_ID " &
                    "left join PROPERTY_PARTNER_REF ppr on p.Property_ID = ppr.Property_ID and ppr.partner_id = " & nPartnerID.ToString.Trim & " " &
            ") t1 " &
            "order by t1.sort_order, t1.ref"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function AdminNonFeaturedProperties(ByVal nPartnerID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select * " &
            "from " &
            "(" &
                "select p.Property_Ref ref, " &
                   " case " & nPartnerID & " when 3864 then " &
                "p.property_ref+' '+   isnull(cast(ppr.reference as varchar(10)), '') + ' (' + r.Region_Name + ') ('+cast (case when p.partner_id=3864 then 'Casa-Andaluza.net' else 'Inland Andalucia Ltd' end as varchar(20))+')'+' '+ cast(Public_Price as varchar(100)) +' €' " &
                    " else " &
                    "isnull(cast(ppr.reference as varchar(10)), p.property_ref) + ' (' + r.Region_Name + ') ('+cast (case when p.partner_id=3864 then 'Casa-Andaluza.net' else 'Inland Andalucia Ltd' end as varchar(20))+')' end text " &
                "from PROPERTY p " &
                    "left join PROPERTY_PARTNER_REF ppr on p.Property_ID = ppr.Property_ID and ppr.partner_id = " & nPartnerID.ToString.Trim & " " &
                    "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
                    "inner join PC_REGION r on pc.Region_ID = r.Region_ID " &
                "where p.Property_Ref not in " &
                    "(" &
                        "select Property_Ref " &
                        "from FEATURED_PROPERTY" &
                    ") " &
                    "and p.Display = 1 " &
                    "and p.Status_ID = 2" &
                ") t1 " &
            "group by t1.ref, t1.text " &
            "order by t1.text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function
    Public Sub SaveFeaturedProperties(ByVal alFeaturedPropertyIDs As ArrayList)

        ' Local Vars
        Dim nSortOrder As Integer = 0

        ' Delete those that have been Excluded
        Dim szSQL As String = "delete from FEATURED_PROPERTY where Property_Ref not in ('" & String.Join("','", alFeaturedPropertyIDs.ToArray) & "');"

        ' For each Property
        For Each szPropertyRef As String In alFeaturedPropertyIDs

            ' Increment Sort Order
            nSortOrder += 1

            ' Init Insertion / Update SQL
            szSQL &=
                "merge FEATURED_PROPERTY as target using " &
                "(" &
                    "select " &
                    "'" & szPropertyRef.Trim.ToUpper & "', " &
                    nSortOrder.ToString.Trim &
                ") " &
                "as source " &
                "(" &
                    "Property_Ref, " &
                    "Sort_Order" &
                ") " &
                "on target.Property_Ref = source.Property_Ref " &
                "when matched then " &
                    "update set " &
                        "Sort_Order = source.Sort_Order " &
                "when not matched then " &
                    "insert " &
                    "(" &
                        "Property_Ref, " &
                        "Sort_Order" &
                    ") " &
                    "values " &
                    "(" &
                        "source.Property_Ref, " &
                        "source.Sort_Order" &
                    ");"

        Next

        ' Run Update
        Execute(szSQL)

    End Sub

    Public Sub UpdateCountry(
                                ByVal nCountryID As Integer,
                                ByVal szCountryNameEN As String,
                                ByVal szCountryNameES As String,
                                ByVal szCountryNameFR As String,
                                ByVal szCountryNameDE As String,
                                ByVal szCountryNameNL As String,
                                ByVal szCountryCode As String
                            )

        ' Init SQL to save Country Names and Update the Country Code
        Dim szSQL As String =
            "update dictionary set text = '" & szCountryNameEN.Trim & "' where language_id = 1 and dictionary_id in (select dictionary_id from country where country_id = " & nCountryID.ToString.Trim & ");" &
            "update dictionary set text = '" & szCountryNameES.Trim & "' where language_id = 2 and dictionary_id in (select dictionary_id from country where country_id = " & nCountryID.ToString.Trim & ");" &
            "update dictionary set text = '" & szCountryNameFR.Trim & "' where language_id = 3 and dictionary_id in (select dictionary_id from country where country_id = " & nCountryID.ToString.Trim & ");" &
            "update dictionary set text = '" & szCountryNameDE.Trim & "' where language_id = 4 and dictionary_id in (select dictionary_id from country where country_id = " & nCountryID.ToString.Trim & ");" &
            "update dictionary set text = '" & szCountryNameNL.Trim & "' where language_id = 5 and dictionary_id in (select dictionary_id from country where country_id = " & nCountryID.ToString.Trim & ");" &
            "update country set country_code = '" & szCountryCode.Trim.ToUpper & "' where country_id = " & nCountryID.ToString.Trim & ";"

        ' Run Update
        Execute(szSQL)

    End Sub

    Public Sub UpdatePostcode(ByVal nRegionID As Integer, ByVal szRegionName As String)

        ' Init SQL to set Name
        Dim szSQL As String = "update pc_region set region_name = '" & szRegionName.Trim & "' where region_id = " & nRegionID.ToString.Trim

        ' Update Name
        Execute(szSQL)

    End Sub

    Public Sub UpdatePostcode(ByVal nRegionID As Integer, ByVal nAreaID As Integer, ByVal szAreaName As String, ByVal szPostcode As String, ByVal nDefaultPartnerID As Integer)
        ' Init SQL to set Name
        Dim szSQL As String = "update pc_area set area_name = '" & szAreaName.Trim & "' where area_id = " & nAreaID.ToString.Trim
        ' Update Name
        Execute(szSQL)
        ' Init SQL to Update Postcode
        szSQL = "update postcode set postcode = '" & szPostcode.Trim.ToUpper & "', GPS_Latitude=Null,GPS_Longitude=Null, default_partner_id = " & nDefaultPartnerID.ToString.Trim & " where region_id = " & nRegionID.ToString.Trim & " and area_id = " & nAreaID.ToString.Trim
        ' Update Postcode
        Execute(szSQL)
    End Sub

    Public Sub UpdatePostcode(ByVal nRegionID As Integer, ByVal nAreaID As Integer, ByVal nSubAreaID As Integer, ByVal szSubAreaName As String, ByVal szPostcode As String, ByVal nDefaultPartnerID As Integer)

        ' Init SQL to set Name
        Dim szSQL As String = "update pc_subarea set subarea_name = '" & szSubAreaName.Trim & "' where subarea_id = " & nSubAreaID.ToString.Trim

        ' Update Name
        Execute(szSQL)

        ' Init SQL to Update Postcode
        szSQL = "update postcode set postcode = '" & szPostcode.Trim.ToUpper & "', GPS_Latitude=Null,GPS_Longitude=Null, default_partner_id = " & nDefaultPartnerID.ToString.Trim & " where region_id = " & nRegionID.ToString.Trim & " and area_id = " & nAreaID.ToString.Trim & " and subarea_id = " & nSubAreaID.ToString.Trim

        ' Update Postcode
        Execute(szSQL)

    End Sub

    Public Sub AddCountry(ByVal szCountryNameEN As String,
                          ByVal szCountryNameES As String,
                          ByVal szCountryNameFR As String,
                          ByVal szCountryNameDE As String,
                          ByVal szCountryNameNL As String,
                          ByVal szCountryCode As String)

        ' Local Vars
        Dim nDictionaryID As Integer
        Dim szSQL As String

        ' Get the next Dictionary ID
        szSQL = "select max(dictionary_id) + 1 from dictionary"
        nDictionaryID = GetDataAsInteger(szSQL)

        ' Allow Identity Insert
        szSQL = "set identity_insert dictionary on;"

        ' Insert the Dictionary Items
        szSQL &= "insert into dictionary (dictionary_id, language_id, text) values (" & nDictionaryID.ToString.Trim & ", 1, '" & szCountryNameEN.Trim & "');"
        szSQL &= "insert into dictionary (dictionary_id, language_id, text) values (" & nDictionaryID.ToString.Trim & ", 2, '" & szCountryNameES.Trim & "');"
        szSQL &= "insert into dictionary (dictionary_id, language_id, text) values (" & nDictionaryID.ToString.Trim & ", 3, '" & szCountryNameFR.Trim & "');"
        szSQL &= "insert into dictionary (dictionary_id, language_id, text) values (" & nDictionaryID.ToString.Trim & ", 4, '" & szCountryNameDE.Trim & "');"
        szSQL &= "insert into dictionary (dictionary_id, language_id, text) values (" & nDictionaryID.ToString.Trim & ", 5, '" & szCountryNameNL.Trim & "');"

        ' Remove Identity Insert
        szSQL &= "set identity_insert dictionary off;"

        ' Allow Identity Insert
        szSQL &= "set identity_insert country on;"

        ' Insert the Country Record
        szSQL &= "insert into country (country_id, country_code, dictionary_id) values ((select max(country_id) + 1 from country), '" & szCountryCode.Trim.ToUpper & "', " & nDictionaryID.ToString.Trim & ");"

        ' Remove Identity Insert
        szSQL &= "set identity_insert country off;"

        ' Run Updates
        Execute(szSQL)

    End Sub

    Public Sub AddPostcode(ByVal nCountryID As Integer, ByVal szRegionName As String)

        ' Local Vars
        Dim nRegionID As Integer = GetDataAsInteger("select MAX(region_id) + 1 from PC_REGION")

        ' Init SQL to Add Region
        Dim szSQL As String =
            "insert into pc_region values (" & nRegionID.ToString.Trim & ", '" & szRegionName.Trim & "');" &
            "insert into postcode values ((select MAX(postcode_id) + 1 from POSTCODE), 0, " & nCountryID.ToString.Trim & ", " & nRegionID.ToString.Trim & ", 0, 0, 0,NULL,NULL,NULL,NULL,NULL,'Automatic');"

        ' Update
        Execute(szSQL)

    End Sub

    Public Sub AddPostcode(ByVal nCountryID As Integer, ByVal nRegionID As Integer, ByVal szAreaName As String, ByVal szPostcode As String, ByVal nDefaultPartnerID As Integer)

        ' Local Vars
        Dim nAreaID As Integer = GetDataAsInteger("select MAX(area_id) + 1 from PC_AREA")

        ' Init SQL to Add Area
        Dim szSQL As String =
            "insert into pc_area values (" & nAreaID.ToString.Trim & ", '" & szAreaName & "');" &
            "insert into postcode values ((select MAX(postcode_id) + 1 from POSTCODE), '" & szPostcode.Trim & "', " & nCountryID.ToString.Trim & ", " & nRegionID.ToString.Trim & ", " & nAreaID.ToString.Trim & ", 0, " & nDefaultPartnerID.ToString.Trim & ",NULL,NULL,NULL,NULL,NULL,'Automatic');"

        ' Update
        Execute(szSQL)

    End Sub

    Public Sub AddPostcode(ByVal nCountryID As Integer, ByVal nRegionID As Integer, ByVal nAreaID As Integer, ByVal szSubAreaName As String, ByVal szPostcode As String, ByVal nDefaultPartnerID As Integer)

        ' Local Vars
        Dim nSubAreaID As Integer = GetDataAsInteger("select MAX(subarea_id) + 1 from PC_SUBAREA")

        ' Init SQL to Add SubArea
        Dim szSQL As String =
            "insert into pc_subarea values (" & nSubAreaID.ToString.Trim & ", '" & szSubAreaName & "');" &
            "insert into postcode values ((select MAX(postcode_id) + 1 from POSTCODE), '" & szPostcode.Trim & "', " & nCountryID.ToString.Trim & ", " & nRegionID.ToString.Trim & ", " & nAreaID.ToString.Trim & ", " & nSubAreaID.ToString.Trim & ", " & nDefaultPartnerID.ToString.Trim & ",NULL,NULL,NULL,NULL,NULL,'Automatic');"

        ' Update
        Execute(szSQL)

    End Sub

    Public Function PostcodeDefaultPartner(ByVal nCountryID As Integer, ByVal nRegionID As Integer, ByVal nAreaID As Integer, Optional ByVal nSubAreaID As Integer = 0) As Integer

        ' Return the Default Partner for the Region, Area and possibly SubArea Provided
        Dim szSQL As String =
            "select default_partner_id from postcode where country_id = " & nCountryID.ToString.Trim & " and region_id = " & nRegionID.ToString.Trim & " and area_id = " & nAreaID.ToString.Trim & " and subarea_id = " & nSubAreaID.ToString.Trim
        Return GetDataAsInteger(szSQL)

    End Function

    Public Function RegionsAreasSubAreas(ByVal nCountryID As Integer, Optional ByVal nRegionID As Integer = 0, Optional ByVal nAreaID As Integer = 0) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select pc.Postcode_ID, d.text Country, r.Region_Name Region, a.Area_Name Area, s.SubArea_Name SubArea, pc.Postcode Postcode " &
            "from POSTCODE pc " &
                "inner join COUNTRY c on pc.Country_ID = c.Country_ID " &
                "inner join DICTIONARY d on c.Dictionary_ID = d.Dictionary_ID and d.Language_ID = 1 " &
                "inner join PC_REGION r on pc.Region_ID = r.Region_ID " &
                "inner join PC_AREA a on pc.Area_ID = a.Area_ID " &
                "inner join PC_SUBAREA s on pc.SubArea_ID = s.SubArea_ID " &
            "where pc.Country_ID = " & nCountryID.ToString.Trim

        ' If we have a Region ID
        If nRegionID > 0 Then

            ' Add this to the Clause
            szSQL &= " and pc.Region_ID = " & nRegionID.ToString.Trim

        End If

        ' If we have an Area ID
        If nAreaID > 0 Then

            ' Add this to the Clause
            szSQL &= " and pc.Area_ID = " & nAreaID.ToString.Trim

        End If

        ' Continue to Init SQL
        szSQL &= " order by r.Region_Name, a.Area_Name, s.SubArea_Name, pc.Postcode"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function RegionAreaSubArea(ByVal nPostcodeID As Integer,
                                      ByRef szPostcode As String,
                                      ByRef nCountryID As Integer,
                                      ByRef szCountry As String,
                                      ByRef nRegionID As Integer,
                                      ByRef szRegion As String,
                                      ByRef nAreaID As Integer,
                                      ByRef szArea As String,
                                      ByRef nSubAreaID As Integer,
                                      ByRef szSubArea As String) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean = False

        ' Init SQL
        Dim szSQL As String =
            "select pc.postcode Postcode, pc.Country_ID, d.text Country, pc.Region_ID, r.region_name Region, pc.Area_ID, a.area_name Area, pc.SubArea_ID, s.subarea_name SubArea " &
            "from POSTCODE pc " &
                "inner join COUNTRY c on pc.Country_ID = c.Country_ID " &
                "inner join DICTIONARY d on c.Dictionary_ID = d.Dictionary_ID and d.Language_ID = 1 " &
                "inner join PC_REGION r on pc.Region_ID = r.Region_ID " &
                "inner join PC_AREA A on pc.Area_ID = a.Area_ID " &
                "inner join PC_SUBAREA s on pc.SubArea_ID = s.SubArea_ID " &
            "where pc.Postcode_ID = " & nPostcodeID.ToString.Trim

        ' Get Result
        Dim dtDataTable As DataTable = GetDataAsDataTable(szSQL)

        ' If we got Results
        If dtDataTable.Rows.Count > 0 Then

            ' Assign to return Variables
            szPostcode = dtDataTable.Rows(0).Item("Postcode").ToString.Trim
            nCountryID = Convert.ToInt32(dtDataTable.Rows(0).Item("Country_ID"))
            szCountry = dtDataTable.Rows(0).Item("Country").ToString.Trim
            nRegionID = Convert.ToInt32(dtDataTable.Rows(0).Item("Region_ID"))
            szRegion = dtDataTable.Rows(0).Item("Region").ToString.Trim
            nAreaID = Convert.ToInt32(dtDataTable.Rows(0).Item("Area_ID"))
            szArea = dtDataTable.Rows(0).Item("Area").ToString.Trim
            nSubAreaID = Convert.ToInt32(dtDataTable.Rows(0).Item("SubArea_ID"))
            szSubArea = dtDataTable.Rows(0).Item("SubArea").ToString.Trim

            ' Set Flag
            bRetVal = True

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' Return the Result
        Return bRetVal

    End Function

    Public Function PostcodeIDsWithPropertiesIn(ByVal nCountryID As Integer, Optional ByVal nRegionID As Integer = 0, Optional ByVal nAreaID As Integer = 0, Optional ByVal nSubAreaID As Integer = 0) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select pc.postcode_id " &
            "from PROPERTY p " &
                "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID and pc.Country_ID = " & nCountryID.ToString.Trim

        ' If we have a Region ID, Add Clause to Query
        If nRegionID > 0 Then
            szSQL &= " and pc.Region_ID = " & nRegionID.ToString.Trim
        End If

        ' If we have a Area ID, Add Clause to Query
        If nAreaID > 0 Then
            szSQL &= " and pc.Area_ID = " & nAreaID.ToString.Trim
        End If

        ' If we have a SubArea ID, Add Clause to Query
        If nSubAreaID > 0 Then
            szSQL &= " and pc.SubArea_ID = " & nSubAreaID.ToString.Trim
        End If

        ' Add Final Clause
        szSQL &= " " &
            "group by pc.Postcode_ID " &
            "order by pc.Postcode_ID;"

        ' Return the Data
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function PostcodeIDsIn(ByVal nCountryID As Integer, Optional ByVal nRegionID As Integer = 0, Optional ByVal nAreaID As Integer = 0, Optional ByVal nSubAreaID As Integer = 0) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select pc.postcode_id " &
            "from POSTCODE pc " &
            "where pc.Country_ID = " & nCountryID.ToString.Trim

        ' If we have a Region ID, Add Clause to Query
        If nRegionID > 0 Then
            szSQL &= " and pc.Region_ID = " & nRegionID.ToString.Trim
        End If

        ' If we have a Area ID, Add Clause to Query
        If nAreaID > 0 Then
            szSQL &= " and pc.Area_ID = " & nAreaID.ToString.Trim
        End If

        ' If we have a SubArea ID, Add Clause to Query
        If nSubAreaID > 0 Then
            szSQL &= " and pc.SubArea_ID = " & nSubAreaID.ToString.Trim
        End If

        ' Add Final Clause
        szSQL &= " " &
            "group by pc.Postcode_ID " &
            "order by pc.Postcode_ID;"

        ' Return the Data
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Sub ReassignPostcode(ByVal nOldPostcodeID As Integer, ByVal nNewPostcodeID As Integer)

        ' Init SQL
        Dim szSQL As String =
            "update property set postcode_id = " & nNewPostcodeID.ToString.Trim & " where postcode_id = " & nOldPostcodeID.ToString.Trim

        ' Run Update
        Execute(szSQL)

    End Sub

    Public Sub DeleteCountry(ByVal nCountryID As Integer)

        ' Init SQL to Remove this Country from the Dictionary, the Country Table and the Postcode Table
        Dim szSQL As String =
            "delete from postcode where country_id = " & nCountryID.ToString.Trim & ";" &
            "delete from dictionary where dictionary_id in (select dictionary_id from country where country_id = " & nCountryID.ToString.Trim & ");" &
            "delete from country where country_id = " & nCountryID.ToString.Trim & ";"

        ' Run Update
        Execute(szSQL)

    End Sub

    Public Sub DeleteRegion(ByVal nRegionID As Integer)

        ' Remove the Entry from the Entity and Postcode Table
        Dim szSQL As String =
            "delete from postcode where region_id = " & nRegionID.ToString.Trim & ";" &
            "delete from pc_region where region_id = " & nRegionID.ToString.Trim & ";"

        ' Update
        Execute(szSQL)

    End Sub

    Public Sub DeleteArea(ByVal nAreaID As Integer)

        ' Remove the Entry from the Entity and Postcode Table
        Dim szSQL As String =
            "delete from postcode where area_id = " & nAreaID.ToString.Trim & ";" &
            "delete from pc_area where area_id = " & nAreaID.ToString.Trim & ";"

        ' Update
        Execute(szSQL)

    End Sub

    Public Sub DeleteSubArea(ByVal nSubAreaID As Integer)

        ' Remove the Entry from the Entity and Postcode Table
        Dim szSQL As String =
            "delete from postcode where subarea_id = " & nSubAreaID.ToString.Trim & ";" &
            "delete from pc_subarea where subarea_id = " & nSubAreaID.ToString.Trim & ";"

        ' Update
        Execute(szSQL)

    End Sub

    Public Function PostcodeID(ByVal nRegionID As Integer, ByVal nAreaID As Integer, ByVal nSubAreaID As Integer) As Integer

        ' Init SQL
        Dim szSQL As String = "select postcode_id from postcode where region_id = " & nRegionID.ToString.Trim & " and area_id = " & nAreaID.ToString.Trim & " and subarea_id = " & nSubAreaID.ToString.Trim

        ' Return the Result
        Return GetDataAsInteger(szSQL)

    End Function

    Public Function PropertiesUsingSystemVariable(ByVal eSystemVariable As E_SystemVariable, ByVal nID As Integer, ByVal nPartnerID As Integer) As DataTable

        ' If this is Language or Payment Type, Ignore
        If eSystemVariable = E_SystemVariable.Language Or eSystemVariable = E_SystemVariable.PaymentType Then
            Return Nothing
        Else

            ' Local Vars
            Dim szSQL As String

            ' If this is Property Features
            If eSystemVariable = E_SystemVariable.Feature Then

                ' Init SQL
                szSQL =
                    "select * from " &
                    "( " &
                        "select " &
                            "case " &
                                "when pr.Reference IS null then p.Property_Ref " &
                                "else cast(pr.Reference as varchar(10)) " &
                            "end Reference " &
                        "from property_features pf " &
                            "inner join PROPERTY p on pf.Property_Ref = p.Property_Ref " &
                            "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID and pr.Partner_ID = " & nPartnerID.ToString.Trim & " " &
                        "where pf.Features_ID = " & nID.ToString.Trim & " " &
                    ") t1 " &
                    "order by t1.Reference"

            Else

                ' Init SQL
                szSQL =
                    "select " &
                        "case " &
                            "when pr.Reference IS null then p.Property_Ref " &
                            "else cast(pr.Reference as varchar(10)) " &
                        "end Reference " &
                        "from PROPERTY p " &
                            "left join PROPERTY_PARTNER_REF pr on p.Property_ID = pr.Property_ID and pr.Partner_ID = " & nPartnerID.ToString.Trim & " " &
                        "where "

                ' Depending on the System Variable
                Select Case eSystemVariable

                    Case E_SystemVariable.Location
                        szSQL &= "Location_ID"

                    Case E_SystemVariable.Status
                        szSQL &= "Status_ID"

                    Case E_SystemVariable.Type
                        szSQL &= "Property_Type_ID"

                    Case E_SystemVariable.View
                        szSQL &= "Views_ID"

                End Select

                ' Continue to Init SQL
                szSQL &= " = " & nID.ToString.Trim & " " &
                        "order by Property_Ref"

            End If

            ' Return the Result
            Return GetDataAsDataTable(szSQL)

        End If

    End Function

    Public Sub RemoveSystemVariable(ByVal eSystemVariable As E_SystemVariable, ByVal nID As Integer)

        ' Init Variable Specific Entry
        Dim szVariableSpecific As String = String.Empty

        ' Depending on the Variable
        Select Case eSystemVariable

            Case E_SystemVariable.BuyerSource
                szVariableSpecific = "buyer_source where buyer_source_id"

            Case E_SystemVariable.BuyerStatus
                szVariableSpecific = "buyer_status where buyer_status_id"

            Case E_SystemVariable.Feature
                szVariableSpecific = "features where features_id"

            Case E_SystemVariable.Language
                szVariableSpecific = "language where language_id"

            Case E_SystemVariable.Location
                szVariableSpecific = "location where location_id"

            Case E_SystemVariable.PaymentType
                szVariableSpecific = "payment_type where payment_type_id"

            Case E_SystemVariable.Status
                szVariableSpecific = "property_status where status_id"

            Case E_SystemVariable.Type
                szVariableSpecific = "property_type where property_type_id"

            Case E_SystemVariable.View
                szVariableSpecific = "views where views_id"

            Case E_SystemVariable.Criterias
                szVariableSpecific = "Criterias where Criteria_Id"

            Case E_SystemVariable.ActionTypes
                szVariableSpecific = "tblActionType where Action_Type_Id"

        End Select

        ' If we Assigned the Specific Variable a Value
        If szVariableSpecific.Trim <> String.Empty Then

            ' Init SQL to Remove Dictionary Entries Associated with this Entity
            Dim szSQL As String =
                "delete from dictionary where dictionary_id in (select dictionary_id from " & szVariableSpecific.Trim & " = " & nID.ToString.Trim & ");"

            ' Remove the Entry from the Views Table
            szSQL &= "delete from " & szVariableSpecific.Trim & " = " & nID.ToString.Trim & ";"

            ' Perform Update
            Execute(szSQL)

        End If

    End Sub
    Public Sub SaveSystemVariablelang(ByVal eSystemVariable As E_SystemVariable, ByVal alEntries As ArrayList, Optional ByVal nID As Integer = 0, Optional ByVal szPropertyCode As String = vbNullString, Optional ByVal szlangcode As String = vbNullString)

        ' Local Vars
        Dim nDictionaryID As Integer
        Dim nLanguageID As Integer = 0
        Dim szTable As String = String.Empty
        Dim szParameter As String = String.Empty
        Dim bAssigned As Boolean = False
        Dim szSQL As String = String.Empty

        ' Depending on the Variable Type, Assign Variables
        Select Case eSystemVariable

            Case E_SystemVariable.BuyerSource
                szTable = "buyer_source"
                szParameter = "buyer_source_id"
                bAssigned = True

            Case E_SystemVariable.BuyerStatus
                szTable = "buyer_status"
                szParameter = "buyer_status_id"
                bAssigned = True

            Case E_SystemVariable.Feature
                szTable = "features"
                szParameter = "features_id"
                bAssigned = True

            Case E_SystemVariable.Language
                szTable = "language"
                szParameter = "language_id"
                bAssigned = True

            Case E_SystemVariable.Location
                szTable = "location"
                szParameter = "location_id"
                bAssigned = True

            Case E_SystemVariable.PaymentType
                szTable = "payment_type"
                szParameter = "payment_type_id"
                bAssigned = True

            Case E_SystemVariable.Status
                szTable = "property_status"
                szParameter = "status_id"
                bAssigned = True

            Case E_SystemVariable.Type
                szTable = "property_type"
                szParameter = "property_type_id"
                bAssigned = True

            Case E_SystemVariable.View
                szTable = "views"
                szParameter = "views_id"
                bAssigned = True

            Case E_SystemVariable.Criterias
                szTable = "Criterias"
                szParameter = "Criteria_Id"
                bAssigned = True

            Case E_SystemVariable.ActionTypes
                szTable = "tblActionType"
                szParameter = "ActionTypeId"
                bAssigned = True

        End Select

        ' If we have Parameters Assigned
        If bAssigned Then

            ' If we have had an Entity ID Supplied
            If nID > 0 Then

                ' Remove Previous Entry
                RemoveSystemVariable(eSystemVariable, nID)

            Else

                ' Get the Next ID
                nID = GetDataAsInteger("select max(" & szParameter.Trim & ") + 1 from " & szTable.Trim)

            End If

            ' Init Dictionatry ID
            nDictionaryID = GetDataAsInteger("select max(dictionary_id) + 1 from dictionary")

            ' For each Entry
            For Each szEntry As String In alEntries

                ' Increment Language ID
                nLanguageID += 1

                ' If we have a Description Supplied
                If szEntry.Trim <> vbNullString Then

                    ' Init SQL to Insert Dictionary ID and the Views Entry
                    szSQL &= "insert into dictionary (Dictionary_ID, Language_ID, Text) values (" & nDictionaryID.ToString.Trim & ", " & nLanguageID.ToString.Trim & ", '" & szEntry.Trim & "');"

                End If

            Next

            ' If we have a SQL Statement
            If szSQL <> String.Empty Then

                ' Prefix to allow Identity Insert
                szSQL = "SET IDENTITY_INSERT dictionary ON;" & szSQL

                ' Reset Identity Insert
                szSQL &= "SET IDENTITY_INSERT dictionary OFF;"

                ' Prefix to allow Identity Insert
                szSQL &= "SET IDENTITY_INSERT " & szTable.Trim & " ON;"

                ' If this is Property Type
                If eSystemVariable = E_SystemVariable.Type Then

                    ' Property Type
                    szSQL &= "insert into " & szTable.Trim & " (" & szParameter.Trim & ", dictionary_id, property_code) values (" & nID.ToString.Trim & ", " & nDictionaryID.ToString.Trim & ", '" & szPropertyCode.Trim.ToUpper & "');"

                Else

                    ' All Others
                    szSQL &= "insert into " & szTable.Trim & " (" & szParameter.Trim & ", dictionary_id, Language_Short_Code) values (" & nID.ToString.Trim & ", " & nDictionaryID.ToString.Trim & ", '" & alEntries(5).Trim & "');"

                End If

                ' Reset Identity Insert
                szSQL &= "SET IDENTITY_INSERT " & szTable.Trim & " OFF;"

                ' Run Updates
                Execute(szSQL)

            End If

        End If

    End Sub

    Public Sub SaveSystemVariable(ByVal eSystemVariable As E_SystemVariable, ByVal alEntries As ArrayList, Optional ByVal nID As Integer = 0, Optional ByVal szPropertyCode As String = vbNullString)

        ' Local Vars
        Dim nDictionaryID As Integer
        Dim nLanguageID As Integer = 0
        Dim szTable As String = String.Empty
        Dim szParameter As String = String.Empty
        Dim bAssigned As Boolean = False
        Dim szSQL As String = String.Empty

        ' Depending on the Variable Type, Assign Variables
        Select Case eSystemVariable

            Case E_SystemVariable.BuyerSource
                szTable = "buyer_source"
                szParameter = "buyer_source_id"
                bAssigned = True

            Case E_SystemVariable.BuyerStatus
                szTable = "buyer_status"
                szParameter = "buyer_status_id"
                bAssigned = True

            Case E_SystemVariable.Feature
                szTable = "features"
                szParameter = "features_id"
                bAssigned = True

            Case E_SystemVariable.Language
                szTable = "language"
                szParameter = "language_id"
                bAssigned = True

            Case E_SystemVariable.Location
                szTable = "location"
                szParameter = "location_id"
                bAssigned = True

            Case E_SystemVariable.PaymentType
                szTable = "payment_type"
                szParameter = "payment_type_id"
                bAssigned = True

            Case E_SystemVariable.Status
                szTable = "property_status"
                szParameter = "status_id"
                bAssigned = True

            Case E_SystemVariable.Type
                szTable = "property_type"
                szParameter = "property_type_id"
                bAssigned = True

            Case E_SystemVariable.View
                szTable = "views"
                szParameter = "views_id"
                bAssigned = True

            Case E_SystemVariable.Criterias
                szTable = "Criterias"
                szParameter = "Criteria_Id"
                bAssigned = True

            Case E_SystemVariable.ActionTypes
                szTable = "tblActionType"
                szParameter = "Action_Type_Id"
                bAssigned = True

        End Select

        ' If we have Parameters Assigned
        If bAssigned Then

            ' If we have had an Entity ID Supplied
            If nID > 0 Then

                ' Remove Previous Entry
                RemoveSystemVariable(eSystemVariable, nID)

            Else

                ' Get the Next ID
                nID = GetDataAsInteger("select max(" & szParameter.Trim & ") + 1 from " & szTable.Trim)

            End If

            ' Init Dictionatry ID
            nDictionaryID = GetDataAsInteger("select max(dictionary_id) + 1 from dictionary")

            ' For each Entry
            For Each szEntry As String In alEntries

                ' Increment Language ID
                nLanguageID += 1

                ' If we have a Description Supplied
                If szEntry.Trim <> vbNullString Then

                    ' Init SQL to Insert Dictionary ID and the Views Entry
                    szSQL &= "insert into dictionary (Dictionary_ID, Language_ID, Text) values (" & nDictionaryID.ToString.Trim & ", " & nLanguageID.ToString.Trim & ", '" & szEntry.Trim & "');"

                End If

            Next

            ' If we have a SQL Statement
            If szSQL <> String.Empty Then

                ' Prefix to allow Identity Insert
                szSQL = "SET IDENTITY_INSERT dictionary ON;" & szSQL

                ' Reset Identity Insert
                szSQL &= "SET IDENTITY_INSERT dictionary OFF;"

                ' Prefix to allow Identity Insert
                szSQL &= "SET IDENTITY_INSERT " & szTable.Trim & " ON;"

                ' If this is Property Type
                If eSystemVariable = E_SystemVariable.Type Then

                    ' Property Type
                    szSQL &= "insert into " & szTable.Trim & " (" & szParameter.Trim & ", dictionary_id, property_code) values (" & nID.ToString.Trim & ", " & nDictionaryID.ToString.Trim & ", '" & szPropertyCode.Trim.ToUpper & "');"

                Else

                    ' All Others
                    szSQL &= "insert into " & szTable.Trim & " (" & szParameter.Trim & ", dictionary_id) values (" & nID.ToString.Trim & ", " & nDictionaryID.ToString.Trim & ");"

                End If

                ' Reset Identity Insert
                szSQL &= "SET IDENTITY_INSERT " & szTable.Trim & " OFF;"

                ' Run Updates
                Execute(szSQL)

            End If

        End If

    End Sub

    Public Function LoadPostcodeTable(ByVal nLanguageID As Integer, ByVal bContainingPropertiesOnly As Boolean, Optional ByVal alPostcodeIDExclusions As ArrayList = Nothing, Optional ByVal nPartnerID As Integer = 0, Optional ByVal nMustIncludePostcodeID As Integer = 0) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select pc.Country_ID, d.Text Country_Name, pc.Region_ID, r.Region_Name, pc.Area_ID, a.Area_Name, pc.SubArea_ID, s.SubArea_Name, pc.Postcode_ID, pc.Postcode " &
            "from postcode pc " &
                "inner join COUNTRY c on pc.Country_ID = c.Country_ID " &
                "inner join DICTIONARY d on c.Dictionary_ID = d.Dictionary_ID and d.Language_ID = " & nLanguageID.ToString.Trim & " " &
                "inner join PC_REGION r on pc.Region_ID = r.Region_ID " &
                "inner join PC_AREA a on pc.Area_ID = a.Area_ID " &
                "inner join PC_SUBAREA s on pc.SubArea_ID = s.SubArea_ID "

        ' If we are only Loading those Areas where Properties Exist
        If bContainingPropertiesOnly Then

            ' Add Clause
            szSQL &=
                "inner join PROPERTY p on pc.postcode_id = p.postcode_id "

        End If

        ' Init Delimiter
        Dim szDelim As String = "where "

        ' If we have Postcode Exclusions
        If Not alPostcodeIDExclusions Is Nothing Then

            ' Init SQL
            szSQL &= szDelim &
                "pc.Postcode_ID not in " &
                "("

            ' Init Delimiter
            szDelim = String.Empty

            ' For each Postcode ID
            For Each nID In alPostcodeIDExclusions

                ' Add to SQL
                szSQL &= szDelim & nID.ToString.Trim

                ' Update Delimiter
                szDelim = ","

            Next

            ' Continue to Init SQL
            szSQL &= ") "

            ' Update Delimiter
            szDelim = "and "

        End If

        ' If we have been passed a Partner ID, restrict to just their Areas
        If nPartnerID > 0 Then

            ' Add Clause
            szSQL &= szDelim &
                "pc.Default_Partner_ID = " & nPartnerID.ToString.Trim & " "

            ' Update Delimiter
            szDelim = "or "

            ' If we must include a particular Postcode ID
            If nMustIncludePostcodeID > 0 Then

                ' Add Clause
                szSQL &= szDelim &
                    "pc.Postcode_ID = " & nMustIncludePostcodeID.ToString.Trim & " "

            End If

        End If

        ' Continue to Init SQL
        szSQL &=
            "order by d.Text, r.Region_Name, a.Area_Name, s.SubArea_Name"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function NumberOfPropertyImages(ByVal szPropertyReference As String) As Integer

        ' Init SQL
        Dim szSQL As String = "select Num_Photos from PROPERTY where Property_Ref = '" & szPropertyReference.Trim.ToUpper & "'"

        ' Return the Result
        Return GetDataAsInteger(szSQL)

    End Function

    Public Function UpdateTestimonial(ByVal nTestimonialID As Integer, ByVal dtDate As Date, ByVal szText As String) As Integer

        ' Local Vars
        Dim nRetVal As Integer = nTestimonialID
        Dim szSQL As String

        ' If this is a NEW Testimonial
        If nTestimonialID = 0 Then

            ' Init SQL
            szSQL = "insert into TESTIMONIALS (Testimonial_Date, Testimonial_Text) Values (" & SQLDateTime(dtDate) & ", '" & szText.Replace("'", "''").Replace(vbLf, "' + CHAR(13) + CHAR(10) + '").Trim & "')"

        Else

            ' Update Existing
            szSQL = "update testimonials set testimonial_date = " & SQLDateTime(dtDate) & ",  testimonial_text = '" & szText.Replace("'", "''").Replace(vbLf, "' + CHAR(13) + CHAR(10) + '").Trim & "' where testimonial_id = " & nTestimonialID.ToString.Trim

        End If

        ' Run Update
        Execute(szSQL)

        ' If we have no Testimonial ID
        If nRetVal = 0 Then

            ' Init SQL
            szSQL = "select MAX(Testimonial_ID) from TESTIMONIALS"

            ' Get the new ID
            nRetVal = GetDataAsInteger(szSQL)

        End If

        ' Return the Result
        Return nRetVal

    End Function

    Public Function GetPassword(ByVal nUserID As Integer) As String

        Return GetDataAsString("select Contact_Password from CONTACT where Contact_ID = " & nUserID.ToString.Trim).Trim

    End Function

    Public Sub UpdatePassword(ByVal nContactID As Integer, ByVal szPassword As String)

        ' Update Password
        Execute("update CONTACT set Contact_Password = '" & szPassword.Trim & "' where Contact_ID = " & nContactID.ToString.Trim)

    End Sub

    Public Function DatabaseStats() As DataTable

        ' Init SQL
        Dim szSQL As String =
        "SELECT " &
            "t.NAME 'Table Name', " &
            "p.rows 'Row Counts', " &
            "SUM(a.total_pages) * 8 'Total Space KB', " &
            "SUM(a.used_pages) * 8 'Used Space KB', " &
            "(SUM(a.total_pages) - SUM(a.used_pages)) * 8 'Unused Space KB' " &
        "FROM " &
            "sys.tables t " &
        "INNER JOIN " &
            "sys.indexes i ON t.OBJECT_ID = i.object_id " &
        "INNER JOIN " &
            "sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id " &
        "INNER JOIN " &
            "sys.allocation_units a ON p.partition_id = a.container_id " &
        "WHERE " &
            "t.NAME NOT LIKE 'dt%' " &
            "AND t.is_ms_shipped = 0 " &
            "AND i.OBJECT_ID > 255 " &
        "GROUP BY " &
            "t.Name, p.Rows " &
        "ORDER BY " &
            "t.Name"

        ' Return the Database Stats
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function BuyerSourceAll() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select bs.Buyer_Source_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch " &
            "from BUYER_SOURCE bs " &
                "left join DICTIONARY english on bs.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on bs.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on bs.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on bs.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on bs.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function BuyerStatusAll() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select bs.Buyer_Status_ID ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch " &
            "from BUYER_STATUS bs " &
                "left join DICTIONARY english on bs.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on bs.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on bs.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on bs.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on bs.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function
    Public Function ActionTypesAll() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select bs.Action_Type_Id ID, isnull(english.Text, 'Auto Translate') English, isnull(spanish.Text, 'Auto Translate') Spanish, isnull(french.Text, 'Auto Translate') French, isnull(german.Text, 'Auto Translate') German, isnull(dutch.Text, 'Auto Translate') Dutch " &
            "from tblActionType bs " &
                "left join DICTIONARY english on bs.Dictionary_ID = english.Dictionary_ID and english.Language_ID = 1 " &
                "left join DICTIONARY spanish on bs.Dictionary_ID = spanish.Dictionary_ID and spanish.Language_ID = 2 " &
                "left join DICTIONARY french on bs.Dictionary_ID = french.Dictionary_ID and french.Language_ID = 3 " &
                "left join DICTIONARY german on bs.Dictionary_ID = german.Dictionary_ID and german.Language_ID = 4 " &
                "left join DICTIONARY dutch on bs.Dictionary_ID = dutch.Dictionary_ID and dutch.Language_ID = 5 " &
            "order by english.Text"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function LatestProperties(ByVal isCreated As Integer, ByVal isModified As Integer,
                               Optional ByVal dteCreatedSince As Date = #1/1/1900#,
                               Optional ByVal dteModifiedSince As Date = #1/1/1900#
                               ) As DataTable
        ' Local Vars
        Dim szDelim As String = "where"
        Dim szSQL As String =
            "select " &
                "p.property_id id, " &
                "p.public_price, " &
                "p.property_ref 'IA Ref', " &
                "(select top 1 Reference from property_partner_ref where property_Id=p.Property_ID) 'Other Ref', " &
                "case p.IsIssue when 1 then 'Red' else 'White' end as 'IsIssue', " &
                "CONVERT(VARCHAR(10),p.Create_Date ,103) Created, " &
                "CONVERT(VARCHAR(10),p.Last_Modified ,103) LastModified, " &
                "d_type.Text Type, " &
                "r.region_name Area, " &
                "a.area_name Town, " &
                "d_status.text Status, " &
                "cast(p.public_price as varchar) Price, " &
                "p.Viewed Viewed, " &
                "(select case count(*) when 0 then 'No' else 'Yes' end from FEATURED_PROPERTY where FEATURED_PROPERTY.Property_Ref=p.Property_Ref) Excl, " &
                "(select contact_name from contact where contact_id=p.Listed_By_Contact_ID) 'Lister Name', " &
                "(select top 1 CONVERT(VARCHAR(10),p.Last_Modified ,103) from property_history where Property_Ref=p.Property_Ref order by History_Id desc) 'LastHistory', " &
                "(select text from dictionary where dictionary_Id in(select Dictionary_Id from property_history_type where History_Type_Id in(select top 1 Type_Id from property_history where Property_Ref=p.Property_Ref order by History_Id desc)) and language_id=1) 'History Type', " &
                "(select top 1 case when len(History_Text)>40 then Left(History_Text,40)+'....' else History_Text end  from property_history where Property_Ref=p.Property_Ref order by History_Id desc) 'History Text', " &
                "p.Create_Date CreateDateForSorting, " &
                "p.Last_Modified ModifiedDateForSorting, " &
                "(select top 1 ph.Last_Modified 'LastHistoryDate' from property_history ph where ph.Property_Ref=p.Property_Ref order by ph.History_Id desc) 'LastHistoryDate' " &
                "from property p " &
                "inner join PROPERTY_STATUS s on p.Status_ID = s.Status_ID " &
                "inner join DICTIONARY d_status on s.Dictionary_ID = d_status.Dictionary_ID and d_status.Language_ID = 1 " &
                "inner join PROPERTY_TYPE t on p.Property_Type_ID = t.Property_Type_ID " &
                "inner join DICTIONARY d_type on t.Dictionary_ID = d_type.Dictionary_ID and d_type.Language_ID = 1 " &
                "inner join POSTCODE pc on p.Postcode_ID = pc.Postcode_ID " &
                "inner join country c on pc.country_id = c.country_id " &
                "inner join dictionary d_country on c.dictionary_id = d_country.dictionary_id and d_country.language_id = 1 " &
                "inner join PC_REGION r on pc.Region_ID = r.Region_ID " &
                "inner join PC_AREA a on pc.Area_ID = a.Area_ID "

        ' If we have set a Date for Properties Created Since
        If dteCreatedSince > #1/1/1900# Then

            ' Update SQL
            szSQL &= szDelim

            ' If we have also Specified a Modified Date
            If dteModifiedSince > #1/1/1900# Then

                ' Add Parenthesis
                szSQL &= "("

                ' Update Delimter
                szDelim = "or"

            Else

                ' Update Delimiter
                szDelim = "and"

            End If

            ' Continue to Update SQL
            szSQL &= " p.create_date >= " & SQLDateTime(dteCreatedSince) & " "

        End If

        ' If we have set a Date for Properties Modified Since
        If dteModifiedSince > #1/1/1900# Then

            ' Update SQL
            szSQL &= szDelim & " p.last_modified >= " & SQLDateTime(dteModifiedSince) & " and datediff(day, p.Create_Date, p.Last_Modified) > 6  "

            ' If we have also Specified a Created Date
            If dteCreatedSince > #1/1/1900# Then

                ' Add Parenthesis  
                szSQL &= ") "

            Else

                ' Only Interested in Modified
                'szSQL &= "and datediff(day, p.Create_Date, p.Last_Modified) > 6 "

            End If

        End If

        'If dteModifiedSince > #1/1/1900# And dteCreatedSince > #1/1/1900# Then
        '    ' Add Order by Clause
        '    szSQL &= "order by p.Create_Date desc"
        'End If
        If isCreated = 0 And isModified = 1 Then
            ' Add Order by Clause
            szSQL &= "order by p.Last_Modified desc"
        Else
            szSQL &= "order by p.Create_Date desc"
        End If

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Sub AuditPropertyViewed(ByVal nPropertyID As Integer)

        ' Audit Viewing
        Execute("update PROPERTY set Viewed = (select Viewed + 1 from PROPERTY where Property_ID = " & nPropertyID.ToString.Trim & ") where property_id = " & nPropertyID.ToString.Trim)

    End Sub

    Public Function ClientTourFeedback(ByVal nPartnerID As Integer, ByVal nClientTourID As Integer) As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select ctp.tour_id, " &
                "ctp.tour_property_id property_id, " &
                "isnull(cast(ppr.reference as varchar(10)), pr.property_ref) partner_reference " &
            "from PROPERTY pr " &
                "inner join CLIENT_TOUR_PROPERTIES ctp on ctp.tour_property_id = pr.Property_ID and ctp.tour_id = " & nClientTourID.ToString.Trim & " " &
                "left join property_partner_ref ppr on pr.property_id = ppr.property_id and ppr.partner_id = " & nPartnerID.ToString.Trim & " " &
            "where not exists " &
                "( " &
                    "select * " &
                    "from CLIENT_TOUR_FEEDBACK " &
                    "where ctp.tour_id = tour_id and ctp.tour_property_id = Property_ID " &
                ") " &
            "order by isnull(cast(ppr.reference as varchar(10)), pr.property_ref)"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

    Public Function ClientTourFeedbackRemaining(ByVal nClientTourID As Integer) As Boolean

        ' Init Return Var
        Dim bRetVal As Boolean = False

        ' Check Feedback
        Dim dtDataTable As DataTable = ClientTourFeedback(0, nClientTourID)

        ' Set Flag
        bRetVal = dtDataTable.Rows.Count > 0

        ' Tidy
        dtDataTable.Dispose()

        ' Return the Result
        Return bRetVal

    End Function

    Public Sub SaveClientTourFeedback(ByVal nTourID As Integer, ByVal nPropertyID As Integer, ByVal szHistory As String, ByVal nUserID As Integer)

        ' Insert into History
        Dim szSQL As String =
            "insert into property_history " &
            "(" &
                "property_ref, " &
                "type_id, " &
                "history_text, " &
                "modified_by" &
            ") " &
            "values " &
            "(" &
                "(select property_ref from PROPERTY where Property_ID = " & nPropertyID.ToString.Trim & "), " &
                "(select ht.history_type_id from property_history_type ht	inner join dictionary d on ht.dictionary_id = d.dictionary_id and d.text = 'Tour Feedback' and d.language_id = 1), " &
                "'" & szHistory.Replace("'", "''").Trim & "', " &
                nUserID.ToString.Trim &
            ");"

        ' Audit Feedback Left
        szSQL &=
            "insert into CLIENT_TOUR_FEEDBACK (Tour_ID, Property_ID) VALUES (" & nTourID.ToString.Trim & ", " & nPropertyID.ToString.Trim & ");"

        ' Run the Update
        Dim CDataAccess As New ClassDataAccess
        CDataAccess.Execute(szSQL)
        CDataAccess = Nothing

    End Sub

    Public Sub ClientTourVendorTourBy(ByVal nClientTourID As Integer, ByRef szClient As String, ByRef szTourBy As String)

        ' Init Returns
        szClient = String.Empty
        szTourBy = String.Empty

        ' Init SQL
        Dim szSQL As String =
            "select ltrim(rtrim(ltrim(rtrim(client.Buyer_Forename)) + ' ' + ltrim(rtrim(client.Buyer_Surname)))) Client, " &
                "isnull(tour_by.Contact_Name, '') TourBy " &
            "from client_tour ct " &
                "left join BUYER client on ct.tour_buyer_id = client.Buyer_ID " &
                "left join CONTACT tour_by on ct.tour_with_id = tour_by.Contact_ID where ct.tour_id = " & nClientTourID.ToString.Trim

        ' Run the Query
        Dim dtDataTable As DataTable = GetDataAsDataTable(szSQL)

        ' If we Received a Result
        If dtDataTable.Rows.Count > 0 Then

            ' Assign Variables
            szClient = dtDataTable.Rows(0).Item("Client").ToString.Trim
            szTourBy = dtDataTable.Rows(0).Item("TourBy").ToString.Trim

        End If

        ' Tidy
        dtDataTable.Dispose()

    End Sub

    Public Sub RegionAreaSubAreaNames(ByVal nRegionID As Integer, ByVal nAreaID As Integer, ByVal nSubAreaID As Integer, ByRef szRegion As String, ByRef szArea As String, ByRef szSubArea As String)

        ' Init SQL
        Dim szSQL As String =
            "select r.Region_Name Region"

        ' If an Area ID has been Provided
        If nAreaID > 0 Then
            szSQL &= ", a.Area_Name Area"
        End If

        ' If a SubArea ID has been Provided
        If nSubAreaID > 0 Then
            szSQL &= ", s.SubArea_Name SubArea"
        End If

        ' Continue to Init SQL
        szSQL &= " " &
            "from POSTCODE pc " &
             "inner join PC_REGION r on pc.Region_ID = r.Region_ID "

        ' If an Area ID has been Provided
        If nAreaID > 0 Then
            szSQL &= "inner join PC_AREA a on pc.Area_ID = a.Area_ID "
        End If

        ' If a SubArea ID has been Provided
        If nSubAreaID > 0 Then
            szSQL &= "inner join PC_SUBAREA s on pc.SubArea_ID = s.SubArea_ID "
        End If

        ' Continue to Init SQL
        szSQL &=
            "where r.Region_ID = " & nRegionID.ToString.Trim

        ' If an Area ID has been Provided
        If nAreaID > 0 Then
            szSQL &= " and a.Area_ID = " & nAreaID.ToString.Trim
        End If

        ' If a SubArea ID has been Provided
        If nSubAreaID > 0 Then
            szSQL &= " and s.SubArea_ID = " & nSubAreaID.ToString.Trim
        End If

        ' Get the Result
        Dim dtDataTable As DataTable = GetDataAsDataTable(szSQL)

        ' If we got a Result
        If dtDataTable.Rows.Count > 0 Then

            ' Set the Return Variables
            szRegion = dtDataTable.Rows(0).Item("Region").ToString.Trim

            ' If an Area ID has been Provided
            If nAreaID > 0 Then
                szArea = dtDataTable.Rows(0).Item("Area").ToString.Trim
            End If

            ' If a SubArea ID has been Provided
            If nSubAreaID > 0 Then
                szSubArea = dtDataTable.Rows(0).Item("SubArea").ToString.Trim
            End If

        End If

        ' Tidy
        dtDataTable.Dispose()

        ' Clear Not Defined SubArea
        If szSubArea = "Not Defined" Then
            szSubArea = String.Empty
        End If

    End Sub

    Public Function AddContactType(ByVal szContactTypeName As String) As Integer

        ' Init SQL
        Dim szSQL As String =
            "insert into contact_type (contact_type_id, contact_type) values ((select max(contact_type_id) + 1 from contact_type), '" & szContactTypeName.Trim & "');" &
            "select max(contact_type_ID) from contact_type;"

        ' Get the Result
        Return GetDataAsInteger(szSQL)

    End Function

    Public Sub LoadContactTypeOptions(ByVal nContactTypeID As Integer,
                                      ByRef bRegNo As Boolean,
                                      ByRef bAddress As Boolean,
                                      ByRef bTelephone As Boolean,
                                      ByRef bMobile As Boolean,
                                      ByRef bFax As Boolean,
                                      ByRef bEmail As Boolean,
                                      ByRef bNotes As Boolean,
                                      ByRef bLogin As Boolean,
                                      ByRef bLanguage As Boolean,
                                      ByRef bPartner As Boolean,
                                      ByRef bBroker As Boolean,
                                      ByRef bImage As Boolean,
                                      ByRef bCommission As Boolean)

        ' Init SQL
        Dim szSQL As String =
            "select * from contact_type_options where contact_type_id = " & nContactTypeID.ToString.Trim

        ' Get Results
        Dim dtOptions As DataTable = GetDataAsDataTable(szSQL)

        ' If we got Results
        If dtOptions.Rows.Count > 0 Then

            ' Set Return Parameters
            bRegNo = Convert.ToBoolean(dtOptions.Rows(0).Item("Registration_No"))
            bAddress = Convert.ToBoolean(dtOptions.Rows(0).Item("Address"))
            bTelephone = Convert.ToBoolean(dtOptions.Rows(0).Item("Telephone"))
            bMobile = Convert.ToBoolean(dtOptions.Rows(0).Item("Mobile"))
            bFax = Convert.ToBoolean(dtOptions.Rows(0).Item("Fax"))
            bEmail = Convert.ToBoolean(dtOptions.Rows(0).Item("Email"))
            bNotes = Convert.ToBoolean(dtOptions.Rows(0).Item("Notes"))
            bLogin = Convert.ToBoolean(dtOptions.Rows(0).Item("Login"))
            bLanguage = Convert.ToBoolean(dtOptions.Rows(0).Item("Language"))
            bPartner = Convert.ToBoolean(dtOptions.Rows(0).Item("Partner"))
            bBroker = Convert.ToBoolean(dtOptions.Rows(0).Item("Broker"))
            bImage = Convert.ToBoolean(dtOptions.Rows(0).Item("Image"))
            bCommission = Convert.ToBoolean(dtOptions.Rows(0).Item("Commission"))

        End If

        ' Tidy
        dtOptions.Dispose()

    End Sub

    Public Sub SaveContactTypeOptions(ByVal nContactTypeID As Integer,
                                      ByVal bRegNo As Boolean,
                                      ByVal bAddress As Boolean,
                                      ByVal bTelephone As Boolean,
                                      ByVal bMobile As Boolean,
                                      ByVal bFax As Boolean,
                                      ByVal bEmail As Boolean,
                                      ByVal bNotes As Boolean,
                                      ByVal bLogin As Boolean,
                                      ByVal bLanguage As Boolean,
                                      ByVal bPartner As Boolean,
                                      ByVal bBroker As Boolean,
                                      ByVal bImage As Boolean,
                                      ByVal bCommission As Boolean)


        ' Init SQL
        Dim szSQL As String =
            "insert into CONTACT_TYPE_OPTIONS (Contact_Type_ID, Registration_No, Address, Telephone, Mobile, Fax, Email, Notes, Login, Language, Partner, Broker, Image, Commission) VALUES (" &
                nContactTypeID.ToString.Trim & ", " &
                SQLBoolean(bRegNo) & ", " &
                SQLBoolean(bAddress) & ", " &
                SQLBoolean(bTelephone) & ", " &
                SQLBoolean(bMobile) & ", " &
                SQLBoolean(bFax) & ", " &
                SQLBoolean(bEmail) & ", " &
                SQLBoolean(bNotes) & ", " &
                SQLBoolean(bLogin) & ", " &
                SQLBoolean(bLanguage) & ", " &
                SQLBoolean(bPartner) & ", " &
                SQLBoolean(bBroker) & ", " &
                SQLBoolean(bImage) & ", " &
                SQLBoolean(bCommission) & ")"

        ' Run Update
        Execute(szSQL)

    End Sub

    Public Sub AddHistoryType(ByVal szText As String)

        ' Local Vars
        Dim nDictionaryID As Integer = GetDictionaryID(1, szText.Trim)

        ' Add this to the History Types
        Dim szSQL As String =
            "insert into property_history_type (dictionary_id, archived) values (" & nDictionaryID.ToString.Trim & ", 0)"

        ' Run Update
        Execute(szSQL)

    End Sub

    Public Sub UpdateHistoryType(ByVal nTypeID As Integer, ByVal szText As String, ByVal bArchived As Boolean)

        ' Local Vars
        Dim nDictionaryID As Integer = GetDictionaryID(1, szText.Trim)

        ' Update this Type
        Dim szSQL As String =
            "update property_history_type " &
                "set dictionary_id = " & nDictionaryID.ToString.Trim & ", " &
                "archived = " & SQLBoolean(bArchived) & " " &
            "where history_type_id = " & nTypeID.ToString.Trim

        ' Run Update
        Execute(szSQL)

    End Sub

    Public Function Tables() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "SELECT table_name FROM information_schema.tables order by table_name"

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

#End Region

#Region "Reports"

    Public Function ClientTourRequiringFeedback(ByVal szSortBy As String, ByVal bAscending As Boolean) As ArrayList

        ' Local Vars
        Dim alRetVal As New ArrayList
        Dim htClientTours As New Hashtable

        ' Init SQL
        Dim szSQL As String =
            "select ct.tour_with_id, ct.tour_id 'Tour ID', ctp.tour_datetime 'Tour Date', c.Contact_Name 'Toured By', ltrim(rtrim(rtrim(b.Buyer_Forename) + ' ' + ltrim(b.Buyer_Surname))) 'Buyer', p.Property_Ref 'IA Reference',  isnull( ppr.Reference ,'')  'External Reference' " &
            "from CLIENT_TOUR_PROPERTIES ctp " &
                "left join CLIENT_TOUR_FEEDBACK ctf on ctp.tour_id = ctf.Tour_ID and ctp.tour_property_id = ctf.Property_ID " &
                "inner join CLIENT_TOUR ct on ctp.tour_id = ct.tour_id " &
                "inner join PROPERTY p on ctp.tour_property_id = p.Property_ID " &
                "inner join CONTACT c on ct.tour_with_id = c.Contact_ID " &
                "inner join BUYER b on ct.tour_buyer_id = b.Buyer_ID " &
                "left join PROPERTY_PARTNER_REF ppr on p.Property_ID = ppr.Property_ID " &
            "where(ctf.Tour_ID Is null And ctp.tour_datetime <= GETDATE()) " &
            "order by "

        ' Depending on Sort
        Select Case szSortBy

            Case "Date"
                szSQL &= "ctp.tour_datetime"

            Case "Tourer"
                szSQL &= "c.Contact_Name"
            Case "Buyer"
                szSQL &= "ltrim(rtrim(rtrim(b.Buyer_Forename) + ' ' + ltrim(b.Buyer_Surname)))"

            Case Else
                szSQL &= "ct.tour_id"

        End Select

        ' If Descending
        If Not bAscending Then
            szSQL &= " desc"
        End If

        ' Sub Sort Property Reference
        szSQL &= ", p.Property_Ref"

        ' Get the Results
        Dim dtDataTable As DataTable = GetDataAsDataTable(szSQL)

        ' For each Row Returned
        For Each dr As DataRow In dtDataTable.Rows

            ' Do we have this Tour ID?
            If Not htClientTours.ContainsKey(Convert.ToInt32(dr("Tour ID"))) Then

                ' Add this to the Table
                Dim CClientTour As New ClassClientTour

                ' Assign the Header Items
                CClientTour.TourID = Convert.ToInt32(dr("Tour ID"))
                CClientTour.ViewingDate = Convert.ToDateTime(dr("Tour Date")).Date
                CClientTour.TourWith = dr("Toured By")
                CClientTour.TourWithID = Convert.ToInt32(dr("tour_with_id"))
                CClientTour.Buyer = dr("Buyer")

                ' Add this to the Array
                htClientTours.Add(CClientTour.TourID, CClientTour)

            End If

            ' Create a New Client Tour Property
            Dim CClientTourProperty As New ClassClientTourProperty

            ' Init Vars
            CClientTourProperty.PropertyReference = dr("IA Reference")
            CClientTourProperty.ExternalReference = dr("External Reference")

            ' Add this Property
            DirectCast(htClientTours.Item(Convert.ToInt32(dr("Tour ID"))), ClassClientTour).TourProperty.Add(CClientTourProperty)

        Next

        ' Resorting the Results

        ' For each Row Returned
        For Each dr As DataRow In dtDataTable.Rows

            ' If this Exists
            If htClientTours.Contains(Convert.ToInt32(dr("Tour ID"))) Then

                ' Add this Tour to the Array
                alRetVal.Add(htClientTours(Convert.ToInt32(dr("Tour ID"))))

                ' Remove
                htClientTours.Remove(Convert.ToInt32(dr("Tour ID")))

            End If

        Next

        ' Tidy
        dtDataTable.Dispose()
        htClientTours.Clear()
        htClientTours = Nothing

        ' Return the Result
        Return alRetVal

    End Function

#End Region

#Region "Duplication"

    Public Function DuplicateBuyers(ByVal szFirstName As String,
                                    ByVal szLastName As String,
                                    ByVal szTelephone As String,
                                    ByVal szEmail As String
                                   ) As DataTable

        ' Init Return Variable
        Dim dtRetVal As New DataTable

        ' Check we have Something
        If szFirstName.Trim <> String.Empty Or
            szLastName.Trim <> String.Empty Or
            szTelephone.Trim <> String.Empty Or
            szEmail.Trim <> String.Empty Then

            ' Local Vars
            Dim szSQL As String
            Dim szDelim As String = String.Empty

            ' We have Something

            ' Init SQL
            szSQL =
                "select * " &
                "from " &
                "( "

            ' If we have a Forename or Surname
            If szFirstName.Trim <> String.Empty And
                szLastName.Trim <> String.Empty Then

                ' Add this to Search
                szSQL &= szDelim &
                        "select Buyer_ID id, ltrim(rtrim(rtrim(Buyer_Forename) + ' ' + ltrim(Buyer_Surname))) Name, Buyer_Telephone Telephone, Buyer_Email Email " &
                        "from buyer " &
                        "where " &
                            "replace(ltrim(rtrim(lower(Buyer_Forename))), ' ', '') like '%" & szFirstName.Trim.ToLower.Replace(" ", "") & "%' and " &
                            "replace(ltrim(rtrim(lower(Buyer_Surname))), ' ', '') like '%" & szLastName.Trim.ToLower.Replace(" ", "") & "%' and " &
                            "replace(ltrim(rtrim(lower(Buyer_Email))), ' ', '') like '%" & szEmail.Trim.ToLower.Replace(" ", "") & "%' "

                ' Update Delimiter
                szDelim = "union "

            End If

            ' If we have a Telephone Number
            If szTelephone.Trim <> String.Empty Then

                ' Add this to Search
                szSQL &= szDelim &
                        "select Buyer_ID id, ltrim(rtrim(rtrim(Buyer_Forename) + ' ' + ltrim(Buyer_Surname))) Name, Buyer_Telephone Telephone, Buyer_Email Email " &
                        "from buyer " &
                        "where " &
                            "replace(ltrim(rtrim(lower(Buyer_Telephone))), ' ', '') like '%" & szTelephone.Trim.ToLower.Replace(" ", "") & "%' "

                ' Update Delimiter
                szDelim = "union "

            End If

            ' If we have an Email Address
            If szEmail.Trim <> String.Empty Then

                ' Add this to Search
                szSQL &= szDelim &
                        "select Buyer_ID id, ltrim(rtrim(rtrim(Buyer_Forename) + ' ' + ltrim(Buyer_Surname))) Name, Buyer_Telephone Telephone, Buyer_Email Email " &
                        "from buyer " &
                        "where " &
                            "replace(ltrim(rtrim(lower(Buyer_Email))), ' ', '') like '%" & szEmail.Trim.ToLower.Replace(" ", "") & "%' "

                ' Update Delimiter
                szDelim = "union "

            End If

            ' Add Closing Statement
            szSQL &=
                ") t1 " &
                "order by t1.Name;"

            ' Return the Result
            dtRetVal = GetDataAsDataTable(szSQL)

        End If

        ' Return the Result
        Return dtRetVal

    End Function

#End Region

#Region "Navigation"

    Public Function Navigation() As DataTable

        ' Init SQL
        Dim szSQL As String =
            "select * " &
            "from Navigation " &
            "order by parent_id, sort_order "

        ' Return the Result
        Return GetDataAsDataTable(szSQL)

    End Function

#End Region

End Class