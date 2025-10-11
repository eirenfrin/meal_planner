using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IRecipeService
{
    public Task<GetRecipeInfoDto> GetSingleRecipe(Guid recipeId);

    public Task<IEnumerable<GetRecipeBasicInfoDto>> GetAllRecipes(Guid userId);

    public Task<GetRecipeInfoDto> AddNewRecipe(Guid creatorId, NewRecipeDto newRecipe);

    public Task DeleteRecipe(Guid recipeId);

    public Task EditRecipe(Guid creatorId, Guid recipeId, NewRecipeDto recipeEdited);

    public Task<IEnumerable<GetPlannedRecipesDto>> GetRecipesPlannedForDate(Guid userId, DateTime plannedForDate);

    public Task PlanToCookRecipe(Guid userId, PlanRecipeDto plannedRecipe);
}