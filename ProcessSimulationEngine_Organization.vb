Module ProcessSimulationEngine_Organization
    'TERMINOLOGY DEFINITION:
    'Movement: The basic "atom", it's group of elevator movements that consists of a level translation and a tray transfer.
    'Move: Group of movements, representing a "game move". Examples: "Transfer all frozen trays from one level to another" or "Remove all random frozen trays from one level and put them in many different levels"
    'Operation: Group of moves, represents a complete move set that accomplishes an important task. Examples: "Unscramble all possible frozen products" or "Make available all low-flow products"

#Region "SIMPLIFIED VERSIONS OF CLASSES"
    Public Class TrayDataSimplified
        'This class contains the data of a tray [Simplified version for the purpose of organization, memory saving]
        Public ConveyorIndex As Long ' Conveyor index
        Public Frozen As Boolean

        Public Function Clone() As TrayDataSimplified
            Return DirectCast(Me.MemberwiseClone(), TrayDataSimplified)
        End Function
    End Class

    Public Class VRTMStateSimplified
        'This class contain a VRTM State (Simplified version)
        Public TrayState(,) As TrayDataSimplified 'Will hold the current VRTM state in memory
        Public ElevatorState As TrayDataSimplified 'Will hold the tray in the elevator
        Public EmptyElevatorB As Boolean 'Will hold whether the elevator B is empty
        Public StateHash As String 'Holds a "probably" unique hash for the state, to compare between states.
        Public currentLevel As Long 'Holds the current level of the elevator

        Public Function Clone() As VRTMStateSimplified
            'Clones the state 
            Dim ClonedState As New VRTMStateSimplified
            ClonedState.ElevatorState = Me.ElevatorState.Clone
            ClonedState.EmptyElevatorB = Me.EmptyElevatorB
            ClonedState.StateHash = Me.StateHash

            ReDim ClonedState.TrayState(VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.nLevels - 1)

            For J = 0 To VRTM_SimVariables.nLevels - 1
                For I = 0 To VRTM_SimVariables.nTrays - 1
                    ClonedState.TrayState(I, J) = New TrayDataSimplified
                    ClonedState.TrayState(I, J) = Me.TrayState(I, J).Clone
                Next
            Next

            Return ClonedState
        End Function

        Public Function toCSV() As String
            'Returns a CSV to represent this state for debug purposes
            Dim S As String = ""
            Dim Code As Integer
            For L As Integer = 0 To VRTM_SimVariables.nLevels - 1
                For T As Integer = 0 To VRTM_SimVariables.nTrays - 1
                    Code = Me.TrayState(T, L).ConveyorIndex
                    If Me.TrayState(T, L).Frozen Then Code += 1000
                    S = S & Code.ToString & ","
                Next
                S = S & vbCrLf
            Next
            Return S
        End Function


        Public Function SimplifyLevel(Level As Integer) As List(Of SimplifiedLevelInfo)
            'Will return a list with product indices -1 (empty), 0 (unfrozen) or 100X (frozen where X is the convIndex)
            'Also the info contained in the SimplifiedLevelInfo class will return the number of items in a streak there are for the particular entry
            Dim NewLevel As New List(Of SimplifiedLevelInfo)
            Dim LastProduct As Integer
            Dim CurrentProduct As Integer

            If TrayState(0, Level).Frozen Then
                LastProduct = TrayState(0, Level).ConveyorIndex + 1000
            Else
                If TrayState(0, Level).ConveyorIndex = -1 Then
                    LastProduct = -1
                Else
                    LastProduct = 0
                End If
            End If


            Dim nProducts As Integer = 1

            For I = 1 To VRTM_SimVariables.nTrays - 1
                If TrayState(I, Level).Frozen Then
                    CurrentProduct = TrayState(I, Level).ConveyorIndex + 1000
                Else
                    If TrayState(I, Level).ConveyorIndex = -1 Then
                        CurrentProduct = -1
                    Else
                        CurrentProduct = 0
                    End If
                End If

                If LastProduct = CurrentProduct Then
                    nProducts += 1
                Else
                    'Streak ended
                    Dim Info As New SimplifiedLevelInfo
                    Info.ItemCode = LastProduct
                    Info.NumberOfItems = nProducts
                    NewLevel.Add(Info)
                    nProducts = 1

                    LastProduct = CurrentProduct
                End If
            Next

            Dim Info2 As New SimplifiedLevelInfo
            Info2.ItemCode = LastProduct
            Info2.NumberOfItems = nProducts
            NewLevel.Add(Info2)

            SimplifyLevel = NewLevel

        End Function
    End Class

    Public Class SimplifiedLevelInfo
        'Simplifies the level into a pair of two info:
        Public ItemCode As Integer
        Public NumberOfItems As Integer

        Public Shared Operator =(A As SimplifiedLevelInfo, B As SimplifiedLevelInfo) As Boolean
            If A.ItemCode = B.ItemCode AndAlso A.NumberOfItems = B.NumberOfItems Then
                Return True
            Else
                Return False
            End If
        End Operator

        Public Shared Operator <>(A As SimplifiedLevelInfo, B As SimplifiedLevelInfo) As Boolean
            If A.ItemCode = B.ItemCode AndAlso A.NumberOfItems = B.NumberOfItems Then
                Return False
            Else
                Return True
            End If
        End Operator

    End Class
