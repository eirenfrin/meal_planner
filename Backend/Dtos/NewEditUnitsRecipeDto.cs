using Backend.Enums;

namespace Backend.Dtos;

public class NewEditUnitsRecipeDto
{
    public required float RecipeAmount { get; set; }

    public required Guid UnitId { get; set; }

    public required EditActions? EditAction { get; set; }
}