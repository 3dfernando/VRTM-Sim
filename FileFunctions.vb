Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Module FileFunctions

    Public Sub SaveTRVMVariables(Variable As SimulationVariables, ByVal fullFileName As String)
        'Saves the serializable class into a file
        Dim fs As FileStream = New FileStream(fullFileName, FileMode.OpenOrCreate)

        ' Create binary object
        Dim bf As New BinaryFormatter()

        ' Serialize object to file
        bf.Serialize(fs, Variable)
        fs.Close()

    End Sub

    Public Sub OpenTRVMVariables(ByVal fullFileName As String)
        'Opens the serializable class into a file
        Dim fsRead As New FileStream(fullFileName, FileMode.Open)
        Dim bf As New BinaryFormatter()
        Dim Contents As Object = bf.Deserialize(fsRead)
        fsRead.Close()

        If Contents.GetType.Name = "SimulationVariables" Then
            VRTM_SimVariables = Contents
        Else
            MsgBox("This file is not valid!")
        End If

    End Sub

End Module
