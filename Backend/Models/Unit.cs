using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Unit
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required string Title { get; set; }

    public required Guid? CreatorId { get; set; }

    [ForeignKey("CreatorId")]
    public User? Creator { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public ICollection<UnitsRecipe> UnitsRecipes { get; set; } = new List<UnitsRecipe>();

    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public ICollection<ShoppingListIngredient> ShoppingListIngredients { get; set; } = new List<ShoppingListIngredient>();
}