Imports Microsoft.VisualBasic

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            ' If the Language is NULL
            If Session("Language") Is Nothing Then

                ' Init to English
                Session("Language") = "English"

            End If

        End If

    End Sub
End Class
