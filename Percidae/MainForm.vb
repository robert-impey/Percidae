Imports Microsoft.Win32
Imports System
Imports System.Text
Imports System.Security.Permissions

<Assembly: RegistryPermissionAttribute( _
    SecurityAction.RequestMinimum, ViewAndModify:="HKEY_LOCAL_MACHINE")> 

Public Class MainForm

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillPathTextBox()

        'Check that the user has the appropriate privileges
    End Sub

    Private Sub FillPathTextBox()
        Dim lmRegistryKey As RegistryKey = Registry.LocalMachine
        Dim pathKey As RegistryKey = lmRegistryKey.OpenSubKey("SYSTEM\CurrentControlSet\Control\Session Manager\Environment")

        Dim path As String = pathKey.GetValue("Path")
        pathKey.Close()
        lmRegistryKey.Close()

        'Parse the path
        Dim folders As Array = path.Split(";")

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

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim pathStringBuilder As New StringBuilder

        Dim folders As Array = Me.PathTextBox.Text.Split(";")

        For Each folder As String In folders
            folder = folder.Trim
            If folder.Length > 0 Then
                pathStringBuilder.Append(folder)
                pathStringBuilder.Append(";")
            End If
        Next

        'MsgBox(pathStringBuilder.ToString)

        Dim lmRegistryKey As RegistryKey = Registry.LocalMachine
        Dim pathKey As RegistryKey = lmRegistryKey.OpenSubKey("SYSTEM\CurrentControlSet\Control\Session Manager\Environment", True)

        pathKey.SetValue("Path", pathStringBuilder.ToString)
        pathKey.Close()
        lmRegistryKey.Close()

        FillPathTextBox()

        MsgBox("Path saved!")
    End Sub
End Class
