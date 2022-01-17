Imports Microsoft.VisualBasic
Imports System.Net
Imports System.IO
Imports System.Data
Imports System.IO.Compression
Imports Ionic.Zip
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports HashSoftwares

Public Class ClassUtilities
    Inherits System.Web.UI.Page
    Public Function FormatPrice(ByVal nPrice As Integer) As String

        ' Local Vars
        Dim szScratch As String
        Dim szRetVal As String = String.Empty
        Dim szDelim As String = String.Empty

        ' Init Scratch Value
        szScratch = nPrice.ToString.Trim

        ' While the Length of szScratch is greater than 3
        While szScratch.Length > 3

            ' Add the Last 3 Chars of szScratch to the Return Value and add Delimiter
            szRetVal = szScratch.Substring(szScratch.Length - 3, 3) & szDelim & szRetVal

            ' Reduce szScratch
            szScratch = szScratch.Substring(0, szScratch.Length - 3)

            ' Set the Delimiter
            szDelim = "."

        End While

        ' Add Remaining Values
        szRetVal = szScratch & szDelim & szRetVal

        ' Return the Result
        Return szRetVal & " €"

    End Function

    Public Function GetLanguageID(ByVal szLanguage As String) As Integer

        ' If Null, return English
        If szLanguage Is Nothing Then
            Return 1
        End If

        ' Depending on the Language
        Select Case szLanguage.Trim.ToLower

            Case "spanish"
                Return 2

            Case "french"
                Return 3

            Case "german"

                Return 5
            Case "dutch"
                Return 4

            Case Else
                Return 1

        End Select

    End Function

    Public Function Translate(ByVal szText As String, ByVal szLanguage As String) As String

        ' Get the Language ID
        Dim nLanguageID As Integer = GetLanguageID(szLanguage)

        ' If not English
        If nLanguageID > 1 Then

            ' Return the Translation
            Return Translate(szText, nLanguageID)

        Else

            ' Return the Original Text
            Return szText.Trim

        End If

    End Function


    Public Function TranslateNew(ByVal szText As String, ByVal nTargetLanguageID As Integer, Optional ByVal nSourceLanguageID As Integer = 0) As String

        ' Define Return Value
        Dim szRetVal As String = String.Empty

        ' Only Translate if not English
        If nTargetLanguageID > 0 Then

            ' Init URL
            Dim szURL As String = "https://www.googleapis.com/language/translate/v2?key=AIzaSyDu0ha4rMNQLXbvMNpBBWqcosfFJicR0D4&q=" & Server.UrlEncode(szText.Trim) & "&source="

            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@langId", nSourceLanguageID)
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "usp_getlangcode_byid", sql).Tables(0)
            If dt.Rows.Count > 0 Then
                szURL &= dt.Rows(0)("Language_Short_Code").ToString()
            Else
                szURL &= "en"
            End If
            '' Depending on the Language
            'Select Case nSourceLanguageID

            '    Case 2
            '        szURL &= "es"

            '    Case 3
            '        szURL &= "fr"

            '    Case 4
            '        szURL &= "de"

            '    Case 5
            '        szURL &= "nl"

            '    Case Else
            '        szURL &= "en"

            'End Select

            ' Continue to Init URL
            szURL &= "&target="

            ' Depending on the Language

            Dim sqlT As SqlParameter() = New SqlParameter(1) {}
            sqlT(0) = New SqlParameter("@langId", nTargetLanguageID)
            Dim dtT As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "usp_getlangcode_byid", sqlT).Tables(0)
            If dtT.Rows.Count > 0 Then
                szURL &= dtT.Rows(0)("Language_Short_Code").ToString()
            Else
                szURL &= "en"
            End If
            'Select Case nTargetLanguageID

            '    Case 2
            '        szURL &= "es"

            '    Case 3
            '        szURL &= "fr"

            '    Case 4
            '        szURL &= "de"

            '    Case 5
            '        szURL &= "nl"

            '    Case Else
            '        szURL &= "en"

            'End Select

            ' Use Google API for Translation
            Dim request As WebRequest = WebRequest.Create(szURL)
            request.Method = "GET"
            request.ContentType = "application/x-www-form-urlencoded"
            Dim response As WebResponse = request.GetResponse
            Dim dataStream As Stream = response.GetResponseStream
            Dim reader As StreamReader = New StreamReader(dataStream)

            ' Read Result
            szRetVal = reader.ReadToEnd

            ' Tidy
            reader.Close()
            dataStream.Close()
            response.Close()

            ' Set Return Result
            ' szRetVal = szRetVal.Substring(61, szRetVal.Length - 77)

            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(szRetVal)
            Dim Translated = jsonResult.Item("data")("translations").Item(0)


            For Each item As JProperty In Translated
                item.CreateReader()
                Select Case item.Name
                    Case "translatedText"
                        szRetVal = item.Value
                End Select
            Next
        Else

            ' Return the Original String
            szRetVal = szText

        End If

        ' Return the Result
        Return szRetVal.Trim

    End Function

    Public Function Translate(ByVal szText As String, ByVal nTargetLanguageID As Integer, Optional ByVal nSourceLanguageID As Integer = 0) As String

        ' Define Return Value
        Dim szRetVal As String = String.Empty

        ' Only Translate if not English
        If nTargetLanguageID > 0 Then

            ' Init URL
            Dim szURL As String = "https://www.googleapis.com/language/translate/v2?key=AIzaSyDu0ha4rMNQLXbvMNpBBWqcosfFJicR0D4&q=" & Server.UrlEncode(szText.Trim) & "&source="

            ' Depending on the Language
            Select Case nSourceLanguageID

                Case 2
                    szURL &= "es"

                Case 3
                    szURL &= "fr"

                Case 4
                    szURL &= "de"

                Case 5
                    szURL &= "nl"

                Case Else
                    szURL &= "en"

            End Select

            ' Continue to Init URL
            szURL &= "&target="

            ' Depending on the Language
            Select Case nTargetLanguageID

                Case 2
                    szURL &= "es"

                Case 3
                    szURL &= "fr"

                Case 4
                    szURL &= "de"

                Case 5
                    szURL &= "nl"

                Case Else
                    szURL &= "en"

            End Select

            ' Use Google API for Translation
            Dim request As WebRequest = WebRequest.Create(szURL)
            request.Method = "GET"
            request.ContentType = "application/x-www-form-urlencoded"
            Dim response As WebResponse = request.GetResponse
            Dim dataStream As Stream = response.GetResponseStream
            Dim reader As StreamReader = New StreamReader(dataStream)

            ' Read Result
            szRetVal = reader.ReadToEnd

            ' Tidy
            reader.Close()
            dataStream.Close()
            response.Close()

            ' Set Return Result
            ' szRetVal = szRetVal.Substring(61, szRetVal.Length - 77)

            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(szRetVal)
            Dim Translated = jsonResult.Item("data")("translations").Item(0)


            For Each item As JProperty In Translated
                item.CreateReader()
                Select Case item.Name
                    Case "translatedText"
                        szRetVal = item.Value
                End Select
            Next
        Else

            ' Return the Original String
            szRetVal = szText

        End If

        ' Return the Result
        Return szRetVal.Trim

    End Function

    Public Function GetIPAddress() As String

        ' Get the User's IP
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim szIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(szIPAddress) Then
            szIPAddress = context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = szIPAddress.Split(
                New [Char]() {","c})
            szIPAddress = ipArray(0)
        End If

        ' Return the Result
        Return szIPAddress.Trim

    End Function

    Public Function GetLocation() As String

        ' Local Vars
        Dim szLocation As String = String.Empty

        ' Get the IP Numbers
        Dim szIP() As String = GetIPAddress.Split(".")

        ' Calculating IP Number
        Dim nIPNumber As Integer = 16777216 * Convert.ToInt32(szIP(0)) + 65536 * Convert.ToInt32(szIP(1)) + 256 * Convert.ToInt32(szIP(2)) + Convert.ToInt32(szIP(3))

        ' Get the Location from the Database
        Dim CDataAccess As New ClassDataAccess
        szLocation = CDataAccess.GetDataAsString("select country from ip_origin where ip_from <= " & nIPNumber.ToString.Trim & " and ip_to >= " & nIPNumber.ToString.Trim)
        CDataAccess = Nothing

        ' Return the Result
        Return szLocation

    End Function

