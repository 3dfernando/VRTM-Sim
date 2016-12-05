Public Class Poly
    'This class implements a polynomial that can perform the basic operations
    Public Coefficients() As Double 'Contains the polynomial coefficients, where the index of the array is the polynomial power

    Public Sub New(CoeffArray() As Double)
        'Initializes the polynomial
        Dim I As Integer
        ReDim Coefficients(UBound(CoeffArray))
        For I = 0 To UBound(CoeffArray)
            Coefficients(I) = CoeffArray(I)
        Next
    End Sub

    Public Sub New(Degree As Integer)
        'Creates a zero-filled poly
        ReDim Coefficients(Degree)
    End Sub


#Region "Numerical Functions"
    Public Function Replace_X(x As Double) As Double
        'This replaces X in the polynomial and returns a number
        Dim I As Integer
        Dim R As Double = 0
        For I = 0 To Me.Degree()
            R = R + (x ^ I) * Me.Coefficients(I)
        Next
        Return R
    End Function

    Public Function Numerical_Integration(from_x As Double, to_x As Double, dx As Double) As Double
        'Integrates numerically between from_x and to_x with a step dx
        'Uses the trapezium rule (simpler, and adequate for the problems solved herein)

        Dim St As Integer = 1
        Dim dx_used As Double
        Dim curr_x As Double

        Dim prev_y As Double
        Dim curr_y As Double
        Dim integral As Double

        'Init vars
        dx_used = (to_x - from_x) / Math.Abs(Int((to_x - from_x) / dx))
        prev_y = Replace_X(from_x)
        integral = 0

        'Does trapezium integral
        For curr_x = (from_x + dx_used) To to_x Step dx_used
            curr_y = Replace_X(curr_x)
            integral = integral + (curr_y + prev_y) * (dx_used / 2)
            prev_y = curr_y
        Next

        Numerical_Integration = integral
    End Function

    Public Function Numerical_Integration_of_P_on_Q(P As Poly, Q As Poly, from_x As Double, to_x As Double, dx As Double) As Double
        'Integrates numerically P/Q between from_x and to_x with a step dx
        'Uses the trapezium rule (simpler, and adequate for the problems solved herein)

        Dim St As Integer = 1
        Dim dx_used As Double
        Dim curr_x As Double

        Dim prev_y_P As Double
        Dim curr_y_P As Double
        Dim prev_y_Q As Double
        Dim curr_y_Q As Double
        Dim integral As Double

        'Init vars
        dx_used = (to_x - from_x) / Math.Abs(Int((to_x - from_x) / dx))
        prev_y_P = P.Replace_X(from_x)
        prev_y_Q = Q.Replace_X(from_x)
        integral = 0

        'Does trapezium integral
        For curr_x = (from_x + dx_used) To to_x Step dx_used
            curr_y_P = P.Replace_X(curr_x)
            curr_y_Q = Q.Replace_X(curr_x)
            integral = integral + ((curr_y_P / curr_y_Q) + (prev_y_P / prev_y_Q)) * (dx_used / 2)
            prev_y_P = curr_y_P
            prev_y_Q = curr_y_Q
        Next

        Numerical_Integration_of_P_on_Q = integral
    End Function

#End Region

#Region "Operators"
    Public Shared Operator +(P1 As Poly, P2 As Poly) As Poly
        'Implements addition of polynomials
        Dim MaxBound As Integer
        If P1.Degree > P2.Degree Then
            MaxBound = P1.Degree
        Else
            MaxBound = P2.Degree
        End If

        Dim I As Integer
        Dim C() As Double
        ReDim C(MaxBound)
        For I = 0 To MaxBound
            If P1.Degree >= I Then
                If P2.Degree >= I Then
                    C(I) = P1.Coefficients(I) + P2.Coefficients(I)
                Else
                    C(I) = P1.Coefficients(I)
                End If
            Else
                If P2.Degree >= I Then
                    C(I) = P2.Coefficients(I)
                End If
            End If
        Next

        Return New Poly(C)
    End Operator

    Public Shared Operator -(P1 As Poly, P2 As Poly) As Poly
        'Implements subtraction of polynomials
        Dim MaxBound As Integer
        If P1.Degree > P2.Degree Then
            MaxBound = P1.Degree
        Else
            MaxBound = P2.Degree
        End If

        Dim I As Integer
        Dim C() As Double
        ReDim C(MaxBound)
        For I = 0 To MaxBound
            If P1.Degree >= I Then
                If P2.Degree >= I Then
                    C(I) = P1.Coefficients(I) - P2.Coefficients(I)
                Else
                    C(I) = P1.Coefficients(I)
                End If
            Else
                If P2.Degree >= I Then
                    C(I) = P2.Coefficients(I) * (-1)
                End If
            End If
        Next

        Return New Poly(C)
    End Operator

    Public Shared Operator *(P1 As Poly, P2 As Poly) As Poly
        'Implements multiplication of polynomials
        Dim MaxBound As Integer
        Dim PolyResult() As Double
        MaxBound = P1.Degree + P2.Degree
        ReDim PolyResult(MaxBound)

        Dim I, J As Integer

        For I = 0 To P1.Degree
            For J = 0 To P2.Degree
                PolyResult(I + J) = PolyResult(I + J) + P1.Coefficients(I) * P2.Coefficients(J)
            Next
        Next

        Return New Poly(PolyResult)
    End Operator

    Public Shared Operator /(P1 As Poly, P2 As Poly) As Poly
        'Implements division of polynomials
        Dim MaxBound As Integer
        MaxBound = P1.Degree - P2.Degree
        If MaxBound < 0 Then Throw New Exception("Division of polynomials not possible")

        Dim PolyResult As New Poly(MaxBound)
        Dim tempPoly As Poly
        Dim Mono As Poly
        tempPoly = P1

        For I = MaxBound To 0 Step -1
            PolyResult.Coefficients(I) = tempPoly.Coefficients(P2.Degree + I) / P2.Coefficients(P2.Degree)
            Mono = New Poly(I)
            Mono.Coefficients(I) = PolyResult.Coefficients(I)

            tempPoly = tempPoly - (P2 * Mono)
        Next

        Return PolyResult
    End Operator

    Public Shared Operator Mod(P1 As Poly, P2 As Poly) As Poly
        'Implements the Mod operator for polynomials (it's the same algorithm as the division algorithm)
        Dim MaxBound As Integer
        MaxBound = P1.Degree - P2.Degree
        If MaxBound < 0 Then Throw New Exception("Division of polynomials not possible")

        Dim PolyResult As New Poly(MaxBound)
        Dim tempPoly As Poly
        Dim Mono As Poly
        tempPoly = P1

        For I = MaxBound To 0 Step -1
            PolyResult.Coefficients(I) = tempPoly.Coefficients(P2.Degree + I) / P2.Coefficients(P2.Degree)
            Mono = New Poly(I)
            Mono.Coefficients(I) = PolyResult.Coefficients(I)

            tempPoly = tempPoly - (P2 * Mono)
        Next

        Return tempPoly
    End Operator

    Public Function Degree() As Integer
        'Returns the degree of the polynomial
        Return UBound(Coefficients)
    End Function
#End Region

End Class
