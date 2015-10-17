Public Module Parser
    Public Function ParsePath(ByVal path As String) As IEnumerable(Of String)
        Dim folders = path.Split(";")
        Return folders.Where(Function(x) (Not String.IsNullOrWhiteSpace(x)))
    End Function
End Module
