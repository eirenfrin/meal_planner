namespace Backend.Dtos;

public class GetUnitDto
{
    public required Guid Id { get; set; }

    public required string Title { get; set; }

    public required Guid? CreatorId { get; set; }
}