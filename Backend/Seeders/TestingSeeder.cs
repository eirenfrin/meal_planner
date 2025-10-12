
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Seeders;

public static class TestingSeeder
{
    public static void SeedDBWithTestData(this AppDbContext dbContext)
    {
        dbContext.Database.Migrate();

        var userId = Guid.NewGuid();
        var recipeBananaSplitId1 = Guid.NewGuid();
        var recipeBananaSandwichId2 = Guid.NewGuid();
        var unitGramsId1 = Guid.NewGuid();
        var unitPiecesId2 = Guid.NewGuid();
        var ingredientBananasId1 = Guid.NewGuid();
        var ingredientCocoaId2 = Guid.NewGuid();
        var ingredientChocolatesId3 = Guid.NewGuid();

        if (!dbContext.Recipes.Any() && !dbContext.Units.Any() && !dbContext.Users.Any() && !dbContext.Ingredients.Any())
        {
            dbContext.Users.Add(
                new User
                {
                    Id = userId,
                    Username = "Boo",
                    Password = BCrypt.Net.BCrypt.HashPassword("Password42"),
                    MealPrepInterval = 7
                }
            );

            dbContext.Recipes.AddRange(
                new Recipe
                {
                    Id = recipeBananaSplitId1,
                    CreatorId = userId,
                    Title = "Banana split",
                    LastCooked = DateTime.UtcNow
                },

                new Recipe
                {
                    Id = recipeBananaSandwichId2,
                    CreatorId = userId,
                    Title = "Banana Sandwich",
                    LastCooked = DateTime.UtcNow
                }
            );

            dbContext.Units.AddRange(
                new Unit
                {
                    Id = unitGramsId1,
                    CreatorId = userId,
                    Title = "grams"
                },

                new Unit
                {
                    Id = unitPiecesId2,
                    CreatorId = userId,
                    Title = "pieces"
                }
            );

            dbContext.Ingredients.AddRange(
                new Ingredient
                {
                    Id = ingredientBananasId1,
                    Title = "bananas",
                    SoldPackageSize = 500,
                    UnitId = unitGramsId1,
                    CreatorId = userId
                },

                new Ingredient
                {
                    Id = ingredientCocoaId2,
                    Title = "cocoa",
                    SoldPackageSize = 100,
                    UnitId = unitGramsId1,
                    CreatorId = userId
                },

                new Ingredient
                {
                    Id = ingredientChocolatesId3,
                    Title = "chocolates for hubby",
                    SoldPackageSize = 1,
                    UnitId = unitPiecesId2,
                    CreatorId = userId
                }
            );

            dbContext.RecipeIngredients.AddRange(
                new RecipeIngredient
                {
                    Id = Guid.NewGuid(),
                    RecipeId = recipeBananaSplitId1,
                    IngredientId = ingredientBananasId1,
                    UnitId = unitPiecesId2,
                    Amount = 5
                },

                new RecipeIngredient
                {
                    Id = Guid.NewGuid(),
                    RecipeId = recipeBananaSplitId1,
                    IngredientId = ingredientCocoaId2,
                    UnitId = unitGramsId1,
                    Amount = 50
                },

                new RecipeIngredient
                {
                    Id = Guid.NewGuid(),
                    RecipeId = recipeBananaSplitId1,
                    IngredientId = ingredientChocolatesId3,
                    UnitId = unitPiecesId2,
                    Amount = 3
                },

                new RecipeIngredient
                {
                    Id = Guid.NewGuid(),
                    RecipeId = recipeBananaSandwichId2,
                    IngredientId = ingredientBananasId1,
                    UnitId = unitGramsId1,
                    Amount = 200
                },

                new RecipeIngredient
                {
                    Id = Guid.NewGuid(),
                    RecipeId = recipeBananaSandwichId2,
                    IngredientId = ingredientChocolatesId3,
                    UnitId = unitPiecesId2,
                    Amount = 1
                }
            );

            dbContext.UnitsRecipes.AddRange(
                new UnitsRecipe
                {
                    Id = Guid.NewGuid(),
                    RecipeId = recipeBananaSplitId1,
                    UnitId = unitPiecesId2,
                    RecipeAmount = 5
                },

                new UnitsRecipe
                {
                    Id = Guid.NewGuid(),
                    RecipeId = recipeBananaSandwichId2,
                    UnitId = unitGramsId1,
                    RecipeAmount = 300
                }
            );

            dbContext.SaveChanges();
        }

    }
}