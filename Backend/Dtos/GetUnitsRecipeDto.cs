namespace Backend.Dtos;

public class GetUnitsRecipeDto
{
    public required string UnitRecipeTitle { get; set; }

    public required float RecipeAmount { get; set; }
}