
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models; 
public class RecipeIngredient
{
    [Key]
    public required Guid Id { get; set; }

    public required float? Amount { get; set; }

    [Required]
    public required Guid RecipeId { get; set; }

    [Required]
    public required Guid IngredientId { get; set; }

    public required Guid? UnitId { get; set; }

    [ForeignKey("RecipeId")]
    public Recipe? Recipe { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredient? Ingredient { get; set; }

    [ForeignKey("UnitId")]
    public Unit? Unit { get; set; }

}