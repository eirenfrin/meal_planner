
using Backend.Models;

namespace Backend.Dtos;

public class GetRecipeInfoDto
{
    public required Guid Id { get; set; }
    
    public required string Title { get; set; }

    public required DateTime? LastCooked { get; set; }

    public required IEnumerable<RecipeIngredientDto> Ingredients { get; set; }

    public required IEnumerable<UnitsRecipeDto> RecipeAmount { get; set; }
}