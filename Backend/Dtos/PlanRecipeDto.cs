namespace Backend.Dtos;

public class PlanRecipeDto
{
    public required DateTime PlannedStartDate { get; set; }

    public required DateTime PlannedEndDate { get; set; }

    public required float? AmountToCook { get; set; }

    public required Guid RecipeId { get; set; }
}