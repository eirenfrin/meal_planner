
using Backend.Models;

namespace Backend.Dtos;

public class RecipeInfoDto
{
    public required string Title { get; set; }

    public required DateTime? LastCooked { get; set; }

    public required IEnumerable<RecipeIngredientDto> Ingredients { get; set; }

    public required IEnumerable<UnitsRecipeDto> RecipeAmount { get; set; }
}