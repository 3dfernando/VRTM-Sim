Module Crank_Nicolson
    'This module implements the FDM Crank-Nicolson heat diffusion equation solver for a 1D geometry (thin slab, long cylinder or sphere). 
    'It will solve for a variable-property material modeled herein as a food during freezing process (alpha and k vary within orders of magnitude during the process).

    Public Sub Solve_Crank_Nicolson_OneProduct(L As Double, nx As Long, t_total As Double, nt As Long,
                                                    T_Initial As Double, h As Double, T_fluid As Double,
                                                    Geometry As String, Product As FoodProperties,
                                                    ByRef t_Simulation As Double(), ByRef T_Profile_Surf As Double(),
                                                    ByRef T_Profile_Center As Double(), ByRef DeltaH As Double)
        'This will solve a transient heat conduction for one product. The return values (Variables with ByRef declares) are the center and surface temperature profiles.
        'This code will do a strict case of the Next_Timestep function, which is the 1D product with symmetric boundary conditions of convection 
        'Variables used:
        'L is the total product thickness [m] (or diameter for cylindrical cases). For a thin slab, then, the thickness used will be half as much as one of the boundaries is isolated.
        'nx is the number of grid divisions in the x direction
        't_total is the total simulation time [s]
        'nt is the number of grid divisions in time
        'T_Initial is the uniform temperature [ºC] the product begins at
        'h is the convection coefficient [W/m².K] calculated (after applying the multiplier).
        'T_fluid is the temperature of the fluid [ºC] for convection.
        'Geometry is a string that Parses "Thin Slab", "Long Cylinder" or "Sphere" and defines the dimensionality of the problem
        'Product will define the property model to be used.
        '---Return arrays---
        't_Simulation [s] returns the simulation time for graphing
        'T_Profile_Surf [ºC] is the resulting surface temperature profile
        'T_Profile_Center [ºC] is the resulting center temperature profile

        ReDim t_Simulation(nt - 1)
        ReDim T_Profile_Surf(nt - 1)
        ReDim T_Profile_Center(nt - 1)

        Dim TProfile() As Double
        ReDim TProfile(nx - 1)

        Dim i As Long
        'Fills up the initial temperature profile
        For i = 0 To nx - 1
            TProfile(i) = T_Initial
        Next

        Dim E As Long
        'Defines the geometry exponent
        If Geometry.ToLower = "thin slab" Then
            E = 0
        ElseIf Geometry.ToLower = "long cylinder" Then
            E = 1
        ElseIf Geometry.ToLower = "sphere" Then
            E = 2
        End If


        'Loops through the timesteps
        Dim dx As Double = L / (2 * (nx - 1))
        Dim dt As Double = t_total / (nt - 1)

        t_Simulation(0) = 0
        T_Profile_Center(0) = TProfile(0)
        T_Profile_Surf(0) = TProfile(nx - 1)

        For i = 1 To nt - 1
            t_Simulation(i) = (i / (nt - 1)) * t_total
            TProfile = Next_Timestep(TProfile, dx, dt, Boundary.Neumann, 0, 0, 0, Boundary.Robin, T_fluid, h, 0, E, Product)
            T_Profile_Surf(i) = TProfile(nx - 1)
            T_Profile_Center(i) = TProfile(0)
        Next

        'Integrates the enthalpy differential
        Dim H_init As Double
        Dim H_end As Double = 0

        H_init = Product.get_H(T_Initial)
        For i = 0 To nx - 1
            H_end += Product.get_H(TProfile(i))
        Next
        H_end = H_end / nx
        DeltaH = H_init - H_end

    End Sub

    Public Function Next_Timestep(Prev_Timestep As Double(), dx As Double, dt As Double,
                                  Boundary_Type_1 As Boundary, T_Boundary_1 As Double, h_Boundary_1 As Double, q_Boundary_1 As Double,
                                  Boundary_Type_2 As Boundary, T_Boundary_2 As Double, h_Boundary_2 As Double, q_Boundary_2 As Double,
                                  Geometry_Exponent As Long, Product As FoodProperties) As Double()
        'Implements the crank-nicolson solver and executes the integration of one single timestep.
        'The equation solved is as follows:
        '(1/k)*(1/x^n)*d(k*x^n)/dx*dT/dx + d²T/dx²=(1/alpha)*dTdt
        'The input variables are as follow:
        'Prev_Timestep is a list of temperatures T [ºC] from the previous time step. To give initial conditions just pass an arbitrary list of the initial temperature profile (can be constant)
        'dx is the grid spacing in x direction.
        'dt is the time difference between time steps.
        'Boundary_Type_1 and _2 is the boundary type according to the Boundary Enum, and implements the way the calculation is carried on
        'T_Boundary_1 and _2 implements the temperature [ºC] fixed at the boundary (Dirichlet) or at the convection fluid (Robin). It's not used in Neumann BC.
        'h_Boundary_1 and _2 implements the convection coeff. [W/m².K] only for the Robin BC. It's ignored for Neumann and Dirichlet.
        'q_Boundary_1 and _2 are the heat flux [W/m²] for the Neumann BC. It's ignored for Dirichlet and Robin.
        'Geometry_Exponent will give the spatial coordinate system to be used. 0 is cartesian, 1 is cylindrical and 2 is spherical.

        'Verifies whether the previous timestep is large enough in size to perform a calculation (minimum 4 grid points)
        Dim n As Long
        n = UBound(Prev_Timestep) + 1
        If n < 3 Then Return Nothing

        Dim Diag_Lower() As Double
        Dim Diag_Main() As Double
        Dim Diag_Upper() As Double
        Dim Constants() As Double
        Dim k() As Double
        Dim i As Integer

        ReDim Diag_Lower(n - 1)
        ReDim Diag_Main(n - 1)
        ReDim Diag_Upper(n - 1)
        ReDim Constants(n - 1)
        ReDim k(n - 1)

        'Fills up the k array as it's heavily used
        For i = 0 To (n - 1)
            k(i) = Product.get_k(Prev_Timestep(i))
        Next

        '----Boundary 1----
        If Boundary_Type_1 = Boundary.Dirichlet Then
            Diag_Lower(0) = 0 'It doesn't matter as it won't be used in the tridiag solver
            Diag_Main(0) = 1
            Diag_Upper(0) = 0
            Constants(0) = T_Boundary_1
        ElseIf Boundary_Type_1 = Boundary.Neumann Then
            Diag_Lower(0) = 0 'It doesn't matter as it won't be used in the tridiag solver
            Diag_Main(0) = 1
            Diag_Upper(0) = -1
            Constants(0) = -q_Boundary_1 * dx / k(0)
        ElseIf Boundary_Type_1 = Boundary.Robin Then
            Diag_Lower(0) = 0 'It doesn't matter as it won't be used in the tridiag solver
            Diag_Main(0) = h_Boundary_1 * dx / k(0) + 1
            Diag_Upper(0) = -1
            Constants(0) = (h_Boundary_1 * dx / k(0)) * T_Boundary_1
        Else
            Return Nothing
        End If
        '----Boundary 2----
        If Boundary_Type_2 = Boundary.Dirichlet Then
            Diag_Lower(n - 1) = 0
            Diag_Main(n - 1) = 1
            Diag_Upper(n - 1) = 0  'It doesn't matter as it won't be used in the tridiag solver
            Constants(n - 1) = T_Boundary_2
        ElseIf Boundary_Type_2 = Boundary.Neumann Then
            Diag_Lower(n - 1) = 1
            Diag_Main(n - 1) = -1
            Diag_Upper(n - 1) = 0 'It doesn't matter as it won't be used in the tridiag solver
            Constants(n - 1) = q_Boundary_2 * dx / k(n - 1)
        ElseIf Boundary_Type_2 = Boundary.Robin Then
            Diag_Lower(n - 1) = -1
            Diag_Main(n - 1) = h_Boundary_2 * dx / k(n - 1) + 1
            Diag_Upper(n - 1) = 0 'It doesn't matter as it won't be used in the tridiag solver
            Constants(n - 1) = (h_Boundary_2 * dx / k(n - 1)) * T_Boundary_2
        Else
            Return Nothing
        End If

        Dim Lambda As Double
        Dim Alpha As Double

        Dim X As Double
        Dim X1 As Double
        Dim X2 As Double
        Dim dkdx_Term As Double
        Dim Omega As Double

        '----Inner terms of array----
        For i = 1 To (n - 2)
            Alpha = Product.get_alpha(Prev_Timestep(i))
            Lambda = Alpha * dt / (dx ^ 2)

            'Calculates the dkdx term
            X = (i + 1) * dx 'Current grid point
            X1 = (i + 2) * dx 'Grid point outwards to boundary 2
            X2 = i * dx 'Grid point inwards to boundary 1

            'Although the original equation was as shown below, it's cheaper computationally to use an if statement:
            'dkdx_Term = (1 / (X ^ Geometry_Exponent)) * ((k(i + 2) * (X1 ^ Geometry_Exponent) - k(i) * (X2 ^ Geometry_Exponent)) / (2 * dx))
            If Geometry_Exponent = 0 Then
                dkdx_Term = (k(i + 1) - k(i - 1)) / (2 * dx)
            ElseIf Geometry_Exponent = 1 Then
                dkdx_Term = (1 / X) * ((k(i + 1) * X1 - k(i - 1) * X2) / (2 * dx))
            ElseIf Geometry_Exponent = 2 Then
                dkdx_Term = (1 / (X * X)) * ((k(i + 1) * (X1 * X1) - k(i - 1) * (X2 * X2)) / (2 * dx))
            End If

            Omega = dx * dkdx_Term / k(i)

            Diag_Lower(i) = (-Lambda) * (2 - Omega) 'Corresponds to A[i-1,i]
            Diag_Main(i) = 4 * (1 + Lambda) 'Corresponds to A[i,i]
            Diag_Upper(i) = (-Lambda) * (2 + Omega) 'Corresponds to A[i+1,i]

            Constants(i) = Prev_Timestep(i - 1) * Lambda * (2 - Omega) + Prev_Timestep(i) * 4 * (1 - Lambda) + Prev_Timestep(i + 1) * Lambda * (2 + Omega)
        Next

        'Solves the tridiagonal system of equations and returns
        Next_Timestep = Solve_Tridiag(Diag_Lower, Diag_Main, Diag_Upper, Constants)

    End Function

    Public Function Geometry_Exponent(Geometry As String) As Long
        'Returns the geometry exponent based on the geometry string
        Select Case Geometry
            Case "Thin Slab"
                Return 0
            Case "Long Cylinder"
                Return 1
            Case "Sphere"
                Return 2
        End Select
    End Function


    Public Enum Boundary As Byte
        'Implements an enumeration of boundary types
        Dirichlet = 0
        Neumann = 1
        Robin = 2
    End Enum
End Module
