Module FluidConvection
    'This module tries to model the properties of a non-phase-changing fluid according to some correlations in the literature
    'And, thereafter, calculate the convection coefficients for given boundary conditions

    Public Function Get_H(Geometry As String, Thickness As Double, Width As Double, Length As Double, T_Fluid As Double,
                    Fluid As String, FluidSpeed As Double, ConvMultFactor As Double) As Double
        'Returns the convection coefficient in [W/m².K] based on the classic correlations from Incropera
        'Thickness, Width and Length are given in [mm] to ease input by user
        'T_fluid is given in [ºC], FluidSpeed in [m/s] and the ConvMultFactor is a factor that multiplies the result, dimensionless.
        'The possible values for the string Geometry are "Thin Slab", "Long Cylinder" and "Sphere"

        'First, gets the fluid properties
        Dim k As Double
        Dim rho As Double
        Dim cp As Double
        Dim mu As Double
        Dim Alpha As Double 'Thermal diffusivity, [m²/s]
        Dim v As Double 'Kinematic viscosity, [m²/s]
        Dim Pr As Double 'Prandtl number, [-]

        k = Get_k_fluid(Fluid, T_Fluid)
        rho = Get_rho_fluid(Fluid, T_Fluid)
        cp = Get_cp_fluid(Fluid, T_Fluid)
        mu = Get_mu_fluid(Fluid, T_Fluid)
        Alpha = k / (rho * cp)
        v = mu / rho
        Pr = v / Alpha

        'Then calculates the dimensionless numbers and gets the convection coeff based on geom
        Dim L_Charact As Double
        Dim Re As Double
        Dim Nu As Double
        Dim h As Double

        Select Case Geometry
            Case "Thin Slab"
                L_Charact = Length / 1000
                Re = L_Charact * FluidSpeed / v
                If Re < 500000 Then
                    Nu = 0.664 * (Re ^ 0.5) * (Pr ^ 0.333333)
                Else
                    Nu = 0.0296 * (Re ^ 0.8) * (Pr ^ 0.333333)
                End If
            Case "Long Cylinder"
                L_Charact = Thickness / 1000
                Re = L_Charact * FluidSpeed / v
                If Re < 0.4 Then
                    Nu = 0
                ElseIf Re < 4 Then
                    Nu = 0.989 * (Re ^ 0.33) * (Pr ^ 0.333333)
                ElseIf Re < 40 Then
                    Nu = 0.911 * (Re ^ 0.385) * (Pr ^ 0.333333)
                ElseIf Re < 4000 Then
                    Nu = 0.683 * (Re ^ 0.466) * (Pr ^ 0.333333)
                ElseIf Re < 40000 Then
                    Nu = 0.193 * (Re ^ 0.618) * (Pr ^ 0.333333)
                ElseIf Re < 400000 Then
                    Nu = 0.027 * (Re ^ 0.805) * (Pr ^ 0.333333)
                Else
                    Nu = 0
                End If
            Case "Sphere"
                L_Charact = Thickness / 1000
                Re = L_Charact * FluidSpeed / v
                If (Re > 3.5) And (Re < 80000) And (Pr > 0.7) And (Pr < 380) Then
                    Nu = (2 + 0.4 * (Re ^ 0.5) + 0.06 * (Re ^ 0.666666)) * (Pr ^ 0.4)
                Else
                    Nu = 0
                End If
        End Select

        h = Nu * k / L_Charact 'h in [W/m².K]

        'Returns the convection coefficient multiplied by the factor
        Get_H = h * ConvMultFactor

    End Function


    Public Function Get_k_fluid(Fluid As String, T As Double) As Double
        'This function returns the fluid thermal conductivity in [W/m.K] at atmospheric pressure
        'Based on curve fitting. Fluid is a string to model multiple fluids in the future.
        Select Case Fluid
            Case "Air"
                Get_k_fluid = 0.0240533778865432 + 0.0000782466354180217 * T
            Case "Water"
                Get_k_fluid = -0.00000711011436736763 * (T ^ 2) + 0.00182792301512115 * T + 0.569247547257793
        End Select
    End Function
    Public Function Get_mu_fluid(Fluid As String, T As Double) As Double
        'This function returns the fluid viscosity [kg/m.s] at atmospheric pressure
        'Based on curve fitting. Fluid is a string to model multiple fluids in the future.
        Select Case Fluid
            Case "Air"
                Get_mu_fluid = 0.0000171825345965432 + 0.0000000493207363030714 * T
            Case "Water"
                Get_mu_fluid = -0.00000000245368846094409 * (T ^ 3) + 0.000000553205710186646 * (T ^ 2) - 0.0000454127415232501 * T + 0.00170928263667909
        End Select
    End Function
    Public Function Get_rho_fluid(Fluid As String, T As Double) As Double
        'This function returns the fluid density in [kg/m³] at atmospheric pressure
        'Based on curve fitting. Fluid is a string to model multiple fluids in the future.
        Select Case Fluid
            Case "Air"
                Get_rho_fluid = 1.27583822258315 - 0.00475228691519318 * T + 0.0000176662498279995 * (T ^ 2)
            Case "Water"
                Get_rho_fluid = -0.00346753359255589 * (T ^ 2) - 0.081523449109055 * T + 1000.63458966787
        End Select
    End Function
    Public Function Get_cp_fluid(Fluid As String, T As Double) As Double
        'This function returns the fluid specific heat in [J/kg.K] at atmospheric pressure
        'Based on curve fitting. Fluid is a string to model multiple fluids in the future. 
        Select Case Fluid
            Case "Air"
                Get_cp_fluid = 1008.57666988117 + 0.0111658123080398 * T + 0.000375143668134172 * (T ^ 2)
            Case "Water"
                Get_cp_fluid = -0.0000000706143290722502 * (T ^ 5) + 0.000013827440999955 * (T ^ 4) + 0.0000774335688096721 * (T ^ 3) - 0.158609176779097 * (T ^ 2) + 9.6662653725282 * T + 4060.17993139157
        End Select
    End Function

End Module
