Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports HashSoftwares
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Partial Class AdminNew_AddBlog
    Inherits System.Web.UI.Page
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Session Variables
        If Session("AdminDisplayingMessage") Is Nothing Then
            Session("AdminDisplayingMessage") = False
        End If
        If Session("AdminPropertyEdit") Is Nothing Then
            Session("AdminPropertyEdit") = False
        End If

        ' Load Header Image
        'ImageHeader.ImageUrl = "http://www.inlandandalucia.com/Images/Admin/header.jpg"

        '' Load the Button Images
        'ImageButtonBack.ImageUrl = GetBackImagePath()
        'ImageButtonForward.ImageUrl = GetForwardImagePath()
        'ImageButtonSignOut.ImageUrl = GetSignOutImagePath()

        '' Add Postback Trigger for Images
        'Dim sm As ScriptManager = ScriptManager.GetCurrent(Page)
        'sm.RegisterPostBackControl(AdminNavigation)

    End Sub



    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function savelanguages(langtype As String, Title As String, SubTitle As String, Description As String, PostedOn As DateTime) As String
        Dim dtaddmore As New System.Data.DataTable()
        If HttpContext.Current.Session("languageNew") IsNot Nothing Then

            dtaddmore = DirectCast(HttpContext.Current.Session("languageNew"), System.Data.DataTable)
            Dim isexits As Integer = 0
            For i As Integer = 0 To dtaddmore.Rows.Count - 1
                isexits = 0
                If dtaddmore.Rows(i)("LanguageType").ToString() = langtype Then
                    dtaddmore.Rows(i)("Title") = Title
                    dtaddmore.Rows(i)("SubTitle") = SubTitle
                    dtaddmore.Rows(i)("Description") = Description
                    dtaddmore.Rows(i)("PostedBy") = HttpContext.Current.Session("ContactId")
                    dtaddmore.Rows(i)("PostedOn") = PostedOn
                    dtaddmore.Rows(i)("IsActive") = True
                    isexits = 1
                End If
            Next

            If Not isexits > 0 Then
                Dim draddmore As System.Data.DataRow = dtaddmore.NewRow()
                draddmore(0) = langtype
                draddmore(1) = Title
                draddmore(2) = SubTitle
                draddmore(3) = Description
                '     draddmore(3) = Label
                draddmore(4) = Convert.ToString(HttpContext.Current.Session("ContactId"))
                draddmore(5) = PostedOn
                draddmore(6) = True
                '   draddmore(7) = BlogTitle
                dtaddmore.Rows.Add(draddmore)
            End If
        Else
            dtaddmore.Columns.Add("LanguageType", GetType(String))
            dtaddmore.Columns.Add("Title", GetType(String))
            dtaddmore.Columns.Add("SubTitle", GetType(String))
            dtaddmore.Columns.Add("Description", GetType(String))
            '   dtaddmore.Columns.Add("Label", GetType(String))
            dtaddmore.Columns.Add("PostedBy", GetType(Integer))
            dtaddmore.Columns.Add("PostedOn", GetType(DateTime))
            dtaddmore.Columns.Add("IsActive", GetType(Boolean))
            '    dtaddmore.Columns.Add("BlogTitle", GetType(String))

            dtaddmore.Columns.Add("id", Type.[GetType]("System.Int32"))
            dtaddmore.Columns("id").AutoIncrement = True
            dtaddmore.Columns("id").AutoIncrementSeed = 1
            dtaddmore.Columns("id").AutoIncrementStep = 1
            Dim draddmore As System.Data.DataRow = dtaddmore.NewRow()

            draddmore(0) = langtype
            draddmore(1) = Title
            draddmore(2) = SubTitle
            draddmore(3) = Description
            '     draddmore(3) = Label
            draddmore(4) = Convert.ToString(HttpContext.Current.Session("ContactId"))
            draddmore(5) = PostedOn
            draddmore(6) = True
            '   draddmore(7) = BlogTitle
            dtaddmore.Rows.Add(draddmore)
        End If



        HttpContext.Current.Session("languageNew") = dtaddmore
        Return dtaddmore.ToString()
    End Function



    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetLangChange(langtype As String) As String
        Dim dtaddmore As New System.Data.DataTable()
        Dim Description As String = String.Empty
        If HttpContext.Current.Session("languageNew") IsNot Nothing Then

            dtaddmore = DirectCast(HttpContext.Current.Session("languageNew"), System.Data.DataTable)
            For i As Integer = 0 To dtaddmore.Rows.Count - 1
                If dtaddmore.Rows(i)("LanguageType").ToString() = langtype Then
                    Description = dtaddmore.Rows(i)("Description")
                End If
            Next
        End If

        Return Description
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Session.Remove("languageNew")

            If Request.QueryString.HasKeys() Then
                ID = Convert.ToInt32(Request.QueryString(0))
                Dim sql As SqlParameter() = New SqlParameter(0) {}
                sql(0) = New SqlParameter("@BlogId", ID)
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_tblBlogs_Select_By_Id1", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    btnUpdate.Style.Add(HtmlTextWriterStyle.Display, "block")
                    btnSubmit.Style.Add(HtmlTextWriterStyle.Display, "none")

                    Dim dtaddmore As New System.Data.DataTable()

                    dtaddmore.Columns.Add("LanguageType", GetType(String))
                    dtaddmore.Columns.Add("Title", GetType(String))
                    dtaddmore.Columns.Add("SubTitle", GetType(String))
                    dtaddmore.Columns.Add("Description", GetType(String))
                    '  dtaddmore.Columns.Add("Label", GetType(String))
                    dtaddmore.Columns.Add("PostedBy", GetType(Integer))
                    dtaddmore.Columns.Add("PostedOn", GetType(DateTime))
                    dtaddmore.Columns.Add("IsActive", GetType(Boolean))

                    dtaddmore.Columns.Add("id", Type.[GetType]("System.Int32"))
                    dtaddmore.Columns("id").AutoIncrement = True
                    dtaddmore.Columns("id").AutoIncrementSeed = 1
                    dtaddmore.Columns("id").AutoIncrementStep = 1
                    '  dtaddmore.Columns.Add("BlogTitle", GetType(String))
                    For i As Integer = 0 To dt.Rows.Count - 1

                        If dt.Rows(i)("LangType").ToString() = "en" Then
                            txttitle.Text = (Convert.ToString(dt.Rows(i)("Title")))
                            txtsubtitle.Text = (Convert.ToString(dt.Rows(i)("SubTitle")))
                            txtdescription.Text = (Convert.ToString(dt.Rows(i)("Description")))
                            hdnlabel.Value = (Convert.ToString(dt.Rows(i)("Label")))
                            txtPostdate.Text = (Convert.ToString(dt.Rows(i)("PostedOn")))
                            chkIsPopular.Checked = (Convert.ToBoolean(dt.Rows(i)("IsPopular")))
                            txtblogurl.Text = (Convert.ToString(dt.Rows(i)("BlogTitle")))
                            If Not (Convert.ToString(dt.Rows(0)("BlogImages"))) = "" Then
                                lblimg.Value = Convert.ToString(dt.Rows(i)("BlogImages"))
                                'imgblog.Style.Add(HtmlTextWriterStyle.Display, "block")
                                'imgblog.ImageUrl = "/BlogImages/" + (Convert.ToString(dt.Rows(0)("Image")))
                            End If
                            If Not (Convert.ToString(dt.Rows(i)("BlogImages"))) = "" Then
                                myllist.InnerHtml = ""
                                Dim BlogImages As String() = dt.Rows(i)("BlogImages").ToString().Split(",")
                                For j As Integer = 0 To BlogImages.Count() - 1
                                    myllist.InnerHtml = myllist.InnerHtml + "<li><span>" + BlogImages(j) + "</span> <a href='#!' class='remove'>Remove</a><br/> (http://www.inlandandalucia.com/BlogImages/" + BlogImages(j) + ") </li>"
                                Next
                            End If
                            If Not String.IsNullOrEmpty(hdnlabel.Value) Then

                                divlabel.Visible = True
                                Dim labels As String() = dt.Rows(i)("Label").ToString().Split(",")

                                For j As Integer = 0 To labels.Count() - 1

                                    divlabel.Visible = True

                                    divlabel.InnerHtml = divlabel.InnerHtml + "<div class='tag tagcity'><span class='tag-name city-name'>" + labels(j) + "</span><span class='tag-delete lbbl'><i class='fa fa-times'></i></span></div>"
                                Next
                                hdnlabel.Value = dt.Rows(i)("Label").ToString()



                            End If

                        End If
                        Dim draddmore As System.Data.DataRow = dtaddmore.NewRow()
                        draddmore(0) = Convert.ToString(dt.Rows(i)("LangType"))
                        draddmore(1) = Convert.ToString(dt.Rows(i)("Title"))
                        draddmore(2) = Convert.ToString(dt.Rows(i)("SubTitle"))
                        draddmore(3) = Convert.ToString(dt.Rows(i)("Description"))
                        'draddmore(3) = Convert.ToString(dt.Rows(i)("Label"))
                        draddmore(4) = Convert.ToString(dt.Rows(i)("PostedBy"))
                        draddmore(5) = Convert.ToString(dt.Rows(i)("PostedOn"))
                        draddmore(6) = Convert.ToString(dt.Rows(i)("IsActive"))
                        ' draddmore(7) = Convert.ToString(dt.Rows(i)("BlogTitle"))



                        'HiddenFieldImage.Src = Convert.ToString(dt.Rows[0]["popupimage"]);
                        dtaddmore.Rows.Add(draddmore)
                    Next
                    HttpContext.Current.Session("languageNew") = dtaddmore
                End If
            End If
        End If

    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim szFileName As String = ""
        Dim comma = ""

        Dim ImageFiles As HttpFileCollection = Request.Files
        If fileimg.HasFiles Then


            For i As Integer = 0 To ImageFiles.Count - 1
                Dim file As HttpPostedFile = ImageFiles(i)
                file.SaveAs(Server.MapPath("/BlogImages/") & ImageFiles(i).FileName)
                If i > 0 Then
                    comma = ","
                End If
                szFileName = szFileName + comma + ImageFiles(i).FileName
            Next
        End If

        '' If we have a Filename
        'If fileimg.HasFile Then

        '    ' Get the Filename
        '    szFileName = fileimg.FileName

        '    ' Upload the Document
        '    fileimg.PostedFile.SaveAs(Server.MapPath("~/BlogImages/" & szFileName))

        '    ' Reflect Changes
        '    '  upAddAdmin.Update()

        'End If

        Dim dtaddmore As New System.Data.DataTable()
        If HttpContext.Current.Session("languageNew") IsNot Nothing Then
            Dim prdid As Integer = 0
            dtaddmore = DirectCast(HttpContext.Current.Session("languageNew"), System.Data.DataTable)
            ''    Dim id As Integer = Convert.ToInt32(Request.QueryString(0))
            Dim blogid As Integer = 0
            For i As Integer = 0 To dtaddmore.Rows.Count - 1


                If dtaddmore.Rows(i)("LanguageType").ToString() = "en" Then

                    Dim sql As SqlParameter() = New SqlParameter(9) {}
                    sql(0) = New SqlParameter("@Title", dtaddmore.Rows(i)("Title").ToString())
                    sql(1) = New SqlParameter("@SubTitle", dtaddmore.Rows(i)("SubTitle").ToString())
                    sql(2) = New SqlParameter("@Description ", dtaddmore.Rows(i)("Description").ToString())
                    sql(3) = New SqlParameter("@Label", hdnlabel.Value.TrimEnd(","))
                    sql(4) = New SqlParameter("@Image", "")
                    sql(5) = New SqlParameter("@BlogImages", szFileName)
                    'sql(6) = New SqlParameter("@DatePosted", dtaddmore.Rows(i)("PostedOn").ToString())
                    sql(6) = New SqlParameter("@Ispopular", chkIsPopular.Checked)
                    sql(7) = New SqlParameter("@BlogTitle", txtblogurl.Text)
                    sql(8) = New SqlParameter("@PostedBy", Session("ContactId"))
                    blogid = Convert.ToInt16(SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_insert_tblBlogs", sql).Tables(0).Rows(0)("BlogId"))
                    'Response.Redirect("Blogs.aspx")

                    'fileuploadimage.FileName

                    '' HashSoftwares.SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, System.Data.CommandType.StoredProcedure, "Usp_product_Update", sql)
                End If

                Dim sql1 As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(6) {}
                ''  Dim sql As SqlParameter() = New SqlParameter(10) {}
                sql1(0) = New SqlParameter("@Title", dtaddmore.Rows(i)("Title").ToString())
                sql1(1) = New SqlParameter("@SubTitle", dtaddmore.Rows(i)("SubTitle").ToString())
                sql1(2) = New SqlParameter("@Description ", dtaddmore.Rows(i)("Description").ToString())
                'sql1(3) = New SqlParameter("@Label", txtblogurl.Text)
                'sql1(4) = New SqlParameter("@Image", "")
                sql1(4) = New SqlParameter("@BlogId", blogid)
                sql1(5) = New SqlParameter("@LangType", dtaddmore.Rows(i)("LanguageType").ToString())
                'sql1(6) = New SqlParameter("@BlogImages", lblimg.Value)
                'sql1(7) = New SqlParameter("@DatePosted", dtaddmore.Rows(i)("DatePosted").ToString())
                'sql1(8) = New SqlParameter("@Ispopular", dtaddmore.Rows(i)("Ispopular").ToString())
                'sql1(9) = New SqlParameter("@BlogTitle", txtblogurl.Text)

                HashSoftwares.SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, System.Data.CommandType.StoredProcedure, "usp_Insert_tblBloglanguage", sql1)
            Next
        End If
        Response.Redirect("Blogs.aspx")

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)

        Dim szFileName As String = ""
        Dim comma = ""

        ' If we have a Filename
        If Not lblimg.Value = "" Then
            Dim ImageFiles As HttpFileCollection = Request.Files
            If fileimg.HasFiles Then

                For i As Integer = 0 To ImageFiles.Count - 1
                    Dim file As HttpPostedFile = ImageFiles(i)
                    file.SaveAs(Server.MapPath("/BlogImages/") & ImageFiles(i).FileName)
                Next
            End If
        End If
        Dim dtaddmore As New System.Data.DataTable()
        If HttpContext.Current.Session("languageNew") IsNot Nothing Then
            Dim prdid As Integer = 0
            dtaddmore = DirectCast(HttpContext.Current.Session("languageNew"), System.Data.DataTable)
            Dim id As Integer = Convert.ToInt32(Request.QueryString(0))
            For i As Integer = 0 To dtaddmore.Rows.Count - 1


                If dtaddmore.Rows(i)("LanguageType").ToString() = "en" Then

                    Dim sql As SqlParameter() = New SqlParameter(9) {}
                    sql(0) = New SqlParameter("@Title", dtaddmore.Rows(i)("Title").ToString())
                    sql(1) = New SqlParameter("@SubTitle", dtaddmore.Rows(i)("SubTitle").ToString())
                    sql(2) = New SqlParameter("@Description ", dtaddmore.Rows(i)("Description").ToString())
                    sql(3) = New SqlParameter("@Label", hdnlabel.Value.TrimEnd(","))
                    sql(4) = New SqlParameter("@Image", "")
                    sql(5) = New SqlParameter("@BlogId", Convert.ToInt32(Request.QueryString(0)))
                    sql(6) = New SqlParameter("@BlogImages", lblimg.Value)
                    'sql(7) = New SqlParameter("@DatePosted", dtaddmore.Rows(i)("PostedOn").ToString())
                    sql(7) = New SqlParameter("@Ispopular", chkIsPopular.Checked)
                    sql(8) = New SqlParameter("@BlogTitle", txtblogurl.Text)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_update_tblBlogs", sql).ToString()
                    '    Response.Redirect("Blogs.aspx")

                    'fileuploadimage.FileName

                    '' HashSoftwares.SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, System.Data.CommandType.StoredProcedure, "Usp_product_Update", sql)
                End If
                Dim sql1 As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(6) {}
                ''  Dim sql As SqlParameter() = New SqlParameter(10) {}
                sql1(0) = New SqlParameter("@BlogId", Convert.ToInt32(Request.QueryString(0)))
                sql1(1) = New SqlParameter("@Title", dtaddmore.Rows(i)("Title").ToString())
                sql1(2) = New SqlParameter("@SubTitle", dtaddmore.Rows(i)("SubTitle").ToString())
                sql1(3) = New SqlParameter("@Description ", dtaddmore.Rows(i)("Description").ToString())
                'sql1(3) = New SqlParameter("@Label", txtblogurl.Text)
                'sql1(4) = New SqlParameter("@Image", "")

                sql1(4) = New SqlParameter("@LangType", dtaddmore.Rows(i)("LanguageType").ToString())
                'sql1(6) = New SqlParameter("@BlogImages", lblimg.Value)
                'sql1(7) = New SqlParameter("@DatePosted", dtaddmore.Rows(i)("DatePosted").ToString())
                'sql1(8) = New SqlParameter("@Ispopular", dtaddmore.Rows(i)("Ispopular").ToString())
                'sql1(9) = New SqlParameter("@BlogTitle", txtblogurl.Text)

                HashSoftwares.SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, System.Data.CommandType.StoredProcedure, "usp_update_tblBloglanguage", sql1)
            Next
        End If



        '=======================================================
        'Service provided by Telerik (www.telerik.com)
        'Conversion powered by NRefactory.
        'Twitter: @telerik
        'Facebook: facebook.com/telerik
        '=======================================================



    End Sub
End Class
