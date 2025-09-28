using Backend.Dtos;
using Backend.Enums;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UnitsRecipeRepository(AppDbContext context) : IUnitsRecipeRepository
{
    private readonly AppDbContext _context = context;

    public async Task EditAllUnitsRecipe(Guid recipeId, IEnumerable<NewUnitsRecipeDto> unitsRecipeEdited)
    {
        foreach (var unitRecipe in unitsRecipeEdited)
        {
            switch (unitRecipe.EditAction)
            {
                case EditActions.Add:
                    await AddUnitRecipe(recipeId, unitRecipe);
                    break;
                case EditActions.Delete:
                    await DeleteUnitRecipe(recipeId, unitRecipe.UnitId);
                    break;
                case EditActions.Update:
                    await EditUnitRecipe(recipeId, unitRecipe);
                    break;
            }
        }
        // put saveChangesAsync here, remove from individual methods
        // catch first exception, no partial updates
    }

    public async Task EditUnitRecipe(Guid recipeId, NewUnitsRecipeDto unitRecipeEdited)
    {
        var unitRecipeExisting = await _context.UnitsRecipes
        .FirstOrDefaultAsync(ur => ur.RecipeId == recipeId && ur.UnitId == unitRecipeEdited.UnitId);

        if (unitRecipeExisting == null)
        {
            throw new KeyNotFoundException($"Unit {unitRecipeEdited.UnitId} for recipe {recipeId} not found.");
        }

        _context.Entry(unitRecipeExisting).CurrentValues.SetValues(unitRecipeEdited);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUnitRecipe(Guid recipeId, Guid unitId)
    {
        var unitRecipe = await _context.UnitsRecipes
        .FirstOrDefaultAsync(ur => ur.RecipeId == recipeId && ur.UnitId == unitId);

        if (unitRecipe == null)
        {
            throw new KeyNotFoundException($"Unit {unitId} for recipe {recipeId} not found.");
        }

        _context.UnitsRecipes.Remove(unitRecipe);
        await _context.SaveChangesAsync();
    }

    public async Task AddUnitRecipe(Guid recipeId, NewUnitsRecipeDto unitRecipeNew)
    {
        var unitRecipe = new UnitsRecipe
        {
            Id = Guid.NewGuid(),
            RecipeAmount = unitRecipeNew.RecipeAmount,
            RecipeId = recipeId,
            UnitId = unitRecipeNew.UnitId
        };

        _context.UnitsRecipes.Add(unitRecipe);
        await _context.SaveChangesAsync();
    }
}