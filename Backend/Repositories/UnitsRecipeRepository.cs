using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UnitsRecipeRepository(AppDbContext context) : IUnitsRecipeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<UnitsRecipe>> GetAmountForRecipe(Guid recipeId)
    {
        var unitsAmount = await _context.UnitsRecipes
            .Where(ur => ur.RecipeId == recipeId).ToListAsync();
            
        return unitsAmount;
    }
}