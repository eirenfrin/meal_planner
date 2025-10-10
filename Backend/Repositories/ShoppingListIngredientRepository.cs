
// using Backend;
// using Backend.Models;
// using Microsoft.EntityFrameworkCore;

// namespace Backend.Repositories;
// public class ShoppingListIngredientRepository(AppDbContext context) : IShoppingListIngredientRepository
// {
//     private readonly AppDbContext _context = context;

//     public async Task<IEnumerable<ShoppingListIngredient>> GetIngredientsOfShoppingList(Guid shoppingListId)
//     {
//         var ingredientsToBuy = await _context.ShoppingListIngredients
//         .Where(sli => sli.ShoppingListId == shoppingListId)
//         .Select(sli =>).ToListAsync();

//         return ingredientsToBuy;
//     }
// }