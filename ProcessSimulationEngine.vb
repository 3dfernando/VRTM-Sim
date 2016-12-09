Module ProcessSimulationEngine
    'This module will contain all subs needed to perform the process simulation.

    Public Sub RunProcessSimulation()
        'This will run the process simulation.

        '################Preruns the box times########################
        With VRTM_SimVariables
            'Seeds the multiple products according to their statistical distributions
            Dim T As Double
            Dim tCurrent As Double = 0
            Dim ArrivalTimes As New SortedDictionary(Of Double, Long)
            Dim idx As Long

            For idx = 0 To .ProductMix.Count - 1
                T = 0
                Do While T < .TotalSimTime
                    If .ProductMix(idx).BoxRateStatisticalDistr.ToLower = "exponential" Then
                        tCurrent = GetExponentialT(3600 / .ProductMix(idx).AvgFlowRate)
                    ElseIf .ProductMix(idx).BoxRateStatisticalDistr.ToLower = "gaussian" Then
                        tCurrent = GetGaussianT(.ProductMix(idx).AvgFlowRate / 3600, .ProductMix(idx).BoxRateStdDev / 3600)
                    End If
                    T = T + tCurrent
                    ArrivalTimes.Add(T, idx) 'Adds the current box in the list (this dictionary automatically sorts them)
                Loop
            Next

            'Gets the seeded products and forms trays as the box quantity needed to fill up a tray is achieved
            For Each k In ArrivalTimes

            Next


        End With
    End Sub

    Public Function GetExponentialT(MeanArrivalTime As Double) As Double
        'Outputs an exponentially distributed arrival time given an average rate
        GetExponentialT = (-1) * MeanArrivalTime * Math.Log(1 - Rnd())
    End Function

    Public Function GetGaussianT(MeanRate As Double, StdRateDev As Double) As Double
        'Outputs a Gaussian distributed arrival time given an average rate
        Dim U1, U2 As Double
        U1 = Rnd()
        U2 = Rnd()

        Dim Z0 As Double
        Z0 = Math.Sqrt(-2 * Math.Log(U1))
        Z0 *= Math.Cos(2 * Math.PI * U2)

        GetGaussianT = 1 / (MeanRate + Z0 * StdRateDev)
    End Function

End Module
