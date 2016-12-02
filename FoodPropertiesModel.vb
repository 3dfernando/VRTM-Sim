Module FoodPropertiesModel
    Public Class FoodProperties
        'This class models the food properties model according to what is described in Chapter 9 of the ASHRAE refrigeration handbook.
        'Uses Choi and Okos models for food properties and Schwartzbert specific heat model
        'The model is code-lengthy, but an effort was made to reduce mathemathical operations (and computational cost) on the extraction of the food properties as a function of temperature
        Public FoodModelUsed As FoodPropertiesListItem 'Stores the food model properties raw data (%fat, etc)

        Private Initialized As Boolean = False 'Flag that says whether the model has already been initialized. This will allow the various property functions to use the quicker piece-wise functions to return values
        Private TemperatureBounds(8) As Double 'Stores the temperature bounds of the piecewise function fits - It is going to be programmed EXACTLY 8 BOUNDS as the curve fit is good enough and the if-else statements reduce to a minimum
        Private PolynomialCoeffs_k(4, 8) As Double 'Stores the polynomial coefficients for thermal conductivity of this product
        Private PolynomialCoeffs_rho(4, 8) As Double 'Stores the polynomial coefficients for the density of this product
        Private PolynomialCoeffs_cp(4, 8) As Double 'Stores the polynomial coefficients for specific heat of this product
        Private PolynomialCoeffs_alpha(4, 8) As Double 'Stores the polynomial coefficients for thermal diffusivity of this product
        Private PolynomialCoeffs_H(4, 8) As Double 'Stores the polynomial coefficients for enthalpy of this product

        Public Sub New()
            Initialized = False
        End Sub

        Public Sub New(FoodModel As FoodPropertiesListItem, initializeVariables As Boolean)
            FoodModelUsed = FoodModel
            If initializeVariables Then Initialize()
        End Sub

        Public Sub Initialize()
            '--------Initializes the food properties model and fills up the important variable arrays--------
            'Inits the temperature points of interest
            TemperatureBounds(0) = -50
            TemperatureBounds(1) = FoodModelUsed.FreezingTemp - (50 + FoodModelUsed.FreezingTemp) / 2
            TemperatureBounds(2) = FoodModelUsed.FreezingTemp - (50 + FoodModelUsed.FreezingTemp) / 4
            TemperatureBounds(3) = FoodModelUsed.FreezingTemp - (50 + FoodModelUsed.FreezingTemp) / 8
            TemperatureBounds(4) = FoodModelUsed.FreezingTemp - (50 + FoodModelUsed.FreezingTemp) / 16
            TemperatureBounds(5) = FoodModelUsed.FreezingTemp - (50 + FoodModelUsed.FreezingTemp) / 32
            TemperatureBounds(6) = FoodModelUsed.FreezingTemp - (50 + FoodModelUsed.FreezingTemp) / 64
            TemperatureBounds(7) = FoodModelUsed.FreezingTemp
            TemperatureBounds(8) = 50

            'Populates an array with an even amount of points between these bounds
            Dim NPoints As Integer = 100
            Dim I, J As Integer
            Dim T(,) As Double
            ReDim T(7, NPoints - 1)

            For I = 0 To 7 '8 points makes to 7 regions
                For J = 0 To NPoints - 1
                    T(I, J) = TemperatureBounds(I) + (TemperatureBounds(I + 1) - TemperatureBounds(I)) * J / (NPoints - 1)
                Next
                T(I, NPoints - 1) = TemperatureBounds(I + 1)
            Next

            'Calculates the various properties based on the temperatures set
            Dim rho(,) As Double
            Dim cp(,) As Double
            Dim k(,) As Double
            Dim alpha(,) As Double
            ReDim rho(7, NPoints - 1)
            ReDim cp(7, NPoints - 1)
            ReDim k(7, NPoints - 1)
            ReDim alpha(7, NPoints - 1)

            For I = 0 To 7
                For J = 0 To NPoints - 1
                    T(I, J) = 1
                Next
            Next





            Initialized = True
        End Sub



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
