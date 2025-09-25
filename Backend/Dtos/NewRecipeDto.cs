
namespace Backend.Dtos;

public class NewRecipeDto
{
    public required string Title { get; set; }

    public required Guid CreatorId { get; set; }

    public required IEnumerable<NewRecipeIngredientDto> RecipeIngredients { get; set; }

    public required IEnumerable<NewUnitsRecipeDto> UnitsRecipe { get; set; }
}