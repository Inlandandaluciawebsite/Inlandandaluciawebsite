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


Partial Class AdminNew_Property_Features
    Inherits System.Web.UI.Page
    Dim CDataAccess As New ClassDataAccess
    Dim CUtilities As New ClassUtilities

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
            LoadFeatures()
        End If
    End Sub
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
    Public Sub LoadFeatures()
        chklstFeatures.DataSource = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Features_Select_All").Tables(0)
        chklstFeatures.DataTextField = "Feature"
        chklstFeatures.DataValueField = "Features_Id"
        chklstFeatures.DataBind()

        Dim sqlpropertyfeatures As SqlParameter() = New SqlParameter(0) {}
        sqlpropertyfeatures(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString())

        Dim dtPropertyFeatures As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Features_Select_By_PropertyRef", sqlpropertyfeatures).Tables(0)

        If dtPropertyFeatures.Rows.Count > 0 Then

            For dbPropertyFeatureIndex = 0 To dtPropertyFeatures.Rows.Count - 1
                For featureIndex = 0 To chklstFeatures.Items.Count - 1
                    If dtPropertyFeatures.Rows(dbPropertyFeatureIndex)("Features_ID").ToString() = chklstFeatures.Items(featureIndex).Value Then
                        chklstFeatures.Items(featureIndex).Selected = True
                    End If
                Next
            Next
        End If
    End Sub
    Protected Sub btnfeater_Click(sender As Object, e As EventArgs)
        'first delete all property features by calling delete method & then insert all selected
        Dim sql As SqlParameter() = New SqlParameter(0) {}
        sql(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString())
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Features_Delete_By_PropertyRef", sql)
        'insert all selected property features
        For Each Item In chklstFeatures.Items
            If Item.Selected = True Then
                Dim sqlInsertFeatures As SqlParameter() = New SqlParameter(1) {}
                sqlInsertFeatures(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString())
                sqlInsertFeatures(1) = New SqlParameter("@Features_ID", Item.Value)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Features_Insert", sqlInsertFeatures)
            End If
        Next
        lblfeatuer.Text = "Property Features Saved Successfully !"
        lblMessageTop.Text = "Property Features Saved Successfully !"
        lblMessageTop.ForeColor = System.Drawing.Color.Green
        lblfeatuer.ForeColor = System.Drawing.Color.Green
    End Sub
End Class
