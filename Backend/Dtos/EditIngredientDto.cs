namespace Backend.Dtos;
public class EditIngredientDto
{
    public required string Title { get; set; }

    public required int? SoldPackageSize { get; set; }

    public required Guid? UnitId { get; set; }
}