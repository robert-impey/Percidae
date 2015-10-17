Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ParserTests

    <TestMethod> Public Sub SingleFolderPath()
        Dim input = "C:\Progs;"
        Dim folders = ParsePath(input)

        Assert.AreEqual(1, folders.Count)
    End Sub

    <TestMethod> Public Sub SingleFolderPathNoSemiColon()
        Dim input = "C:\Progs"
        Dim folders = ParsePath(input)

        Assert.AreEqual(1, folders.Count)
    End Sub

    <TestMethod()> Public Sub MultiLinePath()
        Dim input = "
C:\Progs;
C:\My Progs;
D:\Custom App;
"
        Dim folders = ParsePath(input)

        Assert.AreEqual(3, folders.Count)
    End Sub

    <TestMethod()> Public Sub MultiLinePathWithBlankLines()
        Dim input = "
C:\Progs;

C:\My Progs;

D:\Custom App;
"
        Dim folders = ParsePath(input)

        Assert.AreEqual(3, folders.Count)
    End Sub
End Class