Module ProcessSimulationEngine
    'This module will contain all subs needed to perform the process simulation.
    Private ConveyorPosition_To_Index As New Dictionary(Of Long, Long)

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

            'Determines how many conveyors are there
            Dim CList As New List(Of Long)
            For I As Long = 0 To .ProductMix.Count - 1
                CList.add(.ProductMix(I).ConveyorNumber)
            Next

            Dim UniqueList As List(Of Long)
            UniqueList = CList.Distinct().ToList

            Dim Conveyors() As Conveyor
            ReDim Conveyors(UniqueList.Count - 1)

            For I As Long = 0 To UniqueList.Count - 1
                Conveyors(I) = New Conveyor
                Conveyors(I).ConveyorIndex = UniqueList(I)
                ConveyorPosition_To_Index.Add(UniqueList(I), I) 'Fills up the dictionary to lookup the keys in the next step
            Next


            Dim BoxLimit As Long = .boxesPerTray
            Dim currentTrayIndex As Long = 1
            Dim currentLevel As Long

            'Sizes the tray data array
            ReDim .SimData.TrayEntryTimes(Int(ArrivalTimes.Count / BoxLimit))
            ReDim .SimData.TrayEntryLevels(Int(ArrivalTimes.Count / BoxLimit))
            ReDim .SimData.VRTMTrayData(Int(ArrivalTimes.Count / BoxLimit), .nTrays - 1, .nLevels - 1)
            For I As Long = 0 To UBound(.SimData.VRTMTrayData, 1)
                For J As Long = 0 To UBound(.SimData.VRTMTrayData, 2)
                    For K As Long = 0 To UBound(.SimData.VRTMTrayData, 3)
                        .SimData.VRTMTrayData(I, J, K) = New TrayData
                    Next
                Next
            Next


            '#######Gets the seeded products and forms trays as the box quantity needed to fill up a tray is achieved#######
            For Each k In ArrivalTimes
                Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Add(k.Value)
                If Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Count >= BoxLimit Then
                    'Unload the conveyor and create a tray
                    currentLevel = Int(Rnd() * (.nLevels - 1))

                    If currentTrayIndex <> 0 Then
                        For I As Long = 0 To .nTrays - 1
                            For J As Long = 0 To .nLevels - 1
                                'Copies the last timestep onto the current timestep
                                .SimData.VRTMTrayData(currentTrayIndex, I, J) = .SimData.VRTMTrayData(currentTrayIndex - 1, I, J)
                            Next
                        Next
                    End If

                    'Advances all the other trays in this level
                    For I As Long = .nTrays - 1 To 1 Step -1
                        .SimData.VRTMTrayData(currentTrayIndex, I, currentLevel).TrayIndex = .SimData.VRTMTrayData(currentTrayIndex, I - 1, currentLevel).TrayIndex
                    Next

                    'Puts the current tray here
                    .SimData.VRTMTrayData(currentTrayIndex, 0, currentLevel).TrayIndex = currentTrayIndex
                    Conveyors(ConveyorPosition_To_Index(VRTM_SimVariables.ProductMix(k.Value).ConveyorNumber)).BoxesInConveyor.Clear()

                    'Updates the arrival and exit times
                    .SimData.TrayEntryTimes(currentTrayIndex) = k.Key
                    .SimData.TrayEntryLevels(currentTrayIndex) = currentLevel

                    currentTrayIndex += 1
                End If
            Next

        End With
    End Sub

    Public Class Conveyor
        'Models the array of products inside a conveyor belt (will store only the indices)
        Public BoxesInConveyor As New List(Of Double)
        Public ConveyorIndex As Long
    End Class


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
