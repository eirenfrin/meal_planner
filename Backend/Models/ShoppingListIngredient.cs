
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class ShoppingListIngredient
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required float IngredientAmount { get; set; }

    [Required]
    public required Guid ShoppingListId { get; set; }

    [Required]
    public required Guid IngredientId { get; set; }
    
    [ForeignKey("ShoppingListId")]
    public ShoppingList? ShoppingList { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredient? Ingredient { get; set; }
}