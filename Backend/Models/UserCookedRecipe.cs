using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class UserCookedRecipe
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required DateTime PlannedStartDate { get; set; }

    [Required]
    public required DateTime PlannedEndDate { get; set; }

    public required float? AmountToCook { get; set; }

    [Required]
    public required Guid UserId { get; set; }

    [Required]
    public required Guid RecipeId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    [ForeignKey("RecipeId")]
    public Recipe? Recipe { get; set; }
}