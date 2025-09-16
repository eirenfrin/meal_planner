using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;
public class UserCookedRecipeService(IUserCookedRecipeRepository userCookedRecipeRepository) : IUserCookedRecipeService
{
    private readonly IUserCookedRecipeRepository _userCookedRecipeRepository = userCookedRecipeRepository;
}