
using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IUserCookedRecipeRepository
{
    public Task PlanRecipe(UserCookedRecipe plannedRecipe);

    public Task<IEnumerable<UserCookedRecipe>> GetRecipesPlannedForDate(Guid userId, DateTime plannedForDate);
}