
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public class NewRecipeDto
{
    [StringLength(30, MinimumLength = 2)]
    public required string Title { get; set; }

    public required IEnumerable<NewRecipeIngredientDto> RecipeIngredients { get; set; }

    public required IEnumerable<NewUnitsRecipeDto> UnitsRecipe { get; set; }
}