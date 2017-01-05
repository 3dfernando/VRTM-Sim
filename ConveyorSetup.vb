Imports System.ComponentModel

Public Class frmConveyorSetup

    Private Sub frmConveyorSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loads the variables in VRTMSimData into the interface
        lstConveyors.View = View.Details
        lstConveyors.FullRowSelect = True
        lstConveyors.MultiSelect = False
        lstConveyors.Columns.Add("Index", 40)
        lstConveyors.Columns.Add("Conveyor Tag", 100)
        lstConveyors.Columns.Add("Minimum Ret. Time [h]", 120)
        UpdateList()

        lstProducts.View = View.Details
        lstProducts.Enabled = False
        lstProducts.Columns.Add("Products currently assigned:", 160)

        UpdateProductsInConveyor()

    End Sub

    Private Sub UpdateList()
        'Updates the conveyor list
        lstConveyors.Items.Clear()
        For I As Integer = 0 To VRTM_SimVariables.InletConveyors.Count - 1
            lstConveyors.Items.Add(Str(I))
            lstConveyors.Items(I).SubItems.Add(VRTM_SimVariables.InletConveyors(I).ConveyorTag)
            lstConveyors.Items(I).SubItems.Add(VRTM_SimVariables.InletConveyors(I).MinRetTime)
        Next
        lstConveyors.Items(0).Selected = True
        lstConveyors.Select()
    End Sub

    Private Sub UpdateProductsInConveyor()
        'Based on the selected index, updates the products that are in the conveyor
        Dim SelectedIndex As Integer
        SelectedIndex = lstConveyors.SelectedItems(0).Index

        lstProducts.Items.Clear()

        For I As Integer = 0 To VRTM_SimVariables.ProductMix.Count - 1
            If VRTM_SimVariables.ProductMix(I).ConveyorNumber = SelectedIndex Then
                lstProducts.Items.Add(VRTM_SimVariables.ProductMix(I).ProdName)
            End If
        Next
    End Sub

    Private Sub lstConveyors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstConveyors.SelectedIndexChanged
        If lstConveyors.SelectedItems.Count = 1 Then
            UpdateProductsInConveyor()
            txtConveyorTag.Text = VRTM_SimVariables.InletConveyors(lstConveyors.SelectedItems(0).Index).ConveyorTag
            txtMinTime.Text = Trim(Str(VRTM_SimVariables.InletConveyors(lstConveyors.SelectedItems(0).Index).MinRetTime))
        End If
    End Sub

    Private Sub cmdRemoveConveyor_Click(sender As Object, e As EventArgs) Handles cmdRemoveConveyor.Click
        'Removes the selected conveyor from the list
        Dim I As Integer
        Dim J As Integer
        Dim K As Integer
        Dim newConveyorList() As InletConveyor
        If lstConveyors.SelectedItems.Count = 1 Then
            If lstConveyors.Items.Count = 1 Then
                MsgBox("You can't remove the last item!")
                Exit Sub
            End If

            With lstConveyors.SelectedItems(0)
                I = .Index
                If lstProducts.Items.Count > 0 Then
                    If MsgBox("The currently selected conveyor has products assigned with it." & vbCrLf _
                              & "Removing it will assign those products" & vbCrLf &
                              "with the first conveyor in this list. Proceed?", vbYesNo + vbQuestion) = vbNo Then Exit Sub

                    'Loops through the products that have this conveyor index and change them to 0
                    For J = 0 To UBound(VRTM_SimVariables.ProductMix)
                        If VRTM_SimVariables.ProductMix(J).ConveyorNumber = I Then
                            VRTM_SimVariables.ProductMix(J).ConveyorNumber = 0
                        End If
                    Next
                End If

                ReDim newConveyorList(UBound(VRTM_SimVariables.InletConveyors) - 1)
                For J = 0 To UBound(VRTM_SimVariables.InletConveyors)
                    If J < I Then
                        newConveyorList(J) = VRTM_SimVariables.InletConveyors(J)
                    ElseIf J > I Then
                        newConveyorList(J - 1) = VRTM_SimVariables.InletConveyors(J)
                        'Loops through the products that have this conveyor index and change back one unit 
                        For K = 0 To UBound(VRTM_SimVariables.ProductMix)
                            If VRTM_SimVariables.ProductMix(K).ConveyorNumber = J Then
                                VRTM_SimVariables.ProductMix(K).ConveyorNumber = VRTM_SimVariables.ProductMix(K).ConveyorNumber - 1
                            End If
                        Next
                    End If
                Next
                VRTM_SimVariables.InletConveyors = newConveyorList
                .Remove()
            End With

            clearForm()
            UpdateList()
        End If

    End Sub

    Private Sub cmdAddConveyor_Click(sender As Object, e As EventArgs) Handles cmdAddConveyor.Click
        'Clears the selection
        lstConveyors.SelectedItems.Clear()
        clearForm()
    End Sub

    Private Sub clearForm()
        'Clears the form for a new item
        txtConveyorTag.Text = ""
        txtMinTime.Text = ""
        lstProducts.Items.Clear()
    End Sub

    Private Sub cmdSaveConveyor_Click(sender As Object, e As EventArgs) Handles cmdSaveConveyor.Click
        'Saves the data (Overwrites or creates new)

        'Validates the data inserted
        txtMinTime_Validating(txtMinTime, Nothing)

        'Selects the item to modify/add
        Dim I As Integer

        If lstConveyors.SelectedItems.Count = 1 Then
            'Saves over the selected item in the list
            I = lstConveyors.SelectedItems(0).Index
        ElseIf lstConveyors.SelectedItems.Count = 0 Then
            'It's going to add a new one
            ReDim Preserve VRTM_SimVariables.InletConveyors(UBound(VRTM_SimVariables.InletConveyors) + 1)
            VRTM_SimVariables.InletConveyors(UBound(VRTM_SimVariables.InletConveyors)) = New InletConveyor
            I = UBound(VRTM_SimVariables.InletConveyors)
        Else
            'It seems more than one item is selected
            MsgBox("It seems more than one item is selected in the list, please check!")
        End If

        'Modifies the memory
        VRTM_SimVariables.InletConveyors(I).ConveyorTag = txtConveyorTag.Text
        VRTM_SimVariables.InletConveyors(I).MinRetTime = Val(txtMinTime.Text)


        'Updates
        UpdateList()
        lstConveyors.Items(I).Selected = True
        lstConveyors.Select()

    End Sub

    Private Sub txtMinTime_Validating(sender As Object, e As CancelEventArgs) Handles txtMinTime.Validating
        'Validates several textboxes that have a numeric input
        If Not (IsNumeric(sender.Text) And Val(sender.text) > 0) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            sender.Select(0, sender.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            ErrorProvider1.SetError(sender, "A numeric value must be provided.")
        End If
    End Sub

    Private Sub txtMinTime_Validated(sender As Object, e As EventArgs) Handles txtMinTime.Validated
        ' If all conditions have been met, clear the error provider of errors.
        ErrorProvider1.SetError(sender, "")
    End Sub
End Class