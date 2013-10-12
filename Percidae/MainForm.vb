Imports Microsoft.Win32
Imports System
Imports System.Text
Imports System.Security.Permissions

<Assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, ViewAndModify:="HKEY_LOCAL_MACHINE")> 

Public Class MainForm
#Region "Constants"

    Private Const environmentKeyName As String = "SYSTEM\CurrentControlSet\Control\Session Manager\Environment"

#End Region

#Region "Events"

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillPathTextBox()
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        SavePath()

        FillPathTextBox()

        MsgBox("Path saved!")
    End Sub

#End Region

#Region "Subs"

    Private Sub FillPathTextBox()
        Dim lmRegistryKey As RegistryKey = Registry.LocalMachine
        Dim pathKey As RegistryKey = lmRegistryKey.OpenSubKey(environmentKeyName)

        Dim path As String = CStr(pathKey.GetValue("Path"))
        pathKey.Close()
        lmRegistryKey.Close()

        'Parse the path
        Dim folders As Array = path.Split(CChar(";"))

        Dim foldersStringBuilder As New StringBuilder
        For Each folder As String In folders
            folder = folder.Trim
            If folder.Length > 0 Then
                foldersStringBuilder.Append(folder)
                foldersStringBuilder.AppendLine(";")
            End If
        Next

        Me.PathTextBox.Text = foldersStringBuilder.ToString
    End Sub

    Private Sub SavePath()
        Dim pathStringBuilder As New StringBuilder

        Dim folders As Array = Me.PathTextBox.Text.Split(CChar(";"))

        For Each folder As String In folders
            folder = folder.Trim
            If folder.Length > 0 Then
                pathStringBuilder.Append(folder)
                pathStringBuilder.Append(";")
            End If
        Next

        Dim lmRegistryKey As RegistryKey = Registry.LocalMachine
        Dim pathKey As RegistryKey = lmRegistryKey.OpenSubKey(environmentKeyName, True)

        pathKey.SetValue("Path", pathStringBuilder.ToString)
        pathKey.Close()
        lmRegistryKey.Close()
    End Sub

#End Region
End Class
