using Backend.Dtos;
using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IIngredientRepository
{
    public Task<IEnumerable<Ingredient>> GetAllExistingIngredients(Guid userId);

    public Task AddNewIngredient(Ingredient ingredient);

    public Task EditIngredient(Ingredient ingredientExisting, NewEditIngredientDto ingredientUpdated);

    public Task<Ingredient> DeleteIngredient(Ingredient ingredient);

    public Task DeleteBatchIngredients(IEnumerable<Ingredient> ingredientsToDelete);

    public Task<Ingredient?> GetSingleIngredient(Guid ingredientId);

    public Task<IEnumerable<Ingredient>> GetMultipleIngredients(IEnumerable<Guid> ids);

    public Task<bool> CheckIngredientExistsByName(Guid? creatorId, string ingredientTitle, Guid? ingredientId = null);
}