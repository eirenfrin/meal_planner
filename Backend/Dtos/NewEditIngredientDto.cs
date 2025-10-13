using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public class NewEditIngredientDto
{
    [StringLength(30, MinimumLength = 2)]
    public required string Title { get; set; }

    public required int? SoldPackageSize { get; set; }

    public required Guid? UnitId { get; set; }
}