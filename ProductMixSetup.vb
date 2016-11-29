Public Class ProductMixSetup
    Private Sub ProductMixSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loads the columns in the listview
        lstProductMix.View = View.Details
        lstProductMix.Columns.Add("Product Name", 100)
        lstProductMix.Columns.Add("Box Weight", 100)
        lstProductMix.Columns.Add("Avg Flow [box/h]", 100)
        lstProductMix.Columns.Add("Inlet Temp. [ºC]", 100)
        lstProductMix.Columns.Add("Outlet Temp. [ºC]", 100)
        lstProductMix.Columns.Add("Thermal Model", 100)
    End Sub
End Class