#Region "Back Office"

    Public Sub PopulateDropDownList(ByRef ddl As DropDownList, ByRef dtDataTable As DataTable, Optional ByVal bSort As Boolean = False)

        ' Clear Existing List
        ddl.Items.Clear()

        ' If the Table has Rows
        If dtDataTable.Rows.Count > 0 Then

            ' If Sorting
            If bSort Then

                ' Apply Sorting
                Dim dvSort As DataView = New DataView(dtDataTable)
                dvSort.Sort = "text"

                ' Set Source
                ddl.DataSource = dvSort

            Else

                ' No Sorting
                ddl.DataSource = dtDataTable

            End If

            ' Populate Drop Down List with Data from Data Table
            'ddl.DataTextField = "text"
            'ddl.DataValueField = "id"
            'ddl.DataBind()

            Try


                ddl.DataTextField = "text"
                ddl.DataValueField = "id"
                ddl.DataBind()
            Catch ex As Exception

            End Try

        End If

    End Sub

    'Private Sub EnableControl(ByRef ctrl As Control, ByVal bEnabled As Boolean)

    '    ' Depending on the Control Type
    '    Select Case ctrl.GetType.Name

    '        Case "Button"
    '            DirectCast(ctrl, Button).Enabled = Not bEnabled

    '        Case "DropDownList"
    '            DirectCast(ctrl, DropDownList).Enabled = Not bEnabled

    '        Case "TextBox"
    '            DirectCast(ctrl, TextBox).Enabled = Not bEnabled

    '        Case "CheckBox"
    '            DirectCast(ctrl, CheckBox).Enabled = Not bEnabled

    '    End Select

    'End Sub

    'Public Sub EnableControls(ByRef colControls As ControlCollection, ByVal bEnabled As Boolean)

    '    ' For each Control
    '    For Each ctrl As Control In colControls

    '        ' If this Control contains Controls
    '        If ctrl.Controls.Count > 0 Then

    '            ' For each Control within
    '            For Each ctrlSub In ctrl.Controls

    '                ' If this Control contains Controls
    '                If ctrlSub.Controls.Count > 0 Then

    '                    ' For each Control within
    '                    For Each ctrlSubSub In ctrlSub.Controls

    '                        ' If this Control contains Controls
    '                        If ctrlSubSub.Controls.Count > 0 Then

    '                            ' For each Control within
    '                            For Each ctrlSubSubSub In ctrlSubSub.Controls

    '                                ' Enable / Disable
    '                                EnableControl(ctrlSubSubSub, bEnabled)

    '                            Next

    '                        End If

    '                    Next

    '                End If

    '            Next

    '        End If

    '    Next

    'End Sub

    Private Sub ExportToCSV(ByVal szTargetDirectory As String, ByVal szTableName As String)

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable

        ' Get the Contents of this Table
        'dtDataTable = CDataAccess.GetDataAsDataTable("select * from " & szTableName.Trim.Trim)
        If szTableName = "PROPERTY" Then
            dtDataTable = CDataAccess.GetDataAsDataTable("select Property_ID,Country_ID,Property_Ref,CONVERT (varchar, Create_Date, 120) as [Create_Date],Status_ID,Postcode_ID,Property_Type_ID,GPS_Latitude,GPS_Longitude,Location_ID,Views_ID,Public_Price,Original_Price,Vendor_Price,Vendor_ID,Broker_ID,Partner_ID,Bedrooms,Bathrooms,SQM_Plot,SQM_Built,Property_Address,Video_URL,Property_Notes,Annual_IBI,Annual_Rubbish,Community_Fees,Year_Constructed,SQM_Terrace,SQM_En_Suite,Num_Photos,Listed_By_Contact_ID,CONVERT (varchar, Last_Modified, 120) as [Last_Modified],Display,Viewed,Door_Key,Buyer_Lawyer_ID,Vendor_Lawyer_ID,Buyer_ID,IsIssue,Total_Enquiries from " & szTableName.Trim.Trim)
        End If
        If szTableName = "PROPERTY_HISTORY" Then
            dtDataTable = CDataAccess.GetDataAsDataTable("select History_ID,Property_Ref,CONVERT (varchar, Create_Date, 120) as [Create_Date],Type_ID,History_Text,Modified_By,CONVERT (varchar, Last_Modified, 120) as [Last_Modified],Archived,Buyer_Id,PriceChanged,NewPrice,OldPrice from " & szTableName.Trim.Trim)
        End If
        If szTableName = "BUYER" Then
            dtDataTable = CDataAccess.GetDataAsDataTable("select Buyer_ID,Buyer_Surname,Buyer_Forename,Buyer_Passport,Buyer_Address,Buyer_Contact_Name,Buyer_Contact_1,Buyer_Telephone,Buyer_Email,Buyer_Notes,Buyer_Source_ID,Buyer_Status_ID,CONVERT (varchar, Buyer_Date_Created, 120) AS [Buyer_Date_Created],CONVERT (varchar, Buyer_Date_Modified, 120) AS [Buyer_Date_Modified],Buyer_Agent_ID,Buyer_Partner_ID,Buyer_Salesperson_ID,Lawyer_ID,Nationality_ID,Language_ID,Buyer_Budget,Archived,PropertyRef from " & szTableName.Trim.Trim)
        End If
        If szTableName = "BUYER_HISTORY" Then
            dtDataTable = CDataAccess.GetDataAsDataTable("select History_ID,Buyer_ID,CONVERT (varchar, Create_Date, 120) as [Create_Date],Buyer_Status,History_Text,Modified_By,CONVERT (varchar, Action_Date, 120) as [Action_Date],Archived,Action_Status from " & szTableName.Trim.Trim)
        End If
        If szTableName = "EAA_EMAIL_REDIRECT_HISTORY" Then
            dtDataTable = CDataAccess.GetDataAsDataTable("select id,subject,from_email,property_ref,default_partner_id,language_id,language_abbreviation,salesperson_id,salesperson_status,assistant_id,CONVERT (varchar, sent_date, 120) as [sent_date],CONVERT (varchar, created_at, 120) as [created_at],CONVERT (varchar, updated_at, 120) as [updated_at],buyer_id,source_id,inquiry_type,assistant_contact_id,salesperson_contact_id,property_partner_id from " & szTableName.Trim.Trim)
        End If
        If szTableName = "CLIENT_TOUR" Then
            dtDataTable = CDataAccess.GetDataAsDataTable("select tour_id,CONVERT (varchar, tour_datetime, 120) as [tour_datetime],tour_buyer_id,tour_with_id,VirtualTour from " & szTableName.Trim.Trim)
        End If
        If szTableName = "CLIENT_TOUR_PROPERTIES" Then
            dtDataTable = CDataAccess.GetDataAsDataTable("select tour_id,tour_property_id, CONVERT (varchar, tour_datetime, 120) as[tour_datetime] from " & szTableName.Trim.Trim)
        End If
        If szTableName <> "PROPERTY" And szTableName <> "PROPERTY_HISTORY" And szTableName <> "BUYER" And szTableName <> "BUYER_HISTORY" And szTableName <> "EAA_EMAIL_REDIRECT_HISTORY" And szTableName <> "CLIENT_TOUR" And szTableName <> "CLIENT_TOUR_PROPERTIES" Then
            dtDataTable = CDataAccess.GetDataAsDataTable("select * from " & szTableName.Trim.Trim)
        End If
        ' Tidy
        CDataAccess = Nothing

        ' Init Strings
        Dim szDelim As String = String.Empty
        Dim szScratch As String = String.Empty

        ' Init Writer
        Dim srWriter As StreamWriter = New StreamWriter(szTargetDirectory.Trim & "\" & szTableName.Trim & ".csv", False, Encoding.UTF8)

        ' Export the Column Headers
        For Each drCol As DataColumn In dtDataTable.Columns

            ' Add this Column Header
            szScratch = szScratch & szDelim & Chr(34) & drCol.ToString.Replace(Chr(34), Chr(39)).Trim & Chr(34)

            ' Set Delim
            szDelim = ","

        Next

        ' Write this to the File
        srWriter.WriteLine(szScratch)

        ' Export the Rows
        For Each drRow As DataRow In dtDataTable.Rows

            ' Init Strings
            szDelim = String.Empty
            szScratch = String.Empty

            ' For each Item
            For Each obj As Object In drRow.ItemArray

                ' Add the Data
                szScratch = szScratch & szDelim & Chr(34) & obj.ToString.Replace(Chr(34), Chr(39)).Trim & Chr(34)

                ' Set Delim
                szDelim = ","

            Next

            ' Add the Record
            srWriter.WriteLine(szScratch)

        Next drRow

        ' Close the File
        srWriter.Close()
        srWriter.Dispose()

    End Sub

    Public Sub Export()

        ' Local Vars
        Dim szTargetDirectory As String = AppDomain.CurrentDomain.GetData("DataDirectory") & "\Export\"

        ' Get Directory Info
        Dim dirTarget As DirectoryInfo = New DirectoryInfo(szTargetDirectory)

        ' For each File Within
        For Each file As FileInfo In dirTarget.GetFiles()

            ' Delete the File
            '   System.Threading.Thread.Sleep(1000)
            file.Delete()

        Next

        ' Get the List of Tables
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable = CDataAccess.Tables
        CDataAccess = Nothing

        ' For each Table
        For Each dtRow As DataRow In dtDataTable.Rows
            ' Exclude XML Tables
            If dtRow.Item("table_name").ToString.Trim <> "IA_XML_FEED" And
                dtRow.Item("table_name").ToString.Trim <> "IA_APITS_FEED" And
                dtRow.Item("table_name").ToString.Trim <> "IP_ORIGIN" Then
                ' Export this Table
                ExportToCSV(szTargetDirectory, dtRow.Item("table_name").ToString.Trim)
            End If
        Next

        ' Tidy
        dtDataTable.Dispose()

        ' Define Zip File
        Dim zipFile As New ZipFile(szTargetDirectory & "Export.zip")

        ' Add Files
        zipFile.AddDirectory(szTargetDirectory)

        ' Save
        zipFile.Save()

        ' Tidy
        zipFile.Dispose()

        ' Remove all CSVs
        For Each file As FileInfo In dirTarget.GetFiles()

            ' If the File Extension is CSV
            If file.Extension.Trim.ToLower = ".csv" Then
                '   System.Threading.Thread.Sleep(1000)
                ' Delete the File
                file.Delete()
            End If

        Next

    End Sub
    Public Sub ExportNew()
        ' Local Vars
        Dim szTargetDirectory As String = AppDomain.CurrentDomain.GetData("DataDirectory") & "\ExportNew\"

        ' Get Directory Info
        Dim dirTarget As DirectoryInfo = New DirectoryInfo(szTargetDirectory)

        ' For each File Within
        For Each file As FileInfo In dirTarget.GetFiles()
            ' Delete the File
            '   System.Threading.Thread.Sleep(1000)
            file.Delete()
            'Try


            'Catch

            '    Dim strScript As String
            '    strScript = "alert('Test');"
            '    ClientScript.RegisterStartupScript(Me.GetType(), "EditModalScript", strScript.ToString())
            'End Try


        Next

        ' Get the List of Tables
        Dim CDataAccess As New ClassDataAccess
        Dim dtDataTable As DataTable = CDataAccess.Tables
        CDataAccess = Nothing

        ' For each Table
        For Each dtRow As DataRow In dtDataTable.Rows

            ' Exclude XML Tables
            If dtRow.Item("table_name").ToString.Trim <> "IA_XML_FEED" And
                dtRow.Item("table_name").ToString.Trim <> "IA_APITS_FEED" And
                dtRow.Item("table_name").ToString.Trim <> "IP_ORIGIN" Then

                ' Export this Table
                ExportToCSV(szTargetDirectory, dtRow.Item("table_name").ToString.Trim)

            End If

        Next

        ' Tidy
        dtDataTable.Dispose()

        ' Define Zip File
        Dim zipFile As New ZipFile(szTargetDirectory & "Export.zip")

        ' Add Files
        zipFile.AddDirectory(szTargetDirectory)

        ' Save
        zipFile.Save()

        ' Tidy
        zipFile.Dispose()

        ' Remove all CSVs
        For Each file As FileInfo In dirTarget.GetFiles()

            ' If the File Extension is CSV
            If file.Extension.Trim.ToLower = ".csv" Then
                '   System.Threading.Thread.Sleep(1000)
                ' Delete the File
                file.Delete()
            End If

        Next

    End Sub

#End Region

#Region "Imaging"

    Private Function ImageQuality(ByVal bmpImage As Bitmap, ByVal nQuality As Integer) As Image

        ' Local Vars
        Dim myImageCodecInfo As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
        Dim myEncoder As Encoder = Encoder.Quality
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters = New EncoderParameters(1)

        ' Init Encoder
        myEncoderParameter = New EncoderParameter(myEncoder, nQuality)
        myEncoderParameters.Param(0) = myEncoderParameter

        ' Save the Image to a Memory Stream
        Dim msImage As New MemoryStream
        bmpImage.Save(msImage, myImageCodecInfo, myEncoderParameters)

        ' Tidy
        myEncoderParameter.Dispose()
        myEncoderParameters.Dispose()

        ' Assign to return Variable
        Return Image.FromStream(msImage)

        '' Local Vars
        'Dim myImageCodecInfo As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
        'Dim myEncoder As Encoder = Encoder.Quality
        'Dim myEncoderParameter As EncoderParameter
        'Dim myEncoderParameters As EncoderParameters = New EncoderParameters(1)

        '' Init Encoder
        'myEncoderParameter = New EncoderParameter(myEncoder, nQuality)
        'myEncoderParameters.Param(0) = myEncoderParameter

        '' Save the Image to a Memory Stream
        'Dim msImage As New MemoryStream
        'bmpImage.Save(msImage, myImageCodecInfo, myEncoderParameters)

        '' Assign to return Variable
        'Dim bmpRetVal As Image = Image.FromStream(msImage)

        '' Tidy
        ''msImage.Dispose() ' TODO - This was commented
        'myEncoderParameter.Dispose()
        'myEncoderParameters.Dispose()

        '' Return the Result
        'Return bmpRetVal

    End Function

    Private Function ImageSize(ByVal imgImage As Image) As Integer

        ' Local Vars
        Dim nRetVal As Integer
        Dim imgStream As MemoryStream = New MemoryStream()

        ' Load the Image into a Memory Stream
        imgImage.Save(imgStream, System.Drawing.Imaging.ImageFormat.Jpeg)

        ' Get the Stream Length
        nRetVal = imgStream.Length

        ' Tidy
        imgStream.Close()
        imgStream.Dispose()

        ' Return the Length
        Return nRetVal

    End Function

    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function

    Public Sub ProcessPropertyImage(ByRef imgImage As Image)

        ' Get the Image Size
        Dim nWidth As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("PropertyImageWidth"))
        Dim nHeight As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("PropertyImageHeight"))
        Dim nDPI As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("PropertyImageDPI"))
        Dim nMaxFileSize As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("PropertyImageMaxSizeInKilobytes")) * 1000

        ' Declare Return Variable
        Dim bmpRetVal As Bitmap = New Bitmap(nWidth, nHeight, PixelFormat.Format24bppRgb)

        ' Load into Graphics Object
        Using g As Graphics = Graphics.FromImage(bmpRetVal)

            ' Resizing
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.FillRectangle(Brushes.White, 0, 0, nWidth, nHeight)
            g.DrawImage(imgImage, 0, 0, nWidth, nHeight)

        End Using

        ' Set Resolution
        bmpRetVal.SetResolution(nDPI, nDPI)

        ' Init Quality
        Dim nQuality As Integer = 100

        ' Get the Image @ 100% Quality
        Dim imgReducedImage As Image = ImageQuality(bmpRetVal, nQuality)

        ' While the File Size is too Large
        While ImageSize(imgReducedImage) > nMaxFileSize

            ' Reduce Quality by 5%
            nQuality -= 5

            ' Get the New Image
            imgReducedImage = ImageQuality(bmpRetVal, nQuality)

        End While

        ' Overwrite Image
        imgImage = imgReducedImage

    End Sub

    Public Sub ApplyIAWatermark(ByRef imgImage As Image)

        ' Load the IA Watermark
        Dim imgWatermark As Image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/IA.png"))

        ' Apply
        AddWatermark(imgImage, imgWatermark)

        ' Tidy
        imgWatermark.Dispose()

    End Sub
    Public Sub ApplyIAWatermarkCenter(ByRef imgImage As Image)

        ' Load the IA Watermark
        Dim imgWatermark As Image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/IA.png"))

        ' Apply
        AddWatermarkCenter(imgImage, imgWatermark)

        ' Tidy
        imgWatermark.Dispose()

    End Sub

    Public Function ApplyStatusWatermark(ByVal szImageURL As String, ByVal nStatusID As Integer) As String
        Try
            ' Don't add the Watermark to no-photo
            If Not szImageURL.Contains("no-photo") Then

                ' Does this Image Require a Watermark?
                If nStatusID = 5 Or nStatusID = 7 Or nStatusID = 20 Or nStatusID = 1001 Or nStatusID = 1002 Or nStatusID = 1003 Or nStatusID = 1004 Or nStatusID = 1005 Or nStatusID = 1006 Then

                    ' Local Vars
                    Dim msImage As New MemoryStream
                    Dim imgWatermark As Image
                    Dim imgImage As Image

                    ' Load the Image
                    imgImage = Image.FromFile(HttpContext.Current.Server.MapPath(szImageURL))

                    ' Load Watermark Based on Status
                    Select Case nStatusID

                        Case 5

                            ' Sold
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/Sold.png"))

                        Case 20
                            ' Exclusive
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/Exclusive_02.png"))

                        Case 7

                            ' Under Offer
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/UnderOffer4.png"))

                        Case 1001

                            ' DIY_BARGAIN
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/DIY_BARGAIN.png"))

                        Case 1002

                            ' NOW_NEGOTIABLE
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/NOW_NEGOTIABLE.png"))

                        Case 1003

                            ' REFORMED
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/REFORMED.png"))

                        Case 1004

                            ' BIG_REDUCTION
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/BIG_REDUCTION.png"))

                        Case 1005

                            ' Rent To Buy
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/RentToBuy.png"))

                        Case 1006

                            ' Rent To Buy
                            imgWatermark = Image.FromFile(HttpContext.Current.Server.MapPath("~/Images/Watermarks/Reserved.png"))

                    End Select

                    ' Apply
                    'AddWatermark(imgImage, imgWatermark, False)
                    AddWatermarkCenter(imgImage, imgWatermark, False)

                    ' Tidy
                    imgWatermark.Dispose()

                    ' Load the Image into a Memory Stream
                    imgImage.Save(msImage, Imaging.ImageFormat.Jpeg)

                    ' Update Image URL
                    szImageURL = "data:image/png;base64," + Convert.ToBase64String(msImage.ToArray(), 0, msImage.ToArray().Length)

                    ' Tidy
                    msImage.Close()
                    msImage.Dispose()
                    imgImage.Dispose()

                End If

            End If
        Catch ex As Exception

        End Try

        ' Return the URL
        Return szImageURL

    End Function

    Private Sub AddWatermark(ByRef imgMain As Image, ByVal imgWatermark As Image, Optional ByVal bTopRight As Boolean = True)
        Try
            ' Load into Graphics Object
            Using g As Graphics = Graphics.FromImage(imgMain)

                If bTopRight Then

                    g.DrawImage(imgWatermark, New Point(imgMain.Width - imgWatermark.Width - 14, 5))

                Else

                    g.DrawImage(imgWatermark, New Point(0, 0))

                End If

            End Using
        Catch ex As Exception

        End Try


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

    Public Function CreateThumbnail(ByVal szPropertyRef As String) As Boolean

        ' Local Vars
        Dim bRetVal As Boolean = False
        Dim szImagePath As String = HttpContext.Current.Server.MapPath("~/images/photos/properties/" & szPropertyRef.Trim & "/")
        Dim szImageFilename As String = szPropertyRef.Trim & "_1.jpg"
        Dim szImageThumbnail As String = szPropertyRef.Trim & "_TN.jpg"

        ' If a Header Image Exists
        If File.Exists(szImagePath & szImageFilename) Then

            ' Load the Image
            Dim img As Image = Image.FromFile(szImagePath & szImageFilename)

            ' Generate Thumbnail
            Dim bmp As Image = img.GetThumbnailImage(168, 124, Nothing, IntPtr.Zero)
            bmp.Save(szImagePath & szImageThumbnail)
            bmp.Dispose()

            ' Tidy
            img.Dispose()

            ' Return True
            bRetVal = True

        End If

        ' Return the Result
        Return bRetVal

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
    Public Function GetDataAsDataTable(ByVal szSQL As String) As DataTable

        ' Local Vars
        Dim dtDataTable As New DataTable

        ' Open Database
        Using sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("con").ToString)

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
    Public Enum E_Region As Integer
        Cordoba = 1
        Granada = 2
        Jaen = 3
        Malaga = 4
        Sevilla = 5
    End Enum
    Public Function GetLocations(RegionId As Integer, AreaId As Integer, language As Integer) As DataTable
        Dim ds As New DataSet
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("con").ToString())
        Dim cmdObj As New SqlCommand("Usp_PropertyLocations_Map01", conn)
        cmdObj.CommandType = Data.CommandType.StoredProcedure

        cmdObj.Parameters.Add("@nRegionID", Data.SqlDbType.Int)
        cmdObj.Parameters.Add("@nAreaID", Data.SqlDbType.Int)
        cmdObj.Parameters.Add("@language", Data.SqlDbType.Int)

        cmdObj.Parameters("@nRegionID").Value = RegionId
        cmdObj.Parameters("@nAreaID").Value = AreaId
        cmdObj.Parameters("@language").Value = language
        Dim da As New SqlDataAdapter()
        da.SelectCommand = cmdObj
        da.Fill(ds)
        conn.Close()
        conn.Dispose()
        cmdObj.Dispose()
        Return ds.Tables(0)
        ds.Dispose()
    End Function
#End Region

End Class
