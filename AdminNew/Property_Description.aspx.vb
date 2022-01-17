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


Partial Class AdminNew_Property_Description
    Inherits System.Web.UI.Page
    Dim CDataAccess As New ClassDataAccess
    Dim CUtilities As New ClassUtilities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ContactID") Is Nothing Then
            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")
        End If
        If Not IsPostBack Then
            lblpropref.Text = Request.QueryString("PropertyRef").ToString()
            CUtilities.PopulateDropDownList(DropDownListLanguage, CDataAccess.Languages(Convert.ToInt32(Session("ContactLanguageID"))))
            Dim sqlDescription As SqlParameter() = New SqlParameter(1) {}
            sqlDescription(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
            sqlDescription(1) = New SqlParameter("@Language_Id", Convert.ToInt32(DropDownListLanguage.SelectedValue))
            Dim dsPropertyDescription As DataSet = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Description_Select", sqlDescription)
            If dsPropertyDescription.Tables(0).Rows.Count > 0 Then
                TextBoxShortDescription.Text = HttpUtility.HtmlDecode(dsPropertyDescription.Tables(0).Rows(0)("ShortDescription").ToString())
            End If
            If dsPropertyDescription.Tables(1).Rows.Count > 0 Then
                TextBoxDescription.Text = HttpUtility.HtmlDecode(dsPropertyDescription.Tables(1).Rows(0)("MainDescription").ToString())
            End If
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
    Protected Sub btndescription_Click(sender As Object, e As EventArgs)
        If TextBoxShortDescription.Text <> "" Then
            If chkAutoTranslateShort.Checked Then
                For Each Item In DropDownListLanguage.Items

                    If Item.Value = DropDownListLanguage.SelectedValue Then
                        'Add/Update Short Description in Prop_Short_Desc table.
                        Dim sqlShortDescription As SqlParameter() = New SqlParameter(3) {}
                        sqlShortDescription(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
                        sqlShortDescription(1) = New SqlParameter("@Language_Id", Convert.ToInt32(DropDownListLanguage.SelectedValue))
                        sqlShortDescription(2) = New SqlParameter("@Text", TextBoxShortDescription.Text)
                        sqlShortDescription(3) = New SqlParameter("@En_Translation", False)
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Short_Desc_Insert", sqlShortDescription)
                    Else
                        'call google api to get language text by passing source and language
                        Dim Text As String = CUtilities.TranslateNew(TextBoxShortDescription.Text.Trim, Item.Value, DropDownListLanguage.SelectedValue)
                        'Add/Update Short Description in Prop_Short_Desc table.
                        Dim sqlShortDescription As SqlParameter() = New SqlParameter(3) {}
                        sqlShortDescription(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
                        sqlShortDescription(1) = New SqlParameter("@Language_Id", Item.Value)
                        sqlShortDescription(2) = New SqlParameter("@Text", Text)
                        sqlShortDescription(3) = New SqlParameter("@En_Translation", False)
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Short_Desc_Insert", sqlShortDescription)
                    End If
                Next
            Else
                'Add/Update Short Description in Prop_Short_Desc table.
                Dim sqlShortDescription As SqlParameter() = New SqlParameter(3) {}
                sqlShortDescription(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
                sqlShortDescription(1) = New SqlParameter("@Language_Id", Convert.ToInt32(DropDownListLanguage.SelectedValue))
                sqlShortDescription(2) = New SqlParameter("@Text", TextBoxShortDescription.Text)
                sqlShortDescription(3) = New SqlParameter("@En_Translation", False)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Short_Desc_Insert", sqlShortDescription)
            End If
        Else
            'Delete all existing entries from property_short_desc
            'Add/Update Short Description in Prop_Short_Desc table.
            Dim sqlShortDescriptionDelete As SqlParameter() = New SqlParameter(3) {}
            sqlShortDescriptionDelete(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Short_Desc_Delete_By_PropertyRef", sqlShortDescriptionDelete)
        End If

        If TextBoxDescription.Text <> "" Then
            If chkAutoTranslateMain.Checked Then
                For Each Item In DropDownListLanguage.Items
                    If Item.Value = DropDownListLanguage.SelectedValue Then
                        'Add/Update Short Description in Prop_Short_Desc table.
                        Dim sqlLongDescription As SqlParameter() = New SqlParameter(3) {}
                        sqlLongDescription(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
                        sqlLongDescription(1) = New SqlParameter("@Language_Id", Convert.ToInt32(DropDownListLanguage.SelectedValue))
                        sqlLongDescription(2) = New SqlParameter("@Text", TextBoxDescription.Text)
                        sqlLongDescription(3) = New SqlParameter("@En_Translation", False)
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Desc_Insert", sqlLongDescription)
                    Else
                        'call google api to get language text by passing source and language
                        Dim Text As String = CUtilities.TranslateNew(TextBoxDescription.Text.Trim, Item.Value, DropDownListLanguage.SelectedValue)

                        'Add/Update Short Description in Prop_Short_Desc table.
                        Dim sqlLongDescription As SqlParameter() = New SqlParameter(3) {}
                        sqlLongDescription(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
                        sqlLongDescription(1) = New SqlParameter("@Language_Id", Item.Value)
                        sqlLongDescription(2) = New SqlParameter("@Text", Text)
                        sqlLongDescription(3) = New SqlParameter("@En_Translation", False)
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Desc_Insert", sqlLongDescription)
                    End If
                Next
            Else
                'Add/Update Short Description in Prop_Short_Desc table.
                Dim sqlLongDescription As SqlParameter() = New SqlParameter(3) {}
                sqlLongDescription(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
                sqlLongDescription(1) = New SqlParameter("@Language_Id", Convert.ToInt32(DropDownListLanguage.SelectedValue))
                sqlLongDescription(2) = New SqlParameter("@Text", TextBoxDescription.Text)
                sqlLongDescription(3) = New SqlParameter("@En_Translation", False)
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Desc_Insert", sqlLongDescription)
            End If
        Else
            'Delete all existing entries from property_desc
            Dim sqlMainDescriptionDelete As SqlParameter() = New SqlParameter(3) {}
            sqlMainDescriptionDelete(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Main_Desc_Delete_By_PropertyRef", sqlMainDescriptionDelete)
        End If

        lbldescmessage.Text = "Property Description Saved !"
        lblMessageTop.Text = "Property Description Saved !"
        lblMessageTop.ForeColor = System.Drawing.Color.Green
        lbldescmessage.ForeColor = System.Drawing.Color.Green
    End Sub
    'Protected Sub ButtonAutoTranslateShort_Click(sender As Object, e As EventArgs)
    '    ' Translating to the Remaining Languages - SHORT DESCRIPTIONS

    '    ' For each Language
    '    For Each lstItem As ListItem In DropDownListLanguage.Items
    '        ' If this is the Selected Language
    '        If lstItem.Selected Then
    '            ' Simply Save Text
    '            DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = TextBoxShortDescription.Text.Trim
    '        Else
    '            ' Translate and Add to the Array
    '            Dim CUtilities As New ClassUtilities
    '            DirectCast(Session("PropertyAdminShortDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = CUtilities.TranslateNew(TextBoxShortDescription.Text.Trim, lstItem.Value, DropDownListLanguage.SelectedValue)
    '            CUtilities = Nothing
    '        End If
    '    Next

    '    ' Make the Save Button Clean
    '    ButtonSaveShortDescription.BackColor = Nothing
    '    ButtonSaveShortDescription.ForeColor = Nothing
    '    ButtonSaveShortDescription.Font.Bold = False

    '    ' Dirty
    '    'MakeDirty()

    '    ' Display Message
    '    LabelMessageShort.Text = "Translations have been Completed"
    '    LabelMessageShort.Visible = True
    'End Sub
    'Protected Sub ButtonAutoTranslate_Click(sender As Object, e As EventArgs)
    '    ' Translating to the Remaining Languages - DESCRIPTIONS

    '    ' For each Language
    '    For Each lstItem As ListItem In DropDownListLanguage.Items

    '        ' If this is the Selected Language
    '        If lstItem.Selected Then

    '            ' Simply Save Text
    '            DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = TextBoxDescription.Text.Trim

    '        Else

    '            ' Translate and Add to the Array
    '            Dim CUtilities As New ClassUtilities
    '            DirectCast(Session("PropertyAdminDescription"), Hashtable)(Convert.ToInt32(lstItem.Value)) = CUtilities.TranslateNew(TextBoxDescription.Text.Trim, lstItem.Value, DropDownListLanguage.SelectedValue)
    '            CUtilities = Nothing

    '        End If

    '    Next

    '    ' Make the Save Button Clean
    '    ButtonSaveDescription.BackColor = Nothing
    '    ButtonSaveDescription.ForeColor = Nothing
    '    ButtonSaveDescription.Font.Bold = False

    '    ' Dirty
    '    ' MakeDirty()

    '    ' Display Message
    '    LabelMessage.Text = "Translations have been Completed"
    '    LabelMessage.Visible = True
    'End Sub
    Protected Sub DropDownListLanguage_SelectedIndexChanged(sender As Object, e As EventArgs)
        TextBoxShortDescription.Text = ""
        TextBoxDescription.Text = ""
        lbldescmessage.Text = ""
        lblMessageTop.Text = ""
        Dim sqlDescription As SqlParameter() = New SqlParameter(1) {}
        sqlDescription(0) = New SqlParameter("@Property_Ref", Request.QueryString("PropertyRef").ToString().ToUpper())
        sqlDescription(1) = New SqlParameter("@Language_Id", Convert.ToInt32(DropDownListLanguage.SelectedValue))
        Dim dsPropertyDescription As DataSet = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Property_Description_Select", sqlDescription)
        If dsPropertyDescription.Tables(0).Rows.Count > 0 Then
            TextBoxShortDescription.Text = HttpUtility.HtmlDecode(dsPropertyDescription.Tables(0).Rows(0)("ShortDescription").ToString())
        End If
        If dsPropertyDescription.Tables(1).Rows.Count > 0 Then
            TextBoxDescription.Text = HttpUtility.HtmlDecode(dsPropertyDescription.Tables(1).Rows(0)("MainDescription").ToString())
        End If
    End Sub
End Class
