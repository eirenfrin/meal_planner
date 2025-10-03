namespace Backend.Dtos;

public class GetPlannedRecipesDto
{
    public required string Title { get; set; }

    public required DateTime? LastCooked { get; set; }

    public required DateTime PlannedStartDate { get; set; }

    public required DateTime PlannedEndDate { get; set; }

    public required float? AmountToCook { get; set; }

    public required IEnumerable<UnitsRecipeDto> RecipeAmount { get; set; }
}