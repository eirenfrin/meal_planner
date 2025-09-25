using Backend.Dtos;
using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IIngredientRepository
{
    public Task<IEnumerable<Ingredient>> GetAllExistingIngredients(Guid userId);

    public Task AddNewIngredient(Ingredient ingredient);

    public Task EditIngredient(Ingredient ingredientExisting, EditIngredientDto ingredientUpdated);

    public Task<Ingredient> DeleteIngredient(Guid ingredientId);

    public Task<Ingredient?> GetSingleIngredient(Guid ingredientId);

    public Task<bool> CheckIngredientExistsByName(string ingredientTitle);
}