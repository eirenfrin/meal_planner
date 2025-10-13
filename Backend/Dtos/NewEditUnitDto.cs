
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public class NewEditUnitDto
{
    [StringLength(20, MinimumLength = 1)]
    public required string Title { get; set; }
}