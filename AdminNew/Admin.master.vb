Imports System.Data
Imports System.Data.SqlClient
Imports HashSoftwares
Imports System.IO

Partial Class Admin_Admin
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Redirect("https://inlandandalucia.com/Under_Construction/index.html")

        If Session("ContactID") Is Nothing Then

            Response.Redirect("/AgentLogin.aspx")
        Else

            lblUserName.Text = Session("ContactName").ToString()
        End If


        If Not IsPostBack Then
            If Convert.ToInt32(Session("ContactType")) = 2 Then
                sidemenu.Style.Add(HtmlTextWriterStyle.Display, "none")
                ulblogger.Style.Add(HtmlTextWriterStyle.Display, "none")
            Else
                sidemenu.Style.Add(HtmlTextWriterStyle.Display, "block")
                ulblogger.Style.Add(HtmlTextWriterStyle.Display, "none")
            End If
            If Convert.ToInt32(Session("ContactType")) = 4 And Convert.ToInt32(Session("AdminUser")) = 1 Then
                licontroler.Style.Add(HtmlTextWriterStyle.Display, "block")
                lionlinemagazine.Style.Add(HtmlTextWriterStyle.Display, "block")
                liBlogs.Style.Add(HtmlTextWriterStyle.Display, "block")
                liManageBlogger.Style.Add(HtmlTextWriterStyle.Display, "block")
                liViewAll.Style.Add(HtmlTextWriterStyle.Display, "none")
            ElseIf Convert.ToInt32(Session("ContactType")) = 9 Then
                sidemenu.Style.Add(HtmlTextWriterStyle.Display, "none")
                ulblogger.Style.Add(HtmlTextWriterStyle.Display, "block")
                'lionlinemagazine.Style.Add(HtmlTextWriterStyle.Display, "none")
                'liBlogs.Style.Add(HtmlTextWriterStyle.Display, "block")
                'liManageBlogger.Style.Add(HtmlTextWriterStyle.Display, "none")
            Else
                licontroler.Style.Add(HtmlTextWriterStyle.Display, "none")
                lionlinemagazine.Style.Add(HtmlTextWriterStyle.Display, "none")
                liBlogs.Style.Add(HtmlTextWriterStyle.Display, "none")
                liManageBlogger.Style.Add(HtmlTextWriterStyle.Display, "none")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Index.aspx") Then
                liDashboard.Attributes.Add("class", "active open ")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("AddVendor.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lbladdvendor.Text = "Edit Vendor"
                Else
                    lbladdvendor.Text = "Add Vendor"
                End If

                sVendor.Attributes.Add("class", "arrow open")
                liVendor.Attributes.Add("class", "active open")
                liAddVendor.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ManageVendors.aspx") Then
                sVendor.Attributes.Add("class", "arrow open")
                liVendor.Attributes.Add("class", "active open")
                liManageVendors.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("AddProperty.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddProperty.Text = "Edit Property"
                Else
                    lblAddProperty.Text = "Add Property"
                End If
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liaddproperty.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Property_General.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddProperty.Text = "Edit Property"
                Else
                    lblAddProperty.Text = "Add Property"
                End If
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liaddproperty.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Property_Description.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddProperty.Text = "Edit Property"
                Else
                    lblAddProperty.Text = "Add Property"
                End If
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liaddproperty.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Property_Features.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddProperty.Text = "Edit Property"
                Else
                    lblAddProperty.Text = "Add Property"
                End If
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liaddproperty.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Property_History.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddProperty.Text = "Edit Property"
                Else
                    lblAddProperty.Text = "Add Property"
                End If
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liaddproperty.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Property_Images.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddProperty.Text = "Edit Property"
                Else
                    lblAddProperty.Text = "Add Property"
                End If
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liaddproperty.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Property_Documents.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddProperty.Text = "Edit Property"
                Else
                    lblAddProperty.Text = "Add Property"
                End If
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liaddproperty.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("LatestProperties.aspx") Then
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liLatest.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("FeaturedProperties.aspx") Then
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liFeatured.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ManageProperties.aspx") And Page.Request.QueryString("ViewAll") Is Nothing Then
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liManageProperties.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Not Page.Request.QueryString("ViewAll") Is Nothing Then
                sproperty.Attributes.Add("class", "arrow open")
                liproperty.Attributes.Add("class", "active open")
                liViewAll.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("FranchiseRequests.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liparnter.Attributes.Add("class", "active open")
                liFranchiseRequests.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("FranchiseHistory.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liparnter.Attributes.Add("class", "active open")
                liFranchiseRequests.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If

            If Page.Request.Url.AbsoluteUri.Contains("AddAgent.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddFranchise.Text = "Edit Agent"
                Else
                    lblAddFranchise.Text = "Add Agent"
                End If
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liAgent.Attributes.Add("class", "active open")
                liAddAgent.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ManageAgents.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liAgent.Attributes.Add("class", "active open")
                liManageAgents.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("AddBroker.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddBroker.Text = "Edit Broker"
                Else
                    lblAddBroker.Text = "Add Broker"
                End If
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                librokers.Attributes.Add("class", "active open")
                liaddbroker.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ManageBroker.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                librokers.Attributes.Add("class", "active open")
                limanagebroker.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("BuyerSource.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liBuyers.Attributes.Add("class", "active open")
                lisource.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("BuyerStatus.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liBuyers.Attributes.Add("class", "active open")
                listatus.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("BrokerList.aspx") Then
                spBrokerList.Attributes.Add("class", "arrow open")
                liuserBrokers.Attributes.Add("class", "active open")
                liuserBrokerslist.Attributes.Add("class", "active open")
                ''   liBuyers.Attributes.Add("class", "active open")
                listatus.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ContactType.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                ' liBuyers.Attributes.Add("class", "active open")
                licontacttype.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("DatabaseStatistics.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                '  liBuyers.Attributes.Add("class", "active open")
                lidatabasestatus.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("HistoryType.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                '   liBuyers.Attributes.Add("class", "active open")
                lihistorytype.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Languages.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                'liBuyers.Attributes.Add("class", "active open")
                lilanguage.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Addlawyer.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddLawyer.Text = "Edit Lawyer"
                Else
                    lblAddLawyer.Text = "Add Lawyer"
                End If
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                lilawyers.Attributes.Add("class", "active open")
                liaddlawyer.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Managelawyer.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                lilawyers.Attributes.Add("class", "active open")
                limanagelawyer.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("AddPartner.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddParnter.Text = "Edit Partner"
                Else
                    lblAddParnter.Text = "Add Partner"
                End If
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liparnter.Attributes.Add("class", "active open")
                liaddpartner.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ManagePartner.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liparnter.Attributes.Add("class", "active open")
                limanagepartner.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("PaymentType.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")

                lipayments.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Testinomials.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")

                litestinomials.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("AddUser.aspx") Then
                If Request.QueryString.HasKeys() Then
                    lblAddUser.Text = "Edit User"
                Else
                    lblAddUser.Text = "Add User"
                End If
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liusers.Attributes.Add("class", "active open")
                liadduser.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ManageUser.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liusers.Attributes.Add("class", "active open")
                limanageuser.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Features.aspx") And Not Page.Request.Url.AbsoluteUri.Contains("Property_Features.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                ' lisystable.Attributes.Add("class", "active open")
                lipropertytypes.Attributes.Add("class", "active open")
                lifeatures.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Criterias.aspx") And Not Page.Request.Url.AbsoluteUri.Contains("BuyerCriterias.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lipropertytypes.Attributes.Add("class", "active open")
                liCriterias.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("BuyerCriterias.aspx") Then
                spclient.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                liclients.Attributes.Add("class", "active open")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Location.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                ' lisystable.Attributes.Add("class", "active open")
                lipropertytypes.Attributes.Add("class", "active open")
                lilocation.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("PropertyStatus.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                ' lisystable.Attributes.Add("class", "active open")
                lipropertytypes.Attributes.Add("class", "active open")
                lipropertystatus.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("PropertType.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                ' lisystable.Attributes.Add("class", "active open")
                lipropertytypes.Attributes.Add("class", "active open")
                litypes.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("PropertyViews.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                ' lisystable.Attributes.Add("class", "active open")
                lipropertytypes.Attributes.Add("class", "active open")
                liviews.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("PropertyPostcode.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                ' lisystable.Attributes.Add("class", "active open")
                lipropertytypes.Attributes.Add("class", "active open")
                lipropertypostcode.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Translations.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                ' lipropertytypes.Attributes.Add("class", "active open")
                litranslations.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Changepassword.aspx") Then
                ' lipropertytypes.Attributes.Add("class", "active open")
                lichangepassword.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("CreateClientTour.aspx") Then
                spclient.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                liclients.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                licreateclienttour.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ClientTours.aspx") Then

                spclient.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                liclients.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                lisearchclienttour.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Client.aspx") Then
                spclient.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                liclients.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                liaddcleint.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ClientSearch.aspx") Then
                spclient.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                liclients.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                liclsearch.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("SalespersonTours.aspx") Then
                spreports.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                lireports.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                lisalesperson.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Novideos.aspx") Then
                spreports.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                lireports.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                linovideos.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("ReportClientTourMissingFeedback.aspx") Then
                spreports.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                lireports.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                liclienttourfeedback.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("FranchiseActionAgenda.aspx") Then
                sconroler.Attributes.Add("class", "arrow open")
                licontroler.Attributes.Add("class", "active open")
                lisystable.Attributes.Add("class", "active open")
                liparnter.Attributes.Add("class", "active open")
                liFranchiseRequests.Attributes.Add("style", "color: #fff;background-color: #080808;")

            End If
            If Page.Request.Url.AbsoluteUri.Contains("ActionAgenda.aspx") And Not Page.Request.Url.AbsoluteUri.Contains("FranchiseActionAgenda.aspx") Then
                spreports.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                lireports.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                liAction.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If

            If Page.Request.Url.AbsoluteUri.Contains("OnlineMagazineAddEdit.aspx") Then
                sponlinemagazine.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                lionlinemagazine.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                li3.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If

            If Page.Request.Url.AbsoluteUri.Contains("OnlineMagazine.aspx") Then
                sponlinemagazine.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                lionlinemagazine.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                li4.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If

            If Page.Request.Url.AbsoluteUri.Contains("AddBlog.aspx") Then
                spblog.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                liBlogs.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                liaddblog.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Blogs.aspx") Then
                spblog.Attributes.Add("class", "arrow open")
                '  licontroler.Attributes.Add("class", "active open")
                liBlogs.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                limanageblog.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If

            If Page.Request.Url.AbsoluteUri.Contains("AddBlog.aspx") Then
                spblogs.Attributes.Add("class", "arrow open")
                li2mainblog.Attributes.Add("class", "active open")
                li2addblogg.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                li2addblogg.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If
            If Page.Request.Url.AbsoluteUri.Contains("Blogs.aspx") Then
                spblog.Attributes.Add("class", "arrow open")
                li2mainblog.Attributes.Add("class", "active open")
                li2manageblogg.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                li2manageblogg.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If

            If Page.Request.Url.AbsoluteUri.Contains("AddBlogger.aspx") Then
                spblogger.Attributes.Add("class", "arrow open")
                liBloggermain.Attributes.Add("class", "active open")
                liBlogger.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                liBlogger.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If

            If Page.Request.Url.AbsoluteUri.Contains("ManageBlogger.aspx") Then
                spblogger.Attributes.Add("class", "arrow open")
                liBloggermain.Attributes.Add("class", "active open")
                liManageBlogger.Attributes.Add("class", "active open")
                ' licreateclienttour.Attributes.Add("class", "active open")
                liManageBlogger.Attributes.Add("style", "color: #fff;background-color: #080808;")
            End If

            ' For three users don't allow view all option

            If Session("ContactId") = "10497" Or Session("ContactId") = "10407" Or Session("ContactId") = "9506" Then
                liViewAll.Style.Add(HtmlTextWriterStyle.Display, "none")
            End If

            'If Page.Request.Url.AbsoluteUri.Contains("AddNotification.aspx") Then      
            '    spnNotification.Attributes.Add("class", "arrow open")
            '    liNotification.Attributes.Add("class", "active open")
            '    liAddNotification.Attributes.Add("style", "color: #fff;background-color: #080808;")
            'End If
            'If Page.Request.Url.AbsoluteUri.Contains("ManageNotifications.aspx") Then
            '    spnNotification.Attributes.Add("class", "arrow open")
            '    liNotification.Attributes.Add("class", "active open")
            '    liManageNotification.Attributes.Add("style", "color: #fff;background-color: #080808;")
            'End If
            'If Page.Request.Url.AbsoluteUri.Contains("ManageCompanies.aspx") Then
            '    SpanCompany.Attributes.Add("class", "arrow open")
            '    liCompanies.Attributes.Add("class", "active open")
            '    liManageCompany.Attributes.Add("style", "color: #fff;background-color: #080808;")
            'End If
            If Not Session("ContactID") Is Nothing Then
                If Session("ContactID").ToString() = "10935" Then
                    lionlinemagazine.Visible = False
                    liBlogs.Visible = False
                    licontroler.Visible = False
                End If
            End If
            If Convert.ToInt32(Session("AdminUser")) = 0 And Convert.ToInt32(Session("ContactType")) = 4 Then
                liDashboardActionAgenda.Visible = True
                liDashboard.Visible = False
                liAction.Visible = False
                liActionAgendaUser.Visible = True
            End If
        End If
    End Sub

    Protected Sub lnkexport_Click(sender As Object, e As EventArgs)
        Export()
    End Sub

    Private Sub Export()

        ' Local Vars
        Dim CUtilities As New ClassUtilities

        ' Export Data
        CUtilities.ExportNew()

        ' Tidy
        CUtilities = Nothing

        ' A File
        Response.AppendHeader("Content-Disposition", "attachment; filename=Export.zip")
        Response.TransmitFile(AppDomain.CurrentDomain.GetData("DataDirectory") & "\ExportNew\Export.zip")
        Response.End()

    End Sub

    Protected Sub lnkcsvexport_Click(sender As Object, e As EventArgs)
        ExportGridToCSV()
    End Sub
    Private Sub ExportGridToCSV()
        ' LeadSearch()
        bindproperties()
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.AddHeader("content-disposition", "attachment;filename=" + System.DateTime.Now + "Properties.csv")
        Response.ContentType = "application/text"
        grdMarkettingLeads.AllowPaging = False
        grdMarkettingLeads.DataBind()

        Dim columnbind As New StringBuilder()
        For k As Integer = 0 To grdMarkettingLeads.Columns.Count - 1

            columnbind.Append(grdMarkettingLeads.Columns(k).HeaderText + ","c)
        Next

        columnbind.Append(vbCr & vbLf)
        For i As Integer = 0 To grdMarkettingLeads.Rows.Count - 1
            For k As Integer = 0 To grdMarkettingLeads.Columns.Count - 1

                columnbind.Append(grdMarkettingLeads.Rows(i).Cells(k).Text.Replace("&nbsp;", "") + ","c)
            Next

            columnbind.Append(vbCr & vbLf)
        Next
        Response.Output.Write(columnbind.ToString())
        Response.Flush()
        Response.[End]()

        '=======================================================
        'Service provided by Telerik (www.telerik.com)
        'Conversion powered by NRefactory.
        'Twitter: @telerik
        'Facebook: facebook.com/telerik
        '=======================================================

        '=======================================================
        'Service provided by Telerik (www.telerik.com)
        'Conversion powered by NRefactory.
        'Twitter: @telerik
        'Facebook: facebook.com/telerik
        '=======================================================


    End Sub


    Private Sub bindproperties()
        Dim CUtilities As New ClassUtilities
        Dim sql As SqlParameter() = New SqlParameter(1) {}
        sql(0) = New SqlParameter("@Language", 1)
        Dim dt As DataTable = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings("con").ConnectionString, CommandType.StoredProcedure, "USP_property_PropertyExportCsv", sql).Tables(0)
        '  Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                If col.ColumnName = "formatprice" Then
                    dr(col) = CUtilities.FormatPrice(dr("price"))

                End If

                If col.ColumnName = "url" Then
                    dr(col) = "<img src=""http://" & CUtilities.ApplyStatusWatermark(PhotoURL(dr("property_ref")), dr("status_id")) & """ />"
                End If
                If col.ColumnName = "Description" Then
                    '  dr(col) = "<img src='http://www.inlandandalucia.com/Files/map/img/marker.png' width='40' height='42'>" & dr("location").ToString() & "<br/>" & dr("type").ToString() & "<br/>" & "<img src='" & dr("url").ToString() & "' width='200' height='149' />" & "<br />" & "<href='http://www.inlandandalucia.com/PropSearch.aspx?propertyref='" & dr("property_ref") & " title='More information'>+info</a>" & "&nbsp;&nbsp;" & dr("formatprice").ToString() & ""
                    ' dr(col) = "<href="http://www.inlandandalucia.com/PropSearch.aspx?propertyref=" & dr("property_ref") & "" title='More information'>+info</a>"
                    dr(col) = dr("type").ToString() & "<br>" & dr("url") & "<br> " & dr("formatprice").ToString() & "<a href=""" & "http://www.inlandandalucia.com/propsearch.aspx?propertyref=" & dr("property_ref") & """" & " title=""" & "More information" & """>+info</a>" & " "
                End If

                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next
        grdMarkettingLeads.DataSource = dt
        grdMarkettingLeads.DataBind()
        '    Return serializer.Serialize(rows)
    End Sub
    Private Function PhotoURL(ByVal szPropertyRef As String) As String

        ' Local Vars
        Dim bThumbnail As Boolean = True

        ' Set the Path to the Thumbnail
        Dim szPath As String = "www.inlandandalucia.com/images/photos/properties/" & szPropertyRef.Trim & "/" & szPropertyRef.Trim & "_TN.jpg"

        ' If the Thumbnail does not Exist
        'If Not File.Exists(Server.MapPath(szPath)) Then

        '    ' Create the Thumbnail
        '    Dim CUtilities As New ClassUtilities
        '    bThumbnail = CUtilities.CreateThumbnail(szPropertyRef)
        '    CUtilities = Nothing

        'End If

        ' If we were unable to Create a Thumbnail
        If Not bThumbnail Then

            ' Set to No Image Photo
            szPath = "www.inlandandalucia.com/images/icons/no-photo.png"

        End If

        ' Return the Result
        Return szPath

    End Function


    Protected Sub lbladdcl_Click(sender As Object, e As EventArgs)
        ' Session("AdminBuyerSelected") = Nothing
        Session.Remove("AdminBuyerSelected")
        Response.Redirect("Client.aspx")
    End Sub
End Class

