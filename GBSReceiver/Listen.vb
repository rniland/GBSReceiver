Imports System.Net

Imports System.Globalization
Imports System.IO

Public Class Listen

    Public Shared Sub startListen()
        Try
            Dim prefixes(0) As String
            prefixes(0) = "http://*:8081/"
            ProcessRequests(prefixes)
        Catch ex As Exception
            LogQueue.Enqueue(ex.ToString)
        End Try
    End Sub
    Public Shared Sub ProcessRequests(ByVal prefixes() As String)
        Dim dorun As Boolean = True
        If Not System.Net.HttpListener.IsSupported Then
            Console.WriteLine(
                "Windows XP SP2, Server 2003, or higher is required to " &
                "use the HttpListener class.")
            Exit Sub
        End If
        ' URI prefixes are required,
        If prefixes Is Nothing OrElse prefixes.Length = 0 Then
            Throw New ArgumentException("prefixes")
        End If
        ' Create a listener and add the prefixes.
        Dim listener As System.Net.HttpListener = New System.Net.HttpListener()
        For Each s As String In prefixes

            listener.Prefixes.Add(s)
        Next

        Try
            ' Start the listener to begin listening for requests.
            listener.Start()
            Console.WriteLine("Listening...")
            While dorun
                'Console.Write(s)
                Dim response As HttpListenerResponse = Nothing
                    Try

                        ' Note: GetContext blocks while waiting for a request.
                        Dim context As HttpListenerContext = listener.GetContext()
                        Dim h = context.Request.Headers '.Item("xtype")
                    Dim s = New StreamReader(context.Request.InputStream).ReadToEnd()
                    Console.Write(h)
                    LogQueue.Enqueue("l" & " " & h.ToString())

                    Dim inp As String() = {s, h.Item("xtitle")}

                    If h.Item("xtype") = "meeting" Or h.Item("xtype") = "form" Then
                        mtgQueue.Add(inp)
                    Else
                        priceQueue.Add(inp)
                    End If

                    ' Create the response.
                    response = context.Response
                        Dim responseString As String = "<HTML><BODY>Success</BODY></HTML>"
                        Dim buffer() As Byte = System.Text.Encoding.UTF8.GetBytes(responseString)
                        response.ContentLength64 = buffer.Length
                        Dim output As System.IO.Stream = response.OutputStream
                        output.Write(buffer, 0, buffer.Length)
                    Catch ex As HttpListenerException
                        Console.WriteLine(ex.Message)
                    Finally
                        If response IsNot Nothing Then
                            response.Close()
                        End If
                    End Try
                ' Next
            End While
        Catch ex As HttpListenerException
            Console.WriteLine(ex.Message)
            LogQueue.Enqueue("e - " & ex.ToString)
        Finally
            ' Stop listening for requests.
            listener.Close()
            Console.WriteLine("Done Listening...")
        End Try
    End Sub
End Class
