namespace Backend.Dtos;

public class GetShoppingListInfoDto
{
    public required DateTime? PlannedStartDate { get; set; }

    public required string Title { get; set; }

    public required bool IsDefault { get; set; }

    public required IEnumerable<ShoppingListIngredientDto> ShoppingListEntries { get; set; }
}