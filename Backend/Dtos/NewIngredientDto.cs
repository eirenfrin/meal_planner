namespace Backend.Dtos;
public class NewIngredientDto
{
    public required string Title { get; set; }

    public required int? SoldPackageSize { get; set; }

    public required Guid? UnitId { get; set; }

    public required Guid CreatorId { get; set; }
}