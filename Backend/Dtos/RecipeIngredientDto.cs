
namespace Backend.Dtos;

public class RecipeIngredientDto
{
    public required string IngredientTitle { get; set; }

    public required float? Amount { get; set; }

    public required string UnitTitle { get; set; }
}