Imports System.IO
Imports System.Xml
Imports GBSReceiver.Meetings

Public Class parseXML
    'update footers
    Dim mtgfoot As String = File.ReadAllText("c:\GBS\foots\mtgft.txt")
    Dim horsefoot As String = File.ReadAllText("c:\GBS\foots\horseft.txt")
    Dim trackfoot As String = File.ReadAllText("c:\GBS\foots\trackft.txt")
    Dim racefoot As String = File.ReadAllText("c:\GBS\foots\raceft.txt")
    Shared r4foot As String = File.ReadAllText("c:\GBS\foots\r4ft.txt")
    Public Shared Sub gettop(ByVal x As String, ByVal xname As String)
        Dim loadStr As String = ""
        Try
            If xname.Contains("racestatus") Then
                loadStr = parseRaceStatus(proc_RaceStatus(x, xname))
            ElseIf xname.Contains("result") Then
                loadStr = parseResult(proc_Results(x, xname))
            ElseIf xname.Contains("priceupdate") Then
                loadStr = parsePrice(proc_PriceUpdate(x, xname))
            ElseIf xname.Contains("scratching") Then
                loadStr = parseScratch(proc_Scratching(x, xname))
            ElseIf xname.Contains("substitute") Then
                loadStr = parseSubs(proc_Substitutes(x, xname))
            ElseIf xname.Contains("derivative") Then
                loadStr = parseDerivative(proc_Derivative(x, xname))
            ElseIf xname.Contains("rule4") Then
                loadStr = parseRule4(proc_Rule4(x, xname))
            End If

            'Create the Text file
            File.WriteAllText(Module1.writePath & "\Txtfiles\" &
                  Format(Now, "yyyyMMddhhss") & "_" & xname & ".txt", loadStr)
            'Load into the Database 
            If Not loadStr = "" Then
                DoTRS.doIns(loadStr, Module1.dbconn)
            End If
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Sub
    Public Sub getAccept(ByVal m As String, ByVal mfile As String)
        Try
            Dim loadStr As String = parseMtg(proc_Nominations(m, mfile))

            File.WriteAllText(Module1.writePath & "\Txtfiles\" &
                    Format(Now, "yyyyMMddhhss") & "_" & "Accept.txt", loadStr)
            'Load into the Database 
            DoTRS.doIns(loadStr, Module1.mtgconn)
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
    End Sub
    Public Function parseMtg(ByVal mtg As meeting)
        'construct all acceptance/form here 4 files
        Dim mtgstr As String = ""
        Try
            ' Mtg file 
            If Not mtg.product Is Nothing Then
                Try
                    mtgstr = "Insert into gbs.product values (0,"
                    'Product
                    mtgstr = mtgstr & testInt(mtg.Meetingid) & "," & doProduct(mtg.product)
                Catch ex As Exception
                    LogQueue.Enqueue("e" & " " & ex.ToString())
                End Try
            End If
            'mtg
            Try

                mtgstr = mtgstr & Environment.NewLine & " Insert into gbs.mtg values (" _
                    & testInt(mtg.MeetingType) & "," & tDate(mtg.date) & "," &
                    testStr(mtg.tab_indicator) & "," _
                    & testStr(mtg.rail_position) & "," & testStr(mtg.stage) & "," &
                    testInt(mtg.Meetingid) & "," _
                    & testInt(mtg.Version) & "," & testInt(mtg.Validated) & "," &
                    testInt(mtg.NumberOfRaces) & "," _
                    & testInt(mtg.ExternalMeetingID) & "," & testStr(mtg.MeetingSource) & "," &
                    testDate(Now()) & ")" & mtgfoot
            Catch ex As Exception
                LogQueue.Enqueue("e" & " " & ex.ToString())
            End Try
            'Track
            If Not mtg.track Is Nothing Then
                Try
                    mtgstr = mtgstr & Environment.NewLine & " Insert into gbs.track values (" & testInt(mtg.Meetingid) &
                        "," & doTrack(mtg.track) & trackfoot
                Catch ex As Exception
                    LogQueue.Enqueue("e" & " " & ex.ToString())
                End Try
            End If
            'Totes
            If Not mtg.ToteCodes Is Nothing Then
                Try
                    mtgstr = mtgstr & Environment.NewLine & " Insert into gbs.totes values "
                    For Each t In mtg.ToteCodes()
                        mtgstr = mtgstr & "(0," & testInt(mtg.Meetingid) & "," & doTote(t)
                    Next
                    mtgstr = mtgstr.Substring(0, mtgstr.LastIndexOf(",")) & ";"
                Catch ex As Exception
                    LogQueue.Enqueue("e" & " " & ex.ToString())
                End Try
            End If
            'Do the races part
            mtgstr = mtgstr & parseRace(mtg.Meetingid, mtg.races())
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
        Return mtgstr

    End Function
    Public Function parseRace(ByVal mtgid As Integer, ByVal races As Meetings.RaceType())
        'Construct a file for all races
        Dim racestr As String = ""
        Try
            For Each r As RaceType In races

                racestr = racestr & Environment.NewLine & "Insert into gbs.race values (" & mtgid & "," & doRace(r)
                racestr = racestr.Substring(0, racestr.LastIndexOf(",")) & racefoot
                'Prizes
                If Not r.prizes Is Nothing Then
                    If r.prizes.Length > 0 Then
                        racestr = racestr & Environment.NewLine & "Insert into gbs.prizes values"
                        For Each p As PrizeType In r.prizes()
                            Try
                                racestr = racestr & " (0," & mtgid & "," & testInt(r.number) & "," & doPrizes(p)
                            Catch ex As Exception
                                LogQueue.Enqueue("e" & " " & ex.ToString())
                            End Try
                        Next
                        racestr = racestr.Substring(0, racestr.LastIndexOf(",")) & ";"
                    End If
                End If
                'TabPools
                If Not r.TABPools Is Nothing Then
                    If r.TABPools.Length > 0 Then
                        racestr = racestr & Environment.NewLine & "Insert into gbs.tabpool values"
                        For Each t As TABPoolType In r.TABPools()
                            Try
                                racestr = racestr & " (0," & mtgid & "," & testInt(r.number) & "," & doTab(t)
                            Catch ex As Exception
                                LogQueue.Enqueue("e" & " " & ex.ToString())
                            End Try
                        Next
                        racestr = racestr.Substring(0, racestr.LastIndexOf(",")) & ";"
                    End If
                End If
                'Do the horses part
                testDate(r.start_time)
                'CType(r.start_time, Date)
                racestr = racestr & parseHorse(mtgid, r.number, tDate(r.start_time), r.horses())
            Next
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
        Return racestr

    End Function
    Public Function parseHorse(ByVal mtgid As Integer, ByVal raceno As Integer, ByVal racedate As String,
                               ByVal horses As Meetings.HorseType())
        'Construct a file for all horses
        Dim horsestr As String = ""
        Try
            For Each h As HorseType In horses
                horsestr = horsestr & Environment.NewLine & "Insert into gbs.horse values (" &
                                    mtgid & "," & raceno & "," & doHorse(h)
                horsestr = horsestr.Substring(0, horsestr.LastIndexOf(",")) & " " & horsefoot
                'Ratings
                If Not h.ratings Is Nothing Then
                    If h.ratings.Length > 0 Then
                        horsestr = horsestr & Environment.NewLine & "Insert into gbs.ratings values"
                        For Each r As RatingType In h.ratings()
                            Try
                                horsestr = horsestr & " (0," & mtgid & "," & raceno & "," & testInt(h.tab_no) & "," & doRatings(r)
                            Catch ex As Exception
                                LogQueue.Enqueue("e" & " " & ex.ToString())
                            End Try
                        Next
                        horsestr = horsestr.Substring(0, horsestr.LastIndexOf(",")) & ";"
                    End If
                End If
                'Stats Horses
                If Not h.statistics Is Nothing Then
                    If h.statistics.Length > 0 Then
                        horsestr = horsestr & Environment.NewLine & "Insert into gbs.horse_stats values"
                        For Each hs As StatisticType In h.statistics()
                            Try
                                horsestr = horsestr & " (0," & mtgid & "," & raceno & "," & testInt(h.tab_no) & "," & doStats(hs)
                            Catch ex As Exception
                                LogQueue.Enqueue("e" & " " & ex.ToString())
                            End Try
                        Next
                        horsestr = horsestr.Substring(0, horsestr.LastIndexOf(",")) & ";"
                    End If
                End If
                'Stats Jockey
                If Not h.jockey Is Nothing Then
                    If Not h.jockey.statistics Is Nothing Then
                        horsestr = horsestr & Environment.NewLine & "Insert into gbs.jockey_stats values"
                        For Each j As StatisticType In h.jockey.statistics()
                            Try
                                horsestr = horsestr & " (0," & testInt(h.jockey.id) & "," & tDate(racedate) &
                        "," & doStats(j)
                            Catch ex As Exception
                                LogQueue.Enqueue("e" & " " & ex.ToString())
                            End Try
                        Next
                        horsestr = horsestr.Substring(0, horsestr.LastIndexOf(",")) & ";"
                    End If
                End If
                'Stats Trainer
                If Not h.trainer Is Nothing Then
                    If Not h.trainer.statistics Is Nothing Then
                        horsestr = horsestr & Environment.NewLine & "Insert into gbs.trainer_stats values"
                        For Each t As StatisticType In h.trainer.statistics()
                            Try
                                horsestr = horsestr & " (0," & testInt(h.trainer.id) & "," & tDate(racedate) &
                        "," & doStats(t)
                            Catch ex As Exception
                                LogQueue.Enqueue("e" & " " & ex.ToString())
                            End Try
                        Next
                        horsestr = horsestr.Substring(0, horsestr.LastIndexOf(",")) & ";"
                    End If
                End If
                'Form
                If Not h.PreviousForm Is Nothing Then
                    If h.PreviousForm.Length > 0 Then
                        horsestr = horsestr & Environment.NewLine & "Insert ignore into gbs.form values"
                        For Each f As FormType In h.PreviousForm()
                            Try
                                horsestr = horsestr & " (" & mtgid & "," & raceno & "," & h.tab_no &
                            "," & doForm(f)
                            Catch ex As Exception
                                LogQueue.Enqueue("e" & " " & ex.ToString())
                            End Try
                        Next
                        horsestr = horsestr.Substring(0, horsestr.LastIndexOf(",")) & ";"
                    End If
                End If
            Next
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
        Return horsestr

    End Function
    Public Shared Function doProduct(ByVal prod As Meetings.ProductType)
        Dim retStr As String = ""
        Try
            retStr = testStr(prod.directory) & "," &
        testStr(prod.track) & "," &
        testDate(prod.date) & "," &
        testStr(prod.file) & ");"
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
        Return retStr
    End Function
    Public Shared Function doTrack(ByVal track As Meetings.TrackType)
        Dim retStr As String = ""
        Try
            retStr = testStr(track.name) & "," &
            testStr(track.TranslatedName) & "," &
            testStr(track.BettorDataName) & "," &
            testStr(track.club) & "," &
            testStr(track.location.ToString) & "," &
            testStr(track.country) & "," &
            testStr(track.state) & "," &
            testStr(track.track_3char_abbrev) & "," &
            testStr(track.track_4char_abbrev) & "," &
            testInt(track.id) & "," &
            testStr(track.condition.ToString) & "," &
            testStr(track.Weather) & "," &
            testStr(track.night_meeting) & "," &
            testStr(track.GBSVenueid) & "," &
            testDate(Now()) & ")"
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
        Return retStr
    End Function
    Public Shared Function doRace(ByVal race As Meetings.RaceType)
        Dim retStr As String = ""
        Try
            retStr = retStr & testStr(race.division) & "," &
            testDate(race.RaceJumpTime) & "," &
            testDate(race.start_time) & ","

            If race.distance Is Nothing Then
                retStr = retStr & "0,"
            Else
                retStr = retStr & testInt(race.distance.metres) & ","
            End If

            If race.restrictions Is Nothing Then
                retStr = retStr & "0,0,0,"
            Else
                retStr = retStr & testStr(race.restrictions.age) & "," &
                testStr(race.restrictions.sex) & "," &
                testStr(race.restrictions.jockey) & ","
            End If

            retStr = retStr & testStr(race.weight_type) & "," &
            testDec(race.min_hcp_weight) & "," &
            testInt(race.group) & ","

            If race.classes Is Nothing Then
                retStr = retStr & "0,"
            Else
                retStr = retStr & testStr(race.classes.First) & "," ' Look at this
            End If

            retStr = retStr & testInt(race.number) & "," &
            testInt(race.nomination_number) & "," &
            testStr(race.name) & "," &
            testStr(race.JockeySilksURL) & "," &
            testInt(race.id) & "," &
            testInt(race.ExternalId) & "," &
            testStr(race.Gait) & "," &
            testInt(race.Raceid) & "," &
            testStr(race.SurfaceType.ToString) & "," &
            testStr(race.Status.ToString) & "," &
            testInt(race.NumberOfRunners) & "," &
                testStr(race.Handicap.ToString) & "," &
                testStr(race.ForeCast.ToString) & "," &
                testInt(race.EachWayPlaces) & "," &
                testInt(race.EachWayReduction) & "," &
                testInt(race.NumberOfPlaces) & "," &
                testDate(race.DisplayTime) & "," &
                testInt(race.NumberOfFences) & "," &
                testStr(race.GlobalClass) & "," &
            testDate(Now()) & "),"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retStr

    End Function
    Public Shared Function doPrizes(ByVal prize As Meetings.PrizeType)
        Dim retStr As String = ""
        Try
            retStr = testStr(prize.type.ToString).Replace("Item", "") & "," &
            testDec(prize.value) & "," & testDate(Now()) & "),"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retStr
    End Function
    Public Shared Function doTab(ByVal tab As Meetings.TABPoolType)
        Dim retStr As String = ""
        Try
            retStr = testStr(tab.PoolDescription.ToString) & "," &
            testStr(tab.PoolBetType.ToString) & "," &
            testInt(tab.PoolValue) & "," &
            testInt(tab.LegNumber) & "," &
            testDate(tab.TimeStamp) & "),"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retStr
    End Function
    Public Shared Function doHorse(ByVal horse As Meetings.HorseType)
        Dim retstr As String = ""
        Try
            retstr = retstr & testStr(horse.finish_position) & "," &
            testStr(horse.margin) & "," &
            testStr(horse.StartingPrice) & ","

            If horse.sire Is Nothing Then
                retstr = retstr & "'0','0',"
            Else
                retstr = retstr & testStr(horse.sire().name) & "," &
                testStr(horse.sire().country) & ","
            End If

            If horse.dam Is Nothing Then
                retstr = retstr & "'0','0',"
            Else
                retstr = retstr & testStr(horse.dam().name) & "," &
                testStr(horse.dam().country) & ","
            End If

            If horse.trainer Is Nothing Then
                retstr = retstr & "'0','0',"
            Else
                retstr = retstr & testStr(horse.trainer.name) & "," &
                testInt(horse.trainer.id) & ","
            End If

            retstr = retstr & testStr(horse.training_location) & "," &
                testStr(horse.owners) & "," &
                testStr(horse.colours) & "," &
                testInt(horse.prizemoney_won) & "," &
                testStr(horse.last_four_starts) & "," &
                testStr(horse.last_ten_starts) & "," &
                testInt(horse.tab_no) & "," &
                testStr(horse.Coupled) & ","

            If horse.Status Is Nothing Then
                retstr = retstr & "'0',"
            Else
                retstr = retstr & testStr(horse.Status.Indicator.ToString) & ","
            End If

            retstr = retstr & testStr(horse.barrier) & ","
            If horse.Status Is Nothing Then
                retstr = retstr & "'0',"
            Else
                retstr = retstr & testDate(horse.Status.LateScratchingTime) & ","
            End If

            retstr = retstr & testInt(horse.sequence_no) & "," &
                testStr(horse.emergency_indicator) & ","

            If horse.jockey Is Nothing Then
                retstr = retstr & "'0',0,'0',0,"
            Else
                retstr = retstr & testStr(horse.jockey.name) & "," &
                testInt(horse.jockey.id) & "," &
                testStr(horse.jockey.apprentice_indicator.ToString) & "," &
                testDec(horse.jockey.allowance_weight) & ","
            End If

            retstr = retstr & testStr(horse.BestTime) & "," &
                testStr(horse.Row) & ","

            If horse.weight Is Nothing Then
                retstr = retstr & "0,0,0,0,"
            Else
                retstr = retstr & testDec(horse.weight.total) & "," &
                testDec(horse.weight.allocated) & "," &
                testDec(horse.weight.performance_penalty) & "," &
                testDec(horse.weight.weight_raised) & ","
            End If

            retstr = retstr & testStr(horse.StartingHandicap) & "," &
                testStr(horse.selection) & "," &
                "''" & "," & 'horse.market & "," &
                testStr(horse.name) & "," &
                testStr(horse.country) & "," &
                testInt(horse.age) & "," &
                testStr(horse.colour.ToString) & "," &
                testStr(horse.sex.ToString) & "," &
                testStr(horse.previous_name) & "," &
                testStr(horse.id) & "," &
                testStr(horse.foaling_date) & "," &
                testInt(horse.externalid) & "," &
                testStr(horse.ClassCountry) & "," &
                testStr(horse.ClassMetro) & "," &
                0 & "," & ' Might need to dig into this
                0 & "," &
                testStr(horse.LastTimeAtTrackAndDistance) & "," &
                testStr(horse.JockeySilksURL) & "," &
                testStr(horse.scratched_indicator) & "," &
                testInt(horse.DaysSinceLastRun) & "," &
                testInt(horse.DaysSinceLastRunFlat) & "," &
                testInt(horse.DaysSinceLastRunJumps) & "," &
                testInt(horse.OfficialRating) & "," &
                testInt(horse.OfficialRatingToday) & "," &
                testStr(horse.CourseDistanceWinner) & "," &
                testStr(horse.CourseDistanceWins) & "," &
                testInt(horse.CourseWins) & "," &
                testInt(horse.MorningLine) & ","

            If horse.RunnerComments Is Nothing Then
                retstr = retstr & "'','',"
            Else
                retstr = retstr & testStr(horse.RunnerComments().ElementAt(0).RunnerComment.Replace("'", "").Replace(",", "")) & "," &
                               testStr(horse.RunnerComments().ElementAt(0).Source.ToString) & ","
            End If

            retstr = retstr & testDate(Now()) & "),"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retstr

    End Function
    Public Shared Function doRatings(ByVal rating As Meetings.RatingType)
        Dim retstr As String = ""
        Try
            retstr = testStr(rating.type) & "," &
            testDec(rating.value) & "," &
            tDate(rating.date) & "," &
            testDec(rating.unadjusted) & "," &
            testDec(rating.adjusted) & "),"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retstr
    End Function
    Public Shared Function doPricesUP(ByVal price As Meetings.PriceUpdateType)
        Dim retstr As String = ""
        Try
            retstr = testInt(price.MeetingID) & "," &
            testInt(price.RaceNo) & "," &
            testStr(price.Source) & "," &
            testStr(price.PriceType) & "," &
            testInt(price.PoolSize) & "," & testDate(Now())
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retstr

    End Function
    Public Shared Function doPricesRun(ByVal run As Meetings.RunnerPriceData)
        Dim retstr As String = ""
        Try
            retstr = testInt(run.TabNo) & "," &
            testDec(run.Price) & "," &
            testStr(run.Status.Indicator) & "," &
            testDate(Now)
        Catch ex As Exception
        LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retstr
    End Function
    Public Shared Function doStats(ByVal stats As Meetings.StatisticType)
        Dim retstr As String = ""
        Try
            retstr = testStr(stats.type.ToString) & "," &
            testInt(stats.total) & "," &
            testInt(stats.firsts) & "," &
            testInt(stats.seconds) & "," &
            testInt(stats.thirds) & "," &
            testStr(stats.BestMileRate) & "," &
            testStr(stats.WinningDistance) & "),"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retstr

    End Function
    Public Shared Function doForm(ByVal form As Meetings.FormType)
        Dim retstr As String = ""
        Try
            retstr = testInt(form.Id) & "," &
            testInt(form.EarlySpeedRating) & "," &
            testInt(form.Rating) & "," &
            tDate(form.date) & "," &
            testInt(form.DaysSince) & "," &
            testStr(form.RaceClass) & "," &
            testInt(form.RaceNumber) & "," &
            testStr(form.Finish) & "," &
            testInt(form.NumberOfRunners) & "," &
            testStr(form.Margin) & "," &
            testStr(form.Distance) & "," &
            testStr(form.Track) & "," &
            testStr(form.TrackCondition) & "," &
            testStr(form.BestTimeOfNight) & "," &
            testStr(form.Racetime) & "," &
            testStr(form.TimeRan) & "," &
            testStr(form.Sectionals) & "," &
            testStr(form.Jockey) & "," &
            testInt(form.Barrier) & "," &
            testStr(form.StartingHandicap) & "," &
            testDec(form.WeightCarried) & "," &
            testDec(form.BodyWeight) & "," &
            testStr(form.StartingPrice) & "," &
            testStr(form.RaceWinner) & "," &
            testStr(form.RaceSecond) & "," &
            testStr(form.RaceThird) & "," &
            testStr(form.Comment) & "," &
            testStr(form.VideoCode) & "," &
            testStr(form.Row) & "," &
            testStr(form.StartType) & "," &
            testStr(form.MileRate) & "," &
            testStr(form.LastMile) & "," &
            testStr(form.LimitWeight) & "," &
            testStr(form.Track4Char) & "," &
            testStr(form.InRun) & "," &
            testDec(form.RacePrizemoney) & "," &
            testStr(form.FirstSplit) & "," & testDate(Now()) & "),"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retstr
    End Function
    Public Shared Function doAncestor(ByVal anc As Meetings.AncestorType)
        Dim retstr As String = ""
        Try
            retstr = testStr(anc.name) & "," &
            testStr(anc.country) & "," &
            testStr(anc.YearBorn)
        Catch ex As Exception
        LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retstr
    End Function
    Public Shared Function doTote(ByVal tote As Meetings.ToteCodeType)
        Dim retstr As String = ""
        Try
            retstr = testStr(tote.ToteName.ToString) & "," & testStr(tote.Code) & "," & testDate(Now()) & "),"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retstr
    End Function
    Public Shared Function testInt(ByVal i As String)
        Try
            If IsDBNull(i) OrElse i = "" OrElse i Is Nothing Then Return 0 Else Return i
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return 0
    End Function
    Public Shared Function testStr(ByVal s As String)
        Try
            If IsDBNull(s) OrElse s Is Nothing Then Return "''" Else Return "'" & s.Replace("'", "") & "'"
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return "''"
    End Function
    Public Shared Function testDec(ByVal s As String)
        Try
            If IsDBNull(s) OrElse s Is Nothing Then Return "0.0" Else Return s.Replace(",", "")
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return "0.0"
    End Function

    Public Shared Function testDate(ByVal o As Object)
        Try
            ' Sort the date format here
            If o Is Nothing Then
                Return "NULL"
            End If

            If IsDBNull(0) Then
                Return "NULL"
            ElseIf o.ToString() = "" Then
                Return "NULL"
            Else
                Return "'" & Format(CType(o, Date), "yyyy-MM-dd HH:mm:ss") & "'"
            End If
        Catch ex As Exception

            Return "NULL"
        End Try

    End Function
    Public Shared Function tDate(ByVal o As Object)
        Try
            ' Sort the date format here
            If o Is Nothing Then
                Return "NULL"
            End If
            If IsDBNull(0) Then
                Return "NULL"
            ElseIf o.ToString() = "" Then
                Return "NULL"
            Else
                Return "'" & Format(CType(o, Date), "yyyy-MM-dd") & "'"
            End If
        Catch ex As Exception

            Return "NULL"
        End Try
    End Function

    Public Shared Function parsePrice_old(ByVal price As Meetings.PriceUpdateType)
        Dim retprice As String = ""
        Try
            If Not price Is Nothing Then
                retprice = "Insert into gbs.prices values (0,"
                'Price load part
                retprice = retprice & testInt(price.MeetingID) & "," &
                testInt(price.RaceNo) & "," &
                testStr(price.Source) & "," &
                testStr(price.PriceType) & "," &
                testInt(price.PoolSize) & "," & testDate(Now) & ");"
                If Not price.Runners Is Nothing Then
                    retprice = retprice & "Insert into gbs.prices_runners values "
                    'Runner prices loop
                    For Each run As RunnerPriceData In price.Runners()
                        retprice = retprice & "(0," & testInt(price.MeetingID) & "," &
                                                testInt(price.RaceNo) & "," &
                                                testInt(run.TabNo) & "," &
                                                testStr(run.Price) & "," &
                                                testStr(run.Status.Indicator) & "," &
                                                testDate(Now) & "),"
                    Next

                    retprice = retprice.Substring(0, retprice.LastIndexOf(",")) & ";"
                End If
            End If
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retprice
    End Function

    Public Shared Function parsePrice(ByVal price As Meetings.PriceUpdateType)
        Dim retprice As String = ""
        Try
            Dim upprice As String = "Insert into gbs.prices_live values "
            If Not price Is Nothing Then
                If Not price.Runners Is Nothing Then
                    If price.Runners.Length > 0 Then
                        retprice = retprice & "Insert into gbs.prices_values values "
                        'Runner prices loop
                        For Each run As RunnerPriceData In price.Runners()
                            Try
                                retprice = retprice & "(0," & testInt(price.MeetingID) & "," &
                                            testInt(price.RaceNo) & "," &
                                            testInt(price.Source) & "," &
                                            testInt(price.PriceType) & "," &
                                            testInt(price.PoolSize) & "," &
                                            testInt(run.TabNo) & "," &
                                            testStr(run.Price) & "," &
                                           "'0'," &
                                            testDate(Now) & "),"

                                upprice = upprice & "(" & testInt(price.MeetingID) & "," &
                                                testInt(price.RaceNo) & "," &
                                                testInt(run.TabNo) & "," &
                                                testInt(price.Source) & "," &
                                                testInt(price.PriceType) & "," &
                                                testStr(run.Price) & "," &
                                                testDate(Now) & ",0.0),"

                            Catch ex As Exception
                                LogQueue.Enqueue("e" & " " & ex.ToString())
                            End Try
                        Next
                        upprice = upprice.Substring(0, upprice.LastIndexOf(",")) & " on duplicate key update
                        prices_live.prev = case when prices_live.price != values(price) then prices_live.price else prices_live.prev end,
                        prices_live.updated = case when prices_live.price != values(price) then values(updated) else prices_live.updated end,
                        prices_live.price = case when prices_live.price != values(price) then values(price) else prices_live.price end;
                        "
                        retprice = retprice.Substring(0, retprice.LastIndexOf(",")) & ";" & upprice
                    End If
                End If
                End If
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retprice
    End Function
    Public Shared Function parseScratch(ByVal scratch As Meetings.ScratchingType)
        Dim retprice As String = ""
        Try
            If Not scratch Is Nothing Then
                retprice = "Insert into gbs.scratchings values (0,"

                'Scratchings load part
                retprice = retprice & testInt(scratch.MeetingID) & "," &
                testInt(scratch.RaceNumber) & "," &
                testInt(scratch.RunnerNumber) & "," &
                testStr(scratch.Status.Indicator.ToString) & "," & testDate(Now()) & ");"
            End If
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retprice
    End Function
    Public Shared Function parseRaceStatus(ByVal raceS As Meetings.RaceStatus)
        Dim retprice As String = ""
        Try
            If Not raceS Is Nothing Then
                retprice = "Insert into gbs.race_status values (0,"
                'Status load part
                retprice = retprice & testInt(raceS.MeetingID) & "," &
                testInt(raceS.RaceNumber) & "," &
                testStr(raceS.Status.ToString) & "," & testDate(Now()) & ");"
            End If
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retprice
    End Function
    Public Shared Function parseSubs(ByVal subst As Meetings.SubstituteType)
        Dim retprice As String = ""
        Try
            If Not subst Is Nothing Then
                retprice = "Insert into gbs.subs values (0,"
                'Sustitutes load part
                retprice = retprice & testInt(subst.MeetingID) & "," &
                testInt(subst.RaceNumber) & "," &
                testInt(subst.substitutenumber) & "," &
                testStr(subst.SourcePool.ToString) & "," &
                testStr(subst.BetType.ToString) & "," & testDate(Now()) & ");"
            End If
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retprice
    End Function
    Public Shared Function parseResult(ByVal res As Meetings.ResultType)
        Dim retprice As String = ""
        Try
            If Not res Is Nothing Then
                retprice = "Insert into gbs.results_no values "
                For Each r As ResultNumberType In res.ResultNumbers()
                    'Results load part
                    retprice = retprice & "(0," & testInt(res.MeetingID) & "," &
                testInt(res.RaceNumber) & "," &
                testStr(res.Source.ToString) & "," &
                testInt(r.Position) & "," &
                 testStr(r.ParticipantNumber).replace(",", "-") & "," &
                 testStr(res.DividendStatus.ToString) & "," & testDate(Now()) & "),"
                Next
                retprice = retprice.Substring(0, retprice.LastIndexOf(",")) & ";"

                'Results Dividends Part
                If Not res.Dividends Is Nothing Then
                    retprice = retprice & "Insert into gbs.results_div values "
                    For Each d As DividendType In res.Dividends()
                        'Results load part
                        retprice = retprice & "(0," & testInt(res.MeetingID) & "," &
                    testInt(res.RaceNumber) & "," &
                    testStr(d.BetType.ToString) & "," &
                    Replace(testStr(d.DividendNumbers), ",", "-") & "," &
                    testDec(d.Dividend) & "," &
                    testDec(d.PoolSize) & "," &
                   testStr(d.DividendStatus.ToString) & "," & testDate(Now()) & "),"
                    Next
                    retprice = retprice.Substring(0, retprice.LastIndexOf(",")) & ";"
                End If
                'Jackpots Load Part
                If Not res.JackPots Is Nothing Then
                    retprice = retprice & "Insert into gbs.jackpots values "
                    For Each j As JackPotType In res.JackPots()
                        'Results load part
                        retprice = retprice & "(0," & testInt(res.MeetingID) & "," &
                testInt(res.RaceNumber) & "," &
                testStr(j.BetType.ToString) & "," &
               testDec(j.Amount) & "," & testDate(Now()) & "),"
                    Next
                    retprice = retprice.Substring(0, retprice.LastIndexOf(",")) & ";"
                End If

                'deductions to add
                If Not res.Deductions Is Nothing Then
                    If res.Deductions.Length > 0 Then
                        retprice = retprice & "Insert into gbs.deductions values "
                        For Each d As DeductionType In res.Deductions()
                            'Results load part
                            retprice = retprice & "(0," & testInt(res.MeetingID) & "," &
                testInt(res.RaceNumber) & "," &
                testStr(d.BetType.ToString) & "," &
                testInt(d.Tab_No) & "," &
                testDec(d.Amount) & "," &
               testStr(d.DeductionTime) & "),"
                        Next
                        retprice = retprice.Substring(0, retprice.LastIndexOf(",")) & ";"
                    End If
                End If
            End If
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retprice
    End Function
    Public Shared Function parseRule4(ByVal rule4 As Meetings.Rule4)
        Dim retprice As String = ""
        Dim r4header As String = ""
        Dim r4mainheader As String = ""
        Dim r4ded As String = ""
        Try
            r4mainheader = "Insert into gbs.rule4 values "
            r4header = "(" & testInt(rule4.MeetingID) & "," &
                testInt(rule4.RaceNumber) & "," &
                testStr(rule4.DeductionType.ToString()) & "," &
                testStr(rule4.MeetingSource.ToString()) & ","

            For Each r In rule4.Deductions()
                r4ded = testDate(r.FromTime) & "," &
                    testDate(r.ToTime) & "," &
                    testInt(r.TotalDeduction) & ","
                For Each run In r.ScratchedRunner
                    retprice = retprice & r4header & r4ded & "'Scratched'" & "," &
                    testInt(run.Number) & "," &
                        testStr(run.Name) & "," &
                        testInt(run.Deduction) & "," &
                        testDec(run.Price) & "),"
                Next
                For Each arun In r.ActiveRunner
                    retprice = retprice & r4header & r4ded & "'Active'" & "," &
                        testInt(arun.Number) & "," &
                        testStr(arun.Name) & ",0," &
                        testDec(arun.Price) & "),"
                Next
            Next
            'Add code here
            retprice = r4mainheader & retprice.Substring(0, retprice.LastIndexOf(",")) & " " & r4foot
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retprice
    End Function
    Public Shared Function parseDerivative(ByVal Der As Meetings.derivative)
        Dim retprice As String = ""
        Dim derHeader As String = ""
        Dim derStr As String = ""
        Try
            derHeader = derHeader & "(" & testInt(Der.selectedmarkets.First.meetingId) & "," &
                testInt(Der.selectedmarkets.First.raceNo) & "," &
                testStr(Der.source) & "," &
                testStr(Der.marketType) & "," &
                testStr(Der.title) & "," &
                testStr(Der.updateType) & ","

            For Each r In Der.races()
                For Each run In r.runner
                    retprice = retprice & derHeader & testInt(run.number) & "," &
                    testStr(run.name) & "," &
                        testDec(run.price) & "," &
                        testStr(run.status) & ",now()),"
                Next
            Next
            retprice = "Insert into gbs.derivative values " &
                retprice.Substring(0, retprice.LastIndexOf(",")) & " on duplicate key update
                        derivative.title = values(title),derivative.update_type = values(update_type),
            derivative.horsename = values(horsename),derivative.price = values(price),
            derivative.status = values(status),derivative.updated = values(updated);"
            'Add code here
        Catch ex As Exception
            LogQueue.Enqueue("e" & " " & ex.ToString())
        End Try
        Return retprice
    End Function
End Class
