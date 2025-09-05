using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class RecipeService(IRecipeRepository recipeRepository) : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository = recipeRepository;

    public Recipe LoadRecipe(Guid id)
    {
        // execute any necessary logic here
        AdditionalPrint();
        return _recipeRepository.GetRecipe(id);
    }

    private static void AdditionalPrint()
    {
        Console.WriteLine("getting recipe");
    }
}