#End Region

#Region "MAIN FUNCTION BLOCKS"
    Public Function DefineOrganizationMovements(currentSimulationTimeStep As Integer, AvailableTime As Double, CurrentTime As Double) As List(Of Integer)
        'This is the main function.
        'It's returning a list of levels (Long) where each level corresponds to a back-and-forth movement [It starts at Elev. B, moves to the first level in the list, Performs a transfer B->A, 
        'moves to the next level in the list, performs a transfer A->B, etc.]

        Dim WeekendStrategy As Boolean
        WeekendStrategy = (AvailableTime > (24 * 3600)) 'If there is more than 24 hours available, employ the "weekend strategy"
        WeekendStrategy = WeekendStrategy And VRTM_SimVariables.EnableImprovedWeekendStrat 'But only if it's configured to be enabled

        '-------------NOW THAT THERE ARE MULTIPLE CODES TO SOLVE THIS ISSUE:--------------


        If False Then
            'A* search algorithm
            Dim currentState As FringeItem = ConvertStateForA_Star(currentSimulationTimeStep, CurrentTime, 0.9)

            Return Solve_A_Star_Search(currentState, 300)
        End If

        If False Then
            'Monte Carlo search algorithm
            Dim currentState As GreedyTreeSearchState = ConvertStateForGreedyTreeSearch(currentSimulationTimeStep, CurrentTime)

            Return SolveGreedyTreeSearchSearch(currentState, AvailableTime, 300)
        End If

        If True Then
            'Uses just logic and the assumption that there are at least two levels full of either unfrozen product or empty
            Dim currentState As VRTMStateSimplified = GenerateSimplifiedState(currentSimulationTimeStep, CurrentTime)
            Return OrderThisTunnelWithTwoEmptyLevels(currentState)
        End If
        Return New List(Of Integer)

    End Function

    'Delete this function
    Public Function DefineOrganizationMovementsProdDemandTransition(currentSimulationTimeStep As Long, AvailableTime As Double, CurrentTime As Double) As List(Of Integer)
        'This is a secondary function that accomplishes the purpose of enabling product to be available when the transition from the period ruled by "production" (startup) passes and the period ruled by "demand != production" begins.
        'It's returning a list of levels (Long) where each level corresponds to a back-and-forth movement [It starts at Elev. B, moves to the first level in the list, Performs a transfer B->A, moves to the next level in the list, 
        'performs a transfer A->B, etc.]

        Dim currentState As VRTMStateSimplified = GenerateSimplifiedState(currentSimulationTimeStep, CurrentTime)

        'Shelving strategy: Flip all levels that contain product
        Dim Movements As New List(Of Integer)
        Dim FlipRecipients As New List(Of Integer)
        Dim FlipContainers As New List(Of Integer)
        Dim IsLevelFullOfEmptyTrays As Boolean

        For L As Integer = 0 To VRTM_SimVariables.nLevels - 1
            IsLevelFullOfEmptyTrays = True
            For T As Integer = 0 To VRTM_SimVariables.nTrays - 1
                'Verifies each tray
                If currentState.TrayState(T, L).ConveyorIndex <> -1 Then
                    IsLevelFullOfEmptyTrays = False
                    Exit For
                End If
            Next

            If IsLevelFullOfEmptyTrays Then
                FlipRecipients.Add(L) 'Empty level is a flip recipient
            Else
                FlipContainers.Add(L) 'Non-empty level is a flip container (must be flipped)
            End If
        Next

        If currentState.EmptyElevatorB Then
            'Brings back the product to elevator b
            Movements.Add(currentState.currentLevel)
        End If

        Dim Distance As Integer
        Dim MinDistance As Integer
        Dim MinDistanceAt As Integer = -1
        Dim FlipTimes As Integer
        For Each L As Integer In FlipContainers
            'Level to flip=L
            'Finds the closest flip recipient
            MinDistance = Integer.MaxValue
            MinDistanceAt = -1
            For Each L2 As Integer In FlipRecipients
                Distance = Math.Abs(L2 - L)
                If MinDistance > Distance Then
                    MinDistance = Distance
                    MinDistanceAt = L2
                End If
            Next

            'Counts how many times to perform the flip
            For FlipTimes = 0 To VRTM_SimVariables.nTrays - 1
                If currentState.TrayState(FlipTimes, L).ConveyorIndex = -1 Then Exit For
            Next

            'Performs the flip nTrays Times
            For A As Integer = 1 To FlipTimes
                Movements.Add(L)
                Movements.Add(MinDistanceAt)
            Next

            'Updates the list
            FlipRecipients.Remove(MinDistanceAt)
            FlipRecipients.Add(L)
        Next

        Return Movements

    End Function
#End Region



#Region "MOVES"
    Public Function OrderThisTunnelWithTwoEmptyLevels(currentState As VRTMStateSimplified) As List(Of Integer)
        'Uses just logic and the assumption that there are at least two levels full of either unfrozen product or empty

        'Classifies all levels:
        Dim ClosedLevelList As New List(Of Integer) 'Non modifiable

        Dim GrowingLevelList As New List(Of Integer) 'Priority Recipient when product is frozen and there is a match
        Dim UnfrozenLevelList As New List(Of Integer) 'Priority 1 Recipient
        Dim EmptyLevelList As New List(Of Integer) 'Priority 2 Recipient
        Dim UnfrozenEmptyLevelList As New List(Of Integer) 'Priority 3 Recipient

        Dim ScrambledLevelList As New List(Of Integer) 'Source of products

        For L As Integer = 0 To VRTM_SimVariables.nLevels - 1
            Select Case ClassifyThisLevel(currentState, L)
                Case "ClosedLevel"
                    ClosedLevelList.Add(L)
                Case "GrowingLevel"
                    GrowingLevelList.Add(L)
                Case "UnfrozenLevel"
                    UnfrozenLevelList.Add(L)
                Case "EmptyLevel"
                    EmptyLevelList.Add(L)
                Case "UnfrozenEmptyLevel"
                    UnfrozenEmptyLevelList.Add(L)
                Case "ScrambledLevel"
                    ScrambledLevelList.Add(L)
            End Select
        Next

        Dim ListOfActions As New List(Of Integer)
        Dim SimplifiedLevel As New List(Of SimplifiedLevelInfo)
        'The only levels that need fixing are the scrambled levels.
        'Checks if there are any
        If ScrambledLevelList.Count > 0 Then
            'OK. Makes sure the elevator is in B side. If not, returns an error
            If currentState.EmptyElevatorB Then
                ListOfActions.Add(-1)
                Return ListOfActions
            End If

            'Orders the scrambled levels so the ones that have the least variance of product codes are the first to be taken
            ScrambledLevelList.Sort(Function(X As Integer, Y As Integer)
                                        Dim UniqueItemsInX As New List(Of Integer)
                                        Dim UniqueItemsInY As New List(Of Integer)
                                        Dim SimplifiedX As New List(Of SimplifiedLevelInfo)(currentState.SimplifyLevel(X))
                                        Dim SimplifiedY As New List(Of SimplifiedLevelInfo)(currentState.SimplifyLevel(Y))
                                        Dim ThisOneIsNotUnique As Boolean

                                        For Each XProduct As SimplifiedLevelInfo In SimplifiedX
                                            ThisOneIsNotUnique = False
                                            For Each LX As Integer In UniqueItemsInX
                                                If LX = XProduct.ItemCode Then
                                                    ThisOneIsNotUnique = True
                                                    Exit For
                                                End If
                                            Next
                                            If Not ThisOneIsNotUnique Then
                                                UniqueItemsInX.Add(XProduct.ItemCode)
                                            End If
                                        Next
                                        For Each YProduct As SimplifiedLevelInfo In SimplifiedY
                                            ThisOneIsNotUnique = False
                                            For Each LY As Integer In UniqueItemsInY
                                                If LY = YProduct.ItemCode Then
                                                    ThisOneIsNotUnique = True
                                                    Exit For
                                                End If
                                            Next
                                            If Not ThisOneIsNotUnique Then
                                                UniqueItemsInY.Add(YProduct.ItemCode)
                                            End If
                                        Next


                                        Return UniqueItemsInX.Count.CompareTo(UniqueItemsInY.Count)
                                    End Function)


            'Begins cleaning the scrambled levels
            For Each SL As Integer In ScrambledLevelList
                'Defines the list of products to go through
                Dim LevelComposition As New List(Of SimplifiedLevelInfo)(currentState.SimplifyLevel(SL))
                Dim nMovementPairs As Integer
                Dim ClosestLevel As Integer

                Dim Prod As SimplifiedLevelInfo
                For P = 0 To LevelComposition.Count - 1
                    Prod = LevelComposition(P)

                    If Not Prod.ItemCode <= 0 Then 'it's not an unfrozen/empty product
                        'Now adds movements according to this simplified level version
                        'We need to find a target level
                        'Priorty list: GrowingLevel>UnfrozenLevel>EmptyLevel>UnfrozenEmptyLevel

                        'Tries a growing level first
                        Dim TargetGrowingLevels As New List(Of KeyValuePair(Of Integer, Integer)) 'Keyvaluepair: Key=Level, Value=AvailableSpace
                        Dim AvailableSpace As Integer
                        Dim MinAvailableSpace As Integer = Integer.MaxValue
                        For Each GrowingLevel As Integer In GrowingLevelList
                            If currentState.TrayState(0, GrowingLevel).ConveyorIndex = Prod.ItemCode - 1000 Then
                                'Here we assume the item is frozen as it is already classified as a growing level
                                'Verifies the available space and selects the level if the available space is the least possible
                                AvailableSpace = VRTM_SimVariables.nTrays - currentState.SimplifyLevel(GrowingLevel).First.NumberOfItems 'Defines the available space as the total tray number minus the current item count in the growing level
                                TargetGrowingLevels.Add(New KeyValuePair(Of Integer, Integer)(GrowingLevel, AvailableSpace))
                            End If
                        Next

                        Dim RemainingItemsToPass As Integer = Prod.NumberOfItems 'Number of items to pass to the other side (counter decreases as items are passed)

                        'We could either exit this loop with a target level or not:
                        If TargetGrowingLevels.Count > 0 Then
                            'At least one target level has been found!
                            'Sorts them - This will ensure the most levels are closed before using a new one
                            TargetGrowingLevels.Sort(Function(X As KeyValuePair(Of Integer, Integer), Y As KeyValuePair(Of Integer, Integer))
                                                         Return X.Value.CompareTo(Y.Value)
                                                     End Function)

                            For Each GLevel As KeyValuePair(Of Integer, Integer) In TargetGrowingLevels
                                'Examines each growing level and figures whether there is available space to deposit all the units of this product index
                                If GLevel.Value >= RemainingItemsToPass Then
                                    'There is plenty of space in the target level
                                    nMovementPairs = RemainingItemsToPass
                                    RemainingItemsToPass = 0
                                Else
                                    nMovementPairs = GLevel.Value 'Not enough space, just move the available products
                                    RemainingItemsToPass = RemainingItemsToPass - GLevel.Value
                                    GrowingLevelList.Remove(GLevel.Key) 'Removes it for future queries
                                    ClosedLevelList.Add(GLevel.Key) 'Includes it on the list of closed levels
                                End If

                                'Performs the movement pairs
                                For I As Integer = 1 To nMovementPairs
                                    ListOfActions.Add(SL)
                                    ListOfActions.Add(GLevel.Key)
                                Next
                            Next
                        End If

                        nMovementPairs = RemainingItemsToPass
                        If RemainingItemsToPass > 0 Or TargetGrowingLevels.Count = 0 Then
                            'That wasn't possible or there wasn't enough space on the growing levels - try according to the priority list:
                            If UnfrozenLevelList.Count > 0 Then
                                'Finds the closest level and then performs the movements (super simple)
                                ClosestLevel = FindClosestLevel(SL, UnfrozenLevelList)
                                UnfrozenLevelList.Remove(ClosestLevel)  'Removes it from the list
                            ElseIf EmptyLevelList.Count > 0 Then
                                ClosestLevel = FindClosestLevel(SL, EmptyLevelList)
                                EmptyLevelList.Remove(ClosestLevel) 'Removes it from the list
                            ElseIf UnfrozenEmptyLevelList.Count > 0 Then
                                ClosestLevel = FindClosestLevel(SL, UnfrozenEmptyLevelList)
                                UnfrozenEmptyLevelList.Remove(ClosestLevel) 'Removes it from the list
                            Else
                                'No success with any of the possible candidates. Time to give up from this level!
                                Continue For
                            End If

                            'Performs the movement pairs
                            For I As Integer = 1 To nMovementPairs
                                ListOfActions.Add(SL)
                                ListOfActions.Add(ClosestLevel)
                            Next
                            'Adds the closest level here to the growing level list
                            GrowingLevelList.Add(ClosestLevel)

                        End If
                    Else
                        'Verify whether this is the trailing unfrozen group
                        If P = LevelComposition.Count - 1 Then
                            Continue For 'Skips the trailing unfrozen streak
                        End If

                        ' If we're here it's either an unfrozen or an empty product that needs to be organized. Differs them here:
                        If Prod.ItemCode = 0 Then
                            ' For unfrozen products, prioritizes sending them to an unfrozen level:
                            nMovementPairs = Prod.NumberOfItems
                            If UnfrozenLevelList.Count > 0 Then
                                'Finds the closest level and then performs the movements (super simple)
                                ClosestLevel = FindClosestLevel(SL, UnfrozenLevelList)
                            ElseIf UnfrozenEmptyLevelList.Count > 0 Then
                                ClosestLevel = FindClosestLevel(SL, UnfrozenEmptyLevelList)
                            ElseIf EmptyLevelList.Count > 0 Then
                                ClosestLevel = FindClosestLevel(SL, EmptyLevelList)
                                EmptyLevelList.Remove(ClosestLevel) 'Removes it from the list as it's not clean anymore
                                UnfrozenEmptyLevelList.Add(ClosestLevel) 'Adds it to the contaminated list
                            Else
                                'No success with any of the possible candidates. Time to give up from this level!
                                Continue For
                            End If
                        ElseIf Prod.ItemCode = -1 Then
                            ' For frozen products, prioritizes sending them to an empty level:
                            nMovementPairs = Prod.NumberOfItems
                            If EmptyLevelList.Count > 0 Then
                                ClosestLevel = FindClosestLevel(SL, EmptyLevelList)
                            ElseIf UnfrozenEmptyLevelList.Count > 0 Then
                                ClosestLevel = FindClosestLevel(SL, UnfrozenEmptyLevelList)
                            ElseIf UnfrozenLevelList.Count > 0 Then
                                'Finds the closest level and then performs the movements (super simple)
                                ClosestLevel = FindClosestLevel(SL, UnfrozenLevelList)
                                UnfrozenLevelList.Remove(ClosestLevel)  'Removes it from the list
                                UnfrozenEmptyLevelList.Add(ClosestLevel)  'Adds it to the contaminated list
                            Else
                                'No success with any of the possible candidates. Time to give up from this level!
                                Continue For
                            End If

                            'Now that we know the closest level, Performs the movement pairs
                            For I As Integer = 1 To nMovementPairs
                                ListOfActions.Add(SL)
                                ListOfActions.Add(ClosestLevel)
                            Next
                        End If
                    End If


                Next
                'ScrambledLevelList.Remove(SL) 'Removes it for future queries
                UnfrozenEmptyLevelList.Add(SL) 'Includes it on the list of unfrozen/empty contaminated levels (we don't know the content through the operations performed here)
            Next

        Else
            'No action needed!
        End If

        Return ListOfActions

    End Function

    Public Function ClassifyThisLevel(currentState As VRTMStateSimplified, Level As Integer) As String
        'Classifies the level into the following classes:

        '-Levels that are full of the same frozen product (ClosedLevel)
        '-Levels that are full of unfrozen product (UnfrozenLevel)
        '-Levels that have only unfrozen and empty trays (UnfrozenEmptyLevel)
        '-Levels that have only empty trays (EmptyLevel)
        '-Levels that have a sequence of the same frozen product with a trail of either unfrozen or empty products (GrowingLevel)
        '-Levels that don't follow the rules stated before (ScrambledLevel)

        If currentState.TrayState(0, Level).Frozen Then
            Dim isClosed As Boolean = True
            Dim isGrowing As Boolean = True
            Dim isFrozen, isTheSame, isEmpty As Boolean

            For T As Integer = 1 To VRTM_SimVariables.nTrays - 1
                isTheSame = (currentState.TrayState(T, Level).ConveyorIndex = currentState.TrayState(T - 1, Level).ConveyorIndex)
                isFrozen = currentState.TrayState(T, Level).Frozen
                'isEmpty = (currentState.TrayState(T, Level).ConveyorIndex = -1)

                'If isEmpty Then
                '    Dim A As String = ""
                'End If
                If isFrozen Then
                    isGrowing = isGrowing And isTheSame
                    isClosed = isClosed And isTheSame
                Else
                    isClosed = False
                End If
            Next
            If isClosed Then Return "ClosedLevel"
            If isGrowing Then Return "GrowingLevel"
            Return "ScrambledLevel"
        Else
            Dim isFullOfUnfrozen As Boolean = True
            Dim isUnfrozenEmpty As Boolean = True
            Dim isFullOfEmpty As Boolean = True
            Dim isEmpty, isUnfrozen As Boolean

            isFullOfUnfrozen = Not (currentState.TrayState(0, Level).ConveyorIndex = -1)
            isFullOfEmpty = (currentState.TrayState(0, Level).ConveyorIndex = -1)

            For T As Integer = 1 To VRTM_SimVariables.nTrays - 1
                isEmpty = (currentState.TrayState(T, Level).ConveyorIndex = -1)
                isUnfrozen = Not (currentState.TrayState(T, Level).Frozen)

                If isUnfrozen Then
                    isFullOfUnfrozen = isFullOfUnfrozen And isUnfrozen And (Not isEmpty)
                    isFullOfEmpty = isFullOfEmpty And isEmpty
                Else
                    isFullOfUnfrozen = False
                    isFullOfEmpty = False
                    isUnfrozenEmpty = False
                End If
            Next
            If isFullOfUnfrozen Then Return "UnfrozenLevel"
            If isFullOfEmpty Then Return "EmptyLevel"
            If isUnfrozenEmpty Then Return "UnfrozenEmptyLevel"
            Return "ScrambledLevel"
        End If

    End Function

    Public Function FindClosestLevel(Level As Integer, LevelList As List(Of Integer)) As Integer
        'Finds the closes number in the list to the variable Level shown here
        Dim D As Integer
        Dim minD As Integer = Integer.MaxValue
        Dim minDat As Integer = -1
        For Each L As Integer In LevelList
            D = Math.Abs(L - Level)
            If minD > D Then
                minD = D
                minDat = L
            End If
        Next
        Return minDat
    End Function

#End Region

#Region "MOVEMENTS"
    Public Function PerformMovement(State As VRTMStateSimplified, Level As Long) As VRTMStateSimplified
        'This function is a MOVEMENT and performs a movement->transfer in the elevator at the given level and returns a new, cloned state
        'Old state: _ AABBCC X      (A,B,C are products, _ is an empty elevator and X is a product in the elevator)
        'New state: A ABBCCX _
        'This will happen at the level informed in the parameters.

        PerformMovement = State.Clone

        If State.EmptyElevatorB Then
            'Performs movement A->>B
            PerformMovement.ElevatorState = State.TrayState(VRTM_SimVariables.nTrays - 1, Level).Clone

            For I = VRTM_SimVariables.nTrays - 2 To 0 Step -1
                PerformMovement.TrayState(I + 1, Level) = State.TrayState(I, Level).Clone
            Next
            PerformMovement.TrayState(0, Level) = State.ElevatorState.Clone

            PerformMovement.EmptyElevatorB = False
        Else
            'Performs movement B->>A
            PerformMovement.ElevatorState = State.TrayState(0, Level).Clone

            For I = 1 To VRTM_SimVariables.nTrays - 1
                PerformMovement.TrayState(I - 1, Level) = State.TrayState(I, Level).Clone
            Next
            PerformMovement.TrayState(VRTM_SimVariables.nTrays - 1, Level) = State.ElevatorState.Clone


            PerformMovement.EmptyElevatorB = True
        End If
    End Function
#End Region





#Region "AUXILIARY FUNCTIONS"
    Public Function StreakSize(State As VRTMStateSimplified, Level As Long) As Long
        'Returns the size of a "Streak" of products in the given level. 
        'Examples:
        'XXXXXXXAAAAAAA returns 7
        'XXXXXXXAAAABAA returns 2

        StreakSize = 1
        Dim LastProductIndex As Long

        LastProductIndex = State.TrayState(VRTM_SimVariables.nTrays - 1, Level).ConveyorIndex
        For I As Long = VRTM_SimVariables.nTrays - 2 To 0 Step -1
            If LastProductIndex = State.TrayState(I, Level).ConveyorIndex Then
                StreakSize += 1
            Else
                Exit For
            End If
        Next

    End Function

    Public Function CountThisIndexInThisLevel(State As VRTMStateSimplified, Level As Long, index As Long) As Long
        'Returns how many products of this index are in this level.
        'Examples:
        'XXXXXXXAAAAAAA returns 7
        'XXXXXXXAAAABAA returns 6

        CountThisIndexInThisLevel = 0
        For I As Long = 0 To VRTM_SimVariables.nTrays - 1
            If index = State.TrayState(I, Level).ConveyorIndex Then
                CountThisIndexInThisLevel += 1
            End If
        Next
    End Function

    Public Function IsLevelEmpty(State As VRTMStateSimplified, Level As Long) As Boolean
        'Returns whether the level empty
        IsLevelEmpty = True
        For I As Long = 0 To VRTM_SimVariables.nTrays - 1
            IsLevelEmpty = IsLevelEmpty And (State.TrayState(I, Level).ConveyorIndex = -1)
        Next
    End Function

    Public Function IsLevelFullOfTheSameProduct(State As VRTMStateSimplified, Level As Long) As Boolean
        'Returns whether the level is full of the same product
        For I As Long = 0 To VRTM_SimVariables.nTrays - 1
            If State.TrayState(I, Level).ConveyorIndex <> State.TrayState(0, Level).ConveyorIndex Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function GenerateSimplifiedState(currentSimulationTimeStep As Long, CurrentTime As Double) As VRTMStateSimplified
        'This will return a simplified version of the current time step
        Dim CurrentState As New VRTMStateSimplified
        Dim I, J As Long
        Dim StayTime As Double

        'Fills up the current state
        ReDim CurrentState.TrayState(VRTM_SimVariables.nTrays - 1, VRTM_SimVariables.nLevels - 1)

        For J = 0 To VRTM_SimVariables.nLevels - 1
            For I = 0 To VRTM_SimVariables.nTrays - 1
                CurrentState.TrayState(I, J) = New TrayDataSimplified

                CurrentState.TrayState(I, J).ConveyorIndex = Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).ConveyorIndex 'Defines the product index
                StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.VRTMTrayData(currentSimulationTimeStep - 1, I, J).TrayIndex)

                If CurrentState.TrayState(I, J).ConveyorIndex = -1 Then
                    'No tray here
                    CurrentState.TrayState(I, J).Frozen = False
                Else
                    CurrentState.TrayState(I, J).Frozen = StayTime >= (VRTM_SimVariables.InletConveyors(CurrentState.TrayState(I, J).ConveyorIndex).MinRetTime * 3600) 'Whether the product will be frozen by the end of the organization
                End If

            Next
        Next
        'Elevator part
        CurrentState.ElevatorState = New TrayDataSimplified
        CurrentState.ElevatorState.ConveyorIndex = Simulation_Results.Elevator(currentSimulationTimeStep - 1).ConveyorIndex
        StayTime = CurrentTime - Simulation_Results.TrayEntryTimes(Simulation_Results.Elevator(currentSimulationTimeStep - 1).TrayIndex)

        If CurrentState.ElevatorState.ConveyorIndex = -1 Then
            CurrentState.ElevatorState.Frozen = False
        Else
            CurrentState.ElevatorState.Frozen = StayTime >= (VRTM_SimVariables.InletConveyors(CurrentState.ElevatorState.ConveyorIndex).MinRetTime * 3600)
        End If

        CurrentState.EmptyElevatorB = Simulation_Results.EmptyElevatorB(currentSimulationTimeStep - 1)

        CurrentState.currentLevel = Simulation_Results.TrayEntryLevels(currentSimulationTimeStep - 1)

        Return CurrentState
    End Function
#End Region



End Module
