using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IRecipeService
{
    public Task<GetRecipeAllInfoDto> GetSingleRecipe(Guid recipeId);

    public Task<IEnumerable<GetRecipeBasicInfoDto>> GetAllRecipes(Guid userId);

    public Task<GetRecipeAllInfoDto> AddNewRecipe(Guid creatorId, NewEditRecipeDto newRecipe);

    public Task DeleteRecipe(Guid recipeId);

    public Task EditRecipe(Guid creatorId, Guid recipeId, NewEditRecipeDto recipeEdited);

    public Task<IEnumerable<GetPlannedRecipesDto>> GetRecipesPlannedForDate(Guid userId, DateTime plannedForDate);

    public Task PlanToCookRecipe(Guid userId, PlanRecipeDto plannedRecipe);
}