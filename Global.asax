<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim secretKey As String = ConfigurationManager.AppSettings("StripeSecretKey")
        Stripe.StripeConfiguration.SetApiKey(secretKey)
        ' Code that runs on application startup
        RegisterRoutes(RouteTable.Routes)
    End Sub
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.Ignore("{resource}.axd/{*pathInfo}")
        '' routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()))
        routes.MapPageRoute("Page2", "{language}", "~/Default.aspx")
        routes.MapPageRoute("BlogDetail",
          "Blog/{Title}", "~/Blog/Default.aspx")
        routes.MapPageRoute("TownInfo",
"towninformation/{Page}", "~/TownInfo.aspx")
        routes.Add("Pagefortest1", New Route("{language}/Blog/{Title}", New UrlRoutingHandlers1()))
        routes.Add("Pagefortest", New Route("{language}/{pageName}", New UrlRoutingHandlers()))
        '   routes.Add("Pagefortest", New Route("{language}/{pageName}", New UrlRoutingHandlers()))

    End Sub
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub

</script>
