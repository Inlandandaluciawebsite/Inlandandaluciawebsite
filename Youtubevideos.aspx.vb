Imports System.IO
Imports System.Drawing
Imports System.Threading
'Imports System.Windows.Forms
Partial Class Youtubevideos
    Inherits System.Web.UI.Page

#Region "init settings"
    ' player width
    Private _W As Integer = 640

    ' player height
    Private _H As Integer = 505

    ' autoplay disabled
    Private auto As Boolean = True
#End Region

#Region "Page Load event"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            '#Region "Start mode customization via Web Query String"
            Dim idx As Integer = 0
            Dim qry As String = ""

            '' Web Query to set autoplay option
            'Try
            '    qry = "auto"
            '    qry = If((Request.QueryString(qry) Is Nothing), "", Request.QueryString(qry))
            '    If qry <> "" Then
            '        auto = [Boolean].Parse(qry)
            '    End If
            'Catch
            'End Try

            '' Web Query to set item index
            'Try
            '    qry = "item"
            '    qry = If((Request.QueryString(qry) Is Nothing), "", Request.QueryString(qry))
            '    If qry <> "" Then
            '        idx = Integer.Parse(qry)
            '    End If
            'Catch
            'End Try
            ''#End Region

            ' set selected index
            ' cmbPlaylist.SelectedIndex = idx

            ' generate script on page load
            If Not Request.QueryString("videourl") = "" Then
                ' Literal1.Text = YouTubeScript.[Get](Request.QueryString("videourl"), auto, _W, _H)
                'Literal1.Text = YouTubeScript.[Get](Request.QueryString("videourl"), auto, _W, _H)
                urlembed.Text = Request.QueryString("videourl")
            End If

        Else
            ' generate script on page postback
            ' Literal1.Text = YouTubeScript.[Get](cmbPlaylist.SelectedValue, False, _W, _H)
        End If
    End Sub
#End Region



    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================

End Class
