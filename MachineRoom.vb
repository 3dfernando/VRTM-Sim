Imports System.ComponentModel

Public Class MachineRoom
    Private IndexOfProductBeingEdited As Integer = -1

    Private Sub MachineRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loads information from the machine room
        lstCompressor.View = View.Details
        lstCompressor.FullRowSelect = True
        lstCompressor.Columns.Clear()
        lstCompressor.Columns.Add("Compressor", 75)
        lstCompressor.Columns.Add("Qty", 30)
        lstCompressor.Columns.Add("Disp. [m³/h]", 70)
        lstCompressor.Columns.Add("SP Cap'ty [kW]", 90)

        UpdateCompressorList()
        UpdateCompressorsAvailable()

        cmbSelCompressor.SelectedIndex = 0
    End Sub

    Private Sub lstCompressor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCompressor.SelectedIndexChanged
        Dim I As Integer
        If lstCompressor.SelectedItems.Count = 1 Then
            I = lstCompressor.SelectedIndices(0)
            IndexOfProductBeingEdited = I

            cmbSelCompressor.SelectedIndex = VRTM_SimVariables.CompressorSetup(I).SelectedCompressorIndex

            txtQty.Text = Trim(Str(VRTM_SimVariables.CompressorSetup(I).Qty))
            txtVolDisp.Text = Trim(Str(VRTM_SimVariables.CompressorSetup(I).VolumeDisplacement_m3rev))
            txtRPM.Text = Trim(Str(VRTM_SimVariables.CompressorSetup(I).rpm))
            txtVolDispm3h.Text = Trim(Str(VRTM_SimVariables.CompressorSetup(I).VolumeDisplacement_m3h))
            txtVolEff.Text = Trim(Str(VRTM_SimVariables.CompressorSetup(I).VolumeEfficiency * 100))
            txtEstimatedCap.Text = Trim(Str(Round(Get_Compressor_Capacity(VRTM_SimVariables.CompressorSetup(I),
                                                                          VRTM_SimVariables.Tevap_Setpoint), 1)))


            opOneStageNoEco.Checked = False
            opOneStageWithEco.Checked = False
            opTwoStage.Checked = False
            Select Case VRTM_SimVariables.CompressorSetup(I).CompressorType
                Case CompressorSystemInterconnectionType.OneStageNoEco
                    opOneStageNoEco.Checked = True
                Case CompressorSystemInterconnectionType.OneStageEco
                    opOneStageWithEco.Checked = True
                Case CompressorSystemInterconnectionType.TwoStage
                    opTwoStage.Checked = True
            End Select

            txtIntermTemp.Text = Trim(Str(VRTM_SimVariables.CompressorSetup(I).IntermediateT))

        Else
            'Nothing has been selected, so clears the form
            clearForm()
            IndexOfProductBeingEdited = -1
        End If

        ErrorProvider1.Clear()
    End Sub


#Region "Enabling/Disabling controls"
    Private Sub cmbSelCompressor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelCompressor.SelectedIndexChanged
        If cmbSelCompressor.SelectedIndex = 0 Then
            txtVolDisp.Enabled = True
        Else
            txtVolDisp.Enabled = False
            txtVolDisp.Text = Trim(Str(CompressorList(cmbSelCompressor.SelectedIndex - 1).VolumeDisplacement))
        End If
        UpdateCalculations()
    End Sub

    Private Sub OptionChanged(sender As Object, e As EventArgs) Handles opOneStageNoEco.CheckedChanged, opOneStageWithEco.CheckedChanged, opTwoStage.CheckedChanged
        If opOneStageNoEco.Checked Then
            txtIntermTemp.Text = ""
            txtIntermTemp.Enabled = False
        ElseIf opOneStageWithEco.Checked Then
            txtIntermTemp.Enabled = False
            CalculateEconomizerIntermediateTemperature()
        ElseIf opTwoStage.Checked Then
            txtIntermTemp.Enabled = True
            CalculateTwoStageIntermediateTemperature()
        End If
        UpdateCalculations()
    End Sub


#End Region


