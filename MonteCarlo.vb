Public Module MonteCarlo
    'This module contains an implementation of the MonteCarlo Tree search algorithm.
    'It uses the concept of budgetting to define the Monte Carlo Simulation Step end (after a defined amount of hours, in this case, stop the simulation and return whatever result)

    Public Const NumberOfStartupSimulations As Long = 2 'This will set the simulations performed each expansion
    Public TimeBudgetSimulation_s As Double
    Dim TunnelState As MonteCarloState
    'Dim RootNode As MonteCarloNode


    Public Function SolveMonteCarloSearch(CurrentState As MonteCarloState, TimeBudgetForTunnel_s As Double, TimeBudgetMonteCarlo_s As Double) As List(Of Integer)

        Dim CurrentTimer As New Stopwatch

        CurrentTimer.Start() 'This will allow the MonteCarlo to keep track of its own execution time and exit accordingly

        TimeBudgetSimulation_s = TimeBudgetForTunnel_s 'Makes it public
        TunnelState = CurrentState
        'Don't erase over here

        Dim nActions As Integer = 1000
        Dim ListOfActions As New List(Of Integer)
        Dim r As New System.Random
        For I As Integer = 0 To nActions - 1
            ListOfActions.Add(r.Next(0, VRTM_SimVariables.nLevels - 1))
            'Begins with a random list of movements
        Next

        Dim AccessibleFractionHistory As New List(Of Double)
        Dim AccessibleFractionList() As Double
        ReDim AccessibleFractionList(VRTM_SimVariables.nLevels - 1)
        Dim BestLevel As Integer
        Dim BestLevelAccFraction As Double
        Dim CurrentActionIndex As Integer


        For Iterations As Integer = 1 To 20000
            If Iterations Mod 1000 = 0 Then
                'Performs a trimming operation to kill all the repetitive operations.
                'Does it twice to kill also the leftovers.
                ListOfActions = TrimListOfOperations(ListOfActions)
                ListOfActions = TrimListOfOperations(ListOfActions)
                ComplementListWithZeros(ListOfActions, nActions)
            End If

            BestLevelAccFraction = Double.MinValue
            ReDim AccessibleFractionList(VRTM_SimVariables.nLevels - 1)
            CurrentActionIndex = r.Next(0, nActions - 1)

            For X As Integer = 0 To VRTM_SimVariables.nLevels - 1
                'This maps for the current action index what are the other options (1D max finder)
                Dim R_Copy As New List(Of Integer)(ListOfActions)
                R_Copy(CurrentActionIndex) = X 'Changes the current action index to a new one based on the current value of X

                Dim TestState As MonteCarloState = CurrentState.Clone
                TestState.PerformBatchOperation(R_Copy)

                AccessibleFractionList(X) = TestState.AccessibleFraction
                If BestLevelAccFraction < AccessibleFractionList(X) Then
                    BestLevelAccFraction = AccessibleFractionList(X)
                    BestLevel = X
                End If
            Next

            ListOfActions(CurrentActionIndex) = BestLevel 'Performs the change for the best action

            AccessibleFractionHistory.Add(BestLevelAccFraction)

            If BestLevelAccFraction = 1 Then Exit For
        Next

        'After all has already been done, trims the list
        ListOfActions = TrimListOfOperations(ListOfActions)
        ListOfActions = TrimListOfOperations(ListOfActions)


        CurrentTimer.Stop()

        Dim OperationTime As Double = ComputeTimeForOperations(ListOfActions)

        Return ListOfActions

    End Function



    'Public Function EmptyNode(State As MonteCarloState) As MonteCarloNode
    '    'This function will initialize an empty, seed node for the simulation
    '    Dim Node As New MonteCarloNode
    '    Node.PastPlanOfActions = New List(Of Integer)
    '    'Node.BestSimPlanOfActions = New List(Of Integer)
    '    Node.NumberOfSimulations = 1
    '    Node.ExpandedChildrenNodes = New List(Of MonteCarloNode)
    '    Node.CurrentLevel = TunnelState.CurrentLevel
    '    Node.ParentNode = Nothing
    '    Node.SumOfSimScores = Node.BestSimScoreUntilNow
    '    Node.LastSimScore = Node.BestSimScoreUntilNow
    '    Node.TreeLevel = 0

    '    Return Node
    'End Function


    'Public Class MonteCarloNode
    '    Implements System.ICloneable
    '    'This will implement a node in the MonteCarlo tree search.
    '    Public PastPlanOfActions As List(Of Integer) 'Plan of actions up until this node
    '    Public CurrentLevel As Integer 'Current Level the elevator is at

    '    'Public BestSimPlanOfActions As List(Of Integer) 'Plan of actions of the best simulation performed under this node
    '    Public BestSimScoreUntilNow As Double 'This shows the best utility of all simulations performed
    '    Public SumOfSimScores As Double 'Records the sum of all scores simulated until now
    '    Public LastSimScore As Double
    '    Public NumberOfSimulations As Integer 'Simulations performed until now

    '    Public ExpandedChildrenNodes As List(Of MonteCarloNode)
    '    Public ParentNode As MonteCarloNode
    '    Public TreeLevel As Integer

    '    Public Function SelectNode() As MonteCarloNode
    '        'This function will return a node selected based on MonteCarlo Search parameters
    '        Dim C As Double = 0.1 'Constant for the exploration term

    '        Dim AllChildren As List(Of MonteCarloNode) = Me.ReturnAllChildren
    '        AllChildren.Add(Me)

    '        'Dim TotalSimCount As Double = RootNode.NumberOfSimulations

    '        'Dim ExplorationTerm As Double
    '        'Dim ExploitationTerm As Double

    '        'Dim MaxValue As Double = 0
    '        'Dim CurrValue As Double = 0

    '        'Dim MaxValueAt As Integer

    '        'For I = 0 To AllChildren.Count - 1
    '        '    ExploitationTerm = AllChildren(I).BestSimScoreUntilNow
    '        '    ExplorationTerm = C * ((Math.Log(TotalSimCount) / AllChildren(I).NumberOfSimulations) ^ 0.5)

    '        '    CurrValue = ExplorationTerm + ExploitationTerm
    '        '    If MaxValue < CurrValue Then
    '        '        MaxValue = CurrValue
    '        '        MaxValueAt = I
    '        '    End If
    '        'Next

    '        Dim CurrTermResult As Double
    '        Dim CurrTermTreeLevel As Double

    '        Dim BestTermResult As Double = 0
    '        Dim BestTermTreeLevel As Integer = Integer.MaxValue
    '        Dim BestTermAt As Integer

    '        If Rnd() > 0.5 Then
    '            For I = 0 To AllChildren.Count - 1
    '                CurrTermResult = AllChildren(I).BestSimScoreUntilNow
    '                CurrTermTreeLevel = AllChildren(I).TreeLevel

    '                If (BestTermResult < CurrTermResult) AndAlso (BestTermTreeLevel > CurrTermTreeLevel) Then
    '                    'Selects the highest tree level, best simulation result so far
    '                    BestTermResult = CurrTermResult
    '                    BestTermTreeLevel = CurrTermTreeLevel
    '                    BestTermAt = I
    '                End If
    '            Next
    '            Return AllChildren(BestTermAt)
    '        Else
    '            Dim R As New System.Random
    '            Return AllChildren(R.Next(0, AllChildren.Count - 1))
    '        End If





    '    End Function

    '    Public Sub ExpandNode()
    '        'This sub will select a random subnode and expand it

    '        'If there is any other node left:
    '        Dim R As Integer = New System.Random().Next(0, VRTM_SimVariables.nLevels - 1)

    '        'Checks if the node is already expanded
    '        Dim ExpandedNode As MonteCarloNode = Nothing
    '        For Each Node As MonteCarloNode In Me.ExpandedChildrenNodes
    '            If R = Node.CurrentLevel Then
    '                ExpandedNode = Node
    '                Exit For
    '            End If
    '        Next


    '        If Not IsNothing(ExpandedNode) Then
    '            'Simulates another one in this node
    '            ExpandedNode.SimulateNode()

    '            'Backpropagates the simulation results
    '            Me.BackPropagateToParent()
    '        Else
    '            'Performs the node addition
    '            Dim newNode As New MonteCarloNode
    '            newNode.BestSimScoreUntilNow = 0
    '            newNode.NumberOfSimulations = 0
    '            newNode.PastPlanOfActions = New List(Of Integer)(Me.PastPlanOfActions)
    '            newNode.PastPlanOfActions.Add(R)
    '            newNode.CurrentLevel = R
    '            newNode.ExpandedChildrenNodes = New List(Of MonteCarloNode)
    '            newNode.ParentNode = Me
    '            newNode.TreeLevel = Me.TreeLevel + 1

    '            ExpandedChildrenNodes.Add(newNode)
    '            For I As Integer = 1 To 10
    '                ExpandedChildrenNodes.Last.SimulateNode()
    '            Next

    '            'Backpropagates the simulation results
    '            ExpandedChildrenNodes.Last.BackPropagateToParent()
    '        End If



    '    End Sub

    '    Public Sub SimulateNode()
    '        'Performs another simulation in this node
    '        Dim TimeConsumed As Double
    '        TimeConsumed = ComputeTimeForOperations(Me.PastPlanOfActions)

    '        Dim NextOperationTime As Double
    '        Dim NextOperation As Integer
    '        Dim PastOperation As Integer
    '        Dim SimPlanOfActions As New List(Of Integer)(Me.PastPlanOfActions)

    '        PastOperation = Me.CurrentLevel

    '        Dim RandomGen As New System.Random
    '        Do While True

    '            NextOperation = RandomGen.Next(0, VRTM_SimVariables.nLevels)

    '            NextOperationTime = Compute_Elevator_Time(PastOperation, NextOperation) + 2 * VRTM_SimVariables.TrayTransferTime

    '            If NextOperationTime + TimeConsumed > TimeBudgetSimulation_s Then
    '                'Exceeded the budget, done with simulation
    '                Exit Do
    '            Else
    '                'Just adds the next operation into the list
    '                SimPlanOfActions.Add(NextOperation)
    '                TimeConsumed += NextOperationTime
    '            End If

    '            PastOperation = NextOperation
    '        Loop

    '        Dim SimResult As Double

    '        If SimResult > Me.BestSimScoreUntilNow Then
    '            Me.BestSimScoreUntilNow = SimResult
    '        End If

    '        Me.LastSimScore = SimResult
    '        Me.SumOfSimScores += SimResult
    '        Me.NumberOfSimulations += 1

    '    End Sub

    '    Public Sub BackPropagateToParent()
    '        'Backpropagates the results on Me to my parent and returns the parent
    '        If Not IsNothing(Me.ParentNode) Then
    '            If Me.BestSimScoreUntilNow > Me.ParentNode.BestSimScoreUntilNow Then Me.ParentNode.BestSimScoreUntilNow = Me.BestSimScoreUntilNow
    '            Me.ParentNode.NumberOfSimulations += 1
    '            Me.ParentNode.SumOfSimScores += Me.LastSimScore
    '            Me.ParentNode.BackPropagateToParent()
    '        End If
    '    End Sub

    '    Public Function ReturnAllChildren() As List(Of MonteCarloNode)
    '        'Returns a list of the considered children nodes at all levels, recursively.
    '        Dim TempList As New List(Of MonteCarloNode)
    '        For Each Node As MonteCarloNode In Me.ExpandedChildrenNodes
    '            TempList.AddRange(Node.ReturnAllChildren)
    '            If Node.ExpandedChildrenNodes.Count < (VRTM_SimVariables.nLevels - 1) Then
    '                TempList.Add(Node) 'Doesnt return the parent node if it's all expanded
    '            End If
    '        Next

    '        Return TempList
    '    End Function

    '    Public Function Clone() As Object Implements ICloneable.Clone
    '        Return DirectCast(MemberwiseClone(), MonteCarloNode)
    '    End Function

    'End Class

    Public Class MonteCarloState
        Public VRTMStateConv(,) As Integer 'VRTM internal state with conveyor indices (Tray no, Level no) ***A conveyor index that is larger than 1000 is the same as (index-1000), but ready to ship and needs to be on the side of elevator 2 in the goal.
        Public Elevator1 As Integer 'Content of the elevator 1 (-1 means an empty tray, -2 means no tray on it)
        Public Elevator2 As Integer 'Content of the elevator 2 (-1 means an empty tray, -2 means no tray on it)
        Public CurrentLevel As Integer 'Current level the elevator is at
        Public SKUCount As Integer 'Number of unique SKUs to treat here

        Public Function Clone() As MonteCarloState
            'Clones myself
            Dim NewMe As New MonteCarloState
            NewMe.VRTMStateConv = Me.VRTMStateConv.Clone
            NewMe.Elevator1 = Me.Elevator1
            NewMe.Elevator2 = Me.Elevator2
            NewMe.CurrentLevel = Me.CurrentLevel
            NewMe.SKUCount = Me.SKUCount

            Return NewMe
        End Function
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

        Public Sub PerformBatchOperation(OperationList As List(Of Integer))
            'This will recur operations for multiple operations
            'Will update the VRTMStateConv array and the elevator states.
            'This operation takes roughly 115us/1000 random operations in a 42x10 TRVM.

            If Not (Me.Elevator1 = -2 Xor Me.Elevator2 = -2) Then
                'Only one elevator can be empty
                Exit Sub
            End If

            Dim ElevatorEndPosition As Integer
            Dim IsElevatorOnSide1 As Boolean
            Dim FloatingProduct As Integer
            If OperationList.Count Mod 2 = 0 Then
                'Even number of operations, elevator position stays as is
                If Elevator1 = -2 Then
                    ElevatorEndPosition = 2
                    IsElevatorOnSide1 = False
                    FloatingProduct = Me.Elevator2
                Else
                    ElevatorEndPosition = 1
                    IsElevatorOnSide1 = True
                    FloatingProduct = Me.Elevator1
                End If
            Else
                'Odd number of operations, elevator position changes
                If Elevator1 = -2 Then
                    ElevatorEndPosition = 1
                    IsElevatorOnSide1 = False
                    FloatingProduct = Me.Elevator2
                Else
                    ElevatorEndPosition = 2
                    IsElevatorOnSide1 = True
                    FloatingProduct = Me.Elevator1
                End If
            End If

            'Performs the transfer operations
            Dim TempFloatingProduct As Integer
            For Each I As Integer In OperationList
                If IsElevatorOnSide1 Then
                    TempFloatingProduct = VRTMStateConv(VRTM_SimVariables.nTrays - 1, I)
                    For J As Integer = VRTM_SimVariables.nTrays - 1 To 1 Step -1
                        VRTMStateConv(J, I) = VRTMStateConv(J - 1, I)
                    Next
                    VRTMStateConv(0, I) = FloatingProduct
                    FloatingProduct = TempFloatingProduct
                Else
                    TempFloatingProduct = VRTMStateConv(0, I)
                    For J As Integer = 0 To VRTM_SimVariables.nTrays - 2
                        VRTMStateConv(J, I) = VRTMStateConv(J + 1, I)
                    Next
                    VRTMStateConv(VRTM_SimVariables.nTrays - 1, I) = FloatingProduct
                    FloatingProduct = TempFloatingProduct
                End If
                IsElevatorOnSide1 = Not IsElevatorOnSide1
            Next

            'Fills the elevator position again
            If ElevatorEndPosition = 1 Then
                Me.Elevator1 = FloatingProduct
                Me.Elevator2 = -2
            Else
                Me.Elevator1 = -2
                Me.Elevator2 = FloatingProduct
            End If

        End Sub



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

    Public Function TrimListOfOperations(OpList As List(Of Integer)) As List(Of Integer)
        'Trims repetitive actions on the given list.
        Dim NewListOfActions As New List(Of Integer)
        Dim LastStreakSize As Integer = 0

        'Commented out so one can test if the lists of actions are actually equivalent
        'Dim TestState1 As MonteCarloState = TunnelState.Clone
        'TestState1.PerformBatchOperation(OpList)
        'Dim AF1 As Double = TestState1.AccessibleFraction

        For I As Integer = 0 To OpList.Count - 2
            If OpList(I) = OpList(I + 1) Then
                LastStreakSize += 1
            Else
                If LastStreakSize Mod 2 = 0 Then
                    'Even number of streaks, means either there is no streak (LastStreakSize=0) or the number of streaks is 2,4,6...
                    'The latter case shows the operation has been performed an ODD number of times (3,5,7...), which is equal to perform the operation only once.
                    NewListOfActions.Add(OpList(I))
                End If
                LastStreakSize = 0
            End If
        Next
        NewListOfActions.Add(OpList.Last)

        'Dim TestState2 As MonteCarloState = TunnelState.Clone
        'TestState2.PerformBatchOperation(NewListOfActions)
        'Dim AF2 As Double = TestState2.AccessibleFraction

        Return NewListOfActions
    End Function

    Public Sub ComplementListWithZeros(OpList As List(Of Integer), TotalSize As Integer)
        'Creates new zero items in the list so the size of the list becomes TotalSize
        'Works on the reference object (doesn't clone to save time)
        If OpList.Count >= TotalSize Then Exit Sub

        For I = 1 To TotalSize - OpList.Count
            OpList.Add(0)
        Next
    End Sub

End Module
