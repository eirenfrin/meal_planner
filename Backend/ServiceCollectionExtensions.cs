using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Backend.Services;
using Backend.Services.Interfaces;

namespace Backend;

public static class ServiceCollectionExtensions
{
    public static void AddExtensions(this IServiceCollection services)
    {
        services.AddScoped<IRecipeRepository, RecipeRepository>();

        services.AddScoped<IRecipeService, RecipeService>();
    }
}