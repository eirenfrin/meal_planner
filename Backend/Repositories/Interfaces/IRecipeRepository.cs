using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IRecipeRepository
{
    public Recipe GetRecipe(Guid id);
}