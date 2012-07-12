Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading

Module networking

    Public stpd As Boolean = True

    Public Sub startSyncServer()
        Dim soc As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim ipAddr As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim localAddr As New IPEndPoint(ipAddr, 11000)
        Dim conn As Socket
        Dim thrd As Thread

        soc.Bind(localAddr)
        soc.Listen(10)

        While Not stpd
            conn = soc.Accept()
            thrd = New Thread(AddressOf worker)
            thrd.Start(conn)
        End While

        soc.Close()
    End Sub

    Private Sub worker(ByVal s As Socket)
        Dim msg As Byte() = Encoding.UTF8.GetBytes("ConnectionState established")
        Thread.Sleep(1000)
        s.Send(msg)

        Thread.Sleep(10000)
        s.Shutdown(SocketShutdown.Both)
        s.Close()
    End Sub
End Module
