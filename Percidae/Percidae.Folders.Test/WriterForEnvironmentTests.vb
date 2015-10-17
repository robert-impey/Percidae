Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class WriterForEnvironmentTests

    <TestMethod()> Public Sub SingleFolder()
        Dim input = New List(Of String)
        input.Add("C:\Progs")

        Assert.AreEqual("C:\Progs;", Writer.WriteFoldersForEnvironment(input))
    End Sub

    <TestMethod()> Public Sub MultipleFolders()
        Dim input = New List(Of String)
        input.Add("C:\Progs")
        input.Add("C:\Custom App")
        input.Add("D:\More Progs")

        Assert.AreEqual("C:\Progs;C:\Custom App;D:\More Progs;", Writer.WriteFoldersForEnvironment(input))
    End Sub
End Class