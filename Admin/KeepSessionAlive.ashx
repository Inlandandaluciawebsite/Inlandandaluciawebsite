<%@ WebHandler Language="VB" Class="KeepSessionAlive"  %>

Imports System
Imports System.Web

Public Class KeepSessionAlive : Implements IHttpHandler,IRequiresSessionState
   
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
      context.Session("KeepSessionAlive") = DateTime.Now
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class