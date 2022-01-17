Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports inland_api
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Net.Mail


Partial Class AdminNew_Property_Images
    Inherits System.Web.UI.Page
    Dim CDataAccess As New ClassDataAccess
    Dim CUtilities As New ClassUtilities

    Protected Sub btnPropertyGeneral_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_General.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyDescription_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Description.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyImages_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Images.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyFeatures_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Features.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyHistory_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_History.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Protected Sub btnPropertyDocuments_Click(sender As Object, e As EventArgs)
        Response.Redirect("Property_Documents.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            If Not Request.QueryString("PropertyId") = "" Then
                hdcont.Value = Request.QueryString("PropertyId")
                hdpageind.Value = Request.QueryString("PageIndex")
                Dim url As String = Request.UrlReferrer.ToString()
                'Dim url As String = "http://localhost:59926/AdminNew/AddProperty.aspx?PropertyId=29696&PageIndex=1&Ref=&Address=&type=0&Area=0&Town=0&Beds=0&Bath=0&status=0"
                Dim uri = New Uri(url)
                Dim qs = HttpUtility.ParseQueryString(uri.Query)
                'qs.[Set]("ID", hdcont.Value)
                If url.Contains("ManageProperties.aspx") Then
                    qs.[Set]("PageIndex", hdpageind.Value)
                    qs.[Set]("Ref", Request.QueryString("Ref"))
                    qs.[Set]("Address", Request.QueryString("Address"))
                    qs.[Set]("type", Request.QueryString("type"))
                    qs.[Set]("Area", Request.QueryString("Area"))
                    qs.[Set]("Town", Request.QueryString("Town"))
                    qs.[Set]("Beds", Request.QueryString("Beds"))
                    qs.[Set]("Bath", Request.QueryString("Bath"))
                    qs.[Set]("status", Request.QueryString("status"))
                End If
                If url.Contains("LatestProperties.aspx") Then
                    qs.[Set]("Duration", Request.QueryString("Duration"))
                    qs.[Set]("Created", Request.QueryString("Created"))
                    qs.[Set]("Modified", Request.QueryString("Modified"))
                End If
                If url.Contains("Novideos.aspx") Then
                    qs.[Set]("PageIndex", hdpageind.Value)
                End If
                Dim uriBuilder = New UriBuilder(uri)
                uriBuilder.Query = qs.ToString()
                Dim newUri = uriBuilder.Uri
                hdnprevurl.Value = newUri.ToString()

            End If
            lblpropref.Text = Request.QueryString("PropertyRef").ToString()
            ' Add Image Inserting Options
            DropDownListUploadImageOption.Items.Add("Append")
            DropDownListUploadImageOption.Items.Add("Prepend")
            DropDownListUploadImageOption.Items.Add("Replace Main")
            Dim CImage As ClassImage
            ' Init ArrayList
            Session("PropertyAdminImages") = New ClassImages
            ' Get the IA Ref for this Property

            'Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))
            'CProperty.Load(Convert.ToInt32(Request.QueryString("PropertyId").ToString()))

            Dim sqlPropertyDetails As SqlParameter() = New SqlParameter(1) {}
            sqlPropertyDetails(0) = New SqlParameter("@Property_ID", Request.QueryString("PropertyId").ToString())
            Dim dtPropertyDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Select_By_PropertyId", sqlPropertyDetails).Tables(0)
            Dim PropertyRef As String = dtPropertyDetails.Rows(0)("Property_Ref").ToString()
            Dim NumberOfPhotos As Int32 = Convert.ToInt32(dtPropertyDetails.Rows(0)("Num_Photos").ToString())
            Dim PropertyPartnerId As Int32 = Convert.ToInt32(dtPropertyDetails.Rows(0)("Partner_ID").ToString())

            Dim szIARef As String = CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), PropertyRef).Trim.ToUpper
            ' Only do the Following if we have a Reference
            If PropertyRef.Trim <> String.Empty Then

                ' For each of the Images
                For nImage As Integer = 1 To NumberOfPhotos
                    ' Define a New Image (Restricted to Partner)
                    CImage = New ClassImage(szIARef, szIARef.Trim & "_" & nImage.ToString.Trim & ".jpg", (Convert.ToInt32(Session("ContactPartnerID")) = PropertyPartnerId) Or DirectCast(Session("AdminUser"), Boolean))
                    ' If this Image Exists
                    If File.Exists(Server.MapPath(CImage.CleanURL)) Then
                        ' Add this to the Array
                        DirectCast(Session("PropertyAdminImages"), ClassImages).Append(CImage)
                    Else
                        ' File does not Exist, Ignore
                        CImage = Nothing
                    End If
                Next
                ' Display the Images
                DisplayImages()
            End If
            DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub
    Protected Sub btnimageprop_Click(sender As Object, e As EventArgs)
        Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))
        CProperty.Load(Convert.ToInt32(Request.QueryString("PropertyId").ToString()))
        Dim bError As Boolean

        ' If we have Images
        If Not Session("PropertyAdminImages") Is Nothing Then
            CProperty.Images = DirectCast(Session("PropertyAdminImages"), ClassImages)
        End If

        ' Save this Property to the Database
        'bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))


        ' If we have no Error
        If Not bError Then

            ' IMAGES

            Dim CDataAccess As New ClassDataAccess
            Dim nImage As Integer = 0
            Dim szFiles() As String
            Dim szFile As String

            ' Get the Directories
            Dim szTargetDirectory As String = HttpContext.Current.Server.MapPath("~/Images/Photos/Properties/" & lblpropref.Text.Trim.ToUpper)

            ' If the Target Directory does not Exists
            If Not Directory.Exists(szTargetDirectory) Then

                ' Create the Directory
                Directory.CreateDirectory(szTargetDirectory)

            End If

            ' Get All Files
            szFiles = Directory.GetFiles(szTargetDirectory)

            ' For each File
            For Each szFile In szFiles

                ' If this is not one of the Files in the Collection, Delete
                If Not CProperty.Images.Contains(Path.GetFileName(szFile)) Then

                    Try

                        ' Attempt Deletion
                        File.Delete(szFile)

                    Catch ex As Exception
                        System.Console.Write("Source: " & ex.Source & " / " & ex.Message)
                    End Try

                End If

            Next

            ' For each Image
            For Each CImage As ClassImage In CProperty.Images.Image

                ' Create Temporary Filename to avoid Duplicate Filenames
                File.Move(szTargetDirectory & "\" & CImage.Filename, szTargetDirectory & "\" & CImage.TemporaryFilename)
                CImage.Filename = CImage.TemporaryFilename

            Next

            ' For each Image
            For Each CImage As ClassImage In CProperty.Images.Image

                ' Increment Image Counter
                nImage += 1

                ' Give Image Correct Filename
                File.Move(szTargetDirectory & "\" & CImage.Filename, szTargetDirectory & "\" & lblpropref.Text.Trim & "_" & nImage.ToString.Trim & ".jpg")
                CImage.Filename = lblpropref.Text.Trim & "_" & nImage.ToString.Trim & ".jpg"

            Next

            ' If we have at least 1 Image
            If CProperty.Images.Count > 0 Then

                ' Create a Thumbnail
                Dim CUtilities As New ClassUtilities
                CUtilities.CreateThumbnail(lblpropref.Text)
                CUtilities = Nothing

            End If

        End If

        'Update Number of photos of property table

        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@Property_Ref", lblpropref.Text)
        sql(1) = New SqlParameter("@Num_Photos", CProperty.Images.Count)
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_NumPhoto_Update", sql)

        lblimage.Text = "Property Images Saved !"
        'ButtonViewingPhotos.Visible = True
        ' If we had an Error

        If bError Then
            ' szSaveMessage = "An error occurred whilst saving this property to the database"
        Else
            If Not Request.QueryString("PropertyId") = "" Then
                'Try
                '    Dim updatePropertyReturnJason As String
                '    Dim httpRequest As HttpWebRequest = CType(WebRequest.Create(New Uri("http://inlandandalucia-api.polcode.dev/api/v1/trigger/mssql/property/update/" & CProperty.ID & "?access_token=23ahgj45ioas9s2hgs")), HttpWebRequest)
                '    httpRequest.ContentType = "application/json"
                '    httpRequest.Method = "GET"
                '    Using httpResponse As HttpWebResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
                '        Using stream As Stream = httpResponse.GetResponseStream()
                '            Dim json As String = (New StreamReader(stream)).ReadToEnd()
                '            updatePropertyReturnJason = json
                '        End Using
                '    End Using
                '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                '    sql(0) = New SqlParameter("@Title", "Property-Image")
                '    sql(1) = New SqlParameter("@ActionType", "Update")
                '    sql(2) = New SqlParameter("@JasonString", updatePropertyReturnJason)
                '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                'Catch ex As Exception
                '    Dim sql As SqlParameter() = New SqlParameter(5) {}
                '    sql(0) = New SqlParameter("@Title", "Property-Image")
                '    sql(1) = New SqlParameter("@ActionType", "Update")
                '    sql(2) = New SqlParameter("@JasonString", ex.Message.ToString())
                '    sql(3) = New SqlParameter("@Created_By_Id", Convert.ToInt32(Session("ContactID")))
                '    sql(4) = New SqlParameter("@Property_Id", CProperty.ID)
                '    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_tblAPILOGS_Insert", sql)
                'End Try
            End If
        End If

        DisplayImages(, True)
        updAddProperty_Images.Update()
        btnimageprop.BackColor = System.Drawing.ColorTranslator.FromHtml("#303194")
        Session.Remove("PropertyAdminImages")
        Response.Redirect("Property_Images.aspx?PropertyId=" & Request.QueryString("PropertyId").ToString() & "&PropertyRef=" & lblpropref.Text)
    End Sub
    Private Sub DisplayImages(Optional ByVal alAffectedIndexes As ArrayList = Nothing, Optional ByVal bDeletion As Boolean = False)

        ' Local Vars
        Dim nIndex As Integer
        Dim mpContentPlaceHolder As ContentPlaceHolder
        mpContentPlaceHolder = CType(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        ' If we have Loaded Images
        If Not Session("PropertyAdminImages") Is Nothing Then

            ' If we aren't Dealing with Affected Indexes
            If alAffectedIndexes Is Nothing Then

                ' For each Image

                For nIndex = 1 To 16

                    ' If we have a URL as this Location
                    If nIndex <= DirectCast(Session("PropertyAdminImages"), ClassImages).Count Then

                        ' Assign the URL to this Control

                        DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImagenw).LoadImage(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage))

                        ' Set Header Image
                        DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImagenw).MakeHeaderImage(nIndex = 1)

                        ' Enable / Disable
                        DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim), WebUserControlAdminPropertyImagenw).Enable(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage).Enabled)

                        ' Make Visible
                        mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim).Visible = True

                    Else

                        ' Make Invisible

                        ' AdminPropertyImage1.Visible = True


                        mpContentPlaceHolder.FindControl("AdminPropertyImage" & nIndex.ToString.Trim).Visible = False
                    End If

                Next

            Else

                ' Specific Indexes being Updated
                For Each nIndex In alAffectedIndexes

                    ' Assign the URL to this Control
                    DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & (nIndex).ToString.Trim), WebUserControlAdminPropertyImagenw).LoadImage(DirectCast(DirectCast(Session("PropertyAdminImages"), ClassImages).Image(nIndex - 1), ClassImage))

                    ' Set Header Image
                    DirectCast(mpContentPlaceHolder.FindControl("AdminPropertyImage" & (nIndex).ToString.Trim), WebUserControlAdminPropertyImagenw).MakeHeaderImage(nIndex = 1)

                    ' Make Visible
                    mpContentPlaceHolder.FindControl("AdminPropertyImage" & (nIndex).ToString.Trim).Visible = True

                Next

            End If

        End If

    End Sub
    Protected Sub DropDownListUploadImageOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListUploadImageOption.SelectedIndexChanged
        ' Make the Upload Image Visible / Invisible
        TableRowImageOptions.Visible = (Not AdminPropertyImage16.Visible) Or (AdminPropertyImage16.Visible And DropDownListUploadImageOption.SelectedIndex = 2)
        AjaxBulkFileUploadImage.Visible = TableRowImageOptions.Visible
    End Sub
    Public Sub ImageLeft(ByVal nPosition As Integer)

        ' Local Vars
        Dim alAffectedIndexes As ArrayList

        ' Move Images Left
        alAffectedIndexes = DirectCast(Session("PropertyAdminImages"), ClassImages).ImageLeft(nPosition)

        ' If we have Affected Indexes
        If alAffectedIndexes.Count > 0 Then

            ' Display the Images
            DisplayImages(alAffectedIndexes)

        End If

        ' Tidy
        alAffectedIndexes.Clear()
        alAffectedIndexes = Nothing

        ' Make Dirty
        '  MakeDirty()

    End Sub
    Public Sub ImageRight(ByVal nPosition As Integer)

        ' Local Vars
        Dim alAffectedIndexes As ArrayList

        ' Move Images Right
        alAffectedIndexes = DirectCast(Session("PropertyAdminImages"), ClassImages).ImageRight(nPosition)

        ' If we have Affected Indexes
        If alAffectedIndexes.Count > 0 Then

            ' Display the Images
            DisplayImages(alAffectedIndexes)

        End If

        ' Tidy
        alAffectedIndexes.Clear()
        alAffectedIndexes = Nothing

        ' Make Dirty
        '  MakeDirty()

    End Sub
    Public Sub ImageUp(ByVal nPosition As Integer)

        ' Local Vars
        Dim alAffectedIndexes As ArrayList

        ' Move Images Right
        alAffectedIndexes = DirectCast(Session("PropertyAdminImages"), ClassImages).ImageUp(nPosition)

        ' If we have Affected Indexes
        If alAffectedIndexes.Count > 0 Then

            ' Display the Images
            DisplayImages(alAffectedIndexes)

        End If

        ' Tidy
        alAffectedIndexes.Clear()
        alAffectedIndexes = Nothing

        ' Make Dirty
        '  MakeDirty()

    End Sub
    Public Sub ImageDown(ByVal nPosition As Integer)

        ' Local Vars
        Dim alAffectedIndexes As ArrayList

        ' Move Images Right
        alAffectedIndexes = DirectCast(Session("PropertyAdminImages"), ClassImages).ImageDown(nPosition)

        ' If we have Affected Indexes
        If alAffectedIndexes.Count > 0 Then

            ' Display the Images
            DisplayImages(alAffectedIndexes)

        End If

        ' Tidy
        alAffectedIndexes.Clear()
        alAffectedIndexes = Nothing

        ' Make Dirty
        ' MakeDirty()

    End Sub
    Public Sub ImageDelete(ByVal nPosition As Integer)

        ' Remove this from the Array of those Selected
        DirectCast(Session("PropertyAdminImages"), ClassImages).Remove(nPosition)

        ' Display the Images
        DisplayImages(, True)

        ' Enable / Disable Image Upload Button
        DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)

        ' Make Dirty
        '  MakeDirty()
        btnimageprop.BackColor = Drawing.Color.Red
        btnimageprop.ForeColor = Drawing.Color.White
        btnimageprop.Font.Bold = True
        updAddProperty_Images.Update()

    End Sub
    Protected Sub ButtonUploadImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUploadImage.Click

        ' If the Session has Expired
        If Session("ContactPartnerID") Is Nothing Then
            Response.Redirect("~/AgentLogin.aspx")
        Else

            ' Check the Session hasn't Expired
            If Not Session("PropertyAdminImages") Is Nothing Then
                For Each postedFile As HttpPostedFile In FileUploadImage.PostedFiles
                    ' If we have a Filename
                    If FileUploadImage.HasFile Then

                        ' Upload the Image
                        UploadImage(postedFile.FileName, postedFile.InputStream)
                        btnimageprop.BackColor = Drawing.Color.Red
                        btnimageprop.ForeColor = Drawing.Color.White
                        btnimageprop.Font.Bold = True

                    End If
                Next

            End If

        End If

    End Sub
    Private Sub UploadImage(ByVal szFilename As String, ByVal strFile As IO.Stream, Optional ByVal bBulk As Boolean = False)

        ' Only do the Following if we don't already have the Maximum Number of Properties
        If DirectCast(Session("PropertyAdminImages"), ClassImages).Count < 16 Then

            ' Mark Property as Dirty
            'MakeDirty()

            ' If we haven't already Uploaded this File
            If Not DirectCast(Session("PropertyAdminImages"), ClassImages).Contains(szFilename) Then

                ' Get the IA Reference for this Property
                Dim CDataAccess As New ClassDataAccess

                ' Load the Property
                Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))
                CProperty.Load(Convert.ToInt32(Request.QueryString("PropertyId").ToString()))

                ' Define a New Image
                Dim CImage As New ClassImage(CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), CProperty.Reference), szFilename, True)

                ' Tidy
                CDataAccess = Nothing

                ' If the Directory does not Exist
                If Not Directory.Exists(CImage.ImageDirectory) Then

                    ' Create the Directory
                    Directory.CreateDirectory(CImage.ImageDirectory)

                End If

                ' Resize and Apply IA Watermark
                Dim CUtilities As New ClassUtilities
                Dim imgImage As Drawing.Image = Drawing.Image.FromStream(strFile)
                CUtilities.ProcessPropertyImage(imgImage)
                'CUtilities.ApplyIAWatermark(im gImage)
                CUtilities.ApplyIAWatermarkCenter(imgImage)
                CUtilities = Nothing

                ' Save the Image
                imgImage.Save(Server.MapPath(CImage.CleanPath & CImage.Filename))

                ' Tidy
                imgImage.Dispose()

                ' If this is Bulk
                If bBulk Then

                    ' Bulk - Append
                    DirectCast(Session("PropertyAdminImages"), ClassImages).Append(CImage)

                Else

                    ' Single

                    ' Assign Affected Index
                    Dim alAffectedIndexes As New ArrayList

                    ' Depending on the Option Selected
                    Select Case DropDownListUploadImageOption.SelectedIndex

                        Case 0
                            ' Append
                            DirectCast(Session("PropertyAdminImages"), ClassImages).Append(CImage)
                            alAffectedIndexes.Add(DirectCast(Session("PropertyAdminImages"), ClassImages).Count)

                        Case 1
                            ' Prepend
                            DirectCast(Session("PropertyAdminImages"), ClassImages).Prepend(CImage)

                            ' Redraw Everything
                            alAffectedIndexes = Nothing

                        Case Else
                            ' Replace Main
                            DirectCast(Session("PropertyAdminImages"), ClassImages).ReplaceMain(CImage)
                            alAffectedIndexes.Add(1)

                    End Select

                    ' Display Images
                    DisplayImages(alAffectedIndexes)

                    ' Tidy
                    If Not alAffectedIndexes Is Nothing Then
                        alAffectedIndexes.Clear()
                    End If
                    alAffectedIndexes = Nothing

                    ' Enable / Disable Image Upload Button
                    DropDownListUploadImageOption_SelectedIndexChanged(Nothing, Nothing)

                End If

            End If

        End If

    End Sub

End Class
