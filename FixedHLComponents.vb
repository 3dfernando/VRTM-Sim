Public Class FixedHLComponents
    Private Sub FixedHLComponents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initializes the heat load data
        txtHeight.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.Height))
        txtWidth.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.Width))
        txtLength.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.Length))
        txtOuterT.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.OutsideT))
        txtWallMaterial.SelectedIndex = VRTM_SimVariables.FixedHeatLoadData.WallMaterialIdx
        txtWallThickness.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.WallThickness))

        txtTotalMotorPower.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.MotorPower))
        txtHoursMotor.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.MotorHours))
        txtIllumination.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.IllumPowerArea))
        txtHoursIllum.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.IllumHours))
        txtVolChanges.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.DailyVolumeChange))

        txtConductionPower.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.ConductionPower))
        txtEquipmentPower.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.EquipPower))
        txtInfiltrationPower.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.InfiltrPower))

        txtFixedHeatLoad.Text = Trim(Str(VRTM_SimVariables.FixedHeatLoadData.FixedHL))

        'Does calculations before initializing
        txtInnerT.Text = Trim(Str(VRTM_SimVariables.AssumedDTForPreviews + VRTM_SimVariables.Tevap_Setpoint))

        UpdateTotalPower()

    End Sub

#Region "Power Update"
    Private Sub GetConductionPower()
        'Calculates the power loss due to conduction through the walls
        Dim InsulantThermalConductivity As Double 'W/m.K
        If txtWallMaterial.SelectedIndex = 0 Then
            InsulantThermalConductivity = 0.02
        Else
            InsulantThermalConductivity = 0.04
        End If

        Dim SurfArea As Double = 2 * (VRTM_SimVariables.FixedHeatLoadData.Height * VRTM_SimVariables.FixedHeatLoadData.Width +
                                      VRTM_SimVariables.FixedHeatLoadData.Length * VRTM_SimVariables.FixedHeatLoadData.Width +
                                      VRTM_SimVariables.FixedHeatLoadData.Height * VRTM_SimVariables.FixedHeatLoadData.Length) / 1000000 'm²

        Dim DT As Double = VRTM_SimVariables.FixedHeatLoadData.OutsideT - (VRTM_SimVariables.AssumedDTForPreviews + VRTM_SimVariables.Tevap_Setpoint)

        VRTM_SimVariables.FixedHeatLoadData.ConductionPower = (InsulantThermalConductivity / (0.001 * VRTM_SimVariables.FixedHeatLoadData.WallThickness)) * SurfArea * DT / 1000 'kW

        txtConductionPower.Text = Trim(Str(Round(VRTM_SimVariables.FixedHeatLoadData.ConductionPower, 2)))
    End Sub

    Private Sub GetEquipmentPower()
        'Calculates the heat load related to the equipment
        Dim AvgMotorPower As Double = VRTM_SimVariables.FixedHeatLoadData.MotorPower * VRTM_SimVariables.FixedHeatLoadData.MotorHours / 24

        Dim IllumArea As Double = VRTM_SimVariables.FixedHeatLoadData.Length * VRTM_SimVariables.FixedHeatLoadData.Width / 1000000

        Dim IllumPower As Double = IllumArea * VRTM_SimVariables.FixedHeatLoadData.IllumPowerArea * VRTM_SimVariables.FixedHeatLoadData.IllumHours / 24

        VRTM_SimVariables.FixedHeatLoadData.EquipPower = AvgMotorPower + IllumPower / 1000
        txtEquipmentPower.Text = Trim(Str(Round(VRTM_SimVariables.FixedHeatLoadData.EquipPower, 2)))
    End Sub

    Private Sub GetAirInfiltrationPower()
        'Calculates the heat load related to the air infiltration
        Dim V As Double = VRTM_SimVariables.FixedHeatLoadData.Height * VRTM_SimVariables.FixedHeatLoadData.Width * VRTM_SimVariables.FixedHeatLoadData.Length / 1000000000.0
        Dim RenovNumber As Double = Int((60 / (V ^ (0.5))) * 100) / 100
        txtVolChanges.Text = Trim(Str(RenovNumber))

        Dim U As Double = 0.6 'Assumes outside humidity level as 60%
        Dim Pw As Double
        Dim Tout As Double = VRTM_SimVariables.FixedHeatLoadData.OutsideT + 273.15

        Pw = U * Math.Exp(-5800.2206 / Tout + 1.3914993 - 0.048640239 * Tout + 0.000041764768 * Tout ^ 2 - 0.000000014452093 * Tout ^ 3 + 6.5459673 * Math.Log(Tout))

        Dim Ws As Double = 0.621945 * (Pw / (103000 - Pw)) 'kg H2O/kg air

        Dim rho As Double = 1.2

        Dim m_air As Double = (V * rho) * RenovNumber / (24 * 3600) 'kg/s
        Dim m_water As Double = Ws * m_air 'kg/s

        Dim DT As Double = VRTM_SimVariables.FixedHeatLoadData.OutsideT - (VRTM_SimVariables.AssumedDTForPreviews + VRTM_SimVariables.Tevap_Setpoint)
        Dim DH_H2O As Double = 333600 'J/kg
        Dim cp_air As Double = 1000 'J/kg.K

        VRTM_SimVariables.FixedHeatLoadData.InfiltrPower = (m_air * cp_air * DT + m_water * DH_H2O) / 1000
        txtInfiltrationPower.Text = Trim(Str(Round(VRTM_SimVariables.FixedHeatLoadData.InfiltrPower, 2)))

    End Sub

    Public Sub UpdateTotalPower()
        GetConductionPower()
        GetEquipmentPower()
        GetAirInfiltrationPower()

        VRTM_SimVariables.FixedHeatLoadData.FixedHL = VRTM_SimVariables.FixedHeatLoadData.ConductionPower + VRTM_SimVariables.FixedHeatLoadData.EquipPower + VRTM_SimVariables.FixedHeatLoadData.InfiltrPower
        txtFixedHeatLoad.Text = Trim(Str(Round(VRTM_SimVariables.FixedHeatLoadData.FixedHL, 2)))
    End Sub
