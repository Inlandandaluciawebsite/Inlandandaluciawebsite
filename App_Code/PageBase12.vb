Imports System.Threading
Imports System.Globalization

Public Class BasePage1
    Inherits System.Web.UI.Page
    Protected Overrides Sub InitializeCulture()
        Dim language As String = "en-us"

        'Detect User's Language.
        If Request.UserLanguages IsNot Nothing Then
            'Set the Language.
            language = Request.UserLanguages(0)
        End If

        'Check if PostBack is caused by Language DropDownList.

        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonEnglish") Then
            'Set the Language. 
            '  Response.Write(Request.Form("__EVENTTARGET").ToString())

            Session("language") = "en-us"
        End If
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonSpanish") Then
            'Set the Language. 
            '    Response.Write(Request.Form("__EVENTTARGET").ToString())

            Session("language") = "de-de"
        End If
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonFrench") Then
            'Set the Language. 
            '  Response.Write(Request.Form("__EVENTTARGET").ToString())
            Session("language") = "fr"
        End If
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonGerman") Then
            'Set the Language. 
            '  Response.Write(Request.Form("__EVENTTARGET").ToString())
            Session("language") = "nl"
        End If
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonDutch") Then
            'Set the Language. 
            '   Response.Write(Request.Form("__EVENTTARGET").ToString())
            Session("language") = "da"
        End If

        'If Not Session("language") = "" And Not Session("language") = "en-us" Then
        '    language = Session("language")
        'End If
        If Not Session("language") = "" Then
            language = Session("language")
        Else
            language = "en-us"
        End If

        'Set the Culture.
        Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)
    End Sub
End Class
