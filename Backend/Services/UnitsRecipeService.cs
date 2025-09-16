using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;
public class UnitsRecipeService(IUnitsRecipeRepository unitsRecipeRepository) : IUnitsRecipeService
{
    private readonly IUnitsRecipeRepository _unitsRecipeRepository = unitsRecipeRepository;
}