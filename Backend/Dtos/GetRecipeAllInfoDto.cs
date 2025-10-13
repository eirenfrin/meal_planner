
using Backend.Models;

namespace Backend.Dtos;

public class GetRecipeAllInfoDto
{
    public required Guid Id { get; set; }

    public required string Title { get; set; }

    public required DateTime? LastCooked { get; set; }

    public required IEnumerable<GetRecipeIngredientDto> Ingredients { get; set; }

    public required IEnumerable<GetUnitsRecipeDto> RecipeAmount { get; set; }
}