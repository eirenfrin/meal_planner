
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class UnitsRecipe
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required float RecipeAmount { get; set; }

    [Required]
    public required Guid RecipeId { get; set; }

    [Required]
    public required Guid UnitId { get; set; }

    [ForeignKey("RecipeId")]
    public Recipe? Recipe { get; set; }

    [ForeignKey("UnitId")]
    public Unit? Unit { get; set; }
}