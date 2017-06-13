Module A_Star_V2
    'This module contains the functions needed to solve the "puzzle" of reorganizing the VRTM shelves

    Public Function Solve_A_Star_Search_V2(CurrentState As FringeItemV2, TimeBudget_s As Double) As List(Of Integer)
        '


    End Function


    Public Class FringeItemV2
        Implements IComparable(Of FringeItemV2)
        Public VRTMStateConv(,) As Integer 'VRTM internal state with conveyor indices (Tray no, Level no) ***A conveyor index that is larger than 1000 is the same as (index-1000), but ready to ship and needs to be on the side of elevator 2 in the goal.
        Public Elevator1 As Integer 'Content of the elevator 1 (-1 means an empty tray, -2 means no tray on it)
        Public Elevator2 As Integer 'Content of the elevator 2 (-1 means an empty tray, -2 means no tray on it)
        Public CurrentLevel As Integer 'Current level the elevator is at
        Public SKUCount As Integer 'Number of unique SKUs to treat here
        Public AvailableFraction As Double 'Number of available frozen products/total frozen products 
        Public SimplifiedState As List(Of List(Of SimplifiedLevelInfo))

        Public Function Compare(compareState As FringeItemV2) As Integer _
            Implements IComparable(Of FringeItemV2).CompareTo
            ' A null value means that this object is greater.
            If compareState Is Nothing Then
                Return 1
            Else
                Return AvailableFraction.CompareTo(compareState.AvailableFraction)
            End If
        End Function

        Public Function Clone() As GreedyTreeSearchState
            'Clones myself
            Dim NewMe As New GreedyTreeSearchState
            NewMe.VRTMStateConv = Me.VRTMStateConv.Clone
            NewMe.Elevator1 = Me.Elevator1
            NewMe.Elevator2 = Me.Elevator2
            NewMe.CurrentLevel = Me.CurrentLevel
            NewMe.SKUCount = Me.SKUCount
            NewMe.SimplifiedState = New List(Of List(Of SimplifiedLevelInfoGTS))(Me.SimplifiedState)

            Return NewMe
        End Function

        Public Function AccessibleFraction() As Double
            'Returns the global fraction available/frozen
            Dim AvailableProducts As Integer = 0
            Dim TotalFrozen As Integer = 0

            For J As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                'Looks at each level
                If J = VRTM_SimVariables.ReturnLevel - 1 Then Continue For
                AvailableProducts += AvailableProductCount(J, -1)
                TotalFrozen += FrozenProductCount(J, -1)
            Next

            If TotalFrozen = 0 Then Return 1
            Return (AvailableProducts / TotalFrozen)
        End Function

        Public Function AvailableProductCount(Level As Integer, SKU As Integer) As Integer
            'Returns for the current level the number of available frozen product
            Dim AvailableProduct As Integer = 0
            Dim LastProduct As Integer = VRTMStateConv(UBound(Me.VRTMStateConv, 1), Level)


            If LastProduct > 1000 Then
                'There is at least one frozen product at the end of the line
                If (VRTMStateConv(UBound(Me.VRTMStateConv, 1), Level) = SKU + 1000) Or SKU = -1 Then
                    AvailableProduct = 1
                End If

                For I As Integer = UBound(Me.VRTMStateConv, 1) - 1 To 0 Step -1
                    If VRTMStateConv(I, Level) = LastProduct Then
                        If (VRTMStateConv(I, Level) = SKU + 1000) Or SKU = -1 Then
                            'There is a streak of products of this SKU
                            AvailableProduct += 1
                        End If
                    Else
                        Exit For
                    End If
                Next
            Else
                'No available frozen product.
                Return 0
            End If

            Return AvailableProduct
        End Function

        Public Function FrozenProductCount(Level As Integer, SKU As Integer) As Integer
            'Returns for the current level the number of frozen product
            Dim FrozenProduct As Integer = 0

            For I As Integer = UBound(Me.VRTMStateConv, 1) To 0 Step -1
                If VRTMStateConv(I, Level) > 1000 Then
                    If (VRTMStateConv(I, Level) = SKU + 1000) Or SKU = -1 Then
                        'Another frozen product
                        FrozenProduct += 1
                    End If
                End If
            Next

            Return FrozenProduct
        End Function

        Public Sub ComputeSimplifiedState()
            'Transforms the current VRTMStateConf into a list of lists.
            'Parent list represents the levels of the tunnel
            'Internal list represents the level simplified view (just a collection of items chunks)
            Me.SimplifiedState = New List(Of List(Of SimplifiedLevelInfo))
            For L = 0 To VRTM_SimVariables.nLevels - 1
                Me.SimplifiedState.Add(SimplifyLevel(L))
            Next
        End Sub

        Public Function SimplifyLevel(Level As Integer) As List(Of SimplifiedLevelInfo)
            'Transforms the current VRTMStateConf into a list of lists.
            'First list represents the levels of the tunnel
            'Second list represents the level simplified view (just a collection of items chunks)
            'ItemCode=0 represents an unfrozen product (regardless of code)
            Dim NewLevel As New List(Of SimplifiedLevelInfo)
            Dim LastProduct As Integer

            LastProduct = VRTMStateConv(0, Level)
            Dim nProducts As Integer = 1

            For I = 1 To VRTM_SimVariables.nTrays - 1

                If LastProduct = VRTMStateConv(I, Level) Then
                    nProducts += 1
                ElseIf (LastProduct < 1000 AndAlso LastProduct > -1) AndAlso (VRTMStateConv(I, Level) < 1000 AndAlso VRTMStateConv(I, Level) > -1) Then
                    nProducts += 1
                Else
                    'Streak ended
                    Dim Info As New SimplifiedLevelInfo
                    If (LastProduct < 1000 AndAlso LastProduct > -1) Then
                        Info.ItemCode = 0
                    Else
                        Info.ItemCode = LastProduct
                    End If
                    Info.NumberOfItems = nProducts
                    NewLevel.Add(Info)
                    nProducts = 1
                    LastProduct = VRTMStateConv(I, Level)
                End If
            Next

            Dim Info2 As New SimplifiedLevelInfo
            If (LastProduct < 1000 AndAlso LastProduct > -1) Then
                Info2.ItemCode = 0
            Else
                Info2.ItemCode = LastProduct
            End If
            Info2.NumberOfItems = nProducts
            NewLevel.Add(Info2)

            SimplifyLevel = NewLevel

        End Function


    End Class


    Public Function ConvertStateForAStarV2(currentSimulationTimeStep As Long, CurrentTime As Double) As FringeItemV2
        'Gets a current simulation state and converts it into a FrigeItem object.
        Dim CurrentState As New FringeItemV2
        Dim TunnelConfig(,) As Integer
        ReDim TunnelConfig(VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.nLevels - 1)
        Dim StayTime As Double

        'Fills up the current state
        For J = 0 To VRTM_SimVariables.nLevels - 1
            For I = 0 To VRTM_SimVariables.nTrays - 1
                TunnelConfig(I, J) = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).ConveyorIndex 'Defines the product index

                StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).TrayIndex)

                If TunnelConfig(I, J) <> -1 Then
                    'Evaluates whether the tray is frozen
                    If StayTime >= (VRTM_SimVariables.InletConveyors(TunnelConfig(I, J)).MinRetTime * 3600) Then
                        TunnelConfig(I, J) = TunnelConfig(I, J) + 1000 '100X indicates a frozen tray
                    End If
                End If

                'TunnelConfig(I, J) = TunnelConfig(I, J) + 1 'Adds one to the 0-based SKU index. Empty trays will show as 0.
            Next
        Next

        'Elevators
        Dim IndexOnElevator As Integer = Simulation_Results.Elevator(currentSimulationTimeStep - 1).ConveyorIndex
        StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.Elevator(currentSimulationTimeStep - 1).TrayIndex)

        If IndexOnElevator <> -1 Then
            If StayTime >= (VRTM_SimVariables.InletConveyors(IndexOnElevator).MinRetTime * 3600) Then
                'The tray in the elevator is frozen
                IndexOnElevator = IndexOnElevator + 1000
            End If
        End If
        IndexOnElevator = IndexOnElevator + 1 'Adds one to the 0-based SKU index. Empty trays will show as 0.

        CurrentState.CurrentLevel = Simulation_Results.TrayEntryLevels(currentSimulationTimeStep - 1)
        If Simulation_Results.EmptyElevatorB(currentSimulationTimeStep - 1) Then
            'Elevator B is empty
            CurrentState.Elevator1 = IndexOnElevator
            CurrentState.Elevator2 = -2
        Else
            'Elevator A is empty
            CurrentState.Elevator1 = -2
            CurrentState.Elevator2 = IndexOnElevator
        End If


        'Remaining required variables for the current state
        CurrentState.VRTMStateConv = TunnelConfig
        CurrentState.SKUCount = VRTM_SimVariables.InletConveyors.Count

        CurrentState.ComputeSimplifiedState()

        Return CurrentState
    End Function
End Module