#End Region

#Region "Validations"
    Private Sub Validate_Positive(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtHeight.Validating, txtWidth.Validating, txtLength.Validating, txtLength.Validating, txtOuterT.Validating, txtTotalMotorPower.Validating,
        txtHoursMotor.Validating, txtHoursIllum.Validating, txtIllumination.Validating, txtWallThickness.Validating
        'Validates several textboxes that have a numeric input
        If Not (IsNumeric(sender.Text) And Val(sender.text) > 0) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A numeric value must be provided.")
        End If
    End Sub

    Private Sub Validated_Textbox(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtHeight.Validated, txtWidth.Validated, txtLength.Validated, txtLength.Validated, txtOuterT.Validated, txtTotalMotorPower.Validated,
        txtHoursMotor.Validated, txtHoursIllum.Validated, txtIllumination.Validated, txtWallThickness.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        VRTM_SimVariables.FixedHeatLoadData.Height = Val(txtHeight.Text)
        VRTM_SimVariables.FixedHeatLoadData.Length = Val(txtLength.Text)
        VRTM_SimVariables.FixedHeatLoadData.Width = Val(txtWidth.Text)

        VRTM_SimVariables.FixedHeatLoadData.OutsideT = Val(txtOuterT.Text)
        VRTM_SimVariables.FixedHeatLoadData.WallMaterialIdx = txtWallMaterial.SelectedIndex
        VRTM_SimVariables.FixedHeatLoadData.WallThickness = Val(txtWallThickness.Text)

        VRTM_SimVariables.FixedHeatLoadData.MotorPower = Val(txtTotalMotorPower.Text)
        VRTM_SimVariables.FixedHeatLoadData.MotorHours = Val(txtHoursMotor.Text)
        VRTM_SimVariables.FixedHeatLoadData.IllumPowerArea = Val(txtIllumination.Text)
        VRTM_SimVariables.FixedHeatLoadData.IllumHours = Val(txtHoursIllum.Text)

        UpdateTotalPower()
    End Sub
    Private Sub WallIndexChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWallMaterial.SelectedIndexChanged
        VRTM_SimVariables.FixedHeatLoadData.WallMaterialIdx = txtWallMaterial.SelectedIndex
        UpdateTotalPower()
    End Sub

#End Region

End Class