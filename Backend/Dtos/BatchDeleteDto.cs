namespace Backend.Dtos;

public class BatchDeleteDto
{
    public required IEnumerable<Guid> Ids { get; set; }
}