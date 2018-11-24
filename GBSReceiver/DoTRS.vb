Imports System.IO
Imports MySql.Data.MySqlClient

Public Class DoTRS
    Public Shared Function conStr()
        Return File.ReadAllText("C:\Connections\trs.txt").Replace("admin", "gbs")
    End Function
    Public Function doConnect()
        LogQueue.Enqueue("e" & " Openning TRS connection")

        Dim con As String = conStr()
        Dim dbconn As MySqlConnection = New MySqlConnection(con)
        If Not (dbconn.State = System.Data.ConnectionState.Open) Then
            dbconn.Open()
        End If
        Return dbconn
    End Function
    Public Function testConnect(ByVal dbconn As MySqlConnection)
        If Not (dbconn.State = System.Data.ConnectionState.Open) Then
            Return False
        End If
        Return True
    End Function
    Public Shared Sub doIns(ByVal qry As String, dconn As MySqlConnection)
        Try
            If Not (dconn.State = System.Data.ConnectionState.Open) Then
                dconn.Open()
            End If

            Dim cmd As MySqlCommand = New MySqlCommand(qry, dconn)
            cmd.CommandText = qry
            cmd.Connection = dconn
            cmd.ExecuteNonQuery()

            'cmd.Dispose()
        Catch ex As Exception
            LogQueue.Enqueue("e" & " - " & "::::" & qry & "::::" & ex.ToString)

        End Try

    End Sub
End Class
