Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares
Imports System.IO
Imports System.Net
Imports System.Drawing

Partial Class AdminNew_Utility
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("ContactID") Is Nothing Then
        '    '  Redirect to Login
        '    Response.Redirect("~/AgentLogin.aspx")
        'End If
    End Sub
    Protected Sub btnSwap_Click(sender As Object, e As EventArgs)
        If txtPropertyReferenceFrom.Text <> "" And txtPropertyReferenceTo.Text <> "" Then
            Dim OldPropertyReference As String
            Dim NewPropertyReference As String
            OldPropertyReference = txtPropertyReferenceFrom.Text
            NewPropertyReference = txtPropertyReferenceTo.Text

            'First of all delete folder of images which linked to old property reference
            Dim oldImages As New IO.DirectoryInfo(Server.MapPath("../Images/Photos/Properties/") & OldPropertyReference)
            If oldImages.Exists Then
                oldImages.Delete(True)
            End If

            Try
                'Here delete folder/files of all documents related/linked to old property reference
                Dim oldDocuments As New IO.DirectoryInfo(Server.MapPath("../App_Data/Documents/Properties/") & NewPropertyReference)
                If oldDocuments.Exists Then
                    oldDocuments.Delete(True)
                    'Now rename old folder from old property reference to new property reference
                    Directory.Move(Server.MapPath("../App_Data/Documents/Properties/") & OldPropertyReference, Server.MapPath("../App_Data/Documents/Properties/") & NewPropertyReference)
                End If
            Catch ex As Exception
                Dim str = ex.InnerException.ToString()
            End Try


            'Here i am calling procedure to update all linked/related table to replace old property reference to new property reference
            Dim sql As SqlParameter() = New SqlParameter(2) {}
            sql(0) = New SqlParameter("@OldPropertyReference", OldPropertyReference)
            sql(1) = New SqlParameter("@NewPropertyReference", NewPropertyReference)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Utility_Swap_Property_Reference", sql)

            'Here i am calling procedure to delete records linked/related to old property reference
            Dim sqlremove As SqlParameter() = New SqlParameter(1) {}
            sqlremove(0) = New SqlParameter("@OldPropertyReference", OldPropertyReference)
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Delete_OldPropertyReference", sqlremove)

        End If
    End Sub
    Protected Sub btnDoRename_Click(sender As Object, e As EventArgs)
        Dim PropertyReferenceToRename As String = txtPropertyReferenceToRename.Text
        Dim filePaths As String() = Directory.GetFiles(Server.MapPath("../App_Data/Documents/Properties/") & PropertyReferenceToRename, "*", SearchOption.AllDirectories)

        For index As Integer = 0 To filePaths.Length - 1
            Dim filepath As String = filePaths(index)
            Dim lastindexofslash As Int16 = filepath.LastIndexOf("\")
            Dim oldfilename As String = filepath.Substring(lastindexofslash + 1, filepath.Length - 1 - lastindexofslash)

            Dim currentFilePath As String = filepath.Substring(0, filepath.LastIndexOf("\"))
            currentFilePath = currentFilePath & "/"

            Dim oldpropertyref As String = oldfilename.Substring(0, oldfilename.IndexOf("_"))
            Dim newfilename = oldfilename.Replace(oldpropertyref, txtPropertyReferenceToRename.Text)
            Dim movefirstparam As String = filepath
            Dim movesecondparam As String = currentFilePath & newfilename
            Directory.Move(movefirstparam, movesecondparam)

        Next
    End Sub
    Protected Sub btnRemoveProperty_Click(sender As Object, e As EventArgs)

        'Here i am calling procedure to delete records linked/related to property reference
        Dim sqlremove As SqlParameter() = New SqlParameter(1) {}
        sqlremove(0) = New SqlParameter("@PropertyReference", txtPropReference.Text)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Delete_OldPropertyReference", sqlremove)

    End Sub
    Protected Sub btnGenerate_Click(sender As Object, e As EventArgs)
        'Here i am calling procedure to get all buyer records where we have buyer notes available & property reference also available
        Dim dtBuyers As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Get_PropertyRefs").Tables(0)
        For Each dr As DataRow In dtBuyers.Rows
            Dim propertyreferences As String = ""
            Dim propertyreference As String = ""
            Dim BuyerNotes = dr("Buyer_Notes").ToString().ToLower()
            Dim propertytypes As String = "AP,BA,CH,CM,CJ,DP,FI,PJ,PL,TH,VL"
            For i = 0 To propertytypes.Split(",").Length - 1
                BuyerNotes = dr("Buyer_Notes").ToString().ToLower()
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
            sql(0) = New SqlParameter("@Buyer_Id", Convert.ToInt16(dr("Buyer_Id").ToString()))
            sql(1) = New SqlParameter("@PropertyRef", propertyreferences.ToUpper().Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", ""))
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Update_PropertyRefs", sql)
        Next
    End Sub
    Protected Sub bnInsertPropertyHistory_Click(sender As Object, e As EventArgs)
        Dim dtBuyers As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Buyer_Get_PropertyRefs_for_propertyhistory").Tables(0)
        For Each dr As DataRow In dtBuyers.Rows
            Dim totalreferences() As String = dr("propertyref").ToString().Split(" ")
            For i = 0 To totalreferences.Count - 1
                If totalreferences(i) <> "" Then
                    Dim sql As SqlParameter() = New SqlParameter(5) {}
                    sql(0) = New SqlParameter("@Property_Ref", totalreferences(i).ToString())
                    sql(1) = New SqlParameter("@Type_Id", 14)
                    Dim Buyer_Surname As String = dr("Buyer_Surname").ToString()
                    Dim Buyer_Forename As String = dr("Buyer_Forename").ToString()
                    'Dim datereceived As String = DateTime.Now.ToString()
                    Dim datereceived As String = "11/11/2019 12:05:12 PM"
                    'Dim historytext = "Enquiry received for the property ref  " & totalreferences(i).ToString() & " from client " & Buyer_Surname & " " & Buyer_Forename & " – on the " & datereceived & ""
                    Dim historytext = "Enquiry received for the property ref  " & totalreferences(i).ToString() & " from client " & Buyer_Surname & " " & Buyer_Forename & " – on – Update on missing enqruiries received. Done on the 25-03-2021 "
                    sql(2) = New SqlParameter("@History_Text", historytext)
                    sql(3) = New SqlParameter("@Modified_By", 0)
                    sql(4) = New SqlParameter("@Buyer_Id", Convert.ToInt16(dr("Buyer_Id").ToString()))
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Insert", sql)
                End If
            Next
        Next
    End Sub
    Protected Sub btnGenerateLatLong_Click(sender As Object, e As EventArgs)
        'Dim dtPostcodes As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_GetPostCodeAddress_ToGenerate_LatLong_02").Tables(0)
        Dim dtPostcodes As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_GetPostCodeAddress_ToGenerate_LatLong_NEWURL").Tables(0)
        For Each dr As DataRow In dtPostcodes.Rows
            Dim address As String = dr("Address")
            Dim postCode As String = dr("Postcode_ID")
            Dim Region As String = dr("Region")

            'Check if current postcode already been updated lat/long information then skip other same ones
            'Dim sqlCheckPostcode As SqlParameter() = New SqlParameter(1) {}
            'sqlCheckPostcode(0) = New SqlParameter("@PostCode", postCode)
            'Dim dtcheckpostcode As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_GPSLatLng_Check_By_Postcode", sqlCheckPostcode).Tables(0)
            'If dtcheckpostcode.Rows.Count = 0 Then
            'Dim googleAPIUrl As String = "https://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&key=AIzaSyC_hgbtY2WK_O8_hpm_uzl_9Pfa3F3ZOx4"
            Dim googleAPIUrl As String = "https://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&key=AIzaSyCwJpxFElMKO5iffzrYp1EH9ohb5lvyogU"
            Dim request As WebRequest = WebRequest.Create(googleAPIUrl)
            Dim response As WebResponse = request.GetResponse()
            Dim dataStream As Stream = response.GetResponseStream
            Dim reader As StreamReader = New StreamReader(dataStream)
            Dim dsResult As New DataSet
            dsResult.ReadXml(reader)
            Try
                'If dsResult.Tables("status").Rows(0)(0).ToString() = "ZERO_RESULTS" Then
                '    Update_LatLong_By_Postcode(postCode, Convert.ToDecimal("0"), Convert.ToDecimal("0"))
                'End If
                If dsResult.Tables("result") Is Nothing Then
                    Update_LatLong_By_Postcode(postCode, Convert.ToDecimal("0"), Convert.ToDecimal("0"))
                End If
                For Each drInner As DataRow In dsResult.Tables("result").Rows
                    'lblAddressComponent.Text = dsResult.Tables("address_component").Rows(1)("long_name").ToString()
                    lblAddressComponent.Text = dsResult.Tables("result").Rows(0)("formatted_address").ToString()
                    'lblAddressComponent.Text.Replace("Málaga", "Malaga")
                    'lblAddressComponent.Text.Replace("Jaén", "Jaen")
                    'lblAddressComponent.Text.Replace("Córdoba", "Cordoba")
                    'lblAddressComponent.Text.Replace("Cádiz", "Cadiz")
                    'lblAddressComponent.Text.Replace("Almería", "Almeria")
                    If Not lblAddressComponent.Text.Contains(Region) Then
                        Update_LatLong_By_Postcode(postCode, Convert.ToDecimal("1"), Convert.ToDecimal("1"))
                    Else
                        'If dsResult.Tables("result").Rows.Count > 1 Then
                        'Dim drInner As DataRow = dsResult.Tables("result").Rows(0)
                        Dim geometry_id As String = dsResult.Tables("geometry").Select("result_id = " & drInner("result_id").ToString())(0)("geometry_id").ToString()
                        Dim location As DataRow = dsResult.Tables("location").Select("geometry_id = " + geometry_id)(0)
                        'Update_LatLong_By_Postcode_thirdcolumn(postCode, Convert.ToDecimal(location("lat")), Convert.ToDecimal(location("lng")))
                        Update_LatLong_By_Postcode(postCode, Convert.ToDecimal(location("lat")), Convert.ToDecimal(location("lng")))
                        'End If
                    End If
                Next
                'End If
            Catch ex As Exception
                Dim strex As String = ex.Message.ToString()
            End Try
        Next
    End Sub
    Public Sub Update_LatLong_By_Postcode(ByVal postcode As String, ByVal GPS_Latitude As Decimal, ByVal GPS_Longitude As Decimal)
        Dim sql As SqlParameter() = New SqlParameter(3) {}
        sql(0) = New SqlParameter("@Postcode_Id", postcode)
        sql(1) = New SqlParameter("@GPS_Latitude", GPS_Latitude)
        sql(2) = New SqlParameter("@GPS_Longitude", GPS_Longitude)
        'SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_PostCode_Update_LatLong", sql)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_PostCode_Update_LatLong_03", sql)
    End Sub
    Public Sub Update_LatLong_By_Postcode_thirdcolumn(ByVal postcode As String, ByVal GPS_Latitude As Decimal, ByVal GPS_Longitude As Decimal)
        Dim sql As SqlParameter() = New SqlParameter(3) {}
        sql(0) = New SqlParameter("@Postcode_Id", postcode)
        sql(1) = New SqlParameter("@GPS_Latitude", GPS_Latitude)
        sql(2) = New SqlParameter("@GPS_Longitude", GPS_Longitude)
        'SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_PostCode_Update_LatLong", sql)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_PostCode_Update_LatLong_03", sql)
    End Sub
    Protected Sub btnWatermarkPosition_Click(sender As Object, e As EventArgs)
        'First of all get all properties listing including num_photos from database'
        Dim dtProperties As DataTable
        'dtProperties = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, "select Property_Ref,Num_Photos from property where status_id not in(2,7) and Num_Photos>0").Tables(0)
        dtProperties = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.Text, "select Property_Ref,Num_Photos from property where property_ref='th3686'").Tables(0)
        If dtProperties.Rows.Count > 0 Then
            For index As Integer = 0 To dtProperties.Rows.Count - 1
                Dim propertyRef As String = dtProperties.Rows(index)("Property_Ref")
                Dim NumOfPhotos As Int32 = Convert.ToInt32(dtProperties.Rows(index)("Num_Photos"))
                For photoIndex As Integer = 1 To NumOfPhotos
                    Dim imgPath = "~/Images/Photos/Properties/" & propertyRef & "/" & propertyRef & "_" & photoIndex.ToString() & ".jpg"
                    Dim imgPathNew = "~/Images/Photos/Properties/" & propertyRef & "/" & propertyRef & "_C" & photoIndex.ToString() & ".jpg"
                    Dim imgImage As Image = Image.FromFile(HttpContext.Current.Server.MapPath(imgPath))

                    ApplyIAWatermarkCenter(imgImage)
                    imgImage.Save(HttpContext.Current.Server.MapPath(imgPathNew))
                    imgImage.Dispose()
                    File.Delete(HttpContext.Current.Server.MapPath(imgPath))
                    File.Copy(HttpContext.Current.Server.MapPath(imgPathNew), HttpContext.Current.Server.MapPath(imgPath))
                    File.Delete(HttpContext.Current.Server.MapPath(imgPathNew))
                    'Rename again new file which we have created
                Next
            Next
        End If
    End Sub
    Public Sub ApplyIAWatermarkCenter(ByRef imgImage As Image)

        ' Load the IA Watermark
        Dim imgWatermark As Image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/IA.png"))

        ' Apply
        AddWatermarkCenter(imgImage, imgWatermark)

        ' Tidy
        imgWatermark.Dispose()

    End Sub
    Private Sub AddWatermarkCenter(ByRef imgMain As Image, ByVal imgWatermark As Image, Optional ByVal bTopRight As Boolean = True)
        Try
            ' Load into Graphics Object
            Using g As Graphics = Graphics.FromImage(imgMain)

                If bTopRight Then
                    Dim x As Integer = (imgMain.Width - imgWatermark.Width) / 2
                    Dim y As Integer = (imgMain.Height - imgWatermark.Height) / 2
                    'g.DrawImage(imgWatermark, New Point(imgMain.Width - imgWatermark.Width - 14, 5))
                    g.DrawImage(imgWatermark, New Point(x, y))

                Else

                    g.DrawImage(imgWatermark, New Point(0, 0))

                End If

            End Using
        Catch ex As Exception

        End Try


    End Sub
End Class
