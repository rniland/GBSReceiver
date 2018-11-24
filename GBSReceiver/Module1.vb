Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.Text
Imports System.IO.Compression
Imports System.Collections.Concurrent
Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports System.Threading

Module Module1
    Public CP As New Compression
    Public mtgQueue As New BlockingCollection(Of String())()
    Public priceQueue As New BlockingCollection(Of String())()
    Public WithEvents priceBW As BackgroundWorker = New BackgroundWorker
    Public WithEvents mtgBW As BackgroundWorker = New BackgroundWorker
    Public WithEvents monitorBW As BackgroundWorker = New BackgroundWorker
    Public WithEvents logBW As BackgroundWorker = New BackgroundWorker
    Dim mcancel As Boolean = True
    Public writePath As String = My.Settings.SystemLocalDir & "\" & Format(Now, "yyyyMMdd")

    Public dbconn As MySqlConnection
    Public mtgconn As MySqlConnection
    Dim compressed As Boolean = False
    Public LogQueue As New Queue(Of String)


    Sub Main()
        Try
            createFolders()

            dbconn = New MySqlConnection(DoTRS.conStr())
            mtgconn = New MySqlConnection(DoTRS.conStr())

            priceBW.RunWorkerAsync()
            mtgBW.RunWorkerAsync()
            monitorBW.RunWorkerAsync()
            logBW.RunWorkerAsync()

            Listen.startListen()
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Sub
    Private Sub createFolders()
        Try
            If (Not Directory.Exists(writePath)) Then
                Directory.CreateDirectory(writePath)
            End If
            Dim folders() = {"Derivative", "Acceptances", "PriceUpdate", "RaceStatus", "Rule4", "Results", "Scratching", "Substitute", "Logs", "Txtfiles"}
            For Each f In folders
                If (Not Directory.Exists(writePath & "\" & f)) Then
                    Directory.CreateDirectory(writePath & "\" & f)
                End If
            Next
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Sub
    Private Sub priceBW_DoWork(ByVal sender As System.Object,
                                         ByVal e As DoWorkEventArgs) Handles priceBW.DoWork
        Try
            While mcancel
                While priceQueue.Count > 0
                    Try
                        Dim x = priceQueue.Take
                        Dim px = New parseXML()
                        parseXML.gettop(x.ElementAt(0), x.ElementAt(1))
                    Catch ex As Exception
                        LogQueue.Enqueue("e" & ex.ToString)
                    End Try
                End While
                'Threading.Thread.Sleep(1)
            End While
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Sub
    Private Sub priceBW_RunWorkerCompleted(ByVal sender As System.Object,
                                                     ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                     Handles priceBW.RunWorkerCompleted
        ' Called when the BackgroundWorker is completed.

    End Sub
    Private Sub mtgBW_DoWork(ByVal sender As System.Object,
                                         ByVal e As DoWorkEventArgs) Handles mtgBW.DoWork
        Try
            While mcancel
                If mtgQueue.Count > 0 Then
                    Try
                        Dim mx = New parseXML()
                        Dim x As String() = mtgQueue.Take
                        mx.getAccept(x.ElementAt(0), x.ElementAt(1))
                    Catch ex As Exception
                        LogQueue.Enqueue("e" & ex.ToString)
                    End Try
                End If
                Threading.Thread.Sleep(10)
            End While
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Sub
    Private Sub mtgBW_RunWorkerCompleted(ByVal sender As System.Object,
                                                     ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                     Handles mtgBW.RunWorkerCompleted
        ' Called when the BackgroundWorker is completed.

    End Sub
    Private Sub monitorBW_DoWork(ByVal sender As System.Object,
                                         ByVal e As DoWorkEventArgs) Handles monitorBW.DoWork
        Try
            While mcancel
                LogQueue.Enqueue("q" & "Current Queues: Meeting- " &
                                   mtgQueue.Count() & " Updates- " & priceQueue.Count() &
                                   "::Price Queue " & testBW(priceBW) & "::Mtg Queue " & testBW(mtgBW) &
                                    "::Log Queue " & testBW(logBW))
                Threading.Thread.Sleep(10000)
            End While
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Sub
    Private Sub logBW_DoWork(ByVal sender As System.Object,
                                         ByVal e As DoWorkEventArgs) Handles logBW.DoWork
        Try
            DoLog.startLogger()
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Sub

    Private Function testBW(ByVal bw As BackgroundWorker)
        Try
            If bw.IsBusy Then
                Return " Running"
            Else
                Return " Stalled"
            End If
        Catch ex As Exception
            Return " Stalled"
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Function
    Public Function proc_Derivative(DerivativeXML As String, recName As String)
        Dim MF As New MeetingsFunctions.Functions
        Dim DV As Meetings.derivative = Nothing
        Try
            If compressed Then
                DerivativeXML = CP.DeCompressString(DerivativeXML)
            End If
            DV = MF.DeserializeDerivative(DerivativeXML)
            If DV IsNot Nothing Then
                LogQueue.Enqueue("m" & " - " & "Processing Derivative: " & recName)
                MF.SaveDerivative(DV, writePath & "\Derivative\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml")
            End If
        Catch ex As Exception
            LogQueue.Enqueue("m" & " ERROR: " & writePath & "\RaceStatus\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml" & ex.Message)
        End Try
        Return DV
    End Function
    Public Function proc_Nominations(MeetingXML As String, recName As String)
        Dim MF As New MeetingsFunctions.Functions
        Dim Meeting As Meetings.meeting = MF.DeserializeMeetingXML(MeetingXML)
        Try
            If compressed Then
                MeetingXML = CP.DeCompressString(MeetingXML)
            End If
            If Meeting IsNot Nothing Then
                Try
                    LogQueue.Enqueue("m" & " - " & "Processing Meeting: " & recName)
                    MF.SaveMeeting(Meeting, writePath & "\Acceptances\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml")
                Catch ex As Exception
                    LogQueue.Enqueue("m" & "Processing meeting name: " & Meeting.track.name & " Date: " & Meeting.date & " ERROR loading: " & ex.Message)
                End Try
            End If
        Catch ex As Exception
            LogQueue.Enqueue("m" & " ERROR: " & ex.Message)
        End Try
        Return Meeting
    End Function
    Public Function proc_RaceStatus(RaceStatusXML As String, recName As String)
        Dim MF As New MeetingsFunctions.Functions
        Dim RS As Meetings.RaceStatus = Nothing
        Try
            If compressed Then
                RaceStatusXML = CP.DeCompressString(RaceStatusXML)
            End If
            RS = MF.DeserializeRaceStatusstring(RaceStatusXML)
            If RS IsNot Nothing Then
                LogQueue.Enqueue("m" & " - " & "Processing Race Status: " & recName)
                MF.SaveRaceStatus(RS, writePath & "\RaceStatus\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml")
            End If
        Catch ex As Exception
            LogQueue.Enqueue("m" & " ERROR: " & writePath & "\RaceStatus\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml" & ex.Message)
        End Try
        Return RS
    End Function
    Public Function proc_Rule4(Rule4XML As String, recName As String)
        Dim MF As New MeetingsFunctions.Functions
        Dim RS As Meetings.Rule4 = Nothing
        Try
            If compressed Then
                Rule4XML = CP.DeCompressString(Rule4XML)
            End If
            RS = MF.DeserializeRule4string(Rule4XML)
            If RS IsNot Nothing Then
                LogQueue.Enqueue("m" & " - " & "Processing Race Status: " & recName)
                MF.SaveRule4(RS, writePath & "\Rule4\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml")
            End If
        Catch ex As Exception
            LogQueue.Enqueue("m" & " ERROR: " & writePath & "\Rule4\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml" & ex.Message)
        End Try
        Return RS
    End Function
    Public Function proc_Results(ResultXML As String, recName As String)
        Dim MF As New MeetingsFunctions.Functions
        Dim Res As Meetings.ResultType = Nothing
        Try
            If compressed Then
                ResultXML = CP.DeCompressString(ResultXML)
            End If
            Res = MF.DeserializeResultstring(ResultXML)

            If Res IsNot Nothing Then
                LogQueue.Enqueue("m" & " - " & "Processing Result: " & recName)
                MF.SaveResult(Res, writePath & "\Results\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml")
            End If
        Catch ex As Exception
            LogQueue.Enqueue("m" & " ERROR: " & "Processing Result: " & ex.Message)
        End Try
        Return Res
    End Function
    Public Function proc_PriceUpdate(PriceUpdateXML As String, recName As String)
        Dim MF As New MeetingsFunctions.Functions
        Dim Pud As Meetings.PriceUpdateType = Nothing
        Try
            If compressed Then
                PriceUpdateXML = CP.DeCompressString(PriceUpdateXML)
            End If

            Pud = MF.DeserializePriceUpdateString(PriceUpdateXML)
            If Pud IsNot Nothing Then
                LogQueue.Enqueue("m" & " - " & "Processing Price: " & Pud.MeetingID &
                               "_" & Pud.Source.ToString & "_" & Pud.RaceNo)
                MF.SavePriceUpdate(Pud, writePath & "\PriceUpdate\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml")
            End If
        Catch ex As Exception
            LogQueue.Enqueue("m" & " ERROR: " & "Processing Price: " & ex.Message)
        End Try
        Return Pud
    End Function
    Public Function proc_Substitutes(SubsXML As String, recName As String)
        Dim MF As New MeetingsFunctions.Functions
        Dim Subs As Meetings.SubstituteType = Nothing
        Try
            If compressed Then
                SubsXML = CP.DeCompressString(SubsXML)
            End If
            Subs = MF.DeserializeSubstituteString(SubsXML)
            If Subs IsNot Nothing Then
                LogQueue.Enqueue("m" & " - " & "Processing Subs: " & recName)
                MF.SaveSub(Subs, writePath & "\Substitute\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml")
            End If
        Catch ex As Exception
            LogQueue.Enqueue("m" & " ERROR: " & "Processing Substitute: " & ex.Message)
        End Try
        Return Subs
    End Function
    Public Function proc_Scratching(SCRXML As String, recName As String)
        Dim MF As New MeetingsFunctions.Functions
        Dim Scr As Meetings.ScratchingType = Nothing
        Try
            If compressed Then
                SCRXML = CP.DeCompressString(SCRXML)
            End If

            Scr = MF.DeserializeScratchingtring(SCRXML)
            If Scr IsNot Nothing Then
                LogQueue.Enqueue("m" & " - " & "Processing Scratch: " & recName)
                MF.SaveScr(Scr, writePath & "\Scratching\" & recName & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xml")
            End If
        Catch ex As Exception
            LogQueue.Enqueue("m" & " ERROR: " & "Processing Scratching: " & ex.Message)
        End Try
        Return Scr
    End Function
    Public Sub PrintDebug(ByVal Message As String, Optional ByVal DLevel As Integer = 4)
        '1 - critical
        '2 - Error
        '3 - Informational Error
        '4 - Information
        '5 - system logging
        Message = Format(Now, "HH:mm:ss") & "<GBSService><" & DLevel & ">" & Message
        Debug.WriteLine(Message)
        Console.WriteLine(Message)
        LogQueue.Enqueue("m" & Message & vbCrLf)
        'File.AppendAllText(logfile, Message & vbCrLf)
    End Sub
    ' Step 6: Define a service contract.
    <ServiceContract([Namespace]:="http://RacingServices.Feeds.BettorData")> _
    Public Interface iGBSWSService
        <OperationContract()> _
        Sub Nominations(ByVal MeetingXML As String)
        <OperationContract()> _
        Sub RaceStatus(ByVal RaceStatusXML As String)
        <OperationContract()> _
        Sub Results(ByVal ResultXML As String)
        <OperationContract()> _
        Sub PriceUpdate(ByVal PriceUpdateXML As String)
        <OperationContract()> _
        Sub Substitutes(ByVal subsXML As String)
        <OperationContract()> _
        Sub Scratching(ByVal scrXML As String)
    End Interface

End Module
Public Class Compression
    Public Function CompressString(StringtoCompress As String) As String
        Using outStream As New MemoryStream()
            Using tinyStream As New GZipStream(outStream, CompressionMode.Compress)
                Using mStream As New MemoryStream(Encoding.UTF8.GetBytes(StringtoCompress))
                    CopyTo(mStream, tinyStream)
                End Using
            End Using
            Return Convert.ToBase64String(outStream.ToArray)
        End Using
    End Function
    Public Function DeCompressString(StringToDecompress As String) As String
        Using inStream As New MemoryStream(Convert.FromBase64String(StringToDecompress))
            Using bigStream As New GZipStream(inStream, CompressionMode.Decompress)
                Using bigStreamOut As New MemoryStream()
                    CopyTo(bigStream, bigStreamOut)
                    Return Encoding.UTF8.GetString(bigStreamOut.ToArray())
                End Using
            End Using
        End Using
    End Function
    Public Sub CopyTo(input As Stream, output As Stream)
        Using reader As New StreamReader(input)
            Using writer As New StreamWriter(output)
                writer.Write(reader.ReadToEnd())
            End Using
        End Using
    End Sub
End Class
