
namespace Backend.Dtos;

public class NewUnitDto
{
    public required string Title { get; set; }

    public required Guid CreatorId { get; set; }
}