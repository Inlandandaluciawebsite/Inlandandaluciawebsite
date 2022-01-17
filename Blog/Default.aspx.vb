
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports ASPSnippets.FaceBookAPI
Imports ASPSnippets.GoogleAPI
Imports HashSoftwares

Partial Class Blog_Default
    'Inherits System.Web.UI.Page
    'Inherits System.Web.UI.Page
    Inherits BasePage
    Public language As String
    Public Shared IsSpanish As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FaceBookConnect.API_Key = "1838679733126628"
        FaceBookConnect.API_Secret = "03bad86f236890901d8958c7ed14058a"


        ' Set Session Variables
        If Not Page.IsPostBack Then
            If Not Session("language") = "" Then
                Dim language1 As String = Session("language")
                Select Case language1

                    Case "Spanish"
                        language = "es"


                    Case "French"
                        language = "fr"

                    Case "German"
                        language = "de"

                    Case "Dutch"
                        language = "nl"

                    Case Else
                        language = 1

                End Select
            Else
                language = "en"

            End If
            bindFeaturedProperty()
            bindblogcomments()

            Dim code As String = Request.QueryString("code")
            Dim sql As SqlParameter() = New SqlParameter(2) {}
            If Not String.IsNullOrEmpty(code) Then

                Dim data As String = FaceBookConnect.Fetch(code, "me?fields=name,email")
                ' If Not data = "" Then
                Dim faceBookUser As FaceBookUser = New JavaScriptSerializer().Deserialize(Of FaceBookUser)(data)

                sql(0) = New SqlParameter("@UserName", faceBookUser.UserName)
                sql(1) = New SqlParameter("@Email", faceBookUser.Email)
                Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblUser_Insertfromsocial", sql).Tables(0)
                If dt.Rows.Count > 0 Then
                    Session("UserId") = dt.Rows(0)("UserId").ToString()

                    ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('login successfully');", True)

                Else
                    ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('login detail is incorrect');", True)
                End If
                ' End If


            End If
        End If

        Page.Title = "Inland Andalucia - Blog"

        'Page.MetaDescription = "If you intend buying a property in Spain, whether this be an apartment or house on the coast, a flat in town, a plot of land or country estate."
        'Page.MetaKeywords = "Buying Property Spain"


    End Sub
    Public Class FaceBookUser
        Public Property Id() As String
            Get
                Return m_Id
            End Get
            Set(value As String)
                m_Id = value
            End Set
        End Property
        Private m_Id As String
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(value As String)
                m_Name = value
            End Set
        End Property
        Private m_Name As String
        Public Property UserName() As String
            Get
                Return m_UserName
            End Get
            Set(value As String)
                m_UserName = value
            End Set
        End Property
        Private m_UserName As String
        Public Property PictureUrl() As String
            Get
                Return m_PictureUrl
            End Get
            Set(value As String)
                m_PictureUrl = value
            End Set
        End Property
        Private m_PictureUrl As String
        Public Property Email() As String
            Get
                Return m_Email
            End Get
            Set(value As String)
                m_Email = value
            End Set
        End Property
        Private m_Email As String
    End Class
    Private Sub bindblogcomments()
        ''Throw New NotImplementedException()
        If Not hdblogid.Value = "" Then
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@BlogId", Convert.ToInt32(hdblogid.Value))
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblBlogComment_ShowByBlogId", sql).Tables(0)
            lblcountcomment.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                txtcomment.Text = ""
                rpblogcomment.DataSource = dt
                rpblogcomment.DataBind()
            End If
        End If


    End Sub

    Private Sub bindFeaturedProperty()
        Dim blogtitle As String = TryCast(Page.RouteData.Values("Title"), String)
        Dim title As String = ""
        If Not blogtitle = "" Then
            title = HttpUtility.HtmlDecode(blogtitle).Replace("-", " ")
        End If
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@Title", HttpUtility.HtmlDecode(title))
        sql(1) = New SqlParameter("@lang", language)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblBlogs_Showallbysearch1", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            hdblogid.Value = dt.Rows(0)("BlogId").ToString()
            If Session("language") = "Spanish" And hdblogid.Value = "28" Then
                IsSpanish = True
            Else
                IsSpanish = False
            End If
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object)
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each col As DataColumn In dt.Columns
                    If col.ColumnName = "hashlables" Then
                        dr(col) = ""
                        Dim labels As String() = dr("Label").ToString().Split(",")
                        Dim comma = ""
                        For j As Integer = 0 To labels.Count() - 1
                            If j > 0 Then
                                comma = " , "
                            End If
                            dr(col) = dr(col) + comma + "<a href='/Blog/" + (labels(j).ToString().Replace(" ", "-")) + "'>" + (labels(j)) + "</a> "
                        Next
                    End If
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            frmview.DataSource = dt
            frmview.DataBind()
        End If

    End Sub
    Protected Sub btnpostcomment_Click(sender As Object, e As EventArgs)

        postblogcomment()



    End Sub

    Private Sub postblogcomment()
        If Not (Session("UserId") = "") Then
            Dim sql As SqlParameter() = New SqlParameter(3) {}
            sql(0) = New SqlParameter("@User_Id", Convert.ToInt32(Session("UserId")))
            sql(1) = New SqlParameter("@Blog_Id", Convert.ToInt32(hdblogid.Value))
            sql(2) = New SqlParameter("@Comment", txtcomment.Text)
            SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblBlogComment_Insert", sql)
            ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('Comment Posted successfully!');", True)
            txtcomment.Text = ""
            bindblogcomments()
        Else
            ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('Please login to post on comment!');", True)
            lblchkuser.Text = "notexists"
        End If
    End Sub

    Protected Sub btnlogin_Click(sender As Object, e As EventArgs)
        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@Email", txtEmaillogin.Text)
        sql(1) = New SqlParameter("@Password", txtpasswordlogin.Text)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblUser_Login", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Session("UserId") = dt.Rows(0)("UserId").ToString()
            lblchkuser.Text = ""
            ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('login successfully');", True)
            '  postblogcomment()
        Else
            ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('login detail is incorrect');", True)
        End If
    End Sub
    Protected Sub btnregister_Click(sender As Object, e As EventArgs)
        Dim sql As SqlParameter() = New SqlParameter(4) {}
        sql(0) = New SqlParameter("@Email", txtemailregister.Text)
        sql(1) = New SqlParameter("@Password", txtpasswordregister.Text)
        sql(2) = New SqlParameter("@FirstName", txtfullnameregister.Text)
        sql(3) = New SqlParameter("@LastName", "")

        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblUser_Insert", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Session("UserId") = dt.Rows(0)("UserId").ToString()
            lblchkuser.Text = ""
            '  postblogcomment()
            ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('Register successfully');", True)
        End If

    End Sub
    Protected Sub rpblogcomment_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "reply" Then
            lblchkuser.Text = "reply"
            hdnreply.Value = e.CommandArgument
        End If


    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        If Not (Session("UserId") = "") Then
            Dim sql As SqlParameter() = New SqlParameter(3) {}
            sql(0) = New SqlParameter("@User_Id", Convert.ToInt32(Session("UserId")))
            sql(1) = New SqlParameter("@BlogC_Id", Convert.ToInt32(hdnreply.Value))
            sql(2) = New SqlParameter("@Comment", txtreplycomment.Text)
            SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_tblBlogCommentReply_Insert", sql)
            ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('Comment Posted successfully!');", True)
            txtreplycomment.Text = ""
            lblchkuser.Text = ""
            bindblogcomments()
        Else
            lblchkuser.Text = "notexistsblogcomment"
            ClientScript.RegisterStartupScript(GetType(Page), "test", "bootbox.alert('Please login to reply on comment!');", True)
        End If
    End Sub
    Protected Sub rpblogcomment_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then

            Dim countreply As Literal = DirectCast(e.Item.FindControl("lblcount"), Literal)
            Dim Blogcomment As HiddenField = DirectCast(e.Item.FindControl("blogcid"), HiddenField)
            Dim innerRepeater As Repeater = DirectCast(e.Item.FindControl("rpslider2"), Repeater)
            Dim sql As SqlParameter() = New SqlParameter(1) {}
            sql(0) = New SqlParameter("@Bc_Id", Convert.ToInt32(Blogcomment.Value))
            Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_BlogCommentReply_showbyBc_Id", sql).Tables(0)

            countreply.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                innerRepeater.DataSource = dt
                innerRepeater.DataBind()
            End If

        End If

    End Sub
    Protected Sub lblloginwithfb_Click(sender As Object, e As EventArgs)
        FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split("?"c)(0))
    End Sub
    'Protected Sub lblloginwithgoogle_Click(sender As Object, e As EventArgs)
    '    GoogleConnect.Authorize("profile", "email")

    'End Sub
End Class
