Imports Microsoft.VisualBasic
Imports System.Data

Public Class EcijaLocationInfo
    Inherits System.Web.UI.Page

    Public Function GetTranslation(ByVal szText As String) As String

        Dim CDataAccess As New ClassDataAccess

        Dim szRetVal As String = CDataAccess.GetTranslation(szText, Session("Language")).Trim

        CDataAccess = Nothing

        Return szRetVal

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set Session Variables
        Session("RegionID") = 5
        Session("AreaID") = 322

        ' Get the View Properties Button
        ViewProperties.InnerHTML = "<img src='" & GetViewPropertiesImagePath.Trim & "' alt=""View properties"" width=""262"" height=""31"" border=""0"" align=""right"" />"

        ' Init Class
        Dim CTownMap As Control = LoadControl("Controls/WebUserControlGoogleMapTown.ascx")

        ' Add this to the Update Panel
        UpdatePanelTownMap.ContentTemplateContainer.Controls.Add(CTownMap)

    End Sub
    
        Public Function GetViewPropertiesImagePath() As String
    
            ' Init Return Var
            Dim szRetVal As String = "images/buttons/"
    
            ' Depending on the Language
            Dim CUtilities As New ClassUtilities
    
            Select Case CUtilities.GetLanguageID(Session("Language"))
    
                Case 2
                    ' Spanish
                    szRetVal &= "view-properties-ES.gif"
    
                Case 3
                    ' French
                    szRetVal &= "view-properties-FR.gif"
    
                Case 4
                    ' German
                    szRetVal &= "view-properties-DE.gif"
    
                Case Else
                    ' English
                    szRetVal &= "view-properties.gif"
    
            End Select
    
            ' Tidy
            CUtilities = Nothing
    
            ' Return the Path
            Return szRetVal.Trim
    
        End Function

End Class
