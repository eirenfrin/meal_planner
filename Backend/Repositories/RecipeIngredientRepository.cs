
using Backend.Dtos;
using System.ComponentModel;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Enums;

namespace Backend.Repositories;


public class RecipeIngredientRepository(AppDbContext context) : IRecipeIngredientRepository
{
    private readonly AppDbContext _context = context;

    public async Task EditAllRecipeIngredients(Guid recipeId, IEnumerable<NewRecipeIngredientDto> editedIngredients)
    {
        foreach (var ingredient in editedIngredients)
        {
            switch (ingredient.EditAction)
            {
                case EditActions.Add:
                    await AddRecipeIngredient(recipeId, ingredient);
                    break;
                case EditActions.Delete:
                    await DeleteRecipeIngredient(recipeId, ingredient.IngredientId);
                    break;
                case EditActions.Update:
                    await EditRecipeIngredient(recipeId, ingredient);
                    break;
            }
        }
    }

    public async Task DeleteRecipeIngredient(Guid recipeId, Guid ingredientId)
    {
        var recipeIngredient = await _context.RecipeIngredients
        .FirstOrDefaultAsync(r => r.IngredientId == ingredientId && r.RecipeId == recipeId);

        if (recipeIngredient == null)
        {
            throw new KeyNotFoundException($"Recipe ingredient not found.");
        }

        _context.RecipeIngredients.Remove(recipeIngredient);
        await _context.SaveChangesAsync();
    }

    public async Task EditRecipeIngredient(Guid recipeId, NewRecipeIngredientDto recipeIngredientEdited)
    {
        var recipeIngredientExisting = await _context.RecipeIngredients
        .FirstOrDefaultAsync(r => r.IngredientId == recipeIngredientEdited.IngredientId && r.RecipeId == recipeId);

        if (recipeIngredientExisting == null)
        {
            throw new KeyNotFoundException($"Ingredient {recipeIngredientEdited.IngredientId} for recipe {recipeId} not found.");
        }

        _context.Entry(recipeIngredientExisting).CurrentValues.SetValues(recipeIngredientEdited);
        await _context.SaveChangesAsync();
    }

    public async Task AddRecipeIngredient(Guid recipeId, NewRecipeIngredientDto recipeIngredientNew)
    {
        var recipeIngredient = new RecipeIngredient
        {
            Id = Guid.NewGuid(),
            Amount = recipeIngredientNew.IngredientAmount,
            RecipeId = recipeId,
            IngredientId = recipeIngredientNew.IngredientId,
            UnitId = recipeIngredientNew.UnitId
        };

        _context.RecipeIngredients.Add(recipeIngredient);
        await _context.SaveChangesAsync();
    }
}