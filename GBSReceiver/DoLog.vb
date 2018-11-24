Imports System.IO

Public Class DoLog
    Public Shared Sub startLogger()
        Dim logfile As String = writePath & "\Logs\" &
                          Format(Now, "yyyyMMdd") & "_" & "msglog.txt"
        Dim qLog As String = writePath & "\Logs\" &
                          Format(Now, "yyyyMMdd") & "_" & "Queuelog.txt"
        Dim ListenLog As String = writePath & "\Logs\" &
                          Format(Now, "yyyyMMdd") & "_" & "Listenlog.txt"
        Dim ExLog As String = writePath & "\Logs\" &
                          Format(Now, "yyyyMMdd") & "_" & "Exlog.txt"
        Dim ExtLog As String = writePath & "\Logs\" &
                          Format(Now, "yyyyMMdd") & "_" & "Extralog.txt"
        Try
            Dim wlog As Boolean = True
            While wlog
                If LogQueue.Count > 0 Then
                    Dim msg As String = LogQueue.Dequeue()
                    If msg.Substring(0, 1) = "m" Then
                        Try
                            File.AppendAllText(logfile, Format(Now, "HH:mm:ss") & " " &
                                       msg & Environment.NewLine)
                        Catch ex As Exception
                            File.AppendAllText(ExtLog, Format(Now, "HH:mm:ss") & " " & ex.ToString & Environment.NewLine)
                        End Try
                    ElseIf msg.Substring(0, 1) = "q" Then
                        Try
                            File.AppendAllText(qLog, Format(Now, "HH:mm:ss") & " " &
                   msg & Environment.NewLine)
                        Catch ex As Exception
                            File.AppendAllText(ExtLog, Format(Now, "HH:mm:ss") & " " & ex.ToString & Environment.NewLine)
                        End Try
                    ElseIf msg.Substring(0, 1) = "l" Then
                        Try
                            File.AppendAllText(ListenLog, Format(Now, "HH:mm:ss") & " " &
                   msg & Environment.NewLine)
                        Catch ex As Exception
                            File.AppendAllText(ExtLog, Format(Now, "HH:mm:ss") & " " & ex.ToString & Environment.NewLine)
                        End Try
                    Else
                        Try
                            File.AppendAllText(ExLog, Format(Now, "HH:mm:ss") & " " &
                   msg & Environment.NewLine)
                        Catch ex As Exception
                            File.AppendAllText(ExtLog, Format(Now, "HH:mm:ss") & " " & ex.ToString & Environment.NewLine)
                        End Try

                    End If
                    'Threading.Thread.Sleep(1)
                Else
                    Threading.Thread.Sleep(1)
                End If
            End While
        Catch ex As Exception
            File.AppendAllText(ExtLog, Format(Now, "HH:mm:ss") & " " & ex.ToString & Environment.NewLine)
        End Try

    End Sub


End Class
