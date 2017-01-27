Module FoodPropertiesModel
    <Serializable> Public Class FoodProperties
        'This class models the food properties model according to what is described in Chapter 9 of the ASHRAE refrigeration handbook.
        'Uses Choi and Okos models for food properties and Schwartzbert specific heat model
        'The model is code-lengthy, but an effort was made to reduce mathemathical operations (and computational cost) on the extraction of the food properties as a function of temperature
        Public FoodModelUsed As FoodPropertiesListItem 'Stores the food model properties raw data (%fat, etc)

        Private Initialized As Boolean = False 'Flag that says whether the model has already been initialized. This will allow the various property functions to use the quicker piece-wise functions to return values
        Public Const MaxTemperature As Double = 50 'Stores the temperature bounds of the piecewise function fits
        Public Const MidTemperature As Double = -5
        Public Const MinTemperature As Double = -50

#Region "Polynomial fit coefficients"
        Private FitCoeffs_rho_unfrozen As List(Of Double) 'Stores the polynomial coefficients for the density of this product
        Private FitCoeffs_rho_frozen1 As List(Of Double) 'Stores the polynomial coefficients for the density of this product
        Private FitCoeffs_rho_frozen2 As List(Of Double) 'Stores the polynomial coefficients for the density of this product

        Private FitCoeffs_k_unfrozen As List(Of Double) 'Stores the polynomial coefficients for the thermal conductivity of this product
        Private FitCoeffs_k_frozen1 As List(Of Double) 'Stores the polynomial coefficients for the thermal conductivity of this product
        Private FitCoeffs_k_frozen2 As List(Of Double) 'Stores the polynomial coefficients for the thermal conductivity of this product

        Private FitCoeffs_cp_unfrozen As List(Of Double) 'Stores the polynomial coefficients for specific heat of this product
        Private FitCoeffs_cp_frozen1 As List(Of Double) 'Stores the polynomial coefficients for specific heat of this product
        Private FitCoeffs_cp_frozen2 As List(Of Double) 'Stores the polynomial coefficients for specific heat of this product

        Private FitCoeffs_alpha_unfrozen As List(Of Double) 'Stores the polynomial coefficients for thermal diffusivity of this product
        Private FitCoeffs_logalpha_frozen1 As List(Of Double) 'Stores the polynomial coefficients for thermal diffusivity of this product
        Private FitCoeffs_logalpha_frozen2 As List(Of Double) 'Stores the polynomial coefficients for thermal diffusivity of this product

        '''
        Private FitCoeffs_H_unfrozen As List(Of Double) 'Stores the polynomial coefficients for enthalpy of this product
        Private FitCoeffs_H_frozen1 As List(Of Double) 'Stores the polynomial coefficients for enthalpy of this product
        Private FitCoeffs_H_frozen2 As List(Of Double) 'Stores the polynomial coefficients for enthalpy of this product
#End Region

        Public Sub New()
            Initialized = False
        End Sub

        Public Sub New(FoodModel As FoodPropertiesListItem, initializeVariables As Boolean)
            FoodModelUsed = FoodModel
            If initializeVariables Then Initialize()
        End Sub

        Public Sub Initialize()
            '--------Initializes the food properties model and fills up the important variable arrays--------

            If IsNothing(FoodModelUsed) Then Throw New Exception("There must be a food property in memory to initialize the food model")

            Init_Rho()
            Initialized = True
            Init_k()
            Init_cp()
            Init_alpha()
            Init_H()

        End Sub

        Private Sub Init_Rho()
            'This fills up the polynomial fit coefficients for the density variable

            'The polynomial fit coefficients for the density of the components are as shown below:
            Dim rho_p As New Poly({1329.9, -0.5184})
            Dim rho_f As New Poly({925.59, -0.41757})
            Dim rho_c As New Poly({1599.1, -0.31046})
            Dim rho_a As New Poly({2423.8, -0.28063})
            Dim rho_w As New Poly({997.18, 0.0031439, -0.0037574})
            Dim rho_i As New Poly({916.89, -0.13071})

            Dim xp As Double
            Dim xf As Double
            Dim xc As Double
            Dim xa As Double
            Dim xi As Double
            Dim xw As Double
            Dim Tf As Double

            With FoodModelUsed
                xp = .ProteinContent
                xf = .FatContent
                xc = .CarbContent
                xa = .AshContent
                xw = .WaterContent
                Tf = .FreezingTemp
            End With


            '================UNFROZEN================
            Dim rho As New List(Of PointF)
            Dim newPoint As PointF
            Dim nPoints As Integer = 25
            Dim Tc As Double
            Dim i As Long

            newPoint.X = Tf
            newPoint.Y = 1 / (xp / rho_p.Replace_X(Tf) + xf / rho_f.Replace_X(Tf) + xc / rho_c.Replace_X(Tf) + xa / rho_a.Replace_X(Tf) _
                            + xw / rho_w.Replace_X(Tf))
            rho.Add(newPoint)

            For i = 1 To nPoints
                Tc = i * (MaxTemperature - Tf) / nPoints + Tf
                newPoint.X = Tc
                newPoint.Y = 1 / (xp / rho_p.Replace_X(Tc) + xf / rho_f.Replace_X(Tc) + xc / rho_c.Replace_X(Tc) + xa / rho_a.Replace_X(Tc) _
                            + xw / rho_w.Replace_X(Tc))
                rho.Add(newPoint)
            Next

            FitCoeffs_rho_unfrozen = FindPolynomialLeastSquaresFit(rho, 3)


            '================FROZEN PART 1================

            nPoints = 1000
            rho.Clear()
            For i = 1 To nPoints
                Tc = (i - 1) * (Tf - MidTemperature) / nPoints + MidTemperature
                xi = (xw - 0.4 * xp) * (1 - (Tf / Tc))
                newPoint.X = Tc
                newPoint.Y = 1 / (xp / rho_p.Replace_X(Tc) + xf / rho_f.Replace_X(Tc) + xc / rho_c.Replace_X(Tc) + xa / rho_a.Replace_X(Tc) _
                            + xi / rho_i.Replace_X(Tc) + (xw - xi) / rho_w.Replace_X(Tc))
                rho.Add(newPoint)
            Next

            FitCoeffs_rho_frozen1 = FindPolynomialLeastSquaresFit(rho, 10)


            '================FROZEN PART 2================
            nPoints = 1000
            rho.Clear()
            For i = 1 To nPoints - 1
                Tc = (i - 1) * (MidTemperature - MinTemperature) / nPoints + MinTemperature
                xi = (xw - 0.4 * xp) * (1 - (Tf / Tc))
                newPoint.X = Tc
                newPoint.Y = 1 / (xp / rho_p.Replace_X(Tc) + xf / rho_f.Replace_X(Tc) + xc / rho_c.Replace_X(Tc) + xa / rho_a.Replace_X(Tc) _
                            + xi / rho_i.Replace_X(Tc) + (xw - xi) / rho_w.Replace_X(Tc))
                rho.Add(newPoint)
            Next

            FitCoeffs_rho_frozen2 = FindPolynomialLeastSquaresFit(rho, 10)
        End Sub

        Public Function get_rho(T As Double) As Double
            'Returns the value of rho(T)

            If Initialized Then
                If T > FoodModelUsed.FreezingTemp Then
                    get_rho = ReplaceT(T, FitCoeffs_rho_unfrozen)
                ElseIf T > MidTemperature Then
                    get_rho = ReplaceT(T, FitCoeffs_rho_frozen1)
                Else
                    get_rho = ReplaceT(T, FitCoeffs_rho_frozen2)
                End If
            Else
                get_rho = 0
            End If
        End Function

        Private Sub Init_k()
            'This fills up the polynomial fit coefficients for the density variable
            'The polynomial fit coefficients for the thermal conductivity of the components are as shown below:
            Dim k_p As New Poly({0.17881, 0.0011958, -0.0000027178})
            Dim k_f As New Poly({0.18071, -0.00027604, -0.00000017749})
            Dim k_c As New Poly({0.20141, 0.0013874, -0.0000043312})
            Dim k_a As New Poly({0.32962, 0.0014011, -0.0000029069})
            Dim k_w As New Poly({0.57109, 0.0017625, -0.0000067036})
            Dim k_i As New Poly({2.2196, -0.0062489, 0.00010154})

            'The polynomial fit coefficients for the density of the components are as shown below:
            Dim rho_p As New Poly({1329.9, -0.5184})
            Dim rho_f As New Poly({925.59, -0.41757})
            Dim rho_c As New Poly({1599.1, -0.31046})
            Dim rho_a As New Poly({2423.8, -0.28063})
            Dim rho_w As New Poly({997.18, 0.0031439, -0.0037574})
            Dim rho_i As New Poly({916.89, -0.13071})

            Dim xp As Double
            Dim xf As Double
            Dim xc As Double
            Dim xa As Double
            Dim xi As Double
            Dim xw As Double
            Dim Tf As Double

            With FoodModelUsed
                xp = .ProteinContent
                xf = .FatContent
                xc = .CarbContent
                xa = .AshContent
                xw = .WaterContent
                Tf = .FreezingTemp
            End With


            '================UNFROZEN================
            Dim k As New List(Of PointF)
            Dim newPoint As PointF
            Dim nPoints As Integer = 25
            Dim Tc As Double
            Dim i As Long

            newPoint.X = Tf
            newPoint.Y = get_rho(Tf) * (xp * k_p.Replace_X(Tf) / rho_p.Replace_X(Tf) + xf * k_f.Replace_X(Tf) / rho_f.Replace_X(Tf) +
                            +xc * k_c.Replace_X(Tf) / rho_c.Replace_X(Tf) + xa * k_a.Replace_X(Tf) / rho_a.Replace_X(Tf) +
                            +xw * k_w.Replace_X(Tf) / rho_w.Replace_X(Tf))
            k.Add(newPoint)

            For i = 1 To nPoints
                Tc = i * (MaxTemperature - Tf) / nPoints + Tf
                newPoint.X = Tc
                newPoint.Y = get_rho(Tc) * (xp * k_p.Replace_X(Tc) / rho_p.Replace_X(Tc) + xf * k_f.Replace_X(Tc) / rho_f.Replace_X(Tc) +
                            +xc * k_c.Replace_X(Tc) / rho_c.Replace_X(Tc) + xa * k_a.Replace_X(Tc) / rho_a.Replace_X(Tc) +
                            +xw * k_w.Replace_X(Tc) / rho_w.Replace_X(Tc))
                k.Add(newPoint)
            Next

            FitCoeffs_k_unfrozen = FindPolynomialLeastSquaresFit(k, 3)


            '================FROZEN PART 1================

            nPoints = 1000
            k.Clear()
            For i = 1 To nPoints
                Tc = (i - 1) * (Tf - MidTemperature) / nPoints + MidTemperature
                xi = (xw - 0.4 * xp) * (1 - (Tf / Tc))
                newPoint.X = Tc
                newPoint.Y = get_rho(Tc) * (xp * k_p.Replace_X(Tc) / rho_p.Replace_X(Tc) + xf * k_f.Replace_X(Tc) / rho_f.Replace_X(Tc) +
                            +xc * k_c.Replace_X(Tc) / rho_c.Replace_X(Tc) + xa * k_a.Replace_X(Tc) / rho_a.Replace_X(Tc) +
                            +xi * k_i.Replace_X(Tc) / rho_i.Replace_X(Tc) + xw * k_w.Replace_X(Tc) / rho_w.Replace_X(Tc))
                k.Add(newPoint)
            Next
            newPoint.X = Tf
            newPoint.Y = get_rho(Tc) * (xp * k_p.Replace_X(Tc) / rho_p.Replace_X(Tc) + xf * k_f.Replace_X(Tc) / rho_f.Replace_X(Tc) +
                            +xc * k_c.Replace_X(Tc) / rho_c.Replace_X(Tc) + xa * k_a.Replace_X(Tc) / rho_a.Replace_X(Tc) +
                            +xi * k_i.Replace_X(Tc) / rho_i.Replace_X(Tc) + xw * k_w.Replace_X(Tc) / rho_w.Replace_X(Tc))
            k.Add(newPoint)


            FitCoeffs_k_frozen1 = FindPolynomialLeastSquaresFit(k, 10)


            '================FROZEN PART 2================
            nPoints = 1000
            k.Clear()
            For i = 1 To nPoints - 1
                Tc = (i - 1) * (MidTemperature - MinTemperature) / nPoints + MinTemperature
                xi = (xw - 0.4 * xp) * (1 - (Tf / Tc))
                newPoint.X = Tc
                newPoint.Y = get_rho(Tc) * (xp * k_p.Replace_X(Tc) / rho_p.Replace_X(Tc) + xf * k_f.Replace_X(Tc) / rho_f.Replace_X(Tc) +
                            +xc * k_c.Replace_X(Tc) / rho_c.Replace_X(Tc) + xa * k_a.Replace_X(Tc) / rho_a.Replace_X(Tc) +
                            +xi * k_i.Replace_X(Tc) / rho_i.Replace_X(Tc) + xw * k_w.Replace_X(Tc) / rho_w.Replace_X(Tc))
                k.Add(newPoint)
            Next

            FitCoeffs_k_frozen2 = FindPolynomialLeastSquaresFit(k, 10)
        End Sub
        Public Function get_k(T As Double) As Double
            'Returns the value of k(T)

            If Initialized Then
                If T > FoodModelUsed.FreezingTemp Then
                    get_k = ReplaceT(T, FitCoeffs_k_unfrozen)
                ElseIf T > MidTemperature Then
                    get_k = ReplaceT(T, FitCoeffs_k_frozen1)
                Else
                    get_k = ReplaceT(T, FitCoeffs_k_frozen2)
                End If
            Else
                get_k = 0
            End If
        End Function

        Private Sub Init_cp()
            'This fills up the polynomial fit coefficients for the specific heat variable
            'The polynomial fit coefficients for the thermal conductivity of the components are as shown below: 
            Dim cp_p As New Poly({2008.2, 1.2089, -0.0013129})
            Dim cp_f As New Poly({1984.2, 1.4733, -0.0000048008})
            Dim cp_c As New Poly({1548.8, 1.9625, 0.0059399})
            Dim cp_a As New Poly({0.32962, 0.0014011, -0.0000029069})
            Dim cp_w As New Poly({4128.9, -0.090864, 0.0054731})
            Dim cp_i As New Poly({2062.3, -6.0769})

            Dim xp As Double
            Dim xf As Double
            Dim xc As Double
            Dim xa As Double
            Dim xi As Double
            Dim xw As Double
            Dim Tf As Double

            With FoodModelUsed
                xp = .ProteinContent
                xf = .FatContent
                xc = .CarbContent
                xa = .AshContent
                xw = .WaterContent
                Tf = .FreezingTemp
            End With


            '================UNFROZEN================
            Dim cp As New List(Of PointF)
            Dim newPoint As PointF
            Dim nPoints As Integer = 25
            Dim Tc As Double
            Dim i As Long

            newPoint.X = Tf
            newPoint.Y = xp * cp_p.Replace_X(Tf) + xf * cp_f.Replace_X(Tf) + xc * cp_c.Replace_X(Tf) + xa * cp_a.Replace_X(Tf) + xw * cp_w.Replace_X(Tf)
            cp.Add(newPoint)

            For i = 1 To nPoints
                Tc = i * (MaxTemperature - Tf) / nPoints + Tf
                newPoint.X = Tc
                newPoint.Y = xp * cp_p.Replace_X(Tc) + xf * cp_f.Replace_X(Tc) + xc * cp_c.Replace_X(Tc) + xa * cp_a.Replace_X(Tc) + xw * cp_w.Replace_X(Tc)
                cp.Add(newPoint)
            Next

            FitCoeffs_cp_unfrozen = FindPolynomialLeastSquaresFit(cp, 3)
            'Dim Errore As Double = ErrorSquared(cp, FitCoeffs_cp_unfrozen)

            '================FROZEN PART 1================
            nPoints = 1000
            cp.Clear()
            For i = 1 To nPoints
                Tc = (i - 1) * (Tf - MidTemperature) / nPoints + MidTemperature
                newPoint.X = Tc
                newPoint.Y = 1550 + 1260 * (1 - xw) - 333600 * Tf * (xw - 0.4 * xp) / (Tc * Tc)
                cp.Add(newPoint)
            Next

            FitCoeffs_cp_frozen1 = FindPolynomialLeastSquaresFit(cp, 10)
            'Errore = ErrorSquared(cp, FitCoeffs_cp_frozen1)

            '================FROZEN PART 2================
            nPoints = 1000
            cp.Clear()
            For i = 1 To nPoints - 1
                Tc = (i - 1) * (MidTemperature - MinTemperature) / nPoints + MinTemperature
                xi = (xw - 0.4 * xp) * (1 - (Tf / Tc))
                newPoint.X = Tc
                newPoint.Y = 1550 + 1260 * (1 - xw) - 333600 * Tf * (xw - 0.4 * xp) / (Tc * Tc)
                cp.Add(newPoint)
            Next

            FitCoeffs_cp_frozen2 = FindPolynomialLeastSquaresFit(cp, 10)
            'Errore = ErrorSquared(cp, FitCoeffs_cp_frozen2)

        End Sub
        Public Function get_cp(T As Double) As Double
            'Returns the value of cp(T)

            If Initialized Then
                If T > FoodModelUsed.FreezingTemp Then
                    get_cp = ReplaceT(T, FitCoeffs_cp_unfrozen)
                ElseIf T > MidTemperature Then
                    get_cp = ReplaceT(T, FitCoeffs_cp_frozen1)
                Else
                    get_cp = ReplaceT(T, FitCoeffs_cp_frozen2)
                End If
            Else
                get_cp = 0
            End If
        End Function

        Private Sub Init_alpha()
            'This fills up the polynomial fit coefficients for the thermal diffusivity

            '================UNFROZEN================
            Dim alpha As New List(Of PointF)
            Dim newPoint As PointF
            Dim nPoints As Integer = 25
            Dim Tc As Double
            Dim i As Long
            Dim Tf As Double = FoodModelUsed.FreezingTemp

            newPoint.X = Tf + 0.01
            newPoint.Y = get_k(Tf + 0.01) / (get_rho(Tf + 0.01) * get_cp(Tf + 0.01))
            alpha.Add(newPoint)

            For i = 1 To nPoints
                Tc = i * (MaxTemperature - Tf) / nPoints + Tf
                newPoint.X = Tc
                newPoint.Y = get_k(Tc) / (get_rho(Tc) * get_cp(Tc))
                alpha.Add(newPoint)
            Next

            FitCoeffs_alpha_unfrozen = FindPolynomialLeastSquaresFit(alpha, 3)
            'Dim Errore As Double = ErrorSquared(alpha, FitCoeffs_alpha_unfrozen)

            '================FROZEN PART 1================
            nPoints = 1000
            alpha.Clear()
            For i = 1 To nPoints
                Tc = (i - 1) * (Tf - MidTemperature) / nPoints + MidTemperature
                newPoint.X = Tc
                newPoint.Y = Math.Log10(get_k(Tc) / (get_rho(Tc) * get_cp(Tc)))
                alpha.Add(newPoint)
            Next
            Tc = Tf
            newPoint.X = Tc
            newPoint.Y = Math.Log10(get_k(Tc) / (get_rho(Tc) * get_cp(Tc)))
            alpha.Add(newPoint)

            FitCoeffs_logalpha_frozen1 = FindPolynomialLeastSquaresFit(alpha, 10)
            'Errore = ErrorSquared(alpha, FitCoeffs_logalpha_frozen1)

            '================FROZEN PART 2================
            nPoints = 1000
            alpha.Clear()
            For i = 1 To nPoints - 1
                Tc = (i - 1) * (MidTemperature - MinTemperature) / nPoints + MinTemperature
                newPoint.X = Tc
                newPoint.Y = Math.Log10(get_k(Tc) / (get_rho(Tc) * get_cp(Tc)))
                alpha.Add(newPoint)
            Next

            FitCoeffs_logalpha_frozen2 = FindPolynomialLeastSquaresFit(alpha, 10)
            'Errore = ErrorSquared(alpha, FitCoeffs_logalpha_frozen2)

        End Sub
        Public Function get_alpha(T As Double) As Double
            'Returns the value of cp(T)

            If Initialized Then
                If T > FoodModelUsed.FreezingTemp Then
                    get_alpha = ReplaceT(T, FitCoeffs_alpha_unfrozen)
                ElseIf T > MidTemperature Then
                    get_alpha = Math.Pow(10, ReplaceT(T, FitCoeffs_logalpha_frozen1))
                Else
                    get_alpha = Math.Pow(10, ReplaceT(T, FitCoeffs_logalpha_frozen2))
                End If
            Else
                get_alpha = 0
            End If
        End Function

        Private Sub Init_H()
            'This fills up the polynomial fit coefficients for the specific heat variable
            'The polynomial fit coefficients for the thermal conductivity of the components are as shown below: 
            Dim cp_p As New Poly({2008.2, 1.2089, -0.0013129})
            Dim cp_f As New Poly({1984.2, 1.4733, -0.0000048008})
            Dim cp_c As New Poly({1548.8, 1.9625, 0.0059399})
            Dim cp_a As New Poly({0.32962, 0.0014011, -0.0000029069})
            Dim cp_w As New Poly({4128.9, -0.090864, 0.0054731})
            Dim cp_i As New Poly({2062.3, -6.0769})

            Dim xp As Double
            Dim xf As Double
            Dim xc As Double
            Dim xa As Double
            Dim xi As Double
            Dim xw As Double
            Dim Tf As Double

            With FoodModelUsed
                xp = .ProteinContent
                xf = .FatContent
                xc = .CarbContent
                xa = .AshContent
                xw = .WaterContent
                Tf = .FreezingTemp
            End With

            '================FROZEN PART 2================
            Dim H As New List(Of PointF)
            Dim newPoint As PointF
            Dim nPoints As Integer
            Dim Tc As Double
            Dim i As Long
            Dim H_Accum As Double = 0
            Dim cp As Double

            nPoints = 1000
            H.Clear()
            For i = 1 To nPoints - 1
                Tc = (i - 1) * (MidTemperature - MinTemperature) / nPoints + MinTemperature
                xi = (xw - 0.4 * xp) * (1 - (Tf / Tc))
                newPoint.X = Tc
                cp = 1550 + 1260 * (1 - xw) - 333600 * Tf * (xw - 0.4 * xp) / (Tc * Tc)
                H_Accum += cp * (MidTemperature - MinTemperature) / nPoints
                newPoint.Y = H_Accum

                H.Add(newPoint)
            Next

            FitCoeffs_H_frozen2 = FindPolynomialLeastSquaresFit(H, 10)
            'Errore = ErrorSquared(H, FitCoeffs_H_frozen2)

            '================FROZEN PART 1================
            nPoints = 1000
            H.Clear()
            For i = 1 To nPoints - 1
                Tc = i * (Tf - MidTemperature) / nPoints + MidTemperature
                newPoint.X = Tc
                cp = 1550 + 1260 * (1 - xw) - 333600 * Tf * (xw - 0.4 * xp) / (Tc * Tc)
                H_Accum += cp * (Tf - MidTemperature) / nPoints
                newPoint.Y = H_Accum

                H.Add(newPoint)
            Next

            FitCoeffs_H_frozen1 = FindPolynomialLeastSquaresFit(H, 10)
            'Errore = ErrorSquared(H, FitCoeffs_H_frozen1)

            '================UNFROZEN================

            H.Clear()
            nPoints = 25
            newPoint.X = Tf
            cp = xp * cp_p.Replace_X(Tf) + xf * cp_f.Replace_X(Tf) + xc * cp_c.Replace_X(Tf) + xa * cp_a.Replace_X(Tf) + xw * cp_w.Replace_X(Tf)
            H_Accum += cp * (Tf - MidTemperature) / nPoints
            newPoint.Y = H_Accum
            H.Add(newPoint)

            For i = 1 To nPoints
                Tc = i * (MaxTemperature - Tf) / nPoints + Tf
                newPoint.X = Tc
                newPoint.Y = xp * cp_p.Replace_X(Tc) + xf * cp_f.Replace_X(Tc) + xc * cp_c.Replace_X(Tc) + xa * cp_a.Replace_X(Tc) + xw * cp_w.Replace_X(Tc)
                H_Accum += cp * (MaxTemperature - Tf) / nPoints
                newPoint.Y = H_Accum

                H.Add(newPoint)
            Next

            FitCoeffs_H_unfrozen = FindPolynomialLeastSquaresFit(H, 3)
            'Errore = ErrorSquared(H, FitCoeffs_H_unfrozen)


        End Sub
        Public Function get_H(T As Double) As Double
            'Returns the value of cp(T)

            If Initialized Then
                If T > FoodModelUsed.FreezingTemp Then
                    get_H = ReplaceT(T, FitCoeffs_H_unfrozen)
                ElseIf T > MidTemperature Then
                    get_H = ReplaceT(T, FitCoeffs_H_frozen1)
                Else
                    get_H = ReplaceT(T, FitCoeffs_H_frozen2)
                End If
            Else
                get_H = 0
            End If
        End Function



        Private Function ReplaceT(T As Double, F As List(Of Double)) As Double
            'Replaces T in F(T) and returns F(T)
            Dim Y As Double = 0
            Dim X As Double = 1
            Dim I As Integer

            For I = 0 To F.Count - 1
                Y = Y + X * F(I)
                X = X * T
            Next
            ReplaceT = Y
        End Function

#Region "Individual Component Properties"
        Private Function Specific_Heat_Component(ComponentType As String, Temperature As Double) As Double
            'Determines the specific heat of a food component (J/Kg.K) according to ASHRAE
            Select Case ComponentType
                Case "Protein"
                    Specific_Heat_Component = 2008.2 + 1.2089 * Temperature - 0.0013129 * Temperature ^ 2
                Case "Fat"
                    Specific_Heat_Component = 1984.2 + 1.4733 * Temperature - 0.0000048008 * Temperature ^ 2
                Case "Carbohydrate"
                    Specific_Heat_Component = 1548.8 + 1.9625 * Temperature - 0.0059399 * Temperature ^ 2
                Case "Ash"
                    Specific_Heat_Component = 1092.6 + 1.8896 * Temperature - 0.0036817 * Temperature ^ 2
                Case "Water"
                    If Temperature < 0 Then
                        Specific_Heat_Component = 4128.9 - 5.3062 * Temperature + 0.99516 * Temperature ^ 2
                    Else
                        Specific_Heat_Component = 4128.9 - 0.090864 * Temperature + 0.0054731 * Temperature ^ 2
                    End If
                Case "Ice"
                    Specific_Heat_Component = 2062.3 - 6.0769 * Temperature
                Case Else
                    Return 0
            End Select
        End Function

        Private Function Density_Component(ComponentType As String, Temperature As Double) As Double
            'Determines the density of a food component (kg/m³) according to ASHRAE
            Select Case ComponentType
                Case "Protein"
                    Density_Component = 1329.9 - 0.5184 * Temperature
                Case "Fat"
                    Density_Component = 925.59 - 0.41757 * Temperature
                Case "Carbohydrate"
                    Density_Component = 1599.1 - 0.31046 * Temperature
                Case "Ash"
                    Density_Component = 2423.8 - 0.28063 * Temperature
                Case "Water"
                    Density_Component = 997.18 + 0.0031439 * Temperature - 0.0037574 * Temperature ^ 2
                Case "Ice"
                    Density_Component = 916.89 - 0.13071 * Temperature
                Case Else
                    Return 0
            End Select
        End Function

        Private Function Thermal_Conductivity_Component(ComponentType As String, Temperature As Double) As Double
            'Determines the thermal conductivity of a food component (W/m.K) according to ASHRAE
            Select Case ComponentType
                Case "Protein"
                    Thermal_Conductivity_Component = 0.17881 + 0.0011958 * Temperature - 0.0000027178 * Temperature ^ 2
                Case "Fat"
                    Thermal_Conductivity_Component = 0.18071 - 0.00027604 * Temperature - 0.00000017749 * Temperature ^ 2
                Case "Carbohydrate"
                    Thermal_Conductivity_Component = 0.20141 + 0.0013874 * Temperature - 0.0000043312 * Temperature ^ 2
                Case "Ash"
                    Thermal_Conductivity_Component = 0.32962 + 0.0014011 * Temperature - 0.0000029069 * Temperature ^ 2
                Case "Water"
                    Thermal_Conductivity_Component = 0.57109 + 0.0017625 * Temperature - 0.0000067036 * Temperature ^ 2
                Case "Ice"
                    Thermal_Conductivity_Component = 2.2196 - 0.0062489 * Temperature + 0.00010154 * Temperature ^ 2
                Case Else
                    Return 0
            End Select
        End Function
#End Region


    End Class
End Module
