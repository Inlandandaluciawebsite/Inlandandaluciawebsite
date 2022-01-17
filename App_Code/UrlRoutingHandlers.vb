Imports System.Web.Compilation 
Imports System.Web.Routing

Public Class UrlRoutingHandlers
    Implements IRouteHandler
    ''' <summary> 
    ''' Create this RoutingHandler to check the HttpRequest and 
    ''' return correct url path. 
    ''' </summary> 
    ''' <param name="context"></param> 
    ''' <returns></returns> 
    Public Function GetHttpHandler1(ByVal context As System.Web.Routing.RequestContext) As System.Web.IHttpHandler Implements System.Web.Routing.IRouteHandler.GetHttpHandler
        Dim language As String = context.RouteData.Values("language").ToString().ToLower()
        Dim pageName As String = context.RouteData.Values("pageName").ToString()
        Dim pageName2 As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim currentpage As String = pageName2.Substring(pageName2.LastIndexOf("/") + 1)
        If pageName = currentpage Then
            Return TryCast(BuildManager.CreateInstanceFromVirtualPath("~/" + currentpage, GetType(Page)), Page)
        Else
            Return BuildManager.CreateInstanceFromVirtualPath("~/nopagefound.aspx", GetType(Page))
        End If
    End Function
End Class


Public Class UrlRoutingHandlers1
    Implements IRouteHandler
    ''' <summary> 
    ''' Create this RoutingHandler to check the HttpRequest and 
    ''' return correct url path. 
    ''' </summary> 
    ''' <param name="context"></param> 
    ''' <returns></returns> 
    Public Function GetHttpHandler1(ByVal context As System.Web.Routing.RequestContext) As System.Web.IHttpHandler Implements System.Web.Routing.IRouteHandler.GetHttpHandler
        Dim language As String = context.RouteData.Values("language").ToString().ToLower()
        Dim pageName As String = context.RouteData.Values("Title").ToString()
        Dim pageName2 As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim currentpage As String = pageName2.Substring(pageName2.LastIndexOf("/") + 1)
        If pageName = currentpage Then
            Return TryCast(BuildManager.CreateInstanceFromVirtualPath("~/Blog/Default.aspx", GetType(Page)), Page)
        Else
            Return BuildManager.CreateInstanceFromVirtualPath("~/nopagefound.aspx", GetType(Page))
        End If
    End Function
End Class


