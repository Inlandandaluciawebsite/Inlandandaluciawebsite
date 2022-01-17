Imports Microsoft.VisualBasic
Imports System.IO

Public Class ClassImage

    Private m_szPropertyReference As String
    Private Property PropertyReference() As String
        Get
            Return m_szPropertyReference
        End Get
        Set(ByVal value As String)
            m_szPropertyReference = value
        End Set
    End Property

    Public ReadOnly Property URL() As String
        Get
            '' Return "~/Images/Photos/Properties/" & PropertyReference.Trim & "/" & Filename.Trim & "?nocache=" & Rnd().ToString.Trim
            Return "~/Images/Photos/Properties/" & PropertyReference.Trim & "/" & Filename.Trim & "?" & DateTime.Now.Ticks.ToString()
        End Get
    End Property

    Public ReadOnly Property CleanURL() As String
        Get
            Return "~/Images/Photos/Properties/" & PropertyReference.Trim & "/" & Filename.Trim
        End Get
    End Property

    Public ReadOnly Property CleanPath() As String
        Get
            Return "~/Images/Photos/Properties/" & PropertyReference.Trim & "/"
        End Get
    End Property

    Private m_szFilename As String
    Public Property Filename() As String
        Get
            Return m_szFilename
        End Get
        Set(ByVal value As String)
            m_szFilename = value
        End Set
    End Property

    Private m_bEnabled As Boolean
    Public Property Enabled() As Boolean
        Get
            Return m_bEnabled
        End Get
        Set(ByVal value As Boolean)
            m_bEnabled = value
        End Set
    End Property

    Public Sub New(ByVal szPropertyReference As String, ByVal szFilename As String, ByVal bEnabled As Boolean)

        ' Assign Locals
        PropertyReference = szPropertyReference.Trim.ToUpper
        Enabled = bEnabled
        Filename = szFilename

    End Sub

    Public Function TemporaryFilename() As String

        Return Filename.Substring(0, Filename.IndexOf(".")) & "_TMP" & Filename.Substring(Filename.IndexOf("."))

    End Function

    Public Function ImageDirectory() As String
        Return Path.GetDirectoryName(HttpContext.Current.Server.MapPath(CleanURL))
    End Function

End Class
