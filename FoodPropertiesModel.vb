Module FoodPropertiesModel
    Public Class FoodProperties
        Public FoodModelUsed As FoodPropertiesListItem

        Public Sub New()

        End Sub

        Public Sub New(FoodModel As FoodPropertiesListItem)
            FoodModelUsed = FoodModel
        End Sub

    End Class
End Module
