
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

    public async Task EditAllRecipeIngredients(Guid recipeId, IEnumerable<NewEditRecipeIngredientDto> editedIngredients)
    {
        foreach (var ingredient in editedIngredients)
        {
            switch (ingredient.EditAction)
            {
                case EditActions.Add:
                    AddRecipeIngredient(recipeId, ingredient);
                    break;
                case EditActions.Delete:
                    await DeleteRecipeIngredient(recipeId, ingredient.IngredientId);
                    break;
                case EditActions.Update:
                    await EditRecipeIngredient(recipeId, ingredient);
                    break;
            }
        }

        await _context.SaveChangesAsync();
    }

    private async Task DeleteRecipeIngredient(Guid recipeId, Guid ingredientId)
    {
        var recipeIngredient = await _context.RecipeIngredients
        .FirstOrDefaultAsync(r => r.IngredientId == ingredientId && r.RecipeId == recipeId);

        if (recipeIngredient == null)
        {
            throw new KeyNotFoundException($"Recipe ingredient not found.");
        }

        _context.RecipeIngredients.Remove(recipeIngredient);
    }

    private async Task EditRecipeIngredient(Guid recipeId, NewEditRecipeIngredientDto recipeIngredientEdited)
    {
        var recipeIngredientExisting = await _context.RecipeIngredients
        .FirstOrDefaultAsync(r => r.IngredientId == recipeIngredientEdited.IngredientId && r.RecipeId == recipeId);

        if (recipeIngredientExisting == null)
        {
            throw new KeyNotFoundException($"Ingredient {recipeIngredientEdited.IngredientId} for recipe {recipeId} not found.");
        }

        _context.Entry(recipeIngredientExisting).CurrentValues.SetValues(recipeIngredientEdited);
    }

    private void AddRecipeIngredient(Guid recipeId, NewEditRecipeIngredientDto recipeIngredientNew)
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
    }
}