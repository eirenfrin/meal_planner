
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public class NewEditRecipeDto
{
    [StringLength(30, MinimumLength = 2)]
    public required string Title { get; set; }

    public required IEnumerable<NewEditRecipeIngredientDto> RecipeIngredients { get; set; }

    public required IEnumerable<NewEditUnitsRecipeDto> UnitsRecipe { get; set; }
}