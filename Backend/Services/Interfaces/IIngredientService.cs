using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IIngredientService
{
    public Task<IEnumerable<Ingredient>> GetAllIngredients(Guid userId);

    public Task<GetIngredientDto> AddNewIngredient(NewIngredientDto ingredientNew);

    public Task EditIngredient(Guid ingredientId, EditIngredientDto ingredientUpdated);

    public Task DeleteIngredient(Guid ingredientId);
}