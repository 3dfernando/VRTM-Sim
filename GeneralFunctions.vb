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
            R = Int(Pos * (Convert.ToDouble(C2.R) -
                        Convert.ToDouble(C1.R)) +
                        Convert.ToDouble(C1.R))

            G = Int(Pos * (Convert.ToDouble(C2.G) -
                        Convert.ToDouble(C1.G)) +
                        Convert.ToDouble(C1.G))

            B = Int(Pos * (Convert.ToDouble(C2.B) -
                        Convert.ToDouble(C1.B)) +
                        Convert.ToDouble(C1.B))

            Return Color.FromArgb(R, G, B)
        Catch
            Return Color.White
        End Try
    End Function

End Module
