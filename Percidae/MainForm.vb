Imports System.Security.Permissions
Imports Microsoft.Win32
Imports Percidae.Folders

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

        Dim folders = Parser.ParsePath(path)
        Me.PathTextBox.Text = Writer.WriteFoldersForTextBox(folders)
    End Sub

    Private Sub SavePath()
        Dim lmRegistryKey As RegistryKey = Registry.LocalMachine
        Dim pathKey As RegistryKey = lmRegistryKey.OpenSubKey(environmentKeyName, True)

        Dim folders = Parser.ParsePath(Me.PathTextBox.Text)
        pathKey.SetValue("Path", Writer.WriteFoldersForEnvironment(folders))
        pathKey.Close()
        lmRegistryKey.Close()
    End Sub

#End Region
End Class
