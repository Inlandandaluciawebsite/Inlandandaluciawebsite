Imports System.Threading
Imports System.Globalization

Public Class BasePage
    Inherits System.Web.UI.Page
Protected Overrides Sub InitializeCulture()
        Dim language As String = "en-us"

        'Detect User's Language.
        If Request.UserLanguages IsNot Nothing Then
            'Set the Language.
            language = Request.UserLanguages(0)
        End If
        Dim isbtnclick As String = ""
        'Check if PostBack is caused by Language DropDownList.

        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonEnglish") Then
            'Set the Language. 
            '  Response.Write(Request.Form("__EVENTTARGET").ToString())

            Session("language") = "English"
            isbtnclick = "true"
            '   Session("languageNew") = "en-us"

            ' Session("language") = "de-de"
        End If
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonSpanish") Then
            'Set the Language. 
            '    Response.Write(Request.Form("__EVENTTARGET").ToString())

            Session("language") = "Spanish"
            isbtnclick = "true"
            ' Session("languageNew") = "de-de"
        End If
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonFrench") Then
            'Set the Language. 
            '  Response.Write(Request.Form("__EVENTTARGET").ToString())
            Session("language") = "French"
            isbtnclick = "true"
            '  Session("languageNew") = "fr"
        End If
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonGerman") Then
            'Set the Language. 
            '  Response.Write(Request.Form("__EVENTTARGET").ToString())
            Session("language") = "German"
            isbtnclick = "true"
            '  Session("languageNew") = "nl"
        End If
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ImageButtonDutch") Then
            'Set the Language. 
            '   Response.Write(Request.Form("__EVENTTARGET").ToString())
            Session("language") = "Dutch"
            isbtnclick = "true"
            'Session("languageNew") = "da"
        End If

        'If Not Session("language") = "" And Not Session("language") = "en-us" Then
        '    language = Session("language")
        'End If
        If Not Session("language") = "" Then

            '  language = Session("language")
            Dim language1 As String = Session("language")
            Select Case language1

                Case "English"
                    language = "en-us"

                Case "Spanish"
                    language = "de-de"

                Case "French"
                    language = "fr"

                Case "German"
                    language = "nl"

                Case "Dutch"
                    language = "da"

                Case Else
                    language = "en-us"

            End Select

        Else
            language = "en-us"
        End If

        If Not RouteData.Values("language") = "" And Not isbtnclick = "true" Then
            language = RouteData.Values("language").ToString()

            Select Case language

                Case "en"
                    Session("language") = "English"

                Case "es"

                    Session("language") = "Spanish"
                    language = "de-de"
                Case "fr"

                    Session("language") = "French"

                Case "nl"

                    Session("language") = "German"
                    language = "nl"

                Case "de"


                    Session("language") = "Dutch"
                    language = "da"

                Case Else

                    Session("language") = "English"
            End Select


        End If


        'Set the Culture.

        If (language.ToString() = "KeepSessionAlive.aspx") Then
        Else
            Try
                Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
                Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)
            Catch ex As Exception

            End Try
        End If

    End Sub
End Class
