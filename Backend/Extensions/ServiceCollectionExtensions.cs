using System.Text;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Backend.Services;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddExtensions(this IServiceCollection services)
    {
        services.AddScoped<IRecipeRepository, RecipeRepository>();

        services.AddScoped<IRecipeService, RecipeService>();

        services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();

        services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();

        services.AddScoped<IIngredientRepository, IngredientRepository>();

        services.AddScoped<IIngredientService, IngredientService>();

        // services.AddScoped<IShoppingListIngredientRepository, ShoppingListIngredientRepository>();

        // services.AddScoped<IShoppingListIngredientService, ShoppingListIngredientService>();

        // services.AddScoped<IShoppingListRepository, ShoppingListRepository>();

        // services.AddScoped<IShoppingListService, ShoppingListService>();

        services.AddScoped<IUnitRepository, UnitRepository>();

        services.AddScoped<IUnitService, UnitService>();

        services.AddScoped<IUnitsRecipeRepository, UnitsRecipeRepository>();

        services.AddScoped<IUnitsRecipeService, UnitsRecipeService>();

        services.AddScoped<IUserCookedRecipeRepository, UserCookedRecipeRepository>();

        services.AddScoped<IUserCookedRecipeService, UserCookedRecipeService>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
    }

    public static void AddJwtAuthentication(
        this IServiceCollection services,
        string issuer,
        string audience,
        string signingKey
    )
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
            };
        });
    }

    public static void AddCorsForFrontend(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .WithOrigins("http://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
    }
}