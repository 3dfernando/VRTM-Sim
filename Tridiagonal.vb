Module Tridiagonal
    Public Function Solve_Tridiag(ByVal e() As Double, ByVal f() As Double, ByVal g() As Double, ByVal r() As Double) As Double()
        'This function solves the tridiagonal matrix below for x()
        'All matrices MUST BE the same length (it won't be checked to make code faster)
        '[f1, g1, 0 , 0 , 0 , ...0 , 0 , 0 , 0 ] [ x1 ]   [ r1 ]
        '[e2, f2, g2, 0 , 0 , ...0 , 0 , 0 , 0 ] [ x2 ]   [ r2 ]
        '[0 , e3, f3, g3, 0 , ...0 , 0 , 0 , 0 ] [ x3 ]   [ r3 ]
        '[0 , 0 , e4, f4, g4, ...0 , 0 , 0 , 0 ]*[ x4 ] = [ r4 ]
        '[                    ...              ] [... ]   [... ]
        '[0 , 0 , 0 , 0 , 0 , ...en-1,fn-1,gn-1] [xn-1]   [rn-1]
        '[0 , 0 , 0 , 0 , 0 , ...0   ,en  ,fn  ] [ xn ]   [ rn ]

        'e1 and gn are ignored, but must be present in the arrays e and g.
        'Uses Thomas algorithm to solve it

        'Dim t1 As DateTime = DateTime.Now() '<<Used to measure time performance>>

        Dim n As Long
        Dim x() As Double
        n = UBound(e)
        ReDim x(n)

        'Decomposition
        For i = 1 To n
            e(i) = e(i) / f(i - 1)
            f(i) = f(i) - e(i) * g(i - 1)
        Next

        'Forward substitution
        For i = 1 To n
            r(i) = r(i) - e(i) * r(i - 1)
        Next

        'Backward substitution
        x(n) = r(n) / f(n)
        For i = n - 1 To 0 Step -1
            x(i) = (r(i) - g(i) * x(i + 1)) / f(i)
        Next

        'Dim t2 As DateTime = DateTime.Now() '<<Used to measure time performance>>
        'Dim dt As TimeSpan = t2 - t1 '<<Used to measure time performance>>
        '=====In my computer (Core i7 4790 3.6GHz) it took 352ms for a matrix of n=10e6. Since t~n, it means t=n*35ns=====

        Return x
    End Function
End Module
