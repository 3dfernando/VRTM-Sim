Module FoodPropertiesModel
    Public Class FoodProperties
        Public FoodModelUsed As FoodPropertiesListItem

        Public Sub New()

        End Sub

        Public Sub New(FoodModel As FoodPropertiesListItem)
            FoodModelUsed = FoodModel
        End Sub

        Public Sub Initialize()
            'Initializes the food properties model and fills up the important variable arrays

        End Sub

    End Class
End Module