#Region "Add/Remove"
    Private Sub cmdAddComp_Click(sender As Object, e As EventArgs) Handles cmdAddComp.Click
        'Clears the selection
        If lstCompressor.SelectedItems.Count > 0 Then lstCompressor.SelectedIndices.Clear()
        clearForm()
        IndexOfProductBeingEdited = -1
    End Sub

    Private Sub cmdRemoveComp_Click(sender As Object, e As EventArgs) Handles cmdRemoveComp.Click
        'Removes the selected product from the list
        Dim I As Integer
        Dim newCompressorSetup As New List(Of CompressorData)
        If lstCompressor.SelectedItems.Count = 1 Then
            If lstCompressor.Items.Count = 1 Then
                MsgBox("You can't remove the last item!")
                Exit Sub
            End If

            For I = 0 To VRTM_SimVariables.CompressorSetup.Count - 1
                If Not I = lstCompressor.SelectedIndices(0) Then
                    newCompressorSetup.Add(VRTM_SimVariables.CompressorSetup(I))
                End If
            Next
        End If

        VRTM_SimVariables.CompressorSetup = newCompressorSetup

        UpdateCompressorList()
    End Sub

    Private Sub cmdSaveComp_Click(sender As Object, e As EventArgs) Handles cmdSaveComp.Click
        'Updates the current selected item in the list with the data

        'Error Checking/Validation
        '<<<>>>

        UpdateCalculations() 'Just to make sure again

        'Now does the saving
        Dim newCompressor As New CompressorData

        newCompressor.SelectedCompressorIndex = cmbSelCompressor.SelectedIndex
        newCompressor.Qty = Val(txtQty.Text)
        newCompressor.VolumeDisplacement_m3rev = Val(txtVolDisp.Text)
        newCompressor.VolumeDisplacement_m3h = Val(txtVolDispm3h.Text)
        newCompressor.rpm = Val(txtRPM.Text)
        newCompressor.VolumeEfficiency = Val(txtVolEff.Text) / 100
        If opOneStageNoEco.Checked Then
            newCompressor.CompressorType = CompressorSystemInterconnectionType.OneStageNoEco
        ElseIf opOneStageWithEco.Checked Then
            newCompressor.CompressorType = CompressorSystemInterconnectionType.OneStageEco
        ElseIf opTwoStage.Checked Then
            newCompressor.CompressorType = CompressorSystemInterconnectionType.TwoStage
        End If
        newCompressor.IntermediateT = Val(txtIntermTemp.Text)


        If lstCompressor.SelectedItems.Count = 1 Then
            'Saves over the selected item in the list
            If IndexOfProductBeingEdited = -1 Then Exit Sub
            VRTM_SimVariables.CompressorSetup(lstCompressor.SelectedIndices(0)) = newCompressor
        ElseIf lstCompressor.SelectedItems.Count = 0 Then
            'It's going to add a new one
            VRTM_SimVariables.CompressorSetup.Add(newCompressor)
        Else
            'It seems more than one item is selected
            MsgBox("It seems more than one item is selected in the list, please check!")
        End If

        UpdateCompressorList()
        If IndexOfProductBeingEdited >= 0 Then
            lstCompressor.Items(IndexOfProductBeingEdited).Selected = True
        Else
            lstCompressor.Items(lstCompressor.Items.Count - 1).Selected = True
        End If
        lstCompressor.Select()
    End Sub

#End Region

