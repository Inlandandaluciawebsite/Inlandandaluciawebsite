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
    'Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    '    ' Session Variables
    '    If Session("AdminDisplayingMessage") Is Nothing Then
    '        Session("AdminDisplayingMessage") = False
    '    End If
    '    If Session("AdminPropertyEdit") Is Nothing Then
    '        Session("AdminPropertyEdit") = False
    '    End If

    '    ' Load Header Image
    '    'ImageHeader.ImageUrl = "http://www.inlandandalucia.com/Images/Admin/header.jpg"

    '    '' Load the Button Images
    '    'ImageButtonBack.ImageUrl = GetBackImagePath()
    '    'ImageButtonForward.ImageUrl = GetForwardImagePath()
    '    'ImageButtonSignOut.ImageUrl = GetSignOutImagePath()

    '    '' Add Postback Trigger for Images
    '    'Dim sm As ScriptManager = ScriptManager.GetCurrent(Page)
    '    'sm.RegisterPostBackControl(AdminNavigation)

    'End Sub



    '<System.Web.Services.WebMethod(EnableSession:=True)>
    'Public Shared Function savelanguages(langtype As String, Title As String, SubTitle As String, Description As String, PostedOn As String) As String
    '    Dim dtaddmore As New System.Data.DataTable()
    '    If HttpContext.Current.Session("language") IsNot Nothing Then

    '        dtaddmore = DirectCast(HttpContext.Current.Session("language"), System.Data.DataTable)
    '        Dim isexits As Integer = 0
    '        For i As Integer = 0 To dtaddmore.Rows.Count - 1
    '            isexits = 0
    '            If dtaddmore.Rows(i)("LanguageType").ToString() = langtype Then
    '                dtaddmore.Rows(i)("Title") = Title
    '                dtaddmore.Rows(i)("SubTitle") = SubTitle
    '                dtaddmore.Rows(i)("Description") = Description
    '                dtaddmore.Rows(i)("PostedBy") = HttpContext.Current.Session("ContactId")
    '                dtaddmore.Rows(i)("PostedOn") = PostedOn
    '                dtaddmore.Rows(i)("IsActive") = True
    '                isexits = 1
    '            End If
    '        Next


    '        If Not isexits > 0 Then
    '            Dim draddmore As System.Data.DataRow = dtaddmore.NewRow()
    '            draddmore(0) = langtype
    '            draddmore(1) = Title
    '            draddmore(2) = SubTitle
    '            draddmore(3) = Description
    '            '     draddmore(3) = Label
    '            draddmore(4) = Convert.ToString(HttpContext.Current.Session("ContactId"))
    '            draddmore(5) = PostedOn
    '            draddmore(6) = True
    '            '   draddmore(7) = BlogTitle
    '            dtaddmore.Rows.Add(draddmore)
    '        End If
    '    Else
    '        dtaddmore.Columns.Add("LanguageType", GetType(String))
    '        dtaddmore.Columns.Add("Title", GetType(String))
    '        dtaddmore.Columns.Add("SubTitle", GetType(String))
    '        dtaddmore.Columns.Add("Description", GetType(String))
    '        '   dtaddmore.Columns.Add("Label", GetType(String))
    '        dtaddmore.Columns.Add("PostedBy", GetType(Integer))
    '        dtaddmore.Columns.Add("PostedOn", GetType(DateTime))
    '        dtaddmore.Columns.Add("IsActive", GetType(Boolean))
    '        '    dtaddmore.Columns.Add("BlogTitle", GetType(String))

    '        dtaddmore.Columns.Add("id", Type.[GetType]("System.Int32"))
    '        dtaddmore.Columns("id").AutoIncrement = True
    '        dtaddmore.Columns("id").AutoIncrementSeed = 1
    '        dtaddmore.Columns("id").AutoIncrementStep = 1
    '        Dim draddmore As System.Data.DataRow = dtaddmore.NewRow()

    '        draddmore(0) = langtype
    '        draddmore(1) = Title
    '        draddmore(2) = SubTitle
    '        draddmore(3) = Description
    '        '     draddmore(3) = Label
    '        draddmore(4) = Convert.ToString(HttpContext.Current.Session("ContactId"))
    '        draddmore(5) = PostedOn
    '        draddmore(6) = True
    '        '   draddmore(7) = BlogTitle
    '        dtaddmore.Rows.Add(draddmore)
    '    End If



    '    HttpContext.Current.Session("language") = dtaddmore
    '    Return dtaddmore.ToString()
    'End Function


    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_property_getbystaus").Tables(0)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                sql(0) = New SqlParameter("@propref", dt.Rows(i)("Property_ref").ToString())
                Dim dtl As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "Usp_getlangshortcode", sql).Tables(0)
                If dtl.Rows.Count > 0 Then
                    For j As Integer = 0 To dtl.Rows.Count - 1
                        Dim CUtilities As New ClassUtilities
                        Dim langid = dt.Rows(i)("language_Id").ToString()
                        Dim lasss = dtl.Rows(j)("language_short_code").ToString()
                        Dim lassss = dt.Rows(i)("shortdesc").ToString()
                        Dim shortdesc = CUtilities.TranslateNew(dt.Rows(i)("shortdesc").ToString(), Convert.ToInt16(dtl.Rows(j)("language_Id")), Convert.ToInt16(dt.Rows(i)("language_Id")))
                        Dim longdesc = CUtilities.TranslateNew(dt.Rows(i)("longdesc").ToString(), Convert.ToInt16(dtl.Rows(j)("language_Id")), Convert.ToInt16(dt.Rows(i)("language_Id")))
                        Dim sqln As SqlParameter() = New SqlParameter(4) {}
                        sqln(0) = New SqlParameter("@propref", dt.Rows(i)("Property_ref").ToString())
                        sqln(1) = New SqlParameter("@langid", dtl.Rows(j)("language_Id").ToString())
                        sqln(2) = New SqlParameter("@shorttext", shortdesc)
                        sqln(3) = New SqlParameter("@longtext", longdesc)
                        SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_property_inseart_desc_newlang", sqln)
                    Next
                End If
            Next
        End If
    End Sub
    'Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

    '    Dim szFileName As String = ""
    '    Dim comma = ""

    '    Dim ImageFiles As HttpFileCollection = Request.Files
    '    If fileimg.HasFiles Then


    '        For i As Integer = 0 To ImageFiles.Count - 1
    '            Dim file As HttpPostedFile = ImageFiles(i)
    '            file.SaveAs(Server.MapPath("/BlogImages/") & ImageFiles(i).FileName)
    '            If i > 0 Then
    '                comma = ","
    '            End If
    '            szFileName = szFileName + comma + ImageFiles(i).FileName
    '        Next
    '    End If

    '    '' If we have a Filename
    '    'If fileimg.HasFile Then

    '    '    ' Get the Filename
    '    '    szFileName = fileimg.FileName

    '    '    ' Upload the Document
    '    '    fileimg.PostedFile.SaveAs(Server.MapPath("~/BlogImages/" & szFileName))

    '    '    ' Reflect Changes
    '    '    '  upAddAdmin.Update()

    '    'End If

    '    Dim dtaddmore As New System.Data.DataTable()
    '    If HttpContext.Current.Session("language") IsNot Nothing Then
    '        Dim prdid As Integer = 0
    '        dtaddmore = DirectCast(HttpContext.Current.Session("language"), System.Data.DataTable)
    '        ''    Dim id As Integer = Convert.ToInt32(Request.QueryString(0))
    '        Dim blogid As Integer = 0
    '        For i As Integer = 0 To dtaddmore.Rows.Count - 1


    '            If dtaddmore.Rows(i)("LanguageType").ToString() = "en" Then

    '                Dim sql As SqlParameter() = New SqlParameter(10) {}
    '                sql(0) = New SqlParameter("@Title", dtaddmore.Rows(i)("Title").ToString())
    '                sql(1) = New SqlParameter("@SubTitle", dtaddmore.Rows(i)("SubTitle").ToString())
    '                sql(2) = New SqlParameter("@Description ", dtaddmore.Rows(i)("Description").ToString())
    '                sql(3) = New SqlParameter("@Label", hdnlabel.Value.TrimEnd(","))
    '                sql(4) = New SqlParameter("@Image", "")
    '                sql(4) = New SqlParameter("@Image", "")
    '                sql(5) = New SqlParameter("@BlogImages", szFileName)
    '                sql(6) = New SqlParameter("@DatePosted", dtaddmore.Rows(i)("PostedOn").ToString())
    '                sql(7) = New SqlParameter("@Ispopular", chkIsPopular.Checked)
    '                sql(8) = New SqlParameter("@BlogTitle", txtblogurl.Text)
    '                sql(9) = New SqlParameter("@PostedBy", Session("ContactId"))
    '                blogid = Convert.ToInt16(SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_insert_tblBlogs", sql).Tables(0).Rows(0)("BlogId"))
    '                'Response.Redirect("Blogs.aspx")

    '                'fileuploadimage.FileName

    '                '' HashSoftwares.SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, System.Data.CommandType.StoredProcedure, "Usp_product_Update", sql)
    '            End If

    '            Dim sql1 As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(6) {}
    '            ''  Dim sql As SqlParameter() = New SqlParameter(10) {}
    '            sql1(0) = New SqlParameter("@Title", dtaddmore.Rows(i)("Title").ToString())
    '            sql1(1) = New SqlParameter("@SubTitle", dtaddmore.Rows(i)("SubTitle").ToString())
    '            sql1(2) = New SqlParameter("@Description ", dtaddmore.Rows(i)("Description").ToString())
    '            'sql1(3) = New SqlParameter("@Label", txtblogurl.Text)
    '            'sql1(4) = New SqlParameter("@Image", "")
    '            sql1(4) = New SqlParameter("@BlogId", blogid)
    '            sql1(5) = New SqlParameter("@LangType", dtaddmore.Rows(i)("LanguageType").ToString())
    '            'sql1(6) = New SqlParameter("@BlogImages", lblimg.Value)
    '            'sql1(7) = New SqlParameter("@DatePosted", dtaddmore.Rows(i)("DatePosted").ToString())
    '            'sql1(8) = New SqlParameter("@Ispopular", dtaddmore.Rows(i)("Ispopular").ToString())
    '            'sql1(9) = New SqlParameter("@BlogTitle", txtblogurl.Text)

    '            HashSoftwares.SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, System.Data.CommandType.StoredProcedure, "usp_Insert_tblBloglanguage", sql1)


    '        Next
    '    End If



    '    Response.Redirect("Blogs.aspx")

    'End Sub

    'Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)

    '    Dim szFileName As String = ""
    '    Dim comma = ""



    '    ' If we have a Filename
    '    If Not lblimg.Value = "" Then
    '        Dim ImageFiles As HttpFileCollection = Request.Files
    '        If fileimg.HasFiles Then

    '            For i As Integer = 0 To ImageFiles.Count - 1
    '                Dim file As HttpPostedFile = ImageFiles(i)
    '                file.SaveAs(Server.MapPath("/BlogImages/") & ImageFiles(i).FileName)
    '            Next
    '        End If
    '    End If




    '        Dim dtaddmore As New System.Data.DataTable()
    '    If HttpContext.Current.Session("language") IsNot Nothing Then
    '        Dim prdid As Integer = 0
    '        dtaddmore = DirectCast(HttpContext.Current.Session("language"), System.Data.DataTable)
    '        Dim id As Integer = Convert.ToInt32(Request.QueryString(0))
    '        For i As Integer = 0 To dtaddmore.Rows.Count - 1


    '            If dtaddmore.Rows(i)("LanguageType").ToString() = "en" Then

    '                Dim sql As SqlParameter() = New SqlParameter(10) {}
    '                sql(0) = New SqlParameter("@Title", dtaddmore.Rows(i)("Title").ToString())
    '                sql(1) = New SqlParameter("@SubTitle", dtaddmore.Rows(i)("SubTitle").ToString())
    '                sql(2) = New SqlParameter("@Description ", dtaddmore.Rows(i)("Description").ToString())
    '                sql(3) = New SqlParameter("@Label", hdnlabel.Value.TrimEnd(","))
    '                sql(4) = New SqlParameter("@Image", "")
    '                sql(5) = New SqlParameter("@BlogId", Convert.ToInt32(Request.QueryString(0)))
    '                sql(6) = New SqlParameter("@BlogImages", lblimg.Value)
    '                sql(7) = New SqlParameter("@DatePosted", dtaddmore.Rows(i)("PostedOn").ToString())
    '                sql(8) = New SqlParameter("@Ispopular", chkIsPopular.Checked)
    '                sql(9) = New SqlParameter("@BlogTitle", txtblogurl.Text)
    '                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "usp_update_tblBlogs", sql).ToString()
    '                '    Response.Redirect("Blogs.aspx")

    '                'fileuploadimage.FileName

    '                '' HashSoftwares.SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, System.Data.CommandType.StoredProcedure, "Usp_product_Update", sql)
    '            End If
    '            Dim sql1 As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(6) {}
    '            ''  Dim sql As SqlParameter() = New SqlParameter(10) {}
    '            sql1(0) = New SqlParameter("@BlogId", Convert.ToInt32(Request.QueryString(0)))
    '            sql1(1) = New SqlParameter("@Title", dtaddmore.Rows(i)("Title").ToString())
    '            sql1(2) = New SqlParameter("@SubTitle", dtaddmore.Rows(i)("SubTitle").ToString())
    '            sql1(3) = New SqlParameter("@Description ", dtaddmore.Rows(i)("Description").ToString())
    '            'sql1(3) = New SqlParameter("@Label", txtblogurl.Text)
    '            'sql1(4) = New SqlParameter("@Image", "")

    '            sql1(4) = New SqlParameter("@LangType", dtaddmore.Rows(i)("LanguageType").ToString())
    '            'sql1(6) = New SqlParameter("@BlogImages", lblimg.Value)
    '            'sql1(7) = New SqlParameter("@DatePosted", dtaddmore.Rows(i)("DatePosted").ToString())
    '            'sql1(8) = New SqlParameter("@Ispopular", dtaddmore.Rows(i)("Ispopular").ToString())
    '            'sql1(9) = New SqlParameter("@BlogTitle", txtblogurl.Text)

    '            HashSoftwares.SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, System.Data.CommandType.StoredProcedure, "usp_update_tblBloglanguage", sql1)
    '        Next
    '    End If



    '    '=======================================================
    '    'Service provided by Telerik (www.telerik.com)
    '    'Conversion powered by NRefactory.
    '    'Twitter: @telerik
    '    'Facebook: facebook.com/telerik
    '    '=======================================================



    'End Sub
End Class
