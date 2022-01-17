Imports System.Data

Partial Class WebUserControlAdminPropertySearchResult
    Inherits System.Web.UI.UserControl

    Public Event AddRemove()

    Public Sub InitData(ByVal CUtilities As ClassUtilities, ByVal dr As DataRow)

        ' Depending on Partner
        If Session("ContactPartnerID") = 3864 Then

            ' CA
            TextBoxReference.Text = dr(2).ToString.Trim

        Else

            ' IA
            TextBoxReference.Text = dr(1).ToString.Trim

        End If

        ' Populate Data
        TextBoxCreated.Text = dr(3).ToString.Trim
        TextBoxType.Text = dr(4).ToString.Trim
        TextBoxRegion.Text = dr(6).ToString.Trim
        TextBoxArea.Text = dr(7).ToString.Trim
        TextBoxBedrooms.Text = dr(9).ToString.Trim
        TextBoxBathrooms.Text = dr(10).ToString.Trim
        TextBoxPrice.Text = CUtilities.FormatPrice(Convert.ToInt32(dr(14).ToString.Trim))
        TextBoxID.Text = dr(0).ToString.Trim

        ' Init Hyperlink
        HyperLinkView.NavigateUrl = "/propsearch.aspx?propertyid=" & TextBoxID.Text.Trim

    End Sub

    Protected Sub ButtonAddRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAddRemove.Click

        ' If the Property Array has not yet been Defined, Define
        If Session("AdminClientTourPropertiesSelected") Is Nothing Then
            Session("AdminClientTourPropertiesSelected") = New ArrayList
        End If

        ' If we are Adding
        If ButtonAddRemove.Text = "Add" Then

            ' Add this Property
            DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList).Add(Convert.ToInt32(TextBoxID.Text))

            ' Change the Button Text
            ButtonAddRemove.Text = "Remove"

        Else

            ' Remove this Property
            DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList).Remove(Convert.ToInt32(TextBoxID.Text))

            ' Change the Button Text
            ButtonAddRemove.Text = "Add"

        End If

        ' Raise Event
        RaiseEvent AddRemove()

    End Sub

    Public Sub SetStatus(ByVal bSelected As Boolean, ByVal bLimitReached As Boolean)

        ' If Selected
        If bSelected Then
            ButtonAddRemove.Text = "Remove"
        Else
            ButtonAddRemove.Text = "Add"
        End If

        ' If the Limit has been Reached and this Property is not selected
        ButtonAddRemove.Visible = Not (bLimitReached And Not bSelected)

    End Sub

    'Protected Sub ButtonView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonView.Click

    '    ' Init URL
    '    Dim szURL As String = "http://www.inlandandalucia.com/propsearch.aspx?propertyid=" & TextBoxID.ToString.Trim

    '    Response.Redirect(szURL)

    '    'Response.Write("<script>")
    '    'Response.Write("window.open('" & szURL.Trim & "','_blank')")
    '    'Response.Write("</script>")

    'End Sub

End Class
