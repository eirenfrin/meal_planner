namespace Backend.Dtos;

public class GetIngredientDto
{
    public required Guid Id { get; set; }

    public required string Title { get; set; }

    public required int? SoldPackageSize { get; set; }

    public required Guid? UnitId { get; set; }

    public required string? UnitTitle { get; set; }

    public required Guid? CreatorId { get; set; }
}