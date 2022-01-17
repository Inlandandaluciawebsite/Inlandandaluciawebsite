
Partial Class WebUserControlAdmin3PropertyDisplayCardItem
    Inherits System.Web.UI.UserControl

    Public Sub InitItem(ByVal nPropertyID As Integer)

        ' Check Session hasn't Expired
        If Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Load the Property
            Dim CProperty As New ClassProperty(Session("ContactPartnerID"))
            CProperty.Load(nPropertyID)

            ' Assign Images
            ImageMain.ImageUrl = "~/Images/Photos/Properties/" & CProperty.Reference.Trim.ToUpper & "/" & CProperty.Reference.Trim.ToUpper & "_1.jpg"
            ImageSmall1.ImageUrl = "~/Images/Photos/Properties/" & CProperty.Reference.Trim.ToUpper & "/" & CProperty.Reference.Trim.ToUpper & "_2.jpg"
            ImageSmall2.ImageUrl = "~/Images/Photos/Properties/" & CProperty.Reference.Trim.ToUpper & "/" & CProperty.Reference.Trim.ToUpper & "_3.jpg"

            ' If Language has not been Defined
            If Session("Language") Is Nothing Then

                ' Init to English
                Session("Language") = "English"

            End If

            ' Depending on the Language, set the Description
            Select Case Session("Language")

                Case "English"
                    LabelShortDescription.Text = CProperty.ShortDescription(1)

                Case "Spanish"
                    LabelShortDescription.Text = CProperty.ShortDescription(2)

                Case "French"
                    LabelShortDescription.Text = CProperty.ShortDescription(3)

                Case "German"
                    LabelShortDescription.Text = CProperty.ShortDescription(4)

                Case Else
                    LabelShortDescription.Text = CProperty.ShortDescription(5)

            End Select

            ' Assign Remaining Vars
            LabelTown.Text = CProperty.AreaName
            LabelReference.Text = CProperty.Reference

            ' Local Vars
            Dim CDataAccess As New ClassDataAccess

            ' Assign Labels
            LabelBedsText.Text = CDataAccess.GetTranslation("Beds", Session("Language")) & " / " & CDataAccess.GetTranslation("Beds", 2) & ":"
            LabelBathsText.Text = CDataAccess.GetTranslation("Baths", Session("Language")) & " / " & CDataAccess.GetTranslation("Baths", 2) & ":"
            LabelBuiltText.Text = CDataAccess.GetTranslation("Built", Session("Language")) & " / " & CDataAccess.GetTranslation("Built", 2) & ":"
            LabelPriceText.Text = CDataAccess.GetTranslation("Price", Session("Language")) & " / " & CDataAccess.GetTranslation("Price", 2) & ":"

            ' Tidy
            CDataAccess = Nothing

            ' Local Vars
            Dim CUtilities As New ClassUtilities

            ' Assign Values
            LabelBedsValue.Text = CProperty.Bedrooms.ToString.Trim
            LabelBathsValue.Text = CProperty.Bathrooms.ToString.Trim
            LabelBuiltValue.Text = CProperty.Built.ToString.Trim
            LabelPriceValue.Text = CUtilities.FormatPrice(CProperty.PublicPrice)

            ' Tidy
            CUtilities = Nothing

            ' Depending on the Language, set the Description
            Select Case Session("Language")

                Case "English"
                    LabelDescription.Text = CProperty.Description(1)

                Case "Spanish"
                    LabelDescription.Text = CProperty.Description(2)

                Case "French"
                    LabelDescription.Text = CProperty.Description(3)

                Case "German"
                    LabelDescription.Text = CProperty.Description(4)

                Case Else
                    LabelDescription.Text = CProperty.Description(5)

            End Select

            ' Tidy
            CProperty = Nothing

        End If

    End Sub

End Class
