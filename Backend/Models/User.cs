
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class User
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required int MealPrepInterval { get; set; }

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public ICollection<UserCookedRecipe> UserCookedRecipes { get; set; } = new List<UserCookedRecipe>();

    public ICollection<Unit> Units { get; set; } = new List<Unit>();

    public ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
    
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}