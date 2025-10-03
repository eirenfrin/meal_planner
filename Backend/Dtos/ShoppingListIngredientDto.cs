
namespace Backend.Dtos;

public class ShoppingListIngredientDto
{
    public required string IngredientTitle { get; set; }

    public required float? IngredientAmount { get; set; }
    
    public required string? UnitTitle { get; set; }
}