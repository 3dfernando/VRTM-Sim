Module RefrigerantProperties
    'Implement refrigerant properties


    Public Class AmmoniaProps
        Private Psat_Coeffs() As Double = {429427.282379096, 16095.7589446082, 234.656270676669, 1.52881198991534, 0.00342542498029734, 0, 0}
        Private rhoL_Coeffs() As Double = {638.322599214679, -1.37131367444832, -0.00170689393728327, -0.00000835271341962248, -0.000000196881947537013, 0, 0}
        Private rhoG_Coeffs() As Double = {3.42841327857248, 0.129654999608608, 0.00180811399213713, 0.00000519914528111534, 0.0000000318010771873753, 0.00000000136050893654763, 0}
        Private hL_Coeffs() As Double = {199649.035969526, 4574.84636464272, 3.39937454718641, 0.0302497686522847, 0, 0, 0}
        Private hG_Coeffs() As Double = {1462297.44154183, 1076.52539674709, -8.50420448751739, -0.0316306756873217, 0.0000810522116733361, -0.000000104587064226681, -0.0000000239867853068053}
        Private cpL_Coeffs() As Double = {4609.06032535243, 5.0665822077501, 0.0585007763767858, 0.00112573186726559, -0.0000138737281622451, -0.0000000883863853442716, 0.00000000247895022322161}
        Private cpG_Coeffs() As Double = {2664.77455205808, 13.9732324146636, 0.171935431244363, 0.00161048083073997, -0.000028680827837339, -0.000000154381678090888, 0.00000000486651053547474}
        Private CpCv_Coeffs() As Double = {1.39359472907807, 0.00194209712347739, 0.0000400112170640761, 0.000000462501140219963, -0.00000000738003769035844, -0.0000000000404070116656342, 0.00000000000127543241704783}
        Private muL_Coeffs() As Double = {0.000168816820380243, -0.00000179020518414826, 0.0000000176915072112678, -0.000000000195616443799576, 0.000000000000913901371651467, 0, 0}
        Private muG_Coeffs() As Double = {0.00000907746048386058, 0.0000000307354890700104, -0.0000000000291116722665958, 0.000000000000105652655967393, 0.0000000000000140728797743433, 0, 0}
        Private kL_Coeffs() As Double = {0.560101005706581, -0.00306047348268866, 0.00000319246715462164, 0, 0, 0, 0}
        Private kG_Coeffs() As Double = {0.0233266175784298, 0.000101001443705477, 0.000000807560684550299, -0.00000000551807604590336, -0.0000000000112473629286096, 0.00000000000139615302176713, 0}

        Public ReadOnly Property Psat(T As Double) As Double
            'Gets the property 
            Get
                Psat = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(Psat_Coeffs) - 1
                    Psat = Psat + T_Exp * Psat_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property rho_L(T As Double) As Double
            'Gets the property 
            Get
                rho_L = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(rhoL_Coeffs) - 1
                    rho_L = rho_L + T_Exp * rhoL_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property rho_G(T As Double) As Double
            'Gets the property 
            Get
                rho_G = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(rhoG_Coeffs) - 1
                    rho_G = rho_G + T_Exp * rhoG_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property h_L(T As Double) As Double
            'Gets the property 
            Get
                h_L = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(hL_Coeffs) - 1
                    h_L = h_L + T_Exp * hL_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property h_G(T As Double) As Double
            'Gets the property 
            Get
                h_G = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(hG_Coeffs) - 1
                    h_G = h_G + T_Exp * hG_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property cp_L(T As Double) As Double
            'Gets the property 
            Get
                cp_L = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(cpL_Coeffs) - 1
                    cp_L = cp_L + T_Exp * cpL_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property cp_G(T As Double) As Double
            'Gets the property 
            Get
                cp_G = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(cpG_Coeffs) - 1
                    cp_G = cp_G + T_Exp * cpG_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property cp_cv_G(T As Double) As Double
            'Gets the property 
            Get
                cp_cv_G = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(CpCv_Coeffs) - 1
                    cp_cv_G = cp_cv_G + T_Exp * CpCv_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property mu_L(T As Double) As Double
            'Gets the property 
            Get
                mu_L = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(muL_Coeffs) - 1
                    mu_L = mu_L + T_Exp * muL_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property mu_G(T As Double) As Double
            'Gets the property 
            Get
                mu_G = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(muG_Coeffs) - 1
                    mu_G = mu_G + T_Exp * muG_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property k_L(T As Double) As Double
            'Gets the property 
            Get
                k_L = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(kL_Coeffs) - 1
                    k_L = k_L + T_Exp * kL_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property

        Public ReadOnly Property k_G(T As Double) As Double
            'Gets the property 
            Get
                k_G = 0
                Dim T_Exp As Double = 1
                For I = 0 To UBound(kG_Coeffs) - 1
                    k_G = k_G + T_Exp * kG_Coeffs(I)
                    T_Exp = T_Exp * T
                Next
            End Get
        End Property
    End Class
End Module
