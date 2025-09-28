using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class RecipeRepository(AppDbContext context) : IRecipeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Recipe?> GetSingleRecipeWithAllInfo(Guid recipeId)
    {
        var recipe = await _context.Recipes
        .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
        .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Unit)
        .Include(r => r.UnitsRecipes)
            .ThenInclude(ur => ur.Unit)
        .FirstOrDefaultAsync(r => r.Id == recipeId);

        return recipe;
    }

    public async Task<Recipe?> GetSingleRecipeForEditing(Guid recipeId)
    {
        var recipe = await _context.Recipes
        .Include(r => r.RecipeIngredients)
        .Include(r => r.UnitsRecipes)
        .FirstOrDefaultAsync(r => r.Id == recipeId);

        return recipe;
    }

    public async Task<IEnumerable<Recipe>> GetAllRecipes(Guid creatorId)
    {
        var allRecipes = await _context.Recipes
        .Where(r => r.CreatorId == creatorId).ToListAsync();

        return allRecipes;
    }

    public async Task AddRecipe(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task<Recipe> EditRecipe(Recipe recipeUpdated)
    {
        var recipeExisting = await GetSingleRecipe(recipeUpdated.Id);
        _context.Entry(recipeExisting).CurrentValues.SetValues(recipeUpdated);
        await _context.SaveChangesAsync();
        return recipeExisting;

    }

    public async Task DeleteRecipe(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task<Recipe?> GetSingleRecipe(Guid recipeId)
    {
        var recipe = await _context.Recipes.FindAsync(recipeId);

        return recipe;
    }

    public async Task<bool> CheckRecipeAlreadyExistsByTitle(string title)
    {
        var exists = await _context.Recipes.AnyAsync(r => r.Title == title);

        return exists;
    }

}