using Backend.Dtos;
using Backend.Enums;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UnitsRecipeRepository(AppDbContext context) : IUnitsRecipeRepository
{
    private readonly AppDbContext _context = context;

    public async Task EditAllUnitsRecipe(Guid recipeId, IEnumerable<NewEditUnitsRecipeDto> unitsRecipeEdited)
    {
        foreach (var unitRecipe in unitsRecipeEdited)
        {
            switch (unitRecipe.EditAction)
            {
                case EditActions.Add:
                    AddUnitRecipe(recipeId, unitRecipe);
                    break;
                case EditActions.Delete:
                    await DeleteUnitRecipe(recipeId, unitRecipe.UnitId);
                    break;
                case EditActions.Update:
                    await EditUnitRecipe(recipeId, unitRecipe);
                    break;
            }
        }

        await _context.SaveChangesAsync();
    }

    private async Task EditUnitRecipe(Guid recipeId, NewEditUnitsRecipeDto unitRecipeEdited)
    {
        var unitRecipeExisting = await _context.UnitsRecipes
        .FirstOrDefaultAsync(ur => ur.RecipeId == recipeId && ur.UnitId == unitRecipeEdited.UnitId);

        if (unitRecipeExisting == null)
        {
            throw new KeyNotFoundException($"Unit {unitRecipeEdited.UnitId} for recipe {recipeId} not found.");
        }

        _context.Entry(unitRecipeExisting).CurrentValues.SetValues(unitRecipeEdited);
    }

    private async Task DeleteUnitRecipe(Guid recipeId, Guid unitId)
    {
        var unitRecipe = await _context.UnitsRecipes
        .FirstOrDefaultAsync(ur => ur.RecipeId == recipeId && ur.UnitId == unitId);

        if (unitRecipe == null)
        {
            throw new KeyNotFoundException($"Unit {unitId} for recipe {recipeId} not found.");
        }

        _context.UnitsRecipes.Remove(unitRecipe);
    }

    private void AddUnitRecipe(Guid recipeId, NewEditUnitsRecipeDto unitRecipeNew)
    {
        var unitRecipe = new UnitsRecipe
        {
            Id = Guid.NewGuid(),
            RecipeAmount = unitRecipeNew.RecipeAmount,
            RecipeId = recipeId,
            UnitId = unitRecipeNew.UnitId
        };

        _context.UnitsRecipes.Add(unitRecipe);
    }
}