using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IRecipeService
{
    public Recipe LoadRecipe(Guid id);
}