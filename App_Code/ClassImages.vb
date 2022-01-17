Imports Microsoft.VisualBasic
Imports System.IO

Public Class ClassImages

    Private m_alImage As ArrayList
    Public ReadOnly Property Image() As ArrayList
        Get
            Return m_alImage
        End Get
    End Property

    Public Sub New()

        m_alImage = New ArrayList

    End Sub

    Protected Overrides Sub Finalize()

        Image.Clear()
        m_alImage = Nothing

        MyBase.Finalize()

    End Sub

    Public Function Contains(ByVal szFilename As String) As Boolean

        ' Loop through Images
        For Each CImage As ClassImage In Image

            ' If this Filename Matches
            If CImage.Filename.Trim = szFilename.Trim Then

                ' Return Match
                Return True

            End If

        Next

        ' Not Matched
        Return False

    End Function

    Private Function GetPosition(ByVal szURL As String) As Integer

        ' Local Vars
        Dim nRetVal As Integer = -1

        ' Loop through Images
        For Each CImage As ClassImage In Image

            ' If this Filename Matches
            If CImage.URL.Trim = szURL.Trim Then

                ' Return Match
                nRetVal = Image.IndexOf(CImage)

            End If

        Next

        ' Return the Result
        Return nRetVal

    End Function

    Public Sub Append(ByVal CImage As ClassImage)
        Image.Add(CImage)
    End Sub

    Public Sub Prepend(ByVal CImage As ClassImage)
        Image.Insert(1, CImage)
    End Sub

    Public Sub ReplaceMain(ByVal CImage As ClassImage)

        ' Check we have a Main Image
        If Image.Count > 0 Then

            ' Replace
            Image(0) = CImage

        Else

            ' Simply Append
            Append(CImage)

        End If

    End Sub

    Public Sub Remove(ByVal nPosition As Integer)

        ' If the Image Exists
        If Image.Count >= nPosition Then

            ' Remove this Image from the Array
            Image.RemoveAt(nPosition - 1)

        End If

    End Sub

    Private Sub SwapImages(ByVal nPosition1 As Integer, ByVal nPosition2 As Integer)

        ' Decrement Pointers
        nPosition1 -= 1
        nPosition2 -= 1

        ' Copy Image being Moved
        Dim CImage As ClassImage = DirectCast(Image(nPosition1), ClassImage)

        ' Rotating Images
        Image(nPosition1) = Image(nPosition2)
        Image(nPosition2) = CImage

    End Sub

    Public Function ImageLeft(ByVal nPosition As Integer) As ArrayList

        ' Local Vars
        Dim alAffectedIndexes As New ArrayList

        ' If this is not the left most
        If nPosition > 1 Then

            ' Swap Images
            SwapImages(nPosition - 1, nPosition)

            ' Set Affected Indexes
            alAffectedIndexes.Add(nPosition - 1)
            alAffectedIndexes.Add(nPosition)

        End If

        ' Return the Result
        Return alAffectedIndexes

    End Function

    Public Function ImageRight(ByVal nPosition As Integer) As ArrayList

        ' Local Vars
        Dim alAffectedIndexes As New ArrayList

        ' If this is not the right most
        If nPosition < Image.Count Then

            ' Swap Images
            SwapImages(nPosition, nPosition + 1)

            ' Set Affected Indexes
            alAffectedIndexes.Add(nPosition)
            alAffectedIndexes.Add(nPosition + 1)

        End If

        ' Return the Result
        Return alAffectedIndexes

    End Function

    Public Function ImageUp(ByVal nPosition As Integer) As ArrayList

        ' Local Vars
        Dim alAffectedIndexes As New ArrayList

        ' If this is not the left most
        If nPosition > 1 Then

            ' Swap Images
            SwapImages(Math.Max(1, nPosition - 3), nPosition)

            ' Set Affected Indexes
            alAffectedIndexes.Add(Math.Max(1, nPosition - 3))
            alAffectedIndexes.Add(nPosition)

        End If

        ' Return the Result
        Return alAffectedIndexes

    End Function

    Public Function ImageDown(ByVal nPosition As Integer) As ArrayList

        ' Local Vars
        Dim alAffectedIndexes As New ArrayList

        ' If this is not the right most
        If nPosition < Image.Count - 1 Then

            ' Swap Images
            SwapImages(Math.Min(Me.Count, nPosition + 3), nPosition)

            ' Set Affected Indexes
            alAffectedIndexes.Add(Math.Min(Me.Count, nPosition + 3))
            alAffectedIndexes.Add(nPosition)

        End If

        ' Return the Result
        Return alAffectedIndexes

    End Function

    Public Function Count() As Integer

        Return Image.Count

    End Function

    Public Sub Clear()
        If Not Image Is Nothing Then
            Image.Clear()
        End If
    End Sub

End Class
