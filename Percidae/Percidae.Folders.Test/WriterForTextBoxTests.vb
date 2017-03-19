Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class WriterForTextBoxTests

    <TestMethod()> Public Sub SingleFolder()
        Dim input = New List(Of String)
        input.Add("C:\Progs")

        Dim output = Writer.WriteFoldersForTextBox(input)
        Assert.AreEqual("C:\Progs;
", output)
    End Sub

    <TestMethod()> Public Sub MultipleFolders()
        Dim input = New List(Of String)
        input.Add("C:\Progs")
        input.Add("C:\Custom App")
        input.Add("D:\More Progs")

        Dim output = Writer.WriteFoldersForTextBox(input)
        Assert.AreEqual("C:\Progs;
C:\Custom App;
D:\More Progs;
", output)
    End Sub

End Class