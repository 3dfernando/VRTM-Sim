Module GeneralFunctions

    'A lot of general functions needed to parse stuff
    Public Function Round(Value As Double, nDigits As Integer) As Double
        Round = Int(Value * (10 ^ nDigits)) / (10 ^ nDigits)
    End Function

    Public Function GetCurrentTimeString(SecondsFromZero As Double) As String
        'Converts the time to a string to fill up the current time besides the scrollbar
        Dim DaysOfTheWeek As New Dictionary(Of Integer, String)
        DaysOfTheWeek.Add(0, "Mo")
        DaysOfTheWeek.Add(1, "Tu")
        DaysOfTheWeek.Add(2, "We")
        DaysOfTheWeek.Add(3, "Th")
        DaysOfTheWeek.Add(4, "Fr")
        DaysOfTheWeek.Add(5, "Sa")
        DaysOfTheWeek.Add(6, "Su")

        Dim DaysFromZero As Long = Int(SecondsFromZero / (24 * 3600))
        Dim WeekDay As Integer = DaysFromZero Mod 7

        Dim HoursOfTheDay As Integer = Int((SecondsFromZero Mod (3600 * 24)) / 3600)
        Dim MinutesOfTheDay As Integer = Int(SecondsFromZero / 60) Mod 60

        Dim DaysString As String
        Dim HoursString As String
        Dim MinutesString As String

        DaysFromZero += 1
        If DaysFromZero < 10 Then
            DaysString = "0" & Trim(Str(DaysFromZero))
        Else
            DaysString = Trim(Str(DaysFromZero))
        End If

        If HoursOfTheDay < 10 Then
            HoursString = "0" & Trim(Str(HoursOfTheDay))
        Else
            HoursString = Trim(Str(HoursOfTheDay))
        End If

        If MinutesOfTheDay < 10 Then
            MinutesString = "0" & Trim(Str(MinutesOfTheDay))
        Else
            MinutesString = Trim(Str(MinutesOfTheDay))
        End If

        GetCurrentTimeString = DaysOfTheWeek(WeekDay) & " D" & DaysString & " " & HoursString & ":" & MinutesString

    End Function

    Public Function Return_1_if_0(t As Double) As Double
        If t = 0 Then Return 1
        Return t
    End Function

    Public Function Interpolate_Color(Pos As Double, C1 As Color, C2 As Color) As Color
        'Interpolates colors C1 and C2
        If Pos > 1 Then Pos = 1
        If Pos < 0 Then Pos = 0

        Dim R, G, B As Integer
        Try
            R = Int(Pos * (Convert.ToDouble(C1.R) - Convert.ToDouble(C2.R)) +
                        Convert.ToDouble(C2.R))

            G = Int(Pos * (Convert.ToDouble(C1.G) - Convert.ToDouble(C2.G)) +
                        Convert.ToDouble(C2.G))

            B = Int(Pos * (Convert.ToDouble(C1.B) - Convert.ToDouble(C2.B)) +
                        Convert.ToDouble(C2.B))

            Return Color.FromArgb(R, G, B)
        Catch
            Return Color.White
        End Try
    End Function

    Public Sub InitPlaybackSpeedSettings()
        'This will fill up the default playback speeds in the initialization
        'playbackDefaultSpeeds is the variable that contains this dictionary
        With MainWindow
            .playbackDefaultSpeeds = New List(Of Long)
            .playbackDefaultSpeedNames = New List(Of String)

            .playbackDefaultSpeeds.Add(1) 'list item (0)
            .playbackDefaultSpeedNames.Add("1 s/s")
            .playbackDefaultSpeeds.Add(2) 'list item (1)
            .playbackDefaultSpeedNames.Add("2 s/s")
            .playbackDefaultSpeeds.Add(5) 'list item (2)
            .playbackDefaultSpeedNames.Add("5 s/s")
            .playbackDefaultSpeeds.Add(10) 'list item (3)
            .playbackDefaultSpeedNames.Add("10 s/s")
            .playbackDefaultSpeeds.Add(30) 'list item (4)
            .playbackDefaultSpeedNames.Add("30 s/s")
            .playbackDefaultSpeeds.Add(60) 'list item (5)
            .playbackDefaultSpeedNames.Add("1 min/s")
            .playbackDefaultSpeeds.Add(120) 'list item (6)
            .playbackDefaultSpeedNames.Add("2 min/s")
            .playbackDefaultSpeeds.Add(300) 'list item (7)
            .playbackDefaultSpeedNames.Add("5 min/s")
            .playbackDefaultSpeeds.Add(600) 'list item (8)
            .playbackDefaultSpeedNames.Add("10 min/s")
            .playbackDefaultSpeeds.Add(1800) 'list item (9)
            .playbackDefaultSpeedNames.Add("30 min/s")
            .playbackDefaultSpeeds.Add(3600) 'list item (10)
            .playbackDefaultSpeedNames.Add("1 h/s")
            .playbackDefaultSpeeds.Add(7200) 'list item (11)
            .playbackDefaultSpeedNames.Add("2 h/s")
            .playbackDefaultSpeeds.Add(18000) 'list item (12)
            .playbackDefaultSpeedNames.Add("5 h/s")
            .playbackDefaultSpeeds.Add(43200) 'list item (13)
            .playbackDefaultSpeedNames.Add("12 h/s")
            .playbackDefaultSpeeds.Add(86400) 'list item (14)
            .playbackDefaultSpeedNames.Add("1 day/s")
        End With
    End Sub
End Module
