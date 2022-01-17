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


Partial Class AdminNew_Property_History
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
            ' Populate History Types
            CUtilities.PopulateDropDownList(DropDownListHistoryType, CDataAccess.PropertyHistoryTypes)
            ' Add None
            DropDownListHistoryType.Items.Insert(0, "--- Select ---")
            LoadHistory()
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
    Private Sub LoadHistory()

        ' If Session not Expired
        If Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Login Page
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Load up Previous History
            GridViewList.DataSource = CDataAccess.PropertyHistoryAbbrev(CDataAccess.PropertyIARef(Convert.ToInt32(Session("ContactPartnerID")), Request.QueryString("PropertyRef").ToString()), 75, Convert.ToBoolean(Session("AdminUser")))
            GridViewList.DataBind()

            ' Tidy
            CDataAccess = Nothing

            ' Hide the ID & Archive Flags
            If Not GridViewList.HeaderRow Is Nothing Then
                GridViewList.HeaderRow.Cells(1).Visible = False
                GridViewList.HeaderRow.Cells(6).Visible = False
                'GridViewList.HeaderRow.Cells(7).Visible = False
                For Each gvr As GridViewRow In GridViewList.Rows
                    gvr.Cells(1).Visible = False
                    gvr.Cells(6).Visible = False

                    ' If this is Archived, Make Gray
                    If gvr.Cells(6).Text = "Yes" Then
                        gvr.BackColor = Drawing.Color.LightGray
                    End If

                Next
            End If

            ' Reset History Type
            DropDownListHistoryType.SelectedIndex = 0

            ' Hide Buyer
            TableRowSoldTo.Visible = False

            ' Clear Add Notes
            TextBoxAddHistory.Text = String.Empty

        End If

        Dim sql As SqlParameter() = New SqlParameter(2) {}
        sql(0) = New SqlParameter("@property_id", Convert.ToInt32(Request.QueryString("PropertyId").ToString()))
        sql(1) = New SqlParameter("@PartnerId", Convert.ToInt32(Session("ContactPartnerID")))
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "Usp_Property_SelectByPropertyId", sql).Tables(0)
        If dt.Rows.Count > 0 Then
            lblpropref.Text = dt.Rows(0)("Property_Ref").ToString()
            'Binding History Header Values
            lblHistoryPropReference.Text = dt.Rows(0)("Property_Ref").ToString()
            lblHistoryDateCreated.Text = dt.Rows(0)("Create_Date").ToString()
            lblHistoryDateModified.Text = dt.Rows(0)("Last_Modified").ToString()
            lblHistoryPublicPrice.Text = dt.Rows(0)("public_price").ToString()
            lblHistoryOriginalPrice.Text = dt.Rows(0)("original_price").ToString()
            lblHistoryVendorPrice.Text = dt.Rows(0)("vendor_price").ToString()
            lblHistoryVendorName.Text = dt.Rows(0)("VendorName").ToString()
            lblHistoryVendorEmail.Text = dt.Rows(0)("VendorEmail").ToString()
            lblHistoryVendorTelephone.Text = dt.Rows(0)("VendorPhone").ToString()
            lblHistoryViews.Text = dt.Rows(0)("Viewed").ToString()
            lblHistoryToured.Text = dt.Rows(0)("Toured").ToString()
            If Convert.ToInt32(lblHistoryToured.Text) = 0 Then
                DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("19"))
                DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("20"))
                DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("21"))
                DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("22"))
                DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("23"))
                DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("24"))
                DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("25"))
                DropDownListHistoryType.Items.Remove(DropDownListHistoryType.Items.FindByValue("26"))
            End If
            lblTotalEnquries.Text = dt.Rows(0)("Total_Enquriries").ToString()
            hdnPropertyStatus.Value = dt.Rows(0)("status_id").ToString()
            hdnPropertyStatusText.Value = dt.Rows(0)("StatusText").ToString()
            ''''''''''''''''''''''''''''''
            ' Load the Last People who Viewed this Property on a Tour in Date Descending Order
            CUtilities.PopulateDropDownList(DropDownListBuyer, CDataAccess.PropertyLastTouredBuyers(Convert.ToInt32(Request.QueryString("PropertyId").ToString())))
            Dim dtBuyerDetails As DataTable
            Dim query As String = "select ltrim(rtrim(Buyer_Forename)) + ' ' + ltrim(rtrim(Buyer_Surname)) 'Buyer',Buyer_Id From buyer where Buyer_Id in(select top 1 Buyer_Id from  tblPaypalTransactions where PropertyRef='" & lblpropref.Text & "' order by PaypalTransactionId Desc)"
            dtBuyerDetails = CDataAccess.GetDataAsDataTable(query)
            If dtBuyerDetails.Rows.Count > 0 Then
                Dim liBuyer As ListItem
                liBuyer = New ListItem(dtBuyerDetails.Rows(0)("Buyer").ToString(), dtBuyerDetails.Rows(0)("Buyer_Id").ToString())
                DropDownListBuyer.Items.Add(liBuyer)
                DropDownListBuyer.SelectedValue = liBuyer.Value
            End If
            '' If this List COntains the Buyer
            If DropDownListBuyer.Items.Contains(DropDownListBuyer.Items.FindByValue(Convert.ToInt32(dt.Rows(0)("buyer_id").ToString()))) Then
                ' Select this Item
                DropDownListBuyer.SelectedValue = Convert.ToInt32(dt.Rows(0)("buyer_id").ToString())
            End If
        End If
    End Sub
    Protected Sub btnhistory_Click(sender As Object, e As EventArgs)

        'Get property vendor price

        Dim HistoryTypeId As Int32 = Convert.ToInt32(DropDownListHistoryType.SelectedValue)
        If HistoryTypeId = 2 Then
            If rbtReduceYes.Checked Then
                If txtReduceFrom.Text = "" Then
                    'Page.RegisterStartupScript("script", "<script language='javascript'>alert('Please input Reduce From Price !');</script>")
                    'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('Please input Reduce From Price !');</script>", True)
                    lblhistorymsg.Text = "Please input Reduce From Price !"
                    lblhistorymsg.ForeColor = System.Drawing.Color.Red
                    Return
                End If
                If txtReduceTo.Text = "" Then
                    'Page.RegisterStartupScript("script", "<script language='javascript'>alert('Please input Reduce To Price !');</script>")
                    'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('Please input Reduce To Price !');</script>", True)
                    lblhistorymsg.Text = "Please input Reduce To Price !"
                    lblhistorymsg.ForeColor = System.Drawing.Color.Red
                    Return
                End If
                If txtReduceTo.Text <> "" And txtReduceFrom.Text <> "" Then
                    If Convert.ToInt32(txtReduceTo.Text) >= Convert.ToInt32(txtReduceFrom.Text) Then
                        'Page.RegisterStartupScript("script", "<script language='javascript'>alert('To Price should be less than From Price !');</script>")
                        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('To Price should be less than From Price !');</script>", True)
                        lblhistorymsg.Text = "To Price should be less than From Price !"
                        lblhistorymsg.ForeColor = System.Drawing.Color.Red
                        Return
                    End If
                End If
                'Check property to price is same as property price we have in property table
                Dim CProperty2 As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))
                CProperty2.Load(Convert.ToInt32(Request.QueryString("PropertyId").ToString()))

                If CProperty2.VendorPrice.ToString() <> "" Then
                    Dim existingVendorPrice As Int32 = Convert.ToInt32(CProperty2.VendorPrice)
                    Dim newVendorPrice As Int32 = Convert.ToInt32(txtReduceTo.Text)
                    If existingVendorPrice <> newVendorPrice Then
                        'Page.RegisterStartupScript("script", "<script language='javascript'>alert('Reduce To Price is not same as per property vendor price !');</script>")
                        'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('Reduce To Price is not same as per property vendor price, it should be same as vendor price !');</script>", True)
                        lblhistorymsg.Text = "Reduce To Price is not same as per property vendor price, it should be same as vendor price !"
                        lblhistorymsg.ForeColor = System.Drawing.Color.Red
                        Return
                    End If
                Else
                    'Page.RegisterStartupScript("script", "<script language='javascript'>alert('Please first set vendor price for this property, vendor price is blank !');</script>")
                    'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "<script language='javascript'>alert('Please first set vendor price for this property, vendor price is blank !');</script>", True)
                    lblhistorymsg.Text = "Please first set vendor price for this property, vendor price is blank !"
                    lblhistorymsg.ForeColor = System.Drawing.Color.Red
                    Return
                End If
            End If
        End If

        Dim CProperty As New ClassProperty(Convert.ToInt32(Session("ContactPartnerID")))
        CProperty.Load(Convert.ToInt32(Request.QueryString("PropertyId").ToString()))
        Dim bError As Boolean
        bError = PopulateSaveDataHistory(CProperty)
        If Not bError Then
            ' Save this Property to the Database
            'bError = CProperty.Save(Convert.ToInt32(Session("ContactID")), Convert.ToInt32(Session("ContactPartnerID")))

            Dim szSQL As String = ""
            Dim History As String = TextBoxAddHistory.Text.Trim
            Dim Reference As String = lblpropref.Text
            Dim nUserID As Int32 = Convert.ToInt32(Session("ContactID"))
            History = History.Replace("<", "< ")
            History = History.Replace(">", " >")
            If History.Trim <> String.Empty Then

                'check if the same record already exists in the table
            Dim dt_property_history_latest_Record As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_Check_Latest_Property_History_Record").Tables(0)
                If dt_property_history_latest_Record.Rows.Count > 0 Then
                    Dim lr_property_ref As String = dt_property_history_latest_Record.Rows(0)("Property_Ref").ToString()
                    Dim lr_Type_Id As String = dt_property_history_latest_Record.Rows(0)("Type_Id").ToString()
                    Dim lr_Modified_By As String = dt_property_history_latest_Record.Rows(0)("Modified_By").ToString()
                    Dim lr_History_Text As String = dt_property_history_latest_Record.Rows(0)("History_Text").ToString()
                    If lr_property_ref.Trim.ToUpper = Reference.Trim.ToUpper And lr_Type_Id = HistoryTypeId.ToString.Trim And lr_Modified_By = nUserID.ToString.Trim And lr_History_Text = History.Replace("'", "''").Trim Then
                    Else
                        ' Insert the Notes
                        szSQL = "insert into property_history " &
                            "(" &
                                "property_ref, " &
                                "type_id, " &
                                "history_text, " &
                                "modified_by" &
                            ") " &
                            "values " &
                            "(" &
                                "'" & Reference.Trim.ToUpper & "', " &
                                HistoryTypeId.ToString.Trim & ", " &
                                "'" & History.Replace("'", "''").Trim & "', " &
                                nUserID.ToString.Trim &
                            ")"

                        ' Run the Update
                        bError = CDataAccess.Execute(szSQL)

                        'Update last modified date of property table
                        Dim sqlUpdateLastModified As SqlParameter() = New SqlParameter(1) {}

                        sqlUpdateLastModified(0) = New SqlParameter("@Property_Ref", lblpropref.Text)
                        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_LastModified", sqlUpdateLastModified)


                        ' If this is Sold
                        If DropDownListHistoryType.Items.FindByValue("4").Selected Then

                            ' Save the Buyer
                            Dim Buyer_Id As Int32 = DropDownListBuyer.SelectedValue

                            'Update property table call related procedure to update only buyer id & status id

                            Dim sqlUpdateProperty As SqlParameter() = New SqlParameter(3) {}

                            sqlUpdateProperty(0) = New SqlParameter("@Status_Id", 5)
                            sqlUpdateProperty(1) = New SqlParameter("@Buyer_Id", Buyer_Id)
                            sqlUpdateProperty(2) = New SqlParameter("@Property_Ref", lblpropref.Text)
                            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_Buyer_And_Status", sqlUpdateProperty)

                            'Send email notification after sold to 
                            If hdnPropertyStatus.Value <> DropDownListHistoryType.SelectedValue Then
                                Dim dtListerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "select contact_email from contact where contact_id in(select Listed_By_Contact_Id from property where Property_Ref='" & lblpropref.Text & "')").Tables(0)
                                Dim listerEmail As String = ""
                                If dtListerDetails.Rows.Count > 0 Then
                                    listerEmail = dtListerDetails.Rows(0)("contact_email").ToString()
                                End If

                                'Status been changed so send email accordingly & save in property history table
                                Dim mailTitleStatusChange As String
                                Dim mailBodyStatusChange As String = "Property Status been changed for Property Reference " & lblpropref.Text & "  From " & hdnPropertyStatusText.Value & " To " & DropDownListHistoryType.SelectedItem.Text
                                mailBodyStatusChange = mailBodyStatusChange & "<br/><br/>"
                                mailTitleStatusChange = "Property Reference " & lblpropref.Text & " Property Status is now " & DropDownListHistoryType.SelectedItem.Text
                                Try
                                    ' Define a New Email
                                    Dim CEmailStatusChange As New ClassEmail
                                    Dim isDevORTraining2 As Int16 = 0
                                    If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                        mailBodyStatusChange = mailBodyStatusChange & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                                        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListHistoryType.SelectedItem.Text, "Dev", 1)
                                        isDevORTraining2 = 1
                                    End If
                                    If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                        mailBodyStatusChange = mailBodyStatusChange & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                                        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListHistoryType.SelectedItem.Text, "Training", 1)
                                        isDevORTraining2 = 1
                                    End If
                                    If isDevORTraining2 = 0 Then
                                        mailBodyStatusChange = mailBodyStatusChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                                        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListHistoryType.SelectedItem.Text, "Live", 1)
                                    End If

                                Catch ex As Exception

                                End Try
                            End If

                        End If

                        ' If this is Sold
                        If DropDownListHistoryType.Items.FindByValue("29").Selected Then

                            ' Save the Buyer
                            Dim Buyer_Id As Int32 = DropDownListBuyer.SelectedValue

                            'Update property table call related procedure to update only buyer id & status id

                            Dim sqlUpdateProperty As SqlParameter() = New SqlParameter(3) {}

                            sqlUpdateProperty(0) = New SqlParameter("@Status_Id", 7)
                            sqlUpdateProperty(1) = New SqlParameter("@Buyer_Id", Buyer_Id)
                            sqlUpdateProperty(2) = New SqlParameter("@Property_Ref", lblpropref.Text)
                            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_Update_Buyer_And_Status", sqlUpdateProperty)

                            'Send email notification after sold to 
                            If hdnPropertyStatus.Value <> DropDownListHistoryType.SelectedValue Then
                                Dim dtListerDetails As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.Text, "select contact_email from contact where contact_id in(select Listed_By_Contact_Id from property where Property_Ref='" & lblpropref.Text & "')").Tables(0)
                                Dim listerEmail As String = ""
                                If dtListerDetails.Rows.Count > 0 Then
                                    listerEmail = dtListerDetails.Rows(0)("contact_email").ToString()
                                End If

                                'Status been changed so send email accordingly & save in property history table
                                Dim mailTitleStatusChange As String
                                Dim mailBodyStatusChange As String = "Property Status been changed for Property Reference " & lblpropref.Text & "  From " & hdnPropertyStatusText.Value & " To " & DropDownListHistoryType.SelectedItem.Text
                                mailBodyStatusChange = mailBodyStatusChange & "<br/><br/>"
                                mailTitleStatusChange = "Property Reference " & lblpropref.Text & " Property Status is now " & DropDownListHistoryType.SelectedItem.Text
                                Try
                                    ' Define a New Email
                                    Dim CEmailStatusChange As New ClassEmail
                                    Dim isDevORTraining2 As Int16 = 0
                                    If Page.Request.Url.AbsoluteUri.Contains("dev.inlandandalucia.com") Then
                                        mailBodyStatusChange = mailBodyStatusChange & "<a href='dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>dev.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                                        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListHistoryType.SelectedItem.Text, "Dev", 1)
                                        isDevORTraining2 = 1
                                    End If
                                    If Page.Request.Url.AbsoluteUri.Contains("training.inlandandalucia.com") Then
                                        mailBodyStatusChange = mailBodyStatusChange & "<a href='training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>training.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                                        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListHistoryType.SelectedItem.Text, "Training", 1)
                                        isDevORTraining2 = 1
                                    End If
                                    If isDevORTraining2 = 0 Then
                                        mailBodyStatusChange = mailBodyStatusChange & "<a href='www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "' target='blank'>www.inlandandalucia.com/propsearch.aspx?propertyref=" & lblpropref.Text & "</a>"
                                        CEmailStatusChange.SendEmail_Notification_Single_Fuction(mailTitleStatusChange, mailBodyStatusChange, CProperty.PartnerID, listerEmail, DropDownListHistoryType.SelectedItem.Text, "Live", 1)
                                    End If

                                Catch ex As Exception

                                End Try
                            End If

                        End If
                    End If
                End If
            End If
            If TextBoxAddHistory.Text = "" Then
                lblhistorymsg.Text = "Please input history text..."
                lblhistorymsg.ForeColor = System.Drawing.Color.Red
                Return
            Else

                lblhistorymsg.Text = "Property Details Saved"
                lblhistorymsg.ForeColor = System.Drawing.Color.Black
            End If



            ' If we had an Error
            If bError Then
                lblhistorymsg.Text = "There is something wrong, please try again !"
            Else
                'Update old price, new price, price changed fields of property history

                If HistoryTypeId = 2 Then

                    Dim sql As SqlParameter() = New SqlParameter(4) {}

                    Dim PriceChanged As Int32 = 0

                    If rbtReduceYes.Checked Then
                        sql(0) = New SqlParameter("@OldPrice", Convert.ToInt32(txtReduceFrom.Text))
                        sql(1) = New SqlParameter("@NewPrice", Convert.ToInt32(txtReduceTo.Text))
                        PriceChanged = 1
                    End If

                    If rbtReduceNo.Checked Then
                        sql(0) = New SqlParameter("@OldPrice", Convert.ToInt32(0))
                        sql(1) = New SqlParameter("@NewPrice", Convert.ToInt32(0))
                        PriceChanged = 0
                    End If

                    If rbtReduceDontWant.Checked Then
                        sql(0) = New SqlParameter("@OldPrice", Convert.ToInt32(0))
                        sql(1) = New SqlParameter("@NewPrice", Convert.ToInt32(0))
                        PriceChanged = 2
                    End If

                    sql(2) = New SqlParameter("@PriceChanged", PriceChanged)
                    sql(3) = New SqlParameter("@Property_Ref", CProperty.Reference)
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings("IA").ConnectionString, CommandType.StoredProcedure, "USP_Property_History_Price_Update", sql)
                End If

                divOwnerCallRow.Visible = False
                txtReduceFrom.Text = ""
                txtReduceTo.Text = ""
            End If
        End If
        LoadHistory()
    End Sub
    Private Function GetFormInteger(ByVal szEntry As String) As Integer

        If szEntry.Trim = String.Empty Or szEntry = "--- Select ---" Or szEntry = "--- None ---" Then
            Return 0
        Else
            Return Convert.ToInt32(szEntry.Trim)
        End If

    End Function
    Private Function PopulateSaveDataHistory(ByRef CProperty As ClassProperty) As Boolean

        Try

            ' If we have History Notes, Add
            CProperty.History = TextBoxAddHistory.Text.Trim

            ' If the History Type Record was set
            If DropDownListHistoryType.SelectedIndex > 0 Then

                ' Save this
                CProperty.HistoryTypeID = DropDownListHistoryType.SelectedValue

                ' If this is Sold
                If DropDownListHistoryType.Items.FindByValue("4").Selected Then

                    ' Set the Property Status to Sold
                    'DropDownListStatus.SelectedValue = 5

                    ' Don't Display or Feature this Property
                    'CheckBoxDisplay.Checked = False
                    'CheckBoxFeature.Checked = False

                    ' Save the Buyer
                    CProperty.BuyerID = DropDownListBuyer.SelectedValue

                    ' If we don't have a Description
                    If CProperty.History.Trim = String.Empty Then

                        ' Add Default
                        CProperty.History = "Sold to " & DropDownListBuyer.SelectedItem.Text.Trim
                        TextBoxHistory.Text = "Sold to " & DropDownListBuyer.SelectedItem.Text.Trim
                    End If

                End If

            Else

                ' No History Type Selected
                CProperty.HistoryTypeID = 0

            End If

            Return False

        Catch ex As Exception
            Return True
        End Try

    End Function
    Public Sub SendExpiryEmails(ByVal EmailTitle As String, ByVal EmailBody As String)
        Try
            Dim CEmailAdmin As New ClassEmail
            'CEmailAdmin.SendEmail("info@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("jerome@inlandandalucia.com", EmailTitle, EmailBody, True, Nothing, False)
            'CEmailAdmin.SendEmail("lee@inlandandalucia.com", SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            'CEmailAdmin.SendEmail(SalesPersonEmail, SubjectToAdmin, ContentToAdmin, True, Nothing, False)
            CEmailAdmin.SendEmail("sourabhodesk@gmail.com", EmailTitle, EmailBody, True, Nothing, False)
            CEmailAdmin = Nothing
        Catch ex As Exception
            'lblError.Text = ex.InnerException.ToString()
        End Try
    End Sub
    Protected Sub rbtReduceYes_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxAddHistory.Text = ""
        txtReduceFrom.Text = ""
        txtReduceTo.Text = ""
        divReducePriceFromTo.Visible = True
        TextBoxAddHistory.Visible = True
    End Sub
    Protected Sub rbtReduceNo_CheckedChanged(sender As Object, e As EventArgs)
        divReducePriceFromTo.Visible = False
        TextBoxAddHistory.Text = ""
        TextBoxAddHistory.Visible = True
    End Sub
    Protected Sub rbtReduceDontWant_CheckedChanged(sender As Object, e As EventArgs)
        TextBoxAddHistory.Text = "Vendor didn't want to reduce the price"
        divReducePriceFromTo.Visible = False
        TextBoxAddHistory.Visible = True
    End Sub
    Protected Sub txtReduceTo_TextChanged(sender As Object, e As EventArgs)
        TextBoxAddHistory.Text = "Vendor's price reduced from " & txtReduceFrom.Text & " to " & txtReduceTo.Text
    End Sub
    Protected Sub GridViewList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewList.SelectedIndexChanged

        ' Local Vars
        Dim CDataAccess As New ClassDataAccess
        Dim dvRow As GridViewRow = GridViewList.SelectedRow

        ' Load the History
        TextBoxHistory.Text = CDataAccess.PropertyHistory(Convert.ToInt32(dvRow.Cells(1).Text))

        ' Make the Note Visible
        TableRowHistoryElement.Visible = True

        ' Make the Archive Visible only if Admin
        TableRowHistoryArchive.Visible = Convert.ToBoolean(Session("AdminUser"))

        ' Set the Button Text
        If dvRow.Cells(6).Text.Trim = "No" Then

            ' Currently Active
            ButtonArchiveHistory.Text = "Archive"

        Else

            ' Currently Archived
            ButtonArchiveHistory.Text = "Restore"

        End If

        ' Tidy
        CDataAccess = Nothing

    End Sub
    Protected Sub ButtonArchiveHistory_Click(sender As Object, e As EventArgs) Handles ButtonArchiveHistory.Click

        ' Only do this if we have a History Item Selected
        If GridViewList.SelectedIndex > -1 Then

            ' Archive / Restore Record
            Dim CDataAccess As New ClassDataAccess
            CDataAccess.PropertyHistoryArchiveRecord(Convert.ToInt32(GridViewList.SelectedRow.Cells(1).Text.Trim), GridViewList.SelectedRow.Cells(6).Text.Trim = "No")
            CDataAccess = Nothing

            ' Update Interface
            If GridViewList.SelectedRow.Cells(6).Text = "Yes" Then

                ' Update Flag
                GridViewList.SelectedRow.Cells(6).Text = "No"

                ' Update Colour
                GridViewList.SelectedRow.BackColor = Nothing

            Else

                ' Update Flag
                GridViewList.SelectedRow.Cells(6).Text = "Yes"

                ' Update Colour
                GridViewList.SelectedRow.BackColor = Drawing.Color.LightGray

            End If

        End If
        TableRowHistoryElement.Visible = False
        TableRowHistoryArchive.Visible = False
    End Sub
    Protected Sub DropDownListHistoryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListHistoryType.SelectedIndexChanged
        divOwnerCallRow.Visible = False
        ' Local Vars
        Dim bDirty As Boolean = True

        ' Set Sold To Invisible
        TableRowSoldTo.Visible = False

        ' If this is set to Sold
        If DropDownListHistoryType.SelectedValue = 4 Then
            ' If we don't have any Viewers
            If DropDownListBuyer.Items.Count < 1 Then

                ' Inform the User of the Problem

                ' Create Message Array
                Dim alMessage As New ArrayList

                ' Create the Message
                alMessage.Add("This property has not yet been toured so no potential buyers exist")
                lblhistorymsg.Text = "This property has not yet been toured so no potential buyers exist"
                ' Tidy
                alMessage.Clear()
                alMessage = Nothing

                ' Reset
                DropDownListHistoryType.SelectedIndex = 0

                ' Mark as not Dirty
                bDirty = False

            Else

                ' Set Sold To Visible
                TableRowSoldTo.Visible = True
                TextBoxAddHistory.Text = "Sold to " & DropDownListBuyer.SelectedItem.Text.Trim

            End If
        End If

        ' If this is set to Sold
        If DropDownListHistoryType.SelectedValue = 29 Then
            ' If we don't have any Viewers
            If DropDownListBuyer.Items.Count < 1 Then

                ' Inform the User of the Problem

                ' Create Message Array
                Dim alMessage As New ArrayList

                ' Create the Message
                alMessage.Add("This property has not yet been toured so no potential buyers exist")
                lblhistorymsg.Text = "This property has not yet been toured so no potential buyers exist"
                ' Tidy
                alMessage.Clear()
                alMessage = Nothing

                ' Reset
                DropDownListHistoryType.SelectedIndex = 0

                ' Mark as not Dirty
                bDirty = False

            Else

                ' Set Sold To Visible
                TableRowSoldTo.Visible = True
                TextBoxAddHistory.Text = "This property is now under offer for " & DropDownListBuyer.SelectedItem.Text.Trim

            End If
        End If



        'If this is set to Owner Call
        Try
            If DropDownListHistoryType.SelectedValue = 19 Or DropDownListHistoryType.SelectedValue = 20 Or DropDownListHistoryType.SelectedValue = 21 Or DropDownListHistoryType.SelectedValue = 22 Or DropDownListHistoryType.SelectedValue = 23 Or DropDownListHistoryType.SelectedValue = 24 Or DropDownListHistoryType.SelectedValue = 25 Or DropDownListHistoryType.SelectedValue = 26 Then
                divSubjectTo.Visible = True
                Dim CUtilities As New ClassUtilities
                Dim CDataAccess As New ClassDataAccess
                Dim CProperty As ClassProperty = DirectCast(Session("AdminPropertySelected"), ClassProperty)
                CUtilities.PopulateDropDownList(drpSubjectToBuyer, CDataAccess.PropertyLastTouredBuyers(CProperty.ID))
            Else
                divSubjectTo.Visible = False
            End If

            If DropDownListHistoryType.SelectedValue = 2 Or DropDownListHistoryType.SelectedValue = 17 Or DropDownListHistoryType.SelectedValue = 18 Then
                rbtReduceYes.Checked = False
                rbtReduceNo.Checked = False
                rbtReduceDontWant.Checked = False
                divOwnerCallRow.Visible = True
                TextBoxAddHistory.Visible = False
            Else
                TextBoxAddHistory.Visible = True
            End If
        Catch ex As Exception

        End Try

        If DropDownListHistoryType.SelectedValue <> 4 And DropDownListHistoryType.SelectedValue <> 29 Then
            TextBoxAddHistory.Text = ""
        End If

        ' If Dirty
        If bDirty Then

            ' Make Dirty 
            'MakeDirty()

        End If

    End Sub
    Protected Sub DropDownListBuyer_SelectedIndexChanged(sender As Object, e As EventArgs)
        If DropDownListHistoryType.Items.FindByValue("4").Selected Then
            TextBoxAddHistory.Text = "Sold to " & DropDownListBuyer.SelectedItem.Text.Trim
        End If
        If DropDownListHistoryType.Items.FindByValue("29").Selected Then
            TextBoxAddHistory.Text = "This property is now under offer for " & DropDownListBuyer.SelectedItem.Text.Trim
        End If
    End Sub
End Class
