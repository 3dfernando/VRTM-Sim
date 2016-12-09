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
End Module
