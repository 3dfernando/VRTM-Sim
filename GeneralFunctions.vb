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

    Public Sub MinMax(Array() As Double, ByRef Min As Double, ByRef Max As Double)
        'Determines the minimum and maximum elements of the array
        Dim largest As Double = Double.MinValue
        Dim smallest As Double = Double.MaxValue

        For Each element As Double In Array
            largest = Math.Max(largest, element)
            smallest = Math.Min(smallest, element)
        Next

        Min = smallest
        Max = largest
    End Sub

    Public Function GetTickInterval(MinValue As Double, MaxValue As Double, MinDivisions As Double) As Double
        'This function returns a smart tick interval for the chart
        Dim Interval As Double = (MaxValue - MinValue) / MinDivisions
        If Interval < 0 Then Interval = -Interval
        Dim Magnitude As Double = Math.Pow(10, Int(Math.Log10(Interval)))

        If Magnitude > Interval Then
            GetTickInterval = Magnitude * 0.5
        ElseIf Magnitude * 2 > Interval Then
            GetTickInterval = Magnitude * 1
        ElseIf Magnitude * 5 > Interval Then
            GetTickInterval = Magnitude * 2
        Else
            GetTickInterval = Magnitude * 5
        End If

    End Function

    Public Function SearchForTrayIndex(TrayIndex As Long, TimeStep As Long) As TrayData
        'Searches through Simulation_Results.VRTMTrayData and finds the index indicated, returning the object TrayData referring to it
        For I As Long = 0 To UBound(Simulation_Results.VRTMTrayData, 2)
            For J As Long = 0 To UBound(Simulation_Results.VRTMTrayData, 3)
                If Simulation_Results.VRTMTrayData(TimeStep, I, J).TrayIndex = TrayIndex Then
                    Return Simulation_Results.VRTMTrayData(TimeStep, I, J)
                End If
            Next
        Next
        Return Nothing
    End Function

    Public Function Moving_Average(nAverages As Long, lastTermIndex As Long, Series() As Double) As Double
        'Performs a moving average filter on the last nAverages terms of the Series() array
        Dim nTerms As Long
        Dim Sum As Double = 0
        If lastTermIndex < nAverages Then
            nTerms = lastTermIndex + 1
        Else
            nTerms = nAverages
        End If

        For I As Long = 0 To nTerms - 1
            Sum += Series(lastTermIndex - I)
        Next

        Moving_Average = Sum / nTerms
    End Function

#Region "Binary Search"
    Public Delegate Function Y(X As Double)

    Public Function Binary_Search_F(XMin As Double, XMax As Double, YTarget As Double, Adm_Error_Y As Double, F As Y) As Double
        'Makes a binary search (log search) in a function delegate Y(X)

        Const MaxIter As Long = 100
        Dim XR As Double = XMax
        Dim XL As Double = XMin
        Dim YR As Double = F(XR)
        Dim YL As Double = F(XL)
        Dim XM, YM As Double
        Dim Curr_E As Double
        Dim I As Long

        If (YTarget > YR And YTarget > YL) Then
            Return XMax
        ElseIf (YTarget < YR And YTarget < YL) Then
            Return XMin
        End If

        For I = 0 To MaxIter
            XM = (XR + XL) / 2
            YM = F(XM)
            Curr_E = Math.Abs(YM - YTarget)

            If Curr_E < Adm_Error_Y Then
                Return XM
            End If

            If YM > YL Then
                If YTarget > YM Then
                    XL = XM
                    YL = YM
                Else
                    XR = XM
                    YR = YM
                End If
            ElseIf YM < YL Then
                If YTarget > YM Then
                    XR = XM
                    YR = YM
                Else
                    XL = XM
                    YL = YM
                End If
            End If
        Next

        Return Double.MinValue
    End Function
#End Region
End Module
