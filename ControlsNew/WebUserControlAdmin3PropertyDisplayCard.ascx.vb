
Partial Class WebUserControlAdmin3PropertyDisplayCard
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Check if Session Expired
        If Session("AdminClientTourPropertiesSelected") Is Nothing Then

            ' Redirect to Agent Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' Init Counter
            Dim nCounter As Integer = 0

            ' Add Initial Header
            AddHeader(0)
            '<img src="<%= GetHeaderImageURL%>" width="675" style="padding-top:20px;" alt="Header"/>

            ' For each Property ID
            For Each nPropertyID As Integer In DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList)

                ' Increment Counter
                nCounter += 1

                ' Create a New Control
                Dim ctrl As ASP.controls_webusercontroladmin3propertydisplaycarditem_ascx = CType(LoadControl("~/Controls/WebUserControlAdmin3PropertyDisplayCardItem.ascx"), ASP.controls_webusercontroladmin3propertydisplaycarditem_ascx)

                ' Define an ID
                ctrl.ID = "Admin3PropertyDisplayCardItem" & nCounter.ToString.Trim

                ' Add this to the Page
                PlaceHolderDisplayItems.Controls.Add(ctrl)

                ' Init Control
                ctrl.InitItem(nPropertyID)

                ' If there are Still Images to Process
                If nCounter < DirectCast(Session("AdminClientTourPropertiesSelected"), ArrayList).Count Then

                    ' If this is Divisible by 3, Readd Header
                    If nCounter Mod 3 = 0 Then

                        ' Add Header
                        AddHeader(nCounter / 3)

                    End If

                End If

            Next

        End If

    End Sub

    Private Sub AddHeader(ByVal nCounter As Integer)

        ' Local Vars
        Dim img As New Image

        ' Assign the ID
        img.ID = "ImageHeader" & nCounter.ToString.Trim

        ' Assign Variables
        img.ImageUrl = GetHeaderImageURL()
        img.Width = 675
        img.AlternateText = "Header"

        ' Add this Image to the Page
        PlaceHolderDisplayItems.Controls.Add(img)

    End Sub

    Private Function GetHeaderImageURL() As String

        ' Local Var
        Dim szRetVal As String = String.Empty

        ' Check if Session Expired
        If Session("ContactPartnerID") Is Nothing Then

            ' Redirect to Agent Login
            Response.Redirect("~/AgentLogin.aspx")

        Else

            ' If set to a Value
            If Convert.ToInt32(Session("ContactPartnerID")) > 0 Then

                ' Not a Partner but using their Partner's Logo
                szRetVal = "/Images/Logos/p" & Session("ContactPartnerID").ToString.Trim & ".jpg"

            End If

        End If

        ' Return the Result
        Return szRetVal

    End Function

End Class
