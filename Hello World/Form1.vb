Imports System.Threading

Public Class Form1

    Delegate Sub updateCounterDelegate(ByVal newValue As Integer)

    Dim msg As String = "Hello World"

    Private Sub updateCounter(ByVal newValue As Integer)
        Label2.Text = newValue
        Label2.Refresh()
    End Sub

    Public Sub thread1()
        Dim updateCounterCallback As New updateCounterDelegate(AddressOf updateCounter)
        For i As Integer = 0 To 100
            Invoke(updateCounterCallback, i)
            Thread.Sleep(20)
        Next
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Label1.Text = msg
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim t1 As New Thread(AddressOf thread1)
        t1.Start()
    End Sub
End Class
