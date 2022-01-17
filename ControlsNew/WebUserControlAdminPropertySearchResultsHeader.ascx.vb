
Partial Class WebUserControlAdminPropertySearchResultsHeader
    Inherits System.Web.UI.UserControl

    Public Event SortArea()
    Public Event SortBedrooms()
    Public Event SortBathrooms()
    Public Event SortCreated()
    Public Event SortPrice()
    Public Event SortReference()
    Public Event SortRegion()
    Public Event SortType()
    Public Event SortStatus()
    Public Event SortSubArea()

    Protected Sub LinkButtonArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonArea.Click
        RaiseEvent SortArea()
    End Sub

    Protected Sub LinkButtonBathrooms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonBathrooms.Click
        RaiseEvent SortBathrooms()
    End Sub

    Protected Sub LinkButtonBedrooms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonBedrooms.Click
        RaiseEvent SortBedrooms()
    End Sub

    Protected Sub LinkButtonCreated_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonCreated.Click
        RaiseEvent SortCreated()
    End Sub

    Protected Sub LinkButtonPrice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonPrice.Click
        RaiseEvent SortPrice()
    End Sub

    Protected Sub LinkButtonReference_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonReference.Click
        RaiseEvent SortReference()
    End Sub

    Protected Sub LinkButtonRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonRegion.Click
        RaiseEvent SortRegion()
    End Sub

    Protected Sub LinkButtonType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonType.Click
        RaiseEvent SortType()
    End Sub
End Class