#Region "Validations"


    Private Sub GeneralValidating(sender As Object, e As CancelEventArgs) Handles txtQty.Validating, txtVolDisp.Validating, txtVolEff.Validating, txtRPM.Validating
        'Validates several textboxes that have a numeric input
        If sender.Enabled = False Then Exit Sub
        If Not (IsNumeric(sender.Text) And Val(sender.text) > 0) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A numeric value larger than 0 must be provided.")
        End If
    End Sub

    Private Sub Validate_Temperature(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIntermTemp.Validating
        'Validates several textboxes that have a numeric input
        If sender.Enabled = False Then Exit Sub
        If Not (IsNumeric(sender.Text) And Val(sender.text) > VRTM_SimVariables.Tevap_Setpoint And Val(sender.text) < VRTM_SimVariables.Tcond) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A numeric value between the Evaporator temperature and the Condenser Temperature must be provided.")
        End If
    End Sub

    Private Sub GeneralValidated(sender As Object, e As EventArgs) Handles txtQty.Validated, txtVolDisp.Validated, txtVolEff.Validated, txtIntermTemp.Validated, txtRPM.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")

        'Updates convection coefficient if enough data is available.
        Dim OkToCalc As Boolean = True
        OkToCalc = OkToCalc And (cmbSelCompressor.SelectedIndex >= 0)
        OkToCalc = OkToCalc And (Val(txtVolDisp.Text) > 0)
        OkToCalc = OkToCalc And (Val(txtRPM.Text) > 0)
        OkToCalc = OkToCalc And (Val(txtVolEff.Text) > 0)

        If OkToCalc Then UpdateCalculations()
    End Sub

#End Region

#Region "Update and Clear"
    Private Sub clearForm()
        'Clears the form for a new item
        txtQty.Text = ""
        txtVolDisp.Text = ""
        txtVolDispm3h.Text = ""
        txtRPM.Text = ""
        txtVolEff.Text = ""
        txtEstimatedCap.Text = ""
        opOneStageNoEco.Checked = True
        opOneStageWithEco.Checked = False
        opTwoStage.Checked = False
        txtIntermTemp.Text = ""

        UpdateCompressorList()
        cmbSelCompressor.SelectedIndex = 0
    End Sub

    Private Sub UpdateCompressorList()
        lstCompressor.Items.Clear()

        If IsNothing(VRTM_SimVariables.CompressorSetup) Then
            VRTM_SimVariables.CompressorSetup = New List(Of CompressorData)
        End If

        For Each Compressor As CompressorData In VRTM_SimVariables.CompressorSetup
            If Compressor.SelectedCompressorIndex = 0 Then
                lstCompressor.Items.Add("Custom")
            Else
                lstCompressor.Items.Add(CompressorList(Compressor.SelectedCompressorIndex - 1).CompressorName)
            End If

            lstCompressor.Items(lstCompressor.Items.Count - 1).SubItems.Add(Compressor.Qty)
            lstCompressor.Items(lstCompressor.Items.Count - 1).SubItems.Add(Round(Compressor.VolumeDisplacement_m3h, 1))
            lstCompressor.Items(lstCompressor.Items.Count - 1).SubItems.Add(Round(Get_Compressor_Capacity(Compressor,
                                                                                                          VRTM_SimVariables.Tevap_Setpoint), 1))
        Next

    End Sub

    Private Sub UpdateCompressorsAvailable()
        'Updates the listbox of compressors
        cmbSelCompressor.Items.Clear()
        cmbSelCompressor.Items.Add("Custom")
        For Each Compressor As CompressorFileInfo In CompressorList
            cmbSelCompressor.Items.Add(Compressor.CompressorName)
        Next
    End Sub

    Private Sub UpdateCalculations()
        'Calculates the volumetric displacement and the SP capacity
        CalculateVolumetricDisplacement()

        Dim C As New CompressorData
        C.VolumeDisplacement_m3h = Val(txtVolDispm3h.Text)
        C.VolumeEfficiency = Val(txtVolEff.Text) / 100
        C.IntermediateT = Val(txtIntermTemp.Text)
        txtEstimatedCap.Text = Trim(Str(Round(Get_Compressor_Capacity(C, VRTM_SimVariables.Tevap_Setpoint), 1)))

    End Sub

    Private Function Get_Compressor_Capacity(Comp As CompressorData, T_evap As Double) As Double
        'Returns the compressor set-point capacity [kW] 

        Dim TE As Double = T_evap
        Dim TC As Double = VRTM_SimVariables.Tcond

        Get_Compressor_Capacity = 0

        If opOneStageNoEco.Checked Then
            'Easiest case. 
            Get_Compressor_Capacity = (Comp.VolumeEfficiency) * Ammonia.rho_G(TE) * (Comp.VolumeDisplacement_m3h / 3600) * (Ammonia.h_G(TE) - Ammonia.h_L(TC)) 'W
            Get_Compressor_Capacity = Get_Compressor_Capacity / 1000 'kW
        ElseIf opOneStageWithEco.Checked Then
            'To be implemented
        ElseIf opTwoStage.Checked Then
            'Similar to One stage without eco, but TC=TI
            Get_Compressor_Capacity = (Comp.VolumeEfficiency) * Ammonia.rho_G(TE) * (Comp.VolumeDisplacement_m3h / 3600) * (Ammonia.h_G(TE) - Ammonia.h_L(Comp.IntermediateT)) 'W
            Get_Compressor_Capacity = Get_Compressor_Capacity / 1000 'kW
        End If

    End Function

    Public Function Get_MR_Capacity(TE As Double) As Double
        'Returns the compressors set-point capacity [kW] 

        If IsNothing(VRTM_SimVariables.CompressorSetup) Then Return 0

        Dim TotalCapacity As Double = 0
        For Each Comp As CompressorData In VRTM_SimVariables.CompressorSetup
            TotalCapacity += Get_Compressor_Capacity(Comp, TE) * Comp.Qty
        Next

        Get_MR_Capacity = TotalCapacity
    End Function

    Public Function Get_Evaporating_Temperature(CurrentCapacity_kW As Double) As Double
        'Returns the Evaporating temperature given some current capacity and the compressors in memory
        'InitialGuess_T is an initial temperature guess [C]

        Get_Evaporating_Temperature = Binary_Search_F(-60, 45, CurrentCapacity_kW, CurrentCapacity_kW / 1000, AddressOf Get_MR_Capacity)
    End Function

    Private Sub CalculateVolumetricDisplacement()
        'Gets the actual volumetric displacement and puts it into the textbox
        Try
            Dim VolDis_m3_rev As Double = Val(txtVolDisp.Text)
            Dim rpm As Double = Val(txtRPM.Text)

            Dim VolDis_m3h As Double = VolDis_m3_rev * rpm * 60

            txtVolDispm3h.Text = Trim(Str(VolDis_m3h))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalculateEconomizerIntermediateTemperature()
        'Calculates the economizer intermediate temperature based on the evaporator and condenser pressures

    End Sub

    Private Sub CalculateTwoStageIntermediateTemperature()
        'Calculates the two stage intermediate temperature based on the evaporator and condenser pressures

    End Sub









#End Region



End Class