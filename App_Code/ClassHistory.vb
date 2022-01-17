Imports Microsoft.VisualBasic
Imports System.Web.HttpContext

Public Class ClassHistory

    Public Shared Sub SaveActiveControl(Optional ByVal bAppend As Boolean = True)

        ' If we have an Active Control
        If Not Current.Session("AdminActiveControl") Is Nothing Then

            '' Local Cars
            'Dim bSave As Boolean = True

            ' If we do not yet have a Previous Control
            If Current.Session("AdminControlList") Is Nothing Then

                ' Create History Array
                Current.Session("AdminControlList") = New ArrayList

                ' Save
                DirectCast(Current.Session("AdminControlList"), ArrayList).Add(Current.Session("AdminActiveControl"))

                ' Set the Pointer
                Current.Session("AdminControlListPointer") = DirectCast(Current.Session("AdminControlList"), ArrayList).Count

            Else

                ' Local Vars
                Dim nIndex As Integer = -1
                Dim nFoundIndex As Integer = -1
                Dim ctrl As Control

                ' Cast this as a Control
                ctrl = DirectCast(Current.Session("AdminActiveControl"), Control)

                ' For each Element in the History Array
                For Each ctrlHistory As Control In DirectCast(Current.Session("AdminControlList"), ArrayList)

                    ' Increment Index
                    nIndex += 1

                    ' If the IDs Match
                    If ctrl.ClientID = ctrlHistory.ClientID Then

                        ' Set the Flag
                        nFoundIndex = nIndex

                    End If

                Next

                ' If Found and we are Appending
                If nFoundIndex > -1 And bAppend Then

                    ' Remove Controls from this Point in the List Onward
                    For nIndex = nFoundIndex + 1 To DirectCast(Current.Session("AdminControlList"), ArrayList).Count - 1
                        DirectCast(Current.Session("AdminControlList"), ArrayList).RemoveAt(nFoundIndex + 1)
                    Next

                    ' Set to Append
                    nFoundIndex = DirectCast(Current.Session("AdminControlList"), ArrayList).Count

                    '' Don't Save
                    'bSave = False

                Else

                    ' If we have no Index yet
                    If nFoundIndex < 0 Then

                        ' Set to Append
                        nFoundIndex = DirectCast(Current.Session("AdminControlList"), ArrayList).Count

                    Else

                        ' Remove Existing
                        DirectCast(Current.Session("AdminControlList"), ArrayList).RemoveAt(nFoundIndex)

                    End If

                    ' Save
                    DirectCast(Current.Session("AdminControlList"), ArrayList).Insert(nFoundIndex, Current.Session("AdminActiveControl"))

                End If

                ' Set the Pointer
                Current.Session("AdminControlListPointer") = nFoundIndex

                '' If the Item was Found and not Appending
                'If nFoundIndex > -1 And Not bAppend Then

                '    ' Remove from the Array
                '    DirectCast(Current.Session("AdminControlList"), ArrayList).RemoveAt(nFoundIndex)

                'Else

                '    ' Set to Append
                '    nFoundIndex = DirectCast(Current.Session("AdminControlList"), ArrayList).Count

                'End If

                '' If Saving
                'If bSave Then

                '    ' Save
                '    DirectCast(Current.Session("AdminControlList"), ArrayList).Insert(nFoundIndex, Current.Session("AdminActiveControl"))

                '    ' Set the Pointer
                '    Current.Session("AdminControlListPointer") = nFoundIndex

                'End If

            End If

        End If

    End Sub

    Public Shared Sub LoadPreviousControl()

        ' Save Active Control
        SaveActiveControl(False)

        ' If we have a Control List
        If Not Current.Session("AdminControlList") Is Nothing Then

            ' If we don't yet have a Control Pointer
            If Current.Session("AdminControlListPointer") Is Nothing Then

                ' Init to the Size of the Array
                Current.Session("AdminControlListPointer") = DirectCast(Current.Session("AdminControlList"), ArrayList).Count - 1

            End If

            ' If the Pointer is not at the Start of the List
            If Convert.ToInt32(Current.Session("AdminControlListPointer")) > 0 Then

                ' Decrement the Pointer
                Current.Session("AdminControlListPointer") = Convert.ToInt32(Current.Session("AdminControlListPointer")) - 1

            End If

            ' Load the Previous Control
            Current.Session("AdminActiveControl") = DirectCast(Current.Session("AdminControlList"), ArrayList).Item(DirectCast(Current.Session("AdminControlListPointer"), Int32))

        End If

    End Sub

    Public Shared Sub LoadNextControl()

        ' Save Active Control
        SaveActiveControl(False)

        ' If we have a Control List
        If Not Current.Session("AdminControlList") Is Nothing Then

            ' If we don't yet have a Control Pointer
            If Current.Session("AdminControlListPointer") Is Nothing Then

                ' Init to the Size of the Array
                Current.Session("AdminControlListPointer") = DirectCast(Current.Session("AdminControlList"), ArrayList).Count - 1

            End If

            ' If the Pointer is Less than the Size of the List
            If Convert.ToInt32(Current.Session("AdminControlListPointer")) < DirectCast(Current.Session("AdminControlList"), ArrayList).Count - 1 Then

                ' Increment the Pointer
                Current.Session("AdminControlListPointer") = Convert.ToInt32(Current.Session("AdminControlListPointer")) + 1

            End If

            ' Load the Next Control
            Current.Session("AdminActiveControl") = DirectCast(Current.Session("AdminControlList"), ArrayList).Item(DirectCast(Current.Session("AdminControlListPointer"), Int32))

        End If

    End Sub

    Public Shared Sub SaveControlValues(Optional ByVal obj As Object = Nothing)

        ' Local Vars
        Dim ctrl As Control

        ' If we have not been passed a Control
        If obj Is Nothing Then

            ' Get Active Control
            ctrl = DirectCast(Current.Session("AdminActiveControl"), Control)

        Else

            ' Use the Control Passed
            ctrl = DirectCast(obj, Control)

        End If

        ' Loop through the Controls
        For Each subCtrl As Control In ctrl.Controls

            ' Depending on the Control Type
            Select Case subCtrl.GetType()

                'Case GetType(Label)

                '    ' Save Style
                '    Current.Session(subCtrl.ClientID) = DirectCast(subCtrl, Label).Font

                Case GetType(TextBox)

                    ' Save Value
                    Current.Session(subCtrl.ClientID) = DirectCast(subCtrl, TextBox).Text

                Case GetType(CheckBox)

                    ' Save Value
                    Current.Session(subCtrl.ClientID) = DirectCast(subCtrl, CheckBox).Checked

                Case GetType(DropDownList)

                    ' Clear Previous
                    Current.Session(subCtrl.ClientID & "-Items") = Nothing

                    ' Save Items
                    Current.Session(subCtrl.ClientID & "-Items") = DirectCast(subCtrl, DropDownList).Items

                    ' Save Value
                    Current.Session(subCtrl.ClientID) = DirectCast(subCtrl, DropDownList).SelectedValue

                Case GetType(GridView)

                    ' Save Value
                    Current.Session(subCtrl.ClientID) = DirectCast(subCtrl, GridView).DataSource

                Case Else

                    ' Recursively Call Function
                    SaveControlValues(subCtrl)

            End Select

            ' Irrespective of Control Type - Save Visibility
            Current.Session(subCtrl.ClientID & "-Visibility") = subCtrl.Visible

        Next

    End Sub

    Public Shared Sub LoadControlValues(Optional ByVal obj As Object = Nothing)

        ' Local Vars
        Dim ctrl As Control

        ' If we have not been passed a Control
        If obj Is Nothing Then

            ' Get Active Control
            ctrl = DirectCast(Current.Session("AdminActiveControl"), Control)

        Else

            ' Use the Control Passed
            ctrl = DirectCast(obj, Control)

        End If

        ' If the Control is Valid
        If Not ctrl Is Nothing Then

            ' Loop through the Controls
            For Each subCtrl As Control In ctrl.Controls

                ' Depending on the Control Type
                Select Case subCtrl.GetType()

                    'Case GetType(Label)

                    '    ' Load Style
                    '    DirectCast(subCtrl, Label).Font.CopyFrom(Current.Session(subCtrl.ClientID))

                    Case GetType(TextBox)

                        ' Load Value
                        DirectCast(subCtrl, TextBox).Text = Current.Session(subCtrl.ClientID)

                    Case GetType(CheckBox)

                        ' Load Value
                        DirectCast(subCtrl, CheckBox).Checked = Current.Session(subCtrl.ClientID)

                    Case GetType(DropDownList)

                        ' Clear Previous
                        DirectCast(subCtrl, DropDownList).Items.Clear()

                        ' For each Item
                        For Each li As ListItem In DirectCast(Current.Session(subCtrl.ClientID & "-Items"), ListItemCollection)

                            ' Add this Item
                            DirectCast(subCtrl, DropDownList).Items.Add(li)

                        Next

                        ' Load Value
                        DirectCast(subCtrl, DropDownList).SelectedValue = Current.Session(subCtrl.ClientID)

                    Case GetType(GridView)

                        ' Load Value
                        DirectCast(subCtrl, GridView).DataSource = Current.Session(subCtrl.ClientID)
                        DirectCast(subCtrl, GridView).DataBind()

                    Case Else

                        ' Recursively Call Function
                        LoadControlValues(subCtrl)

                End Select

                ' Irrespective of Control Type - Load Visibility
                subCtrl.Visible = Current.Session(subCtrl.ClientID & "-Visibility")

            Next

        End If

    End Sub

End Class
