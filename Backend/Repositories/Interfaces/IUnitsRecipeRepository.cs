using Backend.Dtos;
using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IUnitsRecipeRepository
{
    public Task EditAllUnitsRecipe(Guid recipeId, IEnumerable<NewUnitsRecipeDto> unitsRecipeEdited);

    public Task EditUnitRecipe(Guid recipeId, NewUnitsRecipeDto unitRecipeEdited);

    public Task DeleteUnitRecipe(Guid recipeId, Guid unitId);

    public Task AddUnitRecipe(Guid recipeId, NewUnitsRecipeDto unitRecipeNew);
}