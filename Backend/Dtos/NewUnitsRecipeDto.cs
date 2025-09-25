namespace Backend.Dtos;

public class NewUnitsRecipeDto
{
    public required float RecipeAmount { get; set; }

    public required Guid UnitId { get; set; }
}