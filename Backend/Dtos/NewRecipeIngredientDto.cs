namespace Backend.Dtos;

public class NewRecipeIngredientDto
{
    public required Guid IngredientId { get; set; }
    public required float? IngredientAmount { get; set; }
    public required Guid? UnitId { get; set; }
}