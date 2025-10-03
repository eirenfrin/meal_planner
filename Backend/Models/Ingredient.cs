using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Ingredient
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required string Title { get; set; }

    public required int? SoldPackageSize { get; set; }

    public required Guid? UnitId { get; set; }

    public required Guid? CreatorId { get; set; }

    [ForeignKey("UnitId")]
    public Unit? Unit { get; set; }

    [ForeignKey("CreatorId")]
    public User? Creator { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public ICollection<ShoppingListIngredient> ShoppingListIngredients { get; set; } = new List<ShoppingListIngredient>();
}