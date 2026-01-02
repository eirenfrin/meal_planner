
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Backend.Repositories;

public class IngredientRepository(AppDbContext context) : IIngredientRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Ingredient>> GetAllExistingIngredients(Guid userId)
    {
        var ingredients = await _context.Ingredients.
        Where(i => i.CreatorId == userId || i.CreatorId == null)
        .Include(i => i.Unit)
        .ToListAsync();

        return ingredients;
    }

    public async Task AddNewIngredient(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task EditIngredient(Ingredient ingredientExisting, NewEditIngredientDto ingredientUpdated)
    {
        _context.Entry(ingredientExisting).CurrentValues.SetValues(ingredientUpdated);
        await _context.SaveChangesAsync();
    }

    public async Task<Ingredient> DeleteIngredient(Ingredient ingredient)
    {
        _context.Ingredients.Remove(ingredient);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Ingredient is referenced elsewhere.");
        }

        return ingredient;
    }

    public async Task DeleteBatchIngredients(IEnumerable<Ingredient> ingredientsToDelete)
    {
        _context.Ingredients.RemoveRange(ingredientsToDelete);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Some ingredients are referenced elsewhere.");

        }
    }

    public async Task<Ingredient?> GetSingleIngredient(Guid ingredientId)
    {
        var ingredient = await _context.Ingredients.FindAsync(ingredientId);

        return ingredient;
    }

    public async Task<IEnumerable<Ingredient>> GetMultipleIngredients(IEnumerable<Guid> ids)
    {
        var allIngredientsByIds = await _context.Ingredients
        .Where(ing => ids.Contains(ing.Id)).ToListAsync();

        return allIngredientsByIds;
    }

    public async Task<bool> CheckIngredientExistsByName(Guid? creatorId, string ingredientTitle, Guid? ingredientId = null)
    {
        // var exists = await _context.Ingredients
        // .AnyAsync(i => i.Title == ingredientTitle && (i.CreatorId == creatorId || i.CreatorId == null));
        var query = _context.Units.AsQueryable();

        query = query.Where(i => i.Title == ingredientTitle && (i.CreatorId == creatorId || i.CreatorId == null));

        if (ingredientId != null)
        {
            query = query.Where(i => i.Id != ingredientId);
        }

        var exists = await query.AnyAsync();

        return exists;
    }
}