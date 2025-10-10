
namespace Backend.Dtos;

public class GetRecipeBasicInfoDto
{
    public required Guid Id { get; set; }
    
    public required string Title { get; set; }

    public required DateTime? LastCooked { get; set; }
}