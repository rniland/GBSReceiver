Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Globalization
Imports System.Text
Imports System.Reflection
Imports System.Text.RegularExpressions

Namespace MeetingsFunctions

    Public Class Functions

        Public Shared Function GetXMLEnumAttrName(en As [Enum]) As String
            Dim type As Type = en.[GetType]()

            Dim memInfo As MemberInfo() = type.GetMember(en.ToString())

            If memInfo IsNot Nothing AndAlso memInfo.Length > 0 Then
                Dim attrs As Object() = memInfo(0).GetCustomAttributes(GetType(XmlEnumAttribute), False)

                If attrs IsNot Nothing AndAlso attrs.Length > 0 Then
                    Return DirectCast(attrs(0), XmlEnumAttribute).Name
                End If
            End If

            Return en.ToString()
        End Function
        Public Function GetMeetingTypeType(MeetingTypeName As String) As Meetings.MeetingTypeIndicator

            If MeetingTypeName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.MeetingTypeIndicator), MeetingTypeName), Meetings.MeetingTypeIndicator)
                Catch
                    Return Meetings.MeetingTypeIndicator.Other
                End Try
            Else
                Return Meetings.MeetingTypeIndicator.Other
            End If
        End Function
        Public Function GetMeetingTypeAttributeValue(Mtype As Meetings.MeetingTypeIndicator) As String
            Try
                Return DirectCast(GetType(Meetings.MeetingTypeIndicator).GetMember(Mtype.ToString())(0).GetCustomAttributes(GetType(XmlEnumAttribute), False)(0), XmlEnumAttribute).Name
            Catch
                Return ""
            End Try
        End Function

        Public Function GetSurfaceType(SurfaceTypeName As String) As Meetings.SurfaceType
            If SurfaceTypeName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.SurfaceType), SurfaceTypeName), Meetings.SurfaceType)
                Catch
                    Return Meetings.SurfaceType.Unknown
                End Try
            Else
                Return Meetings.SurfaceType.Unknown
            End If
        End Function
        Public Function GetSourceType(SourceName As String) As Meetings.SourcePool
            If SourceName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.SourcePool), SourceName), Meetings.SourcePool)
                Catch
                    Return Meetings.SourcePool.RacingServices100
                End Try
            Else
                Return Meetings.SourcePool.RacingServices100
            End If
        End Function
        Public Function GetSourcePoolAttributeValue(SPool As Meetings.SourcePool) As String
            Try
                Return DirectCast(GetType(Meetings.SourcePool).GetMember(SPool.ToString())(0).GetCustomAttributes(GetType(XmlEnumAttribute), False)(0), XmlEnumAttribute).Name
            Catch
                Return ""
            End Try
        End Function
        Public Function GetBetType(BetTypeName As String) As Meetings.BetType
            If BetTypeName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.BetType), BetTypeName), Meetings.BetType)
                Catch
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If
        End Function
        Public Function GetBettingStatusType(BettingStatusName As String) As Meetings.RaceStatusIndicator
            If BettingStatusName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.RaceStatusIndicator), BettingStatusName), Meetings.RaceStatusIndicator)
                Catch
                    Return Meetings.RaceStatusIndicator.UNKNOWN
                End Try
            Else
                Return Meetings.RaceStatusIndicator.UNKNOWN
            End If
        End Function
        Public Function GetGait(GaitName As String) As Meetings.GaitIndicator
            If GaitName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.GaitIndicator), GaitName), Meetings.GaitIndicator)
                Catch
                    Return Meetings.GaitIndicator.Gallop
                End Try
            Else
                Return Meetings.GaitIndicator.Gallop
            End If
        End Function
        Public Function GetGroup(GroupName As String) As Meetings.group
            If Not String.IsNullOrEmpty(GroupName) Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.group), GroupName), Meetings.group)
                Catch
                    Return Meetings.group.LR
                End Try
            Else
                Return Meetings.group.LR
            End If
        End Function
        Public Function GetTrackCondition(TrackConditionName As String) As Meetings.TrackTypeCondition
            If TrackConditionName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.TrackTypeCondition), StrConv(TrackConditionName, vbProperCase)), Meetings.TrackTypeCondition)
                Catch
                    Return Meetings.TrackTypeCondition.Unknown
                End Try
            Else
                Return Meetings.TrackTypeCondition.Unknown
            End If
        End Function

        Public Function GetStatusType(StatusTypeName As String) As Meetings.StatusIndicator
            If StatusTypeName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.StatusIndicator), StatusTypeName), Meetings.StatusIndicator)
                Catch
                    Return Meetings.StatusIndicator.Starter
                End Try
            Else
                Return Meetings.StatusIndicator.Starter
            End If
        End Function
        Public Function GetColourType(ColourName As String) As Meetings.HorseTypeColour
            If ColourName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.HorseTypeColour), ColourName), Meetings.HorseTypeColour)
                Catch
                    Return Meetings.HorseTypeColour.unknown
                End Try
            Else
                Return Meetings.HorseTypeColour.unknown
            End If
        End Function
        Public Function GetColourTypeDefBlk(ColourName As String) As Meetings.HorseTypeColour
            If ColourName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.HorseTypeColour), ColourName), Meetings.HorseTypeColour)
                Catch
                    Return Meetings.HorseTypeColour.bk
                End Try
            Else
                Return Meetings.HorseTypeColour.bk
            End If
        End Function
        Public Function GetColourTypeDefBay(ColourName As String) As Meetings.HorseTypeColour
            If ColourName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.HorseTypeColour), ColourName), Meetings.HorseTypeColour)
                Catch
                    Return Meetings.HorseTypeColour.b
                End Try
            Else
                Return Meetings.HorseTypeColour.b
            End If
        End Function
        Public Function GetSexType(SexName As String) As Meetings.HorseTypeSex
            If SexName IsNot Nothing Then
                Try
                    Return CType([Enum].Parse(GetType(Meetings.HorseTypeSex), SexName), Meetings.HorseTypeSex)
                Catch
                    Return Meetings.HorseTypeSex.U
                End Try
            Else
                Return Meetings.HorseTypeSex.U
            End If
        End Function

        Public Function SaveMeeting(ByVal Meeting As Meetings.meeting, ByVal FileName As String) As Boolean
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.meeting))
                Dim writer As TextWriter = New StreamWriter(FileName)
                serializer.Serialize(writer, Meeting)
                writer.Close()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function SaveRaceStatus(ByVal racest As Meetings.RaceStatus, ByVal FileName As String) As Boolean
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.RaceStatus))
                Dim writer As TextWriter = New StreamWriter(FileName)
                serializer.Serialize(writer, racest)
                writer.Close()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function SaveRule4(ByVal rule4 As Meetings.Rule4, ByVal FileName As String) As Boolean
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.Rule4))
                Dim writer As TextWriter = New StreamWriter(FileName)
                serializer.Serialize(writer, rule4)
                writer.Close()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function SaveResult(ByVal Res As Meetings.ResultType, ByVal FileName As String) As Boolean
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.ResultType))
                Dim writer As TextWriter = New StreamWriter(FileName)
                serializer.Serialize(writer, Res)
                writer.Close()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function SavePriceUpdate(ByVal PriceUp As Meetings.PriceUpdateType, ByVal FileName As String) As Boolean
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.PriceUpdateType))
                Dim writer As TextWriter = New StreamWriter(FileName)
                serializer.Serialize(writer, PriceUp)
                writer.Close()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function SaveSub(ByVal subs As Meetings.SubstituteType, ByVal FileName As String) As Boolean
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.SubstituteType))
                Dim writer As TextWriter = New StreamWriter(FileName)
                serializer.Serialize(writer, subs)
                writer.Close()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function SaveScr(ByVal Scr As Meetings.ScratchingType, ByVal FileName As String) As Boolean
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.ScratchingType))
                Dim writer As TextWriter = New StreamWriter(FileName)
                serializer.Serialize(writer, Scr)
                writer.Close()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function ConvertMeetingListXML(ByVal meetinglist As Meetings.MeetingList) As XmlDocument
            Dim doc As New XmlDocument()
            doc.LoadXml(SerializeMeetingList(meetinglist))
            Return doc
        End Function
        Public Function ConvertMeetingXML(ByVal meeting As Meetings.meeting) As XmlDocument
            Dim doc As New XmlDocument()
            doc.LoadXml(SerializeMeeting(meeting))
            Return doc
        End Function

        Public Function ConvertRaceXML(ByVal Race As Meetings.RaceType) As XmlDocument
            Dim doc As New XmlDocument()
            doc.LoadXml(SerializeRace(Race))
            Return doc
        End Function
        Public Function ConvertResultXML(ByVal Result As Meetings.ResultType) As XmlDocument
            Dim doc As New XmlDocument()
            doc.LoadXml(SerializeResult(Result))
            Return doc
        End Function
        Public Function ConvertSubXML(ByVal Subs As Meetings.SubstituteType) As XmlDocument
            Dim doc As New XmlDocument()
            doc.LoadXml(SerializeSubs(Subs))
            Return doc
        End Function
        Public Sub SaveRace(ByVal FName As String, ByVal Meeting As Meetings.RaceType)
            Dim serializer As New XmlSerializer(GetType(Meetings.RaceType))
            Dim writer As TextWriter = New StreamWriter(FName)
            serializer.Serialize(writer, Meeting)
            writer.Close()
        End Sub
        Public Sub SaveMeeting(ByVal FName As String, ByVal Meeting As Meetings.meeting)
            Dim serializer As New XmlSerializer(GetType(Meetings.meeting))
            Dim writer As TextWriter = New StreamWriter(FName)
            serializer.Serialize(writer, Meeting)
            writer.Close()
        End Sub
        Public Sub SaveMeetingList(ByVal FName As String, ByVal MList As Meetings.MeetingList)
            Dim serializer As New XmlSerializer(GetType(Meetings.MeetingList))
            Dim writer As TextWriter = New StreamWriter(FName)
            serializer.Serialize(writer, MList)
            writer.Close()
        End Sub
        Public Function SerializeFileData(ByVal FileDat As Meetings.FileData) As String
            Try
                Dim FDSerializer As New XmlSerializer(GetType(Meetings.FileData))
                Dim sw As StringWriter = New StringWriter()
                FDSerializer.Serialize(sw, FileDat)
                sw.Close()
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeMeetingList(ByVal Mlist As Meetings.MeetingList) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.MeetingList))
                Dim sw As StringWriter = New StringWriter()
                MeetingSerializer.Serialize(sw, Mlist)
                sw.Close()
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeMeetingXML(ByVal meeting As Meetings.meeting) As XmlDocument
            Dim ser As New XmlSerializer(GetType(Meetings.meeting))
            Dim sb As New System.Text.StringBuilder()
            Dim writer As New System.IO.StringWriter(sb)
            ser.Serialize(writer, meeting)
            Dim doc As New XmlDocument()
            doc.LoadXml(sb.ToString())
            Return doc
        End Function
        Public Function SerializeMeeting(ByVal Meeting As Meetings.meeting) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.meeting))
                Dim sw As StringWriter = New StringWriter()
                MeetingSerializer.Serialize(sw, Meeting)
                sw.Close()
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeForm(ByVal Runner As Meetings.FormType) As String
            Try
                Dim RunnerSerializer As New XmlSerializer(GetType(Meetings.FormType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                RunnerSerializer.Serialize(sw, Runner)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeHorse(ByVal Runner As Meetings.HorseType) As String
            Try
                Dim RunnerSerializer As New XmlSerializer(GetType(Meetings.HorseType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                RunnerSerializer.Serialize(sw, Runner)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeHorses(ByVal Runners As Meetings.HorseType()) As String
            Try
                Dim RunnerSerializer As New XmlSerializer(GetType(Meetings.HorseType()))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                RunnerSerializer.Serialize(sw, Runners)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeMeetingLists(ByVal Mlists As Meetings.MeetingList()) As String
            Try
                Dim RunnerSerializer As New XmlSerializer(GetType(Meetings.MeetingList()))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                RunnerSerializer.Serialize(sw, Mlists)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeHorseList(ByVal RunnerList As Meetings.HorseList) As String
            Try
                Dim RunnerSerializer As New XmlSerializer(GetType(Meetings.HorseList))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                RunnerSerializer.Serialize(sw, RunnerList)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function

        Public Function SerializeRace(ByVal Race As Meetings.RaceType) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.RaceType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, Race)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeResult(ByVal Res As Meetings.ResultType) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.ResultType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, Res)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeRaceStatus(ByVal rStat As Meetings.RaceStatus) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.RaceStatus))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, rStat)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeScratching(ByVal rStat As Meetings.ScratchingType) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.ScratchingType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, rStat)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeResultsXML(ByVal RaceResults As Meetings.ResultType) As XmlDocument
            Dim ser As New XmlSerializer(GetType(Meetings.ResultType))
            Dim sb As New System.Text.StringBuilder()
            Dim writer As New System.IO.StringWriter(sb)
            ser.Serialize(writer, RaceResults)
            Dim doc As New XmlDocument()
            doc.LoadXml(sb.ToString())
            Return doc
        End Function
        Public Function SerializeSubsXML(ByVal Subs As Meetings.SubstituteType) As XmlDocument
            Dim ser As New XmlSerializer(GetType(Meetings.SubstituteType))
            Dim sb As New System.Text.StringBuilder()
            Dim writer As New System.IO.StringWriter(sb)
            ser.Serialize(writer, Subs)
            Dim doc As New XmlDocument()
            doc.LoadXml(sb.ToString())
            Return doc
        End Function

        Public Function SerializeSubs(ByVal Subs As Meetings.SubstituteType) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.SubstituteType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, Subs)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeTabPools(ByVal TabPools As Meetings.TABPoolType()) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.TABPoolType()))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, TabPools)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializePrices(ByVal Price As Meetings.PriceType) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.PriceType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, Price)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializePriceUpdates(ByVal PriceUpdate As Meetings.PriceUpdateType) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.PriceUpdateType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, PriceUpdate)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function SerializeExoticPriceUpdates(ByVal ExoticPriceUpdate As Meetings.ExoticPriceUpdateType) As String
            Try
                Dim MeetingSerializer As New XmlSerializer(GetType(Meetings.ExoticPriceUpdateType))
                Dim sw As StringWriter = New StringWriter()
                ' Serialize the object
                MeetingSerializer.Serialize(sw, ExoticPriceUpdate)
                ' Close the stream
                sw.Close()
                ' Save the XML as a string
                Return sw.GetStringBuilder().ToString()
            Catch
                Return ""
            End Try
        End Function
        Public Function DeserializeFileData(ByVal FileDat As String) As Meetings.FileData
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(FileDat)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.FileData))
            Dim FData As Meetings.FileData = ser.Deserialize(reader)
            Return DirectCast(FData, Meetings.FileData)
        End Function
        Public Function DeserializeMeetingListXML(ByVal MeetingXML As XmlDocument) As Meetings.MeetingList
            Dim reader As New XmlNodeReader(MeetingXML.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.MeetingList))
            Dim MeetingList As Meetings.MeetingList = ser.Deserialize(reader)
            Return DirectCast(MeetingList, Meetings.MeetingList)
        End Function
        Public Function DeserializeMeetingListXML(ByVal MeetingText As String) As Meetings.MeetingList
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(MeetingText)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.MeetingList))
            Dim MeetingList As Meetings.MeetingList = ser.Deserialize(reader)
            Return DirectCast(MeetingList, Meetings.MeetingList)
        End Function
        Public Function DeserializeRaceString(ByVal RaceText As String) As Meetings.RaceType
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(RaceText)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.RaceType))
            Dim Race As Meetings.RaceType = ser.Deserialize(reader)
            Return DirectCast(Race, Meetings.RaceType)
        End Function
        Public Function DeserializeForm(ByVal FormText As String) As Meetings.FormType
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(FormText)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.FormType))
            Dim Fr As Meetings.FormType = ser.Deserialize(reader)
            Return DirectCast(Fr, Meetings.FormType)
        End Function
        Public Function DeserializeHorse(ByVal HorseText As String) As Meetings.HorseType
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(HorseText)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.HorseType))
            Dim Runner As Meetings.HorseType = ser.Deserialize(reader)
            Return DirectCast(Runner, Meetings.HorseType)
        End Function

        Public Function DeserializeHorseList(ByVal HorseListText As String) As Meetings.HorseList
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(HorseListText)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.HorseList))
            Dim RunnerList As Meetings.HorseList = ser.Deserialize(reader)
            Return DirectCast(RunnerList, Meetings.HorseList)
        End Function
        Public Function DeserializePriceUpdateString(ByVal PriceUpdate As String) As Meetings.PriceUpdateType
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(PriceUpdate)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.PriceUpdateType))
            Dim PriceUp As Meetings.PriceUpdateType = ser.Deserialize(reader)
            Return DirectCast(PriceUp, Meetings.PriceUpdateType)
        End Function
        Public Function DeserializeExoticUpdateString(ByVal ExoticUpdate As String) As Meetings.ExoticPriceUpdateType
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(ExoticUpdate)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.ExoticPriceUpdateType))
            Dim ExoticUp As Meetings.ExoticPriceUpdateType = ser.Deserialize(reader)
            Return DirectCast(ExoticUp, Meetings.ExoticPriceUpdateType)
        End Function
        Public Function DeserializeSubstituteString(ByVal SubsXML As String) As Meetings.SubstituteType
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(SubsXML)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.SubstituteType))
            Dim ReturnSub As Meetings.SubstituteType = ser.Deserialize(reader)
            Return DirectCast(ReturnSub, Meetings.SubstituteType)
        End Function
        Public Function DeserializeScratchingtring(ByVal SCRXML As String) As Meetings.ScratchingType
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(SCRXML)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.ScratchingType))
            Dim ReturnScr As Meetings.ScratchingType = ser.Deserialize(reader)
            Return DirectCast(ReturnScr, Meetings.ScratchingType)
        End Function
        Public Function DeserializeResultstring(ByVal ResultXML As String) As Meetings.ResultType
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(ResultXML)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.ResultType))
            Dim ReturnRes As Meetings.ResultType = ser.Deserialize(reader)
            Return DirectCast(ReturnRes, Meetings.ResultType)
        End Function
        Public Function DeserializeFileResult(FileName As String) As Meetings.ResultType
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.ResultType))
                Dim reader As TextReader = New StreamReader(FileName)
                Dim Res As Meetings.ResultType = DirectCast(serializer.Deserialize(reader), Meetings.ResultType)
                reader.Close()
                Return Res
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Function
        Public Function DeserializeFileSubstitute(FileName As String) As Meetings.SubstituteType
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.SubstituteType))
                Dim reader As TextReader = New StreamReader(FileName)
                Dim Subs As Meetings.SubstituteType = DirectCast(serializer.Deserialize(reader), Meetings.SubstituteType)
                reader.Close()
                Return Subs
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Function
        Public Function DeserializeRaceStatusstring(ByVal RsXML As String) As Meetings.RaceStatus
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(RsXML)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.RaceStatus))
            Dim ReturnRs As Meetings.RaceStatus = ser.Deserialize(reader)
            Return DirectCast(ReturnRs, Meetings.RaceStatus)
        End Function
        Public Function DeserializeRule4string(ByVal R4XML As String) As Meetings.Rule4
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(R4XML)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.Rule4))
            Dim ReturnRs As Meetings.Rule4 = ser.Deserialize(reader)
            Return DirectCast(ReturnRs, Meetings.Rule4)
        End Function
        Public Function DeserializeTabPools(ByVal TabPoolText As String) As Meetings.TABPoolType()
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(TabPoolText)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.TABPoolType()))
            Dim TPools As Meetings.TABPoolType() = ser.Deserialize(reader)
            Return DirectCast(TPools, Meetings.TABPoolType())
        End Function
        Public Function DeserializeHorses(ByVal HorsesText As String) As Meetings.HorseType()
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(HorsesText)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.HorseType()))
            Dim Horses As Meetings.HorseType() = ser.Deserialize(reader)
            Return DirectCast(Horses, Meetings.HorseType())
        End Function
        Public Function DeserializeMeetingLists(ByVal MlistsText As String) As Meetings.MeetingList()
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(MlistsText)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.MeetingList()))
            Dim Mlists As Meetings.MeetingList() = ser.Deserialize(reader)
            Return DirectCast(Mlists, Meetings.MeetingList())
        End Function
        Public Function DeserializeFileRace(ByVal Filename As String) As Meetings.RaceType
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.RaceType))
                Dim reader As TextReader = New StreamReader(Filename)
                Dim Race As Meetings.RaceType = DirectCast(serializer.Deserialize(reader), Meetings.RaceType)
                reader.Close()
                Return Race
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Function
        Public Function DeserializeFileMeeting(ByVal Filename As String) As Meetings.meeting
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.meeting))
                Dim reader As TextReader = New StreamReader(Filename)
                Dim Meeting As Meetings.meeting = DirectCast(serializer.Deserialize(reader), Meetings.meeting)
                reader.Close()
                Return Meeting
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Function
        Public Function DeserializeFileMeetingList(ByVal Filename As String) As Meetings.MeetingList
            Try
                Dim serializer As New XmlSerializer(GetType(Meetings.MeetingList))
                Dim reader As TextReader = New StreamReader(Filename)
                Dim MeetingList As Meetings.MeetingList = DirectCast(serializer.Deserialize(reader), Meetings.MeetingList)
                reader.Close()
                Return MeetingList
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Function
        Public Function DeserializeMeetingXML(ByVal Meetingtext As String) As Meetings.meeting
            Dim xDoc As New XmlDocument
            xDoc.LoadXml(Meetingtext)
            Dim reader As New XmlNodeReader(xDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.meeting))
            Dim Meeting As Meetings.meeting = ser.Deserialize(reader)
            Return DirectCast(Meeting, Meetings.meeting)
        End Function
        Public Function DeserializeMeetingXML(ByVal MeetingDoc As XmlDocument) As Meetings.meeting
            Dim reader As New XmlNodeReader(MeetingDoc.DocumentElement)
            Dim ser As New XmlSerializer(GetType(Meetings.meeting))
            Dim Meeting As Meetings.meeting = ser.Deserialize(reader)
            Return DirectCast(Meeting, Meetings.meeting)
        End Function
        Public Function DeserializeDerivative(ByVal Derivtring As String) As Meetings.derivative
            If String.IsNullOrEmpty(Derivtring) Then Return Nothing
            Dim xDoc As XmlDocument = Nothing
            Dim reader As XmlNodeReader = Nothing
            Dim ser As XmlSerializer = Nothing
            Try
                xDoc = New XmlDocument
                xDoc.LoadXml(Derivtring)
                reader = New XmlNodeReader(xDoc.DocumentElement)
                ser = New XmlSerializer(GetType(Meetings.derivative))
                Return DirectCast(ser.Deserialize(reader), Meetings.derivative)
            Catch
                Return Nothing
            Finally
                xDoc = Nothing
                If reader IsNot Nothing Then
                    reader.Close()
                    reader = Nothing
                End If
                ser = Nothing
            End Try
        End Function
        Public Sub SaveDerivative(ByVal Deriv As Meetings.derivative, ByVal FName As String)
            Dim serializer As XmlSerializer = Nothing
            Dim writer As TextWriter = Nothing
            Try
                FName = FName.Replace("""", "")
                serializer = New XmlSerializer(GetType(Meetings.derivative))
                writer = New StreamWriter(FName)
                serializer.Serialize(writer, Deriv)
            Catch ex As Exception
                Trace.WriteLine("Error Saving file: " & FName & " Err: " & ex.Message)
            Finally
                If writer IsNot Nothing Then
                    writer.Close()
                    writer.Dispose()
                End If
                serializer = Nothing
            End Try
        End Sub
    End Class
End Namespace
Namespace Meetings


    '
    'This source code was auto-generated by xsd, Version=4.0.30319.33440.
    '

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class MeetingList

        Private meetingsField() As ArrayOfMeetingMeeting

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("meeting", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Meetings() As ArrayOfMeetingMeeting()
            Get
                Return Me.meetingsField
            End Get
            Set
                Me.meetingsField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfMeetingMeeting

        Private dateField As String

        Private tab_indicatorField As String

        Private meetingTypeField As ArrayOfMeetingMeetingMeetingType

        Private trackField As TrackType

        Private advancedGoingField As String

        Private rail_positionField As String

        Private toteCodesField() As ToteCodeType

        Private productField As ProductType

        Private stageField As String

        Private meetingidField As Long

        Private meetingidFieldSpecified As Boolean

        Private versionField As Integer

        Private versionFieldSpecified As Boolean

        Private validatedField As Boolean

        Private validatedFieldSpecified As Boolean

        Private numberOfRacesField As Integer

        Private numberOfRacesFieldSpecified As Boolean

        Private externalMeetingIDField As String

        Private meetingSourceField As ArrayOfMeetingMeetingMeetingSource

        Private meetingSourceFieldSpecified As Boolean

        Private racesField() As RaceType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property [date]() As String
            Get
                Return Me.dateField
            End Get
            Set
                Me.dateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property tab_indicator() As String
            Get
                Return Me.tab_indicatorField
            End Get
            Set
                Me.tab_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property MeetingType() As ArrayOfMeetingMeetingMeetingType
            Get
                Return Me.meetingTypeField
            End Get
            Set
                Me.meetingTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property track() As TrackType
            Get
                Return Me.trackField
            End Get
            Set
                Me.trackField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AdvancedGoing() As String
            Get
                Return Me.advancedGoingField
            End Get
            Set
                Me.advancedGoingField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property rail_position() As String
            Get
                Return Me.rail_positionField
            End Get
            Set
                Me.rail_positionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("ToteCode", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property ToteCodes() As ToteCodeType()
            Get
                Return Me.toteCodesField
            End Get
            Set
                Me.toteCodesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property product() As ProductType
            Get
                Return Me.productField
            End Get
            Set
                Me.productField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property stage() As String
            Get
                Return Me.stageField
            End Get
            Set
                Me.stageField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Meetingid() As Long
            Get
                Return Me.meetingidField
            End Get
            Set
                Me.meetingidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property MeetingidSpecified() As Boolean
            Get
                Return Me.meetingidFieldSpecified
            End Get
            Set
                Me.meetingidFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Version() As Integer
            Get
                Return Me.versionField
            End Get
            Set
                Me.versionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VersionSpecified() As Boolean
            Get
                Return Me.versionFieldSpecified
            End Get
            Set
                Me.versionFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Validated() As Boolean
            Get
                Return Me.validatedField
            End Get
            Set
                Me.validatedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ValidatedSpecified() As Boolean
            Get
                Return Me.validatedFieldSpecified
            End Get
            Set
                Me.validatedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property NumberOfRaces() As Integer
            Get
                Return Me.numberOfRacesField
            End Get
            Set
                Me.numberOfRacesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property NumberOfRacesSpecified() As Boolean
            Get
                Return Me.numberOfRacesFieldSpecified
            End Get
            Set
                Me.numberOfRacesFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ExternalMeetingID() As String
            Get
                Return Me.externalMeetingIDField
            End Get
            Set
                Me.externalMeetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MeetingSource() As ArrayOfMeetingMeetingMeetingSource
            Get
                Return Me.meetingSourceField
            End Get
            Set
                Me.meetingSourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property MeetingSourceSpecified() As Boolean
            Get
                Return Me.meetingSourceFieldSpecified
            End Get
            Set
                Me.meetingSourceFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("race", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property races() As RaceType()
            Get
                Return Me.racesField
            End Get
            Set
                Me.racesField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ArrayOfMeetingMeetingMeetingType

        '''<remarks/>
        HorseRacing

        '''<remarks/>
        HarnessRacing

        '''<remarks/>
        GreyHoundRacing

        '''<remarks/>
        HorseRacingTrial

        '''<remarks/>
        HarnessRacingTrial

        '''<remarks/>
        GreyHoundRacingQuali

        '''<remarks/>
        Other
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class TrackType

        Private nameField As String

        Private translatedNameField As String

        Private bettorDataNameField As String

        Private clubField As String

        Private locationField As TrackTypeLocation

        Private locationFieldSpecified As Boolean

        Private countryField As String

        Private stateField As String

        Private track_3char_abbrevField As String

        Private track_4char_abbrevField As String

        Private idField As Short

        Private track_surfaceField As String

        Private conditionField As TrackTypeCondition

        Private conditionFieldSpecified As Boolean

        Private weatherField As String

        Private night_meetingField As TrackTypeNight_meeting

        Private night_meetingFieldSpecified As Boolean

        Private gBSVenueidField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TranslatedName() As String
            Get
                Return Me.translatedNameField
            End Get
            Set
                Me.translatedNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BettorDataName() As String
            Get
                Return Me.bettorDataNameField
            End Get
            Set
                Me.bettorDataNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property club() As String
            Get
                Return Me.clubField
            End Get
            Set
                Me.clubField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property location() As TrackTypeLocation
            Get
                Return Me.locationField
            End Get
            Set
                Me.locationField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property locationSpecified() As Boolean
            Get
                Return Me.locationFieldSpecified
            End Get
            Set
                Me.locationFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property country() As String
            Get
                Return Me.countryField
            End Get
            Set
                Me.countryField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property state() As String
            Get
                Return Me.stateField
            End Get
            Set
                Me.stateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property track_3char_abbrev() As String
            Get
                Return Me.track_3char_abbrevField
            End Get
            Set
                Me.track_3char_abbrevField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property track_4char_abbrev() As String
            Get
                Return Me.track_4char_abbrevField
            End Get
            Set
                Me.track_4char_abbrevField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property id() As Short
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property track_surface() As String
            Get
                Return Me.track_surfaceField
            End Get
            Set
                Me.track_surfaceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property condition() As TrackTypeCondition
            Get
                Return Me.conditionField
            End Get
            Set
                Me.conditionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property conditionSpecified() As Boolean
            Get
                Return Me.conditionFieldSpecified
            End Get
            Set
                Me.conditionFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Weather() As String
            Get
                Return Me.weatherField
            End Get
            Set
                Me.weatherField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property night_meeting() As TrackTypeNight_meeting
            Get
                Return Me.night_meetingField
            End Get
            Set
                Me.night_meetingField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property night_meetingSpecified() As Boolean
            Get
                Return Me.night_meetingFieldSpecified
            End Get
            Set
                Me.night_meetingFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property GBSVenueid() As String
            Get
                Return Me.gBSVenueidField
            End Get
            Set
                Me.gBSVenueidField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum TrackTypeLocation

        '''<remarks/>
        C

        '''<remarks/>
        M

        '''<remarks/>
        P

        '''<remarks/>
        G

        '''<remarks/>
        F

        '''<remarks/>
        X
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum TrackTypeCondition

        '''<remarks/>
        Unknown

        '''<remarks/>
        Firm1

        '''<remarks/>
        Firm2

        '''<remarks/>
        Good3

        '''<remarks/>
        Good4

        '''<remarks/>
        Soft5

        '''<remarks/>
        Soft6

        '''<remarks/>
        Soft7

        '''<remarks/>
        Heavy8

        '''<remarks/>
        Heavy9

        '''<remarks/>
        Heavy10

        '''<remarks/>
        Dead

        '''<remarks/>
        Dirt

        '''<remarks/>
        Easy

        '''<remarks/>
        Fair

        '''<remarks/>
        Fast

        '''<remarks/>
        Good

        '''<remarks/>
        Heavy

        '''<remarks/>
        Sand

        '''<remarks/>
        Slow

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("Very Heavy")>
        VeryHeavy

        '''<remarks/>
        Firm

        '''<remarks/>
        Soft
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum TrackTypeNight_meeting

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("")>
        Item

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("0")>
        Item0

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1")>
        Item1
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class ToteCodeType

        Private toteNameField As ToteCodeTypeToteName

        Private codeField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ToteName() As ToteCodeTypeToteName
            Get
                Return Me.toteNameField
            End Get
            Set
                Me.toteNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Code() As String
            Get
                Return Me.codeField
            End Get
            Set
                Me.codeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ToteCodeTypeToteName

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class ProductType

        Private directoryField As String

        Private trackField As String

        Private dateField As String

        Private fileField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property directory() As String
            Get
                Return Me.directoryField
            End Get
            Set
                Me.directoryField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property track() As String
            Get
                Return Me.trackField
            End Get
            Set
                Me.trackField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [date]() As String
            Get
                Return Me.dateField
            End Get
            Set
                Me.dateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property file() As String
            Get
                Return Me.fileField
            End Get
            Set
                Me.fileField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ArrayOfMeetingMeetingMeetingSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RaceType

        Private numberOfRunnersField As Integer

        Private numberOfRunnersFieldSpecified As Boolean

        Private divisionField As String

        Private start_timeField As String

        Private raceJumpTimeField As String

        Private distanceField As DistanceType

        Private gaitField As RaceTypeGait

        Private restrictionsField As RestrictionsType

        Private weight_typeField As String

        Private min_hcp_weightField As Decimal

        Private min_hcp_weightFieldSpecified As Boolean

        Private groupField As RaceTypeGroup

        Private groupFieldSpecified As Boolean

        Private surfaceTypeField As RaceTypeSurfaceType

        Private surfaceTypeFieldSpecified As Boolean

        Private classesField() As String

        Private prizesField() As PrizeType

        Private jockeySilksURLField As String

        Private tABPoolsField() As TABPoolType

        Private track_conditionField As RaceTypeTrack_condition

        Private track_conditionFieldSpecified As Boolean

        Private trackField As TrackType

        Private resultsField() As ResultType

        Private substitutesField() As SubstituteType

        Private raceCommentsField() As RaceCommentType

        Private raceTipsField() As RaceTipType

        Private raceSelectionsField() As RaceSelectionType

        Private speedMapsField() As SpeedMapType

        Private barrier_trial_indicatorField As RaceTypeBarrier_trial_indicator

        Private barrier_trial_indicatorFieldSpecified As Boolean

        Private durationField As String

        Private sectionalsField() As SectionalType

        Private race_record_indicatorField As RaceRecordType

        Private race_record_indicatorFieldSpecified As Boolean

        Private inRunDescriptionsField() As InRunPositions

        Private stewardsCommentField As String

        Private raceCloseToBeIssuedField As Boolean

        Private raceCloseToBeIssuedFieldSpecified As Boolean

        Private foreCastField As Boolean

        Private foreCastFieldSpecified As Boolean

        Private handicapField As Boolean

        Private handicapFieldSpecified As Boolean

        Private numberOfPlacesField As Integer

        Private numberOfPlacesFieldSpecified As Boolean

        Private eachWayPlacesField As Integer

        Private eachWayPlacesFieldSpecified As Boolean

        Private eachWayReductionField As Integer

        Private eachWayReductionFieldSpecified As Boolean

        Private displayTimeField As String

        Private horsesField() As HorseType

        Private numberField As SByte

        Private nameField As String

        Private idField As Integer

        Private idFieldSpecified As Boolean

        Private externalIdField As Integer

        Private nomination_numberField As String

        Private raceidField As Long

        Private raceidFieldSpecified As Boolean

        Private statusField As RaceTypeStatus

        '''<remarks/>
        Public Property NumberOfRunners() As Integer
            Get
                Return Me.numberOfRunnersField
            End Get
            Set
                Me.numberOfRunnersField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property NumberOfRunnersSpecified() As Boolean
            Get
                Return Me.numberOfRunnersFieldSpecified
            End Get
            Set
                Me.numberOfRunnersFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property division() As String
            Get
                Return Me.divisionField
            End Get
            Set
                Me.divisionField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property start_time() As String
            Get
                Return Me.start_timeField
            End Get
            Set
                Me.start_timeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RaceJumpTime() As String
            Get
                Return Me.raceJumpTimeField
            End Get
            Set
                Me.raceJumpTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property distance() As DistanceType
            Get
                Return Me.distanceField
            End Get
            Set
                Me.distanceField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Gait() As RaceTypeGait
            Get
                Return Me.gaitField
            End Get
            Set
                Me.gaitField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property restrictions() As RestrictionsType
            Get
                Return Me.restrictionsField
            End Get
            Set
                Me.restrictionsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property weight_type() As String
            Get
                Return Me.weight_typeField
            End Get
            Set
                Me.weight_typeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property min_hcp_weight() As Decimal
            Get
                Return Me.min_hcp_weightField
            End Get
            Set
                Me.min_hcp_weightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property min_hcp_weightSpecified() As Boolean
            Get
                Return Me.min_hcp_weightFieldSpecified
            End Get
            Set
                Me.min_hcp_weightFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property group() As RaceTypeGroup
            Get
                Return Me.groupField
            End Get
            Set
                Me.groupField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property groupSpecified() As Boolean
            Get
                Return Me.groupFieldSpecified
            End Get
            Set
                Me.groupFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SurfaceType() As RaceTypeSurfaceType
            Get
                Return Me.surfaceTypeField
            End Get
            Set
                Me.surfaceTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SurfaceTypeSpecified() As Boolean
            Get
                Return Me.surfaceTypeFieldSpecified
            End Get
            Set
                Me.surfaceTypeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("class", IsNullable:=False)>
        Public Property classes() As String()
            Get
                Return Me.classesField
            End Get
            Set
                Me.classesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("prize", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property prizes() As PrizeType()
            Get
                Return Me.prizesField
            End Get
            Set
                Me.prizesField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property JockeySilksURL() As String
            Get
                Return Me.jockeySilksURLField
            End Get
            Set
                Me.jockeySilksURLField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("TABPool", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property TABPools() As TABPoolType()
            Get
                Return Me.tABPoolsField
            End Get
            Set
                Me.tABPoolsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property track_condition() As RaceTypeTrack_condition
            Get
                Return Me.track_conditionField
            End Get
            Set
                Me.track_conditionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property track_conditionSpecified() As Boolean
            Get
                Return Me.track_conditionFieldSpecified
            End Get
            Set
                Me.track_conditionFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property track() As TrackType
            Get
                Return Me.trackField
            End Get
            Set
                Me.trackField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("Result", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Results() As ResultType()
            Get
                Return Me.resultsField
            End Get
            Set
                Me.resultsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("Substitute", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Substitutes() As SubstituteType()
            Get
                Return Me.substitutesField
            End Get
            Set
                Me.substitutesField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RaceComments() As RaceCommentType()
            Get
                Return Me.raceCommentsField
            End Get
            Set
                Me.raceCommentsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RaceTips() As RaceTipType()
            Get
                Return Me.raceTipsField
            End Get
            Set
                Me.raceTipsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RaceSelections() As RaceSelectionType()
            Get
                Return Me.raceSelectionsField
            End Get
            Set
                Me.raceSelectionsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property SpeedMaps() As SpeedMapType()
            Get
                Return Me.speedMapsField
            End Get
            Set
                Me.speedMapsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property barrier_trial_indicator() As RaceTypeBarrier_trial_indicator
            Get
                Return Me.barrier_trial_indicatorField
            End Get
            Set
                Me.barrier_trial_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property barrier_trial_indicatorSpecified() As Boolean
            Get
                Return Me.barrier_trial_indicatorFieldSpecified
            End Get
            Set
                Me.barrier_trial_indicatorFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property duration() As String
            Get
                Return Me.durationField
            End Get
            Set
                Me.durationField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("sectionals", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property sectionals() As SectionalType()
            Get
                Return Me.sectionalsField
            End Get
            Set
                Me.sectionalsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property race_record_indicator() As RaceRecordType
            Get
                Return Me.race_record_indicatorField
            End Get
            Set
                Me.race_record_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property race_record_indicatorSpecified() As Boolean
            Get
                Return Me.race_record_indicatorFieldSpecified
            End Get
            Set
                Me.race_record_indicatorFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("Result", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property InRunDescriptions() As InRunPositions()
            Get
                Return Me.inRunDescriptionsField
            End Get
            Set
                Me.inRunDescriptionsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property StewardsComment() As String
            Get
                Return Me.stewardsCommentField
            End Get
            Set
                Me.stewardsCommentField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property RaceCloseToBeIssued() As Boolean
            Get
                Return Me.raceCloseToBeIssuedField
            End Get
            Set
                Me.raceCloseToBeIssuedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RaceCloseToBeIssuedSpecified() As Boolean
            Get
                Return Me.raceCloseToBeIssuedFieldSpecified
            End Get
            Set
                Me.raceCloseToBeIssuedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property ForeCast() As Boolean
            Get
                Return Me.foreCastField
            End Get
            Set
                Me.foreCastField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ForeCastSpecified() As Boolean
            Get
                Return Me.foreCastFieldSpecified
            End Get
            Set
                Me.foreCastFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property Handicap() As Boolean
            Get
                Return Me.handicapField
            End Get
            Set
                Me.handicapField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property HandicapSpecified() As Boolean
            Get
                Return Me.handicapFieldSpecified
            End Get
            Set
                Me.handicapFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property NumberOfPlaces() As Integer
            Get
                Return Me.numberOfPlacesField
            End Get
            Set
                Me.numberOfPlacesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property NumberOfPlacesSpecified() As Boolean
            Get
                Return Me.numberOfPlacesFieldSpecified
            End Get
            Set
                Me.numberOfPlacesFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property EachWayPlaces() As Integer
            Get
                Return Me.eachWayPlacesField
            End Get
            Set
                Me.eachWayPlacesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property EachWayPlacesSpecified() As Boolean
            Get
                Return Me.eachWayPlacesFieldSpecified
            End Get
            Set
                Me.eachWayPlacesFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property EachWayReduction() As Integer
            Get
                Return Me.eachWayReductionField
            End Get
            Set
                Me.eachWayReductionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property EachWayReductionSpecified() As Boolean
            Get
                Return Me.eachWayReductionFieldSpecified
            End Get
            Set
                Me.eachWayReductionFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property DisplayTime() As String
            Get
                Return Me.displayTimeField
            End Get
            Set
                Me.displayTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("horse", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property horses() As HorseType()
            Get
                Return Me.horsesField
            End Get
            Set
                Me.horsesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property number() As SByte
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property id() As Integer
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property idSpecified() As Boolean
            Get
                Return Me.idFieldSpecified
            End Get
            Set
                Me.idFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ExternalId() As Integer
            Get
                Return Me.externalIdField
            End Get
            Set
                Me.externalIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="integer")>
        Public Property nomination_number() As String
            Get
                Return Me.nomination_numberField
            End Get
            Set
                Me.nomination_numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Raceid() As Long
            Get
                Return Me.raceidField
            End Get
            Set
                Me.raceidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RaceidSpecified() As Boolean
            Get
                Return Me.raceidFieldSpecified
            End Get
            Set
                Me.raceidFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Status() As RaceTypeStatus
            Get
                Return Me.statusField
            End Get
            Set
                Me.statusField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class DistanceType

        Private distanceasTextField As String

        Private metresField As Short

        Private about_indicatorField As DistanceTypeAbout_indicator

        Private about_indicatorFieldSpecified As Boolean

        '''<remarks/>
        Public Property DistanceasText() As String
            Get
                Return Me.distanceasTextField
            End Get
            Set
                Me.distanceasTextField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property metres() As Short
            Get
                Return Me.metresField
            End Get
            Set
                Me.metresField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property about_indicator() As DistanceTypeAbout_indicator
            Get
                Return Me.about_indicatorField
            End Get
            Set
                Me.about_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property about_indicatorSpecified() As Boolean
            Get
                Return Me.about_indicatorFieldSpecified
            End Get
            Set
                Me.about_indicatorFieldSpecified = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum DistanceTypeAbout_indicator

        '''<remarks/>
        a
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceTypeGait

        '''<remarks/>
        Gallop

        '''<remarks/>
        Pace

        '''<remarks/>
        Trot
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RestrictionsType

        Private ageField As String

        Private sexField As String

        Private jockeyField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property age() As String
            Get
                Return Me.ageField
            End Get
            Set
                Me.ageField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property sex() As String
            Get
                Return Me.sexField
            End Get
            Set
                Me.sexField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property jockey() As String
            Get
                Return Me.jockeyField
            End Get
            Set
                Me.jockeyField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceTypeGroup

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("0")>
        Item0

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1")>
        Item1

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2")>
        Item2

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("3")>
        Item3

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("4")>
        Item4

        '''<remarks/>
        LR
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceTypeSurfaceType

        '''<remarks/>
        Unknown

        '''<remarks/>
        Turf

        '''<remarks/>
        Sand

        '''<remarks/>
        Dirt

        '''<remarks/>
        PolyTrack

        '''<remarks/>
        EquiTrack

        '''<remarks/>
        AllWeather

        '''<remarks/>
        FibreSand
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class PrizeType

        Private typeField As PrizeTypeType

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property type() As PrizeTypeType
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum PrizeTypeType

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1st")>
        Item1st

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2nd")>
        Item2nd

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("3rd")>
        Item3rd

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("4th")>
        Item4th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("5th")>
        Item5th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("6th")>
        Item6th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("7th")>
        Item7th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("8th")>
        Item8th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("9th")>
        Item9th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("10th")>
        Item10th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("11th")>
        Item11th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("12th")>
        Item12th

        '''<remarks/>
        total_value

        '''<remarks/>
        trophy_total_value

        '''<remarks/>
        welfare_fund

        '''<remarks/>
        jockey_trophy
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class TABPoolType

        Private poolDescriptionField As TABPoolTypePoolDescription

        Private poolBetTypeField As TABPoolTypePoolBetType

        Private poolValueField As String

        Private legNumberField As Integer

        Private legNumberFieldSpecified As Boolean

        Private timeStampField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PoolDescription() As TABPoolTypePoolDescription
            Get
                Return Me.poolDescriptionField
            End Get
            Set
                Me.poolDescriptionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PoolBetType() As TABPoolTypePoolBetType
            Get
                Return Me.poolBetTypeField
            End Get
            Set
                Me.poolBetTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PoolValue() As String
            Get
                Return Me.poolValueField
            End Get
            Set
                Me.poolValueField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property LegNumber() As Integer
            Get
                Return Me.legNumberField
            End Get
            Set
                Me.legNumberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property LegNumberSpecified() As Boolean
            Get
                Return Me.legNumberFieldSpecified
            End Get
            Set
                Me.legNumberFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TimeStamp() As Date
            Get
                Return Me.timeStampField
            End Get
            Set
                Me.timeStampField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum TABPoolTypePoolDescription

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum TABPoolTypePoolBetType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceTypeTrack_condition

        '''<remarks/>
        Unknown

        '''<remarks/>
        Firm1

        '''<remarks/>
        Firm2

        '''<remarks/>
        Good3

        '''<remarks/>
        Good4

        '''<remarks/>
        Soft5

        '''<remarks/>
        Soft6

        '''<remarks/>
        Soft7

        '''<remarks/>
        Heavy8

        '''<remarks/>
        Heavy9

        '''<remarks/>
        Heavy10

        '''<remarks/>
        Dead

        '''<remarks/>
        Dirt

        '''<remarks/>
        Easy

        '''<remarks/>
        Fair

        '''<remarks/>
        Fast

        '''<remarks/>
        Good

        '''<remarks/>
        Heavy

        '''<remarks/>
        Sand

        '''<remarks/>
        Slow

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("Very Heavy")>
        VeryHeavy

        '''<remarks/>
        Firm

        '''<remarks/>
        Soft
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class ResultType

        Private resultNumbersField() As ResultNumberType

        Private dividendsField() As DividendType

        Private jackPotsField() As JackPotType

        Private deductionsField() As DeductionType

        Private meetingIDField As String

        Private raceNumberField As String

        Private sourceField As ResultTypeSource

        Private dividendStatusField As ResultTypeDividendStatus

        Private dividendStatusFieldSpecified As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("ResultNumber", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property ResultNumbers() As ResultNumberType()
            Get
                Return Me.resultNumbersField
            End Get
            Set
                Me.resultNumbersField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("Dividend", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Dividends() As DividendType()
            Get
                Return Me.dividendsField
            End Get
            Set
                Me.dividendsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("JackPot", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property JackPots() As JackPotType()
            Get
                Return Me.jackPotsField
            End Get
            Set
                Me.jackPotsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("Deductions", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Deductions() As DeductionType()
            Get
                Return Me.deductionsField
            End Get
            Set
                Me.deductionsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MeetingID() As String
            Get
                Return Me.meetingIDField
            End Get
            Set
                Me.meetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceNumber() As String
            Get
                Return Me.raceNumberField
            End Get
            Set
                Me.raceNumberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As ResultTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DividendStatus() As ResultTypeDividendStatus
            Get
                Return Me.dividendStatusField
            End Get
            Set
                Me.dividendStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DividendStatusSpecified() As Boolean
            Get
                Return Me.dividendStatusFieldSpecified
            End Get
            Set
                Me.dividendStatusFieldSpecified = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class ResultNumberType

        Private positionField As Integer

        Private participantNumberField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Position() As Integer
            Get
                Return Me.positionField
            End Get
            Set
                Me.positionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ParticipantNumber() As String
            Get
                Return Me.participantNumberField
            End Get
            Set
                Me.participantNumberField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class DividendType

        Private betTypeField As DividendTypeBetType

        Private dividendNumbersField As String

        Private dividendField As Single

        Private dividendFieldSpecified As Boolean

        Private poolSizeField As Single

        Private poolSizeFieldSpecified As Boolean

        Private dividendStatusField As DividendTypeDividendStatus

        Private dividendStatusFieldSpecified As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BetType() As DividendTypeBetType
            Get
                Return Me.betTypeField
            End Get
            Set
                Me.betTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DividendNumbers() As String
            Get
                Return Me.dividendNumbersField
            End Get
            Set
                Me.dividendNumbersField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Dividend() As Single
            Get
                Return Me.dividendField
            End Get
            Set
                Me.dividendField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DividendSpecified() As Boolean
            Get
                Return Me.dividendFieldSpecified
            End Get
            Set
                Me.dividendFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PoolSize() As Single
            Get
                Return Me.poolSizeField
            End Get
            Set
                Me.poolSizeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property PoolSizeSpecified() As Boolean
            Get
                Return Me.poolSizeFieldSpecified
            End Get
            Set
                Me.poolSizeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DividendStatus() As DividendTypeDividendStatus
            Get
                Return Me.dividendStatusField
            End Get
            Set
                Me.dividendStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DividendStatusSpecified() As Boolean
            Get
                Return Me.dividendStatusFieldSpecified
            End Get
            Set
                Me.dividendStatusFieldSpecified = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum DividendTypeBetType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum DividendTypeDividendStatus

        '''<remarks/>
        Interim

        '''<remarks/>
        PartialPay

        '''<remarks/>
        Protest

        '''<remarks/>
        Pending

        '''<remarks/>
        Final

        '''<remarks/>
        ReResult

        '''<remarks/>
        Abandoned
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class JackPotType

        Private betTypeField As JackPotTypeBetType

        Private amountField As Single

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BetType() As JackPotTypeBetType
            Get
                Return Me.betTypeField
            End Get
            Set
                Me.betTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Amount() As Single
            Get
                Return Me.amountField
            End Get
            Set
                Me.amountField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum JackPotTypeBetType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class DeductionType

        Private betTypeField As DeductionTypeBetType

        Private amountField As Single

        Private tab_NoField As SByte

        Private deductionTimeField As String

        Private deductionBetTypeField As String

        Private marketTypeField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BetType() As DeductionTypeBetType
            Get
                Return Me.betTypeField
            End Get
            Set
                Me.betTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Amount() As Single
            Get
                Return Me.amountField
            End Get
            Set
                Me.amountField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Tab_No() As SByte
            Get
                Return Me.tab_NoField
            End Get
            Set
                Me.tab_NoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DeductionTime() As String
            Get
                Return Me.deductionTimeField
            End Get
            Set
                Me.deductionTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DeductionBetType() As String
            Get
                Return Me.deductionBetTypeField
            End Get
            Set
                Me.deductionBetTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MarketType() As String
            Get
                Return Me.marketTypeField
            End Get
            Set
                Me.marketTypeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum DeductionTypeBetType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ResultTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ResultTypeDividendStatus

        '''<remarks/>
        Interim

        '''<remarks/>
        PartialPay

        '''<remarks/>
        Protest

        '''<remarks/>
        Pending

        '''<remarks/>
        Final

        '''<remarks/>
        ReResult

        '''<remarks/>
        Abandoned
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class SubstituteType

        Private meetingIDField As String

        Private raceNumberField As String

        Private sourcePoolField As SubstituteTypeSourcePool

        Private betTypeField As SubstituteTypeBetType

        Private substitutenumberField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MeetingID() As String
            Get
                Return Me.meetingIDField
            End Get
            Set
                Me.meetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceNumber() As String
            Get
                Return Me.raceNumberField
            End Get
            Set
                Me.raceNumberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SourcePool() As SubstituteTypeSourcePool
            Get
                Return Me.sourcePoolField
            End Get
            Set
                Me.sourcePoolField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BetType() As SubstituteTypeBetType
            Get
                Return Me.betTypeField
            End Get
            Set
                Me.betTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property substitutenumber() As String
            Get
                Return Me.substitutenumberField
            End Get
            Set
                Me.substitutenumberField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum SubstituteTypeSourcePool

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum SubstituteTypeBetType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RaceCommentType

        Private raceCommentField As String

        Private sourceField As RaceCommentTypeSource

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceComment() As String
            Get
                Return Me.raceCommentField
            End Get
            Set
                Me.raceCommentField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As RaceCommentTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceCommentTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RaceTipType

        Private raceTipField As String

        Private sourceField As RaceTipTypeSource

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceTip() As String
            Get
                Return Me.raceTipField
            End Get
            Set
                Me.raceTipField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As RaceTipTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceTipTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RaceSelectionType

        Private raceSelectionField As String

        Private sourceField As RaceSelectionTypeSource

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceSelection() As String
            Get
                Return Me.raceSelectionField
            End Get
            Set
                Me.raceSelectionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As RaceSelectionTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceSelectionTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class SpeedMapType

        Private speedMapDescriptionField As String

        Private sourceField As SpeedMapTypeSource

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SpeedMapDescription() As String
            Get
                Return Me.speedMapDescriptionField
            End Get
            Set
                Me.speedMapDescriptionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As SpeedMapTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum SpeedMapTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceTypeBarrier_trial_indicator

        '''<remarks/>
        B
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class SectionalType

        Private distanceField As Integer

        Private distanceDescriptionField As String

        Private timeField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property distance() As Integer
            Get
                Return Me.distanceField
            End Get
            Set
                Me.distanceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property distanceDescription() As String
            Get
                Return Me.distanceDescriptionField
            End Get
            Set
                Me.distanceDescriptionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property time() As String
            Get
                Return Me.timeField
            End Get
            Set
                Me.timeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum RaceRecordType

        '''<remarks/>
        R
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class InRunPositions

        Private positionDescriptionField As String

        Private positionDistanceInMetresField As String

        Private inRunPositions1Field As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PositionDescription() As String
            Get
                Return Me.positionDescriptionField
            End Get
            Set
                Me.positionDescriptionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PositionDistanceInMetres() As String
            Get
                Return Me.positionDistanceInMetresField
            End Get
            Set
                Me.positionDistanceInMetresField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute("InRunPositions")>
        Public Property InRunPositions1() As String
            Get
                Return Me.inRunPositions1Field
            End Get
            Set
                Me.inRunPositions1Field = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class HorseType

        Private tab_noField As Integer

        Private tab_noFieldSpecified As Boolean

        Private gear_changesField() As ArrayOfHorseGearGear

        Private gear_changes_descriptionField As String

        Private failedToFinishField As Boolean

        Private failedToFinishFieldSpecified As Boolean

        Private disqualifiedField As Boolean

        Private disqualifiedFieldSpecified As Boolean

        Private finish_positionField As String

        Private marginField As String

        Private startingPriceField As String

        Private bestTimeField As String

        Private statusField As StatusType

        Private sireField As AncestorType

        Private damField As AncestorType

        Private sire_of_damField As AncestorType

        Private trainerField As TrainerType

        Private training_locationField As String

        Private ownersField As String

        Private coloursField As String

        Private current_blinker_indField As String

        Private lastTimeAtTrackAndDistanceField As String

        Private favourite_indicatorField As FavouriteIndicatorType

        Private favourite_indicatorFieldSpecified As Boolean

        Private prizemoney_wonField As Integer

        Private prizemoney_wonFieldSpecified As Boolean

        Private last_four_startsField As String

        Private last_ten_startsField As String

        Private coupledField As String

        Private sequence_noField As Integer

        Private sequence_noFieldSpecified As Boolean

        Private emergency_indicatorField As HorseTypeEmergency_indicator

        Private emergency_indicatorFieldSpecified As Boolean

        Private jockeyField As JockeyType

        Private rowField As String

        Private barrierField As String

        Private weightField As WeightType

        Private selectionField As String

        Private marketField As MarketType

        Private pricesField() As PriceType

        Private statisticsField() As StatisticType

        Private win_distancesField() As WinDistanceType

        Private ratingsField() As RatingType

        Private classCountryField As String

        Private startingHandicapField As String

        Private classMetroField As String

        Private runnerWeightField As Single

        Private runnerWeightFieldSpecified As Boolean

        Private timeRanField As Single

        Private timeRanFieldSpecified As Boolean

        Private jockeySilksURLField As String

        Private scratched_indicatorField As String

        Private medicationField As String

        Private externalidField As String

        Private previousFormField() As FormType

        Private runnerCommentsField() As RunnerCommentType

        Private sectionalsField() As SectionalType

        Private inRunField As String

        Private providerIDField As HorseTypeProviderID

        Private concessionField As Boolean

        Private concessionFieldSpecified As Boolean

        Private retiredField As Boolean

        Private retiredFieldSpecified As Boolean

        Private yOBField As Integer

        Private yOBFieldSpecified As Boolean

        Private morningLineField As Single

        Private morningLineFieldSpecified As Boolean

        Private travelledDistanceInKMField As Integer

        Private travelledDistanceInKMFieldSpecified As Boolean

        Private earlySpeedIndicatorField As Single

        Private earlySpeedIndicatorFieldSpecified As Boolean

        Private additionalProviderIDsField() As ArrayOfProviderIDTypeAdditionalProviderIDs

        Private nameField As String

        Private countryField As String

        Private ageField As String

        Private sexField As HorseTypeSex

        Private sexFieldSpecified As Boolean

        Private colourField As HorseTypeColour

        Private colourFieldSpecified As Boolean

        Private previous_nameField As String

        Private foaling_dateField As String

        Private idField As Integer

        '''<remarks/>
        Public Property tab_no() As Integer
            Get
                Return Me.tab_noField
            End Get
            Set
                Me.tab_noField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property tab_noSpecified() As Boolean
            Get
                Return Me.tab_noFieldSpecified
            End Get
            Set
                Me.tab_noFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("gear", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property gear_changes() As ArrayOfHorseGearGear()
            Get
                Return Me.gear_changesField
            End Get
            Set
                Me.gear_changesField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property gear_changes_description() As String
            Get
                Return Me.gear_changes_descriptionField
            End Get
            Set
                Me.gear_changes_descriptionField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FailedToFinish() As Boolean
            Get
                Return Me.failedToFinishField
            End Get
            Set
                Me.failedToFinishField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property FailedToFinishSpecified() As Boolean
            Get
                Return Me.failedToFinishFieldSpecified
            End Get
            Set
                Me.failedToFinishFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Disqualified() As Boolean
            Get
                Return Me.disqualifiedField
            End Get
            Set
                Me.disqualifiedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DisqualifiedSpecified() As Boolean
            Get
                Return Me.disqualifiedFieldSpecified
            End Get
            Set
                Me.disqualifiedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property finish_position() As String
            Get
                Return Me.finish_positionField
            End Get
            Set
                Me.finish_positionField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property margin() As String
            Get
                Return Me.marginField
            End Get
            Set
                Me.marginField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property StartingPrice() As String
            Get
                Return Me.startingPriceField
            End Get
            Set
                Me.startingPriceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property BestTime() As String
            Get
                Return Me.bestTimeField
            End Get
            Set
                Me.bestTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property Status() As StatusType
            Get
                Return Me.statusField
            End Get
            Set
                Me.statusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property sire() As AncestorType
            Get
                Return Me.sireField
            End Get
            Set
                Me.sireField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property dam() As AncestorType
            Get
                Return Me.damField
            End Get
            Set
                Me.damField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property sire_of_dam() As AncestorType
            Get
                Return Me.sire_of_damField
            End Get
            Set
                Me.sire_of_damField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property trainer() As TrainerType
            Get
                Return Me.trainerField
            End Get
            Set
                Me.trainerField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property training_location() As String
            Get
                Return Me.training_locationField
            End Get
            Set
                Me.training_locationField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property owners() As String
            Get
                Return Me.ownersField
            End Get
            Set
                Me.ownersField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property colours() As String
            Get
                Return Me.coloursField
            End Get
            Set
                Me.coloursField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property current_blinker_ind() As String
            Get
                Return Me.current_blinker_indField
            End Get
            Set
                Me.current_blinker_indField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property LastTimeAtTrackAndDistance() As String
            Get
                Return Me.lastTimeAtTrackAndDistanceField
            End Get
            Set
                Me.lastTimeAtTrackAndDistanceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property favourite_indicator() As FavouriteIndicatorType
            Get
                Return Me.favourite_indicatorField
            End Get
            Set
                Me.favourite_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property favourite_indicatorSpecified() As Boolean
            Get
                Return Me.favourite_indicatorFieldSpecified
            End Get
            Set
                Me.favourite_indicatorFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property prizemoney_won() As Integer
            Get
                Return Me.prizemoney_wonField
            End Get
            Set
                Me.prizemoney_wonField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property prizemoney_wonSpecified() As Boolean
            Get
                Return Me.prizemoney_wonFieldSpecified
            End Get
            Set
                Me.prizemoney_wonFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property last_four_starts() As String
            Get
                Return Me.last_four_startsField
            End Get
            Set
                Me.last_four_startsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property last_ten_starts() As String
            Get
                Return Me.last_ten_startsField
            End Get
            Set
                Me.last_ten_startsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Coupled() As String
            Get
                Return Me.coupledField
            End Get
            Set
                Me.coupledField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property sequence_no() As Integer
            Get
                Return Me.sequence_noField
            End Get
            Set
                Me.sequence_noField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property sequence_noSpecified() As Boolean
            Get
                Return Me.sequence_noFieldSpecified
            End Get
            Set
                Me.sequence_noFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property emergency_indicator() As HorseTypeEmergency_indicator
            Get
                Return Me.emergency_indicatorField
            End Get
            Set
                Me.emergency_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property emergency_indicatorSpecified() As Boolean
            Get
                Return Me.emergency_indicatorFieldSpecified
            End Get
            Set
                Me.emergency_indicatorFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property jockey() As JockeyType
            Get
                Return Me.jockeyField
            End Get
            Set
                Me.jockeyField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Row() As String
            Get
                Return Me.rowField
            End Get
            Set
                Me.rowField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>
        Public Property barrier() As String
            Get
                Return Me.barrierField
            End Get
            Set
                Me.barrierField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property weight() As WeightType
            Get
                Return Me.weightField
            End Get
            Set
                Me.weightField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property selection() As String
            Get
                Return Me.selectionField
            End Get
            Set
                Me.selectionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property market() As MarketType
            Get
                Return Me.marketField
            End Get
            Set
                Me.marketField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("Price", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Prices() As PriceType()
            Get
                Return Me.pricesField
            End Get
            Set
                Me.pricesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("statistic", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property statistics() As StatisticType()
            Get
                Return Me.statisticsField
            End Get
            Set
                Me.statisticsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("win_distance", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property win_distances() As WinDistanceType()
            Get
                Return Me.win_distancesField
            End Get
            Set
                Me.win_distancesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("rating", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property ratings() As RatingType()
            Get
                Return Me.ratingsField
            End Get
            Set
                Me.ratingsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property ClassCountry() As String
            Get
                Return Me.classCountryField
            End Get
            Set
                Me.classCountryField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>
        Public Property StartingHandicap() As String
            Get
                Return Me.startingHandicapField
            End Get
            Set
                Me.startingHandicapField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property ClassMetro() As String
            Get
                Return Me.classMetroField
            End Get
            Set
                Me.classMetroField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RunnerWeight() As Single
            Get
                Return Me.runnerWeightField
            End Get
            Set
                Me.runnerWeightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RunnerWeightSpecified() As Boolean
            Get
                Return Me.runnerWeightFieldSpecified
            End Get
            Set
                Me.runnerWeightFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TimeRan() As Single
            Get
                Return Me.timeRanField
            End Get
            Set
                Me.timeRanField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property TimeRanSpecified() As Boolean
            Get
                Return Me.timeRanFieldSpecified
            End Get
            Set
                Me.timeRanFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property JockeySilksURL() As String
            Get
                Return Me.jockeySilksURLField
            End Get
            Set
                Me.jockeySilksURLField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property scratched_indicator() As String
            Get
                Return Me.scratched_indicatorField
            End Get
            Set
                Me.scratched_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property medication() As String
            Get
                Return Me.medicationField
            End Get
            Set
                Me.medicationField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property externalid() As String
            Get
                Return Me.externalidField
            End Get
            Set
                Me.externalidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("form", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property PreviousForm() As FormType()
            Get
                Return Me.previousFormField
            End Get
            Set
                Me.previousFormField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RunnerComments() As RunnerCommentType()
            Get
                Return Me.runnerCommentsField
            End Get
            Set
                Me.runnerCommentsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Sectionals() As SectionalType()
            Get
                Return Me.sectionalsField
            End Get
            Set
                Me.sectionalsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property InRun() As String
            Get
                Return Me.inRunField
            End Get
            Set
                Me.inRunField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ProviderID() As HorseTypeProviderID
            Get
                Return Me.providerIDField
            End Get
            Set
                Me.providerIDField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Concession() As Boolean
            Get
                Return Me.concessionField
            End Get
            Set
                Me.concessionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ConcessionSpecified() As Boolean
            Get
                Return Me.concessionFieldSpecified
            End Get
            Set
                Me.concessionFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Retired() As Boolean
            Get
                Return Me.retiredField
            End Get
            Set
                Me.retiredField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RetiredSpecified() As Boolean
            Get
                Return Me.retiredFieldSpecified
            End Get
            Set
                Me.retiredFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property YOB() As Integer
            Get
                Return Me.yOBField
            End Get
            Set
                Me.yOBField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property YOBSpecified() As Boolean
            Get
                Return Me.yOBFieldSpecified
            End Get
            Set
                Me.yOBFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MorningLine() As Single
            Get
                Return Me.morningLineField
            End Get
            Set
                Me.morningLineField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property MorningLineSpecified() As Boolean
            Get
                Return Me.morningLineFieldSpecified
            End Get
            Set
                Me.morningLineFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property TravelledDistanceInKM() As Integer
            Get
                Return Me.travelledDistanceInKMField
            End Get
            Set
                Me.travelledDistanceInKMField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property TravelledDistanceInKMSpecified() As Boolean
            Get
                Return Me.travelledDistanceInKMFieldSpecified
            End Get
            Set
                Me.travelledDistanceInKMFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property EarlySpeedIndicator() As Single
            Get
                Return Me.earlySpeedIndicatorField
            End Get
            Set
                Me.earlySpeedIndicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property EarlySpeedIndicatorSpecified() As Boolean
            Get
                Return Me.earlySpeedIndicatorFieldSpecified
            End Get
            Set
                Me.earlySpeedIndicatorFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("AdditionalProviderIDs", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property AdditionalProviderIDs() As ArrayOfProviderIDTypeAdditionalProviderIDs()
            Get
                Return Me.additionalProviderIDsField
            End Get
            Set
                Me.additionalProviderIDsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property country() As String
            Get
                Return Me.countryField
            End Get
            Set
                Me.countryField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(DataType:="integer")>
        Public Property age() As String
            Get
                Return Me.ageField
            End Get
            Set
                Me.ageField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property sex() As HorseTypeSex
            Get
                Return Me.sexField
            End Get
            Set
                Me.sexField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property sexSpecified() As Boolean
            Get
                Return Me.sexFieldSpecified
            End Get
            Set
                Me.sexFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property colour() As HorseTypeColour
            Get
                Return Me.colourField
            End Get
            Set
                Me.colourField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property colourSpecified() As Boolean
            Get
                Return Me.colourFieldSpecified
            End Get
            Set
                Me.colourFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property previous_name() As String
            Get
                Return Me.previous_nameField
            End Get
            Set
                Me.previous_nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property foaling_date() As String
            Get
                Return Me.foaling_dateField
            End Get
            Set
                Me.foaling_dateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property id() As Integer
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfHorseGearGear

        Private idField As String

        Private nameField As String

        Private optionField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [option]() As String
            Get
                Return Me.optionField
            End Get
            Set
                Me.optionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class StatusType

        Private indicatorField As StatusTypeIndicator

        Private lateScratchingTimeField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Indicator() As StatusTypeIndicator
            Get
                Return Me.indicatorField
            End Get
            Set
                Me.indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property LateScratchingTime() As String
            Get
                Return Me.lateScratchingTimeField
            End Get
            Set
                Me.lateScratchingTimeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum StatusTypeIndicator

        '''<remarks/>
        Starter

        '''<remarks/>
        Scratched

        '''<remarks/>
        LateScratching
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class AncestorType

        Private providerIDField As AncestorTypeProviderID

        Private nameField As String

        Private countryField As String

        Private yearBornField As String

        Private idField As String

        '''<remarks/>
        Public Property ProviderID() As AncestorTypeProviderID
            Get
                Return Me.providerIDField
            End Get
            Set
                Me.providerIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property country() As String
            Get
                Return Me.countryField
            End Get
            Set
                Me.countryField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property YearBorn() As String
            Get
                Return Me.yearBornField
            End Get
            Set
                Me.yearBornField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AncestorTypeProviderID

        Private sourceField As AncestorTypeProviderIDSource

        Private idField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As AncestorTypeProviderIDSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum AncestorTypeProviderIDSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class TrainerType

        Private statisticsField() As StatisticType

        Private firstNameField As String

        Private surnameField As String

        Private countryField As String

        Private providerIDField As TrainerTypeProviderID

        Private nameField As String

        Private idField As Long

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("statistic", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property statistics() As StatisticType()
            Get
                Return Me.statisticsField
            End Get
            Set
                Me.statisticsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property FirstName() As String
            Get
                Return Me.firstNameField
            End Get
            Set
                Me.firstNameField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Surname() As String
            Get
                Return Me.surnameField
            End Get
            Set
                Me.surnameField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Country() As String
            Get
                Return Me.countryField
            End Get
            Set
                Me.countryField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ProviderID() As TrainerTypeProviderID
            Get
                Return Me.providerIDField
            End Get
            Set
                Me.providerIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property id() As Long
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class StatisticType

        Private typeField As StatisticTypeType

        Private totalField As Short

        Private firstsField As Short

        Private secondsField As Short

        Private secondsFieldSpecified As Boolean

        Private thirdsField As Short

        Private thirdsFieldSpecified As Boolean

        Private placingsField As Short

        Private placingsFieldSpecified As Boolean

        Private bestMileRateField As String

        Private winningDistanceField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property type() As StatisticTypeType
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property total() As Short
            Get
                Return Me.totalField
            End Get
            Set
                Me.totalField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property firsts() As Short
            Get
                Return Me.firstsField
            End Get
            Set
                Me.firstsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property seconds() As Short
            Get
                Return Me.secondsField
            End Get
            Set
                Me.secondsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property secondsSpecified() As Boolean
            Get
                Return Me.secondsFieldSpecified
            End Get
            Set
                Me.secondsFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property thirds() As Short
            Get
                Return Me.thirdsField
            End Get
            Set
                Me.thirdsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property thirdsSpecified() As Boolean
            Get
                Return Me.thirdsFieldSpecified
            End Get
            Set
                Me.thirdsFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property placings() As Short
            Get
                Return Me.placingsField
            End Get
            Set
                Me.placingsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property placingsSpecified() As Boolean
            Get
                Return Me.placingsFieldSpecified
            End Get
            Set
                Me.placingsFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BestMileRate() As String
            Get
                Return Me.bestMileRateField
            End Get
            Set
                Me.bestMileRateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property WinningDistance() As String
            Get
                Return Me.winningDistanceField
            End Get
            Set
                Me.winningDistanceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum StatisticTypeType

        '''<remarks/>
        all

        '''<remarks/>
        distance

        '''<remarks/>
        track

        '''<remarks/>
        fast

        '''<remarks/>
        good

        '''<remarks/>
        dead

        '''<remarks/>
        slow

        '''<remarks/>
        soft

        '''<remarks/>
        firm

        '''<remarks/>
        heavy

        '''<remarks/>
        first_up

        '''<remarks/>
        second_up

        '''<remarks/>
        jumps

        '''<remarks/>
        distance_track

        '''<remarks/>
        one_year

        '''<remarks/>
        BestMileRate

        '''<remarks/>
        synthetic

        '''<remarks/>
        distancewins

        '''<remarks/>
        heavy_new

        '''<remarks/>
        good_new

        '''<remarks/>
        unknown
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class TrainerTypeProviderID

        Private sourceField As TrainerTypeProviderIDSource

        Private idField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As TrainerTypeProviderIDSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum TrainerTypeProviderIDSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum FavouriteIndicatorType

        '''<remarks/>
        E

        '''<remarks/>
        F
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum HorseTypeEmergency_indicator

        '''<remarks/>
        E
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class JockeyType

        Private statisticsField() As StatisticType

        Private providerIDField As JockeyTypeProviderID

        Private nameField As String

        Private apprentice_indicatorField As JockeyTypeApprentice_indicator

        Private apprentice_indicatorFieldSpecified As Boolean

        Private allowance_weightField As Decimal

        Private allowance_weightFieldSpecified As Boolean

        Private idField As Long

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("statistic", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property statistics() As StatisticType()
            Get
                Return Me.statisticsField
            End Get
            Set
                Me.statisticsField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ProviderID() As JockeyTypeProviderID
            Get
                Return Me.providerIDField
            End Get
            Set
                Me.providerIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property apprentice_indicator() As JockeyTypeApprentice_indicator
            Get
                Return Me.apprentice_indicatorField
            End Get
            Set
                Me.apprentice_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property apprentice_indicatorSpecified() As Boolean
            Get
                Return Me.apprentice_indicatorFieldSpecified
            End Get
            Set
                Me.apprentice_indicatorFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property allowance_weight() As Decimal
            Get
                Return Me.allowance_weightField
            End Get
            Set
                Me.allowance_weightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property allowance_weightSpecified() As Boolean
            Get
                Return Me.allowance_weightFieldSpecified
            End Get
            Set
                Me.allowance_weightFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property id() As Long
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class JockeyTypeProviderID

        Private sourceField As JockeyTypeProviderIDSource

        Private idField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As JockeyTypeProviderIDSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum JockeyTypeProviderIDSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum JockeyTypeApprentice_indicator

        '''<remarks/>
        A

        '''<remarks/>
        Y
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class WeightType

        Private allocatedField As Decimal

        Private performance_penaltyField As Decimal

        Private performance_penaltyFieldSpecified As Boolean

        Private weight_carriedField As Decimal

        Private weight_carriedFieldSpecified As Boolean

        Private weight_adjField As Decimal

        Private weight_adjFieldSpecified As Boolean

        Private weight_raisedField As Decimal

        Private weight_raisedFieldSpecified As Boolean

        Private weight_inpoundsField As Decimal

        Private weight_inpoundsFieldSpecified As Boolean

        Private totalField As Decimal

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property allocated() As Decimal
            Get
                Return Me.allocatedField
            End Get
            Set
                Me.allocatedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property performance_penalty() As Decimal
            Get
                Return Me.performance_penaltyField
            End Get
            Set
                Me.performance_penaltyField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property performance_penaltySpecified() As Boolean
            Get
                Return Me.performance_penaltyFieldSpecified
            End Get
            Set
                Me.performance_penaltyFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property weight_carried() As Decimal
            Get
                Return Me.weight_carriedField
            End Get
            Set
                Me.weight_carriedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property weight_carriedSpecified() As Boolean
            Get
                Return Me.weight_carriedFieldSpecified
            End Get
            Set
                Me.weight_carriedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property weight_adj() As Decimal
            Get
                Return Me.weight_adjField
            End Get
            Set
                Me.weight_adjField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property weight_adjSpecified() As Boolean
            Get
                Return Me.weight_adjFieldSpecified
            End Get
            Set
                Me.weight_adjFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property weight_raised() As Decimal
            Get
                Return Me.weight_raisedField
            End Get
            Set
                Me.weight_raisedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property weight_raisedSpecified() As Boolean
            Get
                Return Me.weight_raisedFieldSpecified
            End Get
            Set
                Me.weight_raisedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property weight_inpounds() As Decimal
            Get
                Return Me.weight_inpoundsField
            End Get
            Set
                Me.weight_inpoundsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property weight_inpoundsSpecified() As Boolean
            Get
                Return Me.weight_inpoundsFieldSpecified
            End Get
            Set
                Me.weight_inpoundsFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property total() As Decimal
            Get
                Return Me.totalField
            End Get
            Set
                Me.totalField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class MarketType

        Private priceField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property price() As String
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class PriceType

        Private sourceField As PriceTypeSource

        Private sourceFieldSpecified As Boolean

        Private descriptionField As String

        Private typeField As String

        Private decimalOddsField As Single

        Private priceType1Field As PriceTypePriceType

        Private timeStampField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As PriceTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SourceSpecified() As Boolean
            Get
                Return Me.sourceFieldSpecified
            End Get
            Set
                Me.sourceFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Description() As String
            Get
                Return Me.descriptionField
            End Get
            Set
                Me.descriptionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DecimalOdds() As Single
            Get
                Return Me.decimalOddsField
            End Get
            Set
                Me.decimalOddsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute("PriceType")>
        Public Property PriceType1() As PriceTypePriceType
            Get
                Return Me.priceType1Field
            End Get
            Set
                Me.priceType1Field = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TimeStamp() As Date
            Get
                Return Me.timeStampField
            End Get
            Set
                Me.timeStampField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum PriceTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum PriceTypePriceType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class WinDistanceType

        Private distanceField As Short

        Private winsField As Short

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property distance() As Short
            Get
                Return Me.distanceField
            End Get
            Set
                Me.distanceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property wins() As Short
            Get
                Return Me.winsField
            End Get
            Set
                Me.winsField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RatingType

        Private typeField As RatingTypeType

        Private typeFieldSpecified As Boolean

        Private valueField As Decimal

        Private valueFieldSpecified As Boolean

        Private dateField As String

        Private unadjustedField As Decimal

        Private unadjustedFieldSpecified As Boolean

        Private adjustedField As Decimal

        Private adjustedFieldSpecified As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property type() As RatingTypeType
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property typeSpecified() As Boolean
            Get
                Return Me.typeFieldSpecified
            End Get
            Set
                Me.typeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property value() As Decimal
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property valueSpecified() As Boolean
            Get
                Return Me.valueFieldSpecified
            End Get
            Set
                Me.valueFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [date]() As String
            Get
                Return Me.dateField
            End Get
            Set
                Me.dateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property unadjusted() As Decimal
            Get
                Return Me.unadjustedField
            End Get
            Set
                Me.unadjustedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property unadjustedSpecified() As Boolean
            Get
                Return Me.unadjustedFieldSpecified
            End Get
            Set
                Me.unadjustedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property adjusted() As Decimal
            Get
                Return Me.adjustedField
            End Get
            Set
                Me.adjustedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property adjustedSpecified() As Boolean
            Get
                Return Me.adjustedFieldSpecified
            End Get
            Set
                Me.adjustedFieldSpecified = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RatingTypeType

        '''<remarks/>
        career

        '''<remarks/>
        preparation

        '''<remarks/>
        track

        '''<remarks/>
        distance

        '''<remarks/>
        distance_track

        '''<remarks/>
        fast

        '''<remarks/>
        good

        '''<remarks/>
        dead

        '''<remarks/>
        slow

        '''<remarks/>
        heavy

        '''<remarks/>
        first_up

        '''<remarks/>
        second_up

        '''<remarks/>
        jumps

        '''<remarks/>
        handicap
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class FormType

        Private gear_changesField() As ArrayOfHorseGearGear

        Private idField As Long

        Private raceNumberField As Integer

        Private raceNumberFieldSpecified As Boolean

        Private earlySpeedRatingField As String

        Private bestTimeOfNightField As String

        Private ratingField As String

        Private dateField As String

        Private daysSinceField As Integer

        Private raceClassField As String

        Private numberOfRunnersField As String

        Private finishField As String

        Private marginField As String

        Private distanceField As String

        Private trackField As String

        Private trackConditionField As String

        Private racetimeField As String

        Private timeRanField As String

        Private sectionalsField As String

        Private jockeyField As String

        Private barrierField As String

        Private weightCarriedField As Single

        Private weightCarriedFieldSpecified As Boolean

        Private bodyWeightField As Single

        Private bodyWeightFieldSpecified As Boolean

        Private startingHandicapField As String

        Private startingPriceField As String

        Private raceWinnerField As String

        Private raceWinnerWeightField As String

        Private raceWinnerSPField As String

        Private raceWinnerJockeyField As String

        Private raceSecondField As String

        Private raceSecondWeightField As String

        Private raceSecondSPField As String

        Private raceSecondJockeyField As String

        Private raceThirdField As String

        Private raceThirdWeightField As String

        Private raceThirdSPField As String

        Private raceThirdJockeyField As String

        Private commentField As String

        Private videoCodeField As String

        Private rowField As String

        Private startTypeField As String

        Private mileRateField As String

        Private lastMileField As String

        Private limitWeightField As String

        Private track4CharField As String

        Private inRunField As String

        Private racePrizemoneyField As String

        Private firstSplitField As String

        Private trackTypeField As String

        Private rail_PositionField As String

        Private isTrialField As Boolean

        Private isTrialFieldSpecified As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("gear", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property gear_changes() As ArrayOfHorseGearGear()
            Get
                Return Me.gear_changesField
            End Get
            Set
                Me.gear_changesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Id() As Long
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceNumber() As Integer
            Get
                Return Me.raceNumberField
            End Get
            Set
                Me.raceNumberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RaceNumberSpecified() As Boolean
            Get
                Return Me.raceNumberFieldSpecified
            End Get
            Set
                Me.raceNumberFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property EarlySpeedRating() As String
            Get
                Return Me.earlySpeedRatingField
            End Get
            Set
                Me.earlySpeedRatingField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BestTimeOfNight() As String
            Get
                Return Me.bestTimeOfNightField
            End Get
            Set
                Me.bestTimeOfNightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Rating() As String
            Get
                Return Me.ratingField
            End Get
            Set
                Me.ratingField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [date]() As String
            Get
                Return Me.dateField
            End Get
            Set
                Me.dateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DaysSince() As Integer
            Get
                Return Me.daysSinceField
            End Get
            Set
                Me.daysSinceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceClass() As String
            Get
                Return Me.raceClassField
            End Get
            Set
                Me.raceClassField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property NumberOfRunners() As String
            Get
                Return Me.numberOfRunnersField
            End Get
            Set
                Me.numberOfRunnersField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Finish() As String
            Get
                Return Me.finishField
            End Get
            Set
                Me.finishField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Margin() As String
            Get
                Return Me.marginField
            End Get
            Set
                Me.marginField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Distance() As String
            Get
                Return Me.distanceField
            End Get
            Set
                Me.distanceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Track() As String
            Get
                Return Me.trackField
            End Get
            Set
                Me.trackField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TrackCondition() As String
            Get
                Return Me.trackConditionField
            End Get
            Set
                Me.trackConditionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Racetime() As String
            Get
                Return Me.racetimeField
            End Get
            Set
                Me.racetimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TimeRan() As String
            Get
                Return Me.timeRanField
            End Get
            Set
                Me.timeRanField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Sectionals() As String
            Get
                Return Me.sectionalsField
            End Get
            Set
                Me.sectionalsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Jockey() As String
            Get
                Return Me.jockeyField
            End Get
            Set
                Me.jockeyField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Barrier() As String
            Get
                Return Me.barrierField
            End Get
            Set
                Me.barrierField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property WeightCarried() As Single
            Get
                Return Me.weightCarriedField
            End Get
            Set
                Me.weightCarriedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property WeightCarriedSpecified() As Boolean
            Get
                Return Me.weightCarriedFieldSpecified
            End Get
            Set
                Me.weightCarriedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BodyWeight() As Single
            Get
                Return Me.bodyWeightField
            End Get
            Set
                Me.bodyWeightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property BodyWeightSpecified() As Boolean
            Get
                Return Me.bodyWeightFieldSpecified
            End Get
            Set
                Me.bodyWeightFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property StartingHandicap() As String
            Get
                Return Me.startingHandicapField
            End Get
            Set
                Me.startingHandicapField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property StartingPrice() As String
            Get
                Return Me.startingPriceField
            End Get
            Set
                Me.startingPriceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceWinner() As String
            Get
                Return Me.raceWinnerField
            End Get
            Set
                Me.raceWinnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceWinnerWeight() As String
            Get
                Return Me.raceWinnerWeightField
            End Get
            Set
                Me.raceWinnerWeightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceWinnerSP() As String
            Get
                Return Me.raceWinnerSPField
            End Get
            Set
                Me.raceWinnerSPField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceWinnerJockey() As String
            Get
                Return Me.raceWinnerJockeyField
            End Get
            Set
                Me.raceWinnerJockeyField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceSecond() As String
            Get
                Return Me.raceSecondField
            End Get
            Set
                Me.raceSecondField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceSecondWeight() As String
            Get
                Return Me.raceSecondWeightField
            End Get
            Set
                Me.raceSecondWeightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceSecondSP() As String
            Get
                Return Me.raceSecondSPField
            End Get
            Set
                Me.raceSecondSPField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceSecondJockey() As String
            Get
                Return Me.raceSecondJockeyField
            End Get
            Set
                Me.raceSecondJockeyField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceThird() As String
            Get
                Return Me.raceThirdField
            End Get
            Set
                Me.raceThirdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceThirdWeight() As String
            Get
                Return Me.raceThirdWeightField
            End Get
            Set
                Me.raceThirdWeightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceThirdSP() As String
            Get
                Return Me.raceThirdSPField
            End Get
            Set
                Me.raceThirdSPField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceThirdJockey() As String
            Get
                Return Me.raceThirdJockeyField
            End Get
            Set
                Me.raceThirdJockeyField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Comment() As String
            Get
                Return Me.commentField
            End Get
            Set
                Me.commentField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VideoCode() As String
            Get
                Return Me.videoCodeField
            End Get
            Set
                Me.videoCodeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Row() As String
            Get
                Return Me.rowField
            End Get
            Set
                Me.rowField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property StartType() As String
            Get
                Return Me.startTypeField
            End Get
            Set
                Me.startTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MileRate() As String
            Get
                Return Me.mileRateField
            End Get
            Set
                Me.mileRateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property LastMile() As String
            Get
                Return Me.lastMileField
            End Get
            Set
                Me.lastMileField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property LimitWeight() As String
            Get
                Return Me.limitWeightField
            End Get
            Set
                Me.limitWeightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Track4Char() As String
            Get
                Return Me.track4CharField
            End Get
            Set
                Me.track4CharField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property InRun() As String
            Get
                Return Me.inRunField
            End Get
            Set
                Me.inRunField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RacePrizemoney() As String
            Get
                Return Me.racePrizemoneyField
            End Get
            Set
                Me.racePrizemoneyField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FirstSplit() As String
            Get
                Return Me.firstSplitField
            End Get
            Set
                Me.firstSplitField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TrackType() As String
            Get
                Return Me.trackTypeField
            End Get
            Set
                Me.trackTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Rail_Position() As String
            Get
                Return Me.rail_PositionField
            End Get
            Set
                Me.rail_PositionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property IsTrial() As Boolean
            Get
                Return Me.isTrialField
            End Get
            Set
                Me.isTrialField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property IsTrialSpecified() As Boolean
            Get
                Return Me.isTrialFieldSpecified
            End Get
            Set
                Me.isTrialFieldSpecified = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RunnerCommentType

        Private runnerCommentField As String

        Private sourceField As RunnerCommentTypeSource

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RunnerComment() As String
            Get
                Return Me.runnerCommentField
            End Get
            Set
                Me.runnerCommentField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As RunnerCommentTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RunnerCommentTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class HorseTypeProviderID

        Private sourceField As HorseTypeProviderIDSource

        Private idField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As HorseTypeProviderIDSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum HorseTypeProviderIDSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfProviderIDTypeAdditionalProviderIDs

        Private sourceField As ArrayOfProviderIDTypeAdditionalProviderIDsSource

        Private idField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As ArrayOfProviderIDTypeAdditionalProviderIDsSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ArrayOfProviderIDTypeAdditionalProviderIDsSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum HorseTypeSex

        '''<remarks/>
        U

        '''<remarks/>
        C

        '''<remarks/>
        F

        '''<remarks/>
        G

        '''<remarks/>
        H

        '''<remarks/>
        M

        '''<remarks/>
        R

        '''<remarks/>
        D

        '''<remarks/>
        B
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum HorseTypeColour

        '''<remarks/>
        ch

        '''<remarks/>
        b

        '''<remarks/>
        br

        '''<remarks/>
        bl

        '''<remarks/>
        gr

        '''<remarks/>
        r

        '''<remarks/>
        ap

        '''<remarks/>
        pl

        '''<remarks/>
        pi

        '''<remarks/>
        wh

        '''<remarks/>
        ta

        '''<remarks/>
        pa

        '''<remarks/>
        ro

        '''<remarks/>
        du

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("b/br")>
        bbr

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("br/bl")>
        brbl

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/ch")>
        grch

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/b")>
        grb

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/br")>
        grbr

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/bl")>
        grbl

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/ro")>
        grro

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("du/ch")>
        duch

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("wh/b")>
        whb

        '''<remarks/>
        bd

        '''<remarks/>
        wbd

        '''<remarks/>
        wbk

        '''<remarks/>
        be

        '''<remarks/>
        bk

        '''<remarks/>
        bebdw

        '''<remarks/>
        wrf

        '''<remarks/>
        dkbd

        '''<remarks/>
        bkw

        '''<remarks/>
        ltf

        '''<remarks/>
        lf

        '''<remarks/>
        lb

        '''<remarks/>
        lbw

        '''<remarks/>
        ltbd

        '''<remarks/>
        bebd

        '''<remarks/>
        f

        '''<remarks/>
        wf

        '''<remarks/>
        wbe

        '''<remarks/>
        rf

        '''<remarks/>
        rbd

        '''<remarks/>
        bdw

        '''<remarks/>
        bew

        '''<remarks/>
        brw

        '''<remarks/>
        fw

        '''<remarks/>
        bef

        '''<remarks/>
        webed

        '''<remarks/>
        wbebd

        '''<remarks/>
        bkbd

        '''<remarks/>
        befw

        '''<remarks/>
        w

        '''<remarks/>
        rfw

        '''<remarks/>
        wrbd

        '''<remarks/>
        wdkbd

        '''<remarks/>
        wb

        '''<remarks/>
        blblk

        '''<remarks/>
        blf

        '''<remarks/>
        unknown
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum RaceTypeStatus

        '''<remarks/>
        OPEN

        '''<remarks/>
        CLOSED

        '''<remarks/>
        INTERIM

        '''<remarks/>
        FINAL

        '''<remarks/>
        INPROGRESS

        '''<remarks/>
        BEHINDGATES

        '''<remarks/>
        PASTPOST

        '''<remarks/>
        ABANDONED

        '''<remarks/>
        PROTEST

        '''<remarks/>
        UNKNOWN
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class meeting

        Private dateField As String

        Private tab_indicatorField As String

        Private meetingTypeField As meetingMeetingType

        Private trackField As TrackType

        Private advancedGoingField As String

        Private rail_positionField As String

        Private toteCodesField() As ToteCodeType

        Private productField As ProductType

        Private stageField As String

        Private meetingidField As Long

        Private meetingidFieldSpecified As Boolean

        Private versionField As Integer

        Private versionFieldSpecified As Boolean

        Private validatedField As Boolean

        Private validatedFieldSpecified As Boolean

        Private numberOfRacesField As Integer

        Private numberOfRacesFieldSpecified As Boolean

        Private externalMeetingIDField As String

        Private meetingSourceField As meetingMeetingSource

        Private meetingSourceFieldSpecified As Boolean

        Private racesField() As RaceType

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property [date]() As String
            Get
                Return Me.dateField
            End Get
            Set
                Me.dateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property tab_indicator() As String
            Get
                Return Me.tab_indicatorField
            End Get
            Set
                Me.tab_indicatorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property MeetingType() As meetingMeetingType
            Get
                Return Me.meetingTypeField
            End Get
            Set
                Me.meetingTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property track() As TrackType
            Get
                Return Me.trackField
            End Get
            Set
                Me.trackField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property AdvancedGoing() As String
            Get
                Return Me.advancedGoingField
            End Get
            Set
                Me.advancedGoingField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property rail_position() As String
            Get
                Return Me.rail_positionField
            End Get
            Set
                Me.rail_positionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("ToteCode", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property ToteCodes() As ToteCodeType()
            Get
                Return Me.toteCodesField
            End Get
            Set
                Me.toteCodesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property product() As ProductType
            Get
                Return Me.productField
            End Get
            Set
                Me.productField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property stage() As String
            Get
                Return Me.stageField
            End Get
            Set
                Me.stageField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Meetingid() As Long
            Get
                Return Me.meetingidField
            End Get
            Set
                Me.meetingidField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property MeetingidSpecified() As Boolean
            Get
                Return Me.meetingidFieldSpecified
            End Get
            Set
                Me.meetingidFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Version() As Integer
            Get
                Return Me.versionField
            End Get
            Set
                Me.versionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VersionSpecified() As Boolean
            Get
                Return Me.versionFieldSpecified
            End Get
            Set
                Me.versionFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Validated() As Boolean
            Get
                Return Me.validatedField
            End Get
            Set
                Me.validatedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ValidatedSpecified() As Boolean
            Get
                Return Me.validatedFieldSpecified
            End Get
            Set
                Me.validatedFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property NumberOfRaces() As Integer
            Get
                Return Me.numberOfRacesField
            End Get
            Set
                Me.numberOfRacesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property NumberOfRacesSpecified() As Boolean
            Get
                Return Me.numberOfRacesFieldSpecified
            End Get
            Set
                Me.numberOfRacesFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property ExternalMeetingID() As String
            Get
                Return Me.externalMeetingIDField
            End Get
            Set
                Me.externalMeetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property MeetingSource() As meetingMeetingSource
            Get
                Return Me.meetingSourceField
            End Get
            Set
                Me.meetingSourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property MeetingSourceSpecified() As Boolean
            Get
                Return Me.meetingSourceFieldSpecified
            End Get
            Set
                Me.meetingSourceFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("race", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property races() As RaceType()
            Get
                Return Me.racesField
            End Get
            Set
                Me.racesField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum meetingMeetingType

        '''<remarks/>
        HorseRacing

        '''<remarks/>
        HarnessRacing

        '''<remarks/>
        GreyHoundRacing

        '''<remarks/>
        HorseRacingTrial

        '''<remarks/>
        HarnessRacingTrial

        '''<remarks/>
        GreyHoundRacingQuali

        '''<remarks/>
        Other
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum meetingMeetingSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum MeetingTypeIndicator

        '''<remarks/>
        HorseRacing

        '''<remarks/>
        HarnessRacing

        '''<remarks/>
        GreyHoundRacing

        '''<remarks/>
        HorseRacingTrial

        '''<remarks/>
        HarnessRacingTrial

        '''<remarks/>
        GreyHoundRacingQuali

        '''<remarks/>
        Other
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("TrackTypeLocation", [Namespace]:="", IsNullable:=False)>
    Public Enum TrackTypeLocation1

        '''<remarks/>
        C

        '''<remarks/>
        M

        '''<remarks/>
        P

        '''<remarks/>
        G

        '''<remarks/>
        F

        '''<remarks/>
        X
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("TrackTypeCondition", [Namespace]:="", IsNullable:=False)>
    Public Enum TrackTypeCondition1

        '''<remarks/>
        Unknown

        '''<remarks/>
        Firm1

        '''<remarks/>
        Firm2

        '''<remarks/>
        Good3

        '''<remarks/>
        Good4

        '''<remarks/>
        Soft5

        '''<remarks/>
        Soft6

        '''<remarks/>
        Soft7

        '''<remarks/>
        Heavy8

        '''<remarks/>
        Heavy9

        '''<remarks/>
        Heavy10

        '''<remarks/>
        Dead

        '''<remarks/>
        Dirt

        '''<remarks/>
        Easy

        '''<remarks/>
        Fair

        '''<remarks/>
        Fast

        '''<remarks/>
        Good

        '''<remarks/>
        Heavy

        '''<remarks/>
        Sand

        '''<remarks/>
        Slow

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("Very Heavy")>
        VeryHeavy

        '''<remarks/>
        Firm

        '''<remarks/>
        Soft
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("TrackTypeNight_meeting", [Namespace]:="", IsNullable:=False)>
    Public Enum TrackTypeNight_meeting1

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("")>
        Item

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("0")>
        Item0

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1")>
        Item1
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("RatingTypeType", [Namespace]:="", IsNullable:=False)>
    Public Enum RatingTypeType1

        '''<remarks/>
        career

        '''<remarks/>
        preparation

        '''<remarks/>
        track

        '''<remarks/>
        distance

        '''<remarks/>
        distance_track

        '''<remarks/>
        fast

        '''<remarks/>
        good

        '''<remarks/>
        dead

        '''<remarks/>
        slow

        '''<remarks/>
        heavy

        '''<remarks/>
        first_up

        '''<remarks/>
        second_up

        '''<remarks/>
        jumps

        '''<remarks/>
        handicap
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("StatisticTypeType", [Namespace]:="", IsNullable:=False)>
    Public Enum StatisticTypeType1

        '''<remarks/>
        all

        '''<remarks/>
        distance

        '''<remarks/>
        track

        '''<remarks/>
        fast

        '''<remarks/>
        good

        '''<remarks/>
        dead

        '''<remarks/>
        slow

        '''<remarks/>
        soft

        '''<remarks/>
        firm

        '''<remarks/>
        heavy

        '''<remarks/>
        first_up

        '''<remarks/>
        second_up

        '''<remarks/>
        jumps

        '''<remarks/>
        distance_track

        '''<remarks/>
        one_year

        '''<remarks/>
        BestMileRate

        '''<remarks/>
        synthetic

        '''<remarks/>
        distancewins

        '''<remarks/>
        heavy_new

        '''<remarks/>
        good_new

        '''<remarks/>
        unknown
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("JockeyTypeApprentice_indicator", [Namespace]:="", IsNullable:=False)>
    Public Enum JockeyTypeApprentice_indicator1

        '''<remarks/>
        A

        '''<remarks/>
        Y
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class FileData

        Private fileNameField As String

        Private fileData1Field As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FileName() As String
            Get
                Return Me.fileNameField
            End Get
            Set
                Me.fileNameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute("FileData")>
        Public Property FileData1() As String
            Get
                Return Me.fileData1Field
            End Get
            Set
                Me.fileData1Field = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class HorseList

        Private horsesField() As HorseType

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("HorseList", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Horses() As HorseType()
            Get
                Return Me.horsesField
            End Get
            Set
                Me.horsesField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RaceList

        Private racesField() As RaceType

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("RaceList", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Races() As RaceType()
            Get
                Return Me.racesField
            End Get
            Set
                Me.racesField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class ProviderIDType

        Private sourceField As ProviderIDTypeSource

        Private idField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As ProviderIDTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ProviderIDTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class HorseGear

        Private idField As String

        Private nameField As String

        Private optionField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [option]() As String
            Get
                Return Me.optionField
            End Get
            Set
                Me.optionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum StatusIndicator

        '''<remarks/>
        Starter

        '''<remarks/>
        Scratched

        '''<remarks/>
        LateScratching
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum emergency_indicator

        '''<remarks/>
        E
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("HorseTypeColour", [Namespace]:="", IsNullable:=False)>
    Public Enum HorseTypeColour1

        '''<remarks/>
        ch

        '''<remarks/>
        b

        '''<remarks/>
        br

        '''<remarks/>
        bl

        '''<remarks/>
        gr

        '''<remarks/>
        r

        '''<remarks/>
        ap

        '''<remarks/>
        pl

        '''<remarks/>
        pi

        '''<remarks/>
        wh

        '''<remarks/>
        ta

        '''<remarks/>
        pa

        '''<remarks/>
        ro

        '''<remarks/>
        du

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("b/br")>
        bbr

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("br/bl")>
        brbl

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/ch")>
        grch

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/b")>
        grb

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/br")>
        grbr

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/bl")>
        grbl

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("gr/ro")>
        grro

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("du/ch")>
        duch

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("wh/b")>
        whb

        '''<remarks/>
        bd

        '''<remarks/>
        wbd

        '''<remarks/>
        wbk

        '''<remarks/>
        be

        '''<remarks/>
        bk

        '''<remarks/>
        bebdw

        '''<remarks/>
        wrf

        '''<remarks/>
        dkbd

        '''<remarks/>
        bkw

        '''<remarks/>
        ltf

        '''<remarks/>
        lf

        '''<remarks/>
        lb

        '''<remarks/>
        lbw

        '''<remarks/>
        ltbd

        '''<remarks/>
        bebd

        '''<remarks/>
        f

        '''<remarks/>
        wf

        '''<remarks/>
        wbe

        '''<remarks/>
        rf

        '''<remarks/>
        rbd

        '''<remarks/>
        bdw

        '''<remarks/>
        bew

        '''<remarks/>
        brw

        '''<remarks/>
        fw

        '''<remarks/>
        bef

        '''<remarks/>
        webed

        '''<remarks/>
        wbebd

        '''<remarks/>
        bkbd

        '''<remarks/>
        befw

        '''<remarks/>
        w

        '''<remarks/>
        rfw

        '''<remarks/>
        wrbd

        '''<remarks/>
        wdkbd

        '''<remarks/>
        wb

        '''<remarks/>
        blblk

        '''<remarks/>
        blf

        '''<remarks/>
        unknown
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("HorseTypeSex", [Namespace]:="", IsNullable:=False)>
    Public Enum HorseTypeSex1

        '''<remarks/>
        U

        '''<remarks/>
        C

        '''<remarks/>
        F

        '''<remarks/>
        G

        '''<remarks/>
        H

        '''<remarks/>
        M

        '''<remarks/>
        R

        '''<remarks/>
        D

        '''<remarks/>
        B
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("PrizeTypeType", [Namespace]:="", IsNullable:=False)>
    Public Enum PrizeTypeType1

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1st")>
        Item1st

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2nd")>
        Item2nd

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("3rd")>
        Item3rd

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("4th")>
        Item4th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("5th")>
        Item5th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("6th")>
        Item6th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("7th")>
        Item7th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("8th")>
        Item8th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("9th")>
        Item9th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("10th")>
        Item10th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("11th")>
        Item11th

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("12th")>
        Item12th

        '''<remarks/>
        total_value

        '''<remarks/>
        trophy_total_value

        '''<remarks/>
        welfare_fund

        '''<remarks/>
        jockey_trophy
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum SurfaceType

        '''<remarks/>
        Unknown

        '''<remarks/>
        Turf

        '''<remarks/>
        Sand

        '''<remarks/>
        Dirt

        '''<remarks/>
        PolyTrack

        '''<remarks/>
        EquiTrack

        '''<remarks/>
        AllWeather

        '''<remarks/>
        FibreSand
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("DistanceTypeAbout_indicator", [Namespace]:="", IsNullable:=False)>
    Public Enum DistanceTypeAbout_indicator1

        '''<remarks/>
        a
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum SourcePool

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class ScratchingType

        Private statusField As StatusType

        Private meetingIDField As String

        Private raceNumberField As String

        Private runnerNumberField As String

        Private runnerNameField As String

        '''<remarks/>
        Public Property Status() As StatusType
            Get
                Return Me.statusField
            End Get
            Set
                Me.statusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MeetingID() As String
            Get
                Return Me.meetingIDField
            End Get
            Set
                Me.meetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceNumber() As String
            Get
                Return Me.raceNumberField
            End Get
            Set
                Me.raceNumberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RunnerNumber() As String
            Get
                Return Me.runnerNumberField
            End Get
            Set
                Me.runnerNumberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RunnerName() As String
            Get
                Return Me.runnerNameField
            End Get
            Set
                Me.runnerNameField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum DividendStatusType

        '''<remarks/>
        Interim

        '''<remarks/>
        PartialPay

        '''<remarks/>
        Protest

        '''<remarks/>
        Pending

        '''<remarks/>
        Final

        '''<remarks/>
        ReResult

        '''<remarks/>
        Abandoned
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum GaitIndicator

        '''<remarks/>
        Gallop

        '''<remarks/>
        Pace

        '''<remarks/>
        Trot
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum BetType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum group

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("0")>
        Item0

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("1")>
        Item1

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("2")>
        Item2

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("3")>
        Item3

        '''<remarks/>
        <System.Xml.Serialization.XmlEnumAttribute("4")>
        Item4

        '''<remarks/>
        LR
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum RaceStatusIndicator

        '''<remarks/>
        OPEN

        '''<remarks/>
        CLOSED

        '''<remarks/>
        INTERIM

        '''<remarks/>
        FINAL

        '''<remarks/>
        INPROGRESS

        '''<remarks/>
        BEHINDGATES

        '''<remarks/>
        PASTPOST

        '''<remarks/>
        ABANDONED

        '''<remarks/>
        PROTEST

        '''<remarks/>
        UNKNOWN
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum barrier_trial_indicator

        '''<remarks/>
        B
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum blinkers_indicator

        '''<remarks/>
        B
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlRootAttribute("dead_heat_indicator", [Namespace]:="", IsNullable:=False)>
    Public Enum DeadHeatIndicatorType

        '''<remarks/>
        D

        '''<remarks/>
        T

        '''<remarks/>
        Q
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Public Enum favourite_indicator

        '''<remarks/>
        E

        '''<remarks/>
        F
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class PriceUpdateType

        Private meetingIDField As Long

        Private meetingIDFieldSpecified As Boolean

        Private raceNoField As Integer

        Private raceNoFieldSpecified As Boolean

        Private sourceField As PriceUpdateTypeSource

        Private priceTypeField As PriceUpdateTypePriceType

        Private poolSizeField As Single

        Private creationTimeField As Long

        Private creationTimeFieldSpecified As Boolean

        Private queuedTimeField As Long

        Private queuedTimeFieldSpecified As Boolean

        Private deliveryTimeField As Long

        Private deliveryTimeFieldSpecified As Boolean

        Private runnersField() As RunnerPriceData

        '''<remarks/>
        Public Property MeetingID() As Long
            Get
                Return Me.meetingIDField
            End Get
            Set
                Me.meetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property MeetingIDSpecified() As Boolean
            Get
                Return Me.meetingIDFieldSpecified
            End Get
            Set
                Me.meetingIDFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RaceNo() As Integer
            Get
                Return Me.raceNoField
            End Get
            Set
                Me.raceNoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RaceNoSpecified() As Boolean
            Get
                Return Me.raceNoFieldSpecified
            End Get
            Set
                Me.raceNoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Source() As PriceUpdateTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property PriceType() As PriceUpdateTypePriceType
            Get
                Return Me.priceTypeField
            End Get
            Set
                Me.priceTypeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property PoolSize() As Single
            Get
                Return Me.poolSizeField
            End Get
            Set
                Me.poolSizeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property CreationTime() As Long
            Get
                Return Me.creationTimeField
            End Get
            Set
                Me.creationTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property CreationTimeSpecified() As Boolean
            Get
                Return Me.creationTimeFieldSpecified
            End Get
            Set
                Me.creationTimeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property QueuedTime() As Long
            Get
                Return Me.queuedTimeField
            End Get
            Set
                Me.queuedTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property QueuedTimeSpecified() As Boolean
            Get
                Return Me.queuedTimeFieldSpecified
            End Get
            Set
                Me.queuedTimeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property DeliveryTime() As Long
            Get
                Return Me.deliveryTimeField
            End Get
            Set
                Me.deliveryTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DeliveryTimeSpecified() As Boolean
            Get
                Return Me.deliveryTimeFieldSpecified
            End Get
            Set
                Me.deliveryTimeFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("Runner", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Runners() As RunnerPriceData()
            Get
                Return Me.runnersField
            End Get
            Set
                Me.runnersField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum PriceUpdateTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum PriceUpdateTypePriceType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RunnerPriceData

        Private statusField As StatusType

        Private tabNoField As String

        Private nameField As String

        Private priceField As Single

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property Status() As StatusType
            Get
                Return Me.statusField
            End Get
            Set
                Me.statusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TabNo() As String
            Get
                Return Me.tabNoField
            End Get
            Set
                Me.tabNoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Price() As Single
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class derivative

        Private marketIdField As String

        Private updateTypeField As String

        Private sourceField As derivativeSource

        Private marketTypeField As String

        Private titleField As String

        Private selectedmarketsField() As ArrayOfDerivativeSelectedmarketsMarketMarket

        Private racesField() As ArrayOfDerivativeRacesRaceRace

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property marketId() As String
            Get
                Return Me.marketIdField
            End Get
            Set
                Me.marketIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property updateType() As String
            Get
                Return Me.updateTypeField
            End Get
            Set
                Me.updateTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property source() As derivativeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property marketType() As String
            Get
                Return Me.marketTypeField
            End Get
            Set
                Me.marketTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property title() As String
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute("selected-markets", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("market", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property selectedmarkets() As ArrayOfDerivativeSelectedmarketsMarketMarket()
            Get
                Return Me.selectedmarketsField
            End Get
            Set
                Me.selectedmarketsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("race", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property races() As ArrayOfDerivativeRacesRaceRace()
            Get
                Return Me.racesField
            End Get
            Set
                Me.racesField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum derivativeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfDerivativeSelectedmarketsMarketMarket

        Private meetingIdField As String

        Private raceNoField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property meetingId() As String
            Get
                Return Me.meetingIdField
            End Get
            Set
                Me.meetingIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property raceNo() As String
            Get
                Return Me.raceNoField
            End Get
            Set
                Me.raceNoField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfDerivativeRacesRaceRace

        Private runnerField() As ArrayOfDerivativeRacesRaceRaceRunner

        Private numberField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("runner", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property runner() As ArrayOfDerivativeRacesRaceRaceRunner()
            Get
                Return Me.runnerField
            End Get
            Set
                Me.runnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property number() As String
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfDerivativeRacesRaceRaceRunner

        Private numberField As String

        Private nameField As String

        Private priceField As String

        Private statusField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property number() As String
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property price() As String
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property status() As String
            Get
                Return Me.statusField
            End Get
            Set
                Me.statusField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class derivativeSelectedmarketsMarket

        Private meetingIdField As String

        Private raceNoField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property meetingId() As String
            Get
                Return Me.meetingIdField
            End Get
            Set
                Me.meetingIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property raceNo() As String
            Get
                Return Me.raceNoField
            End Get
            Set
                Me.raceNoField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class derivativeRacesRace

        Private runnerField() As derivativeRacesRaceRunner

        Private numberField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("runner", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property runner() As derivativeRacesRaceRunner()
            Get
                Return Me.runnerField
            End Get
            Set
                Me.runnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property number() As String
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class derivativeRacesRaceRunner

        Private numberField As String

        Private nameField As String

        Private priceField As String

        Private statusField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property number() As String
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property price() As String
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property status() As String
            Get
                Return Me.statusField
            End Get
            Set
                Me.statusField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("derivativeRacesRaceRunner", [Namespace]:="", IsNullable:=True)>
    Partial Public Class derivativeRacesRaceRunner1

        Private numberField As String

        Private nameField As String

        Private priceField As String

        Private statusField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property number() As String
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property price() As String
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property status() As String
            Get
                Return Me.statusField
            End Get
            Set
                Me.statusField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class NewDataSet

        Private derivativeField() As NewDataSetDerivative

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("derivative")>
        Public Property derivative() As NewDataSetDerivative()
            Get
                Return Me.derivativeField
            End Get
            Set
                Me.derivativeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class NewDataSetDerivative

        Private marketIdField As String

        Private updateTypeField As String

        Private sourceField As NewDataSetDerivativeSource

        Private marketTypeField As String

        Private titleField As String

        Private selectedmarketsField() As ArrayOfDerivativeSelectedmarketsMarketMarket

        Private racesField() As ArrayOfDerivativeRacesRaceRace

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property marketId() As String
            Get
                Return Me.marketIdField
            End Get
            Set
                Me.marketIdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property updateType() As String
            Get
                Return Me.updateTypeField
            End Get
            Set
                Me.updateTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property source() As NewDataSetDerivativeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property marketType() As String
            Get
                Return Me.marketTypeField
            End Get
            Set
                Me.marketTypeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>
        Public Property title() As String
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute("selected-markets", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("market", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property selectedmarkets() As ArrayOfDerivativeSelectedmarketsMarketMarket()
            Get
                Return Me.selectedmarketsField
            End Get
            Set
                Me.selectedmarketsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("race", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property races() As ArrayOfDerivativeRacesRaceRace()
            Get
                Return Me.racesField
            End Get
            Set
                Me.racesField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum NewDataSetDerivativeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class ExoticPriceUpdateType

        Private meetingIDField As Long

        Private meetingIDFieldSpecified As Boolean

        Private raceNoField As Integer

        Private raceNoFieldSpecified As Boolean

        Private sourceField As ExoticPriceUpdateTypeSource

        Private priceTypeField As ExoticPriceUpdateTypePriceType

        Private poolSizeField As Single

        Private exoticsField() As ExoticPriceData

        '''<remarks/>
        Public Property MeetingID() As Long
            Get
                Return Me.meetingIDField
            End Get
            Set
                Me.meetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property MeetingIDSpecified() As Boolean
            Get
                Return Me.meetingIDFieldSpecified
            End Get
            Set
                Me.meetingIDFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property RaceNo() As Integer
            Get
                Return Me.raceNoField
            End Get
            Set
                Me.raceNoField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RaceNoSpecified() As Boolean
            Get
                Return Me.raceNoFieldSpecified
            End Get
            Set
                Me.raceNoFieldSpecified = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Source() As ExoticPriceUpdateTypeSource
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property PriceType() As ExoticPriceUpdateTypePriceType
            Get
                Return Me.priceTypeField
            End Get
            Set
                Me.priceTypeField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property PoolSize() As Single
            Get
                Return Me.poolSizeField
            End Get
            Set
                Me.poolSizeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified),
     System.Xml.Serialization.XmlArrayItemAttribute("Runner", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=False)>
        Public Property Exotics() As ExoticPriceData()
            Get
                Return Me.exoticsField
            End Get
            Set
                Me.exoticsField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ExoticPriceUpdateTypeSource

        '''<remarks/>
        RacingServices1

        '''<remarks/>
        RacingServices2

        '''<remarks/>
        RacingServices3

        '''<remarks/>
        RacingServices4

        '''<remarks/>
        RacingServices5

        '''<remarks/>
        RacingServices6

        '''<remarks/>
        RacingServices7

        '''<remarks/>
        RacingServices8

        '''<remarks/>
        RacingServices9

        '''<remarks/>
        RacingServices10

        '''<remarks/>
        RacingServices11

        '''<remarks/>
        RacingServices12

        '''<remarks/>
        RacingServices13

        '''<remarks/>
        RacingServices14

        '''<remarks/>
        RacingServices15

        '''<remarks/>
        RacingServices16

        '''<remarks/>
        RacingServices17

        '''<remarks/>
        RacingServices18

        '''<remarks/>
        RacingServices19

        '''<remarks/>
        RacingServices20

        '''<remarks/>
        RacingServices21

        '''<remarks/>
        RacingServices22

        '''<remarks/>
        RacingServices23

        '''<remarks/>
        RacingServices24

        '''<remarks/>
        RacingServices25

        '''<remarks/>
        RacingServices26

        '''<remarks/>
        RacingServices27

        '''<remarks/>
        RacingServices28

        '''<remarks/>
        RacingServices29

        '''<remarks/>
        RacingServices30

        '''<remarks/>
        RacingServices31

        '''<remarks/>
        RacingServices32

        '''<remarks/>
        RacingServices33

        '''<remarks/>
        RacingServices34

        '''<remarks/>
        RacingServices35

        '''<remarks/>
        RacingServices36

        '''<remarks/>
        RacingServices37

        '''<remarks/>
        RacingServices38

        '''<remarks/>
        RacingServices39

        '''<remarks/>
        RacingServices40

        '''<remarks/>
        RacingServices41

        '''<remarks/>
        RacingServices42

        '''<remarks/>
        RacingServices43

        '''<remarks/>
        RacingServices44

        '''<remarks/>
        RacingServices45

        '''<remarks/>
        RacingServices46

        '''<remarks/>
        RacingServices47

        '''<remarks/>
        RacingServices48

        '''<remarks/>
        RacingServices49

        '''<remarks/>
        RacingServices50

        '''<remarks/>
        RacingServices51

        '''<remarks/>
        RacingServices52

        '''<remarks/>
        RacingServices53

        '''<remarks/>
        RacingServices54

        '''<remarks/>
        RacingServices55

        '''<remarks/>
        RacingServices56

        '''<remarks/>
        RacingServices57

        '''<remarks/>
        RacingServices58

        '''<remarks/>
        RacingServices59

        '''<remarks/>
        RacingServices60

        '''<remarks/>
        RacingServices61

        '''<remarks/>
        RacingServices62

        '''<remarks/>
        RacingServices63

        '''<remarks/>
        RacingServices64

        '''<remarks/>
        RacingServices65

        '''<remarks/>
        RacingServices66

        '''<remarks/>
        RacingServices67

        '''<remarks/>
        RacingServices68

        '''<remarks/>
        RacingServices69

        '''<remarks/>
        RacingServices70

        '''<remarks/>
        RacingServices71

        '''<remarks/>
        RacingServices72

        '''<remarks/>
        RacingServices73

        '''<remarks/>
        RacingServices74

        '''<remarks/>
        RacingServices75

        '''<remarks/>
        RacingServices76

        '''<remarks/>
        RacingServices77

        '''<remarks/>
        RacingServices78

        '''<remarks/>
        RacingServices79

        '''<remarks/>
        RacingServices80

        '''<remarks/>
        RacingServices81

        '''<remarks/>
        RacingServices82

        '''<remarks/>
        RacingServices83

        '''<remarks/>
        RacingServices84

        '''<remarks/>
        RacingServices85

        '''<remarks/>
        RacingServices86

        '''<remarks/>
        RacingServices87

        '''<remarks/>
        RacingServices88

        '''<remarks/>
        RacingServices89

        '''<remarks/>
        RacingServices90

        '''<remarks/>
        RacingServices91

        '''<remarks/>
        RacingServices92

        '''<remarks/>
        RacingServices93

        '''<remarks/>
        RacingServices94

        '''<remarks/>
        RacingServices95

        '''<remarks/>
        RacingServices96

        '''<remarks/>
        RacingServices97

        '''<remarks/>
        RacingServices98

        '''<remarks/>
        RacingServices99

        '''<remarks/>
        RacingServices100

        '''<remarks/>
        RacingServices101

        '''<remarks/>
        RacingServices102

        '''<remarks/>
        RacingServices103

        '''<remarks/>
        RacingServices104

        '''<remarks/>
        RacingServices105

        '''<remarks/>
        RacingServices106

        '''<remarks/>
        RacingServices107

        '''<remarks/>
        RacingServices108

        '''<remarks/>
        RacingServices109

        '''<remarks/>
        RacingServices110

        '''<remarks/>
        RacingServices111

        '''<remarks/>
        RacingServices112

        '''<remarks/>
        RacingServices113

        '''<remarks/>
        RacingServices114

        '''<remarks/>
        RacingServices115

        '''<remarks/>
        RacingServices116

        '''<remarks/>
        RacingServices117

        '''<remarks/>
        RacingServices118

        '''<remarks/>
        RacingServices119

        '''<remarks/>
        RacingServices120

        '''<remarks/>
        RacingServices121

        '''<remarks/>
        RacingServices122

        '''<remarks/>
        RacingServices123

        '''<remarks/>
        RacingServices124

        '''<remarks/>
        RacingServices125

        '''<remarks/>
        RacingServices126

        '''<remarks/>
        RacingServices127

        '''<remarks/>
        RacingServices128

        '''<remarks/>
        RacingServices129

        '''<remarks/>
        RacingServices130

        '''<remarks/>
        RacingServices131

        '''<remarks/>
        RacingServices132

        '''<remarks/>
        RacingServices133

        '''<remarks/>
        RacingServices134

        '''<remarks/>
        RacingServices135

        '''<remarks/>
        RacingServices136

        '''<remarks/>
        RacingServices137

        '''<remarks/>
        RacingServices138

        '''<remarks/>
        RacingServices139

        '''<remarks/>
        RacingServices140

        '''<remarks/>
        RacingServices141

        '''<remarks/>
        RacingServices142

        '''<remarks/>
        RacingServices143

        '''<remarks/>
        RacingServices144

        '''<remarks/>
        RacingServices145

        '''<remarks/>
        RacingServices146

        '''<remarks/>
        RacingServices147

        '''<remarks/>
        RacingServices148

        '''<remarks/>
        RacingServices149

        '''<remarks/>
        RacingServices150

        '''<remarks/>
        RacingServices151

        '''<remarks/>
        RacingServices152

        '''<remarks/>
        RacingServices153

        '''<remarks/>
        RacingServices154

        '''<remarks/>
        RacingServices155

        '''<remarks/>
        RacingServices156

        '''<remarks/>
        RacingServices157

        '''<remarks/>
        RacingServices158

        '''<remarks/>
        RacingServices159

        '''<remarks/>
        RacingServices160

        '''<remarks/>
        RacingServices161

        '''<remarks/>
        RacingServices162

        '''<remarks/>
        RacingServices163

        '''<remarks/>
        RacingServices164

        '''<remarks/>
        RacingServices165

        '''<remarks/>
        RacingServices166

        '''<remarks/>
        RacingServices167

        '''<remarks/>
        RacingServices168

        '''<remarks/>
        RacingServices169

        '''<remarks/>
        RacingServices170

        '''<remarks/>
        RacingServices171

        '''<remarks/>
        RacingServices172

        '''<remarks/>
        RacingServices173

        '''<remarks/>
        RacingServices174

        '''<remarks/>
        RacingServices175

        '''<remarks/>
        RacingServices176

        '''<remarks/>
        RacingServices177

        '''<remarks/>
        RacingServices178

        '''<remarks/>
        RacingServices179

        '''<remarks/>
        RacingServices180

        '''<remarks/>
        RacingServices181

        '''<remarks/>
        RacingServices182

        '''<remarks/>
        RacingServices183

        '''<remarks/>
        RacingServices184

        '''<remarks/>
        RacingServices185

        '''<remarks/>
        RacingServices186

        '''<remarks/>
        RacingServices187

        '''<remarks/>
        RacingServices188

        '''<remarks/>
        RacingServices189

        '''<remarks/>
        RacingServices190

        '''<remarks/>
        RacingServices191

        '''<remarks/>
        RacingServices192

        '''<remarks/>
        RacingServices193

        '''<remarks/>
        RacingServices194

        '''<remarks/>
        RacingServices195

        '''<remarks/>
        RacingServices196

        '''<remarks/>
        RacingServices197

        '''<remarks/>
        RacingServices198

        '''<remarks/>
        RacingServices199

        '''<remarks/>
        RacingServices200
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum ExoticPriceUpdateTypePriceType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class ExoticPriceData

        Private selectionsField As String

        Private priceField As Single

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Selections() As String
            Get
                Return Me.selectionsField
            End Get
            Set
                Me.selectionsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Price() As Single
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class RaceStatus

        Private meetingIDField As Long

        Private raceNumberField As Integer

        Private statusField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MeetingID() As Long
            Get
                Return Me.meetingIDField
            End Get
            Set
                Me.meetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceNumber() As Integer
            Get
                Return Me.raceNumberField
            End Get
            Set
                Me.raceNumberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Status() As String
            Get
                Return Me.statusField
            End Get
            Set
                Me.statusField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class Rule4

        Private deductionsField() As ArrayOfRule4DeductionDeduction

        Private meetingIDField As UInteger

        Private raceNumberField As Byte

        Private deductionTypeField As Rule4DeductionType

        '''<remarks/>
        <System.Xml.Serialization.XmlArrayItemAttribute("Deduction", IsNullable:=False)>
        Public Property Deductions() As ArrayOfRule4DeductionDeduction()
            Get
                Return Me.deductionsField
            End Get
            Set
                Me.deductionsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MeetingID() As UInteger
            Get
                Return Me.meetingIDField
            End Get
            Set
                Me.meetingIDField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RaceNumber() As Byte
            Get
                Return Me.raceNumberField
            End Get
            Set
                Me.raceNumberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DeductionType() As Rule4DeductionType
            Get
                Return Me.deductionTypeField
            End Get
            Set
                Me.deductionTypeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfRule4DeductionDeduction

        Private scratchedRunnerField() As ArrayOfRule4DeductionDeductionScratchedRunner

        Private activeRunnerField() As ArrayOfRule4DeductionDeductionActiveRunner

        Private fromTimeField As Date

        Private toTimeField As Date

        Private totalDeductionField As Double

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("ScratchedRunner")>
        Public Property ScratchedRunner() As ArrayOfRule4DeductionDeductionScratchedRunner()
            Get
                Return Me.scratchedRunnerField
            End Get
            Set
                Me.scratchedRunnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("ActiveRunner")>
        Public Property ActiveRunner() As ArrayOfRule4DeductionDeductionActiveRunner()
            Get
                Return Me.activeRunnerField
            End Get
            Set
                Me.activeRunnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FromTime() As Date
            Get
                Return Me.fromTimeField
            End Get
            Set
                Me.fromTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ToTime() As Date
            Get
                Return Me.toTimeField
            End Get
            Set
                Me.toTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TotalDeduction() As Double
            Get
                Return Me.totalDeductionField
            End Get
            Set
                Me.totalDeductionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfRule4DeductionDeductionScratchedRunner

        Private numberField As Byte

        Private nameField As String

        Private priceField As Double

        Private deductionField As Double

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Number() As Byte
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Price() As Double
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Deduction() As Double
            Get
                Return Me.deductionField
            End Get
            Set
                Me.deductionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class ArrayOfRule4DeductionDeductionActiveRunner

        Private numberField As Byte

        Private nameField As String

        Private priceField As Double

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Number() As Byte
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Price() As Double
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Public Enum Rule4DeductionType

        '''<remarks/>
        Win

        '''<remarks/>
        WinFixedOdds

        '''<remarks/>
        Place

        '''<remarks/>
        PlaceFixedOdds

        '''<remarks/>
        Quinella

        '''<remarks/>
        QuinellaFixedOdds

        '''<remarks/>
        Exacta

        '''<remarks/>
        QuinellaPlace

        '''<remarks/>
        Trifecta

        '''<remarks/>
        FirstFour

        '''<remarks/>
        DailyDouble

        '''<remarks/>
        ExtraDouble

        '''<remarks/>
        RunningDouble

        '''<remarks/>
        Treble

        '''<remarks/>
        Quadrella

        '''<remarks/>
        EarlyQuadrella

        '''<remarks/>
        Sixup

        '''<remarks/>
        BIG6

        '''<remarks/>
        B1

        '''<remarks/>
        B2

        '''<remarks/>
        B3

        '''<remarks/>
        B4

        '''<remarks/>
        B5

        '''<remarks/>
        B6

        '''<remarks/>
        WinFixedAllIn

        '''<remarks/>
        PlacedFixedAllIn

        '''<remarks/>
        ALL

        '''<remarks/>
        FeatureDouble

        '''<remarks/>
        SpecialDouble

        '''<remarks/>
        Trio

        '''<remarks/>
        StartingPrice

        '''<remarks/>
        TopFluc

        '''<remarks/>
        OpeningFluc

        '''<remarks/>
        Place2

        '''<remarks/>
        Place4

        '''<remarks/>
        StartingPricePlace

        '''<remarks/>
        PlaceFixedOdds2

        '''<remarks/>
        PlaceFixedOdds4

        '''<remarks/>
        CSF

        '''<remarks/>
        FixedExacta

        '''<remarks/>
        FixedQuinella

        '''<remarks/>
        FixedQuinellaPlace

        '''<remarks/>
        FixedTrifecta

        '''<remarks/>
        FixedFirstFour
    End Enum

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=True)>
    Partial Public Class Rule4Deduction

        Private scratchedRunnerField() As Rule4DeductionScratchedRunner

        Private activeRunnerField() As Rule4DeductionActiveRunner

        Private fromTimeField As Date

        Private toTimeField As Date

        Private totalDeductionField As Double

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("ScratchedRunner")>
        Public Property ScratchedRunner() As Rule4DeductionScratchedRunner()
            Get
                Return Me.scratchedRunnerField
            End Get
            Set
                Me.scratchedRunnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("ActiveRunner")>
        Public Property ActiveRunner() As Rule4DeductionActiveRunner()
            Get
                Return Me.activeRunnerField
            End Get
            Set
                Me.activeRunnerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FromTime() As Date
            Get
                Return Me.fromTimeField
            End Get
            Set
                Me.fromTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ToTime() As Date
            Get
                Return Me.toTimeField
            End Get
            Set
                Me.toTimeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TotalDeduction() As Double
            Get
                Return Me.totalDeductionField
            End Get
            Set
                Me.totalDeductionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class Rule4DeductionScratchedRunner

        Private numberField As Byte

        Private nameField As String

        Private priceField As Double

        Private deductionField As Double

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Number() As Byte
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Price() As Double
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Deduction() As Double
            Get
                Return Me.deductionField
            End Get
            Set
                Me.deductionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class Rule4DeductionActiveRunner

        Private numberField As Byte

        Private nameField As String

        Private priceField As Byte

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Number() As Byte
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Price() As Byte
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("Rule4DeductionScratchedRunner", [Namespace]:="", IsNullable:=True)>
    Partial Public Class Rule4DeductionScratchedRunner1

        Private numberField As Byte

        Private nameField As String

        Private priceField As Double

        Private deductionField As Double

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Number() As Byte
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Price() As Double
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Deduction() As Double
            Get
                Return Me.deductionField
            End Get
            Set
                Me.deductionField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("Rule4DeductionActiveRunner", [Namespace]:="", IsNullable:=True)>
    Partial Public Class Rule4DeductionActiveRunner1

        Private numberField As Byte

        Private nameField As String

        Private priceField As Byte

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Number() As Byte
            Get
                Return Me.numberField
            End Get
            Set
                Me.numberField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Price() As Byte
            Get
                Return Me.priceField
            End Get
            Set
                Me.priceField = Value
            End Set
        End Property
    End Class

End Namespace
