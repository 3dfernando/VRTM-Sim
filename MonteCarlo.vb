Public Module MonteCarlo
    'This module contains an implementation of the MonteCarlo Tree search algorithm.
    'It uses the concept of budgetting to define the Monte Carlo Simulation Step end (after a defined amount of hours, in this case, stop the simulation and return whatever result)

    Public Const NumberOfStartupSimulations As Long = 2 'This will set the simulations performed each expansion
    Public TimeBudgetSimulation_s As Double
    Dim TunnelState As MonteCarloState

    Public Function SolveMonteCarloSearch(CurrentState As MonteCarloState, TimeBudgetForTunnel_s As Double, TimeBudgetMonteCarlo_s As Double) As List(Of Integer)

        Dim CurrentTimer As New Stopwatch
        Dim NodesInMemory As New List(Of MonteCarloNode) 'Keeps track of all the nodes in the tree that are currently in expansion

        CurrentTimer.Start() 'This will allow the MonteCarlo to keep track of its own execution time and exit accordingly

        TimeBudgetSimulation_s = TimeBudgetForTunnel_s 'Makes it public
        TunnelState = CurrentState
        NodesInMemory.Add(EmptyNode(CurrentState))

        Dim Count As Integer = 0
        Dim BestScoreEvolution As New List(Of Double)

        Do While CurrentTimer.ElapsedMilliseconds < (TimeBudgetMonteCarlo_s * 1000)
            Dim Node As Integer = SelectNode(NodesInMemory)

            Dim ExpandedList As List(Of MonteCarloNode)
            ExpandedList = NodesInMemory(Node).ExpandNode()
            NodesInMemory.RemoveAt(Node)

            NodesInMemory.AddRange(ExpandedList)

            Count += 1

            If Count Mod 10 = 0 Then
                Dim N As MonteCarloNode = BestNode(NodesInMemory)
                BestScoreEvolution.Add(N.BestSimScoreUntilNow)
            End If

        Loop
    End Function



    Public Function EmptyNode(State As MonteCarloState) As MonteCarloNode
        'This function will initialize an empty, seed node for the simulation
        Dim Node As New MonteCarloNode
        Node.PastPlanOfActions = New List(Of Integer)
        Node.BestSimPlanOfActions = New List(Of Integer)
        Node.NumberOfSimulations = 1
        Node.BestSimScoreUntilNow = State.BatchOperation_AccessibleFraction(Node.PastPlanOfActions)

        Return Node
    End Function

    Public Function SelectNode(NodeList As List(Of MonteCarloNode)) As Integer
        'This function will randomly select a node based on its simulation results.
        'Best nodes will be more likely to be selected

        'Sums all node results (this is the denominator)
        Dim SumOfAllNodeResults As Double = 0
        For I As Integer = 0 To NodeList.Count - 1
            SumOfAllNodeResults += SelectNodeBiasFunction(NodeList(I).BestSimScoreUntilNow)
        Next

        'Now creates a list of likelihoods based on the list sum
        Dim RandomBounds As New List(Of Double)
        Dim LastValue As Double = 0
        For I As Integer = 0 To NodeList.Count - 1
            RandomBounds.Add(LastValue + (SelectNodeBiasFunction(NodeList(I).BestSimScoreUntilNow) / SumOfAllNodeResults))
            LastValue = RandomBounds.Last
        Next

        'Now selects a random node
        Dim R As Double = Rnd()
        For I As Integer = 0 To NodeList.Count - 1
            If R < RandomBounds(I) Then
                Return I
            End If
        Next

        Return 0
    End Function

    Public Function SelectNodeBiasFunction(NodeScore As Double) As Double
        'This function will bias towards better scores to make better nodes more likely to be selected
        SelectNodeBiasFunction = 100 ^ NodeScore
    End Function

    Public Function BestNode(NodeList As List(Of MonteCarloNode)) As MonteCarloNode
        'Returns the best node in the list (the highest simulated score)
        Dim MaxScore As Double = 0
        For Each Node As MonteCarloNode In NodeList
            If Node.BestSimScoreUntilNow > MaxScore Then
                MaxScore = Node.BestSimScoreUntilNow
                BestNode = Node
            End If
        Next
    End Function

    Public Class MonteCarloNode
        'This will implement a node in the MonteCarlo tree search.
        Public PastPlanOfActions As List(Of Integer) 'Plan of actions up until this node

        Public BestSimPlanOfActions As List(Of Integer) 'Plan of actions of the best simulation performed under this node
        Public BestSimScoreUntilNow As Double 'This shows the best utility of all simulations performed
        Public NumberOfSimulations As Integer 'Simulations performed until now

        Public Function ExpandNode() As List(Of MonteCarloNode)
            'This will expand this node and return the next nodes in the tree
            Dim CurrentLevel As Integer
            If Me.PastPlanOfActions.Count = 0 Then
                'First empty node
                CurrentLevel = TunnelState.CurrentLevel
            Else
                'Not an empty node, the current level is the last item in the plan
                CurrentLevel = Me.PastPlanOfActions.Last
            End If

            Dim ExpandedList As New List(Of MonteCarloNode)
            For I = 1 To VRTM_SimVariables.nLevels
                If I <> CurrentLevel Then
                    Dim N As New MonteCarloNode
                    N.PastPlanOfActions = New List(Of Integer)(Me.PastPlanOfActions)
                    N.PastPlanOfActions.Add(I - 1)
                    N.NumberOfSimulations = 0
                    N.BestSimScoreUntilNow = 0
                    N.BestSimPlanOfActions = New List(Of Integer)

                    For J = 1 To NumberOfStartupSimulations
                        N.PerformAnotherSimulation()
                    Next

                    If N.NumberOfSimulations > 0 Then
                        ExpandedList.Add(N)
                    End If
                End If
            Next

            Return ExpandedList
        End Function

        Public Sub PerformAnotherSimulation()
            'This sub will update the current node to another simulation performed

            Dim TimeConsumed As Double
            TimeConsumed = ComputeTimeForOperations(Me.PastPlanOfActions)

            Dim NextOperationTime As Double
            Dim NextOperation As Integer
            Dim PastOperation As Integer
            Dim SimPlanOfActions As New List(Of Integer)(Me.PastPlanOfActions)

            If Me.PastPlanOfActions.Count > 0 Then
                PastOperation = Me.PastPlanOfActions.Last
            Else
                PastOperation = TunnelState.CurrentLevel
            End If

            Dim RandomGen As New System.Random
            Do While True

                NextOperation = RandomGen.Next(0, VRTM_SimVariables.nLevels)
                'If NextOperation < 0 Then NextOperation = 0
                'If NextOperation > (VRTM_SimVariables.nLevels - 1) Then NextOperation = (VRTM_SimVariables.nLevels - 1)

                NextOperationTime = Compute_Elevator_Time(PastOperation, NextOperation) + 2 * VRTM_SimVariables.TrayTransferTime

                If NextOperationTime + TimeConsumed > TimeBudgetSimulation_s Then
                    'Exceeded the budget, done with simulation
                    Exit Do
                Else
                    'Just adds the next operation into the list
                    SimPlanOfActions.Add(NextOperation)
                    TimeConsumed += NextOperationTime
                End If

                PastOperation = NextOperation
            Loop

            Dim SimResult As Double
            SimResult = TunnelState.BatchOperation_AccessibleFraction(SimPlanOfActions)

            If SimResult > Me.BestSimScoreUntilNow Then
                Me.BestSimScoreUntilNow = SimResult
                Me.BestSimPlanOfActions = SimPlanOfActions
            End If

            Me.NumberOfSimulations += 1

        End Sub
    End Class

    Public Class MonteCarloState
        Public VRTMStateConv(,) As Integer 'VRTM internal state with conveyor indices (Tray no, Level no) ***A conveyor index that is larger than 1000 is the same as (index-1000), but ready to ship and needs to be on the side of elevator 2 in the goal.
        Public Elevator1 As Integer 'Content of the elevator 1 (-1 means an empty tray, -2 means no tray on it)
        Public Elevator2 As Integer 'Content of the elevator 2 (-1 means an empty tray, -2 means no tray on it)
        Public CurrentLevel As Integer 'Current level the elevator is at
        Public SKUCount As Integer 'Number of unique SKUs to treat here

        Public Sub Perform_Operation(Operation As Integer)
            'Performs an operation of moving and swapping according to the operation. 
            'The operation is the number of the level that the elevator will move to and perform the swap
            If Me.Elevator1 = -2 Xor Me.Elevator2 = -2 Then
                'Only one elevator can be empty


                'Performs the operation here
                If Me.Elevator1 = -2 Then
                    Me.Elevator1 = Me.VRTMStateConv(0, Operation)
                    For I As Long = 0 To UBound(Me.VRTMStateConv, 1) - 1
                        Me.VRTMStateConv(I, Operation) = Me.VRTMStateConv(I + 1, Operation)
                    Next
                    Me.VRTMStateConv(UBound(Me.VRTMStateConv, 1), Operation) = Me.Elevator2
                    Me.Elevator2 = -2
                ElseIf Me.Elevator2 = -2 Then
                    Me.Elevator2 = Me.VRTMStateConv(UBound(Me.VRTMStateConv, 1), Operation)
                    For I As Long = UBound(Me.VRTMStateConv, 1) - 1 To 0 Step -1
                        Me.VRTMStateConv(I + 1, Operation) = Me.VRTMStateConv(I, Operation)
                    Next
                    Me.VRTMStateConv(0, Operation) = Me.Elevator1
                    Me.Elevator1 = -2
                End If

                Me.CurrentLevel = Operation
            Else
                'Invalid
            End If
        End Sub

        Public Function AccessibleFraction() As Double
            'Returns the global fraction available/frozen
            Dim AvailableProducts As Integer = 0
            Dim TotalFrozen As Integer = 0

            For J As Integer = 0 To UBound(Me.VRTMStateConv, 2)
                'Looks at each level
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

        Public Function BatchOperation_AccessibleFraction(OperationList As List(Of Integer)) As Double
            'This will recur operations for multiple operations result evaluation
            'Will return the accessible frozen product fraction 0-1
            For Each I As Integer In OperationList
                Me.Perform_Operation(I)
            Next

            Return Me.AccessibleFraction
        End Function


    End Class

    Public Function ConvertStateForMonteCarlo(currentSimulationTimeStep As Long, CurrentTime As Double) As MonteCarloState
        'Gets a current simulation state and converts it into a FrigeItem object.
        Dim CurrentState As New MonteCarloState
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

                TunnelConfig(I, J) = TunnelConfig(I, J) + 1 'Adds one to the 0-based SKU index. Empty trays will show as 0.
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

        Return CurrentState
    End Function

    Public Function ComputeTimeForOperations(OperationList As List(Of Integer)) As Double
        'This will compute how much time does it cost for this operation list to be performed
        Dim T As Double = 0

        If OperationList.Count > 1 Then
            For I As Integer = 1 To OperationList.Count - 1
                If I = 0 Then
                    T = T + Compute_Elevator_Time(TunnelState.CurrentLevel, OperationList(I))
                End If

                T = T + Compute_Elevator_Time(OperationList(I - 1), OperationList(I))
                T = T + 2 * VRTM_SimVariables.TrayTransferTime
            Next
        End If

        ComputeTimeForOperations = T
    End Function



End Module
