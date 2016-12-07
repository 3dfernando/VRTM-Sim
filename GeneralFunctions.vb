Module GeneralFunctions
    'A lot of general functions needed to parse stuff
    Public Function Round(Value As Double, nDigits As Integer) As Double
        Round = Int(Value * (10 ^ nDigits)) / (10 ^ nDigits)
    End Function
End Module
