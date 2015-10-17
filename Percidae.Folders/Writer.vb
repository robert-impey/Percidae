Imports System.Text

Public Module Writer
    Public Function WriteFoldersForTextBox(ByVal folders As IEnumerable(Of String)) As String
        Dim foldersStringBuilder As New StringBuilder
        For Each folder As String In folders
            folder = folder.Trim
            If folder.Length > 0 Then
                foldersStringBuilder.Append(folder)
                foldersStringBuilder.AppendLine(";")
            End If
        Next
        Return foldersStringBuilder.ToString()
    End Function

    Public Function WriteFoldersForEnvironment(ByVal folders As IEnumerable(Of String)) As String
        Dim pathStringBuilder As New StringBuilder
        For Each folder As String In folders
            folder = folder.Trim
            If folder.Length > 0 Then
                pathStringBuilder.Append(folder)
                pathStringBuilder.Append(";")
            End If
        Next
        Return pathStringBuilder.ToString()
    End Function
End Module
